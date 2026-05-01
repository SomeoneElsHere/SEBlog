using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Numerics;
namespace webapp1.Controllers
{
    public class SpecialText
    {
        public static Image wavyTextchar(string text, int i)
        {
            FontCollection collection = new FontCollection();
            FontCollectionExtensions.AddSystemFonts(collection);
            if (collection.TryGet("Arial", out FontFamily family))
            {
                var col = new Rgba32(0, 0, 0, 255); //black

                Image<Rgba32> img = new Image<Rgba32>(text.Length*100, 100, col);
                
                var fnt = family.CreateFont(100, FontStyle.Italic);
                Action<IImageProcessingContext> op = (IImageProcessingContext context) =>
                {
                    DrawingOptions d = new DrawingOptions(); //text options and drawing options
                    TextOptions top = new TextOptions(fnt);
                    
                    //d.Transform = Matrix3x2.Create(new Vector2(0, 0), new Vector2(40,0), new Vector2(0, 0));
                    
                    string s = "";
                    if (i != -1)
                    {
                        for (int q = 0; q < i; q++)
                        {
                            s += "   ";
                        }
                    }
                    if (i == -1)
                    {
                        var c = text.ToCharArray();
                        int q;
                        for (q = 0; q<text.Length-1; q++)
                        {
                            s += c[q];
                            s += "  ";
                        }
                        s += c[q];
                    }
                    else
                    {
                        s += text.ElementAt(i); //get char in a space
                    }
                    DrawPathCollectionExtensions.Draw(context, d, new SolidPen(Color.White, 1f), TextBuilder.GenerateGlyphs(s, top)); // draws a char in its space

                };
                img.Mutate(op);
                return img;

            }
            return null;
        }
        public static void wavytext(string text)
        {
            var img = wavyTextchar(text, 0);
            ImageFrameCollection frames = img.Frames;
            for (int i = 1; i < text.Length; i++)
            {
                frames.AddFrame(wavyTextchar(text, i).Frames.First());
                frames.AddFrame(wavyTextchar(text, i).Frames.First());
                
            }
            frames.AddFrame(wavyTextchar(text, -1).Frames.First());
            img.SaveAsGif("wwwroot/lib/wavytext/"+text+".gif");
            img.Dispose();

        }

        

    }
}

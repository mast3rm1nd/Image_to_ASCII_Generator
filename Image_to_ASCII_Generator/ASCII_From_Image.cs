using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;

namespace Image_to_ASCII_Generator
{
    class ASCII_From_Image
    {
        private static string chars_by_density = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\"^`'. ";

        public static void Generate(string image_path, string result_path)
        {          
            var img = new Bitmap(image_path);

            using (var stream_writer = new StreamWriter(result_path))
            {
                for(var y = 0; y < img.Height; y++)
                {
                    for(var x = 0; x < img.Width; x++)
                    {
                        var color = img.GetPixel(x, y);
                        var brightness = Calculate_Brightness_from_Colour(color);
                        var index_of_char = brightness / 255 * (chars_by_density.Length - 1);
                        var char_to_place = chars_by_density[(int)Math.Round(index_of_char)];

                        stream_writer.Write(char_to_place);
                        stream_writer.Write(char_to_place);
                    }
                    stream_writer.WriteLine();
                }
            }
        }


        private static double Calculate_Brightness_from_Colour(Color c)
        {
            return (int)Math.Sqrt(
                c.R * c.R * .241 +
                c.G * c.G * .641 +
                c.B * c.B * .068);
        }
    }
}

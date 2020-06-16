
using LlamaCorp.ImageProcessing.Dither.Entities;

using LlamaCorp.ImageProcessing.Dither.Interfaces;

namespace LlamaCorp.ImageProcessing.Dither.Implementations
{
    /// <summary>
    ///     Simple Comparison compares each pixel value to gray (255 / 2)
    ///     Darker color becomes black, lighter becomes white
    /// </summary>
    public class SimpleComparison : IDither
    {
        public void PerformWork(Image image, Parameters parameters = null)
        {
            if (parameters == null)
            {
                parameters = new Parameters();
            }

            for (var i = 0; i < image.Pixels.Length; i++)
            {
                var pixel = image.Pixels[i];
                var avg = pixel.R * parameters.R_Multiplier + pixel.G * parameters.G_Multiplier + pixel.B * parameters.B_Multiplier;

                if (avg < parameters.Threshold)
                {
                    avg = 0;
                }
                else
                {
                    avg = 255;
                }

                image.Pixels[i] = new Pixel { R = (byte) avg, G = (byte) avg, B = (byte) avg, A = 255 };
            }
        }
    }
}
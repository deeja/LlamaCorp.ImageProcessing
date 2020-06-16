
using LlamaCorp.ImageProcessing.Dither.Entities;

using LlamaCorp.ImageProcessing.Dither.Interfaces;

namespace LlamaCorp.ImageProcessing.Dither.Implementations
{
    public class OneDimensional : IDither
    {
        public void PerformWork(Image image, Parameters parameters = null)
        {
            if (parameters == null)
            {
                parameters = new Parameters();
            }

            var error = 0;

            for (var i = 0; i < image.Pixels.Length; i++)
            {
                var pixel = image.Pixels[i];
                var avg = pixel.R * parameters.R_Multiplier + pixel.G * parameters.G_Multiplier + pixel.B * parameters.B_Multiplier;

                avg += pixel.Error;

                if (avg < parameters.Threshold)
                {
                    error = (int) avg;
                    avg = 0;
                }
                else
                {
                    error = (int) (avg - 255);
                    avg = 255;
                }

                if ((i + 1) % image.Width != 0)
                {
                    image.Pixels[i + 1].Error = error;
                }

                image.Pixels[i] = new Pixel { R = (byte) avg, G = (byte) avg, B = (byte) avg, A = 255 };
            }
        }
    }
}
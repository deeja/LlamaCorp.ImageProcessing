using LlamaCorp.ImageProcessing.Dither.Entities;

namespace LlamaCorp.ImageProcessing.Dither.Interfaces
{
    public interface IDither
    {
        void PerformWork(Image image, Parameters parameters = null);
    }
}
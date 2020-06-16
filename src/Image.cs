namespace LlamaCorp.ImageProcessing
{
    public class Image
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Pixel[] Pixels { get; set; }

        public Pixel GetPixel(int x, int y)
        {
            var index = Width * y + x;
            return Pixels[index];
        }

        public int GetPixelIndex(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return -1;
            }

            return Width * y + x;
        }

        public void SetPixel(int x, int y, Pixel pixel)
        {
            var index = GetPixelIndex(x, y);
            if (index == -1)
            {
                return;
            }

            Pixels[index] = pixel;
        }

        public void SetPixelError(int x, int y, double error)
        {
            SetPixelError(x, y, (int) error);
        }

        public void SetPixelError(int x, int y, int error)
        {
            var index = GetPixelIndex(x, y);
            if (index == -1)
            {
                return;
            }

            Pixels[index].Error = error;
        }
    }
}
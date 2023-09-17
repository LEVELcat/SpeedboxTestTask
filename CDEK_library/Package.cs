using System.Text.Json.Serialization;

namespace CDEK_library
{
    public class Package
    {
        public int Weight { get; set; }

        public int Length_mm { get; set; }

        public int Width_mm { get; set; }

        public int Height_mm { get; set; }

        public Package(int weight, int length, int width, int height)
        {
            Weight = weight;
            Length_mm = length;
            Width_mm = width;
            Height_mm = height;
        }
    }
}

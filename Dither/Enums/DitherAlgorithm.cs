namespace LlamaCorp.ImageProcessing.Dither.Enums
{
  public enum DitherAlgorithm
  {
    None = 0,

    SimpleComparison,

    OneDimensional,

    TwoDimensional,

    FloydSteinberg,

    FalseFloydSteinberg,

    JarvisJudiceNinke,

    Stucki,

    Atkinson,

    Burkes,

    Sierra3,

    TwoRowSierra,

    SierraLite,

    //Bayer4x4,

    //Bayer8x8,
  }
}
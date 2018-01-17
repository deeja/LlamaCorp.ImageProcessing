using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaCorp.ImageProcessing.Dither.Entities
{
  public class Parameters
  {

    public int Threshold { get; set; } = 127;

    public decimal R_Multiplier { get; set; } = 0.333m;

    public decimal G_Multiplier { get; set; } = 0.333m;

    public decimal B_Multiplier { get; set; } = 0.333m;

  }
}

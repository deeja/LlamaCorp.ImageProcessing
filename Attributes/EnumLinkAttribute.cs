using System;

namespace LlamaCorp.ImageProcessing.Attributes
{
  public class EnumLinkAttribute : Attribute
  {
    public Type EnumType { get; set; }

    public int EnumValue { get; set; }

    public Type Type { get; set; }

    public EnumLinkAttribute(Type EnumType, int EnumValue)
    {
      this.EnumType = EnumType;
      this.EnumValue = EnumValue;
    }
  }
}
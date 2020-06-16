using LlamaCorp.ImageProcessing.Dither.Interfaces;
using LlamaCorp.ImageProcessing.Dither.Enums;
using System;
using LlamaCorp.ImageProcessing.Dither.Implementations;
using System.Reflection;
using System.Linq;
using LlamaCorp.ImageProcessing.Attributes;
using System.Collections.Generic;

namespace LlamaCorp.ImageProcessing.Dither
{
  public static class Factory
  {
    private static List<EnumLinkAttribute> _enumLinks = new List<EnumLinkAttribute>();

    public static IDither CreateDither(DitherAlgorithm ditherAlgorithm)
    {
      Initialize();

      IDither dither = null;

      var attribute = _enumLinks.Where(l => l.EnumValue == (int)ditherAlgorithm);

      if (attribute.Any())
      {
        var foundAttribute = attribute.First();
        dither = (IDither)Activator.CreateInstance(foundAttribute.Type);
      }
      else
      {
        throw new NotSupportedException(ditherAlgorithm.ToString() + " is not supported");
      }

      return dither;
    }

    private static bool _initialized = false;

    public static void Initialize()
    {
      if (_initialized) return;
      _initialized = true;

      var assemblyName = "LlamaCorp.ImageProcessing";
      Assembly assembly = Assembly.Load(assemblyName);

      var elementTypeAttributes =
          from t in assembly.GetTypes()
          let attributes = t.GetCustomAttributes(typeof(EnumLinkAttribute), true)
          where attributes != null && attributes.Length > 0
          select AddTypeValue((EnumLinkAttribute)attributes.First(), t);

      _enumLinks = elementTypeAttributes.Where(t => t.EnumType == typeof(DitherAlgorithm)).ToList();

    }

    private static EnumLinkAttribute AddTypeValue(EnumLinkAttribute enumLinkAttribute, Type t)
    {
      enumLinkAttribute.Type = t;
      return enumLinkAttribute;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LlamaCorp.ImageProcessing.Attributes;
using LlamaCorp.ImageProcessing.Dither.Enums;
using LlamaCorp.ImageProcessing.Dither.Interfaces;

namespace LlamaCorp.ImageProcessing.Dither
{
    public static class Factory
    {
        private static List<EnumLinkAttribute> _enumLinks = new List<EnumLinkAttribute>();

        private static bool _initialized;

        public static IDither CreateDither(DitherAlgorithm ditherAlgorithm)
        {
            Initialize();

            IDither dither = null;

            var attribute = _enumLinks.Where(l => l.EnumValue == (int) ditherAlgorithm);

            if (attribute.Any())
            {
                var foundAttribute = attribute.First();
                dither = (IDither) Activator.CreateInstance(foundAttribute.Type);
            }
            else
            {
                throw new NotSupportedException(ditherAlgorithm + " is not supported");
            }

            return dither;
        }

        public static void Initialize()
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            var assemblyName = "LlamaCorp.ImageProcessing";
            var assembly = Assembly.Load(assemblyName);

            var elementTypeAttributes = from t in assembly.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(EnumLinkAttribute), true)
                where attributes != null && attributes.Length > 0
                select AddTypeValue((EnumLinkAttribute) attributes.First(), t);

            _enumLinks = elementTypeAttributes.Where(t => t.EnumType == typeof(DitherAlgorithm)).ToList();
        }

        private static EnumLinkAttribute AddTypeValue(EnumLinkAttribute enumLinkAttribute, Type t)
        {
            enumLinkAttribute.Type = t;
            return enumLinkAttribute;
        }
    }
}
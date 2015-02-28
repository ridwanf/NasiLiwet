using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Ridwan.Web.NasiLiwet.Web.helper
{
    public class ConventionProvider:DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, 
            Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var meta = base.CreateMetadata(attributes, containerType, modelAccessor,
                modelType, propertyName);
            if (meta.DisplayName == null)
                meta.DisplayName =
                    meta.PropertyName.ToSeparateWords();
            return meta;

        }
    }

    public static class StringExtensions
    {
        public static string ToSeparateWords(this string value)
        {
            return value != null ? Regex.Replace(value, "([A-Z][a-z]?)", " $1").Trim() : value;
        }
    }
}
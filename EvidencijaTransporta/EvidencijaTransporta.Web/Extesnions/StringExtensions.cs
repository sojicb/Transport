using System;

namespace EvidencijaTransporta.Web.Extesnions
{
	public static class StringExtensions
	{
        public static string RemoveSuffix(this string source, string suffix)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (suffix == null) throw new ArgumentNullException(nameof(suffix));

            if (!source.Contains(suffix)) return source;

            return source.Substring(0, source.Length - suffix.Length);
        }
    }
}
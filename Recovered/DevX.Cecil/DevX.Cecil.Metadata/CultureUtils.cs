using System;
using System.Collections;
using System.Globalization;

namespace DevX.Cecil.Metadata
{
	internal sealed class CultureUtils
	{
		private static IDictionary m_cultures;

		private CultureUtils()
		{
		}

		private static void LoadCultures()
		{
			if (m_cultures != null)
			{
				return;
			}
			CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
			m_cultures = new Hashtable(cultures.Length + 2);
			CultureInfo[] array = cultures;
			foreach (CultureInfo cultureInfo in array)
			{
				if (!m_cultures.Contains(cultureInfo.Name))
				{
					m_cultures.Add(cultureInfo.Name, cultureInfo);
				}
			}
			if (!m_cultures.Contains(string.Empty))
			{
				m_cultures.Add(string.Empty, CultureInfo.InvariantCulture);
			}
			m_cultures.Add("neutral", CultureInfo.InvariantCulture);
		}

		public static bool IsValid(string culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			LoadCultures();
			return m_cultures.Contains(culture);
		}

		public static CultureInfo GetCultureInfo(string culture)
		{
			if (IsValid(culture))
			{
				return m_cultures[culture] as CultureInfo;
			}
			return CultureInfo.InvariantCulture;
		}
	}
}

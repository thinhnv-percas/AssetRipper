using System.Globalization;

internal class DevXUnity
{
	internal static bool SelectLocalizationName(string localization_name)
	{
		return true;
	}

	internal static string GetSelectedLocalizationName()
	{
		return CultureInfo.CurrentCulture.Name.Split('-')[0];
	}

	internal static string Translate(string string_ref)
	{
		return string_ref;
	}

	internal static string Tr(string string_ref)
	{
		return string_ref;
	}

	internal static string NoTr(string string_ref)
	{
		return string_ref;
	}

	internal static string NoTranslate(string string_ref)
	{
		return string_ref;
	}

	internal static string NoStringEncrypt(string string_ref)
	{
		return string_ref;
	}
}

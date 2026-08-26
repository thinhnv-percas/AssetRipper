using System.Collections.Generic;
using dnSpy.Contracts.Extension;
using dnSpy.Decompiler.ILSpy.Properties;

namespace dnSpy.Decompiler.ILSpy;

[ExportExtension]
internal sealed class TheExtension : IExtension
{
	public IEnumerable<string> MergedResourceDictionaries
	{
		get
		{
			yield return "Themes/wpf.styles.templates.xaml";
		}
	}

	public ExtensionInfo ExtensionInfo
	{
		get
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			return new ExtensionInfo
			{
				ShortDescription = dnSpy_Decompiler_ILSpy_Resources.Plugin_ShortDescription,
				Copyright = "Copyright 2011-2014 AlphaSierraPapa for the SharpDevelop Team"
			};
		}
	}

	public void OnEvent(ExtensionEvent @event, object obj)
	{
	}
}

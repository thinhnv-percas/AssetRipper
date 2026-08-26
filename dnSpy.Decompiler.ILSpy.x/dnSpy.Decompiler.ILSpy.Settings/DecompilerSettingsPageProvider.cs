using System.Collections.Generic;
using System.ComponentModel.Composition;
using dnSpy.Contracts.Settings.Dialog;
using ICSharpCode.Decompiler;

namespace dnSpy.Decompiler.ILSpy.Settings;

[Export(typeof(IAppSettingsPageProvider))]
internal sealed class DecompilerSettingsPageProvider : IAppSettingsPageProvider
{
	private readonly DecompilerSettings decompilerSettings;

	private readonly ILSettingsImpl ilSettings;

	[ImportingConstructor]
	private DecompilerSettingsPageProvider(DecompilerSettingsImpl decompilerSettings, ILSettingsImpl ilSettings)
	{
		this.decompilerSettings = decompilerSettings;
		this.ilSettings = ilSettings;
	}

	public IEnumerable<AppSettingsPage> Create()
	{
		yield return (AppSettingsPage)(object)new CSharpDecompilerSettingsPage(decompilerSettings);
		yield return (AppSettingsPage)(object)new ILDecompilerSettingsPage(ilSettings);
	}
}

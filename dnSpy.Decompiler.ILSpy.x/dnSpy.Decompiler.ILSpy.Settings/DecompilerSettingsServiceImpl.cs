using System.ComponentModel.Composition;
using dnSpy.Decompiler.ILSpy.Core.Settings;

namespace dnSpy.Decompiler.ILSpy.Settings;

[Export(typeof(DecompilerSettingsService))]
internal sealed class DecompilerSettingsServiceImpl : DecompilerSettingsService
{
	[ImportingConstructor]
	private DecompilerSettingsServiceImpl(DecompilerSettingsImpl decompilerSettings, ILSettingsImpl ilSettings)
	{
		base.CSharpVBDecompilerSettings = new CSharpVBDecompilerSettings(decompilerSettings);
		base.ILDecompilerSettings = new ILDecompilerSettings(ilSettings);
	}
}

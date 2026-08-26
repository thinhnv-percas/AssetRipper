using System;
using dnSpy.Contracts.Settings.Dialog;
using dnSpy.Decompiler.ILSpy.Core.Settings;
using dnSpy.Decompiler.ILSpy.Properties;

namespace dnSpy.Decompiler.ILSpy.Settings;

internal sealed class ILDecompilerSettingsPage : AppSettingsPage, IAppSettingsPage2
{
	private readonly ILSettings _global_ilSettings;

	private readonly ILSettings ilSettings;

	public override double Order => 11000.0;

	public string Name => dnSpy_Decompiler_ILSpy_Resources.ILDecompilerSettingsTabName;

	public ILSettings Settings => ilSettings;

	public override Guid ParentGuid => new Guid("E380FC93-BACB-4125-8AF1-ADFAEA4D1307");

	public override Guid Guid => new Guid("0F8FBD3F-01DA-4AF0-9316-B7B5C8901A74");

	public override string Title => "IL (ILSpy)";

	public override object UIObject => this;

	public ILDecompilerSettingsPage(ILSettings ilSettings)
	{
		_global_ilSettings = ilSettings;
		this.ilSettings = ilSettings.Clone();
	}

	public override void OnApply()
	{
		throw new InvalidOperationException();
	}

	public void OnApply(IAppRefreshSettings appRefreshSettings)
	{
		if (!_global_ilSettings.Equals(ilSettings))
		{
			appRefreshSettings.Add(SettingsConstants.REDISASSEMBLE_IL_ILSPY_CODE, (object)null);
		}
		ilSettings.CopyTo(_global_ilSettings);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.ILSpy.Core.Properties;
using dnSpy.Decompiler.Settings;

namespace dnSpy.Decompiler.ILSpy.Core.Settings;

internal sealed class ILDecompilerSettings : DecompilerSettingsBase
{
	private readonly ILSettings ilSettings;

	private readonly IDecompilerOption[] options;

	public ILSettings Settings => ilSettings;

	public override int Version => ilSettings.SettingsVersion;

	public override IEnumerable<IDecompilerOption> Options => options;

	public override event EventHandler VersionChanged;

	public ILDecompilerSettings(ILSettings ilSettings = null)
	{
		this.ilSettings = ilSettings ?? new ILSettings();
		options = CreateOptions().ToArray();
		this.ilSettings.SettingsVersionChanged += ILSettings_SettingsVersionChanged;
	}

	private void ILSettings_SettingsVersionChanged(object sender, EventArgs e)
	{
		VersionChanged?.Invoke(this, EventArgs.Empty);
	}

	public override DecompilerSettingsBase Clone()
	{
		return new ILDecompilerSettings(ilSettings.Clone());
	}

	private IEnumerable<IDecompilerOption> CreateOptions()
	{
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowILComments_GUID, () => ilSettings.ShowILComments, delegate(bool a)
		{
			ilSettings.ShowILComments = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowILComments,
			Name = DecompilerOptionConstants.ShowILComments_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowXmlDocumentation_GUID, () => ilSettings.ShowXmlDocumentation, delegate(bool a)
		{
			ilSettings.ShowXmlDocumentation = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowXMLDocComments,
			Name = DecompilerOptionConstants.ShowXmlDocumentation_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowTokenAndRvaComments_GUID, () => ilSettings.ShowTokenAndRvaComments, delegate(bool a)
		{
			ilSettings.ShowTokenAndRvaComments = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowTokensRvasOffsets,
			Name = DecompilerOptionConstants.ShowTokenAndRvaComments_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowILBytes_GUID, () => ilSettings.ShowILBytes, delegate(bool a)
		{
			ilSettings.ShowILBytes = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowILInstrBytes,
			Name = DecompilerOptionConstants.ShowILBytes_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.SortMembers_GUID, () => ilSettings.SortMembers, delegate(bool a)
		{
			ilSettings.SortMembers = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_SortMethods,
			Name = DecompilerOptionConstants.SortMembers_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowPdbInfo_GUID, () => ilSettings.ShowPdbInfo, delegate(bool a)
		{
			ilSettings.ShowPdbInfo = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowPdbInfo,
			Name = DecompilerOptionConstants.ShowPdbInfo_NAME
		};
	}

	public override bool Equals(object obj)
	{
		if (obj is ILDecompilerSettings)
		{
			return ilSettings.Equals(((ILDecompilerSettings)obj).ilSettings);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ilSettings.GetHashCode();
	}
}

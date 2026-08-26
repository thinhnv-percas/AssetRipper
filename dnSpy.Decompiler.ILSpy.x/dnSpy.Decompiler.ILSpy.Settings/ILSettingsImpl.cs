using System;
using System.ComponentModel.Composition;
using dnSpy.Contracts.Settings;
using dnSpy.Decompiler.ILSpy.Core.Settings;

namespace dnSpy.Decompiler.ILSpy.Settings;

[Export]
internal sealed class ILSettingsImpl : ILSettings
{
	private static readonly Guid SETTINGS_GUID = new Guid("DD6752B1-5336-4601-A9B2-0879E18AE9F3");

	private readonly ISettingsService settingsService;

	private readonly bool disableSave;

	[ImportingConstructor]
	private ILSettingsImpl(ISettingsService settingsService)
	{
		this.settingsService = settingsService;
		disableSave = true;
		ISettingsSection orCreateSection = settingsService.GetOrCreateSection(SETTINGS_GUID);
		base.ShowILComments = orCreateSection.Attribute<bool?>("ShowILComments") ?? base.ShowILComments;
		base.ShowXmlDocumentation = orCreateSection.Attribute<bool?>("ShowXmlDocumentation") ?? base.ShowXmlDocumentation;
		base.ShowTokenAndRvaComments = orCreateSection.Attribute<bool?>("ShowTokenAndRvaComments") ?? base.ShowTokenAndRvaComments;
		base.ShowILBytes = orCreateSection.Attribute<bool?>("ShowILBytes") ?? base.ShowILBytes;
		base.SortMembers = orCreateSection.Attribute<bool?>("SortMembers") ?? base.SortMembers;
		base.ShowPdbInfo = orCreateSection.Attribute<bool?>("ShowPdbInfo") ?? base.ShowPdbInfo;
		disableSave = false;
	}

	protected override void OnModified()
	{
		if (!disableSave)
		{
			ISettingsSection val = settingsService.RecreateSection(SETTINGS_GUID);
			val.Attribute<bool>("ShowILComments", base.ShowILComments);
			val.Attribute<bool>("ShowXmlDocumentation", base.ShowXmlDocumentation);
			val.Attribute<bool>("ShowTokenAndRvaComments", base.ShowTokenAndRvaComments);
			val.Attribute<bool>("ShowILBytes", base.ShowILBytes);
			val.Attribute<bool>("SortMembers", base.SortMembers);
			val.Attribute<bool>("ShowPdbInfo", base.ShowPdbInfo);
		}
	}
}

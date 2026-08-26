using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DevXUnityUnpackerTools.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => defaultInstance;

		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("False")]
		public bool ShowClassicWaitPanel
		{
			get
			{
				return (bool)this["ShowClassicWaitPanel"];
			}
			set
			{
				this["ShowClassicWaitPanel"] = value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		public bool Disable_auo_open_result_files
		{
			get
			{
				return (bool)this["Disable_auo_open_result_files"];
			}
			set
			{
				this["Disable_auo_open_result_files"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool ShowFastMenu
		{
			get
			{
				return (bool)this["ShowFastMenu"];
			}
			set
			{
				this["ShowFastMenu"] = value;
			}
		}

		[UserScopedSetting]
		[DefaultSettingValue("False")]
		[DebuggerNonUserCode]
		public bool DisableSaveChangesToAssetsPressApplyChanges
		{
			get
			{
				return (bool)this["DisableSaveChangesToAssetsPressApplyChanges"];
			}
			set
			{
				this["DisableSaveChangesToAssetsPressApplyChanges"] = value;
			}
		}
	}
}

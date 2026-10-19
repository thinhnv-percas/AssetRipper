using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Lofelt.NiceVibrations;
using Reflex.Attributes;
using Unco.SettingsSystem.Core;
using UnityEngine;

namespace Unco.SettingsSyste.Core
{
	[Token(Token = "0x2000009")]
	public class HapticManager : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x20")]
		private float HapticDelay;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x24")]
		private bool _isPlatformSupported;

		[Inject(false)]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		private SettingsManager _settings;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x30")]
		private readonly Dictionary<HapticCategory, float> _lastPlayTime;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x38")]
		private bool _isEnabled;

		[Token(Token = "0x17000004")]
		public bool IsEnabled
		{
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x7AF2258", Offset = "0x7AF2258", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settings;\n\tv9 = v6._settingsData;\n\treturnVal1 = v9.Flags & 1;\n\treturn returnVal1;\n")]
			get
			{
				SettingsManager settings = _settings;
				SettingsStorageData settingsData = settings._settingsData;
				return (byte)(settingsData.Flags & 1) != 0;
			}
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x7AF2284", Offset = "0x7AF2284", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._isEnabled = value;\n\treturn;\n")]
			set
			{
				_isEnabled = value;
			}
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x7AF228C", Offset = "0x7AF228C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settings;\n\tv9 = v6._settingsData;\n\treturnVal1 = v9.Flags & 1;\n\treturn returnVal1;\n")]
		public bool IsHapticsEnabled()
		{
			SettingsManager settings = _settings;
			SettingsStorageData settingsData = settings._settingsData;
			return (byte)(settingsData.Flags & 1) != 0;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x7AF22B8", Offset = "0x7AF22B8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv50 = UnityEngine.Application::get_isMobilePlatform();\n\tthis._isPlatformSupported = v50;\n\tv58 = ~v50;\n\tif (v58) goto L_004A;\n\tgoto L_0027;\nL_0027:\n\tv94 = Lofelt.NiceVibrations.HapticController::Init();\n\treturn;\nL_004A:\n\tgoto L_0054;\nL_0054:\n\tUnityEngine.Debug::LogWarning(\"[HapticManager] Haptic feedback is not supported on this platform.\");\n\treturn;\n")]
		public void Awake()
		{
			if (_isPlatformSupported = Application.isMobilePlatform)
			{
				bool flag = HapticController.Init();
			}
			else
			{
				Debug.LogWarning("[HapticManager] Haptic feedback is not supported on this platform.");
			}
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x7AF23E4", Offset = "0x7AF23E4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settings;\n\tv9 = v6._settingsRemoteConfig;\n\tv10 = v6._settingsRemoteConfig == 0;\n\tif (v10) goto L_0016;\n\tv64 = v9.Haptic == -1;\n\tif (v64) goto L_0027;\nL_0016:\n\tv42 = v6._settingsData;\n\tv72 = state == 0;\n\tif (v72) goto L_0022;\n\tv82 = v42.Flags | 1;\n\tgoto L_0023;\nL_0022:\n\tv82 = v42.Flags & -2;\nL_0027:\n\treturn;\nL_0023:\n\tv42.Flags = v82;\n")]
		public void SetHapticsEnabled(bool state)
		{
			SettingsManager settings = _settings;
			SettingsRemoteConfig settingsRemoteConfig = settings._settingsRemoteConfig;
			if (settings._settingsRemoteConfig == null || settingsRemoteConfig.Haptic != -1)
			{
				SettingsStorageData settingsData = settings._settingsData;
				int flags = ((!state) ? (settingsData.Flags & -2) : (settingsData.Flags | 1));
				settingsData.Flags = flags;
			}
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x7AF243C", Offset = "0x7AF243C", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv56 = v51._settingsData;\n\tv117 = v56.Flags & 1;\n\tv118 = v117 == 0;\n\tif (v118) goto L_006C;\n\tv73 = this._isPlatformSupported != 1;\n\tif (v73) goto L_006C;\n\tv69 = UnityEngine.Time::get_unscaledTime();\n\tv147 = System.Collections.Generic.Dictionary`2<Unco.SettingsSyste.Core.HapticCategory, System.Single>::TryGetValue(this._lastPlayTime, category, &v61 @ stack_-44_v4 (System.Single));\n\tv150 = ~v147;\n\tif (v150) goto L_0057;\n\tv129 = v69 - v61;\n\tv140 = v129 < cooldown;\n\tif (v140) goto L_006C;\nL_0057:\n\tSystem.Collections.Generic.Dictionary`2<Unco.SettingsSyste.Core.HapticCategory, System.Single>::set_Item(this._lastPlayTime, category, v69);\n\tgoto L_0062;\nL_0062:\n\tLofelt.NiceVibrations.HapticPatterns::PlayPreset(type);\nL_006C:\n\treturn;\nL_0020:\n\tv51 = this._settings;\n")]
		public void PlayHaptic(HapticPatterns.PresetType type, HapticCategory category = HapticCategory.Default, float cooldown = 0.2f)
		{
			SettingsManager settings = _settings;
			SettingsStorageData settingsData = settings._settingsData;
			if ((settingsData.Flags & 1) == 0 || !_isPlatformSupported)
			{
				return;
			}
			float unscaledTime = Time.unscaledTime;
			if (_lastPlayTime.TryGetValue(category, out var value))
			{
				float num = unscaledTime - value;
				if (num < cooldown)
				{
					return;
				}
			}
			_lastPlayTime[category] = unscaledTime;
			HapticPatterns.PlayPreset(type);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x7AF2564", Offset = "0x7AF2564", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.SettingsSyste.Core.HapticManager::PlayHaptic(this, type, 0, this.HapticDelay);\n\treturn;\n")]
		public void PlayHapticType(HapticPatterns.PresetType type)
		{
			PlayHaptic(type, default(HapticCategory), HapticDelay);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x7AF2570", Offset = "0x7AF2570", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = v49._settingsData;\n\tv57 = v51.Flags & 1;\n\tv58 = v57 == 0;\n\tif (v58) goto L_004F;\n\tv69 = this._isPlatformSupported != 1;\n\tif (v69) goto L_004F;\n\tgoto L_0044;\nL_0044:\n\tLofelt.NiceVibrations.HapticPatterns::PlayConstant(amplitude, frequency, duration);\n\treturn;\nL_004F:\n\treturn;\nL_0019:\n\tv49 = this._settings;\n")]
		public void PlayConstant(float amplitude, float frequency, float duration)
		{
			SettingsManager settings = _settings;
			SettingsStorageData settingsData = settings._settingsData;
			if ((settingsData.Flags & 1) != 0 && _isPlatformSupported)
			{
				HapticPatterns.PlayConstant(amplitude, frequency, duration);
			}
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x7AF262C", Offset = "0x7AF262C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0017;\nL_0017:\n\tLofelt.NiceVibrations.HapticController::Stop();\n\treturn;\n")]
		private void StopHaptic()
		{
			HapticController.Stop();
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x7AF269C", Offset = "0x7AF269C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settings;\n\tv9 = v6._settingsData;\n\tv30 = v9.Flags & 1;\n\tv31 = v30 == 0;\n\tv32 = ~v31;\n\tif (v32) goto L_001A;\n\treturn 0;\nL_001A:\n\treturn this._isPlatformSupported;\n")]
		private bool CanPlayHaptic()
		{
			SettingsManager settings = _settings;
			SettingsStorageData settingsData = settings._settingsData;
			if ((settingsData.Flags & 1) == 0)
			{
				return false;
			}
			return _isPlatformSupported;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x7AF26E0", Offset = "0x7AF26E0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.SettingsSyste.Core.HapticManager::PlayHaptic(this, 0, 0, 0f);\n\treturn;\n")]
		public void PlaySelection()
		{
			PlayHaptic(default(HapticPatterns.PresetType), default(HapticCategory), 0f);
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x7AF26F0", Offset = "0x7AF26F0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis._isEnabled = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001D:\n\tthis.HapticDelay = 0.2f;\n\tv50 = new System.Collections.Generic.Dictionary`2<Unco.SettingsSyste.Core.HapticCategory, System.Single>();\n\tSystem.Collections.Generic.Dictionary`2<Unco.SettingsSyste.Core.HapticCategory, System.Single>::.ctor(v50);\n\tthis._lastPlayTime = v50;\n")]
		public HapticManager()
		{
			HapticDelay = 0.2f;
			Dictionary<HapticCategory, float> lastPlayTime = new Dictionary<HapticCategory, float>();
			_lastPlayTime = lastPlayTime;
			IsEnabled = true;
		}
	}
}

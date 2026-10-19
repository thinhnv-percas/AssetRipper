using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;
using Unity.Notifications.iOS;
using UnityEngine;

namespace Unco.SettingsSystem.Core
{
	[Token(Token = "0x2000005")]
	public class SettingsManager
	{
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x10")]
		internal SettingsStorageData _settingsData;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x18")]
		public Action<int> OnSoundChanged;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x20")]
		public Action<int> OnMusicChanged;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x28")]
		public Action<int> OnNotificationChanged;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x30")]
		public Action<bool> OnNotificationPermissionChanged;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x38")]
		internal SettingsRemoteConfig _settingsRemoteConfig;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x40")]
		private bool _lastKnownNotificationPermission;

		[Token(Token = "0x17000001")]
		private int Settings
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x7AF1774", Offset = "0x7AF1774", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsData;\n\treturn v0.Flags;\n")]
			get
			{
				SettingsStorageData settingsData = _settingsData;
				return settingsData.Flags;
			}
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x7AF1790", Offset = "0x7AF1790", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsData;\n\tv0.Flags = value;\n\treturn;\n")]
			set
			{
				SettingsStorageData settingsData = _settingsData;
				settingsData.Flags = value;
			}
		}

		[Token(Token = "0x17000002")]
		public bool IsNotificationPermissionGranted
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x7AF1C7C", Offset = "0x7AF1C7C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001B:\n\tv48 = Unity.Notifications.iOS.iOSNotificationCenter::GetNotificationSettings();\n\tv61 = v48.authorizationStatus - 2;\n\tv63 = v61 == 0;\n\treturn v63;\nL_0017:\n\tgoto L_001B;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettingsManager::get_IsNotificationPermissionGranted");
				return default;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6000005")]
		[Address(RVA = "0x7AF17AC", Offset = "0x7AF17AC", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv54 = Unco.RemoteManagementSystem.RemoteConfigManager::GetJson(remoteConfigManager, 9);\n\tthis._settingsRemoteConfig = v54;\n\tv63 = this._settingsData;\n\tv166 = v63.Flags;\n\tv132 = v63.Flags & 0x40;\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_003B;\n\tv135 = v63.Flags == 0;\n\tif (v135) goto L_003C;\nL_0032:\n\tv150 = v166 | 0x40;\n\tv63.Flags = v150;\nL_003C:\n\tv171 = this._settingsRemoteConfig;\n\tv170 = this._settingsRemoteConfig == 0;\n\tif (v170) goto L_FFFFFFFF;\n\tv183 = v171.Haptic != 1;\n\tif (v183) goto L_FFFFFFFF;\n\tv165 = 0x10 + 1;\n\tgoto L_0051;\nL_FFFFFFFF:\n\tv165 = 0x10;\nL_FFFFFFFF:\n\tv165 = v187;\n\tgoto L_0063;\nL_FFFFFFFF:\n\tv166 = v154;\n\tgoto L_007C;\nL_FFFFFFFF:\n\tv166 = v165;\n\tv166 = v166 | 0x20;\n\tgoto L_0032;\nL_FFFFFFFF:\n\tv166 = 0x37;\n\tgoto L_0032;\nL_0018:\n\tthis._settingsData = settingsData;\nL_003B:\n\treturn;\nL_0051:\n\tv187 = v165 | 2;\n\tv198 = v171.Sound != 1;\n\tif (v198) goto L_0063;\nL_0063:\n\tv154 = v165 | 4;\n\tv155 = v171.Music != 1;\n\tif (v155) goto L_FFFFFFFF;\nL_007C:\n\tv152 = v171.Notification != 1;\n\tif (v152) goto L_0032;\n")]
		private void Inject(RemoteConfigManager remoteConfigManager, SettingsStorageData settingsData)
		{
			_settingsData = settingsData;
			SettingsRemoteConfig json = remoteConfigManager.GetJson<SettingsRemoteConfig>(RemoteKey.settings_config);
			_settingsRemoteConfig = json;
			SettingsStorageData settingsData2 = _settingsData;
			int num = settingsData2.Flags;
			if ((settingsData2.Flags & 0x40) != 0)
			{
				return;
			}
			if (settingsData2.Flags == 0)
			{
				SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
				if (_settingsRemoteConfig == null)
				{
					num = 55;
				}
				else
				{
					int num2 = ((settingsRemoteConfig.Haptic != 1) ? 16 : (16 + 1));
					int num3 = num2 | 2;
					if (settingsRemoteConfig.Sound == 1)
					{
						num2 = num3;
					}
					int num4 = num2 | 4;
					num = ((settingsRemoteConfig.Music != 1) ? num2 : num4);
					if (settingsRemoteConfig.Notification == 1)
					{
						num |= 0x20;
					}
				}
			}
			int flags = num | 0x40;
			settingsData2.Flags = flags;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x7AF18EC", Offset = "0x7AF18EC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.OnSoundChanged == 0;\n\tif (v13) goto L_0014;\n\tv14 = this._settingsData;\n\tv31 = v14.Flags >> 1;\n\tv22 = v31 & 1;\n\tSystem.Action`1<System.Int32>::Invoke(this.OnSoundChanged, v22);\n\tv50 = this._settingsData;\n\tv60 = v50.Flags >> 2;\n\tv61 = v60 & 1;\n\tSystem.Action`1<System.Int32>::Invoke(this.OnMusicChanged, v61);\n\treturn;\nL_002B:\n\treturn;\nL_0014:\n\t;\n\tv29 = this.OnMusicChanged == 0;\n\tif (v29) goto L_002B;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InitializeValue()
		{
			if (OnSoundChanged != null)
			{
				SettingsStorageData settingsData = _settingsData;
				int num = settingsData.Flags >> 1;
				int obj = num & 1;
				OnSoundChanged(obj);
			}
			if (OnMusicChanged != null)
			{
				SettingsStorageData settingsData2 = _settingsData;
				int num2 = settingsData2.Flags >> 2;
				int obj2 = num2 & 1;
				OnMusicChanged(obj2);
			}
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x7AF1988", Offset = "0x7AF1988", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsRemoteConfig;\n\tv2 = this._settingsRemoteConfig == 0;\n\tif (v2) goto L_0029;\n\tv16 = flag > 3;\n\tif (v16) goto L_002E;\n\tv22 = flag == 1;\n\tif (v22) goto L_0041;\n\tv39 = flag != 2;\n\treturnVal4 = 1;\n\tif (v39) goto L_0042;\n\treturn v0.Sound;\nL_0029:\n\treturn 1;\nL_002E:\n\tv31 = flag == 4;\n\tif (v31) goto L_0044;\n\tv41 = flag != 0x20;\n\treturnVal4 = 1;\n\tif (v41) goto L_0042;\n\treturn v0.Notification;\nL_0041:\n\treturnVal4 = v0.Haptic;\nL_0044:\n\treturn v0.Music;\nL_0042:\n\treturn returnVal4;\n")]
		private int GetRemoteConfigValue(SettingsFlags flag)
		{
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig != null)
			{
				int result;
				if (flag <= (SettingsFlags.Haptic | SettingsFlags.Sound))
				{
					if (flag != SettingsFlags.Haptic)
					{
						bool flag2 = flag != SettingsFlags.Sound;
						result = 1;
						if (!flag2)
						{
							return settingsRemoteConfig.Sound;
						}
					}
					else
					{
						result = settingsRemoteConfig.Haptic;
					}
				}
				else
				{
					if (flag == SettingsFlags.Music)
					{
						return settingsRemoteConfig.Music;
					}
					bool flag3 = flag != SettingsFlags.Notification;
					result = 1;
					if (!flag3)
					{
						return settingsRemoteConfig.Notification;
					}
				}
				return result;
			}
			return 1;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x7AF19E4", Offset = "0x7AF19E4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsRemoteConfig;\n\tv2 = this._settingsRemoteConfig == 0;\n\tif (v2) goto L_0036;\n\tv16 = flag > 3;\n\tif (v16) goto L_0044;\n\tv33 = flag == 1;\n\tif (v33) goto L_0065;\n\tv117 = flag != 2;\n\tv99 = 1;\n\tif (v117) goto L_0029;\n\tv99 = v0.Sound;\nL_0036:\n\tv20 = 1 - -1;\n\tv22 = v20 == 0;\n\treturn v22;\nL_0044:\n\tv42 = flag == 4;\n\tif (v42) goto L_0072;\n\tv57 = flag != 0x20;\n\tv99 = 1;\n\tif (v57) goto L_0029;\n\tv90 = v0.Notification - -1;\n\tv80 = v90 == 0;\n\treturn v80;\nL_0065:\n\tv91 = v0.Haptic - -1;\n\tv81 = v91 == 0;\n\treturn v81;\nL_0072:\n\tv92 = v0.Music - -1;\n\tv82 = v92 == 0;\n\treturn v82;\nL_0029:\n\tv89 = v99 - -1;\n\tv79 = v89 == 0;\n\treturn v79;\n")]
		public bool IsSettingDisabled(SettingsFlags flag)
		{
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig != null)
			{
				int num2;
				if (flag <= (SettingsFlags.Haptic | SettingsFlags.Sound))
				{
					if (flag == SettingsFlags.Haptic)
					{
						int num = settingsRemoteConfig.Haptic - -1;
						return num == 0;
					}
					bool flag2 = flag != SettingsFlags.Sound;
					num2 = 1;
					if (!flag2)
					{
						num2 = settingsRemoteConfig.Sound;
					}
				}
				else
				{
					if (flag == SettingsFlags.Music)
					{
						int num3 = settingsRemoteConfig.Music - -1;
						return num3 == 0;
					}
					bool flag3 = flag != SettingsFlags.Notification;
					num2 = 1;
					if (!flag3)
					{
						int num4 = settingsRemoteConfig.Notification - -1;
						return num4 == 0;
					}
				}
				int num5 = num2 - -1;
				return num5 == 0;
			}
			int num6 = 1 - -1;
			return num6 == 0;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x7AF18A0", Offset = "0x7AF18A0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsRemoteConfig;\n\tv2 = this._settingsRemoteConfig == 0;\n\tif (v2) goto L_0045;\n\tv15 = v0.Haptic != 1;\n\tif (v15) goto L_FFFFFFFF;\n\tv60 = 0x10 + 1;\n\tgoto L_0015;\nL_FFFFFFFF:\n\tv60 = 0x10;\nL_FFFFFFFF:\n\tv60 = v65;\n\tgoto L_0027;\nL_FFFFFFFF:\n\treturnVal2 = v26;\n\tgoto L_0040;\nL_FFFFFFFF:\n\treturnVal2 = v60;\n\treturnVal2 = returnVal2 | 0x20;\nL_0045:\n\treturn 0x37;\nL_0015:\n\tv65 = v60 | 2;\n\tv75 = v0.Sound != 1;\n\tif (v75) goto L_0027;\nL_0027:\n\tv26 = v60 | 4;\n\tv31 = v0.Music != 1;\n\tif (v31) goto L_FFFFFFFF;\nL_0040:\n\tv20 = v0.Notification != 1;\n\tif (v20) goto L_0043;\nL_0043:\n\treturn returnVal2;\n")]
		private int GetDefaultFlags()
		{
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig == null)
			{
				return 55;
			}
			int num = ((settingsRemoteConfig.Haptic != 1) ? 16 : (16 + 1));
			int num2 = num | 2;
			if (settingsRemoteConfig.Sound == 1)
			{
				num = num2;
			}
			int num3 = num | 4;
			int num4 = ((settingsRemoteConfig.Music != 1) ? num : num3);
			if (settingsRemoteConfig.Notification == 1)
			{
				num4 |= 0x20;
			}
			return num4;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x7AF1A68", Offset = "0x7AF1A68", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settingsData;\n\tv8 = state == 0;\n\tif (v8) goto L_0013;\n\tv13 = v6.Flags | flag;\n\tv6.Flags = v13;\n\treturn;\nL_0013:\n\tv33 = ~flag;\n\tv34 = v6.Flags & v33;\n\tv6.Flags = v34;\n\treturn;\n")]
		public void SetFlag(SettingsFlags flag, int state)
		{
			SettingsStorageData settingsData = _settingsData;
			if (state != 0)
			{
				int flags = settingsData.Flags | (int)flag;
				settingsData.Flags = flags;
			}
			else
			{
				int num = (int)(~flag);
				int flags2 = settingsData.Flags & num;
				settingsData.Flags = flags2;
			}
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x7AF1964", Offset = "0x7AF1964", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsData;\n\tv4 = v0.Flags & flag;\n\tv7 = v4 == 0;\n\tv10 = ~v7;\n\treturn v10;\n")]
		public int GetFlagValue(SettingsFlags flag)
		{
			SettingsStorageData settingsData = _settingsData;
			int num = settingsData.Flags & (int)flag;
			bool flag2 = num == 0;
			return (!flag2) ? 1 : 0;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x7AF1AAC", Offset = "0x7AF1AAC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsData;\n\tv4 = v0.Flags & flag;\n\tv7 = v4 == 0;\n\tv10 = ~v7;\n\treturn v10;\n")]
		public bool IsEnabled(SettingsFlags flag)
		{
			SettingsStorageData settingsData = _settingsData;
			int num = settingsData.Flags & (int)flag;
			bool flag2 = num == 0;
			return !flag2;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x7AF1AD0", Offset = "0x7AF1AD0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settingsRemoteConfig;\n\tv8 = this._settingsRemoteConfig == 0;\n\tif (v8) goto L_0013;\n\tv14 = v6.Sound == -1;\n\tif (v14) goto L_0031;\nL_0013:\n\tv38 = this._settingsData;\n\tv39 = state == 0;\n\tif (v39) goto L_0028;\n\tv44 = v38.Flags | 2;\n\tv38.Flags = v44;\n\tv88 = this.OnSoundChanged;\n\tv55 = this.OnSoundChanged == 0;\n\tif (v55) goto L_0031;\nL_0024:\n\tSystem.Action`1<System.Int32>::Invoke(v88, state);\nL_0024:\n\treturn;\nL_0028:\n\tv42 = v38.Flags & -3;\n\tv38.Flags = v42;\n\tv88 = this.OnSoundChanged;\n\tv105 = this.OnSoundChanged == 0;\n\tv54 = ~v105;\n\tif (v54) goto L_0024;\nL_0031:\n\treturn;\n")]
		public void SetSound(int state)
		{
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig != null && settingsRemoteConfig.Sound == -1)
			{
				return;
			}
			SettingsStorageData settingsData = _settingsData;
			Action<int> onSoundChanged;
			if (state != 0)
			{
				int flags = settingsData.Flags | 2;
				settingsData.Flags = flags;
				onSoundChanged = OnSoundChanged;
				if (OnSoundChanged == null)
				{
					return;
				}
			}
			else
			{
				int flags2 = settingsData.Flags & -3;
				settingsData.Flags = flags2;
				onSoundChanged = OnSoundChanged;
				if (OnSoundChanged == null)
				{
					return;
				}
			}
			onSoundChanged(state);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x7AF1B44", Offset = "0x7AF1B44", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settingsRemoteConfig;\n\tv8 = this._settingsRemoteConfig == 0;\n\tif (v8) goto L_0013;\n\tv14 = v6.Music == -1;\n\tif (v14) goto L_0031;\nL_0013:\n\tv38 = this._settingsData;\n\tv39 = state == 0;\n\tif (v39) goto L_0028;\n\tv44 = v38.Flags | 4;\n\tv38.Flags = v44;\n\tv88 = this.OnMusicChanged;\n\tv55 = this.OnMusicChanged == 0;\n\tif (v55) goto L_0031;\nL_0024:\n\tSystem.Action`1<System.Int32>::Invoke(v88, state);\nL_0024:\n\treturn;\nL_0028:\n\tv42 = v38.Flags & -5;\n\tv38.Flags = v42;\n\tv88 = this.OnMusicChanged;\n\tv105 = this.OnMusicChanged == 0;\n\tv54 = ~v105;\n\tif (v54) goto L_0024;\nL_0031:\n\treturn;\n")]
		public void SetMusic(int state)
		{
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig != null && settingsRemoteConfig.Music == -1)
			{
				return;
			}
			SettingsStorageData settingsData = _settingsData;
			Action<int> onMusicChanged;
			if (state != 0)
			{
				int flags = settingsData.Flags | 4;
				settingsData.Flags = flags;
				onMusicChanged = OnMusicChanged;
				if (OnMusicChanged == null)
				{
					return;
				}
			}
			else
			{
				int flags2 = settingsData.Flags & -5;
				settingsData.Flags = flags2;
				onMusicChanged = OnMusicChanged;
				if (OnMusicChanged == null)
				{
					return;
				}
			}
			onMusicChanged(state);
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x7AF1BB8", Offset = "0x7AF1BB8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settingsRemoteConfig;\n\tv8 = this._settingsRemoteConfig == 0;\n\tif (v8) goto L_0013;\n\tv14 = v6.Haptic == -1;\n\tif (v14) goto L_0023;\nL_0013:\n\tv38 = this._settingsData;\n\tv39 = state == 0;\n\tif (v39) goto L_001E;\n\tv42 = v38.Flags | 1;\n\tgoto L_001F;\nL_001E:\n\tv42 = v38.Flags & -2;\nL_0023:\n\treturn;\nL_001F:\n\tv38.Flags = v42;\n")]
		public void SetHaptic(int state)
		{
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig == null || settingsRemoteConfig.Haptic != -1)
			{
				SettingsStorageData settingsData = _settingsData;
				int flags = ((state == 0) ? (settingsData.Flags & -2) : (settingsData.Flags | 1));
				settingsData.Flags = flags;
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x7AF1C08", Offset = "0x7AF1C08", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settingsRemoteConfig;\n\tv8 = this._settingsRemoteConfig == 0;\n\tif (v8) goto L_0013;\n\tv14 = v6.Notification == -1;\n\tif (v14) goto L_0031;\nL_0013:\n\tv38 = this._settingsData;\n\tv39 = state == 0;\n\tif (v39) goto L_0028;\n\tv44 = v38.Flags | 0x20;\n\tv38.Flags = v44;\n\tv88 = this.OnNotificationChanged;\n\tv55 = this.OnNotificationChanged == 0;\n\tif (v55) goto L_0031;\nL_0024:\n\tSystem.Action`1<System.Int32>::Invoke(v88, state);\nL_0024:\n\treturn;\nL_0028:\n\tv42 = v38.Flags & 0xFFFFFFFFFFFFFFDF;\n\tv38.Flags = v42;\n\tv88 = this.OnNotificationChanged;\n\tv105 = this.OnNotificationChanged == 0;\n\tv54 = ~v105;\n\tif (v54) goto L_0024;\nL_0031:\n\treturn;\n")]
		public void SetNotification(int state)
		{
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig != null && settingsRemoteConfig.Notification == -1)
			{
				return;
			}
			SettingsStorageData settingsData = _settingsData;
			Action<int> onNotificationChanged;
			if (state != 0)
			{
				int flags = settingsData.Flags | 0x20;
				settingsData.Flags = flags;
				onNotificationChanged = OnNotificationChanged;
				if (OnNotificationChanged == null)
				{
					return;
				}
			}
			else
			{
				int flags2 = settingsData.Flags & -33;
				settingsData.Flags = flags2;
				onNotificationChanged = OnNotificationChanged;
				if (OnNotificationChanged == null)
				{
					return;
				}
			}
			onNotificationChanged(state);
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x7AF1CEC", Offset = "0x7AF1CEC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB307000 + 0x968;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Application::OpenURL(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		public void OpenNotificationSettings()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettingsManager::OpenNotificationSettings");
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x7AF1D80", Offset = "0x7AF1D80", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001E:\n\tv53 = Unity.Notifications.iOS.iOSNotificationCenter::GetNotificationSettings();\n\tv66 = v53.authorizationStatus - 2;\n\tv68 = v66 == 0;\n\tv79 = this._lastKnownNotificationPermission == v68;\n\tif (v79) goto L_0081;\n\tthis._lastKnownNotificationPermission = v68;\n\tv88 = v53.authorizationStatus == 2;\n\tif (v88) goto L_0069;\n\tv142 = this._settingsData;\n\tv196 = v142.Flags & 0x20;\n\tv170 = v196 == 0;\n\tif (v170) goto L_0069;\n\tv199 = this._settingsRemoteConfig;\n\tv200 = this._settingsRemoteConfig == 0;\n\tif (v200) goto L_005F;\n\tv160 = v199.Notification == -1;\n\tif (v160) goto L_0069;\nL_005F:\n\tv150 = v142.Flags & 0xFFFFFFFFFFFFFFDF;\n\tv142.Flags = v150;\n\tv169 = this.OnNotificationChanged == 0;\n\tif (v169) goto L_0069;\n\tSystem.Action`1<System.Int32>::Invoke(this.OnNotificationChanged, 0);\n\tv124 = v53.authorizationStatus - 2;\n\tv118 = v124 == 0;\n\tSystem.Action`1<System.Boolean>::Invoke(this.OnNotificationPermissionChanged, v118);\nL_001A:\n\tgoto L_001E;\nL_0081:\n\treturn;\nL_0069:\n\t;\n\tv133 = this.OnNotificationPermissionChanged == 0;\n\tif (v133) goto L_0081;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RefreshNotificationPermission()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettingsManager::RefreshNotificationPermission");
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x7AF1EDC", Offset = "0x7AF1EDC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001E:\n\tv53 = Unity.Notifications.iOS.iOSNotificationCenter::GetNotificationSettings();\n\tv68 = v53.authorizationStatus == 2;\n\tthis._lastKnownNotificationPermission = v68;\n\tif (v68) goto L_005C;\n\tv74 = this._settingsData;\n\tv127 = v74.Flags & 0x20;\n\tv117 = v127 == 0;\n\tif (v117) goto L_005C;\n\tv150 = this._settingsRemoteConfig;\n\tv151 = this._settingsRemoteConfig == 0;\n\tif (v151) goto L_004B;\n\tv103 = v150.Notification == -1;\n\tif (v103) goto L_005C;\nL_004B:\n\tv88 = v74.Flags & 0xFFFFFFFFFFFFFFDF;\n\tv74.Flags = v88;\n\tv116 = this.OnNotificationChanged == 0;\n\tif (v116) goto L_005C;\n\tSystem.Action`1<System.Int32>::Invoke(this.OnNotificationChanged, 0);\nL_001A:\n\tgoto L_001E;\nL_005C:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InitializeNotificationPermission()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettingsManager::InitializeNotificationPermission");
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x7AF1E80", Offset = "0x7AF1E80", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = osPermission == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_0024;\n\tv4 = this._settingsData;\n\tv54 = v4.Flags & 0x20;\n\tv51 = v54 == 0;\n\tif (v51) goto L_0024;\n\tv100 = this._settingsRemoteConfig;\n\tv101 = this._settingsRemoteConfig == 0;\n\tif (v101) goto L_001A;\n\tv25 = v100.Notification == -1;\n\tif (v25) goto L_0024;\nL_001A:\n\tv46 = v4.Flags & 0xFFFFFFFFFFFFFFDF;\n\tv4.Flags = v46;\n\tv53 = this.OnNotificationChanged == 0;\n\tif (v53) goto L_0024;\n\tSystem.Action`1<System.Int32>::Invoke(this.OnNotificationChanged, 0);\n\treturn;\nL_0024:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SyncNotificationPref(bool osPermission)
		{
			if (osPermission)
			{
				return;
			}
			SettingsStorageData settingsData = _settingsData;
			if ((settingsData.Flags & 0x20) == 0)
			{
				return;
			}
			SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
			if (_settingsRemoteConfig == null || settingsRemoteConfig.Notification != -1)
			{
				int flags = settingsData.Flags & -33;
				settingsData.Flags = flags;
				if (OnNotificationChanged != null)
				{
					OnNotificationChanged(0);
				}
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x7AF1FAC", Offset = "0x7AF1FAC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsData;\n\tv4 = v0.Flags & 0xFFFFFFFFFFFFFFE7;\n\tv5 = v4 | level;\n\tv0.Flags = v5;\n\treturn;\n")]
		public void SetQuality(int level)
		{
			SettingsStorageData settingsData = _settingsData;
			int num = settingsData.Flags & -25;
			int flags = num | level;
			settingsData.Flags = flags;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x7AF1FD4", Offset = "0x7AF1FD4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._settingsData;\n\tv4 = v0.Flags >> 3;\n\treturnVal1 = v4 & 3;\n\treturn returnVal1;\n")]
		public int GetQuality()
		{
			SettingsStorageData settingsData = _settingsData;
			int num = settingsData.Flags >> 3;
			return num & 3;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x7AF1FF4", Offset = "0x7AF1FF4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._settingsData;\n\tv18 = flag != 0x18;\n\tif (v18) goto L_001C;\n\tv22 = v6.Flags >> 3;\n\treturnVal1 = v22 & 3;\n\treturn returnVal1;\nL_001C:\n\tv43 = v6.Flags & flag;\n\tv45 = v43 == 0;\n\tv48 = ~v45;\n\treturn v48;\n")]
		public int GetState(SettingsFlags flag)
		{
			SettingsStorageData settingsData = _settingsData;
			if (flag == SettingsFlags.QualityMask)
			{
				int num = settingsData.Flags >> 3;
				return num & 3;
			}
			int num2 = settingsData.Flags & (int)flag;
			bool flag2 = num2 == 0;
			return (!flag2) ? 1 : 0;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x7AF2038", Offset = "0x7AF2038", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = flag <= 3;\n\tif (v18) goto L_0053;\n\tv23 = flag == 4;\n\tif (v23) goto L_0080;\n\tv41 = flag == 0x18;\n\tif (v41) goto L_009C;\n\tv70 = flag != 0x20;\n\tif (v70) goto L_00C2;\n\tv133 = this._settingsRemoteConfig;\n\tv134 = this._settingsRemoteConfig == 0;\n\tif (v134) goto L_003F;\n\tv233 = v133.Notification == -1;\n\tif (v233) goto L_004E;\nL_003F:\n\tv152 = this._settingsData;\n\tv253 = value == 0;\n\tif (v253) goto L_00EE;\n\tv194 = v152.Flags | 0x20;\n\tv152.Flags = v194;\n\tv311 = this.OnNotificationChanged;\n\tv316 = this.OnNotificationChanged == 0;\n\tv202 = ~v316;\n\tif (v202) goto L_0105;\nL_004E:\n\treturn;\nL_0053:\n\tv32 = flag == 1;\n\tif (v32) goto L_00A7;\n\tv58 = flag != 2;\n\tif (v58) goto L_00C2;\n\tv97 = this._settingsRemoteConfig;\n\tv98 = this._settingsRemoteConfig == 0;\n\tif (v98) goto L_0073;\n\tv234 = v97.Sound == -1;\n\tif (v234) goto L_004E;\nL_0073:\n\tv153 = this._settingsData;\n\tv249 = value == 0;\n\tif (v249) goto L_00F8;\n\tv196 = v153.Flags | 2;\n\tv153.Flags = v196;\n\tv311 = this.OnSoundChanged;\n\tv313 = this.OnSoundChanged == 0;\n\tv205 = ~v313;\n\tif (v205) goto L_0105;\n\tgoto L_004E;\nL_0080:\n\tv46 = this._settingsRemoteConfig;\n\tv48 = this._settingsRemoteConfig == 0;\n\tif (v48) goto L_008F;\n\tv78 = v46.Music == -1;\n\tif (v78) goto L_004E;\nL_008F:\n\tv94 = this._settingsData;\n\tv95 = value == 0;\n\tif (v95) goto L_00DB;\n\tv197 = v94.Flags | 4;\n\tv94.Flags = v197;\n\tv311 = this.OnMusicChanged;\n\tv304 = this.OnMusicChanged == 0;\n\tv206 = ~v304;\n\tif (v206) goto L_0105;\n\tgoto L_004E;\nL_009C:\n\tv71 = this._settingsData;\n\tv136 = v71.Flags & 0xFFFFFFFFFFFFFFE7;\n\tv137 = v136 | value;\n\tv71.Flags = v137;\n\treturn;\nL_00A7:\n\tv59 = this._settingsRemoteConfig;\n\tv60 = this._settingsRemoteConfig == 0;\n\tif (v60) goto L_00B6;\n\tv115 = v59.Haptic == -1;\n\tif (v115) goto L_004E;\nL_00B6:\n\tv131 = this._settingsData;\n\tv132 = value == 0;\n\tif (v132) goto L_00E5;\n\tv269 = v131.Flags | 1;\n\tv131.Flags = v269;\n\treturn;\nL_00C2:\n\tv108 = this._settingsData;\n\tv109 = value == 0;\n\tif (v109) goto L_00D1;\n\tv270 = v108.Flags | flag;\n\tv108.Flags = v270;\n\treturn;\nL_00D1:\n\tv275 = ~flag;\n\tv271 = v108.Flags & v275;\n\tv108.Flags = v271;\n\treturn;\nL_00DB:\n\tv198 = v94.Flags & -5;\n\tv94.Flags = v198;\n\tv311 = this.OnMusicChanged;\n\tv306 = this.OnMusicChanged == 0;\n\tv207 = ~v306;\n\tif (v207) goto L_0105;\n\tgoto L_004E;\nL_00E5:\n\tv272 = v131.Flags & -2;\n\tv131.Flags = v272;\n\treturn;\nL_00EE:\n\tv199 = v152.Flags & 0xFFFFFFFFFFFFFFDF;\n\tv152.Flags = v199;\n\tv311 = this.OnNotificationChanged;\n\tv318 = this.OnNotificationChanged == 0;\n\tv208 = ~v318;\n\tif (v208) goto L_0105;\n\tgoto L_004E;\nL_00F8:\n\tv200 = v153.Flags & -3;\n\tv153.Flags = v200;\n\tv311 = this.OnSoundChanged;\n\tv209 = this.OnSoundChanged == 0;\n\tif (v209) goto L_004E;\nL_0105:\n\tSystem.Action`1<System.Int32>::Invoke(v311, value);\nL_0105:\n\treturn;\n")]
		public void SetState(SettingsFlags flag, int value)
		{
			Action<int> action;
			switch (flag)
			{
			case SettingsFlags.Notification:
			{
				SettingsRemoteConfig settingsRemoteConfig = _settingsRemoteConfig;
				if (_settingsRemoteConfig != null && settingsRemoteConfig.Notification == -1)
				{
					return;
				}
				SettingsStorageData settingsData2 = _settingsData;
				if (value != 0)
				{
					int flags3 = settingsData2.Flags | 0x20;
					settingsData2.Flags = flags3;
					action = OnNotificationChanged;
					if (OnNotificationChanged == null)
					{
						return;
					}
				}
				else
				{
					int flags4 = settingsData2.Flags & -33;
					settingsData2.Flags = flags4;
					action = OnNotificationChanged;
					if (OnNotificationChanged == null)
					{
						return;
					}
				}
				break;
			}
			case SettingsFlags.Sound:
			{
				SettingsRemoteConfig settingsRemoteConfig2 = _settingsRemoteConfig;
				if (_settingsRemoteConfig != null && settingsRemoteConfig2.Sound == -1)
				{
					return;
				}
				SettingsStorageData settingsData3 = _settingsData;
				if (value != 0)
				{
					int flags5 = settingsData3.Flags | 2;
					settingsData3.Flags = flags5;
					action = OnSoundChanged;
					if (OnSoundChanged == null)
					{
						return;
					}
				}
				else
				{
					int flags6 = settingsData3.Flags & -3;
					settingsData3.Flags = flags6;
					action = OnSoundChanged;
					if (OnSoundChanged == null)
					{
						return;
					}
				}
				break;
			}
			case SettingsFlags.Music:
			{
				SettingsRemoteConfig settingsRemoteConfig4 = _settingsRemoteConfig;
				if (_settingsRemoteConfig != null && settingsRemoteConfig4.Music == -1)
				{
					return;
				}
				SettingsStorageData settingsData5 = _settingsData;
				if (value != 0)
				{
					int flags9 = settingsData5.Flags | 4;
					settingsData5.Flags = flags9;
					action = OnMusicChanged;
					if (OnMusicChanged == null)
					{
						return;
					}
				}
				else
				{
					int flags10 = settingsData5.Flags & -5;
					settingsData5.Flags = flags10;
					action = OnMusicChanged;
					if (OnMusicChanged == null)
					{
						return;
					}
				}
				break;
			}
			case SettingsFlags.QualityMask:
			{
				SettingsStorageData settingsData6 = _settingsData;
				int num2 = settingsData6.Flags & -25;
				int flags11 = num2 | value;
				settingsData6.Flags = flags11;
				return;
			}
			case SettingsFlags.Haptic:
			{
				SettingsRemoteConfig settingsRemoteConfig3 = _settingsRemoteConfig;
				if (_settingsRemoteConfig == null || settingsRemoteConfig3.Haptic != -1)
				{
					SettingsStorageData settingsData4 = _settingsData;
					if (value != 0)
					{
						int flags7 = settingsData4.Flags | 1;
						settingsData4.Flags = flags7;
					}
					else
					{
						int flags8 = settingsData4.Flags & -2;
						settingsData4.Flags = flags8;
					}
				}
				return;
			}
			default:
			{
				SettingsStorageData settingsData = _settingsData;
				if (value != 0)
				{
					int flags = settingsData.Flags | (int)flag;
					settingsData.Flags = flags;
				}
				else
				{
					int num = (int)(~flag);
					int flags2 = settingsData.Flags & num;
					settingsData.Flags = flags2;
				}
				return;
			}
			}
			action(value);
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x7AF2230", Offset = "0x7AF2230", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SettingsManager()
		{
		}
	}
}

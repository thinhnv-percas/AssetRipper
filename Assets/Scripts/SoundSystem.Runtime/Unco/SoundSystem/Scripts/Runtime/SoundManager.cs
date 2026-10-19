using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.Extensions;
using Unco.RemoteManagementSystem;
using Unco.SettingsSystem.Core;
using Unco.SoundSystem.Scripts.Runtime.Data;
using Unco.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Unco.SoundSystem.Scripts.Runtime
{
	[Token(Token = "0x2000004")]
	public class SoundManager : MonoBehaviour, IDisposable
	{
		[Token(Token = "0x2000005")]
		public enum AudioType
		{
			[Token(Token = "0x4000011")]
			None = 0,
			[Token(Token = "0x4000012")]
			CardReveal = 1,
			[Token(Token = "0x4000013")]
			CardMerge = 2,
			[Token(Token = "0x4000014")]
			CardClick = 4,
			[Token(Token = "0x4000015")]
			CardDropFail = 5,
			[Token(Token = "0x4000016")]
			Swing1 = 6,
			[Token(Token = "0x4000017")]
			Swing2 = 7,
			[Token(Token = "0x4000018")]
			Swing3 = 8,
			[Token(Token = "0x4000019")]
			Swing4 = 9,
			[Token(Token = "0x400001A")]
			Swing5 = 10,
			[Token(Token = "0x400001B")]
			GoldCollect = 11,
			[Token(Token = "0x400001C")]
			CardShuffle2 = 12,
			[Token(Token = "0x400001D")]
			MoveCardToEmptySlot = 27,
			[Token(Token = "0x400001E")]
			HoldCard = 61,
			[Token(Token = "0x400001F")]
			MoveCardBack = 68,
			[Token(Token = "0x4000020")]
			WrongMove = 69,
			[Token(Token = "0x4000021")]
			CardFlipper = 70,
			[Token(Token = "0x4000022")]
			Click = 79,
			[Token(Token = "0x4000023")]
			Collect = 81,
			[Token(Token = "0x4000024")]
			Merge = 82,
			[Token(Token = "0x4000025")]
			SoundBoxPour = 83,
			[Token(Token = "0x4000026")]
			SoundMoldComplete = 84,
			[Token(Token = "0x4000027")]
			SoundSandBlockPop = 85,
			[Token(Token = "0x4000028")]
			SoundSandPouring = 86,
			[Token(Token = "0x4000029")]
			SoundClosedSandBlock = 87,
			[Token(Token = "0x400002A")]
			SoundLevelWin = 88,
			[Token(Token = "0x400002B")]
			SoundLevelFail = 89,
			[Token(Token = "0x400002C")]
			BoosterHammer = 101,
			[Token(Token = "0x400002D")]
			BoosterSwap = 102,
			[Token(Token = "0x400002E")]
			BoosterVacuum = 103,
			[Token(Token = "0x400002F")]
			GarageReject = 104,
			[Token(Token = "0x4000030")]
			LockReject = 105
		}

		[CompilerGenerated]
		[Token(Token = "0x2000007")]
		private sealed class _003C_003Ec__DisplayClass29_0
		{
			[Token(Token = "0x4000035")]
			[FieldOffset(Offset = "0x10")]
			public MixerGroup mixerGroup;

			[Token(Token = "0x4000036")]
			[FieldOffset(Offset = "0x18")]
			public Func<Pair<MixerGroup, AudioMixerSnapshot>, bool> _003C_003E9__0;

			[Token(Token = "0x6000031")]
			[Address(RVA = "0x7B9BD64", Offset = "0x7B9BD64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass29_0()
			{
			}

			internal bool _003CSetMixerSnapshot_003Eb__0(Pair<MixerGroup, AudioMixerSnapshot> x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SoundManager._003C_003Ec__DisplayClass29_0::_003CSetMixerSnapshot_003Eb__0");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000B")]
		private sealed class _003C_003Ec__DisplayClass50_0
		{
			[Token(Token = "0x400003D")]
			[FieldOffset(Offset = "0x10")]
			public AudioSource audioSource;

			[Token(Token = "0x6000039")]
			[Address(RVA = "0x7B9D0B0", Offset = "0x7B9D0B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass50_0()
			{
			}

			internal bool _003CSetSoundsMuteCondition_003Eb__0(RuntimeSound music)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SoundManager._003C_003Ec__DisplayClass50_0::_003CSetSoundsMuteCondition_003Eb__0");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000D")]
		private sealed class _003C_003Ec__DisplayClass53_1
		{
			[Token(Token = "0x4000040")]
			[FieldOffset(Offset = "0x10")]
			public RuntimeSound sound;

			[Token(Token = "0x600003D")]
			[Address(RVA = "0x7B9DA64", Offset = "0x7B9DA64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass53_1()
			{
			}

			internal bool _003CUpdateVolume_003Eb__1(AudioSource source)
			{
				AudioResource resource = source.resource;
				RuntimeSound runtimeSound = sound;
				return resource == runtimeSound.AudioResource;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000F")]
		private sealed class _003C_003Ec__DisplayClass54_1
		{
			[Token(Token = "0x4000043")]
			[FieldOffset(Offset = "0x10")]
			public RuntimeSound sound;

			[Token(Token = "0x6000041")]
			[Address(RVA = "0x7B9DD4C", Offset = "0x7B9DD4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass54_1()
			{
			}

			internal bool _003CUpdatePitch_003Eb__1(AudioSource source)
			{
				AudioResource resource = source.resource;
				RuntimeSound runtimeSound = sound;
				return resource == runtimeSound.AudioResource;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private GameObject AudioSourceTemp;

		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x28")]
		private SoundListSo _soundListSo;

		[SerializeField]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x30")]
		private Pair<MixerGroup, AudioMixerSnapshot>[] m_snapshotList;

		[SerializeField]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x38")]
		private Pair<AudioLayer, AudioMixerGroup>[] m_mixerList;

		[Inject(false)]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x40")]
		private SettingsManager _settingsManager;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x48")]
		private readonly Dictionary<AudioLayer, List<AudioSource>> _audioSources;

		[Token(Token = "0x400000C")]
		private static bool OverrideActiveness;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x50")]
		private SoundProvider _soundProvider;

		[Token(Token = "0x17000001")]
		[field: Token(Token = "0x400000E")]
		[field: FieldOffset(Offset = "0x58")]
		public AudioType LastPlayedMusic
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x7B9A858", Offset = "0x7B9A858", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.LastPlayedMusic;\n")]
			get;
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x7B9A860", Offset = "0x7B9A860", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.LastPlayedMusic = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000002")]
		[field: Token(Token = "0x400000F")]
		[field: FieldOffset(Offset = "0x5C")]
		public AudioType LastPlayedSound
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x7B9A868", Offset = "0x7B9A868", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.LastPlayedSound;\n")]
			get;
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x7B9A870", Offset = "0x7B9A870", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.LastPlayedSound = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000003")]
		private bool IsMusicOn
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x7B9A878", Offset = "0x7B9A878", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Unco.SettingsSystem.Core.SettingsManager::GetState(this._settingsManager, 4);\n\tv30 = v11 - 1;\n\tv32 = v30 == 0;\n\treturn v32;\n")]
			get
			{
				int state = _settingsManager.GetState(SettingsFlags.Music);
				int num = state - 1;
				return num == 0;
			}
		}

		[Token(Token = "0x17000004")]
		private bool IsSoundOn
		{
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x7B9A8A8", Offset = "0x7B9A8A8", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Unco.SettingsSystem.Core.SettingsManager::GetState(this._settingsManager, 2);\n\tv30 = v11 - 1;\n\tv32 = v30 == 0;\n\treturn v32;\n")]
			get
			{
				int state = _settingsManager.GetState(SettingsFlags.Sound);
				int num = state - 1;
				return num == 0;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6000009")]
		[Address(RVA = "0x7B9A8D8", Offset = "0x7B9A8D8", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tthis._soundProvider = v66;\n\tv78 = this._settingsManager;\n\tv103 = this._settingsManager + 0x20;\n\tv87 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v87, this, Il2CppMethodInfo);\n\tv147 = System.Delegate::Combine(v78.OnMusicChanged, v87);\n\tv177 = v147 == 0;\n\tv143 = this;\n\tif (v177) goto L_0082;\n\tv180 = 0x21C11D0(v147, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv209 = v180 == 0;\n\tif (v209) goto L_009C;\n\tv78.OnMusicChanged = v180;\n\tv213 = 0x21C11D0(v147, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = v213 == 0;\n\tif (v216) goto L_009C;\n\tv226 = this._settingsManager;\n\tv143 = this;\nL_0060:\n\tv188 = v226 + 0x18;\n\tv229 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v229, v143, Il2CppMethodInfo);\n\tv135 = System.Delegate::Combine(v226.OnSoundChanged, v229);\n\tv137 = v135 == 0;\n\tif (v137) goto L_008B;\n\tv236 = 0x21C11D0(v135, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv237 = v236 == 0;\n\tv103 = System.Action`1<System.Int32>;\n\tif (v237) goto L_0080;\n\tv226.OnSoundChanged = v236;\n\tv158 = 0x21C11D0(v135, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv243 = v158 == 0;\n\tv160 = ~v243;\n\tv103 = System.Action`1<System.Int32>;\n\tif (v160) goto L_0099;\nL_0080:\n\tthrow System.InvalidCastException;\nL_0082:\n\t*([v103 @ X21_v9 (Il2CppClass<System.Action`1<System.Int32>>)]) = 0;\n\tv226 = *([v188 @ X20_v8 (Unco.SettingsSystem.Core.SettingsManager)]);\n\tv210 = *([v188 @ X20_v8 (Unco.SettingsSystem.Core.SettingsManager)]) == 0;\n\tv108 = ~v210;\n\tif (v108) goto L_0060;\n\tthrow System.NullReferenceException;\nL_008B:\n\t*([v188 @ X20_v8 (Unco.SettingsSystem.Core.SettingsManager)]) = 0;\nL_009C:\n\tthrow System.InvalidCastException;\nL_0026:\n\tv188 = this + 0x40;\n\tthis._settingsManager = v50;\n\tv66 = new Unco.SoundSystem.Scripts.Runtime.SoundProvider();\n\tUnco.SoundSystem.Scripts.Runtime.SoundProvider::.ctor(v66, this._soundListSo);\nL_0099:\n\treturn;\n")]
		private void Inject(SettingsManager settingsManager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::Inject");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x7B9AB78", Offset = "0x7B9AB78", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = state - 1;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::SetMusicsMuteCondition(this, v10, 1);\n\treturn;\n")]
		private void OnMusicChanged(int state)
		{
			int num = state - 1;
			bool flag = num == 0;
			bool mute = !flag;
			SetMusicsMuteCondition(mute, AudioLayer.BaseLayerMusic);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x7B9ADC0", Offset = "0x7B9ADC0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = state - 1;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::SetSoundsMuteCondition(this, v10);\n\treturn;\n")]
		private void OnSoundChanged(int state)
		{
			int num = state - 1;
			bool flag = num == 0;
			bool soundsMuteCondition = !flag;
			SetSoundsMuteCondition(soundsMuteCondition);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x7B9B1C4", Offset = "0x7B9B1C4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002A:\n\tv56 = System.Collections.Generic.Dictionary`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>::TryGetValue(this._audioSources, layer, &v54 @ stack_-38_v3 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv82 = ~v56;\n\tif (v82) goto L_003A;\n\treturn v54;\nL_003A:\n\tv68 = new System.Collections.Generic.List`1<UnityEngine.AudioSource>();\n\tSystem.Collections.Generic.List`1<UnityEngine.AudioSource>::.ctor(v68);\n\tSystem.Collections.Generic.Dictionary`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>::set_Item(this._audioSources, layer, v68);\n\treturnVal3 = System.Collections.Generic.Dictionary`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>::get_Item(this._audioSources, layer);\n\treturn returnVal3;\n")]
		private List<AudioSource> GetAudiosInLayer(AudioLayer layer)
		{
			if (_audioSources.TryGetValue(layer, out var value))
			{
				return value;
			}
			List<AudioSource> value2 = new List<AudioSource>();
			_audioSources[layer] = value2;
			return _audioSources[layer];
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x7B9B2EC", Offset = "0x7B9B2EC", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv61.<>4__this = this;\n\tv61.onPlay = onPlay;\n\tv61.audioLayer = audioLayer;\n\tv112 = new System.Action`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, UnityEngine.AudioSource>();\n\tSystem.Action`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, UnityEngine.AudioSource>::.ctor(v112, v61, Il2CppMethodInfo);\n\tv61.onPlayInner = v112;\n\tv96 = new System.Action`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>();\n\tSystem.Action`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>::.ctor(v96, v61, Il2CppMethodInfo);\n\tUnco.SoundSystem.Scripts.Runtime.SoundProvider::Provide(this._soundProvider, type, v96);\n\treturn;\nL_002C:\n\tv61 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass25_0();\n\tSystem.Object::.ctor(v61);\n")]
		public void PlaySound(AudioType type, Action onPlay = null, AudioLayer audioLayer = AudioLayer.Default)
		{
			Action<RuntimeSound, AudioSource> action = delegate(RuntimeSound sound, AudioSource source)
			{
				SoundManager soundManager = this;
				RuntimeSoundProperties soundProperties = sound.SoundProperties;
				Action action2;
				if (soundProperties.IsMusic)
				{
					soundManager.LastPlayedMusic = soundProperties.Type;
					action2 = onPlay;
					if (onPlay == null)
					{
						return;
					}
				}
				else
				{
					soundManager.LastPlayedSound = soundProperties.Type;
					action2 = onPlay;
					if (onPlay == null)
					{
						return;
					}
				}
				action2();
			};
			Action<RuntimeSound, AudioSource> onPlayInner = action;
			Action<RuntimeSound> onProvided = delegate(RuntimeSound x)
			{
				PlaySoundInternal(x, audioLayer, onPlayInner);
			};
			_soundProvider.Provide(type, onProvided);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x7B9B71C", Offset = "0x7B9B71C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Unco.SoundSystem.Scripts.Runtime.SoundProvider::GetProvidedSound(this._soundProvider, type);\n\tv46 = v17 == 0;\n\tif (v46) goto L_0020;\n\tv48 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryGetExistAudioSource(this, v17, &v32 @ stack_-28_v4 (UnityEngine.AudioSource), audioLayer);\n\tv54 = ~v48;\n\tif (v54) goto L_0020;\n\tUnityEngine.AudioSource::Stop(v32);\nL_0020:\n\treturn;\n")]
		public void StopSound(AudioType type, AudioLayer audioLayer = AudioLayer.Default)
		{
			RuntimeSound providedSound = _soundProvider.GetProvidedSound(type);
			if (providedSound != null && TryGetExistAudioSource(providedSound, out var foundAudioSource, audioLayer))
			{
				foundAudioSource.Stop();
			}
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x7B9B990", Offset = "0x7B9B990", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryFindSound(this, type, &v17 @ stack_-28_v2 (Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound));\n\tv21 = ~v18;\n\tif (v21) goto L_001F;\n\tv27 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryGetExistAudioSource(this, v17, &v24 @ stack_-30_v3 (UnityEngine.AudioSource), audioLayer);\n\tv34 = ~v27;\n\tif (v34) goto L_001F;\n\tUnityEngine.AudioSource::Pause(v24);\nL_001F:\n\treturn;\n")]
		public void PauseSound(AudioType type, AudioLayer audioLayer = AudioLayer.Default)
		{
			if (TryFindSound(type, out var sound) && TryGetExistAudioSource(sound, out var foundAudioSource, audioLayer))
			{
				foundAudioSource.Pause();
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x7B9BA84", Offset = "0x7B9BA84", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryFindSound(this, type, &v17 @ stack_-28_v2 (Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound));\n\tv21 = ~v18;\n\tif (v21) goto L_001F;\n\tv27 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryGetExistAudioSource(this, v17, &v24 @ stack_-30_v3 (UnityEngine.AudioSource), audioLayer);\n\tv34 = ~v27;\n\tif (v34) goto L_001F;\n\tUnityEngine.AudioSource::UnPause(v24);\nL_001F:\n\treturn;\n")]
		public void ResumeSound(AudioType type, AudioLayer audioLayer = AudioLayer.Default)
		{
			if (TryFindSound(type, out var sound) && TryGetExistAudioSource(sound, out var foundAudioSource, audioLayer))
			{
				foundAudioSource.UnPause();
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x7B9BAE8", Offset = "0x7B9BAE8", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv65.mixerGroup = mixerGroup;\n\tv80 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(this, audioLayer);\n\tv127 = v80 == 0;\n\tv102 = v104;\n\tv121 = 0;\n\tif (v127) goto L_00A9;\n\tv153 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v80);\n\tv89 = v153._list;\n\tgoto L_0074;\nL_0074:\n\tv197 = UnityEngine.Object::op_Equality(v153.Current, 0);\n\tv321 = v197 == 0;\n\tv200 = ~v321;\n\tif (v200) goto L_0066;\n\tv135 = v65.<>9__0;\n\tv323 = v65.<>9__0 == 0;\n\tv324 = ~v323;\n\tif (v324) goto L_008C;\n\tv326 = new System.Func`2<Unco.Utils.Pair`2<Unco.SoundSystem.Scripts.Runtime.MixerGroup, UnityEngine.Audio.AudioMixerSnapshot>, System.Boolean>();\n\tSystem.Func`2<Unco.Utils.Pair`2<Unco.SoundSystem.Scripts.Runtime.MixerGroup, UnityEngine.Audio.AudioMixerSnapshot>, System.Boolean>::.ctor(v326, v65, Il2CppMethodInfo);\n\tv65.<>9__0 = v326;\n\tv135 = v326;\nL_008C:\n\tv336 = System.Linq.Enumerable::First(this.m_snapshotList, v135);\n\tUnityEngine.Audio.AudioMixerSnapshot::TransitionTo(v135, transitionDuration);\n\tgoto L_0066;\nL_0096:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v89 @ stack_-90_v3 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\nL_00A6:\n\treturn;\nL_00BA:\n\tv163 = v121 != 1;\n\tif (v163) goto L_00C9;\n\tv172 = 0x8BF5BC4(v136, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv208 = 0x8BF5BF4(v172, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v102);\n\tv180 = *([v172 @ X0_v12]) == 0;\n\tif (v180) goto L_00A6;\n\tv178 = new System.OutOfMemoryException();\n\tv108 = *([v172 @ X0_v12]);\n\tv136 = v178;\nL_00C9:\n\tv185 = 0x3943D10(&v108 @ stack_-A8_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv210 = 0x8BF0368(v136, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = 0xA1B8(v210, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_003A:\n\tv65 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass29_0();\n\tSystem.Object::.ctor(v65);\n\tv74 = v65 == 0;\n\tv102 = &v89 @ stack_-90_v3 (System.Collections.Generic.List`1<UnityEngine.AudioSource>);\n\tv108 = 0;\n\tv121 = v135;\n\tif (v74) goto L_00A9;\nL_00A9:\n\tv136 = new System.NullReferenceException();\n\tgoto L_00BA;\nL_0066:\n\tv207 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v89 @ stack_-90_v3 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv214 = v207 == 0;\n\tif (v214) goto L_0096;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetMixerSnapshot(AudioLayer audioLayer, MixerGroup mixerGroup, float transitionDuration = 0.5f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::SetMixerSnapshot");
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x7B9BD6C", Offset = "0x7B9BD6C", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv71 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v52);\n\tv94 = v71._list;\n\tgoto L_004E;\nL_004E:\n\tv120 = UnityEngine.Object::op_Equality(v71.Current, 0);\n\tv214 = v120 == 0;\n\tv124 = ~v214;\n\tif (v124) goto L_0040;\n\tv121 = UnityEngine.AudioSource::get_isPlaying(v71.Current);\n\tv125 = v121 == 0;\n\tif (v125) goto L_0040;\n\tUnityEngine.AudioSource::Pause(v71.Current);\n\tgoto L_0040;\nL_0061:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\nL_0069:\n\treturn;\nL_007C:\n\tv141 = 0 != 1;\n\tv154 = v108;\n\tif (v141) goto L_008C;\n\tv145 = 0x8BF5BC4(v108, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv164 = 0x8BF5BF4(v145, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv153 = *([v145 @ X0_v12]) == 0;\n\tif (v153) goto L_0069;\n\tv151 = new System.OutOfMemoryException();\n\tv77 = *([v145 @ X0_v12]);\n\tv154 = v151;\n\treturn;\nL_0024:\n\tv94 = 0;\n\tv52 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(v44, v41);\n\tv56 = v52 == 0;\n\tv77 = 0;\n\tif (v56) goto L_006C;\nL_006C:\n\tv108 = new System.NullReferenceException();\n\tgoto L_007C;\nL_0040:\n\tv130 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv143 = v130 == 0;\n\tif (v143) goto L_0061;\nL_008C:\n\tv157 = 0x3943D10(&v77 @ stack_-58_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv166 = 0x8BF0368(v154, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv212 = 0xA1B8(v166, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void PauseAllSounds(AudioLayer audioLayer = AudioLayer.Default)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::PauseAllSounds");
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x7B9BF14", Offset = "0x7B9BF14", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv71 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v52);\n\tv94 = v71._list;\n\tgoto L_004E;\nL_004E:\n\tv120 = UnityEngine.Object::op_Equality(v71.Current, 0);\n\tv214 = v120 == 0;\n\tv124 = ~v214;\n\tif (v124) goto L_0040;\n\tv121 = UnityEngine.AudioSource::get_isPlaying(v71.Current);\n\tv125 = v121 == 0;\n\tif (v125) goto L_0040;\n\tUnityEngine.AudioSource::Stop(v71.Current);\n\tgoto L_0040;\nL_0061:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\nL_0069:\n\treturn;\nL_007C:\n\tv141 = 0 != 1;\n\tv154 = v108;\n\tif (v141) goto L_008C;\n\tv145 = 0x8BF5BC4(v108, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv164 = 0x8BF5BF4(v145, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv153 = *([v145 @ X0_v12]) == 0;\n\tif (v153) goto L_0069;\n\tv151 = new System.OutOfMemoryException();\n\tv77 = *([v145 @ X0_v12]);\n\tv154 = v151;\n\treturn;\nL_0024:\n\tv94 = 0;\n\tv52 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(v44, v41);\n\tv56 = v52 == 0;\n\tv77 = 0;\n\tif (v56) goto L_006C;\nL_006C:\n\tv108 = new System.NullReferenceException();\n\tgoto L_007C;\nL_0040:\n\tv130 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv143 = v130 == 0;\n\tif (v143) goto L_0061;\nL_008C:\n\tv157 = 0x3943D10(&v77 @ stack_-58_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv166 = 0x8BF0368(v154, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv212 = 0xA1B8(v166, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void StopAllSounds(AudioLayer audioLayer = AudioLayer.Default)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::StopAllSounds");
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x7B9C0BC", Offset = "0x7B9C0BC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv71 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v52);\n\tv94 = v71._list;\n\tgoto L_004E;\nL_004E:\n\tv120 = UnityEngine.Object::op_Equality(v71.Current, 0);\n\tv214 = v120 == 0;\n\tv124 = ~v214;\n\tif (v124) goto L_0040;\n\tv121 = UnityEngine.AudioSource::get_isPlaying(v71.Current);\n\tv246 = v121 == 0;\n\tv125 = ~v246;\n\tif (v125) goto L_0040;\n\tUnityEngine.AudioSource::UnPause(v71.Current);\n\tgoto L_0040;\nL_0062:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\nL_006A:\n\treturn;\nL_007D:\n\tv141 = 0 != 1;\n\tv154 = v108;\n\tif (v141) goto L_008D;\n\tv145 = 0x8BF5BC4(v108, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv164 = 0x8BF5BF4(v145, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv153 = *([v145 @ X0_v12]) == 0;\n\tif (v153) goto L_006A;\n\tv151 = new System.OutOfMemoryException();\n\tv77 = *([v145 @ X0_v12]);\n\tv154 = v151;\n\treturn;\nL_0024:\n\tv94 = 0;\n\tv52 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(v44, v41);\n\tv56 = v52 == 0;\n\tv77 = 0;\n\tif (v56) goto L_006D;\nL_006D:\n\tv108 = new System.NullReferenceException();\n\tgoto L_007D;\nL_0040:\n\tv130 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v94 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv143 = v130 == 0;\n\tif (v143) goto L_0062;\nL_008D:\n\tv157 = 0x3943D10(&v77 @ stack_-58_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv166 = 0x8BF0368(v154, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv212 = 0xA1B8(v166, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ResumeAllSounds(AudioLayer audioLayer = AudioLayer.Default)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::ResumeAllSounds");
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x7B9C264", Offset = "0x7B9C264", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv52.<>4__this = this;\n\tv52.type = type;\n\tv52.audioLayer = audioLayer;\n\tv71 = new System.Action();\n\tSystem.Action::.ctor(v71, v52, Il2CppMethodInfo);\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this, type, v71, v52.audioLayer);\n\treturn;\nL_0021:\n\tv52 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass33_0();\n\tSystem.Object::.ctor(v52);\n")]
		public void PlayMusic(AudioType type, AudioLayer audioLayer = AudioLayer.Default)
		{
			AudioType type2 = type;
			Action onPlay = delegate
			{
				FadeData fadeData = default(FadeData);
				fadeData.Start = 0f;
				fadeData.End = 1f;
				fadeData.Duration = 1f;
				Action onComplete = default(Action);
				DoFade(type2, fadeData, out var _, onComplete, audioLayer);
			};
			PlaySound(type, onPlay, audioLayer);
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x7B9C34C", Offset = "0x7B9C34C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv52.<>4__this = this;\n\tv52.type = type;\n\tv71 = new System.Action();\n\tSystem.Action::.ctor(v71, v52, Il2CppMethodInfo);\n\t// 62 MakeStruct v78 @ AGG7B9C420_2_v1 (Unco.SoundSystem.Scripts.Runtime.FadeData), typeof(Unco.SoundSystem.Scripts.Runtime.FadeData), 1f, 0, 1f\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::DoFade(this, type, v78, &v109 @ stack_-44 (System.Single), 0, audioLayer);\n\treturn;\nL_0021:\n\tv52 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass34_0();\n\tSystem.Object::.ctor(v52);\n")]
		public void StopMusic(AudioType type, AudioLayer audioLayer = AudioLayer.Default)
		{
			AudioType type2 = type;
			Action action = delegate
			{
				SoundManager soundManager = this;
				RuntimeSound providedSound = soundManager._soundProvider.GetProvidedSound(type2);
				if (providedSound != null && soundManager.TryGetExistAudioSource(providedSound, out var foundAudioSource, default(AudioLayer)))
				{
					foundAudioSource.Stop();
				}
			};
			FadeData fadeData = default(FadeData);
			fadeData.Start = 1f;
			fadeData.End = 0f;
			fadeData.Duration = 1f;
			DoFade(type, fadeData, out var _, null, audioLayer);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x7B9C454", Offset = "0x7B9C454", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([defaultVolume @ X2 (System.Single&)]) = 0;\n\tv38 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryFindSound(this, type, &v37 @ stack_-58_v2 (Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound));\n\tv41 = ~v38;\n\tif (v41) goto L_005C;\n\tv47 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryGetExistAudioSource(this, v37, &v44 @ stack_-60_v3 (UnityEngine.AudioSource), audioLayer);\n\tv94 = ~v47;\n\tif (v94) goto L_005C;\n\tv163 = UnityEngine.AudioSource::get_volume(v44);\n\t*([defaultVolume @ X2 (System.Single&)]) = v163;\n\tv81 = v37.SoundProperties;\n\tv78 = fadeData < 0;\n\tv69 = fadeData == fadeData;\n\tv66 = ~v69;\n\tv63 = v78 == v66;\n\tif (v63) goto L_0046;\n\tv85 = fadeData.End * v81.Volume;\n\tv98 = PrimeTween.Tween::AudioVolume(v44, v85, fadeData.Duration, 0, 1, 0, 0f, 0f, 1);\n\tgoto L_005C;\nL_0046:\n\tv84 = fadeData * v81.Volume;\n\tv107 = fadeData.End * v81.Volume;\n\tv97 = PrimeTween.Tween::AudioVolume(v44, v84, v107, fadeData.Duration, 0, 1, 0, 0f, 0f, 1);\nL_005C:\n\treturn;\n")]
		public void DoFade(AudioType type, FadeData fadeData, out float defaultVolume, Action onComplete = null, AudioLayer audioLayer = AudioLayer.Default)
		{
			defaultVolume = default(float);
			defaultVolume = 0f;
			if (TryFindSound(type, out var sound) && TryGetExistAudioSource(sound, out var foundAudioSource, audioLayer))
			{
				float volume = foundAudioSource.volume;
				defaultVolume = volume;
				RuntimeSoundProperties soundProperties = sound.SoundProperties;
				bool flag = fadeData.Start < 0f;
				bool flag2 = fadeData.Start == fadeData.Start;
				bool flag3 = !flag2;
				if (flag != flag3)
				{
					float endValue = fadeData.End * soundProperties.Volume;
					Tween tween = Tween.AudioVolume(foundAudioSource, endValue, fadeData.Duration, default(Ease), 1, default(CycleMode), 0f, 0f, useUnscaledTime: true);
				}
				else
				{
					float startValue = fadeData.Start * soundProperties.Volume;
					float endValue2 = fadeData.End * soundProperties.Volume;
					Tween tween2 = Tween.AudioVolume(foundAudioSource, startValue, endValue2, fadeData.Duration, default(Ease), 1, default(CycleMode), 0f, 0f, useUnscaledTime: true);
				}
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x7B9C5F0", Offset = "0x7B9C5F0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv69 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v52);\n\tv92 = v69._list;\n\tUnityEngine.AudioSource::set_mute(v69.Current, 1);\n\tgoto L_003B;\nL_0048:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v92 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\nL_0050:\n\treturn;\nL_0060:\n\tv125 = Il2CppMethodInfo != 1;\n\tv138 = v103;\n\tif (v125) goto L_0070;\n\tv129 = 0x8BF5BC4(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv145 = 0x8BF5BF4(v129, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v92 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv137 = *([v129 @ X0_v12]) == 0;\n\tif (v137) goto L_0050;\n\tv135 = new System.OutOfMemoryException();\n\tv75 = *([v129 @ X0_v12]);\n\tv138 = v135;\n\treturn;\nL_0021:\n\tv92 = 0;\n\tv52 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(v44, v41);\n\tv56 = v52 == 0;\n\tv75 = 0;\n\tif (v56) goto L_0053;\nL_0053:\n\tv103 = new System.NullReferenceException();\n\tgoto L_0060;\nL_003B:\n\tv114 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v92 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv127 = v114 == 0;\n\tif (v127) goto L_0048;\nL_0070:\n\tv141 = 0x3943D10(&v75 @ stack_-58_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv147 = 0x8BF0368(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv189 = 0xA1B8(v147, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void MuteAudios(AudioLayer audioLayer = AudioLayer.Default)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::MuteAudios");
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x7B9C744", Offset = "0x7B9C744", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv69 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v52);\n\tv92 = v69._list;\n\tUnityEngine.AudioSource::set_mute(v69.Current, 0);\n\tgoto L_003B;\nL_0048:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v92 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\nL_0050:\n\treturn;\nL_0060:\n\tv125 = Il2CppMethodInfo != 1;\n\tv138 = v103;\n\tif (v125) goto L_0070;\n\tv129 = 0x8BF5BC4(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv145 = 0x8BF5BF4(v129, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v92 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv137 = *([v129 @ X0_v12]) == 0;\n\tif (v137) goto L_0050;\n\tv135 = new System.OutOfMemoryException();\n\tv75 = *([v129 @ X0_v12]);\n\tv138 = v135;\n\treturn;\nL_0021:\n\tv92 = 0;\n\tv52 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(v44, v41);\n\tv56 = v52 == 0;\n\tv75 = 0;\n\tif (v56) goto L_0053;\nL_0053:\n\tv103 = new System.NullReferenceException();\n\tgoto L_0060;\nL_003B:\n\tv114 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v92 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv127 = v114 == 0;\n\tif (v127) goto L_0048;\nL_0070:\n\tv141 = 0x3943D10(&v75 @ stack_-58_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv147 = 0x8BF0368(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv189 = 0xA1B8(v147, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void UnmuteAudios(AudioLayer audioLayer = AudioLayer.Default)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::UnmuteAudios");
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x7B9C898", Offset = "0x7B9C898", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = sound.SoundProperties;\n\tv136 = v26.CoolDown == 0;\n\tif (v136) goto L_0037;\n\tv143 = v26.LastPlayedTime == 0;\n\tif (v143) goto L_0037;\n\tv151 = UnityEngine.Time::get_time();\n\tv62 = v26.CoolDown + v26.LastPlayedTime;\n\tv158 = v62 < v151;\n\tv148 = ~v158;\n\tif (v148) goto L_0090;\nL_0037:\n\tv162 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryGetExistAudioSource(this, sound, &v159 @ stack_-58_v4 (UnityEngine.AudioSource), audioLayer);\n\tv219 = ~v162;\n\tv220 = ~v219;\n\tif (v220) goto L_0044;\n\tv69 = Unco.SoundSystem.Scripts.Runtime.SoundManager::CreateAudioSource(this, audioLayer);\n\tUnityEngine.AudioSource::set_resource(v69, sound.AudioResource);\nL_0044:\n\tv35 = sound.SoundProperties;\n\tUnityEngine.AudioSource::set_volume(v69, v35.Volume);\n\tUnityEngine.AudioSource::set_pitch(v69, v35.Pitch);\n\tUnityEngine.AudioSource::set_loop(v69, v35.IsLoop);\n\tv109 = sound.SoundProperties;\n\tv243 = v109.IsMusic == 0;\n\tif (v243) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv43 = 4;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv43 = 2;\n\tv84 = v73 - 1;\n\tv92 = v84 == 0;\n\tv55 = ~v92;\n\tUnityEngine.AudioSource::set_mute(v69, v55);\n\tUnityEngine.AudioSource::Play(v69);\n\tv236 = onPlay == 0;\n\tif (v236) goto L_0090;\n\tSystem.Action`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, UnityEngine.AudioSource>::Invoke(onPlay, sound, v69);\nL_0090:\n\treturn;\nL_0067:\n\tv73 = Unco.SettingsSystem.Core.SettingsManager::GetState(this._settingsManager, v43);\n")]
		private void PlaySoundInternal(RuntimeSound sound, AudioLayer audioLayer, Action<RuntimeSound, AudioSource> onPlay)
		{
			RuntimeSoundProperties soundProperties = sound.SoundProperties;
			if (soundProperties.CoolDown != 0f && soundProperties.LastPlayedTime != 0f)
			{
				float time = Time.time;
				float num = soundProperties.CoolDown + soundProperties.LastPlayedTime;
				if (!(num < time))
				{
					return;
				}
			}
			AudioSource audioSource = default(AudioSource);
			if (!TryGetExistAudioSource(sound, out var _, audioLayer))
			{
				audioSource = CreateAudioSource(audioLayer);
				audioSource.resource = sound.AudioResource;
			}
			RuntimeSoundProperties soundProperties2 = sound.SoundProperties;
			audioSource.volume = soundProperties2.Volume;
			audioSource.pitch = soundProperties2.Pitch;
			audioSource.loop = soundProperties2.IsLoop;
			RuntimeSoundProperties soundProperties3 = sound.SoundProperties;
			SettingsFlags flag = ((!soundProperties3.IsMusic) ? SettingsFlags.Sound : SettingsFlags.Music);
			int state = _settingsManager.GetState(flag);
			int num2 = state - 1;
			bool flag2 = num2 == 0;
			bool mute = !flag2;
			audioSource.mute = mute;
			audioSource.Play();
			onPlay?.Invoke(sound, audioSource);
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x7B9CE84", Offset = "0x7B9CE84", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = sound.SoundProperties;\n\tv40 = v8.IsMusic != 1;\n\tif (v40) goto L_001B;\n\tthis.LastPlayedMusic = v8.Type;\n\treturn;\nL_001B:\n\tthis.LastPlayedSound = v8.Type;\n\treturn;\n")]
		private void UpdateCurrentAudioData(RuntimeSound sound)
		{
			RuntimeSoundProperties soundProperties = sound.SoundProperties;
			if (soundProperties.IsMusic)
			{
				LastPlayedMusic = soundProperties.Type;
			}
			else
			{
				LastPlayedSound = soundProperties.Type;
			}
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x7B9C568", Offset = "0x7B9C568", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = fadeData < 0;\n\tv13 = fadeData == fadeData;\n\tv14 = ~v13;\n\tv15 = v9 == v14;\n\tif (v15) goto L_0024;\n\tv21 = fadeData.End * properties.Volume;\n\treturnVal1 = PrimeTween.Tween::AudioVolume(source, v21, fadeData.Duration, 0, 1, 0, 0f, 0f, 1);\n\treturn returnVal1;\nL_0024:\n\tv49 = fadeData * properties.Volume;\n\tv50 = fadeData.End * properties.Volume;\n\treturnVal3 = PrimeTween.Tween::AudioVolume(source, v49, v50, fadeData.Duration, 0, 1, 0, 0f, 0f, 1);\n\treturn returnVal3;\n")]
		private Tween DoFadeInternal(RuntimeSoundProperties properties, FadeData fadeData, AudioSource source)
		{
			bool flag = fadeData.Start < 0f;
			bool flag2 = fadeData.Start == fadeData.Start;
			bool flag3 = !flag2;
			if (flag != flag3)
			{
				float endValue = fadeData.End * properties.Volume;
				return Tween.AudioVolume(source, endValue, fadeData.Duration, default(Ease), 1, default(CycleMode), 0f, 0f, useUnscaledTime: true);
			}
			float startValue = fadeData.Start * properties.Volume;
			float endValue2 = fadeData.End * properties.Volume;
			return Tween.AudioVolume(source, startValue, endValue2, fadeData.Duration, default(Ease), 1, default(CycleMode), 0f, 0f, useUnscaledTime: true);
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x7B9B9F4", Offset = "0x7B9B9F4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = Unco.SoundSystem.Scripts.Runtime.SoundProvider::GetProvidedSound(this._soundProvider, type);\n\t*([sound @ X2 (Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound&)]) = v16;\n\tv47 = sound->klass;\n\tv48 = *([sound @ X2 (Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound&)]) == 0;\n\tif (v48) goto L_0025;\n\tv20 = v47.SoundProperties;\n\tv96 = v20.IsMusic == 0;\n\tif (v96) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv80 = 4;\n\tgoto L_002A;\nL_0025:\n\treturn 0;\nL_FFFFFFFF:\n\tv80 = 2;\nL_002A:\n\tv99 = Unco.SettingsSystem.Core.SettingsManager::GetState(this._settingsManager, v80);\n\tv71 = v99 - 1;\n\tv65 = v71 == 0;\n\treturn v65;\n")]
		private bool TryFindSound(AudioType type, out RuntimeSound sound)
		{
			sound = null;
			RuntimeSound providedSound = _soundProvider.GetProvidedSound(type);
			sound = providedSound;
			RuntimeSound runtimeSound = sound;
			if (sound != null)
			{
				RuntimeSoundProperties soundProperties = runtimeSound.SoundProperties;
				SettingsFlags flag = ((!soundProperties.IsMusic) ? SettingsFlags.Sound : SettingsFlags.Music);
				int state = _settingsManager.GetState(flag);
				int num = state - 1;
				return num == 0;
			}
			return false;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x7B9CA10", Offset = "0x7B9CA10", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = sound.SoundProperties;\n\tv35 = v12.CoolDown == 0;\n\tif (v35) goto L_0033;\n\tv42 = v12.LastPlayedTime == 0;\n\tif (v42) goto L_0033;\n\tv66 = UnityEngine.Time::get_time();\n\tv64 = v12.CoolDown + v12.LastPlayedTime;\n\tv84 = v64 < v66;\n\treturn v84;\nL_0033:\n\treturn 1;\n")]
		private bool IsCoolDownPassed(RuntimeSound sound)
		{
			RuntimeSoundProperties soundProperties = sound.SoundProperties;
			if (soundProperties.CoolDown != 0f && soundProperties.LastPlayedTime != 0f)
			{
				float time = Time.time;
				float num = soundProperties.CoolDown + soundProperties.LastPlayedTime;
				return num < time;
			}
			return true;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x7B9CA74", Offset = "0x7B9CA74", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.AudioSource::set_volume(audioSource, soundProperties.Volume);\n\tUnityEngine.AudioSource::set_pitch(audioSource, soundProperties.Pitch);\n\tUnityEngine.AudioSource::set_loop(audioSource, soundProperties.IsLoop);\n\treturn;\n")]
		private void ApplyDataToSource(SoundProperties soundProperties, AudioSource audioSource)
		{
			audioSource.volume = soundProperties.Volume;
			audioSource.pitch = soundProperties.Pitch;
			audioSource.loop = soundProperties.IsLoop;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x7B9CEC4", Offset = "0x7B9CEC4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([foundAudioSource @ X2 (UnityEngine.AudioSource&)]) = 0;\n\treturnVal1 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryFindSound(this, audioType, &v39 @ stack_-38_v2 (Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound));\n\tv43 = ~returnVal1;\n\tif (v43) goto L_0023;\n\treturnVal1 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryGetExistAudioSource(this, v39, foundAudioSource, audioLayer);\nL_0023:\n\treturn returnVal1;\n")]
		public bool TryGetExistAudioSource(AudioType audioType, out AudioSource foundAudioSource, AudioLayer audioLayer)
		{
			foundAudioSource = null;
			foundAudioSource = null;
			bool flag = TryFindSound(audioType, out var sound);
			if (flag)
			{
				flag = TryGetExistAudioSource(sound, out foundAudioSource, audioLayer);
			}
			return flag;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x7B9B79C", Offset = "0x7B9B79C", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv62 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(this, audioLayer);\n\tv142 = v62 == 0;\nL_FFFFFFFF:\n\tv210 = audioLayer;\nL_FFFFFFFF:\n\t;\n\tif (v142) goto L_0076;\n\tv206 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v62);\n\tv159 = v206._list;\n\tv292 = v206.Current == 0;\n\tif (v292) goto L_0070;\n\tv304 = UnityEngine.AudioSource::get_resource(v206.Current);\n\tv306 = v304 == 0;\n\tif (v306) goto L_0072;\n\tv268 = UnityEngine.Object::Equals(v304, sound.AudioResource);\n\tv271 = v268 == 0;\n\tif (v271) goto L_0045;\n\tv269 = UnityEngine.AudioSource::get_isPlaying(v206.Current);\n\tv316 = v269 == 0;\n\tif (v316) goto L_0068;\n\tv312 = sound.SoundProperties;\n\tv319 = v312.IsMultiple == 0;\n\tv272 = ~v319;\n\tif (v272) goto L_0045;\nL_0068:\n\t*([foundAudioSource @ X2 (UnityEngine.AudioSource&)]) = v206.Current;\nL_006E:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v159 @ stack_-60_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\nL_FFFFFFFF:\n\tv189 = v280;\n\tgoto L_00A0;\nL_0070:\n\tv305 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv211 = 0;\n\tgoto L_0075;\nL_0072:\n\tv309 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv211 = Il2CppMethodInfo;\n\tgoto L_0075;\nL_0075:\n\t// 117 Interrupt\nL_FFFFFFFF:\n\tv120 = 0;\nL_FFFFFFFF:\n\tv210 = v211;\nL_0088:\n\tv64 = v210 != 1;\nL_FFFFFFFF:\n\tv253 = v218;\n\tif (v64) goto L_00A5;\n\tv286 = 0x8BF5BC4(v218, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv299 = 0x8BF5BF4(v286, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v159 @ stack_-60_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv307 = *([v286 @ X0_v18]) == 0;\n\tv128 = ~v307;\n\tif (v128) goto L_00A2;\nL_FFFFFFFF:\n\tv189 = 0;\nL_00A2:\n\tv288 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv120 = *([v286 @ X0_v18]);\nL_FFFFFFFF:\n\tv253 = v288;\n\treturn returnVal2;\nL_0022:\n\t*([foundAudioSource @ X2 (UnityEngine.AudioSource&)]) = 0;\n\tv56 = sound == 0;\n\tif (v56) goto L_FFFFFFFF;\nL_0076:\n\tv218 = new System.NullReferenceException();\n\tgoto L_0088;\nL_0045:\n\tv280 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v159 @ stack_-60_v4 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv284 = v280 == 0;\n\tif (v284) goto L_006E;\nL_00A0:\n\treturn v189;\nL_00A5:\n\tv291 = 0x3943D10(&v120 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv301 = 0x8BF0368(v253, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v301, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool TryGetExistAudioSource(RuntimeSound sound, out AudioSource foundAudioSource, AudioLayer audioLayer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::TryGetExistAudioSource");
			foundAudioSource = default;
			return default;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x7B9CACC", Offset = "0x7B9CACC", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tv62.audioLayer = audioLayer;\n\tv77 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(this, audioLayer);\n\tv189 = 0xB2D1000 + 0x1B0;\n\tv186 = 0xB2CA000 + 0x4A8;\n\tv280 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v77);\n\tv148 = v280._list;\n\tv304 = UnityEngine.AudioSource::get_isPlaying(v280.Current);\n\tv357 = v304 == 0;\n\tv306 = ~v357;\n\tif (v306) goto L_006F;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v148 @ stack_-80_v6 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv461 = v280.Current;\n\tgoto L_00FB;\nL_0083:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v148 @ stack_-80_v6 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv224 = v77;\nL_0087:\n\tv353 = UnityEngine.Component::get_transform(this);\n\tgoto L_008F;\nL_008F:\n\t;\n\tv203 = UnityEngine.Object::Instantiate /* +1 sharing this address */(this.AudioSourceTemp, v353, *([v189 @ X24_v5 (System.Int32)]));\n\tv204 = UnityEngine.GameObject::GetComponent /* +1 sharing this address */(v203, *([v186 @ X28_v5 (System.Int32)]));\n\tgoto L_00B4;\nL_00B4:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.AudioSource>::Add(v224, v204);\n\tv492 = new System.Func`2<Unco.Utils.Pair`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, UnityEngine.Audio.AudioMixerGroup>, System.Boolean>();\n\tSystem.Func`2<Unco.Utils.Pair`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, UnityEngine.Audio.AudioMixerGroup>, System.Boolean>::.ctor(v492, v62, Il2CppMethodInfo);\n\tv205 = Unco.Extensions.CollectionExtensions::FindIndex(this.m_mixerList, v492);\n\tv111 = v205 == -1;\n\tv461 = v204;\n\tif (v111) goto L_00FB;\n\tv217 = this.m_mixerList;\n\tv500 = v205 < v217.Length;\n\tv127 = ~v500;\n\tif (v127) goto L_00FF;\n\tv447 = v205 << 4;\n\tv459 = v217 + v447;\n\tUnityEngine.AudioSource::set_outputAudioMixerGroup(v204, *([v459 @ X8_v17+28]));\n\tv461 = v204;\nL_00FB:\n\treturn v461;\nL_00FF:\n\tv266 = new System.IndexOutOfRangeException();\n\tgoto L_010C;\nL_010C:\n\tv297 = v260 != 1;\n\tv312 = v253;\n\tv320 = v266;\n\tif (v297) goto L_011C;\n\tv311 = 0x8BF5BC4(v266, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv330 = 0x8BF5BF4(v311, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v251);\n\tv319 = *([v311 @ X0_v15]) == 0;\n\tv186 = v256;\n\tv189 = v257;\n\tv224 = v265;\n\tif (v319) goto L_0087;\n\tv317 = new System.OutOfMemoryException();\n\tv312 = *([v311 @ X0_v15]);\n\tv320 = v317;\n\treturn returnVal1;\nL_0042:\n\tv62 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass46_0();\n\tSystem.Object::.ctor(v62);\nL_006F:\n\tv309 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v148 @ stack_-80_v6 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv328 = v309 == 0;\n\tif (v328) goto L_0083;\nL_011C:\n\tv323 = 0x3943D10(&v312 @ stack_-98_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv332 = 0x8BF0368(v320, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v332, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe AudioSource CreateAudioSource(AudioLayer audioLayer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::CreateAudioSource");
			return default;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x7B9CF40", Offset = "0x7B9CF40", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\treturnVal1 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryFindSound(this, audioType, &v17 @ stack_-28_v2 (Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound));\n\tv21 = ~returnVal1;\n\tif (v21) goto L_0018;\n\treturnVal1 = Unco.SoundSystem.Scripts.Runtime.SoundManager::TryGetExistAudioSource(this, v17, &v14 @ stack_-30_v1 (UnityEngine.AudioSource), audioLayer);\nL_0018:\n\treturn returnVal1;\n")]
		public bool IsSoundPlaying(AudioType audioType, AudioLayer audioLayer = AudioLayer.Default)
		{
			AudioSource foundAudioSource = null;
			bool flag = TryFindSound(audioType, out var sound);
			if (flag)
			{
				flag = TryGetExistAudioSource(sound, out foundAudioSource, audioLayer);
			}
			return flag;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x7B9CE20", Offset = "0x7B9CE20", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = sound.SoundProperties;\n\tv35 = v8.IsMusic == 0;\n\tif (v35) goto L_0025;\n\tv85 = Unco.SettingsSystem.Core.SettingsManager::GetState(this._settingsManager, 4);\n\tv64 = v85 - 1;\n\tv56 = v64 == 0;\n\treturn v56;\nL_0025:\n\tv86 = Unco.SettingsSystem.Core.SettingsManager::GetState(this._settingsManager, 2);\n\tv65 = v86 - 1;\n\tv57 = v65 == 0;\n\treturn v57;\n")]
		private bool IsSoundPlayable(RuntimeSound sound)
		{
			RuntimeSoundProperties soundProperties = sound.SoundProperties;
			if (soundProperties.IsMusic)
			{
				int state = _settingsManager.GetState(SettingsFlags.Music);
				int num = state - 1;
				return num == 0;
			}
			int state2 = _settingsManager.GetState(SettingsFlags.Sound);
			int num2 = state2 - 1;
			return num2 == 0;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x7B9AB88", Offset = "0x7B9AB88", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv72 = Unco.SoundSystem.Scripts.Runtime.SoundProvider::GetAllProvidedMusics(this._soundProvider);\n\tv103 = v62 == 0;\n\tif (v103) goto L_00BB;\n\tv200 = v72.Length < 1;\n\tif (v200) goto L_00CA;\n\tv159 = 0;\nL_0060:\n\tv341 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v129 @ stack_-80_v5 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv346 = v341 == 0;\n\tif (v346) goto L_0081;\n\tv349 = v286.Current == 0;\n\tif (v349) goto L_0097;\n\tv356 = UnityEngine.AudioSource::get_resource(v286.Current);\n\tv183 = v356 == 0;\n\tif (v183) goto L_0091;\n\tv333 = UnityEngine.Object::Equals(v356, v112.AudioResource);\n\tv336 = v333 == 0;\n\tif (v336) goto L_0060;\n\tUnityEngine.AudioSource::set_mute(v286.Current, mute);\n\tgoto L_0060;\nL_007B:\n\tv344 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v129 @ stack_-80_v5 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv347 = ~v344;\n\tv348 = ~v347;\n\tif (v348) goto L_0094;\nL_0081:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v129 @ stack_-80_v5 (System.Collections.Generic.List`1<UnityEngine.AudioSource>));\n\tv159 = v159 + 1;\n\tv229 = v159 < v72.Length;\n\tif (v229) goto L_0049;\n\tgoto L_00CA;\nL_0091:\n\tv178 = new System.NullReferenceException();\n\tv148 = 0;\n\tgoto L_00CC;\nL_0094:\n\tv354 = v286.Current == 0;\n\tv185 = ~v354;\n\tif (v185) goto L_009A;\nL_0097:\n\tv178 = new System.NullReferenceException();\n\tv148 = 0;\n\tgoto L_00CC;\nL_009A:\n\tv360 = UnityEngine.AudioSource::get_resource(v286.Current);\n\tv178 = new System.NullReferenceException();\n\tv148 = 0;\n\tgoto L_00CC;\nL_00BB:\n\tv75 = v72.Length >= 1;\n\tif (v75) goto L_00CB;\nL_00CA:\n\treturn;\nL_00CB:\n\tv178 = new System.NullReferenceException();\nL_00CC:\n\t// 204 Interrupt\n\treturn;\nL_002A:\n\tv62 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(this, audioLayer);\nL_0049:\n\tv112 = v72[v159 @ X23_v5 (System.Int32)];\n\tv286 = System.Collections.Generic.List`1<UnityEngine.AudioSource>::GetEnumerator(v62);\n\tv129 = v286._list;\n\tv325 = v72[v159 @ X23_v5 (System.Int32)] == 0;\n\tif (v325) goto L_007B;\n\tv198 = 0x3943D10(&v148 @ stack_-98 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv202 = 0x8BF0368(v178, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv266 = 0xA1B8(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void SetMusicsMuteCondition(bool mute, AudioLayer audioLayer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::SetMusicsMuteCondition");
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x7B9ADCC", Offset = "0x7B9ADCC", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\nL_0048:\n\tv64 = Unco.SoundSystem.Scripts.Runtime.SoundProvider::GetAllProvidedMusics(this._soundProvider);\n\tv127 = System.Collections.Generic.Dictionary`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>::get_Values(this._audioSources);\n\tv253 = &v108 @ stack_-B8 (System.Int32);\n\tv254 = System.Collections.Generic.Dictionary`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>+ValueCollection<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>::GetEnumerator(v127);\n\tv108 = v108.m_value;\n\tv87 = v108.m_value;\n\tv339 = *([v253 @ X8_v12+10]) == 0;\n\tif (v339) goto L_0120;\n\tv349 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(*([v253 @ X8_v12+10]));\n\tv108 = *([v349 @ X0_v30]);\n\tv291 = *([v349 @ X0_v30]);\n\tv463 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass50_0();\n\tSystem.Object::.ctor(v463);\n\tv456 = v463 == 0;\n\tif (v456) goto L_00E3;\n\tv463.audioSource = *([v349 @ X0_v30+10]);\n\tgoto L_00AB;\nL_00AB:\n\tv434 = UnityEngine.Object::op_Equality(v463.audioSource, 0);\n\tv477 = v434 == 0;\n\tv439 = ~v477;\n\tif (v439) goto L_0090;\n\tv457 = v463.audioSource == 0;\n\tif (v457) goto L_00E5;\n\tv480 = UnityEngine.AudioSource::get_resource(v463.audioSource);\n\tgoto L_00BF;\nL_00BF:\n\tv435 = UnityEngine.Object::op_Equality(v480, 0);\n\tv488 = v435 == 0;\n\tv440 = ~v488;\n\tif (v440) goto L_0090;\n\tv490 = new System.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, System.Boolean>();\n\tSystem.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, System.Boolean>::.ctor(v490, v463, Il2CppMethodInfo);\n\tv436 = System.Linq.Enumerable::Any(v64, v490);\n\tv495 = v436 == 0;\n\tv441 = ~v495;\n\tif (v441) goto L_0090;\n\tv442 = v463.audioSource == 0;\n\tif (v442) goto L_00E7;\n\tUnityEngine.AudioSource::set_mute(v463.audioSource, mute);\n\tgoto L_0090;\n\tgoto L_0123;\nL_00E3:\n\tthrow v463;\nL_00E5:\n\tv454 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv108 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_0124;\nL_00E7:\n\tv455 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv108 = 0;\n\tgoto L_0124;\nL_FFFFFFFF:\n\tv182 = &v87 @ stack_-80_v4 (System.Int32);\nL_FFFFFFFF:\n\tv185 = 0;\nL_FFFFFFFF:\n\tv225 = 0;\n\treturn;\nL_0120:\n\tv350 = new System.NullReferenceException();\nL_FFFFFFFF:\n\t;\n\tgoto L_0124;\nL_0123:\n\tv452 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv108 = 0;\nL_FFFFFFFF:\n\t;\nL_0124:\n\t// 292 Interrupt\nL_FFFFFFFF:\n\tv182 = &v87 @ stack_-80_v4 (System.Int32);\nL_FFFFFFFF:\n\tv185 = 0;\nL_0127:\n\tv229 = new System.OutOfMemoryException();\n\tv322 = 0x8BF5BC4(v229, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv225 = *([v322 @ X0_v18]);\n\tv332 = 0x8BF5BF4(v322, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv185 = *([v322 @ X0_v18]);\n\tgoto L_010E;\n\treturn;\n\tthrow System.NullReferenceException;\nL_0090:\n\tv450 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v291 @ stack_-A0_v7 (System.Int32));\n\tv461 = v450 == 0;\n\tif (v461) goto L_00DF;\nL_0075:\n\tv320 = System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+ValueCollection<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::MoveNext(&v87 @ stack_-80_v4 (System.Int32));\n\tv329 = v320 == 0;\n\tif (v329) goto L_FFFFFFFF;\n\tv240 = 0x3943D10(&v108 @ stack_-B8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_013C;\nL_00DF:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v291 @ stack_-A0_v7 (System.Int32));\nL_FFFFFFFF:\n\tv108 = 0;\n\tgoto L_0075;\nL_013C:\n\tv276 = Il2CppMethodInfo != 1;\n\tif (v276) goto L_0146;\nL_010E:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+ValueCollection<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::Dispose(v182);\n\tv363 = v225 == 0;\n\tv221 = ~v363;\n\tif (v221) goto L_0127;\nL_0146:\n\tv324 = 0x3943D50(&v185 @ stack_-C8_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv334 = 0x8BF0368(v229, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv341 = 0xA1B8(v334, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void SetSoundsMuteCondition(bool mute)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::SetSoundsMuteCondition");
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x7B9B784", Offset = "0x7B9B784", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.SoundSystem.Scripts.Runtime.SoundProvider::GetProvidedSound(this._soundProvider, audioType);\n\treturn returnVal1;\n")]
		public RuntimeSound GetRuntimeSound(AudioType audioType)
		{
			return _soundProvider.GetProvidedSound(audioType);
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x7B9D198", Offset = "0x7B9D198", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv50 = v48.OverrideActiveness ^ 1;\n\tv48.OverrideActiveness = v50;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(v42, v42.LastPlayedMusic, 0, 0);\n\treturn;\n")]
		public void ToggleSound()
		{
			int overrideActiveness = (OverrideActiveness ? 1 : 0) ^ 1;
			OverrideActiveness = (byte)overrideActiveness != 0;
			PlaySound(LastPlayedMusic);
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x7B9D20C", Offset = "0x7B9D20C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv57.value = value;\n\tv72 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(this, audioLayer);\n\tv57.audioSources = v72;\n\tv81 = new System.Action`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>();\n\tSystem.Action`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>::.ctor(v81, v57, Il2CppMethodInfo);\n\tUnco.SoundSystem.Scripts.Runtime.SoundProvider::Provide(this._soundProvider, audioType, v81);\n\treturn;\nL_0024:\n\tv57 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass53_0();\n\tSystem.Object::.ctor(v57);\n")]
		public unsafe void UpdateVolume(AudioType audioType, float value, AudioLayer audioLayer = AudioLayer.Default)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::UpdateVolume");
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x7B9D310", Offset = "0x7B9D310", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv57.value = value;\n\tv72 = Unco.SoundSystem.Scripts.Runtime.SoundManager::GetAudiosInLayer(this, audioLayer);\n\tv57.audioSources = v72;\n\tv81 = new System.Action`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>();\n\tSystem.Action`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>::.ctor(v81, v57, Il2CppMethodInfo);\n\tUnco.SoundSystem.Scripts.Runtime.SoundProvider::Provide(this._soundProvider, audioType, v81);\n\treturn;\nL_0024:\n\tv57 = new Unco.SoundSystem.Scripts.Runtime.SoundManager+<>c__DisplayClass54_0();\n\tSystem.Object::.ctor(v57);\n")]
		public unsafe void UpdatePitch(AudioType audioType, float value, AudioLayer audioLayer = AudioLayer.Default)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::UpdatePitch");
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x7B9D414", Offset = "0x7B9D414", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
		private static bool GetWrappedRemote(RemoteKey remoteKey)
		{
			return true;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x7B9D41C", Offset = "0x7B9D41C", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv157 = this._settingsManager + 0x20;\n\tv59 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v59, this, Il2CppMethodInfo);\n\tv118 = System.Delegate::Remove(v47.OnMusicChanged, v59);\n\tv138 = v118 == 0;\n\tif (v138) goto L_006C;\n\tv144 = 0x21C11D0(v118, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv162 = v144 == 0;\n\tif (v162) goto L_006A;\n\tv47.OnMusicChanged = v144;\n\tv178 = 0x21C11D0(v118, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = v178 == 0;\n\tif (v184) goto L_006A;\n\tv195 = this._settingsManager;\nL_004A:\n\tv157 = v195 + 0x18;\n\tv198 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v198, this, Il2CppMethodInfo);\n\tv108 = System.Delegate::Remove(v195.OnSoundChanged, v198);\n\tv110 = v108 == 0;\n\tif (v110) goto L_0075;\n\tv183 = 0x21C11D0(v108, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv185 = v183 == 0;\n\tif (v185) goto L_006A;\n\tv195.OnSoundChanged = v183;\n\tv130 = 0x21C11D0(v108, System.Action`1<System.Int32>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv225 = v130 == 0;\n\tv132 = ~v225;\n\tif (v132) goto L_007C;\nL_006A:\n\tthrow System.InvalidCastException;\nL_006C:\n\t*([v157 @ X20_v12 (Unco.SettingsSystem.Core.SettingsManager)]) = 0;\n\tv195 = this._settingsManager;\n\tv163 = this._settingsManager == 0;\n\tv82 = ~v163;\n\tif (v82) goto L_004A;\n\tthrow System.NullReferenceException;\nL_0075:\n\t*([v157 @ X20_v12 (Unco.SettingsSystem.Core.SettingsManager)]) = 0;\nL_008B:\n\tUnityEngine.Object::Destroy(v141);\n\treturn;\nL_001F:\n\tv47 = this._settingsManager;\nL_007C:\n\tv141 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_008B;\n")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SoundManager::Dispose");
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x7B9D608", Offset = "0x7B9D608", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>();\n\tSystem.Collections.Generic.Dictionary`2<Unco.SoundSystem.Scripts.Runtime.AudioLayer, System.Collections.Generic.List`1<UnityEngine.AudioSource>>::.ctor(v48);\n\tthis._audioSources = v48;\n")]
		public SoundManager()
		{
			Dictionary<AudioLayer, List<AudioSource>> audioSources = new Dictionary<AudioLayer, List<AudioSource>>();
			_audioSources = audioSources;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.SoundSystem.Scripts.Runtime.Data;
using UnityEngine;
using UnityEngine.Audio;

namespace Unco.SoundSystem.Scripts.Runtime
{
	[Token(Token = "0x2000015")]
	public class SoundProvider
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000016")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000059")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400005A")]
			public static Func<RuntimeSound, bool> _003C_003E9__5_0;

			[Token(Token = "0x600004C")]
			[Address(RVA = "0x7B9E048", Offset = "0x7B9E048", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.SoundSystem.Scripts.Runtime.SoundProvider+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600004D")]
			[Address(RVA = "0x7B9E0AC", Offset = "0x7B9E0AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGetAllProvidedMusics_003Eb__5_0(RuntimeSound sound)
			{
				RuntimeSoundProperties soundProperties = sound.SoundProperties;
				return soundProperties.IsMusic;
			}
		}

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<RuntimeSound> _runtimeSounds;

		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x18")]
		private SoundListSo _soundList;

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x7B9AAD0", Offset = "0x7B9AAD0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tSystem.Object::.ctor(this);\n\tthis._soundList = soundList;\n\treturn;\nL_001F:\n\tv53 = new System.Collections.Generic.List`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>();\n\tSystem.Collections.Generic.List`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>::.ctor(v53);\n\tthis._runtimeSounds = v53;\n")]
		public SoundProvider(SoundListSo soundList)
		{
			List<RuntimeSound> runtimeSounds = new List<RuntimeSound>();
			_runtimeSounds = runtimeSounds;
			_soundList = soundList;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x7B9B450", Offset = "0x7B9B450", Length = "0x2CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv52.audioType = audioType;\n\tv52.<>4__this = this;\n\tv52.onProvided = onProvided;\n\tv105 = Unco.SoundSystem.Scripts.Runtime.SoundProvider::GetProvidedSound(this, v52.audioType);\n\tv52.runtimeSound = v105;\n\tv175 = v52.runtimeSound == 0;\n\tif (v175) goto L_0064;\n\tv136 = v52.onProvided == 0;\n\tif (v136) goto L_00D4;\n\tSystem.Action`1<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound>::Invoke(v52.onProvided, v52.runtimeSound);\n\treturn;\nL_0064:\n\tv83 = this._soundList;\n\tv199 = new System.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.BaseSound, System.Boolean>();\n\tSystem.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.BaseSound, System.Boolean>::.ctor(v199, v52, Il2CppMethodInfo);\n\tv209 = System.Linq.Enumerable::FirstOrDefault(v83.SoundList, v199);\n\tv52.soundSo = v209;\n\tgoto L_0089;\nL_0089:\n\tv223 = UnityEngine.Object::op_Inequality(v52.soundSo, 0);\n\tv225 = ~v223;\n\tif (v225) goto L_00B2;\n\tv78 = new System.Action`1<UnityEngine.Audio.AudioResource>();\n\tSystem.Action`1<UnityEngine.Audio.AudioResource>::.ctor(v78, v52, Il2CppMethodInfo);\n\tv133 = Unco.SoundSystem.Scripts.Runtime.Data.BaseSound::LoadClip(v133, v78);\n\treturn;\nL_00B2:\n\tv182 = v52.audioType;\n\t// 183 Box v247 @ X0_v25 (System.Object), typeof(Unco.SoundSystem.Scripts.Runtime.SoundManager+AudioType), &v182 @ stack_-44_v2 (Unco.SoundSystem.Scripts.Runtime.SoundManager+AudioType)\n\tv186 = System.String::Format(\"Can't find sound with type of {0}\", v247);\n\tgoto L_00CA;\nL_00D4:\n\treturn;\nL_0036:\n\tv52 = new Unco.SoundSystem.Scripts.Runtime.SoundProvider+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v52);\nL_00CA:\n\tUnityEngine.Debug::LogWarning(v186);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Provide(SoundManager.AudioType audioType, Action<RuntimeSound> onProvided)
		{
			RuntimeSound providedSound = GetProvidedSound(audioType);
			RuntimeSound runtimeSound = providedSound;
			if (runtimeSound != null)
			{
				if (onProvided != null)
				{
					onProvided(runtimeSound);
				}
				return;
			}
			SoundListSo soundList = _soundList;
			Func<BaseSound, bool> predicate = delegate(BaseSound sound)
			{
				SoundProperties soundProperties = sound.SoundProperties;
				int num = soundProperties.Type - audioType;
				return num == 0;
			};
			object obj = soundList.SoundList.FirstOrDefault((Func<object, bool>)predicate);
			BaseSound soundSo = (BaseSound)obj;
			if (soundSo != null)
			{
				Action<AudioResource> onComplete = delegate(AudioResource clip)
				{
					RuntimeSound providedSound2 = GetProvidedSound(audioType);
					runtimeSound = providedSound2;
					Action<RuntimeSound> action;
					if (runtimeSound == null)
					{
						RuntimeSound runtimeSound2 = soundSo.GenerateRuntimeSound(clip);
						runtimeSound = runtimeSound2;
						SoundProvider soundProvider = this;
						if (!soundProvider._runtimeSounds.Contains(runtimeSound))
						{
							SoundProvider soundProvider2 = this;
							List<RuntimeSound> runtimeSounds = soundProvider2._runtimeSounds;
							runtimeSounds.Add(runtimeSound);
							action = onProvided;
							if (onProvided == null)
							{
								return;
							}
							goto IL_0116;
						}
					}
					action = onProvided;
					if (onProvided == null)
					{
						return;
					}
					goto IL_0116;
					IL_0116:
					action(runtimeSound);
				};
				BaseSound baseSound = default(BaseSound);
				baseSound.LoadClip(onComplete);
			}
			else
			{
				SoundManager.AudioType audioType2 = audioType;
				object arg = audioType2;
				string message = $"Can't find sound with type of {arg}";
				Debug.LogWarning(message);
			}
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x7B9D0B8", Offset = "0x7B9D0B8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.audioType = audioType;\n\tv71 = new System.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, System.Boolean>();\n\tSystem.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, System.Boolean>::.ctor(v71, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(this._runtimeSounds, v71);\n\treturn returnVal2;\nL_0023:\n\tv51 = new Unco.SoundSystem.Scripts.Runtime.SoundProvider+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v51);\n")]
		public RuntimeSound GetProvidedSound(SoundManager.AudioType audioType)
		{
			Func<RuntimeSound, bool> predicate = delegate(RuntimeSound sound)
			{
				RuntimeSoundProperties soundProperties = sound.SoundProperties;
				int num = soundProperties.Type - audioType;
				return num == 0;
			};
			return (RuntimeSound)_runtimeSounds.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x7B9CF8C", Offset = "0x7B9CF8C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0040;\nL_0051:\n\tv94 = System.Linq.Enumerable::Where(this._runtimeSounds, v89);\n\treturnVal1 = System.Linq.Enumerable::ToArray(v94);\n\treturn returnVal1;\nL_0029:\n\tgoto L_0032;\nL_0040:\n\tv105 = new System.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, System.Boolean>();\n\tSystem.Func`2<Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound, System.Boolean>::.ctor(v105, v100.<>9, Il2CppMethodInfo);\n\tv122.<>9__5_0 = v105;\n\tv89 = v105;\nL_0032:\n\tv66 = v64.<>9__5_0 == 0;\n\tv67 = ~v66;\n\tv89 = v64.<>9__5_0;\n\tif (v67) goto L_0051;\n")]
		public RuntimeSound[] GetAllProvidedMusics()
		{
			bool flag = _003C_003Ec._003C_003E9__5_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__5_0;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__5_0 = delegate(RuntimeSound sound)
				{
					RuntimeSoundProperties soundProperties = sound.SoundProperties;
					return soundProperties.IsMusic;
				});
			}
			IEnumerable<object> source = _runtimeSounds.Where(predicate);
			return (RuntimeSound[])source.ToArray();
		}
	}
}

using System;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Audio;

namespace Unco.SoundSystem.Scripts.Runtime.Data
{
	[Token(Token = "0x2000019")]
	public abstract class BaseSound : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x18")]
		private SoundProperties m_soundProperties;

		[Token(Token = "0x17000005")]
		public SoundProperties SoundProperties
		{
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x7B9E394", Offset = "0x7B9E394", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SoundProperties;\n")]
			get
			{
				return m_soundProperties;
			}
			[Token(Token = "0x6000055")]
			[Address(RVA = "0x7B9E39C", Offset = "0x7B9E39C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.SoundProperties = value;\n\treturn;\n")]
			set
			{
				m_soundProperties = value;
			}
		}

		[Token(Token = "0x6000056")]
		public abstract void LoadClip(Action<AudioResource> OnComplete);

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x7B9E26C", Offset = "0x7B9E26C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv60.Volume = 0f;\n\tSystem.Object::.ctor(v60);\n\tv64 = this.SoundProperties == 0;\n\tif (v64) goto L_004E;\n\tv60.Type = v58.Type;\n\tv60.Volume = v58.Volume;\n\tv60.IsLoop = v58.IsLoop;\n\tv60.IsMusic = v58.IsMusic;\n\tv60.CoolDown = v58.CoolDown;\n\tv70 = v53 == 0;\n\tif (v70) goto L_004E;\n\tv53.SoundProperties = v60;\n\tv53.AudioResource = audioClip;\n\treturn v53;\nL_004E:\n\tthrow v60;\nL_001F:\n\tv53 = new Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSound();\n\tSystem.Object::.ctor(v53);\n\tv58 = this.SoundProperties;\n\tv60 = new Unco.SoundSystem.Scripts.Runtime.Data.RuntimeSoundProperties();\n")]
		public RuntimeSound GenerateRuntimeSound(AudioResource audioClip)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseSound::GenerateRuntimeSound");
			return default;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x7B9E40C", Offset = "0x7B9E40C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		protected internal BaseSound()
		{
		}
	}
}

using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Audio;

namespace Unco.SoundSystem.Scripts.Runtime.Data
{
	[CreateAssetMenu(menuName = "Unco/SoundSystem/Sound", fileName = "SoundSystem", order = 10)]
	[Token(Token = "0x200001C")]
	public class Sound : BaseSound
	{
		[SerializeField]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x20")]
		private AudioResource m_clip;

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x7B9E454", Offset = "0x7B9E454", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = OnComplete == 0;\n\tif (v0) goto L_0008;\n\tSystem.Action`1<UnityEngine.Audio.AudioResource>::Invoke(OnComplete, this.m_clip);\n\treturn;\nL_0008:\n\treturn;\n")]
		public override void LoadClip(Action<AudioResource> OnComplete)
		{
			OnComplete?.Invoke(m_clip);
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x7B9E474", Offset = "0x7B9E474", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public Sound()
		{
		}
	}
}

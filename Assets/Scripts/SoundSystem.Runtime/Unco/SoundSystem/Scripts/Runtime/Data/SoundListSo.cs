using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.SoundSystem.Scripts.Runtime.Data
{
	[CreateAssetMenu(menuName = "Unco/SoundSystem/SoundList", fileName = "SoundSystem", order = 10)]
	[Token(Token = "0x200001D")]
	public class SoundListSo : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x18")]
		private List<BaseSound> m_soundList;

		[Token(Token = "0x17000009")]
		public List<BaseSound> SoundList
		{
			[Token(Token = "0x6000063")]
			[Address(RVA = "0x7B9E47C", Offset = "0x7B9E47C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SoundList;\n")]
			get
			{
				return m_soundList;
			}
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x7B9E484", Offset = "0x7B9E484", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public SoundListSo()
		{
		}
	}
}

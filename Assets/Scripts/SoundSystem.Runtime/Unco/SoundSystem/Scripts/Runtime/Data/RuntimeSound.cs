using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Audio;

namespace Unco.SoundSystem.Scripts.Runtime.Data
{
	[Serializable]
	[Token(Token = "0x200001A")]
	public class RuntimeSound
	{
		[Token(Token = "0x17000006")]
		[field: Token(Token = "0x4000062")]
		[field: FieldOffset(Offset = "0x10")]
		public RuntimeSoundProperties SoundProperties
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x7B9E414", Offset = "0x7B9E414", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SoundProperties;\n")]
			get;
			[Token(Token = "0x600005A")]
			[Address(RVA = "0x7B9E41C", Offset = "0x7B9E41C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.SoundProperties = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000007")]
		[field: Token(Token = "0x4000063")]
		[field: FieldOffset(Offset = "0x18")]
		public AudioResource AudioResource
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x7B9E424", Offset = "0x7B9E424", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.AudioResource;\n")]
			get;
			[Token(Token = "0x600005C")]
			[Address(RVA = "0x7B9E42C", Offset = "0x7B9E42C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.AudioResource = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x7B9E3A4", Offset = "0x7B9E3A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RuntimeSound()
		{
		}
	}
}

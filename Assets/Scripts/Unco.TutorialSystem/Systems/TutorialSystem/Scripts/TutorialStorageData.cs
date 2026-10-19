using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.TutorialSystem.Scripts
{
	[Serializable]
	[Token(Token = "0x2000012")]
	public class TutorialStorageData
	{
		[Token(Token = "0x1700000E")]
		[field: Token(Token = "0x4000035")]
		[field: FieldOffset(Offset = "0x10")]
		public Dictionary<string, int> Indices
		{
			[Token(Token = "0x6000063")]
			[Address(RVA = "0x81E0FC0", Offset = "0x81E0FC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Indices;\n")]
			get;
			[Token(Token = "0x6000064")]
			[Address(RVA = "0x81E0FC8", Offset = "0x81E0FC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Indices = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x81E0FD0", Offset = "0x81E0FD0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::.ctor(v48);\n\tthis.Indices = v48;\n")]
		public TutorialStorageData()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Indices = dictionary;
		}
	}
}

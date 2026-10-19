using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SettingsSystem.Core
{
	[Serializable]
	[Token(Token = "0x2000007")]
	public class SettingsStorageData
	{
		[Token(Token = "0x17000003")]
		[field: Token(Token = "0x400001B")]
		[field: FieldOffset(Offset = "0x10")]
		public int Flags
		{
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x7AF2240", Offset = "0x7AF2240", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Flags;\n")]
			get;
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x7AF2248", Offset = "0x7AF2248", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Flags = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x7AF2250", Offset = "0x7AF2250", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SettingsStorageData()
		{
		}
	}
}

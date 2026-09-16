using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000004")]
	internal struct CValue
	{
		[Token(Token = "0x4000006")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public string stringValue;

		[Token(Token = "0x4000007")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int intValue;

		[Token(Token = "0x4000008")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public float floatValue;

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x85E198", Offset = "0x85E198", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0x13D401C(v0, other, methodInfo, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
		public unsafe bool Equals(ref CValue other)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13D401C");
			bool result = default(bool);
			return result;
		}
	}
}

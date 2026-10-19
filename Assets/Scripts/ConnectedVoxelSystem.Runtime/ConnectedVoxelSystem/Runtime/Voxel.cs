using AssetRipperInjected;
using Cpp2ILInjected;

namespace ConnectedVoxelSystem.Runtime
{
	[Token(Token = "0x200000E")]
	public struct Voxel<T>
	{
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x0")]
		public bool Filled;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x0")]
		public T Data;

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x6BCF870", Offset = "0x6BCF870", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 1 | data;\n\treturn returnVal1;\n")]
		public static Voxel<T> From(T data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Voxel::From");
			return default;
		}
	}
}

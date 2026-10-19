using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RemoteManagementSystem.ScriptableObjects
{
	[Serializable]
	[Token(Token = "0x2000013")]
	public class CompressionMetadata
	{
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x10")]
		public bool IsCompressed;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x14")]
		public CompressionAlgorithm Algorithm;

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x81CFC50", Offset = "0x81CFC50", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.IsCompressed = 0;\n\tthis.Algorithm = 2;\n\treturn;\n")]
		public CompressionMetadata()
		{
			IsCompressed = false;
			Algorithm = CompressionAlgorithm.Brotli;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x81CFC80", Offset = "0x81CFC80", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.IsCompressed = isCompressed;\n\tthis.Algorithm = algorithm;\n\treturn;\n")]
		public CompressionMetadata(bool isCompressed, CompressionAlgorithm algorithm)
		{
			IsCompressed = isCompressed;
			Algorithm = algorithm;
		}
	}
}

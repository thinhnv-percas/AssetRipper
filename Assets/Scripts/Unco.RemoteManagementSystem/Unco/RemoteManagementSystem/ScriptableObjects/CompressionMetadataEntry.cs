using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RemoteManagementSystem.ScriptableObjects
{
	[Serializable]
	[Token(Token = "0x2000014")]
	public class CompressionMetadataEntry
	{
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x10")]
		public RemoteKey Key;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x18")]
		public CompressionMetadata Metadata;

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x81CFCBC", Offset = "0x81CFCBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public CompressionMetadataEntry()
		{
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x81CFCC4", Offset = "0x81CFCC4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Metadata = metadata;\n\tthis.Key = key;\n\treturn;\n")]
		public CompressionMetadataEntry(RemoteKey key, CompressionMetadata metadata)
		{
			Metadata = metadata;
			Key = key;
		}
	}
}

using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x200002F")]
	public class FileHash
	{
		[CompilerGenerated]
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x10")]
		internal readonly string _003CPath_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x18")]
		internal readonly string _003CHash_003Ek__BackingField;

		[Token(Token = "0x17000021")]
		public string Path
		{
			[CompilerGenerated]
			[Token(Token = "0x600035C")]
			[Address(RVA = "0xBE9BB8", Offset = "0xBE9BB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Path>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Path;
			}
		}

		[Token(Token = "0x17000022")]
		public string Hash
		{
			[CompilerGenerated]
			[Token(Token = "0x600035D")]
			[Address(RVA = "0xBE9BC0", Offset = "0xBE9BC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Hash>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Hash;
			}
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0xBE9BC8", Offset = "0xBE9BC8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Path>k__BackingField = path;\n\tthis.<Hash>k__BackingField = hash;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal FileHash(string path, string hash)
		{
			Path = path;
			Hash = hash;
		}
	}
}

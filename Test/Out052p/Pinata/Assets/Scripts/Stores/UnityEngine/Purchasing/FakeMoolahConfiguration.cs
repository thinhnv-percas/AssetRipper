using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000013")]
	internal class FakeMoolahConfiguration : IMoolahConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x10")]
		private string m_appKey;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x18")]
		private string m_hashKey;

		[Token(Token = "0x17000011")]
		public string appKey
		{
			[Token(Token = "0x6000042")]
			[Address(RVA = "0xC5F048", Offset = "0xC5F048", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_appKey = value;\n\treturn;\n")]
			set
			{
				appKey = value;
			}
		}

		[Token(Token = "0x17000012")]
		public string hashKey
		{
			[Token(Token = "0x6000043")]
			[Address(RVA = "0xC5F050", Offset = "0xC5F050", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_hashKey = value;\n\treturn;\n")]
			set
			{
				hashKey = value;
			}
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0xC5F058", Offset = "0xC5F058", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetMode(CloudMoolahMode mode)
		{
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0xC5F05C", Offset = "0xC5F05C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeMoolahConfiguration()
		{
		}
	}
}

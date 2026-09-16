using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000023")]
	public class FakeGooglePlayStoreExtensions : IGooglePlayStoreExtensions, IStoreExtension, IGooglePlayConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x6000093")]
		[Address(RVA = "0xC5F014", Offset = "0xC5F014", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void RestoreTransactions(Action<bool> callback)
		{
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0xC5F018", Offset = "0xC5F018", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeGooglePlayStoreExtensions()
		{
		}
	}
}

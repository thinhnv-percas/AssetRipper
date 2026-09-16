using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200002A")]
	public class FakeSamsungAppsExtensions : ISamsungAppsExtensions, IStoreExtension, ISamsungAppsConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x60000A2")]
		[Address(RVA = "0xC5F0CC", Offset = "0xC5F0CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetMode(SamsungAppsMode mode)
		{
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0xC5F0D0", Offset = "0xC5F0D0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1ED9D78]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202332C]) = v38;\nL_001F:\n\tSystem.Action`1<System.Boolean>::Invoke(callback, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactions(Action<bool> callback)
		{
			callback(obj: true);
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0xC5F130", Offset = "0xC5F130", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeSamsungAppsExtensions()
		{
		}
	}
}

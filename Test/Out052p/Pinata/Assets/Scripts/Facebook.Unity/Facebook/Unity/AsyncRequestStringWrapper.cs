using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000040")]
	internal class AsyncRequestStringWrapper : IAsyncRequestStringWrapper
	{
		[Token(Token = "0x600015E")]
		[Address(RVA = "0xD1D6F4", Offset = "0xD1D6F4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.AsyncRequestString::Request(url, method, query, callback);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Request(Uri url, HttpMethod method, WWWForm query = null, FacebookDelegate<IGraphResult> callback = null)
		{
			AsyncRequestString.Request(url, method, query, callback);
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0xD1D708", Offset = "0xD1D708", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.AsyncRequestString::Request(url, method, formData, callback);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Request(Uri url, HttpMethod method, IDictionary<string, string> formData = null, FacebookDelegate<IGraphResult> callback = null)
		{
			AsyncRequestString.Request(url, method, formData, callback);
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0xD1D71C", Offset = "0xD1D71C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AsyncRequestStringWrapper()
		{
		}
	}
}

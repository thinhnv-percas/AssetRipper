using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000036")]
	internal class AsyncRequestString : MonoBehaviour
	{
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x18")]
		private Uri url;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x20")]
		private HttpMethod method;

		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x28")]
		private IDictionary<string, string> formData;

		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x30")]
		private WWWForm query;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x38")]
		private FacebookDelegate<IGraphResult> callback;

		[Token(Token = "0x6000128")]
		[Address(RVA = "0xD1C8C4", Offset = "0xD1C8C4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.AsyncRequestString::Request(url, 1, formData, callback);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Post(Uri url, Dictionary<string, string> formData = null, FacebookDelegate<IGraphResult> callback = null)
		{
			Request(url, HttpMethod.POST, formData, callback);
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0xD1C960", Offset = "0xD1C960", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.AsyncRequestString::Request(url, 0, formData, callback);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Get(Uri url, Dictionary<string, string> formData = null, FacebookDelegate<IGraphResult> callback = null)
		{
			Request(url, default(HttpMethod), formData, callback);
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0xD1C978", Offset = "0xD1C978", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EFBEE8]);\n\tv31 = *([v30 @ X8_v6]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, method, query, callback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023B5A]) = v47;\nL_001C:\n\tv51 = Facebook.Unity.ComponentFactory::AddComponent();\n\tv51.url = url;\n\tv51.method = method;\n\tv51.query = query;\n\tv51.callback = callback;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Request(Uri url, HttpMethod method, WWWForm query = null, FacebookDelegate<IGraphResult> callback = null)
		{
			AsyncRequestString asyncRequestString = ComponentFactory.AddComponent<AsyncRequestString>();
			asyncRequestString.url = url;
			asyncRequestString.method = method;
			asyncRequestString.query = query;
			asyncRequestString.callback = callback;
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0xD1C8DC", Offset = "0xD1C8DC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1ED3078]);\n\tv31 = *([v30 @ X8_v6]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, method, formData, callback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023B5B]) = v47;\nL_001C:\n\tv51 = Facebook.Unity.ComponentFactory::AddComponent();\n\tv51.url = url;\n\tv51.method = method;\n\tv51.formData = formData;\n\tv51.callback = callback;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Request(Uri url, HttpMethod method, IDictionary<string, string> formData = null, FacebookDelegate<IGraphResult> callback = null)
		{
			AsyncRequestString asyncRequestString = ComponentFactory.AddComponent<AsyncRequestString>();
			asyncRequestString.url = url;
			asyncRequestString.method = method;
			asyncRequestString.formData = formData;
			asyncRequestString.callback = callback;
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0xD1CA20", Offset = "0xD1CA20", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBC008]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B5C]) = v38;\nL_0016:\n\tv42 = new Facebook.Unity.AsyncRequestString+<Start>d__9();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator Start()
		{
			_003CStart_003Ed__9 _003CStart_003Ed__10 = null;
			_003CStart_003Ed__10._003C_003E1__state = 0;
			_003CStart_003Ed__10._003C_003E4__this = this;
			return _003CStart_003Ed__10;
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0xD1C9F8", Offset = "0xD1C9F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.url = url;\n\treturn this;\n")]
		internal AsyncRequestString SetUrl(Uri url)
		{
			this.url = url;
			return this;
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xD1CA00", Offset = "0xD1CA00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.method = method;\n\treturn this;\n")]
		internal AsyncRequestString SetMethod(HttpMethod method)
		{
			this.method = method;
			return this;
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0xD1CA18", Offset = "0xD1CA18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.formData = formData;\n\treturn this;\n")]
		internal AsyncRequestString SetFormData(IDictionary<string, string> formData)
		{
			this.formData = formData;
			return this;
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0xD1CA08", Offset = "0xD1CA08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.query = query;\n\treturn this;\n")]
		internal AsyncRequestString SetQuery(WWWForm query)
		{
			this.query = query;
			return this;
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0xD1CA10", Offset = "0xD1CA10", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.callback = callback;\n\treturn this;\n")]
		internal AsyncRequestString SetCallback(FacebookDelegate<IGraphResult> callback)
		{
			this.callback = callback;
			return this;
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0xD1CAC0", Offset = "0xD1CAC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AsyncRequestString()
		{
		}
	}
}

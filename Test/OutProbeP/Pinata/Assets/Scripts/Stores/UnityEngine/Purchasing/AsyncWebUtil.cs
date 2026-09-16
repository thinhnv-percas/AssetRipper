using System;
using System.Collections;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x72C6F4", Offset = "0x72C6F4")]
	[Token(Token = "0x200005C")]
	internal class AsyncWebUtil : MonoBehaviour, IAsyncWebUtil
	{
		[Token(Token = "0x6000159")]
		[Address(RVA = "0xC5AFE0", Offset = "0xC5AFE0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EE9580]);\n\tv35 = *([v34 @ X8_v6]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, url, responseHandler, errorHandler, maxTimeoutInSeconds, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20232FA]) = v50;\nL_001E:\n\tv54 = new UnityEngine.WWW();\n\tUnityEngine.WWW::.ctor(v54, url);\n\tv63 = UnityEngine.Purchasing.AsyncWebUtil::Process(this, v54, responseHandler, errorHandler, maxTimeoutInSeconds);\n\tv75 = UnityEngine.MonoBehaviour::StartCoroutine(this, v63);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Get(string url, Action<string> responseHandler, Action<string> errorHandler, int maxTimeoutInSeconds = 5)
		{
			WWW request = new WWW(url);
			IEnumerator routine = Process(request, responseHandler, errorHandler, maxTimeoutInSeconds);
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x600015A")]
		[Address(RVA = "0xC5B124", Offset = "0xC5B124", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1EFFD60]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, url, body, responseHandler, errorHandler, maxTimeoutInSeconds, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20232FB]) = v53;\nL_001E:\n\tv55 = System.Text.Encoding::get_UTF8();\n\tv61 = System.Text.Encoding::GetBytes(v55, body);\n\tv67 = new UnityEngine.WWW();\n\tUnityEngine.WWW::.ctor(v67, url, v61);\n\tv78 = UnityEngine.Purchasing.AsyncWebUtil::Process(this, v67, responseHandler, errorHandler, maxTimeoutInSeconds);\n\tv90 = UnityEngine.MonoBehaviour::StartCoroutine(this, v78);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Post(string url, string body, Action<string> responseHandler, Action<string> errorHandler, int maxTimeoutInSeconds = 5)
		{
			Encoding uTF = Encoding.UTF8;
			byte[] bytes = uTF.GetBytes(body);
			WWW request = new WWW(url, bytes);
			IEnumerator routine = Process(request, responseHandler, errorHandler, maxTimeoutInSeconds);
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0xC5B204", Offset = "0xC5B204", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = UnityEngine.Purchasing.AsyncWebUtil::DoInvoke(this, a, delayInSeconds);\n\tv20 = UnityEngine.MonoBehaviour::StartCoroutine(this, v10);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Schedule(Action a, int delayInSeconds)
		{
			IEnumerator routine = DoInvoke(a, delayInSeconds);
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0xC5B230", Offset = "0xC5B230", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EBC7A0]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, a, delayInSeconds, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20232FC]) = v44;\nL_001A:\n\tv48 = new UnityEngine.Purchasing.AsyncWebUtil+<DoInvoke>d__3();\n\tSystem.Object::.ctor(v48);\n\tv48.<>1__state = 0;\n\tv48.<>4__this = this;\n\tv48.a = a;\n\tv48.delayInSeconds = delayInSeconds;\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator DoInvoke(Action a, int delayInSeconds)
		{
			_003CDoInvoke_003Ed__3 _003CDoInvoke_003Ed__4 = null;
			_003CDoInvoke_003Ed__4._003C_003E1__state = 0;
			_003CDoInvoke_003Ed__4._003C_003E4__this = this;
			_003CDoInvoke_003Ed__4.a = a;
			_003CDoInvoke_003Ed__4.delayInSeconds = delayInSeconds;
			return _003CDoInvoke_003Ed__4;
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0xC5B084", Offset = "0xC5B084", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EA4D70]);\n\tv35 = *([v34 @ X8_v6]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, request, responseHandler, errorHandler, maxTimeoutInSeconds, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20232FD]) = v50;\nL_001E:\n\tv54 = new UnityEngine.Purchasing.AsyncWebUtil+<Process>d__4();\n\tSystem.Object::.ctor(v54);\n\tv54.<>1__state = 0;\n\tv54.<>4__this = this;\n\tv54.request = request;\n\tv54.responseHandler = responseHandler;\n\tv54.errorHandler = errorHandler;\n\tv54.maxTimeoutInSeconds = maxTimeoutInSeconds;\n\treturn v54;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Process(WWW request, Action<string> responseHandler, Action<string> errorHandler, int maxTimeoutInSeconds)
		{
			_003CProcess_003Ed__4 _003CProcess_003Ed__5 = null;
			_003CProcess_003Ed__5._003C_003E1__state = 0;
			_003CProcess_003Ed__5._003C_003E4__this = this;
			_003CProcess_003Ed__5.request = request;
			_003CProcess_003Ed__5.responseHandler = responseHandler;
			_003CProcess_003Ed__5.errorHandler = errorHandler;
			_003CProcess_003Ed__5.maxTimeoutInSeconds = maxTimeoutInSeconds;
			return _003CProcess_003Ed__5;
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0xC5B314", Offset = "0xC5B314", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AsyncWebUtil()
		{
		}
	}
}

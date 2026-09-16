using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000042")]
	internal class FacebookScheduler : MonoBehaviour
	{
		[Token(Token = "0x6000163")]
		[Address(RVA = "0xD2E3F4", Offset = "0xD2E3F4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Facebook.Unity.FacebookScheduler::DelayEvent(this, action, delay);\n\tv20 = UnityEngine.MonoBehaviour::StartCoroutine(this, v10);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Schedule(Action action, long delay)
		{
			IEnumerator routine = DelayEvent(action, delay);
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0xD2E420", Offset = "0xD2E420", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED96E8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, action, delay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2023C2E]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.FacebookScheduler+<DelayEvent>d__1();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.delay = delay;\n\tv45.action = action;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator DelayEvent(Action action, long delay)
		{
			_003CDelayEvent_003Ed__1 _003CDelayEvent_003Ed__2 = null;
			_003CDelayEvent_003Ed__2._003C_003E1__state = 0;
			_003CDelayEvent_003Ed__2.delay = delay;
			_003CDelayEvent_003Ed__2.action = action;
			return _003CDelayEvent_003Ed__2;
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0xD2E4CC", Offset = "0xD2E4CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FacebookScheduler()
		{
		}
	}
}

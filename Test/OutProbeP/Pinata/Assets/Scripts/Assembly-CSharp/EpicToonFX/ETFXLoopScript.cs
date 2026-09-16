using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EpicToonFX
{
	[Token(Token = "0x2000063")]
	public class ETFXLoopScript : MonoBehaviour
	{
		[Token(Token = "0x4000298")]
		[FieldOffset(Offset = "0x18")]
		public GameObject chosenEffect;

		[Token(Token = "0x4000299")]
		[FieldOffset(Offset = "0x20")]
		public float loopTimeLimit;

		[Attribute(Type = typeof(HeaderAttribute), RVA = "0x764CE8", Offset = "0x764CE8")]
		[Token(Token = "0x400029A")]
		[FieldOffset(Offset = "0x24")]
		public bool spawnWithoutLight;

		[Token(Token = "0x400029B")]
		[FieldOffset(Offset = "0x25")]
		public bool spawnWithoutSound;

		[Token(Token = "0x60002AA")]
		[Address(RVA = "0xA04F80", Offset = "0xA04F80", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEpicToonFX.ETFXLoopScript::PlayEffect(this);\n\treturn;\n")]
		private void Start()
		{
			PlayEffect();
		}

		[Token(Token = "0x60002AB")]
		[Address(RVA = "0xA04F84", Offset = "0xA04F84", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF87F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C87]) = v38;\nL_001D:\n\tv48 = UnityEngine.MonoBehaviour::StartCoroutine(this, \"EffectLoop\");\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayEffect()
		{
			Coroutine coroutine = StartCoroutine("EffectLoop");
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7DB97C", Offset = "0x7DB97C")]
		[Token(Token = "0x60002AC")]
		[Address(RVA = "0xA04FD8", Offset = "0xA04FD8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC5B00]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C88]) = v38;\nL_0016:\n\tv42 = new EpicToonFX.ETFXLoopScript+<EffectLoop>d__6();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator EffectLoop()
		{
			_003CEffectLoop_003Ed__6 _003CEffectLoop_003Ed__7 = null;
			_003CEffectLoop_003Ed__7._003C_003E1__state = 0;
			_003CEffectLoop_003Ed__7._003C_003E4__this = this;
			return _003CEffectLoop_003Ed__7;
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0xA05078", Offset = "0xA05078", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.loopTimeLimit = 2f;\n\tthis.spawnWithoutLight = 0x101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ETFXLoopScript()
		{
			loopTimeLimit = 2f;
			spawnWithoutLight = true;
			spawnWithoutSound = true;
		}
	}
}

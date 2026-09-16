using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000005")]
public class DisableAfterTimer : MonoBehaviour
{
	[Token(Token = "0x400000B")]
	[FieldOffset(Offset = "0x18")]
	public float Time;

	[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x74B4A8", Offset = "0x74B4A8")]
	[Token(Token = "0x6000005")]
	[Address(RVA = "0xCBED98", Offset = "0xCBED98", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED1AC8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023712]) = v38;\nL_0016:\n\tv42 = new DisableAfterTimer+<Start>d__1();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IEnumerator Start()
	{
		_003CStart_003Ed__1 _003CStart_003Ed__2 = null;
		_003CStart_003Ed__2._003C_003E1__state = 0;
		_003CStart_003Ed__2._003C_003E4__this = this;
		return _003CStart_003Ed__2;
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0xCBEE38", Offset = "0xCBEE38", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Time = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DisableAfterTimer()
	{
		Time = 1f;
	}
}

using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Token(Token = "0x200002A")]
public class RuntimeRopeGeneratorUse : MonoBehaviour
{
	[Token(Token = "0x40000FF")]
	[FieldOffset(Offset = "0x18")]
	public ObiCollider pendulum;

	[Token(Token = "0x4000100")]
	[FieldOffset(Offset = "0x20")]
	private RuntimeRopeGenerator rg;

	[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7DB554", Offset = "0x7DB554")]
	[Token(Token = "0x60000E1")]
	[Address(RVA = "0xB02AA0", Offset = "0xB02AA0", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF59B8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224C8]) = v38;\nL_0016:\n\tv42 = new RuntimeRopeGeneratorUse+<Start>d__2();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IEnumerator Start()
	{
		_003CStart_003Ed__2 _003CStart_003Ed__3 = null;
		_003CStart_003Ed__3._003C_003E1__state = 0;
		_003CStart_003Ed__3._003C_003E4__this = this;
		return _003CStart_003Ed__3;
	}

	[Token(Token = "0x60000E2")]
	[Address(RVA = "0xB02B40", Offset = "0xB02B40", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Input::GetKey(0x77);\n\tv16 = v14 == 0;\n\tif (v16) goto L_0014;\n\tv19 = UnityEngine.Time::get_deltaTime();\nL_0014:\n\tv28 = UnityEngine.Input::GetKey(0x73);\n\tv30 = v28 == 0;\n\tif (v30) goto L_0022;\n\tv32 = UnityEngine.Time::get_deltaTime();\nL_0022:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			float deltaTime = Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			float deltaTime2 = Time.deltaTime;
		}
	}

	[Token(Token = "0x60000E3")]
	[Address(RVA = "0xB02BA4", Offset = "0xB02BA4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public RuntimeRopeGeneratorUse()
	{
	}
}

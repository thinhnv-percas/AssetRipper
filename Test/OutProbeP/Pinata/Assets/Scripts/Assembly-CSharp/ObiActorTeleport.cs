using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Token(Token = "0x200001F")]
public class ObiActorTeleport : MonoBehaviour
{
	[Token(Token = "0x40000D9")]
	[FieldOffset(Offset = "0x18")]
	public ObiActor actor;

	[Token(Token = "0x60000BA")]
	[Address(RVA = "0x98EA34", Offset = "0x98EA34", Length = "0x48")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Input::get_anyKeyDown();\n\tv13 = v11 == 0;\n\tif (v13) goto L_001A;\n\tv15 = ObiActorTeleport::Teleport(this);\n\tv26 = UnityEngine.MonoBehaviour::StartCoroutine(this, v15);\n\treturn;\nL_001A:\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			IEnumerator routine = Teleport();
			Coroutine coroutine = StartCoroutine(routine);
		}
	}

	[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7DB428", Offset = "0x7DB428")]
	[Token(Token = "0x60000BB")]
	[Address(RVA = "0x98EA7C", Offset = "0x98EA7C", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC19A8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021702]) = v38;\nL_0016:\n\tv42 = new ObiActorTeleport+<Teleport>d__2();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IEnumerator Teleport()
	{
		_003CTeleport_003Ed__2 _003CTeleport_003Ed__3 = null;
		_003CTeleport_003Ed__3._003C_003E1__state = 0;
		_003CTeleport_003Ed__3._003C_003E4__this = this;
		return _003CTeleport_003Ed__3;
	}

	[Token(Token = "0x60000BC")]
	[Address(RVA = "0x98EB1C", Offset = "0x98EB1C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ObiActorTeleport()
	{
	}
}

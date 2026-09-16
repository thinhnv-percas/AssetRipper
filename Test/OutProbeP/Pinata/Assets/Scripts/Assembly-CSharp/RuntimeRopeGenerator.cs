using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Token(Token = "0x2000029")]
public class RuntimeRopeGenerator
{
	[Token(Token = "0x40000FE")]
	[FieldOffset(Offset = "0x10")]
	private ObiSolver solver;

	[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7DB4F0", Offset = "0x7DB4F0")]
	[Token(Token = "0x60000DB")]
	[Address(RVA = "0xB028E8", Offset = "0xB028E8", Length = "0x60")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv17 = *([1EA7600]);\n\tv18 = *([v17 @ X8_v6]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, anchoredTo, methodInfo, v22, v23, v24, v25, v26, attachmentOffset, v0, v2, ropeLength, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20224C5]) = v35;\nL_0016:\n\tv39 = new RuntimeRopeGenerator+<MakeRope>d__1();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IEnumerator MakeRope(Transform anchoredTo, Vector3 attachmentOffset, float ropeLength)
	{
		object obj = 0;
		yield return (int)obj;
	}

	[Token(Token = "0x60000DC")]
	[Address(RVA = "0xB02974", Offset = "0xB02974", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddPendulum(ObiCollider pendulum, Vector3 attachmentOffset)
	{
	}

	[Token(Token = "0x60000DD")]
	[Address(RVA = "0xB02978", Offset = "0xB02978", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public void RemovePendulum()
	{
	}

	[Token(Token = "0x60000DE")]
	[Address(RVA = "0xB0297C", Offset = "0xB0297C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public void ChangeRopeLength(float changeAmount)
	{
	}

	[Token(Token = "0x60000DF")]
	[Address(RVA = "0xB02980", Offset = "0xB02980", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void UpdateTethers()
	{
	}

	[Token(Token = "0x60000E0")]
	[Address(RVA = "0xB02984", Offset = "0xB02984", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public RuntimeRopeGenerator()
	{
	}
}

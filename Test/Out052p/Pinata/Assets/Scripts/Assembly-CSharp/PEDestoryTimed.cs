using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200000A")]
public class PEDestoryTimed : MonoBehaviour
{
	[Token(Token = "0x6000036")]
	[Address(RVA = "0xAFECA8", Offset = "0xAFECA8", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	internal void Start()
	{
	}

	[Token(Token = "0x6000037")]
	[Address(RVA = "0xAFECAC", Offset = "0xAFECAC", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void Update()
	{
	}

	[Token(Token = "0x6000038")]
	[Address(RVA = "0xAFECB0", Offset = "0xAFECB0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PEDestoryTimed()
	{
	}
}

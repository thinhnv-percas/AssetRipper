using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000039")]
public class TestCube : MonoBehaviour
{
	[Token(Token = "0x40000CE")]
	[FieldOffset(Offset = "0x20")]
	private Queue<GameObject> CrewmateList;

	[Token(Token = "0x40000CF")]
	[FieldOffset(Offset = "0x28")]
	private GameObject TopCrewmate;

	[Token(Token = "0x6000178")]
	[Address(RVA = "0xC03324", Offset = "0xC03324", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void Start()
	{
	}

	[Token(Token = "0x6000179")]
	[Address(RVA = "0xC03328", Offset = "0xC03328", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void Update()
	{
	}

	[Token(Token = "0x600017A")]
	[Address(RVA = "0xC0332C", Offset = "0xC0332C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TestCube()
	{
	}
}

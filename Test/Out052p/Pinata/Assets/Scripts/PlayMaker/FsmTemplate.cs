using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000002")]
public class FsmTemplate : ScriptableObject
{
	[SerializeField]
	[Delayed]
	[Token(Token = "0x4000001")]
	[FieldOffset(Offset = "0x18")]
	private string category;

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x20")]
	public Fsm fsm;

	[Token(Token = "0x17000001")]
	public string Category
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x9C7134", Offset = "0x9C7134", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.category;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Category;
		}
		[Token(Token = "0x6000002")]
		[Address(RVA = "0x9C713C", Offset = "0x9C713C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.category = value;\n\treturn;\n")]
		set
		{
			Category = value;
		}
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x9C7144", Offset = "0x9C7144", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\tv2 = this.fsm == 0;\n\tif (v2) goto L_0004;\n\tv0.usedInTemplate = this;\nL_0004:\n\treturn;\n")]
	public void OnEnable()
	{
		Fsm fsm = this.fsm;
		if (this.fsm != null)
		{
			fsm.UsedInTemplate = this;
		}
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x9C7154", Offset = "0x9C7154", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public FsmTemplate()
	{
	}
}

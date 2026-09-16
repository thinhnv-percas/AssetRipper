using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000013")]
public class ItemResources : ItemInventory
{
	[Token(Token = "0x400003A")]
	[FieldOffset(Offset = "0x28")]
	public ObscuredLong value;

	[Token(Token = "0x17000008")]
	public unsafe override long Value
	{
		[Token(Token = "0x6000070")]
		[Address(RVA = "0xBFA084", Offset = "0xBFA084", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.value;\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(&v5 @ V1_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredLong));\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_0013: Expected O, but got Ref
			ObscuredLong obscuredLong = value;
			return (ObscuredLong)(&obscuredLong);
		}
	}

	[Token(Token = "0x6000071")]
	[Address(RVA = "0xBFA0B8", Offset = "0xBFA0B8", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = this.value;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(&v9 @ V1_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredLong));\n\tv19 = v18 + number;\n\tv23 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(v19);\n\tthis.value.fakeValueActive = v23.fakeValueActive;\n\tthis.value.inited = v23.inited;\n\tthis.value = v23.currentCryptoKey;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void Add(long number)
	{
		//IL_0013: Expected O, but got Ref
		//IL_006d: Expected O, but got I8
		ObscuredLong obscuredLong = value;
		long num = (ObscuredLong)(&obscuredLong);
		long num2 = num + number;
		ObscuredLong obscuredLong2 = num2;
		value.fakeValueActive = obscuredLong2.fakeValueActive;
		value.inited = obscuredLong2.inited;
		value = (ObscuredLong)obscuredLong2.currentCryptoKey;
	}

	[Token(Token = "0x6000072")]
	[Address(RVA = "0xBFA12C", Offset = "0xBFA12C", Length = "0x84")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = this.value;\n\tv18 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(&v9 @ V1_v1 (CodeStage.AntiCheat.ObscuredTypes.ObscuredLong));\n\tv19 = v18 - number;\n\tv22 = UnityEngine.Mathf::Max(v19, 0f);\n\tv27 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(v22);\n\tthis.value.fakeValueActive = v27.fakeValueActive;\n\tthis.value.inited = v27.inited;\n\tthis.value = v27.currentCryptoKey;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void Sub(long number)
	{
		//IL_0013: Expected O, but got Ref
		//IL_0045: Expected I8, but got F4
		//IL_0080: Expected O, but got I8
		ObscuredLong obscuredLong = value;
		long num = (ObscuredLong)(&obscuredLong);
		long num2 = num - number;
		float num3 = Mathf.Max(num2, 0f);
		ObscuredLong obscuredLong2 = (long)num3;
		value.fakeValueActive = obscuredLong2.fakeValueActive;
		value.inited = obscuredLong2.inited;
		value = (ObscuredLong)obscuredLong2.currentCryptoKey;
	}

	[Token(Token = "0x6000073")]
	[Address(RVA = "0xBFA1B0", Offset = "0xBFA1B0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ItemResources()
	{
	}
}

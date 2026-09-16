using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000015")]
public class ItemStack : ItemArtifact
{
	[Token(Token = "0x1700000B")]
	public override bool IsCanStack
	{
		[Token(Token = "0x6000078")]
		[Address(RVA = "0xBFA220", Offset = "0xBFA220", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return true;
		}
	}

	[Token(Token = "0x6000079")]
	[Address(RVA = "0xBFA228", Offset = "0xBFA228", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.fragment + number;\n\tthis.fragment = v2;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Add(long number)
	{
		//IL_0019: Expected I4, but got I8
		long num = fragment + number;
		fragment = (int)num;
	}

	[Token(Token = "0x600007A")]
	[Address(RVA = "0xBFA238", Offset = "0xBFA238", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.fragment - number;\n\tthis.fragment = v2;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Sub(long number)
	{
		//IL_0019: Expected I4, but got I8
		long num = fragment - number;
		fragment = (int)num;
	}

	[Token(Token = "0x600007B")]
	[Address(RVA = "0xBFA248", Offset = "0xBFA248", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(1);\n\tthis.level.fakeValueActive = v10.fakeValueActive;\n\tthis.level = v10.currentCryptoKey;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ItemStack()
	{
		//IL_0037: Expected O, but got I4
		base._002Ector();
		ObscuredInt obscuredInt = 1;
		level.fakeValueActive = obscuredInt.fakeValueActive;
		level = (ObscuredInt)obscuredInt.currentCryptoKey;
	}
}

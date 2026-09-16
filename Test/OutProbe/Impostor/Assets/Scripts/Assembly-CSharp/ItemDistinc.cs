using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000016")]
public class ItemDistinc : ItemArtifact
{
	[Token(Token = "0x1700000C")]
	public override bool IsCanStack
	{
		[Token(Token = "0x600007C")]
		[Address(RVA = "0xBFA294", Offset = "0xBFA294", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return false;
		}
	}

	[Token(Token = "0x600007D")]
	[Address(RVA = "0xBFA29C", Offset = "0xBFA29C", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(1);\n\tthis.level.fakeValueActive = v10.fakeValueActive;\n\tthis.level = v10.currentCryptoKey;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ItemDistinc()
	{
		//IL_0037: Expected O, but got I4
		base._002Ector();
		ObscuredInt obscuredInt = 1;
		level.fakeValueActive = obscuredInt.fakeValueActive;
		level = (ObscuredInt)obscuredInt.currentCryptoKey;
	}

	[Token(Token = "0x600007E")]
	[Address(RVA = "0xBFA2E8", Offset = "0xBFA2E8", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Add(long number)
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}

	[Token(Token = "0x600007F")]
	[Address(RVA = "0xBFA320", Offset = "0xBFA320", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void Sub(long number)
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}
}

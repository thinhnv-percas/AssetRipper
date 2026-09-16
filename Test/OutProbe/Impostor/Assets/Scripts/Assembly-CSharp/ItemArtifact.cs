using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000014")]
public abstract class ItemArtifact : ItemInventory
{
	[Token(Token = "0x400003B")]
	[FieldOffset(Offset = "0x28")]
	public int idOnInventory;

	[Token(Token = "0x400003C")]
	[FieldOffset(Offset = "0x2C")]
	public int fragment;

	[Token(Token = "0x400003D")]
	[FieldOffset(Offset = "0x30")]
	public ObscuredInt level;

	[CompilerGenerated]
	[Token(Token = "0x400003E")]
	[FieldOffset(Offset = "0x44")]
	private bool _003CIsCanStack_003Ek__BackingField;

	[Token(Token = "0x17000009")]
	public override long Value
	{
		[Token(Token = "0x6000074")]
		[Address(RVA = "0xBFA1B8", Offset = "0xBFA1B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fragment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_0007: Expected I8, but got I4
			return fragment;
		}
	}

	[Token(Token = "0x1700000A")]
	public virtual bool IsCanStack
	{
		[CompilerGenerated]
		[Token(Token = "0x6000075")]
		[Address(RVA = "0xBFA1C0", Offset = "0xBFA1C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsCanStack>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return IsCanStack;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000076")]
		[Address(RVA = "0xBFA1C8", Offset = "0xBFA1C8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsCanStack>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private set
		{
			_003CIsCanStack_003Ek__BackingField = value;
		}
	}

	[Token(Token = "0x6000077")]
	[Address(RVA = "0xBFA1D4", Offset = "0xBFA1D4", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(1);\n\tthis.level.fakeValueActive = v10.fakeValueActive;\n\tthis.level = v10.currentCryptoKey;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ItemArtifact()
	{
		//IL_0037: Expected O, but got I4
		base._002Ector();
		ObscuredInt obscuredInt = 1;
		level.fakeValueActive = obscuredInt.fakeValueActive;
		level = (ObscuredInt)obscuredInt.currentCryptoKey;
	}
}

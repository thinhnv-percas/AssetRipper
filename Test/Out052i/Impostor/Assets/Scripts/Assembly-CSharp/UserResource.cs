using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000035")]
public abstract class UserResource
{
	[Token(Token = "0x40000C9")]
	[FieldOffset(Offset = "0x10")]
	public TypeResources type;

	[Token(Token = "0x40000CA")]
	[FieldOffset(Offset = "0x18")]
	public Action<int, long> eventChangeValue;

	[Token(Token = "0x600015E")]
	public abstract void SetValue(object valueSet);

	[Token(Token = "0x600015F")]
	public abstract void AddValue(int idAdd, long valueAdd);

	[Token(Token = "0x6000160")]
	public abstract void SubValue(int idSub, long valueSub);

	[Token(Token = "0x6000161")]
	public abstract long GetValue(int id);

	[Token(Token = "0x6000162")]
	[Address(RVA = "0xC03300", Offset = "0xC03300", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.eventChangeValue == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action`2<System.Int32, System.Int64>::Invoke(this.eventChangeValue, id, value);\nL_0007:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void InvokeEventChange(int id, long value)
	{
		if (eventChangeValue != null)
		{
			eventChangeValue(id, value);
		}
	}

	[Token(Token = "0x6000163")]
	[Address(RVA = "0xC0331C", Offset = "0xC0331C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected internal UserResource()
	{
	}
}

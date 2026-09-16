using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000010")]
public struct YandexAppMetricaUserProfileUpdate
{
	[CompilerGenerated]
	[Token(Token = "0x400001F")]
	[FieldOffset(Offset = "0x10")]
	internal string _003CKey_003Ek__BackingField;

	[CompilerGenerated]
	[Token(Token = "0x4000020")]
	[FieldOffset(Offset = "0x18")]
	internal object[] _003CValues_003Ek__BackingField;

	[Token(Token = "0x17000008")]
	public string AttributeName
	{
		[CompilerGenerated]
		[Token(Token = "0x6000063")]
		[Address(RVA = "0x85ED5C", Offset = "0x85ED5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Key>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Key;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000064")]
		[Address(RVA = "0x85ED64", Offset = "0x85ED64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Key>k__BackingField = value;\n\treturn;\n")]
		private set
		{
			Key = value;
		}
	}

	[Token(Token = "0x17000009")]
	public string MethodName
	{
		[CompilerGenerated]
		[Token(Token = "0x6000065")]
		[Address(RVA = "0x85ED6C", Offset = "0x85ED6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Values>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return (string)(object)Values;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000066")]
		[Address(RVA = "0x85ED74", Offset = "0x85ED74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Values>k__BackingField = value;\n\treturn;\n")]
		private set
		{
			Values = (object[])(object)value;
		}
	}

	[Token(Token = "0x1700000A")]
	public string Key
	{
		[CompilerGenerated]
		[Token(Token = "0x6000067")]
		[Address(RVA = "0x85ED7C", Offset = "0x85ED7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaUserProfileUpdate)+20]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaUserProfileUpdate)+20]");
			return (string)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000068")]
		[Address(RVA = "0x85ED84", Offset = "0x85ED84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaUserProfileUpdate)+20]) = value;\n\treturn;\n")]
		private set
		{
		}
	}

	[Token(Token = "0x1700000B")]
	public object[] Values
	{
		[CompilerGenerated]
		[Token(Token = "0x6000069")]
		[Address(RVA = "0x85ED8C", Offset = "0x85ED8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaUserProfileUpdate)+28]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaUserProfileUpdate)+28]");
			return (object[])0;
		}
		[CompilerGenerated]
		[Token(Token = "0x600006A")]
		[Address(RVA = "0x85ED94", Offset = "0x85ED94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaUserProfileUpdate)+28]) = value;\n\treturn;\n")]
		private set
		{
		}
	}

	[Token(Token = "0x600006B")]
	[Address(RVA = "0x85ED9C", Offset = "0x85ED9C", Length = "0x4C14")]
	public YandexAppMetricaUserProfileUpdate(string attributeName, string methodName, string key, params object[] values)
	{
		Key = attributeName;
		Values = (object[])(object)methodName;
	}
}

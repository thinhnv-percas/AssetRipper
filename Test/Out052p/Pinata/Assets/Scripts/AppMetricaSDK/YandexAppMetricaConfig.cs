using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000014")]
public struct YandexAppMetricaConfig
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000020")]
	public struct Coordinates
	{
		[Token(Token = "0x1700003C")]
		public double Latitude
		{
			[CompilerGenerated]
			[Token(Token = "0x600011E")]
			[Address(RVA = "0x85EAC4", Offset = "0x85EAC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig+Coordinates)+10]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected F8, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig+Coordinates)+10]");
				return 0.0;
			}
			[CompilerGenerated]
			[Token(Token = "0x600011F")]
			[Address(RVA = "0x85EACC", Offset = "0x85EACC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig+Coordinates)+10]) = value;\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x1700003D")]
		public double Longitude
		{
			[CompilerGenerated]
			[Token(Token = "0x6000120")]
			[Address(RVA = "0x85EAD4", Offset = "0x85EAD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig+Coordinates)+18]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected F8, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig+Coordinates)+18]");
				return 0.0;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x85EADC", Offset = "0x85EADC", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig+Coordinates)+18]) = value;\n\treturn;\n\t// 2 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xD93;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 12 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xD93;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
			}
		}
	}

	[CompilerGenerated]
	[Token(Token = "0x4000025")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
	internal Coordinates? _003CLocation_003Ek__BackingField;

	[CompilerGenerated]
	[Token(Token = "0x400002C")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
	internal YandexAppMetricaPreloadInfo? _003CPreloadInfo_003Ek__BackingField;

	[Token(Token = "0x1700000E")]
	public string ApiKey
	{
		[CompilerGenerated]
		[Token(Token = "0x600008B")]
		[Address(RVA = "0x85E9BC", Offset = "0x85E9BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Location>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return (string)Location;
		}
		[CompilerGenerated]
		[Token(Token = "0x600008C")]
		[Address(RVA = "0x85E9C4", Offset = "0x85E9C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Location>k__BackingField = value;\n\treturn;\n")]
		private set
		{
			Location = (Coordinates?)value;
		}
	}

	[Token(Token = "0x1700000F")]
	public string AppVersion
	{
		[CompilerGenerated]
		[Token(Token = "0x600008D")]
		[Address(RVA = "0x85E9CC", Offset = "0x85E9CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig)+18]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+18]");
			return (string)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x600008E")]
		[Address(RVA = "0x85E9D4", Offset = "0x85E9D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig)+18]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x17000010")]
	public unsafe Coordinates? Location
	{
		[CompilerGenerated]
		[Token(Token = "0x600008F")]
		[Address(RVA = "0x85E9DC", Offset = "0x85E9DC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([v2 @ X8+10]) = this.<CrashReporting>k__BackingField;\n\t*([v2 @ X8]) = *([this @ X0 (YandexAppMetricaConfig)+20]);\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_001a: Expected O, but got I
			//IL_001c: Expected O, but got Ref
			_ = CrashReporting;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+20]");
			object obj = 0;
			return (Coordinates?)(object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
		}
		[CompilerGenerated]
		[Token(Token = "0x6000090")]
		[Address(RVA = "0x85E9F0", Offset = "0x85E9F0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CrashReporting>k__BackingField = value.value;\n\t*([this @ X0 (YandexAppMetricaConfig)+20]) = *([value @ X1 (System.Nullable`1<YandexAppMetricaConfig+Coordinates>)]);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			CrashReporting = (bool?)value.value;
		}
	}

	[Token(Token = "0x17000011")]
	public int? SessionTimeout
	{
		[CompilerGenerated]
		[Token(Token = "0x6000091")]
		[Address(RVA = "0x85EA04", Offset = "0x85EA04", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<HandleFirstActivationAsUpdate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return (int?)HandleFirstActivationAsUpdate;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000092")]
		[Address(RVA = "0x85EA0C", Offset = "0x85EA0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<HandleFirstActivationAsUpdate>k__BackingField = value;\n\treturn;\n")]
		set
		{
			HandleFirstActivationAsUpdate = (bool?)value;
		}
	}

	[Token(Token = "0x17000012")]
	public bool? CrashReporting
	{
		[CompilerGenerated]
		[Token(Token = "0x6000093")]
		[Address(RVA = "0x85EA14", Offset = "0x85EA14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<PreloadInfo>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return (bool?)PreloadInfo;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000094")]
		[Address(RVA = "0x85EA1C", Offset = "0x85EA1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<PreloadInfo>k__BackingField = value;\n\treturn;\n")]
		set
		{
			PreloadInfo = (YandexAppMetricaPreloadInfo?)value;
		}
	}

	[Token(Token = "0x17000013")]
	public bool? LocationTracking
	{
		[CompilerGenerated]
		[Token(Token = "0x6000095")]
		[Address(RVA = "0x85EA24", Offset = "0x85EA24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig)+42]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+42]");
			return (bool?)(object)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000096")]
		[Address(RVA = "0x85EA2C", Offset = "0x85EA2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig)+42]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x17000014")]
	public bool? Logs
	{
		[CompilerGenerated]
		[Token(Token = "0x6000097")]
		[Address(RVA = "0x85EA34", Offset = "0x85EA34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig)+44]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+44]");
			return (bool?)(object)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x6000098")]
		[Address(RVA = "0x85EA3C", Offset = "0x85EA3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig)+44]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x17000015")]
	public bool? InstalledAppCollecting
	{
		[CompilerGenerated]
		[Token(Token = "0x6000099")]
		[Address(RVA = "0x85EA44", Offset = "0x85EA44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig)+46]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+46]");
			return (bool?)(object)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x600009A")]
		[Address(RVA = "0x85EA4C", Offset = "0x85EA4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig)+46]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x17000016")]
	public bool? HandleFirstActivationAsUpdate
	{
		[CompilerGenerated]
		[Token(Token = "0x600009B")]
		[Address(RVA = "0x85EA54", Offset = "0x85EA54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig)+48]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+48]");
			return (bool?)(object)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x600009C")]
		[Address(RVA = "0x85EA5C", Offset = "0x85EA5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig)+48]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x17000017")]
	public unsafe YandexAppMetricaPreloadInfo? PreloadInfo
	{
		[CompilerGenerated]
		[Token(Token = "0x600009D")]
		[Address(RVA = "0x85EA64", Offset = "0x85EA64", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([v2 @ X8+10]) = *([this @ X0 (YandexAppMetricaConfig)+60]);\n\t*([v2 @ X8]) = *([this @ X0 (YandexAppMetricaConfig)+50]);\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_001d: Expected O, but got I
			//IL_001f: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+50]");
			object obj = 0;
			return (YandexAppMetricaPreloadInfo?)(object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
		}
		[CompilerGenerated]
		[Token(Token = "0x600009E")]
		[Address(RVA = "0x85EA78", Offset = "0x85EA78", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig)+60]) = value.value;\n\t*([this @ X0 (YandexAppMetricaConfig)+50]) = *([value @ X1 (System.Nullable`1<YandexAppMetricaPreloadInfo>)]);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			_ = value.value;
		}
	}

	[Token(Token = "0x17000018")]
	public bool? StatisticsSending
	{
		[CompilerGenerated]
		[Token(Token = "0x600009F")]
		[Address(RVA = "0x85EA8C", Offset = "0x85EA8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaConfig)+68]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaConfig)+68]");
			return (bool?)(object)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x85EA94", Offset = "0x85EA94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaConfig)+68]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x60000A1")]
	[Address(RVA = "0x85EA9C", Offset = "0x85EA9C", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Location>k__BackingField = apiKey;\n\t*([this @ X0 (YandexAppMetricaConfig)+60]) = 0;\n\t*([this @ X0 (YandexAppMetricaConfig)+68]) = 0;\n\t*([this @ X0 (YandexAppMetricaConfig)+48]) = 0;\n\t*([this @ X0 (YandexAppMetricaConfig)+50]) = 0;\n\tthis.<HandleFirstActivationAsUpdate>k__BackingField = 0;\n\tthis.<SessionTimeout>k__BackingField = 0;\n\t*([this @ X0 (YandexAppMetricaConfig)+18]) = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaConfig(string apiKey)
	{
		Location = (Coordinates?)apiKey;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		HandleFirstActivationAsUpdate = null;
		HandleFirstActivationAsUpdate = (bool?)(int?)null;
		_ = 0;
	}
}

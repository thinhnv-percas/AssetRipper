using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000021")]
	public class AdLoaderClientArgs
	{
		[Token(Token = "0x17000005")]
		public string AdUnitId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000161")]
			[Address(RVA = "0x134F890", Offset = "0x134F890", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdUnitId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdUnitId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000162")]
			[Address(RVA = "0x134F898", Offset = "0x134F898", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdUnitId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				AdUnitId = value;
			}
		}

		[Token(Token = "0x17000006")]
		public HashSet<NativeAdType> AdTypes
		{
			[CompilerGenerated]
			[Token(Token = "0x6000163")]
			[Address(RVA = "0x134F8A0", Offset = "0x134F8A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdTypes>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdTypes;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000164")]
			[Address(RVA = "0x134F8A8", Offset = "0x134F8A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdTypes>k__BackingField = value;\n\treturn;\n")]
			set
			{
				AdTypes = value;
			}
		}

		[Token(Token = "0x17000007")]
		[field: Token(Token = "0x400008E")]
		[field: FieldOffset(Offset = "0x20")]
		internal Dictionary<string, bool> TemplateIds
		{
			[Token(Token = "0x6000165")]
			[Address(RVA = "0x134F8B0", Offset = "0x134F8B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TemplateIds>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000166")]
			[Address(RVA = "0x134F8B8", Offset = "0x134F8B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TemplateIds>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x134F8C0", Offset = "0x134F8C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdLoaderClientArgs()
		{
		}
	}
}

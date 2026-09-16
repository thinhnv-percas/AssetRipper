using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000036")]
	public class AdapterStatus
	{
		[CompilerGenerated]
		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x10")]
		internal AdapterState _003CInitializationState_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x18")]
		internal string _003CDescription_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x20")]
		internal int _003CLatency_003Ek__BackingField;

		[Token(Token = "0x17000013")]
		public AdapterState InitializationState
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A4")]
			[Address(RVA = "0x135748C", Offset = "0x135748C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<InitializationState>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return InitializationState;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A5")]
			[Address(RVA = "0x1357494", Offset = "0x1357494", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<InitializationState>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CInitializationState_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000014")]
		public string Description
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A6")]
			[Address(RVA = "0x135749C", Offset = "0x135749C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Description>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Description;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A7")]
			[Address(RVA = "0x13574A4", Offset = "0x13574A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Description>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CDescription_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000015")]
		public int Latency
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A8")]
			[Address(RVA = "0x13574AC", Offset = "0x13574AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Latency>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Latency;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A9")]
			[Address(RVA = "0x13574B4", Offset = "0x13574B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Latency>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLatency_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60002AA")]
		[Address(RVA = "0x1340858", Offset = "0x1340858", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<InitializationState>k__BackingField = state;\n\tthis.<Description>k__BackingField = description;\n\tthis.<Latency>k__BackingField = latency;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AdapterStatus(AdapterState state, string description, int latency)
		{
			InitializationState = state;
			Description = description;
			Latency = latency;
		}
	}
}

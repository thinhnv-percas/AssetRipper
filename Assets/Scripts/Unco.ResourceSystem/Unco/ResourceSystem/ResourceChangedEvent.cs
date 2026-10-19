using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000014")]
	public class ResourceChangedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x30")]
		internal readonly TransactionContext _003CContext_003Ek__BackingField;

		[Token(Token = "0x17000005")]
		[field: Token(Token = "0x4000020")]
		[field: FieldOffset(Offset = "0x10")]
		public ResourceType ResourceType
		{
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x81D26B8", Offset = "0x81D26B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ResourceType;\n")]
			get;
		}

		[Token(Token = "0x17000006")]
		[field: Token(Token = "0x4000021")]
		[field: FieldOffset(Offset = "0x18")]
		public double PreviousAmount
		{
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x81D26C0", Offset = "0x81D26C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.PreviousAmount;\n")]
			get;
		}

		[Token(Token = "0x17000007")]
		[field: Token(Token = "0x4000022")]
		[field: FieldOffset(Offset = "0x20")]
		public double NewAmount
		{
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x81D26C8", Offset = "0x81D26C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.NewAmount;\n")]
			get;
		}

		[Token(Token = "0x17000008")]
		[field: Token(Token = "0x4000023")]
		[field: FieldOffset(Offset = "0x28")]
		public double Delta
		{
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x81D26D0", Offset = "0x81D26D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Delta;\n")]
			get;
		}

		[Token(Token = "0x17000009")]
		public TransactionContext Context
		{
			[CompilerGenerated]
			[Token(Token = "0x6000047")]
			[Address(RVA = "0x81D26D8", Offset = "0x81D26D8", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.Source = this.<Context>k__BackingField;\n\treturnBuffer.SuppressEvents = this.<Context>k__BackingField.SuppressEvents;\n\treturn returnBuffer;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ResourceChangedEvent::get_Context");
				return default;
			}
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81D21AC", Offset = "0x81D21AC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.ResourceType = type;\n\tthis.PreviousAmount = prev;\n\tthis.NewAmount = newAmt;\n\tv29 = newAmt - prev;\n\tthis.Delta = v29;\n\tthis.<Context>k__BackingField.SuppressEvents = ctx.SuppressEvents;\n\tthis.<Context>k__BackingField = ctx.Source;\n\treturn;\n")]
		public ResourceChangedEvent(ResourceType type, double prev, double newAmt, TransactionContext ctx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceChangedEvent::.ctor");
		}
	}
}

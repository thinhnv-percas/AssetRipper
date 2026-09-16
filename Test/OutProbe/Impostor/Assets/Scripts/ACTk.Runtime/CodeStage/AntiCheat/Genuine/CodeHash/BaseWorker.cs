using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x2000035")]
	internal abstract class BaseWorker
	{
		[CompilerGenerated]
		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x10")]
		private HashGeneratorResult _003CResult_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x18")]
		internal bool _003CIsBusy_003Ek__BackingField;

		[Token(Token = "0x1700002A")]
		public HashGeneratorResult Result
		{
			[CompilerGenerated]
			[Token(Token = "0x6000376")]
			[Address(RVA = "0xBEADE4", Offset = "0xBEADE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Result>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Result;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000377")]
			[Address(RVA = "0xBEADEC", Offset = "0xBEADEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Result>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CResult_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002B")]
		public bool IsBusy
		{
			[CompilerGenerated]
			[Token(Token = "0x6000378")]
			[Address(RVA = "0xBEADF4", Offset = "0xBEADF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsBusy>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsBusy;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000379")]
			[Address(RVA = "0xBEADFC", Offset = "0xBEADFC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsBusy>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CIsBusy_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600037A")]
		[Address(RVA = "0xBEAE08", Offset = "0xBEAE08", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsBusy>k__BackingField = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Execute()
		{
			IsBusy = true;
		}

		[Token(Token = "0x600037B")]
		[Address(RVA = "0xBEAE14", Offset = "0xBEAE14", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Result>k__BackingField = result;\n\tthis.<IsBusy>k__BackingField = 0;\n\treturn;\n")]
		protected internal virtual void Complete(HashGeneratorResult result)
		{
			Result = result;
			IsBusy = false;
		}

		[Token(Token = "0x600037C")]
		[Address(RVA = "0xBEAE20", Offset = "0xBEAE20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseWorker()
		{
		}
	}
}

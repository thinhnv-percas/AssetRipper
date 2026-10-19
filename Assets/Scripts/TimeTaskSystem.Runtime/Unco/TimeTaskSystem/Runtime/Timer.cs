using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.TimeTaskSystem.Runtime
{
	[Token(Token = "0x2000008")]
	internal struct Timer
	{
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x0")]
		public float Elapsed;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x4")]
		public float Duration;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x8")]
		public float UpdateInterval;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0xC")]
		public float LastIntervalTime;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x10")]
		public TimerFlags Flags;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x14")]
		public int Generation;

		[Token(Token = "0x17000001")]
		public bool IsActive
		{
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x8193430", Offset = "0x8193430", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.Flags & 1;\n\treturn returnVal1;\n")]
			get
			{
				return (byte)(Flags & TimerFlags.Active) != 0;
			}
		}

		[Token(Token = "0x17000002")]
		public bool IsPaused
		{
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x819343C", Offset = "0x819343C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Flags >> 1;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n")]
			get
			{
				int num = (int)Flags >> 1;
				return (byte)(num & 1) != 0;
			}
		}

		[Token(Token = "0x17000003")]
		public bool HasInterval
		{
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x8193448", Offset = "0x8193448", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Flags >> 2;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n")]
			get
			{
				int num = (int)Flags >> 2;
				return (byte)(num & 1) != 0;
			}
		}

		[Token(Token = "0x17000004")]
		public bool CountsDown
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x8193454", Offset = "0x8193454", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Flags >> 3;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n")]
			get
			{
				int num = (int)Flags >> 3;
				return (byte)(num & 1) != 0;
			}
		}

		[Token(Token = "0x17000005")]
		public bool ShouldLoop
		{
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x8193460", Offset = "0x8193460", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Flags >> 4;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n")]
			get
			{
				int num = (int)Flags >> 4;
				return (byte)(num & 1) != 0;
			}
		}
	}
}

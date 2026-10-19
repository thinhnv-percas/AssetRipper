using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x200000B")]
	public class AlwaysTrueCondition : ReactiveCondition
	{
		[Token(Token = "0x600001C")]
		[Address(RVA = "0x81AE2B8", Offset = "0x81AE2B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InnerDispose()
		{
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x81AE2BC", Offset = "0x81AE2BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
		protected internal override bool InnerIsConditionMet()
		{
			return true;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x81AE2C4", Offset = "0x81AE2C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected internal override void Subscribe()
		{
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x81AD164", Offset = "0x81AD164", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public AlwaysTrueCondition()
		{
			_lastState = -1;
		}
	}
}

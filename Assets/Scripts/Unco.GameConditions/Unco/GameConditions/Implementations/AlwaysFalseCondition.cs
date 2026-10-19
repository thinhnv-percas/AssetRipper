using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x200000A")]
	public class AlwaysFalseCondition : ReactiveCondition
	{
		[Token(Token = "0x6000018")]
		[Address(RVA = "0x81AE298", Offset = "0x81AE298", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void InnerDispose()
		{
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x81AE29C", Offset = "0x81AE29C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		protected internal override bool InnerIsConditionMet()
		{
			return false;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x81AE2A4", Offset = "0x81AE2A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected internal override void Subscribe()
		{
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x81AD174", Offset = "0x81AD174", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public AlwaysFalseCondition()
		{
			_lastState = -1;
		}
	}
}

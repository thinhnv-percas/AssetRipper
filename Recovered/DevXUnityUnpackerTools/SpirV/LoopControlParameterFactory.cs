using System.Collections.Generic;

namespace SpirV
{
	public class LoopControlParameterFactory : ParameterFactory
	{
		public class DependencyLengthParameter : Parameter
		{
			internal static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public override Parameter CreateParameter(object value)
		{
			LoopControl loopControl = (LoopControl)value;
			if (loopControl == LoopControl.DependencyLength)
			{
				return new DependencyLengthParameter();
			}
			return null;
		}
	}
}

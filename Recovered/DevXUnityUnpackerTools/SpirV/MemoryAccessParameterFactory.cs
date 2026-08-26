using System.Collections.Generic;

namespace SpirV
{
	public class MemoryAccessParameterFactory : ParameterFactory
	{
		public class AlignedParameter : Parameter
		{
			internal static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public override Parameter CreateParameter(object value)
		{
			MemoryAccess memoryAccess = (MemoryAccess)value;
			if (memoryAccess == MemoryAccess.Aligned)
			{
				return new AlignedParameter();
			}
			return null;
		}
	}
}

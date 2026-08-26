using System.Collections.Generic;

namespace SpirV
{
	public class ExecutionModeParameterFactory : ParameterFactory
	{
		public class InvocationsParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class LocalSizeParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger(),
				new LiteralInteger(),
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class LocalSizeHintParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger(),
				new LiteralInteger(),
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class OutputVerticesParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class VecTypeHintParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class SubgroupSizeParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class SubgroupsPerWorkgroupParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class SubgroupsPerWorkgroupIdParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class LocalSizeIdParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef(),
				new IdRef(),
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class LocalSizeHintIdParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public override Parameter CreateParameter(object value)
		{
			switch ((ExecutionMode)value)
			{
			case ExecutionMode.Invocations:
				return new InvocationsParameter();
			case ExecutionMode.LocalSize:
				return new LocalSizeParameter();
			case ExecutionMode.LocalSizeHint:
				return new LocalSizeHintParameter();
			case ExecutionMode.OutputVertices:
				return new OutputVerticesParameter();
			case ExecutionMode.VecTypeHint:
				return new VecTypeHintParameter();
			case ExecutionMode.SubgroupSize:
				return new SubgroupSizeParameter();
			case ExecutionMode.SubgroupsPerWorkgroup:
				return new SubgroupsPerWorkgroupParameter();
			case ExecutionMode.SubgroupsPerWorkgroupId:
				return new SubgroupsPerWorkgroupIdParameter();
			case ExecutionMode.LocalSizeId:
				return new LocalSizeIdParameter();
			case ExecutionMode.LocalSizeHintId:
				return new LocalSizeHintIdParameter();
			default:
				return null;
			}
		}
	}
}

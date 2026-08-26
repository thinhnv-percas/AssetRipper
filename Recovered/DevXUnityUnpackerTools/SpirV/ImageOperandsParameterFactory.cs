using System.Collections.Generic;

namespace SpirV
{
	public class ImageOperandsParameterFactory : ParameterFactory
	{
		public class BiasParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class LodParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class GradParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef(),
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class ConstOffsetParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class OffsetParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class ConstOffsetsParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class SampleParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class MinLodParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public override Parameter CreateParameter(object value)
		{
			switch ((ImageOperands)value)
			{
			case ImageOperands.Bias:
				return new BiasParameter();
			case ImageOperands.Lod:
				return new LodParameter();
			case ImageOperands.Grad:
				return new GradParameter();
			case ImageOperands.ConstOffset:
				return new ConstOffsetParameter();
			case ImageOperands.Offset:
				return new OffsetParameter();
			case ImageOperands.ConstOffsets:
				return new ConstOffsetsParameter();
			case ImageOperands.Sample:
				return new SampleParameter();
			case ImageOperands.MinLod:
				return new MinLodParameter();
			default:
				return null;
			}
		}
	}
}

using System.Collections.Generic;

namespace SpirV
{
	public class DecorationParameterFactory : ParameterFactory
	{
		public class SpecIdParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class ArrayStrideParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class MatrixStrideParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class BuiltInParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new EnumType<BuiltIn>()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class StreamParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class LocationParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class ComponentParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class IndexParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class BindingParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class DescriptorSetParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class OffsetParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class XfbBufferParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class XfbStrideParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class FuncParamAttrParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new EnumType<FunctionParameterAttribute>()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class FPRoundingModeParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new EnumType<FPRoundingMode>()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class FPFastMathModeParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new EnumType<FPFastMathMode>()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class LinkageAttributesParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralString(),
				new EnumType<LinkageType>()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class InputAttachmentIndexParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class AlignmentParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class MaxByteOffsetParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class AlignmentIdParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class MaxByteOffsetIdParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new IdRef()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public class SecondaryViewportRelativeNVParameter : Parameter
		{
			private static readonly List<OperandType> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = new List<OperandType>
			{
				new LiteralInteger()
			};

			public override IList<OperandType> OperandTypes => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
		}

		public override Parameter CreateParameter(object value)
		{
			switch ((Decoration)value)
			{
			case Decoration.SpecId:
				return new SpecIdParameter();
			case Decoration.ArrayStride:
				return new ArrayStrideParameter();
			case Decoration.MatrixStride:
				return new MatrixStrideParameter();
			case Decoration.BuiltIn:
				return new BuiltInParameter();
			case Decoration.Stream:
				return new StreamParameter();
			case Decoration.Location:
				return new LocationParameter();
			case Decoration.Component:
				return new ComponentParameter();
			case Decoration.Index:
				return new IndexParameter();
			case Decoration.Binding:
				return new BindingParameter();
			case Decoration.DescriptorSet:
				return new DescriptorSetParameter();
			case Decoration.Offset:
				return new OffsetParameter();
			case Decoration.XfbBuffer:
				return new XfbBufferParameter();
			case Decoration.XfbStride:
				return new XfbStrideParameter();
			case Decoration.FuncParamAttr:
				return new FuncParamAttrParameter();
			case Decoration.FPRoundingMode:
				return new FPRoundingModeParameter();
			case Decoration.FPFastMathMode:
				return new FPFastMathModeParameter();
			case Decoration.LinkageAttributes:
				return new LinkageAttributesParameter();
			case Decoration.InputAttachmentIndex:
				return new InputAttachmentIndexParameter();
			case Decoration.Alignment:
				return new AlignmentParameter();
			case Decoration.MaxByteOffset:
				return new MaxByteOffsetParameter();
			case Decoration.AlignmentId:
				return new AlignmentIdParameter();
			case Decoration.MaxByteOffsetId:
				return new MaxByteOffsetIdParameter();
			case Decoration.SecondaryViewportRelativeNV:
				return new SecondaryViewportRelativeNVParameter();
			default:
				return null;
			}
		}
	}
}

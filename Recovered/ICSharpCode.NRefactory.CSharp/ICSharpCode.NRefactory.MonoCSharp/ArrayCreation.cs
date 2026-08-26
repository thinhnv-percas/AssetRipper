using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class ArrayCreation : Expression
	{
		private FullNamedExpression requested_base_type;

		private ArrayInitializer initializers;

		protected List<Expression> arguments;

		protected TypeSpec array_element_type;

		private int num_arguments;

		protected int dimensions;

		protected readonly ComposedTypeSpecifier rank;

		private Expression first_emit;

		private LocalTemporary first_emit_temp;

		protected List<Expression> array_data;

		private Dictionary<int, int> bounds;

		public ComposedTypeSpecifier Rank => rank;

		public FullNamedExpression TypeExpression => requested_base_type;

		public ArrayInitializer Initializers => initializers;

		public List<Expression> Arguments => arguments;

		public ArrayCreation(FullNamedExpression requested_base_type, List<Expression> exprs, ComposedTypeSpecifier rank, ArrayInitializer initializers, Location l)
			: this(requested_base_type, rank, initializers, l)
		{
			arguments = exprs;
			num_arguments = arguments.Count;
		}

		public ArrayCreation(FullNamedExpression requested_base_type, ComposedTypeSpecifier rank, ArrayInitializer initializers, Location loc)
		{
			this.requested_base_type = requested_base_type;
			this.rank = rank;
			this.initializers = initializers;
			base.loc = loc;
			if (rank != null)
			{
				num_arguments = rank.Dimension;
			}
		}

		public ArrayCreation(FullNamedExpression requested_base_type, ArrayInitializer initializers, Location loc)
			: this(requested_base_type, ComposedTypeSpecifier.SingleDimension, initializers, loc)
		{
		}

		public ArrayCreation(FullNamedExpression requested_base_type, ArrayInitializer initializers)
			: this(requested_base_type, null, initializers, initializers.Location)
		{
		}

		private bool CheckIndices(ResolveContext ec, ArrayInitializer probe, int idx, bool specified_dims, int child_bounds)
		{
			if (initializers != null && bounds == null)
			{
				array_data = new List<Expression>(probe.Count);
				bounds = new Dictionary<int, int>();
			}
			if (specified_dims)
			{
				Expression expression = arguments[idx];
				expression = expression.Resolve(ec);
				if (expression == null)
				{
					return false;
				}
				expression = ConvertExpressionToArrayIndex(ec, expression);
				if (expression == null)
				{
					return false;
				}
				arguments[idx] = expression;
				if (initializers != null)
				{
					Constant constant = expression as Constant;
					if (constant == null && expression is ArrayIndexCast)
					{
						constant = (((ArrayIndexCast)expression).Child as Constant);
					}
					if (constant == null)
					{
						ec.Report.Error(150, expression.Location, "A constant value is expected");
						return false;
					}
					int num;
					try
					{
						num = System.Convert.ToInt32(constant.GetValue());
					}
					catch
					{
						ec.Report.Error(150, expression.Location, "A constant value is expected");
						return false;
					}
					if (num != probe.Count)
					{
						ec.Report.Error(847, loc, "An array initializer of length `{0}' was expected", num.ToString());
						return false;
					}
					bounds[idx] = num;
				}
			}
			if (initializers == null)
			{
				return true;
			}
			for (int i = 0; i < probe.Count; i++)
			{
				Expression expression2 = probe[i];
				if (expression2 is ArrayInitializer)
				{
					ArrayInitializer arrayInitializer = expression2 as ArrayInitializer;
					if (idx + 1 >= dimensions)
					{
						ec.Report.Error(623, loc, "Array initializers can only be used in a variable or field initializer. Try using a new expression instead");
						return false;
					}
					if (!bounds.ContainsKey(idx + 1))
					{
						bounds[idx + 1] = arrayInitializer.Count;
					}
					if (bounds[idx + 1] != arrayInitializer.Count)
					{
						ec.Report.Error(847, arrayInitializer.Location, "An array initializer of length `{0}' was expected", bounds[idx + 1].ToString());
						return false;
					}
					if (!CheckIndices(ec, arrayInitializer, idx + 1, specified_dims, child_bounds - 1))
					{
						return false;
					}
				}
				else if (child_bounds > 1)
				{
					ec.Report.Error(846, expression2.Location, "A nested array initializer was expected");
				}
				else
				{
					Expression expression3 = ResolveArrayElement(ec, expression2);
					if (expression3 != null)
					{
						array_data.Add(expression3);
					}
				}
			}
			return true;
		}

		public override bool ContainsEmitWithAwait()
		{
			foreach (Expression argument in arguments)
			{
				if (argument.ContainsEmitWithAwait())
				{
					return true;
				}
			}
			return InitializersContainAwait();
		}

		public override Expression CreateExpressionTree(ResolveContext ec)
		{
			Arguments arguments;
			if (array_data == null)
			{
				arguments = new Arguments(this.arguments.Count + 1);
				arguments.Add(new Argument(new TypeOf(array_element_type, loc)));
				foreach (Expression argument in this.arguments)
				{
					arguments.Add(new Argument(argument.CreateExpressionTree(ec)));
				}
				return CreateExpressionFactoryCall(ec, "NewArrayBounds", arguments);
			}
			if (dimensions > 1)
			{
				ec.Report.Error(838, loc, "An expression tree cannot contain a multidimensional array initializer");
				return null;
			}
			arguments = new Arguments((array_data == null) ? 1 : (array_data.Count + 1));
			arguments.Add(new Argument(new TypeOf(array_element_type, loc)));
			if (array_data != null)
			{
				for (int i = 0; i < array_data.Count; i++)
				{
					Expression expression = array_data[i];
					arguments.Add(new Argument(expression.CreateExpressionTree(ec)));
				}
			}
			return CreateExpressionFactoryCall(ec, "NewArrayInit", arguments);
		}

		private void UpdateIndices(ResolveContext rc)
		{
			int num = 0;
			ArrayInitializer arrayInitializer = initializers;
			while (arrayInitializer != null)
			{
				Expression item = new IntConstant(rc.BuiltinTypes, arrayInitializer.Count, Location.Null);
				arguments.Add(item);
				bounds[num++] = arrayInitializer.Count;
				if (arrayInitializer.Count > 0 && arrayInitializer[0] is ArrayInitializer)
				{
					arrayInitializer = (ArrayInitializer)arrayInitializer[0];
				}
				else if (dimensions <= num)
				{
					break;
				}
			}
		}

		protected override void Error_NegativeArrayIndex(ResolveContext ec, Location loc)
		{
			ec.Report.Error(248, loc, "Cannot create an array with a negative size");
		}

		public override void FlowAnalysis(FlowAnalysisContext fc)
		{
			foreach (Expression argument in arguments)
			{
				argument.FlowAnalysis(fc);
			}
			if (array_data != null)
			{
				foreach (Expression array_datum in array_data)
				{
					array_datum.FlowAnalysis(fc);
				}
			}
		}

		private bool InitializersContainAwait()
		{
			if (array_data == null)
			{
				return false;
			}
			foreach (Expression array_datum in array_data)
			{
				if (array_datum.ContainsEmitWithAwait())
				{
					return true;
				}
			}
			return false;
		}

		protected virtual Expression ResolveArrayElement(ResolveContext ec, Expression element)
		{
			element = element.Resolve(ec);
			if (element == null)
			{
				return null;
			}
			if (element is CompoundAssign.TargetExpression)
			{
				if (first_emit != null)
				{
					throw new InternalErrorException("Can only handle one mutator at a time");
				}
				first_emit = element;
				element = (first_emit_temp = new LocalTemporary(element.Type));
			}
			return Convert.ImplicitConversionRequired(ec, element, array_element_type, loc);
		}

		protected bool ResolveInitializers(ResolveContext ec)
		{
			if (arguments != null)
			{
				bool flag = true;
				for (int i = 0; i < arguments.Count; i++)
				{
					flag &= CheckIndices(ec, initializers, i, specified_dims: true, dimensions);
					if (initializers != null)
					{
						break;
					}
				}
				return flag;
			}
			arguments = new List<Expression>();
			if (!CheckIndices(ec, initializers, 0, specified_dims: false, dimensions))
			{
				return false;
			}
			UpdateIndices(ec);
			return true;
		}

		private bool ResolveArrayType(ResolveContext ec)
		{
			FullNamedExpression fullNamedExpression = (num_arguments <= 0) ? requested_base_type : new ComposedCast(requested_base_type, rank);
			type = fullNamedExpression.ResolveAsType(ec);
			if (fullNamedExpression == null)
			{
				return false;
			}
			ArrayContainer arrayContainer = type as ArrayContainer;
			if (arrayContainer == null)
			{
				ec.Report.Error(622, loc, "Can only use array initializer expressions to assign to array types. Try using a new expression instead");
				return false;
			}
			array_element_type = arrayContainer.Element;
			dimensions = arrayContainer.Rank;
			return true;
		}

		protected override Expression DoResolve(ResolveContext ec)
		{
			if (type != null)
			{
				return this;
			}
			if (!ResolveArrayType(ec))
			{
				return null;
			}
			if (!ResolveInitializers(ec))
			{
				return null;
			}
			eclass = ExprClass.Value;
			return this;
		}

		private byte[] MakeByteBlob()
		{
			int count = array_data.Count;
			TypeSpec underlyingType = array_element_type;
			if (underlyingType.IsEnum)
			{
				underlyingType = EnumSpec.GetUnderlyingType(underlyingType);
			}
			int size = BuiltinTypeSpec.GetSize(underlyingType);
			if (size == 0)
			{
				throw new Exception("unrecognized type in MakeByteBlob: " + underlyingType);
			}
			byte[] array = new byte[(count * size + 3) & -4];
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				Constant constant = array_data[i] as Constant;
				if (constant == null)
				{
					num += size;
					continue;
				}
				object value = constant.GetValue();
				switch (underlyingType.BuiltinType)
				{
				case BuiltinTypeSpec.Type.Long:
				{
					long num8 = (long)value;
					for (int m = 0; m < size; m++)
					{
						array[num + m] = (byte)(num8 & 0xFF);
						num8 >>= 8;
					}
					break;
				}
				case BuiltinTypeSpec.Type.ULong:
				{
					ulong num7 = (ulong)value;
					for (int l = 0; l < size; l++)
					{
						array[num + l] = (byte)(num7 & 0xFF);
						num7 >>= 8;
					}
					break;
				}
				case BuiltinTypeSpec.Type.Float:
				{
					int num9 = SingleConverter.SingleToInt32Bits((float)value);
					array[num] = (byte)(num9 & 0xFF);
					array[num + 1] = (byte)((num9 >> 8) & 0xFF);
					array[num + 2] = (byte)((num9 >> 16) & 0xFF);
					array[num + 3] = (byte)(num9 >> 24);
					break;
				}
				case BuiltinTypeSpec.Type.Double:
				{
					byte[] bytes = BitConverter.GetBytes((double)value);
					for (int k = 0; k < size; k++)
					{
						array[num + k] = bytes[k];
					}
					if (!BitConverter.IsLittleEndian)
					{
						Array.Reverse(array, num, 8);
					}
					break;
				}
				case BuiltinTypeSpec.Type.Char:
				{
					int num14 = (char)value;
					array[num] = (byte)(num14 & 0xFF);
					array[num + 1] = (byte)(num14 >> 8);
					break;
				}
				case BuiltinTypeSpec.Type.Short:
				{
					int num13 = (short)value;
					array[num] = (byte)(num13 & 0xFF);
					array[num + 1] = (byte)(num13 >> 8);
					break;
				}
				case BuiltinTypeSpec.Type.UShort:
				{
					int num12 = (ushort)value;
					array[num] = (byte)(num12 & 0xFF);
					array[num + 1] = (byte)(num12 >> 8);
					break;
				}
				case BuiltinTypeSpec.Type.Int:
				{
					int num11 = (int)value;
					array[num] = (byte)(num11 & 0xFF);
					array[num + 1] = (byte)((num11 >> 8) & 0xFF);
					array[num + 2] = (byte)((num11 >> 16) & 0xFF);
					array[num + 3] = (byte)(num11 >> 24);
					break;
				}
				case BuiltinTypeSpec.Type.UInt:
				{
					uint num10 = (uint)value;
					array[num] = (byte)(num10 & 0xFF);
					array[num + 1] = (byte)((num10 >> 8) & 0xFF);
					array[num + 2] = (byte)((num10 >> 16) & 0xFF);
					array[num + 3] = (byte)(num10 >> 24);
					break;
				}
				case BuiltinTypeSpec.Type.SByte:
					array[num] = (byte)(sbyte)value;
					break;
				case BuiltinTypeSpec.Type.Byte:
					array[num] = (byte)value;
					break;
				case BuiltinTypeSpec.Type.FirstPrimitive:
					array[num] = (byte)(((bool)value) ? 1 : 0);
					break;
				case BuiltinTypeSpec.Type.Decimal:
				{
					int[] bits = decimal.GetBits((decimal)value);
					int num2 = num;
					int[] array2 = new int[4]
					{
						bits[3],
						bits[2],
						bits[0],
						bits[1]
					};
					for (int j = 0; j < 4; j++)
					{
						array[num2++] = (byte)(array2[j] & 0xFF);
						array[num2++] = (byte)((array2[j] >> 8) & 0xFF);
						array[num2++] = (byte)((array2[j] >> 16) & 0xFF);
						array[num2++] = (byte)(array2[j] >> 24);
					}
					break;
				}
				default:
					throw new Exception("Unrecognized type in MakeByteBlob: " + underlyingType);
				}
				num += size;
			}
			return array;
		}

		public override System.Linq.Expressions.Expression MakeExpression(BuilderContext ctx)
		{
			System.Linq.Expressions.Expression[] array = new System.Linq.Expressions.Expression[array_data.Count];
			for (int i = 0; i < array.Length; i++)
			{
				if (array_data[i] == null)
				{
					array[i] = System.Linq.Expressions.Expression.Default(array_element_type.GetMetaInfo());
				}
				else
				{
					array[i] = array_data[i].MakeExpression(ctx);
				}
			}
			return System.Linq.Expressions.Expression.NewArrayInit(array_element_type.GetMetaInfo(), array);
		}

		private void EmitDynamicInitializers(EmitContext ec, bool emitConstants, StackFieldExpr stackArray)
		{
			int count = bounds.Count;
			int[] array = new int[count];
			for (int i = 0; i < array_data.Count; i++)
			{
				Expression expression = array_data[i];
				Constant constant = expression as Constant;
				if (constant == null || (constant != null && emitConstants && !constant.IsDefaultInitializer(array_element_type)))
				{
					TypeSpec type = expression.Type;
					if (stackArray != null)
					{
						if (expression.ContainsEmitWithAwait())
						{
							expression = expression.EmitToField(ec);
						}
						stackArray.EmitLoad(ec);
					}
					else
					{
						ec.Emit(OpCodes.Dup);
					}
					for (int j = 0; j < count; j++)
					{
						ec.EmitInt(array[j]);
					}
					if (count == 1 && type.IsStruct && !BuiltinTypeSpec.IsPrimitiveType(type))
					{
						ec.Emit(OpCodes.Ldelema, type);
					}
					expression.Emit(ec);
					ec.EmitArrayStore((ArrayContainer)base.type);
				}
				for (int num = count - 1; num >= 0; num--)
				{
					array[num]++;
					if (array[num] < bounds[num])
					{
						break;
					}
					array[num] = 0;
				}
			}
			stackArray?.PrepareCleanup(ec);
		}

		public override void Emit(EmitContext ec)
		{
			EmitToFieldSource(ec)?.Emit(ec);
		}

		protected sealed override FieldExpr EmitToFieldSource(EmitContext ec)
		{
			if (first_emit != null)
			{
				first_emit.Emit(ec);
				first_emit_temp.Store(ec);
			}
			StackFieldExpr stackFieldExpr;
			if (ec.HasSet(BuilderContext.Options.AsyncBody) && InitializersContainAwait())
			{
				stackFieldExpr = ec.GetTemporaryField(type);
				ec.EmitThis();
			}
			else
			{
				stackFieldExpr = null;
			}
			Expression.EmitExpressionsList(ec, arguments);
			ec.EmitArrayNew((ArrayContainer)type);
			if (initializers == null)
			{
				return stackFieldExpr;
			}
			stackFieldExpr?.EmitAssignFromStack(ec);
			EmitDynamicInitializers(ec, emitConstants: true, stackFieldExpr);
			if (first_emit_temp != null)
			{
				first_emit_temp.Release(ec);
			}
			return stackFieldExpr;
		}

		public override void EncodeAttributeValue(IMemberContext rc, AttributeEncoder enc, TypeSpec targetType, TypeSpec parameterType)
		{
			if (arguments.Count != 1 || array_element_type.IsArray)
			{
				base.EncodeAttributeValue(rc, enc, targetType, parameterType);
				return;
			}
			if (type != targetType)
			{
				if (targetType.BuiltinType != BuiltinTypeSpec.Type.Object)
				{
					base.EncodeAttributeValue(rc, enc, targetType, parameterType);
					return;
				}
				if (enc.Encode(type) == AttributeEncoder.EncodedTypeProperties.DynamicType)
				{
					Attribute.Error_AttributeArgumentIsDynamic(rc, loc);
					return;
				}
			}
			if (array_data == null)
			{
				IntConstant intConstant = arguments[0] as IntConstant;
				if (intConstant == null || !intConstant.IsDefaultValue)
				{
					base.EncodeAttributeValue(rc, enc, targetType, parameterType);
				}
				else
				{
					enc.Encode(0);
				}
			}
			else
			{
				enc.Encode(array_data.Count);
				foreach (Expression array_datum in array_data)
				{
					array_datum.EncodeAttributeValue(rc, enc, array_element_type, parameterType);
				}
			}
		}

		protected override void CloneTo(CloneContext clonectx, Expression t)
		{
			ArrayCreation arrayCreation = (ArrayCreation)t;
			if (requested_base_type != null)
			{
				arrayCreation.requested_base_type = (FullNamedExpression)requested_base_type.Clone(clonectx);
			}
			if (arguments != null)
			{
				arrayCreation.arguments = new List<Expression>(arguments.Count);
				foreach (Expression argument in arguments)
				{
					arrayCreation.arguments.Add(argument.Clone(clonectx));
				}
			}
			if (initializers != null)
			{
				arrayCreation.initializers = (ArrayInitializer)initializers.Clone(clonectx);
			}
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}

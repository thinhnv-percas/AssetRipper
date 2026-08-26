using System;
using System.Reflection.Emit;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class PointerArithmetic : Expression
	{
		private Expression left;

		private Expression right;

		private readonly Binary.Operator op;

		public PointerArithmetic(Binary.Operator op, Expression l, Expression r, TypeSpec t, Location loc)
		{
			type = t;
			base.loc = loc;
			left = l;
			right = r;
			this.op = op;
		}

		public override bool ContainsEmitWithAwait()
		{
			throw new NotImplementedException();
		}

		public override Expression CreateExpressionTree(ResolveContext ec)
		{
			Error_PointerInsideExpressionTree(ec);
			return null;
		}

		protected override Expression DoResolve(ResolveContext ec)
		{
			eclass = ExprClass.Variable;
			PointerContainer pointerContainer = left.Type as PointerContainer;
			if (pointerContainer != null && pointerContainer.Element.Kind == MemberKind.Void)
			{
				Error_VoidPointerOperation(ec);
				return null;
			}
			return this;
		}

		public override void Emit(EmitContext ec)
		{
			TypeSpec type = left.Type;
			TypeSpec typeSpec;
			if (TypeManager.HasElementType(type))
			{
				typeSpec = TypeManager.GetElementType(type);
			}
			else
			{
				FieldExpr fieldExpr = left as FieldExpr;
				typeSpec = ((fieldExpr == null) ? type : ((FixedFieldSpec)fieldExpr.Spec).ElementType);
			}
			int size = BuiltinTypeSpec.GetSize(typeSpec);
			TypeSpec type2 = right.Type;
			if ((op & Binary.Operator.SubtractionMask) != 0 && type2.IsPointer)
			{
				left.Emit(ec);
				right.Emit(ec);
				ec.Emit(OpCodes.Sub);
				if (size != 1)
				{
					if (size == 0)
					{
						ec.Emit(OpCodes.Sizeof, typeSpec);
					}
					else
					{
						ec.EmitInt(size);
					}
					ec.Emit(OpCodes.Div);
				}
				ec.Emit(OpCodes.Conv_I8);
				return;
			}
			Constant constant = left as Constant;
			if (constant != null)
			{
				if (constant.IsDefaultValue)
				{
					left = EmptyExpression.Null;
				}
				else
				{
					constant = null;
				}
			}
			left.Emit(ec);
			Constant constant2 = right as Constant;
			if (constant2 != null)
			{
				if (constant2.IsDefaultValue)
				{
					return;
				}
				if (size != 0)
				{
					right = new IntConstant(ec.BuiltinTypes, size, right.Location);
				}
				else
				{
					right = new SizeOf(new TypeExpression(typeSpec, right.Location), right.Location);
				}
				ResolveContext rc = new ResolveContext(ec.MemberContext, ResolveContext.Options.UnsafeScope);
				right = new Binary(Binary.Operator.Multiply, right, constant2).Resolve(rc);
				if (right == null)
				{
					return;
				}
			}
			right.Emit(ec);
			switch (type2.BuiltinType)
			{
			case BuiltinTypeSpec.Type.Byte:
			case BuiltinTypeSpec.Type.SByte:
			case BuiltinTypeSpec.Type.Short:
			case BuiltinTypeSpec.Type.UShort:
				ec.Emit(OpCodes.Conv_I);
				break;
			case BuiltinTypeSpec.Type.UInt:
				ec.Emit(OpCodes.Conv_U);
				break;
			}
			if (constant2 == null && size != 1)
			{
				if (size == 0)
				{
					ec.Emit(OpCodes.Sizeof, typeSpec);
				}
				else
				{
					ec.EmitInt(size);
				}
				if (type2.BuiltinType == BuiltinTypeSpec.Type.Long || type2.BuiltinType == BuiltinTypeSpec.Type.ULong)
				{
					ec.Emit(OpCodes.Conv_I8);
				}
				Binary.EmitOperatorOpcode(ec, Binary.Operator.Multiply, type2, right);
			}
			if (constant == null)
			{
				if (type2.BuiltinType == BuiltinTypeSpec.Type.Long)
				{
					ec.Emit(OpCodes.Conv_I);
				}
				else if (type2.BuiltinType == BuiltinTypeSpec.Type.ULong)
				{
					ec.Emit(OpCodes.Conv_U);
				}
				Binary.EmitOperatorOpcode(ec, op, type, right);
			}
		}
	}
}

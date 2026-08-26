using System;
using System.Reflection.Emit;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class Fixed : Statement
	{
		private abstract class Emitter : ShimExpression
		{
			protected LocalVariable vi;

			protected Emitter(Expression expr, LocalVariable li)
				: base(expr)
			{
				vi = li;
			}

			public abstract void EmitExit(EmitContext ec);

			public override void FlowAnalysis(FlowAnalysisContext fc)
			{
				expr.FlowAnalysis(fc);
			}
		}

		private class ExpressionEmitter : Emitter
		{
			public ExpressionEmitter(Expression converted, LocalVariable li)
				: base(converted, li)
			{
			}

			protected override Expression DoResolve(ResolveContext rc)
			{
				throw new NotImplementedException();
			}

			public override void Emit(EmitContext ec)
			{
				expr.Emit(ec);
				vi.EmitAssign(ec);
			}

			public override void EmitExit(EmitContext ec)
			{
				ec.EmitInt(0);
				ec.Emit(OpCodes.Conv_U);
				vi.EmitAssign(ec);
			}
		}

		private class StringEmitter : Emitter
		{
			private LocalVariable pinned_string;

			public StringEmitter(Expression expr, LocalVariable li)
				: base(expr, li)
			{
			}

			protected override Expression DoResolve(ResolveContext rc)
			{
				pinned_string = new LocalVariable(vi.Block, "$pinned", LocalVariable.Flags.Used | LocalVariable.Flags.CompilerGenerated | LocalVariable.Flags.FixedVariable, vi.Location);
				pinned_string.Type = rc.BuiltinTypes.String;
				eclass = ExprClass.Variable;
				type = rc.BuiltinTypes.Int;
				return this;
			}

			public override void Emit(EmitContext ec)
			{
				pinned_string.CreateBuilder(ec);
				expr.Emit(ec);
				pinned_string.EmitAssign(ec);
				pinned_string.Emit(ec);
				ec.Emit(OpCodes.Conv_I);
				PropertySpec propertySpec = ec.Module.PredefinedMembers.RuntimeHelpersOffsetToStringData.Resolve(loc);
				if (propertySpec != null)
				{
					new PropertyExpr(propertySpec, pinned_string.Location).Resolve(new ResolveContext(ec.MemberContext)).Emit(ec);
					ec.Emit(OpCodes.Add);
					vi.EmitAssign(ec);
				}
			}

			public override void EmitExit(EmitContext ec)
			{
				ec.EmitNull();
				pinned_string.EmitAssign(ec);
			}
		}

		public class VariableDeclaration : BlockVariable
		{
			public VariableDeclaration(FullNamedExpression type, LocalVariable li)
				: base(type, li)
			{
			}

			protected override Expression ResolveInitializer(BlockContext bc, LocalVariable li, Expression initializer)
			{
				if (!base.Variable.Type.IsPointer && li == base.Variable)
				{
					bc.Report.Error(209, base.TypeExpression.Location, "The type of locals declared in a fixed statement must be a pointer type");
					return null;
				}
				if (initializer is Cast)
				{
					bc.Report.Error(254, initializer.Location, "The right hand side of a fixed statement assignment may not be a cast expression");
					return null;
				}
				initializer = initializer.Resolve(bc);
				if (initializer == null)
				{
					return null;
				}
				if (initializer.Type.IsArray)
				{
					TypeSpec elementType = TypeManager.GetElementType(initializer.Type);
					if (!TypeManager.VerifyUnmanaged(bc.Module, elementType, loc))
					{
						return null;
					}
					ArrayPtr arrayPtr = new ArrayPtr(initializer, elementType, loc);
					Expression expression = Convert.ImplicitConversionRequired(bc, arrayPtr.Resolve(bc), li.Type, loc);
					if (expression == null)
					{
						return null;
					}
					expression = new Conditional(new BooleanExpression(new Binary(Binary.Operator.LogicalOr, new Binary(Binary.Operator.Equality, initializer, new NullLiteral(loc)), new Binary(Binary.Operator.Equality, new MemberAccess(initializer, "Length"), new IntConstant(bc.BuiltinTypes, 0, loc)))), new NullLiteral(loc), expression, loc);
					expression = expression.Resolve(bc);
					return new ExpressionEmitter(expression, li);
				}
				if (initializer.Type.BuiltinType == BuiltinTypeSpec.Type.String)
				{
					return new StringEmitter(initializer, li).Resolve(bc);
				}
				if (initializer is FixedBufferPtr)
				{
					return new ExpressionEmitter(initializer, li);
				}
				bool flag = true;
				Unary unary = initializer as Unary;
				if (unary != null && unary.Oper == Unary.Operator.AddressOf)
				{
					IVariableReference variableReference = unary.Expr as IVariableReference;
					if (variableReference == null || !variableReference.IsFixed)
					{
						flag = false;
					}
				}
				if (flag)
				{
					bc.Report.Error(213, loc, "You cannot use the fixed statement to take the address of an already fixed expression");
				}
				initializer = Convert.ImplicitConversionRequired(bc, initializer, li.Type, loc);
				return new ExpressionEmitter(initializer, li);
			}
		}

		private VariableDeclaration decl;

		private Statement statement;

		private bool has_ret;

		public Statement Statement => statement;

		public BlockVariable Variables => decl;

		public Fixed(VariableDeclaration decl, Statement stmt, Location l)
		{
			this.decl = decl;
			statement = stmt;
			loc = l;
		}

		public override bool Resolve(BlockContext bc)
		{
			using (bc.Set(ResolveContext.Options.FixedInitializerScope))
			{
				if (!decl.Resolve(bc))
				{
					return false;
				}
			}
			return statement.Resolve(bc);
		}

		protected override bool DoFlowAnalysis(FlowAnalysisContext fc)
		{
			decl.FlowAnalysis(fc);
			return statement.FlowAnalysis(fc);
		}

		protected override void DoEmit(EmitContext ec)
		{
			decl.Variable.CreateBuilder(ec);
			decl.Initializer.Emit(ec);
			if (decl.Declarators != null)
			{
				foreach (BlockVariableDeclarator declarator in decl.Declarators)
				{
					declarator.Variable.CreateBuilder(ec);
					declarator.Initializer.Emit(ec);
				}
			}
			statement.Emit(ec);
			if (!has_ret)
			{
				((Emitter)decl.Initializer).EmitExit(ec);
				if (decl.Declarators != null)
				{
					foreach (BlockVariableDeclarator declarator2 in decl.Declarators)
					{
						((Emitter)declarator2.Initializer).EmitExit(ec);
					}
				}
			}
		}

		public override Reachability MarkReachable(Reachability rc)
		{
			base.MarkReachable(rc);
			decl.MarkReachable(rc);
			rc = statement.MarkReachable(rc);
			has_ret = rc.IsUnreachable;
			return rc;
		}

		protected override void CloneTo(CloneContext clonectx, Statement t)
		{
			Fixed obj = (Fixed)t;
			obj.decl = (VariableDeclaration)decl.Clone(clonectx);
			obj.statement = statement.Clone(clonectx);
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}

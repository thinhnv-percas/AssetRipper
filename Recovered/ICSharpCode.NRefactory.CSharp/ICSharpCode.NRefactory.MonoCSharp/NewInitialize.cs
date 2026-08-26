using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class NewInitialize : New
	{
		private sealed class InitializerTargetExpression : Expression, IMemoryLocation
		{
			private NewInitialize new_instance;

			public InitializerTargetExpression(NewInitialize newInstance)
			{
				type = newInstance.type;
				loc = newInstance.loc;
				eclass = newInstance.eclass;
				new_instance = newInstance;
			}

			public override bool ContainsEmitWithAwait()
			{
				return false;
			}

			public override Expression CreateExpressionTree(ResolveContext ec)
			{
				throw new NotSupportedException("ET");
			}

			protected override Expression DoResolve(ResolveContext ec)
			{
				return this;
			}

			public override Expression DoResolveLValue(ResolveContext ec, Expression right_side)
			{
				return this;
			}

			public override void Emit(EmitContext ec)
			{
				((Expression)new_instance.instance).Emit(ec);
			}

			public override Expression EmitToField(EmitContext ec)
			{
				return (Expression)new_instance.instance;
			}

			public void AddressOf(EmitContext ec, AddressOp mode)
			{
				new_instance.instance.AddressOf(ec, mode);
			}
		}

		private CollectionOrObjectInitializers initializers;

		private IMemoryLocation instance;

		private DynamicExpressionStatement dynamic;

		public CollectionOrObjectInitializers Initializers => initializers;

		public NewInitialize(FullNamedExpression requested_type, Arguments arguments, CollectionOrObjectInitializers initializers, Location l)
			: base(requested_type, arguments, l)
		{
			this.initializers = initializers;
		}

		protected override void CloneTo(CloneContext clonectx, Expression t)
		{
			base.CloneTo(clonectx, t);
			((NewInitialize)t).initializers = (CollectionOrObjectInitializers)initializers.Clone(clonectx);
		}

		public override bool ContainsEmitWithAwait()
		{
			if (!base.ContainsEmitWithAwait())
			{
				return initializers.ContainsEmitWithAwait();
			}
			return true;
		}

		public override Expression CreateExpressionTree(ResolveContext ec)
		{
			Arguments arguments = new Arguments(2);
			arguments.Add(new Argument(base.CreateExpressionTree(ec)));
			if (!initializers.IsEmpty)
			{
				arguments.Add(new Argument(initializers.CreateExpressionTree(ec, initializers.IsCollectionInitializer)));
			}
			return CreateExpressionFactoryCall(ec, initializers.IsCollectionInitializer ? "ListInit" : "MemberInit", arguments);
		}

		protected override Expression DoResolve(ResolveContext ec)
		{
			Expression expression = base.DoResolve(ec);
			if (type == null)
			{
				return null;
			}
			if (type.IsDelegate)
			{
				ec.Report.Error(1958, Initializers.Location, "Object and collection initializers cannot be used to instantiate a delegate");
			}
			Expression currentInitializerVariable = ec.CurrentInitializerVariable;
			ec.CurrentInitializerVariable = new InitializerTargetExpression(this);
			initializers.Resolve(ec);
			ec.CurrentInitializerVariable = currentInitializerVariable;
			dynamic = (expression as DynamicExpressionStatement);
			if (dynamic != null)
			{
				return this;
			}
			return expression;
		}

		public override void Emit(EmitContext ec)
		{
			if (method == null && TypeSpec.IsValueType(type) && initializers.Initializers.Count > 1 && ec.HasSet(BuilderContext.Options.AsyncBody) && initializers.ContainsEmitWithAwait())
			{
				StackFieldExpr temporaryField = ec.GetTemporaryField(type);
				if (!Emit(ec, temporaryField))
				{
					temporaryField.Emit(ec);
				}
			}
			else
			{
				base.Emit(ec);
			}
		}

		public override bool Emit(EmitContext ec, IMemoryLocation target)
		{
			bool flag;
			if (dynamic != null)
			{
				dynamic.Emit(ec);
				flag = true;
			}
			else
			{
				flag = base.Emit(ec, target);
			}
			if (initializers.IsEmpty)
			{
				return flag;
			}
			LocalTemporary localTemporary = null;
			instance = (target as LocalTemporary);
			if (instance == null)
			{
				instance = (target as StackFieldExpr);
			}
			if (instance == null)
			{
				if (!flag)
				{
					VariableReference variableReference = target as VariableReference;
					if (variableReference != null && variableReference.IsRef)
					{
						target.AddressOf(ec, AddressOp.Load);
					}
					((Expression)target).Emit(ec);
					flag = true;
				}
				if (!ec.HasSet(BuilderContext.Options.AsyncBody) || !initializers.ContainsEmitWithAwait())
				{
					localTemporary = (LocalTemporary)(instance = new LocalTemporary(type));
				}
				else
				{
					instance = (new EmptyAwaitExpression(base.Type).EmitToField(ec) as IMemoryLocation);
				}
			}
			if (flag)
			{
				localTemporary?.Store(ec);
			}
			initializers.Emit(ec);
			if (flag)
			{
				if (localTemporary != null)
				{
					localTemporary.Emit(ec);
					localTemporary.Release(ec);
				}
				else
				{
					((Expression)instance).Emit(ec);
				}
			}
			return flag;
		}

		protected override IMemoryLocation EmitAddressOf(EmitContext ec, AddressOp Mode)
		{
			instance = base.EmitAddressOf(ec, Mode);
			if (!initializers.IsEmpty)
			{
				initializers.Emit(ec);
			}
			return instance;
		}

		public override void FlowAnalysis(FlowAnalysisContext fc)
		{
			base.FlowAnalysis(fc);
			initializers.FlowAnalysis(fc);
		}

		public override object Accept(StructuralVisitor visitor)
		{
			return visitor.Visit(this);
		}
	}
}

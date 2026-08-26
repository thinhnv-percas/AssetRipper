using System.Collections.Generic;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal class DictionaryElementInitializer : ElementInitializer
	{
		private readonly Arguments args;

		public DictionaryElementInitializer(List<Expression> arguments, Expression initializer, Location loc)
			: base(null, initializer, loc)
		{
			args = new Arguments(arguments.Count);
			foreach (Expression argument in arguments)
			{
				args.Add(new Argument(argument));
			}
		}

		public override Expression CreateExpressionTree(ResolveContext ec)
		{
			ec.Report.Error(8074, loc, "Expression tree cannot contain a dictionary initializer");
			return null;
		}

		protected override bool ResolveElement(ResolveContext rc)
		{
			Expression currentInitializerVariable = rc.CurrentInitializerVariable;
			TypeSpec type = currentInitializerVariable.Type;
			if (type.IsArray)
			{
				target = new ArrayAccess(new ElementAccess(currentInitializerVariable, args, loc), loc);
				return true;
			}
			IList<MemberSpec> list = MemberCache.FindMembers(type, MemberCache.IndexerNameAlias, declaredOnlyClass: false);
			if (list == null && type.BuiltinType != BuiltinTypeSpec.Type.Dynamic)
			{
				ElementAccess.Error_CannotApplyIndexing(rc, type, loc);
				return false;
			}
			target = new IndexerExpr(list, type, currentInitializerVariable, args, loc).Resolve(rc);
			return true;
		}
	}
}

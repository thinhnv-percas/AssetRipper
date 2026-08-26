using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public sealed class DefaultVariable : IVariable, ISymbol
	{
		private readonly string name;

		private readonly DomRegion region;

		private readonly IType type;

		private readonly object constantValue;

		private readonly bool isConst;

		public string Name => name;

		public DomRegion Region => region;

		public IType Type => type;

		public bool IsConst => isConst;

		public object ConstantValue => constantValue;

		public SymbolKind SymbolKind => SymbolKind.Variable;

		public DefaultVariable(IType type, string name)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.type = type;
			this.name = name;
		}

		public DefaultVariable(IType type, string name, DomRegion region = default(DomRegion), bool isConst = false, object constantValue = null)
			: this(type, name)
		{
			this.region = region;
			this.isConst = isConst;
			this.constantValue = constantValue;
		}

		public ISymbolReference ToReference()
		{
			return new VariableReference(type.ToTypeReference(), name, region, isConst, constantValue);
		}
	}
}

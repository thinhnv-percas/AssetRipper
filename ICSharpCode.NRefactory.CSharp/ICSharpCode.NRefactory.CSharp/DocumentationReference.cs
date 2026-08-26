using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class DocumentationReference : AstNode
{
	public static readonly Role<AstType> DeclaringTypeRole = new Role<AstType>("DeclaringType", AstType.Null);

	public static readonly Role<AstType> ConversionOperatorReturnTypeRole = new Role<AstType>("ConversionOperatorReturnType", AstType.Null);

	private SymbolKind symbolKind;

	private OperatorType operatorType;

	private bool hasParameterList;

	public SymbolKind SymbolKind
	{
		get
		{
			return symbolKind;
		}
		set
		{
			ThrowIfFrozen();
			symbolKind = value;
		}
	}

	public OperatorType OperatorType
	{
		get
		{
			return operatorType;
		}
		set
		{
			ThrowIfFrozen();
			operatorType = value;
		}
	}

	public bool HasParameterList
	{
		get
		{
			return hasParameterList;
		}
		set
		{
			ThrowIfFrozen();
			hasParameterList = value;
		}
	}

	public override NodeType NodeType => NodeType.Unknown;

	public AstType DeclaringType
	{
		get
		{
			return GetChildByRole(DeclaringTypeRole);
		}
		set
		{
			SetChildByRole(DeclaringTypeRole, value);
		}
	}

	public string MemberName
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, Identifier.Create(value));
		}
	}

	public AstType ConversionOperatorReturnType
	{
		get
		{
			return GetChildByRole(ConversionOperatorReturnTypeRole);
		}
		set
		{
			SetChildByRole(ConversionOperatorReturnTypeRole, value);
		}
	}

	public AstNodeCollection<AstType> TypeArguments => GetChildrenByRole(Roles.TypeArgument);

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (!(other is DocumentationReference documentationReference) || SymbolKind != documentationReference.SymbolKind || HasParameterList != documentationReference.HasParameterList)
		{
			return false;
		}
		if (SymbolKind == SymbolKind.Operator)
		{
			if (OperatorType != documentationReference.OperatorType)
			{
				return false;
			}
			if ((OperatorType == OperatorType.Implicit || OperatorType == OperatorType.Explicit) && !ConversionOperatorReturnType.DoMatch(documentationReference.ConversionOperatorReturnType, match))
			{
				return false;
			}
		}
		else if (SymbolKind == SymbolKind.None)
		{
			if (!AstNode.MatchString(MemberName, documentationReference.MemberName))
			{
				return false;
			}
			if (!TypeArguments.DoMatch(documentationReference.TypeArguments, match))
			{
				return false;
			}
		}
		return Parameters.DoMatch(documentationReference.Parameters, match);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitDocumentationReference(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitDocumentationReference(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitDocumentationReference(this, data);
	}
}

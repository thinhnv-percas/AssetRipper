using System;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class ComposedType : AstType
{
	public static readonly TokenRole NullableRole = new TokenRole("?");

	public static readonly TokenRole PointerRole = new TokenRole("*");

	public static readonly Role<ArraySpecifier> ArraySpecifierRole = new Role<ArraySpecifier>("ArraySpecifier");

	public AstType BaseType
	{
		get
		{
			return GetChildByRole(Roles.Type);
		}
		set
		{
			SetChildByRole(Roles.Type, value);
		}
	}

	public bool HasNullableSpecifier
	{
		get
		{
			return !GetChildByRole(NullableRole).IsNull;
		}
		set
		{
			SetChildByRole(NullableRole, value ? new CSharpTokenNode(TextLocation.Empty, null) : null);
		}
	}

	public CSharpTokenNode NullableSpecifierToken => GetChildByRole(NullableRole);

	public int PointerRank
	{
		get
		{
			return GetChildrenByRole(PointerRole).Count;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			int i;
			for (i = PointerRank; i > value; i--)
			{
				GetChildByRole(PointerRole).Remove();
			}
			for (; i < value; i++)
			{
				InsertChildBefore(GetChildByRole(PointerRole), new CSharpTokenNode(TextLocation.Empty, PointerRole), PointerRole);
			}
		}
	}

	public AstNodeCollection<ArraySpecifier> ArraySpecifiers => GetChildrenByRole(ArraySpecifierRole);

	public AstNodeCollection<CSharpTokenNode> PointerTokens => GetChildrenByRole(PointerRole);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitComposedType(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitComposedType(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitComposedType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ComposedType composedType && HasNullableSpecifier == composedType.HasNullableSpecifier && PointerRank == composedType.PointerRank && BaseType.DoMatch(composedType.BaseType, match))
		{
			return ArraySpecifiers.DoMatch(composedType.ArraySpecifiers, match);
		}
		return false;
	}

	public override string ToString(CSharpFormattingOptions formattingOptions)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(BaseType.ToString());
		if (HasNullableSpecifier)
		{
			stringBuilder.Append('?');
		}
		stringBuilder.Append('*', PointerRank);
		foreach (ArraySpecifier arraySpecifier in ArraySpecifiers)
		{
			stringBuilder.Append('[');
			stringBuilder.Append(',', arraySpecifier.Dimensions - 1);
			stringBuilder.Append(']');
		}
		return stringBuilder.ToString();
	}

	public override AstType MakePointerType()
	{
		if (ArraySpecifiers.Any())
		{
			return base.MakePointerType();
		}
		PointerRank++;
		return this;
	}

	public override AstType MakeArrayType(int dimensions)
	{
		InsertChildBefore(ArraySpecifiers.FirstOrDefault(), new ArraySpecifier(dimensions), ArraySpecifierRole);
		return this;
	}

	public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider = null)
	{
		if (interningProvider == null)
		{
			interningProvider = InterningProvider.Dummy;
		}
		ITypeReference typeReference = BaseType.ToTypeReference(lookupMode, interningProvider);
		if (HasNullableSpecifier)
		{
			typeReference = interningProvider.Intern(NullableType.Create(typeReference));
		}
		int pointerRank = PointerRank;
		for (int i = 0; i < pointerRank; i++)
		{
			typeReference = interningProvider.Intern(new PointerTypeReference(typeReference));
		}
		foreach (ArraySpecifier item in ArraySpecifiers.Reverse())
		{
			typeReference = interningProvider.Intern(new ArrayTypeReference(typeReference, item.Dimensions));
		}
		return typeReference;
	}
}

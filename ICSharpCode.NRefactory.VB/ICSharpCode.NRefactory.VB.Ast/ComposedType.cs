using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ComposedType : AstType
{
	public static readonly Role<VBTokenNode> NullableRole = new Role<VBTokenNode>("Nullable", VBTokenNode.Null);

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
			SetChildByRole(NullableRole, value ? new VBTokenNode(TextLocation.Empty, 1) : null);
		}
	}

	public AstNodeCollection<ArraySpecifier> ArraySpecifiers => GetChildrenByRole(ArraySpecifierRole);

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitComposedType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ComposedType composedType && HasNullableSpecifier == composedType.HasNullableSpecifier)
		{
			return ArraySpecifiers.DoMatch(composedType.ArraySpecifiers, match);
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(BaseType.ToString());
		if (HasNullableSpecifier)
		{
			stringBuilder.Append('?');
		}
		foreach (ArraySpecifier arraySpecifier in ArraySpecifiers)
		{
			stringBuilder.Append('(');
			stringBuilder.Append(',', arraySpecifier.Dimensions - 1);
			stringBuilder.Append(')');
		}
		return stringBuilder.ToString();
	}

	public override AstType MakeArrayType(int dimensions)
	{
		InsertChildBefore(ArraySpecifiers.FirstOrDefault(), new ArraySpecifier(dimensions), ArraySpecifierRole);
		return this;
	}
}

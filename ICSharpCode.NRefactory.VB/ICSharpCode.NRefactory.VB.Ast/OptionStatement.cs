using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class OptionStatement : AstNode
{
	public static readonly Role<VBTokenNode> OptionTypeRole = new Role<VBTokenNode>("OptionType");

	public static readonly Role<VBTokenNode> OptionValueRole = new Role<VBTokenNode>("OptionValue");

	public VBTokenNode OptionKeyword => GetChildByRole(Roles.Keyword);

	public VBTokenNode OptionTypeKeyword => GetChildByRole(OptionTypeRole);

	public VBTokenNode OptionValueKeyword => GetChildByRole(OptionValueRole);

	public OptionType OptionType { get; set; }

	public OptionValue OptionValue { get; set; }

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is OptionStatement optionStatement && optionStatement.OptionType == OptionType)
		{
			return optionStatement.OptionValue == OptionValue;
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitOptionStatement(this, data);
	}

	public override string ToString()
	{
		return $"[OptionStatement OptionType={OptionType} OptionValue={OptionValue}]";
	}
}

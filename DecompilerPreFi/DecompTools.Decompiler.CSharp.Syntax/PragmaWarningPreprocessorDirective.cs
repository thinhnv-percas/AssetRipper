using System;
using System.Collections.Generic;
using System.Linq;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class PragmaWarningPreprocessorDirective : PreProcessorDirective
{
	public static readonly Role<PrimitiveExpression> WarningRole = new Role<PrimitiveExpression>("Warning");

	public static readonly TokenRole PragmaKeywordRole = new TokenRole("#pragma");

	public static readonly TokenRole WarningKeywordRole = new TokenRole("warning");

	public static readonly TokenRole DisableKeywordRole = new TokenRole("disable");

	public static readonly TokenRole RestoreKeywordRole = new TokenRole("restore");

	public bool Disable => !DisableToken.IsNull;

	public CSharpTokenNode PragmaToken => GetChildByRole(PragmaKeywordRole);

	public CSharpTokenNode WarningToken => GetChildByRole(WarningKeywordRole);

	public CSharpTokenNode DisableToken => GetChildByRole(DisableKeywordRole);

	public CSharpTokenNode RestoreToken => GetChildByRole(RestoreKeywordRole);

	public AstNodeCollection<PrimitiveExpression> Warnings => GetChildrenByRole(WarningRole);

	public override TextLocation EndLocation => base.LastChild?.EndLocation ?? base.EndLocation;

	public PragmaWarningPreprocessorDirective(TextLocation startLocation, TextLocation endLocation)
		: base(PreProcessorDirectiveType.Pragma, startLocation, endLocation)
	{
	}

	public PragmaWarningPreprocessorDirective(string argument = null)
		: base(PreProcessorDirectiveType.Pragma, argument)
	{
	}

	public bool IsDefined(int pragmaWarning)
	{
		return Enumerable.Any<int>(Enumerable.Select<PrimitiveExpression, int>((IEnumerable<PrimitiveExpression>)Warnings, (Func<PrimitiveExpression, int>)((PrimitiveExpression w) => (int)w.Value)), (Func<int, bool>)((int n) => n == pragmaWarning));
	}
}

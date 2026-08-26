using System.ComponentModel;

namespace DecompTools.Decompiler.CSharp.OutputVisitor;

[TypeConverter(typeof(ExpandableObjectConverter))]
public class CSharpFormattingOptions
{
	private bool allowOneLinedArrayInitialziers = true;

	private NewLinePlacement embeddedStatementPlacement = NewLinePlacement.NewLine;

	public string Name { get; set; }

	public bool IsBuiltIn { get; set; }

	public string IndentationString { get; set; } = "\t";

	public bool IndentNamespaceBody { get; set; }

	public bool IndentClassBody { get; set; }

	public bool IndentInterfaceBody { get; set; }

	public bool IndentStructBody { get; set; }

	public bool IndentEnumBody { get; set; }

	public bool IndentMethodBody { get; set; }

	public bool IndentPropertyBody { get; set; }

	public bool IndentEventBody { get; set; }

	public bool IndentBlocks { get; set; }

	public bool IndentSwitchBody { get; set; }

	public bool IndentCaseBody { get; set; }

	public bool IndentBreakStatements { get; set; }

	public bool AlignEmbeddedStatements { get; set; }

	public bool AlignElseInIfStatements { get; set; }

	public PropertyFormatting AutoPropertyFormatting { get; set; }

	public PropertyFormatting SimplePropertyFormatting { get; set; }

	public EmptyLineFormatting EmptyLineFormatting { get; set; }

	public bool IndentPreprocessorDirectives { get; set; }

	public bool AlignToMemberReferenceDot { get; set; }

	public bool IndentBlocksInsideExpressions { get; set; }

	public BraceStyle NamespaceBraceStyle { get; set; }

	public BraceStyle ClassBraceStyle { get; set; }

	public BraceStyle InterfaceBraceStyle { get; set; }

	public BraceStyle StructBraceStyle { get; set; }

	public BraceStyle EnumBraceStyle { get; set; }

	public BraceStyle MethodBraceStyle { get; set; }

	public BraceStyle AnonymousMethodBraceStyle { get; set; }

	public BraceStyle ConstructorBraceStyle { get; set; }

	public BraceStyle DestructorBraceStyle { get; set; }

	public BraceStyle PropertyBraceStyle { get; set; }

	public BraceStyle PropertyGetBraceStyle { get; set; }

	public BraceStyle PropertySetBraceStyle { get; set; }

	public PropertyFormatting SimpleGetBlockFormatting { get; set; }

	public PropertyFormatting SimpleSetBlockFormatting { get; set; }

	public BraceStyle EventBraceStyle { get; set; }

	public BraceStyle EventAddBraceStyle { get; set; }

	public BraceStyle EventRemoveBraceStyle { get; set; }

	public bool AllowEventAddBlockInline { get; set; }

	public bool AllowEventRemoveBlockInline { get; set; }

	public BraceStyle StatementBraceStyle { get; set; }

	public bool AllowIfBlockInline { get; set; }

	public bool AllowOneLinedArrayInitialziers
	{
		get
		{
			return allowOneLinedArrayInitialziers;
		}
		set
		{
			allowOneLinedArrayInitialziers = value;
		}
	}

	public NewLinePlacement ElseNewLinePlacement { get; set; }

	public NewLinePlacement ElseIfNewLinePlacement { get; set; }

	public NewLinePlacement CatchNewLinePlacement { get; set; }

	public NewLinePlacement FinallyNewLinePlacement { get; set; }

	public NewLinePlacement WhileNewLinePlacement { get; set; }

	public NewLinePlacement EmbeddedStatementPlacement
	{
		get
		{
			return embeddedStatementPlacement;
		}
		set
		{
			embeddedStatementPlacement = value;
		}
	}

	public bool SpaceBeforeMethodDeclarationParentheses { get; set; }

	public bool SpaceBetweenEmptyMethodDeclarationParentheses { get; set; }

	public bool SpaceBeforeMethodDeclarationParameterComma { get; set; }

	public bool SpaceAfterMethodDeclarationParameterComma { get; set; }

	public bool SpaceWithinMethodDeclarationParentheses { get; set; }

	public bool SpaceBeforeMethodCallParentheses { get; set; }

	public bool SpaceBetweenEmptyMethodCallParentheses { get; set; }

	public bool SpaceBeforeMethodCallParameterComma { get; set; }

	public bool SpaceAfterMethodCallParameterComma { get; set; }

	public bool SpaceWithinMethodCallParentheses { get; set; }

	public bool SpaceBeforeFieldDeclarationComma { get; set; }

	public bool SpaceAfterFieldDeclarationComma { get; set; }

	public bool SpaceBeforeLocalVariableDeclarationComma { get; set; }

	public bool SpaceAfterLocalVariableDeclarationComma { get; set; }

	public bool SpaceBeforeConstructorDeclarationParentheses { get; set; }

	public bool SpaceBetweenEmptyConstructorDeclarationParentheses { get; set; }

	public bool SpaceBeforeConstructorDeclarationParameterComma { get; set; }

	public bool SpaceAfterConstructorDeclarationParameterComma { get; set; }

	public bool SpaceWithinConstructorDeclarationParentheses { get; set; }

	public NewLinePlacement NewLineBeforeConstructorInitializerColon { get; set; }

	public NewLinePlacement NewLineAfterConstructorInitializerColon { get; set; }

	public bool SpaceBeforeIndexerDeclarationBracket { get; set; }

	public bool SpaceWithinIndexerDeclarationBracket { get; set; }

	public bool SpaceBeforeIndexerDeclarationParameterComma { get; set; }

	public bool SpaceAfterIndexerDeclarationParameterComma { get; set; }

	public bool SpaceBeforeDelegateDeclarationParentheses { get; set; }

	public bool SpaceBetweenEmptyDelegateDeclarationParentheses { get; set; }

	public bool SpaceBeforeDelegateDeclarationParameterComma { get; set; }

	public bool SpaceAfterDelegateDeclarationParameterComma { get; set; }

	public bool SpaceWithinDelegateDeclarationParentheses { get; set; }

	public bool SpaceBeforeNewParentheses { get; set; }

	public bool SpaceBeforeIfParentheses { get; set; }

	public bool SpaceBeforeWhileParentheses { get; set; }

	public bool SpaceBeforeForParentheses { get; set; }

	public bool SpaceBeforeForeachParentheses { get; set; }

	public bool SpaceBeforeCatchParentheses { get; set; }

	public bool SpaceBeforeSwitchParentheses { get; set; }

	public bool SpaceBeforeLockParentheses { get; set; }

	public bool SpaceBeforeUsingParentheses { get; set; }

	public bool SpaceAroundAssignment { get; set; }

	public bool SpaceAroundLogicalOperator { get; set; }

	public bool SpaceAroundEqualityOperator { get; set; }

	public bool SpaceAroundRelationalOperator { get; set; }

	public bool SpaceAroundBitwiseOperator { get; set; }

	public bool SpaceAroundAdditiveOperator { get; set; }

	public bool SpaceAroundMultiplicativeOperator { get; set; }

	public bool SpaceAroundShiftOperator { get; set; }

	public bool SpaceAroundNullCoalescingOperator { get; set; }

	public bool SpaceAfterUnsafeAddressOfOperator { get; set; }

	public bool SpaceAfterUnsafeAsteriskOfOperator { get; set; }

	public bool SpaceAroundUnsafeArrowOperator { get; set; }

	public bool SpacesWithinParentheses { get; set; }

	public bool SpacesWithinIfParentheses { get; set; }

	public bool SpacesWithinWhileParentheses { get; set; }

	public bool SpacesWithinForParentheses { get; set; }

	public bool SpacesWithinForeachParentheses { get; set; }

	public bool SpacesWithinCatchParentheses { get; set; }

	public bool SpacesWithinSwitchParentheses { get; set; }

	public bool SpacesWithinLockParentheses { get; set; }

	public bool SpacesWithinUsingParentheses { get; set; }

	public bool SpacesWithinCastParentheses { get; set; }

	public bool SpacesWithinSizeOfParentheses { get; set; }

	public bool SpaceBeforeSizeOfParentheses { get; set; }

	public bool SpacesWithinTypeOfParentheses { get; set; }

	public bool SpacesWithinNewParentheses { get; set; }

	public bool SpacesBetweenEmptyNewParentheses { get; set; }

	public bool SpaceBeforeNewParameterComma { get; set; }

	public bool SpaceAfterNewParameterComma { get; set; }

	public bool SpaceBeforeTypeOfParentheses { get; set; }

	public bool SpacesWithinCheckedExpressionParantheses { get; set; }

	public bool SpaceBeforeConditionalOperatorCondition { get; set; }

	public bool SpaceAfterConditionalOperatorCondition { get; set; }

	public bool SpaceBeforeConditionalOperatorSeparator { get; set; }

	public bool SpaceAfterConditionalOperatorSeparator { get; set; }

	public bool SpacesWithinBrackets { get; set; }

	public bool SpacesBeforeBrackets { get; set; }

	public bool SpaceBeforeBracketComma { get; set; }

	public bool SpaceAfterBracketComma { get; set; }

	public bool SpaceBeforeForSemicolon { get; set; }

	public bool SpaceAfterForSemicolon { get; set; }

	public bool SpaceAfterTypecast { get; set; }

	public bool SpaceBeforeArrayDeclarationBrackets { get; set; }

	public bool SpaceInNamedArgumentAfterDoubleColon { get; set; }

	public bool RemoveEndOfLineWhiteSpace { get; set; }

	public bool SpaceBeforeSemicolon { get; set; }

	public int MinimumBlankLinesBeforeUsings { get; set; }

	public int MinimumBlankLinesAfterUsings { get; set; }

	public int MinimumBlankLinesBeforeFirstDeclaration { get; set; }

	public int MinimumBlankLinesBetweenTypes { get; set; }

	public int MinimumBlankLinesBetweenFields { get; set; }

	public int MinimumBlankLinesBetweenEventFields { get; set; }

	public int MinimumBlankLinesBetweenMembers { get; set; }

	public int MinimumBlankLinesAroundRegion { get; set; }

	public int MinimumBlankLinesInsideRegion { get; set; }

	public bool KeepCommentsAtFirstColumn { get; set; }

	public Wrapping ArrayInitializerWrapping { get; set; }

	public BraceStyle ArrayInitializerBraceStyle { get; set; }

	public Wrapping ChainedMethodCallWrapping { get; set; }

	public Wrapping MethodCallArgumentWrapping { get; set; }

	public NewLinePlacement NewLineAferMethodCallOpenParentheses { get; set; }

	public NewLinePlacement MethodCallClosingParenthesesOnNewLine { get; set; }

	public Wrapping IndexerArgumentWrapping { get; set; }

	public NewLinePlacement NewLineAferIndexerOpenBracket { get; set; }

	public NewLinePlacement IndexerClosingBracketOnNewLine { get; set; }

	public Wrapping MethodDeclarationParameterWrapping { get; set; }

	public NewLinePlacement NewLineAferMethodDeclarationOpenParentheses { get; set; }

	public NewLinePlacement MethodDeclarationClosingParenthesesOnNewLine { get; set; }

	public Wrapping IndexerDeclarationParameterWrapping { get; set; }

	public NewLinePlacement NewLineAferIndexerDeclarationOpenBracket { get; set; }

	public NewLinePlacement IndexerDeclarationClosingBracketOnNewLine { get; set; }

	public bool AlignToFirstIndexerArgument { get; set; }

	public bool AlignToFirstIndexerDeclarationParameter { get; set; }

	public bool AlignToFirstMethodCallArgument { get; set; }

	public bool AlignToFirstMethodDeclarationParameter { get; set; }

	public NewLinePlacement NewLineBeforeNewQueryClause { get; set; }

	public UsingPlacement UsingPlacement { get; set; }

	public CSharpFormattingOptions Clone()
	{
		return (CSharpFormattingOptions)MemberwiseClone();
	}

	internal CSharpFormattingOptions()
	{
	}
}

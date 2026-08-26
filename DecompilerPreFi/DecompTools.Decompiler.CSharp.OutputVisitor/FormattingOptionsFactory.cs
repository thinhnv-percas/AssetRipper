namespace DecompTools.Decompiler.CSharp.OutputVisitor;

public static class FormattingOptionsFactory
{
	public static CSharpFormattingOptions CreateEmpty()
	{
		return new CSharpFormattingOptions();
	}

	public static CSharpFormattingOptions CreateMono()
	{
		return new CSharpFormattingOptions
		{
			IndentNamespaceBody = true,
			IndentClassBody = true,
			IndentInterfaceBody = true,
			IndentStructBody = true,
			IndentEnumBody = true,
			IndentMethodBody = true,
			IndentPropertyBody = true,
			IndentEventBody = true,
			IndentBlocks = true,
			IndentSwitchBody = false,
			IndentCaseBody = true,
			IndentBreakStatements = true,
			IndentPreprocessorDirectives = true,
			IndentBlocksInsideExpressions = false,
			NamespaceBraceStyle = BraceStyle.NextLine,
			ClassBraceStyle = BraceStyle.NextLine,
			InterfaceBraceStyle = BraceStyle.NextLine,
			StructBraceStyle = BraceStyle.NextLine,
			EnumBraceStyle = BraceStyle.NextLine,
			MethodBraceStyle = BraceStyle.NextLine,
			ConstructorBraceStyle = BraceStyle.NextLine,
			DestructorBraceStyle = BraceStyle.NextLine,
			AnonymousMethodBraceStyle = BraceStyle.EndOfLine,
			PropertyBraceStyle = BraceStyle.EndOfLine,
			PropertyGetBraceStyle = BraceStyle.EndOfLine,
			PropertySetBraceStyle = BraceStyle.EndOfLine,
			SimpleGetBlockFormatting = PropertyFormatting.AllowOneLine,
			SimpleSetBlockFormatting = PropertyFormatting.AllowOneLine,
			EventBraceStyle = BraceStyle.EndOfLine,
			EventAddBraceStyle = BraceStyle.EndOfLine,
			EventRemoveBraceStyle = BraceStyle.EndOfLine,
			AllowEventAddBlockInline = true,
			AllowEventRemoveBlockInline = true,
			StatementBraceStyle = BraceStyle.EndOfLine,
			ElseNewLinePlacement = NewLinePlacement.SameLine,
			ElseIfNewLinePlacement = NewLinePlacement.SameLine,
			CatchNewLinePlacement = NewLinePlacement.SameLine,
			FinallyNewLinePlacement = NewLinePlacement.SameLine,
			WhileNewLinePlacement = NewLinePlacement.SameLine,
			ArrayInitializerWrapping = Wrapping.WrapIfTooLong,
			ArrayInitializerBraceStyle = BraceStyle.EndOfLine,
			AllowOneLinedArrayInitialziers = true,
			SpaceBeforeMethodCallParentheses = true,
			SpaceBeforeMethodDeclarationParentheses = true,
			SpaceBeforeConstructorDeclarationParentheses = true,
			SpaceBeforeDelegateDeclarationParentheses = true,
			SpaceAfterMethodCallParameterComma = true,
			SpaceAfterConstructorDeclarationParameterComma = true,
			SpaceBeforeNewParentheses = true,
			SpacesWithinNewParentheses = false,
			SpacesBetweenEmptyNewParentheses = false,
			SpaceBeforeNewParameterComma = false,
			SpaceAfterNewParameterComma = true,
			SpaceBeforeIfParentheses = true,
			SpaceBeforeWhileParentheses = true,
			SpaceBeforeForParentheses = true,
			SpaceBeforeForeachParentheses = true,
			SpaceBeforeCatchParentheses = true,
			SpaceBeforeSwitchParentheses = true,
			SpaceBeforeLockParentheses = true,
			SpaceBeforeUsingParentheses = true,
			SpaceAroundAssignment = true,
			SpaceAroundLogicalOperator = true,
			SpaceAroundEqualityOperator = true,
			SpaceAroundRelationalOperator = true,
			SpaceAroundBitwiseOperator = true,
			SpaceAroundAdditiveOperator = true,
			SpaceAroundMultiplicativeOperator = true,
			SpaceAroundShiftOperator = true,
			SpaceAroundNullCoalescingOperator = true,
			SpacesWithinParentheses = false,
			SpaceWithinMethodCallParentheses = false,
			SpaceWithinMethodDeclarationParentheses = false,
			SpacesWithinIfParentheses = false,
			SpacesWithinWhileParentheses = false,
			SpacesWithinForParentheses = false,
			SpacesWithinForeachParentheses = false,
			SpacesWithinCatchParentheses = false,
			SpacesWithinSwitchParentheses = false,
			SpacesWithinLockParentheses = false,
			SpacesWithinUsingParentheses = false,
			SpacesWithinCastParentheses = false,
			SpacesWithinSizeOfParentheses = false,
			SpacesWithinTypeOfParentheses = false,
			SpacesWithinCheckedExpressionParantheses = false,
			SpaceBeforeConditionalOperatorCondition = true,
			SpaceAfterConditionalOperatorCondition = true,
			SpaceBeforeConditionalOperatorSeparator = true,
			SpaceAfterConditionalOperatorSeparator = true,
			SpacesWithinBrackets = false,
			SpacesBeforeBrackets = true,
			SpaceBeforeBracketComma = false,
			SpaceAfterBracketComma = true,
			SpaceBeforeForSemicolon = false,
			SpaceAfterForSemicolon = true,
			SpaceAfterTypecast = false,
			AlignEmbeddedStatements = true,
			SimplePropertyFormatting = PropertyFormatting.AllowOneLine,
			AutoPropertyFormatting = PropertyFormatting.AllowOneLine,
			EmptyLineFormatting = EmptyLineFormatting.DoNotIndent,
			SpaceBeforeMethodDeclarationParameterComma = false,
			SpaceAfterMethodDeclarationParameterComma = true,
			SpaceAfterDelegateDeclarationParameterComma = true,
			SpaceBeforeFieldDeclarationComma = false,
			SpaceAfterFieldDeclarationComma = true,
			SpaceBeforeLocalVariableDeclarationComma = false,
			SpaceAfterLocalVariableDeclarationComma = true,
			SpaceBeforeIndexerDeclarationBracket = true,
			SpaceWithinIndexerDeclarationBracket = false,
			SpaceBeforeIndexerDeclarationParameterComma = false,
			SpaceInNamedArgumentAfterDoubleColon = true,
			RemoveEndOfLineWhiteSpace = true,
			SpaceAfterIndexerDeclarationParameterComma = true,
			MinimumBlankLinesBeforeUsings = 0,
			MinimumBlankLinesAfterUsings = 1,
			UsingPlacement = UsingPlacement.TopOfFile,
			MinimumBlankLinesBeforeFirstDeclaration = 0,
			MinimumBlankLinesBetweenTypes = 1,
			MinimumBlankLinesBetweenFields = 0,
			MinimumBlankLinesBetweenEventFields = 0,
			MinimumBlankLinesBetweenMembers = 1,
			MinimumBlankLinesAroundRegion = 1,
			MinimumBlankLinesInsideRegion = 1,
			AlignToFirstIndexerArgument = false,
			AlignToFirstIndexerDeclarationParameter = true,
			AlignToFirstMethodCallArgument = false,
			AlignToFirstMethodDeclarationParameter = true,
			KeepCommentsAtFirstColumn = true,
			ChainedMethodCallWrapping = Wrapping.DoNotChange,
			MethodCallArgumentWrapping = Wrapping.DoNotChange,
			NewLineAferMethodCallOpenParentheses = NewLinePlacement.DoNotCare,
			MethodCallClosingParenthesesOnNewLine = NewLinePlacement.DoNotCare,
			IndexerArgumentWrapping = Wrapping.DoNotChange,
			NewLineAferIndexerOpenBracket = NewLinePlacement.DoNotCare,
			IndexerClosingBracketOnNewLine = NewLinePlacement.DoNotCare,
			NewLineBeforeNewQueryClause = NewLinePlacement.NewLine
		};
	}

	public static CSharpFormattingOptions CreateSharpDevelop()
	{
		return CreateKRStyle();
	}

	public static CSharpFormattingOptions CreateKRStyle()
	{
		return new CSharpFormattingOptions
		{
			IndentNamespaceBody = true,
			IndentClassBody = true,
			IndentInterfaceBody = true,
			IndentStructBody = true,
			IndentEnumBody = true,
			IndentMethodBody = true,
			IndentPropertyBody = true,
			IndentEventBody = true,
			IndentBlocks = true,
			IndentSwitchBody = true,
			IndentCaseBody = true,
			IndentBreakStatements = true,
			IndentPreprocessorDirectives = true,
			NamespaceBraceStyle = BraceStyle.NextLine,
			ClassBraceStyle = BraceStyle.NextLine,
			InterfaceBraceStyle = BraceStyle.NextLine,
			StructBraceStyle = BraceStyle.NextLine,
			EnumBraceStyle = BraceStyle.NextLine,
			MethodBraceStyle = BraceStyle.NextLine,
			ConstructorBraceStyle = BraceStyle.NextLine,
			DestructorBraceStyle = BraceStyle.NextLine,
			AnonymousMethodBraceStyle = BraceStyle.EndOfLine,
			PropertyBraceStyle = BraceStyle.EndOfLine,
			PropertyGetBraceStyle = BraceStyle.EndOfLine,
			PropertySetBraceStyle = BraceStyle.EndOfLine,
			SimpleGetBlockFormatting = PropertyFormatting.AllowOneLine,
			SimpleSetBlockFormatting = PropertyFormatting.AllowOneLine,
			EventBraceStyle = BraceStyle.EndOfLine,
			EventAddBraceStyle = BraceStyle.EndOfLine,
			EventRemoveBraceStyle = BraceStyle.EndOfLine,
			AllowEventAddBlockInline = true,
			AllowEventRemoveBlockInline = true,
			StatementBraceStyle = BraceStyle.EndOfLine,
			ElseNewLinePlacement = NewLinePlacement.SameLine,
			ElseIfNewLinePlacement = NewLinePlacement.SameLine,
			CatchNewLinePlacement = NewLinePlacement.SameLine,
			FinallyNewLinePlacement = NewLinePlacement.SameLine,
			WhileNewLinePlacement = NewLinePlacement.SameLine,
			ArrayInitializerWrapping = Wrapping.WrapIfTooLong,
			ArrayInitializerBraceStyle = BraceStyle.EndOfLine,
			SpaceBeforeMethodCallParentheses = false,
			SpaceBeforeMethodDeclarationParentheses = false,
			SpaceBeforeConstructorDeclarationParentheses = false,
			SpaceBeforeDelegateDeclarationParentheses = false,
			SpaceBeforeIndexerDeclarationBracket = false,
			SpaceAfterMethodCallParameterComma = true,
			SpaceAfterConstructorDeclarationParameterComma = true,
			NewLineBeforeConstructorInitializerColon = NewLinePlacement.NewLine,
			NewLineAfterConstructorInitializerColon = NewLinePlacement.SameLine,
			SpaceBeforeNewParentheses = false,
			SpacesWithinNewParentheses = false,
			SpacesBetweenEmptyNewParentheses = false,
			SpaceBeforeNewParameterComma = false,
			SpaceAfterNewParameterComma = true,
			SpaceBeforeIfParentheses = true,
			SpaceBeforeWhileParentheses = true,
			SpaceBeforeForParentheses = true,
			SpaceBeforeForeachParentheses = true,
			SpaceBeforeCatchParentheses = true,
			SpaceBeforeSwitchParentheses = true,
			SpaceBeforeLockParentheses = true,
			SpaceBeforeUsingParentheses = true,
			SpaceAroundAssignment = true,
			SpaceAroundLogicalOperator = true,
			SpaceAroundEqualityOperator = true,
			SpaceAroundRelationalOperator = true,
			SpaceAroundBitwiseOperator = true,
			SpaceAroundAdditiveOperator = true,
			SpaceAroundMultiplicativeOperator = true,
			SpaceAroundShiftOperator = true,
			SpaceAroundNullCoalescingOperator = true,
			SpacesWithinParentheses = false,
			SpaceWithinMethodCallParentheses = false,
			SpaceWithinMethodDeclarationParentheses = false,
			SpacesWithinIfParentheses = false,
			SpacesWithinWhileParentheses = false,
			SpacesWithinForParentheses = false,
			SpacesWithinForeachParentheses = false,
			SpacesWithinCatchParentheses = false,
			SpacesWithinSwitchParentheses = false,
			SpacesWithinLockParentheses = false,
			SpacesWithinUsingParentheses = false,
			SpacesWithinCastParentheses = false,
			SpacesWithinSizeOfParentheses = false,
			SpacesWithinTypeOfParentheses = false,
			SpacesWithinCheckedExpressionParantheses = false,
			SpaceBeforeConditionalOperatorCondition = true,
			SpaceAfterConditionalOperatorCondition = true,
			SpaceBeforeConditionalOperatorSeparator = true,
			SpaceAfterConditionalOperatorSeparator = true,
			SpaceBeforeArrayDeclarationBrackets = false,
			SpacesWithinBrackets = false,
			SpacesBeforeBrackets = false,
			SpaceBeforeBracketComma = false,
			SpaceAfterBracketComma = true,
			SpaceBeforeForSemicolon = false,
			SpaceAfterForSemicolon = true,
			SpaceAfterTypecast = false,
			AlignEmbeddedStatements = true,
			SimplePropertyFormatting = PropertyFormatting.AllowOneLine,
			AutoPropertyFormatting = PropertyFormatting.AllowOneLine,
			EmptyLineFormatting = EmptyLineFormatting.DoNotIndent,
			SpaceBeforeMethodDeclarationParameterComma = false,
			SpaceAfterMethodDeclarationParameterComma = true,
			SpaceAfterDelegateDeclarationParameterComma = true,
			SpaceBeforeFieldDeclarationComma = false,
			SpaceAfterFieldDeclarationComma = true,
			SpaceBeforeLocalVariableDeclarationComma = false,
			SpaceAfterLocalVariableDeclarationComma = true,
			SpaceWithinIndexerDeclarationBracket = false,
			SpaceBeforeIndexerDeclarationParameterComma = false,
			SpaceInNamedArgumentAfterDoubleColon = true,
			SpaceAfterIndexerDeclarationParameterComma = true,
			RemoveEndOfLineWhiteSpace = true,
			MinimumBlankLinesBeforeUsings = 0,
			MinimumBlankLinesAfterUsings = 1,
			MinimumBlankLinesBeforeFirstDeclaration = 0,
			MinimumBlankLinesBetweenTypes = 1,
			MinimumBlankLinesBetweenFields = 0,
			MinimumBlankLinesBetweenEventFields = 0,
			MinimumBlankLinesBetweenMembers = 1,
			MinimumBlankLinesAroundRegion = 1,
			MinimumBlankLinesInsideRegion = 1,
			KeepCommentsAtFirstColumn = true,
			ChainedMethodCallWrapping = Wrapping.DoNotChange,
			MethodCallArgumentWrapping = Wrapping.DoNotChange,
			NewLineAferMethodCallOpenParentheses = NewLinePlacement.DoNotCare,
			MethodCallClosingParenthesesOnNewLine = NewLinePlacement.DoNotCare,
			IndexerArgumentWrapping = Wrapping.DoNotChange,
			NewLineAferIndexerOpenBracket = NewLinePlacement.DoNotCare,
			IndexerClosingBracketOnNewLine = NewLinePlacement.DoNotCare,
			NewLineBeforeNewQueryClause = NewLinePlacement.NewLine
		};
	}

	public static CSharpFormattingOptions CreateAllman()
	{
		CSharpFormattingOptions cSharpFormattingOptions = CreateKRStyle();
		cSharpFormattingOptions.AnonymousMethodBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.PropertyBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.PropertyGetBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.PropertySetBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.EventBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.EventAddBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.EventRemoveBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.StatementBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.ArrayInitializerBraceStyle = BraceStyle.NextLine;
		cSharpFormattingOptions.CatchNewLinePlacement = NewLinePlacement.NewLine;
		cSharpFormattingOptions.ElseNewLinePlacement = NewLinePlacement.NewLine;
		cSharpFormattingOptions.ElseIfNewLinePlacement = NewLinePlacement.SameLine;
		cSharpFormattingOptions.FinallyNewLinePlacement = NewLinePlacement.NewLine;
		cSharpFormattingOptions.WhileNewLinePlacement = NewLinePlacement.DoNotCare;
		cSharpFormattingOptions.ArrayInitializerWrapping = Wrapping.DoNotChange;
		cSharpFormattingOptions.IndentBlocksInsideExpressions = true;
		return cSharpFormattingOptions;
	}

	public static CSharpFormattingOptions CreateWhitesmiths()
	{
		CSharpFormattingOptions cSharpFormattingOptions = CreateKRStyle();
		cSharpFormattingOptions.NamespaceBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.ClassBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.InterfaceBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.StructBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.EnumBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.MethodBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.ConstructorBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.DestructorBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.AnonymousMethodBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.PropertyBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.PropertyGetBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.PropertySetBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.EventBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.EventAddBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.EventRemoveBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.StatementBraceStyle = BraceStyle.NextLineShifted;
		cSharpFormattingOptions.IndentBlocksInsideExpressions = true;
		return cSharpFormattingOptions;
	}

	public static CSharpFormattingOptions CreateGNU()
	{
		CSharpFormattingOptions cSharpFormattingOptions = CreateAllman();
		cSharpFormattingOptions.StatementBraceStyle = BraceStyle.NextLineShifted2;
		return cSharpFormattingOptions;
	}
}

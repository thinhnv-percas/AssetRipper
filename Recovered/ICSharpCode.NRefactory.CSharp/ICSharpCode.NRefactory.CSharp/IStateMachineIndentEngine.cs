using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public interface IStateMachineIndentEngine : IDocumentIndentEngine, ICloneable
	{
		bool IsInsidePreprocessorDirective
		{
			get;
		}

		bool IsInsidePreprocessorComment
		{
			get;
		}

		bool IsInsideStringLiteral
		{
			get;
		}

		bool IsInsideVerbatimString
		{
			get;
		}

		bool IsInsideCharacter
		{
			get;
		}

		bool IsInsideString
		{
			get;
		}

		bool IsInsideLineComment
		{
			get;
		}

		bool IsInsideMultiLineComment
		{
			get;
		}

		bool IsInsideDocLineComment
		{
			get;
		}

		bool IsInsideComment
		{
			get;
		}

		bool IsInsideOrdinaryComment
		{
			get;
		}

		bool IsInsideOrdinaryCommentOrString
		{
			get;
		}

		bool LineBeganInsideVerbatimString
		{
			get;
		}

		bool LineBeganInsideMultiLineComment
		{
			get;
		}

		new IStateMachineIndentEngine Clone();
	}
}

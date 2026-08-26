using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public abstract class DecoratingTokenWriter : TokenWriter
	{
		private TokenWriter decoratedWriter;

		protected DecoratingTokenWriter(TokenWriter decoratedWriter)
		{
			if (decoratedWriter == null)
			{
				throw new ArgumentNullException("decoratedWriter");
			}
			this.decoratedWriter = decoratedWriter;
		}

		public override void StartNode(AstNode node)
		{
			decoratedWriter.StartNode(node);
		}

		public override void EndNode(AstNode node)
		{
			decoratedWriter.EndNode(node);
		}

		public override void WriteIdentifier(Identifier identifier)
		{
			decoratedWriter.WriteIdentifier(identifier);
		}

		public override void WriteKeyword(Role role, string keyword)
		{
			decoratedWriter.WriteKeyword(role, keyword);
		}

		public override void WriteToken(Role role, string token)
		{
			decoratedWriter.WriteToken(role, token);
		}

		public override void WritePrimitiveValue(object value, string literalValue = null)
		{
			decoratedWriter.WritePrimitiveValue(value, literalValue);
		}

		public override void WritePrimitiveType(string type)
		{
			decoratedWriter.WritePrimitiveType(type);
		}

		public override void Space()
		{
			decoratedWriter.Space();
		}

		public override void Indent()
		{
			decoratedWriter.Indent();
		}

		public override void Unindent()
		{
			decoratedWriter.Unindent();
		}

		public override void NewLine()
		{
			decoratedWriter.NewLine();
		}

		public override void WriteComment(CommentType commentType, string content)
		{
			decoratedWriter.WriteComment(commentType, content);
		}

		public override void WritePreProcessorDirective(PreProcessorDirectiveType type, string argument)
		{
			decoratedWriter.WritePreProcessorDirective(type, argument);
		}
	}
}

using ICSharpCode.NRefactory.Refactoring;
using System;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class CodeAction
	{
		private Severity severity = Severity.Suggestion;

		private const string defaultSiblingKey = "default";

		public string Description
		{
			get;
			private set;
		}

		public Action<Script> Run
		{
			get;
			private set;
		}

		public TextLocation Start
		{
			get;
			private set;
		}

		public TextLocation End
		{
			get;
			private set;
		}

		public object SiblingKey
		{
			get;
			private set;
		}

		public Severity Severity
		{
			get
			{
				return severity;
			}
			set
			{
				severity = value;
			}
		}

		public CodeAction(string description, Action<Script> action, AstNode astNode)
			: this(description, action, astNode, "default")
		{
		}

		public CodeAction(string description, Action<Script> action, AstNode astNode, object siblingKey)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			if (description == null)
			{
				throw new ArgumentNullException("description");
			}
			if (astNode == null)
			{
				throw new ArgumentNullException("astNode");
			}
			Description = description;
			Run = action;
			Start = astNode.StartLocation;
			End = astNode.EndLocation;
			SiblingKey = siblingKey;
		}

		public CodeAction(string description, Action<Script> action, TextLocation start, TextLocation end)
			: this(description, action, start, end, "default")
		{
			SiblingKey = "default";
		}

		public CodeAction(string description, Action<Script> action, TextLocation start, TextLocation end, object siblingKey)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			if (description == null)
			{
				throw new ArgumentNullException("description");
			}
			Description = description;
			Run = action;
			Start = start;
			End = end;
			SiblingKey = siblingKey;
		}
	}
}

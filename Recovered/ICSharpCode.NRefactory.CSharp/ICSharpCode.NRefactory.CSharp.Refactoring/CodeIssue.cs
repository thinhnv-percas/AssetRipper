using ICSharpCode.NRefactory.Refactoring;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class CodeIssue
	{
		private List<Type> actionProvider = new List<Type>();

		public string Description
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

		public IList<CodeAction> Actions
		{
			get;
			private set;
		}

		public List<Type> ActionProvider
		{
			get
			{
				return actionProvider;
			}
			set
			{
				actionProvider = value;
			}
		}

		public IssueMarker IssueMarker
		{
			get;
			set;
		}

		public CodeIssue(TextLocation start, TextLocation end, string issueDescription)
		{
			if (issueDescription == null)
			{
				throw new ArgumentNullException("issueDescription");
			}
			Description = issueDescription;
			Start = start;
			End = end;
			Actions = EmptyList<CodeAction>.Instance;
			IssueMarker = IssueMarker.WavedLine;
		}

		public CodeIssue(TextLocation start, TextLocation end, string issueDescription, IEnumerable<CodeAction> actions)
			: this(start, end, issueDescription)
		{
			if (actions != null)
			{
				Actions = actions.ToArray();
			}
		}

		public CodeIssue(TextLocation start, TextLocation end, string issueDescription, params CodeAction[] actions)
			: this(start, end, issueDescription)
		{
			if (actions != null)
			{
				Actions = actions;
			}
		}

		public CodeIssue(TextLocation start, TextLocation end, string issueDescription, string actionDescription, Action<Script> fix)
			: this(start, end, issueDescription)
		{
			if (actionDescription == null)
			{
				throw new ArgumentNullException("actionDescription");
			}
			if (fix == null)
			{
				throw new ArgumentNullException("fix");
			}
			Actions = new CodeAction[1]
			{
				new CodeAction(actionDescription, fix, start, end)
			};
		}

		public CodeIssue(AstNode node, string issueDescription)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			if (issueDescription == null)
			{
				throw new ArgumentNullException("issueDescription");
			}
			Description = issueDescription;
			Start = node.StartLocation;
			End = node.EndLocation;
			Actions = EmptyList<CodeAction>.Instance;
			IssueMarker = IssueMarker.WavedLine;
		}

		public CodeIssue(AstNode node, string issueDescription, IEnumerable<CodeAction> actions)
			: this(node, issueDescription)
		{
			if (actions != null)
			{
				Actions = actions.ToArray();
			}
		}

		public CodeIssue(AstNode node, string issueDescription, params CodeAction[] actions)
			: this(node, issueDescription)
		{
			if (actions != null)
			{
				Actions = actions;
			}
		}

		public CodeIssue(AstNode node, string issueDescription, string actionDescription, Action<Script> fix)
			: this(node, issueDescription)
		{
			if (actionDescription == null)
			{
				throw new ArgumentNullException("actionDescription");
			}
			if (fix == null)
			{
				throw new ArgumentNullException("fix");
			}
			Actions = new CodeAction[1]
			{
				new CodeAction(actionDescription, fix, node)
			};
		}
	}
}

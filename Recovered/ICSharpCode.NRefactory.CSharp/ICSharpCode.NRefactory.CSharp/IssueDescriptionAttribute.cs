using ICSharpCode.NRefactory.Refactoring;
using System;

namespace ICSharpCode.NRefactory.CSharp
{
	[AttributeUsage(AttributeTargets.Class)]
	public class IssueDescriptionAttribute : System.Attribute
	{
		public string Title
		{
			get;
			private set;
		}

		public string Description
		{
			get;
			set;
		}

		public string Category
		{
			get;
			set;
		}

		public string AnalysisDisableKeyword
		{
			get;
			set;
		}

		public string SuppressMessageCategory
		{
			get;
			set;
		}

		public string SuppressMessageCheckId
		{
			get;
			set;
		}

		public int PragmaWarning
		{
			get;
			set;
		}

		public bool IsEnabledByDefault
		{
			get;
			set;
		}

		public bool SupportsAutoFix
		{
			get;
			set;
		}

		public Severity Severity
		{
			get;
			set;
		}

		public IssueDescriptionAttribute(string title)
		{
			Title = title;
			Severity = Severity.Suggestion;
			IsEnabledByDefault = true;
		}
	}
}

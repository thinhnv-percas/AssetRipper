using ICSharpCode.NRefactory.Refactoring;
using System;

namespace ICSharpCode.NRefactory.CSharp
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class SubIssueAttribute : System.Attribute
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

		public bool? IsEnabledByDefault
		{
			get;
			set;
		}

		public Severity? Severity
		{
			get;
			set;
		}

		public SubIssueAttribute(string title)
		{
			Title = title;
		}

		public SubIssueAttribute(string title, Severity severity)
		{
			Title = title;
			Severity = severity;
		}

		public SubIssueAttribute(string title, bool isEnabledByDefault)
		{
			Title = title;
			IsEnabledByDefault = isEnabledByDefault;
		}

		public SubIssueAttribute(string title, Severity severity, bool isEnabledByDefault)
		{
			Title = title;
			Severity = severity;
			IsEnabledByDefault = isEnabledByDefault;
		}
	}
}

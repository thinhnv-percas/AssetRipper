using System;

namespace ICSharpCode.NRefactory.CSharp
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ContextActionAttribute : System.Attribute
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

		public ContextActionAttribute(string title)
		{
			Title = title;
		}
	}
}

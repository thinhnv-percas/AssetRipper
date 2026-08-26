using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public abstract class CodeIssueProvider
	{
		private SubIssueAttribute[] subIssueAttributes;

		private static readonly SubIssueAttribute[] emptyAttributes = new SubIssueAttribute[0];

		public bool HasSubIssues
		{
			get
			{
				Initialize();
				return subIssueAttributes.Length != 0;
			}
		}

		public IEnumerable<SubIssueAttribute> SubIssues
		{
			get
			{
				Initialize();
				return subIssueAttributes;
			}
		}

		private void Initialize()
		{
			if (subIssueAttributes == null)
			{
				subIssueAttributes = (GetType().GetCustomAttributes(typeof(SubIssueAttribute), inherit: false).OfType<SubIssueAttribute>().ToArray() ?? emptyAttributes);
			}
		}

		public virtual IEnumerable<CodeIssue> GetIssues(BaseRefactoringContext context, string subIssue = null)
		{
			return GetIssues(context);
		}
	}
}

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IHasAccessibility
	{
		Accessibility Accessibility
		{
			get;
		}

		bool IsPrivate
		{
			get;
		}

		bool IsPublic
		{
			get;
		}

		bool IsProtected
		{
			get;
		}

		bool IsInternal
		{
			get;
		}

		bool IsProtectedOrInternal
		{
			get;
		}

		bool IsProtectedAndInternal
		{
			get;
		}
	}
}

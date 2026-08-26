namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IAssemblyDefinition
	{
		string FullName
		{
			get;
		}

		bool IsCLSCompliant
		{
			get;
		}

		bool IsMissing
		{
			get;
		}

		string Name
		{
			get;
		}

		byte[] GetPublicKeyToken();

		bool IsFriendAssemblyTo(IAssemblyDefinition assembly);
	}
}

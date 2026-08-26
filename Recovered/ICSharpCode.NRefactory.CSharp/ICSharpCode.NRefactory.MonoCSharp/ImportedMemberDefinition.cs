using System.Reflection;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal class ImportedMemberDefinition : ImportedDefinition
	{
		private readonly TypeSpec type;

		public TypeSpec MemberType => type;

		public ImportedMemberDefinition(MemberInfo member, TypeSpec type, MetadataImporter importer)
			: base(member, importer)
		{
			this.type = type;
		}
	}
}

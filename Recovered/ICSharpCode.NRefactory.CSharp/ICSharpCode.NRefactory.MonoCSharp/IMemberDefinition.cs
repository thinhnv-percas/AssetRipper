using System;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IMemberDefinition
	{
		bool? CLSAttributeValue
		{
			get;
		}

		string Name
		{
			get;
		}

		bool IsImported
		{
			get;
		}

		string[] ConditionalConditions();

		ObsoleteAttribute GetAttributeObsolete();

		void SetIsAssigned();

		void SetIsUsed();
	}
}

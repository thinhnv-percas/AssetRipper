using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public interface ICompletionDataFactory
	{
		ICompletionData CreateEntityCompletionData(IEntity entity);

		ICompletionData CreateEntityCompletionData(IEntity entity, string text);

		ICompletionData CreateTypeCompletionData(IType type, bool showFullName, bool isInAttributeContext, bool addForTypeCreation);

		ICompletionData CreateMemberCompletionData(IType type, IEntity member);

		ICompletionData CreateLiteralCompletionData(string title, string description = null, string insertText = null);

		ICompletionData CreateNamespaceCompletionData(INamespace name);

		ICompletionData CreateVariableCompletionData(IVariable variable);

		ICompletionData CreateVariableCompletionData(ITypeParameter parameter);

		ICompletionData CreateEventCreationCompletionData(string delegateMethodName, IType delegateType, IEvent evt, string parameterDefinition, IUnresolvedMember currentMember, IUnresolvedTypeDefinition currentType);

		ICompletionData CreateNewOverrideCompletionData(int declarationBegin, IUnresolvedTypeDefinition type, IMember m);

		ICompletionData CreateNewPartialCompletionData(int declarationBegin, IUnresolvedTypeDefinition type, IUnresolvedMember m);

		IEnumerable<ICompletionData> CreateCodeTemplateCompletionData();

		IEnumerable<ICompletionData> CreatePreProcessorDefinesCompletionData();

		ICompletionData CreateImportCompletionData(IType type, bool useFullName, bool addForTypeCreation);

		ICompletionData CreateFormatItemCompletionData(string format, string description, object example);

		ICompletionData CreateXmlDocCompletionData(string tag, string description = null, string tagInsertionText = null);
	}
}

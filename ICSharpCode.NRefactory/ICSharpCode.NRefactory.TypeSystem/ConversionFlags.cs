using System;

namespace ICSharpCode.NRefactory.TypeSystem;

[Flags]
public enum ConversionFlags
{
	None = 0,
	ShowParameterList = 1,
	ShowParameterNames = 2,
	ShowAccessibility = 4,
	ShowDefinitionKeyword = 8,
	ShowDeclaringType = 0x10,
	ShowModifiers = 0x20,
	ShowReturnType = 0x40,
	UseFullyQualifiedTypeNames = 0x80,
	ShowTypeParameterList = 0x100,
	ShowBody = 0x200,
	UseFullyQualifiedEntityNames = 0x400,
	StandardConversionFlags = ShowParameterList | ShowParameterNames | ShowAccessibility | ShowDefinitionKeyword | ShowModifiers | ShowReturnType | ShowTypeParameterList | ShowBody,
	All = StandardConversionFlags | ShowDeclaringType | UseFullyQualifiedTypeNames | UseFullyQualifiedEntityNames
}

using System;

namespace dnSpy.Contracts.Decompiler;

[Flags]
public enum FormatterOptions
{
	ShowModuleNames = 1,
	ShowParameterTypes = 2,
	ShowParameterNames = 4,
	ShowDeclaringTypes = 8,
	ShowReturnTypes = 0x10,
	ShowNamespaces = 0x20,
	ShowIntrinsicTypeKeywords = 0x40,
	UseDecimal = 0x80,
	ShowTokens = 0x100,
	ShowArrayValueSizes = 0x200,
	ShowFieldLiteralValues = 0x400,
	ShowParameterLiteralValues = 0x800,
	DigitSeparators = 0x1000,
	Default = ShowParameterTypes | ShowParameterNames | ShowDeclaringTypes | ShowReturnTypes | ShowIntrinsicTypeKeywords | ShowFieldLiteralValues
}

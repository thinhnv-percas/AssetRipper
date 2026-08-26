using System;

namespace ICSharpCode.NRefactory.TypeSystem
{
	[Flags]
	public enum ConversionFlags
	{
		None = 0x0,
		ShowParameterList = 0x1,
		ShowParameterNames = 0x2,
		ShowAccessibility = 0x4,
		ShowDefinitionKeyword = 0x8,
		ShowDeclaringType = 0x10,
		ShowModifiers = 0x20,
		ShowReturnType = 0x40,
		UseFullyQualifiedTypeNames = 0x80,
		ShowTypeParameterList = 0x100,
		ShowBody = 0x200,
		UseFullyQualifiedEntityNames = 0x400,
		StandardConversionFlags = 0x36F,
		All = 0x7FF
	}
}

using System;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

[Flags]
public enum OverloadResolutionErrors
{
	None = 0,
	TooManyPositionalArguments = 1,
	NoParameterFoundForNamedArgument = 2,
	TypeInferenceFailed = 4,
	WrongNumberOfTypeArguments = 8,
	ConstructedTypeDoesNotSatisfyConstraint = 0x10,
	MissingArgumentForRequiredParameter = 0x20,
	MultipleArgumentsForSingleParameter = 0x40,
	ParameterPassingModeMismatch = 0x80,
	ArgumentTypeMismatch = 0x100,
	AmbiguousMatch = 0x200,
	Inaccessible = 0x400,
	MethodConstraintsNotSatisfied = 0x800
}

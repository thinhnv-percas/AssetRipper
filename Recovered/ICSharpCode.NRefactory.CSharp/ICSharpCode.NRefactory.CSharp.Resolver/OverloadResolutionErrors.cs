using System;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	[Flags]
	public enum OverloadResolutionErrors
	{
		None = 0x0,
		TooManyPositionalArguments = 0x1,
		NoParameterFoundForNamedArgument = 0x2,
		TypeInferenceFailed = 0x4,
		WrongNumberOfTypeArguments = 0x8,
		ConstructedTypeDoesNotSatisfyConstraint = 0x10,
		MissingArgumentForRequiredParameter = 0x20,
		MultipleArgumentsForSingleParameter = 0x40,
		ParameterPassingModeMismatch = 0x80,
		ArgumentTypeMismatch = 0x100,
		AmbiguousMatch = 0x200,
		Inaccessible = 0x400,
		MethodConstraintsNotSatisfied = 0x800
	}
}

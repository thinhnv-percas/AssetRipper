using Mono.CompilerServices.SymbolWriter;
using System.Reflection;
using System.Reflection.Emit;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IMethodData : IMemberContext, IModuleContext
	{
		CallingConventions CallingConventions
		{
			get;
		}

		Location Location
		{
			get;
		}

		MemberName MethodName
		{
			get;
		}

		TypeSpec ReturnType
		{
			get;
		}

		ParametersCompiled ParameterInfo
		{
			get;
		}

		MethodSpec Spec
		{
			get;
		}

		bool IsAccessor
		{
			get;
		}

		Attributes OptAttributes
		{
			get;
		}

		ToplevelBlock Block
		{
			get;
			set;
		}

		EmitContext CreateEmitContext(ILGenerator ig, SourceMethodBuilder sourceMethod);
	}
}

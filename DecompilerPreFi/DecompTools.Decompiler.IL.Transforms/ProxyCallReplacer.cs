#define STEP
using System.Collections;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

internal class ProxyCallReplacer : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		foreach (CallInstruction item in Enumerable.OfType<CallInstruction>((IEnumerable)function.Descendants))
		{
			Run(item, context);
		}
	}

	private void Run(CallInstruction inst, ILTransformContext context)
	{
		if (inst.Method.IsStatic || inst.Method.MetadataToken.IsNil || inst.Method.MetadataToken.Kind != HandleKind.MethodDefinition)
		{
			return;
		}
		MethodDefinitionHandle method = (MethodDefinitionHandle)inst.Method.MetadataToken;
		if (!IsDefinedInCurrentOrOuterClass(inst.Method, context.Function.Method.DeclaringTypeDefinition) || !inst.Method.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
		{
			return;
		}
		MetadataReader metadata = context.PEFile.Metadata;
		MethodDefinition methodDefinition = metadata.GetMethodDefinition((MethodDefinitionHandle)inst.Method.MetadataToken);
		if (!methodDefinition.HasBody())
		{
			return;
		}
		GenericContext? genericContext = DelegateConstruction.GenericContextFromTypeArguments(inst.Method.Substitution);
		if (!genericContext.HasValue)
		{
			return;
		}
		ILReader iLReader = context.CreateILReader();
		MethodBodyBlock methodBody = context.PEFile.Reader.GetMethodBody(methodDefinition.RelativeVirtualAddress);
		ILFunction iLFunction = iLReader.ReadIL(method, methodBody, genericContext.Value, context.CancellationToken);
		ILTransformContext context2 = new ILTransformContext(context, iLFunction);
		iLFunction.RunTransforms(CSharpDecompiler.EarlyILTransforms(), context2);
		if (!(iLFunction.Body is BlockContainer blockContainer) || blockContainer.Blocks.Count != 1)
		{
			return;
		}
		Block block = blockContainer.Blocks[0];
		ILInstruction value;
		Call call;
		switch (block.Instructions.Count)
		{
		default:
			return;
		case 1:
			if (!block.Instructions[0].MatchLeave(blockContainer, out value))
			{
				return;
			}
			call = value as Call;
			break;
		case 2:
			call = block.Instructions[0] as Call;
			if (!block.Instructions[1].MatchLeave(blockContainer, out value) || !value.MatchNop())
			{
				return;
			}
			break;
		}
		if (call == null || call.Method.IsConstructor || call.Method.IsStatic || call.Method.Parameters.Count != inst.Method.Parameters.Count)
		{
			return;
		}
		checked
		{
			for (int i = 0; i < call.Arguments.Count; i++)
			{
				ILInstruction iLInstruction = call.Arguments[i];
				if (!iLInstruction.MatchLdLoc(out var variable) || variable.Kind != VariableKind.Parameter || variable.Index != i - 1)
				{
					return;
				}
			}
			context.Step("Replace proxy: " + inst.Method.Name + " with " + call.Method.Name, inst);
			Call call2 = (Call)call.Clone();
			call2.Arguments.ReplaceList(inst.Arguments);
			inst.ReplaceWith(call2);
		}
	}

	private static bool IsDefinedInCurrentOrOuterClass(IMethod method, ITypeDefinition declaringTypeDefinition)
	{
		while (declaringTypeDefinition != null)
		{
			if (method.DeclaringTypeDefinition == declaringTypeDefinition)
			{
				return true;
			}
			declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition;
		}
		return false;
	}
}

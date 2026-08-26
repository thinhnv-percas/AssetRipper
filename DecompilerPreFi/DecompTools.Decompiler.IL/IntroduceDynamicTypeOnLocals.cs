using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

internal class IntroduceDynamicTypeOnLocals : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		foreach (ILVariable variable in function.Variables)
		{
			if ((variable.Kind != VariableKind.Local && variable.Kind != VariableKind.StackSlot && variable.Kind != VariableKind.ForeachLocal && variable.Kind != VariableKind.UsingLocal) || !variable.Type.IsKnownType(KnownTypeCode.Object) || variable.LoadCount == 0)
			{
				continue;
			}
			foreach (LdLoc loadInstruction in variable.LoadInstructions)
			{
				if (loadInstruction.Parent is DynamicInstruction dynamicInstruction && !dynamicInstruction.GetArgumentInfoOfChild(loadInstruction.ChildIndex).HasFlag(CSharpArgumentInfoFlags.UseCompileTimeType))
				{
					variable.Type = SpecialType.Dynamic;
				}
			}
		}
	}
}

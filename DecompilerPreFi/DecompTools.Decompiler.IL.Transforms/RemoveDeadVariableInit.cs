using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

public class RemoveDeadVariableInit : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		DefiniteAssignmentVisitor definiteAssignmentVisitor = new DefiniteAssignmentVisitor(function, context.CancellationToken);
		function.Body.AcceptVisitor(definiteAssignmentVisitor);
		foreach (ILVariable variable in function.Variables)
		{
			if (variable.Kind != VariableKind.Parameter && !definiteAssignmentVisitor.IsPotentiallyUsedUninitialized(variable))
			{
				variable.HasInitialValue = false;
			}
		}
		if (function.IsAsync || function.IsIterator || context.Settings.RemoveDeadCode)
		{
			Queue<ILVariable> queue = new Queue<ILVariable>(function.Variables);
			while (queue.Count > 0)
			{
				ILVariable iLVariable = queue.Dequeue();
				if ((iLVariable.Kind != VariableKind.Local && iLVariable.Kind != VariableKind.StackSlot) || iLVariable.LoadCount != 0 || iLVariable.AddressCount != 0)
				{
					continue;
				}
				StLoc[] array = Enumerable.ToArray<StLoc>(Enumerable.OfType<StLoc>((IEnumerable)iLVariable.StoreInstructions));
				foreach (StLoc stLoc in array)
				{
					if (stLoc.Parent is Block block)
					{
						if (SemanticHelper.IsPure(stLoc.Value.Flags))
						{
							block.Instructions.Remove(stLoc);
						}
						else
						{
							stLoc.ReplaceWith(stLoc.Value);
						}
						if (stLoc.Value is LdLoc ldLoc)
						{
							queue.Enqueue(ldLoc.Variable);
						}
					}
				}
			}
		}
		foreach (ILVariable variable2 in function.Variables)
		{
			if (variable2.Kind != VariableKind.StackSlot || variable2.StackType != StackType.Ref || variable2.AddressCount != 0)
			{
				continue;
			}
			IType type = null;
			foreach (StLoc item in Enumerable.OfType<StLoc>((IEnumerable)variable2.StoreInstructions))
			{
				IType type2 = item.Value.InferType(context.TypeSystem);
				if (type != null && !type.Equals(type2))
				{
					type = SpecialType.UnknownType;
					break;
				}
				type = type2;
			}
			if (type != null && type != SpecialType.UnknownType)
			{
				variable2.Type = type;
			}
		}
	}
}

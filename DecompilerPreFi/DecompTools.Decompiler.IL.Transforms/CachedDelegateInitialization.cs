#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DecompTools.Decompiler.IL.Transforms;

public class CachedDelegateInitialization : IBlockTransform
{
	private BlockTransformContext context;

	public void Run(Block block, BlockTransformContext context)
	{
		this.context = context;
		if (!context.Settings.AnonymousMethods)
		{
			return;
		}
		checked
		{
			for (int num = block.Instructions.Count - 1; num >= 0; num--)
			{
				if (block.Instructions[num] is IfInstruction inst)
				{
					if (CachedDelegateInitializationWithField(inst))
					{
						block.Instructions.RemoveAt(num);
					}
					else if (CachedDelegateInitializationWithLocal(inst))
					{
						ILInlining.InlineOneIfPossible(block, num, InliningOptions.Aggressive, context);
					}
					else if (CachedDelegateInitializationRoslynInStaticWithLocal(inst) || CachedDelegateInitializationRoslynWithLocal(inst))
					{
						block.Instructions.RemoveAt(num);
					}
				}
			}
		}
	}

	private bool CachedDelegateInitializationWithField(IfInstruction inst)
	{
		if (!(inst.TrueInst is Block block) || block.Instructions.Count != 1 || !inst.FalseInst.MatchNop())
		{
			return false;
		}
		ILInstruction iLInstruction = block.Instructions[0];
		if (!inst.Condition.MatchCompEquals(out var left, out var right) || !left.MatchLdsFld(out var field) || !right.MatchLdNull())
		{
			return false;
		}
		if (!iLInstruction.MatchStsFld(out var field2, out var value) || !field.Equals(field2) || !field.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
		{
			return false;
		}
		if (!DelegateConstruction.IsDelegateConstruction(value as NewObj, allowTransformed: true))
		{
			return false;
		}
		ILInstruction iLInstruction2 = Enumerable.ElementAtOrDefault<ILInstruction>((IEnumerable<ILInstruction>)inst.Parent.Children, checked(inst.ChildIndex + 1));
		if (iLInstruction2 == null)
		{
			return false;
		}
		ILInstruction[] array = Enumerable.ToArray<ILInstruction>(Enumerable.Where<ILInstruction>(iLInstruction2.Descendants, (Func<ILInstruction, bool>)((ILInstruction i) => i.MatchLdsFld(field))));
		if (array.Length != 1)
		{
			return false;
		}
		context.Step("CachedDelegateInitializationWithField", inst);
		array[0].ReplaceWith(value);
		return true;
	}

	private bool CachedDelegateInitializationWithLocal(IfInstruction inst)
	{
		if (!(inst.TrueInst is Block block) || block.Instructions.Count != 1 || !inst.FalseInst.MatchNop())
		{
			return false;
		}
		if (!inst.Condition.MatchCompEquals(out var left, out var right) || !left.MatchLdLoc(out var v) || !right.MatchLdNull())
		{
			return false;
		}
		ILInstruction storeInst = block.Instructions.Last();
		if (!storeInst.MatchStLoc(v, out var value))
		{
			return false;
		}
		if (!DelegateConstruction.IsDelegateConstruction(value as NewObj, allowTransformed: true))
		{
			return false;
		}
		if (v.StoreCount != 2 || v.StoreInstructions.Count != 2 || v.LoadCount != 2 || v.AddressCount != 0)
		{
			return false;
		}
		StLoc stLoc = Enumerable.SingleOrDefault<StLoc>(Enumerable.OfType<StLoc>((IEnumerable)v.StoreInstructions), (Func<StLoc, bool>)((StLoc store) => store != storeInst));
		if (stLoc == null || !stLoc.Value.MatchLdNull() || !(stLoc.Parent is Block))
		{
			return false;
		}
		ILInstruction iLInstruction = Enumerable.ElementAtOrDefault<ILInstruction>((IEnumerable<ILInstruction>)inst.Parent.Children, checked(inst.ChildIndex + 1));
		if (iLInstruction == null)
		{
			return false;
		}
		ILInstruction[] array = Enumerable.ToArray<ILInstruction>(Enumerable.Where<ILInstruction>(iLInstruction.Descendants, (Func<ILInstruction, bool>)((ILInstruction i) => i.MatchLdLoc(v))));
		if (array.Length != 1)
		{
			return false;
		}
		context.Step("CachedDelegateInitializationWithLocal", inst);
		((Block)stLoc.Parent).Instructions.Remove(stLoc);
		inst.ReplaceWith(storeInst);
		return true;
	}

	private bool CachedDelegateInitializationRoslynInStaticWithLocal(IfInstruction inst)
	{
		if (!(inst.TrueInst is Block block) || block.Instructions.Count != 1 || !inst.FalseInst.MatchNop())
		{
			return false;
		}
		if (!inst.Condition.MatchCompEquals(out var left, out var right) || !left.MatchLdLoc(out var variable) || !right.MatchLdNull())
		{
			return false;
		}
		StLoc stLoc = block.Instructions.Last() as StLoc;
		if (!(Enumerable.ElementAtOrDefault<ILInstruction>((IEnumerable<ILInstruction>)inst.Parent.Children, checked(inst.ChildIndex - 1)) is StLoc stLoc2) || stLoc == null || stLoc2.Variable != variable || stLoc.Variable != variable)
		{
			return false;
		}
		if (!(stLoc.Value is StObj stObj) || !(stLoc2.Value is LdObj ldObj))
		{
			return false;
		}
		if (!(stObj.Value is NewObj))
		{
			return false;
		}
		if (!stObj.Target.MatchLdsFlda(out var field) || !ldObj.Target.MatchLdsFlda(out var field2) || !field.Equals(field2))
		{
			return false;
		}
		if (!DelegateConstruction.IsDelegateConstruction((NewObj)stObj.Value, allowTransformed: true))
		{
			return false;
		}
		context.Step("CachedDelegateInitializationRoslynInStaticWithLocal", inst);
		stLoc2.Value = stObj.Value;
		return true;
	}

	private bool CachedDelegateInitializationRoslynWithLocal(IfInstruction inst)
	{
		if (!(inst.TrueInst is Block block) || block.Instructions.Count != 1 || !inst.FalseInst.MatchNop())
		{
			return false;
		}
		if (!inst.Condition.MatchCompEquals(out var left, out var right) || !left.MatchLdLoc(out var variable) || !right.MatchLdNull())
		{
			return false;
		}
		StLoc stLoc = block.Instructions.Last() as StLoc;
		if (!(Enumerable.ElementAtOrDefault<ILInstruction>((IEnumerable<ILInstruction>)inst.Parent.Children, checked(inst.ChildIndex - 1)) is StLoc stLoc2) || stLoc == null || stLoc2.Variable != variable || stLoc.Variable != variable)
		{
			return false;
		}
		if (!(stLoc.Value is StObj stObj) || !(stLoc2.Value is LdObj ldObj))
		{
			return false;
		}
		if (!(stObj.Value is NewObj))
		{
			return false;
		}
		if (!stObj.Target.MatchLdFlda(out var _, out var field) || !ldObj.Target.MatchLdFlda(out var _, out var field2) || !field.Equals(field2))
		{
			return false;
		}
		if (!DelegateConstruction.IsDelegateConstruction((NewObj)stObj.Value, allowTransformed: true))
		{
			return false;
		}
		context.Step("CachedDelegateInitializationRoslynWithLocal", inst);
		stLoc2.Value = stObj.Value;
		return true;
	}
}

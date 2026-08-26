#define STEP
using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

internal class UsingTransform : IBlockTransform
{
	private BlockTransformContext context;

	void IBlockTransform.Run(Block block, BlockTransformContext context)
	{
		if (!context.Settings.UsingStatement)
		{
			return;
		}
		this.context = context;
		checked
		{
			for (int num = block.Instructions.Count - 1; num >= 0; num--)
			{
				if ((TransformUsing(block, num) || TransformUsingVB(block, num)) && num >= block.Instructions.Count)
				{
					num = block.Instructions.Count;
				}
			}
		}
	}

	private bool TransformUsing(Block block, int i)
	{
		if (i < 1)
		{
			return false;
		}
		checked
		{
			TryFinally tryFinally;
			if ((tryFinally = block.Instructions[i] as TryFinally) == null || !(block.Instructions[i - 1] is StLoc stLoc))
			{
				return false;
			}
			if (!stLoc.Value.MatchLdNull() && !CheckResourceType(stLoc.Variable.Type))
			{
				return false;
			}
			if (Enumerable.Any<LdLoc>((IEnumerable<LdLoc>)stLoc.Variable.LoadInstructions, (Func<LdLoc, bool>)((LdLoc ld) => !ld.IsDescendantOf(tryFinally))))
			{
				return false;
			}
			if (Enumerable.Any<LdLoca>((IEnumerable<LdLoca>)stLoc.Variable.AddressInstructions, (Func<LdLoca, bool>)((LdLoca la) => !la.IsDescendantOf(tryFinally) || (la.IsDescendantOf(tryFinally.TryBlock) && !ILInlining.IsUsedAsThisPointerInCall(la)))))
			{
				return false;
			}
			if (stLoc.Variable.StoreInstructions.Count > 1)
			{
				return false;
			}
			if (!(tryFinally.FinallyBlock is BlockContainer container) || !MatchDisposeBlock(container, stLoc.Variable, stLoc.Value.MatchLdNull()))
			{
				return false;
			}
			context.Step("UsingTransform", tryFinally);
			stLoc.Variable.Kind = VariableKind.UsingLocal;
			block.Instructions.RemoveAt(i);
			block.Instructions[i - 1] = new UsingInstruction(stLoc.Variable, stLoc.Value, tryFinally.TryBlock).WithILRange(stLoc);
			return true;
		}
	}

	private bool TransformUsingVB(Block block, int i)
	{
		TryFinally tryFinally;
		if ((tryFinally = block.Instructions[i] as TryFinally) == null)
		{
			return false;
		}
		if (!(tryFinally.TryBlock is BlockContainer blockContainer) || !(blockContainer.EntryPoint.Instructions.FirstOrDefault() is StLoc stLoc))
		{
			return false;
		}
		if (!stLoc.Value.MatchLdNull() && !CheckResourceType(stLoc.Variable.Type))
		{
			return false;
		}
		if (Enumerable.Any<LdLoc>((IEnumerable<LdLoc>)stLoc.Variable.LoadInstructions, (Func<LdLoc, bool>)((LdLoc ld) => !ld.IsDescendantOf(tryFinally))))
		{
			return false;
		}
		if (Enumerable.Any<LdLoca>((IEnumerable<LdLoca>)stLoc.Variable.AddressInstructions, (Func<LdLoca, bool>)((LdLoca la) => !la.IsDescendantOf(tryFinally) || (la.IsDescendantOf(tryFinally.TryBlock) && !ILInlining.IsUsedAsThisPointerInCall(la)))))
		{
			return false;
		}
		if (stLoc.Variable.StoreInstructions.Count > 1)
		{
			return false;
		}
		if (!(tryFinally.FinallyBlock is BlockContainer container) || !MatchDisposeBlock(container, stLoc.Variable, stLoc.Value.MatchLdNull()))
		{
			return false;
		}
		context.Step("UsingTransformVB", tryFinally);
		stLoc.Variable.Kind = VariableKind.UsingLocal;
		blockContainer.EntryPoint.Instructions.RemoveAt(0);
		block.Instructions[i] = new UsingInstruction(stLoc.Variable, stLoc.Value, tryFinally.TryBlock);
		return true;
	}

	private bool CheckResourceType(IType type)
	{
		if (type.IsKnownType(KnownTypeCode.IEnumerator) || Enumerable.Any<IType>(type.GetAllBaseTypes(), (Func<IType, bool>)((IType b) => b.IsKnownType(KnownTypeCode.IEnumerator))))
		{
			return true;
		}
		if (Enumerable.Any<IType>(NullableType.GetUnderlyingType(type).GetAllBaseTypes(), (Func<IType, bool>)((IType b) => b.IsKnownType(KnownTypeCode.IDisposable))))
		{
			return true;
		}
		if (!Enumerable.Any<IMethod>(type.GetMethods((IMethod m) => m.Name == "GetEnumerator" && m.TypeParameters.Count == 0 && m.Parameters.Count == 0), (Func<IMethod, bool>)((IMethod m) => ImplementsForeachPattern(m.ReturnType))))
		{
			return false;
		}
		return true;
	}

	private bool ImplementsForeachPattern(IType type)
	{
		if (!Enumerable.Any<IMethod>(type.GetMethods((IMethod m) => m.Name == "MoveNext" && m.TypeParameters.Count == 0 && m.Parameters.Count == 0), (Func<IMethod, bool>)((IMethod m) => m.ReturnType.IsKnownType(KnownTypeCode.Boolean))))
		{
			return false;
		}
		if (!Enumerable.Any<IProperty>(type.GetProperties((IProperty p) => p.Name == "Current" && p.CanGet && !p.IsIndexer)))
		{
			return false;
		}
		return true;
	}

	private bool MatchDisposeBlock(BlockContainer container, ILVariable objVar, bool usingNull)
	{
		Block entryPoint = container.EntryPoint;
		if (entryPoint.Instructions.Count < 2 || entryPoint.Instructions.Count > 3 || entryPoint.IncomingEdgeCount != 1)
		{
			return false;
		}
		int index = ((entryPoint.Instructions.Count == 2) ? 1 : 2);
		int index2 = ((entryPoint.Instructions.Count != 2) ? 1 : 0);
		int num = ((entryPoint.Instructions.Count != 3) ? (-1) : 0);
		ILInstruction checkInst = entryPoint.Instructions[index2];
		bool isReference = objVar.Type.IsReferenceType != false;
		int numObjVarLoadsInCheck2;
		if (num > -1)
		{
			if (!entryPoint.Instructions[num].MatchStLoc(out var variable, out var value))
			{
				return false;
			}
			if (!value.MatchIsInst(out var argument, out var type) || !argument.MatchLdLoc(objVar) || !type.IsKnownType(KnownTypeCode.IDisposable))
			{
				return false;
			}
			if (!variable.IsSingleDefinition)
			{
				return false;
			}
			isReference = true;
			if (!MatchDisposeCheck(variable, checkInst, isReference, usingNull, out var numObjVarLoadsInCheck))
			{
				return false;
			}
			if (variable.LoadCount != numObjVarLoadsInCheck)
			{
				return false;
			}
		}
		else if (!MatchDisposeCheck(objVar, checkInst, isReference, usingNull, out numObjVarLoadsInCheck2))
		{
			return false;
		}
		if (!entryPoint.Instructions[index].MatchLeave(container, out var value2) || !value2.MatchNop())
		{
			return false;
		}
		return true;
	}

	private bool MatchDisposeCheck(ILVariable objVar, ILInstruction checkInst, bool isReference, bool usingNull, out int numObjVarLoadsInCheck)
	{
		numObjVarLoadsInCheck = 2;
		CallVirt callVirt;
		if (objVar.Type.IsKnownType(KnownTypeCode.NullableOfT))
		{
			if (checkInst.MatchIfInstruction(out var condition, out var trueInst))
			{
				if (!NullableLiftingTransform.MatchHasValueCall(condition, objVar))
				{
					return false;
				}
				if (!(trueInst is Block block) || block.Instructions.Count != 1)
				{
					return false;
				}
				callVirt = block.Instructions[0] as CallVirt;
			}
			else
			{
				if (!checkInst.MatchNullableRewrap(out trueInst))
				{
					return false;
				}
				callVirt = trueInst as CallVirt;
			}
			if (callVirt == null)
			{
				return false;
			}
			if (callVirt.Method.FullName != "System.IDisposable.Dispose")
			{
				return false;
			}
			if (callVirt.Method.Parameters.Count > 0)
			{
				return false;
			}
			if (callVirt.Arguments.Count != 1)
			{
				return false;
			}
			ILInstruction argument = callVirt.Arguments.FirstOrDefault();
			if (!argument.MatchUnboxAny(out var argument2, out var type) || !type.IsKnownType(KnownTypeCode.IDisposable))
			{
				if (!argument.MatchAddressOf(out var value))
				{
					return false;
				}
				return NullableLiftingTransform.MatchGetValueOrDefault(value, objVar) || (value is NullableUnwrap nullableUnwrap && nullableUnwrap.Argument.MatchLdLoc(objVar));
			}
			if (!argument2.MatchBox(out argument, out var type2) || !type2.IsKnownType(KnownTypeCode.NullableOfT) || !NullableType.GetUnderlyingType(type2).Equals(NullableType.GetUnderlyingType(objVar.Type)))
			{
				return false;
			}
			return argument.MatchLdLoc(objVar);
		}
		bool flag = false;
		ILInstruction iLInstruction;
		if (isReference && checkInst is NullableRewrap nullableRewrap)
		{
			if (!(nullableRewrap.Argument is CallVirt callVirt2))
			{
				return false;
			}
			if (!(callVirt2.Arguments.FirstOrDefault() is NullableUnwrap nullableUnwrap2))
			{
				return false;
			}
			numObjVarLoadsInCheck = 1;
			callVirt = callVirt2;
			iLInstruction = nullableUnwrap2.Argument;
		}
		else if (isReference)
		{
			if (!checkInst.MatchIfInstruction(out var condition2, out var trueInst2))
			{
				return false;
			}
			if (!condition2.MatchCompNotEquals(out var left, out var right) || !left.MatchLdLoc(objVar) || !right.MatchLdNull())
			{
				return false;
			}
			if (!(trueInst2 is Block block2) || block2.Instructions.Count != 1)
			{
				return false;
			}
			if (!(block2.Instructions[0] is CallVirt callVirt3))
			{
				return false;
			}
			iLInstruction = callVirt3.Arguments.FirstOrDefault();
			if (iLInstruction == null)
			{
				return false;
			}
			if (iLInstruction.MatchBox(out var argument3, out var type3) && type3.Equals(objVar.Type))
			{
				iLInstruction = argument3;
			}
			callVirt = callVirt3;
		}
		else
		{
			if (!(checkInst is CallVirt callVirt4))
			{
				return false;
			}
			iLInstruction = callVirt4.Arguments.FirstOrDefault();
			if (iLInstruction == null)
			{
				return false;
			}
			if (iLInstruction.MatchBox(out var argument4, out var type4) && type4.Equals(objVar.Type))
			{
				flag = type4.IsReferenceType != true;
				iLInstruction = argument4;
			}
			callVirt = callVirt4;
		}
		if (callVirt.Method.FullName != "System.IDisposable.Dispose")
		{
			return false;
		}
		if (callVirt.Method.Parameters.Count > 0)
		{
			return false;
		}
		if (callVirt.Arguments.Count != 1)
		{
			return false;
		}
		ILInstruction argument5;
		IType type5;
		return iLInstruction.MatchLdLocRef(objVar) || (flag && iLInstruction.MatchLdLoc(objVar)) || (usingNull && callVirt.Arguments[0].MatchLdNull()) || (isReference && checkInst is NullableRewrap && iLInstruction.MatchIsInst(out argument5, out type5) && argument5.MatchLdLoc(objVar) && type5.IsKnownType(KnownTypeCode.IDisposable));
	}
}

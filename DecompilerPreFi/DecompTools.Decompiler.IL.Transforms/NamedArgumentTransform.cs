#define DEBUG
#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

internal class NamedArgumentTransform : IStatementTransform
{
	public static ILInlining.FindResult CanIntroduceNamedArgument(CallInstruction call, ILInstruction child, ILVariable v, ILInstruction expressionBeingMoved)
	{
		Debug.Assert(child.Parent == call);
		if (call.IsInstanceCall && child.ChildIndex == 0)
		{
			return ILInlining.FindResult.Stop;
		}
		if (call.Method.IsOperator || call.Method.IsAccessor)
		{
			return ILInlining.FindResult.Stop;
		}
		if (call.Method is VarArgInstanceMethod)
		{
			return ILInlining.FindResult.Stop;
		}
		if (call.Method.IsConstructor)
		{
			IType declaringType = call.Method.DeclaringType;
			if (declaringType.Kind == TypeKind.Delegate || declaringType.IsAnonymousType())
			{
				return ILInlining.FindResult.Stop;
			}
		}
		if (Enumerable.Any<IParameter>((IEnumerable<IParameter>)call.Method.Parameters, (Func<IParameter, bool>)((IParameter p) => string.IsNullOrEmpty(p.Name))))
		{
			return ILInlining.FindResult.Stop;
		}
		for (int num = child.ChildIndex; num < call.Arguments.Count; num = checked(num + 1))
		{
			ILInlining.FindResult findResult = ILInlining.FindLoadInNext(call.Arguments[num], v, expressionBeingMoved, InliningOptions.None);
			if (findResult.Type == ILInlining.FindResultType.Found)
			{
				return ILInlining.FindResult.NamedArgument(findResult.LoadInst, call.Arguments[num]);
			}
		}
		return ILInlining.FindResult.Stop;
	}

	internal static ILInlining.FindResult CanExtendNamedArgument(Block block, ILVariable v, ILInstruction expressionBeingMoved)
	{
		Debug.Assert(block.Kind == BlockKind.CallWithNamedArgs);
		ILInstruction value = ((StLoc)block.Instructions[0]).Value;
		ILInlining.FindResult result = ILInlining.FindLoadInNext(value, v, expressionBeingMoved, InliningOptions.IntroduceNamedArguments);
		if (result.Type == ILInlining.FindResultType.Found || result.Type == ILInlining.FindResultType.NamedArgument)
		{
			return result;
		}
		CallInstruction callInstruction = (CallInstruction)block.FinalInstruction;
		if (callInstruction.IsInstanceCall)
		{
			if (result.Type == ILInlining.FindResultType.Stop)
			{
				return ILInlining.FindResult.Stop;
			}
			if (block.Instructions.Count > 1)
			{
				result = ILInlining.FindLoadInNext(block.Instructions[1], v, expressionBeingMoved, InliningOptions.IntroduceNamedArguments);
				if (result.Type == ILInlining.FindResultType.Found || result.Type == ILInlining.FindResultType.NamedArgument)
				{
					return result;
				}
			}
		}
		foreach (ILInstruction argument in callInstruction.Arguments)
		{
			if (argument.MatchLdLoc(v))
			{
				return ILInlining.FindResult.NamedArgument(argument, argument);
			}
		}
		return ILInlining.FindResult.Stop;
	}

	internal static void IntroduceNamedArgument(ILInstruction arg, ILTransformContext context)
	{
		CallInstruction callInstruction = (CallInstruction)arg.Parent;
		Debug.Assert(context.Function == Enumerable.First<ILFunction>(Enumerable.OfType<ILFunction>((IEnumerable)callInstruction.Ancestors)));
		ILVariable iLVariable = context.Function.RegisterVariable(VariableKind.NamedArgument, arg.ResultType);
		context.Step("Introduce named argument '" + iLVariable.Name + "'", arg);
		Block block;
		if ((block = callInstruction.Parent as Block) == null || block.Kind != BlockKind.CallWithNamedArgs)
		{
			block = new Block(BlockKind.CallWithNamedArgs);
			callInstruction.ReplaceWith(block);
			block.FinalInstruction = callInstruction;
			if (callInstruction.IsInstanceCall)
			{
				IType type = callInstruction.Method.DeclaringType;
				if (CallInstruction.ExpectedTypeForThisPointer(type) == StackType.Ref)
				{
					type = new ByReferenceType(type);
				}
				ILVariable variable = context.Function.RegisterVariable(VariableKind.NamedArgument, type, "this_arg");
				block.Instructions.Add(new StLoc(variable, callInstruction.Arguments[0]));
				callInstruction.Arguments[0] = new LdLoc(variable);
			}
		}
		int childIndex = arg.ChildIndex;
		Debug.Assert(callInstruction.Arguments[childIndex] == arg);
		block.Instructions.Insert(callInstruction.IsInstanceCall ? 1 : 0, new StLoc(iLVariable, arg));
		callInstruction.Arguments[childIndex] = new LdLoc(iLVariable);
	}

	public void Run(Block block, int pos, StatementTransformContext context)
	{
		if (context.Settings.NamedArguments)
		{
			InliningOptions inliningOptions = ILInlining.OptionsForBlock(block, pos);
			inliningOptions |= InliningOptions.IntroduceNamedArguments;
			ILInlining.InlineOneIfPossible(block, pos, inliningOptions, context);
		}
	}
}

#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class TransformCollectionAndObjectInitializers : IStatementTransform
{
	private StatementTransformContext context;

	private Dictionary<ILVariable, (int Index, ILInstruction Value)> possibleIndexVariables;

	private List<AccessPathElement> currentPath;

	private bool isCollection;

	private Stack<HashSet<AccessPathElement>> pathStack;

	void IStatementTransform.Run(Block block, int pos, StatementTransformContext context)
	{
		if (!context.Settings.ObjectOrCollectionInitializers)
		{
			return;
		}
		this.context = context;
		try
		{
			DoTransform(block, pos);
		}
		finally
		{
			this.context = null;
		}
	}

	private bool DoTransform(Block body, int pos)
	{
		ILInstruction iLInstruction = body.Instructions[pos];
		checked
		{
			if (iLInstruction.MatchStLoc(out var variable, out var value) && (variable.Kind == VariableKind.Local || variable.Kind == VariableKind.StackSlot))
			{
				ILInstruction iLInstruction2 = value;
				ILInstruction iLInstruction3 = iLInstruction2;
				if (iLInstruction3 == null)
				{
					goto IL_0165;
				}
				IType rootType;
				if (!(iLInstruction3 is NewObj newObj))
				{
					if (!(iLInstruction3 is DefaultValue defaultValue))
					{
						goto IL_0165;
					}
					DefaultValue defaultValue2 = defaultValue;
					if (defaultValue2.ILStackWasEmpty && variable.Kind == VariableKind.Local && !context.Function.Method.IsConstructor)
					{
						return false;
					}
					rootType = defaultValue2.Type;
				}
				else
				{
					NewObj newObj2 = newObj;
					if (newObj2.ILStackWasEmpty && variable.Kind == VariableKind.Local && !context.Function.Method.IsConstructor && !context.Function.Method.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
					{
						return false;
					}
					if (DelegateConstruction.IsSimpleDisplayClass(newObj2.Method.DeclaringType))
					{
						return false;
					}
					if (DelegateConstruction.IsDelegateConstruction(newObj2) || DelegateConstruction.IsPotentialClosure(context, newObj2))
					{
						return false;
					}
					rootType = newObj2.Method.DeclaringType;
				}
				int i = 0;
				BlockKind blockKind = BlockKind.CollectionInitializer;
				possibleIndexVariables = new Dictionary<ILVariable, (int, ILInstruction)>();
				currentPath = new List<AccessPathElement>();
				isCollection = false;
				pathStack = new Stack<HashSet<AccessPathElement>>();
				pathStack.Push(new HashSet<AccessPathElement>());
				for (; pos + i + 1 < body.Instructions.Count && IsPartOfInitializer(body.Instructions, pos + i + 1, variable, rootType, ref blockKind); i++)
				{
				}
				if (IsMethodCallOnVariable(body.Instructions[pos + i + 1], variable))
				{
					return false;
				}
				int? num = Enumerable.Min<KeyValuePair<ILVariable, (int, ILInstruction)>>(Enumerable.Where<KeyValuePair<ILVariable, (int, ILInstruction)>>((IEnumerable<KeyValuePair<ILVariable, (int, ILInstruction)>>)possibleIndexVariables, (Func<KeyValuePair<ILVariable, (int, ILInstruction)>, bool>)((KeyValuePair<ILVariable, (int Index, ILInstruction Value)> info) => info.Value.Index > -1)), (Func<KeyValuePair<ILVariable, (int, ILInstruction)>, int?>)((KeyValuePair<ILVariable, (int Index, ILInstruction Value)> info) => info.Value.Index));
				if (num.HasValue)
				{
					i = num.Value - pos - 1;
				}
				if (i <= 0)
				{
					return false;
				}
				context.Step("CollectionOrObjectInitializer", iLInstruction);
				Block block = new Block(blockKind);
				ILVariable variable2 = context.Function.RegisterVariable(VariableKind.InitializerTarget, variable.Type);
				block.FinalInstruction = new LdLoc(variable2);
				block.Instructions.Add(new StLoc(variable2, value.Clone()));
				for (int num2 = 1; num2 <= i; num2++)
				{
					ILInstruction iLInstruction4 = body.Instructions[num2 + pos];
					ILInstruction iLInstruction5 = iLInstruction4;
					if (iLInstruction5 == null)
					{
						continue;
					}
					if (!(iLInstruction5 is CallInstruction callInstruction))
					{
						if (!(iLInstruction5 is StObj stObj))
						{
							if (iLInstruction5 is StLoc stLoc)
							{
								StLoc stLoc2 = stLoc;
								StLoc value2 = stLoc2;
								block.Instructions.Add(value2);
							}
							continue;
						}
						StObj stObj2 = stObj;
						StObj stObj3 = stObj2;
						foreach (IInstructionWithVariableOperand item in Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)stObj3.Target.Descendants))
						{
							if ((item is LdLoc || item is LdLoca) && item.Variable == variable)
							{
								item.Variable = variable2;
							}
						}
						block.Instructions.Add(stObj3);
						continue;
					}
					CallInstruction callInstruction2 = callInstruction;
					if (!(callInstruction2 is CallVirt) && !(callInstruction2 is Call))
					{
						continue;
					}
					CallInstruction callInstruction3 = callInstruction2;
					ILInstruction iLInstruction6 = callInstruction3.Arguments[0];
					foreach (IInstructionWithVariableOperand item2 in Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)iLInstruction6.Descendants))
					{
						if ((item2 is LdLoc || item2 is LdLoca) && item2.Variable == variable)
						{
							item2.Variable = variable2;
						}
					}
					block.Instructions.Add(callInstruction3);
				}
				value.ReplaceWith(block);
				body.Instructions.RemoveRange(pos + 1, i);
				ILInlining.InlineIfPossible(body, pos, context);
			}
			return true;
		}
		IL_0165:
		return false;
	}

	private bool IsMethodCallOnVariable(ILInstruction inst, ILVariable variable)
	{
		if (inst.MatchLdLocRef(variable))
		{
			return true;
		}
		if (inst is CallInstruction callInstruction && callInstruction.Arguments.Count > 0 && !callInstruction.Method.IsStatic)
		{
			return IsMethodCallOnVariable(callInstruction.Arguments[0], variable);
		}
		if (inst.MatchLdFld(out var target, out var field) || inst.MatchStFld(out target, out field, out var _) || inst.MatchLdFlda(out target, out field))
		{
			return IsMethodCallOnVariable(target, variable);
		}
		return false;
	}

	private bool IsPartOfInitializer(InstructionCollection<ILInstruction> instructions, int pos, ILVariable target, IType rootType, ref BlockKind blockKind)
	{
		if (instructions[pos] is StLoc stLoc && stLoc.Variable.Kind == VariableKind.Local && stLoc.Variable.IsSingleDefinition)
		{
			if (!context.Settings.DictionaryInitializers)
			{
				return false;
			}
			if (Enumerable.Any<IInstructionWithVariableOperand>(Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)stLoc.Value.Descendants), (Func<IInstructionWithVariableOperand, bool>)((IInstructionWithVariableOperand ld) => ld.Variable == target && (ld is LdLoc || ld is LdLoca))))
			{
				return false;
			}
			possibleIndexVariables.Add(stLoc.Variable, (stLoc.ChildIndex, stLoc.Value));
			return true;
		}
		CSharpTypeResolveContext resolveContext = new CSharpTypeResolveContext(context.TypeSystem.MainModule, context.UsingScope);
		var (accessPathKind, list, list2, iLVariable) = AccessPathElement.GetAccessPath(instructions[pos], rootType, context.Settings, resolveContext, possibleIndexVariables);
		if (accessPathKind == AccessPathKind.Invalid || target != iLVariable)
		{
			return false;
		}
		AccessPathElement accessPathElement = list.Last();
		list.RemoveLast();
		int num = Math.Min(currentPath.Count, list.Count);
		checked
		{
			int num2;
			for (num2 = 0; num2 < num && list[num2] == currentPath[num2]; num2++)
			{
			}
			while (currentPath.Count > num2)
			{
				isCollection = false;
				currentPath.RemoveAt(currentPath.Count - 1);
				pathStack.Pop();
			}
			while (currentPath.Count < list.Count)
			{
				AccessPathElement accessPathElement2 = list[currentPath.Count];
				currentPath.Add(accessPathElement2);
				if (isCollection || !pathStack.Peek().Add(accessPathElement2))
				{
					return false;
				}
				pathStack.Push(new HashSet<AccessPathElement>());
			}
			switch (accessPathKind)
			{
			case AccessPathKind.Adder:
				isCollection = true;
				if (pathStack.Peek().Count != 0)
				{
					return false;
				}
				return true;
			case AccessPathKind.Setter:
				if (isCollection || !pathStack.Peek().Add(accessPathElement))
				{
					return false;
				}
				if (list2.Count == 1)
				{
					blockKind = BlockKind.ObjectInitializer;
					return true;
				}
				return false;
			default:
				return false;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class SplitVariables : IILTransform
{
	private enum AddressUse
	{
		Unknown,
		Immediate,
		WithSupportedRefLocals
	}

	private class GroupStores : ReachingDefinitionsVisitor
	{
		private readonly UnionFind<IInstructionWithVariableOperand> unionFind = new UnionFind<IInstructionWithVariableOperand>();

		private readonly Dictionary<ILVariable, IInstructionWithVariableOperand> uninitVariableUsage = new Dictionary<ILVariable, IInstructionWithVariableOperand>();

		private readonly Dictionary<IInstructionWithVariableOperand, ILVariable> newVariables = new Dictionary<IInstructionWithVariableOperand, ILVariable>();

		public GroupStores(ILFunction scope, CancellationToken cancellationToken)
			: base(scope, IsCandidateVariable, cancellationToken)
		{
		}

		protected internal override void VisitLdLoc(LdLoc inst)
		{
			base.VisitLdLoc(inst);
			HandleLoad(inst);
			LdLoca addressLoadForRefLocalUse = GetAddressLoadForRefLocalUse(inst);
			if (addressLoadForRefLocalUse != null)
			{
				HandleLoad(addressLoadForRefLocalUse);
			}
		}

		protected internal override void VisitLdLoca(LdLoca inst)
		{
			base.VisitLdLoca(inst);
			HandleLoad(inst);
		}

		private void HandleLoad(IInstructionWithVariableOperand inst)
		{
			if (!IsAnalyzedVariable(inst.Variable))
			{
				return;
			}
			if (IsPotentiallyUninitialized(state, inst.Variable))
			{
				if (uninitVariableUsage.TryGetValue(inst.Variable, out var value))
				{
					unionFind.Merge(inst, value);
				}
				else
				{
					uninitVariableUsage.Add(inst.Variable, inst);
				}
			}
			foreach (ILInstruction store in GetStores(state, inst.Variable))
			{
				unionFind.Merge(inst, (IInstructionWithVariableOperand)store);
			}
		}

		internal ILVariable GetNewVariable(IInstructionWithVariableOperand inst)
		{
			IInstructionWithVariableOperand key = unionFind.Find(inst);
			if (!newVariables.TryGetValue(key, out var value))
			{
				value = new ILVariable(inst.Variable.Kind, inst.Variable.Type, inst.Variable.StackType, inst.Variable.Index);
				value.Name = inst.Variable.Name;
				value.HasGeneratedName = inst.Variable.HasGeneratedName;
				value.StateMachineField = inst.Variable.StateMachineField;
				value.HasInitialValue = false;
				newVariables.Add(key, value);
				inst.Variable.Function.Variables.Add(value);
			}
			if (inst.Variable.HasInitialValue && uninitVariableUsage.TryGetValue(inst.Variable, out var value2) && value2 == inst)
			{
				value.HasInitialValue = true;
			}
			return value;
		}
	}

	public void Run(ILFunction function, ILTransformContext context)
	{
		GroupStores groupStores = new GroupStores(function, context.CancellationToken);
		function.Body.AcceptVisitor(groupStores);
		foreach (IInstructionWithVariableOperand item in Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)function.Descendants))
		{
			if (groupStores.IsAnalyzedVariable(item.Variable))
			{
				item.Variable = groupStores.GetNewVariable(item);
			}
		}
		function.Variables.RemoveDead();
	}

	private static bool IsCandidateVariable(ILVariable v)
	{
		VariableKind kind = v.Kind;
		if (kind != VariableKind.Local)
		{
			if (kind != VariableKind.StackSlot)
			{
				return false;
			}
			if (!v.Function.IsAsync)
			{
				return false;
			}
		}
		foreach (LdLoca addressInstruction in v.AddressInstructions)
		{
			if (DetermineAddressUse(addressInstruction, addressInstruction.Variable) == AddressUse.Unknown)
			{
				return false;
			}
		}
		return true;
	}

	private static AddressUse DetermineAddressUse(ILInstruction addressLoadingInstruction, ILVariable targetVar)
	{
		ILInstruction parent = addressLoadingInstruction.Parent;
		ILInstruction iLInstruction = parent;
		if (iLInstruction != null)
		{
			if (iLInstruction is LdObj ldObj)
			{
				LdObj ldObj2 = ldObj;
				return AddressUse.Immediate;
			}
			if (iLInstruction is LdFlda ldFlda)
			{
				LdFlda addressLoadingInstruction2 = ldFlda;
				return DetermineAddressUse(addressLoadingInstruction2, targetVar);
			}
			if (iLInstruction is Await obj)
			{
				Await obj2 = obj;
				return AddressUse.Immediate;
			}
			if (iLInstruction is CallInstruction callInstruction)
			{
				CallInstruction call = callInstruction;
				return HandleCall(addressLoadingInstruction, targetVar, call);
			}
			if (iLInstruction is StLoc stLoc)
			{
				StLoc stLoc2 = stLoc;
				if (stLoc2.Variable.IsSingleDefinition)
				{
					if (stLoc2.Variable.Kind != VariableKind.StackSlot && stLoc2.Variable.Kind != VariableKind.Local)
					{
						return AddressUse.Unknown;
					}
					if (stLoc2.Value.OpCode != OpCode.LdLoca)
					{
						return AddressUse.Unknown;
					}
					foreach (LdLoc loadInstruction in stLoc2.Variable.LoadInstructions)
					{
						if (DetermineAddressUse(loadInstruction, targetVar) != AddressUse.Immediate)
						{
							return AddressUse.Unknown;
						}
					}
					return AddressUse.WithSupportedRefLocals;
				}
			}
		}
		return AddressUse.Unknown;
	}

	private static AddressUse HandleCall(ILInstruction addressLoadingInstruction, ILVariable targetVar, CallInstruction call)
	{
		if (call is NewObj)
		{
			if (call.Method.DeclaringType.IsByRefLike)
			{
				return AddressUse.Unknown;
			}
		}
		else if (call.Method.ReturnType.IsByRefLike)
		{
			return AddressUse.Unknown;
		}
		foreach (IParameter parameter in call.Method.Parameters)
		{
			if (parameter.Type.SkipModifiers() is ByReferenceType byReferenceType && byReferenceType.ElementType.IsByRefLike)
			{
				return AddressUse.Unknown;
			}
		}
		checked
		{
			for (int i = addressLoadingInstruction.ChildIndex + 1; i < call.Arguments.Count; i++)
			{
				foreach (ILInstruction descendant in call.Arguments[i].Descendants)
				{
					if (descendant is StLoc stLoc && stLoc.Variable == targetVar)
					{
						return AddressUse.Unknown;
					}
				}
			}
			return AddressUse.Immediate;
		}
	}

	private static LdLoca GetAddressLoadForRefLocalUse(LdLoc ldloc)
	{
		if (!ldloc.Variable.IsSingleDefinition)
		{
			return null;
		}
		IStoreInstruction storeInstruction = Enumerable.SingleOrDefault<IStoreInstruction>((IEnumerable<IStoreInstruction>)ldloc.Variable.StoreInstructions);
		if (storeInstruction is StLoc stLoc)
		{
			return stLoc.Value as LdLoca;
		}
		return null;
	}
}

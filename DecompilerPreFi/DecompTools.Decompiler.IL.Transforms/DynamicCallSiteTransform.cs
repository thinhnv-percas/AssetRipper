#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class DynamicCallSiteTransform : IILTransform
{
	private struct CallSiteInfo
	{
		public bool Inverted;

		public ILInstruction BranchAfterInit;

		public IfInstruction ConditionalJumpToInit;

		public Block InitBlock;

		public IType DelegateType;

		public BinderMethodKind Kind;

		public CSharpBinderFlags Flags;

		public ExpressionType Operation;

		public IType Context;

		public IType ConvertTargetType;

		public IType[] TypeArguments;

		public CSharpArgumentInfo[] ArgumentInfos;

		public string MemberName;
	}

	private enum BinderMethodKind
	{
		BinaryOperation,
		Convert,
		GetIndex,
		GetMember,
		Invoke,
		InvokeConstructor,
		InvokeMember,
		IsEvent,
		SetIndex,
		SetMember,
		UnaryOperation
	}

	private ILTransformContext context;

	private const string CallSiteTypeName = "System.Runtime.CompilerServices.CallSite";

	private const string CSharpBinderTypeName = "Microsoft.CSharp.RuntimeBinder.Binder";

	public void Run(ILFunction function, ILTransformContext context)
	{
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		if (!context.Settings.Dynamic)
		{
			return;
		}
		this.context = context;
		Dictionary<IField, CallSiteInfo> dictionary = new Dictionary<IField, CallSiteInfo>();
		HashSet<BlockContainer> val = new HashSet<BlockContainer>();
		foreach (Block item in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
		{
			if (item.Instructions.Count >= 2 && item.Instructions.SecondToLastOrDefault() is IfInstruction ifInstruction && item.Instructions.LastOrDefault() is Branch branch && MatchCallSiteCacheNullCheck(ifInstruction.Condition, out var callSiteCacheField, out var callSiteDelegate, out var invertBranches) && ifInstruction.TrueInst.MatchBranch(out var targetBlock))
			{
				Block callSiteInitBlock;
				Block block;
				if (invertBranches)
				{
					callSiteInitBlock = branch.TargetBlock;
					block = targetBlock;
				}
				else
				{
					callSiteInitBlock = targetBlock;
					block = branch.TargetBlock;
				}
				if (ScanCallSiteInitBlock(callSiteInitBlock, callSiteCacheField, callSiteDelegate, out var callSiteInfo, out var blockAfterInit) && block == blockAfterInit)
				{
					callSiteInfo.DelegateType = callSiteDelegate;
					callSiteInfo.ConditionalJumpToInit = ifInstruction;
					callSiteInfo.Inverted = invertBranches;
					callSiteInfo.BranchAfterInit = branch;
					dictionary.Add(callSiteCacheField, callSiteInfo);
				}
			}
		}
		List<StLoc> list = new List<StLoc>();
		foreach (CallVirt item2 in Enumerable.OfType<CallVirt>((IEnumerable)function.Descendants))
		{
			if (item2.Method.DeclaringType.Kind != TypeKind.Delegate || item2.Method.Name != "Invoke" || item2.Arguments.Count == 0)
			{
				continue;
			}
			ILInstruction iLInstruction = item2.Arguments[0];
			if (iLInstruction.MatchLdLoc(out var variable) && variable.Kind == VariableKind.StackSlot && variable.IsSingleDefinition)
			{
				iLInstruction = ((StLoc)variable.StoreInstructions[0]).Value;
			}
			if (!iLInstruction.MatchLdFld(out var target, out var field) || !target.MatchLdsFld(out var field2) || !dictionary.TryGetValue(field2, out var value))
			{
				continue;
			}
			context.Stepper.Step("Transform callsite for " + value.MemberName);
			List<ILInstruction> list2 = new List<ILInstruction>();
			ILInstruction iLInstruction2 = MakeDynamicInstruction(value, item2, list2);
			if (iLInstruction2 == null)
			{
				continue;
			}
			item2.ReplaceWith(iLInstruction2);
			Debug.Assert(value.ConditionalJumpToInit?.Parent is Block);
			Block block2 = (Block)value.ConditionalJumpToInit.Parent;
			if (value.Inverted)
			{
				block2.Instructions.Remove(value.ConditionalJumpToInit);
				value.BranchAfterInit.ReplaceWith(value.ConditionalJumpToInit.TrueInst);
			}
			else
			{
				block2.Instructions.Remove(value.ConditionalJumpToInit);
			}
			foreach (ILInstruction item3 in list2)
			{
				if (!item3.MatchLdLoc(out var variable2) || variable2.Kind != VariableKind.StackSlot || !variable2.IsSingleDefinition || variable2.LoadCount != 0)
				{
					continue;
				}
				StLoc stLoc = (StLoc)variable2.StoreInstructions[0];
				if (stLoc.Parent is Block)
				{
					ILInstruction value2 = stLoc.Value;
					if (value2.MatchLdsFld(out var field3) && field3.Equals(field2))
					{
						list.Add(stLoc);
					}
					if (value2.MatchLdFld(out target, out var field4) && target.MatchLdsFld(out field3) && field2.Equals(field3) && field.Equals(field4))
					{
						list.Add(stLoc);
					}
				}
			}
			val.Add((BlockContainer)block2.Parent);
		}
		foreach (StLoc item4 in list)
		{
			Block block4 = (Block)item4.Parent;
			block4.Instructions.RemoveAt(item4.ChildIndex);
		}
		Enumerator<BlockContainer> enumerator5 = val.GetEnumerator();
		try
		{
			while (enumerator5.MoveNext())
			{
				BlockContainer current5 = enumerator5.Current;
				current5.SortBlocks(deleteUnreachableBlocks: true);
			}
		}
		finally
		{
			((IDisposable)enumerator5/*cast due to constrained. prefix*/).Dispose();
		}
	}

	private ILInstruction MakeDynamicInstruction(CallSiteInfo callsite, CallVirt targetInvokeCall, List<ILInstruction> deadArguments)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		switch (callsite.Kind)
		{
		case BinderMethodKind.BinaryOperation:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicBinaryOperatorInstruction(callsite.Flags, callsite.Operation, callsite.Context, callsite.ArgumentInfos[0], targetInvokeCall.Arguments[2], callsite.ArgumentInfos[1], targetInvokeCall.Arguments[3]);
		case BinderMethodKind.Convert:
		{
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			ILInstruction iLInstruction = new DynamicConvertInstruction(callsite.Flags, context: callsite.Context, type: callsite.ConvertTargetType, argument: targetInvokeCall.Arguments[2]);
			if (iLInstruction.ResultType == StackType.Unknown)
			{
				iLInstruction = new Conv(iLInstruction, PrimitiveType.None, ((DynamicConvertInstruction)iLInstruction).IsChecked, Sign.None);
			}
			return iLInstruction;
		}
		case BinderMethodKind.GetIndex:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicGetIndexInstruction(callsite.Flags, callsite.Context, callsite.ArgumentInfos, Enumerable.ToArray<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2)));
		case BinderMethodKind.GetMember:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicGetMemberInstruction(callsite.Flags, callsite.MemberName, callsite.Context, callsite.ArgumentInfos[0], targetInvokeCall.Arguments[2]);
		case BinderMethodKind.Invoke:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicInvokeInstruction(callsite.Flags, callsite.Context, callsite.ArgumentInfos, Enumerable.ToArray<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2)));
		case BinderMethodKind.InvokeConstructor:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicInvokeConstructorInstruction(callsite.Flags, callsite.Context, callsite.ArgumentInfos, Enumerable.ToArray<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2)));
		case BinderMethodKind.InvokeMember:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicInvokeMemberInstruction(callsite.Flags, callsite.MemberName, callsite.TypeArguments, callsite.Context, callsite.ArgumentInfos, Enumerable.ToArray<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2)));
		case BinderMethodKind.IsEvent:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicIsEventInstruction(callsite.Flags, callsite.MemberName, callsite.Context, targetInvokeCall.Arguments[2]);
		case BinderMethodKind.SetIndex:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicSetIndexInstruction(callsite.Flags, callsite.Context, callsite.ArgumentInfos, Enumerable.ToArray<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2)));
		case BinderMethodKind.SetMember:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicSetMemberInstruction(callsite.Flags, callsite.MemberName, callsite.Context, callsite.ArgumentInfos[0], targetInvokeCall.Arguments[2], callsite.ArgumentInfos[1], targetInvokeCall.Arguments[3]);
		case BinderMethodKind.UnaryOperation:
			deadArguments.AddRange(Enumerable.Take<ILInstruction>((IEnumerable<ILInstruction>)targetInvokeCall.Arguments, 2));
			return new DynamicUnaryOperatorInstruction(callsite.Flags, callsite.Operation, callsite.Context, callsite.ArgumentInfos[0], targetInvokeCall.Arguments[2]);
		default:
			throw new ArgumentOutOfRangeException($"Value {callsite.Kind} is not supported!");
		}
	}

	private bool ScanCallSiteInitBlock(Block callSiteInitBlock, IField callSiteCacheField, IType callSiteDelegateType, out CallSiteInfo callSiteInfo, out Block blockAfterInit)
	{
		//IL_0d4e: Unknown result type (might be due to invalid IL or missing references)
		callSiteInfo = default(CallSiteInfo);
		blockAfterInit = null;
		int count = callSiteInitBlock.Instructions.Count;
		if (callSiteInitBlock.IncomingEdgeCount != 1 || count < 2)
		{
			return false;
		}
		ILInstruction value;
		checked
		{
			if (!callSiteInitBlock.Instructions[count - 1].MatchBranch(out blockAfterInit))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[count - 2].MatchStsFld(out var field, out value) || !field.Equals(callSiteCacheField))
			{
				return false;
			}
			if (!(value is Call call) || call.Method.TypeArguments.Count != 0 || call.Arguments.Count != 1 || call.Method.Name != "Create" || call.Method.DeclaringType.FullName != "System.Runtime.CompilerServices.CallSite" || call.Method.DeclaringType.TypeArguments.Count != 1)
			{
				return false;
			}
			if (!(call.Arguments[0] is Call call2) || call2.Method.DeclaringType.FullName != "Microsoft.CSharp.RuntimeBinder.Binder" || call2.Method.DeclaringType.TypeParameterCount != 0)
			{
				return false;
			}
			callSiteInfo.DelegateType = callSiteDelegateType;
			callSiteInfo.InitBlock = callSiteInitBlock;
		}
		int value2;
		string value4;
		IType type;
		ILVariable variable;
		switch (call2.Method.Name)
		{
		case "IsEvent":
			callSiteInfo.Kind = BinderMethodKind.IsEvent;
			if (call2.Arguments.Count != 3)
			{
				return false;
			}
			if (!call2.Arguments[0].MatchLdcI4(out value2))
			{
				return false;
			}
			callSiteInfo.Flags = (CSharpBinderFlags)value2;
			if (!call2.Arguments[1].MatchLdStr(out value4))
			{
				return false;
			}
			callSiteInfo.MemberName = value4;
			if (!TransformExpressionTrees.MatchGetTypeFromHandle(call2.Arguments[2], out type))
			{
				return false;
			}
			callSiteInfo.Context = type;
			return true;
		case "Convert":
		{
			callSiteInfo.Kind = BinderMethodKind.Convert;
			if (call2.Arguments.Count != 3)
			{
				return false;
			}
			if (!call2.Arguments[0].MatchLdcI4(out value2))
			{
				return false;
			}
			callSiteInfo.Flags = (CSharpBinderFlags)value2;
			if (!TransformExpressionTrees.MatchGetTypeFromHandle(call2.Arguments[1], out var type2))
			{
				return false;
			}
			callSiteInfo.ConvertTargetType = type2;
			if (!TransformExpressionTrees.MatchGetTypeFromHandle(call2.Arguments[2], out type))
			{
				return false;
			}
			callSiteInfo.Context = type;
			return true;
		}
		case "InvokeMember":
		{
			callSiteInfo.Kind = BinderMethodKind.InvokeMember;
			if (call2.Arguments.Count != 5)
			{
				return false;
			}
			if (!call2.Arguments[0].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[0].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!value.MatchLdcI4(out value2))
			{
				return false;
			}
			callSiteInfo.Flags = (CSharpBinderFlags)value2;
			if (!call2.Arguments[1].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[1].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!value.MatchLdStr(out value4))
			{
				return false;
			}
			callSiteInfo.MemberName = value4;
			if (!call2.Arguments[2].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[2].MatchStLoc(out var variable2, out value))
			{
				return false;
			}
			int value5 = 0;
			if (!value.MatchLdNull())
			{
				if (!(value is NewArr newArr) || !newArr.Type.IsKnownType(KnownTypeCode.Type) || newArr.Indices.Count != 1 || !newArr.Indices[0].MatchLdcI4(out value5))
				{
					return false;
				}
				if (!TransformArrayInitializers.HandleSimpleArrayInitializer(context.Function, callSiteInitBlock, 3, variable2, newArr.Type, new int[1] { value5 }, out (ILInstruction[], ILInstruction)[] values, out int _))
				{
					return false;
				}
				int num = 0;
				callSiteInfo.TypeArguments = new IType[value5];
				(ILInstruction[], ILInstruction)[] array = values;
				for (int i = 0; i < array.Length; i++)
				{
					ILInstruction item = array[i].Item2;
					if (!TransformExpressionTrees.MatchGetTypeFromHandle(item, out var type3))
					{
						return false;
					}
					callSiteInfo.TypeArguments[num] = type3;
					num = checked(num + 1);
				}
			}
			int num2 = value5;
			checked
			{
				if (variable2 != variable)
				{
					if (!callSiteInitBlock.Instructions[3 + num2].MatchStLoc(variable, out value))
					{
						return false;
					}
					if (!value.MatchLdLoc(variable2))
					{
						return false;
					}
					num2++;
				}
				if (!call2.Arguments[3].MatchLdLoc(out variable))
				{
					return false;
				}
				if (!callSiteInitBlock.Instructions[3 + num2].MatchStLoc(variable, out value))
				{
					return false;
				}
				if (!TransformExpressionTrees.MatchGetTypeFromHandle(value, out type))
				{
					return false;
				}
				callSiteInfo.Context = type;
				if (!call2.Arguments[4].MatchLdLoc(out variable))
				{
					return false;
				}
				if (!callSiteInitBlock.Instructions[4 + num2].MatchStLoc(variable, out value))
				{
					return false;
				}
				if (!ExtractArgumentInfo(value, ref callSiteInfo, 5 + num2, variable))
				{
					return false;
				}
				return true;
			}
		}
		case "GetMember":
		case "SetMember":
			callSiteInfo.Kind = ((call2.Method.Name == "GetMember") ? BinderMethodKind.GetMember : BinderMethodKind.SetMember);
			if (call2.Arguments.Count != 4)
			{
				return false;
			}
			if (!call2.Arguments[0].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[0].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!value.MatchLdcI4(out value2))
			{
				return false;
			}
			callSiteInfo.Flags = (CSharpBinderFlags)value2;
			if (!call2.Arguments[1].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[1].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!value.MatchLdStr(out value4))
			{
				return false;
			}
			callSiteInfo.MemberName = value4;
			if (!call2.Arguments[2].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[2].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!TransformExpressionTrees.MatchGetTypeFromHandle(value, out type))
			{
				return false;
			}
			callSiteInfo.Context = type;
			if (!call2.Arguments[3].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[3].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!ExtractArgumentInfo(value, ref callSiteInfo, 4, variable))
			{
				return false;
			}
			return true;
		case "GetIndex":
		case "SetIndex":
		case "InvokeConstructor":
		case "Invoke":
			switch (call2.Method.Name)
			{
			case "GetIndex":
				callSiteInfo.Kind = BinderMethodKind.GetIndex;
				break;
			case "SetIndex":
				callSiteInfo.Kind = BinderMethodKind.SetIndex;
				break;
			case "InvokeConstructor":
				callSiteInfo.Kind = BinderMethodKind.InvokeConstructor;
				break;
			case "Invoke":
				callSiteInfo.Kind = BinderMethodKind.Invoke;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (call2.Arguments.Count != 3)
			{
				return false;
			}
			if (!call2.Arguments[0].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[0].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!value.MatchLdcI4(out value2))
			{
				return false;
			}
			callSiteInfo.Flags = (CSharpBinderFlags)value2;
			if (!call2.Arguments[1].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[1].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!TransformExpressionTrees.MatchGetTypeFromHandle(value, out type))
			{
				return false;
			}
			callSiteInfo.Context = type;
			if (!call2.Arguments[2].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[2].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!ExtractArgumentInfo(value, ref callSiteInfo, 3, variable))
			{
				return false;
			}
			return true;
		case "UnaryOperation":
		case "BinaryOperation":
		{
			callSiteInfo.Kind = ((!(call2.Method.Name == "BinaryOperation")) ? BinderMethodKind.UnaryOperation : BinderMethodKind.BinaryOperation);
			if (call2.Arguments.Count != 4)
			{
				return false;
			}
			if (!call2.Arguments[0].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[0].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!value.MatchLdcI4(out value2))
			{
				return false;
			}
			callSiteInfo.Flags = (CSharpBinderFlags)value2;
			if (!call2.Arguments[1].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[1].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!value.MatchLdcI4(out var value3))
			{
				return false;
			}
			callSiteInfo.Operation = (ExpressionType)value3;
			if (!call2.Arguments[2].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[2].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!TransformExpressionTrees.MatchGetTypeFromHandle(value, out type))
			{
				return false;
			}
			callSiteInfo.Context = type;
			if (!call2.Arguments[3].MatchLdLoc(out variable))
			{
				return false;
			}
			if (!callSiteInitBlock.Instructions[3].MatchStLoc(variable, out value))
			{
				return false;
			}
			if (!ExtractArgumentInfo(value, ref callSiteInfo, 4, variable))
			{
				return false;
			}
			return true;
		}
		default:
			return false;
		}
	}

	private bool ExtractArgumentInfo(ILInstruction value, ref CallSiteInfo callSiteInfo, int instructionOffset, ILVariable variable)
	{
		if (!(value is NewArr newArr) || !(newArr.Type.FullName == "Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo") || newArr.Indices.Count != 1 || !newArr.Indices[0].MatchLdcI4(out var value2))
		{
			return false;
		}
		if (!TransformArrayInitializers.HandleSimpleArrayInitializer(context.Function, callSiteInfo.InitBlock, instructionOffset, variable, newArr.Type, new int[1] { value2 }, out (ILInstruction[], ILInstruction)[] values, out int _))
		{
			return false;
		}
		int num = 0;
		callSiteInfo.ArgumentInfos = new CSharpArgumentInfo[value2];
		IType[] array = callSiteInfo.DelegateType.GetDelegateInvokeMethod().Parameters.SelectReadOnlyArray((IParameter p) => p.Type);
		(ILInstruction[], ILInstruction)[] array2 = values;
		for (int num2 = 0; num2 < array2.Length; num2++)
		{
			ILInstruction item = array2[num2].Item2;
			if (!(item is Call call))
			{
				return false;
			}
			if (!(call.Method.Name == "Create") || !(call.Method.DeclaringType.FullName == "Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo") || call.Arguments.Count != 2)
			{
				return false;
			}
			if (!call.Arguments[0].MatchLdcI4(out var value3))
			{
				return false;
			}
			string value4 = null;
			if (!call.Arguments[1].MatchLdStr(out value4) && !call.Arguments[1].MatchLdNull())
			{
				return false;
			}
			callSiteInfo.ArgumentInfos[num] = new CSharpArgumentInfo
			{
				Flags = (CSharpArgumentInfoFlags)value3,
				Name = value4,
				CompileTimeType = array[checked(num + 1)]
			};
			num = checked(num + 1);
		}
		return true;
	}

	private bool MatchCallSiteCacheNullCheck(ILInstruction condition, out IField callSiteCacheField, out IType callSiteDelegate, out bool invertBranches)
	{
		callSiteCacheField = null;
		callSiteDelegate = null;
		invertBranches = false;
		if (!condition.MatchCompEqualsNull(out var arg))
		{
			if (!condition.MatchCompNotEqualsNull(out arg))
			{
				return false;
			}
			invertBranches = true;
		}
		if (!arg.MatchLdsFld(out callSiteCacheField) || callSiteCacheField.ReturnType.TypeArguments.Count != 1 || callSiteCacheField.ReturnType.FullName != "System.Runtime.CompilerServices.CallSite")
		{
			return false;
		}
		callSiteDelegate = callSiteCacheField.ReturnType.TypeArguments[0];
		if (callSiteDelegate.Kind != TypeKind.Delegate)
		{
			return false;
		}
		return true;
	}
}

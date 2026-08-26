using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

internal abstract class AsyncDecompiler
{
	protected enum AsyncMethodType
	{
		Void,
		Task,
		TaskOfT
	}

	protected struct ILMethodBody
	{
		public List<ILNode> Body { get; }

		public int StartPosition { get; }

		public int EndPosition { get; }

		public ILMethodBody(List<ILNode> body)
		{
			Body = body;
			StartPosition = 0;
			EndPosition = body.Count;
		}

		public ILMethodBody(List<ILNode> body, int startPosition, int endPosition)
		{
			Body = body;
			StartPosition = startPosition;
			EndPosition = endPosition;
		}
	}

	private struct TempAsyncStepInfo
	{
		public uint YieldOffset;

		public ILLabel ResumeLabel;
	}

	private static readonly UTF8String nameIAsyncStateMachine = new UTF8String("IAsyncStateMachine");

	protected readonly DecompilerContext context;

	private readonly AutoPropertyProvider autoPropertyProvider;

	protected AsyncMethodType methodType;

	protected TypeDef stateMachineType;

	protected bool stateMachineTypeIsValueType;

	protected MethodDef moveNextMethod;

	protected FieldDef builderField;

	protected FieldDef stateField;

	protected FieldToVariableMap variableMap;

	protected ILLabel exitLabel;

	protected ILVariable cachedThisVar;

	private static readonly UTF8String nameCreate = new UTF8String("Create");

	private static readonly UTF8String nameStart = new UTF8String("Start");

	private static readonly UTF8String nameSystemRuntimeCompilerServices = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String nameAsyncTaskMethodBuilder1 = new UTF8String("AsyncTaskMethodBuilder`1");

	private static readonly UTF8String nameAsyncTaskMethodBuilder = new UTF8String("AsyncTaskMethodBuilder");

	private static readonly UTF8String nameAsyncVoidMethodBuilder = new UTF8String("AsyncVoidMethodBuilder");

	private static readonly UTF8String nameMoveNext = new UTF8String("MoveNext");

	protected static readonly UTF8String nameGetResult = new UTF8String("GetResult");

	private static readonly UTF8String stringSystem_Threading_Tasks = new UTF8String("System.Threading.Tasks");

	private static readonly UTF8String stringTask = new UTF8String("Task");

	private static readonly UTF8String stringTask_1 = new UTF8String("Task`1");

	private static readonly UTF8String stringSystem = new UTF8String("System");

	private static readonly UTF8String stringVoid = new UTF8String("Void");

	private static readonly UTF8String nameGetObjectValue = new UTF8String("GetObjectValue");

	private static readonly UTF8String nameSetResult = new UTF8String("SetResult");

	private static readonly UTF8String nameAwaitUnsafeOnCompleted = new UTF8String("AwaitUnsafeOnCompleted");

	private static readonly UTF8String nameAwaitOnCompleted = new UTF8String("AwaitOnCompleted");

	private static readonly UTF8String nameSetException = new UTF8String("SetException");

	private int smallestGeneratedVariableIndex = int.MaxValue;

	private readonly Dictionary<int, TempAsyncStepInfo> asyncStepInfoMap = new Dictionary<int, TempAsyncStepInfo>();

	private uint catchHandlerOffset = uint.MaxValue;

	private uint setResultOffset = uint.MaxValue;

	public abstract string CompilerName { get; }

	public static bool IsCompilerGeneratedStateMachine(TypeDef type)
	{
		if (type.DeclaringType == null || !type.IsCompilerGenerated())
		{
			return false;
		}
		foreach (InterfaceImpl @interface in type.Interfaces)
		{
			ITypeDefOrRef typeDefOrRef = @interface.Interface;
			if (typeDefOrRef != null && typeDefOrRef.Name == nameIAsyncStateMachine && typeDefOrRef.Namespace == "System.Runtime.CompilerServices")
			{
				return true;
			}
		}
		return false;
	}

	protected AsyncDecompiler(DecompilerContext context, AutoPropertyProvider autoPropertyProvider)
	{
		this.context = context;
		this.autoPropertyProvider = autoPropertyProvider;
		variableMap = context.VariableMap;
	}

	private static AsyncDecompiler TryCreate(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		return MicrosoftAsyncDecompiler.TryCreateCore(context, method, autoPropertyProvider) ?? MonoAsyncDecompiler.TryCreateCore(context, method, autoPropertyProvider);
	}

	public static AsyncDecompiler RunStep1(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider, ref StateMachineKind stateMachineKind, ref MethodDef inlinedMethod, ref string compilerName, List<ILExpression> listExpr, List<ILBlock> listBlock, Dictionary<ILLabel, int> labelRefCount)
	{
		if (!context.Settings.AsyncAwait)
		{
			return null;
		}
		AsyncDecompiler asyncDecompiler = TryCreate(context, method, autoPropertyProvider);
		if (asyncDecompiler == null)
		{
			return null;
		}
		List<ILNode> collection;
		try
		{
			collection = asyncDecompiler.Run();
		}
		catch (SymbolicAnalysisFailedException)
		{
			return null;
		}
		context.CurrentMethodIsAsync = true;
		method.Body.Clear();
		method.EntryGoto = null;
		method.Body.AddRange(collection);
		stateMachineKind = StateMachineKind.AsyncMethod;
		inlinedMethod = asyncDecompiler.moveNextMethod;
		compilerName = asyncDecompiler.CompilerName;
		ILAstOptimizer.RemoveRedundantCode(context, method, listExpr, listBlock, labelRefCount);
		return asyncDecompiler;
	}

	protected abstract void AnalyzeMoveNext(out ILMethodBody bodyInfo, out ILTryCatchBlock tryCatchBlock, out int finalState, out ILLabel exitLabel);

	protected abstract List<ILNode> AnalyzeStateMachine(ILMethodBody bodyInfo);

	private List<ILNode> Run()
	{
		AnalyzeMoveNext(out var bodyInfo, out var tryCatchBlock, out var finalState, out exitLabel);
		if (tryCatchBlock != null)
		{
			ValidateCatchBlock(tryCatchBlock.CatchBlocks[0], finalState, exitLabel);
			if (context.CalculateILSpans)
			{
				ILTryCatchBlock.CatchBlock catchBlock = tryCatchBlock.CatchBlocks[0];
				catchHandlerOffset = GetOffset(catchBlock.Body, 0, catchBlock.Body.Count);
				foreach (ILSpan stlocILSpan in catchBlock.StlocILSpans)
				{
					catchHandlerOffset = Math.Min(stlocILSpan.Start, catchHandlerOffset);
				}
			}
		}
		List<ILNode> list = AnalyzeStateMachine(bodyInfo);
		MarkGeneratedVariables(list);
		YieldReturnDecompiler.TranslateFieldsToLocalAccess(list, variableMap, cachedThisVar, context.CalculateILSpans, fixLocals: true);
		return list;
	}

	protected ILTryCatchBlock GetMainTryCatchBlock(ILNode node)
	{
		if (!(node is ILTryCatchBlock iLTryCatchBlock) || iLTryCatchBlock.CatchBlocks.Count != 1)
		{
			return null;
		}
		if (iLTryCatchBlock.FaultBlock != null || iLTryCatchBlock.FinallyBlock != null)
		{
			return null;
		}
		return iLTryCatchBlock;
	}

	protected bool MatchStartCall(ILNode expr, out ILVariable stateMachineVar)
	{
		ILVariable builderVar;
		return MatchStartCallCore(expr, out stateMachineVar, out builderVar, useLdflda: true);
	}

	protected bool MatchStartCall(ILNode expr, out ILVariable stateMachineVar, out ILVariable builderVar)
	{
		return MatchStartCallCore(expr, out stateMachineVar, out builderVar, useLdflda: false);
	}

	private static bool TryGetAsyncMethodType(ITypeDefOrRef tdr, ITypeDefOrRef builderType, out AsyncMethodType asyncMethodType)
	{
		TypeDef typeDef = tdr.ResolveTypeDef();
		if (typeDef != null)
		{
			int count = typeDef.GenericParameters.Count;
			if (count > 1)
			{
				asyncMethodType = AsyncMethodType.Void;
				return false;
			}
			if (typeDef.Namespace == stringSystem_Threading_Tasks)
			{
				if (count == 1 && typeDef.Name == stringTask_1)
				{
					asyncMethodType = AsyncMethodType.TaskOfT;
					return true;
				}
				if (count == 0 && typeDef.Name == stringTask)
				{
					asyncMethodType = AsyncMethodType.Task;
					return true;
				}
			}
			if (IsCustomTaskType(typeDef))
			{
				switch (count)
				{
				case 0:
					asyncMethodType = AsyncMethodType.Task;
					return true;
				case 1:
					asyncMethodType = AsyncMethodType.TaskOfT;
					return true;
				}
			}
			if (typeDef.Name == stringVoid && typeDef.Namespace == stringSystem)
			{
				TypeDef typeDef2 = builderType.ResolveTypeDef();
				if (typeDef2 != null && typeDef2.Namespace == nameSystemRuntimeCompilerServices && typeDef2.Name == nameAsyncVoidMethodBuilder)
				{
					asyncMethodType = AsyncMethodType.Void;
					return true;
				}
			}
		}
		asyncMethodType = AsyncMethodType.Void;
		return false;
	}

	private static bool IsCustomTaskType(TypeDef td)
	{
		if (td == null)
		{
			return false;
		}
		if (td.GenericParameters.Count > 1)
		{
			return false;
		}
		foreach (CustomAttribute customAttribute in td.CustomAttributes)
		{
			if (!(customAttribute.TypeFullName != "System.Runtime.CompilerServices.AsyncMethodBuilderAttribute") && customAttribute.ConstructorArguments.Count == 1 && !((customAttribute.ConstructorArguments[0].Type as ClassSig)?.TypeDefOrRef.FullName != "System.Type"))
			{
				return true;
			}
		}
		return false;
	}

	private bool MatchStartCallCore(ILNode expr, out ILVariable stateMachineVar, out ILVariable builderVar, bool useLdflda)
	{
		stateMachineVar = null;
		builderVar = null;
		if (!expr.Match<IMethod>(ILCode.Call, out var operand, out var arg, out var arg2))
		{
			return false;
		}
		if (operand.Name != nameStart)
		{
			return false;
		}
		if (!TryGetAsyncMethodType(context.CurrentMethod.ReturnType.RemovePinnedAndModifiers().ToTypeDefOrRef(), operand.DeclaringType, out methodType))
		{
			return false;
		}
		if (!((ILNode)arg2).Match(ILCode.Ldloca, out stateMachineVar))
		{
			return false;
		}
		if (useLdflda)
		{
			if (!((ILNode)arg).Match(ILCode.Ldflda, out IField _, out ILExpression arg3))
			{
				return false;
			}
			if ((!((ILNode)arg3).Match(ILCode.Ldloca, out ILVariable operand3) && !((ILNode)arg3).Match(ILCode.Ldloc, out operand3)) || operand3 != stateMachineVar)
			{
				return false;
			}
		}
		else if (!((ILNode)arg).Match(ILCode.Ldloca, out builderVar))
		{
			return false;
		}
		stateMachineType = stateMachineVar.Type.GetTypeDefOrRef().ResolveWithinSameModule();
		if (stateMachineType == null)
		{
			return false;
		}
		stateMachineTypeIsValueType = DnlibExtensions.IsValueType(stateMachineType);
		moveNextMethod = stateMachineType.Methods.FirstOrDefault((MethodDef f) => f.Name == nameMoveNext);
		if (moveNextMethod == null)
		{
			return false;
		}
		return true;
	}

	protected bool MatchReturnTask(ILNode expr, ILVariable stateMachineVar)
	{
		if (methodType == AsyncMethodType.Void)
		{
			if (!expr.Match(ILCode.Ret))
			{
				return false;
			}
		}
		else
		{
			if (!expr.Match(ILCode.Ret, out ILExpression arg))
			{
				return false;
			}
			if (!((ILNode)arg).Match(ILCode.Call, out IMethod _, out ILExpression arg2))
			{
				return false;
			}
			if (!((ILNode)arg2).Match(ILCode.Ldflda, out IField operand2, out ILExpression arg3))
			{
				return false;
			}
			if (operand2.ResolveFieldWithinSameModule() != builderField)
			{
				return false;
			}
			if (stateMachineTypeIsValueType ? (!arg3.MatchLdloca(stateMachineVar)) : (!arg3.MatchLdloc(stateMachineVar)))
			{
				return false;
			}
		}
		return true;
	}

	protected bool MatchCallCreate(ILNode expr, ILVariable stateMachineVar)
	{
		if (!MatchStFld(expr, stateMachineVar, stateMachineTypeIsValueType, out var field, out var expr2))
		{
			return false;
		}
		if (builderField == null)
		{
			builderField = field;
		}
		else if (field != builderField)
		{
			return false;
		}
		if (!((ILNode)expr2).Match(ILCode.Call, out IMethod operand))
		{
			return false;
		}
		if (operand.Name != nameCreate)
		{
			return false;
		}
		return true;
	}

	protected bool InitializeFieldToParameterMap(List<ILNode> body, int bodyLength, ILVariable stateMachineVar)
	{
		return InitializeFieldToParameterMap(body, (!stateMachineTypeIsValueType) ? 1 : 0, bodyLength, stateMachineVar);
	}

	protected bool InitializeFieldToParameterMap(List<ILNode> body, int startPos, int bodyLength, ILVariable stateMachineVar)
	{
		for (int i = startPos; i < bodyLength; i++)
		{
			if (!MatchStFld(body[i], stateMachineVar, stateMachineTypeIsValueType, out var field, out var expr))
			{
				return false;
			}
			if (!((ILNode)expr).Match(ILCode.Ldloc, out ILVariable operand))
			{
				if (((ILNode)expr).Match(ILCode.Ldobj, out ITypeDefOrRef operand2, out ILExpression arg) && arg.MatchThis() && operand2.ResolveWithinSameModule() == context.CurrentMethod.DeclaringType)
				{
					operand = (ILVariable)arg.Operand;
				}
				else
				{
					if (!((ILNode)expr).Match(ILCode.Call, out IMethod operand3, out arg) || !((ILNode)arg).Match(ILCode.Ldloc, out operand))
					{
						return false;
					}
					if (operand3.Name != nameGetObjectValue)
					{
						return false;
					}
					if (operand3.DeclaringType.FullName != "System.Runtime.CompilerServices.RuntimeHelpers")
					{
						return false;
					}
				}
			}
			if (!operand.IsParameter)
			{
				return false;
			}
			variableMap.SetParameter(field, operand);
		}
		return true;
	}

	protected static bool MatchStFld(ILNode stfld, ILVariable stateMachineVar, bool stateMachineStructIsValueType, out FieldDef field, out ILExpression expr)
	{
		field = null;
		if (!stfld.Match<IField>(ILCode.Stfld, out var operand, out var arg, out expr))
		{
			return false;
		}
		field = operand.ResolveFieldWithinSameModule();
		if (field == null)
		{
			return false;
		}
		if (!stateMachineStructIsValueType)
		{
			return arg.MatchLdloc(stateMachineVar);
		}
		return arg.MatchLdloca(stateMachineVar);
	}

	protected ILBlock CreateILAst(MethodDef method)
	{
		if (method == null || !method.HasBody)
		{
			throw new SymbolicAnalysisFailedException();
		}
		ILBlock iLBlock = new ILBlock(CodeBracesRangeFlags.MethodBraces);
		ILAstBuilder iLAstBuilder = context.Cache.GetILAstBuilder();
		try
		{
			iLBlock.Body = iLAstBuilder.Build(method, optimize: true, context);
		}
		finally
		{
			context.Cache.Return(iLAstBuilder);
		}
		ILAstOptimizer iLAstOptimizer = context.Cache.GetILAstOptimizer();
		try
		{
			iLAstOptimizer.Optimize(context, iLBlock, autoPropertyProvider, out var _, out var _, out var _, ILAstOptimizationStep.YieldReturn);
			return iLBlock;
		}
		finally
		{
			context.Cache.Return(iLAstOptimizer);
		}
	}

	protected bool MatchCallSetResult(ILNode expr, out ILExpression resultExpr, out ILVariable resultVariable)
	{
		resultExpr = null;
		resultVariable = null;
		if (context.CalculateILSpans)
		{
			List<ILSpan> list = ILSpan.OrderAndCompact(expr.GetSelfAndChildrenRecursiveILSpans());
			if (list.Count > 0)
			{
				setResultOffset = list[0].Start;
			}
		}
		IMethod operand;
		ILExpression arg;
		if (methodType == AsyncMethodType.TaskOfT)
		{
			if (!expr.Match<IMethod>(ILCode.Call, out operand, out arg, out resultExpr))
			{
				return false;
			}
			((ILNode)resultExpr).Match(ILCode.Ldloc, out resultVariable);
		}
		else if (!expr.Match(ILCode.Call, out operand, out arg))
		{
			return false;
		}
		if (!(operand.Name == nameSetResult) || !IsBuilderFieldOnThis(arg))
		{
			return false;
		}
		return true;
	}

	protected ILExpression MatchCallAwaitOnCompletedMethod(ILNode expr)
	{
		if (!(expr is ILExpression iLExpression) || (iLExpression.Code != ILCode.Call && iLExpression.Code != ILCode.Callvirt))
		{
			return null;
		}
		UTF8String name = ((IMethod)iLExpression.Operand).Name;
		if (name != nameAwaitUnsafeOnCompleted && name != nameAwaitOnCompleted)
		{
			return null;
		}
		if (iLExpression.Arguments.Count != 3)
		{
			return null;
		}
		return iLExpression.Arguments[1];
	}

	private void ValidateCatchBlock(ILTryCatchBlock.CatchBlock catchBlock, int finalState, ILLabel exitLabel)
	{
		if (!CheckCatchBlock(catchBlock, stateField, builderField, finalState, exitLabel))
		{
			throw new SymbolicAnalysisFailedException();
		}
	}

	private static bool CheckCatchBlock(ILTryCatchBlock.CatchBlock catchBlock, FieldDef stateField, FieldDef builderField, int finalState, ILLabel exitLabel)
	{
		if (catchBlock.ExceptionType == null || catchBlock.ExceptionType.TypeName != "Exception")
		{
			return false;
		}
		List<ILNode> body = catchBlock.Body;
		int num = 0;
		ILVariable operand;
		if (body.Count == 3)
		{
			operand = catchBlock.ExceptionVariable;
		}
		else
		{
			if (body.Count != 4)
			{
				return false;
			}
			if (!body[num++].Match(ILCode.Stloc, out operand, out ILExpression arg) || !arg.MatchLdloc(catchBlock.ExceptionVariable))
			{
				return false;
			}
		}
		if (!MatchStateAssignment(body[num++], stateField, out var stateID) || stateID != finalState)
		{
			return false;
		}
		if (!body[num++].Match<IMethod>(ILCode.Call, out var operand2, out var arg2, out var arg3))
		{
			return false;
		}
		if (!(operand2.Name == nameSetException) || !IsBuilderFieldOnThis(arg2, builderField) || !arg3.MatchLdloc(operand))
		{
			return false;
		}
		if (!body[num++].Match(ILCode.Leave, out ILLabel operand3) || operand3 != exitLabel)
		{
			return false;
		}
		return true;
	}

	private bool IsBuilderFieldOnThis(ILExpression builderExpr)
	{
		return IsBuilderFieldOnThis(builderExpr, builderField);
	}

	private static bool IsBuilderFieldOnThis(ILExpression builderExpr, FieldDef builderField)
	{
		if (((ILNode)builderExpr).Match(ILCode.Ldflda, out IField operand, out ILExpression arg) && operand.ResolveFieldWithinSameModule() == builderField)
		{
			return arg.MatchThis();
		}
		return false;
	}

	protected bool MatchStateAssignment(ILNode stfld, out int stateID)
	{
		return MatchStateAssignment(stfld, stateField, out stateID);
	}

	private static bool MatchStateAssignment(ILNode stfld, FieldDef stateField, out int stateID)
	{
		stateID = 0;
		if (stfld.Match<IField>(ILCode.Stfld, out var operand, out var arg, out var arg2))
		{
			if (operand.ResolveFieldWithinSameModule() == stateField && arg.MatchThis())
			{
				return ((ILNode)arg2).Match(ILCode.Ldc_I4, out stateID);
			}
			return false;
		}
		return false;
	}

	protected void MarkAsGeneratedVariable(ILVariable v)
	{
		if (v.OriginalVariable != null && v.OriginalVariable.Index >= 0)
		{
			smallestGeneratedVariableIndex = Math.Min(smallestGeneratedVariableIndex, v.OriginalVariable.Index);
		}
	}

	private void MarkGeneratedVariables(List<ILNode> newTopLevelBody)
	{
		List<ILExpression> selfAndChildrenRecursive = new ILBlock(newTopLevelBody).GetSelfAndChildrenRecursive<ILExpression>();
		foreach (ILVariable item in selfAndChildrenRecursive.Select((ILExpression e) => e.Operand).OfType<ILVariable>())
		{
			if (item.OriginalVariable != null && item.OriginalVariable.Index >= smallestGeneratedVariableIndex)
			{
				item.GeneratedByDecompiler = true;
			}
		}
	}

	public void RunStep2(DecompilerContext context, ILBlock method, out AsyncMethodDebugInfo asyncInfo, List<ILExpression> listExpr, List<ILBlock> listBlock, Dictionary<ILLabel, int> labelRefCount, List<ILNode> list_ILNode, Func<ILBlock, ILInlining> getILInlining)
	{
		Step2(method);
		BaseMethodWrapperFixer.FixBaseCalls(context.CurrentMethod.DeclaringType, method, listExpr);
		ILAstOptimizer.RemoveRedundantCode(context, method, listExpr, listBlock, labelRefCount);
		ILInlining iLInlining = getILInlining(method);
		iLInlining.InlineAllVariables();
		iLInlining.CopyPropagation(list_ILNode);
		if (context.CalculateILSpans)
		{
			AsyncStepInfo[] array = new AsyncStepInfo[asyncStepInfoMap.Count];
			int num = 0;
			foreach (KeyValuePair<int, TempAsyncStepInfo> item in asyncStepInfoMap)
			{
				TempAsyncStepInfo value = item.Value;
				if (value.YieldOffset != 0 && value.ResumeLabel != null && GetLabelOffset(value.ResumeLabel, out var labelOffset))
				{
					array[num++] = new AsyncStepInfo(value.YieldOffset, moveNextMethod, labelOffset);
				}
			}
			if (array.Length != num)
			{
				Array.Resize(ref array, num);
			}
			if (context.CurrentMethod.MethodSig.RetType.RemovePinnedAndModifiers().GetElementType() != ElementType.Void)
			{
				catchHandlerOffset = uint.MaxValue;
			}
			asyncInfo = new AsyncMethodDebugInfo(array, builderField, catchHandlerOffset, setResultOffset);
		}
		else
		{
			asyncInfo = null;
		}
	}

	protected abstract void Step2(ILBlock method);

	private static bool GetLabelOffset(ILLabel lbl, out uint labelOffset)
	{
		if (lbl.Offset != uint.MaxValue)
		{
			labelOffset = lbl.Offset;
			return true;
		}
		labelOffset = 0u;
		return false;
	}

	protected void RemoveAsyncStepInfoState(int stateId)
	{
		asyncStepInfoMap.Remove(stateId);
	}

	protected void AddYieldOffset(List<ILNode> body, int index, int count, int stateId)
	{
		if (context.CalculateILSpans)
		{
			asyncStepInfoMap.TryGetValue(stateId, out var value);
			value.YieldOffset = GetNextOffset(body, index, count);
			asyncStepInfoMap[stateId] = value;
		}
	}

	protected void AddResumeLabel(ILLabel resumeLabel, int stateId)
	{
		if (context.CalculateILSpans)
		{
			asyncStepInfoMap.TryGetValue(stateId, out var value);
			if (value.ResumeLabel == null || value.ResumeLabel.Offset == 0 || resumeLabel.Offset > value.ResumeLabel.Offset)
			{
				value.ResumeLabel = resumeLabel;
				asyncStepInfoMap[stateId] = value;
			}
		}
	}

	private static uint GetNextOffset(List<ILNode> body, int index, int count)
	{
		uint num = 0u;
		for (int i = 0; i < count; i++)
		{
			foreach (ILSpan selfAndChildrenRecursiveILSpan in body[index + i].GetSelfAndChildrenRecursiveILSpans())
			{
				num = Math.Max(num, selfAndChildrenRecursiveILSpan.End);
			}
		}
		return num;
	}

	private static uint GetOffset(List<ILNode> body, int index, int count)
	{
		uint num = uint.MaxValue;
		for (int i = 0; i < count; i++)
		{
			foreach (ILSpan selfAndChildrenRecursiveILSpan in body[index + i].GetSelfAndChildrenRecursiveILSpans())
			{
				num = Math.Min(num, selfAndChildrenRecursiveILSpan.Start);
			}
		}
		if (num != uint.MaxValue)
		{
			return num;
		}
		return 0u;
	}

	protected LabelRangeMapping CreateLabelRangeMapping(StateRangeAnalysis rangeAnalysis, List<ILNode> body, int pos, int bodyLength)
	{
		LabelRangeMapping labelRangeMapping = rangeAnalysis.CreateLabelRangeMapping(body, pos, bodyLength);
		if (context.CalculateILSpans)
		{
			foreach (KeyValuePair<ILLabel, StateRange> item in labelRangeMapping)
			{
				int? num = item.Value.TryGetSingleState();
				if (num.HasValue)
				{
					AddResumeLabel(item.Key, num.Value);
				}
			}
		}
		return labelRangeMapping;
	}
}

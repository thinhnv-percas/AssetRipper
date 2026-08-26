using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

internal abstract class YieldReturnDecompiler
{
	protected readonly DecompilerContext context;

	protected readonly AutoPropertyProvider autoPropertyProvider;

	protected TypeDef enumeratorType;

	protected MethodDef enumeratorCtor;

	protected MethodDef disposeMethod;

	protected FieldDef stateField;

	protected FieldDef currentField;

	protected FieldToVariableMap variableMap;

	protected List<ILNode> newBody;

	protected MethodDef iteratorMoveNextMethod;

	protected ILVariable cachedThisVar;

	private static readonly UTF8String nameGetObjectValue = new UTF8String("GetObjectValue");

	public abstract string CompilerName { get; }

	protected YieldReturnDecompiler(DecompilerContext context, AutoPropertyProvider autoPropertyProvider)
	{
		this.context = context;
		this.autoPropertyProvider = autoPropertyProvider;
		variableMap = context.VariableMap;
	}

	private static YieldReturnDecompiler TryCreate(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		return MicrosoftYieldReturnDecompiler.TryCreateCore(context, method, autoPropertyProvider) ?? MonoYieldReturnDecompiler.TryCreateCore(context, method, autoPropertyProvider) ?? VisualBasic11YieldReturnDecompiler.TryCreateCore(context, method, autoPropertyProvider);
	}

	public static void Run(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider, ref StateMachineKind stateMachineKind, ref MethodDef inlinedMethod, ref string compilerName, List<ILNode> list_ILNode, Func<ILBlock, ILInlining> getILInlining, List<ILExpression> listExpr, List<ILBlock> listBlock, Dictionary<ILLabel, int> labelRefCount)
	{
		if (!context.Settings.YieldReturn)
		{
			return;
		}
		YieldReturnDecompiler yieldReturnDecompiler = TryCreate(context, method, autoPropertyProvider);
		if (yieldReturnDecompiler != null)
		{
			try
			{
				yieldReturnDecompiler.Run();
			}
			catch (SymbolicAnalysisFailedException)
			{
				return;
			}
			context.CurrentMethodIsYieldReturn = true;
			method.Body.Clear();
			method.EntryGoto = null;
			method.Body.AddRange(yieldReturnDecompiler.newBody);
			stateMachineKind = StateMachineKind.IteratorMethod;
			inlinedMethod = yieldReturnDecompiler.iteratorMoveNextMethod;
			compilerName = yieldReturnDecompiler.CompilerName;
			BaseMethodWrapperFixer.FixBaseCalls(context.CurrentMethod.DeclaringType, method, listExpr);
			ILInlining iLInlining = getILInlining(method);
			iLInlining.InlineAllVariables();
			iLInlining.CopyPropagation(list_ILNode);
			ILAstOptimizer.RemoveRedundantCode(context, method, listExpr, listBlock, labelRefCount);
		}
	}

	private void Run()
	{
		AnalyzeCtor();
		AnalyzeCurrentProperty();
		ResolveIEnumerableIEnumeratorFieldMapping();
		AnalyzeDispose();
		AnalyzeMoveNext();
		TranslateFieldsToLocalAccess();
	}

	public static bool IsCompilerGeneratorEnumerator(TypeDef type)
	{
		if (type.DeclaringType == null || !type.IsCompilerGenerated())
		{
			return false;
		}
		foreach (InterfaceImpl @interface in type.Interfaces)
		{
			if (@interface.Interface != null && @interface.Interface.Name == "IEnumerator" && @interface.Interface.Namespace == "System.Collections")
			{
				return true;
			}
		}
		return false;
	}

	protected static FieldDef GetFieldDefinition(IField field)
	{
		return field.ResolveFieldWithinSameModule();
	}

	protected static MethodDef GetMethodDefinition(IMethod method)
	{
		return method.ResolveMethodWithinSameModule();
	}

	protected virtual void AnalyzeCtor()
	{
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

	protected bool InitializeFieldToParameterMap(ILBlock method, ILVariable enumVar, ref int i)
	{
		return InitializeFieldToParameterMap(method, enumVar, ref i, method.Body.Count);
	}

	protected bool InitializeFieldToParameterMap(ILBlock method, ILVariable enumVar, ref int i, int end)
	{
		IField operand;
		ILExpression arg;
		ILExpression arg2;
		while (i < end && method.Body[i].Match<IField>(ILCode.Stfld, out operand, out arg, out arg2))
		{
			if (!((ILNode)arg).Match(ILCode.Ldloc, out ILVariable operand2))
			{
				return false;
			}
			if (!((ILNode)arg2).Match(ILCode.Ldloc, out ILVariable operand3) && (!((ILNode)arg2).Match(ILCode.Ldobj, out ITypeDefOrRef _, out arg) || !((ILNode)arg).Match(ILCode.Ldloc, out operand3)))
			{
				if (!((ILNode)arg2).Match(ILCode.Call, out IMethod operand5, out arg) || !((ILNode)arg).Match(ILCode.Ldloc, out operand3))
				{
					return false;
				}
				if (operand5.Name != nameGetObjectValue)
				{
					return false;
				}
				if (operand5.DeclaringType.FullName != "System.Runtime.CompilerServices.RuntimeHelpers")
				{
					return false;
				}
			}
			if (operand2 != enumVar)
			{
				return false;
			}
			FieldDef fieldDefinition = GetFieldDefinition(operand);
			if (fieldDefinition == null || !operand3.IsParameter)
			{
				return false;
			}
			variableMap.SetParameter(fieldDefinition, operand3);
			i++;
		}
		return true;
	}

	private void AnalyzeCurrentProperty()
	{
		foreach (MethodDef item in MethodUtils.GetMethod_get_Current(enumeratorType))
		{
			ILBlock iLBlock = CreateILAst(item);
			ILVariable operand2;
			ILExpression arg3;
			IField operand3;
			ILExpression arg4;
			ILExpression arg5;
			ILVariable operand4;
			if (iLBlock.Body.Count == 1)
			{
				if (iLBlock.Body[0].Match(ILCode.Ret, out ILExpression arg) && ((ILNode)arg).Match(ILCode.Ldfld, out IField operand, out ILExpression arg2) && arg2.MatchThis())
				{
					currentField = GetFieldDefinition(operand);
				}
			}
			else if (iLBlock.Body.Count == 2 && iLBlock.Body[0].Match(ILCode.Stloc, out operand2, out arg3) && ((ILNode)arg3).Match(ILCode.Ldfld, out operand3, out arg4) && arg4.MatchThis() && iLBlock.Body[1].Match(ILCode.Ret, out arg5) && ((ILNode)arg5).Match(ILCode.Ldloc, out operand4) && operand2 == operand4)
			{
				currentField = GetFieldDefinition(operand3);
			}
			if (currentField != null)
			{
				break;
			}
		}
		if (currentField == null)
		{
			throw new SymbolicAnalysisFailedException();
		}
	}

	private void ResolveIEnumerableIEnumeratorFieldMapping()
	{
		foreach (MethodDef item in MethodUtils.GetMethod_GetEnumerator(enumeratorType))
		{
			bool flag = false;
			ILBlock iLBlock = CreateILAst(item);
			foreach (ILNode item2 in iLBlock.Body)
			{
				if (item2.Match<IField>(ILCode.Stfld, out var operand, out var _, out var arg2) && (((ILNode)arg2).Match(ILCode.Ldfld, out IField operand2, out ILExpression arg3) || (((ILNode)arg2).Match(ILCode.Call, out IMethod operand3, out arg2) && operand3.Name == nameGetObjectValue && operand3.DeclaringType.FullName == "System.Runtime.CompilerServices.RuntimeHelpers" && ((ILNode)arg2).Match(ILCode.Ldfld, out operand2, out arg3))) && arg3.MatchThis())
				{
					flag = true;
					FieldDef fieldDefinition = GetFieldDefinition(operand);
					FieldDef fieldDefinition2 = GetFieldDefinition(operand2);
					if (fieldDefinition != null && fieldDefinition2 != null && variableMap.TryGetParameter(fieldDefinition2, out var parameter))
					{
						variableMap.SetParameter(fieldDefinition, parameter);
					}
				}
			}
			if (flag)
			{
				break;
			}
		}
	}

	protected abstract void AnalyzeDispose();

	protected abstract void AnalyzeMoveNext();

	private void TranslateFieldsToLocalAccess()
	{
		TranslateFieldsToLocalAccess(newBody, variableMap, cachedThisVar, context.CalculateILSpans, fixLocals: true);
	}

	internal static void TranslateFieldsToLocalAccess(List<ILNode> newBody, FieldToVariableMap variableMap, ILVariable cachedThisField, bool calculateILSpans, bool fixLocals)
	{
		variableMap.Version++;
		ILVariable iLVariable = null;
		if (cachedThisField != null)
		{
			foreach (KeyValuePair<FieldDef, ILVariable> parameter2 in variableMap.GetParameters())
			{
				Parameter originalParameter = parameter2.Value.OriginalParameter;
				if (originalParameter != null && originalParameter.IsHiddenThisParameter)
				{
					iLVariable = parameter2.Value;
					break;
				}
			}
			if (iLVariable == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
		List<ILExpression> list = null;
		foreach (ILNode item in newBody)
		{
			foreach (ILExpression item2 in item.GetSelfAndChildrenRecursive(list ?? (list = new List<ILExpression>())))
			{
				ILVariable parameter;
				ILVariable local;
				switch (item2.Code)
				{
				case ILCode.Ldfld:
				{
					FieldDef fieldDefinition;
					if (!item2.Arguments[0].MatchThis() || (fieldDefinition = GetFieldDefinition(item2.Operand as IField)) == null)
					{
						break;
					}
					if (variableMap.TryGetParameter(fieldDefinition, out parameter))
					{
						item2.Operand = parameter;
					}
					else if (!fixLocals)
					{
						if (!variableMap.TryGetLocal(fieldDefinition, out local))
						{
							break;
						}
						item2.Operand = local;
					}
					else
					{
						item2.Operand = variableMap.GetOrCreateLocal(fieldDefinition);
					}
					item2.Code = ILCode.Ldloc;
					if (calculateILSpans)
					{
						item2.ILSpans.AddRange(item2.Arguments[0].GetSelfAndChildrenRecursiveILSpans());
					}
					item2.Arguments.Clear();
					break;
				}
				case ILCode.Stfld:
				{
					FieldDef fieldDefinition;
					if (!item2.Arguments[0].MatchThis() || (fieldDefinition = GetFieldDefinition(item2.Operand as IField)) == null)
					{
						break;
					}
					if (variableMap.TryGetParameter(fieldDefinition, out parameter))
					{
						item2.Operand = parameter;
					}
					else if (!fixLocals)
					{
						if (!variableMap.TryGetLocal(fieldDefinition, out local))
						{
							break;
						}
						item2.Operand = local;
					}
					else
					{
						item2.Operand = variableMap.GetOrCreateLocal(fieldDefinition);
					}
					item2.Code = ILCode.Stloc;
					if (calculateILSpans)
					{
						item2.ILSpans.AddRange(item2.Arguments[0].GetSelfAndChildrenRecursiveILSpans());
					}
					item2.Arguments.RemoveAt(0);
					break;
				}
				case ILCode.Ldflda:
				{
					FieldDef fieldDefinition;
					if (!item2.Arguments[0].MatchThis() || (fieldDefinition = GetFieldDefinition(item2.Operand as IField)) == null)
					{
						break;
					}
					if (variableMap.TryGetParameter(fieldDefinition, out parameter))
					{
						item2.Operand = parameter;
					}
					else if (!fixLocals)
					{
						if (!variableMap.TryGetLocal(fieldDefinition, out local))
						{
							break;
						}
						item2.Operand = local;
					}
					else
					{
						item2.Operand = variableMap.GetOrCreateLocal(fieldDefinition);
					}
					item2.Code = ILCode.Ldloca;
					if (calculateILSpans)
					{
						item2.ILSpans.AddRange(item2.Arguments[0].GetSelfAndChildrenRecursiveILSpans());
					}
					item2.Arguments.Clear();
					break;
				}
				case ILCode.Ldloc:
					if (item2.Operand == cachedThisField)
					{
						item2.Operand = iLVariable;
					}
					break;
				}
			}
		}
		if (!calculateILSpans)
		{
			return;
		}
		foreach (KeyValuePair<FieldDef, ILVariable> parameter3 in variableMap.GetParameters())
		{
			parameter3.Value.HoistedField = parameter3.Key;
		}
	}
}

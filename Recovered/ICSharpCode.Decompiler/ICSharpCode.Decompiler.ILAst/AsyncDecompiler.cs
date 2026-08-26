using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	internal class AsyncDecompiler
	{
		private enum AsyncMethodType
		{
			Void,
			Task,
			TaskOfT
		}

		private DecompilerContext context;

		private AsyncMethodType methodType;

		private int initialState;

		private TypeDefinition stateMachineStruct;

		private MethodDefinition moveNextMethod;

		private FieldDefinition builderField;

		private FieldDefinition stateField;

		private Dictionary<FieldDefinition, ILVariable> fieldToParameterMap = new Dictionary<FieldDefinition, ILVariable>();

		private ILVariable cachedStateVar;

		private int finalState = -2;

		private ILTryCatchBlock mainTryCatch;

		private ILLabel setResultAndExitLabel;

		private ILLabel exitLabel;

		private ILExpression resultExpr;

		private ILVariable doFinallyBodies;

		private List<ILNode> newTopLevelBody;

		private int smallestGeneratedVariableIndex = int.MaxValue;

		public static bool IsCompilerGeneratedStateMachine(TypeDefinition type)
		{
			if (type.DeclaringType == null || !type.IsCompilerGenerated())
			{
				return false;
			}
			foreach (TypeReference @interface in type.Interfaces)
			{
				if (@interface.Namespace == "System.Runtime.CompilerServices" && @interface.Name == "IAsyncStateMachine")
				{
					return true;
				}
			}
			return false;
		}

		public static void RunStep1(DecompilerContext context, ILBlock method)
		{
			if (context.Settings.AsyncAwait)
			{
				AsyncDecompiler asyncDecompiler = new AsyncDecompiler();
				asyncDecompiler.context = context;
				if (asyncDecompiler.MatchTaskCreationPattern(method))
				{
					try
					{
						asyncDecompiler.Run();
					}
					catch (SymbolicAnalysisFailedException)
					{
						return;
					}
					context.CurrentMethodIsAsync = true;
					method.Body.Clear();
					method.EntryGoto = null;
					method.Body.AddRange(asyncDecompiler.newTopLevelBody);
					ILAstOptimizer.RemoveRedundantCode(method);
				}
			}
		}

		private void Run()
		{
			AnalyzeMoveNext();
			ValidateCatchBlock(mainTryCatch.CatchBlocks[0]);
			AnalyzeStateMachine(mainTryCatch.TryBlock);
			MarkGeneratedVariables();
			YieldReturnDecompiler.TranslateFieldsToLocalAccess(newTopLevelBody, fieldToParameterMap);
		}

		private bool MatchTaskCreationPattern(ILBlock method)
		{
			if (method.Body.Count < 5)
			{
				return false;
			}
			if (!method.Body[method.Body.Count - 2].Match(ILCode.Call, out MethodReference operand, out ILExpression arg, out ILExpression arg2))
			{
				return false;
			}
			if (operand.Name != "Start" || operand.DeclaringType == null || operand.DeclaringType.Namespace != "System.Runtime.CompilerServices")
			{
				return false;
			}
			switch (operand.DeclaringType.Name)
			{
			case "AsyncTaskMethodBuilder`1":
				methodType = AsyncMethodType.TaskOfT;
				break;
			case "AsyncTaskMethodBuilder":
				methodType = AsyncMethodType.Task;
				break;
			case "AsyncVoidMethodBuilder":
				methodType = AsyncMethodType.Void;
				break;
			default:
				return false;
			}
			if (!arg.Match(ILCode.Ldloca, out ILVariable operand2))
			{
				return false;
			}
			if (!arg2.Match(ILCode.Ldloca, out ILVariable operand3))
			{
				return false;
			}
			stateMachineStruct = operand3.Type.ResolveWithinSameModule();
			if (stateMachineStruct == null || !stateMachineStruct.IsValueType)
			{
				return false;
			}
			moveNextMethod = stateMachineStruct.Methods.FirstOrDefault((MethodDefinition f) => f.Name == "MoveNext");
			if (moveNextMethod == null)
			{
				return false;
			}
			if (!method.Body[method.Body.Count - 3].MatchStloc(operand2, out ILExpression expr))
			{
				return false;
			}
			if (!expr.Match(ILCode.Ldfld, out FieldReference operand4, out ILExpression arg3))
			{
				return false;
			}
			if (!arg3.MatchLdloca(operand3) && !arg3.MatchLdloc(operand3))
			{
				return false;
			}
			builderField = operand4.ResolveWithinSameModule();
			if (builderField == null)
			{
				return false;
			}
			if (methodType == AsyncMethodType.Void)
			{
				if (!method.Body[method.Body.Count - 1].Match(ILCode.Ret))
				{
					return false;
				}
			}
			else
			{
				if (!method.Body[method.Body.Count - 1].Match(ILCode.Ret, out ILExpression arg4))
				{
					return false;
				}
				if (!arg4.Match(ILCode.Call, out MethodReference _, out ILExpression arg5))
				{
					return false;
				}
				if (!arg5.Match(ILCode.Ldflda, out FieldReference operand6, out ILExpression arg6))
				{
					return false;
				}
				if (operand6.ResolveWithinSameModule() != builderField || !arg6.MatchLdloca(operand3))
				{
					return false;
				}
			}
			if (!MatchStFld(method.Body[method.Body.Count - 4], operand3, out stateField, out ILExpression expr2))
			{
				return false;
			}
			if (!expr2.Match(ILCode.Ldc_I4, out initialState))
			{
				return false;
			}
			if (initialState != -1)
			{
				return false;
			}
			if (!MatchStFld(method.Body[method.Body.Count - 5], operand3, out FieldDefinition field, out ILExpression expr3))
			{
				return false;
			}
			if (field != builderField || !expr3.Match(ILCode.Call, out MethodReference operand7))
			{
				return false;
			}
			if (operand7.Name != "Create")
			{
				return false;
			}
			for (int i = 0; i < method.Body.Count - 5; i++)
			{
				if (!MatchStFld(method.Body[i], operand3, out FieldDefinition field2, out ILExpression expr4))
				{
					return false;
				}
				if (!expr4.Match(ILCode.Ldloc, out ILVariable operand8))
				{
					return false;
				}
				if (!operand8.IsParameter)
				{
					return false;
				}
				fieldToParameterMap[field2] = operand8;
			}
			return true;
		}

		private static bool MatchStFld(ILNode stfld, ILVariable stateMachineVar, out FieldDefinition field, out ILExpression expr)
		{
			field = null;
			if (!stfld.Match(ILCode.Stfld, out FieldReference operand, out ILExpression arg, out expr))
			{
				return false;
			}
			field = operand.ResolveWithinSameModule();
			if (field != null)
			{
				return arg.MatchLdloca(stateMachineVar);
			}
			return false;
		}

		private void AnalyzeMoveNext()
		{
			ILBlock iLBlock = CreateILAst(moveNextMethod);
			int num;
			if (iLBlock.Body.Count == 6)
			{
				num = 0;
			}
			else
			{
				if (iLBlock.Body.Count != 7)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!iLBlock.Body[0].Match(ILCode.Stloc, out cachedStateVar, out ILExpression arg))
				{
					throw new SymbolicAnalysisFailedException();
				}
				ILExpression arg2;
				if (!arg.Match(ILCode.Ldfld, out FieldReference operand, out arg2) || operand.ResolveWithinSameModule() != stateField || !arg2.MatchThis())
				{
					throw new SymbolicAnalysisFailedException();
				}
				num = 1;
			}
			mainTryCatch = (iLBlock.Body[num] as ILTryCatchBlock);
			if (mainTryCatch == null || mainTryCatch.CatchBlocks.Count != 1)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (mainTryCatch.FaultBlock != null || mainTryCatch.FinallyBlock != null)
			{
				throw new SymbolicAnalysisFailedException();
			}
			setResultAndExitLabel = (iLBlock.Body[num + 1] as ILLabel);
			if (setResultAndExitLabel == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!MatchStateAssignment(iLBlock.Body[num + 2], out finalState))
			{
				throw new SymbolicAnalysisFailedException();
			}
			MethodReference operand2;
			ILExpression arg3;
			if (methodType == AsyncMethodType.TaskOfT)
			{
				if (!iLBlock.Body[num + 3].Match(ILCode.Call, out operand2, out arg3, out resultExpr))
				{
					throw new SymbolicAnalysisFailedException();
				}
			}
			else if (!iLBlock.Body[num + 3].Match(ILCode.Call, out operand2, out arg3))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!(operand2.Name == "SetResult") || !IsBuilderFieldOnThis(arg3))
			{
				throw new SymbolicAnalysisFailedException();
			}
			exitLabel = (iLBlock.Body[num + 4] as ILLabel);
			if (exitLabel == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}

		private ILBlock CreateILAst(MethodDefinition method)
		{
			if (method == null || !method.HasBody)
			{
				throw new SymbolicAnalysisFailedException();
			}
			ILBlock iLBlock = new ILBlock();
			ILAstBuilder iLAstBuilder = new ILAstBuilder();
			iLBlock.Body = iLAstBuilder.Build(method, optimize: true, context);
			new ILAstOptimizer().Optimize(context, iLBlock, ILAstOptimizationStep.YieldReturn);
			return iLBlock;
		}

		private void ValidateCatchBlock(ILTryCatchBlock.CatchBlock catchBlock)
		{
			if (catchBlock.ExceptionType == null || catchBlock.ExceptionType.Name != "Exception")
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (catchBlock.Body.Count != 3)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!MatchStateAssignment(catchBlock.Body[0], out int stateID) || stateID != finalState)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!catchBlock.Body[1].Match(ILCode.Call, out MethodReference operand, out ILExpression arg, out ILExpression arg2))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!(operand.Name == "SetException") || !IsBuilderFieldOnThis(arg) || !arg2.MatchLdloc(catchBlock.ExceptionVariable))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!catchBlock.Body[2].Match(ILCode.Leave, out ILLabel operand2) || operand2 != exitLabel)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}

		private bool IsBuilderFieldOnThis(ILExpression builderExpr)
		{
			if (builderExpr.Match(ILCode.Ldflda, out FieldReference operand, out ILExpression arg) && operand.ResolveWithinSameModule() == builderField)
			{
				return arg.MatchThis();
			}
			return false;
		}

		private bool MatchStateAssignment(ILNode stfld, out int stateID)
		{
			stateID = 0;
			if (stfld.Match(ILCode.Stfld, out FieldReference operand, out ILExpression arg, out ILExpression arg2))
			{
				if (operand.ResolveWithinSameModule() == stateField && arg.MatchThis())
				{
					return arg2.Match(ILCode.Ldc_I4, out stateID);
				}
				return false;
			}
			return false;
		}

		private bool MatchRoslynStateAssignment(List<ILNode> block, int index, out int stateID)
		{
			stateID = 0;
			if (index < 0)
			{
				return false;
			}
			if (!block[index].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || !arg.Match(ILCode.Ldc_I4, out stateID))
			{
				return false;
			}
			if (!block[index + 1].MatchStloc(cachedStateVar, out ILExpression expr) || !expr.MatchLdloc(operand))
			{
				return false;
			}
			if (block[index + 2].Match(ILCode.Stfld, out FieldReference operand2, out ILExpression arg2, out expr))
			{
				if (operand2.ResolveWithinSameModule() == stateField && arg2.MatchThis())
				{
					return expr.MatchLdloc(operand);
				}
				return false;
			}
			return false;
		}

		private void AnalyzeStateMachine(ILBlock block)
		{
			List<ILNode> body = block.Body;
			if (body.Count == 0)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (DetectDoFinallyBodies(body))
			{
				body.RemoveAt(0);
				if (body.Count == 0)
				{
					throw new SymbolicAnalysisFailedException();
				}
			}
			StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(body[0], StateRangeAnalysisMode.AsyncMoveNext, stateField, cachedStateVar);
			int bodyLength = block.Body.Count;
			int pos = stateRangeAnalysis.AssignStateRanges(body, bodyLength);
			stateRangeAnalysis.EnsureLabelAtPos(body, ref pos, ref bodyLength);
			LabelRangeMapping mapping = stateRangeAnalysis.CreateLabelRangeMapping(body, pos, bodyLength);
			newTopLevelBody = ConvertBody(body, pos, bodyLength, mapping);
			newTopLevelBody.Insert(0, MakeGoTo(mapping, initialState));
			newTopLevelBody.Add(setResultAndExitLabel);
			if (methodType == AsyncMethodType.TaskOfT)
			{
				newTopLevelBody.Add(new ILExpression(ILCode.Ret, null, resultExpr));
			}
			else
			{
				newTopLevelBody.Add(new ILExpression(ILCode.Ret, null));
			}
		}

		private bool DetectDoFinallyBodies(List<ILNode> body)
		{
			if (!body[0].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
			{
				return false;
			}
			if (!arg.Match(ILCode.Ldc_I4, out int operand2) || operand2 != 1)
			{
				return false;
			}
			doFinallyBodies = operand;
			return true;
		}

		private ILExpression MakeGoTo(LabelRangeMapping mapping, int state)
		{
			foreach (KeyValuePair<ILLabel, StateRange> item in mapping)
			{
				if (item.Value.Contains(state))
				{
					return new ILExpression(ILCode.Br, item.Key);
				}
			}
			throw new SymbolicAnalysisFailedException();
		}

		private List<ILNode> ConvertBody(List<ILNode> body, int startPos, int bodyLength, LabelRangeMapping mapping)
		{
			List<ILNode> list = new List<ILNode>();
			for (int i = startPos; i < bodyLength; i++)
			{
				ILTryCatchBlock iLTryCatchBlock = body[i] as ILTryCatchBlock;
				ILExpression iLExpression = body[i] as ILExpression;
				if (iLExpression != null && iLExpression.Code == ILCode.Leave && iLExpression.Operand == exitLabel)
				{
					HandleAwait(list, out ILVariable awaiterVar, out FieldDefinition _, out int targetStateID);
					MarkAsGeneratedVariable(awaiterVar);
					list.Add(new ILExpression(ILCode.Await, null, new ILExpression(ILCode.Ldloca, awaiterVar)));
					list.Add(MakeGoTo(mapping, targetStateID));
				}
				else if (iLTryCatchBlock != null)
				{
					ILTryCatchBlock iLTryCatchBlock2 = new ILTryCatchBlock();
					List<ILNode> body2 = iLTryCatchBlock.TryBlock.Body;
					if (body2.Count == 0)
					{
						throw new SymbolicAnalysisFailedException();
					}
					StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(body2[0], StateRangeAnalysisMode.AsyncMoveNext, stateField, cachedStateVar);
					int bodyLength2 = body2.Count;
					int pos = stateRangeAnalysis.AssignStateRanges(body2, bodyLength2);
					stateRangeAnalysis.EnsureLabelAtPos(body2, ref pos, ref bodyLength2);
					LabelRangeMapping mapping2 = stateRangeAnalysis.CreateLabelRangeMapping(body2, pos, bodyLength2);
					List<ILNode> list2 = ConvertBody(body2, pos, bodyLength2, mapping2);
					list2.Insert(0, MakeGoTo(mapping2, initialState));
					if (pos > 0 && body2.FirstOrDefault() is ILLabel)
					{
						list2.Insert(0, body2.First());
					}
					iLTryCatchBlock2.TryBlock = new ILBlock(list2);
					iLTryCatchBlock2.CatchBlocks = new List<ILTryCatchBlock.CatchBlock>(iLTryCatchBlock.CatchBlocks);
					iLTryCatchBlock2.FaultBlock = iLTryCatchBlock.FaultBlock;
					if (iLTryCatchBlock.FinallyBlock != null)
					{
						iLTryCatchBlock2.FinallyBlock = new ILBlock(ConvertFinally(iLTryCatchBlock.FinallyBlock.Body));
					}
					list.Add(iLTryCatchBlock2);
				}
				else
				{
					list.Add(body[i]);
				}
			}
			return list;
		}

		private List<ILNode> ConvertFinally(List<ILNode> body)
		{
			List<ILNode> list = new List<ILNode>(body);
			if (list.Count == 0)
			{
				return list;
			}
			if (list[0].Match(ILCode.Brtrue, out ILLabel _, out ILExpression arg) && MatchLogicNot(arg, out ILExpression arg2))
			{
				if (arg2.MatchLdloc(doFinallyBodies))
				{
					list.RemoveAt(0);
				}
				else if (arg2.Code == ILCode.Clt && arg2.Arguments[0].MatchLdloc(cachedStateVar) && arg2.Arguments[1].MatchLdcI4(0))
				{
					list.RemoveAt(0);
				}
			}
			return list;
		}

		private bool MatchLogicNot(ILExpression expr, out ILExpression arg)
		{
			if (expr.Match(ILCode.Ceq, out object _, out arg, out ILExpression arg2))
			{
				if (arg2.Match(ILCode.Ldc_I4, out int operand2))
				{
					return operand2 == 0;
				}
				return false;
			}
			return expr.Match(ILCode.LogicNot, out arg);
		}

		private void HandleAwait(List<ILNode> newBody, out ILVariable awaiterVar, out FieldDefinition awaiterField, out int targetStateID)
		{
			if (doFinallyBodies != null)
			{
				if (!newBody.LastOrDefault().MatchStloc(doFinallyBodies, out ILExpression expr))
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!expr.Match(ILCode.Ldc_I4, out int operand) || operand != 0)
				{
					throw new SymbolicAnalysisFailedException();
				}
				newBody.RemoveAt(newBody.Count - 1);
			}
			ILExpression iLExpression = newBody.LastOrDefault() as ILExpression;
			newBody.RemoveAt(newBody.Count - 1);
			if (iLExpression == null || iLExpression.Code != ILCode.Call)
			{
				throw new SymbolicAnalysisFailedException();
			}
			string name = ((MethodReference)iLExpression.Operand).Name;
			if (name != "AwaitUnsafeOnCompleted" && name != "AwaitOnCompleted")
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (iLExpression.Arguments.Count != 3)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!iLExpression.Arguments[1].Match(ILCode.Ldloca, out awaiterVar))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!newBody.LastOrDefault().Match(ILCode.Stfld, out FieldReference operand2, out ILExpression arg, out ILExpression arg2))
			{
				throw new SymbolicAnalysisFailedException();
			}
			newBody.RemoveAt(newBody.Count - 1);
			awaiterField = operand2.ResolveWithinSameModule();
			if (awaiterField == null || !arg.MatchThis() || !arg2.MatchLdloc(awaiterVar))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (MatchStateAssignment(newBody.LastOrDefault(), out targetStateID))
			{
				newBody.RemoveAt(newBody.Count - 1);
			}
			else if (MatchRoslynStateAssignment(newBody, newBody.Count - 3, out targetStateID))
			{
				newBody.RemoveRange(newBody.Count - 3, 3);
			}
		}

		private void MarkAsGeneratedVariable(ILVariable v)
		{
			if (v.OriginalVariable != null && v.OriginalVariable.Index >= 0)
			{
				smallestGeneratedVariableIndex = Math.Min(smallestGeneratedVariableIndex, v.OriginalVariable.Index);
			}
		}

		private void MarkGeneratedVariables()
		{
			foreach (ILVariable item in (from e in new ILBlock(newTopLevelBody).GetSelfAndChildrenRecursive<ILExpression>()
				select e.Operand).OfType<ILVariable>())
			{
				if (item.OriginalVariable != null && item.OriginalVariable.Index >= smallestGeneratedVariableIndex)
				{
					item.IsGenerated = true;
				}
			}
		}

		public static void RunStep2(DecompilerContext context, ILBlock method)
		{
			if (context.CurrentMethodIsAsync)
			{
				Step2(method.Body);
				ILAstOptimizer.RemoveRedundantCode(method);
				ILInlining iLInlining = new ILInlining(method);
				iLInlining.InlineAllVariables();
				iLInlining.CopyPropagation();
			}
		}

		private static void Step2(List<ILNode> body)
		{
			for (int i = 0; i < body.Count; i++)
			{
				ILTryCatchBlock iLTryCatchBlock = body[i] as ILTryCatchBlock;
				if (iLTryCatchBlock != null)
				{
					Step2(iLTryCatchBlock.TryBlock.Body);
				}
				else
				{
					Step2(body, ref i);
				}
			}
		}

		private static bool Step2(List<ILNode> body, ref int pos)
		{
			if (!body[pos].Match(ILCode.Await, out ILExpression arg))
			{
				return false;
			}
			if (!arg.Match(ILCode.Ldloca, out ILVariable operand))
			{
				return false;
			}
			ILVariable operand2;
			ILExpression arg2;
			while (pos >= 1 && body[pos - 1].Match(ILCode.Stloc, out operand2, out arg2))
			{
				pos--;
			}
			if (pos < 2 || !body[pos - 2].MatchStloc(operand, out ILExpression expr))
			{
				return false;
			}
			if (!expr.Match(ILCode.Call, out MethodReference operand3, out ILExpression arg3) && !expr.Match(ILCode.Callvirt, out operand3, out arg3))
			{
				return false;
			}
			if (arg3.Code == ILCode.AddressOf)
			{
				arg3 = arg3.Arguments[0];
			}
			if (pos < 1 || !body[pos - 1].Match(ILCode.Brtrue, out ILLabel operand4, out ILExpression _))
			{
				return false;
			}
			int num = body.IndexOf(operand4);
			if (num < pos)
			{
				return false;
			}
			for (int i = pos + 1; i < num; i++)
			{
				ILExpression iLExpression = body[i] as ILExpression;
				if (iLExpression == null)
				{
					return false;
				}
				switch (iLExpression.Code)
				{
				case ILCode.Stfld:
				case ILCode.Stloc:
				case ILCode.Initobj:
				case ILCode.Await:
					continue;
				}
				return false;
			}
			if (num + 1 >= body.Count)
			{
				return false;
			}
			ILExpression iLExpression2 = body[num + 1] as ILExpression;
			ILVariable operand5;
			ILExpression arg5;
			bool flag = iLExpression2.Match(ILCode.Stloc, out operand5, out arg5);
			if (!flag)
			{
				arg5 = iLExpression2;
			}
			if (!(arg5.Operand is MethodReference) || !(((MethodReference)arg5.Operand).Name == "GetResult"))
			{
				return false;
			}
			pos -= 2;
			body.RemoveRange(pos, num - pos);
			pos++;
			if (flag)
			{
				iLExpression2.Arguments[0] = new ILExpression(ILCode.Await, null, arg3);
			}
			else
			{
				body[pos] = new ILExpression(ILCode.Await, null, arg3);
			}
			if (IsVariableReset(body.ElementAtOrDefault(pos + 1), operand))
			{
				body.RemoveAt(pos + 1);
			}
			return true;
		}

		private static bool IsVariableReset(ILNode expr, ILVariable variable)
		{
			if (expr.Match(ILCode.Initobj, out object _, out ILExpression arg))
			{
				return arg.MatchLdloca(variable);
			}
			return false;
		}
	}
}

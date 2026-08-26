using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	internal class YieldReturnDecompiler
	{
		private struct SetState
		{
			public readonly int NewBodyPos;

			public readonly int NewState;

			public SetState(int newBodyPos, int newState)
			{
				NewBodyPos = newBodyPos;
				NewState = newState;
			}
		}

		private DecompilerContext context;

		private TypeDefinition enumeratorType;

		private MethodDefinition enumeratorCtor;

		private MethodDefinition disposeMethod;

		private FieldDefinition stateField;

		private FieldDefinition currentField;

		private Dictionary<FieldDefinition, ILVariable> fieldToParameterMap = new Dictionary<FieldDefinition, ILVariable>();

		private List<ILNode> newBody;

		private Dictionary<MethodDefinition, StateRange> finallyMethodToStateRange;

		private ILVariable returnVariable;

		private ILLabel returnLabel;

		private ILLabel returnFalseLabel;

		public static void Run(DecompilerContext context, ILBlock method)
		{
			if (context.Settings.YieldReturn)
			{
				YieldReturnDecompiler yieldReturnDecompiler = new YieldReturnDecompiler();
				yieldReturnDecompiler.context = context;
				if (yieldReturnDecompiler.MatchEnumeratorCreationPattern(method))
				{
					yieldReturnDecompiler.enumeratorType = yieldReturnDecompiler.enumeratorCtor.DeclaringType;
					try
					{
						yieldReturnDecompiler.Run();
					}
					catch (SymbolicAnalysisFailedException)
					{
						return;
					}
					method.Body.Clear();
					method.EntryGoto = null;
					method.Body.AddRange(yieldReturnDecompiler.newBody);
					ILInlining iLInlining = new ILInlining(method);
					iLInlining.InlineAllVariables();
					iLInlining.CopyPropagation();
				}
			}
		}

		private void Run()
		{
			AnalyzeCtor();
			AnalyzeCurrentProperty();
			ResolveIEnumerableIEnumeratorFieldMapping();
			ConstructExceptionTable();
			AnalyzeMoveNext();
			TranslateFieldsToLocalAccess();
		}

		private bool MatchEnumeratorCreationPattern(ILBlock method)
		{
			if (method.Body.Count == 0)
			{
				return false;
			}
			ILExpression arg;
			if (method.Body.Count == 1)
			{
				if (method.Body[0].Match(ILCode.Ret, out arg))
				{
					return MatchEnumeratorCreationNewObj(arg, out enumeratorCtor);
				}
				return false;
			}
			if (!method.Body[0].Match(ILCode.Stloc, out ILVariable operand, out arg))
			{
				return false;
			}
			if (!MatchEnumeratorCreationNewObj(arg, out enumeratorCtor))
			{
				return false;
			}
			int i;
			FieldReference operand2;
			ILExpression arg2;
			ILExpression arg3;
			for (i = 1; i < method.Body.Count && method.Body[i].Match(ILCode.Stfld, out operand2, out arg2, out arg3); i++)
			{
				if (!arg2.Match(ILCode.Ldloc, out ILVariable operand3) || !arg3.Match(ILCode.Ldloc, out ILVariable operand4))
				{
					return false;
				}
				operand2 = GetFieldDefinition(operand2);
				if (operand3 != operand || operand2 == null || !operand4.IsParameter)
				{
					return false;
				}
				fieldToParameterMap[(FieldDefinition)operand2] = operand4;
			}
			if (i < method.Body.Count && method.Body[i].Match(ILCode.Stloc, out ILVariable operand5, out ILExpression arg4))
			{
				if (arg4.Code != ILCode.Ldloc || arg4.Operand != operand)
				{
					return false;
				}
				i++;
			}
			else
			{
				operand5 = operand;
			}
			ILExpression arg5;
			if (i < method.Body.Count && method.Body[i].Match(ILCode.Ret, out arg5) && arg5.Code == ILCode.Ldloc && arg5.Operand == operand5)
			{
				return true;
			}
			return false;
		}

		private static FieldDefinition GetFieldDefinition(FieldReference field)
		{
			return field.ResolveWithinSameModule();
		}

		private static MethodDefinition GetMethodDefinition(MethodReference method)
		{
			return method.ResolveWithinSameModule();
		}

		private bool MatchEnumeratorCreationNewObj(ILExpression expr, out MethodDefinition ctor)
		{
			ctor = null;
			if (expr.Code != ILCode.Newobj || expr.Arguments.Count != 1)
			{
				return false;
			}
			if (expr.Arguments[0].Code != ILCode.Ldc_I4)
			{
				return false;
			}
			int num = (int)expr.Arguments[0].Operand;
			if (num != -2 && num != 0)
			{
				return false;
			}
			ctor = GetMethodDefinition(expr.Operand as MethodReference);
			if (ctor == null || ctor.DeclaringType.DeclaringType != context.CurrentType)
			{
				return false;
			}
			return IsCompilerGeneratorEnumerator(ctor.DeclaringType);
		}

		public static bool IsCompilerGeneratorEnumerator(TypeDefinition type)
		{
			if (type.DeclaringType == null || !type.IsCompilerGenerated())
			{
				return false;
			}
			foreach (TypeReference @interface in type.Interfaces)
			{
				if (@interface.Namespace == "System.Collections" && @interface.Name == "IEnumerator")
				{
					return true;
				}
			}
			return false;
		}

		private void AnalyzeCtor()
		{
			foreach (ILNode item in CreateILAst(enumeratorCtor).Body)
			{
				ILVariable operand2;
				if (item.Match(ILCode.Stfld, out FieldReference operand, out ILExpression arg, out ILExpression arg2) && arg.MatchThis() && arg2.Match(ILCode.Ldloc, out operand2) && operand2.IsParameter && operand2.OriginalParameter.Index == 0)
				{
					stateField = GetFieldDefinition(operand);
				}
			}
			if (stateField == null)
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

		private void AnalyzeCurrentProperty()
		{
			MethodDefinition method = enumeratorType.Methods.FirstOrDefault((MethodDefinition m) => m.Name.StartsWith("System.Collections.Generic.IEnumerator", StringComparison.Ordinal) && m.Name.EndsWith(".get_Current", StringComparison.Ordinal));
			ILBlock iLBlock = CreateILAst(method);
			ILVariable operand2;
			ILVariable operand4;
			ILExpression arg5;
			ILExpression arg4;
			ILExpression arg3;
			FieldReference operand3;
			if (iLBlock.Body.Count == 1)
			{
				ILExpression arg2;
				if (iLBlock.Body[0].Match(ILCode.Ret, out ILExpression arg) && arg.Match(ILCode.Ldfld, out FieldReference operand, out arg2) && arg2.MatchThis())
				{
					currentField = GetFieldDefinition(operand);
				}
			}
			else if (iLBlock.Body.Count == 2 && iLBlock.Body[0].Match(ILCode.Stloc, out operand2, out arg3) && arg3.Match(ILCode.Ldfld, out operand3, out arg4) && arg4.MatchThis() && iLBlock.Body[1].Match(ILCode.Ret, out arg5) && arg5.Match(ILCode.Ldloc, out operand4) && operand2 == operand4)
			{
				currentField = GetFieldDefinition(operand3);
			}
			if (currentField == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}

		private void ResolveIEnumerableIEnumeratorFieldMapping()
		{
			MethodDefinition methodDefinition = enumeratorType.Methods.FirstOrDefault((MethodDefinition m) => m.Name.StartsWith("System.Collections.Generic.IEnumerable", StringComparison.Ordinal) && m.Name.EndsWith(".GetEnumerator", StringComparison.Ordinal));
			if (methodDefinition != null)
			{
				foreach (ILNode item in CreateILAst(methodDefinition).Body)
				{
					ILExpression arg3;
					if (item.Match(ILCode.Stfld, out FieldReference operand, out ILExpression _, out ILExpression arg2) && arg2.Match(ILCode.Ldfld, out FieldReference operand2, out arg3) && arg3.MatchThis())
					{
						FieldDefinition fieldDefinition = GetFieldDefinition(operand);
						FieldDefinition fieldDefinition2 = GetFieldDefinition(operand2);
						if (fieldDefinition != null && fieldDefinition2 != null && fieldToParameterMap.TryGetValue(fieldDefinition2, out ILVariable value))
						{
							fieldToParameterMap[fieldDefinition] = value;
						}
					}
				}
			}
		}

		private void ConstructExceptionTable()
		{
			disposeMethod = enumeratorType.Methods.FirstOrDefault((MethodDefinition m) => m.Name == "System.IDisposable.Dispose");
			ILBlock iLBlock = CreateILAst(disposeMethod);
			StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(iLBlock.Body[0], StateRangeAnalysisMode.IteratorDispose, stateField);
			stateRangeAnalysis.AssignStateRanges(iLBlock.Body, iLBlock.Body.Count);
			finallyMethodToStateRange = stateRangeAnalysis.finallyMethodToStateRange;
			foreach (ILTryCatchBlock item in iLBlock.GetSelfAndChildrenRecursive<ILTryCatchBlock>())
			{
				StateRange value = stateRangeAnalysis.ranges[item.TryBlock.Body[0]];
				List<ILNode> body = item.FinallyBlock.Body;
				if (body.Count != 2)
				{
					throw new SymbolicAnalysisFailedException();
				}
				ILExpression iLExpression = body[0] as ILExpression;
				if (iLExpression == null || iLExpression.Code != ILCode.Call || iLExpression.Arguments.Count != 1)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!iLExpression.Arguments[0].MatchThis())
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!body[1].Match(ILCode.Endfinally))
				{
					throw new SymbolicAnalysisFailedException();
				}
				MethodDefinition methodDefinition = GetMethodDefinition(iLExpression.Operand as MethodReference);
				if (methodDefinition == null || finallyMethodToStateRange.ContainsKey(methodDefinition))
				{
					throw new SymbolicAnalysisFailedException();
				}
				finallyMethodToStateRange.Add(methodDefinition, value);
			}
			stateRangeAnalysis = null;
		}

		private void AnalyzeMoveNext()
		{
			MethodDefinition method = enumeratorType.Methods.FirstOrDefault((MethodDefinition m) => m.Name == "MoveNext");
			ILBlock iLBlock = CreateILAst(method);
			if (iLBlock.Body.Count == 0)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!iLBlock.Body.Last().Match(ILCode.Ret, out ILExpression arg))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (arg.Code == ILCode.Ldloc)
			{
				returnVariable = (ILVariable)arg.Operand;
				returnLabel = (iLBlock.Body.ElementAtOrDefault(iLBlock.Body.Count - 2) as ILLabel);
				if (returnLabel == null)
				{
					throw new SymbolicAnalysisFailedException();
				}
			}
			else
			{
				returnVariable = null;
				returnLabel = null;
				if (arg.Code != ILCode.Ldc_I4 || (int)arg.Operand != 0)
				{
					throw new SymbolicAnalysisFailedException();
				}
			}
			ILTryCatchBlock iLTryCatchBlock = iLBlock.Body[0] as ILTryCatchBlock;
			List<ILNode> body;
			int bodyLength;
			if (iLTryCatchBlock != null)
			{
				if (returnVariable == null)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (iLTryCatchBlock.CatchBlocks.Count != 0 || iLTryCatchBlock.FinallyBlock != null || iLTryCatchBlock.FaultBlock == null)
				{
					throw new SymbolicAnalysisFailedException();
				}
				ILBlock faultBlock = iLTryCatchBlock.FaultBlock;
				if (faultBlock.Body.Count != 2)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!faultBlock.Body[0].Match(ILCode.Call, out MethodReference operand, out ILExpression arg2))
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (GetMethodDefinition(operand) != disposeMethod || !arg2.MatchThis())
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!faultBlock.Body[1].Match(ILCode.Endfinally))
				{
					throw new SymbolicAnalysisFailedException();
				}
				body = iLTryCatchBlock.TryBlock.Body;
				bodyLength = body.Count;
			}
			else
			{
				body = iLBlock.Body;
				bodyLength = ((returnVariable != null) ? (body.Count - 2) : (body.Count - 1));
			}
			if (returnVariable != null)
			{
				ILExpression iLExpression = body.ElementAtOrDefault(bodyLength - 1) as ILExpression;
				if (iLExpression != null && (iLExpression.Code == ILCode.Br || iLExpression.Code == ILCode.Leave) && iLExpression.Operand == returnLabel)
				{
					bodyLength--;
				}
				ILExpression iLExpression2 = body.ElementAtOrDefault(bodyLength - 1) as ILExpression;
				if (iLExpression2 == null || iLExpression2.Code != ILCode.Stloc || iLExpression2.Operand != returnVariable)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (iLExpression2.Arguments[0].Code != ILCode.Ldc_I4 || (int)iLExpression2.Arguments[0].Operand != 0)
				{
					throw new SymbolicAnalysisFailedException();
				}
				bodyLength--;
			}
			returnFalseLabel = (body.ElementAtOrDefault(bodyLength - 1) as ILLabel);
			StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(body[0], StateRangeAnalysisMode.IteratorMoveNext, stateField);
			int pos = stateRangeAnalysis.AssignStateRanges(body, bodyLength);
			stateRangeAnalysis.EnsureLabelAtPos(body, ref pos, ref bodyLength);
			LabelRangeMapping labels = stateRangeAnalysis.CreateLabelRangeMapping(body, pos, bodyLength);
			ConvertBody(body, pos, bodyLength, labels);
		}

		private void ConvertBody(List<ILNode> body, int startPos, int bodyLength, List<KeyValuePair<ILLabel, StateRange>> labels)
		{
			newBody = new List<ILNode>();
			newBody.Add(MakeGoTo(labels, 0));
			List<SetState> list = new List<SetState>();
			int num = -1;
			for (int i = startPos; i < bodyLength; i++)
			{
				ILExpression iLExpression = body[i] as ILExpression;
				if (iLExpression != null && iLExpression.Code == ILCode.Stfld && iLExpression.Arguments[0].MatchThis())
				{
					if (GetFieldDefinition(iLExpression.Operand as FieldReference) == stateField)
					{
						if (iLExpression.Arguments[1].Code != ILCode.Ldc_I4)
						{
							throw new SymbolicAnalysisFailedException();
						}
						num = (int)iLExpression.Arguments[1].Operand;
						list.Add(new SetState(newBody.Count, num));
					}
					else if (GetFieldDefinition(iLExpression.Operand as FieldReference) == currentField)
					{
						newBody.Add(new ILExpression(ILCode.YieldReturn, null, iLExpression.Arguments[1]));
					}
					else
					{
						newBody.Add(body[i]);
					}
				}
				else if (returnVariable != null && iLExpression != null && iLExpression.Code == ILCode.Stloc && iLExpression.Operand == returnVariable)
				{
					ILExpression iLExpression2 = body.ElementAtOrDefault(++i) as ILExpression;
					if (iLExpression2 == null || (iLExpression2.Code != ILCode.Br && iLExpression2.Code != ILCode.Leave) || iLExpression2.Operand != returnLabel || iLExpression.Arguments[0].Code != ILCode.Ldc_I4)
					{
						throw new SymbolicAnalysisFailedException();
					}
					switch ((int)iLExpression.Arguments[0].Operand)
					{
					case 0:
						newBody.Add(new ILExpression(ILCode.YieldBreak, null));
						break;
					case 1:
						newBody.Add(MakeGoTo(labels, num));
						break;
					default:
						throw new SymbolicAnalysisFailedException();
					}
				}
				else if (iLExpression != null && iLExpression.Code == ILCode.Ret)
				{
					if (iLExpression.Arguments.Count != 1 || iLExpression.Arguments[0].Code != ILCode.Ldc_I4)
					{
						throw new SymbolicAnalysisFailedException();
					}
					switch ((int)iLExpression.Arguments[0].Operand)
					{
					case 0:
						newBody.Add(new ILExpression(ILCode.YieldBreak, null));
						break;
					case 1:
						newBody.Add(MakeGoTo(labels, num));
						break;
					default:
						throw new SymbolicAnalysisFailedException();
					}
				}
				else if (iLExpression != null && iLExpression.Code == ILCode.Call && iLExpression.Arguments.Count == 1 && iLExpression.Arguments[0].MatchThis())
				{
					MethodDefinition methodDefinition = GetMethodDefinition(iLExpression.Operand as MethodReference);
					if (methodDefinition == null)
					{
						throw new SymbolicAnalysisFailedException();
					}
					StateRange stateRange;
					if (methodDefinition == disposeMethod)
					{
						ILExpression iLExpression3 = body.ElementAtOrDefault(++i) as ILExpression;
						if (iLExpression3 == null || (iLExpression3.Code != ILCode.Br && iLExpression3.Code != ILCode.Leave) || iLExpression3.Operand != returnFalseLabel)
						{
							throw new SymbolicAnalysisFailedException();
						}
						newBody.Add(new ILExpression(ILCode.YieldBreak, null));
					}
					else if (finallyMethodToStateRange.TryGetValue(methodDefinition, out stateRange))
					{
						int num2 = list.FindIndex((SetState ss) => stateRange.Contains(ss.NewState));
						if (num2 < 0)
						{
							throw new SymbolicAnalysisFailedException();
						}
						ILLabel iLLabel = new ILLabel();
						iLLabel.Name = "JumpOutOfTryFinally" + list[num2].NewState;
						newBody.Add(new ILExpression(ILCode.Leave, iLLabel));
						SetState setState = list[num2];
						list.RemoveRange(num2, list.Count - num2);
						ILTryCatchBlock iLTryCatchBlock = new ILTryCatchBlock();
						iLTryCatchBlock.TryBlock = new ILBlock(newBody.GetRange(setState.NewBodyPos, newBody.Count - setState.NewBodyPos));
						newBody.RemoveRange(setState.NewBodyPos, newBody.Count - setState.NewBodyPos);
						iLTryCatchBlock.CatchBlocks = new List<ILTryCatchBlock.CatchBlock>();
						iLTryCatchBlock.FinallyBlock = ConvertFinallyBlock(methodDefinition);
						newBody.Add(iLTryCatchBlock);
						newBody.Add(iLLabel);
					}
				}
				else
				{
					newBody.Add(body[i]);
				}
			}
			newBody.Add(new ILExpression(ILCode.YieldBreak, null));
		}

		private ILExpression MakeGoTo(ILLabel targetLabel)
		{
			if (targetLabel == returnFalseLabel)
			{
				return new ILExpression(ILCode.YieldBreak, null);
			}
			return new ILExpression(ILCode.Br, targetLabel);
		}

		private ILExpression MakeGoTo(List<KeyValuePair<ILLabel, StateRange>> labels, int state)
		{
			foreach (KeyValuePair<ILLabel, StateRange> label in labels)
			{
				if (label.Value.Contains(state))
				{
					return MakeGoTo(label.Key);
				}
			}
			throw new SymbolicAnalysisFailedException();
		}

		private ILBlock ConvertFinallyBlock(MethodDefinition finallyMethod)
		{
			ILBlock iLBlock = CreateILAst(finallyMethod);
			List<ILExpression> args;
			if (iLBlock.Body.Count > 0 && iLBlock.Body[0].Match(ILCode.Stfld, out FieldReference operand, out args) && GetFieldDefinition(operand) == stateField && args[0].MatchThis())
			{
				iLBlock.Body.RemoveAt(0);
			}
			foreach (ILExpression item in iLBlock.GetSelfAndChildrenRecursive<ILExpression>())
			{
				if (item.Code == ILCode.Ret)
				{
					item.Code = ILCode.Endfinally;
				}
			}
			return iLBlock;
		}

		private void TranslateFieldsToLocalAccess()
		{
			TranslateFieldsToLocalAccess(newBody, fieldToParameterMap);
		}

		internal static void TranslateFieldsToLocalAccess(List<ILNode> newBody, Dictionary<FieldDefinition, ILVariable> fieldToParameterMap)
		{
			DefaultDictionary<FieldDefinition, ILVariable> defaultDictionary = new DefaultDictionary<FieldDefinition, ILVariable>((FieldDefinition f) => new ILVariable
			{
				Name = f.Name,
				Type = f.FieldType
			});
			foreach (ILNode item in newBody)
			{
				foreach (ILExpression item2 in item.GetSelfAndChildrenRecursive<ILExpression>())
				{
					FieldDefinition fieldDefinition = GetFieldDefinition(item2.Operand as FieldReference);
					if (fieldDefinition != null)
					{
						switch (item2.Code)
						{
						case ILCode.Ldfld:
							if (item2.Arguments[0].MatchThis())
							{
								item2.Code = ILCode.Ldloc;
								if (fieldToParameterMap.ContainsKey(fieldDefinition))
								{
									item2.Operand = fieldToParameterMap[fieldDefinition];
								}
								else
								{
									item2.Operand = defaultDictionary[fieldDefinition];
								}
								item2.Arguments.Clear();
							}
							break;
						case ILCode.Stfld:
							if (item2.Arguments[0].MatchThis())
							{
								item2.Code = ILCode.Stloc;
								if (fieldToParameterMap.ContainsKey(fieldDefinition))
								{
									item2.Operand = fieldToParameterMap[fieldDefinition];
								}
								else
								{
									item2.Operand = defaultDictionary[fieldDefinition];
								}
								item2.Arguments.RemoveAt(0);
							}
							break;
						case ILCode.Ldflda:
							if (item2.Arguments[0].MatchThis())
							{
								item2.Code = ILCode.Ldloca;
								if (fieldToParameterMap.ContainsKey(fieldDefinition))
								{
									item2.Operand = fieldToParameterMap[fieldDefinition];
								}
								else
								{
									item2.Operand = defaultDictionary[fieldDefinition];
								}
								item2.Arguments.Clear();
							}
							break;
						}
					}
				}
			}
		}
	}
}

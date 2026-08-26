#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp;

internal class SequencePointBuilder : DepthFirstAstVisitor
{
	private struct StatePerSequencePoint
	{
		internal readonly AstNode PrimaryNode;

		internal readonly List<Interval> Intervals;

		internal ILFunction Function;

		public StatePerSequencePoint(AstNode primaryNode)
		{
			PrimaryNode = primaryNode;
			Intervals = new List<Interval>();
			Function = null;
		}
	}

	private readonly List<(ILFunction, SequencePoint)> sequencePoints = new List<(ILFunction, SequencePoint)>();

	private readonly HashSet<ILInstruction> mappedInstructions = new HashSet<ILInstruction>();

	private readonly Stack<StatePerSequencePoint> outerStates = new Stack<StatePerSequencePoint>();

	private StatePerSequencePoint current;

	private void VisitAsSequencePoint(AstNode node)
	{
		if (!node.IsNull)
		{
			StartSequencePoint(node);
			node.AcceptVisitor(this);
			EndSequencePoint(node.StartLocation, node.EndLocation);
		}
	}

	protected override void VisitChildren(AstNode node)
	{
		base.VisitChildren(node);
		AddToSequencePoint(node);
	}

	public override void VisitBlockStatement(BlockStatement blockStatement)
	{
		foreach (Statement statement in blockStatement.Statements)
		{
			VisitAsSequencePoint(statement);
		}
		ImplicitReturnAnnotation implicitReturnAnnotation = blockStatement.Annotation<ImplicitReturnAnnotation>();
		if (implicitReturnAnnotation != null)
		{
			StartSequencePoint(blockStatement.RBraceToken);
			AddToSequencePoint(implicitReturnAnnotation.Leave);
			EndSequencePoint(blockStatement.RBraceToken.StartLocation, blockStatement.RBraceToken.EndLocation);
		}
	}

	public override void VisitForStatement(ForStatement forStatement)
	{
		foreach (Statement initializer in forStatement.Initializers)
		{
			VisitAsSequencePoint(initializer);
		}
		VisitAsSequencePoint(forStatement.Condition);
		foreach (Statement iterator in forStatement.Iterators)
		{
			VisitAsSequencePoint(iterator);
		}
		VisitAsSequencePoint(forStatement.EmbeddedStatement);
	}

	public override void VisitSwitchStatement(SwitchStatement switchStatement)
	{
		StartSequencePoint(switchStatement);
		switchStatement.Expression.AcceptVisitor(this);
		foreach (DecompTools.Decompiler.CSharp.Syntax.SwitchSection switchSection in switchStatement.SwitchSections)
		{
			switchSection.AcceptVisitor(this);
		}
		AddToSequencePoint(switchStatement);
		EndSequencePoint(switchStatement.StartLocation, switchStatement.RParToken.EndLocation);
	}

	public override void VisitSwitchSection(DecompTools.Decompiler.CSharp.Syntax.SwitchSection switchSection)
	{
		foreach (Statement statement in switchSection.Statements)
		{
			VisitAsSequencePoint(statement);
		}
	}

	public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
	{
		AddToSequencePoint(lambdaExpression);
		VisitAsSequencePoint(lambdaExpression.Body);
	}

	public override void VisitUsingStatement(UsingStatement usingStatement)
	{
		StartSequencePoint(usingStatement);
		usingStatement.ResourceAcquisition.AcceptVisitor(this);
		VisitAsSequencePoint(usingStatement.EmbeddedStatement);
		AddToSequencePoint(usingStatement);
		EndSequencePoint(usingStatement.StartLocation, usingStatement.RParToken.EndLocation);
	}

	public override void VisitForeachStatement(ForeachStatement foreachStatement)
	{
		ForeachAnnotation foreachAnnotation = foreachStatement.Annotation<ForeachAnnotation>();
		if (foreachAnnotation == null)
		{
			base.VisitForeachStatement(foreachStatement);
			return;
		}
		StartSequencePoint(foreachStatement);
		foreachStatement.InExpression.AcceptVisitor(this);
		AddToSequencePoint(foreachAnnotation.GetEnumeratorCall);
		EndSequencePoint(foreachStatement.InExpression.StartLocation, foreachStatement.InExpression.EndLocation);
		StartSequencePoint(foreachStatement);
		AddToSequencePoint(foreachAnnotation.MoveNextCall);
		EndSequencePoint(foreachStatement.InToken.StartLocation, foreachStatement.InToken.EndLocation);
		StartSequencePoint(foreachStatement);
		AddToSequencePoint(foreachAnnotation.GetCurrentCall);
		EndSequencePoint(foreachStatement.VariableType.StartLocation, foreachStatement.VariableNameToken.EndLocation);
		VisitAsSequencePoint(foreachStatement.EmbeddedStatement);
	}

	public override void VisitLockStatement(LockStatement lockStatement)
	{
		StartSequencePoint(lockStatement);
		lockStatement.Expression.AcceptVisitor(this);
		VisitAsSequencePoint(lockStatement.EmbeddedStatement);
		AddToSequencePoint(lockStatement);
		EndSequencePoint(lockStatement.StartLocation, lockStatement.RParToken.EndLocation);
	}

	public override void VisitIfElseStatement(IfElseStatement ifElseStatement)
	{
		StartSequencePoint(ifElseStatement);
		ifElseStatement.Condition.AcceptVisitor(this);
		VisitAsSequencePoint(ifElseStatement.TrueStatement);
		VisitAsSequencePoint(ifElseStatement.FalseStatement);
		AddToSequencePoint(ifElseStatement);
		EndSequencePoint(ifElseStatement.StartLocation, ifElseStatement.RParToken.EndLocation);
	}

	public override void VisitWhileStatement(WhileStatement whileStatement)
	{
		StartSequencePoint(whileStatement);
		whileStatement.Condition.AcceptVisitor(this);
		VisitAsSequencePoint(whileStatement.EmbeddedStatement);
		AddToSequencePoint(whileStatement);
		EndSequencePoint(whileStatement.StartLocation, whileStatement.RParToken.EndLocation);
	}

	public override void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
	{
		StartSequencePoint(doWhileStatement);
		VisitAsSequencePoint(doWhileStatement.EmbeddedStatement);
		doWhileStatement.Condition.AcceptVisitor(this);
		AddToSequencePoint(doWhileStatement);
		EndSequencePoint(doWhileStatement.WhileToken.StartLocation, doWhileStatement.RParToken.EndLocation);
	}

	public override void VisitFixedStatement(FixedStatement fixedStatement)
	{
		foreach (VariableInitializer variable in fixedStatement.Variables)
		{
			VisitAsSequencePoint(variable);
		}
		VisitAsSequencePoint(fixedStatement.EmbeddedStatement);
	}

	private void StartSequencePoint(AstNode primaryNode)
	{
		outerStates.Push(current);
		current = new StatePerSequencePoint(primaryNode);
	}

	private void EndSequencePoint(TextLocation startLocation, TextLocation endLocation)
	{
		Debug.Assert(!startLocation.IsEmpty, "missing startLocation");
		Debug.Assert(!endLocation.IsEmpty, "missing endLocation");
		if (current.Intervals.Count > 0 && current.Function != null)
		{
			LongSet longSet = new LongSet(Enumerable.Select<Interval, LongInterval>((IEnumerable<Interval>)current.Intervals, (Func<Interval, LongInterval>)((Interval i) => new LongInterval(i.Start, i.End))));
			Debug.Assert(!longSet.IsEmpty);
			sequencePoints.Add((current.Function, checked(new SequencePoint
			{
				Offset = (int)longSet.Intervals[0].Start,
				EndOffset = (int)longSet.Intervals[0].End,
				StartLine = startLocation.Line,
				StartColumn = startLocation.Column,
				EndLine = endLocation.Line,
				EndColumn = endLocation.Column
			})));
		}
		current = outerStates.Pop();
	}

	private void AddToSequencePoint(AstNode node)
	{
		foreach (ILInstruction item in Enumerable.OfType<ILInstruction>((IEnumerable)node.Annotations))
		{
			AddToSequencePoint(item);
		}
	}

	private void AddToSequencePoint(ILInstruction inst)
	{
		if (!mappedInstructions.Add(inst))
		{
			return;
		}
		if (HasUsableILRange(inst) && current.Intervals != null)
		{
			current.Intervals.AddRange(inst.ILRanges);
			ILFunction iLFunction = Enumerable.FirstOrDefault<ILFunction>(Enumerable.OfType<ILFunction>((IEnumerable)inst.Parent.Ancestors));
			Debug.Assert(current.Function == null || current.Function == iLFunction);
			current.Function = iLFunction;
		}
		if (inst is ILFunction)
		{
			return;
		}
		foreach (ILInstruction child in inst.Children)
		{
			AddToSequencePoint(child);
		}
	}

	internal static bool HasUsableILRange(ILInstruction inst)
	{
		if (inst.HasILRange)
		{
			return false;
		}
		return !(inst is BlockContainer) && !(inst is Block);
	}

	internal Dictionary<ILFunction, List<SequencePoint>> GetSequencePoints()
	{
		Dictionary<ILFunction, List<SequencePoint>> dictionary = new Dictionary<ILFunction, List<SequencePoint>>();
		foreach (var (key, item) in sequencePoints)
		{
			if (!dictionary.TryGetValue(key, out var value))
			{
				dictionary.Add(key, value = new List<SequencePoint>());
			}
			value.Add(item);
		}
		checked
		{
			foreach (var (iLFunction2, list2) in Enumerable.ToList<KeyValuePair<ILFunction, List<SequencePoint>>>((IEnumerable<KeyValuePair<ILFunction, List<SequencePoint>>>)dictionary))
			{
				List<SequencePoint> list3 = new List<SequencePoint>();
				int num = 0;
				foreach (SequencePoint item5 in (IEnumerable<SequencePoint>)Enumerable.ThenBy<SequencePoint, int>(Enumerable.OrderBy<SequencePoint, int>((IEnumerable<SequencePoint>)list2, (Func<SequencePoint, int>)((SequencePoint sp) => sp.Offset)), (Func<SequencePoint, int>)((SequencePoint sp) => sp.EndOffset)))
				{
					if (item5.Offset < num)
					{
						while (list3.Count > 0 && list3.Last().EndOffset > num)
						{
							SequencePoint value2 = list3.Last();
							if (value2.Offset >= item5.Offset)
							{
								list3.RemoveAt(list3.Count - 1);
								continue;
							}
							value2.EndOffset = item5.Offset;
							list3[list3.Count - 1] = value2;
						}
					}
					else if (item5.Offset > num)
					{
						SequencePoint item3 = default(SequencePoint);
						item3.Offset = num;
						item3.EndOffset = item5.Offset;
						item3.SetHidden();
						list3.Add(item3);
					}
					list3.Add(item5);
					num = item5.EndOffset;
				}
				if (num < iLFunction2.CodeSize)
				{
					SequencePoint item4 = default(SequencePoint);
					item4.Offset = num;
					item4.EndOffset = iLFunction2.CodeSize;
					item4.SetHidden();
					list3.Add(item4);
				}
				dictionary[iLFunction2] = list3;
			}
			return dictionary;
		}
	}
}

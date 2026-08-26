#define DEBUG
#define STEP
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public sealed class ILFunction : ILInstruction
{
	public static readonly SlotInfo BodySlot = new SlotInfo("Body");

	private ILInstruction body;

	public readonly IMethod Method;

	public readonly GenericContext GenericContext;

	public int CodeSize;

	public readonly ILVariableCollection Variables;

	public bool IsIterator;

	public bool StateMachineCompiledWithMono;

	public IType AsyncReturnType;

	public IMethod MoveNextMethod;

	internal AsyncDebugInfo AsyncDebugInfo;

	public IType DelegateType;

	public readonly IType ReturnType;

	public readonly IReadOnlyList<IParameter> Parameters;

	private int helperVariableCount;

	public ILInstruction Body
	{
		get
		{
			return body;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref body, value, 0);
		}
	}

	public override StackType ResultType => StackType.O;

	public List<string> Warnings { get; } = new List<string>();

	public bool IsAsync => AsyncReturnType != null;

	public bool IsExpressionTree => DelegateType != null && DelegateType.FullName == "System.Linq.Expressions.Expression" && DelegateType.TypeParameterCount == 1;

	public override InstructionFlags DirectFlags => InstructionFlags.MayThrow | InstructionFlags.ControlFlow;

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return body;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Body = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return BodySlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		ILFunction iLFunction = (ILFunction)ShallowClone();
		iLFunction.Body = body.Clone();
		iLFunction.CloneVariables();
		return iLFunction;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitILFunction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitILFunction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitILFunction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is ILFunction iLFunction && body.PerformMatch(iLFunction.body, ref match);
	}

	public ILFunction(IMethod method, int codeSize, GenericContext genericContext, ILInstruction body)
		: base(OpCode.ILFunction)
	{
		Method = method;
		CodeSize = codeSize;
		GenericContext = genericContext;
		Body = body;
		ReturnType = Method?.ReturnType;
		Parameters = Method?.Parameters;
		Variables = new ILVariableCollection(this);
	}

	public ILFunction(IType returnType, IReadOnlyList<IParameter> parameters, GenericContext genericContext, ILInstruction body)
		: base(OpCode.ILFunction)
	{
		GenericContext = genericContext;
		Body = body;
		ReturnType = returnType;
		Parameters = parameters;
		Variables = new ILVariableCollection(this);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		for (int i = 0; i < Variables.Count; i = checked(i + 1))
		{
			Debug.Assert(Variables[i].Function == this);
			Debug.Assert(Variables[i].IndexInFunction == i);
			Variables[i].CheckInvariant();
		}
		base.CheckInvariant(phase);
	}

	private void CloneVariables()
	{
		throw new NotSupportedException("ILFunction.CloneVariables is currently not supported!");
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (Method != null)
		{
			output.Write(' ');
			Method.WriteTo(output);
		}
		if (IsExpressionTree)
		{
			output.Write(".ET");
		}
		if (DelegateType != null)
		{
			output.Write("[");
			DelegateType.WriteTo(output);
			output.Write("]");
		}
		output.WriteLine(" {");
		output.Indent();
		if (IsAsync)
		{
			output.WriteLine(".async");
		}
		if (IsIterator)
		{
			output.WriteLine(".iterator");
		}
		output.MarkFoldStart(Variables.Count + " variable(s)", defaultCollapsed: true);
		foreach (ILVariable variable in Variables)
		{
			variable.WriteDefinitionTo(output);
			output.WriteLine();
		}
		output.MarkFoldEnd();
		output.WriteLine();
		foreach (string warning in Warnings)
		{
			output.WriteLine("//" + warning);
		}
		body.WriteTo(output, options);
		output.WriteLine();
		if (options.ShowILRanges)
		{
			LongSet longSet = FindUnusedILRanges();
			if (!longSet.IsEmpty)
			{
				output.Write("// Unused IL Ranges: ");
				output.Write(string.Join(", ", longSet.Intervals.Select((LongInterval range) => $"[{range.Start:x4}..{range.InclusiveEnd:x4}]")));
				output.WriteLine();
			}
		}
		output.Unindent();
		output.WriteLine("}");
	}

	private LongSet FindUnusedILRanges()
	{
		List<LongInterval> usedILRanges = new List<LongInterval>();
		MarkUsedILRanges(body);
		return new LongSet(new LongInterval(0L, CodeSize)).ExceptWith(new LongSet(usedILRanges));
		void MarkUsedILRanges(ILInstruction inst)
		{
			if (SequencePointBuilder.HasUsableILRange(inst))
			{
				usedILRanges.Add(new LongInterval(inst.StartILOffset, inst.EndILOffset));
			}
			if (!(inst is ILFunction))
			{
				foreach (ILInstruction child in inst.Children)
				{
					MarkUsedILRanges(child);
				}
			}
		}
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.MayThrow | InstructionFlags.ControlFlow;
	}

	public void RunTransforms(IEnumerable<IILTransform> transforms, ILTransformContext context)
	{
		CheckInvariant(ILPhase.Normal);
		foreach (IILTransform transform in transforms)
		{
			context.CancellationToken.ThrowIfCancellationRequested();
			if (transform is BlockILTransform blockILTransform)
			{
				context.StepStartGroup(blockILTransform.ToString());
			}
			else
			{
				context.StepStartGroup(transform.GetType().Name);
			}
			transform.Run(this, context);
			CheckInvariant(ILPhase.Normal);
			context.StepEndGroup(keepIfEmpty: true);
		}
	}

	public ILVariable RegisterVariable(VariableKind kind, IType type, string name = null)
	{
		return RegisterVariable(kind, type, type.GetStackType(), name);
	}

	public ILVariable RegisterVariable(VariableKind kind, StackType stackType, string name = null)
	{
		IType type = Method.Compilation.FindType(stackType.ToKnownTypeCode());
		return RegisterVariable(kind, type, stackType, name);
	}

	private ILVariable RegisterVariable(VariableKind kind, IType type, StackType stackType, string name = null)
	{
		ILVariable iLVariable = new ILVariable(kind, type, stackType);
		if (string.IsNullOrWhiteSpace(name))
		{
			name = "I_" + checked(helperVariableCount++);
			iLVariable.HasGeneratedName = true;
		}
		iLVariable.Name = name;
		Variables.Add(iLVariable);
		return iLVariable;
	}

	internal void RecombineVariables(ILVariable variable1, ILVariable variable2)
	{
		Debug.Assert(ILVariableEqualityComparer.Instance.Equals(variable1, variable2));
		LdLoc[] array = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)variable2.LoadInstructions);
		foreach (LdLoc ldLoc in array)
		{
			ldLoc.Variable = variable1;
		}
		IStoreInstruction[] array2 = Enumerable.ToArray<IStoreInstruction>((IEnumerable<IStoreInstruction>)variable2.StoreInstructions);
		foreach (IStoreInstruction storeInstruction in array2)
		{
			storeInstruction.Variable = variable1;
		}
		LdLoca[] array3 = Enumerable.ToArray<LdLoca>((IEnumerable<LdLoca>)variable2.AddressInstructions);
		foreach (LdLoca ldLoca in array3)
		{
			ldLoca.Variable = variable1;
		}
		bool condition = Variables.Remove(variable2);
		Debug.Assert(condition);
	}
}

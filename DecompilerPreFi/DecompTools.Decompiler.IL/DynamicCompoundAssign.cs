using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class DynamicCompoundAssign : CompoundAssignmentInstruction
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ExpressionType _003COperation_003Ek__BackingField;

	public override StackType ResultType => StackType.O;

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;

	public ExpressionType Operation
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003COperation_003Ek__BackingField;
		}
	}

	public CSharpArgumentInfo TargetArgumentInfo { get; }

	public CSharpArgumentInfo ValueArgumentInfo { get; }

	public CSharpBinderFlags BinderFlags { get; }

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.SideEffect;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDynamicCompoundAssign(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDynamicCompoundAssign(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDynamicCompoundAssign(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is DynamicCompoundAssign dynamicCompoundAssign && CompoundAssignmentType == dynamicCompoundAssign.CompoundAssignmentType && base.Target.PerformMatch(dynamicCompoundAssign.Target, ref match) && base.Value.PerformMatch(dynamicCompoundAssign.Value, ref match);
	}

	public DynamicCompoundAssign(ExpressionType op, CSharpBinderFlags binderFlags, ILInstruction target, CSharpArgumentInfo targetArgumentInfo, ILInstruction value, CSharpArgumentInfo valueArgumentInfo)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector(OpCode.DynamicCompoundAssign, CompoundAssignmentTypeFromOperation(op), target, value);
		if (!IsExpressionTypeSupported(op))
		{
			throw new ArgumentOutOfRangeException("op");
		}
		BinderFlags = binderFlags;
		Operation = op;
		TargetArgumentInfo = targetArgumentInfo;
		ValueArgumentInfo = valueArgumentInfo;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write("." + ((object)Operation/*cast due to constrained. prefix*/).ToString().ToLower());
		DynamicInstruction.WriteBinderFlags(BinderFlags, output, options);
		if (CompoundAssignmentType == CompoundAssignmentType.EvaluatesToNewValue)
		{
			output.Write(".new");
		}
		else
		{
			output.Write(".old");
		}
		output.Write(' ');
		DynamicInstruction.WriteArgumentList(output, options, (base.Target, TargetArgumentInfo), (base.Value, ValueArgumentInfo));
	}

	internal static bool IsExpressionTypeSupported(ExpressionType type)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Invalid comparison between Unknown and I4
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Invalid comparison between Unknown and I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		return (int)type == 63 || (int)type == 74 || (int)type == 64 || (int)type == 65 || (int)type == 66 || (int)type == 67 || (int)type == 68 || (int)type == 69 || (int)type == 75 || (int)type == 70 || (int)type == 80 || (int)type == 79 || (int)type == 78 || (int)type == 77 || (int)type == 72 || (int)type == 73 || (int)type == 76;
	}

	private static CompoundAssignmentType CompoundAssignmentTypeFromOperation(ExpressionType op)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if (op - 79 <= 1)
		{
			return CompoundAssignmentType.EvaluatesToOldValue;
		}
		return CompoundAssignmentType.EvaluatesToNewValue;
	}
}

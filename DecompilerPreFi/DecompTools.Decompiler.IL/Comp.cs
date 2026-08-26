#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class Comp : BinaryInstruction, ILiftableInstruction
{
	private ComparisonKind kind;

	public readonly ComparisonLiftingKind LiftingKind;

	public StackType InputType;

	public readonly Sign Sign;

	public ComparisonKind Kind
	{
		get
		{
			return kind;
		}
		set
		{
			kind = value;
			MakeDirty();
		}
	}

	public override StackType ResultType => (LiftingKind != ComparisonLiftingKind.ThreeValuedLogic) ? StackType.I4 : StackType.O;

	public bool IsLifted => LiftingKind != ComparisonLiftingKind.None;

	public StackType UnderlyingResultType => StackType.I4;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitComp(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitComp(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitComp(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Comp comp && base.Left.PerformMatch(comp.Left, ref match) && base.Right.PerformMatch(comp.Right, ref match) && Kind == comp.Kind && Sign == comp.Sign && LiftingKind == comp.LiftingKind;
	}

	public Comp(ComparisonKind kind, Sign sign, ILInstruction left, ILInstruction right)
		: base(OpCode.Comp, left, right)
	{
		this.kind = kind;
		LiftingKind = ComparisonLiftingKind.None;
		InputType = left.ResultType;
		Sign = sign;
		Debug.Assert(left.ResultType == right.ResultType);
	}

	public Comp(ComparisonKind kind, ComparisonLiftingKind lifting, StackType inputType, Sign sign, ILInstruction left, ILInstruction right)
		: base(OpCode.Comp, left, right)
	{
		this.kind = kind;
		LiftingKind = lifting;
		InputType = inputType;
		Sign = sign;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		if (LiftingKind == ComparisonLiftingKind.None)
		{
			Debug.Assert(base.Left.ResultType == InputType);
			Debug.Assert(base.Right.ResultType == InputType);
		}
		else
		{
			Debug.Assert(base.Left.ResultType == InputType || base.Left.ResultType == StackType.O);
			Debug.Assert(base.Right.ResultType == InputType || base.Right.ResultType == StackType.O);
		}
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		if (options.UseLogicOperationSugar && MatchLogicNot(out var arg))
		{
			output.Write("logic.not(");
			arg.WriteTo(output, options);
			output.Write(')');
			return;
		}
		output.Write(OpCode);
		output.Write('.');
		output.Write(InputType.ToString().ToLower());
		switch (Sign)
		{
		case Sign.Signed:
			output.Write(".signed");
			break;
		case Sign.Unsigned:
			output.Write(".unsigned");
			break;
		}
		switch (LiftingKind)
		{
		case ComparisonLiftingKind.CSharp:
			output.Write(".lifted[C#]");
			break;
		case ComparisonLiftingKind.ThreeValuedLogic:
			output.Write(".lifted[3VL]");
			break;
		}
		output.Write('(');
		base.Left.WriteTo(output, options);
		output.Write(' ');
		output.Write(Kind.GetToken());
		output.Write(' ');
		base.Right.WriteTo(output, options);
		output.Write(')');
	}

	public static Comp LogicNot(ILInstruction arg)
	{
		return new Comp(ComparisonKind.Equality, Sign.None, arg, new LdcI4(0));
	}
}

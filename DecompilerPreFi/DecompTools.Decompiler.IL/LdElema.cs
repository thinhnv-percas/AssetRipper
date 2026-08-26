using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class LdElema : ILInstruction
{
	private IType type;

	public static readonly SlotInfo ArraySlot = new SlotInfo("Array", canInlineInto: true);

	private ILInstruction array;

	public static readonly SlotInfo IndicesSlot = new SlotInfo("Indices", canInlineInto: true);

	public bool DelayExceptions;

	public IType Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
			InvalidateFlags();
		}
	}

	public ILInstruction Array
	{
		get
		{
			return array;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref array, value, 0);
		}
	}

	public InstructionCollection<ILInstruction> Indices { get; private set; }

	public override StackType ResultType => StackType.Ref;

	public bool IsReadOnly { get; set; }

	public override InstructionFlags DirectFlags => (!DelayExceptions) ? InstructionFlags.MayThrow : InstructionFlags.None;

	public LdElema(IType type, ILInstruction array, params ILInstruction[] indices)
		: base(OpCode.LdElema)
	{
		this.type = type;
		Array = array;
		Indices = new InstructionCollection<ILInstruction>(this, 1);
		Indices.AddRange(indices);
	}

	protected sealed override int GetChildCount()
	{
		return checked(1 + Indices.Count);
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return array;
		}
		return Indices[checked(index - 1)];
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Array = value;
		}
		else
		{
			Indices[checked(index - 1)] = value;
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ArraySlot;
		}
		return IndicesSlot;
	}

	public sealed override ILInstruction Clone()
	{
		LdElema ldElema = (LdElema)ShallowClone();
		ldElema.Array = array.Clone();
		ldElema.Indices = new InstructionCollection<ILInstruction>(ldElema, 1);
		ldElema.Indices.AddRange(Enumerable.Select<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)Indices, (Func<ILInstruction, ILInstruction>)((ILInstruction arg) => arg.Clone())));
		return ldElema;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return (InstructionFlags)((int)(array.Flags | Enumerable.Aggregate<ILInstruction, InstructionFlags>((IEnumerable<ILInstruction>)Indices, InstructionFlags.None, (Func<InstructionFlags, ILInstruction, InstructionFlags>)((InstructionFlags f, ILInstruction arg) => f | arg.Flags))) | ((!DelayExceptions) ? 256 : 0));
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		if (DelayExceptions)
		{
			output.Write("delayex.");
		}
		if (IsReadOnly)
		{
			output.Write("readonly.");
		}
		output.Write(OpCode);
		output.Write(' ');
		type.WriteTo(output);
		output.Write('(');
		array.WriteTo(output, options);
		foreach (ILInstruction index in Indices)
		{
			output.Write(", ");
			index.WriteTo(output, options);
		}
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdElema(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdElema(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdElema(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LdElema ldElema && type.Equals(ldElema.type) && array.PerformMatch(ldElema.array, ref match) && ListMatch.DoMatch(Indices, ldElema.Indices, ref match) && DelayExceptions == ldElema.DelayExceptions && IsReadOnly == ldElema.IsReadOnly;
	}
}

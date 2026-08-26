using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class NewArr : ILInstruction
{
	private IType type;

	public static readonly SlotInfo IndicesSlot = new SlotInfo("Indices", canInlineInto: true);

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

	public InstructionCollection<ILInstruction> Indices { get; private set; }

	public override StackType ResultType => StackType.O;

	public override InstructionFlags DirectFlags => InstructionFlags.MayThrow;

	public NewArr(IType type, params ILInstruction[] indices)
		: base(OpCode.NewArr)
	{
		this.type = type;
		Indices = new InstructionCollection<ILInstruction>(this, 0);
		Indices.AddRange(indices);
	}

	protected sealed override int GetChildCount()
	{
		return Indices.Count;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return Indices[index];
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		Indices[index] = value;
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return IndicesSlot;
	}

	public sealed override ILInstruction Clone()
	{
		NewArr newArr = (NewArr)ShallowClone();
		newArr.Indices = new InstructionCollection<ILInstruction>(newArr, 0);
		newArr.Indices.AddRange(Enumerable.Select<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)Indices, (Func<ILInstruction, ILInstruction>)((ILInstruction arg) => arg.Clone())));
		return newArr;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return Enumerable.Aggregate<ILInstruction, InstructionFlags>((IEnumerable<ILInstruction>)Indices, InstructionFlags.None, (Func<InstructionFlags, ILInstruction, InstructionFlags>)((InstructionFlags f, ILInstruction arg) => f | arg.Flags)) | InstructionFlags.MayThrow;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		type.WriteTo(output);
		output.Write('(');
		bool flag = true;
		foreach (ILInstruction index in Indices)
		{
			if (!flag)
			{
				output.Write(", ");
			}
			else
			{
				flag = false;
			}
			index.WriteTo(output, options);
		}
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitNewArr(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitNewArr(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitNewArr(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is NewArr newArr && type.Equals(newArr.type) && ListMatch.DoMatch(Indices, newArr.Indices, ref match);
	}
}

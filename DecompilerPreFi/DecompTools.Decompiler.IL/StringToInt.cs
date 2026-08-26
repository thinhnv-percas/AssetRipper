#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class StringToInt : ILInstruction
{
	public static readonly SlotInfo ArgumentSlot = new SlotInfo("Argument", canInlineInto: true);

	private ILInstruction argument;

	public List<(string Key, int Value)> Map { get; }

	public ILInstruction Argument
	{
		get
		{
			return argument;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref argument, value, 0);
		}
	}

	public override StackType ResultType => StackType.I4;

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	public StringToInt(ILInstruction argument, List<(string Key, int Value)> map)
		: base(OpCode.StringToInt)
	{
		Argument = argument;
		Map = map;
	}

	public StringToInt(ILInstruction argument, string[] map)
		: this(argument, ArrayToDictionary(map))
	{
	}

	private static List<(string Key, int Value)> ArrayToDictionary(string[] map)
	{
		List<(string, int)> list = new List<(string, int)>();
		for (int i = 0; i < map.Length; i = checked(i + 1))
		{
			list.Add((map[i], i));
		}
		return list;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write("string.to.int (");
		Argument.WriteTo(output, options);
		output.Write(", { ");
		int num = 0;
		foreach (var item in Map)
		{
			if (num > 0)
			{
				output.Write(", ");
			}
			output.Write($"[\"{item.Key}\"] = {item.Value}");
			num = checked(num + 1);
		}
		output.Write(" })");
	}

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return argument;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Argument = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ArgumentSlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		StringToInt stringToInt = (StringToInt)ShallowClone();
		stringToInt.Argument = argument.Clone();
		return stringToInt;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return argument.Flags;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitStringToInt(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitStringToInt(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitStringToInt(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is StringToInt stringToInt && argument.PerformMatch(stringToInt.argument, ref match);
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(argument.ResultType == StackType.O);
	}
}

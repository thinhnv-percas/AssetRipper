#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

[DebuggerDisplay("{Name} : {Type}")]
public class ILVariable
{
	private VariableKind kind;

	public readonly StackType StackType;

	private IType type;

	public readonly int? Index;

	private readonly List<LdLoc> loadInstructions = new List<LdLoc>();

	private readonly List<IStoreInstruction> storeInstructions = new List<IStoreInstruction>();

	private readonly List<LdLoca> addressInstructions = new List<LdLoca>();

	private bool hasInitialValue;

	public IField StateMachineField;

	public VariableKind Kind
	{
		get
		{
			return kind;
		}
		internal set
		{
			if (kind == VariableKind.Parameter)
			{
				throw new InvalidOperationException("Kind=Parameter cannot be changed!");
			}
			if (Index.HasValue && value.IsLocal())
			{
				Debug.Assert(kind.IsLocal());
			}
			kind = value;
		}
	}

	public IType Type
	{
		get
		{
			return type;
		}
		internal set
		{
			if (value.GetStackType() != StackType)
			{
				throw new ArgumentException($"Expected stack-type: {StackType} may not be changed. Found: {value.GetStackType()}");
			}
			type = value;
		}
	}

	public string Name { get; set; }

	public bool HasGeneratedName { get; set; }

	public ILFunction Function { get; internal set; }

	public BlockContainer CaptureScope { get; internal set; }

	public int IndexInFunction { get; internal set; }

	public int LoadCount => LoadInstructions.Count;

	public IReadOnlyList<LdLoc> LoadInstructions => loadInstructions;

	public int StoreCount => checked((hasInitialValue ? 1 : 0) + StoreInstructions.Count);

	public IReadOnlyList<IStoreInstruction> StoreInstructions => storeInstructions;

	public int AddressCount => AddressInstructions.Count;

	public IReadOnlyList<LdLoca> AddressInstructions => addressInstructions;

	public bool HasInitialValue
	{
		get
		{
			return hasInitialValue;
		}
		set
		{
			if (Kind == VariableKind.Parameter && !value)
			{
				throw new InvalidOperationException("Cannot remove HasInitialValue from parameters");
			}
			hasInitialValue = value;
		}
	}

	public bool IsSingleDefinition => StoreCount == 1 && AddressCount == 0;

	[Conditional("DEBUG")]
	internal void CheckInvariant()
	{
		switch (kind)
		{
		case VariableKind.Local:
		case VariableKind.PinnedLocal:
		case VariableKind.UsingLocal:
		case VariableKind.ForeachLocal:
		case VariableKind.ExceptionLocal:
		case VariableKind.DisplayClassLocal:
			Debug.Assert(!Index.HasValue || Index >= 0);
			break;
		case VariableKind.Parameter:
			Debug.Assert(Index >= -1);
			Debug.Assert(Function == null || Index < Function.Parameters.Count);
			break;
		case VariableKind.ExceptionStackSlot:
			Debug.Assert(Index >= 0);
			break;
		case VariableKind.InitializerTarget:
		case VariableKind.StackSlot:
		case VariableKind.NamedArgument:
			break;
		}
	}

	internal void AddLoadInstruction(LdLoc inst)
	{
		inst.IndexInLoadInstructionList = AddInstruction(loadInstructions, inst);
	}

	internal void AddStoreInstruction(IStoreInstruction inst)
	{
		inst.IndexInStoreInstructionList = AddInstruction(storeInstructions, inst);
	}

	internal void AddAddressInstruction(LdLoca inst)
	{
		inst.IndexInAddressInstructionList = AddInstruction(addressInstructions, inst);
	}

	internal void RemoveLoadInstruction(LdLoc inst)
	{
		RemoveInstruction(loadInstructions, inst.IndexInLoadInstructionList, inst);
	}

	internal void RemoveStoreInstruction(IStoreInstruction inst)
	{
		RemoveInstruction(storeInstructions, inst.IndexInStoreInstructionList, inst);
	}

	internal void RemoveAddressInstruction(LdLoca inst)
	{
		RemoveInstruction(addressInstructions, inst.IndexInAddressInstructionList, inst);
	}

	private int AddInstruction<T>(List<T> list, T inst) where T : class, IInstructionWithVariableOperand
	{
		list.Add(inst);
		return checked(list.Count - 1);
	}

	private void RemoveInstruction<T>(List<T> list, int index, T inst) where T : class, IInstructionWithVariableOperand
	{
		Debug.Assert(list[index] == inst);
		int index2 = checked(list.Count - 1);
		list[index] = list[index2];
		list[index].IndexInVariableInstructionMapping = index;
		list.RemoveAt(index2);
	}

	public ILVariable(VariableKind kind, IType type, int? index = null)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		Kind = kind;
		this.type = type;
		StackType = type.GetStackType();
		Index = index;
		if (kind == VariableKind.Parameter)
		{
			HasInitialValue = true;
		}
		CheckInvariant();
	}

	public ILVariable(VariableKind kind, IType type, StackType stackType, int? index = null)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		Kind = kind;
		this.type = type;
		StackType = stackType;
		Index = index;
		if (kind == VariableKind.Parameter)
		{
			HasInitialValue = true;
		}
		CheckInvariant();
	}

	public override string ToString()
	{
		return Name;
	}

	internal void WriteDefinitionTo(ITextOutput output)
	{
		switch (Kind)
		{
		case VariableKind.Local:
			output.Write("local ");
			break;
		case VariableKind.PinnedLocal:
			output.Write("pinned local ");
			break;
		case VariableKind.Parameter:
			output.Write("param ");
			break;
		case VariableKind.ExceptionLocal:
			output.Write("exception local ");
			break;
		case VariableKind.ExceptionStackSlot:
			output.Write("exception stack ");
			break;
		case VariableKind.StackSlot:
			output.Write("stack ");
			break;
		case VariableKind.InitializerTarget:
			output.Write("initializer ");
			break;
		case VariableKind.ForeachLocal:
			output.Write("foreach ");
			break;
		case VariableKind.UsingLocal:
			output.Write("using ");
			break;
		case VariableKind.NamedArgument:
			output.Write("named_arg ");
			break;
		case VariableKind.DisplayClassLocal:
			output.Write("display_class local ");
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		output.WriteLocalReference(Name, this, isDefinition: true);
		output.Write(" : ");
		Type.WriteTo(output);
		output.Write('(');
		if (Kind == VariableKind.Parameter || Kind == VariableKind.Local || Kind == VariableKind.PinnedLocal)
		{
			output.Write("Index={0}, ", Index);
		}
		output.Write("LoadCount={0}, AddressCount={1}, StoreCount={2})", LoadCount, AddressCount, StoreCount);
		if (hasInitialValue && Kind != VariableKind.Parameter)
		{
			output.Write(" init");
		}
		if (CaptureScope != null)
		{
			output.Write(" captured in " + CaptureScope.EntryPoint.Label);
		}
		if (StateMachineField != null)
		{
			output.Write(" from state-machine");
		}
	}

	internal void WriteTo(ITextOutput output)
	{
		output.WriteLocalReference(Name, this);
	}

	internal bool IsUsedWithin(ILInstruction inst)
	{
		if (inst is IInstructionWithVariableOperand instructionWithVariableOperand && instructionWithVariableOperand.Variable == this)
		{
			return true;
		}
		foreach (ILInstruction child in inst.Children)
		{
			if (IsUsedWithin(child))
			{
				return true;
			}
		}
		return false;
	}
}

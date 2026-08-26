#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.Disassembler;

public class ILStructure
{
	private struct Branch
	{
		public Interval Source;

		public int Target;

		public Branch(int start, int end, int target)
		{
			Source = new Interval(start, end);
			Target = target;
		}

		public override string ToString()
		{
			return $"[Branch Source={Source}, Target={Target}]";
		}
	}

	public readonly PEFile Module;

	public readonly MethodDefinitionHandle MethodHandle;

	public readonly GenericContext GenericContext;

	public readonly ILStructureType Type;

	public readonly int StartOffset;

	public readonly int EndOffset;

	public readonly ExceptionRegion ExceptionHandler;

	public readonly int LoopEntryPointOffset;

	public readonly List<ILStructure> Children = new List<ILStructure>();

	public ILStructure(PEFile module, MethodDefinitionHandle handle, GenericContext genericContext, MethodBodyBlock body)
		: this(module, handle, genericContext, ILStructureType.Root, 0, body.GetILReader().Length)
	{
		checked
		{
			for (int i = 0; i < body.ExceptionRegions.Length; i++)
			{
				ExceptionRegion eh = body.ExceptionRegions[i];
				if (!Enumerable.Any<ExceptionRegion>(Enumerable.Take<ExceptionRegion>((IEnumerable<ExceptionRegion>)body.ExceptionRegions, i), (Func<ExceptionRegion, bool>)((ExceptionRegion oldEh) => oldEh.TryOffset == eh.TryOffset && oldEh.TryLength == eh.TryLength)))
				{
					AddNestedStructure(new ILStructure(module, handle, genericContext, ILStructureType.Try, eh.TryOffset, eh.TryOffset + eh.TryLength, eh));
				}
				if (eh.Kind == ExceptionRegionKind.Filter)
				{
					AddNestedStructure(new ILStructure(module, handle, genericContext, ILStructureType.Filter, eh.FilterOffset, eh.HandlerOffset, eh));
				}
				AddNestedStructure(new ILStructure(module, handle, genericContext, ILStructureType.Handler, eh.HandlerOffset, eh.HandlerOffset + eh.HandlerLength, eh));
			}
			(List<Branch> Branches, BitSet IsAfterUnconditionalBranch) tuple = FindAllBranches(body.GetILReader());
			List<Branch> item = tuple.Branches;
			BitSet item2 = tuple.IsAfterUnconditionalBranch;
			for (int num = item.Count - 1; num >= 0; num--)
			{
				int end = item[num].Source.End;
				int target = item[num].Target;
				if (target < end)
				{
					int num2 = -1;
					if (target > 0 && !item2[target])
					{
						num2 = item[num].Target;
					}
					bool flag = false;
					foreach (Branch item3 in item)
					{
						if ((item3.Source.Start < target || item3.Source.Start >= end) && target <= item3.Target && item3.Target < end)
						{
							if (num2 < 0)
							{
								num2 = item3.Target;
							}
							else if (item3.Target != num2)
							{
								flag = true;
							}
						}
					}
					if (!flag)
					{
						AddNestedStructure(new ILStructure(module, handle, genericContext, ILStructureType.Loop, target, end, num2));
					}
				}
			}
			SortChildren();
		}
	}

	public ILStructure(PEFile module, MethodDefinitionHandle handle, GenericContext genericContext, ILStructureType type, int startOffset, int endOffset, ExceptionRegion handler = default(ExceptionRegion))
	{
		Debug.Assert(startOffset < endOffset);
		Module = module;
		MethodHandle = handle;
		GenericContext = genericContext;
		Type = type;
		StartOffset = startOffset;
		EndOffset = endOffset;
		ExceptionHandler = handler;
	}

	public ILStructure(PEFile module, MethodDefinitionHandle handle, GenericContext genericContext, ILStructureType type, int startOffset, int endOffset, int loopEntryPoint)
	{
		Debug.Assert(startOffset < endOffset);
		Module = module;
		MethodHandle = handle;
		GenericContext = genericContext;
		Type = type;
		StartOffset = startOffset;
		EndOffset = endOffset;
		LoopEntryPointOffset = loopEntryPoint;
	}

	private bool AddNestedStructure(ILStructure newStructure)
	{
		if (Type == ILStructureType.Loop && newStructure.Type == ILStructureType.Loop && newStructure.StartOffset == StartOffset)
		{
			return false;
		}
		Debug.Assert(StartOffset <= newStructure.StartOffset && newStructure.EndOffset <= EndOffset);
		foreach (ILStructure child in Children)
		{
			if (child.StartOffset <= newStructure.StartOffset && newStructure.EndOffset <= child.EndOffset)
			{
				return child.AddNestedStructure(newStructure);
			}
			if (child.EndOffset > newStructure.StartOffset && newStructure.EndOffset > child.StartOffset && (newStructure.StartOffset > child.StartOffset || child.EndOffset > newStructure.EndOffset))
			{
				return false;
			}
		}
		checked
		{
			for (int i = 0; i < Children.Count; i++)
			{
				ILStructure iLStructure = Children[i];
				if (newStructure.StartOffset <= iLStructure.StartOffset && iLStructure.EndOffset <= newStructure.EndOffset)
				{
					Children.RemoveAt(i--);
					newStructure.Children.Add(iLStructure);
				}
			}
			Children.Add(newStructure);
			return true;
		}
	}

	private (List<Branch> Branches, BitSet IsAfterUnconditionalBranch) FindAllBranches(BlobReader body)
	{
		List<Branch> list = new List<Branch>();
		BitSet bitSet = new BitSet(checked(body.Length + 1));
		body.Reset();
		while (body.RemainingBytes > 0)
		{
			int offset = body.Offset;
			ILOpCode opCode = body.DecodeOpCode();
			switch (opCode.GetOperandType())
			{
			case OperandType.BrTarget:
			case OperandType.ShortBrTarget:
			{
				int target2 = body.DecodeBranchTarget(opCode);
				int offset2 = body.Offset;
				list.Add(new Branch(offset, offset2, target2));
				bitSet[offset2] = IsUnconditionalBranch(opCode);
				break;
			}
			case OperandType.Switch:
			{
				int[] array = body.DecodeSwitchTargets();
				int[] array2 = array;
				foreach (int target in array2)
				{
					list.Add(new Branch(offset, body.Offset, target));
				}
				break;
			}
			default:
				body.SkipOperand(opCode);
				bitSet[body.Offset] = IsUnconditionalBranch(opCode);
				break;
			}
		}
		return (Branches: list, IsAfterUnconditionalBranch: bitSet);
	}

	private static bool IsUnconditionalBranch(ILOpCode opCode)
	{
		switch (opCode)
		{
		case ILOpCode.Ret:
		case ILOpCode.Br_s:
		case ILOpCode.Br:
		case ILOpCode.Throw:
		case ILOpCode.Endfinally:
		case ILOpCode.Leave:
		case ILOpCode.Leave_s:
		case ILOpCode.Endfilter:
		case ILOpCode.Rethrow:
			return true;
		default:
			return false;
		}
	}

	private void SortChildren()
	{
		Children.Sort(delegate(ILStructure a, ILStructure b)
		{
			int startOffset = a.StartOffset;
			return startOffset.CompareTo(b.StartOffset);
		});
		foreach (ILStructure child in Children)
		{
			child.SortChildren();
		}
	}

	public ILStructure GetInnermost(int offset)
	{
		Debug.Assert(StartOffset <= offset && offset < EndOffset);
		foreach (ILStructure child in Children)
		{
			if (child.StartOffset <= offset && offset < child.EndOffset)
			{
				return child.GetInnermost(offset);
			}
		}
		return this;
	}
}

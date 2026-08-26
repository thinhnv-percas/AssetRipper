using ICSharpCode.Decompiler.FlowAnalysis;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.Disassembler
{
	public class ILStructure
	{
		public readonly ILStructureType Type;

		public readonly int StartOffset;

		public readonly int EndOffset;

		public readonly ExceptionHandler ExceptionHandler;

		public readonly Instruction LoopEntryPoint;

		public readonly List<ILStructure> Children = new List<ILStructure>();

		public ILStructure(MethodBody body)
			: this(ILStructureType.Root, 0, body.CodeSize)
		{
			for (int i = 0; i < body.ExceptionHandlers.Count; i++)
			{
				ExceptionHandler eh = body.ExceptionHandlers[i];
				if (!body.ExceptionHandlers.Take(i).Any((ExceptionHandler oldEh) => oldEh.TryStart == eh.TryStart && oldEh.TryEnd == eh.TryEnd))
				{
					AddNestedStructure(new ILStructure(ILStructureType.Try, eh.TryStart.Offset, eh.TryEnd.Offset, eh));
				}
				if (eh.HandlerType == ExceptionHandlerType.Filter)
				{
					AddNestedStructure(new ILStructure(ILStructureType.Filter, eh.FilterStart.Offset, eh.HandlerStart.Offset, eh));
				}
				AddNestedStructure(new ILStructure(ILStructureType.Handler, eh.HandlerStart.Offset, (eh.HandlerEnd == null) ? body.CodeSize : eh.HandlerEnd.Offset, eh));
			}
			List<KeyValuePair<Instruction, Instruction>> list = FindAllBranches(body);
			for (int num = list.Count - 1; num >= 0; num--)
			{
				int endOffset = list[num].Key.GetEndOffset();
				int offset = list[num].Value.Offset;
				if (offset < endOffset)
				{
					Instruction instruction = null;
					Instruction previous = list[num].Value.Previous;
					if (previous != null && !OpCodeInfo.IsUnconditionalBranch(previous.OpCode))
					{
						instruction = list[num].Value;
					}
					bool flag = false;
					foreach (KeyValuePair<Instruction, Instruction> item in list)
					{
						if ((item.Key.Offset < offset || item.Key.Offset >= endOffset) && offset <= item.Value.Offset && item.Value.Offset < endOffset)
						{
							if (instruction == null)
							{
								instruction = item.Value;
							}
							else if (item.Value != instruction)
							{
								flag = true;
							}
						}
					}
					if (!flag)
					{
						AddNestedStructure(new ILStructure(ILStructureType.Loop, offset, endOffset, instruction));
					}
				}
			}
			SortChildren();
		}

		public ILStructure(ILStructureType type, int startOffset, int endOffset, ExceptionHandler handler = null)
		{
			Type = type;
			StartOffset = startOffset;
			EndOffset = endOffset;
			ExceptionHandler = handler;
		}

		public ILStructure(ILStructureType type, int startOffset, int endOffset, Instruction loopEntryPoint)
		{
			Type = type;
			StartOffset = startOffset;
			EndOffset = endOffset;
			LoopEntryPoint = loopEntryPoint;
		}

		private bool AddNestedStructure(ILStructure newStructure)
		{
			if (Type == ILStructureType.Loop && newStructure.Type == ILStructureType.Loop && newStructure.StartOffset == StartOffset)
			{
				return false;
			}
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

		private List<KeyValuePair<Instruction, Instruction>> FindAllBranches(MethodBody body)
		{
			List<KeyValuePair<Instruction, Instruction>> list = new List<KeyValuePair<Instruction, Instruction>>();
			foreach (Instruction instruction in body.Instructions)
			{
				switch (instruction.OpCode.OperandType)
				{
				case OperandType.InlineBrTarget:
				case OperandType.ShortInlineBrTarget:
					list.Add(new KeyValuePair<Instruction, Instruction>(instruction, (Instruction)instruction.Operand));
					break;
				case OperandType.InlineSwitch:
				{
					Instruction[] array = (Instruction[])instruction.Operand;
					foreach (Instruction value in array)
					{
						list.Add(new KeyValuePair<Instruction, Instruction>(instruction, value));
					}
					break;
				}
				}
			}
			return list;
		}

		private void SortChildren()
		{
			Children.Sort((ILStructure a, ILStructure b) => a.StartOffset.CompareTo(b.StartOffset));
			foreach (ILStructure child in Children)
			{
				child.SortChildren();
			}
		}

		public ILStructure GetInnermost(int offset)
		{
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
}

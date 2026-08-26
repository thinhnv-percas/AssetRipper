#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

internal class BlockBuilder
{
	private readonly MethodBodyBlock body;

	private readonly Dictionary<ExceptionRegion, ILVariable> variableByExceptionHandler;

	public bool CreateExtendedBlocks;

	private List<TryInstruction> tryInstructionList = new List<TryInstruction>();

	private Dictionary<int, BlockContainer> handlerContainers = new Dictionary<int, BlockContainer>();

	private int currentTryIndex;

	private TryInstruction nextTry;

	private BlockContainer currentContainer;

	private Block currentBlock;

	private Stack<BlockContainer> containerStack = new Stack<BlockContainer>();

	internal BlockBuilder(MethodBodyBlock body, Dictionary<ExceptionRegion, ILVariable> variableByExceptionHandler)
	{
		Debug.Assert(body != null);
		Debug.Assert(variableByExceptionHandler != null);
		this.body = body;
		this.variableByExceptionHandler = variableByExceptionHandler;
	}

	private void CreateContainerStructure()
	{
		List<TryCatch> list = new List<TryCatch>();
		checked
		{
			foreach (ExceptionRegion exceptionRegion in body.ExceptionRegions)
			{
				Interval tryRange = new Interval(exceptionRegion.TryOffset, exceptionRegion.TryOffset + exceptionRegion.TryLength);
				BlockContainer blockContainer = new BlockContainer();
				blockContainer.AddILRange(new Interval(exceptionRegion.HandlerOffset, exceptionRegion.HandlerOffset + exceptionRegion.HandlerLength));
				blockContainer.Blocks.Add(new Block());
				handlerContainers.Add(blockContainer.StartILOffset, blockContainer);
				if (exceptionRegion.Kind == ExceptionRegionKind.Fault || exceptionRegion.Kind == ExceptionRegionKind.Finally)
				{
					BlockContainer blockContainer2 = new BlockContainer();
					blockContainer2.AddILRange(tryRange);
					if (exceptionRegion.Kind == ExceptionRegionKind.Finally)
					{
						tryInstructionList.Add(new TryFinally(blockContainer2, blockContainer).WithILRange(tryRange));
					}
					else
					{
						tryInstructionList.Add(new TryFault(blockContainer2, blockContainer).WithILRange(tryRange));
					}
					continue;
				}
				TryCatch tryCatch = list.FirstOrDefault((TryCatch tc) => Enumerable.SingleOrDefault<Interval>(tc.TryBlock.ILRanges) == tryRange);
				if (tryCatch == null)
				{
					BlockContainer blockContainer3 = new BlockContainer();
					blockContainer3.AddILRange(tryRange);
					tryCatch = new TryCatch(blockContainer3);
					tryCatch.AddILRange(tryRange);
					list.Add(tryCatch);
					tryInstructionList.Add(tryCatch);
				}
				ILInstruction iLInstruction;
				if (exceptionRegion.Kind == ExceptionRegionKind.Filter)
				{
					BlockContainer blockContainer4 = new BlockContainer(ContainerKind.Normal, StackType.I4);
					blockContainer4.AddILRange(new Interval(exceptionRegion.FilterOffset, exceptionRegion.HandlerOffset));
					blockContainer4.Blocks.Add(new Block());
					handlerContainers.Add(blockContainer4.StartILOffset, blockContainer4);
					iLInstruction = blockContainer4;
				}
				else
				{
					iLInstruction = new LdcI4(1);
				}
				TryCatchHandler tryCatchHandler = new TryCatchHandler(iLInstruction, blockContainer, variableByExceptionHandler[exceptionRegion]);
				tryCatchHandler.AddILRange(iLInstruction);
				tryCatchHandler.AddILRange(blockContainer);
				tryCatch.Handlers.Add(tryCatchHandler);
				tryCatch.AddILRange(tryCatchHandler);
			}
			if (tryInstructionList.Count > 0)
			{
				tryInstructionList = Enumerable.ToList<TryInstruction>((IEnumerable<TryInstruction>)Enumerable.ThenByDescending<TryInstruction, int>(Enumerable.OrderBy<TryInstruction, int>((IEnumerable<TryInstruction>)tryInstructionList, (Func<TryInstruction, int>)((TryInstruction tc) => tc.TryBlock.StartILOffset)), (Func<TryInstruction, int>)((TryInstruction tc) => tc.TryBlock.EndILOffset)));
				nextTry = tryInstructionList[0];
			}
		}
	}

	public void CreateBlocks(BlockContainer mainContainer, List<ILInstruction> instructions, BitArray incomingBranches, CancellationToken cancellationToken)
	{
		CreateContainerStructure();
		mainContainer.SetILRange(new Interval(0, body.GetCodeSize()));
		currentContainer = mainContainer;
		if (instructions.Count == 0)
		{
			currentContainer.Blocks.Add(new Block
			{
				Instructions = { (ILInstruction)new InvalidBranch("Empty body found. Decompiled assembly might be a reference assembly.") }
			});
			return;
		}
		foreach (ILInstruction instruction in instructions)
		{
			cancellationToken.ThrowIfCancellationRequested();
			int startILOffset = instruction.StartILOffset;
			if (currentBlock == null || (incomingBranches[startILOffset] && !IsStackAdjustment(instruction)))
			{
				FinalizeCurrentBlock(startILOffset, fallthrough: true);
				while (startILOffset >= currentContainer.EndILOffset)
				{
					currentContainer = containerStack.Pop();
					currentBlock = currentContainer.Blocks.Last();
					if (startILOffset >= currentContainer.EndILOffset)
					{
						Debug.Assert(currentBlock.HasILRange);
						currentBlock.AddILRange(new Interval(currentBlock.StartILOffset, startILOffset));
					}
				}
				if (handlerContainers.TryGetValue(startILOffset, out var value))
				{
					containerStack.Push(currentContainer);
					currentContainer = value;
					currentBlock = value.EntryPoint;
				}
				else
				{
					FinalizeCurrentBlock(startILOffset, fallthrough: false);
					currentBlock = new Block();
					currentContainer.Blocks.Add(currentBlock);
				}
				currentBlock.SetILRange(new Interval(startILOffset, startILOffset));
			}
			while (nextTry != null && startILOffset == nextTry.TryBlock.StartILOffset)
			{
				currentBlock.Instructions.Add(nextTry);
				containerStack.Push(currentContainer);
				currentContainer = (BlockContainer)nextTry.TryBlock;
				currentBlock = new Block();
				currentContainer.Blocks.Add(currentBlock);
				currentBlock.SetILRange(new Interval(startILOffset, startILOffset));
				nextTry = Enumerable.ElementAtOrDefault<TryInstruction>((IEnumerable<TryInstruction>)tryInstructionList, checked(++currentTryIndex));
			}
			currentBlock.Instructions.Add(instruction);
			if (instruction.HasFlag(InstructionFlags.EndPointUnreachable))
			{
				FinalizeCurrentBlock(instruction.EndILOffset, fallthrough: false);
			}
			else if (!CreateExtendedBlocks && instruction.HasFlag(InstructionFlags.MayBranch))
			{
				FinalizeCurrentBlock(instruction.EndILOffset, fallthrough: true);
			}
		}
		FinalizeCurrentBlock(mainContainer.EndILOffset, fallthrough: false);
		while (containerStack.Count > 0)
		{
			currentContainer = containerStack.Pop();
			currentBlock = currentContainer.Blocks.Last();
			FinalizeCurrentBlock(mainContainer.EndILOffset, fallthrough: false);
		}
		ConnectBranches(mainContainer, cancellationToken);
	}

	private static bool IsStackAdjustment(ILInstruction inst)
	{
		return inst is StLoc stLoc && stLoc.IsStackAdjustment;
	}

	private void FinalizeCurrentBlock(int currentILOffset, bool fallthrough)
	{
		if (currentBlock == null)
		{
			return;
		}
		Debug.Assert(currentBlock.HasILRange);
		currentBlock.SetILRange(new Interval(currentBlock.StartILOffset, currentILOffset));
		if (fallthrough)
		{
			if (currentBlock.Instructions.LastOrDefault() is SwitchInstruction switchInstruction && switchInstruction.Sections.Last().Body.MatchNop())
			{
				switchInstruction.Sections.Last().Body = new Branch(currentILOffset);
				Debug.Assert(switchInstruction.HasFlag(InstructionFlags.EndPointUnreachable));
			}
			else
			{
				currentBlock.Instructions.Add(new Branch(currentILOffset));
			}
		}
		currentBlock = null;
	}

	private void ConnectBranches(ILInstruction inst, CancellationToken cancellationToken)
	{
		if (inst != null)
		{
			if (inst is Branch branch)
			{
				Branch branch2 = branch;
				cancellationToken.ThrowIfCancellationRequested();
				Debug.Assert(branch2.TargetBlock == null);
				branch2.TargetBlock = FindBranchTarget(branch2.TargetILOffset);
				if (branch2.TargetBlock == null)
				{
					branch2.ReplaceWith(new InvalidBranch("Could not find block for branch target " + DisassemblerHelpers.OffsetToString(branch2.TargetILOffset)).WithILRange(branch2));
				}
				return;
			}
			if (inst is Leave leave)
			{
				Leave leave2 = leave;
				if (leave2.TargetContainer == null)
				{
					leave2.TargetContainer = containerStack.Peek();
					leave2.Value = ILReader.Cast(leave2.Value, leave2.TargetContainer.ExpectedResultType, null, leave2.StartILOffset);
				}
				return;
			}
			if (inst is BlockContainer blockContainer)
			{
				BlockContainer blockContainer2 = blockContainer;
				containerStack.Push(blockContainer2);
				foreach (Block block in blockContainer2.Blocks)
				{
					cancellationToken.ThrowIfCancellationRequested();
					ConnectBranches(block, cancellationToken);
					if (block.Instructions.Count == 0 || !block.Instructions.Last().HasFlag(InstructionFlags.EndPointUnreachable))
					{
						block.Instructions.Add(new InvalidBranch("Unexpected end of block"));
					}
				}
				containerStack.Pop();
				return;
			}
		}
		foreach (ILInstruction child in inst.Children)
		{
			ConnectBranches(child, cancellationToken);
		}
	}

	private Block FindBranchTarget(int targetILOffset)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = containerStack.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BlockContainer current = enumerator.Current;
				foreach (Block block in current.Blocks)
				{
					if (block.StartILOffset == targetILOffset)
					{
						return block;
					}
				}
			}
		}
		finally
		{
			((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		return null;
	}
}

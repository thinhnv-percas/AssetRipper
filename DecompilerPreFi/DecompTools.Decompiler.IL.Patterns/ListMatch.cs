using System.Collections.Generic;

namespace DecompTools.Decompiler.IL.Patterns;

public struct ListMatch
{
	private struct SavePoint
	{
		internal readonly int CheckPoint;

		internal readonly int SyntaxIndex;

		internal readonly Stack<int> stack;

		public SavePoint(int checkpoint, int syntaxIndex)
		{
			CheckPoint = checkpoint;
			SyntaxIndex = syntaxIndex;
			stack = new Stack<int>();
		}
	}

	internal readonly IReadOnlyList<ILInstruction> SyntaxList;

	internal int SyntaxIndex;

	private List<SavePoint> backtrackingStack;

	private Stack<int> restoreStack;

	internal static bool DoMatch(IReadOnlyList<ILInstruction> patterns, IReadOnlyList<ILInstruction> syntaxList, ref Match match)
	{
		ListMatch listMatch = new ListMatch(syntaxList);
		do
		{
			if (PerformMatchSequence(patterns, ref listMatch, ref match) && listMatch.SyntaxIndex == syntaxList.Count)
			{
				return true;
			}
		}
		while (listMatch.RestoreSavePoint(ref match));
		return false;
	}

	internal static bool PerformMatchSequence(IReadOnlyList<ILInstruction> patterns, ref ListMatch listMatch, ref Match match)
	{
		for (int i = listMatch.PopFromSavePoint() ?? 0; i < patterns.Count; i = checked(i + 1))
		{
			int savePointStartMarker = listMatch.GetSavePointStartMarker();
			bool flag = patterns[i].PerformMatch(ref listMatch, ref match);
			listMatch.PushToSavePoints(savePointStartMarker, i);
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	private ListMatch(IReadOnlyList<ILInstruction> syntaxList)
	{
		SyntaxList = syntaxList;
		SyntaxIndex = 0;
		backtrackingStack = null;
		restoreStack = null;
	}

	private void AddSavePoint(SavePoint savepoint)
	{
		if (backtrackingStack == null)
		{
			backtrackingStack = new List<SavePoint>();
		}
		backtrackingStack.Add(savepoint);
	}

	internal void AddSavePoint(ref Match match, int data)
	{
		SavePoint savepoint = new SavePoint(match.CheckPoint(), SyntaxIndex);
		savepoint.stack.Push(data);
		AddSavePoint(savepoint);
	}

	internal int GetSavePointStartMarker()
	{
		return (backtrackingStack != null) ? backtrackingStack.Count : 0;
	}

	internal void PushToSavePoints(int startMarker, int data)
	{
		if (backtrackingStack != null)
		{
			for (int i = startMarker; i < backtrackingStack.Count; i = checked(i + 1))
			{
				backtrackingStack[i].stack.Push(data);
			}
		}
	}

	internal int? PopFromSavePoint()
	{
		if (restoreStack == null || restoreStack.Count == 0)
		{
			return null;
		}
		return restoreStack.Pop();
	}

	internal bool RestoreSavePoint(ref Match match)
	{
		if (backtrackingStack == null || backtrackingStack.Count == 0)
		{
			return false;
		}
		checked
		{
			SavePoint savePoint = backtrackingStack[backtrackingStack.Count - 1];
			backtrackingStack.RemoveAt(backtrackingStack.Count - 1);
			match.RestoreCheckPoint(savePoint.CheckPoint);
			SyntaxIndex = savePoint.SyntaxIndex;
			restoreStack = savePoint.stack;
			return true;
		}
	}
}

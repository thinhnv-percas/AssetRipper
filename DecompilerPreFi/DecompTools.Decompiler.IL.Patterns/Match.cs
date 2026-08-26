using System.Collections.Generic;

namespace DecompTools.Decompiler.IL.Patterns;

public struct Match
{
	private static readonly List<KeyValuePair<CaptureGroup, ILInstruction>> emptyResults = new List<KeyValuePair<CaptureGroup, ILInstruction>>();

	private List<KeyValuePair<CaptureGroup, ILInstruction>> results;

	public bool Success
	{
		get
		{
			return results != null;
		}
		internal set
		{
			if (value)
			{
				if (results == null)
				{
					results = emptyResults;
				}
			}
			else
			{
				results = null;
			}
		}
	}

	public static bool operator true(Match m)
	{
		return m.Success;
	}

	public static bool operator false(Match m)
	{
		return !m.Success;
	}

	internal void Add(CaptureGroup g, ILInstruction n)
	{
		if (results == null)
		{
			results = new List<KeyValuePair<CaptureGroup, ILInstruction>>();
		}
		results.Add(new KeyValuePair<CaptureGroup, ILInstruction>(g, n));
	}

	internal int CheckPoint()
	{
		return (results != null) ? results.Count : 0;
	}

	internal void RestoreCheckPoint(int checkPoint)
	{
		if (results != null)
		{
			results.RemoveRange(checkPoint, checked(results.Count - checkPoint));
		}
	}

	public IEnumerable<ILInstruction> Get(CaptureGroup captureGroup)
	{
		if (results == null)
		{
			yield break;
		}
		foreach (KeyValuePair<CaptureGroup, ILInstruction> pair in results)
		{
			if (pair.Key == captureGroup)
			{
				yield return pair.Value;
			}
		}
	}
}

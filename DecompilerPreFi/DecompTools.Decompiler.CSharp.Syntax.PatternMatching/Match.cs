using System.Collections.Generic;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public struct Match
{
	private List<KeyValuePair<string, INode>> results;

	public bool Success => results != null;

	internal static Match CreateNew()
	{
		Match result = default(Match);
		result.results = new List<KeyValuePair<string, INode>>();
		return result;
	}

	internal int CheckPoint()
	{
		return results.Count;
	}

	internal void RestoreCheckPoint(int checkPoint)
	{
		results.RemoveRange(checkPoint, checked(results.Count - checkPoint));
	}

	public IEnumerable<INode> Get(string groupName)
	{
		if (results == null)
		{
			yield break;
		}
		foreach (KeyValuePair<string, INode> pair in results)
		{
			if (pair.Key == groupName)
			{
				yield return pair.Value;
			}
		}
	}

	public IEnumerable<T> Get<T>(string groupName) where T : INode
	{
		if (results == null)
		{
			yield break;
		}
		foreach (KeyValuePair<string, INode> pair in results)
		{
			if (pair.Key == groupName)
			{
				yield return (T)pair.Value;
			}
		}
	}

	public bool Has(string groupName)
	{
		if (results == null)
		{
			return false;
		}
		foreach (KeyValuePair<string, INode> result in results)
		{
			if (result.Key == groupName)
			{
				return true;
			}
		}
		return false;
	}

	public void Add(string groupName, INode node)
	{
		if (groupName != null && node != null)
		{
			results.Add(new KeyValuePair<string, INode>(groupName, node));
		}
	}

	internal void AddNull(string groupName)
	{
		if (groupName != null)
		{
			results.Add(new KeyValuePair<string, INode>(groupName, null));
		}
	}
}

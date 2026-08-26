using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor.TreeViewExamples;

[CreateAssetMenu(fileName = "TreeDataAsset", menuName = "Tree Asset", order = 1)]
public class MyTreeAsset : ScriptableObject
{
	[SerializeField]
	private List<ScriptDbTreeElement> m_TreeElements = new List<ScriptDbTreeElement>();

	internal List<ScriptDbTreeElement> treeElements
	{
		get
		{
			return m_TreeElements;
		}
		set
		{
			m_TreeElements = value;
		}
	}

	private void Awake()
	{
		if (m_TreeElements.Count == 0)
		{
			m_TreeElements = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020.GenerateRandomTree(160);
		}
	}
}

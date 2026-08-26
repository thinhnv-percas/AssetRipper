using System;

namespace UnityEditor.TreeViewExamples;

[Serializable]
internal class ScriptDbTreeElement : TreeElement
{
	internal string text = string.Empty;

	internal bool IsAssembly;

	private bool _selected;

	public _0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A item;

	internal bool selected
	{
		get
		{
			return _selected;
		}
		set
		{
			if (_selected == value)
			{
				return;
			}
			_selected = value;
			if (item != null)
			{
				item._0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A = value;
			}
			if (base.children == null)
			{
				return;
			}
			foreach (TreeElement child in base.children)
			{
				if (child is ScriptDbTreeElement scriptDbTreeElement)
				{
					scriptDbTreeElement.selected = value;
				}
			}
		}
	}

	public ScriptDbTreeElement(string name, int depth, int id)
		: base(name, depth, id)
	{
	}
}

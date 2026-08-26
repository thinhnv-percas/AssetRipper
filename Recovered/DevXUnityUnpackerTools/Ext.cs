using System.Windows.Forms;

public static class Ext
{
	public static TreeNode AddChild(this TreeNode node, string key, string text, string img, string sel_img)
	{
		return node.Nodes.Add(key, text, img, sel_img);
	}

	public static TreeNode AddChild(this TreeNode node, string key, string text)
	{
		return node.Nodes.Add(key, text);
	}

	public static TreeNode AddChild(this TreeNode node, string text)
	{
		return node.Nodes.Add(text);
	}

	public static TreeNode AddChild(this MultiSelectTreeView node, string key, string text, string img, string sel_img)
	{
		return node.Nodes.Add(key, text, img, sel_img);
	}

	public static TreeNode AddChild(this MultiSelectTreeView node, string key, string text)
	{
		return node.Nodes.Add(key, text);
	}

	public static TreeNode AddChild(this MultiSelectTreeView node, string text)
	{
		return node.Nodes.Add(text);
	}
}

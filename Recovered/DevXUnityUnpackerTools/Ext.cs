using System.Windows.Forms;

public class Ext
{
	public static TreeNode AddChild(TreeNode node, string key, string text, string img, string sel_img)
	{
		return node.Nodes.Add(key, text, img, sel_img);
	}

	public static TreeNode AddChild(TreeNode node, string key, string text)
	{
		return node.Nodes.Add(key, text);
	}

	public static TreeNode AddChild(TreeNode node, string text)
	{
		return node.Nodes.Add(text);
	}

	public static TreeNode AddChild(MultiSelectTreeView node, string key, string text, string img, string sel_img)
	{
		return node.Nodes.Add(key, text, img, sel_img);
	}

	public static TreeNode AddChild(MultiSelectTreeView node, string key, string text)
	{
		return node.Nodes.Add(key, text);
	}

	public static TreeNode AddChild(MultiSelectTreeView node, string text)
	{
		return node.Nodes.Add(text);
	}
}

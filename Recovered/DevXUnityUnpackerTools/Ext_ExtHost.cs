using System.Windows.Forms;

	public static class Ext_ExtHost
	{
	public static TreeNode AddChild(this TreeNode node, string key, string text, string img, string sel_img)
	{
		return Ext.AddChild(node, key, text, img, sel_img);
	}
	public static TreeNode AddChild(this TreeNode node, string key, string text)
	{
		return Ext.AddChild(node, key, text);
	}
	public static TreeNode AddChild(this TreeNode node, string text)
	{
		return Ext.AddChild(node, text);
	}
	public static TreeNode AddChild(this MultiSelectTreeView node, string key, string text, string img, string sel_img)
	{
		return Ext.AddChild(node, key, text, img, sel_img);
	}
	public static TreeNode AddChild(this MultiSelectTreeView node, string key, string text)
	{
		return Ext.AddChild(node, key, text);
	}
	public static TreeNode AddChild(this MultiSelectTreeView node, string text)
	{
		return Ext.AddChild(node, text);
	}
	}

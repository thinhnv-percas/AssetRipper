using System;
using System.Runtime.CompilerServices;

namespace DevXForms
{
	public class TreeViewEventArgs : EventArgs
	{
		[CompilerGenerated]
		private readonly TreeNode _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A;

		[CompilerGenerated]
		private readonly TreeViewAction _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020;

		public TreeNode Node
		{
			get;
		}

		public TreeViewAction Action
		{
			get;
		}

		public TreeViewEventArgs(TreeNode node)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A = node;
		}

		public TreeViewEventArgs(TreeNode node, TreeViewAction action)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A = node;
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020 = action;
		}
	}
}

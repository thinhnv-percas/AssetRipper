namespace DevXForms
{
	public class TreeListViewNodes : TreeNodeCollection
	{
		private MultiSelectTreeView2 _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A;

		private bool _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020;

		public void BeginUpdate()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020 = true;
		}

		public void EndUpdate()
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020 = false;
		}

		public TreeListViewNodes(MultiSelectTreeView2 owner)
			: base(null)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A = owner;
		}

		protected override void UpdateNodeCount(int oldvalue, int newvalue)
		{
			base.UpdateNodeCount(oldvalue, newvalue);
			if (!_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A.RecalcLayout();
			}
		}

		public override void Clear()
		{
			base.Clear();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A.RecalcLayout();
		}

		public override void NodetifyBeforeExpand(TreeNode nodeToExpand, bool expanding, out bool cancel)
		{
			cancel = false;
			if (!_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A.OnNotifyBeforeExpand(nodeToExpand, expanding, out cancel);
			}
		}

		public override void NodetifyAfterExpand(TreeNode nodeToExpand, bool expanded)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A.OnNotifyAfterExpand(nodeToExpand, expanded);
		}

		protected override int GetFieldIndex(string fieldname)
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A.Columns[fieldname]?.Index ?? (-1);
		}

		public void EnsureVisible(TreeNode node)
		{
			if (node != null)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A?.EnsureVisible(node);
			}
		}
	}
}

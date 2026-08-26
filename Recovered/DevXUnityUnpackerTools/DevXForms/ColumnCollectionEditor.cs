using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace DevXForms
{
	public class ColumnCollectionEditor : CollectionEditor
	{
		public ColumnCollectionEditor(Type type)
			: base(type)
		{
		}

		protected override bool CanSelectMultipleInstances()
		{
			return false;
		}

		protected override Type CreateCollectionItemType()
		{
			return base.CreateCollectionItemType();
		}

		protected override object CreateInstance(Type itemType)
		{
			MultiSelectTreeView2 multiSelectTreeView = base.Context.Instance as MultiSelectTreeView2;
			int num = multiSelectTreeView.Columns.Count;
			string text;
			string caption;
			do
			{
				text = "fieldname" + num.ToString();
				caption = "Column_" + num.ToString();
				num++;
			}
			while (multiSelectTreeView.Columns[text] != null);
			return new TreeListColumn(text, caption);
		}

		protected override string GetDisplayText(object value)
		{
			TreeListColumn treeListColumn = (TreeListColumn)value;
			if (treeListColumn.Caption.Length > 0)
			{
				return $"{treeListColumn.Caption} ({treeListColumn.Fieldname})";
			}
			return base.GetDisplayText(value);
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			object result = base.EditValue(context, provider, value);
			(base.Context.Instance as MultiSelectTreeView2).Invalidate();
			return result;
		}
	}
}

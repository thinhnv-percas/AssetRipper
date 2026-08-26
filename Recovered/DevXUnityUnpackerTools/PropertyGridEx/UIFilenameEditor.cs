using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace PropertyGridEx
{
	public class UIFilenameEditor : UITypeEditor
	{
		[AttributeUsage(AttributeTargets.Property)]
		public class FileDialogFilterAttribute : Attribute
		{
			internal string _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A;

			public string Filter => _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A;

			public FileDialogFilterAttribute(string filter)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A = filter;
			}
		}

		[AttributeUsage(AttributeTargets.Property)]
		public class SaveFileAttribute : Attribute
		{
		}

		public enum FileDialogType
		{
			LoadFileDialog,
			SaveFileDialog
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null && context.Instance != null && !context.PropertyDescriptor.IsReadOnly)
			{
				return UITypeEditorEditStyle.Modal;
			}
			return UITypeEditorEditStyle.None;
		}

		[RefreshProperties(RefreshProperties.All)]
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context == null || provider == null || context.Instance == null)
			{
				return EditValue(provider, value);
			}
			FileDialog fileDialog = (context.PropertyDescriptor.Attributes[typeof(SaveFileAttribute)] != null) ? ((FileDialog)new SaveFileDialog()) : ((FileDialog)new OpenFileDialog());
			fileDialog.Title = "Select " + context.PropertyDescriptor.DisplayName;
			fileDialog.FileName = (string)value;
			FileDialogFilterAttribute fileDialogFilterAttribute = (FileDialogFilterAttribute)context.PropertyDescriptor.Attributes[typeof(FileDialogFilterAttribute)];
			if (fileDialogFilterAttribute != null)
			{
				fileDialog.Filter = fileDialogFilterAttribute.Filter;
			}
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				value = fileDialog.FileName;
			}
			fileDialog.Dispose();
			return value;
		}
	}
}

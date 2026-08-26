using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridEx
{
	public class UIListboxEditor : UITypeEditor
	{
		[AttributeUsage(AttributeTargets.Property)]
		public class UIListboxDatasource : Attribute
		{
			private object _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020;

			public object Value => _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020;

			public UIListboxDatasource(ref object Datasource)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020 = Datasource;
			}
		}

		[AttributeUsage(AttributeTargets.Property)]
		public class UIListboxValueMember : Attribute
		{
			private string _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A;

			public string Value
			{
				get
				{
					return _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A;
				}
				set
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A = value;
				}
			}

			public UIListboxValueMember(string ValueMember)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A = ValueMember;
			}
		}

		[AttributeUsage(AttributeTargets.Property)]
		public class UIListboxDisplayMember : Attribute
		{
			private string _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020;

			public string Value
			{
				get
				{
					return _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020;
				}
				set
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020 = value;
				}
			}

			public UIListboxDisplayMember(string DisplayMember)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020 = DisplayMember;
			}
		}

		[AttributeUsage(AttributeTargets.Property)]
		public class UIListboxIsDropDownResizable : Attribute
		{
		}

		private bool _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A;

		private ListBox _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020 = new ListBox();

		private object _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A;

		private IWindowsFormsEditorService _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020;

		public override bool IsDropDownResizable => _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A;

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null && context.Instance != null)
			{
				if ((UIListboxIsDropDownResizable)context.PropertyDescriptor.Attributes[typeof(UIListboxIsDropDownResizable)] != null)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A = true;
				}
				return UITypeEditorEditStyle.DropDown;
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
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020 = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020 != null)
			{
				CustomProperty customProperty = (CustomProperty)((CustomProperty.CustomPropertyDescriptor)context.PropertyDescriptor).CustomProperty;
				UIListboxDatasource uIListboxDatasource = (UIListboxDatasource)context.PropertyDescriptor.Attributes[typeof(UIListboxDatasource)];
				UIListboxValueMember uIListboxValueMember = (UIListboxValueMember)context.PropertyDescriptor.Attributes[typeof(UIListboxValueMember)];
				UIListboxDisplayMember uIListboxDisplayMember = (UIListboxDisplayMember)context.PropertyDescriptor.Attributes[typeof(UIListboxDisplayMember)];
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.BorderStyle = BorderStyle.None;
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.IntegralHeight = true;
				if (uIListboxDatasource != null)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.DataSource = uIListboxDatasource.Value;
				}
				if (uIListboxDisplayMember != null)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.DisplayMember = uIListboxDisplayMember.Value;
				}
				if (uIListboxValueMember != null)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.ValueMember = uIListboxValueMember.Value;
				}
				if (value != null)
				{
					if (value.GetType().Name == "String")
					{
						_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.Text = (string)value;
					}
					else
					{
						_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.SelectedItem = value;
					}
				}
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.SelectedIndexChanged += _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A;
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020.DropDownControl(_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020);
				if (_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.SelectedIndices.Count == 1)
				{
					customProperty.SelectedItem = _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.SelectedItem;
					customProperty.SelectedValue = _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A;
					value = _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.Text;
				}
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020.CloseDropDown();
				return value;
			}
			return EditValue(provider, value);
		}

		private void _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A(object _0020, EventArgs _0020_000A)
		{
			if (_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020 != null)
			{
				if (_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.SelectedValue != null)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A = _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020.SelectedValue;
				}
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020.CloseDropDown();
			}
		}
	}
}

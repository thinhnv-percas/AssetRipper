using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace PropertyGridEx
{
	public class UICustomEventEditor : UITypeEditor
	{
		public delegate object OnClick(object sender, EventArgs e);

		[AttributeUsage(AttributeTargets.Property)]
		public class DelegateAttribute : Attribute
		{
			internal OnClick m_MethodDelegate;

			public OnClick GetMethod => m_MethodDelegate;

			public DelegateAttribute(OnClick MethodDelegate)
			{
				m_MethodDelegate = MethodDelegate;
			}
		}

		internal OnClick m_MethodDelegate;

		internal CustomProperty.CustomPropertyDescriptor m_sender;

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
			if (m_MethodDelegate == null)
			{
				DelegateAttribute delegateAttribute = (DelegateAttribute)context.PropertyDescriptor.Attributes[typeof(DelegateAttribute)];
				m_MethodDelegate = delegateAttribute.GetMethod;
			}
			if (m_sender == null)
			{
				m_sender = (context.PropertyDescriptor as CustomProperty.CustomPropertyDescriptor);
			}
			return m_MethodDelegate(m_sender, null);
		}
	}
}

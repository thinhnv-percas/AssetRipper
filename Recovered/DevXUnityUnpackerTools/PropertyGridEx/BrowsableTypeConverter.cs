using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace PropertyGridEx
{
	public class BrowsableTypeConverter : ExpandableObjectConverter
	{
		public enum LabelStyle
		{
			lsNormal,
			lsTypeName,
			lsEllipsis
		}

		public class BrowsableLabelStyleAttribute : Attribute
		{
			internal LabelStyle _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020;

			public LabelStyle LabelStyle
			{
				get
				{
					return _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020;
				}
				set
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020 = value;
				}
			}

			public BrowsableLabelStyleAttribute(LabelStyle LabelStyle)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020 = LabelStyle;
			}
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return true;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			BrowsableLabelStyleAttribute browsableLabelStyleAttribute = (BrowsableLabelStyleAttribute)context.PropertyDescriptor.Attributes[typeof(BrowsableLabelStyleAttribute)];
			if (browsableLabelStyleAttribute != null)
			{
				switch (browsableLabelStyleAttribute.LabelStyle)
				{
				case LabelStyle.lsNormal:
					return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
				case LabelStyle.lsTypeName:
					return "(" + value.GetType().Name + ")";
				case LabelStyle.lsEllipsis:
					return "(...)";
				}
			}
			return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
		}
	}
}

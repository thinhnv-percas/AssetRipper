using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PropertyGridEx
{
	[Serializable]
	public class CustomChoices : ArrayList
	{
		public class CustomChoicesTypeConverter : TypeConverter
		{
			internal CustomChoicesAttributeList oChoices;

			public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
			{
				CustomChoicesAttributeList customChoicesAttributeList = (CustomChoicesAttributeList)context.PropertyDescriptor.Attributes[typeof(CustomChoicesAttributeList)];
				if (oChoices != null)
				{
					return true;
				}
				if (customChoicesAttributeList != null)
				{
					oChoices = customChoicesAttributeList;
					return true;
				}
				return false;
			}

			public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
			{
				CustomChoicesAttributeList customChoicesAttributeList = (CustomChoicesAttributeList)context.PropertyDescriptor.Attributes[typeof(CustomChoicesAttributeList)];
				if (oChoices != null)
				{
					return true;
				}
				if (customChoicesAttributeList != null)
				{
					oChoices = customChoicesAttributeList;
					return true;
				}
				return false;
			}

			public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
			{
				CustomChoicesAttributeList customChoicesAttribute = (CustomChoicesAttributeList)context.PropertyDescriptor.Attributes[typeof(CustomChoicesAttributeList)];
				if (oChoices != null)
				{
					return oChoices.Values;
				}
				return base.GetStandardValues(context);
			}
		}

		public class CustomChoicesAttributeList : Attribute
		{
			internal ArrayList oList = new ArrayList();

			public ArrayList Item => oList;

			public TypeConverter.StandardValuesCollection Values => new TypeConverter.StandardValuesCollection(oList);

			public CustomChoicesAttributeList(string[] List)
			{
				oList.AddRange(List);
			}

			public CustomChoicesAttributeList(ArrayList List)
			{
				oList.AddRange(List);
			}

			public CustomChoicesAttributeList(ListBox.ObjectCollection List)
			{
				oList.AddRange(List);
			}
		}

		public ArrayList Items => this;

		public CustomChoices(ArrayList array, bool IsSorted)
		{
			AddRange(array);
			if (IsSorted)
			{
				Sort();
			}
		}

		public CustomChoices(ArrayList array)
		{
			AddRange(array);
		}

		public CustomChoices(string[] array, bool IsSorted)
		{
			AddRange(array);
			if (IsSorted)
			{
				Sort();
			}
		}

		public CustomChoices(string[] array)
		{
			AddRange(array);
		}

		public CustomChoices(int[] array, bool IsSorted)
		{
			AddRange(array);
			if (IsSorted)
			{
				Sort();
			}
		}

		public CustomChoices(int[] array)
		{
			AddRange(array);
		}

		public CustomChoices(double[] array, bool IsSorted)
		{
			AddRange(array);
			if (IsSorted)
			{
				Sort();
			}
		}

		public CustomChoices(double[] array)
		{
			AddRange(array);
		}

		public CustomChoices(object[] array, bool IsSorted)
		{
			AddRange(array);
			if (IsSorted)
			{
				Sort();
			}
		}

		public CustomChoices(object[] array)
		{
			AddRange(array);
		}
	}
}

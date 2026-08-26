using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PropertyGridEx
{
	[Serializable]
	public class CustomPropertyCollection : CollectionBase, ICustomTypeDescriptor
	{
		public virtual CustomProperty this[int index]
		{
			get
			{
				return (CustomProperty)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}

		public virtual int Add(CustomProperty value)
		{
			return base.List.Add(value);
		}

		public virtual int Add(string strName, object objValue, bool boolIsReadOnly, string strCategory, string strDescription, bool boolVisible)
		{
			return base.List.Add(new CustomProperty(strName, objValue, boolIsReadOnly, strCategory, strDescription, boolVisible));
		}

		public virtual int Add(string strName, ref object objRef, string strProp, bool boolIsReadOnly, string strCategory, string strDescription, bool boolVisible)
		{
			return base.List.Add(new CustomProperty(strName, ref objRef, strProp, boolIsReadOnly, strCategory, strDescription, boolVisible));
		}

		public virtual void Remove(string Name)
		{
			foreach (CustomProperty item in base.List)
			{
				if (item.Name == Name)
				{
					base.List.Remove(item);
					break;
				}
			}
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
		}

		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
		}

		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
		}

		public EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
		}

		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
		}

		public PropertyDescriptorCollection GetProperties()
		{
			return TypeDescriptor.GetProperties(this, noCustomTypeDesc: true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			foreach (CustomProperty item in base.List)
			{
				if (item.Visible)
				{
					ArrayList arrayList = new ArrayList();
					if (item.IsBrowsable)
					{
						arrayList.Add(new TypeConverterAttribute(typeof(BrowsableTypeConverter)));
					}
					if (item.UseFileNameEditor)
					{
						arrayList.Add(new EditorAttribute(typeof(UIFilenameEditor), typeof(UITypeEditor)));
					}
					if (item.Choices != null)
					{
						arrayList.Add(new TypeConverterAttribute(typeof(CustomChoices.CustomChoicesTypeConverter)));
					}
					if (item.IsPassword)
					{
						arrayList.Add(new PasswordPropertyTextAttribute(password: true));
					}
					if (item.Parenthesize)
					{
						arrayList.Add(new ParenthesizePropertyNameAttribute(needParenthesis: true));
					}
					if (item.Datasource != null)
					{
						arrayList.Add(new EditorAttribute(typeof(UIListboxEditor), typeof(UITypeEditor)));
					}
					if (item.CustomEditor != null)
					{
						arrayList.Add(new EditorAttribute(item.CustomEditor.GetType(), typeof(UITypeEditor)));
					}
					if (item.CustomTypeConverter != null)
					{
						arrayList.Add(new TypeConverterAttribute(item.CustomTypeConverter.GetType()));
					}
					if (item.IsPercentage)
					{
						arrayList.Add(new TypeConverterAttribute(typeof(OpacityConverter)));
					}
					if (item.OnClick != null)
					{
						arrayList.Add(new EditorAttribute(typeof(UICustomEventEditor), typeof(UITypeEditor)));
					}
					if (item.DefaultValue != null)
					{
						arrayList.Add(new DefaultValueAttribute(item.Type, item.Value.ToString()));
					}
					else if (item.DefaultType != null)
					{
						arrayList.Add(new DefaultValueAttribute(item.DefaultType, null));
					}
					if (item.Attributes != null)
					{
						arrayList.AddRange(item.Attributes);
					}
					Attribute[] attrs = (Attribute[])arrayList.ToArray(typeof(Attribute));
					propertyDescriptorCollection.Add(new CustomProperty.CustomPropertyDescriptor(item, attrs));
				}
			}
			return propertyDescriptorCollection;
		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

		public void SaveXml(string filename)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomPropertyCollection));
			FileStream fileStream = new FileStream(filename, FileMode.Create);
			try
			{
				xmlSerializer.Serialize(fileStream, this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.InnerException.Message);
			}
			fileStream.Close();
		}

		public bool LoadXml(string filename)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomPropertyCollection));
				FileStream fileStream = new FileStream(filename, FileMode.Open);
				foreach (CustomProperty item in (CustomPropertyCollection)xmlSerializer.Deserialize(fileStream))
				{
					item.RebuildAttributes();
					Add(item);
				}
				fileStream.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void SaveBinary(string filename)
		{
			Stream stream = File.Create(filename);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			try
			{
				binaryFormatter.Serialize(stream, this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.InnerException.Message);
			}
			stream.Close();
		}

		public bool LoadBinary(string filename)
		{
			try
			{
				Stream stream = File.Open(filename, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				if (stream.Length > 0)
				{
					foreach (CustomProperty item in (CustomPropertyCollection)binaryFormatter.Deserialize(stream))
					{
						item.RebuildAttributes();
						Add(item);
					}
					stream.Close();
					return true;
				}
				stream.Close();
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}

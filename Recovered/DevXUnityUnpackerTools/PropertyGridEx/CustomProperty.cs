using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Xml.Serialization;

namespace PropertyGridEx
{
	[Serializable]
	[XmlRoot("CustomProperty")]
	public class CustomProperty
	{
		public class CustomPropertyDescriptor : PropertyDescriptor
		{
			protected CustomProperty oCustomProperty;

			public override Type ComponentType => GetType();

			public override bool IsReadOnly => oCustomProperty.IsReadOnly;

			public override Type PropertyType => oCustomProperty.Type;

			public override string Description => oCustomProperty.Description;

			public override string Category => oCustomProperty.Category;

			public override string DisplayName => oCustomProperty.Name;

			public override bool IsBrowsable => oCustomProperty.IsBrowsable;

			public object CustomProperty => oCustomProperty;

			public CustomPropertyDescriptor(CustomProperty myProperty, Attribute[] attrs)
				: base(myProperty.Name, attrs)
			{
				if (myProperty == null)
				{
					oCustomProperty = null;
				}
				else
				{
					oCustomProperty = myProperty;
				}
			}

			public override bool CanResetValue(object component)
			{
				if (oCustomProperty.DefaultValue != null || oCustomProperty.DefaultType != null)
				{
					return true;
				}
				return false;
			}

			public override object GetValue(object component)
			{
				return oCustomProperty.Value;
			}

			public override void ResetValue(object component)
			{
				oCustomProperty.Value = oCustomProperty.DefaultValue;
				OnValueChanged(component, EventArgs.Empty);
			}

			public override void SetValue(object component, object value)
			{
				oCustomProperty.Value = value;
				OnValueChanged(component, EventArgs.Empty);
			}

			public override bool ShouldSerializeValue(object component)
			{
				object value = oCustomProperty.Value;
				if (oCustomProperty.DefaultValue != null && value != null)
				{
					return !value.Equals(oCustomProperty.DefaultValue);
				}
				return false;
			}
		}

		protected string sName = "";

		protected object oValue;

		protected bool bIsReadOnly;

		protected bool bVisible = true;

		protected string sDescription = "";

		protected string sCategory = "";

		protected bool bIsPassword;

		protected bool bIsPercentage;

		protected bool bParenthesize;

		protected string sFilter;

		protected UIFilenameEditor.FileDialogType eDialogType;

		protected bool bUseFileNameEditor;

		protected CustomChoices oChoices;

		protected bool bIsBrowsable;

		protected BrowsableTypeConverter.LabelStyle eBrowsablePropertyLabel = BrowsableTypeConverter.LabelStyle.lsEllipsis;

		protected bool bRef;

		protected object oRef;

		protected string sProp = "";

		protected object oDatasource;

		protected string sDisplayMember;

		protected string sValueMember;

		protected object oSelectedValue;

		protected object oSelectedItem;

		protected bool bIsDropdownResizable;

		protected UICustomEventEditor.OnClick MethodDelegate;

		[NonSerialized]
		protected AttributeCollection oCustomAttributes;

		protected object oTag;

		protected object oDefaultValue;

		protected Type oDefaultType;

		[NonSerialized]
		protected UITypeEditor oCustomEditor;

		[NonSerialized]
		protected TypeConverter oCustomTypeConverter;

		private object DataColumn
		{
			get
			{
				DataRow dataRow = (DataRow)oRef;
				if (dataRow.RowState != DataRowState.Deleted)
				{
					if (oDatasource == null)
					{
						return dataRow[sProp];
					}
					DataTable dataTable = oDatasource as DataTable;
					if (dataTable != null)
					{
						return dataTable.Select(sValueMember + "=" + dataRow[sProp])[0][sDisplayMember];
					}
					Information.Err().Raise(-2147220991, null, "Bind of DataRow with a DataSource that is not a DataTable is not possible");
					return null;
				}
				return null;
			}
			set
			{
				DataRow dataRow = (DataRow)oRef;
				if (dataRow.RowState == DataRowState.Deleted)
				{
					return;
				}
				if (oDatasource == null)
				{
					dataRow[sProp] = value;
					return;
				}
				DataTable dataTable = oDatasource as DataTable;
				if (dataTable != null)
				{
					if (dataTable.Columns[sDisplayMember].DataType.Equals(Type.GetType("System.String")))
					{
						dataRow[sProp] = dataTable.Select(dataTable.Columns[sDisplayMember].ColumnName + " = '" + value + "'")[0][sValueMember];
					}
					else
					{
						dataRow[sProp] = dataTable.Select(dataTable.Columns[sDisplayMember].ColumnName + " = " + value)[0][sValueMember];
					}
				}
				else
				{
					Information.Err().Raise(-2147220990, null, "Bind of DataRow with a DataSource that is not a DataTable is impossible");
				}
			}
		}

		[XmlElement("Name")]
		[Description("Display Name of the CustomProperty.")]
		[Category("Appearance")]
		[ParenthesizePropertyName(true)]
		[DisplayName("Name")]
		public string Name
		{
			get
			{
				return sName;
			}
			set
			{
				sName = value;
			}
		}

		[Description("Set read only attribute of the CustomProperty.")]
		[Category("Appearance")]
		[DisplayName("ReadOnly")]
		[XmlElement("ReadOnly")]
		public bool IsReadOnly
		{
			get
			{
				return bIsReadOnly;
			}
			set
			{
				bIsReadOnly = value;
			}
		}

		[Description("Set visibility attribute of the CustomProperty.")]
		[Category("Appearance")]
		public bool Visible
		{
			get
			{
				return bVisible;
			}
			set
			{
				bVisible = value;
			}
		}

		[Description("Represent the Value of the CustomProperty.")]
		[Category("Appearance")]
		public object Value
		{
			get
			{
				if (bRef)
				{
					if (oRef.GetType() == typeof(DataRow) || oRef.GetType().IsSubclassOf(typeof(DataRow)))
					{
						return DataColumn;
					}
					return Interaction.CallByName(oRef, sProp, CallType.Get, null);
				}
				return oValue;
			}
			set
			{
				if (bRef)
				{
					if (oRef.GetType() == typeof(DataRow) || oRef.GetType().IsSubclassOf(typeof(DataRow)))
					{
						DataColumn = value;
					}
					else
					{
						Interaction.CallByName(oRef, sProp, CallType.Set, value);
					}
				}
				else
				{
					oValue = value;
				}
			}
		}

		[Category("Appearance")]
		[Description("Set description associated with the CustomProperty.")]
		public string Description
		{
			get
			{
				return sDescription;
			}
			set
			{
				sDescription = value;
			}
		}

		[Category("Appearance")]
		[Description("Set category associated with the CustomProperty.")]
		public string Category
		{
			get
			{
				return sCategory;
			}
			set
			{
				sCategory = value;
			}
		}

		[XmlIgnore]
		public Type Type
		{
			get
			{
				if (Value != null)
				{
					return Value.GetType();
				}
				if (oDefaultValue != null)
				{
					return oDefaultValue.GetType();
				}
				return oDefaultType;
			}
		}

		[XmlIgnore]
		public AttributeCollection Attributes
		{
			get
			{
				return oCustomAttributes;
			}
			set
			{
				oCustomAttributes = value;
			}
		}

		[Description("Indicates if the property is browsable or not.")]
		[Category("Behavior")]
		[XmlElement(IsNullable = false)]
		public bool IsBrowsable
		{
			get
			{
				return bIsBrowsable;
			}
			set
			{
				bIsBrowsable = value;
				if (value)
				{
					BuildAttributes_BrowsableProperty();
				}
			}
		}

		[DefaultValue(false)]
		[XmlElement("Parenthesize")]
		[Category("Appearance")]
		[Description("Indicates whether the name of the associated property is displayed with parentheses in the Properties window.")]
		[DisplayName("Parenthesize")]
		public bool Parenthesize
		{
			get
			{
				return bParenthesize;
			}
			set
			{
				bParenthesize = value;
			}
		}

		[XmlElement(IsNullable = false)]
		[Category("Behavior")]
		[Description("Indicates the style of the label when a property is browsable.")]
		public BrowsableTypeConverter.LabelStyle BrowsableLabelStyle
		{
			get
			{
				return eBrowsablePropertyLabel;
			}
			set
			{
				bool flag = false;
				if (value != eBrowsablePropertyLabel)
				{
					flag = true;
				}
				eBrowsablePropertyLabel = value;
				if (flag)
				{
					BrowsableTypeConverter.BrowsableLabelStyleAttribute browsableLabelStyleAttribute = new BrowsableTypeConverter.BrowsableLabelStyleAttribute(value);
					oCustomAttributes = new AttributeCollection(browsableLabelStyleAttribute);
				}
			}
		}

		[Category("Behavior")]
		[XmlElement(IsNullable = false)]
		[Description("Indicates if the property is masked or not.")]
		public bool IsPassword
		{
			get
			{
				return bIsPassword;
			}
			set
			{
				bIsPassword = value;
			}
		}

		[Category("Behavior")]
		[Description("Indicates if the property represents a value in percentage.")]
		[XmlElement(IsNullable = false)]
		public bool IsPercentage
		{
			get
			{
				return bIsPercentage;
			}
			set
			{
				bIsPercentage = value;
			}
		}

		[Description("Indicates if the property uses a FileNameEditor converter.")]
		[XmlElement(IsNullable = false)]
		[Category("Behavior")]
		public bool UseFileNameEditor
		{
			get
			{
				return bUseFileNameEditor;
			}
			set
			{
				bUseFileNameEditor = value;
			}
		}

		[Category("Behavior")]
		[XmlElement(IsNullable = false)]
		[Description("Apply a filter to FileNameEditor converter.")]
		public string FileNameFilter
		{
			get
			{
				return sFilter;
			}
			set
			{
				bool flag = false;
				if (value != sFilter)
				{
					flag = true;
				}
				sFilter = value;
				if (flag)
				{
					BuildAttributes_FilenameEditor();
				}
			}
		}

		[XmlElement(IsNullable = false)]
		[Description("DialogType of the FileNameEditor.")]
		[Category("Behavior")]
		public UIFilenameEditor.FileDialogType FileNameDialogType
		{
			get
			{
				return eDialogType;
			}
			set
			{
				bool flag = false;
				if (value != eDialogType)
				{
					flag = true;
				}
				eDialogType = value;
				if (flag)
				{
					BuildAttributes_FilenameEditor();
				}
			}
		}

		[XmlIgnore]
		[Description("Custom Choices list.")]
		[Category("Behavior")]
		public CustomChoices Choices
		{
			get
			{
				return oChoices;
			}
			set
			{
				oChoices = value;
				BuildAttributes_CustomChoices();
			}
		}

		[Category("Databinding")]
		[XmlIgnore]
		public object Datasource
		{
			get
			{
				return oDatasource;
			}
			set
			{
				oDatasource = value;
				BuildAttributes_ListboxEditor();
			}
		}

		[XmlElement(IsNullable = false)]
		[Category("Databinding")]
		public string ValueMember
		{
			get
			{
				return sValueMember;
			}
			set
			{
				sValueMember = value;
				BuildAttributes_ListboxEditor();
			}
		}

		[XmlElement(IsNullable = false)]
		[Category("Databinding")]
		public string DisplayMember
		{
			get
			{
				return sDisplayMember;
			}
			set
			{
				sDisplayMember = value;
				BuildAttributes_ListboxEditor();
			}
		}

		[Category("Databinding")]
		[XmlElement(IsNullable = false)]
		public object SelectedValue
		{
			get
			{
				return oSelectedValue;
			}
			set
			{
				oSelectedValue = value;
			}
		}

		[Category("Databinding")]
		[XmlElement(IsNullable = false)]
		public object SelectedItem
		{
			get
			{
				return oSelectedItem;
			}
			set
			{
				oSelectedItem = value;
			}
		}

		[XmlElement(IsNullable = false)]
		[Category("Databinding")]
		public bool IsDropdownResizable
		{
			get
			{
				return bIsDropdownResizable;
			}
			set
			{
				bIsDropdownResizable = value;
				BuildAttributes_ListboxEditor();
			}
		}

		[XmlIgnore]
		public UITypeEditor CustomEditor
		{
			get
			{
				return oCustomEditor;
			}
			set
			{
				oCustomEditor = value;
			}
		}

		[XmlIgnore]
		public TypeConverter CustomTypeConverter
		{
			get
			{
				return oCustomTypeConverter;
			}
			set
			{
				oCustomTypeConverter = value;
			}
		}

		[XmlIgnore]
		public object Tag
		{
			get
			{
				return oTag;
			}
			set
			{
				oTag = value;
			}
		}

		[XmlIgnore]
		public object DefaultValue
		{
			get
			{
				return oDefaultValue;
			}
			set
			{
				oDefaultValue = value;
			}
		}

		[XmlIgnore]
		public Type DefaultType
		{
			get
			{
				return oDefaultType;
			}
			set
			{
				oDefaultType = value;
			}
		}

		[XmlIgnore]
		public UICustomEventEditor.OnClick OnClick
		{
			get
			{
				return MethodDelegate;
			}
			set
			{
				MethodDelegate = value;
				BuildAttributes_CustomEventProperty();
			}
		}

		public CustomProperty()
		{
			sName = "New Property";
			oValue = new string(' ', 0);
		}

		public CustomProperty(string strName, object objValue, bool boolIsReadOnly, string strCategory, string strDescription, bool boolVisible)
		{
			sName = strName;
			oValue = objValue;
			bIsReadOnly = boolIsReadOnly;
			sDescription = strDescription;
			sCategory = strCategory;
			bVisible = boolVisible;
			if (oValue != null)
			{
				oDefaultValue = oValue;
			}
		}

		public CustomProperty(string strName, ref object objRef, string strProp, bool boolIsReadOnly, string strCategory, string strDescription, bool boolVisible)
		{
			sName = strName;
			bIsReadOnly = boolIsReadOnly;
			sDescription = strDescription;
			sCategory = strCategory;
			bVisible = boolVisible;
			bRef = true;
			oRef = objRef;
			sProp = strProp;
			if (Value != null)
			{
				oDefaultValue = Value;
			}
		}

		public void RebuildAttributes()
		{
			if (bUseFileNameEditor)
			{
				BuildAttributes_FilenameEditor();
			}
			else if (oChoices != null)
			{
				BuildAttributes_CustomChoices();
			}
			else if (oDatasource != null)
			{
				BuildAttributes_ListboxEditor();
			}
			else if (bIsBrowsable)
			{
				BuildAttributes_BrowsableProperty();
			}
		}

		private void BuildAttributes_FilenameEditor()
		{
			ArrayList arrayList = new ArrayList();
			UIFilenameEditor.FileDialogFilterAttribute value = new UIFilenameEditor.FileDialogFilterAttribute(sFilter);
			UIFilenameEditor.SaveFileAttribute value2 = new UIFilenameEditor.SaveFileAttribute();
			arrayList.Add(value);
			if (eDialogType == UIFilenameEditor.FileDialogType.SaveFileDialog)
			{
				arrayList.Add(value2);
			}
			Attribute[] attributes = (Attribute[])arrayList.ToArray(typeof(Attribute));
			oCustomAttributes = new AttributeCollection(attributes);
		}

		private void BuildAttributes_CustomChoices()
		{
			if (oChoices != null)
			{
				CustomChoices.CustomChoicesAttributeList value = new CustomChoices.CustomChoicesAttributeList(oChoices.Items);
				Attribute[] attributes = (Attribute[])new ArrayList
				{
					value
				}.ToArray(typeof(Attribute));
				oCustomAttributes = new AttributeCollection(attributes);
			}
		}

		private void BuildAttributes_ListboxEditor()
		{
			if (oDatasource != null)
			{
				UIListboxEditor.UIListboxDatasource value = new UIListboxEditor.UIListboxDatasource(ref oDatasource);
				UIListboxEditor.UIListboxValueMember value2 = new UIListboxEditor.UIListboxValueMember(sValueMember);
				UIListboxEditor.UIListboxDisplayMember value3 = new UIListboxEditor.UIListboxDisplayMember(sDisplayMember);
				UIListboxEditor.UIListboxIsDropDownResizable uIListboxIsDropDownResizable = null;
				ArrayList arrayList = new ArrayList();
				arrayList.Add(value);
				arrayList.Add(value2);
				arrayList.Add(value3);
				if (bIsDropdownResizable)
				{
					uIListboxIsDropDownResizable = new UIListboxEditor.UIListboxIsDropDownResizable();
					arrayList.Add(uIListboxIsDropDownResizable);
				}
				Attribute[] attributes = (Attribute[])arrayList.ToArray(typeof(Attribute));
				oCustomAttributes = new AttributeCollection(attributes);
			}
		}

		private void BuildAttributes_BrowsableProperty()
		{
			BrowsableTypeConverter.BrowsableLabelStyleAttribute browsableLabelStyleAttribute = new BrowsableTypeConverter.BrowsableLabelStyleAttribute(eBrowsablePropertyLabel);
			oCustomAttributes = new AttributeCollection(browsableLabelStyleAttribute);
		}

		private void BuildAttributes_CustomEventProperty()
		{
			UICustomEventEditor.DelegateAttribute delegateAttribute = new UICustomEventEditor.DelegateAttribute(MethodDelegate);
			oCustomAttributes = new AttributeCollection(delegateAttribute);
		}
	}
}

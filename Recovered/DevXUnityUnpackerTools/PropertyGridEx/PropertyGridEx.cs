using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PropertyGridEx
{
	[DesignerGenerated]
	public class PropertyGridEx : PropertyGrid
	{
		internal CustomPropertyCollection oCustomPropertyCollection;

		internal bool bShowCustomProperties;

		internal CustomPropertyCollectionSet oCustomPropertyCollectionSet;

		internal bool bShowCustomPropertiesSet;

		internal object oPropertyGridView;

		internal object oHotCommands;

		internal object oDocComment;

		internal ToolStrip oToolStrip;

		internal Label oDocCommentTitle;

		internal Label oDocCommentDescription;

		internal FieldInfo oPropertyGridEntries;

		internal bool bAutoSizeProperties;

		internal bool bDrawFlatToolbar;

		internal Container _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Set the collection of the CustomProperty. Set ShowCustomProperties to True to enable it.")]
		[Category("Behavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public CustomPropertyCollection Item => oCustomPropertyCollection;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Behavior")]
		[Description("Set the CustomPropertyCollectionSet. Set ShowCustomPropertiesSet to True to enable it.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public CustomPropertyCollectionSet ItemSet => oCustomPropertyCollectionSet;

		[Category("Behavior")]
		[Description("Move automatically the splitter to better fit all the properties shown.")]
		[DefaultValue(false)]
		public bool AutoSizeProperties
		{
			get
			{
				return bAutoSizeProperties;
			}
			set
			{
				bAutoSizeProperties = value;
				if (value)
				{
					AutoSizeSplitter(32);
				}
			}
		}

		[DefaultValue(false)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Behavior")]
		[Description("Use the custom properties collection as SelectedObject.")]
		public bool ShowCustomProperties
		{
			get
			{
				return bShowCustomProperties;
			}
			set
			{
				if (value)
				{
					bShowCustomPropertiesSet = false;
					base.SelectedObject = oCustomPropertyCollection;
				}
				bShowCustomProperties = value;
			}
		}

		[DefaultValue(false)]
		[Description("Use the custom properties collections as SelectedObjects.")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Behavior")]
		public bool ShowCustomPropertiesSet
		{
			get
			{
				return bShowCustomPropertiesSet;
			}
			set
			{
				if (value)
				{
					bShowCustomProperties = false;
					base.SelectedObjects = (object[])oCustomPropertyCollectionSet.ToArray();
				}
				bShowCustomPropertiesSet = value;
			}
		}

		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Draw a flat toolbar")]
		public new bool DrawFlatToolbar
		{
			get
			{
				return bDrawFlatToolbar;
			}
			set
			{
				bDrawFlatToolbar = value;
				ApplyToolStripRenderMode(bDrawFlatToolbar);
			}
		}

		[Category("Appearance")]
		[Description("Toolbar object")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[DisplayName("Toolstrip")]
		public ToolStrip ToolStrip => oToolStrip;

		[DisplayName("Help")]
		[Description("DocComment object. Represent the comments area of the PropertyGrid.")]
		[Category("Appearance")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Control DocComment => (Control)oDocComment;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		[Description("Help Title Label.")]
		[Category("Appearance")]
		[DisplayName("HelpTitle")]
		public Label DocCommentTitle => oDocCommentTitle;

		[Category("Appearance")]
		[Browsable(true)]
		[DisplayName("HelpDescription")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Help Description Label.")]
		public Label DocCommentDescription => oDocCommentDescription;

		[Category("Appearance")]
		[DisplayName("HelpImageBackground")]
		[Description("Help Image Background.")]
		public Image DocCommentImage
		{
			get
			{
				return ((Control)oDocComment).BackgroundImage;
			}
			set
			{
				((Control)oDocComment).BackgroundImage = value;
			}
		}

		public PropertyGridEx()
		{
			_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020();
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			oCustomPropertyCollection = new CustomPropertyCollection();
			oCustomPropertyCollectionSet = new CustomPropertyCollectionSet();
			oPropertyGridView = GetType().BaseType.InvokeMember("gridView", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null);
			oHotCommands = GetType().BaseType.InvokeMember("hotcommands", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null);
			oToolStrip = (ToolStrip)GetType().BaseType.InvokeMember("toolStrip", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null);
			oDocComment = GetType().BaseType.InvokeMember("doccomment", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null);
			if (oDocComment != null)
			{
				oDocCommentTitle = (Label)oDocComment.GetType().InvokeMember("m_labelTitle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, oDocComment, null);
				oDocCommentDescription = (Label)oDocComment.GetType().InvokeMember("m_labelDesc", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, oDocComment, null);
			}
			if (oPropertyGridView != null)
			{
				oPropertyGridEntries = oPropertyGridView.GetType().GetField("allGridEntries", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
			}
			if (oToolStrip != null)
			{
				ApplyToolStripRenderMode(bDrawFlatToolbar);
			}
		}

		public void MoveSplitterTo(int x)
		{
			oPropertyGridView.GetType().InvokeMember("MoveSplitterTo", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, oPropertyGridView, new object[1]
			{
				x
			});
		}

		public override void Refresh()
		{
			if (bShowCustomPropertiesSet)
			{
				base.SelectedObjects = (object[])oCustomPropertyCollectionSet.ToArray();
			}
			try
			{
				base.Refresh();
			}
			catch
			{
			}
			if (bAutoSizeProperties)
			{
				AutoSizeSplitter(32);
			}
		}

		public void SetComment(string title, string description)
		{
			oDocComment.GetType().GetMethod("SetComment").Invoke(oDocComment, new object[2]
			{
				title,
				description
			});
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (bAutoSizeProperties)
			{
				AutoSizeSplitter(32);
			}
		}

		internal void AutoSizeSplitter(int RightMargin)
		{
			GridItemCollection gridItemCollection = (GridItemCollection)oPropertyGridEntries.GetValue(oPropertyGridView);
			if (gridItemCollection != null)
			{
				Graphics graphics = Graphics.FromHwnd(base.Handle);
				int num = 0;
				int num2 = 0;
				foreach (GridItem item in gridItemCollection)
				{
					if (item.GridItemType == GridItemType.Property)
					{
						num = (int)graphics.MeasureString(item.Label, Font).Width + RightMargin;
						if (num > num2)
						{
							num2 = num;
						}
					}
				}
				MoveSplitterTo(num2);
			}
		}

		internal void ApplyToolStripRenderMode(bool value)
		{
			if (value)
			{
				oToolStrip.Renderer = new ToolStripSystemRenderer();
				return;
			}
			ToolStripProfessionalRenderer toolStripProfessionalRenderer = new ToolStripProfessionalRenderer(new CustomColorScheme());
			toolStripProfessionalRenderer.RoundedEdges = false;
			oToolStrip.Renderer = toolStripProfessionalRenderer;
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			if (disposing && _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A != null)
			{
				_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A.Dispose();
			}
			base.Dispose(disposing);
		}

		[DebuggerStepThrough]
		internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020()
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A = new Container();
			base.AutoScaleMode = AutoScaleMode.Font;
		}
	}
}

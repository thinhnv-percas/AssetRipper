using System.Drawing;
using System.Windows.Forms;

namespace PropertyGridEx
{
	public class CustomColorScheme : ProfessionalColorTable
	{
		public override Color ButtonCheckedGradientBegin => Color.FromArgb(193, 210, 238);

		public override Color ButtonCheckedGradientEnd => Color.FromArgb(193, 210, 238);

		public override Color ButtonCheckedGradientMiddle => Color.FromArgb(193, 210, 238);

		public override Color ButtonPressedBorder => Color.FromArgb(49, 106, 197);

		public override Color ButtonPressedGradientBegin => Color.FromArgb(152, 181, 226);

		public override Color ButtonPressedGradientEnd => Color.FromArgb(152, 181, 226);

		public override Color ButtonPressedGradientMiddle => Color.FromArgb(152, 181, 226);

		public override Color ButtonSelectedBorder => base.ButtonSelectedBorder;

		public override Color ButtonSelectedGradientBegin => Color.FromArgb(193, 210, 238);

		public override Color ButtonSelectedGradientEnd => Color.FromArgb(193, 210, 238);

		public override Color ButtonSelectedGradientMiddle => Color.FromArgb(193, 210, 238);

		public override Color CheckBackground => Color.FromArgb(225, 230, 232);

		public override Color CheckPressedBackground => Color.FromArgb(49, 106, 197);

		public override Color CheckSelectedBackground => Color.FromArgb(49, 106, 197);

		public override Color GripDark => Color.FromArgb(193, 190, 179);

		public override Color GripLight => Color.FromArgb(255, 255, 255);

		public override Color ImageMarginGradientBegin => Color.FromArgb(251, 250, 247);

		public override Color ImageMarginGradientEnd => Color.FromArgb(189, 189, 163);

		public override Color ImageMarginGradientMiddle => Color.FromArgb(236, 231, 224);

		public override Color ImageMarginRevealedGradientBegin => Color.FromArgb(247, 246, 239);

		public override Color ImageMarginRevealedGradientEnd => Color.FromArgb(230, 227, 210);

		public override Color ImageMarginRevealedGradientMiddle => Color.FromArgb(242, 240, 228);

		public override Color MenuBorder => Color.FromArgb(138, 134, 122);

		public override Color MenuItemBorder => Color.FromArgb(49, 106, 197);

		public override Color MenuItemPressedGradientBegin => base.MenuItemPressedGradientBegin;

		public override Color MenuItemPressedGradientEnd => base.MenuItemPressedGradientEnd;

		public override Color MenuItemPressedGradientMiddle => base.MenuItemPressedGradientMiddle;

		public override Color MenuItemSelected => Color.FromArgb(193, 210, 238);

		public override Color MenuItemSelectedGradientBegin => Color.FromArgb(193, 210, 238);

		public override Color MenuItemSelectedGradientEnd => Color.FromArgb(193, 210, 238);

		public override Color MenuStripGradientBegin => Color.FromArgb(229, 229, 215);

		public override Color MenuStripGradientEnd => Color.FromArgb(244, 242, 232);

		public override Color OverflowButtonGradientBegin => Color.FromArgb(243, 242, 240);

		public override Color OverflowButtonGradientEnd => Color.FromArgb(146, 146, 118);

		public override Color OverflowButtonGradientMiddle => Color.FromArgb(226, 225, 219);

		public override Color RaftingContainerGradientBegin => Color.FromArgb(229, 229, 215);

		public override Color RaftingContainerGradientEnd => Color.FromArgb(244, 242, 232);

		public override Color SeparatorDark => Color.FromArgb(197, 194, 184);

		public override Color SeparatorLight => Color.FromArgb(255, 255, 255);

		public override Color ToolStripBorder => Color.FromArgb(163, 163, 124);

		public override Color ToolStripDropDownBackground => Color.FromArgb(252, 252, 249);

		public override Color ToolStripGradientBegin => Color.FromArgb(247, 246, 239);

		public override Color ToolStripGradientEnd => Color.FromArgb(192, 192, 168);

		public override Color ToolStripGradientMiddle => Color.FromArgb(242, 240, 228);

		public override Color ToolStripPanelGradientBegin => Color.FromArgb(229, 229, 215);

		public override Color ToolStripPanelGradientEnd => Color.FromArgb(244, 242, 232);
	}
}

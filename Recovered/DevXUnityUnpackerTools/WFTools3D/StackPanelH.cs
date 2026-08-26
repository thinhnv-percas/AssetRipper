using System.Windows;
using System.Windows.Controls;

namespace WFTools3D
{
	public class StackPanelH : StackPanel
	{
		public StackPanelH()
		{
			base.Orientation = Orientation.Horizontal;
		}

		protected override Size ArrangeOverride(Size arrangeSize)
		{
			double num = 0.0;
			foreach (UIElement internalChild in base.InternalChildren)
			{
				if (internalChild != null)
				{
					double width = internalChild.DesiredSize.Width;
					double height = internalChild.DesiredSize.Height;
					double y = (arrangeSize.Height - height) * 0.5;
					Rect finalRect = new Rect(num, y, width, height);
					internalChild.Arrange(finalRect);
					num += width;
				}
			}
			return arrangeSize;
		}
	}
}

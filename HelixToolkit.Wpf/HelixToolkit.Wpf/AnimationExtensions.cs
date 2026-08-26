using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace HelixToolkit.Wpf;

public static class AnimationExtensions
{
	public static void AnimateOpacity(this IAnimatable obj, double targetOpacity, double animationTime)
	{
		DoubleAnimation animation = new DoubleAnimation(targetOpacity, new Duration(TimeSpan.FromMilliseconds(animationTime)))
		{
			AccelerationRatio = 0.3,
			DecelerationRatio = 0.5
		};
		obj.BeginAnimation(UIElement.OpacityProperty, animation);
	}
}

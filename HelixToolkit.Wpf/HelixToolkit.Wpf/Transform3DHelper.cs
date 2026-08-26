using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class Transform3DHelper
{
	public static Transform3D CombineTransform(Transform3D t1, Transform3D t2)
	{
		if (t1 == null && t2 == null)
		{
			return Transform3D.Identity;
		}
		if (t1 == null && t2 != null)
		{
			return t2;
		}
		if (t1 != null && t2 == null)
		{
			return t1;
		}
		Transform3DGroup transform3DGroup = new Transform3DGroup();
		transform3DGroup.Children.Add(t1);
		transform3DGroup.Children.Add(t2);
		return transform3DGroup;
	}
}

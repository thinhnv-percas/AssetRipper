using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class CameraSetting
{
	public double FarPlaneDistance { get; set; }

	public double FieldOfView { get; set; }

	public Vector3D LookDirection { get; set; }

	public double NearPlaneDistance { get; set; }

	public Point3D Position { get; set; }

	public Vector3D UpDirection { get; set; }

	public double Width { get; set; }

	public CameraSetting(ProjectionCamera camera)
	{
		Position = camera.Position;
		LookDirection = camera.LookDirection;
		UpDirection = camera.UpDirection;
		NearPlaneDistance = camera.NearPlaneDistance;
		FarPlaneDistance = camera.FarPlaneDistance;
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			FieldOfView = perspectiveCamera.FieldOfView;
		}
		if (camera is OrthographicCamera orthographicCamera)
		{
			Width = orthographicCamera.Width;
		}
	}

	public void UpdateCamera(ProjectionCamera camera)
	{
		camera.Position = Position;
		camera.LookDirection = LookDirection;
		camera.UpDirection = UpDirection;
		camera.NearPlaneDistance = NearPlaneDistance;
		camera.FarPlaneDistance = FarPlaneDistance;
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			perspectiveCamera.FieldOfView = FieldOfView;
		}
		if (camera is OrthographicCamera orthographicCamera)
		{
			orthographicCamera.Width = Width;
		}
	}
}

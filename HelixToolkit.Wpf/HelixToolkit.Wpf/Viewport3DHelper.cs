using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace HelixToolkit.Wpf;

public static class Viewport3DHelper
{
	public class RectangleHitResult
	{
		public Model3D Model { get; private set; }

		public RectangleHitResult(Model3D model)
		{
			Model = model;
		}
	}

	public class HitResult
	{
		public double Distance { get; set; }

		public MeshGeometry3D Mesh => RayHit.MeshHit;

		public Model3D Model => RayHit.ModelHit;

		public Vector3D Normal { get; set; }

		public Point3D Position { get; set; }

		public RayMeshGeometry3DHitTestResult RayHit { get; set; }

		public Visual3D Visual => RayHit.VisualHit;
	}

	public static void Copy(this Viewport3D view, int m = 1)
	{
		Clipboard.SetImage(view.RenderBitmap(Brushes.White, m));
	}

	public static void Copy(this Viewport3D view, double width, double height, Brush background, int m = 1)
	{
		Clipboard.SetImage(view.RenderBitmap(width, height, background));
	}

	public static void CopyXaml(this Viewport3D viewport)
	{
		Clipboard.SetText(XamlWriter.Save(viewport));
	}

	public static void Export(this Viewport3D viewport, string fileName, Brush background = null)
	{
		string text = System.IO.Path.GetExtension(fileName);
		if (text != null)
		{
			text = text.ToLower();
		}
		switch (text)
		{
		case ".jpg":
		case ".png":
			viewport.SaveBitmap(fileName, background, 2);
			break;
		case ".xaml":
			viewport.ExportXaml(fileName);
			break;
		case ".xml":
			viewport.ExportKerkythea(fileName, background);
			break;
		case ".obj":
			viewport.ExportObj(fileName);
			break;
		case ".x3d":
			viewport.ExportX3D(fileName);
			break;
		case ".dae":
			viewport.ExportCollada(fileName);
			break;
		case ".stl":
			viewport.ExportStl(fileName);
			break;
		default:
			throw new HelixToolkitException("Not supported file format.");
		}
	}

	public static void ExportStereo(this Viewport3D viewport, string fileName, double stereoBase, Brush background = null)
	{
		string text = System.IO.Path.GetExtension(fileName);
		if (text != null)
		{
			text = text.ToLower();
		}
		switch (text)
		{
		case ".jpg":
		case ".png":
			viewport.SaveStereoBitmap(fileName, stereoBase, background, 2);
			break;
		case ".mpo":
			throw new HelixToolkitException("MPO is not yet supported.");
		default:
			throw new HelixToolkitException("Not supported file format.");
		}
	}

	public static IList<HitResult> FindHits(this Viewport3D viewport, Point position)
	{
		ProjectionCamera camera = viewport.Camera as ProjectionCamera;
		if (camera == null)
		{
			return null;
		}
		List<HitResult> result = new List<HitResult>();
		HitTestResultCallback resultCallback = delegate(HitTestResult hit)
		{
			if (hit is RayMeshGeometry3DHitTestResult { MeshHit: not null } rayMeshGeometry3DHitTestResult)
			{
				Point3D globalHitPosition = GetGlobalHitPosition(rayMeshGeometry3DHitTestResult, viewport);
				Vector3D? normalHit = GetNormalHit(rayMeshGeometry3DHitTestResult);
				Vector3D normal = (normalHit.HasValue ? normalHit.Value : new Vector3D(0.0, 0.0, 1.0));
				result.Add(new HitResult
				{
					Distance = (camera.Position - globalHitPosition).Length,
					RayHit = rayMeshGeometry3DHitTestResult,
					Normal = normal,
					Position = globalHitPosition
				});
			}
			return HitTestResultBehavior.Continue;
		};
		PointHitTestParameters hitTestParameters = new PointHitTestParameters(position);
		VisualTreeHelper.HitTest(viewport, null, resultCallback, hitTestParameters);
		return result.OrderBy((HitResult k) => k.Distance).ToList();
	}

	public static IEnumerable<RectangleHitResult> FindHits(this Viewport3D viewport, Rect rectangle, SelectionHitMode mode)
	{
		if (!(viewport.Camera is ProjectionCamera))
		{
			throw new InvalidOperationException("No projection camera defined. Cannot find rectangle hits.");
		}
		if (rectangle.Width < 1E-10 && rectangle.Height < 1E-10)
		{
			IList<HitResult> source = viewport.FindHits(rectangle.BottomLeft);
			return from x in source
				select x.Model into model
				select new RectangleHitResult(model);
		}
		List<RectangleHitResult> results = new List<RectangleHitResult>();
		viewport.Children.Traverse(delegate(GeometryModel3D model, Transform3D transform)
		{
			if (model.Geometry is MeshGeometry3D { Positions: not null, TriangleIndices: not null } meshGeometry3D)
			{
				bool flag = mode == SelectionHitMode.Inside;
				Point[] array = meshGeometry3D.Positions.Select(transform.Transform).Select(viewport.Point3DtoPoint2D).ToArray();
				for (int i = 0; i < meshGeometry3D.TriangleIndices.Count / 3; i++)
				{
					Triangle triangle = new Triangle(array[meshGeometry3D.TriangleIndices[i * 3]], array[meshGeometry3D.TriangleIndices[i * 3 + 1]], array[meshGeometry3D.TriangleIndices[i * 3 + 2]]);
					switch (mode)
					{
					case SelectionHitMode.Inside:
						flag = flag && triangle.IsCompletelyInside(rectangle);
						break;
					case SelectionHitMode.Touch:
						flag = flag || triangle.IsCompletelyInside(rectangle) || triangle.IntersectsWith(rectangle) || triangle.IsRectCompletelyInside(rectangle);
						break;
					}
					if ((mode == SelectionHitMode.Touch) & flag)
					{
						break;
					}
				}
				if (flag)
				{
					results.Add(new RectangleHitResult(model));
				}
			}
		});
		return results;
	}

	public static bool FindNearest(this Viewport3D viewport, Point position, out Point3D point, out Vector3D normal, out DependencyObject visual)
	{
		ProjectionCamera camera = viewport.Camera as ProjectionCamera;
		if (camera == null)
		{
			point = default(Point3D);
			normal = default(Vector3D);
			visual = null;
			return false;
		}
		PointHitTestParameters hitTestParameters = new PointHitTestParameters(position);
		double minimumDistance = double.MaxValue;
		Point3D nearestPoint = default(Point3D);
		Vector3D nearestNormal = default(Vector3D);
		DependencyObject nearestObject = null;
		VisualTreeHelper.HitTest(viewport, null, delegate(HitTestResult hit)
		{
			if (hit is RayMeshGeometry3DHitTestResult { MeshHit: { } meshHit } rayMeshGeometry3DHitTestResult)
			{
				Point3D point3D = meshHit.Positions[rayMeshGeometry3DHitTestResult.VertexIndex1];
				Point3D point3D2 = meshHit.Positions[rayMeshGeometry3DHitTestResult.VertexIndex2];
				Point3D point3D3 = meshHit.Positions[rayMeshGeometry3DHitTestResult.VertexIndex3];
				double x = point3D.X * rayMeshGeometry3DHitTestResult.VertexWeight1 + point3D2.X * rayMeshGeometry3DHitTestResult.VertexWeight2 + point3D3.X * rayMeshGeometry3DHitTestResult.VertexWeight3;
				double y = point3D.Y * rayMeshGeometry3DHitTestResult.VertexWeight1 + point3D2.Y * rayMeshGeometry3DHitTestResult.VertexWeight2 + point3D3.Y * rayMeshGeometry3DHitTestResult.VertexWeight3;
				double z = point3D.Z * rayMeshGeometry3DHitTestResult.VertexWeight1 + point3D2.Z * rayMeshGeometry3DHitTestResult.VertexWeight2 + point3D3.Z * rayMeshGeometry3DHitTestResult.VertexWeight3;
				Point3D point3D4 = new Point3D(x, y, z);
				GeneralTransform3D transformTo = rayMeshGeometry3DHitTestResult.VisualHit.GetTransformTo(rayMeshGeometry3DHitTestResult.ModelHit);
				if (transformTo != null)
				{
					point3D4 = transformTo.Transform(point3D4);
				}
				GeneralTransform3D transform = viewport.GetTransform(rayMeshGeometry3DHitTestResult.VisualHit);
				if (transform != null)
				{
					point3D4 = transform.Transform(point3D4);
				}
				double lengthSquared = (camera.Position - point3D4).LengthSquared;
				if (lengthSquared < minimumDistance)
				{
					minimumDistance = lengthSquared;
					nearestPoint = point3D4;
					nearestNormal = Vector3D.CrossProduct(point3D2 - point3D, point3D3 - point3D);
					nearestObject = hit.VisualHit;
				}
			}
			return HitTestResultBehavior.Continue;
		}, hitTestParameters);
		point = nearestPoint;
		visual = nearestObject;
		normal = nearestNormal;
		if (minimumDistance >= double.MaxValue)
		{
			return false;
		}
		normal.Normalize();
		return true;
	}

	public static Point3D? FindNearestPoint(this Viewport3D viewport, Point position)
	{
		if (viewport.FindNearest(position, out var point, out var _, out var _))
		{
			return point;
		}
		return null;
	}

	public static Visual3D FindNearestVisual(this Viewport3D viewport, Point position)
	{
		if (viewport.FindNearest(position, out var _, out var _, out var visual))
		{
			return visual as Visual3D;
		}
		return null;
	}

	public static Matrix3D GetCameraTransform(this Viewport3DVisual viewport3DVisual)
	{
		return viewport3DVisual.Camera.GetTotalTransform(viewport3DVisual.Viewport.Size.Width / viewport3DVisual.Viewport.Size.Height);
	}

	public static Matrix3D GetCameraTransform(this Viewport3D viewport)
	{
		return viewport.Camera.GetTotalTransform(viewport.ActualWidth / viewport.ActualHeight);
	}

	public static IEnumerable<Light> GetLights(this Viewport3D viewport)
	{
		IList<Model3D> source = viewport.Children.SearchFor<Light>();
		return source.Select((Model3D m) => m as Light);
	}

	public static Ray3D GetRay(this Viewport3D viewport, Point position)
	{
		if (!viewport.Point2DtoPoint3D(position, out var pointNear, out var pointFar))
		{
			return null;
		}
		return new Ray3D
		{
			Origin = pointNear,
			Direction = pointFar - pointNear
		};
	}

	public static Matrix3D GetTotalTransform(this Viewport3DVisual viewport3DVisual)
	{
		Matrix3D cameraTransform = viewport3DVisual.GetCameraTransform();
		cameraTransform.Append(viewport3DVisual.GetViewportTransform());
		return cameraTransform;
	}

	public static Matrix3D GetTotalTransform(this Viewport3D viewport)
	{
		Matrix3D cameraTransform = viewport.GetCameraTransform();
		cameraTransform.Append(viewport.GetViewportTransform());
		return cameraTransform;
	}

	public static GeneralTransform3D GetTransform(this Viewport3D viewport, Visual3D visual)
	{
		if (visual == null)
		{
			return null;
		}
		foreach (Visual3D child in viewport.Children)
		{
			if (visual.IsDescendantOf(child))
			{
				GeneralTransform3DGroup generalTransform3DGroup = new GeneralTransform3DGroup();
				GeneralTransform3D generalTransform3D = visual.TransformToAncestor(child);
				if (generalTransform3D != null)
				{
					generalTransform3DGroup.Children.Add(generalTransform3D);
				}
				generalTransform3DGroup.Children.Add(child.Transform);
				return generalTransform3DGroup;
			}
		}
		return visual.Transform;
	}

	public static Matrix3D GetViewMatrix(this Viewport3D viewport)
	{
		return viewport.Camera.GetViewMatrix();
	}

	public static Matrix3D GetProjectionMatrix(this Viewport3D viewport)
	{
		return viewport.Camera.GetProjectionMatrix(viewport.ActualHeight / viewport.ActualWidth);
	}

	public static Matrix3D GetViewportTransform(this Viewport3DVisual viewport3DVisual)
	{
		return new Matrix3D(viewport3DVisual.Viewport.Width / 2.0, 0.0, 0.0, 0.0, 0.0, (0.0 - viewport3DVisual.Viewport.Height) / 2.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, viewport3DVisual.Viewport.X + viewport3DVisual.Viewport.Width / 2.0, viewport3DVisual.Viewport.Y + viewport3DVisual.Viewport.Height / 2.0, 0.0, 1.0);
	}

	public static Matrix3D GetViewportTransform(this Viewport3D viewport)
	{
		return new Matrix3D(viewport.ActualWidth / 2.0, 0.0, 0.0, 0.0, 0.0, (0.0 - viewport.ActualHeight) / 2.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, viewport.ActualWidth / 2.0, viewport.ActualHeight / 2.0, 0.0, 1.0);
	}

	public static bool Point2DtoPoint3D(this Viewport3D viewport, Point pointIn, out Point3D pointNear, out Point3D pointFar)
	{
		pointNear = default(Point3D);
		pointFar = default(Point3D);
		Point3D point = new Point3D(pointIn.X, pointIn.Y, 0.0);
		Matrix3D viewportTransform = viewport.GetViewportTransform();
		Matrix3D cameraTransform = viewport.GetCameraTransform();
		if (!viewportTransform.HasInverse)
		{
			return false;
		}
		if (!cameraTransform.HasInverse)
		{
			return false;
		}
		viewportTransform.Invert();
		cameraTransform.Invert();
		Point3D point2 = viewportTransform.Transform(point);
		point2.Z = 0.01;
		pointNear = cameraTransform.Transform(point2);
		point2.Z = 0.99;
		pointFar = cameraTransform.Transform(point2);
		return true;
	}

	public static Ray3D Point2DtoRay3D(this Viewport3D viewport, Point pointIn)
	{
		if (!viewport.Point2DtoPoint3D(pointIn, out var pointNear, out var pointFar))
		{
			return null;
		}
		return new Ray3D(pointNear, pointFar);
	}

	public static Point Point3DtoPoint2D(this Viewport3D viewport, Point3D point)
	{
		Point3D point3D = viewport.GetTotalTransform().Transform(point);
		return new Point(point3D.X, point3D.Y);
	}

	public static void Print(this Viewport3D vp, string description)
	{
		PrintDialog printDialog = new PrintDialog();
		if (printDialog.ShowDialog() == true)
		{
			printDialog.PrintVisual(vp, description);
		}
	}

	public static BitmapSource RenderBitmap(this Viewport3D view, Brush background, int m = 1)
	{
		WriteableBitmap writeableBitmap = new WriteableBitmap((int)view.ActualWidth * m, (int)view.ActualHeight * m, 96.0, 96.0, PixelFormats.Pbgra32, null);
		Camera camera = view.Camera;
		Matrix3D viewMatrix = camera.GetViewMatrix();
		double aspectRatio = view.ActualWidth / view.ActualHeight;
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < m; j++)
			{
				Matrix3D projectionMatrix = camera.GetProjectionMatrix(aspectRatio);
				if (camera is OrthographicCamera)
				{
					projectionMatrix.OffsetX = m - 1 - i * 2;
					projectionMatrix.OffsetY = -(m - 1 - j * 2);
				}
				if (camera is PerspectiveCamera)
				{
					projectionMatrix.M31 = -(m - 1 - i * 2);
					projectionMatrix.M32 = m - 1 - j * 2;
				}
				projectionMatrix.M11 *= m;
				projectionMatrix.M22 *= m;
				MatrixCamera camera2 = new MatrixCamera(viewMatrix, projectionMatrix);
				view.Camera = camera2;
				RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)view.ActualWidth, (int)view.ActualHeight, 96.0, 96.0, PixelFormats.Pbgra32);
				Rectangle rectangle = new Rectangle
				{
					Width = renderTargetBitmap.Width,
					Height = renderTargetBitmap.Height,
					Fill = background
				};
				rectangle.Arrange(new Rect(0.0, 0.0, rectangle.Width, rectangle.Height));
				renderTargetBitmap.Render(rectangle);
				renderTargetBitmap.Render(view);
				CopyBitmap(renderTargetBitmap, writeableBitmap, (int)((double)i * view.ActualWidth), (int)((double)j * view.ActualHeight));
			}
		}
		view.Camera = camera;
		return writeableBitmap;
	}

	public static BitmapSource RenderBitmap(this Viewport3D view, double width, double height, Brush background, int m = 1)
	{
		double width2 = view.Width;
		double height2 = view.Height;
		view.ResizeAndArrange(width, height);
		BitmapSource result = view.RenderBitmap(background, m);
		view.ResizeAndArrange(width2, height2);
		return result;
	}

	public static void ResizeAndArrange(this Viewport3D view, double width, double height)
	{
		view.Width = width;
		view.Height = height;
		if (!double.IsNaN(width) && !double.IsNaN(height))
		{
			view.Measure(new Size(width, height));
			view.Arrange(new Rect(0.0, 0.0, width, height));
		}
	}

	public static void SaveBitmap(this Viewport3D view, string fileName, Brush background = null, int m = 1, BitmapExporter.OutputFormat format = BitmapExporter.OutputFormat.Png)
	{
		using FileStream stream = File.Create(fileName);
		view.SaveBitmap(stream, background, m, format);
	}

	public static void SaveStereoBitmap(this Viewport3D view, string fileName, double stereoBase, Brush background = null, int m = 1)
	{
		string extension = System.IO.Path.GetExtension(fileName);
		string path = System.IO.Path.GetDirectoryName(fileName) ?? string.Empty;
		string path2 = System.IO.Path.GetFileNameWithoutExtension(fileName) ?? string.Empty;
		string path3 = System.IO.Path.Combine(path, path2) + "_L" + extension;
		string path4 = System.IO.Path.Combine(path, path2) + "_R" + extension;
		PerspectiveCamera perspectiveCamera = view.Camera as PerspectiveCamera;
		PerspectiveCamera perspectiveCamera2 = new PerspectiveCamera();
		PerspectiveCamera perspectiveCamera3 = new PerspectiveCamera();
		StereoHelper.UpdateStereoCameras(perspectiveCamera, perspectiveCamera2, perspectiveCamera3, stereoBase);
		using (FileStream stream = File.Create(path3))
		{
			view.Camera = perspectiveCamera2;
			view.SaveBitmap(stream, background, m);
		}
		using (FileStream stream2 = File.Create(path4))
		{
			view.Camera = perspectiveCamera3;
			view.SaveBitmap(stream2, background, m);
		}
		view.Camera = perspectiveCamera;
	}

	public static void SaveBitmap(this Viewport3D view, Stream stream, Brush background = null, int m = 1, BitmapExporter.OutputFormat format = BitmapExporter.OutputFormat.Png)
	{
		BitmapExporter bitmapExporter = new BitmapExporter
		{
			Background = background,
			OversamplingMultiplier = m,
			Format = format
		};
		bitmapExporter.Export(view, stream);
	}

	public static IList<Model3D> SearchFor<T>(this IEnumerable<Visual3D> collection)
	{
		List<Model3D> list = new List<Model3D>();
		SearchFor(collection, typeof(T), list);
		return list;
	}

	public static Point3D? UnProject(this Viewport3D viewport, Point p, Point3D position, Vector3D normal)
	{
		Ray3D ray = viewport.GetRay(p);
		if (ray == null)
		{
			return null;
		}
		Point3D intersection;
		return ray.PlaneIntersection(position, normal, out intersection) ? new Point3D?(intersection) : ((Point3D?)null);
	}

	public static Point3D? UnProject(this Viewport3D viewport, Point p)
	{
		if (!(viewport.Camera is ProjectionCamera projectionCamera))
		{
			return null;
		}
		return viewport.UnProject(p, projectionCamera.Position + projectionCamera.LookDirection, projectionCamera.LookDirection);
	}

	public static int GetTotalNumberOfTriangles(this Viewport3D viewport)
	{
		int count = 0;
		viewport.Children.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			if (m.Geometry is MeshGeometry3D { TriangleIndices: not null } meshGeometry3D)
			{
				count += meshGeometry3D.TriangleIndices.Count / 3;
			}
		});
		return count;
	}

	private static void CopyBitmap(BitmapSource source, WriteableBitmap target, int x, int y)
	{
		int num = source.PixelWidth * (source.Format.BitsPerPixel / 8);
		byte[] pixels = new byte[num * source.PixelHeight];
		source.CopyPixels(pixels, num, 0);
		target.WritePixels(new Int32Rect(x, y, source.PixelWidth, source.PixelHeight), pixels, num, 0);
	}

	private static void ExportKerkythea(this Viewport3D view, string fileName, Brush background)
	{
		view.ExportKerkythea(fileName, background, (int)view.ActualWidth, (int)view.ActualHeight);
	}

	private static void ExportKerkythea(this Viewport3D view, string fileName, Brush background, int width, int height)
	{
		Color backgroundColor = ((background is SolidColorBrush solidColorBrush) ? solidColorBrush.Color : Colors.White);
		KerkytheaExporter kerkytheaExporter = new KerkytheaExporter
		{
			Width = width,
			Height = height,
			BackgroundColor = backgroundColor,
			TexturePath = System.IO.Path.GetDirectoryName(fileName)
		};
		using FileStream stream = File.Create(fileName);
		kerkytheaExporter.Export(view, stream);
	}

	private static void ExportObj(this Viewport3D view, string path)
	{
		string dir = System.IO.Path.GetDirectoryName(path) ?? ".";
		string fileName = System.IO.Path.GetFileName(path);
		ObjExporter objExporter = new ObjExporter
		{
			TextureFolder = dir,
			FileCreator = (string f) => File.Create(System.IO.Path.Combine(dir, f))
		};
		using FileStream stream = File.Create(path);
		objExporter.MaterialsFile = System.IO.Path.ChangeExtension(fileName, ".mtl");
		objExporter.Export(view, stream);
	}

	private static void ExportX3D(this Viewport3D view, string fileName)
	{
		X3DExporter x3DExporter = new X3DExporter();
		using FileStream stream = File.Create(fileName);
		x3DExporter.Export(view, stream);
	}

	private static void ExportCollada(this Viewport3D view, string fileName)
	{
		ColladaExporter colladaExporter = new ColladaExporter();
		using FileStream stream = File.Create(fileName);
		colladaExporter.Export(view, stream);
	}

	private static void ExportStl(this Viewport3D view, string fileName)
	{
		StlExporter stlExporter = new StlExporter();
		using FileStream stream = File.Create(fileName);
		stlExporter.Export(view, stream);
	}

	private static void ExportXaml(this Viewport3D view, string fileName)
	{
		XamlExporter xamlExporter = new XamlExporter();
		using FileStream stream = File.Create(fileName);
		xamlExporter.Export(view, stream);
	}

	private static Point3D GetGlobalHitPosition(RayHitTestResult rayHit, Viewport3D viewport)
	{
		Point3D point3D = rayHit.PointHit;
		GeneralTransform3D transform = viewport.GetTransform(rayHit.VisualHit);
		if (transform != null)
		{
			point3D = transform.Transform(point3D);
		}
		return point3D;
	}

	private static Vector3D? GetNormalHit(RayMeshGeometry3DHitTestResult rayHit)
	{
		if (rayHit.MeshHit.Normals == null || rayHit.MeshHit.Normals.Count < 1)
		{
			return null;
		}
		return rayHit.MeshHit.Normals[rayHit.VertexIndex1] * rayHit.VertexWeight1 + rayHit.MeshHit.Normals[rayHit.VertexIndex2] * rayHit.VertexWeight2 + rayHit.MeshHit.Normals[rayHit.VertexIndex3] * rayHit.VertexWeight3;
	}

	private static void SearchFor(IEnumerable<Visual3D> collection, Type type, IList<Model3D> output)
	{
		foreach (Visual3D item in collection)
		{
			if (!(item is ModelVisual3D { Content: var content } modelVisual3D))
			{
				continue;
			}
			if (content != null)
			{
				if (type.IsInstanceOfType(content))
				{
					output.Add(content);
				}
				SearchFor(modelVisual3D.Children, type, output);
			}
			if (content is Model3DGroup model3DGroup)
			{
				SearchFor(model3DGroup.Children, type, output);
			}
		}
	}

	private static void SearchFor(IEnumerable<Model3D> collection, Type type, IList<Model3D> output)
	{
		foreach (Model3D item in collection)
		{
			if (type.IsInstanceOfType(item))
			{
				output.Add(item);
			}
			if (item is Model3DGroup model3DGroup)
			{
				SearchFor(model3DGroup.Children, type, output);
			}
		}
	}
}

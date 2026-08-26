using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class CuttingPlaneGroup : RenderingModelVisual3D
{
	public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(CuttingPlaneGroup), new UIPropertyMetadata(false, IsEnabledChanged));

	public static readonly DependencyProperty OperationProperty = DependencyProperty.Register("Operation", typeof(CuttingOperation), typeof(CuttingPlaneGroup), new PropertyMetadata(CuttingOperation.Intersect, OperationChanged));

	private Dictionary<Model3D, Geometry3D> cutGeometries = new Dictionary<Model3D, Geometry3D>();

	private Dictionary<Model3D, Geometry3D> newCutGeometries;

	private Dictionary<Model3D, Geometry3D> newOriginalGeometries;

	private Dictionary<Model3D, Geometry3D> originalGeometries = new Dictionary<Model3D, Geometry3D>();

	public List<Plane3D> CuttingPlanes { get; set; }

	public bool IsEnabled
	{
		get
		{
			return (bool)GetValue(IsEnabledProperty);
		}
		set
		{
			SetValue(IsEnabledProperty, value);
		}
	}

	public CuttingOperation Operation
	{
		get
		{
			return (CuttingOperation)GetValue(OperationProperty);
		}
		set
		{
			SetValue(OperationProperty, value);
		}
	}

	public CuttingPlaneGroup()
	{
		IsEnabled = true;
		CuttingPlanes = new List<Plane3D>();
	}

	protected override void OnCompositionTargetRendering(object sender, RenderingEventArgs e)
	{
		if (IsEnabled)
		{
			ApplyCuttingGeometries();
		}
	}

	private static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		CuttingPlaneGroup cuttingPlaneGroup = (CuttingPlaneGroup)d;
		if (cuttingPlaneGroup.IsEnabled)
		{
			cuttingPlaneGroup.SubscribeToRenderingEvent();
		}
		else
		{
			cuttingPlaneGroup.UnsubscribeRenderingEvent();
		}
		cuttingPlaneGroup.ApplyCuttingGeometries(forceUpdate: true);
	}

	private static void OperationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CuttingPlaneGroup)d).ApplyCuttingGeometries(forceUpdate: true);
	}

	private void ApplyCuttingGeometries(bool forceUpdate = false)
	{
		lock (this)
		{
			newCutGeometries = new Dictionary<Model3D, Geometry3D>();
			newOriginalGeometries = new Dictionary<Model3D, Geometry3D>();
			base.Children.Traverse(delegate(GeometryModel3D m, Transform3D t)
			{
				ApplyCuttingPlanesToModel(m, t, forceUpdate);
			});
			cutGeometries = newCutGeometries;
			originalGeometries = newOriginalGeometries;
		}
	}

	private void ApplyCuttingPlanesToModel(GeometryModel3D model, Transform3D transform, bool updateRequired)
	{
		if (model.Geometry == null)
		{
			return;
		}
		if (!IsEnabled)
		{
			updateRequired = true;
		}
		if (cutGeometries.TryGetValue(model, out var value) && value == model.Geometry)
		{
			updateRequired = true;
		}
		if (!originalGeometries.TryGetValue(model, out var value2))
		{
			value2 = model.Geometry;
			updateRequired = true;
		}
		newOriginalGeometries.Add(model, value2);
		if (!updateRequired)
		{
			return;
		}
		Geometry3D geometry = value2;
		MeshGeometry3D meshGeometry3D = value2 as MeshGeometry3D;
		if (IsEnabled && meshGeometry3D != null)
		{
			GeneralTransform3D inverse = transform.Inverse;
			if (inverse == null)
			{
				throw new InvalidOperationException("No inverse transform.");
			}
			switch (Operation)
			{
			case CuttingOperation.Intersect:
			{
				MeshGeometry3D meshGeometry3D2 = meshGeometry3D;
				foreach (Plane3D cuttingPlane in CuttingPlanes)
				{
					meshGeometry3D2 = Intersect(meshGeometry3D2, inverse, cuttingPlane, complement: false);
				}
				geometry = meshGeometry3D2;
				break;
			}
			case CuttingOperation.Subtract:
			{
				MeshBuilder meshBuilder = new MeshBuilder(meshGeometry3D.Normals.Any(), meshGeometry3D.TextureCoordinates.Any());
				foreach (Plane3D cuttingPlane2 in CuttingPlanes)
				{
					MeshGeometry3D mesh = Intersect(meshGeometry3D, inverse, cuttingPlane2, complement: true);
					meshBuilder.Append(mesh);
				}
				geometry = meshBuilder.ToMesh(freeze: true);
				break;
			}
			}
		}
		model.Geometry = geometry;
		newCutGeometries.Add(model, meshGeometry3D);
	}

	private MeshGeometry3D Intersect(MeshGeometry3D source, GeneralTransform3D inverseTransform, Plane3D plane, bool complement)
	{
		Point3D point3D = inverseTransform.Transform(plane.Position);
		Point3D point3D2 = inverseTransform.Transform(plane.Position + plane.Normal);
		Vector3D normal = point3D2 - point3D;
		if (complement)
		{
			normal *= -1.0;
		}
		return source.Cut(point3D, normal);
	}
}

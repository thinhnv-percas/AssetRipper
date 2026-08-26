using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class MeshVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty EdgeDiameterProperty = DependencyProperty.Register("EdgeDiameter", typeof(double), typeof(MeshVisual3D), new UIPropertyMetadata(0.03, MeshChanged));

	public static readonly DependencyProperty EdgeMaterialProperty = DependencyProperty.Register("EdgeMaterial", typeof(Material), typeof(MeshVisual3D), new UIPropertyMetadata(Materials.Gray));

	public static readonly DependencyProperty FaceBackMaterialProperty = DependencyProperty.Register("FaceBackMaterial", typeof(Material), typeof(MeshVisual3D), new UIPropertyMetadata(Materials.Gray));

	public static readonly DependencyProperty FaceMaterialProperty = DependencyProperty.Register("FaceMaterial", typeof(Material), typeof(MeshVisual3D), new UIPropertyMetadata(Materials.Blue));

	public static readonly DependencyProperty MeshProperty = DependencyProperty.Register("Mesh", typeof(Mesh3D), typeof(MeshVisual3D), new UIPropertyMetadata(null, MeshChanged));

	public static readonly DependencyProperty SharedVerticesProperty = DependencyProperty.Register("SharedVertices", typeof(bool), typeof(MeshVisual3D), new UIPropertyMetadata(false, MeshChanged));

	public static readonly DependencyProperty ShrinkFactorProperty = DependencyProperty.Register("ShrinkFactor", typeof(double), typeof(MeshVisual3D), new UIPropertyMetadata(0.0, MeshChanged));

	public static readonly DependencyProperty VertexMaterialProperty = DependencyProperty.Register("VertexMaterial", typeof(Material), typeof(MeshVisual3D), new UIPropertyMetadata(Materials.Gold));

	public static readonly DependencyProperty VertexRadiusProperty = DependencyProperty.Register("VertexRadius", typeof(double), typeof(MeshVisual3D), new UIPropertyMetadata(0.05, MeshChanged));

	public static readonly DependencyProperty VertexResolutionProperty = DependencyProperty.Register("VertexResolution", typeof(int), typeof(MeshVisual3D), new UIPropertyMetadata(2));

	public double EdgeDiameter
	{
		get
		{
			return (double)GetValue(EdgeDiameterProperty);
		}
		set
		{
			SetValue(EdgeDiameterProperty, value);
		}
	}

	public Material EdgeMaterial
	{
		get
		{
			return (Material)GetValue(EdgeMaterialProperty);
		}
		set
		{
			SetValue(EdgeMaterialProperty, value);
		}
	}

	public Material FaceBackMaterial
	{
		get
		{
			return (Material)GetValue(FaceBackMaterialProperty);
		}
		set
		{
			SetValue(FaceBackMaterialProperty, value);
		}
	}

	public Material FaceMaterial
	{
		get
		{
			return (Material)GetValue(FaceMaterialProperty);
		}
		set
		{
			SetValue(FaceMaterialProperty, value);
		}
	}

	public Mesh3D Mesh
	{
		get
		{
			return (Mesh3D)GetValue(MeshProperty);
		}
		set
		{
			SetValue(MeshProperty, value);
		}
	}

	public bool SharedVertices
	{
		get
		{
			return (bool)GetValue(SharedVerticesProperty);
		}
		set
		{
			SetValue(SharedVerticesProperty, value);
		}
	}

	public double ShrinkFactor
	{
		get
		{
			return (double)GetValue(ShrinkFactorProperty);
		}
		set
		{
			SetValue(ShrinkFactorProperty, value);
		}
	}

	public List<int> TriangleIndexToFaceIndex { get; set; }

	public Material VertexMaterial
	{
		get
		{
			return (Material)GetValue(VertexMaterialProperty);
		}
		set
		{
			SetValue(VertexMaterialProperty, value);
		}
	}

	public double VertexRadius
	{
		get
		{
			return (double)GetValue(VertexRadiusProperty);
		}
		set
		{
			SetValue(VertexRadiusProperty, value);
		}
	}

	public int VertexResolution
	{
		get
		{
			return (int)GetValue(VertexResolutionProperty);
		}
		set
		{
			SetValue(VertexResolutionProperty, value);
		}
	}

	protected static void MeshChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((MeshVisual3D)obj).UpdateVisuals();
	}

	protected void UpdateVisuals()
	{
		if (Mesh == null)
		{
			base.Content = null;
			return;
		}
		Model3DGroup model3DGroup = new Model3DGroup();
		TriangleIndexToFaceIndex = new List<int>();
		MeshGeometry3D geometry = Mesh.ToMeshGeometry3D(SharedVertices, ShrinkFactor, TriangleIndexToFaceIndex);
		model3DGroup.Children.Add(new GeometryModel3D(geometry, FaceMaterial)
		{
			BackMaterial = FaceBackMaterial
		});
		if (VertexRadius > 0.0)
		{
			MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, generateTexCoords: false);
			foreach (Point3D vertex in Mesh.Vertices)
			{
				meshBuilder.AddSubdivisionSphere(vertex, VertexRadius, VertexResolution);
			}
			model3DGroup.Children.Add(new GeometryModel3D(meshBuilder.ToMesh(), VertexMaterial));
		}
		if (EdgeDiameter > 0.0)
		{
			MeshBuilder meshBuilder2 = new MeshBuilder(generateNormals: false, generateTexCoords: false);
			foreach (int[] face in Mesh.Faces)
			{
				for (int i = 0; i < face.Length; i++)
				{
					Point3D p = Mesh.Vertices[face[i]];
					Point3D p2 = Mesh.Vertices[face[(i + 1) % face.Length]];
					meshBuilder2.AddCylinder(p, p2, EdgeDiameter, 4);
				}
			}
			model3DGroup.Children.Add(new GeometryModel3D(meshBuilder2.ToMesh(), EdgeMaterial));
		}
		base.Content = model3DGroup;
	}
}

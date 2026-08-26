using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class MeshElement3D : ModelVisual3D, IEditableObject
{
	public static readonly DependencyProperty BackMaterialProperty = DependencyProperty.Register("BackMaterial", typeof(Material), typeof(MeshElement3D), new UIPropertyMetadata(MaterialHelper.CreateMaterial(Brushes.LightBlue), MaterialChanged));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(MeshElement3D), new UIPropertyMetadata(null, FillChanged));

	public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register("Material", typeof(Material), typeof(MeshElement3D), new UIPropertyMetadata(MaterialHelper.CreateMaterial(Brushes.Blue), MaterialChanged));

	public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register("Visible", typeof(bool), typeof(MeshElement3D), new UIPropertyMetadata(true, VisibleChanged));

	private bool isEditing;

	private bool isGeometryChanged;

	private bool isMaterialChanged;

	public Material BackMaterial
	{
		get
		{
			return (Material)GetValue(BackMaterialProperty);
		}
		set
		{
			SetValue(BackMaterialProperty, value);
		}
	}

	public Brush Fill
	{
		get
		{
			return (Brush)GetValue(FillProperty);
		}
		set
		{
			SetValue(FillProperty, value);
		}
	}

	public Material Material
	{
		get
		{
			return (Material)GetValue(MaterialProperty);
		}
		set
		{
			SetValue(MaterialProperty, value);
		}
	}

	public bool Visible
	{
		get
		{
			return (bool)GetValue(VisibleProperty);
		}
		set
		{
			SetValue(VisibleProperty, value);
		}
	}

	public GeometryModel3D Model => base.Content as GeometryModel3D;

	protected MeshElement3D()
	{
		base.Content = new GeometryModel3D();
		UpdateModel();
	}

	public void BeginEdit()
	{
		isEditing = true;
		isGeometryChanged = false;
		isMaterialChanged = false;
	}

	public void CancelEdit()
	{
		isEditing = false;
	}

	public void EndEdit()
	{
		isEditing = false;
		if (isGeometryChanged)
		{
			OnGeometryChanged();
		}
		if (isMaterialChanged)
		{
			OnMaterialChanged();
		}
	}

	public void UpdateModel()
	{
		OnGeometryChanged();
		OnMaterialChanged();
	}

	protected static void VisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MeshElement3D)d).OnGeometryChanged();
	}

	protected static void GeometryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MeshElement3D)d).OnGeometryChanged();
	}

	protected static void MaterialChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MeshElement3D)d).OnMaterialChanged();
	}

	protected virtual void OnFillChanged()
	{
		Material = MaterialHelper.CreateMaterial(Fill);
		BackMaterial = Material;
	}

	protected virtual void OnGeometryChanged()
	{
		if (!isEditing)
		{
			Model.Geometry = (Visible ? Tessellate() : null);
		}
		else
		{
			isGeometryChanged = true;
		}
	}

	protected virtual void OnMaterialChanged()
	{
		if (!isEditing)
		{
			Model.Material = Material;
			Model.BackMaterial = BackMaterial;
		}
		else
		{
			isMaterialChanged = true;
		}
	}

	protected abstract MeshGeometry3D Tessellate();

	private static void FillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MeshElement3D)d).OnFillChanged();
	}
}

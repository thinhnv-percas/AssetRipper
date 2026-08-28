using @as;
using HelixToolkit.Wpf;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using WFTools3D;

namespace DevXUnityUnpackerTools._WPF
{
	public class _3DView : System.Windows.Controls.UserControl, IComponentConnector
	{
		internal class Params
		{
			internal volatile bool _0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020;

			internal volatile bool _0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A;

			internal volatile bool _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A;

			internal volatile bool _0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020;

			internal volatile ManyCodeCls manyCodeCls;

			internal volatile ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020;

			internal volatile ModelHandler model;

			internal volatile ProjectionCamera camera;
		}

		internal class ModelHandler
		{
			internal ModelVisual3D model;

			internal ModelHandler()
			{
			}

			internal ModelHandler(ModelVisual3D paret)
			{
				model = paret;
			}
		}

		internal string currentActionString;

		internal ProjectionCamera camera;

		internal System.Windows.Media.Brush brush1;

		internal System.Windows.Media.Brush brush2;

		internal Material material;

		internal Material[] allMaterials;

		internal ModelVisual3D modelVisual2;

		internal ModelVisual3D modelVisual1;

		internal CameraBox cameraBox;

		internal int curIndex;

		internal Point3D point3D = Math3D.Origin;

		internal System.Windows.Point point = new System.Windows.Point(double.NaN, 0.0);

		internal bool IsInteractive_Val;

		internal volatile Params m_params;

		internal Dictionary<int, Params> paramsByIndex = new Dictionary<int, Params>();

		internal List<int> ints = new List<int>();

		internal Dictionary<ImageResData, Stream> imageAndStream2 = new Dictionary<ImageResData, Stream>();

		internal Dictionary<ImageResData, BitmapImage> imageAndBitmap = new Dictionary<ImageResData, BitmapImage>();

		internal static object lockObject = new object();

		internal Dictionary<ImageResData, Material> imageAndMat = new Dictionary<ImageResData, Material>();

		internal Dictionary<ImageResData, Stream> imageAndStream = new Dictionary<ImageResData, Stream>();

		internal HelixViewport3D viewport;

		internal bool sthBool;

		internal string currentAction
		{
			get
			{
				return currentActionString;
			}
			set
			{
				currentActionString = value;
				MaybeAlertManager.setAction(currentActionString);
			}
		}

		public bool IsInteractive
		{
			get
			{
				return IsInteractive_Val;
			}
			set
			{
				if (IsInteractive_Val != value)
				{
					IsInteractive_Val = value;
				}
			}
		}

		internal Params @params => this.m_params;

		public _3DView()
		{
			InitializeComponent();
			modelVisual2 = new ModelVisual3D();
			Matrix3D value = Transform3D.Identity.Value;
			value.Scale(new Vector3D(1.0, 1.0, -1.0));
			value.Rotate(new Quaternion(new Vector3D(0.0, 1.0, 0.0), 180.0));
			value.Rotate(new Quaternion(new Vector3D(1.0, 0.0, 0.0), 90.0));
			modelVisual2.Transform = new MatrixTransform3D(value);
			modelVisual1 = MakeLights();
			viewport.ShowCoordinateSystem = true;
			viewport.ShowFrameRate = true;
			viewport.ShowTriangleCountInfo = true;
			camera = viewport.Camera.Clone();
			RadialGradientBrush radialGradientBrush = (RadialGradientBrush)(brush1 = new RadialGradientBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), System.Windows.Media.Color.FromArgb(byte.MaxValue, 150, 200, byte.MaxValue)));
			brush2 = new RadialGradientBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 200, byte.MaxValue, byte.MaxValue), System.Windows.Media.Color.FromArgb(byte.MaxValue, 200, 200, byte.MaxValue));
			((UIElement)viewport).ClipToBounds = false;
			((UIElement)viewport).IsHitTestVisible = true;
			if (material == null)
			{
				material = new MaterialGroup
				{
					Children = 
					{
						(Material)new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(120, 50, 50, byte.MaxValue))),
						(Material)new SpecularMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(70, byte.MaxValue, byte.MaxValue, byte.MaxValue)), 5.0)
					}
				};
				allMaterials = new Material[4];
				allMaterials[0] = material;
				MaterialGroup materialGroup = new MaterialGroup
				{
					Children = 
					{
						(Material)new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(120, 50, byte.MaxValue, 50))),
						(Material)new SpecularMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(70, byte.MaxValue, byte.MaxValue, byte.MaxValue)), 5.0)
					}
				};
				allMaterials[1] = materialGroup;
				materialGroup = new MaterialGroup
				{
					Children = 
					{
						(Material)new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(120, 50, byte.MaxValue, byte.MaxValue))),
						(Material)new SpecularMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(70, byte.MaxValue, byte.MaxValue, byte.MaxValue)), 5.0)
					}
				};
				allMaterials[2] = materialGroup;
				materialGroup = new MaterialGroup
				{
					Children = 
					{
						(Material)new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(120, byte.MaxValue, 50, 50))),
						(Material)new SpecularMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(70, byte.MaxValue, byte.MaxValue, byte.MaxValue)), 5.0)
					}
				};
				allMaterials[3] = materialGroup;
			}
			Clear();
		}

		internal void CreateCam()
		{
			if (cameraBox == null)
			{
				cameraBox = new CameraBox();
			}
			cameraBox.NearPlaneDistance = 0.0;
			cameraBox.FarPlaneDistance = 1000.0;
			cameraBox.Position = camera.Position;
			cameraBox.LookDirection = camera.LookDirection;
			viewport.Camera = (ProjectionCamera)cameraBox.Camera;
			viewport.ResetCamera();
			IsInteractive = true;
		}

		internal void HandleMouseMove(Vector mouseMove)
		{
			double num = WFUtils.IsShiftDown() ? 0.5 : 0.1;
			double num2 = mouseMove.X * num;
			double num3 = mouseMove.Y * num;
			cameraBox.StopAnyTurn();
			if (cameraBox.Speed == 0)
			{
				cameraBox.Rotate(Math3D.UnitZ, 2.0 * num2, point3D);
				cameraBox.Rotate(cameraBox.RightDirection, 2.0 * num3, point3D);
			}
			else if (cameraBox.MovingDirectionIsLocked)
			{
				cameraBox.ChangeHeading(num2);
				cameraBox.ChangePitch(num3);
			}
			else
			{
				cameraBox.ChangeRoll(0.0 - num2);
				cameraBox.ChangePitch(num3);
			}
		}

		internal Point3D Raycast(System.Windows.Point point)
		{
			RayMeshGeometry3DHitTestResult rayMeshGeometry3DHitTestResult = Math3D.HitTest(viewport, point);
			if (rayMeshGeometry3DHitTestResult == null)
			{
				return Math3D.Origin;
			}
			Point3D pointHit = rayMeshGeometry3DHitTestResult.PointHit;
			return Math3D.GetTransformationMatrix(rayMeshGeometry3DHitTestResult.VisualHit).Transform(pointHit);
		}

		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			Focus();
			base.OnMouseDown(e);
			if (IsInteractive && WFUtils.IsCtrlDown())
			{
				point3D = Raycast(e.GetPosition(this));
			}
		}

		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);
			point3D = Math3D.Origin;
			point.X = double.NaN;
		}

		protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
		{
			base.OnMouseLeave(e);
			point3D = Math3D.Origin;
			point.X = double.NaN;
		}

		protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (IsInteractive && e.LeftButton == MouseButtonState.Pressed)
			{
				System.Windows.Point position = e.GetPosition(this);
				if (point.IsValid())
				{
					HandleMouseMove(point - position);
				}
				point = position;
			}
		}

		protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (!IsInteractive)
			{
				return;
			}
			e.Handled = true;
			double num = WFUtils.IsShiftDown() ? 1.0 : 0.2;
			if (WFUtils.IsCtrlDown())
			{
				num *= (WFUtils.IsAltDown() ? 0.1 : 0.5);
				num *= cameraBox.Scale;
				switch (e.Key)
				{
				case Key.Up:
					cameraBox.Move(cameraBox.LookDirection, num);
					break;
				case Key.Down:
					cameraBox.Move(cameraBox.LookDirection, 0.0 - num);
					break;
				case Key.Left:
					cameraBox.Move(cameraBox.LeftDirection, num);
					break;
				case Key.Right:
					cameraBox.Move(cameraBox.LeftDirection, 0.0 - num);
					break;
				case Key.Prior:
					cameraBox.Move(cameraBox.UpDirection, num);
					break;
				case Key.Next:
					cameraBox.Move(cameraBox.UpDirection, 0.0 - num);
					break;
				default:
					e.Handled = false;
					break;
				}
				return;
			}
			switch (e.Key)
			{
			case Key.Up:
				cameraBox.ChangePitch(num);
				break;
			case Key.Down:
				cameraBox.ChangePitch(0.0 - num);
				break;
			case Key.Left:
			case Key.A:
				if (cameraBox.Speed == 0)
				{
					cameraBox.ChangeYaw(num);
				}
				else
				{
					cameraBox.ChangeRoll(0.0 - num);
				}
				break;
			case Key.Right:
			case Key.D:
				if (cameraBox.Speed == 0)
				{
					cameraBox.ChangeYaw(0.0 - num);
				}
				else
				{
					cameraBox.ChangeRoll(num);
				}
				break;
			case Key.Prior:
				cameraBox.ChangeRoll(0.0 - num);
				break;
			case Key.Next:
				cameraBox.ChangeRoll(num);
				break;
			case Key.W:
				cameraBox.Speed++;
				return;
			case Key.S:
				cameraBox.Speed--;
				return;
			case Key.X:
				cameraBox.Speed = 0;
				return;
			case Key.F:
				cameraBox.FlyParallel();
				return;
			case Key.T:
				cameraBox.LookBack();
				return;
			case Key.Space:
				cameraBox.LookAtOrigin();
				return;
			default:
				e.Handled = false;
				return;
			}
			cameraBox.StopAnyTurn();
		}

		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			base.OnMouseWheel(e);
			cameraBox.FieldOfView *= ((e.Delta < 0) ? 1.1 : 0.90909090909090906);
		}

		internal ModelVisual3D MakeLights()
		{
			Model3DGroup model3DGroup = new Model3DGroup();
			model3DGroup.Children.Add(new DirectionalLight(System.Windows.Media.Color.FromRgb(180, 180, 180), new Vector3D(0.0, 1.0, -0.5)));
			model3DGroup.Children.Add(new DirectionalLight(System.Windows.Media.Color.FromRgb(120, 120, 120), new Vector3D(1.0, -1.0, -0.1)));
			model3DGroup.Children.Add(new AmbientLight(System.Windows.Media.Color.FromRgb(100, 100, 100)));
			return new ModelVisual3D
			{
				Content = model3DGroup
			};
		}

		internal void Clear()
		{
			foreach (KeyValuePair<int, Params> item in paramsByIndex)
			{
				item.Value._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A = true;
			}
			paramsByIndex.Clear();
			imageAndStream2.Clear();
			ints.Clear();
			imageAndMat.Clear();
			imageAndBitmap.Clear();
			imageAndStream.Clear();
			makeCurModel();
		}

		internal void makeCurModel()
		{
			viewport.Children.Clear();
			viewport.Children.Add(modelVisual1);
			((System.Windows.Controls.Control)viewport).Background = brush1;
			CreateCamCaller();
		}

		internal void CreateCamCaller()
		{
			CreateCam();
		}

		internal bool TryCreateMaterialSphere(ImageResData matImg)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			try
			{
				makeCurModel();
				SphereVisual3D val = new SphereVisual3D();
				val.Radius = 1.0;
				val.Center = new Point3D(0.0, 0.0, 0.0);
				Material matByData = getMatByData(matImg);
				val.Material = matByData;
				val.BackMaterial = matByData;
				viewport.Children.Add((Visual3D)val);
				CreateCamCaller();
				return true;
			}
			catch (Exception arg)
			{
				ConsoleOver.LogEx(string.Concat(arg));
				return false;
			}
		}

		public bool ShowModel(string obj)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				currentAction = "3DView.ShowModel..";
				makeCurModel();
				modelVisual2.Content = null;
				if (string.IsNullOrEmpty(obj))
				{
					return true;
				}
				ModelImporter val = new ModelImporter();
				double num = 0.0;
				Model3DGroup model3DGroup = val.LoadObj((Stream)new MemoryStream(Encoding.ASCII.GetBytes(obj)), (Dispatcher)null, false);
				if (model3DGroup != null)
				{
					for (int i = 0; i < model3DGroup.Children.Count; i++)
					{
						GeometryModel3D geometryModel3D = (GeometryModel3D)model3DGroup.Children[i];
						num = Math.Max(num, geometryModel3D.Bounds.SizeX);
						num = Math.Max(num, geometryModel3D.Bounds.SizeY);
						num = Math.Max(num, geometryModel3D.Bounds.SizeZ);
						geometryModel3D.Material = allMaterials[i % allMaterials.Length];
						geometryModel3D.BackMaterial = allMaterials[i % allMaterials.Length];
					}
				}
				if (num > 0.0)
				{
					Matrix3D value = Transform3D.Identity.Value;
					value.Scale(new Vector3D(4.0 / num, 4.0 / num, 4.0 / num));
					model3DGroup.Transform = new MatrixTransform3D(value);
				}
				modelVisual2.Content = model3DGroup;
				viewport.Children.Add(modelVisual2);
				CreateCamCaller();
				return true;
			}
			catch (Exception arg)
			{
				ConsoleOver.LogEx(string.Concat(arg));
				return false;
			}
			finally
			{
				currentAction = "3DView.ShowModel - ok";
			}
		}

		internal Model3D TryLoadModel(string path)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			Model3D result = null;
			try
			{
				result = new ModelImporter().Load(path, (Dispatcher)null, false);
				return result;
			}
			catch (Exception _0020)
			{
				ConsoleOver.WriteEx24584756(_0020);
				return result;
			}
		}

		internal int _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A_0020(ManyCodeCls _0020, ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020_000A)
		{
			return ((_0020 != null) ? (_0020.GetHashCode() * 10000) : 0) + ((!ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(_0020_000A, null)) ? _0020_000A.GetHashCode() : 0);
		}

		internal Params GetParams(ManyCodeCls _0020, ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020_000A)
		{
			if (_0020 == null && ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(_0020_000A, null))
			{
				return null;
			}
			Params @params = null;
			int key = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A_0020(_0020, _0020_000A);
			if (!paramsByIndex.ContainsKey(key))
			{
				return null;
			}
			@params = paramsByIndex[key];
			if (this.m_params == @params)
			{
				return @params;
			}
			makeCurModel();
			if (this.m_params != null)
			{
				this.m_params.camera = viewport.Camera;
			}
			if (this.m_params != @params)
			{
				if (@params.camera == null)
				{
					CreateCam();
				}
				viewport.Camera = @params.camera;
				this.m_params = @params;
			}
			if (@params.model?.model != null)
			{
				viewport.Children.Add(@params.model?.model);
			}
			CreateCamCaller();
			return @params;
		}

		internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020(ManyCodeCls _0020, ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020_000A)
		{
			makeCurModel();
			if (_0020 != null || !ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(_0020_000A, null))
			{
				if (_0020 == null && ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020_000A, null))
				{
					_0020 = _0020_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A;
				}
				int key = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A_0020(_0020, _0020_000A);
				Params @params = null;
				if (paramsByIndex.ContainsKey(key))
				{
					@params = paramsByIndex[key];
					@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A = true;
					makeCurModel();
				}
			}
		}

		internal Params _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A(ManyCodeCls _0020, ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020_000A, bool _0020_0020 = false, bool _0020_000A_000A = false)
		{
			if (_0020 == null && ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(_0020_000A, null))
			{
				return null;
			}
			if (_0020 == null && ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020_000A, null))
			{
				_0020 = _0020_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A;
			}
			Params @params = null;
			int key = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A_0020(_0020, _0020_000A);
			if (!paramsByIndex.ContainsKey(key))
			{
				@params = new Params();
				@params.manyCodeCls = _0020;
				@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020 = _0020_000A;
				paramsByIndex[key] = @params;
			}
			else
			{
				@params = paramsByIndex[key];
			}
			this.m_params = @params;
			if (_0020_0020)
			{
				if (@params.model != null)
				{
					@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A = true;
					if (!@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020)
					{
						Thread.Sleep(10);
					}
					if (!@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020)
					{
						Thread.Sleep(50);
					}
					if (!@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020)
					{
						Thread.Sleep(100);
					}
				}
				@params.model = null;
				@params._0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A = false;
				@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020 = false;
				@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A = false;
			}
			@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020 = _0020_000A_000A;
			MakeViewByParams(@params);
			return @params;
		}

		internal void MakeViewByParams(Params @params)
		{
			try
			{
				currentAction = "3DView.MakeScene.. " + @params.manyCodeCls._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020;
				this.m_params = @params;
				ints.Clear();
				try
				{
					makeCurModel();
					if (@params.model == null || @params.model.model == null)
					{
						if (@params.model == null)
						{
							@params.model = new ModelHandler();
						}
						if (@params.model.model == null)
						{
							Matrix3D value = Transform3D.Identity.Value;
							value.Scale(new Vector3D(1.0, 1.0, -1.0));
							value.Rotate(new Quaternion(new Vector3D(0.0, 1.0, 0.0), 180.0));
							value.Rotate(new Quaternion(new Vector3D(1.0, 0.0, 0.0), 90.0));
							@params.model.model = new ModelVisual3D();
							@params.model.model.Transform = new MatrixTransform3D(value);
						}
					}
					viewport.Children.Add(@params.model?.model);
					if (!@params._0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A)
					{
						@params._0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A = true;
						if (ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020(@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020, null))
						{
							_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(@params, @params.model, @params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020, _0020_000A_000A: true);
						}
						else
						{
							foreach (ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A item in @params.manyCodeCls._0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020)
							{
								if (@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
								{
									break;
								}
								_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(@params, @params.model, item, _0020_000A_000A: false);
							}
						}
					}
				}
				finally
				{
					@params._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020 = true;
				}
			}
			catch (Exception arg)
			{
				ConsoleOver.LogEx(string.Concat(arg));
			}
			finally
			{
				currentAction = "3DView.MakeScene.. " + @params.manyCodeCls._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 + " -finish ";
			}
		}

		internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(Params _0020, ModelHandler _0020_000A, ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020_0020, bool _0020_000A_000A)
		{
			try
			{
				if (_0020_0020._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A is _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, _0020_000A, (_0020_0020._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020, _0020_000A_000A);
				}
				else if (_0020_0020._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A is _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020)
				{
					_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, _0020_000A, _0020_0020._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020, _0020_000A_000A);
				}
				else if (_0020_0020._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A == null)
				{
					foreach (ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A item in _0020_0020._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A)
					{
						if (_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
						{
							break;
						}
						_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, _0020_000A, item, _0020_000A_000A: false);
					}
				}
				else
				{
					_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, _0020_000A, _0020_0020._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A, _0020_000A_000A);
				}
			}
			catch (Exception _00202)
			{
				ConsoleOver.WriteEx24584756(_00202);
			}
		}

		internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(Params _0020, ModelHandler _0020_000A, _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 _0020_0020, bool _0020_000A_000A)
		{
			try
			{
				_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020;
				_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202;
				ModelHandler modelHandler;
				if (_0020_0020 != null && !_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A && (_0020_0020.objectType == ClassIDEnum.GameObject || _0020_0020.objectType == ClassIDEnum.TerrainData) && !ints.Contains(_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020.GetHashCode()))
				{
					System.Windows.Forms.Application.DoEvents();
					ints.Add(_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020.GetHashCode());
					currentAction = "3DView.MakeScene.. " + _0020.manyCodeCls._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 + " " + _0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020;
					ImageResData imageResData = _0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020();
					List<ImageResData> list = _0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020();
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 = _0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020();
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202 = _0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020();
					modelHandler = null;
					if (!_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
					{
						float num = 0f;
						float num2 = 0f;
						float num3 = 0f;
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						float num7 = 1f;
						float num8 = 1f;
						float num9 = 1f;
						float num10 = 1f;
						ShaderInfo shaderInfo = _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020?._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;
						if (shaderInfo == null)
						{
							shaderInfo = _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202?._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;
						}
						bool flag = false;
						if (shaderInfo != null)
						{
							num = (float)shaderInfo.GetProp("m_LocalPosition.x");
							num2 = (float)shaderInfo.GetProp("m_LocalPosition.y");
							num3 = (float)shaderInfo.GetProp("m_LocalPosition.z");
							num4 = (float)shaderInfo.GetProp("m_LocalRotation.x");
							num5 = (float)shaderInfo.GetProp("m_LocalRotation.y");
							num6 = (float)shaderInfo.GetProp("m_LocalRotation.z");
							num7 = (float)shaderInfo.GetProp("m_LocalRotation.w");
							num8 = (float)shaderInfo.GetProp("m_LocalScale.x");
							num9 = (float)shaderInfo.GetProp("m_LocalScale.y");
							num10 = (float)shaderInfo.GetProp("m_LocalScale.z");
							if (num != 0f || num2 != 0f || num3 != 0f || num4 != 0f || num5 != 0f || num6 != 0f || num7 != 1f || num8 != 1f || num9 != 1f || num10 != 1f)
							{
								flag = true;
							}
						}
						if (!((imageResData != null) | flag))
						{
							goto IL_03c3;
						}
						modelHandler = new ModelHandler(new ModelVisual3D());
						_0020_000A.model.Children.Add(modelHandler.model);
						if (flag)
						{
							Matrix3D value = Transform3D.Identity.Value;
							value.Scale(new Vector3D(num8, num9, num10));
							value.Rotate(new Quaternion(num4, num5, num6, num7));
							if (!_0020_000A_000A)
							{
								value.Translate(new Vector3D(num, num2, num3));
							}
							modelHandler.model.Transform = new MatrixTransform3D(value);
						}
						if (!(imageResData != null))
						{
							goto IL_03c3;
						}
						if (!_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
						{
							Model3DGroup model3DGroup = MakeModelGroup(imageResData);
							if (model3DGroup != null)
							{
								for (int i = 0; i < model3DGroup.Children.Count; i++)
								{
									Material backMaterial = allMaterials[i % allMaterials.Length];
									if (!_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020 && i < list.Count)
									{
										backMaterial = getMatByData(list[i]);
									}
									GeometryModel3D obj = (GeometryModel3D)model3DGroup.Children[i];
									obj.Material = backMaterial;
									obj.BackMaterial = backMaterial;
								}
								ModelVisual3D modelVisual3D = new ModelVisual3D();
								modelVisual3D.Content = model3DGroup;
								modelHandler.model.Children.Add(modelVisual3D);
							}
							goto IL_03c3;
						}
					}
				}
				goto end_IL_0000;
				IL_03c3:
				if (modelHandler == null)
				{
					modelHandler = _0020_000A;
				}
				if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 != null)
				{
					foreach (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 item in _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020())
					{
						if (_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
						{
							return;
						}
						_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, modelHandler, item, _0020_000A_000A: false);
					}
				}
				if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202 != null)
				{
					foreach (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 item2 in _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020())
					{
						if (_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
						{
							break;
						}
						_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, modelHandler, item2, _0020_000A_000A: false);
					}
				}
				end_IL_0000:;
			}
			catch (Exception arg)
			{
				ConsoleOver.LogEx(string.Concat(arg));
			}
		}

		internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(Params _0020, ModelHandler _0020_000A, _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020 _0020_0020, bool _0020_000A_000A)
		{
			try
			{
				ModelHandler modelHandler;
				if (_0020_0020 != null && !_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
				{
					System.Windows.Forms.Application.DoEvents();
					currentAction = "3DView.MakeScene.. " + _0020.manyCodeCls._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 + " " + _0020_0020._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A;
					IMakeObj makeObj = _0020_0020 as IMakeObj;
					_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A = _0020_0020 as _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A;
					modelHandler = null;
					if (!_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
					{
						bool flag = false;
						if (!((makeObj != null) | flag))
						{
							goto IL_02da;
						}
						modelHandler = new ModelHandler(new ModelVisual3D());
						_0020_000A.model.Children.Add(modelHandler.model);
						if (flag)
						{
							Matrix3D value = Transform3D.Identity.Value;
							if (_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A != null)
							{
								int num = 0;
								value.M11 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M12 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M13 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M14 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M21 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M22 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M23 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M24 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M31 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M32 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M33 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M34 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.OffsetX = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.OffsetY = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.OffsetZ = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
								value.M44 = _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020[num];
								num++;
							}
							modelHandler.model.Transform = new MatrixTransform3D(value);
						}
						if (makeObj == null)
						{
							goto IL_02da;
						}
						if (!_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
						{
							Model3DGroup model3DGroup = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A(makeObj);
							if (model3DGroup != null)
							{
								for (int i = 0; i < model3DGroup.Children.Count; i++)
								{
									Material backMaterial = allMaterials[i % allMaterials.Length];
									GeometryModel3D obj = (GeometryModel3D)model3DGroup.Children[i];
									obj.Material = backMaterial;
									obj.BackMaterial = backMaterial;
								}
								ModelVisual3D modelVisual3D = new ModelVisual3D();
								modelVisual3D.Content = model3DGroup;
								modelHandler.model.Children.Add(modelVisual3D);
							}
							goto IL_02da;
						}
					}
				}
				goto end_IL_0000;
				IL_02da:
				if (modelHandler == null)
				{
					modelHandler = _0020_000A;
				}
				foreach (_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020 item in _0020_0020._0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020)
				{
					if (_0020._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A)
					{
						break;
					}
					_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A(_0020, modelHandler, item, _0020_000A_000A: false);
				}
				end_IL_0000:;
			}
			catch (Exception arg)
			{
				ConsoleOver.LogEx(string.Concat(arg));
			}
		}

		internal Stream _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020(ImageResData _0020, bool _0020_000A = false, bool _0020_0020 = false)
		{
			if (_0020 == null || _0020._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A || _0020._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020 == null)
			{
				return null;
			}
			try
			{
				Bitmap bitmap = null;
				_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 = _0020._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020;
				if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 == null || _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020.objectType != ClassIDEnum.Texture2D)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202 = _0020._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020;
					if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202 == null || _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00202.objectType != ClassIDEnum.Cubemap)
					{
						goto IL_006b;
					}
				}
				bitmap = ((TextureManager)_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A)._0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A()?.Bitmap;
				goto IL_006b;
				IL_006b:
				_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00203 = _0020._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020;
				if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00203 != null && _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_00203.objectType == ClassIDEnum.Sprite)
				{
					bitmap = ((ImageInfo)_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A)._0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A()?.Bitmap;
				}
				if (bitmap == null)
				{
					return null;
				}
				if (_0020_000A && _0020_0020)
				{
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
				}
				else if (_0020_000A)
				{
					bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
				}
				else if (_0020_0020)
				{
					bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
				}
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				bitmap.Dispose();
				memoryStream.Position = 0L;
				return memoryStream;
			}
			catch (Exception _00202)
			{
				ConsoleOver.WriteEx24584756(_00202);
				return null;
			}
		}

		internal BitmapImage MakeBitmapImage(ImageResData img, bool bool1 = false, bool bool2 = false)
		{
			if (img == null || img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
			{
				return null;
			}
			if (imageAndBitmap.ContainsKey(img))
			{
				currentAction = "MakeBitmapImage cache: " + img + "  " + img?._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
				return imageAndBitmap[img];
			}
			try
			{
				lock (lockObject)
				{
					if (imageAndBitmap.ContainsKey(img))
					{
						return imageAndBitmap[img];
					}
					object[] obj = new object[6]
					{
						"3DView.MakeScene.. ",
						null,
						null,
						null,
						null,
						null
					};
					Params obj2 = this.m_params;
					obj[1] = ((obj2 == null) ? null : obj2.manyCodeCls?._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020);
					obj[2] = " Make image: ";
					obj[3] = img;
					obj[4] = "  ";
					obj[5] = img?._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
					currentAction = string.Concat(obj);
					Stream stream = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020(img, bool1, bool2);
					if (stream == null)
					{
						ConsoleManager.WriteInfo("Not find image: " + img);
						return null;
					}
					BitmapImage bitmapImage = new BitmapImage();
					bitmapImage.BeginInit();
					bitmapImage.StreamSource = stream;
					bitmapImage.EndInit();
					imageAndBitmap[img] = bitmapImage;
					return bitmapImage;
				}
			}
			catch (Exception _0020)
			{
				ConsoleOver.WriteEx24584756(_0020);
				return null;
			}
		}

		internal Material getMatByData(ImageResData img)
		{
			if (img == null || img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A || img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020 == null)
			{
				return material;
			}
			currentAction = "3DView.MakeScene.. " + ((this.m_params == null || this.m_params.manyCodeCls == null) ? null : this.m_params.manyCodeCls._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020) + " Make material: " + img + " " + ((img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020 == null) ? null : img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020);
			try
			{
				if (img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020 != null && img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020.objectType == ClassIDEnum.Material)
				{
					ShaderInfo shaderInfo = img._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A;
					MaterialGroup materialGroup = new MaterialGroup();
					string text = string.Concat(shaderInfo.GetProp("m_ShaderKeywords"));
					text.Contains("_ALPHABLEND_ON");
					text.Contains("_ALPHAPREMULTIPLY_ON");
					byte b = 100;
					byte b2 = byte.MaxValue;
					byte b3 = 200;
					byte a = 200;
					if (shaderInfo.GetProp("m_SavedProperties.m_Colors._Color") != null)
					{
						try
						{
							b = (byte)((float)shaderInfo.GetProp("m_SavedProperties.m_Colors._Color.r") * 255f);
							b2 = (byte)((float)shaderInfo.GetProp("m_SavedProperties.m_Colors._Color.g") * 255f);
							b3 = (byte)((float)shaderInfo.GetProp("m_SavedProperties.m_Colors._Color.b") * 255f);
							a = (byte)((float)shaderInfo.GetProp("m_SavedProperties.m_Colors._Color.a") * 255f);
							if (b != byte.MaxValue || b2 != byte.MaxValue || b3 != byte.MaxValue)
							{
								DiffuseMaterial value = new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(a, b, b2, b3)));
								materialGroup.Children.Add(value);
							}
						}
						catch (Exception arg)
						{
							ConsoleOver.LogEx(string.Concat(arg));
						}
					}
					string text2 = null;
					text2 = "m_SavedProperties.m_TexEnvs._MainTex";
					if (shaderInfo.GetProp(text2 + ".m_Texture") == null || (shaderInfo.GetProp(text2 + ".m_Texture") as ImageResData)._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
					{
						text2 = "m_SavedProperties.m_TexEnvs._OcclusionMap";
					}
					if (shaderInfo.GetProp(text2 + ".m_Texture") == null || (shaderInfo.GetProp(text2 + ".m_Texture") as ImageResData)._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
					{
						text2 = "m_SavedProperties.m_TexEnvs._BumpMap";
					}
					if (shaderInfo.GetProp(text2) != null)
					{
						ImageResData imageResData = shaderInfo.GetProp(text2 + ".m_Texture") as ImageResData;
						if (imageResData != null && !imageResData._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
						{
							float num = (float)shaderInfo.GetProp(text2 + ".m_Scale.x");
							float num2 = (float)shaderInfo.GetProp(text2 + ".m_Scale.y");
							float num3 = (float)shaderInfo.GetProp(text2 + ".m_Offset.x");
							float num4 = (float)shaderInfo.GetProp(text2 + ".m_Offset.y");
							BitmapImage bitmapImage = MakeBitmapImage(imageResData);
							if (bitmapImage != null)
							{
								ImageBrush imageBrush = new ImageBrush(bitmapImage);
								if (materialGroup.Children.Count > 0)
								{
									imageBrush.Opacity = 0.7;
								}
								imageBrush.TileMode = TileMode.Tile;
								imageBrush.Viewport = new Rect(num3, num4, 1f / num, 1f / num2);
								DiffuseMaterial value2 = new DiffuseMaterial(imageBrush);
								materialGroup.Children.Add(value2);
							}
						}
					}
					text2 = "m_SavedProperties.m_TexEnvs._DetailAlbedoMap";
					if (shaderInfo.GetProp(text2) != null)
					{
						ImageResData imageResData2 = shaderInfo.GetProp(text2 + ".m_Texture") as ImageResData;
						float num5 = (float)shaderInfo.GetProp(text2 + ".m_Scale.x");
						float num6 = (float)shaderInfo.GetProp(text2 + ".m_Scale.y");
						float num7 = (float)shaderInfo.GetProp(text2 + ".m_Offset.x");
						float num8 = (float)shaderInfo.GetProp(text2 + ".m_Offset.y");
						if (imageResData2 != null && !imageResData2._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
						{
							BitmapImage bitmapImage2 = MakeBitmapImage(imageResData2);
							if (bitmapImage2 != null)
							{
								DiffuseMaterial value3 = new DiffuseMaterial(new ImageBrush(bitmapImage2)
								{
									Opacity = 0.5,
									TileMode = TileMode.Tile,
									AlignmentX = AlignmentX.Left,
									AlignmentY = AlignmentY.Top,
									Viewport = new Rect(num7, num8, 1f / num5, 1f / num6)
								});
								materialGroup.Children.Add(value3);
							}
						}
					}
					text2 = "m_SavedProperties.m_TexEnvs._EmissionMap";
					if (shaderInfo.GetProp(text2) != null)
					{
						ImageResData imageResData3 = shaderInfo.GetProp(text2 + ".m_Texture") as ImageResData;
						if (imageResData3 != null && !imageResData3._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
						{
							float num9 = (float)shaderInfo.GetProp(text2 + ".m_Scale.x");
							float num10 = (float)shaderInfo.GetProp(text2 + ".m_Scale.y");
							float num11 = (float)shaderInfo.GetProp(text2 + ".m_Offset.x");
							float num12 = (float)shaderInfo.GetProp(text2 + ".m_Offset.y");
							BitmapImage bitmapImage3 = MakeBitmapImage(imageResData3);
							if (bitmapImage3 != null)
							{
								ImageBrush imageBrush2 = new ImageBrush(bitmapImage3);
								imageBrush2.Opacity = 0.5;
								imageBrush2.TileMode = TileMode.Tile;
								imageBrush2.AlignmentX = AlignmentX.Left;
								imageBrush2.AlignmentY = AlignmentY.Top;
								imageBrush2.Viewport = new Rect(num11, num12, 1f / num9, 1f / num10);
								EmissiveMaterial emissiveMaterial = new EmissiveMaterial(imageBrush2);
								emissiveMaterial.Brush = imageBrush2;
								materialGroup.Children.Add(emissiveMaterial);
							}
						}
					}
					if (materialGroup.Children.Count == 0)
					{
						DiffuseMaterial value4 = new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(a, b, b2, b3)));
						materialGroup.Children.Add(value4);
					}
					imageAndMat[img] = materialGroup;
					return materialGroup;
				}
				if (img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020 != null && img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020.objectType == ClassIDEnum.TerrainData)
				{
					ShaderInfo shaderInfo2 = img._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A;
					MaterialGroup materialGroup2 = new MaterialGroup();
					int num17 = (int)shaderInfo2.GetProp("m_Heightmap.m_Width");
					int num18 = (int)shaderInfo2.GetProp("m_Heightmap.m_Height");
					Vector3 vector = new Vector3((float)shaderInfo2.GetProp("m_Heightmap.m_Scale.x"), (float)shaderInfo2.GetProp("m_Heightmap.m_Scale.y"), (float)shaderInfo2.GetProp("m_Heightmap.m_Scale.z"));
					object[] array = (object[])shaderInfo2._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020("m_SplatDatabase.m_Splats");
					for (int i = 0; i < array.Length; i++)
					{
						CultureFormatter.SomeItem someItem = (CultureFormatter.SomeItem)array[i];
						ImageResData imageResData4 = someItem.SetProp("texture") as ImageResData;
						if (!(imageResData4 == null) && !imageResData4._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
						{
							someItem.SetProp("normalMap");
							if (imageResData4 != null && !imageResData4._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
							{
								float num13 = (float)someItem.SetProp("tileSize.x") / vector.x;
								float num14 = (float)someItem.SetProp("tileSize.y") / vector.z;
								float num15 = (float)someItem.SetProp("tileOffset.x") / vector.x;
								float num16 = (float)someItem.SetProp("tileOffset.y") / vector.z;
								BitmapImage bitmapImage4 = MakeBitmapImage(imageResData4);
								if (bitmapImage4 != null)
								{
									ImageBrush imageBrush3 = new ImageBrush(bitmapImage4);
									imageBrush3.Opacity = 0.7;
									if (materialGroup2.Children.Count > 1)
									{
										imageBrush3.Opacity = 0.3;
									}
									imageBrush3.TileMode = TileMode.Tile;
									imageBrush3.AlignmentX = AlignmentX.Left;
									imageBrush3.AlignmentY = AlignmentY.Top;
									imageBrush3.Viewport = new Rect(num15, num16, 1f / num13, 1f / num14);
									DiffuseMaterial value5 = new DiffuseMaterial(imageBrush3);
									materialGroup2.Children.Add(value5);
									break;
								}
							}
						}
					}
					if (materialGroup2.Children.Count == 0)
					{
						imageAndMat[img] = material;
						return material;
					}
					imageAndMat[img] = materialGroup2;
					return materialGroup2;
				}
				if (img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020 != null && img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020.objectType == ClassIDEnum.Sprite)
				{
					ShaderInfo shaderInfo3 = img._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A;
					MaterialGroup materialGroup3 = new MaterialGroup();
					BitmapImage bitmapImage5 = MakeBitmapImage(img, bool1: true);
					if (bitmapImage5 != null)
					{
						DiffuseMaterial value6 = new DiffuseMaterial(new ImageBrush(bitmapImage5)
						{
							TileMode = TileMode.None,
							AlignmentX = AlignmentX.Left,
							AlignmentY = AlignmentY.Top,
							Viewport = new Rect(0.0, 0.0, 1.0, 1.0)
						});
						materialGroup3.Children.Add(value6);
					}
					if (materialGroup3.Children.Count == 0)
					{
						imageAndMat[img] = material;
						return material;
					}
					imageAndMat[img] = materialGroup3;
					return materialGroup3;
				}
				imageAndMat[img] = material;
				return material;
			}
			catch (Exception arg2)
			{
				ConsoleOver.LogEx(string.Concat(arg2));
			}
			return material;
		}

		internal Model3DGroup MakeModelGroup(ImageResData img)
		{
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				Stream stream = null;
				if (imageAndStream.ContainsKey(img))
				{
					stream = imageAndStream[img];
					if (stream == null)
					{
						return null;
					}
				}
				object[] obj = new object[4]
				{
					"3DView.MakeScene.. ",
					null,
					null,
					null
				};
				Params obj2 = this.m_params;
				obj[1] = ((obj2 == null) ? null : obj2.manyCodeCls?._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020);
				obj[2] = " Make mesh: ";
				obj[3] = img;
				currentAction = string.Concat(obj);
				if (stream == null)
				{
					IMakeObj makeObj = img._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020?._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A as IMakeObj;
					if (makeObj != null)
					{
						string text = makeObj.MakeMeshAsObj();
						if (text != null)
						{
							stream = new CustomStream(new MemoryStream(Encoding.UTF8.GetBytes(text ?? "")));
						}
					}
					imageAndStream[img] = stream;
				}
				if (stream == null)
				{
					return null;
				}
				ModelImporter val = new ModelImporter();
				stream.Position = 0L;
				return val.LoadObj(stream, (Dispatcher)null, false);
			}
			catch (Exception arg)
			{
				imageAndStream[img] = null;
				ConsoleOver.LogEx(string.Concat(arg));
				return null;
			}
		}

		internal Model3DGroup _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A(IMakeObj _0020)
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				Stream stream = null;
				Params obj = this.m_params;
				currentAction = "3DView.MakeScene.. " + ((obj == null) ? null : obj.manyCodeCls?._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020) + " Make mesh: ";
				if (_0020 != null)
				{
					string text = _0020.MakeMeshAsObj();
					if (text != null)
					{
						stream = new CustomStream(new MemoryStream(Encoding.UTF8.GetBytes(text ?? "")));
					}
				}
				if (stream == null)
				{
					return null;
				}
				ModelImporter val = new ModelImporter();
				stream.Position = 0L;
				return val.LoadObj(stream, (Dispatcher)null, false);
			}
			catch (Exception arg)
			{
				ConsoleOver.LogEx(string.Concat(arg));
				return null;
			}
		}

		public SphereVisual3D addSphere(double x, double z, double y)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			SphereVisual3D val = new SphereVisual3D();
			val.Radius = 0.25;
			val.Center = new Point3D(x, y, z);
			DiffuseMaterial backMaterial = new DiffuseMaterial(new SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 100, byte.MaxValue, 200)));
			val.Material = (Material)backMaterial;
			val.BackMaterial = (Material)backMaterial;
			return val;
		}

		internal static void MakeActionThread(Action action)
		{
			ThreadPool.QueueUserWorkItem(CallAction, action);
		}

		internal static void CallAction(object action)
		{
			try
			{
				((Action)action)();
			}
			catch (Exception _0020)
			{
				ConsoleManager.WriteEx9847(_0020);
			}
		}

		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!sthBool)
			{
				sthBool = true;
				Uri resourceLocator = new Uri("/DevXUnityUnpackerTools;component/_wpf/3dview.xaml", UriKind.Relative);
				System.Windows.Application.LoadComponent(this, resourceLocator);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			if (connectionId == 1)
			{
				viewport = (HelixViewport3D)target;
			}
			else
			{
				sthBool = true;
			}
		}
	}
}

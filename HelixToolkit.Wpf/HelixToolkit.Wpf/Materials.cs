using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class Materials
{
	private static readonly Material BlackMaterial = MaterialHelper.CreateMaterial(Brushes.Black);

	private static readonly Material DarkGrayMaterial = MaterialHelper.CreateMaterial(Brushes.DarkGray);

	private static readonly Material GrayMaterial = MaterialHelper.CreateMaterial(Brushes.Gray);

	private static readonly Material LightGrayMaterial = MaterialHelper.CreateMaterial(Brushes.LightGray);

	private static readonly Material WhiteMaterial = MaterialHelper.CreateMaterial(Brushes.White);

	private static readonly Material HueMaterial = MaterialHelper.CreateMaterial(BrushHelper.CreateHsvBrush());

	private static readonly Material RainbowMaterial = MaterialHelper.CreateMaterial(BrushHelper.CreateRainbowBrush());

	private static readonly Material RedMaterial = MaterialHelper.CreateMaterial(Brushes.Red);

	private static readonly Material OrangeMaterial = MaterialHelper.CreateMaterial(Brushes.Orange);

	private static readonly Material YellowMaterial = MaterialHelper.CreateMaterial(Brushes.Yellow);

	private static readonly Material GreenMaterial = MaterialHelper.CreateMaterial(Brushes.Green);

	private static readonly Material BlueMaterial = MaterialHelper.CreateMaterial(Brushes.Blue);

	private static readonly Material IndigoMaterial = MaterialHelper.CreateMaterial(Brushes.Indigo);

	private static readonly Material VioletMaterial = MaterialHelper.CreateMaterial(Brushes.Violet);

	private static readonly Material BrownMaterial = MaterialHelper.CreateMaterial(Brushes.Brown);

	private static readonly Material GoldMaterial = MaterialHelper.CreateMaterial(Brushes.Gold);

	public static Material Black => BlackMaterial;

	public static Material DarkGray => DarkGrayMaterial;

	public static Material Gray => GrayMaterial;

	public static Material LightGray => LightGrayMaterial;

	public static Material White => WhiteMaterial;

	public static Material Hue => HueMaterial;

	public static Material Rainbow => RainbowMaterial;

	public static Material Red => RedMaterial;

	public static Material Orange => OrangeMaterial;

	public static Material Yellow => YellowMaterial;

	public static Material Green => GreenMaterial;

	public static Material Blue => BlueMaterial;

	public static Material Indigo => IndigoMaterial;

	public static Material Violet => VioletMaterial;

	public static Material Brown => BrownMaterial;

	public static Material Gold => GoldMaterial;
}

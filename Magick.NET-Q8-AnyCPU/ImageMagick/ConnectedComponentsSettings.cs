namespace ImageMagick;

public sealed class ConnectedComponentsSettings
{
	public double? AreaThreshold { get; set; }

	public int Connectivity { get; set; }

	public bool MeanColor { get; set; }
}

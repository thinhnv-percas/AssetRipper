namespace ImageMagick;

public sealed class MorphologySettings
{
	public Channels Channels { get; set; }

	public Percentage? ConvolveBias { get; set; }

	public MagickGeometry ConvolveScale { get; set; }

	public int Iterations { get; set; }

	public Kernel Kernel { get; set; }

	public string KernelArguments { get; set; }

	public MorphologyMethod Method { get; set; }

	public string UserKernel { get; set; }

	public MorphologySettings()
	{
		Channels = Channels.Composite;
		Iterations = 1;
		KernelArguments = string.Empty;
	}
}

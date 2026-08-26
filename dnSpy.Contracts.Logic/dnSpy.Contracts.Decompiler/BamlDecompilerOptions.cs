namespace dnSpy.Contracts.Decompiler;

public sealed class BamlDecompilerOptions
{
	public string InternalClassModifier { get; set; }

	public static BamlDecompilerOptions Create(IDecompiler decompiler)
	{
		if (decompiler.GenericGuid == DecompilerConstants.LANGUAGE_VISUALBASIC)
		{
			return CreateVisualBasic();
		}
		return CreateCSharp();
	}

	public static BamlDecompilerOptions CreateCSharp()
	{
		return new BamlDecompilerOptions
		{
			InternalClassModifier = "internal"
		};
	}

	public static BamlDecompilerOptions CreateVisualBasic()
	{
		return new BamlDecompilerOptions
		{
			InternalClassModifier = "Friend"
		};
	}
}

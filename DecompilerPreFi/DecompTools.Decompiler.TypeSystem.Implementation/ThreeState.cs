namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal static class ThreeState
{
	public const byte Unknown = 0;

	public const byte False = 1;

	public const byte True = 2;

	public static byte From(bool value)
	{
		return (byte)((!value) ? 1 : 2);
	}
}

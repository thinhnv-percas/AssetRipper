namespace dnlib.DotNet.Pdb;

internal static class PdbUtils
{
	public static bool IsEndInclusive(PdbFileKind pdbFileKind, Compiler compiler)
	{
		return pdbFileKind == PdbFileKind.WindowsPDB && compiler == Compiler.VisualBasic;
	}
}

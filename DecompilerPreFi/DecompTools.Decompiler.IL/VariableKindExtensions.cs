namespace DecompTools.Decompiler.IL;

internal static class VariableKindExtensions
{
	public static bool IsLocal(this VariableKind kind)
	{
		switch (kind)
		{
		case VariableKind.Local:
		case VariableKind.PinnedLocal:
		case VariableKind.UsingLocal:
		case VariableKind.ForeachLocal:
		case VariableKind.ExceptionLocal:
		case VariableKind.DisplayClassLocal:
			return true;
		default:
			return false;
		}
	}
}

using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class FieldDefComparer : MemberRefComparer<FieldDef>
{
	public static readonly FieldDefComparer Instance = new FieldDefComparer();
}

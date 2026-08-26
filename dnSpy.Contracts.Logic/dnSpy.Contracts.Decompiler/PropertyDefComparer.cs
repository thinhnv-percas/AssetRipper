using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class PropertyDefComparer : MemberRefComparer<PropertyDef>
{
	public static readonly PropertyDefComparer Instance = new PropertyDefComparer();
}

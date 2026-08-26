using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class TypeDefComparer : MemberRefComparer<TypeDef>
{
	public static readonly TypeDefComparer Instance = new TypeDefComparer();
}

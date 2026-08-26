using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class EventDefComparer : MemberRefComparer<EventDef>
{
	public static readonly EventDefComparer Instance = new EventDefComparer();
}

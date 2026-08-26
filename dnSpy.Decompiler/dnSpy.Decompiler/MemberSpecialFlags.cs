using System;

namespace dnSpy.Decompiler;

[Flags]
internal enum MemberSpecialFlags
{
	None = 0,
	Extension = 1,
	Awaitable = 2
}

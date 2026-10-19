using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace Utils.UncoInput
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x2000005")]
	public struct UventInputSystemDisabled : IEvent
	{
	}
}

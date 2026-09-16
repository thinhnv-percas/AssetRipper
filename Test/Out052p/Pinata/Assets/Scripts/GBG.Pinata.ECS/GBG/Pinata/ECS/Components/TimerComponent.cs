using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;

namespace GBG.Pinata.ECS.Components
{
	[StructLayout((LayoutKind)0, Size = 4)]
	[Token(Token = "0x2000084")]
	public struct TimerComponent : IComponent
	{
		[Token(Token = "0x400016D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float timer;
	}
}

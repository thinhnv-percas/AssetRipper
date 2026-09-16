using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;

namespace GBG.Pinata.ECS.Components
{
	[StructLayout((LayoutKind)0, Size = 12)]
	[Token(Token = "0x200007D")]
	public struct AttackComponent : IComponent
	{
		[Token(Token = "0x400014F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float LastTime;

		[Token(Token = "0x4000150")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public bool InMenu;

		[Token(Token = "0x4000151")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int HandSwitcher;
	}
}

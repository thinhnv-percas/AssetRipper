using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;

namespace GBG.Pinata.ECS.Components
{
	[StructLayout((LayoutKind)0, Size = 8)]
	[Token(Token = "0x2000083")]
	public struct HealthComponent : IComponent
	{
		[Token(Token = "0x400016B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int MaxHealth;

		[Token(Token = "0x400016C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int Health;
	}
}

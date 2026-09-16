using Cpp2ILInjected;
using UnityEngine.UI.Collections;

namespace UnityEngine.UI
{
	[Token(Token = "0x200000C")]
	public class ClipperRegistry
	{
		[Token(Token = "0x400002D")]
		private static ClipperRegistry s_Instance;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x10")]
		private readonly IndexedSet<IClipper> m_Clippers;

		[Token(Token = "0x17000012")]
		public static ClipperRegistry instance
		{
			[Token(Token = "0x600004C")]
			[Address(RVA = "0x16C1FAC", Offset = "0x16C1FAC", Length = "0x74")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x16C333C", Offset = "0x16C333C", Length = "0x7C")]
		protected ClipperRegistry()
		{
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x16C2020", Offset = "0x16C2020", Length = "0x10C")]
		public void Cull()
		{
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x16C33B8", Offset = "0x16C33B8", Length = "0x70")]
		public static void Register(IClipper c)
		{
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x16C3428", Offset = "0x16C3428", Length = "0x5C")]
		public static void Unregister(IClipper c)
		{
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x16C3484", Offset = "0x16C3484", Length = "0x5C")]
		public static void Disable(IClipper c)
		{
		}
	}
}

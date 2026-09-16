using Cpp2ILInjected;
using UnityEngine.UI.Collections;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000008")]
	public class ClipperRegistry
	{
		[Token(Token = "0x4000020")]
		private static ClipperRegistry s_Instance;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x10")]
		private readonly IndexedSet<IClipper> m_Clippers;

		[Token(Token = "0x17000011")]
		public static ClipperRegistry instance
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0xC4E3B0", Offset = "0xC4E3B0", Length = "0x7C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0xC4EF64", Offset = "0xC4EF64", Length = "0x70")]
		protected ClipperRegistry()
		{
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0xC4E42C", Offset = "0xC4E42C", Length = "0x118")]
		public void Cull()
		{
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0xC4EFD4", Offset = "0xC4EFD4", Length = "0x74")]
		public static void Register(IClipper c)
		{
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0xC4F048", Offset = "0xC4F048", Length = "0x64")]
		public static void Unregister(IClipper c)
		{
		}
	}
}

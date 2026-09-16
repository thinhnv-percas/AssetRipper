using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.UI.Collections;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000013")]
	public class GraphicRegistry
	{
		[Token(Token = "0x4000066")]
		private static GraphicRegistry s_Instance;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x10")]
		private readonly Dictionary<Canvas, IndexedSet<Graphic>> m_Graphics;

		[Token(Token = "0x4000068")]
		private static readonly List<Graphic> s_EmptyList;

		[Token(Token = "0x1700003E")]
		public static GraphicRegistry instance
		{
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0xF49B24", Offset = "0xF49B24", Length = "0xC0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xF49A04", Offset = "0xF49A04", Length = "0x120")]
		protected GraphicRegistry()
		{
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xF45C14", Offset = "0xF45C14", Length = "0x184")]
		public static void RegisterGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0xF458AC", Offset = "0xF458AC", Length = "0x148")]
		public static void UnregisterGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0xF49210", Offset = "0xF49210", Length = "0xC8")]
		public static IList<Graphic> GetGraphicsForCanvas(Canvas canvas)
		{
			return null;
		}
	}
}

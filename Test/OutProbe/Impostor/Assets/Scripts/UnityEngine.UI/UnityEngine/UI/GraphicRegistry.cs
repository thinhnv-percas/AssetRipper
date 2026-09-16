using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.UI.Collections;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000022")]
	public class GraphicRegistry
	{
		[Token(Token = "0x4000092")]
		private static GraphicRegistry s_Instance;

		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x10")]
		private readonly Dictionary<Canvas, IndexedSet<Graphic>> m_Graphics;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x18")]
		private readonly Dictionary<Canvas, IndexedSet<Graphic>> m_RaycastableGraphics;

		[Token(Token = "0x4000095")]
		private static readonly List<Graphic> s_EmptyList;

		[Token(Token = "0x1700004A")]
		public static GraphicRegistry instance
		{
			[Token(Token = "0x6000132")]
			[Address(RVA = "0x16D0740", Offset = "0x16D0740", Length = "0xA0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x16D0598", Offset = "0x16D0598", Length = "0x1A8")]
		protected GraphicRegistry()
		{
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0x16CC8C0", Offset = "0x16CC8C0", Length = "0x1EC")]
		public static void RegisterGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x16CBD74", Offset = "0x16CBD74", Length = "0x1EC")]
		public static void RegisterRaycastGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x16CC4F8", Offset = "0x16CC4F8", Length = "0x1A4")]
		public static void UnregisterGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x16CBBF8", Offset = "0x16CBBF8", Length = "0x17C")]
		public static void UnregisterRaycastGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x16CD158", Offset = "0x16CD158", Length = "0x180")]
		public static void DisableGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x16D07E0", Offset = "0x16D07E0", Length = "0x180")]
		public static void DisableRaycastGraphicForCanvas(Canvas c, Graphic graphic)
		{
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x16D0960", Offset = "0x16D0960", Length = "0xBC")]
		public static IList<Graphic> GetGraphicsForCanvas(Canvas canvas)
		{
			return null;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x16CFD74", Offset = "0x16CFD74", Length = "0xBC")]
		public static IList<Graphic> GetRaycastableGraphicsForCanvas(Canvas canvas)
		{
			return null;
		}
	}
}

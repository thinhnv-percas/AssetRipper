using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x200005C")]
	public class TMP_UpdateRegistry
	{
		[Token(Token = "0x40003FD")]
		private static TMP_UpdateRegistry s_Instance;

		[Token(Token = "0x40003FE")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<ICanvasElement> m_LayoutRebuildQueue;

		[Token(Token = "0x40003FF")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<int, int> m_LayoutQueueLookup;

		[Token(Token = "0x4000400")]
		[FieldOffset(Offset = "0x20")]
		private readonly List<ICanvasElement> m_GraphicRebuildQueue;

		[Token(Token = "0x4000401")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary<int, int> m_GraphicQueueLookup;

		[Token(Token = "0x1700013C")]
		public static TMP_UpdateRegistry instance
		{
			[Token(Token = "0x600050E")]
			[Address(RVA = "0xC8F5D4", Offset = "0xC8F5D4", Length = "0x7C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600050F")]
		[Address(RVA = "0xC8F650", Offset = "0xC8F650", Length = "0x110")]
		protected TMP_UpdateRegistry()
		{
		}

		[Token(Token = "0x6000510")]
		[Address(RVA = "0xC8F760", Offset = "0xC8F760", Length = "0x2C")]
		public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000511")]
		[Address(RVA = "0xC8F78C", Offset = "0xC8F78C", Length = "0x108")]
		private bool InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x6000512")]
		[Address(RVA = "0xC8F894", Offset = "0xC8F894", Length = "0x2C")]
		public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000513")]
		[Address(RVA = "0xC8F8C0", Offset = "0xC8F8C0", Length = "0x108")]
		private bool InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x6000514")]
		[Address(RVA = "0xC8F9C8", Offset = "0xC8F9C8", Length = "0x244")]
		private void PerformUpdateForCanvasRendererObjects()
		{
		}

		[Token(Token = "0x6000515")]
		[Address(RVA = "0xC8FC0C", Offset = "0xC8FC0C", Length = "0x6C")]
		private void PerformUpdateForMeshRendererObjects()
		{
		}

		[Token(Token = "0x6000516")]
		[Address(RVA = "0xC8FC78", Offset = "0xC8FC78", Length = "0x3C")]
		public static void UnRegisterCanvasElementForRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000517")]
		[Address(RVA = "0xC8FCB4", Offset = "0xC8FCB4", Length = "0xD8")]
		private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000518")]
		[Address(RVA = "0xC8FD8C", Offset = "0xC8FD8C", Length = "0x1C8")]
		private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}
	}
}

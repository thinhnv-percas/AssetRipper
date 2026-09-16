using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x20000A6")]
	public class TMP_UpdateRegistry
	{
		[Token(Token = "0x4000608")]
		private static TMP_UpdateRegistry s_Instance;

		[Token(Token = "0x4000609")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<ICanvasElement> m_LayoutRebuildQueue;

		[Token(Token = "0x400060A")]
		[FieldOffset(Offset = "0x18")]
		private HashSet<int> m_LayoutQueueLookup;

		[Token(Token = "0x400060B")]
		[FieldOffset(Offset = "0x20")]
		private readonly List<ICanvasElement> m_GraphicRebuildQueue;

		[Token(Token = "0x400060C")]
		[FieldOffset(Offset = "0x28")]
		private HashSet<int> m_GraphicQueueLookup;

		[Token(Token = "0x17000172")]
		public static TMP_UpdateRegistry instance
		{
			[Token(Token = "0x6000646")]
			[Address(RVA = "0x16154E8", Offset = "0x16154E8", Length = "0x74")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000647")]
		[Address(RVA = "0x161555C", Offset = "0x161555C", Length = "0x14C")]
		protected TMP_UpdateRegistry()
		{
		}

		[Token(Token = "0x6000648")]
		[Address(RVA = "0x16156A8", Offset = "0x16156A8", Length = "0x20")]
		public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000649")]
		[Address(RVA = "0x16156C8", Offset = "0x16156C8", Length = "0x158")]
		private bool InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x600064A")]
		[Address(RVA = "0x1615820", Offset = "0x1615820", Length = "0x20")]
		public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x600064B")]
		[Address(RVA = "0x1615840", Offset = "0x1615840", Length = "0x158")]
		private bool InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x600064C")]
		[Address(RVA = "0x1615998", Offset = "0x1615998", Length = "0x25C")]
		private void PerformUpdateForCanvasRendererObjects()
		{
		}

		[Token(Token = "0x600064D")]
		[Address(RVA = "0x1615BF4", Offset = "0x1615BF4", Length = "0x68")]
		private void PerformUpdateForMeshRendererObjects()
		{
		}

		[Token(Token = "0x600064E")]
		[Address(RVA = "0x1615C5C", Offset = "0x1615C5C", Length = "0x30")]
		public static void UnRegisterCanvasElementForRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x600064F")]
		[Address(RVA = "0x1615C8C", Offset = "0x1615C8C", Length = "0xDC")]
		private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000650")]
		[Address(RVA = "0x1615D68", Offset = "0x1615D68", Length = "0xDC")]
		private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}
	}
}

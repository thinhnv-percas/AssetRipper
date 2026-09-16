using System;
using Cpp2ILInjected;
using UnityEngine.UI.Collections;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000006")]
	public class CanvasUpdateRegistry
	{
		[Token(Token = "0x4000013")]
		private static CanvasUpdateRegistry s_Instance;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x10")]
		private bool m_PerformingLayoutUpdate;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x11")]
		private bool m_PerformingGraphicUpdate;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x18")]
		private readonly IndexedSet<ICanvasElement> m_LayoutRebuildQueue;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x20")]
		private readonly IndexedSet<ICanvasElement> m_GraphicRebuildQueue;

		[Token(Token = "0x4000018")]
		private static readonly Comparison<ICanvasElement> s_SortLayoutFunction;

		[Token(Token = "0x17000008")]
		public static CanvasUpdateRegistry instance
		{
			[Token(Token = "0x6000019")]
			[Address(RVA = "0xC4D7C4", Offset = "0xC4D7C4", Length = "0xC0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0xC4D6FC", Offset = "0xC4D6FC", Length = "0xC8")]
		protected CanvasUpdateRegistry()
		{
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0xC4D884", Offset = "0xC4D884", Length = "0xE0")]
		private bool ObjectValidForUpdate(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0xC4D964", Offset = "0xC4D964", Length = "0x2FC")]
		private void CleanInvalidItems()
		{
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0xC4DC60", Offset = "0xC4DC60", Length = "0x750")]
		private void PerformUpdate()
		{
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0xC4E544", Offset = "0xC4E544", Length = "0xE0")]
		private static int ParentCount(Transform child)
		{
			return 0;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0xC4E624", Offset = "0xC4E624", Length = "0x170")]
		private static int SortLayoutList(ICanvasElement x, ICanvasElement y)
		{
			return 0;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0xC4E794", Offset = "0xC4E794", Length = "0x70")]
		public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0xC4E8A0", Offset = "0xC4E8A0", Length = "0x70")]
		public static bool TryRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0xC4E804", Offset = "0xC4E804", Length = "0x9C")]
		private bool InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0xC4E910", Offset = "0xC4E910", Length = "0x70")]
		public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0xC4EA50", Offset = "0xC4EA50", Length = "0x70")]
		public static bool TryRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0xC4E980", Offset = "0xC4E980", Length = "0xD0")]
		private bool InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0xC4EAC0", Offset = "0xC4EAC0", Length = "0x80")]
		public static void UnRegisterCanvasElementForRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0xC4EB40", Offset = "0xC4EB40", Length = "0x164")]
		private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0xC4ECA4", Offset = "0xC4ECA4", Length = "0x164")]
		private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0xC4EE08", Offset = "0xC4EE08", Length = "0x6C")]
		public static bool IsRebuildingLayout()
		{
			return false;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0xC4EE74", Offset = "0xC4EE74", Length = "0x6C")]
		public static bool IsRebuildingGraphics()
		{
			return false;
		}
	}
}

using System;
using Cpp2ILInjected;
using UnityEngine.UI.Collections;

namespace UnityEngine.UI
{
	[Token(Token = "0x200000A")]
	public class CanvasUpdateRegistry
	{
		[Token(Token = "0x400001D")]
		private static CanvasUpdateRegistry s_Instance;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x10")]
		private bool m_PerformingLayoutUpdate;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x11")]
		private bool m_PerformingGraphicUpdate;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x18")]
		private string[] m_CanvasUpdateProfilerStrings;

		[Token(Token = "0x4000021")]
		private const string m_CullingUpdateProfilerString = "ClipperRegistry.Cull";

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x20")]
		private readonly IndexedSet<ICanvasElement> m_LayoutRebuildQueue;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x28")]
		private readonly IndexedSet<ICanvasElement> m_GraphicRebuildQueue;

		[Token(Token = "0x4000024")]
		private static readonly Comparison<ICanvasElement> s_SortLayoutFunction;

		[Token(Token = "0x1700000A")]
		public static CanvasUpdateRegistry instance
		{
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x16C1518", Offset = "0x16C1518", Length = "0xA0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x16C1348", Offset = "0x16C1348", Length = "0x1D0")]
		protected CanvasUpdateRegistry()
		{
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x16C15B8", Offset = "0x16C15B8", Length = "0xD0")]
		private bool ObjectValidForUpdate(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x16C1688", Offset = "0x16C1688", Length = "0x2E4")]
		private void CleanInvalidItems()
		{
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x16C196C", Offset = "0x16C196C", Length = "0x640")]
		private void PerformUpdate()
		{
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x16C212C", Offset = "0x16C212C", Length = "0xBC")]
		private static int ParentCount(Transform child)
		{
			return 0;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x16C21E8", Offset = "0x16C21E8", Length = "0x150")]
		private static int SortLayoutList(ICanvasElement x, ICanvasElement y)
		{
			return 0;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x16C2338", Offset = "0x16C2338", Length = "0x60")]
		public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x16C2430", Offset = "0x16C2430", Length = "0x60")]
		public static bool TryRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x16C2398", Offset = "0x16C2398", Length = "0x98")]
		private bool InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x16C2490", Offset = "0x16C2490", Length = "0x60")]
		public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x16C25C0", Offset = "0x16C25C0", Length = "0x60")]
		public static bool TryRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x16C24F0", Offset = "0x16C24F0", Length = "0xD0")]
		private bool InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
			return false;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x16C2620", Offset = "0x16C2620", Length = "0x70")]
		public static void UnRegisterCanvasElementForRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x16C2958", Offset = "0x16C2958", Length = "0x70")]
		public static void DisableCanvasElementForRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x16C2690", Offset = "0x16C2690", Length = "0x164")]
		private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x16C27F4", Offset = "0x16C27F4", Length = "0x164")]
		private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x16C29C8", Offset = "0x16C29C8", Length = "0x164")]
		private void InternalDisableCanvasElementForLayoutRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x16C2B2C", Offset = "0x16C2B2C", Length = "0x164")]
		private void InternalDisableCanvasElementForGraphicRebuild(ICanvasElement element)
		{
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x16C2C90", Offset = "0x16C2C90", Length = "0x5C")]
		public static bool IsRebuildingLayout()
		{
			return false;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x16C2CEC", Offset = "0x16C2CEC", Length = "0x5C")]
		public static bool IsRebuildingGraphics()
		{
			return false;
		}
	}
}

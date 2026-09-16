using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Events;
using UnityEngine.Pool;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000050")]
	public class LayoutRebuilder : ICanvasElement
	{
		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x10")]
		private RectTransform m_ToRebuild;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x18")]
		private int m_CachedHashFromTransform;

		[Token(Token = "0x4000187")]
		private static ObjectPool<LayoutRebuilder> s_Rebuilders;

		[Token(Token = "0x170000D4")]
		public Transform transform
		{
			[Token(Token = "0x6000304")]
			[Address(RVA = "0x1827A7C", Offset = "0x1827A7C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000300")]
		[Address(RVA = "0x182780C", Offset = "0x182780C", Length = "0x34")]
		private void Initialize(RectTransform controller)
		{
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0x1827840", Offset = "0x1827840", Length = "0xC")]
		private void Clear()
		{
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0x182784C", Offset = "0x182784C", Length = "0x1DC")]
		static LayoutRebuilder()
		{
		}

		[Token(Token = "0x6000303")]
		[Address(RVA = "0x1827A28", Offset = "0x1827A28", Length = "0x54")]
		private static void ReapplyDrivenProperties(RectTransform driven)
		{
		}

		[Token(Token = "0x6000305")]
		[Address(RVA = "0x1827A84", Offset = "0x1827A84", Length = "0x60")]
		public bool IsDestroyed()
		{
			return false;
		}

		[Token(Token = "0x6000306")]
		[Address(RVA = "0x1827AE4", Offset = "0x1827AE4", Length = "0xF8")]
		private static void StripDisabledBehavioursFromList(List<Component> components)
		{
		}

		[Token(Token = "0x6000307")]
		[Address(RVA = "0x1827BDC", Offset = "0x1827BDC", Length = "0xDC")]
		public static void ForceRebuildLayoutImmediate(RectTransform layoutRoot)
		{
		}

		[Token(Token = "0x6000308")]
		[Address(RVA = "0x1827CB8", Offset = "0x1827CB8", Length = "0x2AC")]
		public void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x6000309")]
		[Address(RVA = "0x1828234", Offset = "0x1828234", Length = "0x3C8")]
		private void PerformLayoutControl(RectTransform rect, UnityAction<Component> action)
		{
		}

		[Token(Token = "0x600030A")]
		[Address(RVA = "0x1827F64", Offset = "0x1827F64", Length = "0x2D0")]
		private void PerformLayoutCalculation(RectTransform rect, UnityAction<Component> action)
		{
		}

		[Token(Token = "0x600030B")]
		[Address(RVA = "0x1822E94", Offset = "0x1822E94", Length = "0x400")]
		public static void MarkLayoutForRebuild(RectTransform rect)
		{
		}

		[Token(Token = "0x600030C")]
		[Address(RVA = "0x18285FC", Offset = "0x18285FC", Length = "0x1F4")]
		private static bool ValidController(RectTransform layoutRoot, List<Component> comps)
		{
			return false;
		}

		[Token(Token = "0x600030D")]
		[Address(RVA = "0x18287F0", Offset = "0x18287F0", Length = "0x158")]
		private static void MarkLayoutRootForRebuild(RectTransform controller)
		{
		}

		[Token(Token = "0x600030E")]
		[Address(RVA = "0x1828948", Offset = "0x1828948", Length = "0x80")]
		public void LayoutComplete()
		{
		}

		[Token(Token = "0x600030F")]
		[Address(RVA = "0x18289C8", Offset = "0x18289C8", Length = "0x4")]
		public void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x6000310")]
		[Address(RVA = "0x18289CC", Offset = "0x18289CC", Length = "0x8")]
		public override int GetHashCode()
		{
			return 0;
		}

		[Token(Token = "0x6000311")]
		[Address(RVA = "0x18289D4", Offset = "0x18289D4", Length = "0x50")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x6000312")]
		[Address(RVA = "0x1828A24", Offset = "0x1828A24", Length = "0x6C")]
		public override string ToString()
		{
			return null;
		}

		[Token(Token = "0x6000313")]
		[Address(RVA = "0x1828A90", Offset = "0x1828A90", Length = "0x8")]
		public LayoutRebuilder()
		{
		}
	}
}

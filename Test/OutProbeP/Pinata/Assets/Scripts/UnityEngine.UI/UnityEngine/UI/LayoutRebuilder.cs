using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000026")]
	public class LayoutRebuilder : ICanvasElement
	{
		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x10")]
		private RectTransform m_ToRebuild;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x18")]
		private int m_CachedHashFromTransform;

		[Token(Token = "0x40000E6")]
		private static ObjectPool<LayoutRebuilder> s_Rebuilders;

		[Token(Token = "0x170000C0")]
		public Transform transform
		{
			[Token(Token = "0x600029B")]
			[Address(RVA = "0xEC4C50", Offset = "0xEC4C50", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0xEC4A8C", Offset = "0xEC4A8C", Length = "0x44")]
		private void Initialize(RectTransform controller)
		{
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0xEC4AD0", Offset = "0xEC4AD0", Length = "0xC")]
		private void Clear()
		{
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0xEC4ADC", Offset = "0xEC4ADC", Length = "0x110")]
		static LayoutRebuilder()
		{
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0xEC4BEC", Offset = "0xEC4BEC", Length = "0x64")]
		private static void ReapplyDrivenProperties(RectTransform driven)
		{
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0xEC4C58", Offset = "0xEC4C58", Length = "0x70")]
		public bool IsDestroyed()
		{
			return false;
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0xEC4CC8", Offset = "0xEC4CC8", Length = "0xF8")]
		private static void StripDisabledBehavioursFromList(List<Component> components)
		{
		}

		[Token(Token = "0x600029E")]
		[Address(RVA = "0xEC4DC0", Offset = "0xEC4DC0", Length = "0xE4")]
		public static void ForceRebuildLayoutImmediate(RectTransform layoutRoot)
		{
		}

		[Token(Token = "0x600029F")]
		[Address(RVA = "0xEC4EA4", Offset = "0xEC4EA4", Length = "0x2E4")]
		public void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0xEC5458", Offset = "0xEC5458", Length = "0x304")]
		private void PerformLayoutControl(RectTransform rect, UnityAction<Component> action)
		{
		}

		[Token(Token = "0x60002A1")]
		[Address(RVA = "0xEC5188", Offset = "0xEC5188", Length = "0x2D0")]
		private void PerformLayoutCalculation(RectTransform rect, UnityAction<Component> action)
		{
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xEC465C", Offset = "0xEC465C", Length = "0x3BC")]
		public static void MarkLayoutForRebuild(RectTransform rect)
		{
		}

		[Token(Token = "0x60002A3")]
		[Address(RVA = "0xEC575C", Offset = "0xEC575C", Length = "0x1E0")]
		private static bool ValidController(RectTransform layoutRoot, List<Component> comps)
		{
			return false;
		}

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0xEC593C", Offset = "0xEC593C", Length = "0x164")]
		private static void MarkLayoutRootForRebuild(RectTransform controller)
		{
		}

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0xEC5AA0", Offset = "0xEC5AA0", Length = "0x84")]
		public void LayoutComplete()
		{
		}

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0xEC5B24", Offset = "0xEC5B24", Length = "0x4")]
		public void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0xEC5B28", Offset = "0xEC5B28", Length = "0x8")]
		public override int GetHashCode()
		{
			return 0;
		}

		[Token(Token = "0x60002A8")]
		[Address(RVA = "0xEC5B30", Offset = "0xEC5B30", Length = "0x58")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x60002A9")]
		[Address(RVA = "0xEC5B88", Offset = "0xEC5B88", Length = "0x54")]
		public override string ToString()
		{
			return null;
		}

		[Token(Token = "0x60002AA")]
		[Address(RVA = "0xEC5BDC", Offset = "0xEC5BDC", Length = "0x8")]
		public LayoutRebuilder()
		{
		}
	}
}

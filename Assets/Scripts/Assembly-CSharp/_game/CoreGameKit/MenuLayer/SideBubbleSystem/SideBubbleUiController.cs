using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.MenuLayer.SideBubbleSystem
{
	[Token(Token = "0x20005EB")]
	public class SideBubbleUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x400146E")]
		[FieldOffset(Offset = "0x48")]
		private RectTransform m_leftContainer;

		[SerializeField]
		[Token(Token = "0x400146F")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform m_rightContainer;

		[Token(Token = "0x4001470")]
		[FieldOffset(Offset = "0x58")]
		private SideBubbleSlot[] _leftSlots;

		[Token(Token = "0x4001471")]
		[FieldOffset(Offset = "0x60")]
		private SideBubbleSlot[] _rightSlots;

		[Inject(false)]
		[Token(Token = "0x6001961")]
		[Address(RVA = "0x3D47A6C", Offset = "0x3D47A6C", Length = "0x198")]
		public void Initialize(Instancer instancer)
		{
			SideBubbleSlot[] componentsInChildren = m_leftContainer.GetComponentsInChildren<SideBubbleSlot>(includeInactive: true);
			_leftSlots = componentsInChildren;
			SideBubbleSlot[] componentsInChildren2 = m_rightContainer.GetComponentsInChildren<SideBubbleSlot>(includeInactive: true);
			_rightSlots = componentsInChildren2;
			SideBubbleSlot[] leftSlots = _leftSlots;
			if (leftSlots.Length >= 1)
			{
				int num = 0;
				do
				{
					SideBubbleSlot sideBubbleSlot = leftSlots[num];
					sideBubbleSlot._side = default(SideBubbleSide);
					leftSlots[num].InitHidden();
					num++;
				}
				while (num < leftSlots.Length);
			}
			SideBubbleSlot[] rightSlots = _rightSlots;
			if (rightSlots.Length >= 1)
			{
				int num2 = 0;
				do
				{
					SideBubbleSlot sideBubbleSlot2 = rightSlots[num2];
					sideBubbleSlot2._side = SideBubbleSide.Right;
					rightSlots[num2].InitHidden();
					num2++;
				}
				while (num2 < rightSlots.Length);
			}
			SideBubbleSlot[] leftSlots2 = _leftSlots;
			int num3 = 0;
			do
			{
				if (num3 < leftSlots2.Length)
				{
					ShowSlot(default(SideBubbleSide), num3);
					num3++;
					leftSlots2 = _leftSlots;
					continue;
				}
				SideBubbleSlot[] rightSlots2 = _rightSlots;
				int num4 = 0;
				do
				{
					if (num4 < rightSlots2.Length)
					{
						ShowSlot(SideBubbleSide.Right, num4);
						num4++;
						rightSlots2 = _rightSlots;
						continue;
					}
					return;
				}
				while (_rightSlots != null);
				break;
			}
			while (_leftSlots != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001962")]
		[Address(RVA = "0x3D47C90", Offset = "0x3D47C90", Length = "0x48")]
		public SideBubbleSlot GetSlot(SideBubbleSide side, int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SideBubbleUiController::GetSlot");
			return default;
		}

		[Token(Token = "0x6001963")]
		[Address(RVA = "0x3D47CD8", Offset = "0x3D47CD8", Length = "0xFC")]
		public void ShowSlot(SideBubbleSide side, int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SideBubbleUiController::ShowSlot");
		}

		[Token(Token = "0x6001964")]
		[Address(RVA = "0x3D47DD4", Offset = "0x3D47DD4", Length = "0x100")]
		public void HideSlot(SideBubbleSide side, int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SideBubbleUiController::HideSlot");
		}

		[Token(Token = "0x6001965")]
		[Address(RVA = "0x3D47C04", Offset = "0x3D47C04", Length = "0x8C")]
		public void ShowAllSlots()
		{
			SideBubbleSlot[] leftSlots = _leftSlots;
			int num = 0;
			do
			{
				if (num < leftSlots.Length)
				{
					ShowSlot(default(SideBubbleSide), num);
					num++;
					leftSlots = _leftSlots;
					continue;
				}
				SideBubbleSlot[] rightSlots = _rightSlots;
				int num2 = 0;
				do
				{
					if (num2 < rightSlots.Length)
					{
						ShowSlot(SideBubbleSide.Right, num2);
						num2++;
						rightSlots = _rightSlots;
						continue;
					}
					return;
				}
				while (_rightSlots != null);
				break;
			}
			while (_leftSlots != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001966")]
		[Address(RVA = "0x3D47ED4", Offset = "0x3D47ED4", Length = "0x8C")]
		public void HideAllSlots()
		{
			SideBubbleSlot[] leftSlots = _leftSlots;
			int num = 0;
			do
			{
				if (num < leftSlots.Length)
				{
					HideSlot(default(SideBubbleSide), num);
					num++;
					leftSlots = _leftSlots;
					continue;
				}
				SideBubbleSlot[] rightSlots = _rightSlots;
				int num2 = 0;
				do
				{
					if (num2 < rightSlots.Length)
					{
						HideSlot(SideBubbleSide.Right, num2);
						num2++;
						rightSlots = _rightSlots;
						continue;
					}
					return;
				}
				while (_rightSlots != null);
				break;
			}
			while (_leftSlots != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001967")]
		[Address(RVA = "0x3D47F60", Offset = "0x3D47F60", Length = "0x8")]
		public SideBubbleUiController()
		{
		}
	}
}

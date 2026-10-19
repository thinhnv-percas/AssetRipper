using System;
using System.Collections.Generic;
using Systems.RewardSystem.UnityBindings;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.Extensions;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.RewardSystem.Distribution;
using UnityEngine;

namespace _game.Systems.RewardSystem.UnityBindings
{
	[Token(Token = "0x200073C")]
	public class ItemGridView : MonoBehaviour
	{
		[Header("Prefab & Grid")]
		[SerializeField]
		[Token(Token = "0x4001832")]
		[FieldOffset(Offset = "0x20")]
		private GenericElementVisualizer m_elementPrefab;

		[SerializeField]
		[Token(Token = "0x4001833")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform m_container;

		[SerializeField]
		[Token(Token = "0x4001834")]
		[FieldOffset(Offset = "0x30")]
		private int m_columnCount;

		[SerializeField]
		[Token(Token = "0x4001835")]
		[FieldOffset(Offset = "0x34")]
		private float m_cellWidth;

		[SerializeField]
		[Token(Token = "0x4001836")]
		[FieldOffset(Offset = "0x38")]
		private float m_cellHeight;

		[SerializeField]
		[Token(Token = "0x4001837")]
		[FieldOffset(Offset = "0x3C")]
		private float m_spacingX;

		[SerializeField]
		[Token(Token = "0x4001838")]
		[FieldOffset(Offset = "0x40")]
		private float m_spacingY;

		[Header("Element Size Override")]
		[SerializeField]
		[Token(Token = "0x4001839")]
		[FieldOffset(Offset = "0x44")]
		private bool m_overrideElementSize;

		[SerializeField]
		[Token(Token = "0x400183A")]
		[FieldOffset(Offset = "0x48")]
		private float m_elementWidth;

		[SerializeField]
		[Token(Token = "0x400183B")]
		[FieldOffset(Offset = "0x4C")]
		private float m_elementHeight;

		[SerializeField]
		[Token(Token = "0x400183C")]
		[FieldOffset(Offset = "0x50")]
		private float m_overrideSpacingX;

		[SerializeField]
		[Token(Token = "0x400183D")]
		[FieldOffset(Offset = "0x54")]
		private float m_overrideSpacingY;

		[Header("Animation")]
		[SerializeField]
		[Token(Token = "0x400183E")]
		[FieldOffset(Offset = "0x58")]
		private float m_popInDuration;

		[SerializeField]
		[Token(Token = "0x400183F")]
		[FieldOffset(Offset = "0x5C")]
		private float m_delayBetweenItems;

		[Header("Options")]
		[SerializeField]
		[Token(Token = "0x4001840")]
		[FieldOffset(Offset = "0x60")]
		private bool m_mergeSameItems;

		[SerializeField]
		[Token(Token = "0x4001841")]
		[FieldOffset(Offset = "0x61")]
		private bool m_featuredResourceLayout;

		[Header("Featured Resource (optional)")]
		[SerializeField]
		[Token(Token = "0x4001842")]
		[FieldOffset(Offset = "0x64")]
		private ResourceType m_featuredResourceType;

		[SerializeField]
		[Token(Token = "0x4001843")]
		[FieldOffset(Offset = "0x68")]
		private RectTransform m_featuredContainer;

		[Inject(false)]
		[Token(Token = "0x4001844")]
		[FieldOffset(Offset = "0x70")]
		private Instancer _instancer;

		[Token(Token = "0x4001845")]
		[FieldOffset(Offset = "0x78")]
		private Sequence _spawnSequence;

		[Token(Token = "0x4001846")]
		[FieldOffset(Offset = "0x88")]
		private readonly List<GenericElementVisualizer> _spawnedElements;

		[Token(Token = "0x170002E9")]
		public bool IsAnimating
		{
			[Token(Token = "0x6001E7B")]
			[Address(RVA = "0x3D852B8", Offset = "0x3D852B8", Length = "0xC")]
			get
			{
				return _spawnSequence.isAlive;
			}
		}

		[Token(Token = "0x170002EA")]
		private float CellWidth
		{
			[Token(Token = "0x6001E84")]
			[Address(RVA = "0x3D86570", Offset = "0x3D86570", Length = "0x1C")]
			get
			{
				//IL_005e: Expected F4, but got I
				if (m_overrideElementSize)
				{
					int num = 72;
				}
				else
				{
					int num = 52;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.Systems.RewardSystem.UnityBindings.ItemGridView)+v17 @ X8_v3 (System.Int32)]");
				return 0f;
			}
		}

		[Token(Token = "0x170002EB")]
		private float CellHeight
		{
			[Token(Token = "0x6001E85")]
			[Address(RVA = "0x3D8658C", Offset = "0x3D8658C", Length = "0x1C")]
			get
			{
				//IL_005e: Expected F4, but got I
				if (m_overrideElementSize)
				{
					int num = 76;
				}
				else
				{
					int num = 56;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.Systems.RewardSystem.UnityBindings.ItemGridView)+v17 @ X8_v3 (System.Int32)]");
				return 0f;
			}
		}

		[Token(Token = "0x170002EC")]
		private float SpacingX
		{
			[Token(Token = "0x6001E86")]
			[Address(RVA = "0x3D865A8", Offset = "0x3D865A8", Length = "0x1C")]
			get
			{
				//IL_005e: Expected F4, but got I
				if (m_overrideElementSize)
				{
					int num = 80;
				}
				else
				{
					int num = 60;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.Systems.RewardSystem.UnityBindings.ItemGridView)+v17 @ X8_v3 (System.Int32)]");
				return 0f;
			}
		}

		[Token(Token = "0x170002ED")]
		private float SpacingY
		{
			[Token(Token = "0x6001E87")]
			[Address(RVA = "0x3D865C4", Offset = "0x3D865C4", Length = "0x1C")]
			get
			{
				//IL_005e: Expected F4, but got I
				if (m_overrideElementSize)
				{
					int num = 84;
				}
				else
				{
					int num = 64;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.Systems.RewardSystem.UnityBindings.ItemGridView)+v17 @ X8_v3 (System.Int32)]");
				return 0f;
			}
		}

		[Token(Token = "0x6001E7C")]
		[Address(RVA = "0x3D852C4", Offset = "0x3D852C4", Length = "0x198")]
		public void Populate(IReadOnlyList<ShopItemData> items, Action onComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ItemGridView::Populate");
		}

		[Token(Token = "0x6001E7D")]
		[Address(RVA = "0x3D860D8", Offset = "0x3D860D8", Length = "0x40")]
		public void CompleteAnimation()
		{
			if (_spawnSequence.isAlive)
			{
				_spawnSequence.Complete();
			}
		}

		[Token(Token = "0x6001E7E")]
		[Address(RVA = "0x3D8545C", Offset = "0x3D8545C", Length = "0x10C")]
		public void Clear()
		{
			if (_spawnSequence.isAlive)
			{
				_spawnSequence.Stop();
			}
			m_container.DeleteAllChildren();
			List<GenericElementVisualizer> spawnedElements;
			if (!(m_featuredContainer != null))
			{
				spawnedElements = _spawnedElements;
			}
			else
			{
				m_featuredContainer.DeleteAllChildren();
				spawnedElements = _spawnedElements;
				if (_spawnedElements == null)
				{
					throw new NullReferenceException();
				}
			}
			spawnedElements.Clear();
			if (spawnedElements.Count < 1)
			{
			}
		}

		[Token(Token = "0x6001E7F")]
		[Address(RVA = "0x3D86118", Offset = "0x3D86118", Length = "0x4")]
		private void OnDisable()
		{
			Clear();
		}

		[Token(Token = "0x6001E80")]
		[Address(RVA = "0x3D85D90", Offset = "0x3D85D90", Length = "0x348")]
		private void PopulateGridOnly(IReadOnlyList<ShopItemData> items, Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ItemGridView::PopulateGridOnly");
		}

		[Token(Token = "0x6001E81")]
		[Address(RVA = "0x3D85568", Offset = "0x3D85568", Length = "0x828")]
		private void PopulateFeaturedLayout(IReadOnlyList<ShopItemData> items, Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ItemGridView::PopulateFeaturedLayout");
		}

		[Token(Token = "0x6001E82")]
		[Address(RVA = "0x3D862C0", Offset = "0x3D862C0", Length = "0x2A8")]
		private unsafe void AnimateElements(int startIndex, int count, Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ItemGridView::AnimateElements");
		}

		[Token(Token = "0x6001E83")]
		[Address(RVA = "0x3D8611C", Offset = "0x3D8611C", Length = "0x30")]
		private void ApplyElementSize(RectTransform rt)
		{
			if (m_overrideElementSize)
			{
				Vector2 sizeDelta = default(Vector2);
				sizeDelta.x = m_elementWidth;
				sizeDelta.y = m_elementHeight;
				rt.sizeDelta = sizeDelta;
			}
		}

		[Token(Token = "0x6001E88")]
		[Address(RVA = "0x3D8614C", Offset = "0x3D8614C", Length = "0x174")]
		private Vector2 CalculateGridPosition(int index, int totalItems)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ItemGridView::CalculateGridPosition");
			return default;
		}

		[Token(Token = "0x6001E89")]
		[Address(RVA = "0x3D865E0", Offset = "0x3D865E0", Length = "0xB8")]
		public ItemGridView()
		{
			//IL_0029: Expected F4, but got I
			//IL_003b: Expected F4, but got I
			m_columnCount = 4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [93080E0]");
			m_cellWidth = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [93080E0]");
			m_elementWidth = 0f;
			m_popInDuration = 0.25f;
			m_delayBetweenItems = 0.08f;
			m_featuredResourceType = ResourceType.SoftCurrency;
			List<GenericElementVisualizer> spawnedElements = new List<GenericElementVisualizer>();
			_spawnedElements = spawnedElements;
		}
	}
}

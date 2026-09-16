using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[AddComponentMenu("Layout/Aspect Ratio Fitter", 142)]
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x200003A")]
	public class AspectRatioFitter : UIBehaviour, ILayoutSelfController, ILayoutController
	{
		[Token(Token = "0x200003B")]
		public enum AspectMode
		{
			[Token(Token = "0x400012E")]
			None = 0,
			[Token(Token = "0x400012F")]
			WidthControlsHeight = 1,
			[Token(Token = "0x4000130")]
			HeightControlsWidth = 2,
			[Token(Token = "0x4000131")]
			FitInParent = 3,
			[Token(Token = "0x4000132")]
			EnvelopeParent = 4
		}

		[SerializeField]
		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x20")]
		private AspectMode m_AspectMode;

		[SerializeField]
		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x24")]
		private float m_AspectRatio;

		[NonSerialized]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform m_Rect;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x30")]
		private bool m_DelayedSetDirty;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x31")]
		private bool m_DoesParentExist;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x32")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x17000098")]
		public AspectMode aspectMode
		{
			[Token(Token = "0x6000244")]
			[Address(RVA = "0x1822A9C", Offset = "0x1822A9C", Length = "0x8")]
			get
			{
				return AspectMode.None;
			}
			[Token(Token = "0x6000245")]
			[Address(RVA = "0x1822AA4", Offset = "0x1822AA4", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000099")]
		public float aspectRatio
		{
			[Token(Token = "0x6000246")]
			[Address(RVA = "0x1822B1C", Offset = "0x1822B1C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000247")]
			[Address(RVA = "0x1822B24", Offset = "0x1822B24", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x1700009A")]
		private RectTransform rectTransform
		{
			[Token(Token = "0x6000248")]
			[Address(RVA = "0x1822B98", Offset = "0x1822B98", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0x1822C2C", Offset = "0x1822C2C", Length = "0x10")]
		protected AspectRatioFitter()
		{
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0x1822C3C", Offset = "0x1822C3C", Length = "0x98")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x1822CD4", Offset = "0x1822CD4", Length = "0x50")]
		protected override void Start()
		{
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x1822E18", Offset = "0x1822E18", Length = "0x7C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x1823294", Offset = "0x1823294", Length = "0x98")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0x182332C", Offset = "0x182332C", Length = "0x14")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x1823340", Offset = "0x1823340", Length = "0x4")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x1823344", Offset = "0x1823344", Length = "0x2EC")]
		private void UpdateRect()
		{
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x1823728", Offset = "0x1823728", Length = "0xF4")]
		private float GetSizeDeltaToProduceSize(float size, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x6000252")]
		[Address(RVA = "0x1823630", Offset = "0x1823630", Length = "0xF8")]
		private Vector2 GetParentSize()
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0x182381C", Offset = "0x182381C", Length = "0x4")]
		public virtual void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x1823820", Offset = "0x1823820", Length = "0x4")]
		public virtual void SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0x1822B18", Offset = "0x1822B18", Length = "0x4")]
		protected void SetDirty()
		{
		}

		[Token(Token = "0x6000256")]
		[Address(RVA = "0x1822D24", Offset = "0x1822D24", Length = "0xCC")]
		public bool IsComponentValidOnObject()
		{
			return false;
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x1822DF0", Offset = "0x1822DF0", Length = "0x28")]
		public bool IsAspectModeValid()
		{
			return false;
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0x1823824", Offset = "0x1823824", Length = "0x8")]
		private bool DoesParentExists()
		{
			return false;
		}
	}
}

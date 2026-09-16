using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AddComponentMenu("Layout/Grid Layout Group", 152)]
	[Token(Token = "0x2000042")]
	public class GridLayoutGroup : LayoutGroup
	{
		[Token(Token = "0x2000043")]
		public enum Corner
		{
			[Token(Token = "0x400015F")]
			UpperLeft = 0,
			[Token(Token = "0x4000160")]
			UpperRight = 1,
			[Token(Token = "0x4000161")]
			LowerLeft = 2,
			[Token(Token = "0x4000162")]
			LowerRight = 3
		}

		[Token(Token = "0x2000044")]
		public enum Axis
		{
			[Token(Token = "0x4000164")]
			Horizontal = 0,
			[Token(Token = "0x4000165")]
			Vertical = 1
		}

		[Token(Token = "0x2000045")]
		public enum Constraint
		{
			[Token(Token = "0x4000167")]
			Flexible = 0,
			[Token(Token = "0x4000168")]
			FixedColumnCount = 1,
			[Token(Token = "0x4000169")]
			FixedRowCount = 2
		}

		[SerializeField]
		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x60")]
		protected Corner m_StartCorner;

		[SerializeField]
		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x64")]
		protected Axis m_StartAxis;

		[SerializeField]
		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x68")]
		protected Vector2 m_CellSize;

		[SerializeField]
		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x70")]
		protected Vector2 m_Spacing;

		[SerializeField]
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x78")]
		protected Constraint m_Constraint;

		[SerializeField]
		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x7C")]
		protected int m_ConstraintCount;

		[Token(Token = "0x170000A8")]
		public Corner startCorner
		{
			[Token(Token = "0x6000285")]
			[Address(RVA = "0x1824334", Offset = "0x1824334", Length = "0x8")]
			get
			{
				return Corner.UpperLeft;
			}
			[Token(Token = "0x6000286")]
			[Address(RVA = "0x182433C", Offset = "0x182433C", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000A9")]
		public Axis startAxis
		{
			[Token(Token = "0x6000287")]
			[Address(RVA = "0x1824398", Offset = "0x1824398", Length = "0x8")]
			get
			{
				return Axis.Horizontal;
			}
			[Token(Token = "0x6000288")]
			[Address(RVA = "0x18243A0", Offset = "0x18243A0", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AA")]
		public Vector2 cellSize
		{
			[Token(Token = "0x6000289")]
			[Address(RVA = "0x18243FC", Offset = "0x18243FC", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x600028A")]
			[Address(RVA = "0x1824404", Offset = "0x1824404", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000AB")]
		public Vector2 spacing
		{
			[Token(Token = "0x600028B")]
			[Address(RVA = "0x1824468", Offset = "0x1824468", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x600028C")]
			[Address(RVA = "0x1824470", Offset = "0x1824470", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000AC")]
		public Constraint constraint
		{
			[Token(Token = "0x600028D")]
			[Address(RVA = "0x18244D4", Offset = "0x18244D4", Length = "0x8")]
			get
			{
				return Constraint.Flexible;
			}
			[Token(Token = "0x600028E")]
			[Address(RVA = "0x18244DC", Offset = "0x18244DC", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AD")]
		public int constraintCount
		{
			[Token(Token = "0x600028F")]
			[Address(RVA = "0x1824538", Offset = "0x1824538", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000290")]
			[Address(RVA = "0x1824540", Offset = "0x1824540", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0x18245A0", Offset = "0x18245A0", Length = "0x68")]
		protected GridLayoutGroup()
		{
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0x1824724", Offset = "0x1824724", Length = "0x1CC")]
		public override void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0x1824D28", Offset = "0x1824D28", Length = "0x208")]
		public override void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0x1824FC4", Offset = "0x1824FC4", Length = "0x8")]
		public override void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0x1825758", Offset = "0x1825758", Length = "0x8")]
		public override void SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0x1824FCC", Offset = "0x1824FCC", Length = "0x78C")]
		private void SetCellsAlongAxis(int axis)
		{
		}
	}
}

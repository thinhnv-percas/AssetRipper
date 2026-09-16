using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x727460", Offset = "0x727460")]
	[Token(Token = "0x200001C")]
	public class GridLayoutGroup : LayoutGroup
	{
		[Token(Token = "0x2000096")]
		public enum Corner
		{
			[Token(Token = "0x4000299")]
			UpperLeft = 0,
			[Token(Token = "0x400029A")]
			UpperRight = 1,
			[Token(Token = "0x400029B")]
			LowerLeft = 2,
			[Token(Token = "0x400029C")]
			LowerRight = 3
		}

		[Token(Token = "0x2000097")]
		public enum Axis
		{
			[Token(Token = "0x400029E")]
			Horizontal = 0,
			[Token(Token = "0x400029F")]
			Vertical = 1
		}

		[Token(Token = "0x2000098")]
		public enum Constraint
		{
			[Token(Token = "0x40002A1")]
			Flexible = 0,
			[Token(Token = "0x40002A2")]
			FixedColumnCount = 1,
			[Token(Token = "0x40002A3")]
			FixedRowCount = 2
		}

		[SerializeField]
		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x58")]
		protected Corner m_StartCorner;

		[SerializeField]
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x5C")]
		protected Axis m_StartAxis;

		[SerializeField]
		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x60")]
		protected Vector2 m_CellSize;

		[SerializeField]
		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x68")]
		protected Vector2 m_Spacing;

		[SerializeField]
		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x70")]
		protected Constraint m_Constraint;

		[SerializeField]
		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x74")]
		protected int m_ConstraintCount;

		[Token(Token = "0x17000097")]
		public Corner startCorner
		{
			[Token(Token = "0x6000224")]
			[Address(RVA = "0xF49C58", Offset = "0xF49C58", Length = "0x8")]
			get
			{
				return Corner.UpperLeft;
			}
			[Token(Token = "0x6000225")]
			[Address(RVA = "0xF49C60", Offset = "0xF49C60", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x17000098")]
		public Axis startAxis
		{
			[Token(Token = "0x6000226")]
			[Address(RVA = "0xF49CC4", Offset = "0xF49CC4", Length = "0x8")]
			get
			{
				return Axis.Horizontal;
			}
			[Token(Token = "0x6000227")]
			[Address(RVA = "0xF49CCC", Offset = "0xF49CCC", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x17000099")]
		public Vector2 cellSize
		{
			[Token(Token = "0x6000228")]
			[Address(RVA = "0xF49D30", Offset = "0xF49D30", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000229")]
			[Address(RVA = "0xF49D38", Offset = "0xF49D38", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x1700009A")]
		public Vector2 spacing
		{
			[Token(Token = "0x600022A")]
			[Address(RVA = "0xF49DA4", Offset = "0xF49DA4", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x600022B")]
			[Address(RVA = "0xF49DAC", Offset = "0xF49DAC", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x1700009B")]
		public Constraint constraint
		{
			[Token(Token = "0x600022C")]
			[Address(RVA = "0xF49E18", Offset = "0xF49E18", Length = "0x8")]
			get
			{
				return Constraint.Flexible;
			}
			[Token(Token = "0x600022D")]
			[Address(RVA = "0xF49E20", Offset = "0xF49E20", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x1700009C")]
		public int constraintCount
		{
			[Token(Token = "0x600022E")]
			[Address(RVA = "0xF49E84", Offset = "0xF49E84", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600022F")]
			[Address(RVA = "0xF49E8C", Offset = "0xF49E8C", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0xF49F24", Offset = "0xF49F24", Length = "0xA8")]
		protected GridLayoutGroup()
		{
		}

		[Token(Token = "0x6000231")]
		[Address(RVA = "0xF4A0CC", Offset = "0xF4A0CC", Length = "0x198")]
		public override void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0xF4A5DC", Offset = "0xF4A5DC", Length = "0x1E0")]
		public override void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0xF4A854", Offset = "0xF4A854", Length = "0x8")]
		public override void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x6000234")]
		[Address(RVA = "0xF4AEC4", Offset = "0xF4AEC4", Length = "0x8")]
		public override void SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0xF4A85C", Offset = "0xF4A85C", Length = "0x668")]
		private void SetCellsAlongAxis(int axis)
		{
		}
	}
}

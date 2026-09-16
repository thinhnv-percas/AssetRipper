using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000066")]
	public class BaseInput : UIBehaviour
	{
		[Token(Token = "0x17000187")]
		public virtual string compositionString
		{
			[Token(Token = "0x600057C")]
			[Address(RVA = "0xC40F70", Offset = "0xC40F70", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000188")]
		public virtual IMECompositionMode imeCompositionMode
		{
			[Token(Token = "0x600057D")]
			[Address(RVA = "0xC40F78", Offset = "0xC40F78", Length = "0x8")]
			get
			{
				return IMECompositionMode.Auto;
			}
			[Token(Token = "0x600057E")]
			[Address(RVA = "0xC40F80", Offset = "0xC40F80", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000189")]
		public virtual Vector2 compositionCursorPos
		{
			[Token(Token = "0x600057F")]
			[Address(RVA = "0xC40F8C", Offset = "0xC40F8C", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000580")]
			[Address(RVA = "0xC40F94", Offset = "0xC40F94", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700018A")]
		public virtual bool mousePresent
		{
			[Token(Token = "0x6000581")]
			[Address(RVA = "0xC40F9C", Offset = "0xC40F9C", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700018B")]
		public virtual Vector2 mousePosition
		{
			[Token(Token = "0x6000585")]
			[Address(RVA = "0xC40FC8", Offset = "0xC40FC8", Length = "0x90")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x1700018C")]
		public virtual Vector2 mouseScrollDelta
		{
			[Token(Token = "0x6000586")]
			[Address(RVA = "0xC41058", Offset = "0xC41058", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x1700018D")]
		public virtual bool touchSupported
		{
			[Token(Token = "0x6000587")]
			[Address(RVA = "0xC41060", Offset = "0xC41060", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700018E")]
		public virtual int touchCount
		{
			[Token(Token = "0x6000588")]
			[Address(RVA = "0xC41068", Offset = "0xC41068", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x6000582")]
		[Address(RVA = "0xC40FA4", Offset = "0xC40FA4", Length = "0xC")]
		public virtual bool GetMouseButtonDown(int button)
		{
			return false;
		}

		[Token(Token = "0x6000583")]
		[Address(RVA = "0xC40FB0", Offset = "0xC40FB0", Length = "0xC")]
		public virtual bool GetMouseButtonUp(int button)
		{
			return false;
		}

		[Token(Token = "0x6000584")]
		[Address(RVA = "0xC40FBC", Offset = "0xC40FBC", Length = "0xC")]
		public virtual bool GetMouseButton(int button)
		{
			return false;
		}

		[Token(Token = "0x6000589")]
		[Address(RVA = "0xC41070", Offset = "0xC41070", Length = "0xC")]
		public virtual Touch GetTouch(int index)
		{
			return default(Touch);
		}

		[Token(Token = "0x600058A")]
		[Address(RVA = "0xC4107C", Offset = "0xC4107C", Length = "0xC")]
		public virtual float GetAxisRaw(string axisName)
		{
			return 0f;
		}

		[Token(Token = "0x600058B")]
		[Address(RVA = "0xC41088", Offset = "0xC41088", Length = "0xC")]
		public virtual bool GetButtonDown(string buttonName)
		{
			return false;
		}

		[Token(Token = "0x600058C")]
		[Address(RVA = "0xC41094", Offset = "0xC41094", Length = "0x8")]
		public BaseInput()
		{
		}
	}
}

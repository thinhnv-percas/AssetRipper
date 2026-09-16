using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000B9")]
	public class BaseInput : UIBehaviour
	{
		[Token(Token = "0x170001D5")]
		public virtual string compositionString
		{
			[Token(Token = "0x60006C2")]
			[Address(RVA = "0x1847814", Offset = "0x1847814", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001D6")]
		public virtual IMECompositionMode imeCompositionMode
		{
			[Token(Token = "0x60006C3")]
			[Address(RVA = "0x184781C", Offset = "0x184781C", Length = "0x8")]
			get
			{
				return IMECompositionMode.Auto;
			}
			[Token(Token = "0x60006C4")]
			[Address(RVA = "0x1847824", Offset = "0x1847824", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170001D7")]
		public virtual Vector2 compositionCursorPos
		{
			[Token(Token = "0x60006C5")]
			[Address(RVA = "0x1847830", Offset = "0x1847830", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x60006C6")]
			[Address(RVA = "0x1847838", Offset = "0x1847838", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001D8")]
		public virtual bool mousePresent
		{
			[Token(Token = "0x60006C7")]
			[Address(RVA = "0x1847840", Offset = "0x1847840", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170001D9")]
		public virtual Vector2 mousePosition
		{
			[Token(Token = "0x60006CB")]
			[Address(RVA = "0x184786C", Offset = "0x184786C", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x170001DA")]
		public virtual Vector2 mouseScrollDelta
		{
			[Token(Token = "0x60006CC")]
			[Address(RVA = "0x1847874", Offset = "0x1847874", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x170001DB")]
		public virtual bool touchSupported
		{
			[Token(Token = "0x60006CD")]
			[Address(RVA = "0x184787C", Offset = "0x184787C", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170001DC")]
		public virtual int touchCount
		{
			[Token(Token = "0x60006CE")]
			[Address(RVA = "0x1847884", Offset = "0x1847884", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x60006C8")]
		[Address(RVA = "0x1847848", Offset = "0x1847848", Length = "0xC")]
		public virtual bool GetMouseButtonDown(int button)
		{
			return false;
		}

		[Token(Token = "0x60006C9")]
		[Address(RVA = "0x1847854", Offset = "0x1847854", Length = "0xC")]
		public virtual bool GetMouseButtonUp(int button)
		{
			return false;
		}

		[Token(Token = "0x60006CA")]
		[Address(RVA = "0x1847860", Offset = "0x1847860", Length = "0xC")]
		public virtual bool GetMouseButton(int button)
		{
			return false;
		}

		[Token(Token = "0x60006CF")]
		[Address(RVA = "0x184788C", Offset = "0x184788C", Length = "0x38")]
		public virtual Touch GetTouch(int index)
		{
			return default(Touch);
		}

		[Token(Token = "0x60006D0")]
		[Address(RVA = "0x18478C4", Offset = "0x18478C4", Length = "0xC")]
		public virtual float GetAxisRaw(string axisName)
		{
			return 0f;
		}

		[Token(Token = "0x60006D1")]
		[Address(RVA = "0x18478D0", Offset = "0x18478D0", Length = "0xC")]
		public virtual bool GetButtonDown(string buttonName)
		{
			return false;
		}

		[Token(Token = "0x60006D2")]
		[Address(RVA = "0x18478DC", Offset = "0x18478DC", Length = "0x8")]
		public BaseInput()
		{
		}
	}
}

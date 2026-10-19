using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.Systems.Offers
{
	[Token(Token = "0x2000762")]
	public abstract class OfferElement
	{
		[Token(Token = "0x40018B0")]
		[FieldOffset(Offset = "0x10")]
		private bool _isDisabled;

		[Token(Token = "0x170002F8")]
		public bool IsDisabled
		{
			[Token(Token = "0x6001F26")]
			[Address(RVA = "0x3D8CF04", Offset = "0x3D8CF04", Length = "0x8")]
			get
			{
				return _isDisabled;
			}
		}

		[Token(Token = "0x170002F9")]
		public virtual bool IsPriority
		{
			[Token(Token = "0x6001F27")]
			[Address(RVA = "0x3D8CF0C", Offset = "0x3D8CF0C", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6001F28")]
		public abstract OfferId GetOfferId();

		[Token(Token = "0x6001F29")]
		public abstract bool IsActive();

		[Token(Token = "0x6001F2A")]
		public abstract void Trigger(Instancer instancer, Action onComplete);

		[Token(Token = "0x6001F2B")]
		[Address(RVA = "0x3D8CF14", Offset = "0x3D8CF14", Length = "0x8")]
		public void SetDisabled(bool disabled)
		{
			_isDisabled = disabled;
		}

		[Token(Token = "0x6001F2C")]
		[Address(RVA = "0x3D8CF1C", Offset = "0x3D8CF1C", Length = "0x4")]
		public virtual void DeInit()
		{
		}

		[Token(Token = "0x6001F2D")]
		[Address(RVA = "0x3D8CC14", Offset = "0x3D8CC14", Length = "0x8")]
		protected internal OfferElement()
		{
		}
	}
}

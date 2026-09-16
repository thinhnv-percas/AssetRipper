using Cpp2ILInjected;
using UnityEngine.Events;

namespace TMPro
{
	[Token(Token = "0x2000014")]
	internal struct FloatTween : ITweenValue
	{
		[Token(Token = "0x2000072")]
		public class FloatTweenCallback : UnityEvent<float>
		{
			[Token(Token = "0x6000544")]
			[Address(RVA = "0x917B04", Offset = "0x917B04", Length = "0x1F8")]
			public FloatTweenCallback()
			{
			}
		}

		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x0")]
		private FloatTweenCallback m_Target;

		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x8")]
		private float m_StartValue;

		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0xC")]
		private float m_TargetValue;

		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x10")]
		private float m_Duration;

		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x14")]
		private bool m_IgnoreTimeScale;

		[Token(Token = "0x17000026")]
		public float startValue
		{
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0x8462CC", Offset = "0x8462CC", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x8462D4", Offset = "0x8462D4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000027")]
		public float targetValue
		{
			[Token(Token = "0x60000FB")]
			[Address(RVA = "0x8462DC", Offset = "0x8462DC", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60000FC")]
			[Address(RVA = "0x8462E4", Offset = "0x8462E4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000028")]
		public float duration
		{
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0x8462EC", Offset = "0x8462EC", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60000FE")]
			[Address(RVA = "0x8462F4", Offset = "0x8462F4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000029")]
		public bool ignoreTimeScale
		{
			[Token(Token = "0x60000FF")]
			[Address(RVA = "0x8462FC", Offset = "0x8462FC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000100")]
			[Address(RVA = "0x846304", Offset = "0x846304", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x846310", Offset = "0x846310", Length = "0x8")]
		public void TweenValue(float floatPercentage)
		{
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x846318", Offset = "0x846318", Length = "0x8")]
		public void AddOnChangedCallback(UnityAction<float> callback)
		{
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x846320", Offset = "0x846320", Length = "0x8")]
		public bool GetIgnoreTimescale()
		{
			return false;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x846328", Offset = "0x846328", Length = "0x8")]
		public float GetDuration()
		{
			return 0f;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x846330", Offset = "0x846330", Length = "0x1D8")]
		public bool ValidTarget()
		{
			return false;
		}
	}
}

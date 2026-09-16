using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x2000002")]
	public class AnimationTriggers
	{
		[Token(Token = "0x4000001")]
		private const string kDefaultNormalAnimName = "Normal";

		[Token(Token = "0x4000002")]
		private const string kDefaultHighlightedAnimName = "Highlighted";

		[Token(Token = "0x4000003")]
		private const string kDefaultPressedAnimName = "Pressed";

		[Token(Token = "0x4000004")]
		private const string kDefaultSelectedAnimName = "Selected";

		[Token(Token = "0x4000005")]
		private const string kDefaultDisabledAnimName = "Disabled";

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728098", Offset = "0x728098")]
		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		private string m_NormalTrigger;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7280E4", Offset = "0x7280E4")]
		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		private string m_HighlightedTrigger;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728130", Offset = "0x728130")]
		[SerializeField]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x20")]
		private string m_PressedTrigger;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x72817C", Offset = "0x72817C")]
		[SerializeField]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x28")]
		private string m_SelectedTrigger;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7281C8", Offset = "0x7281C8")]
		[SerializeField]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x30")]
		private string m_DisabledTrigger;

		[Token(Token = "0x17000001")]
		public string normalTrigger
		{
			[Token(Token = "0x6000001")]
			[Address(RVA = "0xC4BEC4", Offset = "0xC4BEC4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000002")]
			[Address(RVA = "0xC4BECC", Offset = "0xC4BECC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000002")]
		public string highlightedTrigger
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0xC4BED4", Offset = "0xC4BED4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000004")]
			[Address(RVA = "0xC4BEDC", Offset = "0xC4BEDC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000003")]
		public string pressedTrigger
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0xC4BEE4", Offset = "0xC4BEE4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000006")]
			[Address(RVA = "0xC4BEEC", Offset = "0xC4BEEC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000004")]
		public string selectedTrigger
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0xC4BEF4", Offset = "0xC4BEF4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000008")]
			[Address(RVA = "0xC4BEFC", Offset = "0xC4BEFC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000005")]
		public string disabledTrigger
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0xC4BF04", Offset = "0xC4BF04", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600000A")]
			[Address(RVA = "0xC4BF0C", Offset = "0xC4BF0C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0xC4BF14", Offset = "0xC4BF14", Length = "0x98")]
		public AnimationTriggers()
		{
		}
	}
}

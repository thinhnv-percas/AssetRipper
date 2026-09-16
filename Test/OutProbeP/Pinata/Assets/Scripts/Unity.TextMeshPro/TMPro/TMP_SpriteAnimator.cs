using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[DisallowMultipleComponent]
	[Token(Token = "0x200003E")]
	public class TMP_SpriteAnimator : MonoBehaviour
	{
		[Token(Token = "0x4000262")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<int, bool> m_animations;

		[Token(Token = "0x4000263")]
		[FieldOffset(Offset = "0x20")]
		private TMP_Text m_TextComponent;

		[Token(Token = "0x6000327")]
		[Address(RVA = "0x93B994", Offset = "0x93B994", Length = "0x58")]
		private void Awake()
		{
		}

		[Token(Token = "0x6000328")]
		[Address(RVA = "0x93B9EC", Offset = "0x93B9EC", Length = "0x4")]
		private void OnEnable()
		{
		}

		[Token(Token = "0x6000329")]
		[Address(RVA = "0x93B9F0", Offset = "0x93B9F0", Length = "0x4")]
		private void OnDisable()
		{
		}

		[Token(Token = "0x600032A")]
		[Address(RVA = "0x93B9F4", Offset = "0x93B9F4", Length = "0x64")]
		public void StopAllAnimations()
		{
		}

		[Token(Token = "0x600032B")]
		[Address(RVA = "0x93BA58", Offset = "0x93BA58", Length = "0xE4")]
		public void DoSpriteAnimation(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate)
		{
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7496B8", Offset = "0x7496B8")]
		[Token(Token = "0x600032C")]
		[Address(RVA = "0x93BB3C", Offset = "0x93BB3C", Length = "0xAC")]
		private IEnumerator DoSpriteAnimationInternal(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate)
		{
			return null;
		}

		[Token(Token = "0x600032D")]
		[Address(RVA = "0x93BC14", Offset = "0x93BC14", Length = "0x74")]
		public TMP_SpriteAnimator()
		{
		}
	}
}

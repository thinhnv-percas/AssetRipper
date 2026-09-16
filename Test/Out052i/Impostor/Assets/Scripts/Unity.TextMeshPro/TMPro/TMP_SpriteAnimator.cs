using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[DisallowMultipleComponent]
	[Token(Token = "0x200007D")]
	public class TMP_SpriteAnimator : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200007E")]
		private sealed class _003CDoSpriteAnimationInternal_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000413")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000414")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000415")]
			[FieldOffset(Offset = "0x20")]
			public TMP_SpriteAnimator _003C_003E4__this;

			[Token(Token = "0x4000416")]
			[FieldOffset(Offset = "0x28")]
			public int start;

			[Token(Token = "0x4000417")]
			[FieldOffset(Offset = "0x2C")]
			public int end;

			[Token(Token = "0x4000418")]
			[FieldOffset(Offset = "0x30")]
			public TMP_SpriteAsset spriteAsset;

			[Token(Token = "0x4000419")]
			[FieldOffset(Offset = "0x38")]
			public int currentCharacter;

			[Token(Token = "0x400041A")]
			[FieldOffset(Offset = "0x3C")]
			public int framerate;

			[Token(Token = "0x400041B")]
			[FieldOffset(Offset = "0x40")]
			private int _003CcurrentFrame_003E5__2;

			[Token(Token = "0x400041C")]
			[FieldOffset(Offset = "0x48")]
			private TMP_CharacterInfo _003CcharInfo_003E5__3;

			[Token(Token = "0x400041D")]
			[FieldOffset(Offset = "0x1C0")]
			private int _003CmaterialIndex_003E5__4;

			[Token(Token = "0x400041E")]
			[FieldOffset(Offset = "0x1C4")]
			private int _003CvertexIndex_003E5__5;

			[Token(Token = "0x400041F")]
			[FieldOffset(Offset = "0x1C8")]
			private TMP_MeshInfo _003CmeshInfo_003E5__6;

			[Token(Token = "0x4000420")]
			[FieldOffset(Offset = "0x218")]
			private float _003CbaseSpriteScale_003E5__7;

			[Token(Token = "0x4000421")]
			[FieldOffset(Offset = "0x21C")]
			private float _003CelapsedTime_003E5__8;

			[Token(Token = "0x4000422")]
			[FieldOffset(Offset = "0x220")]
			private float _003CtargetTime_003E5__9;

			[Token(Token = "0x170000E0")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000410")]
				[Address(RVA = "0x160B274", Offset = "0x160B274", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x170000E1")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000412")]
				[Address(RVA = "0x160B2B4", Offset = "0x160B2B4", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600040D")]
			[Address(RVA = "0x160A894", Offset = "0x160A894", Length = "0x28")]
			public _003CDoSpriteAnimationInternal_003Ed__7(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x600040E")]
			[Address(RVA = "0x160A93C", Offset = "0x160A93C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600040F")]
			[Address(RVA = "0x160A940", Offset = "0x160A940", Length = "0x910")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000411")]
			[Address(RVA = "0x160B27C", Offset = "0x160B27C", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[Token(Token = "0x4000411")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<int, bool> m_animations;

		[Token(Token = "0x4000412")]
		[FieldOffset(Offset = "0x28")]
		private TMP_Text m_TextComponent;

		[Token(Token = "0x6000406")]
		[Address(RVA = "0x160A660", Offset = "0x160A660", Length = "0x50")]
		private void Awake()
		{
		}

		[Token(Token = "0x6000407")]
		[Address(RVA = "0x160A6B0", Offset = "0x160A6B0", Length = "0x4")]
		private void OnEnable()
		{
		}

		[Token(Token = "0x6000408")]
		[Address(RVA = "0x160A6B4", Offset = "0x160A6B4", Length = "0x4")]
		private void OnDisable()
		{
		}

		[Token(Token = "0x6000409")]
		[Address(RVA = "0x160A6B8", Offset = "0x160A6B8", Length = "0x5C")]
		public void StopAllAnimations()
		{
		}

		[Token(Token = "0x600040A")]
		[Address(RVA = "0x160A714", Offset = "0x160A714", Length = "0xE8")]
		public void DoSpriteAnimation(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate)
		{
		}

		[IteratorStateMachine(typeof(_003CDoSpriteAnimationInternal_003Ed__7))]
		[Token(Token = "0x600040B")]
		[Address(RVA = "0x160A7FC", Offset = "0x160A7FC", Length = "0x98")]
		private IEnumerator DoSpriteAnimationInternal(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate)
		{
			return null;
		}

		[Token(Token = "0x600040C")]
		[Address(RVA = "0x160A8BC", Offset = "0x160A8BC", Length = "0x80")]
		public TMP_SpriteAnimator()
		{
		}
	}
}

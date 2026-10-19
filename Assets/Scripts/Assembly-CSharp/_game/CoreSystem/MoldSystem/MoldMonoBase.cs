using System;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004A6")]
	public abstract class MoldMonoBase : MonoBehaviour
	{
		[Token(Token = "0x170001B0")]
		public abstract Transform PourPoint
		{
			[Token(Token = "0x600136C")]
			get;
		}

		[Token(Token = "0x170001B1")]
		public abstract Renderer Renderer
		{
			[Token(Token = "0x600136D")]
			get;
		}

		[Token(Token = "0x600136E")]
		public abstract void Setup(IMoldMaterialProvider materialProvider);

		[Token(Token = "0x600136F")]
		internal abstract void SetOpen();

		[Token(Token = "0x6001370")]
		internal abstract void SetClosed();

		[Token(Token = "0x6001371")]
		internal abstract void SetOpen_Editor();

		[Token(Token = "0x6001372")]
		internal abstract void SetClosed_Editor();

		[Token(Token = "0x6001373")]
		internal abstract void PlayCoverOpen();

		[Token(Token = "0x6001374")]
		internal abstract void PlayCoverClose();

		[Token(Token = "0x6001375")]
		internal abstract void PlayOnlyCoverClose();

		[Token(Token = "0x6001376")]
		public abstract void UpdateVisualFill(float fillRate);

		[Token(Token = "0x6001377")]
		public abstract void StartFill();

		[Token(Token = "0x6001378")]
		public abstract void StopFill();

		[Token(Token = "0x6001379")]
		public abstract void ApplyMaterial(GameColor color, bool isHidden);

		[Token(Token = "0x600137A")]
		internal abstract void Reveal(GameColor color, Action onComplete);

		[Token(Token = "0x600137B")]
		public abstract Sequence BuildRevealSequence(GameColor color);

		[Token(Token = "0x600137C")]
		public abstract void SnapToRevealed();

		[Token(Token = "0x600137D")]
		public abstract void PlayCompleteVfx();

		[Token(Token = "0x600137E")]
		[Address(RVA = "0x3CEBB08", Offset = "0x3CEBB08", Length = "0x8")]
		protected internal MoldMonoBase()
		{
		}
	}
}

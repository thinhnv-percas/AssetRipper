using Cpp2ILInjected;
using HighlightPlus;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Configs
{
	[CreateAssetMenu(fileName = "MoldSwapConfig", menuName = "Sand Out/MoldSwap/Config")]
	[Token(Token = "0x200048D")]
	public class MoldSwapConfigSO : ScriptableObject
	{
		[Header("Behavior")]
		[Token(Token = "0x4000ED7")]
		[FieldOffset(Offset = "0x18")]
		public bool alwaysSwap;

		[Header("Showcase Grid")]
		[Token(Token = "0x4000ED8")]
		[FieldOffset(Offset = "0x1C")]
		public Vector3 showcaseCenter;

		[Token(Token = "0x4000ED9")]
		[FieldOffset(Offset = "0x28")]
		public float showcaseWidth;

		[Token(Token = "0x4000EDA")]
		[FieldOffset(Offset = "0x2C")]
		public float showcaseHeight;

		[Token(Token = "0x4000EDB")]
		[FieldOffset(Offset = "0x30")]
		public float maxShowcaseScale;

		[Token(Token = "0x4000EDC")]
		[FieldOffset(Offset = "0x34")]
		public float showcaseSpacing;

		[Header("Stagger")]
		[Token(Token = "0x4000EDD")]
		[FieldOffset(Offset = "0x38")]
		public Vector2 staggerRange;

		[Header("Arc Up")]
		[Token(Token = "0x4000EDE")]
		[FieldOffset(Offset = "0x40")]
		public TweenSettings arcUpX;

		[Token(Token = "0x4000EDF")]
		[FieldOffset(Offset = "0x70")]
		public TweenSettings arcUpY;

		[Token(Token = "0x4000EE0")]
		[FieldOffset(Offset = "0xA0")]
		public TweenSettings arcUpZ;

		[Token(Token = "0x4000EE1")]
		[FieldOffset(Offset = "0xD0")]
		public TweenSettings scaleToShowcase;

		[Header("Showcase Swap")]
		[Token(Token = "0x4000EE2")]
		[FieldOffset(Offset = "0x100")]
		public bool enableShowcaseSwap;

		[Token(Token = "0x4000EE3")]
		[FieldOffset(Offset = "0x108")]
		public TweenSettings showcaseSwapX;

		[Token(Token = "0x4000EE4")]
		[FieldOffset(Offset = "0x138")]
		public TweenSettings showcaseSwapY;

		[Token(Token = "0x4000EE5")]
		[FieldOffset(Offset = "0x168")]
		public TweenSettings showcaseSwapZ;

		[Header("Showcase Hold")]
		[Token(Token = "0x4000EE6")]
		[FieldOffset(Offset = "0x198")]
		public Vector2 showcaseHoldDelayRange;

		[Header("Arc Down")]
		[Token(Token = "0x4000EE7")]
		[FieldOffset(Offset = "0x1A0")]
		public TweenSettings arcDownX;

		[Token(Token = "0x4000EE8")]
		[FieldOffset(Offset = "0x1D0")]
		public TweenSettings arcDownY;

		[Token(Token = "0x4000EE9")]
		[FieldOffset(Offset = "0x200")]
		public TweenSettings arcDownZ;

		[Token(Token = "0x4000EEA")]
		[FieldOffset(Offset = "0x230")]
		public TweenSettings scaleToOriginal;

		[Header("Highlight")]
		[Token(Token = "0x4000EEB")]
		[FieldOffset(Offset = "0x260")]
		public HighlightProfile swapHighlightProfile;

		[Header("Backdrop")]
		[Token(Token = "0x4000EEC")]
		[FieldOffset(Offset = "0x268")]
		public float backdropMaxAlpha;

		[Token(Token = "0x4000EED")]
		[FieldOffset(Offset = "0x270")]
		public TweenSettings backdropFadeIn;

		[Token(Token = "0x4000EEE")]
		[FieldOffset(Offset = "0x2A0")]
		public TweenSettings backdropFadeOut;

		[Token(Token = "0x4000EEF")]
		[FieldOffset(Offset = "0x2D0")]
		public int backdropSortingOrder;

		[Token(Token = "0x60012EC")]
		[Address(RVA = "0x3CE1730", Offset = "0x3CE1730", Length = "0x64")]
		public MoldSwapConfigSO()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapConfigSO::.ctor");
		}
	}
}

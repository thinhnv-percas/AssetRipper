using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Video;

namespace _game.CoreGameKit.CoreSerivces.FeatureUnlock
{
	[Serializable]
	[Token(Token = "0x2000614")]
	public class FeatureUnlockData
	{
		[Token(Token = "0x40014F9")]
		[FieldOffset(Offset = "0x10")]
		public string featureId;

		[Token(Token = "0x40014FA")]
		[FieldOffset(Offset = "0x18")]
		public string featureName;

		[Token(Token = "0x40014FB")]
		[FieldOffset(Offset = "0x20")]
		public string featureDescription;

		[Token(Token = "0x40014FC")]
		[FieldOffset(Offset = "0x28")]
		public Sprite featureIcon;

		[Token(Token = "0x40014FD")]
		[FieldOffset(Offset = "0x30")]
		public Sprite featureShowcaseImage;

		[Token(Token = "0x40014FE")]
		[FieldOffset(Offset = "0x38")]
		public VideoClip VideoClip;

		[Header("Video Framing")]
		[Token(Token = "0x40014FF")]
		[FieldOffset(Offset = "0x40")]
		public Vector2 videoPositionOffset;

		[Token(Token = "0x4001500")]
		[FieldOffset(Offset = "0x48")]
		public float videoScale;

		[Token(Token = "0x4001501")]
		[FieldOffset(Offset = "0x4C")]
		public Vector2 videoRect;

		[Header("Win UI Settings")]
		[Token(Token = "0x4001502")]
		[FieldOffset(Offset = "0x54")]
		public bool showProgressInWinUi;

		[Header("Booster Unlock Override")]
		[Token(Token = "0x4001503")]
		[FieldOffset(Offset = "0x58")]
		public Sprite titleSprite;

		[Token(Token = "0x4001504")]
		[FieldOffset(Offset = "0x60")]
		public bool hideFrame;

		[Token(Token = "0x17000281")]
		public bool isVideo
		{
			[Token(Token = "0x6001A15")]
			[Address(RVA = "0x3D50114", Offset = "0x3D50114", Length = "0x6C")]
			get
			{
				return VideoClip != null;
			}
		}

		[Token(Token = "0x6001A16")]
		[Address(RVA = "0x3D50180", Offset = "0x3D50180", Length = "0x18")]
		public FeatureUnlockData()
		{
			videoScale = 1f;
			showProgressInWinUi = true;
		}
	}
}

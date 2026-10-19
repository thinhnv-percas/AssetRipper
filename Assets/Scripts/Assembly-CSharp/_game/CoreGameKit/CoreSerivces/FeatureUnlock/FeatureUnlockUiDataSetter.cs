using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.TextViewSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.CoreSerivces.FeatureUnlock
{
	[Token(Token = "0x2000618")]
	public class FeatureUnlockUiDataSetter : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400150D")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_featureDescriptionText;

		[SerializeField]
		[Token(Token = "0x400150E")]
		[FieldOffset(Offset = "0x28")]
		private TextView m_featureTitleText;

		[SerializeField]
		[Token(Token = "0x400150F")]
		[FieldOffset(Offset = "0x30")]
		private Image m_featureIconImage;

		[SerializeField]
		[Token(Token = "0x4001510")]
		[FieldOffset(Offset = "0x38")]
		private RawImage m_videoRawImage;

		[SerializeField]
		[Token(Token = "0x4001511")]
		[FieldOffset(Offset = "0x40")]
		private VideoPlayer m_videoPlayer;

		[Header("Booster Override")]
		[SerializeField]
		[Token(Token = "0x4001512")]
		[FieldOffset(Offset = "0x48")]
		private Image m_titleSpriteImage;

		[SerializeField]
		[Token(Token = "0x4001513")]
		[FieldOffset(Offset = "0x50")]
		private GameObject m_frame;

		[Inject(false)]
		[Token(Token = "0x6001A22")]
		[Address(RVA = "0x3D50CF0", Offset = "0x3D50CF0", Length = "0xDC")]
		private void Inject(ILevel level, FeatureUnlockDatabase database)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FeatureUnlockUiDataSetter::Inject");
		}

		[Token(Token = "0x6001A23")]
		[Address(RVA = "0x3D50DCC", Offset = "0x3D50DCC", Length = "0x430")]
		public void SetData(FeatureUnlockData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FeatureUnlockUiDataSetter::SetData");
		}

		[Token(Token = "0x6001A24")]
		[Address(RVA = "0x3D511FC", Offset = "0x3D511FC", Length = "0x8")]
		public FeatureUnlockUiDataSetter()
		{
		}
	}
}

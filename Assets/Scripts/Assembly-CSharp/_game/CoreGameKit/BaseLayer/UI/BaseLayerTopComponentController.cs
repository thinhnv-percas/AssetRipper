using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.TextViewSystem;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000637")]
	public class BaseLayerTopComponentController : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400156D")]
		[FieldOffset(Offset = "0x20")]
		private ComponentStateHandler m_componentStateHandler;

		[SerializeField]
		[Token(Token = "0x400156E")]
		[FieldOffset(Offset = "0x28")]
		private TextView m_levelText;

		[Inject(false)]
		[Token(Token = "0x6001A93")]
		[Address(RVA = "0x3D551B4", Offset = "0x3D551B4", Length = "0x1B8")]
		public void Initialize(ILevel level, ILevelProgressService progressService)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTopComponentController::Initialize");
		}

		[Token(Token = "0x6001A94")]
		[Address(RVA = "0x3D5536C", Offset = "0x3D5536C", Length = "0x8")]
		public BaseLayerTopComponentController()
		{
		}
	}
}

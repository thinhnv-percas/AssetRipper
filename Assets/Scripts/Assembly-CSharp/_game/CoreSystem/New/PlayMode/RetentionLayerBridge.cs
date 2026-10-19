using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003E7")]
	public class RetentionLayerBridge : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000C6A")]
		[FieldOffset(Offset = "0x20")]
		private GameplayContainerController m_controller;

		[Inject(false)]
		[Token(Token = "0x6001074")]
		[Address(RVA = "0x3CB3FDC", Offset = "0x3CB3FDC", Length = "0x428")]
		public void Construct(ContainerManager containerManager, LevelContext ctx, ILevel level, ILevelProgressService progressService, ILevelList _levelList, RemoteConfigManager remoteConfigManager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RetentionLayerBridge::Construct");
		}

		[Token(Token = "0x6001075")]
		[Address(RVA = "0x3CB4404", Offset = "0x3CB4404", Length = "0x8")]
		public RetentionLayerBridge()
		{
		}
	}
}

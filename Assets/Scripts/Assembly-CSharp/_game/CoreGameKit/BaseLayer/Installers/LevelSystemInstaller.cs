using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Core;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006AB")]
	public class LevelSystemInstaller : InstallerSO, ILevelSystemInstaller, IContainerInstaller
	{
		[SerializeField]
		[Token(Token = "0x400169C")]
		[FieldOffset(Offset = "0x18")]
		private LevelListSo m_levelListSo;

		[Token(Token = "0x6001C30")]
		[Address(RVA = "0x3D69B94", Offset = "0x3D69B94", Length = "0x2DC")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelSystemInstaller::InstallBindings");
		}

		[Token(Token = "0x6001C31")]
		[Address(RVA = "0x3D69E70", Offset = "0x3D69E70", Length = "0x8")]
		public LevelSystemInstaller()
		{
		}
	}
}

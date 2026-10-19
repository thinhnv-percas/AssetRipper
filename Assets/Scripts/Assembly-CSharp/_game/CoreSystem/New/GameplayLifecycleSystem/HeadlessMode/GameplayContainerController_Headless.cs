using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Installers;
using _game.CoreSystem.New.MoldSystem.HeadlessMode;
using _game.CoreSystem.New.MoldSystem.Installers;
using _game.CoreSystem.New.TopGridSystem.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers.HeadlessMode;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.HeadlessMode
{
	[Token(Token = "0x2000400")]
	public class GameplayContainerController_Headless : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000CAB")]
		[FieldOffset(Offset = "0x20")]
		private MoldSystemCoreInstaller m_moldSystemCoreInstaller;

		[SerializeField]
		[Token(Token = "0x4000CAC")]
		[FieldOffset(Offset = "0x28")]
		private TopGridCommonInstaller m_topGridSystemInstaller;

		[SerializeField]
		[Token(Token = "0x4000CAD")]
		[FieldOffset(Offset = "0x30")]
		private TunnelInstaller_Headless m_tunnelInstaller;

		[SerializeField]
		[Token(Token = "0x4000CAE")]
		[FieldOffset(Offset = "0x38")]
		private SandCubeInstaller_Headless m_sandCubeInstaller;

		[SerializeField]
		[Token(Token = "0x4000CAF")]
		[FieldOffset(Offset = "0x40")]
		private KeyAndLockInstaller_Headless m_keyAndLockInstaller;

		[SerializeField]
		[Token(Token = "0x4000CB0")]
		[FieldOffset(Offset = "0x48")]
		private GarageInstaller_Headless m_garageInstaller;

		[SerializeField]
		[Token(Token = "0x4000CB1")]
		[FieldOffset(Offset = "0x50")]
		private LinkedCubeInstaller_Headless m_linkedCubeInstaller;

		[SerializeField]
		[Token(Token = "0x4000CB2")]
		[FieldOffset(Offset = "0x58")]
		private SnakeInstaller_Headless m_snakeInstaller;

		[SerializeField]
		[Token(Token = "0x4000CB3")]
		[FieldOffset(Offset = "0x60")]
		private PinInstaller_Headless m_pinInstaller;

		[SerializeField]
		[Token(Token = "0x4000CB4")]
		[FieldOffset(Offset = "0x68")]
		private GameplayCommonInstaller m_coreInstaller;

		[Token(Token = "0x60010CF")]
		[Address(RVA = "0x3CB8A50", Offset = "0x3CB8A50", Length = "0x3C")]
		private void Open_test(LevelSo so)
		{
			LevelSerializable level = so.CreateLevelSerializable();
			HeadlessSimulationHandle headlessSimulationHandle = CreateContainer(level);
		}

		[Token(Token = "0x60010D0")]
		[Address(RVA = "0x3CB8A8C", Offset = "0x3CB8A8C", Length = "0xC48")]
		public HeadlessSimulationHandle CreateContainer(ILevel level)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayContainerController_Headless::CreateContainer");
			return default;
		}

		[Token(Token = "0x60010D1")]
		[Address(RVA = "0x3CB981C", Offset = "0x3CB981C", Length = "0x8")]
		public GameplayContainerController_Headless()
		{
		}
	}
}

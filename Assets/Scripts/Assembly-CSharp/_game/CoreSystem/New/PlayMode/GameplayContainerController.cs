using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.EventBusSystem.Runtime;
using Unco.GameBootstrap.Core;
using Unco.RewardSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.BoosterSystem.ForcePour.Installers;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Installers;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.Installers;
using _game.CoreSystem.New.GameplayAreaSystem.Installers;
using _game.CoreSystem.New.GameplayLifecycleSystem;
using _game.CoreSystem.New.GameplayLifecycleSystem.CertainWinSpeedUp.Installers;
using _game.CoreSystem.New.GameplayLifecycleSystem.ConveyorWarning.Installer;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.Installers;
using _game.CoreSystem.New.GameplayLifecycleSystem.PlayMode;
using _game.CoreSystem.New.GameplayLifecycleSystem.Shared;
using _game.CoreSystem.New.GameplayLifecycleSystem.TapHoldSpeedUp.Installers;
using _game.CoreSystem.New.GameplayLifecycleSystem.TimeScale.Installers;
using _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck.Installers;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.PlayMode;
using _game.CoreSystem.New.MoldSystem.Installers;
using _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.Installers;
using _game.CoreSystem.New.MoldSystem.PlayMode;
using _game.CoreSystem.New.TopGridSystem.InputSystem.Installers;
using _game.CoreSystem.New.TopGridSystem.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers;
using _game.CoreSystem.New.TopGridSystem.PlayMode;
using _game.CoreSystem.New.TopGridSystem.Runtime;
using _game.CoreSystem.SandPhysics.PlayMode;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003DF")]
	public class GameplayContainerController : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000C21")]
		[FieldOffset(Offset = "0x20")]
		private MoldSystemCoreInstaller m_moldSystemCoreInstaller;

		[SerializeField]
		[Token(Token = "0x4000C22")]
		[FieldOffset(Offset = "0x28")]
		private HammerInstaller m_hammerInstaller;

		[SerializeField]
		[Token(Token = "0x4000C23")]
		[FieldOffset(Offset = "0x30")]
		private TopGridCommonInstaller m_topGridSystemInstaller;

		[SerializeField]
		[Token(Token = "0x4000C24")]
		[FieldOffset(Offset = "0x38")]
		private TopGridSystemPlayModeInstaller m_topGridPlayModeInstaller;

		[SerializeField]
		[Token(Token = "0x4000C25")]
		[FieldOffset(Offset = "0x40")]
		private TunnelInstaller m_tunnelInstaller;

		[SerializeField]
		[Token(Token = "0x4000C26")]
		[FieldOffset(Offset = "0x48")]
		private SandCubeInstaller m_sandCubeInstaller;

		[SerializeField]
		[Token(Token = "0x4000C27")]
		[FieldOffset(Offset = "0x50")]
		private KeyAndLockInstaller m_keyAndLockInstaller;

		[SerializeField]
		[Token(Token = "0x4000C28")]
		[FieldOffset(Offset = "0x58")]
		private GarageInstaller m_garageInstaller;

		[SerializeField]
		[Token(Token = "0x4000C29")]
		[FieldOffset(Offset = "0x60")]
		private HammerAreaInstaller m_hammerAreaInstaller;

		[SerializeField]
		[Token(Token = "0x4000C2A")]
		[FieldOffset(Offset = "0x68")]
		private LinkedCubeInstaller m_linkedCubeInstaller;

		[SerializeField]
		[Token(Token = "0x4000C2B")]
		[FieldOffset(Offset = "0x70")]
		private SnakeInstaller m_snakeInstaller;

		[SerializeField]
		[Token(Token = "0x4000C2C")]
		[FieldOffset(Offset = "0x78")]
		private PinInstaller m_pinInstaller;

		[SerializeField]
		[Token(Token = "0x4000C2D")]
		[FieldOffset(Offset = "0x80")]
		private GameplayCommonInstaller m_coreInstaller;

		[SerializeField]
		[Token(Token = "0x4000C2E")]
		[FieldOffset(Offset = "0x88")]
		private SandPhysicsPlayModeInstaller m_sandPhysicsInstaller;

		[SerializeField]
		[Token(Token = "0x4000C2F")]
		[FieldOffset(Offset = "0x90")]
		private GameplayAreaInstaller m_areaInstaller;

		[SerializeField]
		[Token(Token = "0x4000C30")]
		[FieldOffset(Offset = "0x98")]
		private InputInstaller m_inputInstaller;

		[SerializeField]
		[Token(Token = "0x4000C31")]
		[FieldOffset(Offset = "0xA0")]
		private MoldSwapInstaller m_moldSwapInstaller;

		[SerializeField]
		[Token(Token = "0x4000C32")]
		[FieldOffset(Offset = "0xA8")]
		private VacuumBoosterInstaller m_vacuumBoosterInstaller;

		[SerializeField]
		[Token(Token = "0x4000C33")]
		[FieldOffset(Offset = "0xB0")]
		private ForcePourInstaller m_forcePourInstaller;

		[SerializeField]
		[Token(Token = "0x4000C34")]
		[FieldOffset(Offset = "0xB8")]
		private SRDebuggerInstaller m_srDebuggerInstaller;

		[SerializeField]
		[Token(Token = "0x4000C35")]
		[FieldOffset(Offset = "0xC0")]
		private SRDebuggerOptionInstallerSO[] m_srOptions;

		[Token(Token = "0x4000C36")]
		[FieldOffset(Offset = "0xC8")]
		private ContainerManager _containerManager;

		[Token(Token = "0x4000C37")]
		[FieldOffset(Offset = "0xD0")]
		private List<IContainerInstaller> _installers;

		[Token(Token = "0x1700014A")]
		public ContainerManager ContainerManager
		{
			[Token(Token = "0x6001043")]
			[Address(RVA = "0x3CAF344", Offset = "0x3CAF344", Length = "0x8")]
			get
			{
				return _containerManager;
			}
		}

		[Token(Token = "0x6001044")]
		[Address(RVA = "0x3CAF34C", Offset = "0x3CAF34C", Length = "0x178")]
		public void OpenLevel(LevelSo so)
		{
			bool flag = so != null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			LevelSerializable levelSerializable = null;
			LevelSerializable levelSerializable2;
			if (!flag3)
			{
				levelSerializable2 = levelSerializable;
			}
			else
			{
				LevelSerializable levelSerializable3 = so.CreateLevelSerializable();
				levelSerializable = levelSerializable3;
				levelSerializable2 = levelSerializable3;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X0_v35 (Il2CppClass<System.EmptyArray`1<Unco.ContainerSystem.Runtime.IContainerInstaller>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag4 = num2 == 0;
			nint num3 = 0;
			levelSerializable2 = levelSerializable;
			nint num6;
			if (flag4)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X0_v11+E4]");
				bool flag5 = (nint)0 == 0;
				bool flag6 = !flag5;
				levelSerializable = levelSerializable2;
				if (!flag6)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ X0_v9 (Il2CppClass<System.EmptyArray`1<Unco.ContainerSystem.Runtime.IContainerInstaller>>)+135]");
					int num5 = (int)((nint)0 & (nint)1);
					bool flag7 = num5 == 0;
					bool flag8 = !flag7;
					levelSerializable = levelSerializable2;
					num6 = 0;
					if (flag8)
					{
						goto IL_00e2;
					}
					goto IL_0235;
				}
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ X0_v32 (Il2CppClass<System.EmptyArray`1<Unco.ContainerSystem.Runtime.IContainerInstaller>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag9 = num8 == 0;
			num6 = 0;
			levelSerializable2 = levelSerializable;
			if (!flag9)
			{
				goto IL_00e2;
			}
			goto IL_0235;
			IL_0235:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			ILevel level = levelSerializable2;
			goto IL_0251;
			IL_0251:
			OpenLevel(level);
			return;
			IL_00e2:
			bool flag10 = (object)this == null;
			bool flag11 = !flag10;
			level = levelSerializable;
			if (!flag11)
			{
				throw new NullReferenceException();
			}
			goto IL_0251;
		}

		[Token(Token = "0x6001045")]
		[Address(RVA = "0x3CAF4C4", Offset = "0x3CAF4C4", Length = "0x298")]
		public void OpenLevel(ILevel level, params IContainerInstaller[] additional)
		{
			if (level != null)
			{
				if (ContainerManager != null && ContainerManager.Exists<GameplayContainer>())
				{
					ContainerManager.DisposeContainer<GameplayContainer>();
				}
				SetupInstallers(level);
				if (additional.Length >= 1)
				{
					int num = 0;
					do
					{
						List<IContainerInstaller> installers = _installers;
						installers.Add(additional[num]);
						num++;
					}
					while (num < additional.Length);
				}
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ X0_v30 (Il2CppClass<System.EmptyArray`1<Unco.ContainerSystem.Runtime.IContainerInstaller>>)+135]");
				int num3 = (int)((nint)0 & (nint)1);
				bool flag = num3 == 0;
				nint num4 = 0;
				if (flag)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				}
				ContainerManager containerManager = new ContainerManager();
				_containerManager = containerManager;
				ContainerManager.Scope<GameplayContainer>(_installers);
				PrimeReconcileVisuals();
			}
			else
			{
				Debug.LogError("[GameplayContainerController] OpenLevel called with null level.");
			}
		}

		[Token(Token = "0x6001046")]
		[Address(RVA = "0x3CAFDC8", Offset = "0x3CAFDC8", Length = "0xB8")]
		public void OpenLevelAsChild(ContainerManager manager, params IContainerInstaller[] extraInstallers)
		{
			SetupInstallersAsChild();
			if (extraInstallers != null)
			{
				_installers.AddRange(extraInstallers);
			}
			_containerManager = manager;
			ContainerManager.Scope<GameplayContainer, FeatureContainer>(_installers);
			PrimeReconcileVisuals();
		}

		[Token(Token = "0x6001047")]
		[Address(RVA = "0x3CAFC68", Offset = "0x3CAFC68", Length = "0x160")]
		private void PrimeReconcileVisuals()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayContainerController::PrimeReconcileVisuals");
		}

		[Token(Token = "0x6001048")]
		[Address(RVA = "0x3CB045C", Offset = "0x3CB045C", Length = "0x88")]
		public void DisposeLevel()
		{
			if (ContainerManager != null && ContainerManager.Exists<GameplayContainer>())
			{
				ContainerManager.DisposeContainer<GameplayContainer>();
			}
		}

		[Token(Token = "0x6001049")]
		[Address(RVA = "0x3CAF75C", Offset = "0x3CAF75C", Length = "0x50C")]
		private unsafe void SetupInstallers(ILevel level)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayContainerController::SetupInstallers");
		}

		[Token(Token = "0x600104A")]
		[Address(RVA = "0x3CAFE80", Offset = "0x3CAFE80", Length = "0x5DC")]
		private void SetupInstallersAsChild()
		{
			List<IContainerInstaller> installers = new List<IContainerInstaller>();
			_installers = installers;
			List<IContainerInstaller> installers2 = _installers;
			GameplayContainerRootInstaller item = new GameplayContainerRootInstaller(isPlaying: true);
			installers2.Add(item);
			List<IContainerInstaller> installers3 = _installers;
			GameSpeedConfigInstaller item2 = new GameSpeedConfigInstaller();
			installers3.Add(item2);
			List<IContainerInstaller> installers4 = _installers;
			WinCheckInstaller item3 = new WinCheckInstaller();
			installers4.Add(item3);
			List<IContainerInstaller> installers5 = _installers;
			FailCheckInstaller item4 = new FailCheckInstaller();
			installers5.Add(item4);
			List<IContainerInstaller> installers6 = _installers;
			GameSpeedInstaller item5 = new GameSpeedInstaller();
			installers6.Add(item5);
			List<IContainerInstaller> installers7 = _installers;
			GameplaySpeedInstaller item6 = new GameplaySpeedInstaller();
			installers7.Add(item6);
			List<IContainerInstaller> installers8 = _installers;
			TimeScaleInstaller item7 = new TimeScaleInstaller();
			installers8.Add(item7);
			List<IContainerInstaller> installers9 = _installers;
			CertainWinSpeedUpInstaller item8 = new CertainWinSpeedUpInstaller();
			installers9.Add(item8);
			List<IContainerInstaller> installers10 = _installers;
			TapHoldSpeedUpInstaller item9 = new TapHoldSpeedUpInstaller();
			installers10.Add(item9);
			SetupInstallers_common();
		}

		[Token(Token = "0x600104B")]
		[Address(RVA = "0x3CB0528", Offset = "0x3CB0528", Length = "0xC70")]
		private void SetupInstallers_common()
		{
			List<IContainerInstaller> installers = _installers;
			installers.Add(m_coreInstaller);
			List<IContainerInstaller> installers2 = _installers;
			installers2.Add(m_moldSystemCoreInstaller);
			List<IContainerInstaller> installers3 = _installers;
			MoldSystemPlayModeInstaller item = new MoldSystemPlayModeInstaller();
			installers3.Add(item);
			List<IContainerInstaller> installers4 = _installers;
			MoldFillDisplayInstaller item2 = new MoldFillDisplayInstaller();
			installers4.Add(item2);
			UnityEngine.Object hammerInstaller = m_hammerInstaller;
			if (hammerInstaller != null)
			{
				List<IContainerInstaller> installers5 = _installers;
				installers5.Add(m_hammerInstaller);
			}
			List<IContainerInstaller> installers6 = _installers;
			GameSpeedInstaller item3 = new GameSpeedInstaller();
			installers6.Add(item3);
			List<IContainerInstaller> installers7 = _installers;
			installers7.Add(m_topGridSystemInstaller);
			List<IContainerInstaller> installers8 = _installers;
			installers8.Add(m_tunnelInstaller);
			List<IContainerInstaller> installers9 = _installers;
			installers9.Add(m_sandCubeInstaller);
			List<IContainerInstaller> installers10 = _installers;
			installers10.Add(m_keyAndLockInstaller);
			List<IContainerInstaller> installers11 = _installers;
			installers11.Add(m_garageInstaller);
			UnityEngine.Object hammerAreaInstaller = m_hammerAreaInstaller;
			if (hammerAreaInstaller != null)
			{
				List<IContainerInstaller> installers12 = _installers;
				installers12.Add(m_hammerAreaInstaller);
			}
			List<IContainerInstaller> installers13 = _installers;
			installers13.Add(m_linkedCubeInstaller);
			List<IContainerInstaller> installers14 = _installers;
			installers14.Add(m_snakeInstaller);
			UnityEngine.Object pinInstaller = m_pinInstaller;
			if (pinInstaller != null)
			{
				List<IContainerInstaller> installers15 = _installers;
				installers15.Add(m_pinInstaller);
			}
			List<IContainerInstaller> installers16 = _installers;
			installers16.Add(m_topGridPlayModeInstaller);
			List<IContainerInstaller> installers17 = _installers;
			installers17.Add(m_sandPhysicsInstaller);
			List<IContainerInstaller> installers18 = _installers;
			installers18.Add(m_areaInstaller);
			List<IContainerInstaller> installers19 = _installers;
			installers19.Add(m_inputInstaller);
			List<IContainerInstaller> installers20 = _installers;
			GameplayFeedbackInstaller item4 = new GameplayFeedbackInstaller();
			installers20.Add(item4);
			List<IContainerInstaller> installers21 = _installers;
			ConveyorWarningInstaller item5 = new ConveyorWarningInstaller();
			installers21.Add(item5);
			UnityEngine.Object moldSwapInstaller = m_moldSwapInstaller;
			UnityEngine.Object forcePourInstaller;
			if (moldSwapInstaller != null)
			{
				List<IContainerInstaller> installers22 = _installers;
				installers22.Add(m_moldSwapInstaller);
				forcePourInstaller = m_forcePourInstaller;
			}
			else
			{
				forcePourInstaller = m_forcePourInstaller;
			}
			UnityEngine.Object vacuumBoosterInstaller;
			if (forcePourInstaller != null)
			{
				List<IContainerInstaller> installers23 = _installers;
				installers23.Add(m_forcePourInstaller);
				vacuumBoosterInstaller = m_vacuumBoosterInstaller;
			}
			else
			{
				vacuumBoosterInstaller = m_vacuumBoosterInstaller;
			}
			if (vacuumBoosterInstaller != null)
			{
				List<IContainerInstaller> installers24 = _installers;
				installers24.Add(m_vacuumBoosterInstaller);
			}
			SRDebuggerOptionInstallerSO[] srOptions = m_srOptions;
			if (srOptions.Length >= 1)
			{
				int num = 0;
				do
				{
					List<IContainerInstaller> installers25 = _installers;
					installers25.Add(srOptions[num]);
					num++;
				}
				while (num < srOptions.Length);
			}
		}

		[Token(Token = "0x600104C")]
		[Address(RVA = "0x3CB11E0", Offset = "0x3CB11E0", Length = "0x88")]
		private void OnDestroy()
		{
			if (ContainerManager != null && ContainerManager.Exists<GameplayContainer>())
			{
				ContainerManager.DisposeContainer<GameplayContainer>();
			}
		}

		[Token(Token = "0x600104D")]
		[Address(RVA = "0x3CB1268", Offset = "0x3CB1268", Length = "0x8")]
		public GameplayContainerController()
		{
		}
	}
}

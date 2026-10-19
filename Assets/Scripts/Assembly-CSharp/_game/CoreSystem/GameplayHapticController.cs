using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Lofelt.NiceVibrations;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.SettingsSyste.Core;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.New.MoldSystem;

namespace _game.CoreSystem
{
	[Token(Token = "0x2000084")]
	public class GameplayHapticController : IDisposable
	{
		[Inject(true)]
		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x10")]
		private HapticManager _hapticManager;

		[Inject(false)]
		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x20")]
		private MoldAbsorptionBridge _bridge;

		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x28")]
		private ConveyorController _conveyor;

		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x30")]
		private int _prevConveyorCount;

		[Inject(false)]
		[Token(Token = "0x6000238")]
		[Address(RVA = "0x3C756E4", Offset = "0x3C756E4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tUnco.EventBusSystem.Runtime.EventBus::ListenEvent(this._eventBus, v49);\n\treturn;\nL_0020:\n\tv49 = new System.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>();\n\tSystem.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>::.ctor(v49, this, Il2CppMethodInfo);\n")]
		private void Construct()
		{
			Action<UventLevelFailed> observer = OnLevelFailed;
			_eventBus.ListenEvent(observer);
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0x3C7578C", Offset = "0x3C7578C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv74 = this._bridge == 0;\n\tif (v74) goto L_0054;\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::add_OnMoldVisualComplete(this._bridge, v64);\n\tv90 = new System.Action();\n\tSystem.Action::.ctor(v90, this, Il2CppMethodInfo);\n\tv92 = this._bridge == 0;\n\tif (v92) goto L_0054;\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::add_OnParticleAbsorbed(this._bridge, v90);\n\treturn;\nL_0054:\n\tthrow v64;\nL_0027:\n\tthis._bridge = v48;\n\tv64 = new System.Action`2<System.Int32, System.Int32>();\n\tSystem.Action`2<System.Int32, System.Int32>::.ctor(v64, this, Il2CppMethodInfo);\n")]
		public void BindMoldEvents(MoldAbsorptionBridge bridge)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayHapticController::BindMoldEvents");
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0x3C7589C", Offset = "0x3C7589C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv67 = new System.Action`2<System.Int32, System.Int32>();\n\tSystem.Action`2<System.Int32, System.Int32>::.ctor(v67, this, Il2CppMethodInfo);\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::remove_OnMoldVisualComplete(this._bridge, v67);\n\tv127 = new System.Action();\n\tSystem.Action::.ctor(v127, this, Il2CppMethodInfo);\n\tv113 = this._bridge == 0;\n\tif (v113) goto L_0063;\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::remove_OnParticleAbsorbed(this._bridge, v127);\n\tthis._bridge = 0;\n\treturn;\nL_0062:\n\treturn;\nL_0063:\n\tthrow v127;\nL_0024:\n\tv54 = this._bridge == 0;\n\tif (v54) goto L_0062;\n")]
		public void UnbindMoldEvents()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayHapticController::UnbindMoldEvents");
		}

		[Token(Token = "0x600023B")]
		[Address(RVA = "0x3C759C8", Offset = "0x3C759C8", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(conveyor, 0);\n\tv62 = v53 == 0;\n\tif (v62) goto L_003F;\n\treturn;\nL_003F:\n\tthis._conveyor = conveyor;\n\tv119 = this._conveyor;\n\tthis._prevConveyorCount = v119.CurrentParticleCount;\n\tv126 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v126, this, Il2CppMethodInfo);\n\t_game.CoreSystem.ConveyorSystem.ConveyorController::add_OnParticleCountChanged(v119, v126);\n\treturn;\n")]
		public void BindConveyor(ConveyorController conveyor)
		{
			if (!(conveyor == null))
			{
				_conveyor = conveyor;
				ConveyorController conveyor2 = _conveyor;
				_prevConveyorCount = conveyor2.CurrentParticleCount;
				Action<int> value = OnConveyorCountUpdated;
				conveyor2.add_OnParticleCountChanged(value);
			}
		}

		[Token(Token = "0x600023C")]
		[Address(RVA = "0x3C75AE4", Offset = "0x3C75AE4", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Equality(this._conveyor, 0);\n\tv74 = v63 == 0;\n\tif (v74) goto L_004C;\n\treturn;\nL_004C:\n\tv111 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v111, this, Il2CppMethodInfo);\n\tv137 = this._conveyor == 0;\n\tif (v137) goto L_0067;\n\t_game.CoreSystem.ConveyorSystem.ConveyorController::remove_OnParticleCountChanged(this._conveyor, v111);\n\tthis._conveyor = 0;\n\tthis._prevConveyorCount = 0;\n\treturn;\nL_0067:\n\tthrow v111;\n")]
		public void UnbindConveyor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayHapticController::UnbindConveyor");
		}

		[Token(Token = "0x600023D")]
		[Address(RVA = "0x3C75C14", Offset = "0x3C75C14", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tUnco.EventBusSystem.Runtime.EventBus::RemoveListener(this._eventBus, v49);\n\t_game.CoreSystem.GameplayHapticController::UnbindMoldEvents(this);\n\t_game.CoreSystem.GameplayHapticController::UnbindConveyor(this);\n\treturn;\nL_0020:\n\tv49 = new System.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>();\n\tSystem.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>::.ctor(v49, this, Il2CppMethodInfo);\n")]
		public void Dispose()
		{
			Action<UventLevelFailed> observer = OnLevelFailed;
			_eventBus.RemoveListener(observer);
			UnbindMoldEvents();
			UnbindConveyor();
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0x3C75CCC", Offset = "0x3C75CCC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = v29._prevConveyorCount >= v24;\n\tif (v12) goto L_0024;\n\tv14 = v29._hapticManager == 0;\n\tif (v14) goto L_0024;\n\tUnco.SettingsSyste.Core.HapticManager::PlayHaptic(v29._hapticManager, 0, 2, 0.25f);\nL_0024:\n\tv29._prevConveyorCount = v24;\n\treturn;\n")]
		private void OnConveyorCountUpdated(int newCount)
		{
			int num = default(int);
			if (_prevConveyorCount < num && (object)_hapticManager != null)
			{
				_hapticManager.PlayHaptic(default(HapticPatterns.PresetType), HapticCategory.ConveyorFlow, 0.25f);
			}
			_prevConveyorCount = num;
		}

		[Token(Token = "0x600023F")]
		[Address(RVA = "0x3C75D24", Offset = "0x3C75D24", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._hapticManager == 0;\n\tif (v2) goto L_000B;\n\tUnco.SettingsSyste.Core.HapticManager::PlayHaptic(this._hapticManager, 4, 3, 0.3f);\n\treturn;\nL_000B:\n\treturn;\n")]
		private void OnMoldParticleAbsorbed()
		{
			if ((object)_hapticManager != null)
			{
				_hapticManager.PlayHaptic(HapticPatterns.PresetType.LightImpact, HapticCategory.MoldFill, 0.3f);
			}
		}

		[Token(Token = "0x6000240")]
		[Address(RVA = "0x3C75D4C", Offset = "0x3C75D4C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._hapticManager == 0;\n\tif (v2) goto L_0009;\n\tUnco.SettingsSyste.Core.HapticManager::PlayHaptic(this._hapticManager, 1, 4, 0f);\n\treturn;\nL_0009:\n\treturn;\n")]
		private void OnMoldVisualComplete(int col, int row)
		{
			if ((object)_hapticManager != null)
			{
				_hapticManager.PlayHaptic(HapticPatterns.PresetType.Success, HapticCategory.MoldComplete, 0f);
			}
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0x3C75D6C", Offset = "0x3C75D6C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._hapticManager == 0;\n\tif (v2) goto L_0009;\n\tUnco.SettingsSyste.Core.HapticManager::PlayHaptic(this._hapticManager, 3, 5, 0f);\n\treturn;\nL_0009:\n\treturn;\n")]
		private void OnLevelFailed(UventLevelFailed evt)
		{
			if ((object)_hapticManager != null)
			{
				_hapticManager.PlayHaptic(HapticPatterns.PresetType.Failure, HapticCategory.LevelResult, 0f);
			}
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0x3C75D8C", Offset = "0x3C75D8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GameplayHapticController()
		{
		}
	}
}

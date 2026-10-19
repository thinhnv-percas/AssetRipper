using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.SoundSystem.Scripts.Runtime;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreSystem.Events;
using _game.CoreSystem.New.MoldSystem;

namespace _game.CoreSystem
{
	[Token(Token = "0x2000085")]
	public class GameplaySoundController : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x10")]
		private SoundManager _soundManager;

		[Inject(false)]
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x20")]
		private MoldAbsorptionBridge _bridge;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x28")]
		private int _absorbedCount;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x2C")]
		private bool _boxPourPlaying;

		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x30")]
		private Tween _boxPourIdleTween;

		[Token(Token = "0x4000161")]
		private const int AbsorptionThreshold = 5;

		[Token(Token = "0x4000162")]
		private const float BoxPourIdleTimeout = 0.3f;

		[Token(Token = "0x4000163")]
		private const AudioLayer GameplayLayer = AudioLayer.BaseLayerSoundEffect;

		[Inject(false)]
		[Token(Token = "0x6000243")]
		[Address(RVA = "0x3C75D94", Offset = "0x3C75D94", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tUnco.EventBusSystem.Runtime.EventBus::ListenEvent(this._eventBus, v53);\n\tv89 = new System.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelCompleted>();\n\tSystem.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelCompleted>::.ctor(v89, this, Il2CppMethodInfo);\n\tUnco.EventBusSystem.Runtime.EventBus::ListenEvent(this._eventBus, v89);\n\tv90 = new System.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>();\n\tSystem.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>::.ctor(v90, this, Il2CppMethodInfo);\n\tUnco.EventBusSystem.Runtime.EventBus::ListenEvent(this._eventBus, v90);\n\treturn;\nL_0034:\n\tv53 = new System.Action`1<_game.CoreSystem.Events.USandCubeClicked>();\n\tSystem.Action`1<_game.CoreSystem.Events.USandCubeClicked>::.ctor(v53, this, Il2CppMethodInfo);\n")]
		private void Construct()
		{
			Action<USandCubeClicked> observer = OnSandCubeClicked;
			_eventBus.ListenEvent(observer);
			Action<UventLevelCompleted> observer2 = OnLevelWin;
			_eventBus.ListenEvent(observer2);
			Action<UventLevelFailed> observer3 = OnLevelFail;
			_eventBus.ListenEvent(observer3);
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0x3C75F24", Offset = "0x3C75F24", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv74 = this._bridge == 0;\n\tif (v74) goto L_0054;\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::add_OnParticleAbsorbed(this._bridge, v64);\n\tv90 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v90, this, Il2CppMethodInfo);\n\tv92 = this._bridge == 0;\n\tif (v92) goto L_0054;\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::add_OnEntityVisualComplete(this._bridge, v90);\n\treturn;\nL_0054:\n\tthrow v64;\nL_0027:\n\tthis._bridge = v48;\n\tv64 = new System.Action();\n\tSystem.Action::.ctor(v64, this, Il2CppMethodInfo);\n")]
		public void BindMoldEvents(MoldAbsorptionBridge bridge)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplaySoundController::BindMoldEvents");
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0x3C76034", Offset = "0x3C76034", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv67 = new System.Action();\n\tSystem.Action::.ctor(v67, this, Il2CppMethodInfo);\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::remove_OnParticleAbsorbed(this._bridge, v67);\n\tv128 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v128, this, Il2CppMethodInfo);\n\t_game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge::remove_OnEntityVisualComplete(this._bridge, v128);\n\tthis._bridge = 0;\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tthis._boxPourPlaying = 0;\n\tthis._absorbedCount = 0;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopAllSounds(this._soundManager, 2);\n\treturn;\nL_006D:\n\treturn;\nL_0024:\n\tv54 = this._bridge == 0;\n\tif (v54) goto L_006D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UnbindMoldEvents()
		{
			if (_bridge != null)
			{
				Action value = OnParticleAbsorbed;
				_bridge.remove_OnParticleAbsorbed(value);
				Action<int> value2 = OnEntityVisualComplete;
				_bridge.remove_OnEntityVisualComplete(value2);
				_bridge = null;
				_boxPourIdleTween.Stop();
				_boxPourPlaying = false;
				_absorbedCount = 0;
				_soundManager.StopAllSounds(AudioLayer.BaseLayerSoundEffect);
			}
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0x3C761CC", Offset = "0x3C761CC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tthis._boxPourPlaying = 0;\n\tthis._absorbedCount = 0;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopAllSounds(this._soundManager, 2);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Cleanup()
		{
			_boxPourIdleTween.Stop();
			_boxPourPlaying = false;
			_absorbedCount = 0;
			_soundManager.StopAllSounds(AudioLayer.BaseLayerSoundEffect);
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0x3C76210", Offset = "0x3C76210", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopAllSounds(this._soundManager, 2);\n\tv86 = new System.Action`1<_game.CoreSystem.Events.USandCubeClicked>();\n\tSystem.Action`1<_game.CoreSystem.Events.USandCubeClicked>::.ctor(v86, this, Il2CppMethodInfo);\n\tUnco.EventBusSystem.Runtime.EventBus::RemoveListener(this._eventBus, v86);\n\tv87 = new System.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelCompleted>();\n\tSystem.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelCompleted>::.ctor(v87, this, Il2CppMethodInfo);\n\tUnco.EventBusSystem.Runtime.EventBus::RemoveListener(this._eventBus, v87);\n\tv88 = new System.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>();\n\tSystem.Action`1<_game.CoreGameKit.BaseLayer.Controller.Runtime.States.UventLevelFailed>::.ctor(v88, this, Il2CppMethodInfo);\n\tUnco.EventBusSystem.Runtime.EventBus::RemoveListener(this._eventBus, v88);\n\treturn;\nL_002E:\n\t;\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tthis._boxPourPlaying = 0;\n\tthis._absorbedCount = 0;\n")]
		public void Dispose()
		{
			_boxPourIdleTween.Stop();
			_boxPourPlaying = false;
			_absorbedCount = 0;
			_soundManager.StopAllSounds(AudioLayer.BaseLayerSoundEffect);
			Action<USandCubeClicked> observer = OnSandCubeClicked;
			_eventBus.RemoveListener(observer);
			Action<UventLevelCompleted> observer2 = OnLevelWin;
			_eventBus.RemoveListener(observer2);
			Action<UventLevelFailed> observer3 = OnLevelFail;
			_eventBus.RemoveListener(observer3);
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0x3C763C8", Offset = "0x3C763C8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._soundManager == 0;\n\tif (v2) goto L_0009;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this._soundManager, 0x66, 0, 2);\n\treturn;\nL_0009:\n\treturn;\n")]
		public void PlayBoosterSwap()
		{
			if ((object)_soundManager != null)
			{
				_soundManager.PlaySound(SoundManager.AudioType.BoosterSwap, null, AudioLayer.BaseLayerSoundEffect);
			}
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0x3C763E8", Offset = "0x3C763E8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = evt.isPourable == 0;\n\tif (v16) goto L_002C;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this._soundManager, 0x55, 0, 2);\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this._soundManager, 0x56, 0, 2);\n\treturn;\nL_002C:\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this._soundManager, 0x57, 0, 2);\n\treturn;\n")]
		private void OnSandCubeClicked(USandCubeClicked evt)
		{
			if (evt.isPourable)
			{
				_soundManager.PlaySound(SoundManager.AudioType.SoundSandBlockPop, null, AudioLayer.BaseLayerSoundEffect);
				_soundManager.PlaySound(SoundManager.AudioType.SoundSandPouring, null, AudioLayer.BaseLayerSoundEffect);
			}
			else
			{
				_soundManager.PlaySound(SoundManager.AudioType.SoundClosedSandBlock, null, AudioLayer.BaseLayerSoundEffect);
			}
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0x3C76464", Offset = "0x3C76464", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tthis._boxPourPlaying = 0;\n\tthis._absorbedCount = 0;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopAllSounds(this._soundManager, 2);\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this._soundManager, 0x58, 0, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnLevelWin(UventLevelCompleted evt)
		{
			_boxPourIdleTween.Stop();
			_boxPourPlaying = false;
			_absorbedCount = 0;
			_soundManager.StopAllSounds(AudioLayer.BaseLayerSoundEffect);
			_soundManager.PlaySound(SoundManager.AudioType.SoundLevelWin);
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x3C764C4", Offset = "0x3C764C4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tthis._boxPourPlaying = 0;\n\tthis._absorbedCount = 0;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopAllSounds(this._soundManager, 2);\n\tv41 = evt & 1;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0028;\n\treturn;\nL_0028:\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this._soundManager, 0x59, 0, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnLevelFail(UventLevelFailed evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplaySoundController::OnLevelFail");
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x3C76538", Offset = "0x3C76538", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = v40._absorbedCount + 1;\n\tv40._absorbedCount = v12;\n\tv23 = v12 < 5;\n\tif (v23) goto L_002B;\n\tv26 = v40._boxPourPlaying == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_002B;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(v40._soundManager, 0x53, 0, 2);\n\tv40._boxPourPlaying = 1;\nL_002B:\n\t_game.CoreSystem.GameplaySoundController::ResetIdleTimer(v40);\n\treturn;\n")]
		private void OnParticleAbsorbed()
		{
			if (++_absorbedCount >= 5 && !_boxPourPlaying)
			{
				_soundManager.PlaySound(SoundManager.AudioType.SoundBoxPour, null, AudioLayer.BaseLayerSoundEffect);
				_boxPourPlaying = true;
			}
			ResetIdleTimer();
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x3C76670", Offset = "0x3C76670", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::PlaySound(this._soundManager, 0x54, 0, 2);\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tv20 = this._boxPourPlaying != 1;\n\tif (v20) goto L_0026;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopSound(this._soundManager, 0x53, 2);\n\tthis._boxPourPlaying = 0;\nL_0026:\n\tthis._absorbedCount = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEntityVisualComplete(int entityId)
		{
			_soundManager.PlaySound(SoundManager.AudioType.SoundMoldComplete, null, AudioLayer.BaseLayerSoundEffect);
			_boxPourIdleTween.Stop();
			if (_boxPourPlaying)
			{
				_soundManager.StopSound(SoundManager.AudioType.SoundBoxPour, AudioLayer.BaseLayerSoundEffect);
				_boxPourPlaying = false;
			}
			_absorbedCount = 0;
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0x3C7659C", Offset = "0x3C7659C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv63 = new System.Action();\n\tSystem.Action::.ctor(v63, this, Il2CppMethodInfo);\n\tv101 = PrimeTween.Tween::Delay(0.3f, v63, 1, 1);\n\tthis._boxPourIdleTween.tween = 1;\n\tthis._boxPourIdleTween.id = v101;\n\treturn;\nL_004E:\n\treturn;\nL_0017:\n\t;\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tv57 = this._boxPourPlaying != 1;\n\tif (v57) goto L_004E;\n")]
		private void ResetIdleTimer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplaySoundController::ResetIdleTimer");
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x3C76188", Offset = "0x3C76188", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tthis._boxPourPlaying = 0;\n\tthis._absorbedCount = 0;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopAllSounds(this._soundManager, 2);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopAllGameplaySounds()
		{
			_boxPourIdleTween.Stop();
			_boxPourPlaying = false;
			_absorbedCount = 0;
			_soundManager.StopAllSounds(AudioLayer.BaseLayerSoundEffect);
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x3C766E4", Offset = "0x3C766E4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Tween::Stop(&this._boxPourIdleTween (PrimeTween.Tween));\n\tv24 = this._boxPourPlaying != 1;\n\tif (v24) goto L_001E;\n\tUnco.SoundSystem.Scripts.Runtime.SoundManager::StopSound(this._soundManager, 0x53, 2);\n\tthis._boxPourPlaying = 0;\nL_001E:\n\tthis._absorbedCount = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopBoxPour()
		{
			_boxPourIdleTween.Stop();
			if (_boxPourPlaying)
			{
				_soundManager.StopSound(SoundManager.AudioType.SoundBoxPour, AudioLayer.BaseLayerSoundEffect);
				_boxPourPlaying = false;
			}
			_absorbedCount = 0;
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x3C7673C", Offset = "0x3C7673C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GameplaySoundController()
		{
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Reflex.Attributes;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.EventBusSystem.Runtime;
using Unco.GameBootstrap.Core;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreGameKit.BaseLayer.States;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Tracking.Tools.Logging;

namespace _game.CoreGameKit.Tools.AutoScreenshot
{
	[Token(Token = "0x20005CD")]
	public class AutoScreenshotTool : IDevTool, IDisposable
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005CE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400142B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400142C")]
			public static Func<ScreenshotResolutionEntry, bool> _003C_003E9__38_0;

			[Token(Token = "0x6001915")]
			[Address(RVA = "0x3D4504C", Offset = "0x3D4504C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001916")]
			[Address(RVA = "0x3D450B0", Offset = "0x3D450B0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGetCaptureCountPerTrigger_003Eb__38_0(ScreenshotResolutionEntry r)
			{
				if (r != null && r.Enabled && r.Width >= 1)
				{
					bool flag = r.Height < 0;
					bool flag2 = r.Height == 0;
					int num = r.Height ^ r.Height;
					int num2 = r.Height & num;
					bool flag3 = num2 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					return flag4 && flag5;
				}
				return false;
			}
		}

		[Inject(false)]
		[Token(Token = "0x4001424")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x4001425")]
		[FieldOffset(Offset = "0x18")]
		private ContainerManager _containerManager;

		[Token(Token = "0x4001426")]
		[FieldOffset(Offset = "0x20")]
		private ULogger _logger;

		[Token(Token = "0x4001427")]
		[FieldOffset(Offset = "0x28")]
		private AutoScreenshotConfig _config;

		[Token(Token = "0x4001428")]
		[FieldOffset(Offset = "0x30")]
		private AutoScreenshotRunner _runner;

		[Token(Token = "0x4001429")]
		[FieldOffset(Offset = "0x38")]
		private bool _isActive;

		[Token(Token = "0x400142A")]
		[FieldOffset(Offset = "0x3C")]
		private int _captureCount;

		[Token(Token = "0x1700025C")]
		public string ToolName
		{
			[Token(Token = "0x60018F0")]
			[Address(RVA = "0x3D429C4", Offset = "0x3D429C4", Length = "0x44")]
			get
			{
				return "Auto Screenshot Tool";
			}
		}

		[Token(Token = "0x1700025D")]
		public string ToolVersion
		{
			[Token(Token = "0x60018F1")]
			[Address(RVA = "0x3D42A08", Offset = "0x3D42A08", Length = "0x44")]
			get
			{
				return "1.0.0";
			}
		}

		[Token(Token = "0x1700025E")]
		public bool IsRunning
		{
			[Token(Token = "0x60018F2")]
			[Address(RVA = "0x3D42A4C", Offset = "0x3D42A4C", Length = "0x8")]
			get
			{
				return _isActive;
			}
		}

		[Token(Token = "0x1700025F")]
		public int CaptureCount
		{
			[Token(Token = "0x60018F3")]
			[Address(RVA = "0x3D42A54", Offset = "0x3D42A54", Length = "0x8")]
			get
			{
				return _captureCount;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60018EF")]
		[Address(RVA = "0x3D429BC", Offset = "0x3D429BC", Length = "0x8")]
		private void Construct(ULogger logger)
		{
			_logger = logger;
		}

		[Token(Token = "0x60018F4")]
		[Address(RVA = "0x3D42A5C", Offset = "0x3D42A5C", Length = "0x4C0")]
		public void Start(AutoScreenshotConfig config)
		{
			if (IsRunning)
			{
				if (_logger != null)
				{
					_logger.LogWarning("[AutoScreenshot] Already running. Stop first.", "Start", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 43);
				}
				return;
			}
			if (config == null)
			{
				if (_logger != null)
				{
					_logger.LogError("[AutoScreenshot] Config is null. Cannot start.", "Start", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 49);
				}
				return;
			}
			_config = config;
			_captureCount = 0;
			if (TryResolveFromScene<ILevelProgressService>(out var service))
			{
				AutoScreenshotConfig config2 = _config;
				service.SetCurrentLevelIndex(config2.LevelRangeMin);
			}
			CreateRunner();
			Action<UventChapterStateChanged> observer = OnStateChanged;
			_eventBus.ListenEvent(observer);
			_isActive = true;
			if (_logger != null)
			{
				object[] array = new object[4];
				AutoScreenshotConfig config3 = _config;
				int levelRangeMin = config3.LevelRangeMin;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj = default(object);
				if (obj != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						goto IL_03d8;
					}
				}
				array[0] = obj;
				AutoScreenshotConfig config4 = _config;
				int levelRangeMax = config4.LevelRangeMax;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj3 = default(object);
				if (obj3 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj4 = default(object);
					if (obj4 == null)
					{
						goto IL_03d8;
					}
				}
				array[1] = obj3;
				AutoScreenshotConfig config5 = _config;
				List<ScreenshotTriggerEntry> triggers = config5.Triggers;
				int count = triggers.Count;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj5 = default(object);
				if (obj5 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj6 = default(object);
					if (obj6 == null)
					{
						goto IL_03d8;
					}
				}
				array[2] = obj5;
				AutoScreenshotConfig config6 = _config;
				int captureCountPerTrigger = GetCaptureCountPerTrigger(config6.Resolutions);
				int num2 = captureCountPerTrigger;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj7 = default(object);
				if (obj7 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj8 = default(object);
					if (obj8 == null)
					{
						goto IL_03d8;
					}
				}
				array[3] = obj7;
				string message = string.Format("[AutoScreenshot] Started. Level range: {0}-{1}, Triggers: {2}, Active resolutions: {3}", array);
				_logger.Log(message, "Start", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 62);
			}
			EvaluateCurrentState();
			return;
			IL_03d8:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60018F5")]
		[Address(RVA = "0x3D43650", Offset = "0x3D43650", Length = "0x1F8")]
		public void Stop()
		{
			if (!IsRunning)
			{
				return;
			}
			if (_eventBus != null)
			{
				Action<UventChapterStateChanged> observer = OnStateChanged;
				_eventBus.RemoveListener(observer);
			}
			ULogger logger;
			if (!(_runner != null))
			{
				_isActive = false;
				logger = _logger;
				if (_logger == null)
				{
					return;
				}
			}
			else
			{
				GameObject gameObject = _runner.gameObject;
				UnityEngine.Object.Destroy(gameObject);
				_runner = null;
				_isActive = false;
				logger = _logger;
				if (_logger == null)
				{
					return;
				}
			}
			int captureCount = CaptureCount;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string message = $"[AutoScreenshot] Stopped. Total captures: {arg}";
			logger.Log(message, "Stop", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 81);
		}

		[Token(Token = "0x60018F6")]
		[Address(RVA = "0x3D42F1C", Offset = "0x3D42F1C", Length = "0xFC")]
		private void CreateRunner()
		{
			GameObject gameObject = new GameObject("[AutoScreenshotRunner]");
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			AutoScreenshotRunner runner = gameObject.AddComponent<AutoScreenshotRunner>();
			_runner = runner;
			AutoScreenshotRunner runner2 = _runner;
			runner2._logger = _logger;
		}

		[Token(Token = "0x60018F7")]
		[Address(RVA = "0x3D43848", Offset = "0x3D43848", Length = "0x12C")]
		private bool IsInLevelRange()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::IsInLevelRange");
			return default;
		}

		[Token(Token = "0x60018F8")]
		[Address(RVA = "0x3D431C4", Offset = "0x3D431C4", Length = "0x48C")]
		private void EvaluateCurrentState()
		{
			if (!IsRunning || _runner == null)
			{
				return;
			}
			if (IsInLevelRange())
			{
				if (TryResolveFromGlobal<GameStateController>(out var service))
				{
					if (service.CurrentLayer != GameplayLayer.Menu)
					{
						if (!TryResolveFromFeature<BaseLayerStateMachine>(out var service2) || service2.CurrentState == null)
						{
							return;
						}
						Type type = service2.CurrentState.GetType();
						if (_logger != null)
						{
							string name = type.Name;
							string message = "[AutoScreenshot] Evaluating current state: " + name;
							_logger.Log(message, "EvaluateCurrentState", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 128);
						}
						Type typeFromHandle = typeof(BaseLayerIntroState);
						if (type == typeFromHandle)
						{
							HandleIntroState();
							return;
						}
						Type typeFromHandle2 = typeof(BaseLayerReadyState);
						if (type == typeFromHandle2)
						{
							HandleReadyState();
							return;
						}
						Type typeFromHandle3 = typeof(BaseLayerRunningState);
						if (type == typeFromHandle3)
						{
							HandleRunningState();
							return;
						}
						Type typeFromHandle4 = typeof(BaseLayerWinState);
						if (type == typeFromHandle4)
						{
							HandleWinState();
							return;
						}
						Type typeFromHandle5 = typeof(BaseLayerFailState);
						if (type == typeFromHandle5)
						{
							HandleFailState();
						}
					}
					else
					{
						HandleMenuLayer();
					}
				}
				else if (_logger != null)
				{
					_logger.LogWarning("[AutoScreenshot] Could not resolve GameStateController", "EvaluateCurrentState", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 112);
				}
			}
			else
			{
				if (_logger != null)
				{
					_logger.Log("[AutoScreenshot] Level outside range. Stopping.", "EvaluateCurrentState", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 105);
				}
				Stop();
			}
		}

		[Token(Token = "0x60018F9")]
		[Address(RVA = "0x3D43B18", Offset = "0x3D43B18", Length = "0x90")]
		private void HandleIntroState()
		{
			if (_logger != null)
			{
				_logger.Log("[AutoScreenshot] Intro state - auto-advancing to Running", "HandleIntroState", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 145);
			}
			AdvanceToRunningState();
		}

		[Token(Token = "0x60018FA")]
		[Address(RVA = "0x3D43F84", Offset = "0x3D43F84", Length = "0x370")]
		private void OnStateChanged(UventChapterStateChanged evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::OnStateChanged");
		}

		[Token(Token = "0x60018FB")]
		[Address(RVA = "0x3D43974", Offset = "0x3D43974", Length = "0x1A4")]
		private void HandleMenuLayer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::HandleMenuLayer");
		}

		[Token(Token = "0x60018FC")]
		[Address(RVA = "0x3D43BA8", Offset = "0x3D43BA8", Length = "0x90")]
		private void HandleReadyState()
		{
			if (_logger != null)
			{
				_logger.Log("[AutoScreenshot] Ready state - auto-advancing to Running", "HandleReadyState", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotTool.cs", 204);
			}
			AdvanceToRunningState();
		}

		[Token(Token = "0x60018FD")]
		[Address(RVA = "0x3D43ED8", Offset = "0x3D43ED8", Length = "0xAC")]
		private void AdvanceToRunningState()
		{
			if (TryResolveFromFeature<BaseLayerStateMachine>(out var service) && TryResolveFromFeature<BaseLayerRunningState>(out var service2))
			{
				service.SetState(service2);
			}
		}

		[Token(Token = "0x60018FE")]
		[Address(RVA = "0x3D43C38", Offset = "0x3D43C38", Length = "0xC8")]
		private void HandleRunningState()
		{
			ScreenshotTriggerEntry screenshotTriggerEntry = FindTrigger(ScreenshotTriggerType.OnStateEntered, "BaseLayerRunningState");
			if (screenshotTriggerEntry != null)
			{
				Action onCaptured = delegate
				{
					TriggerAfterRun();
				};
				CaptureForTrigger(screenshotTriggerEntry, onCaptured);
			}
			else
			{
				TriggerAfterRun();
			}
		}

		[Token(Token = "0x60018FF")]
		[Address(RVA = "0x3D43D00", Offset = "0x3D43D00", Length = "0xEC")]
		private void HandleWinState()
		{
			ScreenshotTriggerEntry screenshotTriggerEntry = FindTrigger(ScreenshotTriggerType.OnStateEntered, "BaseLayerWinState");
			if (screenshotTriggerEntry == null)
			{
				screenshotTriggerEntry = FindTriggerByUi("WinUiController");
				if (screenshotTriggerEntry == null)
				{
					AutoAdvance();
					return;
				}
			}
			Action onCaptured = delegate
			{
				AutoAdvance();
			};
			CaptureForTrigger(screenshotTriggerEntry, onCaptured);
		}

		[Token(Token = "0x6001900")]
		[Address(RVA = "0x3D43DEC", Offset = "0x3D43DEC", Length = "0xEC")]
		private void HandleFailState()
		{
			ScreenshotTriggerEntry screenshotTriggerEntry = FindTrigger(ScreenshotTriggerType.OnStateEntered, "BaseLayerFailState");
			if (screenshotTriggerEntry == null)
			{
				screenshotTriggerEntry = FindTriggerByUi("FailUiController");
				if (screenshotTriggerEntry == null)
				{
					AutoAdvance();
					return;
				}
			}
			Action onCaptured = delegate
			{
				AutoAdvance();
			};
			CaptureForTrigger(screenshotTriggerEntry, onCaptured);
		}

		[Token(Token = "0x6001901")]
		[Address(RVA = "0x3D44734", Offset = "0x3D44734", Length = "0xFC")]
		private void TriggerAfterRun()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::TriggerAfterRun");
		}

		[Token(Token = "0x6001902")]
		[Address(RVA = "0x3D443F0", Offset = "0x3D443F0", Length = "0x23C")]
		private void CaptureForTrigger(ScreenshotTriggerEntry trigger, Action onCaptured = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::CaptureForTrigger");
		}

		[Token(Token = "0x6001903")]
		[Address(RVA = "0x3D44924", Offset = "0x3D44924", Length = "0x10C")]
		private void AutoAdvance()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::AutoAdvance");
		}

		[Token(Token = "0x6001904")]
		[Address(RVA = "0x3D4462C", Offset = "0x3D4462C", Length = "0x108")]
		private void ReEvaluateStateSoon()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::ReEvaluateStateSoon");
		}

		[Token(Token = "0x6001905")]
		[Address(RVA = "0x472B69C", Offset = "0x472B69C", Length = "0x160")]
		private bool TryResolveFromGlobal<T>(out T service)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::TryResolveFromGlobal");
			service = default;
			return default;
		}

		[Token(Token = "0x6001906")]
		[Address(RVA = "0x472B928", Offset = "0x472B928", Length = "0xC8")]
		private bool TryResolveFromScene<T>(out T service)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::TryResolveFromScene");
			service = default;
			return default;
		}

		[Token(Token = "0x6001907")]
		[Address(RVA = "0x472B52C", Offset = "0x472B52C", Length = "0xC8")]
		private bool TryResolveFromFeature<T>(out T service)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::TryResolveFromFeature");
			service = default;
			return default;
		}

		[Token(Token = "0x6001908")]
		[Address(RVA = "0x3D442F4", Offset = "0x3D442F4", Length = "0xFC")]
		private ScreenshotTriggerEntry FindTrigger(ScreenshotTriggerType type, string typeName)
		{
			AutoScreenshotConfig config = _config;
			Func<ScreenshotTriggerEntry, bool> predicate = delegate(ScreenshotTriggerEntry t)
			{
				if (!t.Enabled || t.TriggerType != type)
				{
					return false;
				}
				return typeName == null || t.StateTypeName == typeName;
			};
			return (ScreenshotTriggerEntry)config.Triggers.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x6001909")]
		[Address(RVA = "0x3D44830", Offset = "0x3D44830", Length = "0xF4")]
		private ScreenshotTriggerEntry FindTriggerByUi(string uiTypeName)
		{
			AutoScreenshotConfig config = _config;
			Func<ScreenshotTriggerEntry, bool> predicate = (ScreenshotTriggerEntry t) => t.Enabled && t.TriggerType == ScreenshotTriggerType.OnUiShown && t.UiControllerTypeName == uiTypeName;
			return (ScreenshotTriggerEntry)config.Triggers.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x600190A")]
		[Address(RVA = "0x3D43018", Offset = "0x3D43018", Length = "0x1AC")]
		private static int GetCaptureCountPerTrigger(IReadOnlyList<ScreenshotResolutionEntry> resolutions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotTool::GetCaptureCountPerTrigger");
			return default;
		}

		[Token(Token = "0x600190B")]
		[Address(RVA = "0x3D44A40", Offset = "0x3D44A40", Length = "0x4")]
		public void Dispose()
		{
			Stop();
		}

		[Token(Token = "0x600190C")]
		[Address(RVA = "0x3D44A44", Offset = "0x3D44A44", Length = "0x8")]
		public AutoScreenshotTool()
		{
		}
	}
}

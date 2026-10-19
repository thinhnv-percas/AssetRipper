using System;
using System.Collections;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Reflex.Attributes;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Core;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Tracking.Tools.Logging;

namespace _game.CoreGameKit.Tools.LevelScreenshot
{
	[Token(Token = "0x20005AB")]
	public class LevelScreenshotTool : IDevTool, IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4001370")]
		[FieldOffset(Offset = "0x10")]
		private ContainerManager _containerManager;

		[Token(Token = "0x4001371")]
		[FieldOffset(Offset = "0x18")]
		private ULogger _logger;

		[Token(Token = "0x4001372")]
		[FieldOffset(Offset = "0x20")]
		private LevelScreenshotRunner _runner;

		[Token(Token = "0x4001373")]
		[FieldOffset(Offset = "0x28")]
		private bool _isActive;

		[Token(Token = "0x4001374")]
		[FieldOffset(Offset = "0x2C")]
		private int _captureCount;

		[Token(Token = "0x4001375")]
		[FieldOffset(Offset = "0x30")]
		private int _currentLevel;

		[Token(Token = "0x4001376")]
		[FieldOffset(Offset = "0x34")]
		private int _min;

		[Token(Token = "0x4001377")]
		[FieldOffset(Offset = "0x38")]
		private int _max;

		[Token(Token = "0x4001378")]
		[FieldOffset(Offset = "0x40")]
		private string _outputSubfolder;

		[Token(Token = "0x4001379")]
		[FieldOffset(Offset = "0x48")]
		private float _delayBeforeCapture;

		[Token(Token = "0x400137A")]
		[FieldOffset(Offset = "0x4C")]
		private bool _hideUi;

		[Token(Token = "0x400137B")]
		[FieldOffset(Offset = "0x50")]
		private Func<int, string> _fileNameProvider;

		[Token(Token = "0x400137C")]
		[FieldOffset(Offset = "0x58")]
		private string _phase;

		[Token(Token = "0x400137D")]
		private const int FeatureResolveMaxFrames = 60;

		[Token(Token = "0x17000234")]
		public string ToolName
		{
			[Token(Token = "0x6001820")]
			[Address(RVA = "0x3D3207C", Offset = "0x3D3207C", Length = "0x44")]
			get
			{
				return "Level Screenshot Tool";
			}
		}

		[Token(Token = "0x17000235")]
		public string ToolVersion
		{
			[Token(Token = "0x6001821")]
			[Address(RVA = "0x3D320C0", Offset = "0x3D320C0", Length = "0x44")]
			get
			{
				return "1.0.0";
			}
		}

		[Token(Token = "0x17000236")]
		public bool IsRunning
		{
			[Token(Token = "0x6001822")]
			[Address(RVA = "0x3D32104", Offset = "0x3D32104", Length = "0x8")]
			get
			{
				return _isActive;
			}
		}

		[Token(Token = "0x17000237")]
		public int CaptureCount
		{
			[Token(Token = "0x6001823")]
			[Address(RVA = "0x3D3210C", Offset = "0x3D3210C", Length = "0x8")]
			get
			{
				return _captureCount;
			}
		}

		[Token(Token = "0x17000238")]
		public int CurrentLevel
		{
			[Token(Token = "0x6001824")]
			[Address(RVA = "0x3D32114", Offset = "0x3D32114", Length = "0x8")]
			get
			{
				return _currentLevel;
			}
		}

		[Token(Token = "0x17000239")]
		public int LevelRangeMin
		{
			[Token(Token = "0x6001825")]
			[Address(RVA = "0x3D3211C", Offset = "0x3D3211C", Length = "0x8")]
			get
			{
				return _min;
			}
		}

		[Token(Token = "0x1700023A")]
		public int LevelRangeMax
		{
			[Token(Token = "0x6001826")]
			[Address(RVA = "0x3D32124", Offset = "0x3D32124", Length = "0x8")]
			get
			{
				return _max;
			}
		}

		[Inject(false)]
		[Token(Token = "0x600181F")]
		[Address(RVA = "0x3D32074", Offset = "0x3D32074", Length = "0x8")]
		private void Construct(ULogger logger)
		{
			_logger = logger;
		}

		[Token(Token = "0x6001827")]
		[Address(RVA = "0x3D3212C", Offset = "0x3D3212C", Length = "0xBC")]
		public bool CanStart()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DC1C]");
			bool flag;
			ILevelProgressService service2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				GameStateController service = null;
				flag = TryResolveFromGlobal<GameStateController>(out service);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				service2 = null;
				if (!flag3)
				{
					goto IL_006f;
				}
			}
			else
			{
				_ = 1;
				GameStateController service = null;
				flag = TryResolveFromGlobal<GameStateController>(out service);
				bool flag4 = !flag;
				service2 = null;
				if (flag4)
				{
					goto IL_006f;
				}
			}
			return TryResolveFromScene<ILevelProgressService>(out service2);
			IL_006f:
			return flag;
		}

		[Token(Token = "0x6001828")]
		[Address(RVA = "0x3D321E8", Offset = "0x3D321E8", Length = "0x3CC")]
		private string StateInfo()
		{
			bool flag = !TryResolveFromScene<ILevelProgressService>(out var service) || service == null;
			string text = "?";
			if (!flag)
			{
				int currentLevelIndex = service.CurrentLevelIndex;
				int num = currentLevelIndex;
				string text2 = num.ToString();
				text = text2;
			}
			bool flag2 = !TryResolveFromFeature<BaseLayerStateMachine>(out var service2) || service2 == null;
			string text3 = "?";
			string text4 = "<no-sm>";
			if (!flag2)
			{
				BaseLayerStateMachine baseLayerStateMachine;
				if (service2.CurrentState != null)
				{
					Type type = service2.CurrentState.GetType();
					string name = type.Name;
					bool flag3 = service2 == null;
					bool flag4 = !flag3;
					baseLayerStateMachine = service2;
					text4 = name;
					if (!flag4)
					{
						return (string)(object)new NullReferenceException();
					}
				}
				else
				{
					baseLayerStateMachine = service2;
					text4 = "<null-state>";
				}
				int hashCode = baseLayerStateMachine.GetHashCode();
				int num = hashCode;
				string text5 = num.ToString("X");
				text3 = text5;
			}
			object[] array = new object[6];
			if (_phase != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0354;
				}
			}
			array[0] = _phase;
			int currentLevel = CurrentLevel;
			int num2 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_0354;
				}
			}
			array[1] = obj2;
			if (text != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_0354;
				}
			}
			array[2] = text;
			if (text3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj5 = default(object);
				if (obj5 == null)
				{
					goto IL_0354;
				}
			}
			array[3] = text3;
			if (text4 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj6 = default(object);
				if (obj6 == null)
				{
					goto IL_0354;
				}
			}
			array[4] = text4;
			int captureCount = CaptureCount;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj7 = default(object);
			if (obj7 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj8 = default(object);
				if (obj8 == null)
				{
					goto IL_0354;
				}
			}
			array[5] = obj7;
			return string.Format("[phase={0} target={1} svc={2} sm#{3}={4} caps={5}]", array);
			IL_0354:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6001829")]
		[Address(RVA = "0x3D325B4", Offset = "0x3D325B4", Length = "0x7C")]
		private static string DefaultFileName(int idx)
		{
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"Level{arg:D3}";
		}

		[Token(Token = "0x600182A")]
		[Address(RVA = "0x3D32630", Offset = "0x3D32630", Length = "0x8")]
		public void Start(int levelMin, int levelMax, string outputSubfolder, float delayBeforeCapture, bool hideUi)
		{
			Start(levelMin, levelMax, outputSubfolder, delayBeforeCapture, hideUi, null);
		}

		[Token(Token = "0x600182B")]
		[Address(RVA = "0x3D32638", Offset = "0x3D32638", Length = "0x548")]
		public void Start(int levelMin, int levelMax, string outputSubfolder, float delayBeforeCapture, bool hideUi, Func<int, string> fileNameProvider)
		{
			ILevelProgressService service = null;
			GameStateController service2 = null;
			if (IsRunning)
			{
				if (_logger != null)
				{
					_logger.LogWarning("[LevelScreenshot] Already running. Stop first.", "Start", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs", 93);
				}
				return;
			}
			int sourceLineNumber;
			string sourceFilePath;
			string memberName;
			string message;
			ULogger logger;
			if (levelMin > levelMax)
			{
				if (_logger == null)
				{
					return;
				}
				int num = levelMin;
				int num2 = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int num3 = levelMax;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				string text = $"[LevelScreenshot] Invalid range: {arg}-{arg2}";
				sourceLineNumber = 99;
				sourceFilePath = "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs";
				memberName = "Start";
				message = text;
				logger = _logger;
			}
			else if (TryResolveFromGlobal<GameStateController>(out service2))
			{
				if (TryResolveFromScene<ILevelProgressService>(out service))
				{
					int num4 = ~levelMin;
					int min = levelMin & num4;
					_min = min;
					_max = levelMax;
					string outputSubfolder2 = ((!string.IsNullOrWhiteSpace(outputSubfolder)) ? outputSubfolder : "Levels");
					_outputSubfolder = outputSubfolder2;
					float num5 = default(float);
					if (num5 < 0f)
					{
					}
					_delayBeforeCapture = 0f;
					_hideUi = hideUi;
					bool flag = fileNameProvider == null;
					bool flag2 = !flag;
					Func<int, string> fileNameProvider2 = fileNameProvider;
					if (!flag2)
					{
						Func<int, string> func = DefaultFileName;
						fileNameProvider2 = func;
					}
					_fileNameProvider = fileNameProvider2;
					_captureCount = 0;
					_currentLevel = LevelRangeMin;
					CreateRunner();
					_phase = "Started";
					_isActive = true;
					if (_logger != null)
					{
						object[] array = new object[5];
						int num = LevelRangeMin;
						int num6 = 192761856 + 1336;
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
						object obj = default(object);
						if (obj != null)
						{
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
							object obj2 = default(object);
							if (obj2 == null)
							{
								goto IL_058c;
							}
						}
						array[0] = obj;
						int num3 = LevelRangeMax;
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
						object obj3 = default(object);
						if (obj3 != null)
						{
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
							object obj4 = default(object);
							if (obj4 == null)
							{
								goto IL_058c;
							}
						}
						array[1] = obj3;
						if (_outputSubfolder != null)
						{
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
							object obj5 = default(object);
							if (obj5 == null)
							{
								goto IL_058c;
							}
						}
						array[2] = _outputSubfolder;
						bool hideUi2 = _hideUi;
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
						object obj6 = default(object);
						if (obj6 != null)
						{
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
							object obj7 = default(object);
							if (obj7 == null)
							{
								goto IL_058c;
							}
						}
						array[3] = obj6;
						string text2 = StateInfo();
						if (text2 != null)
						{
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
							object obj8 = default(object);
							if (obj8 == null)
							{
								goto IL_058c;
							}
						}
						array[4] = text2;
						string message2 = string.Format("[LevelScreenshot] Started. Range: {0}-{1}, Subfolder: {2}, HideUi: {3} {4}", array);
						_logger.Log(message2, "Start", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs", 135);
					}
					LoadAndCaptureCurrent();
					return;
				}
				logger = _logger;
				if (_logger == null)
				{
					return;
				}
				sourceLineNumber = 111;
				sourceFilePath = "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs";
				memberName = "Start";
				message = "[LevelScreenshot] Could not resolve ILevelProgressService.";
			}
			else
			{
				logger = _logger;
				if (_logger == null)
				{
					return;
				}
				sourceLineNumber = 105;
				sourceFilePath = "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs";
				memberName = "Start";
				message = "[LevelScreenshot] Could not resolve GameStateController.";
			}
			logger.LogError(message, memberName, sourceFilePath, sourceLineNumber);
			return;
			IL_058c:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x600182C")]
		[Address(RVA = "0x3D33388", Offset = "0x3D33388", Length = "0x240")]
		public void Stop()
		{
			if (IsRunning)
			{
				_phase = "Stopping";
				if (_logger != null)
				{
					string text = StateInfo();
					string message = "[LevelScreenshot] Stop requested. " + text;
					_logger.Log(message, "Stop", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs", 144);
				}
				_isActive = false;
				if (_runner != null)
				{
					GameObject gameObject = _runner.gameObject;
					UnityEngine.Object.Destroy(gameObject);
					_runner = null;
				}
				_phase = "Stopped";
				if (_logger != null)
				{
					int captureCount = CaptureCount;
					int num = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					string arg = StateInfo();
					object arg2 = default(object);
					string message2 = $"[LevelScreenshot] Stopped. Total captures: {arg2} {arg}";
					_logger.Log(message2, "Stop", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs", 159);
				}
			}
		}

		[Token(Token = "0x600182D")]
		[Address(RVA = "0x3D335C8", Offset = "0x3D335C8", Length = "0x4")]
		public void Dispose()
		{
			Stop();
		}

		[Token(Token = "0x600182E")]
		[Address(RVA = "0x3D32B80", Offset = "0x3D32B80", Length = "0xFC")]
		private void CreateRunner()
		{
			GameObject gameObject = new GameObject("[LevelScreenshotRunner]");
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			LevelScreenshotRunner runner = gameObject.AddComponent<LevelScreenshotRunner>();
			_runner = runner;
			LevelScreenshotRunner runner2 = _runner;
			runner2._logger = _logger;
		}

		[Token(Token = "0x600182F")]
		[Address(RVA = "0x3D32C7C", Offset = "0x3D32C7C", Length = "0x70C")]
		private void LoadAndCaptureCurrent()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotTool::LoadAndCaptureCurrent");
		}

		[Token(Token = "0x6001830")]
		[Address(RVA = "0x3D3368C", Offset = "0x3D3368C", Length = "0x844")]
		private void WaitForFeatureAndForceReady(int frameAttempt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotTool::WaitForFeatureAndForceReady");
		}

		[Token(Token = "0x6001831")]
		[Address(RVA = "0x3D33ED8", Offset = "0x3D33ED8", Length = "0x6A0")]
		private unsafe void CaptureNow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotTool::CaptureNow");
		}

		[Token(Token = "0x6001832")]
		[Address(RVA = "0x3D34578", Offset = "0x3D34578", Length = "0x15C")]
		private void AfterCapture()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DC22]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if (!IsRunning)
				{
					return;
				}
			}
			else
			{
				_ = 1;
				if (!IsRunning)
				{
					return;
				}
			}
			_phase = "AfterCapture";
			_currentLevel = (int)((uint)(_captureCount = CaptureCount + 1) >> 32);
			if (_logger != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int currentLevel = CurrentLevel;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				string arg = StateInfo();
				object arg2 = default(object);
				object arg3 = default(object);
				string message = $"[LevelScreenshot] AfterCapture completedLevel={arg2} nextLevel={arg3} {arg}";
				_logger.Log(message, "AfterCapture", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/LevelScreenshot/LevelScreenshotTool.cs", 296);
			}
			LoadAndCaptureCurrent();
		}

		[Token(Token = "0x6001833")]
		[Address(RVA = "0x49F68C8", Offset = "0x49F68C8", Length = "0x160")]
		private bool TryResolveFromGlobal<T>(out T service)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotTool::TryResolveFromGlobal");
			service = default;
			return default;
		}

		[Token(Token = "0x6001834")]
		[Address(RVA = "0x49F6B54", Offset = "0x49F6B54", Length = "0xC8")]
		private bool TryResolveFromScene<T>(out T service)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotTool::TryResolveFromScene");
			service = default;
			return default;
		}

		[Token(Token = "0x6001835")]
		[Address(RVA = "0x49F6758", Offset = "0x49F6758", Length = "0xC8")]
		private bool TryResolveFromFeature<T>(out T service)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotTool::TryResolveFromFeature");
			service = default;
			return default;
		}

		[Token(Token = "0x6001836")]
		[Address(RVA = "0x3D335CC", Offset = "0x3D335CC", Length = "0xC0")]
		private bool TryResolveNavigationResolver(out LevelNavigationResolver resolver)
		{
			resolver = null;
			if (TryResolveFromScene<LevelNavigationResolver>(out resolver) || TryResolveFromGlobal<LevelNavigationResolver>(out resolver))
			{
				return true;
			}
			return TryResolveFromFeature<LevelNavigationResolver>(out resolver);
		}

		[Token(Token = "0x6001837")]
		[Address(RVA = "0x3D346D4", Offset = "0x3D346D4", Length = "0x64")]
		public LevelScreenshotTool()
		{
			_phase = "Idle";
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.DomainReload.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007C9")]
	public class GameBootstrapper : MonoBehaviour
	{
		[Token(Token = "0x20007CA")]
		private class GlobalScopeContextInstaller : IContainerInstaller
		{
			[Token(Token = "0x4001A0F")]
			[FieldOffset(Offset = "0x10")]
			private readonly Transform _parentTransform;

			[Token(Token = "0x60020EC")]
			[Address(RVA = "0x3DBE4BC", Offset = "0x3DBE4BC", Length = "0x34")]
			public GlobalScopeContextInstaller(Transform parentTransform)
			{
				_parentTransform = parentTransform;
			}

			[Token(Token = "0x60020ED")]
			[Address(RVA = "0x3DBFD50", Offset = "0x3DBFD50", Length = "0x1D0")]
			public void InstallBindings(ref ContainerInstanceBuilder builder)
			{
				Func<Instancer, GlobalScopeContext> factory = (Instancer instancer) => new GlobalScopeContext(_parentTransform, instancer);
				builder.AddSingleton(factory);
				Func<Instancer, ScopeContext> factory2 = (Instancer instancer) => new ScopeContext(_parentTransform, instancer, "Global");
				Type[] array = new Type[1];
				Type typeFromHandle = typeof(ScopeContext);
				if ((object)typeFromHandle != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = typeFromHandle;
				builder.AddSingleton(factory2, array);
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20007CB")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001A10")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001A11")]
			public static Func<IContainerInstaller, bool> _003C_003E9__12_0;

			[Token(Token = "0x4001A12")]
			public static Func<IContainerInstaller, bool> _003C_003E9__12_1;

			[Token(Token = "0x60020F0")]
			[Address(RVA = "0x3DC0028", Offset = "0x3DC0028", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60020F1")]
			[Address(RVA = "0x3DC008C", Offset = "0x3DC008C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CMarkGlobalInstallersAsInstalled_003Eb__12_0(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}

			internal bool _003CMarkGlobalInstallersAsInstalled_003Eb__12_1(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20007CC")]
		private sealed class _003CRestartFromBootRoutine_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001A13")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001A14")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001A15")]
			[FieldOffset(Offset = "0x20")]
			public GameBootstrapper _003C_003E4__this;

			[Token(Token = "0x4001A16")]
			[FieldOffset(Offset = "0x28")]
			private AsyncOperation _003CloadOp_003E5__2;

			[Token(Token = "0x17000330")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60020F7")]
				[Address(RVA = "0x3DC02F0", Offset = "0x3DC02F0", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000331")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60020F9")]
				[Address(RVA = "0x3DC0338", Offset = "0x3DC0338", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60020F4")]
			[Address(RVA = "0x3DBF9F4", Offset = "0x3DBF9F4", Length = "0x2C")]
			public _003CRestartFromBootRoutine_003Ed__17(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60020F5")]
			[Address(RVA = "0x3DC00AC", Offset = "0x3DC00AC", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60020F6")]
			[Address(RVA = "0x3DC00B0", Offset = "0x3DC00B0", Length = "0x240")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GameBootstrapper._003CRestartFromBootRoutine_003Ed__17::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60020F8")]
			[Address(RVA = "0x3DC02F8", Offset = "0x3DC02F8", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[ClearOnReload]
		[Token(Token = "0x4001A05")]
		public static GameBootstrapper Instance;

		[SerializeField]
		[Token(Token = "0x4001A06")]
		[FieldOffset(Offset = "0x20")]
		private GameModeConfig _gameModeConfig;

		[SerializeField]
		[Token(Token = "0x4001A07")]
		[FieldOffset(Offset = "0x28")]
		private bool _dontDestroyOnLoad;

		[Token(Token = "0x4001A08")]
		[FieldOffset(Offset = "0x30")]
		private SceneFlow _sceneFlow;

		[Token(Token = "0x4001A09")]
		[FieldOffset(Offset = "0x38")]
		internal InstallOrchestrator _installOrchestrator;

		[Token(Token = "0x4001A0A")]
		[FieldOffset(Offset = "0x40")]
		internal ScopeRegistry _scopeRegistry;

		[Token(Token = "0x4001A0B")]
		[FieldOffset(Offset = "0x48")]
		private ContainerManager _containerManager;

		[Token(Token = "0x4001A0C")]
		[FieldOffset(Offset = "0x50")]
		private GameObject _globalScopeRoot;

		[Token(Token = "0x4001A0D")]
		[FieldOffset(Offset = "0x58")]
		private string _bootSceneName;

		[Token(Token = "0x4001A0E")]
		[FieldOffset(Offset = "0x60")]
		private bool _isRestarting;

		[Token(Token = "0x60020E1")]
		[Address(RVA = "0x3DBDD4C", Offset = "0x3DBDD4C", Length = "0x2F4")]
		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Debug.LogWarning("[GameBootstrapper] Another instance already exists! Destroying this one.");
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
				return;
			}
			Instance = this;
			GameObject gameObject = base.gameObject;
			Scene scene = gameObject.scene;
			Scene scene2 = scene;
			string bootSceneName = scene2.name;
			_bootSceneName = bootSceneName;
			UnityEngine.Object gameModeConfig;
			if (!_dontDestroyOnLoad)
			{
				gameModeConfig = _gameModeConfig;
			}
			else
			{
				GameObject target = base.gameObject;
				UnityEngine.Object.DontDestroyOnLoad(target);
				gameModeConfig = _gameModeConfig;
			}
			if (gameModeConfig == null)
			{
				Debug.LogError("[GameBootstrapper] GameModeConfig is not assigned!");
				base.enabled = false;
			}
			else
			{
				Screen.sleepTimeout = -1;
				Initialize();
			}
		}

		[Token(Token = "0x60020E2")]
		[Address(RVA = "0x3DBE040", Offset = "0x3DBE040", Length = "0x40C")]
		private void Initialize()
		{
			GameObject globalScopeRoot = new GameObject("GlobalScope");
			_globalScopeRoot = globalScopeRoot;
			Transform transform = _globalScopeRoot.transform;
			Transform parent = base.transform;
			transform.SetParent(parent);
			if (_dontDestroyOnLoad)
			{
				UnityEngine.Object.DontDestroyOnLoad(_globalScopeRoot);
			}
			GameModeConfig gameModeConfig = _gameModeConfig;
			IEnumerable<object> source = gameModeConfig._globalInstallers.Cast<object>();
			List<object> collection = source.ToList();
			List<IContainerInstaller> list = new List<IContainerInstaller>();
			Transform parentTransform = _globalScopeRoot.transform;
			GlobalScopeContextInstaller item = new GlobalScopeContextInstaller(parentTransform);
			list.Add(item);
			list.AddRange((IEnumerable<IContainerInstaller>)collection);
			IContainerInstaller[] globalInstallers = list.ToArray();
			ContainerManager containerManager = new ContainerManager(globalInstallers);
			_containerManager = containerManager;
			ScopeRegistry scopeRegistry = new ScopeRegistry();
			_scopeRegistry = scopeRegistry;
			Transform globalScopeParent = _globalScopeRoot.transform;
			_scopeRegistry.Initialize(_containerManager, globalScopeParent);
			InstallOrchestrator installOrchestrator = new InstallOrchestrator(_scopeRegistry, _gameModeConfig);
			_installOrchestrator = installOrchestrator;
			MarkGlobalInstallersAsInstalled();
			SceneFlow sceneFlow = new SceneFlow(_installOrchestrator, _gameModeConfig);
			_sceneFlow = sceneFlow;
			ScopeRegistry scopeRegistry2 = _scopeRegistry;
			scopeRegistry2._loadTask = _sceneFlow;
			_sceneFlow.StartFlow();
		}

		[Token(Token = "0x60020E3")]
		[Address(RVA = "0x3DBE8DC", Offset = "0x3DBE8DC", Length = "0x8A4")]
		private void MarkGlobalInstallersAsInstalled()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameBootstrapper::MarkGlobalInstallersAsInstalled");
		}

		[Token(Token = "0x60020E4")]
		[Address(RVA = "0x3DBF408", Offset = "0x3DBF408", Length = "0xB8")]
		private void TestLogException()
		{
			Exception exception = new Exception("This is a test exception from GameBootstrapper");
			Debug.LogException(exception);
		}

		[Token(Token = "0x60020E5")]
		[Address(RVA = "0x3DBF4C0", Offset = "0x3DBF4C0", Length = "0x98")]
		public void InstallFeature(string featureTag)
		{
			if (_installOrchestrator != null)
			{
				string featureTag2 = default(string);
				_installOrchestrator.InstallOnDemandFeature(featureTag2);
			}
			else
			{
				Debug.LogError("[GameBootstrapper] Cannot install feature: system not initialized");
			}
		}

		[Token(Token = "0x60020E6")]
		[Address(RVA = "0x3DBF824", Offset = "0x3DBF824", Length = "0x158")]
		public void RestartFromBoot()
		{
			if (_isRestarting)
			{
				Debug.LogWarning("[GameBootstrapper] Restart already in progress");
				return;
			}
			if (string.IsNullOrEmpty(_bootSceneName))
			{
				Debug.LogError("[GameBootstrapper] Boot scene name is not captured, cannot restart");
				return;
			}
			_isRestarting = true;
			_003CRestartFromBootRoutine_003Ed__17 _003CRestartFromBootRoutine_003Ed__18 = (_003CRestartFromBootRoutine_003Ed__17)FormatterServices.GetUninitializedObject(typeof(_003CRestartFromBootRoutine_003Ed__17));
			_003CRestartFromBootRoutine_003Ed__18._003C_003E1__state = 0;
			_003CRestartFromBootRoutine_003Ed__18._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CRestartFromBootRoutine_003Ed__18);
		}

		[IteratorStateMachine(typeof(_003CRestartFromBootRoutine_003Ed__17))]
		[Token(Token = "0x60020E7")]
		[Address(RVA = "0x3DBF97C", Offset = "0x3DBF97C", Length = "0x78")]
		private IEnumerator RestartFromBootRoutine()
		{
			_003CRestartFromBootRoutine_003Ed__17 _003CRestartFromBootRoutine_003Ed__18 = (_003CRestartFromBootRoutine_003Ed__17)FormatterServices.GetUninitializedObject(typeof(_003CRestartFromBootRoutine_003Ed__17));
			_003CRestartFromBootRoutine_003Ed__18._003C_003E1__state = 0;
			_003CRestartFromBootRoutine_003Ed__18._003C_003E4__this = this;
			return _003CRestartFromBootRoutine_003Ed__18;
		}

		[Token(Token = "0x60020E8")]
		[Address(RVA = "0x3DBFA20", Offset = "0x3DBFA20", Length = "0x8")]
		public ScopeRegistry GetScopeRegistry()
		{
			return _scopeRegistry;
		}

		[Token(Token = "0x60020E9")]
		[Address(RVA = "0x3DBFA28", Offset = "0x3DBFA28", Length = "0x8")]
		public ContainerManager GetContainerManager()
		{
			return _containerManager;
		}

		[Token(Token = "0x60020EA")]
		[Address(RVA = "0x3DBFA30", Offset = "0x3DBFA30", Length = "0xD8")]
		private void OnApplicationQuit()
		{
			if (_scopeRegistry != null)
			{
				_scopeRegistry.DisposeAll();
			}
			if (_globalScopeRoot != null)
			{
				UnityEngine.Object.Destroy(_globalScopeRoot);
			}
		}

		[Token(Token = "0x60020EB")]
		[Address(RVA = "0x3DBFD40", Offset = "0x3DBFD40", Length = "0x10")]
		public GameBootstrapper()
		{
			_dontDestroyOnLoad = true;
		}
	}
}

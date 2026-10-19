using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreSystem.New.BoosterSystem.ForcePour.Configs;
using _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck;
using _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.InputSystem;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.New.BoosterSystem.ForcePour.Core
{
	[Token(Token = "0x2000491")]
	public class ForcePourController : MonoBehaviour, IDisposable
	{
		[Token(Token = "0x2000492")]
		private enum State
		{
			[Token(Token = "0x4000F16")]
			Inactive = 0,
			[Token(Token = "0x4000F17")]
			Selecting = 1,
			[Token(Token = "0x4000F18")]
			Executing = 2
		}

		[SerializeField]
		[Token(Token = "0x4000EF7")]
		[FieldOffset(Offset = "0x20")]
		private ForcePourConfigSO m_config;

		[SerializeField]
		[Token(Token = "0x4000EF8")]
		[FieldOffset(Offset = "0x28")]
		private Transform m_overlayParent;

		[SerializeField]
		[Token(Token = "0x4000EF9")]
		[FieldOffset(Offset = "0x30")]
		private Transform m_hammerParent;

		[SerializeField]
		[Token(Token = "0x4000EFA")]
		[FieldOffset(Offset = "0x38")]
		private Camera m_camera;

		[SerializeField]
		[Token(Token = "0x4000EFB")]
		[FieldOffset(Offset = "0x40")]
		private LayerMask m_raycastMask;

		[SerializeField]
		[Token(Token = "0x4000EFC")]
		[FieldOffset(Offset = "0x44")]
		private float m_raycastDistance;

		[Inject(false)]
		[Token(Token = "0x4000EFD")]
		[FieldOffset(Offset = "0x48")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000EFE")]
		[FieldOffset(Offset = "0x50")]
		private ForcePourTargeter _targeter;

		[Inject(false)]
		[Token(Token = "0x4000EFF")]
		[FieldOffset(Offset = "0x58")]
		private MoldAbsorptionBridge _absorptionBridge;

		[Inject(false)]
		[Token(Token = "0x4000F00")]
		[FieldOffset(Offset = "0x60")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x4000F01")]
		[FieldOffset(Offset = "0x68")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000F02")]
		[FieldOffset(Offset = "0x70")]
		private SandBreakEventQueue _breakEventQueue;

		[Inject(true)]
		[Token(Token = "0x4000F03")]
		[FieldOffset(Offset = "0x78")]
		private InputBlockService _inputBlockService;

		[Inject(true)]
		[Token(Token = "0x4000F04")]
		[FieldOffset(Offset = "0x80")]
		private IFailCheckSuppressor _failSuppressor;

		[Inject(true)]
		[Token(Token = "0x4000F05")]
		[FieldOffset(Offset = "0x88")]
		private IWinCheckSuppressor _winSuppressor;

		[CompilerGenerated]
		[Token(Token = "0x4000F06")]
		[FieldOffset(Offset = "0x90")]
		private Action OnUsed;

		[CompilerGenerated]
		[Token(Token = "0x4000F07")]
		[FieldOffset(Offset = "0x98")]
		private Action OnCancelled;

		[Token(Token = "0x4000F08")]
		[FieldOffset(Offset = "0xA0")]
		private State _state;

		[Token(Token = "0x4000F09")]
		[FieldOffset(Offset = "0xA8")]
		private readonly HashSet<int> _eligibleEntityIndices;

		[Token(Token = "0x4000F0A")]
		[FieldOffset(Offset = "0xB0")]
		private readonly List<GameObject> _overlayInstances;

		[Token(Token = "0x4000F0B")]
		[FieldOffset(Offset = "0xB8")]
		private Action _onPouringStarted;

		[Token(Token = "0x4000F0C")]
		[FieldOffset(Offset = "0xC0")]
		private IDisposable _inputBlockHandle;

		[Token(Token = "0x4000F0D")]
		[FieldOffset(Offset = "0xC8")]
		private IDisposable _failSuppressHandle;

		[Token(Token = "0x4000F0E")]
		[FieldOffset(Offset = "0xD0")]
		private IDisposable _winSuppressHandle;

		[Token(Token = "0x4000F0F")]
		[FieldOffset(Offset = "0xD8")]
		private int _expectedArrivals;

		[Token(Token = "0x4000F10")]
		[FieldOffset(Offset = "0xE0")]
		private GameObject _hammerInstance;

		[Token(Token = "0x4000F11")]
		[FieldOffset(Offset = "0xE8")]
		private Tween _hammerDelayTween;

		[Token(Token = "0x4000F12")]
		[FieldOffset(Offset = "0xF8")]
		private IDisposable _postExecuteBoosterBlockHandle;

		[Token(Token = "0x4000F13")]
		[FieldOffset(Offset = "0x100")]
		private Tween _postExecuteBoosterBlockTween;

		[Token(Token = "0x4000F14")]
		[FieldOffset(Offset = "0x110")]
		private bool _disposed;

		[Token(Token = "0x170001A1")]
		[field: Token(Token = "0x4000EF6")]
		public static ForcePourController Instance
		{
			[Token(Token = "0x60012F5")]
			[Address(RVA = "0x3CE1DB0", Offset = "0x3CE1DB0", Length = "0x4C")]
			get;
			[Token(Token = "0x60012F6")]
			[Address(RVA = "0x3CE1DFC", Offset = "0x3CE1DFC", Length = "0x5C")]
			private set;
		}

		[Token(Token = "0x170001A2")]
		public ForcePourConfigSO Config
		{
			[Token(Token = "0x60012F7")]
			[Address(RVA = "0x3CE1E58", Offset = "0x3CE1E58", Length = "0x8")]
			get
			{
				return m_config;
			}
		}

		[Token(Token = "0x170001A3")]
		public ForcePourAbsorptionProfile AbsorptionProfile
		{
			[Token(Token = "0x60012F8")]
			[Address(RVA = "0x3CE1E60", Offset = "0x3CE1E60", Length = "0xD0")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::get_AbsorptionProfile");
				return default;
			}
		}

		[Token(Token = "0x170001A4")]
		public float StaggerDuration
		{
			[Token(Token = "0x60012F9")]
			[Address(RVA = "0x3CE1F30", Offset = "0x3CE1F30", Length = "0xC4")]
			get
			{
				if (Config != null)
				{
					ForcePourConfigSO config = Config;
					return config.staggerDuration;
				}
				return 1.2f;
			}
		}

		[Token(Token = "0x170001A5")]
		public bool IsActive
		{
			[Token(Token = "0x60012FA")]
			[Address(RVA = "0x3CE1FF4", Offset = "0x3CE1FF4", Length = "0x10")]
			get
			{
				bool flag = _state == State.Inactive;
				return !flag;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x60012FB")]
		[Address(RVA = "0x3CE2004", Offset = "0x3CE2004", Length = "0xA4")]
		public void add_OnUsed(Action value)
		{
			Action action = OnUsed;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnUsed, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60012FC")]
		[Address(RVA = "0x3CE20A8", Offset = "0x3CE20A8", Length = "0xA4")]
		public void remove_OnUsed(Action value)
		{
			Action action = OnUsed;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnUsed, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60012FD")]
		[Address(RVA = "0x3CE214C", Offset = "0x3CE214C", Length = "0xA4")]
		public void add_OnCancelled(Action value)
		{
			Action action = OnCancelled;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnCancelled, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60012FE")]
		[Address(RVA = "0x3CE21F0", Offset = "0x3CE21F0", Length = "0xA4")]
		public void remove_OnCancelled(Action value)
		{
			Action action = OnCancelled;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnCancelled, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x60012FF")]
		[Address(RVA = "0x3CE2294", Offset = "0x3CE2294", Length = "0x1B0")]
		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		[Token(Token = "0x6001300")]
		[Address(RVA = "0x3CE2444", Offset = "0x3CE2444", Length = "0x110")]
		private void OnDestroy()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001301")]
		[Address(RVA = "0x3CE2554", Offset = "0x3CE2554", Length = "0x8")]
		private void Construct()
		{
			_disposed = false;
		}

		[Token(Token = "0x6001302")]
		[Address(RVA = "0x3CE255C", Offset = "0x3CE255C", Length = "0x100")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::Dispose");
		}

		[Token(Token = "0x6001303")]
		[Address(RVA = "0x3CE2954", Offset = "0x3CE2954", Length = "0xC0")]
		private void Update()
		{
			if (!_disposed && _state == State.Selecting && Input.GetMouseButtonDown(0) && (_inputBlockService == null || !_inputBlockService.IsBlocked(InputChannel.ForcePourTarget)) && !GameplayInputController.IsPointerOverInteractableUI())
			{
				Vector3 mousePosition = Input.mousePosition;
				HandleClick(mousePosition);
			}
		}

		[Token(Token = "0x6001304")]
		[Address(RVA = "0x3CE2C38", Offset = "0x3CE2C38", Length = "0x308")]
		public bool Activate(Action onPouringStarted = null)
		{
			if (!_disposed && _state == State.Inactive)
			{
				if (Config == null)
				{
					Debug.LogError("[ForcePourController] Config not assigned.");
					return false;
				}
				ScanEligibleCubes();
				HashSet<int> eligibleEntityIndices = _eligibleEntityIndices;
				if (eligibleEntityIndices.Count != 0)
				{
					SpawnOverlays();
					if (_inputBlockService != null)
					{
						IDisposable inputBlockHandle = _inputBlockService.RequestBlock("ForcePourSelect", InputChannel.CubeInteraction | InputChannel.VacuumButton | InputChannel.SwapButton);
						_inputBlockHandle = inputBlockHandle;
					}
					IDisposable failSuppressHandle;
					if (_failSuppressor == null)
					{
						failSuppressHandle = null;
					}
					else
					{
						IDisposable disposable = _failSuppressor.RequestSuppress("hammer_booster");
						failSuppressHandle = disposable;
					}
					_failSuppressHandle = failSuppressHandle;
					IDisposable winSuppressHandle;
					if (_winSuppressor == null)
					{
						winSuppressHandle = null;
					}
					else
					{
						IDisposable disposable2 = _winSuppressor.RequestSuppress("hammer_booster");
						winSuppressHandle = disposable2;
					}
					_winSuppressHandle = winSuppressHandle;
					_onPouringStarted = onPouringStarted;
					_state = State.Selecting;
					return true;
				}
				if (OnCancelled != null)
				{
					OnCancelled();
					return false;
				}
			}
			return false;
		}

		[Token(Token = "0x6001305")]
		[Address(RVA = "0x3CE35C0", Offset = "0x3CE35C0", Length = "0xC8")]
		public void Cancel()
		{
			if (_state != State.Inactive)
			{
				CleanupVisualsAndHandles();
				if (_absorptionBridge != null)
				{
					Action value = OnParticleAbsorbed;
					_absorptionBridge.remove_OnParticleAbsorbed(value);
				}
				_state = default(State);
				if (OnCancelled != null)
				{
					OnCancelled();
				}
			}
		}

		[Token(Token = "0x6001306")]
		[Address(RVA = "0x3CE2F40", Offset = "0x3CE2F40", Length = "0x1DC")]
		private void ScanEligibleCubes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::ScanEligibleCubes");
		}

		[Token(Token = "0x6001307")]
		[Address(RVA = "0x3CE3688", Offset = "0x3CE3688", Length = "0x230")]
		private bool IsEligible(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::IsEligible");
			return default;
		}

		[Token(Token = "0x6001308")]
		[Address(RVA = "0x3CE311C", Offset = "0x3CE311C", Length = "0x4A4")]
		private void SpawnOverlays()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::SpawnOverlays");
		}

		[Token(Token = "0x6001309")]
		[Address(RVA = "0x3CE38B8", Offset = "0x3CE38B8", Length = "0x1EC")]
		private void ClearPreviewTags()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::ClearPreviewTags");
		}

		[Token(Token = "0x600130A")]
		[Address(RVA = "0x3CE2A14", Offset = "0x3CE2A14", Length = "0x224")]
		private unsafe void HandleClick(Vector3 screenPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::HandleClick");
		}

		[Token(Token = "0x600130B")]
		[Address(RVA = "0x3CE3AA4", Offset = "0x3CE3AA4", Length = "0x1BC")]
		public void ExecuteEntity(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::ExecuteEntity");
		}

		[Token(Token = "0x600130C")]
		[Address(RVA = "0x3CE3C60", Offset = "0x3CE3C60", Length = "0x2F8")]
		private void PlayHammerThenExecute(Entity cube, GridCoord coord, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::PlayHammerThenExecute");
		}

		[Token(Token = "0x600130D")]
		[Address(RVA = "0x3CE3F58", Offset = "0x3CE3F58", Length = "0x3EC")]
		private void Execute(Entity cube, GridCoord coord, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::Execute");
		}

		[Token(Token = "0x600130E")]
		[Address(RVA = "0x3CE47C8", Offset = "0x3CE47C8", Length = "0x168")]
		private void StartPostExecuteBoosterBlock()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::StartPostExecuteBoosterBlock");
		}

		[Token(Token = "0x600130F")]
		[Address(RVA = "0x3CE4930", Offset = "0x3CE4930", Length = "0x104")]
		private void ReleasePostExecuteBoosterBlock()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::ReleasePostExecuteBoosterBlock");
		}

		[Token(Token = "0x6001310")]
		[Address(RVA = "0x3CE446C", Offset = "0x3CE446C", Length = "0x1DC")]
		private unsafe void EnqueueForceBreakEvent(GridCoord coord, GameColor color, int totalClaimed, List<ForcePourTargeter.EntityCount> allocations)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::EnqueueForceBreakEvent");
		}

		[Token(Token = "0x6001311")]
		[Address(RVA = "0x3CE4408", Offset = "0x3CE4408", Length = "0x64")]
		private int ResolveParticlesPerCube()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::ResolveParticlesPerCube");
			return default;
		}

		[Token(Token = "0x6001312")]
		[Address(RVA = "0x3CE4A34", Offset = "0x3CE4A34", Length = "0xCC")]
		private void OnParticleAbsorbed()
		{
			if (_state == State.Executing && --_expectedArrivals <= 0)
			{
				if (_absorptionBridge != null)
				{
					Action value = OnParticleAbsorbed;
					_absorptionBridge.remove_OnParticleAbsorbed(value);
				}
				Finalize();
			}
		}

		[Token(Token = "0x6001313")]
		[Address(RVA = "0x3CE265C", Offset = "0x3CE265C", Length = "0xA0")]
		private void UnsubscribeArrivalTracker()
		{
			if (_absorptionBridge != null)
			{
				Action value = OnParticleAbsorbed;
				_absorptionBridge.remove_OnParticleAbsorbed(value);
			}
		}

		[Token(Token = "0x6001314")]
		[Address(RVA = "0x3CE4B00", Offset = "0x3CE4B00", Length = "0x15C")]
		private void Finalize()
		{
			if (_failSuppressHandle != null)
			{
				_failSuppressHandle.Dispose();
			}
			_failSuppressHandle = null;
			if (_winSuppressHandle != null)
			{
				_winSuppressHandle.Dispose();
			}
			_winSuppressHandle = null;
			_state = default(State);
			if (OnUsed != null)
			{
				OnUsed();
			}
		}

		[Token(Token = "0x6001315")]
		[Address(RVA = "0x3CE4344", Offset = "0x3CE4344", Length = "0xC4")]
		private void FinalizeUnused()
		{
			if (_absorptionBridge != null)
			{
				Action value = OnParticleAbsorbed;
				_absorptionBridge.remove_OnParticleAbsorbed(value);
			}
			CleanupVisualsAndHandles();
			_state = default(State);
			if (OnCancelled != null)
			{
				OnCancelled();
			}
		}

		[Token(Token = "0x6001316")]
		[Address(RVA = "0x3CE4648", Offset = "0x3CE4648", Length = "0x180")]
		private void CleanupOverlaysOnly()
		{
			ClearPreviewTags();
			List<GameObject> overlayInstances = _overlayInstances;
			int num = 0;
			while (num < overlayInstances.Count)
			{
				UnityEngine.Object obj = overlayInstances[num];
				if (obj != null)
				{
					GameObject obj2 = _overlayInstances[num];
					UnityEngine.Object.Destroy(obj2);
				}
				num++;
				overlayInstances = _overlayInstances;
			}
			overlayInstances.Clear();
			if (overlayInstances.Count >= 1)
			{
			}
			_eligibleEntityIndices.Clear();
		}

		[Token(Token = "0x6001317")]
		[Address(RVA = "0x3CE26FC", Offset = "0x3CE26FC", Length = "0x258")]
		private void CleanupVisualsAndHandles()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourController::CleanupVisualsAndHandles");
		}

		[Token(Token = "0x6001318")]
		[Address(RVA = "0x3CE4C5C", Offset = "0x3CE4C5C", Length = "0xF4")]
		public ForcePourController()
		{
			LayerMask raycastMask = -1;
			m_raycastMask = raycastMask;
			m_raycastDistance = 1000f;
			HashSet<int> eligibleEntityIndices = new HashSet<int>();
			_eligibleEntityIndices = eligibleEntityIndices;
			_overlayInstances = new List<GameObject>();
		}
	}
}

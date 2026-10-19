using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Systems;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts;
using _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck;
using _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck;
using _game.CoreSystem.Pooling;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.VacuumSystem;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x200044B")]
	public class VacuumFacade : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000D92")]
		[FieldOffset(Offset = "0x10")]
		private VacuumReservationService _reservation;

		[Inject(false)]
		[Token(Token = "0x4000D93")]
		[FieldOffset(Offset = "0x18")]
		private VacuumSequenceRunner _runner;

		[Inject(false)]
		[Token(Token = "0x4000D94")]
		[FieldOffset(Offset = "0x20")]
		private VacuumSpawner _spawner;

		[Inject(true)]
		[Token(Token = "0x4000D95")]
		[FieldOffset(Offset = "0x28")]
		private IFailCheckSuppressor _failSuppressor;

		[Inject(true)]
		[Token(Token = "0x4000D96")]
		[FieldOffset(Offset = "0x30")]
		private IWinCheckSuppressor _winSuppressor;

		[Inject(true)]
		[Token(Token = "0x4000D97")]
		[FieldOffset(Offset = "0x38")]
		private IVfxPool _vfxPool;

		[CompilerGenerated]
		[Token(Token = "0x4000D99")]
		[FieldOffset(Offset = "0x48")]
		private Action OnCompleted;

		[Token(Token = "0x4000D9A")]
		[FieldOffset(Offset = "0x50")]
		private readonly VacuumRuntimeContext _context;

		[Token(Token = "0x4000D9B")]
		[FieldOffset(Offset = "0x58")]
		private readonly VacuumSession _session;

		[Token(Token = "0x4000D9C")]
		[FieldOffset(Offset = "0x60")]
		private bool _mouthFillStarted;

		[Token(Token = "0x4000D9D")]
		[FieldOffset(Offset = "0x61")]
		private bool _disposed;

		[Token(Token = "0x4000D9E")]
		[FieldOffset(Offset = "0x68")]
		private IDisposable _failSuppressHandle;

		[Token(Token = "0x4000D9F")]
		[FieldOffset(Offset = "0x70")]
		private IDisposable _winSuppressHandle;

		[Token(Token = "0x1700018D")]
		[field: Token(Token = "0x4000D98")]
		[field: FieldOffset(Offset = "0x40")]
		public bool IsVacuuming
		{
			[Token(Token = "0x6001208")]
			[Address(RVA = "0x3CC8B74", Offset = "0x3CC8B74", Length = "0x8")]
			get;
			[Token(Token = "0x6001209")]
			[Address(RVA = "0x3CC8B7C", Offset = "0x3CC8B7C", Length = "0x8")]
			private set;
		}

		[CompilerGenerated]
		[Token(Token = "0x600120A")]
		[Address(RVA = "0x3CC8B84", Offset = "0x3CC8B84", Length = "0xA4")]
		public void add_OnCompleted(Action value)
		{
			Action action = OnCompleted;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnCompleted, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600120B")]
		[Address(RVA = "0x3CC8C28", Offset = "0x3CC8C28", Length = "0xA4")]
		public void remove_OnCompleted(Action value)
		{
			Action action = OnCompleted;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnCompleted, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x600120C")]
		[Address(RVA = "0x3CC8CCC", Offset = "0x3CC8CCC", Length = "0x1E4")]
		public void OnUpdate(float dt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumFacade::OnUpdate");
		}

		[Token(Token = "0x600120D")]
		[Address(RVA = "0x3CC8EB0", Offset = "0x3CC8EB0", Length = "0x438")]
		public bool Execute(VacuumExecuteConfig config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumFacade::Execute");
			return default;
		}

		[Token(Token = "0x600120E")]
		[Address(RVA = "0x3CC92E8", Offset = "0x3CC92E8", Length = "0xBC")]
		private void BeginSuction()
		{
			double timeAsDouble = Time.timeAsDouble;
			_context.StartSuction(timeAsDouble);
			VacuumSpawner spawner = _spawner;
			if (spawner.ActiveInstance != null)
			{
				spawner.ActiveInstance.StartSuckLoopVfx();
			}
		}

		[Token(Token = "0x600120F")]
		[Address(RVA = "0x3CC93A4", Offset = "0x3CC93A4", Length = "0xB0")]
		private void OnMouthToDispatchDelayDone()
		{
			VacuumSpawner spawner = _spawner;
			if (spawner.ActiveInstance != null)
			{
				spawner.ActiveInstance.StopSuckLoopVfx();
			}
			InstantSettleTransitParticles();
			_runner.MoveToSpitAndDispatch();
		}

		[Token(Token = "0x6001210")]
		[Address(RVA = "0x3CC9AB4", Offset = "0x3CC9AB4", Length = "0x24")]
		public void NotifyMouthArrival()
		{
			VacuumSession session = _session;
			int mouthArrivedCount = session.MouthArrivedCount + 1;
			session.MouthArrivedCount = mouthArrivedCount;
		}

		[Token(Token = "0x6001211")]
		[Address(RVA = "0x3CC9AD8", Offset = "0x3CC9AD8", Length = "0x34")]
		public void NotifyBulbArrival()
		{
			VacuumSession session = _session;
			int currentBulbCount = ++session.BulbArrivedCount;
			VacuumRuntimeContext context = _context;
			context.CurrentBulbCount = currentBulbCount;
		}

		[Token(Token = "0x6001212")]
		[Address(RVA = "0x3CC9B0C", Offset = "0x3CC9B0C", Length = "0x24")]
		public void NotifyDispatchMouthExit()
		{
			VacuumSequenceRunner runner = _runner;
			runner.Dispatch.NotifyDispatchMouthExit();
		}

		[Token(Token = "0x6001213")]
		[Address(RVA = "0x3CC9454", Offset = "0x3CC9454", Length = "0x660")]
		private unsafe void InstantSettleTransitParticles()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumFacade::InstantSettleTransitParticles");
		}

		[Token(Token = "0x6001214")]
		[Address(RVA = "0x3CC9B30", Offset = "0x3CC9B30", Length = "0xA8")]
		private void FinishSession()
		{
			CleanupAnyResidualVacuumParticles();
			VacuumDispatchCallback.NotifyExit = null;
			_context.EndSession();
			IsVacuuming = false;
			ReleaseSuppressHandles();
			if (OnCompleted != null)
			{
				OnCompleted();
			}
		}

		[Token(Token = "0x6001215")]
		[Address(RVA = "0x3CC9DB0", Offset = "0x3CC9DB0", Length = "0x12C")]
		private void ReleaseSuppressHandles()
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
		}

		[Token(Token = "0x6001216")]
		[Address(RVA = "0x3CC9BD8", Offset = "0x3CC9BD8", Length = "0x1D8")]
		private void CleanupAnyResidualVacuumParticles()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumFacade::CleanupAnyResidualVacuumParticles");
		}

		[Token(Token = "0x6001217")]
		[Address(RVA = "0x3CC9EDC", Offset = "0x3CC9EDC", Length = "0x1E8")]
		public void Dispose()
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			bool flag = _runner == null;
			VacuumFacade vacuumFacade = (VacuumFacade)(object)_runner;
			if (!flag)
			{
				_runner.Cancel();
				VacuumSequenceRunner runner = _runner;
				bool flag2 = _runner == null;
				vacuumFacade = (VacuumFacade)(object)_runner;
				if (!flag2)
				{
					bool flag3 = runner.Dispatch == null;
					vacuumFacade = (VacuumFacade)(object)runner.Dispatch;
					if (!flag3)
					{
						runner.Dispatch.Dispose();
						vacuumFacade = (VacuumFacade)(object)runner.Dispatch;
					}
				}
			}
			vacuumFacade.CleanupAnyResidualVacuumParticles();
			VacuumDispatchCallback.NotifyExit = null;
			bool flag4 = _spawner != null;
			bool flag5 = !flag4;
			bool flag6 = !flag5;
			UnityEngine.Object obj = null;
			if (flag6)
			{
				VacuumSpawner spawner = _spawner;
				obj = spawner.ActiveInstance;
			}
			UnityEngine.Object spawner2;
			if (!(obj != null))
			{
				spawner2 = _spawner;
			}
			else
			{
				((VacuumMono)obj).StopSuckLoopVfx();
				spawner2 = _spawner;
			}
			if (spawner2 != null)
			{
				_spawner.DestroyVacuum();
			}
			_context.Dispose();
			ReleaseSuppressHandles();
			OnCompleted = null;
			IsVacuuming = false;
			_mouthFillStarted = false;
		}

		[Token(Token = "0x6001218")]
		[Address(RVA = "0x3CCA0C4", Offset = "0x3CCA0C4", Length = "0xB0")]
		public VacuumFacade()
		{
			VacuumRuntimeContext context = new VacuumRuntimeContext();
			_context = context;
			VacuumSession session = new VacuumSession();
			_session = session;
		}
	}
}

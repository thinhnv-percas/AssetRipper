using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x2000449")]
	public class VacuumDispatchCoordinator : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000D88")]
		[FieldOffset(Offset = "0x10")]
		private MoldAbsorptionBridge _moldBridge;

		[Token(Token = "0x4000D89")]
		[FieldOffset(Offset = "0x18")]
		private VacuumSession _session;

		[Token(Token = "0x4000D8A")]
		[FieldOffset(Offset = "0x20")]
		private VacuumSpawner _spawner;

		[Token(Token = "0x4000D8B")]
		[FieldOffset(Offset = "0x28")]
		private VacuumRuntimeContext _context;

		[Token(Token = "0x4000D8C")]
		[FieldOffset(Offset = "0x30")]
		private Action _onAllDispatched;

		[Token(Token = "0x4000D8D")]
		[FieldOffset(Offset = "0x38")]
		private Tween _moldTransitionTween;

		[Token(Token = "0x4000D8E")]
		[FieldOffset(Offset = "0x48")]
		private Tween _rotateTween;

		[Token(Token = "0x1700018C")]
		private static SandPhysicsContext Physics
		{
			[Token(Token = "0x60011FC")]
			[Address(RVA = "0x3CC7670", Offset = "0x3CC7670", Length = "0x4C")]
			get
			{
				return SandPhysicsContext.Current;
			}
		}

		[Token(Token = "0x60011FD")]
		[Address(RVA = "0x3CC76BC", Offset = "0x3CC76BC", Length = "0x94")]
		public void Begin(VacuumSession session, VacuumSpawner spawner, VacuumRuntimeContext context, Action onAllDispatched)
		{
			_session = session;
			_spawner = spawner;
			_context = context;
			_onAllDispatched = onAllDispatched;
			VacuumSession session2 = _session;
			session2.CurrentReservationIndex = -1;
			session2.IsDripping = false;
			PrepareNext();
		}

		[Token(Token = "0x60011FE")]
		[Address(RVA = "0x3CC7970", Offset = "0x3CC7970", Length = "0x1E4")]
		public void Tick(float dt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumDispatchCoordinator::Tick");
		}

		[Token(Token = "0x60011FF")]
		[Address(RVA = "0x3CC835C", Offset = "0x3CC835C", Length = "0x164")]
		public void NotifyDispatchMouthExit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumDispatchCoordinator::NotifyDispatchMouthExit");
		}

		[Token(Token = "0x6001200")]
		[Address(RVA = "0x3CC7750", Offset = "0x3CC7750", Length = "0x220")]
		private void PrepareNext()
		{
			VacuumSpawner spawner = _spawner;
			int num;
			VacuumSession.Reservation entry;
			int num2;
			if ((object)_spawner != null)
			{
				if (spawner.ActiveInstance == null)
				{
					goto IL_0046;
				}
				VacuumSession session = _session;
				if (_session != null)
				{
					num = session.CurrentReservationIndex + 1;
					while (true)
					{
						List<VacuumSession.Reservation> reservations = session.Reservations;
						if (session.Reservations == null)
						{
							break;
						}
						if (num >= reservations.Count)
						{
							goto IL_0046;
						}
						entry = session.Reservations[num];
						num2 = num >> 32;
						if (num2 >= 1)
						{
							goto IL_0110;
						}
						session = _session;
						num++;
						if (_session == null)
						{
							break;
						}
					}
				}
			}
			goto IL_021b;
			IL_021b:
			throw new NullReferenceException();
			IL_0110:
			if (_moldBridge != null)
			{
				float2 entityPourPointWorld = _moldBridge.GetEntityPourPointWorld(entry.moldEntityIndex);
				VacuumSession session2 = _session;
				if (_session != null)
				{
					session2.CurrentMoldExitedCount = 0;
					session2.CurrentMoldTotalParticles = num2;
					session2.CurrentReservationIndex = num;
					session2.IsDripping = false;
					session2.DripSpawnedCount = 0;
					DispatchEntry(entry, spawner.ActiveInstance, entityPourPointWorld);
					return;
				}
				goto IL_021b;
			}
			NullReferenceException ex = new NullReferenceException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
			return;
			IL_0046:
			if (_onAllDispatched != null)
			{
				_onAllDispatched();
			}
		}

		[Token(Token = "0x6001201")]
		[Address(RVA = "0x3CC84C0", Offset = "0x3CC84C0", Length = "0x1F4")]
		private void DispatchEntry(VacuumSession.Reservation entry, VacuumMono vacuum, float2 pourPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumDispatchCoordinator::DispatchEntry");
		}

		[Token(Token = "0x6001202")]
		[Address(RVA = "0x3CC7B54", Offset = "0x3CC7B54", Length = "0x808")]
		private unsafe void SpawnDripBatch(int startIndex, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumDispatchCoordinator::SpawnDripBatch");
		}

		[Token(Token = "0x6001203")]
		[Address(RVA = "0x3CC86BC", Offset = "0x3CC86BC", Length = "0x3A0")]
		private unsafe void DestroyBulbParticles(int count, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumDispatchCoordinator::DestroyBulbParticles");
		}

		[Token(Token = "0x6001204")]
		[Address(RVA = "0x3CC8A5C", Offset = "0x3CC8A5C", Length = "0x90")]
		public void Dispose()
		{
			if (_moldTransitionTween.isAlive)
			{
				_moldTransitionTween.Stop();
			}
			if (_rotateTween.isAlive)
			{
				_rotateTween.Stop();
			}
			_session = null;
			_spawner = null;
			_context = null;
			_onAllDispatched = null;
		}

		[Token(Token = "0x6001205")]
		[Address(RVA = "0x3CC8AEC", Offset = "0x3CC8AEC", Length = "0x8")]
		public VacuumDispatchCoordinator()
		{
		}
	}
}

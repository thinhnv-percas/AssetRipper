using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x2000450")]
	public class VacuumSequenceRunner : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000452")]
		private struct _003CFinishAndDespawn_003Ed__19 : IAsyncStateMachine
		{
			[Token(Token = "0x4000DEA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4000DEB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncVoidMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4000DEC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public VacuumSequenceRunner _003C_003E4__this;

			[Token(Token = "0x4000DED")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private Tween.TweenAwaiter _003C_003Eu__1;

			[Token(Token = "0x600123D")]
			[Address(RVA = "0x3CCCF60", Offset = "0x3CCCF60", Length = "0x290")]
			private void MoveNext()
			{
				VacuumSequenceRunner vacuumSequenceRunner = _003C_003E4__this;
				Tween.TweenAwaiter awaiter2 = default(Tween.TweenAwaiter);
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E4__this != null)
					{
						VacuumSpawner spawner = vacuumSequenceRunner._spawner;
						if ((object)vacuumSequenceRunner._spawner != null)
						{
							if (!(spawner.ActiveInstance != null))
							{
								goto IL_0170;
							}
							if ((object)spawner.ActiveInstance != null)
							{
								Sequence sequence = spawner.ActiveInstance.PlayDespawnAnimation();
								Sequence sequence2 = sequence;
								Tween.TweenAwaiter awaiter = sequence2.GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									_003C_003E1__state = 0;
									_003C_003Eu__1 = awaiter2;
									_003C_003Et__builder.AwaitOnCompleted(ref awaiter2, ref this);
									return;
								}
								goto IL_02b4;
							}
							NullReferenceException ex = new NullReferenceException();
						}
						else
						{
							NullReferenceException ex = new NullReferenceException();
						}
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
					}
					goto IL_0257;
				}
				_003C_003Eu__1 = default(Tween.TweenAwaiter);
				_ = 0;
				_003C_003E1__state = -1;
				awaiter2 = _003C_003Eu__1;
				goto IL_02b4;
				IL_0257:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
				return;
				IL_0170:
				if (vacuumSequenceRunner._cancelled)
				{
					vacuumSequenceRunner.IsRunning = false;
				}
				else
				{
					if ((object)vacuumSequenceRunner._spawner == null)
					{
						NullReferenceException ex = new NullReferenceException();
						goto IL_0257;
					}
					vacuumSequenceRunner._spawner.DestroyVacuum();
					vacuumSequenceRunner.IsRunning = false;
					if (vacuumSequenceRunner._onCompleted != null)
					{
						vacuumSequenceRunner._onCompleted();
					}
				}
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetResult();
				return;
				IL_02b4:
				awaiter2.GetResult();
				if (_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					goto IL_0257;
				}
				goto IL_0170;
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600123E")]
			[Address(RVA = "0x3CCD1F0", Offset = "0x3CCD1F0", Length = "0xC")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000453")]
		private struct _003CMoveToSpitAndDispatch_003Ed__15 : IAsyncStateMachine
		{
			[Token(Token = "0x4000DEE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4000DEF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncVoidMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4000DF0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public VacuumSequenceRunner _003C_003E4__this;

			[Token(Token = "0x4000DF1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private Tween.TweenAwaiter _003C_003Eu__1;

			[Token(Token = "0x600123F")]
			[Address(RVA = "0x3CCD1FC", Offset = "0x3CCD1FC", Length = "0x348")]
			private void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumSequenceRunner._003CMoveToSpitAndDispatch_003Ed__15::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001240")]
			[Address(RVA = "0x3CCD544", Offset = "0x3CCD544", Length = "0xC")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000454")]
		private struct _003CRun_003Ed__13 : IAsyncStateMachine
		{
			[Token(Token = "0x4000DF2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4000DF3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncVoidMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4000DF4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public VacuumSequenceRunner _003C_003E4__this;

			[Token(Token = "0x4000DF5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public VacuumSpawner spawner;

			[Token(Token = "0x4000DF6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public VacuumRuntimeContext context;

			[Token(Token = "0x4000DF7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public VacuumSession session;

			[Token(Token = "0x4000DF8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			public Action onSuctionReady;

			[Token(Token = "0x4000DF9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public Action onAllDispatched;

			[Token(Token = "0x4000DFA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			public Action onCompleted;

			[Token(Token = "0x4000DFB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			private Tween.TweenAwaiter _003C_003Eu__1;

			[Token(Token = "0x6001241")]
			[Address(RVA = "0x3CCD550", Offset = "0x3CCD550", Length = "0x2E8")]
			private void MoveNext()
			{
				VacuumSequenceRunner vacuumSequenceRunner = _003C_003E4__this;
				Tween.TweenAwaiter awaiter2 = default(Tween.TweenAwaiter);
				NullReferenceException ex;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E4__this != null)
					{
						vacuumSequenceRunner._spawner = spawner;
						vacuumSequenceRunner._context = context;
						vacuumSequenceRunner._session = session;
						vacuumSequenceRunner._onSuctionReady = onSuctionReady;
						vacuumSequenceRunner._onAllDispatched = onAllDispatched;
						vacuumSequenceRunner._onCompleted = onCompleted;
						vacuumSequenceRunner._cancelled = false;
						vacuumSequenceRunner.IsRunning = true;
						VacuumSpawner vacuumSpawner = spawner;
						if ((object)spawner != null)
						{
							if (vacuumSpawner.ActiveInstance == null)
							{
								vacuumSequenceRunner.IsRunning = false;
								goto IL_0313;
							}
							if ((object)vacuumSpawner.ActiveInstance != null)
							{
								Sequence sequence = vacuumSpawner.ActiveInstance.PlaySpawnAndVacuumAnimation();
								Sequence sequence2 = sequence;
								Tween.TweenAwaiter awaiter = sequence2.GetAwaiter();
								if (awaiter2.IsCompleted)
								{
									goto IL_01c1;
								}
								_003C_003E1__state = 0;
								_003C_003Eu__1 = awaiter2;
								_003C_003Et__builder.AwaitOnCompleted(ref awaiter2, ref this);
								return;
							}
							ex = new NullReferenceException();
						}
						else
						{
							ex = new NullReferenceException();
						}
					}
					else
					{
						ex = new NullReferenceException();
					}
					goto IL_02b6;
				}
				_003C_003Eu__1 = default(Tween.TweenAwaiter);
				_ = 0;
				_003C_003E1__state = -1;
				awaiter2 = _003C_003Eu__1;
				goto IL_01c1;
				IL_0313:
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetResult();
				return;
				IL_02b6:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
				return;
				IL_01c1:
				awaiter2.GetResult();
				if (_003C_003E4__this != null)
				{
					if (!vacuumSequenceRunner._cancelled && vacuumSequenceRunner._onSuctionReady != null)
					{
						vacuumSequenceRunner._onSuctionReady();
					}
					goto IL_0313;
				}
				ex = new NullReferenceException();
				goto IL_02b6;
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001242")]
			[Address(RVA = "0x3CCD838", Offset = "0x3CCD838", Length = "0xC")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Inject(false)]
		[Token(Token = "0x4000DDE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private VacuumDispatchCoordinator _dispatch;

		[Token(Token = "0x4000DDF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private VacuumSpawner _spawner;

		[Token(Token = "0x4000DE0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private VacuumRuntimeContext _context;

		[Token(Token = "0x4000DE1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private VacuumSession _session;

		[Token(Token = "0x4000DE2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private Action _onSuctionReady;

		[Token(Token = "0x4000DE3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		private Action _onAllDispatched;

		[Token(Token = "0x4000DE4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		private Action _onCompleted;

		[Token(Token = "0x4000DE5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		private bool _cancelled;

		[Token(Token = "0x4000DE6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		private Tween _mouthToDispatchTween;

		[Token(Token = "0x17000194")]
		[field: Token(Token = "0x4000DE7")]
		[field: Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		public bool IsRunning
		{
			[Token(Token = "0x600122F")]
			[Address(RVA = "0x3CCC91C", Offset = "0x3CCC91C", Length = "0x8")]
			get;
			[Token(Token = "0x6001230")]
			[Address(RVA = "0x3CCC924", Offset = "0x3CCC924", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000195")]
		public VacuumDispatchCoordinator Dispatch
		{
			[Token(Token = "0x6001235")]
			[Address(RVA = "0x3CCCD08", Offset = "0x3CCCD08", Length = "0x8")]
			get
			{
				return _dispatch;
			}
		}

		[AsyncStateMachine(typeof(_003CRun_003Ed__13))]
		[Token(Token = "0x6001231")]
		[Address(RVA = "0x3CCC92C", Offset = "0x3CCC92C", Length = "0x148")]
		public void Run(VacuumSpawner spawner, VacuumRuntimeContext context, VacuumSession session, Action onSuctionReady, Action onAllDispatched, Action onCompleted)
		{
			AsyncVoidMethodBuilder _003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			_003CRun_003Ed__13 stateMachine = default(_003CRun_003Ed__13);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine._003C_003E4__this = this;
			stateMachine.spawner = spawner;
			stateMachine.context = context;
			stateMachine.session = session;
			stateMachine.onSuctionReady = onSuctionReady;
			stateMachine.onAllDispatched = onAllDispatched;
			stateMachine.onCompleted = onCompleted;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[Token(Token = "0x6001232")]
		[Address(RVA = "0x3CCCA74", Offset = "0x3CCCA74", Length = "0x1C0")]
		public void StartMouthToDispatchDelay(Action onDelayDone)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumSequenceRunner::StartMouthToDispatchDelay");
		}

		[AsyncStateMachine(typeof(_003CMoveToSpitAndDispatch_003Ed__15))]
		[Token(Token = "0x6001233")]
		[Address(RVA = "0x3CCCC3C", Offset = "0x3CCCC3C", Length = "0xB0")]
		public void MoveToSpitAndDispatch()
		{
			AsyncVoidMethodBuilder _003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			_003CMoveToSpitAndDispatch_003Ed__15 stateMachine = default(_003CMoveToSpitAndDispatch_003Ed__15);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[Token(Token = "0x6001234")]
		[Address(RVA = "0x3CCCCEC", Offset = "0x3CCCCEC", Length = "0x1C")]
		public void TickDispatch(float dt)
		{
			Dispatch.Tick(dt);
		}

		[AsyncStateMachine(typeof(_003CFinishAndDespawn_003Ed__19))]
		[Token(Token = "0x6001236")]
		[Address(RVA = "0x3CCCD10", Offset = "0x3CCCD10", Length = "0xB0")]
		public void FinishAndDespawn()
		{
			AsyncVoidMethodBuilder _003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			_003CFinishAndDespawn_003Ed__19 stateMachine = default(_003CFinishAndDespawn_003Ed__19);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[Token(Token = "0x6001237")]
		[Address(RVA = "0x3CCCDC0", Offset = "0x3CCCDC0", Length = "0x4C")]
		public void Cancel()
		{
			_cancelled = true;
			IsRunning = false;
			if (_mouthToDispatchTween.isAlive)
			{
				_mouthToDispatchTween.Stop();
			}
		}

		[Token(Token = "0x6001238")]
		[Address(RVA = "0x3CCCE0C", Offset = "0x3CCCE0C", Length = "0x4C")]
		public void Dispose()
		{
			_cancelled = true;
			IsRunning = false;
			if (_mouthToDispatchTween.isAlive)
			{
				_mouthToDispatchTween.Stop();
			}
		}

		[Token(Token = "0x6001239")]
		[Address(RVA = "0x3CCCE58", Offset = "0x3CCCE58", Length = "0x8")]
		public VacuumSequenceRunner()
		{
		}
	}
}

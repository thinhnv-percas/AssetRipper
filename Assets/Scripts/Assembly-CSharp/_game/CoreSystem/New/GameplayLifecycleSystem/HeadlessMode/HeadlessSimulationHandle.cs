using System;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.HeadlessMode
{
	[Token(Token = "0x200040A")]
	public sealed class HeadlessSimulationHandle : IDisposable
	{
		[Token(Token = "0x4000CC7")]
		[FieldOffset(Offset = "0x10")]
		private bool _disposed;

		[Token(Token = "0x4000CC8")]
		[FieldOffset(Offset = "0x18")]
		private readonly HeadlessReconcileDriver _driver;

		[Token(Token = "0x17000156")]
		[field: Token(Token = "0x4000CC9")]
		[field: FieldOffset(Offset = "0x20")]
		public ContainerManager Manager
		{
			[Token(Token = "0x60010EA")]
			[Address(RVA = "0x3CBB01C", Offset = "0x3CBB01C", Length = "0x8")]
			get;
		}

		[Token(Token = "0x60010EB")]
		[Address(RVA = "0x3CB96FC", Offset = "0x3CB96FC", Length = "0x120")]
		public HeadlessSimulationHandle(ContainerManager manager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HeadlessSimulationHandle::.ctor");
		}

		[Token(Token = "0x60010EC")]
		[Address(RVA = "0x3CBB024", Offset = "0x3CBB024", Length = "0x78")]
		public void Tick(float dt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HeadlessSimulationHandle::Tick");
		}

		[Token(Token = "0x60010ED")]
		[Address(RVA = "0x3CBB100", Offset = "0x3CBB100", Length = "0xAC")]
		public void RunUntilStable(int maxTicks = 1024)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HeadlessSimulationHandle::RunUntilStable");
		}

		[Token(Token = "0x60010EE")]
		[Address(RVA = "0x3CBB1AC", Offset = "0x3CBB1AC", Length = "0x70")]
		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				Manager.DisposeContainer<GameplayContainer>();
			}
		}

		[Token(Token = "0x60010EF")]
		[Address(RVA = "0x3CBB09C", Offset = "0x3CBB09C", Length = "0x64")]
		private void ThrowIfDisposed()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HeadlessSimulationHandle::ThrowIfDisposed");
		}
	}
}

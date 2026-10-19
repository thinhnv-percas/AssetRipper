using Cpp2ILInjected;
using Reflex.Attributes;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x2000421")]
	public class FailDetector
	{
		[Inject(false)]
		[Token(Token = "0x4000CFF")]
		[FieldOffset(Offset = "0x10")]
		internal FailSnapshotBuilder _builder;

		[Token(Token = "0x6001145")]
		[Address(RVA = "0x3CBE838", Offset = "0x3CBE838", Length = "0x34")]
		public bool IsStuck()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailDetector::IsStuck");
			return default;
		}

		[Token(Token = "0x6001146")]
		[Address(RVA = "0x3CBEC9C", Offset = "0x3CBEC9C", Length = "0x2C")]
		public static bool IsStuck(in GameStateSnapshot s)
		{
			if (s.AnyConveyorParticleAbsorbable)
			{
				return false;
			}
			if (s.AnyAbsorbingInFlight)
			{
				return false;
			}
			return s.ConveyorAtCapacity;
		}

		[Token(Token = "0x6001147")]
		[Address(RVA = "0x3CBDA2C", Offset = "0x3CBDA2C", Length = "0x8")]
		public FailDetector()
		{
		}
	}
}

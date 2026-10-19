using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;

namespace _game.CoreSystem.New.MoldSystem.Core.Conditions
{
	[Token(Token = "0x2000304")]
	public class NotDataCompleteCondition : IClaimCondition
	{
		[Token(Token = "0x6000D4C")]
		[Address(RVA = "0x3EED5B0", Offset = "0x3EED5B0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv51 = entity & 0x100000000;\n\tv53 = v51 == 0;\n\treturn v53;\n")]
		public bool CanClaim(EntityManager em, Entity entity, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotDataCompleteCondition::CanClaim");
			return default;
		}

		[Token(Token = "0x6000D4D")]
		[Address(RVA = "0x3EED620", Offset = "0x3EED620", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NotDataCompleteCondition()
		{
		}
	}
}

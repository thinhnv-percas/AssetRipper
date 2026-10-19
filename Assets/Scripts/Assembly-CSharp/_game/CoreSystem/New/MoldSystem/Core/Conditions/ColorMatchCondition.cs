using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;

namespace _game.CoreSystem.New.MoldSystem.Core.Conditions
{
	[Token(Token = "0x2000301")]
	public class ColorMatchCondition : IClaimCondition
	{
		[Token(Token = "0x6000D47")]
		[Address(RVA = "0x3EED3B0", Offset = "0x3EED3B0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv50 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv54 = v50 - color;\n\tv56 = v54 == 0;\n\treturn v56;\n")]
		public bool CanClaim(EntityManager em, Entity entity, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ColorMatchCondition::CanClaim");
			return default;
		}

		[Token(Token = "0x6000D48")]
		[Address(RVA = "0x3EED424", Offset = "0x3EED424", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ColorMatchCondition()
		{
		}
	}
}

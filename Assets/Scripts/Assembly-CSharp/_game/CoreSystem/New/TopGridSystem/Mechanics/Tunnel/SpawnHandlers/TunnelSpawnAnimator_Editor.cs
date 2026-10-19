using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers
{
	[Token(Token = "0x2000157")]
	public class TunnelSpawnAnimator_Editor : ITunnelSpawnAnimator
	{
		[Token(Token = "0x600069E")]
		[Address(RVA = "0x3DB9CD4", Offset = "0x3DB9CD4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public Sequence Animate(Entity entity, Entity tunnel)
		{
			return default(Sequence);
		}

		[Token(Token = "0x600069F")]
		[Address(RVA = "0x3DB9CE0", Offset = "0x3DB9CE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelSpawnAnimator_Editor()
		{
		}
	}
}

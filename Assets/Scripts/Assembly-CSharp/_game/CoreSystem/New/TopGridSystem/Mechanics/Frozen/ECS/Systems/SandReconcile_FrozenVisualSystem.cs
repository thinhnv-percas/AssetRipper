using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Systems
{
	[Token(Token = "0x2000246")]
	public class SandReconcile_FrozenVisualSystem : IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x40006F0")]
		[FieldOffset(Offset = "0x10")]
		private FrozenVisualHandler _visualHandler;

		[Token(Token = "0x60009DA")]
		[Address(RVA = "0x3E9C420", Offset = "0x3E9C420", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._visualHandler == 0;\n\tif (v2) goto L_0005;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler::RefreshDynamic(this._visualHandler);\n\treturn;\nL_0005:\n\treturn;\n")]
		public void Execute()
		{
			if (_visualHandler != null)
			{
				_visualHandler.RefreshDynamic();
			}
		}

		[Token(Token = "0x60009DB")]
		[Address(RVA = "0x3E9BBF0", Offset = "0x3E9BBF0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_FrozenVisualSystem()
		{
		}
	}
}

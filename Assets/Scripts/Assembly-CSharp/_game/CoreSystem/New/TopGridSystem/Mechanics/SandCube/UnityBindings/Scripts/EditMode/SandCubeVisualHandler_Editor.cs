using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x2000192")]
	public class SandCubeVisualHandler_Editor : SandCubeVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x400051D")]
		[FieldOffset(Offset = "0x48")]
		private EditorHistory _history;

		[Token(Token = "0x6000788")]
		[Address(RVA = "0x3E6ADB0", Offset = "0x3E6ADB0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = UnityEngine.GameObject::AddComponent(go);\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.SandCubeEntityActions::Bind(v49, entity, this._history);\n\treturn;\n")]
		protected override void OnSpawned(GameObject go, Entity entity)
		{
			SandCubeEntityActions sandCubeEntityActions = go.AddComponent<SandCubeEntityActions>();
			sandCubeEntityActions.Bind(entity, _history);
		}

		[Token(Token = "0x6000789")]
		[Address(RVA = "0x3E6AE28", Offset = "0x3E6AE28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandCubeVisualHandler_Editor()
		{
		}
	}
}

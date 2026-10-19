using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x20001EF")]
	public class KeyVisualHandler_Editor : KeyVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000638")]
		[FieldOffset(Offset = "0x40")]
		private EditorHistory _history;

		[Token(Token = "0x60008DE")]
		[Address(RVA = "0x3E88EF4", Offset = "0x3E88EF4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = UnityEngine.GameObject::AddComponent(go);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(v49, entity, this._history);\n\treturn;\n")]
		protected override void OnSpawned(GameObject go, Entity entity)
		{
			KeyEntityActions keyEntityActions = go.AddComponent<KeyEntityActions>();
			keyEntityActions.BindCore(entity, _history);
		}

		[Token(Token = "0x60008DF")]
		[Address(RVA = "0x3E88F6C", Offset = "0x3E88F6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public KeyVisualHandler_Editor()
		{
		}
	}
}

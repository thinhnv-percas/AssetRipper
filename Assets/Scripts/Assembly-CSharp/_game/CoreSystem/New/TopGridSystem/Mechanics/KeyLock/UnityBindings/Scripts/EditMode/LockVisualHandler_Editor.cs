using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x20001F0")]
	public class LockVisualHandler_Editor : LockVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000639")]
		[FieldOffset(Offset = "0x58")]
		private EditorHistory _history;

		[Token(Token = "0x60008E0")]
		[Address(RVA = "0x3E88F74", Offset = "0x3E88F74", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = UnityEngine.GameObject::AddComponent(go);\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.LockEntityActions::Bind(v49, entity, this._history);\n\treturn;\n")]
		protected override void OnSpawned(GameObject go, Entity entity)
		{
			LockEntityActions lockEntityActions = go.AddComponent<LockEntityActions>();
			lockEntityActions.Bind(entity, _history);
		}

		[Token(Token = "0x60008E1")]
		[Address(RVA = "0x3E88FEC", Offset = "0x3E88FEC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::.ctor(this);\n\treturn;\n")]
		public LockVisualHandler_Editor()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x2000151")]
	public class TunnelVisualHandler_Editor : TunnelVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x400044A")]
		[FieldOffset(Offset = "0x38")]
		private EditorHistory _history;

		[Token(Token = "0x6000692")]
		[Address(RVA = "0x3DB8D00", Offset = "0x3DB8D00", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = UnityEngine.GameObject::AddComponent(go);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(v49, entity, this._history);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelEntityActions::RefreshQueueView(v49);\n\treturn;\n")]
		protected override void OnSpawned(GameObject go, Entity entity)
		{
			TunnelEntityActions tunnelEntityActions = go.AddComponent<TunnelEntityActions>();
			tunnelEntityActions.BindCore(entity, _history);
			tunnelEntityActions.RefreshQueueView();
		}

		[Token(Token = "0x6000693")]
		[Address(RVA = "0x3DB8D84", Offset = "0x3DB8D84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelVisualHandler_Editor()
		{
		}
	}
}

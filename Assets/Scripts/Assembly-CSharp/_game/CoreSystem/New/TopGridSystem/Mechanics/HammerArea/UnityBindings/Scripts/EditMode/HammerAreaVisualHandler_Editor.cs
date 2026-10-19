using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x200020A")]
	public class HammerAreaVisualHandler_Editor : HammerAreaVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000674")]
		[FieldOffset(Offset = "0x38")]
		private EditorHistory _history;

		[Token(Token = "0x6000937")]
		[Address(RVA = "0x3E903EC", Offset = "0x3E903EC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = UnityEngine.GameObject::AddComponent(go);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(v49, entity, this._history);\n\treturn;\n")]
		protected override void OnSpawned(GameObject go, Entity entity)
		{
			HammerAreaEntityActions hammerAreaEntityActions = go.AddComponent<HammerAreaEntityActions>();
			hammerAreaEntityActions.BindCore(entity, _history);
		}

		[Token(Token = "0x6000938")]
		[Address(RVA = "0x3E90464", Offset = "0x3E90464", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerAreaVisualHandler_Editor()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x2000225")]
	public class GarageVisualHandler_Editor : GarageVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x40006B7")]
		[FieldOffset(Offset = "0x40")]
		private EditorHistory _history;

		[Token(Token = "0x600098F")]
		[Address(RVA = "0x3E97284", Offset = "0x3E97284", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = UnityEngine.GameObject::AddComponent(go);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(v49, entity, this._history);\n\treturn;\n")]
		protected override void OnSpawned(GameObject go, Entity entity)
		{
			GarageEntityActions garageEntityActions = go.AddComponent<GarageEntityActions>();
			garageEntityActions.BindCore(entity, _history);
		}

		[Token(Token = "0x6000990")]
		[Address(RVA = "0x3E972FC", Offset = "0x3E972FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GarageVisualHandler_Editor()
		{
		}
	}
}

using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode
{
	[Token(Token = "0x20001D7")]
	public class LinkedCubeRemoveHook : IEntityRemoveHook
	{
		[Inject(false)]
		[Token(Token = "0x40005AF")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x40005B0")]
		[FieldOffset(Offset = "0x18")]
		private LinkedCubeEditorMutations _mutations;

		[Inject(true)]
		[Token(Token = "0x40005B1")]
		[FieldOffset(Offset = "0x20")]
		private LinkedCubeVisualHandler _visualHandler;

		[Token(Token = "0x40005B2")]
		[FieldOffset(Offset = "0x28")]
		internal readonly List<GridCoord> _removedCoords;

		[Token(Token = "0x6000871")]
		[Address(RVA = "0x3E7D7EC", Offset = "0x3E7D7EC", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv61 = this._removedCoords;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Clear(v61);\n\tv145 = entities == 0;\n\tif (v145) goto L_010C;\n\tv151 = 0;\n\tgoto L_004E;\nL_004B:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v174, v223);\n\tv125 = v457;\nL_004C:\n\tv151 = v151 + 1;\n\tv117 = *([v318 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv117 = v117 + 0x10;\n\tv344 = v359 - 1;\n\tv326 = v359 != 1;\n\tv359 = v344;\n\tif (v326) goto L_0059;\nL_0072:\n\tv142 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(entities);\n\tv80 = v151 < v142;\n\tif (v80) goto L_0097;\n\tgoto L_010C;\nL_0081:\n\tv77 = *([v117 @ X10_v18]) << 4;\n\tv373 = v318 + v77;\n\tv374 = v373 + 0x138;\n\t*([v374 @ X0_v27])(v143, entities, *([v374 @ X0_v27+8]), v125, Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv81 = v151 >= v143;\n\tif (v81) goto L_010C;\nL_0097:\n\tgoto L_00BE;\n\tv458 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v457);\n\tv459 = ~v458;\n\tv125 = 0;\n\tif (v459) goto L_004C;\n\tv476 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v457);\n\tv478 = ~v476;\n\tv125 = Il2CppMethodInfo;\n\tif (v478) goto L_004C;\n\tv477 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v457);\n\tv479 = ~v477;\n\tv125 = Il2CppMethodInfo;\n\tif (v479) goto L_004C;\n\tv174 = this._removedCoords;\n\tv223 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v457);\n\tgoto L_004B;\nL_010C:\n\treturn;\nL_002E:\n\tv57 = this._visualHandler == 0;\n\tif (v57) goto L_010C;\nL_004E:\n\tv318 = entities->klass;\n\tv359 = entities->klass->interface_offsets_count;\n\tv146 = *([v318 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v146) goto L_0072;\nL_0059:\n\tv364 = *([v117 @ X10_v18-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v364) goto L_0081;\nL_00BE:\n\tv457 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(entities, v151);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeforeRemove(IReadOnlyList<Entity> entities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeRemoveHook::OnBeforeRemove");
		}

		[Token(Token = "0x6000872")]
		[Address(RVA = "0x3E7DA90", Offset = "0x3E7DA90", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnBeforeDestroyEntity(Entity entity)
		{
		}

		[Token(Token = "0x6000873")]
		[Address(RVA = "0x3E7DA94", Offset = "0x3E7DA94", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv44 = *([v39 @ X1_v1 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+18]) == 0;\n\tif (v44) goto L_002F;\n\tv53 = this._mutations == 0;\n\tif (v53) goto L_0020;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeEditorMutations::HandleCubesRemoved(this._mutations, v39);\nL_0020:\n\tv64 = this._visualHandler == 0;\n\tif (v64) goto L_0023;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler::ResyncAll(this._visualHandler);\nL_0023:\n\tv50 = this._removedCoords;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Clear(v50);\nL_0015:\n\tv39 = this._removedCoords;\nL_002F:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterRemove()
		{
			IReadOnlyList<GridCoord> removedCoords = _removedCoords;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X1_v1 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+18]");
			if ((nint)0 != 0)
			{
				if (_mutations != null)
				{
					_mutations.HandleCubesRemoved(removedCoords);
				}
				if (_visualHandler != null)
				{
					_visualHandler.ResyncAll();
				}
				List<GridCoord> removedCoords2 = _removedCoords;
				removedCoords2.Clear();
			}
		}

		[Token(Token = "0x6000874")]
		[Address(RVA = "0x3E7AC54", Offset = "0x3E7AC54", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v48);\n\tthis._removedCoords = v48;\n")]
		public LinkedCubeRemoveHook()
		{
			List<GridCoord> removedCoords = new List<GridCoord>();
			_removedCoords = removedCoords;
		}
	}
}

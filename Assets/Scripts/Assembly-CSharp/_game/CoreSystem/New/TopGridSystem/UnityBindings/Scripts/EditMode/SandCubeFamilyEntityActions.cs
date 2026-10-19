using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x200013F")]
	public abstract class SandCubeFamilyEntityActions : EntityActionsBase
	{
		[Token(Token = "0x600065C")]
		[Address(RVA = "0x3DB52C0", Offset = "0x3DB52C0", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_002C;\nL_002C:\n\tv80 = UnityEngine.Object::FindObjectOfType();\n\tv105 = UnityEngine.Object::op_Equality(v80, 0);\n\tv107 = v105 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0052;\n\tv110 = v80.Mutations == 0;\n\tif (v110) goto L_0052;\n\t// 62 NewArr v115 @ X0_v16 (_game.BaseLayerSystems.EntitySystem.Core.Entity[]), typeof(_game.BaseLayerSystems.EntitySystem.Core.Entity[]), 1\n\t*([v115 @ X0_v16 (_game.BaseLayerSystems.EntitySystem.Core.Entity[])+20]) = v43;\n\t_game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations::RemoveEntities(v80.Mutations, v115);\nL_004F:\n\treturn;\nL_0052:\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::DoRemove(this);\n\treturn;\nL_0018:\n\tv39 = 0;\n\tv46 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v39 @ stack_-30_v1 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v43 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv50 = ~v46;\n\tif (v50) goto L_004F;\n")]
		protected internal override void DoRemove()
		{
			EntityManager em = null;
			if (TryResolve(out em, out var _))
			{
				TopGridReconcileTick_Editor topGridReconcileTick_Editor = Object.FindObjectOfType<TopGridReconcileTick_Editor>();
				if (!(topGridReconcileTick_Editor == null) && topGridReconcileTick_Editor.Mutations != null)
				{
					Entity[] entities = new Entity[1];
					topGridReconcileTick_Editor.Mutations.RemoveEntities(entities);
				}
				else
				{
					base.DoRemove();
				}
			}
		}

		[Token(Token = "0x600065D")]
		[Address(RVA = "0x3DB444C", Offset = "0x3DB444C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::.ctor(this);\n\treturn;\n")]
		protected internal SandCubeFamilyEntityActions()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;

namespace _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode
{
	[Token(Token = "0x200013A")]
	public class LockEntityActions : SandCubeFamilyEntityActions
	{
		[Token(Token = "0x6000641")]
		[Address(RVA = "0x3DB4014", Offset = "0x3DB4014", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::BindCore(this, entity, history);\n\treturn;\n")]
		public void Bind(Entity entity, EditorHistory history)
		{
			BindCore(entity, history);
		}

		[Token(Token = "0x6000642")]
		[Address(RVA = "0x3DB401C", Offset = "0x3DB401C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv55.color = color;\n\tv79 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.LockEntityActions>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.LockEntityActions>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv91 = v55.color;\n\t// 71 Box v94 @ X0_v8 (System.Object), typeof(_game.CoreSystem.GameColor), &v91 @ stack_-54_v1 (_game.CoreSystem.GameColor)\n\tv129 = System.String::Format(\"ChangeLockColor({0})\", v94);\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::ForEachSelected(this, v79, v129);\n\treturn;\nL_002B:\n\tv55 = new _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.LockEntityActions+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v55);\n")]
		public void ChangeColor(GameColor color)
		{
			Action<LockEntityActions> action = delegate(LockEntityActions a)
			{
				a.DoChangeColor(color);
			};
			GameColor gameColor = color;
			object arg = gameColor;
			string label = $"ChangeLockColor({arg})";
			ForEachSelected(action, label);
		}

		[Token(Token = "0x6000643")]
		[Address(RVA = "0x3DB4164", Offset = "0x3DB4164", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv176 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v61, v63);\n\tv184 = ~v176;\n\tif (v184) goto L_0120;\n\tv283 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v61, v63);\n\tv255 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v61);\n\tv313 = 0;\n\tv157 = 0;\n\tv165 = Il2CppMethodInfo;\n\tgoto L_0068;\nL_0065:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v61, v459, 0);\n\tv313 = Il2CppMethodInfo;\n\tv165 = 0;\nL_0066:\n\tv157 = v157 + 1;\n\tv142 = *([v325 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv142 = v142 + 0x10;\n\tv331 = v353 - 1;\n\tv330 = v353 != 1;\n\tv353 = v331;\n\tif (v330) goto L_006E;\nL_008A:\n\t;\n\tv177 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v255);\n\tv91 = v157 < v177;\n\tif (v91) goto L_00B1;\n\tgoto L_0120;\nL_009A:\n\t;\n\tv87 = *([v142 @ X10_v14]) << 4;\n\tv375 = v325 + v87;\n\tv376 = v375 + 0x138;\n\t*([v376 @ X0_v35])(v178, v255, *([v376 @ X0_v35+8]), v165, v313, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv92 = v157 >= v178;\n\tif (v92) goto L_0120;\nL_00B1:\n\tgoto L_00D8;\n\tv460 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v61, v459);\n\tv461 = ~v460;\n\tv165 = 0;\n\tif (v461) goto L_0066;\n\tv465 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v61, v459);\n\tv468 = ~v465;\n\tv165 = Il2CppMethodInfo;\n\tif (v468) goto L_0066;\n\tv466 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v61, v459);\n\tv215 = v466 != v283;\n\tv165 = Il2CppMethodInfo;\n\tif (v215) goto L_0066;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(v61, v459, color);\n\tv467 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v61, v459);\n\tv474 = v467 == 0;\n\tv469 = ~v474;\n\tv313 = Il2CppMethodInfo;\n\tv165 = Il2CppMethodInfo;\n\tif (v469) goto L_0066;\n\tv475 = v61 == 0;\n\tv261 = ~v475;\n\tif (v261) goto L_0065;\n\tthrow System.NullReferenceException;\nL_0120:\n\treturn;\nL_0037:\n\tv65 = _game.CoreSystem.New.Shared.EditMode.EntityActionsBase::TryResolve(this, &v61 @ stack_-68_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager), &v63 @ stack_-70_v2 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv69 = ~v65;\n\tif (v69) goto L_0120;\nL_0068:\n\tv325 = *([v255 @ X0_v11 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv353 = *([v325 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv185 = *([v325 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v185) goto L_008A;\nL_006E:\n\t;\n\tv366 = *([v142 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v366) goto L_009A;\nL_00D8:\n\tv459 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v255, v157);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoChangeColor(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockEntityActions::DoChangeColor");
		}

		[Token(Token = "0x6000644")]
		[Address(RVA = "0x3DB4444", Offset = "0x3DB4444", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.Shared.EditMode.EntityActionsBase::.ctor(this);\n\treturn;\n")]
		public LockEntityActions()
		{
		}
	}
}

using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Responds;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x200026D")]
	public class TopGridReconcile_RevealSystem : ITopGridEcsSystem, IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x4000782")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x6000A9C")]
		[Address(RVA = "0x3EB7D54", Offset = "0x3EB7D54", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteRevealDoneCleanup(this);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteCmdRevealIssue(this);\n\treturn;\n")]
		public void Execute()
		{
			ExecuteRevealDoneCleanup();
			ExecuteCmdRevealIssue();
		}

		[Token(Token = "0x6000A9D")]
		[Address(RVA = "0x3EB7D78", Offset = "0x3EB7D78", Length = "0x2B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\nL_003B:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv129 = 0;\n\tgoto L_004F;\nL_004D:\n\tv129 = v129 + 1;\n\tv313 = *([v265 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv313 = v313 + 0x10;\n\tv277 = v304 - 1;\n\tv275 = v304 != 1;\n\tv304 = v277;\n\tif (v275) goto L_005A;\nL_0073:\n\tv326 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv337 = v129 < v326;\n\tif (v337) goto L_009A;\n\tgoto L_0109;\nL_0082:\n\tv343 = *([v313 @ X10_v14]) << 4;\n\tv344 = v265 + v343;\n\tv345 = v344 + 0x138;\n\t*([v345 @ X0_v30])(v349, v63, *([v345 @ X0_v30+8]), v242, v240, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv359 = v129 >= v349;\n\tif (v359) goto L_0109;\nL_009A:\n\tgoto L_00C1;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v447);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v447);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v447);\n\tv448 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v447);\n\tv450 = v448 == 0;\n\tv451 = ~v450;\n\tif (v451) goto L_00ED;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v447, 0);\n\tv240 = Il2CppMethodInfo;\nL_00ED:\n\tv459 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v447);\n\tv461 = v459 == 0;\n\tv462 = ~v461;\n\tv242 = Il2CppMethodInfo;\n\tif (v462) goto L_004D;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v447, 0);\n\tv240 = Il2CppMethodInfo;\n\tv242 = 0;\n\tgoto L_004D;\nL_0109:\n\treturn;\nL_004F:\n\tv265 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv304 = *([v265 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv226 = *([v265 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v226) goto L_0073;\nL_005A:\n\tv318 = *([v313 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v318) goto L_0082;\nL_00C1:\n\tv447 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v129);\n")]
		public void ExecuteRevealDoneCleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcile_RevealSystem::ExecuteRevealDoneCleanup");
		}

		[Token(Token = "0x6000A9E")]
		[Address(RVA = "0x3EB802C", Offset = "0x3EB802C", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv145 = *([v59 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv251 = *([v145 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv147 = *([v145 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v147) goto L_0058;\n\tv250 = *([v145 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv250 = v250 + 0x10;\n\tv234 = v251 - 1;\n\tv214 = v251 != 1;\n\tv251 = v234;\n\tif (v214) goto L_003F;\nL_0058:\n\tv264 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v59);\n\tv79 = v264 - 1;\n\tv275 = v264 >= 1;\n\tif (v275) goto L_0081;\n\tgoto L_00E2;\nL_0067:\n\tv278 = *([v250 @ X10_v14]) << 4;\n\tv279 = v145 + v278;\n\tv280 = v279 + 0x138;\n\t*([v280 @ X0_v25])(v284, v59, *([v280 @ X0_v25+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv288 = v284 < 1;\n\tv79 = v284 - 1;\n\tif (v288) goto L_00E2;\nL_0081:\n\tgoto L_0095;\nL_0082:\n\tv338 = v79 - 1;\n\tv326 = v79 <= 0;\n\tv79 = v338;\n\tif (v326) goto L_00E2;\nL_0095:\n\tgoto L_00BC;\n\tv422 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v421);\n\tv424 = v422 == 0;\n\tv425 = ~v424;\n\tif (v425) goto L_0082;\n\tv433 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v421);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v421, v433);\n\tgoto L_0082;\nL_00E2:\n\treturn;\nL_003F:\n\tv256 = *([v250 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v256) goto L_0067;\nL_00BC:\n\tv421 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v59, v79);\n")]
		public void ExecuteCmdRevealIssue()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcile_RevealSystem::ExecuteCmdRevealIssue");
		}

		[Token(Token = "0x6000A9F")]
		[Address(RVA = "0x3EB823C", Offset = "0x3EB823C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TopGridReconcile_RevealSystem()
		{
		}
	}
}

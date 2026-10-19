using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x200025B")]
	public class SandReconcile_PourableEvaluatorSystem
	{
		[Inject(false)]
		[Token(Token = "0x4000737")]
		[FieldOffset(Offset = "0x10")]
		internal EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000738")]
		[FieldOffset(Offset = "0x18")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x4000739")]
		[FieldOffset(Offset = "0x20")]
		private LockGroupHandler _lockGroups;

		[Token(Token = "0x400073A")]
		[FieldOffset(Offset = "0x28")]
		private IReadOnlyList<IPourableBlockCondition> _conditions;

		[Inject(false)]
		[Token(Token = "0x6000A49")]
		[Address(RVA = "0x3EAD7D4", Offset = "0x3EAD7D4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = System.Linq.Enumerable::ToList(conditions);\n\tthis._conditions = v47;\n\treturn;\n")]
		public void Construct(IEnumerable<IPourableBlockCondition> conditions)
		{
			List<object> conditions2 = ((IEnumerable<object>)conditions).ToList();
			_conditions = (IReadOnlyList<IPourableBlockCondition>)conditions2;
		}

		[Token(Token = "0x6000A4A")]
		[Address(RVA = "0x3EAD83C", Offset = "0x3EAD83C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv43 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_PourableEvaluatorSystem::CheckBlocking(this, v43);\n\treturn;\n")]
		public void Execute()
		{
			IReadOnlyList<Entity> entities = _em.Query<SandRevealTag, SandCubeTag>();
			CheckBlocking(entities);
		}

		[Token(Token = "0x6000A4B")]
		[Address(RVA = "0x3EAD89C", Offset = "0x3EAD89C", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv63 = entities->klass;\n\tv275 = entities->klass->interface_offsets_count;\n\tv65 = *([v63 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v65) goto L_0050;\n\tv274 = *([v63 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv274 = v274 + 0x10;\n\tv257 = v275 - 1;\n\tv237 = v275 != 1;\nL_FFFFFFFF:\n\tv275 = v257;\n\tif (v237) goto L_0037;\nL_0050:\n\tv288 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(entities);\n\tv112 = v288 - 1;\n\tv299 = v288 >= 1;\n\tif (v299) goto L_FFFFFFFF;\n\tgoto L_01DB;\nL_005F:\n\tv370 = *([v274 @ X10_v47]) << 4;\n\tv371 = v63 + v370;\n\tv372 = v371 + 0x138;\n\t*([v372 @ X0_v51])(v376, entities, *([v372 @ X0_v51+8]), methodInfo, v88, v69, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv380 = v376 < 1;\n\tv112 = v376 - 1;\n\tif (v380) goto L_01DB;\nL_FFFFFFFF:\n\tv461 = entities;\n\tgoto L_008F;\nL_0079:\n\tv439 = v112 - 1;\n\tv425 = v112 <= 0;\nL_FFFFFFFF:\n\tv112 = v439;\nL_FFFFFFFF:\n\tv461 = entities;\n\tif (v425) goto L_01DB;\nL_008F:\n\tgoto L_00B6;\n\tv205 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v527);\n\tv528 = ~v205;\n\tif (v528) goto L_0079;\n\tv531 = this._conditions;\nL_FFFFFFFF:\n\tv92 = 0;\nL_FFFFFFFF:\n\tv535 = 0;\n\tgoto L_00D3;\nL_FFFFFFFF:\n\tv873 = 4;\nL_00CD:\n\t*([v926 @ X0_v23])(v206, v885, this._em, v527, *([v926 @ X0_v23+8]), 0, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv92 = v92 + 1;\n\tv531 = this._conditions;\nL_FFFFFFFF:\n\tv535 = v527;\nL_00D3:\n\tv596 = *([v531 @ X24_v6 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)]);\n\tv632 = *([v596 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]);\n\tv571 = *([v596 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]) == 0;\n\tif (v571) goto L_00F7;\n\tv564 = *([v596 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+B0]) + 8;\n\tv564 = v564 + 0x10;\n\tv619 = v632 - 1;\n\tv601 = v632 != 1;\nL_FFFFFFFF:\n\tv632 = v619;\n\tif (v601) goto L_00DE;\nL_00F7:\n\tv569 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>::get_Count(v531);\n\tv537 = v92 < v569;\n\tif (v537) goto L_0118;\n\tgoto L_0079;\nL_0106:\n\tv533 = *([v564 @ X10_v36]) << 4;\n\tv646 = v596 + v533;\n\tv647 = v646 + 0x138;\n\t*([v647 @ X0_v40])(v570, v531, *([v647 @ X0_v40+8]), v535, *([v926 @ X0_v23+8]), 0, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv538 = v92 >= v570;\n\tif (v538) goto L_0079;\nL_0118:\n\tv96 = this._conditions;\n\tv651 = *([v96 @ X24_v7 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)]);\n\tv679 = *([v651 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]);\n\tv653 = *([v651 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]) == 0;\n\tif (v653) goto L_0141;\n\tv188 = *([v651 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+B0]) + 8;\n\tv188 = v188 + 0x10;\n\tv666 = v679 - 1;\n\tv656 = v679 != 1;\nL_FFFFFFFF:\n\tv679 = v666;\n\tif (v656) goto L_0127;\nL_0141:\n\tv885 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>::get_Item(v96, v92);\n\tv682 = v885 == 0;\n\tv215 = ~v682;\n\tif (v215) goto L_0158;\n\tgoto L_01DC;\nL_0147:\n\tv109 = *([v188 @ X10_v31]) << 4;\n\tv684 = v651 + v109;\n\tv685 = v684 + 0x138;\n\t*([v685 @ X0_v33])(v885, v96, v92, *([v685 @ X0_v33+8]), *([v926 @ X0_v23+8]), 0, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0158:\n\tgoto L_0182;\n\tv793 = *([v790 @ X8_v23 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)+12E]) == 0;\n\tif (v793) goto L_FFFFFFFF;\n\tv861 = *([v790 @ X8_v23 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)+B0]) + 8;\n\tv861 = v861 + 0x10;\n\tv820 = v899 - 1;\n\tv800 = v899 != 1;\nL_FFFFFFFF:\n\tv899 = v820;\n\tif (v800) goto L_0192;\nL_FFFFFFFF:\n\tv873 = 3;\n\tgoto L_00C7;\nL_01A8:\n\tv794 = *([v790 @ X8_v23 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)+12E]) == 0;\n\tif (v794) goto L_FFFFFFFF;\n\tv898 = *([v790 @ X8_v23 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)+B0]) + 8;\n\tv898 = v898 + 0x10;\n\tv848 = v899 - 1;\n\tv828 = v899 != 1;\nL_FFFFFFFF:\n\tv899 = v848;\n\tif (v828) goto L_01B1;\n\tgoto L_FFFFFFFF;\nL_01C6:\n\tv925 = *([v861 @ X10_v20]) + 3;\n\tgoto L_01CA;\nL_01C9:\n\tv925 = *([v898 @ X10_v14]) + 4;\nL_01DB:\n\treturn;\nL_01DC:\n\tthrow System.NullReferenceException;\nL_0037:\n\tv280 = *([v274 @ X10_v47-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v280) goto L_005F;\nL_00B6:\n\tv527 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v461, v112);\nL_00DE:\n\tv637 = *([v564 @ X10_v36-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>;\n\tif (v637) goto L_0106;\nL_0127:\n\tv160 = *([v188 @ X10_v31-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>;\n\tif (v160) goto L_0147;\nL_0182:\n\tv788 = _game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition::IsBlocking(v885, v527, this._em, this._gridHandler);\n\tv790 = *([v885 @ X0_v19 (_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition)]);\n\tv899 = *([v790 @ X8_v23 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)+12E]);\n\tv792 = ~v788;\n\tif (v792) goto L_01A8;\nL_0192:\n\tv867 = *([v861 @ X10_v20-8]) == _game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition;\n\tif (v867) goto L_01C6;\nL_00C7:\n\tv926 = 0x220C5E0(v885, _game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition, v873, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_01B1:\n\tv904 = *([v898 @ X10_v14-8]) == _game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition;\n\tif (v904) goto L_01C9;\nL_01CA:\n\tv913 = v925 << 4;\n\tv931 = v790 + v913;\n\tv926 = v931 + 0x138;\n\tgoto L_00CD;\n")]
		internal void CheckBlocking(IReadOnlyList<Entity> entities)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandReconcile_PourableEvaluatorSystem::CheckBlocking");
		}

		[Token(Token = "0x6000A4C")]
		[Address(RVA = "0x3EADC94", Offset = "0x3EADC94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandReconcile_PourableEvaluatorSystem()
		{
		}
	}
}

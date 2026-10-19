using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.Shared.Components.Commands;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x200026B")]
	public class TopGridReconcile_CoverSystem : ITopGridEcsSystem, IEcsSystem
	{
		[Inject(false)]
		[Token(Token = "0x400077A")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x400077B")]
		[FieldOffset(Offset = "0x18")]
		private IReadOnlyList<IPourableBlockCondition> _conditions;

		[Inject(false)]
		[Token(Token = "0x6000A8C")]
		[Address(RVA = "0x3EB57C0", Offset = "0x3EB57C0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = System.Linq.Enumerable::ToList(conditions);\n\tthis._conditions = v47;\n\treturn;\n")]
		public void Construct(IEnumerable<IPourableBlockCondition> conditions)
		{
			List<object> conditions2 = ((IEnumerable<object>)conditions).ToList();
			_conditions = (IReadOnlyList<IPourableBlockCondition>)conditions2;
		}

		[Token(Token = "0x6000A8D")]
		[Address(RVA = "0x3EB5828", Offset = "0x3EB5828", Length = "0x7D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004A;\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv219 = *([v64 @ X0_v23 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv278 = *([v219 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv221 = *([v219 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v221) goto L_007C;\n\tv277 = *([v219 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv277 = v277 + 0x10;\n\tv250 = v278 - 1;\n\tv230 = v278 != 1;\nL_FFFFFFFF:\n\tv278 = v250;\n\tif (v230) goto L_0062;\nL_007C:\n\tv337 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v64);\n\tv297 = v337 == 0;\n\tv298 = ~v297;\nL_FFFFFFFF:\n\tv321 = v337;\nL_FFFFFFFF:\n\tv493 = &v321 @ stack_-68_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv323 = 0;\n\tif (v298) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv323 = 0;\n\tgoto L_02B0;\nL_0086:\n\tv308 = *([v277 @ X10_v66]) << 4;\n\tv309 = v219 + v308;\n\tv310 = v309 + 0x138;\n\t*([v310 @ X8_v80])(v337, v64, *([v310 @ X8_v80+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv318 = v337 == 0;\nL_FFFFFFFF:\n\tv321 = v337;\nL_FFFFFFFF:\n\tv493 = &v321 @ stack_-68_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv323 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv323 = 0;\n\tif (v318) goto L_02B0;\nL_FFFFFFFF:\n\tv437 = v337;\n\tgoto L_00A5;\nL_009F:\n\tv409 = v321 == 0;\nL_FFFFFFFF:\n\tv437 = v321;\n\tif (v409) goto L_02B0;\nL_00A5:\n\tgoto L_00CB;\n\tv663 = v321 == 0;\n\tif (v663) goto L_02B2;\n\tgoto L_00FC;\n\tv926 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v922);\n\tv928 = v926 == 0;\n\tif (v928) goto L_009F;\n\tv665 = this._em == 0;\n\tif (v665) goto L_02B6;\n\tv948 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v922);\n\tv1011 = this._conditions;\n\tv950 = this._conditions == 0;\n\tif (v950) goto L_02AA;\n\tv952 = v948 == 0;\n\tif (v952) goto L_FFFFFFFF;\n\tgoto L_0212;\nL_FFFFFFFF:\n\tv555 = 0;\n\tgoto L_0142;\nL_013A:\n\tv555 = v555 + 1;\n\tv974 = this._conditions == 0;\nL_FFFFFFFF:\n\tv1011 = this._conditions;\n\tif (v974) goto L_02AA;\nL_0142:\n\tgoto L_0168;\n\tv661 = this._conditions == 0;\n\tif (v661) goto L_02AC;\n\tgoto L_01A5;\n\tgoto L_01D4;\n\tgoto L_0206;\n\tgoto L_FFFFFFFF;\n\tv1198 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v922);\n\tv667 = this._em == 0;\n\tif (v667) goto L_02BA;\n\tv936 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v922);\n\tv1256 = v557 == 0;\n\tif (v1256) goto L_0249;\n\tv1267 = ~v936;\n\tv681 = v1198 | v1267;\n\tv940 = v681 == 0;\n\tif (v940) goto L_009F;\n\tv668 = this._em == 0;\n\tif (v668) goto L_02BC;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v922);\n\tv669 = this._em == 0;\n\tif (v669) goto L_02BE;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v922, 0);\n\tv672 = this._em == 0;\n\tif (v672) goto L_02C4;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v922, 0);\n\tgoto L_009F;\nL_0249:\n\tv1270 = v1198 == 0;\n\tv941 = ~v1270;\n\tif (v941) goto L_009F;\n\tv670 = this._em == 0;\n\tif (v670) goto L_02C0;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v922);\n\tv671 = this._em == 0;\n\tif (v671) goto L_02C2;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v922, 0);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v922, 0);\n\tgoto L_009F;\nL_0268:\n\tv526 = &v321 @ stack_-68_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv527 = *([v526 @ X8_v26]);\n\tv524 = *([v526 @ X8_v26]) == 0;\nL_FFFFFFFF:\n\tv529 = 0;\nL_FFFFFFFF:\n\tv172 = v493;\nL_FFFFFFFF:\n\tv199 = 0;\nL_FFFFFFFF:\n\tv210 = 0;\n\tif (v524) goto L_0299;\nL_0272:\n\tgoto L_0298;\n\treturn;\nL_02AA:\n\tv646 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02AC:\n\tv647 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02AE:\n\tv648 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv199 = 0;\n\tgoto L_02C7;\nL_02B0:\n\tv414 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02B2:\n\tv649 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02B4:\n\tv650 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv199 = 0;\n\tgoto L_02C7;\nL_02B6:\n\tv651 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv199 = 0;\n\tgoto L_02C7;\nL_02B8:\n\tv652 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02BA:\n\tv653 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02BC:\n\tv654 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02BE:\n\tv655 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02C0:\n\tv656 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02C2:\n\tv657 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02C4:\n\tv658 = new System.NullReferenceException();\n\tgoto L_02C7;\nL_02C7:\n\t// 711 Interrupt\nL_02CA:\n\tv212 = new System.OutOfMemoryException();\n\tgoto L_02F3;\nL_02F3:\n\tv263 = v199 != 1;\n\tif (v263) goto L_0301;\n\tv299 = 0x8BF5BC4(v212, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv529 = *([v299 @ X0_v14]);\n\tv354 = 0x8BF5BF4(v299, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv527 = *([v172 @ stack_-70_v1]);\n\tv444 = *([v172 @ stack_-70_v1]) == 0;\n\tv445 = ~v444;\nL_FFFFFFFF:\n\tv323 = *([v299 @ X0_v14]);\n\tif (v445) goto L_0272;\nL_FFFFFFFF:\n\tv172 = v172;\nL_FFFFFFFF:\n\tv323 = *([v299 @ X0_v14]);\nL_FFFFFFFF:\n\tv210 = *([v299 @ X0_v14]);\n\tgoto L_0299;\nL_0301:\n\tv302 = 0x3175484(&v323 @ stack_-78_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv356 = 0x8BF0368(v212, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv446 = 0xA1B8(v356, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_004A:\n\tv321 = 0;\n\tthrow System.NullReferenceException;\nL_0062:\n\tv283 = *([v277 @ X10_v66-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v283) goto L_0086;\nL_00CB:\n\tv522 = System.Collections.IEnumerator::MoveNext(v437);\n\tv815 = v522 == 0;\n\tif (v815) goto L_0268;\nL_00FC:\n\tv922 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v321);\n\tv664 = this._em == 0;\n\tif (v664) goto L_02B4;\nL_0212:\n\tv1107 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>::get_Count(this._conditions);\nL_FFFFFFFF:\n\t;\nL_0168:\n\tv1189 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>::get_Count(v1011);\n\tv615 = v555 - v1189;\n\tv610 = v615 < 0;\n\tv600 = v555 ^ v1189;\n\tv595 = v555 ^ v615;\n\tv590 = v600 & v595;\n\tv585 = v590 < 0;\n\tv1191 = v610 == v585;\n\tv1192 = ~v1191;\n\tv580 = v555 >= v1189;\nL_FFFFFFFF:\n\tv557 = v1192;\nL_FFFFFFFF:\n\t;\n\tif (v580) goto L_0215;\nL_01A5:\n\tv1266 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>::get_Item(this._conditions, v555);\n\tv662 = v1266 == 0;\n\tif (v662)\n// ... truncated")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcile_CoverSystem::Execute");
		}

		[Token(Token = "0x6000A8E")]
		[Address(RVA = "0x3EB5FFC", Offset = "0x3EB5FFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TopGridReconcile_CoverSystem()
		{
		}
	}
}

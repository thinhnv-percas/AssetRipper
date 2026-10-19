using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation
{
	[Token(Token = "0x2000269")]
	public class TopGridReconcile_BlockerCheckSystem
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200026A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000778")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000779")]
			public static Func<IPourableBlockCondition, int> _003C_003E9__3_0;

			[Token(Token = "0x6000A89")]
			[Address(RVA = "0x3EB56A4", Offset = "0x3EB56A4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_BlockerCheckSystem+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000A8A")]
			[Address(RVA = "0x3EB5708", Offset = "0x3EB5708", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal int _003CConstruct_003Eb__3_0(IPourableBlockCondition c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcile_BlockerCheckSystem._003C_003Ec::_003CConstruct_003Eb__3_0");
				return default;
			}
		}

		[Token(Token = "0x4000775")]
		private const int RejectCooldownFrames = 15;

		[Inject(false)]
		[Token(Token = "0x4000776")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x4000777")]
		[FieldOffset(Offset = "0x18")]
		private IReadOnlyList<IPourableBlockCondition> _conditions;

		[Inject(false)]
		[Token(Token = "0x6000A86")]
		[Address(RVA = "0x3EB4FCC", Offset = "0x3EB4FCC", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tgoto L_0042;\nL_0053:\n\tv98 = System.Linq.Enumerable::OrderByDescending(conditions, v93);\n\tv111 = System.Linq.Enumerable::ToList(v98);\n\tthis._conditions = v111;\n\treturn;\nL_002B:\n\tgoto L_0034;\nL_0042:\n\tv109 = new System.Func`2<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition, System.Int32>();\n\tSystem.Func`2<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition, System.Int32>::.ctor(v109, v104.<>9, Il2CppMethodInfo);\n\tv119.<>9__3_0 = v109;\n\tv93 = v109;\nL_0034:\n\tv70 = v68.<>9__3_0 == 0;\n\tv71 = ~v70;\n\tv93 = v68.<>9__3_0;\n\tif (v71) goto L_0053;\n")]
		public void Construct(IEnumerable<IPourableBlockCondition> conditions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcile_BlockerCheckSystem::Construct");
		}

		[Token(Token = "0x6000A87")]
		[Address(RVA = "0x3EB5110", Offset = "0x3EB5110", Length = "0x58C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\nL_0047:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv338 = *([v63 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv449 = *([v338 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv340 = *([v338 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v340) goto L_0072;\n\tv448 = *([v338 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv448 = v448 + 0x10;\n\tv431 = v449 - 1;\n\tv411 = v449 != 1;\n\tv449 = v431;\n\tif (v411) goto L_0059;\nL_0072:\n\tv462 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v63);\n\tv116 = v462 - 1;\n\tv473 = v462 >= 1;\n\tif (v473) goto L_0099;\n\tgoto L_024F;\nL_0081:\n\tv479 = *([v448 @ X10_v42]) << 4;\n\tv480 = v338 + v479;\n\tv481 = v480 + 0x138;\n\t*([v481 @ X0_v74])(v485, v63, *([v481 @ X0_v74+8]), v37, v79, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv489 = v485 < 1;\n\tv116 = v485 - 1;\n\tif (v489) goto L_024F;\nL_0099:\n\tgoto L_00B6;\nL_00A0:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(v700, v644);\nL_00A1:\n\tv550 = v116 - 1;\n\tv536 = v116 <= 0;\n\tv116 = v550;\n\tif (v536) goto L_024F;\nL_00B6:\n\tgoto L_00DD;\n\tv648 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v644);\n\tv652 = ~v648;\n\tif (v652) goto L_00A1;\n\tv717 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v644);\n\tv700 = this._em;\n\tv719 = v717 == 0;\n\tif (v719) goto L_00A0;\n\tv276 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v644);\n\tv726 = v276 == 0;\n\tif (v726) goto L_0103;\n\tv700 = this._em;\n\tv727 = this._em == 0;\n\tv295 = ~v727;\n\tif (v295) goto L_00A0;\n\tgoto L_0250;\nL_0103:\n\tv658 = this._conditions;\n\tv90 = 0;\n\tv663 = Il2CppMethodInfo;\n\tv693 = *([v746 @ X8_v23 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+B0]) + 8;\n\tv693 = v693 + 0x10;\n\tv769 = v782 - 1;\n\tv751 = v782 != 1;\n\tv782 = v769;\n\tif (v751) goto L_0113;\nL_012C:\n\tv701 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>::get_Count(v658);\n\tv666 = v90 < v701;\n\tif (v666) goto L_014D;\n\tgoto L_00A1;\nL_013B:\n\tv660 = *([v693 @ X10_v31]) << 4;\n\tv796 = v746 + v660;\n\tv797 = v796 + 0x138;\n\t*([v797 @ X0_v61])(v702, v658, *([v797 @ X0_v61+8]), v663, v79, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv667 = v90 >= v702;\n\tif (v667) goto L_00A1;\nL_014D:\n\tv97 = this._conditions;\n\tv801 = *([v97 @ X24_v7 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)]);\n\tv829 = *([v801 @ X8_v25 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]);\n\tv803 = *([v801 @ X8_v25 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]) == 0;\n\tif (v803) goto L_0176;\n\tv238 = *([v801 @ X8_v25 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+B0]) + 8;\n\tv238 = v238 + 0x10;\n\tv816 = v829 - 1;\n\tv806 = v829 != 1;\n\tv829 = v816;\n\tif (v806) goto L_015C;\nL_0176:\n\tv852 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>::get_Item(v97, v90);\n\tv832 = v852 == 0;\n\tv298 = ~v832;\n\tif (v298) goto L_0189;\n\tgoto L_0250;\nL_017C:\n\tv110 = *([v238 @ X10_v26]) << 4;\n\tv834 = v801 + v110;\n\tv835 = v834 + 0x138;\n\t*([v835 @ X0_v54])(v852, v97, v90, *([v835 @ X0_v54+8]), v79, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0189:\n\tv856 = *([v852 @ X0_v20]);\n\tv899 = *([v856 @ X8_v27+12E]);\n\tv858 = *([v856 @ X8_v27+12E]) == 0;\n\tif (v858) goto L_01AB;\n\tv898 = *([v856 @ X8_v27+B0]) + 8;\n\tv898 = v898 + 0x10;\n\tv884 = v899 - 1;\n\tv864 = v899 != 1;\n\tv899 = v884;\n\tif (v864) goto L_0194;\nL_01AB:\n\tv79 = *([v887 @ X0_v44+8]);\n\tv914 = _game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition::HasBlockTag(v852, this._em, v644);\n\tv915 = v914 == 0;\n\tv124 = v644;\n\tif (v915) goto L_01C1;\n\tv83 = *([v887 @ X0_v44+8]);\n\tgoto L_01CE;\nL_01B4:\n\tv918 = *([v898 @ X10_v21]) + 2;\n\tv919 = v918 << 4;\n\tv920 = v856 + v919;\n\tv921 = v920 + 0x138;\n\tv79 = *([v921 @ X0_v47+8]);\n\t*([v921 @ X0_v47])(v927, v852, this._em, v644, *([v921 @ X0_v47+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv928 = v927 == 0;\n\tv929 = ~v928;\n\tv124 = v644;\n\tv83 = *([v921 @ X0_v47+8]);\n\tif (v929) goto L_01CE;\nL_01C1:\n\tv90 = v90 + 1;\n\tv658 = this._conditions;\n\tv931 = this._conditions == 0;\n\tv300 = ~v931;\n\tv663 = v124;\n\tif (v300) goto L_0108;\n\tgoto L_0250;\nL_01CE:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, v644);\n\tv938 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v644);\n\tv940 = v938 == 0;\n\tv941 = ~v940;\n\tif (v941) goto L_021E;\n\tv943 = *([v852 @ X0_v20]);\n\tv993 = *([v943 @ X8_v43+12E]);\n\tv945 = *([v943 @ X8_v43+12E]) == 0;\n\tif (v945) goto L_0201;\n\tv242 = *([v943 @ X8_v43+B0]) + 8;\n\tv242 = v242 + 0x10;\n\tv979 = v993 - 1;\n\tv969 = v993 != 1;\n\tv993 = v979;\n\tif (v969) goto L_01E8;\nL_0201:\n\tv1006 = _game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition::get_Reason(v852);\n\tv996 = this._em == 0;\n\tv303 = ~v996;\n\tif (v303) goto L_0216;\n\tgoto L_0250;\nL_0207:\n\tv113 = *([v242 @ X10_v15]) << 4;\n\tv1001 = v943 + v113;\n\tv1002 = v1001 + 0x138;\n\t*([v1002 @ X0_v39])(v1006, v852, *([v1002 @ X0_v39+8]), Il2CppMethodInfo, v83, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0216:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v644, v1006);\n\tv83 = Il2CppMethodInfo;\nL_021E:\n\tv983 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v644);\n\tv998 = v983 == 0;\n\tv999 = ~v998;\n\tif (v999) goto L_0233;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v644, 0);\n\tv83 = Il2CppMethodInfo;\nL_0233:\n\tv703 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v644);\n\tv1018 = v703 == 0;\n\tv706 = ~v1018;\n\tv79 = v83;\n\tif (v706) goto L_00A1;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v644, 0xF);\n\tv79 = Il2CppMethodInfo;\n\tgoto L_00A1;\nL_024F:\n\treturn;\nL_0250:\n\tthrow System.NullReferenceException;\nL_0059:\n\tv454 = *([v448 @ X10_v42-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v454) goto L_0081;\nL_00DD:\n\tv644 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v63, v116);\nL_0113:\n\tv787 = *([v693 @ X10_v31-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>;\n\tif (v787) goto L_013B;\nL_015C:\n\tv194 = *([v238 @ X10_v26-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>;\n\tif (v194) goto L_017C;\nL_0194:\n\tv904 = *([v898 @ X10_v21-8]) == _game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition;\n\tif (v904) goto L_01B4;\nL_0108:\n\tv746 = *([v658 @ X24_v6 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>)]);\n\tv782 = *([v746 @ X8_v23 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]);\n\tv705 = *([v746 @ X8_v23 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition>>)+12E]) == 0;\n\tif (v705) goto L_012C;\nL_01E8:\n\tv198 = *([v242 @ X10_v15-8]) == _\n// ... truncated")]
		public void Execute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcile_BlockerCheckSystem::Execute");
		}

		[Token(Token = "0x6000A88")]
		[Address(RVA = "0x3EB569C", Offset = "0x3EB569C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TopGridReconcile_BlockerCheckSystem()
		{
		}
	}
}

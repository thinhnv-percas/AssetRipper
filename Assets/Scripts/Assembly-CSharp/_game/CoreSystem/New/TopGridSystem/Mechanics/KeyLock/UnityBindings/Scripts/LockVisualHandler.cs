using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001EB")]
	public class LockVisualHandler : ITopGridVisualHandler
	{
		[Inject(false)]
		[Token(Token = "0x400062A")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400062B")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x400062C")]
		[FieldOffset(Offset = "0x20")]
		private KeyAndLockConfig _config;

		[Inject(false)]
		[Token(Token = "0x400062D")]
		[FieldOffset(Offset = "0x28")]
		private LockGroupHandler _lockGroups;

		[Token(Token = "0x400062E")]
		[FieldOffset(Offset = "0x30")]
		private Transform _parent;

		[Token(Token = "0x400062F")]
		[FieldOffset(Offset = "0x38")]
		private readonly Dictionary<GameColor, GameObject> _groupParentsByColor;

		[Token(Token = "0x4000630")]
		[FieldOffset(Offset = "0x40")]
		private readonly Dictionary<GameColor, GameObject> _lockMonosByColor;

		[Token(Token = "0x4000631")]
		[FieldOffset(Offset = "0x48")]
		private readonly Dictionary<GameColor, ChainController> _chainsByColor;

		[Token(Token = "0x4000632")]
		[FieldOffset(Offset = "0x50")]
		private readonly Dictionary<GameColor, Entity> _leaderByColor;

		[Token(Token = "0x4000633")]
		private const float SingleCellChainFactor = 0.9f;

		[Token(Token = "0x4000634")]
		private const float CornerDotEpsilon = 0.001f;

		[Token(Token = "0x4000635")]
		private static readonly (int dx, int dy)[] s_neighborDeltas;

		[Token(Token = "0x60008BE")]
		[Address(RVA = "0x3E856D0", Offset = "0x3E856D0", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tv81 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv163 = new System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>();\n\tSystem.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>::.ctor(v163);\n\tv169 = v81 == 0;\n\tv154 = Il2CppMethodInfo;\n\tif (v169) goto L_011D;\n\tv153 = 0;\n\tgoto L_0066;\nL_0064:\n\tv153 = v153 + 1;\n\tv313 = *([v260 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv313 = v313 + 0x10;\n\tv277 = v304 - 1;\n\tv275 = v304 != 1;\n\tv304 = v277;\n\tif (v275) goto L_0071;\nL_0088:\n\tv154 = *([v298 @ X0_v47+8]);\n\tv326 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v81);\n\tv337 = v153 < v326;\n\tif (v337) goto L_00AF;\n\tv96 = 0;\n\tgoto L_00EF;\nL_0099:\n\tv446 = *([v313 @ X10_v15]) << 4;\n\tv447 = v260 + v446;\n\tv448 = v447 + 0x138;\n\tv154 = *([v448 @ X0_v50+8]);\n\t*([v448 @ X0_v50])(v452, v81, *([v448 @ X0_v50+8]), v96, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv462 = v153 >= v452;\n\tif (v462) goto L_00EF;\nL_00AF:\n\tgoto L_00D6;\n\tv560 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v551);\n\tv562 = ~v560;\n\tv96 = Il2CppMethodInfo;\n\tif (v562) goto L_0064;\n\tv170 = this._em == 0;\n\tv154 = v551;\n\tif (v170) goto L_011D;\n\tv165 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v551);\n\tv171 = v163 == 0;\n\tv154 = v551;\n\tif (v171) goto L_011D;\n\tv566 = System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>::Add(v163, v165);\n\tv96 = Il2CppMethodInfo;\n\tgoto L_0064;\nL_00EF:\n\tv172 = v163 == 0;\n\tif (v172) goto L_011D;\n\tv520 = System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>::GetEnumerator(v163);\n\tv359 = v520._set;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::EnsureGroupVisualForColor(this, v520._current);\n\tgoto L_0102;\nL_010E:\n\tSystem.Collections.Generic.HashSet`1<System.Int32Enum>+Enumerator<System.Int32Enum>::Dispose(&v359 @ stack_-78_v3 (System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>));\nL_011C:\n\treturn;\nL_011D:\n\tv180 = new System.NullReferenceException();\n\tgoto L_0129;\nL_0129:\n\tv198 = v154 != 1;\n\tv215 = v180;\n\tif (v198) goto L_013B;\n\tv203 = 0x8BF5BC4(v180, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv229 = 0x8BF5BF4(v203, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.HashSet`1<System.Int32Enum>+Enumerator<System.Int32Enum>::Dispose(v264);\n\tv212 = *([v203 @ X0_v14]) == 0;\n\tif (v212) goto L_011C;\n\tv210 = new System.OutOfMemoryException();\n\tv206 = *([v203 @ X0_v14]);\n\tv215 = v210;\n\treturn;\nL_0042:\n\tthis._parent = v52;\n\tv70 = this._em == 0;\n\tv154 = v52;\n\tif (v70) goto L_011D;\nL_0066:\n\tv260 = *([v81 @ X0_v20 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv304 = *([v260 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv262 = *([v260 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v262) goto L_0088;\nL_0071:\n\tv318 = *([v313 @ X10_v15-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v318) goto L_0099;\nL_00D6:\n\tv551 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v81, v153);\n\tv173 = this._em == 0;\n\tv154 = v153;\n\tif (v173) goto L_011D;\nL_0102:\n\tv559 = System.Collections.Generic.HashSet`1<System.Int32Enum>+Enumerator<System.Int32Enum>::MoveNext(&v359 @ stack_-78_v3 (System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>));\n\tv386 = v559 == 0;\n\tif (v386) goto L_010E;\nL_013B:\n\tv218 = 0x318E96C(&v206 @ stack_-88, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv231 = 0x8BF0368(v215, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv266 = 0xA1B8(v231, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		public unsafe void InitVisuals(Transform visualParent)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::InitVisuals");
		}

		[Token(Token = "0x60008BF")]
		[Address(RVA = "0x3E86214", Offset = "0x3E86214", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_0029:\n\tv54 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv83 = ~v54;\n\tif (v83) goto L_0076;\n\tv90 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv93 = ~v90;\n\tif (v93) goto L_0076;\n\tv91 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv94 = ~v91;\n\tif (v94) goto L_0076;\n\tv164 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::EnsureGroupVisualForColor(this, v164);\n\tv168 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::TryGetValue(this._lockMonosByColor, v164, &v138 @ stack_-38_v2 (UnityEngine.GameObject));\n\tv126 = v168 == 0;\n\tv111 = ~v126;\n\tv108 = ~v111;\n\tif (v108) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal3 = v138;\n\tgoto L_006D;\nL_FFFFFFFF:\n\treturnVal3 = 0;\nL_0076:\n\treturn 0;\nL_006D:\n\treturn returnVal3;\n")]
		public GameObject TrySpawn(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::TrySpawn");
			return default;
		}

		[Token(Token = "0x60008C0")]
		[Address(RVA = "0x3E8636C", Offset = "0x3E8636C", Length = "0x37C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0045;\n\tv74 = 0xB2A1000 + 0xBB8;\n\tv76 = 0xB2A1000 + 0xC20;\n\tv84 = 0xB2A1000 + 0xC00;\n\tv86 = 0xB2A8000 + 0x3D8;\n\tv90 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(this._leaderByColor);\n\tv157 = v90._dictionary;\n\tv266 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v309);\n\tv270 = v266 == 0;\n\tif (v270) goto L_0073;\n\tv267 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v309, &v59 @ stack_-98_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv271 = v267 == 0;\n\tif (v271) goto L_0073;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v309);\n\tgoto L_0073;\nL_0092:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, _game.BaseLayerSystems.EntitySystem.Core.Entity>+Enumerator<System.Int32Enum, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Dispose(&v157 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>));\n\tv138 = 0;\n\tv187 = &v157 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv194 = 0;\n\tv200 = Il2CppMethodInfo;\n\tv207 = v86;\n\tv209 = v84;\n\tv217 = v76;\n\tv219 = v74;\nL_0094:\n\tv232 = this._leaderByColor == 0;\n\tv138 = 0;\n\tv185 = &v157 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv194 = 0;\n\tv198 = Il2CppMethodInfo;\n\tv206 = v86;\n\tv208 = v84;\n\tv216 = v76;\n\tv218 = v74;\n\tif (v232) goto L_00E8;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._leaderByColor);\n\tv233 = this._groupParentsByColor == 0;\n\tv185 = v187;\n\tv198 = v200;\n\tv206 = v207;\n\tv208 = v209;\n\tv216 = v217;\n\tv218 = v219;\n\tif (v233) goto L_00E8;\n\tv226 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::get_Values(this._groupParentsByColor);\n\tv234 = v226 == 0;\n\tv185 = v187;\n\tv198 = *([v219 @ X28_v2 (System.Int32)]);\n\tv206 = v207;\n\tv208 = v209;\n\tv216 = v217;\n\tv218 = v219;\n\tif (v234) goto L_00E8;\n\tv409 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>+ValueCollection<_game.CoreSystem.GameColor, UnityEngine.GameObject>::GetEnumerator(v226);\n\tv138 = v409._dictionary;\n\tgoto L_00BB;\nL_00BB:\n\tv420 = UnityEngine.Object::op_Inequality(v409.Current, 0);\n\tv423 = v420 == 0;\n\tif (v423) goto L_00AB;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v409.Current);\n\tgoto L_00AB;\nL_00C6:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+ValueCollection<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::Dispose(&v138 @ stack_-B0_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>));\n\tv235 = this._groupParentsByColor == 0;\n\tv185 = v187;\n\tv198 = *([v217 @ X27_v2 (System.Int32)]);\n\tv206 = v207;\n\tv208 = v209;\n\tv216 = v217;\n\tv218 = v219;\n\tif (v235) goto L_00E8;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::Clear(this._groupParentsByColor);\n\tv236 = this._lockMonosByColor == 0;\n\tv185 = &v138 @ stack_-B0_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\n\tv194 = 0;\n\tv198 = Il2CppMethodInfo;\n\tv206 = v207;\n\tv208 = v209;\n\tv216 = v217;\n\tv218 = v219;\n\tif (v236) goto L_00E8;\n\tv198 = *([v209 @ X22_v2 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::Clear(this._lockMonosByColor);\n\tv237 = this._chainsByColor == 0;\n\tv185 = &v138 @ stack_-B0_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\n\tv194 = 0;\n\tv198 = *([v209 @ X22_v2 (System.Int32)]);\n\tv206 = v207;\n\tv208 = v209;\n\tv216 = v217;\n\tv218 = v219;\n\tif (v237) goto L_00E8;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController>::Clear(this._chainsByColor);\n\treturn;\nL_00FA:\n\tv286 = v198 != 1;\n\tif (v286) goto L_0109;\n\tv293 = 0x8BF5BC4(v246, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv194 = *([v293 @ X0_v12]);\n\tv305 = 0x8BF5BF4(v293, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv200 = *([v206 @ X21_v1 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, _game.BaseLayerSystems.EntitySystem.Core.Entity>+Enumerator<System.Int32Enum, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Dispose(v185);\n\tv314 = *([v293 @ X0_v12]) == 0;\n\tv187 = v185;\n\tv194 = *([v293 @ X0_v12]);\n\tv207 = v206;\n\tv209 = v208;\n\tv217 = v216;\n\tv219 = v218;\n\tif (v314) goto L_0094;\n\tgoto L_0124;\nL_0124:\n\tv338 = new System.OutOfMemoryException();\nL_0129:\n\tv323 = 0x8BF0368(v320, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv328 = 0xA1B8(v323, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0045:\n\tv59 = 0;\n\tv65 = this._leaderByColor == 0;\n\tv185 = &v138 @ stack_-B0_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\n\tv194 = 0;\n\tv206 = v207;\n\tv208 = v209;\n\tv216 = v217;\n\tv218 = v219;\n\tif (v65) goto L_00E8;\nL_0073:\n\tv275 = System.Collections.Generic.Dictionary`2<System.Int32Enum, _game.BaseLayerSystems.EntitySystem.Core.Entity>+Enumerator<System.Int32Enum, _game.BaseLayerSystems.EntitySystem.Core.Entity>::MoveNext(&v157 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>));\n\tv291 = v275 == 0;\n\tif (v291) goto L_0092;\nL_00E8:\n\tv246 = new System.NullReferenceException();\n\tgoto L_00FA;\nL_00AB:\n\t;\n\tv429 = System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+ValueCollection<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::MoveNext(&v138 @ stack_-B0_v4 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>));\n\tv431 = v429 == 0;\n\tif (v431) goto L_00C6;\nL_0109:\n\tv295 = 0x318E9AC(&v194 @ stack_-D0_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv320 = v246;\n\tgoto L_0129;\n\tv318 = 0x318E9EC(&v194 @ stack_-D0_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv320 = v338;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::Cleanup");
		}

		[Token(Token = "0x60008C1")]
		[Address(RVA = "0x3E866E8", Offset = "0x3E866E8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::ReconcileGroupVisuals(this);\n\treturn;\n")]
		public void SyncWithData(EntityManager oldData)
		{
			ReconcileGroupVisuals();
		}

		[Token(Token = "0x60008C2")]
		[Address(RVA = "0x3E86D4C", Offset = "0x3E86D4C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::ReconcileGroupVisuals(this);\n\treturn;\n")]
		public void ApplyMaterial(Entity entity, GameColor color)
		{
			ReconcileGroupVisuals();
		}

		[Token(Token = "0x60008C3")]
		[Address(RVA = "0x3E86D50", Offset = "0x3E86D50", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv50 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, entity);\n\tv64 = ~v50;\n\tif (v64) goto L_0045;\n\tv68 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv70 = ~v68;\n\tif (v70) goto L_0045;\n\tv103 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::DestroyGroupVisual(this, v103, 0);\n\treturn;\nL_0045:\n\treturn;\n")]
		public void BeginUnlockBreak(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::BeginUnlockBreak");
		}

		[Token(Token = "0x60008C4")]
		[Address(RVA = "0x3E86FF4", Offset = "0x3E86FF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnSpawned(GameObject go, Entity entity)
		{
		}

		[Token(Token = "0x60008C5")]
		[Address(RVA = "0x3E86FF8", Offset = "0x3E86FF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::ReconcileGroupVisuals(this);\n\treturn;\n")]
		public void ResyncGroupVisuals()
		{
			ReconcileGroupVisuals();
		}

		[Token(Token = "0x60008C6")]
		[Address(RVA = "0x3E86FFC", Offset = "0x3E86FFC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController>::TryGetValue(this._chainsByColor, color, &v56 @ stack_-38_v3 (_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController));\n\tv73 = ~v57;\n\tif (v73) goto L_0039;\n\tgoto L_002E;\nL_002E:\n\tv85 = UnityEngine.Object::op_Equality(v56, 0);\n\tv88 = v85 == 0;\n\tif (v88) goto L_0046;\nL_0039:\n\treturn;\nL_0046:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::Shake(v56);\n\treturn;\n")]
		public void PlayRejectShake(GameColor color)
		{
			if (_chainsByColor.TryGetValue(color, out var value) && !(value == null))
			{
				value.Shake();
			}
		}

		[Token(Token = "0x60008C7")]
		[Address(RVA = "0x3E870E8", Offset = "0x3E870E8", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv58 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController>::TryGetValue(this._chainsByColor, color, &v57 @ stack_-38_v3 (UnityEngine.Component));\n\tv77 = ~v58;\n\tif (v77) goto L_003A;\n\tgoto L_002F;\nL_002F:\n\tv89 = UnityEngine.Object::op_Equality(v57, 0);\n\tv92 = v89 == 0;\n\tif (v92) goto L_0048;\nL_003A:\n\treturn;\nL_0048:\n\tv68 = UnityEngine.Component::get_gameObject(v57);\n\tUnityEngine.GameObject::SetActive(v68, visible);\n\treturn;\n")]
		public unsafe void SetGroupChainVisible(GameColor color, bool visible)
		{
			Component value;
			if (_chainsByColor.TryGetValue(color, out *(ChainController*)(&value)) && !(value == null))
			{
				GameObject gameObject = value.gameObject;
				gameObject.SetActive(visible);
			}
		}

		[Token(Token = "0x60008C8")]
		[Address(RVA = "0x3E84C20", Offset = "0x3E84C20", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv58 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::TryGetValue(this._lockMonosByColor, color, &v57 @ stack_-38_v3 (UnityEngine.GameObject));\n\tv76 = ~v58;\n\tif (v76) goto L_003D;\n\tgoto L_0031;\nL_0031:\n\tv88 = UnityEngine.Object::op_Equality(v57, 0);\n\tv91 = v88 == 0;\n\tif (v91) goto L_004D;\nL_003D:\n\treturn 0;\nL_004D:\n\treturnVal3 = UnityEngine.GameObject::GetComponentInChildren(v57);\n\treturn returnVal3;\n")]
		public LockMono GetLockMono(GameColor color)
		{
			if (!_lockMonosByColor.TryGetValue(color, out var value) || value == null)
			{
				return null;
			}
			return value.GetComponentInChildren<LockMono>();
		}

		[Token(Token = "0x60008C9")]
		[Address(RVA = "0x3E85134", Offset = "0x3E85134", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv149 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController>::TryGetValue(this._chainsByColor, color, &v60.chain (_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController));\n\tv235 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::TryGetValue(this._lockMonosByColor, color, &v111 @ stack_-68_v3 (UnityEngine.GameObject));\n\tv128 = UnityEngine.GameObject::get_transform(v111);\n\tv140 = this._config;\n\tgoto L_005B;\nL_005B:\n\tv243 = UnityEngine.Object::op_Inequality(v140.lockVfx, 0);\n\tv247 = ~v243;\n\tv248 = ~v247;\n\tif (v248) goto L_006C;\n\tgoto L_00C0;\nL_006C:\n\tv262 = new System.Action();\n\tSystem.Action::.ctor(v262, v60, Il2CppMethodInfo);\n\tv129 = PrimeTween.Tween::Delay(0.1f, v262, 0, 1);\n\tv141 = this._config;\n\tv77 = color != 1;\n\tif (v77) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv109 = 0x30;\n\tgoto L_0094;\nL_FFFFFFFF:\n\tv109 = 0x38;\nL_0094:\n\tv300 = UnityEngine.Transform::get_position(v128);\n\tv305 = UnityEngine.Transform::get_rotation(v128);\n\tv282 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(*([v141 @ X8_v17 (_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyAndLockConfig)+v109 @ X9_v6 (System.Int32)]), v300, v305, this._parent);\nL_00C0:\n\treturn;\nL_0031:\n\tv60 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler+<>c__DisplayClass20_0();\n\tSystem.Object::.ctor(v60);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayBreakAnimation(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::PlayBreakAnimation");
		}

		[Token(Token = "0x60008CA")]
		[Address(RVA = "0x3E866EC", Offset = "0x3E866EC", Length = "0x660")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006C;\nL_006C:\n\tv73 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv262 = new System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>();\n\tSystem.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>::.ctor(v262);\nL_FFFFFFFF:\n\tv129 = v378;\nL_FFFFFFFF:\n\tv259 = 0;\n\tgoto L_0083;\nL_0081:\n\tv259 = v259 + 1;\n\tv580 = *([v520 @ X8_v22 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv580 = v580 + 0x10;\n\tv534 = v571 - 1;\n\tv532 = v571 != 1;\nL_FFFFFFFF:\n\tv571 = v534;\n\tif (v532) goto L_008E;\nL_00A3:\n\tv555 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v73, System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv555.m_value(v593, v73, *([v555 @ X0_v79 (System.Boolean)+8]), 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv604 = v259 < v593;\n\tif (v604) goto L_00CA;\nL_FFFFFFFF:\n\tv129 = 0;\n\tgoto L_014D;\nL_00B6:\n\tv614 = *([v580 @ X10_v27]) << 4;\n\tv615 = v520 + v614;\n\tv616 = v615 + 0x138;\n\t*([v616 @ X0_v82])(v620, v73, *([v616 @ X0_v82+8]), v129, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv630 = v259 >= v620;\n\tif (v630) goto L_014D;\nL_00CA:\n\tv648 = *([v73 @ X0_v33 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv681 = *([v648 @ X8_v45 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv650 = *([v648 @ X8_v45 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v650) goto L_00EF;\n\tv223 = *([v648 @ X8_v45 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv223 = v223 + 0x10;\n\tv661 = v681 - 1;\n\tv660 = v681 != 1;\nL_FFFFFFFF:\n\tv681 = v661;\n\tif (v660) goto L_00D5;\nL_00EF:\n\tv732 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v73, v259);\n\tv692 = this._em == 0;\n\tv273 = ~v692;\n\tif (v273) goto L_0102;\nL_FFFFFFFF:\n\tv464 = Il2CppMethodInfo;\n\tgoto L_0212;\nL_00F5:\n\tv116 = *([v223 @ X10_v22]) << 4;\n\tv715 = v648 + v116;\n\tv716 = v715 + 0x138;\n\t*([v716 @ X0_v75])(v732, v73, v259, *([v716 @ X0_v75+8]), v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0102:\n\tv738 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v732);\n\tv748 = ~v738;\nL_FFFFFFFF:\n\tv129 = Il2CppMethodInfo;\n\tif (v748) goto L_0081;\n\tv830 = *([v73 @ X0_v33 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv922 = *([v830 @ X8_v47 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv832 = *([v830 @ X8_v47 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v832) goto L_012C;\n\tv225 = *([v830 @ X8_v47 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv225 = v225 + 0x10;\n\tv871 = v922 - 1;\n\tv870 = v922 != 1;\nL_FFFFFFFF:\n\tv922 = v871;\n\tif (v870) goto L_0112;\nL_012C:\n\tv964 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v73, v259);\n\tv933 = this._em == 0;\n\tv275 = ~v933;\n\tif (v275) goto L_013F;\n\tgoto L_0212;\nL_0132:\n\tv118 = *([v225 @ X10_v16]) << 4;\n\tv959 = v830 + v118;\n\tv960 = v959 + 0x138;\n\t*([v960 @ X0_v67])(v964, v73, v259, *([v960 @ X0_v67+8]), v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_013F:\n\tv267 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v964);\n\tv835 = System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>::Add(v262, v267);\nL_FFFFFFFF:\n\tv129 = Il2CppMethodInfo;\n\tgoto L_0081;\nL_014D:\n\tv269 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::get_Keys(this._groupParentsByColor);\n\tv747 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>+KeyCollection<_game.CoreSystem.GameColor, UnityEngine.GameObject>::GetEnumerator(v269);\n\tv360 = v747._dictionary;\n\tv828 = v262 == 0;\n\tif (v828) goto L_01AC;\nL_FFFFFFFF:\n\tv407 = 0;\n\tv913 = System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>::Contains(v262, v747._currentKey);\n\tv986 = v913 == 0;\n\tv916 = ~v986;\nL_FFFFFFFF:\n\tv129 = Il2CppMethodInfo;\n\tif (v916) goto L_016B;\n\tv992 = v407 == 0;\n\tv993 = ~v992;\nL_FFFFFFFF:\n\tv464 = v747._currentKey;\n\tif (v993) goto L_018A;\n\tv1000 = new System.Collections.Generic.List`1<_game.CoreSystem.GameColor>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.GameColor>::.ctor(v1000);\n\tv472 = v1000 == 0;\nL_FFFFFFFF:\n\tv407 = v1000;\nL_FFFFFFFF:\n\tv464 = Il2CppMethodInfo;\n\tif (v472) goto L_FFFFFFFF;\nL_018A:\n\tv1006 = v407._version + 1;\n\tv407._version = v1006;\n\tv415 = v407._items == 0;\nL_FFFFFFFF:\n\tv439 = &v360 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv378 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv462 = v407;\nL_FFFFFFFF:\n\tv477 = v262;\n\tif (v415) goto L_0215;\n\tgoto L_01A6;\nL_01A6:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.GameColor>::Add(v407, v747._currentKey);\nL_FFFFFFFF:\n\tv129 = Il2CppMethodInfo;\n\tgoto L_016B;\nL_FFFFFFFF:\n\tv439 = &v360 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv462 = v407;\nL_FFFFFFFF:\n\tv342 = 0;\nL_FFFFFFFF:\n\tv477 = v262;\n\tgoto L_01B6;\nL_01AC:\n\tv701 = System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+KeyCollection<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::MoveNext(&v360 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>));\n\tv920 = ~v701;\n\tv473 = ~v920;\n\tif (v473) goto L_0217;\nL_FFFFFFFF:\n\tv439 = &v360 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv462 = 0;\nL_FFFFFFFF:\n\tv342 = 0;\nL_FFFFFFFF:\n\tv477 = v262;\n\tv749 = v462 == 0;\n\tif (v749) goto L_01EA;\n\tv847 = *([v462 @ X21_v4 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)+18]) < 1;\n\tif (v847) goto L_01EA;\nL_FFFFFFFF:\n\tv945 = 0;\nL_01EA:\n\tv892 = System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>::GetEnumerator(v477);\n\tv766 = v892._set;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::EnsureGroupVisualForColor(this, v892._current);\n\tgoto L_01F7;\nL_0203:\n\tSystem.Collections.Generic.HashSet`1<System.Int32Enum>+Enumerator<System.Int32Enum>::Dispose(&v766 @ stack_-98_v2 (System.Collections.Generic.HashSet`1<_game.CoreSystem.GameColor>));\n\treturn;\nL_0212:\n\tthrow System.NullReferenceException;\nL_0214:\n\tv351 = new System.OutOfMemoryException();\nL_0215:\n\tv468 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv129 = v378;\n\tgoto L_021A;\nL_0217:\n\tv468 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv439 = &v360 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv462 = v73;\nL_FFFFFFFF:\n\tv464 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv477 = v262;\n\tgoto L_021A;\nL_FFFFFFFF:\n\tv439 = &v360 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv129 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv464 = Il2CppMethodInfo;\n\tthrow v1000;\nL_021A:\n\t// 538 Interrupt\n\tgoto L_022D;\n\tv606 = 0x8BF5BC4(v468, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv342 = *([v606 @ X0_v24]);\n\tv653 = 0x8BF5BF4(v606, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_\n// ... truncated")]
		internal unsafe void ReconcileGroupVisuals()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::ReconcileGroupVisuals");
		}

		[Token(Token = "0x60008CB")]
		[Address(RVA = "0x3E85A28", Offset = "0x3E85A28", Length = "0x7EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0058;\nL_0058:\n\tv73 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.LockGroupHandler::GetGroup(this._lockGroups, color);\n\tv336 = v73.Count == 0;\n\tif (v336) goto L_0156;\n\tv459 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::TryComputeChainLayout(this, v73, &v212 @ stack_-78_v3 (UnityEngine.Vector3[]), &v204 @ stack_-88_v3 (UnityEngine.Vector3), &v200 @ stack_-98_v3 (UnityEngine.Quaternion), &v196 @ stack_-A0_v3 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv185 = 0xB7D5000 + 0x538;\n\tv465 = v459 == 0;\n\tif (v465) goto L_0158;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::DestroyGroupVisual(this, color, 0);\n\tv182 = color;\n\t// 116 Box v484 @ X0_v24 (System.Object), typeof(_game.CoreSystem.GameColor), &v182 @ stack_-A4_v4 (_game.CoreSystem.GameColor)\n\tv487 = v73.Count;\n\tv498 = \"il2cpp_vm_object_box\"(*([v185 @ X23_v4 (System.Int32)+48]), &v487 @ stack_-A8_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv514 = System.String::Format(\"LockGroup_{0}_{1}\", v484, v498);\n\tv256 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v256, v514);\n\tv257 = UnityEngine.GameObject::get_transform(v256);\n\tUnityEngine.Transform::SetParent(v257, this._parent, 0);\n\tv258 = UnityEngine.GameObject::get_transform(v256);\n\t// 159 MakeStruct v147 @ AGG3E85C50_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v204 @ stack_-88_v3 (UnityEngine.Vector3), v590 @ stack_-84, 0\n\tUnityEngine.Transform::set_position(v258, v147);\n\tv593 = UnityEngine.GameObject::get_transform(v256);\n\tv260 = UnityEngine.Component::get_transform(this._visualGrid);\n\tv150 = UnityEngine.Transform::get_rotation(v260);\n\tUnityEngine.Transform::set_rotation(v593, v150);\n\tv261 = UnityEngine.GameObject::get_transform(v256);\n\tgoto L_00D2;\nL_00D2:\n\t// 210 MakeStruct v138 @ AGG3E85CE8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v611.one (UnityEngine.Vector3), v611.one.y (System.Single), v611.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v261, v138);\n\tv312 = this._config;\n\tv615 = UnityEngine.GameObject::get_transform(v256);\n\tv620 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v312.lockMono, v615);\n\tv133 = color;\n\t// 229 Box v623 @ X0_v48 (System.Object), typeof(_game.CoreSystem.GameColor), &v133 @ stack_-AC_v3 (_game.CoreSystem.GameColor)\n\tv262 = System.String::Format(\"Lock_{0}\", v623);\n\tUnityEngine.Object::set_name(v620, v262);\n\tv280 = UnityEngine.GameObject::get_transform(v620);\n\tgoto L_010B;\nL_010B:\n\t// 267 MakeStruct v123 @ AGG3E85DAC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v314.zero (UnityEngine.Vector3), v314.zero.y (System.Single), v314.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v280, v123);\n\tv263 = UnityEngine.GameObject::get_transform(v620);\n\t// 279 MakeStruct v120 @ AGG3E85DCC_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v200 @ stack_-98_v3 (UnityEngine.Quaternion), v645 @ stack_-94, 0, v644 @ stack_-8C\n\tUnityEngine.Transform::set_localRotation(v263, v120);\n\tv154 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv265 = UnityEngine.GameObject::get_transform(v620);\n\t// 296 MakeStruct v115 @ AGG3E85E04_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v154 @ V0_v8 (System.Single), v154 @ V0_v8 (System.Single), v154 @ V0_v8 (System.Single)\n\tUnityEngine.Transform::set_localScale(v265, v115);\n\tv649 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyAndLockConfig::GetLockMaterial(this._config, color);\n\tv654 = UnityEngine.GameObject::GetComponent(v620);\n\tgoto L_013F;\nL_013F:\n\tv661 = UnityEngine.Object::op_Inequality(v654, 0);\n\tv663 = ~v661;\n\tv664 = ~v663;\n\tif (v664) goto L_0190;\n\tgoto L_0194;\nL_0156:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::DestroyGroupVisual(this, color, 0);\n\treturn;\nL_0158:\n\tv182 = color;\n\t// 349 Box v477 @ X0_v11 (System.Object), typeof(_game.CoreSystem.GameColor), &v182 @ stack_-A4_v4 (_game.CoreSystem.GameColor)\n\tv487 = v73.Count;\n\tv490 = \"il2cpp_vm_object_box\"(*([v185 @ X23_v4 (System.Int32)+48]), &v487 @ stack_-A8_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv505 = System.String::Format(\"[LockVisualHandler] lock group '{0}' ({1} cells) admits no \", v477, v490);\n\tv537 = System.String::Concat(v505, \"chain layout — same-color lock cells must form one orthogonally connected path. Group visual dropped; these locks will block invisibly.\");\n\tgoto L_017C;\nL_0190:\n\tUnityEngine.Renderer::set_sharedMaterial(v654.m_renderer, v649);\nL_0194:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::BindEntityMono(v620, v196);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::set_Item(this._groupParentsByColor, color, v256);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::set_Item(this._lockMonosByColor, color, v620);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._leaderByColor, color, v196);\n\tv272 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::OnSpawned(this, v620, v196);\n\tv316 = this._config;\n\tgoto L_01C0;\nL_01C0:\n\tv570 = UnityEngine.Object::op_Inequality(v316.chainPrefab, 0);\n\tv689 = ~v570;\n\tv573 = ~v689;\n\tif (v573) goto L_01CD;\n\tgoto L_0268;\nL_01CD:\n\tv575 = v212 == 0;\n\tif (v575) goto L_0268;\n\tv85 = v212.Length < 2;\n\tif (v85) goto L_0268;\n\tv317 = this._config;\n\tv696 = UnityEngine.GameObject::get_transform(v256);\n\tv700 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v317.chainPrefab, v696);\n\tv182 = color;\n\t// 491 Box v703 @ X0_v79 (System.Object), typeof(_game.CoreSystem.GameColor), &v182 @ stack_-A4_v4 (_game.CoreSystem.GameColor)\n\tv274 = System.String::Format(\"Chain_{0}\", v703);\n\tUnityEngine.Object::set_name(v700, v274);\n\tv709 = UnityEngine.GameObject::get_transform(v700);\n\tv275 = 0x3D15AE8(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 514 MakeStruct v82 @ AGG3E860C8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v154 @ V0_v8 (System.Single), v154 @ V0_v8 (System.Single), v154 @ V0_v8 (System.Single)\n\tUnityEngine.Transform::set_localPosition(v709, v82);\n\tv714 = UnityEngine.GameObject::get_transform(v700);\n\tv276 = 0x3E74E78(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 526 MakeStruct v79 @ AGG3E860F0_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v154 @ V0_v8 (System.Single), v154 @ V0_v8 (System.Single), v154 @ V0_v8 (System.Single), v644 @ stack_-8C\n\tUnityEngine.Transform::set_localRotation(v714, v79);\n\tv722 = UnityEngine.GameObject::GetComponent(v700);\n\tgoto L_021F;\nL_021F:\n\tv729 = UnityEngine.Object::op_Equality(v722, 0);\n\tv730 = ~v729;\n\tif (v730) goto L_023F;\n\tgoto L_022F;\nL_022F:\n\tUnityEngine.Debug::LogError(\"[LockVisualHandler] chainPrefab is missing ChainController component.\", v700);\n\tgoto L_0238;\nL_0238:\n\tUnityEngine.Object::Destroy(v700);\n\tgoto L_0268;\nL_023F:\n\tv278 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyAndLockConfig::GetChainMaterial(this._config, color);\n\t_game.CoreSystem.New.TopGridSystem.Me\n// ... truncated")]
		private void EnsureGroupVisualForColor(GameColor color)
		{
			//IL_0153: Expected F4, but got O
			//IL_030e: Expected F4, but got O
			//IL_0329: Expected F4, but got O
			//IL_0697: Expected F4, but got O
			List<Entity> list = _lockGroups.GetGroup(color);
			if (list.Count != 0)
			{
				bool flag = TryComputeChainLayout(list, out var localWaypoints, out var lockCenterWorld, out var lockLocalRotation, out var leader);
				int num = 192761856 + 1336;
				if (flag)
				{
					DestroyGroupVisual(color, chainBreak: false);
					GameColor gameColor = color;
					object arg = gameColor;
					int count = list.Count;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg2 = default(object);
					string name = $"LockGroup_{arg}_{arg2}";
					GameObject gameObject = new GameObject(name);
					Transform transform = gameObject.transform;
					transform.SetParent(_parent, worldPositionStays: false);
					Transform transform2 = gameObject.transform;
					Vector3 position = default(Vector3);
					position.x = lockCenterWorld.x;
					object obj = default(object);
					position.y = (float)obj;
					position.z = 0f;
					transform2.position = position;
					Transform transform3 = gameObject.transform;
					Transform transform4 = _visualGrid.transform;
					Quaternion rotation = transform4.rotation;
					transform3.rotation = rotation;
					Transform transform5 = gameObject.transform;
					Vector3 localScale = default(Vector3);
					localScale.x = Vector3.one.x;
					localScale.y = Vector3.one.y;
					localScale.z = Vector3.one.z;
					transform5.localScale = localScale;
					KeyAndLockConfig config = _config;
					Transform transform6 = gameObject.transform;
					GameObject gameObject2 = VisualHandlerUtility.Instantiate(config.lockMono, transform6);
					object arg3 = color;
					string name2 = $"Lock_{arg3}";
					gameObject2.name = name2;
					Transform transform7 = gameObject2.transform;
					Vector3 localPosition = default(Vector3);
					localPosition.x = Vector3.zero.x;
					localPosition.y = Vector3.zero.y;
					localPosition.z = Vector3.zero.z;
					transform7.localPosition = localPosition;
					Transform transform8 = gameObject2.transform;
					Quaternion localRotation = default(Quaternion);
					localRotation.x = lockLocalRotation.x;
					object obj2 = default(object);
					localRotation.y = (float)obj2;
					localRotation.z = 0f;
					object obj3 = default(object);
					localRotation.w = (float)obj3;
					transform8.localRotation = localRotation;
					float effectiveCubeSize = _visualGrid.EffectiveCubeSize;
					Transform transform9 = gameObject2.transform;
					Vector3 localScale2 = default(Vector3);
					localScale2.x = effectiveCubeSize;
					localScale2.y = effectiveCubeSize;
					localScale2.z = effectiveCubeSize;
					transform9.localScale = localScale2;
					Material lockMaterial = _config.GetLockMaterial(color);
					SimpleMaterialSetter component = gameObject2.GetComponent<SimpleMaterialSetter>();
					if (component != null)
					{
						component.m_renderer.sharedMaterial = lockMaterial;
					}
					VisualHandlerUtility.BindEntityMono(gameObject2, leader);
					_groupParentsByColor[color] = gameObject;
					_lockMonosByColor[color] = gameObject2;
					_leaderByColor[color] = leader;
					OnSpawned(gameObject2, leader);
					KeyAndLockConfig config2 = _config;
					if (config2.chainPrefab != null && localWaypoints != null && localWaypoints.Length >= 2)
					{
						KeyAndLockConfig config3 = _config;
						Transform transform10 = gameObject.transform;
						GameObject gameObject3 = VisualHandlerUtility.Instantiate(config3.chainPrefab, transform10);
						gameColor = color;
						object arg4 = gameColor;
						string name3 = $"Chain_{arg4}";
						gameObject3.name = name3;
						Transform transform11 = gameObject3.transform;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3D15AE8 (inside _game.CoreGameKit.UiControllers.RewardUiController+<>c__DisplayClass13_0::.ctor +0x8)");
						Vector3 localPosition2 = default(Vector3);
						localPosition2.x = effectiveCubeSize;
						localPosition2.y = effectiveCubeSize;
						localPosition2.z = effectiveCubeSize;
						transform11.localPosition = localPosition2;
						Transform transform12 = gameObject3.transform;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E74E78 (inside _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ScatterPiece +0x3E0)");
						Quaternion localRotation2 = default(Quaternion);
						localRotation2.x = effectiveCubeSize;
						localRotation2.y = effectiveCubeSize;
						localRotation2.z = effectiveCubeSize;
						localRotation2.w = (float)obj3;
						transform12.localRotation = localRotation2;
						ChainController component2 = gameObject3.GetComponent<ChainController>();
						if (component2 == null)
						{
							Debug.LogError("[LockVisualHandler] chainPrefab is missing ChainController component.", gameObject3);
							UnityEngine.Object.Destroy(gameObject3);
							return;
						}
						Material chainMaterial = _config.GetChainMaterial(color);
						component2.Initialize(localWaypoints, chainMaterial);
						Transform transform13 = gameObject2.transform;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3D15AE8 (inside _game.CoreGameKit.UiControllers.RewardUiController+<>c__DisplayClass13_0::.ctor +0x8)");
						Vector3 localPosOnChain = default(Vector3);
						localPosOnChain.x = effectiveCubeSize;
						localPosOnChain.y = effectiveCubeSize;
						localPosOnChain.z = effectiveCubeSize;
						component2.Attach(transform13, localPosOnChain);
						_chainsByColor[color] = component2;
					}
				}
				else
				{
					GameColor gameColor = color;
					object arg5 = gameColor;
					int count = list.Count;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg6 = default(object);
					string text = $"[LockVisualHandler] lock group '{arg5}' ({arg6} cells) admits no ";
					string message = text + "chain layout — same-color lock cells must form one orthogonally connected path. Group visual dropped; these locks will block invisibly.";
					Debug.LogError(message);
					DestroyGroupVisual(color, chainBreak: false);
				}
			}
			else
			{
				DestroyGroupVisual(color, chainBreak: false);
			}
		}

		[Token(Token = "0x60008CC")]
		[Address(RVA = "0x3E86E18", Offset = "0x3E86E18", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv58 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._leaderByColor, color, &v56 @ stack_-38_v3 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv112 = ~v58;\n\tif (v112) goto L_0055;\n\tv152 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v56);\n\tv161 = ~v152;\n\tif (v161) goto L_004A;\n\tv166 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::TryGetMonoBinding(v56, &v46 @ stack_-48_v1 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv171 = ~v166;\n\tif (v171) goto L_004A;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::UnbindMono(v56);\nL_004A:\n\tv119 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Remove(this._leaderByColor, color);\nL_0055:\n\tv158 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::TryGetValue(this._groupParentsByColor, color, &v68 @ stack_-40_v3 (UnityEngine.Object));\n\tv162 = ~v158;\n\tif (v162) goto L_0080;\n\tgoto L_0061;\nL_0061:\n\tv186 = UnityEngine.Object::op_Inequality(v68, 0);\n\tv191 = ~v186;\n\tv192 = ~v191;\n\tif (v192) goto L_0074;\n\tv207 = this._groupParentsByColor;\n\tv200 = this._groupParentsByColor == 0;\n\tv98 = ~v200;\n\tif (v98) goto L_007A;\n\tgoto L_0091;\nL_0074:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::DestroyGo(v68);\n\tv207 = this._groupParentsByColor;\nL_007A:\n\tv180 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::Remove(v207, color);\nL_0080:\n\tv190 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::Remove(this._lockMonosByColor, color);\n\tv135 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController>::Remove(this._chainsByColor, color);\n\treturn;\nL_0091:\n\tthrow System.NullReferenceException;\nL_0026:\n\tv46 = 0;\n")]
		private unsafe void DestroyGroupVisual(GameColor color, bool chainBreak)
		{
			EntityMono mono = null;
			if (_leaderByColor.TryGetValue(color, out var value))
			{
				if (_em.IsValid(value) && value.TryGetMonoBinding(out mono))
				{
					value.UnbindMono();
				}
				bool flag = _leaderByColor.Remove(color);
			}
			UnityEngine.Object value2;
			if (_groupParentsByColor.TryGetValue(color, out *(GameObject*)(&value2)))
			{
				Dictionary<GameColor, GameObject> groupParentsByColor;
				if (!(value2 != null))
				{
					groupParentsByColor = _groupParentsByColor;
					if (_groupParentsByColor == null)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					VisualHandlerUtility.DestroyGo((GameObject)value2);
					groupParentsByColor = _groupParentsByColor;
				}
				bool flag2 = groupParentsByColor.Remove(color);
			}
			bool flag3 = _lockMonosByColor.Remove(color);
			bool flag4 = _chainsByColor.Remove(color);
		}

		[Token(Token = "0x60008CD")]
		[Address(RVA = "0x3E871F4", Offset = "0x3E871F4", Length = "0xE24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0072;\n\tv106 = group.Count == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tv263 = new System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::.ctor(v263, group.Count);\n\tv563 = group.Count < 1;\nL_FFFFFFFF:\n\tv242 = this;\n\tif (v563) goto L_0117;\nL_FFFFFFFF:\n\tv639 = 0;\n\tgoto L_00CF;\nL_00B8:\n\tv163 = v786;\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::Add(v263, &v163 @ stack_-C0 (System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>));\nL_FFFFFFFF:\n\tv163 = v786;\nL_00BE:\n\tv639 = v639 + 1;\n\tv587 = v639 >= group.Count;\nL_FFFFFFFF:\n\tv242 = this;\n\tif (v587) goto L_0117;\nL_00CF:\n\tv644 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(group, v639);\n\tv1100 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v644);\n\tv1104 = ~v1100;\n\tif (v1104) goto L_00BE;\n\tv1111 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(group, v639);\n\tv970 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(group, v639);\n\tv1164 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v970);\n\tSystem.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(&v786 @ stack_-D8_v14 (System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>), v1111, v1164);\n\tgoto L_00B8;\nL_0117:\n\tv233 = v263.Count == 0;\n\tif (v233) goto L_FFFFFFFF;\n\tv973 = UnityEngine.Component::get_transform(v242._visualGrid);\n\tv1011 = v242._config;\n\t// 297 MakeStruct v127 @ AGG3E875AC_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1011.lockOverlayOffset (UnityEngine.Vector3), v1011.lockOverlayOffset.y (System.Single), v1011.lockOverlayOffset.z (System.Single)\n\tv168 = UnityEngine.Transform::InverseTransformVector(v973, v127);\n\tv823 = v263.Count != 1;\n\tif (v823) goto L_01C6;\n\tv1168 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(v263, 0);\n\tv1185 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToLocal(v242._visualGrid, v1168.Item2);\n\tv1205 = v168 + v1185;\n\tv1206 = v168.y + v1185.y;\n\tv1207 = v168.z + v1185.z;\n\t// 343 MakeStruct v701 @ AGG3E87610_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1205 @ V0_v46 (System.Single), v1206 @ V1_v43 (System.Single), v1207 @ V2_v32 (System.Single)\n\tv807 = UnityEngine.Transform::TransformPoint(v973, v701);\n\tlockCenterWorld.x = v807;\n\tlockCenterWorld.y = v807.y;\n\tlockCenterWorld.z = v807.z;\n\tv808 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(v242._visualGrid);\n\t// 366 NewArr v976 @ X0_v127 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 3\n\tv1512 = v808 * 0.5f;\n\tv1516 = v1512 * 0x3F666666;\n\tv1517 = -v1516;\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+20]) = v1517;\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+24]) = 0;\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+28]) = 0;\n\tgoto L_019D;\nL_019D:\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+2C]) = v1535.zero;\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+34]) = v1535.zero.z;\n\tv1765 = v1512 * 0x3F666666;\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+38]) = v1765;\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+3C]) = 0;\n\t*([v976 @ X0_v127 (UnityEngine.Vector3[])+40]) = 0;\n\t*([localWaypoints @ X2 (UnityEngine.Vector3[]&)]) = v976;\n\tgoto L_01BF;\nL_01C6:\n\tv1172 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v1172, v263.Count);\n\tv1197 = v263.Count < 1;\nL_FFFFFFFF:\n\tv165 = v163;\nL_FFFFFFFF:\n\t;\n\tif (v1197) goto L_022E;\n\tv1209 = v1172 == 0;\n\tif (v1209) goto L_0564;\nL_FFFFFFFF:\n\tv1039 = 0;\n\tgoto L_01F9;\nL_01E7:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v1172, v977.Item2);\n\tv1039 = v1039 + 1;\n\tv1214 = v1039 >= v263.Count;\nL_FFFFFFFF:\n\t;\n\tif (v1214) goto L_022E;\nL_01F9:\n\tv977 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(v263, v1039);\n\tv165 = v977.Item1;\n\tgoto L_01E7;\nL_022E:\n\tgoto L_0231;\nL_0231:\n\tv231 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::FindLongestPath(v1172);\n\tv174 = v231.Count < 2;\n\tif (v174) goto L_FFFFFFFF;\n\tv1465 = v231.Count >= v263.Count;\nL_FFFFFFFF:\n\tv1751 = v165;\n\tif (v1465) goto L_027C;\n\tv1478 = v263.Count;\n\tv1480 = 0xB7D5000 + 0x538;\n\tv1483 = \"il2cpp_vm_object_box\"(*([v1480 @ X20_v32 (System.Int32)+48]), &v1478 @ stack_-C0_v17 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1643 = System.String::Format(\"[LockVisualHandler] lock group of {0} cells is only \", v1483);\n\tv1486 = v231.Count;\n\tv1668 = \"il2cpp_vm_object_box\"(*([v1480 @ X20_v32 (System.Int32)+48]), &v1486 @ stack_-D8_v11 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1743 = System.String::Format(\"partially chainable — the chain covers {0} cells; the rest \", v1668);\n\tv1495 = System.String::Concat(v1643, v1743, \"render no visual but still block.\");\n\tgoto L_0279;\nL_027C:\n\t;\n\tv1507 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(v231, 0);\n\tv1655 = v263.Count < 1;\n\tif (v1655) goto L_02E1;\nL_FFFFFFFF:\n\tv1688 = 0;\n\tv1688 = v1688 + 1;\n\tv1692 = v1688 < v263.Count;\n\tif (v1692) goto L_0294;\n\tgoto L_02E1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_02D3:\n\tv1723 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(v263, v1688);\n\tleader.Id = v1723.Item1;\n\tv1432 = v1430 == 0;\n\tif (v1432) goto L_0570;\n\tv1068 = v1430 + 0x28;\nL_FFFFFFFF:\n\tv1040 = 0;\n\tv1541 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToLocal(v242._visualGrid, v978);\n\tv1776 = v168.z + v1541.z;\n\tv1777 = v168.y + v1541.y;\n\tv1778 = v168 + v1541;\n\t*([v1068 @ X20_v27-8]) = v1778;\n\t*([v1068 @ X20_v27-4]) = v1777;\n\t*([v1068 @ X20_v27]) = v1776;\n\tv1068 = v1068 + 0xC;\n\tv1040 = v1040 + 1;\n\tv1779 = v231.Count != v1040;\n\tif (v1779) goto L_02F8;\nL_0326:\n\tv811 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(v242._visualGrid);\n\tv1078 = v1430 + 0x20;\n\tgoto L_0344;\nL_034D:\n\tv1874 = v1527 * v1527;\n\t// 846 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv1875 = v1526 * v1526;\n\tv1876 = v1875 + v1874;\n\tv1542 = UnityEngine.Mathf::Sqrt(v1876);\n\tv1879 = v1542 < 0x3727C5AC;\n\tv1880 = v1542 == 0x3727C5AC;\n\tv1883 = v1542 == v1542;\n\tv1886 = ~v1883;\n\tv1887 = v1879 == v1886;\n\tv1888 = ~v1887;\n\tv1546 = v1888 | v1880;\n\tif (v1546) goto L_036C;\n\t// 865 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv688 = v1527 / 0x3727C5AC;\n\tv680 = v1526 / v1542;\n\tgoto L_0376;\nL_036C:\n\tgoto L_0375;\n\tv1629 = v231.Count - 2;\n\tv1911 = v1054 * 0xC;\n\tv1061 = v1078 + v1911;\n\tv1913 = v1629 * 0xC;\n\tv1914 = v1078 + v1913;\n\tgoto L_03A0;\nL_03A8:\n\tv1934 = v1926 * v1926;\n\t// 937 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv1935 = v1927 * v1927;\n\tv1936 = v1935 + v1934;\n\tv1544 = UnityEngine.Mathf::Sqrt(v1936);\n\tv1596 = v1544 < 0x3727C5A\n// ... truncated")]
		private unsafe bool TryComputeChainLayout(List<Entity> group, out Vector3[] localWaypoints, out Vector3 lockCenterWorld, out Quaternion lockLocalRotation, out Entity leader)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::TryComputeChainLayout");
			localWaypoints = default;
			lockCenterWorld = default;
			lockLocalRotation = default;
			leader = default;
			return default;
		}

		[Token(Token = "0x60008CE")]
		[Address(RVA = "0x3E88228", Offset = "0x3E88228", Length = "0x510")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0030:\n\tv79 = path.Count <= 1;\n\tif (v79) goto L_008E;\n\tv152 = path.Count >> 1;\n\tv157 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v152);\n\tv166 = v152 - 1;\n\tv170 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v166);\n\tv271 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v152);\n\tv330 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v166);\n\tv95 = v157 - v170;\n\tv333 = v271.y - v330.y;\n\tv338 = path.Count & 1;\n\tv339 = v338 == 0;\n\tv340 = ~v339;\n\tif (v340) goto L_009E;\n\tgoto L_0063;\nL_0065:\n\tv369 = v95 * v95;\n\tv370 = v333 * v333;\n\tv371 = v369 + v370;\n\tv420 = UnityEngine.Mathf::Sqrt(v371);\n\tv382 = v420 < 0x3727C5AC;\n\tv383 = v420 == 0x3727C5AC;\n\tv386 = v420 == v420;\n\tv389 = ~v386;\n\tv390 = v382 == v389;\n\tv391 = ~v383;\n\tv392 = v390 & v391;\nL_FFFFFFFF:\n\tv422 = v333;\nL_FFFFFFFF:\n\tv424 = v95;\n\tif (v392) goto L_016A;\n\tgoto L_0086;\nL_008E:\n\tgoto L_0096;\nL_009E:\n\tgoto L_00A8;\nL_00AA:\n\tv375 = v95 * v95;\n\tv376 = v333 * v333;\n\tv377 = v375 + v376;\n\tv378 = UnityEngine.Mathf::Sqrt(v377);\n\tgoto L_00C1;\nL_00C1:\n\tv93 = v95 / v378;\n\tv91 = v333 / v378;\n\tgoto L_00D4;\n\tv693 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v152);\n\tv150 = v551 - v636;\n\tv699 = v663.y - v693.y;\n\tgoto L_00FB;\nL_00FD:\n\tv728 = v150 * v150;\n\tv729 = v699 * v699;\n\tv730 = v728 + v729;\n\tv731 = UnityEngine.Mathf::Sqrt(v730);\n\tgoto L_0110;\nL_0110:\n\tv83 = v150 / v731;\n\tv81 = v699 / v731;\n\tgoto L_0121;\n\tv141 = UnityEngine.Component::get_transform(*([B193018]));\n\tv788 = UnityEngine.Transform::get_rotation(v141);\n\treturnVal2 = UnityEngine.Quaternion::Inverse(v788);\n\tgoto L_0205;\nL_0149:\n\tgoto L_014F;\nL_0157:\n\tv785 = v424 * v424;\n\tv786 = v423 * v423;\n\tv787 = v785 + v786;\n\tv420 = UnityEngine.Mathf::Sqrt(v787);\n\tv440 = v420 < 0x3727C5AC;\n\tv438 = v420 == 0x3727C5AC;\n\tv791 = v420 == v420;\n\tv434 = ~v791;\n\tv792 = v440 == v434;\n\tv793 = ~v792;\n\tv432 = v793 | v438;\nL_FFFFFFFF:\n\tv422 = v423;\n\tif (v432) goto L_0179;\nL_016A:\n\tv586 = v424 / v420;\n\tv642 = v422 / v420;\n\tv456 = v642 < 0;\n\tv462 = ~v456;\n\tif (v462) goto L_0191;\nL_FFFFFFFF:\n\tv587 = v642;\n\tgoto L_01CC;\nL_0179:\n\tgoto L_0182;\nL_0191:\n\tgoto L_019B;\n\tgoto L_01B8;\nL_FFFFFFFF:\n\tv579 = v575;\n\tv607 = v586 < 0;\n\tv599 = ~v607;\nL_FFFFFFFF:\n\tv587 = v642;\n\tif (v599) goto L_01CD;\nL_01CC:\n\tv642 = -v587;\nL_FFFFFFFF:\n\tv704 = v670;\n\tgoto L_01EB;\nL_0063:\n\tgoto L_0065;\nL_0086:\n\tgoto L_0182;\nL_0096:\n\treturnVal2 = v178.identity;\n\tgoto L_0205;\nL_00A8:\n\tgoto L_00AA;\nL_00D4:\n\tv549 = v152 + 1;\n\tv551 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v549);\n\tv636 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v152);\n\tv661 = v152 + 1;\n\tv663 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v661);\nL_00FB:\n\tgoto L_00FD;\nL_0121:\n\tv759 = v93 * v83;\n\tv760 = v91 * v81;\n\tv761 = v759 + v760;\n\tv89 = UnityEngine.Mathf::Abs(v761);\n\tv129 = v89 < 0x3A83126F;\n\tv113 = ~v129;\n\tif (v113) goto L_0149;\nL_0205:\n\treturn returnVal2;\nL_014F:\n\tv424 = v93 + v83;\n\tv423 = v91 + v81;\n\tgoto L_0157;\nL_019B:\n\tv632 = UnityEngine.Mathf::Abs(v642);\n\tv659 = UnityEngine.Mathf::Max(v632, 0f);\n\tv579 = v659 * 0x358637BD;\n\tv575 = v677.Epsilon * 8f;\n\tv682 = v579 < v575;\n\tv683 = v579 == v575;\n\tv686 = v579 == v579;\n\tv687 = v575 == v575;\n\tv688 = v686 & v687;\n\tv689 = ~v688;\n\tv690 = v682 == v689;\n\tv584 = ~v683;\n\tv691 = v690 & v584;\n\tv571 = ~v691;\n\tif (v571) goto L_FFFFFFFF;\nL_01B8:\n\t// 440 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv651 = 0 < v579;\n\tv644 = ~v651;\n\tif (v644) goto L_01CD;\nL_01CD:\n\tv658 = 0x8BF5E94(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv704 = v642 * 0x42652EE1;\n\tv670 = v704 + 0xFFFFFFFFC3340000;\n\tv311 = v704 < 0x42B40000;\n\tv310 = v704 == 0x42B40000;\n\tv674 = v704 == v704;\n\tv308 = ~v674;\n\tv675 = v311 == v308;\n\tv287 = ~v310;\n\tv307 = v675 & v287;\n\tv273 = ~v307;\n\tif (v273) goto L_01EB;\nL_01EB:\n\tv707 = v704 * 0x3C8EFA35;\n\t// 495 MakeStruct v272 @ AGG3E8870C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v707 @ V2_v5 (System.Single)\n\treturnVal2 = UnityEngine.Quaternion::Internal_FromEulerRad(v272);\nL_0182:\n\tv642 = v526.zero.y;\n\tv514 = v526.zero.y < 0;\nL_FFFFFFFF:\n\tv586 = v526.zero;\nL_FFFFFFFF:\n\tv587 = v526.zero.y;\n\tif (v514) goto L_01CC;\n")]
		private Quaternion ComputeLockRotation(List<GridCoord> path)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::ComputeLockRotation");
			return default;
		}

		[Token(Token = "0x60008CF")]
		[Address(RVA = "0x3E88018", Offset = "0x3E88018", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\nL_0040:\n\tv71 = cells.Count <= 1;\n\tif (v71) goto L_00B0;\n\tv147 = new System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v147, cells);\n\tv234 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v234);\n\tv281 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v281);\n\tv268 = new System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v268);\n\tv249 = cells.Count < 1;\nL_FFFFFFFF:\n\tv244 = v234;\n\tif (v249) goto L_00C5;\nL_FFFFFFFF:\n\tv94 = 1;\n\tv321 = v91.Count - cells.Count;\n\tv323 = v321 == 0;\n\tv328 = ~v323;\n\tv235 = ~v328;\n\tif (v235) goto L_FFFFFFFF;\n\tv331 = v94 - cells.Count;\n\tv262 = v331 < 0;\n\tv334 = v94 ^ cells.Count;\n\tv335 = v94 ^ v331;\n\tv336 = v334 & v335;\n\tv252 = v336 < 0;\n\tgoto L_00A8;\nL_FFFFFFFF:\n\tv252 = 0;\nL_FFFFFFFF:\n\tv262 = 0;\nL_FFFFFFFF:\n\tv244 = v91;\n\tgoto L_00C5;\nL_00B0:\n\tv151 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v151, cells);\nL_FFFFFFFF:\n\tv244 = v151;\nL_00C5:\n\treturn v244;\nL_0087:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::DfsLongest(v133, v147, v268, v281, &v91 @ stack_-68_v5 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\nL_00A8:\n\tv94 = v94 + 1;\n\tv342 = v262 == v252;\n\tv250 = ~v342;\n\tif (v250) goto L_0074;\nL_0074:\n\tv308 = v94 - 1;\n\tv133 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(cells, v308);\n\tgoto L_0087;\n")]
		private static List<GridCoord> FindLongestPath(List<GridCoord> cells)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::FindLongestPath");
			return default;
		}

		[Token(Token = "0x60008D0")]
		[Address(RVA = "0x3E88738", Offset = "0x3E88738", Length = "0x34C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0046;\nL_0046:\n\tv73 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(visited, cur);\n\tgoto L_006C;\nL_006C:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(current, cur);\n\tv192 = best->klass;\n\tv94 = current.Count <= v192.Count;\n\tif (v94) goto L_00A0;\n\tv373 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v373, current);\n\t*([best @ X5 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>&)]) = v373;\n\tv192 = best->klass;\nL_00A0:\n\tv391 = v192.Count >= cells.Count;\n\tv436 = cur;\n\tv437 = visited;\n\tv438 = current;\n\tif (v391) goto L_0110;\n\tv91 = 0;\n\tv436 = cur;\n\tv437 = visited;\n\tv438 = current;\n\tgoto L_00BB;\nL_00B4:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockVisualHandler::DfsLongest(v419, cells, v437, v438, best);\n\tv96 = v91 >= v254.Length;\n\tif (v96) goto L_0110;\n\tgoto L_00E3;\nL_00E3:\n\tv420 = v91 << 3;\n\tv453 = v254 + v420;\n\tv454 = *([v453 @ X8_v26+20]);\n\tv456 = *([v453 @ X8_v26+20]) + v436;\n\tv457 = *([v454 @ X8_v27+24]) + cur.y;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v419 @ stack_-70_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v456, v457);\n\tv463 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(cells, v419);\n\tv464 = ~v463;\n\tif (v464) goto L_00B6;\n\tv469 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v437, v419);\n\tv486 = v469 == 0;\n\tv478 = ~v486;\n\tif (v478) goto L_00B6;\n\tgoto L_00B4;\nL_0110:\n\tv418 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Remove(v437, v436);\n\tv341 = v438.Count - 1;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::RemoveAt(v438, v341);\n\treturn;\nL_00BB:\n\tgoto L_00BF;\nL_00B6:\n\tv91 = v91 + 1;\nL_00BF:\n\tv254 = v446.s_neighborDeltas;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DfsLongest(GridCoord cur, HashSet<GridCoord> cells, HashSet<GridCoord> visited, List<GridCoord> current, ref List<GridCoord> best)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockVisualHandler::DfsLongest");
		}

		[Token(Token = "0x60008D1")]
		[Address(RVA = "0x3E88A84", Offset = "0x3E88A84", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv81 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::.ctor(v81);\n\tthis._lockMonosByColor = v81;\n\tv94 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController>::.ctor(v94);\n\tthis._chainsByColor = v94;\n\tv102 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v102);\n\tthis._leaderByColor = v102;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0034:\n\tv64 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.GameObject>::.ctor(v64);\n\tthis._groupParentsByColor = v64;\n")]
		public LockVisualHandler()
		{
			Dictionary<GameColor, GameObject> groupParentsByColor = new Dictionary<GameColor, GameObject>();
			_groupParentsByColor = groupParentsByColor;
			Dictionary<GameColor, GameObject> lockMonosByColor = new Dictionary<GameColor, GameObject>();
			_lockMonosByColor = lockMonosByColor;
			Dictionary<GameColor, ChainController> chainsByColor = new Dictionary<GameColor, ChainController>();
			_chainsByColor = chainsByColor;
			Dictionary<GameColor, Entity> leaderByColor = new Dictionary<GameColor, Entity>();
			_leaderByColor = leaderByColor;
		}

		[Token(Token = "0x60008D2")]
		[Address(RVA = "0x3E88BDC", Offset = "0x3E88BDC", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+20]) = v56;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v117 @ stack_-40_v4 (System.ValueTuple`2<System.Int32, System.Int32>), -1, 0);\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+28]) = v117;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v126 @ stack_-48_v4 (System.ValueTuple`2<System.Int32, System.Int32>), 0, 1);\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+30]) = v126;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v120 @ stack_-50_v4 (System.ValueTuple`2<System.Int32, System.Int32>), 0, -1);\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+38]) = v120;\n\tv197.s_neighborDeltas = v48;\n\treturn;\nL_001F:\n\t// 31 NewArr v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[]), typeof(System.ValueTuple`2<System.Int32, System.Int32>[]), 4\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v56 @ stack_-38_v2 (System.ValueTuple`2<System.Int32, System.Int32>), 1, 0);\n")]
		static LockVisualHandler()
		{
			(int, int)[] array = new(int, int)[4];
			(int, int) tuple = (1, 0);
			(int, int) tuple2 = (-1, 0);
			(int, int) tuple3 = (0, 1);
			(int, int) tuple4 = (0, -1);
			s_neighborDeltas = array;
		}
	}
}

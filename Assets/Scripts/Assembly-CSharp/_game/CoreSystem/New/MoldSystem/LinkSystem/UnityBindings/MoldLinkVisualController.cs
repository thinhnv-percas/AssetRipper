using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.Visual;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings
{
	[Token(Token = "0x20002A9")]
	public class MoldLinkVisualController : MonoBehaviour, IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000838")]
		[FieldOffset(Offset = "0x20")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000839")]
		[FieldOffset(Offset = "0x28")]
		private MoldVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x400083A")]
		[FieldOffset(Offset = "0x30")]
		private MoldEntitySystemCreator _entityCreator;

		[Inject(false)]
		[Token(Token = "0x400083B")]
		[FieldOffset(Offset = "0x38")]
		private MoldLinkedHandler _linkedHandler;

		[Inject(true)]
		[Token(Token = "0x400083C")]
		[FieldOffset(Offset = "0x40")]
		private IVfxPool _vfxPool;

		[SerializeField]
		[Token(Token = "0x400083D")]
		[FieldOffset(Offset = "0x48")]
		private MoldLinkVisualConfig m_visualConfig;

		[Token(Token = "0x400083E")]
		[FieldOffset(Offset = "0x50")]
		private readonly List<GameObject> _linkVisuals;

		[Token(Token = "0x400083F")]
		[FieldOffset(Offset = "0x58")]
		private readonly Dictionary<int, GameObject> _capObjects;

		[Token(Token = "0x4000840")]
		[FieldOffset(Offset = "0x60")]
		private readonly Dictionary<(int, int), GameObject> _ropeObjects;

		[Inject(false)]
		[Token(Token = "0x6000BCA")]
		[Address(RVA = "0x3ECAF4C", Offset = "0x3ECAF4C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::Cleanup(this);\n\treturn;\n")]
		private void Construct()
		{
			Cleanup();
		}

		[Token(Token = "0x6000BCB")]
		[Address(RVA = "0x3ECB1C8", Offset = "0x3ECB1C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::CreateLinkVisuals(this);\n\treturn;\n")]
		public void Initialize()
		{
			CreateLinkVisuals();
		}

		[Token(Token = "0x6000BCC")]
		[Address(RVA = "0x3ECAF50", Offset = "0x3ECAF50", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv153 = 0xB2A2000 + 0x5D0;\n\tv149 = 0xB2A6000 + 0x448;\n\tv73 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(this._linkVisuals);\n\tv184 = v73._list;\n\tgoto L_0059;\nL_0053:\n\tgoto L_0056;\nL_0056:\n\tUnityEngine.Object::DestroyImmediate(v73.Current);\nL_0059:\n\tv216 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v184 @ stack_-70_v3 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv232 = v216 == 0;\n\tif (v232) goto L_0085;\n\tgoto L_0067;\nL_0067:\n\tv203 = UnityEngine.Object::op_Inequality(v73.Current, 0);\n\tv207 = v203 == 0;\n\tif (v207) goto L_0059;\n\tgoto L_0072;\nL_0072:\n\tv336 = UnityEngine.Application::get_isPlaying();\n\tv339 = v336 == 0;\n\tif (v339) goto L_0053;\n\tgoto L_007F;\nL_007F:\n\tUnityEngine.Object::Destroy(v73.Current);\n\tgoto L_0059;\nL_0085:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v184 @ stack_-70_v3 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv72 = 0;\n\tv147 = Il2CppMethodInfo;\nL_0086:\n\tv170 = this._linkVisuals;\n\tv166 = this._linkVisuals == 0;\n\tif (v166) goto L_00B4;\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Clear(v170);\n\tv79 = v170.Count < 1;\n\tif (v79) goto L_009F;\n\tv147 = 0;\nL_009F:\n\tv167 = this._capObjects == 0;\n\tif (v167) goto L_00B4;\n\tv147 = *([v153 @ X22_v1 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::Clear(this._capObjects);\n\tv168 = this._ropeObjects == 0;\n\tif (v168) goto L_00B4;\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::Clear(this._ropeObjects);\n\treturn;\nL_00B4:\n\tv173 = new System.NullReferenceException();\n\tgoto L_00C5;\nL_00C5:\n\tv227 = v147 != 1;\n\tv243 = v173;\n\tif (v227) goto L_00D5;\n\tv234 = 0x8BF5BC4(v173, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv256 = 0x8BF5BF4(v234, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv147 = *([v149 @ X23_v1 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v184 @ stack_-70_v3 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv242 = *([v234 @ X0_v12]) == 0;\n\tv72 = *([v234 @ X0_v12]);\n\tif (v242) goto L_0086;\n\tv240 = new System.OutOfMemoryException();\n\tv72 = *([v234 @ X0_v12]);\n\tv243 = v240;\n\treturn;\nL_0031:\n\tv52 = this._linkVisuals == 0;\n\tif (v52) goto L_00B4;\nL_00D5:\n\tv246 = 0x31776C4(&v72 @ stack_-88 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv258 = 0x8BF0368(v243, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv268 = 0xA1B8(v258, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualController::Cleanup");
		}

		[Token(Token = "0x6000BCD")]
		[Address(RVA = "0x3ECB1CC", Offset = "0x3ECB1CC", Length = "0x4B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tv79 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv241 = *([v79 @ X0_v25 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv300 = *([v241 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv243 = *([v241 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v243) goto L_0072;\n\tv299 = *([v241 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv299 = v299 + 0x10;\n\tv272 = v300 - 1;\n\tv252 = v300 != 1;\nL_FFFFFFFF:\n\tv300 = v272;\n\tif (v252) goto L_005D;\nL_0072:\n\tv275 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v79, System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv275.partnerEntityId(v361, v79, *([v275 @ X0_v66 (_game.CoreSystem.New.MoldSystem.Core.Components.MoldLinkedComponent)+8]), 0, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv320 = v361 == 0;\n\tv321 = ~v320;\nL_FFFFFFFF:\n\tv519 = &v317 @ stack_-68_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv346 = 0;\n\tif (v321) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv346 = 0;\n\tgoto L_018D;\nL_0081:\n\tv331 = *([v299 @ X10_v30]) << 4;\n\tv332 = v241 + v331;\n\tv333 = v332 + 0x138;\n\tv217 = *([v333 @ X8_v43+8]);\n\t*([v333 @ X8_v43])(v361, v79, *([v333 @ X8_v43+8]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv342 = v361 == 0;\nL_FFFFFFFF:\n\tv519 = &v317 @ stack_-68_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv346 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv346 = 0;\n\tif (v342) goto L_018D;\nL_FFFFFFFF:\n\tv462 = v361;\n\tgoto L_00A2;\nL_009C:\n\tv434 = v317 == 0;\nL_FFFFFFFF:\n\tv462 = v317;\n\tif (v434) goto L_018D;\nL_00A2:\n\tgoto L_00C8;\n\tv600 = v317 == 0;\n\tif (v600) goto L_0191;\n\tgoto L_00F9;\n\tv830 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v827);\n\tgoto L_010A;\nL_010A:\n\tv839 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::get_IsValid(&v393 @ stack_-70_v10 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\tv841 = v839 == 0;\nL_FFFFFFFF:\n\tv217 = 0;\n\tif (v841) goto L_009C;\n\tgoto L_0116;\nL_0116:\n\tv601 = this._em == 0;\n\tif (v601) goto L_0193;\n\tv850 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v393);\n\tv854 = v850 == 0;\nL_FFFFFFFF:\n\tv217 = v393;\n\tif (v854) goto L_009C;\n\tv573 = v393 <= v827;\n\tif (v573) goto L_013B;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v569 @ stack_-88_v8 (System.ValueTuple`2<System.Int32, System.Int32>), v827, v393);\nL_FFFFFFFF:\n\t;\n\tgoto L_0141;\nL_013B:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v569 @ stack_-88_v8 (System.ValueTuple`2<System.Int32, System.Int32>), v393, v827);\nL_FFFFFFFF:\n\t;\nL_0141:\n\tv851 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Add(v62, v569);\n\tv855 = v851 == 0;\nL_FFFFFFFF:\n\tv217 = v569;\n\tif (v855) goto L_009C;\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::CreateLinkPairInternal(this, v827, v393);\nL_FFFFFFFF:\n\tv217 = v827;\n\tgoto L_009C;\nL_014B:\n\tv556 = &v317 @ stack_-68_v10 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv553 = *([v556 @ X8_v26]);\n\tv551 = *([v556 @ X8_v26]) == 0;\nL_FFFFFFFF:\n\tv558 = 0;\nL_FFFFFFFF:\n\tv188 = v519;\nL_FFFFFFFF:\n\tv217 = 0;\nL_FFFFFFFF:\n\tv232 = 0;\n\tif (v551) goto L_017C;\nL_0155:\n\tgoto L_017B;\n\treturn;\nL_018D:\n\tv441 = new System.NullReferenceException();\n\tgoto L_0196;\nL_018F:\n\tv595 = new System.NullReferenceException();\n\tgoto L_0196;\nL_0191:\n\tv596 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv217 = 0;\n\tgoto L_0196;\nL_0193:\n\tv597 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv217 = 0;\n\tgoto L_0196;\nL_0196:\n\t// 406 Interrupt\nL_0199:\n\tv234 = new System.OutOfMemoryException();\n\tgoto L_01B2;\nL_01B2:\n\tv285 = v217 != 1;\n\tif (v285) goto L_01C0;\n\tv322 = 0x8BF5BC4(v234, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv558 = *([v322 @ X0_v16]);\n\tv380 = 0x8BF5BF4(v322, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv553 = *([v188 @ stack_-78_v1]);\n\tv471 = *([v188 @ stack_-78_v1]) == 0;\n\tv472 = ~v471;\nL_FFFFFFFF:\n\tv346 = *([v322 @ X0_v16]);\n\tif (v472) goto L_0155;\nL_FFFFFFFF:\n\tv188 = v188;\nL_FFFFFFFF:\n\tv346 = *([v322 @ X0_v16]);\nL_FFFFFFFF:\n\tv232 = *([v322 @ X0_v16]);\n\tgoto L_017C;\nL_01C0:\n\tv325 = 0x3175484(&v346 @ stack_-80_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv382 = 0x8BF0368(v234, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv473 = 0xA1B8(v382, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0042:\n\tv62 = new System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v62);\n\tthrow System.NullReferenceException;\nL_005D:\n\tv305 = *([v299 @ X10_v30-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v305) goto L_0081;\nL_00C8:\n\tv549 = System.Collections.IEnumerator::MoveNext(v462);\n\tv735 = v549 == 0;\n\tif (v735) goto L_014B;\nL_00F9:\n\tv827 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v317);\n\tv599 = this._em == 0;\n\tif (v599) goto L_018F;\nL_017C:\n\tv648 = v232 == 0;\n\tv222 = ~v648;\nL_FFFFFFFF:\n\tv519 = v188;\n\tif (v222) goto L_0199;\nL_017B:\n\tSystem.IDisposable::Dispose(v553);\nL_FFFFFFFF:\n\tv188 = v519;\nL_FFFFFFFF:\n\tv217 = 0;\nL_FFFFFFFF:\n\tv232 = v558;\n")]
		internal void CreateLinkVisuals()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualController::CreateLinkVisuals");
		}

		[Token(Token = "0x6000BCE")]
		[Address(RVA = "0x3ECBB10", Offset = "0x3ECBB10", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, a);\n\tv97 = ~v51;\n\tif (v97) goto L_005B;\n\tv118 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, b);\n\tv122 = ~v118;\n\tif (v122) goto L_005B;\n\tv59 = a >= b;\n\tif (v59) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv85 = b;\nL_FFFFFFFF:\n\tv170 = a;\nL_FFFFFFFF:\n\tv171 = &v159 @ stack_-38_v7 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_0043;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv85 = a;\nL_FFFFFFFF:\n\tv170 = b;\nL_FFFFFFFF:\n\tv171 = &v159 @ stack_-38_v7 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tv119 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::ContainsKey(this._ropeObjects, v159);\n\tv174 = v119 == 0;\n\tv121 = ~v174;\n\tif (v121) goto L_005B;\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::CreateLinkPairInternal(this, a, b);\nL_005B:\n\treturn;\nL_0043:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(v171, v170, v85);\n")]
		public unsafe void CreateLinkPair_Editor(Entity a, Entity b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualController::CreateLinkPair_Editor");
		}

		[Token(Token = "0x6000BCF")]
		[Address(RVA = "0x3ECB680", Offset = "0x3ECB680", Length = "0x490")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\nL_FFFFFFFF:\n\tv97 = partner;\nL_FFFFFFFF:\n\tv98 = entity;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv101 = &v85 @ stack_-98_v9 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_0058;\nL_FFFFFFFF:\n\tv97 = entity;\nL_FFFFFFFF:\n\tv98 = partner;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv101 = &v85 @ stack_-98_v9 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tv129 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::TryGetValue(this._capObjects, entity, &v127 @ stack_-88_v3 (UnityEngine.GameObject));\n\tv218 = v129 == 0;\n\tv198 = ~v218;\n\tv195 = ~v198;\n\tif (v195) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv191 = v127;\n\tgoto L_0084;\nL_FFFFFFFF:\n\tv191 = 0;\nL_0084:\n\tv408 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::TryGetValue(this._capObjects, partner, &v183 @ stack_-90_v3 (UnityEngine.GameObject));\n\tv216 = v408 == 0;\n\tv197 = ~v216;\n\tv194 = ~v197;\n\tif (v194) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv413 = v183;\n\tgoto L_0099;\nL_FFFFFFFF:\n\tv413 = 0;\nL_009D:\n\tv420 = UnityEngine.Object::op_Equality(v191, 0);\n\tv423 = v420 == 0;\n\tif (v423) goto L_00AE;\n\tgoto L_0186;\nL_00AE:\n\tgoto L_00B2;\nL_00B2:\n\tv454 = UnityEngine.Object::op_Equality(v413, 0);\n\tv456 = v454 == 0;\n\tif (v456) goto L_00C1;\n\tgoto L_0186;\nL_00C1:\n\tv468 = _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::GetCapAnchor(v191);\n\tv472 = _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::GetCapAnchor(v413);\n\tv474 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv475 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, partner);\n\tv172 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v474);\n\tv173 = _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController::GridToWorld(this._visualGrid, v475);\n\tv261 = entity;\n\tv188 = 0xB7D5000 + 0x538;\n\tv481 = \"il2cpp_vm_object_box\"(*([v188 @ X25_v10 (System.Int32)+48]), &v261 @ stack_-98_v4 (_game.BaseLayerSystems.EntitySystem.Core.Entity), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v173, v173.y, v173.z, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv153 = partner;\n\tv485 = \"il2cpp_vm_object_box\"(*([v188 @ X25_v10 (System.Int32)+48]), &v153 @ stack_-9C_v3 (_game.BaseLayerSystems.EntitySystem.Core.Entity), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv491 = System.String::Format(\"LinkRope_{0}_{1}\", v481, v485);\n\tv267 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v267, v491);\n\tUnityEngine.Object::set_hideFlags(v267, 0x34);\n\tv498 = UnityEngine.GameObject::get_transform(v267);\n\tv268 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v498, v268, 0);\n\tv269 = UnityEngine.GameObject::get_transform(v267);\n\tv503 = v172 + v173;\n\tv174 = v503 * 0.5f;\n\tv505 = v172.y + v173.y;\n\tv169 = v505 * 0.5f;\n\t// 295 MakeStruct v150 @ AGG3ECB9F4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v174 @ V0_v6 (System.Single), v169 @ V1_v6 (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(v269, v150);\n\tv511 = UnityEngine.GameObject::AddComponent(v267);\n\tv516 = UnityEngine.GameObject::AddComponent(v267);\n\tv270 = UnityEngine.GameObject::AddComponent(v267);\n\tv291 = this.m_visualConfig;\n\t_game.CoreSystem.MoldSystem.MoldLinkRope::Initialize(v270, v468, v472, v291.ropeMaterial, v291.ropeSag, v291.ropeRadius, v291.ropeSegments, v291.ropeRadialSegments);\n\tv271 = this._linkVisuals;\n\tgoto L_016B;\nL_016B:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(v271, v267);\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::set_Item(this._ropeObjects, v85, v267);\nL_0186:\n\treturn;\nL_004B:\n\tv78 = entity >= partner;\n\tif (v78) goto L_FFFFFFFF;\nL_0058:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(v101, v98, v97);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::CreateCap(this, entity, entity);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::CreateCap(this, partner, partner);\nL_0099:\n\tgoto L_009D;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void CreateLinkPairInternal(Entity entity, Entity partner)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualController::CreateLinkPairInternal");
		}

		[Token(Token = "0x6000BD0")]
		[Address(RVA = "0x3ECBC1C", Offset = "0x3ECBC1C", Length = "0x32C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\nL_002E:\n\tv58 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::ContainsKey(this._capObjects, entityId);\n\tv131 = v58 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_004D;\n\tv110 = this.m_visualConfig;\n\tgoto L_0040;\nL_0040:\n\tv144 = UnityEngine.Object::op_Equality(v110.linkCapPrefab, 0);\n\tv147 = v144 == 0;\n\tif (v147) goto L_0059;\nL_004D:\n\treturn;\nL_0059:\n\tv253 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tv256 = v253 == 0;\n\tif (v256) goto L_FFFFFFFF;\n\tv258 = UnityEngine.Component::get_gameObject(v253);\nL_FFFFFFFF:\n\tv123 = v258;\n\tgoto L_0066;\nL_0066:\n\tv282 = UnityEngine.Object::op_Inequality(v123, 0);\n\tv288 = v282 == 0;\n\tif (v288) goto L_0081;\n\tv95 = UnityEngine.GameObject::get_transform(v123);\n\tgoto L_0083;\nL_FFFFFFFF:\n\tv123 = 0;\n\tgoto L_0066;\nL_0081:\n\tv95 = UnityEngine.Component::get_transform(this);\nL_0083:\n\tv112 = this.m_visualConfig;\n\tgoto L_0094;\n\tv96 = System.String::Format(\"LinkCap_{0}\", v327);\n\tUnityEngine.Object::set_name(v321, v96);\n\tv99 = UnityEngine.GameObject::get_transform(v321);\n\tgoto L_00C5;\nL_00C5:\n\t// 197 MakeStruct v63 @ AGG3ECBE8C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v114.zero (UnityEngine.Vector3), v114.zero.y (System.Single), v114.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v99, v63);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::set_Item(this._capObjects, entityId, v321);\n\tv98 = this._linkVisuals;\n\tgoto L_00FE;\nL_00FE:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(v98, v321);\n\treturn;\nL_0094:\n\tv321 = UnityEngine.Object::Instantiate(v112.linkCapPrefab, v95);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::ApplyEditorHideFlags(v321);\n\tv72 = entityId;\n\tv324 = 0xB7D5000 + 0x538;\n\tv327 = \"il2cpp_vm_object_box\"(*([v324 @ X8_v15 (System.Int32)+48]), &v72 @ stack_-44_v2 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreateCap(Entity entity, int entityId)
		{
			if (_capObjects.ContainsKey(entityId))
			{
				return;
			}
			MoldLinkVisualConfig visualConfig = m_visualConfig;
			if (!(visualConfig.linkCapPrefab == null))
			{
				EntityMono monoBinding = entity.GetMonoBinding();
				GameObject gameObject2;
				if ((object)monoBinding != null)
				{
					GameObject gameObject = monoBinding.gameObject;
					gameObject2 = gameObject;
				}
				else
				{
					gameObject2 = null;
				}
				Transform parent = ((!(gameObject2 != null)) ? base.transform : gameObject2.transform);
				MoldLinkVisualConfig visualConfig2 = m_visualConfig;
				GameObject gameObject3 = UnityEngine.Object.Instantiate(visualConfig2.linkCapPrefab, parent);
				VisualHandlerUtility.ApplyEditorHideFlags(gameObject3);
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				string text = $"LinkCap_{arg}";
				gameObject3.name = text;
				Transform transform = gameObject3.transform;
				Vector3 localPosition = default(Vector3);
				localPosition.x = Vector3.zero.x;
				localPosition.y = Vector3.zero.y;
				localPosition.z = Vector3.zero.z;
				transform.localPosition = localPosition;
				_capObjects[entityId] = gameObject3;
				List<GameObject> linkVisuals = _linkVisuals;
				linkVisuals.Add(gameObject3);
			}
		}

		[Token(Token = "0x6000BD1")]
		[Address(RVA = "0x3ECBF48", Offset = "0x3ECBF48", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.GameObject::get_transform(capGo);\n\tv69 = UnityEngine.Transform::get_childCount(v14);\n\treturnVal2 = UnityEngine.GameObject::get_transform(capGo);\n\tv17 = v69 < 1;\n\tif (v17) goto L_002F;\n\treturnVal3 = UnityEngine.Transform::GetChild(returnVal2, 0);\n\treturn returnVal3;\nL_002F:\n\treturn returnVal2;\n")]
		private static Transform GetCapAnchor(GameObject capGo)
		{
			Transform transform = capGo.transform;
			int childCount = transform.childCount;
			Transform transform2 = capGo.transform;
			if (childCount >= 1)
			{
				return transform2.GetChild(0);
			}
			return transform2;
		}

		[Token(Token = "0x6000BD2")]
		[Address(RVA = "0x3ECBFB0", Offset = "0x3ECBFB0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::SpawnConnectedVfx(this, entityIdA);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::SpawnConnectedVfx(this, entityIdB);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::RemoveLinkVisuals(this, entityIdA, entityIdB);\n\treturn;\n")]
		public void BreakLinkInstant(int entityIdA, int entityIdB)
		{
			SpawnConnectedVfx(entityIdA);
			SpawnConnectedVfx(entityIdB);
			RemoveLinkVisuals(entityIdA, entityIdB);
		}

		[Token(Token = "0x6000BD3")]
		[Address(RVA = "0x3ECC458", Offset = "0x3ECC458", Length = "0x524")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv63.<>4__this = this;\n\tv63.capturedA = entityIdA;\n\tv63.capturedB = entityIdB;\n\tv161 = entityIdA >= entityIdB;\n\tif (v161) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv348 = entityIdB;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv350 = entityIdA;\nL_FFFFFFFF:\n\tv351 = &v270 @ stack_-90_v6 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv348 = entityIdA;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv350 = entityIdB;\nL_FFFFFFFF:\n\tv351 = &v270 @ stack_-90_v6 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tv365 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv367 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::TryGetValue(this._capObjects, entityIdA, &v122 @ stack_-68_v3 (UnityEngine.GameObject));\n\tv194 = v367 == 0;\n\tv164 = ~v194;\n\tv120 = ~v164;\n\tif (v120) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv113 = v122;\n\tgoto L_009A;\nL_FFFFFFFF:\n\tv113 = 0;\nL_009A:\n\tv374 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::TryGetValue(this._capObjects, entityIdB, &v109 @ stack_-70_v3 (UnityEngine.GameObject));\n\tv192 = v374 == 0;\n\tv162 = ~v192;\n\tv118 = ~v162;\n\tif (v118) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv251 = v109;\n\tgoto L_00AF;\nL_FFFFFFFF:\n\tv251 = 0;\nL_00B3:\n\tv384 = UnityEngine.Object::op_Inequality(v113, 0);\n\tv387 = ~v384;\n\tv388 = ~v387;\nL_FFFFFFFF:\n\tv255 = v384;\n\tif (v388) goto L_00D1;\n\tv115 = v255 ^ 1;\nL_FFFFFFFF:\n\tv423 = v365;\n\tgoto L_00C0;\nL_00C0:\n\tv445 = UnityEngine.Object::op_Inequality(v251, 0);\n\tv469 = ~v445;\n\tv470 = ~v469;\n\tif (v470) goto L_010B;\n\tgoto L_0141;\nL_00D1:\n\tv487 = UnityEngine.GameObject::get_transform(v113);\n\tgoto L_00F1;\nL_010B:\n\tv548 = UnityEngine.GameObject::get_transform(v251);\n\tgoto L_012B;\n\tv566 = PrimeTween.Sequence::Group(&v423 @ stack_-60_v15 (PrimeTween.Sequence), v558);\n\tgoto L_FFFFFFFF;\nL_0137:\n\tv567 = PrimeTween.Sequence::Chain(&v423 @ stack_-60_v15 (PrimeTween.Sequence), v558);\nL_FFFFFFFF:\n\tv115 = 0;\nL_0141:\n\tv533 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::TryGetValue(this._ropeObjects, v270, &v107 @ stack_-78_v3 (UnityEngine.GameObject));\n\tv193 = v533 == 0;\n\tv163 = ~v193;\n\tv119 = ~v163;\n\tif (v119) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv248 = v107;\n\tgoto L_0156;\nL_FFFFFFFF:\n\tv248 = 0;\nL_015A:\n\tv571 = UnityEngine.Object::op_Inequality(v248, 0);\n\tv573 = ~v571;\n\tif (v573) goto L_0182;\n\tv590 = UnityEngine.GameObject::GetComponent(v248);\n\tgoto L_016C;\nL_016C:\n\tv615 = UnityEngine.Object::op_Inequality(v590, 0);\n\tv639 = ~v615;\n\tif (v639) goto L_019A;\n\tv627 = _game.CoreSystem.MoldSystem.MoldLinkRope::Disappear(v590);\n\tv618 = v627;\n\tv633 = 0xB2DE000 + 0x620;\nL_FFFFFFFF:\n\tv630 = &v618 @ stack_-88_v3 (PrimeTween.Sequence);\n\tgoto L_019E;\nL_0182:\n\tv584 = v115 == 0;\n\tif (v584) goto L_FFFFFFFF;\n\tv599 = PrimeTween.Sequence::ChainDelay(&v423 @ stack_-60_v15 (PrimeTween.Sequence), 0.3f);\nL_FFFFFFFF:\n\tv630 = &v423 @ stack_-60_v15 (PrimeTween.Sequence);\n\tgoto L_018E;\nL_FFFFFFFF:\n\tv630 = &v423 @ stack_-60_v15 (PrimeTween.Sequence);\nL_019A:\n\tv633 = 0xB2DE000 + 0x618;\nL_FFFFFFFF:\n\tv630 = &v423 @ stack_-60_v15 (PrimeTween.Sequence);\n\treturn v365;\nL_003F:\n\tv63 = new _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v63);\nL_0067:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(v351, v350, v348);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::SpawnConnectedVfx(this, entityIdA);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::SpawnConnectedVfx(this, entityIdB);\nL_00AF:\n\tgoto L_00B3;\nL_00F1:\n\t// 241 MakeStruct v406 @ AGG3ECC714_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v494.zero (UnityEngine.Vector3), v494.zero.y (System.Single), v494.zero.z (System.Single)\n\tv500 = PrimeTween.Tween::Scale(v487, v406, 0.3f, 0x1A, 1, 0, 0f, 0f, 0);\n\tv528 = PrimeTween.Sequence::Chain(&v423 @ stack_-60_v15 (PrimeTween.Sequence), v500);\n\tv115 = v384 ^ 1;\nL_FFFFFFFF:\n\tv255 = v384;\n\tgoto L_00C0;\nL_012B:\n\t// 299 MakeStruct v501 @ AGG3ECC7D8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v553.zero (UnityEngine.Vector3), v553.zero.y (System.Single), v553.zero.z (System.Single)\n\tv558 = PrimeTween.Tween::Scale(v548, v501, 0.3f, 0x1A, 1, 0, 0f, 0f, 0);\n\tv519 = v255 == 0;\n\tif (v519) goto L_0137;\nL_0156:\n\tgoto L_015A;\nL_019E:\n\tv638 = new System.Action();\n\tSystem.Action::.ctor(v638, v63, *([v633 @ X22_v4 (System.Int32)]));\n\tv654 = PrimeTween.Sequence::ChainCallback(v630, v638, 1);\nL_018E:\n\tv633 = 0xB2DE000 + 0x610;\n\tgoto L_019E;\n")]
		public unsafe Sequence PlayLinkDisappear(int entityIdA, int entityIdB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualController::PlayLinkDisappear");
			return default;
		}

		[Token(Token = "0x6000BD4")]
		[Address(RVA = "0x3ECBFF8", Offset = "0x3ECBFF8", Length = "0x2B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tgoto L_001E;\nL_001E:\n\tv67 = UnityEngine.Application::get_isPlaying();\n\tv75 = ~v67;\n\tv76 = ~v75;\n\tif (v76) goto L_003B;\n\tgoto L_0089;\nL_003B:\n\tv86 = this.m_visualConfig;\n\tv87 = this.m_visualConfig == 0;\n\tif (v87) goto L_0089;\n\tgoto L_0048;\nL_0048:\n\tv103 = UnityEngine.Object::op_Equality(v86.connectedVfxPrefab, 0);\n\tv108 = v103 == 0;\n\tif (v108) goto L_005B;\n\tgoto L_0089;\nL_005B:\n\tv250 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetEntityByIndex(this._em, entityId);\n\tv105 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v250);\n\tv110 = ~v105;\n\tif (v110) goto L_0089;\n\tv266 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v250);\n\tv267 = v266 == 0;\n\tif (v267) goto L_FFFFFFFF;\n\tv269 = UnityEngine.Component::get_gameObject(v266);\nL_FFFFFFFF:\n\tv119 = v269;\n\tgoto L_0076;\nL_0076:\n\tv102 = UnityEngine.Object::op_Equality(v119, 0);\n\tv107 = v102 == 0;\n\tif (v107) goto L_008E;\nL_0089:\n\treturn;\nL_008E:\n\tv258 = UnityEngine.GameObject::get_transform(v119);\n\tv253 = UnityEngine.Transform::get_position(v258);\n\tv263 = this.m_visualConfig;\n\tv295 = v253 + v263.connectedVfxOffset;\n\tv296 = v253.y + v263.connectedVfxOffset.y;\n\tv297 = v253.z + v263.connectedVfxOffset.z;\n\tv301 = 0x3E74E78(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v253, v253.y, v253.z, v263.connectedVfxOffset, v263.connectedVfxOffset.y, v263.connectedVfxOffset.z, clobbered_V6, clobbered_V7);\n\tv308 = UnityEngine.Component::get_transform(this);\n\tv214 = this._vfxPool == 0;\n\tif (v214) goto L_00EC;\n\tv210 = 0x318FE08(0, _game.CoreSystem.Pooling.IVfxPool, this._vfxPool, v263.connectedVfxPrefab, v308, clobbered_X5, clobbered_X6, clobbered_X7, v295, v296, v297, v253, v253.y, v253.z, v263.connectedVfxOffset, clobbered_V7);\n\treturn;\nL_FFFFFFFF:\n\tv119 = 0;\n\tgoto L_0076;\nL_00EC:\n\t// 236 MakeStruct v145 @ AGG3ECC2A4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v295 @ V10_v2 (System.Single), v296 @ V9_v2 (System.Single), v297 @ V8_v2 (System.Single)\n\t// 237 MakeStruct v142 @ AGG3ECC2A4_2_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v253 @ V0_v2 (UnityEngine.Vector3), v253.y (System.Single), v253.z (System.Single), v263.connectedVfxOffset (UnityEngine.Vector3)\n\tv211 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(v263.connectedVfxPrefab, v145, v142, v308);\n\treturn;\n")]
		private void SpawnConnectedVfx(int entityId)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			MoldLinkVisualConfig visualConfig = m_visualConfig;
			if (m_visualConfig == null || visualConfig.connectedVfxPrefab == null)
			{
				return;
			}
			Entity entityByIndex = _em.GetEntityByIndex(entityId);
			if (!_em.IsValid(entityByIndex))
			{
				return;
			}
			EntityMono monoBinding = entityByIndex.GetMonoBinding();
			GameObject gameObject2;
			if ((object)monoBinding != null)
			{
				GameObject gameObject = monoBinding.gameObject;
				gameObject2 = gameObject;
			}
			else
			{
				gameObject2 = null;
			}
			if (!(gameObject2 == null))
			{
				Transform transform = gameObject2.transform;
				Vector3 position = transform.position;
				MoldLinkVisualConfig visualConfig2 = m_visualConfig;
				float x = position.x + visualConfig2.connectedVfxOffset.x;
				float y = position.y + visualConfig2.connectedVfxOffset.y;
				float z = position.z + visualConfig2.connectedVfxOffset.z;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E74E78 (inside _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ScatterPiece +0x3E0)");
				Transform parent = base.transform;
				if (_vfxPool != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @318FE08");
					return;
				}
				Vector3 position2 = default(Vector3);
				position2.x = x;
				position2.y = y;
				position2.z = z;
				Quaternion rotation = default(Quaternion);
				rotation.x = position.x;
				rotation.y = position.y;
				rotation.z = position.z;
				rotation.w = visualConfig2.connectedVfxOffset.x;
				GameObject gameObject3 = VisualHandlerUtility.Instantiate(visualConfig2.connectedVfxPrefab, position2, rotation, parent);
			}
		}

		[Token(Token = "0x6000BD5")]
		[Address(RVA = "0x3ECC2AC", Offset = "0x3ECC2AC", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_FFFFFFFF:\n\tv85 = entityIdB;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv89 = &v74 @ stack_-40_v5 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_0041;\nL_FFFFFFFF:\n\tv85 = v88;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv89 = &v74 @ stack_-40_v5 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tv99 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::TryGetValue(this._ropeObjects, v74, &v97 @ stack_-38_v3 (UnityEngine.Object));\n\tv123 = ~v99;\n\tif (v123) goto L_0085;\n\tgoto L_0058;\nL_0058:\n\tv160 = UnityEngine.Object::op_Inequality(v97, 0);\n\tv162 = ~v160;\n\tv163 = ~v162;\n\tif (v163) goto L_006B;\n\tgoto L_007D;\nL_006B:\n\tv182 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(this._linkVisuals, v97);\n\tgoto L_0075;\nL_0075:\n\tUnityEngine.Object::Destroy(v97);\nL_007D:\n\tv132 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::Remove(this._ropeObjects, v74);\nL_0085:\n\treturn;\nL_0027:\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::RemoveCap(this, v88);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::RemoveCap(this, entityIdB);\n\tv67 = v88 >= entityIdB;\n\tif (v67) goto L_FFFFFFFF;\nL_0041:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(v89, entityIdB, v85);\n")]
		private unsafe void RemoveLinkVisuals(int entityIdA, int entityIdB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualController::RemoveLinkVisuals");
		}

		[Token(Token = "0x6000BD6")]
		[Address(RVA = "0x3ECCAC4", Offset = "0x3ECCAC4", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_FFFFFFFF:\n\tv85 = entityIdB;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv89 = &v74 @ stack_-40_v5 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_0041;\nL_FFFFFFFF:\n\tv85 = v88;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv89 = &v74 @ stack_-40_v5 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tv99 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::TryGetValue(this._ropeObjects, v74, &v97 @ stack_-38_v3 (UnityEngine.Object));\n\tv123 = ~v99;\n\tif (v123) goto L_0085;\n\tgoto L_0058;\nL_0058:\n\tv160 = UnityEngine.Object::op_Inequality(v97, 0);\n\tv162 = ~v160;\n\tv163 = ~v162;\n\tif (v163) goto L_006B;\n\tgoto L_007D;\nL_006B:\n\tv182 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(this._linkVisuals, v97);\n\tgoto L_0075;\nL_0075:\n\tUnityEngine.Object::DestroyImmediate(v97);\nL_007D:\n\tv132 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::Remove(this._ropeObjects, v74);\nL_0085:\n\treturn;\nL_0027:\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::RemoveCap_Editor(this, v88);\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::RemoveCap_Editor(this, entityIdB);\n\tv67 = v88 >= entityIdB;\n\tif (v67) goto L_FFFFFFFF;\nL_0041:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(v89, entityIdB, v85);\n")]
		public unsafe void RemoveLinkVisuals_Editor(int entityIdA, int entityIdB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkVisualController::RemoveLinkVisuals_Editor");
		}

		[Token(Token = "0x6000BD7")]
		[Address(RVA = "0x3ECC984", Offset = "0x3ECC984", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv56 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::TryGetValue(this._capObjects, entityId, &v54 @ stack_-38_v3 (UnityEngine.Object));\n\tv83 = ~v56;\n\tif (v83) goto L_0061;\n\tgoto L_0034;\nL_0034:\n\tv122 = UnityEngine.Object::op_Inequality(v54, 0);\n\tv124 = ~v122;\n\tv125 = ~v124;\n\tif (v125) goto L_0047;\n\tgoto L_0059;\nL_0047:\n\tv144 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(this._linkVisuals, v54);\n\tgoto L_0051;\nL_0051:\n\tUnityEngine.Object::Destroy(v54);\nL_0059:\n\tv95 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::Remove(this._capObjects, entityId);\nL_0061:\n\treturn;\n")]
		private unsafe void RemoveCap(int entityId)
		{
			UnityEngine.Object value;
			if (_capObjects.TryGetValue(entityId, out *(GameObject*)(&value)))
			{
				if (value != null)
				{
					bool flag = _linkVisuals.Remove((GameObject)value);
					UnityEngine.Object.Destroy(value);
				}
				bool flag2 = _capObjects.Remove(entityId);
			}
		}

		[Token(Token = "0x6000BD8")]
		[Address(RVA = "0x3ECCC70", Offset = "0x3ECCC70", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv56 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::TryGetValue(this._capObjects, entityId, &v54 @ stack_-38_v3 (UnityEngine.Object));\n\tv83 = ~v56;\n\tif (v83) goto L_0061;\n\tgoto L_0034;\nL_0034:\n\tv122 = UnityEngine.Object::op_Inequality(v54, 0);\n\tv124 = ~v122;\n\tv125 = ~v124;\n\tif (v125) goto L_0047;\n\tgoto L_0059;\nL_0047:\n\tv144 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(this._linkVisuals, v54);\n\tgoto L_0051;\nL_0051:\n\tUnityEngine.Object::DestroyImmediate(v54);\nL_0059:\n\tv95 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::Remove(this._capObjects, entityId);\nL_0061:\n\treturn;\n")]
		private unsafe void RemoveCap_Editor(int entityId)
		{
			UnityEngine.Object value;
			if (_capObjects.TryGetValue(entityId, out *(GameObject*)(&value)))
			{
				if (value != null)
				{
					bool flag = _linkVisuals.Remove((GameObject)value);
					UnityEngine.Object.DestroyImmediate(value);
				}
				bool flag2 = _capObjects.Remove(entityId);
			}
		}

		[Token(Token = "0x6000BD9")]
		[Address(RVA = "0x3ECCDB0", Offset = "0x3ECCDB0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController::Cleanup(this);\n\treturn;\n")]
		public void Dispose()
		{
			Cleanup();
		}

		[Token(Token = "0x6000BDA")]
		[Address(RVA = "0x3ECCDB4", Offset = "0x3ECCDB4", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv81 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>::.ctor(v81);\n\tthis._capObjects = v81;\n\tv94 = new System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>();\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, UnityEngine.GameObject>::.ctor(v94);\n\tthis._ropeObjects = v94;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0034:\n\tv64 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v64);\n\tthis._linkVisuals = v64;\n")]
		public MoldLinkVisualController()
		{
			List<GameObject> linkVisuals = new List<GameObject>();
			_linkVisuals = linkVisuals;
			_capObjects = new Dictionary<int, GameObject>();
			_ropeObjects = new Dictionary<(int, int), GameObject>();
		}
	}
}

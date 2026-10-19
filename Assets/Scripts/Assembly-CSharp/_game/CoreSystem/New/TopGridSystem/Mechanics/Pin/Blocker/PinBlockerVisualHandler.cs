using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HighlightPlus;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Shared.Blocker;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker
{
	[Token(Token = "0x20001BA")]
	public class PinBlockerVisualHandler : ITopGridVisualHandler
	{
		[Token(Token = "0x20001BB")]
		private readonly struct PathEntry
		{
			[Token(Token = "0x400056D")]
			[FieldOffset(Offset = "0x0")]
			public readonly Entity entity;

			[Token(Token = "0x400056E")]
			[FieldOffset(Offset = "0x8")]
			public readonly GridCoord coord;

			[Token(Token = "0x6000802")]
			[Address(RVA = "0x3E74EC8", Offset = "0x3E74EC8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.entity = entity;\n\tthis.coord = coord;\n\t*([this @ X0 (_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry)+10]) = coord.IsValid;\n\treturn;\n")]
			public PathEntry(Entity entity, GridCoord coord)
			{
				this.entity = entity;
				this.coord = coord;
				_ = coord.IsValid;
			}
		}

		[Inject(false)]
		[Token(Token = "0x4000565")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000566")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000567")]
		[FieldOffset(Offset = "0x20")]
		private PinBlockerConfig _config;

		[Token(Token = "0x4000568")]
		[FieldOffset(Offset = "0x28")]
		private Transform _parent;

		[Token(Token = "0x4000569")]
		[FieldOffset(Offset = "0x30")]
		private readonly Dictionary<int, Transform> _rootsByPinId;

		[Token(Token = "0x400056A")]
		[FieldOffset(Offset = "0x38")]
		private readonly Dictionary<Entity, GameObject> _visualByEntity;

		[Token(Token = "0x400056B")]
		[FieldOffset(Offset = "0x40")]
		private readonly Dictionary<int, List<GameObject>> _terminalsByPinId;

		[Token(Token = "0x400056C")]
		[FieldOffset(Offset = "0x48")]
		private readonly List<GameObject> _scatteredPieces;

		[Token(Token = "0x60007F0")]
		[Address(RVA = "0x3E719A0", Offset = "0x3E719A0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._parent = visualParent;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ResyncAll(this);\n\treturn;\n")]
		public void InitVisuals(Transform visualParent)
		{
			_parent = visualParent;
			ResyncAll();
		}

		[Token(Token = "0x60007F1")]
		[Address(RVA = "0x3E72304", Offset = "0x3E72304", Length = "0x3FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004A;\nL_004A:\n\tv341 = 0xB292000 + 0x5A0;\n\tv340 = 0xB28B000 + 0x5A8;\n\tv85 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::GetEnumerator(this._rootsByPinId);\n\tv225 = v85._dictionary;\n\tgoto L_0073;\nL_0070:\n\tUnityEngine.Object::DestroyImmediate(v499);\nL_0073:\n\tv302 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v225 @ stack_-90_v6 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>));\n\tv307 = v302 == 0;\n\tif (v307) goto L_00B0;\n\tgoto L_0081;\nL_0081:\n\tv287 = UnityEngine.Object::op_Equality(v352, 0);\n\tv395 = v287 == 0;\n\tv291 = ~v395;\n\tif (v291) goto L_0073;\n\tgoto L_008D;\nL_008D:\n\tv270 = UnityEngine.Application::get_isPlaying();\n\tv416 = v270 == 0;\n\tif (v416) goto L_00A5;\n\tv272 = v352 == 0;\n\tif (v272) goto L_0135;\n\tv496 = UnityEngine.Component::get_gameObject(v352);\n\tgoto L_009F;\nL_009F:\n\tUnityEngine.Object::Destroy(v496);\n\tgoto L_0073;\nL_00A5:\n\tv499 = UnityEngine.Component::get_gameObject(v352);\n\tgoto L_0070;\nL_00B0:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v225 @ stack_-90_v6 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>));\nL_00B5:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::Clear(this._rootsByPinId);\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::Clear(this._visualByEntity);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::Clear(this._terminalsByPinId);\n\tv521 = this._scatteredPieces;\n\tv523 = 0;\n\tgoto L_00D8;\nL_00C6:\n\tgoto L_00C9;\nL_00C9:\n\tUnityEngine.Object::DestroyImmediate(v527);\nL_00CA:\n\tv523 = v523 + 1;\n\tv521 = this._scatteredPieces;\nL_00D8:\n\tv92 = v523 >= v521.Count;\n\tif (v92) goto L_0113;\n\tv527 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v521, v523);\n\tv531 = *([v341 @ X22_v1 (System.Int32)]);\n\tv533 = *([v531 @ X0_v28+E4]) == 0;\n\tif (v533) goto L_00EF;\n\tv540 = UnityEngine.Object::op_Equality(v527, 0);\n\tv543 = v540 == 0;\n\tv544 = ~v543;\n\tif (v544) goto L_00CA;\n\tgoto L_00F4;\nL_00EF:\n\tv548 = UnityEngine.Object::op_Equality(v527, 0);\n\tv564 = v548 == 0;\n\tv559 = ~v564;\n\tif (v559) goto L_00CA;\nL_00F4:\n\tv568 = *([v340 @ X23_v1 (System.Int32)]);\n\tv570 = *([v568 @ X0_v30+E4]) == 0;\n\tif (v570) goto L_0102;\n\tv572 = UnityEngine.Application::get_isPlaying();\n\tv577 = ~v572;\n\tif (v577) goto L_00C6;\n\tgoto L_010A;\nL_0102:\n\tv579 = UnityEngine.Application::get_isPlaying();\n\tv584 = ~v579;\n\tif (v584) goto L_00C6;\nL_010A:\n\tgoto L_010E;\nL_010E:\n\tUnityEngine.Object::Destroy(v527);\n\tgoto L_00CA;\nL_0113:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Clear(v521);\n\tv425 = v521.Count < 1;\n\tif (v425) goto L_0133;\nL_0133:\n\treturn;\nL_0135:\n\tv277 = new System.NullReferenceException();\n\tv382 = 0;\n\tgoto L_0138;\nL_0138:\n\t// 312 Interrupt\n\tgoto L_014A;\nL_014A:\n\tv367 = 0 != 1;\n\tif (v367) goto L_0159;\n\tv381 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv396 = 0x8BF5BF4(v381, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v225 @ stack_-90_v6 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>));\n\tv379 = *([v381 @ X0_v10]) == 0;\n\tif (v379) goto L_00B5;\n\tv385 = new System.OutOfMemoryException();\n\tv382 = *([v381 @ X0_v10]);\nL_0159:\n\tv390 = 0x318E41C(&v382 @ stack_-B8_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv398 = 0x8BF0368(v385, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv405 = 0xA1B8(v398, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::Cleanup");
		}

		[Token(Token = "0x60007F2")]
		[Address(RVA = "0x3E72700", Offset = "0x3E72700", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ResyncAll(this);\n\treturn;\n")]
		public void SyncWithData(EntityManager oldData)
		{
			ResyncAll();
		}

		[Token(Token = "0x60007F3")]
		[Address(RVA = "0x3E719C8", Offset = "0x3E719C8", Length = "0x93C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0094;\nL_0097:\n\tv77 = UnityEngine.Object::op_Equality(this._config, 0);\n\tv85 = v77 == 0;\n\tif (v85) goto L_00AB;\n\tgoto L_02D3;\nL_00AB:\n\tgoto L_00AE;\nL_00AE:\n\tv254 = UnityEngine.Object::op_Equality(this._parent, 0);\n\tv259 = v254 == 0;\n\tif (v259) goto L_00C4;\n\tgoto L_02D3;\nL_00C4:\n\tv413 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::get_Keys(this._visualByEntity);\n\tv577 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v577, v413);\n\tv759 = v577.Count < 1;\n\tif (v759) goto L_00FD;\n\tv806 = 0;\nL_00FD:\n\tv817 = &v824 @ stack_-120_v8 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>);\n\tv818 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::GetEnumerator(this._terminalsByPinId);\n\tv824 = *([v817 @ X8_v35]);\n\tv454 = *([v817 @ X8_v35]);\n\tv489 = 0;\n\tv150 = 0xB28B000 + 0x5A8;\n\tv739 = v889 == 0;\n\tif (v739) goto L_02D9;\n\tv841 = v889.Count < 1;\n\tif (v841) goto L_011A;\n\tv928 = 0;\n\tgoto L_0145;\nL_0131:\n\tgoto L_0134;\nL_0134:\n\tUnityEngine.Object::DestroyImmediate(v938);\nL_0135:\n\tv928 = v928 + 1;\n\tv842 = v928 >= v889.Count;\n\tif (v842) goto L_011A;\nL_0145:\n\tv938 = System.Collections.Generic.List`1<System.Int32>::get_Item(v889, v928);\n\tgoto L_0150;\nL_0150:\n\tv957 = UnityEngine.Object::op_Equality(v938, 0);\n\tv968 = v957 == 0;\n\tv969 = ~v968;\n\tif (v969) goto L_0135;\n\tgoto L_015C;\nL_015C:\n\tv1058 = UnityEngine.Application::get_isPlaying();\n\tv1070 = v1058 == 0;\n\tif (v1070) goto L_0131;\n\tgoto L_0169;\nL_0169:\n\tUnityEngine.Object::Destroy(v938);\n\tgoto L_0135;\nL_0171:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v454 @ stack_-90_v7 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>));\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::Clear(this._terminalsByPinId);\n\tv580 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::CollectPinPaths(this);\n\tv961 = &v489 @ stack_-120_v9 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tv962 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>::GetEnumerator(v580);\n\tv824 = v489.Id;\n\tv1026 = *([v961 @ X8_v45+8]);\n\tv440 = v489.Id;\n\tv1028 = v489.Id;\n\tgoto L_01A0;\nL_019D:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::SpawnTerminals(this, *([v961 @ X8_v45+10]), v1071);\nL_01A0:\n\tv1049 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v440 @ stack_-C0_v7 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>));\n\tv1060 = v1049 == 0;\n\tif (v1060) goto L_01D9;\n\tv738 = v1071 == 0;\n\tif (v738) goto L_02D7;\n\tv1096 = *([v1071 @ stack_-A8 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>)+18]) < 1;\n\tif (v1096) goto L_019D;\n\tv1152 = 0;\n\tgoto L_019D;\nL_01D9:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v440 @ stack_-C0_v7 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>));\n\tv1100 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v1100);\n\tv1184 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::GetEnumerator(this._rootsByPinId);\n\tv631 = v1184._dictionary;\n\tgoto L_020A;\n\tgoto L_0219;\nL_0219:\n\tv1257 = UnityEngine.Object::op_Equality(v1247, 0);\n\tv1259 = v1257 == 0;\n\tv1260 = ~v1259;\n\tif (v1260) goto L_0226;\n\tv1222 = UnityEngine.Transform::get_childCount(v1247);\n\tv1265 = v1222 == 0;\n\tv1225 = ~v1265;\n\tif (v1225) goto L_020A;\nL_0226:\n\tv703 = v1100 == 0;\n\tv266 = v606;\n\tif (v703) goto L_02D5;\n\tv1264 = v1100._version + 1;\n\tv1100._version = v1264;\n\tv704 = v1100._items == 0;\n\tv665 = &v631 @ stack_-F0_v7 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>);\n\tv669 = 0;\n\tv266 = v1100;\n\tif (v704) goto L_02D5;\n\tgoto L_0241;\nL_0241:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(v1100, *([v1184 @ X0_v82 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>+Enumerator<System.Int32, UnityEngine.Transform>)+10]));\n\tgoto L_020A;\nL_0247:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v631 @ stack_-F0_v7 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>));\n\tv266 = v1100;\nL_0255:\n\tv203 = v266.Count < 1;\n\tif (v203) goto L_02D3;\n\tv554 = 0;\n\tv949 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::TryGetValue(this._rootsByPinId, v914, &v112 @ stack_-F8_v8 (UnityEngine.Object));\n\tv963 = ~v949;\n\tif (v963) goto L_02B7;\n\tgoto L_0273;\nL_0273:\n\tv995 = UnityEngine.Object::op_Inequality(v112, 0);\n\tv1061 = ~v995;\n\tv1000 = ~v1061;\n\tif (v1000) goto L_0281;\n\tgoto L_02B7;\nL_0281:\n\tv1078 = *([v150 @ X24_v6 (System.Int32)]);\n\tv1080 = *([v1078 @ X0_v36+E4]) == 0;\n\tif (v1080) goto L_029D;\n\tv1102 = UnityEngine.Application::get_isPlaying();\n\tv1139 = ~v1102;\n\tv583 = v112;\n\tv584 = v112;\n\tif (v1139) goto L_02A6;\nL_028E:\n\tv1186 = UnityEngine.Component::get_gameObject(v583);\n\tgoto L_0299;\nL_029D:\n\tv1141 = UnityEngine.Application::get_isPlaying();\n\tv1176 = ~v1141;\n\tv1173 = ~v1176;\n\tv583 = v112;\n\tv584 = v112;\n\tif (v1173) goto L_028E;\nL_02A6:\n\tv1188 = UnityEngine.Component::get_gameObject(v584);\n\tgoto L_02B1;\nL_02B7:\n\tv253 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::Remove(this._rootsByPinId, v914);\n\tv554 = v554 + 1;\n\tv201 = v554 < v266.Count;\n\tif (v201) goto L_0261;\nL_02D3:\n\treturn;\nL_02D5:\n\tv709 = new System.NullReferenceException();\n\tv1026 = &v631 @ stack_-F0_v7 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>);\n\tv1028 = 0;\n\tv728 = 0;\n\tv266 = v1100;\n\tgoto L_02DC;\nL_02D7:\n\tv732 = new System.NullReferenceException();\n\tv150 = v639;\n\tv1026 = v665;\n\tv1028 = v669;\n\tv728 = v698;\n\tv732 = v709;\n\tgoto L_02DC;\nL_02D9:\n\tv735 = new System.NullReferenceException();\n\tv728 = Il2CppMethodInfo;\n\tv266 = v1071;\n\tgoto L_02DC;\nL_02DC:\n\t// 732 Interrupt\n\tgoto L_02F2;\nL_02F2:\n\tv357 = v728 != 1;\n\tv375 = v732;\n\tif (v357) goto L_0304;\n\tv784 = 0x8BF5BC4(v732, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv820 = 0x8BF5BF4(v784, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(v1026);\n\tv790 = *([v784 @ X0_v16]) == 0;\n\tif (v790) goto L_0255;\n\tv789 = new System.OutOfMemoryException();\n\tv1028 = *([v784 @ X0_v16]);\n\tv375 = v789;\nL_0344:\n\tv834 = 0x8BF0368(v375, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv383 = 0xA1B8(v834, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0094:\n\tgoto L_0097;\nL_00E5:\n\tv813 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v577, v806);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::DestroyVisualFor(this, v81\n// ... truncated")]
		public unsafe void ResyncAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::ResyncAll");
		}

		[Token(Token = "0x60007F4")]
		[Address(RVA = "0x3E72D84", Offset = "0x3E72D84", Length = "0x504")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\nL_0047:\n\tv78 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, pin);\n\tv310 = ~v78;\n\tif (v310) goto L_01CC;\n\tv354 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, pin);\n\tv358 = ~v354;\n\tif (v358) goto L_01CC;\n\tv355 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, pin);\n\tv359 = ~v355;\n\tif (v359) goto L_01CC;\n\tv356 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::ContainsKey(this._visualByEntity, pin);\n\tv457 = v356 == 0;\n\tv360 = ~v457;\n\tif (v360) goto L_01CC;\n\tv459 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, pin);\n\tv464 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, pin);\n\tv467 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::GetOrCreateRoot(this, pinId);\n\tv469 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ExtractCoords(ordered);\n\tv243 = _game.CoreSystem.New.TopGridSystem.Shared.Blocker.PathSegmentClassifier::Classify(v469, index);\n\tv471 = pin & 1;\n\tv472 = v471 == 0;\n\tif (v472) goto L_00B8;\n\tv282 = this._config;\n\tv477 = v243.zRotationDeg / 0x43340000;\n\tv478 = UnityEngine.Mathf::Floor(v477);\n\tv480 = v478 * 0x43340000;\n\tv481 = v243.zRotationDeg - v480;\n\tv482 = v481 < 0x43340000;\n\tv483 = v481 == 0x43340000;\n\tv486 = v481 == v481;\n\tv489 = ~v486;\n\tv490 = v482 == v489;\n\tv491 = ~v483;\n\tv492 = v490 & v491;\n\tv493 = ~v492;\n\tif (v493) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv510 = 0x43340000;\n\tgoto L_00AD;\nL_FFFFFFFF:\n\tv510 = v481;\nL_FFFFFFFF:\n\tv511 = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv511 = v510;\nL_00B8:\n\tv178 = v243 == 2;\n\tif (v178) goto L_00D7;\n\tv177 = v243 == 1;\n\tif (v177) goto L_00D1;\n\tv494 = v243 == 0;\n\tv495 = ~v494;\n\tif (v495) goto L_FFFFFFFF;\n\tv283 = this._config;\nL_FFFFFFFF:\n\tv201 = v243.zRotationDeg;\nL_FFFFFFFF:\n\tv300 = v283.endpointPrefab;\n\tgoto L_00E5;\nL_00D1:\n\tv284 = this._config;\nL_FFFFFFFF:\n\tv201 = v243.zRotationDeg;\nL_FFFFFFFF:\n\tv300 = v284.straightPrefab;\n\tgoto L_00E5;\nL_00D7:\n\tv285 = this._config;\nL_FFFFFFFF:\n\tv201 = v243.zRotationDeg;\nL_FFFFFFFF:\n\tv300 = v285.cornerPrefab;\n\tgoto L_00E5;\nL_FFFFFFFF:\n\tv201 = v243.zRotationDeg;\nL_FFFFFFFF:\n\tv300 = 0;\nL_00EA:\n\tv526 = UnityEngine.Object::op_Inequality(v300, 0);\n\tv529 = ~v526;\n\tif (v529) goto L_00FF;\n\tgoto L_00F9;\nL_00F9:\n\tv244 = UnityEngine.Object::Instantiate(v300, v467);\n\tv541 = v244 == 0;\n\tv265 = ~v541;\nL_FFFFFFFF:\n\tv302 = v244;\n\tif (v265) goto L_011C;\n\tgoto L_01CD;\nL_00FF:\n\tv534 = pin & 1;\n\tv180 = v534 == 0;\n\tv149 = ~v180;\n\tv141 = ~v149;\n\tif (v141) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv542 = 0;\n\tgoto L_010D;\nL_FFFFFFFF:\n\tv542 = 3;\n\tv246 = UnityEngine.GameObject::get_transform(v245);\n\tUnityEngine.Transform::SetParent(v246, v467, 0);\nL_FFFFFFFF:\n\tv302 = v245;\nL_011C:\n\tUnityEngine.Object::set_hideFlags(v302, 0x34);\n\tv122 = pinId;\n\tv204 = 0xB7D5000 + 0x538;\n\tv564 = \"il2cpp_vm_object_box\"(*([v204 @ X28_v6 (System.Int32)+48]), &v122 @ stack_-94_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv119 = index;\n\tv567 = \"il2cpp_vm_object_box\"(*([v204 @ X28_v6 (System.Int32)+48]), &v119 @ stack_-98_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv572 = 0xB2F7000 + 0x760;\n\tv579 = 0xB2FA000 + 0x78;\n\tv576 = pin & 1;\n\tv181 = v576 == 0;\n\tv150 = ~v181;\n\tv142 = ~v150;\n\tif (v142) goto L_013F;\nL_FFFFFFFF:\n\tv579 = v572;\n\tgoto L_013F;\n\tv604 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v464);\nL_FFFFFFFF:\n\tv101 = v604.z;\nL_FFFFFFFF:\n\tv103 = v604.y;\nL_FFFFFFFF:\n\tv107 = v604;\n\tgoto L_0166;\nL_0162:\n\tv596 = v464 >> 0x20;\nL_FFFFFFFF:\n\tv101 = 0;\nL_FFFFFFFF:\n\tv103 = v596;\nL_FFFFFFFF:\n\tv107 = v464;\n\tv248 = UnityEngine.GameObject::get_transform(v302);\n\tv613 = v101 - v289.verticalOffset;\n\t// 371 MakeStruct v97 @ AGG3E73188_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v107 @ V8_v4, v103 @ V9_v4, v613 @ V2_v4 (System.Single)\n\tUnityEngine.Transform::set_position(v248, v97);\n\tv618 = UnityEngine.GameObject::get_transform(v302);\n\tv621 = v201 * 0x3C8EFA35;\n\t// 384 MakeStruct v94 @ AGG3E731B8_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v621 @ V2_v5 (System.Int32)\n\tv197 = UnityEngine.Quaternion::Internal_FromEulerRad(v94);\n\tUnityEngine.Transform::set_localRotation(v618, v197);\n\tv625 = v526 == 0;\n\tv626 = ~v625;\n\tif (v626) goto L_01B8;\n\tv627 = pin & 1;\n\tv628 = v627 == 0;\n\tif (v628) goto L_019D;\n\tv637 = UnityEngine.GameObject::get_transform(v302);\n\tv291 = this._config;\n\tv633 = v291.markerScale.y;\n\tv631 = v291.markerScale;\n\tgoto L_01AE;\nL_019D:\n\tv292 = this._config;\n\tv631 = v292.pieceScale;\n\tv637 = UnityEngine.GameObject::get_transform(v302);\n\t// 425 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv633 = v292.pieceScale.y * v197;\nL_01B8:\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::set_Item(this._visualByEntity, pin, v302);\nL_01CC:\n\treturn;\nL_01CD:\n\tthrow System.NullReferenceException;\nL_00AD:\n\tv503 = v243.zRotationDeg >= v480;\n\tif (v503) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv201 = v511;\nL_FFFFFFFF:\n\tv300 = v282.markerPrefab;\n\tgoto L_00E5;\nL_00E5:\n\tgoto L_00EA;\nL_010D:\n\tv245 = UnityEngine.GameObject::CreatePrimitive(v542);\nL_013F:\n\tv581 = System.String::Format(\"Pin_{0}_{1}_{2}\", v564, v567, *([v579 @ X8_v23 (System.Int32)]));\n\tUnityEngine.Object::set_name(v302, v581);\n\tgoto L_0150;\nL_0150:\n\tv593 = UnityEngine.Object::op_Inequality(this._visualGrid, 0);\n\tv595 = v593 == 0;\n\tif (v595) goto L_0162;\nL_0166:\n\tv289 = this._config;\nL_01AE:\n\t// 430 MakeStruct v629 @ AGG3E73234_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v631 @ V8_v6 (UnityEngine.Vector3), v633 @ V1_v9 (System.Single), v650 @ V1.S1\n\tUnityEngine.Transform::set_localScale(v637, v629);\n")]
		private void SpawnVisual(Entity pin, int pinId, IReadOnlyList<PathEntry> ordered, int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::SpawnVisual");
		}

		[Token(Token = "0x60007F5")]
		[Address(RVA = "0x3E73288", Offset = "0x3E73288", Length = "0x424")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tgoto L_0036;\nL_0036:\n\tv91 = UnityEngine.Object::op_Equality(v61.terminalPrefab, 0);\n\tv99 = v91 == 0;\n\tv337 = 0;\n\tif (v99) goto L_004B;\n\tgoto L_01B2;\nL_004B:\n\tv271 = ordered->klass;\n\tv307 = ordered->klass->interface_offsets_count;\n\tv263 = *([v271 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+12E]) == 0;\n\tif (v263) goto L_006D;\n\tv248 = *([v271 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+B0]) + 8;\n\tv248 = v248 + 0x10;\n\tv294 = v307 - 1;\n\tv276 = v307 != 1;\n\tv307 = v294;\n\tif (v276) goto L_0056;\nL_006D:\n\t;\n\tv260 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Count(ordered);\n\tv220 = v260 >= 2;\n\tv337 = 0;\n\tif (v220) goto L_0091;\n\tgoto L_01B2;\nL_007D:\n\tv218 = *([v248 @ X10_v36]) << 4;\n\tv320 = v271 + v218;\n\tv321 = v320 + 0x138;\n\t*([v321 @ X0_v52])(v261, ordered, *([v321 @ X0_v52+8]), v337, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv221 = v261 < 2;\n\tif (v221) goto L_01B2;\nL_0091:\n\tv343 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ExtractCoords(ordered);\n\tv347 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::GetOrCreateRoot(this, pinId);\n\tv351 = _game.CoreSystem.New.TopGridSystem.Shared.Blocker.PathSegmentClassifier::Classify(v343, 0);\n\tgoto L_00CB;\nL_01B2:\n\treturn;\nL_002A:\n\tv61 = this._config;\nL_0056:\n\tv312 = *([v248 @ X10_v36-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>;\n\tif (v312) goto L_007D;\nL_00CB:\n\tv436 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Item(ordered, 0);\n\tgoto L_00FA;\nL_00FA:\n\tv521 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Item(ordered, 1);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::SpawnTerminal(this, pinId, v347, v438, v438, v351.zRotationDeg, \"Head\");\n\tgoto L_0131;\nL_0131:\n\tv612 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Count(ordered);\n\tv614 = v612 - 1;\n\tv618 = _game.CoreSystem.New.TopGridSystem.Shared.Blocker.PathSegmentClassifier::Classify(v343, v614);\n\tgoto L_0166;\nL_0166:\n\tv700 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Item(ordered, v614);\n\tv210 = v612 - 2;\n\tgoto L_0196;\nL_0196:\n\tv767 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Item(ordered, v210);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::SpawnTerminal(this, pinId, v347, v438, v438, v618.zRotationDeg, \"Tail\");\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SpawnTerminals(int pinId, IReadOnlyList<PathEntry> ordered)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::SpawnTerminals");
		}

		[Token(Token = "0x60007F6")]
		[Address(RVA = "0x3E73D84", Offset = "0x3E73D84", Length = "0x3F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tgoto L_0031;\nL_0031:\n\tv94 = UnityEngine.Object::op_Inequality(this._visualGrid, 0);\n\tv105 = v94 == 0;\n\tif (v105) goto L_FFFFFFFF;\n\tv146 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, endpointCoord);\nL_FFFFFFFF:\n\tv174 = v146.z;\nL_FFFFFFFF:\n\tv177 = v146.y;\nL_FFFFFFFF:\n\tv180 = v146;\nL_FFFFFFFF:\n\tv289 = this._visualGrid;\n\tgoto L_007E;\nL_FFFFFFFF:\n\tv174 = 0;\nL_FFFFFFFF:\n\tv177 = endpointCoord.y;\nL_FFFFFFFF:\n\tv180 = endpointCoord;\nL_FFFFFFFF:\n\tv289 = this._visualGrid;\n\tgoto L_007E;\nL_007E:\n\tv294 = UnityEngine.Object::op_Inequality(v289, 0);\n\tv316 = v294 == 0;\nL_FFFFFFFF:\n\tv175 = v174;\nL_FFFFFFFF:\n\tv178 = v177;\nL_FFFFFFFF:\n\tv181 = v180;\n\tif (v316) goto L_FFFFFFFF;\n\tv447 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, neighborCoord);\nL_FFFFFFFF:\n\tv168 = v447.z;\nL_FFFFFFFF:\n\tv170 = v447.y;\nL_FFFFFFFF:\n\tv172 = v447;\nL_FFFFFFFF:\n\tv175 = v174;\nL_FFFFFFFF:\n\tv178 = v177;\nL_FFFFFFFF:\n\tv181 = v180;\n\tgoto L_009C;\nL_FFFFFFFF:\n\tv168 = 0;\nL_FFFFFFFF:\n\tv170 = neighborCoord.y;\nL_FFFFFFFF:\n\tv172 = neighborCoord;\n\tgoto L_00AE;\n\tUnityEngine.Object::set_hideFlags(v218, 0x34);\n\tv160 = pinId;\n\tv243 = 0xB7D5000 + 0x538;\n\tv475 = \"il2cpp_vm_object_box\"(*([v243 @ X8_v6 (System.Int32)+48]), &v160 @ stack_-AC_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv479 = System.String::Format(\"Pin_{0}_Terminal_{1}\", v475, suffix);\n\tUnityEngine.Object::set_name(v218, v479);\n\tv219 = UnityEngine.GameObject::get_transform(v218);\n\tv483 = v175 - v168;\n\tv484 = v181 - v172;\n\tv485 = v178 - v170;\n\tv486 = v175 + v483;\n\tv487 = v181 + v484;\n\tv488 = v178 + v485;\n\tv489 = v486 - v248.verticalOffset;\n\t// 211 MakeStruct v155 @ AGG3E7402C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v487 @ V0_v3, v488 @ V1_v3, v489 @ V2_v3 (System.Single)\n\tUnityEngine.Transform::set_position(v219, v155);\n\tv492 = UnityEngine.GameObject::get_transform(v218);\n\tv495 = zRotationDeg * 0x3C8EFA35;\n\t// 224 MakeStruct v152 @ AGG3E7405C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v495 @ V2_v4 (System.Single)\n\tv193 = UnityEngine.Quaternion::Internal_FromEulerRad(v152);\n\tUnityEngine.Transform::set_localRotation(v492, v193);\n\tv503 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::TryGetValue(this._terminalsByPinId, pinId, &v501 @ stack_-A8_v2 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv505 = v503 == 0;\n\tv506 = ~v505;\n\tif (v506) goto L_0112;\n\tv510 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v510);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::set_Item(this._terminalsByPinId, pinId, v510);\nL_0112:\n\t;\n\tgoto L_0130;\nL_0130:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(v510, v218);\n\treturn;\nL_009C:\n\tv248 = this._config;\nL_00AE:\n\tv218 = UnityEngine.Object::Instantiate(v248.terminalPrefab, root);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SpawnTerminal(int pinId, Transform root, GridCoord endpointCoord, GridCoord neighborCoord, float zRotationDeg, string suffix)
		{
			//IL_0091: Expected O, but got I4
			//IL_0064: Expected O, but got F4
			//IL_0153: Expected O, but got I4
			//IL_0118: Expected O, but got F4
			//IL_01f6: Expected O, but got I
			//IL_0205: Expected O, but got I
			//IL_0223: Expected O, but got I
			//IL_0232: Expected O, but got I
			//IL_0253: Expected F4, but got O
			//IL_0260: Expected F4, but got O
			float num;
			object obj;
			object obj2;
			UnityEngine.Object visualGrid;
			if (_visualGrid != null)
			{
				Vector3 vector = _visualGrid.GridToWorld(endpointCoord);
				num = vector.z;
				obj = vector.y;
				obj2 = vector;
				visualGrid = _visualGrid;
			}
			else
			{
				num = 0f;
				obj = endpointCoord.y;
				obj2 = endpointCoord;
				visualGrid = _visualGrid;
			}
			bool flag = visualGrid != null;
			bool flag2 = !flag;
			float num2 = num;
			object obj3 = obj;
			object obj4 = obj2;
			float num3;
			object obj5;
			object obj6;
			if (!flag2)
			{
				Vector3 vector2 = _visualGrid.GridToWorld(neighborCoord);
				num3 = vector2.z;
				obj5 = vector2.y;
				obj6 = vector2;
				num2 = num;
				obj3 = obj;
				obj4 = obj2;
			}
			else
			{
				num3 = 0f;
				obj5 = neighborCoord.y;
				obj6 = neighborCoord;
			}
			PinBlockerConfig config = _config;
			GameObject gameObject = UnityEngine.Object.Instantiate(config.terminalPrefab, root);
			gameObject.hideFlags = HideFlags.DontSave;
			int num4 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string name = $"Pin_{arg}_Terminal_{suffix}";
			gameObject.name = name;
			Transform transform = gameObject.transform;
			float num5 = num2 - num3;
			object obj7 = (nint)obj4 - (nint)obj6;
			object obj8 = (nint)obj3 - (nint)obj5;
			float num6 = num2 + num5;
			object obj9 = (nint)obj4 + (nint)obj7;
			object obj10 = (nint)obj3 + (nint)obj8;
			float z = num6 - config.verticalOffset;
			Vector3 position = default(Vector3);
			position.x = (float)obj9;
			position.y = (float)obj10;
			position.z = z;
			transform.position = position;
			Transform transform2 = gameObject.transform;
			float z2 = zRotationDeg * ((float)Math.PI / 180f);
			Vector3 vector3 = default(Vector3);
			vector3.x = 0f;
			vector3.y = 0f;
			vector3.z = z2;
			Quaternion localRotation = Quaternion.Euler(vector3 * 57.29578f);
			transform2.localRotation = localRotation;
			List<GameObject> list = default(List<GameObject>);
			if (!_terminalsByPinId.TryGetValue(pinId, out var _))
			{
				list = new List<GameObject>();
				_terminalsByPinId[pinId] = list;
			}
			list.Add(gameObject);
		}

		[Token(Token = "0x60007F7")]
		[Address(RVA = "0x3E74178", Offset = "0x3E74178", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv56.onComplete = onComplete;\n\tgoto L_003B;\nL_003B:\n\tv94 = UnityEngine.Object::op_Inequality(this._config, 0);\n\tv130 = ~v94;\nL_FFFFFFFF:\n\t;\n\tif (v130) goto L_FFFFFFFF;\n\tv84 = this._config;\nL_FFFFFFFF:\n\tv146 = v84.disappearSeconds;\nL_FFFFFFFF:\n\t;\n\tgoto L_0054;\nL_FFFFFFFF:\n\tv146 = 0x3E4CCCCD;\n\tv113 = PrimeTween.Tween::Delay(v146, v157, 0, 1);\n\treturn;\nL_0026:\n\tv56 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v56);\nL_0054:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ScatterVisualFor(this, pin);\n\tv157 = new System.Action();\n\tSystem.Action::.ctor(v157, v56, Il2CppMethodInfo);\n")]
		public void PlayDisappear(Entity pin, Action onComplete)
		{
			//IL_005d: Expected I4, but got F4
			int num;
			if (_config != null)
			{
				PinBlockerConfig config = _config;
				num = (int)config.disappearSeconds;
			}
			else
			{
				num = 1045220557;
			}
			ScatterVisualFor(pin);
			Action onComplete2 = delegate
			{
				if (onComplete != null)
				{
					onComplete();
				}
			};
			Tween tween = Tween.Delay(num, onComplete2);
		}

		[Token(Token = "0x60007F8")]
		[Address(RVA = "0x3E742E0", Offset = "0x3E742E0", Length = "0x4A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\nL_0042:\n\tv71 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::TryGetValue(this._visualByEntity, pin, &v69 @ stack_-68_v3 (UnityEngine.GameObject));\n\tv213 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::Remove(this._visualByEntity, pin);\n\tgoto L_0055;\nL_0055:\n\tv298 = UnityEngine.Object::op_Equality(this._config, 0);\n\tv304 = v298 == 0;\n\tif (v304) goto L_0068;\n\tgoto L_008A;\nL_0068:\n\tgoto L_006A;\nL_006A:\n\tv331 = UnityEngine.Application::get_isPlaying();\n\tv334 = v331 == 0;\n\tif (v334) goto L_008A;\n\tv362 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::TryGetMarkerWorldPosFor(this, pin, &v136 @ stack_-78_v4 (UnityEngine.Vector3));\n\tv377 = v362 == 0;\n\tif (v377) goto L_00BE;\n\tv130 = 0;\n\tv132 = v417;\n\tv134 = v136;\n\tv455 = v69;\n\tgoto L_0102;\nL_008A:\n\tgoto L_008E;\nL_008E:\n\tv347 = UnityEngine.Object::op_Inequality(v69, 0);\n\tv351 = ~v347;\n\tv352 = ~v351;\n\tif (v352) goto L_00A0;\n\tgoto L_0186;\nL_00A0:\n\tgoto L_00A3;\nL_00A3:\n\tv414 = UnityEngine.Application::get_isPlaying();\n\tv427 = ~v414;\n\tif (v427) goto L_00B4;\n\tgoto L_00B0;\nL_00B0:\n\tUnityEngine.Object::Destroy(v69);\n\tgoto L_0186;\nL_00B4:\n\tgoto L_00B8;\nL_00B8:\n\tUnityEngine.Object::DestroyImmediate(v69);\n\tgoto L_0186;\nL_00BE:\n\tgoto L_00C2;\nL_00C2:\n\tv472 = UnityEngine.Object::op_Inequality(v69, 0);\n\tv483 = v472 == 0;\n\tif (v483) goto L_00EB;\n\tv165 = UnityEngine.GameObject::get_transform(v69);\n\tv435 = UnityEngine.Transform::get_position(v165);\n\tv130 = v435.z;\n\tv132 = v435.y;\n\tv134 = v435;\n\tv455 = v69;\n\tgoto L_0102;\nL_00EB:\n\tgoto L_00F3;\n\tv507 = this._em;\n\tv492 = this._em == 0;\n\tv178 = ~v492;\n\tif (v178) goto L_0117;\n\tgoto L_0187;\nL_0110:\n\t// 272 MakeStruct v106 @ AGG3E74628_2_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v134 @ V8_v4 (UnityEngine.Vector3), v132 @ V9_v4 (System.Single), v130 @ V10_v4 (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ScatterPiece(this, v69, v106);\n\tv507 = this._em;\nL_0117:\n\tv393 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v507, pin);\n\tv399 = ~v393;\n\tif (v399) goto L_0186;\n\tv394 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, pin);\n\tv400 = ~v394;\n\tif (v400) goto L_0186;\n\tv521 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, pin);\n\tv395 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::TryGetValue(this._terminalsByPinId, v521, &v103 @ stack_-80_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv401 = ~v395;\n\tif (v401) goto L_0186;\n\tv524 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::Remove(this._terminalsByPinId, v521);\n\tv396 = v103;\n\tv410 = 0;\n\tgoto L_0155;\nL_0147:\n\tv410 = v410 + 1;\n\tv396 = v103;\nL_0155:\n\tv77 = v410 >= v396.Count;\n\tif (v77) goto L_0186;\n\tv540 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v396, v410);\n\tgoto L_0162;\nL_0162:\n\tv546 = UnityEngine.Object::op_Equality(v540, 0);\n\tv549 = v546 == 0;\n\tv550 = ~v549;\n\tif (v550) goto L_0147;\n\tgoto L_0176;\nL_0176:\n\t// 374 MakeStruct v555 @ AGG3E74754_2_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v134 @ V8_v4 (UnityEngine.Vector3), v132 @ V9_v4 (System.Single), v130 @ V10_v4 (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler::ScatterPiece(this, v540, v555);\n\tgoto L_0147;\nL_0186:\n\treturn;\nL_0187:\n\tthrow System.NullReferenceException;\nL_0102:\n\tv468 = UnityEngine.Object::op_Inequality(v455, 0);\n\tv480 = ~v468;\n\tv481 = ~v480;\n\tif (v481) goto L_0110;\nL_00F3:\n\tv134 = v516.zero;\n\tv132 = v516.zero.y;\n\tv130 = v516.zero.z;\n\tv455 = v69;\n\tgoto L_0102;\n")]
		private void ScatterVisualFor(Entity pin)
		{
			bool flag = _visualByEntity.TryGetValue(pin, out var value);
			bool flag2 = _visualByEntity.Remove(pin);
			if (!(_config == null) && Application.isPlaying)
			{
				float z;
				float y;
				Vector3 vector;
				UnityEngine.Object obj;
				if (TryGetMarkerWorldPosFor(pin, out var worldPos))
				{
					z = 0f;
					float num = default(float);
					y = num;
					vector = worldPos;
					obj = value;
				}
				else if (value != null)
				{
					Transform transform = value.transform;
					Vector3 position = transform.position;
					z = position.z;
					y = position.y;
					vector = position;
					obj = value;
				}
				else
				{
					vector = Vector3.zero;
					y = Vector3.zero.y;
					z = Vector3.zero.z;
					obj = value;
				}
				EntityManager em;
				if (!(obj != null))
				{
					em = _em;
					if (_em == null)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					Vector3 markerWorldPos = default(Vector3);
					markerWorldPos.x = vector.x;
					markerWorldPos.y = y;
					markerWorldPos.z = z;
					ScatterPiece(value, markerWorldPos);
					em = _em;
				}
				if (!em.IsValid(pin) || !_em.HasComponent<PinNodeComponent>(pin))
				{
					return;
				}
				PinNodeComponent component = _em.GetComponent<PinNodeComponent>(pin);
				if (!_terminalsByPinId.TryGetValue(component.pinId, out var value2))
				{
					return;
				}
				bool flag3 = _terminalsByPinId.Remove(component.pinId);
				List<GameObject> list = value2;
				int num2 = 0;
				Vector3 markerWorldPos2 = default(Vector3);
				while (num2 < list.Count)
				{
					UnityEngine.Object obj2 = list[num2];
					if (!(obj2 == null))
					{
						markerWorldPos2.x = vector.x;
						markerWorldPos2.y = y;
						markerWorldPos2.z = z;
						ScatterPiece((GameObject)obj2, markerWorldPos2);
					}
					num2++;
					list = value2;
				}
			}
			else if (value != null)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(value);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(value);
				}
			}
		}

		[Token(Token = "0x60007F9")]
		[Address(RVA = "0x3E74A98", Offset = "0x3E74A98", Length = "0x430")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv60 = UnityEngine.GameObject::get_transform(go);\n\tv162 = v60 == 0;\n\tif (v162) goto L_0146;\n\tUnityEngine.Transform::SetParent(v60, 0, 1);\n\tv153 = this._scatteredPieces;\n\tv163 = this._scatteredPieces == 0;\n\tif (v163) goto L_0146;\n\tv296 = v153._version + 1;\n\tv153._version = v296;\n\tv164 = v153._items == 0;\n\tif (v164) goto L_0146;\n\tgoto L_005A;\nL_005A:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(this._scatteredPieces, go);\n\tv317 = UnityEngine.GameObject::GetComponent(go);\n\tgoto L_0066;\nL_0066:\n\tv323 = UnityEngine.Object::op_Equality(v317, 0);\n\tv325 = ~v323;\n\tv326 = ~v325;\n\tif (v326) goto L_0079;\n\tv333 = v317 == 0;\n\tv165 = ~v333;\n\tv184 = v317;\n\tif (v165) goto L_0080;\n\tgoto L_0146;\nL_0079:\n\tv155 = UnityEngine.GameObject::AddComponent(go);\n\tv166 = v155 == 0;\n\tv184 = v155;\n\tif (v166) goto L_0146;\nL_0080:\n\tUnityEngine.Rigidbody::set_useGravity(v184, 1);\n\tUnityEngine.Rigidbody::set_isKinematic(v184, 0);\n\tUnityEngine.Rigidbody::set_constraints(v184, 0x38);\n\tv156 = UnityEngine.GameObject::get_transform(go);\n\tv167 = v156 == 0;\n\tif (v167) goto L_0146;\n\tv352 = UnityEngine.Transform::get_position(v156);\n\tv428 = v352 - markerWorldPos;\n\tv86 = v352.y - markerWorldPos.y;\n\tv357 = v428 * v428;\n\tv358 = v86 * v86;\n\tv359 = v357 + v358;\n\tv363 = v359 < 0x358637BD;\n\tif (v363) goto L_00CE;\n\tv375 = *([B193A86]) & 1;\n\tv376 = v375 == 0;\n\tv402 = v86;\n\tv406 = v428;\n\tif (v376) goto L_00DF;\nL_00AD:\n\tgoto L_00AE;\nL_00AE:\n\tv432 = v428 * v428;\n\tv433 = v86 * v86;\n\tv434 = v432 + v433;\n\tv190 = UnityEngine.Mathf::Sqrt(v434);\n\tv113 = v190 < 0x3727C5AC;\n\tv109 = v190 == 0x3727C5AC;\n\tv447 = v190 == v190;\n\tv95 = ~v447;\n\tv449 = v113 == v95;\n\tv450 = ~v449;\n\tv79 = v450 | v109;\n\tif (v79) goto L_00EE;\n\tv188 = v428 / v190;\n\t// 198 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv186 = 0 / v86;\n\tgoto L_00F8;\nL_00CE:\n\tv86 = UnityEngine.Random::Range(0f, 6.2831855f);\n\tv389 = 0x8BF5CD8(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v86, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv441 = *([B193A86]) & 1;\n\tv442 = v441 == 0;\n\tv391 = ~v442;\n\tv428 = 0x40C90FDB;\n\tv402 = v86;\n\tv406 = 0x40C90FDB;\n\tif (v391) goto L_00AD;\nL_00DF:\n\t*([B193A86]) = 1;\n\tv86 = v402;\n\tv428 = v406;\n\tgoto L_00AE;\nL_00EE:\n\tgoto L_00F4;\n\tv474 = *([B193A80]) & 1;\n\tv475 = v474 == 0;\n\tv476 = ~v475;\n\tif (v476) goto L_010C;\n\t*([B193A80]) = 1;\n\tv481 = this._config;\n\tv168 = this._config == 0;\n\tif (v168) goto L_0146;\nL_010C:\n\tv483 = v188 * v481.explosionForce;\n\tv484 = v186 * v454;\n\tv485 = *([B193000]);\n\tv134 = *([v485 @ X9_v6+B8]);\n\tv487 = *([v134 @ X9_v7+18]) * v481.upwardBias;\n\tv87 = v483 + v487;\n\tv489 = *([v134 @ X9_v7+1C]) * v490;\n\tv195 = v484 + v489;\n\t// 283 MakeStruct v66 @ AGG3E74DF8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v87 @ V0_v13 (System.Single), v195 @ V1_v18 (System.Single), v491 @ V1.S1\n\tUnityEngine.Rigidbody::AddForce(v184, v66, 1);\n\tv178 = this._config;\n\tv169 = this._config == 0;\n\tif (v169) goto L_0146;\n\tv494 = -v178.explosionTorque;\n\tv496 = UnityEngine.Random::Range(v494, v178.explosionTorque);\n\t// 298 MakeStruct v63 @ AGG3E74E2C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v496 @ V0_v15 (System.Single)\n\tUnityEngine.Rigidbody::AddTorque(v184, v63, 1);\n\tv179 = this._config;\n\tv170 = this._config == 0;\n\tif (v170) goto L_0146;\n\tgoto L_0144;\nL_0144:\n\tUnityEngine.Object::Destroy(go, v179.pieceLifetime);\n\treturn;\nL_0146:\n\tthrow System.NullReferenceException;\nL_0026:\n\tv54 = go == 0;\n\tif (v54) goto L_0146;\nL_00F8:\n\tv481 = this._config;\n\tv171 = this._config == 0;\n\tif (v171) goto L_0146;\nL_00F4:\n\tv472 = *([B193000]);\n\tv464 = *([v472 @ X8_v37+B8]);\n\tv188 = *([v464 @ X8_v38]);\n\tv186 = *([v464 @ X8_v38+4]);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ScatterPiece(GameObject go, Vector3 markerWorldPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::ScatterPiece");
		}

		[Token(Token = "0x60007FA")]
		[Address(RVA = "0x3E74780", Offset = "0x3E74780", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, pin);\n\tv178 = ~returnVal2;\n\tif (v178) goto L_012A;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, pin);\n\tv235 = ~returnVal2;\n\tif (v235) goto L_012A;\n\tv301 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, pin);\n\tv147 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\nL_FFFFFFFF:\n\tv122 = 0;\nL_FFFFFFFF:\n\tv330 = Il2CppMethodInfo;\n\tgoto L_0062;\nL_0060:\n\tv122 = v122 + 1;\n\tv382 = *([v340 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv382 = v382 + 0x10;\n\tv349 = v373 - 1;\n\tv347 = v373 != 1;\nL_FFFFFFFF:\n\tv373 = v349;\n\tif (v347) goto L_006D;\nL_0086:\n\tv395 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v147);\n\tv406 = v122 < v395;\n\tif (v406) goto L_00AB;\n\tgoto L_FFFFFFFF;\nL_0095:\n\tv409 = *([v382 @ X10_v15]) << 4;\n\tv410 = v340 + v409;\n\tv411 = v410 + 0x138;\n\t*([v411 @ X0_v44])(v415, v147, *([v411 @ X0_v44+8]), v330, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv425 = v122 >= v415;\n\tif (v425) goto L_FFFFFFFF;\nL_00AB:\n\tgoto L_00D2;\n\tv508 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v507);\n\tv509 = ~v508;\nL_FFFFFFFF:\n\tv330 = 0;\n\tif (v509) goto L_0060;\n\tv510 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v507);\n\tv76 = v510 != v301;\nL_FFFFFFFF:\n\tv330 = Il2CppMethodInfo;\n\tif (v76) goto L_0060;\n\tv515 = v507 & 1;\n\tv512 = v515 == 0;\nL_FFFFFFFF:\n\tv330 = Il2CppMethodInfo;\n\tif (v512) goto L_0060;\n\tv511 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v507);\n\tv513 = ~v511;\nL_FFFFFFFF:\n\tv330 = Il2CppMethodInfo;\n\tif (v513) goto L_0060;\n\tv520 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v507);\n\tgoto L_010E;\nL_010E:\n\tv529 = UnityEngine.Object::op_Inequality(this._visualGrid, 0);\n\tv531 = v529 == 0;\n\tif (v531) goto L_012B;\n\tv539 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v520);\n\tv189 = v539.y;\n\tv187 = v539.z;\nL_FFFFFFFF:\n\tv191 = v539;\n\tgoto L_012F;\nL_FFFFFFFF:\n\treturnVal2 = 0;\nL_012B:\n\tv532 = v520 >> 0x20;\nL_FFFFFFFF:\n\tv187 = 0;\nL_FFFFFFFF:\n\tv189 = v532;\nL_FFFFFFFF:\n\tv191 = v520;\nL_0031:\n\tworldPos.z = 0f;\n\tworldPos.x = 0f;\nL_012A:\n\treturn returnVal2;\nL_0062:\n\tv340 = *([v147 @ X0_v12 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv373 = *([v340 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv234 = *([v340 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v234) goto L_0086;\nL_006D:\n\tv387 = *([v382 @ X10_v15-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v387) goto L_0095;\nL_00D2:\n\tv507 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v147, v122);\nL_012F:\n\tworldPos.x = v191;\n\tworldPos.y = v189;\n\tworldPos.z = v187;\nL_FFFFFFFF:\n\treturnVal2 = 1;\n\tgoto L_012A;\n")]
		private bool TryGetMarkerWorldPosFor(Entity pin, out Vector3 worldPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::TryGetMarkerWorldPosFor");
			worldPos = default;
			return default;
		}

		[Token(Token = "0x60007FB")]
		[Address(RVA = "0x3E72704", Offset = "0x3E72704", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv56 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::TryGetValue(this._visualByEntity, pin, &v54 @ stack_-38_v3 (UnityEngine.Object));\n\tv70 = ~v56;\n\tif (v70) goto L_0047;\n\tv137 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::Remove(this._visualByEntity, pin);\n\tgoto L_003C;\nL_003C:\n\tv80 = UnityEngine.Object::op_Equality(v54, 0);\n\tv83 = v80 == 0;\n\tif (v83) goto L_0057;\nL_0047:\n\treturn;\nL_0057:\n\tgoto L_005A;\nL_005A:\n\tv159 = UnityEngine.Application::get_isPlaying();\n\tv162 = ~v159;\n\tif (v162) goto L_0072;\n\tgoto L_0067;\nL_0067:\n\tUnityEngine.Object::Destroy(v54);\n\treturn;\nL_0072:\n\tgoto L_0076;\nL_0076:\n\tUnityEngine.Object::DestroyImmediate(v54);\n\treturn;\n")]
		private unsafe void DestroyVisualFor(Entity pin)
		{
			UnityEngine.Object value;
			if (!_visualByEntity.TryGetValue(pin, out *(GameObject*)(&value)))
			{
				return;
			}
			bool flag = _visualByEntity.Remove(pin);
			if (!(value == null))
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(value);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(value);
				}
			}
		}

		[Token(Token = "0x60007FC")]
		[Address(RVA = "0x3E736AC", Offset = "0x3E736AC", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tv70 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::TryGetValue(this._rootsByPinId, pinId, &v68 @ stack_-68_v3 (UnityEngine.Object));\n\tv178 = ~v70;\n\tif (v178) goto L_0051;\n\tgoto L_0040;\nL_0040:\n\tv194 = UnityEngine.Object::op_Inequality(v68, 0);\n\tv197 = ~v194;\n\tif (v197) goto L_0051;\n\treturnVal2 = v68;\n\tgoto L_012D;\nL_0051:\n\tgoto L_0055;\nL_0055:\n\tv265 = UnityEngine.Object::op_Inequality(this._visualGrid, 0);\n\tv271 = ~v265;\n\tv272 = ~v271;\n\tif (v272) goto L_0067;\n\tv118 = 1f;\n\tgoto L_006D;\nL_0067:\n\tv298 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\n\tv118 = v298;\n\tUnityEngine.GameObject::.ctor(v142, v315);\n\tUnityEngine.Object::set_hideFlags(v142, 0x34);\n\tv143 = UnityEngine.GameObject::get_transform(v142);\n\tUnityEngine.Transform::SetParent(v143, this._parent, 0);\n\tv147 = UnityEngine.GameObject::get_transform(v142);\n\tgoto L_00A8;\nL_00A8:\n\t// 168 MakeStruct v91 @ AGG3E738E0_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v336.zero (UnityEngine.Vector3), v336.zero.y (System.Single), v336.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v147, v91);\n\tv148 = UnityEngine.GameObject::get_transform(v142);\n\tgoto L_00C6;\nL_00C6:\n\t// 198 MakeStruct v82 @ AGG3E7393C_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v354.identity (UnityEngine.Quaternion), v354.identity.y (System.Single), v354.identity.z (System.Single), v354.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v148, v82);\n\tv144 = UnityEngine.GameObject::get_transform(v142);\n\tgoto L_00DF;\nL_00DF:\n\tv93 = v118 * v370.one.z;\n\tv97 = v118 * v370.one.y;\n\tv113 = v118 * v370.one;\n\t// 228 MakeStruct v79 @ AGG3E7399C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v113 @ V0_v7 (System.Single), v97 @ V1_v6 (System.Single), v93 @ V2_v5 (System.Single)\n\tUnityEngine.Transform::set_localScale(v144, v79);\n\tv163 = this._config;\n\tgoto L_00F0;\nL_00F0:\n\tv378 = UnityEngine.Object::op_Inequality(v163.highlightProfile, 0);\n\tv382 = ~v378;\n\tv383 = ~v382;\n\tif (v383) goto L_0102;\n\tgoto L_0113;\nL_0102:\n\tv145 = UnityEngine.GameObject::AddComponent(v142);\n\tv164 = this._config;\n\tHighlightPlus.HighlightEffect::ProfileLoad(v145, v164.highlightProfile);\n\tHighlightPlus.HighlightEffect::SetHighlighted(v145, 1);\nL_0113:\n\tv146 = UnityEngine.GameObject::get_transform(v142);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::set_Item(this._rootsByPinId, pinId, v146);\n\treturnVal2 = UnityEngine.GameObject::get_transform(v142);\nL_012D:\n\treturn returnVal2;\nL_006D:\n\tv73 = pinId;\n\tv162 = 0xB7D5000 + 0x538;\n\tv311 = \"il2cpp_vm_object_box\"(*([v162 @ X8_v10 (System.Int32)+48]), &v73 @ stack_-6C_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv315 = System.String::Format(\"PinBlocker_{0}\", v311);\n\tv142 = new UnityEngine.GameObject();\n")]
		private unsafe Transform GetOrCreateRoot(int pinId)
		{
			UnityEngine.Object value;
			if (_rootsByPinId.TryGetValue(pinId, out *(Transform*)(&value)) && value != null)
			{
				return (Transform)value;
			}
			float num;
			if (!(_visualGrid != null))
			{
				num = 1f;
			}
			else
			{
				float effectiveCubeSize = _visualGrid.EffectiveCubeSize;
				num = effectiveCubeSize;
			}
			int num2 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string name = $"PinBlocker_{arg}";
			GameObject gameObject = new GameObject(name);
			gameObject.hideFlags = HideFlags.DontSave;
			Transform transform = gameObject.transform;
			transform.SetParent(_parent, worldPositionStays: false);
			Transform transform2 = gameObject.transform;
			Vector3 localPosition = default(Vector3);
			localPosition.x = Vector3.zero.x;
			localPosition.y = Vector3.zero.y;
			localPosition.z = Vector3.zero.z;
			transform2.localPosition = localPosition;
			Transform transform3 = gameObject.transform;
			Quaternion localRotation = default(Quaternion);
			localRotation.x = Quaternion.identity.x;
			localRotation.y = Quaternion.identity.y;
			localRotation.z = Quaternion.identity.z;
			localRotation.w = Quaternion.identity.w;
			transform3.localRotation = localRotation;
			Transform transform4 = gameObject.transform;
			float z = num * Vector3.one.z;
			float y = num * Vector3.one.y;
			float x = num * Vector3.one.x;
			Vector3 localScale = default(Vector3);
			localScale.x = x;
			localScale.y = y;
			localScale.z = z;
			transform4.localScale = localScale;
			PinBlockerConfig config = _config;
			if (config.highlightProfile != null)
			{
				HighlightEffect highlightEffect = gameObject.AddComponent<HighlightEffect>();
				PinBlockerConfig config2 = _config;
				highlightEffect.ProfileLoad(config2.highlightProfile);
				highlightEffect.SetHighlighted(state: true);
			}
			Transform transform5 = gameObject.transform;
			_rootsByPinId[pinId] = transform5;
			return gameObject.transform;
		}

		[Token(Token = "0x60007FD")]
		[Address(RVA = "0x3E73D1C", Offset = "0x3E73D1C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = type == 2;\n\tif (v11) goto L_002D;\n\tv20 = type == 1;\n\tif (v20) goto L_0024;\n\tv28 = type == 0;\n\tv29 = ~v28;\n\tif (v29) goto L_003A;\n\tv37 = this._config;\n\treturn v37.endpointPrefab;\nL_0024:\n\tv30 = this._config;\n\treturn v30.straightPrefab;\nL_002D:\n\tv25 = this._config;\n\treturn v25.cornerPrefab;\nL_003A:\n\treturn 0;\n")]
		private GameObject PickPiecePrefab(PathSegmentType type)
		{
			switch (type)
			{
			case PathSegmentType.Endpoint:
			{
				PinBlockerConfig config3 = _config;
				return config3.endpointPrefab;
			}
			case PathSegmentType.Straight:
			{
				PinBlockerConfig config2 = _config;
				return config2.straightPrefab;
			}
			case PathSegmentType.Corner:
			{
				PinBlockerConfig config = _config;
				return config.cornerPrefab;
			}
			default:
				return null;
			}
		}

		[Token(Token = "0x60007FE")]
		[Address(RVA = "0x3E72888", Offset = "0x3E72888", Length = "0x4FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0060;\n\tv82 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv214 = 0;\n\tv217 = this;\n\tgoto L_007F;\nL_0078:\n\tv727 = v691;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::Add(v766, &v727 @ stack_-78_v8 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv338 = Il2CppMethodInfo;\nL_007D:\n\tv214 = v214 + 1;\n\tv426 = *([v351 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv426 = v426 + 0x10;\n\tv374 = v417 - 1;\n\tv372 = v417 != 1;\n\tv417 = v374;\n\tif (v372) goto L_0085;\nL_00A1:\n\t;\n\tv439 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v82);\n\tv450 = v214 < v439;\n\tif (v450) goto L_00CA;\n\tgoto L_015E;\nL_00B1:\n\t;\n\tv459 = *([v426 @ X10_v18]) << 4;\n\tv460 = v351 + v459;\n\tv461 = v460 + 0x138;\n\t*([v461 @ X0_v61])(v465, v82, *([v461 @ X0_v61+8]), v338, v309, v43, v44, v45, v46, 0, v48, v49, v50, v51, v52, v53, v54);\n\tv475 = v214 >= v465;\n\tif (v475) goto L_015E;\nL_00CA:\n\tgoto L_00F1;\n\tv704 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v217._em, v691);\n\tv709 = ~v704;\n\tv338 = 0;\n\tif (v709) goto L_007D;\n\tv730 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(v217._em, v691);\n\tv731 = ~v730;\n\tv338 = Il2CppMethodInfo;\n\tif (v731) goto L_007D;\n\tv748 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v217._em, v691);\n\tv190 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v217._em, v691);\n\tv759 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>::TryGetValue(v65, v748, &v756 @ stack_-80_v6 (System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>));\n\tv761 = v759 == 0;\n\tv762 = ~v761;\n\tv309 = Il2CppMethodInfo;\n\tif (v762) goto L_013C;\n\tv766 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::.ctor(v766);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>::set_Item(v65, v748, v766);\n\tv756 = v766;\n\tv309 = Il2CppMethodInfo;\n\tv217 = this;\nL_013C:\n\t;\n\tgoto L_0078;\nL_015E:\n\tv542 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>::GetEnumerator(v65);\n\tv250 = v542._dictionary;\n\tv286 = new System.Comparison`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>();\n\tSystem.Comparison`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::.ctor(v286, v217, Il2CppMethodInfo);\n\tv288 = *([v542 @ X0_v26 (System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>+Enumerator<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+18]) == 0;\n\tif (v288) goto L_019D;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::Sort(*([v542 @ X0_v26 (System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>+Enumerator<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+18]), v286);\n\tgoto L_0175;\nL_018C:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v250 @ stack_-B0_v4 (System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>));\n\treturn v65;\nL_019D:\n\tthrow v285;\nL_0060:\n\tv65 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>::.ctor(v65);\nL_007F:\n\tv351 = *([v82 @ X0_v22 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv417 = *([v351 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv353 = *([v351 @ X8_v12 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v353) goto L_00A1;\nL_0085:\n\t;\n\tv431 = *([v426 @ X10_v18-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v431) goto L_00B1;\nL_00F1:\n\tv691 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v82, v214);\nL_0175:\n\tv703 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v250 @ stack_-B0_v4 (System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>));\n\tv608 = v703 == 0;\n\tif (v608) goto L_018C;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe Dictionary<int, List<PathEntry>> CollectPinPaths()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::CollectPinPaths");
			return default;
		}

		[Token(Token = "0x60007FF")]
		[Address(RVA = "0x3E73A8C", Offset = "0x3E73A8C", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0030:\n\tgoto L_005A;\nL_0069:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v308, v494);\n\tv77 = v77 + 1;\n\tv317 = v495;\n\tv387 = *([v346 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+B0]) + 8;\n\tv387 = v387 + 0x10;\n\tv373 = v388 - 1;\n\tv353 = v388 != 1;\n\tv388 = v373;\n\tif (v353) goto L_0077;\nL_0090:\n\tv401 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Count(ordered);\n\tv412 = v77 < v401;\n\tif (v412) goto L_00B2;\n\tgoto L_0111;\nL_009F:\n\tv415 = *([v387 @ X10_v16]) << 4;\n\tv416 = v346 + v415;\n\tv417 = v416 + 0x138;\n\t*([v417 @ X0_v27])(v421, ordered, *([v417 @ X0_v27+8]), v317, Il2CppMethodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv431 = v77 >= v421;\n\tif (v431) goto L_0111;\nL_00B2:\n\tv449 = ordered->klass;\n\tv479 = ordered->klass->interface_offsets_count;\n\tv451 = *([v449 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+12E]) == 0;\n\tif (v451) goto L_00D8;\n\tv134 = *([v449 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+B0]) + 8;\n\tv134 = v134 + 0x10;\n\tv466 = v479 - 1;\n\tv455 = v479 != 1;\n\tv479 = v466;\n\tif (v455) goto L_00BD;\nL_00D8:\n\tv150 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Item(ordered, v77);\n\tv483 = v308 == 0;\n\tv154 = ~v483;\n\tif (v154) goto L_00ED;\n\tgoto L_0112;\nL_00DE:\n\tv80 = *([v134 @ X10_v11]) << 4;\n\tv486 = v449 + v80;\n\tv487 = v486 + 0x138;\n\t*([v487 @ X0_v20])(v151, ordered, v77, *([v487 @ X0_v20+8]), Il2CppMethodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00ED:\n\t;\n\tgoto L_0069;\nL_0111:\n\treturn v308;\nL_0112:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_005A:\n\tv305 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>::get_Count(ordered);\n\tv308 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v308, v305);\n\tv77 = 0;\n\tv317 = Il2CppMethodInfo;\n\tgoto L_006C;\nL_006C:\n\tv346 = ordered->klass;\n\tv388 = ordered->klass->interface_offsets_count;\n\tv268 = *([v346 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>>)+12E]) == 0;\n\tif (v268) goto L_0090;\nL_0077:\n\tv393 = *([v387 @ X10_v16-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>;\n\tif (v393) goto L_009F;\nL_00BD:\n\tv114 = *([v134 @ X10_v11-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler+PathEntry>;\n\tif (v114) goto L_00DE;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static List<GridCoord> ExtractCoords(IReadOnlyList<PathEntry> ordered)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBlockerVisualHandler::ExtractCoords");
			return default;
		}

		[Token(Token = "0x6000800")]
		[Address(RVA = "0x3E74ED4", Offset = "0x3E74ED4", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv89 = new System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>();\n\tSystem.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, UnityEngine.GameObject>::.ctor(v89);\n\tthis._visualByEntity = v89;\n\tv106 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<UnityEngine.GameObject>>::.ctor(v106);\n\tthis._terminalsByPinId = v106;\n\tv116 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v116);\n\tthis._scatteredPieces = v116;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0040:\n\tv72 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Transform>::.ctor(v72);\n\tthis._rootsByPinId = v72;\n")]
		public PinBlockerVisualHandler()
		{
			Dictionary<int, Transform> rootsByPinId = new Dictionary<int, Transform>();
			_rootsByPinId = rootsByPinId;
			Dictionary<Entity, GameObject> visualByEntity = new Dictionary<Entity, GameObject>();
			_visualByEntity = visualByEntity;
			Dictionary<int, List<GameObject>> terminalsByPinId = new Dictionary<int, List<GameObject>>();
			_terminalsByPinId = terminalsByPinId;
			List<GameObject> scatteredPieces = new List<GameObject>();
			_scatteredPieces = scatteredPieces;
		}
	}
}

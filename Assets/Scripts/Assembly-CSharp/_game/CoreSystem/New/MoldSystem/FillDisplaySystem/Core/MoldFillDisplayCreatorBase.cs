using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces;
using _game.CoreSystem.New.MoldSystem.Visual;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core
{
	[Token(Token = "0x20002D3")]
	public abstract class MoldFillDisplayCreatorBase : IMoldFillDisplayCreator
	{
		[Inject(false)]
		[Token(Token = "0x40008AE")]
		[FieldOffset(Offset = "0x10")]
		protected EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40008AF")]
		[FieldOffset(Offset = "0x18")]
		protected MoldFillDisplayState _state;

		[Inject(false)]
		[Token(Token = "0x40008B0")]
		[FieldOffset(Offset = "0x20")]
		protected MoldFillDisplayConfig _config;

		[Inject(false)]
		[Token(Token = "0x40008B1")]
		[FieldOffset(Offset = "0x28")]
		protected MoldVisualGridController _visualGrid;

		[Token(Token = "0x6000C7B")]
		[Address(RVA = "0x3ED6D2C", Offset = "0x3ED6D2C", Length = "0x530")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv158 = *([v64 @ X0_v26 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv324 = *([v158 @ X8_v21 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv160 = *([v158 @ X8_v21 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v160) goto L_0067;\n\tv323 = *([v158 @ X8_v21 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv323 = v323 + 0x10;\n\tv189 = v324 - 1;\n\tv169 = v324 != 1;\nL_FFFFFFFF:\n\tv324 = v189;\n\tif (v169) goto L_004D;\nL_0067:\n\tv386 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v64);\n\tv343 = v386 == 0;\n\tv344 = ~v343;\nL_FFFFFFFF:\n\tv99 = v386;\nL_FFFFFFFF:\n\tv424 = &v99 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv105 = 0;\n\tif (v344) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv224 = &v99 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv268 = *([v192 @ X0_v79+8]);\n\tgoto L_0157;\nL_0071:\n\tv360 = *([v323 @ X10_v30]) << 4;\n\tv361 = v158 + v360;\n\tv362 = v361 + 0x138;\n\tv268 = *([v362 @ X8_v46+8]);\n\t*([v362 @ X8_v46])(v386, v64, *([v362 @ X8_v46+8]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv370 = v386 == 0;\nL_FFFFFFFF:\n\tv99 = v386;\nL_FFFFFFFF:\n\tv424 = &v99 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv224 = &v99 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv105 = 0;\n\tif (v370) goto L_0157;\nL_FFFFFFFF:\n\tv496 = v386;\n\tgoto L_0094;\nL_008E:\n\tv475 = v99 == 0;\nL_FFFFFFFF:\n\tv496 = v99;\nL_FFFFFFFF:\n\tv224 = v424;\n\tif (v475) goto L_0157;\nL_0094:\n\tgoto L_00BA;\n\tv291 = v99 == 0;\n\tif (v291) goto L_0159;\n\tgoto L_00EB;\n\tv788 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v786);\n\tv790 = v788 == 0;\nL_FFFFFFFF:\n\tv268 = v786;\n\tif (v790) goto L_008E;\n\tv293 = this._em == 0;\n\tif (v293) goto L_015D;\n\tv800 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v786);\n\tv809 = v786 & 0x100000000;\n\tv810 = v809 == 0;\n\tv804 = ~v810;\nL_FFFFFFFF:\n\tv268 = v786;\n\tif (v804) goto L_008E;\n\tv813 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(v786);\n\tv814 = v813 == 0;\n\tif (v814) goto L_FFFFFFFF;\n\tv816 = UnityEngine.Component::get_gameObject(v813);\nL_FFFFFFFF:\n\tv793 = v816;\n\tgoto L_0118;\nL_FFFFFFFF:\n\tv793 = 0;\n\tgoto L_0118;\nL_0118:\n\tv801 = UnityEngine.Object::op_Equality(v793, 0);\n\tv837 = ~v801;\n\tv805 = ~v837;\nL_FFFFFFFF:\n\tv268 = 0;\n\tif (v805) goto L_008E;\n\tv840 = _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayCreatorBase::CreateForMold(this, v786);\n\tgoto L_0129;\nL_0129:\n\tv802 = UnityEngine.Object::op_Equality(v840, 0);\n\tv848 = v802 == 0;\n\tv806 = ~v848;\nL_FFFFFFFF:\n\tv268 = 0;\n\tif (v806) goto L_008E;\n\tv301 = this._state;\n\tv299 = v301.MoldTexts == 0;\n\tif (v299) goto L_016C;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>::set_Item(v301.MoldTexts, v786, v840);\n\tv306 = this._state;\n\tv298 = this._state == 0;\n\tif (v298) goto L_016A;\n\tv297 = v306.EntityIds == 0;\n\tif (v297) goto L_0168;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.BaseLayerSystems.EntitySystem.Core.EntityId>::set_Item(v306.EntityIds, v786, v786);\n\tv305 = this._state;\n\tv296 = this._state == 0;\n\tif (v296) goto L_0166;\n\tv295 = v305.LastPercent == 0;\n\tif (v295) goto L_0164;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::set_Item(v305.LastPercent, v786, -1);\n\tv148 = this._state;\n\tv294 = this._state == 0;\n\tif (v294) goto L_0162;\n\tv146 = v148.FramesSinceLastChange == 0;\n\tif (v146) goto L_0160;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::set_Item(v148.FramesSinceLastChange, v786, 0);\nL_FFFFFFFF:\n\tv268 = v786;\n\tgoto L_008E;\nL_0157:\n\tv278 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = 0;\n\tgoto L_016F;\nL_0159:\n\tv276 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv424 = v224;\nL_FFFFFFFF:\n\tv276 = v278;\n\tgoto L_016F;\nL_015B:\n\tv280 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = 0;\n\tgoto L_016F;\nL_015D:\n\tv276 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = 0;\nL_FFFFFFFF:\n\tv276 = v280;\n\tgoto L_016F;\nL_0160:\n\tv151 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = v786;\n\tgoto L_016F;\nL_0162:\n\tv276 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv424 = v100;\nL_FFFFFFFF:\n\tv268 = v141;\nL_FFFFFFFF:\n\tv276 = v151;\n\tgoto L_016F;\nL_0164:\n\tv283 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = v786;\n\tgoto L_016F;\nL_0166:\n\tv276 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = v786;\nL_FFFFFFFF:\n\tv276 = v283;\n\tgoto L_016F;\nL_0168:\n\tv285 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = v786;\n\tgoto L_016F;\nL_016A:\n\tv276 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = v786;\nL_FFFFFFFF:\n\tv276 = v285;\n\tgoto L_016F;\nL_016C:\n\tv287 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv268 = v786;\n\tgoto L_016F;\nL_016F:\n\t// 367 Interrupt\n\tgoto L_0193;\nL_0193:\n\tv354 = v268 != 1;\n\tif (v354) goto L_01DF;\n\tv398 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv503 = 0x8BF5BF4(v398, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv105 = *([v398 @ X0_v20]);\nL_019B:\n\tv559 = *([v424 @ stack_-70_v2]) == 0;\n\tif (v559) goto L_01CB;\n\tgoto L_01C9;\n\treturn;\nL_01DC:\n\tv454 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv276 = v454;\nL_01DF:\n\tv465 = 0x3175484(&v105 @ stack_-78_v7 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv505 = 0x8BF0368(v276, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv560 = 0xA1B8(v505, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0035:\n\tv99 = 0;\nL_004D:\n\tv329 = *([v323 @ X10_v30-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v329) goto L_0071;\nL_00BA:\n\tv554 = System.Collections.IEnumerator::MoveNext(v496);\n\tv556 = v554 == 0;\n\tif (v556) goto L_019B;\nL_00EB:\n\tv786 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v99);\n\tv292 = this._em == 0;\n\tif (v292) goto L_015B;\nL_01CB:\n\tv610 = v105 == 0;\n\tv456 = ~v610;\n\tif (v456) goto L_01DC;\nL_01C9:\n\tSystem.IDisposable::Dispose(*([v424 @ stack_-70_v2]));\n")]
		public void CreateAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillDisplayCreatorBase::CreateAll");
		}

		[Token(Token = "0x6000C7C")]
		[Address(RVA = "0x3ED725C", Offset = "0x3ED725C", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv56 = UnityEngine.Component::get_gameObject(v48);\nL_FFFFFFFF:\n\tv75 = v56;\n\tgoto L_002E;\nL_002E:\n\tv80 = UnityEngine.Object::op_Equality(v75, 0);\n\tv85 = v80 == 0;\n\tv86 = ~v85;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v86) goto L_005E;\n\tv87 = this._config;\n\tv144 = UnityEngine.GameObject::get_transform(v75);\n\tgoto L_004B;\nL_004B:\n\treturnVal1 = UnityEngine.Object::Instantiate(v87.TextPrefab, v144, 0);\n\tv155 = TMPro.TMP_Text::set_text(returnVal1, \"\");\nL_FFFFFFFF:\n\tv75 = 0;\n\tgoto L_002E;\nL_001F:\n\tv48 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tv52 = v48 == 0;\n\tif (v52) goto L_FFFFFFFF;\nL_005E:\n\treturn returnVal1;\n")]
		public TextMeshPro CreateForMold(Entity entity)
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
			bool flag = gameObject2 == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			TextMeshPro textMeshPro = null;
			if (!flag3)
			{
				MoldFillDisplayConfig config = _config;
				Transform transform = gameObject2.transform;
				textMeshPro = UnityEngine.Object.Instantiate(config.TextPrefab, transform, worldPositionStays: false);
				textMeshPro.text = "";
			}
			return textMeshPro;
		}

		[Token(Token = "0x6000C7D")]
		protected abstract GameObject InstantiateTextGameObject();

		[Token(Token = "0x6000C7E")]
		[Address(RVA = "0x3ED5E60", Offset = "0x3ED5E60", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected internal MoldFillDisplayCreatorBase()
		{
		}
	}
}

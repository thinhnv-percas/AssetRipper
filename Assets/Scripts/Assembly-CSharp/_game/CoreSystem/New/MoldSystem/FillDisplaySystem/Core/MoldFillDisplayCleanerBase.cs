using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core
{
	[Token(Token = "0x20002D0")]
	public abstract class MoldFillDisplayCleanerBase : IMoldFillDisplayCleaner
	{
		[Inject(false)]
		[Token(Token = "0x40008A6")]
		[FieldOffset(Offset = "0x10")]
		protected MoldFillDisplayState _state;

		[Token(Token = "0x6000C71")]
		[Address(RVA = "0x3ED6664", Offset = "0x3ED6664", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv65 = v59.MoldTexts == 0;\n\tv143 = &v107 @ stack_-90_v4 (System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>);\n\tv154 = 0;\n\tv155 = 0;\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v65) goto L_00C0;\n\tv176 = 0xB2A2000 + 0xA98;\n\tv173 = 0xB2A2000 + 0x570;\n\tv170 = 0xB2A2000 + 0x738;\n\tv164 = 0xB2A8000 + 0x808;\n\tv228 = System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>::GetEnumerator(v59.MoldTexts);\n\tv107 = v228._dictionary;\n\tgoto L_0075;\nL_0075:\n\tv256 = UnityEngine.Object::op_Inequality(v292, 0);\n\tv259 = v256 == 0;\n\tif (v259) goto L_0067;\n\tv372 = UnityEngine.Component::get_gameObject(v292);\n\tv257 = _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayCleanerBase::DestroyObject(this, v372);\n\tgoto L_0067;\nL_0087:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v107 @ stack_-90_v4 (System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>));\n\tv146 = &v107 @ stack_-90_v4 (System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>);\n\tv154 = 0;\n\tv157 = Il2CppMethodInfo;\nL_0088:\n\tv205 = this._state;\n\tv193 = this._state == 0;\n\tv143 = v145;\n\tv155 = methodInfo;\n\tv162 = v7;\n\tv168 = v13;\n\tv171 = v11;\n\tv174 = v9;\n\tif (v193) goto L_00C0;\n\tv194 = v205.MoldTexts == 0;\n\tv143 = v146;\n\tv155 = v157;\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v194) goto L_00C0;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>::Clear(v205.MoldTexts);\n\tv206 = this._state;\n\tv195 = this._state == 0;\n\tv143 = v146;\n\tv155 = v157;\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v195) goto L_00C0;\n\tv196 = v206.EntityIds == 0;\n\tv143 = v146;\n\tv155 = *([v176 @ X24_v2 (System.Int32)]);\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v196) goto L_00C0;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.BaseLayerSystems.EntitySystem.Core.EntityId>::Clear(v206.EntityIds);\n\tv207 = this._state;\n\tv197 = this._state == 0;\n\tv143 = v146;\n\tv155 = *([v176 @ X24_v2 (System.Int32)]);\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v197) goto L_00C0;\n\tv198 = v207.LastPercent == 0;\n\tv143 = v146;\n\tv155 = *([v173 @ X23_v2 (System.Int32)]);\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v198) goto L_00C0;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::Clear(v207.LastPercent);\n\tv208 = this._state;\n\tv199 = this._state == 0;\n\tv143 = v146;\n\tv155 = *([v173 @ X23_v2 (System.Int32)]);\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v199) goto L_00C0;\n\tv200 = v208.FramesSinceLastChange == 0;\n\tv143 = v146;\n\tv155 = *([v170 @ X22_v2 (System.Int32)]);\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v200) goto L_00C0;\n\tv161 = *([v170 @ X22_v2 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::Clear(v208.FramesSinceLastChange);\n\tv209 = this._state;\n\tv201 = this._state == 0;\n\tv143 = v146;\n\tv155 = *([v170 @ X22_v2 (System.Int32)]);\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v201) goto L_00C0;\n\tv202 = v209.Filling == 0;\n\tv143 = v146;\n\tv155 = *([v170 @ X22_v2 (System.Int32)]);\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v202) goto L_00C0;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(v209.Filling);\n\treturn;\nL_00CF:\n\tv246 = v155 != 1;\n\tv276 = v213;\n\tif (v246) goto L_00DF;\n\tv267 = 0x8BF5BC4(v213, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv286 = 0x8BF5BF4(v267, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv157 = *([v162 @ X25_v1 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(v143);\n\tv275 = *([v267 @ X0_v11]) == 0;\n\tv146 = v143;\n\tv154 = *([v267 @ X0_v11]);\n\tv164 = v162;\n\tv170 = v168;\n\tv173 = v171;\n\tv176 = v174;\n\tif (v275) goto L_0088;\n\tv273 = new System.OutOfMemoryException();\n\tv154 = *([v267 @ X0_v11]);\n\tv276 = v273;\n\treturn;\nL_0039:\n\tv59 = this._state;\n\tv60 = this._state == 0;\n\tv143 = v146;\n\tv155 = v161;\n\tv162 = v164;\n\tv168 = v170;\n\tv171 = v173;\n\tv174 = v176;\n\tif (v60) goto L_00C0;\nL_00C0:\n\tv213 = new System.NullReferenceException();\n\tgoto L_00CF;\nL_0067:\n\tv265 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v107 @ stack_-90_v4 (System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>));\n\tv284 = v265 == 0;\n\tif (v284) goto L_0087;\nL_00DF:\n\tv279 = 0x3190014(&v154 @ stack_-B8_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv288 = 0x8BF0368(v276, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv299 = 0xA1B8(v288, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ClearAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillDisplayCleanerBase::ClearAll");
		}

		[Token(Token = "0x6000C72")]
		[Address(RVA = "0x3ED6908", Offset = "0x3ED6908", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv116 = System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>::TryGetValue(v45.MoldTexts, key, &v63 @ stack_-38_v3 (UnityEngine.Component));\n\tv120 = ~v116;\n\tif (v120) goto L_0054;\n\tgoto L_003D;\nL_003D:\n\tv160 = UnityEngine.Object::op_Inequality(v63, 0);\n\tv171 = ~v160;\n\tv163 = ~v171;\n\tif (v163) goto L_004D;\n\tgoto L_0054;\nL_004D:\n\tv178 = UnityEngine.Component::get_gameObject(v63);\n\tv159 = _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayCleanerBase::DestroyObject(this, v178);\n\tv76 = System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>::Remove(v99.MoldTexts, key);\n\tv100 = this._state;\n\tv78 = System.Collections.Generic.Dictionary`2<System.Int32, _game.BaseLayerSystems.EntitySystem.Core.EntityId>::Remove(v100.EntityIds, key);\n\tv101 = this._state;\n\tv80 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::Remove(v101.LastPercent, key);\n\tv102 = this._state;\n\tv82 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::Remove(v102.FramesSinceLastChange, key);\n\tv103 = this._state;\n\tv133 = System.Collections.Generic.HashSet`1<System.Int32>::Remove(v103.Filling, key);\n\treturn;\nL_0025:\n\tv45 = this._state;\nL_0054:\n\tv99 = this._state;\n")]
		public unsafe void RemoveOne(int key)
		{
			MoldFillDisplayState state = _state;
			Component value;
			if (state.MoldTexts.TryGetValue(key, out *(TextMeshPro*)(&value)) && value != null)
			{
				GameObject gameObject = value.gameObject;
				DestroyObject(gameObject);
			}
			MoldFillDisplayState state2 = _state;
			bool flag = state2.MoldTexts.Remove(key);
			MoldFillDisplayState state3 = _state;
			bool flag2 = state3.EntityIds.Remove(key);
			MoldFillDisplayState state4 = _state;
			bool flag3 = state4.LastPercent.Remove(key);
			MoldFillDisplayState state5 = _state;
			bool flag4 = state5.FramesSinceLastChange.Remove(key);
			MoldFillDisplayState state6 = _state;
			bool flag5 = state6.Filling.Remove(key);
		}

		[Token(Token = "0x6000C73")]
		protected abstract void DestroyObject(UnityEngine.Object obj);

		[Token(Token = "0x6000C74")]
		[Address(RVA = "0x3ED5DE0", Offset = "0x3ED5DE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected internal MoldFillDisplayCleanerBase()
		{
		}
	}
}

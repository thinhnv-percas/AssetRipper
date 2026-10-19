using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using Unco.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.Utils
{
	[Serializable]
	[Token(Token = "0x2000020")]
	public class GenericUIState : ComponentState
	{
		[SerializeField]
		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x28")]
		private List<Pair<Image, Sprite>> m_imagePair;

		[SerializeField]
		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x30")]
		private List<Pair<Image, Color>> m_imageColorPair;

		[SerializeField]
		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x38")]
		private List<Pair<UncoTMP, Color>> m_tmpColorPair;

		[SerializeField]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x40")]
		private List<Pair<UncoTMP, string>> m_tmpTextPair;

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x81C3028", Offset = "0x81C3028", Length = "0x4A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = &v144 @ stack_-C0_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>);\n\tgoto L_0049;\n\tv93 = &v94 @ stack_-138 (System.Int32);\n\tv95 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>::GetEnumerator(this.m_imagePair);\n\tv94 = v94.m_value;\n\t*([v28 @ X27_v1+30]) = v94.m_value;\n\t*([v28 @ X27_v1+40]) = *([v93 @ X8_v10+10]);\n\tv94 = 0;\n\tv260 = v301 == 0;\n\tif (v260) goto L_011B;\n\tUnityEngine.UI.Image::set_sprite(v301, v307);\n\tv156 = 0;\n\tgoto L_007E;\nL_008B:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>::Dispose(&v250 @ stack_-90 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>));\n\tv233 = this.m_tmpColorPair == 0;\n\tv197 = &v250 @ stack_-90 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>);\n\tv94 = 0;\n\tv214 = Il2CppMethodInfo;\n\tif (v233) goto L_0123;\n\tv317 = &v94 @ stack_-138 (System.Int32);\n\tv318 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>::GetEnumerator(this.m_tmpColorPair);\n\tv144 = v94.m_value;\n\t*([v28 @ X27_v1+10]) = *([v317 @ X8_v13+10]);\n\tv94 = 0;\n\tv347 = v516 == 0;\n\tif (v347) goto L_011D;\n\tv449 = *([v516 @ stack_-B0]);\n\t*([v449 @ X8_v28+2A8])(v447, v516, *([v449 @ X8_v28+2B0]), v156, v40, v41, v42, v43, v44, v522, v523, *([v317 @ X8_v13+20]), v521, v49, v50, v51, v52);\n\tgoto L_00A7;\nL_00B9:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>::Dispose(&v144 @ stack_-C0_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>));\n\tv234 = this.m_tmpTextPair == 0;\n\tv197 = &v144 @ stack_-C0_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>);\n\tv94 = 0;\n\tv214 = Il2CppMethodInfo;\n\tif (v234) goto L_0123;\n\tv528 = &v94 @ stack_-138 (System.Int32);\n\tv529 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>::GetEnumerator(this.m_tmpTextPair);\n\tv128 = v94.m_value;\n\tv348 = *([v528 @ X8_v17+10]) == 0;\n\tif (v348) goto L_011F;\n\tTMPro.TMP_Text::SetText(*([v528 @ X8_v17+10]), v546);\n\tv156 = 0;\n\tgoto L_00D1;\nL_00E0:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>::Dispose(&v128 @ stack_-E0_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>));\n\tv235 = this.m_imageColorPair == 0;\n\tv197 = &v128 @ stack_-E0_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>);\n\tv94 = 0;\n\tv214 = Il2CppMethodInfo;\n\tif (v235) goto L_0123;\n\tv551 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>::GetEnumerator(this.m_imageColorPair);\n\tv332 = v551;\n\tv328 = *([v551 @ X0_v38 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>)+10]);\n\tv562 = *([v328 @ stack_-100_v5]);\n\t*([v562 @ X8_v27+2A8])(v560, v328, *([v562 @ X8_v27+2B0]), v156, v40, v41, v42, v43, v44, *([v551 @ X0_v38 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>)+18]), *([v551 @ X0_v38 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>)+1C]), *([v551 @ X0_v38 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>)+20]), *([v551 @ X0_v38 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>)+24]), v49, v50, v51, v52);\n\tgoto L_00F8;\nL_010C:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>::Dispose(&v332 @ stack_-110_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>));\nL_011A:\n\treturn;\nL_011B:\n\tv308 = new System.NullReferenceException();\n\tv197 = &v63 @ stack_-110_v1 (System.Int32);\n\tv94 = 0;\n\tv214 = Il2CppMethodInfo;\n\tgoto L_0122;\nL_011D:\n\tv344 = new System.NullReferenceException();\n\tv197 = &v250 @ stack_-90 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>);\n\tv94 = 0;\n\tv214 = Il2CppMethodInfo;\n\tgoto L_0122;\nL_011F:\n\tv345 = new System.NullReferenceException();\n\tv197 = &v144 @ stack_-C0_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>);\n\tv94 = 0;\n\tv214 = Il2CppMethodInfo;\n\tgoto L_0122;\nL_0122:\n\t// 290 Interrupt\nL_0136:\n\tv274 = v214 != 1;\n\tv286 = v244;\n\tif (v274) goto L_0148;\n\tv281 = 0x8BF5BC4(v244, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv303 = 0x8BF5BF4(v281, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>::Dispose(v197);\n\tv291 = *([v281 @ X0_v13]) == 0;\n\tif (v291) goto L_011A;\n\tv289 = new System.OutOfMemoryException();\n\tv94 = *([v281 @ X0_v13]);\n\tv286 = v289;\nL_019F:\n\tv312 = 0x8BF0368(v286, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv319 = 0x7C03E68(v312, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0049:\n\t*([v28 @ X27_v1+30]) = 0;\n\t*([v28 @ X27_v1+40]) = 0;\n\t*([v28 @ X27_v1+10]) = 0;\n\tv63 = 0;\n\tUnco.Utils.ComponentState::Activate(this);\n\tv70 = this.m_imagePair == 0;\n\tif (v70) goto L_0123;\nL_0123:\n\tv244 = new System.NullReferenceException();\n\tgoto L_0136;\nL_007E:\n\tv263 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>::MoveNext(&v250 @ stack_-90 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>));\n\tv279 = v263 == 0;\n\tif (v279) goto L_008B;\nL_00A7:\n\tv451 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>::MoveNext(&v144 @ stack_-C0_v5 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Object, UnityEngine.Color>>));\n\tv511 = v451 == 0;\n\tif (v511) goto L_00B9;\nL_00D1:\n\tv541 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Object>>+Enumerator<Unco.Utils.Pair`2<System.Object, System.Object>>::MoveNext(&v128 @ stack_-E0_v5 (System.Collections.Generic.List`1<U\n// ... truncated")]
		public unsafe override void Activate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenericUIState::Activate");
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x81C34D4", Offset = "0x81C34D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GenericUIState()
		{
		}
	}
}

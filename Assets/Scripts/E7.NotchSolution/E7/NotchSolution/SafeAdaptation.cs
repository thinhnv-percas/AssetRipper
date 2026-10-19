using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[HelpURL("https://exceed7.com/notch-solution/components/adaptation/safe-adaptation.html")]
	[Token(Token = "0x2000017")]
	public class SafeAdaptation : AdaptationBase
	{
		[Token(Token = "0x400007E")]
		private const float iPhoneXNotchHeightRelative = 0.05418718f;

		[SerializeField]
		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform.Edge adaptToEdge;

		[SerializeField]
		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x54")]
		private EdgeEvaluationMode evaluationMode;

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x3F464CC", Offset = "0x3F464CC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.AnimationCurve::Linear(0f, 0f, 0.05418718f, 1f);\n\tE7.NotchSolution.AdaptationBase::ResetAdaptationToCurve(this, v19);\n\treturn;\n")]
		private void Reset()
		{
			AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 0.05418718f, 1f);
			ResetAdaptationToCurve(curve);
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x3F46510", Offset = "0x3F46510", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_0020:\n\tv55 = E7.NotchSolution.NotchSolutionUtility::get_ScreenSafeAreaRelative();\n\tv251 = v55.y;\n\tv66 = this.evaluationMode == 2;\nL_FFFFFFFF:\n\tv157 = 0;\nL_FFFFFFFF:\n\tv156 = 0;\n\tif (v66) goto L_0080;\n\tv118 = this.adaptToEdge > 1;\n\tif (v118) goto L_0052;\n\tv170 = this.adaptToEdge == 0;\n\tif (v170) goto L_FFFFFFFF;\n\tv190 = this.adaptToEdge != 1;\n\tif (v190) goto L_0090;\n\tv298 = v55.width + v55;\n\tgoto L_0086;\nL_0052:\n\tv175 = this.adaptToEdge == 2;\n\tif (v175) goto L_0084;\n\tv201 = this.adaptToEdge != 3;\n\tif (v201) goto L_0090;\nL_FFFFFFFF:\n\tv157 = v55.y;\n\tgoto L_0090;\nL_0080:\n\tE7.NotchSolution.AdaptationBase::Adapt(this, v156);\n\treturn;\nL_FFFFFFFF:\n\tv157 = v55;\n\tgoto L_0090;\nL_0084:\n\tv298 = v55.height + v55.y;\n\tv309 = this.adaptToEdge > 1;\n\tif (v309) goto L_00CF;\n\tv259 = this.adaptToEdge == 0;\n\tif (v259) goto L_00E2;\n\tv319 = v157 < v55;\n\tv320 = v157 == v55;\n\tv323 = v157 == v157;\n\tv324 = v55 == v55;\n\tv325 = v323 & v324;\n\tv326 = ~v325;\n\tv327 = v319 == v326;\n\tv215 = ~v320;\n\tv218 = v327 & v215;\n\tv328 = ~v218;\n\tif (v328) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv250 = v157;\n\tgoto L_00BB;\nL_FFFFFFFF:\n\tv250 = v55;\nL_FFFFFFFF:\n\tv253 = v250;\n\tgoto L_00C9;\nL_FFFFFFFF:\n\tv253 = v157;\nL_00CF:\n\tv314 = this.adaptToEdge == 2;\n\tif (v314) goto L_00E5;\n\tv125 = this.adaptToEdge != 3;\nL_FFFFFFFF:\n\tv156 = v157;\n\tif (v125) goto L_0080;\n\tv355 = v55.height + v251;\n\tgoto L_00E4;\nL_00E2:\n\tv355 = v55.width + v55;\nL_FFFFFFFF:\n\tv254 = v157;\n\tgoto L_00FE;\nL_FFFFFFFF:\n\tv254 = v251;\nL_001A:\n\tgoto L_0020;\nL_0090:\n\tv126 = this.evaluationMode != 1;\nL_FFFFFFFF:\n\tv156 = v157;\n\tif (v126) goto L_0080;\nL_0086:\n\tv294 = 1f - v298;\nL_FFFFFFFF:\n\tv157 = v294;\nL_00BB:\n\tv206 = this.adaptToEdge != 1;\n\tif (v206) goto L_FFFFFFFF;\nL_00C9:\n\tE7.NotchSolution.AdaptationBase::Adapt(this, v253);\n\treturn;\nL_00E5:\n\tv237 = v157 < v251;\n\tv234 = v157 == v251;\n\tv351 = v157 == v157;\n\tv231 = v251 == v251;\n\tv240 = v351 & v231;\n\tv222 = ~v240;\n\tv352 = v237 == v222;\n\tv216 = ~v234;\n\tv219 = v352 & v216;\n\tv207 = ~v219;\n\tif (v207) goto L_FFFFFFFF;\nL_00E4:\n\tv251 = 1f - v355;\nL_00FE:\n\tE7.NotchSolution.AdaptationBase::Adapt(this, v254);\n\treturn;\n")]
		public override void Adapt()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SafeAdaptation::Adapt");
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x3F46674", Offset = "0x3F46674", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv174 = relativeSafeArea.y;\n\tv12 = this.evaluationMode == 2;\nL_FFFFFFFF:\n\tv90 = 0;\n\tif (v12) goto L_005A;\n\tv29 = this.adaptToEdge > 1;\n\tif (v29) goto L_0031;\n\tv96 = this.adaptToEdge == 0;\n\tif (v96) goto L_FFFFFFFF;\n\tv115 = this.adaptToEdge != 1;\nL_FFFFFFFF:\n\tv91 = 0;\n\tif (v115) goto L_0054;\n\tv195 = relativeSafeArea.width + relativeSafeArea;\n\tgoto L_005E;\nL_0031:\n\tv101 = this.adaptToEdge == 2;\n\tif (v101) goto L_005C;\n\tv126 = this.adaptToEdge != 3;\nL_FFFFFFFF:\n\tv91 = 0;\n\tif (v126) goto L_0054;\n\tv45 = this.evaluationMode != 1;\nL_FFFFFFFF:\n\tv90 = relativeSafeArea.y;\n\tif (v45) goto L_005A;\nL_FFFFFFFF:\n\tv168 = relativeSafeArea.y;\n\tgoto L_0075;\nL_FFFFFFFF:\n\tv91 = relativeSafeArea;\nL_005A:\n\tE7.NotchSolution.AdaptationBase::Adapt(this, v90);\n\treturn;\nL_005C:\n\tv195 = relativeSafeArea.height + relativeSafeArea.y;\nL_0075:\n\tv216 = this.adaptToEdge > 1;\n\tif (v216) goto L_009F;\n\tv134 = this.adaptToEdge == 0;\n\tif (v134) goto L_00B2;\n\tv226 = v168 < relativeSafeArea;\n\tv227 = v168 == relativeSafeArea;\n\tv230 = v168 == v168;\n\tv231 = relativeSafeArea == relativeSafeArea;\n\tv232 = v230 & v231;\n\tv233 = ~v232;\n\tv234 = v226 == v233;\n\tv137 = ~v227;\n\tv140 = v234 & v137;\n\tv235 = ~v140;\n\tif (v235) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv173 = v168;\n\tgoto L_0093;\nL_FFFFFFFF:\n\tv173 = relativeSafeArea;\nL_FFFFFFFF:\n\tv168 = v173;\n\tgoto L_0099;\nL_009F:\n\tv221 = this.adaptToEdge == 2;\n\tif (v221) goto L_00B5;\n\tv46 = this.adaptToEdge != 3;\nL_FFFFFFFF:\n\tv90 = v168;\n\tif (v46) goto L_005A;\n\tv262 = relativeSafeArea.height + v174;\n\tgoto L_00B4;\nL_00B2:\n\tv262 = relativeSafeArea.width + relativeSafeArea;\n\tgoto L_00C6;\nL_FFFFFFFF:\n\tv168 = v174;\nL_0054:\n\tv71 = this.evaluationMode == 1;\nL_FFFFFFFF:\n\tv90 = v91;\nL_FFFFFFFF:\n\tv168 = v91;\n\tif (v71) goto L_0075;\nL_005E:\n\tv90 = 1f - v195;\n\tv47 = this.evaluationMode != 1;\nL_FFFFFFFF:\n\tv168 = v90;\n\tif (v47) goto L_005A;\nL_0093:\n\tv131 = this.adaptToEdge != 1;\n\tif (v131) goto L_0099;\nL_0099:\n\tE7.NotchSolution.AdaptationBase::Adapt(this, v168);\n\treturn;\nL_00B5:\n\tv160 = v168 < v174;\n\tv157 = v168 == v174;\n\tv258 = v168 == v168;\n\tv154 = v174 == v174;\n\tv163 = v258 & v154;\n\tv145 = ~v163;\n\tv259 = v160 == v145;\n\tv138 = ~v157;\n\tv141 = v259 & v138;\n\tv132 = ~v141;\n\tif (v132) goto L_FFFFFFFF;\nL_00B4:\n\tv174 = 1f - v262;\nL_00C6:\n\tE7.NotchSolution.AdaptationBase::Adapt(this, v168);\n\treturn;\n")]
		private void AdaptWithRelativeSafeArea(Rect relativeSafeArea)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SafeAdaptation::AdaptWithRelativeSafeArea");
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x3F4673C", Offset = "0x3F4673C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_0021;\nL_0021:\n\tthis.storedSimulatedCutoutsRelative = v51.defaultCutouts;\n\tthis.storedSimulatedSafeAreaRelative = v57.defaultSafeArea;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SafeAdaptation()
		{
			storedSimulatedCutoutsRelative = NotchSolutionUtility.defaultCutouts;
			storedSimulatedSafeAreaRelative = NotchSolutionUtility.defaultSafeArea;
		}
	}
}

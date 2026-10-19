using System;
using AlmostEngine.Screenshot;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AlmostEngine.Examples
{
	[Token(Token = "0x2000009")]
	public class ScreenshotSettingsDebug : MonoBehaviour
	{
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x20")]
		public Text m_DebugText;

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x3C2E954", Offset = "0x3C2E954", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv55 = 0xB2D1000 + 0x90;\n\tgoto L_0019;\nL_0019:\n\tv74 = UnityEngine.Object::FindObjectOfType /* +1 sharing this address */(*([v55 @ X21_v10 (System.Int32)]));\n\tv67 = v74 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0052;\n\tgoto L_00A8;\nL_0052:\n\tgoto L_0054;\nL_0054:\n\tv172 = *([v74 @ X0_v3+20]) + 0x28;\n\tv174 = System.Boolean::ToString(v172);\n\tv143 = System.String::Concat(\"\", \"Export to gallery: \", v174, \"\\n\");\n\tv151 = *([v74 @ X0_v3+20]);\n\tv93 = *([v151 @ X8_v9+10]) != 0;\n\tif (v93) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv123 = 0x20;\n\tgoto L_0078;\nL_FFFFFFFF:\n\tv123 = 0x18;\n\tv111 = v249 == 0;\n\tv90 = ~v111;\n\tv87 = v90;\n\tv253 = System.Boolean::ToString(&v87 @ stack_-41_v2 (System.Boolean));\n\tv256 = System.String::Concat(v248, \"HasGalleryAuthorization \", v253, \"\\n\");\n\tv206 = UnityEngine.UI.Text::set_text(this.m_DebugText, v256);\n\treturn;\nL_00A8:\n\tthrow System.NullReferenceException;\nL_0078:\n\tv242 = AlmostEngine.Screenshot.ScreenshotNameParser::ParsePath(v143, *([v151 @ X8_v9+v123 @ X9_v4 (System.Int32)]));\n\tv248 = System.String::Concat(v143, \"Export path: \", v242, \"\\n\");\n\tv249 = 0x35058(v248, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		private unsafe void OnEnable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotSettingsDebug::OnEnable");
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x3C2EB98", Offset = "0x3C2EB98", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ScreenshotSettingsDebug()
		{
		}
	}
}

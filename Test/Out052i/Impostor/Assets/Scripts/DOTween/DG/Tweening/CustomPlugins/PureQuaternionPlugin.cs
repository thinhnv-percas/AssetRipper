using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.CustomPlugins
{
	[Token(Token = "0x200009F")]
	public class PureQuaternionPlugin : ABSTweenPlugin<Quaternion, Quaternion, NoOptions>
	{
		[Token(Token = "0x40001C5")]
		private static PureQuaternionPlugin _plug;

		[Token(Token = "0x60003B4")]
		[Address(RVA = "0xC2AE40", Offset = "0xC2AE40", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.CustomPlugins.PureQuaternionPlugin;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357B5]) = v34;\nL_0013:\n\tv42 = v36._plug;\n\tv38 = v36._plug == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0025;\n\tv40 = new DG.Tweening.CustomPlugins.PureQuaternionPlugin();\n\tDG.Tweening.CustomPlugins.PureQuaternionPlugin::.ctor(v40);\n\tv51._plug = v40;\n\tv42 = v53._plug;\nL_0025:\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PureQuaternionPlugin Plug()
		{
			PureQuaternionPlugin plug = _plug;
			if (_plug == null)
			{
				PureQuaternionPlugin plug2 = new PureQuaternionPlugin();
				_plug = plug2;
				plug = _plug;
			}
			return plug;
		}

		[Token(Token = "0x60003B5")]
		[Address(RVA = "0xC2AEFC", Offset = "0xC2AEFC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
		}

		[Token(Token = "0x60003B6")]
		[Address(RVA = "0xC2AF00", Offset = "0xC2AF00", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]);\n\tv76 = t.endValue;\n\tv74 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\tv72 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]);\n\tv70 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]);\n\t*([v16 @ X8_v2+18])(v81, *([v16 @ X8_v2+40]), *([v16 @ X8_v2+28]), isRelative, methodInfo, v94, v95, v96, v97, v47, v26, v20, v41, v66, v63, v36, v24);\n\tt.endValue = v47;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) = v26;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) = v20;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) = v41;\n\tv104 = isRelative == 0;\n\tif (v104) goto L_003A;\n\tv105 = t.endValue * v41;\n\tv106 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * v47;\n\tv107 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * v41;\n\tv108 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * v26;\n\tv109 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * v47;\n\tv110 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * v47;\n\tv111 = t.endValue * v47;\n\tv112 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * v41;\n\tv113 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * v41;\n\tv114 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * v20;\n\tv36 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * v26;\n\tv116 = t.endValue * v20;\n\tv117 = t.endValue * v26;\n\tv118 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * v26;\n\tv119 = v105 + v106;\n\tv120 = v107 + v108;\n\tv121 = v112 + v114;\n\tv122 = v113 - v111;\n\tv24 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * v20;\n\tv124 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * v20;\n\tv125 = v36 + v119;\n\tv66 = v116 + v120;\n\tv63 = v110 + v121;\n\tv128 = v122 - v118;\n\tv129 = v125 - v24;\n\tv74 = v66 - v109;\n\tv72 = v63 - v117;\n\tv70 = v128 - v124;\nL_003A:\n\tv88 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+160]);\n\tt.startValue = v76;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]) = v74;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]) = v72;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]) = v70;\n\tv136 = *([v88 @ X8_v3+18]);\n\tv170 = *([v88 @ X8_v3+40]);\n\tv168 = *([v88 @ X8_v3+28]);\n\t// 80 IndirectJump v136 @ X2_v1, v170 @ X0_v5, v170 @ X0_v5, v168 @ X1_v3, v136 @ X2_v1, methodInfo @ X3 (Il2CppMethodInfo), v94 @ X4, v95 @ X5, v96 @ X6, v97 @ X7, v76 @ V11_v3 (UnityEngine.Quaternion), v74 @ V10_v3 (System.Single), v72 @ V9_v3 (System.Single), v70 @ V8_v3 (System.Single), v66 @ V4_v2 (System.Single), v63 @ V5_v2 (System.Single), v36 @ V6_v2 (System.Single), v24 @ V7_v2 (System.Single)\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, bool isRelative)
		{
			//IL_0010: Expected O, but got I
			//IL_0032: Expected F4, but got I
			//IL_0042: Expected F4, but got I
			//IL_0052: Expected F4, but got I
			//IL_032c: Expected O, but got I
			//IL_02f2: Expected O, but got I
			//IL_0302: Expected O, but got I
			//IL_0312: Expected O, but got I
			//IL_02dd: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]");
			object obj = 0;
			Quaternion startValue = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
			float num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			float num3 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v16 @ X8_v2+18] (should have been resolved before IL gen)");
			Quaternion endValue = default(Quaternion);
			t.endValue = endValue;
			if (isRelative)
			{
				object obj2 = default(object);
				float num4 = t.endValue.x * (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				float num5 = 0f * endValue.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num6 = 0f * (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				object obj3 = default(object);
				float num7 = 0f * (float)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num8 = 0f * endValue.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num9 = 0f * endValue.x;
				float num10 = t.endValue.x * endValue.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num11 = 0f * (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				float num12 = 0f * (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				object obj4 = default(object);
				float num13 = 0f * (float)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num14 = 0f * (float)obj3;
				float num15 = t.endValue.x * (float)obj4;
				float num16 = t.endValue.x * (float)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num17 = 0f * (float)obj3;
				float num18 = num4 + num5;
				float num19 = num6 + num7;
				float num20 = num11 + num13;
				float num21 = num12 - num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num22 = 0f * (float)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num23 = 0f * (float)obj4;
				float num24 = num14 + num18;
				float num25 = num15 + num19;
				float num26 = num9 + num20;
				float num27 = num21 - num17;
				float num28 = num24 - num22;
				num = num25 - num8;
				num2 = num26 - num16;
				num3 = num27 - num23;
				startValue = (Quaternion)num28;
			}
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+160]");
				object obj5 = 0;
				t.startValue = startValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v3+18]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v3+40]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v3+28]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v136 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003B7")]
		[Address(RVA = "0xC2B014", Offset = "0xC2B014", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = isRelative == 0;\n\tif (v28) goto L_FFFFFFFF;\n\tv31 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]);\n\t*([v31 @ X8_v4+18])(v141, *([v31 @ X8_v4+40]), *([v31 @ X8_v4+28]), setImmediately, isRelative, methodInfo, v118, v119, v120, fromValue, fromValue.y, fromValue.z, fromValue.w, v82, v88, v85, v79);\n\tv159 = fromValue * fromValue.w;\n\tv160 = fromValue.w * fromValue;\n\tv161 = fromValue.y * fromValue.w;\n\tv162 = fromValue.w * fromValue.y;\n\tv163 = fromValue.z * fromValue.w;\n\tv164 = fromValue.w * fromValue.z;\n\tv165 = fromValue.z * fromValue.y;\n\tv166 = fromValue * fromValue.z;\n\tv167 = v159 + v160;\n\tv168 = fromValue.y * fromValue;\n\tv169 = v161 + v162;\n\tv127 = fromValue.w * fromValue.w;\n\tv126 = fromValue * fromValue;\n\tv170 = v163 + v164;\n\tv171 = fromValue.y * fromValue.z;\n\tv172 = fromValue.z * fromValue;\n\tv173 = fromValue * fromValue.y;\n\tv123 = fromValue.y * fromValue.y;\n\tv174 = v127 - v126;\n\tv175 = v165 + v167;\n\tv176 = v166 + v169;\n\tv177 = v168 + v170;\n\tv122 = fromValue.z * fromValue.z;\n\tv133 = v174 - v123;\n\tv145 = v175 - v171;\n\tv105 = v176 - v172;\n\tv107 = v177 - v173;\n\tv178 = fromValue.w * t.endValue;\n\tv134 = fromValue * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]);\n\tv129 = fromValue.y * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]);\n\tv125 = fromValue.z * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\tv132 = fromValue.w * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\tv128 = fromValue.y * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]);\n\tv124 = fromValue.z * t.endValue;\n\tv131 = fromValue * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]);\n\tv130 = fromValue * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\tv179 = fromValue * t.endValue;\n\tv88 = fromValue.y * t.endValue;\n\tv180 = fromValue.y * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\tv181 = fromValue.w * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]);\n\tv182 = fromValue.w * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]);\n\tv79 = fromValue.z * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]);\n\tv150 = fromValue.z * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]);\n\tv183 = v178 + v134;\n\tv135 = v132 + v128;\n\tv184 = v181 + v79;\n\tv185 = v182 - v179;\n\tv186 = v129 + v183;\n\tv187 = v124 + v135;\n\tv85 = v130 + v184;\n\tv188 = v185 - v180;\n\tv151 = v186 - v125;\n\tv149 = v187 - v131;\n\tv82 = v85 - v88;\n\tv121 = v188 - v150;\n\tt.endValue = v151;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) = v149;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) = v82;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) = v121;\n\tv109 = v133 - v122;\n\tgoto L_0060;\nL_0060:\n\tt.startValue = v103;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]) = v105;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]) = v107;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]) = v109;\n\tv153 = setImmediately == 0;\n\tif (v153) goto L_0082;\n\tv99 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+160]);\n\tv199 = *([v99 @ X8_v3+18]);\n\tv223 = *([v99 @ X8_v3+40]);\n\tv221 = *([v99 @ X8_v3+28]);\n\t// 121 IndirectJump v199 @ X2_v1, v223 @ X0_v4, v223 @ X0_v4, v221 @ X1_v3, v199 @ X2_v1, isRelative @ X3 (System.Boolean), methodInfo @ X4 (Il2CppMethodInfo), v118 @ X5, v119 @ X6, v120 @ X7, v103 @ V11_v3 (UnityEngine.Quaternion), v105 @ V10_v3 (System.Single), v107 @ V9_v3 (System.Single), v109 @ V8_v3 (System.Single), v82 @ V4_v2 (System.Single), v88 @ V5_v2 (System.Single), v85 @ V6_v2 (System.Single), v79 @ V7_v2 (System.Single)\nL_0082:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion fromValue, bool setImmediately, bool isRelative)
		{
			//IL_002d: Expected O, but got I
			//IL_04fa: Expected O, but got F4
			//IL_0520: Expected O, but got F4
			//IL_05a2: Expected O, but got I
			//IL_05b7: Expected O, but got I
			//IL_05c7: Expected O, but got I
			//IL_05d7: Expected O, but got I
			Quaternion startValue;
			if (isRelative)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ X8_v4+18] (should have been resolved before IL gen)");
				Quaternion quaternion = default(Quaternion);
				float num = quaternion.x * fromValue.w;
				float num2 = fromValue.w * quaternion.x;
				float num3 = fromValue.y * fromValue.w;
				float num4 = fromValue.w * fromValue.y;
				float num5 = fromValue.z * fromValue.w;
				float num6 = fromValue.w * fromValue.z;
				float num7 = fromValue.z * fromValue.y;
				float num8 = quaternion.x * fromValue.z;
				float num9 = num + num2;
				float num10 = fromValue.y * quaternion.x;
				float num11 = num3 + num4;
				float num12 = fromValue.w * fromValue.w;
				float num13 = quaternion.x * quaternion.x;
				float num14 = num5 + num6;
				float num15 = fromValue.y * fromValue.z;
				float num16 = fromValue.z * quaternion.x;
				float num17 = quaternion.x * fromValue.y;
				float num18 = fromValue.y * fromValue.y;
				float num19 = num12 - num13;
				float num20 = num7 + num9;
				float num21 = num8 + num11;
				float num22 = num10 + num14;
				float num23 = fromValue.z * fromValue.z;
				float num24 = num19 - num18;
				float num25 = num20 - num15;
				float num26 = num21 - num16;
				float num27 = num22 - num17;
				float num28 = fromValue.w * t.endValue.x;
				float num29 = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				float num30 = num29 * 0f;
				float num31 = fromValue.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num32 = num31 * 0f;
				float num33 = fromValue.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num34 = num33 * 0f;
				float num35 = fromValue.w;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num36 = num35 * 0f;
				float num37 = fromValue.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				float num38 = num37 * 0f;
				float num39 = fromValue.z * t.endValue.x;
				float num40 = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num41 = num40 * 0f;
				float num42 = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num43 = num42 * 0f;
				float num44 = quaternion.x * t.endValue.x;
				float num45 = fromValue.y * t.endValue.x;
				float num46 = fromValue.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				float num47 = num46 * 0f;
				float num48 = fromValue.w;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num49 = num48 * 0f;
				float num50 = fromValue.w;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				float num51 = num50 * 0f;
				float num52 = fromValue.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				float num53 = num52 * 0f;
				float num54 = fromValue.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
				float num55 = num54 * 0f;
				float num56 = num28 + num30;
				float num57 = num36 + num38;
				float num58 = num49 + num53;
				float num59 = num51 - num44;
				float num60 = num32 + num56;
				float num61 = num39 + num57;
				float num62 = num43 + num58;
				float num63 = num59 - num47;
				float num64 = num60 - num34;
				float num65 = num61 - num41;
				float num66 = num62 - num45;
				float num67 = num63 - num55;
				t.endValue = (Quaternion)num64;
				float num68 = num24 - num23;
				startValue = (Quaternion)num25;
			}
			else
			{
				startValue = fromValue;
				float num26 = fromValue.y;
				float num27 = fromValue.z;
				float num68 = fromValue.w;
			}
			t.startValue = startValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+160]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v3+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v3+40]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v3+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v199 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003B8")]
		[Address(RVA = "0xC2B1C8", Offset = "0xC2B1C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Quaternion ConvertToStartValue(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion value)
		{
			return value;
		}

		[Token(Token = "0x60003B9")]
		[Address(RVA = "0xC2B1CC", Offset = "0xC2B1CC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * t.startValue;\n\tv13 = t.endValue * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]);\n\tv14 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]);\n\tv15 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]);\n\tv16 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]);\n\tv17 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]);\n\tv18 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * t.startValue;\n\tv19 = t.endValue * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]);\n\tv20 = t.endValue * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]);\n\tv21 = t.endValue * t.startValue;\n\tv22 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * t.startValue;\n\tv23 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]);\n\tv24 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]);\n\tv25 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]);\n\tv26 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]);\n\tv27 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) * *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]);\n\tv28 = v12 + v13;\n\tv29 = v16 + v17;\n\tv30 = v24 + v26;\n\tv31 = v25 - v21;\n\tv32 = v14 + v28;\n\tv33 = v18 + v29;\n\tv34 = v20 + v30;\n\tv35 = v31 - v23;\n\tv36 = v32 - v15;\n\tv37 = v33 - v19;\n\tv38 = v34 - v22;\n\tv39 = v35 - v27;\n\tt.endValue = v36;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) = v37;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]) = v38;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) = v39;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
			//IL_005f: Expected O, but got I
			//IL_007c: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_017a: Expected O, but got I
			//IL_0197: Expected O, but got I
			//IL_01b4: Expected O, but got I
			//IL_01d1: Expected O, but got I
			//IL_01ee: Expected O, but got I
			//IL_020c: Expected O, but got I
			//IL_021b: Expected O, but got I
			//IL_02af: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			float num = 0f * t.startValue.x;
			float num2 = t.endValue.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]");
			float num3 = num2 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]");
			object obj = num4 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]");
			object obj2 = num5 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]");
			object obj3 = num6 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]");
			object obj4 = num7 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
			float num8 = 0f * t.startValue.x;
			float num9 = t.endValue.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]");
			float num10 = num9 * 0f;
			float num11 = t.endValue.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]");
			float num12 = num11 * 0f;
			float num13 = t.endValue.x * t.startValue.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			float num14 = 0f * t.startValue.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]");
			object obj5 = num15 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]");
			object obj6 = num16 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]");
			object obj7 = num17 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]");
			object obj8 = num18 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+13C]");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+12C]");
			object obj9 = num19 * 0;
			float num20 = num + num3;
			object obj10 = (nint)obj3 + (nint)obj4;
			object obj11 = (nint)obj6 + (nint)obj8;
			float num21 = (float)obj7 - num13;
			float num22 = (float)obj + num20;
			float num23 = num8 + (float)obj10;
			float num24 = num12 + (float)obj11;
			float num25 = num21 - (float)obj5;
			float num26 = num22 - (float)obj2;
			float num27 = num23 - num10;
			float num28 = num24 - num14;
			float num29 = num25 - (float)obj9;
			t.endValue = (Quaternion)num26;
		}

		[Token(Token = "0x60003BA")]
		[Address(RVA = "0xC2B280", Offset = "0xC2B280", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.changeValue = t.endValue;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
			t.changeValue = t.endValue;
		}

		[Token(Token = "0x60003BB")]
		[Address(RVA = "0xC2B2A4", Offset = "0xC2B2A4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = UnityEngine.Quaternion::Internal_ToEulerRad(changeValue);\n\tv30 = v24 * 57.29578f;\n\tv31 = v24.y * 57.29578f;\n\tv32 = v24.z * 57.29578f;\n\t// 26 MakeStruct v33 @ AGGC2F2E4_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v30 @ V0_v3 (System.Single), v31 @ V1_v3 (System.Single), v32 @ V2_v4 (System.Single)\n\tv34 = UnityEngine.Quaternion::Internal_MakePositive(v33);\n\tgoto L_0031;\n\tv45 = System.Math;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, options, methodInfo, v49, v50, v51, v52, v53, v34, v35, v36, v28, v3, v54, v55, v56);\n\tv58 = 1;\n\t*([1A35759]) = v58;\nL_0031:\n\tgoto L_0033;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v62, options, methodInfo, v49, v50, v51, v52, v53, v34, v35, v36, v28, v3, v54, v55, v56);\nL_0033:\n\tv68 = v34 * v34;\n\tv69 = v34.y * v34.y;\n\tv70 = v68 + v69;\n\tv71 = v34.z * v34.z;\n\tv72 = v71 + v70;\n\tv73 = UnityEngine.Mathf::Sqrt(v72);\n\treturnVal1 = v73 / unitsXSecond;\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, Quaternion changeValue)
		{
			Vector3 vector = Quaternion.Internal_ToEulerRad(changeValue);
			float x = vector.x * 57.29578f;
			float y = vector.y * 57.29578f;
			float z = vector.z * 57.29578f;
			Vector3 euler = default(Vector3);
			euler.x = x;
			euler.y = y;
			euler.z = z;
			Vector3 vector2 = Quaternion.Internal_MakePositive(euler);
			float num = vector2.x * vector2.x;
			float num2 = vector2.y * vector2.y;
			float num3 = num + num2;
			float num4 = vector2.z * vector2.z;
			float f = num4 + num3;
			float num5 = Mathf.Sqrt(f);
			return num5 / unitsXSecond;
		}

		[Token(Token = "0x60003BC")]
		[Address(RVA = "0xC2B358", Offset = "0xC2B358", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv47 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod);\n\t// 43 MakeStruct v51 @ AGGC2F3D0_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), changeValue @ stack_0 (UnityEngine.Quaternion), v42 @ stack_4, updateNotice @ stack_8 (DG.Tweening.Core.Enums.UpdateNotice), v38 @ stack_C\n\tv68 = UnityEngine.Quaternion::Slerp(startValue, v51, v47);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(setter, setter.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Quaternion startValue, Quaternion changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0031: Expected F4, but got I
			//IL_0054: Expected F4, but got O
			//IL_0061: Expected F4, but got I4
			//IL_006e: Expected F4, but got O
			//IL_009a: Expected O, but got I
			IntPtr intPtr = default(IntPtr);
			float t2 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, (nint)intPtr, t.easeOvershootOrAmplitude, t.easePeriod);
			Quaternion b = default(Quaternion);
			Quaternion quaternion = default(Quaternion);
			b.x = quaternion.x;
			object obj = default(object);
			b.y = (float)obj;
			b.z = (float)updateNotice;
			object obj2 = default(object);
			b.w = (float)obj2;
			Quaternion quaternion2 = Quaternion.Slerp(startValue, b, t2);
			setter((Quaternion)(nint)setter.method);
		}

		[Token(Token = "0x60003BD")]
		[Address(RVA = "0xC2AEB4", Offset = "0xC2AEB4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357B6]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PureQuaternionPlugin()
		{
		}
	}
}

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
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]);\n\tv74 = t.endValue.y;\n\tv72 = t.endValue.z;\n\tv70 = t.endValue.w;\n\t*([v16 @ X8_v2+18])(v81, *([v16 @ X8_v2+40]), *([v16 @ X8_v2+28]), isRelative, methodInfo, v94, v95, v96, v97, v47, v26, v20, v41, v66, v63, v36, v24);\n\tt.endValue.x = v47;\n\tt.endValue.y = v26;\n\tt.endValue.z = v20;\n\tt.endValue.w = v41;\n\tv104 = isRelative == 0;\n\tif (v104) goto L_003A;\n\tv105 = t.endValue * v41;\n\tv106 = t.endValue.w * v47;\n\tv107 = t.endValue.y * v41;\n\tv108 = t.endValue.w * v26;\n\tv109 = t.endValue.z * v47;\n\tv110 = t.endValue.y * v47;\n\tv111 = t.endValue * v47;\n\tv112 = t.endValue.z * v41;\n\tv113 = t.endValue.w * v41;\n\tv114 = t.endValue.w * v20;\n\tv36 = t.endValue.z * v26;\n\tv116 = t.endValue * v20;\n\tv117 = t.endValue * v26;\n\tv118 = t.endValue.y * v26;\n\tv119 = v105 + v106;\n\tv120 = v107 + v108;\n\tv121 = v112 + v114;\n\tv122 = v113 - v111;\n\tv24 = t.endValue.y * v20;\n\tv124 = t.endValue.z * v20;\n\tv125 = v36 + v119;\n\tv66 = v116 + v120;\n\tv63 = v110 + v121;\n\tv128 = v122 - v118;\n\tv76 = v125 - v24;\n\tv74 = v66 - v109;\n\tv72 = v63 - v117;\n\tv70 = v128 - v124;\nL_003A:\n\tv88 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+160]);\n\tt.startValue.x = v76;\n\tt.startValue.y = v74;\n\tt.startValue.z = v72;\n\tt.startValue.w = v70;\n\tv136 = *([v88 @ X8_v3+18]);\n\tv170 = *([v88 @ X8_v3+40]);\n\tv168 = *([v88 @ X8_v3+28]);\n\t// 80 IndirectJump v136 @ X2_v1, v170 @ X0_v5, v170 @ X0_v5, v168 @ X1_v3, v136 @ X2_v1, methodInfo @ X3 (Il2CppMethodInfo), v94 @ X4, v95 @ X5, v96 @ X6, v97 @ X7, v76 @ V11_v3 (System.Single), v74 @ V10_v3 (System.Single), v72 @ V9_v3 (System.Single), v70 @ V8_v3 (System.Single), v66 @ V4_v2 (System.Single), v63 @ V5_v2 (System.Single), v36 @ V6_v2 (System.Single), v24 @ V7_v2 (System.Single)\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, bool isRelative)
		{
			//IL_0010: Expected O, but got I
			//IL_035f: Expected O, but got I
			//IL_0325: Expected O, but got I
			//IL_0335: Expected O, but got I
			//IL_0345: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]");
			object obj = 0;
			float y = t.endValue.y;
			float z = t.endValue.z;
			float w = t.endValue.w;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v16 @ X8_v2+18] (should have been resolved before IL gen)");
			float num = default(float);
			t.endValue.x = num;
			float num2 = default(float);
			t.endValue.y = num2;
			float num3 = default(float);
			t.endValue.z = num3;
			float num4 = default(float);
			t.endValue.w = num4;
			bool flag = !isRelative;
			float x = t.endValue.x;
			if (!flag)
			{
				float num5 = t.endValue.x * num4;
				float num6 = t.endValue.w * num;
				float num7 = t.endValue.y * num4;
				float num8 = t.endValue.w * num2;
				float num9 = t.endValue.z * num;
				float num10 = t.endValue.y * num;
				float num11 = t.endValue.x * num;
				float num12 = t.endValue.z * num4;
				float num13 = t.endValue.w * num4;
				float num14 = t.endValue.w * num3;
				float num15 = t.endValue.z * num2;
				float num16 = t.endValue.x * num3;
				float num17 = t.endValue.x * num2;
				float num18 = t.endValue.y * num2;
				float num19 = num5 + num6;
				float num20 = num7 + num8;
				float num21 = num12 + num14;
				float num22 = num13 - num11;
				float num23 = t.endValue.y * num3;
				float num24 = t.endValue.z * num3;
				float num25 = num15 + num19;
				float num26 = num16 + num20;
				float num27 = num10 + num21;
				float num28 = num22 - num18;
				x = num25 - num23;
				y = num26 - num9;
				z = num27 - num17;
				w = num28 - num24;
			}
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+160]");
				object obj2 = 0;
				t.startValue.x = x;
				t.startValue.y = y;
				t.startValue.z = z;
				t.startValue.w = w;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v3+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v3+40]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v3+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v136 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003B7")]
		[Address(RVA = "0xC2B014", Offset = "0xC2B014", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = isRelative == 0;\n\tif (v28) goto L_FFFFFFFF;\n\tv31 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]);\n\t*([v31 @ X8_v4+18])(v141, *([v31 @ X8_v4+40]), *([v31 @ X8_v4+28]), setImmediately, isRelative, methodInfo, v118, v119, v120, fromValue, fromValue.y, fromValue.z, fromValue.w, v82, v88, v85, v79);\n\tv159 = fromValue * fromValue.w;\n\tv160 = fromValue.w * fromValue;\n\tv161 = fromValue.y * fromValue.w;\n\tv162 = fromValue.w * fromValue.y;\n\tv163 = fromValue.z * fromValue.w;\n\tv164 = fromValue.w * fromValue.z;\n\tv165 = fromValue.z * fromValue.y;\n\tv166 = fromValue * fromValue.z;\n\tv167 = v159 + v160;\n\tv168 = fromValue.y * fromValue;\n\tv169 = v161 + v162;\n\tv127 = fromValue.w * fromValue.w;\n\tv126 = fromValue * fromValue;\n\tv170 = v163 + v164;\n\tv171 = fromValue.y * fromValue.z;\n\tv172 = fromValue.z * fromValue;\n\tv173 = fromValue * fromValue.y;\n\tv123 = fromValue.y * fromValue.y;\n\tv174 = v127 - v126;\n\tv175 = v165 + v167;\n\tv176 = v166 + v169;\n\tv177 = v168 + v170;\n\tv122 = fromValue.z * fromValue.z;\n\tv133 = v174 - v123;\n\tv145 = v175 - v171;\n\tv105 = v176 - v172;\n\tv107 = v177 - v173;\n\tv178 = fromValue.w * t.endValue;\n\tv134 = fromValue * t.endValue.w;\n\tv129 = fromValue.y * t.endValue.z;\n\tv125 = fromValue.z * t.endValue.y;\n\tv132 = fromValue.w * t.endValue.y;\n\tv128 = fromValue.y * t.endValue.w;\n\tv124 = fromValue.z * t.endValue;\n\tv131 = fromValue * t.endValue.z;\n\tv130 = fromValue * t.endValue.y;\n\tv179 = fromValue * t.endValue;\n\tv88 = fromValue.y * t.endValue;\n\tv180 = fromValue.y * t.endValue.y;\n\tv181 = fromValue.w * t.endValue.z;\n\tv182 = fromValue.w * t.endValue.w;\n\tv79 = fromValue.z * t.endValue.w;\n\tv150 = fromValue.z * t.endValue.z;\n\tv183 = v178 + v134;\n\tv135 = v132 + v128;\n\tv184 = v181 + v79;\n\tv185 = v182 - v179;\n\tv186 = v129 + v183;\n\tv187 = v124 + v135;\n\tv85 = v130 + v184;\n\tv188 = v185 - v180;\n\tv151 = v186 - v125;\n\tv149 = v187 - v131;\n\tv82 = v85 - v88;\n\tv121 = v188 - v150;\n\tt.endValue.x = v151;\n\tt.endValue.y = v149;\n\tt.endValue.z = v82;\n\tt.endValue.w = v121;\n\tv109 = v133 - v122;\n\tgoto L_0060;\nL_0060:\n\tt.startValue.x = v103;\n\tt.startValue.y = v105;\n\tt.startValue.z = v107;\n\tt.startValue.w = v109;\n\tv153 = setImmediately == 0;\n\tif (v153) goto L_0082;\n\tv99 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+160]);\n\tv199 = *([v99 @ X8_v3+18]);\n\tv223 = *([v99 @ X8_v3+40]);\n\tv221 = *([v99 @ X8_v3+28]);\n\t// 121 IndirectJump v199 @ X2_v1, v223 @ X0_v4, v223 @ X0_v4, v221 @ X1_v3, v199 @ X2_v1, isRelative @ X3 (System.Boolean), methodInfo @ X4 (Il2CppMethodInfo), v118 @ X5, v119 @ X6, v120 @ X7, v103 @ V11_v3 (UnityEngine.Quaternion), v105 @ V10_v3 (System.Single), v107 @ V9_v3 (System.Single), v109 @ V8_v3 (System.Single), v82 @ V4_v2 (System.Single), v88 @ V5_v2 (System.Single), v85 @ V6_v2 (System.Single), v79 @ V7_v2 (System.Single)\nL_0082:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion fromValue, bool setImmediately, bool isRelative)
		{
			//IL_002d: Expected O, but got I
			//IL_0564: Expected O, but got F4
			//IL_0617: Expected O, but got I
			//IL_062c: Expected O, but got I
			//IL_063c: Expected O, but got I
			//IL_064c: Expected O, but got I
			float y;
			float z;
			float w2;
			Quaternion quaternion2;
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
				y = num21 - num16;
				z = num22 - num17;
				float num26 = fromValue.w * t.endValue.x;
				float num27 = quaternion.x * t.endValue.w;
				float num28 = fromValue.y * t.endValue.z;
				float num29 = fromValue.z * t.endValue.y;
				float num30 = fromValue.w * t.endValue.y;
				float num31 = fromValue.y * t.endValue.w;
				float num32 = fromValue.z * t.endValue.x;
				float num33 = quaternion.x * t.endValue.z;
				float num34 = quaternion.x * t.endValue.y;
				float num35 = quaternion.x * t.endValue.x;
				float num36 = fromValue.y * t.endValue.x;
				float num37 = fromValue.y * t.endValue.y;
				float num38 = fromValue.w * t.endValue.z;
				float num39 = fromValue.w * t.endValue.w;
				float num40 = fromValue.z * t.endValue.w;
				float num41 = fromValue.z * t.endValue.z;
				float num42 = num26 + num27;
				float num43 = num30 + num31;
				float num44 = num38 + num40;
				float num45 = num39 - num35;
				float num46 = num28 + num42;
				float num47 = num32 + num43;
				float num48 = num34 + num44;
				float num49 = num45 - num37;
				float x = num46 - num29;
				float y2 = num47 - num33;
				float z2 = num48 - num36;
				float w = num49 - num41;
				t.endValue.x = x;
				t.endValue.y = y2;
				t.endValue.z = z2;
				t.endValue.w = w;
				w2 = num24 - num23;
				quaternion2 = (Quaternion)num25;
			}
			else
			{
				quaternion2 = fromValue;
				y = fromValue.y;
				z = fromValue.z;
				w2 = fromValue.w;
			}
			t.startValue.x = quaternion2.x;
			t.startValue.y = y;
			t.startValue.z = z;
			t.startValue.w = w2;
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
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = t.endValue.w * t.startValue;\n\tv13 = t.endValue * t.startValue.w;\n\tv14 = t.endValue.y * t.startValue.z;\n\tv15 = t.endValue.z * t.startValue.y;\n\tv16 = t.endValue.w * t.startValue.y;\n\tv17 = t.endValue.y * t.startValue.w;\n\tv18 = t.endValue.z * t.startValue;\n\tv19 = t.endValue * t.startValue.z;\n\tv20 = t.endValue * t.startValue.y;\n\tv21 = t.endValue * t.startValue;\n\tv22 = t.endValue.y * t.startValue;\n\tv23 = t.endValue.y * t.startValue.y;\n\tv24 = t.endValue.w * t.startValue.z;\n\tv25 = t.endValue.w * t.startValue.w;\n\tv26 = t.endValue.z * t.startValue.w;\n\tv27 = t.endValue.z * t.startValue.z;\n\tv28 = v12 + v13;\n\tv29 = v16 + v17;\n\tv30 = v24 + v26;\n\tv31 = v25 - v21;\n\tv32 = v14 + v28;\n\tv33 = v18 + v29;\n\tv34 = v20 + v30;\n\tv35 = v31 - v23;\n\tv36 = v32 - v15;\n\tv37 = v33 - v19;\n\tv38 = v34 - v22;\n\tv39 = v35 - v27;\n\tt.endValue.x = v36;\n\tt.endValue.y = v37;\n\tt.endValue.z = v38;\n\tt.endValue.w = v39;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
			float num = t.endValue.w * t.startValue.x;
			float num2 = t.endValue.x * t.startValue.w;
			float num3 = t.endValue.y * t.startValue.z;
			float num4 = t.endValue.z * t.startValue.y;
			float num5 = t.endValue.w * t.startValue.y;
			float num6 = t.endValue.y * t.startValue.w;
			float num7 = t.endValue.z * t.startValue.x;
			float num8 = t.endValue.x * t.startValue.z;
			float num9 = t.endValue.x * t.startValue.y;
			float num10 = t.endValue.x * t.startValue.x;
			float num11 = t.endValue.y * t.startValue.x;
			float num12 = t.endValue.y * t.startValue.y;
			float num13 = t.endValue.w * t.startValue.z;
			float num14 = t.endValue.w * t.startValue.w;
			float num15 = t.endValue.z * t.startValue.w;
			float num16 = t.endValue.z * t.startValue.z;
			float num17 = num + num2;
			float num18 = num5 + num6;
			float num19 = num13 + num15;
			float num20 = num14 - num10;
			float num21 = num3 + num17;
			float num22 = num7 + num18;
			float num23 = num9 + num19;
			float num24 = num20 - num12;
			float x = num21 - num4;
			float y = num22 - num8;
			float z = num23 - num11;
			float w = num24 - num16;
			t.endValue.x = x;
			t.endValue.y = y;
			t.endValue.z = z;
			t.endValue.w = w;
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

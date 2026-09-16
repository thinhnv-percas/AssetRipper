using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000004")]
	public static class DOTweenProShortcuts
	{
		[Token(Token = "0x6000027")]
		[Address(RVA = "0x15B8498", Offset = "0x15B8498", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EAFCE0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202990B]) = v35;\nL_0014:\n\tv39 = new DG.Tweening.Plugins.SpiralPlugin();\n\tDG.Tweening.Plugins.SpiralPlugin::.ctor(v39);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static DOTweenProShortcuts()
		{
			SpiralPlugin spiralPlugin = new SpiralPlugin();
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15B84E8", Offset = "0x15B84E8", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv60 = *([1EE21D0]);\n\tv61 = *([v60 @ X8_v55]);\n\tv62 = \"il2cpp_codegen_initialize_method\"(v61, axis, mode, snapping, methodInfo, v63, v64, v65, duration, speed, frequency, depth, v66, v67, v68, v69);\n\tv72 = 0 | 1;\n\t*([202990C]) = v72;\nL_002C:\n\tv76 = new DG.Tweening.DOTweenProShortcuts+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v76);\n\tv76.target = target;\n\tgoto L_0042;\n\tv87 = *([v82 @ X0_v7+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0042;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v82, v77, mode, snapping, methodInfo, v63, v64, v65, duration, speed, frequency, depth, v66, v67, v68, v69);\nL_0042:\n\tv97 = UnityEngine.Mathf::Approximately(speed, 0f);\n\tv147 = v97 == 0;\n\tv180 = mode & 0xFF00000000;\n\tv138 = ~v147;\n\tv135 = ~v138;\n\tif (v135) goto L_FFFFFFFF;\n\tgoto L_0051;\nL_0051:\n\tv240 = v180 == 0;\n\tif (v240) goto L_008F;\n\tv245 = axis >> 0x20;\n\tgoto L_0068;\n\tv300 = *([v248 @ X0_v36+E0]);\n\tv301 = v300 == 0;\n\tv302 = ~v301;\n\tif (v302) goto L_0068;\n\tv304 = \"il2cpp_codegen_runtime_class_init\"(v248, v77, mode, snapping, methodInfo, v63, v64, v65, v179, v94, frequency, depth, v66, v67, v68, v69);\nL_0068:\n\tv308 = UnityEngine.Vector3::get_zero();\n\tgoto L_007F;\n\tv333 = *([v320 @ X0_v39+E0]);\n\tv334 = v333 == 0;\n\tv335 = ~v334;\n\tif (v335) goto L_007F;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v320, v77, mode, snapping, methodInfo, v63, v64, v65, v308, v318, v319, depth, v66, v67, v68, v69);\nL_007F:\n\t// 127 MakeStruct v258 @ AGG15B8648_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), axis @ X1 (System.Nullable`1<UnityEngine.Vector3>), v245 @ X9_v8 (System.Int32), mode @ X2 (DG.Tweening.SpiralMode)\n\tv281 = UnityEngine.Vector3::op_Equality(v258, v308);\n\tv283 = v281 == 0;\n\tif (v283) goto L_00A4;\nL_008F:\n\tgoto L_0096;\n\tv309 = *([v296 @ X0_v30+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_0096;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v296, v77, mode, snapping, methodInfo, v63, v64, v65, v276, v278, v267, v263, v261, v259, v68, v69);\nL_0096:\n\tv317 = UnityEngine.Vector3::get_forward();\n\tv326 = v317.y;\n\tv327 = v317.z;\n\tv332 = 0x115D2C0(&axis @ X1 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, mode, snapping, methodInfo, v63, v64, v65, v317, v317.y, v317.z, v263, v308.y, v308.z, v68, v69);\nL_00A4:\n\tgoto L_00AB;\n\tv360 = *([v355 @ X0_v12+E0]);\n\tv361 = v360 == 0;\n\tv362 = ~v361;\n\tif (v362) goto L_00AB;\n\tv364 = \"il2cpp_codegen_runtime_class_init\"(v355, v347, mode, snapping, methodInfo, v63, v64, v65, v345, v346, v341, v340, v111, v109, v68, v69);\nL_00AB:\n\tv368 = DG.Tweening.Plugins.SpiralPlugin::Get();\n\tv373 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v373, v76, Il2CppMethodInfo);\n\tv384 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v384, v76, Il2CppMethodInfo);\n\tv395 = 0x115D2DC(&axis @ X1 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, Il2CppMethodInfo, Il2CppMethodInfo, methodInfo, v63, v64, v65, v317, v326, v327, v340, v111, v109, v68, v69);\n\tgoto L_00E6;\n\tv402 = *([v398 @ X0_v22+E0]);\n\tv403 = v402 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_00E6;\n\tv406 = \"il2cpp_codegen_runtime_class_init\"(v398, v394, v389, v390, methodInfo, v63, v64, v65, v345, v346, v341, v340, v111, v109, v68, v69);\nL_00E6:\n\tv414 = DG.Tweening.DOTween::To /* +1 sharing this address */(v368, v373, v384, Il2CppMethodInfo, v317, methodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v414, v76.target);\n\tv234 = methodInfo & 1;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+14C]) = snapping;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+148]) = v132;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+144]) = v172;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+140]) = v174;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+150]) = v234;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 184 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOSpiral(this Transform target, float duration, Vector3? axis = null, SpiralMode mode = SpiralMode.Expand, float speed = 1f, float frequency = 10f, float depth = 0f, bool snapping = false)
		{
			//IL_004a: Expected I4, but got I8
			//IL_01c9: Expected O, but got F4
			//IL_0097: Expected I4, but got O
			//IL_00b7: Expected F4, but got O
			//IL_00d2: Expected F4, but got I4
			//IL_0139: Expected F4, but got I4
			bool flag = Mathf.Approximately(speed, 0f);
			bool flag2 = !flag;
			int num = (int)((long)mode & 0xFF00000000L);
			float num2 = (flag2 ? speed : 1f);
			bool flag3 = num == 0;
			float num3 = depth;
			float num4 = frequency;
			float num5 = depth;
			Vector3 zero = default(Vector3);
			Vector3 vector2;
			float num9;
			float num7;
			float z;
			float y;
			object obj;
			float num8;
			float num10;
			float num11;
			if (!flag3)
			{
				int num6 = (object?)axis >> 32;
				zero = Vector3.zero;
				Vector3 vector = default(Vector3);
				vector.x = (float)axis;
				vector.y = num6;
				vector.z = (float)mode;
				bool flag4 = vector == zero;
				bool flag5 = !flag4;
				num3 = zero.x;
				num4 = frequency;
				num5 = depth;
				z = zero.z;
				y = zero.y;
				obj = zero;
				num7 = (float)mode;
				num8 = num2;
				vector2 = (Vector3)axis;
				num9 = num6;
				num10 = frequency;
				num11 = depth;
				if (flag5)
				{
					goto IL_01eb;
				}
			}
			vector2 = Vector3.forward;
			num9 = vector2.y;
			num7 = vector2.z;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
			z = zero.z;
			y = zero.y;
			obj = num3;
			num8 = num2;
			num10 = num4;
			num11 = num5;
			goto IL_01eb;
			IL_01eb:
			ABSTweenPlugin<Vector3, Vector3, SpiralOptions> aBSTweenPlugin = SpiralPlugin.Get();
			DOGetter<Vector3> dOGetter = () => target.localPosition;
			DOSetter<Vector3> dOSetter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2DC (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xE4)");
			Il2CppRuntime.Boundary("MANAGED", "Method not found @13632B8 (DG.Tweening.DOTween::To, and 1 more at this address)");
			TweenerCore<Vector3, Vector3, SpiralOptions> t = default(TweenerCore<Vector3, Vector3, SpiralOptions>);
			Tweener result = t.SetTarget(target);
			IntPtr intPtr = default(IntPtr);
			int num12 = (int)((long)intPtr & 1L);
			return result;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x15B8804", Offset = "0x15B8804", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_002D;\n\tv62 = *([1EB6298]);\n\tv63 = *([v62 @ X8_v55]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, axis, mode, snapping, methodInfo, v65, v66, v67, duration, speed, frequency, depth, v68, v69, v70, v71);\n\tv74 = 0 | 1;\n\t*([202990D]) = v74;\nL_002D:\n\tv78 = new DG.Tweening.DOTweenProShortcuts+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v78);\n\tv78.target = target;\n\tgoto L_0043;\n\tv89 = *([v84 @ X0_v7+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0043;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v84, v79, mode, snapping, methodInfo, v65, v66, v67, duration, speed, frequency, depth, v68, v69, v70, v71);\nL_0043:\n\tv99 = UnityEngine.Mathf::Approximately(speed, 0f);\n\tv145 = v99 == 0;\n\tv178 = mode & 0xFF00000000;\n\tv136 = ~v145;\n\tv133 = ~v136;\n\tif (v133) goto L_FFFFFFFF;\n\tgoto L_0052;\nL_0052:\n\tv238 = v178 == 0;\n\tif (v238) goto L_0090;\n\t*([v34 @ X29_v1-38]) = v268;\n\t*([v34 @ X29_v1-34]) = duration;\n\tv241 = axis >> 0x20;\n\tgoto L_0069;\n\tv294 = *([v244 @ X0_v36+E0]);\n\tv295 = v294 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_0069;\n\tv298 = \"il2cpp_codegen_runtime_class_init\"(v244, v79, mode, snapping, methodInfo, v65, v66, v67, v177, v96, frequency, depth, v68, v69, v70, v71);\nL_0069:\n\tv302 = UnityEngine.Vector3::get_zero();\n\tgoto L_0080;\n\tv327 = *([v314 @ X0_v39+E0]);\n\tv328 = v327 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_0080;\n\tv331 = \"il2cpp_codegen_runtime_class_init\"(v314, v79, mode, snapping, methodInfo, v65, v66, v67, v302, v312, v313, depth, v68, v69, v70, v71);\nL_0080:\n\t// 128 MakeStruct v254 @ AGG15B8968_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), axis @ X1 (System.Nullable`1<UnityEngine.Vector3>), v241 @ X9_v8 (System.Int32), mode @ X2 (DG.Tweening.SpiralMode)\n\tv275 = UnityEngine.Vector3::op_Equality(v254, v302);\n\tv268 = *([v34 @ X29_v1-38]);\n\tv277 = v275 == 0;\n\tif (v277) goto L_00A5;\nL_0090:\n\tgoto L_0097;\n\tv303 = *([v290 @ X0_v30+E0]);\n\tv304 = v303 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_0097;\n\tv307 = \"il2cpp_codegen_runtime_class_init\"(v290, v79, mode, snapping, methodInfo, v65, v66, v67, v270, v272, v263, v259, v257, v255, v70, v71);\nL_0097:\n\tv311 = UnityEngine.Vector3::get_forward();\n\tv320 = v311.y;\n\tv321 = v311.z;\n\tv326 = 0x115D2C0(&axis @ X1 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, mode, snapping, methodInfo, v65, v66, v67, v311, v311.y, v311.z, v259, v302.y, v302.z, v70, v71);\nL_00A5:\n\tgoto L_00AC;\n\tv354 = *([v349 @ X0_v12+E0]);\n\tv355 = v354 == 0;\n\tv356 = ~v355;\n\tif (v356) goto L_00AC;\n\tv358 = \"il2cpp_codegen_runtime_class_init\"(v349, v341, mode, snapping, methodInfo, v65, v66, v67, v339, v340, v335, v334, v115, v113, v70, v71);\nL_00AC:\n\tv362 = DG.Tweening.Plugins.SpiralPlugin::Get();\n\tv367 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v367, v78, Il2CppMethodInfo);\n\tv378 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v378, v78.target, Il2CppMethodInfo);\n\tv389 = 0x115D2DC(&axis @ X1 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, Il2CppMethodInfo, Il2CppMethodInfo, methodInfo, v65, v66, v67, v311, v320, v321, v334, v115, v113, v70, v71);\n\tgoto L_00E8;\n\tv396 = *([v392 @ X0_v22+E0]);\n\tv397 = v396 == 0;\n\tv398 = ~v397;\n\tif (v398) goto L_00E8;\n\tv400 = \"il2cpp_codegen_runtime_class_init\"(v392, v388, v383, v384, methodInfo, v65, v66, v67, v339, v340, v335, v334, v115, v113, v70, v71);\nL_00E8:\n\tv408 = DG.Tweening.DOTween::To /* +1 sharing this address */(v362, v367, v378, Il2CppMethodInfo, v311, methodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v408, v78.target);\n\tv232 = methodInfo & 1;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+14C]) = snapping;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+148]) = v130;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+144]) = v170;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+140]) = v172;\n\t*([returnVal2 @ X0_v26 (DG.Tweening.Tweener)+150]) = v232;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 183 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOSpiral(this Rigidbody target, float duration, Vector3? axis = null, SpiralMode mode = SpiralMode.Expand, float speed = 1f, float frequency = 10f, float depth = 0f, bool snapping = false)
		{
			//IL_0052: Expected I4, but got I8
			//IL_01f3: Expected O, but got F4
			//IL_00a9: Expected I4, but got O
			//IL_00c9: Expected F4, but got O
			//IL_00e4: Expected F4, but got I4
			//IL_0105: Expected F4, but got I
			//IL_015b: Expected F4, but got I4
			//IL_016b: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			bool flag = Mathf.Approximately(speed, 0f);
			bool flag2 = !flag;
			int num = (int)((long)mode & 0xFF00000000L);
			float num2 = (flag2 ? speed : 1f);
			bool flag3 = num == 0;
			float num3 = depth;
			float num4 = frequency;
			float num5 = depth;
			Vector3 zero = default(Vector3);
			Vector3 vector2;
			float num9;
			float num7;
			float z;
			float y;
			object obj3;
			float num8;
			float num10;
			float num11;
			if (!flag3)
			{
				int num6 = (object?)axis >> 32;
				zero = Vector3.zero;
				Vector3 vector = default(Vector3);
				vector.x = (float)axis;
				vector.y = num6;
				vector.z = (float)mode;
				bool flag4 = vector == zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
				num2 = 0f;
				bool flag5 = !flag4;
				num3 = zero.x;
				num4 = frequency;
				num5 = depth;
				z = zero.z;
				y = zero.y;
				obj3 = zero;
				num7 = (float)mode;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
				num8 = 0f;
				vector2 = (Vector3)axis;
				num9 = num6;
				num10 = frequency;
				num11 = depth;
				if (flag5)
				{
					goto IL_0215;
				}
			}
			vector2 = Vector3.forward;
			num9 = vector2.y;
			num7 = vector2.z;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
			z = zero.z;
			y = zero.y;
			obj3 = num3;
			num8 = num2;
			num10 = num4;
			num11 = num5;
			goto IL_0215;
			IL_0215:
			ABSTweenPlugin<Vector3, Vector3, SpiralOptions> aBSTweenPlugin = SpiralPlugin.Get();
			DOGetter<Vector3> dOGetter = () => target.position;
			DOSetter<Vector3> dOSetter = target.MovePosition;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2DC (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xE4)");
			Il2CppRuntime.Boundary("MANAGED", "Method not found @13632B8 (DG.Tweening.DOTween::To, and 1 more at this address)");
			TweenerCore<Vector3, Vector3, SpiralOptions> t = default(TweenerCore<Vector3, Vector3, SpiralOptions>);
			Tweener result = t.SetTarget(target);
			IntPtr intPtr = default(IntPtr);
			int num12 = (int)((long)intPtr & 1L);
			return result;
		}
	}
}

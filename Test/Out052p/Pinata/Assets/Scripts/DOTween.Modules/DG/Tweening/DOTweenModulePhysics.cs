using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000003")]
	public static class DOTweenModulePhysics
	{
		[Token(Token = "0x6000010")]
		[Address(RVA = "0x15760F4", Offset = "0x15760F4", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv42 = *([1ED5A30]);\n\tv43 = *([v42 @ X8_v22]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, snapping, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([202914D]) = v57;\nL_0024:\n\tv61 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv68 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v68, v61, Il2CppMethodInfo);\n\tv83 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v83, v61.target, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv144 = *([v140 @ X0_v10+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_005A;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v140, v135, v137, v98, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\nL_005A:\n\tv153 = DG.Tweening.DOTween::To(v68, v83, endValue, duration);\n\tv157 = DG.Tweening.TweenSettingsExtensions::SetOptions(v153, snapping);\n\tv159 = DG.Tweening.TweenSettingsExtensions::SetTarget(v157, v61.target);\n\treturn v153;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Rigidbody target, Vector3 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = target.MovePosition;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x1576270", Offset = "0x1576270", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1ECC140]);\n\tv35 = *([v34 @ X8_v22]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, snapping, methodInfo, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202914E]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv62 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v62, v55, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v77, v55.target, Il2CppMethodInfo);\n\tv86 = 0;\n\tv140 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v86 @ stack_-60_v1, 0, Il2CppMethodInfo);\n\tgoto L_005B;\n\tv147 = *([v143 @ X0_v12+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_005B;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v143, v139, v133, v134, v39, v40, v41, v42, v138, v136, v137, v44, v45, v46, v47, v48);\nL_005B:\n\t// 91 MakeStruct v81 @ AGG15763A8_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v153 @ stack_-5C, 0\n\tv157 = DG.Tweening.DOTween::To(v62, v77, v81, duration);\n\tv161 = DG.Tweening.TweenSettingsExtensions::SetOptions(v157, 2, snapping);\n\tv163 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v55.target);\n\treturn v157;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveX(this Rigidbody target, float endValue, float duration, bool snapping = false)
		{
			//IL_0052: Expected O, but got I4
			//IL_0072: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = target.MovePosition;
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.X, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x1576404", Offset = "0x1576404", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1ECBED0]);\n\tv35 = *([v34 @ X8_v22]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, snapping, methodInfo, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202914F]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv62 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v62, v55, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v77, v55.target, Il2CppMethodInfo);\n\tv86 = 0;\n\tv140 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v86 @ stack_-60_v1, 0, Il2CppMethodInfo);\n\tgoto L_005B;\n\tv147 = *([v143 @ X0_v12+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_005B;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v143, v139, v133, v134, v39, v40, v41, v42, v136, v138, v137, v44, v45, v46, v47, v48);\nL_005B:\n\t// 91 MakeStruct v81 @ AGG157653C_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v153 @ stack_-5C, 0\n\tv157 = DG.Tweening.DOTween::To(v62, v77, v81, duration);\n\tv161 = DG.Tweening.TweenSettingsExtensions::SetOptions(v157, 4, snapping);\n\tv163 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v55.target);\n\treturn v157;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveY(this Rigidbody target, float endValue, float duration, bool snapping = false)
		{
			//IL_0052: Expected O, but got I4
			//IL_0072: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = target.MovePosition;
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Y, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x1576598", Offset = "0x1576598", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EF8060]);\n\tv35 = *([v34 @ X8_v22]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, snapping, methodInfo, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2029150]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv62 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v62, v55, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v77, v55.target, Il2CppMethodInfo);\n\tv86 = 0;\n\tv140 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v86 @ stack_-60_v1, 0, Il2CppMethodInfo);\n\tgoto L_005B;\n\tv147 = *([v143 @ X0_v12+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_005B;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v143, v139, v133, v134, v39, v40, v41, v42, v136, v137, v138, v44, v45, v46, v47, v48);\nL_005B:\n\t// 91 MakeStruct v81 @ AGG15766D0_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v153 @ stack_-5C, 0\n\tv157 = DG.Tweening.DOTween::To(v62, v77, v81, duration);\n\tv161 = DG.Tweening.TweenSettingsExtensions::SetOptions(v157, 8, snapping);\n\tv163 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v55.target);\n\treturn v157;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveZ(this Rigidbody target, float endValue, float duration, bool snapping = false)
		{
			//IL_0052: Expected O, but got I4
			//IL_0072: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = target.MovePosition;
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Z, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x157672C", Offset = "0x157672C", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv42 = *([1ED9C80]);\n\tv43 = *([v42 @ X8_v23]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, mode, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2029151]) = v57;\nL_0024:\n\tv61 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv68 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v68, v61, Il2CppMethodInfo);\n\tv115 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v115, v61.target, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv162 = *([v158 @ X0_v11+E0]);\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_005A;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v158, v154, v155, v81, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\nL_005A:\n\tv172 = DG.Tweening.DOTween::To(v68, v115, endValue, duration);\n\tv90 = DG.Tweening.TweenSettingsExtensions::SetTarget(v172, v61.target);\n\tv172.plugOptions = mode;\n\treturn v172;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(this Rigidbody target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			//IL_008f: Expected O, but got I4
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = target.MoveRotation;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			tweenerCore.plugOptions = (QuaternionOptions)mode;
			return tweenerCore;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x15768A4", Offset = "0x15768A4", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv168 = v131.y;\n\tv166 = v131.z;\n\tgoto L_0028;\n\tv49 = *([1EF3E70]);\n\tv50 = *([v49 @ X8_v34]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, axisConstraint, up, methodInfo, v52, v53, v54, v55, towards, v0, v2, duration, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2029152]) = v62;\nL_0028:\n\tv66 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v66);\n\tv66.target = target;\n\tv73 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v73, v66, Il2CppMethodInfo);\n\tv120 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v120, v66.target, Il2CppMethodInfo);\n\tgoto L_005E;\n\tv175 = *([v171 @ X0_v11+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_005E;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v171, v124, v125, v95, v52, v53, v54, v55, towards, v0, v2, duration, v56, v57, v58, v59);\nL_005E:\n\tv185 = DG.Tweening.DOTween::To(v73, v120, v131, duration);\n\tv190 = DG.Tweening.TweenSettingsExtensions::SetTarget(v185, v66.target);\n\tv104 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v190, 1);\n\tv192 = methodInfo & 0xFF00000000;\n\t*([v104 @ X0_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]) = axisConstraint;\n\tv193 = v192 == 0;\n\tif (v193) goto L_007C;\n\tv198 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(&up @ X2 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, Il2CppMethodInfo);\n\tgoto L_0086;\nL_007C:\n\tgoto L_0083;\n\tv205 = *([v201 @ X0_v19+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_0083;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v201, v102, v97, v95, v52, v53, v54, v55, v89, v115, v113, v87, v56, v57, v58, v59);\nL_0083:\n\tv131 = UnityEngine.Vector3::get_up();\n\tv168 = v131.y;\n\tv166 = v131.z;\nL_0086:\n\t*([v104 @ X0_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+148]) = v131;\n\t*([v104 @ X0_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]) = v168;\n\t*([v104 @ X0_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+150]) = v166;\n\treturn v104;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOLookAt(this Rigidbody target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
		{
			//IL_00c6: Expected I4, but got I8
			Vector3 endValue = default(Vector3);
			float y = endValue.y;
			float z = endValue.z;
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = target.MoveRotation;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = t.SetTarget(target);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> result = t2.SetSpecialStartupMode(SpecialStartupMode.SetLookAt);
			IntPtr intPtr = default(IntPtr);
			if ((int)((long)intPtr & 0xFF00000000L) == 0)
			{
				endValue = Vector3.up;
				y = endValue.y;
				z = endValue.z;
			}
			return result;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x1576A94", Offset = "0x1576A94", Length = "0x478")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv58 = *([1EF33B0]);\n\tv59 = *([v58 @ X8_v53]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, numJumps, snapping, methodInfo, v62, v63, v64, v65, endValue, v0, v2, jumpPower, duration, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([2029153]) = v71;\nL_002C:\n\tv75 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v75);\n\tv75.target = target;\n\tv75.endValue = endValue;\n\tv75.endValue.y = endValue.y;\n\tv75.endValue.z = endValue.z;\n\tv75.startPosY = 0f;\n\tv75.offsetYSet = 0;\n\tv75.offsetY = -1f;\n\tv84 = numJumps - 1;\n\tv85 = v84 < 0;\n\tv86 = v84 == 0;\n\tv87 = numJumps ^ 1;\n\tv88 = numJumps ^ v84;\n\tv89 = v87 & v88;\n\tv90 = v89 < 0;\n\tv91 = v85 == v90;\n\tv92 = ~v86;\n\tv93 = v91 & v92;\n\tv94 = ~v93;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0052;\nL_0052:\n\tgoto L_0059;\n\tv210 = *([v100 @ X0_v6+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tgoto L_0059;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v100, v76, snapping, methodInfo, v62, v63, v64, v65, endValue, v0, v2, jumpPower, duration, v66, v67, v68);\nL_0059:\n\tv217 = DG.Tweening.DOTween::Sequence();\n\tv75.s = v217;\n\tv221 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v221, v75, Il2CppMethodInfo);\n\tv234 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v234, v75.target, Il2CppMethodInfo);\n\tv132 = 0;\n\tv248 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v132 @ stack_-A0_v1, 0, Il2CppMethodInfo);\n\tv253 = v99 << 1;\n\tv255 = duration / v253;\n\t// 135 MakeStruct v127 @ AGG1576C20_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v251 @ stack_-9C, 0\n\tv259 = DG.Tweening.DOTween::To(v221, v234, v127, v255);\n\tv264 = DG.Tweening.TweenSettingsExtensions::SetOptions(v259, 4, snapping);\n\tv269 = DG.Tweening.TweenSettingsExtensions::SetEase(v264, 6);\n\tv273 = DG.Tweening.TweenSettingsExtensions::SetRelative(v269);\n\tv279 = DG.Tweening.TweenSettingsExtensions::SetLoops(v273, v253, 1);\n\tv285 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v285, v75, Il2CppMethodInfo);\n\tv297 = DG.Tweening.TweenSettingsExtensions::OnStart(v279, v285);\n\tv75.yTween = v297;\n\tv302 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v302, v75, Il2CppMethodInfo);\n\tv313 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v313, v75.target, Il2CppMethodInfo);\n\tv119 = 0;\n\tv323 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v119 @ stack_-B0_v1, 0, Il2CppMethodInfo);\n\t// 214 MakeStruct v116 @ AGG1576D54_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v326 @ stack_-AC, 0\n\tv332 = DG.Tweening.DOTween::To(v302, v313, v116, duration);\n\tv336 = DG.Tweening.TweenSettingsExtensions::SetOptions(v332, 2, snapping);\n\tv339 = DG.Tweening.TweenSettingsExtensions::SetEase(v336, 1);\n\tv343 = DG.Tweening.TweenSettingsExtensions::Append(v75.s, v339);\n\tv349 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v349, v75, Il2CppMethodInfo);\n\tv360 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v360, v75.target, Il2CppMethodInfo);\n\tv110 = 0;\n\tv370 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v110 @ stack_-C0_v1, 0, Il2CppMethodInfo);\n\t// 265 MakeStruct v107 @ AGG1576E18_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v371 @ stack_-BC, 0\n\tv375 = DG.Tweening.DOTween::To(v349, v360, v107, duration);\n\tv379 = DG.Tweening.TweenSettingsExtensions::SetOptions(v375, 8, snapping);\n\tv382 = DG.Tweening.TweenSettingsExtensions::SetEase(v379, 1);\n\tv386 = DG.Tweening.TweenSettingsExtensions::Join(v343, v382);\n\tv389 = DG.Tweening.TweenSettingsExtensions::Join(v386, v75.yTween);\n\tv394 = DG.Tweening.TweenSettingsExtensions::SetTarget(v389, v75.target);\n\tv402 = DG.Tweening.TweenSettingsExtensions::SetEase(v394, v399.defaultEaseType);\n\tv407 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v407, v75, Il2CppMethodInfo);\n\tv415 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v75.yTween, v407);\n\treturn v75.s;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 251 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOJump(this Rigidbody target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			//IL_018a: Expected O, but got I4
			//IL_01c8: Expected F4, but got O
			//IL_02c0: Expected O, but got I4
			//IL_02db: Expected F4, but got O
			//IL_038a: Expected O, but got I4
			//IL_03aa: Expected F4, but got O
			Vector3 endValue2 = endValue;
			endValue2.y = endValue.y;
			endValue2.z = endValue.z;
			float startPosY = 0f;
			bool offsetYSet = false;
			float offsetY = -1f;
			int num = numJumps - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = numJumps ^ 1;
			int num3 = numJumps ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int num5 = ((!(flag4 && flag5)) ? 1 : numJumps);
			Sequence sequence = DOTween.Sequence();
			Sequence s = sequence;
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = target.MovePosition;
			object obj = 0;
			int num6 = num5 << 1;
			float duration2 = duration / (float)num6;
			Vector3 endValue3 = default(Vector3);
			endValue3.x = 0f;
			object obj2 = default(object);
			endValue3.y = (float)obj2;
			endValue3.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, endValue3, duration2);
			Tweener t2 = t.SetOptions(AxisConstraint.Y, snapping);
			Tweener relative = t2.SetEase(Ease.OutQuad);
			Tweener t3 = relative.SetRelative();
			Tweener t4 = t3.SetLoops(num6, LoopType.Yoyo);
			TweenCallback action = delegate
			{
				startPosY = target.position.y;
			};
			Tweener tweener = t4.OnStart(action);
			Tween yTween = tweener;
			DOGetter<Vector3> getter2 = () => target.position;
			DOSetter<Vector3> setter2 = target.MovePosition;
			object obj3 = 0;
			Vector3 endValue4 = default(Vector3);
			endValue4.x = 0f;
			object obj4 = default(object);
			endValue4.y = (float)obj4;
			endValue4.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t5 = DOTween.To(getter2, setter2, endValue4, duration);
			Tweener t6 = t5.SetOptions(AxisConstraint.X, snapping);
			Tweener t7 = t6.SetEase(Ease.Linear);
			Sequence s2 = s.Append(t7);
			DOGetter<Vector3> getter3 = () => target.position;
			DOSetter<Vector3> setter3 = target.MovePosition;
			object obj5 = 0;
			Vector3 endValue5 = default(Vector3);
			endValue5.x = 0f;
			object obj6 = default(object);
			endValue5.y = (float)obj6;
			endValue5.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t8 = DOTween.To(getter3, setter3, endValue5, duration);
			Tweener t9 = t8.SetOptions(AxisConstraint.Z, snapping);
			Tweener t10 = t9.SetEase(Ease.Linear);
			Sequence s3 = s2.Join(t10);
			Sequence t11 = s3.Join(yTween);
			Sequence t12 = t11.SetTarget(target);
			Sequence sequence2 = t12.SetEase(DOTween.defaultEaseType);
			TweenCallback action2 = delegate
			{
				if (!offsetYSet)
				{
					Sequence sequence3 = s;
					offsetYSet = true;
					float num7 = endValue2.y;
					if (!sequence3.isRelative)
					{
						num7 -= startPosY;
					}
					offsetY = num7;
				}
				Vector3 position = target.position;
				float lifetimePercentage = yTween.ElapsedPercentage();
				float num8 = DOVirtual.EasedValue(0f, offsetY, lifetimePercentage, Ease.OutQuad);
				float y = position.y + num8;
				Vector3 position2 = default(Vector3);
				position2.x = position.x;
				position2.y = y;
				position2.z = position.z;
				target.MovePosition(position2);
			};
			Tween tween = yTween.OnUpdate(action2);
			return s;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x1576F14", Offset = "0x1576F14", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv48 = *([1EF6C08]);\n\tv49 = *([v48 @ X8_v32]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v52, duration, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2029154]) = v62;\nL_0025:\n\tv66 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v66);\n\tv72 = resolution - 1;\n\tv73 = v72 < 0;\n\tv74 = v72 == 0;\n\tv75 = resolution ^ 1;\n\tv76 = resolution ^ v72;\n\tv77 = v75 & v76;\n\tv78 = v77 < 0;\n\tv66.target = target;\n\tv80 = v73 == v78;\n\tv81 = ~v74;\n\tv82 = v80 & v81;\n\tv83 = ~v82;\n\tif (v83) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\tv149 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv154 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v154, v66, Il2CppMethodInfo);\n\tv215 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v215, v66.target, Il2CppMethodInfo);\n\tduration = *([gizmoColor @ X5 (System.Nullable`1<UnityEngine.Color>)]);\n\tv227 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v227, pathType, path, v111, &duration @ V0 (System.Single));\n\tgoto L_0080;\n\tv238 = *([v234 @ X0_v15+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_0080;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v234, v229, v230, v231, v228, v88, methodInfo, v52, v224, v53, v54, v55, v56, v57, v58, v59);\nL_0080:\n\tv250 = DG.Tweening.DOTween::To(v149, v154, v215, v227, duration);\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetTarget(v250, v66.target);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetUpdate(v255, 2);\n\t*([returnVal2 @ X0_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+188]) = 1;\n\treturnVal2.plugOptions = pathMode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			//IL_00f5: Expected F4, but got O
			//IL_010a: Expected O, but got Ref
			//IL_017b: Expected O, but got I4
			int num = resolution - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = resolution ^ 1;
			int num3 = resolution ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			Rigidbody target2 = target;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int subdivisionsXSegment = ((!(flag4 && flag5)) ? 1 : resolution);
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target2.position;
			DOSetter<Vector3> setter = target2.MovePosition;
			float num5 = (float)gizmoColor;
			Path endValue = new Path(pathType, path, subdivisionsXSegment, (Color?)(object)(&num5));
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, endValue, duration);
			TweenerCore<Vector3, Path, PathOptions> t2 = t.SetTarget(target2);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t2.SetUpdate(UpdateType.Fixed);
			_ = 1;
			tweenerCore.plugOptions = (PathOptions)pathMode;
			return tweenerCore;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x157710C", Offset = "0x157710C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv46 = *([1EE2240]);\n\tv47 = *([v46 @ X8_v32]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v50, duration, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([2029155]) = v60;\nL_0024:\n\tv64 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v64);\n\tv64.target = target;\n\tv73 = resolution - 1;\n\tv74 = v73 < 0;\n\tv75 = v73 == 0;\n\tv76 = resolution ^ 1;\n\tv77 = resolution ^ v73;\n\tv78 = v76 & v77;\n\tv79 = v78 < 0;\n\tv82 = v74 == v79;\n\tv83 = ~v75;\n\tv84 = v82 & v83;\n\tv85 = ~v84;\n\tif (v85) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tv148 = UnityEngine.Component::get_transform(target);\n\tv64.trans = v148;\n\tv198 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv203 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v203, v64, Il2CppMethodInfo);\n\tv214 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v214, v64, Il2CppMethodInfo);\n\tduration = *([gizmoColor @ X5 (System.Nullable`1<UnityEngine.Color>)]);\n\tv226 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v226, pathType, path, v108, &duration @ V0 (System.Single));\n\tgoto L_0084;\n\tv237 = *([v233 @ X0_v17+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\tif (v239) goto L_0084;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v233, v228, v229, v230, v227, v87, methodInfo, v50, v223, v51, v52, v53, v54, v55, v56, v57);\nL_0084:\n\tv249 = DG.Tweening.DOTween::To(v198, v203, v214, v226, duration);\n\tv254 = DG.Tweening.TweenSettingsExtensions::SetTarget(v249, v64.target);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetUpdate(v254, 2);\n\treturnVal2.plugOptions = pathMode;\n\t*([returnVal2 @ X0_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+188]) = 1;\n\t*([returnVal2 @ X0_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+178]) = 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			//IL_00f5: Expected F4, but got O
			//IL_010a: Expected O, but got Ref
			//IL_0175: Expected O, but got I4
			Rigidbody target2 = target;
			int num = resolution - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = resolution ^ 1;
			int num3 = resolution ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int subdivisionsXSegment = ((!(flag4 && flag5)) ? 1 : resolution);
			Transform transform = target.transform;
			Transform trans = transform;
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => trans.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Transform parent = trans.parent;
				bool flag6 = parent == null;
				bool flag7 = !flag6;
				bool flag8 = !flag7;
				Vector3 vector = x;
				float y = x.y;
				float z = x.z;
				if (!flag8)
				{
					Transform parent2 = trans.parent;
					Vector3 vector2 = parent2.TransformPoint(x);
					vector = vector2;
					y = vector2.y;
					z = vector2.z;
				}
				Vector3 position = default(Vector3);
				position.x = vector.x;
				position.y = y;
				position.z = z;
				target2.MovePosition(position);
			};
			float num5 = (float)gizmoColor;
			Path endValue = new Path(pathType, path, subdivisionsXSegment, (Color?)(object)(&num5));
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, endValue, duration);
			TweenerCore<Vector3, Path, PathOptions> t2 = t.SetTarget(target2);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t2.SetUpdate(UpdateType.Fixed);
			tweenerCore.plugOptions = (PathOptions)pathMode;
			_ = 1;
			_ = 1;
			return tweenerCore;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x1577318", Offset = "0x1577318", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EB4A40]);\n\tv37 = *([v36 @ X8_v27]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, path, pathMode, methodInfo, v40, v41, v42, v43, duration, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2029156]) = v53;\nL_001F:\n\tv57 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v57);\n\tv57.target = target;\n\tv62 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv69 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v69, v57, Il2CppMethodInfo);\n\tv107 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v107, v57.target, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv150 = *([v146 @ X0_v13+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0059;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v146, v141, v142, v143, v40, v41, v42, v43, duration, v44, v45, v46, v47, v48, v49, v50);\nL_0059:\n\tv162 = DG.Tweening.DOTween::To(v62, v69, v107, path, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v162, v57.target);\n\t*([returnVal2 @ X0_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+188]) = 1;\n\treturnVal2.plugOptions = pathMode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			//IL_00a2: Expected O, but got I4
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = target.MovePosition;
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, path, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t.SetTarget(target);
			_ = 1;
			tweenerCore.plugOptions = (PathOptions)pathMode;
			return tweenerCore;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x157749C", Offset = "0x157749C", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EC6450]);\n\tv35 = *([v34 @ X8_v27]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, path, pathMode, methodInfo, v38, v39, v40, v41, duration, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2029157]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.DOTweenModulePhysics+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv64 = UnityEngine.Component::get_transform(target);\n\tv55.trans = v64;\n\tv92 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv97 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v97, v55, Il2CppMethodInfo);\n\tv136 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v136, v55, Il2CppMethodInfo);\n\tgoto L_005D;\n\tv149 = *([v145 @ X0_v15+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_005D;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v145, v140, v141, v142, v38, v39, v40, v41, duration, v42, v43, v44, v45, v46, v47, v48);\nL_005D:\n\tv161 = DG.Tweening.DOTween::To(v92, v97, v136, path, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v55.target);\n\treturnVal2.plugOptions = pathMode;\n\t*([returnVal2 @ X0_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+188]) = 1;\n\t*([returnVal2 @ X0_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+178]) = 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			//IL_00bb: Expected O, but got I4
			Rigidbody target2 = target;
			Transform transform = target.transform;
			Transform trans = transform;
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => trans.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Transform parent = trans.parent;
				bool flag = parent == null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				Vector3 vector = x;
				float y = x.y;
				float z = x.z;
				if (!flag3)
				{
					Transform parent2 = trans.parent;
					Vector3 vector2 = parent2.TransformPoint(x);
					vector = vector2;
					y = vector2.y;
					z = vector2.z;
				}
				Vector3 position = default(Vector3);
				position.x = vector.x;
				position.y = y;
				position.z = z;
				target2.MovePosition(position);
			};
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, path, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t.SetTarget(target2);
			tweenerCore.plugOptions = (PathOptions)pathMode;
			_ = 1;
			_ = 1;
			return tweenerCore;
		}
	}
}

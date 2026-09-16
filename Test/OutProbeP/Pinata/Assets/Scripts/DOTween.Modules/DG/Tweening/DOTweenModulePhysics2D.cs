using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000004")]
	public static class DOTweenModulePhysics2D
	{
		[Token(Token = "0x600001B")]
		[Address(RVA = "0x1577AA8", Offset = "0x1577AA8", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv38 = *([1EAA3B0]);\n\tv39 = *([v38 @ X8_v22]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, snapping, methodInfo, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202915A]) = v54;\nL_0021:\n\tv58 = new DG.Tweening.DOTweenModulePhysics2D+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv65 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v65, v58, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v80, v58.target, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv137 = *([v133 @ X0_v10+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0056;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v128, v130, v95, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\nL_0056:\n\tv146 = DG.Tweening.DOTween::To(v65, v80, endValue, duration);\n\tv150 = DG.Tweening.TweenSettingsExtensions::SetOptions(v146, snapping);\n\tv152 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v58.target);\n\treturn v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOMove(this Rigidbody2D target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = () => target.position;
			DOSetter<Vector2> setter = target.MovePosition;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x1577C1C", Offset = "0x1577C1C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1F00FD8]);\n\tv35 = *([v34 @ X8_v22]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, snapping, methodInfo, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202915B]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.DOTweenModulePhysics2D+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv62 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v62, v55, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v55.target, Il2CppMethodInfo);\n\tv86 = 0;\n\tv134 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v86 @ stack_-38_v1, 0, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv141 = *([v137 @ X0_v12+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0058;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v133, v128, v129, v39, v40, v41, v42, v132, v131, v43, v44, v45, v46, v47, v48);\nL_0058:\n\t// 88 MakeStruct v81 @ AGG1577D44_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v147 @ stack_-34\n\tv151 = DG.Tweening.DOTween::To(v62, v77, v81, duration);\n\tv155 = DG.Tweening.TweenSettingsExtensions::SetOptions(v151, 2, snapping);\n\tv157 = DG.Tweening.TweenSettingsExtensions::SetTarget(v155, v55.target);\n\treturn v151;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveX(this Rigidbody2D target, float endValue, float duration, bool snapping = false)
		{
			//IL_0052: Expected O, but got I4
			//IL_0072: Expected F4, but got O
			DOGetter<Vector2> getter = () => target.position;
			DOSetter<Vector2> setter = target.MovePosition;
			object obj = 0;
			Vector2 endValue2 = default(Vector2);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.X, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x1577D9C", Offset = "0x1577D9C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EFE5A8]);\n\tv35 = *([v34 @ X8_v22]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, snapping, methodInfo, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202915C]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.DOTweenModulePhysics2D+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv62 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v62, v55, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v55.target, Il2CppMethodInfo);\n\tv86 = 0;\n\tv134 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v86 @ stack_-38_v1, 0, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv141 = *([v137 @ X0_v12+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0058;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v133, v128, v129, v39, v40, v41, v42, v131, v132, v43, v44, v45, v46, v47, v48);\nL_0058:\n\t// 88 MakeStruct v81 @ AGG1577EC4_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v147 @ stack_-34\n\tv151 = DG.Tweening.DOTween::To(v62, v77, v81, duration);\n\tv155 = DG.Tweening.TweenSettingsExtensions::SetOptions(v151, 4, snapping);\n\tv157 = DG.Tweening.TweenSettingsExtensions::SetTarget(v155, v55.target);\n\treturn v151;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveY(this Rigidbody2D target, float endValue, float duration, bool snapping = false)
		{
			//IL_0052: Expected O, but got I4
			//IL_0072: Expected F4, but got O
			DOGetter<Vector2> getter = () => target.position;
			DOSetter<Vector2> setter = target.MovePosition;
			object obj = 0;
			Vector2 endValue2 = default(Vector2);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Y, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x1577F1C", Offset = "0x1577F1C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EC40B8]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, endValue, duration, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202915D]) = v48;\nL_001C:\n\tv52 = new DG.Tweening.DOTweenModulePhysics2D+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v52);\n\tv52.target = target;\n\tv59 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v59, v52, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v74, v52.target, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv122 = *([v118 @ X0_v10+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_004F;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v113, v115, v86, v36, v37, v38, v39, endValue, duration, v40, v41, v42, v43, v44, v45);\nL_004F:\n\tv131 = DG.Tweening.DOTween::To(v59, v74, endValue, duration);\n\tv134 = DG.Tweening.TweenSettingsExtensions::SetTarget(v131, v52.target);\n\treturn v131;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DORotate(this Rigidbody2D target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.rotation;
			DOSetter<float> setter = target.MoveRotation;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x1578068", Offset = "0x1578068", Length = "0x37C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv54 = *([1EDEFD0]);\n\tv55 = *([v54 @ X8_v44]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, numJumps, snapping, methodInfo, v58, v59, v60, v61, endValue, v0, jumpPower, duration, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([202915E]) = v68;\nL_0029:\n\tv72 = new DG.Tweening.DOTweenModulePhysics2D+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v72);\n\tv72.target = target;\n\tv72.endValue = endValue;\n\tv72.endValue.y = endValue.y;\n\tv72.startPosY = 0f;\n\tv72.offsetYSet = 0;\n\tv72.offsetY = -1f;\n\tv81 = numJumps - 1;\n\tv82 = v81 < 0;\n\tv83 = v81 == 0;\n\tv84 = numJumps ^ 1;\n\tv85 = numJumps ^ v81;\n\tv86 = v84 & v85;\n\tv87 = v86 < 0;\n\tv88 = v82 == v87;\n\tv89 = ~v83;\n\tv90 = v88 & v89;\n\tv91 = ~v90;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_004E;\nL_004E:\n\tgoto L_0055;\n\tv188 = *([v97 @ X0_v6+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tgoto L_0055;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v97, v73, snapping, methodInfo, v58, v59, v60, v61, endValue, v0, jumpPower, duration, v62, v63, v64, v65);\nL_0055:\n\tv195 = DG.Tweening.DOTween::Sequence();\n\tv72.s = v195;\n\tv199 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v199, v72, Il2CppMethodInfo);\n\tv211 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v211, v72, Il2CppMethodInfo);\n\tv120 = 0;\n\tv224 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v120 @ stack_-88_v1, 0, Il2CppMethodInfo);\n\tv228 = v96 << 1;\n\tv230 = duration / v228;\n\t// 127 MakeStruct v115 @ AGG15781D8_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v227 @ stack_-84\n\tv234 = DG.Tweening.DOTween::To(v199, v211, v115, v230);\n\tv239 = DG.Tweening.TweenSettingsExtensions::SetOptions(v234, 4, snapping);\n\tv244 = DG.Tweening.TweenSettingsExtensions::SetEase(v239, 6);\n\tv248 = DG.Tweening.TweenSettingsExtensions::SetRelative(v244);\n\tv254 = DG.Tweening.TweenSettingsExtensions::SetLoops(v248, v228, 1);\n\tv260 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v260, v72, Il2CppMethodInfo);\n\tv272 = DG.Tweening.TweenSettingsExtensions::OnStart(v254, v260);\n\tv72.yTween = v272;\n\tv275 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v275, v72, Il2CppMethodInfo);\n\tv283 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v283, v72, Il2CppMethodInfo);\n\tv110 = 0;\n\tv294 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v110 @ stack_-90_v1, 0, Il2CppMethodInfo);\n\t// 200 MakeStruct v107 @ AGG15782F4_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v295 @ stack_-8C\n\tv299 = DG.Tweening.DOTween::To(v275, v283, v107, duration);\n\tv303 = DG.Tweening.TweenSettingsExtensions::SetOptions(v299, 2, snapping);\n\tv306 = DG.Tweening.TweenSettingsExtensions::SetEase(v303, 1);\n\tv310 = DG.Tweening.TweenSettingsExtensions::Append(v72.s, v306);\n\tv313 = DG.Tweening.TweenSettingsExtensions::Join(v310, v72.yTween);\n\tv318 = DG.Tweening.TweenSettingsExtensions::SetTarget(v313, v72.target);\n\tv326 = DG.Tweening.TweenSettingsExtensions::SetEase(v318, v323.defaultEaseType);\n\tv331 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v331, v72, Il2CppMethodInfo);\n\tv339 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v72.yTween, v331);\n\treturn v72.s;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 197 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOJump(this Rigidbody2D target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			//IL_016e: Expected O, but got I4
			//IL_01ac: Expected F4, but got O
			//IL_0291: Expected O, but got I4
			//IL_02ac: Expected F4, but got O
			Vector2 endValue2 = endValue;
			endValue2.y = endValue.y;
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
			DOGetter<Vector2> getter = () => target.position;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.position = x;
			};
			object obj = 0;
			int num6 = num5 << 1;
			float duration2 = duration / (float)num6;
			Vector2 endValue3 = default(Vector2);
			endValue3.x = 0f;
			object obj2 = default(object);
			endValue3.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, setter, endValue3, duration2);
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
			DOGetter<Vector2> getter2 = () => target.position;
			DOSetter<Vector2> setter2 = delegate(Vector2 x)
			{
				target.position = x;
			};
			object obj3 = 0;
			Vector2 endValue4 = default(Vector2);
			endValue4.x = 0f;
			object obj4 = default(object);
			endValue4.y = (float)obj4;
			TweenerCore<Vector2, Vector2, VectorOptions> t5 = DOTween.To(getter2, setter2, endValue4, duration);
			Tweener t6 = t5.SetOptions(AxisConstraint.X, snapping);
			Tweener t7 = t6.SetEase(Ease.Linear);
			Sequence s2 = s.Append(t7);
			Sequence t8 = s2.Join(yTween);
			Sequence t9 = t8.SetTarget(target);
			Sequence sequence2 = t9.SetEase(DOTween.defaultEaseType);
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
				Vector2 position = target.position;
				Vector3 vector = position;
				float lifetimePercentage = yTween.ElapsedPercentage();
				float num8 = DOVirtual.EasedValue(0f, offsetY, lifetimePercentage, Ease.OutQuad);
				float y = vector.y + num8;
				Vector3 vector2 = default(Vector3);
				vector2.x = vector.x;
				vector2.y = y;
				vector2.z = vector.z;
				Vector2 position2 = vector2;
				target.MovePosition(position2);
			};
			Tween tween = yTween.OnUpdate(action2);
			return s;
		}
	}
}

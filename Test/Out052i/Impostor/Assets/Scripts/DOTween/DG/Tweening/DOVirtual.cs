using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x200000C")]
	public static class DOVirtual
	{
		[Token(Token = "0x6000070")]
		[Address(RVA = "0xC0A494", Offset = "0xC0A494", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv42 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv68 = DG.Tweening.DOTween;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv72 = DG.Tweening.TweenCallback;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv94 = Il2CppMethodInfo;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv148 = Il2CppMethodInfo;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv154 = Il2CppMethodInfo;\n\tv155 = \"il2cpp_codegen_initialize_runtime_metadata\"(v154, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv160 = DG.Tweening.DOVirtual+<>c__DisplayClass0_0;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, methodInfo, v45, v46, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A356B2]) = v59;\nL_0038:\n\tv61 = new DG.Tweening.DOVirtual+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v61);\n\tv61.onVirtualUpdate = onVirtualUpdate;\n\tv61.val = from;\n\tv91 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v91, v61, Il2CppMethodInfo);\n\tv104 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v104, v61, Il2CppMethodInfo);\n\tgoto L_0068;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v156, v151, v150, v112, v47, v48, v49, v50, from, to, duration, v51, v52, v53, v54, v55);\nL_0068:\n\tv165 = DG.Tweening.DOTween::To(v91, v104, to, duration);\n\tv168 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v168, v61, Il2CppMethodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v165, v168);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener Float(float from, float to, float duration, TweenCallback<float> onVirtualUpdate)
		{
			DOGetter<float> getter = () => from;
			DOSetter<float> setter = delegate(float x)
			{
				from = x;
			};
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, setter, to, duration);
			TweenCallback action = delegate
			{
				//IL_0023: Expected F4, but got I
				TweenCallback<float> tweenCallback = onVirtualUpdate;
				onVirtualUpdate((nint)tweenCallback.method);
			};
			return t.OnUpdate(action);
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0xC0A65C", Offset = "0xC0A65C", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv42 = DG.Tweening.Core.DOGetter`1<System.Int32>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<System.Int32>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv68 = DG.Tweening.DOTween;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv72 = DG.Tweening.TweenCallback;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv94 = Il2CppMethodInfo;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv146 = Il2CppMethodInfo;\n\tv147 = \"il2cpp_codegen_initialize_runtime_metadata\"(v146, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv152 = Il2CppMethodInfo;\n\tv153 = \"il2cpp_codegen_initialize_runtime_metadata\"(v152, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv158 = DG.Tweening.DOVirtual+<>c__DisplayClass1_0;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v158, to, onVirtualUpdate, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A356B3]) = v59;\nL_0038:\n\tv61 = new DG.Tweening.DOVirtual+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v61);\n\tv61.onVirtualUpdate = onVirtualUpdate;\n\tv61.val = from;\n\tv91 = new DG.Tweening.Core.DOGetter`1<System.Int32>();\n\tDG.Tweening.Core.DOGetter`1<System.Int32>::.ctor(v91, v61, Il2CppMethodInfo);\n\tv104 = new DG.Tweening.Core.DOSetter`1<System.Int32>();\n\tDG.Tweening.Core.DOSetter`1<System.Int32>::.ctor(v104, v61, Il2CppMethodInfo);\n\tgoto L_0068;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v154, v149, v148, v110, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\nL_0068:\n\tv164 = DG.Tweening.DOTween::To(v91, v104, to, duration);\n\tv167 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v167, v61, Il2CppMethodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v164, v167);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener Int(int from, int to, float duration, TweenCallback<int> onVirtualUpdate)
		{
			DOGetter<int> getter = () => from;
			DOSetter<int> setter = delegate(int x)
			{
				from = x;
			};
			TweenerCore<int, int, NoOptions> t = DOTween.To(getter, setter, to, duration);
			TweenCallback action = delegate
			{
				onVirtualUpdate(from);
			};
			return t.OnUpdate(action);
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0xC0A824", Offset = "0xC0A824", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv50 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv69 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv74 = DG.Tweening.DOTween;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv78 = DG.Tweening.TweenCallback;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv100 = Il2CppMethodInfo;\n\tv101 = \"il2cpp_codegen_initialize_runtime_metadata\"(v100, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv107 = Il2CppMethodInfo;\n\tv108 = \"il2cpp_codegen_initialize_runtime_metadata\"(v107, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv163 = Il2CppMethodInfo;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv169 = Il2CppMethodInfo;\n\tv170 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv175 = DG.Tweening.DOVirtual+<>c__DisplayClass2_0;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\n\tv65 = 1;\n\t*([1A356B4]) = v65;\nL_003E:\n\tv67 = new DG.Tweening.DOVirtual+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v67);\n\tv67.onVirtualUpdate = onVirtualUpdate;\n\tv67.val = from;\n\tv67.val.y = from.y;\n\tv97 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v97, v67, Il2CppMethodInfo);\n\tv110 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v110, v67, Il2CppMethodInfo);\n\tgoto L_0071;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v171, v166, v165, v121, v55, v56, v57, v58, from, v0, to, v2, duration, v59, v60, v61);\nL_0071:\n\tv180 = DG.Tweening.DOTween::To(v97, v110, to, duration);\n\tv183 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v183, v67, Il2CppMethodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v180, v183);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener Vector2(Vector2 from, Vector2 to, float duration, TweenCallback<Vector2> onVirtualUpdate)
		{
			Vector2 val = from;
			val.y = from.y;
			DOGetter<Vector2> getter = () => val;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				val = x;
				val.y = x.y;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, setter, to, duration);
			TweenCallback action = delegate
			{
				//IL_0023: Expected O, but got I
				TweenCallback<Vector2> tweenCallback = onVirtualUpdate;
				onVirtualUpdate((Vector2)(nint)tweenCallback.method);
			};
			return t.OnUpdate(action);
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0xC0AA00", Offset = "0xC0AA00", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\n\tv58 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv75 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv80 = DG.Tweening.DOTween;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv84 = DG.Tweening.TweenCallback;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv106 = Il2CppMethodInfo;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv113 = Il2CppMethodInfo;\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv175 = Il2CppMethodInfo;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv181 = Il2CppMethodInfo;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv187 = DG.Tweening.DOVirtual+<>c__DisplayClass3_0;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v187, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\n\tv71 = 1;\n\t*([1A356B5]) = v71;\nL_0044:\n\tv73 = new DG.Tweening.DOVirtual+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v73);\n\tv73.onVirtualUpdate = onVirtualUpdate;\n\tv73.val = from;\n\tv73.val.y = from.y;\n\tv73.val.z = from.z;\n\tv103 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v103, v73, Il2CppMethodInfo);\n\tv116 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v116, v73, Il2CppMethodInfo);\n\tgoto L_0079;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v183, v178, v177, v127, v63, v64, v65, v66, from, v0, v2, to, v3, v5, duration, v67);\nL_0079:\n\tv192 = DG.Tweening.DOTween::To(v103, v116, to, duration);\n\tv195 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v195, v73, Il2CppMethodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v192, v195);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener Vector3(Vector3 from, Vector3 to, float duration, TweenCallback<Vector3> onVirtualUpdate)
		{
			Vector3 val = from;
			val.y = from.y;
			val.z = from.z;
			DOGetter<Vector3> getter = () => val;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				val = x;
				val.y = x.y;
				val.z = x.z;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, to, duration);
			TweenCallback action = delegate
			{
				//IL_0023: Expected O, but got I
				TweenCallback<Vector3> tweenCallback = onVirtualUpdate;
				onVirtualUpdate((Vector3)(nint)tweenCallback.method);
			};
			return t.OnUpdate(action);
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0xC0ABF4", Offset = "0xC0ABF4", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0049;\n\tv64 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv80 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv85 = DG.Tweening.DOTween;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv89 = DG.Tweening.TweenCallback;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv111 = Il2CppMethodInfo;\n\tv112 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv118 = Il2CppMethodInfo;\n\tv119 = \"il2cpp_codegen_initialize_runtime_metadata\"(v118, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv184 = Il2CppMethodInfo;\n\tv185 = \"il2cpp_codegen_initialize_runtime_metadata\"(v184, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv190 = Il2CppMethodInfo;\n\tv191 = \"il2cpp_codegen_initialize_runtime_metadata\"(v190, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv196 = DG.Tweening.DOVirtual+<>c__DisplayClass4_0;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v196, methodInfo, v67, v68, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\n\tv76 = 1;\n\t*([1A356B6]) = v76;\nL_0049:\n\tv78 = new DG.Tweening.DOVirtual+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v78);\n\tv78.onVirtualUpdate = onVirtualUpdate;\n\tv78.val = from;\n\tv78.val.g = from.g;\n\tv78.val.b = from.b;\n\tv78.val.a = from.a;\n\tv108 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v108, v78, Il2CppMethodInfo);\n\tv121 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v121, v78, Il2CppMethodInfo);\n\tgoto L_0080;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v192, v187, v186, v132, v69, v70, v71, v72, from, v0, v2, v3, to, v4, v6, v7);\nL_0080:\n\tv201 = DG.Tweening.DOTween::To(v108, v121, to, duration);\n\tv204 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v204, v78, Il2CppMethodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v201, v204);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener Color(Color from, Color to, float duration, TweenCallback<Color> onVirtualUpdate)
		{
			Color val = from;
			val.g = from.g;
			val.b = from.b;
			val.a = from.a;
			DOGetter<Color> getter = () => val;
			DOSetter<Color> setter = delegate(Color x)
			{
				val = x;
				val.g = x.g;
				val.b = x.b;
				val.a = x.a;
			};
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, to, duration);
			TweenCallback action = delegate
			{
				//IL_0023: Expected O, but got I
				TweenCallback<Color> tweenCallback = onVirtualUpdate;
				onVirtualUpdate((Color)(nint)tweenCallback.method);
			};
			return t.OnUpdate(action);
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0xC0ADFC", Offset = "0xC0ADFC", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = DG.Tweening.DOTween;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, from, to, lifetimePercentage, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A356B7]) = v46;\nL_001D:\n\tgoto L_0028;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, from, to, lifetimePercentage, v39, v40, v41, v42, v43);\n\tv53 = DG.Tweening.DOTween;\nL_0028:\n\tv62 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, v54.defaultEaseOvershootOrAmplitude, v54.defaultEasePeriod);\n\tv63 = to - from;\n\tv64 = v63 * v62;\n\treturnVal1 = v64 + from;\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType)
		{
			float num = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0xC0AE98", Offset = "0xC0AE98", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = DG.Tweening.DOTween;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, from, to, lifetimePercentage, overshoot, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A356B8]) = v49;\nL_001F:\n\tgoto L_002A;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v37, v38, v39, v40, v41, v42, from, to, lifetimePercentage, overshoot, v43, v44, v45, v46);\n\tv56 = DG.Tweening.DOTween;\nL_002A:\n\tv65 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, overshoot, v57.defaultEasePeriod);\n\tv66 = to - from;\n\tv67 = v66 * v65;\n\treturnVal1 = v67 + from;\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float overshoot)
		{
			float num = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, overshoot, DOTween.defaultEasePeriod);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0xC0AF3C", Offset = "0xC0AF3C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, amplitude, period);\n\tv22 = to - from;\n\tv23 = v22 * v19;\n\treturnVal1 = v23 + from;\n\treturn returnVal1;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float amplitude, float period)
		{
			float num = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, amplitude, period);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0xC0AF80", Offset = "0xC0AF80", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv42 = DG.Tweening.DOTween;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v45, v46, v47, v48, v49, v50, from, to, lifetimePercentage, v51, v52, v53, v54, v55);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v45, v46, v47, v48, v49, v50, from, to, lifetimePercentage, v51, v52, v53, v54, v55);\n\tv69 = DG.Tweening.Core.Easing.EaseCurve;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v45, v46, v47, v48, v49, v50, from, to, lifetimePercentage, v51, v52, v53, v54, v55);\n\tv74 = DG.Tweening.EaseFunction;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v45, v46, v47, v48, v49, v50, from, to, lifetimePercentage, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A356B9]) = v59;\nL_002C:\n\tv61 = new DG.Tweening.Core.Easing.EaseCurve();\n\tDG.Tweening.Core.Easing.EaseCurve::.ctor(v61, easeCurve);\n\tv72 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v72, v61, Il2CppMethodInfo);\n\tgoto L_0046;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v78, v76, v75, v46, v47, v48, v49, v50, from, to, lifetimePercentage, v51, v52, v53, v54, v55);\n\tv84 = DG.Tweening.DOTween;\nL_0046:\n\tv93 = DG.Tweening.Core.Easing.EaseManager::Evaluate(0x25, v72, lifetimePercentage, 1f, v85.defaultEaseOvershootOrAmplitude, v85.defaultEasePeriod);\n\tv94 = to - from;\n\tv95 = v94 * v93;\n\treturnVal1 = v95 + from;\n\treturn returnVal1;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EasedValue(float from, float to, float lifetimePercentage, AnimationCurve easeCurve)
		{
			EaseCurve easeCurve2 = new EaseCurve(easeCurve);
			EaseFunction customEase = easeCurve2.Evaluate;
			float num = EaseManager.Evaluate(Ease.INTERNAL_Custom, customEase, lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0xC0B098", Offset = "0xC0B098", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv46 = DG.Tweening.DOTween;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, from, v0, v2, to, v3, v5, lifetimePercentage, v55);\n\tv58 = 1;\n\t*([1A356BA]) = v58;\nL_0029:\n\tgoto L_0036;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v49, v50, v51, v52, v53, v54, from, v0, v2, to, v3, v5, lifetimePercentage, v55);\n\tv65 = DG.Tweening.DOTween;\nL_0036:\n\tv76 = to - from;\n\tv77 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, v66.defaultEaseOvershootOrAmplitude, v66.defaultEasePeriod);\n\tv78 = v76 * v77;\n\treturnVal1 = from + v78;\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType)
		{
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
			float num3 = num * num2;
			float x = vector2.x + num3;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0xC0B16C", Offset = "0xC0B16C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv50 = DG.Tweening.DOTween;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, v2, to, v3, v5, lifetimePercentage, overshoot);\n\tv61 = 1;\n\t*([1A356BB]) = v61;\nL_002B:\n\tgoto L_0038;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v53, v54, v55, v56, v57, v58, from, v0, v2, to, v3, v5, lifetimePercentage, overshoot);\n\tv68 = DG.Tweening.DOTween;\nL_0038:\n\tv79 = to - from;\n\tv80 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, overshoot, v69.defaultEasePeriod);\n\tv81 = v79 * v80;\n\treturnVal1 = from + v81;\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType, float overshoot)
		{
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, overshoot, DOTween.defaultEasePeriod);
			float num3 = num * num2;
			float x = vector2.x + num3;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0xC0B248", Offset = "0xC0B248", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = to - from;\n\tv36 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, amplitude, period);\n\tv38 = v25 * v36;\n\treturnVal1 = from + v38;\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType, float amplitude, float period)
		{
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, amplitude, period);
			float num3 = num * num2;
			float x = vector2.x + num3;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0xC0B2BC", Offset = "0xC0B2BC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv58 = DG.Tweening.DOTween;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, lifetimePercentage, v67);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, lifetimePercentage, v67);\n\tv81 = DG.Tweening.Core.Easing.EaseCurve;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, lifetimePercentage, v67);\n\tv86 = DG.Tweening.EaseFunction;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v61, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, lifetimePercentage, v67);\n\tv71 = 1;\n\t*([1A356BC]) = v71;\nL_0038:\n\tv73 = new DG.Tweening.Core.Easing.EaseCurve();\n\tDG.Tweening.Core.Easing.EaseCurve::.ctor(v73, easeCurve);\n\tv84 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v84, v73, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v90, v88, v87, v62, v63, v64, v65, v66, from, v0, v2, to, v3, v5, lifetimePercentage, v67);\n\tv96 = DG.Tweening.DOTween;\nL_0054:\n\tv107 = to - from;\n\tv108 = DG.Tweening.Core.Easing.EaseManager::Evaluate(0x25, v84, lifetimePercentage, 1f, v97.defaultEaseOvershootOrAmplitude, v97.defaultEasePeriod);\n\tv109 = v107 * v108;\n\treturnVal1 = from + v109;\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, AnimationCurve easeCurve)
		{
			EaseCurve easeCurve2 = new EaseCurve(easeCurve);
			EaseFunction customEase = easeCurve2.Evaluate;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = EaseManager.Evaluate(Ease.INTERNAL_Custom, customEase, lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
			float num3 = num * num2;
			float x = vector2.x + num3;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0xC0B40C", Offset = "0xC0B40C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv28 = DG.Tweening.DOTween;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, ignoreTimeScale, methodInfo, v31, v32, v33, v34, v35, delay, v36, v37, v38, v39, v40, v41, v42);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, ignoreTimeScale, methodInfo, v31, v32, v33, v34, v35, delay, v36, v37, v38, v39, v40, v41, v42);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, ignoreTimeScale, methodInfo, v31, v32, v33, v34, v35, delay, v36, v37, v38, v39, v40, v41, v42);\n\tv69 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, ignoreTimeScale, methodInfo, v31, v32, v33, v34, v35, delay, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A356BD]) = v46;\nL_002B:\n\tgoto L_002D;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v47, ignoreTimeScale, methodInfo, v31, v32, v33, v34, v35, delay, v36, v37, v38, v39, v40, v41, v42);\nL_002D:\n\tv62 = DG.Tweening.DOTween::Sequence();\n\tv67 = DG.Tweening.TweenSettingsExtensions::AppendInterval(v62, delay);\n\tv72 = DG.Tweening.TweenSettingsExtensions::OnStepComplete(v67, callback);\n\tv76 = DG.Tweening.TweenSettingsExtensions::SetUpdate(v72, 0, ignoreTimeScale);\n\treturnVal1 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(v76, 1);\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tween DelayedCall(float delay, TweenCallback callback, bool ignoreTimeScale = true)
		{
			Sequence s = DOTween.Sequence();
			Sequence t = s.AppendInterval(delay);
			Sequence t2 = t.OnStepComplete(callback);
			Sequence t3 = t2.SetUpdate(default(UpdateType), ignoreTimeScale);
			return t3.SetAutoKill(autoKillOnCompletion: true);
		}
	}
}

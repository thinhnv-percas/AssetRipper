using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x2000009")]
	public class SkeletonAnimationMulti : MonoBehaviour
	{
		[Token(Token = "0x4000020")]
		private const int MainTrackIndex = 0;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x20")]
		public bool initialFlipX;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x21")]
		public bool initialFlipY;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x28")]
		public string initialAnimation;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x30")]
		public bool initialLoop;

		[Space]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x38")]
		public List<SkeletonDataAsset> skeletonDataAssets;

		[Header("Settings")]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x40")]
		public MeshGenerator.Settings meshGeneratorSettings;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x50")]
		private readonly List<SkeletonAnimation> skeletonAnimations;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x58")]
		private readonly Dictionary<string, Animation> animationNameTable;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x60")]
		private readonly Dictionary<Animation, SkeletonAnimation> animationSkeletonTable;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x68")]
		private SkeletonAnimation currentSkeletonAnimation;

		[Token(Token = "0x17000003")]
		public Dictionary<Animation, SkeletonAnimation> AnimationSkeletonTable
		{
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x1509468", Offset = "0x1509468", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animationSkeletonTable;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnimationSkeletonTable;
			}
		}

		[Token(Token = "0x17000004")]
		public Dictionary<string, Animation> AnimationNameTable
		{
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x1509470", Offset = "0x1509470", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.animationNameTable;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnimationNameTable;
			}
		}

		[Token(Token = "0x17000005")]
		public SkeletonAnimation CurrentSkeletonAnimation
		{
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x1509478", Offset = "0x1509478", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentSkeletonAnimation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentSkeletonAnimation;
			}
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x1508A64", Offset = "0x1508A64", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv163 = Il2CppMethodInfo;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv168 = Il2CppMethodInfo;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv191 = Il2CppMethodInfo;\n\tv192 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv209 = Il2CppMethodInfo;\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv218 = Il2CppMethodInfo;\n\tv219 = \"il2cpp_codegen_initialize_runtime_metadata\"(v218, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv230 = UnityEngine.Object;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A379E0]) = v44;\nL_002E:\n\tv49 = this.skeletonAnimations == 0;\n\tif (v49) goto L_0089;\n\tv68 = System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>::GetEnumerator(this.skeletonAnimations);\nL_0045:\n\tv179 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v67 @ stack_-78_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv194 = v179 == 0;\n\tif (v194) goto L_005B;\n\tv221 = UnityEngine.Component::get_gameObject(v166);\n\tgoto L_0057;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v231, v220, v27, v28, v29, v30, v31, v32, v125, v34, v35, v36, v37, v38, v39, v40);\nL_0057:\n\tUnityEngine.Object::Destroy(v221);\n\tgoto L_0045;\nL_005B:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v67 @ stack_-78_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_005C:\n\tv157 = this.skeletonAnimations;\n\tv152 = this.skeletonAnimations == 0;\n\tif (v152) goto L_0089;\n\tv114 = v157._version + 1;\n\tv157._size = 0;\n\tv157._version = v114;\n\tv78 = v157._size < 1;\n\tif (v78) goto L_0075;\n\tSystem.Array::Clear(v157._items, 0, v157._size);\nL_0075:\n\tv153 = this.animationNameTable == 0;\n\tif (v153) goto L_0089;\n\tv136 = *([v135 @ X22_v2 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, Spine.Animation>::Clear(this.animationNameTable);\n\tv154 = this.animationSkeletonTable == 0;\n\tif (v154) goto L_0089;\n\tSystem.Collections.Generic.Dictionary`2<Spine.Animation, Spine.Unity.SkeletonAnimation>::Clear(this.animationSkeletonTable);\n\treturn;\n\tv146 = new System.NullReferenceException();\nL_0089:\n\tv161 = new System.NullReferenceException();\n\tgoto L_0095;\n\tgoto L_0095;\nL_0095:\n\tv189 = v136 != 1;\n\tif (v189) goto L_00A4;\n\tv195 = System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>+Enumerator<Spine.Unity.SkeletonAnimation>::MoveNext(v161);\n\tv214 = System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>+Enumerator<Spine.Unity.SkeletonAnimation>::MoveNext(v195);\n\tv138 = *([v130 @ X23_v1 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v123 @ stack_-60_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv203 = ~v195.m_value;\n\tif (v203) goto L_005C;\n\tv201 = new System.OutOfMemoryException();\nL_00A4:\n\tgoto L_00A8;\n\tX19 = X0;\nL_00A8:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v123 @ stack_-60_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00B0;\n\tv237 = 0xBD3CD0(v161, *([v130 @ X23_v1 (Il2CppMethodInfo)]), v115, v72, v29, v30, v31, v32, v124, v34, v35, v36, v37, v38, v39, v40);\nL_00B0:\n\tv240 = new System.OutOfMemoryException();\n\tv247 = 0x9DACB4(v240, *([v130 @ X23_v1 (Il2CppMethodInfo)]), v115, v72, v29, v30, v31, v32, v124, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Clear()
		{
			//IL_015b: Expected O, but got I4
			//IL_0160: Expected I, but got O
			bool flag = skeletonAnimations == null;
			object obj2 = default(object);
			object obj = obj2;
			int num2 = default(int);
			int num = num2;
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			List<object>.Enumerator enumerator = enumerator2;
			nint num4 = default(nint);
			nint num3 = num4;
			nint num6 = default(nint);
			nint num5 = num6;
			List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
			object obj4;
			object obj5 = default(object);
			int num7;
			int num8 = default(int);
			nint num9;
			List<object>.Enumerator enumerator5 = default(List<object>.Enumerator);
			if (!flag)
			{
				List<SkeletonAnimation>.Enumerator enumerator3 = skeletonAnimations.GetEnumerator();
				Component component = default(Component);
				while (enumerator4.MoveNext())
				{
					GameObject obj3 = component.gameObject;
					UnityEngine.Object.Destroy(obj3);
				}
				enumerator4.Dispose();
				obj4 = obj5;
				num7 = num8;
				enumerator5 = enumerator4;
				enumerator2 = enumerator4;
				num4 = 0;
				num6 = 0;
				num9 = 0;
				goto IL_007a;
			}
			goto IL_0229;
			IL_0229:
			NullReferenceException ex = new NullReferenceException();
			nint num10 = default(nint);
			if (num10 == 1)
			{
				bool flag2 = ((List<SkeletonAnimation>.Enumerator*)ex)->MoveNext();
				bool flag3 = (flag2 ? ((List<SkeletonAnimation>.Enumerator*)1) : ((List<SkeletonAnimation>.Enumerator*)null))->MoveNext();
				num9 = num3;
				enumerator5.Dispose();
				bool flag4 = !((bool*)(flag2 ? 1 : 0))->m_value;
				obj4 = obj;
				num7 = num;
				enumerator2 = enumerator;
				num4 = num3;
				num6 = num5;
				if (flag4)
				{
					goto IL_007a;
				}
				OutOfMemoryException ex2 = new OutOfMemoryException();
				ex = (NullReferenceException)(object)ex2;
			}
			enumerator5.Dispose();
			OutOfMemoryException ex3 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			return;
			IL_007a:
			List<SkeletonAnimation> list = skeletonAnimations;
			bool flag5 = skeletonAnimations == null;
			obj = obj5;
			num = num8;
			enumerator5 = enumerator4;
			enumerator = enumerator4;
			num3 = 0;
			num5 = 0;
			num10 = 0;
			if (!flag5)
			{
				int version = list._version + 1;
				list._size = 0;
				list._version = version;
				bool flag6 = list.Count < 1;
				obj2 = obj4;
				nint num11 = num9;
				if (!flag6)
				{
					Array.Clear(list._items, 0, list.Count);
					obj2 = 0;
					num11 = unchecked((nint)null);
				}
				bool flag7 = AnimationNameTable == null;
				obj = obj4;
				num = num7;
				enumerator = enumerator2;
				num3 = num4;
				num5 = num6;
				num10 = num9;
				if (!flag7)
				{
					num10 = num6;
					AnimationNameTable.Clear();
					bool flag8 = AnimationSkeletonTable == null;
					obj = obj2;
					num = list.Count;
					enumerator = enumerator2;
					num3 = num4;
					num5 = num6;
					num10 = num11;
					if (!flag8)
					{
						AnimationSkeletonTable.Clear();
						return;
					}
				}
			}
			goto IL_0229;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x1508C78", Offset = "0x1508C78", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, skeletonAnimation, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, skeletonAnimation, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, skeletonAnimation, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv98 = Il2CppMethodInfo;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, skeletonAnimation, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv127 = UnityEngine.Object;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, skeletonAnimation, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A379E1]) = v45;\nL_0026:\n\tv50 = this.skeletonAnimations == 0;\n\tif (v50) goto L_0065;\n\tv65 = System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>::GetEnumerator(this.skeletonAnimations);\nL_0039:\n\tv115 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v64 @ stack_-78_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv129 = v115 == 0;\n\tif (v129) goto L_0057;\n\tv149 = UnityEngine.Component::get_gameObject(v96);\n\tgoto L_004D;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v194, v148, v100, v29, v30, v31, v32, v33, v75, v35, v36, v37, v38, v39, v40, v41);\nL_004D:\n\tv200 = UnityEngine.Object::op_Equality(v96, skeletonAnimation);\n\tUnityEngine.GameObject::SetActive(v149, v200);\n\tgoto L_0039;\nL_0057:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v64 @ stack_-78_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0058:\n\tthis.currentSkeletonAnimation = skeletonAnimation;\n\treturn;\n\tv150 = new System.NullReferenceException();\n\tv84 = new System.NullReferenceException();\nL_0065:\n\tv91 = new System.NullReferenceException();\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\nL_0074:\n\tv125 = v78 != 1;\n\tif (v125) goto L_0082;\n\tv130 = 0x1854E70(v91, v78, v66, v29, v30, v31, v32, v33, v64, v35, v36, v37, v38, v39, v40, v41);\n\tv144 = 0x1854E80(v130, v78, v66, v29, v30, v31, v32, v33, v64, v35, v36, v37, v38, v39, v40, v41);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v72 @ stack_-60_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv136 = *([v130 @ X0_v13]) == 0;\n\tif (v136) goto L_0058;\n\tv134 = new System.OutOfMemoryException();\nL_0082:\n\tgoto L_0086;\n\tX19 = X0;\nL_0086:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v72 @ stack_-60_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_008D;\n\tv229 = 0xBD3CD0(v91, *([v80 @ X23_v1 (Il2CppMethodInfo)]), v66, v29, v30, v31, v32, v33, v64, v35, v36, v37, v38, v39, v40, v41);\nL_008D:\n\tv232 = new System.OutOfMemoryException();\n\tv222 = 0x9DACB4(v232, *([v80 @ X23_v1 (Il2CppMethodInfo)]), v66, v29, v30, v31, v32, v33, v64, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetActiveSkeleton(SkeletonAnimation skeletonAnimation)
		{
			bool flag = skeletonAnimations == null;
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			List<object>.Enumerator enumerator = enumerator2;
			nint num = 0;
			if (!flag)
			{
				List<SkeletonAnimation>.Enumerator enumerator3 = skeletonAnimations.GetEnumerator();
				Component component = default(Component);
				while (enumerator2.MoveNext())
				{
					GameObject gameObject = component.gameObject;
					bool active = component == skeletonAnimation;
					gameObject.SetActive(active);
				}
				enumerator2.Dispose();
				goto IL_0061;
			}
			NullReferenceException ex = new NullReferenceException();
			SkeletonAnimation skeletonAnimation2 = default(SkeletonAnimation);
			if ((nint)skeletonAnimation2 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0061;
				}
				OutOfMemoryException ex2 = new OutOfMemoryException();
				ex = (NullReferenceException)(object)ex2;
			}
			enumerator.Dispose();
			OutOfMemoryException ex3 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			return;
			IL_0061:
			currentSkeletonAnimation = skeletonAnimation;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x1508E38", Offset = "0x1508E38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonAnimationMulti::Initialize(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Initialize(overwrite: false);
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x1508E40", Offset = "0x1508E40", Length = "0x628")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0055;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv265 = Il2CppMethodInfo;\n\tv266 = \"il2cpp_codegen_initialize_runtime_metadata\"(v265, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv353 = Il2CppMethodInfo;\n\tv354 = \"il2cpp_codegen_initialize_runtime_metadata\"(v353, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv434 = Il2CppMethodInfo;\n\tv435 = \"il2cpp_codegen_initialize_runtime_metadata\"(v434, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv497 = Il2CppMethodInfo;\n\tv498 = \"il2cpp_codegen_initialize_runtime_metadata\"(v497, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv520 = Il2CppMethodInfo;\n\tv521 = \"il2cpp_codegen_initialize_runtime_metadata\"(v520, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv602 = Il2CppMethodInfo;\n\tv603 = \"il2cpp_codegen_initialize_runtime_metadata\"(v602, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv700 = Il2CppMethodInfo;\n\tv701 = \"il2cpp_codegen_initialize_runtime_metadata\"(v700, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv756 = Il2CppMethodInfo;\n\tv757 = \"il2cpp_codegen_initialize_runtime_metadata\"(v756, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv845 = Il2CppMethodInfo;\n\tv846 = \"il2cpp_codegen_initialize_runtime_metadata\"(v845, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv927 = Il2CppMethodInfo;\n\tv928 = \"il2cpp_codegen_initialize_runtime_metadata\"(v927, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1006 = Il2CppMethodInfo;\n\tv1007 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1006, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1073 = Il2CppMethodInfo;\n\tv1074 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1073, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1136 = Il2CppMethodInfo;\n\tv1137 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1136, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1187 = Il2CppMethodInfo;\n\tv1188 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1187, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1193 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1193, overwrite, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A379E2]) = v57;\nL_0055:\n\tv67 = this.skeletonAnimations;\n\tv73 = v67._size == 0;\n\tif (v73) goto L_005F;\n\tv268 = overwrite == 0;\n\tif (v268) goto L_0192;\nL_005F:\n\tSpine.Unity.SkeletonAnimationMulti::Clear(this);\n\tv237 = UnityEngine.Component::get_transform(this);\n\tv506 = System.Collections.Generic.List`1<Spine.Unity.SkeletonDataAsset>::GetEnumerator(this.skeletonDataAssets);\nL_007B:\n\tv642 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v505 @ stack_-E8_v19 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv703 = v642 == 0;\n\tif (v703) goto L_00E6;\n\tv760 = Spine.Unity.SkeletonAnimation::NewSkeletonAnimationGameObject(v524);\n\tv901 = UnityEngine.Component::get_transform(v760);\n\tUnityEngine.Transform::SetParent(v901, v237, 0);\n\tSpine.Unity.SkeletonRenderer::SetMeshSettings(v760, this.meshGeneratorSettings);\n\tv690 = v760.skeleton;\n\tv760.initialFlipX = this.initialFlipX;\n\tv760.initialFlipY = this.initialFlipY;\n\tif (this.initialFlipX) goto L_FFFFFFFF;\n\tgoto L_00B3;\nL_00B3:\n\tif (this.initialFlipY) goto L_FFFFFFFF;\n\tgoto L_00B8;\nL_00B8:\n\tv690.scaleX = v581;\n\tv690.scaleY = v547;\n\tv747 = *([v760 @ X0_v91 (Spine.Unity.SkeletonAnimation)]);\n\tv886 = *([v747 @ X8_v54 (Il2CppClass<Spine.Unity.SkeletonAnimation>)+1D0]);\n\tv1211 = Spine.Unity.SkeletonAnimation::Initialize(v760, 0);\n\tv589 = this.skeletonAnimations;\n\tv595 = v589._items;\n\tv567 = v589._version + 1;\n\tv589._version = v567;\n\tv625 = v589._size;\n\tv1216 = v589._size < v595.Length;\n\tv623 = ~v1216;\n\tif (v623) goto L_00E0;\n\tv632 = v589._size + 1;\n\tv589._size = v632;\n\tv595[v625 @ X10_v20 (System.Int32)] = v760;\n\tgoto L_007B;\nL_00E0:\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>::AddWithResize(v589, v760);\n\tgoto L_007B;\nL_00E6:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v505 @ stack_-E8_v19 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00F0:\n\tv935 = System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>::GetEnumerator(v904.skeletonAnimations);\nL_0103:\n\tv1084 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v505 @ stack_-E8_v19 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv921 = v1084 == 0;\n\tif (v921) goto L_0169;\n\tv1054 = Spine.Unity.SkeletonRenderer::get_Skeleton(v524);\n\tv1060 = v1054.data;\n\tv1214 = Spine.ExposedList`1<Spine.Animation>::GetEnumerator(v1060.animations);\nL_011E:\n\tv1226 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v328 @ stack_-E8_v18 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv1229 = v1226 == 0;\n\tif (v1229) goto L_0138;\n\tv341 = v524 == 0;\n\tif (v341) goto L_014B;\n\tv342 = v904.animationNameTable == 0;\n\tif (v342) goto L_014D;\n\tSystem.Collections.Generic.Dictionary`2<System.String, Spine.Animation>::set_Item(v904.animationNameTable, v524.m_CachedPtr, v524);\n\tv340 = v904.animationSkeletonTable == 0;\n\tif (v340) goto L_0149;\n\tSystem.Collections.Generic.Dictionary`2<Spine.Animation, Spine.Unity.SkeletonAnimation>::set_Item(v904.animationSkeletonTable, v524, v524);\n\tgoto L_011E;\nL_0138:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v328 @ stack_-E8_v18 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_01A3;\n\tgoto L_0103;\n\tgoto L_0148;\nL_0148:\n\tgoto L_0182;\nL_0149:\n\tv335 = new System.NullReferenceException();\n\tgoto L_01AB;\nL_014B:\n\tv335 = new System.NullReferenceException();\n\tgoto L_01AB;\nL_014D:\n\tv335 = new System.NullReferenceException();\n\tgoto L_01AB;\n\tgoto L_0154;\n\tgoto L_0154;\n\tgoto L_0154;\n\tgoto L_0154;\n\tgoto L_0154;\nL_0154:\n\tX22 = X1;\n\tC = X22 < 1;\n\tC = ~C;\n\tTEMP1 = X22 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ 1;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0193;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = 0;\n\tgoto L_0138;\nL_0169:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v505 @ stack_-E8_v19 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0171:\n\tv1003 = System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>::get_Item(v904.skeletonAnimations, 0);\n\tSpine.Unity.SkeletonAnimationMulti::SetActiveSkeleton(v904, v1003);\n\tv1133 = Spine.Unity.SkeletonAnimationMulti::FindAnimation(v904, v904.initialAnimation);\n\tv406 = Spine.Unity.SkeletonAnimationMulti::SetAnimation(v904, v1133, v904.initialLoop);\n\tgoto L_0192;\nL_0182:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v505 @ stack_-E8_v19 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0192:\n\treturn;\nL_0193:\n\tX20 = X0;\n\tX23 = 0;\nL_0195:\n\t;\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v938 @ stack_-D0_v8 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv495 = v887 == 0;\n\tif (v495) goto L_01BF;\n\tv508 = new System.\n// ... truncated")]
		public void Initialize(bool overwrite)
		{
			//IL_062e: Expected I, but got O
			//IL_02b3: Expected O, but got I
			//IL_032a: Expected I, but got O
			//IL_04e4: Expected O, but got I
			//IL_04e4: Expected O, but got I
			//IL_04f5: Expected O, but got I
			//IL_04f5: Expected O, but got I
			//IL_02f4: Expected I, but got O
			//IL_05c0: Expected O, but got I
			//IL_05c0: Expected O, but got I
			//IL_05e7: Expected O, but got I
			//IL_05e7: Expected O, but got I
			List<SkeletonAnimation> list = skeletonAnimations;
			if (list.Count != 0 && !overwrite)
			{
				return;
			}
			Clear();
			Transform parent = base.transform;
			List<SkeletonDataAsset>.Enumerator enumerator = skeletonDataAssets.GetEnumerator();
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			SkeletonDataAsset skeletonDataAsset = default(SkeletonDataAsset);
			nint num2 = default(nint);
			while (enumerator2.MoveNext())
			{
				SkeletonAnimation skeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(skeletonDataAsset);
				Transform transform = skeletonAnimation.transform;
				transform.SetParent(parent, worldPositionStays: false);
				skeletonAnimation.SetMeshSettings(meshGeneratorSettings);
				Skeleton skeleton = skeletonAnimation.skeleton;
				skeletonAnimation.initialFlipX = initialFlipX;
				skeletonAnimation.initialFlipY = initialFlipY;
				float scaleX = (initialFlipX ? (-1f) : 1f);
				float scaleY = (initialFlipY ? (-1f) : 1f);
				skeleton.ScaleX = scaleX;
				skeleton.ScaleY = scaleY;
				nint num = (nint)skeletonAnimation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ X8_v54 (Il2CppClass<Spine.Unity.SkeletonAnimation>)+1D0]");
				num2 = 0;
				skeletonAnimation.Initialize(overwrite: false);
				List<SkeletonAnimation> list2 = skeletonAnimations;
				SkeletonAnimation[] items = list2._items;
				int version = list2._version + 1;
				list2._version = version;
				int count = list2.Count;
				if (list2.Count < items.Length)
				{
					int size = list2.Count + 1;
					list2._size = size;
					items[count] = skeletonAnimation;
				}
				else
				{
					list2.Add(skeletonAnimation);
					num2 = 0;
				}
			}
			enumerator2.Dispose();
			List<object>.Enumerator enumerator3 = enumerator2;
			List<SkeletonAnimation>.Enumerator enumerator4 = skeletonAnimations.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				Skeleton skeleton2 = ((SkeletonRenderer)(object)skeletonDataAsset).Skeleton;
				SkeletonData data = skeleton2.Data;
				ExposedList<Animation>.Enumerator enumerator5 = data.Animations.GetEnumerator();
				ExposedList<object>.Enumerator enumerator6 = default(ExposedList<object>.Enumerator);
				NullReferenceException ex;
				ExposedList<object>.Enumerator enumerator7;
				List<object>.Enumerator enumerator8;
				SkeletonAnimation skeletonAnimation2;
				nint num3;
				nint num4;
				while (true)
				{
					if (enumerator6.MoveNext())
					{
						if ((object)skeletonDataAsset != null)
						{
							if (AnimationNameTable != null)
							{
								AnimationNameTable[(string)(nint)((UnityEngine.Object)skeletonDataAsset).m_CachedPtr] = (Animation)(object)skeletonDataAsset;
								if (AnimationSkeletonTable != null)
								{
									AnimationSkeletonTable[(Animation)(object)skeletonDataAsset] = (SkeletonAnimation)(object)skeletonDataAsset;
									num2 = (nint)skeletonDataAsset;
									continue;
								}
								ex = new NullReferenceException();
								enumerator7 = enumerator6;
								enumerator8 = enumerator2;
								num2 = (nint)skeletonDataAsset;
								skeletonAnimation2 = (SkeletonAnimation)(object)skeletonDataAsset;
								num3 = 0;
								num4 = ((UnityEngine.Object)skeletonDataAsset).m_CachedPtr;
								break;
							}
							ex = new NullReferenceException();
							enumerator7 = enumerator6;
							enumerator8 = enumerator2;
							skeletonAnimation2 = (SkeletonAnimation)(object)skeletonDataAsset;
							num3 = 0;
							num4 = 0;
							break;
						}
						ex = new NullReferenceException();
						enumerator7 = enumerator6;
						enumerator8 = enumerator2;
						skeletonAnimation2 = (SkeletonAnimation)(object)skeletonDataAsset;
						num3 = 0;
						num4 = 0;
						break;
					}
					enumerator6.Dispose();
					enumerator7 = enumerator6;
					enumerator8 = enumerator2;
					skeletonAnimation2 = null;
					num3 = 0;
					num4 = 0;
					OutOfMemoryException ex2 = new OutOfMemoryException();
					NullReferenceException ex3 = new NullReferenceException();
					NullReferenceException ex4 = new NullReferenceException();
					NullReferenceException ex5 = new NullReferenceException();
					NullReferenceException ex6 = new NullReferenceException();
					ex = new NullReferenceException();
					break;
				}
				enumerator7.Dispose();
				if ((object)skeletonAnimation2 != null)
				{
					OutOfMemoryException ex7 = new OutOfMemoryException();
					NullReferenceException ex8 = new NullReferenceException();
					NullReferenceException ex9 = new NullReferenceException();
					NullReferenceException ex10 = new NullReferenceException();
					NullReferenceException ex11 = new NullReferenceException();
					throw new NullReferenceException();
				}
				nint num6;
				if (num4 == 1)
				{
					((Dictionary<string, Animation>)(object)ex)[(string)num3] = (Animation)num2;
					Dictionary<string, Animation> dictionary = default(Dictionary<string, Animation>);
					dictionary[(string)num3] = (Animation)num2;
					enumerator8.Dispose();
					if (dictionary == null)
					{
						goto IL_03bc;
					}
					OutOfMemoryException ex12 = new OutOfMemoryException();
					enumerator3.Dispose();
					nint num5 = 0;
					NullReferenceException ex13 = (NullReferenceException)(object)ex12;
					num6 = 0;
				}
				else
				{
					enumerator8.Dispose();
					nint num5 = 0;
					NullReferenceException ex13 = ex;
					((Dictionary<string, Animation>)(object)ex13)[(string)num5] = (Animation)num2;
					num6 = num5;
				}
				OutOfMemoryException ex14 = new OutOfMemoryException();
				((Dictionary<string, Animation>)(object)ex14)[(string)num6] = (Animation)num2;
				return;
			}
			enumerator2.Dispose();
			goto IL_03bc;
			IL_03bc:
			SkeletonAnimation activeSkeleton = skeletonAnimations[0];
			SetActiveSkeleton(activeSkeleton);
			Animation animation = FindAnimation(initialAnimation);
			TrackEntry trackEntry = SetAnimation(animation, initialLoop);
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x15094AC", Offset = "0x15094AC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, animationName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A379E3]) = v36;\nL_001B:\n\tv46 = System.Collections.Generic.Dictionary`2<System.String, Spine.Animation>::TryGetValue(this.animationNameTable, animationName, &v43 @ stack_-28_v2 (System.Object));\n\treturn v43;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Animation FindAnimation(string animationName)
		{
			object value;
			bool flag = AnimationNameTable.TryGetValue(animationName, out *(Animation*)(&value));
			return (Animation)value;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x1509480", Offset = "0x1509480", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Spine.Unity.SkeletonAnimationMulti::FindAnimation(this, animationName);\n\treturnVal1 = Spine.Unity.SkeletonAnimationMulti::SetAnimation(this, v10, loop);\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry SetAnimation(string animationName, bool loop)
		{
			Animation animation = FindAnimation(animationName);
			return SetAnimation(animation, loop);
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x150951C", Offset = "0x150951C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, animation, loop, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = UnityEngine.Object;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, animation, loop, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A379E4]) = v40;\nL_0018:\n\tv42 = animation == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv56 = System.Collections.Generic.Dictionary`2<Spine.Animation, Spine.Unity.SkeletonAnimation>::TryGetValue(this.animationSkeletonTable, animation, &v52 @ stack_-28_v4 (System.Object));\n\tgoto L_002F;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v111, v53, v51, v54, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002F:\n\tv97 = UnityEngine.Object::op_Inequality(v52, 0);\n\tv100 = v97 == 0;\n\tif (v100) goto L_005B;\n\tSpine.Unity.SkeletonAnimationMulti::SetActiveSkeleton(this, v52);\n\tSpine.Skeleton::SetToSetupPose(*([v52 @ stack_-28_v4 (System.Object)+C8]));\n\tv73 = Spine.AnimationState::SetAnimation(*([v52 @ stack_-28_v4 (System.Object)+E8]), 0, animation, loop);\n\tSpine.Unity.SkeletonAnimation::Update(v52, 0f);\n\tgoto L_005B;\nL_005B:\n\treturn v103;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe TrackEntry SetAnimation(Animation animation, bool loop)
		{
			//IL_0071: Expected O, but got I
			//IL_0094: Expected O, but got I
			TrackEntry result;
			if (animation != null)
			{
				object value;
				bool flag = AnimationSkeletonTable.TryGetValue(animation, out *(SkeletonAnimation*)(&value));
				bool flag2 = (UnityEngine.Object)value != null;
				bool flag3 = !flag2;
				result = null;
				if (!flag3)
				{
					SetActiveSkeleton((SkeletonAnimation)value);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ stack_-28_v4 (System.Object)+C8]");
					((Skeleton)0).SetToSetupPose();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ stack_-28_v4 (System.Object)+E8]");
					TrackEntry trackEntry = ((AnimationState)0).SetAnimation(0, animation, loop);
					((SkeletonAnimation)value).Update(0f);
					result = trackEntry;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x1509640", Offset = "0x1509640", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentSkeletonAnimation;\n\tv28 = Spine.AnimationState::SetEmptyAnimation(v2.state, 0, mixDuration);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEmptyAnimation(float mixDuration)
		{
			SkeletonAnimation skeletonAnimation = CurrentSkeletonAnimation;
			TrackEntry trackEntry = skeletonAnimation.state.SetEmptyAnimation(0, mixDuration);
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x1509668", Offset = "0x1509668", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentSkeletonAnimation;\n\tSpine.AnimationState::ClearTrack(v2.state, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearAnimation()
		{
			SkeletonAnimation skeletonAnimation = CurrentSkeletonAnimation;
			skeletonAnimation.state.ClearTrack(0);
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x1509690", Offset = "0x1509690", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentSkeletonAnimation;\n\treturnVal2 = Spine.AnimationState::GetCurrent(v2.state, 0);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackEntry GetCurrent()
		{
			SkeletonAnimation skeletonAnimation = CurrentSkeletonAnimation;
			return skeletonAnimation.state.GetCurrent(0);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15096B8", Offset = "0x15096B8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv75 = System.Collections.Generic.Dictionary`2<Spine.Animation, Spine.Unity.SkeletonAnimation>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv80 = System.Collections.Generic.Dictionary`2<System.String, Spine.Animation>;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv95 = System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv100 = System.Collections.Generic.List`1<Spine.Unity.SkeletonDataAsset>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v100, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = 1;\n\t*([1A379E5]) = v66;\nL_003E:\n\tv68 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonDataAsset>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonDataAsset>::.ctor(v68);\n\tthis.skeletonDataAssets = v68;\n\tv78 = Spine.Unity.MeshGenerator+Settings::get_Default();\n\tthis.meshGeneratorSettings = v78;\n\tthis.meshGeneratorSettings.pmaVertexColors = Il2CppMethodInfo;\n\tv83 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonAnimation>::.ctor(v83);\n\tthis.skeletonAnimations = v83;\n\tv93 = new System.Collections.Generic.Dictionary`2<System.String, Spine.Animation>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, Spine.Animation>::.ctor(v93);\n\tthis.animationNameTable = v93;\n\tv102 = new System.Collections.Generic.Dictionary`2<Spine.Animation, Spine.Unity.SkeletonAnimation>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.Animation, Spine.Unity.SkeletonAnimation>::.ctor(v102);\n\tthis.animationSkeletonTable = v102;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonAnimationMulti()
		{
			List<SkeletonDataAsset> list = new List<SkeletonDataAsset>();
			skeletonDataAssets = list;
			MeshGenerator.Settings settings = MeshGenerator.Settings.Default;
			meshGeneratorSettings = settings;
			meshGeneratorSettings.pmaVertexColors = false;
			List<SkeletonAnimation> list2 = new List<SkeletonAnimation>();
			skeletonAnimations = list2;
			Dictionary<string, Animation> dictionary = new Dictionary<string, Animation>();
			animationNameTable = dictionary;
			Dictionary<Animation, SkeletonAnimation> dictionary2 = new Dictionary<Animation, SkeletonAnimation>();
			animationSkeletonTable = dictionary2;
		}
	}
}

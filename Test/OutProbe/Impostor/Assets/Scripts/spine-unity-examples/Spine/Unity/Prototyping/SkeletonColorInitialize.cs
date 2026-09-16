using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Prototyping
{
	[Token(Token = "0x200000A")]
	public class SkeletonColorInitialize : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x200000B")]
		public class SlotSettings
		{
			[SpineSlot(null, null, false, true, false)]
			[Token(Token = "0x400002D")]
			[FieldOffset(Offset = "0x10")]
			public string slot;

			[Token(Token = "0x400002E")]
			[FieldOffset(Offset = "0x18")]
			public Color color;

			[Token(Token = "0x6000028")]
			[Address(RVA = "0x1509ABC", Offset = "0x1509ABC", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = System.String;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379E8]) = v37;\nL_0019:\n\tthis.color = 0;\n\tthis.slot = v42.Empty;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SlotSettings()
			{
				color = default(Color);
				slot = string.Empty;
			}
		}

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x20")]
		public Color skeletonColor;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x30")]
		public List<SlotSettings> slotSettings;

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x1509818", Offset = "0x1509818", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Prototyping.SkeletonColorInitialize::ApplySettings(this);\n\treturn;\n")]
		private void Start()
		{
			ApplySettings();
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x150981C", Offset = "0x150981C", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv161 = Il2CppMethodInfo;\n\tv162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv226 = Spine.Unity.ISkeletonComponent;\n\tv227 = \"il2cpp_codegen_initialize_runtime_metadata\"(v226, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv250 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A379E6]) = v40;\nL_0025:\n\tv43 = 0;\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tv50 = v46 == 0;\n\tif (v50) goto L_0090;\n\tgoto L_0059;\n\tv163 = *([v55 @ X8_v4+B0]);\n\tv164 = v163 + 8;\n\tv166 = *([v239 @ X10_v8-8]);\n\tv244 = v166 == v59;\n\tif (v244) goto L_0051;\n\tv186 = v238 - 1;\n\tv188 = v239 + 0x10;\n\tv168 = v238 != 1;\n\tif (v168) goto L_FFFFFFFF;\n\tv189 = 1;\n\tv190 = v57;\n\tv191 = 0xB349B4(v190, v59, v189, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0059;\nL_0051:\n\tv252 = *([v239 @ X10_v8]);\n\tv253 = v252 + 1;\n\tv254 = v253 << 4;\n\tv255 = v55 + v254;\n\tv256 = v255 + 0x138;\nL_0059:\n\tv263 = Spine.Unity.ISkeletonComponent::get_Skeleton(v46);\n\t// 96 MakeStruct v62 @ AGG150D924_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), this.skeletonColor (UnityEngine.Color), this.skeletonColor.g (System.Single), this.skeletonColor.b (System.Single), this.skeletonColor.a (System.Single)\n\tSpine.Unity.SkeletonExtensions::SetColor(v263, v62);\n\tv270 = this.slotSettings == 0;\n\tif (v270) goto L_0093;\n\tv276 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>::GetEnumerator(this.slotSettings);\nL_0070:\n\tv300 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v43 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv141 = v300 == 0;\n\tif (v141) goto L_0089;\n\tv277 = 0;\n\tv296 = Spine.Skeleton::FindSlot(v263, *([v277 @ X22_v5 (System.Int32)+10]));\n\tv298 = v296 == 0;\n\tif (v298) goto L_0070;\n\t// 132 MakeStruct v286 @ AGG150D990_1_v4 (UnityEngine.Color), typeof(UnityEngine.Color), [v277 @ X22_v5 (System.Int32)+18], [v277 @ X22_v5 (System.Int32)+1C], [v277 @ X22_v5 (System.Int32)+20], [v277 @ X22_v5 (System.Int32)+24]\n\tSpine.Unity.SkeletonExtensions::SetColor(v296, v286);\n\tgoto L_0070;\nL_0089:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v43 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0090:\n\treturn;\n\tv312 = new System.NullReferenceException();\n\tv281 = new System.NullReferenceException();\nL_0093:\n\tv285 = new System.NullReferenceException();\n\tgoto L_00A2;\n\tgoto L_00A2;\n\tgoto L_00A2;\n\tgoto L_00A2;\nL_00A2:\n\tv95 = Il2CppMethodInfo != 1;\n\tif (v95) goto L_00B0;\n\tv305 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>+Enumerator<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>::MoveNext(v285);\n\tv313 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>+Enumerator<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>::MoveNext(v305);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v43 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv142 = ~v305.m_value;\n\tif (v142) goto L_0090;\n\tthrow System.OutOfMemoryException;\nL_00B0:\n\tgoto L_00B4;\n\tX19 = X0;\nL_00B4:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v43 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00BB;\n\tv319 = 0xBD3CD0(v285, *([v154 @ X21_v4 (Il2CppMethodInfo)]), v91, v24, v25, v26, v27, v28, v82, v79, v76, v73, v33, v34, v35, v36);\nL_00BB:\n\tv322 = new System.OutOfMemoryException();\n\tv217 = 0x9DACB4(v322, *([v154 @ X21_v4 (Il2CppMethodInfo)]), v91, v24, v25, v26, v27, v28, v82, v79, v76, v73, v33, v34, v35, v36);\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ApplySettings()
		{
			//IL_00ab: Expected O, but got I
			//IL_00ea: Expected F4, but got I
			//IL_00ff: Expected F4, but got I
			//IL_0114: Expected F4, but got I
			//IL_0129: Expected F4, but got I
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			ISkeletonComponent component = GetComponent<ISkeletonComponent>();
			if (component == null)
			{
				return;
			}
			Skeleton skeleton = component.Skeleton;
			Color color = default(Color);
			color.r = skeletonColor.r;
			color.g = skeletonColor.g;
			color.b = skeletonColor.b;
			color.a = skeletonColor.a;
			skeleton.SetColor(color);
			bool flag = slotSettings == null;
			nint num = 0;
			if (!flag)
			{
				List<SlotSettings>.Enumerator enumerator2 = slotSettings.GetEnumerator();
				float a = skeletonColor.a;
				float b = skeletonColor.b;
				float g = skeletonColor.g;
				Color color2 = skeletonColor;
				int num2 = 0;
				Color color3 = default(Color);
				while (enumerator.MoveNext())
				{
					int num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X22_v5 (System.Int32)+10]");
					Slot slot = skeleton.FindSlot((string)0);
					bool flag2 = slot == null;
					num2 = 0;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X22_v5 (System.Int32)+18]");
						color3.r = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X22_v5 (System.Int32)+1C]");
						color3.g = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X22_v5 (System.Int32)+20]");
						color3.b = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X22_v5 (System.Int32)+24]");
						color3.a = 0f;
						slot.SetColor(color3);
						num2 = 0;
					}
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((nint)0 == 1)
			{
				bool flag3 = ((List<SlotSettings>.Enumerator*)ex)->MoveNext();
				bool flag4 = (flag3 ? ((List<SlotSettings>.Enumerator*)1) : ((List<SlotSettings>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (((bool*)(flag3 ? 1 : 0))->m_value)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			}
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x1509A38", Offset = "0x1509A38", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A379E7]) = v42;\nL_001A:\n\tthis.skeletonColor = 0;\n\tv45 = new System.Collections.Generic.List`1<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Prototyping.SkeletonColorInitialize+SlotSettings>::.ctor(v45);\n\tthis.slotSettings = v45;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonColorInitialize()
		{
			skeletonColor = default(Color);
			List<SlotSettings> list = new List<SlotSettings>();
			slotSettings = list;
		}
	}
}

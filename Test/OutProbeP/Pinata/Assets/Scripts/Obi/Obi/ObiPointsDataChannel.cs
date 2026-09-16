using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200006F")]
	public class ObiPointsDataChannel : ObiPathDataChannel<ObiWingedPoint, Vector3>
	{
		[Token(Token = "0x600047B")]
		[Address(RVA = "0xC2D92C", Offset = "0xC2D92C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBD5A0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023185]) = v38;\nL_0016:\n\tv42 = new Obi.ObiCatmullRomInterpolator3D();\n\tObi.ObiCatmullRomInterpolator3D::.ctor(v42);\n\tObi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::.ctor(this, v42);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiPointsDataChannel()
			: base((ObiInterpolator<Vector3>)new ObiCatmullRomInterpolator3D())
		{
		}

		[Token(Token = "0x600047C")]
		[Address(RVA = "0xC30FE8", Offset = "0xC30FE8", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_001D;\n\tv38 = *([1ED41D0]);\n\tv39 = *([v38 @ X8_v12]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, index, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2023186]) = v57;\nL_001D:\n\t*([v26 @ X29_v1-70]) = 0;\n\t*([v26 @ X29_v1-90]) = 0;\n\t*([v26 @ X29_v1-80]) = 0;\n\tv66 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Count(this);\n\tv69 = index + 1;\n\tv70 = v69 / v66;\n\tv71 = v70 * v66;\n\tv72 = v69 - v71;\n\tv78 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, index);\n\t*([v26 @ X29_v1-70]) = v80;\n\t*([v26 @ X29_v1-90]) = v75;\n\t*([v26 @ X29_v1-80]) = v82;\n\tv89 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v72);\n\tv98 = &v27 @ stack_-10_v2 - 0x90;\n\tv103 = 0x10340E8(v98, 0, Il2CppMethodInfo, v42, v43, v44, v45, v46, v92, v86, v49, v50, v51, v52, v53, v54);\n\tv109 = 0x1034048(&v86 @ stack_-120_v1, 0, Il2CppMethodInfo, v42, v43, v44, v45, v46, v92, v86, v49, v50, v51, v52, v53, v54);\n\tv129 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this, Il2CppMethodInfo, Il2CppMethodInfo, v42, v43, *([v26 @ X29_v1-80]));\n\treturn *([v26 @ X29_v1-80]);\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 GetTangent(int index)
		{
			//IL_001c: Expected O, but got I
			//IL_005d: Expected F4, but got I
			//IL_005d: Expected O, but got I
			//IL_005d: Expected O, but got I
			//IL_006e: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			int count = base.Count;
			int num = index + 1;
			int num2 = num / count;
			int num3 = num2 * count;
			int i = num - num3;
			ObiWingedPoint obiWingedPoint = base.get_Item(index);
			ObiWingedPoint obiWingedPoint2 = base.get_Item(i);
			object obj3 = (long)(IntPtr)obj2 - 144L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
			Vector3 v = default(Vector3);
			Vector3 v2 = default(Vector3);
			Vector3 vector = EvaluateFirstDerivative((Vector3)(long)intPtr, (Vector3)(long)intPtr2, v, v2, 0f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
			return (Vector3)0;
		}

		[Token(Token = "0x600047D")]
		[Address(RVA = "0xC31158", Offset = "0xC31158", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_001D;\n\tv38 = *([1EFB0E0]);\n\tv39 = *([v38 @ X8_v12]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, index, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2023187]) = v57;\nL_001D:\n\t*([v26 @ X29_v1-70]) = 0;\n\t*([v26 @ X29_v1-90]) = 0;\n\t*([v26 @ X29_v1-80]) = 0;\n\tv66 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Count(this);\n\tv69 = index + 1;\n\tv70 = v69 / v66;\n\tv71 = v70 * v66;\n\tv72 = v69 - v71;\n\tv78 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, index);\n\t*([v26 @ X29_v1-70]) = v80;\n\t*([v26 @ X29_v1-90]) = v75;\n\t*([v26 @ X29_v1-80]) = v82;\n\tv89 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v72);\n\tv98 = &v27 @ stack_-10_v2 - 0x90;\n\tv103 = 0x10340E8(v98, 0, Il2CppMethodInfo, v42, v43, v44, v45, v46, v92, v86, v49, v50, v51, v52, v53, v54);\n\tv109 = 0x1034048(&v86 @ stack_-120_v1, 0, Il2CppMethodInfo, v42, v43, v44, v45, v46, v92, v86, v49, v50, v51, v52, v53, v54);\n\tv129 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateSecondDerivative(this, Il2CppMethodInfo, Il2CppMethodInfo, v42, v43, *([v26 @ X29_v1-80]));\n\treturn *([v26 @ X29_v1-80]);\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 GetAcceleration(int index)
		{
			//IL_001c: Expected O, but got I
			//IL_005d: Expected F4, but got I
			//IL_005d: Expected O, but got I
			//IL_005d: Expected O, but got I
			//IL_006e: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			int count = base.Count;
			int num = index + 1;
			int num2 = num / count;
			int num3 = num2 * count;
			int i = num - num3;
			ObiWingedPoint obiWingedPoint = base.get_Item(index);
			ObiWingedPoint obiWingedPoint2 = base.get_Item(i);
			object obj3 = (long)(IntPtr)obj2 - 144L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
			Vector3 v = default(Vector3);
			Vector3 v2 = default(Vector3);
			Vector3 vector = EvaluateSecondDerivative((Vector3)(long)intPtr, (Vector3)(long)intPtr2, v, v2, 0f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
			return (Vector3)0;
		}

		[Token(Token = "0x600047E")]
		[Address(RVA = "0xC312C8", Offset = "0xC312C8", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_001E;\n\tv40 = *([1EBF600]);\n\tv41 = *([v40 @ X8_v21]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, closed, methodInfo, v44, v45, v46, v47, v48, mu, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2023188]) = v58;\nL_001E:\n\t*([v26 @ X29_v1-24]) = 0;\n\t*([v26 @ X29_v1-70]) = 0;\n\t*([v26 @ X29_v1-90]) = 0;\n\t*([v26 @ X29_v1-80]) = 0;\n\tv67 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Count(this);\n\tv79 = v67 < 2;\n\tif (v79) goto L_008F;\n\tv83 = &v27 @ stack_-10_v2 - 0x24;\n\tv87 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::GetSpanControlPointAtMu(this, closed, mu, v83);\n\tv95 = v87 + 1;\n\tv96 = v95 / v67;\n\tv98 = v96 * v67;\n\tv99 = v95 - v98;\n\tv104 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v87);\n\t*([v26 @ X29_v1-70]) = v111;\n\t*([v26 @ X29_v1-90]) = v101;\n\t*([v26 @ X29_v1-80]) = v113;\n\tv120 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v99);\n\tv135 = &v27 @ stack_-10_v2 - 0x90;\n\tv140 = 0x10340E8(v135, 0, Il2CppMethodInfo, Il2CppMethodInfo, v45, v46, v47, v48, v129, v117, v50, v51, v52, v53, v54, v55);\n\tv146 = 0x1034048(&v117 @ stack_-120_v1, 0, Il2CppMethodInfo, Il2CppMethodInfo, v45, v46, v47, v48, v129, v117, v50, v51, v52, v53, v54, v55);\n\tv210 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::Evaluate(this, Il2CppMethodInfo, Il2CppMethodInfo, Il2CppMethodInfo, v45, *([v26 @ X29_v1-80]));\n\treturn *([v26 @ X29_v1-80]);\nL_008F:\n\tv91 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v91, \"Cannot get position in path because it has zero control points.\");\n\tthrow v91;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Vector3 GetPositionAtMu(bool closed, float mu)
		{
			//IL_00a6: Expected O, but got I
			//IL_00e5: Expected F4, but got I
			//IL_00e5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00fb: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			int count = base.Count;
			if (count >= 2)
			{
				int spanControlPointAtMu = GetSpanControlPointAtMu(closed, mu, out *(float*)((long)(IntPtr)obj2 - 36L));
				int num = spanControlPointAtMu + 1;
				int num2 = num / count;
				int num3 = num2 * count;
				int i = num - num3;
				ObiWingedPoint obiWingedPoint = base.get_Item(spanControlPointAtMu);
				ObiWingedPoint obiWingedPoint2 = base.get_Item(i);
				object obj3 = (long)(IntPtr)obj2 - 144L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)0;
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
				Vector3 v = default(Vector3);
				Vector3 vector = Evaluate((Vector3)(long)intPtr, (Vector3)(long)intPtr2, (Vector3)(long)intPtr3, v, 0f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
				return (Vector3)0;
			}
			InvalidOperationException ex = new InvalidOperationException("Cannot get position in path because it has zero control points.");
			throw ex;
		}

		[Token(Token = "0x600047F")]
		[Address(RVA = "0xC314B4", Offset = "0xC314B4", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_001E;\n\tv40 = *([1ED3000]);\n\tv41 = *([v40 @ X8_v21]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, closed, methodInfo, v44, v45, v46, v47, v48, mu, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2023189]) = v58;\nL_001E:\n\t*([v26 @ X29_v1-24]) = 0;\n\t*([v26 @ X29_v1-70]) = 0;\n\t*([v26 @ X29_v1-90]) = 0;\n\t*([v26 @ X29_v1-80]) = 0;\n\tv67 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Count(this);\n\tv79 = v67 < 2;\n\tif (v79) goto L_008F;\n\tv83 = &v27 @ stack_-10_v2 - 0x24;\n\tv87 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::GetSpanControlPointAtMu(this, closed, mu, v83);\n\tv95 = v87 + 1;\n\tv96 = v95 / v67;\n\tv98 = v96 * v67;\n\tv99 = v95 - v98;\n\tv104 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v87);\n\t*([v26 @ X29_v1-70]) = v111;\n\t*([v26 @ X29_v1-90]) = v101;\n\t*([v26 @ X29_v1-80]) = v113;\n\tv120 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v99);\n\tv135 = &v27 @ stack_-10_v2 - 0x90;\n\tv140 = 0x10340E8(v135, 0, Il2CppMethodInfo, Il2CppMethodInfo, v45, v46, v47, v48, v129, v117, v50, v51, v52, v53, v54, v55);\n\tv146 = 0x1034048(&v117 @ stack_-120_v1, 0, Il2CppMethodInfo, Il2CppMethodInfo, v45, v46, v47, v48, v129, v117, v50, v51, v52, v53, v54, v55);\n\tv210 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this, Il2CppMethodInfo, Il2CppMethodInfo, Il2CppMethodInfo, v45, *([v26 @ X29_v1-80]));\n\treturn *([v26 @ X29_v1-80]);\nL_008F:\n\tv91 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v91, \"Cannot get derivative in path because it has less than 2 control points.\");\n\tthrow v91;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Vector3 GetTangentAtMu(bool closed, float mu)
		{
			//IL_00a6: Expected O, but got I
			//IL_00e5: Expected F4, but got I
			//IL_00e5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00fb: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			int count = base.Count;
			if (count >= 2)
			{
				int spanControlPointAtMu = GetSpanControlPointAtMu(closed, mu, out *(float*)((long)(IntPtr)obj2 - 36L));
				int num = spanControlPointAtMu + 1;
				int num2 = num / count;
				int num3 = num2 * count;
				int i = num - num3;
				ObiWingedPoint obiWingedPoint = base.get_Item(spanControlPointAtMu);
				ObiWingedPoint obiWingedPoint2 = base.get_Item(i);
				object obj3 = (long)(IntPtr)obj2 - 144L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)0;
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
				Vector3 v = default(Vector3);
				Vector3 vector = EvaluateFirstDerivative((Vector3)(long)intPtr, (Vector3)(long)intPtr2, (Vector3)(long)intPtr3, v, 0f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
				return (Vector3)0;
			}
			InvalidOperationException ex = new InvalidOperationException("Cannot get derivative in path because it has less than 2 control points.");
			throw ex;
		}

		[Token(Token = "0x6000480")]
		[Address(RVA = "0xC316A0", Offset = "0xC316A0", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_001E;\n\tv40 = *([1EFFDB8]);\n\tv41 = *([v40 @ X8_v21]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, closed, methodInfo, v44, v45, v46, v47, v48, mu, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([202318A]) = v58;\nL_001E:\n\t*([v26 @ X29_v1-24]) = 0;\n\t*([v26 @ X29_v1-70]) = 0;\n\t*([v26 @ X29_v1-90]) = 0;\n\t*([v26 @ X29_v1-80]) = 0;\n\tv67 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Count(this);\n\tv79 = v67 < 2;\n\tif (v79) goto L_008F;\n\tv83 = &v27 @ stack_-10_v2 - 0x24;\n\tv87 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::GetSpanControlPointAtMu(this, closed, mu, v83);\n\tv95 = v87 + 1;\n\tv96 = v95 / v67;\n\tv98 = v96 * v67;\n\tv99 = v95 - v98;\n\tv104 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v87);\n\t*([v26 @ X29_v1-70]) = v111;\n\t*([v26 @ X29_v1-90]) = v101;\n\t*([v26 @ X29_v1-80]) = v113;\n\tv120 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this, v99);\n\tv135 = &v27 @ stack_-10_v2 - 0x90;\n\tv140 = 0x10340E8(v135, 0, Il2CppMethodInfo, Il2CppMethodInfo, v45, v46, v47, v48, v129, v117, v50, v51, v52, v53, v54, v55);\n\tv146 = 0x1034048(&v117 @ stack_-120_v1, 0, Il2CppMethodInfo, Il2CppMethodInfo, v45, v46, v47, v48, v129, v117, v50, v51, v52, v53, v54, v55);\n\tv210 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateSecondDerivative(this, Il2CppMethodInfo, Il2CppMethodInfo, Il2CppMethodInfo, v45, *([v26 @ X29_v1-80]));\n\treturn *([v26 @ X29_v1-80]);\nL_008F:\n\tv91 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v91, \"Cannot get second derivative in path because it has less than 2 control points.\");\n\tthrow v91;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Vector3 GetAccelerationAtMu(bool closed, float mu)
		{
			//IL_00a6: Expected O, but got I
			//IL_00e5: Expected F4, but got I
			//IL_00e5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00fb: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			int count = base.Count;
			if (count >= 2)
			{
				int spanControlPointAtMu = GetSpanControlPointAtMu(closed, mu, out *(float*)((long)(IntPtr)obj2 - 36L));
				int num = spanControlPointAtMu + 1;
				int num2 = num / count;
				int num3 = num2 * count;
				int i = num - num3;
				ObiWingedPoint obiWingedPoint = base.get_Item(spanControlPointAtMu);
				ObiWingedPoint obiWingedPoint2 = base.get_Item(i);
				object obj3 = (long)(IntPtr)obj2 - 144L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)0;
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
				Vector3 v = default(Vector3);
				Vector3 vector = EvaluateSecondDerivative((Vector3)(long)intPtr, (Vector3)(long)intPtr2, (Vector3)(long)intPtr3, v, 0f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-80]");
				return (Vector3)0;
			}
			InvalidOperationException ex = new InvalidOperationException("Cannot get second derivative in path because it has less than 2 control points.");
			throw ex;
		}
	}
}

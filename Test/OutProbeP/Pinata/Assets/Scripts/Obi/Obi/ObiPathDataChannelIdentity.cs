using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x200006D")]
	public abstract class ObiPathDataChannelIdentity<T> : ObiPathDataChannel<T, T>
	{
		[Token(Token = "0x6000474")]
		[Address(RVA = "0x11E2928", Offset = "0x11E2928", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X3_v1, this @ X0 (Obi.ObiPathDataChannelIdentity`1<T>), this @ X0 (Obi.ObiPathDataChannelIdentity`1<T>), interpolator @ X1 (Obi.ObiInterpolator`1<T>), methodof(Obi.ObiPathDataChannel`2<T, T>::.ctor), v6 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiPathDataChannelIdentity(ObiInterpolator<T> interpolator)
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000475")]
		[Address(RVA = "0x11E294C", Offset = "0x11E294C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = Obi.ObiPathDataChannel`2<T, T>::get_Count(this);\n\tv45 = index + 1;\n\tv46 = v45 / v30;\n\tv47 = v46 * v30;\n\tv48 = v45 - v47;\n\tv54 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, index);\n\tv62 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, index);\n\tv70 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v48);\n\tv78 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v48);\n\tv90 = Il2CppMethodInfo;\n\tv94 = *([v90 @ X5_v1 (Il2CppMethodInfo)]);\n\t// 75 IndirectJump v94 @ X6_v1, this @ X0 (Obi.ObiPathDataChannelIdentity`1<T>), this @ X0 (Obi.ObiPathDataChannelIdentity`1<T>), v54 @ X0_v5 (T), v62 @ X0_v7 (T), v70 @ X0_v9 (T), v78 @ X0_v11 (T), methodof(Obi.ObiPathDataChannel`2<T, T>::EvaluateFirstDerivative), v94 @ X6_v1, v35 @ X7, 0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetFirstDerivative(int index)
		{
			//IL_0085: Expected O, but got I
			int count = base.Count;
			int num = index + 1;
			int num2 = num / count;
			int num3 = num2 * count;
			int i = num - num3;
			T val = base.get_Item(index);
			T val2 = base.get_Item(index);
			T val3 = base.get_Item(i);
			T val4 = base.get_Item(i);
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X6_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000476")]
		[Address(RVA = "0x11E2A50", Offset = "0x11E2A50", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = Obi.ObiPathDataChannel`2<T, T>::get_Count(this);\n\tv45 = index + 1;\n\tv46 = v45 / v30;\n\tv47 = v46 * v30;\n\tv48 = v45 - v47;\n\tv54 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, index);\n\tv62 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, index);\n\tv70 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v48);\n\tv78 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v48);\n\tv90 = Il2CppMethodInfo;\n\tv94 = *([v90 @ X5_v1 (Il2CppMethodInfo)]);\n\t// 75 IndirectJump v94 @ X6_v1, this @ X0 (Obi.ObiPathDataChannelIdentity`1<T>), this @ X0 (Obi.ObiPathDataChannelIdentity`1<T>), v54 @ X0_v5 (T), v62 @ X0_v7 (T), v70 @ X0_v9 (T), v78 @ X0_v11 (T), methodof(Obi.ObiPathDataChannel`2<T, T>::EvaluateSecondDerivative), v94 @ X6_v1, v35 @ X7, 0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetSecondDerivative(int index)
		{
			//IL_0085: Expected O, but got I
			int count = base.Count;
			int num = index + 1;
			int num2 = num / count;
			int num3 = num2 * count;
			int i = num - num3;
			T val = base.get_Item(index);
			T val2 = base.get_Item(index);
			T val3 = base.get_Item(i);
			T val4 = base.get_Item(i);
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X6_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000477")]
		[Address(RVA = "0x11E2B54", Offset = "0x11E2B54", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = *([1EE5288]);\n\tv35 = *([v34 @ X8_v33]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, closed, methodInfo, v37, v38, v39, v40, v41, mu, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2027BF8]) = v51;\nL_0023:\n\tv59 = Obi.ObiPathDataChannel`2<T, T>::get_Count(this);\n\tv71 = v59 < 2;\n\tif (v71) goto L_0079;\n\tv83 = Obi.ObiPathDataChannel`2<T, T>::GetSpanControlPointAtMu(this, closed, mu, &v77 @ stack_-44_v2 (System.Single));\n\tv86 = v83 + 1;\n\tv87 = v86 / v59;\n\tv91 = v87 * v59;\n\tv92 = v86 - v91;\n\tv95 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v83);\n\tv103 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v83);\n\tv111 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v92);\n\tv119 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v92);\n\treturnVal1 = Obi.ObiPathDataChannel`2<T, T>::Evaluate(this, v95, v103, v111, v119, v77);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0079:\n\tv165 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v165, \"Cannot get property in path because it has less than 2 control points.\");\n\tthrow v165;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetAtMu(bool closed, float mu)
		{
			int count = base.Count;
			if (count >= 2)
			{
				int spanControlPointAtMu = GetSpanControlPointAtMu(closed, mu, out var spanMu);
				int num = spanControlPointAtMu + 1;
				int num2 = num / count;
				int num3 = num2 * count;
				int i = num - num3;
				T v = base.get_Item(spanControlPointAtMu);
				T v2 = base.get_Item(spanControlPointAtMu);
				T v3 = base.get_Item(i);
				T v4 = base.get_Item(i);
				return Evaluate(v, v2, v3, v4, spanMu);
			}
			InvalidOperationException ex = new InvalidOperationException("Cannot get property in path because it has less than 2 control points.");
			throw ex;
		}

		[Token(Token = "0x6000478")]
		[Address(RVA = "0x11E2D08", Offset = "0x11E2D08", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = *([1ECEB08]);\n\tv35 = *([v34 @ X8_v33]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, closed, methodInfo, v37, v38, v39, v40, v41, mu, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2027BF9]) = v51;\nL_0023:\n\tv59 = Obi.ObiPathDataChannel`2<T, T>::get_Count(this);\n\tv71 = v59 < 2;\n\tif (v71) goto L_0079;\n\tv83 = Obi.ObiPathDataChannel`2<T, T>::GetSpanControlPointAtMu(this, closed, mu, &v77 @ stack_-44_v2 (System.Single));\n\tv86 = v83 + 1;\n\tv87 = v86 / v59;\n\tv91 = v87 * v59;\n\tv92 = v86 - v91;\n\tv95 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v83);\n\tv103 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v83);\n\tv111 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v92);\n\tv119 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v92);\n\treturnVal1 = Obi.ObiPathDataChannel`2<T, T>::EvaluateFirstDerivative(this, v95, v103, v111, v119, v77);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0079:\n\tv165 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v165, \"Cannot get derivative in path because it has less than 2 control points.\");\n\tthrow v165;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetFirstDerivativeAtMu(bool closed, float mu)
		{
			int count = base.Count;
			if (count >= 2)
			{
				int spanControlPointAtMu = GetSpanControlPointAtMu(closed, mu, out var spanMu);
				int num = spanControlPointAtMu + 1;
				int num2 = num / count;
				int num3 = num2 * count;
				int i = num - num3;
				T v = base.get_Item(spanControlPointAtMu);
				T v2 = base.get_Item(spanControlPointAtMu);
				T v3 = base.get_Item(i);
				T v4 = base.get_Item(i);
				return EvaluateFirstDerivative(v, v2, v3, v4, spanMu);
			}
			InvalidOperationException ex = new InvalidOperationException("Cannot get derivative in path because it has less than 2 control points.");
			throw ex;
		}

		[Token(Token = "0x6000479")]
		[Address(RVA = "0x11E2EBC", Offset = "0x11E2EBC", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = *([1EFF418]);\n\tv35 = *([v34 @ X8_v33]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, closed, methodInfo, v37, v38, v39, v40, v41, mu, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2027BFA]) = v51;\nL_0023:\n\tv59 = Obi.ObiPathDataChannel`2<T, T>::get_Count(this);\n\tv71 = v59 < 2;\n\tif (v71) goto L_0079;\n\tv83 = Obi.ObiPathDataChannel`2<T, T>::GetSpanControlPointAtMu(this, closed, mu, &v77 @ stack_-44_v2 (System.Single));\n\tv86 = v83 + 1;\n\tv87 = v86 / v59;\n\tv91 = v87 * v59;\n\tv92 = v86 - v91;\n\tv95 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v83);\n\tv103 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v83);\n\tv111 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v92);\n\tv119 = Obi.ObiPathDataChannel`2<T, T>::get_Item(this, v92);\n\treturnVal1 = Obi.ObiPathDataChannel`2<T, T>::EvaluateSecondDerivative(this, v95, v103, v111, v119, v77);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0079:\n\tv165 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v165, \"Cannot get second derivative in path because it has less than 2 control points.\");\n\tthrow v165;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetSecondDerivativeAtMu(bool closed, float mu)
		{
			int count = base.Count;
			if (count >= 2)
			{
				int spanControlPointAtMu = GetSpanControlPointAtMu(closed, mu, out var spanMu);
				int num = spanControlPointAtMu + 1;
				int num2 = num / count;
				int num3 = num2 * count;
				int i = num - num3;
				T v = base.get_Item(spanControlPointAtMu);
				T v2 = base.get_Item(spanControlPointAtMu);
				T v3 = base.get_Item(i);
				T v4 = base.get_Item(i);
				return EvaluateSecondDerivative(v, v2, v3, v4, spanMu);
			}
			InvalidOperationException ex = new InvalidOperationException("Cannot get second derivative in path because it has less than 2 control points.");
			throw ex;
		}
	}
}

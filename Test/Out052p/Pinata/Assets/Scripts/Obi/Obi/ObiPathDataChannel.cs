using System;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x744E78", Offset = "0x744E78")]
	[Token(Token = "0x200006C")]
	public abstract class ObiPathDataChannel<T, U> : IObiPathDataChannel
	{
		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x0")]
		protected ObiInterpolator<U> interpolator;

		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x0")]
		protected bool dirty;

		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x0")]
		public List<T> data = new List<T>();

		[Token(Token = "0x170000B6")]
		public int Count
		{
			[Token(Token = "0x6000468")]
			[Address(RVA = "0x11E50E0", Offset = "0x11E50E0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.data;\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X2_v1, v0 @ X0_v1 (System.Collections.Generic.List`1<T>), v0 @ X0_v1 (System.Collections.Generic.List`1<T>), methodof(System.Collections.Generic.List`1<T>::get_Count), v7 @ X2_v1, v8 @ X3, v9 @ X4, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001d: Expected O, but got I
				List<T> list = data;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X2_v1 (should have been resolved before IL gen)");
				return 0;
			}
		}

		[Token(Token = "0x170000B7")]
		public bool Dirty
		{
			[Token(Token = "0x6000469")]
			[Address(RVA = "0x11E5108", Offset = "0x11E5108", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.dirty;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Dirty;
			}
		}

		[Token(Token = "0x170000B8")]
		public T Item
		{
			[Token(Token = "0x600046C")]
			[Address(RVA = "0x11E51A0", Offset = "0x11E51A0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.data;\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X3_v1, v0 @ X0_v1 (System.Collections.Generic.List`1<T>), v0 @ X0_v1 (System.Collections.Generic.List`1<T>), i @ X1 (System.Int32), methodof(System.Collections.Generic.List`1<T>::get_Item), v7 @ X3_v1, v9 @ X4, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001d: Expected O, but got I
				List<T> list = data;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X3_v1 (should have been resolved before IL gen)");
				return (T)null;
			}
			[Token(Token = "0x600046D")]
			[Address(RVA = "0x11E51C8", Offset = "0x11E51C8", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = value->klass;\n\tv32 = System.Collections.Generic.List`1<T>::set_Item(this.data, i, &v16 @ V0_v2 (Il2CppClass<T>));\n\tthis.dirty = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0008: Expected I, but got O
				//IL_0020: Expected O, but got I
				IntPtr intPtr = (IntPtr)value;
				data.set_Item(i, (T)(long)intPtr);
				dirty = true;
			}
		}

		[Token(Token = "0x600046A")]
		[Address(RVA = "0x11E5110", Offset = "0x11E5110", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.dirty = 0;\n\treturn;\n")]
		public void Clean()
		{
			dirty = false;
		}

		[Token(Token = "0x600046B")]
		[Address(RVA = "0x11E5118", Offset = "0x11E5118", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv27 = v22;\n\tv28 = 0x8907BC(v27, interpolator, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0016:\n\tv44 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv50 = System.Collections.Generic.List`1<T>::.ctor(v44);\n\tthis.data = v44;\n\tSystem.Object::.ctor(this);\n\tthis.interpolator = interpolator;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiPathDataChannel(ObiInterpolator<U> interpolator)
		{
			this.interpolator = interpolator;
		}

		[Token(Token = "0x600046E")]
		[Address(RVA = "0x11E5244", Offset = "0x11E5244", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.Collections.Generic.List`1<T>::RemoveAt(this.data, index);\n\tthis.dirty = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveAt(int index)
		{
			data.RemoveAt(index);
			dirty = true;
		}

		[Token(Token = "0x600046F")]
		[Address(RVA = "0x11E5288", Offset = "0x11E5288", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv36 = this.interpolator;\n\tv41 = *([v0 @ X1 (U)+18]);\n\tv48 = *([v41 @ X8_v1+C0]);\n\tv51 = *([v48 @ X8_v2+30]);\n\tv53 = *([v51 @ X20_v1+12E]) & 1;\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0028;\n\tv67 = 0x8907BC(v51, v0, v1, v2, v3, methodInfo, v62, v63, mu, v35, v31, v33, v27, v29, v64, v65);\nL_0028:\n\tv69 = *([v36 @ X19_v1 (Obi.ObiInterpolator`1<U>)]);\n\tv71 = *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]) == 0;\n\tif (v71) goto L_004A;\n\tv202 = *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+B0]) + 8;\nL_0034:\n\tv207 = *([v202 @ X11_v5-8]) == v51;\n\tif (v207) goto L_004D;\n\tv201 = v201 + 1;\n\tv212 = v201 < *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]);\n\tv103 = ~v212;\n\tv202 = v202 + 0x10;\n\tv79 = ~v103;\n\tif (v79) goto L_0034;\nL_004A:\n\tv219 = 0x8909C4(v36, v51, 0, v2, v3, methodInfo, v62, v63, mu, v35, v31, v33, v27, v29, v64, v65);\n\tgoto L_0050;\nL_004D:\n\tv214 = *([v202 @ X11_v5]) << 4;\n\tv215 = v69 + v214;\n\tv219 = v215 + 0x130;\nL_0050:\n\tv135 = *([v219 @ X0_v4]);\n\tv137 = *([v219 @ X0_v4+8]);\n\t*([v24 @ X29_v1+30]) = *([v24 @ X29_v1+30]);\n\t*([v24 @ X29_v1+20]) = *([v24 @ X29_v1+20]);\n\t*([v24 @ X29_v1+24]) = *([v24 @ X29_v1+24]);\n\t*([v24 @ X29_v1+10]) = *([v24 @ X29_v1+10]);\n\t*([v24 @ X29_v1+14]) = *([v24 @ X29_v1+14]);\n\t*([v24 @ X29_v1+28]) = *([v24 @ X29_v1+28]);\n\t*([v24 @ X29_v1+18]) = *([v24 @ X29_v1+18]);\n\t// 109 IndirectJump v135 @ X2_v2, v36 @ X19_v1 (Obi.ObiInterpolator`1<U>), v36 @ X19_v1 (Obi.ObiInterpolator`1<U>), v137 @ X1_v2, v135 @ X2_v2, v2 @ X3 (U), v3 @ X4 (U), methodInfo @ X5 (Il2CppMethodInfo), v62 @ X6, v63 @ X7, mu @ V0 (System.Single), v35 @ V1, v31 @ V2, v33 @ V3, v27 @ V4, v29 @ V5, v64 @ V6, v65 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public U Evaluate(U v0, U v1, U v2, U v3, float mu)
		{
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			//IL_0047: Expected O, but got I
			//IL_009c: Expected I, but got O
			//IL_01b7: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_0159: Expected I4, but got O
			//IL_0167: Expected O, but got I
			//IL_0176: Expected O, but got I
			//IL_0123: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			ObiInterpolator<U> obiInterpolator = interpolator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X1 (U)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v1+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v2+30]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X20_v1+12E]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			}
			IntPtr intPtr = (IntPtr)obiInterpolator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_013c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+B0]");
			object obj6 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)obj5)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_013c;
			}
			int num3 = obj6 << 4;
			object obj7 = (long)intPtr + (long)num3;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_019f;
			IL_019f:
			object obj9 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X0_v4+8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+24]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+14]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v135 @ X2_v2 (should have been resolved before IL gen)");
			return (U)null;
			IL_013c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_019f;
		}

		[Token(Token = "0x6000470")]
		[Address(RVA = "0x11E5398", Offset = "0x11E5398", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv36 = this.interpolator;\n\tv41 = *([v0 @ X1 (U)+18]);\n\tv48 = *([v41 @ X8_v1+C0]);\n\tv51 = *([v48 @ X8_v2+30]);\n\tv53 = *([v51 @ X20_v1+12E]) & 1;\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0028;\n\tv67 = 0x8907BC(v51, v0, v1, v2, v3, methodInfo, v62, v63, mu, v35, v31, v33, v27, v29, v64, v65);\nL_0028:\n\tv69 = *([v36 @ X19_v1 (Obi.ObiInterpolator`1<U>)]);\n\tv71 = *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]) == 0;\n\tif (v71) goto L_004A;\n\tv202 = *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+B0]) + 8;\nL_0034:\n\tv207 = *([v202 @ X11_v5-8]) == v51;\n\tif (v207) goto L_004D;\n\tv201 = v201 + 1;\n\tv212 = v201 < *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]);\n\tv103 = ~v212;\n\tv202 = v202 + 0x10;\n\tv79 = ~v103;\n\tif (v79) goto L_0034;\nL_004A:\n\tv220 = 0x8909C4(v36, v51, 1, v2, v3, methodInfo, v62, v63, mu, v35, v31, v33, v27, v29, v64, v65);\n\tgoto L_0051;\nL_004D:\n\tv214 = *([v202 @ X11_v5]) + 1;\n\tv215 = v214 << 4;\n\tv216 = v69 + v215;\n\tv220 = v216 + 0x130;\nL_0051:\n\tv137 = *([v220 @ X0_v4]);\n\tv135 = *([v220 @ X0_v4+8]);\n\t*([v24 @ X29_v1+30]) = *([v24 @ X29_v1+30]);\n\t*([v24 @ X29_v1+20]) = *([v24 @ X29_v1+20]);\n\t*([v24 @ X29_v1+24]) = *([v24 @ X29_v1+24]);\n\t*([v24 @ X29_v1+10]) = *([v24 @ X29_v1+10]);\n\t*([v24 @ X29_v1+14]) = *([v24 @ X29_v1+14]);\n\t*([v24 @ X29_v1+28]) = *([v24 @ X29_v1+28]);\n\t*([v24 @ X29_v1+18]) = *([v24 @ X29_v1+18]);\n\t// 110 IndirectJump v137 @ X2_v2, v36 @ X19_v1 (Obi.ObiInterpolator`1<U>), v36 @ X19_v1 (Obi.ObiInterpolator`1<U>), v135 @ X1_v2, v137 @ X2_v2, v2 @ X3 (U), v3 @ X4 (U), methodInfo @ X5 (Il2CppMethodInfo), v62 @ X6, v63 @ X7, mu @ V0 (System.Single), v35 @ V1, v31 @ V2, v33 @ V3, v27 @ V4, v29 @ V5, v64 @ V6, v65 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public U EvaluateFirstDerivative(U v0, U v1, U v2, U v3, float mu)
		{
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			//IL_0047: Expected O, but got I
			//IL_009c: Expected I, but got O
			//IL_01c6: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Expected O, but got Unknown
			//IL_0176: Expected O, but got I
			//IL_0185: Expected O, but got I
			//IL_0123: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			ObiInterpolator<U> obiInterpolator = interpolator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X1 (U)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v1+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v2+30]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X20_v1+12E]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			}
			IntPtr intPtr = (IntPtr)obiInterpolator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_013c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+B0]");
			object obj6 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)obj5)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_013c;
			}
			object obj7 = obj6 + 1;
			int num3 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr + (long)num3;
			object obj9 = (long)(IntPtr)obj8 + 304L;
			goto IL_01ae;
			IL_01ae:
			object obj10 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X0_v4+8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+24]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+14]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v137 @ X2_v2 (should have been resolved before IL gen)");
			return (U)null;
			IL_013c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01ae;
		}

		[Token(Token = "0x6000471")]
		[Address(RVA = "0x11E54AC", Offset = "0x11E54AC", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv36 = this.interpolator;\n\tv41 = *([v0 @ X1 (U)+18]);\n\tv48 = *([v41 @ X8_v1+C0]);\n\tv51 = *([v48 @ X8_v2+30]);\n\tv53 = *([v51 @ X20_v1+12E]) & 1;\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0028;\n\tv67 = 0x8907BC(v51, v0, v1, v2, v3, methodInfo, v62, v63, mu, v35, v31, v33, v27, v29, v64, v65);\nL_0028:\n\tv69 = *([v36 @ X19_v1 (Obi.ObiInterpolator`1<U>)]);\n\tv71 = *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]) == 0;\n\tif (v71) goto L_004A;\n\tv202 = *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+B0]) + 8;\nL_0034:\n\tv207 = *([v202 @ X11_v5-8]) == v51;\n\tif (v207) goto L_004D;\n\tv201 = v201 + 1;\n\tv212 = v201 < *([v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]);\n\tv103 = ~v212;\n\tv202 = v202 + 0x10;\n\tv79 = ~v103;\n\tif (v79) goto L_0034;\nL_004A:\n\tv220 = 0x8909C4(v36, v51, 2, v2, v3, methodInfo, v62, v63, mu, v35, v31, v33, v27, v29, v64, v65);\n\tgoto L_0051;\nL_004D:\n\tv214 = *([v202 @ X11_v5]) + 2;\n\tv215 = v214 << 4;\n\tv216 = v69 + v215;\n\tv220 = v216 + 0x130;\nL_0051:\n\tv137 = *([v220 @ X0_v4]);\n\tv135 = *([v220 @ X0_v4+8]);\n\t*([v24 @ X29_v1+30]) = *([v24 @ X29_v1+30]);\n\t*([v24 @ X29_v1+20]) = *([v24 @ X29_v1+20]);\n\t*([v24 @ X29_v1+24]) = *([v24 @ X29_v1+24]);\n\t*([v24 @ X29_v1+10]) = *([v24 @ X29_v1+10]);\n\t*([v24 @ X29_v1+14]) = *([v24 @ X29_v1+14]);\n\t*([v24 @ X29_v1+28]) = *([v24 @ X29_v1+28]);\n\t*([v24 @ X29_v1+18]) = *([v24 @ X29_v1+18]);\n\t// 110 IndirectJump v137 @ X2_v2, v36 @ X19_v1 (Obi.ObiInterpolator`1<U>), v36 @ X19_v1 (Obi.ObiInterpolator`1<U>), v135 @ X1_v2, v137 @ X2_v2, v2 @ X3 (U), v3 @ X4 (U), methodInfo @ X5 (Il2CppMethodInfo), v62 @ X6, v63 @ X7, mu @ V0 (System.Single), v35 @ V1, v31 @ V2, v33 @ V3, v27 @ V4, v29 @ V5, v64 @ V6, v65 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public U EvaluateSecondDerivative(U v0, U v1, U v2, U v3, float mu)
		{
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			//IL_0047: Expected O, but got I
			//IL_009c: Expected I, but got O
			//IL_01c6: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Expected O, but got Unknown
			//IL_0176: Expected O, but got I
			//IL_0185: Expected O, but got I
			//IL_0123: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			ObiInterpolator<U> obiInterpolator = interpolator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X1 (U)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X8_v1+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v2+30]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X20_v1+12E]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			}
			IntPtr intPtr = (IntPtr)obiInterpolator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_013c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+B0]");
			object obj6 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)obj5)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (Il2CppClass<Obi.ObiInterpolator`1<U>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_013c;
			}
			object obj7 = obj6 + 2;
			int num3 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr + (long)num3;
			object obj9 = (long)(IntPtr)obj8 + 304L;
			goto IL_01ae;
			IL_01ae:
			object obj10 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X0_v4+8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+24]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+14]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v137 @ X2_v2 (should have been resolved before IL gen)");
			return (U)null;
			IL_013c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01ae;
		}

		[Token(Token = "0x6000472")]
		[Address(RVA = "0x11E55C0", Offset = "0x11E55C0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Obi.ObiPathDataChannel`2<T, U>::get_Count(this);\n\tv41 = v17 < 2;\n\tif (v41) goto L_FFFFFFFF;\n\tv43 = ~closed;\n\treturnVal2 = v17 - v43;\n\tgoto L_0023;\nL_0023:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetSpanCount(bool closed)
		{
			int count = Count;
			if (count >= 2)
			{
				bool flag = !closed;
				return count - (flag ? 1 : 0);
			}
			return 0;
		}

		[Token(Token = "0x6000473")]
		[Address(RVA = "0x11E5614", Offset = "0x11E5614", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Obi.ObiPathDataChannel`2<T, U>::GetSpanCount(this, closed);\n\tv37 = v23 * mu;\n\tv38 = v23 - 1;\n\tv42 = mu - 1f;\n\tv43 = v42 < 0;\n\tv45 = mu ^ 1f;\n\tv46 = mu ^ v42;\n\tv47 = v45 & v46;\n\tv48 = v47 < 0;\n\tv49 = v43 == v48;\n\tv50 = ~v49;\n\tv51 = ~v50;\n\tif (v51) goto L_FFFFFFFF;\n\tgoto L_0027;\nL_0027:\n\tv57 = v37 - returnVal2;\n\t*([spanMu @ X2 (System.Single&)]) = v57;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int GetSpanControlPointAtMu(bool closed, float mu, out float spanMu)
		{
			//IL_0065: Expected O, but got F4
			//IL_0072: Expected O, but got F4
			//IL_00f4: Expected Ref, but got F4
			//IL_00ca: Expected I4, but got F4
			spanMu = default(float);
			int spanCount = GetSpanCount(closed);
			float num = (float)spanCount * mu;
			int num2 = spanCount - 1;
			float num3 = mu - 1f;
			bool flag = num3 < 0f;
			object obj = mu ^ 1f;
			object obj2 = mu ^ num3;
			int num4 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag2 = num4 < 0;
			int num5 = ((flag == flag2) ? num2 : ((int)num));
			float num6 = num - (float)num5;
			ref float reference = ref *(float*)num6;
			return num5;
		}
	}
}

using System;
using System.Collections.Specialized;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LipingShare.LCLib.Asn1Processor
{
	[Token(Token = "0x2000022")]
	internal class Oid
	{
		[Token(Token = "0x4000050")]
		private static StringDictionary oidDictionary = null;

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x15D0530", Offset = "0x15D0530", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB20B8]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, inOidStr, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029A16]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Oid>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, inOidStr, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = LipingShare.LCLib.Asn1Processor.Oid;\nL_0023:\n\tv56 = v54.oidDictionary == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_003E;\n\tv62 = new System.Collections.Specialized.StringDictionary();\n\tSystem.Collections.Specialized.StringDictionary::.ctor(v62);\n\tgoto L_0039;\n\tv101 = *([v86 @ X0_v13 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Oid>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0039;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v86, v64, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv105 = LipingShare.LCLib.Asn1Processor.Oid;\nL_0039:\n\tv70.oidDictionary = v62;\nL_003E:\n\tgoto L_0046;\n\tv76 = *([v65 @ X0_v4 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Oid>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_0046;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v65, v63, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv80 = LipingShare.LCLib.Asn1Processor.Oid;\nL_0046:\n\tv84 = v83.oidDictionary;\n\tv91 = *([v84 @ X0_v6 (System.Collections.Specialized.StringDictionary)]);\n\tv97 = *([v91 @ X8_v11 (Il2CppClass<System.Collections.Specialized.StringDictionary>)+180]);\n\tv98 = *([v91 @ X8_v11 (Il2CppClass<System.Collections.Specialized.StringDictionary>)+188]);\n\t// 83 IndirectJump v97 @ X3_v1, v84 @ X0_v6 (System.Collections.Specialized.StringDictionary), v84 @ X0_v6 (System.Collections.Specialized.StringDictionary), inOidStr @ X1 (System.String), v98 @ X2_v1, v97 @ X3_v1, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetOidName(string inOidStr)
		{
			//IL_0021: Expected I, but got O
			//IL_0031: Expected O, but got I
			//IL_0041: Expected O, but got I
			while (true)
			{
				if (oidDictionary == null)
				{
					StringDictionary stringDictionary = new StringDictionary();
					oidDictionary = stringDictionary;
				}
				StringDictionary stringDictionary2 = oidDictionary;
				IntPtr intPtr = (IntPtr)stringDictionary2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v11 (Il2CppClass<System.Collections.Specialized.StringDictionary>)+180]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v11 (Il2CppClass<System.Collections.Specialized.StringDictionary>)+188]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v97 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x15D1B64", Offset = "0x15D1B64", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA4E18]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, data, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A17]) = v41;\nL_0018:\n\tv45 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v45, data);\n\tv55 = System.IO.MemoryStream::set_Position(v45, 0);\n\tv61 = LipingShare.LCLib.Asn1Processor.Oid::Decode(this, v45);\n\tv67 = System.IO.Stream::Close(v45);\n\treturn v61;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string Decode(byte[] data)
		{
			//IL_0013: Expected I8, but got I4
			MemoryStream memoryStream = new MemoryStream(data);
			memoryStream.Position = 0L;
			string result = Decode(memoryStream);
			memoryStream.Close();
			return result;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x15D1C20", Offset = "0x15D1C20", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED7678]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, bt, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029A18]) = v42;\nL_0017:\n\tv45 = 0;\n\tv47 = v104 == 0;\n\tif (v47) goto L_0074;\n\tv52 = System.IO.Stream::ReadByte(v104);\n\tv55 = v52 & 0xFF;\n\tgoto L_0030;\n\tv62 = *([v56 @ X8_v18+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0030;\n\tv76 = v56;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v76, v51, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0030:\n\tv71 = v55 * 0xCCCCCCCD;\n\tv72 = v71 >> 0x25;\n\tv75 = System.Convert::ToString(v72);\n\tv80 = System.String::Concat(\"\", v75);\n\tv94 = v72 * 0x28;\n\tv95 = v55 - v94;\n\tv97 = System.Convert::ToString(v95);\n\tv127 = System.String::Concat(v80, \".\", v97);\nL_004B:\n\tv184 = System.IO.Stream::get_Position(v104);\n\tv187 = System.IO.Stream::get_Length(v104);\n\tv139 = v184 >= v187;\n\tif (v139) goto L_0072;\n\tv235 = LipingShare.LCLib.Asn1Processor.Oid::DecodeValue(v187, v104, &v45 @ stack_-38_v1 (System.UInt64));\n\tv243 = 0x13CC990(&v45 @ stack_-38_v1 (System.UInt64), 0, &v45 @ stack_-38_v1 (System.UInt64), v164, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv175 = System.String::Concat(v178, \".\", v243);\n\tgoto L_004B;\nL_0072:\n\treturn v178;\nL_0074:\n\tv61 = new System.NullReferenceException();\n\tgoto L_0081;\n\tgoto L_0081;\nL_0081:\n\tv91 = v104 != 1;\n\tif (v91) goto L_00B8;\n\tv99 = 0x6D2BC0(v61, v104, v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv130 = *([v99 @ X0_v9 (System.Exception)]);\n\tv133 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v130 @ X19_v4 (Il2CppClass<System.Exception>)]), v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv136 = v133 & 1;\n\tv112 = v136 == 0;\n\tif (v112) goto L_00AE;\n\tv189 = 0x6D2490(v133, *([v130 @ X19_v4 (Il2CppClass<System.Exception>)]), v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv238 = 0x846A20(v130, 0, v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv244 = *([v130 @ X19_v4 (Il2CppClass<System.Exception>)]);\n\t*([v244 @ X8_v8+180])(v247, v130, *([v244 @ X8_v8+188]), v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv254 = System.String::Concat(\"Failed to decode OID value: \", v247);\n\tv258 = new System.Exception();\n\tSystem.Exception::.ctor(v258, v254);\n\tthrow v258;\nL_00AE:\n\tv203 = 0x6D1E60(8, *([v130 @ X19_v4 (Il2CppClass<System.Exception>)]), v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v203 @ X0_v14]) = *([v99 @ X0_v9 (System.Exception)]);\n\tv104 = 0x1E8A000 + 0x870;\n\tv240 = 0x6D2A00(v203, v104, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv110 = 0x6D2490(v240, v104, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00B8:\n\tv120 = 0x6D2380(v113, v104, v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal1 = 0x846AA4(v120, v104, v190, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual string Decode(Stream bt)
		{
			//IL_0269: Expected I8, but got I4
			//IL_0037: Expected I4, but got I8
			//IL_015f: Expected I, but got O
			//IL_00b5: Expected O, but got I4
			//IL_0217: Expected O, but got I4
			//IL_02a0: Expected O, but got I8
			//IL_0235: Expected I, but got O
			//IL_01bb: Expected O, but got I
			//IL_0105: Expected O, but got I4
			ulong v = 0uL;
			Stream stream = default(Stream);
			if (stream != null)
			{
				int num = stream.ReadByte();
				int num2 = num & 0xFF;
				int num3 = (int)(num2 * 3435973837L);
				int num4 = num3 >> 37;
				string text = Convert.ToString(num4);
				string text2 = "" + text;
				int num5 = num4 * 40;
				int num6 = num2 - num5;
				string text3 = Convert.ToString(num6);
				string text4 = text2 + "." + text3;
				object obj = 0;
				string text5 = text4;
				string text7 = default(string);
				while (true)
				{
					long position = stream.Position;
					Oid oid = (Oid)stream.Length;
					if (position >= (long)oid)
					{
						break;
					}
					int num7 = oid.DecodeValue(stream, ref v);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13CC990 (inside System.UInt32::TryParse +0x8D0)");
					string text6 = text5 + "." + text7;
					obj = 0;
					text5 = text6;
				}
				return text5;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag = (IntPtr)stream != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Exception ex3 = default(Exception);
				IntPtr intPtr = (IntPtr)ex3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj2 = default(object);
				IntPtr intPtr2;
				if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
					object obj3 = (long)intPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v244 @ X8_v8+180] (should have been resolved before IL gen)");
					string text8 = default(string);
					string message = "Failed to decode OID value: " + text8;
					Exception ex4 = new Exception(message);
					intPtr2 = (IntPtr)0;
					throw ex4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj4 = ex3;
				stream = (Stream)(32022528 + 2160);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				intPtr2 = (IntPtr)null;
				NullReferenceException ex5 = default(NullReferenceException);
				ex2 = ex5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x15D0528", Offset = "0x15D0528", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Oid()
		{
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x15D1E70", Offset = "0x15D1E70", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([v @ X2 (System.UInt64&)]) = 0;\nL_0011:\n\tv43 = System.IO.Stream::ReadByte(bt);\n\tv52 = v43 & 0x7F;\n\tv44 = v44 + 1;\n\tv53 = *([v @ X2 (System.UInt64&)]) & 0x1FFFFFFFFFFFFFF;\n\tv54 = v53 << 7;\n\tv55 = v52 & 0x7F;\n\tv37 = v55 | v54;\n\t*([v @ X2 (System.UInt64&)]) = v37;\n\tv56 = v43 & 0x80;\n\tv57 = v56 == 0;\n\tv48 = ~v57;\n\tif (v48) goto L_0011;\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe int DecodeValue(Stream bt, ref ulong v)
		{
			//IL_0069: Expected I4, but got I8
			ref ulong reference = ref *(ulong*)null;
			int num = 0;
			int num2 = default(int);
			num = num2;
			int num3;
			do
			{
				num3 = bt.ReadByte();
				int num4 = num3 & 0x7F;
				num++;
				int num5 = (int)(v & 0x1FFFFFFFFFFFFFFL);
				int num6 = num5 << 7;
				int num7 = num4 & 0x7F;
				int num8 = num7 | num6;
				reference = ref *(ulong*)num8;
			}
			while ((num3 & 0x80) != 0);
			return num;
		}
	}
}

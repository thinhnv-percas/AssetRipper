using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LipingShare.LCLib.Asn1Processor
{
	[Token(Token = "0x2000023")]
	internal class RelativeOid : Oid
	{
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x15D0620", Offset = "0x15D0620", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F014C8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A1A]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tSystem.Object::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RelativeOid()
		{
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x15D1F2C", Offset = "0x15D1F2C", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE9520]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, bt, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2029A1B]) = v42;\nL_0017:\n\tv45 = 0;\n\tv47 = v165 == 0;\n\tif (v47) goto L_006A;\n\tv52 = System.IO.Stream::get_Position(v165);\n\tv58 = System.IO.Stream::get_Length(v165);\n\tv68 = v52 >= v58;\n\tif (v68) goto L_0068;\nL_0036:\n\tv138 = LipingShare.LCLib.Asn1Processor.Oid::DecodeValue(v132, v165, &v45 @ stack_-38_v1 (System.UInt64));\n\tv181 = v129 & 1;\n\tv106 = v181 == 0;\n\tif (v106) goto L_0041;\n\tv199 = 0x13CC990(&v45 @ stack_-38_v1 (System.UInt64), 0, &v45 @ stack_-38_v1 (System.UInt64), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_0041:\n\tv202 = 0x13CC990(&v45 @ stack_-38_v1 (System.UInt64), 0, &v45 @ stack_-38_v1 (System.UInt64), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv214 = System.String::Concat(v135, \".\", v202);\nL_004C:\n\tv223 = System.IO.Stream::get_Position(v165);\n\tv104 = System.IO.Stream::get_Length(v165);\n\tv80 = v223 < v104;\n\tif (v80) goto L_0036;\nL_0068:\n\treturn v109;\nL_006A:\n\tv70 = new System.NullReferenceException();\n\tgoto L_0078;\n\tgoto L_0078;\n\tgoto L_0078;\nL_0078:\n\tv145 = v165 != 1;\n\tif (v145) goto L_00AF;\n\tv183 = 0x6D2BC0(v70, v165, v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv205 = *([v183 @ X0_v9 (System.Exception)]);\n\tv208 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v205 @ X19_v4 (Il2CppClass<System.Exception>)]), v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv215 = v208 & 1;\n\tv191 = v215 == 0;\n\tif (v191) goto L_00A5;\n\tv228 = 0x6D2490(v208, *([v205 @ X19_v4 (Il2CppClass<System.Exception>)]), v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv245 = 0x846A20(v205, 0, v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv248 = *([v205 @ X19_v4 (Il2CppClass<System.Exception>)]);\n\t*([v248 @ X8_v8+180])(v251, v205, *([v248 @ X8_v8+188]), v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv258 = System.String::Concat(\"Failed to decode OID value: \", v251);\n\tv261 = new System.Exception();\n\tSystem.Exception::.ctor(v261, v258);\n\tthrow v261;\nL_00A5:\n\tv242 = 0x6D1E60(8, *([v205 @ X19_v4 (Il2CppClass<System.Exception>)]), v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v242 @ X0_v14]) = *([v183 @ X0_v9 (System.Exception)]);\n\tv165 = 0x1E8A000 + 0x870;\n\tv247 = 0x6D2A00(v242, v165, 0, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv190 = 0x6D2490(v247, v165, 0, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AF:\n\tv196 = 0x6D2380(v173, v165, v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = 0x846AA4(v196, v165, v229, v75, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal2;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string Decode(Stream bt)
		{
			//IL_0206: Expected I8, but got I4
			//IL_00fc: Expected I, but got O
			//IL_0058: Expected O, but got I8
			//IL_01b4: Expected O, but got I4
			//IL_01d2: Expected I, but got O
			//IL_0158: Expected O, but got I
			//IL_025c: Expected O, but got I8
			ulong v = 0uL;
			Stream stream = default(Stream);
			if (stream != null)
			{
				long position = stream.Position;
				long length = stream.Length;
				bool flag = position >= length;
				string text = "";
				if (!flag)
				{
					int num = 1;
					Oid oid = (Oid)length;
					string text2 = "";
					string text3 = default(string);
					string text5 = default(string);
					bool flag2;
					do
					{
						int num2 = oid.DecodeValue(stream, ref v);
						if ((num & 1) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13CC990 (inside System.UInt32::TryParse +0x8D0)");
							text = text3;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13CC990 (inside System.UInt32::TryParse +0x8D0)");
							string text4 = text2 + "." + text5;
							text = text4;
						}
						long position2 = stream.Position;
						long length2 = stream.Length;
						flag2 = position2 < length2;
						num = 0;
						oid = (Oid)length2;
						text2 = text;
					}
					while (flag2);
				}
				return text;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag3 = (IntPtr)stream != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Exception ex3 = default(Exception);
				IntPtr intPtr = (IntPtr)ex3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj = default(object);
				IntPtr intPtr2;
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
					object obj2 = (long)intPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v248 @ X8_v8+180] (should have been resolved before IL gen)");
					string text6 = default(string);
					string message = "Failed to decode OID value: " + text6;
					Exception ex4 = new Exception(message);
					intPtr2 = (IntPtr)0;
					throw ex4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj3 = ex3;
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
	}
}

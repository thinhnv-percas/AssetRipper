using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace YMMJSONUtils
{
	[Token(Token = "0x200001E")]
	public class JSONEncoder
	{
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x10")]
		private readonly StringBuilder _buffer;

		[Token(Token = "0x4000064")]
		internal static readonly Dictionary<char, string> EscapeChars = new Dictionary<char, string>
		{
			{ '"', "\\\"" },
			{ '\\', "\\\\" },
			{ '\b', "\\b" },
			{ '\f', "\\f" },
			{ '\n', "\\n" },
			{ '\r', "\\r" },
			{ '\t', "\\t" },
			{ '\u2028', "\\u2028" },
			{ '\u2029', "\\u2029" }
		};

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x15BCAEC", Offset = "0x15BCAEC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F013F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029931]) = v38;\nL_0016:\n\tv42 = new YMMJSONUtils.JSONEncoder();\n\tYMMJSONUtils.JSONEncoder::.ctor(v42);\n\tYMMJSONUtils.JSONEncoder::EncodeObject(v42, obj);\n\tv48 = v42._buffer;\n\tv54 = *([v48 @ X0_v8 (System.Text.StringBuilder)]);\n\tv57 = *([v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv58 = *([v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 41 IndirectJump v57 @ X2_v1, v48 @ X0_v8 (System.Text.StringBuilder), v48 @ X0_v8 (System.Text.StringBuilder), v58 @ X1_v3, v57 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string Encode(object obj)
		{
			//IL_002c: Expected I, but got O
			//IL_003c: Expected O, but got I
			//IL_004c: Expected O, but got I
			while (true)
			{
				JSONEncoder jSONEncoder = new JSONEncoder();
				jSONEncoder.EncodeObject(obj);
				StringBuilder buffer = jSONEncoder._buffer;
				IntPtr intPtr = (IntPtr)buffer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+160]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+168]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x15BCB6C", Offset = "0x15BCB6C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFE068]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029932]) = v38;\nL_0016:\n\tv42 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v42);\n\tthis._buffer = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private JSONEncoder()
		{
			StringBuilder buffer = new StringBuilder();
			_buffer = buffer;
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x15BCBD4", Offset = "0x15BCBD4", Length = "0x5A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_010A;\nL_0022:\n\t;\n\tv157 = *([v100 @ X20_v2 (System.Object)]) == System.String;\n\tif (v157) goto L_0164;\n\tv167 = *([v100 @ X20_v2 (System.Object)]) == *([v110 @ X25_v3 (Il2CppClass<System.Single>)]);\n\tif (v167) goto L_0167;\n\tv267 = *([v100 @ X20_v2 (System.Object)]) == *([v108 @ X26_v3 (Il2CppClass<System.Double>)]);\n\tif (v267) goto L_017A;\n\tv406 = *([v100 @ X20_v2 (System.Object)]) == *([v106 @ X27_v3 (Il2CppClass<System.Int32>)]);\n\tif (v406) goto L_018D;\n\tv418 = *([v100 @ X20_v2 (System.Object)]) == *([v104 @ X28_v3 (Il2CppClass<System.UInt32>)]);\n\tif (v418) goto L_0191;\n\tv430 = *([v100 @ X20_v2 (System.Object)]) == *([v102 @ X22_v3 (Il2CppClass<System.Int64>)]);\n\tif (v430) goto L_0195;\n\tv445 = *([v100 @ X20_v2 (System.Object)]) == System.UInt64;\n\tif (v445) goto L_0199;\n\tv461 = *([v100 @ X20_v2 (System.Object)]) == System.Int16;\n\tif (v461) goto L_019D;\n\tv486 = *([v100 @ X20_v2 (System.Object)]) == System.UInt16;\n\tif (v486) goto L_01B0;\n\tv485 = *([v100 @ X20_v2 (System.Object)]) == System.Byte;\n\tif (v485) goto L_01B4;\n\tv270 = *([v100 @ X20_v2 (System.Object)]) == System.Boolean;\n\tif (v270) goto L_01C7;\n\t// 169 IsInst v511 @ X0_v33, typeof(System.Collections.IDictionary), v100 @ X20_v2 (System.Object)\n\tv514 = v511 == 0;\n\tv515 = ~v514;\n\tif (v515) goto L_01CF;\n\t// 177 IsInst v228 @ X0_v41, typeof(System.Collections.IEnumerable), v100 @ X20_v2 (System.Object)\n\tv525 = v228 == 0;\n\tv215 = ~v525;\n\tif (v215) goto L_01E9;\n\tgoto L_FFFFFFFF;\n\tv58 = v58_asT == 0;\n\tif (v58) goto L_0130;\n\tv599 = System.Object::GetType(v100);\n\tgoto L_00ED;\n\tv630 = *([v621 @ X8_v39+E0]);\n\tv631 = v630 == 0;\n\tv632 = ~v631;\n\tif (v632) goto L_00ED;\n\tv645 = v621;\n\tv635 = \"il2cpp_codegen_runtime_class_init\"(v645, v594, v46, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\nL_00ED:\n\tv639 = System.Enum::GetUnderlyingType(v599);\n\tgoto L_00FF;\n\tv663 = *([v113 @ X8_v42+E0]);\n\tv664 = v663 == 0;\n\tv665 = ~v664;\n\tif (v665) goto L_00FF;\n\tv674 = v113;\n\tv667 = \"il2cpp_codegen_runtime_class_init\"(v674, v638, v46, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\nL_00FF:\n\tv72 = System.Convert::ChangeType(v100, v639);\nL_010A:\n\tgoto L_010F;\n\tv118 = v42;\n\tv119 = \"il2cpp_codegen_initialize_method\"(v118, v69, v46, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv135 = 0 | 1;\n\t*([2029933]) = v135;\nL_010F:\n\tv136 = v100 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0022;\n\tYMMJSONUtils.JSONEncoder::EncodeNull(this);\n\treturn;\nL_0130:\n\tgoto L_FFFFFFFF;\n\tv612 = v612_asT == 0;\n\tif (v612) goto L_0223;\n\tv614 = *([v100 @ X20_v2 (System.Object)+10]);\n\tv625 = *([v100 @ X20_v2 (System.Object)+10]) < 5;\n\tv287 = ~v625;\n\tv280 = *([v100 @ X20_v2 (System.Object)+10]) - 5;\n\tv266 = v280 == 0;\n\tv626 = ~v266;\n\tv206 = v287 & v626;\n\tif (v206) goto L_0223;\n\tv294 = 0x183B000 + 0xD28;\n\tv385 = *([v294 @ X9_v31 (System.Int32)+v614 @ X8_v34*4]) + v294;\n\t// 337 IndirectJump v385 @ X8_v36, v228 @ X0_v41, v228 @ X0_v41, typeof(System.Collections.IEnumerable), 0, v120 @ X3, v121 @ X4, v122 @ X5, v123 @ X6, v124 @ X7, v125 @ V0, v126 @ V1, v127 @ V2, v128 @ V3, v129 @ V4, v130 @ V5, v131 @ V6, v132 @ V7\n\tX1 = *([X20+18]);\n\tX0 = stack[8];\n\tgoto L_01E2;\nL_0164:\n\tYMMJSONUtils.JSONEncoder::EncodeString(this, v100);\n\treturn;\nL_0167:\n\tv400 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tYMMJSONUtils.JSONEncoder::EncodeFloat(this, *([v400 @ X0_v6]));\n\treturn;\nL_017A:\n\tv412 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\nL_018A:\n\tYMMJSONUtils.JSONEncoder::EncodeDouble(this, *([v412 @ X0_v9]));\n\treturn;\nL_018D:\n\tv424 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv221 = *([v424 @ X0_v14]);\n\tgoto L_01AD;\nL_0191:\n\tv436 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv222 = *([v436 @ X0_v18]);\n\tgoto L_01C4;\nL_0195:\n\tv451 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv221 = *([v451 @ X0_v20]);\n\tgoto L_01AD;\nL_0199:\n\tv470 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv222 = *([v470 @ X0_v22]);\n\tgoto L_01C4;\nL_019D:\n\tv456 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv221 = *([v456 @ X0_v24]);\nL_01AD:\n\tYMMJSONUtils.JSONEncoder::EncodeLong(this, v221);\n\treturn;\nL_01B0:\n\tv476 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv222 = *([v476 @ X0_v26]);\n\tgoto L_01C4;\nL_01B4:\n\tv475 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv222 = *([v475 @ X0_v28]);\nL_01C4:\n\tYMMJSONUtils.JSONEncoder::EncodeULong(this, v222);\n\treturn;\nL_01C7:\n\tv513 = \"il2cpp_vm_object_unbox\"(v100, v639, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tgoto L_0218;\nL_01CF:\n\t// 463 IsInst v524 @ X0_v38 (System.Collections.IDictionary), typeof(System.Collections.IDictionary), v100 @ X20_v2 (System.Object)\n\tv216 = v524 == 0;\n\tif (v216) goto L_024B;\nL_01E2:\n\tYMMJSONUtils.JSONEncoder::EncodeDictionary(this, v524);\n\treturn;\nL_01E9:\n\t// 489 IsInst v546 @ X0_v43 (System.Collections.IEnumerable), typeof(System.Collections.IEnumerable), v100 @ X20_v2 (System.Object)\n\tv217 = v546 == 0;\n\tif (v217) goto L_024B;\n\tgoto L_01FF;\n\tX1 = *([X20+20]);\n\tX0 = stack[8];\nL_01FF:\n\tYMMJSONUtils.JSONEncoder::EncodeEnumerable(this, v546);\n\treturn;\n\tX1 = *([X20+28]);\n\tX0 = stack[8];\n\tgoto L_0164;\n\tX8 = *([X20+67]);\n\tif (TEMP) goto L_021A;\n\tV0 = *([X20+38]);\n\tgoto L_018A;\n\tX1 = *([X20+30]);\nL_0218:\n\tYMMJSONUtils.JSONEncoder::EncodeBool(this, *([v513 @ X0_v30]));\n\treturn;\nL_021A:\n\tX8 = *([X20+66]);\n\tif (TEMP) goto L_021F;\n\tX1 = *([X20+50]);\n\tgoto L_01AD;\nL_021F:\n\tX1 = *([X20+48]);\n\tgoto L_01C4;\nL_0223:\n\tv617 = 0x846A20(v100, 0, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv629 = System.Object::GetType(v100);\n\tv644 = 0x846A20(v629, 0, 0, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132);\n\tv655 = System.Reflection.MemberInfo::get_Name(v629);\n\tv662 = System.String::Concat(\"Can't serialize object of type \", v655);\n\tv673 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v673, v662, \"obj\");\n\tthrow v673;\nL_024B:\n\tthrow System.InvalidCastException;\n// 439 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeObject(object obj)
		{
			//IL_0016: Expected I, but got O
			//IL_0024: Expected I, but got O
			//IL_0032: Expected I, but got O
			//IL_0040: Expected I, but got O
			//IL_004e: Expected I, but got O
			//IL_039f: Expected F4, but got O
			//IL_057b: Expected F8, but got O
			//IL_03c6: Expected I8, but got O
			//IL_03dd: Expected I8, but got O
			//IL_03f4: Expected I8, but got O
			//IL_040b: Expected I8, but got O
			//IL_0422: Expected I8, but got O
			//IL_0439: Expected I8, but got O
			//IL_0450: Expected I8, but got O
			//IL_055a: Expected I4, but got O
			//IL_02f0: Expected O, but got I
			//IL_0328: Expected O, but got I
			//IL_0381: Expected O, but got I
			object obj2 = obj;
			IntPtr intPtr = (IntPtr)typeof(long);
			IntPtr intPtr2 = (IntPtr)typeof(uint);
			IntPtr intPtr3 = (IntPtr)typeof(int);
			IntPtr intPtr4 = (IntPtr)typeof(double);
			IntPtr intPtr5 = (IntPtr)typeof(float);
			object obj3 = default(object);
			object obj4 = default(object);
			object obj12 = default(object);
			object obj13 = default(object);
			object obj14 = default(object);
			object obj15 = default(object);
			object obj16 = default(object);
			object obj17 = default(object);
			object obj18 = default(object);
			object obj19 = default(object);
			while (true)
			{
				long l;
				if (obj2 != null)
				{
					if ((object)obj2.GetType() == typeof(string))
					{
						break;
					}
					if ((IntPtr)obj2 == intPtr5)
					{
						goto IL_038b;
					}
					if ((IntPtr)obj2 != intPtr4)
					{
						if ((IntPtr)obj2 != intPtr3)
						{
							ulong l2;
							if ((IntPtr)obj2 != intPtr2)
							{
								if ((IntPtr)obj2 == intPtr)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									l = (long)obj3;
									goto IL_053a;
								}
								if ((object)obj2.GetType() != typeof(ulong))
								{
									if ((object)obj2.GetType() == typeof(short))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
										l = (long)obj4;
										goto IL_053a;
									}
									if ((object)obj2.GetType() != typeof(ushort))
									{
										if ((object)obj2.GetType() != typeof(byte))
										{
											if ((object)obj2.GetType() != typeof(bool))
											{
												object obj5 = obj2 as IDictionary;
												if (obj5 == null)
												{
													object obj6 = obj2 as IEnumerable;
													if (obj6 == null)
													{
														Enum obj7 = obj2 as Enum;
														if (obj7 != null)
														{
															Type type = obj2.GetType();
															Type underlyingType = Enum.GetUnderlyingType(type);
															object obj8 = Convert.ChangeType(obj2, underlyingType);
															obj2 = obj8;
															continue;
														}
														JObject jObject = obj2 as JObject;
														if (jObject != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X20_v2 (System.Object)+10]");
															object obj9 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X20_v2 (System.Object)+10]");
															bool flag = 0L < 5L;
															bool flag2 = !flag;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X20_v2 (System.Object)+10]");
															object obj10 = -5;
															bool flag3 = obj10 == null;
															bool flag4 = !flag3;
															if (!(flag2 && flag4))
															{
																int num = 25407488 + 3368;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X9_v31 (System.Int32)+v614 @ X8_v34*4]");
																object obj11 = 0L + (long)num;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v385 @ X8_v36 (should have been resolved before IL gen)");
																goto IL_038b;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
														Type type2 = obj2.GetType();
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
														string name = type2.Name;
														string message = "Can't serialize object of type " + name;
														ArgumentException ex = new ArgumentException(message, "obj");
														throw ex;
													}
													IEnumerable enumerable = obj2 as IEnumerable;
													if (enumerable != null)
													{
														EncodeEnumerable(enumerable);
														return;
													}
												}
												else
												{
													IDictionary dictionary = obj2 as IDictionary;
													if (dictionary != null)
													{
														EncodeDictionary(dictionary);
														return;
													}
												}
												throw new InvalidCastException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
											EncodeBool((byte)(int)obj12 != 0);
											return;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
										l2 = (ulong)(long)obj13;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
										l2 = (ulong)(long)obj14;
									}
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									l2 = (ulong)(long)obj15;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								l2 = (ulong)(long)obj16;
							}
							EncodeULong(l2);
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						l = (long)obj17;
						goto IL_053a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					EncodeDouble((double)obj18);
					return;
				}
				EncodeNull();
				return;
				IL_038b:
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				EncodeFloat((float)obj19);
				return;
				IL_053a:
				EncodeLong(l);
				return;
			}
			EncodeString((string)obj2);
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x15BD178", Offset = "0x15BD178", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1EAE4A0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029934]) = v38;\nL_001F:\n\tv49 = System.Text.StringBuilder::Append(this._buffer, \"null\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeNull()
		{
			StringBuilder stringBuilder = _buffer.Append("null");
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x15BD1D4", Offset = "0x15BD1D4", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EF27B0]);\n\tv37 = *([v36 @ X8_v30]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, str, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029935]) = v55;\nL_0021:\n\tv60 = System.Text.StringBuilder::Append(this._buffer, 0x22);\n\tv227 = str.m_stringLength < 1;\n\tif (v227) goto L_00D5;\nL_003F:\n\tv306 = System.String::get_Chars(str, v163);\n\tgoto L_0053;\n\tv311 = *([v307 @ X8_v8 (Il2CppClass<YMMJSONUtils.JSONEncoder>)+E0]);\n\tv312 = v311 == 0;\n\tv313 = ~v312;\n\t// 73 Jump @b48\n\tv319 = v307;\n\tv315 = \"il2cpp_codegen_runtime_class_init\"(v319, v145, v140, v62, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv318 = YMMJSONUtils.JSONEncoder;\nL_0053:\n\tv203 = System.Collections.Generic.Dictionary`2<System.Char, System.String>::ContainsKey(v160.EscapeChars, v306);\n\tv321 = v203 == 0;\n\tif (v321) goto L_006B;\n\tv170 = this._buffer;\n\tgoto L_0069;\n\tv328 = *([v322 @ X0_v39 (Il2CppClass<YMMJSONUtils.JSONEncoder>)+E0]);\n\tv329 = v328 == 0;\n\tv330 = ~v329;\n\t// 96 ConditionalJump @b49, v330 @ TEMP_v38\n\tv342 = \"il2cpp_codegen_runtime_class_init\"(v322, v146, v141, v62, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv332 = YMMJSONUtils.JSONEncoder;\nL_0069:\n\tv205 = System.Collections.Generic.Dictionary`2<System.Char, System.String>::get_Item(v161.EscapeChars, v306);\n\tgoto L_00B4;\nL_006B:\n\tv170 = this._buffer;\n\tv326 = v306 - 0x20;\n\tv211 = v326 & 0xFFFF;\n\tv327 = v211 < 0x61;\n\tv133 = ~v327;\n\tif (v133) goto L_0081;\n\tv349 = System.Text.StringBuilder::Append(this._buffer, v306);\n\tgoto L_00B6;\nL_0081:\n\tv337 = v306 & 0xFFFF;\n\tgoto L_008F;\n\tv350 = *([v338 @ X0_v22+E0]);\n\tv351 = v350 == 0;\n\tv352 = ~v351;\n\tif (v352) goto L_008F;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v338, v146, v141, v62, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_008F:\n\tv359 = System.Convert::ToString(v337, 0x10);\n\tgoto L_009D;\n\tv383 = *([v158 @ X8_v20+E0]);\n\tv384 = v383 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_009D;\n\tv391 = v158;\n\tv387 = \"il2cpp_codegen_runtime_class_init\"(v391, v357, v198, v62, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_009D:\n\tv204 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv148 = System.String::ToUpper(v359, v204);\n\tv395 = System.String::PadLeft(v148, 4, 0x30);\n\tv205 = System.String::Concat(\"\\\\u\", v395);\nL_00B4:\n\tv379 = System.Text.StringBuilder::Append(v170, v205);\nL_00B6:\n\tv163 = v163 + 1;\n\tv238 = v163 < str.m_stringLength;\n\tif (v238) goto L_003F;\nL_00D5:\n\tv287 = System.Text.StringBuilder::Append(this._buffer, 0x22);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeString(string str)
		{
			StringBuilder stringBuilder = _buffer.Append('"');
			if (str.Length >= 1)
			{
				int num = 0;
				do
				{
					char c = str.get_Chars(num);
					StringBuilder buffer;
					string value;
					if (EscapeChars.ContainsKey(c))
					{
						buffer = _buffer;
						value = EscapeChars.get_Item(c);
					}
					else
					{
						buffer = _buffer;
						int num2 = c - 32;
						int num3 = num2 & 0xFFFF;
						if (num3 < 97)
						{
							StringBuilder stringBuilder2 = _buffer.Append(c);
							goto IL_019b;
						}
						int num4 = c & 0xFFFF;
						string text = Convert.ToString(num4, 16);
						CultureInfo invariantCulture = CultureInfo.InvariantCulture;
						string text2 = text.ToUpper(invariantCulture);
						string text3 = text2.PadLeft(4, '0');
						value = "\\u" + text3;
					}
					StringBuilder stringBuilder3 = buffer.Append(value);
					goto IL_019b;
					IL_019b:
					num++;
				}
				while (num < str.Length);
			}
			StringBuilder stringBuilder4 = _buffer.Append('"');
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x15BD418", Offset = "0x15BD418", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ECE748]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, f, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([2029936]) = v39;\nL_001B:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, f, v30, v31, v32, v33, v34, v35, v36);\nL_0022:\n\tv55 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv59 = 0xBCCEFC(&f @ V0 (System.Single), v55, 0, v25, v26, v27, v28, v29, f, v30, v31, v32, v33, v34, v35, v36);\n\tv64 = System.Text.StringBuilder::Append(this._buffer, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeFloat(float f)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEFC (inside System.Single::IsNaN +0x2E4)");
			string value = default(string);
			StringBuilder stringBuilder = _buffer.Append(value);
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x15BD4BC", Offset = "0x15BD4BC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1F00E58]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, d, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([2029937]) = v39;\nL_001B:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, d, v30, v31, v32, v33, v34, v35, v36);\nL_0022:\n\tv55 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv59 = 0xA6636C(&d @ V0 (System.Double), v55, 0, v25, v26, v27, v28, v29, d, v30, v31, v32, v33, v34, v35, v36);\n\tv64 = System.Text.StringBuilder::Append(this._buffer, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeDouble(double d)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @A6636C (inside System.Double::IsNaN +0x488)");
			string value = default(string);
			StringBuilder stringBuilder = _buffer.Append(value);
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x15BD560", Offset = "0x15BD560", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE6FD8]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, l, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([2029938]) = v39;\nL_001B:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, l, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0022:\n\tv55 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv59 = 0xDC40D4(&l @ X1 (System.Int64), v55, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv64 = System.Text.StringBuilder::Append(this._buffer, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeLong(long l)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC40D4 (inside System.Number::FormatInt64 +0x80)");
			string value = default(string);
			StringBuilder stringBuilder = _buffer.Append(value);
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x15BD604", Offset = "0x15BD604", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EDBDC0]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, l, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([2029939]) = v39;\nL_001B:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, l, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0022:\n\tv55 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv59 = 0x13CC9C4(&l @ X1 (System.UInt64), v55, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv64 = System.Text.StringBuilder::Append(this._buffer, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeULong(ulong l)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13CC9C4 (inside System.UInt32::TryParse +0x904)");
			string value = default(string);
			StringBuilder stringBuilder = _buffer.Append(value);
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x15BD6A8", Offset = "0x15BD6A8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EF65D0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, b, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202993A]) = v41;\nL_001E:\n\tv50 = b == 0;\n\tv57 = ~v50;\n\tv58 = ~v57;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\tv66 = System.Text.StringBuilder::Append(this._buffer, *([v62 @ X8_v5 (System.String)]));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeBool(bool b)
		{
			string value = ((!b) ? "false" : "true");
			StringBuilder stringBuilder = _buffer.Append(value);
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x15BD720", Offset = "0x15BD720", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EA78F8]);\n\tv33 = *([v32 @ X8_v46]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, d, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202993B]) = v51;\nL_001F:\n\tv56 = System.Text.StringBuilder::Append(this._buffer, 0x7B);\n\tv161 = d->klass;\n\tv165 = *([v161 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]) == 0;\n\tif (v165) goto L_0046;\n\tv346 = *([v161 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+B0]) + 8;\nL_0031:\n\tv352 = *([v346 @ X11_v31-8]) == System.Collections.IDictionary;\n\tif (v352) goto L_0049;\n\tv347 = v347 + 1;\n\tv400 = v347 < *([v161 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]);\n\tv299 = ~v400;\n\tv346 = v346 + 0x10;\n\tv283 = ~v299;\n\tif (v283) goto L_0031;\nL_0046:\n\tv406 = 0x8909C4(d, System.Collections.IDictionary, 3, v224, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_004E;\nL_0049:\n\tv402 = *([v346 @ X11_v31]) + 3;\n\tv403 = v402 << 4;\n\tv404 = v161 + v403;\n\tv406 = v404 + 0x130;\nL_004E:\n\tv264 = *([v406 @ X0_v30+8]);\n\t*([v406 @ X0_v30])(v333, d, *([v406 @ X0_v30+8]), v262, v224, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv334 = v333 == 0;\n\tif (v334) goto L_011E;\nL_005F:\n\tgoto L_0086;\n\tv460 = *([v454 @ X8_v18+B0]);\n\tv461 = 0;\n\tv462 = v460 + 8;\n\tv464 = *([v501 @ X11_v26-8]);\n\tv507 = v464 == v455;\n\tif (v507) goto L_007F;\n\tv486 = v502 + 1;\n\tv558 = v486 < v456;\n\tv482 = ~v558;\n\tv484 = v501 + 0x10;\n\tv466 = ~v482;\n\tif (v466) goto L_FFFFFFFF;\n\tv487 = v215;\n\tv488 = 0;\n\tv489 = 0x8909C4(v487, v455, v488, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0086;\nL_007F:\n\tv559 = *([v501 @ X11_v26]);\n\tv560 = v559 << 4;\n\tv561 = v454 + v560;\n\tv562 = v561 + 0x130;\nL_0086:\n\tv547 = System.Collections.IEnumerator::MoveNext(v333);\n\tv549 = v547 == 0;\n\tif (v549) goto L_FFFFFFFF;\n\tv568 = *([v333 @ X0_v32 (System.Collections.IEnumerator)]);\n\tv571 = *([v568 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v571) goto L_00AC;\n\tv673 = *([v568 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0097:\n\tv679 = *([v673 @ X11_v21-8]) == System.Collections.IEnumerator;\n\tif (v679) goto L_00AF;\n\tv674 = v674 + 1;\n\tv705 = v674 < *([v568 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv623 = ~v705;\n\tv673 = v673 + 0x10;\n\tv607 = ~v623;\n\tif (v607) goto L_0097;\nL_00AC:\n\tv722 = 0x8909C4(v333, System.Collections.IEnumerator, 1, v224, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00B6;\nL_00AF:\n\tv707 = *([v673 @ X11_v21]) + 1;\n\tv708 = v707 << 4;\n\tv709 = v568 + v708;\n\tv722 = v709 + 0x130;\nL_00B6:\n\t*([v722 @ X0_v37])(v727, v333, *([v722 @ X0_v37+8]), v820, v224, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv750 = v750_asT == 0;\n\tif (v750) goto L_0117;\n\tv787 = \"il2cpp_vm_object_unbox\"(v727, System.Collections.DictionaryEntry, v820, v224, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv417 = *([v787 @ X0_v51]);\n\tv781 = *([v787 @ X0_v51]) == 0;\n\tif (v781) goto L_0105;\n\tv839 = *([v417 @ X22_v16 (System.String)]) != System.String;\n\tif (v839) goto L_0105;\n\tv867 = v173 & 1;\n\tv868 = v867 == 0;\n\tv869 = ~v868;\n\tif (v869) goto L_00F3;\n\tv888 = System.Text.StringBuilder::Append(this._buffer, 0x2C);\n\tv876 = *([v417 @ X22_v16 (System.String)]) != System.String;\n\tif (v876) goto L_011B;\nL_00F3:\n\tYMMJSONUtils.JSONEncoder::EncodeString(this, *([v787 @ X0_v51]));\n\tv900 = System.Text.StringBuilder::Append(this._buffer, 0x3A);\n\tYMMJSONUtils.JSONEncoder::EncodeObject(this, *([v787 @ X0_v51+8]));\n\tgoto L_005F;\n\tgoto L_013F;\nL_0105:\n\tv845 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v845, \"Dictionary keys must be strings\", \"d\");\n\tthrow v845;\n\tv786 = new System.NullReferenceException();\nL_0117:\n\tv806 = new System.InvalidCastException();\n\tv828 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_011B:\n\tthrow System.InvalidCastException;\n\tv221 = new System.NullReferenceException();\nL_011E:\n\tv267 = new System.NullReferenceException();\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\n\tgoto L_0135;\nL_0135:\n\tv239 = *([v406 @ X0_v30+8]) != 1;\n\tif (v239) goto L_0190;\n\tv414 = 0x6D2BC0(v267, *([v406 @ X0_v30+8]), v262, v224, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv124 = *([v414 @ X0_v25]);\n\tv459 = 0x6D2490(v414, *([v406 @ X0_v30+8]), v262, v224, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_013F:\n\t// 319 IsInst v557 @ X0_v13 (System.IDisposable), typeof(System.IDisposable), v550 @ X20_v5 (System.Collections.IEnumerator)\n\tv567 = v557 == 0;\n\tif (v567) goto L_016F;\n\tgoto L_016E;\n\tv631 = *([v572 @ X8_v8+B0]);\n\tv632 = 0;\n\tv633 = v631 + 8;\n\tv635 = *([v694 @ X11_v10-8]);\n\tv700 = v635 == v573;\n\tif (v700) goto L_0167;\n\tv657 = v695 + 1;\n\tv729 = v657 < v574;\n\tv653 = ~v729;\n\tv655 = v694 + 0x10;\n\tv637 = ~v653;\n\tif (v637) goto L_FFFFFFFF;\n\tv658 = v120;\n\tv659 = 0;\n\tv660 = 0x8909C4(v658, v573, v659, v61, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_016E;\nL_0167:\n\tv730 = *([v694 @ X11_v10]);\n\tv731 = v730 << 4;\n\tv732 = v572 + v731;\n\tv733 = v732 + 0x130;\nL_016E:\n\tSystem.IDisposable::Dispose(v557);\nL_016F:\n\tv600 = v63 + 1;\n\tv91 = v600 == 0;\n\tv76 = ~v91;\n\tif (v76) goto L_0189;\n\tv661 = v124 == 0;\n\tv152 = ~v661;\n\tif (v152) goto L_018F;\nL_0189:\n\tv389 = System.Text.StringBuilder::Append(this._buffer, 0x7D);\n\treturn;\n\tthrow System.NullReferenceException;\nL_018F:\n\tv159 = new System.TypeLoadException();\nL_0190:\n\tv276 = 0x6D2380(v267, v264, v262, v128, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn;\n// 244 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeDictionary(IDictionary d)
		{
			//IL_0026: Expected I, but got O
			//IL_0061: Expected O, but got I
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Expected O, but got Unknown
			//IL_0109: Expected O, but got I
			//IL_0118: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_0431: Expected I4, but got O
			//IL_013c: Expected I, but got O
			//IL_0177: Expected O, but got I
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Expected O, but got Unknown
			//IL_021f: Expected O, but got I
			//IL_022e: Expected O, but got I
			//IL_01c3: Expected O, but got I
			//IL_0371: Expected O, but got I
			StringBuilder stringBuilder = _buffer.Append('{');
			IntPtr intPtr = (IntPtr)d;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ X11_v31-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c6;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			int num4 = 0;
			goto IL_04ed;
			IL_04b8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_00c6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 3;
			goto IL_04ed;
			IL_04ed:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X0_v30+8]");
			char c = '\0';
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v406 @ X0_v30] (should have been resolved before IL gen)");
			IEnumerator enumerator = default(IEnumerator);
			bool flag3 = enumerator == null;
			IEnumerator enumerator2 = enumerator;
			int num10;
			int num11;
			NullReferenceException ex4;
			if (!flag3)
			{
				int num5 = 1;
				object obj9 = default(object);
				object obj10 = default(object);
				while (enumerator.MoveNext())
				{
					IntPtr intPtr2 = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01dc;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj5 = 0L + 8L;
					int num6 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ X11_v21-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num6++;
						int num7 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag4 = (long)num7 < 0L;
						bool flag5 = !flag4;
						obj5 = (long)(IntPtr)obj5 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_01dc;
					}
					object obj6 = obj5 + 1;
					int num8 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)intPtr2 + (long)num8;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					int num9 = 0;
					goto IL_0580;
					IL_01dc:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num9 = 1;
					goto IL_0580;
					IL_0580:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v722 @ X0_v37] (should have been resolved before IL gen)");
					DictionaryEntry dictionaryEntry = (DictionaryEntry)((obj9 is DictionaryEntry) ? obj9 : null);
					if ((object)dictionaryEntry != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						string text = (string)obj10;
						if (obj10 != null && (object)text.GetType() == typeof(string))
						{
							if ((num5 & 1) == 0)
							{
								StringBuilder stringBuilder2 = _buffer.Append(',');
								bool flag6 = (object)text.GetType() != typeof(string);
								num9 = 0;
								if (flag6)
								{
									throw new InvalidCastException();
								}
							}
							EncodeString((string)obj10);
							StringBuilder stringBuilder3 = _buffer.Append(':');
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X0_v51+8]");
							EncodeObject(0);
							num5 = 0;
							continue;
						}
						ArgumentException ex = new ArgumentException("Dictionary keys must be strings", "d");
						throw ex;
					}
					InvalidCastException ex2 = new InvalidCastException();
					NullReferenceException ex3 = new NullReferenceException();
					throw new NullReferenceException();
				}
				num10 = 0;
				enumerator2 = enumerator;
				num11 = 0;
			}
			else
			{
				ex4 = new NullReferenceException();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X0_v30+8]");
				if ((IntPtr)0 != (IntPtr)1)
				{
					goto IL_04b8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj11 = default(object);
				num11 = (int)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num10 = -1;
			}
			(enumerator2 as IDisposable)?.Dispose();
			if (num10 + 1 != 0 || num11 == 0)
			{
				StringBuilder stringBuilder4 = _buffer.Append('}');
				return;
			}
			TypeLoadException ex5 = new TypeLoadException();
			num4 = 0;
			c = '\0';
			ex4 = (NullReferenceException)(object)ex5;
			goto IL_04b8;
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x15BDB00", Offset = "0x15BDB00", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1F10458]);\n\tv27 = *([v26 @ X8_v29]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, e, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202993C]) = v45;\nL_001C:\n\tv50 = System.Text.StringBuilder::Append(this._buffer, 0x5B);\n\tgoto L_004C;\n\tv243 = *([v143 @ X8_v14+B0]);\n\tv244 = 0;\n\tv245 = v243 + 8;\n\tv247 = *([v312 @ X11_v31-8]);\n\tv318 = v247 == v146;\n\tif (v318) goto L_0045;\n\tv269 = v313 + 1;\n\tv359 = v269 < v145;\n\tv265 = ~v359;\n\tv267 = v312 + 0x10;\n\tv249 = ~v265;\n\tif (v249) goto L_FFFFFFFF;\n\tv270 = v18;\n\tv271 = 0;\n\tv272 = 0x8909C4(v270, v146, v271, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004C;\nL_0045:\n\tv360 = *([v312 @ X11_v31]);\n\tv361 = v360 << 4;\n\tv362 = v143 + v361;\n\tv363 = v362 + 0x130;\nL_004C:\n\tv299 = System.Collections.IEnumerable::GetEnumerator(e);\n\tv300 = v299 == 0;\n\tif (v300) goto L_00C5;\nL_0057:\n\tgoto L_007E;\n\tv402 = *([v396 @ X8_v18+B0]);\n\tv403 = 0;\n\tv404 = v402 + 8;\n\tv406 = *([v443 @ X11_v26-8]);\n\tv449 = v406 == v397;\n\tif (v449) goto L_0077;\n\tv428 = v444 + 1;\n\tv500 = v428 < v398;\n\tv424 = ~v500;\n\tv426 = v443 + 0x10;\n\tv408 = ~v424;\n\tif (v408) goto L_FFFFFFFF;\n\tv429 = v189;\n\tv430 = 0;\n\tv431 = 0x8909C4(v429, v397, v430, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_007E;\nL_0077:\n\tv501 = *([v443 @ X11_v26]);\n\tv502 = v501 << 4;\n\tv503 = v396 + v502;\n\tv504 = v503 + 0x130;\nL_007E:\n\tv489 = System.Collections.IEnumerator::MoveNext(v299);\n\tv491 = v489 == 0;\n\tif (v491) goto L_FFFFFFFF;\n\tv510 = *([v299 @ X0_v32 (System.Collections.IEnumerator)]);\n\tv513 = *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v513) goto L_00A4;\n\tv615 = *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_008F:\n\tv621 = *([v615 @ X11_v21-8]) == System.Collections.IEnumerator;\n\tif (v621) goto L_00A7;\n\tv616 = v616 + 1;\n\tv647 = v616 < *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv565 = ~v647;\n\tv615 = v615 + 0x10;\n\tv549 = ~v565;\n\tif (v549) goto L_008F;\nL_00A4:\n\tv653 = 0x8909C4(v299, System.Collections.IEnumerator, 1, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00AE;\nL_00A7:\n\tv649 = *([v615 @ X11_v21]) + 1;\n\tv650 = v649 << 4;\n\tv651 = v510 + v650;\n\tv653 = v651 + 0x130;\nL_00AE:\n\t*([v653 @ X0_v37])(v656, v299, *([v653 @ X0_v37+8]), v387, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv657 = v151 & 1;\n\tv658 = v657 == 0;\n\tv659 = ~v658;\n\tif (v659) goto L_00BC;\n\tv673 = System.Text.StringBuilder::Append(this._buffer, 0x2C);\nL_00BC:\n\tYMMJSONUtils.JSONEncoder::EncodeObject(this, v656);\n\tgoto L_0057;\n\tgoto L_00DE;\n\tthrow System.NullReferenceException;\n\tv195 = new System.NullReferenceException();\nL_00C5:\n\tv233 = new System.NullReferenceException();\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\nL_00D4:\n\tv205 = v230 != 1;\n\tif (v205) goto L_012C;\n\tv370 = 0x6D2BC0(v233, v230, v228, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv110 = *([v370 @ X0_v25]);\n\tv401 = 0x6D2490(v370, v230, v228, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00DE:\n\t// 222 IsInst v499 @ X0_v13 (System.IDisposable), typeof(System.IDisposable), v299 @ X0_v32 (System.Collections.IEnumerator)\n\tv509 = v499 == 0;\n\tif (v509) goto L_010E;\n\tgoto L_010D;\n\tv573 = *([v514 @ X8_v8+B0]);\n\tv574 = 0;\n\tv575 = v573 + 8;\n\tv577 = *([v636 @ X11_v10-8]);\n\tv642 = v577 == v515;\n\tif (v642) goto L_0106;\n\tv599 = v637 + 1;\n\tv660 = v599 < v516;\n\tv595 = ~v660;\n\tv597 = v636 + 0x10;\n\tv579 = ~v595;\n\tif (v579) goto L_FFFFFFFF;\n\tv600 = v106;\n\tv601 = 0;\n\tv602 = 0x8909C4(v600, v515, v601, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_010D;\nL_0106:\n\tv661 = *([v636 @ X11_v10]);\n\tv662 = v661 << 4;\n\tv663 = v514 + v662;\n\tv664 = v663 + 0x130;\nL_010D:\n\tSystem.IDisposable::Dispose(v499);\nL_010E:\n\tv542 = v57 + 1;\n\tv77 = v542 == 0;\n\tv62 = ~v77;\n\tif (v62) goto L_0125;\n\tv603 = v110 == 0;\n\tv134 = ~v603;\n\tif (v134) goto L_012B;\nL_0125:\n\tv348 = System.Text.StringBuilder::Append(this._buffer, 0x5D);\n\treturn;\n\tthrow System.NullReferenceException;\nL_012B:\n\tv141 = new System.TypeLoadException();\nL_012C:\n\tv242 = 0x6D2380(v233, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EncodeEnumerable(IEnumerable e)
		{
			//IL_01ca: Expected I4, but got O
			//IL_0039: Expected I, but got O
			//IL_0074: Expected O, but got I
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			//IL_011c: Expected O, but got I
			//IL_012b: Expected O, but got I
			//IL_00c0: Expected O, but got I
			StringBuilder stringBuilder = _buffer.Append('[');
			IEnumerator enumerator = e.GetEnumerator();
			int num6;
			int num7;
			NullReferenceException ex;
			if (enumerator != null)
			{
				int num = 1;
				object obj5 = default(object);
				while (enumerator.MoveNext())
				{
					IntPtr intPtr = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00d9;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj = 0L + 8L;
					int num2 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ X11_v21-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num2++;
						int num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag = (long)num3 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00d9;
					}
					object obj2 = obj + 1;
					int num4 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num4;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					int num5 = 0;
					goto IL_02c8;
					IL_00d9:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num5 = 1;
					goto IL_02c8;
					IL_02c8:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v653 @ X0_v37] (should have been resolved before IL gen)");
					if ((num & 1) == 0)
					{
						StringBuilder stringBuilder2 = _buffer.Append(',');
						num5 = 0;
					}
					EncodeObject(obj5);
					num = 0;
				}
				num6 = 0;
				num7 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				int num8 = default(int);
				if (num8 != 1)
				{
					goto IL_023f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj6 = default(object);
				num7 = (int)obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num6 = -1;
			}
			(enumerator as IDisposable)?.Dispose();
			if (num6 + 1 != 0 || num7 == 0)
			{
				StringBuilder stringBuilder3 = _buffer.Append(']');
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_023f;
			IL_023f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}
	}
}

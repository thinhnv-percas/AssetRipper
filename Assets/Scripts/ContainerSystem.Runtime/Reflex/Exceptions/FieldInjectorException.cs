using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Exceptions
{
	[Token(Token = "0x200002C")]
	internal sealed class FieldInjectorException : Exception
	{
		[Token(Token = "0x6000079")]
		[Address(RVA = "0x3F32CEC", Offset = "0x3F32CEC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_0031:\n\tSystem.Exception::.ctor(this, v52, e);\n\treturn;\nL_001C:\n\tv52 = Reflex.Exceptions.FieldInjectorException::BuildMessage(field, e);\n\tgoto L_0031;\n")]
		public FieldInjectorException(FieldInfo field, Exception e)
		{
			string message = BuildMessage(field, e);
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x3F345EC", Offset = "0x3F345EC", Length = "0x3A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\nL_0047:\n\tv132 = System.Reflection.MemberInfo::get_DeclaringType(field);\n\tv208 = System.Reflection.MemberInfo::get_Name(v132);\n\tv210 = System.Reflection.MemberInfo::get_Name(field);\n\t// 51 NewArr v52 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv52[0] = \"'\";\n\tv52[1] = v208;\n\tv52[2] = \".\";\n\tv52[3] = v210;\n\tv52[4] = \"'\";\n\tv345 = System.String::Concat(v52);\n\tv133 = System.Reflection.FieldInfo::get_FieldType(field);\n\tv354 = System.Reflection.MemberInfo::get_Name(v133);\n\tv359 = System.String::Concat(\"(\", v354, \")\");\n\tgoto L_00BA;\n\tv419 = e;\n\tv419 = v419.InnerException;\n\tv432 = v419.InnerException == 0;\n\tv401 = ~v432;\n\tif (v401) goto L_00C5;\n\tgoto L_00E1;\nL_00D2:\n\tv399 = System.Exception::get_Message(v419);\n\tv402 = v399 == 0;\n\tif (v402) goto L_00E1;\n\tv428 = System.String::Concat(\"\\n  ROOT CAUSE: \", v399, \"\\n\");\n\tv128 = v428;\n\tgoto L_00E7;\nL_00E1:\n\tv406 = 0xB7D5000 + 0x538;\n\tv407 = *([v406 @ X8_v35 (System.Int32)+90]);\n\tv408 = *([v407 @ X8_v36+B8]);\n\tv128 = *([v408 @ X8_v37]);\n\tv437 = v345 == 0;\n\tif (v437) goto L_00F8;\n\tv252 = 0x21C11D0(v345, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv257 = v252 == 0;\n\tif (v257) goto L_014F;\nL_00F8:\n\tv134[0] = v345;\n\tv445 = v359 == 0;\n\tif (v445) goto L_010C;\n\tv253 = 0x21C11D0(v359, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv258 = v253 == 0;\n\tif (v258) goto L_014F;\nL_010C:\n\tv134[1] = v359;\n\tv453 = v128 == 0;\n\tif (v453) goto L_0126;\n\tv254 = 0x21C11D0(v128, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv259 = v254 == 0;\n\tif (v259) goto L_014F;\nL_0126:\n\tv134[2] = v128;\n\tv462 = e == 0;\n\tif (v462) goto L_013C;\n\tv255 = 0x21C11D0(e, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv260 = v255 == 0;\n\tif (v260) goto L_014F;\nL_013C:\n\tv134[3] = e;\n\treturnVal2 = System.String::Format(\"Could not inject field {0} {1}{2}\\n{3}\", v134);\n\treturn returnVal2;\nL_014F:\n\tv269 = new System.ArrayTypeMismatchException();\n\tthrow v269;\nL_00BA:\n\tv372 = e == 0;\n\tif (v372) goto L_00E1;\nL_00C5:\n\tv390 = *([v419 @ X0_v67 (System.Exception)]) == Reflex.Exceptions.UnknownContractException;\n\tif (v390) goto L_00D2;\nL_00E7:\n\t// 231 NewArr v134 @ X0_v38 (System.Object[]), typeof(System.Object[]), 4\n")]
		private static string BuildMessage(FieldInfo field, Exception e)
		{
			//IL_01a4: Expected O, but got I
			//IL_01b4: Expected O, but got I
			Type declaringType = field.DeclaringType;
			string name = declaringType.Name;
			string name2 = field.Name;
			string text = "'" + name + "." + name2 + "'";
			Type fieldType = field.FieldType;
			string name3 = fieldType.Name;
			string text2 = "(" + name3 + ")";
			string text4;
			if (e != null)
			{
				Exception ex = e;
				while ((object)((object)ex).GetType() != typeof(UnknownContractException))
				{
					ex = ex.InnerException;
					if (ex.InnerException != null)
					{
						continue;
					}
					goto IL_0185;
				}
				string message = ex.Message;
				if (message != null)
				{
					string text3 = "\n  ROOT CAUSE: " + message + "\n";
					text4 = text3;
					goto IL_0387;
				}
			}
			goto IL_0185;
			IL_0387:
			object[] array = new object[4];
			if (text != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0339;
				}
			}
			array[0] = text;
			if (text2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0339;
				}
			}
			array[1] = text2;
			if (text4 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_0339;
				}
			}
			array[2] = text4;
			if (e != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_0339;
				}
			}
			array[3] = e;
			return string.Format("Could not inject field {0} {1}{2}\n{3}", array);
			IL_0339:
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
			IL_0185:
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X8_v35 (System.Int32)+90]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v36+B8]");
			object obj6 = 0;
			text4 = (string)obj6;
			goto IL_0387;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x3F34994", Offset = "0x3F34994", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv89 = e;\n\tv89 = v89.InnerException;\n\tv116 = v89.InnerException == 0;\n\tv70 = ~v116;\n\tif (v70) goto L_001C;\nL_002C:\n\treturn 0;\nL_0035:\n\tv107 = System.Exception::get_Message(v107);\nL_0035:\n\treturn v89;\nL_0012:\n\tv38 = e == 0;\n\tif (v38) goto L_002C;\nL_001C:\n\tv55 = *([v89 @ X19_v4 (System.Exception)]) == Reflex.Exceptions.UnknownContractException;\n\tif (v55) goto L_0035;\n")]
		private static string FindRootCause(Exception e)
		{
			if (e != null)
			{
				Exception ex = e;
				Exception message = default(Exception);
				do
				{
					if ((object)((object)ex).GetType() != typeof(UnknownContractException))
					{
						ex = ex.InnerException;
						continue;
					}
					message = (Exception)(object)message.Message;
					return (string)(object)ex;
				}
				while (ex.InnerException != null);
			}
			return null;
		}
	}
}

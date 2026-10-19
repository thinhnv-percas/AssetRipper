using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Exceptions
{
	[Token(Token = "0x200002D")]
	internal sealed class MethodInjectorException : Exception
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200002E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400003F")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000040")]
			public static Func<ParameterInfo, string> _003C_003E9__1_0;

			[Token(Token = "0x600007F")]
			[Address(RVA = "0x3F34EFC", Offset = "0x3F34EFC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Reflex.Exceptions.MethodInjectorException+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000080")]
			[Address(RVA = "0x3F34F60", Offset = "0x3F34F60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CBuildMessage_003Eb__1_0(ParameterInfo p)
			{
				Type parameterType = p.ParameterType;
				string name = parameterType.Name;
				string name2 = p.Name;
				return name + " " + name2;
			}
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x3F33720", Offset = "0x3F33720", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0033:\n\tSystem.Exception::.ctor(this, v54, e);\n\treturn;\nL_001E:\n\tv54 = Reflex.Exceptions.MethodInjectorException::BuildMessage(obj, method, e);\n\tgoto L_0033;\n")]
		public MethodInjectorException(object obj, MethodInfo method, Exception e)
		{
			string message = BuildMessage(obj, method, e);
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x3F34A0C", Offset = "0x3F34A0C", Length = "0x478")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\nL_0043:\n\tv63 = System.Reflection.MethodBase::GetParameters(method);\n\tv136 = System.Object::GetType(obj);\n\tv267 = System.Reflection.MemberInfo::get_Name(v136);\n\tv269 = System.Reflection.MemberInfo::get_Name(method);\n\t// 71 NewArr v67 @ X0_v10 (System.String[]), typeof(System.String[]), 5\n\tv67[0] = \"'\";\n\tv67[1] = v267;\n\tv67[2] = \".\";\n\tv67[3] = v269;\n\tv67[4] = \"'\";\n\tv378 = System.String::Concat(v67);\n\tgoto L_00B3;\nL_00B3:\n\t;\n\tv387 = v384.<>9__1_0 == 0;\n\tv388 = ~v387;\n\tv397 = v384.<>9__1_0;\n\tv413 = \", \";\n\tif (v388) goto L_00E1;\n\tv413 = \", \";\n\tgoto L_00C8;\nL_00C8:\n\tgoto L_00D0;\n\tv397 = v437;\n\tv504 = e;\n\tv504 = v504.InnerException;\n\tv517 = v504.InnerException == 0;\n\tv486 = ~v517;\n\tif (v486) goto L_00FF;\n\tgoto L_011B;\nL_010C:\n\tv484 = System.Exception::get_Message(v504);\n\tv487 = v484 == 0;\n\tif (v487) goto L_011B;\n\tv513 = System.String::Concat(\"\\n  ROOT CAUSE: \", v484, \"\\n\");\n\tv132 = v513;\n\tgoto L_0121;\nL_011B:\n\tv491 = 0xB7D5000 + 0x538;\n\tv492 = *([v491 @ X8_v35 (System.Int32)+90]);\n\tv493 = *([v492 @ X8_v36+B8]);\n\tv132 = *([v493 @ X8_v37]);\n\tv522 = v378 == 0;\n\tif (v522) goto L_0132;\n\tv196 = 0x21C11D0(v378, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv201 = v196 == 0;\n\tif (v201) goto L_018B;\nL_0132:\n\tv137[0] = v378;\n\tv530 = v429 == 0;\n\tif (v530) goto L_0146;\n\tv197 = 0x21C11D0(v429, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv202 = v197 == 0;\n\tif (v202) goto L_018B;\nL_0146:\n\tv137[1] = v429;\n\tv538 = v132 == 0;\n\tif (v538) goto L_0160;\n\tv198 = 0x21C11D0(v132, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv203 = v198 == 0;\n\tif (v203) goto L_018B;\nL_0160:\n\tv137[2] = v132;\n\tv547 = e == 0;\n\tif (v547) goto L_0176;\n\tv199 = 0x21C11D0(e, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv204 = v199 == 0;\n\tif (v204) goto L_018B;\nL_0176:\n\tv137[3] = e;\n\treturnVal2 = System.String::Format(\"Could not inject {0}({1}){2}\\n{3}\", v137);\n\treturn returnVal2;\nL_018B:\n\tv214 = new System.ArrayTypeMismatchException();\n\tthrow v214;\nL_00E1:\n\tv418 = System.Linq.Enumerable::Select(v63, v397);\n\tv429 = System.String::Join(v413, v418);\n\tgoto L_00F4;\nL_00D0:\n\tv437 = new System.Func`2<System.Reflection.ParameterInfo, System.String>();\n\tSystem.Func`2<System.Reflection.ParameterInfo, System.String>::.ctor(v437, v432.<>9, Il2CppMethodInfo);\n\tv455.<>9__1_0 = v437;\nL_00F4:\n\tv454 = e == 0;\n\tif (v454) goto L_011B;\nL_00FF:\n\tv475 = *([v504 @ X0_v70 (System.Exception)]) == Reflex.Exceptions.UnknownContractException;\n\tif (v475) goto L_010C;\nL_0121:\n\t// 289 NewArr v137 @ X0_v41 (System.Object[]), typeof(System.Object[]), 4\n")]
		private static string BuildMessage(object obj, MethodInfo method, Exception e)
		{
			//IL_01d8: Expected O, but got I
			//IL_01e8: Expected O, but got I
			ParameterInfo[] parameters = method.GetParameters();
			Type type = obj.GetType();
			string name = type.Name;
			string name2 = method.Name;
			string text = "'" + name + "." + name2 + "'";
			bool flag = _003C_003Ec._003C_003E9__1_0 == null;
			bool flag2 = !flag;
			Func<object, object> selector = (Func<object, object>)_003C_003Ec._003C_003E9__1_0;
			string separator = ", ";
			if (!flag2)
			{
				separator = ", ";
				selector = (Func<object, object>)(_003C_003Ec._003C_003E9__1_0 = delegate(ParameterInfo p)
				{
					Type parameterType = p.ParameterType;
					string name3 = parameterType.Name;
					string name4 = p.Name;
					return name3 + " " + name4;
				});
			}
			IEnumerable<object> values = parameters.Select(selector);
			string text2 = string.Join(separator, (IEnumerable<string>)values);
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
					goto IL_01b9;
				}
				string message = ex.Message;
				if (message != null)
				{
					string text3 = "\n  ROOT CAUSE: " + message + "\n";
					text4 = text3;
					goto IL_0405;
				}
			}
			goto IL_01b9;
			IL_01b9:
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ X8_v35 (System.Int32)+90]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ X8_v36+B8]");
			object obj3 = 0;
			text4 = (string)obj3;
			goto IL_0405;
			IL_036d:
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
			IL_0405:
			object[] array = new object[4];
			if (text != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_036d;
				}
			}
			array[0] = text;
			if (text2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj5 = default(object);
				if (obj5 == null)
				{
					goto IL_036d;
				}
			}
			array[1] = text2;
			if (text4 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj6 = default(object);
				if (obj6 == null)
				{
					goto IL_036d;
				}
			}
			array[2] = text4;
			if (e != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj7 = default(object);
				if (obj7 == null)
				{
					goto IL_036d;
				}
			}
			array[3] = e;
			return string.Format("Could not inject {0}({1}){2}\n{3}", array);
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x3F34E84", Offset = "0x3F34E84", Length = "0x78")]
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

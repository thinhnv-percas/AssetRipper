using System;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000060")]
	internal static class QueryHelper
	{
		[Token(Token = "0x600016E")]
		[Address(RVA = "0xC6E36C", Offset = "0xC6E36C", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1F08510]);\n\tv35 = *([v34 @ X8_v32]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20233B0]) = v54;\nL_0021:\n\tv61 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v61);\n\tv69 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Keys(parameters);\n\tv198 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+KeyCollection<System.String, System.Object>::GetEnumerator(v69);\nL_0045:\n\tv308 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+KeyCollection<System.String, System.Object>+Enumerator<System.String, System.Object>::MoveNext(&v145 @ stack_-98_v5 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+KeyCollection<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tv310 = v308 == 0;\n\tif (v310) goto L_008B;\n\tv374 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(parameters, v236);\n\tv304 = *([v374 @ X0_v25]);\n\t*([v304 @ X8_v23+160])(v298, v374, *([v304 @ X8_v23+168]), Il2CppMethodInfo, v422, 0, v41, v42, v43, v145, v45, v46, v47, v48, v49, v50, v51);\n\tv301 = v298 == 0;\n\tif (v301) goto L_0045;\n\tv388 = v61 == 0;\n\tif (v388) goto L_0092;\n\tv393 = System.Text.StringBuilder::get_Length(v61);\n\tv281 = v393 != 0;\n\tif (v281) goto L_FFFFFFFF;\n\tgoto L_006B;\nL_006B:\n\t;\n\tv403 = System.Text.StringBuilder::Append(v61, *([v399 @ X8_v24 (System.String)]));\n\tgoto L_007B;\n\tv411 = *([v405 @ X0_v39+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tgoto L_007B;\n\tv415 = \"il2cpp_codegen_runtime_class_init\"(v405, v400, v402, v76, v74, v41, v42, v43, v142, v45, v46, v47, v48, v49, v50, v51);\nL_007B:\n\tv418 = System.Uri::EscapeDataString(v236);\n\tv422 = System.Uri::EscapeDataString(v298);\n\tv299 = System.Text.StringBuilder::AppendFormat(v61, \"{0}={1}\", v418, v422);\n\tgoto L_0045;\nL_008B:\n\tv150 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+KeyCollection<System.String, System.Object>+Enumerator<System.String, System.Object>::Dispose(&v145 @ stack_-98_v5 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+KeyCollection<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tv378 = v61 == 0;\n\tv153 = ~v378;\n\tif (v153) goto L_00B8;\n\tgoto L_00C8;\n\tthrow System.NullReferenceException;\nL_0092:\n\tv227 = new System.NullReferenceException();\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\nL_00A5:\n\tv72 = v236 != 1;\n\tif (v72) goto L_00C9;\n\tv398 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v227, v236);\n\tv404 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v398, v236);\n\tv151 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(&v145 @ stack_-98_v5 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+KeyCollection<System.String, System.Object>+Enumerator<System.String, System.Object>), Il2CppMethodInfo);\n\tv419 = *([v398 @ X0_v29]) == 0;\n\tv272 = ~v419;\n\tif (v272) goto L_00CD;\nL_00B8:\n\treturnVal2 = System.Text.StringBuilder::ToString(v61);\n\treturn returnVal2;\nL_00C8:\n\tv227 = new System.NullReferenceException();\nL_00C9:\n\tv234 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v227, v225);\nL_00CD:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string ToQueryString(this Dictionary<string, object> parameters)
		{
			//IL_01b3: Expected O, but got I
			StringBuilder stringBuilder = new StringBuilder();
			object keys = parameters.Keys;
			object enumerator = ((Dictionary<string, object>.KeyCollection)keys).GetEnumerator();
			Dictionary<string, object>.KeyCollection.Enumerator enumerator2 = default(Dictionary<string, object>.KeyCollection.Enumerator);
			string text = default(string);
			string text2 = default(string);
			while (true)
			{
				string key;
				NullReferenceException ex;
				if (enumerator2.MoveNext())
				{
					object obj = parameters.get_Item(text);
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v304 @ X8_v23+160] (should have been resolved before IL gen)");
					if (text2 == null)
					{
						continue;
					}
					bool flag = stringBuilder == null;
					key = text;
					if (!flag)
					{
						string value = ((stringBuilder.Length != 0) ? "&" : "?");
						StringBuilder stringBuilder2 = stringBuilder.Append(value);
						string arg = Uri.EscapeDataString(text);
						string arg2 = Uri.EscapeDataString(text2);
						StringBuilder stringBuilder3 = stringBuilder.AppendFormat("{0}={1}", arg, arg2);
						continue;
					}
					ex = new NullReferenceException();
					if ((IntPtr)text == (IntPtr)1)
					{
						object obj3 = ((Dictionary<string, object>)(object)ex).get_Item(text);
						object obj4 = ((Dictionary<string, object>)obj3).get_Item(text);
						object obj5 = ((Dictionary<string, object>)enumerator2).get_Item((string)0);
						if (obj3 != null)
						{
							break;
						}
						goto IL_01df;
					}
				}
				else
				{
					enumerator2.Dispose();
					if (stringBuilder != null)
					{
						goto IL_01df;
					}
					ex = new NullReferenceException();
					key = null;
				}
				object obj6 = ((Dictionary<string, object>)(object)ex).get_Item(key);
				break;
				IL_01df:
				return stringBuilder.ToString();
			}
			return (string)(object)new TypeLoadException();
		}
	}
}

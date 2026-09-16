using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using IronSourceJSON;

[Token(Token = "0x200000E")]
public class IronSourceUtils
{
	[Token(Token = "0x400005F")]
	private const string ERROR_CODE = "error_code";

	[Token(Token = "0x4000060")]
	private const string ERROR_DESCRIPTION = "error_description";

	[Token(Token = "0x4000061")]
	private const string INSTANCE_ID_KEY = "instanceId";

	[Token(Token = "0x4000062")]
	private const string PLACEMENT_KEY = "placement";

	[Token(Token = "0x6000181")]
	[Address(RVA = "0x159E6E8", Offset = "0x159E6E8", Length = "0x23C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EB5A98]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20297C1]) = v42;\nL_0019:\n\t// 25 IsInst v47 @ X0_v3, typeof(System.Collections.IDictionary), descriptionObject @ X0 (System.Object)\n\tv48 = v47 == 0;\n\tif (v48) goto L_0043;\n\tv49 = descriptionObject == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv144 = v144_asT == 0;\n\tif (v144) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tgoto L_0057;\nL_0043:\n\tv50 = descriptionObject == 0;\n\tif (v50) goto L_FFFFFFFF;\n\tv89 = *([descriptionObject @ X0 (System.Object)]) == System.String;\n\tif (v89) goto L_00B5;\nL_0057:\n\tv186 = new IronSourceError();\n\tSystem.Object::.ctor(v186);\n\tv186.code = 0xFFFFFFFF;\n\tv186.description = \"\";\n\tv200 = v180 == 0;\n\tif (v200) goto L_00B1;\n\tv206 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(v180);\n\tv214 = v206 < 1;\n\tif (v214) goto L_00B1;\n\tv288 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v180, \"error_code\");\n\tv296 = *([v288 @ X0_v12]);\n\t*([v296 @ X8_v15+160])(v299, v288, *([v296 @ X8_v15+168]), Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0092;\n\tv314 = *([v303 @ X8_v18+E0]);\n\tv315 = v314 == 0;\n\tv316 = ~v315;\n\tif (v316) goto L_0092;\n\tv323 = v303;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v323, v298, v287, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0092:\n\tv322 = System.Convert::ToInt32(v299);\n\tv310 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v180, \"error_description\");\n\tv326 = *([v310 @ X0_v20]);\n\t*([v326 @ X8_v21+160])(v328, v310, *([v326 @ X8_v21+168]), Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv234 = new IronSourceError();\n\tSystem.Object::.ctor(v234);\n\t*([v234 @ X0_v23 (System.Object)+18]) = v322;\n\t*([v234 @ X0_v23 (System.Object)+10]) = v328;\nL_00B1:\n\treturn v237;\nL_00B5:\n\tv189 = System.String::ToString(descriptionObject);\n\tv176 = System.String::IsNullOrEmpty(v189);\n\tv198 = v176 == 0;\n\tv178 = ~v198;\n\tif (v178) goto L_0057;\n\tv116 = System.Object::ToString(descriptionObject);\n\tv119 = v116 == 0;\n\tif (v119) goto L_FFFFFFFF;\n\tv117 = IronSourceJSON.Json+Parser::Parse(v116);\n\tv120 = v117 == 0;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv149 = v149_asT == 0;\n\tif (v149) goto L_FFFFFFFF;\n\tgoto L_00EB;\nL_00EB:\n\tgoto L_0057;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static IronSourceError getErrorFromErrorObject(object descriptionObject)
	{
		object obj = descriptionObject as IDictionary;
		object obj2;
		if (obj != null)
		{
			if (descriptionObject != null)
			{
				Dictionary<string, object> dictionary = descriptionObject as Dictionary<string, object>;
				obj2 = ((dictionary == null) ? null : descriptionObject);
				goto IL_0283;
			}
		}
		else if (descriptionObject != null && (object)descriptionObject.GetType() == typeof(string))
		{
			string value = ((string)descriptionObject).ToString();
			bool flag = string.IsNullOrEmpty(value);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			obj2 = null;
			if (flag3)
			{
				goto IL_0283;
			}
			string text = descriptionObject.ToString();
			if (text != null)
			{
				object obj3 = Json.Parser.Parse(text);
				if (obj3 != null)
				{
					Dictionary<string, object> dictionary2 = obj3 as Dictionary<string, object>;
					obj2 = ((dictionary2 == null) ? null : obj3);
					goto IL_0283;
				}
			}
		}
		obj2 = null;
		goto IL_0283;
		IL_0283:
		IronSourceError ironSourceError = null;
		ironSourceError.code = -1;
		ironSourceError.description = "";
		bool flag4 = obj2 == null;
		IronSourceError result = ironSourceError;
		if (!flag4)
		{
			int count = ((Dictionary<string, object>)obj2).Count;
			bool flag5 = count < 1;
			result = ironSourceError;
			if (!flag5)
			{
				object obj4 = ((Dictionary<string, object>)obj2).get_Item("error_code");
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v296 @ X8_v15+160] (should have been resolved before IL gen)");
				string value2 = default(string);
				int num = Convert.ToInt32(value2);
				object obj6 = ((Dictionary<string, object>)obj2).get_Item("error_description");
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v326 @ X8_v21+160] (should have been resolved before IL gen)");
				object obj8 = null;
				result = (IronSourceError)obj8;
			}
		}
		return result;
	}

	[Token(Token = "0x6000182")]
	[Address(RVA = "0x159E924", Offset = "0x159E924", Length = "0x1EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC8758]);\n\tv23 = *([v22 @ X8_v34]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20297C2]) = v42;\nL_0019:\n\t// 25 IsInst v47 @ X0_v3, typeof(System.Collections.IDictionary), placementObject @ X0 (System.Object)\n\tv48 = v47 == 0;\n\tif (v48) goto L_0095;\n\tv49 = placementObject == 0;\n\tif (v49) goto L_00AE;\nL_002E:\n\tgoto L_FFFFFFFF;\n\tv191 = v191_asT == 0;\n\tif (v191) goto L_FFFFFFFF;\n\tv193 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(v84);\n\tv120 = v193 < 1;\n\tif (v120) goto L_FFFFFFFF;\n\tv243 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v84, \"placement_reward_amount\");\n\tv245 = *([v243 @ X0_v14]);\n\t*([v245 @ X8_v19+160])(v248, v243, *([v245 @ X8_v19+168]), Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_006D;\n\tv267 = *([v252 @ X8_v22+E0]);\n\tv268 = v267 == 0;\n\tv269 = ~v268;\n\tif (v269) goto L_006D;\n\tv276 = v252;\n\tv271 = \"il2cpp_codegen_runtime_class_init\"(v276, v247, v242, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006D:\n\tv275 = System.Convert::ToInt32(v248);\n\tv262 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v84, \"placement_reward_name\");\n\tv279 = *([v262 @ X0_v22]);\n\t*([v279 @ X8_v25+160])(v281, v262, *([v279 @ X8_v25+168]), Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv263 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v84, \"placement_name\");\n\tv284 = *([v263 @ X0_v25]);\n\t*([v284 @ X8_v28+160])(v286, v263, *([v284 @ X8_v28+168]), Il2CppMethodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv156 = new IronSourcePlacement();\n\tSystem.Object::.ctor(v156);\n\t*([v156 @ X0_v28 (System.Object)+20]) = v286;\n\t*([v156 @ X0_v28 (System.Object)+10]) = v281;\n\t*([v156 @ X0_v28 (System.Object)+18]) = v275;\n\tgoto L_00AE;\nL_0095:\n\tv50 = placementObject == 0;\n\tif (v50) goto L_00AE;\n\tv67 = *([placementObject @ X0 (System.Object)]) == System.String;\n\tif (v67) goto L_00B2;\nL_00AE:\n\treturn v160;\nL_00B2:\n\tv194 = System.String::ToString(placementObject);\n\tv195 = v194 == 0;\n\tif (v195) goto L_FFFFFFFF;\n\tv81 = IronSourceJSON.Json+Parser::Parse(v194);\n\tv235 = v81 == 0;\n\tv83 = ~v235;\n\tif (v83) goto L_002E;\n\tgoto L_00AE;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static IronSourcePlacement getPlacementFromObject(object placementObject)
	{
		object obj = placementObject as IDictionary;
		object obj2;
		object result;
		if (obj != null)
		{
			bool flag = placementObject == null;
			obj2 = placementObject;
			result = placementObject;
			if (!flag)
			{
				goto IL_0037;
			}
		}
		else
		{
			bool flag2 = placementObject == null;
			result = placementObject;
			if (!flag2)
			{
				if ((object)placementObject.GetType() == typeof(string))
				{
					string text = ((string)placementObject).ToString();
					if (text != null)
					{
						object obj3 = Json.Parser.Parse(text);
						bool flag3 = obj3 == null;
						bool flag4 = !flag3;
						obj2 = obj3;
						if (flag4)
						{
							goto IL_0037;
						}
						result = obj3;
						goto IL_0233;
					}
				}
				goto IL_018b;
			}
		}
		goto IL_0233;
		IL_018b:
		result = null;
		goto IL_0233;
		IL_0233:
		return (IronSourcePlacement)result;
		IL_0037:
		Dictionary<string, object> dictionary = obj2 as Dictionary<string, object>;
		if (dictionary != null)
		{
			int count = ((Dictionary<string, object>)obj2).Count;
			if (count >= 1)
			{
				object obj4 = ((Dictionary<string, object>)obj2).get_Item("placement_reward_amount");
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v245 @ X8_v19+160] (should have been resolved before IL gen)");
				string value = default(string);
				int num = Convert.ToInt32(value);
				object obj6 = ((Dictionary<string, object>)obj2).get_Item("placement_reward_name");
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v279 @ X8_v25+160] (should have been resolved before IL gen)");
				object obj8 = ((Dictionary<string, object>)obj2).get_Item("placement_name");
				object obj9 = obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v284 @ X8_v28+160] (should have been resolved before IL gen)");
				object obj10 = null;
				result = obj10;
				goto IL_0233;
			}
		}
		goto IL_018b;
	}

	[Token(Token = "0x6000183")]
	[Address(RVA = "0x159EB10", Offset = "0x159EB10", Length = "0x1008")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n\tGameAnalyticsSDK.Events.GA_Ads::NewEvent(X0, X1, X2, X3, X4, X5);\n\treturn;\n\tX8 = *([X21]);\n\tX0 = 0x1596008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1022 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourceUtils()
	{
	}
}

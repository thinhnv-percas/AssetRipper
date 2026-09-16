using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000015")]
	public class AdjustSessionSuccess
	{
		[Token(Token = "0x17000038")]
		public string Adid
		{
			[CompilerGenerated]
			[Token(Token = "0x6000115")]
			[Address(RVA = "0x156F314", Offset = "0x156F314", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Adid>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Adid;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000116")]
			[Address(RVA = "0x156F31C", Offset = "0x156F31C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Adid>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Adid = value;
			}
		}

		[Token(Token = "0x17000039")]
		public string Message
		{
			[CompilerGenerated]
			[Token(Token = "0x6000117")]
			[Address(RVA = "0x156F324", Offset = "0x156F324", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Message>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Message;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000118")]
			[Address(RVA = "0x156F32C", Offset = "0x156F32C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Message>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Message = value;
			}
		}

		[Token(Token = "0x1700003A")]
		public string Timestamp
		{
			[CompilerGenerated]
			[Token(Token = "0x6000119")]
			[Address(RVA = "0x156F334", Offset = "0x156F334", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Timestamp>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Timestamp;
			}
			[CompilerGenerated]
			[Token(Token = "0x600011A")]
			[Address(RVA = "0x156F33C", Offset = "0x156F33C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Timestamp>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Timestamp = value;
			}
		}

		[Token(Token = "0x1700003B")]
		public Dictionary<string, object> JsonResponse
		{
			[CompilerGenerated]
			[Token(Token = "0x600011B")]
			[Address(RVA = "0x156F344", Offset = "0x156F344", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<JsonResponse>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return JsonResponse;
			}
			[CompilerGenerated]
			[Token(Token = "0x600011C")]
			[Address(RVA = "0x156F34C", Offset = "0x156F34C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<JsonResponse>k__BackingField = value;\n\treturn;\n")]
			set
			{
				JsonResponse = value;
			}
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x156CDE4", Offset = "0x156CDE4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustSessionSuccess()
		{
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x156F354", Offset = "0x156F354", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EA87A0]);\n\tv25 = *([v24 @ X8_v23]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, sessionSuccessDataMap, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290CE]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv46 = sessionSuccessDataMap == 0;\n\tif (v46) goto L_0059;\n\tgoto L_002B;\n\tv77 = *([v49 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002B;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v49, v45, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv81 = com.adjust.sdk.AdjustUtils;\nL_002B:\n\tv87 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionSuccessDataMap, v84.KeyAdid);\n\tthis.<Adid>k__BackingField = v87;\n\tv117 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionSuccessDataMap, v115.KeyMessage);\n\tthis.<Message>k__BackingField = v117;\n\tv122 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionSuccessDataMap, v120.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v122;\n\tv126 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionSuccessDataMap, v70.KeyJsonResponse);\n\tv127 = com.adjust.sdk.JSONNode::Parse(v126);\n\tv62 = com.adjust.sdk.JSONNode::op_Equality(v127, 0);\n\tv129 = v62 == 0;\n\tv65 = ~v129;\n\tif (v65) goto L_0059;\n\tv132 = com.adjust.sdk.JSONNode::get_AsObject(v127);\n\tv61 = com.adjust.sdk.JSONNode::op_Equality(v132, 0);\n\tv64 = v61 == 0;\n\tif (v64) goto L_005D;\nL_0059:\n\treturn;\nL_005D:\n\tv138 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v138);\n\tthis.<JsonResponse>k__BackingField = v138;\n\tv147 = com.adjust.sdk.JSONNode::get_AsObject(v127);\n\tgoto L_007F;\n\tv153 = *([v107 @ X8_v19+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_007F;\n\tv158 = v107;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v158, v146, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_007F:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v147, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustSessionSuccess(Dictionary<string, string> sessionSuccessDataMap)
		{
			if (sessionSuccessDataMap != null)
			{
				string adid = AdjustUtils.TryGetValue(sessionSuccessDataMap, AdjustUtils.KeyAdid);
				Adid = adid;
				string message = AdjustUtils.TryGetValue(sessionSuccessDataMap, AdjustUtils.KeyMessage);
				Message = message;
				string timestamp = AdjustUtils.TryGetValue(sessionSuccessDataMap, AdjustUtils.KeyTimestamp);
				Timestamp = timestamp;
				JSONNode jSONNode = JSONNode.Parse(AdjustUtils.TryGetValue(sessionSuccessDataMap, AdjustUtils.KeyJsonResponse));
				if (!(jSONNode == null) && !(jSONNode.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0x156F4E4", Offset = "0x156F4E4", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F0CC18]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, jsonString, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290CF]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv47 = com.adjust.sdk.JSONNode::Parse(jsonString);\n\tv50 = com.adjust.sdk.JSONNode::op_Equality(v47, 0);\n\tv52 = v50 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0064;\n\tgoto L_0032;\n\tv87 = *([v56 @ X0_v7 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0032;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v56, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv91 = com.adjust.sdk.AdjustUtils;\nL_0032:\n\tv97 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v94.KeyAdid);\n\tthis.<Adid>k__BackingField = v97;\n\tv133 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v131.KeyMessage);\n\tthis.<Message>k__BackingField = v133;\n\tv138 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v136.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v138;\n\tv144 = com.adjust.sdk.JSONNode::get_Item(v47, v142.KeyJsonResponse);\n\tv72 = com.adjust.sdk.JSONNode::op_Equality(v144, 0);\n\tv149 = v72 == 0;\n\tv75 = ~v149;\n\tif (v75) goto L_0064;\n\tv152 = com.adjust.sdk.JSONNode::get_AsObject(v144);\n\tv71 = com.adjust.sdk.JSONNode::op_Equality(v152, 0);\n\tv74 = v71 == 0;\n\tif (v74) goto L_0068;\nL_0064:\n\treturn;\nL_0068:\n\tv157 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v157);\n\tthis.<JsonResponse>k__BackingField = v157;\n\tv166 = com.adjust.sdk.JSONNode::get_AsObject(v144);\n\tgoto L_008A;\n\tv172 = *([v122 @ X8_v21+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_008A;\n\tv177 = v122;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v177, v165, v61, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008A:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v166, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustSessionSuccess(string jsonString)
		{
			JSONNode jSONNode = JSONNode.Parse(jsonString);
			if (!(jSONNode == null))
			{
				string jsonString2 = AdjustUtils.GetJsonString(jSONNode, AdjustUtils.KeyAdid);
				Adid = jsonString2;
				string jsonString3 = AdjustUtils.GetJsonString(jSONNode, AdjustUtils.KeyMessage);
				Message = jsonString3;
				string jsonString4 = AdjustUtils.GetJsonString(jSONNode, AdjustUtils.KeyTimestamp);
				Timestamp = jsonString4;
				JSONNode jSONNode2 = jSONNode.get_Item(AdjustUtils.KeyJsonResponse);
				if (!(jSONNode2 == null) && !(jSONNode2.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode2.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0x156CDEC", Offset = "0x156CDEC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EAD560]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonResponseString, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290D0]) = v41;\nL_0016:\n\tv43 = com.adjust.sdk.JSONNode::Parse(jsonResponseString);\n\tv46 = com.adjust.sdk.JSONNode::op_Equality(v43, 0);\n\tv48 = v46 == 0;\n\tif (v48) goto L_0027;\n\treturn;\nL_0027:\n\tv57 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v57);\n\tthis.<JsonResponse>k__BackingField = v57;\n\tv89 = com.adjust.sdk.JSONNode::get_AsObject(v43);\n\tgoto L_004C;\n\tv98 = *([v77 @ X8_v10+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_004C;\n\tv103 = v77;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v103, v88, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004C:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v89, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void BuildJsonResponseFromString(string jsonResponseString)
		{
			JSONNode jSONNode = JSONNode.Parse(jsonResponseString);
			if (!(jSONNode == null))
			{
				Dictionary<string, object> jsonResponse = new Dictionary<string, object>();
				JsonResponse = jsonResponse;
				JSONClass asObject = jSONNode.AsObject;
				AdjustUtils.WriteJsonResponseDictionary(asObject, JsonResponse);
			}
		}

		[Token(Token = "0x6000121")]
		[Address(RVA = "0x156F690", Offset = "0x156F690", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF1E60]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290D1]) = v38;\nL_001A:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = com.adjust.sdk.AdjustUtils::GetJsonResponseCompact(this.<JsonResponse>k__BackingField);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(JsonResponse);
		}
	}
}

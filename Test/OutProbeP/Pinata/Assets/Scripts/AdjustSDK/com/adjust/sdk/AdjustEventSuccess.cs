using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000011")]
	public class AdjustEventSuccess
	{
		[Token(Token = "0x1700002D")]
		public string Adid
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0x156E990", Offset = "0x156E990", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Adid>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Adid;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F4")]
			[Address(RVA = "0x156E998", Offset = "0x156E998", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Adid>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Adid = value;
			}
		}

		[Token(Token = "0x1700002E")]
		public string Message
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F5")]
			[Address(RVA = "0x156E9A0", Offset = "0x156E9A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Message>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Message;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F6")]
			[Address(RVA = "0x156E9A8", Offset = "0x156E9A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Message>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Message = value;
			}
		}

		[Token(Token = "0x1700002F")]
		public string Timestamp
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F7")]
			[Address(RVA = "0x156E9B0", Offset = "0x156E9B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Timestamp>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Timestamp;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F8")]
			[Address(RVA = "0x156E9B8", Offset = "0x156E9B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Timestamp>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Timestamp = value;
			}
		}

		[Token(Token = "0x17000030")]
		public string EventToken
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0x156E9C0", Offset = "0x156E9C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<EventToken>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EventToken;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x156E9C8", Offset = "0x156E9C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<EventToken>k__BackingField = value;\n\treturn;\n")]
			set
			{
				EventToken = value;
			}
		}

		[Token(Token = "0x17000031")]
		public string CallbackId
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FB")]
			[Address(RVA = "0x156E9D0", Offset = "0x156E9D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CallbackId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CallbackId;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000FC")]
			[Address(RVA = "0x156E9D8", Offset = "0x156E9D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CallbackId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				CallbackId = value;
			}
		}

		[Token(Token = "0x17000032")]
		public Dictionary<string, object> JsonResponse
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0x156E9E0", Offset = "0x156E9E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<JsonResponse>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return JsonResponse;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000FE")]
			[Address(RVA = "0x156E9E8", Offset = "0x156E9E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<JsonResponse>k__BackingField = value;\n\treturn;\n")]
			set
			{
				JsonResponse = value;
			}
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x156C444", Offset = "0x156C444", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustEventSuccess()
		{
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x156E9F0", Offset = "0x156E9F0", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF0D00]);\n\tv25 = *([v24 @ X8_v27]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventSuccessDataMap, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290C4]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv46 = eventSuccessDataMap == 0;\n\tif (v46) goto L_0065;\n\tgoto L_002B;\n\tv77 = *([v49 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002B;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v49, v45, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv81 = com.adjust.sdk.AdjustUtils;\nL_002B:\n\tv87 = com.adjust.sdk.AdjustUtils::TryGetValue(eventSuccessDataMap, v84.KeyAdid);\n\tthis.<Adid>k__BackingField = v87;\n\tv117 = com.adjust.sdk.AdjustUtils::TryGetValue(eventSuccessDataMap, v115.KeyMessage);\n\tthis.<Message>k__BackingField = v117;\n\tv122 = com.adjust.sdk.AdjustUtils::TryGetValue(eventSuccessDataMap, v120.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v122;\n\tv127 = com.adjust.sdk.AdjustUtils::TryGetValue(eventSuccessDataMap, v125.KeyEventToken);\n\tthis.<EventToken>k__BackingField = v127;\n\tv132 = com.adjust.sdk.AdjustUtils::TryGetValue(eventSuccessDataMap, v130.KeyCallbackId);\n\tthis.<CallbackId>k__BackingField = v132;\n\tv136 = com.adjust.sdk.AdjustUtils::TryGetValue(eventSuccessDataMap, v70.KeyJsonResponse);\n\tv137 = com.adjust.sdk.JSONNode::Parse(v136);\n\tv62 = com.adjust.sdk.JSONNode::op_Equality(v137, 0);\n\tv139 = v62 == 0;\n\tv65 = ~v139;\n\tif (v65) goto L_0065;\n\tv142 = com.adjust.sdk.JSONNode::get_AsObject(v137);\n\tv61 = com.adjust.sdk.JSONNode::op_Equality(v142, 0);\n\tv64 = v61 == 0;\n\tif (v64) goto L_0069;\nL_0065:\n\treturn;\nL_0069:\n\tv148 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v148);\n\tthis.<JsonResponse>k__BackingField = v148;\n\tv157 = com.adjust.sdk.JSONNode::get_AsObject(v137);\n\tgoto L_008B;\n\tv163 = *([v107 @ X8_v23+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_008B;\n\tv168 = v107;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v168, v156, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008B:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v157, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustEventSuccess(Dictionary<string, string> eventSuccessDataMap)
		{
			if (eventSuccessDataMap != null)
			{
				string adid = AdjustUtils.TryGetValue(eventSuccessDataMap, AdjustUtils.KeyAdid);
				Adid = adid;
				string message = AdjustUtils.TryGetValue(eventSuccessDataMap, AdjustUtils.KeyMessage);
				Message = message;
				string timestamp = AdjustUtils.TryGetValue(eventSuccessDataMap, AdjustUtils.KeyTimestamp);
				Timestamp = timestamp;
				EventToken = AdjustUtils.TryGetValue(eventSuccessDataMap, AdjustUtils.KeyEventToken);
				CallbackId = AdjustUtils.TryGetValue(eventSuccessDataMap, AdjustUtils.KeyCallbackId);
				JSONNode jSONNode = JSONNode.Parse(AdjustUtils.TryGetValue(eventSuccessDataMap, AdjustUtils.KeyJsonResponse));
				if (!(jSONNode == null) && !(jSONNode.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x156EBB0", Offset = "0x156EBB0", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB5D70]);\n\tv25 = *([v24 @ X8_v29]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, jsonString, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290C5]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv47 = com.adjust.sdk.JSONNode::Parse(jsonString);\n\tv50 = com.adjust.sdk.JSONNode::op_Equality(v47, 0);\n\tv52 = v50 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0070;\n\tgoto L_0032;\n\tv87 = *([v56 @ X0_v7 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0032;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v56, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv91 = com.adjust.sdk.AdjustUtils;\nL_0032:\n\tv97 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v94.KeyAdid);\n\tthis.<Adid>k__BackingField = v97;\n\tv133 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v131.KeyMessage);\n\tthis.<Message>k__BackingField = v133;\n\tv138 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v136.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v138;\n\tv143 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v141.KeyEventToken);\n\tthis.<EventToken>k__BackingField = v143;\n\tv148 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v146.KeyCallbackId);\n\tthis.<CallbackId>k__BackingField = v148;\n\tv154 = com.adjust.sdk.JSONNode::get_Item(v47, v152.KeyJsonResponse);\n\tv72 = com.adjust.sdk.JSONNode::op_Equality(v154, 0);\n\tv159 = v72 == 0;\n\tv75 = ~v159;\n\tif (v75) goto L_0070;\n\tv162 = com.adjust.sdk.JSONNode::get_AsObject(v154);\n\tv71 = com.adjust.sdk.JSONNode::op_Equality(v162, 0);\n\tv74 = v71 == 0;\n\tif (v74) goto L_0074;\nL_0070:\n\treturn;\nL_0074:\n\tv167 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v167);\n\tthis.<JsonResponse>k__BackingField = v167;\n\tv176 = com.adjust.sdk.JSONNode::get_AsObject(v154);\n\tgoto L_0096;\n\tv182 = *([v122 @ X8_v25+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0096;\n\tv187 = v122;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v187, v175, v61, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0096:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v176, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustEventSuccess(string jsonString)
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
				EventToken = AdjustUtils.GetJsonString(jSONNode, AdjustUtils.KeyEventToken);
				CallbackId = AdjustUtils.GetJsonString(jSONNode, AdjustUtils.KeyCallbackId);
				JSONNode jSONNode2 = jSONNode.get_Item(AdjustUtils.KeyJsonResponse);
				if (!(jSONNode2 == null) && !(jSONNode2.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode2.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x156C44C", Offset = "0x156C44C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EBFFE8]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonResponseString, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290C6]) = v41;\nL_0016:\n\tv43 = com.adjust.sdk.JSONNode::Parse(jsonResponseString);\n\tv46 = com.adjust.sdk.JSONNode::op_Equality(v43, 0);\n\tv48 = v46 == 0;\n\tif (v48) goto L_0027;\n\treturn;\nL_0027:\n\tv57 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v57);\n\tthis.<JsonResponse>k__BackingField = v57;\n\tv89 = com.adjust.sdk.JSONNode::get_AsObject(v43);\n\tgoto L_004C;\n\tv98 = *([v77 @ X8_v10+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_004C;\n\tv103 = v77;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v103, v88, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004C:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v89, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x156ED8C", Offset = "0x156ED8C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ECB610]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290C7]) = v38;\nL_001A:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = com.adjust.sdk.AdjustUtils::GetJsonResponseCompact(this.<JsonResponse>k__BackingField);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(JsonResponse);
		}
	}
}

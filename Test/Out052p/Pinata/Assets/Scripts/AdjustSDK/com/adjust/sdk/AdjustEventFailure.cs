using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000010")]
	public class AdjustEventFailure
	{
		[CompilerGenerated]
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x38")]
		internal bool _003CWillRetry_003Ek__BackingField;

		[Token(Token = "0x17000026")]
		public string Adid
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E0")]
			[Address(RVA = "0x156DA00", Offset = "0x156DA00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Adid>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Adid;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E1")]
			[Address(RVA = "0x156DA08", Offset = "0x156DA08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Adid>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Adid = value;
			}
		}

		[Token(Token = "0x17000027")]
		public string Message
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E2")]
			[Address(RVA = "0x156DA10", Offset = "0x156DA10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Message>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Message;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E3")]
			[Address(RVA = "0x156DA18", Offset = "0x156DA18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Message>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Message = value;
			}
		}

		[Token(Token = "0x17000028")]
		public string Timestamp
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E4")]
			[Address(RVA = "0x156DA20", Offset = "0x156DA20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Timestamp>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Timestamp;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E5")]
			[Address(RVA = "0x156DA28", Offset = "0x156DA28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Timestamp>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Timestamp = value;
			}
		}

		[Token(Token = "0x17000029")]
		public string EventToken
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E6")]
			[Address(RVA = "0x156DA30", Offset = "0x156DA30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<EventToken>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EventToken;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x156DA38", Offset = "0x156DA38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<EventToken>k__BackingField = value;\n\treturn;\n")]
			set
			{
				EventToken = value;
			}
		}

		[Token(Token = "0x1700002A")]
		public string CallbackId
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x156DA40", Offset = "0x156DA40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CallbackId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CallbackId;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E9")]
			[Address(RVA = "0x156DA48", Offset = "0x156DA48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CallbackId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				CallbackId = value;
			}
		}

		[Token(Token = "0x1700002B")]
		public bool WillRetry
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x156DA50", Offset = "0x156DA50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<WillRetry>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return WillRetry;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x156DA58", Offset = "0x156DA58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<WillRetry>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CWillRetry_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002C")]
		public Dictionary<string, object> JsonResponse
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0x156DA64", Offset = "0x156DA64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<JsonResponse>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return JsonResponse;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0x156DA6C", Offset = "0x156DA6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<JsonResponse>k__BackingField = value;\n\treturn;\n")]
			set
			{
				JsonResponse = value;
			}
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x156BE90", Offset = "0x156BE90", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustEventFailure()
		{
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x156DA74", Offset = "0x156DA74", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB6970]);\n\tv25 = *([v24 @ X8_v36]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, eventFailureDataMap, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290C0]) = v43;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tv47 = eventFailureDataMap == 0;\n\tif (v47) goto L_00AC;\n\tgoto L_002C;\n\tv94 = *([v50 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_002C;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v50, v45, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv98 = com.adjust.sdk.AdjustUtils;\nL_002C:\n\tv104 = com.adjust.sdk.AdjustUtils::TryGetValue(eventFailureDataMap, v101.KeyAdid);\n\tthis.<Adid>k__BackingField = v104;\n\tv125 = com.adjust.sdk.AdjustUtils::TryGetValue(eventFailureDataMap, v123.KeyMessage);\n\tthis.<Message>k__BackingField = v125;\n\tv130 = com.adjust.sdk.AdjustUtils::TryGetValue(eventFailureDataMap, v128.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v130;\n\tv135 = com.adjust.sdk.AdjustUtils::TryGetValue(eventFailureDataMap, v133.KeyEventToken);\n\tthis.<EventToken>k__BackingField = v135;\n\tv140 = com.adjust.sdk.AdjustUtils::TryGetValue(eventFailureDataMap, v138.KeyCallbackId);\n\tthis.<CallbackId>k__BackingField = v140;\n\tv145 = com.adjust.sdk.AdjustUtils::TryGetValue(eventFailureDataMap, v143.KeyWillRetry);\n\tgoto L_005C;\n\tv152 = *([v148 @ X8_v19+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_005C;\n\tv161 = v148;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v161, v144, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005C:\n\tv160 = System.Boolean::TryParse(v145, &v57 @ stack_-34_v3 (System.Boolean));\n\tv163 = v160 == 0;\n\tif (v163) goto L_0066;\n\tthis.<WillRetry>k__BackingField = v57;\nL_0066:\n\tgoto L_0070;\n\tv170 = *([v166 @ X0_v21 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tgoto L_0070;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v166, v158, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv174 = com.adjust.sdk.AdjustUtils;\nL_0070:\n\tv179 = com.adjust.sdk.AdjustUtils::TryGetValue(eventFailureDataMap, v83.KeyJsonResponse);\n\tv181 = com.adjust.sdk.JSONNode::Parse(v179);\n\tv70 = com.adjust.sdk.JSONNode::op_Equality(v181, 0);\n\tv183 = v70 == 0;\n\tv74 = ~v183;\n\tif (v74) goto L_00AC;\n\tv186 = com.adjust.sdk.JSONNode::get_AsObject(v181);\n\tv71 = com.adjust.sdk.JSONNode::op_Equality(v186, 0);\n\tv189 = v71 == 0;\n\tv75 = ~v189;\n\tif (v75) goto L_00AC;\n\tv193 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v193);\n\tthis.<JsonResponse>k__BackingField = v193;\n\tv201 = com.adjust.sdk.JSONNode::get_AsObject(v181);\n\tgoto L_00A4;\n\tv205 = *([v82 @ X8_v30+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_00A4;\n\tv210 = v82;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v210, v200, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A4:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v201, this.<JsonResponse>k__BackingField);\nL_00AC:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustEventFailure(Dictionary<string, string> eventFailureDataMap)
		{
			if (eventFailureDataMap != null)
			{
				string adid = AdjustUtils.TryGetValue(eventFailureDataMap, AdjustUtils.KeyAdid);
				Adid = adid;
				string message = AdjustUtils.TryGetValue(eventFailureDataMap, AdjustUtils.KeyMessage);
				Message = message;
				string timestamp = AdjustUtils.TryGetValue(eventFailureDataMap, AdjustUtils.KeyTimestamp);
				Timestamp = timestamp;
				EventToken = AdjustUtils.TryGetValue(eventFailureDataMap, AdjustUtils.KeyEventToken);
				CallbackId = AdjustUtils.TryGetValue(eventFailureDataMap, AdjustUtils.KeyCallbackId);
				if (bool.TryParse(AdjustUtils.TryGetValue(eventFailureDataMap, AdjustUtils.KeyWillRetry), out var result))
				{
					WillRetry = result;
				}
				string aJSON = AdjustUtils.TryGetValue(eventFailureDataMap, AdjustUtils.KeyJsonResponse);
				JSONNode jSONNode = JSONNode.Parse(aJSON);
				if (!(jSONNode == null) && !(jSONNode.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x156E030", Offset = "0x156E030", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ECD6B8]);\n\tv25 = *([v24 @ X8_v35]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, jsonString, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290C1]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv47 = com.adjust.sdk.JSONNode::Parse(jsonString);\n\tv50 = com.adjust.sdk.JSONNode::op_Equality(v47, 0);\n\tv52 = v50 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0088;\n\tgoto L_0032;\n\tv89 = *([v56 @ X0_v7 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0032;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v56, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv93 = com.adjust.sdk.AdjustUtils;\nL_0032:\n\tv99 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v96.KeyAdid);\n\tthis.<Adid>k__BackingField = v99;\n\tv135 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v133.KeyMessage);\n\tthis.<Message>k__BackingField = v135;\n\tv140 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v138.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v140;\n\tv145 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v143.KeyEventToken);\n\tthis.<EventToken>k__BackingField = v145;\n\tv150 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v148.KeyCallbackId);\n\tthis.<CallbackId>k__BackingField = v150;\n\tv155 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v153.KeyWillRetry);\n\tgoto L_0061;\n\tv162 = *([v158 @ X8_v19+E0]);\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_0061;\n\tv172 = v158;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v172, v154, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0061:\n\tv171 = System.Convert::ToBoolean(v155);\n\tthis.<WillRetry>k__BackingField = v171;\n\tv179 = com.adjust.sdk.JSONNode::get_Item(v47, v177.KeyJsonResponse);\n\tv72 = com.adjust.sdk.JSONNode::op_Equality(v179, 0);\n\tv184 = v72 == 0;\n\tv75 = ~v184;\n\tif (v75) goto L_0088;\n\tv187 = com.adjust.sdk.JSONNode::get_AsObject(v179);\n\tv71 = com.adjust.sdk.JSONNode::op_Equality(v187, 0);\n\tv74 = v71 == 0;\n\tif (v74) goto L_008C;\nL_0088:\n\treturn;\nL_008C:\n\tv192 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v192);\n\tthis.<JsonResponse>k__BackingField = v192;\n\tv201 = com.adjust.sdk.JSONNode::get_AsObject(v179);\n\tgoto L_00AE;\n\tv207 = *([v124 @ X8_v31+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_00AE;\n\tv212 = v124;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v212, v200, v61, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00AE:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v201, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustEventFailure(string jsonString)
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
				WillRetry = Convert.ToBoolean(AdjustUtils.GetJsonString(jSONNode, AdjustUtils.KeyWillRetry));
				JSONNode jSONNode2 = jSONNode.get_Item(AdjustUtils.KeyJsonResponse);
				if (!(jSONNode2 == null) && !(jSONNode2.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode2.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x156BE98", Offset = "0x156BE98", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F0A220]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonResponseString, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290C2]) = v41;\nL_0016:\n\tv43 = com.adjust.sdk.JSONNode::Parse(jsonResponseString);\n\tv46 = com.adjust.sdk.JSONNode::op_Equality(v43, 0);\n\tv48 = v46 == 0;\n\tif (v48) goto L_0027;\n\treturn;\nL_0027:\n\tv57 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v57);\n\tthis.<JsonResponse>k__BackingField = v57;\n\tv89 = com.adjust.sdk.JSONNode::get_AsObject(v43);\n\tgoto L_004C;\n\tv98 = *([v77 @ X8_v10+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_004C;\n\tv103 = v77;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v103, v88, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004C:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v89, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x156E25C", Offset = "0x156E25C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBFB10]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290C3]) = v38;\nL_001A:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = com.adjust.sdk.AdjustUtils::GetJsonResponseCompact(this.<JsonResponse>k__BackingField);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(JsonResponse);
		}
	}
}

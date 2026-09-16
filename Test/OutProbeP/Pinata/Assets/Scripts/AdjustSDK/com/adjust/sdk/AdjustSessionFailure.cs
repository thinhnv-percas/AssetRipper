using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000014")]
	public class AdjustSessionFailure
	{
		[CompilerGenerated]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x28")]
		internal bool _003CWillRetry_003Ek__BackingField;

		[Token(Token = "0x17000033")]
		public string Adid
		{
			[CompilerGenerated]
			[Token(Token = "0x6000106")]
			[Address(RVA = "0x156EE5C", Offset = "0x156EE5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Adid>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Adid;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000107")]
			[Address(RVA = "0x156EE64", Offset = "0x156EE64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Adid>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Adid = value;
			}
		}

		[Token(Token = "0x17000034")]
		public string Message
		{
			[CompilerGenerated]
			[Token(Token = "0x6000108")]
			[Address(RVA = "0x156EE6C", Offset = "0x156EE6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Message>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Message;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000109")]
			[Address(RVA = "0x156EE74", Offset = "0x156EE74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Message>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Message = value;
			}
		}

		[Token(Token = "0x17000035")]
		public string Timestamp
		{
			[CompilerGenerated]
			[Token(Token = "0x600010A")]
			[Address(RVA = "0x156EE7C", Offset = "0x156EE7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Timestamp>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Timestamp;
			}
			[CompilerGenerated]
			[Token(Token = "0x600010B")]
			[Address(RVA = "0x156EE84", Offset = "0x156EE84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Timestamp>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Timestamp = value;
			}
		}

		[Token(Token = "0x17000036")]
		public bool WillRetry
		{
			[CompilerGenerated]
			[Token(Token = "0x600010C")]
			[Address(RVA = "0x156EE8C", Offset = "0x156EE8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<WillRetry>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return WillRetry;
			}
			[CompilerGenerated]
			[Token(Token = "0x600010D")]
			[Address(RVA = "0x156EE94", Offset = "0x156EE94", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<WillRetry>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CWillRetry_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000037")]
		public Dictionary<string, object> JsonResponse
		{
			[CompilerGenerated]
			[Token(Token = "0x600010E")]
			[Address(RVA = "0x156EEA0", Offset = "0x156EEA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<JsonResponse>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return JsonResponse;
			}
			[CompilerGenerated]
			[Token(Token = "0x600010F")]
			[Address(RVA = "0x156EEA8", Offset = "0x156EEA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<JsonResponse>k__BackingField = value;\n\treturn;\n")]
			set
			{
				JsonResponse = value;
			}
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x156C928", Offset = "0x156C928", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustSessionFailure()
		{
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x156EEB0", Offset = "0x156EEB0", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EFB160]);\n\tv25 = *([v24 @ X8_v32]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, sessionFailureDataMap, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290CA]) = v43;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tv47 = sessionFailureDataMap == 0;\n\tif (v47) goto L_00A0;\n\tgoto L_002C;\n\tv94 = *([v50 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_002C;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v50, v45, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv98 = com.adjust.sdk.AdjustUtils;\nL_002C:\n\tv104 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionFailureDataMap, v101.KeyAdid);\n\tthis.<Adid>k__BackingField = v104;\n\tv125 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionFailureDataMap, v123.KeyMessage);\n\tthis.<Message>k__BackingField = v125;\n\tv130 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionFailureDataMap, v128.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v130;\n\tv135 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionFailureDataMap, v133.KeyWillRetry);\n\tgoto L_0050;\n\tv142 = *([v138 @ X8_v15+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0050;\n\tv151 = v138;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v151, v134, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0050:\n\tv150 = System.Boolean::TryParse(v135, &v57 @ stack_-34_v3 (System.Boolean));\n\tv153 = v150 == 0;\n\tif (v153) goto L_005A;\n\tthis.<WillRetry>k__BackingField = v57;\nL_005A:\n\tgoto L_0064;\n\tv160 = *([v156 @ X0_v17 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tgoto L_0064;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v156, v148, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv164 = com.adjust.sdk.AdjustUtils;\nL_0064:\n\tv169 = com.adjust.sdk.AdjustUtils::TryGetValue(sessionFailureDataMap, v83.KeyJsonResponse);\n\tv171 = com.adjust.sdk.JSONNode::Parse(v169);\n\tv70 = com.adjust.sdk.JSONNode::op_Equality(v171, 0);\n\tv173 = v70 == 0;\n\tv74 = ~v173;\n\tif (v74) goto L_00A0;\n\tv176 = com.adjust.sdk.JSONNode::get_AsObject(v171);\n\tv71 = com.adjust.sdk.JSONNode::op_Equality(v176, 0);\n\tv179 = v71 == 0;\n\tv75 = ~v179;\n\tif (v75) goto L_00A0;\n\tv183 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v183);\n\tthis.<JsonResponse>k__BackingField = v183;\n\tv191 = com.adjust.sdk.JSONNode::get_AsObject(v171);\n\tgoto L_0098;\n\tv195 = *([v82 @ X8_v26+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0098;\n\tv200 = v82;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v200, v190, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0098:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v191, this.<JsonResponse>k__BackingField);\nL_00A0:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustSessionFailure(Dictionary<string, string> sessionFailureDataMap)
		{
			if (sessionFailureDataMap != null)
			{
				string adid = AdjustUtils.TryGetValue(sessionFailureDataMap, AdjustUtils.KeyAdid);
				Adid = adid;
				string message = AdjustUtils.TryGetValue(sessionFailureDataMap, AdjustUtils.KeyMessage);
				Message = message;
				string timestamp = AdjustUtils.TryGetValue(sessionFailureDataMap, AdjustUtils.KeyTimestamp);
				Timestamp = timestamp;
				if (bool.TryParse(AdjustUtils.TryGetValue(sessionFailureDataMap, AdjustUtils.KeyWillRetry), out var result))
				{
					WillRetry = result;
				}
				string aJSON = AdjustUtils.TryGetValue(sessionFailureDataMap, AdjustUtils.KeyJsonResponse);
				JSONNode jSONNode = JSONNode.Parse(aJSON);
				if (!(jSONNode == null) && !(jSONNode.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x156F0B0", Offset = "0x156F0B0", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EFC6D8]);\n\tv25 = *([v24 @ X8_v31]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, jsonString, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290CB]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv47 = com.adjust.sdk.JSONNode::Parse(jsonString);\n\tv50 = com.adjust.sdk.JSONNode::op_Equality(v47, 0);\n\tv52 = v50 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_007C;\n\tgoto L_0032;\n\tv89 = *([v56 @ X0_v7 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0032;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v56, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv93 = com.adjust.sdk.AdjustUtils;\nL_0032:\n\tv99 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v96.KeyAdid);\n\tthis.<Adid>k__BackingField = v99;\n\tv135 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v133.KeyMessage);\n\tthis.<Message>k__BackingField = v135;\n\tv140 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v138.KeyTimestamp);\n\tthis.<Timestamp>k__BackingField = v140;\n\tv145 = com.adjust.sdk.AdjustUtils::GetJsonString(v47, v143.KeyWillRetry);\n\tgoto L_0055;\n\tv152 = *([v148 @ X8_v15+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_0055;\n\tv162 = v148;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v162, v144, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0055:\n\tv161 = System.Convert::ToBoolean(v145);\n\tthis.<WillRetry>k__BackingField = v161;\n\tv169 = com.adjust.sdk.JSONNode::get_Item(v47, v167.KeyJsonResponse);\n\tv72 = com.adjust.sdk.JSONNode::op_Equality(v169, 0);\n\tv174 = v72 == 0;\n\tv75 = ~v174;\n\tif (v75) goto L_007C;\n\tv177 = com.adjust.sdk.JSONNode::get_AsObject(v169);\n\tv71 = com.adjust.sdk.JSONNode::op_Equality(v177, 0);\n\tv74 = v71 == 0;\n\tif (v74) goto L_0080;\nL_007C:\n\treturn;\nL_0080:\n\tv182 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v182);\n\tthis.<JsonResponse>k__BackingField = v182;\n\tv191 = com.adjust.sdk.JSONNode::get_AsObject(v169);\n\tgoto L_00A2;\n\tv197 = *([v124 @ X8_v27+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_00A2;\n\tv202 = v124;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v202, v190, v61, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A2:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v191, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustSessionFailure(string jsonString)
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
				WillRetry = Convert.ToBoolean(AdjustUtils.GetJsonString(jSONNode, AdjustUtils.KeyWillRetry));
				JSONNode jSONNode2 = jSONNode.get_Item(AdjustUtils.KeyJsonResponse);
				if (!(jSONNode2 == null) && !(jSONNode2.AsObject == null))
				{
					JsonResponse = new Dictionary<string, object>();
					AdjustUtils.WriteJsonResponseDictionary(jSONNode2.AsObject, JsonResponse);
				}
			}
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x156C930", Offset = "0x156C930", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB0CE0]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonResponseString, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290CC]) = v41;\nL_0016:\n\tv43 = com.adjust.sdk.JSONNode::Parse(jsonResponseString);\n\tv46 = com.adjust.sdk.JSONNode::op_Equality(v43, 0);\n\tv48 = v46 == 0;\n\tif (v48) goto L_0027;\n\treturn;\nL_0027:\n\tv57 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v57);\n\tthis.<JsonResponse>k__BackingField = v57;\n\tv89 = com.adjust.sdk.JSONNode::get_AsObject(v43);\n\tgoto L_004C;\n\tv98 = *([v77 @ X8_v10+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_004C;\n\tv103 = v77;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v103, v88, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004C:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v89, this.<JsonResponse>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x156F2AC", Offset = "0x156F2AC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EDB558]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290CD]) = v38;\nL_001A:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = com.adjust.sdk.AdjustUtils::GetJsonResponseCompact(this.<JsonResponse>k__BackingField);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(JsonResponse);
		}
	}
}

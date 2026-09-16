using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000053")]
	internal class StoreCatalogImpl
	{
		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x10")]
		private IAsyncWebUtil m_AsyncUtil;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x18")]
		private ILogger m_Logger;

		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x20")]
		private string m_CatalogURL;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x28")]
		private string m_StoreName;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x30")]
		private FileReference m_cachedStoreCatalogReference;

		[Token(Token = "0x40000F7")]
		private static ProfileData profile;

		[Token(Token = "0x6000139")]
		[Address(RVA = "0xC63744", Offset = "0xC63744", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1EE5080]);\n\tv35 = *([v34 @ X8_v31]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, baseUrl, webUtil, logger, util, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20233D2]) = v50;\nL_001D:\n\tv53 = System.String::IsNullOrEmpty(storeName);\n\tv56 = v53 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0084;\n\tv60 = System.String::IsNullOrEmpty(baseUrl);\n\tv97 = v60 == 0;\n\tv72 = ~v97;\n\tif (v72) goto L_0084;\n\tv116 = logger == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_003E;\n\tgoto L_003B;\n\tv133 = *([v120 @ X0_v24+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_003B;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v120, v59, webUtil, logger, util, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_003B:\n\tv125 = UnityEngine.Debug::get_unityLogger();\nL_003E:\n\tv132 = UnityEngine.Purchasing.ProfileData::Instance(util);\n\tv141.profile = v132;\n\tv68 = v143.profile;\n\tv145 = v68.<AppId>k__BackingField;\n\tv152 = v145.m_stringLength == 0;\n\tif (v152) goto L_FFFFFFFF;\n\tv155 = v68.<UserId>k__BackingField;\n\tv158 = v155.m_stringLength == 0;\n\tif (v158) goto L_FFFFFFFF;\n\tv156 = v68.<DeviceId>k__BackingField;\n\tv73 = v156.m_stringLength == 0;\n\tif (v73) goto L_FFFFFFFF;\n\tv161 = UnityEngine.Purchasing.ProfileData::GetProfileIds(v68);\n\tv162 = UnityEngine.Purchasing.QueryHelper::ToQueryString(v161);\n\tv168 = System.String::Concat(baseUrl, \"/catalog\", v162);\n\tv174 = UnityEngine.Purchasing.FileReference::CreateInstance(\"store.json\", v77, util);\n\tv69 = new UnityEngine.Purchasing.StoreCatalogImpl();\n\tSystem.Object::.ctor(v69);\n\t*([v69 @ X0_v23 (System.Object)+10]) = webUtil;\n\t*([v69 @ X0_v23 (System.Object)+18]) = v77;\n\t*([v69 @ X0_v23 (System.Object)+20]) = v168;\n\t*([v69 @ X0_v23 (System.Object)+28]) = storeName;\n\t*([v69 @ X0_v23 (System.Object)+30]) = v174;\n\tgoto L_0084;\nL_0084:\n\treturn v83;\n\tv148 = new System.NullReferenceException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static StoreCatalogImpl CreateInstance(string storeName, string baseUrl, IAsyncWebUtil webUtil, ILogger logger, IUtil util)
		{
			bool flag = string.IsNullOrEmpty(storeName);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			StoreCatalogImpl result = null;
			if (!flag3)
			{
				bool flag4 = string.IsNullOrEmpty(baseUrl);
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = null;
				if (!flag6)
				{
					bool flag7 = logger == null;
					bool flag8 = !flag7;
					ILogger logger2 = logger;
					if (!flag8)
					{
						ILogger unityLogger = Debug.unityLogger;
						logger2 = unityLogger;
					}
					ProfileData profileData = ProfileData.Instance(util);
					profile = profileData;
					ProfileData profileData2 = profile;
					string appId = profileData2.AppId;
					if (appId.Length != 0)
					{
						string userId = profileData2.UserId;
						if (userId.Length != 0)
						{
							string deviceId = profileData2.DeviceId;
							if (deviceId.Length != 0)
							{
								Dictionary<string, object> profileIds = profileData2.GetProfileIds();
								string text = profileIds.ToQueryString();
								string text2 = baseUrl + "/catalog" + text;
								FileReference fileReference = FileReference.CreateInstance("store.json", logger2, util);
								object obj = null;
								result = (StoreCatalogImpl)obj;
								goto IL_01ea;
							}
						}
					}
					result = null;
				}
			}
			goto IL_01ea;
			IL_01ea:
			return result;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0xC70CC4", Offset = "0xC70CC4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_AsyncUtil = util;\n\tthis.m_Logger = logger;\n\tthis.m_CatalogURL = catalogURL;\n\tthis.m_StoreName = storeName;\n\tthis.m_cachedStoreCatalogReference = fileReference;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal StoreCatalogImpl(IAsyncWebUtil util, ILogger logger, string catalogURL, string storeName, FileReference fileReference)
		{
			m_AsyncUtil = util;
			m_Logger = logger;
			m_CatalogURL = catalogURL;
			m_StoreName = storeName;
			m_cachedStoreCatalogReference = fileReference;
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0xC63A4C", Offset = "0xC63A4C", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EBB3E0]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, callback, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20233D3]) = v47;\nL_001B:\n\tv51 = new UnityEngine.Purchasing.StoreCatalogImpl+<>c__DisplayClass10_0();\n\tUnityEngine.Purchasing.StoreCatalogImpl+<>c__DisplayClass10_0::.ctor(v51);\n\tv51.<>4__this = this;\n\tv51.callback = callback;\n\tv60 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v60, v51, Il2CppMethodInfo);\n\tv72 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v72, v51, Il2CppMethodInfo);\n\tgoto L_0077;\n\tv172 = *([v168 @ X8_v10+B0]);\n\tv173 = 0;\n\tv174 = v172 + 8;\n\tv176 = *([v212 @ X11_v5-8]);\n\tv218 = v176 == v171;\n\tif (v218) goto L_0063;\n\tv198 = v213 + 1;\n\tv223 = v198 < v170;\n\tv194 = ~v223;\n\tv196 = v212 + 0x10;\n\tv178 = ~v194;\n\tif (v178) goto L_FFFFFFFF;\n\tv199 = v57;\n\tv200 = 0;\n\tv201 = 0x8909C4(v199, v171, v200, v62, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0077;\nL_0063:\n\tv224 = *([v212 @ X11_v5]);\n\tv225 = v224 << 4;\n\tv226 = v168 + v225;\n\tv227 = v226 + 0x130;\nL_0077:\n\tUnityEngine.Purchasing.IAsyncWebUtil::Get(this.m_AsyncUtil, this.m_CatalogURL, v60, v72, 0x1E);\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void FetchProducts(Action<List<ProductDefinition>> callback)
		{
			Action<string> responseHandler = delegate(string response)
			{
				//IL_014f: Expected I, but got O
				//IL_0065: Expected I, but got O
				//IL_018a: Expected O, but got I
				//IL_00a0: Expected O, but got I
				//IL_0294: Unknown result type (might be due to invalid IL or missing references)
				//IL_0299: Expected O, but got Unknown
				//IL_02b6: Expected O, but got I
				//IL_02c5: Expected O, but got I
				//IL_020c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0211: Expected O, but got Unknown
				//IL_022e: Expected O, but got I
				//IL_023d: Expected O, but got I
				//IL_01d6: Expected O, but got I
				//IL_00ec: Expected O, but got I
				StoreCatalogImpl storeCatalogImpl = this;
				List<ProductDefinition> list = ParseProductsFromJSON(response, storeCatalogImpl.m_StoreName, storeCatalogImpl.m_Logger);
				StoreCatalogImpl storeCatalogImpl2 = this;
				ILogger logger = storeCatalogImpl2.m_Logger;
				if (list != null)
				{
					IntPtr intPtr = (IntPtr)logger;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v16 (Il2CppClass<UnityEngine.ILogger>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0105;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v16 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X11_v13-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILogger))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v16 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0105;
					}
					object obj2 = obj + 4;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_0315;
				}
				string text = "Failed to fetch IAP catalog due to malformed response for " + storeCatalogImpl2.m_StoreName;
				string text2 = "response: " + response;
				IntPtr intPtr2 = (IntPtr)logger;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01ef;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+B0]");
				object obj5 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X11_v7-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILogger))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj5 = (long)(IntPtr)obj5 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_01ef;
				}
				object obj6 = obj5 + 7;
				int num6 = (int)((long)(IntPtr)obj6 << 4);
				object obj7 = (long)intPtr2 + (long)num6;
				object obj8 = (long)(IntPtr)obj7 + 304L;
				goto IL_0358;
				IL_01ef:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0358;
				IL_0358:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v367 @ X0_v12] (should have been resolved before IL gen)");
				handleCachedCatalog(callback);
				return;
				IL_0105:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0315;
				IL_0315:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v301 @ X0_v19] (should have been resolved before IL gen)");
				StoreCatalogImpl storeCatalogImpl3 = this;
				if (storeCatalogImpl3.m_cachedStoreCatalogReference != null)
				{
					storeCatalogImpl3.m_cachedStoreCatalogReference.Save(response);
				}
				callback(list);
			};
			Action<string> errorHandler = delegate
			{
				handleCachedCatalog(callback);
			};
			m_AsyncUtil.Get(m_CatalogURL, responseHandler, errorHandler);
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0xC70D18", Offset = "0xC70D18", Length = "0x4A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EEBA38]);\n\tv33 = *([v32 @ X8_v76]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, storeName, logger, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20233D4]) = v50;\nL_0020:\n\tv57 = System.String::IsNullOrEmpty(json);\n\tv61 = v57 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_013D;\n\tv66 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v66);\n\tv248 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tgoto L_FFFFFFFF;\n\tv342 = v342_asT == 0;\n\tif (v342) goto L_0141;\n\tv435 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v248, \"catalog\", &v98 @ stack_-48_v7 (System.Object));\n\tv467 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v248, \"abGroup\", &v95 @ stack_-58_v7 (System.Object));\n\tv471 = v467 == 0;\n\tif (v471) goto L_00A8;\n\tv488 = v487.profile;\n\tv489 = v487.profile == 0;\n\tif (v489) goto L_00A8;\n\tgoto L_007E;\n\tv540 = *([v511 @ X0_v64+E0]);\n\tv541 = v540 == 0;\n\tv542 = ~v541;\n\tif (v542) goto L_007E;\n\tv544 = \"il2cpp_codegen_runtime_class_init\"(v511, v464, v465, v354, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_007E:\n\tv549 = System.Convert::ToInt32(v95);\n\tv560 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(&v491 @ stack_-70_v8 (System.Nullable`1<System.Int32>), v549, Il2CppMethodInfo);\n\tgoto L_0093;\n\tv610 = *([1EE0ED8]);\n\tv611 = *([v610 @ X8_v71]);\n\tv612 = \"il2cpp_codegen_initialize_method\"(v611, v493, v492, v354, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv614 = 0 | 1;\n\t*([202339F]) = v614;\nL_0093:\n\tv501 = v491 & 0xFF00000000;\n\tv497 = v501 == 0;\n\tif (v497) goto L_00A8;\n\tv488.<StoreABGroup>k__BackingField = v491;\nL_00A8:\n\tgoto L_FFFFFFFF;\n\tv566 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v98, \"id\", &v78 @ stack_-60_v6 (System.Object));\n\tv661 = v576.profile;\n\tv579 = v566 == 0;\n\tif (v579) goto L_00E0;\n\tv615 = v576.profile == 0;\n\tif (v615) goto L_010D;\n\tv625 = v78 == 0;\n\tif (v625) goto L_FFFFFFFF;\n\tv691 = *([v78 @ stack_-60_v6 (System.Object)]) != System.String;\n\tif (v691) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00EF;\nL_00E0:\n\tv616 = v576.profile == 0;\n\tif (v616) goto L_010D;\n\tv670 = \"no-catalog-id-present\" == 0;\n\tv658 = ~v670;\n\tif (v658) goto L_0106;\n\tgoto L_010D;\nL_00EF:\n\tv419 = System.String::op_Equality(v425, \"\");\n\tv407 = v419 == 0;\n\tv661 = v747.profile;\n\tv397 = ~v407;\n\tv391 = ~v397;\n\tif (v391) goto L_FFFFFFFF;\n\tgoto L_0102;\nL_0102:\n\tv421 = v661 == 0;\n\tif (v421) goto L_0146;\n\tv659 = v648 == 0;\n\tif (v659) goto L_010D;\nL_0106:\n\tv661.<CatalogId>k__BackingField = v648;\nL_010D:\n\tv667 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v98, \"products\", &v71 @ stack_-68_v6 (System.Object));\n\tv164 = v71 == 0;\n\tif (v164) goto L_0132;\n\tgoto L_FFFFFFFF;\n\tv438 = v438_asT == 0;\n\tif (v438) goto L_0142;\nL_0132:\n\treturnVal1 = UnityEngine.Purchasing.ProductDefinitionExtensions::DecodeJSON(v71, storeName);\nL_013D:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0141:\n\tv390 = new System.InvalidCastException();\nL_0142:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_0146:\n\tv427 = new System.NullReferenceException();\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\nL_015C:\n\tv209 = \"\" != 1;\n\tif (v209) goto L_01BF;\n\tv473 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v427, \"\", 0);\n\tv479 = v473.m_value;\n\tv507 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v479.m_value, 0, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv539 = v507 & 1;\n\tv478 = v539 == 0;\n\tif (v478) goto L_01B5;\n\tv553 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v507, v479.m_value, v202);\n\tv567 = logger == 0;\n\tif (v567) goto L_FFFFFFFF;\n\tv586 = ~v479;\n\tif (v586) goto L_FFFFFFFF;\n\tv617 = v479.m_value;\n\t*([v617 @ X8_v22 (System.Boolean)+160])(v621, v479, *([v617 @ X8_v22 (System.Boolean)+168]), v202, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_017F;\nL_017F:\n\tv677 = System.String::Concat(\"Error parsing catalog, exception \", v672);\n\tv694 = logger->klass;\n\tv606 = *([v694 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v606) goto L_01A5;\n\tv754 = *([v694 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0190:\n\tv769 = *([v754 @ X11_v8-8]) == UnityEngine.ILogger;\n\tif (v769) goto L_01A8;\n\tv764 = v764 + 1;\n\tv776 = v764 < *([v694 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv738 = ~v776;\n\tv754 = v754 + 0x10;\n\tv722 = ~v738;\n\tif (v722) goto L_0190;\nL_01A5:\n\tv783 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(logger, UnityEngine.ILogger, 6);\n\tgoto L_01B1;\nL_01A8:\n\tv778 = *([v754 @ X11_v8]) + 6;\n\tv779 = v778 << 4;\n\tv780 = v694 + v779;\n\tv783 = v780 + 0x130;\nL_01B1:\n\tv783.m_value(v605, logger, \"UnityIAP\", v677, *([v783 @ X0_v31 (System.Boolean)+8]), v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_013D;\nL_01B5:\n\tv555 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(8, v479.m_value, 0);\n\tv555.m_value = v473.m_value;\n\tv231 = 0x1E8A000 + 0x870;\n\tv569 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v555, v231, 0);\n\tv477 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v569, v231, 0);\nL_01BF:\n\tv483 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v239, v231, v202);\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v483, v231, v202);\n\treturn returnVal2;\n// 309 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static List<ProductDefinition> ParseProductsFromJSON(string json, string storeName, ILogger logger)
		{
			//IL_00eb: Expected O, but got I4
			//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cb: Expected I4, but got Unknown
			//IL_0571: Expected O, but got I4
			//IL_0575: Expected O, but got I4
			//IL_04eb: Expected O, but got I4
			//IL_04eb: Expected O, but got I4
			//IL_0510: Expected O, but got I4
			//IL_051e: Expected O, but got I4
			//IL_0535: Expected O, but got I4
			//IL_0546: Expected O, but got I4
			//IL_0394: Expected O, but got I4
			//IL_0677: Expected I, but got O
			//IL_0412: Expected O, but got I
			//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Expected O, but got Unknown
			//IL_04c3: Expected O, but got I
			//IL_045e: Expected O, but got I
			bool flag = string.IsNullOrEmpty(json);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			List<ProductDefinition> result = null;
			if (flag3)
			{
				goto IL_02c8;
			}
			HashSet<ProductDefinition> hashSet = new HashSet<ProductDefinition>();
			object obj = MiniJson.JsonDecode(json);
			Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
			object value;
			ProfileData profileData2;
			string text2;
			bool flag15;
			if (dictionary != null)
			{
				bool flag4 = ((Dictionary<string, object>)obj).TryGetValue("catalog", out value);
				if (((Dictionary<string, object>)obj).TryGetValue("abGroup", out object value2))
				{
					ProfileData profileData = profile;
					if (profile != null)
					{
						int num = Convert.ToInt32(value2);
						int? num2 = default(int?);
						bool flag5 = ((Dictionary<string, object>)num2).TryGetValue((string)num, out *(object*)null);
						if ((int)((_003F?)num2 & 0xFF00000000L) != 0)
						{
							profileData.StoreABGroup = num2;
						}
					}
				}
				Dictionary<string, object> dictionary2 = value as Dictionary<string, object>;
				bool flag6 = ((Dictionary<string, object>)value).TryGetValue("id", out object value3);
				profileData2 = profile;
				if (flag6)
				{
					if (profile != null)
					{
						string text;
						if (value3 != null)
						{
							object obj2 = (((object)value3.GetType() != typeof(string)) ? null : value3);
							text = (string)obj2;
						}
						else
						{
							text = null;
						}
						bool flag7 = text == "";
						bool flag8 = !flag7;
						profileData2 = profile;
						text2 = (flag8 ? text : "empty-catalog-id");
						bool flag9 = profileData2 == null;
						ILogger logger2 = null;
						string key = "";
						if (flag9)
						{
							NullReferenceException ex = new NullReferenceException();
							bool flag10 = (IntPtr)"" != (IntPtr)1;
							NullReferenceException ex2 = ex;
							if (!flag10)
							{
								bool flag11 = ((Dictionary<string, object>)(object)ex).TryGetValue("", out *(object*)null);
								bool value4 = ((bool*)(flag11 ? 1 : 0))->m_value;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj3 = default(object);
								if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
								{
									bool flag12 = ((Dictionary<string, object>)obj3).TryGetValue((string)((bool*)(value4 ? 1 : 0))->m_value, out *(object*)logger2);
									if (logger == null)
									{
										goto IL_0653;
									}
									string text3;
									if (value4)
									{
										bool value5 = ((bool*)(value4 ? 1 : 0))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v617 @ X8_v22 (System.Boolean)+160] (should have been resolved before IL gen)");
										string text4 = default(string);
										text3 = text4;
									}
									else
									{
										text3 = null;
									}
									string text5 = "Error parsing catalog, exception " + text3;
									IntPtr intPtr = (IntPtr)logger;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+126]");
									if ((IntPtr)0 == (IntPtr)0)
									{
										goto IL_0477;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+B0]");
									object obj4 = 0L + 8L;
									int num3 = 0;
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ X11_v8-8]");
										if ((IntPtr)0 == (IntPtr)typeof(ILogger))
										{
											break;
										}
										num3++;
										int num4 = num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X8_v18 (Il2CppClass<UnityEngine.ILogger>)+126]");
										bool flag13 = (long)num4 < 0L;
										bool flag14 = !flag13;
										obj4 = (long)(IntPtr)obj4 + 16L;
										if (!flag14)
										{
											continue;
										}
										goto IL_0477;
									}
									object obj5 = obj4 + 6;
									int num5 = (int)((long)(IntPtr)obj5 << 4);
									object obj6 = (long)intPtr + (long)num5;
									flag15 = (byte)((ulong)(long)(IntPtr)obj6 + 304uL) != 0;
									goto IL_06c6;
								}
								bool flag16 = ((Dictionary<string, object>)8).TryGetValue((string)((bool*)(value4 ? 1 : 0))->m_value, out *(object*)null);
								((bool*)(flag16 ? 1 : 0))->m_value = ((bool*)(flag11 ? 1 : 0))->m_value;
								key = (string)(32022528 + 2160);
								bool flag17 = ((Dictionary<string, object>)flag16).TryGetValue(key, out *(object*)null);
								bool flag18 = ((Dictionary<string, object>)flag17).TryGetValue(key, out *(object*)null);
								logger2 = null;
								ex2 = (NullReferenceException)flag17;
							}
							bool flag19 = ((Dictionary<string, object>)(object)ex2).TryGetValue(key, out *(object*)logger2);
							return (List<ProductDefinition>)((Dictionary<string, object>)flag19).TryGetValue(key, out *(object*)logger2);
						}
						if (text2 != null)
						{
							goto IL_0271;
						}
					}
				}
				else if (profile != null)
				{
					bool flag20 = "no-catalog-id-present" == null;
					bool flag21 = !flag20;
					text2 = "no-catalog-id-present";
					if (flag21)
					{
						goto IL_0271;
					}
				}
				goto IL_05e8;
			}
			InvalidCastException ex3 = new InvalidCastException();
			goto IL_02e1;
			IL_06c6:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v783.m_value (System.Boolean) (should have been resolved before IL gen)");
			goto IL_0653;
			IL_0653:
			result = null;
			goto IL_02c8;
			IL_02e1:
			throw new InvalidCastException();
			IL_0477:
			flag15 = ((Dictionary<string, object>)logger).TryGetValue((string)(object)typeof(ILogger), out *(object*)6);
			goto IL_06c6;
			IL_0271:
			profileData2.CatalogId = text2;
			goto IL_05e8;
			IL_05e8:
			bool flag22 = ((Dictionary<string, object>)value).TryGetValue("products", out object value6);
			if (value6 != null)
			{
				List<object> list = value6 as List<object>;
				if (list == null)
				{
					goto IL_02e1;
				}
			}
			result = ((List<object>)value6).DecodeJSON(storeName);
			goto IL_02c8;
			IL_02c8:
			return result;
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0xC711BC", Offset = "0xC711BC", Length = "0x11F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EEADD0]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20233D5]) = v43;\nL_0017:\n\tv45 = this.m_cachedStoreCatalogReference == 0;\n\tif (v45) goto L_002C;\n\tv46 = UnityEngine.Purchasing.FileReference::Load(this.m_cachedStoreCatalogReference);\n\tv51 = UnityEngine.Purchasing.StoreCatalogImpl::ParseProductsFromJSON(v46, this.m_StoreName, this.m_Logger);\n\tv151 = v51 == 0;\n\tif (v151) goto L_FFFFFFFF;\n\tv187 = v51._size == 0;\n\tgoto L_0059;\nL_002C:\n\tv47 = this.m_Logger;\n\tv48 = this.m_Logger == 0;\n\tif (v48) goto L_00D3;\n\tv53 = *([v47 @ X20_v5 (UnityEngine.ILogger)]);\n\tv60 = *([v53 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v60) goto L_0056;\n\tv196 = *([v53 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0041:\n\tv210 = *([v196 @ X11_v7-8]) == UnityEngine.ILogger;\n\tif (v210) goto L_00C5;\n\tv197 = v197 + 1;\n\tv215 = v197 < *([v53 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv178 = ~v215;\n\tv196 = v196 + 0x10;\n\tv158 = ~v178;\n\tif (v158) goto L_0041;\nL_0056:\n\tv222 = 0x8909C4(this.m_Logger, UnityEngine.ILogger, 4, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00CA;\nL_0059:\n\tv141 = this.m_Logger;\n\tv138 = this.m_Logger == 0;\n\tif (v138) goto L_00D3;\n\tv279 = v144 == 0;\n\tif (v279) goto L_0085;\n\tv407 = *([v141 @ X21_v6 (UnityEngine.ILogger)]);\n\tv293 = *([v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v293) goto L_00A8;\n\tv395 = *([v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0070:\n\tv365 = *([v395 @ X11_v10-8]) == UnityEngine.ILogger;\n\tif (v365) goto L_00AB;\n\tv352 = v352 + 1;\n\tv391 = v352 < *([v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv340 = ~v391;\n\tv395 = v395 + 0x10;\n\tv309 = ~v340;\n\tif (v309) goto L_0070;\n\tgoto L_00A8;\nL_0085:\n\tv407 = *([v141 @ X21_v6 (UnityEngine.ILogger)]);\n\tv299 = *([v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v299) goto L_00A8;\n\tv395 = *([v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0093:\n\tv386 = *([v395 @ X11_v10-8]) == UnityEngine.ILogger;\n\tif (v386) goto L_00AB;\n\tv373 = v373 + 1;\n\tv418 = v373 < *([v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv339 = ~v418;\n\tv395 = v395 + 0x10;\n\tv308 = ~v339;\n\tif (v308) goto L_0093;\nL_00A8:\n\tv414 = 0x8909C4(this.m_Logger, UnityEngine.ILogger, 4, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00B0;\nL_00AB:\n\tv409 = *([v395 @ X11_v10]) + 4;\n\tv410 = v409 << 4;\n\tv411 = v407 + v410;\n\tv414 = v411 + 0x130;\nL_00B0:\n\t;\n\t*([v414 @ X0_v16])(v135, this.m_Logger, v70, *([v414 @ X0_v16+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv139 = callback == 0;\n\tif (v139) goto L_00D3;\nL_00C2:\n\tSystem.Action`1<System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>>::Invoke(callback, v286);\n\treturn;\nL_00C5:\n\tv217 = *([v196 @ X11_v7]) + 4;\n\tv218 = v217 << 4;\n\tv219 = v53 + v218;\n\tv222 = v219 + 0x130;\nL_00CA:\n\t;\n\t*([v222 @ X0_v8])(v134, this.m_Logger, \"Using registered configuration builder objects\", *([v222 @ X0_v8+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv225 = callback == 0;\n\tv137 = ~v225;\n\tif (v137) goto L_00C2;\nL_00D3:\n\tv150 = new System.NullReferenceException();\n\tSystem.Runtime.Serialization.Formatters.Binary.ObjectReader+TopLevelAssemblyTypeResolver::.ctor(v150, v130);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xC59008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX8 = *([X8+188]);\n\tX0 = 0xC67008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void handleCachedCatalog(Action<List<ProductDefinition>> callback)
		{
			//IL_00a9: Expected I, but got O
			//IL_0166: Expected O, but got I4
			//IL_00e4: Expected O, but got I
			//IL_006b: Expected O, but got I4
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Expected O, but got Unknown
			//IL_038d: Expected O, but got I
			//IL_039c: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_024f: Expected I, but got O
			//IL_0190: Expected I, but got O
			//IL_0293: Expected O, but got I
			//IL_01d4: Expected O, but got I
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Expected O, but got Unknown
			//IL_0340: Expected O, but got I
			//IL_034f: Expected O, but got I
			//IL_02df: Expected O, but got I
			//IL_0220: Expected O, but got I
			List<ProductDefinition> list;
			Assembly topLevelAssembly;
			string text;
			if (m_cachedStoreCatalogReference != null)
			{
				string json = m_cachedStoreCatalogReference.Load();
				list = ParseProductsFromJSON(json, m_StoreName, m_Logger);
				object obj;
				if (list != null)
				{
					bool flag = list.Count == 0;
					obj = flag;
				}
				else
				{
					obj = 1;
				}
				ILogger logger = m_Logger;
				bool flag2 = m_Logger == null;
				topLevelAssembly = (Assembly)(object)m_StoreName;
				if (!flag2)
				{
					IntPtr intPtr;
					object obj2;
					if (obj != null)
					{
						intPtr = (IntPtr)logger;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag3 = (IntPtr)0 == (IntPtr)0;
						text = "Using configuration builder objects";
						if (flag3)
						{
							goto IL_0301;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+B0]");
						obj2 = 0L + 8L;
						int num = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X11_v10-8]");
							bool flag4 = (IntPtr)0 == (IntPtr)typeof(ILogger);
							text = "Using configuration builder objects";
							if (flag4)
							{
								break;
							}
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]");
							bool flag5 = (long)num2 < 0L;
							bool flag6 = !flag5;
							obj2 = (long)(IntPtr)obj2 + 16L;
							if (!flag6)
							{
								continue;
							}
							goto IL_0239;
						}
					}
					else
					{
						intPtr = (IntPtr)logger;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag7 = (IntPtr)0 == (IntPtr)0;
						text = "Using cached IAP catalog";
						if (flag7)
						{
							goto IL_0301;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+B0]");
						obj2 = 0L + 8L;
						int num3 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X11_v10-8]");
							bool flag8 = (IntPtr)0 == (IntPtr)typeof(ILogger);
							text = "Using cached IAP catalog";
							if (flag8)
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v14 (Il2CppClass<UnityEngine.ILogger>)+126]");
							bool flag9 = (long)num4 < 0L;
							bool flag10 = !flag9;
							obj2 = (long)(IntPtr)obj2 + 16L;
							bool flag11 = !flag10;
							text = "Using cached IAP catalog";
							if (flag11)
							{
								continue;
							}
							goto IL_0301;
						}
					}
					object obj3 = obj2 + 4;
					int num5 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num5;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					goto IL_04d9;
				}
			}
			else
			{
				ILogger logger2 = m_Logger;
				bool flag12 = m_Logger == null;
				topLevelAssembly = (Assembly)(object)callback;
				if (!flag12)
				{
					IntPtr intPtr2 = (IntPtr)logger2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0149;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					object obj6 = 0L + 8L;
					int num6 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X11_v7-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILogger))
						{
							break;
						}
						num6++;
						int num7 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag13 = (long)num7 < 0L;
						bool flag14 = !flag13;
						obj6 = (long)(IntPtr)obj6 + 16L;
						if (!flag14)
						{
							continue;
						}
						goto IL_0149;
					}
					object obj7 = obj6 + 4;
					int num8 = (int)((long)(IntPtr)obj7 << 4);
					object obj8 = (long)intPtr2 + (long)num8;
					object obj9 = (long)(IntPtr)obj8 + 304L;
					goto IL_0432;
				}
			}
			goto IL_03a1;
			IL_0432:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v222 @ X0_v8] (should have been resolved before IL gen)");
			bool flag15 = callback == null;
			bool flag16 = !flag15;
			List<ProductDefinition> obj10 = null;
			topLevelAssembly = (Assembly)(object)"Using registered configuration builder objects";
			if (flag16)
			{
				goto IL_0354;
			}
			goto IL_03a1;
			IL_03a1:
			NullReferenceException ex = (NullReferenceException)(object)new System.Runtime.Serialization.Formatters.Binary.ObjectReader.TopLevelAssemblyTypeResolver(topLevelAssembly);
			return;
			IL_04d9:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v414 @ X0_v16] (should have been resolved before IL gen)");
			bool flag17 = callback == null;
			obj10 = list;
			topLevelAssembly = (Assembly)(object)text;
			if (!flag17)
			{
				goto IL_0354;
			}
			goto IL_03a1;
			IL_0239:
			text = "Using configuration builder objects";
			goto IL_0301;
			IL_0301:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_04d9;
			IL_0354:
			callback(obj10);
			return;
			IL_0149:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0432;
		}
	}
}

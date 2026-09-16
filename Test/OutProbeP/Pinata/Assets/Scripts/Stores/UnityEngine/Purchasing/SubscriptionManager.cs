using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Security;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000075")]
	public class SubscriptionManager
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000076")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40001CA")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40001CB")]
			public static Comparison<AppleInAppPurchaseReceipt> _003C_003E9__11_0;

			[Token(Token = "0x6000204")]
			[Address(RVA = "0x15B0BD0", Offset = "0x15B0BD0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F05888]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20298B9]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.SubscriptionManager+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000205")]
			[Address(RVA = "0x15B0C34", Offset = "0x15B0C34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal int _003CfindMostRecentReceipt_003Eb__11_0(AppleInAppPurchaseReceipt b, AppleInAppPurchaseReceipt a)
			{
				DateTime purchaseDate = a.purchaseDate;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
				int result = default(int);
				return result;
			}
		}

		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x10")]
		private string receipt;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x18")]
		private string productId;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x20")]
		private string intro_json;

		[Token(Token = "0x60001FE")]
		[Address(RVA = "0x15AFE14", Offset = "0x15AFE14", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.receipt = product.<receipt>k__BackingField;\n\tv21 = product.<definition>k__BackingField;\n\tthis.productId = v21.<storeSpecificId>k__BackingField;\n\tthis.intro_json = intro_json;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SubscriptionManager(Product product, string intro_json)
		{
			receipt = product.receipt;
			ProductDefinition definition = product.definition;
			productId = definition.storeSpecificId;
			this.intro_json = intro_json;
		}

		[Token(Token = "0x60001FF")]
		[Address(RVA = "0x15AFE6C", Offset = "0x15AFE6C", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EDCB40]);\n\tv21 = *([v20 @ X8_v46]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20298B4]) = v40;\nL_0017:\n\tv44 = this.receipt == 0;\n\tif (v44) goto L_00BC;\n\tv46 = UnityEngine.Purchasing.MiniJson::JsonDecode(this.receipt);\n\tgoto L_FFFFFFFF;\n\tv63 = v63_asT == 0;\n\tif (v63) goto L_00B8;\n\tv271 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v46, \"Payload\", &v52 @ stack_-28_v8 (System.Object));\n\tv108 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v46, \"Store\", &v48 @ stack_-38_v8 (System.Object));\n\tv111 = v271 == 0;\n\tif (v111) goto L_00BC;\n\tv112 = v108 == 0;\n\tif (v112) goto L_00BC;\n\tv336 = v52 == 0;\n\tif (v336) goto L_FFFFFFFF;\n\tv361 = *([v52 @ stack_-28_v8 (System.Object)]) != System.String;\n\tif (v361) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006E;\nL_006E:\n\tv256 = v48 == 0;\n\tif (v256) goto L_00CD;\n\tv232 = *([v48 @ stack_-38_v8 (System.Object)]) != System.String;\n\tif (v232) goto L_FFFFFFFF;\n\tv374 = System.String::op_Equality(v48, \"GooglePlay\");\n\tv376 = v374 == 0;\n\tif (v376) goto L_0090;\n\treturnVal1 = UnityEngine.Purchasing.SubscriptionManager::getGooglePlayStoreSubInfo(v374, v229);\n\tgoto L_00B6;\nL_0090:\n\tv384 = System.String::op_Equality(v48, \"AppleAppStore\");\n\tv386 = v384 == 0;\n\tv387 = ~v386;\n\tif (v387) goto L_009F;\n\tv407 = System.String::op_Equality(v48, \"MacAppStore\");\n\tv410 = v407 == 0;\n\tif (v410) goto L_00AA;\nL_009F:\n\tv342 = this.productId == 0;\n\tif (v342) goto L_00E1;\n\treturnVal1 = UnityEngine.Purchasing.SubscriptionManager::getAppleAppStoreSubInfo(this, v229, this.productId);\n\tgoto L_00B6;\nL_00AA:\n\tv303 = System.String::op_Equality(v48, \"AmazonApps\");\n\tv305 = v303 == 0;\n\tif (v305) goto L_00CD;\n\treturnVal1 = UnityEngine.Purchasing.SubscriptionManager::getAmazonAppStoreSubInfo(v303, this.productId);\nL_00B6:\n\treturn returnVal1;\nL_00B8:\n\tthrow System.InvalidCastException;\nL_00BC:\n\tv121 = new UnityEngine.Purchasing.NullReceiptException();\n\tUnityEngine.Purchasing.NullReceiptException::.ctor(v121);\nL_00C5:\n\tv177 = new System.TypeLoadException();\n\tthrow System.NullReferenceException;\nL_00CD:\n\tv316 = System.String::Concat(\"Store not supported: \", v310);\n\tv324 = new UnityEngine.Purchasing.StoreSubscriptionInfoNotSupportedException();\n\tUnityEngine.Purchasing.ReceiptParserException::.ctor(v324, v316);\n\tthrow v324;\nL_00E1:\n\tv209 = new UnityEngine.Purchasing.NullProductIdException();\n\tUnityEngine.Purchasing.NullProductIdException::.ctor(v209);\n\tgoto L_00C5;\n\treturn X0;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SubscriptionInfo getSubscriptionInfo()
		{
			//IL_0181: Expected O, but got I4
			//IL_0271: Expected O, but got I4
			if (receipt != null)
			{
				object obj = MiniJson.JsonDecode(receipt);
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				if (dictionary == null)
				{
					throw new InvalidCastException();
				}
				bool flag = ((Dictionary<string, object>)obj).TryGetValue("Payload", out object value);
				bool flag2 = ((Dictionary<string, object>)obj).TryGetValue("Store", out object value2);
				if (flag && flag2)
				{
					string payload;
					if (value != null)
					{
						object obj2 = (((object)value.GetType() != typeof(string)) ? null : value);
						payload = (string)obj2;
					}
					else
					{
						payload = null;
					}
					bool flag3 = value2 == null;
					string text = (string)value2;
					if (!flag3)
					{
						if ((object)value2.GetType() == typeof(string))
						{
							bool flag4 = (string)value2 == "GooglePlay";
							if (flag4)
							{
								return ((SubscriptionManager)flag4).getGooglePlayStoreSubInfo(payload);
							}
							if ((string)value2 == "AppleAppStore" || (string)value2 == "MacAppStore")
							{
								if (productId != null)
								{
									return getAppleAppStoreSubInfo(payload, productId);
								}
								NullProductIdException ex = new NullProductIdException();
								goto IL_0294;
							}
							bool flag5 = (string)value2 == "AmazonApps";
							bool flag6 = !flag5;
							text = (string)value2;
							if (!flag6)
							{
								return ((SubscriptionManager)flag5).getAmazonAppStoreSubInfo(productId);
							}
						}
						else
						{
							text = null;
						}
					}
					string message = "Store not supported: " + text;
					ReceiptParserException ex2 = new ReceiptParserException(message);
					throw ex2;
				}
			}
			NullReceiptException ex3 = new NullReceiptException();
			goto IL_0294;
			IL_0294:
			TypeLoadException ex4 = new TypeLoadException();
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000200")]
		[Address(RVA = "0x15B0A5C", Offset = "0x15B0A5C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F07CB0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, productId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298B5]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Purchasing.SubscriptionInfo();\n\tUnityEngine.Purchasing.SubscriptionInfo::.ctor(v42, productId);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private SubscriptionInfo getAmazonAppStoreSubInfo(string productId)
		{
			return new SubscriptionInfo(productId);
		}

		[Token(Token = "0x6000201")]
		[Address(RVA = "0x15B061C", Offset = "0x15B061C", Length = "0x440")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EB7C80]);\n\tv33 = *([v32 @ X8_v60]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, payload, productId, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20298B6]) = v50;\nL_001D:\n\tv54 = new UnityEngine.Purchasing.Security.AppleReceiptParser();\n\tUnityEngine.Purchasing.Security.AppleReceiptParser::.ctor(v54);\n\tgoto L_0030;\n\tv64 = *([v60 @ X0_v5+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0030;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, v57, productId, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0030:\n\tv73 = System.Convert::FromBase64String(payload);\n\tv75 = v54 == 0;\n\tif (v75) goto L_00AB;\n\tv78 = UnityEngine.Purchasing.Security.AppleReceiptParser::Parse(v54, v73);\nL_003B:\n\tv194 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::.ctor(v194);\n\tv229 = v189 == 0;\n\tif (v229) goto L_0087;\n\tv237 = v189.inAppPurchaseReceipts;\n\tv238 = v189.inAppPurchaseReceipts == 0;\n\tif (v238) goto L_0087;\n\tv391 = v237.Length;\n\tv281 = v237.Length == 0;\n\tif (v281) goto L_0087;\n\tv247 = v237.Length < 1;\n\tif (v247) goto L_0087;\nL_0058:\n\tv441 = v294 < v391;\n\tv313 = ~v441;\n\tif (v313) goto L_00A6;\n\tv286 = v237[v294 @ X24_v7 (System.Int32)];\n\tv323 = System.String::Equals(v286.<productID>k__BackingField, v129);\n\tv678 = v323 == 0;\n\tif (v678) goto L_0076;\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::Add(v194, v237[v294 @ X24_v7 (System.Int32)]);\nL_0076:\n\tv391 = v237.Length;\n\tv294 = v294 + 1;\n\tv246 = v294 < v237.Length;\n\tif (v246) goto L_0058;\nL_0087:\n\tv291 = v194._size == 0;\n\tif (v291) goto L_FFFFFFFF;\n\tv384 = UnityEngine.Purchasing.SubscriptionManager::findMostRecentReceipt(v277, v194);\n\tv410 = new UnityEngine.Purchasing.SubscriptionInfo();\n\tUnityEngine.Purchasing.SubscriptionInfo::.ctor(v410, v384, this.intro_json);\n\tgoto L_00A3;\nL_00A3:\n\treturn v414;\n\tv331 = new System.NullReferenceException();\nL_00A6:\n\tv393 = new System.IndexOutOfRangeException();\n\tthrow v393;\nL_00AB:\n\tv144 = new System.NullReferenceException();\n\tgoto L_00B9;\n\tgoto L_00B9;\n\tgoto L_00B9;\nL_00B9:\n\tv205 = v73 != 1;\n\tif (v205) goto L_019D;\n\tv210 = 0x6D2BC0(v144, v73, v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv186 = *([v210 @ X0_v44]);\n\tv235 = \"il2cpp_vm_class_is_assignable_from\"(System.ArgumentException, *([v186 @ X21_v7 (Il2CppMethodInfo)]), v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv288 = v235 & 1;\n\tv289 = v288 == 0;\n\tif (v289) goto L_0100;\n\tv332 = 0x6D2490(v235, *([v186 @ X21_v7 (Il2CppMethodInfo)]), v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00D5;\n\tv418 = *([v396 @ X0_v71+E0]);\n\tv419 = v418 == 0;\n\tv420 = ~v419;\n\tif (v420) goto L_00D5;\n\tv422 = \"il2cpp_codegen_runtime_class_init\"(v396, v233, v129, v79, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00D5:\n\tv426 = UnityEngine.Debug::get_unityLogger();\n\tv452 = *([v426 @ X0_v74 (UnityEngine.ILogger)]);\n\tv459 = *([v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v459) goto L_0183;\n\tv582 = *([v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_00EB:\n\tv614 = *([v582 @ X11_v17-8]) == UnityEngine.ILogger;\n\tif (v614) goto L_0186;\n\tv586 = v586 + 1;\n\tv679 = v586 < *([v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv560 = ~v679;\n\tv582 = v582 + 0x10;\n\tv528 = ~v560;\n\tif (v528) goto L_00EB;\n\tgoto L_0183;\nL_0100:\n\tv334 = *([v210 @ X0_v44]);\n\tv338 = \"il2cpp_vm_class_is_assignable_from\"(UnityEngine.Purchasing.Security.IAPSecurityException, *([v334 @ X8_v36]), v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv400 = v338 & 1;\n\tv401 = v400 == 0;\n\tif (v401) goto L_0141;\n\tv427 = 0x6D2490(v338, *([v334 @ X8_v36]), v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0116;\n\tv496 = *([v446 @ X0_v65+E0]);\n\tv497 = v496 == 0;\n\tv498 = ~v497;\n\tif (v498) goto L_0116;\n\tv500 = \"il2cpp_codegen_runtime_class_init\"(v446, v336, v129, v79, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0116:\n\tv482 = UnityEngine.Debug::get_unityLogger();\n\tv635 = *([v482 @ X0_v68 (UnityEngine.ILogger)]);\n\tv571 = *([v635 @ X8_v28 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v571) goto L_0183;\n\tv583 = *([v635 @ X8_v28 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_012C:\n\tv615 = *([v583 @ X11_v13-8]) == UnityEngine.ILogger;\n\tif (v615) goto L_0186;\n\tv587 = v587 + 1;\n\tv701 = v587 < *([v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv561 = ~v701;\n\tv583 = v583 + 0x10;\n\tv529 = ~v561;\n\tif (v529) goto L_012C;\n\tgoto L_0183;\nL_0141:\n\tv429 = *([v210 @ X0_v44]);\n\tv432 = \"il2cpp_vm_class_is_assignable_from\"(System.NullReferenceException, *([v429 @ X8_v37]), v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv450 = v432 & 1;\n\tv220 = v450 == 0;\n\tif (v220) goto L_0193;\n\tv503 = 0x6D2490(v432, *([v429 @ X8_v37]), v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0157;\n\tv670 = *([v644 @ X0_v59+E0]);\n\tv671 = v670 == 0;\n\tv672 = ~v671;\n\tif (v672) goto L_0157;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v644, v430, v129, v79, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0157:\n\tv483 = UnityEngine.Debug::get_unityLogger();\n\tv573 = *([v483 @ X0_v62 (UnityEngine.ILogger)]);\n\tv570 = *([v573 @ X8_v43 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v570) goto L_0183;\n\tv584 = *([v573 @ X8_v43 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_016D:\n\tv616 = *([v584 @ X11_v9-8]) == UnityEngine.ILogger;\n\tif (v616) goto L_0186;\n\tv588 = v588 + 1;\n\tv715 = v588 < *([v573 @ X8_v43 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv559 = ~v715;\n\tv584 = v584 + 0x10;\n\tv527 = ~v559;\n\tif (v527) goto L_016D;\nL_0183:\n\tgoto L_018F;\n\tthrow System.NullReferenceException;\nL_0186:\n\t;\nL_018F:\n\tv182 = UnityEngine.ILogger::Log(v665, v176, v186);\n\tgoto L_003B;\nL_0193:\n\tv505 = 0x6D1E60(8, *([v429 @ X8_v37]), v129, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([v505 @ X0_v55]) = *([v210 @ X0_v44]);\n\tv215 = 0x1E8A000 + 0x870;\n\tv649 = 0x6D2A00(v505, v215, 0, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv218 = 0x6D2490(v649, v215, 0, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_019D:\n\tv228 = 0x6D2380(v221, v215, v213, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturnVal1 = 0x846AA4(v228, v215, v213, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal1;\n// 267 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private SubscriptionInfo getAppleAppStoreSubInfo(string payload, string productId)
		{
			//IL_026f: Expected I, but got O
			//IL_064f: Expected O, but got I4
			//IL_02d9: Expected I, but got O
			//IL_040d: Expected I, but got O
			//IL_0541: Expected I, but got O
			//IL_07b2: Expected O, but got I
			//IL_0325: Expected O, but got I
			//IL_0459: Expected O, but got I
			//IL_058d: Expected O, but got I
			//IL_0371: Expected O, but got I
			//IL_04a5: Expected O, but got I
			//IL_0137: Expected O, but got I4
			//IL_05d9: Expected O, but got I
			AppleReceiptParser appleReceiptParser = new AppleReceiptParser();
			byte[] array = Convert.FromBase64String(payload);
			bool flag = appleReceiptParser == null;
			byte[] array2 = array;
			AppleReceipt appleReceipt2;
			if (!flag)
			{
				AppleReceipt appleReceipt = appleReceiptParser.Parse(array);
				appleReceipt2 = appleReceipt;
				goto IL_07bd;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag2 = (IntPtr)array != (IntPtr)1;
			string text2 = default(string);
			string text = text2;
			NullReferenceException ex2 = ex;
			if (flag2)
			{
				goto IL_0684;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj = default(object);
			IntPtr intPtr = (IntPtr)obj;
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
			object obj2 = default(object);
			string tag;
			ILogger logger;
			string text3 = default(string);
			IntPtr intPtr4 = default(IntPtr);
			ILogger logger2 = default(ILogger);
			ILogger unityLogger = default(ILogger);
			ILogger unityLogger2 = default(ILogger);
			if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				unityLogger = Debug.unityLogger;
				IntPtr intPtr2 = (IntPtr)unityLogger;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag3 = (IntPtr)0 == (IntPtr)0;
				tag = "Unable to parse Apple receipt";
				logger = unityLogger;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					object obj3 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ X11_v17-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILogger))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag4 = (long)num2 < 0L;
						bool flag5 = !flag4;
						obj3 = (long)(IntPtr)obj3 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_038a;
					}
					goto IL_0608;
				}
			}
			else
			{
				object obj4 = obj;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj5 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					unityLogger2 = Debug.unityLogger;
					IntPtr intPtr3 = (IntPtr)unityLogger2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ X8_v28 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag6 = (IntPtr)0 == (IntPtr)0;
					tag = "Unable to parse Apple receipt";
					logger = unityLogger2;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ X8_v28 (Il2CppClass<UnityEngine.ILogger>)+B0]");
						object obj6 = 0L + 8L;
						int num3 = 0;
						IntPtr intPtr2 = default(IntPtr);
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X11_v13-8]");
							bool flag7 = (IntPtr)0 == (IntPtr)typeof(ILogger);
							text3 = "Unable to parse Apple receipt";
							intPtr4 = intPtr;
							intPtr3 = intPtr2;
							logger2 = unityLogger;
							if (flag7)
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ X8_v55 (Il2CppClass<UnityEngine.ILogger>)+126]");
							bool flag8 = (long)num4 < 0L;
							bool flag9 = !flag8;
							obj6 = (long)(IntPtr)obj6 + 16L;
							if (!flag9)
							{
								continue;
							}
							goto IL_04be;
						}
						goto IL_0608;
					}
				}
				else
				{
					object obj7 = obj;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj8 = default(object);
					if ((int)((long)(IntPtr)obj8 & 1L) == 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj9 = obj;
						array2 = (byte[])(32022528 + 2160);
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						text = null;
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
						goto IL_0684;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					ILogger unityLogger3 = Debug.unityLogger;
					IntPtr intPtr5 = (IntPtr)unityLogger3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ X8_v43 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag10 = (IntPtr)0 == (IntPtr)0;
					tag = "Unable to parse Apple receipt";
					logger = unityLogger3;
					if (!flag10)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ X8_v43 (Il2CppClass<UnityEngine.ILogger>)+B0]");
						object obj10 = 0L + 8L;
						int num5 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ X11_v9-8]");
							bool flag11 = (IntPtr)0 == (IntPtr)typeof(ILogger);
							text3 = "Unable to parse Apple receipt";
							intPtr4 = intPtr;
							logger2 = unityLogger2;
							if (flag11)
							{
								break;
							}
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ X8_v43 (Il2CppClass<UnityEngine.ILogger>)+126]");
							bool flag12 = (long)num6 < 0L;
							bool flag13 = !flag12;
							obj10 = (long)(IntPtr)obj10 + 16L;
							bool flag14 = !flag13;
							tag = "Unable to parse Apple receipt";
							logger = unityLogger3;
							if (flag14)
							{
								continue;
							}
							goto IL_07a1;
						}
						goto IL_0608;
					}
				}
			}
			goto IL_07a1;
			IL_07a1:
			logger.Log(tag, (long)intPtr);
			appleReceipt2 = null;
			goto IL_07bd;
			IL_038a:
			tag = "Unable to parse Apple receipt";
			logger = unityLogger;
			goto IL_07a1;
			IL_07bd:
			List<AppleInAppPurchaseReceipt> list = new List<AppleInAppPurchaseReceipt>();
			bool flag15 = appleReceipt2 == null;
			SubscriptionManager subscriptionManager = (SubscriptionManager)(object)list;
			if (!flag15)
			{
				AppleInAppPurchaseReceipt[] inAppPurchaseReceipts = appleReceipt2.inAppPurchaseReceipts;
				bool flag16 = appleReceipt2.inAppPurchaseReceipts == null;
				subscriptionManager = (SubscriptionManager)(object)list;
				if (!flag16)
				{
					int num7 = inAppPurchaseReceipts.Length;
					bool flag17 = inAppPurchaseReceipts.Length == 0;
					subscriptionManager = (SubscriptionManager)(object)list;
					if (!flag17)
					{
						bool flag18 = inAppPurchaseReceipts.Length < 1;
						subscriptionManager = (SubscriptionManager)(object)list;
						if (!flag18)
						{
							int num8 = 0;
							do
							{
								if (num8 < num7)
								{
									AppleInAppPurchaseReceipt appleInAppPurchaseReceipt = inAppPurchaseReceipts[num8];
									bool flag19 = appleInAppPurchaseReceipt.productID.Equals(text2);
									bool flag20 = !flag19;
									subscriptionManager = (SubscriptionManager)flag19;
									if (!flag20)
									{
										list.Add(inAppPurchaseReceipts[num8]);
										subscriptionManager = (SubscriptionManager)(object)list;
									}
									num7 = inAppPurchaseReceipts.Length;
									num8++;
									continue;
								}
								IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
								text2 = null;
								array2 = null;
								throw ex4;
							}
							while (num8 < inAppPurchaseReceipts.Length);
						}
					}
				}
			}
			if (list.Count != 0)
			{
				AppleInAppPurchaseReceipt r = subscriptionManager.findMostRecentReceipt(list);
				return new SubscriptionInfo(r, intro_json);
			}
			return null;
			IL_04be:
			tag = "Unable to parse Apple receipt";
			logger = unityLogger2;
			goto IL_07a1;
			IL_0608:
			tag = text3;
			intPtr = intPtr4;
			logger = logger2;
			goto IL_07a1;
			IL_0684:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			SubscriptionInfo result = default(SubscriptionInfo);
			return result;
		}

		[Token(Token = "0x6000202")]
		[Address(RVA = "0x15B0ABC", Offset = "0x15B0ABC", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F08D58]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, receipts, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([20298B7]) = v42;\nL_001B:\n\tgoto L_0023;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.SubscriptionManager+<>c>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0023;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v45, receipts, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = UnityEngine.Purchasing.SubscriptionManager+<>c;\nL_0023:\n\tv81 = v56.<>9__11_0;\n\tv58 = v56.<>9__11_0 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_004A;\n\tgoto L_0036;\n\tv84 = *([v52 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.SubscriptionManager+<>c>)+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0036;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v52, receipts, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv108 = UnityEngine.Purchasing.SubscriptionManager+<>c;\n\tv91 = *([v108 @ X8_v19+B8]);\nL_0036:\n\tv76 = new System.Comparison`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>();\n\tSystem.Comparison`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::.ctor(v76, v90.<>9, Il2CppMethodInfo);\n\tv80.<>9__11_0 = v76;\nL_004A:\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::Sort(receipts, v81);\n\tv106 = receipts._size == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0051;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0051:\n\tv112 = receipts._items;\n\treturn v112[0];\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AppleInAppPurchaseReceipt findMostRecentReceipt(List<AppleInAppPurchaseReceipt> receipts)
		{
			Comparison<AppleInAppPurchaseReceipt> comparison = _003C_003Ec._003C_003E9__11_0;
			if (_003C_003Ec._003C_003E9__11_0 == null)
			{
				comparison = (_003C_003Ec._003C_003E9__11_0 = delegate(AppleInAppPurchaseReceipt b, AppleInAppPurchaseReceipt a)
				{
					DateTime purchaseDate = a.purchaseDate;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
					int result = default(int);
					return result;
				});
			}
			receipts.Sort(comparison);
			if (receipts.Count == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			AppleInAppPurchaseReceipt[] items = receipts._items;
			return items[0];
		}

		[Token(Token = "0x6000203")]
		[Address(RVA = "0x15B00FC", Offset = "0x15B00FC", Length = "0x520")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_001C;\n\tv32 = *([1EBD770]);\n\tv33 = *([v32 @ X8_v81]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, payload, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([20298B8]) = v52;\nL_001C:\n\t*([v22 @ X29_v1-48]) = 0;\n\tv58 = 0;\n\tv64 = UnityEngine.Purchasing.MiniJson::JsonDecode(payload);\n\tgoto L_FFFFFFFF;\n\tv150 = v150_asT == 0;\n\tif (v150) goto L_0247;\n\tv498 = &v23 @ stack_-10_v2 - 0x48;\n\tv502 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v64, \"skuDetails\", v498);\n\tv507 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v64, \"isPurchaseHistorySupported\", &v123 @ stack_-68_v5 (System.Object));\n\tv595 = v502 == 0;\n\tif (v595) goto L_007C;\n\tv596 = *([v22 @ X29_v1-48]);\n\tv597 = *([v22 @ X29_v1-48]) == 0;\n\tif (v597) goto L_007C;\n\tv616 = *([v596 @ X8_v78 (System.String)]) != System.String;\n\tif (v616) goto L_FFFFFFFF;\n\tgoto L_0075;\nL_0075:\n\tv673 = v507 == 0;\n\tv618 = ~v673;\n\tif (v618) goto L_FFFFFFFF;\n\tgoto L_00A6;\nL_007C:\n\tv602 = v507 == 0;\n\tif (v602) goto L_FFFFFFFF;\n\tv396 = ~v396_asT;\n\tif (v396) goto L_0245;\n\tv662 = \"il2cpp_vm_object_unbox\"(v123, System.Boolean, &v123 @ stack_-68_v5 (System.Object), Il2CppMethodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv652 = *([v662 @ X0_v63]) == 0;\n\tv642 = ~v652;\nL_00A6:\n\tv483 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v64, \"json\");\n\tv485 = v483 == 0;\n\tif (v485) goto L_00B9;\n\tv397 = *([v483 @ X0_v17 (System.String)]) != System.String;\n\tif (v397) goto L_0245;\nL_00B9:\n\tv269 = UnityEngine.Purchasing.MiniJson::JsonDecode(v483);\n\tgoto L_FFFFFFFF;\n\tv152 = v152_asT == 0;\n\tif (v152) goto L_020F;\n\tv765 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v269, \"autoRenewing\", &v112 @ stack_-70_v8 (System.Object));\n\tv828 = v765 == 0;\n\tif (v828) goto L_FFFFFFFF;\n\tv398 = ~v398_asT;\n\tif (v398) goto L_0245;\n\tv898 = \"il2cpp_vm_object_unbox\"(v112, System.Boolean, &v112 @ stack_-70_v8 (System.Object), Il2CppMethodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv891 = *([v898 @ X0_v61]) == 0;\n\tv886 = ~v891;\n\tgoto L_0111;\nL_0111:\n\tv906 = 0xE93B78(&v58 @ stack_-78_v1, 0x7B2, 1, 1, 0, 0, 0, 1, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv909 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v269, \"purchaseTime\", &v110 @ stack_-80_v8 (System.Object));\n\tv912 = v909 == 0;\n\tif (v912) goto L_0136;\n\tv399 = v399_asT == 0;\n\tif (v399) goto L_0245;\n\tv916 = \"il2cpp_vm_object_unbox\"(v110, System.Int64, &v110 @ stack_-80_v8 (System.Object), Il2CppMethodInfo, 0, 0, 0, 1, 0, v42, v43, v44, v45, v46, v47, v48);\n\tv108 = *([v916 @ X0_v59]);\nL_0136:\n\tv921 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(&v58 @ stack_-78_v1, 0, &v110 @ stack_-80_v8 (System.Object));\n\tv870 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v269, \"developerPayload\", &v103 @ stack_-88_v8 (System.Object));\n\tv872 = v870 == 0;\n\tif (v872) goto L_FFFFFFFF;\n\tv486 = v103 == 0;\n\tif (v486) goto L_0153;\n\tv400 = *([v103 @ stack_-88_v8 (System.Object)]) != System.String;\n\tif (v400) goto L_0245;\nL_0153:\n\tv272 = UnityEngine.Purchasing.MiniJson::JsonDecode(v103);\n\tgoto L_FFFFFFFF;\n\tv155 = v155_asT == 0;\n\tif (v155) goto L_020F;\n\tv938 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v272, \"is_free_trial\", &v101 @ stack_-90_v8 (System.Object));\n\tv940 = v938 == 0;\n\tif (v940) goto L_FFFFFFFF;\n\tv401 = ~v401_asT;\n\tif (v401) goto L_0245;\n\tv949 = \"il2cpp_vm_object_unbox\"(v101, System.Boolean, &v101 @ stack_-90_v8 (System.Object), Il2CppMethodInfo, 0, 0, 0, 1, v108, v42, v43, v44, v45, v46, v47, v48);\n\tv774 = *([v949 @ X0_v57]);\n\tgoto L_01A1;\n\tgoto L_022C;\nL_01A1:\n\tv954 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v272, \"has_introductory_price_trial\", &v87 @ stack_-98_v8 (System.Object));\n\tv956 = v954 == 0;\n\tif (v956) goto L_FFFFFFFF;\n\tv402 = ~v402_asT;\n\tif (v402) goto L_0245;\n\tv965 = \"il2cpp_vm_object_unbox\"(v87, System.Boolean, &v87 @ stack_-98_v8 (System.Object), Il2CppMethodInfo, 0, 0, 0, 1, v108, v42, v43, v44, v45, v46, v47, v48);\n\tv797 = *([v965 @ X0_v55]);\n\tgoto L_01C3;\nL_01C3:\n\tv800 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v272, \"is_updated\", &v89 @ stack_-A0_v8 (System.Object));\n\tv802 = v800 == 0;\n\tif (v802) goto L_0214;\n\tv403 = ~v403_asT;\n\tif (v403) goto L_0245;\n\tv975 = \"il2cpp_vm_object_unbox\"(v89, System.Boolean, &v89 @ stack_-A0_v8 (System.Object), Il2CppMethodInfo, 0, 0, 0, 1, v108, v42, v43, v44, v45, v46, v47, v48);\n\tv981 = v797 == 0;\n\tv986 = ~v981;\n\tv853 = v774 == 0;\n\tv719 = ~v853;\n\tv988 = *([v975 @ X0_v50]) == 0;\n\tif (v988) goto L_FFFFFFFF;\n\tv754 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v272, \"update_subscription_metadata\", &v702 @ stack_-A8_v6 (System.Object));\n\tv991 = v754 == 0;\n\tif (v991) goto L_FFFFFFFF;\n\tv756 = v702 == 0;\n\tif (v756) goto L_022C;\n\tv734 = *([v702 @ stack_-A8_v6 (System.Object)]) == System.String;\n\tif (v734) goto L_022C;\nL_020F:\n\tthrow System.InvalidCastException;\nL_0214:\n\tv808 = v797 == 0;\n\tv813 = ~v808;\n\tv819 = v774 == 0;\n\tv825 = ~v819;\n\tgoto L_022C;\nL_022C:\n\tv879 = new UnityEngine.Purchasing.SubscriptionInfo();\n\tUnityEngine.Purchasing.SubscriptionInfo::.ctor(v879, v287, v867, v836, v834, v865, v298, v837);\n\treturn v879;\n\tv299 = new System.NullReferenceException();\nL_0245:\n\tthrow System.InvalidCastException;\nL_0247:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 463 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe SubscriptionInfo getGooglePlayStoreSubInfo(string payload)
		{
			//IL_06bf: Expected O, but got I4
			//IL_00a9: Expected O, but got I
			//IL_0159: Expected I4, but got O
			//IL_01fa: Expected I, but got O
			//IL_0229: Expected I, but got O
			//IL_0108: Expected O, but got I
			//IL_076d: Expected O, but got I4
			//IL_0277: Expected I4, but got O
			//IL_0447: Expected O, but got I4
			//IL_045d: Expected O, but got I4
			//IL_02e1: Expected I8, but got O
			//IL_0814: Expected I4, but got O
			//IL_0382: Expected I, but got O
			//IL_03b2: Expected I, but got O
			//IL_0400: Expected I4, but got O
			//IL_04b7: Expected I, but got O
			//IL_047d: Expected I4, but got O
			//IL_0430: Expected I4, but got O
			//IL_0657: Expected O, but got I4
			//IL_066c: Expected O, but got I4
			//IL_04c9: Expected I4, but got O
			//IL_04ad: Expected I, but got O
			//IL_0682: Expected O, but got I4
			//IL_0697: Expected O, but got I4
			//IL_0595: Expected O, but got I4
			//IL_05ad: Expected O, but got I4
			//IL_05e6: Expected O, but got I4
			//IL_05fe: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			object obj3 = 0;
			object obj4 = MiniJson.JsonDecode(payload);
			Dictionary<string, object> dictionary = obj4 as Dictionary<string, object>;
			object value;
			string text2;
			string text3;
			if (dictionary != null)
			{
				bool flag = ((Dictionary<string, object>)obj4).TryGetValue("skuDetails", out *(object*)((long)(IntPtr)obj2 - 72L));
				bool flag2 = ((Dictionary<string, object>)obj4).TryGetValue("isPurchaseHistorySupported", out value);
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-48]");
					string text = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-48]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						if ((object)text.GetType() == typeof(string))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-48]");
							text2 = (string)0;
						}
						else
						{
							text2 = null;
						}
						bool flag3 = !flag2;
						bool flag4 = !flag3;
						text3 = text2;
						if (!flag4)
						{
							goto IL_0117;
						}
						goto IL_014c;
					}
				}
				bool flag5 = !flag2;
				text2 = null;
				text3 = null;
				if (flag5)
				{
					goto IL_0117;
				}
				goto IL_014c;
			}
			return (SubscriptionInfo)(object)new InvalidCastException();
			IL_0701:
			string text4 = (string)((Dictionary<string, object>)obj4).get_Item("json");
			bool purchaseHistorySupported;
			if (text4 == null || (object)text4.GetType() == typeof(string))
			{
				object obj5 = MiniJson.JsonDecode(text4);
				IntPtr intPtr = (IntPtr)typeof(Dictionary<string, object>);
				Dictionary<string, object> dictionary2 = obj5 as Dictionary<string, object>;
				bool flag6 = dictionary2 == null;
				intPtr = (IntPtr)typeof(Dictionary<string, object>);
				if (!flag6)
				{
					bool flag9;
					if (((Dictionary<string, object>)obj5).TryGetValue("autoRenewing", out object value2))
					{
						if ((int)((value2 is bool) ? value2 : null) == 0)
						{
							goto IL_069c;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj6 = default(object);
						bool flag7 = obj6 == null;
						bool flag8 = !flag7;
						flag9 = flag8;
					}
					else
					{
						flag9 = false;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93B78 (inside System.DateTime::TimeToTicks +0xF0)");
					bool flag10 = ((Dictionary<string, object>)obj5).TryGetValue("purchaseTime", out object value3);
					bool flag11 = !flag10;
					object obj7 = 0;
					if (!flag11)
					{
						long num = (long)((value3 is long) ? value3 : null);
						if (num == 0)
						{
							goto IL_069c;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj8 = default(object);
						obj7 = obj8;
					}
					bool flag12 = ((Dictionary<string, object>)obj3).TryGetValue((string)null, out value3);
					bool isFreeTrial;
					DateTime purchaseDate;
					string updateMetadata;
					bool hasIntroductoryPriceTrial;
					object obj13;
					if (((Dictionary<string, object>)obj5).TryGetValue("developerPayload", out object value4))
					{
						if (value4 != null && (object)value4.GetType() != typeof(string))
						{
							goto IL_069c;
						}
						object obj9 = MiniJson.JsonDecode((string)value4);
						intPtr = (IntPtr)typeof(Dictionary<string, object>);
						Dictionary<string, object> dictionary3 = obj9 as Dictionary<string, object>;
						bool flag13 = dictionary3 == null;
						intPtr = (IntPtr)typeof(Dictionary<string, object>);
						if (flag13)
						{
							goto IL_060c;
						}
						bool flag14;
						if (((Dictionary<string, object>)obj9).TryGetValue("is_free_trial", out object value5))
						{
							if ((int)((value5 is bool) ? value5 : null) == 0)
							{
								goto IL_069c;
							}
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj10 = default(object);
							flag14 = (byte)(int)obj10 != 0;
						}
						else
						{
							flag14 = false;
						}
						if (((Dictionary<string, object>)obj9).TryGetValue("has_introductory_price_trial", out object value6))
						{
							if ((int)((value6 is bool) ? value6 : null) == 0)
							{
								goto IL_069c;
							}
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj11 = default(object);
							intPtr = (IntPtr)obj11;
						}
						else
						{
							intPtr = (IntPtr)null;
						}
						if (((Dictionary<string, object>)obj9).TryGetValue("is_updated", out object value7))
						{
							if ((int)((value7 is bool) ? value7 : null) == 0)
							{
								goto IL_069c;
							}
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							bool flag15 = intPtr == (IntPtr)0;
							bool flag16 = !flag15;
							bool flag17 = !flag14;
							bool flag18 = !flag17;
							object obj12 = default(object);
							if (obj12 != null && ((Dictionary<string, object>)obj9).TryGetValue("update_subscription_metadata", out object value8))
							{
								bool flag19 = value8 == null;
								isFreeTrial = flag18;
								purchaseDate = (DateTime)flag12;
								updateMetadata = (string)value8;
								hasIntroductoryPriceTrial = flag16;
								obj13 = flag9;
								if (!flag19)
								{
									bool flag20 = (object)value8.GetType() == typeof(string);
									isFreeTrial = flag18;
									purchaseDate = (DateTime)flag12;
									updateMetadata = (string)value8;
									hasIntroductoryPriceTrial = flag16;
									obj13 = flag9;
									if (!flag20)
									{
										goto IL_060c;
									}
								}
							}
							else
							{
								isFreeTrial = flag18;
								purchaseDate = (DateTime)flag12;
								updateMetadata = null;
								hasIntroductoryPriceTrial = flag16;
								obj13 = flag9;
							}
						}
						else
						{
							bool flag21 = intPtr == (IntPtr)0;
							bool flag22 = !flag21;
							bool flag23 = !flag14;
							bool flag24 = !flag23;
							isFreeTrial = flag24;
							purchaseDate = (DateTime)flag12;
							updateMetadata = null;
							hasIntroductoryPriceTrial = flag22;
							obj13 = flag9;
						}
					}
					else
					{
						isFreeTrial = false;
						purchaseDate = (DateTime)flag12;
						updateMetadata = null;
						hasIntroductoryPriceTrial = false;
						obj13 = flag9;
					}
					return new SubscriptionInfo(text2, (byte)(int)obj13 != 0, purchaseDate, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata);
				}
				goto IL_060c;
			}
			goto IL_069c;
			IL_069c:
			throw new InvalidCastException();
			IL_014c:
			if ((int)((value is bool) ? value : null) == 0)
			{
				goto IL_069c;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj14 = default(object);
			bool flag25 = obj14 == null;
			bool flag26 = !flag25;
			text2 = text3;
			purchaseHistorySupported = flag26;
			goto IL_0701;
			IL_0117:
			purchaseHistorySupported = false;
			goto IL_0701;
			IL_060c:
			throw new InvalidCastException();
		}
	}
}

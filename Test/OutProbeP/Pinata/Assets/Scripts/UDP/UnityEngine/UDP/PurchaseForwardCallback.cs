using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Analytics;
using UnityEngine.UDP.Common;

namespace UnityEngine.UDP
{
	[Token(Token = "0x200000F")]
	internal class PurchaseForwardCallback : AndroidJavaProxy
	{
		[CompilerGenerated]
		[Token(Token = "0x2000012")]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x4000040")]
			[FieldOffset(Offset = "0x10")]
			public PurchaseForwardCallback _003C_003E4__this;

			[Token(Token = "0x4000041")]
			[FieldOffset(Offset = "0x18")]
			public string message;

			[Token(Token = "0x600005A")]
			[Address(RVA = "0x15CAD7C", Offset = "0x15CAD7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass4_0()
			{
			}

			internal void _003ConQueryInventory_003Eb__1()
			{
				PurchaseForwardCallback purchaseForwardCallback = _003C_003E4__this;
				purchaseForwardCallback.purchaseListener.OnQueryInventoryFailed(message);
			}
		}

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x20")]
		private IPurchaseListener purchaseListener;

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x15CA604", Offset = "0x15CA604", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE0B40]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, purchaseListener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299DB]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, purchaseListener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.PurchaseCallback\");\n\tthis.purchaseListener = purchaseListener;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseForwardCallback(IPurchaseListener purchaseListener)
			: base("com.unity.udp.sdk.PurchaseCallback")
		{
			this.purchaseListener = purchaseListener;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x15CA68C", Offset = "0x15CA68C", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EEE030]);\n\tv31 = *([v30 @ X8_v44]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, resultCode, message, purchaseInfoString, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20299DC]) = v47;\nL_001C:\n\tv51 = new UnityEngine.UDP.PurchaseForwardCallback+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v51);\n\tv51.<>4__this = this;\n\tv51.message = message;\n\t// 41 Box v60 @ X0_v8 (System.Object), typeof(System.Int32), &resultCode @ X1 (System.Int32)\n\tv96 = System.String::Format(\"Purchased Finished. ResultCode: {0}, message: {1}, purchaseInfoString: {2}\", v60, v51.message, purchaseInfoString);\n\tgoto L_0043;\n\tv132 = *([v99 @ X8_v13+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0043;\n\tv140 = v99;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v140, v92, v90, v93, v65, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0043:\n\tUnityEngine.Debug::Log(v96);\n\tv142 = this.purchaseListener == 0;\n\tif (v142) goto L_00AB;\n\tv144 = UnityEngine.UDP.PurchaseForwardCallback::ConvertPurchaseInfo(purchaseInfoString);\n\tv51.purchaseInfo = v144;\n\tv164 = new System.Action();\n\tv165 = resultCode == 0;\n\tif (v165) goto L_0074;\n\tSystem.Action::.ctor(v164, v51, Il2CppMethodInfo);\n\tgoto L_0065;\n\tv185 = *([v175 @ X0_v30+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_0065;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v175, v150, v147, v145, v65, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0065:\n\tUnityEngine.UDP.MainThreadDispatcher::RunOnMainThread(v164);\n\tv160 = v51.purchaseInfo;\n\tv155 = v51.purchaseInfo == 0;\n\tif (v155) goto L_00AB;\n\tv154 = UnityEngine.UDP.Analytics.UdpAnalytics::TransactionFailed(v160.<ProductId>k__BackingField, v160.<GameOrderId>k__BackingField, v51.message);\n\tgoto L_00AB;\nL_0074:\n\tSystem.Action::.ctor(v164, v51, Il2CppMethodInfo);\n\tgoto L_0082;\n\tv192 = *([v181 @ X0_v19+E0]);\n\tv193 = v192 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_0082;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v181, v172, v69, v67, v65, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0082:\n\tUnityEngine.UDP.MainThreadDispatcher::RunOnMainThread(v164);\n\tv204 = new UnityEngine.UDP.TransactionEventHandler();\n\tSystem.Object::.ctor(v204);\n\tv204._purchaseInfo = v51.purchaseInfo;\n\tv75 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v75);\n\tv86 = v51.purchaseInfo;\n\tSystem.Collections.Generic.List`1<System.String>::Add(v75, v86.<ProductId>k__BackingField);\n\tUnityEngine.UDP.StoreService::QueryInventory(v75, v204);\nL_00AB:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onPurchaseFinished(int resultCode, string message, string purchaseInfoString)
		{
			object arg = resultCode;
			string message2 = $"Purchased Finished. ResultCode: {arg}, message: {message}, purchaseInfoString: {purchaseInfoString}";
			Debug.Log(message2);
			if (purchaseListener == null)
			{
				return;
			}
			PurchaseInfo purchaseInfo = ConvertPurchaseInfo(purchaseInfoString);
			PurchaseInfo purchaseInfo2 = purchaseInfo;
			Action runnable = delegate
			{
				//IL_001f: Expected I, but got O
				//IL_0177: Expected O, but got I
				//IL_006e: Expected O, but got I
				//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f5: Expected O, but got Unknown
				//IL_0112: Expected O, but got I
				//IL_0121: Expected O, but got I
				//IL_00ba: Expected O, but got I
				PurchaseForwardCallback purchaseForwardCallback = this;
				IPurchaseListener purchaseListener = purchaseForwardCallback.purchaseListener;
				IntPtr intPtr = (IntPtr)purchaseListener;
				PurchaseInfo purchaseInfo5 = purchaseInfo2;
				string text = message;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v4 (Il2CppClass<UnityEngine.UDP.IPurchaseListener>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00d3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v4 (Il2CppClass<UnityEngine.UDP.IPurchaseListener>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IPurchaseListener))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v4 (Il2CppClass<UnityEngine.UDP.IPurchaseListener>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00d3;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_015f;
				IL_00d3:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_015f;
				IL_015f:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v103 @ X4_v1 (should have been resolved before IL gen)");
			};
			if (resultCode != 0)
			{
				MainThreadDispatcher.RunOnMainThread(runnable);
				PurchaseInfo purchaseInfo3 = purchaseInfo2;
				if (purchaseInfo2 != null)
				{
					AnalyticsResult analyticsResult = UdpAnalytics.TransactionFailed(purchaseInfo3.ProductId, purchaseInfo3.GameOrderId, message);
				}
			}
			else
			{
				MainThreadDispatcher.RunOnMainThread(runnable);
				TransactionEventHandler transactionEventHandler = null;
				transactionEventHandler._purchaseInfo = purchaseInfo2;
				List<string> list = new List<string>();
				PurchaseInfo purchaseInfo4 = purchaseInfo2;
				list.Add(purchaseInfo4.ProductId);
				StoreService.QueryInventory(list, transactionEventHandler);
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x15CAA64", Offset = "0x15CAA64", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EAE548]);\n\tv31 = *([v30 @ X8_v28]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, resultCode, message, purchaseInfoString, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20299DD]) = v47;\nL_001C:\n\tv51 = new UnityEngine.UDP.PurchaseForwardCallback+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v51);\n\tv51.<>4__this = this;\n\tv51.message = message;\n\tv56 = this.purchaseListener == 0;\n\tif (v56) goto L_0059;\n\tv60 = UnityEngine.UDP.PurchaseForwardCallback::ConvertPurchaseInfo(purchaseInfoString);\n\tv51.purchaseInfo = v60;\n\tv99 = System.String::Concat(\"onConsumeFinished, purchaseInfoString: \", purchaseInfoString);\n\tgoto L_0040;\n\tv136 = *([v87 @ X8_v11+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0040;\n\tv142 = v87;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v142, v97, v77, purchaseInfoString, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0040:\n\tUnityEngine.Debug::Log(v99);\n\tv143 = resultCode + 0x258;\n\tv69 = v143 == 0;\n\tif (v69) goto L_005D;\n\tv144 = resultCode == 0;\n\tv83 = ~v144;\n\tif (v83) goto L_0059;\n\tv157 = new System.Action();\n\tgoto L_0064;\nL_0059:\n\treturn;\nL_005D:\n\tv157 = new System.Action();\nL_0064:\n\tSystem.Action::.ctor(v157, v51, *([v159 @ X8_v12 (Il2CppMethodInfo)]));\n\tgoto L_007A;\n\tv167 = *([v163 @ X0_v14+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tgoto L_007A;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v163, v112, v110, v101, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_007A:\n\tUnityEngine.UDP.MainThreadDispatcher::RunOnMainThread(v157);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onConsumeFinished(int resultCode, string message, string purchaseInfoString)
		{
			if (purchaseListener == null)
			{
				return;
			}
			PurchaseInfo purchaseInfo = ConvertPurchaseInfo(purchaseInfoString);
			PurchaseInfo purchaseInfo2 = purchaseInfo;
			string message2 = "onConsumeFinished, purchaseInfoString: " + purchaseInfoString;
			Debug.Log(message2);
			Action runnable;
			if (resultCode + 600 != 0)
			{
				if (resultCode != 0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: Action");
				runnable = null;
				IntPtr intPtr = (IntPtr)0;
			}
			else
			{
				runnable = null;
				IntPtr intPtr = (IntPtr)0;
			}
			MainThreadDispatcher.RunOnMainThread(runnable);
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x15CABE4", Offset = "0x15CABE4", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EEFB08]);\n\tv31 = *([v30 @ X8_v29]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, resultCode, message, inventoryString, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20299DE]) = v47;\nL_001C:\n\tv51 = new UnityEngine.UDP.PurchaseForwardCallback+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v51);\n\tv51.<>4__this = this;\n\tv51.message = message;\n\tv60 = System.String::Concat(\"onQueryInventory, inventoryString: \", inventoryString);\n\tgoto L_003A;\n\tv84 = *([v80 @ X8_v10+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_003A;\n\tv139 = v80;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v139, v57, v58, inventoryString, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_003A:\n\tUnityEngine.Debug::Log(v60);\n\tv68 = new UnityEngine.UDP.PurchaseForwardCallback+<>c__DisplayClass4_1();\n\tSystem.Object::.ctor(v68);\n\tv142 = resultCode + 0x2BC;\n\tv104 = v142 == 0;\n\tv68.CS$<>8__locals1 = v51;\n\tif (v104) goto L_005D;\n\tv143 = resultCode == 0;\n\tv118 = ~v143;\n\tif (v118) goto L_0084;\n\tv149 = UnityEngine.UDP.PurchaseForwardCallback::ConvertInventory(inventoryString);\n\tv68.inventory = v149;\n\tv159 = new System.Action();\n\tgoto L_0064;\nL_005D:\n\tv159 = new System.Action();\nL_0064:\n\tSystem.Action::.ctor(v159, v113, *([v163 @ X8_v13 (Il2CppMethodInfo)]));\n\tgoto L_007A;\n\tv172 = *([v168 @ X0_v14+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tgoto L_007A;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v168, v113, v111, v93, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_007A:\n\tUnityEngine.UDP.MainThreadDispatcher::RunOnMainThread(v161);\n\treturn;\nL_0084:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onQueryInventory(int resultCode, string message, string inventoryString)
		{
			_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_2 = new _003C_003Ec__DisplayClass4_0();
			_003C_003Ec__DisplayClass4_2._003C_003E4__this = this;
			_003C_003Ec__DisplayClass4_2.message = message;
			string message2 = "onQueryInventory, inventoryString: " + inventoryString;
			Debug.Log(message2);
			int num = resultCode + 700;
			bool flag = num == 0;
			_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_3 = _003C_003Ec__DisplayClass4_2;
			Action runnable;
			if (!flag)
			{
				if (resultCode != 0)
				{
					return;
				}
				Inventory inventory = ConvertInventory(inventoryString);
				Inventory inventory2 = inventory;
				Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: Action");
				Action action = null;
				_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_5;
				_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_4 = (_003C_003Ec__DisplayClass4_0)(object)_003C_003Ec__DisplayClass4_5;
				runnable = action;
				IntPtr intPtr = (IntPtr)0;
			}
			else
			{
				Action action = null;
				_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_4 = _003C_003Ec__DisplayClass4_2;
				runnable = action;
				IntPtr intPtr = (IntPtr)0;
			}
			MainThreadDispatcher.RunOnMainThread(runnable);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x15CA8D4", Offset = "0x15CA8D4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.String::IsNullOrEmpty(purchaseInfoString);\n\tv13 = v11 == 0;\n\tif (v13) goto L_0012;\n\treturn 0;\nL_0012:\n\tv19 = UnityEngine.UDP.Common.MiniJson::JsonDecode(purchaseInfoString);\n\treturnVal2 = UnityEngine.UDP.PurchaseForwardCallback::ConvertPurchaseInfo(v19);\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static PurchaseInfo ConvertPurchaseInfo(string purchaseInfoString)
		{
			if (string.IsNullOrEmpty(purchaseInfoString))
			{
				return null;
			}
			Dictionary<string, object> purchaseInfoMap = MiniJson.JsonDecode(purchaseInfoString);
			return ConvertPurchaseInfo(purchaseInfoMap);
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x15CB0E8", Offset = "0x15CB0E8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EC6130]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20299DF]) = v40;\nL_0017:\n\tv44 = new UnityEngine.UDP.PurchaseInfo();\n\tSystem.Object::.ctor(v44);\n\tv55 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(purchaseInfoMap, \"gameOrderId\", 0);\n\tv44.<GameOrderId>k__BackingField = v55;\n\tv63 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(purchaseInfoMap, \"itemType\", 0);\n\tv44.<ItemType>k__BackingField = v63;\n\tv72 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(purchaseInfoMap, \"orderQueryToken\", 0);\n\tv44.<OrderQueryToken>k__BackingField = v72;\n\tv79 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(purchaseInfoMap, \"productId\", 0);\n\tv44.<ProductId>k__BackingField = v79;\n\tv106 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(purchaseInfoMap, \"storePurchaseJsonString\", 0);\n\tv44.<StorePurchaseJsonString>k__BackingField = v106;\n\tv109 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(purchaseInfoMap, \"developerPayload\", 0);\n\tv44.<DeveloperPayload>k__BackingField = v109;\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static PurchaseInfo ConvertPurchaseInfo(Dictionary<string, object> purchaseInfoMap)
		{
			PurchaseInfo purchaseInfo = new PurchaseInfo();
			string valueOfDictionary = GetValueOfDictionary<string>(purchaseInfoMap, "gameOrderId", null);
			purchaseInfo.GameOrderId = valueOfDictionary;
			string valueOfDictionary2 = GetValueOfDictionary<string>(purchaseInfoMap, "itemType", null);
			purchaseInfo.ItemType = valueOfDictionary2;
			string valueOfDictionary3 = GetValueOfDictionary<string>(purchaseInfoMap, "orderQueryToken", null);
			purchaseInfo.OrderQueryToken = valueOfDictionary3;
			string valueOfDictionary4 = GetValueOfDictionary<string>(purchaseInfoMap, "productId", null);
			purchaseInfo.ProductId = valueOfDictionary4;
			string valueOfDictionary5 = GetValueOfDictionary<string>(purchaseInfoMap, "storePurchaseJsonString", null);
			purchaseInfo.StorePurchaseJsonString = valueOfDictionary5;
			string valueOfDictionary6 = GetValueOfDictionary<string>(purchaseInfoMap, "developerPayload", null);
			purchaseInfo.DeveloperPayload = valueOfDictionary6;
			return purchaseInfo;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x15CB224", Offset = "0x15CB224", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.String::IsNullOrEmpty(productInfoString);\n\tv13 = v11 == 0;\n\tif (v13) goto L_0012;\n\treturn 0;\nL_0012:\n\tv19 = UnityEngine.UDP.Common.MiniJson::JsonDecode(productInfoString);\n\treturnVal2 = UnityEngine.UDP.PurchaseForwardCallback::ConvertProductInfo(v19);\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ProductInfo ConvertProductInfo(string productInfoString)
		{
			if (string.IsNullOrEmpty(productInfoString))
			{
				return null;
			}
			Dictionary<string, object> productInfoMap = MiniJson.JsonDecode(productInfoString);
			return ConvertProductInfo(productInfoMap);
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x15CB264", Offset = "0x15CB264", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EE84D8]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20299E0]) = v40;\nL_0017:\n\tv44 = new UnityEngine.UDP.ProductInfo();\n\tSystem.Object::.ctor(v44);\n\tv55 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"consumable\", 0);\n\tv60 = 0;\n\tv62 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(&v60 @ stack_-24_v1 (System.Nullable`1<System.Boolean>), v55, Il2CppMethodInfo);\n\tv44.<Consumable>k__BackingField = 0;\n\tv73 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"currency\", 0);\n\tv44.<Currency>k__BackingField = v73;\n\tv82 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"description\", 0);\n\tv44.<Description>k__BackingField = v82;\n\tv89 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"itemType\", 0);\n\tv44.<ItemType>k__BackingField = v89;\n\tv118 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"price\", 0);\n\tv44.<Price>k__BackingField = v118;\n\tv126 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"priceAmountMicros\", 0);\n\tv44.<PriceAmountMicros>k__BackingField = v126;\n\tv133 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"productId\", 0);\n\tv44.<ProductId>k__BackingField = v133;\n\tv136 = UnityEngine.UDP.PurchaseForwardCallback::GetValueOfDictionary(productInfoMap, \"title\", 0);\n\tv44.<Title>k__BackingField = v136;\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ProductInfo ConvertProductInfo(Dictionary<string, object> productInfoMap)
		{
			//IL_001e: Expected O, but got I4
			//IL_00db: Expected I8, but got I4
			ProductInfo productInfo = new ProductInfo();
			bool valueOfDictionary = GetValueOfDictionary(productInfoMap, "consumable", defaultValue: false);
			bool valueOfDictionary2 = GetValueOfDictionary((IDictionary<string, object>)(bool?)null, (string)valueOfDictionary, defaultValue: false);
			productInfo.Consumable = null;
			string valueOfDictionary3 = GetValueOfDictionary<string>(productInfoMap, "currency", null);
			productInfo.Currency = valueOfDictionary3;
			string valueOfDictionary4 = GetValueOfDictionary<string>(productInfoMap, "description", null);
			productInfo.Description = valueOfDictionary4;
			string valueOfDictionary5 = GetValueOfDictionary<string>(productInfoMap, "itemType", null);
			productInfo.ItemType = valueOfDictionary5;
			string valueOfDictionary6 = GetValueOfDictionary<string>(productInfoMap, "price", null);
			productInfo.Price = valueOfDictionary6;
			long valueOfDictionary7 = GetValueOfDictionary(productInfoMap, "priceAmountMicros", 0L);
			productInfo.PriceAmountMicros = valueOfDictionary7;
			string valueOfDictionary8 = GetValueOfDictionary<string>(productInfoMap, "productId", null);
			productInfo.ProductId = valueOfDictionary8;
			string valueOfDictionary9 = GetValueOfDictionary<string>(productInfoMap, "title", null);
			productInfo.Title = valueOfDictionary9;
			return productInfo;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x15CAD8C", Offset = "0x15CAD8C", Length = "0x35C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EEACE8]);\n\tv27 = *([v26 @ X8_v55]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20299E1]) = v46;\nL_001C:\n\tv52 = System.String::IsNullOrEmpty(inventoryString);\n\tv55 = v52 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0151;\n\tv60 = new UnityEngine.UDP.Inventory();\n\tUnityEngine.UDP.Inventory::.ctor(v60);\n\tv193 = UnityEngine.UDP.Common.MiniJson::JsonDecode(inventoryString);\n\tv195 = v193 == 0;\n\tif (v195) goto L_00CD;\n\tv203 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v193, \"purchases\");\n\tv259 = v203 == 0;\n\tif (v259) goto L_005D;\n\tgoto L_FFFFFFFF;\n\tv277 = v277_asT == 0;\n\tif (v277) goto L_00CA;\nL_005D:\n\tv304 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v193, \"products\");\n\tv369 = v304 == 0;\n\tif (v369) goto L_0086;\n\tgoto L_FFFFFFFF;\n\tv374 = v374_asT == 0;\n\tif (v374) goto L_00CC;\nL_0086:\n\tv424 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v203);\nL_0091:\n\tv549 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(&v325 @ stack_-78_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>), Il2CppMethodInfo);\n\tv550 = v549 & 1;\n\tv551 = v550 == 0;\n\tif (v551) goto L_00C1;\n\tv577 = v521 == 0;\n\tif (v577) goto L_00B6;\n\tgoto L_FFFFFFFF;\n\tv596 = v596_asT == 0;\n\tif (v596) goto L_00C6;\nL_00B6:\n\tv607 = UnityEngine.UDP.PurchaseForwardCallback::ConvertPurchaseInfo(v521);\n\tUnityEngine.UDP.Inventory::AddPurchase(v60, v607);\n\tgoto L_0091;\nL_00C1:\n\tv476 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(&v325 @ stack_-78_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>), Il2CppMethodInfo);\n\tv608 = v304 == 0;\n\tv480 = ~v608;\n\tif (v480) goto L_00ED;\n\tgoto L_012A;\nL_00C6:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_00CA:\n\tthrow System.InvalidCastException;\nL_00CC:\n\tv249 = new System.InvalidCastException();\nL_00CD:\n\tv256 = new System.NullReferenceException();\n\tgoto L_00DB;\n\tgoto L_00DB;\n\tgoto L_00DB;\n\tgoto L_00DB;\nL_00DB:\n\tv314 = v244 != 1;\n\tif (v314) goto L_0152;\n\tv370 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v256, v244);\n\tv415 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v370, v244);\n\tv477 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v204 @ stack_-60_v8 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv526 = *([v370 @ X0_v36]) == 0;\n\tv525 = ~v526;\n\tif (v525) goto L_012C;\nL_00ED:\n\tv575 = System.Collections.Generic.List`1::GetEnumerator /* +104 sharing this address */(v123, *([v71 @ X24_v6 (Il2CppMethodInfo)]));\nL_00F2:\n\tv678 = *([v111 @ X22_v6 (Il2CppMethodInfo)]);\n\tv631 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(&v325 @ stack_-78_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>), *([v111 @ X22_v6 (Il2CppMethodInfo)]));\n\tv647 = v631 & 1;\n\tv121 = v647 == 0;\n\tif (v121) goto L_0124;\n\tv651 = v521 == 0;\n\tif (v651) goto L_0119;\n\tv654 = *([v521 @ stack_-68 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)]);\n\tv678 = *([v117 @ X23_v6 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv658 = *([v654 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]) < *([v678 @ X1_v13 (System.String)+128]);\n\tv659 = ~v658;\n\tv667 = ~v659;\n\tif (v667) goto L_0126;\n\tv668 = *([v678 @ X1_v13 (System.String)+128]) << 3;\n\tv682 = *([v654 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]) + v668;\n\tv669 = *([v682 @ X8_v20-8]) != v678;\n\tif (v669) goto L_0126;\nL_0119:\n\tv680 = UnityEngine.UDP.PurchaseForwardCallback::ConvertProductInfo(v521);\n\tUnityEngine.UDP.Inventory::AddProduct(v60, v680);\n\tgoto L_00F2;\nL_0124:\n\tv119 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v325 @ stack_-78_v10 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0151;\nL_0126:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_012A:\n\tthrow System.NullReferenceException;\nL_012C:\n\tgoto L_0156;\n\tgoto L_0131;\n\tgoto L_0131;\n\tgoto L_0131;\n\tgoto L_0131;\nL_0131:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0152;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F08848]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0153;\nL_0151:\n\treturn v126;\nL_0152:\n\tv371 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v256, v244);\nL_0153:\n\t;\nL_0156:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Inventory ConvertInventory(string inventoryString)
		{
			//IL_003f: Expected I, but got O
			//IL_04af: Expected O, but got I
			//IL_031d: Expected O, but got I
			//IL_032e: Expected O, but got I
			//IL_009c: Expected I, but got O
			//IL_00ab: Expected I, but got O
			//IL_04fd: Expected O, but got I
			//IL_0164: Expected I, but got O
			//IL_0173: Expected I, but got O
			//IL_00f2: Expected I, but got O
			//IL_0101: Expected I, but got O
			//IL_0274: Expected O, but got I
			//IL_02ad: Expected I, but got O
			//IL_01ba: Expected I, but got O
			//IL_01c9: Expected I, but got O
			//IL_0535: Expected O, but got I
			//IL_0542: Expected O, but got I
			//IL_03b6: Expected I, but got O
			//IL_03be: Expected O, but got I
			//IL_042b: Expected O, but got I
			bool flag = string.IsNullOrEmpty(inventoryString);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Inventory result = null;
			Inventory inventory;
			List<object>.Enumerator enumerator;
			IntPtr intPtr;
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr3 = default(IntPtr);
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			Dictionary<string, object> dictionary4 = default(Dictionary<string, object>);
			IntPtr intPtr5;
			IntPtr intPtr6;
			if (!flag3)
			{
				inventory = new Inventory();
				Dictionary<string, object> dictionary = MiniJson.JsonDecode(inventoryString);
				bool flag4 = dictionary == null;
				enumerator = default(List<object>.Enumerator);
				intPtr = (IntPtr)null;
				Dictionary<string, object> dictionary2 = dictionary;
				if (flag4)
				{
					goto IL_02e2;
				}
				object obj = dictionary.get_Item("purchases");
				if (obj != null)
				{
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)typeof(List<object>);
					intPtr = (IntPtr)typeof(List<object>);
					intPtr3 = (IntPtr)0;
					dictionary2 = dictionary;
					List<object> list = obj as List<object>;
					bool flag5 = list == null;
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)typeof(List<object>);
					intPtr = (IntPtr)typeof(List<object>);
					intPtr3 = (IntPtr)0;
					dictionary2 = dictionary;
					if (flag5)
					{
						throw new InvalidCastException();
					}
				}
				Dictionary<string, object> dictionary3 = (Dictionary<string, object>)dictionary.get_Item("products");
				if (dictionary3 != null)
				{
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)typeof(List<object>);
					intPtr = (IntPtr)typeof(List<object>);
					intPtr3 = (IntPtr)0;
					dictionary2 = dictionary3;
					List<object> list2 = dictionary3 as List<object>;
					bool flag6 = list2 == null;
					enumerator = default(List<object>.Enumerator);
					intPtr2 = (IntPtr)typeof(List<object>);
					intPtr = (IntPtr)typeof(List<object>);
					intPtr3 = (IntPtr)0;
					dictionary2 = dictionary3;
					if (flag6)
					{
						InvalidCastException ex = new InvalidCastException();
						goto IL_02e2;
					}
				}
				object enumerator2 = ((List<object>)obj).GetEnumerator();
				while (true)
				{
					object obj2 = ((Dictionary<string, object>)enumerator3).get_Item((string)0);
					if ((int)((long)(IntPtr)obj2 & 1L) == 0)
					{
						break;
					}
					if (dictionary4 != null)
					{
						Dictionary<string, object> dictionary5 = dictionary4 as Dictionary<string, object>;
						if (dictionary5 == null)
						{
							throw new InvalidCastException();
						}
					}
					PurchaseInfo purchaseInfo = ConvertPurchaseInfo(dictionary4);
					inventory.AddPurchase(purchaseInfo);
				}
				object obj3 = ((Dictionary<string, object>)enumerator3).get_Item((string)0);
				bool flag7 = dictionary3 == null;
				bool flag8 = !flag7;
				IntPtr intPtr4 = (IntPtr)0;
				intPtr5 = (IntPtr)0;
				intPtr6 = (IntPtr)typeof(Dictionary<string, object>);
				dictionary2 = dictionary3;
				if (!flag8)
				{
					throw new NullReferenceException();
				}
				goto IL_037d;
			}
			goto IL_049d;
			IL_02e2:
			NullReferenceException ex2 = new NullReferenceException();
			if (intPtr == (IntPtr)1)
			{
				object obj4 = ((Dictionary<string, object>)(object)ex2).get_Item((string)(long)intPtr);
				object obj5 = ((Dictionary<string, object>)obj4).get_Item((string)(long)intPtr);
				enumerator.Dispose();
				if (obj4 == null)
				{
					intPtr5 = intPtr2;
					intPtr6 = intPtr3;
					goto IL_037d;
				}
			}
			else
			{
				object obj6 = ((Dictionary<string, object>)(object)ex2).get_Item((string)(long)intPtr);
			}
			return (Inventory)(object)new TypeLoadException();
			IL_037d:
			Il2CppRuntime.Boundary("MANAGED", "Method not found @1452110 (System.Collections.Generic.List`1::GetEnumerator, and 104 more at this address)");
			while (true)
			{
				string text = (string)(long)intPtr5;
				object obj7 = ((Dictionary<string, object>)enumerator3).get_Item((string)(long)intPtr5);
				if ((int)((long)(IntPtr)obj7 & 1L) == 0)
				{
					break;
				}
				if (dictionary4 != null)
				{
					IntPtr intPtr7 = (IntPtr)dictionary4;
					text = (string)(long)intPtr6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]");
					IntPtr intPtr8 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ X1_v13 (System.String)+128]");
					if ((long)intPtr8 >= 0L)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ X1_v13 (System.String)+128]");
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]");
						object obj8 = 0L + (long)num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ X8_v20-8]");
						if ((IntPtr)0 == (IntPtr)text)
						{
							goto IL_0452;
						}
					}
					throw new InvalidCastException();
				}
				goto IL_0452;
				IL_0452:
				ProductInfo productInfo = ConvertProductInfo(dictionary4);
				inventory.AddProduct(productInfo);
			}
			enumerator3.Dispose();
			result = inventory;
			goto IL_049d;
			IL_049d:
			return result;
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0xACDCB8", Offset = "0xACDCB8", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EA35A8]);\n\tv31 = *([v30 @ X8_v21]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, key, defaultValue, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20223CB]) = v47;\nL_001C:\n\tv50 = dictionary->klass;\n\tv54 = *([v50 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v54) goto L_003F;\n\tv191 = *([v50 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_002A:\n\tv196 = *([v191 @ X11_v14-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v196) goto L_0042;\n\tv190 = v190 + 1;\n\tv201 = v190 < *([v50 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv136 = ~v201;\n\tv191 = v191 + 0x10;\n\tv120 = ~v136;\n\tif (v120) goto L_002A;\nL_003F:\n\tv222 = 0x8909C4(dictionary, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 3, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_004A;\nL_0042:\n\tv203 = *([v191 @ X11_v14]) + 3;\n\tv204 = v203 << 4;\n\tv205 = v50 + v204;\n\tv222 = v205 + 0x130;\nL_004A:\n\t*([v222 @ X0_v7])(v228, dictionary, key, *([v222 @ X0_v7+8]), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv229 = v228 & 1;\n\tv230 = v229 == 0;\n\tif (v230) goto L_00A3;\n\tgoto L_007A;\n\tv303 = *([v283 @ X8_v9+B0]);\n\tv304 = 0;\n\tv305 = v303 + 8;\n\tv307 = *([v344 @ X11_v9-8]);\n\tv349 = v307 == v284;\n\tif (v349) goto L_0072;\n\tv327 = v343 + 1;\n\tv354 = v327 < v285;\n\tv325 = ~v354;\n\tv329 = v344 + 0x10;\n\tv309 = ~v325;\n\tif (v309) goto L_FFFFFFFF;\n\tv330 = v24;\n\tv331 = 0;\n\tv332 = 0x8909C4(v330, v284, v331, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_007A;\nL_0072:\n\tv355 = *([v344 @ X11_v9]);\n\tv356 = v355 << 4;\n\tv357 = v283 + v356;\n\tv358 = v357 + 0x130;\nL_007A:\n\tv364 = System.Collections.Generic.IDictionary`2<System.String, System.Object>::get_Item(dictionary, key);\n\tgoto L_FFFFFFFF;\n\tv369 = v108;\n\tv370 = 0x8907BC(v369, v97, v62, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv148 = v148_asT == 0;\n\tif (v148) goto L_00B0;\n\tv297 = \"il2cpp_vm_object_unbox\"(v364, key, 0, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv292 = *([v297 @ X0_v17]) == 0;\n\tv287 = ~v292;\nL_00A3:\n\treturnVal2 = v299 & 1;\n\treturn returnVal2;\n\tv113 = new System.NullReferenceException();\nL_00B0:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static T GetValueOfDictionary<T>(IDictionary<string, object> dictionary, string key, T defaultValue)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0200: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0160: Expected O, but got I4
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X11_v14-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_019d;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_019d;
			IL_019d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v222 @ X0_v7] (should have been resolved before IL gen)");
			object obj5 = default(object);
			int num4 = (int)((long)(IntPtr)obj5 & 1L);
			bool flag3 = num4 == 0;
			T val = defaultValue;
			if (!flag3)
			{
				object obj6 = dictionary.get_Item(key);
				T val2 = (T)((obj6 is T) ? obj6 : null);
				if (val2 == null)
				{
					return (T)new InvalidCastException();
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj7 = default(object);
				bool flag4 = obj7 == null;
				bool flag5 = !flag4;
				val = (T)flag5;
			}
			return (T)((long)(IntPtr)val & 1L);
		}
	}
}

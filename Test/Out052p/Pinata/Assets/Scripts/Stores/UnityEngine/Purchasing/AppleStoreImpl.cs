using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AOT;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.Security;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200003D")]
	internal class AppleStoreImpl : JSONStore, IAppleExtensions, IStoreExtension, IAppleConfiguration, IStoreConfiguration
	{
		[CompilerGenerated]
		[Token(Token = "0x200003E")]
		private sealed class _003C_003Ec__DisplayClass23_0
		{
			[Token(Token = "0x40000AD")]
			[FieldOffset(Offset = "0x10")]
			public ProductDescription productDescription;

			[Token(Token = "0x60000EC")]
			[Address(RVA = "0xC59230", Offset = "0xC59230", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass23_0()
			{
			}

			internal bool _003COnProductsRetrieved_003Eb__0(AppleInAppPurchaseReceipt r)
			{
				ProductDescription productDescription = this.productDescription;
				return r.productID == productDescription.storeSpecificId;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200003F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000AE")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000AF")]
			public static Comparison<AppleInAppPurchaseReceipt> _003C_003E9__23_1;

			[Token(Token = "0x40000B0")]
			public static Comparison<AppleInAppPurchaseReceipt> _003C_003E9__40_1;

			[Token(Token = "0x60000EE")]
			[Address(RVA = "0xC5AE30", Offset = "0xC5AE30", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F03980]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20232F8]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.AppleStoreImpl+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000EF")]
			[Address(RVA = "0xC5AE94", Offset = "0xC5AE94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal int _003COnProductsRetrieved_003Eb__23_1(AppleInAppPurchaseReceipt b, AppleInAppPurchaseReceipt a)
			{
				DateTime purchaseDate = a.purchaseDate;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
				int result = default(int);
				return result;
			}

			internal int _003CisValidPurchaseState_003Eb__40_1(AppleInAppPurchaseReceipt b, AppleInAppPurchaseReceipt a)
			{
				DateTime purchaseDate = a.purchaseDate;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
				int result = default(int);
				return result;
			}
		}

		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0xA8")]
		private Action<Product> m_DeferredCallback;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0xB0")]
		private Action m_RefreshReceiptError;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0xB8")]
		private Action<string> m_RefreshReceiptSuccess;

		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0xC0")]
		private Action<bool> m_RestoreCallback;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0xC8")]
		private Action<Product> m_PromotionalPurchaseCallback;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0xD0")]
		private INativeAppleStore m_Native;

		[Token(Token = "0x40000AA")]
		private static IUtil util;

		[Token(Token = "0x40000AB")]
		private static AppleStoreImpl instance;

		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0xD8")]
		private string products_json;

		[Token(Token = "0x17000023")]
		public bool simulateAskToBuy
		{
			[Token(Token = "0x60000D8")]
			[Address(RVA = "0xC57EE0", Offset = "0xC57EE0", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F0FF90]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232E8]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 5;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 5;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tUnityEngine.Purchasing.INativeAppleStore::set_simulateAskToBuy(this.m_Native, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_Native.simulateAskToBuy = value;
			}
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xC57CB4", Offset = "0xC57CB4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EFA740]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, util, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232E6]) = v41;\nL_0016:\n\tUnityEngine.Purchasing.JSONStore::.ctor(this);\n\tv46.util = util;\n\tv48.instance = this;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppleStoreImpl(IUtil util)
		{
			AppleStoreImpl.util = util;
			instance = this;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xC57DDC", Offset = "0xC57DDC", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE7ED0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, apple, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232E7]) = v41;\nL_0015:\n\tthis.store = apple;\n\tthis.m_Native = apple;\n\tv45 = new UnityEngine.Purchasing.UnityPurchasingCallback();\n\tUnityEngine.Purchasing.UnityPurchasingCallback::.ctor(v45, 0, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv61 = *([v54 @ X8_v7+B0]);\n\tv62 = 0;\n\tv63 = v61 + 8;\n\tv65 = *([v112 @ X11_v5-8]);\n\tv118 = v65 == v57;\n\tif (v118) goto L_004A;\n\tv98 = v113 + 1;\n\tv175 = v98 < v56;\n\tv92 = ~v175;\n\tv95 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_FFFFFFFF;\n\tv99 = v14;\n\tv100 = 0;\n\tv101 = 0x8909C4(v99, v57, v100, v49, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0058;\nL_004A:\n\tv176 = *([v112 @ X11_v5]);\n\tv177 = v176 << 4;\n\tv178 = v54 + v177;\n\tv179 = v178 + 0x130;\nL_0058:\n\tUnityEngine.Purchasing.INativeAppleStore::SetUnityPurchasingCallback(apple, v45);\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetNativeStore(INativeAppleStore apple)
		{
			store = apple;
			m_Native = apple;
			UnityPurchasingCallback unityPurchasingCallback = MessageCallback;
			apple.SetUnityPurchasingCallback(unityPurchasingCallback);
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0xC57ED8", Offset = "0xC57ED8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_PromotionalPurchaseCallback = callback;\n\treturn;\n")]
		public void SetApplePromotionalPurchaseInterceptorCallback(Action<Product> callback)
		{
			m_PromotionalPurchaseCallback = callback;
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xC57FA8", Offset = "0xC57FA8", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF68A8]);\n\tv27 = *([v26 @ X8_v36]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, products, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20232E9]) = v45;\nL_001D:\n\tv52 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v52);\n\tv64 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::GetEnumerator(products);\nL_0035:\n\tv184 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>::MoveNext(&v63 @ stack_-78_v4 (System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>));\n\tv230 = v184 == 0;\n\tif (v230) goto L_0054;\n\tv188 = v133 == 0;\n\tif (v188) goto L_0035;\n\tv192 = *([v133 @ stack_-68+10]);\n\tv185 = System.String::IsNullOrEmpty(*([v192 @ X8_v28+18]));\n\tv310 = v185 == 0;\n\tv189 = ~v310;\n\tif (v189) goto L_0035;\n\tv193 = *([v133 @ stack_-68+10]);\n\tv190 = v52 == 0;\n\tif (v190) goto L_005B;\n\tSystem.Collections.Generic.List`1<System.String>::Add(v52, *([v193 @ X8_v33+18]));\n\tgoto L_0035;\nL_0054:\n\tv235 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>::Dispose(&v63 @ stack_-78_v4 (System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>));\n\tgoto L_007A;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_005B:\n\tv168 = new System.NullReferenceException();\n\tgoto L_006A;\n\tgoto L_006A;\n\tgoto L_006A;\n\tgoto L_006A;\n\tgoto L_006A;\nL_006A:\n\tv140 = v166 != 1;\n\tif (v140) goto L_00CD;\n\tv327 = 0x6D2BC0(v168, v166, Il2CppMethodInfo, v30, v31, v32, v33, v34, v63, v36, v37, v38, v39, v40, v41, v42);\n\tv328 = 0x6D2490(v327, v166, Il2CppMethodInfo, v30, v31, v32, v33, v34, v63, v36, v37, v38, v39, v40, v41, v42);\n\tv216 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>::Dispose(&v63 @ stack_-78_v4 (System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>));\n\tv366 = *([v327 @ X0_v34]) == 0;\n\tv218 = ~v366;\n\tif (v218) goto L_00D1;\nL_007A:\n\tv116 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v116);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v116, \"products\", v52);\n\tv122 = this.m_Native;\n\tv117 = UnityEngine.Purchasing.MiniJson::JsonEncode(v116);\n\tv330 = *([v122 @ X19_v5 (UnityEngine.Purchasing.INativeAppleStore)]);\n\tv286 = *([v330 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]) == 0;\n\tif (v286) goto L_00B6;\n\tv368 = *([v330 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]) + 8;\nL_00A1:\n\tv383 = *([v368 @ X11_v5-8]) == UnityEngine.Purchasing.INativeAppleStore;\n\tif (v383) goto L_00B9;\n\tv369 = v369 + 1;\n\tv388 = v369 < *([v330 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]);\n\tv362 = ~v388;\n\tv368 = v368 + 0x10;\n\tv346 = ~v362;\n\tif (v346) goto L_00A1;\nL_00B6:\n\tv395 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v122, UnityEngine.Purchasing.INativeAppleStore, 6);\n\tgoto L_00C1;\nL_00B9:\n\tv390 = *([v368 @ X11_v5]) + 6;\n\tv391 = v390 << 4;\n\tv392 = v330 + v391;\n\tv395 = v392 + 0x130;\nL_00C1:\n\t*([v395 @ X0_v23])(v284, v122, v117, *([v395 @ X0_v23+8]), Il2CppMethodInfo, v31, v32, v33, v34, v63, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n\tv131 = new System.NullReferenceException();\nL_00CD:\n\tv176 = 0x6D2380(v167, v165, v157, v137, v31, v32, v33, v34, v163, v36, v37, v38, v39, v40, v41, v42);\nL_00D1:\n\tthrow System.TypeLoadException;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetStorePromotionOrder(List<Product> products)
		{
			//IL_019d: Expected I, but got O
			//IL_0044: Expected O, but got I
			//IL_0255: Expected O, but got I4
			//IL_005a: Expected O, but got I
			//IL_01d8: Expected O, but got I
			//IL_0096: Expected O, but got I
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_0285: Expected O, but got I
			//IL_0294: Expected O, but got I
			//IL_0224: Expected O, but got I
			//IL_00cd: Expected O, but got I
			List<string> list = new List<string>();
			List<Product>.Enumerator enumerator = products.GetEnumerator();
			List<Product>.Enumerator enumerator2 = default(List<Product>.Enumerator);
			object obj = default(object);
			object obj4 = default(object);
			object obj5 = default(object);
			while (true)
			{
				if (enumerator2.MoveNext())
				{
					if (obj == null)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ stack_-68+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X8_v28+18]");
					if (string.IsNullOrEmpty((string)0))
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ stack_-68+10]");
					object obj3 = 0;
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X8_v33+18]");
						list.Add((string)0);
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)obj4 != (IntPtr)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					enumerator2.Dispose();
					if (obj5 != null)
					{
						break;
					}
				}
				else
				{
					enumerator2.Dispose();
				}
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("products", list);
				INativeAppleStore native = m_Native;
				string text = MiniJson.JsonEncode(dictionary);
				IntPtr intPtr = (IntPtr)native;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_023d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]");
				object obj6 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(INativeAppleStore))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj6 = (long)(IntPtr)obj6 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_023d;
				}
				object obj7 = obj6 + 6;
				int num3 = (int)((long)(IntPtr)obj7 << 4);
				object obj8 = (long)intPtr + (long)num3;
				object obj9 = (long)(IntPtr)obj8 + 304L;
				goto IL_0311;
				IL_023d:
				((Dictionary<string, object>)native).Add((string)(object)typeof(INativeAppleStore), (object)6);
				goto IL_0311;
				IL_0311:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v395 @ X0_v23] (should have been resolved before IL gen)");
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xC5821C", Offset = "0xC5821C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB67D0]);\n\tv27 = *([v26 @ X8_v23]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, product, visibility, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20232EA]) = v44;\nL_0017:\n\tv45 = product == 0;\n\tif (v45) goto L_0070;\n\tv46 = product.<definition>k__BackingField;\n\tv75 = this.m_Native;\n\t// 34 Box v79 @ X0_v12, typeof(UnityEngine.Purchasing.AppleStorePromotionVisibility), &visibility @ X2 (UnityEngine.Purchasing.AppleStorePromotionVisibility)\n\tv112 = *([v79 @ X0_v12]);\n\t*([v112 @ X8_v15+160])(v114, v79, *([v112 @ X8_v15+168]), visibility, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv87 = \"il2cpp_vm_object_unbox\"(v79, *([v112 @ X8_v15+168]), visibility, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv183 = *([v75 @ X19_v6 (UnityEngine.Purchasing.INativeAppleStore)]);\n\tv170 = *([v183 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]) == 0;\n\tif (v170) goto L_0056;\n\tv227 = *([v183 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]) + 8;\nL_0041:\n\tv233 = *([v227 @ X11_v5-8]) == UnityEngine.Purchasing.INativeAppleStore;\n\tif (v233) goto L_0059;\n\tv228 = v228 + 1;\n\tv238 = v228 < *([v183 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]);\n\tv209 = ~v238;\n\tv227 = v227 + 0x10;\n\tv193 = ~v209;\n\tif (v193) goto L_0041;\nL_0056:\n\tv245 = 0x8909C4(v75, UnityEngine.Purchasing.INativeAppleStore, 7, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0062;\nL_0059:\n\tv240 = *([v227 @ X11_v5]) + 7;\n\tv241 = v240 << 4;\n\tv242 = v183 + v241;\n\tv245 = v242 + 0x130;\nL_0062:\n\t*([v245 @ X0_v17])(v168, v75, v46.<storeSpecificId>k__BackingField, v114, *([v245 @ X0_v17+8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0070:\n\tv72 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v72, \"product\");\n\tthrow v72;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetStorePromotionVisibility(Product product, AppleStorePromotionVisibility visibility)
		{
			//IL_005c: Expected I, but got O
			//IL_0097: Expected O, but got I
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_0136: Expected O, but got I
			//IL_0145: Expected O, but got I
			//IL_00e3: Expected O, but got I
			if (product != null)
			{
				ProductDefinition definition = product.definition;
				INativeAppleStore native = m_Native;
				object obj = visibility;
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v112 @ X8_v15+160] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				IntPtr intPtr = (IntPtr)native;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00fc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]");
				object obj3 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(INativeAppleStore))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00fc;
				}
				object obj4 = obj3 + 7;
				int num3 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr + (long)num3;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_01aa;
			}
			ArgumentNullException ex = new ArgumentNullException("product");
			throw ex;
			IL_01aa:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v245 @ X0_v17] (should have been resolved before IL gen)");
			return;
			IL_00fc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01aa;
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0xC58388", Offset = "0xC58388", Length = "0x97C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EEA6C8]);\n\tv37 = *([v36 @ X8_v150]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, json, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20232EB]) = v55;\nL_0021:\n\tv61 = UnityEngine.Purchasing.JSONSerializer::DeserializeProductDescriptions(json);\n\tv62 = this.m_Native;\n\tthis.products_json = json;\n\tv64 = this.m_Native == 0;\n\tif (v64) goto L_01A9;\n\tv66 = *([v62 @ X21_v1 (UnityEngine.Purchasing.INativeAppleStore)]);\n\tv70 = *([v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]) == 0;\n\tif (v70) goto L_004B;\n\tv269 = *([v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]) + 8;\nL_0036:\n\tv275 = *([v269 @ X11_v30-8]) == UnityEngine.Purchasing.INativeAppleStore;\n\tif (v275) goto L_004E;\n\tv270 = v270 + 1;\n\tv282 = v270 < *([v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]);\n\tv249 = ~v282;\n\tv269 = v269 + 0x10;\n\tv233 = ~v249;\n\tif (v233) goto L_0036;\nL_004B:\n\tv288 = 0x8909C4(this.m_Native, UnityEngine.Purchasing.INativeAppleStore, 4, v96, v637, v635, v43, v44, v116, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0052;\nL_004E:\n\tv284 = *([v269 @ X11_v30]) + 4;\n\tv285 = v284 << 4;\n\tv66 = v66 + v285;\n\tv288 = v66 + 0x130;\nL_0052:\n\tv66 = *([v288 @ X0_v39]);\n\t*([v288 @ X0_v39])(v292, this.m_Native, *([v288 @ X0_v39+8]), 4, v96, v637, v635, v43, v44, v116, v46, v47, v48, v49, v50, v51, v52);\n\tv197 = System.String::IsNullOrEmpty(v292);\n\tv421 = v197 == 0;\n\tv202 = ~v421;\n\tif (v202) goto L_01A9;\n\tv196 = UnityEngine.Purchasing.AppleStoreImpl::getAppleReceiptFromBase64String(v197, v292);\n\tv607 = v196 == 0;\n\tif (v607) goto L_FFFFFFFF;\n\tv694 = v196.inAppPurchaseReceipts;\n\tv695 = v196.inAppPurchaseReceipts == 0;\n\tif (v695) goto L_FFFFFFFF;\n\tv66 = v694.Length;\n\tv696 = v694.Length == 0;\n\tif (v696) goto L_FFFFFFFF;\n\tv395 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::.ctor(v395);\n\tv812 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::GetEnumerator(v61);\nL_0084:\n\tv1002 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>+Enumerator<UnityEngine.Purchasing.Extension.ProductDescription>::MoveNext(&v121 @ stack_-A0_v7 (System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>+Enumerator<UnityEngine.Purchasing.Extension.ProductDescription>));\n\tv1004 = v1002 == 0;\n\tif (v1004) goto L_0274;\n\tv1006 = new *([v937 @ X27_v10 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl+<>c__DisplayClass23_0>)])();\n\tSystem.Object::.ctor(v1006);\n\t*([v1006 @ X0_v71 (System.Object)+10]) = v856;\n\tv1022 = new System.Predicate`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>();\n\tSystem.Predicate`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::.ctor(v1022, v1006, Il2CppMethodInfo);\n\tv1042 = System.Array::FindAll(v196.inAppPurchaseReceipts, v1022);\n\tv1085 = v1042 == 0;\n\tif (v1085) goto L_0178;\n\tv66 = v1042.Length;\n\tv1090 = v1042.Length == 0;\n\tif (v1090) goto L_0178;\n\tgoto L_00BD;\n\tv1167 = *([v1117 @ X0_v119 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl+<>c>)+E0]);\n\tv1168 = v1167 == 0;\n\tv1169 = ~v1168;\n\tif (v1169) goto L_00BD;\n\tv1208 = \"il2cpp_codegen_runtime_class_init\"(v1117, v1040, v1038, v918, v911, v908, v43, v44, v117, v46, v47, v48, v49, v50, v51, v52);\n\tv1171 = UnityEngine.Purchasing.AppleStoreImpl+<>c;\nL_00BD:\n\tv1059 = v1175.<>9__23_1;\n\tv1177 = v1175.<>9__23_1 == 0;\n\tv1178 = ~v1177;\n\tif (v1178) goto L_00E7;\n\tgoto L_00D2;\n\tv1256 = *([v1170 @ X0_v120 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl+<>c>)+E0]);\n\tv1257 = v1256 == 0;\n\tv1258 = ~v1257;\n\tif (v1258) goto L_00D2;\n\tv1260 = \"il2cpp_codegen_runtime_class_init\"(v1170, v1040, v1038, v918, v911, v908, v43, v44, v117, v46, v47, v48, v49, v50, v51, v52);\n\tv1342 = UnityEngine.Purchasing.AppleStoreImpl+<>c;\n\tv1262 = *([v1342 @ X8_v143+B8]);\nL_00D2:\n\tv1266 = new System.Comparison`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>();\n\tSystem.Comparison`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::.ctor(v1266, v1261.<>9, Il2CppMethodInfo);\n\tv1225.<>9__23_1 = v1266;\nL_00E7:\n\tSystem.Array::Sort(v1042, v1059);\n\tv66 = v1042.Length;\n\tv1072 = v1042.Length == 0;\n\tif (v1072) goto L_027A;\n\tv931 = v1042[0];\n\tgoto L_00FD;\n\tv1346 = *([v1302 @ X0_v123+E0]);\n\tv1347 = v1346 == 0;\n\tv1348 = ~v1347;\n\tif (v1348) goto L_00FD;\n\tv1350 = \"il2cpp_codegen_runtime_class_init\"(v1302, v1066, v1064, v919, v911, v908, v43, v44, v117, v46, v47, v48, v49, v50, v51, v52);\nL_00FD:\n\tv1102 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.AppleStoreProductType);\n\tv1418 = v931.<productType>k__BackingField;\n\tv1421 = System.Array::Sort(&v1418 @ X8_v105 (System.Int32), 0);\n\tgoto L_0116;\n\tv1473 = *([v1457 @ X0_v129+E0]);\n\tv1474 = v1473 == 0;\n\tv1475 = ~v1474;\n\tif (v1475) goto L_0116;\n\tv1477 = \"il2cpp_codegen_runtime_class_init\"(v1457, v1420, v1064, v919, v911, v908, v43, v44, v117, v46, v47, v48, v49, v50, v51, v52);\nL_0116:\n\tv1150 = System.Enum::Parse(v1102, v1421);\n\tv949 = v949_asT == 0;\n\tif (v949) goto L_0280;\n\tv1246 = \"il2cpp_vm_object_unbox\"(v1150, UnityEngine.Purchasing.AppleStoreProductType, 0, v919, v637, v635, v43, v44, v121, v46, v47, v48, v49, v50, v51, v52);\n\tv66 = *([v1246 @ X0_v133]);\n\tv964 = *([v1246 @ X0_v133]) == 1;\n\tif (v964) goto L_0181;\n\tv948 = *([v1246 @ X0_v133]) != 3;\n\tif (v948) goto L_0183;\n\tv1497 = new UnityEngine.Purchasing.SubscriptionInfo();\n\tUnityEngine.Purchasing.SubscriptionInfo::.ctor(v1497, v931, 0);\n\tv1408 = UnityEngine.Purchasing.SubscriptionInfo::isExpired(v1497);\n\tv979 = *([v1006 @ X0_v71 (System.Object)+10]);\n\tv1506 = v1408 == 0;\n\tif (v1506) goto L_01A0;\n\tv1511 = new UnityEngine.Purchasing.Extension.ProductDescription();\n\tUnityEngine.Purchasing.Extension.ProductDescription::.ctor(v1511, v979.<storeSpecificId>k__BackingField, v979.<metadata>k__BackingField, v292, v931.<transactionID>k__BackingField);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v395, v1511);\n\tgoto L_0084;\nL_0178:\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v395, *([v1006 @ X0_v71 (System.Object)+10]));\n\tgoto L_0084;\nL_0181:\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v395, *([v1006 @ X0_v71 (System.Object)+10]));\n\tgoto L_0084;\nL_0183:\n\tv66 = *([v1006 @ X0_v71 (System.Object)+10]);\n\tv1502 = new UnityEngine.Purchasing.Extension.ProductDescription();\n\tUnityEngine.Purchasing.Extension.ProductDescription::.ctor(v1502, *([v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+10]), *([v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+20]), v292, v931.<transactionID>k__BackingField);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v395, v1502);\n\tgoto L_0084;\nL_01A0:\n\tv993 = v395 == 0;\n\tif (v993) goto L_028F;\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v395, v979);\n\tgoto L_0084;\nL_01A9:\n\tv216 = this.unity;\n\tv226 = v190 != 0;\n\tif (v226) goto L_FFFFFFFF;\n\tgoto L_01BC;\nL_01BC:\n\tv294 = *([v216 @ X22_v3 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv298 = *([v294 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v298) goto L_01DF;\n\tv509 = *([v294 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_01CA:\n\tv515 = *([v509 @ X11_v19-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v515) goto L_01E2;\n\tv510 = v510 + 1;\n\tv608 = v510 < *([v294 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv444 = ~v608;\n\tv509 = v509 + 0x10;\n\tv428 = ~v444;\n\tif (v428) goto L_01CA;\nL_01DF:\n\tv615 = 0x8909C4(v216, UnityEngine.Purchasing.Extension.IStoreCallback, 2, v96, v637, v635, v43, v44, v116, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_01E6;\nL_01E2:\n\tv610 = *([v509 @ X11_v19]) + 2;\n\tv611 = v610 << 4;\n\tv66 = v294 + v611;\n\tv615 \n// ... truncated")]
		public unsafe override void OnProductsRetrieved(string json)
		{
			//IL_000d: Expected I, but got O
			//IL_0529: Expected I, but got O
			//IL_0b94: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0ca5: Expected I, but got O
			//IL_0564: Expected O, but got I
			//IL_0108: Expected O, but got I4
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00f6: Expected O, but got I
			//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e6: Expected O, but got Unknown
			//IL_0612: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0758: Expected I, but got O
			//IL_05b0: Expected O, but got I
			//IL_0659: Expected I, but got O
			//IL_0793: Expected O, but got I
			//IL_0d05: Expected I, but got O
			//IL_0694: Expected O, but got I
			//IL_0819: Unknown result type (might be due to invalid IL or missing references)
			//IL_081e: Expected O, but got Unknown
			//IL_084a: Expected O, but got I
			//IL_07df: Expected O, but got I
			//IL_071a: Unknown result type (might be due to invalid IL or missing references)
			//IL_071f: Expected O, but got Unknown
			//IL_074b: Expected O, but got I
			//IL_01ab: Expected I, but got O
			//IL_06e0: Expected O, but got I
			//IL_03e7: Expected O, but got I
			//IL_03ed: Expected O, but got I
			//IL_0284: Expected O, but got I4
			//IL_02ac: Expected I4, but got O
			//IL_02db: Expected I, but got O
			//IL_0407: Expected O, but got I
			//IL_040f: Expected O, but got I
			//IL_041d: Expected I, but got O
			//IL_0461: Expected O, but got I
			//IL_0461: Expected O, but got I
			//IL_0481: Expected O, but got I4
			//IL_04a4: Expected I, but got O
			//IL_0349: Expected O, but got I
			//IL_04ca: Expected I4, but got O
			//IL_04f8: Expected I, but got O
			//IL_03aa: Expected O, but got I4
			//IL_03cd: Expected I, but got O
			List<ProductDescription> list = JSONSerializer.DeserializeProductDescriptions(json);
			INativeAppleStore native = m_Native;
			products_json = json;
			bool flag = m_Native == null;
			List<ProductDescription> list2 = (List<ProductDescription>)m_Native;
			List<ProductDescription> list3 = list;
			if (flag)
			{
				goto IL_0b38;
			}
			IntPtr intPtr = (IntPtr)native;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ X11_v30-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeAppleStore))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
				bool flag2 = (long)num2 < 0L;
				bool flag3 = !flag2;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			intPtr = (IntPtr)(void*)((long)intPtr + (long)num3);
			object obj3 = (long)intPtr + 304L;
			goto IL_0b8c;
			IL_06f9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			int num4 = 8;
			goto IL_0cfd;
			IL_0cc4:
			INativeAppleStore native2 = m_Native;
			intPtr = (IntPtr)native2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_07f8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]");
			object obj4 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v844 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeAppleStore))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
				bool flag4 = (long)num6 < 0L;
				bool flag5 = !flag4;
				obj4 = (long)(IntPtr)obj4 + 16L;
				if (!flag5)
				{
					continue;
				}
				goto IL_07f8;
			}
			object obj5 = obj4 + 3;
			int num7 = (int)((long)(IntPtr)obj5 << 4);
			intPtr = (IntPtr)(void*)((long)intPtr + (long)num7);
			object obj6 = (long)intPtr + 304L;
			goto IL_0d3e;
			IL_0d3e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v890 @ X0_v12] (should have been resolved before IL gen)");
			return;
			IL_0b38:
			IStoreCallback storeCallback = unity;
			if (list2 != null)
			{
				list3 = list2;
			}
			IntPtr intPtr2 = (IntPtr)storeCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_05c9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
			object obj7 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X11_v19-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				bool flag6 = (long)num9 < 0L;
				bool flag7 = !flag6;
				obj7 = (long)(IntPtr)obj7 + 16L;
				if (!flag7)
				{
					continue;
				}
				goto IL_05c9;
			}
			object obj8 = obj7 + 2;
			int num10 = (int)((long)(IntPtr)obj8 << 4);
			intPtr = (IntPtr)(void*)((long)intPtr2 + (long)num10);
			object obj9 = (long)intPtr + 304L;
			goto IL_0c9d;
			IL_05c9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0c9d;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0b8c;
			IL_0b8c:
			intPtr = (IntPtr)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v288 @ X0_v39] (should have been resolved before IL gen)");
			string text = default(string);
			bool flag8 = string.IsNullOrEmpty(text);
			bool flag9 = !flag8;
			bool flag10 = !flag9;
			list2 = null;
			list3 = list;
			if (!flag10)
			{
				AppleReceipt appleReceiptFromBase64String = ((AppleStoreImpl)flag8).getAppleReceiptFromBase64String(text);
				if (appleReceiptFromBase64String != null)
				{
					AppleInAppPurchaseReceipt[] inAppPurchaseReceipts = appleReceiptFromBase64String.inAppPurchaseReceipts;
					if (appleReceiptFromBase64String.inAppPurchaseReceipts != null)
					{
						intPtr = (IntPtr)inAppPurchaseReceipts.Length;
						if (inAppPurchaseReceipts.Length != 0)
						{
							List<ProductDescription> list4 = new List<ProductDescription>();
							List<ProductDescription>.Enumerator enumerator = list.GetEnumerator();
							IntPtr intPtr3 = (IntPtr)typeof(_003C_003Ec__DisplayClass23_0);
							List<ProductDescription>.Enumerator enumerator2 = default(List<ProductDescription>.Enumerator);
							string value = default(string);
							object obj11 = default(object);
							object obj13 = default(object);
							object obj14 = default(object);
							string text4 = default(string);
							string text5 = default(string);
							List<ProductDescription>.Enumerator enumerator4 = default(List<ProductDescription>.Enumerator);
							while (true)
							{
								object obj12;
								string transactionID;
								string text2;
								List<ProductDescription>.Enumerator enumerator3;
								string text3;
								int num11;
								NullReferenceException ex;
								if (enumerator2.MoveNext())
								{
									object CS_0024_003C_003E8__locals1 = new object();
									Predicate<AppleInAppPurchaseReceipt> match = delegate(AppleInAppPurchaseReceipt r)
									{
										ProductDescription productDescription2 = ((_003C_003Ec__DisplayClass23_0)CS_0024_003C_003E8__locals1).productDescription;
										return r.productID == productDescription2.storeSpecificId;
									};
									AppleInAppPurchaseReceipt[] array = Array.FindAll(appleReceiptFromBase64String.inAppPurchaseReceipts, match);
									if (array != null)
									{
										intPtr = (IntPtr)array.Length;
										if (array.Length != 0)
										{
											Comparison<AppleInAppPurchaseReceipt> comparison = _003C_003Ec._003C_003E9__23_1;
											bool flag11 = _003C_003Ec._003C_003E9__23_1 == null;
											bool flag12 = !flag11;
											IntPtr intPtr4 = (IntPtr)0;
											if (!flag12)
											{
												Comparison<AppleInAppPurchaseReceipt> comparison2 = (_003C_003Ec._003C_003E9__23_1 = delegate(AppleInAppPurchaseReceipt b, AppleInAppPurchaseReceipt a)
												{
													DateTime purchaseDate2 = a.purchaseDate;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
													int result2 = default(int);
													return result2;
												});
												intPtr4 = (IntPtr)0;
												comparison = comparison2;
											}
											Array.Sort(array, comparison);
											intPtr = (IntPtr)array.Length;
											if (array.Length != 0)
											{
												AppleInAppPurchaseReceipt appleInAppPurchaseReceipt = array[0];
												Type typeFromHandle = typeof(AppleStoreProductType);
												int productType = appleInAppPurchaseReceipt.productType;
												Array.Sort((AppleInAppPurchaseReceipt[])productType, (Comparison<AppleInAppPurchaseReceipt>)null);
												object obj10 = Enum.Parse(typeFromHandle, value);
												if ((int)((obj10 is AppleStoreProductType) ? obj10 : null) != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
													intPtr = (IntPtr)obj11;
													if ((IntPtr)obj11 != (IntPtr)1)
													{
														if ((IntPtr)obj11 == (IntPtr)3)
														{
															SubscriptionInfo subscriptionInfo = new SubscriptionInfo(appleInAppPurchaseReceipt, null);
															Result result = subscriptionInfo.isExpired();
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ X0_v71 (System.Object)+10]");
															ProductDescription productDescription = (ProductDescription)0;
															if (result != Result.True)
															{
																ProductDescription item = new ProductDescription(productDescription.storeSpecificId, productDescription.metadata, text, appleInAppPurchaseReceipt.transactionID);
																list4.Add(item);
																obj12 = 0;
																transactionID = appleInAppPurchaseReceipt.transactionID;
																text2 = text;
																intPtr3 = (IntPtr)typeof(_003C_003Ec__DisplayClass23_0);
																continue;
															}
															bool flag13 = list4 == null;
															text2 = null;
															text3 = null;
															num11 = (int)productDescription;
															if (!flag13)
															{
																list4.Add(productDescription);
																text2 = null;
																intPtr3 = (IntPtr)typeof(_003C_003Ec__DisplayClass23_0);
																continue;
															}
															ex = new NullReferenceException();
															bool flag14 = (IntPtr)productDescription != (IntPtr)1;
															enumerator3 = enumerator2;
															if (!flag14)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
																enumerator2.Dispose();
																if (obj13 == null)
																{
																	break;
																}
																goto IL_0a8e;
															}
															goto IL_0ad2;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ X0_v71 (System.Object)+10]");
														intPtr = (IntPtr)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+10]");
														IntPtr intPtr5 = (IntPtr)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+20]");
														ProductDescription item2 = new ProductDescription((string)(long)intPtr5, (ProductMetadata)0, text, appleInAppPurchaseReceipt.transactionID);
														list4.Add(item2);
														obj12 = 0;
														transactionID = appleInAppPurchaseReceipt.transactionID;
														text2 = text;
														intPtr3 = (IntPtr)typeof(_003C_003Ec__DisplayClass23_0);
														continue;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ X0_v71 (System.Object)+10]");
													list4.Add((ProductDescription)0);
													text2 = (string)(long)intPtr4;
													intPtr3 = (IntPtr)typeof(_003C_003Ec__DisplayClass23_0);
													continue;
												}
												InvalidCastException ex2 = new InvalidCastException();
												throw new NullReferenceException();
											}
											IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
											throw ex3;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1006 @ X0_v71 (System.Object)+10]");
									list4.Add((ProductDescription)0);
									text2 = (string)0;
									continue;
								}
								enumerator2.Dispose();
								break;
								IL_0a8e:
								TypeLoadException ex4 = new TypeLoadException();
								obj12 = obj14;
								transactionID = text4;
								text2 = text5;
								enumerator3 = enumerator4;
								text3 = null;
								num11 = 0;
								ex = (NullReferenceException)(object)ex4;
								goto IL_0ad2;
								IL_0ad2:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
								goto IL_0a8e;
							}
							AppleInAppPurchaseReceipt[] inAppPurchaseReceipts2 = appleReceiptFromBase64String.inAppPurchaseReceipts;
							intPtr = (IntPtr)inAppPurchaseReceipts2.Length;
							if (inAppPurchaseReceipts2.Length >= 1)
							{
								int num12 = 0;
								do
								{
									AppleInAppPurchaseReceipt appleInAppPurchaseReceipt2 = inAppPurchaseReceipts2[num12];
									Console.WriteLine("                    productID: {0}", appleInAppPurchaseReceipt2.productID);
									Console.WriteLine("                transactionID: {0}", appleInAppPurchaseReceipt2.transactionID);
									Console.WriteLine("originalTransactionIdentifier: {0}", appleInAppPurchaseReceipt2.originalTransactionIdentifier);
									DateTime purchaseDate = appleInAppPurchaseReceipt2.purchaseDate;
									object arg = purchaseDate;
									Console.WriteLine("                 purchaseDate: {0}", arg);
									DateTime originalPurchaseDate = appleInAppPurchaseReceipt2.originalPurchaseDate;
									object arg2 = originalPurchaseDate;
									Console.WriteLine("         originalPurchaseDate: {0}", arg2);
									DateTime subscriptionExpirationDate = appleInAppPurchaseReceipt2.subscriptionExpirationDate;
									object arg3 = subscriptionExpirationDate;
									Console.WriteLine("   subscriptionExpirationDate: {0}", arg3);
									num12++;
								}
								while (num12 < inAppPurchaseReceipts2.Length);
								List<ProductDescription>.Enumerator enumerator5 = enumerator2;
								list2 = list4;
								list3 = list;
							}
							else
							{
								List<ProductDescription>.Enumerator enumerator5 = enumerator2;
								list2 = list4;
								list3 = list;
							}
							goto IL_0b38;
						}
					}
				}
				list2 = null;
				list3 = list;
			}
			goto IL_0b38;
			IL_07f8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 3;
			goto IL_0d3e;
			IL_0c9d:
			intPtr = (IntPtr)obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ X0_v5+8]");
			num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v615 @ X0_v5] (should have been resolved before IL gen)");
			Promo.ProvideProductsToAds(this, unity);
			if (m_PromotionalPurchaseCallback == null)
			{
				goto IL_0cc4;
			}
			INativeAppleStore native3 = m_Native;
			intPtr = (IntPtr)native3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_06f9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]");
			object obj15 = 0L + 8L;
			int num13 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ X11_v14-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeAppleStore))
				{
					break;
				}
				num13++;
				int num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v28 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
				bool flag15 = (long)num14 < 0L;
				bool flag16 = !flag15;
				obj15 = (long)(IntPtr)obj15 + 16L;
				if (!flag16)
				{
					continue;
				}
				goto IL_06f9;
			}
			object obj16 = obj15 + 8;
			int num15 = (int)((long)(IntPtr)obj16 << 4);
			intPtr = (IntPtr)(void*)((long)intPtr + (long)num15);
			object obj17 = (long)intPtr + 304L;
			goto IL_0cfd;
			IL_0cfd:
			intPtr = (IntPtr)obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v866 @ X0_v18] (should have been resolved before IL gen)");
			goto IL_0cc4;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0xC59388", Offset = "0xC59388", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB2EC0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232EC]) = v41;\nL_0015:\n\tv42 = this.m_Native;\n\tthis.m_RestoreCallback = callback;\n\tv45 = *([v42 @ X19_v2 (UnityEngine.Purchasing.INativeAppleStore)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]) == 0;\n\tif (v49) goto L_003D;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]) + 8;\nL_0028:\n\tv109 = *([v103 @ X11_v5-8]) == UnityEngine.Purchasing.INativeAppleStore;\n\tif (v109) goto L_0040;\n\tv104 = v104 + 1;\n\tv164 = v104 < *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]);\n\tv83 = ~v164;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0028;\nL_003D:\n\tv171 = 0x8909C4(v42, UnityEngine.Purchasing.INativeAppleStore, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0044;\nL_0040:\n\tv166 = *([v103 @ X11_v5]) + 1;\n\tv167 = v166 << 4;\n\tv168 = v45 + v167;\n\tv171 = v168 + 0x130;\nL_0044:\n\tv122 = *([v171 @ X0_v4]);\n\tv144 = *([v171 @ X0_v4+8]);\n\t// 77 IndirectJump v122 @ X2_v2, v42 @ X19_v2 (UnityEngine.Purchasing.INativeAppleStore), v42 @ X19_v2 (UnityEngine.Purchasing.INativeAppleStore), v144 @ X1_v2, v122 @ X2_v2, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactions(Action<bool> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_0156: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			INativeAppleStore native = m_Native;
			m_RestoreCallback = callback;
			IntPtr intPtr = (IntPtr)native;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeAppleStore))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_013e;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_013e;
			IL_013e:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v122 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0xC59450", Offset = "0xC59450", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF0428]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, successCallback, errorCallback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20232ED]) = v44;\nL_0017:\n\tv45 = this.m_Native;\n\tthis.m_RefreshReceiptError = errorCallback;\n\tthis.m_RefreshReceiptSuccess = successCallback;\n\tv48 = *([v45 @ X19_v2 (UnityEngine.Purchasing.INativeAppleStore)]);\n\tv52 = *([v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]) == 0;\n\tif (v52) goto L_0040;\n\tv106 = *([v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]) + 8;\nL_002B:\n\tv112 = *([v106 @ X11_v5-8]) == UnityEngine.Purchasing.INativeAppleStore;\n\tif (v112) goto L_0043;\n\tv107 = v107 + 1;\n\tv169 = v107 < *([v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]);\n\tv86 = ~v169;\n\tv106 = v106 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_002B;\nL_0040:\n\tv176 = 0x8909C4(v45, UnityEngine.Purchasing.INativeAppleStore, 2, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0047;\nL_0043:\n\tv171 = *([v106 @ X11_v5]) + 2;\n\tv172 = v171 << 4;\n\tv173 = v48 + v172;\n\tv176 = v173 + 0x130;\nL_0047:\n\tv125 = *([v176 @ X0_v4]);\n\tv147 = *([v176 @ X0_v4+8]);\n\t// 81 IndirectJump v125 @ X2_v2, v45 @ X19_v2 (UnityEngine.Purchasing.INativeAppleStore), v45 @ X19_v2 (UnityEngine.Purchasing.INativeAppleStore), v147 @ X1_v2, v125 @ X2_v2, methodInfo @ X3 (Il2CppMethodInfo), v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RefreshAppReceipt(Action<string> successCallback, Action errorCallback)
		{
			//IL_000d: Expected I, but got O
			//IL_0160: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			INativeAppleStore native = m_Native;
			m_RefreshReceiptError = errorCallback;
			m_RefreshReceiptSuccess = successCallback;
			IntPtr intPtr = (IntPtr)native;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeAppleStore))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeAppleStore>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0148;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0148;
			IL_0148:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v125 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0xC5951C", Offset = "0xC5951C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_DeferredCallback = callback;\n\treturn;\n")]
		public void RegisterPurchaseDeferredListener(Action<Product> callback)
		{
			m_DeferredCallback = callback;
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0xC59524", Offset = "0xC59524", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ECF1B8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20232EE]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 9;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 9;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tUnityEngine.Purchasing.INativeAppleStore::ContinuePromotionalPurchases(this.m_Native);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ContinuePromotionalPurchases()
		{
			m_Native.ContinuePromotionalPurchases();
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0xC595DC", Offset = "0xC595DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Purchasing.JSONSerializer::DeserializeSubscriptionDescriptions(this.products_json);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Dictionary<string, string> GetIntroductoryPriceDictionary()
		{
			return JSONSerializer.DeserializeSubscriptionDescriptions(products_json);
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0xC59A80", Offset = "0xC59A80", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EFC5B8]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232EF]) = v41;\nL_0016:\n\tv43 = this.m_DeferredCallback == 0;\n\tif (v43) goto L_0066;\n\tgoto L_0048;\n\tv164 = *([v105 @ X8_v6+B0]);\n\tv165 = 0;\n\tv166 = v164 + 8;\n\tv168 = *([v210 @ X11_v7-8]);\n\tv216 = v168 == v108;\n\tif (v216) goto L_0041;\n\tv190 = v211 + 1;\n\tv221 = v190 < v107;\n\tv186 = ~v221;\n\tv188 = v210 + 0x10;\n\tv170 = ~v186;\n\tif (v170) goto L_FFFFFFFF;\n\tv191 = v44;\n\tv192 = 0;\n\tv193 = 0x8909C4(v191, v108, v192, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0048;\nL_0041:\n\tv222 = *([v210 @ X11_v7]);\n\tv223 = v222 << 4;\n\tv224 = v105 + v223;\n\tv225 = v224 + 0x130;\nL_0048:\n\tv197 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(this.unity);\n\tv93 = UnityEngine.Purchasing.ProductCollection::WithStoreSpecificID(v197, productId);\n\tv95 = v93 == 0;\n\tif (v95) goto L_0066;\n\tSystem.Action`1<UnityEngine.Purchasing.Product>::Invoke(this.m_DeferredCallback, v93);\n\treturn;\nL_0066:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseDeferred(string productId)
		{
			if (m_DeferredCallback != null)
			{
				ProductCollection products = unity.products;
				Product product = products.WithStoreSpecificID(productId);
				if (product != null)
				{
					m_DeferredCallback(product);
				}
			}
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0xC59B8C", Offset = "0xC59B8C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EBB688]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232F0]) = v41;\nL_0016:\n\tv43 = this.m_PromotionalPurchaseCallback == 0;\n\tif (v43) goto L_0066;\n\tgoto L_0048;\n\tv164 = *([v105 @ X8_v6+B0]);\n\tv165 = 0;\n\tv166 = v164 + 8;\n\tv168 = *([v210 @ X11_v7-8]);\n\tv216 = v168 == v108;\n\tif (v216) goto L_0041;\n\tv190 = v211 + 1;\n\tv221 = v190 < v107;\n\tv186 = ~v221;\n\tv188 = v210 + 0x10;\n\tv170 = ~v186;\n\tif (v170) goto L_FFFFFFFF;\n\tv191 = v44;\n\tv192 = 0;\n\tv193 = 0x8909C4(v191, v108, v192, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0048;\nL_0041:\n\tv222 = *([v210 @ X11_v7]);\n\tv223 = v222 << 4;\n\tv224 = v105 + v223;\n\tv225 = v224 + 0x130;\nL_0048:\n\tv197 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(this.unity);\n\tv93 = UnityEngine.Purchasing.ProductCollection::WithStoreSpecificID(v197, productId);\n\tv95 = v93 == 0;\n\tif (v95) goto L_0066;\n\tSystem.Action`1<UnityEngine.Purchasing.Product>::Invoke(this.m_PromotionalPurchaseCallback, v93);\n\treturn;\nL_0066:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPromotionalPurchaseAttempted(string productId)
		{
			if (m_PromotionalPurchaseCallback != null)
			{
				ProductCollection products = unity.products;
				Product product = products.WithStoreSpecificID(productId);
				if (product != null)
				{
					m_PromotionalPurchaseCallback(product);
				}
			}
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0xC59C98", Offset = "0xC59C98", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0F838]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20232F1]) = v38;\nL_0014:\n\tv40 = this.m_RestoreCallback == 0;\n\tif (v40) goto L_0026;\n\tSystem.Action`1<System.Boolean>::Invoke(this.m_RestoreCallback, 1);\n\treturn;\nL_0026:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTransactionsRestoredSuccess()
		{
			if (m_RestoreCallback != null)
			{
				m_RestoreCallback(obj: true);
			}
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0xC59CFC", Offset = "0xC59CFC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED1A00]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20232F2]) = v38;\nL_0014:\n\tv40 = this.m_RestoreCallback == 0;\n\tif (v40) goto L_0026;\n\tSystem.Action`1<System.Boolean>::Invoke(this.m_RestoreCallback, 0);\n\treturn;\nL_0026:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTransactionsRestoredFail(string error)
		{
			if (m_RestoreCallback != null)
			{
				m_RestoreCallback(obj: false);
			}
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0xC59D60", Offset = "0xC59D60", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0EED0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, receipt, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232F3]) = v41;\nL_0015:\n\tv42 = receipt == 0;\n\tif (v42) goto L_002C;\n\tv44 = this.m_RefreshReceiptSuccess == 0;\n\tif (v44) goto L_002C;\n\tSystem.Action`1<System.String>::Invoke(this.m_RefreshReceiptSuccess, receipt);\n\treturn;\nL_002C:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAppReceiptRetrieved(string receipt)
		{
			if (receipt != null && m_RefreshReceiptSuccess != null)
			{
				m_RefreshReceiptSuccess(receipt);
			}
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xC59DD8", Offset = "0xC59DD8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_RefreshReceiptError == 0;\n\tif (v2) goto L_0006;\n\tSystem.Action::Invoke(this.m_RefreshReceiptError);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAppReceiptRefreshedFailed()
		{
			if (m_RefreshReceiptError != null)
			{
				m_RefreshReceiptError();
			}
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x72D30C", Offset = "0x72D30C")]
		[Token(Token = "0x60000E7")]
		[Address(RVA = "0xC57B78", Offset = "0xC57B78", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EB09C8]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, payload, receipt, transactionId, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20232F4]) = v47;\nL_001C:\n\tv51 = new UnityEngine.Purchasing.AppleStoreImpl+<>c__DisplayClass36_0();\n\tSystem.Object::.ctor(v51);\n\tv51.subject = subject;\n\tv51.payload = payload;\n\tv51.receipt = receipt;\n\tv51.transactionId = transactionId;\n\tv61 = v59.util;\n\tv63 = new System.Action();\n\tSystem.Action::.ctor(v63, v51, Il2CppMethodInfo);\n\tv151 = *([v61 @ X19_v3 (Uniject.IUtil)]);\n\tv135 = *([v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v135) goto L_005C;\n\tv195 = *([v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_0047:\n\tv201 = *([v195 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v201) goto L_005F;\n\tv196 = v196 + 1;\n\tv206 = v196 < *([v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv177 = ~v206;\n\tv195 = v195 + 0x10;\n\tv161 = ~v177;\n\tif (v161) goto L_0047;\nL_005C:\n\tv213 = 0x8909C4(v61, Uniject.IUtil, 0xF, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0063;\nL_005F:\n\tv208 = *([v195 @ X11_v5]) + 0xF;\n\tv209 = v208 << 4;\n\tv210 = v151 + v209;\n\tv213 = v210 + 0x130;\nL_0063:\n\tv127 = *([v213 @ X0_v9]);\n\tv125 = *([v213 @ X0_v9+8]);\n\t// 111 IndirectJump v127 @ X3_v3, v61 @ X19_v3 (Uniject.IUtil), v61 @ X19_v3 (Uniject.IUtil), v63 @ X0_v8 (System.Action), v125 @ X2_v4, v127 @ X3_v3, methodInfo @ X4 (Il2CppMethodInfo), v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void MessageCallback(string subject, string payload, string receipt, string transactionId)
		{
			//IL_0063: Expected I, but got O
			//IL_01a2: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_013d: Expected O, but got I
			//IL_014c: Expected O, but got I
			//IL_00ea: Expected O, but got I
			IUtil util = AppleStoreImpl.util;
			Action action = delegate
			{
				instance.ProcessMessage(subject, payload, receipt, transactionId);
			};
			IntPtr intPtr = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0103;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0103;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_018a;
			IL_0103:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_018a;
			IL_018a:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ X0_v9+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X3_v3 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xC59DF4", Offset = "0xC59DF4", Length = "0x394")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1F09D88]);\n\tv35 = *([v34 @ X8_v54]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, subject, payload, receipt, transactionId, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20232F5]) = v50;\nL_001B:\n\tv51 = subject == 0;\n\tif (v51) goto L_01B3;\n\tv53 = <PrivateImplementationDetails>::ComputeStringHash(subject);\n\tv229 = v53 < 0x8FB9271E;\n\tv230 = ~v229;\n\tv231 = v53 - 0x8FB9271E;\n\tv233 = v231 == 0;\n\tv238 = ~v233;\n\tv239 = v230 & v238;\n\tif (v239) goto L_006B;\n\tv373 = v53 < 0x4129DEDF;\n\tv374 = ~v373;\n\tv375 = v53 - 0x4129DEDF;\n\tv377 = v375 == 0;\n\tv382 = ~v377;\n\tv81 = v374 & v382;\n\tif (v81) goto L_00B0;\n\tv137 = v53 == 0x19B025D5;\n\tif (v137) goto L_0125;\n\tv77 = v53 != 0x4129DEDF;\n\tif (v77) goto L_01B3;\n\tv181 = System.String::op_Equality(subject, \"onTransactionsRestoredFail\");\n\tv193 = v181 == 0;\n\tif (v193) goto L_01B3;\n\tUnityEngine.Purchasing.AppleStoreImpl::OnTransactionsRestoredFail(this, \"onTransactionsRestoredFail\");\n\treturn;\nL_006B:\n\tv385 = v53 < 0xC9C42AA0;\n\tv386 = ~v385;\n\tv387 = v53 - 0xC9C42AA0;\n\tv389 = v387 == 0;\n\tv394 = ~v389;\n\tv82 = v386 & v394;\n\tif (v82) goto L_00EB;\n\tv138 = v53 == 0xC5F05D66;\n\tif (v138) goto L_013B;\n\tv78 = v53 != 0xC9C42AA0;\n\tif (v78) goto L_01B3;\n\tv182 = System.String::op_Equality(subject, \"OnPurchaseSucceeded\");\n\tv194 = v182 == 0;\n\tif (v194) goto L_01B3;\n\tv347 = this->klass;\n\tv243 = this->klass->vtable[21];\n\tv241 = this->klass->vtable[21];\n\t// 169 IndirectJump v243 @ X5_v1, this @ X0 (UnityEngine.Purchasing.AppleStoreImpl), this @ X0 (UnityEngine.Purchasing.AppleStoreImpl), payload @ X2 (System.String), receipt @ X3 (System.String), transactionId @ X4 (System.String), v241 @ X4_v1, v243 @ X5_v1, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_00B0:\n\tv139 = v53 == 0x8FB9271E;\n\tif (v139) goto L_0154;\n\tv140 = v53 == 0x5AD0E871;\n\tif (v140) goto L_0169;\n\tv79 = v53 != 0x63D12BCB;\n\tif (v79) goto L_01B3;\n\tv183 = System.String::op_Equality(subject, \"onProductPurchaseDeferred\");\n\tv195 = v183 == 0;\n\tif (v195) goto L_01B3;\n\tUnityEngine.Purchasing.AppleStoreImpl::OnPurchaseDeferred(this, payload);\n\treturn;\nL_00EB:\n\tv141 = v53 == 0xD7E9ECED;\n\tif (v141) goto L_0181;\n\tv142 = v53 == 0xDBACFE1C;\n\tif (v142) goto L_0197;\n\tv80 = v53 != 0xDF91F2FC;\n\tif (v80) goto L_01B3;\n\tv184 = System.String::op_Equality(subject, \"OnSetupFailed\");\n\tv196 = v184 == 0;\n\tif (v196) goto L_01B3;\n\tUnityEngine.Purchasing.JSONStore::OnSetupFailed(this, payload);\n\treturn;\nL_0125:\n\tv185 = System.String::op_Equality(subject, \"onPromotionalPurchaseAttempted\");\n\tv197 = v185 == 0;\n\tif (v197) goto L_01B3;\n\tUnityEngine.Purchasing.AppleStoreImpl::OnPromotionalPurchaseAttempted(this, payload);\n\treturn;\nL_013B:\n\tv186 = System.String::op_Equality(subject, \"OnPurchaseFailed\");\n\tv198 = v186 == 0;\n\tif (v198) goto L_01B3;\n\tv447 = UnityEngine.Purchasing.JSONSerializer::DeserializeFailureReason(payload);\n\tUnityEngine.Purchasing.JSONStore::OnPurchaseFailed(this, v447, payload);\n\treturn;\nL_0154:\n\tv187 = System.String::op_Equality(subject, \"onTransactionsRestoredSuccess\");\n\tv199 = v187 == 0;\n\tif (v199) goto L_01B3;\n\tUnityEngine.Purchasing.AppleStoreImpl::OnTransactionsRestoredSuccess(this);\n\treturn;\nL_0169:\n\tv188 = System.String::op_Equality(subject, \"onAppReceiptRefreshFailed\");\n\tv200 = v188 == 0;\n\tif (v200) goto L_01B3;\n\tv201 = this.m_RefreshReceiptError == 0;\n\tif (v201) goto L_01B3;\n\tSystem.Action::Invoke(this.m_RefreshReceiptError);\n\treturn;\nL_0181:\n\tv190 = System.String::op_Equality(subject, \"onAppReceiptRefreshed\");\n\tv202 = v190 == 0;\n\tif (v202) goto L_01B3;\n\tUnityEngine.Purchasing.AppleStoreImpl::OnAppReceiptRetrieved(this, payload);\n\treturn;\nL_0197:\n\tv191 = System.String::op_Equality(subject, \"OnProductsRetrieved\");\n\tv203 = v191 == 0;\n\tif (v203) goto L_01B3;\n\tv348 = this->klass;\n\tv246 = this->klass->vtable[20];\n\tv270 = this->klass->vtable[20];\n\t// 425 IndirectJump v246 @ X3_v1, this @ X0 (UnityEngine.Purchasing.AppleStoreImpl), this @ X0 (UnityEngine.Purchasing.AppleStoreImpl), payload @ X2 (System.String), v270 @ X2_v4, v246 @ X3_v1, transactionId @ X4 (System.String), methodInfo @ X5 (Il2CppMethodInfo), v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_01B3:\n\treturn;\n// 328 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ProcessMessage(string subject, string payload, string receipt, string transactionId)
		{
			//IL_0042: Expected I4, but got I8
			//IL_017c: Expected I4, but got I8
			//IL_0514: Expected I, but got O
			//IL_0524: Expected O, but got I
			//IL_0534: Expected O, but got I
			//IL_022a: Expected I, but got O
			//IL_023a: Expected O, but got I
			//IL_024a: Expected O, but got I
			if (subject == null)
			{
				return;
			}
			uint num = global::_003CPrivateImplementationDetails_003E.ComputeStringHash(subject);
			bool flag = (int)num < 2411276062L;
			bool flag2 = !flag;
			int num2 = (int)((int)num - 2411276062L);
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				bool flag5 = (int)num < 1093263071;
				bool flag6 = !flag5;
				int num3 = (int)(num - 1093263071);
				bool flag7 = num3 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					switch (num)
					{
					case 1093263071u:
						if (subject == "onTransactionsRestoredFail")
						{
							OnTransactionsRestoredFail("onTransactionsRestoredFail");
						}
						break;
					case 430974421u:
						if (subject == "onPromotionalPurchaseAttempted")
						{
							OnPromotionalPurchaseAttempted(payload);
						}
						break;
					}
					return;
				}
			}
			else
			{
				bool flag9 = (int)num < 3385076384L;
				bool flag10 = !flag9;
				int num4 = (int)((int)num - 3385076384L);
				bool flag11 = num4 == 0;
				bool flag12 = !flag11;
				if (flag10 && flag12)
				{
					if ((int)num != 3622431981L)
					{
						if ((int)num != 3685547548L)
						{
							if ((int)num == 3750884092L && subject == "OnSetupFailed")
							{
								OnSetupFailed(payload);
							}
						}
						else if (subject == "OnProductsRetrieved")
						{
							IntPtr intPtr = (IntPtr)this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl>)+270]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl>)+278]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v246 @ X3_v1 (should have been resolved before IL gen)");
						}
					}
					else if (subject == "onAppReceiptRefreshed")
					{
						OnAppReceiptRetrieved(payload);
					}
					return;
				}
				if ((int)num == 3320864102L)
				{
					if (subject == "OnPurchaseFailed")
					{
						PurchaseFailureDescription failure = JSONSerializer.DeserializeFailureReason(payload);
						OnPurchaseFailed(failure, payload);
					}
					return;
				}
				if ((int)num != 3385076384L || !(subject == "OnPurchaseSucceeded"))
				{
					return;
				}
				IntPtr intPtr2 = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v29 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl>)+280]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v29 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl>)+288]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v243 @ X5_v1 (should have been resolved before IL gen)");
			}
			if ((int)num != 2411276062L)
			{
				switch (num)
				{
				case 1674652619u:
					if (subject == "onProductPurchaseDeferred")
					{
						OnPurchaseDeferred(payload);
					}
					break;
				case 1523640433u:
					if (subject == "onAppReceiptRefreshFailed" && m_RefreshReceiptError != null)
					{
						m_RefreshReceiptError();
					}
					break;
				}
			}
			else if (subject == "onTransactionsRestoredSuccess")
			{
				OnTransactionsRestoredSuccess();
			}
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xC5A32C", Offset = "0xC5A32C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = UnityEngine.Purchasing.AppleStoreImpl::getAppleReceiptFromBase64String(this, receipt);\n\tv26 = UnityEngine.Purchasing.AppleStoreImpl::isValidPurchaseState(v23, v23, id);\n\tv28 = v26 == 0;\n\tif (v28) goto L_002B;\n\tUnityEngine.Purchasing.JSONStore::OnPurchaseSucceeded(this, id, receipt, transactionId);\n\treturn;\nL_002B:\n\tUnityEngine.Purchasing.JSONStore::FinishTransaction(this, 0, transactionId);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPurchaseSucceeded(string id, string receipt, string transactionId)
		{
			AppleReceipt appleReceiptFromBase64String = getAppleReceiptFromBase64String(receipt);
			if (((AppleStoreImpl)(object)appleReceiptFromBase64String).isValidPurchaseState(appleReceiptFromBase64String, id))
			{
				base.OnPurchaseSucceeded(id, receipt, transactionId);
			}
			else
			{
				FinishTransaction(null, transactionId);
			}
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xC590FC", Offset = "0xC590FC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EADF50]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, receipt, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20232F6]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(receipt);\n\tv45 = v41 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_003D;\n\tv50 = new UnityEngine.Purchasing.Security.AppleReceiptParser();\n\tUnityEngine.Purchasing.Security.AppleReceiptParser::.ctor(v50);\n\tgoto L_0031;\n\tv136 = *([v132 @ X0_v8+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0031;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v132, v103, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tv144 = System.Convert::FromBase64String(receipt);\n\tv90 = v50 == 0;\n\tif (v90) goto L_003F;\n\treturnVal1 = UnityEngine.Purchasing.Security.AppleReceiptParser::Parse(v50, v144);\nL_003D:\n\treturn returnVal1;\nL_003F:\n\tv147 = new System.NullReferenceException();\n\tgoto L_004B;\nL_004B:\n\tv56 = v144 != 1;\n\tif (v56) goto L_0067;\n\tv151 = 0x6D2BC0(v147, v144, v117, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv96 = *([v151 @ X0_v19]);\n\tv162 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v96 @ X8_v12]), v117, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv163 = v162 & 1;\n\tv91 = v163 == 0;\n\tif (v91) goto L_005D;\n\tv164 = 0x6D2490(v162, *([v96 @ X8_v12]), v117, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_003D;\nL_005D:\n\tv166 = 0x6D1E60(8, *([v96 @ X8_v12]), v117, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\t*([v166 @ X0_v23]) = *([v151 @ X0_v19]);\n\tv119 = 0x1E8A000 + 0x870;\n\tv168 = 0x6D2A00(v166, v119, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv155 = 0x6D2490(v168, v119, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0067:\n\tv159 = 0x6D2380(v125, v119, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal2 = 0x846AA4(v159, v119, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AppleReceipt getAppleReceiptFromBase64String(string receipt)
		{
			//IL_011e: Expected O, but got I4
			bool flag = string.IsNullOrEmpty(receipt);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			AppleReceipt result = null;
			if (!flag3)
			{
				AppleReceiptParser appleReceiptParser = new AppleReceiptParser();
				byte[] array = Convert.FromBase64String(receipt);
				if (appleReceiptParser == null)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag4 = (IntPtr)array != (IntPtr)1;
					byte[] array2 = array;
					NullReferenceException ex2 = ex;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj2 = default(object);
						object obj = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj3 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							result = null;
							goto IL_0059;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj4 = obj2;
						array2 = (byte[])(32022528 + 2160);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					AppleReceipt result2 = default(AppleReceipt);
					return result2;
				}
				result = appleReceiptParser.Parse(array);
			}
			goto IL_0059;
			IL_0059:
			return result;
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0xC5A3A0", Offset = "0xC5A3A0", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EF7E08]);\n\tv25 = *([v24 @ X8_v54]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, appleReceipt, id, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20232F7]) = v43;\nL_001A:\n\tv48 = new UnityEngine.Purchasing.AppleStoreImpl+<>c__DisplayClass40_0();\n\tSystem.Object::.ctor(v48);\n\tv48.id = id;\n\tv52 = appleReceipt == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv116 = appleReceipt.inAppPurchaseReceipts;\n\tv117 = appleReceipt.inAppPurchaseReceipts == 0;\n\tif (v117) goto L_FFFFFFFF;\n\tv143 = v116.Length == 0;\n\tif (v143) goto L_FFFFFFFF;\n\tv230 = new System.Predicate`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>();\n\tSystem.Predicate`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::.ctor(v230, v48, Il2CppMethodInfo);\n\tv140 = System.Array::FindAll(appleReceipt.inAppPurchaseReceipts, v230);\n\tv144 = v140 == 0;\n\tif (v144) goto L_FFFFFFFF;\n\tv145 = v140.Length == 0;\n\tif (v145) goto L_FFFFFFFF;\n\tgoto L_0050;\n\tv324 = *([v320 @ X0_v21 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl+<>c>)+E0]);\n\tv325 = v324 == 0;\n\tv326 = ~v325;\n\tif (v326) goto L_0050;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v320, v137, v132, v130, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv328 = UnityEngine.Purchasing.AppleStoreImpl+<>c;\nL_0050:\n\tv180 = v331.<>9__40_1;\n\tv333 = v331.<>9__40_1 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_0075;\n\tgoto L_0063;\n\tv355 = *([v327 @ X0_v22 (Il2CppClass<UnityEngine.Purchasing.AppleStoreImpl+<>c>)+E0]);\n\tv356 = v355 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_0063;\n\tv360 = \"il2cpp_codegen_runtime_class_init\"(v327, v137, v132, v130, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv377 = UnityEngine.Purchasing.AppleStoreImpl+<>c;\n\tv362 = *([v377 @ X8_v49+B8]);\nL_0063:\n\tv346 = new System.Comparison`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>();\n\tSystem.Comparison`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::.ctor(v346, v331.<>9, Il2CppMethodInfo);\n\tv331.<>9__40_1 = v346;\nL_0075:\n\tSystem.Array::Sort(v140, v180);\n\tv178 = v140.Length == 0;\n\tif (v178) goto L_00EB;\n\tv107 = v140[0];\n\tgoto L_008B;\n\tv379 = *([v371 @ X0_v25+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_008B;\n\tv383 = \"il2cpp_codegen_runtime_class_init\"(v371, v174, v88, v85, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008B:\n\tv98 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.AppleStoreProductType);\n\tv386 = v107.<productType>k__BackingField;\n\tv389 = System.Array::Sort(&v386 @ X8_v31 (System.Int32), 0);\n\tgoto L_00A5;\n\tv395 = *([v298 @ X8_v34+E0]);\n\tv396 = v395 == 0;\n\tv397 = ~v396;\n\tif (v397) goto L_00A5;\n\tv402 = v298;\n\tv399 = \"il2cpp_codegen_runtime_class_init\"(v402, v388, v88, v85, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00A5:\n\tv293 = System.Enum::Parse(v98, v389);\n\tv306 = v306_asT == 0;\n\tif (v306) goto L_00F0;\n\tv141 = \"il2cpp_vm_object_unbox\"(v293, UnityEngine.Purchasing.AppleStoreProductType, 0, v85, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv55 = *([v141 @ X0_v34]) != 3;\n\tif (v55) goto L_FFFFFFFF;\n\tv99 = new UnityEngine.Purchasing.SubscriptionInfo();\n\tUnityEngine.Purchasing.SubscriptionInfo::.ctor(v99, v107, 0);\n\tv411 = UnityEngine.Purchasing.SubscriptionInfo::isExpired(v99);\n\tv197 = v411 == 0;\n\tv187 = ~v197;\n\tgoto L_00E8;\nL_00E8:\n\treturn returnVal1;\n\tv115 = new System.NullReferenceException();\nL_00EB:\n\tv185 = new System.IndexOutOfRangeException();\n\tthrow v185;\n\tv300 = new System.NullReferenceException();\nL_00F0:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal bool isValidPurchaseState(AppleReceipt appleReceipt, string id)
		{
			//IL_0135: Expected O, but got I4
			//IL_015d: Expected I4, but got O
			//IL_0216: Expected I4, but got O
			if (appleReceipt != null)
			{
				AppleInAppPurchaseReceipt[] inAppPurchaseReceipts = appleReceipt.inAppPurchaseReceipts;
				if (appleReceipt.inAppPurchaseReceipts != null && inAppPurchaseReceipts.Length != 0)
				{
					Predicate<AppleInAppPurchaseReceipt> match = (AppleInAppPurchaseReceipt r) => r.productID == id;
					AppleInAppPurchaseReceipt[] array = Array.FindAll(appleReceipt.inAppPurchaseReceipts, match);
					if (array != null && array.Length != 0)
					{
						Comparison<AppleInAppPurchaseReceipt> comparison = _003C_003Ec._003C_003E9__40_1;
						bool flag = _003C_003Ec._003C_003E9__40_1 == null;
						bool flag2 = !flag;
						IntPtr intPtr = (IntPtr)0;
						if (!flag2)
						{
							Comparison<AppleInAppPurchaseReceipt> comparison2 = (_003C_003Ec._003C_003E9__40_1 = delegate(AppleInAppPurchaseReceipt b, AppleInAppPurchaseReceipt a)
							{
								DateTime purchaseDate = a.purchaseDate;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
								int result2 = default(int);
								return result2;
							});
							intPtr = (IntPtr)0;
							comparison = comparison2;
						}
						Array.Sort(array, comparison);
						if (array.Length == 0)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						AppleInAppPurchaseReceipt appleInAppPurchaseReceipt = array[0];
						Type typeFromHandle = typeof(AppleStoreProductType);
						int productType = appleInAppPurchaseReceipt.productType;
						Array.Sort((AppleInAppPurchaseReceipt[])productType, (Comparison<AppleInAppPurchaseReceipt>)null);
						string value = default(string);
						object obj = Enum.Parse(typeFromHandle, value);
						if ((int)((obj is AppleStoreProductType) ? obj : null) == 0)
						{
							InvalidCastException ex2 = new InvalidCastException();
							return (byte)(int)ex2 != 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj2 = default(object);
						if ((IntPtr)obj2 == (IntPtr)3)
						{
							SubscriptionInfo subscriptionInfo = new SubscriptionInfo(appleInAppPurchaseReceipt, null);
							Result result = subscriptionInfo.isExpired();
							bool flag3 = result == Result.True;
							return !flag3;
						}
					}
				}
			}
			return true;
		}
	}
}

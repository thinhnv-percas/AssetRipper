using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.MiniJSON;
using UnityEngine.UDP;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200003A")]
	internal class UDPImpl : JSONStore, IUDPExtensions, IStoreExtension
	{
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0xA8")]
		private INativeUDPStore m_Bindings;

		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0xB0")]
		private UserInfo m_UserInfo;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0xB8")]
		private string m_LastInitError;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0xC0")]
		private bool m_Initialized;

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x15B2958", Offset = "0x15B2958", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Bindings = nativeUdpStore;\n\treturn;\n")]
		public void SetNativeStore(INativeUDPStore nativeUdpStore)
		{
			m_Bindings = nativeUdpStore;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x15B2960", Offset = "0x15B2960", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.unity = callback;\n\treturn;\n")]
		public override void Initialize(IStoreCallback callback)
		{
			unity = callback;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x15B2968", Offset = "0x15B2968", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EB7310]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, products, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20298D0]) = v45;\nL_001A:\n\tv49 = new UnityEngine.Purchasing.UDPImpl+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v49);\n\tv49.<>4__this = this;\n\tv49.products = products;\n\tv56 = new System.Action`2<System.Boolean, System.String>();\n\tSystem.Action`2<System.Boolean, System.String>::.ctor(v56, v49, Il2CppMethodInfo);\n\tv49.retrieveCallback = v56;\n\tv75 = this.m_Bindings;\n\tv87 = ~this.m_Initialized;\n\tif (v87) goto L_005E;\n\tv187 = *([v75 @ X19_v3 (System.Action`2<System.Boolean, System.String>)]);\n\tv188 = v49.products;\n\tv168 = *([v187 @ X8_v14 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]) == 0;\n\tif (v168) goto L_005B;\n\tv233 = *([v187 @ X8_v14 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+B0]) + 8;\nL_0046:\n\tv239 = *([v233 @ X11_v11-8]) == UnityEngine.Purchasing.INativeUDPStore;\n\tif (v239) goto L_008F;\n\tv234 = v234 + 1;\n\tv249 = v234 < *([v187 @ X8_v14 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]);\n\tv215 = ~v249;\n\tv233 = v233 + 0x10;\n\tv199 = ~v215;\n\tif (v199) goto L_0046;\nL_005B:\n\tv256 = System.Action`2<System.Boolean, System.String>::.ctor(v75, UnityEngine.Purchasing.INativeUDPStore, 2);\n\tgoto L_0093;\nL_005E:\n\tv70 = new System.Action`2<System.Boolean, System.String>();\n\tSystem.Action`2<System.Boolean, System.String>::.ctor(v70, v49, Il2CppMethodInfo);\n\tgoto L_00B1;\n\tv257 = *([v245 @ X8_v11+B0]);\n\tv258 = 0;\n\tv259 = v257 + 8;\n\tv261 = *([v297 @ X11_v5-8]);\n\tv303 = v261 == v248;\n\tif (v303) goto L_00A1;\n\tv283 = v298 + 1;\n\tv308 = v283 < v247;\n\tv279 = ~v308;\n\tv281 = v297 + 0x10;\n\tv263 = ~v279;\n\tif (v263) goto L_FFFFFFFF;\n\tv284 = v75;\n\tv285 = 0;\n\tv286 = 0x8909C4(v284, v248, v285, v59, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00B1;\nL_008F:\n\tv251 = *([v233 @ X11_v11]) + 2;\n\tv252 = v251 << 4;\n\tv253 = v187 + v252;\n\tv256 = v253 + 0x130;\nL_0093:\n\tv92 = *([v256 @ X0_v16 (System.Action`2<System.Boolean, System.String>)]);\n\tv150 = *([v256 @ X0_v16 (System.Action`2<System.Boolean, System.String>)+8]);\n\t// 160 IndirectJump v92 @ X4_v1 (Il2CppClass<System.Action`2<System.Boolean, System.String>>), v75 @ X19_v3 (System.Action`2<System.Boolean, System.String>), v75 @ X19_v3 (System.Action`2<System.Boolean, System.String>), v188 @ X21_v4 (System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>), v56 @ X0_v8 (System.Action`2<System.Boolean, System.String>), v150 @ X3_v5, v92 @ X4_v1 (Il2CppClass<System.Action`2<System.Boolean, System.String>>), v32 @ X5, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\nL_00A1:\n\tv309 = *([v297 @ X11_v5]);\n\tv310 = v309 << 4;\n\tv311 = v245 + v310;\n\tv312 = v311 + 0x130;\nL_00B1:\n\tUnityEngine.Purchasing.INativeUDPStore::Initialize(v75, v70);\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products)
		{
			//IL_006f: Expected I, but got O
			//IL_01bf: Expected I, but got O
			//IL_01cf: Expected O, but got I
			//IL_00b7: Expected O, but got I
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_016a: Expected O, but got I
			//IL_0179: Expected O, but got I
			//IL_0103: Expected O, but got I
			Action<bool, string> action = delegate(bool success, string json)
			{
				//IL_00ae: Expected I, but got O
				//IL_005d: Expected I, but got O
				//IL_006d: Expected O, but got I
				//IL_007d: Expected O, but got I
				//IL_0214: Expected O, but got I
				//IL_00e9: Expected O, but got I
				//IL_0166: Unknown result type (might be due to invalid IL or missing references)
				//IL_016b: Expected O, but got Unknown
				//IL_0188: Expected O, but got I
				//IL_0197: Expected O, but got I
				//IL_0135: Expected O, but got I
				int num4;
				if (success)
				{
					bool flag3 = string.IsNullOrEmpty(json);
					bool flag4 = !flag3;
					num4 = (flag4 ? 1 : 0);
				}
				else
				{
					num4 = 0;
				}
				UDPImpl uDPImpl = this;
				object obj5;
				object obj6;
				if (num4 != 0)
				{
					IntPtr intPtr3 = (IntPtr)uDPImpl;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.UDPImpl>)+270]");
					obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.UDPImpl>)+278]");
					obj6 = 0;
					goto IL_01c8;
				}
				ILogger logger = uDPImpl.m_Logger;
				string text = "RetrieveProducts failed: " + json;
				IntPtr intPtr4 = (IntPtr)logger;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_014e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+B0]");
				object obj7 = 0L + 8L;
				int num5 = 0;
				goto IL_01d2;
				IL_01c8:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X3_v1 (should have been resolved before IL gen)");
				goto IL_01d2;
				IL_01d2:
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILogger))
					{
						break;
					}
					num5++;
					int num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag5 = (long)num6 < 0L;
					bool flag6 = !flag5;
					obj7 = (long)(IntPtr)obj7 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_014e;
				}
				object obj8 = obj7 + 4;
				int num7 = (int)((long)(IntPtr)obj8 << 4);
				object obj9 = (long)intPtr4 + (long)num7;
				object obj10 = (long)(IntPtr)obj9 + 304L;
				goto IL_01fc;
				IL_01fc:
				obj5 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X0_v11+8]");
				obj6 = 0;
				goto IL_01c8;
				IL_014e:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_01fc;
			};
			Action<bool, string> retrieveCallback = action;
			Action<bool, string> bindings = (Action<bool, string>)(object)m_Bindings;
			Action<bool, string> callback = default(Action<bool, string>);
			if (m_Initialized)
			{
				IntPtr intPtr = (IntPtr)bindings;
				ReadOnlyCollection<ProductDefinition> readOnlyCollection = products;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X8_v14 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]");
				Action<bool, string> action2 = default(Action<bool, string>);
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X8_v14 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X11_v11-8]");
						if ((IntPtr)0 != (IntPtr)typeof(INativeUDPStore))
						{
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X8_v14 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]");
							bool flag = (long)num2 < 0L;
							flag2 = !flag;
							obj = (long)(IntPtr)obj + 16L;
							continue;
						}
						object obj2 = obj + 2;
						int num3 = (int)((long)(IntPtr)obj2 << 4);
						object obj3 = (long)intPtr + (long)num3;
						action2 = (Action<bool, string>)((long)(IntPtr)obj3 + 304L);
						break;
					}
					while (!flag2);
				}
				IntPtr intPtr2 = (IntPtr)action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ X0_v16 (System.Action`2<System.Boolean, System.String>)+8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v92 @ X4_v1 (Il2CppClass<System.Action`2<System.Boolean, System.String>>) (should have been resolved before IL gen)");
			}
			else
			{
				callback = delegate(bool success, string message)
				{
					//IL_0259: Expected I, but got O
					//IL_0423: Expected O, but got I
					//IL_0294: Expected O, but got I
					//IL_0151: Expected I, but got O
					//IL_0311: Unknown result type (might be due to invalid IL or missing references)
					//IL_0316: Expected O, but got Unknown
					//IL_0333: Expected O, but got I
					//IL_0342: Expected O, but got I
					//IL_03d7: Expected O, but got I
					//IL_01a0: Expected O, but got I
					//IL_02e0: Expected O, but got I
					//IL_0350: Unknown result type (might be due to invalid IL or missing references)
					//IL_0355: Expected O, but got Unknown
					//IL_0372: Expected O, but got I
					//IL_0381: Expected O, but got I
					//IL_01ec: Expected O, but got I
					UDPImpl uDPImpl = this;
					uDPImpl.m_LastInitError = "";
					UDPImpl uDPImpl2 = this;
					uDPImpl2.m_UserInfo = null;
					object obj8 = default(object);
					if (success)
					{
						if (!string.IsNullOrEmpty(message))
						{
							Dictionary<string, object> dictionary = message.HashtableFromJson();
							if (dictionary.ContainsKey("Channel"))
							{
								UDPImpl uDPImpl3 = this;
								UserInfo userInfo = new UserInfo();
								uDPImpl3.m_UserInfo = userInfo;
								UDPImpl uDPImpl4 = this;
								DictionaryToStringProperty(dictionary, uDPImpl4.m_UserInfo);
							}
						}
						UDPImpl uDPImpl5 = this;
						uDPImpl5.m_Initialized = true;
						UDPImpl uDPImpl6 = this;
						INativeUDPStore bindings2 = uDPImpl6.m_Bindings;
						IntPtr intPtr3 = (IntPtr)bindings2;
						ReadOnlyCollection<ProductDefinition> readOnlyCollection2 = products;
						Action<bool, string> action3 = retrieveCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v15 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0205;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v15 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+B0]");
						object obj5 = 0L + 8L;
						int num4 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ X11_v11-8]");
							if ((IntPtr)0 == (IntPtr)typeof(INativeUDPStore))
							{
								break;
							}
							num4++;
							int num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v15 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+126]");
							bool flag3 = (long)num5 < 0L;
							bool flag4 = !flag3;
							obj5 = (long)(IntPtr)obj5 + 16L;
							if (!flag4)
							{
								continue;
							}
							goto IL_0205;
						}
						object obj6 = obj5 + 2;
						int num6 = (int)((long)(IntPtr)obj6 << 4);
						object obj7 = (long)intPtr3 + (long)num6;
						obj8 = (long)(IntPtr)obj7 + 304L;
						goto IL_03bf;
					}
					UDPImpl uDPImpl7 = this;
					uDPImpl7.m_LastInitError = message;
					UDPImpl uDPImpl8 = this;
					IStoreCallback storeCallback = uDPImpl8.unity;
					IntPtr intPtr4 = (IntPtr)storeCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_02f9;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
					object obj9 = 0L + 8L;
					int num7 = 0;
					goto IL_03e1;
					IL_0205:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_03bf;
					IL_040b:
					object obj11 = default(object);
					object obj10 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ X0_v6+8]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v121 @ X3_v1 (should have been resolved before IL gen)");
					return;
					IL_03bf:
					object obj13 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ X0_v14+8]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v124 @ X4_v1 (should have been resolved before IL gen)");
					goto IL_03e1;
					IL_03e1:
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
						{
							break;
						}
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
						bool flag5 = (long)num8 < 0L;
						bool flag6 = !flag5;
						obj9 = (long)(IntPtr)obj9 + 16L;
						if (!flag6)
						{
							continue;
						}
						goto IL_02f9;
					}
					object obj15 = obj9 + 1;
					int num9 = (int)((long)(IntPtr)obj15 << 4);
					object obj16 = (long)intPtr4 + (long)num9;
					obj11 = (long)(IntPtr)obj16 + 304L;
					goto IL_040b;
					IL_02f9:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_040b;
				};
			}
			((INativeUDPStore)(object)bindings).Initialize(callback);
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x15B2B50", Offset = "0x15B2B50", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F0B2D8]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, product, developerPayload, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20298D1]) = v46;\nL_001B:\n\tv50 = new UnityEngine.Purchasing.UDPImpl+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v50);\n\tv50.product = product;\n\tv50.<>4__this = this;\n\tv69 = this.m_Bindings;\n\tv71 = product.<storeSpecificId>k__BackingField;\n\tv65 = new System.Action`2<System.Boolean, System.String>();\n\tSystem.Action`2<System.Boolean, System.String>::.ctor(v65, v50, Il2CppMethodInfo);\n\tv155 = *([v69 @ X20_v3 (System.Action`2<System.Boolean, System.String>)]);\n\tv141 = *([v155 @ X8_v10 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]) == 0;\n\tif (v141) goto L_005A;\n\tv199 = *([v155 @ X8_v10 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+B0]) + 8;\nL_0045:\n\tv205 = *([v199 @ X11_v5-8]) == UnityEngine.Purchasing.INativeUDPStore;\n\tif (v205) goto L_005D;\n\tv200 = v200 + 1;\n\tv210 = v200 < *([v155 @ X8_v10 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]);\n\tv181 = ~v210;\n\tv199 = v199 + 0x10;\n\tv165 = ~v181;\n\tif (v165) goto L_0045;\nL_005A:\n\tv217 = System.Action`2<System.Boolean, System.String>::.ctor(v69, UnityEngine.Purchasing.INativeUDPStore, 1);\n\tgoto L_0061;\nL_005D:\n\tv212 = *([v199 @ X11_v5]) + 1;\n\tv213 = v212 << 4;\n\tv214 = v155 + v213;\n\tv217 = v214 + 0x130;\nL_0061:\n\tv88 = *([v217 @ X0_v9 (System.Action`2<System.Boolean, System.String>)]);\n\tv86 = *([v217 @ X0_v9 (System.Action`2<System.Boolean, System.String>)+8]);\n\t// 111 IndirectJump v88 @ X5_v1 (Il2CppClass<System.Action`2<System.Boolean, System.String>>), v69 @ X20_v3 (System.Action`2<System.Boolean, System.String>), v69 @ X20_v3 (System.Action`2<System.Boolean, System.String>), v71 @ X21_v3 (System.String), v65 @ X0_v8 (System.Action`2<System.Boolean, System.String>), developerPayload @ X2 (System.String), v86 @ X4_v1, v88 @ X5_v1 (Il2CppClass<System.Action`2<System.Boolean, System.String>>), v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Purchase(ProductDefinition product, string developerPayload)
		{
			//IL_0059: Expected I, but got O
			//IL_017e: Expected I, but got O
			//IL_018e: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected O, but got Unknown
			//IL_0129: Expected O, but got I
			//IL_0138: Expected O, but got I
			//IL_00e0: Expected O, but got I
			ProductDefinition product2 = product;
			Action<bool, string> bindings = (Action<bool, string>)(object)m_Bindings;
			string storeSpecificId = product.storeSpecificId;
			Action<bool, string> action = delegate(bool success, string message)
			{
				//IL_0064: Expected I, but got O
				//IL_0319: Expected I4, but got O
				//IL_0351: Expected I4, but got O
				//IL_05d0: Expected I, but got O
				//IL_0688: Expected O, but got I4
				//IL_042b: Expected I4, but got O
				//IL_060b: Expected O, but got I
				//IL_076a: Expected O, but got I
				//IL_0696: Unknown result type (might be due to invalid IL or missing references)
				//IL_069b: Expected O, but got Unknown
				//IL_06b8: Expected O, but got I
				//IL_06c7: Expected O, but got I
				//IL_0657: Expected O, but got I
				//IL_047a: Expected I, but got O
				//IL_0220: Expected I, but got O
				//IL_02d8: Expected O, but got I4
				//IL_04b5: Expected O, but got I
				//IL_07e3: Expected I, but got O
				//IL_025b: Expected O, but got I
				//IL_0532: Unknown result type (might be due to invalid IL or missing references)
				//IL_0537: Expected O, but got Unknown
				//IL_0554: Expected O, but got I
				//IL_0563: Expected O, but got I
				//IL_0571: Unknown result type (might be due to invalid IL or missing references)
				//IL_0576: Expected O, but got Unknown
				//IL_0593: Expected O, but got I
				//IL_05a2: Expected O, but got I
				//IL_0501: Expected O, but got I
				//IL_02a7: Expected O, but got I
				Dictionary<string, object> dictionary = message.HashtableFromJson();
				ILogger logger;
				object[] array;
				object obj8 = default(object);
				ArrayTypeMismatchException ex3 = default(ArrayTypeMismatchException);
				ProductDefinition productDefinition;
				IntPtr intPtr3;
				if (success)
				{
					string value = dictionary.GetString("GameOrderId");
					string text = dictionary.GetString("ProductId");
					bool flag3 = string.IsNullOrEmpty(value);
					bool flag4 = !flag3;
					bool flag5 = !flag4;
					intPtr3 = (IntPtr)null;
					if (!flag5)
					{
						dictionary.set_Item("transactionId", (object)value);
						intPtr3 = (IntPtr)0;
					}
					if (!string.IsNullOrEmpty(text))
					{
						dictionary.set_Item("storeSpecificId", (object)text);
						intPtr3 = (IntPtr)0;
					}
					productDefinition = product2;
					if (productDefinition.storeSpecificId.Equals(text))
					{
						goto IL_0725;
					}
					UDPImpl uDPImpl = this;
					logger = uDPImpl.m_Logger;
					array = new object[2];
					productDefinition = product2;
					if (productDefinition.storeSpecificId != null)
					{
						productDefinition = (ProductDefinition)(object)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					}
					array[0] = productDefinition.storeSpecificId;
					bool flag6 = text == null;
					IntPtr intPtr4 = (IntPtr)0;
					if (!flag6)
					{
						productDefinition = (ProductDefinition)(object)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
						intPtr4 = (IntPtr)0;
					}
					bool flag7 = (long)intPtr4 < 1L;
					bool flag8 = !flag7;
					object obj5 = (long)intPtr4 - 1L;
					bool flag9 = obj5 == null;
					bool flag10 = !flag8;
					if (!(flag10 || flag9))
					{
						array[1] = text;
						IntPtr intPtr5 = (IntPtr)logger;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ X8_v63 (Il2CppClass<UnityEngine.ILogger>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_02c0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ X8_v63 (Il2CppClass<UnityEngine.ILogger>)+B0]");
						object obj6 = 0L + 8L;
						int num4 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X11_v23-8]");
							if ((IntPtr)0 == (IntPtr)typeof(ILogger))
							{
								break;
							}
							num4++;
							int num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ X8_v63 (Il2CppClass<UnityEngine.ILogger>)+126]");
							bool flag11 = (long)num5 < 0L;
							bool flag12 = !flag11;
							obj6 = (long)(IntPtr)obj6 + 16L;
							if (!flag12)
							{
								continue;
							}
							goto IL_02c0;
						}
						object obj7 = obj6 + 8;
						int num6 = (int)((long)(IntPtr)obj7 << 4);
						productDefinition = (ProductDefinition)((long)intPtr5 + (long)num6);
						obj8 = (long)(IntPtr)productDefinition + 304L;
						goto IL_07c9;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
				}
				else
				{
					Type typeFromHandle = typeof(PurchaseFailureReason);
					object obj9 = Enum.Parse(typeFromHandle, "Unknown");
					if ((int)((obj9 is PurchaseFailureReason) ? obj9 : null) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj10 = default(object);
						productDefinition = (ProductDefinition)obj10;
						object obj11 = (PurchaseFailureReason)productDefinition;
						productDefinition = (ProductDefinition)obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v281 @ X8_v49 (UnityEngine.Purchasing.ProductDefinition)+160] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object value2 = default(object);
						Dictionary<string, object> dictionary2 = new Dictionary<string, object> { ["error"] = value2 };
						if (dictionary.ContainsKey("purchaseInfo"))
						{
							object value3 = dictionary.get_Item("purchaseInfo");
							dictionary2.set_Item("purchaseInfo", value3);
						}
						string text2 = dictionary2.toJson();
						productDefinition = product2;
						object obj12 = default(object);
						PurchaseFailureDescription purchaseFailureDescription = new PurchaseFailureDescription(productDefinition.storeSpecificId, (PurchaseFailureReason)obj12, message);
						UDPImpl uDPImpl2 = this;
						uDPImpl2.lastPurchaseFailureDescription = purchaseFailureDescription;
						UDPImpl uDPImpl3 = this;
						IStoreCallback storeCallback = uDPImpl3.unity;
						IntPtr intPtr6 = (IntPtr)storeCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v779 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_051a;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v779 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
						object obj13 = 0L + 8L;
						int num7 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ X11_v10-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
							{
								break;
							}
							num7++;
							int num8 = num7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v779 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
							bool flag13 = (long)num8 < 0L;
							bool flag14 = !flag13;
							obj13 = (long)(IntPtr)obj13 + 16L;
							if (!flag14)
							{
								continue;
							}
							goto IL_051a;
						}
						object obj14 = obj13 + 4;
						int num9 = (int)((long)(IntPtr)obj14 << 4);
						productDefinition = (ProductDefinition)((long)intPtr6 + (long)num9);
						object obj15 = (long)(IntPtr)productDefinition + 304L;
						goto IL_0812;
					}
					InvalidCastException ex2 = new InvalidCastException();
					ex3 = new ArrayTypeMismatchException();
				}
				throw ex3;
				IL_051a:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0812;
				IL_02c0:
				((Dictionary<string, object>)logger).set_Item((string)(object)typeof(ILogger), (object)8);
				goto IL_07c9;
				IL_0670:
				IStoreCallback storeCallback2;
				((Dictionary<string, object>)storeCallback2).set_Item((string)(object)typeof(IStoreCallback), (object)3);
				goto IL_084b;
				IL_0725:
				string text3 = dictionary.toJson();
				UDPImpl uDPImpl4 = this;
				ProductDefinition productDefinition2 = product2;
				storeCallback2 = uDPImpl4.unity;
				IntPtr intPtr7 = (IntPtr)storeCallback2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ X8_v52 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0670;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ X8_v52 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
				object obj16 = 0L + 8L;
				int num10 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ X11_v17-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
					{
						break;
					}
					num10++;
					int num11 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ X8_v52 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
					bool flag15 = (long)num11 < 0L;
					bool flag16 = !flag15;
					obj16 = (long)(IntPtr)obj16 + 16L;
					if (!flag16)
					{
						continue;
					}
					goto IL_0670;
				}
				object obj17 = obj16 + 3;
				int num12 = (int)((long)(IntPtr)obj17 << 4);
				productDefinition = (ProductDefinition)((long)intPtr7 + (long)num12);
				object obj18 = (long)(IntPtr)productDefinition + 304L;
				goto IL_084b;
				IL_07c9:
				productDefinition = (ProductDefinition)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v775 @ X0_v77] (should have been resolved before IL gen)");
				intPtr3 = (IntPtr)array;
				goto IL_0725;
				IL_0812:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v841 @ X0_v40] (should have been resolved before IL gen)");
				return;
				IL_084b:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v658 @ X0_v67] (should have been resolved before IL gen)");
			};
			IntPtr intPtr = (IntPtr)bindings;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v10 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]");
			Action<bool, string> action2 = default(Action<bool, string>);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v10 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(INativeUDPStore))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v10 (Il2CppClass<System.Action`2<System.Boolean, System.String>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					action2 = (Action<bool, string>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			IntPtr intPtr2 = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X0_v9 (System.Action`2<System.Boolean, System.String>)+8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v88 @ X5_v1 (Il2CppClass<System.Action`2<System.Boolean, System.String>>) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x15B2C94", Offset = "0x15B2C94", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF0BE8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, product, transactionId, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20298D2]) = v44;\nL_0017:\n\tv45 = product == 0;\n\tif (v45) goto L_0025;\n\tv46 = transactionId == 0;\n\tif (v46) goto L_0025;\n\tv48 = product.<type>k__BackingField == 0;\n\tif (v48) goto L_0026;\nL_0025:\n\treturn;\nL_0026:\n\tv117 = this.m_Bindings;\n\tv129 = *([v117 @ X21_v3 (UnityEngine.Purchasing.INativeUDPStore)]);\n\tv113 = *([v129 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+126]) == 0;\n\tif (v113) goto L_004D;\n\tv174 = *([v129 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+B0]) + 8;\nL_0038:\n\tv180 = *([v174 @ X11_v5-8]) == UnityEngine.Purchasing.INativeUDPStore;\n\tif (v180) goto L_0050;\n\tv175 = v175 + 1;\n\tv185 = v175 < *([v129 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+126]);\n\tv156 = ~v185;\n\tv174 = v174 + 0x10;\n\tv140 = ~v156;\n\tif (v140) goto L_0038;\nL_004D:\n\tv192 = 0x8909C4(v117, UnityEngine.Purchasing.INativeUDPStore, 3, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0054;\nL_0050:\n\tv187 = *([v174 @ X11_v5]) + 3;\n\tv188 = v187 << 4;\n\tv189 = v129 + v188;\n\tv192 = v189 + 0x130;\nL_0054:\n\tv60 = *([v192 @ X0_v4]);\n\tv58 = *([v192 @ X0_v4+8]);\n\t// 96 IndirectJump v60 @ X4_v1, v117 @ X21_v3 (UnityEngine.Purchasing.INativeUDPStore), v117 @ X21_v3 (UnityEngine.Purchasing.INativeUDPStore), product @ X1 (UnityEngine.Purchasing.ProductDefinition), transactionId @ X2 (System.String), v58 @ X3_v1, v60 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FinishTransaction(ProductDefinition product, string transactionId)
		{
			//IL_005c: Expected I, but got O
			//IL_01a9: Expected O, but got I
			//IL_0097: Expected O, but got I
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_0136: Expected O, but got I
			//IL_0145: Expected O, but got I
			//IL_00e3: Expected O, but got I
			if (product == null || transactionId == null || product.type != ProductType.Consumable)
			{
				return;
			}
			INativeUDPStore bindings = m_Bindings;
			IntPtr intPtr = (IntPtr)bindings;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00fc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeUDPStore))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeUDPStore>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00fc;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0191;
			IL_0191:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X4_v1 (should have been resolved before IL gen)");
			return;
			IL_00fc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0191;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x15B2D84", Offset = "0x15B2D84", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EC8010]);\n\tv37 = *([v36 @ X8_v18]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, info, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20298D3]) = v55;\nL_0020:\n\tv59 = System.Object::GetType(info);\n\tv149 = System.Type::GetProperties(v59);\n\tv183 = v149.Length;\n\tv200 = v149.Length < 1;\n\tif (v200) goto L_0098;\nL_003C:\n\tv300 = v79 < v183;\n\tv111 = ~v300;\n\tif (v111) goto L_009B;\n\tv305 = System.Reflection.PropertyInfo::get_PropertyType(v149[v79 @ X25_v7 (System.Int32)]);\n\tgoto L_005F;\n\tv310 = *([v306 @ X8_v11+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_005F;\n\tv319 = v306;\n\tv315 = \"il2cpp_codegen_runtime_class_init\"(v319, v304, v65, v63, v61, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_005F:\n\tv318 = System.Type::GetTypeFromHandle(System.String);\n\tv329 = v305 != v318;\n\tif (v329) goto L_007D;\n\tv334 = System.Reflection.MemberInfo::get_Name(v149[v79 @ X25_v7 (System.Int32)]);\n\tv339 = UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::GetString(dic, v334, \"\");\n\tv345 = System.Reflection.PropertyInfo::SetValue(v149[v79 @ X25_v7 (System.Int32)], info, v339, 0);\nL_007D:\n\tv183 = v149.Length;\n\tv79 = v79 + 1;\n\tv225 = v79 < v149.Length;\n\tif (v225) goto L_003C;\nL_0098:\n\treturn;\n\tv154 = new System.NullReferenceException();\nL_009B:\n\tv185 = new System.IndexOutOfRangeException();\n\tthrow v185;\n\treturn;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DictionaryToStringProperty(Dictionary<string, object> dic, object info)
		{
			Type type = info.GetType();
			PropertyInfo[] properties = type.GetProperties();
			int num = properties.Length;
			if (properties.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				Type propertyType = properties[num2].PropertyType;
				Type typeFromHandle = typeof(string);
				if ((object)propertyType == typeFromHandle)
				{
					string name = properties[num2].Name;
					string value = dic.GetString(name);
					properties[num2].SetValue(info, value, null);
				}
				num = properties.Length;
				num2++;
				if (num2 >= properties.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x15B2F00", Offset = "0x15B2F00", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_UserInfo = 0;\n\tthis.m_Initialized = 0;\n\tUnityEngine.Purchasing.JSONStore::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UDPImpl()
		{
			m_UserInfo = null;
			m_Initialized = false;
		}
	}
}

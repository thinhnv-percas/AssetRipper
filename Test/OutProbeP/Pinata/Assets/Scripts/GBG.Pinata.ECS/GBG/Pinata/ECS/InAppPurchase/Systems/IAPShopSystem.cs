using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile;
using GBG.Pinata.ECS.InAppPurchase.Components;
using GBG.Pinata.ECS.InAppPurchase.Configs;
using Morpeh;
using TMPro;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000048")]
	public class IAPShopSystem : UpdateSystem
	{
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x28")]
		public ConsumableProductsConfig config;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x30")]
		private Filter filter;

		[Token(Token = "0x6000081")]
		[Address(RVA = "0xCC0960", Offset = "0xCC0960", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE8588]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202373E]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<IAPShopComponent>();
			this.filter = filter;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0xCC09D0", Offset = "0xCC09D0", Length = "0x400")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001D;\n\tv33 = *([1EE4C90]);\n\tv34 = *([v33 @ X8_v50]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, deltaTime, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202373F]) = v53;\nL_001D:\n\tv55 = &v56 @ stack_-100;\n\t*([v21 @ X29-A8]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-A0]) = 0;\n\t*([v21 @ X29-B0]) = 0;\n\tv62 = Morpeh.Filter::GetEnumerator(this.filter);\n\t*([v21 @ X29-60]) = *([v21 @ X29-D0]);\n\tv150 = *([v21 @ X29-E0]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-E0]);\nL_0036:\n\tv278 = &v21 @ X29 - 0x70;\n\tv280 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v278, 0, v360);\n\tv292 = v280 == 0;\n\tif (v292) goto L_0127;\n\tv141 = *([v21 @ X29-68]);\n\tv334 = Il2CppMethodInfo;\n\tv335 = *([v141 @ X21_v7 (System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>)]);\n\tv360 = *([v334 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv339 = *([v335 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>>)+126]) == 0;\n\tif (v339) goto L_0064;\n\tv486 = *([v335 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>>)+B0]) + 8;\nL_0050:\n\tv491 = *([v486 @ X11_v11-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v491) goto L_0067;\n\tv485 = v485 + 1;\n\tv525 = v485 < *([v335 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>>)+126]);\n\tv458 = ~v525;\n\tv486 = v486 + 0x10;\n\tv442 = ~v458;\n\tif (v442) goto L_0050;\nL_0064:\n\tv532 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v141, Il2CppClass<Morpeh.IEntity>, v360);\n\tgoto L_006D;\nL_0067:\n\tv527 = *([v486 @ X11_v11]) + v360;\n\tv528 = v527 << 4;\n\tv529 = v335 + v528;\n\tv532 = v529 + 0x130;\nL_006D:\n\tv536 = Morpeh.IEntity::GetComponent(*([v532 @ X0_v26 (System.Boolean)+8]));\n\t*([v536 @ X0_v28 (GBG.Pinata.ECS.InAppPurchase.Components.IAPShopComponent&)])(v565, v141, v536, v360, v176, v39, v40, v41, v42, v150, *([v21 @ X29-D0]), *([v21 @ X29-E0]), v46, v47, v48, v49, v50);\n\tv570 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.ShopSection>::GetEnumerator(*([v565 @ X0_v30]));\n\tv150 = *([v21 @ X29-C0]);\n\t*([v21 @ X29-90]) = *([v21 @ X29-D0]);\n\t*([v21 @ X29-80]) = *([v21 @ X29-C0]);\n\t*([v21 @ X29-A0]) = *([v21 @ X29-E0]);\nL_0082:\n\tv584 = &v21 @ X29 - 0xA0;\n\tv585 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.ShopSection>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Components.ShopSection>::MoveNext(v584);\n\tv587 = v585 == 0;\n\tif (v587) goto L_00D3;\n\tv165 = this.config;\n\tv161 = this.config == 0;\n\tif (v161) goto L_00D9;\n\tv162 = v165.productsDictionary == 0;\n\tif (v162) goto L_00DB;\n\tv360 = &v21 @ X29 - 0xB0;\n\tv577 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v165.productsDictionary, *([v21 @ X29-90]), v360);\n\tv580 = v577 == 0;\n\tif (v580) goto L_0082;\n\tgoto L_00A6;\n\tv609 = *([v603 @ X0_v45+E0]);\n\tv610 = v609 == 0;\n\tv611 = ~v610;\n\tif (v611) goto L_00A6;\n\tv613 = \"il2cpp_codegen_runtime_class_init\"(v603, v574, v198, v177, v39, v40, v41, v42, v151, v81, v78, v46, v47, v48, v49, v50);\nL_00A6:\n\tv616 = EasyMobile.InAppPurchasing::GetIAPProductByName(*([v21 @ X29-90]));\n\tv220 = v616 == 0;\n\tif (v220) goto L_00DD;\n\tv221 = *([v21 @ X29-78]) == 0;\n\tif (v221) goto L_00E0;\n\tTMPro.TMP_Text::set_text(*([v21 @ X29-78]), v616._price);\n\tv621 = GBG.Pinata.ECS.InAppPurchase.Systems.IAPShopSystem::FormatNumber(*([v21 @ X29-78]), *([v21 @ X29-B0]));\n\tv222 = *([v21 @ X29-88]) == 0;\n\tif (v222) goto L_00E3;\n\tTMPro.TMP_Text::set_text(*([v21 @ X29-88]), v621);\n\tv626 = *([v21 @ X29-AC]) == 0;\n\tif (v626) goto L_00CC;\n\tv627 = GBG.Pinata.ECS.InAppPurchase.Systems.IAPShopSystem::FormatNumber(*([v21 @ X29-88]), *([v21 @ X29-AC]));\n\tv640 = System.String::Concat(\"+\", v627, \" free\");\n\tv648 = *([v21 @ X29-80]) == 0;\n\tv644 = ~v648;\n\tif (v644) goto L_00D1;\n\tgoto L_00E6;\nL_00CC:\n\tv631 = *([v21 @ X29-80]) == 0;\n\tif (v631) goto L_00E6;\nL_00D1:\n\tTMPro.TMP_Text::set_text(*([v21 @ X29-80]), v583);\n\tgoto L_0082;\nL_00D3:\n\tv364 = v364 + 1;\n\t*([v55 @ X25_v1+v364 @ X26_v1*4]) = 0xD2;\n\tgoto L_0107;\nL_00D9:\n\tv157 = new System.NullReferenceException();\n\tgoto L_012E;\nL_00DB:\n\tv158 = new System.NullReferenceException();\n\tgoto L_012E;\nL_00DD:\n\tv214 = new System.NullReferenceException();\n\tgoto L_012F;\nL_00E0:\n\tv214 = new System.NullReferenceException();\n\tgoto L_012F;\nL_00E3:\n\tv214 = new System.NullReferenceException();\n\tgoto L_012F;\nL_00E6:\n\tv214 = new System.NullReferenceException();\n\tgoto L_012F;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\n\tgoto L_00F6;\nL_00F6:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_013D;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0107:\n\tv593 = &v21 @ X29 - 0xA0;\n\tv269 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.ShopSection>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Components.ShopSection>::Dispose(v593);\n\tv271 = v364 + 1;\n\tv595 = v271 == 0;\n\tif (v595) goto L_0121;\n\tv231 = *([v55 @ X25_v1+v364 @ X26_v1*4]) != 0xD2;\n\tif (v231) goto L_0121;\n\tv274 = 0xFFFFFFFF ^ v364;\n\tv364 = v364 + v274;\n\tgoto L_0036;\nL_0121:\n\tv272 = ~v372;\n\tif (v272) goto L_0036;\n\tthrow System.TypeLoadException;\nL_0127:\n\tv364 = v364 + 1;\n\t*([v55 @ X25_v1+v364 @ X26_v1*4]) = 0xEE;\n\tgoto L_0142;\n\tv341 = new System.NullReferenceException();\n\tv156 = new System.NullReferenceException();\nL_012E:\n\tv214 = new System.NullReferenceException();\nL_012F:\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\nL_013D:\n\tv290 = v210 != 1;\n\tif (v290) goto L_016E;\n\tv293 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v214, v210, v197);\n\tv372 = v293.m_value;\n\tv331 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v293, v210, v197);\nL_0142:\n\tv373 = &v21 @ X29 - 0x70;\n\tv375 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v373, 0, v360);\n\tv470 = v364 + 1;\n\tv472 = v470 == 0;\n\tif (v472) goto L_015C;\n\tv496 = ~v372;\n\tif (v496) goto L_016D;\n\tv542 = *([v55 @ X25_v1+v364 @ X26_v1*4]) == 0xEE;\n\tif (v542) goto L_016D;\nL_015B:\n\tthrow System.TypeLoadException;\nL_015C:\n\tv523 = ~v372;\n\tv524 = ~v523;\n\tif (v524) goto L_015B;\nL_016D:\n\treturn;\nL_016E:\n\tv294 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v214, v210, v197);\n\treturn;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnUpdate(float deltaTime)
		{
			//IL_0053: Expected O, but got I8
			//IL_0840: Expected O, but got I
			//IL_0627: Expected O, but got I
			//IL_06be: Expected O, but got I
			//IL_06df: Expected O, but got I
			//IL_0071: Expected O, but got I
			//IL_0084: Expected I, but got O
			//IL_0143: Expected O, but got I
			//IL_07e5: Expected O, but got I
			//IL_00cf: Expected O, but got I
			//IL_0807: Expected O, but got I
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Expected O, but got Unknown
			//IL_0177: Expected O, but got I
			//IL_0488: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_054f: Expected O, but got I
			//IL_0567: Expected O, but got I
			//IL_0641: Expected O, but got I
			//IL_05bf: Expected I4, but got I8
			//IL_05cd: Expected O, but got I
			//IL_0254: Expected O, but got I
			//IL_069e: Expected O, but got I4
			//IL_0291: Expected O, but got I
			//IL_02f1: Expected O, but got I
			//IL_030e: Expected O, but got I
			//IL_0351: Expected O, but got I
			//IL_044c: Expected O, but got I
			//IL_0393: Expected O, but got I
			//IL_046f: Expected O, but got I
			//IL_03da: Expected I, but got O
			//IL_03f5: Expected I, but got O
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Filter.EntityEnumerator enumerator = filter.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-D0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-E0]");
			int num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-E0]");
			_ = 0;
			object obj4 = 4294967295L;
			bool flag = false;
			ref ProductReward reference2 = default(ref ProductReward);
			object obj8 = default(object);
			IntPtr intPtr4 = default(IntPtr);
			ref ProductReward reference = default(ref ProductReward);
			while (true)
			{
				Dictionary<string, ProductReward> dictionary = (Dictionary<string, ProductReward>)((long)(IntPtr)obj - 112L);
				Dictionary<string, ProductReward> dictionary2;
				bool flag4;
				if (dictionary.TryGetValue(null, out reference))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					dictionary2 = (Dictionary<string, ProductReward>)0;
					IntPtr intPtr = (IntPtr)0;
					IntPtr intPtr2 = (IntPtr)dictionary2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X22_v8 (Il2CppMethodInfo)+48]");
					reference = ref *(ProductReward*)null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0134;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>>)+B0]");
					object obj5 = 0L + 8L;
					int num2 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ X11_v11-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num2++;
						int num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ X8_v17 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>>)+126]");
						bool flag2 = (long)num3 < 0L;
						bool flag3 = !flag2;
						obj5 = (long)(IntPtr)obj5 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_0134;
					}
					object obj6 = obj5 + System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
					int num4 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)intPtr2 + (long)num4;
					flag4 = (byte)((ulong)(long)(IntPtr)obj7 + 304uL) != 0;
					goto IL_07d4;
				}
				obj4 = (long)(IntPtr)obj4 + 1L;
				_ = 238;
				break;
				IL_066b:
				NullReferenceException ex;
				string text;
				bool flag5 = ((Dictionary<string, ProductReward>)(object)ex).TryGetValue(text, out reference2);
				flag = ((bool*)(flag5 ? 1 : 0))->m_value;
				bool flag6 = ((Dictionary<string, ProductReward>)flag5).TryGetValue(text, out reference2);
				reference = ref reference2;
				break;
				IL_07d4:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ X0_v26 (System.Boolean)+8]");
				ref IAPShopComponent component = ref ((IEntity)0).GetComponent<IAPShopComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v536 @ X0_v28 (GBG.Pinata.ECS.InAppPurchase.Components.IAPShopComponent&)] (should have been resolved before IL gen)");
				List<ShopSection>.Enumerator enumerator2 = ((List<ShopSection>)obj8).GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C0]");
				num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-D0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-E0]");
				_ = 0;
				IntPtr intPtr3 = intPtr4;
				while (true)
				{
					List<ShopSection>.Enumerator enumerator3 = (List<ShopSection>.Enumerator)((long)(IntPtr)obj - 160L);
					if (!((List<ShopSection>.Enumerator*)enumerator3)->MoveNext())
					{
						break;
					}
					ConsumableProductsConfig consumableProductsConfig = config;
					string text5;
					if ((object)config != null)
					{
						if (consumableProductsConfig.productsDictionary != null)
						{
							reference = ref *(ProductReward*)((long)(IntPtr)obj - 176L);
							Dictionary<string, ProductReward> productsDictionary = consumableProductsConfig.productsDictionary;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							bool flag7 = productsDictionary.TryGetValue((string)0, out reference);
							bool flag8 = !flag7;
							intPtr3 = (IntPtr)0;
							if (flag8)
							{
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							IAPProduct iAPProductByName = InAppPurchasing.GetIAPProductByName((string)0);
							if (iAPProductByName != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
								if ((IntPtr)0 != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
									((TMP_Text)0).text = iAPProductByName.Price;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
									IntPtr intPtr5 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
									string text2 = ((IAPShopSystem)(long)intPtr5).FormatNumber(0);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
									if ((IntPtr)0 != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
										((TMP_Text)0).text = text2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-AC]");
										IntPtr intPtr7;
										string text6;
										if ((IntPtr)0 != (IntPtr)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
											IntPtr intPtr6 = (IntPtr)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-AC]");
											string text3 = ((IAPShopSystem)(long)intPtr6).FormatNumber(0);
											string text4 = "+" + text3 + " free";
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
											bool flag9 = (IntPtr)0 == (IntPtr)0;
											bool flag10 = !flag9;
											intPtr3 = (IntPtr)null;
											text5 = text4;
											if (flag10)
											{
												goto IL_045a;
											}
											intPtr7 = (IntPtr)null;
											text6 = " free";
											text = text3;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
											bool flag11 = (IntPtr)0 == (IntPtr)0;
											intPtr3 = (IntPtr)0;
											text5 = "";
											intPtr7 = (IntPtr)0;
											text6 = null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-AC]");
											text = (string)0;
											if (!flag11)
											{
												goto IL_045a;
											}
										}
										ex = new NullReferenceException();
										intPtr4 = intPtr7;
										reference2 = ref *(ProductReward*)text6;
									}
									else
									{
										ex = new NullReferenceException();
										intPtr4 = (IntPtr)0;
										reference2 = ref *(ProductReward*)null;
										text = text2;
									}
								}
								else
								{
									ex = new NullReferenceException();
									intPtr4 = (IntPtr)0;
									reference2 = ref reference;
									text = null;
								}
							}
							else
							{
								ex = new NullReferenceException();
								intPtr4 = (IntPtr)0;
								reference2 = ref reference;
								text = null;
							}
							goto IL_064b;
						}
						NullReferenceException ex2 = new NullReferenceException();
						intPtr4 = intPtr3;
						reference2 = ref reference;
					}
					else
					{
						NullReferenceException ex3 = new NullReferenceException();
					}
					ex = new NullReferenceException();
					text = (string)0;
					goto IL_064b;
					IL_045a:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
					((TMP_Text)0).text = text5;
					reference = ref *(ProductReward*)null;
					continue;
					IL_064b:
					if ((IntPtr)text == (IntPtr)1)
					{
						goto IL_066b;
					}
					bool flag12 = ((Dictionary<string, ProductReward>)(object)ex).TryGetValue(text, out reference2);
					return;
				}
				obj4 = (long)(IntPtr)obj4 + 1L;
				_ = 210;
				List<ShopSection>.Enumerator enumerator4 = (List<ShopSection>.Enumerator)((long)(IntPtr)obj - 160L);
				((List<ShopSection>.Enumerator*)enumerator4)->Dispose();
				object obj9 = (long)(IntPtr)obj4 + 1L;
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X25_v1+v364 @ X26_v1*4]");
					if ((IntPtr)0 == (IntPtr)210)
					{
						int num5 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj4);
						obj4 = (long)(IntPtr)obj4 + (long)num5;
						intPtr4 = intPtr3;
						continue;
					}
				}
				bool flag13 = !flag;
				intPtr4 = intPtr3;
				flag = false;
				if (!flag13)
				{
					reference = ref *(ProductReward*)null;
					flag = false;
					throw new TypeLoadException();
				}
				continue;
				IL_0134:
				flag4 = dictionary2.TryGetValue((string)0, out reference);
				goto IL_07d4;
			}
			Dictionary<string, ProductReward> dictionary3 = (Dictionary<string, ProductReward>)((long)(IntPtr)obj - 112L);
			bool flag14 = dictionary3.TryGetValue(null, out reference);
			object obj10 = (long)(IntPtr)obj4 + 1L;
			if (obj10 != null)
			{
				if (!flag)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X25_v1+v364 @ X26_v1*4]");
				if ((IntPtr)0 == (IntPtr)238)
				{
					return;
				}
			}
			else if (!flag)
			{
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0xCC0DD0", Offset = "0xCC0DD0", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = *([1EB2BE0]);\n\tv25 = *([v24 @ X8_v32]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, number, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2023740]) = v44;\nL_0021:\n\tv56 = number <= 0x3E7;\n\tif (v56) goto L_004B;\n\tv59 = 0xF4240 - 1;\n\tv71 = number <= v59;\n\tif (v71) goto L_0058;\n\tv91 = number <= 0x3B9AC9FF;\n\tif (v91) goto L_006F;\n\tgoto L_0090;\nL_004B:\n\t// 75 Box v77 @ X0_v4 (System.Object), typeof(System.Int32), &number @ X1 (System.Int32)\n\treturnVal1 = System.String::Format(\"{0}\", v77);\n\tgoto L_0090;\nL_0058:\n\tv59 = number * 0x10624DD3;\n\tv98 = v59 >> 0x26;\n\t// 93 Box v101 @ X0_v11 (System.Object), typeof(System.Int32), &v98 @ X22_v4 (System.Int32)\n\tv124 = v98 * 0x3E8;\n\tv59 = number - v124;\n\tv59 = v59 * 0x51EB851F;\n\tv59 = v59 >> 0x25;\n\t// 105 Box v202 @ X0_v7 (System.Object), typeof(System.Int32), &v59 @ X8_v9 (System.Int32)\n\tgoto L_0087;\nL_006F:\n\tv114 = number / 0xF4240;\n\t// 115 Box v118 @ X0_v15 (System.Object), typeof(System.Int32), &v114 @ X23_v4 (System.Int32)\n\tv186 = v114 * 0xF4240;\n\tv59 = number - v186;\n\tv59 = v59 >> 5;\n\tv59 = v59 * 0xA7C5AC5;\n\tv59 = v59 >> 0x27;\n\t// 127 Box v202 @ X0_v7 (System.Object), typeof(System.Int32), &v59 @ X8_v9 (System.Int32)\nL_0087:\n\treturnVal1 = System.String::Format(*([v203 @ X8_v10 (System.String)]), v177, v202);\nL_0090:\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string FormatNumber(int number)
		{
			if (number > 999)
			{
				int num = 1000000 - 1;
				object arg;
				string format;
				object arg2;
				if (number > num)
				{
					if (number > 999999999)
					{
						return "";
					}
					int num2 = number / 1000000;
					object obj = num2;
					int num3 = num2 * 1000000;
					num = number - num3;
					num >>= 5;
					num *= 175921861;
					num >>= 39;
					arg = num;
					format = "{0}.{1}M";
					arg2 = obj;
				}
				else
				{
					num = number * 274877907;
					int num4 = num >> 38;
					object obj2 = num4;
					int num5 = num4 * 1000;
					num = number - num5;
					num *= 1374389535;
					num >>= 37;
					arg = num;
					format = "{0}.{1}K";
					arg2 = obj2;
				}
				return string.Format(format, arg2, arg);
			}
			object arg3 = number;
			return $"{arg3}";
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0xCC0F5C", Offset = "0xCC0F5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPShopSystem()
		{
		}
	}
}

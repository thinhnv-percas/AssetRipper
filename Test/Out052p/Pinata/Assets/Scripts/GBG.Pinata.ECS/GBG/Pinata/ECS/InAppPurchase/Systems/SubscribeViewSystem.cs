using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile;
using GBG.Pinata.ECS.InAppPurchase.Components;
using GBG.Pinata.ECS.InAppPurchase.Configs;
using Morpeh;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200004F")]
	public class SubscribeViewSystem : UpdateSystem
	{
		[Required]
		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x28")]
		public InAppConfig config;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x30")]
		private Filter filter;

		[Token(Token = "0x600009A")]
		[Address(RVA = "0xCC22F4", Offset = "0xCC22F4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDFC50]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202374E]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v52;\n\tv79 = new System.Action`1<EasyMobile.IAPProduct>();\n\tSystem.Action`1<EasyMobile.IAPProduct>::.ctor(v79, this, Il2CppMethodInfo);\n\tgoto L_0040;\n\tv91 = *([v87 @ X0_v9+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0040;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v87, v83, v61, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0040:\n\tEasyMobile.InAppPurchasing::add_PurchaseFailed(v79);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<SubscriptionViewComponent>();
			this.filter = filter;
			Action<IAPProduct> value = ShowError;
			InAppPurchasing.PurchaseFailed += value;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0xCC23C0", Offset = "0xCC23C0", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EE2AA8]);\n\tv35 = *([v34 @ X8_v25]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202374F]) = v54;\nL_001F:\n\tv59 = this.filter == 0;\n\tif (v59) goto L_00D2;\n\tv63 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv156 = v63.world;\nL_003E:\n\tv222 = 0x15F75B8(&v156 @ stack_-A0_v3 (Morpeh.World), 0, 0, 0, v40, v41, v42, v43, v63.ids, v63.world, v46, v47, v48, v49, v50, v51);\n\tv233 = v222 & 1;\n\tv234 = v233 == 0;\n\tif (v234) goto L_00C2;\n\tv256 = Il2CppMethodInfo;\n\tv257 = *([v238 @ stack_-78]);\n\tv261 = *([v257 @ X8_v15+126]) == 0;\n\tif (v261) goto L_0068;\n\tv431 = *([v257 @ X8_v15+B0]) + 8;\nL_004F:\n\t;\n\tv436 = *([v431 @ X11_v16-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v436) goto L_006A;\n\tv430 = v430 + 1;\n\tv465 = v430 < *([v257 @ X8_v15+126]);\n\tv287 = ~v465;\n\tv431 = v431 + 0x10;\n\tv271 = ~v287;\n\tif (v271) goto L_004F;\nL_0068:\n\tv472 = 0x8909C4(v238, Il2CppClass<Morpeh.IEntity>, *([v256 @ X21_v13 (Il2CppMethodInfo)+48]), 0, v40, v41, v42, v43, v63.ids, v63.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_006F;\nL_006A:\n\t;\n\tv467 = *([v431 @ X11_v16]) + *([v256 @ X21_v13 (Il2CppMethodInfo)+48]);\n\tv468 = v467 << 4;\n\tv469 = v257 + v468;\n\tv472 = v469 + 0x130;\nL_006F:\n\t;\n\tv476 = Morpeh.IEntity::GetComponent(*([v472 @ X0_v42+8]));\n\t*([v476 @ X0_v44 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)])(v313, v238, v476, *([v256 @ X21_v13 (Il2CppMethodInfo)+48]), 0, v40, v41, v42, v43, v63.ids, v63.world, v46, v47, v48, v49, v50, v51);\n\tv317 = this.config;\n\tTMPro.TMP_Text::set_text(*([v313 @ X0_v46+70]), v317.AndroidAgreementText);\n\tgoto L_008F;\n\tv629 = *([v597 @ X0_v48+E0]);\n\tv630 = v629 == 0;\n\tv631 = ~v630;\n\tif (v631) goto L_008F;\n\tv633 = \"il2cpp_codegen_runtime_class_init\"(v597, v566, v492, v176, v40, v41, v42, v43, v131, v133, v46, v47, v48, v49, v50, v51);\nL_008F:\n\tv499 = EasyMobile.InAppPurchasing::GetIAPProductByName(*([v313 @ X0_v46+8]));\n\tv530 = System.String::Concat(\"Then \", v499._price, \"/week\");\n\tTMPro.TMP_Text::set_text(*([v313 @ X0_v46+58]), v530);\n\tv560 = EasyMobile.InAppPurchasing::GetIAPProductByName(*([v313 @ X0_v46+18]));\n\tv590 = System.String::Concat(\"Then \", v560._price, \"/month\");\n\tTMPro.TMP_Text::set_text(*([v313 @ X0_v46+60]), v590);\n\tv623 = EasyMobile.InAppPurchasing::GetIAPProductByName(*([v313 @ X0_v46+10]));\n\tv638 = System.String::Concat(\"Then \", v623._price, \"/year\");\n\tTMPro.TMP_Text::set_text(*([v313 @ X0_v46+68]), v638);\n\tgoto L_003E;\nL_00C2:\n\tv242 = 0x15F7664(&v156 @ stack_-A0_v3 (Morpeh.World), 0, 0, 0, v40, v41, v42, v43, v63.ids, v63.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_0108;\n\tthrow System.NullReferenceException;\n\tv320 = new System.NullReferenceException();\n\tv464 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv536 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv596 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv160 = new System.NullReferenceException();\nL_00D2:\n\tv167 = new System.NullReferenceException();\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\nL_00F0:\n\tv232 = v157 != 1;\n\tif (v232) goto L_0109;\n\tv235 = 0x6D2BC0(v167, v157, v107, v67, v40, v41, v42, v43, v144, v156, v46, v47, v48, v49, v50, v51);\n\tv244 = 0x6D2490(v235, v157, v107, v67, v40, v41, v42, v43, v144, v156, v46, v47, v48, v49, v50, v51);\n\tv248 = 0x15F7664(&v118 @ stack_-80_v3 (Morpeh.World), 0, v107, v67, v40, v41, v42, v43, v144, v156, v46, v47, v48, v49, v50, v51);\n\tv375 = *([v235 @ X0_v10]) == 0;\n\tv250 = ~v375;\n\tif (v250) goto L_010D;\nL_0108:\n\treturn;\nL_0109:\n\tv236 = 0x6D2380(v167, v157, v107, v67, v40, v41, v42, v43, v144, v156, v46, v47, v48, v49, v50, v51);\nL_010D:\n\tthrow System.TypeLoadException;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_0347: Expected O, but got I
			//IL_0072: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			//IL_0119: Expected O, but got I
			//IL_0128: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_00be: Expected O, but got I
			//IL_01a4: Expected O, but got I
			//IL_01b7: Expected O, but got I
			//IL_01f6: Expected O, but got I
			//IL_0209: Expected O, but got I
			//IL_0248: Expected O, but got I
			bool flag = filter == null;
			World world2 = default(World);
			World world = world2;
			if (!flag)
			{
				world2 = filter.GetEnumerator().world;
				object obj = default(object);
				object obj3 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v15+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v15+B0]");
						object obj4 = 0L + 8L;
						int num = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ X11_v16-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v15+126]");
							bool flag2 = (long)num2 < 0L;
							bool flag3 = !flag2;
							obj4 = (long)(IntPtr)obj4 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_00d7;
						}
						object obj5 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ X21_v13 (Il2CppMethodInfo)+48]");
						object obj6 = obj5 + 0;
						int num3 = (int)((long)(IntPtr)obj6 << 4);
						object obj7 = (long)(IntPtr)obj2 + (long)num3;
						object obj8 = (long)(IntPtr)obj7 + 304L;
						goto IL_0335;
					}
					goto IL_00d7;
					IL_00d7:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0335;
					IL_0335:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ X0_v42+8]");
					ref SubscriptionViewComponent component = ref ((IEntity)0).GetComponent<SubscriptionViewComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v476 @ X0_v44 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)] (should have been resolved before IL gen)");
					InAppConfig inAppConfig = config;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X0_v46+70]");
					((TMP_Text)0).text = inAppConfig.AndroidAgreementText;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X0_v46+8]");
					IAPProduct iAPProductByName = InAppPurchasing.GetIAPProductByName((string)0);
					string text = "Then " + iAPProductByName.Price + "/week";
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X0_v46+58]");
					((TMP_Text)0).text = text;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X0_v46+18]");
					IAPProduct iAPProductByName2 = InAppPurchasing.GetIAPProductByName((string)0);
					string text2 = "Then " + iAPProductByName2.Price + "/month";
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X0_v46+60]");
					((TMP_Text)0).text = text2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X0_v46+10]");
					IAPProduct iAPProductByName3 = InAppPurchasing.GetIAPProductByName((string)0);
					string text3 = "Then " + iAPProductByName3.Price + "/year";
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X0_v46+68]");
					((TMP_Text)0).text = text3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr2 = default(IntPtr);
			if (intPtr2 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj9 = default(object);
				if (obj9 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0xCC26D8", Offset = "0xCC26D8", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED5E00]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, product, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023750]) = v40;\nL_0018:\n\tv45 = this.filter == 0;\n\tif (v45) goto L_0074;\n\tv49 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv126 = v49.world;\nL_002D:\n\tv184 = 0x15F75B8(&v126 @ stack_-70_v3 (Morpeh.World), 0, 0, v25, v26, v27, v28, v29, v49.ids, v49.world, v32, v33, v34, v35, v36, v37);\n\tv195 = v184 & 1;\n\tv196 = v195 == 0;\n\tif (v196) goto L_006F;\n\tv181 = Il2CppMethodInfo;\n\tv217 = *([v199 @ stack_-48]);\n\tv221 = *([v217 @ X8_v8+126]) == 0;\n\tif (v221) goto L_0057;\n\tv343 = *([v217 @ X8_v8+B0]) + 8;\nL_003E:\n\t;\n\tv348 = *([v343 @ X11_v9-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v348) goto L_0059;\n\tv342 = v342 + 1;\n\tv353 = v342 < *([v217 @ X8_v8+126]);\n\tv247 = ~v353;\n\tv343 = v343 + 0x10;\n\tv231 = ~v247;\n\tif (v231) goto L_003E;\nL_0057:\n\tv360 = 0x8909C4(v199, Il2CppClass<Morpeh.IEntity>, *([v181 @ X20_v7 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v49.ids, v49.world, v32, v33, v34, v35, v36, v37);\n\tgoto L_005E;\nL_0059:\n\t;\n\tv355 = *([v343 @ X11_v9]) + *([v181 @ X20_v7 (Il2CppMethodInfo)+48]);\n\tv356 = v355 << 4;\n\tv357 = v217 + v356;\n\tv360 = v357 + 0x130;\nL_005E:\n\t;\n\tv364 = Morpeh.IEntity::GetComponent(*([v360 @ X0_v24+8]));\n\t*([v364 @ X0_v26 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)])(v366, v199, v364, *([v181 @ X20_v7 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v49.ids, v49.world, v32, v33, v34, v35, v36, v37);\n\tUnityEngine.GameObject::SetActive(*([v366 @ X0_v28+30]), 1);\n\tgoto L_002D;\nL_006F:\n\tv203 = 0x15F7664(&v126 @ stack_-70_v3 (Morpeh.World), 0, 0, v25, v26, v27, v28, v29, v49.ids, v49.world, v32, v33, v34, v35, v36, v37);\n\tgoto L_0093;\n\tv223 = new System.NullReferenceException();\n\tv130 = new System.NullReferenceException();\nL_0074:\n\tv139 = new System.NullReferenceException();\n\tgoto L_0082;\n\tgoto L_0082;\n\tgoto L_0082;\n\tgoto L_0082;\nL_0082:\n\tv194 = v127 != 1;\n\tif (v194) goto L_0094;\n\tv197 = 0x6D2BC0(v139, v127, v89, v25, v26, v27, v28, v29, v114, v126, v32, v33, v34, v35, v36, v37);\n\tv205 = 0x6D2490(v197, v127, v89, v25, v26, v27, v28, v29, v114, v126, v32, v33, v34, v35, v36, v37);\n\tv209 = 0x15F7664(&v96 @ stack_-50_v3 (Morpeh.World), 0, v89, v25, v26, v27, v28, v29, v114, v126, v32, v33, v34, v35, v36, v37);\n\tv295 = *([v197 @ X0_v10]) == 0;\n\tv211 = ~v295;\n\tif (v211) goto L_0098;\nL_0093:\n\treturn;\nL_0094:\n\tv198 = 0x6D2380(v139, v127, v89, v25, v26, v27, v28, v29, v114, v126, v32, v33, v34, v35, v36, v37);\nL_0098:\n\tthrow System.TypeLoadException;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ShowError(IAPProduct product)
		{
			//IL_0242: Expected O, but got I
			//IL_0072: Expected O, but got I
			//IL_0143: Expected O, but got I
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			//IL_0119: Expected O, but got I
			//IL_0128: Expected O, but got I
			//IL_00be: Expected O, but got I
			bool flag = filter == null;
			World world2 = default(World);
			World world = world2;
			if (!flag)
			{
				world2 = filter.GetEnumerator().world;
				object obj = default(object);
				object obj3 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v8+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v8+B0]");
						object obj4 = 0L + 8L;
						int num = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ X11_v9-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v8+126]");
							bool flag2 = (long)num2 < 0L;
							bool flag3 = !flag2;
							obj4 = (long)(IntPtr)obj4 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_00d7;
						}
						object obj5 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X20_v7 (Il2CppMethodInfo)+48]");
						object obj6 = obj5 + 0;
						int num3 = (int)((long)(IntPtr)obj6 << 4);
						object obj7 = (long)(IntPtr)obj2 + (long)num3;
						object obj8 = (long)(IntPtr)obj7 + 304L;
						goto IL_0230;
					}
					goto IL_00d7;
					IL_00d7:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0230;
					IL_0230:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ X0_v24+8]");
					ref SubscriptionViewComponent component = ref ((IEntity)0).GetComponent<SubscriptionViewComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v364 @ X0_v26 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ X0_v28+30]");
					((GameObject)0).SetActive(value: true);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IAPProduct iAPProduct = default(IAPProduct);
			if ((IntPtr)iAPProduct == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj9 = default(object);
				if (obj9 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0xCC2868", Offset = "0xCC2868", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SubscribeViewSystem()
		{
		}
	}
}

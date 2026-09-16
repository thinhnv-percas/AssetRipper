using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile;
using GBG.Pinata.ECS.InAppPurchase.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200004B")]
	public class PinataSubscribeSystem : UpdateSystem
	{
		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x28")]
		public GlobalVariableInt RewardMultiplierGlobalVariable;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x30")]
		public int SubscribedRewardMultiplier;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x38")]
		private Filter filter;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x40")]
		private Filter filterView;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x48")]
		private bool isSubscribed;

		[Token(Token = "0x600008C")]
		[Address(RVA = "0xCC132C", Offset = "0xCC132C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF1990]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023745]) = v38;\nL_001A:\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.RewardMultiplierGlobalVariable, 1);\n\tv52 = Morpeh.FilterProvider::get_All(this.filter);\n\tv65 = Morpeh.Filter::With(v52, 1);\n\tthis.filter = v65;\n\tv53 = Morpeh.FilterProvider::get_All(this.filter);\n\tv78 = Morpeh.Filter::With(v53, 1);\n\tthis.filterView = v78;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			RewardMultiplierGlobalVariable.Value = 1;
			Filter all = Filter.All;
			Filter filter = all.With<SubscriptionComponent>();
			this.filter = filter;
			Filter all2 = Filter.All;
			Filter filter2 = all2.With<SubscriptionViewComponent>();
			filterView = filter2;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0xCC13F0", Offset = "0xCC13F0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.filter;\n\tv16 = v0.Length <= 0;\n\tif (v16) goto L_0017;\n\tv39 = ~this.isSubscribed;\n\tv40 = ~v39;\n\tif (v40) goto L_001B;\n\tGBG.Pinata.ECS.InAppPurchase.Systems.PinataSubscribeSystem::Subscribe(this);\n\treturn;\nL_0017:\n\tv41 = ~this.isSubscribed;\n\tif (v41) goto L_001B;\n\tGBG.Pinata.ECS.InAppPurchase.Systems.PinataSubscribeSystem::UnSubscribe(this);\n\treturn;\nL_001B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			Filter filter = this.filter;
			if (filter.Length > 0)
			{
				if (!isSubscribed)
				{
					Subscribe();
				}
			}
			else if (isSubscribed)
			{
				UnSubscribe();
			}
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0xCC142C", Offset = "0xCC142C", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EF3670]);\n\tv23 = *([v22 @ X8_v31]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023746]) = v42;\nL_001D:\n\tv51 = Morpeh.Filter::GetEnumerator(this.filterView);\n\tv130 = v51.world;\nL_002E:\n\tv243 = 0x15F75B8(&v130 @ stack_-70_v4 (Morpeh.World), 0, 0, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv286 = v243 & 1;\n\tv287 = v286 == 0;\n\tif (v287) goto L_0077;\n\tv230 = Il2CppMethodInfo;\n\tv342 = *([v289 @ stack_-48]);\n\tv346 = *([v342 @ X8_v25+126]) == 0;\n\tif (v346) goto L_0058;\n\tv423 = *([v342 @ X8_v25+B0]) + 8;\nL_0044:\n\tv428 = *([v423 @ X11_v12-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v428) goto L_005B;\n\tv422 = v422 + 1;\n\tv452 = v422 < *([v342 @ X8_v25+126]);\n\tv371 = ~v452;\n\tv423 = v423 + 0x10;\n\tv355 = ~v371;\n\tif (v355) goto L_0044;\nL_0058:\n\tv459 = 0x8909C4(v289, Il2CppClass<Morpeh.IEntity>, *([v230 @ X21_v9 (Il2CppMethodInfo)+48]), v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tgoto L_0061;\nL_005B:\n\tv454 = *([v423 @ X11_v12]) + *([v230 @ X21_v9 (Il2CppMethodInfo)+48]);\n\tv455 = v454 << 4;\n\tv456 = v342 + v455;\n\tv459 = v456 + 0x130;\nL_0061:\n\tv463 = Morpeh.IEntity::GetComponent(*([v459 @ X0_v36+8]));\n\t*([v463 @ X0_v38 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)])(v465, v289, v463, *([v230 @ X21_v9 (Il2CppMethodInfo)+48]), v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tUnityEngine.GameObject::SetActive(*([v465 @ X0_v40+20]), 0);\n\tv236 = *([v465 @ X0_v40+28]) == 0;\n\tif (v236) goto L_007C;\n\tUnityEngine.GameObject::SetActive(*([v465 @ X0_v40+28]), 1);\n\tgoto L_002E;\nL_0077:\n\tv293 = 0x15F7664(&v130 @ stack_-70_v4 (Morpeh.World), 0, 0, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tgoto L_009D;\n\tv348 = new System.NullReferenceException();\n\tv402 = new System.NullReferenceException();\nL_007C:\n\tv191 = new System.NullReferenceException();\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\nL_008C:\n\tv148 = v189 != 1;\n\tif (v148) goto L_00C8;\n\tv470 = 0x6D2BC0(v191, v189, v170, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv477 = 0x6D2490(v470, v189, v170, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv276 = 0x15F7664(&v130 @ stack_-70_v4 (Morpeh.World), 0, v170, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv486 = *([v470 @ X0_v28]) == 0;\n\tv278 = ~v486;\n\tif (v278) goto L_00CC;\nL_009D:\n\tgoto L_00A4;\n\tv445 = *([v408 @ X0_v15+E0]);\n\tv446 = v445 == 0;\n\tv447 = ~v446;\n\tif (v447) goto L_00A4;\n\tv449 = \"il2cpp_codegen_runtime_class_init\"(v408, v132, v92, v27, v28, v29, v30, v31, v105, v107, v34, v35, v36, v37, v38, v39);\nL_00A4:\n\tEasyMobile.Advertising::ResetRemoveAds();\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.RewardMultiplierGlobalVariable, 1);\n\tthis.isSubscribed = 0;\n\tgoto L_00BE;\n\tv478 = *([v473 @ X0_v19+E0]);\n\tv479 = v478 == 0;\n\tv480 = ~v479;\n\tif (v480) goto L_00BE;\n\tv482 = \"il2cpp_codegen_runtime_class_init\"(v473, v469, v310, v27, v28, v29, v30, v31, v105, v107, v34, v35, v36, v37, v38, v39);\nL_00BE:\n\tUnityEngine.Debug::Log(\"Pinata Unsubscription successful\");\n\treturn;\n\tv141 = new System.NullReferenceException();\nL_00C8:\n\tv198 = 0x6D2380(v190, v188, v169, v27, v28, v29, v30, v31, v178, v179, v34, v35, v36, v37, v38, v39);\nL_00CC:\n\tthrow System.TypeLoadException;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UnSubscribe()
		{
			//IL_02a7: Expected O, but got I
			//IL_006f: Expected O, but got I
			//IL_0144: Expected O, but got I
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_011a: Expected O, but got I
			//IL_0129: Expected O, but got I
			//IL_017f: Expected O, but got I
			//IL_00bb: Expected O, but got I
			World world = filterView.GetEnumerator().world;
			object obj = default(object);
			object obj3 = default(object);
			bool flag3 = default(bool);
			object obj9 = default(object);
			while (true)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ X8_v25+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00d4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ X8_v25+B0]");
					object obj4 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ X11_v12-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ X8_v25+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00d4;
					}
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X21_v9 (Il2CppMethodInfo)+48]");
					object obj6 = obj5 + 0;
					int num3 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)(IntPtr)obj2 + (long)num3;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_0296;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				goto IL_0225;
				IL_0225:
				Advertising.ResetRemoveAds();
				RewardMultiplierGlobalVariable.Value = 1;
				isSubscribed = false;
				Debug.Log("Pinata Unsubscription successful");
				return;
				IL_0296:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ X0_v36+8]");
				ref SubscriptionViewComponent component = ref ((IEntity)0).GetComponent<SubscriptionViewComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v463 @ X0_v38 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ X0_v40+20]");
				((GameObject)0).SetActive(value: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ X0_v40+28]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ X0_v40+28]");
					((GameObject)0).SetActive(value: true);
					continue;
				}
				NullReferenceException ex = new NullReferenceException();
				if (flag3)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
					if (obj9 != null)
					{
						break;
					}
					goto IL_0225;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				break;
				IL_00d4:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0296;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0xCC165C", Offset = "0xCC165C", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1ECD258]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023747]) = v42;\nL_001D:\n\tv51 = Morpeh.Filter::GetEnumerator(this.filterView);\n\tv130 = v51.world;\nL_002E:\n\tv243 = 0x15F75B8(&v130 @ stack_-70_v4 (Morpeh.World), 0, 0, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv286 = v243 & 1;\n\tv287 = v286 == 0;\n\tif (v287) goto L_0077;\n\tv230 = Il2CppMethodInfo;\n\tv342 = *([v289 @ stack_-48]);\n\tv346 = *([v342 @ X8_v26+126]) == 0;\n\tif (v346) goto L_0058;\n\tv424 = *([v342 @ X8_v26+B0]) + 8;\nL_0044:\n\tv429 = *([v424 @ X11_v12-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v429) goto L_005B;\n\tv423 = v423 + 1;\n\tv453 = v423 < *([v342 @ X8_v26+126]);\n\tv371 = ~v453;\n\tv424 = v424 + 0x10;\n\tv355 = ~v371;\n\tif (v355) goto L_0044;\nL_0058:\n\tv460 = 0x8909C4(v289, Il2CppClass<Morpeh.IEntity>, *([v230 @ X21_v9 (Il2CppMethodInfo)+48]), v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tgoto L_0061;\nL_005B:\n\tv455 = *([v424 @ X11_v12]) + *([v230 @ X21_v9 (Il2CppMethodInfo)+48]);\n\tv456 = v455 << 4;\n\tv457 = v342 + v456;\n\tv460 = v457 + 0x130;\nL_0061:\n\tv464 = Morpeh.IEntity::GetComponent(*([v460 @ X0_v36+8]));\n\t*([v464 @ X0_v38 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)])(v466, v289, v464, *([v230 @ X21_v9 (Il2CppMethodInfo)+48]), v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tUnityEngine.GameObject::SetActive(*([v466 @ X0_v40+20]), 1);\n\tv236 = *([v466 @ X0_v40+28]) == 0;\n\tif (v236) goto L_007C;\n\tUnityEngine.GameObject::SetActive(*([v466 @ X0_v40+28]), 0);\n\tgoto L_002E;\nL_0077:\n\tv293 = 0x15F7664(&v130 @ stack_-70_v4 (Morpeh.World), 0, 0, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tgoto L_009D;\n\tv348 = new System.NullReferenceException();\n\tv402 = new System.NullReferenceException();\nL_007C:\n\tv191 = new System.NullReferenceException();\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\n\tgoto L_008C;\nL_008C:\n\tv148 = v189 != 1;\n\tif (v148) goto L_00CA;\n\tv471 = 0x6D2BC0(v191, v189, v170, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv479 = 0x6D2490(v471, v189, v170, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv276 = 0x15F7664(&v130 @ stack_-70_v4 (Morpeh.World), 0, v170, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv488 = *([v471 @ X0_v28]) == 0;\n\tv278 = ~v488;\n\tif (v278) goto L_00CE;\nL_009D:\n\tgoto L_00A5;\n\tv446 = *([v409 @ X0_v15+E0]);\n\tv447 = v446 == 0;\n\tv448 = ~v447;\n\tif (v448) goto L_00A5;\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v409, v403, v92, v27, v28, v29, v30, v31, v105, v107, v34, v35, v36, v37, v38, v39);\nL_00A5:\n\tEasyMobile.Advertising::RemoveAds(0);\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.RewardMultiplierGlobalVariable, this.SubscribedRewardMultiplier);\n\tthis.isSubscribed = 1;\n\tgoto L_00C0;\n\tv480 = *([v475 @ X0_v19+E0]);\n\tv481 = v480 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_00C0;\n\tv484 = \"il2cpp_codegen_runtime_class_init\"(v475, v469, v310, v27, v28, v29, v30, v31, v105, v107, v34, v35, v36, v37, v38, v39);\nL_00C0:\n\tUnityEngine.Debug::Log(\"Pinata Subscription successful\");\n\treturn;\n\tv141 = new System.NullReferenceException();\nL_00CA:\n\tv198 = 0x6D2380(v190, v188, v169, v27, v28, v29, v30, v31, v178, v179, v34, v35, v36, v37, v38, v39);\nL_00CE:\n\tthrow System.TypeLoadException;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Subscribe()
		{
			//IL_02ad: Expected O, but got I
			//IL_006f: Expected O, but got I
			//IL_0144: Expected O, but got I
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_011a: Expected O, but got I
			//IL_0129: Expected O, but got I
			//IL_017f: Expected O, but got I
			//IL_00bb: Expected O, but got I
			World world = filterView.GetEnumerator().world;
			object obj = default(object);
			object obj3 = default(object);
			bool flag3 = default(bool);
			object obj9 = default(object);
			while (true)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ X8_v26+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00d4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ X8_v26+B0]");
					object obj4 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ X11_v12-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ X8_v26+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00d4;
					}
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X21_v9 (Il2CppMethodInfo)+48]");
					object obj6 = obj5 + 0;
					int num3 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)(IntPtr)obj2 + (long)num3;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_029c;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				goto IL_0225;
				IL_0225:
				Advertising.RemoveAds();
				RewardMultiplierGlobalVariable.Value = SubscribedRewardMultiplier;
				isSubscribed = true;
				Debug.Log("Pinata Subscription successful");
				return;
				IL_029c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ X0_v36+8]");
				ref SubscriptionViewComponent component = ref ((IEntity)0).GetComponent<SubscriptionViewComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v464 @ X0_v38 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X0_v40+20]");
				((GameObject)0).SetActive(value: true);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X0_v40+28]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X0_v40+28]");
					((GameObject)0).SetActive(value: false);
					continue;
				}
				NullReferenceException ex = new NullReferenceException();
				if (flag3)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
					if (obj9 != null)
					{
						break;
					}
					goto IL_0225;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				break;
				IL_00d4:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_029c;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0xCC1894", Offset = "0xCC1894", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PinataSubscribeSystem()
		{
		}
	}
}

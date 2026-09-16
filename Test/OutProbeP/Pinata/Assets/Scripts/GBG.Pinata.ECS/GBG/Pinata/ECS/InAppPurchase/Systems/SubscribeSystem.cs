using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile;
using GBG.Pinata.ECS.InAppPurchase.Components;
using Morpeh;
using UnityEngine;
using UnityEngine.Purchasing;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200004E")]
	public class SubscribeSystem : UpdateSystem
	{
		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x30")]
		private IAPProduct[] products;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x38")]
		private bool isSubscribed;

		[Token(Token = "0x6000097")]
		[Address(RVA = "0xCC1E38", Offset = "0xCC1E38", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA9688]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202374C]) = v38;\nL_0014:\n\tv40 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tthis.products = v40.mProducts;\n\tv48 = Morpeh.FilterProvider::get_All(this.filter);\n\tv60 = Morpeh.Filter::With(v48, 1);\n\tthis.filter = v60;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
			products = inAppPurchasing.Products;
			Filter all = Filter.All;
			Filter filter = all.With<SubscriptionComponent>();
			this.filter = filter;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0xCC1EBC", Offset = "0xCC1EBC", Length = "0x430")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1ECAB98]);\n\tv39 = *([v38 @ X8_v51]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, deltaTime, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([202374D]) = v58;\nL_001E:\n\tv60 = 0;\n\tgoto L_002F;\n\tv70 = *([v66 @ X0_v2+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_002F;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v42, v43, v44, v45, v46, v47, v63, v49, v50, v51, v52, v53, v54, v55);\nL_002F:\n\tv78 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv80 = v78 == 0;\n\tif (v80) goto L_01B6;\n\tv81 = this.products;\n\tv189 = v81.Length < 1;\n\tif (v189) goto L_01B6;\nL_0057:\n\tv169 = v81[v178 @ X25_v9 (System.Int32)];\n\tv190 = v169._type != 2;\n\tif (v190) goto L_0199;\n\tgoto L_0073;\n\tv668 = *([v613 @ X0_v20+E0]);\n\tv669 = v668 == 0;\n\tv670 = ~v669;\n\tif (v670) goto L_0073;\n\tv672 = \"il2cpp_codegen_runtime_class_init\"(v613, v284, v152, v89, v44, v45, v46, v47, v98, v101, v50, v51, v52, v53, v54, v55);\nL_0073:\n\tv234 = EasyMobile.InAppPurchasing::GetSubscriptionInfo(v169._name);\n\tv237 = v234 == 0;\n\tif (v237) goto L_01B6;\n\tv677 = UnityEngine.Purchasing.SubscriptionInfo::getRemainingTime(v234);\n\tv78 = 0x9BD218(&v677 @ X0_v25 (System.TimeSpan), 0, v355, v522, v44, v45, v46, v47, v97, v754.world, v50, v51, v52, v53, v54, v55);\n\tv683 = UnityEngine.Purchasing.SubscriptionInfo::isCancelled(v234);\n\tv652 = UnityEngine.Purchasing.SubscriptionInfo::isSubscribed(v234);\n\tv685 = v652 == 0;\n\tv686 = ~v685;\n\tif (v686) goto L_00BD;\n\tv687 = ~this.isSubscribed;\n\tv688 = ~v687;\n\tif (v688) goto L_00BD;\n\tv451 = Morpeh.World::CreateEntity(this.world, &v60 @ stack_-7C_v1 (System.Int32));\n\tv716 = Il2CppMethodInfo;\n\tv717 = *([v451 @ X0_v48 (Morpeh.IEntity)]);\n\tv721 = *([v717 @ X8_v33 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v721) goto L_00BB;\n\tv757 = *([v717 @ X8_v33 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_00A2:\n\t;\n\tv771 = *([v757 @ X11_v19-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v771) goto L_0113;\n\tv756 = v756 + 1;\n\tv776 = v756 < *([v717 @ X8_v33 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv749 = ~v776;\n\tv757 = v757 + 0x10;\n\tv733 = ~v749;\n\tif (v733) goto L_00A2;\nL_00BB:\n\tv78 = 0x8909C4(v451, Il2CppClass<Morpeh.IEntity>, *([v716 @ X22_v11 (Il2CppMethodInfo)+48]), v522, v44, v45, v46, v47, v97, v754.world, v50, v51, v52, v53, v54, v55);\n\tgoto L_0118;\nL_00BD:\n\tv655 = ~this.isSubscribed;\n\tif (v655) goto L_0199;\n\tv692 = v683 - 1;\n\tv694 = v692 == 0;\n\tv699 = ~v694;\n\tv350 = ~v699;\n\tif (v350) goto L_FFFFFFFF;\n\tv700 = v97 < 0;\n\tv390 = ~v700;\n\tv384 = v97 == 0;\n\tgoto L_00DA;\nL_00DA:\n\tv713 = ~v390;\n\tv374 = v713 | v384;\n\tif (v374) goto L_00E4;\n\tv656 = v652 == 0;\n\tif (v656) goto L_0199;\nL_00E4:\n\tv754 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv348 = v754.world;\nL_00F3:\n\tv78 = 0x15F75B8(&v348 @ stack_-C0_v9 (Morpeh.World), 0, v355, v522, v44, v45, v46, v47, v754.ids, v754.world, v50, v51, v52, v53, v54, v55);\n\tv825 = v78 & 1;\n\tv826 = v825 == 0;\n\tif (v826) goto L_016E;\n\tv395 = this.world == 0;\n\tif (v395) goto L_0170;\n\tMorpeh.World::RemoveEntity(this.world, v879);\n\tv898 = System.String::Concat(\"Subscription \", v169._name, \" cancelled\");\n\tgoto L_0111;\n\tv922 = *([v910 @ X0_v43+E0]);\n\tv923 = v922 == 0;\n\tv924 = ~v923;\n\tif (v924) goto L_0111;\n\tv926 = \"il2cpp_codegen_runtime_class_init\"(v910, v895, v802, v801, v44, v45, v46, v47, v330, v332, v50, v51, v52, v53, v54, v55);\nL_0111:\n\tUnityEngine.Debug::Log(v898);\n\tgoto L_00F3;\nL_0113:\n\t;\n\tv778 = *([v757 @ X11_v19]) + *([v716 @ X22_v11 (Il2CppMethodInfo)+48]);\n\tv779 = v778 << 4;\n\tv780 = v717 + v779;\n\tv78 = v780 + 0x130;\nL_0118:\n\t;\n\tv800 = Morpeh.IEntity::AddComponent(*([v78 @ X0_v5 (System.Boolean)+8]));\n\t*([v800 @ X0_v51 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionComponent&)])(v78, v451, v800, *([v716 @ X22_v11 (Il2CppMethodInfo)+48]), v522, v44, v45, v46, v47, v97, v754.world, v50, v51, v52, v53, v54, v55);\n\tv624 = Il2CppMethodInfo;\n\tv820 = *([v451 @ X0_v48 (Morpeh.IEntity)]);\n\tv824 = *([v820 @ X8_v38 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v824) goto L_0145;\n\tv859 = *([v820 @ X8_v38 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_012C:\n\t;\n\tv873 = *([v859 @ X11_v14-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v873) goto L_0147;\n\tv858 = v858 + 1;\n\tv882 = v858 < *([v820 @ X8_v38 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv853 = ~v882;\n\tv859 = v859 + 0x10;\n\tv837 = ~v853;\n\tif (v837) goto L_012C;\nL_0145:\n\tv78 = 0x8909C4(v451, Il2CppClass<Morpeh.IEntity>, *([v624 @ X22_v12 (Il2CppMethodInfo)+48]), v522, v44, v45, v46, v47, v97, v754.world, v50, v51, v52, v53, v54, v55);\n\tgoto L_014C;\nL_0147:\n\t;\n\tv884 = *([v859 @ X11_v14]) + *([v624 @ X22_v12 (Il2CppMethodInfo)+48]);\n\tv885 = v884 << 4;\n\tv886 = v820 + v885;\n\tv78 = v886 + 0x130;\nL_014C:\n\t;\n\tv893 = Morpeh.IEntity::GetComponent(*([v78 @ X0_v5 (System.Boolean)+8]));\n\t*([v893 @ X0_v56 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionComponent&)])(v78, v451, v893, *([v624 @ X22_v12 (Il2CppMethodInfo)+48]), v522, v44, v45, v46, v47, v97, v754.world, v50, v51, v52, v53, v54, v55);\n\t*([v78 @ X0_v5 (System.Boolean)]) = v81[v178 @ X25_v9 (System.Int32)];\n\tv909 = System.String::Concat(\"Subscription \", v169._name, \" applied!\");\n\tgoto L_016A;\n\tv928 = *([v918 @ X8_v43+E0]);\n\tv929 = v928 == 0;\n\tv930 = ~v929;\n\tgoto L_016A;\n\tv933 = v918;\n\tv932 = \"il2cpp_codegen_runtime_class_init\"(v933, v906, v623, v619, v44, v45, v46, v47, v98, v101, v50, v51, v52, v53, v54, v55);\nL_016A:\n\tUnityEngine.Debug::Log(v909);\n\tthis.isSubscribed = 1;\n\tgoto L_0199;\nL_016E:\n\tv667 = v243 + 1;\n\tgoto L_0188;\nL_0170:\n\tv393 = new System.NullReferenceException();\n\tGBG.Pinata.ECS.InAppPurchase.Systems.SubscribeSystem::.ctor(v393);\n\treturn;\n\tgoto L_0177;\n\tgoto L_0177;\n\tgoto L_0177;\n\tgoto L_0177;\nL_0177:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01BD;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tstack[8] = X8;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0188:\n\tv78 = 0x15F7664(&v348 @ stack_-C0_v9 (Morpeh.World), 0, v355, v522, v44, v45, v46, v47, v754.ids, v754.world, v50, v51, v52, v53, v54, v55);\n\tv899 = v667 + 1;\n\tv641 = v899 == 0;\n\tif (v641) goto L_0196;\n\tv915 = 0xFFFFFFFF ^ v667;\n\tv243 = v667 + v915;\n\tgoto L_0198;\nL_0196:\n\tgoto L_01BF;\nL_0198:\n\tthis.isSubscribed = 0;\nL_0199:\n\t;\n\tv178 = v178 + 1;\n\tv187 = v178 < v81.Length;\n\tif (v187) goto L_0057;\nL_01B6:\n\treturn;\n\tv460 = new System.NullReferenceException();\n\tv518 = new System.IndexOutOfRangeException();\nL_01BC:\n\tv609 = new System.TypeLoadException();\nL_01BD:\n\tv78 = 0x6D2380(v609, 0, 0, v521, v44, v45, v46, v47, v527, v529, v50, v51, v52, v53, v54, v55);\nL_01BF:\n\tgoto L_01BC;\n\treturn;\n// 270 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_0074: Expected O, but got I8
			//IL_019c: Expected I, but got O
			//IL_061e: Expected O, but got I
			//IL_063b: Expected I, but got O
			//IL_01da: Expected O, but got I
			//IL_04fe: Expected O, but got I
			//IL_0531: Expected O, but got I
			//IL_06f7: Expected O, but got I
			//IL_0717: Expected I4, but got O
			//IL_0404: Expected O, but got I
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Expected O, but got Unknown
			//IL_03d9: Expected O, but got I
			//IL_04e1: Expected O, but got I4
			//IL_0226: Expected O, but got I
			//IL_0561: Expected I4, but got I8
			//IL_056f: Expected O, but got I
			//IL_048e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0493: Expected O, but got Unknown
			//IL_04b0: Expected O, but got I
			//IL_0450: Expected O, but got I
			//IL_0398: Expected O, but got I4
			int id = 0;
			bool flag = InAppPurchasing.IsInitialized();
			if (!flag)
			{
				return;
			}
			IAPProduct[] array = products;
			if (array.Length < 1)
			{
				return;
			}
			int[] array2 = null;
			int num = 0;
			object obj = 4294967295L;
			IEntity entity2 = default(IEntity);
			while (true)
			{
				IAPProduct iAPProduct = array[num];
				IEntity entity;
				object obj6;
				string text;
				if (iAPProduct.Type == IAPProductType.Subscription)
				{
					SubscriptionInfo subscriptionInfo = InAppPurchasing.GetSubscriptionInfo(iAPProduct.Name);
					if (subscriptionInfo == null)
					{
						return;
					}
					TimeSpan remainingTime = subscriptionInfo.getRemainingTime();
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD218 (inside System.TimeSpan::TimeToTicks +0x298)");
					Result result = subscriptionInfo.isCancelled();
					Result result2 = subscriptionInfo.isSubscribed();
					if (result2 == Result.True && !isSubscribed)
					{
						entity = World.CreateEntity(out id);
						IntPtr intPtr = (IntPtr)0;
						IntPtr intPtr2 = (IntPtr)entity;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X8_v33 (Il2CppClass<Morpeh.IEntity>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_023f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X8_v33 (Il2CppClass<Morpeh.IEntity>)+B0]");
						object obj2 = 0L + 8L;
						int num2 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X11_v19-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num2++;
							int num3 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X8_v33 (Il2CppClass<Morpeh.IEntity>)+126]");
							bool flag2 = (long)num3 < 0L;
							bool flag3 = !flag2;
							obj2 = (long)(IntPtr)obj2 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_023f;
						}
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ X22_v11 (Il2CppMethodInfo)+48]");
						object obj4 = obj3 + 0;
						int num4 = (int)((long)(IntPtr)obj4 << 4);
						object obj5 = (long)intPtr2 + (long)num4;
						flag = (byte)((ulong)(long)(IntPtr)obj5 + 304uL) != 0;
						goto IL_060c;
					}
					if (isSubscribed)
					{
						bool flag5;
						bool flag6;
						if (result - 1 != Result.True)
						{
							bool flag4 = (long)(IntPtr)array2 < 0L;
							flag5 = !flag4;
							flag6 = array2 == null;
						}
						else
						{
							flag6 = false;
							flag5 = true;
						}
						bool flag7 = !flag5;
						if (flag7 || flag6 || result2 != Result.True)
						{
							Filter.EntityEnumerator enumerator = filter.GetEnumerator();
							World world = enumerator.world;
							while (true)
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
								if (((flag ? 1u : 0u) & 1u) == 0)
								{
									break;
								}
								if (World != null)
								{
									World.RemoveEntity(entity2);
									string message = "Subscription " + iAPProduct.Name + " cancelled";
									Debug.Log(message);
									obj6 = 0;
									text = " cancelled";
									continue;
								}
								NullReferenceException ex = (NullReferenceException)(object)new SubscribeSystem();
								return;
							}
							object obj7 = (long)(IntPtr)obj + 1L;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
							object obj8 = (long)(IntPtr)obj7 + 1L;
							if (obj8 == null)
							{
								break;
							}
							int num5 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj7);
							obj = (long)(IntPtr)obj7 + (long)num5;
							isSubscribed = false;
							array2 = enumerator.ids;
						}
					}
				}
				goto IL_05bc;
				IL_05bc:
				num++;
				if (num >= array.Length)
				{
					return;
				}
				continue;
				IL_0469:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_06e5;
				IL_060c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v5 (System.Boolean)+8]");
				ref SubscriptionComponent reference = ref ((IEntity)0).AddComponent<SubscriptionComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v800 @ X0_v51 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionComponent&)] (should have been resolved before IL gen)");
				IntPtr intPtr3 = (IntPtr)0;
				IntPtr intPtr4 = (IntPtr)entity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ X8_v38 (Il2CppClass<Morpeh.IEntity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0469;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ X8_v38 (Il2CppClass<Morpeh.IEntity>)+B0]");
				object obj9 = 0L + 8L;
				int num6 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X11_v14-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num6++;
					int num7 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ X8_v38 (Il2CppClass<Morpeh.IEntity>)+126]");
					bool flag8 = (long)num7 < 0L;
					bool flag9 = !flag8;
					obj9 = (long)(IntPtr)obj9 + 16L;
					if (!flag9)
					{
						continue;
					}
					goto IL_0469;
				}
				object obj10 = obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ X22_v12 (Il2CppMethodInfo)+48]");
				object obj11 = obj10 + 0;
				int num8 = (int)((long)(IntPtr)obj11 << 4);
				object obj12 = (long)intPtr4 + (long)num8;
				flag = (byte)((ulong)(long)(IntPtr)obj12 + 304uL) != 0;
				goto IL_06e5;
				IL_06e5:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v5 (System.Boolean)+8]");
				ref SubscriptionComponent component = ref ((IEntity)0).GetComponent<SubscriptionComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v893 @ X0_v56 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionComponent&)] (should have been resolved before IL gen)");
				flag = (byte)(int)array[num] != 0;
				string message2 = "Subscription " + iAPProduct.Name + " applied!";
				Debug.Log(message2);
				isSubscribed = true;
				obj6 = 0;
				text = " applied!";
				goto IL_05bc;
				IL_023f:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_060c;
			}
			while (true)
			{
				TypeLoadException ex2 = new TypeLoadException();
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0xCC22EC", Offset = "0xCC22EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SubscribeSystem()
		{
		}
	}
}

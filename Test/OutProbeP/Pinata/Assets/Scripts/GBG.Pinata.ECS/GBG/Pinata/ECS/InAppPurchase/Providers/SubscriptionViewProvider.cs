using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.InAppPurchase.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine.Events;

namespace GBG.Pinata.ECS.InAppPurchase.Providers
{
	[Token(Token = "0x2000055")]
	public class SubscriptionViewProvider : MonoProvider<SubscriptionViewComponent>
	{
		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x98")]
		private string SubscriptionName;

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0xCBFB20", Offset = "0xCBFB20", Length = "0x3EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EFC190]);\n\tv25 = *([v24 @ X8_v59]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202372E]) = v44;\nL_001A:\n\tv48 = 0;\n\tv51 = Morpeh.MonoProvider`1<GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent>::GetData(this, &v48 @ stack_-34_v1 (System.Boolean));\n\t// 35 NewArr v58 @ X0_v5 (System.Object[]), typeof(System.Object[]), 4\n\tv62 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]) == 0;\n\tif (v62) goto L_0030;\n\t// 45 IsInst v241 @ X0_v16 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]\nL_0030:\n\tv136 = v58.Length;\n\tv151 = v58.Length == 0;\n\tif (v151) goto L_0171;\n\tv58[0] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]);\n\tv153 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]) == 0;\n\tif (v153) goto L_003E;\n\t// 58 IsInst v241 @ X0_v16 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]\n\tv136 = v58.Length;\nL_003E:\n\tv376 = v136 < 1;\n\tv211 = ~v376;\n\tv204 = v136 - 1;\n\tv190 = v204 == 0;\n\tv377 = ~v211;\n\tv155 = v377 | v190;\n\tif (v155) goto L_0171;\n\tv58[1] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]);\n\tv381 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]) == 0;\n\tif (v381) goto L_0055;\n\t// 81 IsInst v241 @ X0_v16 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]\n\tv136 = v58.Length;\nL_0055:\n\tv384 = v136 < 2;\n\tv212 = ~v384;\n\tv205 = v136 - 2;\n\tv191 = v205 == 0;\n\tv385 = ~v212;\n\tv156 = v385 | v191;\n\tif (v156) goto L_0171;\n\tv58[2] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]);\n\tv386 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]) == 0;\n\tif (v386) goto L_006C;\n\t// 104 IsInst v242 @ X0_v17 (GBG.Pinata.ECS.InAppPurchase.Providers.SubscriptionViewProvider), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]\n\tv136 = v58.Length;\nL_006C:\n\tv389 = v136 < 3;\n\tv106 = ~v389;\n\tv101 = v136 - 3;\n\tv91 = v101 == 0;\n\tv390 = ~v106;\n\tv66 = v390 | v91;\n\tif (v66) goto L_0171;\n\tv58[3] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]);\n\tGBG.Pinata.ECS.InAppPurchase.Providers.SubscriptionViewProvider::AssertIsNotNull(v242, v58, Il2CppMethodInfo);\n\t// 125 NewArr v128 @ X0_v19 (System.Object[]), typeof(System.Object[]), 4\n\tv393 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+58]) == 0;\n\tif (v393) goto L_008A;\n\t// 135 IsInst v244 @ X0_v22 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+58]\nL_008A:\n\tv137 = v128.Length;\n\tv249 = v128.Length == 0;\n\tif (v249) goto L_0171;\n\tv128[0] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+58]);\n\tv397 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+60]) == 0;\n\tif (v397) goto L_0098;\n\t// 148 IsInst v244 @ X0_v22 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+60]\n\tv137 = v128.Length;\nL_0098:\n\tv400 = v137 < 1;\n\tv213 = ~v400;\n\tv206 = v137 - 1;\n\tv192 = v206 == 0;\n\tv401 = ~v213;\n\tv157 = v401 | v192;\n\tif (v157) goto L_0171;\n\tv128[1] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+60]);\n\tv402 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+68]) == 0;\n\tif (v402) goto L_00AF;\n\t// 171 IsInst v244 @ X0_v22 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+68]\n\tv137 = v128.Length;\nL_00AF:\n\tv405 = v137 < 2;\n\tv214 = ~v405;\n\tv207 = v137 - 2;\n\tv193 = v207 == 0;\n\tv406 = ~v214;\n\tv158 = v406 | v193;\n\tif (v158) goto L_0171;\n\tv128[2] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+68]);\n\tv407 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+70]) == 0;\n\tif (v407) goto L_00C6;\n\t// 194 IsInst v245 @ X0_v23 (GBG.Pinata.ECS.InAppPurchase.Providers.SubscriptionViewProvider), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+70]\n\tv137 = v128.Length;\nL_00C6:\n\tv410 = v137 < 3;\n\tv107 = ~v410;\n\tv102 = v137 - 3;\n\tv92 = v102 == 0;\n\tv411 = ~v107;\n\tv67 = v411 | v92;\n\tif (v67) goto L_0171;\n\tv128[3] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+70]);\n\tGBG.Pinata.ECS.InAppPurchase.Providers.SubscriptionViewProvider::AssertIsNotNull(v245, v128, Il2CppMethodInfo);\n\t// 215 NewArr v129 @ X0_v25 (System.Object[]), typeof(System.Object[]), 3\n\tv414 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+20]) == 0;\n\tif (v414) goto L_00E4;\n\t// 225 IsInst v246 @ X0_v27 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+20]\nL_00E4:\n\tv267 = v129.Length;\n\tv250 = v129.Length == 0;\n\tif (v250) goto L_0171;\n\tv129[0] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+20]);\n\tv418 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+28]) == 0;\n\tif (v418) goto L_00F2;\n\t// 238 IsInst v246 @ X0_v27 (System.Object[]), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+28]\n\tv267 = v129.Length;\nL_00F2:\n\tv421 = v267 < 1;\n\tv215 = ~v421;\n\tv208 = v267 - 1;\n\tv194 = v208 == 0;\n\tv422 = ~v215;\n\tv159 = v422 | v194;\n\tif (v159) goto L_0171;\n\tv129[1] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+28]);\n\tv423 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+30]) == 0;\n\tif (v423) goto L_0109;\n\t// 261 IsInst v247 @ X0_v28 (GBG.Pinata.ECS.InAppPurchase.Providers.SubscriptionViewProvider), typeof(System.Object), [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+30]\n\tv267 = v129.Length;\nL_0109:\n\tv426 = v267 < 2;\n\tv216 = ~v426;\n\tv209 = v267 - 2;\n\tv195 = v209 == 0;\n\tv427 = ~v216;\n\tv160 = v427 | v195;\n\tif (v160) goto L_0171;\n\tv129[2] = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+30]);\n\tGBG.Pinata.ECS.InAppPurchase.Providers.SubscriptionViewProvider::AssertIsNotNull(v247, v129, Il2CppMethodInfo);\n\tthis.SubscriptionName = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+8]);\n\tv430 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]);\n\tv436 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v436, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v430 @ X8_v25+E8]), v436);\n\tv474 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]);\n\tv462 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v462, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v474 @ X8_v29+E8]), v462);\n\tv476 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]);\n\tv464 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v464, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v476 @ X8_v32+E8]), v464);\n\tv478 = *([v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]);\n\tv466 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v466, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(*([v478 @ X8_v35+E8]), v466);\n\treturn;\nL_0171:\n\tv268 = ne\n// ... truncated")]
		protected override void Initialize()
		{
			//IL_0056: Expected O, but got I4
			//IL_0043: Expected O, but got I
			//IL_008f: Expected O, but got I
			//IL_06c7: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_00f7: Expected O, but got I
			//IL_00d8: Expected O, but got I4
			//IL_0725: Expected O, but got I
			//IL_012d: Expected O, but got I
			//IL_015f: Expected O, but got I
			//IL_0140: Expected O, but got I4
			//IL_0783: Expected O, but got I
			//IL_019d: Expected O, but got I
			//IL_01cf: Expected O, but got I
			//IL_01de: Expected O, but got I
			//IL_01b0: Expected O, but got I4
			//IL_0242: Expected O, but got I4
			//IL_022f: Expected O, but got I
			//IL_027b: Expected O, but got I
			//IL_07e1: Expected O, but got I
			//IL_02b1: Expected O, but got I
			//IL_02e3: Expected O, but got I
			//IL_02c4: Expected O, but got I4
			//IL_083f: Expected O, but got I
			//IL_0319: Expected O, but got I
			//IL_034b: Expected O, but got I
			//IL_032c: Expected O, but got I4
			//IL_089d: Expected O, but got I
			//IL_0389: Expected O, but got I
			//IL_03bb: Expected O, but got I
			//IL_03ca: Expected O, but got I
			//IL_039c: Expected O, but got I4
			//IL_042e: Expected O, but got I4
			//IL_041b: Expected O, but got I
			//IL_0467: Expected O, but got I
			//IL_08fb: Expected O, but got I
			//IL_049d: Expected O, but got I
			//IL_04cf: Expected O, but got I
			//IL_04b0: Expected O, but got I4
			//IL_0959: Expected O, but got I
			//IL_050d: Expected O, but got I
			//IL_053f: Expected O, but got I
			//IL_054e: Expected O, but got I
			//IL_0560: Expected O, but got I
			//IL_0570: Expected O, but got I
			//IL_0520: Expected O, but got I4
			//IL_05a0: Expected O, but got I
			//IL_05b0: Expected O, but got I
			//IL_05e0: Expected O, but got I
			//IL_05f0: Expected O, but got I
			//IL_0620: Expected O, but got I
			//IL_0630: Expected O, but got I
			//IL_0660: Expected O, but got I
			bool existOnEntity = false;
			ref SubscriptionViewComponent data = ref GetData(out existOnEntity);
			object[] array = new object[4];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]");
			bool flag = (IntPtr)0 == (IntPtr)0;
			object[] array2 = array;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]");
				array2 = (object[])(0 as object);
			}
			object obj = array.Length;
			if (array.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]");
				array[0] = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]");
					array2 = (object[])(0 as object);
					obj = array.Length;
				}
				bool flag2 = (long)(IntPtr)obj < 1L;
				bool flag3 = !flag2;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag4 = obj2 == null;
				bool flag5 = !flag3;
				if (!(flag5 || flag4))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]");
					array[1] = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]");
						array2 = (object[])(0 as object);
						obj = array.Length;
					}
					bool flag6 = (long)(IntPtr)obj < 2L;
					bool flag7 = !flag6;
					object obj3 = (long)(IntPtr)obj - 2L;
					bool flag8 = obj3 == null;
					bool flag9 = !flag7;
					if (!(flag9 || flag8))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]");
						array[2] = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]");
						bool flag10 = (IntPtr)0 == (IntPtr)0;
						SubscriptionViewProvider subscriptionViewProvider = (SubscriptionViewProvider)(object)array2;
						if (!flag10)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]");
							subscriptionViewProvider = (SubscriptionViewProvider)(0 as object);
							obj = array.Length;
						}
						bool flag11 = (long)(IntPtr)obj < 3L;
						bool flag12 = !flag11;
						object obj4 = (long)(IntPtr)obj - 3L;
						bool flag13 = obj4 == null;
						bool flag14 = !flag12;
						if (!(flag14 || flag13))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]");
							array[3] = 0;
							subscriptionViewProvider.AssertIsNotNull(array, (string)0);
							object[] array3 = new object[4];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+58]");
							bool flag15 = (IntPtr)0 == (IntPtr)0;
							object[] array4 = array3;
							if (!flag15)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+58]");
								array4 = (object[])(0 as object);
							}
							object obj5 = array3.Length;
							if (array3.Length != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+58]");
								array3[0] = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+60]");
								if ((IntPtr)0 != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+60]");
									array4 = (object[])(0 as object);
									obj5 = array3.Length;
								}
								bool flag16 = (long)(IntPtr)obj5 < 1L;
								bool flag17 = !flag16;
								object obj6 = (long)(IntPtr)obj5 - 1L;
								bool flag18 = obj6 == null;
								bool flag19 = !flag17;
								if (!(flag19 || flag18))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+60]");
									array3[1] = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+68]");
									if ((IntPtr)0 != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+68]");
										array4 = (object[])(0 as object);
										obj5 = array3.Length;
									}
									bool flag20 = (long)(IntPtr)obj5 < 2L;
									bool flag21 = !flag20;
									object obj7 = (long)(IntPtr)obj5 - 2L;
									bool flag22 = obj7 == null;
									bool flag23 = !flag21;
									if (!(flag23 || flag22))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+68]");
										array3[2] = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+70]");
										bool flag24 = (IntPtr)0 == (IntPtr)0;
										SubscriptionViewProvider subscriptionViewProvider2 = (SubscriptionViewProvider)(object)array4;
										if (!flag24)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+70]");
											subscriptionViewProvider2 = (SubscriptionViewProvider)(0 as object);
											obj5 = array3.Length;
										}
										bool flag25 = (long)(IntPtr)obj5 < 3L;
										bool flag26 = !flag25;
										object obj8 = (long)(IntPtr)obj5 - 3L;
										bool flag27 = obj8 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+70]");
											array3[3] = 0;
											subscriptionViewProvider2.AssertIsNotNull(array3, (string)0);
											object[] array5 = new object[3];
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+20]");
											bool flag29 = (IntPtr)0 == (IntPtr)0;
											object[] array6 = array5;
											if (!flag29)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+20]");
												array6 = (object[])(0 as object);
											}
											object obj9 = array5.Length;
											if (array5.Length != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+20]");
												array5[0] = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+28]");
												if ((IntPtr)0 != (IntPtr)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+28]");
													array6 = (object[])(0 as object);
													obj9 = array5.Length;
												}
												bool flag30 = (long)(IntPtr)obj9 < 1L;
												bool flag31 = !flag30;
												object obj10 = (long)(IntPtr)obj9 - 1L;
												bool flag32 = obj10 == null;
												bool flag33 = !flag31;
												if (!(flag33 || flag32))
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+28]");
													array5[1] = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+30]");
													bool flag34 = (IntPtr)0 == (IntPtr)0;
													SubscriptionViewProvider subscriptionViewProvider3 = (SubscriptionViewProvider)(object)array6;
													if (!flag34)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+30]");
														subscriptionViewProvider3 = (SubscriptionViewProvider)(0 as object);
														obj9 = array5.Length;
													}
													bool flag35 = (long)(IntPtr)obj9 < 2L;
													bool flag36 = !flag35;
													object obj11 = (long)(IntPtr)obj9 - 2L;
													bool flag37 = obj11 == null;
													bool flag38 = !flag36;
													if (!(flag38 || flag37))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+30]");
														array5[2] = 0;
														subscriptionViewProvider3.AssertIsNotNull(array5, (string)0);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+8]");
														SubscriptionName = (string)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+40]");
														object obj12 = 0;
														UnityAction call = delegate
														{
															//IL_002e: Expected O, but got I
															bool existOnEntity2 = false;
															ref SubscriptionViewComponent data2 = ref GetData(out existOnEntity2);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+8]");
															SubscriptionName = (string)0;
														};
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ X8_v25+E8]");
														((UnityEvent)0).AddListener(call);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+48]");
														object obj13 = 0;
														UnityAction call2 = delegate
														{
															//IL_002e: Expected O, but got I
															bool existOnEntity2 = false;
															ref SubscriptionViewComponent data2 = ref GetData(out existOnEntity2);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+10]");
															SubscriptionName = (string)0;
														};
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v29+E8]");
														((UnityEvent)0).AddListener(call2);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+50]");
														object obj14 = 0;
														UnityAction call3 = delegate
														{
															//IL_002e: Expected O, but got I
															bool existOnEntity2 = false;
															ref SubscriptionViewComponent data2 = ref GetData(out existOnEntity2);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+18]");
															SubscriptionName = (string)0;
														};
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ X8_v32+E8]");
														((UnityEvent)0).AddListener(call3);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v3 (GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent&)+38]");
														object obj15 = 0;
														UnityAction call4 = delegate
														{
															bool existOnEntity2 = false;
															((BaseGlobalEvent<string>)GetData(out existOnEntity2)).Publish(SubscriptionName);
														};
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ X8_v35+E8]");
														((UnityEvent)0).AddListener(call4);
														return;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0xCBFF0C", Offset = "0xCBFF0C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = objs.Length < 1;\n\tif (v19) goto L_002E;\nL_0014:\n\tv106 = v29 < objs.Length;\n\tv56 = ~v106;\n\tif (v56) goto L_002F;\n\tv29 = v29 + 1;\n\tv79 = v29 < objs.Length;\n\tif (v79) goto L_0014;\nL_002E:\n\treturn;\nL_002F:\n\tv125 = new System.IndexOutOfRangeException();\n\tthrow v125;\n\tthrow System.NullReferenceException;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AssertIsNotNull(object[] objs, string mesg)
		{
			if (objs.Length < 1)
			{
				return;
			}
			int num = 0;
			while (num < objs.Length)
			{
				num++;
				if (num >= objs.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xCBFF5C", Offset = "0xCBFF5C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F05CC8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202372F]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<GBG.Pinata.ECS.InAppPurchase.Components.SubscriptionViewComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SubscriptionViewProvider()
		{
		}
	}
}

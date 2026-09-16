using System;
using AOT;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000088")]
	internal class TizenStoreImpl : JSONStore, ITizenStoreConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x40001F5")]
		private static TizenStoreImpl instance;

		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0xA8")]
		private INativeTizenStore m_Native;

		[Token(Token = "0x6000231")]
		[Address(RVA = "0x15B0D08", Offset = "0x15B0D08", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF14F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, util, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20298BA]) = v38;\nL_0015:\n\tUnityEngine.Purchasing.JSONStore::.ctor(this);\n\tv44.instance = this;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TizenStoreImpl(IUtil util)
		{
			instance = this;
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0x15B0D68", Offset = "0x15B0D68", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EECAC0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, tizen, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298BB]) = v41;\nL_0018:\n\tUnityEngine.Purchasing.JSONStore::SetNativeStore(this, tizen);\n\tthis.m_Native = tizen;\n\tv48 = new UnityEngine.Purchasing.UnityNativePurchasingCallback();\n\tUnityEngine.Purchasing.UnityNativePurchasingCallback::.ctor(v48, 0, Il2CppMethodInfo);\n\tgoto L_005B;\n\tv64 = *([v57 @ X8_v7+B0]);\n\tv65 = 0;\n\tv66 = v64 + 8;\n\tv68 = *([v115 @ X11_v5-8]);\n\tv121 = v68 == v60;\n\tif (v121) goto L_004D;\n\tv101 = v116 + 1;\n\tv178 = v101 < v59;\n\tv95 = ~v178;\n\tv98 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_FFFFFFFF;\n\tv102 = v14;\n\tv103 = 0;\n\tv104 = 0x8909C4(v102, v60, v103, v52, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005B;\nL_004D:\n\tv179 = *([v115 @ X11_v5]);\n\tv180 = v179 << 4;\n\tv181 = v57 + v180;\n\tv182 = v181 + 0x130;\nL_005B:\n\tUnityEngine.Purchasing.INativeTizenStore::SetUnityPurchasingCallback(tizen, v48);\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetNativeStore(INativeTizenStore tizen)
		{
			SetNativeStore((INativeStore)tizen);
			m_Native = tizen;
			UnityNativePurchasingCallback unityPurchasingCallback = MessageCallback;
			tizen.SetUnityPurchasingCallback(unityPurchasingCallback);
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0x15B0E68", Offset = "0x15B0E68", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA7368]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, group, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298BC]) = v41;\nL_0015:\n\tv42 = this.m_Native;\n\tv45 = *([v42 @ X20_v2 (UnityEngine.Purchasing.INativeTizenStore)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeTizenStore>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeTizenStore>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == UnityEngine.Purchasing.INativeTizenStore;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeTizenStore>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, UnityEngine.Purchasing.INativeTizenStore, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (UnityEngine.Purchasing.INativeTizenStore), v42 @ X20_v2 (UnityEngine.Purchasing.INativeTizenStore), group @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetGroupId(string group)
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			INativeTizenStore native = m_Native;
			IntPtr intPtr = (IntPtr)native;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeTizenStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeTizenStore>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeTizenStore))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeTizenStore>)+126]");
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
			goto IL_0134;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0134;
			IL_0134:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x72D860", Offset = "0x72D860")]
		[Token(Token = "0x6000234")]
		[Address(RVA = "0x15B0C80", Offset = "0x15B0C80", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv30 = *([1ED65F8]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, payload, receipt, transactionId, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20298BD]) = v47;\nL_002C:\n\tUnityEngine.Purchasing.TizenStoreImpl::ProcessMessage(v51.instance, subject, payload, receipt, transactionId);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void MessageCallback(string subject, string payload, string receipt, string transactionId)
		{
			instance.ProcessMessage(subject, payload, receipt, transactionId);
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0x15B0F30", Offset = "0x15B0F30", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1ECD428]);\n\tv37 = *([v36 @ X8_v49]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, subject, payload, receipt, transactionId, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20298BE]) = v52;\nL_0020:\n\t// 32 NewArr v57 @ X0_v3 (System.String[]), typeof(System.String[]), 8\n\tv63 = \"[UnityIAP] ProcessMessage subject: \" == 0;\n\tif (v63) goto L_002E;\n\t// 43 IsInst v109 @ X0_v54, typeof(System.String), \"[UnityIAP] ProcessMessage subject: \"\nL_002E:\n\tv230 = v57.Length;\n\tv116 = v57.Length == 0;\n\tif (v116) goto L_015B;\n\tv57[0] = \"[UnityIAP] ProcessMessage subject: \";\n\tv118 = subject == 0;\n\tif (v118) goto L_003C;\n\t// 56 IsInst v354 @ X0_v53, typeof(System.String), subject @ X1 (System.String)\n\tv230 = v57.Length;\nL_003C:\n\tv380 = v230 < 1;\n\tv184 = ~v380;\n\tv176 = v230 - 1;\n\tv160 = v176 == 0;\n\tv381 = ~v184;\n\tv120 = v381 | v160;\n\tif (v120) goto L_015B;\n\tv57[1] = subject;\n\tv386 = \" payload: \" == 0;\n\tif (v386) goto L_0054;\n\t// 80 IsInst v355 @ X0_v51, typeof(System.String), \" payload: \"\n\tv230 = v57.Length;\nL_0054:\n\tv388 = v230 < 2;\n\tv185 = ~v388;\n\tv177 = v230 - 2;\n\tv161 = v177 == 0;\n\tv389 = ~v185;\n\tv121 = v389 | v161;\n\tif (v121) goto L_015B;\n\tv57[2] = \" payload: \";\n\tv390 = payload == 0;\n\tif (v390) goto L_006B;\n\t// 103 IsInst v356 @ X0_v50, typeof(System.String), payload @ X2 (System.String)\n\tv230 = v57.Length;\nL_006B:\n\tv393 = v230 < 3;\n\tv186 = ~v393;\n\tv178 = v230 - 3;\n\tv162 = v178 == 0;\n\tv394 = ~v186;\n\tv122 = v394 | v162;\n\tif (v122) goto L_015B;\n\tv57[3] = payload;\n\tv397 = \" receipt: \" == 0;\n\tif (v397) goto L_0083;\n\t// 127 IsInst v357 @ X0_v48, typeof(System.String), \" receipt: \"\n\tv230 = v57.Length;\nL_0083:\n\tv399 = v230 < 4;\n\tv187 = ~v399;\n\tv179 = v230 - 4;\n\tv163 = v179 == 0;\n\tv400 = ~v187;\n\tv123 = v400 | v163;\n\tif (v123) goto L_015B;\n\tv57[4] = \" receipt: \";\n\tv401 = receipt == 0;\n\tif (v401) goto L_009A;\n\t// 150 IsInst v358 @ X0_v47, typeof(System.String), receipt @ X3 (System.String)\n\tv230 = v57.Length;\nL_009A:\n\tv404 = v230 < 5;\n\tv188 = ~v404;\n\tv180 = v230 - 5;\n\tv164 = v180 == 0;\n\tv405 = ~v188;\n\tv124 = v405 | v164;\n\tif (v124) goto L_015B;\n\tv57[5] = receipt;\n\tv408 = \" transactionId: \" == 0;\n\tif (v408) goto L_00B2;\n\t// 174 IsInst v359 @ X0_v45, typeof(System.String), \" transactionId: \"\n\tv230 = v57.Length;\nL_00B2:\n\tv410 = v230 < 6;\n\tv189 = ~v410;\n\tv181 = v230 - 6;\n\tv165 = v181 == 0;\n\tv411 = ~v189;\n\tv125 = v411 | v165;\n\tif (v125) goto L_015B;\n\tv57[6] = \" transactionId: \";\n\tv412 = transactionId == 0;\n\tif (v412) goto L_00C9;\n\t// 197 IsInst v360 @ X0_v44, typeof(System.String), transactionId @ X4 (System.String)\n\tv230 = v57.Length;\nL_00C9:\n\tv415 = v230 < 7;\n\tv190 = ~v415;\n\tv182 = v230 - 7;\n\tv166 = v182 == 0;\n\tv416 = ~v190;\n\tv126 = v416 | v166;\n\tif (v126) goto L_015B;\n\tv57[7] = transactionId;\n\tv419 = System.String::Concat(v57);\n\tgoto L_00E9;\n\tv427 = *([v423 @ X8_v20+E0]);\n\tv428 = v427 == 0;\n\tv429 = ~v428;\n\tif (v429) goto L_00E9;\n\tv435 = v423;\n\tv431 = \"il2cpp_codegen_runtime_class_init\"(v435, v418, payload, receipt, transactionId, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00E9:\n\tUnityEngine.Debug::Log(v419);\n\tv436 = subject == 0;\n\tif (v436) goto L_015A;\n\tv441 = System.String::op_Equality(subject, \"OnSetupFailed\");\n\tv281 = v441 == 0;\n\tif (v281) goto L_0109;\n\tUnityEngine.Purchasing.JSONStore::OnSetupFailed(this, payload);\n\treturn;\nL_0109:\n\tv451 = System.String::op_Equality(subject, \"OnProductsRetrieved\");\n\tv282 = v451 == 0;\n\tif (v282) goto L_0122;\n\tv318 = this->klass;\n\tv246 = this->klass->vtable[20];\n\tv256 = this->klass->vtable[20];\n\t// 284 IndirectJump v246 @ X3_v2, this @ X0 (UnityEngine.Purchasing.TizenStoreImpl), this @ X0 (UnityEngine.Purchasing.TizenStoreImpl), payload @ X2 (System.String), v256 @ X2_v10, v246 @ X3_v2, transactionId @ X4 (System.String), methodInfo @ X5 (Il2CppMethodInfo), v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\nL_0122:\n\tv458 = System.String::op_Equality(subject, \"OnPurchaseSucceeded\");\n\tv283 = v458 == 0;\n\tif (v283) goto L_013D;\n\tv319 = this->klass;\n\tv244 = this->klass->vtable[21];\n\tv242 = this->klass->vtable[21];\n\t// 311 IndirectJump v244 @ X5_v1, this @ X0 (UnityEngine.Purchasing.TizenStoreImpl), this @ X0 (UnityEngine.Purchasing.TizenStoreImpl), payload @ X2 (System.String), receipt @ X3 (System.String), transactionId @ X4 (System.String), v242 @ X4_v1, v244 @ X5_v1, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\nL_013D:\n\tv444 = System.String::op_Equality(subject, \"OnPurchaseFailed\");\n\tv284 = v444 == 0;\n\tif (v284) goto L_015A;\n\tUnityEngine.Purchasing.JSONStore::OnPurchaseFailed(this, payload);\n\treturn;\nL_015A:\n\treturn;\nL_015B:\n\tv231 = new System.IndexOutOfRangeException();\n\tgoto L_0160;\n\tv377 = new System.ArrayTypeMismatchException();\nL_0160:\n\tthrow v383;\n\tthrow System.NullReferenceException;\n// 216 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ProcessMessage(string subject, string payload, string receipt, string transactionId)
		{
			//IL_0040: Expected O, but got I4
			//IL_0463: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			//IL_04c1: Expected O, but got I
			//IL_00fd: Expected O, but got I4
			//IL_051f: Expected O, but got I
			//IL_014e: Expected O, but got I4
			//IL_057d: Expected O, but got I
			//IL_01a0: Expected O, but got I4
			//IL_05db: Expected O, but got I
			//IL_01f1: Expected O, but got I4
			//IL_0639: Expected O, but got I
			//IL_0243: Expected O, but got I4
			//IL_0697: Expected O, but got I
			//IL_0294: Expected O, but got I4
			//IL_0351: Expected I, but got O
			//IL_0361: Expected O, but got I
			//IL_0371: Expected O, but got I
			//IL_03af: Expected I, but got O
			//IL_03bf: Expected O, but got I
			//IL_03cf: Expected O, but got I
			string[] array = new string[8];
			if ("[UnityIAP] ProcessMessage subject: " != null)
			{
				object obj = "[UnityIAP] ProcessMessage subject: " as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = "[UnityIAP] ProcessMessage subject: ";
				if (subject != null)
				{
					object obj3 = subject as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = subject;
					if (" payload: " != null)
					{
						object obj5 = " payload: " as string;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = " payload: ";
						if (payload != null)
						{
							object obj7 = payload as string;
							obj2 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj2 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = payload;
							if (" receipt: " != null)
							{
								object obj9 = " receipt: " as string;
								obj2 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj2 < 4L;
							bool flag14 = !flag13;
							object obj10 = (long)(IntPtr)obj2 - 4L;
							bool flag15 = obj10 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = " receipt: ";
								if (receipt != null)
								{
									object obj11 = receipt as string;
									obj2 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj2 < 5L;
								bool flag18 = !flag17;
								object obj12 = (long)(IntPtr)obj2 - 5L;
								bool flag19 = obj12 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = receipt;
									if (" transactionId: " != null)
									{
										object obj13 = " transactionId: " as string;
										obj2 = array.Length;
									}
									bool flag21 = (long)(IntPtr)obj2 < 6L;
									bool flag22 = !flag21;
									object obj14 = (long)(IntPtr)obj2 - 6L;
									bool flag23 = obj14 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[6] = " transactionId: ";
										if (transactionId != null)
										{
											object obj15 = transactionId as string;
											obj2 = array.Length;
										}
										bool flag25 = (long)(IntPtr)obj2 < 7L;
										bool flag26 = !flag25;
										object obj16 = (long)(IntPtr)obj2 - 7L;
										bool flag27 = obj16 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											array[7] = transactionId;
											string message = string.Concat(array);
											Debug.Log(message);
											if (subject == null)
											{
												return;
											}
											if (subject == "OnSetupFailed")
											{
												OnSetupFailed(payload);
												return;
											}
											if (subject == "OnProductsRetrieved")
											{
												IntPtr intPtr = (IntPtr)this;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.TizenStoreImpl>)+270]");
												object obj17 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.TizenStoreImpl>)+278]");
												object obj18 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v246 @ X3_v2 (should have been resolved before IL gen)");
											}
											if (subject == "OnPurchaseSucceeded")
											{
												IntPtr intPtr2 = (IntPtr)this;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v30 (Il2CppClass<UnityEngine.Purchasing.TizenStoreImpl>)+280]");
												object obj19 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v30 (Il2CppClass<UnityEngine.Purchasing.TizenStoreImpl>)+288]");
												object obj20 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v244 @ X5_v1 (should have been resolved before IL gen)");
											}
											if (subject == "OnPurchaseFailed")
											{
												OnPurchaseFailed(payload);
											}
											return;
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
	}
}

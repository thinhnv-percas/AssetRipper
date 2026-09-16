using System;
using AOT;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200008A")]
	internal class FacebookStoreImpl : JSONStore
	{
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0xA8")]
		private INativeFacebookStore m_Native;

		[Token(Token = "0x40001F8")]
		private static IUtil util;

		[Token(Token = "0x40001F9")]
		private static FacebookStoreImpl instance;

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xC5EA4C", Offset = "0xC5EA4C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA8D68]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, util, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023322]) = v41;\nL_0016:\n\tUnityEngine.Purchasing.JSONStore::.ctor(this);\n\tv46.util = util;\n\tv48.instance = this;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FacebookStoreImpl(IUtil util)
		{
			FacebookStoreImpl.util = util;
			instance = this;
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0xC5EAC0", Offset = "0xC5EAC0", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAF370]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, facebook, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023323]) = v41;\nL_0015:\n\tthis.store = facebook;\n\tthis.m_Native = facebook;\n\tv44 = facebook->klass;\n\tv48 = *([v44 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]) == 0;\n\tif (v48) goto L_003D;\n\tv104 = *([v44 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+B0]) + 8;\nL_0028:\n\tv109 = *([v104 @ X11_v11-8]) == UnityEngine.Purchasing.INativeFacebookStore;\n\tif (v109) goto L_0040;\n\tv103 = v103 + 1;\n\tv166 = v103 < *([v44 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]);\n\tv82 = ~v166;\n\tv104 = v104 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_0028;\nL_003D:\n\tv187 = 0x8909C4(facebook, UnityEngine.Purchasing.INativeFacebookStore, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0047;\nL_0040:\n\tv168 = *([v104 @ X11_v11]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v44 + v169;\n\tv187 = v170 + 0x130;\nL_0047:\n\t*([v187 @ X0_v4])(v192, facebook, *([v187 @ X0_v4+8]), 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv196 = new UnityEngine.Purchasing.UnityPurchasingCallback();\n\tUnityEngine.Purchasing.UnityPurchasingCallback::.ctor(v196, 0, Il2CppMethodInfo);\n\tv203 = facebook->klass;\n\tv155 = *([v203 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]) == 0;\n\tif (v155) goto L_0075;\n\tv247 = *([v203 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+B0]) + 8;\nL_0060:\n\tv252 = *([v247 @ X11_v6-8]) == UnityEngine.Purchasing.INativeFacebookStore;\n\tif (v252) goto L_0078;\n\tv246 = v246 + 1;\n\tv257 = v246 < *([v203 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]);\n\tv228 = ~v257;\n\tv247 = v247 + 0x10;\n\tv212 = ~v228;\n\tif (v212) goto L_0060;\nL_0075:\n\tv264 = 0x8909C4(facebook, UnityEngine.Purchasing.INativeFacebookStore, 2, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_007C;\nL_0078:\n\tv259 = *([v247 @ X11_v6]) + 2;\n\tv260 = v259 << 4;\n\tv261 = v203 + v260;\n\tv264 = v261 + 0x130;\nL_007C:\n\tv119 = *([v264 @ X0_v9]);\n\tv124 = *([v264 @ X0_v9+8]);\n\t// 134 IndirectJump v119 @ X3_v2, facebook @ X1 (UnityEngine.Purchasing.INativeFacebookStore), facebook @ X1 (UnityEngine.Purchasing.INativeFacebookStore), v196 @ X0_v8 (UnityEngine.Purchasing.UnityPurchasingCallback), v124 @ X2_v4, v119 @ X3_v2, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetNativeStore(INativeFacebookStore facebook)
		{
			//IL_000d: Expected I, but got O
			//IL_022a: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0291: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Expected O, but got Unknown
			//IL_01b0: Expected O, but got I
			//IL_01bf: Expected O, but got I
			//IL_015d: Expected O, but got I
			store = facebook;
			m_Native = facebook;
			IntPtr intPtr = (IntPtr)facebook;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X11_v11-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeFacebookStore))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]");
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
			goto IL_0207;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0207;
			IL_0207:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v187 @ X0_v4] (should have been resolved before IL gen)");
			UnityPurchasingCallback unityPurchasingCallback = MessageCallback;
			IntPtr intPtr2 = (IntPtr)facebook;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0176;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+B0]");
			object obj5 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeFacebookStore))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.INativeFacebookStore>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0176;
			}
			object obj6 = obj5 + 2;
			int num6 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num6;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_0279;
			IL_0279:
			object obj9 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ X0_v9+8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X3_v2 (should have been resolved before IL gen)");
			return;
			IL_0176:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0279;
		}

		[AttributeAttribute(Type = typeof(MonoPInvokeCallbackAttribute), RVA = "0x72D8C4", Offset = "0x72D8C4")]
		[Token(Token = "0x600023A")]
		[Address(RVA = "0xC5E910", Offset = "0xC5E910", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EFB940]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, payload, receipt, transactionId, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023324]) = v47;\nL_001C:\n\tv51 = new UnityEngine.Purchasing.FacebookStoreImpl+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v51);\n\tv51.subject = subject;\n\tv51.payload = payload;\n\tv51.receipt = receipt;\n\tv51.transactionId = transactionId;\n\tv61 = v59.util;\n\tv63 = new System.Action();\n\tSystem.Action::.ctor(v63, v51, Il2CppMethodInfo);\n\tv151 = *([v61 @ X19_v3 (Uniject.IUtil)]);\n\tv135 = *([v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v135) goto L_005C;\n\tv195 = *([v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_0047:\n\tv201 = *([v195 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v201) goto L_005F;\n\tv196 = v196 + 1;\n\tv206 = v196 < *([v151 @ X8_v12 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv177 = ~v206;\n\tv195 = v195 + 0x10;\n\tv161 = ~v177;\n\tif (v161) goto L_0047;\nL_005C:\n\tv213 = 0x8909C4(v61, Uniject.IUtil, 0xF, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0063;\nL_005F:\n\tv208 = *([v195 @ X11_v5]) + 0xF;\n\tv209 = v208 << 4;\n\tv210 = v151 + v209;\n\tv213 = v210 + 0x130;\nL_0063:\n\tv127 = *([v213 @ X0_v9]);\n\tv125 = *([v213 @ X0_v9+8]);\n\t// 111 IndirectJump v127 @ X3_v3, v61 @ X19_v3 (Uniject.IUtil), v61 @ X19_v3 (Uniject.IUtil), v63 @ X0_v8 (System.Action), v125 @ X2_v4, v127 @ X3_v3, methodInfo @ X4 (Il2CppMethodInfo), v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			IUtil util = FacebookStoreImpl.util;
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

		[Token(Token = "0x600023B")]
		[Address(RVA = "0xC5EC24", Offset = "0xC5EC24", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EEEE58]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, subject, payload, receipt, transactionId, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023325]) = v50;\nL_001B:\n\tv51 = subject == 0;\n\tif (v51) goto L_003C;\n\tv57 = System.String::op_Equality(subject, \"OnSetupFailed\");\n\tv67 = v57 == 0;\n\tif (v67) goto L_0042;\n\tUnityEngine.Purchasing.JSONStore::OnSetupFailed(this, payload);\n\treturn;\nL_003C:\n\treturn;\nL_0042:\n\tv154 = System.String::op_Equality(subject, \"OnProductsRetrieved\");\n\tv99 = v154 == 0;\n\tif (v99) goto L_005A;\n\tv133 = this->klass;\n\tv73 = this->klass->vtable[20];\n\tv88 = this->klass->vtable[20];\n\t// 84 IndirectJump v73 @ X3_v2, this @ X0 (UnityEngine.Purchasing.FacebookStoreImpl), this @ X0 (UnityEngine.Purchasing.FacebookStoreImpl), payload @ X2 (System.String), v88 @ X2_v8, v73 @ X3_v2, transactionId @ X4 (System.String), methodInfo @ X5 (Il2CppMethodInfo), v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_005A:\n\tv161 = System.String::op_Equality(subject, \"OnPurchaseSucceeded\");\n\tv100 = v161 == 0;\n\tif (v100) goto L_0074;\n\tv134 = this->klass;\n\tv71 = this->klass->vtable[21];\n\tv69 = this->klass->vtable[21];\n\t// 110 IndirectJump v71 @ X5_v1, this @ X0 (UnityEngine.Purchasing.FacebookStoreImpl), this @ X0 (UnityEngine.Purchasing.FacebookStoreImpl), payload @ X2 (System.String), receipt @ X3 (System.String), transactionId @ X4 (System.String), v69 @ X4_v1, v71 @ X5_v1, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_0074:\n\tv167 = System.String::op_Equality(subject, \"OnPurchaseFailed\");\n\tv101 = v167 == 0;\n\tif (v101) goto L_0096;\n\tv170 = UnityEngine.Purchasing.JSONSerializer::DeserializeFailureReason(payload);\n\tUnityEngine.Purchasing.JSONStore::OnPurchaseFailed(this, v170, payload);\n\treturn;\nL_0096:\n\tv97 = System.String::op_Equality(subject, \"SendPurchasingEvent\");\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ProcessMessage(string subject, string payload, string receipt, string transactionId)
		{
			//IL_0074: Expected I, but got O
			//IL_0084: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_00d2: Expected I, but got O
			//IL_00e2: Expected O, but got I
			//IL_00f2: Expected O, but got I
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X8_v14 (Il2CppClass<UnityEngine.Purchasing.FacebookStoreImpl>)+270]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X8_v14 (Il2CppClass<UnityEngine.Purchasing.FacebookStoreImpl>)+278]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v73 @ X3_v2 (should have been resolved before IL gen)");
			}
			if (subject == "OnPurchaseSucceeded")
			{
				IntPtr intPtr2 = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v13 (Il2CppClass<UnityEngine.Purchasing.FacebookStoreImpl>)+280]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v13 (Il2CppClass<UnityEngine.Purchasing.FacebookStoreImpl>)+288]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v71 @ X5_v1 (should have been resolved before IL gen)");
			}
			if (subject == "OnPurchaseFailed")
			{
				PurchaseFailureDescription failure = JSONSerializer.DeserializeFailureReason(payload);
				OnPurchaseFailed(failure, payload);
			}
			else
			{
				bool flag = subject == "SendPurchasingEvent";
			}
		}
	}
}

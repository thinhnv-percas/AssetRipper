using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200000A")]
	internal class ScriptingUnityCallback : IUnityCallback
	{
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x10")]
		private IUnityCallback forwardTo;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x18")]
		private IUtil util;

		[Token(Token = "0x600002D")]
		[Address(RVA = "0xC6AEC8", Offset = "0xC6AEC8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.forwardTo = forwardTo;\n\tthis.util = util;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ScriptingUnityCallback(IUnityCallback forwardTo, IUtil util)
		{
			this.forwardTo = forwardTo;
			this.util = util;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0xC6E9A8", Offset = "0xC6E9A8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EFA978]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233B9]) = v41;\nL_0018:\n\tv45 = new UnityEngine.Purchasing.ScriptingUnityCallback+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.json = json;\n\tv51 = this.util;\n\tv53 = new System.Action();\n\tSystem.Action::.ctor(v53, v45, Il2CppMethodInfo);\n\tv136 = *([v51 @ X19_v3 (Uniject.IUtil)]);\n\tv124 = *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v124) goto L_0052;\n\tv180 = *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_003D:\n\tv186 = *([v180 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v186) goto L_0055;\n\tv181 = v181 + 1;\n\tv191 = v181 < *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv162 = ~v191;\n\tv180 = v180 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_003D;\nL_0052:\n\tv198 = 0x8909C4(v51, Uniject.IUtil, 0xF, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0059;\nL_0055:\n\tv193 = *([v180 @ X11_v5]) + 0xF;\n\tv194 = v193 << 4;\n\tv195 = v136 + v194;\n\tv198 = v195 + 0x130;\nL_0059:\n\tv118 = *([v198 @ X0_v9]);\n\tv116 = *([v198 @ X0_v9+8]);\n\t// 99 IndirectJump v118 @ X3_v3, v51 @ X19_v3 (Uniject.IUtil), v51 @ X19_v3 (Uniject.IUtil), v53 @ X0_v8 (System.Action), v116 @ X2_v4, v118 @ X3_v3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnSetupFailed(string json)
		{
			//IL_0047: Expected I, but got O
			//IL_0186: Expected O, but got I
			//IL_0082: Expected O, but got I
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_0121: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_00ce: Expected O, but got I
			IUtil util = this.util;
			Action action = delegate
			{
				ScriptingUnityCallback scriptingUnityCallback = this;
				scriptingUnityCallback.forwardTo.OnSetupFailed(json);
			};
			IntPtr intPtr = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e7;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_016e;
			IL_00e7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_016e;
			IL_016e:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X0_v9+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ X3_v3 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0xC6EAC8", Offset = "0xC6EAC8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F00AC0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233BA]) = v41;\nL_0018:\n\tv45 = new UnityEngine.Purchasing.ScriptingUnityCallback+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.json = json;\n\tv51 = this.util;\n\tv53 = new System.Action();\n\tSystem.Action::.ctor(v53, v45, Il2CppMethodInfo);\n\tv136 = *([v51 @ X19_v3 (Uniject.IUtil)]);\n\tv124 = *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v124) goto L_0052;\n\tv180 = *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_003D:\n\tv186 = *([v180 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v186) goto L_0055;\n\tv181 = v181 + 1;\n\tv191 = v181 < *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv162 = ~v191;\n\tv180 = v180 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_003D;\nL_0052:\n\tv198 = 0x8909C4(v51, Uniject.IUtil, 0xF, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0059;\nL_0055:\n\tv193 = *([v180 @ X11_v5]) + 0xF;\n\tv194 = v193 << 4;\n\tv195 = v136 + v194;\n\tv198 = v195 + 0x130;\nL_0059:\n\tv118 = *([v198 @ X0_v9]);\n\tv116 = *([v198 @ X0_v9+8]);\n\t// 99 IndirectJump v118 @ X3_v3, v51 @ X19_v3 (Uniject.IUtil), v51 @ X19_v3 (Uniject.IUtil), v53 @ X0_v8 (System.Action), v116 @ X2_v4, v118 @ X3_v3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnProductsRetrieved(string json)
		{
			//IL_0047: Expected I, but got O
			//IL_0186: Expected O, but got I
			//IL_0082: Expected O, but got I
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_0121: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_00ce: Expected O, but got I
			IUtil util = this.util;
			Action action = delegate
			{
				//IL_001f: Expected I, but got O
				//IL_0168: Expected O, but got I
				//IL_0064: Expected O, but got I
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Expected O, but got Unknown
				//IL_0103: Expected O, but got I
				//IL_0112: Expected O, but got I
				//IL_00b0: Expected O, but got I
				ScriptingUnityCallback scriptingUnityCallback = this;
				IUnityCallback unityCallback = scriptingUnityCallback.forwardTo;
				IntPtr intPtr2 = (IntPtr)unityCallback;
				string text = json;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]");
				object obj7 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IUnityCallback))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj7 = (long)(IntPtr)obj7 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_00c9;
				}
				object obj8 = obj7 + 1;
				int num6 = (int)((long)(IntPtr)obj8 << 4);
				object obj9 = (long)intPtr2 + (long)num6;
				object obj10 = (long)(IntPtr)obj9 + 304L;
				goto IL_0150;
				IL_00c9:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				object obj11 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v98 @ X3_v1 (should have been resolved before IL gen)");
			};
			IntPtr intPtr = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e7;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_016e;
			IL_00e7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_016e;
			IL_016e:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X0_v9+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ X3_v3 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0xC6EBE8", Offset = "0xC6EBE8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EE81B0]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, id, receipt, transactionID, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20233BB]) = v47;\nL_001C:\n\tv51 = new UnityEngine.Purchasing.ScriptingUnityCallback+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v51);\n\tv51.<>4__this = this;\n\tv51.id = id;\n\tv51.receipt = receipt;\n\tv51.transactionID = transactionID;\n\tv57 = this.util;\n\tv59 = new System.Action();\n\tSystem.Action::.ctor(v59, v51, Il2CppMethodInfo);\n\tv146 = *([v57 @ X19_v3 (Uniject.IUtil)]);\n\tv130 = *([v146 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v130) goto L_0058;\n\tv190 = *([v146 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_0043:\n\tv196 = *([v190 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v196) goto L_005B;\n\tv191 = v191 + 1;\n\tv201 = v191 < *([v146 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv172 = ~v201;\n\tv190 = v190 + 0x10;\n\tv156 = ~v172;\n\tif (v156) goto L_0043;\nL_0058:\n\tv208 = 0x8909C4(v57, Uniject.IUtil, 0xF, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_005F;\nL_005B:\n\tv203 = *([v190 @ X11_v5]) + 0xF;\n\tv204 = v203 << 4;\n\tv205 = v146 + v204;\n\tv208 = v205 + 0x130;\nL_005F:\n\tv124 = *([v208 @ X0_v9]);\n\tv122 = *([v208 @ X0_v9+8]);\n\t// 107 IndirectJump v124 @ X3_v3, v57 @ X19_v3 (Uniject.IUtil), v57 @ X19_v3 (Uniject.IUtil), v59 @ X0_v8 (System.Action), v122 @ X2_v4, v124 @ X3_v3, methodInfo @ X4 (Il2CppMethodInfo), v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseSucceeded(string id, string receipt, string transactionID)
		{
			//IL_0061: Expected I, but got O
			//IL_01a0: Expected O, but got I
			//IL_009c: Expected O, but got I
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Expected O, but got Unknown
			//IL_013b: Expected O, but got I
			//IL_014a: Expected O, but got I
			//IL_00e8: Expected O, but got I
			IUtil util = this.util;
			Action action = delegate
			{
				//IL_001f: Expected I, but got O
				//IL_017c: Expected O, but got I
				//IL_0078: Expected O, but got I
				//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fa: Expected O, but got Unknown
				//IL_0117: Expected O, but got I
				//IL_0126: Expected O, but got I
				//IL_00c4: Expected O, but got I
				ScriptingUnityCallback scriptingUnityCallback = this;
				IUnityCallback unityCallback = scriptingUnityCallback.forwardTo;
				IntPtr intPtr2 = (IntPtr)unityCallback;
				string text = id;
				string text2 = receipt;
				string text3 = transactionID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00dd;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]");
				object obj7 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IUnityCallback))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj7 = (long)(IntPtr)obj7 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_00dd;
				}
				object obj8 = obj7 + 2;
				int num6 = (int)((long)(IntPtr)obj8 << 4);
				object obj9 = (long)intPtr2 + (long)num6;
				object obj10 = (long)(IntPtr)obj9 + 304L;
				goto IL_0164;
				IL_00dd:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0164;
				IL_0164:
				object obj11 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X0_v4+8]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v108 @ X5_v1 (should have been resolved before IL gen)");
			};
			IntPtr intPtr = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0101;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0101;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0188;
			IL_0101:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0188;
			IL_0188:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ X0_v9+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v124 @ X3_v3 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0xC6ED1C", Offset = "0xC6ED1C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0A5E8]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233BC]) = v41;\nL_0018:\n\tv45 = new UnityEngine.Purchasing.ScriptingUnityCallback+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.json = json;\n\tv51 = this.util;\n\tv53 = new System.Action();\n\tSystem.Action::.ctor(v53, v45, Il2CppMethodInfo);\n\tv136 = *([v51 @ X19_v3 (Uniject.IUtil)]);\n\tv124 = *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v124) goto L_0052;\n\tv180 = *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_003D:\n\tv186 = *([v180 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v186) goto L_0055;\n\tv181 = v181 + 1;\n\tv191 = v181 < *([v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv162 = ~v191;\n\tv180 = v180 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_003D;\nL_0052:\n\tv198 = 0x8909C4(v51, Uniject.IUtil, 0xF, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0059;\nL_0055:\n\tv193 = *([v180 @ X11_v5]) + 0xF;\n\tv194 = v193 << 4;\n\tv195 = v136 + v194;\n\tv198 = v195 + 0x130;\nL_0059:\n\tv118 = *([v198 @ X0_v9]);\n\tv116 = *([v198 @ X0_v9+8]);\n\t// 99 IndirectJump v118 @ X3_v3, v51 @ X19_v3 (Uniject.IUtil), v51 @ X19_v3 (Uniject.IUtil), v53 @ X0_v8 (System.Action), v116 @ X2_v4, v118 @ X3_v3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(string json)
		{
			//IL_0047: Expected I, but got O
			//IL_0186: Expected O, but got I
			//IL_0082: Expected O, but got I
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_0121: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_00ce: Expected O, but got I
			IUtil util = this.util;
			Action action = delegate
			{
				//IL_001f: Expected I, but got O
				//IL_0168: Expected O, but got I
				//IL_0064: Expected O, but got I
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Expected O, but got Unknown
				//IL_0103: Expected O, but got I
				//IL_0112: Expected O, but got I
				//IL_00b0: Expected O, but got I
				ScriptingUnityCallback scriptingUnityCallback = this;
				IUnityCallback unityCallback = scriptingUnityCallback.forwardTo;
				IntPtr intPtr2 = (IntPtr)unityCallback;
				string text = json;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+B0]");
				object obj7 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IUnityCallback))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.IUnityCallback>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj7 = (long)(IntPtr)obj7 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_00c9;
				}
				object obj8 = obj7 + 3;
				int num6 = (int)((long)(IntPtr)obj8 << 4);
				object obj9 = (long)intPtr2 + (long)num6;
				object obj10 = (long)(IntPtr)obj9 + 304L;
				goto IL_0150;
				IL_00c9:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				object obj11 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v98 @ X3_v1 (should have been resolved before IL gen)");
			};
			IntPtr intPtr = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X8_v10 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e7;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_016e;
			IL_00e7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_016e;
			IL_016e:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X0_v9+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ X3_v3 (should have been resolved before IL gen)");
		}
	}
}

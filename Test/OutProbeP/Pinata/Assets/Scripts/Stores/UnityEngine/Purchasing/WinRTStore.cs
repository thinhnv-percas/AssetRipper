using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Default;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000085")]
	internal class WinRTStore : AbstractStore, IWindowsIAPCallback, IMicrosoftExtensions, IStoreExtension
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000086")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40001F2")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40001F3")]
			public static Func<ProductDefinition, bool> _003C_003E9__8_0;

			[Token(Token = "0x40001F4")]
			public static Func<ProductDefinition, WinProductDescription> _003C_003E9__8_1;

			[Token(Token = "0x600022C")]
			[Address(RVA = "0x15B50AC", Offset = "0x15B50AC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED06C0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20298EC]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.WinRTStore+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600022D")]
			[Address(RVA = "0x15B5110", Offset = "0x15B5110", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CRetrieveProducts_003Eb__8_0(ProductDefinition def)
			{
				int num = (int)(def.type - 2);
				bool flag = num == 0;
				return !flag;
			}

			internal WinProductDescription _003CRetrieveProducts_003Eb__8_1(ProductDefinition def)
			{
				string title = "Fake title - " + def.storeSpecificId;
				string description = "Fake description - " + def.storeSpecificId;
				decimal num = default(decimal);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EA3E34 (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0x340)");
				return new WinProductDescription(def.storeSpecificId, "$0.01", title, description, "USD", default(decimal));
			}
		}

		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x10")]
		private IWindowsIAP win8;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x18")]
		private IStoreCallback callback;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x20")]
		private IUtil util;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x28")]
		private ILogger logger;

		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x30")]
		private bool m_CanReceivePurchases;

		[Token(Token = "0x6000223")]
		[Address(RVA = "0x15B4918", Offset = "0x15B4918", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_CanReceivePurchases = 0;\n\tUnityEngine.Purchasing.Extension.AbstractStore::.ctor(this);\n\tthis.win8 = win8;\n\tthis.util = util;\n\tthis.logger = logger;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WinRTStore(IWindowsIAP win8, IUtil util, ILogger logger)
		{
			m_CanReceivePurchases = false;
			this.win8 = win8;
			this.util = util;
			this.logger = logger;
		}

		[Token(Token = "0x6000224")]
		[Address(RVA = "0x15B495C", Offset = "0x15B495C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.win8 = iap;\n\treturn;\n")]
		public void SetWindowsIAP(IWindowsIAP iap)
		{
			win8 = iap;
		}

		[Token(Token = "0x6000225")]
		[Address(RVA = "0x15B4964", Offset = "0x15B4964", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.callback = biller;\n\treturn;\n")]
		public override void Initialize(IStoreCallback biller)
		{
			callback = biller;
		}

		[Token(Token = "0x6000226")]
		[Address(RVA = "0x15B496C", Offset = "0x15B496C", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB0270]);\n\tv27 = *([v26 @ X8_v41]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, productDefs, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20298E6]) = v45;\nL_001D:\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.WinRTStore+<>c>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, productDefs, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = UnityEngine.Purchasing.WinRTStore+<>c;\nL_0025:\n\tv84 = v59.<>9__8_0;\n\tv61 = v59.<>9__8_0 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_004A;\n\tgoto L_0038;\n\tv92 = *([v55 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.WinRTStore+<>c>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0038;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v55, productDefs, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv124 = UnityEngine.Purchasing.WinRTStore+<>c;\n\tv99 = *([v124 @ X8_v37+B8]);\nL_0038:\n\tv79 = new System.Func`2<UnityEngine.Purchasing.ProductDefinition, System.Boolean>();\n\tSystem.Func`2<UnityEngine.Purchasing.ProductDefinition, System.Boolean>::.ctor(v79, v98.<>9, Il2CppMethodInfo);\n\tv83.<>9__8_0 = v79;\nL_004A:\n\tv91 = System.Linq.Enumerable::Where(productDefs, v84);\n\tgoto L_0059;\n\tv111 = *([v103 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.WinRTStore+<>c>)+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tgoto L_0059;\n\tv126 = v103;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v126, v89, v90, v69, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv119 = UnityEngine.Purchasing.WinRTStore+<>c;\nL_0059:\n\tv149 = v120.<>9__8_1;\n\tv122 = v120.<>9__8_1 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_007F;\n\tgoto L_006D;\n\tv157 = *([v118 @ X8_v10 (Il2CppClass<UnityEngine.Purchasing.WinRTStore+<>c>)+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_006D;\n\tv174 = v118;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v174, v89, v90, v69, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv165 = UnityEngine.Purchasing.WinRTStore+<>c;\n\tv161 = *([v165 @ X8_v28+B8]);\nL_006D:\n\tv144 = new System.Func`2<UnityEngine.Purchasing.ProductDefinition, UnityEngine.Purchasing.Default.WinProductDescription>();\n\tSystem.Func`2<UnityEngine.Purchasing.ProductDefinition, UnityEngine.Purchasing.Default.WinProductDescription>::.ctor(v144, v160.<>9, Il2CppMethodInfo);\n\tv148.<>9__8_1 = v144;\nL_007F:\n\tv156 = System.Linq.Enumerable::Select(v91, v149);\n\tv173 = System.Linq.Enumerable::ToList(v156);\n\tgoto L_00B6;\n\tv189 = *([v182 @ X8_v16+B0]);\n\tv190 = 0;\n\tv191 = v189 + 8;\n\tv193 = *([v240 @ X11_v5-8]);\n\tv246 = v193 == v185;\n\tif (v246) goto L_00AE;\n\tv226 = v241 + 1;\n\tv303 = v226 < v184;\n\tv220 = ~v303;\n\tv223 = v240 + 0x10;\n\tv196 = ~v220;\n\tif (v196) goto L_FFFFFFFF;\n\tv227 = v170;\n\tv228 = 0;\n\tv229 = 0x8909C4(v227, v185, v228, v135, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00B6;\nL_00AE:\n\tv304 = *([v240 @ X11_v5]);\n\tv305 = v304 << 4;\n\tv306 = v182 + v305;\n\tv307 = v306 + 0x130;\nL_00B6:\n\tUnityEngine.Purchasing.Default.IWindowsIAP::BuildDummyProducts(this.win8, v173);\n\tUnityEngine.Purchasing.WinRTStore::init(this, v173);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void RetrieveProducts(ReadOnlyCollection<ProductDefinition> productDefs)
		{
			//IL_00ec: Expected I4, but got O
			Func<ProductDefinition, bool> predicate = _003C_003Ec._003C_003E9__8_0;
			if (_003C_003Ec._003C_003E9__8_0 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__8_0 = delegate(ProductDefinition def)
				{
					int num = (int)(def.type - 2);
					bool flag = num == 0;
					return !flag;
				});
			}
			IEnumerable<ProductDefinition> source = productDefs.Where(predicate);
			Func<ProductDefinition, WinProductDescription> selector = _003C_003Ec._003C_003E9__8_1;
			if (_003C_003Ec._003C_003E9__8_1 == null)
			{
				selector = (_003C_003Ec._003C_003E9__8_1 = delegate(ProductDefinition def)
				{
					string title = "Fake title - " + def.storeSpecificId;
					string description = "Fake description - " + def.storeSpecificId;
					decimal num = default(decimal);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EA3E34 (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0x340)");
					return new WinProductDescription(def.storeSpecificId, "$0.01", title, description, "USD", default(decimal));
				});
			}
			IEnumerable<WinProductDescription> source2 = source.Select(selector);
			List<WinProductDescription> list = source2.ToList();
			win8.BuildDummyProducts(list);
			init((int)list);
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0x15B4CDC", Offset = "0x15B4CDC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBEB80]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, product, transactionId, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298E7]) = v41;\nL_0015:\n\tv42 = this.win8;\n\tv45 = *([v42 @ X20_v2 (UnityEngine.Purchasing.Default.IWindowsIAP)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == UnityEngine.Purchasing.Default.IWindowsIAP;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, UnityEngine.Purchasing.Default.IWindowsIAP, 4, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 4;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (UnityEngine.Purchasing.Default.IWindowsIAP), v42 @ X20_v2 (UnityEngine.Purchasing.Default.IWindowsIAP), transactionId @ X2 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FinishTransaction(ProductDefinition product, string transactionId)
		{
			//IL_000d: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IWindowsIAP windowsIAP = win8;
			IntPtr intPtr = (IntPtr)windowsIAP;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IWindowsIAP))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0139;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0139;
			IL_0139:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000228")]
		[Address(RVA = "0x15B4BA8", Offset = "0x15B4BA8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EDBF00]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, delay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20298E8]) = v40;\nL_0014:\n\tv41 = this.win8;\n\tv44 = *([v41 @ X20_v2 (UnityEngine.Purchasing.Default.IWindowsIAP)]);\n\tv48 = *([v44 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]) == 0;\n\tif (v48) goto L_003B;\n\tv147 = *([v44 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]) + 8;\nL_0026:\n\tv152 = *([v147 @ X11_v12-8]) == UnityEngine.Purchasing.Default.IWindowsIAP;\n\tif (v152) goto L_003E;\n\tv146 = v146 + 1;\n\tv207 = v146 < *([v44 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]);\n\tv128 = ~v207;\n\tv147 = v147 + 0x10;\n\tv112 = ~v128;\n\tif (v112) goto L_0026;\nL_003B:\n\tv214 = 0x8909C4(v41, UnityEngine.Purchasing.Default.IWindowsIAP, 1, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0046;\nL_003E:\n\tv209 = *([v147 @ X11_v12]) + 1;\n\tv210 = v209 << 4;\n\tv211 = v44 + v210;\n\tv214 = v211 + 0x130;\nL_0046:\n\t*([v214 @ X0_v5])(v97, v41, this, *([v214 @ X0_v5+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv101 = this.win8;\n\tv217 = *([v101 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP)]);\n\tv198 = *([v217 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]) == 0;\n\tif (v198) goto L_006C;\n\tv261 = *([v217 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]) + 8;\nL_0057:\n\tv266 = *([v261 @ X11_v7-8]) == UnityEngine.Purchasing.Default.IWindowsIAP;\n\tif (v266) goto L_006F;\n\tv260 = v260 + 1;\n\tv271 = v260 < *([v217 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]);\n\tv242 = ~v271;\n\tv261 = v261 + 0x10;\n\tv226 = ~v242;\n\tif (v226) goto L_0057;\nL_006C:\n\tv278 = 0x8909C4(v101, UnityEngine.Purchasing.Default.IWindowsIAP, 2, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0073;\nL_006F:\n\tv273 = *([v261 @ X11_v7]) + 2;\n\tv274 = v273 << 4;\n\tv275 = v217 + v274;\n\tv278 = v275 + 0x130;\nL_0073:\n\tv160 = *([v278 @ X0_v8]);\n\tv166 = *([v278 @ X0_v8+8]);\n\t// 125 IndirectJump v160 @ X3_v1, v101 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP), v101 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP), 1, v166 @ X2_v5, v160 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void init(int delay)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0108: Expected I, but got O
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_028f: Expected O, but got I
			//IL_0143: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected O, but got Unknown
			//IL_01e7: Expected O, but got I
			//IL_01f6: Expected O, but got I
			//IL_018f: Expected O, but got I
			IWindowsIAP windowsIAP = win8;
			IntPtr intPtr = (IntPtr)windowsIAP;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ X11_v12-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IWindowsIAP))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v4 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
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
			goto IL_0234;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0234;
			IL_0234:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v214 @ X0_v5] (should have been resolved before IL gen)");
			IWindowsIAP windowsIAP2 = win8;
			IntPtr intPtr2 = (IntPtr)windowsIAP2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01a8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]");
			object obj5 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IWindowsIAP))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_01a8;
			}
			object obj6 = obj5 + 2;
			int num6 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num6;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_0277;
			IL_0277:
			object obj9 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X0_v8+8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v160 @ X3_v1 (should have been resolved before IL gen)");
			return;
			IL_01a8:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0277;
		}

		[Token(Token = "0x6000229")]
		[Address(RVA = "0x15B4DA4", Offset = "0x15B4DA4", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EABD60]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, product, developerPayload, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298E9]) = v41;\nL_0017:\n\tv43 = this.win8;\n\tv50 = *([v43 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP)]);\n\tv51 = product.<storeSpecificId>k__BackingField;\n\tv55 = *([v50 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]) == 0;\n\tif (v55) goto L_003F;\n\tv159 = *([v50 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]) + 8;\nL_002A:\n\tv165 = *([v159 @ X11_v5-8]) == UnityEngine.Purchasing.Default.IWindowsIAP;\n\tif (v165) goto L_0042;\n\tv160 = v160 + 1;\n\tv170 = v160 < *([v50 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]);\n\tv87 = ~v170;\n\tv159 = v159 + 0x10;\n\tv63 = ~v87;\n\tif (v63) goto L_002A;\nL_003F:\n\tv177 = 0x8909C4(v43, UnityEngine.Purchasing.Default.IWindowsIAP, 3, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0046;\nL_0042:\n\tv172 = *([v159 @ X11_v5]) + 3;\n\tv173 = v172 << 4;\n\tv174 = v50 + v173;\n\tv177 = v174 + 0x130;\nL_0046:\n\tv100 = *([v177 @ X0_v4]);\n\tv107 = *([v177 @ X0_v4+8]);\n\t// 80 IndirectJump v100 @ X3_v1, v43 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP), v43 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP), v51 @ X20_v2 (System.String), v107 @ X2_v2, v100 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Purchase(ProductDefinition product, string developerPayload)
		{
			//IL_001c: Expected I, but got O
			//IL_015e: Expected O, but got I
			//IL_0064: Expected O, but got I
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_0108: Expected O, but got I
			//IL_0117: Expected O, but got I
			//IL_00b0: Expected O, but got I
			IWindowsIAP windowsIAP = win8;
			IntPtr intPtr = (IntPtr)windowsIAP;
			string storeSpecificId = product.storeSpecificId;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IWindowsIAP))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c9;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0146;
			IL_00c9:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0146;
			IL_0146:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v100 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0x15B4E74", Offset = "0x15B4E74", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EC1B00]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pausing, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298EA]) = v41;\nL_0016:\n\tv43 = pausing == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_004B;\n\tv46 = ~this.m_CanReceivePurchases;\n\tif (v46) goto L_004B;\n\tv54 = this.win8;\n\tv122 = *([v54 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP)]);\n\tv110 = *([v122 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]) == 0;\n\tif (v110) goto L_0043;\n\tv167 = *([v122 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]) + 8;\nL_002E:\n\tv173 = *([v167 @ X11_v5-8]) == UnityEngine.Purchasing.Default.IWindowsIAP;\n\tif (v173) goto L_004D;\n\tv168 = v168 + 1;\n\tv178 = v168 < *([v122 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]);\n\tv149 = ~v178;\n\tv167 = v167 + 0x10;\n\tv133 = ~v149;\n\tif (v133) goto L_002E;\nL_0043:\n\tv185 = 0x8909C4(v54, UnityEngine.Purchasing.Default.IWindowsIAP, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0051;\nL_004B:\n\treturn;\nL_004D:\n\tv180 = *([v167 @ X11_v5]) + 2;\n\tv181 = v180 << 4;\n\tv182 = v122 + v181;\n\tv185 = v182 + 0x130;\nL_0051:\n\tv57 = *([v185 @ X0_v4]);\n\tv67 = *([v185 @ X0_v4+8]);\n\t// 91 IndirectJump v57 @ X3_v1, v54 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP), v54 @ X19_v3 (UnityEngine.Purchasing.Default.IWindowsIAP), 0, v67 @ X2_v2, v57 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void restoreTransactions(bool pausing)
		{
			//IL_0037: Expected I, but got O
			//IL_0195: Expected O, but got I
			//IL_0072: Expected O, but got I
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Expected O, but got Unknown
			//IL_0117: Expected O, but got I
			//IL_0126: Expected O, but got I
			//IL_00be: Expected O, but got I
			if (pausing || !m_CanReceivePurchases)
			{
				return;
			}
			IWindowsIAP windowsIAP = win8;
			IntPtr intPtr = (IntPtr)windowsIAP;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00d7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IWindowsIAP))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00d7;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_017d;
			IL_00d7:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_017d;
			IL_017d:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0x15B4F58", Offset = "0x15B4F58", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFF460]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20298EB]) = v40;\nL_0014:\n\tv41 = this.logger;\n\tv44 = *([v41 @ X20_v2 (UnityEngine.ILogger)]);\n\tv51 = *([v44 @ X8_v4 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v51) goto L_003E;\n\tv149 = *([v44 @ X8_v4 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0029:\n\tv155 = *([v149 @ X11_v12-8]) == UnityEngine.ILogger;\n\tif (v155) goto L_0041;\n\tv150 = v150 + 1;\n\tv208 = v150 < *([v44 @ X8_v4 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv131 = ~v208;\n\tv149 = v149 + 0x10;\n\tv115 = ~v131;\n\tif (v115) goto L_0029;\nL_003E:\n\tv215 = 0x8909C4(v41, UnityEngine.ILogger, 4, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0049;\nL_0041:\n\tv210 = *([v149 @ X11_v12]) + 4;\n\tv211 = v210 << 4;\n\tv212 = v44 + v211;\n\tv215 = v212 + 0x130;\nL_0049:\n\t*([v215 @ X0_v5])(v100, v41, \"Explicit RestoreTransactions()\", *([v215 @ X0_v5+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv106 = this.win8;\n\tv219 = *([v106 @ X20_v4 (UnityEngine.Purchasing.Default.IWindowsIAP)]);\n\tv199 = *([v219 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]) == 0;\n\tif (v199) goto L_0071;\n\tv263 = *([v219 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]) + 8;\nL_005C:\n\tv269 = *([v263 @ X11_v7-8]) == UnityEngine.Purchasing.Default.IWindowsIAP;\n\tif (v269) goto L_0074;\n\tv264 = v264 + 1;\n\tv274 = v264 < *([v219 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]);\n\tv245 = ~v274;\n\tv263 = v263 + 0x10;\n\tv229 = ~v245;\n\tif (v229) goto L_005C;\nL_0071:\n\tv281 = 0x8909C4(v106, UnityEngine.Purchasing.Default.IWindowsIAP, 2, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_007C;\nL_0074:\n\tv276 = *([v263 @ X11_v7]) + 2;\n\tv277 = v276 << 4;\n\tv278 = v219 + v277;\n\tv281 = v278 + 0x130;\nL_007C:\n\t*([v281 @ X0_v8])(v197, v106, 0, *([v281 @ X0_v8+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tthis.m_CanReceivePurchases = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactions()
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0108: Expected I, but got O
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0143: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected O, but got Unknown
			//IL_01e7: Expected O, but got I
			//IL_01f6: Expected O, but got I
			//IL_018f: Expected O, but got I
			ILogger logger = this.logger;
			IntPtr intPtr = (IntPtr)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v4 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v4 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X11_v12-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v4 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0234;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0234;
			IL_0234:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v215 @ X0_v5] (should have been resolved before IL gen)");
			IWindowsIAP windowsIAP = win8;
			IntPtr intPtr2 = (IntPtr)windowsIAP;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01a8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+B0]");
			object obj5 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IWindowsIAP))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.Default.IWindowsIAP>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_01a8;
			}
			object obj6 = obj5 + 2;
			int num6 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num6;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_0277;
			IL_0277:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v281 @ X0_v8] (should have been resolved before IL gen)");
			m_CanReceivePurchases = true;
			return;
			IL_01a8:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0277;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000E1")]
	internal class AndroidConsentDialog : IPlatformConsentDialog
	{
		[Serializable]
		[StructLayout((LayoutKind)0, Size = 16)]
		[Token(Token = "0x20001C6")]
		internal struct ClosedEventParam
		{
			[Token(Token = "0x40006D4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string clickedButtonId;

			[Token(Token = "0x40006D5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public ToggleResult[] toggles;

			[Token(Token = "0x6000D26")]
			[Address(RVA = "0x84B9C4", Offset = "0x84B9C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0xC07A28(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
			public unsafe override string ToString()
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C07A28 (inside EasyMobile.Internal.Privacy.AndroidConsentDialog::<.ctor>b__19_1 +0x8)");
				string result = default(string);
				return result;
			}

			[Token(Token = "0x6000D27")]
			[Address(RVA = "0x84B9CC", Offset = "0x84B9CC", Length = "0x300")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0xC06F14(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n\t// 3 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX20 = X0;\n\tX8 = *([X20+10]);\n\tX19 = X1;\n\t*([X19]) = X8;\n\tX0 = *([X20+18]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = X0;\n\tX0 = *([X20+20]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+10]) = X0;\n\tX0 = *([X20+28]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+18]) = X0;\n\tX0 = *([X20+30]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+20]) = X0;\n\tX0 = *([X20+38]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+28]) = X0;\n\tX0 = *([X20+40]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+30]) = X0;\n\tX0 = *([X20+48]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+38]) = X0;\n\tX0 = *([X20+50]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+40]) = X0;\n\tX0 = *([X20+58]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+48]) = X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 44 ShiftStack 32\n\treturn X0;\n\t// 46 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX20 = X0;\n\tX8 = *([X20]);\n\tX19 = X1;\n\t*([X19+10]) = X8;\n\tX0 = *([X20+8]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+18]) = X0;\n\tX0 = *([X20+10]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+20]) = X0;\n\tX0 = *([X20+18]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+28]) = X0;\n\tX0 = *([X20+20]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+30]) = X0;\n\tX0 = *([X20+28]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+38]) = X0;\n\tX0 = *([X20+30]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+40]) = X0;\n\tX0 = *([X20+38]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+48]) = X0;\n\tX0 = *([X20+40]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+50]) = X0;\n\tX0 = *([X20+48]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+58]) = X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 87 ShiftStack 32\n\treturn X0;\n\t// 89 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+10]);\n\t*([X19+8]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+18]);\n\t*([X19+10]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+20]);\n\t*([X19+18]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+28]);\n\t*([X19+20]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+30]);\n\t*([X19+28]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+38]);\n\t*([X19+30]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+40]);\n\t*([X19+38]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+48]);\n\t*([X19+40]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+48]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 125 ShiftStack 32\n\treturn X0;\n\t// 127 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19+10]);\n\tX20 = X1;\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20]) = X0;\n\tX1 = *([X19+18]);\n\tX0 = 0 | 0x10;\n\tX0 = 0x8D82E8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+8]) = X0;\n\tX8 = *([X19+20]);\n\t*([X20+10]) = X8;\n\tX8 = *([X19+24]);\n\t*([X20+14]) = X8;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 150 ShiftStack 32\n\treturn X0;\n\t// 152 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([202302C]);\n\tX19 = X1;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AD;\n\tX8 = *([1EAF858]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([202302C]) = X8;\nL_00AD:\n\tX0 = *([X20]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+10]) = X0;\n\tX8 = *([1F0FFA0]);\n\tX2 = *([X20+8]);\n\tX0 = 0 | 0x10;\n\tX1 = *([X8]);\n\tX0 = 0x8D82EC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+18]) = X0;\n\tX8 = *([X20+10]);\n\t*([X19+20]) = X8;\n\tX8 = *([X20+14]);\n\t*([X19+24]) = X8;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 192 ShiftStack 48\n\treturn X0;\n\t// 194 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+8]);\n\t*([X19]) = 0;\n\tX0 = 0x8D82F0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 209 ShiftStack 32\n\treturn X0;\n\t// 211 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x78;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 221 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x78;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe Dictionary<string, bool> GetTogglesAsDictionary()
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C06F14 (inside EasyMobile.Internal.Privacy.AndroidConsentDialog::OnNativeDialogCompleted +0x198)");
				Dictionary<string, bool> result = default(Dictionary<string, bool>);
				return result;
			}
		}

		[Serializable]
		[StructLayout((LayoutKind)0, Size = 16)]
		[Token(Token = "0x20001C7")]
		internal struct ToggleResult
		{
			[Token(Token = "0x40006D6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string id;

			[Token(Token = "0x40006D7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public bool state;
		}

		[Token(Token = "0x4000411")]
		private static AndroidConsentDialog sInstance;

		[Token(Token = "0x4000412")]
		internal static string FacadeClassName = "com.sglib.easymobile.androidnative.gdpr.ConsentDialogUnityFacade";

		[Token(Token = "0x4000413")]
		internal static string ShowDialogMethodName = "Show";

		[Token(Token = "0x4000414")]
		internal static string SetButtonInteractableMethodName = "SetButtonInteractable";

		[Token(Token = "0x4000415")]
		internal static string SetToggleIsOnMethodName = "SetToggleIsOn";

		[Token(Token = "0x4000416")]
		internal static string SetToggleInteractableMethodName = "SetToggleInteractable";

		[CompilerGenerated]
		[Token(Token = "0x4000417")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private Action<IPlatformConsentDialog, string, Dictionary<string, bool>> m_mCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000418")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private Action<IPlatformConsentDialog> m_mDismissed;

		[Token(Token = "0x4000419")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private AndroidJavaObject mAndroidJavaObject;

		[Token(Token = "0x400041A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private NativeConsentDialogListener mListener;

		[Token(Token = "0x400041B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private bool mIsShowing;

		[CompilerGenerated]
		[Token(Token = "0x400041C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		private Action<IPlatformConsentDialog, string, bool> m_ToggleStateUpdated;

		[Token(Token = "0x1700023F")]
		internal static AndroidConsentDialog Instance
		{
			[Token(Token = "0x6000830")]
			[Address(RVA = "0xC06708", Offset = "0xC06708", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EBD928]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022FEE]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_0021:\n\tv53 = v51.sInstance == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0038;\n\tv56 = new EasyMobile.Internal.Privacy.AndroidConsentDialog();\n\tEasyMobile.Internal.Privacy.AndroidConsentDialog::.ctor(v56);\n\tgoto L_0033;\n\tv86 = *([v81 @ X0_v10 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0033;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v81, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv90 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_0033:\n\tv62.sInstance = v56;\nL_0038:\n\tgoto L_0046;\n\tv68 = *([v57 @ X0_v4 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_0046;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv72 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_0046:\n\treturn v75.sInstance;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sInstance == null)
				{
					AndroidConsentDialog androidConsentDialog = new AndroidConsentDialog();
					sInstance = androidConsentDialog;
				}
				return sInstance;
			}
		}

		[Token(Token = "0x1400003C")]
		private event Action<IPlatformConsentDialog, string, Dictionary<string, bool>> mCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x6000831")]
			[Address(RVA = "0xC06A6C", Offset = "0xC06A6C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAA178]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FEF]) = v43;\nL_0017:\n\tv45 = this + 0x10;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 16L;
				Delegate obj2 = this.m_mCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, Dictionary<string, bool>>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000832")]
			[Address(RVA = "0xC06B10", Offset = "0xC06B10", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED6B20]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FF0]) = v43;\nL_0017:\n\tv45 = this + 0x10;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 16L;
				Delegate obj2 = this.m_mCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, Dictionary<string, bool>>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400003D")]
		private event Action<IPlatformConsentDialog> mDismissed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000833")]
			[Address(RVA = "0xC06BB4", Offset = "0xC06BB4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F08930]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FF1]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_mDismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000834")]
			[Address(RVA = "0xC06C58", Offset = "0xC06C58", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB3748]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FF2]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_mDismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400003E")]
		public event Action<IPlatformConsentDialog, string, bool> ToggleStateUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x6000839")]
			[Address(RVA = "0xC07114", Offset = "0xC07114", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EED278]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FF7]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_ToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, bool>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600083A")]
			[Address(RVA = "0xC071B8", Offset = "0xC071B8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED1160]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FF8]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_ToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, bool>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400003F")]
		public event Action<IPlatformConsentDialog, string, Dictionary<string, bool>> Completed
		{
			[Token(Token = "0x600083B")]
			[Address(RVA = "0xC0725C", Offset = "0xC0725C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.AndroidConsentDialog::add_mCompleted(this, value);\n\treturn;\n")]
			add
			{
				mCompleted += value;
			}
			[Token(Token = "0x600083C")]
			[Address(RVA = "0xC07260", Offset = "0xC07260", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.AndroidConsentDialog::remove_mCompleted(this, value);\n\treturn;\n")]
			remove
			{
				mCompleted -= value;
			}
		}

		[Token(Token = "0x14000040")]
		public event Action<IPlatformConsentDialog> Dismissed
		{
			[Token(Token = "0x600083D")]
			[Address(RVA = "0xC07264", Offset = "0xC07264", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.AndroidConsentDialog::add_mDismissed(this, value);\n\treturn;\n")]
			add
			{
				mDismissed += value;
			}
			[Token(Token = "0x600083E")]
			[Address(RVA = "0xC07268", Offset = "0xC07268", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Privacy.AndroidConsentDialog::remove_mDismissed(this, value);\n\treturn;\n")]
			remove
			{
				mDismissed -= value;
			}
		}

		[Token(Token = "0x6000835")]
		[Address(RVA = "0xC067C8", Offset = "0xC067C8", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED6E08]);\n\tv23 = *([v22 @ X8_v44]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022FF3]) = v42;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tgoto L_002B;\n\tv51 = *([v47 @ X0_v3 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002B;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v47, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv55 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_002B:\n\tv64 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0034;\n\tv70 = v64;\n\tv71 = 0x8907BC(v70, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv74 = *([v64 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0034:\n\tv75 = *([v64 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv76 = v75 == 0;\n\tif (v76) goto L_0055;\n\tv78 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0041;\n\tv100 = v78;\n\tv101 = 0x8907BC(v100, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0041:\n\tv102 = *([v78 @ X21_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv90 = ~v102;\n\tif (v90) goto L_0055;\n\tgoto L_0055;\n\tv119 = v84;\n\tv120 = 0x8907BC(v119, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0055:\n\tgoto L_005D;\n\tv103 = v95;\n\tv104 = 0x8907BC(v103, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005D:\n\tv111 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v111, v60.FacadeClassName, v107.Value);\n\tthis.mAndroidJavaObject = v111;\n\tthis.mIsShowing = 0;\n\tv124 = EasyMobile.Internal.Privacy.NativeConsentDialogListener::GetListener();\n\tthis.mListener = v124;\n\tv129 = new System.Action`2<System.String, System.Boolean>();\n\tSystem.Action`2<System.String, System.Boolean>::.ctor(v129, this, Il2CppMethodInfo);\n\tEasyMobile.Internal.Privacy.NativeConsentDialogListener::add_ToggleStateUpdated(v124, v129);\n\tv157 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v157, this, Il2CppMethodInfo);\n\tEasyMobile.Internal.Privacy.NativeConsentDialogListener::add_DialogCompleted(this.mListener, v157);\n\tv158 = new System.Action();\n\tSystem.Action::.ctor(v158, this, Il2CppMethodInfo);\n\tEasyMobile.Internal.Privacy.NativeConsentDialogListener::add_DialogDismissed(this.mListener, v158);\n\tv213 = new System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>();\n\tSystem.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>::.ctor(v213, this, Il2CppMethodInfo);\n\tEasyMobile.Internal.Privacy.AndroidConsentDialog::add_mCompleted(this, v213);\n\tv227 = new System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>();\n\tSystem.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>::.ctor(v227, this, Il2CppMethodInfo);\n\tEasyMobile.Internal.Privacy.AndroidConsentDialog::add_mDismissed(this, v227);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AndroidConsentDialog()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X21_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			mAndroidJavaObject = new AndroidJavaObject(FacadeClassName);
			mIsShowing = false;
			(mListener = NativeConsentDialogListener.GetListener()).ToggleStateUpdated += OnNativeToggleStateUpdated;
			Action<string> value = OnNativeDialogCompleted;
			mListener.DialogCompleted += value;
			Action value2 = OnNativeDialogDismissed;
			mListener.DialogDismissed += value2;
			mCompleted += delegate
			{
				mIsShowing = false;
			};
			mDismissed += delegate
			{
				mIsShowing = false;
			};
		}

		[Token(Token = "0x6000836")]
		[Address(RVA = "0xC06CFC", Offset = "0xC06CFC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EFBAF8]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, toggleId, isOn, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022FF4]) = v44;\nL_0018:\n\tv46 = this.ToggleStateUpdated == 0;\n\tif (v46) goto L_0030;\n\tSystem.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>::Invoke(this.ToggleStateUpdated, this, toggleId, isOn);\n\treturn;\nL_0030:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnNativeToggleStateUpdated(string toggleId, bool isOn)
		{
			if (this.ToggleStateUpdated != null)
			{
				this.ToggleStateUpdated(this, toggleId, isOn);
			}
		}

		[Token(Token = "0x6000837")]
		[Address(RVA = "0xC06D7C", Offset = "0xC06D7C", Length = "0x334")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC2678]);\n\tv23 = *([v22 @ X8_v60]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonResult, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FF5]) = v41;\nL_0018:\n\tv45 = this.mCompleted == 0;\n\tif (v45) goto L_0035;\n\tv50 = UnityEngine.JsonUtility::FromJson(jsonResult);\n\tv117 = 0xC06F14(&v50 @ X0_v4 (EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam), Il2CppMethodInfo, v198, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv99 = this.mCompleted == 0;\n\tif (v99) goto L_0037;\n\tSystem.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>::Invoke(this.mCompleted, this, v50, v117);\nL_0035:\n\treturn;\nL_0037:\n\tv192 = new System.NullReferenceException();\n\tgoto L_0044;\n\tgoto L_0044;\nL_0044:\n\tv56 = Il2CppMethodInfo != 1;\n\tif (v56) goto L_0080;\n\tthis = 0x6D2BC0(v192, Il2CppMethodInfo, v198, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv213 = *([this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)]);\n\tv199 = *([v213 @ X19_v9]);\n\tthis = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v213 @ X19_v9]), v198, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv219 = this & 1;\n\tv220 = v219 == 0;\n\tif (v220) goto L_0074;\n\tthis = 0x6D2490(this, v199, v198, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv241 = v213 == 0;\n\tif (v241) goto L_007C;\n\tv270 = *([v213 @ X19_v9]);\n\t*([v270 @ X8_v49+180])(v274, v213, *([v270 @ X8_v49+188]), v198, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv280 = System.String::Concat(\"[AndroidConsentDialog -> OnNativeDialogCompleted]. Error: \", v274);\n\tgoto L_0071;\n\tv320 = *([v108 @ X8_v55+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_0071;\n\tv349 = v108;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v349, v277, v83, v87, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0071:\n\tUnityEngine.Debug::Log(v280);\n\tgoto L_0035;\nL_0074:\n\tthis = 0x6D1E60(8, *([v213 @ X19_v9]), v198, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)]) = *([this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)]);\n\tv199 = 0x1E8A000 + 0x870;\n\tthis = 0x6D2A00(this, v199, 0, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_007C:\n\tv283 = new System.NullReferenceException();\n\tthis = 0x6D2490(v283, v199, 0, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0080:\n\tthis = 0x6D2380(v205, v199, 0, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis = 0x846AA4(this, v199, 0, v117, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0098;\n\tv233 = *([1F0B100]);\n\tv234 = *([v233 @ X8_v43]);\n\tv235 = \"il2cpp_codegen_initialize_method\"(v234, v199, v197, v87, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv238 = 0 | 1;\n\t*([2023000]) = v238;\nL_0098:\n\tv239 = *([this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)+8]);\n\tv240 = *([this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)+8]) == 0;\n\tif (v240) goto L_0112;\n\tv258 = *([v239 @ X19_v7 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.Privacy.AndroidConsentDialog+ToggleResult>)+18]) < 1;\n\tif (v258) goto L_0112;\n\tgoto L_00B6;\n\tv309 = *([v286 @ X0_v16 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c>)+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_00B6;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v286, v199, v197, v87, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv313 = EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c;\nL_00B6:\n\tv300 = v316.<>9__3_0;\n\tv318 = v316.<>9__3_0 == 0;\n\tv319 = ~v318;\n\tif (v319) goto L_00D9;\n\tgoto L_00C9;\n\tv350 = *([v312 @ X0_v17 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c>)+E0]);\n\tv351 = v350 == 0;\n\tv352 = ~v351;\n\tif (v352) goto L_00C9;\n\tv355 = \"il2cpp_codegen_runtime_class_init\"(v312, v199, v197, v87, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv396 = EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c;\n\tv357 = *([v396 @ X8_v39+B8]);\nL_00C9:\n\tv361 = new System.Func`2<EasyMobile.Internal.Privacy.AndroidConsentDialog+ToggleResult, System.String>();\n\tSystem.Func`2<EasyMobile.Internal.Privacy.AndroidConsentDialog+ToggleResult, System.String>::.ctor(v361, v356.<>9, Il2CppMethodInfo);\n\tv343.<>9__3_0 = v361;\nL_00D9:\n\tgoto L_00E1;\n\tv362 = *([v337 @ X0_v18 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c>)+E0]);\n\tv363 = v362 == 0;\n\tv364 = ~v363;\n\tgoto L_00E1;\n\tv376 = \"il2cpp_codegen_runtime_class_init\"(v337, v335, v331, v333, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv366 = EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c;\nL_00E1:\n\tv303 = v369.<>9__3_1;\n\tv371 = v369.<>9__3_1 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_0107;\n\tgoto L_00F4;\n\tv397 = *([v365 @ X0_v19 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c>)+E0]);\n\tv398 = v397 == 0;\n\tv399 = ~v398;\n\tif (v399) goto L_00F4;\n\tv402 = \"il2cpp_codegen_runtime_class_init\"(v365, v335, v331, v333, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv411 = EasyMobile.Internal.Privacy.AndroidConsentDialog+ClosedEventParam+<>c;\n\tv404 = *([v411 @ X8_v30+B8]);\nL_00F4:\n\tv389 = new System.Func`2<EasyMobile.Internal.Privacy.AndroidConsentDialog+ToggleResult, System.Boolean>();\n\tSystem.Func`2<EasyMobile.Internal.Privacy.AndroidConsentDialog+ToggleResult, System.Boolean>::.ctor(v389, v403.<>9, Il2CppMethodInfo);\n\tv392.<>9__3_1 = v389;\nL_0107:\n\tv297 = System.Linq.Enumerable::ToDictionary(*([this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)+8]), v300, v303);\n\tgoto L_0112;\nL_0112:\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnNativeDialogCompleted(string jsonResult)
		{
			//IL_00ab: Expected I, but got O
			//IL_020f: Expected O, but got I
			//IL_030d: Expected O, but got I
			if (this.mCompleted == null)
			{
				return;
			}
			ClosedEventParam arg = JsonUtility.FromJson<ClosedEventParam>(jsonResult);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C06F14 (inside EasyMobile.Internal.Privacy.AndroidConsentDialog::OnNativeDialogCompleted +0x198)");
			if (this.mCompleted != null)
			{
				Dictionary<string, bool> arg2 = default(Dictionary<string, bool>);
				this.mCompleted(this, (string)arg, arg2);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag = (IntPtr)0 != (IntPtr)1;
			IntPtr intPtr = (IntPtr)0;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				if ((uint)((ulong)(long)(IntPtr)this & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					if (this != null)
					{
						object obj = this;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ X8_v49+180] (should have been resolved before IL gen)");
						string text = default(string);
						string message = "[AndroidConsentDialog -> OnNativeDialogCompleted]. Error: " + text;
						Debug.Log(message);
						return;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
					intPtr = (IntPtr)(32022528 + 2160);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				}
				NullReferenceException ex3 = new NullReferenceException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				ex2 = ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)+8]");
			IEnumerable<ToggleResult> enumerable = (IEnumerable<ToggleResult>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)+8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ X19_v7 (System.Collections.Generic.IEnumerable`1<EasyMobile.Internal.Privacy.AndroidConsentDialog+ToggleResult>)+18]");
			if (0L < 1L)
			{
				return;
			}
			Func<ToggleResult, string> keySelector = ClosedEventParam._003C_003Ec._003C_003E9__3_0;
			if (ClosedEventParam._003C_003Ec._003C_003E9__3_0 == null)
			{
				keySelector = (ClosedEventParam._003C_003Ec._003C_003E9__3_0 = (ToggleResult toggle) => (string)toggle);
			}
			Func<ToggleResult, bool> elementSelector = ClosedEventParam._003C_003Ec._003C_003E9__3_1;
			if (ClosedEventParam._003C_003Ec._003C_003E9__3_1 == null)
			{
				elementSelector = (ClosedEventParam._003C_003Ec._003C_003E9__3_1 = delegate
				{
					IntPtr intPtr2 = default(IntPtr);
					int num = (int)((long)intPtr2 & 0xFFL);
					bool flag2 = num == 0;
					return !flag2;
				});
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.Internal.Privacy.AndroidConsentDialog)+8]");
			Dictionary<string, bool> dictionary = ((IEnumerable<ToggleResult>)0).ToDictionary(keySelector, elementSelector);
		}

		[Token(Token = "0x6000838")]
		[Address(RVA = "0xC070B0", Offset = "0xC070B0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA68E0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FF6]) = v38;\nL_0014:\n\tv40 = this.mDismissed == 0;\n\tif (v40) goto L_0026;\n\tSystem.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>::Invoke(this.mDismissed, this);\n\treturn;\nL_0026:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnNativeDialogDismissed()
		{
			if (this.mDismissed != null)
			{
				this.mDismissed(this);
			}
		}

		[Token(Token = "0x600083F")]
		[Address(RVA = "0xC0726C", Offset = "0xC0726C", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EE8378]);\n\tv35 = *([v34 @ X8_v42]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, title, content, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2022FF9]) = v51;\nL_001C:\n\tthis.mIsShowing = 1;\n\tgoto L_0031;\n\tv60 = *([v56 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0031;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v56, title, content, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv64 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_0031:\n\t// 49 NewArr v73 @ X0_v5 (System.Object[]), typeof(System.Object[]), 3\n\tv77 = title == 0;\n\tif (v77) goto L_003D;\n\t// 58 IsInst v83 @ X0_v65, typeof(System.Object), title @ X1 (System.String)\n\tv87 = v83 == 0;\n\tif (v87) goto L_0097;\nL_003D:\n\tv151 = v73.Length;\n\tv90 = v73.Length == 0;\n\tif (v90) goto L_0089;\n\tv73[0] = title;\n\tv96 = content == 0;\n\tif (v96) goto L_004A;\n\t// 70 IsInst v146 @ X0_v63, typeof(System.Object), content @ X2 (System.String)\n\tv150 = v146 == 0;\n\tif (v150) goto L_009B;\n\tv151 = v73.Length;\nL_004A:\n\tv153 = v151 < 1;\n\tv154 = ~v153;\n\tv155 = v151 - 1;\n\tv157 = v155 == 0;\n\tv162 = ~v154;\n\tv163 = v162 | v157;\n\tif (v163) goto L_008D;\n\tv73[1] = content;\n\t// 93 Box v188 @ X0_v57, typeof(System.Boolean), &isDismissible @ X3 (System.Boolean)\n\tv210 = v188 == 0;\n\tif (v210) goto L_0068;\n\t// 100 IsInst v247 @ X0_v61, typeof(System.Object), v188 @ X0_v57\n\tv248 = v247 == 0;\n\tif (v248) goto L_009F;\nL_0068:\n\tv250 = v73.Length < 2;\n\tv229 = ~v250;\n\tv227 = v73.Length - 2;\n\tv223 = v227 == 0;\n\tv251 = ~v229;\n\tv213 = v251 | v223;\n\tif (v213) goto L_0091;\n\tv73[2] = v188;\n\tUnityEngine.AndroidJavaObject::Call(this.mAndroidJavaObject, v68.ShowDialogMethodName, v73);\nL_0086:\n\treturn;\n\tv79 = new System.NullReferenceException();\nL_0089:\n\tv95 = new System.IndexOutOfRangeException();\n\tthrow v95;\nL_008D:\n\tv178 = new System.IndexOutOfRangeException();\n\tthrow v178;\nL_0091:\n\tv240 = new System.IndexOutOfRangeException();\n\tthrow v240;\n\tv135 = new System.NullReferenceException();\nL_0097:\n\tv142 = new System.ArrayTypeMismatchException();\n\tthrow v142;\nL_009B:\n\tv208 = new System.ArrayTypeMismatchException();\n\tthrow v208;\nL_009F:\n\tv271 = new System.ArrayTypeMismatchException();\n\tthrow v271;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_00EF;\n\tv363 = 0x6D2BC0(v277, 0, 0, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv374 = *([v363 @ X0_v14]);\n\tv376 = *([v374 @ X20_v5]);\n\tv378 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v376, 0, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv379 = v378 & 1;\n\tv380 = v379 == 0;\n\tif (v380) goto L_00E3;\n\tv381 = 0x6D2490(v378, v376, 0, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv384 = v374 == 0;\n\tif (v384) goto L_00EB;\n\tv390 = *([v374 @ X20_v5]);\n\tv392 = *([v390 @ X8_v13+180]);\n\tv393 = *([v390 @ X8_v13+188]);\n\tv392(v394, v374, v393, 0, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv400 = System.String::Concat(\"Error when showing consent dialog on Android. Message: \", v394, 0);\n\tgoto L_00DF;\n\tv409 = *([v315 @ X8_v19+E0]);\n\tv410 = v409 == 0;\n\tv411 = ~v410;\n\tif (v411) goto L_00DF;\n\tv414 = v315;\n\tv413 = \"il2cpp_codegen_runtime_class_init\"(v414, v397, v286, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00DF:\n\tUnityEngine.Debug::Log(v400, 0);\n\tthis.mIsShowing = 0;\n\tgoto L_0086;\nL_00E3:\n\tv383 = 0x6D1E60(8, v376, 0, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv385 = *([v363 @ X0_v14]);\n\t*([v383 @ X0_v22]) = v385;\n\tv387 = 0x1E8A000 + 0x870;\n\tv389 = 0x6D2A00(v383, v387, 0, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00EB:\n\tv403 = new System.NullReferenceException();\n\tv367 = 0x6D2490(v403, v365, v364, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00EF:\n\tv372 = 0x6D2380(v360, v346, v334, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv349 = 0x846AA4(v372, v346, v334, isDismissible, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show(string title, string content, bool isDismissible)
		{
			//IL_0056: Expected O, but got I4
			//IL_0275: Expected O, but got I
			//IL_016f: Expected O, but got I4
			//IL_00d8: Expected O, but got I4
			mIsShowing = true;
			object[] array = new object[3];
			if (title != null)
			{
				object obj = title as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = title;
				if (content != null)
				{
					object obj3 = content as object;
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = content;
					object obj5 = isDismissible;
					if (obj5 != null)
					{
						object obj6 = obj5 as object;
						if (obj6 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
					}
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = obj5;
						mAndroidJavaObject.Call(ShowDialogMethodName, array);
						return;
					}
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
				throw ex5;
			}
			IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
			throw ex6;
		}

		[Token(Token = "0x6000840")]
		[Address(RVA = "0xC07534", Offset = "0xC07534", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1EF9320]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, id, interactable, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022FFA]) = v46;\nL_001F:\n\tgoto L_002C;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v50, id, interactable, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv58 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_002C:\n\t// 44 NewArr v67 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv71 = id == 0;\n\tif (v71) goto L_0039;\n\t// 53 IsInst v118 @ X0_v25, typeof(System.Object), id @ X1 (System.String)\nL_0039:\n\tv125 = v67.Length == 0;\n\tif (v125) goto L_006A;\n\tv67[0] = id;\n\t// 66 Box v164 @ X0_v19, typeof(System.Boolean), &interactable @ X2 (System.Boolean)\n\tv193 = v164 == 0;\n\tif (v193) goto L_004D;\n\t// 73 IsInst v186 @ X0_v23, typeof(System.Object), v164 @ X0_v19\nL_004D:\n\tv232 = v67.Length < 1;\n\tv144 = ~v232;\n\tv142 = v67.Length - 1;\n\tv138 = v142 == 0;\n\tv233 = ~v144;\n\tv128 = v233 | v138;\n\tif (v128) goto L_006A;\n\tv67[1] = v164;\n\tUnityEngine.AndroidJavaObject::Call(this.mAndroidJavaObject, v62.SetButtonInteractableMethodName, v67);\n\treturn;\nL_006A:\n\tv181 = new System.IndexOutOfRangeException();\n\tgoto L_006F;\n\tv192 = new System.ArrayTypeMismatchException();\nL_006F:\n\tthrow v229;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetButtonInteractable(string id, bool interactable)
		{
			//IL_00cd: Expected O, but got I4
			object[] array = new object[2];
			if (id != null)
			{
				object obj = id as object;
			}
			if (array.Length != 0)
			{
				array[0] = id;
				object obj2 = interactable;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj4 = array.Length - 1;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj2;
					mAndroidJavaObject.Call(SetButtonInteractableMethodName, array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000841")]
		[Address(RVA = "0xC07680", Offset = "0xC07680", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1F06AD0]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, toggleId, interactable, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022FFB]) = v46;\nL_001F:\n\tgoto L_002C;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v50, toggleId, interactable, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv58 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_002C:\n\t// 44 NewArr v67 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv71 = toggleId == 0;\n\tif (v71) goto L_0039;\n\t// 53 IsInst v118 @ X0_v25, typeof(System.Object), toggleId @ X1 (System.String)\nL_0039:\n\tv125 = v67.Length == 0;\n\tif (v125) goto L_006A;\n\tv67[0] = toggleId;\n\t// 66 Box v164 @ X0_v19, typeof(System.Boolean), &interactable @ X2 (System.Boolean)\n\tv193 = v164 == 0;\n\tif (v193) goto L_004D;\n\t// 73 IsInst v186 @ X0_v23, typeof(System.Object), v164 @ X0_v19\nL_004D:\n\tv232 = v67.Length < 1;\n\tv144 = ~v232;\n\tv142 = v67.Length - 1;\n\tv138 = v142 == 0;\n\tv233 = ~v144;\n\tv128 = v233 | v138;\n\tif (v128) goto L_006A;\n\tv67[1] = v164;\n\tUnityEngine.AndroidJavaObject::Call(this.mAndroidJavaObject, v62.SetToggleInteractableMethodName, v67);\n\treturn;\nL_006A:\n\tv181 = new System.IndexOutOfRangeException();\n\tgoto L_006F;\n\tv192 = new System.ArrayTypeMismatchException();\nL_006F:\n\tthrow v229;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToggleInteractable(string toggleId, bool interactable)
		{
			//IL_00cd: Expected O, but got I4
			object[] array = new object[2];
			if (toggleId != null)
			{
				object obj = toggleId as object;
			}
			if (array.Length != 0)
			{
				array[0] = toggleId;
				object obj2 = interactable;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj4 = array.Length - 1;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj2;
					mAndroidJavaObject.Call(SetToggleInteractableMethodName, array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000842")]
		[Address(RVA = "0xC077CC", Offset = "0xC077CC", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = *([1F06388]);\n\tv33 = *([v32 @ X8_v25]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, toggleId, isOn, animated, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2022FFC]) = v49;\nL_0021:\n\tgoto L_002E;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Privacy.AndroidConsentDialog>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002E;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v53, toggleId, isOn, animated, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv61 = EasyMobile.Internal.Privacy.AndroidConsentDialog;\nL_002E:\n\t// 46 NewArr v70 @ X0_v5 (System.Object[]), typeof(System.Object[]), 3\n\tv74 = toggleId == 0;\n\tif (v74) goto L_003B;\n\t// 55 IsInst v128 @ X0_v30, typeof(System.Object), toggleId @ X1 (System.String)\nL_003B:\n\tv135 = v70.Length == 0;\n\tif (v135) goto L_0089;\n\tv70[0] = toggleId;\n\t// 68 Box v179 @ X0_v19, typeof(System.Boolean), &isOn @ X2 (System.Boolean)\n\tv240 = v179 == 0;\n\tif (v240) goto L_004F;\n\t// 75 IsInst v228 @ X0_v28, typeof(System.Object), v179 @ X0_v19\nL_004F:\n\tv282 = v70.Length < 1;\n\tv198 = ~v282;\n\tv196 = v70.Length - 1;\n\tv192 = v196 == 0;\n\tv283 = ~v198;\n\tv182 = v283 | v192;\n\tif (v182) goto L_0089;\n\tv70[1] = v179;\n\t// 96 Box v287 @ X0_v22, typeof(System.Boolean), &animated @ X3 (System.Boolean)\n\tv288 = v287 == 0;\n\tif (v288) goto L_006B;\n\t// 103 IsInst v229 @ X0_v26, typeof(System.Object), v287 @ X0_v22\nL_006B:\n\tv291 = v70.Length < 2;\n\tv156 = ~v291;\n\tv154 = v70.Length - 2;\n\tv150 = v154 == 0;\n\tv292 = ~v156;\n\tv140 = v292 | v150;\n\tif (v140) goto L_0089;\n\tv70[2] = v287;\n\tUnityEngine.AndroidJavaObject::Call(this.mAndroidJavaObject, v65.SetToggleIsOnMethodName, v70);\n\treturn;\nL_0089:\n\tv212 = new System.IndexOutOfRangeException();\n\tgoto L_008E;\n\tv239 = new System.ArrayTypeMismatchException();\nL_008E:\n\tthrow v279;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToggleIsOn(string toggleId, bool isOn, bool animated)
		{
			//IL_00cd: Expected O, but got I4
			//IL_017c: Expected O, but got I4
			object[] array = new object[3];
			if (toggleId != null)
			{
				object obj = toggleId as object;
			}
			if (array.Length != 0)
			{
				array[0] = toggleId;
				object obj2 = isOn;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj4 = array.Length - 1;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj2;
					object obj5 = animated;
					if (obj5 != null)
					{
						object obj6 = obj5 as object;
					}
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj7 = array.Length - 2;
					bool flag7 = obj7 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = obj5;
						mAndroidJavaObject.Call(SetToggleIsOnMethodName, array);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000843")]
		[Address(RVA = "0xC07964", Offset = "0xC07964", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsShowing;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsShowing()
		{
			return mIsShowing;
		}
	}
}

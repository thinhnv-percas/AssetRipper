using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Notifications.Android
{
	[Serializable]
	[Token(Token = "0x20000ED")]
	internal class AndroidNotificationCategory
	{
		[Serializable]
		[Token(Token = "0x20001CC")]
		internal class AndroidActionButton
		{
			[Token(Token = "0x40006E5")]
			[FieldOffset(Offset = "0x10")]
			public string id;

			[Token(Token = "0x40006E6")]
			[FieldOffset(Offset = "0x18")]
			public string title;

			[Token(Token = "0x40006E7")]
			[FieldOffset(Offset = "0x20")]
			public string icon;

			[Token(Token = "0x6000D36")]
			[Address(RVA = "0xC031F0", Offset = "0xC031F0", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA8210]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FBC]) = v38;\nL_001A:\n\tthis.icon = v44.Empty;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AndroidActionButton()
			{
				icon = string.Empty;
			}
		}

		[Token(Token = "0x400042D")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x400042E")]
		[FieldOffset(Offset = "0x18")]
		public string groupId;

		[Token(Token = "0x400042F")]
		[FieldOffset(Offset = "0x20")]
		public string name;

		[Token(Token = "0x4000430")]
		[FieldOffset(Offset = "0x28")]
		public string description;

		[Token(Token = "0x4000431")]
		[FieldOffset(Offset = "0x30")]
		public int importance;

		[Token(Token = "0x4000432")]
		[FieldOffset(Offset = "0x34")]
		public bool enableBadge;

		[Token(Token = "0x4000433")]
		[FieldOffset(Offset = "0x38")]
		public int lights;

		[Token(Token = "0x4000434")]
		[FieldOffset(Offset = "0x3C")]
		public int lightColor;

		[Token(Token = "0x4000435")]
		[FieldOffset(Offset = "0x40")]
		public int vibration;

		[Token(Token = "0x4000436")]
		[FieldOffset(Offset = "0x48")]
		public int[] vibrationPattern;

		[Token(Token = "0x4000437")]
		[FieldOffset(Offset = "0x50")]
		public int lockScreenVisibility;

		[Token(Token = "0x4000438")]
		[FieldOffset(Offset = "0x54")]
		public int sound;

		[Token(Token = "0x4000439")]
		[FieldOffset(Offset = "0x58")]
		public string soundName;

		[Token(Token = "0x400043A")]
		[FieldOffset(Offset = "0x60")]
		public AndroidActionButton[] actionButtons;

		[Token(Token = "0x60008A4")]
		[Address(RVA = "0xC02FB0", Offset = "0xC02FB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.JsonUtility::ToJson(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal string ToJson()
		{
			return JsonUtility.ToJson(this);
		}

		[Token(Token = "0x60008A5")]
		[Address(RVA = "0xC02FB8", Offset = "0xC02FB8", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ED8D00]);\n\tv29 = *([v28 @ X8_v7]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022FBB]) = v48;\nL_0018:\n\tv49 = v46 == 0;\n\tif (v49) goto L_00C5;\n\treturnVal1 = 0xC097F0(v46, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal1;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tSystem.Object::.ctor(X0, X1);\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X19+10]);\n\tX0 = 0;\n\t*([X20+10]) = X8;\n\tX8 = *([X19+18]);\n\t*([X20+18]) = X8;\n\tX8 = *([X19+20]);\n\t*([X20+20]) = X8;\n\tX8 = *([X19+28]);\n\t*([X20+28]) = X8;\n\tX8 = *([X19+30]);\n\t*([X20+30]) = X8;\n\tX8 = *([X19+34]);\n\t*([X20+34]) = X8;\n\tX8 = *([X19+38]);\n\t*([X20+38]) = X8;\n\tV0 = *([X19+3C]);\n\tV1 = *([X19+40]);\n\tV2 = *([X19+44]);\n\tV3 = *([X19+48]);\n\t// 55 MakeStruct AGGC03060_0, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tX0 = UnityEngine.Color32::op_Implicit(AGGC03060_0, X0);\n\tX8 = X0 & 0xFF00FF00;\n\tTEMP = X0 & 0xFF;\n\tTEMP = TEMP << 0x10;\n\tX8 = X8 & 0xFFFFFFFFFF00FFFF;\n\tX8 = X8 | TEMP;\n\tTEMP = X0 >> 0x10;\n\tTEMP = TEMP & 0xFF;\n\tX8 = X8 & 0xFFFFFFFFFFFFFF00;\n\tX8 = X8 | TEMP;\n\t*([X20+3C]) = X8;\n\tX8 = *([X19+4C]);\n\t*([X20+40]) = X8;\n\tX8 = *([X19+50]);\n\t*([X20+48]) = X8;\n\tX8 = *([X19+58]);\n\t*([X20+50]) = X8;\n\tX8 = *([X19+5C]);\n\t*([X20+54]) = X8;\n\tX8 = *([1EBA198]);\n\tX21 = *([X19+60]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0058;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0058;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0058:\n\tX0 = X21;\n\tX1 = 0;\n\tX0 = System.IO.Path::GetFileNameWithoutExtension(X0, X1);\n\t*([X20+58]) = X0;\n\tX8 = *([1EB0980]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EAD080]);\n\tX21 = X0;\n\tX1 = *([X8]);\n\tSystem.Collections.Generic.List`1::.ctor /* +161 sharing this address */(X0, X1);\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_00B0;\n\tX24 = *([1F04220]);\n\tX25 = *([1EC05C8]);\n\tX23 = 0;\nL_006D:\n\tX8 = *([X8+18]);\n\tC = X23 < X8;\n\tC = ~C;\n\tTEMP1 = X23 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X8;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_00B0;\n\tX0 = *([X24]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tEasyMobile.Internal.Notifications.Android.AndroidNotificationCategory+AndroidActionButton::.ctor(X0, X1);\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_00C6;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_00C8;\n\tif (TEMP) goto L_00C6;\n\tX9 = X23;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\t*([X22+10]) = X8;\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_00C6;\n\tX10 = *([X8+18]);\n\tC = X23 < X10;\n\tC = ~C;\n\tTEMP1 = X23 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X10;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_00C8;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+28]);\n\t*([X22+18]) = X8;\n\tif (TEMP) goto L_00C6;\n\tX2 = *([X25]);\n\tX0 = X21;\n\tX1 = X22;\n\tX23 = X23 + 1;\n\tSystem.Collections.Generic.List`1::Add /* +161 sharing this address */(X0, X1, X2);\n\tX8 = *([X19+68]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006D;\n\tgoto L_00C6;\nL_00B0:\n\tTEMP = X21 == 0;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([1F05270]);\n\tX0 = X21;\n\tX1 = *([X8]);\n\tX0 = System.Collections.Generic.List`1::ToArray /* +30 sharing this address */(X0, X1);\n\t*([X20+60]) = X0;\n\tgoto L_00C5;\nL_00C5:\n\treturn 0;\nL_00C6:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C8:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidNotificationCategory FromCrossPlatformCategory(NotificationCategory category)
		{
			NotificationCategory notificationCategory = default(NotificationCategory);
			if (notificationCategory != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C097F0 (inside EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent::IsButton +0x78)");
				AndroidNotificationCategory result = default(AndroidNotificationCategory);
				return result;
			}
			return null;
		}

		[Token(Token = "0x60008A6")]
		[Address(RVA = "0xC031E8", Offset = "0xC031E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidNotificationCategory()
		{
		}
	}
}

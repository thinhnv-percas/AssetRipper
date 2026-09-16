using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200000C")]
	public class EM_Settings : ScriptableObject
	{
		[Token(Token = "0x4000067")]
		private static EM_Settings sInstance;

		[SerializeField]
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x18")]
		private AdSettings mAdvertisingSettings;

		[SerializeField]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x20")]
		private GameServicesSettings mGameServiceSettings;

		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x28")]
		private IAPSettings mInAppPurchaseSettings;

		[SerializeField]
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x30")]
		private NotificationsSettings mNotificationSettings;

		[SerializeField]
		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x38")]
		private PrivacySettings mPrivacySettings;

		[SerializeField]
		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x40")]
		private RatingRequestSettings mRatingRequestSettings;

		[SerializeField]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x48")]
		private SharingSettings mSharingSettings;

		[SerializeField]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x50")]
		private NativeApisSettings mNativeApisSettings;

		[SerializeField]
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x58")]
		private bool mIsAdModuleEnable;

		[SerializeField]
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x59")]
		private bool mIsIAPModuleEnable;

		[SerializeField]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x5A")]
		private bool mIsGameServiceModuleEnable;

		[SerializeField]
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x5B")]
		private bool mIsNotificationModuleEnable;

		[SerializeField]
		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x5C")]
		private bool mIsSharingModuleEnable;

		[Token(Token = "0x17000007")]
		public static EM_Settings Instance
		{
			[Token(Token = "0x6000052")]
			[Address(RVA = "0xA55EFC", Offset = "0xA55EFC", Length = "0x130")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1ECC260]);\n\tv19 = *([v18 @ X8_v28]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2021FAE]) = v39;\nL_001E:\n\tgoto L_0027;\n\tv51 = *([v46 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v46, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv61 = UnityEngine.Object::op_Equality(v45.sInstance, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_0064;\n\tv64 = EasyMobile.EM_Settings::LoadSettingsAsset();\n\tv92.sInstance = v64;\n\tgoto L_003F;\n\tv98 = *([v94 @ X0_v9+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_003F;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, v59, v60, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003F:\n\tv74 = UnityEngine.Object::op_Equality(v95.sInstance, 0);\n\tv77 = v74 == 0;\n\tif (v77) goto L_0064;\n\tgoto L_0053;\n\tv112 = *([v108 @ X0_v13+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_0053;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v108, v71, v68, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0053:\n\tUnityEngine.Debug::LogError(\"Easy Mobile settings not found! Please go to menu Windows > Easy Mobile > Settings to setup the plugin.\");\n\tv73 = UnityEngine.ScriptableObject::CreateInstance();\n\tv79.sInstance = v73;\nL_0064:\n\treturn v88.sInstance;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sInstance == null)
				{
					EM_Settings eM_Settings = LoadSettingsAsset();
					sInstance = eM_Settings;
					if (sInstance == null)
					{
						Debug.LogError("Easy Mobile settings not found! Please go to menu Windows > Easy Mobile > Settings to setup the plugin.");
						EM_Settings eM_Settings2 = ScriptableObject.CreateInstance<EM_Settings>();
						sInstance = eM_Settings2;
					}
				}
				return sInstance;
			}
		}

		[Token(Token = "0x17000008")]
		public static AdSettings Advertising
		{
			[Token(Token = "0x6000054")]
			[Address(RVA = "0xA47F4C", Offset = "0xA47F4C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mAdvertisingSettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mAdvertisingSettings;
			}
		}

		[Token(Token = "0x17000009")]
		public static GameServicesSettings GameServices
		{
			[Token(Token = "0x6000055")]
			[Address(RVA = "0xA560BC", Offset = "0xA560BC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mGameServiceSettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mGameServiceSettings;
			}
		}

		[Token(Token = "0x1700000A")]
		public static IAPSettings InAppPurchasing
		{
			[Token(Token = "0x6000056")]
			[Address(RVA = "0xA560DC", Offset = "0xA560DC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mInAppPurchaseSettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mInAppPurchaseSettings;
			}
		}

		[Token(Token = "0x1700000B")]
		public static PrivacySettings Privacy
		{
			[Token(Token = "0x6000057")]
			[Address(RVA = "0xA560FC", Offset = "0xA560FC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mPrivacySettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mPrivacySettings;
			}
		}

		[Token(Token = "0x1700000C")]
		public static NotificationsSettings Notifications
		{
			[Token(Token = "0x6000058")]
			[Address(RVA = "0xA5611C", Offset = "0xA5611C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mNotificationSettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mNotificationSettings;
			}
		}

		[Token(Token = "0x1700000D")]
		public static SharingSettings Sharing
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0xA5613C", Offset = "0xA5613C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mSharingSettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mSharingSettings;
			}
		}

		[Token(Token = "0x1700000E")]
		public static NativeApisSettings NativeApis
		{
			[Token(Token = "0x600005A")]
			[Address(RVA = "0xA5615C", Offset = "0xA5615C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mNativeApisSettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mNativeApisSettings;
			}
		}

		[Token(Token = "0x1700000F")]
		public static RatingRequestSettings RatingRequest
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0xA5617C", Offset = "0xA5617C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mRatingRequestSettings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mRatingRequestSettings;
			}
		}

		[Token(Token = "0x17000010")]
		public static bool IsAdModuleEnable
		{
			[Token(Token = "0x600005C")]
			[Address(RVA = "0xA5619C", Offset = "0xA5619C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mIsAdModuleEnable;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mIsAdModuleEnable;
			}
		}

		[Token(Token = "0x17000011")]
		public static bool IsIAPModuleEnable
		{
			[Token(Token = "0x600005D")]
			[Address(RVA = "0xA561BC", Offset = "0xA561BC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mIsIAPModuleEnable;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mIsIAPModuleEnable;
			}
		}

		[Token(Token = "0x17000012")]
		public static bool IsGameServicesModuleEnable
		{
			[Token(Token = "0x600005E")]
			[Address(RVA = "0xA561DC", Offset = "0xA561DC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mIsGameServiceModuleEnable;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mIsGameServiceModuleEnable;
			}
		}

		[Token(Token = "0x17000013")]
		public static bool IsNotificationsModuleEnable
		{
			[Token(Token = "0x600005F")]
			[Address(RVA = "0xA561FC", Offset = "0xA561FC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.EM_Settings::get_Instance();\n\treturn v6.mIsNotificationModuleEnable;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				EM_Settings instance = Instance;
				return instance.mIsNotificationModuleEnable;
			}
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0xA5602C", Offset = "0xA5602C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EA87D0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FAF]) = v35;\nL_0015:\n\tv40 = UnityEngine.Resources::Load(\"EM_Settings\");\n\tv41 = v40 == 0;\n\tif (v41) goto L_0041;\n\tgoto L_FFFFFFFF;\n\tgoto L_0041;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static EM_Settings LoadSettingsAsset()
		{
			Object obj = Resources.Load("EM_Settings");
			bool flag = (object)obj == null;
			EM_Settings result = (EM_Settings)obj;
			if (!flag)
			{
				EM_Settings eM_Settings = obj as EM_Settings;
				result = (EM_Settings)(((object)eM_Settings == null) ? null : obj);
			}
			return result;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0xA5621C", Offset = "0xA5621C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = mod != 4;\n\tif (v10) goto L_000F;\n\treturn 1;\nL_000F:\n\tv14 = mod - 8;\n\tv16 = v14 == 0;\n\treturn v16;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsCompositeModule(Module mod)
		{
			if (mod == Module.NativeApis)
			{
				return true;
			}
			int num = (int)(mod - 8);
			return num == 0;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0xA56238", Offset = "0xA56238", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = mod < 8;\n\tv8 = ~v6;\n\tv9 = mod - 8;\n\tv11 = v9 == 0;\n\tv16 = ~v11;\n\tv17 = v8 & v16;\n\tif (v17) goto L_0019;\n\tv20 = 0x1818000 + 0x928;\n\tv22 = *([v20 @ X9_v2 (System.Int32)+mod @ X0 (EasyMobile.Module)*4]) + v20;\n\t// 21 IndirectJump v22 @ X8_v3, mod @ X0 (EasyMobile.Module), mod @ X0 (EasyMobile.Module), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = 0 | 1;\n\tgoto L_0040;\nL_0019:\n\tgoto L_0040;\n\tX0 = EasyMobile.EM_Settings::get_Instance(X0);\n\tif (TEMP) goto L_0041;\n\tX8 = *([X0+58]);\n\tgoto L_0032;\n\tX0 = EasyMobile.EM_Settings::get_Instance(X0);\n\tif (TEMP) goto L_0041;\n\tX8 = *([X0+5A]);\n\tgoto L_0032;\n\tX0 = EasyMobile.EM_Settings::get_Instance(X0);\n\tif (TEMP) goto L_0041;\n\tX8 = *([X0+59]);\n\tgoto L_0032;\n\tX0 = EasyMobile.EM_Settings::get_Instance(X0);\n\tif (TEMP) goto L_0041;\n\tX8 = *([X0+5B]);\n\tgoto L_0032;\n\tX0 = EasyMobile.EM_Settings::get_Instance(X0);\n\tif (TEMP) goto L_0041;\n\tX8 = *([X0+5C]);\nL_0032:\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX0 = TEMPCOND;\nL_0040:\n\treturn 0;\nL_0041:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsModuleEnable(Module mod)
		{
			//IL_0081: Expected O, but got I
			bool flag = mod < Module.Utilities;
			bool flag2 = !flag;
			int num = (int)(mod - 8);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 2344;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X9_v2 (System.Int32)+mod @ X0 (EasyMobile.Module)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X8_v3 (should have been resolved before IL gen)");
			}
			return false;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0xA562D0", Offset = "0xA562D0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = submod == 0;\n\tif (v6) goto L_0020;\n\tv12 = submod == 2;\n\tif (v12) goto L_FFFFFFFF;\n\tv27 = submod != 1;\n\tif (v27) goto L_FFFFFFFF;\n\tv30 = EasyMobile.EM_Settings::get_NativeApis();\n\tv34 = v30.mIsContactsEnabled;\n\tgoto L_0028;\nL_0020:\n\tv17 = EasyMobile.EM_Settings::get_NativeApis();\n\tv34 = v17.mIsMediaEnabled;\nL_0028:\n\tv49 = v34 == 0;\n\tv39 = ~v49;\n\tgoto L_0036;\n\tgoto L_0036;\nL_0036:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsSubmoduleEnable(Submodule submod)
		{
			bool flag;
			switch (submod)
			{
			case Submodule.Contacts:
			{
				NativeApisSettings nativeApis2 = NativeApis;
				flag = nativeApis2.IsContactsEnabled;
				break;
			}
			case Submodule.Media:
			{
				NativeApisSettings nativeApis = NativeApis;
				flag = nativeApis.IsMediaEnabled;
				break;
			}
			case Submodule.RatingRequest:
				return true;
			default:
				return false;
			}
			bool flag2 = !flag;
			return !flag2;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0xA5632C", Offset = "0xA5632C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EM_Settings()
		{
		}
	}
}

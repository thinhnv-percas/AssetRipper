using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using EasyMobile.Internal.StoreReview.Android;
using UnityEngine;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x731378", Offset = "0x731378")]
	[Token(Token = "0x2000094")]
	public class StoreReview : MonoBehaviour
	{
		[Token(Token = "0x2000148")]
		public enum UserAction
		{
			[Token(Token = "0x400056A")]
			Refuse = 0,
			[Token(Token = "0x400056B")]
			Postpone = 1,
			[Token(Token = "0x400056C")]
			Feedback = 2,
			[Token(Token = "0x400056D")]
			Rate = 3
		}

		[Token(Token = "0x4000376")]
		private static readonly string RATING_DIALOG_GAMEOBJECT = "MobileNativeRatingDialog";

		[Token(Token = "0x4000377")]
		private const int IOS_SYSTEM_DEFAULT_ANNUAL_CAP = 3;

		[Token(Token = "0x4000378")]
		private const int RATING_REQUEST_ENABLED = 1;

		[Token(Token = "0x4000379")]
		private const int RATING_REQUEST_DISABLED = -1;

		[Token(Token = "0x400037A")]
		private const string RATING_REQUEST_DISABLE_PPKEY = "EM_RATING_REQUEST_DISABLE";

		[Token(Token = "0x400037B")]
		private const string ANNUAL_REQUESTS_MADE_PPKEY_PREFIX = "EM_RATING_REQUESTS_MADE_YEAR_";

		[Token(Token = "0x400037C")]
		private const string LAST_REQUEST_TIMESTAMP_PPKEY = "EM_RATING_REQUEST_LAST_REQUEST_TIMESTAMP";

		[Token(Token = "0x400037D")]
		private static Action<UserAction> customBehaviour;

		[Token(Token = "0x170001C5")]
		[field: Token(Token = "0x4000375")]
		public static StoreReview Instance
		{
			[Token(Token = "0x600062F")]
			[Address(RVA = "0xFD50EC", Offset = "0xFD50EC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE5058]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256CA]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.StoreReview;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000630")]
			[Address(RVA = "0xFD5154", Offset = "0xFD5154", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F01EE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256CB]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.StoreReview;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x6000631")]
		[Address(RVA = "0xFD51C0", Offset = "0xFD51C0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAB3A8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256CC]) = v35;\nL_0017:\n\tgoto L_0022;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\tEasyMobile.StoreReview::RequestRating(0);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RequestRating()
		{
			RequestRating(null);
		}

		[Token(Token = "0x6000632")]
		[Address(RVA = "0xFD5220", Offset = "0xFD5220", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFE320]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256CD]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tEasyMobile.StoreReview::DoRequestRating(dialogContent, 0);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RequestRating(RatingDialogContent dialogContent)
		{
			DoRequestRating(dialogContent, null);
		}

		[Token(Token = "0x6000633")]
		[Address(RVA = "0xFD56B4", Offset = "0xFD56B4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC8F90]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256CE]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tEasyMobile.StoreReview::DoRequestRating(dialogContent, callback);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RequestRating(RatingDialogContent dialogContent, Action<UserAction> callback)
		{
			DoRequestRating(dialogContent, callback);
		}

		[Token(Token = "0x6000634")]
		[Address(RVA = "0xFD5728", Offset = "0xFD5728", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.EM_Settings::get_RatingRequest();\n\treturn v7.mDefaultRatingDialogContent;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RatingDialogContent GetDefaultDialogContent()
		{
			RatingRequestSettings ratingRequest = EM_Settings.RatingRequest;
			return ratingRequest.DefaultRatingDialogContent;
		}

		[Token(Token = "0x6000635")]
		[Address(RVA = "0xFD574C", Offset = "0xFD574C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA4C10]);\n\tv15 = *([v14 @ X8_v22]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256CF]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv70 = EasyMobile.StoreReview::IsDisplayConstraintIgnored();\n\tv53 = v70 == 0;\n\tif (v53) goto L_0031;\n\tgoto L_002C;\n\tv58 = *([v50 @ X8_v5+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_002C;\n\tv74 = v50;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v74, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002C:\n\tv65 = EasyMobile.StoreReview::IsRatingRequestDisabled();\n\tv123 = v65 ^ 1;\n\tgoto L_0058;\nL_0031:\n\tgoto L_0038;\n\tv66 = *([v50 @ X8_v5+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0038;\n\tv76 = v50;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v76, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0038:\n\tv73 = EasyMobile.StoreReview::IsRatingRequestDisabled();\n\tv78 = v73 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_FFFFFFFF;\n\tgoto L_0047;\n\tv159 = *([v130 @ X0_v10 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0047;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v130, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0047:\n\tv152 = EasyMobile.StoreReview::GetRemainingDelayAfterInstallation();\n\tv134 = v152 <= 0;\n\tif (v134) goto L_0060;\nL_0058:\n\treturnVal1 = v123 & 1;\n\treturn returnVal1;\nL_0060:\n\tgoto L_0066;\n\tv171 = *([v167 @ X0_v13 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0066;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v167, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0066:\n\tv153 = EasyMobile.StoreReview::GetThisYearRemainingRequests();\n\tv135 = v153 < 1;\n\tif (v135) goto L_FFFFFFFF;\n\tgoto L_007D;\n\tv182 = *([v178 @ X0_v16 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_007D;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v178, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_007D:\n\tv119 = EasyMobile.StoreReview::GetRemainingCoolingOffDays();\n\tv111 = v119 - 1;\n\tv107 = v111 < 0;\n\tv99 = v119 ^ 1;\n\tv95 = v119 ^ v111;\n\tv91 = v99 & v95;\n\tv87 = v91 < 0;\n\tv189 = v107 == v87;\n\tv83 = ~v189;\n\tgoto L_0058;\n\treturn X0;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CanRequestRating()
		{
			int num;
			if (IsDisplayConstraintIgnored())
			{
				bool flag = IsRatingRequestDisabled();
				num = (flag ? 1 : 0) ^ 1;
			}
			else
			{
				if (!IsRatingRequestDisabled())
				{
					int remainingDelayAfterInstallation = GetRemainingDelayAfterInstallation();
					if (remainingDelayAfterInstallation <= 0)
					{
						int thisYearRemainingRequests = GetThisYearRemainingRequests();
						if (thisYearRemainingRequests >= 1)
						{
							int remainingCoolingOffDays = GetRemainingCoolingOffDays();
							int num2 = remainingCoolingOffDays - 1;
							bool flag2 = num2 < 0;
							int num3 = remainingCoolingOffDays ^ 1;
							int num4 = remainingCoolingOffDays ^ num2;
							int num5 = num3 & num4;
							bool flag3 = num5 < 0;
							bool flag4 = flag2 == flag3;
							bool flag5 = !flag4;
							num = (flag5 ? 1 : 0);
							goto IL_0176;
						}
					}
				}
				num = 0;
			}
			goto IL_0176;
			IL_0176:
			return (byte)(num & 1) != 0;
		}

		[Token(Token = "0x6000636")]
		[Address(RVA = "0xFD586C", Offset = "0xFD586C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA6828]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D0]) = v35;\nL_0017:\n\tgoto L_001E;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001E;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001E:\n\tv50 = EasyMobile.Internal.Util::IsUnityDevelopmentBuild();\n\tv52 = v50 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv54 = EasyMobile.EM_Settings::get_RatingRequest();\n\tv74 = v54.mIgnoreContraintsInDevelopment == 0;\n\tv59 = ~v74;\n\tgoto L_0038;\nL_0038:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsDisplayConstraintIgnored()
		{
			if (Util.IsUnityDevelopmentBuild())
			{
				RatingRequestSettings ratingRequest = EM_Settings.RatingRequest;
				bool flag = !ratingRequest.IgnoreConstraintsInDevelopment;
				return !flag;
			}
			return false;
		}

		[Token(Token = "0x6000637")]
		[Address(RVA = "0xFD58F8", Offset = "0xFD58F8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EF88D0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D1]) = v35;\nL_0016:\n\tv41 = EasyMobile.Internal.StorageUtil::GetInt(\"EM_RATING_REQUEST_DISABLE\", 1);\n\tv44 = v41 + 1;\n\tv46 = v44 == 0;\n\treturn v46;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsRatingRequestDisabled()
		{
			int num = StorageUtil.GetInt("EM_RATING_REQUEST_DISABLE", 1);
			int num2 = num + 1;
			return num2 == 0;
		}

		[Token(Token = "0x6000638")]
		[Address(RVA = "0xFD5954", Offset = "0xFD5954", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1ECE260]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D2]) = v35;\nL_0018:\n\tgoto L_001F;\n\tv43 = *([v39 @ X0_v2+E0]);\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tgoto L_001F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001F:\n\tv51 = System.DateTime::get_Now();\n\tgoto L_002F;\n\tv59 = *([v55 @ X8_v9+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002F;\n\tv68 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v68, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002F:\n\tv51 = EasyMobile.Internal.RuntimeHelper::GetAppInstallationTime();\n\tv72 = EasyMobile.Internal.DateTimeExt::SameTimeZoneSubtract(v51, v51);\n\tv51 = 0x9BD07C(&v72 @ X0_v10 (System.TimeSpan), 0, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv79 = EasyMobile.EM_Settings::get_RatingRequest();\n\tv84 = v79.mDelayAfterInstallation - v51;\n\tv85 = ~v84;\n\treturnVal1 = v84 & v85;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetRemainingDelayAfterInstallation()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_0065: Expected I4, but got O
			DateTime now = DateTime.Now;
			now = RuntimeHelper.GetAppInstallationTime();
			TimeSpan timeSpan = now.SameTimeZoneSubtract(now);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9BD07C (inside System.TimeSpan::TimeToTicks +0xFC)");
			RatingRequestSettings ratingRequest = EM_Settings.RatingRequest;
			object obj = ratingRequest.DelayAfterInstallation - now;
			int num = (int)(~obj);
			return (int)((long)(IntPtr)obj & (long)num);
		}

		[Token(Token = "0x6000639")]
		[Address(RVA = "0xFD5A98", Offset = "0xFD5A98", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EF77A0]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D3]) = v35;\nL_0018:\n\tgoto L_001F;\n\tv43 = *([v39 @ X0_v2+E0]);\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tgoto L_001F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001F:\n\tv51 = System.DateTime::get_Now();\n\tgoto L_002E;\n\tv59 = *([v55 @ X8_v9+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002E;\n\tv67 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v67, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002E:\n\tv51 = EasyMobile.StoreReview::GetLastRequestTimestamp();\n\tv71 = EasyMobile.Internal.DateTimeExt::SameTimeZoneSubtract(v51, v51);\n\tv51 = 0x9BD07C(&v71 @ X0_v9 (System.TimeSpan), 0, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv78 = EasyMobile.EM_Settings::get_RatingRequest();\n\tv83 = v78.mCoolingOffPeriod - v51;\n\tv84 = ~v83;\n\treturnVal1 = v83 & v84;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetRemainingCoolingOffDays()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_0065: Expected I4, but got O
			DateTime now = DateTime.Now;
			now = GetLastRequestTimestamp();
			TimeSpan timeSpan = now.SameTimeZoneSubtract(now);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9BD07C (inside System.TimeSpan::TimeToTicks +0xFC)");
			RatingRequestSettings ratingRequest = EM_Settings.RatingRequest;
			object obj = ratingRequest.CoolingOffPeriod - now;
			int num = (int)(~obj);
			return (int)((long)(IntPtr)obj & (long)num);
		}

		[Token(Token = "0x600063A")]
		[Address(RVA = "0xFD5B6C", Offset = "0xFD5B6C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F0C728]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D4]) = v35;\nL_0018:\n\tgoto L_0022;\n\tv43 = *([v39 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Util>)+E0]);\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tgoto L_0022;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v39, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv47 = EasyMobile.Internal.Util;\nL_0022:\n\tv54 = v50.UnixEpoch;\n\tv55 = 0xE95E98(&v54 @ X8_v6 (System.DateTime), 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturnVal1 = EasyMobile.Internal.StorageUtil::GetTime(\"EM_RATING_REQUEST_LAST_REQUEST_TIMESTAMP\", v55);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static DateTime GetLastRequestTimestamp()
		{
			DateTime unixEpoch = Util.UnixEpoch;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95E98 (inside System.DateTime::ParseExact +0x1D0)");
			DateTime defaultTime = default(DateTime);
			return StorageUtil.GetTime("EM_RATING_REQUEST_LAST_REQUEST_TIMESTAMP", defaultTime);
		}

		[Token(Token = "0x600063B")]
		[Address(RVA = "0xFD5C04", Offset = "0xFD5C04", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EEBD60]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D5]) = v35;\nL_0018:\n\tgoto L_001F;\n\tv43 = *([v39 @ X0_v2+E0]);\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tgoto L_001F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001F:\n\tv51 = System.DateTime::get_Now();\n\tv55 = 0xE958CC(&v51 @ X0_v5 (System.DateTime), 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0033;\n\tv63 = *([v59 @ X8_v9+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0033;\n\tv72 = v59;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v72, v54, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0033:\n\treturnVal1 = EasyMobile.StoreReview::GetAnnualUsedRequests(v55);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetThisYearUsedRequests()
		{
			DateTime now = DateTime.Now;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E958CC (inside System.DateTime::GetSystemTimeAsFileTime +0x74)");
			int year = default(int);
			return GetAnnualUsedRequests(year);
		}

		[Token(Token = "0x600063C")]
		[Address(RVA = "0xFD5A2C", Offset = "0xFD5A2C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF8E50]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D6]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.StoreReview::GetAnnualRequestsLimit();\n\tv51 = EasyMobile.StoreReview::GetThisYearUsedRequests();\n\treturnVal1 = v49 - v51;\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetThisYearRemainingRequests()
		{
			int annualRequestsLimit = GetAnnualRequestsLimit();
			int thisYearUsedRequests = GetThisYearUsedRequests();
			return annualRequestsLimit - thisYearUsedRequests;
		}

		[Token(Token = "0x600063D")]
		[Address(RVA = "0xFD5D20", Offset = "0xFD5D20", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.EM_Settings::get_RatingRequest();\n\treturn v7.mAnnualCap;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetAnnualRequestsLimit()
		{
			RatingRequestSettings ratingRequest = EM_Settings.RatingRequest;
			return (int)ratingRequest.AnnualCap;
		}

		[Token(Token = "0x600063E")]
		[Address(RVA = "0xFD5D44", Offset = "0xFD5D44", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EDA6B8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256D7]) = v35;\nL_0016:\n\tEasyMobile.Internal.StorageUtil::SetInt(\"EM_RATING_REQUEST_DISABLE\", 0xFFFFFFFF);\n\tEasyMobile.Internal.StorageUtil::Save();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DisableRatingRequest()
		{
			StorageUtil.SetInt("EM_RATING_REQUEST_DISABLE", -1);
			StorageUtil.Save();
		}

		[Token(Token = "0x600063F")]
		[Address(RVA = "0xFD5CAC", Offset = "0xFD5CAC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-4]) = year;\n\tgoto L_0012;\n\tv15 = *([1EF5D28]);\n\tv16 = *([v15 @ X8_v7]);\n\tv17 = \"il2cpp_codegen_initialize_method\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 0 | 1;\n\t*([20256D8]) = v35;\nL_0012:\n\tv36 = &v7 @ stack_-10_v2 - 4;\n\tv38 = 0xDC3560(v36, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv45 = System.String::Concat(\"EM_RATING_REQUESTS_MADE_YEAR_\", v38);\n\treturnVal1 = EasyMobile.Internal.StorageUtil::GetInt(v45, 0);\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int GetAnnualUsedRequests(int year)
		{
			//IL_0026: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string text = default(string);
			string key = "EM_RATING_REQUESTS_MADE_YEAR_" + text;
			return StorageUtil.GetInt(key, 0);
		}

		[Token(Token = "0x6000640")]
		[Address(RVA = "0xFD5D9C", Offset = "0xFD5D9C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EDFF60]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, requestNumber, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([20256D9]) = v39;\nL_0016:\n\tv42 = 0xDC3560(&year @ X0 (System.Int32), 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = System.String::Concat(\"EM_RATING_REQUESTS_MADE_YEAR_\", v42);\n\tEasyMobile.Internal.StorageUtil::SetInt(v49, requestNumber);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetAnnualUsedRequests(int year, int requestNumber)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string text = default(string);
			string key = "EM_RATING_REQUESTS_MADE_YEAR_" + text;
			StorageUtil.SetInt(key, requestNumber);
		}

		[Token(Token = "0x6000641")]
		[Address(RVA = "0xFD5288", Offset = "0xFD5288", Length = "0x42C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv36 = *([1EEE170]);\n\tv37 = *([v36 @ X8_v63]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, callback, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20256DA]) = v55;\nL_0023:\n\tgoto L_0029;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0029;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, callback, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0029:\n\tv70 = EasyMobile.StoreReview::CanRequestRating();\n\tv72 = v70 == 0;\n\tif (v72) goto L_013E;\n\tv73 = content == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0039;\n\tv82 = EasyMobile.EM_Settings::get_RatingRequest();\n\tv86 = v82.mDefaultRatingDialogContent;\nL_0039:\n\tgoto L_0041;\n\tv103 = *([v88 @ X0_v11 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tgoto L_0041;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v88, callback, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv107 = EasyMobile.StoreReview;\nL_0041:\n\tv110.customBehaviour = callback;\n\tgoto L_0051;\n\tv225 = *([1F099B0]);\n\tv226 = *([v225 @ X8_v56]);\n\tv227 = \"il2cpp_codegen_initialize_method\"(v226, callback, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv229 = EasyMobile.StoreReview;\n\tv231 = 0 | 1;\n\t*([20256FC]) = v231;\nL_0051:\n\tgoto L_0060;\n\tv262 = *([v228 @ X0_v13 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv263 = v262 == 0;\n\tv264 = ~v263;\n\tgoto L_0060;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v228, callback, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv266 = EasyMobile.StoreReview;\nL_0060:\n\tgoto L_006A;\n\tv275 = *([v179 @ X8_v22+E0]);\n\tv276 = v275 == 0;\n\tv277 = ~v276;\n\tgoto L_006A;\n\tv282 = v179;\n\tv279 = \"il2cpp_codegen_runtime_class_init\"(v282, callback, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_006A:\n\tv164 = UnityEngine.Object::op_Inequality(v271.<Instance>k__BackingField, 0);\n\tv284 = v164 == 0;\n\tv168 = ~v284;\n\tif (v168) goto L_0156;\n\tgoto L_007F;\n\tv289 = *([v285 @ X0_v18 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv290 = v289 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_007F;\n\tv301 = \"il2cpp_codegen_runtime_class_init\"(v285, v155, v151, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv293 = EasyMobile.StoreReview;\nL_007F:\n\tv300 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v300, v297.RATING_DIALOG_GAMEOBJECT);\n\tv310 = UnityEngine.GameObject::AddComponent(v300);\n\tgoto L_009B;\n\tv346 = *([1EBA958]);\n\tv347 = *([v346 @ X8_v51]);\n\tv348 = \"il2cpp_codegen_initialize_method\"(v347, v309, v303, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv351 = 0 | 1;\n\t*([20256FD]) = v351;\nL_009B:\n\tgoto L_00A3;\n\tv356 = *([v352 @ X0_v28 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv357 = v356 == 0;\n\tv358 = ~v357;\n\tgoto L_00A3;\n\tv362 = \"il2cpp_codegen_runtime_class_init\"(v352, v309, v303, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv359 = EasyMobile.StoreReview;\nL_00A3:\n\tv338.<Instance>k__BackingField = v310;\n\tv325 = UnityEngine.Application::get_productName();\n\tv366 = System.String::Replace(v86.mTitle, \"$PRODUCT_NAME\", v325);\n\tv326 = UnityEngine.Application::get_productName();\n\tv369 = System.String::Replace(v86.mMessage, \"$PRODUCT_NAME\", v326);\n\tv327 = UnityEngine.Application::get_productName();\n\tv372 = System.String::Replace(v86.mLowRatingMessage, \"$PRODUCT_NAME\", v327);\n\tv328 = UnityEngine.Application::get_productName();\n\tv377 = System.String::Replace(v86.mHighRatingMessage, \"$PRODUCT_NAME\", v328);\n\tv382 = new EasyMobile.RatingDialogContent();\n\tEasyMobile.RatingDialogContent::.ctor(v382, v366, v369, v372, v377, v86.mPostponeButtonText, v86.mRefuseButtonText, v86.mRateButtonText, v86.mCancelButtonText, v86.mFeedbackButtonText);\n\tv387 = EasyMobile.EM_Settings::get_RatingRequest();\n\tgoto L_00FC;\n\tv394 = *([v180 @ X8_v39+E0]);\n\tv395 = v394 == 0;\n\tv396 = ~v395;\n\tif (v396) goto L_00FC;\n\tv401 = v180;\n\tv398 = \"il2cpp_codegen_runtime_class_init\"(v401, v383, v384, v147, v133, v131, v129, v127, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00FC:\n\tEasyMobile.Internal.StoreReview.Android.AndroidNativeUtility::RequestRating(v382, v387);\n\tv165 = EasyMobile.StoreReview::IsDisplayConstraintIgnored();\n\tv404 = v165 == 0;\n\tv169 = ~v404;\n\tif (v169) goto L_0156;\n\tgoto L_0111;\n\tv411 = *([v407 @ X0_v53+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tif (v413) goto L_0111;\n\tv415 = \"il2cpp_codegen_runtime_class_init\"(v407, v156, v152, v147, v133, v131, v129, v127, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0111:\n\tv419 = System.DateTime::get_Now();\n\tv423 = 0xE958CC(&v419 @ X0_v56 (System.DateTime), 0, 0, v372, v377, v86.mPostponeButtonText, v86.mRefuseButtonText, v86.mRateButtonText, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv425 = System.DateTime::get_Now();\n\tv428 = 0xE958CC(&v425 @ X0_v60 (System.DateTime), 0, 0, v372, v377, v86.mPostponeButtonText, v86.mRefuseButtonText, v86.mRateButtonText, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_012A;\n\tv433 = *([v429 @ X8_v44+E0]);\n\tv434 = v433 == 0;\n\tv435 = ~v434;\n\tif (v435) goto L_012A;\n\tv440 = v429;\n\tv437 = \"il2cpp_codegen_runtime_class_init\"(v440, v427, v152, v147, v133, v131, v129, v127, v45, v46, v47, v48, v49, v50, v51, v52);\nL_012A:\n\tv439 = EasyMobile.StoreReview::GetAnnualUsedRequests(v428);\n\tv441 = v439 + 1;\n\tEasyMobile.StoreReview::SetAnnualUsedRequests(v423, v441);\n\tv444 = System.DateTime::get_Now();\n\tEasyMobile.Internal.StorageUtil::SetTime(\"EM_RATING_REQUEST_LAST_REQUEST_TIMESTAMP\", v444);\n\tgoto L_0156;\nL_013E:\n\tgoto L_0148;\n\tv92 = *([v77 @ X0_v6+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0148;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v77, callback, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0148:\n\tUnityEngine.Debug::Log(\"Could not display the rating request popup because it was disabled, or one or more display constraints are not satisfied.\");\nL_0156:\n\treturn;\n\tv212 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DoRequestRating(RatingDialogContent content, Action<UserAction> callback)
		{
			if (CanRequestRating())
			{
				bool flag = content == null;
				bool flag2 = !flag;
				RatingDialogContent ratingDialogContent = content;
				if (!flag2)
				{
					RatingRequestSettings ratingRequest = EM_Settings.RatingRequest;
					ratingDialogContent = ratingRequest.DefaultRatingDialogContent;
				}
				customBehaviour = callback;
				if (!(Instance != null))
				{
					GameObject gameObject = new GameObject(RATING_DIALOG_GAMEOBJECT);
					StoreReview storeReview = gameObject.AddComponent<StoreReview>();
					Instance = storeReview;
					string productName = Application.productName;
					string title = ratingDialogContent.Title.Replace("$PRODUCT_NAME", productName);
					string productName2 = Application.productName;
					string message = ratingDialogContent.Message.Replace("$PRODUCT_NAME", productName2);
					string productName3 = Application.productName;
					string lowRatingMessage = ratingDialogContent.LowRatingMessage.Replace("$PRODUCT_NAME", productName3);
					string productName4 = Application.productName;
					string highRatingMessage = ratingDialogContent.HighRatingMessage.Replace("$PRODUCT_NAME", productName4);
					RatingDialogContent content2 = new RatingDialogContent(title, message, lowRatingMessage, highRatingMessage, ratingDialogContent.PostponeButtonText, ratingDialogContent.RefuseButtonText, ratingDialogContent.RateButtonText, ratingDialogContent.CancelButtonText, ratingDialogContent.FeedbackButtonText);
					RatingRequestSettings ratingRequest2 = EM_Settings.RatingRequest;
					AndroidNativeUtility.RequestRating(content2, ratingRequest2);
					if (!IsDisplayConstraintIgnored())
					{
						DateTime now = DateTime.Now;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E958CC (inside System.DateTime::GetSystemTimeAsFileTime +0x74)");
						DateTime now2 = DateTime.Now;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E958CC (inside System.DateTime::GetSystemTimeAsFileTime +0x74)");
						int year = default(int);
						int annualUsedRequests = GetAnnualUsedRequests(year);
						int requestNumber = annualUsedRequests + 1;
						int year2 = default(int);
						SetAnnualUsedRequests(year2, requestNumber);
						DateTime now3 = DateTime.Now;
						StorageUtil.SetTime("EM_RATING_REQUEST_LAST_REQUEST_TIMESTAMP", now3);
					}
				}
			}
			else
			{
				Debug.Log("Could not display the rating request popup because it was disabled, or one or more display constraints are not satisfied.");
			}
		}

		[Token(Token = "0x6000642")]
		[Address(RVA = "0xFD5E1C", Offset = "0xFD5E1C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBD008]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256DB]) = v38;\nL_0015:\n\tv41 = EasyMobile.StoreReview;\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = EasyMobile.StoreReview;\n\tv49 = *([v51 @ X0_v14+12E]);\nL_0022:\n\tv70 = v54.customBehaviour;\n\tv56 = v54.customBehaviour == 0;\n\tif (v56) goto L_0040;\n\tv58 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_003C;\n\tv63 = *([v50 @ X0_v3 (Il2CppClass<EasyMobile.StoreReview>)+E0]) == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003C;\n\tv70 = v94.customBehaviour;\nL_003C:\n\tSystem.Action`1<EasyMobile.StoreReview+UserAction>::Invoke(v70, action);\n\treturn;\nL_0040:\n\tgoto L_004C;\n\tv81 = *([v50 @ X0_v3 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_004C;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004C:\n\tEasyMobile.StoreReview::PerformDefaultBehaviour(action);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DefaultCallback(UserAction action)
		{
			//IL_00a1: Expected I, but got O
			//IL_00af: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(StoreReview);
			IntPtr intPtr2 = (IntPtr)typeof(StoreReview);
			Action<UserAction> action2 = customBehaviour;
			if (customBehaviour != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X0_v2 (Il2CppClass<EasyMobile.StoreReview>)+12E]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v3 (Il2CppClass<EasyMobile.StoreReview>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						action2 = customBehaviour;
					}
				}
				action2(action);
			}
			else
			{
				PerformDefaultBehaviour(action);
			}
		}

		[Token(Token = "0x6000643")]
		[Address(RVA = "0xFD5EEC", Offset = "0xFD5EEC", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC15C8]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256DC]) = v38;\nL_0017:\n\tv43 = action == 3;\n\tif (v43) goto L_0030;\n\tv52 = action == 2;\n\tif (v52) goto L_004B;\n\tv59 = action == 0;\n\tif (v59) goto L_007A;\n\treturn;\nL_0030:\n\tv58 = UnityEngine.Application::get_platform();\n\tv71 = v58 != 8;\n\tif (v71) goto L_005D;\n\tv128 = EasyMobile.EM_Settings::get_RatingRequest();\n\tv114 = System.String::Concat(\"itms-apps://itunes.apple.com/app/id\", v128.mIosAppId, \"?action=write-review\");\n\tgoto L_0073;\nL_004B:\n\tv61 = EasyMobile.EM_Settings::get_RatingRequest();\n\tv158 = System.String::Concat(\"mailto:\", v61.mSupportEmail);\n\tUnityEngine.Application::OpenURL(v158);\n\treturn;\nL_005D:\n\tv115 = UnityEngine.Application::get_platform();\n\tv88 = v115 != 0xB;\n\tif (v88) goto L_007A;\n\tv196 = UnityEngine.Application::get_identifier();\n\tv114 = System.String::Concat(\"market://details?id=\", v196);\nL_0073:\n\tUnityEngine.Application::OpenURL(v114);\nL_007A:\n\tgoto L_0085;\n\tv176 = *([v122 @ X0_v5 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0085;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v122, v80, v76, v78, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0085:\n\tEasyMobile.StoreReview::DisableRatingRequest();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PerformDefaultBehaviour(UserAction action)
		{
			switch (action)
			{
			default:
				return;
			case UserAction.Rate:
			{
				RuntimePlatform platform = Application.platform;
				string url2;
				if (platform == RuntimePlatform.IPhonePlayer)
				{
					RatingRequestSettings ratingRequest2 = EM_Settings.RatingRequest;
					url2 = "itms-apps://itunes.apple.com/app/id" + ratingRequest2.IosAppId + "?action=write-review";
				}
				else
				{
					RuntimePlatform platform2 = Application.platform;
					if (platform2 != RuntimePlatform.Android)
					{
						break;
					}
					string identifier = Application.identifier;
					url2 = "market://details?id=" + identifier;
				}
				Application.OpenURL(url2);
				break;
			}
			case UserAction.Feedback:
			{
				RatingRequestSettings ratingRequest = EM_Settings.RatingRequest;
				string url = "mailto:" + ratingRequest.SupportEmail;
				Application.OpenURL(url);
				return;
			}
			case UserAction.Refuse:
				break;
			}
			DisableRatingRequest();
		}

		[Token(Token = "0x6000644")]
		[Address(RVA = "0xFD6024", Offset = "0xFD6024", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = index < 4;\n\tv2 = ~v0;\n\tv10 = ~v2;\n\tv11 = ~v10;\n\tif (v11) goto L_FFFFFFFF;\n\tgoto L_0010;\nL_0010:\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static UserAction ConvertToUserAction(int index)
		{
			if (index < 4)
			{
				return (UserAction)index;
			}
			return UserAction.Postpone;
		}

		[Token(Token = "0x6000645")]
		[Address(RVA = "0xFD6030", Offset = "0xFD6030", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED75E8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, userAction, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256DD]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, userAction, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = System.Convert::ToInt16(userAction);\n\tgoto L_0032;\n\tv65 = *([v61 @ X8_v7+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0032;\n\tv85 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v85, v56, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0032:\n\tv72 = v57 & 0xFFFF;\n\tv74 = v72 < 4;\n\tv75 = ~v74;\n\tv83 = ~v75;\n\tv84 = ~v83;\n\tif (v84) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tEasyMobile.StoreReview::DefaultCallback(v88);\n\tgoto L_0054;\n\tv94 = *([1EBA958]);\n\tv95 = *([v94 @ X8_v19]);\n\tv96 = \"il2cpp_codegen_initialize_method\"(v95, v56, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv99 = 0 | 1;\n\t*([20256FD]) = v99;\nL_0054:\n\tgoto L_005E;\n\tv104 = *([v100 @ X0_v9 (Il2CppClass<EasyMobile.StoreReview>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tgoto L_005E;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v100, v56, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv108 = EasyMobile.StoreReview;\nL_005E:\n\tv111.<Instance>k__BackingField = 0;\n\tv114 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0076;\n\tv123 = *([v119 @ X8_v16+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tgoto L_0076;\n\tv137 = v119;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v137, v113, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0076:\n\tUnityEngine.Object::Destroy(v114);\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnAndroidRatingDialogCallback(string userAction)
		{
			short num = Convert.ToInt16(userAction);
			int num2 = num & 0xFFFF;
			UserAction action = (UserAction)((num2 >= 4) ? 1 : num);
			DefaultCallback(action);
			Instance = null;
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}

		[Token(Token = "0x6000646")]
		[Address(RVA = "0xFD6168", Offset = "0xFD6168", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StoreReview()
		{
		}
	}
}

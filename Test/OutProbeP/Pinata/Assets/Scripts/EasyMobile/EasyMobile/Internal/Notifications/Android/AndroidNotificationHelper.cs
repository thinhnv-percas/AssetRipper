using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.MiniJSON;
using UnityEngine;

namespace EasyMobile.Internal.Notifications.Android
{
	[Token(Token = "0x20000EB")]
	internal class AndroidNotificationHelper
	{
		[Token(Token = "0x600089E")]
		[Address(RVA = "0xC032E8", Offset = "0xC032E8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC6F70]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022FBE]) = v42;\nL_0018:\n\tv46 = categoryGroups == 0;\n\tif (v46) goto L_0067;\n\t// 27 NewArr v48 @ X0_v7 (System.String[]), typeof(System.String[]), categoryGroups.Length\n\tv137 = categoryGroups.Length;\n\tv63 = categoryGroups.Length < 1;\n\tif (v63) goto L_0072;\nL_002B:\n\tv138 = v124 < v137;\n\tv139 = ~v138;\n\tif (v139) goto L_0074;\n\tv150 = EasyMobile.Internal.Notifications.Android.AndroidNotificationCategoryGroup::FromCrossPlatformCategoryGroup(categoryGroups[v124 @ X9_v3 (System.Int32)]);\n\tv216 = UnityEngine.JsonUtility::ToJson(v150);\n\tv232 = v216 == 0;\n\tif (v232) goto L_004A;\n\tv237 = *([v48 @ X0_v7 (System.String[])]);\n\tv235 = \"il2cpp_codegen_object_is_inst\"(v216, *([v237 @ X8_v16 (Il2CppClass<System.Object>)+40]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004A:\n\tv240 = v124 < v48.Length;\n\tv169 = ~v240;\n\tif (v169) goto L_0074;\n\tv48[v124 @ X9_v3 (System.Int32)] = v216;\n\tv137 = categoryGroups.Length;\n\tv124 = v124 + 1;\n\tv78 = v124 < categoryGroups.Length;\n\tif (v78) goto L_002B;\n\tgoto L_0072;\nL_0067:\n\t// 103 NewArr v50 @ X0_v6 (System.String[]), typeof(System.String[]), 0\nL_0072:\n\treturnVal1 = EasyMobile.MiniJSON.Json::Serialize(v111);\n\treturn returnVal1;\nL_0074:\n\tv175 = new System.IndexOutOfRangeException();\n\tgoto L_007C;\n\tthrow System.NullReferenceException;\n\tv231 = new System.NullReferenceException();\n\tv222 = new System.ArrayTypeMismatchException();\nL_007C:\n\tthrow v221;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string ToJson(NotificationCategoryGroup[] categoryGroups)
		{
			//IL_00a7: Expected I, but got O
			object obj;
			if (categoryGroups != null)
			{
				string[] array = new string[categoryGroups.Length];
				int num = categoryGroups.Length;
				bool flag = categoryGroups.Length < 1;
				obj = array;
				if (!flag)
				{
					int num2 = 0;
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					while (true)
					{
						if (num2 < num)
						{
							AndroidNotificationCategoryGroup obj2 = AndroidNotificationCategoryGroup.FromCrossPlatformCategoryGroup(categoryGroups[num2]);
							string text = JsonUtility.ToJson(obj2);
							if (text != null)
							{
								IntPtr intPtr = (IntPtr)array;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
							}
							if (num2 < array.Length)
							{
								array[num2] = text;
								num = categoryGroups.Length;
								num2++;
								if (num2 >= categoryGroups.Length)
								{
									break;
								}
								continue;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex2;
					}
					obj = array;
				}
			}
			else
			{
				string[] array2 = new string[0];
				obj = array2;
			}
			return Json.Serialize(obj);
		}

		[Token(Token = "0x600089F")]
		[Address(RVA = "0xC03400", Offset = "0xC03400", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA96F8]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022FBF]) = v42;\nL_0018:\n\tv46 = categories == 0;\n\tif (v46) goto L_0067;\n\t// 27 NewArr v48 @ X0_v7 (System.String[]), typeof(System.String[]), categories.Length\n\tv137 = categories.Length;\n\tv63 = categories.Length < 1;\n\tif (v63) goto L_0072;\nL_002B:\n\tv138 = v124 < v137;\n\tv139 = ~v138;\n\tif (v139) goto L_0074;\n\tv150 = EasyMobile.Internal.Notifications.Android.AndroidNotificationCategory::FromCrossPlatformCategory(categories[v124 @ X9_v3 (System.Int32)]);\n\tv216 = UnityEngine.JsonUtility::ToJson(v150);\n\tv232 = v216 == 0;\n\tif (v232) goto L_004A;\n\tv237 = *([v48 @ X0_v7 (System.String[])]);\n\tv235 = \"il2cpp_codegen_object_is_inst\"(v216, *([v237 @ X8_v16 (Il2CppClass<System.Object>)+40]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004A:\n\tv240 = v124 < v48.Length;\n\tv169 = ~v240;\n\tif (v169) goto L_0074;\n\tv48[v124 @ X9_v3 (System.Int32)] = v216;\n\tv137 = categories.Length;\n\tv124 = v124 + 1;\n\tv78 = v124 < categories.Length;\n\tif (v78) goto L_002B;\n\tgoto L_0072;\nL_0067:\n\t// 103 NewArr v50 @ X0_v6 (System.String[]), typeof(System.String[]), 0\nL_0072:\n\treturnVal1 = EasyMobile.MiniJSON.Json::Serialize(v111);\n\treturn returnVal1;\nL_0074:\n\tv175 = new System.IndexOutOfRangeException();\n\tgoto L_007C;\n\tthrow System.NullReferenceException;\n\tv231 = new System.NullReferenceException();\n\tv222 = new System.ArrayTypeMismatchException();\nL_007C:\n\tthrow v221;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string ToJson(NotificationCategory[] categories)
		{
			//IL_00a7: Expected I, but got O
			object obj;
			if (categories != null)
			{
				string[] array = new string[categories.Length];
				int num = categories.Length;
				bool flag = categories.Length < 1;
				obj = array;
				if (!flag)
				{
					int num2 = 0;
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					while (true)
					{
						if (num2 < num)
						{
							AndroidNotificationCategory obj2 = AndroidNotificationCategory.FromCrossPlatformCategory(categories[num2]);
							string text = JsonUtility.ToJson(obj2);
							if (text != null)
							{
								IntPtr intPtr = (IntPtr)array;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
							}
							if (num2 < array.Length)
							{
								array[num2] = text;
								num = categories.Length;
								num2++;
								if (num2 >= categories.Length)
								{
									break;
								}
								continue;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex2;
					}
					obj = array;
				}
			}
			else
			{
				string[] array2 = new string[0];
				obj = array2;
			}
			return Json.Serialize(obj);
		}

		[Token(Token = "0x60008A0")]
		[Address(RVA = "0xC03518", Offset = "0xC03518", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidNotificationHelper()
		{
		}
	}
}

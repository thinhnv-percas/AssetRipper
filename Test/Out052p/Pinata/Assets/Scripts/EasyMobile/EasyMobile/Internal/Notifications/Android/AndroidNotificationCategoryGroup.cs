using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Notifications.Android
{
	[Serializable]
	[Token(Token = "0x20000EC")]
	internal class AndroidNotificationCategoryGroup
	{
		[Token(Token = "0x400042B")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x400042C")]
		[FieldOffset(Offset = "0x18")]
		public string name;

		[Token(Token = "0x60008A1")]
		[Address(RVA = "0xC03250", Offset = "0xC03250", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.JsonUtility::ToJson(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal string ToJson()
		{
			return JsonUtility.ToJson(this);
		}

		[Token(Token = "0x60008A2")]
		[Address(RVA = "0xC03258", Offset = "0xC03258", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED1848]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FBD]) = v38;\nL_0013:\n\tv39 = categoryGroup == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv43 = new EasyMobile.Internal.Notifications.Android.AndroidNotificationCategoryGroup();\n\tSystem.Object::.ctor(v43);\n\tv43.id = categoryGroup.id;\n\tv43.name = categoryGroup.name;\n\tgoto L_002A;\nL_002A:\n\treturn v53;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidNotificationCategoryGroup FromCrossPlatformCategoryGroup(NotificationCategoryGroup categoryGroup)
		{
			if (categoryGroup != null)
			{
				AndroidNotificationCategoryGroup androidNotificationCategoryGroup = new AndroidNotificationCategoryGroup();
				androidNotificationCategoryGroup.id = categoryGroup.id;
				androidNotificationCategoryGroup.name = categoryGroup.name;
				return androidNotificationCategoryGroup;
			}
			return null;
		}

		[Token(Token = "0x60008A3")]
		[Address(RVA = "0xC032E0", Offset = "0xC032E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidNotificationCategoryGroup()
		{
		}
	}
}

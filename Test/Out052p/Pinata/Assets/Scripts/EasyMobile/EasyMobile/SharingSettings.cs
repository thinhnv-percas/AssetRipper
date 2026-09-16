using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000091")]
	public class SharingSettings : IAndroidPermissionRequired, IIOSInfoItemRequired
	{
		[SerializeField]
		[Token(Token = "0x4000360")]
		[FieldOffset(Offset = "0x10")]
		private List<AndroidPermission> mAndroidPermissions;

		[SerializeField]
		[Token(Token = "0x4000361")]
		[FieldOffset(Offset = "0x18")]
		private List<iOSInfoPlistItem> mIOSInfoPlistItems;

		[Token(Token = "0x6000606")]
		[Address(RVA = "0xFD4F70", Offset = "0xFD4F70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAndroidPermissions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<AndroidPermission> GetAndroidPermissions()
		{
			return mAndroidPermissions;
		}

		[Token(Token = "0x6000607")]
		[Address(RVA = "0xFD4F78", Offset = "0xFD4F78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIOSInfoPlistItems;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<iOSInfoPlistItem> GetIOSInfoPlistKeys()
		{
			return mIOSInfoPlistItems;
		}

		[Token(Token = "0x6000608")]
		[Address(RVA = "0xFD4F80", Offset = "0xFD4F80", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EA8D58]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20256C9]) = v44;\nL_0019:\n\tv48 = new System.Collections.Generic.List`1<EasyMobile.AndroidPermission>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::.ctor(v48);\n\tv56 = new EasyMobile.AndroidPermission();\n\tEasyMobile.AndroidPermission::.ctor(v56, \"uses-permission\", \"android.permission.WRITE_EXTERNAL_STORAGE\");\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::Add(v48, v56);\n\tthis.mAndroidPermissions = v48;\n\tv91 = new System.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>();\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::.ctor(v91);\n\tv79 = new EasyMobile.iOSInfoPlistItem();\n\tEasyMobile.iOSInfoPlistItem::.ctor(v79, \"NSPhotoLibraryUsageDescription\");\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::Add(v91, v79);\n\tv127 = new EasyMobile.iOSInfoPlistItem();\n\tEasyMobile.iOSInfoPlistItem::.ctor(v127, \"NSPhotoLibraryAddUsageDescription\");\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::Add(v91, v127);\n\tthis.mIOSInfoPlistItems = v91;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SharingSettings()
		{
			List<AndroidPermission> list = new List<AndroidPermission>();
			AndroidPermission item = new AndroidPermission("uses-permission", "android.permission.WRITE_EXTERNAL_STORAGE");
			list.Add(item);
			mAndroidPermissions = list;
			List<iOSInfoPlistItem> list2 = new List<iOSInfoPlistItem>();
			iOSInfoPlistItem item2 = new iOSInfoPlistItem("NSPhotoLibraryUsageDescription");
			list2.Add(item2);
			iOSInfoPlistItem item3 = new iOSInfoPlistItem("NSPhotoLibraryAddUsageDescription");
			list2.Add(item3);
			mIOSInfoPlistItems = list2;
		}
	}
}

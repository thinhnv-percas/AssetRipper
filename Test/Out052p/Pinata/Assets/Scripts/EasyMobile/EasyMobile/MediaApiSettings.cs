using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200006B")]
	public class MediaApiSettings : IAndroidPermissionRequired, IIOSInfoItemRequired
	{
		[SerializeField]
		[Token(Token = "0x4000281")]
		[FieldOffset(Offset = "0x10")]
		private List<AndroidPermission> mAndroidPermissions;

		[SerializeField]
		[Token(Token = "0x4000282")]
		[FieldOffset(Offset = "0x18")]
		private List<iOSInfoPlistItem> mIOSInfoPlistKeys;

		[Token(Token = "0x6000513")]
		[Address(RVA = "0xFCBA0C", Offset = "0xFCBA0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAndroidPermissions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<AndroidPermission> GetAndroidPermissions()
		{
			return mAndroidPermissions;
		}

		[Token(Token = "0x6000514")]
		[Address(RVA = "0xFCBA14", Offset = "0xFCBA14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIOSInfoPlistKeys;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<iOSInfoPlistItem> GetIOSInfoPlistKeys()
		{
			return mIOSInfoPlistKeys;
		}

		[Token(Token = "0x6000515")]
		[Address(RVA = "0xFCBA1C", Offset = "0xFCBA1C", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EBA718]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025645]) = v44;\nL_0019:\n\tv48 = new System.Collections.Generic.List`1<EasyMobile.AndroidPermission>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::.ctor(v48);\n\tv56 = new EasyMobile.AndroidPermission();\n\tEasyMobile.AndroidPermission::.ctor(v56, \"uses-permission\", \"android.permission.WRITE_EXTERNAL_STORAGE\");\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::Add(v48, v56);\n\tv95 = new EasyMobile.AndroidPermission();\n\tEasyMobile.AndroidPermission::.ctor(v95, \"uses-feature\", \"android.hardware.camera\");\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::Add(v48, v95);\n\tthis.mAndroidPermissions = v48;\n\tv132 = new System.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>();\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::.ctor(v132);\n\tv85 = new EasyMobile.iOSInfoPlistItem();\n\tEasyMobile.iOSInfoPlistItem::.ctor(v85, \"NSPhotoLibraryUsageDescription\");\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::Add(v132, v85);\n\tv145 = new EasyMobile.iOSInfoPlistItem();\n\tEasyMobile.iOSInfoPlistItem::.ctor(v145, \"NSPhotoLibraryAddUsageDescription\");\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::Add(v132, v145);\n\tv154 = new EasyMobile.iOSInfoPlistItem();\n\tEasyMobile.iOSInfoPlistItem::.ctor(v154, \"NSCameraUsageDescription\");\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::Add(v132, v154);\n\tv163 = new EasyMobile.iOSInfoPlistItem();\n\tEasyMobile.iOSInfoPlistItem::.ctor(v163, \"NSMicrophoneUsageDescription\");\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::Add(v132, v163);\n\tthis.mIOSInfoPlistKeys = v132;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MediaApiSettings()
		{
			List<AndroidPermission> list = new List<AndroidPermission>();
			AndroidPermission item = new AndroidPermission("uses-permission", "android.permission.WRITE_EXTERNAL_STORAGE");
			list.Add(item);
			AndroidPermission item2 = new AndroidPermission("uses-feature", "android.hardware.camera");
			list.Add(item2);
			mAndroidPermissions = list;
			List<iOSInfoPlistItem> list2 = new List<iOSInfoPlistItem>();
			iOSInfoPlistItem item3 = new iOSInfoPlistItem("NSPhotoLibraryUsageDescription");
			list2.Add(item3);
			iOSInfoPlistItem item4 = new iOSInfoPlistItem("NSPhotoLibraryAddUsageDescription");
			list2.Add(item4);
			iOSInfoPlistItem item5 = new iOSInfoPlistItem("NSCameraUsageDescription");
			list2.Add(item5);
			iOSInfoPlistItem item6 = new iOSInfoPlistItem("NSMicrophoneUsageDescription");
			list2.Add(item6);
			mIOSInfoPlistKeys = list2;
		}
	}
}

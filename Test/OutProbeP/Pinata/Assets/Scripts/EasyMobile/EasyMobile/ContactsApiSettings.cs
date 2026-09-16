using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000064")]
	public class ContactsApiSettings : IAndroidPermissionRequired, IIOSInfoItemRequired
	{
		[SerializeField]
		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0x10")]
		private List<AndroidPermission> mAndroidPermissions;

		[SerializeField]
		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0x18")]
		private List<iOSInfoPlistItem> mIOSInfoPlistKeys;

		[Token(Token = "0x60004FD")]
		[Address(RVA = "0xA54C88", Offset = "0xA54C88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAndroidPermissions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<AndroidPermission> GetAndroidPermissions()
		{
			return mAndroidPermissions;
		}

		[Token(Token = "0x60004FE")]
		[Address(RVA = "0xA54C90", Offset = "0xA54C90", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIOSInfoPlistKeys;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<iOSInfoPlistItem> GetIOSInfoPlistKeys()
		{
			return mIOSInfoPlistKeys;
		}

		[Token(Token = "0x60004FF")]
		[Address(RVA = "0xA54C98", Offset = "0xA54C98", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EE04B8]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021F9E]) = v46;\nL_001A:\n\tv50 = new System.Collections.Generic.List`1<EasyMobile.AndroidPermission>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::.ctor(v50);\n\tv58 = new EasyMobile.AndroidPermission();\n\tEasyMobile.AndroidPermission::.ctor(v58, \"uses-permission\", \"android.permission.WRITE_CONTACTS\");\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::Add(v50, v58);\n\tv90 = new EasyMobile.AndroidPermission();\n\tEasyMobile.AndroidPermission::.ctor(v90, \"uses-permission\", \"android.permission.READ_CONTACTS\");\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::Add(v50, v90);\n\tthis.mAndroidPermissions = v50;\n\tv127 = new System.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>();\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::.ctor(v127);\n\tv80 = new EasyMobile.iOSInfoPlistItem();\n\tEasyMobile.iOSInfoPlistItem::.ctor(v80, \"NSContactsUsageDescription\");\n\tSystem.Collections.Generic.List`1<EasyMobile.iOSInfoPlistItem>::Add(v127, v80);\n\tthis.mIOSInfoPlistKeys = v127;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ContactsApiSettings()
		{
			List<AndroidPermission> list = new List<AndroidPermission>();
			AndroidPermission item = new AndroidPermission("uses-permission", "android.permission.WRITE_CONTACTS");
			list.Add(item);
			AndroidPermission item2 = new AndroidPermission("uses-permission", "android.permission.READ_CONTACTS");
			list.Add(item2);
			mAndroidPermissions = list;
			List<iOSInfoPlistItem> list2 = new List<iOSInfoPlistItem>();
			iOSInfoPlistItem item3 = new iOSInfoPlistItem("NSContactsUsageDescription");
			list2.Add(item3);
			mIOSInfoPlistKeys = list2;
		}
	}
}

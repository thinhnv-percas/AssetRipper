using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000009")]
	public class AndroidPermission
	{
		[Token(Token = "0x400005A")]
		public const string AndroidPermissionElementName = "uses-permission";

		[Token(Token = "0x400005B")]
		public const string AndroidFeatureElementName = "uses-feature";

		[Token(Token = "0x400005C")]
		public const string AndroidPermissionWriteExternalStorage = "android.permission.WRITE_EXTERNAL_STORAGE";

		[Token(Token = "0x400005D")]
		public const string AndroidPermissionReadContacts = "android.permission.READ_CONTACTS";

		[Token(Token = "0x400005E")]
		public const string AndroidPermissionWriteContacts = "android.permission.WRITE_CONTACTS";

		[Token(Token = "0x400005F")]
		public const string AndroidPermissionReceiveBootCompleted = "android.permission.RECEIVE_BOOT_COMPLETED";

		[Token(Token = "0x4000060")]
		public const string AndroidHardwareCamera = "android.hardware.camera";

		[SerializeField]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x10")]
		private string mElementName;

		[SerializeField]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x18")]
		private string mValue;

		[Token(Token = "0x17000001")]
		public string ElementName
		{
			[Token(Token = "0x6000038")]
			[Address(RVA = "0xA4D868", Offset = "0xA4D868", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mElementName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ElementName;
			}
			[Token(Token = "0x6000039")]
			[Address(RVA = "0xA4D870", Offset = "0xA4D870", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mElementName = value;\n\treturn;\n")]
			set
			{
				ElementName = value;
			}
		}

		[Token(Token = "0x17000002")]
		public string Value
		{
			[Token(Token = "0x600003A")]
			[Address(RVA = "0xA4D878", Offset = "0xA4D878", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Value;
			}
			[Token(Token = "0x600003B")]
			[Address(RVA = "0xA4D880", Offset = "0xA4D880", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mValue = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0xA4D7F8", Offset = "0xA4D7F8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EE75C8]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, elementName, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021F2D]) = v44;\nL_001C:\n\tthis.mValue = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.mElementName = elementName;\n\tthis.mValue = value;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidPermission(string elementName, string value)
		{
			Value = "";
			ElementName = elementName;
			Value = value;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0xA4D888", Offset = "0xA4D888", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC8AA8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F2E]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_0058;\n\tgoto L_FFFFFFFF;\n\tv65 = v65_asT == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv70 = v70_asT == 0;\n\tif (v70) goto L_0058;\n\tv104 = System.String::op_Equality(this.mElementName, *([v108 @ X20_v4 (System.Object)+10]));\n\tv106 = v104 == 0;\n\tif (v106) goto L_0058;\n\treturnVal3 = System.String::op_Equality(this.mValue, *([v108 @ X20_v4 (System.Object)+18]));\n\treturn returnVal3;\nL_0058:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_0062: Expected O, but got I
			//IL_009a: Expected O, but got I
			if (obj != null)
			{
				AndroidPermission androidPermission = obj as AndroidPermission;
				if (androidPermission != null)
				{
					object obj2 = obj;
				}
				else
				{
					object obj2 = null;
				}
				AndroidPermission androidPermission2 = obj as AndroidPermission;
				if (androidPermission2 != null)
				{
					string elementName = ElementName;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X20_v4 (System.Object)+10]");
					if (elementName == (string)0)
					{
						string value = Value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X20_v4 (System.Object)+18]");
						return value == (string)0;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0xA4D950", Offset = "0xA4D950", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.mElementName == 0;\n\tif (v14) goto L_0012;\n\tv18 = System.String::GetHashCode(this.mElementName);\n\tv34 = v18 * 0x17;\n\tv43 = 0x2321 + v34;\nL_0012:\n\tv54 = this.mValue;\n\tv46 = this.mValue == 0;\n\tif (v46) goto L_001B;\n\tv50 = System.String::GetHashCode(this.mValue);\nL_001B:\n\treturnVal1 = v54 + v43;\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_006f: Expected O, but got I4
			bool flag = ElementName == null;
			int num = 8993;
			if (!flag)
			{
				int hashCode = ElementName.GetHashCode();
				int num2 = hashCode * 23;
				num = 8993 + num2;
			}
			string text = Value;
			if (Value != null)
			{
				int hashCode2 = Value.GetHashCode();
				text = (string)hashCode2;
			}
			return (int)((long)(IntPtr)text + (long)num);
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0xA4D9A4", Offset = "0xA4D9A4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EF3448]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F2F]) = v38;\nL_001E:\n\treturnVal1 = System.String::Format(\"[AndroidPermission: ElementName={0}, Value={1}]\", this.mElementName, this.mValue);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return $"[AndroidPermission: ElementName={ElementName}, Value={Value}]";
		}
	}
}

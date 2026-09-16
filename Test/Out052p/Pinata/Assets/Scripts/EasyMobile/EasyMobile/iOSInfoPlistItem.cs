using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public class iOSInfoPlistItem
	{
		[Token(Token = "0x4000075")]
		public const string NSPhotoLibraryUsageDescription = "NSPhotoLibraryUsageDescription";

		[Token(Token = "0x4000076")]
		public const string NSPhotoLibraryAddUsageDescription = "NSPhotoLibraryAddUsageDescription";

		[Token(Token = "0x4000077")]
		public const string NSCameraUsageDescription = "NSCameraUsageDescription";

		[Token(Token = "0x4000078")]
		public const string NSMicrophoneUsageDescription = "NSMicrophoneUsageDescription";

		[Token(Token = "0x4000079")]
		public const string NSContactsUsageDescription = "NSContactsUsageDescription";

		[Token(Token = "0x400007A")]
		public const string DefaultUsageDescription = "[Your usage description]";

		[SerializeField]
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x10")]
		private string mKey;

		[SerializeField]
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x18")]
		private string mValue;

		[Token(Token = "0x17000014")]
		public string Key
		{
			[Token(Token = "0x6000068")]
			[Address(RVA = "0xFD7234", Offset = "0xFD7234", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mKey;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Key;
			}
		}

		[Token(Token = "0x17000015")]
		public string Value
		{
			[Token(Token = "0x6000069")]
			[Address(RVA = "0xFD723C", Offset = "0xFD723C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Value;
			}
			[Token(Token = "0x600006A")]
			[Address(RVA = "0xFD7244", Offset = "0xFD7244", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mValue = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0xFD71C4", Offset = "0xFD71C4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EC0F40]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, key, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20256F4]) = v44;\nL_001C:\n\tthis.mValue = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.mKey = key;\n\tthis.mValue = value;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public iOSInfoPlistItem(string key, string value)
		{
			Value = "";
			mKey = key;
			Value = value;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0xFCBC1C", Offset = "0xFCBC1C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB9D80]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, key, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256F5]) = v41;\nL_001A:\n\tthis.mValue = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.mKey = key;\n\tthis.mValue = \"[Your usage description]\";\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public iOSInfoPlistItem(string key)
		{
			Value = "";
			mKey = key;
			Value = "[Your usage description]";
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0xFD724C", Offset = "0xFD724C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB3750]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256F6]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_0058;\n\tgoto L_FFFFFFFF;\n\tv65 = v65_asT == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv70 = v70_asT == 0;\n\tif (v70) goto L_0058;\n\tv104 = System.String::op_Equality(this.mKey, *([v108 @ X20_v4 (System.Object)+10]));\n\tv106 = v104 == 0;\n\tif (v106) goto L_0058;\n\treturnVal3 = System.String::op_Equality(this.mValue, *([v108 @ X20_v4 (System.Object)+18]));\n\treturn returnVal3;\nL_0058:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_0062: Expected O, but got I
			//IL_009a: Expected O, but got I
			if (obj != null)
			{
				iOSInfoPlistItem iOSInfoPlistItem2 = obj as iOSInfoPlistItem;
				if (iOSInfoPlistItem2 != null)
				{
					object obj2 = obj;
				}
				else
				{
					object obj2 = null;
				}
				iOSInfoPlistItem iOSInfoPlistItem3 = obj as iOSInfoPlistItem;
				if (iOSInfoPlistItem3 != null)
				{
					string key = Key;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X20_v4 (System.Object)+10]");
					if (key == (string)0)
					{
						string value = Value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X20_v4 (System.Object)+18]");
						return value == (string)0;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0xFD7314", Offset = "0xFD7314", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.mKey == 0;\n\tif (v14) goto L_0012;\n\tv18 = System.String::GetHashCode(this.mKey);\n\tv34 = v18 * 0x17;\n\tv43 = 0x2321 + v34;\nL_0012:\n\tv54 = this.mValue;\n\tv46 = this.mValue == 0;\n\tif (v46) goto L_001B;\n\tv50 = System.String::GetHashCode(this.mValue);\nL_001B:\n\treturnVal1 = v54 + v43;\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_006f: Expected O, but got I4
			bool flag = Key == null;
			int num = 8993;
			if (!flag)
			{
				int hashCode = Key.GetHashCode();
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

		[Token(Token = "0x600006D")]
		[Address(RVA = "0xFD7368", Offset = "0xFD7368", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EE9FE8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256F7]) = v38;\nL_001E:\n\treturnVal1 = System.String::Format(\"[iOSInfoPlistItem: Key={0}, Value={1}]\", this.mKey, this.mValue);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return $"[iOSInfoPlistItem: Key={Key}, Value={Value}]";
		}
	}
}

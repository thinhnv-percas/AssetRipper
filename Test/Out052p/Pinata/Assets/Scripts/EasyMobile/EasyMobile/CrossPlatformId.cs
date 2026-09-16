using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200000B")]
	public class CrossPlatformId
	{
		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x731EF4", Offset = "0x731EF4")]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x10")]
		protected internal string mIosId;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RenameAttribute), RVA = "0x731F40", Offset = "0x731F40")]
		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x18")]
		protected internal string mAndroidId;

		[Token(Token = "0x17000004")]
		public virtual string Id
		{
			[Token(Token = "0x6000049")]
			[Address(RVA = "0xA54E08", Offset = "0xA54E08", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[6];\n\tv3 = this->klass->vtable[6];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (EasyMobile.CrossPlatformId), this @ X0 (EasyMobile.CrossPlatformId), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn X0;\n")]
			get
			{
				//IL_0005: Expected I, but got O
				//IL_0015: Expected O, but got I
				//IL_0025: Expected O, but got I
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<EasyMobile.CrossPlatformId>)+190]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<EasyMobile.CrossPlatformId>)+198]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x17000005")]
		public virtual string IosId
		{
			[Token(Token = "0x600004A")]
			[Address(RVA = "0xA54E14", Offset = "0xA54E14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIosId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IosId;
			}
		}

		[Token(Token = "0x17000006")]
		public virtual string AndroidId
		{
			[Token(Token = "0x600004B")]
			[Address(RVA = "0xA54E1C", Offset = "0xA54E1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAndroidId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AndroidId;
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0xA4569C", Offset = "0xA4569C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mIosId = iOSId;\n\tthis.mAndroidId = androidId;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CrossPlatformId(string iOSId, string androidId)
		{
			mIosId = iOSId;
			mAndroidId = androidId;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0xA54E24", Offset = "0xA54E24", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[4];\n\tv3 = this->klass->vtable[4];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (EasyMobile.CrossPlatformId), this @ X0 (EasyMobile.CrossPlatformId), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn X0;\n")]
		public override string ToString()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<EasyMobile.CrossPlatformId>)+170]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<EasyMobile.CrossPlatformId>)+178]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0xA54E30", Offset = "0xA54E30", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF40F8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F9F]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_0047;\n\tgoto L_FFFFFFFF;\n\tv67 = v67_asT == 0;\n\tif (v67) goto L_0047;\n\tv106 = obj->klass;\n\tv102 = System.Object::Equals(obj, 0);\n\tv104 = v102 == 0;\n\tif (v104) goto L_004C;\nL_0047:\n\treturn 0;\nL_004C:\n\tv158 = EasyMobile.CrossPlatformId::get_Id(this);\n\tv147 = obj->klass;\n\t*([v147 @ X8_v9 (Il2CppClass<System.Object>)+170])(v161, obj, *([v147 @ X8_v9 (Il2CppClass<System.Object>)+178]), *([v106 @ X8_v7 (Il2CppClass<System.Object>)+138]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = System.String::Equals(v158, v161);\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_003c: Expected I, but got O
			//IL_007f: Expected I, but got O
			if (obj != null)
			{
				CrossPlatformId crossPlatformId = obj as CrossPlatformId;
				if ((object)crossPlatformId != null)
				{
					IntPtr intPtr = (IntPtr)obj;
					if (!obj.Equals(null))
					{
						string id = Id;
						IntPtr intPtr2 = (IntPtr)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v147 @ X8_v9 (Il2CppClass<System.Object>)+170] (should have been resolved before IL gen)");
						string value = default(string);
						return id.Equals(value);
					}
				}
			}
			return false;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0xA54F38", Offset = "0xA54F38", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.CrossPlatformId::get_Id(this);\n\tv26 = *([v10 @ X0_v1 (System.String)]);\n\tv27 = *([v26 @ X8_v2 (Il2CppClass<System.String>)+150]);\n\tv28 = *([v26 @ X8_v2 (Il2CppClass<System.String>)+158]);\n\t// 16 IndirectJump v27 @ X2_v1, v10 @ X0_v1 (System.String), v10 @ X0_v1 (System.String), v28 @ X1_v2, v27 @ X2_v1, v12 @ X3, v13 @ X4, v14 @ X5, v15 @ X6, v16 @ X7, v17 @ V0, v18 @ V1, v19 @ V2, v20 @ V3, v21 @ V4, v22 @ V5, v23 @ V6, v24 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_0017: Expected I, but got O
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			string id = Id;
			IntPtr intPtr = (IntPtr)id;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X8_v2 (Il2CppClass<System.String>)+150]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X8_v2 (Il2CppClass<System.String>)+158]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v27 @ X2_v1 (should have been resolved before IL gen)");
			return 0;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0xA54F1C", Offset = "0xA54F1C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = a == 0;\n\tif (v0) goto L_000A;\n\tv2 = a->klass;\n\tv3 = a->klass->vtable[0];\n\tv4 = a->klass->vtable[0];\n\t// 5 IndirectJump v3 @ X3_v1, a @ X0 (EasyMobile.CrossPlatformId), a @ X0 (EasyMobile.CrossPlatformId), b @ X1 (EasyMobile.CrossPlatformId), v4 @ X2_v1, v3 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\nL_000A:\n\tv22 = b == 0;\n\treturn v22;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(CrossPlatformId a, CrossPlatformId b)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if ((object)a != null)
			{
				IntPtr intPtr = (IntPtr)a;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.CrossPlatformId>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.CrossPlatformId>)+138]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
			}
			return (object)b == null;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0xA44A28", Offset = "0xA44A28", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = a == 0;\n\tif (v0) goto L_0012;\n\tv55 = EasyMobile.CrossPlatformId::Equals(a, b);\n\tgoto L_0018;\nL_0012:\n\tv32 = b == 0;\nL_0018:\n\tv67 = ~v55;\n\treturn v67;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(CrossPlatformId a, CrossPlatformId b)
		{
			bool flag;
			if ((object)a != null)
			{
				flag = a.Equals(b);
			}
			else
			{
				bool flag2 = (object)b == null;
				flag = flag2;
			}
			return !flag;
		}
	}
}

using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000006")]
	public class JSONData : JSONNode
	{
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x10")]
		private string m_Data;

		[Token(Token = "0x17000015")]
		public override string Value
		{
			[Token(Token = "0x600004C")]
			[Address(RVA = "0x1572D50", Offset = "0x1572D50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Value;
			}
			[Token(Token = "0x600004D")]
			[Address(RVA = "0x1572D58", Offset = "0x1572D58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Data = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x156FAB4", Offset = "0x156FAB4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_Data = aData;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONData(string aData)
		{
			Value = aData;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x1572D60", Offset = "0x1572D60", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = this->klass;\n\tv20 = this->klass->vtable[21];\n\tv21 = this->klass->vtable[21];\n\t// 20 IndirectJump v20 @ X2_v1, this @ X0 (com.adjust.sdk.JSONData), this @ X0 (com.adjust.sdk.JSONData), v21 @ X1_v2, v20 @ X2_v1, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, aData @ V0 (System.Single), v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONData(float aData)
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+280]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+288]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v20 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x1572DA4", Offset = "0x1572DA4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = this->klass;\n\tv20 = this->klass->vtable[23];\n\tv21 = this->klass->vtable[23];\n\t// 20 IndirectJump v20 @ X2_v1, this @ X0 (com.adjust.sdk.JSONData), this @ X0 (com.adjust.sdk.JSONData), v21 @ X1_v2, v20 @ X2_v1, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, aData @ V0 (System.Double), v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONData(double aData)
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+2A0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+2A8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v20 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x1572DE8", Offset = "0x1572DE8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = this->klass;\n\tv20 = this->klass->vtable[25];\n\tv21 = this->klass->vtable[25];\n\t// 20 IndirectJump v20 @ X3_v1, this @ X0 (com.adjust.sdk.JSONData), this @ X0 (com.adjust.sdk.JSONData), aData @ X1 (System.Boolean), v21 @ X2_v1, v20 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONData(bool aData)
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+2C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+2C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v20 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x1572E24", Offset = "0x1572E24", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = this->klass;\n\tv20 = this->klass->vtable[19];\n\tv21 = this->klass->vtable[19];\n\t// 20 IndirectJump v20 @ X3_v1, this @ X0 (com.adjust.sdk.JSONData), this @ X0 (com.adjust.sdk.JSONData), aData @ X1 (System.Int32), v21 @ X2_v1, v20 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONData(int aData)
		{
			//IL_000b: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_002b: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+260]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v1 (Il2CppClass<com.adjust.sdk.JSONData>)+268]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v20 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x1572E60", Offset = "0x1572E60", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB44C0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029109]) = v38;\nL_0014:\n\tv40 = com.adjust.sdk.JSONNode::Escape(this.m_Data);\n\treturnVal1 = System.String::Concat(\"\\\"\", v40, \"\\\"\");\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string text = JSONNode.Escape(Value);
			return "\"" + text + "\"";
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x1572EC4", Offset = "0x1572EC4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB6878]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, aPrefix, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202910A]) = v38;\nL_0014:\n\tv40 = com.adjust.sdk.JSONNode::Escape(this.m_Data);\n\treturnVal1 = System.String::Concat(\"\\\"\", v40, \"\\\"\");\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString(string aPrefix)
		{
			string text = JSONNode.Escape(Value);
			return "\"" + text + "\"";
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x1572F28", Offset = "0x1572F28", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EAEFA8]);\n\tv25 = *([v24 @ X8_v32]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, aWriter, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202910B]) = v43;\nL_0019:\n\tv47 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v47);\n\tv47.m_Data = \"\";\n\tv57 = com.adjust.sdk.JSONNode::get_AsInt(this);\n\tv64 = com.adjust.sdk.JSONNode::set_AsInt(v47, v57);\n\tv68 = System.String::op_Equality(v47.m_Data, this.m_Data);\n\tv97 = v68 == 0;\n\tif (v97) goto L_0053;\n\tv173 = System.IO.BinaryWriter::Write(aWriter, 4);\n\tv178 = com.adjust.sdk.JSONNode::get_AsInt(this);\n\tv179 = aWriter->klass;\n\tv113 = aWriter->klass->vtable[16];\n\tv116 = aWriter->klass->vtable[16];\nL_004E:\n\t// 78 IndirectJump v113 @ X3_v1, aWriter @ X1 (System.IO.BinaryWriter), aWriter @ X1 (System.IO.BinaryWriter), v131 @ X1_v6 (System.Int32), v116 @ X2_v4, v113 @ X3_v1, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0 (System.Single), v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0053:\n\tv102 = com.adjust.sdk.JSONNode::get_AsFloat(this);\n\tv105 = com.adjust.sdk.JSONNode::set_AsFloat(v47, v33);\n\tv82 = System.String::op_Equality(v47.m_Data, this.m_Data);\n\tv184 = v82 == 0;\n\tif (v184) goto L_007D;\n\tv206 = System.IO.BinaryWriter::Write(aWriter, 7);\n\tv210 = com.adjust.sdk.JSONNode::get_AsFloat(this);\n\tv155 = aWriter->klass;\n\tv117 = aWriter->klass->vtable[20];\n\tv132 = aWriter->klass->vtable[20];\n\t// 120 IndirectJump v117 @ X2_v15, aWriter @ X1 (System.IO.BinaryWriter), aWriter @ X1 (System.IO.BinaryWriter), v132 @ X1_v26, v117 @ X2_v15, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0 (System.Single), v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_007D:\n\tv196 = com.adjust.sdk.JSONNode::get_AsDouble(this);\n\tv199 = com.adjust.sdk.JSONNode::set_AsDouble(v47, v33);\n\tv83 = System.String::op_Equality(v47.m_Data, this.m_Data);\n\tv212 = v83 == 0;\n\tif (v212) goto L_00A7;\n\tv228 = System.IO.BinaryWriter::Write(aWriter, 5);\n\tv232 = com.adjust.sdk.JSONNode::get_AsDouble(this);\n\tv156 = aWriter->klass;\n\tv118 = aWriter->klass->vtable[13];\n\tv133 = aWriter->klass->vtable[13];\n\t// 162 IndirectJump v118 @ X2_v13, aWriter @ X1 (System.IO.BinaryWriter), aWriter @ X1 (System.IO.BinaryWriter), v133 @ X1_v23, v118 @ X2_v13, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0 (System.Single), v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_00A7:\n\tv217 = com.adjust.sdk.JSONNode::get_AsBool(this);\n\tv221 = com.adjust.sdk.JSONNode::set_AsBool(v47, v217);\n\tv84 = System.String::op_Equality(v47.m_Data, this.m_Data);\n\tv142 = v84 == 0;\n\tif (v142) goto L_00C9;\n\tv238 = System.IO.BinaryWriter::Write(aWriter, 6);\n\tv190 = com.adjust.sdk.JSONNode::get_AsBool(this);\n\tv191 = aWriter->klass;\n\tv113 = aWriter->klass->vtable[7];\n\tv116 = aWriter->klass->vtable[7];\n\tgoto L_004E;\nL_00C9:\n\tv244 = System.IO.BinaryWriter::Write(aWriter, 3);\n\tv157 = aWriter->klass;\n\tv134 = this.m_Data;\n\tv114 = aWriter->klass->vtable[21];\n\tv119 = aWriter->klass->vtable[21];\n\t// 214 IndirectJump v114 @ X3_v2, aWriter @ X1 (System.IO.BinaryWriter), aWriter @ X1 (System.IO.BinaryWriter), v134 @ X1_v17 (System.String), v119 @ X2_v10, v114 @ X3_v2, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0 (System.Single), v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 157 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Serialize(BinaryWriter aWriter)
		{
			//IL_0067: Expected I, but got O
			//IL_0077: Expected O, but got I
			//IL_0087: Expected O, but got I
			//IL_00f8: Expected I, but got O
			//IL_0108: Expected O, but got I
			//IL_0118: Expected O, but got I
			//IL_018e: Expected I, but got O
			//IL_019e: Expected O, but got I
			//IL_01ae: Expected O, but got I
			//IL_0264: Expected I, but got O
			//IL_027e: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_0229: Expected I, but got O
			//IL_0239: Expected O, but got I
			//IL_0249: Expected O, but got I
			float num = default(float);
			while (true)
			{
				JSONData jSONData = null;
				jSONData.Value = "";
				int asInt = base.AsInt;
				jSONData.AsInt = asInt;
				if (jSONData.Value == Value)
				{
					aWriter.Write((byte)4);
					int asInt2 = base.AsInt;
					IntPtr intPtr = (IntPtr)aWriter;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X8_v29 (Il2CppClass<System.IO.BinaryWriter>)+230]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X8_v29 (Il2CppClass<System.IO.BinaryWriter>)+238]");
					object obj2 = 0;
					break;
				}
				float asFloat = base.AsFloat;
				jSONData.AsFloat = num;
				if (jSONData.Value == Value)
				{
					aWriter.Write((byte)7);
					float asFloat2 = base.AsFloat;
					IntPtr intPtr2 = (IntPtr)aWriter;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v26 (Il2CppClass<System.IO.BinaryWriter>)+270]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v26 (Il2CppClass<System.IO.BinaryWriter>)+278]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X2_v15 (should have been resolved before IL gen)");
				}
				double asDouble = base.AsDouble;
				jSONData.AsDouble = num;
				if (jSONData.Value == Value)
				{
					aWriter.Write((byte)5);
					double asDouble2 = base.AsDouble;
					IntPtr intPtr3 = (IntPtr)aWriter;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v23 (Il2CppClass<System.IO.BinaryWriter>)+200]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v23 (Il2CppClass<System.IO.BinaryWriter>)+208]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v118 @ X2_v13 (should have been resolved before IL gen)");
				}
				bool asBool = base.AsBool;
				jSONData.AsBool = asBool;
				if (jSONData.Value == Value)
				{
					aWriter.Write((byte)6);
					bool asBool2 = base.AsBool;
					IntPtr intPtr4 = (IntPtr)aWriter;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v20 (Il2CppClass<System.IO.BinaryWriter>)+1A0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v20 (Il2CppClass<System.IO.BinaryWriter>)+1A8]");
					object obj2 = 0;
					break;
				}
				aWriter.Write((byte)3);
				IntPtr intPtr5 = (IntPtr)aWriter;
				string value = Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v18 (Il2CppClass<System.IO.BinaryWriter>)+280]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v18 (Il2CppClass<System.IO.BinaryWriter>)+288]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v114 @ X3_v2 (should have been resolved before IL gen)");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ X3_v1 (should have been resolved before IL gen)");
		}
	}
}

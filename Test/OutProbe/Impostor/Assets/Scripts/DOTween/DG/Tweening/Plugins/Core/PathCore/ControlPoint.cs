using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Serializable]
	[Token(Token = "0x200009A")]
	public struct ControlPoint
	{
		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x0")]
		public Vector3 a;

		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0xC")]
		public Vector3 b;

		[Token(Token = "0x6000390")]
		[Address(RVA = "0xC28B58", Offset = "0xC28B58", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.a = a;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+4]) = a.y;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+8]) = a.z;\n\tthis.b = b;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]) = b.y;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+14]) = b.z;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ControlPoint(Vector3 a, Vector3 b)
		{
			this.a = a;
			_ = a.y;
			_ = a.z;
			this.b = b;
			_ = b.y;
			_ = b.z;
		}

		[Token(Token = "0x6000391")]
		[Address(RVA = "0xC292C4", Offset = "0xC292C4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = v + cp.a;\n\tv15 = v.z + *([cp @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+8]);\n\tv16 = v.y + *([cp @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]);\n\treturnBuffer.a = v14;\n\t*([returnBuffer @ X8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+8]) = v15;\n\t*([returnBuffer @ X8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]) = v16;\n\treturn cp;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ControlPoint operator +(ControlPoint cp, Vector3 v)
		{
			//IL_0063: Expected O, but got F4
			//IL_005e: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float num = vector.x + cp.a.x;
			float num2 = v.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cp @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+8]");
			float num3 = num2 + 0f;
			float num4 = v.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cp @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]");
			float num5 = num4 + 0f;
			ControlPoint controlPoint = default(ControlPoint);
			((ControlPoint*)(nint)controlPoint)->a = (Vector3)num;
			return cp;
		}

		[Token(Token = "0x6000392")]
		[Address(RVA = "0xC292F4", Offset = "0xC292F4", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv18 = System.String[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = \" | \";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = \"[\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv93 = \"]\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A357A5]) = v38;\n\t// 30 NewArr v41 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv41[0] = \"[\";\nL_002D:\n\tv101 = 0xBEEA54(this, 0, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv41[1] = v101;\n\tv174 = this + 0xC;\n\tv41[2] = \" | \";\n\tv140 = 0xBEEA54(v174, 0, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv41[3] = v140;\n\tv41[4] = \"]\";\n\treturnVal2 = System.String::Concat(v41);\n\treturn returnVal2;\n\tv86 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override string ToString()
		{
			//IL_0024: Expected O, but got Ref
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEEA54 (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x540)");
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 12));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BEEA54 (inside CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::OnError +0x540)");
			object obj2 = default(object);
			object obj3 = default(object);
			return "[" + (string)obj2 + " | " + (string)obj3 + "]";
		}
	}
}

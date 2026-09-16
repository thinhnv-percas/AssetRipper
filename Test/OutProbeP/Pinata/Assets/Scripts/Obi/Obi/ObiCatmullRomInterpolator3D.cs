using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000073")]
	public class ObiCatmullRomInterpolator3D : ObiInterpolator<Vector3>
	{
		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x10")]
		private ObiCatmullRomInterpolator interpolator;

		[Token(Token = "0x6000487")]
		[Address(RVA = "0xE3FBF4", Offset = "0xE3FBF4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tv20 = *([v10 @ X29_v1+30]) * *([v10 @ X29_v1+30]);\n\tv22 = 1f - *([v10 @ X29_v1+30]);\n\tv23 = v20 * *([v10 @ X29_v1+30]);\n\tv27 = *([v10 @ X29_v1+20]) * v23;\n\tv28 = *([v10 @ X29_v1+24]) * v23;\n\tv29 = *([v10 @ X29_v1+28]) * v23;\n\tv30 = v22 * v22;\n\tv31 = v22 * 3f;\n\tv32 = v22 * v30;\n\tv33 = v22 * v31;\n\tv34 = v31 * *([v10 @ X29_v1+30]);\n\tv35 = v33 * *([v10 @ X29_v1+30]);\n\tv36 = y0 * v32;\n\tv37 = v34 * *([v10 @ X29_v1+30]);\n\tv38 = y0.y * v32;\n\tv39 = y0.z * v32;\n\tv40 = y1 * v35;\n\tv41 = y1.y * v35;\n\tv42 = y1.z * v35;\n\tv43 = *([v10 @ X29_v1+10]) * v37;\n\tv44 = *([v10 @ X29_v1+14]) * v37;\n\tv45 = *([v10 @ X29_v1+18]) * v37;\n\tv46 = v36 + v40;\n\tv47 = v38 + v41;\n\tv48 = v39 + v42;\n\tv49 = v43 + v46;\n\tv50 = v44 + v47;\n\tv51 = v45 + v48;\n\tv52 = v27 + v49;\n\tv53 = v28 + v50;\n\tv54 = v29 + v51;\n\tv56 = 0;\n\tv59 = 0x1586898(&v56 @ stack_-20_v1 (UnityEngine.Vector3), 0, v60, v61, v62, v63, v64, v65, v52, v53, v54, v40, v41, v42, v29, v28);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn y0;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 Evaluate(Vector3 y0, Vector3 y1, Vector3 y2, Vector3 y3, float mu)
		{
			//IL_002a: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_0084: Expected O, but got I
			//IL_009a: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			object obj3 = (long)intPtr * 0L;
			float num = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num2 = num - 0f;
			IntPtr intPtr2 = (IntPtr)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			object obj4 = (long)intPtr2 * 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+20]");
			object obj5 = 0L * (long)(IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+24]");
			object obj6 = 0L * (long)(IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+28]");
			object obj7 = 0L * (long)(IntPtr)obj4;
			float num3 = num2 * num2;
			float num4 = num2 * 3f;
			float num5 = num2 * num3;
			float num6 = num2 * num4;
			float num7 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num8 = num7 * 0f;
			float num9 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num10 = num9 * 0f;
			Vector3 vector = default(Vector3);
			float num11 = vector.x * num5;
			float num12 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num13 = num12 * 0f;
			float num14 = y0.y * num5;
			float num15 = y0.z * num5;
			Vector3 vector2 = default(Vector3);
			float num16 = vector2.x * num10;
			float num17 = y1.y * num10;
			float num18 = y1.z * num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+10]");
			float num19 = 0f * num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+14]");
			float num20 = 0f * num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+18]");
			float num21 = 0f * num13;
			float num22 = num11 + num16;
			float num23 = num14 + num17;
			float num24 = num15 + num18;
			float num25 = num19 + num22;
			float num26 = num20 + num23;
			float num27 = num21 + num24;
			float num28 = (float)obj5 + num25;
			float num29 = (float)obj6 + num26;
			float num30 = (float)obj7 + num27;
			Vector3 vector3 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x6000488")]
		[Address(RVA = "0xE3FCD0", Offset = "0xE3FCD0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tv25 = 1f - *([v10 @ X29_v1+30]);\n\tv26 = y1 - y0;\n\tv27 = y1.y - y0.y;\n\tv28 = *([v10 @ X29_v1+10]) - y1;\n\tv29 = *([v10 @ X29_v1+30]) * 3f;\n\tv30 = *([v10 @ X29_v1+20]) - *([v10 @ X29_v1+10]);\n\tv31 = *([v10 @ X29_v1+14]) - y1.y;\n\tv32 = *([v10 @ X29_v1+24]) - *([v10 @ X29_v1+14]);\n\tv33 = v25 * 3f;\n\tv34 = v25 * 6f;\n\tv35 = y1.z - y0.z;\n\tv36 = *([v10 @ X29_v1+18]) - y1.z;\n\tv37 = *([v10 @ X29_v1+28]) - *([v10 @ X29_v1+18]);\n\tv38 = v29 * *([v10 @ X29_v1+30]);\n\tv39 = v25 * v33;\n\tv40 = v34 * *([v10 @ X29_v1+30]);\n\tv41 = v26 * v39;\n\tv42 = v28 * v40;\n\tv43 = v27 * v39;\n\tv44 = v31 * v40;\n\tv45 = v35 * v39;\n\tv46 = v36 * v40;\n\tv47 = v30 * v38;\n\tv48 = v32 * v38;\n\tv49 = v37 * v38;\n\tv50 = v41 + v42;\n\tv51 = v43 + v44;\n\tv52 = v45 + v46;\n\tv53 = v47 + v50;\n\tv54 = v48 + v51;\n\tv55 = v49 + v52;\n\tv57 = 0;\n\tv60 = 0x1586898(&v57 @ stack_-20_v1 (UnityEngine.Vector3), 0, v61, v62, v63, v64, v65, v66, v53, v54, v55, v42, v44, v46, v49, v48);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn y0;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 EvaluateFirstDerivative(Vector3 y0, Vector3 y1, Vector3 y2, Vector3 y3, float mu)
		{
			//IL_00a8: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_0153: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			float num = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num2 = num - 0f;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num3 = vector.x - vector2.x;
			float num4 = y1.y - y0.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+10]");
			float num5 = 0f - vector.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num6 = 0f * 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+20]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+10]");
			object obj3 = (long)intPtr - 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+14]");
			float num7 = 0f - y1.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+24]");
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+14]");
			object obj4 = (long)intPtr2 - 0L;
			float num8 = num2 * 3f;
			float num9 = num2 * 6f;
			float num10 = y1.z - y0.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+18]");
			float num11 = 0f - y1.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+28]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+18]");
			object obj5 = (long)intPtr3 - 0L;
			float num12 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num13 = num12 * 0f;
			float num14 = num2 * num8;
			float num15 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num16 = num15 * 0f;
			float num17 = num3 * num14;
			float num18 = num5 * num16;
			float num19 = num4 * num14;
			float num20 = num7 * num16;
			float num21 = num10 * num14;
			float num22 = num11 * num16;
			float num23 = (float)obj3 * num13;
			float num24 = (float)obj4 * num13;
			float num25 = (float)obj5 * num13;
			float num26 = num17 + num18;
			float num27 = num19 + num20;
			float num28 = num21 + num22;
			float num29 = num23 + num26;
			float num30 = num24 + num27;
			float num31 = num25 + num28;
			Vector3 vector3 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x6000489")]
		[Address(RVA = "0xE3FDB0", Offset = "0xE3FDB0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tv25 = 1f - *([v10 @ X29_v1+30]);\n\tv26 = y1 - y0;\n\tv27 = y1.y - y0.y;\n\tv28 = *([v10 @ X29_v1+10]) - y1;\n\tv29 = *([v10 @ X29_v1+30]) * 3f;\n\tv30 = *([v10 @ X29_v1+20]) - *([v10 @ X29_v1+10]);\n\tv31 = *([v10 @ X29_v1+14]) - y1.y;\n\tv32 = *([v10 @ X29_v1+24]) - *([v10 @ X29_v1+14]);\n\tv33 = v25 * 3f;\n\tv34 = v25 * 6f;\n\tv35 = y1.z - y0.z;\n\tv36 = *([v10 @ X29_v1+18]) - y1.z;\n\tv37 = *([v10 @ X29_v1+28]) - *([v10 @ X29_v1+18]);\n\tv38 = v29 * *([v10 @ X29_v1+30]);\n\tv39 = v25 * v33;\n\tv40 = v34 * *([v10 @ X29_v1+30]);\n\tv41 = v26 * v39;\n\tv42 = v28 * v40;\n\tv43 = v27 * v39;\n\tv44 = v31 * v40;\n\tv45 = v35 * v39;\n\tv46 = v36 * v40;\n\tv47 = v30 * v38;\n\tv48 = v32 * v38;\n\tv49 = v37 * v38;\n\tv50 = v41 + v42;\n\tv51 = v43 + v44;\n\tv52 = v45 + v46;\n\tv53 = v47 + v50;\n\tv54 = v48 + v51;\n\tv55 = v49 + v52;\n\tv57 = 0;\n\tv60 = 0x1586898(&v57 @ stack_-20_v1 (UnityEngine.Vector3), 0, v61, v62, v63, v64, v65, v66, v53, v54, v55, v42, v44, v46, v49, v48);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn y0;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 EvaluateSecondDerivative(Vector3 y0, Vector3 y1, Vector3 y2, Vector3 y3, float mu)
		{
			//IL_00a8: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_0153: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			float num = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num2 = num - 0f;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num3 = vector.x - vector2.x;
			float num4 = y1.y - y0.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+10]");
			float num5 = 0f - vector.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num6 = 0f * 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+20]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+10]");
			object obj3 = (long)intPtr - 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+14]");
			float num7 = 0f - y1.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+24]");
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+14]");
			object obj4 = (long)intPtr2 - 0L;
			float num8 = num2 * 3f;
			float num9 = num2 * 6f;
			float num10 = y1.z - y0.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+18]");
			float num11 = 0f - y1.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+28]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+18]");
			object obj5 = (long)intPtr3 - 0L;
			float num12 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num13 = num12 * 0f;
			float num14 = num2 * num8;
			float num15 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1+30]");
			float num16 = num15 * 0f;
			float num17 = num3 * num14;
			float num18 = num5 * num16;
			float num19 = num4 * num14;
			float num20 = num7 * num16;
			float num21 = num10 * num14;
			float num22 = num11 * num16;
			float num23 = (float)obj3 * num13;
			float num24 = (float)obj4 * num13;
			float num25 = (float)obj5 * num13;
			float num26 = num17 + num18;
			float num27 = num19 + num20;
			float num28 = num21 + num22;
			float num29 = num23 + num26;
			float num30 = num24 + num27;
			float num31 = num25 + num28;
			Vector3 vector3 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x600048A")]
		[Address(RVA = "0xE3FE90", Offset = "0xE3FE90", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0CC68]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024709]) = v38;\nL_0016:\n\tv42 = new Obi.ObiCatmullRomInterpolator();\n\tSystem.Object::.ctor(v42);\n\tthis.interpolator = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCatmullRomInterpolator3D()
		{
			ObiCatmullRomInterpolator obiCatmullRomInterpolator = new ObiCatmullRomInterpolator();
			interpolator = obiCatmullRomInterpolator;
		}
	}
}

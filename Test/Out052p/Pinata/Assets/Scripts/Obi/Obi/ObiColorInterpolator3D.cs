using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000074")]
	public class ObiColorInterpolator3D : ObiInterpolator<Color>
	{
		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x10")]
		private ObiCatmullRomInterpolator interpolator;

		[Token(Token = "0x600048B")]
		[Address(RVA = "0xE428A0", Offset = "0xE428A0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tv23 = *([v12 @ X29_v1+30]) * *([v12 @ X29_v1+30]);\n\tv25 = 1f - *([v12 @ X29_v1+30]);\n\tv26 = v23 * *([v12 @ X29_v1+30]);\n\tv31 = *([v12 @ X29_v1+20]) * v26;\n\tv32 = *([v12 @ X29_v1+24]) * v26;\n\tv33 = *([v12 @ X29_v1+28]) * v26;\n\tv34 = *([v12 @ X29_v1+2C]) * v26;\n\tv35 = v25 * v25;\n\tv36 = v25 * 3f;\n\tv37 = v25 * v35;\n\tv38 = v25 * v36;\n\tv39 = v36 * *([v12 @ X29_v1+30]);\n\tv40 = v38 * *([v12 @ X29_v1+30]);\n\tv41 = y0 * v37;\n\tv42 = v39 * *([v12 @ X29_v1+30]);\n\tv43 = y0.g * v37;\n\tv44 = y0.b * v37;\n\tv45 = y0.a * v37;\n\tv46 = y1 * v40;\n\tv47 = y1.g * v40;\n\tv48 = y1.b * v40;\n\tv49 = y1.a * v40;\n\tv50 = *([v12 @ X29_v1+10]) * v42;\n\tv51 = *([v12 @ X29_v1+14]) * v42;\n\tv52 = *([v12 @ X29_v1+18]) * v42;\n\tv53 = *([v12 @ X29_v1+1C]) * v42;\n\tv54 = v41 + v46;\n\tv55 = v43 + v47;\n\tv56 = v44 + v48;\n\tv57 = v45 + v49;\n\tv58 = v50 + v54;\n\tv59 = v51 + v55;\n\tv60 = v52 + v56;\n\tv61 = v53 + v57;\n\tv62 = v31 + v58;\n\tv63 = v32 + v59;\n\tv64 = v33 + v60;\n\tv65 = v34 + v61;\n\tv67 = 0;\n\tv70 = 0x101059C(&v67 @ stack_-20_v1 (UnityEngine.Color), 0, v71, v72, v73, v74, v75, v76, v62, v63, v64, v65, v46, v47, v48, v49);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn y0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color Evaluate(Color y0, Color y1, Color y2, Color y3, float mu)
		{
			//IL_002a: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_0084: Expected O, but got I
			//IL_009a: Expected O, but got I
			//IL_00b0: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			object obj3 = (long)intPtr * 0L;
			float num = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num2 = num - 0f;
			IntPtr intPtr2 = (IntPtr)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			object obj4 = (long)intPtr2 * 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+20]");
			object obj5 = 0L * (long)(IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+24]");
			object obj6 = 0L * (long)(IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+28]");
			object obj7 = 0L * (long)(IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+2C]");
			object obj8 = 0L * (long)(IntPtr)obj4;
			float num3 = num2 * num2;
			float num4 = num2 * 3f;
			float num5 = num2 * num3;
			float num6 = num2 * num4;
			float num7 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num8 = num7 * 0f;
			float num9 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num10 = num9 * 0f;
			Color color = default(Color);
			float num11 = color.r * num5;
			float num12 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num13 = num12 * 0f;
			float num14 = y0.g * num5;
			float num15 = y0.b * num5;
			float num16 = y0.a * num5;
			Color color2 = default(Color);
			float num17 = color2.r * num10;
			float num18 = y1.g * num10;
			float num19 = y1.b * num10;
			float num20 = y1.a * num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			float num21 = 0f * num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+14]");
			float num22 = 0f * num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+18]");
			float num23 = 0f * num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+1C]");
			float num24 = 0f * num13;
			float num25 = num11 + num17;
			float num26 = num14 + num18;
			float num27 = num15 + num19;
			float num28 = num16 + num20;
			float num29 = num21 + num25;
			float num30 = num22 + num26;
			float num31 = num23 + num27;
			float num32 = num24 + num28;
			float num33 = (float)obj5 + num29;
			float num34 = (float)obj6 + num30;
			float num35 = (float)obj7 + num31;
			float num36 = (float)obj8 + num32;
			Color color3 = default(Color);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}

		[Token(Token = "0x600048C")]
		[Address(RVA = "0xE42998", Offset = "0xE42998", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tv29 = 1f - *([v12 @ X29_v1+30]);\n\tv30 = y1 - y0;\n\tv31 = y1.g - y0.g;\n\tv32 = *([v12 @ X29_v1+10]) - y1;\n\tv33 = *([v12 @ X29_v1+30]) * 3f;\n\tv34 = *([v12 @ X29_v1+20]) - *([v12 @ X29_v1+10]);\n\tv35 = *([v12 @ X29_v1+14]) - y1.g;\n\tv36 = *([v12 @ X29_v1+24]) - *([v12 @ X29_v1+14]);\n\tv37 = v29 * 3f;\n\tv38 = v29 * 6f;\n\tv39 = y1.b - y0.b;\n\tv40 = y1.a - y0.a;\n\tv41 = *([v12 @ X29_v1+18]) - y1.b;\n\tv42 = *([v12 @ X29_v1+28]) - *([v12 @ X29_v1+18]);\n\tv43 = *([v12 @ X29_v1+1C]) - y1.a;\n\tv44 = v33 * *([v12 @ X29_v1+30]);\n\tv45 = v29 * v37;\n\tv46 = v38 * *([v12 @ X29_v1+30]);\n\tv47 = *([v12 @ X29_v1+2C]) - *([v12 @ X29_v1+1C]);\n\tv48 = v30 * v45;\n\tv49 = v32 * v46;\n\tv50 = v31 * v45;\n\tv51 = v35 * v46;\n\tv52 = v39 * v45;\n\tv53 = v41 * v46;\n\tv54 = v40 * v45;\n\tv55 = v43 * v46;\n\tv56 = v34 * v44;\n\tv57 = v36 * v44;\n\tv58 = v42 * v44;\n\tv59 = v47 * v44;\n\tv60 = v48 + v49;\n\tv61 = v50 + v51;\n\tv62 = v52 + v53;\n\tv63 = v54 + v55;\n\tv64 = v56 + v60;\n\tv65 = v57 + v61;\n\tv66 = v58 + v62;\n\tv67 = v59 + v63;\n\tv69 = 0;\n\tv72 = 0x101059C(&v69 @ stack_-20_v1 (UnityEngine.Color), 0, v73, v74, v75, v76, v77, v78, v64, v65, v66, v67, v49, v51, v53, v55);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn y0;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color EvaluateFirstDerivative(Color y0, Color y1, Color y2, Color y3, float mu)
		{
			//IL_00a8: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_016c: Expected O, but got I
			//IL_01e2: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			float num = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num2 = num - 0f;
			Color color = default(Color);
			Color color2 = default(Color);
			float num3 = color.r - color2.r;
			float num4 = y1.g - y0.g;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			float num5 = 0f - color.r;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num6 = 0f * 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+20]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			object obj3 = (long)intPtr - 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+14]");
			float num7 = 0f - y1.g;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+24]");
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+14]");
			object obj4 = (long)intPtr2 - 0L;
			float num8 = num2 * 3f;
			float num9 = num2 * 6f;
			float num10 = y1.b - y0.b;
			float num11 = y1.a - y0.a;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+18]");
			float num12 = 0f - y1.b;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+28]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+18]");
			object obj5 = (long)intPtr3 - 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+1C]");
			float num13 = 0f - y1.a;
			float num14 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num15 = num14 * 0f;
			float num16 = num2 * num8;
			float num17 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num18 = num17 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+2C]");
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+1C]");
			object obj6 = (long)intPtr4 - 0L;
			float num19 = num3 * num16;
			float num20 = num5 * num18;
			float num21 = num4 * num16;
			float num22 = num7 * num18;
			float num23 = num10 * num16;
			float num24 = num12 * num18;
			float num25 = num11 * num16;
			float num26 = num13 * num18;
			float num27 = (float)obj3 * num15;
			float num28 = (float)obj4 * num15;
			float num29 = (float)obj5 * num15;
			float num30 = (float)obj6 * num15;
			float num31 = num19 + num20;
			float num32 = num21 + num22;
			float num33 = num23 + num24;
			float num34 = num25 + num26;
			float num35 = num27 + num31;
			float num36 = num28 + num32;
			float num37 = num29 + num33;
			float num38 = num30 + num34;
			Color color3 = default(Color);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}

		[Token(Token = "0x600048D")]
		[Address(RVA = "0xE42A98", Offset = "0xE42A98", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tv29 = 1f - *([v12 @ X29_v1+30]);\n\tv30 = y1 - y0;\n\tv31 = y1.g - y0.g;\n\tv32 = *([v12 @ X29_v1+10]) - y1;\n\tv33 = *([v12 @ X29_v1+30]) * 3f;\n\tv34 = *([v12 @ X29_v1+20]) - *([v12 @ X29_v1+10]);\n\tv35 = *([v12 @ X29_v1+14]) - y1.g;\n\tv36 = *([v12 @ X29_v1+24]) - *([v12 @ X29_v1+14]);\n\tv37 = v29 * 3f;\n\tv38 = v29 * 6f;\n\tv39 = y1.b - y0.b;\n\tv40 = y1.a - y0.a;\n\tv41 = *([v12 @ X29_v1+18]) - y1.b;\n\tv42 = *([v12 @ X29_v1+28]) - *([v12 @ X29_v1+18]);\n\tv43 = *([v12 @ X29_v1+1C]) - y1.a;\n\tv44 = v33 * *([v12 @ X29_v1+30]);\n\tv45 = v29 * v37;\n\tv46 = v38 * *([v12 @ X29_v1+30]);\n\tv47 = *([v12 @ X29_v1+2C]) - *([v12 @ X29_v1+1C]);\n\tv48 = v30 * v45;\n\tv49 = v32 * v46;\n\tv50 = v31 * v45;\n\tv51 = v35 * v46;\n\tv52 = v39 * v45;\n\tv53 = v41 * v46;\n\tv54 = v40 * v45;\n\tv55 = v43 * v46;\n\tv56 = v34 * v44;\n\tv57 = v36 * v44;\n\tv58 = v42 * v44;\n\tv59 = v47 * v44;\n\tv60 = v48 + v49;\n\tv61 = v50 + v51;\n\tv62 = v52 + v53;\n\tv63 = v54 + v55;\n\tv64 = v56 + v60;\n\tv65 = v57 + v61;\n\tv66 = v58 + v62;\n\tv67 = v59 + v63;\n\tv69 = 0;\n\tv72 = 0x101059C(&v69 @ stack_-20_v1 (UnityEngine.Color), 0, v73, v74, v75, v76, v77, v78, v64, v65, v66, v67, v49, v51, v53, v55);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn y0;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color EvaluateSecondDerivative(Color y0, Color y1, Color y2, Color y3, float mu)
		{
			//IL_00a8: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_016c: Expected O, but got I
			//IL_01e2: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			float num = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num2 = num - 0f;
			Color color = default(Color);
			Color color2 = default(Color);
			float num3 = color.r - color2.r;
			float num4 = y1.g - y0.g;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			float num5 = 0f - color.r;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num6 = 0f * 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+20]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+10]");
			object obj3 = (long)intPtr - 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+14]");
			float num7 = 0f - y1.g;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+24]");
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+14]");
			object obj4 = (long)intPtr2 - 0L;
			float num8 = num2 * 3f;
			float num9 = num2 * 6f;
			float num10 = y1.b - y0.b;
			float num11 = y1.a - y0.a;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+18]");
			float num12 = 0f - y1.b;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+28]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+18]");
			object obj5 = (long)intPtr3 - 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+1C]");
			float num13 = 0f - y1.a;
			float num14 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num15 = num14 * 0f;
			float num16 = num2 * num8;
			float num17 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+30]");
			float num18 = num17 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+2C]");
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1+1C]");
			object obj6 = (long)intPtr4 - 0L;
			float num19 = num3 * num16;
			float num20 = num5 * num18;
			float num21 = num4 * num16;
			float num22 = num7 * num18;
			float num23 = num10 * num16;
			float num24 = num12 * num18;
			float num25 = num11 * num16;
			float num26 = num13 * num18;
			float num27 = (float)obj3 * num15;
			float num28 = (float)obj4 * num15;
			float num29 = (float)obj5 * num15;
			float num30 = (float)obj6 * num15;
			float num31 = num19 + num20;
			float num32 = num21 + num22;
			float num33 = num23 + num24;
			float num34 = num25 + num26;
			float num35 = num27 + num31;
			float num36 = num28 + num32;
			float num37 = num29 + num33;
			float num38 = num30 + num34;
			Color color3 = default(Color);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}

		[Token(Token = "0x600048E")]
		[Address(RVA = "0xE42838", Offset = "0xE42838", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF23F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202472C]) = v38;\nL_0016:\n\tv42 = new Obi.ObiCatmullRomInterpolator();\n\tSystem.Object::.ctor(v42);\n\tthis.interpolator = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiColorInterpolator3D()
		{
			ObiCatmullRomInterpolator obiCatmullRomInterpolator = new ObiCatmullRomInterpolator();
			interpolator = obiCatmullRomInterpolator;
		}
	}
}

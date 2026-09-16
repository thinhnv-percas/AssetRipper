using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x200004A")]
	public static class MathUtils
	{
		[Token(Token = "0x40001CF")]
		public const float PI = (float)Math.PI;

		[Token(Token = "0x40001D0")]
		public const float PI2 = (float)Math.PI * 2f;

		[Token(Token = "0x40001D1")]
		public const float RadDeg = 180f / (float)Math.PI;

		[Token(Token = "0x40001D2")]
		public const float DegRad = (float)Math.PI / 180f;

		[Token(Token = "0x40001D3")]
		private static System.Random random;

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0x1530F2C", Offset = "0x1530F2C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.Math;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, radians, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B5F]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, v20, v21, v22, v23, v24, v25, v26, radians, v27, v28, v29, v30, v31, v32, v33);\nL_001A:\n\tv45 = 0x1854F60(System.Math, v20, v21, v22, v23, v24, v25, v26, radians, v27, v28, v29, v30, v31, v32, v33);\n\treturn radians;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Sin(float radians)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
			return radians;
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0x1530EC8", Offset = "0x1530EC8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.Math;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, radians, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B60]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, v20, v21, v22, v23, v24, v25, v26, radians, v27, v28, v29, v30, v31, v32, v33);\nL_001A:\n\tv45 = 0x1854F50(System.Math, v20, v21, v22, v23, v24, v25, v26, radians, v27, v28, v29, v30, v31, v32, v33);\n\treturn radians;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Cos(float radians)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:cos", "Method not found @1854F50 (native cos)");
			return radians;
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0x152F4D4", Offset = "0x152F4D4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.Math;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, degrees, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B61]) = v37;\nL_0017:\n\tgoto L_001B;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, v20, v21, v22, v23, v24, v25, v26, degrees, v27, v28, v29, v30, v31, v32, v33);\nL_001B:\n\tv46 = degrees * 0.017453292f;\n\tv48 = 0x1854F60(System.Math, v20, v21, v22, v23, v24, v25, v26, v46, v27, v28, v29, v30, v31, v32, v33);\n\treturn v46;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float SinDeg(float degrees)
		{
			float result = degrees * ((float)Math.PI / 180f);
			Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
			return result;
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0x152F464", Offset = "0x152F464", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.Math;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, degrees, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B62]) = v37;\nL_0017:\n\tgoto L_001B;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, v20, v21, v22, v23, v24, v25, v26, degrees, v27, v28, v29, v30, v31, v32, v33);\nL_001B:\n\tv46 = degrees * 0.017453292f;\n\tv48 = 0x1854F50(System.Math, v20, v21, v22, v23, v24, v25, v26, v46, v27, v28, v29, v30, v31, v32, v33);\n\treturn v46;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float CosDeg(float degrees)
		{
			float result = degrees * ((float)Math.PI / 180f);
			Il2CppRuntime.Boundary("SYSTEM_API:cos", "Method not found @1854F50 (native cos)");
			return result;
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0x152F544", Offset = "0x152F544", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = System.Math;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, y, x, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37B63]) = v40;\nL_0019:\n\tgoto L_001D;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, v24, v25, v26, v27, v28, v29, v30, y, x, v31, v32, v33, v34, v35, v36);\nL_001D:\n\tv49 = 0x18550E0(System.Math, v24, v25, v26, v27, v28, v29, v30, y, x, v31, v32, v33, v34, v35, v36);\n\treturn y;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Atan2(float y, float x)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:atan2", "Method not found @18550E0 (native atan2)");
			return y;
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0x153313C", Offset = "0x153313C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = value < v29;\n\tif (v5) goto L_001A;\n\tv24 = value > max;\n\tif (v24) goto L_001A;\nL_001A:\n\treturn v29;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Clamp(float value, float min, float max)
		{
			float num = default(float);
			if (!(value < num))
			{
				bool flag = value > max;
				num = max;
				if (!flag)
				{
					num = value;
				}
			}
			return num;
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0x153315C", Offset = "0x153315C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.MathUtils;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, min, max, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37B64]) = v40;\nL_0019:\n\tgoto L_001E;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, v24, v25, v26, v27, v28, v29, v30, min, max, v31, v32, v33, v34, v35, v36);\nL_001E:\n\tv50 = min + max;\n\tv52 = v50 * 0.5f;\n\treturnVal1 = Spine.MathUtils::RandomTriangle(min, max, v52);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float RandomTriangle(float min, float max)
		{
			float num = min + max;
			float mode = num * 0.5f;
			return RandomTriangle(min, max, mode);
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x15331CC", Offset = "0x15331CC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = Spine.MathUtils;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, v36, v37, v38, v39, v40, v41, v42, min, max, mode, v43, v44, v45, v46, v47);\n\tv58 = System.Math;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, v36, v37, v38, v39, v40, v41, v42, min, max, mode, v43, v44, v45, v46, v47);\n\tv52 = 1;\n\t*([1A37B65]) = v52;\nL_0022:\n\tgoto L_002E;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v53, v36, v37, v38, v39, v40, v41, v42, min, max, mode, v43, v44, v45, v46, v47);\n\tv61 = Spine.MathUtils;\nL_002E:\n\tv70 = System.Random::NextDouble(v62.random);\n\tv72 = max - min;\n\tv73 = mode - min;\n\tv76 = v73 / v72;\n\tgoto L_0042;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v71, v68, v37, v38, v39, v40, v41, v42, min, max, mode, v43, v44, v45, v46, v47);\nL_0042:\n\tv91 = v76 >= min;\n\tif (v91) goto L_004C;\n\tv93 = 1f - min;\n\tv94 = v72 * v93;\n\tv95 = max - mode;\n\tv96 = v95 * v94;\n\tv97 = UnityEngine.Mathf::Sqrt(v96);\n\treturnVal2 = max - v97;\n\tgoto L_005B;\nL_004C:\n\tv98 = v72 * min;\n\tv99 = v73 * v98;\n\tv100 = UnityEngine.Mathf::Sqrt(v99);\n\treturnVal2 = v100 + min;\nL_005B:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn min;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float RandomTriangle(float min, float max, float mode)
		{
			double num = random.NextDouble();
			float num2 = max - min;
			float num3 = mode - min;
			float num4 = num3 / num2;
			if (num4 < min)
			{
				float num5 = 1f - min;
				float num6 = num2 * num5;
				float num7 = max - mode;
				float f = num7 * num6;
				float num8 = Mathf.Sqrt(f);
				return max - num8;
			}
			float num9 = num2 * min;
			float f2 = num3 * num9;
			float num10 = Mathf.Sqrt(f2);
			return num10 + min;
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0x15332D0", Offset = "0x15332D0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Spine.MathUtils;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = System.Random;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A37B66]) = v39;\nL_0018:\n\tv41 = new System.Random();\n\tSystem.Random::.ctor(v41);\n\tv47.random = v41;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static MathUtils()
		{
			System.Random random = new System.Random();
			MathUtils.random = random;
		}
	}
}

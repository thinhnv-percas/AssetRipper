using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.OptionalValueSystem;
using Unity.Mathematics;
using UnityEngine;

namespace Unco.Extensions
{
	[Token(Token = "0x200001D")]
	public static class VectorExtensions
	{
		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x81AB4FC", Offset = "0x81AB4FC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = y;\n\tv35 = x;\n\tv36 = z;\n\tv37 = 0xB799000;\n\tv39 = *([B799F87]) & 1;\n\tv40 = v39 == 0;\n\tif (v40) goto L_0040;\n\tv43 = x & 1;\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0048;\nL_0022:\n\tv66 = y & 1;\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tv107 = v;\n\tv119 = v;\n\tif (v68) goto L_004F;\nL_0026:\n\tv87 = z & 1;\n\tv88 = v87 == 0;\n\tv119 = v107;\n\tif (v88) goto L_003B;\nL_002B:\n\tv112 = Unco.OptionalValueSystem.Optional`1<System.Single>::get_Value(&v36 @ stack_-68_v1 (Unco.OptionalValueSystem.Optional`1<System.Single>));\n\tv119 = v107;\nL_0040:\n\t*([v37 @ X22_v1+F87]) = 1;\n\tv77 = x & 1;\n\tv61 = v77 == 0;\n\tif (v61) goto L_0022;\nL_0048:\n\tv75 = Unco.OptionalValueSystem.Optional`1<System.Single>::get_Value(&v35 @ stack_-58_v1 (Unco.OptionalValueSystem.Optional`1<System.Single>));\n\tv99 = y & 1;\n\tv82 = v99 == 0;\n\tv107 = v75;\n\tv119 = v75;\n\tif (v82) goto L_0026;\nL_004F:\n\tv98 = Unco.OptionalValueSystem.Optional`1<System.Single>::get_Value(&v34 @ stack_-60_v1 (Unco.OptionalValueSystem.Optional`1<System.Single>));\n\tv136 = z & 1;\n\tv137 = v136 == 0;\n\tv104 = ~v137;\n\tv107 = v119;\n\tif (v104) goto L_002B;\n\tgoto L_003B;\nL_003B:\n\treturn v119;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 With(this Vector3 v, Optional<float> x = default(Optional<float>), Optional<float> y = default(Optional<float>), Optional<float> z = default(Optional<float>))
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VectorExtensions::With");
			return default;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x81AB5DC", Offset = "0x81AB5DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v;\n")]
		public static Vector2 XY(this Vector3 v)
		{
			return v;
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x81AB5E0", Offset = "0x81AB5E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v;\n")]
		public static Vector2 XZ(this Vector3 v)
		{
			return v;
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x81AB5E8", Offset = "0x81AB5E8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v;\n")]
		public static Vector3 X0Z(this Vector2 v, float y = 0f)
		{
			return v;
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x81AB5F8", Offset = "0x81AB5F8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v;\n")]
		public static float3 X0Z(this float2 v, float y = 0f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VectorExtensions::X0Z");
			return default;
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x81AB608", Offset = "0x81AB608", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = degrees * 0x3C8EFA35;\n\tv19 = 0x8BF5CD8(methodInfo, v21, v22, v23, v24, v25, v26, v27, v17, v.y, degrees, v28, v29, v30, v31, v32);\n\tv33 = v * v.y;\n\tv34 = v.y * v17;\n\tv35 = v33 - v34;\n\treturn v35;\n")]
		public static Vector2 Rotate(this Vector2 v, float degrees)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VectorExtensions::Rotate");
			return default;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x81AB658", Offset = "0x81AB658", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\t// 44 MakeStruct v71 @ AGG81AB6DC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), returnVal1 @ V0_v1 (UnityEngine.Vector3), returnVal1.y (System.Single), returnVal1.z (System.Single)\n\tv156 = UnityEngine.Camera::WorldToScreenPoint(camera, v71);\n\tv78 = v156.z < 0;\n\tv79 = v156.z == 0;\n\tv82 = v156.z == v156.z;\n\tv83 = ~v82;\n\tv84 = v78 == v83;\n\tv85 = ~v84;\n\tv86 = v85 | v79;\n\tif (v86) goto L_005C;\n\tgoto L_004B;\n\treturnVal2 = 0xFFFFFFFFC53B8000;\n\tgoto L_007F;\nL_005C:\n\tgoto L_0062;\nL_0062:\n\tUnityEngine.Debug::LogWarning(\"Object is behind the camera, UI position might not be valid.\");\n\tgoto L_0072;\nL_0027:\n\tv64 = 0;\nL_004B:\n\t// 75 MakeStruct v168 @ AGG81AB724_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v156 @ V0_v6 (UnityEngine.Vector3), v156.y (System.Single)\n\tv169 = UnityEngine.RectTransformUtility::ScreenPointToLocalPointInRectangle(canvasRect, v168, camera, &v64 @ stack_-58_v1 (UnityEngine.Vector2));\n\tv177 = v169 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0072;\nL_0072:\n\treturnVal2 = v202.zero;\nL_007F:\n\treturn returnVal2;\n")]
		public static Vector2 ToScreenPos(this Vector3 worldPosition, RectTransform canvasRect, Camera camera)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VectorExtensions::ToScreenPos");
			return default;
		}
	}
}

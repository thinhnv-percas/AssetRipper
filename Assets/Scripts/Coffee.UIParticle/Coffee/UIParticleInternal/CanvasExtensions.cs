using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000004")]
	internal static class CanvasExtensions
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x3F1E90C", Offset = "0x3F1E90C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.QualitySettings::get_activeColorSpace();\n\tv23 = v13 != 1;\n\tif (v23) goto L_0025;\n\treturnVal2 = UnityEngine.Canvas::get_vertexColorAlwaysGammaSpace(canvas);\n\treturn returnVal2;\nL_0025:\n\treturn 0;\n")]
		public static bool ShouldGammaToLinearInShader(this Canvas canvas)
		{
			ColorSpace activeColorSpace = QualitySettings.activeColorSpace;
			if (activeColorSpace == ColorSpace.Linear)
			{
				return canvas.vertexColorAlwaysGammaSpace;
			}
			return false;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x3F1E958", Offset = "0x3F1E958", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.QualitySettings::get_activeColorSpace();\n\tv23 = v13 != 1;\n\tif (v23) goto L_0026;\n\tv32 = UnityEngine.Canvas::get_vertexColorAlwaysGammaSpace(canvas);\n\treturnVal2 = v32 ^ 1;\n\treturn returnVal2;\nL_0026:\n\treturn 0;\n")]
		public static bool ShouldGammaToLinearInMesh(this Canvas canvas)
		{
			ColorSpace activeColorSpace = QualitySettings.activeColorSpace;
			if (activeColorSpace == ColorSpace.Linear)
			{
				bool vertexColorAlwaysGammaSpace = canvas.vertexColorAlwaysGammaSpace;
				return (byte)((vertexColorAlwaysGammaSpace ? 1u : 0u) ^ 1u) != 0;
			}
			return false;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x3F1E9AC", Offset = "0x3F1E9AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public static bool IsStereoCanvas(this Canvas canvas)
		{
			return false;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x3F1E9B4", Offset = "0x3F1E9B4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCoffee.UIParticleInternal.CanvasExtensions::GetViewProjectionMatrix(canvas, 2, vpMatrix);\n\treturn;\n")]
		public static void GetViewProjectionMatrix(this Canvas canvas, out Matrix4x4 vpMatrix)
		{
			vpMatrix = default(Matrix4x4);
			canvas.GetViewProjectionMatrix(Camera.MonoOrStereoscopicEye.Mono, out vpMatrix);
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x3F1E9C0", Offset = "0x3F1E9C0", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_003A:\n\tv78 = Coffee.UIParticleInternal.FrameCache::TryGet(canvas, \"GetViewProjectionMatrix\", vpMatrix);\n\tv84 = v78 == 0;\n\tif (v84) goto L_004F;\n\tgoto L_009F;\nL_004F:\n\tCoffee.UIParticleInternal.CanvasExtensions::GetViewProjectionMatrix(canvas, eye, &v101 @ stack_-D0_v3 (UnityEngine.Matrix4x4), &v103 @ stack_-110_v3 (UnityEngine.Matrix4x4));\n\tv227 = v101;\n\tv182 = v103;\n\tv241 = UnityEngine.Matrix4x4::op_Multiply(&v227 @ stack_-90_v2 (UnityEngine.Matrix4x4), &v182 @ stack_-190_v2 (UnityEngine.Matrix4x4));\n\tvpMatrix.m02 = v241.m02;\n\tvpMatrix.m03 = v241.m03;\n\tvpMatrix.m00 = v241.m00;\n\tvpMatrix.m01 = v241.m01;\n\tgoto L_008B;\nL_008B:\n\tv194 = v241.m00;\n\tCoffee.UIParticleInternal.FrameCache::Set(canvas, \"GetViewProjectionMatrix\", &v194 @ stack_-90_v3 (System.Single));\nL_009F:\n\treturn;\nL_0035:\n\tgoto L_003A;\n")]
		public unsafe static void GetViewProjectionMatrix(this Canvas canvas, Camera.MonoOrStereoscopicEye eye, out Matrix4x4 vpMatrix)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CanvasExtensions::GetViewProjectionMatrix");
			vpMatrix = default;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x3F1EF7C", Offset = "0x3F1EF7C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCoffee.UIParticleInternal.CanvasExtensions::GetViewProjectionMatrix(canvas, 2, vMatrix, pMatrix);\n\treturn;\n")]
		public static void GetViewProjectionMatrix(this Canvas canvas, out Matrix4x4 vMatrix, out Matrix4x4 pMatrix)
		{
			vMatrix = default(Matrix4x4);
			pMatrix = default(Matrix4x4);
			canvas.GetViewProjectionMatrix(Camera.MonoOrStereoscopicEye.Mono, out vMatrix, out pMatrix);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x3F1EB54", Offset = "0x3F1EB54", Length = "0x428")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\nL_0043:\n\tv88 = Coffee.UIParticleInternal.FrameCache::TryGet(canvas, \"GetViewMatrix\", eye, vMatrix);\n\tv92 = ~v88;\n\tif (v92) goto L_005A;\n\tgoto L_0051;\nL_0051:\n\tv109 = Coffee.UIParticleInternal.FrameCache::TryGet(canvas, \"GetProjectionMatrix\", eye, pMatrix);\n\tv174 = v109 == 0;\n\tv111 = ~v174;\n\tif (v111) goto L_0177;\nL_005A:\n\tv122 = UnityEngine.Canvas::get_rootCanvas(canvas);\n\tv408 = UnityEngine.Canvas::get_worldCamera(v122);\n\tgoto L_0069;\nL_0069:\n\tv505 = UnityEngine.Object::op_Implicit(v122);\n\tv507 = ~v505;\n\tv508 = ~v507;\n\tif (v508) goto L_0076;\n\tgoto L_00BF;\nL_0076:\n\tv518 = UnityEngine.Canvas::get_renderMode(v122);\n\tv527 = v518 == 0;\n\tif (v527) goto L_00BF;\n\tgoto L_007F;\nL_007F:\n\tv524 = UnityEngine.Object::op_Implicit(v408);\n\tv528 = ~v524;\n\tif (v528) goto L_00BF;\n\tv125 = eye != 2;\n\tif (v125) goto L_017E;\n\tv635 = UnityEngine.Camera::get_worldToCameraMatrix(v408);\n\tvMatrix.m00 = v809;\n\tvMatrix.m01 = v281;\n\tvMatrix.m02 = v278;\n\tvMatrix.m03 = v275;\n\tv669 = UnityEngine.Camera::get_projectionMatrix(v408);\n\tv714 = v669.m00;\n\tgoto L_01C0;\nL_00BF:\n\tv159 = UnityEngine.Component::get_transform(v122);\n\tv533 = UnityEngine.Transform::get_position(v159);\n\tv540 = -v533;\n\tv541 = -v533.y;\n\tgoto L_00E7;\nL_014E:\n\tv809 = vMatrix.m00;\n\tCoffee.UIParticleInternal.FrameCache::Set(canvas, \"GetViewMatrix\", eye, &v809 @ stack_-D0_v3 (System.Single));\n\tv809 = pMatrix.m00;\n\tCoffee.UIParticleInternal.FrameCache::Set(canvas, \"GetProjectionMatrix\", eye, &v809 @ stack_-D0_v3 (System.Single));\nL_0177:\n\treturn;\nL_017E:\n\tv641 = UnityEngine.Camera::GetStereoProjectionMatrix(v408, eye);\n\tpMatrix.m00 = v809;\n\tpMatrix.m01 = v281;\n\tpMatrix.m02 = v278;\n\tpMatrix.m03 = v275;\n\tv694 = UnityEngine.Camera::GetStereoViewMatrix(v408, eye);\n\tvMatrix.m00 = v694.m00;\n\tvMatrix.m01 = v694.m01;\n\tvMatrix.m02 = v694.m02;\n\tvMatrix.m03 = v694.m03;\n\tv714 = pMatrix.m00;\nL_003A:\n\tgoto L_0043;\nL_01C0:\n\tv742 = UnityEngine.GL::GetGPUProjectionMatrix(&v714 @ stack_-190_v3 (System.Single), 0);\n\tpMatrix.m00 = v742.m00;\n\tpMatrix.m01 = v742.m01;\n\tv731 = v742.m03;\n\tv733 = v742.m02;\n\tgoto L_0138;\nL_00E7:\n\t// 231 MakeStruct v573 @ AGG3F1EDD4_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v540 @ V10_v4, v541 @ V11_v4, -998637568\n\t// 232 MakeStruct v574 @ AGG3F1EDD4_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v557.identity (UnityEngine.Quaternion), v557.identity.y (System.Single), v557.identity.z (System.Single), v557.identity.w (System.Single)\n\tv575 = UnityEngine.Matrix4x4::TRS(v573, v574, 0x3F8000003F800000);\n\tvMatrix.m00 = v809;\n\tvMatrix.m01 = v281;\n\tvMatrix.m02 = v278;\n\tvMatrix.m03 = v275;\n\tgoto L_0113;\nL_0113:\n\tv616 = 1f / v533;\n\t// 287 MakeStruct v628 @ AGG3F1EE44_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, -1f\n\t// 288 MakeStruct v629 @ AGG3F1EE44_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v610.identity (UnityEngine.Quaternion), v610.identity.y (System.Single), v610.identity.z (System.Single), v610.identity.w (System.Single)\n\tv630 = UnityEngine.Matrix4x4::TRS(v628, v629, v616);\n\tpMatrix.m00 = v630.m00;\n\tpMatrix.m01 = v630.m01;\n\tv731 = v630.m03;\n\tv733 = v630.m02;\nL_0138:\n\tpMatrix.m02 = v733;\n\tpMatrix.m03 = v731;\n\tgoto L_014E;\n")]
		public unsafe static void GetViewProjectionMatrix(this Canvas canvas, Camera.MonoOrStereoscopicEye eye, out Matrix4x4 vMatrix, out Matrix4x4 pMatrix)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CanvasExtensions::GetViewProjectionMatrix");
			vMatrix = default;
			pMatrix = default;
		}
	}
}

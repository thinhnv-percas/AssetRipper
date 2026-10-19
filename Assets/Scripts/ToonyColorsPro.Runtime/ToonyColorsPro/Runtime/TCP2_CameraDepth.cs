using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ToonyColorsPro.Runtime
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[Token(Token = "0x2000004")]
	public class TCP2_CameraDepth : MonoBehaviour
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		public bool RenderDepth;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x8196554", Offset = "0x8196554", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tToonyColorsPro.Runtime.TCP2_CameraDepth::SetCameraDepth(this);\n\treturn;\n")]
		private void OnEnable()
		{
			SetCameraDepth();
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x819660C", Offset = "0x819660C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tToonyColorsPro.Runtime.TCP2_CameraDepth::SetCameraDepth(this);\n\treturn;\n")]
		private void OnValidate()
		{
			SetCameraDepth();
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x8196558", Offset = "0x8196558", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv63 = UnityEngine.Camera::get_depthTextureMode(v46);\n\tv69 = v63 | 1;\n\tUnityEngine.Camera::set_depthTextureMode(v46, v69);\n\treturn;\nL_003B:\n\tv68 = UnityEngine.Camera::get_depthTextureMode(v46);\n\tv78 = v68 & -2;\n\tUnityEngine.Camera::set_depthTextureMode(v46, v78);\n\treturn;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tv58 = this.RenderDepth != 1;\n\tif (v58) goto L_003B;\n")]
		private void SetCameraDepth()
		{
			Camera component = GetComponent<Camera>();
			if (RenderDepth)
			{
				DepthTextureMode depthTextureMode = component.depthTextureMode;
				DepthTextureMode depthTextureMode2 = depthTextureMode | DepthTextureMode.Depth;
				component.depthTextureMode = depthTextureMode2;
			}
			else
			{
				DepthTextureMode depthTextureMode3 = component.depthTextureMode;
				DepthTextureMode depthTextureMode4 = depthTextureMode3 & ~DepthTextureMode.Depth;
				component.depthTextureMode = depthTextureMode4;
			}
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x8196610", Offset = "0x8196610", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.RenderDepth = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TCP2_CameraDepth()
		{
			RenderDepth = true;
		}
	}
}

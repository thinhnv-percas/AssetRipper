using AlmostEngine.Screenshot;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AlmostEngine.Examples
{
	[Token(Token = "0x2000005")]
	public class CaptureCameraToTextureExample : MonoBehaviour
	{
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x20")]
		public RawImage m_RawImage;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x28")]
		public Camera m_Camera;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x30")]
		public int m_Width;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x34")]
		public int m_Height;

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x3C2E0B8", Offset = "0x3C2E0B8", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = AlmostEngine.Screenshot.SimpleScreenshotCapture::CaptureCameraToTexture(this.m_Width, this.m_Height, this.m_Camera, 0);\n\tUnityEngine.UI.RawImage::set_texture(this.m_RawImage, v17);\n\treturn;\n")]
		public void Capture()
		{
			Texture2D texture = SimpleScreenshotCapture.CaptureCameraToTexture(m_Width, m_Height, m_Camera);
			m_RawImage.texture = texture;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x3C2E25C", Offset = "0x3C2E25C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Width = 1.9097962126593E-311d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CaptureCameraToTextureExample()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CaptureCameraToTextureExample::.ctor");
		}
	}
}

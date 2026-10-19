using AlmostEngine.Screenshot;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AlmostEngine.Examples
{
	[Token(Token = "0x2000006")]
	public class CaptureScreenToTextureExample : MonoBehaviour
	{
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x20")]
		public RawImage m_RawImage;

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x3C2E270", Offset = "0x3C2E270", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturn;\nL_001C:\n\tv48 = new UnityEngine.Events.UnityAction`1<UnityEngine.Texture2D>();\n\tUnityEngine.Events.UnityAction`1<UnityEngine.Texture2D>::.ctor(v48, this, Il2CppMethodInfo);\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::CaptureScreenToTexture(v48, 0);\n")]
		public void Capture()
		{
			UnityAction<Texture2D> onTextureCaptured = OnTextureCaptured;
			SimpleScreenshotCapture.CaptureScreenToTexture(onTextureCaptured);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x3C2E3C4", Offset = "0x3C2E3C4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.RawImage::set_texture(this.m_RawImage, texture);\n\treturn;\n")]
		private void OnTextureCaptured(Texture2D texture)
		{
			m_RawImage.texture = texture;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x3C2E3E0", Offset = "0x3C2E3E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CaptureScreenToTextureExample()
		{
		}
	}
}

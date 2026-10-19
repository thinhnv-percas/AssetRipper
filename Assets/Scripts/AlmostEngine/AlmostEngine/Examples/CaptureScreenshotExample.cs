using AlmostEngine.Screenshot;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Examples
{
	[Token(Token = "0x2000007")]
	public class CaptureScreenshotExample : MonoBehaviour
	{
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x20")]
		public int m_Width;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x24")]
		public int m_Height;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x28")]
		public int m_Scale;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x30")]
		public string m_FullpathA;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x38")]
		public string m_FullpathB;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x40")]
		public KeyCode m_ShortcutA;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x44")]
		public KeyCode m_ShortcutB;

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x3C2E3E8", Offset = "0x3C2E3E8", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = UnityEngine.Input::GetKeyDown(this.m_ShortcutA);\n\tv19 = ~v18;\n\tv20 = ~v19;\n\tif (v20) goto L_001F;\n\tv23 = UnityEngine.Input::GetKeyDown(this.m_ShortcutB);\n\tv27 = ~v23;\n\tv28 = ~v27;\n\tif (v28) goto L_003F;\nL_001C:\n\treturn;\nL_001F:\n\tv26 = UnityEngine.Screen::get_width();\n\tv31 = UnityEngine.Screen::get_height();\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::CaptureToFile(this.m_FullpathA, v26, v31, 0, 0x64, 0, 0, 2, 8, 1, 0, 0x100, v116, 0);\n\tv81 = UnityEngine.Input::GetKeyDown(this.m_ShortcutB);\n\tv77 = ~v81;\n\tif (v77) goto L_001C;\nL_003F:\n\tv111 = UnityEngine.Camera::get_main();\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::CaptureCameraToFile(this.m_FullpathB, this.m_Width, this.m_Height, v111, 1, 0x46, 8, 0, 0x100, v160, 0);\n\treturn;\n")]
		private void Update()
		{
			if (!Input.GetKeyDown(m_ShortcutA))
			{
				if (!Input.GetKeyDown(m_ShortcutB))
				{
					return;
				}
			}
			else
			{
				int width = Screen.width;
				int height = Screen.height;
				bool exportToGallery = default(bool);
				SimpleScreenshotCapture.CaptureToFile(m_FullpathA, width, height, default(TextureExporter.ImageFileFormat), 100, null, null, ScreenshotTaker.CaptureMode.FIXED_GAME_VIEW, 8, captureGameUI: true, default(ScreenshotTaker.ColorFormat), recomputeAlphaMask: false, exportToGallery);
				if (!Input.GetKeyDown(m_ShortcutB))
				{
					return;
				}
			}
			Camera main = Camera.main;
			bool exportToGallery2 = default(bool);
			SimpleScreenshotCapture.CaptureCameraToFile(m_FullpathB, m_Width, m_Height, main, TextureExporter.ImageFileFormat.JPG, 70, 8, default(ScreenshotTaker.ColorFormat), recomputeAlphaMask: false, exportToGallery2);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x3C2E724", Offset = "0x3C2E724", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\treturn;\nL_0018:\n\tthis.m_Width = 1.2731974749744E-311d;\n\tthis.m_Scale = 1;\n\tthis.m_FullpathA = \"\";\n\tthis.m_FullpathB = \"\";\n\tthis.m_ShortcutA = 6.1113478794E-312d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n")]
		public CaptureScreenshotExample()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CaptureScreenshotExample::.ctor");
		}
	}
}

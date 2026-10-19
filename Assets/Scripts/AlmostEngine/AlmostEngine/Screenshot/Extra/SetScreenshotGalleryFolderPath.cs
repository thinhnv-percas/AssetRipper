using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot.Extra
{
	[RequireComponent(typeof(ScreenshotGallery))]
	[Token(Token = "0x200005D")]
	public class SetScreenshotGalleryFolderPath : MonoBehaviour
	{
		[Tooltip("The screenshot manager to use as reference to get the screenshots folder path.")]
		[Token(Token = "0x4000232")]
		[FieldOffset(Offset = "0x20")]
		public ScreenshotManager m_Manager;

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0x3C479F4", Offset = "0x3C479F4", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.m_Manager, 0);\n\tv64 = ~v55;\n\tif (v64) goto L_005B;\n\tv82 = UnityEngine.Component::GetComponent(this);\n\tv128 = AlmostEngine.Screenshot.ScreenshotManager::GetExportPath(this.m_Manager);\n\tv82.m_ScreenshotFolderPath = v128;\n\tv137 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::LoadImageFiles(v82);\n\tv112 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::UpdateGallery(v112);\n\treturn;\nL_005B:\n\treturn;\n")]
		private void Start()
		{
			if (m_Manager != null)
			{
				ScreenshotGallery component = GetComponent<ScreenshotGallery>();
				string exportPath = m_Manager.GetExportPath();
				component.m_ScreenshotFolderPath = exportPath;
				component.LoadImageFiles();
				ScreenshotGallery screenshotGallery = default(ScreenshotGallery);
				screenshotGallery.UpdateGallery();
			}
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0x3C47B04", Offset = "0x3C47B04", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SetScreenshotGalleryFolderPath()
		{
		}
	}
}

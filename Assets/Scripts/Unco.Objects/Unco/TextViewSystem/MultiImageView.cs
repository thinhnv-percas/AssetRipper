using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000014")]
	public class MultiImageView : ImageView
	{
		[SerializeField]
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x20")]
		private ImageView[] m_imageViews;

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x81C1CC8", Offset = "0x81C1CC8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_imageViews;\n\tv28 = v14.Length < 1;\n\tif (v28) goto L_0038;\n\tv43 = 0;\nL_0022:\n\tv94 = Unco.TextViewSystem.ImageView::SetImage(v14[v43 @ X21_v5 (System.Int32)], sprite);\n\tv43 = v43 + 1;\n\tv106 = v43 < v14.Length;\n\tif (v106) goto L_0022;\nL_0038:\n\treturn;\n")]
		public override void SetImage(Sprite sprite)
		{
			ImageView[] imageViews = m_imageViews;
			if (imageViews.Length >= 1)
			{
				int num = 0;
				do
				{
					imageViews[num].SetImage(sprite);
					num++;
				}
				while (num < imageViews.Length);
			}
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x81C1D34", Offset = "0x81C1D34", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = this.m_imageViews;\n\tv40 = v26.Length < 1;\n\tif (v40) goto L_0049;\n\tv54 = 0;\nL_002F:\n\tv114 = Unco.TextViewSystem.ImageView::SetColor(v26[v54 @ X20_v5 (System.Int32)], Color_arg);\n\tv54 = v54 + 1;\n\tv129 = v54 < v26.Length;\n\tif (v129) goto L_002F;\nL_0049:\n\treturn;\n")]
		public override void SetColor(Color color)
		{
			ImageView[] imageViews = m_imageViews;
			if (imageViews.Length >= 1)
			{
				int num = 0;
				Color color2 = default(Color);
				do
				{
					imageViews[num].SetColor(color2);
					num++;
				}
				while (num < imageViews.Length);
			}
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x81C1DC8", Offset = "0x81C1DC8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_imageViews;\n\tv12 = v6[0];\n\tv12 = Unco.TextViewSystem.ImageView::GetImage(v12);\n\treturn v12;\n")]
		public override Sprite GetImage()
		{
			ImageView[] imageViews = m_imageViews;
			ImageView imageView = imageViews[0];
			return imageView.GetImage();
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x81C1E00", Offset = "0x81C1E00", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_imageViews;\n\tv28 = v14.Length < 1;\n\tif (v28) goto L_0038;\n\tv43 = 0;\nL_0022:\n\tv94 = Unco.TextViewSystem.ImageView::SetActive(v14[v43 @ X21_v5 (System.Int32)], isActive);\n\tv43 = v43 + 1;\n\tv106 = v43 < v14.Length;\n\tif (v106) goto L_0022;\nL_0038:\n\treturn;\n")]
		public override void SetActive(bool isActive)
		{
			ImageView[] imageViews = m_imageViews;
			if (imageViews.Length >= 1)
			{
				int num = 0;
				do
				{
					imageViews[num].SetActive(isActive);
					num++;
				}
				while (num < imageViews.Length);
			}
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81C1E6C", Offset = "0x81C1E6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MultiImageView()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000012")]
	public class ImageFillAmountProgressView : ProgressView
	{
		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x20")]
		private Image m_image;

		[Token(Token = "0x17000005")]
		public override float Progress
		{
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x81C1C10", Offset = "0x81C1C10", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_image;\n\treturn v0.fillAmount;\n")]
			get
			{
				Image image = m_image;
				return image.fillAmount;
			}
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x81C1C2C", Offset = "0x81C1C2C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = UnityEngine.Component::GetComponentInChildren(this, 1);\n\tthis.m_image = v47;\n\treturn;\n")]
		private void Reset()
		{
			Image componentInChildren = GetComponentInChildren<Image>(includeInactive: true);
			m_image = componentInChildren;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x81C1C94", Offset = "0x81C1C94", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Image::set_fillAmount(this.m_image, value);\n\treturn;\n")]
		public override void SetProgress(float value)
		{
			m_image.fillAmount = value;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x81C1CB0", Offset = "0x81C1CB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ImageFillAmountProgressView()
		{
		}
	}
}

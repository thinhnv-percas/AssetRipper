using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x200001E")]
	public class UnityImageView : ImageView
	{
		[SerializeField]
		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x20")]
		private Image m_image;

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x81C2ACC", Offset = "0x81C2ACC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = UnityEngine.Component::GetComponentInChildren(this, 1);\n\tthis.m_image = v47;\n\treturn;\n")]
		private void Reset()
		{
			Image componentInChildren = GetComponentInChildren<Image>(includeInactive: true);
			m_image = componentInChildren;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x81C2B34", Offset = "0x81C2B34", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Image::set_sprite(this.m_image, sprite);\n\treturn;\n")]
		public override void SetImage(Sprite sprite)
		{
			m_image.sprite = sprite;
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x81C2B50", Offset = "0x81C2B50", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = UnityEngine.UI.Graphic::set_color(v4, Color_arg);\n\treturn;\n")]
		public override void SetColor(Color color)
		{
			Image image = default(Image);
			Color color2 = default(Color);
			image.color = color2;
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x81C2B74", Offset = "0x81C2B74", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_image;\n\treturn v0.sprite;\n")]
		public override Sprite GetImage()
		{
			Image image = m_image;
			return image.sprite;
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x81C2B90", Offset = "0x81C2B90", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Behaviour::set_enabled(this.m_image, isActive);\n\treturn;\n")]
		public override void SetActive(bool isActive)
		{
			m_image.enabled = isActive;
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x81C2BAC", Offset = "0x81C2BAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public UnityImageView()
		{
		}
	}
}

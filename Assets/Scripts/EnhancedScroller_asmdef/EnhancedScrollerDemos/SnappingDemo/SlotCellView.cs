using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SnappingDemo
{
	[Token(Token = "0x2000064")]
	public class SlotCellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x38")]
		public Image slotImage;

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0x402E0E4", Offset = "0x402E0E4", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tgoto L_0023;\nL_0023:\n\tv71 = UnityEngine.Object::op_Equality(data.sprite, 0);\n\tv72 = ~v71;\n\tif (v72) goto L_003D;\n\t// -1 MakeStruct Color_arg @ V0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), 0, 0, 0, 0\n\tv58 = UnityEngine.UI.Graphic::set_color(v58, Color_arg);\n\treturn;\nL_003D:\n\tUnityEngine.UI.Image::set_sprite(this.slotImage, data.sprite);\n\t// -1 MakeStruct Color_arg @ V0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 1f, 1f, 1f, 1f\n\tv59 = UnityEngine.UI.Graphic::set_color(v59, Color_arg);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetData(SlotData data)
		{
			if (data.sprite == null)
			{
				Color color = default(Color);
				color.r = 0f;
				color.g = 0f;
				color.b = 0f;
				color.a = 0f;
				Image image = default(Image);
				image.color = color;
			}
			else
			{
				slotImage.sprite = data.sprite;
				Color color2 = default(Color);
				color2.r = 1f;
				color2.g = 1f;
				color2.b = 1f;
				color2.a = 1f;
				Image image2 = default(Image);
				image2.color = color2;
			}
		}

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0x402E1D0", Offset = "0x402E1D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public SlotCellView()
		{
		}
	}
}

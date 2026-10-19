using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using Unco.UncoButtonSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.ShopSystem.Scripts.Ui.ShopGroups
{
	[Token(Token = "0x2000052")]
	public class ShopFilterController : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x20")]
		private Color m_activeColor;

		[SerializeField]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x30")]
		private Color m_passiveColor;

		[SerializeField]
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x40")]
		internal Image m_bgImage;

		[SerializeField]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x48")]
		private Color m_activeTextColor;

		[SerializeField]
		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x58")]
		private Color m_passiveTextColor;

		[SerializeField]
		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x68")]
		internal TextMeshProUGUI m_text;

		[SerializeField]
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x70")]
		private UncoButton m_button;

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x3C69484", Offset = "0x3C69484", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv59 = TMPro.TMP_Text::set_text(this.m_text, v41);\n\tv62 = new System.Action();\n\tSystem.Action::.ctor(v62, onClick, Il2CppMethodInfo);\n\tUnco.UncoButtonSystem.UncoButton::AddListener(this.m_button, v62, 1, 0);\n\treturn;\n")]
		public void Init(string label, Action onClick)
		{
			string text = default(string);
			m_text.text = text;
			Action clickAction = onClick.Invoke;
			m_button.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x3C69544", Offset = "0x3C69544", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = TMPro.TMP_Text::set_text(v0, label);\n\treturn;\n")]
		public void SetLabel(string label)
		{
			TextMeshProUGUI textMeshProUGUI = default(TextMeshProUGUI);
			textMeshProUGUI.text = label;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x3C69568", Offset = "0x3C69568", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = active == 0;\n\tv27 = ~v20;\n\tv28 = ~v27;\n\tif (v28) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv98 = 0x2C;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv98 = 0x3C;\nL_FFFFFFFF:\n\tv157 = 0x28;\n\tgoto L_0028;\nL_FFFFFFFF:\n\tv157 = 0x38;\nL_FFFFFFFF:\n\tv51 = 0x24;\n\tgoto L_0034;\nL_FFFFFFFF:\n\tv51 = 0x34;\nL_FFFFFFFF:\n\tv166 = 0x20;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv166 = 0x30;\n\tv140 = active == 0;\n\tv171 = ~v140;\n\tv172 = ~v171;\n\tif (v172) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv175 = 0x54;\n\tgoto L_0057;\nL_FFFFFFFF:\n\tv175 = 0x64;\nL_FFFFFFFF:\n\tv128 = 0x50;\n\tgoto L_0060;\nL_FFFFFFFF:\n\tv128 = 0x60;\nL_FFFFFFFF:\n\tv122 = 0x4C;\n\tgoto L_006C;\nL_FFFFFFFF:\n\tv122 = 0x5C;\nL_FFFFFFFF:\n\tv190 = 0x48;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv190 = 0x58;\nL_001F:\n\tv101 = ~v20;\n\tv102 = ~v101;\n\tif (v102) goto L_FFFFFFFF;\nL_0028:\n\tv160 = ~v20;\n\tv161 = ~v160;\n\tif (v161) goto L_FFFFFFFF;\nL_0034:\n\tv57 = ~v20;\n\tv54 = ~v57;\n\tif (v54) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v166 @ X8_v4 (System.Int32)], [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v51 @ X10_v4 (System.Int32)], [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v157 @ X9_v4 (System.Int32)], [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v98 @ X8_v3 (System.Int32)]\n\tv167 = UnityEngine.UI.Graphic::set_color(this.m_bgImage, Color_arg);\nL_0057:\n\tv178 = ~v140;\n\tv179 = ~v178;\n\tif (v179) goto L_FFFFFFFF;\nL_0060:\n\tv184 = ~v140;\n\tv185 = ~v184;\n\tif (v185) goto L_FFFFFFFF;\nL_006C:\n\tv126 = ~v140;\n\tv124 = ~v126;\n\tif (v124) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v190 @ X8_v8 (System.Int32)], [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v122 @ X10_v7 (System.Int32)], [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v128 @ X9_v8 (System.Int32)], [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v175 @ X8_v7 (System.Int32)]\n\tv84 = TMPro.TMP_Text::set_color(v84, Color_arg);\n\treturn;\n")]
		public void SetActive(bool active)
		{
			//IL_01c7: Expected F4, but got I
			//IL_01dc: Expected F4, but got I
			//IL_01f1: Expected F4, but got I
			//IL_0206: Expected F4, but got I
			//IL_029b: Expected F4, but got I
			//IL_02b0: Expected F4, but got I
			//IL_02c5: Expected F4, but got I
			//IL_02da: Expected F4, but got I
			bool flag = !active;
			if (!flag)
			{
				int num = 44;
			}
			else
			{
				int num = 60;
			}
			if (!flag)
			{
				int num2 = 40;
			}
			else
			{
				int num2 = 56;
			}
			if (!flag)
			{
				int num3 = 36;
			}
			else
			{
				int num3 = 52;
			}
			if (!flag)
			{
				int num4 = 32;
			}
			else
			{
				int num4 = 48;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v166 @ X8_v4 (System.Int32)]");
			Color color = default(Color);
			color.r = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v51 @ X10_v4 (System.Int32)]");
			color.g = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v157 @ X9_v4 (System.Int32)]");
			color.b = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v98 @ X8_v3 (System.Int32)]");
			color.a = 0f;
			m_bgImage.color = color;
			bool flag2 = !active;
			if (!flag2)
			{
				int num5 = 84;
			}
			else
			{
				int num5 = 100;
			}
			if (!flag2)
			{
				int num6 = 80;
			}
			else
			{
				int num6 = 96;
			}
			if (!flag2)
			{
				int num7 = 76;
			}
			else
			{
				int num7 = 92;
			}
			if (!flag2)
			{
				int num8 = 72;
			}
			else
			{
				int num8 = 88;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v190 @ X8_v8 (System.Int32)]");
			Color color2 = default(Color);
			color2.r = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v122 @ X10_v7 (System.Int32)]");
			color2.g = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v128 @ X9_v8 (System.Int32)]");
			color2.b = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopFilterController)+v175 @ X8_v7 (System.Int32)]");
			color2.a = 0f;
			TextMeshProUGUI textMeshProUGUI = default(TextMeshProUGUI);
			textMeshProUGUI.color = color2;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x3C69640", Offset = "0x3C69640", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ShopFilterController()
		{
		}
	}
}

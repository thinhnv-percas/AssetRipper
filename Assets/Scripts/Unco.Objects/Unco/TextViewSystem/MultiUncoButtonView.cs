using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.UncoButtonSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000017")]
	public class MultiUncoButtonView : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton[] m_buttons;

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x81C2358", Offset = "0x81C2358", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv61.deactivateAfterClick = deactivateAfterClick;\n\tv61.<>4__this = this;\n\tv61.clickAction = clickAction;\n\tv88 = v61.deactivateAfterClick != 1;\n\tif (v88) goto L_006C;\n\tv201 = this.m_buttons;\n\tv270 = v201.Length < 1;\n\tif (v270) goto L_006C;\n\tv206 = 0;\n\tUnityEngine.UI.Selectable::set_interactable(v192.Button, 1);\n\tv206 = v206 + 1;\n\tv269 = v206 < v201.Length;\n\tif (v269) goto L_0055;\nL_006C:\n\tv293 = ~removeAllListener;\n\tif (v293) goto L_0099;\n\tv202 = this.m_buttons;\n\tv297 = v202.Length < 1;\n\tif (v297) goto L_0099;\n\tv208 = 0;\n\tv195 = v194.Button;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v195.onClick);\n\tv208 = v208 + 1;\n\tv296 = v208 < v202.Length;\n\tif (v296) goto L_0080;\nL_0099:\n\tv209 = this.m_buttons;\n\tv334 = v209.Length < 1;\n\tif (v334) goto L_00E1;\n\tv189 = 0;\n\tv375 = new System.Action();\n\tSystem.Action::.ctor(v375, v61, Il2CppMethodInfo);\n\tv61.<>9__0 = v375;\n\tv204 = v375;\nL_00C5:\n\tUnco.UncoButtonSystem.UncoButton::AddListener(v209[v189 @ X24_v9 (System.Int32)], v204, removeAllListener, 0);\n\tv189 = v189 + 1;\n\tv346 = v189 < v209.Length;\n\tif (v346) goto L_00B0;\nL_00E1:\n\treturn;\nL_0026:\n\tv61 = new Unco.TextViewSystem.MultiUncoButtonView+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v61);\nL_0055:\n\tv192 = v201[v206 @ X23_v11 (System.Int32)];\nL_0080:\n\tv194 = v202[v208 @ X23_v8 (System.Int32)];\nL_00B0:\n\tv204 = v61.<>9__0;\n\tv372 = v61.<>9__0 == 0;\n\tv373 = ~v372;\n\tif (v373) goto L_00C5;\n")]
		public void AddListener(Action clickAction, bool removeAllListener = true, bool deactivateAfterClick = true)
		{
			if (deactivateAfterClick)
			{
				UncoButton[] buttons = m_buttons;
				if (buttons.Length >= 1)
				{
					int num = 0;
					do
					{
						UncoButton uncoButton = buttons[num];
						uncoButton.Button.interactable = true;
						num++;
					}
					while (num < buttons.Length);
				}
			}
			if (removeAllListener)
			{
				UncoButton[] buttons2 = m_buttons;
				if (buttons2.Length >= 1)
				{
					int num2 = 0;
					do
					{
						UncoButton uncoButton2 = buttons2[num2];
						Button button = uncoButton2.Button;
						button.onClick.RemoveAllListeners();
						num2++;
					}
					while (num2 < buttons2.Length);
				}
			}
			UncoButton[] buttons3 = m_buttons;
			if (buttons3.Length < 1)
			{
				return;
			}
			int num3 = 0;
			Action action = default(Action);
			do
			{
				Action clickAction2 = action;
				if (action == null)
				{
					clickAction2 = (action = delegate
					{
						if (deactivateAfterClick)
						{
							MultiUncoButtonView multiUncoButtonView = this;
							UncoButton[] buttons4 = multiUncoButtonView.m_buttons;
							if (buttons4.Length >= 1)
							{
								int num4 = 0;
								do
								{
									UncoButton uncoButton3 = buttons4[num4];
									uncoButton3.Button.interactable = false;
									num4++;
								}
								while (num4 < buttons4.Length);
							}
						}
						if (clickAction != null)
						{
							clickAction();
						}
					});
				}
				buttons3[num3].AddListener(clickAction2, removeAllListener, deactivateAfterClick: false);
				num3++;
			}
			while (num3 < buttons3.Length);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x81C2558", Offset = "0x81C2558", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_buttons;\n\tv28 = v14.Length < 1;\n\tif (v28) goto L_0039;\n\tv41 = 0;\n\tUnityEngine.UI.Selectable::set_interactable(v73.Button, isInteractable);\n\tv41 = v41 + 1;\n\tv102 = v41 < v14.Length;\n\tif (v102) goto L_001B;\nL_0039:\n\treturn;\nL_001B:\n\tv73 = v14[v41 @ X21_v5 (System.Int32)];\n")]
		public void SetInteractable(bool isInteractable)
		{
			UncoButton[] buttons = m_buttons;
			if (buttons.Length >= 1)
			{
				int num = 0;
				do
				{
					UncoButton uncoButton = buttons[num];
					uncoButton.Button.interactable = isInteractable;
					num++;
				}
				while (num < buttons.Length);
			}
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x81C25C8", Offset = "0x81C25C8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_buttons;\n\tv28 = v14.Length < 1;\n\tif (v28) goto L_003A;\n\tv38 = 0;\n\tv69 = v68.Button;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v69.onClick);\n\tv38 = v38 + 1;\n\tv97 = v38 < v14.Length;\n\tif (v97) goto L_001A;\nL_003A:\n\treturn;\nL_001A:\n\tv68 = v14[v38 @ X20_v5 (System.Int32)];\n")]
		public void RemoveAllListeners()
		{
			UncoButton[] buttons = m_buttons;
			if (buttons.Length >= 1)
			{
				int num = 0;
				do
				{
					UncoButton uncoButton = buttons[num];
					Button button = uncoButton.Button;
					button.onClick.RemoveAllListeners();
					num++;
				}
				while (num < buttons.Length);
			}
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x81C2638", Offset = "0x81C2638", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MultiUncoButtonView()
		{
		}
	}
}

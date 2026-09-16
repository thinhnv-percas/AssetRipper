using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tayx.Graphy.CustomizationScene
{
	[Token(Token = "0x2000043")]
	public class G_CUIColorPicker : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000469")]
		private sealed class _003C_003Ec__DisplayClass13_0
		{
			[Token(Token = "0x40020BE")]
			[FieldOffset(Offset = "0x10")]
			public Texture2D satvalTex;

			[Token(Token = "0x40020BF")]
			[FieldOffset(Offset = "0x18")]
			public Color[] satvalColors;

			[Token(Token = "0x40020C0")]
			[FieldOffset(Offset = "0x20")]
			public float Hue;

			[Token(Token = "0x40020C1")]
			[FieldOffset(Offset = "0x28")]
			public Color[] hueColors;

			[Token(Token = "0x40020C2")]
			[FieldOffset(Offset = "0x30")]
			public Action resetSatValTexture;

			[Token(Token = "0x40020C3")]
			[FieldOffset(Offset = "0x38")]
			public float Saturation;

			[Token(Token = "0x40020C4")]
			[FieldOffset(Offset = "0x3C")]
			public float Value;

			[Token(Token = "0x40020C5")]
			[FieldOffset(Offset = "0x40")]
			public GameObject result;

			[Token(Token = "0x40020C6")]
			[FieldOffset(Offset = "0x48")]
			public G_CUIColorPicker _003C_003E4__this;

			[Token(Token = "0x40020C7")]
			[FieldOffset(Offset = "0x50")]
			public GameObject hueGO;

			[Token(Token = "0x40020C8")]
			[FieldOffset(Offset = "0x58")]
			public Action dragH;

			[Token(Token = "0x40020C9")]
			[FieldOffset(Offset = "0x60")]
			public GameObject satvalGO;

			[Token(Token = "0x40020CA")]
			[FieldOffset(Offset = "0x68")]
			public Action dragSV;

			[Token(Token = "0x40020CB")]
			[FieldOffset(Offset = "0x70")]
			public Vector2 hueSz;

			[Token(Token = "0x40020CC")]
			[FieldOffset(Offset = "0x78")]
			public Action applyHue;

			[Token(Token = "0x40020CD")]
			[FieldOffset(Offset = "0x80")]
			public Action applySaturationValue;

			[Token(Token = "0x40020CE")]
			[FieldOffset(Offset = "0x88")]
			public GameObject hueKnob;

			[Token(Token = "0x40020CF")]
			[FieldOffset(Offset = "0x90")]
			public Action idle;

			[Token(Token = "0x40020D0")]
			[FieldOffset(Offset = "0x98")]
			public Vector2 satvalSz;

			[Token(Token = "0x40020D1")]
			[FieldOffset(Offset = "0xA0")]
			public GameObject satvalKnob;

			[Token(Token = "0x6001570")]
			[Address(RVA = "0xB11D84", Offset = "0xB11D84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass13_0()
			{
			}

			internal void _003CSetup_003Eb__0()
			{
				//IL_0064: Expected O, but got I
				//IL_0079: Expected F4, but got I
				//IL_008e: Expected F4, but got I
				//IL_00a3: Expected F4, but got I
				//IL_00b8: Expected F4, but got I
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				Color color = default(Color);
				bool flag2;
				do
				{
					int num4 = num2;
					int num5 = 0;
					bool flag;
					do
					{
						Color[] array = satvalColors;
						int num6 = num3 + num5;
						if (num6 < array.Length)
						{
							object obj = (long)(IntPtr)array + (long)num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+20]");
							color.r = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+24]");
							color.g = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+28]");
							color.b = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+2C]");
							color.a = 0f;
							satvalTex.SetPixel(num5, num, color);
							int num7 = num5 + 1;
							num4 += 16;
							flag = num5 < 1;
							num5 = num7;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (flag);
					int num8 = num + 1;
					num2 += 32;
					num3 += 2;
					flag2 = num <= 0;
					num = num8;
				}
				while (flag2);
				satvalTex.Apply();
			}

			internal void _003CSetup_003Eb__1()
			{
				//IL_001a: Expected I4, but got F4
				//IL_00ee: Expected O, but got I
				//IL_010a: Expected O, but got I
				//IL_0126: Expected O, but got I
				//IL_0145: Expected F4, but got O
				//IL_015a: Expected F4, but got I
				//IL_016f: Expected F4, but got I
				//IL_0184: Expected F4, but got I
				//IL_0191: Expected F4, but got O
				//IL_01a6: Expected F4, but got I
				//IL_01bb: Expected F4, but got I
				//IL_01d0: Expected F4, but got I
				//IL_0220: Expected O, but got I4
				int num = Mathf.Clamp((int)Hue, 0, 5);
				Color[] array = hueColors;
				if (num < array.Length)
				{
					int num2 = num + 1;
					int num3 = num2 * 715827883;
					int num4 = num3 >> 63;
					int num5 = num3 >> 32;
					int num6 = num5 + num4;
					int num7 = num6 * 6;
					int num8 = num2 - num7;
					if (num8 < array.Length)
					{
						object obj = (long)(IntPtr)array + 32L;
						int num9 = num << 4;
						object obj2 = (long)(IntPtr)obj + (long)num9;
						int num10 = num8 << 4;
						object obj3 = (long)(IntPtr)obj + (long)num10;
						float t = Hue - (float)num;
						Color a = default(Color);
						a.r = (float)obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X9_v6+4]");
						a.g = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X9_v6+8]");
						a.b = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X9_v6+C]");
						a.a = 0f;
						Color b = default(Color);
						b.r = (float)obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v12+4]");
						b.g = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v12+8]");
						b.b = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v12+C]");
						b.a = 0f;
						Color color = Color.Lerp(a, b, t);
						Color[] array2 = satvalColors;
						bool flag = array2.Length < 3;
						bool flag2 = !flag;
						object obj4 = array2.Length - 3;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							_ = color.g;
							_ = color.b;
							_ = color.a;
							resetSatValTexture();
							return;
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}

			internal void _003CSetup_003Eb__2()
			{
				//IL_0048: Expected F4, but got I
				//IL_005d: Expected F4, but got I
				//IL_0072: Expected F4, but got I
				//IL_0087: Expected F4, but got I
				//IL_00d3: Expected O, but got I4
				//IL_012c: Expected F4, but got I
				//IL_0141: Expected F4, but got I
				//IL_0156: Expected F4, but got I
				//IL_016b: Expected F4, but got I
				//IL_01b7: Expected O, but got I4
				//IL_0210: Expected F4, but got I
				//IL_0225: Expected F4, but got I
				//IL_023a: Expected F4, but got I
				//IL_024f: Expected F4, but got I
				//IL_029b: Expected O, but got I4
				//IL_02f4: Expected F4, but got I
				//IL_0309: Expected F4, but got I
				//IL_031e: Expected F4, but got I
				//IL_0333: Expected F4, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				object obj = default(object);
				float num = 1f - (float)obj;
				object obj2 = default(object);
				float num2 = 1f - (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Color[] array = satvalColors;
				if (array.Length != 0)
				{
					object obj3 = default(object);
					object obj4 = default(object);
					float num3 = (float)obj3 * (float)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+20]");
					Color color = default(Color);
					color.r = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+24]");
					color.g = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+28]");
					color.b = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+2C]");
					color.a = 0f;
					Color color2 = num3 * color;
					Color[] array2 = satvalColors;
					bool flag = array2.Length < 1;
					bool flag2 = !flag;
					object obj5 = array2.Length - 1;
					bool flag3 = obj5 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						float num4 = (float)obj * (float)obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+30]");
						Color color3 = default(Color);
						color3.r = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+34]");
						color3.g = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+38]");
						color3.b = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+3C]");
						color3.a = 0f;
						Color color4 = num4 * color3;
						Color[] array3 = satvalColors;
						bool flag5 = array3.Length < 2;
						bool flag6 = !flag5;
						object obj6 = array3.Length - 2;
						bool flag7 = obj6 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							float num5 = (float)obj3 * (float)obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+40]");
							Color color5 = default(Color);
							color5.r = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+44]");
							color5.g = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+48]");
							color5.b = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+4C]");
							color5.a = 0f;
							Color color6 = num5 * color5;
							Color[] array4 = satvalColors;
							bool flag9 = array4.Length < 3;
							bool flag10 = !flag9;
							object obj7 = array4.Length - 3;
							bool flag11 = obj7 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								float num6 = (float)obj * (float)obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+50]");
								Color color7 = default(Color);
								color7.r = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+54]");
								color7.g = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+58]");
								color7.b = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+5C]");
								color7.a = 0f;
								Color color8 = num6 * color7;
								Color color9 = color2 + color4;
								Color color10 = color9 + color6;
								Color color11 = color10 + color8;
								Image component = result.GetComponent<Image>();
								component.color = color11;
								G_CUIColorPicker g_CUIColorPicker = _003C_003E4__this;
								Color color12 = default(Color);
								color12.r = g_CUIColorPicker._color.r;
								color12.g = g_CUIColorPicker._color.g;
								color12.b = g_CUIColorPicker._color.b;
								color12.a = g_CUIColorPicker._color.a;
								if (color12 != color11)
								{
									G_CUIColorPicker g_CUIColorPicker2 = _003C_003E4__this;
									float value = g_CUIColorPicker2.alphaSlider.value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
									G_CUIColorPicker g_CUIColorPicker3 = _003C_003E4__this;
									float r = default(float);
									if (g_CUIColorPicker3._onValueChange != null)
									{
										Color obj8 = default(Color);
										obj8.r = r;
										obj8.g = color11.g;
										obj8.b = color11.b;
										obj8.a = color11.a;
										g_CUIColorPicker3._onValueChange(obj8);
										g_CUIColorPicker3 = _003C_003E4__this;
									}
									g_CUIColorPicker3._color.r = r;
									g_CUIColorPicker3._color.g = color11.g;
									g_CUIColorPicker3._color.a = color11.a;
									G_CUIColorPicker g_CUIColorPicker4 = _003C_003E4__this;
									Color color13 = default(Color);
									color13.r = g_CUIColorPicker4._color.r;
									color13.g = g_CUIColorPicker4._color.g;
									color13.b = g_CUIColorPicker4._color.b;
									color13.a = g_CUIColorPicker4._color.a;
									g_CUIColorPicker4.alphaSliderBGImage.color = color13;
								}
								return;
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}

			internal void _003CSetup_003Eb__3()
			{
				Vector2 vector = default(Vector2);
				if (!Input.GetMouseButtonDown(0))
				{
					return;
				}
				G_CUIColorPicker g_CUIColorPicker;
				Action update;
				if (GetLocalMouse(hueGO, out vector))
				{
					g_CUIColorPicker = _003C_003E4__this;
					update = dragH;
				}
				else
				{
					if (!GetLocalMouse(satvalGO, out vector))
					{
						return;
					}
					g_CUIColorPicker = _003C_003E4__this;
					update = dragSV;
				}
				g_CUIColorPicker._update = update;
			}

			internal void _003CSetup_003Eb__4()
			{
				//IL_0063: Expected O, but got I4
				//IL_0092: Expected F4, but got O
				Vector2 vector = default(Vector2);
				bool localMouse = GetLocalMouse(hueGO, out vector);
				object obj = default(object);
				float num = (float)obj / hueSz.y;
				float hue = num * 6f;
				Hue = hue;
				applyHue();
				applySaturationValue();
				Transform transform = hueKnob.transform;
				Transform transform2 = hueKnob.transform;
				Vector3 localPosition = transform2.localPosition;
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Vector2 vector2 = default(Vector2);
				vector2.x = 0f;
				object obj3 = default(object);
				vector2.y = (float)obj3;
				Vector3 localPosition2 = vector2;
				transform.localPosition = localPosition2;
				if (Input.GetMouseButtonUp(0))
				{
					G_CUIColorPicker g_CUIColorPicker = _003C_003E4__this;
					g_CUIColorPicker._update = idle;
				}
			}

			internal void _003CSetup_003Eb__5()
			{
				//IL_0048: Expected F4, but got O
				bool localMouse = GetLocalMouse(satvalGO, out var vector);
				float saturation = vector.x / satvalSz.x;
				Saturation = saturation;
				object obj = default(object);
				float value = (float)obj / satvalSz.y;
				Value = value;
				applySaturationValue();
				Transform transform = satvalKnob.transform;
				Vector2 vector2 = default(Vector2);
				vector2.x = vector.x;
				vector2.y = (float)obj;
				Vector3 localPosition = vector2;
				transform.localPosition = localPosition;
				if (Input.GetMouseButtonUp(0))
				{
					G_CUIColorPicker g_CUIColorPicker = _003C_003E4__this;
					g_CUIColorPicker._update = idle;
				}
			}
		}

		[SerializeField]
		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x18")]
		private Slider alphaSlider;

		[SerializeField]
		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x20")]
		private Image alphaSliderBGImage;

		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x28")]
		private Color _color;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x38")]
		internal Action<Color> _onValueChange;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x40")]
		private Action _update;

		[Token(Token = "0x17000045")]
		public Color Color
		{
			[Token(Token = "0x60001E0")]
			[Address(RVA = "0xB111C8", Offset = "0xB111C8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._color;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _color;
			}
			[Token(Token = "0x60001E1")]
			[Address(RVA = "0xB0FBF8", Offset = "0xB0FBF8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.CustomizationScene.G_CUIColorPicker::Setup(this, value);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Setup(value);
			}
		}

		[Token(Token = "0x60001E2")]
		[Address(RVA = "0xB118E0", Offset = "0xB118E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._onValueChange = onValueChange;\n\treturn;\n")]
		public void SetOnValueChangeCallback(Action<Color> onValueChange)
		{
			_onValueChange = onValueChange;
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0xB118E8", Offset = "0xB118E8", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv49 = *([1ED6618]);\n\tv50 = *([v49 @ X8_v16]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, s, v, methodInfo, v53, v54, v55, v56, color, v0, v2, v3, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([2022524]) = v63;\nL_0029:\n\t// 41 NewArr v68 @ X0_v3 (System.Single[]), typeof(System.Single[]), 3\n\tv72 = v68.Length == 0;\n\tif (v72) goto L_00DB;\n\tv137 = v68.Length == 1;\n\tv68[0] = color;\n\tif (v137) goto L_00DB;\n\tv164 = v68.Length < 2;\n\tv122 = ~v164;\n\tv118 = v68.Length - 2;\n\tv110 = v118 == 0;\n\tv68[1] = color.g;\n\tv165 = ~v122;\n\tv90 = v165 | v110;\n\tif (v90) goto L_00DB;\n\tv68[2] = color.b;\n\tgoto L_0057;\n\tv233 = *([v229 @ X0_v9+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_0057;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v229, v66, v, methodInfo, v53, v54, v55, v56, color, v0, v2, v3, v57, v58, v59, v60);\nL_0057:\n\tv80 = UnityEngine.Mathf::Min(v68);\n\t// 91 NewArr v125 @ X0_v13 (System.Single[]), typeof(System.Single[]), 3\n\tv161 = v125.Length == 0;\n\tif (v161) goto L_00DB;\n\tv152 = v125.Length == 1;\n\tv125[0] = color;\n\tif (v152) goto L_00DB;\n\tv243 = v125.Length < 2;\n\tv159 = ~v243;\n\tv157 = v125.Length - 2;\n\tv153 = v157 == 0;\n\tv125[1] = color.g;\n\tv244 = ~v159;\n\tv143 = v244 | v153;\n\tif (v143) goto L_00DB;\n\tv125[2] = color.b;\n\tv245 = UnityEngine.Mathf::Max(v125);\n\tv247 = v245 - v80;\n\tv253 = v247 == 0;\n\tif (v253) goto L_00B8;\n\tv268 = v245 != color;\n\tif (v268) goto L_00AE;\n\tgoto L_009F;\n\tv303 = *([v296 @ X0_v15+E0]);\n\tv304 = v303 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_009F;\n\tv307 = \"il2cpp_codegen_runtime_class_init\"(v296, v183, v, methodInfo, v53, v54, v55, v56, v258, v0, v2, v3, v57, v58, v59, v60);\nL_009F:\n\tv308 = color.g - color.b;\n\tv309 = v308 / v247;\n\tv269 = UnityEngine.Mathf::Repeat(v309, 6f);\n\tgoto L_00B8;\nL_00AE:\n\tv272 = v245 != color.g;\n\tif (v272) goto L_00B4;\n\tv310 = color.b - color;\n\tv316 = v310 / v247;\n\tgoto L_00B7;\nL_00B4:\n\tv313 = color - color.g;\n\tv316 = v313 / v247;\nL_00B7:\n\tv269 = v316 + v292;\nL_00B8:\n\t*([h @ X0 (System.Single&)]) = v269;\n\tv181 = v247 / v245;\n\tv169 = v245 != 0;\n\tif (v169) goto L_00C9;\n\tgoto L_00C9;\nL_00C9:\n\t*([s @ X1 (System.Single&)]) = v181;\n\t*([v @ X2 (System.Single&)]) = v245;\n\treturn;\nL_00DB:\n\tv163 = new System.IndexOutOfRangeException();\n\tthrow v163;\n\tthrow System.NullReferenceException;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void RGBToHSV(Color color, out float h, out float s, out float v)
		{
			//IL_00a4: Expected O, but got I4
			//IL_01ad: Expected O, but got I4
			//IL_0387: Expected Ref, but got F4
			//IL_03d4: Expected Ref, but got F4
			//IL_03dc: Expected Ref, but got F4
			h = default(float);
			s = default(float);
			v = default(float);
			float[] array = new float[3];
			if (array.Length != 0)
			{
				bool flag = array.Length == 1;
				Color color2 = default(Color);
				array[0] = color2.r;
				if (!flag)
				{
					bool flag2 = array.Length < 2;
					bool flag3 = !flag2;
					object obj = array.Length - 2;
					bool flag4 = obj == null;
					array[1] = color.g;
					bool flag5 = !flag3;
					if (!(flag5 || flag4))
					{
						array[2] = color.b;
						float num = Mathf.Min(array);
						float[] array2 = new float[3];
						if (array2.Length != 0)
						{
							bool flag6 = array2.Length == 1;
							array2[0] = color2.r;
							if (!flag6)
							{
								bool flag7 = array2.Length < 2;
								bool flag8 = !flag7;
								object obj2 = array2.Length - 2;
								bool flag9 = obj2 == null;
								array2[1] = color.g;
								bool flag10 = !flag8;
								if (!(flag10 || flag9))
								{
									array2[2] = color.b;
									float num2 = Mathf.Max(array2);
									float num3 = num2 - num;
									bool flag11 = num3 == 0f;
									float num4 = 0f;
									if (!flag11)
									{
										if (num2 == color2.r)
										{
											float num5 = color.g - color.b;
											float t = num5 / num3;
											num4 = Mathf.Repeat(t, 6f);
										}
										else
										{
											float num7;
											float num8;
											if (num2 == color.g)
											{
												float num6 = color.b - color2.r;
												num7 = num6 / num3;
												num8 = 2f;
											}
											else
											{
												float num9 = color2.r - color.g;
												num7 = num9 / num3;
												num8 = 4f;
											}
											num4 = num7 + num8;
										}
									}
									ref float reference = ref *(float*)num4;
									float num10 = num3 / num2;
									if (num2 == 0f)
									{
										num10 = 0f;
									}
									ref float reference2 = ref *(float*)num10;
									ref float reference3 = ref *(float*)num2;
									return;
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0xB11AB4", Offset = "0xB11AB4", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EA85C8]);\n\tv33 = *([v32 @ X8_v14]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, result, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2022525]) = v51;\nL_0020:\n\tv57 = UnityEngine.GameObject::get_transform(go);\n\tv67 = v57 == 0;\n\tif (v67) goto L_00AC;\n\tv77 = *([v57 @ X0_v9 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v77) goto L_00B2;\n\tv63 = UnityEngine.Input::get_mousePosition();\n\tv63 = UnityEngine.Transform::InverseTransformPoint(v57, v63);\n\tv186 = UnityEngine.RectTransform::get_rect(v57);\n\tv196 = 0x10CD04C(&v186 @ V0_v6 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v186, v186.m_YMin, v186.m_Width, v186.m_Height, v45, v46, v47, v48);\n\tv200 = UnityEngine.RectTransform::get_rect(v57);\n\tv210 = 0x10CD0E8(&v200 @ V0_v7 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v200, v200.m_YMin, v200.m_Width, v200.m_Height, v45, v46, v47, v48);\n\tgoto L_006C;\n\tv218 = *([v214 @ X0_v18+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_006C;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v214, v206, methodInfo, v36, v37, v38, v39, v40, v200, v201, v202, v203, v45, v46, v47, v48);\nL_006C:\n\tv227 = UnityEngine.Mathf::Clamp(v63, v186, v200);\n\t*([result @ X1 (UnityEngine.Vector2&)]) = v227;\n\tv230 = UnityEngine.RectTransform::get_rect(v57);\n\tv240 = 0x10CD04C(&v230 @ V0_v10 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v230, v230.m_YMin, v230.m_Width, v230.m_Height, v45, v46, v47, v48);\n\tv244 = UnityEngine.RectTransform::get_rect(v57);\n\tv254 = 0x10CD0E8(&v244 @ V0_v11 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v244, v244.m_YMin, v244.m_Width, v244.m_Height, v45, v46, v47, v48);\n\tv259 = UnityEngine.Mathf::Clamp(v63.y, v230.m_YMin, v244.m_YMin);\n\t*([result @ X1 (UnityEngine.Vector2&)+4]) = v259;\n\tv262 = UnityEngine.RectTransform::get_rect(v57);\n\tv266 = 0x10CD20C(&v262 @ V0_v14 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v63, v63.y, v63.z, v262.m_Height, v45, v46, v47, v48);\n\treturnVal2 = v266 & 1;\n\treturn returnVal2;\nL_00AC:\n\tv63 = UnityEngine.Input::get_mousePosition();\n\tthrow System.NullReferenceException;\nL_00B2:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static bool GetLocalMouse(GameObject go, out Vector2 result)
		{
			//IL_019d: Expected I4, but got O
			//IL_00eb: Expected Ref, but got F4
			result = default(Vector2);
			Transform transform = go.transform;
			Vector3 mousePosition;
			if ((object)transform != null)
			{
				if ((object)transform.GetType() == typeof(RectTransform))
				{
					mousePosition = Input.mousePosition;
					mousePosition = transform.InverseTransformPoint(mousePosition);
					Rect rect = ((RectTransform)transform).rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD04C (inside UnityEngine.Rect::MinMaxRect +0xB0)");
					Rect rect2 = ((RectTransform)transform).rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD0E8 (inside UnityEngine.Rect::MinMaxRect +0x14C)");
					float num = Mathf.Clamp(mousePosition.x, rect.x, rect2.x);
					ref Vector2 reference = ref *(Vector2*)num;
					Rect rect3 = ((RectTransform)transform).rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD04C (inside UnityEngine.Rect::MinMaxRect +0xB0)");
					Rect rect4 = ((RectTransform)transform).rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD0E8 (inside UnityEngine.Rect::MinMaxRect +0x14C)");
					float num2 = Mathf.Clamp(mousePosition.y, rect3.y, rect4.y);
					Rect rect5 = ((RectTransform)transform).rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD20C (inside UnityEngine.Rect::MinMaxRect +0x270)");
					object obj = default(object);
					return (byte)((ulong)(long)(IntPtr)obj & 1uL) != 0;
				}
				InvalidCastException ex = new InvalidCastException();
				return (byte)(int)ex != 0;
			}
			mousePosition = Input.mousePosition;
			throw new NullReferenceException();
		}

		[Token(Token = "0x60001E5")]
		[Address(RVA = "0xB11C94", Offset = "0xB11C94", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECDDF8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, returnVal1, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022526]) = v38;\nL_0019:\n\tv44 = UnityEngine.GameObject::get_transform(go);\n\tv108 = *([v44 @ X0_v8 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v108) goto L_0049;\n\tv119 = *([v44 @ X0_v8 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v119) goto L_0049;\n\treturnVal2 = UnityEngine.RectTransform::get_rect(v44);\n\tv152 = 0x10CD198(&returnVal2 @ V0_v1 (UnityEngine.Vector2), 0, v22, v23, v24, v25, v26, v27, returnVal2, returnVal2.y, *([returnVal2 @ V0_v1 (UnityEngine.Vector2)+8]), *([returnVal2 @ V0_v1 (UnityEngine.Vector2)+C]), v32, v33, v34, v35);\n\treturn returnVal2;\nL_0049:\n\tthrow System.InvalidCastException;\n\tv81 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Vector2 GetWidgetSize(GameObject go)
		{
			Transform transform = go.transform;
			if ((object)transform.GetType() == typeof(RectTransform) && (object)transform.GetType() == typeof(RectTransform))
			{
				Vector2 rect = (Vector2)((RectTransform)transform).rect;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD198 (inside UnityEngine.Rect::MinMaxRect +0x1FC)");
				return rect;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0xB11D44", Offset = "0xB11D44", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Component::get_transform(this);\n\tv16 = UnityEngine.Transform::Find(v11, name);\n\treturnVal2 = UnityEngine.Component::get_gameObject(v16);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GameObject GO(string name)
		{
			Transform transform = base.transform;
			Transform transform2 = transform.Find(name);
			return transform2.gameObject;
		}

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0xB111D4", Offset = "0xB111D4", Length = "0x70C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0028;\n\tv48 = *([1EB65D0]);\n\tv49 = *([v48 @ X8_v53]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, methodInfo, v52, v53, v54, v55, v56, v57, inputColor, v0, v2, v3, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([2022527]) = v64;\nL_0028:\n\tv68 = new Tayx.Graphy.CustomizationScene.G_CUIColorPicker+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v68);\n\tv68.<>4__this = this;\n\tv331 = UnityEngine.UI.Slider::set_value(this.alphaSlider, Color_arg.a);\n\tv425 = UnityEngine.UI.Graphic::set_color(this.alphaSliderBGImage, Color_arg);\n\tv430 = Tayx.Graphy.CustomizationScene.G_CUIColorPicker::GO(this, \"SaturationValue\");\n\tv68.satvalGO = v430;\n\tv581 = Tayx.Graphy.CustomizationScene.G_CUIColorPicker::GO(this, \"SaturationValue/Knob\");\n\tv68.satvalKnob = v581;\n\tv589 = Tayx.Graphy.CustomizationScene.G_CUIColorPicker::GO(this, \"Hue\");\n\tv68.hueGO = v589;\n\tv594 = Tayx.Graphy.CustomizationScene.G_CUIColorPicker::GO(this, \"Hue/Knob\");\n\tv68.hueKnob = v594;\n\tv678 = Tayx.Graphy.CustomizationScene.G_CUIColorPicker::GO(this, \"Result\");\n\tv68.result = v678;\n\t// 100 NewArr v681 @ X0_v26 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), 6\n\tv254 = UnityEngine.Color::get_red();\n\tv545 = v681.Length == 0;\n\tif (v545) goto L_0295;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+20]) = v254;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+24]) = v254.g;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+28]) = v254.b;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+2C]) = v254.a;\n\tv528 = UnityEngine.Color::get_yellow();\n\tv682 = v681.Length < 1;\n\tv518 = ~v682;\n\tv511 = v681.Length - 1;\n\tv497 = v511 == 0;\n\tv683 = ~v518;\n\tv462 = v683 | v497;\n\tif (v462) goto L_0295;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+30]) = v528;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+34]) = v528.g;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+38]) = v528.b;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+3C]) = v528.a;\n\tv529 = UnityEngine.Color::get_green();\n\tv684 = v681.Length < 2;\n\tv519 = ~v684;\n\tv512 = v681.Length - 2;\n\tv498 = v512 == 0;\n\tv685 = ~v519;\n\tv463 = v685 | v498;\n\tif (v463) goto L_0295;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+40]) = v529;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+44]) = v529.g;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+48]) = v529.b;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+4C]) = v529.a;\n\tv530 = UnityEngine.Color::get_cyan();\n\tv686 = v681.Length < 3;\n\tv520 = ~v686;\n\tv513 = v681.Length - 3;\n\tv499 = v513 == 0;\n\tv687 = ~v520;\n\tv464 = v687 | v499;\n\tif (v464) goto L_0295;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+50]) = v530;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+54]) = v530.g;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+58]) = v530.b;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+5C]) = v530.a;\n\tv531 = UnityEngine.Color::get_blue();\n\tv688 = v681.Length < 4;\n\tv521 = ~v688;\n\tv514 = v681.Length - 4;\n\tv500 = v514 == 0;\n\tv689 = ~v521;\n\tv465 = v689 | v500;\n\tif (v465) goto L_0295;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+60]) = v531;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+64]) = v531.g;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+68]) = v531.b;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+6C]) = v531.a;\n\tv532 = UnityEngine.Color::get_magenta();\n\tv690 = v681.Length < 5;\n\tv228 = ~v690;\n\tv221 = v681.Length - 5;\n\tv207 = v221 == 0;\n\tv691 = ~v228;\n\tv173 = v691 | v207;\n\tif (v173) goto L_0295;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+70]) = v532;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+74]) = v532.g;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+78]) = v532.b;\n\t*([v681 @ X0_v26 (UnityEngine.Color[])+7C]) = v532.a;\n\tv68.hueColors = v681;\n\t// 229 NewArr v694 @ X0_v34 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), 4\n\tv169 = 0;\n\tv274 = 0x10105A8(&v169 @ stack_-90_v4, 0, v52, v53, v54, v55, v56, v57, 0, 0, 0, v532.a, v58, v59, v60, v61);\n\tv546 = v694.Length == 0;\n\tif (v546) goto L_0295;\n\t*([v694 @ X0_v34 (UnityEngine.Color[])+20]) = 0;\n\tv161 = 0;\n\tv543 = 0x10105A8(&v161 @ stack_-A0_v4, 0, v52, v53, v54, v55, v56, v57, 0, 0, 0, v532.a, v58, v59, v60, v61);\n\tv698 = v694.Length < 1;\n\tv522 = ~v698;\n\tv515 = v694.Length - 1;\n\tv501 = v515 == 0;\n\tv699 = ~v522;\n\tv466 = v699 | v501;\n\tif (v466) goto L_0295;\n\t*([v694 @ X0_v34 (UnityEngine.Color[])+30]) = 0;\n\tv153 = 0;\n\tv275 = 0x10105A8(&v153 @ stack_-B0_v4, 0, v52, v53, v54, v55, v56, v57, 1f, 1f, 1f, v532.a, v58, v59, v60, v61);\n\tv702 = v694.Length < 2;\n\tv229 = ~v702;\n\tv222 = v694.Length - 2;\n\tv208 = v222 == 0;\n\tv703 = ~v229;\n\tv174 = v703 | v208;\n\tif (v174) goto L_0295;\n\t*([v694 @ X0_v34 (UnityEngine.Color[])+40]) = 0;\n\tv249 = v68.hueColors;\n\tv547 = v249.Length == 0;\n\tif (v547) goto L_0295;\n\tv704 = v694.Length < 3;\n\tv523 = ~v704;\n\tv516 = v694.Length - 3;\n\tv502 = v516 == 0;\n\tv705 = ~v523;\n\tv467 = v705 | v502;\n\tif (v467) goto L_0295;\n\t*([v694 @ X0_v34 (UnityEngine.Color[])+50]) = *([v249 @ X9_v6 (UnityEngine.Color[])+20]);\n\tv68.satvalColors = v694;\n\tv709 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v709, 1, 7);\nL_0146:\n\tv297 = v68.hueColors;\n\tv139 = v242 + 1;\n\tv719 = v139 * 0x2AAAAAAB;\n\tv126 = v719 >> 0x3F;\n\tv720 = v719 >> 0x20;\n\tv721 = v720 + v126;\n\tv548 = v721 * 6;\n\tv251 = v139 - v548;\n\tv722 = v251 < v297.Length;\n\tv231 = ~v722;\n\tif (v231) goto L_0295;\n\tv122 = v251 << 4;\n\tv298 = v297 + v122;\n\t// 359 MakeStruct v118 @ AGGB1151C_3_v5 (UnityEngine.Color), typeof(UnityEngine.Color), [v298 @ X8_v31+20], v297[v251 @ X9_v11 (System.Int32)].g (System.Single), v297[v251 @ X9_v11 (System.Int32)].b (System.Single), v297[v251 @ X9_v11 (System.Int32)].a (System.Single)\n\tUnityEngine.Texture2D::SetPixel(v709, 0, v139, v118);\n\tv242 = v242 + 1;\n\tv176 = v242 < 6;\n\tif (v176) goto L_0146;\n\tUnityEngine.Texture2D::Apply(v709);\n\tv728 = UnityEngine.GameObject::GetComponent(v68.hueGO);\n\tv169 = 0;\n\tv735 = 0x10CCF64(&v169 @ stack_-90_v4, 0, v139, 0, v54, v55, v56, v57, 0, 0.5f, 1f, 6f, v58, v59, v60, v61);\n\tv153 = 0;\n\tv740 = 0x1588A6C(&v153 @ stack_-B0_v4, 0, v139, 0, v54, v55, v56, v57, 0.5f, 0.5f, 1f, 6f, v58, v59, v60, v61);\n\t// 410 MakeStruct v103 @ AGGB115A8_1_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v741 @ stack_-8C, 0, v742 @ stack_-84\n\t// 411 MakeStruct v100 @ AGGB115A8_2_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v743 @ stack_-AC\n\tv277 = UnityEngine.Sprite::Create(v709, v103, v100);\n\tUnityEngine.UI.Image::set_sprite(v728, v277);\n\tv380 = Tayx.Graphy.CustomizationScene.G_CUIColorPicker::GetWidgetSize(v68.hueGO);\n\tv68.hueSz = v380;\n\tv68.hueSz.y = v380.y;\n\tv750 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v750, 2, 2);\n\tv68.satvalTex = v750;\n\tv752 = UnityEngine.GameObject::GetComponent(v68.satvalGO);\n\tv161 = 0;\n\tv759 = 0x10CCF64(&v161 @ stack_-A0_v4, 0, 2, 0, v54, v55, v56, v57, 0.5f, 0.5f, 1f, 1f, 0, v743, v60, v61);\n\tv760 = &v35 @ stack_-10_v2 - 0x38;\n\t*([v34 @ X29_v1-38]) = 0;\n\tv764 = 0x1588A6C(v760, 0, 2, 0, v54, v55, v56, v57, 0.5f, 0.5f, 1f, 1f, 0, v743, v60, v61);\n\t// 463 MakeStruct v97 @ AGGB11654_1_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v765 @ stack_-9C, 0, v766 @ stack_-94\n\t// 464 MakeStruct v94 @ AGGB11654_2_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), [v34 @ X29_v1-38], [v34 @ X29_v1-34]\n\tv278 = UnityEngine.Sprite::Create(v68.satvalTex, v97, v94);\n\tUnityEngine.UI.Image::set_sprite(v752, v278);\n\tv773 = new System.Action();\n\tSystem.Action::.ctor(v773, v68, Il2CppMethodInfo);\n\tv68.resetSatValTexture = v773;\n\tv781 = Tayx.Graphy.CustomizationScene.G_CUIColorPicker::GetWidgetSize(v68.satvalGO);\n\tv68.satvalSz = v781;\n\tv68.satvalSz.y = v781.y;\n\tv783 = v68 + 0x20;\n\tv784 = v68 + 0x38;\n\tv785 = v68 + 0x3C;\n\tTayx.Graphy.CustomizationScene.G_CUIColorPicker::RGBToHSV(Color_arg, v783, v784, v785);\n\tv787 = new System.Action();\n\tSystem.Action::.ctor(v787, v68, Il2CppMethodInfo);\n\tv68.applyHue = v787;\n\tv795 = new System.Action();\n\tSystem.Action::.ctor(v795, v68, Il2CppMethodInfo);\n\tv68.applySaturationValue = v795;\n\tSystem.Action::Invoke(v68.applyHue);\n\tSystem.Action::Invoke(v68.applySaturationValue);\n\tv798 = UnityEngine.GameObject::get_transform(v68.satvalKnob);\n\tv803 = v68.Saturation * v68.satvalSz;\n\tv804 = v68.Value * v68.satvalSz.y;\n\tv88 = 0;\n\tv805 = 0x1588A6C(&v88 @ stack_-B8_v4, 0, Il2CppMethodInfo, 0, v54, v55, v56, v57, v803, v804, v68.satvalSz, v68.satvalSz.y, *([v34 @ X29_v\n// ... truncated")]
		internal unsafe void Setup(Color inputColor)
		{
			//IL_0172: Expected O, but got I4
			//IL_01ff: Expected O, but got I4
			//IL_028c: Expected O, but got I4
			//IL_0319: Expected O, but got I4
			//IL_03a6: Expected O, but got I4
			//IL_0422: Expected O, but got I4
			//IL_045f: Expected O, but got I4
			//IL_0495: Expected O, but got I4
			//IL_04d9: Expected O, but got I4
			//IL_050f: Expected O, but got I4
			//IL_05a7: Expected O, but got I4
			//IL_061c: Expected O, but got I8
			//IL_06c7: Expected O, but got I
			//IL_06dc: Expected F4, but got I
			//IL_0752: Expected O, but got I
			//IL_0798: Expected O, but got I4
			//IL_07b0: Expected O, but got I4
			//IL_07d5: Expected F4, but got O
			//IL_07f0: Expected F4, but got O
			//IL_080b: Expected F4, but got O
			//IL_08b3: Expected O, but got I4
			//IL_08d1: Expected O, but got I
			//IL_08fc: Expected F4, but got O
			//IL_0917: Expected F4, but got O
			//IL_092c: Expected F4, but got I
			//IL_0941: Expected F4, but got I
			//IL_0ade: Expected O, but got I4
			//IL_0b0d: Expected F4, but got O
			//IL_0ba3: Expected O, but got I4
			//IL_0bcd: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals85 = new _003C_003Ec__DisplayClass13_0();
			CS_0024_003C_003E8__locals85._003C_003E4__this = this;
			Color color = default(Color);
			alphaSlider.value = color.a;
			alphaSliderBGImage.color = color;
			GameObject satvalGO = GO("SaturationValue");
			CS_0024_003C_003E8__locals85.satvalGO = satvalGO;
			GameObject satvalKnob = GO("SaturationValue/Knob");
			CS_0024_003C_003E8__locals85.satvalKnob = satvalKnob;
			GameObject hueGO = GO("Hue");
			CS_0024_003C_003E8__locals85.hueGO = hueGO;
			GameObject hueKnob = GO("Hue/Knob");
			CS_0024_003C_003E8__locals85.hueKnob = hueKnob;
			GameObject result = GO("Result");
			CS_0024_003C_003E8__locals85.result = result;
			Color[] array = new Color[6];
			Color red = Color.red;
			if (array.Length != 0)
			{
				_ = red.g;
				_ = red.b;
				_ = red.a;
				Color yellow = Color.yellow;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj3 = array.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					_ = yellow.g;
					_ = yellow.b;
					_ = yellow.a;
					Color green = Color.green;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj4 = array.Length - 2;
					bool flag7 = obj4 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						_ = green.g;
						_ = green.b;
						_ = green.a;
						Color cyan = Color.cyan;
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj5 = array.Length - 3;
						bool flag11 = obj5 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							_ = cyan.g;
							_ = cyan.b;
							_ = cyan.a;
							Color blue = Color.blue;
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj6 = array.Length - 4;
							bool flag15 = obj6 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								_ = blue.g;
								_ = blue.b;
								_ = blue.a;
								Color magenta = Color.magenta;
								bool flag17 = array.Length < 5;
								bool flag18 = !flag17;
								object obj7 = array.Length - 5;
								bool flag19 = obj7 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									_ = magenta.g;
									_ = magenta.b;
									_ = magenta.a;
									CS_0024_003C_003E8__locals85.hueColors = array;
									Color[] array2 = new Color[4];
									object obj8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
									if (array2.Length != 0)
									{
										_ = 0;
										object obj9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
										bool flag21 = array2.Length < 1;
										bool flag22 = !flag21;
										object obj10 = array2.Length - 1;
										bool flag23 = obj10 == null;
										bool flag24 = !flag22;
										if (!(flag24 || flag23))
										{
											_ = 0;
											object obj11 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
											bool flag25 = array2.Length < 2;
											bool flag26 = !flag25;
											object obj12 = array2.Length - 2;
											bool flag27 = obj12 == null;
											bool flag28 = !flag26;
											if (!(flag28 || flag27))
											{
												_ = 0;
												Color[] array3 = CS_0024_003C_003E8__locals85.hueColors;
												if (array3.Length != 0)
												{
													bool flag29 = array2.Length < 3;
													bool flag30 = !flag29;
													object obj13 = array2.Length - 3;
													bool flag31 = obj13 == null;
													bool flag32 = !flag30;
													if (!(flag32 || flag31))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X9_v6 (UnityEngine.Color[])+20]");
														_ = 0;
														CS_0024_003C_003E8__locals85.satvalColors = array2;
														Texture2D texture2D = new Texture2D(1, 7);
														object obj14 = 4294967295L;
														Color color2 = default(Color);
														Rect rect = default(Rect);
														object obj16 = default(object);
														object obj17 = default(object);
														Vector2 pivot = default(Vector2);
														object obj18 = default(object);
														Rect rect2 = default(Rect);
														object obj20 = default(object);
														object obj21 = default(object);
														Vector2 pivot2 = default(Vector2);
														Vector2 vector3 = default(Vector2);
														object obj23 = default(object);
														Vector2 vector4 = default(Vector2);
														object obj25 = default(object);
														while (true)
														{
															Color[] array4 = CS_0024_003C_003E8__locals85.hueColors;
															int num = (int)((long)(IntPtr)obj14 + 1L);
															int num2 = num * 715827883;
															int num3 = num2 >> 63;
															int num4 = num2 >> 32;
															int num5 = num4 + num3;
															int num6 = num5 * 6;
															int num7 = num - num6;
															if (num7 >= array4.Length)
															{
																break;
															}
															int num8 = num7 << 4;
															object obj15 = (long)(IntPtr)array4 + (long)num8;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X8_v31+20]");
															color2.r = 0f;
															color2.g = array4[num7].g;
															color2.b = array4[num7].b;
															color2.a = array4[num7].a;
															texture2D.SetPixel(0, num, color2);
															obj14 = (long)(IntPtr)obj14 + 1L;
															if ((long)(IntPtr)obj14 < 6L)
															{
																continue;
															}
															texture2D.Apply();
															Image component = CS_0024_003C_003E8__locals85.hueGO.GetComponent<Image>();
															obj8 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
															obj11 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
															rect.x = 0f;
															rect.y = (float)obj16;
															rect.width = 0f;
															rect.height = (float)obj17;
															pivot.x = 0f;
															pivot.y = (float)obj18;
															Sprite sprite = Sprite.Create(texture2D, rect, pivot);
															component.sprite = sprite;
															Vector2 vector = (CS_0024_003C_003E8__locals85.hueSz = GetWidgetSize(CS_0024_003C_003E8__locals85.hueGO));
															CS_0024_003C_003E8__locals85.hueSz.y = vector.y;
															Texture2D satvalTex = new Texture2D(2, 2);
															CS_0024_003C_003E8__locals85.satvalTex = satvalTex;
															Image component2 = CS_0024_003C_003E8__locals85.satvalGO.GetComponent<Image>();
															obj9 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
															object obj19 = (long)(IntPtr)obj2 - 56L;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
															rect2.x = 0f;
															rect2.y = (float)obj20;
															rect2.width = 0f;
															rect2.height = (float)obj21;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
															pivot2.x = 0f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
															pivot2.y = 0f;
															Sprite sprite2 = Sprite.Create(CS_0024_003C_003E8__locals85.satvalTex, rect2, pivot2);
															component2.sprite = sprite2;
															Action resetSatValTexture = delegate
															{
																//IL_0064: Expected O, but got I
																//IL_0079: Expected F4, but got I
																//IL_008e: Expected F4, but got I
																//IL_00a3: Expected F4, but got I
																//IL_00b8: Expected F4, but got I
																int num13 = 0;
																int num14 = 0;
																int num15 = 0;
																Color color3 = default(Color);
																bool flag34;
																do
																{
																	int num16 = num14;
																	int num17 = 0;
																	bool flag33;
																	do
																	{
																		Color[] array5 = CS_0024_003C_003E8__locals85.satvalColors;
																		int num18 = num15 + num17;
																		if (num18 >= array5.Length)
																		{
																			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
																			throw ex2;
																		}
																		object obj26 = (long)(IntPtr)array5 + (long)num16;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+20]");
																		color3.r = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+24]");
																		color3.g = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+28]");
																		color3.b = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v5+2C]");
																		color3.a = 0f;
																		CS_0024_003C_003E8__locals85.satvalTex.SetPixel(num17, num13, color3);
																		int num19 = num17 + 1;
																		num16 += 16;
																		flag33 = num17 < 1;
																		num17 = num19;
																	}
																	while (flag33);
																	int num20 = num13 + 1;
																	num14 += 32;
																	num15 += 2;
																	flag34 = num13 <= 0;
																	num13 = num20;
																}
																while (flag34);
																CS_0024_003C_003E8__locals85.satvalTex.Apply();
															};
															CS_0024_003C_003E8__locals85.resetSatValTexture = resetSatValTexture;
															Vector2 vector2 = (CS_0024_003C_003E8__locals85.satvalSz = GetWidgetSize(CS_0024_003C_003E8__locals85.satvalGO));
															CS_0024_003C_003E8__locals85.satvalSz.y = vector2.y;
															RGBToHSV(color, out *(float*)((long)(IntPtr)CS_0024_003C_003E8__locals85 + 32L), out *(float*)((long)(IntPtr)CS_0024_003C_003E8__locals85 + 56L), out *(float*)((long)(IntPtr)CS_0024_003C_003E8__locals85 + 60L));
															Action applyHue = delegate
															{
																//IL_001a: Expected I4, but got F4
																//IL_00ee: Expected O, but got I
																//IL_010a: Expected O, but got I
																//IL_0126: Expected O, but got I
																//IL_0145: Expected F4, but got O
																//IL_015a: Expected F4, but got I
																//IL_016f: Expected F4, but got I
																//IL_0184: Expected F4, but got I
																//IL_0191: Expected F4, but got O
																//IL_01a6: Expected F4, but got I
																//IL_01bb: Expected F4, but got I
																//IL_01d0: Expected F4, but got I
																//IL_0220: Expected O, but got I4
																int num13 = Mathf.Clamp((int)CS_0024_003C_003E8__locals85.Hue, 0, 5);
																Color[] array5 = CS_0024_003C_003E8__locals85.hueColors;
																if (num13 < array5.Length)
																{
																	int num14 = num13 + 1;
																	int num15 = num14 * 715827883;
																	int num16 = num15 >> 63;
																	int num17 = num15 >> 32;
																	int num18 = num17 + num16;
																	int num19 = num18 * 6;
																	int num20 = num14 - num19;
																	if (num20 < array5.Length)
																	{
																		object obj26 = (long)(IntPtr)array5 + 32L;
																		int num21 = num13 << 4;
																		object obj27 = (long)(IntPtr)obj26 + (long)num21;
																		int num22 = num20 << 4;
																		object obj28 = (long)(IntPtr)obj26 + (long)num22;
																		float t = CS_0024_003C_003E8__locals85.Hue - (float)num13;
																		Color a = default(Color);
																		a.r = (float)obj27;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X9_v6+4]");
																		a.g = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X9_v6+8]");
																		a.b = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X9_v6+C]");
																		a.a = 0f;
																		Color b = default(Color);
																		b.r = (float)obj28;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v12+4]");
																		b.g = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v12+8]");
																		b.b = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v12+C]");
																		b.a = 0f;
																		Color color3 = Color.Lerp(a, b, t);
																		Color[] array6 = CS_0024_003C_003E8__locals85.satvalColors;
																		bool flag33 = array6.Length < 3;
																		bool flag34 = !flag33;
																		object obj29 = array6.Length - 3;
																		bool flag35 = obj29 == null;
																		bool flag36 = !flag34;
																		if (!(flag36 || flag35))
																		{
																			_ = color3.g;
																			_ = color3.b;
																			_ = color3.a;
																			CS_0024_003C_003E8__locals85.resetSatValTexture();
																			return;
																		}
																	}
																}
																IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
																throw ex2;
															};
															CS_0024_003C_003E8__locals85.applyHue = applyHue;
															Action applySaturationValue = delegate
															{
																//IL_0048: Expected F4, but got I
																//IL_005d: Expected F4, but got I
																//IL_0072: Expected F4, but got I
																//IL_0087: Expected F4, but got I
																//IL_00d3: Expected O, but got I4
																//IL_012c: Expected F4, but got I
																//IL_0141: Expected F4, but got I
																//IL_0156: Expected F4, but got I
																//IL_016b: Expected F4, but got I
																//IL_01b7: Expected O, but got I4
																//IL_0210: Expected F4, but got I
																//IL_0225: Expected F4, but got I
																//IL_023a: Expected F4, but got I
																//IL_024f: Expected F4, but got I
																//IL_029b: Expected O, but got I4
																//IL_02f4: Expected F4, but got I
																//IL_0309: Expected F4, but got I
																//IL_031e: Expected F4, but got I
																//IL_0333: Expected F4, but got I
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
																object obj26 = default(object);
																float num13 = 1f - (float)obj26;
																object obj27 = default(object);
																float num14 = 1f - (float)obj27;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
																Color[] array5 = CS_0024_003C_003E8__locals85.satvalColors;
																if (array5.Length != 0)
																{
																	object obj28 = default(object);
																	object obj29 = default(object);
																	float num15 = (float)obj28 * (float)obj29;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+20]");
																	Color color3 = default(Color);
																	color3.r = 0f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+24]");
																	color3.g = 0f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+28]");
																	color3.b = 0f;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v3 (UnityEngine.Color[])+2C]");
																	color3.a = 0f;
																	Color color4 = num15 * color3;
																	Color[] array6 = CS_0024_003C_003E8__locals85.satvalColors;
																	bool flag33 = array6.Length < 1;
																	bool flag34 = !flag33;
																	object obj30 = array6.Length - 1;
																	bool flag35 = obj30 == null;
																	bool flag36 = !flag34;
																	if (!(flag36 || flag35))
																	{
																		float num16 = (float)obj26 * (float)obj29;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+30]");
																		Color color5 = default(Color);
																		color5.r = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+34]");
																		color5.g = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+38]");
																		color5.b = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X8_v7 (UnityEngine.Color[])+3C]");
																		color5.a = 0f;
																		Color color6 = num16 * color5;
																		Color[] array7 = CS_0024_003C_003E8__locals85.satvalColors;
																		bool flag37 = array7.Length < 2;
																		bool flag38 = !flag37;
																		object obj31 = array7.Length - 2;
																		bool flag39 = obj31 == null;
																		bool flag40 = !flag38;
																		if (!(flag40 || flag39))
																		{
																			float num17 = (float)obj28 * (float)obj27;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+40]");
																			Color color7 = default(Color);
																			color7.r = 0f;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+44]");
																			color7.g = 0f;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+48]");
																			color7.b = 0f;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ X8_v8 (UnityEngine.Color[])+4C]");
																			color7.a = 0f;
																			Color color8 = num17 * color7;
																			Color[] array8 = CS_0024_003C_003E8__locals85.satvalColors;
																			bool flag41 = array8.Length < 3;
																			bool flag42 = !flag41;
																			object obj32 = array8.Length - 3;
																			bool flag43 = obj32 == null;
																			bool flag44 = !flag42;
																			if (!(flag44 || flag43))
																			{
																				float num18 = (float)obj26 * (float)obj27;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+50]");
																				Color color9 = default(Color);
																				color9.r = 0f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+54]");
																				color9.g = 0f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+58]");
																				color9.b = 0f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X8_v9 (UnityEngine.Color[])+5C]");
																				color9.a = 0f;
																				Color color10 = num18 * color9;
																				Color color11 = color4 + color6;
																				Color color12 = color11 + color8;
																				Color color13 = color12 + color10;
																				Image component3 = CS_0024_003C_003E8__locals85.result.GetComponent<Image>();
																				component3.color = color13;
																				G_CUIColorPicker g_CUIColorPicker = CS_0024_003C_003E8__locals85._003C_003E4__this;
																				Color color14 = default(Color);
																				color14.r = g_CUIColorPicker._color.r;
																				color14.g = g_CUIColorPicker._color.g;
																				color14.b = g_CUIColorPicker._color.b;
																				color14.a = g_CUIColorPicker._color.a;
																				if (color14 != color13)
																				{
																					G_CUIColorPicker g_CUIColorPicker2 = CS_0024_003C_003E8__locals85._003C_003E4__this;
																					float value = g_CUIColorPicker2.alphaSlider.value;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
																					G_CUIColorPicker g_CUIColorPicker3 = CS_0024_003C_003E8__locals85._003C_003E4__this;
																					float r = default(float);
																					if (g_CUIColorPicker3._onValueChange != null)
																					{
																						Color obj33 = default(Color);
																						obj33.r = r;
																						obj33.g = color13.g;
																						obj33.b = color13.b;
																						obj33.a = color13.a;
																						g_CUIColorPicker3._onValueChange(obj33);
																						g_CUIColorPicker3 = CS_0024_003C_003E8__locals85._003C_003E4__this;
																					}
																					g_CUIColorPicker3._color.r = r;
																					g_CUIColorPicker3._color.g = color13.g;
																					g_CUIColorPicker3._color.a = color13.a;
																					G_CUIColorPicker g_CUIColorPicker4 = CS_0024_003C_003E8__locals85._003C_003E4__this;
																					Color color15 = default(Color);
																					color15.r = g_CUIColorPicker4._color.r;
																					color15.g = g_CUIColorPicker4._color.g;
																					color15.b = g_CUIColorPicker4._color.b;
																					color15.a = g_CUIColorPicker4._color.a;
																					g_CUIColorPicker4.alphaSliderBGImage.color = color15;
																				}
																				return;
																			}
																		}
																	}
																}
																IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
																throw ex2;
															};
															CS_0024_003C_003E8__locals85.applySaturationValue = applySaturationValue;
															CS_0024_003C_003E8__locals85.applyHue();
															CS_0024_003C_003E8__locals85.applySaturationValue();
															Transform transform = CS_0024_003C_003E8__locals85.satvalKnob.transform;
															float num9 = CS_0024_003C_003E8__locals85.Saturation * CS_0024_003C_003E8__locals85.satvalSz.x;
															float num10 = CS_0024_003C_003E8__locals85.Value * CS_0024_003C_003E8__locals85.satvalSz.y;
															object obj22 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
															vector3.x = 0f;
															vector3.y = (float)obj23;
															Vector3 localPosition = vector3;
															transform.localPosition = localPosition;
															Transform transform2 = CS_0024_003C_003E8__locals85.hueKnob.transform;
															Transform transform3 = CS_0024_003C_003E8__locals85.hueKnob.transform;
															Vector3 localPosition2 = transform3.localPosition;
															float num11 = CS_0024_003C_003E8__locals85.Hue / 6f;
															float num12 = num11 * CS_0024_003C_003E8__locals85.satvalSz.y;
															object obj24 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
															vector4.x = 0f;
															vector4.y = (float)obj25;
															Vector3 localPosition3 = vector4;
															transform2.localPosition = localPosition3;
															CS_0024_003C_003E8__locals85.dragH = null;
															CS_0024_003C_003E8__locals85.dragSV = null;
															Action idle = delegate
															{
																Vector2 result2 = default(Vector2);
																if (Input.GetMouseButtonDown(0))
																{
																	G_CUIColorPicker g_CUIColorPicker;
																	Action update;
																	if (GetLocalMouse(CS_0024_003C_003E8__locals85.hueGO, out result2))
																	{
																		g_CUIColorPicker = CS_0024_003C_003E8__locals85._003C_003E4__this;
																		update = CS_0024_003C_003E8__locals85.dragH;
																	}
																	else
																	{
																		if (!GetLocalMouse(CS_0024_003C_003E8__locals85.satvalGO, out result2))
																		{
																			return;
																		}
																		g_CUIColorPicker = CS_0024_003C_003E8__locals85._003C_003E4__this;
																		update = CS_0024_003C_003E8__locals85.dragSV;
																	}
																	g_CUIColorPicker._update = update;
																}
															};
															CS_0024_003C_003E8__locals85.idle = idle;
															Action dragH = delegate
															{
																//IL_0063: Expected O, but got I4
																//IL_0092: Expected F4, but got O
																Vector2 result2 = default(Vector2);
																bool localMouse = GetLocalMouse(CS_0024_003C_003E8__locals85.hueGO, out result2);
																object obj26 = default(object);
																float num13 = (float)obj26 / CS_0024_003C_003E8__locals85.hueSz.y;
																float hue = num13 * 6f;
																CS_0024_003C_003E8__locals85.Hue = hue;
																CS_0024_003C_003E8__locals85.applyHue();
																CS_0024_003C_003E8__locals85.applySaturationValue();
																Transform transform4 = CS_0024_003C_003E8__locals85.hueKnob.transform;
																Transform transform5 = CS_0024_003C_003E8__locals85.hueKnob.transform;
																Vector3 localPosition4 = transform5.localPosition;
																object obj27 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
																Vector2 vector5 = default(Vector2);
																vector5.x = 0f;
																object obj28 = default(object);
																vector5.y = (float)obj28;
																Vector3 localPosition5 = vector5;
																transform4.localPosition = localPosition5;
																if (Input.GetMouseButtonUp(0))
																{
																	G_CUIColorPicker g_CUIColorPicker = CS_0024_003C_003E8__locals85._003C_003E4__this;
																	g_CUIColorPicker._update = CS_0024_003C_003E8__locals85.idle;
																}
															};
															CS_0024_003C_003E8__locals85.dragH = dragH;
															Action dragSV = delegate
															{
																//IL_0048: Expected F4, but got O
																bool localMouse = GetLocalMouse(CS_0024_003C_003E8__locals85.satvalGO, out var result2);
																float saturation = result2.x / CS_0024_003C_003E8__locals85.satvalSz.x;
																CS_0024_003C_003E8__locals85.Saturation = saturation;
																object obj26 = default(object);
																float value = (float)obj26 / CS_0024_003C_003E8__locals85.satvalSz.y;
																CS_0024_003C_003E8__locals85.Value = value;
																CS_0024_003C_003E8__locals85.applySaturationValue();
																Transform transform4 = CS_0024_003C_003E8__locals85.satvalKnob.transform;
																Vector2 vector5 = default(Vector2);
																vector5.x = result2.x;
																vector5.y = (float)obj26;
																Vector3 localPosition4 = vector5;
																transform4.localPosition = localPosition4;
																if (Input.GetMouseButtonUp(0))
																{
																	G_CUIColorPicker g_CUIColorPicker = CS_0024_003C_003E8__locals85._003C_003E4__this;
																	g_CUIColorPicker._update = CS_0024_003C_003E8__locals85.idle;
																}
															};
															CS_0024_003C_003E8__locals85.dragSV = dragSV;
															_update = CS_0024_003C_003E8__locals85.idle;
															return;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0xB11D8C", Offset = "0xB11D8C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC8F28]);\n\tv29 = *([v28 @ X8_v20]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022528]) = v48;\nL_001B:\n\tv52 = new System.Random();\n\tSystem.Random::.ctor(v52);\n\tv60 = System.Random::Next(v52);\n\tv65 = v60 * 0x10624DD3;\n\tv67 = v65 >> 0x3F;\n\tv68 = v65 >> 0x26;\n\tv69 = v68 + v67;\n\tv73 = v69 * 0x3E8;\n\tv74 = v60 - v73;\n\tv77 = v74 / 1000f;\n\tv78 = System.Random::Next(v52);\n\tv80 = v78 * 0x10624DD3;\n\tv81 = v80 >> 0x3F;\n\tv82 = v80 >> 0x26;\n\tv83 = v82 + v81;\n\tv86 = v83 * 0x3E8;\n\tv87 = v78 - v86;\n\tv90 = v87 / 1000f;\n\tv91 = System.Random::Next(v52);\n\tv92 = v91 * 0x10624DD3;\n\tv93 = v92 >> 0x3F;\n\tv94 = v92 >> 0x26;\n\tv95 = v94 + v93;\n\tv96 = v95 * 0x3E8;\n\tv97 = v91 - v96;\n\tv99 = v97 / 1000f;\n\tv101 = 0;\n\tv106 = 0x10105A8(&v101 @ stack_-60_v1, 0, v32, v33, v34, v35, v36, v37, v77, v90, v99, v41, v42, v43, v44, v45);\n\t// 89 MakeStruct v116 @ AGGB11EAC_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v111 @ stack_-5C, 0, v114 @ stack_-54\n\tTayx.Graphy.CustomizationScene.G_CUIColorPicker::Setup(this, v116);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetRandomColor()
		{
			//IL_015e: Expected O, but got I4
			//IL_0183: Expected F4, but got O
			//IL_019e: Expected F4, but got O
			System.Random random = new System.Random();
			int num = random.Next();
			int num2 = num * 274877907;
			int num3 = num2 >> 63;
			int num4 = num2 >> 38;
			int num5 = num4 + num3;
			int num6 = num5 * 1000;
			int num7 = num - num6;
			float num8 = (float)num7 / 1000f;
			int num9 = random.Next();
			int num10 = num9 * 274877907;
			int num11 = num10 >> 63;
			int num12 = num10 >> 38;
			int num13 = num12 + num11;
			int num14 = num13 * 1000;
			int num15 = num9 - num14;
			float num16 = (float)num15 / 1000f;
			int num17 = random.Next();
			int num18 = num17 * 274877907;
			int num19 = num18 >> 63;
			int num20 = num18 >> 38;
			int num21 = num20 + num19;
			int num22 = num21 * 1000;
			int num23 = num17 - num22;
			float num24 = (float)num23 / 1000f;
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
			Color inputColor = default(Color);
			inputColor.r = 0f;
			object obj2 = default(object);
			inputColor.g = (float)obj2;
			inputColor.b = 0f;
			object obj3 = default(object);
			inputColor.a = (float)obj3;
			Setup(inputColor);
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0xB11ED4", Offset = "0xB11ED4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = 0;\n\tv17 = 0x1010E50(&v11 @ stack_-18_v1 (UnityEngine.Color32), 0xFF, 0, 0, 0x80, 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv30 = UnityEngine.Color32::op_Implicit(0);\n\tTayx.Graphy.CustomizationScene.G_CUIColorPicker::Setup(this, v30);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Color32 color = default(Color32);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			Color inputColor = default(Color32);
			Setup(inputColor);
		}

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0xB11F24", Offset = "0xB11F24", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC1310]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022529]) = v40;\nL_0014:\n\tv41 = this.alphaSlider;\n\tv47 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v47, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v41.m_OnValueChanged, v47);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Slider slider = alphaSlider;
			UnityAction<float> call = delegate
			{
				Color color = default(Color);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
				_color = default(Color);
				float g = default(float);
				_color.g = g;
				_color.b = 0f;
				float a = default(float);
				_color.a = a;
				Color color2 = default(Color);
				color2.r = 0f;
				color2.g = g;
				color2.b = 0f;
				color2.a = a;
				alphaSliderBGImage.color = color2;
				if (_onValueChange != null)
				{
					Color obj = default(Color);
					obj.r = _color.r;
					obj.g = _color.g;
					obj.b = _color.b;
					obj.a = _color.a;
					_onValueChange(obj);
				}
			};
			slider.onValueChanged.AddListener(call);
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0xB11FCC", Offset = "0xB11FCC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._update == 0;\n\tif (v2) goto L_0006;\n\tSystem.Action::Invoke(this._update);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (_update != null)
			{
				_update();
			}
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0xB11FE0", Offset = "0xB11FE0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = 0;\n\tv17 = 0x1010E50(&v11 @ stack_-18_v1 (UnityEngine.Color32), 0xFF, 0, 0, 0x80, 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv30 = UnityEngine.Color32::op_Implicit(0);\n\tthis._color = v30;\n\tthis._color.g = v30.g;\n\tthis._color.b = v30.b;\n\tthis._color.a = v30.a;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_CUIColorPicker()
		{
			Color32 color = default(Color32);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			Color color2 = (_color = default(Color32));
			_color.g = color2.g;
			_color.b = color2.b;
			_color.a = color2.a;
		}
	}
}

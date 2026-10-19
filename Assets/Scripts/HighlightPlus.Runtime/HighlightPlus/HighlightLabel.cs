using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace HighlightPlus
{
	[ExecuteAlways]
	[Token(Token = "0x200002B")]
	public class HighlightLabel : MonoBehaviour
	{
		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x20")]
		public Camera cam;

		[NonSerialized]
		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x28")]
		public Transform target;

		[NonSerialized]
		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x30")]
		public Vector3 localPosition;

		[NonSerialized]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x3C")]
		public Vector3 worldOffset;

		[NonSerialized]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x48")]
		public Vector2 viewportOffset;

		[NonSerialized]
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x50")]
		public bool isVisible;

		[NonSerialized]
		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x54")]
		public LabelAlignment labelAlignment;

		[NonSerialized]
		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x58")]
		public bool labelRelativeAlignment;

		[NonSerialized]
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x60")]
		public Transform labelAlignmentTransform;

		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x68")]
		public GameObject labelPrefab;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x70")]
		internal bool isPooled;

		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x78")]
		private TextMeshProUGUI text;

		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x80")]
		private RectTransform panel;

		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x88")]
		private CanvasGroup canvasGroup;

		[NonSerialized]
		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0x90")]
		public float labelMaxDistance;

		[NonSerialized]
		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x94")]
		public float labelFadeStartDistance;

		[NonSerialized]
		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x98")]
		public bool labelScaleByDistance;

		[NonSerialized]
		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x9C")]
		public float labelScaleMin;

		[NonSerialized]
		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0xA0")]
		public float labelScaleMax;

		[NonSerialized]
		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0xA4")]
		public float highlightAlpha;

		[Token(Token = "0x17000007")]
		public virtual float alpha
		{
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x77264AC", Offset = "0x77264AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.highlightAlpha;\n")]
			get
			{
				return highlightAlpha;
			}
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x77264B4", Offset = "0x77264B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.highlightAlpha = value;\n\treturn;\n")]
			set
			{
				highlightAlpha = value;
			}
		}

		[Token(Token = "0x17000008")]
		public virtual Color textColor
		{
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x77264BC", Offset = "0x77264BC", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.text == 0;\n\tif (v2) goto L_0013;\n\tv12 = TMPro.TMP_Text::get_color(this.text);\n\treturn returnVal1;\nL_0013:\n\treturn 1f;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightLabel::get_textColor");
				return default;
			}
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x77264F8", Offset = "0x77264F8", Length = "0xF8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tgoto L_0023;\nL_0023:\n\tv67 = UnityEngine.Object::op_Inequality(this.text, 0);\n\tv75 = ~v67;\n\tif (v75) goto L_005A;\n\tv87 = TMPro.TMP_Text::set_color(v87, Color_arg);\n\treturn;\nL_005A:\n\treturn;\n")]
			set
			{
				if (text != null)
				{
					TextMeshProUGUI textMeshProUGUI = default(TextMeshProUGUI);
					Color color = default(Color);
					textMeshProUGUI.color = color;
				}
			}
		}

		[Token(Token = "0x17000009")]
		public virtual string textLabel
		{
			[Token(Token = "0x60000A2")]
			[Address(RVA = "0x77265F0", Offset = "0x77265F0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv45 = TMPro.TMP_Text::get_text(this.text);\nL_FFFFFFFF:\n\tv49 = v45;\nL_FFFFFFFF:\n\treturnVal1 = \"\";\n\tgoto L_0030;\nL_FFFFFFFF:\n\treturnVal1 = v49;\nL_0014:\n\tv49 = this.text;\n\tv41 = this.text == 0;\n\tif (v41) goto L_0025;\nL_0030:\n\treturn returnVal1;\nL_0025:\n\tv61 = v49 != 0;\n\tif (v61) goto L_FFFFFFFF;\n")]
			get
			{
				TextMeshProUGUI textMeshProUGUI = this.text;
				if ((object)this.text != null)
				{
					string text = this.text.text;
					textMeshProUGUI = (TextMeshProUGUI)(object)text;
				}
				if ((object)textMeshProUGUI == null)
				{
					return "";
				}
				return (string)(object)textMeshProUGUI;
			}
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x7726658", Offset = "0x7726658", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Inequality(this.text, 0);\n\tv64 = ~v56;\n\tif (v64) goto L_0045;\n\tv76 = TMPro.TMP_Text::set_text(v76, value);\n\treturn;\nL_0045:\n\treturn;\n")]
			set
			{
				if (text != null)
				{
					TextMeshProUGUI textMeshProUGUI = default(TextMeshProUGUI);
					textMeshProUGUI.text = value;
				}
			}
		}

		[Token(Token = "0x1700000A")]
		public virtual float textSize
		{
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0x7726720", Offset = "0x7726720", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.text;\n\tv2 = this.text == 0;\n\tif (v2) goto L_0006;\n\treturn v0.fontSize;\nL_0006:\n\treturn 14f;\n")]
			get
			{
				TextMeshProUGUI textMeshProUGUI = text;
				if ((object)text != null)
				{
					return textMeshProUGUI.fontSize;
				}
				return 14f;
			}
			[Token(Token = "0x60000A5")]
			[Address(RVA = "0x7726738", Offset = "0x7726738", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv60 = UnityEngine.Object::op_Inequality(this.text, 0);\n\tv68 = ~v60;\n\tif (v68) goto L_004A;\n\tTMPro.TMP_Text::set_fontSize(this.text, value);\n\treturn;\nL_004A:\n\treturn;\n")]
			set
			{
				if (text != null)
				{
					text.fontSize = value;
				}
			}
		}

		[Token(Token = "0x1700000B")]
		public virtual float width
		{
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0x7726804", Offset = "0x7726804", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.text == 0;\n\tif (v8) goto L_0017;\n\tv10 = TMPro.TMP_Text::get_rectTransform(this.text);\n\treturnVal2 = UnityEngine.RectTransform::get_sizeDelta(v10);\n\treturn returnVal2;\nL_0017:\n\treturn 0x43480000;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightLabel::get_width");
				return default;
			}
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0x7726844", Offset = "0x7726844", Length = "0x1E4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv60 = UnityEngine.Object::op_Equality(this.text, 0);\n\tv70 = v60 == 0;\n\tif (v70) goto L_003B;\n\tgoto L_00B2;\nL_003B:\n\tv157 = TMPro.TMP_Text::get_rectTransform(this.text);\n\tgoto L_0042;\nL_0042:\n\tv247 = UnityEngine.Object::op_Inequality(v157, 0);\n\tv251 = ~v247;\n\tv252 = ~v251;\n\tif (v252) goto L_0054;\n\tgoto L_0076;\nL_0054:\n\tv190 = TMPro.TMP_Text::get_rectTransform(this.text);\n\tv176 = UnityEngine.RectTransform::get_sizeDelta(v190);\n\tv170 = v176 == value;\n\tif (v170) goto L_0076;\n\tv192 = TMPro.TMP_Text::get_rectTransform(this.text);\n\t// 110 MakeStruct v260 @ AGG772697C_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), value @ V0 (System.Single), v176.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v192, v260);\nL_0076:\n\tv269 = UnityEngine.Component::GetComponent(this.panel);\n\tgoto L_007F;\nL_007F:\n\tv135 = UnityEngine.Object::op_Inequality(v269, 0);\n\tv276 = ~v135;\n\tv139 = ~v276;\n\tif (v139) goto L_008F;\n\tgoto L_00B2;\nL_008F:\n\tv122 = UnityEngine.RectTransform::get_sizeDelta(v269);\n\tv112 = v122 == value;\n\tif (v112) goto L_00B2;\n\t// 166 MakeStruct v208 @ AGG7726A0C_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), value @ V0 (System.Single), v122.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v269, v208);\n\treturn;\nL_00B2:\n\treturn;\n")]
			set
			{
				if (text == null)
				{
					return;
				}
				RectTransform rectTransform = text.rectTransform;
				if (rectTransform != null)
				{
					RectTransform rectTransform2 = text.rectTransform;
					Vector2 sizeDelta = rectTransform2.sizeDelta;
					if (sizeDelta.x != value)
					{
						RectTransform rectTransform3 = text.rectTransform;
						Vector2 sizeDelta2 = default(Vector2);
						sizeDelta2.x = value;
						sizeDelta2.y = sizeDelta.y;
						rectTransform3.sizeDelta = sizeDelta2;
					}
				}
				RectTransform component = panel.GetComponent<RectTransform>();
				if (component != null)
				{
					Vector2 sizeDelta3 = component.sizeDelta;
					if (sizeDelta3.x != value)
					{
						Vector2 sizeDelta4 = default(Vector2);
						sizeDelta4.x = value;
						sizeDelta4.y = sizeDelta3.y;
						component.sizeDelta = sizeDelta4;
					}
				}
			}
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x7726A28", Offset = "0x7726A28", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv63 = UnityEngine.Transform::GetChild(v59, 0);\n\tv75 = UnityEngine.Component::GetComponentInChildren(v63);\n\tthis.panel = v75;\n\tv101 = UnityEngine.Component::GetComponent(this);\n\tthis.canvasGroup = v101;\n\treturn;\nL_001E:\n\tv47 = UnityEngine.Component::GetComponentInChildren(this);\n\tthis.text = v47;\n\tv59 = UnityEngine.Component::get_transform(this);\n")]
		private void Awake()
		{
			TextMeshProUGUI componentInChildren = GetComponentInChildren<TextMeshProUGUI>();
			text = componentInChildren;
			Transform transform = base.transform;
			Transform child = transform.GetChild(0);
			RectTransform componentInChildren2 = child.GetComponentInChildren<RectTransform>();
			panel = componentInChildren2;
			CanvasGroup component = GetComponent<CanvasGroup>();
			canvasGroup = component;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x7726B0C", Offset = "0x7726B0C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv51 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v51, 0);\n\tgoto L_0032;\nL_0032:\n\tHighlightPlus.HighlightLabelPoolManager::ReturnToPool(this);\n\treturn;\nL_0039:\n\treturn;\nL_001C:\n\tv48 = this.isPooled != 1;\n\tif (v48) goto L_0039;\n")]
		public virtual void ReturnToPool()
		{
			if (isPooled)
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
				HighlightLabelPoolManager.ReturnToPool(this);
			}
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x7726D2C", Offset = "0x7726D2C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = target;\n\tthis.localPosition.x = localPosition;\n\tthis.localPosition.y = localPosition.y;\n\tthis.localPosition.z = localPosition.z;\n\tthis.worldOffset.x = worldOffset;\n\tthis.worldOffset.y = worldOffset.y;\n\tthis.worldOffset.z = worldOffset.z;\n\tthis.viewportOffset.x = viewportOffset;\n\tthis.viewportOffset.y = viewportOffset.y;\n\treturn;\n")]
		public virtual void SetPosition(Transform target, Vector3 localPosition, Vector3 worldOffset, Vector2 viewportOffset = default(Vector2))
		{
			this.target = target;
			this.localPosition.x = localPosition.x;
			this.localPosition.y = localPosition.y;
			this.localPosition.z = localPosition.z;
			this.worldOffset.x = worldOffset.x;
			this.worldOffset.y = worldOffset.y;
			this.worldOffset.z = worldOffset.z;
			this.viewportOffset.x = viewportOffset.x;
			this.viewportOffset.y = viewportOffset.y;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x7726DA4", Offset = "0x7726DA4", Length = "0x8B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tgoto L_0022;\nL_0022:\n\tv77 = UnityEngine.Object::op_Equality(this.panel, 0);\n\tv88 = v77 == 0;\n\tif (v88) goto L_0041;\n\tgoto L_0302;\nL_0041:\n\tgoto L_0045;\nL_0045:\n\tv252 = UnityEngine.Object::op_Equality(this.text, 0);\n\tv265 = v252 == 0;\n\tif (v265) goto L_0059;\n\tgoto L_0302;\nL_0059:\n\tgoto L_005D;\nL_005D:\n\tv469 = UnityEngine.Object::op_Equality(this.cam, 0);\n\tv471 = ~v469;\n\tv472 = ~v471;\n\tif (v472) goto L_006A;\n\tgoto L_0089;\nL_006A:\n\tv483 = UnityEngine.Camera::get_main();\n\tthis.cam = v483;\n\tgoto L_0077;\nL_0077:\n\tv254 = UnityEngine.Object::op_Equality(this.cam, 0);\n\tv267 = v254 == 0;\n\tif (v267) goto L_0089;\n\tgoto L_0302;\nL_0089:\n\tgoto L_008D;\nL_008D:\n\tv256 = UnityEngine.Object::op_Equality(this.target, 0);\n\tv269 = v256 == 0;\n\tif (v269) goto L_009C;\n\tgoto L_0302;\nL_009C:\n\tv508 = this.target == 0;\n\tif (v508) goto L_0303;\n\t// 162 MakeStruct v216 @ AGG7726F84_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.localPosition (UnityEngine.Vector3), this.localPosition.y (System.Single), this.localPosition.z (System.Single)\n\tv517 = UnityEngine.Transform::TransformPoint(this.target, v216);\n\tv733 = this.cam == 0;\n\tif (v733) goto L_0303;\n\tv207 = v517 + this.worldOffset;\n\tv204 = v517.y + this.worldOffset.y;\n\tv201 = v517.z + this.worldOffset.z;\n\t// 179 MakeStruct v197 @ AGG7726FB4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v207 @ V8_v7 (System.Single), v204 @ V9_v7 (System.Single), v201 @ V10_v7 (System.Single)\n\tv788 = UnityEngine.Camera::WorldToViewportPoint(this.cam, v197);\n\tv799 = v788.z < 0;\n\tv800 = v788.z == 0;\n\tv578 = v788.z == v788.z;\n\tv803 = ~v578;\n\tv804 = v799 == v803;\n\tv805 = ~v804;\n\tv806 = v805 | v800;\n\tif (v806) goto L_FFFFFFFF;\n\t// 194 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 197 NotImplemented \"Instruction FCMGE not yet implemented.\"\n\t// 198 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 199 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 200 NotImplemented \"Instruction FCMGE not yet implemented.\"\n\t// 201 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 202 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 204 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv641 = v788 & *([92457A0]);\n\t// 208 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv818 = v641 & 0xF;\n\tv602 = v818 == 0;\n\tv555 = ~v602;\n\tif (v555) goto L_FFFFFFFF;\n\tv734 = this.cam == 0;\n\tif (v734) goto L_0303;\n\tv710 = UnityEngine.Component::get_transform(this.cam);\n\tv735 = v710 == 0;\n\tif (v735) goto L_0303;\n\tv923 = UnityEngine.Transform::get_position(v710);\n\tgoto L_00F8;\nL_00FA:\n\tv944 = v923.z - v201;\n\tv945 = v923.y - v204;\n\tv946 = v923 - v207;\n\tv658 = v946 * v946;\n\tv947 = v945 * v945;\n\tv902 = v658 + v947;\n\tv948 = v944 * v944;\n\tv949 = v948 + v902;\n\tv553 = UnityEngine.Mathf::Sqrt(v949);\n\tv645 = this.labelMaxDistance;\n\tv950 = this.labelMaxDistance < 0;\n\tv951 = this.labelMaxDistance == 0;\n\tv954 = this.labelMaxDistance == this.labelMaxDistance;\n\tv955 = ~v954;\n\tv956 = v950 == v955;\n\tv957 = ~v956;\n\tv958 = v957 | v951;\n\tif (v958) goto L_0146;\n\tv896 = v553 < this.labelMaxDistance;\n\tv894 = v553 == this.labelMaxDistance;\n\tv960 = v553 == v553;\n\tv877 = this.labelMaxDistance == this.labelMaxDistance;\n\tv890 = v960 & v877;\n\tv888 = ~v890;\n\tv961 = v896 == v888;\n\tv962 = ~v961;\n\tv886 = v962 | v894;\n\tif (v886) goto L_0146;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv863 = this.canvasGroup;\n\tgoto L_012D;\nL_FFFFFFFF:\n\tv863 = this.canvasGroup;\n\tv433 = this.canvasGroup == 0;\n\tif (v433) goto L_0303;\n\tUnityEngine.CanvasGroup::set_alpha(this.canvasGroup, 0f);\n\treturn;\nL_0146:\n\tv671 = this.labelFadeStartDistance;\n\tv972 = this.labelFadeStartDistance < 0;\n\tv973 = this.labelFadeStartDistance == 0;\n\tv976 = this.labelFadeStartDistance == this.labelFadeStartDistance;\n\tv977 = ~v976;\n\tv978 = v972 == v977;\n\tv979 = ~v978;\n\tv980 = v979 | v973;\nL_FFFFFFFF:\n\tv551 = 1f;\n\tif (v980) goto L_0192;\n\tv982 = v645 < this.labelFadeStartDistance;\n\tv983 = v645 == this.labelFadeStartDistance;\n\tv986 = v645 == v645;\n\tv987 = this.labelFadeStartDistance == this.labelFadeStartDistance;\n\tv988 = v986 & v987;\n\tv989 = ~v988;\n\tv990 = v982 == v989;\n\tv991 = ~v990;\n\tv992 = v991 | v983;\nL_FFFFFFFF:\n\tv551 = 1f;\n\tif (v992) goto L_0192;\n\tv1009 = v553 < this.labelFadeStartDistance;\n\tv1007 = v553 == this.labelFadeStartDistance;\n\tv1018 = v553 == v553;\n\tv995 = this.labelFadeStartDistance == this.labelFadeStartDistance;\n\tv1003 = v1018 & v995;\n\tv1001 = ~v1003;\n\tv1019 = v1009 == v1001;\n\tv1020 = ~v1019;\n\tv999 = v1020 | v1007;\nL_FFFFFFFF:\n\tv551 = 1f;\n\tif (v999) goto L_0192;\n\tv658 = v553 - this.labelFadeStartDistance;\n\tv1027 = v645 - this.labelFadeStartDistance;\n\tv1028 = v658 / v1027;\n\tv1030 = 1f - v1028;\n\tv1031 = v1030 < 1f;\n\tv1032 = v1030 == 1f;\n\tv1035 = v1030 == v1030;\n\tv996 = 1f == 1f;\n\tv1036 = v1035 & v996;\n\tv1037 = ~v1036;\n\tv1038 = v1031 == v1037;\n\tv994 = ~v1032;\n\tv1000 = v1038 & v994;\n\tv1039 = ~v1000;\n\tif (v1039) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv671 = 1f;\n\tgoto L_0187;\nL_FFFFFFFF:\n\tv671 = v1030;\nL_FFFFFFFF:\n\tv551 = 0;\nL_FFFFFFFF:\n\tv645 = 0;\n\tgoto L_0192;\nL_FFFFFFFF:\n\tv551 = v671;\nL_FFFFFFFF:\n\tv645 = 0;\n\tv736 = this.canvasGroup == 0;\n\tif (v736) goto L_0303;\n\tv645 = v551 * this.highlightAlpha;\n\tUnityEngine.CanvasGroup::set_alpha(this.canvasGroup, v645);\nL_01AD:\n\tv1053 = this.labelScaleByDistance != 1;\n\tif (v1053) goto L_01D9;\n\tv645 = this.labelMaxDistance;\n\tv616 = this.labelMaxDistance < 0;\n\tv604 = this.labelMaxDistance == 0;\n\tv580 = this.labelMaxDistance == this.labelMaxDistance;\n\tv568 = ~v580;\n\tv1057 = v616 == v568;\n\tv1058 = ~v1057;\n\tv557 = v1058 | v604;\n\tif (v557) goto L_01D9;\n\tv737 = this.panel == 0;\n\tif (v737) goto L_0303;\n\tv1062 = this.labelScaleMin - this.labelScaleMax;\n\tv1084 = v553 / this.labelMaxDistance;\n\tv1065 = v1084 < 1f;\n\tv1066 = v1084 == 1f;\n\tv1069 = v1084 == v1084;\n\tv1070 = 1f == 1f;\n\tv1071 = v1069 & v1070;\n\tv1072 = ~v1071;\n\tv1073 = v1065 == v1072;\n\tv1074 = ~v1066;\n\tv1075 = v1073 & v1074;\n\tv1076 = ~v1075;\n\tif (v1076) goto L_01D3;\nL_FFFFFFFF:\n\tv1084 = 1f;\n\tgoto L_01D3;\nL_01D9:\n\tv713 = 0x3D19AA0(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv738 = this.panel == 0;\nL_FFFFFFFF:\n\tv683 = this.panel;\n\tif (v738) goto L_0303;\nL_01DE:\n\t// 478 MakeStruct v130 @ AGG772720C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v645 @ V0_v26 (System.Single), v671 @ V1_v23 (System.Single), v658 @ V2_v17 (System.Single)\n\tUnityEngine.Transform::set_localScale(v683, v130);\n\tv739 = this.cam == 0;\n\tif (v739) goto L_0303;\n\t// 487 MakeStruct v127 @ AGG7727228_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v207 @ V8_v7 (System.Single), v204 @ V9_v7 (System.Single), v201 @ V10_v7 (System.Single)\n\tv646 = UnityEngine.Camera::WorldToScreenPoint(this.cam, v127);\n\tv1090 = UnityEngine.Screen::get_width();\n\tv1092 = UnityEngine.Screen::get_height();\n\tv740 = this.panel == 0;\n\tif (v740) goto L_0303;\n\tv1094 = this.viewportOffset.y * v1092;\n\tv679 = v646.y + v1094;\n\tv1096 = this.viewportOffset * v1090;\n\tv653 = v646 + v1096;\n\t// 513 MakeStruct v124 @ AGG7727280_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v653 @ V0_v36 (System.Single), v679 @ V1_v29 (System.Single), v646.z (System.Single)\n\tUnityEngine.Transform::set_position(this.panel, v124);\n\tv560 = this.labelRelativeAlignment != 1;\n\tif (v560) goto L_FFFFFFFF;\n\tgoto L_021B;\n\tv741 = this.cam == 0;\n\tif (v741) goto L_0303;\n\tv717 = UnityEngine.Component::get_transform(this.cam);\n\tv742 = v717 == 0;\n\tif (v742) goto L_0303;\n\tv648 = UnityEngine.Transform::get_position(v717);\n\tv743 = this.labelAlignmentTransform == 0;\n\tif (v743) goto L_0303;\n\tv1168 = UnityEngine.Transform::get_position(this.labelAlignmentTransform);\n\tv649 = v648 - v1168;\n\tv675 = v648.y - v1168.y;\n\tv662 = v648.z - v1168.z;\n\tv730 = v649;\n\tv1184 = 0x77274D4(&v730 @ stack_-80_v5 (System.Single), 0, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v649, v675, v662, clobbered_V3, clobbered_V4, clobbered_V5, clobbered\n// ... truncated")]
		public virtual void UpdatePosition()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightLabel::UpdatePosition");
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x7727658", Offset = "0x7727658", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isVisible = 1;\n\treturn;\n")]
		public virtual void Show()
		{
			isVisible = true;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x7727664", Offset = "0x7727664", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv52 = UnityEngine.Object::op_Equality(this, 0);\n\tv60 = v52 == 0;\n\tif (v60) goto L_0038;\n\treturn;\nL_0038:\n\tv84 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v84, 0);\n\tthis.isVisible = 0;\n\treturn;\n")]
		public virtual void Hide()
		{
			if (!(this == null))
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
				isVisible = false;
			}
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x7727728", Offset = "0x7727728", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv52 = UnityEngine.Object::op_Equality(this, 0);\n\tv60 = v52 == 0;\n\tif (v60) goto L_0033;\n\tgoto L_0053;\nL_0033:\n\tv75 = HighlightPlus.HighlightLabel::Hide(this);\n\tv86 = this.isPooled != 1;\n\tif (v86) goto L_0053;\n\tv123 = HighlightPlus.HighlightLabel::ReturnToPool(v123);\n\treturn;\nL_0053:\n\treturn;\n")]
		public virtual void Release()
		{
			if (!(this == null))
			{
				Hide();
				if (isPooled)
				{
					HighlightLabel highlightLabel = default(HighlightLabel);
					highlightLabel.ReturnToPool();
				}
			}
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x77277FC", Offset = "0x77277FC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.labelMaxDistance = 13510801146249216d;\n\tthis.labelScaleMin = 0f;\n\tthis.highlightAlpha = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public HighlightLabel()
		{
			labelMaxDistance = 250f;
			labelFadeStartDistance = 200f;
			labelScaleMin = 0f;
			highlightAlpha = 1f;
		}
	}
}

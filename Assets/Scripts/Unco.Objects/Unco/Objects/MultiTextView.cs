using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using Unco.TextViewSystem;
using UnityEngine;

namespace Unco.Objects
{
	[ExecuteAlways]
	[Token(Token = "0x2000028")]
	public class MultiTextView : TextView
	{
		[SerializeField]
		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x20")]
		private UncoTMP m_backgroundText;

		[SerializeField]
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x28")]
		private UncoTMP m_foregroundText;

		[Header("Multi Outline Settings")]
		[SerializeField]
		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x30")]
		private bool m_hasMultiOutline;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x38")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x17000012")]
		public UncoTMP ForegroundText
		{
			[Token(Token = "0x60000AF")]
			[Address(RVA = "0x81C494C", Offset = "0x81C494C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ForegroundText;\n")]
			get
			{
				return m_foregroundText;
			}
		}

		[Token(Token = "0x17000013")]
		public UncoTMP BackgroundText
		{
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x81C4954", Offset = "0x81C4954", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.BackgroundText;\n")]
			get
			{
				return m_backgroundText;
			}
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x81C495C", Offset = "0x81C495C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis.m_rectTransform = v46;\n\treturn;\n")]
		private void Awake()
		{
			RectTransform component = GetComponent<RectTransform>();
			m_rectTransform = component;
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x81C49C0", Offset = "0x81C49C0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = 0xB79A000;\n\tv26 = *([B79A069]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_003F;\n\tthis.m_hasMultiOutline = hasMultiOutline;\n\tv53 = this.m_rectTransform;\n\tgoto L_001E;\nL_001E:\n\tv64 = UnityEngine.Object::op_Equality(v53, 0);\n\tv74 = ~v64;\n\tif (v74) goto L_002B;\n\tv94 = UnityEngine.Component::GetComponent(this);\n\tthis.m_rectTransform = v94;\nL_002B:\n\tUnco.Objects.MultiTextView::CreateTextObjects(this);\n\tUnco.Objects.MultiTextView::UpdateMultiOutline(this);\n\treturn;\nL_003F:\n\t*([v22 @ X20_v1+69]) = 1;\n\tthis.m_hasMultiOutline = hasMultiOutline;\n\tv53 = this.m_rectTransform;\n\tgoto L_001E;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(bool hasMultiOutline = false, float outlineDilate = 1.5f, Color? outlineColor = null)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192520192;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B79A069]");
			Object rectTransform;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				m_hasMultiOutline = hasMultiOutline;
				rectTransform = m_rectTransform;
			}
			else
			{
				_ = 1;
				m_hasMultiOutline = hasMultiOutline;
				rectTransform = m_rectTransform;
			}
			if (rectTransform == null)
			{
				RectTransform component = GetComponent<RectTransform>();
				m_rectTransform = component;
			}
			CreateTextObjects();
			UpdateMultiOutline();
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x81C4AB4", Offset = "0x81C4AB4", Length = "0x684")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0037:\n\tv70 = UnityEngine.Object::op_Equality(this.BackgroundText, 0);\n\tv74 = ~v70;\n\tif (v74) goto L_0112;\n\tv81 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v81, \"BackgroundText\");\n\tv161 = UnityEngine.GameObject::get_transform(v81);\n\tv271 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v161, v271);\n\tv279 = UnityEngine.GameObject::get_transform(v81);\n\tgoto L_006C;\nL_006C:\n\t// 108 MakeStruct v108 @ AGG81C4C14_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v415.zero (UnityEngine.Vector3), v415.zero.y (System.Single), v415.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v279, v108);\n\tv280 = UnityEngine.GameObject::get_transform(v81);\n\tgoto L_008A;\nL_008A:\n\t// 138 MakeStruct v101 @ AGG81C4C70_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v450.identity (UnityEngine.Quaternion), v450.identity.y (System.Single), v450.identity.z (System.Single), v450.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v280, v101);\n\tv281 = UnityEngine.GameObject::get_transform(v81);\n\tgoto L_00A5;\nL_00A5:\n\t// 165 MakeStruct v98 @ AGG81C4CC4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v484.one (UnityEngine.Vector3), v484.one.y (System.Single), v484.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v281, v98);\n\tv492 = UnityEngine.GameObject::AddComponent(v81);\n\tthis.BackgroundText = v492;\n\tv510 = UnityEngine.GameObject::GetComponent(v81);\n\tgoto L_00CB;\nL_00CB:\n\t// 203 MakeStruct v95 @ AGG81C4D44_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v532.zero (UnityEngine.Vector2), v532.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(v510, v95);\n\tgoto L_00DE;\n\tv127 = UnityEngine.UI.Graphic::set_raycastTarget(this.BackgroundText, 0);\nL_0115:\n\tv146 = UnityEngine.Object::op_Equality(this.ForegroundText, 0);\n\tv153 = ~v146;\n\tv154 = ~v153;\n\tif (v154) goto L_0124;\n\tgoto L_01F9;\nL_0124:\n\tv273 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v273, \"ForegroundText\");\n\tv396 = UnityEngine.GameObject::get_transform(v273);\n\tv274 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v396, v274);\n\tv284 = UnityEngine.GameObject::get_transform(v273);\n\tgoto L_0155;\nL_0155:\n\t// 341 MakeStruct v191 @ AGG81C4EF8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v445.zero (UnityEngine.Vector3), v445.zero.y (System.Single), v445.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v284, v191);\n\tv285 = UnityEngine.GameObject::get_transform(v273);\n\tgoto L_0173;\nL_0173:\n\t// 371 MakeStruct v187 @ AGG81C4F54_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v481.identity (UnityEngine.Quaternion), v481.identity.y (System.Single), v481.identity.z (System.Single), v481.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v285, v187);\n\tv286 = UnityEngine.GameObject::get_transform(v273);\n\tgoto L_018E;\nL_018E:\n\t// 398 MakeStruct v183 @ AGG81C4FA8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v512.one (UnityEngine.Vector3), v512.one.y (System.Single), v512.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v286, v183);\n\tv522 = UnityEngine.GameObject::AddComponent(v273);\n\tthis.ForegroundText = v522;\n\tv540 = UnityEngine.GameObject::GetComponent(v273);\n\tgoto L_01B4;\nL_01B4:\n\t// 436 MakeStruct v179 @ AGG81C5028_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v571.zero (UnityEngine.Vector2), v571.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(v540, v179);\n\tgoto L_01C7;\n\tv343 = UnityEngine.UI.Graphic::set_raycastTarget(this.ForegroundText, 0);\nL_01F9:\n\tv276 = TMPro.TMP_Text::get_transform(this.BackgroundText);\n\tUnityEngine.Transform::SetAsFirstSibling(v276);\n\tv278 = TMPro.TMP_Text::get_transform(this.ForegroundText);\n\tUnityEngine.Transform::SetAsLastSibling(v278);\n\treturn;\nL_0030:\n\tgoto L_0037;\nL_0112:\n\tgoto L_0115;\nL_00DE:\n\t// 222 MakeStruct v89 @ AGG81C4D7C_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v556.one (UnityEngine.Vector2), v556.one.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(v510, v89);\n\tgoto L_00F0;\nL_00F0:\n\t// 240 MakeStruct v86 @ AGG81C4DB0_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v583.zero (UnityEngine.Vector2), v583.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v510, v86);\n\tgoto L_0102;\nL_0102:\n\t// 258 MakeStruct v83 @ AGG81C4DE4_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v313.zero (UnityEngine.Vector2), v313.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition(v510, v83);\nL_01C7:\n\t// 455 MakeStruct v172 @ AGG81C5060_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v603.one (UnityEngine.Vector2), v603.one.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(v540, v172);\n\tgoto L_01D9;\nL_01D9:\n\t// 473 MakeStruct v168 @ AGG81C5094_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v627.zero (UnityEngine.Vector2), v627.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v540, v168);\n\tgoto L_01EB;\nL_01EB:\n\t// 491 MakeStruct v164 @ AGG81C50C8_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v315.zero (UnityEngine.Vector2), v315.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition(v540, v164);\n")]
		private void CreateTextObjects()
		{
			if (BackgroundText == null)
			{
				GameObject gameObject = new GameObject("BackgroundText");
				Transform transform = gameObject.transform;
				Transform parent = base.transform;
				transform.SetParent(parent);
				Transform transform2 = gameObject.transform;
				Vector3 localPosition = default(Vector3);
				localPosition.x = Vector3.zero.x;
				localPosition.y = Vector3.zero.y;
				localPosition.z = Vector3.zero.z;
				transform2.localPosition = localPosition;
				Transform transform3 = gameObject.transform;
				Quaternion localRotation = default(Quaternion);
				localRotation.x = Quaternion.identity.x;
				localRotation.y = Quaternion.identity.y;
				localRotation.z = Quaternion.identity.z;
				localRotation.w = Quaternion.identity.w;
				transform3.localRotation = localRotation;
				Transform transform4 = gameObject.transform;
				Vector3 localScale = default(Vector3);
				localScale.x = Vector3.one.x;
				localScale.y = Vector3.one.y;
				localScale.z = Vector3.one.z;
				transform4.localScale = localScale;
				UncoTMP backgroundText = gameObject.AddComponent<UncoTMP>();
				m_backgroundText = backgroundText;
				RectTransform component = gameObject.GetComponent<RectTransform>();
				Vector2 anchorMin = default(Vector2);
				anchorMin.x = Vector2.zero.x;
				anchorMin.y = Vector2.zero.y;
				component.anchorMin = anchorMin;
				Vector2 anchorMax = default(Vector2);
				anchorMax.x = Vector2.one.x;
				anchorMax.y = Vector2.one.y;
				component.anchorMax = anchorMax;
				Vector2 sizeDelta = default(Vector2);
				sizeDelta.x = Vector2.zero.x;
				sizeDelta.y = Vector2.zero.y;
				component.sizeDelta = sizeDelta;
				Vector2 anchoredPosition = default(Vector2);
				anchoredPosition.x = Vector2.zero.x;
				anchoredPosition.y = Vector2.zero.y;
				component.anchoredPosition = anchoredPosition;
				BackgroundText.raycastTarget = false;
			}
			if (ForegroundText == null)
			{
				GameObject gameObject2 = new GameObject("ForegroundText");
				Transform transform5 = gameObject2.transform;
				Transform parent2 = base.transform;
				transform5.SetParent(parent2);
				Transform transform6 = gameObject2.transform;
				Vector3 localPosition2 = default(Vector3);
				localPosition2.x = Vector3.zero.x;
				localPosition2.y = Vector3.zero.y;
				localPosition2.z = Vector3.zero.z;
				transform6.localPosition = localPosition2;
				Transform transform7 = gameObject2.transform;
				Quaternion localRotation2 = default(Quaternion);
				localRotation2.x = Quaternion.identity.x;
				localRotation2.y = Quaternion.identity.y;
				localRotation2.z = Quaternion.identity.z;
				localRotation2.w = Quaternion.identity.w;
				transform7.localRotation = localRotation2;
				Transform transform8 = gameObject2.transform;
				Vector3 localScale2 = default(Vector3);
				localScale2.x = Vector3.one.x;
				localScale2.y = Vector3.one.y;
				localScale2.z = Vector3.one.z;
				transform8.localScale = localScale2;
				UncoTMP foregroundText = gameObject2.AddComponent<UncoTMP>();
				m_foregroundText = foregroundText;
				RectTransform component2 = gameObject2.GetComponent<RectTransform>();
				Vector2 anchorMin2 = default(Vector2);
				anchorMin2.x = Vector2.zero.x;
				anchorMin2.y = Vector2.zero.y;
				component2.anchorMin = anchorMin2;
				Vector2 anchorMax2 = default(Vector2);
				anchorMax2.x = Vector2.one.x;
				anchorMax2.y = Vector2.one.y;
				component2.anchorMax = anchorMax2;
				Vector2 sizeDelta2 = default(Vector2);
				sizeDelta2.x = Vector2.zero.x;
				sizeDelta2.y = Vector2.zero.y;
				component2.sizeDelta = sizeDelta2;
				Vector2 anchoredPosition2 = default(Vector2);
				anchoredPosition2.x = Vector2.zero.x;
				anchoredPosition2.y = Vector2.zero.y;
				component2.anchoredPosition = anchoredPosition2;
				ForegroundText.raycastTarget = false;
			}
			Transform transform9 = BackgroundText.transform;
			transform9.SetAsFirstSibling();
			Transform transform10 = ForegroundText.transform;
			transform10.SetAsLastSibling();
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x81C53DC", Offset = "0x81C53DC", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Inequality(this.ForegroundText, 0);\n\tv64 = ~v56;\n\tv65 = ~v64;\n\tif (v65) goto L_0041;\n\tv99 = this.BackgroundText;\n\tgoto L_0025;\nL_0025:\n\tv104 = UnityEngine.Object::op_Inequality(v99, 0);\n\tv152 = ~v104;\n\tv153 = ~v152;\n\tif (v153) goto L_0059;\n\tgoto L_0070;\nL_0041:\n\tTMPro.TMP_Text::SetText(this.ForegroundText, text);\n\tv99 = this.BackgroundText;\n\tgoto L_0025;\nL_0059:\n\tv114 = this.m_hasMultiOutline != 1;\n\tif (v114) goto L_0070;\n\tTMPro.TMP_Text::SetText(this.BackgroundText, text);\n\treturn;\nL_0070:\n\treturn;\n")]
		public override void SetText(string text)
		{
			Object backgroundText;
			if (!(ForegroundText != null))
			{
				backgroundText = BackgroundText;
			}
			else
			{
				((TMP_Text)ForegroundText).SetText(text);
				backgroundText = BackgroundText;
			}
			if (backgroundText != null && m_hasMultiOutline)
			{
				((TMP_Text)BackgroundText).SetText(text);
			}
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x81C550C", Offset = "0x81C550C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.ForegroundText, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_003F;\n\tv76 = this.ForegroundText;\n\tv76 = TMPro.TMP_Text::get_text(v76);\n\treturn v76;\nL_003F:\n\tv85 = 0xB7D5000 + 0x538;\n\tv86 = *([v85 @ X8_v4 (System.Int32)+90]);\n\tv87 = *([v86 @ X8_v5+B8]);\n\treturn *([v87 @ X8_v6]);\n")]
		public override string GetText()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MultiTextView::GetText");
			return default;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x81C55E0", Offset = "0x81C55E0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Inequality(this.ForegroundText, 0);\n\tv64 = ~v56;\n\tv65 = ~v64;\n\tif (v65) goto L_0041;\n\tv99 = this.BackgroundText;\n\tgoto L_0025;\nL_0025:\n\tv104 = UnityEngine.Object::op_Inequality(v99, 0);\n\tv152 = ~v104;\n\tv153 = ~v152;\n\tif (v153) goto L_0059;\n\tgoto L_0070;\nL_0041:\n\tTMPro.TMP_Text::set_font(this.ForegroundText, font);\n\tv99 = this.BackgroundText;\n\tgoto L_0025;\nL_0059:\n\tv114 = this.m_hasMultiOutline != 1;\n\tif (v114) goto L_0070;\n\tTMPro.TMP_Text::set_font(this.BackgroundText, font);\n\treturn;\nL_0070:\n\treturn;\n")]
		public void SetFont(TMP_FontAsset font)
		{
			Object backgroundText;
			if (!(ForegroundText != null))
			{
				backgroundText = BackgroundText;
			}
			else
			{
				ForegroundText.font = font;
				backgroundText = BackgroundText;
			}
			if (backgroundText != null && m_hasMultiOutline)
			{
				BackgroundText.font = font;
			}
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x81C5710", Offset = "0x81C5710", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv60 = UnityEngine.Object::op_Inequality(this.ForegroundText, 0);\n\tv68 = ~v60;\n\tv69 = ~v68;\n\tif (v69) goto L_0043;\n\tv104 = this.BackgroundText;\n\tgoto L_0027;\nL_0027:\n\tv109 = UnityEngine.Object::op_Inequality(v104, 0);\n\tv160 = ~v109;\n\tv161 = ~v160;\n\tif (v161) goto L_005B;\n\tgoto L_0076;\nL_0043:\n\tTMPro.TMP_Text::set_fontSize(this.ForegroundText, size);\n\tv104 = this.BackgroundText;\n\tgoto L_0027;\nL_005B:\n\tv120 = this.m_hasMultiOutline != 1;\n\tif (v120) goto L_0076;\n\tTMPro.TMP_Text::set_fontSize(this.BackgroundText, size);\n\treturn;\nL_0076:\n\treturn;\n")]
		public void SetFontSize(float size)
		{
			Object backgroundText;
			if (!(ForegroundText != null))
			{
				backgroundText = BackgroundText;
			}
			else
			{
				ForegroundText.fontSize = size;
				backgroundText = BackgroundText;
			}
			if (backgroundText != null && m_hasMultiOutline)
			{
				BackgroundText.fontSize = size;
			}
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x81C584C", Offset = "0x81C584C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tgoto L_0023;\nL_0023:\n\tv67 = UnityEngine.Object::op_Inequality(this.ForegroundText, 0);\n\tv75 = ~v67;\n\tif (v75) goto L_005A;\n\tv87 = TMPro.TMP_Text::set_color(v87, Color_arg);\n\treturn;\nL_005A:\n\treturn;\n")]
		public override void SetColor(Color color)
		{
			if (ForegroundText != null)
			{
				UncoTMP uncoTMP = default(UncoTMP);
				Color color2 = default(Color);
				uncoTMP.color = color2;
			}
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x81C5944", Offset = "0x81C5944", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.ForegroundText, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_0047;\n\tv75 = this.ForegroundText;\n\tv75 = TMPro.TMP_Text::get_color(v75);\n\treturn v75;\nL_0047:\n\treturn 0;\n")]
		public override Color GetColor()
		{
			if (ForegroundText != null)
			{
				UncoTMP foregroundText = ForegroundText;
				return foregroundText.color;
			}
			return default(Color);
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x81C5A14", Offset = "0x81C5A14", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Inequality(this.ForegroundText, 0);\n\tv64 = ~v56;\n\tv65 = ~v64;\n\tif (v65) goto L_0041;\n\tv99 = this.BackgroundText;\n\tgoto L_0025;\nL_0025:\n\tv104 = UnityEngine.Object::op_Inequality(v99, 0);\n\tv152 = ~v104;\n\tv153 = ~v152;\n\tif (v153) goto L_0059;\n\tgoto L_0070;\nL_0041:\n\tTMPro.TMP_Text::set_alignment(this.ForegroundText, alignment);\n\tv99 = this.BackgroundText;\n\tgoto L_0025;\nL_0059:\n\tv114 = this.m_hasMultiOutline != 1;\n\tif (v114) goto L_0070;\n\tTMPro.TMP_Text::set_alignment(this.BackgroundText, alignment);\n\treturn;\nL_0070:\n\treturn;\n")]
		public void SetAlignment(TextAlignmentOptions alignment)
		{
			Object backgroundText;
			if (!(ForegroundText != null))
			{
				backgroundText = BackgroundText;
			}
			else
			{
				ForegroundText.alignment = alignment;
				backgroundText = BackgroundText;
			}
			if (backgroundText != null && m_hasMultiOutline)
			{
				BackgroundText.alignment = alignment;
			}
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x81C5138", Offset = "0x81C5138", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_002A;\nL_002A:\n\tv71 = UnityEngine.Object::op_Equality(this.BackgroundText, 0);\n\tv76 = v71 == 0;\n\tif (v76) goto L_003C;\n\tgoto L_0047;\nL_003C:\n\tgoto L_0040;\nL_0040:\n\tv70 = UnityEngine.Object::op_Equality(this.ForegroundText, 0);\n\tv75 = ~v70;\n\tif (v75) goto L_007C;\nL_0047:\n\tgoto L_004B;\nL_004B:\n\tv92 = UnityEngine.Object::op_Inequality(this.BackgroundText, 0);\n\tv96 = ~v92;\n\tif (v96) goto L_006F;\n\tv130 = UnityEngine.Component::get_gameObject(this.BackgroundText);\n\tUnityEngine.GameObject::SetActive(v130, 0);\n\treturn;\nL_006F:\n\treturn;\nL_007C:\n\tv166 = UnityEngine.Component::get_gameObject(this.BackgroundText);\n\tUnityEngine.GameObject::SetActive(v166, 1);\n\tv206 = this.ForegroundText;\n\tTMPro.TMP_Text::set_font(this.BackgroundText, v206.font);\n\tv207 = this.ForegroundText;\n\tTMPro.TMP_Text::set_fontSize(this.BackgroundText, v207.fontSize);\n\tv170 = TMPro.TMP_Text::get_text(this.ForegroundText);\n\tv250 = TMPro.TMP_Text::set_text(this.BackgroundText, v170);\n\tv172 = TMPro.TMP_Text::get_alignment(this.ForegroundText);\n\tTMPro.TMP_Text::set_alignment(this.BackgroundText, v172);\n\tv210 = this.ForegroundText;\n\tTMPro.TMP_Text::set_fontStyle(this.BackgroundText, v210.fontStyle);\n\tv211 = this.ForegroundText;\n\tTMPro.TMP_Text::set_characterSpacing(this.BackgroundText, v211.characterSpacing);\n\tv212 = this.ForegroundText;\n\tTMPro.TMP_Text::set_lineSpacing(this.BackgroundText, v212.lineSpacing);\n\tTMPro.TMP_Text::set_enableVertexGradient(this.BackgroundText, 0);\n\tv179 = TMPro.TMP_Text::get_transform(this.BackgroundText);\n\tUnityEngine.Transform::SetAsFirstSibling(v179);\n\tv181 = TMPro.TMP_Text::get_transform(this.ForegroundText);\n\tUnityEngine.Transform::SetAsLastSibling(v181);\n\treturn;\nL_0020:\n\tv54 = this.m_hasMultiOutline != 1;\n\tif (v54) goto L_0047;\n")]
		public void UpdateMultiOutline()
		{
			if (!m_hasMultiOutline || BackgroundText == null || ForegroundText == null)
			{
				if (BackgroundText != null)
				{
					GameObject gameObject = BackgroundText.gameObject;
					gameObject.SetActive(value: false);
				}
				return;
			}
			GameObject gameObject2 = BackgroundText.gameObject;
			gameObject2.SetActive(value: true);
			UncoTMP foregroundText = ForegroundText;
			BackgroundText.font = foregroundText.font;
			UncoTMP foregroundText2 = ForegroundText;
			BackgroundText.fontSize = foregroundText2.fontSize;
			string text = ForegroundText.text;
			BackgroundText.text = text;
			TextAlignmentOptions alignment = ForegroundText.alignment;
			BackgroundText.alignment = alignment;
			UncoTMP foregroundText3 = ForegroundText;
			BackgroundText.fontStyle = foregroundText3.fontStyle;
			UncoTMP foregroundText4 = ForegroundText;
			BackgroundText.characterSpacing = foregroundText4.characterSpacing;
			UncoTMP foregroundText5 = ForegroundText;
			BackgroundText.lineSpacing = foregroundText5.lineSpacing;
			BackgroundText.enableVertexGradient = false;
			Transform transform = BackgroundText.transform;
			transform.SetAsFirstSibling();
			Transform transform2 = ForegroundText.transform;
			transform2.SetAsLastSibling();
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x81C5B44", Offset = "0x81C5B44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_hasMultiOutline = enable;\n\tUnco.Objects.MultiTextView::UpdateMultiOutline(this);\n\treturn;\n")]
		public void SetMultiOutline(bool enable, float dilate = 1.5f, Color? color = null)
		{
			m_hasMultiOutline = enable;
			UpdateMultiOutline();
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x81C5B4C", Offset = "0x81C5B4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MultiTextView()
		{
		}
	}
}

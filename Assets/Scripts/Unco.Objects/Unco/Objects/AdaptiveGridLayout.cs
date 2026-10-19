using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unco.Objects
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("Layout/Adaptive Grid Layout")]
	[Token(Token = "0x2000024")]
	public class AdaptiveGridLayout : UIBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x20")]
		private RectOffset m_padding;

		[SerializeField]
		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x28")]
		private Vector2 m_spacing;

		[SerializeField]
		[Min(0f)]
		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x30")]
		private int m_maxColumns;

		[SerializeField]
		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x34")]
		private LastRowAlignment m_lastRowAlignment;

		[SerializeField]
		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x38")]
		private bool m_ignoreInactiveChildren;

		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x40")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x48")]
		private AdaptiveGridLayoutCalculator.CellRect[] m_buffer;

		[Token(Token = "0x1700000C")]
		public RectOffset Padding
		{
			[Token(Token = "0x600009A")]
			[Address(RVA = "0x81C3D00", Offset = "0x81C3D00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Padding;\n")]
			get
			{
				return m_padding;
			}
			[Token(Token = "0x600009B")]
			[Address(RVA = "0x81C3D08", Offset = "0x81C3D08", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Padding = value;\n\tv33 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv34 = ~v33;\n\tif (v34) goto L_001E;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001E:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_padding = value;
				if (base.IsActive())
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x1700000D")]
		public Vector2 Spacing
		{
			[Token(Token = "0x600009C")]
			[Address(RVA = "0x81C3D8C", Offset = "0x81C3D8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Spacing;\n")]
			get
			{
				return m_spacing;
			}
			[Token(Token = "0x600009D")]
			[Address(RVA = "0x81C3D94", Offset = "0x81C3D94", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_spacing.x = value;\n\tthis.m_spacing.y = value.y;\n\tv17 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv30 = ~v17;\n\tif (v30) goto L_001D;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001D:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_spacing.x = value.x;
				m_spacing.y = value.y;
				if (base.IsActive())
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x1700000E")]
		public bool IgnoreInactiveChildren
		{
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x81C3DD4", Offset = "0x81C3DD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IgnoreInactiveChildren;\n")]
			get
			{
				return m_ignoreInactiveChildren;
			}
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x81C3DDC", Offset = "0x81C3DDC", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IgnoreInactiveChildren = value;\n\tv16 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv31 = ~v16;\n\tif (v31) goto L_001B;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001B:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_ignoreInactiveChildren = value;
				if (base.IsActive())
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x1700000F")]
		public int MaxColumns
		{
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x81C3E1C", Offset = "0x81C3E1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MaxColumns;\n")]
			get
			{
				return m_maxColumns;
			}
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x81C3E24", Offset = "0x81C3E24", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~value;\n\tv14 = value & v12;\n\tthis.MaxColumns = v14;\n\tv18 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv33 = ~v18;\n\tif (v33) goto L_001D;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001D:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				int num = ~value;
				int maxColumns = value & num;
				m_maxColumns = maxColumns;
				if (base.IsActive())
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x17000010")]
		public LastRowAlignment LastRowAlign
		{
			[Token(Token = "0x60000A2")]
			[Address(RVA = "0x81C3E68", Offset = "0x81C3E68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.LastRowAlign;\n")]
			get
			{
				return m_lastRowAlignment;
			}
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x81C3E70", Offset = "0x81C3E70", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.LastRowAlign = value;\n\tv16 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv31 = ~v16;\n\tif (v31) goto L_001B;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001B:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_lastRowAlignment = value;
				if (base.IsActive())
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x17000011")]
		private RectTransform RectTransform
		{
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0x81C3EB0", Offset = "0x81C3EB0", Length = "0x118")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv85 = this + 0x40;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_rectTransform, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_0040;\n\treturn *([v85 @ X19_v7]);\nL_0040:\n\tv102 = UnityEngine.Component::get_transform(this);\n\tv143 = v102 == 0;\n\tif (v143) goto L_0061;\n\tv167 = *([v102 @ X0_v3 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v167) goto L_0060;\n\t*([v85 @ X19_v7]) = v102;\n\tv195 = *([v102 @ X0_v3 (UnityEngine.Transform)]) == UnityEngine.RectTransform;\n\tif (v195) goto L_006D;\nL_0060:\n\tthrow System.InvalidCastException;\nL_0061:\n\t*([v85 @ X19_v7]) = 0;\nL_006D:\n\treturn *([v85 @ X19_v7]);\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AdaptiveGridLayout::get_RectTransform");
				return default;
			}
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x81C3FC8", Offset = "0x81C3FC8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.EventSystems.UIBehaviour::OnEnable(this);\n\tv17 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv32 = ~v17;\n\tif (v32) goto L_001D;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001D:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnEnable()
		{
			base.OnEnable();
			if (base.IsActive())
			{
				Rebuild();
			}
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x81C4010", Offset = "0x81C4010", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv30 = ~v15;\n\tif (v30) goto L_001A;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001A:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnRectTransformDimensionsChange()
		{
			if (base.IsActive())
			{
				Rebuild();
			}
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x81C404C", Offset = "0x81C404C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv30 = ~v15;\n\tif (v30) goto L_001A;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001A:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnTransformChildrenChanged()
		{
			if (base.IsActive())
			{
				Rebuild();
			}
		}

		[ContextMenu("Rebuild")]
		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x81C3D50", Offset = "0x81C3D50", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.EventSystems.UIBehaviour::IsActive(this);\n\tv30 = ~v15;\n\tif (v30) goto L_001A;\n\tUnco.Objects.AdaptiveGridLayout::Rebuild(this);\n\treturn;\nL_001A:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetDirty()
		{
			if (base.IsActive())
			{
				Rebuild();
			}
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x81C4088", Offset = "0x81C4088", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = 0xB79A000;\n\tv32 = *([B79A065]) & 1;\n\tv33 = v32 == 0;\n\tif (v33) goto L_002F;\n\tv35 = Unco.Objects.AdaptiveGridLayout::get_RectTransform(this);\nL_FFFFFFFF:\n\tv96 = v35;\n\tgoto L_0020;\nL_0020:\n\tv72 = UnityEngine.Object::op_Equality(v96, 0);\n\tv82 = v72 == 0;\n\tif (v82) goto L_0045;\n\tgoto L_0123;\nL_002F:\n\t*([v28 @ X20_v1+65]) = 1;\n\tv89 = Unco.Objects.AdaptiveGridLayout::get_RectTransform(this);\nL_FFFFFFFF:\n\tv96 = v89;\n\tgoto L_0020;\nL_0045:\n\tv203 = UnityEngine.RectTransform::get_rect(v96);\n\tv178 = v203.width == 0;\n\tv392 = v203.width < 0;\n\tv171 = ~v392;\n\tv393 = ~v171;\n\tv150 = v393 | v178;\n\tif (v150) goto L_0123;\n\tv179 = v203.height == 0;\n\tv405 = v203.height < 0;\n\tv172 = ~v405;\n\tv406 = ~v172;\n\tv151 = v406 | v179;\n\tif (v151) goto L_0123;\n\tv429 = Unco.Objects.AdaptiveGridLayout::CountLaidOutChildren(this);\n\tv221 = v429 == 0;\n\tif (v221) goto L_0123;\n\tv143 = this.m_buffer;\n\tv152 = v429 <= v143.Length;\n\tif (v152) goto L_008E;\n\tv413 = v429 - 1;\n\tv414 = v413 | v413;\n\tv415 = v414 | v414;\n\tv416 = v415 | v415;\n\tv417 = v416 | v416;\n\tv418 = v417 | v417;\n\tv422 = v418 + 1;\n\t// 128 NewArr v425 @ X0_v33 (CellRect[]), typeof(CellRect[]), v422 @ X1_v18 (System.Int32)\n\tthis.m_buffer = v425;\n\tv143 = this.m_buffer;\n\tv307 = UnityEngine.Component::get_transform(this);\n\tv218 = UnityEngine.Transform::get_childCount(v307);\n\tv153 = v218 < 1;\n\tif (v153) goto L_0123;\nL_FFFFFFFF:\n\tv252 = 0;\nL_FFFFFFFF:\n\tv119 = 0;\n\tgoto L_00C1;\nL_00B2:\n\tUnco.Objects.AdaptiveGridLayout::ApplyCell(v107, v305);\n\tv119 = v119 + 1;\nL_00C1:\n\tv308 = UnityEngine.Component::get_transform(this);\n\tv445 = UnityEngine.Transform::GetChild(v308, v252);\n\tv446 = v445 == 0;\n\tif (v446) goto L_FFFFFFFF;\n\tv458 = *([v445 @ X0_v18 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v458) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv467 = v445;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv467 = 0;\nL_00E3:\n\tv309 = UnityEngine.Object::op_Equality(v107, 0);\n\tv499 = v309 == 0;\n\tv500 = ~v499;\n\tif (v500) goto L_00B4;\n\tv274 = this.IgnoreInactiveChildren != 1;\nL_FFFFFFFF:\n\tv305 = 0;\n\tif (v274) goto L_00FF;\n\tv310 = UnityEngine.Component::get_gameObject(v107);\n\tv518 = UnityEngine.GameObject::get_activeSelf(v310);\n\tv519 = ~v518;\nL_FFFFFFFF:\n\tv305 = 0;\n\tif (v519) goto L_00B4;\nL_00FF:\n\tv321 = this.m_buffer;\n\tv524 = v119 < v321.Length;\n\tv401 = ~v524;\n\tv398 = ~v401;\n\tif (v398) goto L_00B2;\n\tgoto L_0125;\nL_FFFFFFFF:\n\tv107 = 0;\n\tgoto L_00E3;\nL_0123:\n\treturn;\nL_0125:\n\tthrow System.IndexOutOfRangeException;\nL_008E:\n\t// 142 MakeStruct v103 @ AGG81C41F4_4_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.Spacing (UnityEngine.Vector2), this.m_spacing.y (System.Single)\n\tv217 = Unco.Objects.AdaptiveGridLayoutCalculator::Calculate(v429, v203.width, v203.height, this.Padding, v103, this.MaxColumns, this.LastRowAlign, v143);\n\tv222 = ~v217;\n\tif (v222) goto L_0123;\nL_FFFFFFFF:\n\tv107 = v467;\n\tgoto L_00E3;\nL_00B4:\n\tv252 = v252 + 1;\n\tv182 = v218 == v252;\n\tif (v182) goto L_0123;\n")]
		private void Rebuild()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192520192;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B79A065]");
			RectTransform rectTransform2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				RectTransform rectTransform = RectTransform;
				rectTransform2 = rectTransform;
			}
			else
			{
				_ = 1;
				RectTransform rectTransform3 = RectTransform;
				rectTransform2 = rectTransform3;
			}
			if (rectTransform2 == null)
			{
				return;
			}
			Rect rect = rectTransform2.rect;
			bool flag = rect.width == 0f;
			bool flag2 = rect.width < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (flag4 || flag)
			{
				return;
			}
			bool flag5 = rect.height == 0f;
			bool flag6 = rect.height < 0f;
			bool flag7 = !flag6;
			bool flag8 = !flag7;
			if (flag8 || flag5)
			{
				return;
			}
			int num = CountLaidOutChildren();
			if (num == 0)
			{
				return;
			}
			AdaptiveGridLayoutCalculator.CellRect[] buffer = m_buffer;
			if (num > buffer.Length)
			{
				int num2 = num - 1;
				int num3 = num2 | num2;
				int num4 = num3 | num3;
				int num5 = num4 | num4;
				int num6 = num5 | num5;
				int num7 = num6 | num6;
				int num8 = num7 + 1;
				AdaptiveGridLayoutCalculator.CellRect[] buffer2 = new AdaptiveGridLayoutCalculator.CellRect[num8];
				m_buffer = buffer2;
				buffer = m_buffer;
			}
			Vector2 spacing = default(Vector2);
			spacing.x = Spacing.x;
			spacing.y = m_spacing.y;
			if (!AdaptiveGridLayoutCalculator.Calculate(num, rect.width, rect.height, Padding, spacing, MaxColumns, LastRowAlign, buffer))
			{
				return;
			}
			Transform transform = base.transform;
			int childCount = transform.childCount;
			if (childCount < 1)
			{
				return;
			}
			int num9 = 0;
			int num10 = 0;
			while (true)
			{
				Transform transform2 = base.transform;
				Transform child = transform2.GetChild(num9);
				UnityEngine.Object obj2;
				if ((object)child != null)
				{
					Transform transform3 = (((object)child.GetType() != typeof(RectTransform)) ? null : child);
					obj2 = transform3;
				}
				else
				{
					obj2 = null;
				}
				if (!(obj2 == null))
				{
					bool flag9 = !IgnoreInactiveChildren;
					AdaptiveGridLayoutCalculator.CellRect cell = default(AdaptiveGridLayoutCalculator.CellRect);
					if (!flag9)
					{
						GameObject gameObject = ((Component)obj2).gameObject;
						bool activeSelf = gameObject.activeSelf;
						bool flag10 = !activeSelf;
						cell = default(AdaptiveGridLayoutCalculator.CellRect);
						if (flag10)
						{
							goto IL_04b9;
						}
					}
					AdaptiveGridLayoutCalculator.CellRect[] buffer3 = m_buffer;
					if ((uint)num10 >= (uint)buffer3.Length)
					{
						break;
					}
					ApplyCell((RectTransform)obj2, cell);
					num10++;
				}
				goto IL_04b9;
				IL_04b9:
				num9++;
				if (childCount == num9)
				{
					return;
				}
			}
			throw new IndexOutOfRangeException();
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x81C46D8", Offset = "0x81C46D8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 23 MakeStruct v38 @ AGG81C4714_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 1f\n\tUnityEngine.RectTransform::set_anchorMin(child, v38);\n\t// 29 MakeStruct v53 @ AGG81C4728_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 1f\n\tUnityEngine.RectTransform::set_anchorMax(child, v53);\n\t// 36 MakeStruct v59 @ AGG81C4740_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tUnityEngine.RectTransform::set_pivot(child, v59);\n\t// 42 MakeStruct v70 @ AGG81C4754_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v29 @ V2, v27 @ V3\n\tUnityEngine.RectTransform::set_sizeDelta(child, v70);\n\tv104 = v29 * 0.5f;\n\tv89 = v33 + v104;\n\tv105 = v27 * 0.5f;\n\tv106 = v31 + v105;\n\tv87 = -v106;\n\t// 62 MakeStruct v61 @ AGG81C4788_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v89 @ V0_v6 (System.Single), v87 @ V1_v7\n\tUnityEngine.RectTransform::set_anchoredPosition(child, v61);\n\treturn;\n")]
		private static void ApplyCell(RectTransform child, AdaptiveGridLayoutCalculator.CellRect cell)
		{
			//IL_008d: Expected F4, but got O
			//IL_009a: Expected F4, but got O
			//IL_00f3: Expected O, but got F4
			//IL_010d: Expected F4, but got O
			Vector2 anchorMin = default(Vector2);
			anchorMin.x = 0f;
			anchorMin.y = 1f;
			child.anchorMin = anchorMin;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = 0f;
			anchorMax.y = 1f;
			child.anchorMax = anchorMax;
			Vector2 pivot = default(Vector2);
			pivot.x = 0.5f;
			pivot.y = 0.5f;
			child.pivot = pivot;
			Vector2 sizeDelta = default(Vector2);
			object obj = default(object);
			sizeDelta.x = (float)obj;
			object obj2 = default(object);
			sizeDelta.y = (float)obj2;
			child.sizeDelta = sizeDelta;
			float num = (float)obj * 0.5f;
			object obj3 = default(object);
			float x = (float)obj3 + num;
			float num2 = (float)obj2 * 0.5f;
			object obj4 = default(object);
			float num3 = (float)obj4 + num2;
			object obj5 = 0f - num3;
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = x;
			anchoredPosition.y = (float)obj5;
			child.anchoredPosition = anchoredPosition;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x81C4328", Offset = "0x81C4328", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv58 = UnityEngine.Transform::get_childCount(v53);\n\tv145 = v58 < 1;\n\tif (v145) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv78 = 0;\nL_FFFFFFFF:\n\tv220 = 0;\n\tgoto L_0044;\nL_0036:\n\tv220 = v220 + 1;\nL_0044:\n\tv122 = UnityEngine.Component::get_transform(this);\n\tv231 = UnityEngine.Transform::GetChild(v122, v78);\n\tv232 = v231 == 0;\n\tif (v232) goto L_FFFFFFFF;\n\tv244 = *([v231 @ X0_v12 (UnityEngine.Transform)]) != UnityEngine.RectTransform;\n\tif (v244) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv253 = v231;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv253 = 0;\nL_0066:\n\tv123 = UnityEngine.Object::op_Equality(v61, 0);\n\tv285 = v123 == 0;\n\tv286 = ~v285;\n\tif (v286) goto L_0037;\n\tv84 = this.IgnoreInactiveChildren != 1;\n\tif (v84) goto L_0036;\n\tv124 = UnityEngine.Component::get_gameObject(v61);\n\tv299 = UnityEngine.GameObject::get_activeSelf(v124);\n\tv305 = ~v299;\n\tv301 = ~v305;\n\tif (v301) goto L_0036;\n\tgoto L_0037;\nL_FFFFFFFF:\n\tv61 = 0;\n\tgoto L_0066;\nL_FFFFFFFF:\n\tv228 = 0;\nL_001D:\n\tv53 = UnityEngine.Component::get_transform(this);\nL_0098:\n\treturn v228;\nL_FFFFFFFF:\n\tv61 = v253;\n\tgoto L_0066;\nL_0037:\n\tv78 = v78 + 1;\n\tv209 = v58 == v78;\nL_FFFFFFFF:\n\tv228 = v220;\n\tif (v209) goto L_0098;\n")]
		private int CountLaidOutChildren()
		{
			Transform transform = base.transform;
			int childCount = transform.childCount;
			int result;
			if (childCount >= 1)
			{
				int num = 0;
				int num2 = 0;
				bool flag;
				do
				{
					Transform transform2 = base.transform;
					Transform child = transform2.GetChild(num);
					UnityEngine.Object obj;
					if ((object)child != null)
					{
						Transform transform3 = (((object)child.GetType() != typeof(RectTransform)) ? null : child);
						obj = transform3;
					}
					else
					{
						obj = null;
					}
					if (!(obj == null))
					{
						if (IgnoreInactiveChildren)
						{
							GameObject gameObject = ((Component)obj).gameObject;
							if (!gameObject.activeSelf)
							{
								goto IL_01ac;
							}
						}
						num2++;
					}
					goto IL_01ac;
					IL_01ac:
					num++;
					flag = childCount == num;
					result = num2;
				}
				while (!flag);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x81C4790", Offset = "0x81C4790", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn;\nL_0017:\n\tthis.IgnoreInactiveChildren = 1;\n\t// 26 NewArr v47 @ X0_v3 (CellRect[]), typeof(CellRect[]), 8\n\tthis.m_buffer = v47;\n\tUnityEngine.EventSystems.UIBehaviour::.ctor(this);\n")]
		public AdaptiveGridLayout()
		{
			m_ignoreInactiveChildren = true;
			AdaptiveGridLayoutCalculator.CellRect[] buffer = new AdaptiveGridLayoutCalculator.CellRect[8];
			m_buffer = buffer;
		}
	}
}

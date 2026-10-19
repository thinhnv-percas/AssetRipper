using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000016")]
	public class MultiTextView : TextView
	{
		[SerializeField]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x20")]
		private TextView[] m_textViewList;

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x81C2078", Offset = "0x81C2078", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv83 = System.Linq.Enumerable::Where(v63, v69);\n\tv87 = System.Linq.Enumerable::ToArray(v83);\n\tthis.m_textViewList = v87;\n\treturn;\nL_0030:\n\tv63 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv69 = new System.Func`2<Unco.TextViewSystem.TextView, System.Boolean>();\n\tSystem.Func`2<Unco.TextViewSystem.TextView, System.Boolean>::.ctor(v69, this, Il2CppMethodInfo);\n")]
		private void Reset()
		{
			TextView[] componentsInChildren = GetComponentsInChildren<TextView>();
			Func<TextView, bool> predicate = (TextView view) => view != this;
			IEnumerable<object> source = componentsInChildren.Where((Func<object, bool>)predicate);
			object[] textViewList = source.ToArray();
			m_textViewList = (TextView[])textViewList;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x81C2174", Offset = "0x81C2174", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_textViewList;\n\tv28 = v14.Length < 1;\n\tif (v28) goto L_0038;\n\tv43 = 0;\nL_0022:\n\tv94 = Unco.TextViewSystem.TextView::SetText(v14[v43 @ X21_v5 (System.Int32)], text);\n\tv43 = v43 + 1;\n\tv106 = v43 < v14.Length;\n\tif (v106) goto L_0022;\nL_0038:\n\treturn;\n")]
		public override void SetText(string text)
		{
			TextView[] textViewList = m_textViewList;
			if (textViewList.Length >= 1)
			{
				int num = 0;
				do
				{
					textViewList[num].SetText(text);
					num++;
				}
				while (num < textViewList.Length);
			}
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x81C21E0", Offset = "0x81C21E0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_textViewList;\n\tv12 = v6[0];\n\tv12 = Unco.TextViewSystem.TextView::GetText(v12);\n\treturn v12;\n")]
		public override string GetText()
		{
			TextView[] textViewList = m_textViewList;
			TextView textView = textViewList[0];
			return textView.GetText();
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x81C2218", Offset = "0x81C2218", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = this.m_textViewList;\n\tv40 = v26.Length < 1;\n\tif (v40) goto L_0049;\n\tv54 = 0;\nL_002F:\n\tv114 = Unco.TextViewSystem.TextView::SetColor(v26[v54 @ X20_v5 (System.Int32)], Color_arg);\n\tv54 = v54 + 1;\n\tv129 = v54 < v26.Length;\n\tif (v129) goto L_002F;\nL_0049:\n\treturn;\n")]
		public override void SetColor(Color color)
		{
			TextView[] textViewList = m_textViewList;
			if (textViewList.Length >= 1)
			{
				int num = 0;
				Color color2 = default(Color);
				do
				{
					textViewList[num].SetColor(color2);
					num++;
				}
				while (num < textViewList.Length);
			}
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x81C22AC", Offset = "0x81C22AC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_textViewList;\n\tv12 = v6[0];\n\tv12 = Unco.TextViewSystem.TextView::GetColor(v12);\n\treturn v12;\n")]
		public override Color GetColor()
		{
			TextView[] textViewList = m_textViewList;
			TextView textView = textViewList[0];
			return textView.GetColor();
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x81C22E4", Offset = "0x81C22E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MultiTextView()
		{
		}
	}
}

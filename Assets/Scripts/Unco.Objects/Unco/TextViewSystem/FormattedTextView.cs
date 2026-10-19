using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000011")]
	public class FormattedTextView : TextView
	{
		[SerializeField]
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_view;

		[SerializeField]
		[TextArea]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x28")]
		private string m_format;

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81C1B64", Offset = "0x81C1B64", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = System.String::Format(this.m_format, text);\n\tv21 = Unco.TextViewSystem.TextView::SetText(v21, v14);\n\treturn;\n")]
		public override void SetText(string text)
		{
			string text2 = string.Format(m_format, text);
			TextView textView = default(TextView);
			textView.SetText(text2);
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81C1BA0", Offset = "0x81C1BA0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_view;\n\tv0 = Unco.TextViewSystem.TextView::GetText(v0);\n\treturn v0;\n")]
		public override string GetText()
		{
			TextView view = m_view;
			return view.GetText();
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x81C1BC0", Offset = "0x81C1BC0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = Unco.TextViewSystem.TextView::SetColor(v4, Color_arg);\n\treturn;\n")]
		public override void SetColor(Color color)
		{
			TextView textView = default(TextView);
			Color color2 = default(Color);
			textView.SetColor(color2);
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x81C1BE0", Offset = "0x81C1BE0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_view;\n\tv0 = Unco.TextViewSystem.TextView::GetColor(v0);\n\treturn v0;\n")]
		public override Color GetColor()
		{
			TextView view = m_view;
			return view.GetColor();
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x81C1C00", Offset = "0x81C1C00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public FormattedTextView()
		{
		}
	}
}

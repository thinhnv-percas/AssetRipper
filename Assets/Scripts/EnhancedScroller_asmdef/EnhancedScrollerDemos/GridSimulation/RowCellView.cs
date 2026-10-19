using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.GridSimulation
{
	[Token(Token = "0x2000054")]
	public class RowCellView : MonoBehaviour
	{
		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x20")]
		public GameObject container;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x28")]
		public Text text;

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x402AFD4", Offset = "0x402AFD4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = data == 0;\n\tv25 = ~v20;\n\tUnityEngine.GameObject::SetActive(this.container, v25);\n\tv68 = data == 0;\n\tif (v68) goto L_002C;\n\tv53 = UnityEngine.UI.Text::set_text(v53, data.someText);\n\treturn;\nL_002C:\n\treturn;\n")]
		public void SetData(Data data)
		{
			bool flag = data == null;
			bool active = !flag;
			container.SetActive(active);
			if (data != null)
			{
				Text text = default(Text);
				text.text = data.someText;
			}
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0x402B434", Offset = "0x402B434", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RowCellView()
		{
		}
	}
}

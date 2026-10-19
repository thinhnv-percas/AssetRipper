using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EnhancedUI.EnhancedScroller
{
	[Token(Token = "0x2000016")]
	public class EnhancedScrollerCellView : MonoBehaviour
	{
		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x20")]
		public string cellIdentifier;

		[NonSerialized]
		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x28")]
		public int cellIndex;

		[NonSerialized]
		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x2C")]
		public int dataIndex;

		[NonSerialized]
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x30")]
		public bool active;

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x4022344", Offset = "0x4022344", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void RefreshCellView()
		{
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x4022348", Offset = "0x4022348", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public EnhancedScrollerCellView()
		{
		}
	}
}

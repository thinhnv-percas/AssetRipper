using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	[Token(Token = "0x2000078")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x38")]
		protected internal Data _data;

		[Token(Token = "0x6000249")]
		[Address(RVA = "0x4031768", Offset = "0x4031768", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._data = data;\n\treturn;\n")]
		public virtual void SetData(Data data)
		{
			_data = data;
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0x4031770", Offset = "0x4031770", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}

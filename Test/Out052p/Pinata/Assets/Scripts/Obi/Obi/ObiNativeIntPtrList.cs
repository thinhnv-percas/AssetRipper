using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x74448C", Offset = "0x74448C")]
	[Token(Token = "0x2000033")]
	public class ObiNativeIntPtrList : ObiNativeList<IntPtr>
	{
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x30")]
		private unsafe IntPtr* m_Ptr;

		[Token(Token = "0x17000045")]
		public unsafe override IntPtr Item
		{
			[Token(Token = "0x6000283")]
			[Address(RVA = "0xE47EC8", Offset = "0xE47EC8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_Ptr;\n\treturn *([v0 @ X8_v1 (System.IntPtr*)+index @ X1 (System.Int32)*8]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IntPtr* ptr = m_Ptr;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (System.IntPtr*)+index @ X1 (System.Int32)*8]");
				return (IntPtr)0;
			}
			[Token(Token = "0x6000284")]
			[Address(RVA = "0xE47ED4", Offset = "0xE47ED4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_Ptr;\n\t*([v0 @ X8_v1 (System.IntPtr*)+index @ X1 (System.Int32)*8]) = value;\n\treturn;\n")]
			set
			{
				IntPtr* ptr = m_Ptr;
			}
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xE47E20", Offset = "0xE47E20", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ECD480]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, capacity, alignment, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202476F]) = v44;\nL_001D:\n\tObi.ObiNativeList`1<System.IntPtr>::.ctor(this, capacity, alignment);\n\tv61 = capacity < 1;\n\tif (v61) goto L_0045;\nL_0031:\n\tv91 = Obi.ObiNativeIntPtrList::set_Item(this, v125, 0);\n\tv125 = v125 + 1;\n\tv73 = capacity != v125;\n\tif (v73) goto L_0031;\nL_0045:\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNativeIntPtrList(int capacity = 8, int alignment = 16)
			: base(capacity, alignment)
		{
			if (capacity >= 1)
			{
				int num = 0;
				int num2 = default(int);
				num = num2;
				do
				{
					this.set_Item(num, (IntPtr)0);
					num++;
				}
				while (capacity != num);
			}
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xE47EBC", Offset = "0xE47EBC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Ptr = this.m_AlignedPtr;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void CapacityChanged()
		{
			m_Ptr = (IntPtr*)m_AlignedPtr;
		}
	}
}

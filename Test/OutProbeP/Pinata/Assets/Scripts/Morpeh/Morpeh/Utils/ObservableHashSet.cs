using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh.Utils
{
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DA40", Offset = "0x73DA40")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DA40", Offset = "0x73DA40")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DA40", Offset = "0x73DA40")]
	[Token(Token = "0x2000033")]
	public class ObservableHashSet<T> : HashSet<T>
	{
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x0")]
		public Action<T> OnAddItem;

		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x0")]
		public Action<T> OnRemoveItem;

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x10A4D2C", Offset = "0x10A4D2C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = System.Collections.Generic.HashSet`1<T>::Add(this, item);\n\tv37 = v22 == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv39 = this.OnAddItem == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv46 = System.Action`1<T>::Invoke(this.OnAddItem, item);\n\tgoto L_0024;\nL_0024:\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public new bool Add(T item)
		{
			if (base.Add(item))
			{
				if (OnAddItem != null)
				{
					OnAddItem(item);
				}
				return true;
			}
			return false;
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x10A4D9C", Offset = "0x10A4D9C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = System.Collections.Generic.HashSet`1<T>::Remove(this, item);\n\tv37 = v22 == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv39 = this.OnRemoveItem == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv46 = System.Action`1<T>::Invoke(this.OnRemoveItem, item);\n\tgoto L_0024;\nL_0024:\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public new bool Remove(T item)
		{
			if (base.Remove(item))
			{
				if (OnRemoveItem != null)
				{
					OnRemoveItem(item);
				}
				return true;
			}
			return false;
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x10A4E0C", Offset = "0x10A4E0C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (Morpeh.Utils.ObservableHashSet`1<T>), this @ X0 (Morpeh.Utils.ObservableHashSet`1<T>), methodof(System.Collections.Generic.HashSet`1<T>::.ctor), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObservableHashSet()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
		}
	}
}

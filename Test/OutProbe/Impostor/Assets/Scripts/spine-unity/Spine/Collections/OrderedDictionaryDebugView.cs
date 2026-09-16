using System.Collections.Generic;
using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Collections
{
	[Token(Token = "0x20000D4")]
	internal class OrderedDictionaryDebugView<TKey, TValue>
	{
		[Token(Token = "0x400046E")]
		[FieldOffset(Offset = "0x0")]
		private readonly OrderedDictionary<TKey, TValue> dictionary;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		[Token(Token = "0x170001D3")]
		public KeyValuePair<TKey, TValue>[] Items
		{
			[Token(Token = "0x600078F")]
			[Address(RVA = "0x1133464", Offset = "0x1133464", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.dictionary;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 5 IndirectJump v6 @ X2_v1, v2 @ X0_v1 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), v2 @ X0_v1 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), methodof(System.Linq.Enumerable::ToArray), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0018: Expected O, but got I
				OrderedDictionary<TKey, TValue> orderedDictionary = dictionary;
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x600078E")]
		[Address(RVA = "0x113343C", Offset = "0x113343C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.dictionary = dictionary;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OrderedDictionaryDebugView(OrderedDictionary<TKey, TValue> dictionary)
		{
			this.dictionary = dictionary;
		}
	}
}

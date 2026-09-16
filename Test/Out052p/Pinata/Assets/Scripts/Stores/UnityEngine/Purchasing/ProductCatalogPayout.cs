using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Serializable]
	[Token(Token = "0x2000066")]
	public class ProductCatalogPayout
	{
		[Token(Token = "0x2000067")]
		public enum ProductCatalogPayoutType
		{
			[Token(Token = "0x4000158")]
			Other = 0,
			[Token(Token = "0x4000159")]
			Currency = 1,
			[Token(Token = "0x400015A")]
			Item = 2,
			[Token(Token = "0x400015B")]
			Resource = 3
		}

		[SerializeField]
		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x10")]
		private string t;

		[SerializeField]
		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x18")]
		private string st;

		[SerializeField]
		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x20")]
		private double q;

		[SerializeField]
		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x28")]
		private string d;

		[Token(Token = "0x1700002D")]
		public string typeString
		{
			[Token(Token = "0x6000179")]
			[Address(RVA = "0xC6B8CC", Offset = "0xC6B8CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.t;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return typeString;
			}
		}

		[Token(Token = "0x1700002E")]
		public string subtype
		{
			[Token(Token = "0x600017A")]
			[Address(RVA = "0xC6B8D4", Offset = "0xC6B8D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.st;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return subtype;
			}
		}

		[Token(Token = "0x1700002F")]
		public double quantity
		{
			[Token(Token = "0x600017B")]
			[Address(RVA = "0xC6B8DC", Offset = "0xC6B8DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.q;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return quantity;
			}
		}

		[Token(Token = "0x17000030")]
		public string data
		{
			[Token(Token = "0x600017C")]
			[Address(RVA = "0xC6B8E4", Offset = "0xC6B8E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.d;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return data;
			}
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0xC6B8EC", Offset = "0xC6B8EC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1F09120]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023397]) = v40;\nL_0017:\n\tv44 = 0;\n\t// 25 Box v46 @ X0_v3, typeof(UnityEngine.Purchasing.ProductCatalogPayout+ProductCatalogPayoutType), &v44 @ stack_-24_v1\n\tv49 = *([v46 @ X0_v3]);\n\t*([v49 @ X8_v5+160])(v53, v46, *([v49 @ X8_v5+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = \"il2cpp_vm_object_unbox\"(v46, *([v49 @ X8_v5+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tthis.t = v53;\n\tthis.st = v65.Empty;\n\tthis.d = v67.Empty;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProductCatalogPayout()
		{
			//IL_0056: Expected O, but got I4
			//IL_005f: Expected I4, but got O
			base._002Ector();
			object obj = 0;
			object obj2 = (ProductCatalogPayoutType)obj;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ X8_v5+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string text = default(string);
			t = text;
			st = string.Empty;
			d = string.Empty;
		}
	}
}

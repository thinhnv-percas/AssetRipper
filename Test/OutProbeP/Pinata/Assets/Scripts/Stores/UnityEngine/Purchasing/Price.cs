using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Serializable]
	[Token(Token = "0x2000061")]
	public class Price : ISerializationCallbackReceiver
	{
		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x10")]
		public decimal value;

		[SerializeField]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x20")]
		private int[] data;

		[SerializeField]
		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x28")]
		private double num;

		[Token(Token = "0x600016F")]
		[Address(RVA = "0xC6B0E0", Offset = "0xC6B0E0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1ECA148]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202338C]) = v40;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv59 = System.Decimal::GetBits(this.value);\n\tthis.data = v59;\n\tv64 = System.Decimal::ToDouble(this.value);\n\tthis.num = v64;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeforeSerialize()
		{
			int[] bits = decimal.GetBits(value);
			data = bits;
			double num = decimal.ToDouble(value);
			this.num = num;
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0xC6B174", Offset = "0xC6B174", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.data;\n\tv11 = this.data == 0;\n\tif (v11) goto L_0022;\n\tv22 = v10.Length != 4;\n\tif (v22) goto L_0022;\n\tv30 = 0;\n\tv36 = 0xEA3B9C(&v30 @ stack_-30_v2 (System.Decimal), this.data, 0, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74);\n\tthis.value = 0;\n\tthis.value.lo = 0;\nL_0022:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			int[] array = data;
			if (data != null && array.Length == 4)
			{
				decimal num = default(decimal);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EA3B9C (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0xA8)");
				value = default(decimal);
				value.lo = 0;
			}
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0xC6B1C4", Offset = "0xC6B1C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Price()
		{
		}
	}
}

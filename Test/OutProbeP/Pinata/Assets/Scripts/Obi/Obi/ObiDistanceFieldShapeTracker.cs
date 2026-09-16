using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000021")]
	public class ObiDistanceFieldShapeTracker : ObiShapeTracker
	{
		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x60")]
		public ObiDistanceField distanceField;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x68")]
		internal bool fieldDataHasChanged;

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0xE410C4", Offset = "0xE410C4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.distanceField = distanceField;\n\tthis.adaptor.is2D = 0;\n\tv17 = Oni::CreateShape(6);\n\tthis.oniShape = v17;\n\tthis.fieldDataHasChanged = 1;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiDistanceFieldShapeTracker(ObiDistanceField distanceField)
		{
			this.distanceField = distanceField;
			adaptor.is2D = false;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.SignedDistanceField);
			oniShape = intPtr;
			fieldDataHasChanged = true;
		}

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0xE45988", Offset = "0xE45988", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EEC8A0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202474D]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.distanceField, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv59 = this.distanceField;\n\tv66 = v59.nodes == 0;\n\tif (v66) goto L_FFFFFFFF;\n\tv67 = ~this.fieldDataHasChanged;\n\tif (v67) goto L_FFFFFFFF;\n\tOni::SetShapeDistanceField(this.oniShape, v59.oniDistanceField);\n\tthis.fieldDataHasChanged = 0;\n\tgoto L_003D;\nL_003D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool UpdateIfNeeded()
		{
			if (distanceField != null)
			{
				ObiDistanceField obiDistanceField = distanceField;
				if (obiDistanceField.nodes != null && fieldDataHasChanged)
				{
					Oni.SetShapeDistanceField(OniShape, obiDistanceField.OniDistanceField);
					fieldDataHasChanged = false;
					return true;
				}
			}
			return false;
		}
	}
}

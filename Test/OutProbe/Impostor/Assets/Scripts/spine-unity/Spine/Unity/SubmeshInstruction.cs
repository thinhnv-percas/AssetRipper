using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000B0")]
	public struct SubmeshInstruction
	{
		[Token(Token = "0x400041D")]
		[FieldOffset(Offset = "0x0")]
		public Skeleton skeleton;

		[Token(Token = "0x400041E")]
		[FieldOffset(Offset = "0x8")]
		public int startSlot;

		[Token(Token = "0x400041F")]
		[FieldOffset(Offset = "0xC")]
		public int endSlot;

		[Token(Token = "0x4000420")]
		[FieldOffset(Offset = "0x10")]
		public Material material;

		[Token(Token = "0x4000421")]
		[FieldOffset(Offset = "0x18")]
		public bool forceSeparate;

		[Token(Token = "0x4000422")]
		[FieldOffset(Offset = "0x1C")]
		public int preActiveClippingSlotSource;

		[Token(Token = "0x4000423")]
		[FieldOffset(Offset = "0x20")]
		public int rawTriangleCount;

		[Token(Token = "0x4000424")]
		[FieldOffset(Offset = "0x24")]
		public int rawVertexCount;

		[Token(Token = "0x4000425")]
		[FieldOffset(Offset = "0x28")]
		public int rawFirstVertexIndex;

		[Token(Token = "0x4000426")]
		[FieldOffset(Offset = "0x2C")]
		public bool hasClipping;

		[Token(Token = "0x170001BC")]
		public int SlotCount
		{
			[Token(Token = "0x600069F")]
			[Address(RVA = "0x156FC5C", Offset = "0x156FC5C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.endSlot - this.startSlot;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return endSlot - startSlot;
			}
		}

		[Token(Token = "0x60006A0")]
		[Address(RVA = "0x156FC68", Offset = "0x156FC68", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv24 = System.Int32;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv49 = System.Object[];\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv58 = UnityEngine.Object;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv62 = \"[SubmeshInstruction: slots {0} to {1}. (Material){2}. preActiveClippingSlotSource:{3}]\";\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv134 = \"<none>\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37CE0]) = v44;\nL_0025:\n\t// 37 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 4\n\tv52 = this.startSlot;\n\t// 43 Box v56 @ X0_v5, typeof(System.Int32), &v52 @ X8_v3 (System.Int32)\n\tv65 = v56 == 0;\n\tif (v65) goto L_003A;\n\t// 52 IsInst v138 @ X0_v38, typeof(System.Object), v56 @ X0_v5\n\tv142 = v138 == 0;\n\tif (v142) goto L_00B7;\nL_003A:\n\tv47[0] = v56;\n\tv52 = this.endSlot;\n\tv52 = v52 - 1;\n\t// 64 Box v150 @ X0_v15, typeof(System.Int32), &v52 @ X8_v3 (System.Int32)\n\tv252 = v150 == 0;\n\tif (v252) goto L_0059;\n\t// 71 IsInst v242 @ X0_v36, typeof(System.Object), v150 @ X0_v15\n\tv245 = v242 == 0;\n\tif (v245) goto L_00B7;\nL_0059:\n\tv47[1] = v150;\n\tgoto L_0066;\n\tv264 = \"il2cpp_codegen_runtime_class_init\"(v261, v185, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0066:\n\tv267 = UnityEngine.Object::op_Equality(this.material, 0);\n\tv269 = v267 == 0;\n\tif (v269) goto L_0076;\n\tv273 = \"<none>\" == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_007D;\n\tgoto L_008D;\nL_0076:\n\tv279 = UnityEngine.Object::get_name(this.material);\n\tv281 = v279 == 0;\n\tif (v281) goto L_008D;\nL_007D:\n\t// 125 IsInst v243 @ X0_v31, typeof(System.Object), v236 @ X22_v8 (System.String)\n\tv246 = v243 == 0;\n\tif (v246) goto L_00B7;\nL_008D:\n\tv47[2] = v155;\n\tv52 = this.preActiveClippingSlotSource;\n\t// 146 Box v290 @ X0_v23, typeof(System.Int32), &v52 @ X8_v3 (System.Int32)\n\tv291 = v290 == 0;\n\tif (v291) goto L_00AC;\n\t// 153 IsInst v244 @ X0_v28, typeof(System.Object), v290 @ X0_v23\n\tv247 = v244 == 0;\n\tif (v247) goto L_00B7;\nL_00AC:\n\tv47[3] = v290;\n\treturnVal2 = System.String::Format(\"[SubmeshInstruction: slots {0} to {1}. (Material){2}. preActiveClippingSlotSource:{3}]\", v47);\n\treturn returnVal2;\n\tv204 = new System.IndexOutOfRangeException();\nL_00B7:\n\tv251 = new System.ArrayTypeMismatchException();\n\tthrow v251;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			object[] array = new object[4];
			int num = startSlot;
			object obj = num;
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					goto IL_0255;
				}
			}
			array[0] = obj;
			num = endSlot;
			num--;
			object obj3 = num;
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
				if (obj4 == null)
				{
					goto IL_0255;
				}
			}
			array[1] = obj3;
			string text;
			string text2;
			if (material == null)
			{
				bool flag = "<none>" == null;
				bool flag2 = !flag;
				text = "<none>";
				if (flag2)
				{
					goto IL_018a;
				}
				text2 = "<none>";
			}
			else
			{
				string name = material.name;
				bool flag3 = name == null;
				text = name;
				text2 = name;
				if (!flag3)
				{
					goto IL_018a;
				}
			}
			goto IL_01bc;
			IL_01bc:
			array[2] = text2;
			num = preActiveClippingSlotSource;
			object obj5 = num;
			if (obj5 != null)
			{
				object obj6 = obj5 as object;
				if (obj6 == null)
				{
					goto IL_0255;
				}
			}
			array[3] = obj5;
			return string.Format("[SubmeshInstruction: slots {0} to {1}. (Material){2}. preActiveClippingSlotSource:{3}]", array);
			IL_0255:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
			IL_018a:
			object obj7 = text as object;
			bool flag4 = obj7 == null;
			text2 = text;
			if (!flag4)
			{
				goto IL_01bc;
			}
			goto IL_0255;
		}
	}
}

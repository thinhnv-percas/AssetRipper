using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200001B")]
	public class ObiBoxShapeTracker2D : ObiShapeTracker
	{
		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x60")]
		private Vector2 size;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x68")]
		private Vector2 center;

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0xE3F1A4", Offset = "0xE3F1A4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 1;\n\tv18 = Oni::CreateShape(1);\n\tthis.oniShape = v18;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiBoxShapeTracker2D(BoxCollider2D collider)
		{
			base.collider = collider;
			adaptor.is2D = true;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.Box);
			oniShape = intPtr;
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0xE3F1E8", Offset = "0xE3F1E8", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EB9078]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2024706]) = v48;\nL_0018:\n\tv49 = this.collider;\n\tv50 = this.collider == 0;\n\tif (v50) goto L_FFFFFFFF;\n\tv64 = *([v49 @ X8_v3 (UnityEngine.Component)]) != UnityEngine.BoxCollider2D;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0036;\nL_0036:\n\tgoto L_003F;\n\tv98 = *([v94 @ X0_v2+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tgoto L_003F;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_003F:\n\tv108 = UnityEngine.Object::op_Inequality(v90, 0);\n\tv110 = v108 == 0;\n\tif (v110) goto L_FFFFFFFF;\n\tv153 = UnityEngine.BoxCollider2D::get_size(v90);\n\tgoto L_005F;\n\tv246 = *([v216 @ X0_v12+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_005F;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v216, v152, v107, v33, v34, v35, v36, v37, v153, v210, v40, v41, v42, v43, v44, v45);\nL_005F:\n\t// 95 MakeStruct v120 @ AGGE3F2D4_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.size (UnityEngine.Vector2), this.size.y (System.Single)\n\tv258 = UnityEngine.Vector2::op_Inequality(v153, v120);\n\tv260 = v258 == 0;\n\tv261 = ~v260;\n\tif (v261) goto L_0084;\n\tv263 = UnityEngine.Collider2D::get_offset(v90);\n\tgoto L_007D;\n\tv287 = *([v279 @ X0_v29+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_007D;\n\tv291 = \"il2cpp_codegen_runtime_class_init\"(v279, v143, v107, v33, v34, v35, v36, v37, v263, v278, v255, v256, v42, v43, v44, v45);\nL_007D:\n\t// 125 MakeStruct v114 @ AGGE3F320_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.center (UnityEngine.Vector2), this.center.y (System.Single)\n\tv145 = UnityEngine.Vector2::op_Inequality(v263, v114);\n\tv147 = v145 == 0;\n\tif (v147) goto L_FFFFFFFF;\nL_0084:\n\tv277 = UnityEngine.BoxCollider2D::get_size(v90);\n\tthis.size = v277;\n\tthis.size.y = v277.y;\n\tv286 = UnityEngine.Collider2D::get_offset(v90);\n\tthis.center = v286;\n\tthis.center.y = v286.y;\n\tv200 = this + 0x18;\n\tgoto L_009F;\n\tv302 = *([v297 @ X0_v19+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_009F;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v297, v285, v107, v33, v34, v35, v36, v37, v286, v294, v265, v264, v42, v43, v44, v45);\nL_009F:\n\tv310 = UnityEngine.Vector2::op_Implicit(v286);\n\t// 168 MakeStruct v162 @ AGGE3F390_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.size (UnityEngine.Vector2), this.size.y (System.Single)\n\tv316 = UnityEngine.Vector2::op_Implicit(v162);\n\tv321 = 0x103BB64(v200, 0, 0, v33, v34, v35, v36, v37, v310, v310.y, v310.z, v316, v316.y, v316.z, v44, v45);\n\tOni::UpdateShape(this.oniShape, v200);\n\tgoto L_00C6;\nL_00C6:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			Component component = collider;
			UnityEngine.Object obj;
			if ((object)collider != null)
			{
				Component component2 = (((object)component.GetType() != typeof(BoxCollider2D)) ? null : collider);
				obj = component2;
			}
			else
			{
				obj = null;
			}
			if (obj != null)
			{
				Vector2 vector = ((BoxCollider2D)obj).size;
				Vector2 vector2 = default(Vector2);
				vector2.x = size.x;
				vector2.y = size.y;
				if (!(vector != vector2))
				{
					Vector2 offset = ((Collider2D)obj).offset;
					Vector2 vector3 = default(Vector2);
					vector3.x = center.x;
					vector3.y = center.y;
					if (!(offset != vector3))
					{
						goto IL_0237;
					}
				}
				Vector2 vector4 = (size = ((BoxCollider2D)obj).size);
				size.y = vector4.y;
				Vector2 vector5 = (center = ((Collider2D)obj).offset);
				center.y = vector5.y;
				ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
				Vector3 vector6 = vector5;
				Vector2 vector7 = default(Vector2);
				vector7.x = size.x;
				vector7.y = size.y;
				Vector3 vector8 = vector7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103BB64 (inside Oni::GetProfilingInfo +0xD54)");
				Oni.UpdateShape(OniShape, ref reference);
				return true;
			}
			goto IL_0237;
			IL_0237:
			return false;
		}
	}
}

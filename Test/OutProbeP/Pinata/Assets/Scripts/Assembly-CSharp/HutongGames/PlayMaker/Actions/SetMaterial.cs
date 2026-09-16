using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759118", Offset = "0x759118")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759118", Offset = "0x759118")]
	[Token(Token = "0x2000277")]
	public class SetMaterial : ComponentAction<Renderer>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B764C", Offset = "0x7B764C")]
		[Token(Token = "0x4001682")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x4001683")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[RequiredField]
		[Token(Token = "0x4001684")]
		[FieldOffset(Offset = "0x70")]
		public FsmMaterial material;

		[Token(Token = "0x6000C4A")]
		[Address(RVA = "0x996EC4", Offset = "0x996EC4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.material = 0;\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			material = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
		}

		[Token(Token = "0x6000C4B")]
		[Address(RVA = "0x996EF8", Offset = "0x996EF8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetMaterial::DoSetMaterial(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetMaterial();
			Finish();
		}

		[Token(Token = "0x6000C4C")]
		[Address(RVA = "0x996F20", Offset = "0x996F20", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1ECA6B0]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021776]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetMaterial)+30]), this.gameObject);\n\tv128 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v49);\n\tv167 = v128 == 0;\n\tif (v167) goto L_0093;\n\tv218 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv149 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv287 = v218 == 0;\n\tif (v287) goto L_0098;\n\tv105 = UnityEngine.Renderer::get_materials(v149);\n\tv206 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv57 = v206 >= v105.Length;\n\tif (v57) goto L_0093;\n\tv107 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv150 = UnityEngine.Renderer::get_materials(v107);\n\tv151 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv152 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\n\tv294 = v152 == 0;\n\tif (v294) goto L_006D;\n\t// 105 IsInst v296 @ X0_v38, typeof(UnityEngine.Material), v152 @ X0_v33 (UnityEngine.Material)\nL_006D:\n\tv298 = v151 < v150.Length;\n\tv89 = ~v298;\n\tif (v89) goto L_00AB;\n\tv150[v151 @ X0_v31 (System.Int32)] = v152;\n\tv108 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v108, v150);\n\treturn;\nL_0093:\n\treturn;\nL_0098:\n\tv153 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\n\tUnityEngine.Renderer::set_material(v149, v153);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv165 = new System.NullReferenceException();\nL_00AB:\n\tv191 = new System.IndexOutOfRangeException();\n\tgoto L_00B0;\n\tv282 = new System.ArrayTypeMismatchException();\nL_00B0:\n\tthrow v281;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetMaterial()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetMaterial)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!UpdateCache(ownerDefaultTarget))
			{
				return;
			}
			int value = materialIndex.Value;
			Renderer renderer = base.renderer;
			if (value != 0)
			{
				Material[] materials = renderer.materials;
				int value2 = materialIndex.Value;
				if (value2 < materials.Length)
				{
					Renderer renderer2 = base.renderer;
					Material[] materials2 = renderer2.materials;
					int value3 = materialIndex.Value;
					Material value4 = material.Value;
					if ((object)value4 != null)
					{
						object obj = value4 as Material;
					}
					if (value3 >= materials2.Length)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
						throw ex2;
					}
					materials2[value3] = value4;
					Renderer renderer3 = base.renderer;
					renderer3.materials = materials2;
				}
			}
			else
			{
				Material value5 = material.Value;
				renderer.material = value5;
			}
		}

		[Token(Token = "0x6000C4D")]
		[Address(RVA = "0x997104", Offset = "0x997104", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC2D38]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021777]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetMaterial()
		{
		}
	}
}

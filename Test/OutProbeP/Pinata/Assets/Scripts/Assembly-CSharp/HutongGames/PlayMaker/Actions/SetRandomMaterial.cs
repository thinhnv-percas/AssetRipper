using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759258", Offset = "0x759258")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759258", Offset = "0x759258")]
	[Token(Token = "0x200027B")]
	public class SetRandomMaterial : ComponentAction<Renderer>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B7BAC", Offset = "0x7B7BAC")]
		[Token(Token = "0x4001696")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x4001697")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[Token(Token = "0x4001698")]
		[FieldOffset(Offset = "0x70")]
		public FsmMaterial[] materials;

		[Token(Token = "0x6000C5C")]
		[Address(RVA = "0x998960", Offset = "0x998960", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ECCAA0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202178A]) = v38;\nL_0015:\n\tthis.gameObject = 0;\n\tv41 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v41;\n\t// 28 NewArr v46 @ X0_v5 (HutongGames.PlayMaker.FsmMaterial[]), typeof(HutongGames.PlayMaker.FsmMaterial[]), 3\n\tthis.materials = v46;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
			FsmMaterial[] array = new FsmMaterial[3];
			materials = array;
		}

		[Token(Token = "0x6000C5D")]
		[Address(RVA = "0x9989CC", Offset = "0x9989CC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetRandomMaterial::DoSetRandomMaterial(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetRandomMaterial();
			Finish();
		}

		[Token(Token = "0x6000C5E")]
		[Address(RVA = "0x9989F4", Offset = "0x9989F4", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F08118]);\n\tv25 = *([v24 @ X8_v30]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202178B]) = v44;\nL_0016:\n\tv45 = this.materials;\n\tv46 = this.materials == 0;\n\tif (v46) goto L_00D7;\n\tv48 = v45.Length == 0;\n\tif (v48) goto L_00D7;\n\tv189 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetRandomMaterial)+30]), this.gameObject);\n\tv90 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v189);\n\tv93 = v90 == 0;\n\tif (v93) goto L_00D7;\n\tv228 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv376 = UnityEngine.Renderer::get_material(v228);\n\tgoto L_0045;\n\tv382 = *([v245 @ X8_v15+E0]);\n\tv383 = v382 == 0;\n\tv384 = ~v383;\n\tif (v384) goto L_0045;\n\tv390 = v245;\n\tv386 = \"il2cpp_codegen_runtime_class_init\"(v390, v375, v84, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0045:\n\tv389 = UnityEngine.Object::op_Equality(v376, 0);\n\tv168 = v389 == 0;\n\tif (v168) goto L_005C;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing Material!\");\n\treturn;\nL_005C:\n\tv394 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv275 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv396 = v394 == 0;\n\tif (v396) goto L_00D8;\n\tv230 = UnityEngine.Renderer::get_materials(v275);\n\tv91 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv51 = v91 >= v230.Length;\n\tif (v51) goto L_00D7;\n\tv232 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv276 = UnityEngine.Renderer::get_materials(v232);\n\tv277 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv212 = this.materials;\n\tv311 = UnityEngine.Random::Range(0, v212.Length);\n\tv278 = HutongGames.PlayMaker.FsmMaterial::get_Value(v212[v311 @ X0_v43 (System.Int32)]);\n\tv406 = v278 == 0;\n\tif (v406) goto L_00BD;\n\t// 173 IsInst v372 @ X0_v50, typeof(UnityEngine.Material), v278 @ X0_v45 (UnityEngine.Material)\n\tv373 = v372 == 0;\n\tif (v373) goto L_0107;\nL_00BD:\n\tv276[v277 @ X0_v41 (System.Int32)] = v278;\n\tv165 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v165, v276);\n\treturn;\nL_00D7:\n\treturn;\nL_00D8:\n\tv243 = this.materials;\n\tv313 = UnityEngine.Random::Range(0, v243.Length);\n\tv279 = HutongGames.PlayMaker.FsmMaterial::get_Value(v243[v313 @ X0_v29 (System.Int32)]);\n\tUnityEngine.Renderer::set_material(v275, v279);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv291 = new System.NullReferenceException();\n\tv322 = new System.IndexOutOfRangeException();\nL_0106:\n\tv369 = new System.TypeLoadException();\nL_0107:\n\tv358 = new System.ArrayTypeMismatchException();\n\tgoto L_0106;\n\treturn;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetRandomMaterial()
		{
			//IL_003b: Expected O, but got I
			FsmMaterial[] array = materials;
			if (materials == null || array.Length == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetRandomMaterial)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!UpdateCache(ownerDefaultTarget))
			{
				return;
			}
			Renderer renderer = base.renderer;
			Material material = renderer.material;
			if (material == null)
			{
				LogError("Missing Material!");
				return;
			}
			int value = materialIndex.Value;
			Renderer renderer2 = base.renderer;
			if (value != 0)
			{
				Material[] array2 = renderer2.materials;
				int value2 = materialIndex.Value;
				if (value2 >= array2.Length)
				{
					return;
				}
				Renderer renderer3 = base.renderer;
				Material[] array3 = renderer3.materials;
				int value3 = materialIndex.Value;
				FsmMaterial[] array4 = materials;
				int num = UnityEngine.Random.Range(0, array4.Length);
				Material value4 = array4[num].Value;
				if ((object)value4 != null)
				{
					object obj = value4 as Material;
					if (obj == null)
					{
						while (true)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							TypeLoadException ex2 = new TypeLoadException();
						}
					}
				}
				array3[value3] = value4;
				Renderer renderer4 = base.renderer;
				renderer4.materials = array3;
			}
			else
			{
				FsmMaterial[] array5 = materials;
				int num2 = UnityEngine.Random.Range(0, array5.Length);
				Material value5 = array5[num2].Value;
				renderer2.material = value5;
			}
		}

		[Token(Token = "0x6000C5F")]
		[Address(RVA = "0x998CB0", Offset = "0x998CB0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0D910]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202178C]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetRandomMaterial()
		{
		}
	}
}

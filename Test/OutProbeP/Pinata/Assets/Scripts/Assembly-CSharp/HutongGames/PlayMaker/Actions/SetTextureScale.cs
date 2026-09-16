using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7592F8", Offset = "0x7592F8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7592F8", Offset = "0x7592F8")]
	[Token(Token = "0x200027D")]
	public class SetTextureScale : ComponentAction<Renderer>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B7CF0", Offset = "0x7B7CF0")]
		[Token(Token = "0x400169F")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40016A0")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B7D64", Offset = "0x7B7D64")]
		[Token(Token = "0x40016A1")]
		[FieldOffset(Offset = "0x70")]
		public FsmString namedTexture;

		[RequiredField]
		[Token(Token = "0x40016A2")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat scaleX;

		[RequiredField]
		[Token(Token = "0x40016A3")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat scaleY;

		[Token(Token = "0x40016A4")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x6000C65")]
		[Address(RVA = "0x99A774", Offset = "0x99A774", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1ECCFD8]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202179C]) = v40;\nL_0016:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v43;\n\tv48 = HutongGames.PlayMaker.FsmString::op_Implicit(\"_MainTex\");\n\tthis.namedTexture = v48;\n\tv52 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.scaleX = v52;\n\tv55 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.scaleY = v55;\n\tthis.everyFrame = 0;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
			FsmString fsmString = "_MainTex";
			namedTexture = fsmString;
			FsmFloat fsmFloat = 1f;
			scaleX = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			scaleY = fsmFloat2;
			everyFrame = false;
		}

		[Token(Token = "0x6000C66")]
		[Address(RVA = "0x99A810", Offset = "0x99A810", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetTextureScale::DoSetTextureScale(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetTextureScale();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C67")]
		[Address(RVA = "0x99AB2C", Offset = "0x99AB2C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetTextureScale::DoSetTextureScale(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetTextureScale();
		}

		[Token(Token = "0x6000C68")]
		[Address(RVA = "0x99A84C", Offset = "0x99A84C", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EFD440]);\n\tv27 = *([v26 @ X8_v23]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202179D]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetTextureScale)+30]), this.gameObject);\n\tv165 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v51);\n\tv224 = v165 == 0;\n\tif (v224) goto L_00EE;\n\tv130 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv345 = UnityEngine.Renderer::get_material(v130);\n\tgoto L_0040;\n\tv351 = *([v151 @ X8_v11+E0]);\n\tv352 = v351 == 0;\n\tv353 = ~v352;\n\tif (v353) goto L_0040;\n\tv359 = v151;\n\tv355 = \"il2cpp_codegen_runtime_class_init\"(v359, v344, v117, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0040:\n\tv358 = UnityEngine.Object::op_Equality(v345, 0);\n\tv335 = v358 == 0;\n\tif (v335) goto L_0058;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing Material!\");\n\treturn;\nL_0058:\n\tv363 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv132 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv365 = v363 == 0;\n\tif (v365) goto L_00C1;\n\tv133 = UnityEngine.Renderer::get_materials(v132);\n\tv287 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv69 = v287 >= v133.Length;\n\tif (v69) goto L_00EE;\n\tv135 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv200 = UnityEngine.Renderer::get_materials(v135);\n\tv201 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv375 = v201 < v200.Length;\n\tv101 = ~v375;\n\tif (v101) goto L_00F2;\n\tv202 = HutongGames.PlayMaker.FsmString::get_Value(this.namedTexture);\n\tv61 = HutongGames.PlayMaker.FsmFloat::get_Value(this.scaleX);\n\tv379 = HutongGames.PlayMaker.FsmFloat::get_Value(this.scaleY);\n\tv168 = 0;\n\tv203 = 0x1588A6C(&v168 @ stack_-48_v5, 0, 0, v31, v32, v33, v34, v35, v61, v379, v38, v39, v40, v41, v42, v43);\n\t// 181 MakeStruct v54 @ AGG99AA54_2_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v374 @ stack_-44\n\tUnityEngine.Material::SetTextureScale(v200[v201 @ X0_v40 (System.Int32)], v202, v54);\n\tv137 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v137, v200);\n\tgoto L_00EE;\nL_00C1:\n\tv204 = UnityEngine.Renderer::get_material(v132);\n\tv205 = HutongGames.PlayMaker.FsmString::get_Value(this.namedTexture);\n\tv63 = HutongGames.PlayMaker.FsmFloat::get_Value(this.scaleX);\n\tv371 = HutongGames.PlayMaker.FsmFloat::get_Value(this.scaleY);\n\tv168 = 0;\n\tv206 = 0x1588A6C(&v168 @ stack_-48_v5, 0, 0, v31, v32, v33, v34, v35, v63, v371, v38, v39, v40, v41, v42, v43);\n\t// 227 MakeStruct v255 @ AGG99AAF0_2_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v374 @ stack_-44\n\tUnityEngine.Material::SetTextureScale(v204, v205, v255);\nL_00EE:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv222 = new System.NullReferenceException();\nL_00F2:\n\tv251 = new System.IndexOutOfRangeException();\n\tthrow v251;\n\treturn;\n// 185 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetTextureScale()
		{
			//IL_001c: Expected O, but got I
			//IL_027f: Expected O, but got I4
			//IL_02ae: Expected F4, but got O
			//IL_01c3: Expected O, but got I4
			//IL_01f2: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetTextureScale)+30]");
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
			object obj2 = default(object);
			if (value != 0)
			{
				Material[] materials = renderer2.materials;
				int value2 = materialIndex.Value;
				if (value2 < materials.Length)
				{
					Renderer renderer3 = base.renderer;
					Material[] materials2 = renderer3.materials;
					int value3 = materialIndex.Value;
					if (value3 >= materials2.Length)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					string value4 = namedTexture.Value;
					float value5 = scaleX.Value;
					float value6 = scaleY.Value;
					object obj = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					Vector2 value7 = default(Vector2);
					value7.x = 0f;
					value7.y = (float)obj2;
					materials2[value3].SetTextureScale(value4, value7);
					Renderer renderer4 = base.renderer;
					renderer4.materials = materials2;
				}
			}
			else
			{
				Material material2 = renderer2.material;
				string value8 = namedTexture.Value;
				float value9 = scaleX.Value;
				float value10 = scaleY.Value;
				object obj = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Vector2 value11 = default(Vector2);
				value11.x = 0f;
				value11.y = (float)obj2;
				material2.SetTextureScale(value8, value11);
			}
		}

		[Token(Token = "0x6000C69")]
		[Address(RVA = "0x99AB30", Offset = "0x99AB30", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB2A70]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202179E]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetTextureScale()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758304", Offset = "0x758304")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758304", Offset = "0x758304")]
	[Token(Token = "0x200024E")]
	public class SetLightColor : ComponentAction<Light>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B4BC4", Offset = "0x7B4BC4")]
		[Token(Token = "0x40015C8")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x40015C9")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor lightColor;

		[Token(Token = "0x40015CA")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000B85")]
		[Address(RVA = "0x99606C", Offset = "0x99606C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv11 = UnityEngine.Color::get_white();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.lightColor = v17;\n\tthis.everyFrame = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			Color white = Color.white;
			FsmColor fsmColor = white;
			lightColor = fsmColor;
			everyFrame = false;
		}

		[Token(Token = "0x6000B86")]
		[Address(RVA = "0x9960A4", Offset = "0x9960A4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightColor::DoSetLightColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetLightColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B87")]
		[Address(RVA = "0x996194", Offset = "0x996194", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightColor::DoSetLightColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetLightColor();
		}

		[Token(Token = "0x6000B88")]
		[Address(RVA = "0x9960E0", Offset = "0x9960E0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC7478]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021762]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetLightColor)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::UpdateCache(this, v43);\n\tv69 = v59 == 0;\n\tif (v69) goto L_003E;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::get_light(this);\n\tv53 = this.lightColor;\n\t// 54 MakeStruct v78 @ AGG996178_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v53.value (UnityEngine.Color), v53.value.g (System.Single), v53.value.b (System.Single), v53.value.a (System.Single)\n\tUnityEngine.Light::set_color(v49, v78);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLightColor()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetLightColor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Light light = base.light;
				FsmColor fsmColor = lightColor;
				Color color = default(Color);
				color.r = fsmColor.value.r;
				color.g = fsmColor.value.g;
				color.b = fsmColor.value.b;
				color.a = fsmColor.value.a;
				light.color = color;
			}
		}

		[Token(Token = "0x6000B89")]
		[Address(RVA = "0x996198", Offset = "0x996198", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED4998]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021763]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetLightColor()
		{
		}
	}
}

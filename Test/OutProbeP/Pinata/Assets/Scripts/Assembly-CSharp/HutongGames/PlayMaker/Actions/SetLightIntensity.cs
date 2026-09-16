using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7583F4", Offset = "0x7583F4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7583F4", Offset = "0x7583F4")]
	[Token(Token = "0x2000251")]
	public class SetLightIntensity : ComponentAction<Light>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B4D30", Offset = "0x7B4D30")]
		[Token(Token = "0x40015CF")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40015D0")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat lightIntensity;

		[Token(Token = "0x40015D1")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000B92")]
		[Address(RVA = "0x99644C", Offset = "0x99644C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.lightIntensity = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 1f;
			lightIntensity = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000B93")]
		[Address(RVA = "0x996480", Offset = "0x996480", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightIntensity::DoSetLightIntensity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetLightIntensity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B94")]
		[Address(RVA = "0x99657C", Offset = "0x99657C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightIntensity::DoSetLightIntensity(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetLightIntensity();
		}

		[Token(Token = "0x6000B95")]
		[Address(RVA = "0x9964BC", Offset = "0x9964BC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA9178]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021768]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetLightIntensity)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::UpdateCache(this, v43);\n\tv70 = v50 == 0;\n\tif (v70) goto L_003E;\n\tv58 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::get_light(this);\n\tv52 = HutongGames.PlayMaker.FsmFloat::get_Value(this.lightIntensity);\n\tUnityEngine.Light::set_intensity(v58, v52);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLightIntensity()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetLightIntensity)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Light light = base.light;
				float value = lightIntensity.Value;
				light.intensity = value;
			}
		}

		[Token(Token = "0x6000B96")]
		[Address(RVA = "0x996580", Offset = "0x996580", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC7DA0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021769]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetLightIntensity()
		{
		}
	}
}

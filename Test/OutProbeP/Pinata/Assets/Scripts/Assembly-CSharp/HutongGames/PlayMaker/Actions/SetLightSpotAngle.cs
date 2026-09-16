using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758494", Offset = "0x758494")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758494", Offset = "0x758494")]
	[Token(Token = "0x2000253")]
	public class SetLightSpotAngle : ComponentAction<Light>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B4E18", Offset = "0x7B4E18")]
		[Token(Token = "0x40015D5")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40015D6")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat lightSpotAngle;

		[Token(Token = "0x40015D7")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000B9C")]
		[Address(RVA = "0x996754", Offset = "0x996754", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(20f);\n\tthis.lightSpotAngle = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 20f;
			lightSpotAngle = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000B9D")]
		[Address(RVA = "0x996788", Offset = "0x996788", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightSpotAngle::DoSetLightRange(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetLightRange();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B9E")]
		[Address(RVA = "0x996884", Offset = "0x996884", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightSpotAngle::DoSetLightRange(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetLightRange();
		}

		[Token(Token = "0x6000B9F")]
		[Address(RVA = "0x9967C4", Offset = "0x9967C4", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDC8B0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202176C]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetLightSpotAngle)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::UpdateCache(this, v43);\n\tv70 = v50 == 0;\n\tif (v70) goto L_003E;\n\tv58 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::get_light(this);\n\tv52 = HutongGames.PlayMaker.FsmFloat::get_Value(this.lightSpotAngle);\n\tUnityEngine.Light::set_spotAngle(v58, v52);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLightRange()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetLightSpotAngle)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Light light = base.light;
				float value = lightSpotAngle.Value;
				light.spotAngle = value;
			}
		}

		[Token(Token = "0x6000BA0")]
		[Address(RVA = "0x996888", Offset = "0x996888", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EEE090]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202176D]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetLightSpotAngle()
		{
		}
	}
}

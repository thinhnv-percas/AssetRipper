using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7583A4", Offset = "0x7583A4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7583A4", Offset = "0x7583A4")]
	[Token(Token = "0x2000250")]
	public class SetLightFlare : ComponentAction<Light>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B4CBC", Offset = "0x7B4CBC")]
		[Token(Token = "0x40015CD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40015CE")]
		[FieldOffset(Offset = "0x68")]
		public Flare lightFlare;

		[Token(Token = "0x6000B8E")]
		[Address(RVA = "0x99632C", Offset = "0x99632C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.lightFlare = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			lightFlare = null;
		}

		[Token(Token = "0x6000B8F")]
		[Address(RVA = "0x996334", Offset = "0x996334", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightFlare::DoSetLightRange(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetLightRange();
			Finish();
		}

		[Token(Token = "0x6000B90")]
		[Address(RVA = "0x99635C", Offset = "0x99635C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF7CE8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021766]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetLightFlare)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::UpdateCache(this, v43);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0037;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::get_light(this);\n\tUnityEngine.Light::set_flare(v49, this.lightFlare);\n\treturn;\nL_0037:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLightRange()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetLightFlare)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Light light = base.light;
				light.flare = lightFlare;
			}
		}

		[Token(Token = "0x6000B91")]
		[Address(RVA = "0x9963FC", Offset = "0x9963FC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDA220]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021767]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetLightFlare()
		{
		}
	}
}

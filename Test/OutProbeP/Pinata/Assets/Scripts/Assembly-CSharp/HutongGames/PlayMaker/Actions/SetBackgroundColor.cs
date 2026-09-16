using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75480C", Offset = "0x75480C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75480C", Offset = "0x75480C")]
	[Token(Token = "0x2000196")]
	public class SetBackgroundColor : ComponentAction<Camera>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7ABCEC", Offset = "0x7ABCEC")]
		[Token(Token = "0x40012DD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x40012DE")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor backgroundColor;

		[Token(Token = "0x40012DF")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60008AB")]
		[Address(RVA = "0xB2C37C", Offset = "0xB2C37C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv11 = UnityEngine.Color::get_black();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.backgroundColor = v17;\n\tthis.everyFrame = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			Color black = Color.black;
			FsmColor fsmColor = black;
			backgroundColor = fsmColor;
			everyFrame = false;
		}

		[Token(Token = "0x60008AC")]
		[Address(RVA = "0xB2C3B4", Offset = "0xB2C3B4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetBackgroundColor::DoSetBackgroundColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetBackgroundColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008AD")]
		[Address(RVA = "0xB2C4A4", Offset = "0xB2C4A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetBackgroundColor::DoSetBackgroundColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetBackgroundColor();
		}

		[Token(Token = "0x60008AE")]
		[Address(RVA = "0xB2C3F0", Offset = "0xB2C3F0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB5678]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022622]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetBackgroundColor)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::UpdateCache(this, v43);\n\tv69 = v59 == 0;\n\tif (v69) goto L_003E;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::get_camera(this);\n\tv53 = this.backgroundColor;\n\t// 54 MakeStruct v78 @ AGGB2C488_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v53.value (UnityEngine.Color), v53.value.g (System.Single), v53.value.b (System.Single), v53.value.a (System.Single)\n\tUnityEngine.Camera::set_backgroundColor(v49, v78);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetBackgroundColor()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetBackgroundColor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Camera camera = base.camera;
				FsmColor fsmColor = backgroundColor;
				Color color = default(Color);
				color.r = fsmColor.value.r;
				color.g = fsmColor.value.g;
				color.b = fsmColor.value.b;
				color.a = fsmColor.value.a;
				camera.backgroundColor = color;
			}
		}

		[Token(Token = "0x60008AF")]
		[Address(RVA = "0xB2C4A8", Offset = "0xB2C4A8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB80B8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022623]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetBackgroundColor()
		{
		}
	}
}

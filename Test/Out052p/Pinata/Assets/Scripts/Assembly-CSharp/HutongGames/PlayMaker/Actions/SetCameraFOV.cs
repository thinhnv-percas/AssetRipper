using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7548AC", Offset = "0x7548AC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7548AC", Offset = "0x7548AC")]
	[Token(Token = "0x2000198")]
	public class SetCameraFOV : ComponentAction<Camera>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7ABE6C", Offset = "0x7ABE6C")]
		[Token(Token = "0x40012E4")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x40012E5")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat fieldOfView;

		[Token(Token = "0x40012E6")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x60008B5")]
		[Address(RVA = "0xB2C790", Offset = "0xB2C790", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(50f);\n\tthis.fieldOfView = v13;\n\tthis.everyFrame = 0;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 50f;
			fieldOfView = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x60008B6")]
		[Address(RVA = "0xB2C7C8", Offset = "0xB2C7C8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetCameraFOV::DoSetCameraFOV(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetCameraFOV();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008B7")]
		[Address(RVA = "0xB2C8C4", Offset = "0xB2C8C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetCameraFOV::DoSetCameraFOV(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetCameraFOV();
		}

		[Token(Token = "0x60008B8")]
		[Address(RVA = "0xB2C804", Offset = "0xB2C804", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAE828]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022627]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetCameraFOV)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::UpdateCache(this, v43);\n\tv70 = v50 == 0;\n\tif (v70) goto L_003E;\n\tv58 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::get_camera(this);\n\tv52 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fieldOfView);\n\tUnityEngine.Camera::set_fieldOfView(v58, v52);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetCameraFOV()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetCameraFOV)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Camera camera = base.camera;
				float value = fieldOfView.Value;
				camera.fieldOfView = value;
			}
		}

		[Token(Token = "0x60008B9")]
		[Address(RVA = "0xB2C8C8", Offset = "0xB2C8C8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB4C60]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022628]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetCameraFOV()
		{
		}
	}
}

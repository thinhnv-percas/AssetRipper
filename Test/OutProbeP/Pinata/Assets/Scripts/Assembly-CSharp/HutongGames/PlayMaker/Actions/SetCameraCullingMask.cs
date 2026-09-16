using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75485C", Offset = "0x75485C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75485C", Offset = "0x75485C")]
	[Token(Token = "0x2000197")]
	public class SetCameraCullingMask : ComponentAction<Camera>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7ABD70", Offset = "0x7ABD70")]
		[Token(Token = "0x40012E0")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABDE4", Offset = "0x7ABDE4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABDE4", Offset = "0x7ABDE4")]
		[Token(Token = "0x40012E1")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt[] cullingMask;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABE34", Offset = "0x7ABE34")]
		[Token(Token = "0x40012E2")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool invertMask;

		[Token(Token = "0x40012E3")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x60008B0")]
		[Address(RVA = "0xB2C5B8", Offset = "0xB2C5B8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF0650]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022624]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\t// 24 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.cullingMask = v43;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v46;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt[] array = new FsmInt[0];
			cullingMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x60008B1")]
		[Address(RVA = "0xB2C628", Offset = "0xB2C628", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetCameraCullingMask::DoSetCameraCullingMask(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetCameraCullingMask();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008B2")]
		[Address(RVA = "0xB2C73C", Offset = "0xB2C73C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetCameraCullingMask::DoSetCameraCullingMask(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetCameraCullingMask();
		}

		[Token(Token = "0x60008B3")]
		[Address(RVA = "0xB2C664", Offset = "0xB2C664", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC29A8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022625]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetCameraCullingMask)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::UpdateCache(this, v43);\n\tv71 = v50 == 0;\n\tif (v71) goto L_0044;\n\tv57 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::get_camera(this);\n\tv96 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv58 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.cullingMask, v96);\n\tUnityEngine.Camera::set_cullingMask(v57, v58);\n\treturn;\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetCameraCullingMask()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetCameraCullingMask)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Camera camera = base.camera;
				bool value = invertMask.Value;
				int num = ActionHelpers.LayerArrayToLayerMask(cullingMask, value);
				camera.cullingMask = num;
			}
		}

		[Token(Token = "0x60008B4")]
		[Address(RVA = "0xB2C740", Offset = "0xB2C740", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F032A0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022626]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Camera>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetCameraCullingMask()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759348", Offset = "0x759348")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759348", Offset = "0x759348")]
	[Token(Token = "0x200027E")]
	public class SetVisibility : ComponentAction<Renderer>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B7D98", Offset = "0x7B7D98")]
		[Token(Token = "0x40016A5")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7E0C", Offset = "0x7B7E0C")]
		[Token(Token = "0x40016A6")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool toggle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7E44", Offset = "0x7B7E44")]
		[Token(Token = "0x40016A7")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool visible;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7E7C", Offset = "0x7B7E7C")]
		[Token(Token = "0x40016A8")]
		[FieldOffset(Offset = "0x78")]
		public bool resetOnExit;

		[Token(Token = "0x40016A9")]
		[FieldOffset(Offset = "0x79")]
		private bool initialVisibility;

		[Token(Token = "0x6000C6A")]
		[Address(RVA = "0x99B754", Offset = "0x99B754", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.toggle = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.visible = v15;\n\tthis.resetOnExit = 1;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			toggle = fsmBool;
			FsmBool fsmBool2 = false;
			visible = fsmBool2;
			resetOnExit = true;
			initialVisibility = false;
		}

		[Token(Token = "0x6000C6B")]
		[Address(RVA = "0x99B79C", Offset = "0x99B79C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetVisibility)+30]), this.gameObject);\n\tHutongGames.PlayMaker.Actions.SetVisibility::DoSetVisibility(this, v14);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0017: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetVisibility)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			DoSetVisibility(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x6000C6C")]
		[Address(RVA = "0x99B7E4", Offset = "0x99B7E4", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EB8B40]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, go, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20217A7]) = v43;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, go);\n\tv51 = v49 == 0;\n\tif (v51) goto L_004C;\n\tv56 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv97 = UnityEngine.Renderer::get_enabled(v56);\n\tthis.initialVisibility = v97;\n\tv126 = HutongGames.PlayMaker.FsmBool::get_Value(this.toggle);\n\tv128 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv130 = v126 == 0;\n\tif (v130) goto L_0051;\n\tv103 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv119 = UnityEngine.Renderer::get_enabled(v103);\n\tv133 = ~v119;\n\tgoto L_005E;\nL_004C:\n\treturn;\nL_0051:\n\tv120 = HutongGames.PlayMaker.FsmBool::get_Value(this.visible);\nL_005E:\n\tUnityEngine.Renderer::set_enabled(v128, v73);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetVisibility(GameObject go)
		{
			if (UpdateCache(go))
			{
				Renderer renderer = base.renderer;
				bool flag = renderer.enabled;
				initialVisibility = flag;
				bool value = toggle.Value;
				Renderer renderer2 = base.renderer;
				bool flag4;
				if (value)
				{
					Renderer renderer3 = base.renderer;
					bool flag2 = renderer3.enabled;
					bool flag3 = !flag2;
					flag4 = flag3;
				}
				else
				{
					bool value2 = visible.Value;
					flag4 = value2;
				}
				renderer2.enabled = flag4;
			}
		}

		[Token(Token = "0x6000C6D")]
		[Address(RVA = "0x99B904", Offset = "0x99B904", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.resetOnExit;\n\tif (v2) goto L_0005;\n\tHutongGames.PlayMaker.Actions.SetVisibility::ResetVisibility(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (resetOnExit)
			{
				Reset();
			}
		}

		[Token(Token = "0x6000C6E")]
		[Address(RVA = "0x99B914", Offset = "0x99B914", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EB8B90]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217A8]) = v40;\nL_0018:\n\tv45 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tgoto L_002A;\n\tv53 = *([v49 @ X8_v5+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002A;\n\tv64 = v49;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v64, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv63 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv66 = v63 == 0;\n\tif (v66) goto L_0043;\n\tv69 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_enabled(v69, this.initialVisibility);\n\treturn;\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetVisibility()
		{
			Renderer renderer = base.renderer;
			if (renderer != null)
			{
				Renderer renderer2 = base.renderer;
				renderer2.enabled = initialVisibility;
			}
		}

		[Token(Token = "0x6000C6F")]
		[Address(RVA = "0x99B9D8", Offset = "0x99B9D8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ECA0F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217A9]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetVisibility()
		{
		}
	}
}

using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75ABBC", Offset = "0x75ABBC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75ABBC", Offset = "0x75ABBC")]
	[Token(Token = "0x20002CC")]
	public class MousePick2dEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BEAA4", Offset = "0x7BEAA4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEAA4", Offset = "0x7BEAA4")]
		[Token(Token = "0x400185E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault GameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEB2C", Offset = "0x7BEB2C")]
		[Token(Token = "0x400185F")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent mouseOver;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEB64", Offset = "0x7BEB64")]
		[Token(Token = "0x4001860")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent mouseDown;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEB9C", Offset = "0x7BEB9C")]
		[Token(Token = "0x4001861")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent mouseUp;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEBD4", Offset = "0x7BEBD4")]
		[Token(Token = "0x4001862")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent mouseOff;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEC0C", Offset = "0x7BEC0C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BEC0C", Offset = "0x7BEC0C")]
		[Token(Token = "0x4001863")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEC5C", Offset = "0x7BEC5C")]
		[Token(Token = "0x4001864")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BEC94", Offset = "0x7BEC94")]
		[Token(Token = "0x4001865")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x6000E01")]
		[Address(RVA = "0xA3D144", Offset = "0xA3D144", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EECEC0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E5F]) = v38;\nL_0014:\n\tthis.mouseOff = 0;\n\tthis.GameObject = 0;\n\tthis.mouseDown = 0;\n\t// 27 NewArr v44 @ X0_v3 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v44;\n\tv47 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v47;\n\tthis.everyFrame = 1;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			mouseOff = null;
			GameObject = null;
			mouseDown = null;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			everyFrame = true;
		}

		[Token(Token = "0x6000E02")]
		[Address(RVA = "0xA3D1C0", Offset = "0xA3D1C0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePick2dEvent::DoMousePickEvent(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoMousePickEvent();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E03")]
		[Address(RVA = "0xA3D2B0", Offset = "0xA3D2B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePick2dEvent::DoMousePickEvent(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMousePickEvent();
		}

		[Token(Token = "0x6000E04")]
		[Address(RVA = "0xA3D1FC", Offset = "0xA3D1FC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.Actions.MousePick2dEvent::DoRaycast(this);\n\tv13 = v10 == 0;\n\tif (v13) goto L_002F;\n\tv15 = this.mouseDown == 0;\n\tif (v15) goto L_001A;\n\tv20 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv28 = v20 == 0;\n\tif (v28) goto L_001A;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.mouseDown);\nL_001A:\n\tv32 = this.mouseOver == 0;\n\tif (v32) goto L_0022;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.mouseOver);\nL_0022:\n\tv43 = this.mouseUp == 0;\n\tif (v43) goto L_0040;\n\tv47 = UnityEngine.Input::GetMouseButtonUp(0);\n\tv44 = v47 == 0;\n\tif (v44) goto L_0040;\n\tv62 = this.fsm;\n\tv57 = this.mouseUp;\n\tgoto L_003A;\nL_002F:\n\tv57 = this.mouseOff;\n\tv17 = this.mouseOff == 0;\n\tif (v17) goto L_0040;\n\tv62 = this.fsm;\nL_003A:\n\tHutongGames.PlayMaker.Fsm::Event(v62, v57);\n\treturn;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMousePickEvent()
		{
			Fsm fsm;
			FsmEvent fsmEvent;
			if (DoRaycast())
			{
				if (mouseDown != null && Input.GetMouseButtonDown(0))
				{
					Fsm.Event(mouseDown);
				}
				if (mouseOver != null)
				{
					Fsm.Event(mouseOver);
				}
				if (mouseUp == null || !Input.GetMouseButtonUp(0))
				{
					return;
				}
				fsm = Fsm;
				fsmEvent = mouseUp;
			}
			else
			{
				fsmEvent = mouseOff;
				if (mouseOff == null)
				{
					return;
				}
				fsm = Fsm;
			}
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000E05")]
		[Address(RVA = "0xA3D2B4", Offset = "0xA3D2B4", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tgoto L_0016;\n\tv22 = *([1F04D80]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E60]) = v42;\nL_0016:\n\t*([v12 @ X29_v1-30]) = 0;\n\t*([v12 @ X29_v1-50]) = 0;\n\t*([v12 @ X29_v1-40]) = 0;\n\tv44 = this.GameObject;\n\tv47 = v44.ownerOption == 0;\n\tif (v47) goto L_0026;\n\tv152 = HutongGames.PlayMaker.FsmGameObject::get_Value(v44.gameObject);\n\tgoto L_0028;\nL_0026:\n\tv65 = this.owner;\nL_0028:\n\tv157 = UnityEngine.Camera::get_main();\n\tv53 = UnityEngine.Input::get_mousePosition();\n\tv204 = UnityEngine.Camera::ScreenPointToRay(v157, v53);\n\tv207 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv211 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v207);\n\tgoto L_004E;\n\tv219 = *([v215 @ X8_v8+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_004E;\n\tv235 = v215;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v235, v208, v210, v27, v28, v29, v30, v31, v53, v51, v49, v35, v36, v37, v38, v39);\nL_004E:\n\tv53 = *([v12 @ X29_v1-68]);\n\tv234 = UnityEngine.Physics2D::GetRayIntersection(&v53 @ V0_v4 (UnityEngine.Vector3), Infinityf, v211);\n\tv114 = v234.m_Centroid;\n\t*([v12 @ X29_v1-30]) = v234.m_Collider;\n\t*([v12 @ X29_v1-50]) = v234.m_Centroid;\n\t*([v12 @ X29_v1-40]) = v234.m_Normal;\n\tgoto L_0083;\n\tv249 = *([v245 @ X0_v19+E0]);\n\tv250 = v249 == 0;\n\tv251 = ~v250;\n\tif (v251) goto L_0083;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v245, v229, v233, v27, v28, v29, v30, v31, v242, v241, v49, v35, v36, v37, v38, v39);\nL_0083:\n\tHutongGames.PlayMaker.Fsm::RecordLastRaycastHit2DInfo(this.fsm, &v114 @ stack_-A0_v2 (UnityEngine.Vector2));\n\tv262 = new System.NullReferenceException();\n\tgoto L_0098;\n\tv267 = *([v148 @ X8_v18+E0]);\n\tv268 = v267 == 0;\n\tv269 = ~v268;\n\tif (v269) goto L_0098;\n\tv276 = v148;\n\tv271 = \"il2cpp_codegen_runtime_class_init\"(v276, v261, v259, v27, v28, v29, v30, v31, v130, v128, v49, v35, v36, v37, v38, v39);\nL_0098:\n\tv275 = UnityEngine.Object::op_Inequality(v262, 0);\n\tv278 = v275 == 0;\n\tif (v278) goto L_FFFFFFFF;\n\tv140 = new System.NullReferenceException();\n\tv298 = UnityEngine.Component::get_gameObject(v140);\n\tgoto L_00B2;\n\tv302 = *([v293 @ X8_v21+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_00B2;\n\tv309 = v293;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v309, v297, v122, v27, v28, v29, v30, v31, v130, v128, v49, v35, v36, v37, v38, v39);\nL_00B2:\n\tv287 = UnityEngine.Object::op_Equality(v298, v65);\n\tv289 = v287 == 0;\n\tif (v289) goto L_FFFFFFFF;\n\tgoto L_00C0;\nL_00C0:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool DoRaycast()
		{
			//IL_00af: Expected O, but got I
			//IL_00c1: Expected O, but got Ref
			//IL_0104: Expected O, but got Ref
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			FsmOwnerDefault gameObject = GameObject;
			GameObject gameObject2;
			if (gameObject.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = gameObject.GameObject.Value;
				gameObject2 = value;
			}
			else
			{
				gameObject2 = Owner;
			}
			Camera main = Camera.main;
			Vector3 pos = Input.mousePosition;
			Ray ray = main.ScreenPointToRay(pos);
			bool value2 = invertMask.Value;
			int num = ActionHelpers.LayerArrayToLayerMask(layerMask, value2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-68]");
			pos = (Vector3)0;
			RaycastHit2D rayIntersection = Physics2D.GetRayIntersection((Ray)(&pos), float.PositiveInfinity, num);
			Vector2 centroid = rayIntersection.m_Centroid;
			_ = rayIntersection.m_Collider;
			_ = rayIntersection.m_Centroid;
			_ = rayIntersection.m_Normal;
			Fsm.RecordLastRaycastHit2DInfo(Fsm, (RaycastHit2D)(&centroid));
			NullReferenceException ex = new NullReferenceException();
			if ((UnityEngine.Object)(object)ex != null)
			{
				NullReferenceException ex2 = new NullReferenceException();
				GameObject gameObject3 = ((Component)(object)ex2).gameObject;
				if (gameObject3 == gameObject2)
				{
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x6000E06")]
		[Address(RVA = "0xA3D4E8", Offset = "0xA3D4E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MousePick2dEvent()
		{
		}
	}
}

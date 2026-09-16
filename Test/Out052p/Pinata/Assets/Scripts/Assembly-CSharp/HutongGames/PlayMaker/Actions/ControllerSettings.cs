using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754A3C", Offset = "0x754A3C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754A3C", Offset = "0x754A3C")]
	[Token(Token = "0x200019D")]
	public class ControllerSettings : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AC4C4", Offset = "0x7AC4C4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC4C4", Offset = "0x7AC4C4")]
		[Token(Token = "0x40012FE")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC55C", Offset = "0x7AC55C")]
		[Token(Token = "0x40012FF")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat height;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC594", Offset = "0x7AC594")]
		[Token(Token = "0x4001300")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat radius;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC5CC", Offset = "0x7AC5CC")]
		[Token(Token = "0x4001301")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat slopeLimit;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC604", Offset = "0x7AC604")]
		[Token(Token = "0x4001302")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat stepOffset;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC63C", Offset = "0x7AC63C")]
		[Token(Token = "0x4001303")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector3 center;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC674", Offset = "0x7AC674")]
		[Token(Token = "0x4001304")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool detectCollisions;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC6AC", Offset = "0x7AC6AC")]
		[Token(Token = "0x4001305")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x4001306")]
		[FieldOffset(Offset = "0x90")]
		private GameObject previousGo;

		[Token(Token = "0x4001307")]
		[FieldOffset(Offset = "0x98")]
		private CharacterController controller;

		[Token(Token = "0x60008CA")]
		[Address(RVA = "0xA91934", Offset = "0xA91934", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F02468]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20221FC]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.height = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.radius = v52;\n\tv64 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v64);\n\tv64.useVariable = 1;\n\tthis.slopeLimit = v64;\n\tv65 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v65);\n\tv65.useVariable = 1;\n\tthis.stepOffset = v65;\n\tv66 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v66);\n\tv66.useVariable = 1;\n\tthis.center = v66;\n\tv67 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v67);\n\tv67.useVariable = 1;\n\tthis.detectCollisions = v67;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			height = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			radius = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			slopeLimit = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			stepOffset = fsmFloat4;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			center = fsmVector;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = true;
			detectCollisions = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x60008CB")]
		[Address(RVA = "0xA91A70", Offset = "0xA91A70", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ControllerSettings::DoControllerSettings(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoControllerSettings();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008CC")]
		[Address(RVA = "0xA91D34", Offset = "0xA91D34", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ControllerSettings::DoControllerSettings(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoControllerSettings();
		}

		[Token(Token = "0x60008CD")]
		[Address(RVA = "0xA91AAC", Offset = "0xA91AAC", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE9DA8]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20221FD]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv172 = *([v120 @ X8_v5+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_002C;\n\tv182 = v120;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v182, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv181 = UnityEngine.Object::op_Equality(v47, 0);\n\tv184 = v181 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_00D6;\n\tgoto L_003F;\n\tv236 = *([v226 @ X0_v13+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_003F;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v226, v179, v180, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv150 = UnityEngine.Object::op_Inequality(v47, this.previousGo);\n\tv244 = v150 == 0;\n\tif (v244) goto L_004E;\n\tv250 = UnityEngine.GameObject::GetComponent(v47);\n\tthis.previousGo = v47;\n\tthis.controller = v250;\n\tgoto L_0053;\nL_004E:\n\tv62 = this.controller;\nL_0053:\n\tgoto L_005C;\n\tv260 = *([v256 @ X0_v18+E0]);\n\tv261 = v260 == 0;\n\tv262 = ~v261;\n\tgoto L_005C;\n\tv264 = \"il2cpp_codegen_runtime_class_init\"(v256, v252, v140, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005C:\n\tv232 = UnityEngine.Object::op_Inequality(v62, 0);\n\tv234 = v232 == 0;\n\tif (v234) goto L_00D6;\n\tv268 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.height);\n\tv270 = v268 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_0078;\n\tv130 = HutongGames.PlayMaker.FsmFloat::get_Value(this.height);\n\tUnityEngine.CharacterController::set_height(this.controller, v130);\nL_0078:\n\tv276 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.radius);\n\tv278 = v276 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_008C;\n\tv131 = HutongGames.PlayMaker.FsmFloat::get_Value(this.radius);\n\tUnityEngine.CharacterController::set_radius(this.controller, v131);\nL_008C:\n\tv284 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.slopeLimit);\n\tv286 = v284 == 0;\n\tv287 = ~v286;\n\tif (v287) goto L_00A0;\n\tv132 = HutongGames.PlayMaker.FsmFloat::get_Value(this.slopeLimit);\n\tUnityEngine.CharacterController::set_slopeLimit(this.controller, v132);\nL_00A0:\n\tv292 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.stepOffset);\n\tv294 = v292 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_00B4;\n\tv133 = HutongGames.PlayMaker.FsmFloat::get_Value(this.stepOffset);\n\tUnityEngine.CharacterController::set_stepOffset(this.controller, v133);\nL_00B4:\n\tv300 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.center);\n\tv302 = v300 == 0;\n\tv303 = ~v302;\n\tif (v303) goto L_00CB;\n\tv134 = HutongGames.PlayMaker.FsmVector3::get_Value(this.center);\n\tUnityEngine.CharacterController::set_center(this.controller, v134);\nL_00CB:\n\tv231 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.detectCollisions);\n\tv233 = v231 == 0;\n\tif (v233) goto L_00DC;\nL_00D6:\n\treturn;\nL_00DC:\n\tv151 = HutongGames.PlayMaker.FsmBool::get_Value(this.detectCollisions);\n\tUnityEngine.CharacterController::set_detectCollisions(this.controller, v151);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoControllerSettings()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			CharacterController characterController;
			if (ownerDefaultTarget != previousGo)
			{
				CharacterController component = ownerDefaultTarget.GetComponent<CharacterController>();
				previousGo = ownerDefaultTarget;
				controller = component;
				characterController = component;
			}
			else
			{
				characterController = controller;
			}
			if (characterController != null)
			{
				if (!height.IsNone)
				{
					float value = height.Value;
					controller.height = value;
				}
				if (!radius.IsNone)
				{
					float value2 = radius.Value;
					controller.radius = value2;
				}
				if (!slopeLimit.IsNone)
				{
					float value3 = slopeLimit.Value;
					controller.slopeLimit = value3;
				}
				if (!stepOffset.IsNone)
				{
					float value4 = stepOffset.Value;
					controller.stepOffset = value4;
				}
				if (!center.IsNone)
				{
					Vector3 value5 = center.Value;
					controller.center = value5;
				}
				if (!detectCollisions.IsNone)
				{
					bool value6 = detectCollisions.Value;
					controller.detectCollisions = value6;
				}
			}
		}

		[Token(Token = "0x60008CE")]
		[Address(RVA = "0xA91D38", Offset = "0xA91D38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ControllerSettings()
		{
		}
	}
}

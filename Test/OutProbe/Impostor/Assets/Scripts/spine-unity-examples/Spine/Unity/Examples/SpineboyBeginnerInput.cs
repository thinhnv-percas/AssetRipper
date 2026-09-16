using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000021")]
	public class SpineboyBeginnerInput : MonoBehaviour
	{
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x20")]
		public string horizontalAxis;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x28")]
		public string attackButton;

		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x30")]
		public string aimButton;

		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x38")]
		public string jumpButton;

		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x40")]
		public SpineboyBeginnerModel model;

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x150C894", Offset = "0x150C894", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A07]) = v38;\nL_001B:\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = UnityEngine.Object::op_Equality(this.model, 0);\n\tv53 = v51 == 0;\n\tif (v53) goto L_002F;\n\tv58 = UnityEngine.Component::GetComponent(this);\n\tthis.model = v58;\nL_002F:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			if (model == null)
			{
				SpineboyBeginnerModel component = GetComponent<SpineboyBeginnerModel>();
				model = component;
			}
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x150C920", Offset = "0x150C920", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A08]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Equality(this.model, 0);\n\tv50 = v48 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0090;\n\tv54 = UnityEngine.Input::GetAxisRaw(this.horizontalAxis);\n\tv98 = this.model;\n\tv146 = v54 < 0;\n\tv147 = v54 == 0;\n\tv98.currentSpeed = v54;\n\tif (v147) goto L_003A;\n\tv98.facingLeft = v146;\nL_003A:\n\tv174 = v98.state == 2;\n\tif (v174) goto L_004E;\n\tv183 = v54 == 0;\n\tv188 = ~v183;\n\tv98.state = v188;\nL_004E:\n\tv191 = UnityEngine.Input::GetButton(this.attackButton);\n\tv193 = v191 == 0;\n\tif (v193) goto L_0058;\n\tSpine.Unity.Examples.SpineboyBeginnerModel::TryShoot(this.model);\nL_0058:\n\tv159 = UnityEngine.Input::GetButtonDown(this.aimButton);\n\tv198 = v159 == 0;\n\tif (v198) goto L_0068;\n\tv165 = this.model;\n\tv205 = v165.StartAimEvent == 0;\n\tif (v205) goto L_0068;\n\tSystem.Action::Invoke(v165.StartAimEvent);\nL_0068:\n\tv160 = UnityEngine.Input::GetButtonUp(this.aimButton);\n\tv210 = v160 == 0;\n\tif (v210) goto L_0078;\n\tv166 = this.model;\n\tv218 = v166.StopAimEvent == 0;\n\tif (v218) goto L_0078;\n\tSystem.Action::Invoke(v166.StopAimEvent);\nL_0078:\n\tv89 = UnityEngine.Input::GetButtonDown(this.jumpButton);\n\tv91 = v89 == 0;\n\tif (v91) goto L_0090;\n\tv224 = Spine.Unity.Examples.SpineboyBeginnerModel::JumpRoutine(this.model);\n\tv129 = UnityEngine.MonoBehaviour::StartCoroutine(this.model, v224);\n\treturn;\nL_0090:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (model == null)
			{
				return;
			}
			float axisRaw = Input.GetAxisRaw(horizontalAxis);
			SpineboyBeginnerModel spineboyBeginnerModel = model;
			bool facingLeft = axisRaw < 0f;
			bool flag = axisRaw == 0f;
			spineboyBeginnerModel.currentSpeed = axisRaw;
			if (!flag)
			{
				spineboyBeginnerModel.facingLeft = facingLeft;
			}
			if (spineboyBeginnerModel.state != SpineBeginnerBodyState.Jumping)
			{
				bool flag2 = axisRaw == 0f;
				bool state = !flag2;
				spineboyBeginnerModel.state = (state ? SpineBeginnerBodyState.Running : SpineBeginnerBodyState.Idle);
			}
			if (Input.GetButton(attackButton))
			{
				model.TryShoot();
			}
			if (Input.GetButtonDown(aimButton))
			{
				SpineboyBeginnerModel spineboyBeginnerModel2 = model;
				if (spineboyBeginnerModel2.StartAimEvent != null)
				{
					spineboyBeginnerModel2.StartAimEvent();
				}
			}
			if (Input.GetButtonUp(aimButton))
			{
				SpineboyBeginnerModel spineboyBeginnerModel3 = model;
				if (spineboyBeginnerModel3.StopAimEvent != null)
				{
					spineboyBeginnerModel3.StopAimEvent();
				}
			}
			if (Input.GetButtonDown(jumpButton))
			{
				IEnumerator routine = model.JumpRoutine();
				Coroutine coroutine = model.StartCoroutine(routine);
			}
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x150CB50", Offset = "0x150CB50", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv30 = \"Jump\";\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = \"Horizontal\";\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv68 = \"Fire2\";\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv71 = \"Fire1\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37A09]) = v50;\nL_002B:\n\tthis.horizontalAxis = \"Horizontal\";\n\tthis.attackButton = \"Fire1\";\n\tthis.aimButton = \"Fire2\";\n\tthis.jumpButton = \"Jump\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyBeginnerInput()
		{
			horizontalAxis = "Horizontal";
			attackButton = "Fire1";
			aimButton = "Fire2";
			jumpButton = "Jump";
		}
	}
}

using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Spine.Unity.Examples
{
	[RequireComponent(typeof(CharacterController))]
	[Token(Token = "0x2000018")]
	public class BasicPlatformerController : MonoBehaviour
	{
		[Token(Token = "0x2000019")]
		public enum CharacterState
		{
			[Token(Token = "0x4000086")]
			None = 0,
			[Token(Token = "0x4000087")]
			Idle = 1,
			[Token(Token = "0x4000088")]
			Walk = 2,
			[Token(Token = "0x4000089")]
			Run = 3,
			[Token(Token = "0x400008A")]
			Crouch = 4,
			[Token(Token = "0x400008B")]
			Rise = 5,
			[Token(Token = "0x400008C")]
			Fall = 6,
			[Token(Token = "0x400008D")]
			Attack = 7
		}

		[Header("Components")]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x20")]
		public CharacterController controller;

		[Header("Controls")]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x28")]
		public string XAxis;

		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x30")]
		public string YAxis;

		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x38")]
		public string JumpButton;

		[Header("Moving")]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x40")]
		public float walkSpeed;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x44")]
		public float runSpeed;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x48")]
		public float gravityScale;

		[Header("Jumping")]
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x4C")]
		public float jumpSpeed;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x50")]
		public float minimumJumpDuration;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x54")]
		public float jumpInterruptFactor;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x58")]
		public float forceCrouchVelocity;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x5C")]
		public float forceCrouchDuration;

		[Header("Animation")]
		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x60")]
		public SkeletonAnimationHandleExample animationHandle;

		[CompilerGenerated]
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x68")]
		private UnityAction m_OnJump;

		[CompilerGenerated]
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x70")]
		private UnityAction m_OnLand;

		[CompilerGenerated]
		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x78")]
		private UnityAction m_OnHardLand;

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x80")]
		private Vector2 input;

		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x88")]
		private Vector3 velocity;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x94")]
		private float minimumJumpEndTime;

		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x98")]
		private float forceCrouchEndTime;

		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x9C")]
		private bool wasGrounded;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0xA0")]
		private CharacterState previousState;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0xA4")]
		private CharacterState currentState;

		[Token(Token = "0x14000001")]
		public event UnityAction OnJump
		{
			[CompilerGenerated]
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x150B4C4", Offset = "0x150B4C4", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = UnityEngine.Events.UnityAction;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A379F6]) = v38;\nL_0014:\n\tv40 = this + 0x68;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 104;
				Delegate obj2 = this.m_OnJump;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UnityAction))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000051")]
			[Address(RVA = "0x150B560", Offset = "0x150B560", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = UnityEngine.Events.UnityAction;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A379F7]) = v38;\nL_0014:\n\tv40 = this + 0x68;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 104;
				Delegate obj2 = this.m_OnJump;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UnityAction))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000002")]
		public event UnityAction OnLand
		{
			[CompilerGenerated]
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x150B5FC", Offset = "0x150B5FC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = UnityEngine.Events.UnityAction;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A379F8]) = v38;\nL_0014:\n\tv40 = this + 0x70;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 112;
				Delegate obj2 = this.m_OnLand;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UnityAction))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x150B698", Offset = "0x150B698", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = UnityEngine.Events.UnityAction;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A379F9]) = v38;\nL_0014:\n\tv40 = this + 0x70;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 112;
				Delegate obj2 = this.m_OnLand;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UnityAction))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000003")]
		public event UnityAction OnHardLand
		{
			[CompilerGenerated]
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x150B734", Offset = "0x150B734", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = UnityEngine.Events.UnityAction;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A379FA]) = v38;\nL_0014:\n\tv40 = this + 0x78;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 120;
				Delegate obj2 = this.m_OnHardLand;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UnityAction))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000055")]
			[Address(RVA = "0x150B7D0", Offset = "0x150B7D0", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = UnityEngine.Events.UnityAction;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A379FB]) = v38;\nL_0014:\n\tv40 = this + 0x78;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 120;
				Delegate obj2 = this.m_OnHardLand;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UnityAction))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x150B86C", Offset = "0x150B86C", Length = "0x40C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv36 = UnityEngine.Physics;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 1;\n\t*([1A379FC]) = v55;\nL_001C:\n\tv57 = UnityEngine.Time::get_deltaTime();\n\tv62 = UnityEngine.CharacterController::get_isGrounded(this.controller);\n\tv185 = UnityEngine.Input::GetAxis(this.XAxis);\n\tthis.input.x = v185;\n\tv188 = UnityEngine.Input::GetAxis(this.YAxis);\n\tthis.input.y = v188;\n\tv268 = UnityEngine.Input::GetButtonUp(this.JumpButton);\n\tv272 = UnityEngine.Input::GetButtonDown(this.JumpButton);\n\tv274 = ~this.wasGrounded;\n\tv153 = v62 & v274;\n\tv277 = v62 == 0;\n\tif (v277) goto L_004E;\n\tv289 = this.input.y >= -0.5f;\n\tif (v289) goto L_004E;\n\tgoto L_005E;\nL_004E:\n\tv303 = UnityEngine.Time::get_time();\n\tv307 = this.forceCrouchEndTime - v303;\n\tv308 = v307 < 0;\n\tv309 = v307 == 0;\n\tv310 = this.forceCrouchEndTime ^ v303;\n\tv311 = this.forceCrouchEndTime ^ v307;\n\tv312 = v310 & v311;\n\tv313 = v312 < 0;\n\tv314 = v308 == v313;\n\tv315 = ~v309;\n\tv316 = v314 & v315;\nL_005E:\n\tv335 = v153 == 0;\n\tif (v335) goto L_0079;\n\tv338 = -this.velocity.y;\n\tv348 = this.forceCrouchVelocity >= v338;\n\tif (v348) goto L_0079;\n\tv363 = UnityEngine.Time::get_time();\n\tv374 = v363 + this.forceCrouchDuration;\n\tthis.forceCrouchEndTime = v374;\n\tgoto L_00AB;\nL_0079:\n\tv361 = v332 == 0;\n\tif (v361) goto L_0081;\n\tgoto L_00AB;\nL_0081:\n\tv369 = v62 == 0;\n\tif (v369) goto L_0088;\n\tgoto L_00AB;\nL_0088:\n\tv407 = v268 == 0;\n\tif (v407) goto L_FFFFFFFF;\n\tv421 = UnityEngine.Time::get_time();\n\tv435 = v421 - this.minimumJumpEndTime;\n\tv436 = v435 < 0;\n\tgoto L_009D;\nL_009D:\n\tv389 = v409 == 0;\n\tv379 = ~v389;\nL_00AB:\n\tgoto L_00AE;\n\tv416 = \"il2cpp_codegen_runtime_class_init\"(v411, v159, v39, v40, v41, v42, v43, v44, v400, v396, v47, v48, v49, v50, v51, v52);\nL_00AE:\n\tv419 = UnityEngine.Physics::get_gravity();\n\tv427 = v178 == 0;\n\tv430 = ~v427;\n\tv431 = ~v430;\n\tif (v431) goto L_FFFFFFFF;\n\tgoto L_00C2;\nL_00C2:\n\tv456 = v178 == 0;\n\tif (v456) goto L_00CC;\n\tthis.velocity.y = this.jumpSpeed;\n\tv459 = UnityEngine.Time::get_time();\n\tv462 = v459 + this.minimumJumpDuration;\n\tthis.minimumJumpEndTime = v462;\n\tgoto L_00E1;\nL_00CC:\n\tv460 = ~v97;\n\tif (v460) goto L_00E1;\n\tv475 = this.velocity.y <= 0;\n\tif (v475) goto L_FFFFFFFF;\n\tv498 = this.velocity.y * this.jumpInterruptFactor;\n\tthis.velocity.y = v498;\nL_00E1:\n\tthis.velocity.x = 0f;\n\tv494 = v151 & 1;\n\tv495 = v494 == 0;\n\tv496 = ~v495;\n\tif (v496) goto L_011F;\n\tv504 = this.input == 0;\n\tif (v504) goto L_011F;\n\tv550 = UnityEngine.Mathf::Abs(this.input);\n\tv556 = v550 - 0.6f;\n\tv557 = v556 < 0;\n\tv558 = v556 == 0;\n\tv559 = v550 ^ 0.6f;\n\tv560 = v550 ^ v556;\n\tv561 = v559 & v560;\n\tv562 = v561 < 0;\n\tv563 = v557 == v562;\n\tv514 = ~v558;\n\tv564 = v563 & v514;\n\tv565 = ~v564;\n\tif (v565) goto L_FFFFFFFF;\n\tgoto L_0108;\nL_0108:\n\tv601 = this->klass;\n\tv513 = -*([this @ X0 (Spine.Unity.Examples.BasicPlatformerController)+v537 @ X8_v33 (System.Int32)]);\n\tv511 = this.input < 0;\n\tif (v511) goto L_FFFFFFFF;\n\tgoto L_011A;\nL_011A:\n\tthis.velocity.x = v601;\nL_011F:\n\tv542 = v62 == 0;\n\tv547 = ~v542;\n\tv86 = ~v547;\n\tif (v86) goto L_FFFFFFFF;\n\tgoto L_012C;\nL_012C:\n\tv568 = v62 == 0;\n\tif (v568) goto L_0132;\n\tgoto L_0156;\nL_0132:\n\tv574 = ~this.wasGrounded;\n\tif (v574) goto L_0143;\n\tv583 = this.velocity.y >= 0;\n\tif (v583) goto L_FFFFFFFF;\n\tthis.velocity.y = 0f;\n\tgoto L_0156;\nL_0143:\n\tv607 = v419 * this.gravityScale;\n\tv608 = v419.y * this.gravityScale;\n\tv609 = v419.z * this.gravityScale;\n\tv610 = v57 * v607;\n\tv611 = v57 * v608;\n\tv577 = v57 * v609;\n\tv601 = v610 + v601;\n\tv614 = v611 + this.velocity.y;\n\tv615 = v577 + this.velocity.z;\n\tthis.velocity = v601;\n\tthis.velocity.y = v614;\n\tthis.velocity.z = v615;\nL_0156:\n\tv620 = v57 * v601;\n\tv94 = v57 * this.velocity.z;\n\tv141 = v57 * this.velocity.y;\n\t// 346 MakeStruct v68 @ AGG150FB40_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v620 @ V0_v12 (System.Single), v141 @ V1_v10 (System.Single), v94 @ V2_v5 (System.Single)\n\tv622 = UnityEngine.CharacterController::Move(this.controller, v68);\n\tthis.wasGrounded = v62;\n\tv623 = v62 == 0;\n\tif (v623) goto L_017B;\n\tv628 = v151 == 0;\n\tv633 = ~v628;\n\tv634 = ~v633;\n\tif (v634) goto L_FFFFFFFF;\n\tgoto L_016F;\nL_016F:\n\tv657 = v151 & 1;\n\tv658 = v657 == 0;\n\tif (v658) goto L_0195;\n\tgoto L_01B2;\nL_017B:\n\tv642 = this.velocity.y < 0;\n\tv643 = this.velocity.y == 0;\n\tv645 = this.velocity.y ^ this.velocity.y;\n\tv646 = this.velocity.y & v645;\n\tv647 = v646 < 0;\n\tv648 = v642 == v647;\n\tv649 = ~v643;\n\tv650 = v648 & v649;\n\tv651 = ~v650;\n\tif (v651) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_01B2;\nL_0195:\n\tv671 = this.input != 0;\n\tif (v671) goto L_019B;\n\tgoto L_01B2;\nL_019B:\n\tv696 = UnityEngine.Mathf::Abs(this.input);\n\tv691 = v696 - 0.6f;\n\tv689 = v691 < 0;\n\tv687 = v691 == 0;\n\tv685 = v696 ^ 0.6f;\n\tv683 = v696 ^ v691;\n\tv681 = v685 & v683;\n\tv679 = v681 < 0;\n\tv716 = v689 == v679;\n\tv675 = ~v687;\n\tv677 = v716 & v675;\n\tv674 = ~v677;\n\tif (v674) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_01B2:\n\tthis.previousState = v173;\n\tthis.currentState = v173;\n\tv705 = this.previousState == v173;\n\tif (v705) goto L_01CA;\n\tSpine.Unity.Examples.BasicPlatformerController::HandleStateChanged(this);\nL_01CA:\n\tv106 = this.input != 0;\n\tif (v106) goto L_01DC;\n\tv718 = v178 == 0;\n\tv719 = ~v718;\n\tif (v719) goto L_01E0;\nL_01D0:\n\tv725 = v153 == 0;\n\tif (v725) goto L_01F9;\nL_01D2:\n\tv733 = v144 == 0;\n\tif (v733) goto L_01FA;\n\tv262 = this.OnHardLand;\n\tv737 = this.OnHardLand == 0;\n\tv166 = ~v737;\n\tif (v166) goto L_020F;\n\tgoto L_0210;\nL_01DC:\n\tSpine.Unity.Examples.SkeletonAnimationHandleExample::SetFlip(this.animationHandle, this.input);\n\tv724 = v178 == 0;\n\tif (v724) goto L_01D0;\nL_01E0:\n\t;\n\tUnityEngine.Events.UnityAction::Invoke(this.OnJump);\n\tv735 = v153 == 0;\n\tv731 = ~v735;\n\tif (v731) goto L_01D2;\nL_01F9:\n\treturn;\nL_01FA:\n\tv262 = this.OnLand;\nL_020F:\n\tUnityEngine.Events.UnityAction::Invoke(v262);\nL_0210:\n\tthrow System.NullReferenceException;\n// 325 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0131: Expected O, but got F4
			//IL_0140: Expected O, but got F4
			//IL_01a1: Expected O, but got F4
			//IL_0481: Expected O, but got F4
			//IL_048e: Expected O, but got F4
			//IL_0658: Expected O, but got F4
			//IL_0bde: Expected F4, but got I
			//IL_0bef: Expected F4, but got I
			//IL_07c6: Expected I4, but got F4
			//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07da: Expected I4, but got Unknown
			//IL_08cf: Expected O, but got F4
			//IL_08dc: Expected O, but got F4
			float deltaTime = Time.deltaTime;
			bool isGrounded = controller.isGrounded;
			float axis = Input.GetAxis(XAxis);
			input.x = axis;
			float axis2 = Input.GetAxis(YAxis);
			input.y = axis2;
			bool buttonUp = Input.GetButtonUp(JumpButton);
			bool buttonDown = Input.GetButtonDown(JumpButton);
			int num = ((!wasGrounded) ? 1 : 0);
			int num2 = (isGrounded ? 1 : 0) & num;
			bool flag;
			if (isGrounded && input.y < -0.5f)
			{
				flag = true;
			}
			else
			{
				float time = Time.time;
				float num3 = forceCrouchEndTime - time;
				bool flag2 = num3 < 0f;
				bool flag3 = num3 == 0f;
				object obj = forceCrouchEndTime ^ time;
				object obj2 = forceCrouchEndTime ^ num3;
				int num4 = (int)((nint)obj & (nint)obj2);
				bool flag4 = num4 < 0;
				bool flag5 = flag2 == flag4;
				bool flag6 = !flag3;
				bool flag7 = flag5 && flag6;
				flag = flag7;
			}
			bool flag8;
			int num6;
			int num7;
			bool flag9;
			if (num2 != 0)
			{
				object obj3 = 0f - velocity.y;
				if (forceCrouchVelocity < (float)obj3)
				{
					float time2 = Time.time;
					float num5 = time2 + forceCrouchDuration;
					forceCrouchEndTime = num5;
					flag8 = false;
					num6 = 1;
					num7 = 1;
					flag9 = false;
					goto IL_02ff;
				}
			}
			if (flag)
			{
				flag8 = false;
				num6 = 0;
				num7 = 1;
				flag9 = false;
			}
			else if (isGrounded)
			{
				flag8 = false;
				num6 = 0;
				num7 = 0;
				flag9 = buttonDown;
			}
			else
			{
				bool flag11;
				if (buttonUp)
				{
					float time3 = Time.time;
					float num8 = time3 - minimumJumpEndTime;
					bool flag10 = num8 < 0f;
					flag11 = flag10;
				}
				else
				{
					flag11 = false;
				}
				bool flag12 = !flag11;
				bool flag13 = !flag12;
				flag8 = flag13;
				num6 = 0;
				num7 = 0;
				flag9 = false;
			}
			goto IL_02ff;
			IL_0683:
			float num9;
			float x = deltaTime * num9;
			float z = deltaTime * velocity.z;
			float y = deltaTime * velocity.y;
			Vector3 motion = default(Vector3);
			motion.x = x;
			motion.y = y;
			motion.z = z;
			CollisionFlags collisionFlags = controller.Move(motion);
			wasGrounded = isGrounded;
			CharacterState characterState;
			int num16;
			if (isGrounded)
			{
				int num10 = ((num7 == 0) ? num2 : 0);
				if ((num7 & 1) != 0)
				{
					characterState = CharacterState.Crouch;
				}
				else if (input.x == 0f)
				{
					characterState = CharacterState.Idle;
				}
				else
				{
					float num11 = Mathf.Abs(input.x);
					float num12 = num11 - 0.6f;
					bool flag14 = num12 < 0f;
					bool flag15 = num12 == 0f;
					object obj4 = num11 ^ 0.6f;
					object obj5 = num11 ^ num12;
					int num13 = (int)((nint)obj4 & (nint)obj5);
					bool flag16 = num13 < 0;
					bool flag17 = flag14 == flag16;
					bool flag18 = !flag15;
					characterState = ((!(flag17 && flag18)) ? CharacterState.Walk : CharacterState.Run);
					y = 0.6f;
					num2 = num10;
				}
			}
			else
			{
				bool flag19 = velocity.y < 0f;
				bool flag20 = velocity.y == 0f;
				int num14 = velocity.y ^ velocity.y;
				int num15 = velocity.y & num14;
				bool flag21 = num15 < 0;
				bool flag22 = flag19 == flag21;
				bool flag23 = !flag20;
				characterState = ((!(flag22 && flag23)) ? CharacterState.Fall : CharacterState.Rise);
				num2 = num16;
			}
			previousState = characterState;
			currentState = characterState;
			if (previousState != characterState)
			{
				HandleStateChanged();
			}
			if (input.x == 0f)
			{
				if (!flag9)
				{
					goto IL_09b1;
				}
			}
			else
			{
				animationHandle.SetFlip(input.x);
				if (!flag9)
				{
					goto IL_09b1;
				}
			}
			this.OnJump();
			if (num2 == 0)
			{
				return;
			}
			goto IL_09ce;
			IL_09ce:
			UnityAction unityAction;
			if (num6 != 0)
			{
				unityAction = this.OnHardLand;
				if (this.OnHardLand == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				unityAction = this.OnLand;
			}
			unityAction();
			return;
			IL_02ff:
			Vector3 gravity = Physics.gravity;
			int num17 = ((!flag9) ? num2 : 0);
			if (flag9)
			{
				velocity.y = jumpSpeed;
				float time4 = Time.time;
				float num18 = time4 + minimumJumpDuration;
				minimumJumpEndTime = num18;
			}
			else if (flag8)
			{
				if (velocity.y > 0f)
				{
					float y2 = velocity.y * jumpInterruptFactor;
					velocity.y = y2;
				}
				num2 = num17;
			}
			velocity.x = 0f;
			int num19 = num7 & 1;
			bool flag24 = num19 == 0;
			bool flag25 = !flag24;
			num9 = 0f;
			if (!flag25)
			{
				bool flag26 = input.x == 0f;
				num9 = 0f;
				if (!flag26)
				{
					float num20 = Mathf.Abs(input.x);
					float num21 = num20 - 0.6f;
					bool flag27 = num21 < 0f;
					bool flag28 = num21 == 0f;
					object obj6 = num20 ^ 0.6f;
					object obj7 = num20 ^ num21;
					int num22 = (int)((nint)obj6 & (nint)obj7);
					bool flag29 = num22 < 0;
					bool flag30 = flag27 == flag29;
					bool flag31 = !flag28;
					if (flag30 && flag31)
					{
						int num23 = 68;
					}
					else
					{
						int num23 = 64;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.Examples.BasicPlatformerController)+v537 @ X8_v33 (System.Int32)]");
					num9 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.Examples.BasicPlatformerController)+v537 @ X8_v33 (System.Int32)]");
					float num24 = -0;
					if (input.x < 0f)
					{
						num9 = num24;
					}
					velocity.x = num9;
				}
			}
			num16 = ((!isGrounded) ? num2 : 0);
			if (isGrounded)
			{
				num16 = 0;
			}
			else
			{
				if (wasGrounded)
				{
					if (velocity.y < 0f)
					{
						velocity.y = 0f;
						num2 = 0;
						goto IL_0683;
					}
				}
				else
				{
					float num25 = gravity.x * gravityScale;
					float num26 = gravity.y * gravityScale;
					float num27 = gravity.z * gravityScale;
					float num28 = deltaTime * num25;
					float num29 = deltaTime * num26;
					float num30 = deltaTime * num27;
					num9 = num28 + num9;
					float y3 = num29 + velocity.y;
					float z2 = num30 + velocity.z;
					velocity = (Vector3)num9;
					velocity.y = y3;
					velocity.z = z2;
					num16 = num2;
				}
				num2 = 0;
			}
			goto IL_0683;
			IL_09b1:
			if (num2 != 0)
			{
				goto IL_09ce;
			}
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x150BC78", Offset = "0x150BC78", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv14 = \"idle\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv49 = \"attack\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv59 = \"crouch\";\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv86 = \"fall\";\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv91 = \"run\";\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv94 = \"rise\";\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv97 = \"walk\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A379FD]) = v34;\nL_0023:\n\tv36 = v31.currentState - 1;\n\tv37 = v36 < 6;\n\tv38 = ~v37;\n\tv39 = v36 - 6;\n\tv41 = v39 == 0;\n\tv46 = ~v41;\n\tv47 = v38 & v46;\n\tif (v47) goto L_0044;\n\tv52 = 0x44C000 + 0xCCA;\n\tv55 = *([v52 @ X9_v2 (System.Int32)+v36 @ X8_v4 (System.Int32)]) << 2;\n\tv56 = 0x150FD14 + v55;\n\t// 54 IndirectJump v56 @ X10_v2 (System.Int32), v31 @ X0_v1 (Spine.Unity.Examples.BasicPlatformerController), v31 @ X0_v1 (Spine.Unity.Examples.BasicPlatformerController), methodInfo @ X1 (Il2CppMethodInfo), v17 @ X2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\tX8 = *([1945BD0]);\n\tgoto L_004D;\n\tX8 = *([1945BA0]);\n\tgoto L_004D;\n\tX8 = *([1945BE0]);\n\tgoto L_004D;\n\tX8 = *([1945BF0]);\n\tgoto L_004D;\nL_0044:\n\tgoto L_0052;\n\tX8 = *([1945BF8]);\n\tgoto L_004D;\n\tX8 = *([1945BE8]);\n\tgoto L_004D;\n\tX8 = *([1945BD8]);\nL_004D:\n\tX0 = *([X8]);\nL_0052:\n\tv89 = UnityEngine.Animator::StringToHash(0);\n\tSpine.Unity.Examples.SkeletonAnimationHandleExample::PlayAnimationForState(v31.animationHandle, v89, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleStateChanged()
		{
			int num = (int)(currentState - 1);
			bool flag = num < 6;
			bool flag2 = !flag;
			int num2 = num - 6;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 4505600 + 3274;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v36 @ X8_v4 (System.Int32)]");
				int num4 = (int)((nint)0 << 2);
				int num5 = 22084884 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			int shortNameHash = Animator.StringToHash(null);
			animationHandle.PlayAnimationForState(shortNameHash, 0);
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x150BE1C", Offset = "0x150BE1C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = \"Vertical\";\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv63 = \"Jump\";\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv66 = \"Horizontal\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A379FE]) = v46;\nL_0024:\n\tthis.XAxis = \"Horizontal\";\n\tthis.YAxis = \"Vertical\";\n\tthis.JumpButton = \"Jump\";\n\tthis.walkSpeed = *([407B60]);\n\tthis.minimumJumpDuration = *([408040]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BasicPlatformerController()
		{
			//IL_003e: Expected F4, but got I
			//IL_0050: Expected F4, but got I
			base._002Ector();
			XAxis = "Horizontal";
			YAxis = "Vertical";
			JumpButton = "Jump";
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B60]");
			walkSpeed = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [408040]");
			minimumJumpDuration = 0f;
		}
	}
}

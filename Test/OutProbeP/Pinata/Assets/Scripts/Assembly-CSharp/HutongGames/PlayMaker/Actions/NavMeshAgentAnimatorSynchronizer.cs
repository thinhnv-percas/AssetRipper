using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.AI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7531E4", Offset = "0x7531E4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7531E4", Offset = "0x7531E4")]
	[Token(Token = "0x2000158")]
	public class NavMeshAgentAnimatorSynchronizer : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A78EC", Offset = "0x7A78EC")]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A78EC", Offset = "0x7A78EC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A78EC", Offset = "0x7A78EC")]
		[Token(Token = "0x40011D8")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40011D9")]
		[FieldOffset(Offset = "0x58")]
		private Animator _animator;

		[Token(Token = "0x40011DA")]
		[FieldOffset(Offset = "0x60")]
		private NavMeshAgent _agent;

		[Token(Token = "0x40011DB")]
		[FieldOffset(Offset = "0x68")]
		private Transform _trans;

		[Token(Token = "0x600079D")]
		[Address(RVA = "0xB18CD0", Offset = "0xB18CD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x600079E")]
		[Address(RVA = "0xB18CD8", Offset = "0xB18CD8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleAnimatorMove(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleAnimatorMove = true;
		}

		[Token(Token = "0x600079F")]
		[Address(RVA = "0xB18CF8", Offset = "0xB18CF8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB0628]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022559]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv72 = *([v52 @ X8_v4+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_002C;\n\tv79 = v52;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v79, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv65 = UnityEngine.Object::op_Equality(v47, 0);\n\tv81 = v65 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_005A;\n\tv127 = UnityEngine.GameObject::GetComponent(v47);\n\tthis._agent = v127;\n\tv132 = UnityEngine.GameObject::GetComponent(v47);\n\tthis._animator = v132;\n\tgoto L_004D;\n\tv137 = *([v133 @ X0_v17+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_004D;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v131, v61, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004D:\n\tv122 = UnityEngine.Object::op_Equality(v132, 0);\n\tv104 = v122 == 0;\n\tif (v104) goto L_005E;\nL_005A:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_005E:\n\tv101 = UnityEngine.GameObject::get_transform(v47);\n\tthis._trans = v101;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				NavMeshAgent component = ownerDefaultTarget.GetComponent<NavMeshAgent>();
				_agent = component;
				if (!((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
				{
					Transform transform = ownerDefaultTarget.transform;
					_trans = transform;
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x60007A0")]
		[Address(RVA = "0xB18E28", Offset = "0xB18E28", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EB29A0]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202255A]) = v46;\nL_001C:\n\tv51 = UnityEngine.Animator::get_deltaPosition(this._animator);\n\tv87 = UnityEngine.Time::get_deltaTime();\n\tgoto L_0037;\n\tv121 = *([v117 @ X0_v9+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0037;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v117, v50, v30, v31, v32, v33, v34, v35, v87, v84, v85, v39, v40, v41, v42, v43);\nL_0037:\n\tv73 = UnityEngine.Vector3::op_Division(v51, v87);\n\tUnityEngine.AI.NavMeshAgent::set_velocity(this._agent, v73);\n\tv101 = UnityEngine.Animator::get_rootRotation(this._animator);\n\tUnityEngine.Transform::set_rotation(this._trans, v101);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoAnimatorMove()
		{
			Vector3 deltaPosition = _animator.deltaPosition;
			float deltaTime = Time.deltaTime;
			Vector3 velocity = deltaPosition / deltaTime;
			_agent.velocity = velocity;
			Quaternion rootRotation = _animator.rootRotation;
			_trans.rotation = rootRotation;
		}

		[Token(Token = "0x60007A1")]
		[Address(RVA = "0xB18F18", Offset = "0xB18F18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NavMeshAgentAnimatorSynchronizer()
		{
		}
	}
}

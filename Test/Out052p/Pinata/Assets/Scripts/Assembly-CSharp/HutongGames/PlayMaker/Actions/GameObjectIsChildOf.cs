using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758C4C", Offset = "0x758C4C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758C4C", Offset = "0x758C4C")]
	[Token(Token = "0x2000269")]
	public class GameObjectIsChildOf : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B676C", Offset = "0x7B676C")]
		[Token(Token = "0x400163E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B67B8", Offset = "0x7B67B8")]
		[Token(Token = "0x400163F")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject isChildOf;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6804", Offset = "0x7B6804")]
		[Token(Token = "0x4001640")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B683C", Offset = "0x7B683C")]
		[Token(Token = "0x4001641")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent falseEvent;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6874", Offset = "0x7B6874")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6874", Offset = "0x7B6874")]
		[Token(Token = "0x4001642")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[Token(Token = "0x6000C08")]
		[Address(RVA = "0xB7CED0", Offset = "0xB7CED0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeResult = 0;\n\tthis.gameObject = 0;\n\tthis.trueEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			storeResult = null;
			gameObject = null;
			trueEvent = null;
		}

		[Token(Token = "0x6000C09")]
		[Address(RVA = "0xB7CEE0", Offset = "0xB7CEE0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tHutongGames.PlayMaker.Actions.GameObjectIsChildOf::DoIsChildOf(this, v14);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			DoIsChildOf(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x6000C0A")]
		[Address(RVA = "0xB7CF28", Offset = "0xB7CF28", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF1628]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202297B]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(go, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0069;\n\tv63 = this.isChildOf == 0;\n\tif (v63) goto L_0069;\n\tv125 = UnityEngine.GameObject::get_transform(go);\n\tv148 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.isChildOf);\n\tv133 = UnityEngine.GameObject::get_transform(v148);\n\tv134 = UnityEngine.Transform::IsChildOf(v125, v133);\n\tv144 = this.storeResult;\n\tv144.value = v134;\n\tv96 = this + 0x60;\n\tv93 = this + 0x68;\n\tv87 = v134 == 0;\n\tv78 = ~v87;\n\tv75 = ~v78;\n\tif (v75) goto L_FFFFFFFF;\n\tgoto L_0061;\nL_0061:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v96 @ X9_v5]));\n\treturn;\nL_0069:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIsChildOf(GameObject go)
		{
			//IL_00d0: Expected O, but got I
			//IL_00dc: Expected O, but got I
			if (!(go == null) && isChildOf != null)
			{
				Transform transform = go.transform;
				GameObject value = isChildOf.Value;
				Transform transform2 = value.transform;
				bool flag = transform.IsChildOf(transform2);
				FsmBool fsmBool = storeResult;
				fsmBool.value = flag;
				object fsmEvent = (long)(IntPtr)this + 96L;
				object obj = (long)(IntPtr)this + 104L;
				if (!flag)
				{
					fsmEvent = obj;
				}
				Fsm.Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000C0B")]
		[Address(RVA = "0xB7D044", Offset = "0xB7D044", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectIsChildOf()
		{
		}
	}
}

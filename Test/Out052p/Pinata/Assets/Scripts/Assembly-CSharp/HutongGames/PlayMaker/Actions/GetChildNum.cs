using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75618C", Offset = "0x75618C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75618C", Offset = "0x75618C")]
	[Token(Token = "0x20001E6")]
	public class GetChildNum : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0E88", Offset = "0x7B0E88")]
		[Token(Token = "0x400144A")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0ED4", Offset = "0x7B0ED4")]
		[Token(Token = "0x400144B")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt childIndex;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B0F20", Offset = "0x7B0F20")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0F20", Offset = "0x7B0F20")]
		[Token(Token = "0x400144C")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject store;

		[Token(Token = "0x6000A07")]
		[Address(RVA = "0xB841C0", Offset = "0xB841C0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.childIndex = v12;\n\tthis.store = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			childIndex = fsmInt;
			store = null;
		}

		[Token(Token = "0x6000A08")]
		[Address(RVA = "0xB841F0", Offset = "0xB841F0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv36 = HutongGames.PlayMaker.Actions.GetChildNum::DoGetChildNum(this, v17);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.store, v36);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			GameObject value = DoGetChildNum(ownerDefaultTarget);
			store.Value = value;
			Finish();
		}

		[Token(Token = "0x6000A09")]
		[Address(RVA = "0xB84258", Offset = "0xB84258", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F08140]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229DB]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(go, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0069;\n\tv80 = UnityEngine.GameObject::get_transform(go);\n\tv67 = UnityEngine.Transform::get_childCount(v80);\n\tv70 = v67 == 0;\n\tif (v70) goto L_0069;\n\tv68 = HutongGames.PlayMaker.FsmInt::get_Value(this.childIndex);\n\tv133 = v68 & 0x80000000;\n\tv134 = v133 == 0;\n\tv71 = ~v134;\n\tif (v71) goto L_0069;\n\tv85 = UnityEngine.GameObject::get_transform(go);\n\tv138 = HutongGames.PlayMaker.FsmInt::get_Value(this.childIndex);\n\tv129 = UnityEngine.GameObject::get_transform(go);\n\tv86 = UnityEngine.Transform::get_childCount(v129);\n\tv117 = v138 / v86;\n\tv140 = v117 * v86;\n\tv126 = v138 - v140;\n\tv130 = UnityEngine.Transform::GetChild(v85, v126);\n\treturnVal3 = UnityEngine.Component::get_gameObject(v130);\n\treturn returnVal3;\nL_0069:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GameObject DoGetChildNum(GameObject go)
		{
			//IL_0098: Expected I4, but got I8
			if (!(go == null))
			{
				Transform transform = go.transform;
				if (transform.childCount != 0)
				{
					int value = childIndex.Value;
					if ((int)(value & 0x80000000L) == 0)
					{
						Transform transform2 = go.transform;
						int value2 = childIndex.Value;
						Transform transform3 = go.transform;
						int childCount = transform3.childCount;
						int num = value2 / childCount;
						int num2 = num * childCount;
						int index = value2 - num2;
						Transform child = transform2.GetChild(index);
						return child.gameObject;
					}
				}
			}
			return null;
		}

		[Token(Token = "0x6000A0A")]
		[Address(RVA = "0xB84388", Offset = "0xB84388", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetChildNum()
		{
		}
	}
}

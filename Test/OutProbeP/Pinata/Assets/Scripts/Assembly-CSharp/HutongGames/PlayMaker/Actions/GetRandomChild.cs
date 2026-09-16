using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7563BC", Offset = "0x7563BC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7563BC", Offset = "0x7563BC")]
	[Token(Token = "0x20001ED")]
	public class GetRandomChild : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001461")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1324", Offset = "0x7B1324")]
		[Token(Token = "0x4001462")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject storeResult;

		[Token(Token = "0x6000A24")]
		[Address(RVA = "0xA32F44", Offset = "0xA32F44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			storeResult = null;
		}

		[Token(Token = "0x6000A25")]
		[Address(RVA = "0xA32F4C", Offset = "0xA32F4C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRandomChild::DoGetRandomChild(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetRandomChild();
			Finish();
		}

		[Token(Token = "0x6000A26")]
		[Address(RVA = "0xA32F74", Offset = "0xA32F74", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EDFD58]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E00]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv96 = *([v66 @ X8_v7+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_002B;\n\tv103 = v66;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v103, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv84 = UnityEngine.Object::op_Equality(v45, 0);\n\tv105 = v84 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0062;\n\tv58 = UnityEngine.GameObject::get_transform(v45);\n\tv135 = UnityEngine.Transform::get_childCount(v58);\n\tv136 = v135 == 0;\n\tif (v136) goto L_0062;\n\tv140 = UnityEngine.GameObject::get_transform(v45);\n\tv85 = UnityEngine.Random::Range(0, v135);\n\tv59 = UnityEngine.Transform::GetChild(v140, v85);\n\tv86 = UnityEngine.Component::get_gameObject(v59);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeResult, v86);\n\treturn;\nL_0062:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetRandomChild()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Transform transform = ownerDefaultTarget.transform;
				int childCount = transform.childCount;
				if (childCount != 0)
				{
					Transform transform2 = ownerDefaultTarget.transform;
					int index = Random.Range(0, childCount);
					Transform child = transform2.GetChild(index);
					GameObject value = child.gameObject;
					storeResult.Value = value;
				}
			}
		}

		[Token(Token = "0x6000A27")]
		[Address(RVA = "0xA330A0", Offset = "0xA330A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetRandomChild()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75645C", Offset = "0x75645C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75645C", Offset = "0x75645C")]
	[Token(Token = "0x20001EF")]
	public class GetRoot : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001466")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B13F8", Offset = "0x7B13F8")]
		[Token(Token = "0x4001467")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject storeRoot;

		[Token(Token = "0x6000A2D")]
		[Address(RVA = "0xA33C70", Offset = "0xA33C70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.storeRoot = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			storeRoot = null;
		}

		[Token(Token = "0x6000A2E")]
		[Address(RVA = "0xA33C78", Offset = "0xA33C78", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRoot::DoGetRoot(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetRoot();
			Finish();
		}

		[Token(Token = "0x6000A2F")]
		[Address(RVA = "0xA33CA0", Offset = "0xA33CA0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC55C8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E06]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv86 = *([v61 @ X8_v7+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_002A;\n\tv93 = v61;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v93, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv76 = UnityEngine.Object::op_Equality(v43, 0);\n\tv95 = v76 == 0;\n\tif (v95) goto L_0039;\n\treturn;\nL_0039:\n\tv53 = UnityEngine.GameObject::get_transform(v43);\n\tv54 = UnityEngine.Transform::get_root(v53);\n\tv77 = UnityEngine.Component::get_gameObject(v54);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeRoot, v77);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetRoot()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Transform transform = ownerDefaultTarget.transform;
				Transform root = transform.root;
				GameObject value = root.gameObject;
				storeRoot.Value = value;
			}
		}

		[Token(Token = "0x6000A30")]
		[Address(RVA = "0xA33D84", Offset = "0xA33D84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetRoot()
		{
		}
	}
}

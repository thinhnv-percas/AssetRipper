using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75668C", Offset = "0x75668C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75668C", Offset = "0x75668C")]
	[Token(Token = "0x20001F6")]
	public class SetLayer : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x400147E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B16D0", Offset = "0x7B16D0")]
		[Token(Token = "0x400147F")]
		[FieldOffset(Offset = "0x58")]
		public int layer;

		[Token(Token = "0x6000A4C")]
		[Address(RVA = "0x995F78", Offset = "0x995F78", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.layer = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			layer = 0;
		}

		[Token(Token = "0x6000A4D")]
		[Address(RVA = "0x995F84", Offset = "0x995F84", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLayer::DoSetLayer(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetLayer();
			Finish();
		}

		[Token(Token = "0x6000A4E")]
		[Address(RVA = "0x995FAC", Offset = "0x995FAC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB54B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021761]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Equality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_003E;\n\treturn;\nL_003E:\n\tUnityEngine.GameObject::set_layer(v43, this.layer);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLayer()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				ownerDefaultTarget.layer = layer;
			}
		}

		[Token(Token = "0x6000A4F")]
		[Address(RVA = "0x996064", Offset = "0x996064", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetLayer()
		{
		}
	}
}

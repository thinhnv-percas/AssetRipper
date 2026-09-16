using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75613C", Offset = "0x75613C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75613C", Offset = "0x75613C")]
	[Token(Token = "0x20001E5")]
	public class GetChildCount : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0DDC", Offset = "0x7B0DDC")]
		[Token(Token = "0x4001448")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B0E28", Offset = "0x7B0E28")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0E28", Offset = "0x7B0E28")]
		[Token(Token = "0x4001449")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt storeResult;

		[Token(Token = "0x6000A03")]
		[Address(RVA = "0xB840C4", Offset = "0xB840C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			storeResult = null;
		}

		[Token(Token = "0x6000A04")]
		[Address(RVA = "0xB840CC", Offset = "0xB840CC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetChildCount::DoGetChildCount(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetChildCount();
			Finish();
		}

		[Token(Token = "0x6000A05")]
		[Address(RVA = "0xB840F4", Offset = "0xB840F4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBD1F0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229DA]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv83 = *([v58 @ X8_v7+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002A;\n\tv90 = v58;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v90, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv73 = UnityEngine.Object::op_Equality(v43, 0);\n\tv92 = v73 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0041;\n\tv56 = this.storeResult;\n\tv52 = UnityEngine.GameObject::get_transform(v43);\n\tv74 = UnityEngine.Transform::get_childCount(v52);\n\tv56.value = v74;\nL_0041:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetChildCount()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				FsmInt fsmInt = storeResult;
				Transform transform = ownerDefaultTarget.transform;
				int childCount = transform.childCount;
				fsmInt.Value = childCount;
			}
		}

		[Token(Token = "0x6000A06")]
		[Address(RVA = "0xB841B8", Offset = "0xB841B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetChildCount()
		{
		}
	}
}

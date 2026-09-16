using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7564AC", Offset = "0x7564AC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7564AC", Offset = "0x7564AC")]
	[Token(Token = "0x20001F0")]
	public class GetTag : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001468")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1444", Offset = "0x7B1444")]
		[Token(Token = "0x4001469")]
		[FieldOffset(Offset = "0x58")]
		public FsmString storeResult;

		[Token(Token = "0x400146A")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000A31")]
		[Address(RVA = "0xA364E4", Offset = "0xA364E4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			storeResult = null;
		}

		[Token(Token = "0x6000A32")]
		[Address(RVA = "0xA364F0", Offset = "0xA364F0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTag::DoGetTag(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetTag();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A33")]
		[Address(RVA = "0xA365EC", Offset = "0xA365EC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTag::DoGetTag(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetTag();
		}

		[Token(Token = "0x6000A34")]
		[Address(RVA = "0xA3652C", Offset = "0xA3652C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0E750]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E17]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_0029;\n\tv82 = *([v60 @ X8_v7+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0029;\n\tv90 = v60;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v90, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv89 = UnityEngine.Object::op_Equality(v42, 0);\n\tv92 = v89 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0040;\n\tv58 = this.storeResult;\n\tv53 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tv74 = UnityEngine.GameObject::get_tag(v53);\n\tv58.value = v74;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetTag()
		{
			GameObject value = gameObject.Value;
			if (!(value == null))
			{
				FsmString fsmString = storeResult;
				GameObject value2 = gameObject.Value;
				string tag = value2.tag;
				fsmString.Value = tag;
			}
		}

		[Token(Token = "0x6000A35")]
		[Address(RVA = "0xA365F0", Offset = "0xA365F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetTag()
		{
		}
	}
}

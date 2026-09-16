using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7566DC", Offset = "0x7566DC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7566DC", Offset = "0x7566DC")]
	[Token(Token = "0x20001F7")]
	public class SetName : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001480")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x4001481")]
		[FieldOffset(Offset = "0x58")]
		public FsmString name;

		[Token(Token = "0x6000A50")]
		[Address(RVA = "0x997EFC", Offset = "0x997EFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.name = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			name = null;
		}

		[Token(Token = "0x6000A51")]
		[Address(RVA = "0x997F04", Offset = "0x997F04", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetName::DoSetLayer(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetLayer();
			Finish();
		}

		[Token(Token = "0x6000A52")]
		[Address(RVA = "0x997F2C", Offset = "0x997F2C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAA0B0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021782]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv77 = *([v56 @ X8_v7+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002A;\n\tv85 = v56;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v85, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv84 = UnityEngine.Object::op_Equality(v43, 0);\n\tv87 = v84 == 0;\n\tif (v87) goto L_0038;\n\treturn;\nL_0038:\n\tv70 = HutongGames.PlayMaker.FsmString::get_Value(this.name);\n\tUnityEngine.Object::set_name(v43, v70);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLayer()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				string value = name.Value;
				ownerDefaultTarget.name = value;
			}
		}

		[Token(Token = "0x6000A53")]
		[Address(RVA = "0x997FF4", Offset = "0x997FF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetName()
		{
		}
	}
}

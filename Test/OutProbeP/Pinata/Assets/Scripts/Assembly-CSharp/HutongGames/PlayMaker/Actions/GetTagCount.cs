using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7564FC", Offset = "0x7564FC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7564FC", Offset = "0x7564FC")]
	[Token(Token = "0x20001F1")]
	public class GetTagCount : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1480", Offset = "0x7B1480")]
		[Token(Token = "0x400146B")]
		[FieldOffset(Offset = "0x50")]
		public FsmString tag;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1494", Offset = "0x7B1494")]
		[Token(Token = "0x400146C")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt storeResult;

		[Token(Token = "0x6000A36")]
		[Address(RVA = "0xA365F8", Offset = "0xA365F8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF51E0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E18]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Untagged\");\n\tthis.tag = v43;\n\tthis.storeResult = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "Untagged";
			tag = fsmString;
			storeResult = null;
		}

		[Token(Token = "0x6000A37")]
		[Address(RVA = "0xA36650", Offset = "0xA36650", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmString::get_Value(this.tag);\n\tv31 = UnityEngine.GameObject::FindGameObjectsWithTag(v13);\n\tv32 = this.storeResult;\n\tv33 = this.storeResult == 0;\n\tif (v33) goto L_001C;\n\tv51 = v31 == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv52 = v31.Length;\n\tgoto L_0015;\nL_0015:\n\tv32.value = v52;\nL_001C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = tag.Value;
			GameObject[] array = GameObject.FindGameObjectsWithTag(value);
			FsmInt fsmInt = storeResult;
			if (storeResult != null)
			{
				int value2 = ((array != null) ? array.Length : 0);
				fsmInt.Value = value2;
			}
			Finish();
		}

		[Token(Token = "0x6000A38")]
		[Address(RVA = "0xA366AC", Offset = "0xA366AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetTagCount()
		{
		}
	}
}

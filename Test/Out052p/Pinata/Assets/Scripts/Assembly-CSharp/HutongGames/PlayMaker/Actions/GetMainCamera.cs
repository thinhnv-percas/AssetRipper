using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754700", Offset = "0x754700")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x754700", Offset = "0x754700")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754700", Offset = "0x754700")]
	[Token(Token = "0x2000194")]
	public class GetMainCamera : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABA08", Offset = "0x7ABA08")]
		[Token(Token = "0x40012D2")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject storeGameObject;

		[Token(Token = "0x60008A3")]
		[Address(RVA = "0xA2F514", Offset = "0xA2F514", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeGameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeGameObject = null;
		}

		[Token(Token = "0x60008A4")]
		[Address(RVA = "0xA2F51C", Offset = "0xA2F51C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F0BC90]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DE1]) = v40;\nL_0016:\n\tv43 = UnityEngine.Camera::get_main();\n\tgoto L_0028;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv62 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv61 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv65 = v61 == 0;\n\tif (v65) goto L_0038;\n\tv67 = UnityEngine.Camera::get_main();\n\tv71 = UnityEngine.Component::get_gameObject(v67);\nL_0038:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, v68);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv78 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Camera main = Camera.main;
			bool flag = main != null;
			bool flag2 = !flag;
			GameObject value = null;
			if (!flag2)
			{
				Camera main2 = Camera.main;
				GameObject gameObject = main2.gameObject;
				value = gameObject;
			}
			storeGameObject.Value = value;
			Finish();
		}

		[Token(Token = "0x60008A5")]
		[Address(RVA = "0xA2F5EC", Offset = "0xA2F5EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMainCamera()
		{
		}
	}
}

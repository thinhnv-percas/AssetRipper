using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755EBC", Offset = "0x755EBC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755EBC", Offset = "0x755EBC")]
	[Token(Token = "0x20001DD")]
	public class DestroyObject : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B066C", Offset = "0x7B066C")]
		[Token(Token = "0x400142F")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B06B8", Offset = "0x7B06B8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B06B8", Offset = "0x7B06B8")]
		[Token(Token = "0x4001430")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat delay;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B070C", Offset = "0x7B070C")]
		[Token(Token = "0x4001431")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool detachChildren;

		[Token(Token = "0x60009E2")]
		[Address(RVA = "0xA86358", Offset = "0xA86358", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.delay = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 0f;
			delay = fsmFloat;
		}

		[Token(Token = "0x60009E3")]
		[Address(RVA = "0xA86388", Offset = "0xA86388", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EEFB68]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022199]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_002B;\n\tv135 = *([v102 @ X8_v5+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_002B;\n\tv143 = v102;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v143, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002B:\n\tv142 = UnityEngine.Object::op_Inequality(v46, 0);\n\tv145 = v142 == 0;\n\tif (v145) goto L_007C;\n\tv77 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tv193 = v77 < 0;\n\tv75 = ~v193;\n\tv66 = v77 == 0;\n\tv194 = ~v75;\n\tv51 = v194 | v66;\n\tif (v51) goto L_0059;\n\tv200 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tgoto L_0053;\n\tv222 = *([v210 @ X0_v25+E0]);\n\tv223 = v222 == 0;\n\tv224 = ~v223;\n\tif (v224) goto L_0053;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v210, v199, v80, v27, v28, v29, v30, v31, v200, v33, v34, v35, v36, v37, v38, v39);\nL_0053:\n\tUnityEngine.Object::Destroy(v46, v200);\n\tgoto L_0066;\nL_0059:\n\tgoto L_0061;\n\tv201 = *([v195 @ X0_v20+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0061;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v195, v88, v80, v27, v28, v29, v30, v31, v77, v33, v34, v35, v36, v37, v38, v39);\nL_0061:\n\tUnityEngine.Object::Destroy(v46);\nL_0066:\n\tv128 = HutongGames.PlayMaker.FsmBool::get_Value(this.detachChildren);\n\tv192 = v128 == 0;\n\tif (v192) goto L_007C;\n\tv95 = UnityEngine.GameObject::get_transform(v46);\n\tUnityEngine.Transform::DetachChildren(v95);\nL_007C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject value = gameObject.Value;
			if (value != null)
			{
				float value2 = delay.Value;
				bool flag = value2 < 0f;
				bool flag2 = !flag;
				bool flag3 = value2 == 0f;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					float value3 = delay.Value;
					Object.Destroy(value, value3);
				}
				else
				{
					Object.Destroy(value);
				}
				if (detachChildren.Value)
				{
					Transform transform = value.transform;
					transform.DetachChildren();
				}
			}
			Finish();
		}

		[Token(Token = "0x60009E4")]
		[Address(RVA = "0xA864E4", Offset = "0xA864E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate()
		{
		}

		[Token(Token = "0x60009E5")]
		[Address(RVA = "0xA864E8", Offset = "0xA864E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DestroyObject()
		{
		}
	}
}

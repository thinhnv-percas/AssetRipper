using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75ACFC", Offset = "0x75ACFC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75ACFC", Offset = "0x75ACFC")]
	[Token(Token = "0x20002D0")]
	public class SetGravity2d : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF5FC", Offset = "0x7BF5FC")]
		[Token(Token = "0x4001888")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF634", Offset = "0x7BF634")]
		[Token(Token = "0x4001889")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF66C", Offset = "0x7BF66C")]
		[Token(Token = "0x400188A")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF6A4", Offset = "0x7BF6A4")]
		[Token(Token = "0x400188B")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000E15")]
		[Address(RVA = "0x994F74", Offset = "0x994F74", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB2710]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021753]) = v42;\nL_0015:\n\tthis.vector = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.x = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.y = v52;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			vector = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			everyFrame = false;
		}

		[Token(Token = "0x6000E16")]
		[Address(RVA = "0x995018", Offset = "0x995018", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGravity2d::DoSetGravity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetGravity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E17")]
		[Address(RVA = "0x99512C", Offset = "0x99512C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGravity2d::DoSetGravity(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetGravity();
		}

		[Token(Token = "0x6000E18")]
		[Address(RVA = "0x995054", Offset = "0x995054", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAA540]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021754]) = v42;\nL_0015:\n\tv43 = this.vector;\n\tv111 = v43.value.y;\n\tv51 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv70 = v51 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_002D;\n\tv72 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_002D:\n\tv104 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv106 = v104 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_003E;\n\tv109 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_003E:\n\tgoto L_004E;\n\tv121 = *([v117 @ X0_v11+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tgoto L_004E;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v117, v87, v26, v27, v28, v29, v30, v31, v108, v33, v34, v35, v36, v37, v38, v39);\nL_004E:\n\t// 78 MakeStruct v78 @ AGG995120_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v59 @ V9_v3 (System.Single), v111 @ V8_v3 (System.Single)\n\tUnityEngine.Physics2D::set_gravity(v78);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetGravity()
		{
			FsmVector2 fsmVector = vector;
			float num = fsmVector.value.y;
			bool isNone = x.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num2 = fsmVector.value.x;
			if (!flag2)
			{
				float value = x.Value;
				num2 = value;
			}
			if (!y.IsNone)
			{
				float value2 = y.Value;
				num = value2;
			}
			Vector2 gravity = default(Vector2);
			gravity.x = num2;
			gravity.y = num;
			Physics2D.gravity = gravity;
		}

		[Token(Token = "0x6000E19")]
		[Address(RVA = "0x995130", Offset = "0x995130", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGravity2d()
		{
		}
	}
}

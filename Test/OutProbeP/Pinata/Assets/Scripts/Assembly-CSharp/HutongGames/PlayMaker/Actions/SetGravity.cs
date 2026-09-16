using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A16C", Offset = "0x75A16C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A16C", Offset = "0x75A16C")]
	[Token(Token = "0x20002AB")]
	public class SetGravity : FsmStateAction
	{
		[Token(Token = "0x400177B")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector;

		[Token(Token = "0x400177C")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat x;

		[Token(Token = "0x400177D")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat y;

		[Token(Token = "0x400177E")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat z;

		[Token(Token = "0x400177F")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000D49")]
		[Address(RVA = "0x994D90", Offset = "0x994D90", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBE410]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021752]) = v42;\nL_0015:\n\tthis.vector = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.x = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.y = v52;\n\tv58 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v58);\n\tv58.useVariable = 1;\n\tthis.z = v58;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			vector = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			z = fsmFloat3;
			everyFrame = false;
		}

		[Token(Token = "0x6000D4A")]
		[Address(RVA = "0x994E58", Offset = "0x994E58", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGravity::DoSetGravity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetGravity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D4B")]
		[Address(RVA = "0x994F68", Offset = "0x994F68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGravity::DoSetGravity(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetGravity();
		}

		[Token(Token = "0x6000D4C")]
		[Address(RVA = "0x994E94", Offset = "0x994E94", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector);\n\tv71 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv100 = v71 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0026;\n\tv103 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0026:\n\tv107 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv109 = v107 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0035;\n\tv112 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0035:\n\tv116 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv118 = v116 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004B;\n\tv123 = HutongGames.PlayMaker.FsmFloat::get_Value(this.z);\nL_004B:\n\t// 75 MakeStruct v73 @ AGG994F60_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v27 @ V8_v3 (UnityEngine.Vector3), v24 @ V9_v3 (System.Single), v120 @ V10_v3 (System.Single)\n\tUnityEngine.Physics::set_gravity(v73);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetGravity()
		{
			//IL_006a: Expected O, but got F4
			Vector3 value = this.vector.Value;
			bool isNone = x.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Vector3 vector = value;
			if (!flag2)
			{
				float value2 = x.Value;
				vector = (Vector3)value2;
			}
			bool isNone2 = y.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num = value.y;
			if (!flag4)
			{
				float value3 = y.Value;
				num = value3;
			}
			bool isNone3 = z.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float num2 = value.z;
			if (!flag6)
			{
				float value4 = z.Value;
				num2 = value4;
			}
			Vector3 gravity = default(Vector3);
			gravity.x = vector.x;
			gravity.y = num;
			gravity.z = num2;
			Physics.gravity = gravity;
		}

		[Token(Token = "0x6000D4D")]
		[Address(RVA = "0x994F6C", Offset = "0x994F6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGravity()
		{
		}
	}
}

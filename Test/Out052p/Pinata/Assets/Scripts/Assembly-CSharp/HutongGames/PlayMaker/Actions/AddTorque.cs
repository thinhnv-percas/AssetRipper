using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759BF8", Offset = "0x759BF8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759BF8", Offset = "0x759BF8")]
	[Token(Token = "0x200029A")]
	public class AddTorque : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B95CC", Offset = "0x7B95CC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B95CC", Offset = "0x7B95CC")]
		[Token(Token = "0x4001713")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9664", Offset = "0x7B9664")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9664", Offset = "0x7B9664")]
		[Token(Token = "0x4001714")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 vector;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B96B4", Offset = "0x7B96B4")]
		[Token(Token = "0x4001715")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat x;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B96EC", Offset = "0x7B96EC")]
		[Token(Token = "0x4001716")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat y;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9724", Offset = "0x7B9724")]
		[Token(Token = "0x4001717")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat z;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B975C", Offset = "0x7B975C")]
		[Token(Token = "0x4001718")]
		[FieldOffset(Offset = "0x88")]
		public Space space;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9794", Offset = "0x7B9794")]
		[Token(Token = "0x4001719")]
		[FieldOffset(Offset = "0x8C")]
		public ForceMode forceMode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B97CC", Offset = "0x7B97CC")]
		[Token(Token = "0x400171A")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x6000CE7")]
		[Address(RVA = "0xA1375C", Offset = "0xA1375C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA70E0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D24]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.x = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.y = v52;\n\tv58 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v58);\n\tv58.useVariable = 1;\n\tthis.everyFrame = 0;\n\tthis.z = v58;\n\tthis.space = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			everyFrame = false;
			z = fsmFloat3;
			space = default(Space);
		}

		[Token(Token = "0x6000CE8")]
		[Address(RVA = "0xA13824", Offset = "0xA13824", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.AddTorque)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddTorque)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000CE9")]
		[Address(RVA = "0xA13844", Offset = "0xA13844", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddTorque::DoAddTorque(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddTorque();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CEA")]
		[Address(RVA = "0xA13A60", Offset = "0xA13A60", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddTorque::DoAddTorque(this);\n\treturn;\n")]
		public override void OnFixedUpdate()
		{
			DoAddTorque();
		}

		[Token(Token = "0x6000CEB")]
		[Address(RVA = "0xA13880", Offset = "0xA13880", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EDFFF0]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D25]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.AddTorque)+30]), this.gameObject);\n\tv128 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v49);\n\tv130 = v128 == 0;\n\tif (v130) goto L_00A0;\n\tv183 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector);\n\tv185 = v183 == 0;\n\tif (v185) goto L_0050;\n\tv123 = this + 0x70;\n\tv72 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\n\tv73 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\n\tv209 = HutongGames.PlayMaker.FsmFloat::get_Value(this.z);\n\tv196 = 0;\n\tv205 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(&v196 @ stack_-50_v4 (UnityEngine.Vector3), 0);\n\tgoto L_005B;\nL_0050:\n\tv188 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector);\n\tv123 = this + 0x70;\nL_005B:\n\tv207 = HutongGames.PlayMaker.NamedVariable::get_IsNone(*([v123 @ X20_v5]));\n\tv211 = v207 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_006A;\n\tv215 = HutongGames.PlayMaker.FsmFloat::get_Value(*([v123 @ X20_v5]));\nL_006A:\n\tv220 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv222 = v220 == 0;\n\tv223 = ~v222;\n\tif (v223) goto L_0079;\n\tv225 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0079:\n\tv229 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv231 = v229 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_0089;\n\tv234 = HutongGames.PlayMaker.FsmFloat::get_Value(this.z);\nL_0089:\n\tv101 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv181 = this.space == 0;\n\tif (v181) goto L_0096;\n\t// 147 MakeStruct v172 @ AGGA13A38_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v66 @ V9_v5 (UnityEngine.Vector3), v52 @ V10_v5 (System.Single), v70 @ V8_v5 (System.Single)\n\tUnityEngine.Rigidbody::AddRelativeTorque(v101, v172, this.forceMode);\n\tgoto L_00A0;\nL_0096:\n\t// 150 MakeStruct v171 @ AGGA13A40_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v66 @ V9_v5 (UnityEngine.Vector3), v52 @ V10_v5 (System.Single), v70 @ V8_v5 (System.Single)\n\tUnityEngine.Rigidbody::AddTorque(v101, v171, this.forceMode);\nL_00A0:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddTorque()
		{
			//IL_001c: Expected O, but got I
			//IL_011c: Expected O, but got I
			//IL_0088: Expected O, but got I
			//IL_018d: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddTorque)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				object obj;
				float num;
				Vector3 vector;
				float num3;
				if (this.vector.IsNone)
				{
					obj = (long)(IntPtr)this + 112L;
					float value = x.Value;
					float value2 = y.Value;
					float value3 = z.Value;
					bool flag = ((ComponentAction<Rigidbody>)default(Vector3)).UpdateCache((GameObject)null);
					float num2 = default(float);
					num = num2;
					vector = default(Vector3);
					num3 = 0f;
				}
				else
				{
					Vector3 value4 = this.vector.Value;
					obj = (long)(IntPtr)this + 112L;
					num = value4.y;
					vector = value4;
					num3 = value4.z;
				}
				if (!((NamedVariable)obj).IsNone)
				{
					float value5 = ((FsmFloat)obj).Value;
					vector = (Vector3)value5;
				}
				if (!y.IsNone)
				{
					float value6 = y.Value;
					num = value6;
				}
				if (!z.IsNone)
				{
					float value7 = z.Value;
					num3 = value7;
				}
				Rigidbody rigidbody = base.rigidbody;
				if (space != Space.World)
				{
					Vector3 torque = default(Vector3);
					torque.x = vector.x;
					torque.y = num;
					torque.z = num3;
					rigidbody.AddRelativeTorque(torque, forceMode);
				}
				else
				{
					Vector3 torque2 = default(Vector3);
					torque2.x = vector.x;
					torque2.y = num;
					torque2.z = num3;
					rigidbody.AddTorque(torque2, forceMode);
				}
			}
		}

		[Token(Token = "0x6000CEC")]
		[Address(RVA = "0xA13A64", Offset = "0xA13A64", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F05EC0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D26]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddTorque()
		{
		}
	}
}

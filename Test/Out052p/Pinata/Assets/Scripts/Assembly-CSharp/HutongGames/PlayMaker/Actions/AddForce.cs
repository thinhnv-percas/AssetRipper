using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759BA8", Offset = "0x759BA8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759BA8", Offset = "0x759BA8")]
	[Token(Token = "0x2000299")]
	public class AddForce : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B9344", Offset = "0x7B9344")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9344", Offset = "0x7B9344")]
		[Token(Token = "0x400170A")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B93DC", Offset = "0x7B93DC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B93DC", Offset = "0x7B93DC")]
		[Token(Token = "0x400170B")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 atPosition;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B942C", Offset = "0x7B942C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B942C", Offset = "0x7B942C")]
		[Token(Token = "0x400170C")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 vector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B947C", Offset = "0x7B947C")]
		[Token(Token = "0x400170D")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B94B4", Offset = "0x7B94B4")]
		[Token(Token = "0x400170E")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B94EC", Offset = "0x7B94EC")]
		[Token(Token = "0x400170F")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat z;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9524", Offset = "0x7B9524")]
		[Token(Token = "0x4001710")]
		[FieldOffset(Offset = "0x90")]
		public Space space;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B955C", Offset = "0x7B955C")]
		[Token(Token = "0x4001711")]
		[FieldOffset(Offset = "0x94")]
		public ForceMode forceMode;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9594", Offset = "0x7B9594")]
		[Token(Token = "0x4001712")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x6000CE1")]
		[Address(RVA = "0xA12840", Offset = "0xA12840", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA89D8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D17]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.atPosition = v46;\n\tthis.vector = 0;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.x = v54;\n\tv63 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.y = v63;\n\tv64 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v64);\n\tv64.useVariable = 1;\n\tthis.everyFrame = 0;\n\tthis.z = v64;\n\tthis.space = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			atPosition = fsmVector;
			vector = null;
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

		[Token(Token = "0x6000CE2")]
		[Address(RVA = "0xA12930", Offset = "0xA12930", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.AddForce)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddForce)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000CE3")]
		[Address(RVA = "0xA12950", Offset = "0xA12950", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddForce::DoAddForce(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddForce();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CE4")]
		[Address(RVA = "0xA12BD4", Offset = "0xA12BD4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddForce::DoAddForce(this);\n\treturn;\n")]
		public override void OnFixedUpdate()
		{
			DoAddForce();
		}

		[Token(Token = "0x6000CE5")]
		[Address(RVA = "0xA1298C", Offset = "0xA1298C", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EC9150]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D18]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.AddForce)+30]), this.gameObject);\n\tv123 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v51);\n\tv153 = v123 == 0;\n\tif (v153) goto L_008D;\n\tv234 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector);\n\tv236 = v234 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0040;\n\tv240 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector);\nL_0040:\n\tv247 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv249 = v247 == 0;\n\tv250 = ~v249;\n\tif (v250) goto L_004F;\n\tv251 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_004F:\n\tv256 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv258 = v256 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_005E;\n\tv260 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_005E:\n\tv265 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv267 = v265 == 0;\n\tv268 = ~v267;\n\tif (v268) goto L_006A;\n\tv269 = HutongGames.PlayMaker.FsmFloat::get_Value(this.z);\nL_006A:\n\tv274 = this.space == 0;\n\tif (v274) goto L_0092;\n\tv95 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\t// 129 MakeStruct v175 @ AGGA12AF8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v73 @ V9_v5 (UnityEngine.Vector3), v70 @ V10_v6 (System.Single), v66 @ V8_v6 (System.Single)\n\tUnityEngine.Rigidbody::AddRelativeForce(v95, v175, this.forceMode);\n\treturn;\nL_008D:\n\treturn;\nL_0092:\n\tv278 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.atPosition);\n\tv144 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv282 = v278 == 0;\n\tif (v282) goto L_00B5;\n\t// 174 MakeStruct v173 @ AGGA12B74_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v73 @ V9_v5 (UnityEngine.Vector3), v70 @ V10_v6 (System.Single), v66 @ V8_v6 (System.Single)\n\tUnityEngine.Rigidbody::AddForce(v144, v173, this.forceMode);\n\treturn;\nL_00B5:\n\tv136 = HutongGames.PlayMaker.FsmVector3::get_Value(this.atPosition);\n\t// 204 MakeStruct v167 @ AGGA12BC4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v73 @ V9_v5 (UnityEngine.Vector3), v70 @ V10_v6 (System.Single), v66 @ V8_v6 (System.Single)\n\tUnityEngine.Rigidbody::AddForceAtPosition(v144, v167, v136, this.forceMode);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddForce()
		{
			//IL_001c: Expected O, but got I
			//IL_0127: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddForce)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!UpdateCache(ownerDefaultTarget))
			{
				return;
			}
			bool isNone = this.vector.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num = 0f;
			float num2 = 0f;
			Vector3 vector = default(Vector3);
			if (!flag2)
			{
				Vector3 value = this.vector.Value;
				num = value.z;
				num2 = value.y;
				vector = value;
			}
			if (!x.IsNone)
			{
				float value2 = x.Value;
				vector = (Vector3)value2;
			}
			if (!y.IsNone)
			{
				float value3 = y.Value;
				num2 = value3;
			}
			if (!z.IsNone)
			{
				float value4 = z.Value;
				num = value4;
			}
			if (space != Space.World)
			{
				Rigidbody rigidbody = base.rigidbody;
				Vector3 force = default(Vector3);
				force.x = vector.x;
				force.y = num2;
				force.z = num;
				rigidbody.AddRelativeForce(force, forceMode);
				return;
			}
			bool isNone2 = atPosition.IsNone;
			Rigidbody rigidbody2 = base.rigidbody;
			if (isNone2)
			{
				Vector3 force2 = default(Vector3);
				force2.x = vector.x;
				force2.y = num2;
				force2.z = num;
				rigidbody2.AddForce(force2, forceMode);
			}
			else
			{
				Vector3 value5 = atPosition.Value;
				Vector3 force3 = default(Vector3);
				force3.x = vector.x;
				force3.y = num2;
				force3.z = num;
				rigidbody2.AddForceAtPosition(force3, value5, forceMode);
			}
		}

		[Token(Token = "0x6000CE6")]
		[Address(RVA = "0xA12BD8", Offset = "0xA12BD8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBD748]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D19]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddForce()
		{
		}
	}
}

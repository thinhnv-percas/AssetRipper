using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A48C", Offset = "0x75A48C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A48C", Offset = "0x75A48C")]
	[Token(Token = "0x20002B5")]
	public class AddForce2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB678", Offset = "0x7BB678")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB678", Offset = "0x7BB678")]
		[Token(Token = "0x4001799")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB710", Offset = "0x7BB710")]
		[Token(Token = "0x400179A")]
		[FieldOffset(Offset = "0x68")]
		public ForceMode2D forceMode;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BB748", Offset = "0x7BB748")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB748", Offset = "0x7BB748")]
		[Token(Token = "0x400179B")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector2 atPosition;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BB798", Offset = "0x7BB798")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB798", Offset = "0x7BB798")]
		[Token(Token = "0x400179C")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector2 vector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB7E8", Offset = "0x7BB7E8")]
		[Token(Token = "0x400179D")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB820", Offset = "0x7BB820")]
		[Token(Token = "0x400179E")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB858", Offset = "0x7BB858")]
		[Token(Token = "0x400179F")]
		[FieldOffset(Offset = "0x90")]
		public FsmVector3 vector3;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB890", Offset = "0x7BB890")]
		[Token(Token = "0x40017A0")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x6000D81")]
		[Address(RVA = "0xA12C28", Offset = "0xA12C28", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECEC98]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D1A]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.forceMode = 0;\n\tthis.atPosition = v46;\n\tthis.vector = 0;\n\tv54 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.vector3 = v54;\n\tv64 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v64);\n\tv64.useVariable = 1;\n\tthis.x = v64;\n\tv65 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v65);\n\tv65.useVariable = 1;\n\tthis.y = v65;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			forceMode = default(ForceMode2D);
			atPosition = fsmVector;
			vector = null;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			vector3 = fsmVector2;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			everyFrame = false;
		}

		[Token(Token = "0x6000D82")]
		[Address(RVA = "0xA12D24", Offset = "0xA12D24", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.AddForce2d)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddForce2d)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000D83")]
		[Address(RVA = "0xA12D44", Offset = "0xA12D44", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddForce2d::DoAddForce(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddForce();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D84")]
		[Address(RVA = "0xA12F68", Offset = "0xA12F68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddForce2d::DoAddForce(this);\n\treturn;\n")]
		public override void OnFixedUpdate()
		{
			DoAddForce();
		}

		[Token(Token = "0x6000D85")]
		[Address(RVA = "0xA12D80", Offset = "0xA12D80", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EAC428]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D1B]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.AddForce2d)+30]), this.gameObject);\n\tv127 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v47);\n\tv147 = v127 == 0;\n\tif (v147) goto L_00A8;\n\tv137 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector);\n\tv206 = v137 == 0;\n\tif (v206) goto L_0040;\n\tv69 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\n\tv219 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\n\tv210 = 0;\n\tv216 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(&v210 @ stack_-38_v5 (UnityEngine.Vector2), 0);\n\tgoto L_0049;\nL_0040:\n\tv142 = this.vector;\n\tv64 = v142.value;\n\tv54 = v142.value.y;\nL_0049:\n\tv220 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector3);\n\tv223 = v220 == 0;\n\tv224 = ~v223;\n\tif (v224) goto L_0062;\n\tv71 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector3);\n\tv229 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector3);\nL_0062:\n\tv233 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv235 = v233 == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_0071;\n\tv238 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0071:\n\tv242 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv244 = v242 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_0080;\n\tv247 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0080:\n\tv252 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.atPosition);\n\tv98 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv256 = v252 == 0;\n\tif (v256) goto L_0093;\n\t// 144 MakeStruct v158 @ AGGA12F1C_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v66 @ V8_v6 (UnityEngine.Vector3), v54 @ V9_v7 (System.Single)\n\tUnityEngine.Rigidbody2D::AddForce(v98, v158, this.forceMode);\n\tgoto L_00A8;\nL_0093:\n\tv121 = this.atPosition;\n\t// 158 MakeStruct v152 @ AGGA12F44_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v66 @ V8_v6 (UnityEngine.Vector3), v54 @ V9_v7 (System.Single)\n\t// 159 MakeStruct v149 @ AGGA12F44_2_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v121.value (UnityEngine.Vector2), v121.value.y (System.Single)\n\tUnityEngine.Rigidbody2D::AddForceAtPosition(v98, v152, v149, this.forceMode);\nL_00A8:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddForce()
		{
			//IL_001c: Expected O, but got I
			//IL_01d0: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddForce2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				float num;
				Vector2 vector;
				if (this.vector.IsNone)
				{
					float value = x.Value;
					float value2 = y.Value;
					bool flag = ((ComponentAction<Rigidbody2D>)default(Vector2)).UpdateCache((GameObject)null);
					float num2 = default(float);
					num = num2;
					vector = default(Vector2);
				}
				else
				{
					FsmVector2 fsmVector = this.vector;
					vector = fsmVector.value;
					num = fsmVector.value.y;
				}
				bool isNone = vector3.IsNone;
				bool flag2 = !isNone;
				bool flag3 = !flag2;
				Vector3 vector2 = vector;
				if (!flag3)
				{
					Vector3 value3 = vector3.Value;
					num = vector3.Value.y;
					vector2 = value3;
				}
				if (!x.IsNone)
				{
					float value4 = x.Value;
					vector2 = (Vector3)value4;
				}
				if (!y.IsNone)
				{
					float value5 = y.Value;
					num = value5;
				}
				bool isNone2 = atPosition.IsNone;
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				if (isNone2)
				{
					Vector2 force = default(Vector2);
					force.x = vector2.x;
					force.y = num;
					rigidbody2D.AddForce(force, forceMode);
					return;
				}
				FsmVector2 fsmVector2 = atPosition;
				Vector2 force2 = default(Vector2);
				force2.x = vector2.x;
				force2.y = num;
				Vector2 position = default(Vector2);
				position.x = fsmVector2.value.x;
				position.y = fsmVector2.value.y;
				rigidbody2D.AddForceAtPosition(force2, position, forceMode);
			}
		}

		[Token(Token = "0x6000D86")]
		[Address(RVA = "0xA12F6C", Offset = "0xA12F6C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB42F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D1C]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddForce2d()
		{
		}
	}
}

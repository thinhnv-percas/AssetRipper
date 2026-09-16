using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A4DC", Offset = "0x75A4DC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A4DC", Offset = "0x75A4DC")]
	[Token(Token = "0x20002B6")]
	public class AddRelativeForce2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB8C8", Offset = "0x7BB8C8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB8C8", Offset = "0x7BB8C8")]
		[Token(Token = "0x40017A1")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB960", Offset = "0x7BB960")]
		[Token(Token = "0x40017A2")]
		[FieldOffset(Offset = "0x68")]
		public ForceMode2D forceMode;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BB998", Offset = "0x7BB998")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB998", Offset = "0x7BB998")]
		[Token(Token = "0x40017A3")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector2 vector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB9E8", Offset = "0x7BB9E8")]
		[Token(Token = "0x40017A4")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBA20", Offset = "0x7BBA20")]
		[Token(Token = "0x40017A5")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBA58", Offset = "0x7BBA58")]
		[Token(Token = "0x40017A6")]
		[FieldOffset(Offset = "0x88")]
		public FsmVector3 vector3;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBA90", Offset = "0x7BBA90")]
		[Token(Token = "0x40017A7")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x6000D87")]
		[Address(RVA = "0xA131BC", Offset = "0xA131BC", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE6660]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D1F]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tthis.forceMode = 0;\n\tthis.vector = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.vector3 = v46;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.x = v54;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.y = v61;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			forceMode = default(ForceMode2D);
			vector = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			vector3 = fsmVector;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			everyFrame = false;
		}

		[Token(Token = "0x6000D88")]
		[Address(RVA = "0xA13294", Offset = "0xA13294", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.AddRelativeForce2d)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddRelativeForce2d)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000D89")]
		[Address(RVA = "0xA132B4", Offset = "0xA132B4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddRelativeForce2d::DoAddRelativeForce(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddRelativeForce();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D8A")]
		[Address(RVA = "0xA13498", Offset = "0xA13498", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddRelativeForce2d::DoAddRelativeForce(this);\n\treturn;\n")]
		public override void OnFixedUpdate()
		{
			DoAddRelativeForce();
		}

		[Token(Token = "0x6000D8B")]
		[Address(RVA = "0xA132F0", Offset = "0xA132F0", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EF8CE0]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D20]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.AddRelativeForce2d)+30]), this.gameObject);\n\tv120 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v47);\n\tv138 = v120 == 0;\n\tif (v138) goto L_0090;\n\tv130 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector);\n\tv180 = v130 == 0;\n\tif (v180) goto L_0040;\n\tv69 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\n\tv193 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\n\tv184 = 0;\n\tv190 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(&v184 @ stack_-38_v5 (UnityEngine.Vector2), 0);\n\tgoto L_0049;\nL_0040:\n\tv134 = this.vector;\n\tv64 = v134.value;\n\tv54 = v134.value.y;\nL_0049:\n\tv194 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector3);\n\tv197 = v194 == 0;\n\tv198 = ~v197;\n\tif (v198) goto L_0062;\n\tv71 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector3);\n\tv203 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector3);\nL_0062:\n\tv207 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv209 = v207 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0071;\n\tv212 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0071:\n\tv216 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv218 = v216 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_0080;\n\tv221 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0080:\n\tv97 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\t// 135 MakeStruct v140 @ AGGA13474_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v66 @ V8_v6 (UnityEngine.Vector3), v54 @ V9_v7 (System.Single)\n\tUnityEngine.Rigidbody2D::AddRelativeForce(v97, v140, this.forceMode);\nL_0090:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddRelativeForce()
		{
			//IL_001c: Expected O, but got I
			//IL_01d0: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddRelativeForce2d)+30]");
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
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				Vector2 relativeForce = default(Vector2);
				relativeForce.x = vector2.x;
				relativeForce.y = num;
				rigidbody2D.AddRelativeForce(relativeForce, forceMode);
			}
		}

		[Token(Token = "0x6000D8C")]
		[Address(RVA = "0xA1349C", Offset = "0xA1349C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFF7D0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D21]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddRelativeForce2d()
		{
		}
	}
}

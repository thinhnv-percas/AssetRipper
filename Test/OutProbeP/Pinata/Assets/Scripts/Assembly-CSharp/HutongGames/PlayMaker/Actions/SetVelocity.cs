using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A2AC", Offset = "0x75A2AC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A2AC", Offset = "0x75A2AC")]
	[Token(Token = "0x20002AF")]
	public class SetVelocity : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB33C", Offset = "0x7BB33C")]
		[Token(Token = "0x4001786")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BB3B0", Offset = "0x7BB3B0")]
		[Token(Token = "0x4001787")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 vector;

		[Token(Token = "0x4001788")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat x;

		[Token(Token = "0x4001789")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat y;

		[Token(Token = "0x400178A")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat z;

		[Token(Token = "0x400178B")]
		[FieldOffset(Offset = "0x88")]
		public Space space;

		[Token(Token = "0x400178C")]
		[FieldOffset(Offset = "0x8C")]
		public bool everyFrame;

		[Token(Token = "0x6000D59")]
		[Address(RVA = "0x99B088", Offset = "0x99B088", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF47B0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20217A1]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tthis.vector = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.x = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.y = v52;\n\tv58 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v58);\n\tv58.useVariable = 1;\n\tthis.z = v58;\n\tthis.space = 1;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
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
			space = Space.Self;
			everyFrame = false;
		}

		[Token(Token = "0x6000D5A")]
		[Address(RVA = "0x99B154", Offset = "0x99B154", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000D5B")]
		[Address(RVA = "0x99B174", Offset = "0x99B174", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetVelocity::DoSetVelocity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetVelocity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D5C")]
		[Address(RVA = "0x99B3E8", Offset = "0x99B3E8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetVelocity::DoSetVelocity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			DoSetVelocity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D5D")]
		[Address(RVA = "0x99B1B0", Offset = "0x99B1B0", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EB64A0]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20217A2]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity)+30]), this.gameObject);\n\tv127 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v51);\n\tv169 = v127 == 0;\n\tif (v169) goto L_0055;\n\tv154 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector);\n\tv213 = v154 == 0;\n\tif (v213) goto L_005A;\n\tv214 = this.space == 0;\n\tif (v214) goto L_0062;\n\tv221 = UnityEngine.GameObject::get_transform(v51);\n\tv92 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv145 = UnityEngine.Rigidbody::get_velocity(v92);\n\tv69 = UnityEngine.Transform::InverseTransformDirection(v221, v145);\n\tv67 = v69.y;\n\tv65 = v69.z;\n\tgoto L_0070;\nL_0055:\n\treturn;\nL_005A:\n\tv69 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector);\n\tv67 = v69.y;\n\tv65 = v69.z;\n\tgoto L_0070;\nL_0062:\n\tv94 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv69 = UnityEngine.Rigidbody::get_velocity(v94);\n\tv67 = v69.y;\n\tv65 = v69.z;\nL_0070:\n\tv238 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv240 = v238 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_007F;\n\tv243 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_007F:\n\tv247 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv249 = v247 == 0;\n\tv250 = ~v249;\n\tif (v250) goto L_008E;\n\tv252 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_008E:\n\tv256 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv258 = v256 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_009D;\n\tv261 = HutongGames.PlayMaker.FsmFloat::get_Value(this.z);\nL_009D:\n\tv155 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv269 = this.space == 0;\n\tif (v269) goto L_00C4;\n\tv98 = UnityEngine.GameObject::get_transform(v51);\n\t// 173 MakeStruct v270 @ AGG99B39C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v134 @ V8_v6 (UnityEngine.Vector3), v136 @ V9_v6 (System.Single), v132 @ V10_v6 (System.Single)\n\tv276 = UnityEngine.Transform::TransformDirection(v98, v270);\nL_00C4:\n\t// 196 MakeStruct v180 @ AGG99B3D8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v134 @ V8_v6 (UnityEngine.Vector3), v136 @ V9_v6 (System.Single), v132 @ V10_v6 (System.Single)\n\tUnityEngine.Rigidbody::set_velocity(v155, v180);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetVelocity()
		{
			//IL_001c: Expected O, but got I
			//IL_01b9: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!UpdateCache(ownerDefaultTarget))
			{
				return;
			}
			Vector3 vector;
			float num;
			float num2;
			if (this.vector.IsNone)
			{
				if (space != Space.World)
				{
					Transform transform = ownerDefaultTarget.transform;
					Rigidbody rigidbody = base.rigidbody;
					Vector3 velocity = rigidbody.velocity;
					vector = transform.InverseTransformDirection(velocity);
					num = vector.y;
					num2 = vector.z;
				}
				else
				{
					Rigidbody rigidbody2 = base.rigidbody;
					vector = rigidbody2.velocity;
					num = vector.y;
					num2 = vector.z;
				}
			}
			else
			{
				vector = this.vector.Value;
				num = vector.y;
				num2 = vector.z;
			}
			bool isNone = x.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Vector3 vector2 = vector;
			if (!flag2)
			{
				float value = x.Value;
				vector2 = (Vector3)value;
			}
			bool isNone2 = y.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num3 = num;
			if (!flag4)
			{
				float value2 = y.Value;
				num3 = value2;
			}
			bool isNone3 = z.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float num4 = num2;
			if (!flag6)
			{
				float value3 = z.Value;
				num4 = value3;
			}
			Rigidbody rigidbody3 = base.rigidbody;
			if (space != Space.World)
			{
				Transform transform2 = ownerDefaultTarget.transform;
				Vector3 direction = default(Vector3);
				direction.x = vector2.x;
				direction.y = num3;
				direction.z = num4;
				Vector3 vector3 = transform2.TransformDirection(direction);
				num4 = vector3.z;
				vector2 = vector3;
				num3 = vector3.y;
			}
			Vector3 velocity2 = default(Vector3);
			velocity2.x = vector2.x;
			velocity2.y = num3;
			velocity2.z = num4;
			rigidbody3.velocity = velocity2;
		}

		[Token(Token = "0x6000D5E")]
		[Address(RVA = "0x99B424", Offset = "0x99B424", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EEBB10]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217A3]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetVelocity()
		{
		}
	}
}

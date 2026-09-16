using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AF00", Offset = "0x75AF00")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75AF00", Offset = "0x75AF00")]
	[Token(Token = "0x20002D6")]
	public class SetVelocity2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BFD30", Offset = "0x7BFD30")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BFD30", Offset = "0x7BFD30")]
		[Token(Token = "0x40018A0")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BFDC8", Offset = "0x7BFDC8")]
		[Token(Token = "0x40018A1")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 vector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BFE00", Offset = "0x7BFE00")]
		[Token(Token = "0x40018A2")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BFE38", Offset = "0x7BFE38")]
		[Token(Token = "0x40018A3")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BFE70", Offset = "0x7BFE70")]
		[Token(Token = "0x40018A4")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x6000E30")]
		[Address(RVA = "0x99B474", Offset = "0x99B474", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC8378]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20217A4]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tthis.vector = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.x = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.y = v52;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			everyFrame = false;
		}

		[Token(Token = "0x6000E31")]
		[Address(RVA = "0x99B518", Offset = "0x99B518", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity2d)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Awake()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity2d)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000E32")]
		[Address(RVA = "0x99B538", Offset = "0x99B538", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetVelocity2d::DoSetVelocity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetVelocity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E33")]
		[Address(RVA = "0x99B6C8", Offset = "0x99B6C8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetVelocity2d::DoSetVelocity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			DoSetVelocity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E34")]
		[Address(RVA = "0x99B574", Offset = "0x99B574", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB1DB8]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20217A5]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity2d)+30]), this.gameObject);\n\tv94 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v47);\n\tv111 = v94 == 0;\n\tif (v111) goto L_0040;\n\tv103 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector);\n\tv144 = v103 == 0;\n\tif (v144) goto L_0041;\n\tv72 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv150 = UnityEngine.Rigidbody2D::get_velocity(v72);\n\tgoto L_004A;\nL_0040:\n\treturn;\nL_0041:\n\tv107 = this.vector;\n\tv53 = v107.value;\n\tv50 = v107.value.y;\nL_004A:\n\tv156 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv158 = v156 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0059;\n\tv161 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0059:\n\tv165 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv167 = v165 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0068;\n\tv170 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0068:\n\tv75 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\t// 117 MakeStruct v120 @ AGG99B6B8_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v53 @ V8_v5 (UnityEngine.Vector2), v50 @ V9_v5 (System.Single)\n\tUnityEngine.Rigidbody2D::set_velocity(v75, v120);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetVelocity()
		{
			//IL_001c: Expected O, but got I
			//IL_0134: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetVelocity2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				float num;
				Vector2 vector;
				if (this.vector.IsNone)
				{
					Rigidbody2D rigidbody2D = base.rigidbody2d;
					Vector2 velocity = rigidbody2D.velocity;
					num = velocity.y;
					vector = velocity;
				}
				else
				{
					FsmVector2 fsmVector = this.vector;
					vector = fsmVector.value;
					num = fsmVector.value.y;
				}
				if (!x.IsNone)
				{
					float value = x.Value;
					vector = (Vector2)value;
				}
				if (!y.IsNone)
				{
					float value2 = y.Value;
					num = value2;
				}
				Rigidbody2D rigidbody2D2 = base.rigidbody2d;
				Vector2 velocity2 = default(Vector2);
				velocity2.x = vector.x;
				velocity2.y = num;
				rigidbody2D2.velocity = velocity2;
			}
		}

		[Token(Token = "0x6000E35")]
		[Address(RVA = "0x99B704", Offset = "0x99B704", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFA578]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217A6]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetVelocity2d()
		{
		}
	}
}

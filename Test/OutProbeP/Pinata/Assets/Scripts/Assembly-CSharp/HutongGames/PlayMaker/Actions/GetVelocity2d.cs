using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A93C", Offset = "0x75A93C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A93C", Offset = "0x75A93C")]
	[Token(Token = "0x20002C4")]
	public class GetVelocity2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BDA00", Offset = "0x7BDA00")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BDA00", Offset = "0x7BDA00")]
		[Token(Token = "0x4001820")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BDA98", Offset = "0x7BDA98")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BDA98", Offset = "0x7BDA98")]
		[Token(Token = "0x4001821")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 vector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BDAE8", Offset = "0x7BDAE8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BDAE8", Offset = "0x7BDAE8")]
		[Token(Token = "0x4001822")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat x;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BDB38", Offset = "0x7BDB38")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BDB38", Offset = "0x7BDB38")]
		[Token(Token = "0x4001823")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BDB88", Offset = "0x7BDB88")]
		[Token(Token = "0x4001824")]
		[FieldOffset(Offset = "0x80")]
		public Space space;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BDBC0", Offset = "0x7BDBC0")]
		[Token(Token = "0x4001825")]
		[FieldOffset(Offset = "0x84")]
		public bool everyFrame;

		[Token(Token = "0x6000DD9")]
		[Address(RVA = "0xA37660", Offset = "0xA37660", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetVelocity2d)+7D]) = 0;\n\tthis.gameObject = 0;\n\tthis.x = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			_ = 0;
			gameObject = null;
			x = null;
		}

		[Token(Token = "0x6000DDA")]
		[Address(RVA = "0xA37670", Offset = "0xA37670", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVelocity2d::DoGetVelocity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetVelocity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DDB")]
		[Address(RVA = "0xA377F8", Offset = "0xA377F8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVelocity2d::DoGetVelocity(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetVelocity();
		}

		[Token(Token = "0x6000DDC")]
		[Address(RVA = "0xA376AC", Offset = "0xA376AC", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB3988]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E21]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.GetVelocity2d)+30]), this.gameObject);\n\tv103 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v47);\n\tv163 = v103 == 0;\n\tif (v163) goto L_007A;\n\tv89 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv82 = UnityEngine.Rigidbody2D::get_velocity(v89);\n\tv50 = this.space != 1;\n\tif (v50) goto L_0066;\n\tv90 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv236 = UnityEngine.Component::get_transform(v90);\n\tgoto L_0055;\n\tv242 = *([v153 @ X8_v15+E0]);\n\tv243 = v242 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_0055;\n\tv250 = v153;\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v250, v142, v84, v27, v28, v29, v30, v31, v82, v80, v34, v35, v36, v37, v38, v39);\nL_0055:\n\tv138 = UnityEngine.Vector2::op_Implicit(v82);\n\tv252 = UnityEngine.Transform::InverseTransformDirection(v236, v138);\n\tv231 = UnityEngine.Vector2::op_Implicit(v252);\nL_0066:\n\tv156 = this.vector;\n\tv156.value = v133;\n\tv156.value.y = v131;\n\tv154 = this.x;\n\tv154.value = v133;\n\tv155 = this.y;\n\tv155.value = v131;\nL_007A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetVelocity()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GetVelocity2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				Vector2 velocity = rigidbody2D.velocity;
				bool flag = space != Space.Self;
				float value = velocity.y;
				Vector2 value2 = velocity;
				if (!flag)
				{
					Rigidbody2D rigidbody2D2 = base.rigidbody2d;
					Transform transform = rigidbody2D2.transform;
					Vector3 direction = velocity;
					Vector3 vector = transform.InverseTransformDirection(direction);
					Vector2 vector2 = vector;
					value = vector2.y;
					value2 = vector2;
				}
				FsmVector2 fsmVector = this.vector;
				fsmVector.value = value2;
				fsmVector.value.y = value;
				FsmFloat fsmFloat = x;
				fsmFloat.Value = value2.x;
				FsmFloat fsmFloat2 = y;
				fsmFloat2.Value = value;
			}
		}

		[Token(Token = "0x6000DDD")]
		[Address(RVA = "0xA377FC", Offset = "0xA377FC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFC5C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E22]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetVelocity2d()
		{
		}
	}
}

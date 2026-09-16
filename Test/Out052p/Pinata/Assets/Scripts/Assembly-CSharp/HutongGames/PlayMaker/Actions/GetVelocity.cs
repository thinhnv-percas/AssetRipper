using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759F68", Offset = "0x759F68")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759F68", Offset = "0x759F68")]
	[Token(Token = "0x20002A5")]
	public class GetVelocity : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BA4B4", Offset = "0x7BA4B4")]
		[Token(Token = "0x4001744")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA528", Offset = "0x7BA528")]
		[Token(Token = "0x4001745")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 vector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA53C", Offset = "0x7BA53C")]
		[Token(Token = "0x4001746")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat x;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA550", Offset = "0x7BA550")]
		[Token(Token = "0x4001747")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat y;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA564", Offset = "0x7BA564")]
		[Token(Token = "0x4001748")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat z;

		[Token(Token = "0x4001749")]
		[FieldOffset(Offset = "0x88")]
		public Space space;

		[Token(Token = "0x400174A")]
		[FieldOffset(Offset = "0x8C")]
		public bool everyFrame;

		[Token(Token = "0x6000D2B")]
		[Address(RVA = "0xA3748C", Offset = "0xA3748C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetVelocity)+85]) = 0;\n\tthis.z = 0;\n\tthis.gameObject = 0;\n\tthis.x = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			_ = 0;
			z = null;
			gameObject = null;
			x = null;
		}

		[Token(Token = "0x6000D2C")]
		[Address(RVA = "0xA374A0", Offset = "0xA374A0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVelocity::DoGetVelocity(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetVelocity();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D2D")]
		[Address(RVA = "0xA3760C", Offset = "0xA3760C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetVelocity::DoGetVelocity(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetVelocity();
		}

		[Token(Token = "0x6000D2E")]
		[Address(RVA = "0xA374DC", Offset = "0xA374DC", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EE5738]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021E1F]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.GetVelocity)+30]), this.gameObject);\n\tv123 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v49);\n\tv125 = v123 == 0;\n\tif (v125) goto L_006C;\n\tv106 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv97 = UnityEngine.Rigidbody::get_velocity(v106);\n\tv54 = this.space != 1;\n\tif (v54) goto L_0052;\n\tv107 = UnityEngine.GameObject::get_transform(v49);\n\tv200 = UnityEngine.Transform::InverseTransformDirection(v107, v97);\nL_0052:\n\tv203 = this.vector;\n\tv203.value = v183;\n\tv203.value.y = v181;\n\tv203.value.z = v179;\n\tv209 = this.x;\n\tv209.value = v183;\n\tv210 = this.y;\n\tv210.value = v181;\n\tv190 = this.z;\n\tv190.value = v179;\nL_006C:\n\treturn;\n\tv105 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetVelocity()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GetVelocity)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody rigidbody = base.rigidbody;
				Vector3 velocity = rigidbody.velocity;
				bool flag = space != Space.Self;
				float value = velocity.z;
				float value2 = velocity.y;
				Vector3 value3 = velocity;
				if (!flag)
				{
					Transform transform = ownerDefaultTarget.transform;
					Vector3 vector = transform.InverseTransformDirection(velocity);
					value = vector.z;
					value2 = vector.y;
					value3 = vector;
				}
				FsmVector3 fsmVector = this.vector;
				fsmVector.value = value3;
				fsmVector.value.y = value2;
				fsmVector.value.z = value;
				FsmFloat fsmFloat = x;
				fsmFloat.Value = value3.x;
				FsmFloat fsmFloat2 = y;
				fsmFloat2.Value = value2;
				FsmFloat fsmFloat3 = z;
				fsmFloat3.Value = value;
			}
		}

		[Token(Token = "0x6000D2F")]
		[Address(RVA = "0xA37610", Offset = "0xA37610", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EAFE60]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E20]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetVelocity()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754B2C", Offset = "0x754B2C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754B2C", Offset = "0x754B2C")]
	[Token(Token = "0x20001A0")]
	public class GetControllerHitInfo : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACA60", Offset = "0x7ACA60")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACA60", Offset = "0x7ACA60")]
		[Token(Token = "0x4001316")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACAB0", Offset = "0x7ACAB0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACAB0", Offset = "0x7ACAB0")]
		[Token(Token = "0x4001317")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 contactPoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACB00", Offset = "0x7ACB00")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACB00", Offset = "0x7ACB00")]
		[Token(Token = "0x4001318")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 contactNormal;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACB50", Offset = "0x7ACB50")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACB50", Offset = "0x7ACB50")]
		[Token(Token = "0x4001319")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 moveDirection;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACBA0", Offset = "0x7ACBA0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACBA0", Offset = "0x7ACBA0")]
		[Token(Token = "0x400131A")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat moveLength;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACBF0", Offset = "0x7ACBF0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACBF0", Offset = "0x7ACBF0")]
		[Token(Token = "0x400131B")]
		[FieldOffset(Offset = "0x78")]
		public FsmString physicsMaterialName;

		[Token(Token = "0x60008D5")]
		[Address(RVA = "0xA2A594", Offset = "0xA2A594", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.contactNormal = 0;\n\tthis.moveLength = 0;\n\tthis.gameObjectHit = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			contactNormal = null;
			moveLength = null;
			gameObjectHit = null;
		}

		[Token(Token = "0x60008D6")]
		[Address(RVA = "0xA2A5A4", Offset = "0xA2A5A4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleControllerColliderHit(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleControllerColliderHit = true;
		}

		[Token(Token = "0x60008D7")]
		[Address(RVA = "0xA2A5C4", Offset = "0xA2A5C4", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.fsm;\n\tv15 = v12.<ControllerCollider>k__BackingField == 0;\n\tif (v15) goto L_006B;\n\tv50 = UnityEngine.ControllerColliderHit::get_gameObject(v12.<ControllerCollider>k__BackingField);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v50);\n\tv70 = this.fsm;\n\tv45 = this.contactPoint;\n\tv28 = UnityEngine.ControllerColliderHit::get_point(v70.<ControllerCollider>k__BackingField);\n\tv45.value = v28;\n\tv45.value.y = v28.y;\n\tv45.value.z = v28.z;\n\tv71 = this.fsm;\n\tv46 = this.contactNormal;\n\tv29 = UnityEngine.ControllerColliderHit::get_normal(v71.<ControllerCollider>k__BackingField);\n\tv46.value = v29;\n\tv46.value.y = v29.y;\n\tv46.value.z = v29.z;\n\tv72 = this.fsm;\n\tv47 = this.moveDirection;\n\tv30 = UnityEngine.ControllerColliderHit::get_moveDirection(v72.<ControllerCollider>k__BackingField);\n\tv47.value = v30;\n\tv47.value.y = v30.y;\n\tv47.value.z = v30.z;\n\tv73 = this.fsm;\n\tv48 = this.moveLength;\n\tv31 = UnityEngine.ControllerColliderHit::get_moveLength(v73.<ControllerCollider>k__BackingField);\n\tv48.value = v31;\n\tv74 = this.fsm;\n\tv76 = this.physicsMaterialName;\n\tv103 = UnityEngine.ControllerColliderHit::get_collider(v74.<ControllerCollider>k__BackingField);\n\tv104 = UnityEngine.Collider::get_material(v103);\n\tv56 = UnityEngine.Object::get_name(v104);\n\tv76.value = v56;\nL_006B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreTriggerInfo()
		{
			Fsm fsm = Fsm;
			if (fsm.ControllerCollider != null)
			{
				GameObject gameObject = fsm.ControllerCollider.gameObject;
				gameObjectHit.Value = gameObject;
				Fsm fsm2 = Fsm;
				FsmVector3 fsmVector = contactPoint;
				Vector3 vector = (fsmVector.value = fsm2.ControllerCollider.point);
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
				Fsm fsm3 = Fsm;
				FsmVector3 fsmVector2 = contactNormal;
				Vector3 vector2 = (fsmVector2.value = fsm3.ControllerCollider.normal);
				fsmVector2.value.y = vector2.y;
				fsmVector2.value.z = vector2.z;
				Fsm fsm4 = Fsm;
				FsmVector3 fsmVector3 = moveDirection;
				Vector3 vector3 = (fsmVector3.value = fsm4.ControllerCollider.moveDirection);
				fsmVector3.value.y = vector3.y;
				fsmVector3.value.z = vector3.z;
				Fsm fsm5 = Fsm;
				FsmFloat fsmFloat = moveLength;
				float value = fsm5.ControllerCollider.moveLength;
				fsmFloat.Value = value;
				Fsm fsm6 = Fsm;
				FsmString fsmString = physicsMaterialName;
				Collider collider = fsm6.ControllerCollider.collider;
				PhysicMaterial material = collider.material;
				string value2 = material.name;
				fsmString.Value = value2;
			}
		}

		[Token(Token = "0x60008D8")]
		[Address(RVA = "0xA2A6F0", Offset = "0xA2A6F0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetControllerHitInfo::StoreTriggerInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreTriggerInfo();
			Finish();
		}

		[Token(Token = "0x60008D9")]
		[Address(RVA = "0xA2A718", Offset = "0xA2A718", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.ActionHelpers::CheckPhysicsSetup(this.owner);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			return ActionHelpers.CheckPhysicsSetup(Owner);
		}

		[Token(Token = "0x60008DA")]
		[Address(RVA = "0xA2A724", Offset = "0xA2A724", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetControllerHitInfo()
		{
		}
	}
}

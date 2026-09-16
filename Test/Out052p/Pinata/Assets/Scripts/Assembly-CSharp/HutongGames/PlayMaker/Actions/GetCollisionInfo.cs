using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759CE8", Offset = "0x759CE8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759CE8", Offset = "0x759CE8")]
	[Token(Token = "0x200029D")]
	public class GetCollisionInfo : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9BC4", Offset = "0x7B9BC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9BC4", Offset = "0x7B9BC4")]
		[Token(Token = "0x400172B")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9C14", Offset = "0x7B9C14")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9C14", Offset = "0x7B9C14")]
		[Token(Token = "0x400172C")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 relativeVelocity;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9C64", Offset = "0x7B9C64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9C64", Offset = "0x7B9C64")]
		[Token(Token = "0x400172D")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat relativeSpeed;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9CB4", Offset = "0x7B9CB4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9CB4", Offset = "0x7B9CB4")]
		[Token(Token = "0x400172E")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 contactPoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9D04", Offset = "0x7B9D04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9D04", Offset = "0x7B9D04")]
		[Token(Token = "0x400172F")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 contactNormal;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9D54", Offset = "0x7B9D54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9D54", Offset = "0x7B9D54")]
		[Token(Token = "0x4001730")]
		[FieldOffset(Offset = "0x78")]
		public FsmString physicsMaterialName;

		[Token(Token = "0x6000D09")]
		[Address(RVA = "0xB846E4", Offset = "0xB846E4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.relativeSpeed = 0;\n\tthis.contactNormal = 0;\n\tthis.gameObjectHit = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			relativeSpeed = null;
			contactNormal = null;
			gameObjectHit = null;
		}

		[Token(Token = "0x6000D0A")]
		[Address(RVA = "0xB846F4", Offset = "0xB846F4", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.fsm;\n\tv17 = v14.<CollisionInfo>k__BackingField == 0;\n\tif (v17) goto L_0098;\n\tv53 = UnityEngine.Collision::get_gameObject(v14.<CollisionInfo>k__BackingField);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v53);\n\tv77 = this.fsm;\n\tv48 = this.relativeSpeed;\n\tv31 = UnityEngine.Collision::get_relativeVelocity(v77.<CollisionInfo>k__BackingField);\n\tv55 = 0x158AD58(&v31 @ V0_v5 (UnityEngine.Vector3), 0, 0, v154, v155, v156, v157, v158, v31, v31.y, v31.z, v159, v160, v161, v162, v163);\n\tv48.value = v31;\n\tv78 = this.fsm;\n\tv49 = this.relativeVelocity;\n\tv31 = UnityEngine.Collision::get_relativeVelocity(v78.<CollisionInfo>k__BackingField);\n\tv49.value = v31;\n\tv49.value.y = v31.y;\n\tv49.value.z = v31.z;\n\tv79 = this.fsm;\n\tv50 = this.physicsMaterialName;\n\tv128 = UnityEngine.Collision::get_collider(v79.<CollisionInfo>k__BackingField);\n\tv129 = UnityEngine.Collider::get_material(v128);\n\tv57 = UnityEngine.Object::get_name(v129);\n\tv50.value = v57;\n\tv80 = this.fsm;\n\tv58 = UnityEngine.Collision::get_contacts(v80.<CollisionInfo>k__BackingField);\n\tv103 = v58 == 0;\n\tif (v103) goto L_0098;\n\tv81 = this.fsm;\n\tv59 = UnityEngine.Collision::get_contacts(v81.<CollisionInfo>k__BackingField);\n\tv104 = v59.Length == 0;\n\tif (v104) goto L_0098;\n\tv82 = this.fsm;\n\tv51 = this.contactPoint;\n\tv133 = UnityEngine.Collision::get_contacts(v82.<CollisionInfo>k__BackingField);\n\tv195 = v133.Length == 0;\n\tif (v195) goto L_009B;\n\tv200 = v133 + 0x20;\n\tv60 = 0x16499F4(v200, 0, 0, v154, v155, v156, v157, v158, v31, v31.y, v31.z, v159, v160, v161, v162, v163);\n\tv51.value = v31;\n\tv51.value.y = v31.y;\n\tv51.value.z = v31.z;\n\tv84 = this.fsm;\n\tv91 = this.contactNormal;\n\tv135 = UnityEngine.Collision::get_contacts(v84.<CollisionInfo>k__BackingField);\n\tv196 = v135.Length == 0;\n\tif (v196) goto L_009B;\n\tv201 = v135 + 0x20;\n\tv61 = 0x1649A00(v201, 0, 0, v154, v155, v156, v157, v158, v31, v31.y, v31.z, v159, v160, v161, v162, v163);\n\tv91.value = v31;\n\tv91.value.y = v31.y;\n\tv91.value.z = v31.z;\nL_0098:\n\treturn;\n\tv153 = new System.NullReferenceException();\nL_009B:\n\tv197 = new System.IndexOutOfRangeException();\n\tthrow v197;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreCollisionInfo()
		{
			//IL_0250: Expected O, but got I
			//IL_02f8: Expected O, but got I
			Fsm fsm = Fsm;
			if (fsm.CollisionInfo == null)
			{
				return;
			}
			GameObject gameObject = fsm.CollisionInfo.gameObject;
			gameObjectHit.Value = gameObject;
			Fsm fsm2 = Fsm;
			FsmFloat fsmFloat = relativeSpeed;
			Vector3 vector = fsm2.CollisionInfo.relativeVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			fsmFloat.Value = vector.x;
			Fsm fsm3 = Fsm;
			FsmVector3 fsmVector = relativeVelocity;
			vector = (fsmVector.value = fsm3.CollisionInfo.relativeVelocity);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			Fsm fsm4 = Fsm;
			FsmString fsmString = physicsMaterialName;
			Collider collider = fsm4.CollisionInfo.collider;
			PhysicMaterial material = collider.material;
			string value = material.name;
			fsmString.Value = value;
			Fsm fsm5 = Fsm;
			ContactPoint[] contacts = fsm5.CollisionInfo.contacts;
			if (contacts == null)
			{
				return;
			}
			Fsm fsm6 = Fsm;
			ContactPoint[] contacts2 = fsm6.CollisionInfo.contacts;
			if (contacts2.Length == 0)
			{
				return;
			}
			Fsm fsm7 = Fsm;
			FsmVector3 fsmVector2 = contactPoint;
			ContactPoint[] contacts3 = fsm7.CollisionInfo.contacts;
			if (contacts3.Length != 0)
			{
				object obj = (long)(IntPtr)contacts3 + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16499F4 (inside UnityEngine.Collision::get_contacts +0x80)");
				fsmVector2.value = vector;
				fsmVector2.value.y = vector.y;
				fsmVector2.value.z = vector.z;
				Fsm fsm8 = Fsm;
				FsmVector3 fsmVector3 = contactNormal;
				ContactPoint[] contacts4 = fsm8.CollisionInfo.contacts;
				if (contacts4.Length != 0)
				{
					object obj2 = (long)(IntPtr)contacts4 + 32L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1649A00 (inside UnityEngine.Collision::get_contacts +0x8C)");
					fsmVector3.value = vector;
					fsmVector3.value.y = vector.y;
					fsmVector3.value.z = vector.z;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000D0B")]
		[Address(RVA = "0xB848C4", Offset = "0xB848C4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetCollisionInfo::StoreCollisionInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreCollisionInfo();
			Finish();
		}

		[Token(Token = "0x6000D0C")]
		[Address(RVA = "0xB848EC", Offset = "0xB848EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetCollisionInfo()
		{
		}
	}
}

using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760110", Offset = "0x760110")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760110", Offset = "0x760110")]
	[Token(Token = "0x20003A3")]
	public class SetRotation : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDF64", Offset = "0x7CDF64")]
		[Token(Token = "0x4001CFA")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CDFB0", Offset = "0x7CDFB0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CDFB0", Offset = "0x7CDFB0")]
		[Token(Token = "0x4001CFB")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion quaternion;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CE000", Offset = "0x7CE000")]
		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7CE000", Offset = "0x7CE000")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE000", Offset = "0x7CE000")]
		[Token(Token = "0x4001CFC")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 vector;

		[Token(Token = "0x4001CFD")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat xAngle;

		[Token(Token = "0x4001CFE")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat yAngle;

		[Token(Token = "0x4001CFF")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat zAngle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE074", Offset = "0x7CE074")]
		[Token(Token = "0x4001D00")]
		[FieldOffset(Offset = "0x80")]
		public Space space;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE0AC", Offset = "0x7CE0AC")]
		[Token(Token = "0x4001D01")]
		[FieldOffset(Offset = "0x84")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CE0E4", Offset = "0x7CE0E4")]
		[Token(Token = "0x4001D02")]
		[FieldOffset(Offset = "0x85")]
		public bool lateUpdate;

		[Token(Token = "0x600121C")]
		[Address(RVA = "0x99922C", Offset = "0x99922C", Length = "0xD0")]
		public override void Reset()
		{
			quaternion = null;
			vector = null;
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			xAngle = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			yAngle = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			zAngle = fsmFloat3;
			space = default(Space);
			everyFrame = false;
			lateUpdate = false;
		}

		[Token(Token = "0x600121D")]
		[Address(RVA = "0x9992FC", Offset = "0x9992FC", Length = "0x2C")]
		public override void OnPreprocess()
		{
			if (lateUpdate)
			{
				Fsm.HandleLateUpdate = true;
			}
		}

		[Token(Token = "0x600121E")]
		[Address(RVA = "0x999328", Offset = "0x999328", Length = "0x48")]
		public override void OnEnter()
		{
			if (!everyFrame && !lateUpdate)
			{
				DoSetRotation();
				Finish();
			}
		}

		[Token(Token = "0x600121F")]
		[Address(RVA = "0x999584", Offset = "0x999584", Length = "0x10")]
		public override void OnUpdate()
		{
			if (!lateUpdate)
			{
				DoSetRotation();
			}
		}

		[Token(Token = "0x6001220")]
		[Address(RVA = "0x999594", Offset = "0x999594", Length = "0x48")]
		public override void OnLateUpdate()
		{
			if (lateUpdate)
			{
				DoSetRotation();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001221")]
		[Address(RVA = "0x999370", Offset = "0x999370", Length = "0x214")]
		private void DoSetRotation()
		{
			//IL_01f5: Expected O, but got F4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			Vector3 vector;
			float y = default(float);
			float z = default(float);
			if (quaternion.IsNone)
			{
				if (this.vector.IsNone)
				{
					Transform transform = ownerDefaultTarget.transform;
					if (space == Space.Self)
					{
						vector = transform.localEulerAngles;
						y = vector.y;
						z = vector.z;
					}
					else
					{
						vector = transform.eulerAngles;
						y = vector.y;
						z = vector.z;
					}
				}
				else
				{
					vector = this.vector.Value;
					y = vector.y;
					z = vector.z;
				}
			}
			else
			{
				FsmQuaternion fsmQuaternion = quaternion;
				Quaternion value = fsmQuaternion.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
				vector = (Vector3)fsmQuaternion.value;
			}
			bool isNone = xAngle.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Vector3 vector2 = vector;
			if (!flag2)
			{
				float value2 = xAngle.Value;
				vector2 = (Vector3)value2;
			}
			bool isNone2 = yAngle.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float y2 = y;
			if (!flag4)
			{
				float value3 = yAngle.Value;
				y2 = value3;
			}
			bool isNone3 = zAngle.IsNone;
			bool flag5 = !isNone3;
			bool flag6 = !flag5;
			float z2 = z;
			if (!flag6)
			{
				float value4 = zAngle.Value;
				z2 = value4;
			}
			Transform transform2 = ownerDefaultTarget.transform;
			if (space == Space.Self)
			{
				Vector3 localEulerAngles = default(Vector3);
				localEulerAngles.x = vector2.x;
				localEulerAngles.y = y2;
				localEulerAngles.z = z2;
				transform2.localEulerAngles = localEulerAngles;
			}
			else
			{
				Vector3 eulerAngles = default(Vector3);
				eulerAngles.x = vector2.x;
				eulerAngles.y = y2;
				eulerAngles.z = z2;
				transform2.eulerAngles = eulerAngles;
			}
		}

		[Token(Token = "0x6001222")]
		[Address(RVA = "0x9995DC", Offset = "0x9995DC", Length = "0x8")]
		public SetRotation()
		{
		}
	}
}

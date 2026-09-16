using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760020", Offset = "0x760020")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760020", Offset = "0x760020")]
	[Token(Token = "0x20003A0")]
	public class Rotate : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDB84", Offset = "0x7CDB84")]
		[Token(Token = "0x4001CE4")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDBD0", Offset = "0x7CDBD0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CDBD0", Offset = "0x7CDBD0")]
		[Token(Token = "0x4001CE5")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDC20", Offset = "0x7CDC20")]
		[Token(Token = "0x4001CE6")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat xAngle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDC58", Offset = "0x7CDC58")]
		[Token(Token = "0x4001CE7")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat yAngle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDC90", Offset = "0x7CDC90")]
		[Token(Token = "0x4001CE8")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat zAngle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDCC8", Offset = "0x7CDCC8")]
		[Token(Token = "0x4001CE9")]
		[FieldOffset(Offset = "0x78")]
		public Space space;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDD00", Offset = "0x7CDD00")]
		[Token(Token = "0x4001CEA")]
		[FieldOffset(Offset = "0x7C")]
		public bool perSecond;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDD38", Offset = "0x7CDD38")]
		[Token(Token = "0x4001CEB")]
		[FieldOffset(Offset = "0x7D")]
		public bool everyFrame;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDD70", Offset = "0x7CDD70")]
		[Token(Token = "0x4001CEC")]
		[FieldOffset(Offset = "0x7E")]
		public bool lateUpdate;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CDDA8", Offset = "0x7CDDA8")]
		[Token(Token = "0x4001CED")]
		[FieldOffset(Offset = "0x7F")]
		public bool fixedUpdate;

		[Token(Token = "0x6001209")]
		[Address(RVA = "0xB2439C", Offset = "0xB2439C", Length = "0xCC")]
		public override void Reset()
		{
			//IL_007a: Expected I4, but got I8
			gameObject = null;
			vector = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			xAngle = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			yAngle = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			zAngle = fsmFloat3;
			space = (Space)257;
		}

		[Token(Token = "0x600120A")]
		[Address(RVA = "0xB24468", Offset = "0xB24468", Length = "0x60")]
		public override void OnPreprocess()
		{
			if (fixedUpdate)
			{
				Fsm.HandleFixedUpdate = true;
			}
			if (lateUpdate)
			{
				Fsm.HandleLateUpdate = true;
			}
		}

		[Token(Token = "0x600120B")]
		[Address(RVA = "0xB244C8", Offset = "0xB244C8", Length = "0x50")]
		public override void OnEnter()
		{
			if (!everyFrame && !lateUpdate && !fixedUpdate)
			{
				DoRotate();
				Finish();
			}
		}

		[Token(Token = "0x600120C")]
		[Address(RVA = "0xB24778", Offset = "0xB24778", Length = "0x18")]
		public override void OnUpdate()
		{
			if (!lateUpdate && !fixedUpdate)
			{
				DoRotate();
			}
		}

		[Token(Token = "0x600120D")]
		[Address(RVA = "0xB24790", Offset = "0xB24790", Length = "0x48")]
		public override void OnLateUpdate()
		{
			if (lateUpdate)
			{
				DoRotate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600120E")]
		[Address(RVA = "0xB247D8", Offset = "0xB247D8", Length = "0x48")]
		public override void OnFixedUpdate()
		{
			if (fixedUpdate)
			{
				DoRotate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600120F")]
		[Address(RVA = "0xB24518", Offset = "0xB24518", Length = "0x260")]
		private void DoRotate()
		{
			//IL_011d: Expected O, but got I
			//IL_008d: Expected O, but got I
			//IL_018e: Expected O, but got F4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				object obj;
				float num;
				Vector3 vector2;
				float num3;
				if (this.vector.IsNone)
				{
					obj = (long)(IntPtr)this + 96L;
					float value = xAngle.Value;
					float value2 = yAngle.Value;
					float value3 = zAngle.Value;
					Vector3 vector = default(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					float num2 = default(float);
					num = num2;
					vector2 = default(Vector3);
					num3 = 0f;
				}
				else
				{
					Vector3 value4 = this.vector.Value;
					obj = (long)(IntPtr)this + 96L;
					num = value4.y;
					vector2 = value4;
					num3 = value4.z;
				}
				if (!((NamedVariable)obj).IsNone)
				{
					float value5 = ((FsmFloat)obj).Value;
					vector2 = (Vector3)value5;
				}
				if (!yAngle.IsNone)
				{
					float value6 = yAngle.Value;
					num = value6;
				}
				if (!zAngle.IsNone)
				{
					float value7 = zAngle.Value;
					num3 = value7;
				}
				Transform transform = ownerDefaultTarget.transform;
				Vector3 vector4;
				float y;
				float z;
				Space relativeTo;
				if (perSecond)
				{
					float deltaTime = Time.deltaTime;
					Vector3 vector3 = default(Vector3);
					vector3.x = vector2.x;
					vector3.y = num;
					vector3.z = num3;
					vector4 = vector3 * deltaTime;
					y = vector4.y;
					z = vector4.z;
					relativeTo = space;
				}
				else
				{
					relativeTo = space;
					y = num;
					z = num3;
					vector4 = vector2;
				}
				Vector3 eulers = default(Vector3);
				eulers.x = vector4.x;
				eulers.y = y;
				eulers.z = z;
				transform.Rotate(eulers, relativeTo);
			}
		}

		[Token(Token = "0x6001210")]
		[Address(RVA = "0xB24820", Offset = "0xB24820", Length = "0x8")]
		public Rotate()
		{
		}
	}
}

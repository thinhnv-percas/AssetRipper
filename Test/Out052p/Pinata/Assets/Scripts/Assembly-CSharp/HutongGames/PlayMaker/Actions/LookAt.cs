using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FF0C", Offset = "0x75FF0C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FF0C", Offset = "0x75FF0C")]
	[Token(Token = "0x200039D")]
	public class LookAt : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD794", Offset = "0x7CD794")]
		[Token(Token = "0x4001CC7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD7E0", Offset = "0x7CD7E0")]
		[Token(Token = "0x4001CC8")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject targetObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD818", Offset = "0x7CD818")]
		[Token(Token = "0x4001CC9")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 targetPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD850", Offset = "0x7CD850")]
		[Token(Token = "0x4001CCA")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 upVector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD888", Offset = "0x7CD888")]
		[Token(Token = "0x4001CCB")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool keepVertical;

		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7CD8C0", Offset = "0x7CD8C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD8C0", Offset = "0x7CD8C0")]
		[Token(Token = "0x4001CCC")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool debug;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD920", Offset = "0x7CD920")]
		[Token(Token = "0x4001CCD")]
		[FieldOffset(Offset = "0x80")]
		public FsmColor debugLineColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD958", Offset = "0x7CD958")]
		[Token(Token = "0x4001CCE")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x4001CCF")]
		[FieldOffset(Offset = "0x90")]
		private GameObject go;

		[Token(Token = "0x4001CD0")]
		[FieldOffset(Offset = "0x98")]
		private GameObject goTarget;

		[Token(Token = "0x4001CD1")]
		[FieldOffset(Offset = "0xA0")]
		private Vector3 lookAtPos;

		[Token(Token = "0x4001CD2")]
		[FieldOffset(Offset = "0xAC")]
		private Vector3 lookAtPosWithVertical;

		[Token(Token = "0x60011F5")]
		[Address(RVA = "0xA3ADB8", Offset = "0xA3ADB8", Length = "0xD8")]
		public override void Reset()
		{
			gameObject = null;
			targetObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			targetPosition = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			upVector = fsmVector2;
			FsmBool fsmBool = true;
			keepVertical = fsmBool;
			FsmBool fsmBool2 = false;
			debug = fsmBool2;
			Color yellow = Color.yellow;
			FsmColor fsmColor = yellow;
			debugLineColor = fsmColor;
			everyFrame = true;
		}

		[Token(Token = "0x60011F6")]
		[Address(RVA = "0xA3AE90", Offset = "0xA3AE90", Length = "0x20")]
		public override void OnPreprocess()
		{
			Fsm.HandleLateUpdate = true;
		}

		[Token(Token = "0x60011F7")]
		[Address(RVA = "0xA3AEB0", Offset = "0xA3AEB0", Length = "0x3C")]
		public override void OnEnter()
		{
			DoLookAt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011F8")]
		[Address(RVA = "0xA3B098", Offset = "0xA3B098", Length = "0x4")]
		public override void OnLateUpdate()
		{
			DoLookAt();
		}

		[Token(Token = "0x60011F9")]
		[Address(RVA = "0xA3AEEC", Offset = "0xA3AEEC", Length = "0x1AC")]
		private void DoLookAt()
		{
			if (UpdateLookAtPosition())
			{
				Transform transform = go.transform;
				Vector3 vector;
				float y;
				float z;
				if (upVector.IsNone)
				{
					vector = Vector3.up;
					y = vector.y;
					z = vector.z;
				}
				else
				{
					vector = upVector.Value;
					y = vector.y;
					z = vector.z;
				}
				Vector3 worldPosition = default(Vector3);
				worldPosition.x = lookAtPos.x;
				worldPosition.y = lookAtPos.y;
				worldPosition.z = lookAtPos.z;
				Vector3 worldUp = default(Vector3);
				worldUp.x = vector.x;
				worldUp.y = y;
				worldUp.z = z;
				transform.LookAt(worldPosition, worldUp);
				if (debug.Value)
				{
					Transform transform2 = go.transform;
					Vector3 position = transform2.position;
					FsmColor fsmColor = debugLineColor;
					Vector3 start = default(Vector3);
					start.x = position.x;
					start.y = position.y;
					start.z = position.z;
					Vector3 end = default(Vector3);
					end.x = lookAtPos.x;
					end.y = lookAtPos.y;
					end.z = lookAtPos.z;
					Debug.DrawLine(start, end, fsmColor.value);
				}
			}
		}

		[Token(Token = "0x60011FA")]
		[Address(RVA = "0xA3B09C", Offset = "0xA3B09C", Length = "0x1F0")]
		public bool UpdateLookAtPosition()
		{
			//IL_0278: Expected I4, but got O
			bool flag = Fsm == null;
			bool result = (byte)(int)Fsm != 0;
			if (!flag)
			{
				if ((go = Fsm.GetOwnerDefaultTarget(gameObject)) == null || ((goTarget = targetObject.Value) == null && targetPosition.IsNone))
				{
					result = false;
				}
				else
				{
					Vector3 vector;
					float y;
					float z;
					if (goTarget != null)
					{
						bool isNone = targetPosition.IsNone;
						Transform transform = goTarget.transform;
						if (isNone)
						{
							vector = transform.position;
							y = vector.y;
							z = vector.z;
						}
						else
						{
							Vector3 value = targetPosition.Value;
							vector = transform.TransformPoint(value);
							y = vector.y;
							z = vector.z;
						}
					}
					else
					{
						vector = targetPosition.Value;
						y = vector.y;
						z = vector.z;
					}
					lookAtPos = vector;
					lookAtPos.y = y;
					lookAtPos.z = z;
					lookAtPosWithVertical = vector;
					lookAtPosWithVertical.y = y;
					lookAtPosWithVertical.z = z;
					if (keepVertical.Value)
					{
						Transform transform2 = go.transform;
						Vector3 position = transform2.position;
						lookAtPos.y = position.y;
					}
					result = true;
				}
			}
			return result;
		}

		[Token(Token = "0x60011FB")]
		[Address(RVA = "0xA3B28C", Offset = "0xA3B28C", Length = "0xC")]
		public Vector3 GetLookAtPosition()
		{
			return lookAtPos;
		}

		[Token(Token = "0x60011FC")]
		[Address(RVA = "0xA3B298", Offset = "0xA3B298", Length = "0xC")]
		public Vector3 GetLookAtPositionWithVertical()
		{
			return lookAtPosWithVertical;
		}

		[Token(Token = "0x60011FD")]
		[Address(RVA = "0xA3B2A4", Offset = "0xA3B2A4", Length = "0x10")]
		public LookAt()
		{
			everyFrame = true;
		}
	}
}

using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FF5C", Offset = "0x75FF5C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x75FF5C", Offset = "0x75FF5C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75FF5C", Offset = "0x75FF5C")]
	[Token(Token = "0x200039E")]
	public class MoveObject : EaseFsmAction
	{
		[RequiredField]
		[Token(Token = "0x4001CD3")]
		[FieldOffset(Offset = "0xC8")]
		public FsmOwnerDefault objectToMove;

		[RequiredField]
		[Token(Token = "0x4001CD4")]
		[FieldOffset(Offset = "0xD0")]
		public FsmGameObject destination;

		[Token(Token = "0x4001CD5")]
		[FieldOffset(Offset = "0xD8")]
		private FsmVector3 fromValue;

		[Token(Token = "0x4001CD6")]
		[FieldOffset(Offset = "0xE0")]
		private FsmVector3 toVector;

		[Token(Token = "0x4001CD7")]
		[FieldOffset(Offset = "0xE8")]
		private FsmVector3 fromVector;

		[Token(Token = "0x4001CD8")]
		[FieldOffset(Offset = "0xF0")]
		private bool finishInNextStep;

		[Token(Token = "0x60011FE")]
		[Address(RVA = "0xA3DA74", Offset = "0xA3DA74", Length = "0x30")]
		public override void Reset()
		{
			base.Reset();
			finishInNextStep = false;
			toVector = null;
			fromVector = null;
			fromValue = null;
		}

		[Token(Token = "0x60011FF")]
		[Address(RVA = "0xA3DAA4", Offset = "0xA3DAA4", Length = "0x284")]
		public override void OnEnter()
		{
			//IL_0164: Expected O, but got I4
			//IL_01ff: Expected O, but got I4
			//IL_0301: Expected O, but got I4
			//IL_039c: Expected O, but got I4
			//IL_049e: Expected O, but got I4
			//IL_0539: Expected O, but got I4
			base.OnEnter();
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(objectToMove);
			Transform transform = ownerDefaultTarget.transform;
			Vector3 position = transform.position;
			FsmVector3 fsmVector = position;
			fromVector = fsmVector;
			GameObject value = destination.Value;
			Transform transform2 = value.transform;
			Vector3 position2 = transform2.position;
			FsmVector3 fsmVector2 = position2;
			toVector = fsmVector2;
			float[] array = (fromFloats = new float[3]);
			Vector3 value2 = fromVector.Value;
			if (array.Length != 0)
			{
				array[0] = value2.x;
				float[] array2 = fromFloats;
				Vector3 value3 = fromVector.Value;
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj = array2.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = value3.y;
					float[] array3 = fromFloats;
					Vector3 value4 = fromVector.Value;
					bool flag5 = array3.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array3.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array3[2] = value4.z;
						float[] array4 = (toFloats = new float[3]);
						Vector3 value5 = toVector.Value;
						if (array4.Length != 0)
						{
							array4[0] = value5.x;
							float[] array5 = toFloats;
							Vector3 value6 = toVector.Value;
							bool flag9 = array5.Length < 1;
							bool flag10 = !flag9;
							object obj3 = array5.Length - 1;
							bool flag11 = obj3 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								array5[1] = value6.y;
								float[] array6 = toFloats;
								Vector3 value7 = toVector.Value;
								bool flag13 = array6.Length < 2;
								bool flag14 = !flag13;
								object obj4 = array6.Length - 2;
								bool flag15 = obj4 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									array6[2] = value7.z;
									float[] array7 = (resultFloats = new float[3]);
									Vector3 value8 = fromVector.Value;
									if (array7.Length != 0)
									{
										array7[0] = value8.x;
										float[] array8 = resultFloats;
										Vector3 value9 = fromVector.Value;
										bool flag17 = array8.Length < 1;
										bool flag18 = !flag17;
										object obj5 = array8.Length - 1;
										bool flag19 = obj5 == null;
										bool flag20 = !flag18;
										if (!(flag20 || flag19))
										{
											array8[1] = value9.y;
											float[] array9 = resultFloats;
											Vector3 value10 = fromVector.Value;
											bool flag21 = array9.Length < 2;
											bool flag22 = !flag21;
											object obj6 = array9.Length - 2;
											bool flag23 = obj6 == null;
											bool flag24 = !flag22;
											if (!(flag24 || flag23))
											{
												array9[2] = value10.z;
												finishInNextStep = false;
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6001200")]
		[Address(RVA = "0xA3DD28", Offset = "0xA3DD28", Length = "0x234")]
		public override void OnUpdate()
		{
			//IL_00ab: Expected O, but got I4
			//IL_00e9: Expected O, but got I4
			//IL_0113: Expected F4, but got O
			//IL_0144: Expected O, but got I4
			//IL_0172: Expected O, but got I4
			//IL_019a: Expected O, but got I4
			//IL_04c2: Expected O, but got I4
			//IL_04ec: Expected F4, but got O
			//IL_0353: Expected O, but got I4
			base.OnUpdate();
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(objectToMove);
			Transform transform = ownerDefaultTarget.transform;
			float[] array = resultFloats;
			object obj3 = default(object);
			FsmVector3 fsmVector3;
			Transform transform4;
			object obj2;
			if (array.Length != 0 && array.Length != 1)
			{
				bool flag = array.Length < 2;
				bool flag2 = !flag;
				object obj = array.Length - 2;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					Vector3 position = default(Vector3);
					position.x = 0f;
					position.y = (float)obj3;
					position.z = 0f;
					transform.position = position;
					bool flag5 = !finishInNextStep;
					object obj4 = 0;
					if (!flag5)
					{
						Finish();
						bool flag6 = finishEvent == null;
						obj4 = 0;
						if (!flag6)
						{
							Fsm.Event(finishEvent);
							obj4 = 0;
						}
					}
					if (!finishAction || finishInNextStep)
					{
						return;
					}
					Transform transform2 = ownerDefaultTarget.transform;
					FsmVector3 fsmVector;
					if (!reverse.IsNone && reverse.Value)
					{
						fsmVector = fromValue;
						if (fromValue == null)
						{
							goto IL_0477;
						}
					}
					else
					{
						fsmVector = toVector;
					}
					Vector3 value = fsmVector.Value;
					FsmVector3 fsmVector2;
					object obj5;
					if (!reverse.IsNone && reverse.Value)
					{
						fsmVector2 = fromValue;
						if (fromValue == null)
						{
							obj5 = 0;
							goto IL_0477;
						}
					}
					else
					{
						fsmVector2 = toVector;
					}
					Vector3 value2 = fsmVector2.Value;
					bool isNone = reverse.IsNone;
					bool flag7 = !isNone;
					bool flag8 = !flag7;
					float y = value2.y;
					Vector3 vector = value;
					Transform transform3 = transform2;
					obj5 = obj4;
					float y2;
					Vector3 vector2;
					if (!flag8)
					{
						bool value3 = reverse.Value;
						bool flag9 = !value3;
						y = value2.y;
						vector = value;
						transform3 = transform2;
						obj5 = obj4;
						if (!flag9)
						{
							fsmVector3 = fromValue;
							bool flag10 = fromValue == null;
							bool flag11 = !flag10;
							y2 = value2.y;
							vector2 = value;
							transform4 = transform2;
							if (!flag11)
							{
								goto IL_0477;
							}
							goto IL_04ac;
						}
					}
					fsmVector3 = toVector;
					y2 = y;
					vector2 = vector;
					transform4 = transform3;
					obj4 = obj5;
					goto IL_04ac;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_04ac:
			Vector3 value4 = fsmVector3.Value;
			obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 position2 = default(Vector3);
			position2.x = 0f;
			position2.y = (float)obj3;
			position2.z = 0f;
			transform4.position = position2;
			finishInNextStep = true;
			return;
			IL_0477:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001201")]
		[Address(RVA = "0xA3DF5C", Offset = "0xA3DF5C", Length = "0x1008")]
		public MoveObject()
		{
		}
	}
}

using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EBE8", Offset = "0x75EBE8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75EBE8", Offset = "0x75EBE8")]
	[Token(Token = "0x2000374")]
	public class SetEventData : FsmStateAction
	{
		[Token(Token = "0x4001BD3")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject setGameObjectData;

		[Token(Token = "0x4001BD4")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt setIntData;

		[Token(Token = "0x4001BD5")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat setFloatData;

		[Token(Token = "0x4001BD6")]
		[FieldOffset(Offset = "0x68")]
		public FsmString setStringData;

		[Token(Token = "0x4001BD7")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setBoolData;

		[Token(Token = "0x4001BD8")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector2 setVector2Data;

		[Token(Token = "0x4001BD9")]
		[FieldOffset(Offset = "0x80")]
		public FsmVector3 setVector3Data;

		[Token(Token = "0x4001BDA")]
		[FieldOffset(Offset = "0x88")]
		public FsmRect setRectData;

		[Token(Token = "0x4001BDB")]
		[FieldOffset(Offset = "0x90")]
		public FsmQuaternion setQuaternionData;

		[Token(Token = "0x4001BDC")]
		[FieldOffset(Offset = "0x98")]
		public FsmColor setColorData;

		[Token(Token = "0x4001BDD")]
		[FieldOffset(Offset = "0xA0")]
		public FsmMaterial setMaterialData;

		[Token(Token = "0x4001BDE")]
		[FieldOffset(Offset = "0xA8")]
		public FsmTexture setTextureData;

		[Token(Token = "0x4001BDF")]
		[FieldOffset(Offset = "0xB0")]
		public FsmObject setObjectData;

		[Token(Token = "0x6001137")]
		[Address(RVA = "0xB2CF90", Offset = "0xB2CF90", Length = "0x274")]
		public override void Reset()
		{
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			setGameObjectData = fsmGameObject;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			setIntData = fsmInt;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			setFloatData = fsmFloat;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = true;
			setStringData = fsmString;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = true;
			setBoolData = fsmBool;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			setVector2Data = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			setVector3Data = fsmVector2;
			FsmRect fsmRect = new FsmRect();
			fsmRect.useVariable = true;
			setRectData = fsmRect;
			FsmQuaternion fsmQuaternion = new FsmQuaternion();
			fsmQuaternion.useVariable = true;
			setQuaternionData = fsmQuaternion;
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = true;
			setColorData = fsmColor;
			FsmMaterial fsmMaterial = new FsmMaterial();
			fsmMaterial.useVariable = true;
			setMaterialData = fsmMaterial;
			FsmTexture fsmTexture = new FsmTexture();
			fsmTexture.useVariable = true;
			setTextureData = fsmTexture;
			FsmObject fsmObject = new FsmObject();
			fsmObject.useVariable = true;
			setObjectData = fsmObject;
		}

		[Token(Token = "0x6001138")]
		[Address(RVA = "0xB2D204", Offset = "0xB2D204", Length = "0x268")]
		public override void OnEnter()
		{
			FsmEventData eventData = Fsm.EventData;
			bool value = setBoolData.Value;
			eventData.BoolData = value;
			FsmEventData eventData2 = Fsm.EventData;
			int value2 = setIntData.Value;
			eventData2.IntData = value2;
			FsmEventData eventData3 = Fsm.EventData;
			float value3 = setFloatData.Value;
			eventData3.FloatData = value3;
			FsmVector2 fsmVector = setVector2Data;
			FsmEventData eventData4 = Fsm.EventData;
			eventData4.Vector2Data = fsmVector.value;
			eventData4.Vector2Data.y = fsmVector.value.y;
			FsmEventData eventData5 = Fsm.EventData;
			Vector3 vector = (eventData5.Vector3Data = setVector3Data.Value);
			eventData5.Vector3Data.y = vector.y;
			eventData5.Vector3Data.z = vector.z;
			FsmEventData eventData6 = Fsm.EventData;
			string value4 = setStringData.Value;
			eventData6.StringData = value4;
			FsmEventData eventData7 = Fsm.EventData;
			GameObject value5 = setGameObjectData.Value;
			eventData7.GameObjectData = value5;
			FsmRect fsmRect = setRectData;
			FsmEventData eventData8 = Fsm.EventData;
			eventData8.RectData.x = fsmRect.value.x;
			eventData8.RectData.y = fsmRect.value.y;
			eventData8.RectData.height = fsmRect.value.height;
			FsmQuaternion fsmQuaternion = setQuaternionData;
			FsmEventData eventData9 = Fsm.EventData;
			eventData9.QuaternionData.x = fsmQuaternion.value.x;
			eventData9.QuaternionData.y = fsmQuaternion.value.y;
			eventData9.QuaternionData.w = fsmQuaternion.value.w;
			FsmColor fsmColor = setColorData;
			FsmEventData eventData10 = Fsm.EventData;
			eventData10.ColorData.r = fsmColor.value.r;
			eventData10.ColorData.g = fsmColor.value.g;
			eventData10.ColorData.a = fsmColor.value.a;
			FsmEventData eventData11 = Fsm.EventData;
			Material value6 = setMaterialData.Value;
			eventData11.MaterialData = value6;
			FsmEventData eventData12 = Fsm.EventData;
			Texture value7 = setTextureData.Value;
			eventData12.TextureData = value7;
			FsmEventData eventData13 = Fsm.EventData;
			Object value8 = setObjectData.Value;
			eventData13.ObjectData = value8;
			Finish();
		}

		[Token(Token = "0x6001139")]
		[Address(RVA = "0xB2D46C", Offset = "0xB2D46C", Length = "0x8")]
		public SetEventData()
		{
		}
	}
}

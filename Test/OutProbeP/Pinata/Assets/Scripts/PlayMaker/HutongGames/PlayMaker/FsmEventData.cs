using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200004E")]
	public class FsmEventData
	{
		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x10")]
		public GameObject SentByGameObject;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x18")]
		public Fsm SentByFsm;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x20")]
		public FsmState SentByState;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x28")]
		public FsmStateAction SentByAction;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x30")]
		public bool BoolData;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x34")]
		public int IntData;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x38")]
		public float FloatData;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x3C")]
		public Vector2 Vector2Data;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x44")]
		public Vector3 Vector3Data;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x50")]
		public string StringData;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x58")]
		public Quaternion QuaternionData;

		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x68")]
		public Rect RectData;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x78")]
		public Color ColorData;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x88")]
		public UnityEngine.Object ObjectData;

		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x90")]
		public GameObject GameObjectData;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x98")]
		public Material MaterialData;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0xA0")]
		public Texture TextureData;

		[Token(Token = "0x6000169")]
		[Address(RVA = "0xCAB824", Offset = "0xCAB824", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEventData()
		{
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0xCAB82C", Offset = "0xCAB82C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.SentByGameObject = source.SentByGameObject;\n\tthis.SentByFsm = source.SentByFsm;\n\tthis.SentByState = source.SentByState;\n\tthis.SentByAction = source.SentByAction;\n\tthis.BoolData = source.BoolData;\n\tthis.IntData = source.IntData;\n\tthis.FloatData = source.FloatData;\n\tthis.Vector2Data = source.Vector2Data;\n\tthis.Vector2Data.y = source.Vector2Data.y;\n\tthis.Vector3Data = source.Vector3Data;\n\tthis.Vector3Data.z = source.Vector3Data.z;\n\tthis.StringData = source.StringData;\n\tthis.QuaternionData.x = source.QuaternionData;\n\tthis.QuaternionData.y = source.QuaternionData.y;\n\tthis.QuaternionData.w = source.QuaternionData.w;\n\tthis.RectData.m_XMin = source.RectData;\n\tthis.RectData.m_YMin = source.RectData.m_YMin;\n\tthis.RectData.m_Height = source.RectData.m_Height;\n\tthis.ColorData.r = source.ColorData;\n\tthis.ColorData.g = source.ColorData.g;\n\tthis.ColorData.a = source.ColorData.a;\n\tthis.ObjectData = source.ObjectData;\n\tthis.GameObjectData = source.GameObjectData;\n\tthis.MaterialData = source.MaterialData;\n\tthis.TextureData = source.TextureData;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEventData(FsmEventData source)
		{
			SentByGameObject = source.SentByGameObject;
			SentByFsm = source.SentByFsm;
			SentByState = source.SentByState;
			SentByAction = source.SentByAction;
			BoolData = source.BoolData;
			IntData = source.IntData;
			FloatData = source.FloatData;
			Vector2Data = source.Vector2Data;
			Vector2Data.y = source.Vector2Data.y;
			Vector3Data = source.Vector3Data;
			Vector3Data.z = source.Vector3Data.z;
			StringData = source.StringData;
			QuaternionData.x = source.QuaternionData.x;
			QuaternionData.y = source.QuaternionData.y;
			QuaternionData.w = source.QuaternionData.w;
			RectData.x = source.RectData.x;
			RectData.y = source.RectData.y;
			RectData.height = source.RectData.height;
			ColorData.r = source.ColorData.r;
			ColorData.g = source.ColorData.g;
			ColorData.a = source.ColorData.a;
			ObjectData = source.ObjectData;
			GameObjectData = source.GameObjectData;
			MaterialData = source.MaterialData;
			TextureData = source.TextureData;
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0xCAB920", Offset = "0xCAB920", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv22 = *([1ECCCF8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20235CE]) = v42;\nL_0024:\n\tv58 = this.SentByFsm + 0x30;\n\tv59 = this.SentByFsm != 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_002D;\nL_002D:\n\tv65 = System.String::Concat(\"Sent By FSM: \", *([v62 @ X8_v4 (System.String)]));\n\tgoto L_003E;\n\tv73 = *([v69 @ X8_v5+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_003E;\n\tv82 = v69;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v82, v63, v64, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003E:\n\tUnityEngine.Debug::Log(v65);\n\tv97 = this.SentByState + 0x40;\n\tv98 = this.SentByState != 0;\n\tif (v98) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\tv103 = System.String::Concat(\"Sent By State: \", *([v101 @ X8_v7 (System.String)]));\n\tgoto L_0064;\n\tv109 = *([v104 @ X8_v8+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tgoto L_0064;\n\tv118 = v104;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v118, v102, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0064:\n\tUnityEngine.Debug::Log(v103);\n\tv123 = this.SentByAction == 0;\n\tif (v123) goto L_FFFFFFFF;\n\tv125 = System.Object::GetType(this.SentByAction);\n\tv133 = System.Reflection.MemberInfo::get_Name(v125);\n\tgoto L_0078;\nL_0078:\n\tv139 = System.String::Concat(\"Sent By Action: \", v128);\n\tgoto L_008E;\n\tv147 = *([v142 @ X8_v12+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tgoto L_008E;\n\tv174 = v142;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v174, v128, v138, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008E:\n\tUnityEngine.Debug::Log(v139);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DebugLog()
		{
			//IL_00f6: Expected O, but got I
			//IL_003a: Expected O, but got I
			string text = (string)((long)(IntPtr)SentByFsm + 48L);
			string text2 = ((SentByFsm != null) ? text : "None");
			string message = "Sent By FSM: " + text2;
			Debug.Log(message);
			string text3 = (string)((long)(IntPtr)SentByState + 64L);
			string text4 = ((SentByState != null) ? text3 : "None");
			string message2 = "Sent By State: " + text4;
			Debug.Log(message2);
			string text5;
			if (SentByAction != null)
			{
				Type type = SentByAction.GetType();
				string name = type.Name;
				text5 = name;
			}
			else
			{
				text5 = "None";
			}
			string message3 = "Sent By Action: " + text5;
			Debug.Log(message3);
		}
	}
}

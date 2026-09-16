using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D8A0", Offset = "0x75D8A0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D8A0", Offset = "0x75D8A0")]
	[Token(Token = "0x2000350")]
	public class GetEventInfo : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9698", Offset = "0x7C9698")]
		[Token(Token = "0x4001B10")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject sentByGameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C96AC", Offset = "0x7C96AC")]
		[Token(Token = "0x4001B11")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C96C0", Offset = "0x7C96C0")]
		[Token(Token = "0x4001B12")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool getBoolData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C96D4", Offset = "0x7C96D4")]
		[Token(Token = "0x4001B13")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt getIntData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C96E8", Offset = "0x7C96E8")]
		[Token(Token = "0x4001B14")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat getFloatData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C96FC", Offset = "0x7C96FC")]
		[Token(Token = "0x4001B15")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector2 getVector2Data;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9710", Offset = "0x7C9710")]
		[Token(Token = "0x4001B16")]
		[FieldOffset(Offset = "0x80")]
		public FsmVector3 getVector3Data;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9724", Offset = "0x7C9724")]
		[Token(Token = "0x4001B17")]
		[FieldOffset(Offset = "0x88")]
		public FsmString getStringData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9738", Offset = "0x7C9738")]
		[Token(Token = "0x4001B18")]
		[FieldOffset(Offset = "0x90")]
		public FsmGameObject getGameObjectData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C974C", Offset = "0x7C974C")]
		[Token(Token = "0x4001B19")]
		[FieldOffset(Offset = "0x98")]
		public FsmRect getRectData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9760", Offset = "0x7C9760")]
		[Token(Token = "0x4001B1A")]
		[FieldOffset(Offset = "0xA0")]
		public FsmQuaternion getQuaternionData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9774", Offset = "0x7C9774")]
		[Token(Token = "0x4001B1B")]
		[FieldOffset(Offset = "0xA8")]
		public FsmMaterial getMaterialData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9788", Offset = "0x7C9788")]
		[Token(Token = "0x4001B1C")]
		[FieldOffset(Offset = "0xB0")]
		public FsmTexture getTextureData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C979C", Offset = "0x7C979C")]
		[Token(Token = "0x4001B1D")]
		[FieldOffset(Offset = "0xB8")]
		public FsmColor getColorData;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C97B0", Offset = "0x7C97B0")]
		[Token(Token = "0x4001B1E")]
		[FieldOffset(Offset = "0xC0")]
		public FsmObject getObjectData;

		[Token(Token = "0x6001089")]
		[Address(RVA = "0xA2B0B4", Offset = "0xA2B0B4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this + 0x50;\n\tv10 = 0x6D26F0(v6, 0, 0x78, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 80L;
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x600108A")]
		[Address(RVA = "0xA2B0D4", Offset = "0xA2B0D4", Length = "0x3B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED60A0]);\n\tv21 = *([v20 @ X8_v68]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DB2]) = v40;\nL_001A:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = HutongGames.PlayMaker.Fsm;\nL_0022:\n\tv55 = v54.EventData;\n\tgoto L_0035;\n\tv186 = *([v61 @ X0_v8+E0]);\n\tv187 = v186 == 0;\n\tv188 = ~v187;\n\tif (v188) goto L_0035;\n\tv190 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0035:\n\tv194 = UnityEngine.Object::op_Inequality(v55.SentByGameObject, 0);\n\tv212 = v194 == 0;\n\tif (v212) goto L_0054;\n\tgoto L_0046;\n\tv243 = *([v213 @ X0_v31 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv244 = v243 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_0046;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v213, v91, v83, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv246 = HutongGames.PlayMaker.Fsm;\nL_0046:\n\tv162 = v249.EventData;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.sentByGameObject, v162.SentByGameObject);\n\tgoto L_0098;\nL_0054:\n\tgoto L_005C;\n\tv250 = *([v217 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\tif (v252) goto L_005C;\n\tv258 = \"il2cpp_codegen_runtime_class_init\"(v217, v91, v83, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv253 = HutongGames.PlayMaker.Fsm;\nL_005C:\n\tv164 = v256.EventData;\n\tv259 = v164.SentByFsm == 0;\n\tif (v259) goto L_008F;\n\tgoto L_0075;\n\tv99 = *([v121 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv266 = v99 == 0;\n\tv267 = ~v266;\n\t// 106 ConditionalJump @b29, v267 @ TEMP_v63 (System.Boolean)\n\tv288 = HutongGames.PlayMaker.Fsm;\n\tv289 = *([v288 @ X8_v55 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv163 = v289.EventData;\nL_0075:\n\tv119 = HutongGames.PlayMaker.Fsm::get_GameObject(v164.SentByFsm);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.sentByGameObject, v119);\n\tv165 = v296.EventData;\n\tv166 = v165.SentByFsm;\n\tv101 = this.fsmName;\n\tv101.value = v166.name;\n\tgoto L_0098;\nL_008F:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.sentByGameObject, 0);\n\tv168 = this.fsmName;\n\tv168.value = \"\";\nL_0098:\n\tv184 = this.getBoolData;\n\tgoto L_00A4;\n\tv281 = *([v276 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tgoto L_00A4;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v276, v94, v86, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv284 = HutongGames.PlayMaker.Fsm;\nL_00A4:\n\tv169 = v287.EventData;\n\tv184.value = v169.BoolData;\n\tv170 = v294.EventData;\n\tv104 = this.getIntData;\n\tv104.value = v170.IntData;\n\tv171 = v298.EventData;\n\tv105 = this.getFloatData;\n\tv105.value = v171.FloatData;\n\tv172 = v300.EventData;\n\tv106 = this.getVector2Data;\n\tv106.value = v172.Vector2Data;\n\tv106.value.y = v172.Vector2Data.y;\n\tv173 = v302.EventData;\n\tv107 = this.getVector3Data;\n\tv107.value = v173.Vector3Data;\n\tv107.value.z = v173.Vector3Data.z;\n\tv174 = v304.EventData;\n\tv108 = this.getStringData;\n\tv108.value = v174.StringData;\n\tv175 = v306.EventData;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.getGameObjectData, v175.GameObjectData);\n\tv109 = v307.EventData;\n\tv79 = this.getRectData;\n\tv79.value.m_XMin = v109.RectData;\n\tv79.value.m_YMin = v109.RectData.m_YMin;\n\tv79.value.m_Height = v109.RectData.m_Height;\n\tv110 = v309.EventData;\n\tv80 = this.getQuaternionData;\n\tv80.value.x = v110.QuaternionData;\n\tv80.value.y = v110.QuaternionData.y;\n\tv80.value.w = v110.QuaternionData.w;\n\tv177 = v310.EventData;\n\tHutongGames.PlayMaker.FsmMaterial::set_Value(this.getMaterialData, v177.MaterialData);\n\tv178 = v312.EventData;\n\tHutongGames.PlayMaker.FsmTexture::set_Value(this.getTextureData, v178.TextureData);\n\tv112 = v313.EventData;\n\tv81 = this.getColorData;\n\tv81.value.r = v112.ColorData;\n\tv81.value.g = v112.ColorData.g;\n\tv81.value.a = v112.ColorData.a;\n\tv180 = v314.EventData;\n\tv114 = this.getObjectData;\n\tv114.value = v180.ObjectData;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmEventData eventData = Fsm.EventData;
			if (!(eventData.SentByGameObject != null))
			{
				FsmEventData eventData2 = Fsm.EventData;
				if (eventData2.SentByFsm != null)
				{
					GameObject gameObject = eventData2.SentByFsm.GameObject;
					sentByGameObject.Value = gameObject;
					FsmEventData eventData3 = Fsm.EventData;
					Fsm sentByFsm = eventData3.SentByFsm;
					FsmString fsmString = fsmName;
					fsmString.Value = sentByFsm.Name;
				}
				else
				{
					sentByGameObject.Value = null;
					FsmString fsmString2 = fsmName;
					fsmString2.Value = "";
				}
			}
			else
			{
				FsmEventData eventData4 = Fsm.EventData;
				sentByGameObject.Value = eventData4.SentByGameObject;
			}
			FsmBool fsmBool = getBoolData;
			FsmEventData eventData5 = Fsm.EventData;
			fsmBool.value = eventData5.BoolData;
			FsmEventData eventData6 = Fsm.EventData;
			FsmInt fsmInt = getIntData;
			fsmInt.Value = eventData6.IntData;
			FsmEventData eventData7 = Fsm.EventData;
			FsmFloat fsmFloat = getFloatData;
			fsmFloat.Value = eventData7.FloatData;
			FsmEventData eventData8 = Fsm.EventData;
			FsmVector2 fsmVector = getVector2Data;
			fsmVector.value = eventData8.Vector2Data;
			fsmVector.value.y = eventData8.Vector2Data.y;
			FsmEventData eventData9 = Fsm.EventData;
			FsmVector3 fsmVector2 = getVector3Data;
			fsmVector2.value = eventData9.Vector3Data;
			fsmVector2.value.z = eventData9.Vector3Data.z;
			FsmEventData eventData10 = Fsm.EventData;
			FsmString fsmString3 = getStringData;
			fsmString3.Value = eventData10.StringData;
			FsmEventData eventData11 = Fsm.EventData;
			getGameObjectData.Value = eventData11.GameObjectData;
			FsmEventData eventData12 = Fsm.EventData;
			FsmRect fsmRect = getRectData;
			fsmRect.value.x = eventData12.RectData.x;
			fsmRect.value.y = eventData12.RectData.y;
			fsmRect.value.height = eventData12.RectData.height;
			FsmEventData eventData13 = Fsm.EventData;
			FsmQuaternion fsmQuaternion = getQuaternionData;
			fsmQuaternion.value.x = eventData13.QuaternionData.x;
			fsmQuaternion.value.y = eventData13.QuaternionData.y;
			fsmQuaternion.value.w = eventData13.QuaternionData.w;
			FsmEventData eventData14 = Fsm.EventData;
			getMaterialData.Value = eventData14.MaterialData;
			FsmEventData eventData15 = Fsm.EventData;
			getTextureData.Value = eventData15.TextureData;
			FsmEventData eventData16 = Fsm.EventData;
			FsmColor fsmColor = getColorData;
			fsmColor.value.r = eventData16.ColorData.r;
			fsmColor.value.g = eventData16.ColorData.g;
			fsmColor.value.a = eventData16.ColorData.a;
			FsmEventData eventData17 = Fsm.EventData;
			FsmObject fsmObject = getObjectData;
			fsmObject.Value = eventData17.ObjectData;
			Finish();
		}

		[Token(Token = "0x600108B")]
		[Address(RVA = "0xA2B484", Offset = "0xA2B484", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetEventInfo()
		{
		}
	}
}

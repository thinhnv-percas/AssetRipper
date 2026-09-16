using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000050")]
	public class FsmProperty
	{
		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x10")]
		public FsmObject TargetObject;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x18")]
		public string TargetTypeName;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x20")]
		public Type TargetType;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x28")]
		public string PropertyName;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x30")]
		public Type PropertyType;

		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x38")]
		public FsmBool BoolParameter;

		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x40")]
		public FsmFloat FloatParameter;

		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x48")]
		public FsmInt IntParameter;

		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject GameObjectParameter;

		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString StringParameter;

		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 Vector2Parameter;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 Vector3Parameter;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x70")]
		public FsmRect RectParamater;

		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x78")]
		public FsmQuaternion QuaternionParameter;

		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x80")]
		public FsmObject ObjectParameter;

		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x88")]
		public FsmMaterial MaterialParameter;

		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x90")]
		public FsmTexture TextureParameter;

		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x98")]
		public FsmColor ColorParameter;

		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEnum EnumParameter;

		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0xA8")]
		public FsmArray ArrayParameter;

		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0xB0")]
		public bool setProperty;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0xB1")]
		private bool initialized;

		[NonSerialized]
		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0xB8")]
		private UnityEngine.Object targetObjectCached;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0xC0")]
		private MemberInfo[] memberInfo;

		[Token(Token = "0x6000177")]
		[Address(RVA = "0xCAFBB4", Offset = "0xCAFBB4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF7FC0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023619]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42);\n\tthis.TargetObject = v42;\n\tthis.TargetTypeName = \"\";\n\tthis.PropertyName = \"\";\n\tSystem.Object::.ctor(this);\n\tHutongGames.PlayMaker.FsmProperty::ResetParameters(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmProperty()
		{
			FsmObject targetObject = (FsmObject)new NamedVariable();
			TargetObject = targetObject;
			TargetTypeName = "";
			PropertyName = "";
			ResetParameters();
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0xCAFE24", Offset = "0xCAFE24", Length = "0x340")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC9F60]);\n\tv27 = *([v26 @ X8_v47]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, source, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202361A]) = v45;\nL_001A:\n\tv49 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v49);\n\tthis.TargetObject = v49;\n\tthis.TargetTypeName = \"\";\n\tthis.PropertyName = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.setProperty = source.setProperty;\n\tv61 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v61, source.TargetObject);\n\tthis.TargetObject = v61;\n\tthis.TargetTypeName = source.TargetTypeName;\n\tthis.TargetType = source.TargetType;\n\tthis.PropertyName = source.PropertyName;\n\tthis.PropertyType = source.PropertyType;\n\tv73 = source.BoolParameter;\n\tv74 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v74, source.BoolParameter);\n\tv104 = source.BoolParameter == 0;\n\tif (v104) goto L_0047;\n\tv74.value = *([v73 @ X21_v4 (HutongGames.PlayMaker.NamedVariable)+38]);\nL_0047:\n\tthis.BoolParameter = v74;\n\tv109 = source.FloatParameter;\n\tv111 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v111, source.FloatParameter);\n\tv115 = source.FloatParameter == 0;\n\tif (v115) goto L_0055;\n\tv111.value = *([v109 @ X21_v5 (HutongGames.PlayMaker.NamedVariable)+38]);\nL_0055:\n\tthis.FloatParameter = v111;\n\tv120 = source.IntParameter;\n\tv122 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v122, source.IntParameter);\n\tv126 = source.IntParameter == 0;\n\tif (v126) goto L_0063;\n\tv122.value = *([v120 @ X21_v6 (HutongGames.PlayMaker.NamedVariable)+38]);\nL_0063:\n\tthis.IntParameter = v122;\n\tv131 = source.GameObjectParameter;\n\tv133 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v133, source.GameObjectParameter);\n\tv90 = source.GameObjectParameter == 0;\n\tif (v90) goto L_0071;\n\tv133.value = *([v131 @ X21_v7 (HutongGames.PlayMaker.NamedVariable)+40]);\nL_0071:\n\tthis.GameObjectParameter = v133;\n\tv143 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v143, source.StringParameter);\n\tthis.StringParameter = v143;\n\tv150 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v150, source.Vector2Parameter);\n\tthis.Vector2Parameter = v150;\n\tv158 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v158, source.Vector3Parameter);\n\tthis.Vector3Parameter = v158;\n\tv165 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v165, source.RectParamater);\n\tthis.RectParamater = v165;\n\tv172 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v172, source.QuaternionParameter);\n\tthis.QuaternionParameter = v172;\n\tv177 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v177, source.ObjectParameter);\n\tthis.ObjectParameter = v177;\n\tv184 = new HutongGames.PlayMaker.FsmMaterial();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v184, source.MaterialParameter);\n\tthis.MaterialParameter = v184;\n\tv191 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v191, source.TextureParameter);\n\tthis.TextureParameter = v191;\n\tv198 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v198, source.ColorParameter);\n\tthis.ColorParameter = v198;\n\tv205 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v205, source.EnumParameter);\n\tthis.EnumParameter = v205;\n\tv88 = new HutongGames.PlayMaker.FsmArray();\n\tHutongGames.PlayMaker.FsmArray::.ctor(v88, source.ArrayParameter);\n\tthis.ArrayParameter = v88;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmProperty(FsmProperty source)
		{
			//IL_00ee: Expected F4, but got I
			//IL_0122: Expected O, but got I
			base._002Ector();
			FsmObject targetObject = (FsmObject)new NamedVariable();
			TargetObject = targetObject;
			TargetTypeName = "";
			PropertyName = "";
			setProperty = source.setProperty;
			FsmObject targetObject2 = new FsmObject(source.TargetObject);
			TargetObject = targetObject2;
			TargetTypeName = source.TargetTypeName;
			TargetType = source.TargetType;
			PropertyName = source.PropertyName;
			PropertyType = source.PropertyType;
			NamedVariable boolParameter = source.BoolParameter;
			FsmBool fsmBool = (FsmBool)new NamedVariable(source.BoolParameter);
			if (source.BoolParameter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X21_v4 (HutongGames.PlayMaker.NamedVariable)+38]");
				fsmBool.value = false;
			}
			BoolParameter = fsmBool;
			NamedVariable floatParameter = source.FloatParameter;
			FsmFloat fsmFloat = (FsmFloat)new NamedVariable(source.FloatParameter);
			if (source.FloatParameter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X21_v5 (HutongGames.PlayMaker.NamedVariable)+38]");
				fsmFloat.Value = 0f;
			}
			FloatParameter = fsmFloat;
			NamedVariable intParameter = source.IntParameter;
			FsmInt fsmInt = (FsmInt)new NamedVariable(source.IntParameter);
			if (source.IntParameter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X21_v6 (HutongGames.PlayMaker.NamedVariable)+38]");
				fsmInt.Value = 0;
			}
			IntParameter = fsmInt;
			NamedVariable gameObjectParameter = source.GameObjectParameter;
			FsmGameObject fsmGameObject = (FsmGameObject)new NamedVariable(source.GameObjectParameter);
			if (source.GameObjectParameter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X21_v7 (HutongGames.PlayMaker.NamedVariable)+40]");
				fsmGameObject.value = (GameObject)0;
			}
			GameObjectParameter = fsmGameObject;
			FsmString stringParameter = new FsmString(source.StringParameter);
			StringParameter = stringParameter;
			FsmVector2 vector2Parameter = new FsmVector2(source.Vector2Parameter);
			Vector2Parameter = vector2Parameter;
			FsmVector3 vector3Parameter = new FsmVector3(source.Vector3Parameter);
			Vector3Parameter = vector3Parameter;
			FsmRect rectParamater = new FsmRect(source.RectParamater);
			RectParamater = rectParamater;
			FsmQuaternion quaternionParameter = new FsmQuaternion(source.QuaternionParameter);
			QuaternionParameter = quaternionParameter;
			FsmObject objectParameter = new FsmObject(source.ObjectParameter);
			ObjectParameter = objectParameter;
			FsmMaterial materialParameter = (FsmMaterial)new FsmObject(source.MaterialParameter);
			MaterialParameter = materialParameter;
			FsmTexture textureParameter = (FsmTexture)new FsmObject(source.TextureParameter);
			TextureParameter = textureParameter;
			FsmColor colorParameter = new FsmColor(source.ColorParameter);
			ColorParameter = colorParameter;
			FsmEnum enumParameter = new FsmEnum(source.EnumParameter);
			EnumParameter = enumParameter;
			FsmArray arrayParameter = new FsmArray(source.ArrayParameter);
			ArrayParameter = arrayParameter;
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0xCB01F0", Offset = "0xCB01F0", Length = "0x4C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB6658]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, variable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202361B]) = v41;\nL_0015:\n\tv42 = variable == 0;\n\tif (v42) goto L_0047;\n\tv43 = variable->klass;\n\tv46 = variable->klass->vtable[22];\n\tv47 = HutongGames.PlayMaker.NamedVariable::get_VariableType(variable);\n\tv48 = v47 + 1;\n\tv49 = v48 < 0xF;\n\tv50 = ~v49;\n\tv51 = v48 - 0xF;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_0289;\n\tv67 = 0x181A000 + 0x8C0;\n\tv69 = *([v67 @ X9_v3 (System.Int32)+v48 @ X8_v4 (System.Int32)*4]) + v67;\n\t// 45 IndirectJump v69 @ X8_v10, v47 @ X0_v4 (HutongGames.PlayMaker.VariableType), v47 @ X0_v4 (HutongGames.PlayMaker.VariableType), v46 @ X1_v1, methodInfo @ X2 (Il2CppMethodInfo), v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tX8 = *([1ED98E0]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0145;\n\tX8 = 0;\n\tgoto L_0158;\nL_0047:\n\tHutongGames.PlayMaker.FsmProperty::ResetParameters(this);\n\treturn;\n\tX8 = *([1ECE5A0]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_015A;\n\tX8 = 0;\n\tgoto L_016D;\n\tX8 = *([1F0E6C0]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_016F;\n\tX8 = 0;\n\tgoto L_0182;\n\tX8 = *([1EA73B8]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0184;\n\tX8 = 0;\n\tgoto L_0197;\n\tX8 = *([1ED01C0]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0199;\n\tX8 = 0;\n\tgoto L_01AC;\n\tX8 = *([1EC9AF0]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_01AE;\n\tX8 = 0;\n\tgoto L_01C1;\n\tX8 = *([1EDC658]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_01C3;\n\tX8 = 0;\n\tgoto L_01D6;\n\tX8 = *([1EDA758]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_01D8;\n\tX8 = 0;\n\tgoto L_01EB;\n\tX8 = *([1EC7C68]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_01ED;\n\tX8 = 0;\n\tgoto L_0200;\n\tX8 = *([1F0A440]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0202;\n\tX8 = 0;\n\tgoto L_0215;\n\tX8 = *([1EF30E8]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0217;\n\tX8 = 0;\n\tgoto L_022A;\n\tX8 = *([1EECE08]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_022C;\n\tX8 = 0;\n\tgoto L_023F;\n\tX8 = *([1EF1608]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0241;\n\tX8 = 0;\n\tgoto L_0254;\n\tX8 = *([1EC1C20]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0256;\n\tX8 = 0;\n\tgoto L_0269;\n\tX8 = *([1EA9A60]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_026B;\n\tX8 = 0;\n\tgoto L_027E;\nL_0145:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0156;\n\tX8 = X20;\n\tgoto L_0157;\nL_0156:\n\tX8 = 0;\nL_0157:\n\t;\nL_0158:\n\t*([X19+40]) = X8;\n\tgoto L_027F;\nL_015A:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_016B;\n\tX8 = X20;\n\tgoto L_016C;\nL_016B:\n\tX8 = 0;\nL_016C:\n\t;\nL_016D:\n\t*([X19+48]) = X8;\n\tgoto L_027F;\nL_016F:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0180;\n\tX8 = X20;\n\tgoto L_0181;\nL_0180:\n\tX8 = 0;\nL_0181:\n\t;\nL_0182:\n\t*([X19+38]) = X8;\n\tgoto L_027F;\nL_0184:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0195;\n\tX8 = X20;\n\tgoto L_0196;\nL_0195:\n\tX8 = 0;\nL_0196:\n\t;\nL_0197:\n\t*([X19+50]) = X8;\n\tgoto L_027F;\nL_0199:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_01AA;\n\tX8 = X20;\n\tgoto L_01AB;\nL_01AA:\n\tX8 = 0;\nL_01AB:\n\t;\nL_01AC:\n\t*([X19+58]) = X8;\n\tgoto L_027F;\nL_01AE:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_01BF;\n\tX8 = X20;\n\tgoto L_01C0;\nL_01BF:\n\tX8 = 0;\nL_01C0:\n\t;\nL_01C1:\n\t*([X19+60]) = X8;\n\tgoto L_027F;\nL_01C3:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_01D4;\n\tX8 = X20;\n\tgoto L_01D5;\n// ... 192 further instructions omitted\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetVariable(NamedVariable variable)
		{
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_00b9: Expected O, but got I
			if (variable != null)
			{
				IntPtr intPtr = (IntPtr)variable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+298]");
				object obj = 0;
				VariableType variableType = variable.VariableType;
				int num = (int)(variableType + 1);
				bool flag = num < 15;
				bool flag2 = !flag;
				int num2 = num - 15;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				int num3 = 25272320 + 2240;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X9_v3 (System.Int32)+v48 @ X8_v4 (System.Int32)*4]");
				object obj2 = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v69 @ X8_v10 (should have been resolved before IL gen)");
			}
			ResetParameters();
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0xCB06B4", Offset = "0xCB06B4", Length = "0x4F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE31E8]);\n\tv23 = *([v22 @ X8_v71]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202361C]) = v42;\nL_0016:\n\tHutongGames.PlayMaker.FsmProperty::CheckForReinitialize(this);\n\tv45 = this.PropertyType == 0;\n\tif (v45) goto L_FFFFFFFF;\n\tgoto L_002B;\n\tv98 = *([v49 @ X0_v6+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002B:\n\tv107 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv255 = System.Type::IsAssignableFrom(this.PropertyType, v107);\n\tv208 = v255 == 0;\n\tif (v208) goto L_003F;\n\tgoto L_01B9;\nL_003F:\n\tgoto L_0047;\n\tv299 = *([v294 @ X0_v12+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tif (v301) goto L_0047;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v294, v150, v141, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0047:\n\tv308 = System.Type::GetTypeFromHandle(System.Int32);\n\tv311 = System.Type::IsAssignableFrom(this.PropertyType, v308);\n\tv209 = v311 == 0;\n\tif (v209) goto L_005D;\n\tgoto L_01B9;\nL_005D:\n\tgoto L_0065;\n\tv368 = *([v359 @ X0_v22+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_0065;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v359, v151, v142, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0065:\n\tv333 = System.Type::GetTypeFromHandle(System.Single);\n\tv377 = System.Type::IsAssignableFrom(this.PropertyType, v333);\n\tv210 = v377 == 0;\n\tif (v210) goto L_007B;\n\tgoto L_01B9;\nL_007B:\n\tgoto L_0083;\n\tv384 = *([v380 @ X0_v28+E0]);\n\tv385 = v384 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_0083;\n\tv388 = \"il2cpp_codegen_runtime_class_init\"(v380, v152, v143, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0083:\n\tv334 = System.Type::GetTypeFromHandle(System.String);\n\tv393 = System.Type::IsAssignableFrom(this.PropertyType, v334);\n\tv211 = v393 == 0;\n\tif (v211) goto L_0099;\n\tgoto L_01B9;\nL_0099:\n\tgoto L_00A1;\n\tv400 = *([v396 @ X0_v34+E0]);\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_00A1;\n\tv404 = \"il2cpp_codegen_runtime_class_init\"(v396, v153, v144, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00A1:\n\tv335 = System.Type::GetTypeFromHandle(UnityEngine.Vector2);\n\tv409 = System.Type::IsAssignableFrom(this.PropertyType, v335);\n\tv212 = v409 == 0;\n\tif (v212) goto L_00B7;\n\tgoto L_01B9;\nL_00B7:\n\tgoto L_00BF;\n\tv416 = *([v412 @ X0_v40+E0]);\n\tv417 = v416 == 0;\n\tv418 = ~v417;\n\tif (v418) goto L_00BF;\n\tv420 = \"il2cpp_codegen_runtime_class_init\"(v412, v154, v145, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00BF:\n\tv336 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv425 = System.Type::IsAssignableFrom(this.PropertyType, v336);\n\tv213 = v425 == 0;\n\tif (v213) goto L_00D5;\n\tgoto L_01B9;\nL_00D5:\n\tgoto L_00DD;\n\tv432 = *([v428 @ X0_v46+E0]);\n\tv433 = v432 == 0;\n\tv434 = ~v433;\n\tif (v434) goto L_00DD;\n\tv436 = \"il2cpp_codegen_runtime_class_init\"(v428, v155, v146, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00DD:\n\tv337 = System.Type::GetTypeFromHandle(UnityEngine.Rect);\n\tv441 = System.Type::IsAssignableFrom(this.PropertyType, v337);\n\tv214 = v441 == 0;\n\tif (v214) goto L_00F3;\n\tgoto L_01B9;\nL_00F3:\n\tgoto L_00FB;\n\tv448 = *([v444 @ X0_v52+E0]);\n\tv449 = v448 == 0;\n\tv450 = ~v449;\n\tif (v450) goto L_00FB;\n\tv452 = \"il2cpp_codegen_runtime_class_init\"(v444, v156, v147, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00FB:\n\tv338 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv457 = System.Type::IsAssignableFrom(this.PropertyType, v338);\n\tv215 = v457 == 0;\n\tif (v215) goto L_0111;\n\tgoto L_01B9;\nL_0111:\n\tgoto L_0119;\n\tv464 = *([v460 @ X0_v58+E0]);\n\tv465 = v464 == 0;\n\tv466 = ~v465;\n\tif (v466) goto L_0119;\n\tv468 = \"il2cpp_codegen_runtime_class_init\"(v460, v157, v148, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0119:\n\tv470 = System.Type::GetTypeFromHandle(UnityEngine.GameObject);\n\tv125 = this.PropertyType == v470;\n\tif (v125) goto L_FFFFFFFF;\n\tgoto L_0134;\n\tv477 = *([v473 @ X0_v63+E0]);\n\tv478 = v477 == 0;\n\tv479 = ~v478;\n\tif (v479) goto L_0134;\n\tv481 = \"il2cpp_codegen_runtime_class_init\"(v473, v159, v148, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0134:\n\tv483 = System.Type::GetTypeFromHandle(UnityEngine.Material);\n\tv126 = this.PropertyType == v483;\n\tif (v126) goto L_FFFFFFFF;\n\tgoto L_014F;\n\tv490 = *([v486 @ X0_v68+E0]);\n\tv491 = v490 == 0;\n\tv492 = ~v491;\n\tif (v492) goto L_014F;\n\tv494 = \"il2cpp_codegen_runtime_class_init\"(v486, v160, v148, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_014F:\n\tv496 = System.Type::GetTypeFromHandle(UnityEngine.Texture);\n\tv127 = this.PropertyType == v496;\n\tif (v127) goto L_FFFFFFFF;\n\tgoto L_016A;\n\tv503 = *([v499 @ X0_v73+E0]);\n\tv504 = v503 == 0;\n\tv505 = ~v504;\n\tif (v505) goto L_016A;\n\tv507 = \"il2cpp_codegen_runtime_class_init\"(v499, v161, v148, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_016A:\n\tv509 = System.Type::GetTypeFromHandle(UnityEngine.Color);\n\tv69 = this.PropertyType == v509;\n\tif (v69) goto L_FFFFFFFF;\n\tgoto L_0185;\n\tv516 = *([v512 @ X0_v78+E0]);\n\tv517 = v516 == 0;\n\tv518 = ~v517;\n\tif (v518) goto L_0185;\n\tv520 = \"il2cpp_codegen_runtime_class_init\"(v512, v162, v148, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0185:\n\tv339 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv525 = System.Type::IsSubclassOf(this.PropertyType, v339);\n\tv216 = v525 == 0;\n\tif (v216) goto L_019F;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\nL_019F:\n\tv527 = System.Type::get_IsArray(this.PropertyType);\n\tv221 = v527 == 0;\n\tif (v221) goto L_01AB;\n\tgoto L_01B9;\nL_01AB:\n\tv90 = System.Type::get_IsEnum(this.PropertyType);\n\tv92 = v90 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_01B9;\nL_01B9:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 286 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable GetVariable()
		{
			CheckForReinitialize();
			if ((object)PropertyType != null)
			{
				Type typeFromHandle = typeof(bool);
				if (PropertyType.IsAssignableFrom(typeFromHandle))
				{
					return BoolParameter;
				}
				Type typeFromHandle2 = typeof(int);
				if (PropertyType.IsAssignableFrom(typeFromHandle2))
				{
					return IntParameter;
				}
				Type typeFromHandle3 = typeof(float);
				if (PropertyType.IsAssignableFrom(typeFromHandle3))
				{
					return FloatParameter;
				}
				Type typeFromHandle4 = typeof(string);
				if (PropertyType.IsAssignableFrom(typeFromHandle4))
				{
					return StringParameter;
				}
				Type typeFromHandle5 = typeof(Vector2);
				if (PropertyType.IsAssignableFrom(typeFromHandle5))
				{
					return Vector2Parameter;
				}
				Type typeFromHandle6 = typeof(Vector3);
				if (PropertyType.IsAssignableFrom(typeFromHandle6))
				{
					return Vector3Parameter;
				}
				Type typeFromHandle7 = typeof(Rect);
				if (PropertyType.IsAssignableFrom(typeFromHandle7))
				{
					return RectParamater;
				}
				Type typeFromHandle8 = typeof(Quaternion);
				if (PropertyType.IsAssignableFrom(typeFromHandle8))
				{
					return QuaternionParameter;
				}
				Type typeFromHandle9 = typeof(GameObject);
				if ((object)PropertyType == typeFromHandle9)
				{
					return GameObjectParameter;
				}
				Type typeFromHandle10 = typeof(Material);
				if ((object)PropertyType == typeFromHandle10)
				{
					return MaterialParameter;
				}
				Type typeFromHandle11 = typeof(Texture);
				if ((object)PropertyType == typeFromHandle11)
				{
					return TextureParameter;
				}
				Type typeFromHandle12 = typeof(Color);
				if ((object)PropertyType == typeFromHandle12)
				{
					return ColorParameter;
				}
				Type typeFromHandle13 = typeof(UnityEngine.Object);
				if (PropertyType.IsSubclassOf(typeFromHandle13))
				{
					return ObjectParameter;
				}
				if (PropertyType.IsArray)
				{
					return ArrayParameter;
				}
				if (PropertyType.IsEnum)
				{
					return EnumParameter;
				}
			}
			return null;
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0xCB0C84", Offset = "0xCB0C84", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE89A8]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, propertyName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202361D]) = v41;\nL_0016:\n\tHutongGames.PlayMaker.FsmProperty::ResetParameters(this);\n\tthis.PropertyName = propertyName;\n\tv45 = System.String::IsNullOrEmpty(propertyName);\n\tv47 = v45 == 0;\n\tif (v47) goto L_0021;\n\tthis.PropertyType = 0;\n\tgoto L_007C;\nL_0021:\n\tv49 = this.TargetType == 0;\n\tif (v49) goto L_007C;\n\tgoto L_0033;\n\tv94 = *([v90 @ X0_v7+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0033;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v90, v44, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0033:\n\tv104 = HutongGames.PlayMaker.ReflectionUtils::GetPropertyType(this.TargetType, this.PropertyName);\n\tthis.PropertyType = v104;\n\tv75 = this.TargetType;\n\tgoto L_0047;\n\tv132 = *([v126 @ X0_v11+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0047;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v126, v102, v103, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0047:\n\tv141 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv146 = System.Type::IsSubclassOf(v75, v141);\n\tv148 = v146 == 0;\n\tif (v148) goto L_0063;\n\tv67 = HutongGames.PlayMaker.FsmObject::set_ObjectType(this.ObjectParameter, this.PropertyType);\n\tgoto L_007C;\nL_0063:\n\tv68 = System.Type::get_IsArray(this.PropertyType);\n\tv72 = v68 == 0;\n\tif (v72) goto L_007C;\n\tv162 = this.PropertyType;\n\tv167 = System.Type::GetElementType(v162);\n\tv153 = HutongGames.PlayMaker.FsmVar::GetVariableType(v167);\n\tHutongGames.PlayMaker.FsmArray::SetType(this.ArrayParameter, v153);\nL_007C:\n\tHutongGames.PlayMaker.FsmProperty::Init(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPropertyName(string propertyName)
		{
			ResetParameters();
			PropertyName = propertyName;
			if (string.IsNullOrEmpty(propertyName))
			{
				PropertyType = null;
			}
			else if ((object)TargetType != null)
			{
				Type propertyType = ReflectionUtils.GetPropertyType(TargetType, PropertyName);
				PropertyType = propertyType;
				Type targetType = TargetType;
				Type typeFromHandle = typeof(UnityEngine.Object);
				if (targetType.IsSubclassOf(typeFromHandle))
				{
					ObjectParameter.ObjectType = PropertyType;
				}
				else if (PropertyType.IsArray)
				{
					Type propertyType2 = PropertyType;
					Type elementType = propertyType2.GetElementType();
					VariableType variableType = FsmVar.GetVariableType(elementType);
					ArrayParameter.SetType(variableType);
				}
			}
			Init();
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0xCB14DC", Offset = "0xCB14DC", Length = "0x988")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F09218]);\n\tv25 = *([v24 @ X8_v127]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202361E]) = v44;\nL_0017:\n\tHutongGames.PlayMaker.FsmProperty::CheckForReinitialize(this);\n\tgoto L_0028;\n\tv53 = *([v49 @ X0_v3+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tv63 = UnityEngine.Object::op_Equality(this.targetObjectCached, 0);\n\tv65 = v63 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0309;\n\tv68 = this.memberInfo == 0;\n\tif (v68) goto L_0309;\n\tv166 = this.PropertyType;\n\tgoto L_0042;\n\tv249 = *([v167 @ X0_v8+E0]);\n\tv250 = v249 == 0;\n\tv251 = ~v250;\n\tif (v251) goto L_0042;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v167, v61, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0042:\n\tv258 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv261 = *([v166 @ X20_v5 (System.Type)]);\n\tv646 = *([v261 @ X8_v13 (Il2CppClass<System.Type>)+848]);\n\tv265 = System.Type::IsAssignableFrom(v166, v258);\n\tv267 = v265 == 0;\n\tif (v267) goto L_0058;\n\tv407 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.BoolParameter);\n\tv409 = v407 == 0;\n\tif (v409) goto L_0233;\nL_0058:\n\tv391 = this.PropertyType;\n\tgoto L_0066;\n\tv564 = *([v411 @ X0_v30+E0]);\n\tv565 = v564 == 0;\n\tv566 = ~v565;\n\tif (v566) goto L_0066;\n\tv568 = \"il2cpp_codegen_runtime_class_init\"(v411, v404, v264, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0066:\n\tv343 = System.Type::GetTypeFromHandle(System.Int32);\n\tv546 = *([v391 @ X20_v11 (System.Type)]);\n\tv646 = *([v546 @ X8_v23 (Il2CppClass<System.Type>)+848]);\n\tv579 = System.Type::IsAssignableFrom(v391, v343);\n\tv581 = v579 == 0;\n\tif (v581) goto L_007C;\n\tv587 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.IntParameter);\n\tv589 = v587 == 0;\n\tif (v589) goto L_023E;\nL_007C:\n\tv392 = this.PropertyType;\n\tgoto L_008A;\n\tv599 = *([v591 @ X0_v37+E0]);\n\tv600 = v599 == 0;\n\tv601 = ~v600;\n\tif (v601) goto L_008A;\n\tv603 = \"il2cpp_codegen_runtime_class_init\"(v591, v585, v316, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_008A:\n\tv344 = System.Type::GetTypeFromHandle(System.Single);\n\tv547 = *([v392 @ X20_v12 (System.Type)]);\n\tv646 = *([v547 @ X8_v27 (Il2CppClass<System.Type>)+848]);\n\tv660 = System.Type::IsAssignableFrom(v392, v344);\n\tv662 = v660 == 0;\n\tif (v662) goto L_00A6;\n\tv670 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.FloatParameter);\n\tv672 = v670 == 0;\n\tif (v672) goto L_024B;\nL_00A6:\n\tgoto L_00AE;\n\tv684 = *([v674 @ X0_v45+E0]);\n\tv685 = v684 == 0;\n\tv686 = ~v685;\n\tif (v686) goto L_00AE;\n\tv688 = \"il2cpp_codegen_runtime_class_init\"(v674, v668, v317, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00AE:\n\tv345 = System.Type::GetTypeFromHandle(System.String);\n\tv695 = System.Type::IsAssignableFrom(this.PropertyType, v345);\n\tv697 = v695 == 0;\n\tif (v697) goto L_00C4;\n\tv703 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.StringParameter);\n\tv705 = v703 == 0;\n\tif (v705) goto L_0256;\nL_00C4:\n\tv394 = this.PropertyType;\n\tgoto L_00D2;\n\tv715 = *([v707 @ X0_v58+E0]);\n\tv716 = v715 == 0;\n\tv717 = ~v716;\n\tif (v717) goto L_00D2;\n\tv719 = \"il2cpp_codegen_runtime_class_init\"(v707, v701, v318, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00D2:\n\tv346 = System.Type::GetTypeFromHandle(UnityEngine.Vector2);\n\tv549 = *([v394 @ X20_v18 (System.Type)]);\n\tv646 = *([v549 @ X8_v41 (Il2CppClass<System.Type>)+848]);\n\tv765 = System.Type::IsAssignableFrom(v394, v346);\n\tv767 = v765 == 0;\n\tif (v767) goto L_00E8;\n\tv351 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Vector2Parameter);\n\tv774 = v351 == 0;\n\tif (v774) goto L_0275;\nL_00E8:\n\tv395 = this.PropertyType;\n\tgoto L_00F6;\n\tv817 = *([v776 @ X0_v65+E0]);\n\tv818 = v817 == 0;\n\tv819 = ~v818;\n\tif (v819) goto L_00F6;\n\tv821 = \"il2cpp_codegen_runtime_class_init\"(v776, v771, v319, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00F6:\n\tv347 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv550 = *([v395 @ X20_v19 (System.Type)]);\n\tv646 = *([v550 @ X8_v45 (Il2CppClass<System.Type>)+848]);\n\tv873 = System.Type::IsAssignableFrom(v395, v347);\n\tv875 = v873 == 0;\n\tif (v875) goto L_010C;\n\tv879 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.Vector3Parameter);\n\tv881 = v879 == 0;\n\tif (v881) goto L_0285;\nL_010C:\n\tv396 = this.PropertyType;\n\tgoto L_011A;\n\tv887 = *([v883 @ X0_v72+E0]);\n\tv888 = v887 == 0;\n\tv889 = ~v888;\n\tif (v889) goto L_011A;\n\tv891 = \"il2cpp_codegen_runtime_class_init\"(v883, v877, v320, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_011A:\n\tv348 = System.Type::GetTypeFromHandle(UnityEngine.Rect);\n\tv551 = *([v396 @ X20_v20 (System.Type)]);\n\tv646 = *([v551 @ X8_v49 (Il2CppClass<System.Type>)+848]);\n\tv897 = System.Type::IsAssignableFrom(v396, v348);\n\tv899 = v897 == 0;\n\tif (v899) goto L_0130;\n\tv352 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.RectParamater);\n\tv903 = v352 == 0;\n\tif (v903) goto L_0292;\nL_0130:\n\tv397 = this.PropertyType;\n\tgoto L_013E;\n\tv910 = *([v905 @ X0_v81+E0]);\n\tv911 = v910 == 0;\n\tv912 = ~v911;\n\tif (v912) goto L_013E;\n\tv914 = \"il2cpp_codegen_runtime_class_init\"(v905, v900, v321, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_013E:\n\tv349 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv552 = *([v397 @ X20_v22 (System.Type)]);\n\tv646 = *([v552 @ X8_v54 (Il2CppClass<System.Type>)+848]);\n\tv920 = System.Type::IsAssignableFrom(v397, v349);\n\tv922 = v920 == 0;\n\tif (v922) goto L_015A;\n\tv353 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.QuaternionParameter);\n\tv931 = v353 == 0;\n\tif (v931) goto L_029B;\nL_015A:\n\tgoto L_0162;\n\tv946 = *([v933 @ X0_v88+E0]);\n\tv947 = v946 == 0;\n\tv948 = ~v947;\n\tif (v948) goto L_0162;\n\tv950 = \"il2cpp_codegen_runtime_class_init\"(v933, v928, v322, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0162:\n\tv953 = System.Type::GetTypeFromHandle(UnityEngine.GameObject);\n\tv418 = this.PropertyType != v953;\n\tif (v418) goto L_017E;\n\tv958 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.GameObjectParameter);\n\tv960 = v958 == 0;\n\tif (v960) goto L_02A7;\nL_017E:\n\tgoto L_0186;\n\tv967 = *([v962 @ X0_v93+E0]);\n\tv968 = v967 == 0;\n\tv969 = ~v968;\n\tif (v969) goto L_0186;\n\tv971 = \"il2cpp_codegen_runtime_class_init\"(v962, v956, v322, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0186:\n\tv974 = System.Type::GetTypeFromHandle(UnityEngine.Material);\n\tv419 = this.PropertyType != v974;\n\tif (v419) goto L_01A2;\n\tv979 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.MaterialParameter);\n\tv981 = v979 == 0;\n\tif (v981) goto L_02AE;\nL_01A2:\n\tgoto L_01AA;\n\tv987 = *([v983 @ X0_v98+E0]);\n\tv988 = v987 == 0;\n\tv989 = ~v988;\n\tif (v989) goto L_01AA;\n\tv991 = \"il2cpp_codegen_runtime_class_init\"(v983, v977, v322, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_01AA:\n\tv994 = System.Type::GetTypeFromHandle(UnityEngine.Texture);\n\tv420 = this.PropertyType != v994;\n\tif (v420) goto L_01C6;\n\tv999 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.TextureParameter);\n\tv1001 = v999 == 0;\n\tif (v1001) goto L_02B5;\nL_01C6:\n\tgoto L_01CE;\n\tv1007 = *([v1003 @ X0_v103+E0]);\n\tv1008 = v1007 == 0;\n\tv1009 = ~v1008;\n\tif (v1009) goto L_01CE;\n\tv1011 = \"il2cpp_codegen_runtime_class_init\"(v1003, v997, v322, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_01CE:\n\tv1014 = System.Type::GetTypeFromHandle(UnityEngine.Color);\n\tv92 = this.PropertyType != v1014;\n\tif (v92) goto L_01EA;\n\tv354 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.ColorParameter);\n\tv1020 = v354 == 0;\n\tif (v1020) goto L_02E2;\nL_01EA:\n\tgoto L_01F2;\n\tv1026 = *([v1022 @ X0_v108+E0]);\n\tv1027 = v1026 == 0;\n\tv1028 = ~v1027;\n\tif (v1028) goto L_01F2;\n\tv1030 = \"il2cpp_codegen_runtime_class_init\"(v1022, v1017, v322, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_01F2:\n\tv350 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv1036 = System.Type::IsSubclassOf(this.PropertyTy\n// ... truncated")]
		public void SetValue()
		{
			//IL_0086: Expected I, but got O
			//IL_0096: Expected O, but got I
			//IL_011a: Expected I, but got O
			//IL_012a: Expected O, but got I
			//IL_0cbf: Expected O, but got I4
			//IL_01ae: Expected I, but got O
			//IL_01be: Expected O, but got I
			//IL_0cd4: Expected O, but got F4
			//IL_02b6: Expected I, but got O
			//IL_02c6: Expected O, but got I
			//IL_034a: Expected I, but got O
			//IL_035a: Expected O, but got I
			//IL_03de: Expected I, but got O
			//IL_03ee: Expected O, but got I
			//IL_0472: Expected I, but got O
			//IL_0482: Expected O, but got I
			CheckForReinitialize();
			if (targetObjectCached == null || memberInfo == null)
			{
				return;
			}
			Type propertyType = PropertyType;
			Type typeFromHandle = typeof(bool);
			IntPtr intPtr = (IntPtr)propertyType;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X8_v13 (Il2CppClass<System.Type>)+848]");
			object obj = 0;
			UnityEngine.Object obj2;
			MemberInfo[] array;
			object obj3;
			object value3;
			UnityEngine.Object target;
			MemberInfo[] array3;
			UnityEngine.Object target2;
			MemberInfo[] array4;
			Rect value6;
			object typeFromHandle14;
			float num3;
			int num4;
			object typeFromHandle16;
			object typeFromHandle15;
			float x;
			if (!propertyType.IsAssignableFrom(typeFromHandle) || BoolParameter.IsNone)
			{
				Type propertyType2 = PropertyType;
				Type typeFromHandle2 = typeof(int);
				IntPtr intPtr2 = (IntPtr)propertyType2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ X8_v23 (Il2CppClass<System.Type>)+848]");
				obj = 0;
				if (!propertyType2.IsAssignableFrom(typeFromHandle2) || IntParameter.IsNone)
				{
					Type propertyType3 = PropertyType;
					Type typeFromHandle3 = typeof(float);
					IntPtr intPtr3 = (IntPtr)propertyType3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ X8_v27 (Il2CppClass<System.Type>)+848]");
					obj = 0;
					if (!propertyType3.IsAssignableFrom(typeFromHandle3) || FloatParameter.IsNone)
					{
						Type typeFromHandle4 = typeof(string);
						if (PropertyType.IsAssignableFrom(typeFromHandle4) && !StringParameter.IsNone)
						{
							obj2 = targetObjectCached;
							array = memberInfo;
							string value = StringParameter.Value;
							obj3 = value;
							goto IL_08aa;
						}
						Type propertyType4 = PropertyType;
						Type typeFromHandle5 = typeof(Vector2);
						IntPtr intPtr4 = (IntPtr)propertyType4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ X8_v41 (Il2CppClass<System.Type>)+848]");
						obj = 0;
						if (!propertyType4.IsAssignableFrom(typeFromHandle5) || Vector2Parameter.IsNone)
						{
							Type propertyType5 = PropertyType;
							Type typeFromHandle6 = typeof(Vector3);
							IntPtr intPtr5 = (IntPtr)propertyType5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ X8_v45 (Il2CppClass<System.Type>)+848]");
							obj = 0;
							if (!propertyType5.IsAssignableFrom(typeFromHandle6) || Vector3Parameter.IsNone)
							{
								Type propertyType6 = PropertyType;
								Type typeFromHandle7 = typeof(Rect);
								IntPtr intPtr6 = (IntPtr)propertyType6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ X8_v49 (Il2CppClass<System.Type>)+848]");
								obj = 0;
								if (!propertyType6.IsAssignableFrom(typeFromHandle7) || RectParamater.IsNone)
								{
									Type propertyType7 = PropertyType;
									Type typeFromHandle8 = typeof(Quaternion);
									IntPtr intPtr7 = (IntPtr)propertyType7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X8_v54 (Il2CppClass<System.Type>)+848]");
									obj = 0;
									if (!propertyType7.IsAssignableFrom(typeFromHandle8) || QuaternionParameter.IsNone)
									{
										Type typeFromHandle9 = typeof(GameObject);
										if ((object)PropertyType != typeFromHandle9 || GameObjectParameter.IsNone)
										{
											Type typeFromHandle10 = typeof(Material);
											if ((object)PropertyType != typeFromHandle10 || MaterialParameter.IsNone)
											{
												Type typeFromHandle11 = typeof(Texture);
												if ((object)PropertyType != typeFromHandle11 || TextureParameter.IsNone)
												{
													Type typeFromHandle12 = typeof(Color);
													if ((object)PropertyType != typeFromHandle12 || ColorParameter.IsNone)
													{
														Type typeFromHandle13 = typeof(UnityEngine.Object);
														if (!PropertyType.IsSubclassOf(typeFromHandle13) || ObjectParameter.IsNone)
														{
															if (!PropertyType.IsArray || ArrayParameter.IsNone)
															{
																if (PropertyType.IsEnum && !EnumParameter.IsNone)
																{
																	obj2 = targetObjectCached;
																	array = memberInfo;
																	Enum value2 = EnumParameter.Value;
																	obj3 = value2;
																	goto IL_08aa;
																}
																return;
															}
															FsmArray arrayParameter = ArrayParameter;
															object[] values = arrayParameter.values;
															if (arrayParameter.values == null)
															{
																arrayParameter.Init();
																values = arrayParameter.values;
															}
															Type elementType = PropertyType.GetElementType();
															Array array2 = Array.CreateInstance(elementType, values.Length);
															int num = values.Length;
															if (values.Length >= 1)
															{
																int num2 = 0;
																do
																{
																	if (num2 < num)
																	{
																		array2.SetValue(values[num2], num2);
																		num = values.Length;
																		num2++;
																		continue;
																	}
																	IndexOutOfRangeException ex = new IndexOutOfRangeException();
																	throw ex;
																}
																while (num2 < values.Length);
															}
															value3 = array2;
															target = targetObjectCached;
															array3 = memberInfo;
														}
														else
														{
															UnityEngine.Object value4 = ObjectParameter.Value;
															if (value4 == null)
															{
																value3 = null;
																target = targetObjectCached;
																array3 = memberInfo;
															}
															else
															{
																UnityEngine.Object value5 = ObjectParameter.Value;
																value3 = value5;
																target = targetObjectCached;
																array3 = memberInfo;
															}
														}
														goto IL_0d00;
													}
													FsmColor colorParameter = ColorParameter;
													target2 = targetObjectCached;
													array4 = memberInfo;
													value6 = (Rect)colorParameter.value;
													typeFromHandle14 = typeof(Color);
													goto IL_0cd9;
												}
												obj2 = targetObjectCached;
												array = memberInfo;
												Texture value7 = TextureParameter.Value;
												obj3 = value7;
											}
											else
											{
												obj2 = targetObjectCached;
												array = memberInfo;
												Material value8 = MaterialParameter.Value;
												obj3 = value8;
											}
										}
										else
										{
											obj2 = targetObjectCached;
											array = memberInfo;
											GameObject value9 = GameObjectParameter.Value;
											obj3 = value9;
										}
										goto IL_08aa;
									}
									FsmQuaternion quaternionParameter = QuaternionParameter;
									target2 = targetObjectCached;
									array4 = memberInfo;
									value6 = (Rect)quaternionParameter.value;
									typeFromHandle14 = typeof(Quaternion);
								}
								else
								{
									FsmRect rectParamater = RectParamater;
									value6 = rectParamater.value;
									target2 = targetObjectCached;
									array4 = memberInfo;
									typeFromHandle14 = typeof(Rect);
								}
								goto IL_0cd9;
							}
							target2 = targetObjectCached;
							array4 = memberInfo;
							Vector3 value10 = Vector3Parameter.Value;
							x = value10.x;
							num3 = value10.x;
							typeFromHandle15 = typeof(Vector3);
						}
						else
						{
							FsmVector2 vector2Parameter = Vector2Parameter;
							target2 = targetObjectCached;
							array4 = memberInfo;
							num3 = vector2Parameter.value.x;
							typeFromHandle15 = typeof(Vector2);
						}
					}
					else
					{
						target2 = targetObjectCached;
						array4 = memberInfo;
						x = FloatParameter.Value;
						num3 = x;
						typeFromHandle15 = typeof(float);
					}
					goto IL_0ccc;
				}
				target2 = targetObjectCached;
				array4 = memberInfo;
				int value11 = IntParameter.Value;
				num4 = value11;
				typeFromHandle16 = typeof(int);
			}
			else
			{
				target2 = targetObjectCached;
				array4 = memberInfo;
				bool value12 = BoolParameter.Value;
				num4 = (value12 ? 1 : 0);
				typeFromHandle16 = typeof(bool);
			}
			object obj4 = num4;
			typeFromHandle15 = typeFromHandle16;
			goto IL_0d39;
			IL_08aa:
			value3 = obj3;
			target = obj2;
			array3 = array;
			goto IL_0d00;
			IL_0d00:
			ReflectionUtils.SetMemberValue(array3, target, value3);
			return;
			IL_0ccc:
			obj4 = num3;
			goto IL_0d39;
			IL_0d39:
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value13 = default(object);
			ReflectionUtils.SetMemberValue(array4, target2, value13);
			return;
			IL_0cd9:
			typeFromHandle15 = typeFromHandle14;
			x = value6.x;
			num3 = value6.x;
			goto IL_0ccc;
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0xCB1F40", Offset = "0xCB1F40", Length = "0xBE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ECB0A0]);\n\tv25 = *([v24 @ X8_v214]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202361F]) = v44;\nL_0017:\n\tHutongGames.PlayMaker.FsmProperty::CheckForReinitialize(this);\n\tgoto L_0028;\n\tv53 = *([v49 @ X0_v3+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tv63 = UnityEngine.Object::op_Equality(this.targetObjectCached, 0);\n\tv65 = v63 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_00FF;\n\tv68 = this.memberInfo == 0;\n\tif (v68) goto L_00FF;\n\tgoto L_0042;\n\tv398 = *([v301 @ X0_v8+E0]);\n\tv399 = v398 == 0;\n\tv400 = ~v399;\n\tif (v400) goto L_0042;\n\tv402 = \"il2cpp_codegen_runtime_class_init\"(v301, v61, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0042:\n\tv407 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv414 = System.Type::IsAssignableFrom(this.PropertyType, v407);\n\tv416 = v414 == 0;\n\tif (v416) goto L_0082;\n\tv187 = this.BoolParameter;\n\tgoto L_0060;\n\tv696 = *([v643 @ X0_v210+E0]);\n\tv697 = v696 == 0;\n\tv698 = ~v697;\n\tif (v698) goto L_0060;\n\tv700 = \"il2cpp_codegen_runtime_class_init\"(v643, v408, v413, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0060:\n\tv543 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(this.memberInfo, this.targetObjectCached);\n\tv81 = ~v81_asT;\n\tif (v81) goto L_0492;\n\tv237 = \"il2cpp_vm_object_unbox\"(v543, System.Boolean, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv187.value = *([v237 @ X0_v214]);\n\tgoto L_00FF;\nL_0082:\n\tgoto L_008A;\n\tv703 = *([v648 @ X0_v30+E0]);\n\tv704 = v703 == 0;\n\tv705 = ~v704;\n\tif (v705) goto L_008A;\n\tv707 = \"il2cpp_codegen_runtime_class_init\"(v648, v408, v413, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_008A:\n\tv544 = System.Type::GetTypeFromHandle(System.Int32);\n\tv833 = System.Type::IsAssignableFrom(this.PropertyType, v544);\n\tv835 = v833 == 0;\n\tif (v835) goto L_00B8;\n\tv464 = this.IntParameter;\n\tgoto L_00A8;\n\tv880 = *([v842 @ X0_v204+E0]);\n\tv881 = v880 == 0;\n\tv882 = ~v881;\n\tif (v882) goto L_00A8;\n\tv884 = \"il2cpp_codegen_runtime_class_init\"(v842, v519, v502, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00A8:\n\tv777 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(this.memberInfo, this.targetObjectCached);\n\tgoto L_FFFFFFFF;\nL_00B8:\n\tgoto L_00C0;\n\tv887 = *([v847 @ X0_v38+E0]);\n\tv888 = v887 == 0;\n\tv889 = ~v888;\n\tif (v889) goto L_00C0;\n\tv891 = \"il2cpp_codegen_runtime_class_init\"(v847, v519, v502, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00C0:\n\tv546 = System.Type::GetTypeFromHandle(System.Single);\n\tv970 = System.Type::IsAssignableFrom(this.PropertyType, v546);\n\tv972 = v970 == 0;\n\tif (v972) goto L_0108;\n\tgoto L_00DE;\n\tv992 = *([v977 @ X0_v198+E0]);\n\tv993 = v992 == 0;\n\tv994 = ~v993;\n\tif (v994) goto L_00DE;\n\tv996 = \"il2cpp_codegen_runtime_class_init\"(v977, v521, v504, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00DE:\n\tv777 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(this.memberInfo, this.targetObjectCached);\n\tv79 = v79_asT == 0;\n\tif (v79) goto L_0492;\n\tv236 = \"il2cpp_vm_object_unbox\"(v777, *([v988 @ X8_v22]), v212, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\t*([v464 @ X21_v45 (HutongGames.PlayMaker.FsmInt)+38]) = *([v236 @ X0_v37]);\nL_00FF:\n\treturn;\nL_0108:\n\tgoto L_0110;\n\tv999 = *([v982 @ X0_v44+E0]);\n\tv1000 = v999 == 0;\n\tv1001 = ~v1000;\n\tif (v1001) goto L_0110;\n\tv1003 = \"il2cpp_codegen_runtime_class_init\"(v982, v521, v504, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0110:\n\tv548 = System.Type::GetTypeFromHandle(System.String);\n\tv1009 = System.Type::IsAssignableFrom(this.PropertyType, v548);\n\tv1011 = v1009 == 0;\n\tif (v1011) goto L_014C;\n\tv188 = this.StringParameter;\n\tgoto L_012E;\n\tv1024 = *([v1015 @ X0_v192+E0]);\n\tv1025 = v1024 == 0;\n\tv1026 = ~v1025;\n\tif (v1026) goto L_012E;\n\tv1028 = \"il2cpp_codegen_runtime_class_init\"(v1015, v523, v505, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_012E:\n\tv238 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(this.memberInfo, this.targetObjectCached);\n\tv249 = v238 == 0;\n\tif (v249) goto L_0142;\n\tv716 = *([v238 @ X0_v195 (System.Object)]) != System.String;\n\tif (v716) goto L_0492;\nL_0142:\n\tv188.value = v238;\n\tgoto L_00FF;\nL_014C:\n\tgoto L_0154;\n\tv1031 = *([v1020 @ X0_v50+E0]);\n\tv1032 = v1031 == 0;\n\tv1033 = ~v1032;\n\tif (v1033) goto L_0154;\n\tv1035 = \"il2cpp_codegen_runtime_class_init\"(v1020, v523, v505, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0154:\n\tv549 = System.Type::GetTypeFromHandle(UnityEngine.Vector2);\n\tv1041 = System.Type::IsAssignableFrom(this.PropertyType, v549);\n\tv1043 = v1041 == 0;\n\tif (v1043) goto L_0196;\n\tv189 = this.Vector2Parameter;\n\tgoto L_0172;\n\tv1058 = *([v1049 @ X0_v185+E0]);\n\tv1059 = v1058 == 0;\n\tv1060 = ~v1059;\n\tif (v1060) goto L_0172;\n\tv1062 = \"il2cpp_codegen_runtime_class_init\"(v1049, v525, v506, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0172:\n\tv550 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(this.memberInfo, this.targetObjectCached);\n\tv83 = v83_asT == 0;\n\tif (v83) goto L_0492;\n\tv239 = \"il2cpp_vm_object_unbox\"(v550, UnityEngine.Vector2, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv189.value = *([v239 @ X0_v189]);\n\tv189.value.y = *([v239 @ X0_v189+4]);\n\tgoto L_00FF;\nL_0196:\n\tgoto L_019E;\n\tv1065 = *([v1054 @ X0_v56+E0]);\n\tv1066 = v1065 == 0;\n\tv1067 = ~v1066;\n\tif (v1067) goto L_019E;\n\tv1069 = \"il2cpp_codegen_runtime_class_init\"(v1054, v525, v506, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_019E:\n\tv551 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv1075 = System.Type::IsAssignableFrom(this.PropertyType, v551);\n\tv1077 = v1075 == 0;\n\tif (v1077) goto L_01E0;\n\tv190 = this.Vector3Parameter;\n\tgoto L_01BC;\n\tv1093 = *([v1084 @ X0_v178+E0]);\n\tv1094 = v1093 == 0;\n\tv1095 = ~v1094;\n\tif (v1095) goto L_01BC;\n\tv1097 = \"il2cpp_codegen_runtime_class_init\"(v1084, v527, v507, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_01BC:\n\tv552 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(this.memberInfo, this.targetObjectCached);\n\tv84 = v84_asT == 0;\n\tif (v84) goto L_0492;\n\tv240 = \"il2cpp_vm_object_unbox\"(v552, UnityEngine.Vector3, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv190.value = *([v240 @ X0_v182]);\n\tv190.value.z = *([v240 @ X0_v182+8]);\n\tgoto L_00FF;\nL_01E0:\n\tgoto L_01E8;\n\tv1100 = *([v1089 @ X0_v62+E0]);\n\tv1101 = v1100 == 0;\n\tv1102 = ~v1101;\n\tif (v1102) goto L_01E8;\n\tv1104 = \"il2cpp_codegen_runtime_class_init\"(v1089, v527, v507, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_01E8:\n\tv553 = System.Type::GetTypeFromHandle(UnityEngine.Rect);\n\tv1110 = System.Type::IsAssignableFrom(this.PropertyType, v553);\n\tv1112 = v1110 == 0;\n\tif (v1112) goto L_0216;\n\tv471 = this.RectParamater;\n\tgoto L_0206;\n\tv1128 = *([v1119 @ X0_v172+E0]);\n\tv1129 = v1128 == 0;\n\tv1130 = ~v1129;\n\tif (v1130) goto L_0206;\n\tv1132 = \"il2cpp_codegen_runtime_class_init\"(v1119, v529, v509, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0206:\n\tv778 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(this.memberInfo, this.targetObjectCached);\n\tgoto L_FFFFFFFF;\nL_0216:\n\tgoto L_021E;\n\tv1135 = *([v1124 @ X0_v70+E0]);\n\tv1136 = v1135 == 0;\n\tv1137 = ~v1136;\n\tif (v1137) goto L_021E;\n\tv1139 = \"il2cpp_codegen_runtime_class_init\"(v1124, v529, v509, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_021E:\n\tv555 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv1145 = System.Type::IsAssignableFrom(this.PropertyType, v555);\n\tv1147 = v1145 == 0;\n\tif (v1147) goto L_0262;\n\tgoto L_023C;\n\tv1178 = *([v1152 @ X0_v166+E0]);\n\tv1179 = v1178 == 0;\n\tv1180 = ~v1179;\n\tif (v1180) goto L_023C;\n\tv1182 = \"il2cpp_codegen_runtime_class_init\"(v1152, v531, v515, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40\n// ... truncated")]
		public void GetValue()
		{
			//IL_00da: Expected I4, but got O
			//IL_010a: Expected I4, but got O
			//IL_0189: Expected O, but got I4
			//IL_020d: Expected O, but got I4
			//IL_03d1: Expected F4, but got I
			//IL_04a9: Expected F4, but got I
			//IL_0528: Expected O, but got I4
			//IL_05ac: Expected O, but got I4
			//IL_0c53: Expected I, but got O
			//IL_0c5b: Expected I, but got O
			//IL_08f2: Expected O, but got I
			//IL_094c: Expected O, but got I4
			//IL_0bab: Expected I, but got O
			//IL_0bb9: Expected I, but got O
			CheckForReinitialize();
			if (targetObjectCached == null || memberInfo == null)
			{
				return;
			}
			Type typeFromHandle = typeof(bool);
			object typeFromHandle9;
			object[] array2;
			IntPtr intPtr2;
			if (PropertyType.IsAssignableFrom(typeFromHandle))
			{
				FsmBool boolParameter = BoolParameter;
				object memberValue = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
				if ((int)((memberValue is bool) ? memberValue : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					boolParameter.value = (byte)(int)obj != 0;
					return;
				}
			}
			else
			{
				Type typeFromHandle2 = typeof(int);
				object typeFromHandle3;
				if (PropertyType.IsAssignableFrom(typeFromHandle2))
				{
					FsmInt intParameter = IntParameter;
					object memberValue2 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
					object obj2 = 0;
					typeFromHandle3 = typeof(int);
				}
				else
				{
					Type typeFromHandle4 = typeof(float);
					if (!PropertyType.IsAssignableFrom(typeFromHandle4))
					{
						Type typeFromHandle5 = typeof(string);
						if (PropertyType.IsAssignableFrom(typeFromHandle5))
						{
							FsmString stringParameter = StringParameter;
							object memberValue3 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
							if (memberValue3 == null || (object)memberValue3.GetType() == typeof(string))
							{
								stringParameter.Value = (string)memberValue3;
								return;
							}
						}
						else
						{
							Type typeFromHandle6 = typeof(Vector2);
							if (PropertyType.IsAssignableFrom(typeFromHandle6))
							{
								FsmVector2 vector2Parameter = Vector2Parameter;
								object memberValue4 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
								if (((Vector2)((memberValue4 is Vector2) ? memberValue4 : null)).x != 0f)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									object value = default(object);
									vector2Parameter.value = (Vector2)value;
									ref Vector2 value2 = ref vector2Parameter.value;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ X0_v189+4]");
									value2.y = 0f;
									return;
								}
							}
							else
							{
								Type typeFromHandle7 = typeof(Vector3);
								if (!PropertyType.IsAssignableFrom(typeFromHandle7))
								{
									Type typeFromHandle8 = typeof(Rect);
									if (PropertyType.IsAssignableFrom(typeFromHandle8))
									{
										FsmRect rectParamater = RectParamater;
										object memberValue5 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
										object obj3 = 0;
										typeFromHandle9 = typeof(Rect);
									}
									else
									{
										Type typeFromHandle10 = typeof(Quaternion);
										object memberValue5;
										object obj3;
										if (!PropertyType.IsAssignableFrom(typeFromHandle10))
										{
											Type typeFromHandle11 = typeof(GameObject);
											if ((object)PropertyType != typeFromHandle11)
											{
												Type typeFromHandle12 = typeof(Material);
												object memberValue8;
												object typeFromHandle16;
												IntPtr intPtr;
												if ((object)PropertyType != typeFromHandle12)
												{
													Type typeFromHandle13 = typeof(Texture);
													if ((object)PropertyType != typeFromHandle13)
													{
														Type typeFromHandle14 = typeof(Color);
														if ((object)PropertyType != typeFromHandle14)
														{
															if (PropertyType.IsEnum)
															{
																object memberValue6 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
																if (memberValue6 != null)
																{
																	Enum obj4 = memberValue6 as Enum;
																	if (obj4 == null)
																	{
																		throw new InvalidCastException();
																	}
																}
																EnumParameter.Value = (Enum)memberValue6;
																return;
															}
															if (PropertyType.IsArray)
															{
																object memberValue7 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
																Array array = memberValue7 as Array;
																if (array != null)
																{
																	int length = ((Array)memberValue7).Length;
																	array2 = new object[length];
																	int length2 = ((Array)memberValue7).Length;
																	if (length2 < 1)
																	{
																		goto IL_0ad2;
																	}
																	int num = 0;
																	while (true)
																	{
																		object value3 = ((Array)memberValue7).GetValue(num);
																		if (value3 != null)
																		{
																			object obj5 = value3 as object;
																		}
																		if (num >= array2.Length)
																		{
																			break;
																		}
																		array2[num] = value3;
																		num++;
																		int length3 = ((Array)memberValue7).Length;
																		if (num < length3)
																		{
																			continue;
																		}
																		goto IL_0ad2;
																	}
																	goto IL_0bcc;
																}
																throw new InvalidCastException();
															}
															Type typeFromHandle15 = typeof(UnityEngine.Object);
															if (PropertyType.IsSubclassOf(typeFromHandle15))
															{
																memberValue8 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
																if (memberValue8 == null)
																{
																	return;
																}
																intPtr = (IntPtr)memberValue8;
																intPtr2 = (IntPtr)typeof(UnityEngine.Object);
																goto IL_0c76;
															}
															return;
														}
														memberValue5 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
														obj3 = 0;
														typeFromHandle9 = typeof(Color);
														goto IL_0c21;
													}
													memberValue8 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
													if (memberValue8 == null)
													{
														return;
													}
													typeFromHandle16 = typeof(Texture);
												}
												else
												{
													memberValue8 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
													if (memberValue8 == null)
													{
														return;
													}
													typeFromHandle16 = typeof(Material);
												}
												intPtr = (IntPtr)memberValue8;
												intPtr2 = (IntPtr)typeFromHandle16;
												goto IL_0c76;
											}
											FsmGameObject gameObjectParameter = GameObjectParameter;
											object memberValue9 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
											if (memberValue9 == null || (object)memberValue9.GetType() == typeof(GameObject))
											{
												if (gameObjectParameter.value != memberValue9)
												{
													gameObjectParameter.value = (GameObject)memberValue9;
													if (gameObjectParameter.OnChange != null)
													{
														gameObjectParameter.OnChange();
													}
												}
												return;
											}
											goto IL_0bbe;
										}
										memberValue5 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
										obj3 = 0;
										typeFromHandle9 = typeof(Quaternion);
									}
									goto IL_0c21;
								}
								FsmVector3 vector3Parameter = Vector3Parameter;
								object memberValue10 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
								if (((Vector3)((memberValue10 is Vector3) ? memberValue10 : null)).x != 0f)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									object value4 = default(object);
									vector3Parameter.value = (Vector3)value4;
									ref Vector3 value5 = ref vector3Parameter.value;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X0_v182+8]");
									value5.z = 0f;
									return;
								}
							}
						}
						goto IL_0bbe;
					}
					object memberValue2 = ReflectionUtils.GetMemberValue(memberInfo, targetObjectCached);
					object obj2 = 0;
					typeFromHandle3 = typeof(float);
				}
				object obj6 = typeFromHandle3 as object;
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					return;
				}
			}
			goto IL_0bbe;
			IL_0bcc:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0bbe:
			InvalidCastException ex3 = new InvalidCastException();
			goto IL_0bcc;
			IL_0c21:
			object obj7 = typeFromHandle9 as object;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X0_v69+4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X0_v69+C]");
				_ = 0;
				return;
			}
			goto IL_0bbe;
			IL_0c76:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X8_v69 (Il2CppClass<System.Object>)+128]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ X1_v37 (Il2CppClass<UnityEngine.Object>)+128]");
			if ((long)intPtr3 >= 0L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ X1_v37 (Il2CppClass<UnityEngine.Object>)+128]");
				int num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X8_v69 (Il2CppClass<System.Object>)+C8]");
				object obj8 = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1354 @ X8_v71-8]");
				if ((IntPtr)0 == intPtr2)
				{
					return;
				}
			}
			goto IL_0bbe;
			IL_0ad2:
			FsmArray arrayParameter = ArrayParameter;
			arrayParameter.values = array2;
			if (Application.isEditor)
			{
				arrayParameter.SaveChanges();
			}
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0xCB11F4", Offset = "0xCB11F4", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA6A18]);\n\tv25 = *([v24 @ X8_v33]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023620]) = v44;\nL_0017:\n\tv46 = this.TargetObject == 0;\n\tif (v46) goto L_00F0;\n\tthis.initialized = 1;\n\tv48 = HutongGames.PlayMaker.FsmObject::get_Value(this.TargetObject);\n\tv145 = this.TargetObject;\n\tthis.targetObjectCached = v48;\n\tv206 = ~v145.useVariable;\n\tif (v206) goto L_002D;\n\tthis.TargetTypeName = v145.typeName;\n\tv239 = HutongGames.PlayMaker.FsmObject::get_ObjectType(v145);\n\tthis.TargetType = v239;\n\tgoto L_0055;\nL_002D:\n\tv241 = HutongGames.PlayMaker.FsmObject::get_Value(v145);\n\tgoto L_003F;\n\tv326 = *([v276 @ X8_v29+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_003F;\n\tv342 = v276;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v342, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003F:\n\tv285 = UnityEngine.Object::op_Inequality(v241, 0);\n\tv287 = v285 == 0;\n\tif (v287) goto L_0055;\n\tv267 = HutongGames.PlayMaker.FsmObject::get_Value(this.TargetObject);\n\tv268 = System.Object::GetType(v267);\n\tthis.TargetType = v268;\n\tv284 = System.Type::get_FullName(v268);\n\tthis.TargetTypeName = v284;\nL_0055:\n\tv290 = System.String::IsNullOrEmpty(this.PropertyName);\n\tv325 = v290 == 0;\n\tif (v325) goto L_0066;\n\tv375 = this.PropertyType;\n\tv336 = this.PropertyType == 0;\n\tv124 = ~v336;\n\tif (v124) goto L_008D;\n\tgoto L_00F0;\nL_0066:\n\tgoto L_006F;\n\tv379 = *([v338 @ X0_v33+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_006F;\n\tv383 = \"il2cpp_codegen_runtime_class_init\"(v338, v101, v96, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006F:\n\tv316 = HutongGames.PlayMaker.ReflectionUtils::GetMemberInfo(this.TargetType, this.PropertyName);\n\tthis.memberInfo = v316;\n\tv193 = v316 == 0;\n\tif (v193) goto L_00F5;\n\tv318 = v316.Length == 0;\n\tif (v318) goto L_0103;\n\tv395 = v316.Length << 0x20;\n\tv396 = 0xFFFFFFFF00000000 + v395;\n\tv84 = v396 >> 0x1D;\n\tv397 = v316 + v84;\n\tgoto L_0089;\n\tv401 = *([v131 @ X8_v25+E0]);\n\tv402 = v401 == 0;\n\tv403 = ~v402;\n\tif (v403) goto L_0089;\n\tv408 = v131;\n\tv405 = \"il2cpp_codegen_runtime_class_init\"(v408, v183, v97, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0089:\n\tv375 = HutongGames.PlayMaker.ReflectionUtils::GetMemberUnderlyingType(*([v397 @ X9_v20+20]));\n\tthis.PropertyType = v375;\n\tv125 = v375 == 0;\n\tif (v125) goto L_00F0;\nL_008D:\n\t;\n\tv120 = System.Type::get_IsEnum(v375);\n\tv126 = v120 == 0;\n\tif (v126) goto L_00F0;\n\tv121 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(this.StringParameter);\n\tv388 = v121 == 0;\n\tv127 = ~v388;\n\tif (v127) goto L_00F0;\n\tv227 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v227, \"\");\n\tHutongGames.PlayMaker.FsmEnum::set_EnumType(v227, this.PropertyType);\n\tv410 = HutongGames.PlayMaker.FsmString::get_Value(this.StringParameter);\n\tgoto L_00BE;\n\tv416 = *([v412 @ X8_v17+E0]);\n\tv417 = v416 == 0;\n\tv418 = ~v417;\n\tif (v418) goto L_00BE;\n\tv425 = v412;\n\tv421 = \"il2cpp_codegen_runtime_class_init\"(v425, v261, v98, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00BE:\n\tv369 = System.Enum::Parse(this.PropertyType, v410);\n\tv370 = v369 == 0;\n\tif (v370) goto L_00E2;\n\tgoto L_FFFFFFFF;\n\tv345 = v345_asT == 0;\n\tif (v345) goto L_0108;\nL_00E2:\n\tHutongGames.PlayMaker.FsmEnum::set_Value(v227, v369);\n\tv129 = this.StringParameter;\n\tthis.EnumParameter = v227;\n\tv129.value = 0;\nL_00F0:\n\treturn;\nL_00F5:\n\tthis.PropertyName = \"\";\n\tthis.PropertyType = 0;\n\tHutongGames.PlayMaker.FsmProperty::ResetParameters(this);\n\treturn;\n\tv279 = new System.NullReferenceException();\nL_0103:\n\tv323 = new System.IndexOutOfRangeException();\n\tthrow v323;\nL_0108:\n\tthrow System.InvalidCastException;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init()
		{
			//IL_01c7: Expected O, but got I8
			//IL_01e4: Expected O, but got I
			//IL_01fa: Expected O, but got I
			if (TargetObject == null)
			{
				return;
			}
			initialized = true;
			UnityEngine.Object value = TargetObject.Value;
			FsmObject targetObject = TargetObject;
			targetObjectCached = value;
			if (targetObject.UseVariable)
			{
				TargetTypeName = targetObject.TypeName;
				Type objectType = targetObject.ObjectType;
				TargetType = objectType;
			}
			else
			{
				UnityEngine.Object value2 = targetObject.Value;
				if (value2 != null)
				{
					UnityEngine.Object value3 = TargetObject.Value;
					string fullName = (TargetType = value3.GetType()).FullName;
					TargetTypeName = fullName;
				}
			}
			Type type;
			if (string.IsNullOrEmpty(PropertyName))
			{
				type = PropertyType;
				if ((object)PropertyType == null)
				{
					return;
				}
			}
			else
			{
				MemberInfo[] array = (memberInfo = ReflectionUtils.GetMemberInfo(TargetType, PropertyName));
				if (array == null)
				{
					PropertyName = "";
					PropertyType = null;
					ResetParameters();
					return;
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				int num = array.Length << 32;
				object obj = -4294967296L + num;
				int num2 = (int)((long)(IntPtr)obj >> 29);
				object obj2 = (long)(IntPtr)array + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X9_v20+20]");
				type = (PropertyType = ReflectionUtils.GetMemberUnderlyingType((MemberInfo)0));
				if ((object)type == null)
				{
					return;
				}
			}
			if (!type.IsEnum || FsmString.IsNullOrEmpty(StringParameter))
			{
				return;
			}
			FsmEnum fsmEnum = new FsmEnum("");
			fsmEnum.EnumType = PropertyType;
			string value4 = StringParameter.Value;
			object obj3 = Enum.Parse(PropertyType, value4);
			if (obj3 != null)
			{
				Enum obj4 = obj3 as Enum;
				if (obj4 == null)
				{
					throw new InvalidCastException();
				}
			}
			fsmEnum.Value = (Enum)obj3;
			FsmString stringParameter = StringParameter;
			EnumParameter = fsmEnum;
			stringParameter.Value = null;
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0xCB0BA4", Offset = "0xCB0BA4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ED7600]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023621]) = v40;\nL_0015:\n\tv42 = ~this.initialized;\n\tif (v42) goto L_004E;\n\tv98 = HutongGames.PlayMaker.FsmObject::get_Value(this.TargetObject);\n\tgoto L_002D;\n\tv151 = *([v88 @ X8_v8+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_002D;\n\tv158 = v88;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v158, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002D:\n\tv82 = UnityEngine.Object::op_Inequality(this.targetObjectCached, v98);\n\tv160 = v82 == 0;\n\tv85 = ~v160;\n\tif (v85) goto L_004E;\n\tv104 = this.TargetObject;\n\tv84 = ~v104.useVariable;\n\tif (v84) goto L_0056;\n\tv81 = HutongGames.PlayMaker.FsmObject::get_ObjectType(v104);\n\tv58 = this.TargetType == v81;\n\tif (v58) goto L_0056;\nL_004E:\n\tHutongGames.PlayMaker.FsmProperty::Init(this);\n\treturn;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CheckForReinitialize()
		{
			if (initialized)
			{
				UnityEngine.Object value = TargetObject.Value;
				if (!(targetObjectCached != value))
				{
					FsmObject targetObject = TargetObject;
					if (!targetObject.UseVariable)
					{
						return;
					}
					Type objectType = targetObject.ObjectType;
					if ((object)TargetType == objectType)
					{
						return;
					}
				}
			}
			Init();
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0xCAFC38", Offset = "0xCAFC38", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F0D108]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023622]) = v40;\nL_0015:\n\tv42 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.BoolParameter = v42;\n\tv44 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.FloatParameter = v44;\n\tv46 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.IntParameter = v46;\n\tv50 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.StringParameter = v50;\n\tv54 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v54, \"\");\n\tthis.GameObjectParameter = v54;\n\tv61 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v61);\n\tthis.Vector2Parameter = v61;\n\tv67 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v67);\n\tthis.Vector3Parameter = v67;\n\tv73 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v73);\n\tthis.RectParamater = v73;\n\tv79 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v79);\n\tthis.QuaternionParameter = v79;\n\tv85 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v85);\n\tthis.ObjectParameter = v85;\n\tv91 = new HutongGames.PlayMaker.FsmMaterial();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v91);\n\tthis.MaterialParameter = v91;\n\tv97 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v97);\n\tthis.TextureParameter = v97;\n\tv103 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v103);\n\tthis.ColorParameter = v103;\n\tv108 = new HutongGames.PlayMaker.FsmEnum();\n\tv108.parsedIntValue = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v108);\n\tthis.EnumParameter = v108;\n\tv115 = new HutongGames.PlayMaker.FsmArray();\n\tv115.type = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v115);\n\tthis.ArrayParameter = v115;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResetParameters()
		{
			//IL_0154: Expected I4, but got I8
			FsmBool boolParameter = false;
			BoolParameter = boolParameter;
			FsmFloat floatParameter = 0f;
			FloatParameter = floatParameter;
			FsmInt intParameter = 0;
			IntParameter = intParameter;
			FsmString stringParameter = "";
			StringParameter = stringParameter;
			FsmGameObject gameObjectParameter = (FsmGameObject)new NamedVariable("");
			GameObjectParameter = gameObjectParameter;
			FsmVector2 vector2Parameter = new FsmVector2();
			Vector2Parameter = vector2Parameter;
			FsmVector3 vector3Parameter = new FsmVector3();
			Vector3Parameter = vector3Parameter;
			FsmRect rectParamater = (FsmRect)new NamedVariable();
			RectParamater = rectParamater;
			FsmQuaternion quaternionParameter = (FsmQuaternion)new NamedVariable();
			QuaternionParameter = quaternionParameter;
			FsmObject objectParameter = (FsmObject)new NamedVariable();
			ObjectParameter = objectParameter;
			FsmMaterial materialParameter = (FsmMaterial)new NamedVariable();
			MaterialParameter = materialParameter;
			FsmTexture textureParameter = (FsmTexture)new NamedVariable();
			TextureParameter = textureParameter;
			FsmColor colorParameter = new FsmColor();
			ColorParameter = colorParameter;
			FsmEnum fsmEnum = (FsmEnum)new NamedVariable();
			fsmEnum.parsedIntValue = -1;
			EnumParameter = fsmEnum;
			FsmArray fsmArray = (FsmArray)new NamedVariable();
			fsmArray.type = VariableType.Unknown;
			ArrayParameter = fsmArray;
		}
	}
}

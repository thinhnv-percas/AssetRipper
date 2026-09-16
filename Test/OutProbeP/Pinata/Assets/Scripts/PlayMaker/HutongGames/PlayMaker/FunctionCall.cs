using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000049")]
	public class FunctionCall
	{
		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x10")]
		public string FunctionName;

		[SerializeField]
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x18")]
		private string parameterType;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x20")]
		public FsmBool BoolParameter;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x28")]
		public FsmFloat FloatParameter;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x30")]
		public FsmInt IntParameter;

		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x38")]
		public FsmGameObject GameObjectParameter;

		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x40")]
		public FsmObject ObjectParameter;

		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x48")]
		public FsmString StringParameter;

		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 Vector2Parameter;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 Vector3Parameter;

		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x60")]
		public FsmRect RectParamater;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion QuaternionParameter;

		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x70")]
		public FsmMaterial MaterialParameter;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x78")]
		public FsmTexture TextureParameter;

		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x80")]
		public FsmColor ColorParameter;

		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x88")]
		public FsmEnum EnumParameter;

		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x90")]
		public FsmArray ArrayParameter;

		[Token(Token = "0x17000055")]
		public string ParameterType
		{
			[Token(Token = "0x6000151")]
			[Address(RVA = "0xE51884", Offset = "0xE51884", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.parameterType;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ParameterType;
			}
			[Token(Token = "0x6000152")]
			[Address(RVA = "0xE5188C", Offset = "0xE5188C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.parameterType = value;\n\treturn;\n")]
			set
			{
				ParameterType = value;
			}
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0xE5138C", Offset = "0xE5138C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED12F8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247AA]) = v38;\nL_0018:\n\tthis.FunctionName = \"\";\n\tSystem.Object::.ctor(this);\n\tHutongGames.PlayMaker.FunctionCall::ResetParameters(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FunctionCall()
		{
			FunctionName = "";
			ResetParameters();
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0xE515B0", Offset = "0xE515B0", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1ED5020]);\n\tv25 = *([v24 @ X8_v39]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20247AB]) = v43;\nL_001B:\n\tthis.FunctionName = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.FunctionName = source.FunctionName;\n\tthis.parameterType = source.parameterType;\n\tv56 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v56, source.BoolParameter);\n\tthis.BoolParameter = v56;\n\tv66 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v66, source.FloatParameter);\n\tthis.FloatParameter = v66;\n\tv102 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v102, source.IntParameter);\n\tthis.IntParameter = v102;\n\tv110 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v110, source.GameObjectParameter);\n\tthis.GameObjectParameter = v110;\n\tthis.ObjectParameter = source.ObjectParameter;\n\tv119 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v119, source.StringParameter);\n\tthis.StringParameter = v119;\n\tv125 = source.Vector2Parameter;\n\tv127 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v127, source.Vector2Parameter);\n\tv130 = source.Vector2Parameter == 0;\n\tif (v130) goto L_0065;\n\tv127.value = *([v125 @ X21_v7 (HutongGames.PlayMaker.NamedVariable)+38]);\n\tv127.value.y = *([v125 @ X21_v7 (HutongGames.PlayMaker.NamedVariable)+3C]);\nL_0065:\n\tthis.Vector2Parameter = v127;\n\tv137 = source.Vector3Parameter;\n\tv139 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v139, source.Vector3Parameter);\n\tv84 = source.Vector3Parameter == 0;\n\tif (v84) goto L_0076;\n\tv139.value = *([v137 @ X21_v8 (HutongGames.PlayMaker.NamedVariable)+38]);\n\tv139.value.y = *([v137 @ X21_v8 (HutongGames.PlayMaker.NamedVariable)+3C]);\n\tv139.value.z = *([v137 @ X21_v8 (HutongGames.PlayMaker.NamedVariable)+40]);\nL_0076:\n\tthis.Vector3Parameter = v139;\n\tv150 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v150, source.RectParamater);\n\tthis.RectParamater = v150;\n\tv158 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v158, source.QuaternionParameter);\n\tthis.QuaternionParameter = v158;\n\tv166 = new HutongGames.PlayMaker.FsmMaterial();\n\tHutongGames.PlayMaker.FsmMaterial::.ctor(v166, source.MaterialParameter);\n\tthis.MaterialParameter = v166;\n\tv174 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.FsmTexture::.ctor(v174, source.TextureParameter);\n\tthis.TextureParameter = v174;\n\tv182 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v182, source.ColorParameter);\n\tthis.ColorParameter = v182;\n\tv190 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v190, source.EnumParameter);\n\tthis.EnumParameter = v190;\n\tv82 = new HutongGames.PlayMaker.FsmArray();\n\tHutongGames.PlayMaker.FsmArray::.ctor(v82, source.ArrayParameter);\n\tthis.ArrayParameter = v82;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FunctionCall(FunctionCall source)
		{
			//IL_013e: Expected O, but got I
			//IL_0158: Expected F4, but got I
			//IL_0172: Expected O, but got I
			//IL_018c: Expected F4, but got I
			//IL_01a6: Expected F4, but got I
			base._002Ector();
			FunctionName = "";
			FunctionName = source.FunctionName;
			ParameterType = source.ParameterType;
			FsmBool boolParameter = new FsmBool(source.BoolParameter);
			BoolParameter = boolParameter;
			FsmFloat floatParameter = new FsmFloat(source.FloatParameter);
			FloatParameter = floatParameter;
			FsmInt intParameter = new FsmInt(source.IntParameter);
			IntParameter = intParameter;
			FsmGameObject gameObjectParameter = new FsmGameObject(source.GameObjectParameter);
			GameObjectParameter = gameObjectParameter;
			ObjectParameter = source.ObjectParameter;
			FsmString stringParameter = new FsmString(source.StringParameter);
			StringParameter = stringParameter;
			NamedVariable vector2Parameter = source.Vector2Parameter;
			FsmVector2 fsmVector = (FsmVector2)new NamedVariable(source.Vector2Parameter);
			if (source.Vector2Parameter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X21_v7 (HutongGames.PlayMaker.NamedVariable)+38]");
				fsmVector.value = (Vector2)0;
				ref Vector2 value = ref fsmVector.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X21_v7 (HutongGames.PlayMaker.NamedVariable)+3C]");
				value.y = 0f;
			}
			Vector2Parameter = fsmVector;
			NamedVariable vector3Parameter = source.Vector3Parameter;
			FsmVector3 fsmVector2 = (FsmVector3)new NamedVariable(source.Vector3Parameter);
			if (source.Vector3Parameter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X21_v8 (HutongGames.PlayMaker.NamedVariable)+38]");
				fsmVector2.value = (Vector3)0;
				ref Vector3 value2 = ref fsmVector2.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X21_v8 (HutongGames.PlayMaker.NamedVariable)+3C]");
				value2.y = 0f;
				ref Vector3 value3 = ref fsmVector2.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X21_v8 (HutongGames.PlayMaker.NamedVariable)+40]");
				value3.z = 0f;
			}
			Vector3Parameter = fsmVector2;
			FsmRect rectParamater = new FsmRect(source.RectParamater);
			RectParamater = rectParamater;
			FsmQuaternion quaternionParameter = new FsmQuaternion(source.QuaternionParameter);
			QuaternionParameter = quaternionParameter;
			FsmMaterial materialParameter = new FsmMaterial(source.MaterialParameter);
			MaterialParameter = materialParameter;
			FsmTexture textureParameter = new FsmTexture(source.TextureParameter);
			TextureParameter = textureParameter;
			FsmColor colorParameter = new FsmColor(source.ColorParameter);
			ColorParameter = colorParameter;
			FsmEnum enumParameter = new FsmEnum(source.EnumParameter);
			EnumParameter = enumParameter;
			FsmArray arrayParameter = new FsmArray(source.ArrayParameter);
			ArrayParameter = arrayParameter;
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0xE513EC", Offset = "0xE513EC", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EED908]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247AC]) = v38;\nL_0015:\n\tv41 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.BoolParameter = v41;\n\tv44 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.FloatParameter = v44;\n\tv47 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.IntParameter = v47;\n\tv52 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.StringParameter = v52;\n\tv56 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v56, \"\");\n\tthis.GameObjectParameter = v56;\n\tthis.ObjectParameter = 0;\n\tv63 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v63);\n\tthis.Vector2Parameter = v63;\n\tv68 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v68);\n\tthis.Vector3Parameter = v68;\n\tv73 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v73);\n\tthis.RectParamater = v73;\n\tv79 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v79);\n\tthis.QuaternionParameter = v79;\n\tv85 = new HutongGames.PlayMaker.FsmMaterial();\n\tHutongGames.PlayMaker.FsmMaterial::.ctor(v85);\n\tthis.MaterialParameter = v85;\n\tv91 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.FsmTexture::.ctor(v91);\n\tthis.TextureParameter = v91;\n\tv97 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v97);\n\tthis.ColorParameter = v97;\n\tv103 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v103);\n\tthis.EnumParameter = v103;\n\tv109 = new HutongGames.PlayMaker.FsmArray();\n\tHutongGames.PlayMaker.FsmArray::.ctor(v109);\n\tthis.ArrayParameter = v109;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResetParameters()
		{
			FsmBool boolParameter = false;
			BoolParameter = boolParameter;
			FsmFloat floatParameter = 0f;
			FloatParameter = floatParameter;
			FsmInt intParameter = 0;
			IntParameter = intParameter;
			FsmString stringParameter = "";
			StringParameter = stringParameter;
			FsmGameObject gameObjectParameter = new FsmGameObject("");
			GameObjectParameter = gameObjectParameter;
			ObjectParameter = null;
			FsmVector2 vector2Parameter = (FsmVector2)new NamedVariable();
			Vector2Parameter = vector2Parameter;
			FsmVector3 vector3Parameter = (FsmVector3)new NamedVariable();
			Vector3Parameter = vector3Parameter;
			FsmRect rectParamater = new FsmRect();
			RectParamater = rectParamater;
			FsmQuaternion quaternionParameter = new FsmQuaternion();
			QuaternionParameter = quaternionParameter;
			FsmMaterial materialParameter = new FsmMaterial();
			MaterialParameter = materialParameter;
			FsmTexture textureParameter = new FsmTexture();
			TextureParameter = textureParameter;
			FsmColor colorParameter = new FsmColor();
			ColorParameter = colorParameter;
			FsmEnum enumParameter = new FsmEnum();
			EnumParameter = enumParameter;
			FsmArray arrayParameter = new FsmArray();
			ArrayParameter = arrayParameter;
		}
	}
}

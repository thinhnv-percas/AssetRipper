using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755640", Offset = "0x755640")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755640", Offset = "0x755640")]
	[Token(Token = "0x20001C5")]
	public class DevicePlayFullScreenMovie : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEA04", Offset = "0x7AEA04")]
		[Token(Token = "0x4001397")]
		[FieldOffset(Offset = "0x50")]
		public FsmString moviePath;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEA50", Offset = "0x7AEA50")]
		[Token(Token = "0x4001398")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor fadeColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEA9C", Offset = "0x7AEA9C")]
		[Token(Token = "0x4001399")]
		[FieldOffset(Offset = "0x60")]
		public FullScreenMovieControlMode movieControlMode;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEAD4", Offset = "0x7AEAD4")]
		[Token(Token = "0x400139A")]
		[FieldOffset(Offset = "0x64")]
		public FullScreenMovieScalingMode movieScalingMode;

		[Token(Token = "0x6000979")]
		[Address(RVA = "0xB704C4", Offset = "0xB704C4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC6068]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20228F6]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.moviePath = v43;\n\tv45 = UnityEngine.Color::get_black();\n\tv51 = HutongGames.PlayMaker.FsmColor::op_Implicit(v45);\n\tthis.fadeColor = v51;\n\tthis.movieControlMode = 0x100000000;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_001e: Expected I4, but got I8
			FsmString fsmString = "";
			moviePath = fsmString;
			Color black = Color.black;
			FsmColor fsmColor = black;
			fadeColor = fsmColor;
			movieControlMode = FullScreenMovieControlMode.Full;
		}

		[Token(Token = "0x600097A")]
		[Address(RVA = "0xB70534", Offset = "0xB70534", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmString::get_Value(this.moviePath);\n\tv30 = this.fadeColor;\n\t// 25 MakeStruct v49 @ AGGB70574_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v30.value (UnityEngine.Color), v30.value.g (System.Single), v30.value.b (System.Single), v30.value.a (System.Single)\n\tv50 = UnityEngine.Handheld::PlayFullScreenMovie(v13, v49, this.movieControlMode, this.movieScalingMode);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = moviePath.Value;
			FsmColor fsmColor = fadeColor;
			Color bgColor = default(Color);
			bgColor.r = fsmColor.value.r;
			bgColor.g = fsmColor.value.g;
			bgColor.b = fsmColor.value.b;
			bgColor.a = fsmColor.value.a;
			bool flag = Handheld.PlayFullScreenMovie(value, bgColor, movieControlMode, movieScalingMode);
		}

		[Token(Token = "0x600097B")]
		[Address(RVA = "0xB70584", Offset = "0xB70584", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DevicePlayFullScreenMovie()
		{
		}
	}
}

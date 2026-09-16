using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75681C", Offset = "0x75681C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75681C", Offset = "0x75681C")]
	[Token(Token = "0x20001FB")]
	public class DrawFullscreenColor : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B1908", Offset = "0x7B1908")]
		[Token(Token = "0x400148C")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor color;

		[Token(Token = "0x6000A5F")]
		[Address(RVA = "0xB70B74", Offset = "0xB70B74", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_white();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.color = v17;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			Color white = Color.white;
			FsmColor fsmColor = white;
			color = fsmColor;
		}

		[Token(Token = "0x6000A60")]
		[Address(RVA = "0xB70BA4", Offset = "0xB70BA4", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EFB358]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20228FC]) = v46;\nL_001D:\n\tgoto L_0024;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0024:\n\tv61 = UnityEngine.GUI::get_color();\n\tv65 = this.color;\n\t// 52 MakeStruct v76 @ AGGB70C30_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v65.value (UnityEngine.Color), v65.value.g (System.Single), v65.value.b (System.Single), v65.value.a (System.Single)\n\tUnityEngine.GUI::set_color(v76);\n\tv80 = UnityEngine.Screen::get_width();\n\tv83 = UnityEngine.Screen::get_height();\n\tv96 = 0;\n\tv132 = 0x10CCF64(&v96 @ stack_-50_v1, 0, v30, v31, v32, v33, v34, v35, 0, 0, v80, v83, v40, v41, v42, v43);\n\tv134 = HutongGames.PlayMaker.ActionHelpers::get_WhiteTexture();\n\t// 75 MakeStruct v90 @ AGGB70C7C_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v137 @ stack_-4C, 0, v140 @ stack_-44\n\tUnityEngine.GUI::DrawTexture(v90, v134);\n\tUnityEngine.GUI::set_color(v61);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_00a2: Expected O, but got I4
			//IL_00da: Expected F4, but got O
			//IL_00f5: Expected F4, but got O
			Color color = GUI.color;
			FsmColor fsmColor = this.color;
			Color color2 = default(Color);
			color2.r = fsmColor.value.r;
			color2.g = fsmColor.value.g;
			color2.b = fsmColor.value.b;
			color2.a = fsmColor.value.a;
			GUI.color = color2;
			int width = Screen.width;
			int height = Screen.height;
			object obj = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Texture2D whiteTexture = ActionHelpers.WhiteTexture;
			Rect position = default(Rect);
			position.x = 0f;
			object obj2 = default(object);
			position.y = (float)obj2;
			position.width = 0f;
			object obj3 = default(object);
			position.height = (float)obj3;
			GUI.DrawTexture(position, whiteTexture);
			GUI.color = color;
		}

		[Token(Token = "0x6000A61")]
		[Address(RVA = "0xB70CB8", Offset = "0xB70CB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DrawFullscreenColor()
		{
		}
	}
}

using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754660", Offset = "0x754660")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754660", Offset = "0x754660")]
	[Token(Token = "0x2000192")]
	public class CameraFadeOut : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB82C", Offset = "0x7AB82C")]
		[Token(Token = "0x40012C7")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor color;

		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AB878", Offset = "0x7AB878")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB878", Offset = "0x7AB878")]
		[Token(Token = "0x40012C8")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat time;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB8DC", Offset = "0x7AB8DC")]
		[Token(Token = "0x40012C9")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB914", Offset = "0x7AB914")]
		[Token(Token = "0x40012CA")]
		[FieldOffset(Offset = "0x68")]
		public bool realTime;

		[Token(Token = "0x40012CB")]
		[FieldOffset(Offset = "0x6C")]
		private float startTime;

		[Token(Token = "0x40012CC")]
		[FieldOffset(Offset = "0x70")]
		private float currentTime;

		[Token(Token = "0x40012CD")]
		[FieldOffset(Offset = "0x74")]
		private Color colorLerp;

		[Token(Token = "0x6000899")]
		[Address(RVA = "0xA8E4C0", Offset = "0xA8E4C0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_black();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.color = v17;\n\tv20 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.time = v20;\n\tthis.finishEvent = 0;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			Color black = Color.black;
			FsmColor fsmColor = black;
			color = fsmColor;
			FsmFloat fsmFloat = 1f;
			time = fsmFloat;
			finishEvent = null;
		}

		[Token(Token = "0x600089A")]
		[Address(RVA = "0xA8E500", Offset = "0xA8E500", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v11;\n\tthis.currentTime = 0f;\n\tv13 = UnityEngine.Color::get_clear();\n\tthis.colorLerp = v13;\n\tthis.colorLerp.g = v13.g;\n\tthis.colorLerp.b = v13.b;\n\tthis.colorLerp.a = v13.a;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			startTime = realtimeSinceStartup;
			currentTime = 0f;
			Color color = (colorLerp = Color.clear);
			colorLerp.g = color.g;
			colorLerp.b = color.b;
			colorLerp.a = color.a;
		}

		[Token(Token = "0x600089B")]
		[Address(RVA = "0xA8E53C", Offset = "0xA8E53C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tv27 = ~this.realTime;\n\tif (v27) goto L_0018;\n\tv29 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv39 = v29 - this.startTime;\n\tgoto L_001B;\nL_0018:\n\tv32 = UnityEngine.Time::get_deltaTime();\n\tv39 = this.currentTime + v32;\nL_001B:\n\tthis.currentTime = v39;\n\tv42 = UnityEngine.Color::get_clear();\n\tv46 = this.color;\n\t*([v22 @ X29_v1-4]) = v42.a;\n\tv60 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv143 = this.currentTime / v60;\n\t// 60 MakeStruct v93 @ AGGA8E5F8_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v42 @ V0_v2 (UnityEngine.Color), v42.g (System.Single), v42.b (System.Single), [v22 @ X29_v1-4]\n\t// 61 MakeStruct v90 @ AGGA8E5F8_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v46.value (UnityEngine.Color), v46.value.g (System.Single), v46.value.b (System.Single), v46.value.a (System.Single)\n\tv128 = UnityEngine.Color::Lerp(v93, v90, v143);\n\tthis.colorLerp = v128;\n\tthis.colorLerp.g = v128.g;\n\tthis.colorLerp.b = v128.b;\n\tthis.colorLerp.a = v128.a;\n\tv129 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv63 = this.currentTime <= v129;\n\tif (v63) goto L_007A;\n\tv213 = this.finishEvent == 0;\n\tif (v213) goto L_007A;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\n\treturn;\nL_007A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00db: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			float num;
			if (realTime)
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				num = realtimeSinceStartup - startTime;
			}
			else
			{
				float deltaTime = Time.deltaTime;
				num = currentTime + deltaTime;
			}
			currentTime = num;
			Color clear = Color.clear;
			FsmColor fsmColor = this.color;
			_ = clear.a;
			float value = time.Value;
			float t = currentTime / value;
			Color a = default(Color);
			a.r = clear.r;
			a.g = clear.g;
			a.b = clear.b;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-4]");
			a.a = 0f;
			Color b = default(Color);
			b.r = fsmColor.value.r;
			b.g = fsmColor.value.g;
			b.b = fsmColor.value.b;
			b.a = fsmColor.value.a;
			Color color = (colorLerp = Color.Lerp(a, b, t));
			colorLerp.g = color.g;
			colorLerp.b = color.b;
			colorLerp.a = color.a;
			float value2 = time.Value;
			if (currentTime > value2 && finishEvent != null)
			{
				Fsm.Event(finishEvent);
			}
		}

		[Token(Token = "0x600089C")]
		[Address(RVA = "0xA8E67C", Offset = "0xA8E67C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F0BA88]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20221DB]) = v46;\nL_001D:\n\tgoto L_0024;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0024:\n\tv61 = UnityEngine.GUI::get_color();\n\t// 50 MakeStruct v75 @ AGGA8E704_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.colorLerp (UnityEngine.Color), this.colorLerp.g (System.Single), this.colorLerp.b (System.Single), this.colorLerp.a (System.Single)\n\tUnityEngine.GUI::set_color(v75);\n\tv77 = UnityEngine.Screen::get_width();\n\tv80 = UnityEngine.Screen::get_height();\n\tv84 = 0;\n\tv89 = 0x10CCF64(&v84 @ stack_-50_v1, 0, v30, v31, v32, v33, v34, v35, 0, 0, v77, v80, this.colorLerp.a, v41, v42, v43);\n\tv91 = HutongGames.PlayMaker.ActionHelpers::get_WhiteTexture();\n\t// 73 MakeStruct v99 @ AGGA8E750_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v94 @ stack_-4C, 0, v97 @ stack_-44\n\tUnityEngine.GUI::DrawTexture(v99, v91);\n\tUnityEngine.GUI::set_color(v61);\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_008c: Expected O, but got I4
			//IL_00c4: Expected F4, but got O
			//IL_00df: Expected F4, but got O
			Color color = GUI.color;
			Color color2 = default(Color);
			color2.r = colorLerp.r;
			color2.g = colorLerp.g;
			color2.b = colorLerp.b;
			color2.a = colorLerp.a;
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

		[Token(Token = "0x600089D")]
		[Address(RVA = "0xA8E784", Offset = "0xA8E784", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CameraFadeOut()
		{
		}
	}
}

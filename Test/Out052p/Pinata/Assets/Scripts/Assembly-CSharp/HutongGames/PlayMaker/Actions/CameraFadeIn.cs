using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754610", Offset = "0x754610")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754610", Offset = "0x754610")]
	[Token(Token = "0x2000191")]
	public class CameraFadeIn : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB70C", Offset = "0x7AB70C")]
		[Token(Token = "0x40012C0")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor color;

		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AB758", Offset = "0x7AB758")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB758", Offset = "0x7AB758")]
		[Token(Token = "0x40012C1")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat time;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB7BC", Offset = "0x7AB7BC")]
		[Token(Token = "0x40012C2")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB7F4", Offset = "0x7AB7F4")]
		[Token(Token = "0x40012C3")]
		[FieldOffset(Offset = "0x68")]
		public bool realTime;

		[Token(Token = "0x40012C4")]
		[FieldOffset(Offset = "0x6C")]
		private float startTime;

		[Token(Token = "0x40012C5")]
		[FieldOffset(Offset = "0x70")]
		private float currentTime;

		[Token(Token = "0x40012C6")]
		[FieldOffset(Offset = "0x74")]
		private Color colorLerp;

		[Token(Token = "0x6000894")]
		[Address(RVA = "0xA8E1C8", Offset = "0xA8E1C8", Length = "0x40")]
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

		[Token(Token = "0x6000895")]
		[Address(RVA = "0xA8E208", Offset = "0xA8E208", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv12 = this.color;\n\tthis.startTime = v11;\n\tthis.currentTime = 0f;\n\tthis.colorLerp.r = v12.value;\n\tthis.colorLerp.g = v12.value.g;\n\tthis.colorLerp.a = v12.value.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			FsmColor fsmColor = color;
			startTime = realtimeSinceStartup;
			currentTime = 0f;
			colorLerp.r = fsmColor.value.r;
			colorLerp.g = fsmColor.value.g;
			colorLerp.a = fsmColor.value.a;
		}

		[Token(Token = "0x6000896")]
		[Address(RVA = "0xA8E25C", Offset = "0xA8E25C", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tv27 = ~this.realTime;\n\tif (v27) goto L_0018;\n\tv29 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv39 = v29 - this.startTime;\n\tgoto L_001A;\nL_0018:\n\tv32 = UnityEngine.Time::get_deltaTime();\n\tv39 = this.currentTime + v32;\nL_001A:\n\tv41 = this.color;\n\tthis.currentTime = v39;\n\t*([v22 @ X29_v1-4]) = v41.value;\n\tv48 = UnityEngine.Color::get_clear();\n\tv145 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv146 = this.currentTime / v145;\n\t// 61 MakeStruct v91 @ AGGA8E320_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), [v22 @ X29_v1-4], v41.value.g (System.Single), v41.value.b (System.Single), v41.value.a (System.Single)\n\tv130 = UnityEngine.Color::Lerp(v91, v48, v146);\n\tthis.colorLerp = v130;\n\tthis.colorLerp.g = v130.g;\n\tthis.colorLerp.b = v130.b;\n\tthis.colorLerp.a = v130.a;\n\tv131 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv61 = this.currentTime <= v131;\n\tif (v61) goto L_007E;\n\tv217 = this.finishEvent == 0;\n\tif (v217) goto L_0070;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0070:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_007E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00ae: Expected F4, but got I
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
			FsmColor fsmColor = this.color;
			currentTime = num;
			_ = fsmColor.value;
			Color clear = Color.clear;
			float value = time.Value;
			float t = currentTime / value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-4]");
			Color a = default(Color);
			a.r = 0f;
			a.g = fsmColor.value.g;
			a.b = fsmColor.value.b;
			a.a = fsmColor.value.a;
			Color color = (colorLerp = Color.Lerp(a, clear, t));
			colorLerp.g = color.g;
			colorLerp.b = color.b;
			colorLerp.a = color.a;
			float value2 = time.Value;
			if (currentTime > value2)
			{
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
				Finish();
			}
		}

		[Token(Token = "0x6000897")]
		[Address(RVA = "0xA8E3B0", Offset = "0xA8E3B0", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB71A8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20221DA]) = v46;\nL_001D:\n\tgoto L_0024;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0024:\n\tv61 = UnityEngine.GUI::get_color();\n\t// 50 MakeStruct v75 @ AGGA8E438_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.colorLerp (UnityEngine.Color), this.colorLerp.g (System.Single), this.colorLerp.b (System.Single), this.colorLerp.a (System.Single)\n\tUnityEngine.GUI::set_color(v75);\n\tv77 = UnityEngine.Screen::get_width();\n\tv80 = UnityEngine.Screen::get_height();\n\tv84 = 0;\n\tv89 = 0x10CCF64(&v84 @ stack_-50_v1, 0, v30, v31, v32, v33, v34, v35, 0, 0, v77, v80, this.colorLerp.a, v41, v42, v43);\n\tv91 = HutongGames.PlayMaker.ActionHelpers::get_WhiteTexture();\n\t// 73 MakeStruct v99 @ AGGA8E484_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v94 @ stack_-4C, 0, v97 @ stack_-44\n\tUnityEngine.GUI::DrawTexture(v99, v91);\n\tUnityEngine.GUI::set_color(v61);\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_008c: Expected O, but got I4
			//IL_00bf: Expected F4, but got O
			//IL_00da: Expected F4, but got O
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
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
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

		[Token(Token = "0x6000898")]
		[Address(RVA = "0xA8E4B8", Offset = "0xA8E4B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CameraFadeIn()
		{
		}
	}
}

using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755C20", Offset = "0x755C20")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755C20", Offset = "0x755C20")]
	[Token(Token = "0x20001D6")]
	public class Flicker : ComponentAction<Renderer>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFE1C", Offset = "0x7AFE1C")]
		[Token(Token = "0x400140D")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AFE68", Offset = "0x7AFE68")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFE68", Offset = "0x7AFE68")]
		[Token(Token = "0x400140E")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat frequency;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AFEBC", Offset = "0x7AFEBC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFEBC", Offset = "0x7AFEBC")]
		[Token(Token = "0x400140F")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat amountOn;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFF10", Offset = "0x7AFF10")]
		[Token(Token = "0x4001410")]
		[FieldOffset(Offset = "0x78")]
		public bool rendererOnly;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFF48", Offset = "0x7AFF48")]
		[Token(Token = "0x4001411")]
		[FieldOffset(Offset = "0x79")]
		public bool realTime;

		[Token(Token = "0x4001412")]
		[FieldOffset(Offset = "0x7C")]
		private float startTime;

		[Token(Token = "0x4001413")]
		[FieldOffset(Offset = "0x80")]
		private float timer;

		[Token(Token = "0x60009C3")]
		[Address(RVA = "0xB759A0", Offset = "0xB759A0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.1f);\n\tthis.frequency = v13;\n\tv16 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.amountOn = v16;\n\tthis.rendererOnly = 1;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 0.1f;
			frequency = fsmFloat;
			FsmFloat fsmFloat2 = 0.5f;
			amountOn = fsmFloat2;
			rendererOnly = true;
			realTime = false;
		}

		[Token(Token = "0x60009C4")]
		[Address(RVA = "0xB759EC", Offset = "0xB759EC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v11;\n\tthis.timer = 0f;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			startTime = realtimeSinceStartup;
			timer = 0f;
		}

		[Token(Token = "0x60009C5")]
		[Address(RVA = "0xB75A18", Offset = "0xB75A18", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EBEB08]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022928]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.Flicker)+30]), this.gameObject);\n\tgoto L_002D;\n\tv147 = *([v117 @ X8_v7+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_002D;\n\tv155 = v117;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v155, v47, v48, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv154 = UnityEngine.Object::op_Equality(v49, 0);\n\tv157 = v154 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_009A;\n\tv206 = ~this.realTime;\n\tif (v206) goto L_003D;\n\tv225 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv83 = this + 0x80;\n\tv81 = v225 - this.startTime;\n\tthis.timer = v81;\n\tgoto L_0047;\nL_003D:\n\tv83 = this + 0x80;\n\tv230 = UnityEngine.Time::get_deltaTime();\n\tv81 = this.timer + v230;\n\tthis.timer = v81;\nL_0047:\n\tv218 = HutongGames.PlayMaker.FsmFloat::get_Value(this.frequency);\n\tv53 = v81 <= v218;\n\tif (v53) goto L_009A;\n\tv88 = UnityEngine.Random::Range(0f, 1f);\n\tv89 = HutongGames.PlayMaker.FsmFloat::get_Value(this.amountOn);\n\tv241 = ~this.rendererOnly;\n\tif (v241) goto L_0084;\n\tv246 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v49);\n\tv248 = v246 == 0;\n\tif (v248) goto L_0090;\n\tv103 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv269 = v88 - v89;\n\tv268 = v269 < 0;\n\tUnityEngine.Renderer::set_enabled(v103, v268);\n\tgoto L_0090;\nL_0084:\n\tv251 = v88 - v89;\n\tv252 = v251 < 0;\n\tUnityEngine.GameObject::SetActive(v49, v252);\nL_0090:\n\tthis.startTime = this.timer;\n\tthis.timer = 0f;\nL_009A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_001c: Expected O, but got I
			//IL_00b7: Expected O, but got I
			//IL_008b: Expected O, but got I
			//IL_01fa: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.Flicker)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			float num;
			if (realTime)
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				obj = (long)(IntPtr)this + 128L;
				num = (timer = realtimeSinceStartup - startTime);
			}
			else
			{
				obj = (long)(IntPtr)this + 128L;
				float deltaTime = Time.deltaTime;
				num = (timer += deltaTime);
			}
			float value = frequency.Value;
			if (!(num > value))
			{
				return;
			}
			float num2 = UnityEngine.Random.Range(0f, 1f);
			float value2 = amountOn.Value;
			if (rendererOnly)
			{
				if (UpdateCache(ownerDefaultTarget))
				{
					Renderer renderer = base.renderer;
					float num3 = num2 - value2;
					bool flag = num3 < 0f;
					renderer.enabled = flag;
				}
			}
			else
			{
				float num4 = num2 - value2;
				bool flag2 = num4 < 0f;
				ownerDefaultTarget.SetActive(flag2);
			}
			startTime = (float)obj;
			timer = 0f;
		}

		[Token(Token = "0x60009C6")]
		[Address(RVA = "0xB75BB0", Offset = "0xB75BB0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED5570]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022929]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Flicker()
		{
		}
	}
}

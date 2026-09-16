using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755BD0", Offset = "0x755BD0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755BD0", Offset = "0x755BD0")]
	[Token(Token = "0x20001D5")]
	public class Blink : ComponentAction<Renderer>
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AFC80", Offset = "0x7AFC80")]
		[Token(Token = "0x4001404")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AFCCC", Offset = "0x7AFCCC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AFCCC", Offset = "0x7AFCCC")]
		[Token(Token = "0x4001405")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat timeOff;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AFD20", Offset = "0x7AFD20")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AFD20", Offset = "0x7AFD20")]
		[Token(Token = "0x4001406")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat timeOn;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AFD74", Offset = "0x7AFD74")]
		[Token(Token = "0x4001407")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool startOn;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AFDAC", Offset = "0x7AFDAC")]
		[Token(Token = "0x4001408")]
		[FieldOffset(Offset = "0x80")]
		public bool rendererOnly;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AFDE4", Offset = "0x7AFDE4")]
		[Token(Token = "0x4001409")]
		[FieldOffset(Offset = "0x81")]
		public bool realTime;

		[Token(Token = "0x400140A")]
		[FieldOffset(Offset = "0x84")]
		private float startTime;

		[Token(Token = "0x400140B")]
		[FieldOffset(Offset = "0x88")]
		private float timer;

		[Token(Token = "0x400140C")]
		[FieldOffset(Offset = "0x8C")]
		private bool blinkOn;

		[Token(Token = "0x60009BE")]
		[Address(RVA = "0xA8BCA4", Offset = "0xA8BCA4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv15 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.timeOff = v15;\n\tv18 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.timeOn = v18;\n\tthis.rendererOnly = 1;\n\tv22 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.startOn = v22;\n\tthis.realTime = 0;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 0.5f;
			timeOff = fsmFloat;
			FsmFloat fsmFloat2 = 0.5f;
			timeOn = fsmFloat2;
			rendererOnly = true;
			FsmBool fsmBool = false;
			startOn = fsmBool;
			realTime = false;
		}

		[Token(Token = "0x60009BF")]
		[Address(RVA = "0xA8BD0C", Offset = "0xA8BD0C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v11;\n\tthis.timer = 0f;\n\tv15 = HutongGames.PlayMaker.FsmBool::get_Value(this.startOn);\n\tHutongGames.PlayMaker.Actions.Blink::UpdateBlinkState(this, v15);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			startTime = realtimeSinceStartup;
			timer = 0f;
			bool value = startOn.Value;
			UpdateBlinkState(value);
		}

		[Token(Token = "0x60009C0")]
		[Address(RVA = "0xA8BE80", Offset = "0xA8BE80", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this.realTime;\n\tif (v13) goto L_0011;\n\tv15 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv22 = v15 - this.startTime;\n\tgoto L_0014;\nL_0011:\n\tv18 = UnityEngine.Time::get_deltaTime();\n\tv22 = this.timer + v18;\nL_0014:\n\tthis.timer = v22;\n\tv28 = ~this.blinkOn;\n\tif (v28) goto L_0035;\n\tv62 = HutongGames.PlayMaker.FsmFloat::get_Value(this.timeOn);\n\tv32 = v22 <= v62;\n\tif (v32) goto L_002D;\n\tHutongGames.PlayMaker.Actions.Blink::UpdateBlinkState(this, 0);\nL_002D:\n\tv119 = ~this.blinkOn;\n\tv66 = ~v119;\n\tif (v66) goto L_0051;\nL_0035:\n\tv101 = HutongGames.PlayMaker.FsmFloat::get_Value(this.timeOff);\n\tv116 = this.timer <= v101;\n\tif (v116) goto L_0051;\n\tHutongGames.PlayMaker.Actions.Blink::UpdateBlinkState(this, 1);\n\treturn;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			float num;
			if (realTime)
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				num = realtimeSinceStartup - startTime;
			}
			else
			{
				float deltaTime = Time.deltaTime;
				num = timer + deltaTime;
			}
			timer = num;
			if (blinkOn)
			{
				float value = timeOn.Value;
				if (num > value)
				{
					UpdateBlinkState(state: false);
				}
				if (blinkOn)
				{
					return;
				}
			}
			float value2 = timeOff.Value;
			if (timer > value2)
			{
				UpdateBlinkState(state: true);
			}
		}

		[Token(Token = "0x60009C1")]
		[Address(RVA = "0xA8BD54", Offset = "0xA8BD54", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0B618]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, state, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20221CC]) = v41;\nL_0015:\n\tv42 = this.gameObject;\n\tv45 = v42.ownerOption == 0;\n\tif (v45) goto L_0022;\n\tv78 = HutongGames.PlayMaker.FsmGameObject::get_Value(v42.gameObject);\n\tgoto L_0029;\nL_0022:\n\tv59 = *([this @ X0 (HutongGames.PlayMaker.Actions.Blink)+20]);\nL_0029:\n\tgoto L_0032;\n\tv89 = *([v85 @ X0_v7+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tgoto L_0032;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v85, v79, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0032:\n\tv53 = UnityEngine.Object::op_Equality(v59, 0);\n\tv121 = v53 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0060;\n\tv123 = ~this.rendererOnly;\n\tif (v123) goto L_0053;\n\tv134 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v59);\n\tv136 = v134 == 0;\n\tif (v136) goto L_0056;\n\tv70 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_enabled(v70, state);\n\tgoto L_0056;\nL_0053:\n\tUnityEngine.GameObject::SetActive(v59, state);\nL_0056:\n\tthis.blinkOn = state;\n\tv124 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v124;\n\tthis.timer = 0f;\nL_0060:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateBlinkState(bool state)
		{
			//IL_0056: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = this.gameObject;
			GameObject gameObject;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				gameObject = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.Blink)+20]");
				gameObject = (GameObject)0;
			}
			if (gameObject == null)
			{
				return;
			}
			if (rendererOnly)
			{
				if (UpdateCache(gameObject))
				{
					Renderer renderer = base.renderer;
					renderer.enabled = state;
				}
			}
			else
			{
				gameObject.SetActive(state);
			}
			blinkOn = state;
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			startTime = realtimeSinceStartup;
			timer = 0f;
		}

		[Token(Token = "0x60009C2")]
		[Address(RVA = "0xA8BF40", Offset = "0xA8BF40", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED1990]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221CD]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Blink()
		{
		}
	}
}

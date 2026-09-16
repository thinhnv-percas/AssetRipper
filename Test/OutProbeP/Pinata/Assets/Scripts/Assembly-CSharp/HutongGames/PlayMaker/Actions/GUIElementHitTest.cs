using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756A1C", Offset = "0x756A1C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756A1C", Offset = "0x756A1C")]
	[Obsolete]
	[Token(Token = "0x2000202")]
	public class GUIElementHitTest : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B1C44", Offset = "0x7B1C44")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1C44", Offset = "0x7B1C44")]
		[Token(Token = "0x40014A7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1CDC", Offset = "0x7B1CDC")]
		[Token(Token = "0x40014A8")]
		[FieldOffset(Offset = "0x58")]
		public Camera camera;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1D14", Offset = "0x7B1D14")]
		[Token(Token = "0x40014A9")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 screenPoint;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1D4C", Offset = "0x7B1D4C")]
		[Token(Token = "0x40014AA")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat screenX;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1D84", Offset = "0x7B1D84")]
		[Token(Token = "0x40014AB")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat screenY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1DBC", Offset = "0x7B1DBC")]
		[Token(Token = "0x40014AC")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool normalized;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1DF4", Offset = "0x7B1DF4")]
		[Token(Token = "0x40014AD")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent hitEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1E2C", Offset = "0x7B1E2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1E2C", Offset = "0x7B1E2C")]
		[Token(Token = "0x40014AE")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1E7C", Offset = "0x7B1E7C")]
		[Token(Token = "0x40014AF")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool everyFrame;

		[Token(Token = "0x40014B0")]
		[FieldOffset(Offset = "0x98")]
		private GUIElement guiElement;

		[Token(Token = "0x40014B1")]
		[FieldOffset(Offset = "0xA0")]
		private GameObject gameObjectCached;

		[Token(Token = "0x6000A73")]
		[Address(RVA = "0xB78378", Offset = "0xB78378", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDA198]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022940]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tthis.camera = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.screenPoint = v46;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.screenX = v54;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.screenY = v61;\n\tv92 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.normalized = v92;\n\tthis.hitEvent = 0;\n\tv79 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.everyFrame = v79;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			camera = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			screenPoint = fsmVector;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			screenX = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			screenY = fsmFloat2;
			FsmBool fsmBool = true;
			normalized = fsmBool;
			hitEvent = null;
			FsmBool fsmBool2 = true;
			everyFrame = fsmBool2;
		}

		[Token(Token = "0x6000A74")]
		[Address(RVA = "0xB78464", Offset = "0xB78464", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GUIElementHitTest::DoHitTest(this);\n\tv14 = HutongGames.PlayMaker.FsmBool::get_Value(this.everyFrame);\n\tv31 = v14 == 0;\n\tif (v31) goto L_001A;\n\treturn;\nL_001A:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoHitTest();
			if (!everyFrame.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A75")]
		[Address(RVA = "0xB78778", Offset = "0xB78778", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GUIElementHitTest::DoHitTest(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoHitTest();
		}

		[Token(Token = "0x6000A76")]
		[Address(RVA = "0xB784B0", Offset = "0xB784B0", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EC7048]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022941]) = v50;\nL_001E:\n\tv55 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0030;\n\tv170 = *([v137 @ X8_v5+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0030;\n\tv180 = v137;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v180, v53, v54, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0030:\n\tv179 = UnityEngine.Object::op_Equality(v55, 0);\n\tv182 = v179 == 0;\n\tif (v182) goto L_0045;\nL_003F:\n\treturn;\nL_0045:\n\tgoto L_004E;\n\tv252 = *([v248 @ X0_v12+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\tif (v254) goto L_004E;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v248, v177, v178, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004E:\n\tv160 = UnityEngine.Object::op_Inequality(v55, this.gameObjectCached);\n\tv260 = v160 == 0;\n\tif (v260) goto L_0069;\n\tv268 = UnityEngine.GameObject::GetComponent(v55);\n\tv284 = v268 == 0;\n\tv276 = ~v284;\n\tif (v276) goto L_0064;\n\tv297 = UnityEngine.GameObject::GetComponent(v55);\nL_0064:\n\tv90 = this + 0x98;\n\tthis.guiElement = v269;\n\tthis.gameObjectCached = v55;\n\tgoto L_006F;\nL_0069:\n\tv90 = this + 0x98;\nL_006F:\n\tgoto L_0078;\n\tv285 = *([v279 @ X0_v17+E0]);\n\tv286 = v285 == 0;\n\tv287 = ~v286;\n\tgoto L_0078;\n\tv289 = \"il2cpp_codegen_runtime_class_init\"(v279, v271, v156, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0078:\n\tv292 = UnityEngine.Object::op_Equality(v88, 0);\n\tv228 = v292 == 0;\n\tif (v228) goto L_008F;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_008F:\n\tv301 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenPoint);\n\tv303 = v301 == 0;\n\tif (v303) goto L_00A2;\n\tv305 = 0;\n\tv310 = 0x1589D20(&v305 @ stack_-60_v4 (UnityEngine.Vector3), 0, 0, v35, v36, v37, v38, v39, 0, 0, v42, v43, v44, v45, v46, v47);\n\tgoto L_00AC;\nL_00A2:\n\tv316 = HutongGames.PlayMaker.FsmVector3::get_Value(this.screenPoint);\nL_00AC:\n\tv324 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenX);\n\tv326 = v324 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_00BB;\n\tv328 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenX);\nL_00BB:\n\tv333 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenY);\n\tv335 = v333 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_00CA;\n\tv337 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenY);\nL_00CA:\n\tv342 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv344 = v342 == 0;\n\tif (v344) goto L_00DE;\n\tv346 = UnityEngine.Screen::get_width();\n\tv84 = v84 * v346;\n\tv351 = UnityEngine.Screen::get_height();\n\tv79 = v79 * v351;\nL_00DE:\n\t// 222 MakeStruct v58 @ AGGB78734_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v84 @ V9_v3 (UnityEngine.Vector3), v79 @ V10_v5 (System.Single), v82 @ V8_v3 (System.Single)\n\tv161 = UnityEngine.GUIElement::HitTest(*([v90 @ X22_v3]), v58, this.camera);\n\tv132 = this.storeResult;\n\tv247 = v161 == 0;\n\tif (v247) goto L_00EF;\n\tv132.value = 1;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.hitEvent);\n\tgoto L_003F;\nL_00EF:\n\tv132.value = 0;\n\tgoto L_003F;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 160 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoHitTest()
		{
			//IL_00e3: Expected O, but got I
			//IL_0381: Expected O, but got I
			//IL_020d: Expected O, but got F4
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected O, but got Unknown
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			UnityEngine.Object obj2;
			if (ownerDefaultTarget != gameObjectCached)
			{
				GUITexture component = ownerDefaultTarget.GetComponent<GUITexture>();
				bool flag = (object)component == null;
				bool flag2 = !flag;
				GUIElement gUIElement = component;
				if (!flag2)
				{
					GUIText component2 = ownerDefaultTarget.GetComponent<GUIText>();
					gUIElement = component2;
				}
				obj = (long)(IntPtr)this + 152L;
				guiElement = gUIElement;
				gameObjectCached = ownerDefaultTarget;
				obj2 = gUIElement;
			}
			else
			{
				obj = (long)(IntPtr)this + 152L;
				obj2 = guiElement;
			}
			if (obj2 == null)
			{
				Finish();
				return;
			}
			float num;
			float z;
			Vector3 vector2;
			if (screenPoint.IsNone)
			{
				Vector3 vector = default(Vector3);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1589D20 (inside UnityEngine.Vector2Int::.cctor +0x90)");
				float num2 = default(float);
				num = num2;
				z = 0f;
				vector2 = default(Vector3);
			}
			else
			{
				Vector3 value = screenPoint.Value;
				num = value.y;
				z = value.z;
				vector2 = value;
			}
			if (!screenX.IsNone)
			{
				float value2 = screenX.Value;
				vector2 = (Vector3)value2;
			}
			if (!screenY.IsNone)
			{
				float value3 = screenY.Value;
				num = value3;
			}
			if (normalized.Value)
			{
				int width = Screen.width;
				vector2 *= width;
				int height = Screen.height;
				num *= (float)height;
			}
			Vector3 screenPosition = default(Vector3);
			screenPosition.x = vector2.x;
			screenPosition.y = num;
			screenPosition.z = z;
			bool flag3 = ((GUIElement)obj).HitTest(screenPosition, camera);
			FsmBool fsmBool = storeResult;
			if (flag3)
			{
				fsmBool.value = true;
				Fsm.Event(hitEvent);
			}
			else
			{
				fsmBool.value = false;
			}
		}

		[Token(Token = "0x6000A77")]
		[Address(RVA = "0xB7877C", Offset = "0xB7877C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUIElementHitTest()
		{
		}
	}
}

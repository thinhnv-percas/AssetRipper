using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75494C", Offset = "0x75494C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75494C", Offset = "0x75494C")]
	[Token(Token = "0x200019A")]
	public class WorldToScreenPoint : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABF88", Offset = "0x7ABF88")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABF88", Offset = "0x7ABF88")]
		[Token(Token = "0x40012E8")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 worldPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABFD8", Offset = "0x7ABFD8")]
		[Token(Token = "0x40012E9")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat worldX;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC010", Offset = "0x7AC010")]
		[Token(Token = "0x40012EA")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat worldY;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC048", Offset = "0x7AC048")]
		[Token(Token = "0x40012EB")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat worldZ;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AC080", Offset = "0x7AC080")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC080", Offset = "0x7AC080")]
		[Token(Token = "0x40012EC")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 storeScreenPoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AC0D0", Offset = "0x7AC0D0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC0D0", Offset = "0x7AC0D0")]
		[Token(Token = "0x40012ED")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat storeScreenX;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AC120", Offset = "0x7AC120")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC120", Offset = "0x7AC120")]
		[Token(Token = "0x40012EE")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat storeScreenY;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC170", Offset = "0x7AC170")]
		[Token(Token = "0x40012EF")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool normalize;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC1A8", Offset = "0x7AC1A8")]
		[Token(Token = "0x40012F0")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x60008BD")]
		[Address(RVA = "0x98A83C", Offset = "0x98A83C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEFF50]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20216CB]) = v42;\nL_0015:\n\tthis.worldPosition = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.worldX = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.worldY = v52;\n\tv58 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v58);\n\tv58.useVariable = 1;\n\tthis.everyFrame = 0;\n\tthis.storeScreenX = 0;\n\tthis.storeScreenY = 0;\n\tthis.worldZ = v58;\n\tthis.storeScreenPoint = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			worldPosition = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			worldX = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			worldY = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			everyFrame = false;
			storeScreenX = null;
			storeScreenY = null;
			worldZ = fsmFloat3;
			storeScreenPoint = null;
		}

		[Token(Token = "0x60008BE")]
		[Address(RVA = "0x98A908", Offset = "0x98A908", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.WorldToScreenPoint::DoWorldToScreenPoint(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoWorldToScreenPoint();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008BF")]
		[Address(RVA = "0x98AB7C", Offset = "0x98AB7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.WorldToScreenPoint::DoWorldToScreenPoint(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoWorldToScreenPoint();
		}

		[Token(Token = "0x60008C0")]
		[Address(RVA = "0x98A944", Offset = "0x98A944", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED7DB0]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20216CC]) = v44;\nL_0017:\n\tv46 = UnityEngine.Camera::get_main();\n\tgoto L_0029;\n\tv54 = *([v50 @ X8_v5+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv65 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0029:\n\tv64 = UnityEngine.Object::op_Equality(v46, 0);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0045;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"No MainCamera defined!\");\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0045:\n\tgoto L_004C;\n\tv88 = *([v75 @ X0_v7+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_004C;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v75, v62, v63, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004C:\n\tv96 = UnityEngine.Vector3::get_zero();\n\tv148 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.worldPosition);\n\tv203 = v148 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_0069;\n\tv215 = HutongGames.PlayMaker.FsmVector3::get_Value(this.worldPosition);\nL_0069:\n\tv222 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.worldX);\n\tv224 = v222 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_0078;\n\tv226 = HutongGames.PlayMaker.FsmFloat::get_Value(this.worldX);\nL_0078:\n\tv231 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.worldY);\n\tv233 = v231 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_0087;\n\tv235 = HutongGames.PlayMaker.FsmFloat::get_Value(this.worldY);\nL_0087:\n\tv240 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.worldZ);\n\tv242 = v240 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_0093;\n\tv244 = HutongGames.PlayMaker.FsmFloat::get_Value(this.worldZ);\nL_0093:\n\tv186 = UnityEngine.Camera::get_main();\n\t// 154 MakeStruct v106 @ AGG98AAF0_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v166 @ V8_v5 (UnityEngine.Vector3), v170 @ V9_v5 (System.Single), v162 @ V10_v5 (System.Single)\n\tv159 = UnityEngine.Camera::WorldToScreenPoint(v186, v106);\n\tv253 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalize);\n\tv255 = v253 == 0;\n\tif (v255) goto L_00B1;\n\tv257 = UnityEngine.Screen::get_width();\n\tv260 = v159 / v257;\n\tv261 = UnityEngine.Screen::get_height();\n\tv205 = v159.y / v261;\nL_00B1:\n\tv211 = this.storeScreenPoint;\n\tv211.value = v206;\n\tv211.value.y = v205;\n\tv211.value.z = v159.z;\n\tv210 = this.storeScreenX;\n\tv210.value = v206;\n\tv141 = this.storeScreenY;\n\tv141.value = v205;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoWorldToScreenPoint()
		{
			//IL_0137: Expected O, but got F4
			//IL_02ae: Expected O, but got F4
			Camera main = Camera.main;
			if (main == null)
			{
				LogError("No MainCamera defined!");
				Finish();
				return;
			}
			Vector3 zero = Vector3.zero;
			bool isNone = worldPosition.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float z = zero.z;
			Vector3 vector = zero;
			float y = zero.y;
			if (!flag2)
			{
				Vector3 value = worldPosition.Value;
				z = value.z;
				vector = value;
				y = value.y;
			}
			if (!worldX.IsNone)
			{
				float value2 = worldX.Value;
				vector = (Vector3)value2;
			}
			if (!worldY.IsNone)
			{
				float value3 = worldY.Value;
				y = value3;
			}
			if (!worldZ.IsNone)
			{
				float value4 = worldZ.Value;
				z = value4;
			}
			Camera main2 = Camera.main;
			Vector3 position = default(Vector3);
			position.x = vector.x;
			position.y = y;
			position.z = z;
			Vector3 vector2 = main2.WorldToScreenPoint(position);
			bool value5 = normalize.Value;
			bool flag3 = !value5;
			float num = vector2.y;
			Vector3 value6 = vector2;
			if (!flag3)
			{
				int width = Screen.width;
				float num2 = vector2.x / (float)width;
				int height = Screen.height;
				num = vector2.y / (float)height;
				value6 = (Vector3)num2;
			}
			FsmVector3 fsmVector = storeScreenPoint;
			fsmVector.value = value6;
			fsmVector.value.y = num;
			fsmVector.value.z = vector2.z;
			FsmFloat fsmFloat = storeScreenX;
			fsmFloat.Value = value6.x;
			FsmFloat fsmFloat2 = storeScreenY;
			fsmFloat2.Value = num;
		}

		[Token(Token = "0x60008C1")]
		[Address(RVA = "0x98AB80", Offset = "0x98AB80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WorldToScreenPoint()
		{
		}
	}
}

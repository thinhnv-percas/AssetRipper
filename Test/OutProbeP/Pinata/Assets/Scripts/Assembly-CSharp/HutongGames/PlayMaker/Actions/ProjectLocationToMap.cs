using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755910", Offset = "0x755910")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755910", Offset = "0x755910")]
	[Token(Token = "0x20001CE")]
	public class ProjectLocationToMap : FsmStateAction
	{
		[Token(Token = "0x2000488")]
		public enum MapProjection
		{
			[Token(Token = "0x400216B")]
			EquidistantCylindrical = 0,
			[Token(Token = "0x400216C")]
			Mercator = 1
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF078", Offset = "0x7AF078")]
		[Token(Token = "0x40013C5")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 GPSLocation;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF0B0", Offset = "0x7AF0B0")]
		[Token(Token = "0x40013C6")]
		[FieldOffset(Offset = "0x58")]
		public MapProjection mapProjection;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AF0E8", Offset = "0x7AF0E8")]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AF0E8", Offset = "0x7AF0E8")]
		[Token(Token = "0x40013C7")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat minLongitude;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AF144", Offset = "0x7AF144")]
		[Token(Token = "0x40013C8")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat maxLongitude;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AF164", Offset = "0x7AF164")]
		[Token(Token = "0x40013C9")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat minLatitude;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AF184", Offset = "0x7AF184")]
		[Token(Token = "0x40013CA")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat maxLatitude;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AF1A4", Offset = "0x7AF1A4")]
		[Token(Token = "0x40013CB")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat minX;

		[Token(Token = "0x40013CC")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat minY;

		[Token(Token = "0x40013CD")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat width;

		[Token(Token = "0x40013CE")]
		[FieldOffset(Offset = "0x98")]
		public FsmFloat height;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AF1DC", Offset = "0x7AF1DC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF1DC", Offset = "0x7AF1DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF1DC", Offset = "0x7AF1DC")]
		[Token(Token = "0x40013CF")]
		[FieldOffset(Offset = "0xA0")]
		public FsmFloat projectedX;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF250", Offset = "0x7AF250")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF250", Offset = "0x7AF250")]
		[Token(Token = "0x40013D0")]
		[FieldOffset(Offset = "0xA8")]
		public FsmFloat projectedY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF2A0", Offset = "0x7AF2A0")]
		[Token(Token = "0x40013D1")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool normalized;

		[Token(Token = "0x40013D2")]
		[FieldOffset(Offset = "0xB8")]
		public bool everyFrame;

		[Token(Token = "0x40013D3")]
		[FieldOffset(Offset = "0xBC")]
		private float x;

		[Token(Token = "0x40013D4")]
		[FieldOffset(Offset = "0xC0")]
		private float y;

		[Token(Token = "0x600099D")]
		[Address(RVA = "0xB1B1C4", Offset = "0xB1B1C4", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EEF9F8]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022577]) = v40;\nL_0017:\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.GPSLocation = v44;\n\tthis.mapProjection = 0;\n\tv52 = HutongGames.PlayMaker.FsmFloat::op_Implicit(-180f);\n\tthis.minLongitude = v52;\n\tv58 = HutongGames.PlayMaker.FsmFloat::op_Implicit(180f);\n\tthis.maxLongitude = v58;\n\tv62 = HutongGames.PlayMaker.FsmFloat::op_Implicit(-90f);\n\tthis.minLatitude = v62;\n\tv83 = HutongGames.PlayMaker.FsmFloat::op_Implicit(90f);\n\tthis.maxLatitude = v83;\n\tv86 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.minX = v86;\n\tv89 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.minY = v89;\n\tv93 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.width = v93;\n\tv95 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.height = v95;\n\tv72 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.projectedY = 0;\n\tthis.normalized = v72;\n\tthis.everyFrame = 0;\n\tthis.projectedX = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			GPSLocation = fsmVector;
			mapProjection = default(MapProjection);
			FsmFloat fsmFloat = -180f;
			minLongitude = fsmFloat;
			FsmFloat fsmFloat2 = 180f;
			maxLongitude = fsmFloat2;
			FsmFloat fsmFloat3 = -90f;
			minLatitude = fsmFloat3;
			FsmFloat fsmFloat4 = 90f;
			maxLatitude = fsmFloat4;
			FsmFloat fsmFloat5 = 0f;
			minX = fsmFloat5;
			FsmFloat fsmFloat6 = 0f;
			minY = fsmFloat6;
			FsmFloat fsmFloat7 = 1f;
			width = fsmFloat7;
			FsmFloat fsmFloat8 = 1f;
			height = fsmFloat8;
			FsmBool fsmBool = true;
			projectedY = null;
			normalized = fsmBool;
			everyFrame = false;
			projectedX = null;
		}

		[Token(Token = "0x600099E")]
		[Address(RVA = "0xB1B2F0", Offset = "0xB1B2F0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.GPSLocation);\n\tv31 = v13 == 0;\n\tv32 = ~v31;\n\tif (v32) goto L_001F;\n\tHutongGames.PlayMaker.Actions.ProjectLocationToMap::DoProjectGPSLocation(this);\n\tv38 = ~this.everyFrame;\n\tif (v38) goto L_001F;\n\treturn;\nL_001F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (!GPSLocation.IsNone)
			{
				DoProjectGPSLocation();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x600099F")]
		[Address(RVA = "0xB1B574", Offset = "0xB1B574", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ProjectLocationToMap::DoProjectGPSLocation(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoProjectGPSLocation();
		}

		[Token(Token = "0x60009A0")]
		[Address(RVA = "0xB1B348", Offset = "0xB1B348", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ECAAC8]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022578]) = v46;\nL_001B:\n\tv50 = HutongGames.PlayMaker.FsmVector3::get_Value(this.GPSLocation);\n\tv100 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLongitude);\n\tv216 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxLongitude);\n\tgoto L_003B;\n\tv223 = *([v219 @ X0_v10+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_003B;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v219, v110, v30, v31, v32, v33, v34, v35, v216, v95, v90, v39, v40, v41, v42, v43);\nL_003B:\n\tv101 = UnityEngine.Mathf::Clamp(v50, v100, v216);\n\tthis.x = v101;\n\tv102 = HutongGames.PlayMaker.FsmVector3::get_Value(this.GPSLocation);\n\tv103 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLatitude);\n\tv231 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxLatitude);\n\tv104 = UnityEngine.Mathf::Clamp(v102.y, v103, v231);\n\tthis.y = v104;\n\tv67 = this.mapProjection == 1;\n\tif (v67) goto L_0068;\n\tv235 = this.mapProjection == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_006E;\n\tHutongGames.PlayMaker.Actions.ProjectLocationToMap::DoEquidistantCylindrical(this);\n\tgoto L_006E;\nL_0068:\n\tHutongGames.PlayMaker.Actions.ProjectLocationToMap::DoMercatorProjection(this);\nL_006E:\n\tv241 = HutongGames.PlayMaker.FsmFloat::get_Value(this.width);\n\tv105 = this.x * v241;\n\tthis.x = v105;\n\tv242 = HutongGames.PlayMaker.FsmFloat::get_Value(this.height);\n\tv106 = this.y * v242;\n\tthis.y = v106;\n\tv52 = this.projectedX;\n\tv169 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv244 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minX);\n\tv82 = this.x;\n\tv247 = v169 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_0092;\n\tv250 = UnityEngine.Screen::get_width();\n\tv82 = v82 * v250;\nL_0092:\n\tv107 = v244 + v82;\n\tv52.value = v107;\n\tv145 = this.projectedY;\n\tv170 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv254 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minY);\n\tv156 = this.y;\n\tv257 = v170 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_00AD;\n\tv260 = UnityEngine.Screen::get_height();\n\tv156 = v156 * v260;\nL_00AD:\n\tv205 = v254 + v156;\n\tv145.value = v205;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoProjectGPSLocation()
		{
			Vector3 value = GPSLocation.Value;
			float value2 = minLongitude.Value;
			float value3 = maxLongitude.Value;
			float num = Mathf.Clamp(value.x, value2, value3);
			x = num;
			Vector3 value4 = GPSLocation.Value;
			float value5 = minLatitude.Value;
			float value6 = maxLatitude.Value;
			float num2 = Mathf.Clamp(value4.y, value5, value6);
			y = num2;
			if (mapProjection != MapProjection.Mercator)
			{
				if (mapProjection == MapProjection.EquidistantCylindrical)
				{
					DoEquidistantCylindrical();
				}
			}
			else
			{
				DoMercatorProjection();
			}
			float value7 = width.Value;
			float num3 = x * value7;
			x = num3;
			float value8 = height.Value;
			float num4 = y * value8;
			y = num4;
			FsmFloat fsmFloat = projectedX;
			bool value9 = normalized.Value;
			float value10 = minX.Value;
			float num5 = x;
			if (!value9)
			{
				int num6 = Screen.width;
				num5 *= (float)num6;
			}
			float value11 = value10 + num5;
			fsmFloat.Value = value11;
			FsmFloat fsmFloat2 = projectedY;
			bool value12 = normalized.Value;
			float value13 = minY.Value;
			float num7 = y;
			if (!value12)
			{
				int num8 = Screen.height;
				num7 *= (float)num8;
			}
			float value14 = value13 + num7;
			fsmFloat2.Value = value14;
		}

		[Token(Token = "0x60009A1")]
		[Address(RVA = "0xB1B578", Offset = "0xB1B578", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLongitude);\n\tv32 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxLongitude);\n\tv89 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLongitude);\n\tv23 = this.x - v20;\n\tv90 = v32 - v89;\n\tv33 = v23 / v90;\n\tthis.x = v33;\n\tv34 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLatitude);\n\tv35 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxLatitude);\n\tv91 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLatitude);\n\tv72 = this.y - v34;\n\tv92 = v35 - v91;\n\tv78 = v72 / v92;\n\tthis.y = v78;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoEquidistantCylindrical()
		{
			float value = minLongitude.Value;
			float value2 = maxLongitude.Value;
			float value3 = minLongitude.Value;
			float num = x - value;
			float num2 = value2 - value3;
			float num3 = num / num2;
			x = num3;
			float value4 = minLatitude.Value;
			float value5 = maxLatitude.Value;
			float value6 = minLatitude.Value;
			float num4 = y - value4;
			float num5 = value5 - value6;
			float num6 = num4 / num5;
			y = num6;
		}

		[Token(Token = "0x60009A2")]
		[Address(RVA = "0xB1B640", Offset = "0xB1B640", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLongitude);\n\tv32 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxLongitude);\n\tv90 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLongitude);\n\tv23 = this.x - v20;\n\tv91 = v32 - v90;\n\tv33 = v23 / v91;\n\tthis.x = v33;\n\tv92 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minLatitude);\n\tv34 = HutongGames.PlayMaker.Actions.ProjectLocationToMap::LatitudeToMercator(v92);\n\tv93 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxLatitude);\n\tv35 = HutongGames.PlayMaker.Actions.ProjectLocationToMap::LatitudeToMercator(v93);\n\tv94 = HutongGames.PlayMaker.FsmVector3::get_Value(this.GPSLocation);\n\tv97 = HutongGames.PlayMaker.Actions.ProjectLocationToMap::LatitudeToMercator(v94.y);\n\tv98 = v97 - v34;\n\tv73 = v35 - v34;\n\tv79 = v98 / v73;\n\tthis.y = v79;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMercatorProjection()
		{
			float value = minLongitude.Value;
			float value2 = maxLongitude.Value;
			float value3 = minLongitude.Value;
			float num = x - value;
			float num2 = value2 - value3;
			float num3 = num / num2;
			x = num3;
			float value4 = minLatitude.Value;
			float num4 = LatitudeToMercator(value4);
			float value5 = maxLatitude.Value;
			float num5 = LatitudeToMercator(value5);
			float num6 = LatitudeToMercator(GPSLocation.Value.y);
			float num7 = num6 - num4;
			float num8 = num5 - num4;
			float num9 = num7 / num8;
			y = num9;
		}

		[Token(Token = "0x60009A3")]
		[Address(RVA = "0xB1B714", Offset = "0xB1B714", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8CF0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, latitudeInDegrees, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022579]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, v21, v22, v23, v24, v25, v26, v27, latitudeInDegrees, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tv58 = UnityEngine.Mathf::Clamp(latitudeInDegrees, -85f, 85f);\n\tv63 = v58 * 0.017453292f;\n\tv65 = v63 * 0.5f;\n\treturnVal1 = v65 + 0.7853982f;\n\tv67 = 0x6D25B0(0, v21, v22, v23, v24, v25, v26, v27, returnVal1, 0.5f, 0.7853982f, v30, v31, v32, v33, v34);\n\tv72 = 0x6D2B90(v67, v21, v22, v23, v24, v25, v26, v27, returnVal1, 0.5f, 0.7853982f, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float LatitudeToMercator(float latitudeInDegrees)
		{
			float num = Mathf.Clamp(latitudeInDegrees, -85f, 85f);
			float num2 = num * ((float)Math.PI / 180f);
			float num3 = num2 * 0.5f;
			float result = num3 + (float)Math.PI / 4f;
			Il2CppRuntime.Boundary("SYSTEM_API:tanf", "Method not found @6D25B0 (native tanf)");
			Il2CppRuntime.Boundary("SYSTEM_API:logf", "Method not found @6D2B90 (native logf)");
			return result;
		}

		[Token(Token = "0x60009A4")]
		[Address(RVA = "0xB1B7BC", Offset = "0xB1B7BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProjectLocationToMap()
		{
		}
	}
}

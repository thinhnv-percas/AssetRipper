using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755820", Offset = "0x755820")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755820", Offset = "0x755820")]
	[Token(Token = "0x20001CB")]
	public class GetLocationInfo : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEE20", Offset = "0x7AEE20")]
		[Token(Token = "0x40013AF")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vectorPosition;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEE34", Offset = "0x7AEE34")]
		[Token(Token = "0x40013B0")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat longitude;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEE48", Offset = "0x7AEE48")]
		[Token(Token = "0x40013B1")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat latitude;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEE5C", Offset = "0x7AEE5C")]
		[Token(Token = "0x40013B2")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat altitude;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEE70", Offset = "0x7AEE70")]
		[Token(Token = "0x40013B3")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat horizontalAccuracy;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEE84", Offset = "0x7AEE84")]
		[Token(Token = "0x40013B4")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat verticalAccuracy;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AEE98", Offset = "0x7AEE98")]
		[Token(Token = "0x40013B5")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent errorEvent;

		[Token(Token = "0x600098F")]
		[Address(RVA = "0xA2F2F0", Offset = "0xA2F2F0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.verticalAccuracy = 0;\n\tthis.altitude = 0;\n\tthis.longitude = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			verticalAccuracy = null;
			altitude = null;
			longitude = null;
		}

		[Token(Token = "0x6000990")]
		[Address(RVA = "0xA2F304", Offset = "0xA2F304", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetLocationInfo::DoGetLocationInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetLocationInfo();
			Finish();
		}

		[Token(Token = "0x6000991")]
		[Address(RVA = "0xA2F32C", Offset = "0xA2F32C", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-10_v2;\n\t*([v16 @ X29_v1-50]) = 0;\n\t*([v16 @ X29_v1-40]) = 0;\n\tv22 = UnityEngine.Input::get_location();\n\tv25 = UnityEngine.LocationService::get_status(v22);\n\tv132 = v25 != 2;\n\tif (v132) goto L_00B1;\n\tv171 = UnityEngine.Input::get_location();\n\tv403 = UnityEngine.LocationService::get_lastData(v171);\n\tv409 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v16 @ X29_v1-50]) = *([v16 @ X29_v1-70]);\n\t*([v16 @ X29_v1-40]) = *([v16 @ X29_v1-60]);\n\tv410 = 0x166FFFC(v409, 0, v185, v186, v187, v188, v189, v190, *([v16 @ X29_v1-60]), *([v16 @ X29_v1-70]), v60, v191, v192, v193, v194, v195);\n\tv172 = UnityEngine.Input::get_location();\n\tv127 = &v114 @ stack_-A0;\n\tv413 = UnityEngine.LocationService::get_lastData(v172);\n\tv414 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v16 @ X29_v1-50]) = *([v127 @ X8_v5]);\n\t*([v16 @ X29_v1-40]) = *([v127 @ X8_v5+10]);\n\tv415 = 0x166FFF4(v414, 0, v185, v186, v187, v188, v189, v190, *([v127 @ X8_v5+10]), *([v127 @ X8_v5]), v60, v191, v192, v193, v194, v195);\n\tv173 = UnityEngine.Input::get_location();\n\tv257 = &v88 @ stack_-C0;\n\tv418 = UnityEngine.LocationService::get_lastData(v173);\n\tv421 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v16 @ X29_v1-50]) = *([v257 @ X8_v6]);\n\t*([v16 @ X29_v1-40]) = *([v257 @ X8_v6+10]);\n\tv423 = 0x1670004(v421, 0, v185, v186, v187, v188, v189, v190, *([v257 @ X8_v6+10]), *([v257 @ X8_v6]), v60, v191, v192, v193, v194, v195);\n\tv235 = this.vectorPosition;\n\tv55 = 0;\n\tv280 = 0x1586898(&v55 @ stack_-D0_v4 (UnityEngine.Vector3), 0, v185, v186, v187, v188, v189, v190, *([v16 @ X29_v1-60]), *([v127 @ X8_v5+10]), *([v257 @ X8_v6+10]), v191, v192, v193, v194, v195);\n\tv235.value = 0;\n\tv235.value.z = 0f;\n\tv258 = this.longitude;\n\tv258.value = *([v16 @ X29_v1-60]);\n\tv259 = this.latitude;\n\tv259.value = *([v127 @ X8_v5+10]);\n\tv128 = this.altitude;\n\tv128.value = *([v257 @ X8_v6+10]);\n\tv65 = this.horizontalAccuracy;\n\tv174 = UnityEngine.Input::get_location();\n\tv129 = &v48 @ stack_-F0;\n\tv428 = UnityEngine.LocationService::get_lastData(v174);\n\tv429 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v16 @ X29_v1-50]) = *([v129 @ X8_v11]);\n\t*([v16 @ X29_v1-40]) = *([v129 @ X8_v11+10]);\n\tv281 = 0x167000C(v429, 0, v185, v186, v187, v188, v189, v190, *([v129 @ X8_v11+10]), *([v129 @ X8_v11]), *([v257 @ X8_v6+10]), v191, v192, v193, v194, v195);\n\tv65.value = *([v129 @ X8_v11+10]);\n\tv183 = this.verticalAccuracy;\n\tv175 = UnityEngine.Input::get_location();\n\tv432 = UnityEngine.LocationService::get_lastData(v175);\n\tv433 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v16 @ X29_v1-50]) = v432.m_Timestamp;\n\t*([v16 @ X29_v1-40]) = v432.m_Altitude;\n\tv282 = 0x1670014(v433, 0, v185, v186, v187, v188, v189, v190, v432.m_Altitude, v432.m_Timestamp, *([v257 @ X8_v6+10]), v191, v192, v193, v194, v195);\n\tv183.value = v432.m_Altitude;\n\tgoto L_00BB;\nL_00B1:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.errorEvent);\nL_00BB:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetLocationInfo()
		{
			//IL_0079: Expected O, but got I
			//IL_00d4: Expected O, but got I
			//IL_0127: Expected O, but got I
			//IL_01b9: Expected F4, but got I
			//IL_01dd: Expected F4, but got I
			//IL_0201: Expected F4, but got I
			//IL_023d: Expected O, but got I
			//IL_0273: Expected F4, but got I
			//IL_02a7: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			LocationService location = Input.location;
			LocationServiceStatus status = location.status;
			if (status == LocationServiceStatus.Running)
			{
				LocationService location2 = Input.location;
				LocationInfo lastData = location2.lastData;
				object obj3 = (long)(IntPtr)obj2 - 80L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @166FFFC (inside UnityEngine.Input::get_touches +0x150)");
				LocationService location3 = Input.location;
				object obj5 = default(object);
				object obj4 = obj5;
				LocationInfo lastData2 = location3.lastData;
				object obj6 = (long)(IntPtr)obj2 - 80L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v5+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @166FFF4 (inside UnityEngine.Input::get_touches +0x148)");
				LocationService location4 = Input.location;
				object obj8 = default(object);
				object obj7 = obj8;
				LocationInfo lastData3 = location4.lastData;
				object obj9 = (long)(IntPtr)obj2 - 80L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v6+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1670004 (inside UnityEngine.Input::get_touches +0x158)");
				FsmVector3 fsmVector = vectorPosition;
				Vector3 vector = default(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				fsmVector.value = default(Vector3);
				fsmVector.value.z = 0f;
				FsmFloat fsmFloat = longitude;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-60]");
				fsmFloat.Value = 0f;
				FsmFloat fsmFloat2 = latitude;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v5+10]");
				fsmFloat2.Value = 0f;
				FsmFloat fsmFloat3 = altitude;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v6+10]");
				fsmFloat3.Value = 0f;
				FsmFloat fsmFloat4 = horizontalAccuracy;
				LocationService location5 = Input.location;
				object obj11 = default(object);
				object obj10 = obj11;
				LocationInfo lastData4 = location5.lastData;
				object obj12 = (long)(IntPtr)obj2 - 80L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v11+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @167000C (inside UnityEngine.Input::get_touches +0x160)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v11+10]");
				fsmFloat4.Value = 0f;
				FsmFloat fsmFloat5 = verticalAccuracy;
				LocationService location6 = Input.location;
				LocationInfo lastData5 = location6.lastData;
				object obj13 = (long)(IntPtr)obj2 - 80L;
				_ = lastData5.m_Timestamp;
				_ = lastData5.altitude;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1670014 (inside UnityEngine.Input::get_touches +0x168)");
				fsmFloat5.Value = lastData5.altitude;
			}
			else
			{
				Fsm.Event(errorEvent);
			}
		}

		[Token(Token = "0x6000992")]
		[Address(RVA = "0xA2F50C", Offset = "0xA2F50C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetLocationInfo()
		{
		}
	}
}

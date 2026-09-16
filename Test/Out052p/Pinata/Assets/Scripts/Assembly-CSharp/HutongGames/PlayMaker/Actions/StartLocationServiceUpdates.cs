using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755960", Offset = "0x755960")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755960", Offset = "0x755960")]
	[Token(Token = "0x20001CF")]
	public class StartLocationServiceUpdates : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AF2D8", Offset = "0x7AF2D8")]
		[Token(Token = "0x40013D5")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat maxWait;

		[Token(Token = "0x40013D6")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat desiredAccuracy;

		[Token(Token = "0x40013D7")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat updateDistance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AF310", Offset = "0x7AF310")]
		[Token(Token = "0x40013D8")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent successEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AF348", Offset = "0x7AF348")]
		[Token(Token = "0x40013D9")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent failedEvent;

		[Token(Token = "0x40013DA")]
		[FieldOffset(Offset = "0x78")]
		private float startTime;

		[Token(Token = "0x60009A5")]
		[Address(RVA = "0x99E1D4", Offset = "0x99E1D4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmFloat::op_Implicit(20f);\n\tthis.maxWait = v14;\n\tv18 = HutongGames.PlayMaker.FsmFloat::op_Implicit(10f);\n\tthis.desiredAccuracy = v18;\n\tv21 = HutongGames.PlayMaker.FsmFloat::op_Implicit(10f);\n\tthis.successEvent = 0;\n\tthis.failedEvent = 0;\n\tthis.updateDistance = v21;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 20f;
			maxWait = fsmFloat;
			FsmFloat fsmFloat2 = 10f;
			desiredAccuracy = fsmFloat2;
			FsmFloat fsmFloat3 = 10f;
			successEvent = null;
			failedEvent = null;
			updateDistance = fsmFloat3;
		}

		[Token(Token = "0x60009A6")]
		[Address(RVA = "0x99E230", Offset = "0x99E230", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v15;\n\tv17 = UnityEngine.Input::get_location();\n\tv23 = HutongGames.PlayMaker.FsmFloat::get_Value(this.desiredAccuracy);\n\tv35 = HutongGames.PlayMaker.FsmFloat::get_Value(this.updateDistance);\n\tUnityEngine.LocationService::Start(v17, v23, v35);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			startTime = realtimeSinceStartup;
			LocationService location = Input.location;
			float value = desiredAccuracy.Value;
			float value2 = updateDistance.Value;
			location.Start(value, value2);
		}

		[Token(Token = "0x60009A7")]
		[Address(RVA = "0x99E2B0", Offset = "0x99E2B0", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Input::get_location();\n\tv18 = UnityEngine.LocationService::get_status(v15);\n\tv69 = v18 == 3;\n\tif (v69) goto L_003C;\n\tv104 = UnityEngine.Input::get_location();\n\tv139 = UnityEngine.LocationService::get_status(v104);\n\tv137 = v139 == 0;\n\tif (v137) goto L_003C;\n\tv40 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv126 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxWait);\n\tv124 = v40 - this.startTime;\n\tv123 = v124 <= v126;\n\tif (v123) goto L_0041;\nL_003C:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.failedEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0041:\n\tv107 = UnityEngine.Input::get_location();\n\tv167 = UnityEngine.LocationService::get_status(v107);\n\tv26 = v167 != 2;\n\tif (v26) goto L_0067;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.successEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0067:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			LocationService location = Input.location;
			LocationServiceStatus status = location.status;
			if (status != LocationServiceStatus.Failed)
			{
				LocationService location2 = Input.location;
				if (location2.status != LocationServiceStatus.Stopped)
				{
					float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
					float value = maxWait.Value;
					float num = realtimeSinceStartup - startTime;
					if (!(num > value))
					{
						goto IL_00db;
					}
				}
			}
			Fsm.Event(failedEvent);
			Finish();
			goto IL_00db;
			IL_00db:
			LocationService location3 = Input.location;
			LocationServiceStatus status2 = location3.status;
			if (status2 == LocationServiceStatus.Running)
			{
				Fsm.Event(successEvent);
				Finish();
			}
		}

		[Token(Token = "0x60009A8")]
		[Address(RVA = "0x99E3A0", Offset = "0x99E3A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StartLocationServiceUpdates()
		{
		}
	}
}

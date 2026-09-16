using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7555F0", Offset = "0x7555F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7555F0", Offset = "0x7555F0")]
	[Token(Token = "0x20001C4")]
	public class DeviceOrientationEvent : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE95C", Offset = "0x7AE95C")]
		[Token(Token = "0x4001394")]
		[FieldOffset(Offset = "0x4C")]
		public DeviceOrientation orientation;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE994", Offset = "0x7AE994")]
		[Token(Token = "0x4001395")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sendEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE9CC", Offset = "0x7AE9CC")]
		[Token(Token = "0x4001396")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000974")]
		[Address(RVA = "0xB70418", Offset = "0xB70418", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sendEvent = 0;\n\tthis.orientation = 1;\n\tthis.everyFrame = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			sendEvent = null;
			orientation = DeviceOrientation.Portrait;
			everyFrame = false;
		}

		[Token(Token = "0x6000975")]
		[Address(RVA = "0xB7042C", Offset = "0xB7042C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.DeviceOrientationEvent::DoDetectDeviceOrientation(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoDetectDeviceOrientation();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000976")]
		[Address(RVA = "0xB704B8", Offset = "0xB704B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.DeviceOrientationEvent::DoDetectDeviceOrientation(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoDetectDeviceOrientation();
		}

		[Token(Token = "0x6000977")]
		[Address(RVA = "0xB70468", Offset = "0xB70468", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Input::get_deviceOrientation();\n\tv22 = v11 != this.orientation;\n\tif (v22) goto L_0023;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_0023:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoDetectDeviceOrientation()
		{
			DeviceOrientation deviceOrientation = Input.deviceOrientation;
			if (deviceOrientation == orientation)
			{
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000978")]
		[Address(RVA = "0xB704BC", Offset = "0xB704BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DeviceOrientationEvent()
		{
		}
	}
}

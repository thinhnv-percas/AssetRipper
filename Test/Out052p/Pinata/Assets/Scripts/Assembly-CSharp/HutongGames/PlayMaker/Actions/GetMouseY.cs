using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757EC8", Offset = "0x757EC8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757EC8", Offset = "0x757EC8")]
	[Token(Token = "0x2000242")]
	public class GetMouseY : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B3B2C", Offset = "0x7B3B2C")]
		[Token(Token = "0x400157D")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat storeResult;

		[Token(Token = "0x400157E")]
		[FieldOffset(Offset = "0x58")]
		public bool normalize;

		[Token(Token = "0x6000B4D")]
		[Address(RVA = "0xA30200", Offset = "0xA30200", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeResult = 0;\n\tthis.normalize = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			storeResult = null;
			normalize = true;
		}

		[Token(Token = "0x6000B4E")]
		[Address(RVA = "0xA30210", Offset = "0xA30210", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMouseY::DoGetMouseY(this);\n\treturn;\n")]
		public override void OnEnter()
		{
			DoGetMouseY();
		}

		[Token(Token = "0x6000B4F")]
		[Address(RVA = "0xA30278", Offset = "0xA30278", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMouseY::DoGetMouseY(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetMouseY();
		}

		[Token(Token = "0x6000B50")]
		[Address(RVA = "0xA30214", Offset = "0xA30214", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.storeResult == 0;\n\tif (v13) goto L_001F;\n\tv15 = UnityEngine.Input::get_mousePosition();\n\tv39 = ~this.normalize;\n\tif (v39) goto L_0016;\n\tv52 = UnityEngine.Screen::get_height();\n\tv17 = v15.y / v52;\nL_0016:\n\tv32 = this.storeResult;\n\tv32.value = v17;\nL_001F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetMouseY()
		{
			if (storeResult != null)
			{
				Vector3 mousePosition = Input.mousePosition;
				bool flag = !normalize;
				float value = mousePosition.y;
				if (!flag)
				{
					int height = Screen.height;
					value = mousePosition.y / (float)height;
				}
				FsmFloat fsmFloat = storeResult;
				fsmFloat.Value = value;
			}
		}

		[Token(Token = "0x6000B51")]
		[Address(RVA = "0xA3027C", Offset = "0xA3027C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMouseY()
		{
		}
	}
}

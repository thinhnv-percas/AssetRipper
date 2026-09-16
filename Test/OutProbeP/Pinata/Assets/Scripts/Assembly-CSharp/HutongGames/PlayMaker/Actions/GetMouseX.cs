using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757E78", Offset = "0x757E78")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757E78", Offset = "0x757E78")]
	[Token(Token = "0x2000241")]
	public class GetMouseX : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B3AF0", Offset = "0x7B3AF0")]
		[Token(Token = "0x400157B")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat storeResult;

		[Token(Token = "0x400157C")]
		[FieldOffset(Offset = "0x58")]
		public bool normalize;

		[Token(Token = "0x6000B48")]
		[Address(RVA = "0xA3017C", Offset = "0xA3017C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeResult = 0;\n\tthis.normalize = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			storeResult = null;
			normalize = true;
		}

		[Token(Token = "0x6000B49")]
		[Address(RVA = "0xA3018C", Offset = "0xA3018C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMouseX::DoGetMouseX(this);\n\treturn;\n")]
		public override void OnEnter()
		{
			DoGetMouseX();
		}

		[Token(Token = "0x6000B4A")]
		[Address(RVA = "0xA301F4", Offset = "0xA301F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMouseX::DoGetMouseX(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetMouseX();
		}

		[Token(Token = "0x6000B4B")]
		[Address(RVA = "0xA30190", Offset = "0xA30190", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.storeResult == 0;\n\tif (v13) goto L_001F;\n\tv15 = UnityEngine.Input::get_mousePosition();\n\tv39 = ~this.normalize;\n\tif (v39) goto L_0016;\n\tv52 = UnityEngine.Screen::get_width();\n\tv17 = v15 / v52;\nL_0016:\n\tv32 = this.storeResult;\n\tv32.value = v17;\nL_001F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetMouseX()
		{
			if (storeResult != null)
			{
				Vector3 mousePosition = Input.mousePosition;
				bool flag = !normalize;
				float value = mousePosition.x;
				if (!flag)
				{
					int width = Screen.width;
					value = mousePosition.x / (float)width;
				}
				FsmFloat fsmFloat = storeResult;
				fsmFloat.Value = value;
			}
		}

		[Token(Token = "0x6000B4C")]
		[Address(RVA = "0xA301F8", Offset = "0xA301F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMouseX()
		{
		}
	}
}

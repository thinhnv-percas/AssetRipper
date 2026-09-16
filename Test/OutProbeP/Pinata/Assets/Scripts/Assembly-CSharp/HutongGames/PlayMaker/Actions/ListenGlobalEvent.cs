using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759AE8", Offset = "0x759AE8")]
	[Token(Token = "0x2000296")]
	public class ListenGlobalEvent : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40016FF")]
		[FieldOffset(Offset = "0x50")]
		public GlobalEvent evnt;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B90C4", Offset = "0x7B90C4")]
		[Token(Token = "0x4001700")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sendEvent;

		[Token(Token = "0x4001701")]
		[FieldOffset(Offset = "0x60")]
		private IDisposable subscribe;

		[Token(Token = "0x6000CD4")]
		[Address(RVA = "0xA39F08", Offset = "0xA39F08", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F0AFC0]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E3E]) = v40;\nL_0018:\n\tv45 = new System.Action`1<System.Collections.Generic.IEnumerable`1<System.Int32>>();\n\tSystem.Action`1<System.Collections.Generic.IEnumerable`1<System.Int32>>::.ctor(v45, this, Il2CppMethodInfo);\n\tv60 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::Subscribe(this.evnt, v45);\n\tthis.subscribe = v60;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Action<IEnumerable<int>> callback = delegate
			{
				Fsm.Event(sendEvent);
				Finish();
				subscribe.Dispose();
			};
			IDisposable disposable = evnt.Subscribe(callback);
			subscribe = disposable;
		}

		[Token(Token = "0x6000CD5")]
		[Address(RVA = "0xA39FB0", Offset = "0xA39FB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.evnt = 0;\n\tthis.sendEvent = 0;\n\treturn;\n")]
		public override void Reset()
		{
			evnt = null;
			sendEvent = null;
		}

		[Token(Token = "0x6000CD6")]
		[Address(RVA = "0xA39FB8", Offset = "0xA39FB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ListenGlobalEvent()
		{
		}
	}
}

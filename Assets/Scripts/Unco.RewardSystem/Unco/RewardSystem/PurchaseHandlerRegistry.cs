using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x200000C")]
	public class PurchaseHandlerRegistry
	{
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x10")]
		private readonly Dictionary<Type, IPurchaseHandler> _handlers;

		[Token(Token = "0x17000006")]
		[field: Token(Token = "0x400000B")]
		public static PurchaseHandlerRegistry Instance
		{
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x81D4B7C", Offset = "0x81D4B7C", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<Instance>k__BackingField;\n")]
			get;
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x81D4BC8", Offset = "0x81D4BC8", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.<Instance>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x81D4C24", Offset = "0x81D4C24", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\tgoto L_0037;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.Type, Unco.RewardSystem.IPurchaseHandler>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Unco.RewardSystem.IPurchaseHandler>::.ctor(v48);\n\tthis._handlers = v48;\nL_0037:\n\tv73.<Instance>k__BackingField = this;\n\treturn;\n")]
		public PurchaseHandlerRegistry()
		{
			Dictionary<Type, IPurchaseHandler> handlers = new Dictionary<Type, IPurchaseHandler>();
			_handlers = handlers;
			Instance = this;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x4C57B1C", Offset = "0x4C57B1C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_0021;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0025:\n\tv60 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Unco.RewardSystem.IPurchaseHandler>::set_Item(this._handlers, v60, handler);\n\treturn;\nL_0021:\n\tgoto L_0025;\n")]
		public void Register<T>(IPurchaseHandler handler) where T : ShopItemData
		{
			Type typeFromHandle = typeof(T);
			_handlers[typeFromHandle] = handler;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x81D4CEC", Offset = "0x81D4CEC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv51 = System.Object::GetType(item);\n\tv61 = System.Collections.Generic.Dictionary`2<System.Type, Unco.RewardSystem.IPurchaseHandler>::TryGetValue(this._handlers, v51, &v53 @ stack_-38_v3 (Unco.RewardSystem.IPurchaseHandler));\n\tv135 = ~v61;\n\tif (v135) goto L_0062;\n\tgoto L_005A;\nL_0062:\n\treturn;\nL_005A:\n\tUnco.RewardSystem.IPurchaseHandler::Handle(v53, item);\n")]
		public void Execute(ShopItemData item)
		{
			Type type = item.GetType();
			if (_handlers.TryGetValue(type, out var value))
			{
				value.Handle(item);
			}
		}
	}
}

using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;

namespace Unco.EventBusSystem.Runtime
{
	[Token(Token = "0x2000004")]
	public static class ContainerEventBusExtensions
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x4866578", Offset = "0x4866578", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tv28 = v114;\n\tgoto L_0021;\n\tgoto L_0021;\n\tv49 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv71 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0036:\n\tv78 = Reflex.Core.Container::Resolve(container);\n\tv126 = Il2CppClass<TEvent>;\n\tv104 = *([v126 @ X8_v14 (Il2CppClass<TEvent>)+28]) < 0;\n\tv95 = *([v126 @ X8_v14 (Il2CppClass<TEvent>)+28]) ^ *([v126 @ X8_v14 (Il2CppClass<TEvent>)+28]);\n\tv92 = *([v126 @ X8_v14 (Il2CppClass<TEvent>)+28]) & v95;\n\tv89 = v92 < 0;\n\tv128 = v104 == v89;\n\tv86 = ~v128;\n\tv83 = ~v86;\n\tif (v83) goto L_004F;\n\tgoto L_004F;\n\tv163 = Il2CppMethodInfo;\n\tgoto L_0059;\n\treturn;\nL_007A:\n\tv172 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0021:\n\tv55 = Il2CppClass<TEvent>;\n\tv59 = *([v55 @ X8_v6 (Il2CppClass<TEvent>)+FC]) + 0xF;\n\tv60 = v59 & 0x1FFFFFFF0;\n\t// 38 StackAlloc v61 @ X20_v1 (System.Byte*), v60 @ X9_v2 (System.Int32)\n\tgoto L_0036;\nL_004F:\n\tv116 = 0x8BF6A1C(v61, &v28 @ stack_-58_v1 (TEvent), *([v55 @ X8_v6 (Il2CppClass<TEvent>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0059:\n\tv135 = v61;\n\t*([v163 @ X1_v5 (Il2CppMethodInfo)+10])(v165, *([v163 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, v78, &v135 @ stack_-50_v2 (System.IntPtr), v61, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv217 = *([A4731E0]);\n\tv144 = *([v217 @ X9_v5]) != *([v25 @ X8_v2]);\n\tif (v144) goto L_007A;\n")]
		public unsafe static void PublishEvent<TEvent>(this ContainerInstance container, TEvent eventData) where TEvent : IEvent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerEventBusExtensions::PublishEvent");
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x48664D0", Offset = "0x48664D0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = Il2CppMethodInfo;\n\tgoto L_0022;\nL_001C:\n\tv58 = 0x220C2B8(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0022:\n\tv68 = Reflex.Core.Container::Resolve(container);\n\tv68 = Unco.EventBusSystem.Runtime.EventBus::InvokeEvent(v68);\n\treturn;\n\tv52 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0022;\nL_FFFFFFFF:\n\tv49 = Il2CppMethodInfo;\n\tgoto L_001C;\n")]
		public static void PublishEvent<TEvent>(this ContainerInstance container) where TEvent : struct, IEvent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerEventBusExtensions::PublishEvent");
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x48666B0", Offset = "0x48666B0", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0018;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0018:\n\tv45 = handler == 0;\n\tif (v45) goto L_0039;\n\tgoto L_0028;\n\tv67 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0028:\n\tv74 = Reflex.Core.Container::Resolve(container);\n\tv74 = Unco.EventBusSystem.Runtime.EventBus::ListenEvent(v74, handler);\n\treturn;\nL_0039:\n\tv63 = 0xB28B000 + 0x600;\n\tv70 = new v63();\n\tv79 = 0xB30B000 + 0x4C8;\n\tSystem.ArgumentNullException::.ctor(v70, v79);\n\tthrow v70;\n")]
		public static void SubscribeToEvent<TEvent>(this ContainerInstance container, Action<TEvent> handler) where TEvent : IEvent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerEventBusExtensions::SubscribeToEvent");
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x4866788", Offset = "0x4866788", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0018;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0018:\n\tv45 = handler == 0;\n\tif (v45) goto L_0039;\n\tgoto L_0028;\n\tv67 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0028:\n\tv74 = Reflex.Core.Container::Resolve(container);\n\tv74 = Unco.EventBusSystem.Runtime.EventBus::RemoveListener(v74, handler);\n\treturn;\nL_0039:\n\tv63 = 0xB28B000 + 0x600;\n\tv70 = new v63();\n\tv79 = 0xB30B000 + 0x4C8;\n\tSystem.ArgumentNullException::.ctor(v70, v79);\n\tthrow v70;\n")]
		public static void UnsubscribeFromEvent<TEvent>(this ContainerInstance container, Action<TEvent> handler) where TEvent : IEvent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerEventBusExtensions::UnsubscribeFromEvent");
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81A88D4", Offset = "0x81A88D4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB799000;\n\tv20 = *([B799F65]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0026;\n\tv54 = Il2CppMethodInfo;\n\tgoto L_0020;\nL_0020:\n\treturnVal1 = Reflex.Core.Container::Resolve(container);\n\treturn returnVal1;\nL_0026:\n\t*([v16 @ X20_v1+F65]) = 1;\n\tv54 = Il2CppMethodInfo;\n\tgoto L_0020;\n\tv56 = 0x220C2B8(v54, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv79 = container == 0;\n\tv61 = ~v79;\n\tif (v61) goto L_0020;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n")]
		public static EventBus GetEventBus(this ContainerInstance container)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerEventBusExtensions::GetEventBus");
			return default;
		}
	}
}

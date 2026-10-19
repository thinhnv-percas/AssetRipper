using System;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Core.Data
{
	[Token(Token = "0x200048B")]
	public struct SwapEntry
	{
		[Token(Token = "0x4000ED1")]
		[FieldOffset(Offset = "0x0")]
		public EntityId frontId;

		[Token(Token = "0x4000ED2")]
		[FieldOffset(Offset = "0x8")]
		public EntityId backId;

		[Token(Token = "0x4000ED3")]
		[FieldOffset(Offset = "0x10")]
		public GridCoord oldFront;

		[Token(Token = "0x4000ED4")]
		[FieldOffset(Offset = "0x1C")]
		public GridCoord oldBack;

		[Token(Token = "0x60012E8")]
		[Address(RVA = "0x3CE1204", Offset = "0x3CE1204", Length = "0x26C")]
		public override string ToString()
		{
			object[] array = new object[6];
			EntityId entityId = frontId;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj = default(object);
			if (obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_02e3;
				}
			}
			array[0] = obj;
			GridCoord gridCoord = oldFront;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_02e3;
				}
			}
			array[1] = obj3;
			int y = oldFront.y;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj5 = default(object);
			if (obj5 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj6 = default(object);
				if (obj6 == null)
				{
					goto IL_02e3;
				}
			}
			array[2] = obj5;
			EntityId entityId2 = backId;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj7 = default(object);
			if (obj7 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj8 = default(object);
				if (obj8 == null)
				{
					goto IL_02e3;
				}
			}
			array[3] = obj7;
			GridCoord gridCoord2 = oldBack;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj9 = default(object);
			if (obj9 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj10 = default(object);
				if (obj10 == null)
				{
					goto IL_02e3;
				}
			}
			array[4] = obj9;
			int y2 = oldBack.y;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj11 = default(object);
			if (obj11 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj12 = default(object);
				if (obj12 == null)
				{
					goto IL_02e3;
				}
			}
			array[5] = obj11;
			return string.Format("Swap E{0}({1},{2}) <-> E{3}({4},{5})", array);
			IL_02e3:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
	}
}

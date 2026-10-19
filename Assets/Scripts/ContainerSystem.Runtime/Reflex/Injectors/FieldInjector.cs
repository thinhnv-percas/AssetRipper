using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;

namespace Reflex.Injectors
{
	[Token(Token = "0x200001C")]
	internal static class FieldInjector
	{
		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3F3211C", Offset = "0x3F3211C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = field == 0;\n\tif (v16) goto L_0024;\n\tv25 = System.Reflection.FieldInfo::get_FieldType(field);\n\tv40 = container == 0;\n\tif (v40) goto L_0026;\n\tv43 = Reflex.Core.Container::Resolve(container, v25);\n\tSystem.Reflection.FieldInfo::SetValue(field, instance, v43);\n\treturn;\nL_0024:\n\tv49 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0026:\n\tv49 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0059:\n\t// 89 Interrupt\n\tv59 = 0x8BF5BF4(v49, v25, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv67 = 0x8BF0368(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv73 = 0xA1B8(v67, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		internal static void Inject(FieldInfo field, object instance, Container container)
		{
			if ((object)field != null)
			{
				Type fieldType = field.FieldType;
				if (container != null)
				{
					object value = container.Resolve(fieldType);
					field.SetValue(instance, value);
					return;
				}
				NullReferenceException ex = new NullReferenceException();
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3F32248", Offset = "0x3F32248", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = field == 0;\n\tif (v17) goto L_0029;\n\tv26 = System.Reflection.FieldInfo::get_FieldType(field);\n\tv41 = container == 0;\n\tif (v41) goto L_002B;\n\tv46 = Reflex.Core.Container::TryResolve(container, v26, &v44 @ stack_-38_v2 (System.Object));\n\tv49 = v46 == 0;\n\tif (v49) goto L_0028;\n\tSystem.Reflection.FieldInfo::SetValue(field, instance, v44);\nL_0028:\n\treturn;\nL_0029:\n\tv50 = new System.NullReferenceException();\n\tgoto L_005F;\nL_002B:\n\tv50 = new System.NullReferenceException();\n\tgoto L_005F;\nL_005F:\n\t// 95 Interrupt\n\tv60 = 0x8BF5BF4(v50, v26, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv76 = 0x8BF0368(v50, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv82 = 0xA1B8(v76, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		internal static void TryInject(FieldInfo field, object instance, Container container)
		{
			if ((object)field != null)
			{
				Type fieldType = field.FieldType;
				if (container != null)
				{
					if (container.TryResolve(fieldType, out var result))
					{
						field.SetValue(instance, result);
					}
					return;
				}
				NullReferenceException ex = new NullReferenceException();
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
		}
	}
}

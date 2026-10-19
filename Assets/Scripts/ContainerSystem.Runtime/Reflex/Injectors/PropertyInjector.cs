using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;

namespace Reflex.Injectors
{
	[Token(Token = "0x200001F")]
	internal static class PropertyInjector
	{
		[Token(Token = "0x6000057")]
		[Address(RVA = "0x3F3238C", Offset = "0x3F3238C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = property == 0;\n\tif (v16) goto L_0024;\n\tv25 = System.Reflection.PropertyInfo::get_PropertyType(property);\n\tv40 = container == 0;\n\tif (v40) goto L_0026;\n\tv43 = Reflex.Core.Container::Resolve(container, v25);\n\tSystem.Reflection.PropertyInfo::SetValue(property, instance, v43);\n\treturn;\nL_0024:\n\tv49 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0026:\n\tv49 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0059:\n\t// 89 Interrupt\n\tv59 = 0x8BF5BF4(v49, v25, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv67 = 0x8BF0368(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv73 = 0xA1B8(v67, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		internal static void Inject(PropertyInfo property, object instance, Container container)
		{
			if ((object)property != null)
			{
				Type propertyType = property.PropertyType;
				if (container != null)
				{
					object value = container.Resolve(propertyType);
					property.SetValue(instance, value);
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

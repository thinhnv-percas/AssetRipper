using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Caching;
using Reflex.Core;

namespace Reflex.Injectors
{
	[Token(Token = "0x200001B")]
	internal static class AttributeInjector
	{
		[Token(Token = "0x600004D")]
		[Address(RVA = "0x3F31DFC", Offset = "0x3F31DFC", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv192 = System.Object::GetType(obj);\n\tgoto L_0029;\n\tv146 = v161.InjectableFields;\n\tv253 = v146.Length < 1;\n\tif (v253) goto L_005B;\n\tv256 = v146.Length & 0x7FFFFFFF;\n\tv272 = 0;\nL_004E:\n\tReflex.Injectors.FieldInjector::Inject(v146[v272 @ X23_v20 (System.Int32)], obj, container);\n\tv272 = v272 + 1;\n\tv259 = v256 != v272;\n\tif (v259) goto L_004E;\nL_005B:\n\tv147 = v161.OptionalInjectableFields;\n\tv305 = v147.Length < 1;\n\tif (v305) goto L_0089;\n\tv310 = v147.Length & 0x7FFFFFFF;\n\tv317 = 0;\nL_007C:\n\tReflex.Injectors.FieldInjector::TryInject(v147[v317 @ X23_v17 (System.Int32)], obj, container);\n\tv317 = v317 + 1;\n\tv374 = v310 != v317;\n\tif (v374) goto L_007C;\nL_0089:\n\tv148 = v161.InjectableProperties;\n\tv407 = v148.Length < 1;\n\tif (v407) goto L_00B7;\n\tv311 = v148.Length & 0x7FFFFFFF;\n\tv318 = 0;\nL_00AA:\n\tReflex.Injectors.PropertyInjector::Inject(v148[v318 @ X23_v14 (System.Int32)], obj, container);\n\tv318 = v318 + 1;\n\tv411 = v311 != v318;\n\tif (v411) goto L_00AA;\nL_00B7:\n\tv149 = v161.InjectableMethods;\n\tv444 = v149.Length < 1;\n\tif (v444) goto L_00E5;\n\tv312 = v149.Length & 0x7FFFFFFF;\n\tv319 = 0;\nL_00D8:\n\tReflex.Injectors.MethodInjector::Inject(v149[v319 @ X23_v11 (System.Int32)], obj, container);\n\tv319 = v319 + 1;\n\tv448 = v312 != v319;\n\tif (v448) goto L_00D8;\nL_00E5:\n\tv185 = v161.OptionalInjectableMethods;\n\tv481 = v185.Length < 1;\n\tif (v481) goto L_011E;\n\tv316 = v185.Length & 0x7FFFFFFF;\n\tv357 = 0;\nL_0106:\n\tReflex.Injectors.MethodInjector::TryInject(v185[v357 @ X22_v10 (System.Int32)], obj, container);\n\tv357 = v357 + 1;\n\tv486 = v316 != v357;\n\tif (v486) goto L_0106;\nL_011E:\n\treturn;\nL_0029:\n\tv161 = Reflex.Caching.TypeInfoCache::Get(v192);\n")]
		internal static void Inject(object obj, Container container)
		{
			Type type = obj.GetType();
			TypeAttributeInfo typeAttributeInfo = TypeInfoCache.Get(type);
			FieldInfo[] injectableFields = typeAttributeInfo.InjectableFields;
			if (injectableFields.Length >= 1)
			{
				int num = injectableFields.Length & 0x7FFFFFFF;
				int num2 = 0;
				do
				{
					FieldInjector.Inject(injectableFields[num2], obj, container);
					num2++;
				}
				while (num != num2);
			}
			FieldInfo[] optionalInjectableFields = typeAttributeInfo.OptionalInjectableFields;
			if (optionalInjectableFields.Length >= 1)
			{
				int num3 = optionalInjectableFields.Length & 0x7FFFFFFF;
				int num4 = 0;
				do
				{
					FieldInjector.TryInject(optionalInjectableFields[num4], obj, container);
					num4++;
				}
				while (num3 != num4);
			}
			PropertyInfo[] injectableProperties = typeAttributeInfo.InjectableProperties;
			if (injectableProperties.Length >= 1)
			{
				int num5 = injectableProperties.Length & 0x7FFFFFFF;
				int num6 = 0;
				do
				{
					PropertyInjector.Inject(injectableProperties[num6], obj, container);
					num6++;
				}
				while (num5 != num6);
			}
			InjectableMethodInfo[] injectableMethods = typeAttributeInfo.InjectableMethods;
			if (injectableMethods.Length >= 1)
			{
				int num7 = injectableMethods.Length & 0x7FFFFFFF;
				int num8 = 0;
				do
				{
					MethodInjector.Inject(injectableMethods[num8], obj, container);
					num8++;
				}
				while (num7 != num8);
			}
			InjectableMethodInfo[] optionalInjectableMethods = typeAttributeInfo.OptionalInjectableMethods;
			if (optionalInjectableMethods.Length >= 1)
			{
				int num9 = optionalInjectableMethods.Length & 0x7FFFFFFF;
				int num10 = 0;
				do
				{
					MethodInjector.TryInject(optionalInjectableMethods[num10], obj, container);
					num10++;
				}
				while (num9 != num10);
			}
		}
	}
}

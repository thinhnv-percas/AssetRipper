using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using System.Threading;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal static class MetadataViewGenerator
{
	public delegate object MetadataViewFactory(IReadOnlyDictionary<string, object> metadata, IReadOnlyDictionary<string, object> defaultMetadata);

	private const string MetadataViewFactoryName = "Create";

	private static readonly Dictionary<Type, MetadataViewFactory> MetadataViewFactories = new Dictionary<Type, MetadataViewFactory>();

	private static readonly AssemblyName ProxyAssemblyName = new AssemblyName(string.Format(CultureInfo.InvariantCulture, "MetadataViewProxies_{0}", new object[1] { Guid.NewGuid() }));

	private static readonly Type[] CtorArgumentTypes = new Type[2]
	{
		typeof(IReadOnlyDictionary<string, object>),
		typeof(IReadOnlyDictionary<string, object>)
	};

	private static readonly MethodInfo MdvDictionaryTryGet = CtorArgumentTypes[0].GetTypeInfo().GetMethod("TryGetValue");

	private static readonly MethodInfo MdvDictionaryIndexer = CtorArgumentTypes[0].GetTypeInfo().GetMethod("get_Item");

	private static readonly MethodInfo ObjectGetType = typeof(object).GetTypeInfo().GetMethod("GetType", Type.EmptyTypes);

	private static readonly ConstructorInfo ObjectCtor = typeof(object).GetTypeInfo().GetConstructor(Type.EmptyTypes);

	private static ModuleBuilder transparentProxyModuleBuilder;

	private static SkipClrVisibilityChecks skipClrVisibilityChecks;

	private static AssemblyBuilder CreateProxyAssemblyBuilder(ConstructorInfo constructorInfo)
	{
		return AssemblyBuilder.DefineDynamicAssembly(ProxyAssemblyName, AssemblyBuilderAccess.Run);
	}

	private static ModuleBuilder GetProxyModuleBuilder()
	{
		Assumes.True(Monitor.IsEntered(MetadataViewFactories));
		if (transparentProxyModuleBuilder == null)
		{
			AssemblyBuilder assemblyBuilder = CreateProxyAssemblyBuilder(typeof(SecurityTransparentAttribute).GetTypeInfo().GetConstructor(Type.EmptyTypes));
			transparentProxyModuleBuilder = assemblyBuilder.DefineDynamicModule("MetadataViewProxiesModule");
			skipClrVisibilityChecks = new SkipClrVisibilityChecks(assemblyBuilder, transparentProxyModuleBuilder);
		}
		return transparentProxyModuleBuilder;
	}

	public static MetadataViewFactory GetMetadataViewFactory(Type viewType)
	{
		Assumes.NotNull(viewType);
		Assumes.True(viewType.GetTypeInfo().IsInterface);
		MetadataViewFactory value;
		lock (MetadataViewFactories)
		{
			if (!MetadataViewFactories.TryGetValue(viewType, out value))
			{
				value = (MetadataViewFactory)GenerateInterfaceViewProxyType(viewType).GetMethod("Create", BindingFlags.Static | BindingFlags.Public).CreateDelegate(typeof(MetadataViewFactory));
				MetadataViewFactories.Add(viewType, value);
			}
		}
		return value;
	}

	private static TypeInfo GenerateInterfaceViewProxyType(Type viewType)
	{
		Type[] interfaces = new Type[1] { viewType };
		ModuleBuilder proxyModuleBuilder = GetProxyModuleBuilder();
		skipClrVisibilityChecks.SkipVisibilityChecksFor(viewType.GetTypeInfo());
		TypeBuilder typeBuilder = proxyModuleBuilder.DefineType(string.Format(CultureInfo.InvariantCulture, "_proxy_{0}_{1}", new object[2]
		{
			viewType.FullName,
			Guid.NewGuid()
		}), TypeAttributes.Public, typeof(object), interfaces);
		FieldBuilder field = typeBuilder.DefineField("metadata", CtorArgumentTypes[0], FieldAttributes.Private | FieldAttributes.InitOnly);
		FieldBuilder field2 = typeBuilder.DefineField("metadataDefault", CtorArgumentTypes[1], FieldAttributes.Private | FieldAttributes.InitOnly);
		ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Private, CallingConventions.Standard, CtorArgumentTypes);
		ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, ObjectCtor);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		iLGenerator.Emit(OpCodes.Stfld, field);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_2);
		iLGenerator.Emit(OpCodes.Stfld, field2);
		iLGenerator.Emit(OpCodes.Ret);
		foreach (PropertyInfo allProperty in viewType.GetAllProperties())
		{
			string name = allProperty.Name;
			Type[] parameterTypes = new Type[1] { allProperty.PropertyType };
			Type[] array = null;
			Type[] array2 = null;
			array = allProperty.GetOptionalCustomModifiers();
			array2 = allProperty.GetRequiredCustomModifiers();
			Array.Reverse(array);
			Array.Reverse(array2);
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None, allProperty.PropertyType, parameterTypes);
			MethodBuilder methodBuilder = typeBuilder.DefineMethod(string.Format(CultureInfo.InvariantCulture, "get_{0}", new object[1] { name }), MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.SpecialName, CallingConventions.HasThis, allProperty.PropertyType, array2, array, Type.EmptyTypes, null, null);
			typeBuilder.DefineMethodOverride(methodBuilder, allProperty.GetGetMethod());
			ILGenerator iLGenerator2 = methodBuilder.GetILGenerator();
			LocalBuilder local = iLGenerator2.DeclareLocal(typeof(object));
			iLGenerator2.Emit(OpCodes.Ldarg_0);
			iLGenerator2.Emit(OpCodes.Ldfld, field);
			iLGenerator2.Emit(OpCodes.Ldstr, name);
			iLGenerator2.Emit(OpCodes.Ldloca_S, local);
			iLGenerator2.Emit(OpCodes.Callvirt, MdvDictionaryTryGet);
			Label label = iLGenerator2.DefineLabel();
			iLGenerator2.Emit(OpCodes.Brtrue_S, label);
			iLGenerator2.Emit(OpCodes.Ldarg_0);
			iLGenerator2.Emit(OpCodes.Ldfld, field2);
			iLGenerator2.Emit(OpCodes.Ldstr, name);
			iLGenerator2.Emit(OpCodes.Callvirt, MdvDictionaryIndexer);
			iLGenerator2.Emit(OpCodes.Stloc_0);
			iLGenerator2.MarkLabel(label);
			iLGenerator2.Emit(OpCodes.Ldloc_0);
			iLGenerator2.Emit(allProperty.PropertyType.GetTypeInfo().IsValueType ? OpCodes.Unbox_Any : OpCodes.Isinst, allProperty.PropertyType);
			iLGenerator2.Emit(OpCodes.Ret);
			propertyBuilder.SetGetMethod(methodBuilder);
		}
		ILGenerator iLGenerator3 = typeBuilder.DefineMethod("Create", MethodAttributes.Public | MethodAttributes.Static, typeof(object), CtorArgumentTypes).GetILGenerator();
		iLGenerator3.Emit(OpCodes.Ldarg_0);
		iLGenerator3.Emit(OpCodes.Ldarg_1);
		iLGenerator3.Emit(OpCodes.Newobj, constructorBuilder);
		iLGenerator3.Emit(OpCodes.Ret);
		return typeBuilder.CreateTypeInfo();
	}

	private static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
	{
		return type.GetTypeInfo().GetInterfaces().Concat(new Type[1] { type })
			.SelectMany((Type itf) => itf.GetTypeInfo().GetProperties());
	}
}

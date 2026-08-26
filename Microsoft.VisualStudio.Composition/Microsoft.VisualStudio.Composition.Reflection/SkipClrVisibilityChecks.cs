using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.VisualStudio.Composition.Reflection;

internal class SkipClrVisibilityChecks
{
	private static readonly ConstructorInfo AttributeBaseClassCtor = typeof(Attribute).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Single((ConstructorInfo ctor) => ctor.GetParameters().Length == 0);

	private static readonly ConstructorInfo AttributeUsageCtor = typeof(AttributeUsageAttribute).GetConstructor(new Type[1] { typeof(AttributeTargets) });

	private static readonly PropertyInfo AttributeUsageAllowMultipleProperty = typeof(AttributeUsageAttribute).GetProperty("AllowMultiple");

	private readonly AssemblyBuilder assemblyBuilder;

	private readonly ModuleBuilder moduleBuilder;

	private readonly HashSet<string> attributedAssemblyNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private ConstructorInfo magicAttributeCtor;

	internal SkipClrVisibilityChecks(AssemblyBuilder assemblyBuilder, ModuleBuilder moduleBuilder)
	{
		Requires.NotNull(assemblyBuilder, "assemblyBuilder");
		Requires.NotNull(moduleBuilder, "moduleBuilder");
		this.assemblyBuilder = assemblyBuilder;
		this.moduleBuilder = moduleBuilder;
	}

	internal void SkipVisibilityChecksFor(MemberInfo memberInfo)
	{
		SkipVisibilityChecksFor(memberInfo.Module.Assembly);
	}

	private void SkipVisibilityChecksFor(Assembly assembly)
	{
		Requires.NotNull(assembly, "assembly");
		AssemblyName name = assembly.GetName();
		SkipVisibilityChecksFor(name);
	}

	private void SkipVisibilityChecksFor(AssemblyName assemblyName)
	{
		Requires.NotNull(assemblyName, "assemblyName");
		string name = assemblyName.Name;
		if (attributedAssemblyNames.Add(name))
		{
			CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(GetMagicAttributeCtor(), new object[1] { name });
			assemblyBuilder.SetCustomAttribute(customAttribute);
		}
	}

	private ConstructorInfo GetMagicAttributeCtor()
	{
		if (magicAttributeCtor == null)
		{
			TypeInfo typeInfo = EmitMagicAttribute();
			magicAttributeCtor = typeInfo.GetConstructor(new Type[1] { typeof(string) });
		}
		return magicAttributeCtor;
	}

	private TypeInfo EmitMagicAttribute()
	{
		TypeBuilder typeBuilder = moduleBuilder.DefineType("System.Runtime.CompilerServices.IgnoresAccessChecksToAttribute", TypeAttributes.NotPublic, typeof(Attribute));
		CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(AttributeUsageCtor, new object[1] { AttributeTargets.Assembly }, new PropertyInfo[1] { AttributeUsageAllowMultipleProperty }, new object[1] { false });
		typeBuilder.SetCustomAttribute(customAttribute);
		ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, CallingConventions.Standard, new Type[1] { typeof(string) });
		constructorBuilder.DefineParameter(1, ParameterAttributes.None, "assemblyName");
		ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, AttributeBaseClassCtor);
		iLGenerator.Emit(OpCodes.Ret);
		return typeBuilder.CreateTypeInfo();
	}
}

using System;
using System.Collections;

namespace DevX.Cecil
{
	internal class MetadataResolver
	{
		private AssemblyDefinition assembly;

		public IAssemblyResolver AssemblyResolver => assembly.Resolver;

		public MetadataResolver(AssemblyDefinition assembly)
		{
			this.assembly = assembly;
		}

		public TypeDefinition Resolve(TypeReference type)
		{
			type = type.GetOriginalType();
			if (type is TypeDefinition)
			{
				return (TypeDefinition)type;
			}
			AssemblyNameReference assemblyNameReference = type.Scope as AssemblyNameReference;
			if (assemblyNameReference != null)
			{
				return AssemblyResolver.Resolve(assemblyNameReference)?.MainModule.Types[type.FullName];
			}
			ModuleDefinition moduleDefinition = type.Scope as ModuleDefinition;
			if (moduleDefinition != null)
			{
				return moduleDefinition.Types[type.FullName];
			}
			ModuleReference moduleReference = type.Scope as ModuleReference;
			if (moduleReference != null)
			{
				foreach (ModuleDefinition module in type.Module.Assembly.Modules)
				{
					if (module.Name == moduleReference.Name)
					{
						return module.Types[type.FullName];
					}
				}
			}
			throw new NotImplementedException();
		}

		public FieldDefinition Resolve(FieldReference field)
		{
			TypeDefinition typeDefinition = Resolve(field.DeclaringType);
			if (typeDefinition == null)
			{
				return null;
			}
			return (!typeDefinition.HasFields) ? null : GetField(typeDefinition.Fields, field);
		}

		private static FieldDefinition GetField(ICollection collection, FieldReference reference)
		{
			foreach (FieldDefinition item in collection)
			{
				if (!(item.Name != reference.Name) && AreSame(item.FieldType, reference.FieldType))
				{
					return item;
				}
			}
			return null;
		}

		public MethodDefinition Resolve(MethodReference method)
		{
			TypeDefinition typeDefinition = Resolve(method.DeclaringType);
			if (typeDefinition == null)
			{
				return null;
			}
			method = method.GetOriginalMethod();
			if (method.Name == ".cctor" || method.Name == ".ctor")
			{
				return (!typeDefinition.HasConstructors) ? null : GetMethod(typeDefinition.Constructors, method);
			}
			return (!typeDefinition.HasMethods) ? null : GetMethod(typeDefinition, method);
		}

		private MethodDefinition GetMethod(TypeDefinition type, MethodReference reference)
		{
			while (type != null)
			{
				MethodDefinition method = GetMethod(type.Methods, reference);
				if (method == null)
				{
					if (type.BaseType == null)
					{
						return null;
					}
					type = Resolve(type.BaseType);
					continue;
				}
				return method;
			}
			return null;
		}

		private static MethodDefinition GetMethod(ICollection collection, MethodReference reference)
		{
			foreach (MethodDefinition item in collection)
			{
				if (!(item.Name != reference.Name) && AreSame(item.ReturnType.ReturnType, reference.ReturnType.ReturnType) && item.HasParameters == reference.HasParameters)
				{
					if (!item.HasParameters && !reference.HasParameters)
					{
						return item;
					}
					if (AreSame(item.Parameters, reference.Parameters))
					{
						return item;
					}
				}
			}
			return null;
		}

		private static bool AreSame(ParameterDefinitionCollection a, ParameterDefinitionCollection b)
		{
			if (a.Count != b.Count)
			{
				return false;
			}
			if (a.Count == 0)
			{
				return true;
			}
			for (int i = 0; i < a.Count; i++)
			{
				if (!AreSame(a[i].ParameterType, b[i].ParameterType))
				{
					return false;
				}
			}
			return true;
		}

		private static bool AreSame(ModType a, ModType b)
		{
			if (!AreSame(a.ModifierType, b.ModifierType))
			{
				return false;
			}
			return AreSame(a.ElementType, b.ElementType);
		}

		private static bool AreSame(TypeSpecification a, TypeSpecification b)
		{
			if (a is GenericInstanceType)
			{
				return AreSame((GenericInstanceType)a, (GenericInstanceType)b);
			}
			if (a is ModType)
			{
				return AreSame((ModType)a, (ModType)b);
			}
			return AreSame(a.ElementType, b.ElementType);
		}

		private static bool AreSame(GenericInstanceType a, GenericInstanceType b)
		{
			if (!AreSame(a.ElementType, b.ElementType))
			{
				return false;
			}
			if (a.GenericArguments.Count != b.GenericArguments.Count)
			{
				return false;
			}
			if (a.GenericArguments.Count == 0)
			{
				return true;
			}
			for (int i = 0; i < a.GenericArguments.Count; i++)
			{
				if (!AreSame(a.GenericArguments[i], b.GenericArguments[i]))
				{
					return false;
				}
			}
			return true;
		}

		private static bool AreSame(GenericParameter a, GenericParameter b)
		{
			return a.Position == b.Position;
		}

		private static bool AreSame(TypeReference a, TypeReference b)
		{
			if (a is TypeSpecification || b is TypeSpecification)
			{
				if (a.GetType() != b.GetType())
				{
					return false;
				}
				return AreSame((TypeSpecification)a, (TypeSpecification)b);
			}
			if (a is GenericParameter || b is GenericParameter)
			{
				if (a.GetType() != b.GetType())
				{
					return false;
				}
				return AreSame((GenericParameter)a, (GenericParameter)b);
			}
			return a.FullName == b.FullName;
		}
	}
}

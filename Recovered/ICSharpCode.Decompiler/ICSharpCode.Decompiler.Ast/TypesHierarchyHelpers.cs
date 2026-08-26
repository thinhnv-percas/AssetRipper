using Mono.Cecil;
using Mono.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast
{
	public static class TypesHierarchyHelpers
	{
		private struct GenericContext<T> where T : class
		{
			private class DummyGenericParameterProvider : IGenericParameterProvider, IMetadataTokenProvider
			{
				private readonly GenericParameterType type;

				private readonly Mono.Collections.Generic.Collection<GenericParameter> parameters;

				public GenericParameter DummyParameter => parameters[0];

				bool IGenericParameterProvider.HasGenericParameters
				{
					get
					{
						throw new NotImplementedException();
					}
				}

				bool IGenericParameterProvider.IsDefinition
				{
					get
					{
						throw new NotImplementedException();
					}
				}

				ModuleDefinition IGenericParameterProvider.Module
				{
					get
					{
						throw new NotImplementedException();
					}
				}

				Mono.Collections.Generic.Collection<GenericParameter> IGenericParameterProvider.GenericParameters => parameters;

				GenericParameterType IGenericParameterProvider.GenericParameterType => type;

				MetadataToken IMetadataTokenProvider.MetadataToken
				{
					get
					{
						throw new NotImplementedException();
					}
					set
					{
						throw new NotImplementedException();
					}
				}

				public DummyGenericParameterProvider(bool methodTypeParameter)
				{
					type = (methodTypeParameter ? GenericParameterType.Method : GenericParameterType.Type);
					parameters = new Mono.Collections.Generic.Collection<GenericParameter>(1);
					parameters.Add(new GenericParameter(this));
				}
			}

			private static readonly System.Collections.ObjectModel.ReadOnlyCollection<TypeReference> Empty = new System.Collections.ObjectModel.ReadOnlyCollection<TypeReference>(new List<TypeReference>());

			private static readonly GenericParameter UnresolvedGenericTypeParameter = new DummyGenericParameterProvider(methodTypeParameter: false).DummyParameter;

			private static readonly GenericParameter UnresolvedGenericMethodParameter = new DummyGenericParameterProvider(methodTypeParameter: true).DummyParameter;

			public readonly T Item;

			public readonly System.Collections.ObjectModel.ReadOnlyCollection<TypeReference> TypeArguments;

			public GenericContext(T item)
			{
				if (item == null)
				{
					throw new ArgumentNullException("item");
				}
				Item = item;
				TypeArguments = Empty;
			}

			public GenericContext(T item, IEnumerable<TypeReference> typeArguments)
			{
				if (item == null)
				{
					throw new ArgumentNullException("item");
				}
				Item = item;
				List<TypeReference> list = new List<TypeReference>();
				foreach (TypeReference typeArgument in typeArguments)
				{
					TypeReference typeReference = (typeArgument != null) ? typeArgument.Resolve() : typeArgument;
					list.Add((typeReference != null) ? typeReference : typeArgument);
				}
				TypeArguments = new System.Collections.ObjectModel.ReadOnlyCollection<TypeReference>(list);
			}

			private GenericContext(T item, System.Collections.ObjectModel.ReadOnlyCollection<TypeReference> typeArguments)
			{
				Item = item;
				TypeArguments = typeArguments;
			}

			public TypeReference ResolveWithContext(TypeReference type)
			{
				GenericParameter genericParameter = type as GenericParameter;
				if (genericParameter != null)
				{
					if (genericParameter.Owner.GenericParameterType == GenericParameterType.Type)
					{
						return TypeArguments[genericParameter.Position];
					}
					if (genericParameter.Owner.GenericParameterType != 0)
					{
						return UnresolvedGenericMethodParameter;
					}
					return UnresolvedGenericTypeParameter;
				}
				TypeSpecification typeSpecification = type as TypeSpecification;
				if (typeSpecification != null)
				{
					TypeReference newElementType = ResolveWithContext(typeSpecification.ElementType);
					return ReplaceElementType(typeSpecification, newElementType);
				}
				return type.ResolveOrThrow();
			}

			private TypeReference ReplaceElementType(TypeSpecification ts, TypeReference newElementType)
			{
				ArrayType arrayType = ts as ArrayType;
				if (arrayType != null)
				{
					if (newElementType == arrayType.ElementType)
					{
						return arrayType;
					}
					ArrayType arrayType2 = new ArrayType(newElementType, arrayType.Rank);
					for (int i = 0; i < arrayType.Rank; i++)
					{
						arrayType2.Dimensions[i] = arrayType.Dimensions[i];
					}
					return arrayType2;
				}
				if (ts is ByReferenceType)
				{
					return new ByReferenceType(newElementType);
				}
				return ts.ResolveOrThrow();
			}

			public GenericContext<T2> ApplyTo<T2>(T2 item) where T2 : class
			{
				return new GenericContext<T2>(item, TypeArguments);
			}
		}

		public static bool IsBaseType(TypeDefinition baseType, TypeDefinition derivedType, bool resolveTypeArguments)
		{
			if (resolveTypeArguments)
			{
				return BaseTypes(derivedType).Any((GenericContext<TypeDefinition> t) => t.Item == baseType);
			}
			TypeDefinition typeDefinition = baseType.Resolve();
			if (typeDefinition == null)
			{
				return false;
			}
			while (derivedType.BaseType != null)
			{
				TypeDefinition typeDefinition2 = derivedType.BaseType.Resolve();
				if (typeDefinition2 == null)
				{
					return false;
				}
				if (typeDefinition == typeDefinition2)
				{
					return true;
				}
				derivedType = typeDefinition2;
			}
			return false;
		}

		public static bool IsBaseMethod(MethodDefinition parentMethod, MethodDefinition childMethod)
		{
			if (parentMethod == null)
			{
				throw new ArgumentNullException("parentMethod");
			}
			if (childMethod == null)
			{
				throw new ArgumentNullException("childMethod");
			}
			if (parentMethod.Name != childMethod.Name)
			{
				return false;
			}
			if ((parentMethod.HasParameters || childMethod.HasParameters) && (!parentMethod.HasParameters || !childMethod.HasParameters || parentMethod.Parameters.Count != childMethod.Parameters.Count))
			{
				return false;
			}
			return FindBaseMethods(childMethod).Any((MethodDefinition m) => m == parentMethod);
		}

		public static bool IsBaseProperty(PropertyDefinition parentProperty, PropertyDefinition childProperty)
		{
			if (parentProperty == null)
			{
				throw new ArgumentNullException("parentProperty");
			}
			if (childProperty == null)
			{
				throw new ArgumentNullException("childProperty");
			}
			if (parentProperty.Name != childProperty.Name)
			{
				return false;
			}
			if ((parentProperty.HasParameters || childProperty.HasParameters) && (!parentProperty.HasParameters || !childProperty.HasParameters || parentProperty.Parameters.Count != childProperty.Parameters.Count))
			{
				return false;
			}
			return FindBaseProperties(childProperty).Any((PropertyDefinition m) => m == parentProperty);
		}

		public static bool IsBaseEvent(EventDefinition parentEvent, EventDefinition childEvent)
		{
			if (parentEvent.Name != childEvent.Name)
			{
				return false;
			}
			return FindBaseEvents(childEvent).Any((EventDefinition m) => m == parentEvent);
		}

		public static IEnumerable<MethodDefinition> FindBaseMethods(MethodDefinition method)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			GenericContext<MethodDefinition> gMethod = CreateGenericContext(method.DeclaringType).ApplyTo(method);
			foreach (GenericContext<TypeDefinition> item in BaseTypes(method.DeclaringType))
			{
				GenericContext<TypeDefinition> baseType = item;
				foreach (MethodDefinition baseMethod in baseType.Item.Methods)
				{
					if (MatchMethod(baseType.ApplyTo(baseMethod), gMethod) && IsVisibleFromDerived(baseMethod, method.DeclaringType))
					{
						yield return baseMethod;
						if (baseMethod.IsNewSlot == baseMethod.IsVirtual)
						{
							yield break;
						}
					}
				}
			}
		}

		public static IEnumerable<PropertyDefinition> FindBaseProperties(PropertyDefinition property)
		{
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}
			if (!(property.GetMethod ?? property.SetMethod).HasOverrides)
			{
				GenericContext<PropertyDefinition> gProperty = CreateGenericContext(property.DeclaringType).ApplyTo(property);
				bool isIndexer = property.IsIndexer();
				foreach (GenericContext<TypeDefinition> item in BaseTypes(property.DeclaringType))
				{
					GenericContext<TypeDefinition> baseType = item;
					foreach (PropertyDefinition baseProperty in baseType.Item.Properties)
					{
						if (MatchProperty(baseType.ApplyTo(baseProperty), gProperty) && IsVisibleFromDerived(baseProperty, property.DeclaringType) && isIndexer == baseProperty.IsIndexer())
						{
							yield return baseProperty;
							MethodDefinition methodDefinition = baseProperty.GetMethod ?? baseProperty.SetMethod;
							if (methodDefinition.IsNewSlot == methodDefinition.IsVirtual)
							{
								yield break;
							}
						}
					}
				}
			}
		}

		public static IEnumerable<EventDefinition> FindBaseEvents(EventDefinition eventDef)
		{
			if (eventDef == null)
			{
				throw new ArgumentNullException("eventDef");
			}
			GenericContext<EventDefinition> gEvent = CreateGenericContext(eventDef.DeclaringType).ApplyTo(eventDef);
			foreach (GenericContext<TypeDefinition> item in BaseTypes(eventDef.DeclaringType))
			{
				GenericContext<TypeDefinition> baseType = item;
				foreach (EventDefinition baseEvent in baseType.Item.Events)
				{
					if (MatchEvent(baseType.ApplyTo(baseEvent), gEvent) && IsVisibleFromDerived(baseEvent, eventDef.DeclaringType))
					{
						yield return baseEvent;
						MethodDefinition methodDefinition = baseEvent.AddMethod ?? baseEvent.RemoveMethod;
						if (methodDefinition.IsNewSlot == methodDefinition.IsVirtual)
						{
							yield break;
						}
					}
				}
			}
		}

		public static bool IsVisibleFromDerived(IMemberDefinition baseMember, TypeDefinition derivedType)
		{
			if (baseMember == null)
			{
				throw new ArgumentNullException("baseMember");
			}
			if (derivedType == null)
			{
				throw new ArgumentNullException("derivedType");
			}
			MethodAttributes methodAttributes = GetAccessAttributes(baseMember) & MethodAttributes.MemberAccessMask;
			if (methodAttributes == MethodAttributes.Private)
			{
				return false;
			}
			if (baseMember.DeclaringType.Module == derivedType.Module)
			{
				return true;
			}
			if (methodAttributes == MethodAttributes.Assembly || methodAttributes == MethodAttributes.FamANDAssem)
			{
				AssemblyDefinition assembly = derivedType.Module.Assembly;
				AssemblyDefinition assembly2 = baseMember.DeclaringType.Module.Assembly;
				if (assembly2.HasCustomAttributes)
				{
					foreach (CustomAttribute item in from attr in assembly2.CustomAttributes
						where attr.AttributeType.FullName == "System.Runtime.CompilerServices.InternalsVisibleToAttribute"
						select attr)
					{
						if ((item.ConstructorArguments[0].Value as string).Split(',')[0] == assembly.Name.Name)
						{
							return true;
						}
					}
				}
				return false;
			}
			return true;
		}

		private static MethodAttributes GetAccessAttributes(IMemberDefinition member)
		{
			FieldDefinition fieldDefinition = member as FieldDefinition;
			if (fieldDefinition != null)
			{
				return (MethodAttributes)fieldDefinition.Attributes;
			}
			MethodDefinition methodDefinition = member as MethodDefinition;
			if (methodDefinition != null)
			{
				return methodDefinition.Attributes;
			}
			PropertyDefinition propertyDefinition = member as PropertyDefinition;
			if (propertyDefinition != null)
			{
				return (propertyDefinition.GetMethod ?? propertyDefinition.SetMethod).Attributes;
			}
			EventDefinition eventDefinition = member as EventDefinition;
			if (eventDefinition != null)
			{
				return (eventDefinition.AddMethod ?? eventDefinition.RemoveMethod).Attributes;
			}
			TypeDefinition typeDefinition = member as TypeDefinition;
			if (typeDefinition != null)
			{
				if (typeDefinition.IsNestedPrivate)
				{
					return MethodAttributes.Private;
				}
				if (typeDefinition.IsNestedAssembly || typeDefinition.IsNestedFamilyAndAssembly)
				{
					return MethodAttributes.Assembly;
				}
				return MethodAttributes.Public;
			}
			throw new NotSupportedException();
		}

		private static bool MatchMethod(GenericContext<MethodDefinition> candidate, GenericContext<MethodDefinition> method)
		{
			MethodDefinition item = candidate.Item;
			MethodDefinition item2 = method.Item;
			if (item.Name != item2.Name)
			{
				return false;
			}
			if (item.HasOverrides)
			{
				return false;
			}
			if (item.IsSpecialName != method.Item.IsSpecialName)
			{
				return false;
			}
			if ((item.HasGenericParameters || item2.HasGenericParameters) && (!item.HasGenericParameters || !item2.HasGenericParameters || item.GenericParameters.Count != item2.GenericParameters.Count))
			{
				return false;
			}
			if (item.HasParameters || item2.HasParameters)
			{
				if (!item.HasParameters || !item2.HasParameters || item.Parameters.Count != item2.Parameters.Count)
				{
					return false;
				}
				for (int i = 0; i < item.Parameters.Count; i++)
				{
					if (!MatchParameters(candidate.ApplyTo(item.Parameters[i]), method.ApplyTo(item2.Parameters[i])))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static bool MatchInterfaceMethod(MethodDefinition candidate, MethodDefinition method, TypeReference interfaceContextType)
		{
			GenericContext<TypeDefinition> genericContext = CreateGenericContext(candidate.DeclaringType);
			GenericContext<MethodDefinition> candidate2 = genericContext.ApplyTo(candidate);
			if (interfaceContextType is GenericInstanceType)
			{
				GenericContext<MethodDefinition> method2 = new GenericContext<TypeDefinition>(interfaceContextType.Resolve(), ((GenericInstanceType)interfaceContextType).GenericArguments).ApplyTo(method);
				return MatchMethod(candidate2, method2);
			}
			CreateGenericContext(interfaceContextType.Resolve());
			GenericContext<MethodDefinition> method3 = genericContext.ApplyTo(method);
			return MatchMethod(candidate2, method3);
		}

		private static bool MatchProperty(GenericContext<PropertyDefinition> candidate, GenericContext<PropertyDefinition> property)
		{
			PropertyDefinition item = candidate.Item;
			PropertyDefinition item2 = property.Item;
			if (item.Name != item2.Name)
			{
				return false;
			}
			if ((item.GetMethod ?? item.SetMethod).HasOverrides)
			{
				return false;
			}
			if (item.HasParameters || item2.HasParameters)
			{
				if (!item.HasParameters || !item2.HasParameters || item.Parameters.Count != item2.Parameters.Count)
				{
					return false;
				}
				for (int i = 0; i < item.Parameters.Count; i++)
				{
					if (!MatchParameters(candidate.ApplyTo(item.Parameters[i]), property.ApplyTo(item2.Parameters[i])))
					{
						return false;
					}
				}
			}
			return true;
		}

		private static bool MatchEvent(GenericContext<EventDefinition> candidate, GenericContext<EventDefinition> ev)
		{
			EventDefinition item = candidate.Item;
			EventDefinition item2 = ev.Item;
			if (item.Name != item2.Name)
			{
				return false;
			}
			if ((item.AddMethod ?? item.RemoveMethod).HasOverrides)
			{
				return false;
			}
			if (!IsSameType(candidate.ResolveWithContext(item.EventType), ev.ResolveWithContext(item2.EventType)))
			{
				return false;
			}
			return true;
		}

		private static bool MatchParameters(GenericContext<ParameterDefinition> baseParameterType, GenericContext<ParameterDefinition> parameterType)
		{
			if (baseParameterType.Item.IsIn != parameterType.Item.IsIn || baseParameterType.Item.IsOut != parameterType.Item.IsOut)
			{
				return false;
			}
			TypeReference tr = baseParameterType.ResolveWithContext(baseParameterType.Item.ParameterType);
			TypeReference tr2 = parameterType.ResolveWithContext(parameterType.Item.ParameterType);
			return IsSameType(tr, tr2);
		}

		private static bool IsSameType(TypeReference tr1, TypeReference tr2)
		{
			if (tr1 == tr2)
			{
				return true;
			}
			if (tr1 == null || tr2 == null)
			{
				return false;
			}
			if (tr1.GetType() != tr2.GetType())
			{
				return false;
			}
			if (tr1.Name == tr2.Name && tr1.FullName == tr2.FullName)
			{
				return true;
			}
			return false;
		}

		private static IEnumerable<GenericContext<TypeDefinition>> BaseTypes(TypeDefinition type)
		{
			return BaseTypes(CreateGenericContext(type));
		}

		private static IEnumerable<GenericContext<TypeDefinition>> BaseTypes(GenericContext<TypeDefinition> type)
		{
			while (type.Item.BaseType != null)
			{
				TypeReference baseType = type.Item.BaseType;
				GenericInstanceType genericInstanceType = baseType as GenericInstanceType;
				if (genericInstanceType != null)
				{
					type = new GenericContext<TypeDefinition>(genericInstanceType.ResolveOrThrow(), from t in genericInstanceType.GenericArguments
						select type.ResolveWithContext(t));
				}
				else
				{
					type = new GenericContext<TypeDefinition>(baseType.ResolveOrThrow());
				}
				yield return type;
			}
		}

		private static GenericContext<TypeDefinition> CreateGenericContext(TypeDefinition type)
		{
			if (!type.HasGenericParameters)
			{
				return new GenericContext<TypeDefinition>(type);
			}
			return new GenericContext<TypeDefinition>(type, type.GenericParameters);
		}
	}
}

using System;

namespace DevX.Cecil
{
	public class DefaultImporter : IImporter
	{
		private ModuleDefinition m_module;

		public ModuleDefinition Module => m_module;

		public DefaultImporter(ModuleDefinition module)
		{
			m_module = module;
		}

		public AssemblyNameReference ImportAssembly(AssemblyNameReference asm)
		{
			AssemblyNameReference assemblyNameReference = GetAssemblyNameReference(asm);
			if (assemblyNameReference != null)
			{
				return assemblyNameReference;
			}
			assemblyNameReference = new AssemblyNameReference(asm.Name, asm.Culture, asm.Version);
			assemblyNameReference.PublicKeyToken = asm.PublicKeyToken;
			assemblyNameReference.HashAlgorithm = asm.HashAlgorithm;
			m_module.AssemblyReferences.Add(assemblyNameReference);
			return assemblyNameReference;
		}

		private AssemblyNameReference GetAssemblyNameReference(AssemblyNameReference asm)
		{
			foreach (AssemblyNameReference assemblyReference in m_module.AssemblyReferences)
			{
				if (assemblyReference.FullName == asm.FullName)
				{
					return assemblyReference;
				}
			}
			return null;
		}

		private TypeSpecification GetTypeSpec(TypeSpecification original, ImportContext context)
		{
			TypeReference typeReference = ImportTypeReference(original.ElementType, context);
			if (original is PointerType)
			{
				return new PointerType(typeReference);
			}
			if (original is ArrayType)
			{
				return new ArrayType(typeReference);
			}
			if (original is ReferenceType)
			{
				return new ReferenceType(typeReference);
			}
			if (original is GenericInstanceType)
			{
				GenericInstanceType genericInstanceType = original as GenericInstanceType;
				GenericInstanceType genericInstanceType2 = new GenericInstanceType(typeReference);
				context.GenericContext.CheckProvider(genericInstanceType2.GetOriginalType(), genericInstanceType.GenericArguments.Count);
				foreach (TypeReference genericArgument in genericInstanceType.GenericArguments)
				{
					genericInstanceType2.GenericArguments.Add(ImportTypeReference(genericArgument, context));
				}
				return genericInstanceType2;
			}
			if (original is ModifierOptional)
			{
				TypeReference modifierType = (original as ModifierOptional).ModifierType;
				return new ModifierOptional(typeReference, ImportTypeReference(modifierType, context));
			}
			if (original is ModifierRequired)
			{
				TypeReference modifierType2 = (original as ModifierRequired).ModifierType;
				return new ModifierRequired(typeReference, ImportTypeReference(modifierType2, context));
			}
			if (original is SentinelType)
			{
				return new SentinelType(typeReference);
			}
			if (original is FunctionPointerType)
			{
				FunctionPointerType functionPointerType = original as FunctionPointerType;
				FunctionPointerType functionPointerType2 = new FunctionPointerType(functionPointerType.HasThis, functionPointerType.ExplicitThis, functionPointerType.CallingConvention, new MethodReturnType(ImportTypeReference(functionPointerType.ReturnType.ReturnType, context)));
				foreach (ParameterDefinition parameter in functionPointerType.Parameters)
				{
					functionPointerType2.Parameters.Add(new ParameterDefinition(ImportTypeReference(parameter.ParameterType, context)));
				}
				return functionPointerType2;
			}
			throw new ReflectionException("Unknown element type: {0}", original.GetType().Name);
		}

		private static GenericParameter GetGenericParameter(GenericParameter gp, ImportContext context)
		{
			if (gp.Owner is TypeReference)
			{
				return context.GenericContext.Type.GenericParameters[gp.Position];
			}
			if (gp.Owner is MethodReference)
			{
				return context.GenericContext.Method.GenericParameters[gp.Position];
			}
			throw new NotSupportedException();
		}

		private TypeReference AdjustReference(TypeReference type, TypeReference reference)
		{
			if (type.IsValueType && !reference.IsValueType)
			{
				reference.IsValueType = true;
			}
			if (type.HasGenericParameters)
			{
				for (int i = reference.GenericParameters.Count; i < type.GenericParameters.Count; i++)
				{
					reference.GenericParameters.Add(new GenericParameter(i, reference));
				}
			}
			return reference;
		}

		public virtual TypeReference ImportTypeReference(TypeReference t, ImportContext context)
		{
			if (t.Module == m_module)
			{
				return t;
			}
			if (t is TypeSpecification)
			{
				return GetTypeSpec(t as TypeSpecification, context);
			}
			if (t is GenericParameter)
			{
				return GetGenericParameter(t as GenericParameter, context);
			}
			TypeReference typeReference = m_module.TypeReferences[t.FullName];
			if (typeReference != null)
			{
				return AdjustReference(t, typeReference);
			}
			AssemblyNameReference scope;
			if (t.Scope is AssemblyNameReference)
			{
				scope = ImportAssembly((AssemblyNameReference)t.Scope);
			}
			else
			{
				if (!(t.Scope is ModuleDefinition))
				{
					throw new NotImplementedException();
				}
				scope = ImportAssembly(((ModuleDefinition)t.Scope).Assembly.Name);
			}
			if (t.DeclaringType != null)
			{
				typeReference = new TypeReference(t.Name, string.Empty, scope, t.IsValueType);
				typeReference.DeclaringType = ImportTypeReference(t.DeclaringType, context);
			}
			else
			{
				typeReference = new TypeReference(t.Name, t.Namespace, scope, t.IsValueType);
			}
			TypeReference type = context.GenericContext.Type;
			context.GenericContext.Type = typeReference;
			GenericParameter.CloneInto(t, typeReference, context);
			context.GenericContext.Type = type;
			m_module.TypeReferences.Add(typeReference);
			return typeReference;
		}

		public virtual FieldReference ImportFieldReference(FieldReference fr, ImportContext context)
		{
			if (fr.DeclaringType.Module == m_module)
			{
				return fr;
			}
			FieldReference fieldReference = (FieldReference)GetMemberReference(fr);
			if (fieldReference != null)
			{
				return fieldReference;
			}
			fieldReference = new FieldReference(fr.Name, ImportTypeReference(fr.DeclaringType, context), ImportTypeReference(fr.FieldType, context));
			m_module.MemberReferences.Add(fieldReference);
			return fieldReference;
		}

		private MethodReference GetMethodSpec(MethodReference meth, ImportContext context)
		{
			if (!(meth is GenericInstanceMethod))
			{
				return null;
			}
			GenericInstanceMethod genericInstanceMethod = meth as GenericInstanceMethod;
			GenericInstanceMethod genericInstanceMethod2 = new GenericInstanceMethod(ImportMethodReference(genericInstanceMethod.ElementMethod, context));
			context.GenericContext.CheckProvider(genericInstanceMethod2.GetOriginalMethod(), genericInstanceMethod.GenericArguments.Count);
			foreach (TypeReference genericArgument in genericInstanceMethod.GenericArguments)
			{
				genericInstanceMethod2.GenericArguments.Add(ImportTypeReference(genericArgument, context));
			}
			return genericInstanceMethod2;
		}

		public virtual MethodReference ImportMethodReference(MethodReference mr, ImportContext context)
		{
			if (mr.DeclaringType.Module == m_module)
			{
				return mr;
			}
			if (mr is MethodSpecification)
			{
				return GetMethodSpec(mr, context);
			}
			MethodReference methodReference = (MethodReference)GetMemberReference(mr);
			if (methodReference != null)
			{
				return methodReference;
			}
			methodReference = new MethodReference(mr.Name, mr.HasThis, mr.ExplicitThis, mr.CallingConvention);
			methodReference.DeclaringType = ImportTypeReference(mr.DeclaringType, context);
			TypeReference type = context.GenericContext.Type;
			MethodReference method = context.GenericContext.Method;
			context.GenericContext.Method = methodReference;
			context.GenericContext.Type = methodReference.DeclaringType.GetOriginalType();
			GenericParameter.CloneInto(mr, methodReference, context);
			methodReference.ReturnType.ReturnType = ImportTypeReference(mr.ReturnType.ReturnType, context);
			foreach (ParameterDefinition parameter in mr.Parameters)
			{
				methodReference.Parameters.Add(new ParameterDefinition(ImportTypeReference(parameter.ParameterType, context)));
			}
			context.GenericContext.Type = type;
			context.GenericContext.Method = method;
			m_module.MemberReferences.Add(methodReference);
			return methodReference;
		}

		private MemberReference GetMemberReference(MemberReference member)
		{
			foreach (MemberReference memberReference in m_module.MemberReferences)
			{
				if (memberReference.ToString() == member.ToString())
				{
					return memberReference;
				}
			}
			return null;
		}
	}
}

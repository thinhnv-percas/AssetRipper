using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace DevX.Cecil
{
	internal sealed class ReflectionHelper
	{
		private ModuleDefinition m_module;

		public ReflectionHelper(ModuleDefinition module)
		{
			m_module = module;
		}

		public AssemblyNameReference ImportAssembly(Assembly asm)
		{
			AssemblyNameReference assemblyNameReference = GetAssemblyNameReference(asm.GetName());
			if (assemblyNameReference != null)
			{
				return assemblyNameReference;
			}
			AssemblyName name = asm.GetName();
			assemblyNameReference = new AssemblyNameReference(name.Name, name.CultureInfo.Name, name.Version);
			assemblyNameReference.PublicKeyToken = name.GetPublicKeyToken();
			assemblyNameReference.HashAlgorithm = (AssemblyHashAlgorithm)name.HashAlgorithm;
			assemblyNameReference.Culture = name.CultureInfo.ToString();
			m_module.AssemblyReferences.Add(assemblyNameReference);
			return assemblyNameReference;
		}

		private AssemblyNameReference GetAssemblyNameReference(AssemblyName name)
		{
			foreach (AssemblyNameReference assemblyReference in m_module.AssemblyReferences)
			{
				if (assemblyReference.FullName == name.FullName)
				{
					return assemblyReference;
				}
			}
			return null;
		}

		public static string GetTypeSignature(Type t)
		{
			if (t.HasElementType)
			{
				if (t.IsPointer)
				{
					return GetTypeSignature(t.GetElementType()) + "*";
				}
				if (t.IsArray)
				{
					int arrayRank = t.GetArrayRank();
					if (arrayRank == 1)
					{
						return GetTypeSignature(t.GetElementType()) + "[]";
					}
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append('[');
					for (int i = 1; i < arrayRank; i++)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(']');
					return GetTypeSignature(t.GetElementType()) + stringBuilder.ToString();
				}
				if (t.IsByRef)
				{
					return GetTypeSignature(t.GetElementType()) + "&";
				}
			}
			if (IsGenericTypeSpec(t))
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.Append(GetTypeSignature(GetGenericTypeDefinition(t)));
				stringBuilder2.Append("<");
				Type[] genericArguments = GetGenericArguments(t);
				for (int j = 0; j < genericArguments.Length; j++)
				{
					if (j > 0)
					{
						stringBuilder2.Append(",");
					}
					stringBuilder2.Append(GetTypeSignature(genericArguments[j]));
				}
				stringBuilder2.Append(">");
				return stringBuilder2.ToString();
			}
			if (IsGenericParameter(t))
			{
				return t.Name;
			}
			if (t.DeclaringType != null)
			{
				return t.DeclaringType.FullName + "/" + t.Name;
			}
			if (t.Namespace == null || t.Namespace.Length == 0)
			{
				return t.Name;
			}
			return t.Namespace + "." + t.Name;
		}

		private static bool GetProperty(object o, string prop)
		{
			PropertyInfo property = o.GetType().GetProperty(prop);
			if (property == null)
			{
				return false;
			}
			return (bool)property.GetValue(o, null);
		}

		public static bool IsGenericType(Type t)
		{
			return GetProperty(t, "IsGenericType");
		}

		private static bool IsGenericParameter(Type t)
		{
			return GetProperty(t, "IsGenericParameter");
		}

		private static bool IsGenericTypeDefinition(Type t)
		{
			return GetProperty(t, "IsGenericTypeDefinition");
		}

		private static bool IsGenericTypeSpec(Type t)
		{
			return IsGenericType(t) && !IsGenericTypeDefinition(t);
		}

		private static Type GetGenericTypeDefinition(Type t)
		{
			return (Type)t.GetType().GetMethod("GetGenericTypeDefinition").Invoke(t, null);
		}

		private static Type[] GetGenericArguments(Type t)
		{
			return (Type[])t.GetType().GetMethod("GetGenericArguments").Invoke(t, null);
		}

		private GenericInstanceType GetGenericType(Type t, TypeReference element, ImportContext context)
		{
			GenericInstanceType genericInstanceType = new GenericInstanceType(element);
			Type[] genericArguments = GetGenericArguments(t);
			foreach (Type t2 in genericArguments)
			{
				genericInstanceType.GenericArguments.Add(ImportSystemType(t2, context));
			}
			return genericInstanceType;
		}

		private static bool GenericParameterOfMethod(Type t)
		{
			return t.GetType().GetProperty("DeclaringMethod").GetValue(t, null) != null;
		}

		private static GenericParameter GetGenericParameter(Type t, ImportContext context)
		{
			int index = (int)t.GetType().GetProperty("GenericParameterPosition").GetValue(t, null);
			IGenericParameterProvider genericParameterProvider = (IGenericParameterProvider)((!GenericParameterOfMethod(t)) ? ((object)context.GenericContext.Type) : ((object)context.GenericContext.Method));
			if (genericParameterProvider == null)
			{
				throw new InvalidOperationException("Invalid context");
			}
			return genericParameterProvider.GenericParameters[index];
		}

		private TypeReference GetTypeSpec(Type t, ImportContext context)
		{
			Stack stack = new Stack();
			while (t.HasElementType || IsGenericTypeSpec(t))
			{
				stack.Push(t);
				if (t.HasElementType)
				{
					t = t.GetElementType();
				}
				else if (IsGenericTypeSpec(t))
				{
					t = (Type)t.GetType().GetMethod("GetGenericTypeDefinition").Invoke(t, null);
					break;
				}
			}
			TypeReference typeReference = ImportSystemType(t, context);
			while (stack.Count > 0)
			{
				t = (Type)stack.Pop();
				if (t.IsPointer)
				{
					typeReference = new PointerType(typeReference);
					continue;
				}
				if (t.IsArray)
				{
					typeReference = new ArrayType(typeReference, t.GetArrayRank());
					continue;
				}
				if (t.IsByRef)
				{
					typeReference = new ReferenceType(typeReference);
					continue;
				}
				if (IsGenericTypeSpec(t))
				{
					typeReference = GetGenericType(t, typeReference, context);
					continue;
				}
				throw new ReflectionException("Unknown element type");
			}
			return typeReference;
		}

		private TypeReference AdjustReference(Type type, TypeReference reference)
		{
			if (type.IsValueType && !reference.IsValueType)
			{
				reference.IsValueType = true;
			}
			if (IsGenericTypeDefinition(type))
			{
				Type[] genericArguments = GetGenericArguments(type);
				for (int i = reference.GenericParameters.Count; i < genericArguments.Length; i++)
				{
					reference.GenericParameters.Add(new GenericParameter(i, reference));
				}
			}
			return reference;
		}

		public TypeReference ImportSystemType(Type t, ImportContext context)
		{
			if (t.HasElementType || IsGenericTypeSpec(t))
			{
				return GetTypeSpec(t, context);
			}
			if (IsGenericParameter(t))
			{
				return GetGenericParameter(t, context);
			}
			TypeReference typeReference = m_module.TypeReferences[GetTypeSignature(t)];
			if (typeReference != null)
			{
				return AdjustReference(t, typeReference);
			}
			AssemblyNameReference scope = ImportAssembly(t.Assembly);
			if (t.DeclaringType != null)
			{
				typeReference = new TypeReference(t.Name, string.Empty, scope, t.IsValueType);
				typeReference.DeclaringType = ImportSystemType(t.DeclaringType, context);
			}
			else
			{
				typeReference = new TypeReference(t.Name, t.Namespace, scope, t.IsValueType);
			}
			if (IsGenericTypeDefinition(t))
			{
				Type[] genericArguments = GetGenericArguments(t);
				foreach (Type type in genericArguments)
				{
					typeReference.GenericParameters.Add(new GenericParameter(type.Name, typeReference));
				}
			}
			context.GenericContext.Type = typeReference;
			m_module.TypeReferences.Add(typeReference);
			return typeReference;
		}

		private static string GetMethodBaseSignature(MethodBase meth, Type declaringType, Type retType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetTypeSignature(retType));
			stringBuilder.Append(' ');
			stringBuilder.Append(GetTypeSignature(declaringType));
			stringBuilder.Append("::");
			stringBuilder.Append(meth.Name);
			if (IsGenericMethodSpec(meth))
			{
				stringBuilder.Append("<");
				Type[] genericArguments = GetGenericArguments(meth as MethodInfo);
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(GetTypeSignature(genericArguments[i]));
				}
				stringBuilder.Append(">");
			}
			stringBuilder.Append("(");
			ParameterInfo[] parameters = meth.GetParameters();
			for (int j = 0; j < parameters.Length; j++)
			{
				if (j > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(GetTypeSignature(parameters[j].ParameterType));
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		private static bool IsGenericMethod(MethodBase mb)
		{
			return GetProperty(mb, "IsGenericMethod");
		}

		private static bool IsGenericMethodDefinition(MethodBase mb)
		{
			return GetProperty(mb, "IsGenericMethodDefinition");
		}

		private static bool IsGenericMethodSpec(MethodBase mb)
		{
			return IsGenericMethod(mb) && !IsGenericMethodDefinition(mb);
		}

		private static Type[] GetGenericArguments(MethodInfo mi)
		{
			return (Type[])mi.GetType().GetMethod("GetGenericArguments").Invoke(mi, null);
		}

		private static int GetMetadataToken(MethodInfo mi)
		{
			return (int)mi.GetType().GetProperty("MetadataToken").GetValue(mi, null);
		}

		private MethodReference ImportGenericInstanceMethod(MethodInfo mi, ImportContext context)
		{
			MethodInfo methodInfo = (MethodInfo)mi.GetType().GetMethod("GetGenericMethodDefinition").Invoke(mi, null);
			GenericInstanceMethod genericInstanceMethod = new GenericInstanceMethod(ImportMethodBase(methodInfo, methodInfo.ReturnType, context));
			Type[] genericArguments = GetGenericArguments(mi);
			foreach (Type t in genericArguments)
			{
				genericInstanceMethod.GenericArguments.Add(ImportSystemType(t, context));
			}
			return genericInstanceMethod;
		}

		private MethodReference ImportMethodBase(MethodBase mb, Type retType, ImportContext context)
		{
			if (IsGenericMethod(mb) && !IsGenericMethodDefinition(mb))
			{
				return ImportGenericInstanceMethod((MethodInfo)mb, context);
			}
			Type declaringType = mb.DeclaringType;
			Type type = declaringType;
			while (IsGenericTypeSpec(type))
			{
				type = GetGenericTypeDefinition(type);
			}
			if (mb.DeclaringType != type && mb is MethodInfo)
			{
				int metadataToken = GetMetadataToken(mb as MethodInfo);
				MethodInfo[] methods = type.GetMethods();
				foreach (MethodInfo methodInfo in methods)
				{
					if (GetMetadataToken(methodInfo) == metadataToken)
					{
						mb = methodInfo;
						retType = methodInfo.ReturnType;
						break;
					}
				}
			}
			string methodBaseSignature = GetMethodBaseSignature(mb, declaringType, retType);
			MethodReference methodReference = (MethodReference)GetMemberReference(methodBaseSignature);
			if (methodReference != null)
			{
				return methodReference;
			}
			methodReference = new MethodReference(mb.Name, (mb.CallingConvention & CallingConventions.HasThis) > (CallingConventions)0, (mb.CallingConvention & CallingConventions.ExplicitThis) > (CallingConventions)0, MethodCallingConvention.Default);
			methodReference.DeclaringType = ImportSystemType(declaringType, context);
			if (IsGenericMethod(mb))
			{
				Type[] genericArguments = GetGenericArguments(mb as MethodInfo);
				foreach (Type type2 in genericArguments)
				{
					methodReference.GenericParameters.Add(new GenericParameter(type2.Name, methodReference));
				}
			}
			TypeReference type3 = context.GenericContext.Type;
			MethodReference method = context.GenericContext.Method;
			context.GenericContext.Method = methodReference;
			context.GenericContext.Type = ImportSystemType(type, context);
			methodReference.ReturnType.ReturnType = ImportSystemType(retType, context);
			ParameterInfo[] parameters = mb.GetParameters();
			for (int k = 0; k < parameters.Length; k++)
			{
				methodReference.Parameters.Add(new ParameterDefinition(ImportSystemType(parameters[k].ParameterType, context)));
			}
			context.GenericContext.Type = type3;
			context.GenericContext.Method = method;
			m_module.MemberReferences.Add(methodReference);
			return methodReference;
		}

		public MethodReference ImportConstructorInfo(ConstructorInfo ci, ImportContext context)
		{
			return ImportMethodBase(ci, typeof(void), context);
		}

		public MethodReference ImportMethodInfo(MethodInfo mi, ImportContext context)
		{
			return ImportMethodBase(mi, mi.ReturnType, context);
		}

		private static string GetFieldSignature(FieldInfo field)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetTypeSignature(field.FieldType));
			stringBuilder.Append(' ');
			stringBuilder.Append(GetTypeSignature(field.DeclaringType));
			stringBuilder.Append("::");
			stringBuilder.Append(field.Name);
			return stringBuilder.ToString();
		}

		public FieldReference ImportFieldInfo(FieldInfo fi, ImportContext context)
		{
			string fieldSignature = GetFieldSignature(fi);
			FieldReference fieldReference = (FieldReference)GetMemberReference(fieldSignature);
			if (fieldReference != null)
			{
				return fieldReference;
			}
			fieldReference = new FieldReference(fi.Name, ImportSystemType(fi.DeclaringType, context), ImportSystemType(fi.FieldType, context));
			m_module.MemberReferences.Add(fieldReference);
			return fieldReference;
		}

		private MemberReference GetMemberReference(string signature)
		{
			foreach (MemberReference memberReference in m_module.MemberReferences)
			{
				if (memberReference.ToString() == signature)
				{
					return memberReference;
				}
			}
			return null;
		}
	}
}

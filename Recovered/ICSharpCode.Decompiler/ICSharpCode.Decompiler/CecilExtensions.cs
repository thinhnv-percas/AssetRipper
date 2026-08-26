using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler
{
	public static class CecilExtensions
	{
		public static int GetPushDelta(this Instruction instruction)
		{
			OpCode opCode = instruction.OpCode;
			switch (opCode.StackBehaviourPush)
			{
			case StackBehaviour.Push0:
				return 0;
			case StackBehaviour.Push1:
			case StackBehaviour.Pushi:
			case StackBehaviour.Pushi8:
			case StackBehaviour.Pushr4:
			case StackBehaviour.Pushr8:
			case StackBehaviour.Pushref:
				return 1;
			case StackBehaviour.Push1_push1:
				return 2;
			case StackBehaviour.Varpush:
				if (opCode.FlowControl == FlowControl.Call)
				{
					if (!((IMethodSignature)instruction.Operand).ReturnType.IsVoid())
					{
						return 1;
					}
					return 0;
				}
				break;
			}
			throw new NotSupportedException();
		}

		public static int? GetPopDelta(this Instruction instruction, MethodDefinition methodDef)
		{
			OpCode opCode = instruction.OpCode;
			switch (opCode.StackBehaviourPop)
			{
			case StackBehaviour.Pop0:
				return 0;
			case StackBehaviour.Pop1:
			case StackBehaviour.Popi:
			case StackBehaviour.Popref:
				return 1;
			case StackBehaviour.Pop1_pop1:
			case StackBehaviour.Popi_pop1:
			case StackBehaviour.Popi_popi:
			case StackBehaviour.Popi_popi8:
			case StackBehaviour.Popi_popr4:
			case StackBehaviour.Popi_popr8:
			case StackBehaviour.Popref_pop1:
			case StackBehaviour.Popref_popi:
				return 2;
			case StackBehaviour.Popi_popi_popi:
			case StackBehaviour.Popref_popi_popi:
			case StackBehaviour.Popref_popi_popi8:
			case StackBehaviour.Popref_popi_popr4:
			case StackBehaviour.Popref_popi_popr8:
			case StackBehaviour.Popref_popi_popref:
				return 3;
			case StackBehaviour.PopAll:
				return null;
			case StackBehaviour.Varpop:
				if (opCode == OpCodes.Ret)
				{
					return (!methodDef.ReturnType.IsVoid()) ? 1 : 0;
				}
				if (opCode.FlowControl == FlowControl.Call)
				{
					IMethodSignature methodSignature = (IMethodSignature)instruction.Operand;
					int num = methodSignature.HasParameters ? methodSignature.Parameters.Count : 0;
					if (methodSignature.HasThis && opCode != OpCodes.Newobj)
					{
						num++;
					}
					if (opCode == OpCodes.Calli)
					{
						num++;
					}
					return num;
				}
				break;
			}
			throw new NotSupportedException();
		}

		public static bool IsVoid(this TypeReference type)
		{
			while (type is OptionalModifierType || type is RequiredModifierType)
			{
				type = ((TypeSpecification)type).ElementType;
			}
			return type.MetadataType == MetadataType.Void;
		}

		public static bool IsValueTypeOrVoid(this TypeReference type)
		{
			while (type is OptionalModifierType || type is RequiredModifierType)
			{
				type = ((TypeSpecification)type).ElementType;
			}
			if (type is ArrayType)
			{
				return false;
			}
			if (!type.IsValueType)
			{
				return type.IsVoid();
			}
			return true;
		}

		public static bool IsSignedIntegralType(this TypeReference type)
		{
			if (type.MetadataType != MetadataType.SByte && type.MetadataType != MetadataType.Int16 && type.MetadataType != MetadataType.Int32 && type.MetadataType != MetadataType.Int64)
			{
				return type.MetadataType == MetadataType.IntPtr;
			}
			return true;
		}

		public static bool IsZero(this object value)
		{
			if (!value.Equals((sbyte)0) && !value.Equals((short)0) && !value.Equals(0) && !value.Equals(0L) && !value.Equals(IntPtr.Zero) && !value.Equals((byte)0) && !value.Equals((ushort)0) && !value.Equals(0u) && !value.Equals(0uL) && !value.Equals(0f) && !value.Equals(0.0))
			{
				return value.Equals(decimal.Zero);
			}
			return true;
		}

		public static int GetEndOffset(this Instruction inst)
		{
			if (inst == null)
			{
				throw new ArgumentNullException("inst");
			}
			return inst.Offset + inst.GetSize();
		}

		public static string OffsetToString(int offset)
		{
			return $"IL_{offset:x4}";
		}

		public static HashSet<MethodDefinition> GetAccessorMethods(this TypeDefinition type)
		{
			HashSet<MethodDefinition> hashSet = new HashSet<MethodDefinition>();
			foreach (PropertyDefinition property in type.Properties)
			{
				hashSet.Add(property.GetMethod);
				hashSet.Add(property.SetMethod);
				if (property.HasOtherMethods)
				{
					foreach (MethodDefinition otherMethod in property.OtherMethods)
					{
						hashSet.Add(otherMethod);
					}
				}
			}
			foreach (EventDefinition @event in type.Events)
			{
				hashSet.Add(@event.AddMethod);
				hashSet.Add(@event.RemoveMethod);
				hashSet.Add(@event.InvokeMethod);
				if (@event.HasOtherMethods)
				{
					foreach (MethodDefinition otherMethod2 in @event.OtherMethods)
					{
						hashSet.Add(otherMethod2);
					}
				}
			}
			return hashSet;
		}

		public static TypeDefinition ResolveWithinSameModule(this TypeReference type)
		{
			if (type != null && type.GetElementType().Module == type.Module)
			{
				return type.Resolve();
			}
			return null;
		}

		public static FieldDefinition ResolveWithinSameModule(this FieldReference field)
		{
			if (field != null && field.DeclaringType.GetElementType().Module == field.Module)
			{
				return field.Resolve();
			}
			return null;
		}

		public static MethodDefinition ResolveWithinSameModule(this MethodReference method)
		{
			if (method != null && method.DeclaringType.GetElementType().Module == method.Module)
			{
				return method.Resolve();
			}
			return null;
		}

		[Obsolete("throwing exceptions is considered a bug")]
		public static TypeDefinition ResolveOrThrow(this TypeReference typeReference)
		{
			TypeDefinition typeDefinition = typeReference.Resolve();
			if (typeDefinition == null)
			{
				throw new ReferenceResolvingException();
			}
			return typeDefinition;
		}

		public static bool IsCompilerGenerated(this ICustomAttributeProvider provider)
		{
			if (provider != null && provider.HasCustomAttributes)
			{
				foreach (CustomAttribute customAttribute in provider.CustomAttributes)
				{
					if (customAttribute.AttributeType.FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute")
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsCompilerGeneratedOrIsInCompilerGeneratedClass(this IMemberDefinition member)
		{
			if (member == null)
			{
				return false;
			}
			if (member.IsCompilerGenerated())
			{
				return true;
			}
			return member.DeclaringType.IsCompilerGeneratedOrIsInCompilerGeneratedClass();
		}

		public static TypeReference GetEnumUnderlyingType(this TypeDefinition type)
		{
			if (!type.IsEnum)
			{
				throw new ArgumentException("Type must be an enum", "type");
			}
			Collection<FieldDefinition> fields = type.Fields;
			for (int i = 0; i < fields.Count; i++)
			{
				FieldDefinition fieldDefinition = fields[i];
				if (!fieldDefinition.IsStatic)
				{
					return fieldDefinition.FieldType;
				}
			}
			throw new NotSupportedException();
		}

		public static bool IsAnonymousType(this TypeReference type)
		{
			if (type == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(type.Namespace) && type.HasGeneratedName() && (type.Name.Contains("AnonType") || type.Name.Contains("AnonymousType")))
			{
				return type.Resolve()?.IsCompilerGenerated() ?? false;
			}
			return false;
		}

		public static bool HasGeneratedName(this MemberReference member)
		{
			return member.Name.StartsWith("<", StringComparison.Ordinal);
		}

		public static bool ContainsAnonymousType(this TypeReference type)
		{
			GenericInstanceType genericInstanceType = type as GenericInstanceType;
			if (genericInstanceType != null)
			{
				if (genericInstanceType.IsAnonymousType())
				{
					return true;
				}
				for (int i = 0; i < genericInstanceType.GenericArguments.Count; i++)
				{
					if (genericInstanceType.GenericArguments[i].ContainsAnonymousType())
					{
						return true;
					}
				}
				return false;
			}
			return (type as TypeSpecification)?.ElementType.ContainsAnonymousType() ?? false;
		}

		public static string GetDefaultMemberName(this TypeDefinition type)
		{
			CustomAttribute defaultMemberAttribute;
			return type.GetDefaultMemberName(out defaultMemberAttribute);
		}

		public static string GetDefaultMemberName(this TypeDefinition type, out CustomAttribute defaultMemberAttribute)
		{
			if (type.HasCustomAttributes)
			{
				foreach (CustomAttribute customAttribute in type.CustomAttributes)
				{
					if (customAttribute.Constructor.DeclaringType.Name == "DefaultMemberAttribute" && customAttribute.Constructor.DeclaringType.Namespace == "System.Reflection" && customAttribute.Constructor.FullName == "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)")
					{
						defaultMemberAttribute = customAttribute;
						return customAttribute.ConstructorArguments[0].Value as string;
					}
				}
			}
			defaultMemberAttribute = null;
			return null;
		}

		public static bool IsIndexer(this PropertyDefinition property)
		{
			CustomAttribute defaultMemberAttribute;
			return property.IsIndexer(out defaultMemberAttribute);
		}

		public static bool IsIndexer(this PropertyDefinition property, out CustomAttribute defaultMemberAttribute)
		{
			defaultMemberAttribute = null;
			if (property.HasParameters)
			{
				MethodDefinition methodDefinition = property.GetMethod ?? property.SetMethod;
				PropertyDefinition propertyDefinition = property;
				if (methodDefinition.HasOverrides)
				{
					MethodDefinition methodDefinition2 = methodDefinition.Overrides.First().Resolve();
					if (methodDefinition2 == null)
					{
						return false;
					}
					foreach (PropertyDefinition property2 in methodDefinition2.DeclaringType.Properties)
					{
						if (property2.GetMethod == methodDefinition2 || property2.SetMethod == methodDefinition2)
						{
							propertyDefinition = property2;
							break;
						}
					}
				}
				if (propertyDefinition.DeclaringType.GetDefaultMemberName(out CustomAttribute defaultMemberAttribute2) == propertyDefinition.Name)
				{
					defaultMemberAttribute = defaultMemberAttribute2;
					return true;
				}
			}
			return false;
		}

		public static bool IsDelegate(this TypeDefinition type)
		{
			if (type.BaseType != null && type.BaseType.Namespace == "System")
			{
				if (type.BaseType.Name == "MulticastDelegate")
				{
					return true;
				}
				if (type.BaseType.Name == "Delegate" && type.Name != "MulticastDelegate")
				{
					return true;
				}
			}
			return false;
		}
	}
}

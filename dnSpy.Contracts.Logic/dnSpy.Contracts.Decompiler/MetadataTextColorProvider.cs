using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

public abstract class MetadataTextColorProvider
{
	private static readonly UTF8String systemString = new UTF8String("System");

	private static readonly UTF8String objectString = new UTF8String("Object");

	private static readonly UTF8String systemRuntimeCompilerServicesString = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String extensionAttributeString = new UTF8String("ExtensionAttribute");

	public virtual object GetColor(TypeDef type)
	{
		if (type == null)
		{
			return BoxedTextColor.Text;
		}
		if (type.IsInterface)
		{
			return BoxedTextColor.Interface;
		}
		if (type.IsEnum)
		{
			return BoxedTextColor.Enum;
		}
		if (type.IsValueType)
		{
			return BoxedTextColor.ValueType;
		}
		if (type.IsDelegate)
		{
			return BoxedTextColor.Delegate;
		}
		if (type.IsSealed && type.IsAbstract)
		{
			ITypeDefOrRef baseType = type.BaseType;
			if (baseType != null && baseType.DefinitionAssembly.IsCorLib())
			{
				if (baseType is TypeRef typeRef)
				{
					if (typeRef.Namespace == systemString && typeRef.Name == objectString)
					{
						return BoxedTextColor.StaticType;
					}
				}
				else
				{
					TypeDef typeDef = baseType as TypeDef;
					if (typeDef.Namespace == systemString && typeDef.Name == objectString)
					{
						return BoxedTextColor.StaticType;
					}
				}
			}
		}
		if (type.IsSealed)
		{
			return BoxedTextColor.SealedType;
		}
		return BoxedTextColor.Type;
	}

	public virtual object GetColor(TypeRef type)
	{
		if (type == null)
		{
			return BoxedTextColor.Text;
		}
		TypeDef typeDef = type.Resolve();
		if (typeDef != null)
		{
			return GetColor(typeDef);
		}
		return BoxedTextColor.Type;
	}

	public virtual object GetColor(IMemberRef memberRef)
	{
		if (memberRef == null)
		{
			return BoxedTextColor.Text;
		}
		if (memberRef.IsField)
		{
			FieldDef fieldDef = ((IField)memberRef).ResolveFieldDef();
			if (fieldDef == null)
			{
				return BoxedTextColor.InstanceField;
			}
			if (fieldDef.DeclaringType.IsEnum)
			{
				return BoxedTextColor.EnumField;
			}
			if (fieldDef.IsLiteral)
			{
				return BoxedTextColor.LiteralField;
			}
			if (fieldDef.IsStatic)
			{
				return BoxedTextColor.StaticField;
			}
			return BoxedTextColor.InstanceField;
		}
		if (memberRef.IsMethod)
		{
			IMethod method = (IMethod)memberRef;
			if (method.MethodSig == null)
			{
				return BoxedTextColor.InstanceMethod;
			}
			MethodDef methodDef = method.ResolveMethodDef();
			if (methodDef != null && methodDef.IsConstructor)
			{
				return GetColor(methodDef.DeclaringType);
			}
			if (!method.MethodSig.HasThis)
			{
				if (methodDef != null && methodDef.IsDefined(systemRuntimeCompilerServicesString, extensionAttributeString))
				{
					return BoxedTextColor.ExtensionMethod;
				}
				return BoxedTextColor.StaticMethod;
			}
			return BoxedTextColor.InstanceMethod;
		}
		if (memberRef.IsPropertyDef)
		{
			PropertyDef propertyDef = (PropertyDef)memberRef;
			return GetColor(propertyDef.GetMethod ?? propertyDef.SetMethod, BoxedTextColor.StaticProperty, BoxedTextColor.InstanceProperty);
		}
		if (memberRef.IsEventDef)
		{
			EventDef eventDef = (EventDef)memberRef;
			return GetColor(eventDef.AddMethod ?? eventDef.RemoveMethod ?? eventDef.InvokeMethod, BoxedTextColor.StaticEvent, BoxedTextColor.InstanceEvent);
		}
		if (memberRef is TypeDef type)
		{
			return GetColor(type);
		}
		if (memberRef is TypeRef type2)
		{
			return GetColor(type2);
		}
		if (memberRef is TypeSpec typeSpec)
		{
			if (typeSpec.TypeSig is GenericSig genericSig)
			{
				return GetColor(genericSig);
			}
			return BoxedTextColor.Type;
		}
		if (memberRef is GenericParam genericParam)
		{
			return GetColor(genericParam);
		}
		if (memberRef.IsMemberRef)
		{
			return BoxedTextColor.Text;
		}
		return BoxedTextColor.Text;
	}

	public virtual object GetColor(GenericSig genericSig)
	{
		if (genericSig == null)
		{
			return BoxedTextColor.Text;
		}
		return genericSig.IsMethodVar ? BoxedTextColor.MethodGenericParameter : BoxedTextColor.TypeGenericParameter;
	}

	public virtual object GetColor(GenericParam genericParam)
	{
		if (genericParam == null)
		{
			return BoxedTextColor.Text;
		}
		if (genericParam.DeclaringType != null)
		{
			return BoxedTextColor.TypeGenericParameter;
		}
		if (genericParam.DeclaringMethod != null)
		{
			return BoxedTextColor.MethodGenericParameter;
		}
		return BoxedTextColor.TypeGenericParameter;
	}

	private static object GetColor(MethodDef method, object staticValue, object instanceValue)
	{
		if (method == null)
		{
			return instanceValue;
		}
		if (method.IsStatic)
		{
			return staticValue;
		}
		return instanceValue;
	}

	public virtual object GetColor(ExportedType exportedType)
	{
		if (exportedType == null)
		{
			return BoxedTextColor.Text;
		}
		return GetColor(exportedType.ToTypeRef());
	}

	public virtual object GetColor(TypeSig typeSig)
	{
		typeSig = typeSig.RemovePinnedAndModifiers();
		if (typeSig == null)
		{
			return BoxedTextColor.Text;
		}
		if (typeSig is TypeDefOrRefSig typeDefOrRefSig)
		{
			return GetColor(typeDefOrRefSig.TypeDefOrRef);
		}
		if (typeSig is GenericSig genericSig)
		{
			return GetColor(genericSig);
		}
		return BoxedTextColor.Text;
	}

	public virtual object GetColor(object obj)
	{
		if (obj == null)
		{
			return BoxedTextColor.Text;
		}
		if (obj is byte || obj is sbyte || obj is ushort || obj is short || obj is uint || obj is int || obj is ulong || obj is long || obj is UIntPtr || obj is IntPtr)
		{
			return BoxedTextColor.Number;
		}
		if (obj is IMemberRef memberRef)
		{
			return GetColor(memberRef);
		}
		if (obj is ExportedType exportedType)
		{
			return GetColor(exportedType);
		}
		if (obj is TypeSig typeSig)
		{
			return GetColor(typeSig);
		}
		if (obj is GenericParam genericParam)
		{
			return GetColor(genericParam);
		}
		if (obj is TextColor)
		{
			return obj;
		}
		if (obj is Parameter)
		{
			return BoxedTextColor.Parameter;
		}
		if (obj is Local)
		{
			return BoxedTextColor.Local;
		}
		if (obj is MethodSig)
		{
			return BoxedTextColor.Text;
		}
		if (obj is string)
		{
			return BoxedTextColor.String;
		}
		return BoxedTextColor.Text;
	}
}

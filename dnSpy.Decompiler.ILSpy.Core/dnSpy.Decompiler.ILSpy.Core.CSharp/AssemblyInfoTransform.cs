using System.Linq;
using dnlib.DotNet;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class AssemblyInfoTransform : IAstTransform
{
	private static readonly UTF8String systemRuntimeVersioningString = new UTF8String("System.Runtime.Versioning");

	private static readonly UTF8String targetFrameworkAttributeString = new UTF8String("TargetFrameworkAttribute");

	private static readonly UTF8String systemSecurityString = new UTF8String("System.Security");

	private static readonly UTF8String unverifiableCodeAttributeString = new UTF8String("UnverifiableCodeAttribute");

	public void Run(AstNode compilationUnit)
	{
		foreach (AttributeSection item in compilationUnit.Descendants.OfType<AttributeSection>())
		{
			Attribute attribute = item.Descendants.OfType<Attribute>().FirstOrDefault();
			if (attribute != null)
			{
				CustomAttribute customAttribute = attribute.Annotation<CustomAttribute>();
				if (customAttribute != null && (Compare(customAttribute.AttributeType, systemRuntimeVersioningString, targetFrameworkAttributeString) || Compare(customAttribute.AttributeType, systemSecurityString, unverifiableCodeAttributeString)))
				{
					item.Remove();
				}
			}
		}
	}

	private static bool Compare(ITypeDefOrRef type, UTF8String expNs, UTF8String expName)
	{
		if (type == null)
		{
			return false;
		}
		if (type is TypeRef typeRef)
		{
			if (typeRef.Namespace == expNs)
			{
				return typeRef.Name == expName;
			}
			return false;
		}
		if (type is TypeDef typeDef)
		{
			if (typeDef.Namespace == expNs)
			{
				return typeDef.Name == expName;
			}
			return false;
		}
		return false;
	}
}

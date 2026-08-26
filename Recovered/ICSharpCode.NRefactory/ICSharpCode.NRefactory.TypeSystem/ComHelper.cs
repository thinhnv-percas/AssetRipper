using ICSharpCode.NRefactory.Semantics;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public static class ComHelper
	{
		private static bool IsComAttribute(IAttribute attribute, string name)
		{
			if (attribute.AttributeType.Name == name)
			{
				return attribute.AttributeType.Namespace == "System.Runtime.InteropServices";
			}
			return false;
		}

		public static bool IsComImport(ITypeDefinition typeDefinition)
		{
			if (typeDefinition != null && typeDefinition.Kind == TypeKind.Interface)
			{
				return typeDefinition.Attributes.Any((IAttribute a) => IsComAttribute(a, "ComImportAttribute"));
			}
			return false;
		}

		public static IType GetCoClass(ITypeDefinition typeDefinition)
		{
			if (typeDefinition == null)
			{
				return SpecialType.UnknownType;
			}
			IAttribute attribute = typeDefinition.Attributes.FirstOrDefault((IAttribute a) => IsComAttribute(a, "CoClassAttribute"));
			if (attribute != null && attribute.PositionalArguments.Count == 1)
			{
				TypeOfResolveResult typeOfResolveResult = attribute.PositionalArguments[0] as TypeOfResolveResult;
				if (typeOfResolveResult != null)
				{
					return typeOfResolveResult.ReferencedType;
				}
			}
			return SpecialType.UnknownType;
		}
	}
}

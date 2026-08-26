using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

internal sealed class BaseTypeCollector : List<IType>
{
	private readonly Stack<IType> activeTypes = new Stack<IType>();

	internal bool SkipImplementedInterfaces;

	public void CollectBaseTypes(IType type)
	{
		IType definition = type.GetDefinition();
		IType type2 = definition ?? type;
		if (activeTypes.Contains(type2))
		{
			return;
		}
		activeTypes.Push(type2);
		if (!Contains(type))
		{
			foreach (IType directBaseType in type.DirectBaseTypes)
			{
				if (!SkipImplementedInterfaces || type2 == null || type2.Kind == TypeKind.Interface || type2.Kind == TypeKind.TypeParameter || directBaseType.Kind != TypeKind.Interface)
				{
					CollectBaseTypes(directBaseType);
				}
			}
			Add(type);
		}
		activeTypes.Pop();
	}
}

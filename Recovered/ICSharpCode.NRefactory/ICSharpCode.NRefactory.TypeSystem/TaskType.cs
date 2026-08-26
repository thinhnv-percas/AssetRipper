using System;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public static class TaskType
	{
		public static IType UnpackTask(ICompilation compilation, IType type)
		{
			if (!IsTask(type))
			{
				return type;
			}
			if (type.TypeParameterCount == 0)
			{
				return compilation.FindType(KnownTypeCode.Void);
			}
			return type.TypeArguments[0];
		}

		public static bool IsTask(IType type)
		{
			ITypeDefinition definition = type.GetDefinition();
			if (definition != null)
			{
				if (definition.KnownTypeCode == KnownTypeCode.Task)
				{
					return true;
				}
				if (definition.KnownTypeCode == KnownTypeCode.TaskOfT)
				{
					return type is ParameterizedType;
				}
			}
			return false;
		}

		public static IType Create(ICompilation compilation, IType elementType)
		{
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (elementType.Kind == TypeKind.Void)
			{
				return compilation.FindType(KnownTypeCode.Task);
			}
			IType type = compilation.FindType(KnownTypeCode.TaskOfT);
			ITypeDefinition definition = type.GetDefinition();
			if (definition != null)
			{
				return new ParameterizedType(definition, new IType[1]
				{
					elementType
				});
			}
			return type;
		}
	}
}

using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.ComponentModel;
using System.Linq;

namespace ICSharpCode.NRefactory.Completion
{
	public static class CompletionExtensionMethods
	{
		public static EditorBrowsableState GetEditorBrowsableState(this IEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			IAttribute attribute = entity.Attributes.FirstOrDefault((IAttribute attr) => attr.AttributeType.Name == "EditorBrowsableAttribute" && attr.AttributeType.Namespace == "System.ComponentModel");
			if (attribute != null && attribute.PositionalArguments.Count == 1 && attribute.PositionalArguments[0].ConstantValue is int)
			{
				return (EditorBrowsableState)(int)attribute.PositionalArguments[0].ConstantValue;
			}
			return EditorBrowsableState.Always;
		}

		public static bool IsBrowsable(this IEntity entity)
		{
			return entity.GetEditorBrowsableState() != EditorBrowsableState.Never;
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class DecompileTypeMethodsTransform : IAstTransform
{
	private readonly HashSet<IMemberDef> defsToShow;

	private readonly HashSet<TypeDef> partialTypes;

	private readonly bool showDefinitions;

	private readonly bool showAll;

	public DecompileTypeMethodsTransform(HashSet<TypeDef> types, HashSet<MethodDef> methods, bool showDefinitions, bool showAll)
	{
		defsToShow = new HashSet<IMemberDef>();
		partialTypes = new HashSet<TypeDef>();
		this.showDefinitions = showDefinitions;
		this.showAll = showAll;
		foreach (MethodDef method in methods)
		{
			PropertyDef propertyDef = method.DeclaringType.Properties.FirstOrDefault((PropertyDef a) => a.GetMethods.Contains(method) || a.SetMethods.Contains(method));
			if (propertyDef != null)
			{
				defsToShow.Add(propertyDef);
				foreach (MethodDef getMethod in propertyDef.GetMethods)
				{
					defsToShow.Add(getMethod);
				}
				foreach (MethodDef setMethod in propertyDef.SetMethods)
				{
					defsToShow.Add(setMethod);
				}
				foreach (MethodDef otherMethod in propertyDef.OtherMethods)
				{
					defsToShow.Add(otherMethod);
				}
				continue;
			}
			EventDef eventDef = method.DeclaringType.Events.FirstOrDefault((EventDef a) => a.AddMethod == method || a.RemoveMethod == method);
			if (eventDef != null)
			{
				defsToShow.Add(eventDef);
				if (eventDef.AddMethod != null)
				{
					defsToShow.Add(eventDef.AddMethod);
				}
				if (eventDef.RemoveMethod != null)
				{
					defsToShow.Add(eventDef.RemoveMethod);
				}
				if (eventDef.InvokeMethod != null)
				{
					defsToShow.Add(eventDef.InvokeMethod);
				}
				foreach (MethodDef otherMethod2 in eventDef.OtherMethods)
				{
					defsToShow.Add(otherMethod2);
				}
			}
			else
			{
				defsToShow.Add(method);
			}
		}
		foreach (TypeDef type in types)
		{
			if (!type.IsEnum)
			{
				defsToShow.Add(type);
				partialTypes.Add(type);
			}
		}
		foreach (IMemberDef item in defsToShow)
		{
			for (TypeDef declaringType = item.DeclaringType; declaringType != null; declaringType = declaringType.DeclaringType)
			{
				partialTypes.Add(declaringType);
			}
		}
		foreach (TypeDef type2 in types)
		{
			if (!type2.IsEnum)
			{
				continue;
			}
			defsToShow.Add(type2);
			foreach (FieldDef field in type2.Fields)
			{
				defsToShow.Add(field);
			}
		}
	}

	public void Run(AstNode compilationUnit)
	{
		foreach (EntityDeclaration item in compilationUnit.Descendants.OfType<EntityDeclaration>())
		{
			IMemberDef memberDef = item.Annotation<IMemberDef>();
			if (memberDef == null)
			{
				continue;
			}
			if (partialTypes.Contains(memberDef))
			{
				if (item is TypeDeclaration typeDeclaration)
				{
					if (typeDeclaration.ClassType != ClassType.Enum)
					{
						typeDeclaration.Modifiers |= Modifiers.Partial;
					}
					if (!showDefinitions)
					{
						typeDeclaration.BaseTypes.Clear();
						typeDeclaration.Attributes.Clear();
					}
					Comment[] array = item.GetChildrenByRole(Roles.Comment).Reverse().ToArray();
					Comment[] array2 = array;
					foreach (Comment comment in array2)
					{
						comment.Remove();
						item.InsertChildAfter(null, comment, Roles.Comment);
					}
				}
			}
			else if (showDefinitions)
			{
				if (!showAll && !defsToShow.Contains(memberDef))
				{
					item.Remove();
				}
			}
			else if (showAll || defsToShow.Contains(memberDef))
			{
				item.Remove();
			}
			else if (item is CustomEventDeclaration customEventDeclaration)
			{
				if (!customEventDeclaration.AddAccessor.IsNull)
				{
					customEventDeclaration.AddAccessor.Body = new BlockStatement();
				}
				if (!customEventDeclaration.RemoveAccessor.IsNull)
				{
					customEventDeclaration.RemoveAccessor.Body = new BlockStatement();
				}
			}
		}
	}
}

using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.Analysis
{
	public class AbiComparer
	{
		public bool StopOnIncompatibility
		{
			get;
			set;
		}

		public event EventHandler<AbiEventArgs> IncompatibilityFound;

		private void CheckContstraints(IType otype, ITypeParameter p1, ITypeParameter p2, ref AbiCompatibility compatibility)
		{
			if (p1.DirectBaseTypes.Count() != p2.DirectBaseTypes.Count() || p1.HasReferenceTypeConstraint != p2.HasReferenceTypeConstraint || p1.HasValueTypeConstraint != p2.HasValueTypeConstraint || p1.HasDefaultConstructorConstraint != p2.HasDefaultConstructorConstraint)
			{
				OnIncompatibilityFound(new AbiEventArgs(string.Format(TranslateString("Type parameter constraints of type {0} have changed."), otype.FullName)));
				compatibility = AbiCompatibility.Incompatible;
			}
		}

		private void CheckContstraints(IMethod omethod, ITypeParameter p1, ITypeParameter p2, ref AbiCompatibility compatibility)
		{
			if (p1.DirectBaseTypes.Count() != p2.DirectBaseTypes.Count() || p1.HasReferenceTypeConstraint != p2.HasReferenceTypeConstraint || p1.HasValueTypeConstraint != p2.HasValueTypeConstraint || p1.HasDefaultConstructorConstraint != p2.HasDefaultConstructorConstraint)
			{
				OnIncompatibilityFound(new AbiEventArgs(string.Format(TranslateString("Type parameter constraints of method {0} have changed."), omethod.FullName)));
				compatibility = AbiCompatibility.Incompatible;
			}
		}

		private void CheckTypes(ITypeDefinition oType, ITypeDefinition nType, ref AbiCompatibility compatibility)
		{
			int num = 0;
			Predicate<IUnresolvedMember> filter = null;
			if (oType.Kind == TypeKind.Class || oType.Kind == TypeKind.Struct)
			{
				filter = ((IUnresolvedMember m) => (m.IsPublic || m.IsProtected) && !m.IsOverride && !m.IsSynthetic);
			}
			for (int i = 0; i < oType.TypeParameterCount; i++)
			{
				CheckContstraints(oType, oType.TypeParameters[i], nType.TypeParameters[i], ref compatibility);
				if (compatibility == AbiCompatibility.Incompatible && StopOnIncompatibility)
				{
					return;
				}
			}
			foreach (IMember member in oType.GetMembers(filter, GetMemberOptions.IgnoreInheritedMembers))
			{
				IMember member2 = nType.GetMembers((IUnresolvedMember m) => member.UnresolvedMember.Name == m.Name && m.IsPublic == member.IsPublic && m.IsProtected == member.IsProtected).FirstOrDefault((IMember m) => SignatureComparer.Ordinal.Equals(member, m));
				if (member2 == null)
				{
					compatibility = AbiCompatibility.Incompatible;
					if (StopOnIncompatibility)
					{
						return;
					}
				}
				else
				{
					IMethod method = member as IMethod;
					if (method != null)
					{
						for (int j = 0; j < method.TypeParameters.Count; j++)
						{
							CheckContstraints(method, method.TypeParameters[j], ((IMethod)member2).TypeParameters[j], ref compatibility);
							if (compatibility == AbiCompatibility.Incompatible && StopOnIncompatibility)
							{
								return;
							}
						}
					}
					num++;
				}
			}
			if ((compatibility != AbiCompatibility.Bigger || oType.Kind == TypeKind.Interface) && num != nType.GetMembers(filter, GetMemberOptions.IgnoreInheritedMembers).Count())
			{
				if (oType.Kind == TypeKind.Interface)
				{
					OnIncompatibilityFound(new AbiEventArgs(string.Format(TranslateString("Interafce {0} has changed."), oType.FullName)));
					compatibility = AbiCompatibility.Incompatible;
				}
				else if (compatibility == AbiCompatibility.Equal)
				{
					compatibility = AbiCompatibility.Bigger;
				}
			}
		}

		private void CheckNamespace(INamespace oNs, INamespace nNs, ref AbiCompatibility compatibility)
		{
			foreach (ITypeDefinition type in oNs.Types)
			{
				if (type.IsPublic || type.IsProtected)
				{
					ITypeDefinition typeDefinition = nNs.GetTypeDefinition(type.Name, type.TypeParameterCount);
					if (typeDefinition == null)
					{
						OnIncompatibilityFound(new AbiEventArgs(string.Format(TranslateString("Type definition {0} is missing."), type.FullName)));
						compatibility = AbiCompatibility.Incompatible;
						if (StopOnIncompatibility)
						{
							return;
						}
					}
					else
					{
						CheckTypes(type, typeDefinition, ref compatibility);
						if (compatibility == AbiCompatibility.Incompatible && StopOnIncompatibility)
						{
							return;
						}
					}
				}
			}
			if (compatibility != AbiCompatibility.Bigger)
			{
				foreach (ITypeDefinition type2 in nNs.Types)
				{
					if ((type2.IsPublic || type2.IsProtected) && oNs.GetTypeDefinition(type2.Name, type2.TypeParameterCount) == null)
					{
						if (compatibility == AbiCompatibility.Equal)
						{
							compatibility = AbiCompatibility.Bigger;
						}
						break;
					}
				}
			}
		}

		private static bool ContainsPublicTypes(INamespace testNs)
		{
			Stack<INamespace> stack = new Stack<INamespace>();
			stack.Push(testNs);
			while (stack.Count > 0)
			{
				INamespace @namespace = stack.Pop();
				if (@namespace.Types.Any((ITypeDefinition t) => t.IsPublic))
				{
					return true;
				}
				foreach (INamespace childNamespace in @namespace.ChildNamespaces)
				{
					stack.Push(childNamespace);
				}
			}
			return false;
		}

		public AbiCompatibility Check(ICompilation oldProject, ICompilation newProject)
		{
			Stack<INamespace> stack = new Stack<INamespace>();
			Stack<INamespace> stack2 = new Stack<INamespace>();
			stack.Push(oldProject.MainAssembly.RootNamespace);
			stack2.Push(newProject.MainAssembly.RootNamespace);
			AbiCompatibility compatibility = AbiCompatibility.Equal;
			while (stack.Count > 0)
			{
				INamespace @namespace = stack.Pop();
				INamespace namespace2 = stack2.Pop();
				CheckNamespace(@namespace, namespace2, ref compatibility);
				if (compatibility == AbiCompatibility.Incompatible && StopOnIncompatibility)
				{
					return AbiCompatibility.Incompatible;
				}
				foreach (INamespace childNamespace2 in @namespace.ChildNamespaces)
				{
					INamespace childNamespace = namespace2.GetChildNamespace(childNamespace2.Name);
					if (childNamespace == null)
					{
						OnIncompatibilityFound(new AbiEventArgs(string.Format(TranslateString("Namespace {0} is missing."), childNamespace2.FullName)));
						if (StopOnIncompatibility)
						{
							return AbiCompatibility.Incompatible;
						}
					}
					else
					{
						stack.Push(childNamespace2);
						stack2.Push(childNamespace);
					}
				}
				if (compatibility != AbiCompatibility.Bigger)
				{
					foreach (INamespace childNamespace3 in namespace2.ChildNamespaces)
					{
						if (@namespace.GetChildNamespace(childNamespace3.Name) == null)
						{
							if (compatibility == AbiCompatibility.Equal && ContainsPublicTypes(childNamespace3))
							{
								compatibility = AbiCompatibility.Bigger;
							}
							break;
						}
					}
				}
			}
			return compatibility;
		}

		public virtual string TranslateString(string str)
		{
			return str;
		}

		protected virtual void OnIncompatibilityFound(AbiEventArgs e)
		{
			this.IncompatibilityFound?.Invoke(this, e);
		}
	}
}

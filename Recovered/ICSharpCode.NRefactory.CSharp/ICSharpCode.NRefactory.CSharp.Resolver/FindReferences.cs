using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public sealed class FindReferences
	{
		private sealed class SearchScope : IFindReferenceSearchScope
		{
			private readonly Func<ICompilation, FindReferenceNavigator> factory;

			internal string searchTerm;

			internal FindReferences findReferences;

			internal ICompilation declarationCompilation;

			internal Accessibility accessibility;

			internal ITypeDefinition topLevelTypeDefinition;

			internal string fileName;

			ICompilation IFindReferenceSearchScope.Compilation => declarationCompilation;

			string IFindReferenceSearchScope.SearchTerm => searchTerm;

			Accessibility IFindReferenceSearchScope.Accessibility => accessibility;

			ITypeDefinition IFindReferenceSearchScope.TopLevelTypeDefinition => topLevelTypeDefinition;

			string IFindReferenceSearchScope.FileName => fileName;

			public SearchScope(Func<ICompilation, FindReferenceNavigator> factory)
			{
				this.factory = factory;
			}

			public SearchScope(string searchTerm, Func<ICompilation, FindReferenceNavigator> factory)
			{
				this.searchTerm = searchTerm;
				this.factory = factory;
			}

			IResolveVisitorNavigator IFindReferenceSearchScope.GetNavigator(ICompilation compilation, FoundReferenceCallback callback)
			{
				FindReferenceNavigator findReferenceNavigator = factory(compilation);
				if (findReferenceNavigator != null)
				{
					findReferenceNavigator.callback = callback;
					findReferenceNavigator.findReferences = findReferences;
					return findReferenceNavigator;
				}
				return new ConstantModeResolveVisitorNavigator(ResolveVisitorNavigationMode.Skip, null);
			}
		}

		private abstract class FindReferenceNavigator : IResolveVisitorNavigator
		{
			internal FoundReferenceCallback callback;

			internal FindReferences findReferences;

			internal abstract bool CanMatch(AstNode node);

			internal abstract bool IsMatch(ResolveResult rr);

			ResolveVisitorNavigationMode IResolveVisitorNavigator.Scan(AstNode node)
			{
				if (CanMatch(node))
				{
					return ResolveVisitorNavigationMode.Resolve;
				}
				return ResolveVisitorNavigationMode.Scan;
			}

			void IResolveVisitorNavigator.Resolved(AstNode node, ResolveResult result)
			{
				if (CanMatch(node) && IsMatch(result))
				{
					ReportMatch(node, result);
				}
			}

			public virtual void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
			{
			}

			protected void ReportMatch(AstNode node, ResolveResult result)
			{
				if (callback != null)
				{
					callback(node, result);
				}
			}

			internal virtual void NavigatorDone(CSharpAstResolver resolver, CancellationToken cancellationToken)
			{
			}
		}

		private sealed class FindTypeDefinitionReferencesNavigator : FindReferenceNavigator
		{
			private readonly ITypeDefinition typeDefinition;

			private readonly string searchTerm;

			public FindTypeDefinitionReferencesNavigator(ITypeDefinition typeDefinition, string searchTerm)
			{
				this.typeDefinition = typeDefinition;
				this.searchTerm = searchTerm;
			}

			internal override bool CanMatch(AstNode node)
			{
				IdentifierExpression identifierExpression = node as IdentifierExpression;
				if (identifierExpression != null)
				{
					if (searchTerm != null)
					{
						return identifierExpression.Identifier == searchTerm;
					}
					return true;
				}
				MemberReferenceExpression memberReferenceExpression = node as MemberReferenceExpression;
				if (memberReferenceExpression != null)
				{
					if (searchTerm != null)
					{
						return memberReferenceExpression.MemberName == searchTerm;
					}
					return true;
				}
				SimpleType simpleType = node as SimpleType;
				if (simpleType != null)
				{
					if (searchTerm != null)
					{
						return simpleType.Identifier == searchTerm;
					}
					return true;
				}
				MemberType memberType = node as MemberType;
				if (memberType != null)
				{
					if (searchTerm != null)
					{
						return memberType.MemberName == searchTerm;
					}
					return true;
				}
				if (searchTerm == null && node is PrimitiveType)
				{
					return true;
				}
				TypeDeclaration typeDeclaration = node as TypeDeclaration;
				if (typeDeclaration != null)
				{
					if (searchTerm != null)
					{
						return typeDeclaration.Name == searchTerm;
					}
					return true;
				}
				DelegateDeclaration delegateDeclaration = node as DelegateDeclaration;
				if (delegateDeclaration != null)
				{
					if (searchTerm != null)
					{
						return delegateDeclaration.Name == searchTerm;
					}
					return true;
				}
				return false;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				TypeResolveResult typeResolveResult = rr as TypeResolveResult;
				if (typeResolveResult != null)
				{
					return typeDefinition.Equals(typeResolveResult.Type.GetDefinition());
				}
				return false;
			}
		}

		private class FindMemberReferencesNavigator : FindReferenceNavigator
		{
			private readonly IMember member;

			private readonly string searchTerm;

			public FindMemberReferencesNavigator(IMember member)
			{
				this.member = member;
				searchTerm = member.Name;
			}

			internal override bool CanMatch(AstNode node)
			{
				IdentifierExpression identifierExpression = node as IdentifierExpression;
				if (identifierExpression != null)
				{
					return identifierExpression.Identifier == searchTerm;
				}
				MemberReferenceExpression memberReferenceExpression = node as MemberReferenceExpression;
				if (memberReferenceExpression != null)
				{
					return memberReferenceExpression.MemberName == searchTerm;
				}
				PointerReferenceExpression pointerReferenceExpression = node as PointerReferenceExpression;
				if (pointerReferenceExpression != null)
				{
					return pointerReferenceExpression.MemberName == searchTerm;
				}
				NamedExpression namedExpression = node as NamedExpression;
				if (namedExpression != null)
				{
					return namedExpression.Name == searchTerm;
				}
				return false;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(member, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}
		}

		private sealed class FindFieldReferences : FindMemberReferencesNavigator
		{
			public FindFieldReferences(IField field)
				: base(field)
			{
			}

			internal override bool CanMatch(AstNode node)
			{
				if (node is VariableInitializer)
				{
					return node.Parent is FieldDeclaration;
				}
				return base.CanMatch(node);
			}
		}

		private sealed class FindEnumMemberReferences : FindMemberReferencesNavigator
		{
			public FindEnumMemberReferences(IField field)
				: base(field)
			{
			}

			internal override bool CanMatch(AstNode node)
			{
				if (!(node is EnumMemberDeclaration))
				{
					return base.CanMatch(node);
				}
				return true;
			}
		}

		private sealed class FindPropertyReferences : FindMemberReferencesNavigator
		{
			public FindPropertyReferences(IProperty property)
				: base(property)
			{
			}

			internal override bool CanMatch(AstNode node)
			{
				if (!(node is PropertyDeclaration))
				{
					return base.CanMatch(node);
				}
				return true;
			}
		}

		private sealed class FindEventReferences : FindMemberReferencesNavigator
		{
			public FindEventReferences(IEvent ev)
				: base(ev)
			{
			}

			internal override bool CanMatch(AstNode node)
			{
				if (node is VariableInitializer)
				{
					return node.Parent is EventDeclaration;
				}
				if (!(node is CustomEventDeclaration))
				{
					return base.CanMatch(node);
				}
				return true;
			}
		}

		private sealed class FindEnumeratorCurrentReferencesNavigator : FindReferenceNavigator
		{
			private IProperty property;

			public FindEnumeratorCurrentReferencesNavigator(IProperty property)
			{
				this.property = property;
			}

			internal override bool CanMatch(AstNode node)
			{
				return node is ForeachStatement;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				ForEachResolveResult forEachResolveResult = rr as ForEachResolveResult;
				if (forEachResolveResult != null && forEachResolveResult.CurrentProperty != null)
				{
					return findReferences.IsMemberMatch(property, forEachResolveResult.CurrentProperty, isVirtualCall: true);
				}
				return false;
			}
		}

		private sealed class FindAwaiterIsCompletedReferencesNavigator : FindReferenceNavigator
		{
			private IProperty property;

			public FindAwaiterIsCompletedReferencesNavigator(IProperty property)
			{
				this.property = property;
			}

			internal override bool CanMatch(AstNode node)
			{
				return node is UnaryOperatorExpression;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				AwaitResolveResult awaitResolveResult = rr as AwaitResolveResult;
				if (awaitResolveResult != null && awaitResolveResult.IsCompletedProperty != null)
				{
					return findReferences.IsMemberMatch(property, awaitResolveResult.IsCompletedProperty, isVirtualCall: true);
				}
				return false;
			}
		}

		private sealed class FindMethodReferences : FindReferenceNavigator
		{
			private readonly IMethod method;

			private readonly Type specialNodeType;

			private HashSet<Expression> potentialMethodGroupConversions = new HashSet<Expression>();

			public FindMethodReferences(IMethod method, Type specialNodeType)
			{
				this.method = method;
				this.specialNodeType = specialNodeType;
			}

			internal override bool CanMatch(AstNode node)
			{
				if (specialNodeType != null && node.GetType() == specialNodeType)
				{
					return true;
				}
				Expression expression = node as Expression;
				if (expression == null)
				{
					return node is MethodDeclaration;
				}
				InvocationExpression invocationExpression = node as InvocationExpression;
				if (invocationExpression != null)
				{
					Expression expression2 = ParenthesizedExpression.UnpackParenthesizedExpression(invocationExpression.Target);
					IdentifierExpression identifierExpression = expression2 as IdentifierExpression;
					if (identifierExpression != null)
					{
						return identifierExpression.Identifier == method.Name;
					}
					MemberReferenceExpression memberReferenceExpression = expression2 as MemberReferenceExpression;
					if (memberReferenceExpression != null)
					{
						return memberReferenceExpression.MemberName == method.Name;
					}
					PointerReferenceExpression pointerReferenceExpression = expression2 as PointerReferenceExpression;
					if (pointerReferenceExpression != null)
					{
						return pointerReferenceExpression.MemberName == method.Name;
					}
				}
				else if (expression.Role != Roles.TargetExpression && expression.GetChildByRole(Roles.Identifier).Name == method.Name)
				{
					potentialMethodGroupConversions.Add(expression);
				}
				return node is MethodDeclaration;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				if (specialNodeType != null)
				{
					ForEachResolveResult forEachResolveResult = rr as ForEachResolveResult;
					if (forEachResolveResult != null)
					{
						if (!IsMatch(forEachResolveResult.GetEnumeratorCall))
						{
							if (forEachResolveResult.MoveNextMethod != null)
							{
								return findReferences.IsMemberMatch(method, forEachResolveResult.MoveNextMethod, isVirtualCall: true);
							}
							return false;
						}
						return true;
					}
					AwaitResolveResult awaitResolveResult = rr as AwaitResolveResult;
					if (awaitResolveResult != null)
					{
						if (!IsMatch(awaitResolveResult.GetAwaiterInvocation) && (awaitResolveResult.GetResultMethod == null || !findReferences.IsMemberMatch(method, awaitResolveResult.GetResultMethod, isVirtualCall: true)))
						{
							if (awaitResolveResult.OnCompletedMethod != null)
							{
								return findReferences.IsMemberMatch(method, awaitResolveResult.OnCompletedMethod, isVirtualCall: true);
							}
							return false;
						}
						return true;
					}
				}
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(method, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}

			internal override void NavigatorDone(CSharpAstResolver resolver, CancellationToken cancellationToken)
			{
				foreach (Expression potentialMethodGroupConversion in potentialMethodGroupConversions)
				{
					Conversion conversion = resolver.GetConversion(potentialMethodGroupConversion, cancellationToken);
					if (conversion.IsMethodGroupConversion && findReferences.IsMemberMatch(method, conversion.Method, conversion.IsVirtualMethodLookup))
					{
						IType expectedType = resolver.GetExpectedType(potentialMethodGroupConversion, cancellationToken);
						ResolveResult input = resolver.Resolve(potentialMethodGroupConversion, cancellationToken);
						ReportMatch(potentialMethodGroupConversion, new ConversionResolveResult(expectedType, input, conversion));
					}
				}
				base.NavigatorDone(resolver, cancellationToken);
			}
		}

		private sealed class FindIndexerReferencesNavigator : FindReferenceNavigator
		{
			private readonly IProperty indexer;

			public FindIndexerReferencesNavigator(IProperty indexer)
			{
				this.indexer = indexer;
			}

			internal override bool CanMatch(AstNode node)
			{
				if (!(node is IndexerExpression))
				{
					return node is IndexerDeclaration;
				}
				return true;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(indexer, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}
		}

		private sealed class FindUnaryOperatorNavigator : FindReferenceNavigator
		{
			private readonly IMethod op;

			private readonly UnaryOperatorType operatorType;

			public FindUnaryOperatorNavigator(IMethod op, UnaryOperatorType operatorType)
			{
				this.op = op;
				this.operatorType = operatorType;
			}

			internal override bool CanMatch(AstNode node)
			{
				UnaryOperatorExpression unaryOperatorExpression = node as UnaryOperatorExpression;
				if (unaryOperatorExpression != null)
				{
					if (operatorType == UnaryOperatorType.Increment)
					{
						if (unaryOperatorExpression.Operator != UnaryOperatorType.Increment)
						{
							return unaryOperatorExpression.Operator == UnaryOperatorType.PostIncrement;
						}
						return true;
					}
					if (operatorType == UnaryOperatorType.Decrement)
					{
						if (unaryOperatorExpression.Operator != UnaryOperatorType.Decrement)
						{
							return unaryOperatorExpression.Operator == UnaryOperatorType.PostDecrement;
						}
						return true;
					}
					return unaryOperatorExpression.Operator == operatorType;
				}
				return node is OperatorDeclaration;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(op, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}
		}

		private sealed class FindBinaryOperatorNavigator : FindReferenceNavigator
		{
			private readonly IMethod op;

			private readonly BinaryOperatorType operatorType;

			public FindBinaryOperatorNavigator(IMethod op, BinaryOperatorType operatorType)
			{
				this.op = op;
				this.operatorType = operatorType;
			}

			internal override bool CanMatch(AstNode node)
			{
				BinaryOperatorExpression binaryOperatorExpression = node as BinaryOperatorExpression;
				if (binaryOperatorExpression != null)
				{
					return binaryOperatorExpression.Operator == operatorType;
				}
				return node is OperatorDeclaration;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(op, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}
		}

		private sealed class FindImplicitOperatorNavigator : FindReferenceNavigator
		{
			private readonly IMethod op;

			public FindImplicitOperatorNavigator(IMethod op)
			{
				this.op = op;
			}

			internal override bool CanMatch(AstNode node)
			{
				return true;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(op, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}

			public override void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
			{
				if (conversion.IsUserDefined && findReferences.IsMemberMatch(op, conversion.Method, conversion.IsVirtualMethodLookup))
				{
					ReportMatch(expression, result);
				}
			}
		}

		private sealed class FindExplicitOperatorNavigator : FindReferenceNavigator
		{
			private readonly IMethod op;

			public FindExplicitOperatorNavigator(IMethod op)
			{
				this.op = op;
			}

			internal override bool CanMatch(AstNode node)
			{
				return node is CastExpression;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				ConversionResolveResult conversionResolveResult = rr as ConversionResolveResult;
				if (conversionResolveResult != null && conversionResolveResult.Conversion.IsUserDefined)
				{
					return findReferences.IsMemberMatch(op, conversionResolveResult.Conversion.Method, conversionResolveResult.Conversion.IsVirtualMethodLookup);
				}
				return false;
			}
		}

		private sealed class FindObjectCreateReferencesNavigator : FindReferenceNavigator
		{
			private readonly IMethod ctor;

			public FindObjectCreateReferencesNavigator(IMethod ctor)
			{
				this.ctor = ctor;
			}

			internal override bool CanMatch(AstNode node)
			{
				if (!(node is ObjectCreateExpression) && !(node is ConstructorDeclaration))
				{
					return node is Attribute;
				}
				return true;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(ctor, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}
		}

		private sealed class FindChainedConstructorReferencesNavigator : FindReferenceNavigator
		{
			private readonly IMethod ctor;

			public FindChainedConstructorReferencesNavigator(IMethod ctor)
			{
				this.ctor = ctor;
			}

			internal override bool CanMatch(AstNode node)
			{
				return node is ConstructorInitializer;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(ctor, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}
		}

		private sealed class FindDestructorReferencesNavigator : FindReferenceNavigator
		{
			private readonly IMethod dtor;

			public FindDestructorReferencesNavigator(IMethod dtor)
			{
				this.dtor = dtor;
			}

			internal override bool CanMatch(AstNode node)
			{
				return node is DestructorDeclaration;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				MemberResolveResult memberResolveResult = rr as MemberResolveResult;
				if (memberResolveResult != null)
				{
					return findReferences.IsMemberMatch(dtor, memberResolveResult.Member, memberResolveResult.IsVirtualCall);
				}
				return false;
			}
		}

		private class FindLocalReferencesNavigator : FindReferenceNavigator
		{
			private readonly IVariable variable;

			public FindLocalReferencesNavigator(IVariable variable)
			{
				this.variable = variable;
			}

			internal override bool CanMatch(AstNode node)
			{
				IdentifierExpression identifierExpression = node as IdentifierExpression;
				if (identifierExpression != null)
				{
					if (identifierExpression.TypeArguments.Count == 0)
					{
						return variable.Name == identifierExpression.Identifier;
					}
					return false;
				}
				VariableInitializer variableInitializer = node as VariableInitializer;
				if (variableInitializer != null)
				{
					return variableInitializer.Name == variable.Name;
				}
				ParameterDeclaration parameterDeclaration = node as ParameterDeclaration;
				if (parameterDeclaration != null)
				{
					return parameterDeclaration.Name == variable.Name;
				}
				Identifier identifier = node as Identifier;
				if (identifier != null)
				{
					return identifier.Name == variable.Name;
				}
				return false;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				LocalResolveResult localResolveResult = rr as LocalResolveResult;
				if (localResolveResult != null && localResolveResult.Variable.Name == variable.Name)
				{
					return localResolveResult.Variable.Region == variable.Region;
				}
				return false;
			}
		}

		private class FindTypeParameterReferencesNavigator : FindReferenceNavigator
		{
			private readonly ITypeParameter typeParameter;

			public FindTypeParameterReferencesNavigator(ITypeParameter typeParameter)
			{
				this.typeParameter = typeParameter;
			}

			internal override bool CanMatch(AstNode node)
			{
				SimpleType simpleType = node as SimpleType;
				if (simpleType != null)
				{
					return simpleType.Identifier == typeParameter.Name;
				}
				TypeParameterDeclaration typeParameterDeclaration = node as TypeParameterDeclaration;
				if (typeParameterDeclaration != null)
				{
					return typeParameterDeclaration.Name == typeParameter.Name;
				}
				return false;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				TypeResolveResult typeResolveResult = rr as TypeResolveResult;
				if (typeResolveResult != null && typeResolveResult.Type.Kind == TypeKind.TypeParameter)
				{
					return ((ITypeParameter)typeResolveResult.Type).Region == typeParameter.Region;
				}
				return false;
			}
		}

		private sealed class FindNamespaceNavigator : FindReferenceNavigator
		{
			private readonly INamespace ns;

			public FindNamespaceNavigator(INamespace ns)
			{
				this.ns = ns;
			}

			internal override bool CanMatch(AstNode node)
			{
				NamespaceDeclaration namespaceDeclaration = node as NamespaceDeclaration;
				if (namespaceDeclaration != null && namespaceDeclaration.FullName.StartsWith(ns.FullName, StringComparison.Ordinal))
				{
					return true;
				}
				UsingDeclaration usingDeclaration = node as UsingDeclaration;
				if (usingDeclaration != null && usingDeclaration.Namespace == ns.FullName)
				{
					return true;
				}
				SimpleType simpleType = node as SimpleType;
				if (simpleType != null && simpleType.Identifier == ns.Name)
				{
					return !simpleType.AncestorsAndSelf.TakeWhile((AstNode n) => n is AstType).Any((AstNode m) => m.Role == NamespaceDeclaration.NamespaceNameRole);
				}
				MemberType memberType = node as MemberType;
				if (memberType != null && memberType.MemberName == ns.Name)
				{
					return !memberType.AncestorsAndSelf.TakeWhile((AstNode n) => n is AstType).Any((AstNode m) => m.Role == NamespaceDeclaration.NamespaceNameRole);
				}
				IdentifierExpression identifierExpression = node as IdentifierExpression;
				if (identifierExpression != null && identifierExpression.Identifier == ns.Name)
				{
					return true;
				}
				MemberReferenceExpression memberReferenceExpression = node as MemberReferenceExpression;
				if (memberReferenceExpression != null && memberReferenceExpression.MemberName == ns.Name)
				{
					return true;
				}
				return false;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				return (rr as NamespaceResolveResult)?.NamespaceName.StartsWith(ns.FullName, StringComparison.Ordinal) ?? false;
			}
		}

		private class FindParameterReferencesNavigator : FindReferenceNavigator
		{
			private readonly IParameter parameter;

			public FindParameterReferencesNavigator(IParameter parameter)
			{
				this.parameter = parameter;
			}

			internal override bool CanMatch(AstNode node)
			{
				IdentifierExpression identifierExpression = node as IdentifierExpression;
				if (identifierExpression != null)
				{
					if (identifierExpression.TypeArguments.Count == 0)
					{
						return parameter.Name == identifierExpression.Identifier;
					}
					return false;
				}
				VariableInitializer variableInitializer = node as VariableInitializer;
				if (variableInitializer != null)
				{
					return variableInitializer.Name == parameter.Name;
				}
				ParameterDeclaration parameterDeclaration = node as ParameterDeclaration;
				if (parameterDeclaration != null)
				{
					return parameterDeclaration.Name == parameter.Name;
				}
				Identifier identifier = node as Identifier;
				if (identifier != null)
				{
					return identifier.Name == parameter.Name;
				}
				NamedArgumentExpression namedArgumentExpression = node as NamedArgumentExpression;
				if (namedArgumentExpression != null)
				{
					return namedArgumentExpression.Name == parameter.Name;
				}
				return false;
			}

			internal override bool IsMatch(ResolveResult rr)
			{
				LocalResolveResult localResolveResult = rr as LocalResolveResult;
				if (localResolveResult != null)
				{
					if (localResolveResult.Variable.Name == parameter.Name)
					{
						return localResolveResult.Variable.Region == parameter.Region;
					}
					return false;
				}
				NamedArgumentResolveResult namedArgumentResolveResult = rr as NamedArgumentResolveResult;
				if (namedArgumentResolveResult != null && namedArgumentResolveResult.Parameter.Name == parameter.Name)
				{
					return namedArgumentResolveResult.Parameter.Region == parameter.Region;
				}
				return false;
			}
		}

		public bool FindTypeReferencesEvenIfAliased
		{
			get;
			set;
		}

		public bool FindOnlySpecializedReferences
		{
			get;
			set;
		}

		public bool FindCallsThroughVirtualBaseMethod
		{
			get;
			set;
		}

		public bool FindCallsThroughInterface
		{
			get;
			set;
		}

		public bool WholeVirtualSlot
		{
			get;
			set;
		}

		public bool SearchInDocumentationComments
		{
			get;
			set;
		}

		public static Accessibility GetEffectiveAccessibility(IEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			Accessibility accessibility = entity.Accessibility;
			for (ITypeDefinition declaringTypeDefinition = entity.DeclaringTypeDefinition; declaringTypeDefinition != null; declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition)
			{
				accessibility = MergeAccessibility(declaringTypeDefinition.Accessibility, accessibility);
			}
			return accessibility;
		}

		private static Accessibility MergeAccessibility(Accessibility outer, Accessibility inner)
		{
			if (outer == inner)
			{
				return inner;
			}
			if (outer == Accessibility.None || inner == Accessibility.None)
			{
				return Accessibility.None;
			}
			if (outer == Accessibility.Private || inner == Accessibility.Private)
			{
				return Accessibility.Private;
			}
			if (outer == Accessibility.Public)
			{
				return inner;
			}
			if (inner == Accessibility.Public)
			{
				return outer;
			}
			if (outer == Accessibility.ProtectedOrInternal)
			{
				return inner;
			}
			if (inner == Accessibility.ProtectedOrInternal)
			{
				return outer;
			}
			return Accessibility.ProtectedAndInternal;
		}

		public IList<IFindReferenceSearchScope> GetSearchScopes(ISymbol symbol)
		{
			if (symbol == null)
			{
				throw new ArgumentNullException("symbol");
			}
			switch (symbol.SymbolKind)
			{
			case SymbolKind.Namespace:
				return new SearchScope[1]
				{
					GetSearchScopeForNamespace((INamespace)symbol)
				};
			case SymbolKind.TypeParameter:
				return new SearchScope[1]
				{
					GetSearchScopeForTypeParameter((ITypeParameter)symbol)
				};
			default:
			{
				SearchScope additionalScope = null;
				IEntity entity = null;
				SearchScope searchScope;
				if (symbol.SymbolKind == SymbolKind.Variable)
				{
					IVariable variable = (IVariable)symbol;
					searchScope = GetSearchScopeForLocalVariable(variable);
				}
				else if (symbol.SymbolKind == SymbolKind.Parameter)
				{
					IParameter parameter = (IParameter)symbol;
					searchScope = GetSearchScopeForParameter(parameter);
					entity = parameter.Owner;
				}
				else
				{
					entity = (symbol as IEntity);
					if (entity == null)
					{
						throw new NotSupportedException("Unsupported symbol type");
					}
					if (entity is IMember)
					{
						entity = NormalizeMember((IMember)entity);
					}
					switch (entity.SymbolKind)
					{
					case SymbolKind.TypeDefinition:
						searchScope = FindTypeDefinitionReferences((ITypeDefinition)entity, FindTypeReferencesEvenIfAliased, out additionalScope);
						break;
					case SymbolKind.Field:
						searchScope = ((entity.DeclaringTypeDefinition == null || entity.DeclaringTypeDefinition.Kind != TypeKind.Enum) ? FindMemberReferences(entity, (IMember m) => new FindFieldReferences((IField)m)) : FindMemberReferences(entity, (IMember m) => new FindEnumMemberReferences((IField)m)));
						break;
					case SymbolKind.Property:
						searchScope = FindMemberReferences(entity, (IMember m) => new FindPropertyReferences((IProperty)m));
						if (entity.Name == "Current")
						{
							additionalScope = FindEnumeratorCurrentReferences((IProperty)entity);
						}
						else if (entity.Name == "IsCompleted")
						{
							additionalScope = FindAwaiterIsCompletedReferences((IProperty)entity);
						}
						break;
					case SymbolKind.Event:
						searchScope = FindMemberReferences(entity, (IMember m) => new FindEventReferences((IEvent)m));
						break;
					case SymbolKind.Method:
						searchScope = GetSearchScopeForMethod((IMethod)entity);
						break;
					case SymbolKind.Indexer:
						searchScope = FindIndexerReferences((IProperty)entity);
						break;
					case SymbolKind.Operator:
						searchScope = GetSearchScopeForOperator((IMethod)entity);
						break;
					case SymbolKind.Constructor:
					{
						IMethod ctor = (IMethod)entity;
						searchScope = FindObjectCreateReferences(ctor);
						additionalScope = FindChainedConstructorReferences(ctor);
						break;
					}
					case SymbolKind.Destructor:
						searchScope = GetSearchScopeForDestructor((IMethod)entity);
						break;
					default:
						throw new ArgumentException("Unknown entity type " + entity.SymbolKind);
					}
				}
				Accessibility accessibility = (entity == null) ? Accessibility.Private : GetEffectiveAccessibility(entity);
				ITypeDefinition topLevelTypeDefinition = GetTopLevelTypeDefinition(entity);
				if (searchScope.accessibility == Accessibility.None)
				{
					searchScope.accessibility = accessibility;
				}
				searchScope.declarationCompilation = entity?.Compilation;
				searchScope.topLevelTypeDefinition = topLevelTypeDefinition;
				searchScope.findReferences = this;
				if (additionalScope != null)
				{
					if (additionalScope.accessibility == Accessibility.None)
					{
						additionalScope.accessibility = accessibility;
					}
					additionalScope.declarationCompilation = searchScope.declarationCompilation;
					additionalScope.topLevelTypeDefinition = topLevelTypeDefinition;
					additionalScope.findReferences = this;
					return new SearchScope[2]
					{
						searchScope,
						additionalScope
					};
				}
				return new SearchScope[1]
				{
					searchScope
				};
			}
			}
		}

		public IList<IFindReferenceSearchScope> GetSearchScopes(IEnumerable<ISymbol> symbols)
		{
			if (symbols == null)
			{
				throw new ArgumentNullException("symbols");
			}
			return symbols.SelectMany(GetSearchScopes).ToList();
		}

		private static ITypeDefinition GetTopLevelTypeDefinition(IEntity entity)
		{
			if (entity == null)
			{
				return null;
			}
			ITypeDefinition declaringTypeDefinition = entity.DeclaringTypeDefinition;
			while (declaringTypeDefinition != null && declaringTypeDefinition.DeclaringTypeDefinition != null)
			{
				declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition;
			}
			return declaringTypeDefinition;
		}

		public IEnumerable<CSharpUnresolvedFile> GetInterestingFiles(IFindReferenceSearchScope searchScope, ICompilation compilation)
		{
			if (searchScope == null)
			{
				throw new ArgumentNullException("searchScope");
			}
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			IProjectContent projectContent = compilation.MainAssembly.UnresolvedAssembly as IProjectContent;
			if (projectContent == null)
			{
				throw new ArgumentException("Main assembly is not a project content");
			}
			if (searchScope.TopLevelTypeDefinition != null)
			{
				ITypeDefinition typeDefinition = compilation.Import(searchScope.TopLevelTypeDefinition);
				if (typeDefinition == null)
				{
					return EmptyList<CSharpUnresolvedFile>.Instance;
				}
				switch (searchScope.Accessibility)
				{
				case Accessibility.None:
				case Accessibility.Private:
					if (typeDefinition.ParentAssembly == compilation.MainAssembly)
					{
						return (from p in typeDefinition.Parts
							select p.UnresolvedFile).OfType<CSharpUnresolvedFile>().Distinct();
					}
					return EmptyList<CSharpUnresolvedFile>.Instance;
				case Accessibility.Protected:
					return GetInterestingFilesProtected(typeDefinition);
				case Accessibility.Internal:
					if (typeDefinition.ParentAssembly.InternalsVisibleTo(compilation.MainAssembly))
					{
						return projectContent.Files.OfType<CSharpUnresolvedFile>();
					}
					return EmptyList<CSharpUnresolvedFile>.Instance;
				case Accessibility.ProtectedAndInternal:
					if (typeDefinition.ParentAssembly.InternalsVisibleTo(compilation.MainAssembly))
					{
						return GetInterestingFilesProtected(typeDefinition);
					}
					return EmptyList<CSharpUnresolvedFile>.Instance;
				case Accessibility.ProtectedOrInternal:
					if (typeDefinition.ParentAssembly.InternalsVisibleTo(compilation.MainAssembly))
					{
						return projectContent.Files.OfType<CSharpUnresolvedFile>();
					}
					return GetInterestingFilesProtected(typeDefinition);
				default:
					return projectContent.Files.OfType<CSharpUnresolvedFile>();
				}
			}
			if (searchScope.FileName == null)
			{
				return projectContent.Files.OfType<CSharpUnresolvedFile>();
			}
			return from f in projectContent.Files.OfType<CSharpUnresolvedFile>()
				where f.FileName == searchScope.FileName
				select f;
		}

		private IEnumerable<CSharpUnresolvedFile> GetInterestingFilesProtected(ITypeDefinition referencedTypeDefinition)
		{
			return (from typeDef in referencedTypeDefinition.Compilation.MainAssembly.GetAllTypeDefinitions()
				where typeDef.IsDerivedFrom(referencedTypeDefinition)
				from part in typeDef.Parts
				select part.UnresolvedFile).OfType<CSharpUnresolvedFile>().Distinct();
		}

		public void FindReferencesInFile(IFindReferenceSearchScope searchScope, CSharpAstResolver resolver, FoundReferenceCallback callback, CancellationToken cancellationToken)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			FindReferencesInFile(searchScope, resolver.UnresolvedFile, (SyntaxTree)resolver.RootNode, resolver.Compilation, callback, cancellationToken);
		}

		public void FindReferencesInFile(IList<IFindReferenceSearchScope> searchScopes, CSharpAstResolver resolver, FoundReferenceCallback callback, CancellationToken cancellationToken)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			FindReferencesInFile(searchScopes, resolver.UnresolvedFile, (SyntaxTree)resolver.RootNode, resolver.Compilation, callback, cancellationToken);
		}

		public void FindReferencesInFile(IFindReferenceSearchScope searchScope, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, ICompilation compilation, FoundReferenceCallback callback, CancellationToken cancellationToken)
		{
			if (searchScope == null)
			{
				throw new ArgumentNullException("searchScope");
			}
			FindReferencesInFile(new IFindReferenceSearchScope[1]
			{
				searchScope
			}, unresolvedFile, syntaxTree, compilation, callback, cancellationToken);
		}

		public void FindReferencesInFile(IList<IFindReferenceSearchScope> searchScopes, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, ICompilation compilation, FoundReferenceCallback callback, CancellationToken cancellationToken)
		{
			if (searchScopes == null)
			{
				throw new ArgumentNullException("searchScopes");
			}
			if (syntaxTree == null)
			{
				throw new ArgumentNullException("syntaxTree");
			}
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (searchScopes.Count != 0)
			{
				IResolveVisitorNavigator[] array = new IResolveVisitorNavigator[searchScopes.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = searchScopes[i].GetNavigator(compilation, callback);
				}
				IResolveVisitorNavigator navigator = (searchScopes.Count != 1) ? new CompositeResolveVisitorNavigator(array) : array[0];
				cancellationToken.ThrowIfCancellationRequested();
				navigator = new DetectSkippableNodesNavigator(navigator, syntaxTree);
				cancellationToken.ThrowIfCancellationRequested();
				CSharpAstResolver cSharpAstResolver = new CSharpAstResolver(compilation, syntaxTree, unresolvedFile);
				cSharpAstResolver.ApplyNavigator(navigator, cancellationToken);
				IResolveVisitorNavigator[] array2 = array;
				for (int j = 0; j < array2.Length; j++)
				{
					(array2[j] as FindReferenceNavigator)?.NavigatorDone(cSharpAstResolver, cancellationToken);
				}
			}
		}

		public static AstNode GetNodeToReplace(AstNode node)
		{
			if (node is ConstructorInitializer)
			{
				return null;
			}
			if (node is ObjectCreateExpression)
			{
				node = ((ObjectCreateExpression)node).Type;
			}
			if (node is InvocationExpression)
			{
				node = ((InvocationExpression)node).Target;
			}
			if (node is MemberReferenceExpression)
			{
				node = ((MemberReferenceExpression)node).MemberNameToken;
			}
			if (node is SimpleType)
			{
				node = ((SimpleType)node).IdentifierToken;
			}
			if (node is MemberType)
			{
				node = ((MemberType)node).MemberNameToken;
			}
			if (node is NamespaceDeclaration)
			{
				return null;
			}
			if (node is TypeDeclaration)
			{
				node = ((TypeDeclaration)node).NameToken;
			}
			if (node is DelegateDeclaration)
			{
				node = ((DelegateDeclaration)node).NameToken;
			}
			if (node is EntityDeclaration)
			{
				node = ((EntityDeclaration)node).NameToken;
			}
			if (node is ParameterDeclaration)
			{
				node = ((ParameterDeclaration)node).NameToken;
			}
			if (node is ConstructorDeclaration)
			{
				node = ((ConstructorDeclaration)node).NameToken;
			}
			if (node is DestructorDeclaration)
			{
				node = ((DestructorDeclaration)node).NameToken;
			}
			if (node is NamedArgumentExpression)
			{
				node = ((NamedArgumentExpression)node).NameToken;
			}
			if (node is NamedExpression)
			{
				node = ((NamedExpression)node).NameToken;
			}
			if (node is VariableInitializer)
			{
				node = ((VariableInitializer)node).NameToken;
			}
			if (node is IdentifierExpression)
			{
				node = ((IdentifierExpression)node).IdentifierToken;
			}
			return node;
		}

		public void RenameReferencesInFile(IList<IFindReferenceSearchScope> searchScopes, string newName, CSharpAstResolver resolver, Action<RenameCallbackArguments> callback, Action<Error> errorCallback, CancellationToken cancellationToken = default(CancellationToken))
		{
			FindReferencesInFile(searchScopes, resolver, delegate(AstNode astNode, ResolveResult result)
			{
				AstNode nodeToReplace = GetNodeToReplace(astNode);
				if (nodeToReplace == null)
				{
					errorCallback(new Error(ErrorType.Error, "no node to replace found."));
				}
				else
				{
					callback(new RenameCallbackArguments(nodeToReplace, Identifier.Create(newName)));
				}
			}, cancellationToken);
		}

		private SearchScope FindTypeDefinitionReferences(ITypeDefinition typeDefinition, bool findTypeReferencesEvenIfAliased, out SearchScope additionalScope)
		{
			string text = null;
			additionalScope = null;
			if (!findTypeReferencesEvenIfAliased && KnownTypeReference.GetCSharpNameByTypeCode(typeDefinition.KnownTypeCode) == null)
			{
				text = typeDefinition.Name;
				if (text.Length > 9 && text.EndsWith("Attribute", StringComparison.Ordinal))
				{
					string searchTerm = text.Substring(0, text.Length - 9);
					additionalScope = FindTypeDefinitionReferences(typeDefinition, searchTerm);
				}
			}
			return FindTypeDefinitionReferences(typeDefinition, text);
		}

		private SearchScope FindTypeDefinitionReferences(ITypeDefinition typeDefinition, string searchTerm)
		{
			return new SearchScope(searchTerm, delegate(ICompilation compilation)
			{
				ITypeDefinition typeDefinition2 = compilation.Import(typeDefinition);
				return (typeDefinition2 != null) ? new FindTypeDefinitionReferencesNavigator(typeDefinition2, searchTerm) : null;
			});
		}

		private SearchScope FindMemberReferences(IEntity member, Func<IMember, FindMemberReferencesNavigator> factory)
		{
			return new SearchScope(member.Name, delegate(ICompilation compilation)
			{
				IMember member2 = compilation.Import((IMember)member);
				return (member2 == null) ? null : factory(member2);
			});
		}

		private IMember NormalizeMember(IMember member)
		{
			if (WholeVirtualSlot && member.IsOverride)
			{
				member = (InheritanceHelper.GetBaseMembers(member, includeImplementedInterfaces: false).FirstOrDefault((IMember m) => !m.IsOverride) ?? member);
			}
			if (!FindOnlySpecializedReferences)
			{
				member = member.MemberDefinition;
			}
			return member;
		}

		private bool IsMemberMatch(IMember member, IMember referencedMember, bool isVirtualCall)
		{
			referencedMember = NormalizeMember(referencedMember);
			if (member.Equals(referencedMember))
			{
				return true;
			}
			if (FindCallsThroughInterface && member.DeclaringTypeDefinition != null && member.DeclaringTypeDefinition.Kind == TypeKind.Interface)
			{
				if (FindOnlySpecializedReferences)
				{
					return referencedMember.ImplementedInterfaceMembers.Contains(member);
				}
				return referencedMember.ImplementedInterfaceMembers.Any((IMember m) => m.MemberDefinition.Equals(member));
			}
			if (!isVirtualCall)
			{
				return false;
			}
			bool flag = referencedMember.DeclaringTypeDefinition != null && referencedMember.DeclaringTypeDefinition.Kind == TypeKind.Interface;
			if (FindCallsThroughVirtualBaseMethod && member.IsOverride && !WholeVirtualSlot && !flag)
			{
				foreach (IMember baseMember in InheritanceHelper.GetBaseMembers(member, includeImplementedInterfaces: false))
				{
					if (FindOnlySpecializedReferences)
					{
						if (baseMember.Equals(referencedMember))
						{
							return true;
						}
					}
					else if (baseMember.MemberDefinition.Equals(referencedMember))
					{
						return true;
					}
					if (!baseMember.IsOverride)
					{
						break;
					}
				}
				return false;
			}
			if (FindCallsThroughInterface && flag)
			{
				if (FindOnlySpecializedReferences)
				{
					return member.ImplementedInterfaceMembers.Contains(referencedMember);
				}
				return member.ImplementedInterfaceMembers.Any((IMember m) => m.MemberDefinition.Equals(referencedMember));
			}
			return false;
		}

		private SearchScope FindEnumeratorCurrentReferences(IProperty property)
		{
			return new SearchScope(delegate(ICompilation compilation)
			{
				IProperty property2 = compilation.Import(property);
				return (property2 == null) ? null : new FindEnumeratorCurrentReferencesNavigator(property2);
			});
		}

		private SearchScope FindAwaiterIsCompletedReferences(IProperty property)
		{
			return new SearchScope(delegate(ICompilation compilation)
			{
				IProperty property2 = compilation.Import(property);
				return (property2 == null) ? null : new FindAwaiterIsCompletedReferencesNavigator(property2);
			});
		}

		private SearchScope GetSearchScopeForMethod(IMethod method)
		{
			Type specialNodeType;
			switch (method.Name)
			{
			case "Add":
				specialNodeType = typeof(ArrayInitializerExpression);
				break;
			case "Where":
				specialNodeType = typeof(QueryWhereClause);
				break;
			case "Select":
				specialNodeType = typeof(QuerySelectClause);
				break;
			case "SelectMany":
				specialNodeType = typeof(QueryFromClause);
				break;
			case "Join":
			case "GroupJoin":
				specialNodeType = typeof(QueryJoinClause);
				break;
			case "OrderBy":
			case "OrderByDescending":
			case "ThenBy":
			case "ThenByDescending":
				specialNodeType = typeof(QueryOrdering);
				break;
			case "GroupBy":
				specialNodeType = typeof(QueryGroupClause);
				break;
			case "Invoke":
				if (method.DeclaringTypeDefinition != null && method.DeclaringTypeDefinition.Kind == TypeKind.Delegate)
				{
					specialNodeType = typeof(InvocationExpression);
				}
				else
				{
					specialNodeType = null;
				}
				break;
			case "GetEnumerator":
			case "MoveNext":
				specialNodeType = typeof(ForeachStatement);
				break;
			case "GetAwaiter":
			case "GetResult":
			case "OnCompleted":
			case "UnsafeOnCompleted":
				specialNodeType = typeof(UnaryOperatorExpression);
				break;
			default:
				specialNodeType = null;
				break;
			}
			return new SearchScope((specialNodeType == null) ? method.Name : null, delegate(ICompilation compilation)
			{
				IMethod method2 = compilation.Import(method);
				return (method2 != null) ? new FindMethodReferences(method2, specialNodeType) : null;
			});
		}

		private SearchScope FindIndexerReferences(IProperty indexer)
		{
			return new SearchScope(delegate(ICompilation compilation)
			{
				IProperty property = compilation.Import(indexer);
				return (property != null) ? new FindIndexerReferencesNavigator(property) : null;
			});
		}

		private SearchScope GetSearchScopeForOperator(IMethod op)
		{
			OperatorType? operatorType = OperatorDeclaration.GetOperatorType(op.Name);
			if (!operatorType.HasValue)
			{
				return GetSearchScopeForMethod(op);
			}
			switch (operatorType.Value)
			{
			case OperatorType.LogicalNot:
				return FindUnaryOperator(op, UnaryOperatorType.Not);
			case OperatorType.OnesComplement:
				return FindUnaryOperator(op, UnaryOperatorType.BitNot);
			case OperatorType.UnaryPlus:
				return FindUnaryOperator(op, UnaryOperatorType.Plus);
			case OperatorType.UnaryNegation:
				return FindUnaryOperator(op, UnaryOperatorType.Minus);
			case OperatorType.Increment:
				return FindUnaryOperator(op, UnaryOperatorType.Increment);
			case OperatorType.Decrement:
				return FindUnaryOperator(op, UnaryOperatorType.Decrement);
			case OperatorType.True:
			case OperatorType.False:
				return GetSearchScopeForMethod(op);
			case OperatorType.Addition:
				return FindBinaryOperator(op, BinaryOperatorType.Add);
			case OperatorType.Subtraction:
				return FindBinaryOperator(op, BinaryOperatorType.Subtract);
			case OperatorType.Multiply:
				return FindBinaryOperator(op, BinaryOperatorType.Multiply);
			case OperatorType.Division:
				return FindBinaryOperator(op, BinaryOperatorType.Divide);
			case OperatorType.Modulus:
				return FindBinaryOperator(op, BinaryOperatorType.Modulus);
			case OperatorType.BitwiseAnd:
				return FindBinaryOperator(op, BinaryOperatorType.BitwiseAnd);
			case OperatorType.BitwiseOr:
				return FindBinaryOperator(op, BinaryOperatorType.BitwiseOr);
			case OperatorType.ExclusiveOr:
				return FindBinaryOperator(op, BinaryOperatorType.ExclusiveOr);
			case OperatorType.LeftShift:
				return FindBinaryOperator(op, BinaryOperatorType.ShiftLeft);
			case OperatorType.RightShift:
				return FindBinaryOperator(op, BinaryOperatorType.ShiftRight);
			case OperatorType.Equality:
				return FindBinaryOperator(op, BinaryOperatorType.Equality);
			case OperatorType.Inequality:
				return FindBinaryOperator(op, BinaryOperatorType.InEquality);
			case OperatorType.GreaterThan:
				return FindBinaryOperator(op, BinaryOperatorType.GreaterThan);
			case OperatorType.LessThan:
				return FindBinaryOperator(op, BinaryOperatorType.LessThan);
			case OperatorType.GreaterThanOrEqual:
				return FindBinaryOperator(op, BinaryOperatorType.GreaterThanOrEqual);
			case OperatorType.LessThanOrEqual:
				return FindBinaryOperator(op, BinaryOperatorType.LessThanOrEqual);
			case OperatorType.Implicit:
				return FindOperator(op, (IMethod m) => new FindImplicitOperatorNavigator(m));
			case OperatorType.Explicit:
				return FindOperator(op, (IMethod m) => new FindExplicitOperatorNavigator(m));
			default:
				throw new InvalidOperationException("Invalid value for OperatorType");
			}
		}

		private SearchScope FindOperator(IMethod op, Func<IMethod, FindReferenceNavigator> factory)
		{
			return new SearchScope(delegate(ICompilation compilation)
			{
				IMethod method = compilation.Import(op);
				return (method == null) ? null : factory(method);
			});
		}

		private SearchScope FindUnaryOperator(IMethod op, UnaryOperatorType operatorType)
		{
			return FindOperator(op, (IMethod m) => new FindUnaryOperatorNavigator(m, operatorType));
		}

		private SearchScope FindBinaryOperator(IMethod op, BinaryOperatorType operatorType)
		{
			return FindOperator(op, (IMethod m) => new FindBinaryOperatorNavigator(m, operatorType));
		}

		private SearchScope FindObjectCreateReferences(IMethod ctor)
		{
			string text = null;
			if (KnownTypeReference.GetCSharpNameByTypeCode(ctor.DeclaringTypeDefinition.KnownTypeCode) == null)
			{
				text = ctor.DeclaringTypeDefinition.Name;
				if (text.Length > 9 && text.EndsWith("Attribute", StringComparison.Ordinal))
				{
					text = null;
				}
			}
			return new SearchScope(text, delegate(ICompilation compilation)
			{
				IMethod method = compilation.Import(ctor);
				return (method != null) ? new FindObjectCreateReferencesNavigator(method) : null;
			});
		}

		private SearchScope FindChainedConstructorReferences(IMethod ctor)
		{
			SearchScope searchScope = new SearchScope(delegate(ICompilation compilation)
			{
				IMethod method = compilation.Import(ctor);
				return (method != null) ? new FindChainedConstructorReferencesNavigator(method) : null;
			});
			if (ctor.DeclaringTypeDefinition.IsSealed)
			{
				searchScope.accessibility = Accessibility.Private;
			}
			else
			{
				searchScope.accessibility = Accessibility.Protected;
			}
			searchScope.accessibility = MergeAccessibility(GetEffectiveAccessibility(ctor), searchScope.accessibility);
			return searchScope;
		}

		private SearchScope GetSearchScopeForDestructor(IMethod dtor)
		{
			return new SearchScope(delegate(ICompilation compilation)
			{
				IMethod method = compilation.Import(dtor);
				return (method != null) ? new FindDestructorReferencesNavigator(method) : null;
			})
			{
				accessibility = Accessibility.Private
			};
		}

		public void FindLocalReferences(IVariable variable, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, ICompilation compilation, FoundReferenceCallback callback, CancellationToken cancellationToken)
		{
			if (variable == null)
			{
				throw new ArgumentNullException("variable");
			}
			SearchScope searchScope = new SearchScope((ICompilation c) => new FindLocalReferencesNavigator(variable));
			searchScope.declarationCompilation = compilation;
			FindReferencesInFile(searchScope, unresolvedFile, syntaxTree, compilation, callback, cancellationToken);
		}

		private SearchScope GetSearchScopeForLocalVariable(IVariable variable)
		{
			return new SearchScope((ICompilation _003Carg_003E) => new FindLocalReferencesNavigator(variable))
			{
				fileName = variable.Region.FileName
			};
		}

		[Obsolete("Use GetSearchScopes(typeParameter) instead")]
		public void FindTypeParameterReferences(IType typeParameter, CSharpUnresolvedFile unresolvedFile, SyntaxTree syntaxTree, ICompilation compilation, FoundReferenceCallback callback, CancellationToken cancellationToken)
		{
			if (typeParameter == null)
			{
				throw new ArgumentNullException("typeParameter");
			}
			if (typeParameter.Kind != TypeKind.TypeParameter)
			{
				throw new ArgumentOutOfRangeException("typeParameter", "Only type parameters are allowed");
			}
			SearchScope searchScope = new SearchScope((ICompilation c) => new FindTypeParameterReferencesNavigator((ITypeParameter)typeParameter));
			searchScope.declarationCompilation = compilation;
			searchScope.accessibility = Accessibility.Private;
			FindReferencesInFile(searchScope, unresolvedFile, syntaxTree, compilation, callback, cancellationToken);
		}

		private SearchScope GetSearchScopeForTypeParameter(ITypeParameter tp)
		{
			SearchScope searchScope = new SearchScope((ICompilation c) => new FindTypeParameterReferencesNavigator(tp));
			ICompilationProvider compilationProvider = tp as ICompilationProvider;
			if (compilationProvider != null)
			{
				searchScope.declarationCompilation = compilationProvider.Compilation;
			}
			searchScope.topLevelTypeDefinition = GetTopLevelTypeDefinition(tp.Owner);
			searchScope.accessibility = Accessibility.Private;
			return searchScope;
		}

		private SearchScope GetSearchScopeForNamespace(INamespace ns)
		{
			return new SearchScope((ICompilation compilation) => new FindNamespaceNavigator(ns));
		}

		private SearchScope GetSearchScopeForParameter(IParameter parameter)
		{
			SearchScope searchScope = new SearchScope((ICompilation _003Carg_003E) => new FindParameterReferencesNavigator(parameter));
			if (parameter.Owner == null)
			{
				searchScope.fileName = parameter.Region.FileName;
			}
			return searchScope;
		}
	}
}

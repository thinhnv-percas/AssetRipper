#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class IntroduceExtensionMethods : DepthFirstAstVisitor, IAstTransform
{
	private TransformContext context;

	private CSharpResolver resolver;

	private CSharpConversions conversions;

	private Stack<CSharpTypeResolveContext> resolveContextStack = new Stack<CSharpTypeResolveContext>();

	public void Run(AstNode rootNode, TransformContext context)
	{
		this.context = context;
		conversions = CSharpConversions.Get(context.TypeSystem);
		InitializeContext(rootNode.Annotation<UsingScope>());
		rootNode.AcceptVisitor(this);
	}

	private void InitializeContext(UsingScope usingScope)
	{
		resolveContextStack = new Stack<CSharpTypeResolveContext>();
		if (!string.IsNullOrEmpty(context.CurrentTypeDefinition?.Namespace))
		{
			string[] array = context.CurrentTypeDefinition.Namespace.Split(new char[1] { '.' });
			foreach (string shortName in array)
			{
				usingScope = new UsingScope(usingScope, shortName);
			}
		}
		CSharpTypeResolveContext cSharpTypeResolveContext = new CSharpTypeResolveContext(context.TypeSystem.MainModule, usingScope.Resolve(context.TypeSystem), context.CurrentTypeDefinition);
		resolveContextStack.Push(cSharpTypeResolveContext);
		resolver = new CSharpResolver(cSharpTypeResolveContext);
	}

	public override void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
	{
		CSharpTypeResolveContext cSharpTypeResolveContext = resolveContextStack.Peek();
		UsingScope usingScope = cSharpTypeResolveContext.CurrentUsingScope.UnresolvedUsingScope;
		foreach (string identifier in namespaceDeclaration.Identifiers)
		{
			usingScope = new UsingScope(usingScope, identifier);
		}
		CSharpTypeResolveContext cSharpTypeResolveContext2 = new CSharpTypeResolveContext(cSharpTypeResolveContext.CurrentModule, usingScope.Resolve(cSharpTypeResolveContext.Compilation));
		resolveContextStack.Push(cSharpTypeResolveContext2);
		try
		{
			resolver = new CSharpResolver(cSharpTypeResolveContext2);
			base.VisitNamespaceDeclaration(namespaceDeclaration);
		}
		finally
		{
			resolver = new CSharpResolver(cSharpTypeResolveContext);
			resolveContextStack.Pop();
		}
	}

	public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
	{
		CSharpTypeResolveContext cSharpTypeResolveContext = resolveContextStack.Peek();
		CSharpTypeResolveContext cSharpTypeResolveContext2 = cSharpTypeResolveContext.WithCurrentTypeDefinition(typeDeclaration.GetSymbol() as ITypeDefinition);
		resolveContextStack.Push(cSharpTypeResolveContext2);
		try
		{
			resolver = new CSharpResolver(cSharpTypeResolveContext2);
			base.VisitTypeDeclaration(typeDeclaration);
		}
		finally
		{
			resolver = new CSharpResolver(cSharpTypeResolveContext);
			resolveContextStack.Pop();
		}
	}

	public override void VisitInvocationExpression(InvocationExpression invocationExpression)
	{
		base.VisitInvocationExpression(invocationExpression);
		IMethod method = invocationExpression.GetSymbol() as IMethod;
		if (method == null || !method.IsExtensionMethod || !invocationExpression.Arguments.Any())
		{
			return;
		}
		Expression target = invocationExpression.Target;
		Expression expression = target;
		if (expression == null)
		{
			return;
		}
		IReadOnlyList<IType> typeArguments;
		MemberReferenceExpression memberReferenceExpression2;
		if (!(expression is MemberReferenceExpression memberReferenceExpression))
		{
			if (!(expression is IdentifierExpression identifierExpression))
			{
				return;
			}
			IdentifierExpression identifierExpression2 = identifierExpression;
			IReadOnlyList<IType> readOnlyList;
			if (!identifierExpression2.TypeArguments.Any())
			{
				IReadOnlyList<IType> instance = EmptyList<IType>.Instance;
				readOnlyList = instance;
			}
			else
			{
				readOnlyList = method.TypeArguments;
			}
			typeArguments = readOnlyList;
			memberReferenceExpression2 = null;
		}
		else
		{
			MemberReferenceExpression memberReferenceExpression3 = memberReferenceExpression;
			IReadOnlyList<IType> readOnlyList2;
			if (!memberReferenceExpression3.TypeArguments.Any())
			{
				IReadOnlyList<IType> instance = EmptyList<IType>.Instance;
				readOnlyList2 = instance;
			}
			else
			{
				readOnlyList2 = method.TypeArguments;
			}
			typeArguments = readOnlyList2;
			memberReferenceExpression2 = memberReferenceExpression3;
		}
		Expression expression2 = Enumerable.First<Expression>((IEnumerable<Expression>)invocationExpression.Arguments);
		if (expression2 is NamedArgumentExpression)
		{
			return;
		}
		ResolveResult resolveResult = expression2.GetResolveResult();
		if (resolveResult is ConstantResolveResult { ConstantValue: null } constantResolveResult)
		{
			resolveResult = new ConversionResolveResult(method.Parameters[0].Type, constantResolveResult, Conversion.NullLiteralConversion);
		}
		checked
		{
			ResolveResult[] array = new ResolveResult[invocationExpression.Arguments.Count - 1];
			string[] array2 = null;
			int num = 0;
			foreach (Expression item in Enumerable.Skip<Expression>((IEnumerable<Expression>)invocationExpression.Arguments, 1))
			{
				if (item is NamedArgumentExpression namedArgumentExpression)
				{
					if (array2 == null)
					{
						array2 = new string[array.Length];
					}
					array2[num] = namedArgumentExpression.Name;
					array[num] = namedArgumentExpression.Expression.GetResolveResult();
				}
				else
				{
					array[num] = item.GetResolveResult();
				}
				num++;
			}
			if (!CanTransformToExtensionMethodCall(resolver, method, typeArguments, resolveResult, array, array2))
			{
				return;
			}
			if (expression2 is NullReferenceExpression)
			{
				Debug.Assert(context.RequiredNamespacesSuperset.Contains(method.Parameters[0].Type.Namespace));
				expression2 = expression2.ReplaceWith((Expression expr) => new CastExpression(context.TypeSystemAstBuilder.ConvertType(method.Parameters[0].Type), expr.Detach()));
			}
			if (invocationExpression.Target is IdentifierExpression identifierExpression3)
			{
				identifierExpression3.Detach();
				memberReferenceExpression2 = new MemberReferenceExpression(expression2.Detach(), method.Name, identifierExpression3.TypeArguments.Detach());
				invocationExpression.Target = memberReferenceExpression2;
			}
			else
			{
				memberReferenceExpression2.Target = expression2.Detach();
			}
			if (invocationExpression.GetResolveResult() is CSharpInvocationResolveResult cSharpInvocationResolveResult)
			{
				invocationExpression.RemoveAnnotations<CSharpInvocationResolveResult>();
				CSharpInvocationResolveResult annotation = new CSharpInvocationResolveResult(cSharpInvocationResolveResult.TargetResult, cSharpInvocationResolveResult.Member, cSharpInvocationResolveResult.Arguments, cSharpInvocationResolveResult.OverloadResolutionErrors, isExtensionMethodInvocation: true, cSharpInvocationResolveResult.IsExpandedForm, cSharpInvocationResolveResult.IsDelegateInvocation, cSharpInvocationResolveResult.GetArgumentToParameterMap(), cSharpInvocationResolveResult.InitializerStatements);
				invocationExpression.AddAnnotation(annotation);
			}
		}
	}

	public static bool CanTransformToExtensionMethodCall(CSharpResolver resolver, IMethod method, IReadOnlyList<IType> typeArguments, ResolveResult target, ResolveResult[] arguments, string[] argumentNames)
	{
		if (!(resolver.ResolveMemberAccess(target, method.Name, typeArguments, NameLookupMode.InvocationTarget) is MethodGroupResolveResult methodGroupResolveResult))
		{
			return false;
		}
		OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(resolver.CurrentTypeResolveContext.Compilation, arguments, argumentNames);
		if (overloadResolution == null || overloadResolution.IsAmbiguous)
		{
			return false;
		}
		return method.Equals(overloadResolution.GetBestCandidateWithSubstitutedTypeArguments());
	}

	public static bool CanTransformToExtensionMethodCall(IMethod method, CSharpTypeResolveContext resolveContext, bool ignoreTypeArguments = false, bool ignoreArgumentNames = true)
	{
		if (method.Parameters.Count == 0)
		{
			return false;
		}
		ResolveResult target = Enumerable.First<ResolveResult>(Enumerable.Select<IParameter, ResolveResult>((IEnumerable<IParameter>)method.Parameters, (Func<IParameter, ResolveResult>)((IParameter p) => new ResolveResult(p.Type))));
		ResolveResult[] arguments = Enumerable.ToArray<ResolveResult>(Enumerable.Select<IParameter, ResolveResult>(Enumerable.Skip<IParameter>((IEnumerable<IParameter>)method.Parameters, 1), (Func<IParameter, ResolveResult>)((IParameter p) => new ResolveResult(p.Type))));
		string[] argumentNames = (ignoreArgumentNames ? null : method.Parameters.SelectReadOnlyArray((IParameter p) => p.Name));
		IType[] typeArguments = (ignoreTypeArguments ? Empty<IType>.Array : Enumerable.ToArray<IType>((IEnumerable<IType>)method.TypeArguments));
		CSharpResolver cSharpResolver = new CSharpResolver(resolveContext);
		return CanTransformToExtensionMethodCall(cSharpResolver, method, typeArguments, target, arguments, argumentNames);
	}
}

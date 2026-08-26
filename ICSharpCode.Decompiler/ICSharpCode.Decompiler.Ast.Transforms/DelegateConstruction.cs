using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class DelegateConstruction : ContextTrackingVisitor<object>, IAstTransformPoolObject, IAstTransform
{
	internal sealed class Annotation
	{
		public static readonly Annotation True = new Annotation(isVirtual: true);

		public static readonly Annotation False = new Annotation(isVirtual: false);

		public readonly bool IsVirtual;

		private Annotation(bool isVirtual)
		{
			IsVirtual = isVirtual;
		}
	}

	internal sealed class CapturedVariableAnnotation
	{
		public static readonly CapturedVariableAnnotation Instance = new CapturedVariableAnnotation();

		private CapturedVariableAnnotation()
		{
		}
	}

	private readonly List<string> currentlyUsedVariableNames = new List<string>();

	private readonly StringBuilder stringBuilder;

	private readonly AutoPropertyProvider autoPropertyProvider;

	private static readonly UTF8String nameInvoke = new UTF8String("Invoke");

	private static readonly ExpressionStatement displayClassAssignmentPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new ObjectCreateExpression
	{
		Type = new AnyNode("type")
	}));

	public DelegateConstruction(DecompilerContext context)
		: base(context)
	{
		stringBuilder = new StringBuilder();
		autoPropertyProvider = new AutoPropertyProvider();
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
		base.context = context;
		currentlyUsedVariableNames.Clear();
		autoPropertyProvider.Reset();
	}

	public override object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
	{
		if (objectCreateExpression.Arguments.Count == 2)
		{
			Expression expression = objectCreateExpression.Arguments.First();
			Expression expression2 = objectCreateExpression.Arguments.Last();
			Annotation annotation = expression2.Annotation<Annotation>();
			if (annotation != null)
			{
				IdentifierExpression identifierExpression = (IdentifierExpression)((InvocationExpression)expression2).Arguments.Single();
				IMethod method = identifierExpression.Annotation<IMethod>();
				if (method != null)
				{
					if (HandleAnonymousMethod(objectCreateExpression, expression, method))
					{
						return null;
					}
					List<ILSpan> annotation2 = (context.CalculateILSpans ? objectCreateExpression.GetAllRecursiveILSpans() : null);
					expression.Remove();
					identifierExpression.Remove();
					if (!annotation.IsVirtual && expression is ThisReferenceExpression && method.DeclaringType.ResolveTypeDef() != context.CurrentType)
					{
						expression = new BaseReferenceExpression().WithAnnotation(method.DeclaringType);
					}
					if (!annotation.IsVirtual && expression is NullReferenceExpression && method.MethodSig != null && !method.MethodSig.HasThis)
					{
						bool flag = false;
						ITypeDefOrRef typeDefOrRef = objectCreateExpression.Type.Annotation<ITypeDefOrRef>();
						if (typeDefOrRef != null)
						{
							TypeDef typeDef = typeDefOrRef.ResolveTypeDef();
							if (typeDef != null)
							{
								MethodDef methodDef = typeDef.Methods.FirstOrDefault((MethodDef m) => m.Name == "Invoke");
								if (methodDef != null)
								{
									flag = methodDef.Parameters.GetNumberOfNormalParameters() + 1 == method.MethodSig.GetParameters().Count;
								}
							}
						}
						if (!flag)
						{
							expression = new TypeReferenceExpression
							{
								Type = AstBuilder.ConvertType(method.DeclaringType, stringBuilder)
							};
						}
					}
					MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression();
					memberReferenceExpression.Target = expression;
					memberReferenceExpression.MemberNameToken = (Identifier)identifierExpression.IdentifierToken.Clone();
					identifierExpression.TypeArguments.MoveTo(memberReferenceExpression.TypeArguments);
					memberReferenceExpression.AddAnnotation(method);
					AssignmentExpression assignmentExpression = objectCreateExpression.Parent as AssignmentExpression;
					if (context.Settings.RemoveNewDelegateClass && assignmentExpression != null && (assignmentExpression.Operator == AssignmentOperatorType.Add || assignmentExpression.Operator == AssignmentOperatorType.Subtract))
					{
						ITypeDefOrRef typeDefOrRef2 = objectCreateExpression.Annotation<IMethod>()?.DeclaringType;
						MethodDef methodDef2 = typeDefOrRef2.ResolveTypeDef()?.FindMethod(nameInvoke);
						if (methodDef2 != null)
						{
							MethodBaseSig methodBaseSig = GetMethodBaseSig(typeDefOrRef2, methodDef2.MethodSig);
							MethodBaseSig methodBaseSig2 = GetMethodBaseSig(method.DeclaringType, method.MethodSig, (method as MethodSpec)?.GenericInstMethodSig.GenericArguments);
							methodBaseSig = new MethodSig((methodBaseSig.CallingConvention | CallingConvention.HasThis) & ~CallingConvention.Generic, 0u, methodBaseSig.RetType, methodBaseSig.Params);
							methodBaseSig2 = new MethodSig((methodBaseSig2.CallingConvention | CallingConvention.HasThis) & ~CallingConvention.Generic, 0u, methodBaseSig2.RetType, methodBaseSig2.Params);
							if (default(SigComparer).Equals(methodBaseSig, methodBaseSig2))
							{
								objectCreateExpression.ReplaceWith(memberReferenceExpression);
								memberReferenceExpression.AddAnnotation(annotation2);
								return null;
							}
						}
					}
					objectCreateExpression.Arguments.Clear();
					objectCreateExpression.Arguments.Add(memberReferenceExpression);
					objectCreateExpression.AddAnnotation(annotation2);
					return null;
				}
			}
		}
		return base.VisitObjectCreateExpression(objectCreateExpression, data);
	}

	private static MethodBaseSig GetMethodBaseSig(ITypeDefOrRef type, MethodBaseSig msig, IList<TypeSig> methodGenArgs = null)
	{
		IList<TypeSig> list = null;
		if (type is TypeSpec typeSpec)
		{
			GenericInstSig genericInstSig = typeSpec.TypeSig.ToGenericInstSig();
			if (genericInstSig != null)
			{
				list = genericInstSig.GenericArguments;
			}
		}
		if (list == null && methodGenArgs == null)
		{
			return msig;
		}
		return GenericArgumentResolver.Resolve(msig, list, methodGenArgs);
	}

	internal static bool IsAnonymousMethod(DecompilerContext context, MethodDef method)
	{
		if (method == null || (!method.HasGeneratedName() && !method.Name.Contains("$")))
		{
			return false;
		}
		if (method.IsLocalFunction())
		{
			return false;
		}
		if (!method.IsCompilerGenerated() && !IsPotentialClosure(context, method.DeclaringType))
		{
			return false;
		}
		return true;
	}

	private bool HandleAnonymousMethod(ObjectCreateExpression objectCreateExpression, Expression target, IMethod methodRef)
	{
		if (!context.Settings.AnonymousMethods)
		{
			return false;
		}
		if (target != null && !(target is IdentifierExpression) && !(target is ThisReferenceExpression) && !(target is NullReferenceExpression) && !(target is MemberReferenceExpression))
		{
			return false;
		}
		MethodDef method = methodRef.ResolveMethodWithinSameModule();
		if (!IsAnonymousMethod(context, method))
		{
			return false;
		}
		List<ILSpan> annotation = (context.CalculateILSpans ? objectCreateExpression.GetAllRecursiveILSpans() : null);
		AnonymousMethodExpression anonymousMethodExpression = new AnonymousMethodExpression();
		anonymousMethodExpression.CopyAnnotationsFrom(objectCreateExpression);
		anonymousMethodExpression.RemoveAnnotations<IMethod>();
		anonymousMethodExpression.AddAnnotation(method);
		anonymousMethodExpression.Parameters.AddRange(AstBuilder.MakeParameters(context.MetadataTextColorProvider, method, context.Settings, stringBuilder, isLambda: true));
		anonymousMethodExpression.HasParameterList = true;
		foreach (ParameterDeclaration parameter in anonymousMethodExpression.Parameters)
		{
			EnsureVariableNameIsAvailable(objectCreateExpression, parameter.Name);
		}
		DecompilerContext decompilerContext = context.CloneDontUse();
		decompilerContext.CurrentMethod = method;
		decompilerContext.CurrentMethodIsAsync = false;
		decompilerContext.CurrentMethodIsYieldReturn = false;
		decompilerContext.ReservedVariableNames.AddRange(currentlyUsedVariableNames);
		decompilerContext.CalculateILSpans = true;
		BlockStatement blockStatement = AstMethodBodyBuilder.CreateMethodBody(method, decompilerContext, autoPropertyProvider, anonymousMethodExpression.Parameters, valueParameterIsKeyword: false, stringBuilder, out var stmtsBuilder);
		TransformationPipeline.RunTransformationsUntil(blockStatement, (IAstTransform v) => v is DelegateConstruction, decompilerContext);
		blockStatement.AcceptVisitor(this, null);
		anonymousMethodExpression.IsAsync = decompilerContext.CurrentMethodIsAsync;
		bool flag = false;
		if (anonymousMethodExpression.Parameters.All((ParameterDeclaration p) => p.ParameterModifier == ParameterModifier.None))
		{
			flag = blockStatement.Statements.Count == 1 && blockStatement.Statements.Single() is ReturnStatement && blockStatement.HiddenStart == null && blockStatement.HiddenEnd == null;
		}
		if (!flag && method.Parameters.SkipNonNormal().All((Parameter p) => string.IsNullOrEmpty(p.Name) || (p.Name.StartsWith("<") && p.Name.EndsWith(">"))))
		{
			IEnumerable<IdentifierExpression> source = from ident in blockStatement.Descendants.OfType<IdentifierExpression>()
				let v = ident.Annotation<ILVariable>()
				where v != null && v.IsParameter && method.Parameters.Contains(v.OriginalParameter)
				select ident;
			if (!source.Any())
			{
				MethodDef methodDef = objectCreateExpression.Parent.Annotation<IMethod>().ResolveMethodDef();
				TypeDef typeDef = methodDef?.DeclaringType;
				if (typeDef != null && !HasTwoOrMoreMethods(typeDef, methodDef.Name))
				{
					anonymousMethodExpression.AddAnnotation(anonymousMethodExpression.Parameters.GetAllRecursiveILSpans());
					anonymousMethodExpression.Parameters.Clear();
					anonymousMethodExpression.HasParameterList = false;
				}
			}
		}
		foreach (AstNode descendant in blockStatement.Descendants)
		{
			if (descendant is ThisReferenceExpression)
			{
				Expression expression = target.Clone();
				if (context.CalculateILSpans)
				{
					expression.RemoveAllILSpansRecursive();
					expression.AddAnnotation(descendant.GetAllRecursiveILSpans());
				}
				descendant.ReplaceWith(expression);
			}
		}
		Expression expression3;
		if (flag)
		{
			LambdaExpression lambdaExpression = new LambdaExpression();
			lambdaExpression.CopyAnnotationsFrom(anonymousMethodExpression);
			anonymousMethodExpression.Parameters.MoveTo(lambdaExpression.Parameters);
			List<ILSpan> allILSpans = blockStatement.Statements.Single().GetAllILSpans();
			Expression expression2 = ((ReturnStatement)blockStatement.Statements.Single()).Expression;
			if (allILSpans.Count > 0)
			{
				expression2.AddAnnotation(allILSpans);
			}
			expression2.Remove();
			expression2.AddAnnotation(stmtsBuilder);
			lambdaExpression.Body = expression2;
			lambdaExpression.IsAsync = decompilerContext.CurrentMethodIsAsync;
			expression3 = lambdaExpression;
		}
		else
		{
			anonymousMethodExpression.AddAnnotation(stmtsBuilder);
			anonymousMethodExpression.Body = blockStatement;
			expression3 = anonymousMethodExpression;
		}
		TypeDef typeDef2 = objectCreateExpression.Annotation<TypeInformation>().ExpectedType.Resolve();
		if (typeDef2 != null && !typeDef2.IsDelegate)
		{
			ObjectCreateExpression objectCreateExpression2 = (ObjectCreateExpression)objectCreateExpression.Clone();
			objectCreateExpression2.Arguments.Clear();
			objectCreateExpression2.Arguments.Add(expression3);
			expression3 = objectCreateExpression2;
		}
		objectCreateExpression.ReplaceWith(expression3);
		expression3.AddAnnotation(annotation);
		return true;
	}

	private static bool HasTwoOrMoreMethods(TypeDef type, UTF8String name)
	{
		int num = 0;
		while (type != null)
		{
			foreach (MethodDef method in type.Methods)
			{
				if (method.Name == name && ++num >= 2)
				{
					return true;
				}
			}
			type = type.BaseType.ResolveTypeDef();
		}
		return false;
	}

	internal static bool IsPotentialClosure(DecompilerContext context, TypeDef potentialDisplayClass)
	{
		if (potentialDisplayClass == null || !potentialDisplayClass.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
		{
			return false;
		}
		while (potentialDisplayClass != context.CurrentType)
		{
			potentialDisplayClass = potentialDisplayClass.DeclaringType;
			if (potentialDisplayClass == null)
			{
				return false;
			}
		}
		return true;
	}

	public override object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
	{
		if (context.Settings.ExpressionTrees && ExpressionTreeConverter.CouldBeExpressionTree(invocationExpression))
		{
			Expression expression = ExpressionTreeConverter.TryConvert(context, invocationExpression, stringBuilder);
			if (expression != null)
			{
				invocationExpression.ReplaceWith(expression);
				return expression.AcceptVisitor(this, data);
			}
		}
		return base.VisitInvocationExpression(invocationExpression, data);
	}

	public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
	{
		try
		{
			currentlyUsedVariableNames.AddRange(methodDeclaration.Parameters.Select((ParameterDeclaration p) => p.Name));
			return base.VisitMethodDeclaration(methodDeclaration, data);
		}
		finally
		{
			currentlyUsedVariableNames.Clear();
		}
	}

	public override object VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data)
	{
		try
		{
			currentlyUsedVariableNames.AddRange(operatorDeclaration.Parameters.Select((ParameterDeclaration p) => p.Name));
			return base.VisitOperatorDeclaration(operatorDeclaration, data);
		}
		finally
		{
			currentlyUsedVariableNames.Clear();
		}
	}

	public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
	{
		try
		{
			currentlyUsedVariableNames.AddRange(constructorDeclaration.Parameters.Select((ParameterDeclaration p) => p.Name));
			return base.VisitConstructorDeclaration(constructorDeclaration, data);
		}
		finally
		{
			currentlyUsedVariableNames.Clear();
		}
	}

	public override object VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration, object data)
	{
		try
		{
			currentlyUsedVariableNames.AddRange(indexerDeclaration.Parameters.Select((ParameterDeclaration p) => p.Name));
			return base.VisitIndexerDeclaration(indexerDeclaration, data);
		}
		finally
		{
			currentlyUsedVariableNames.Clear();
		}
	}

	public override object VisitAccessor(Accessor accessor, object data)
	{
		try
		{
			currentlyUsedVariableNames.Add("value");
			return base.VisitAccessor(accessor, data);
		}
		finally
		{
			currentlyUsedVariableNames.RemoveAt(currentlyUsedVariableNames.Count - 1);
		}
	}

	public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
	{
		foreach (VariableInitializer variable in variableDeclarationStatement.Variables)
		{
			currentlyUsedVariableNames.Add(variable.Name);
		}
		return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
	}

	public override object VisitFixedStatement(FixedStatement fixedStatement, object data)
	{
		foreach (VariableInitializer variable in fixedStatement.Variables)
		{
			currentlyUsedVariableNames.Add(variable.Name);
		}
		return base.VisitFixedStatement(fixedStatement, data);
	}

	public override object VisitBlockStatement(BlockStatement blockStatement, object data)
	{
		int count = currentlyUsedVariableNames.Count;
		base.VisitBlockStatement(blockStatement, data);
		ExpressionStatement[] array = blockStatement.Statements.OfType<ExpressionStatement>().ToArray();
		foreach (ExpressionStatement expressionStatement in array)
		{
			Match match = displayClassAssignmentPattern.Match(expressionStatement);
			if (!match.Success)
			{
				continue;
			}
			ILVariable iLVariable = match.Get<AstNode>("variable").Single().Annotation<ILVariable>();
			if (iLVariable == null)
			{
				continue;
			}
			TypeDef typeDef = iLVariable.Type.ToTypeDefOrRef().ResolveWithinSameModule();
			if (!IsPotentialClosure(context, typeDef) || match.Get<AstType>("type").Single().Annotation<ITypeDefOrRef>()
				.ResolveWithinSameModule() != typeDef)
			{
				continue;
			}
			bool flag = true;
			INode node = null;
			foreach (IdentifierExpression item in blockStatement.Descendants.OfType<IdentifierExpression>())
			{
				if (!(item.Identifier == iLVariable.Name) || item == (node ?? (node = match.Get("variable").Single())))
				{
					continue;
				}
				if (item.Parent is MemberReferenceExpression)
				{
					IField field = item.Parent.Annotation<IField>();
					if (field != null && field.IsField)
					{
						continue;
					}
				}
				flag = false;
				break;
			}
			if (!flag)
			{
				continue;
			}
			Dictionary<IField, AstNode> dictionary = new Dictionary<IField, AstNode>();
			PatternStatementTransform.FindVariableDeclaration(expressionStatement, iLVariable.Name)?.Remove();
			AstNode astNode = expressionStatement.NextSibling;
			expressionStatement.Remove();
			BlockStatement blockStatement2 = blockStatement.Ancestors.OfType<BlockStatement>().LastOrDefault() ?? blockStatement;
			List<ILVariable> source = (from n in blockStatement2.Descendants.OfType<IdentifierExpression>()
				select n.Annotation<ILVariable>() into p
				where p?.IsParameter ?? false
				select p).ToList();
			FieldDef fieldDef = null;
			while (astNode != null)
			{
				AstNode nextSibling = astNode.NextSibling;
				ExpressionStatement pattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("left", new MemberReferenceExpression
				{
					Target = IdentifierExpression.Create(iLVariable.Name, iLVariable.IsParameter ? BoxedTextColor.Parameter : BoxedTextColor.Local),
					MemberName = Pattern.AnyString
				}), new AnyNode("right")));
				Match match2 = pattern.Match(astNode);
				if (!match2.Success)
				{
					break;
				}
				MemberReferenceExpression memberReferenceExpression = match2.Get<MemberReferenceExpression>("left").Single();
				FieldDef fieldDef2 = memberReferenceExpression.Annotation<IField>().ResolveFieldWithinSameModule();
				AstNode astNode2 = match2.Get<AstNode>("right").Single();
				bool flag2 = false;
				bool flag3 = false;
				if (astNode2 is ThisReferenceExpression)
				{
					flag2 = true;
					fieldDef = fieldDef2;
				}
				else if (astNode2 is IdentifierExpression)
				{
					ILVariable v = astNode2.Annotation<ILVariable>();
					flag2 = v.IsParameter && source.Count((ILVariable c) => c == v) == 1;
					if (!flag2 && IsPotentialClosure(context, v.Type.ToTypeDefOrRef().ResolveWithinSameModule()))
					{
						flag3 = true;
					}
				}
				else if (astNode2 is MemberReferenceExpression)
				{
					MemberReferenceExpression memberReferenceExpression2 = match2.Get<MemberReferenceExpression>("right").Single();
					do
					{
						FieldDef fieldDef3 = memberReferenceExpression2.Annotation<FieldDef>().ResolveFieldWithinSameModule();
						if (fieldDef3 == null || !IsPotentialClosure(context, fieldDef3.FieldType.ToTypeDefOrRef().ResolveWithinSameModule()))
						{
							break;
						}
						if (memberReferenceExpression2.Target is ThisReferenceExpression)
						{
							flag3 = true;
						}
						memberReferenceExpression2 = memberReferenceExpression2.Target as MemberReferenceExpression;
					}
					while (memberReferenceExpression2 != null);
				}
				if (!(flag2 | flag3))
				{
					break;
				}
				if (fieldDef2 != null)
				{
					dictionary[fieldDef2] = astNode2;
				}
				astNode.Remove();
				astNode = nextSibling;
			}
			List<Tuple<AstType, ILVariable>> list = new List<Tuple<AstType, ILVariable>>();
			foreach (FieldDef field2 in typeDef.Fields)
			{
				if (!field2.IsStatic && !dictionary.ContainsKey(field2))
				{
					string text = field2.Name;
					if (text.StartsWith("$VB$Local_", StringComparison.Ordinal) && text.Length > 10)
					{
						text = text.Substring(10);
					}
					EnsureVariableNameIsAvailable(blockStatement, text);
					currentlyUsedVariableNames.Add(text);
					ILVariable iLVariable2 = new ILVariable(text)
					{
						GeneratedByDecompiler = true,
						Type = field2.FieldType
					};
					list.Add(Tuple.Create(AstBuilder.ConvertType(field2.FieldType, stringBuilder, field2), iLVariable2));
					dictionary[field2] = IdentifierExpression.Create(text, BoxedTextColor.Local).WithAnnotation(iLVariable2);
				}
			}
			foreach (IdentifierExpression item2 in blockStatement.Descendants.OfType<IdentifierExpression>())
			{
				if (!(item2.Identifier == iLVariable.Name))
				{
					continue;
				}
				AstNode parent = item2.Parent;
				FieldDef fieldDef4 = parent.Annotation<IField>().ResolveFieldWithinSameModule();
				if (fieldDef4 == null || !dictionary.TryGetValue(fieldDef4, out var value))
				{
					continue;
				}
				AstNode astNode3 = value.Clone();
				if (context.CalculateILSpans)
				{
					astNode3.RemoveAllILSpansRecursive();
					astNode3.AddAnnotation(parent.GetAllRecursiveILSpans());
				}
				parent.ReplaceWith(astNode3);
				if (fieldDef4 == fieldDef && astNode3.Parent is MemberReferenceExpression { MemberName: "$this", Parent: MemberReferenceExpression parent2 } memberReferenceExpression3)
				{
					Identifier node2 = memberReferenceExpression3.MemberNameToken.Detach();
					memberReferenceExpression3.MemberNameToken = parent2.MemberNameToken.Detach();
					if (context.CalculateILSpans)
					{
						memberReferenceExpression3.AddAnnotation(node2.GetAllRecursiveILSpans());
					}
					parent2.ReplaceWith(memberReferenceExpression3.Detach());
					memberReferenceExpression3.RemoveAnnotations<IField>();
					memberReferenceExpression3.AddAnnotationsFrom(parent2);
				}
			}
			Statement existingItem = blockStatement.Statements.FirstOrDefault();
			foreach (Tuple<AstType, ILVariable> item3 in list)
			{
				VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement(item3.Item2.IsParameter ? BoxedTextColor.Parameter : BoxedTextColor.Local, item3.Item1, item3.Item2.Name);
				variableDeclarationStatement.Variables.Single().AddAnnotation(CapturedVariableAnnotation.Instance);
				variableDeclarationStatement.Variables.Single().AddAnnotation(item3.Item2);
				blockStatement.Statements.InsertBefore(existingItem, variableDeclarationStatement);
			}
		}
		currentlyUsedVariableNames.RemoveRange(count, currentlyUsedVariableNames.Count - count);
		return null;
	}

	private void EnsureVariableNameIsAvailable(AstNode currentNode, string name)
	{
		int num = currentlyUsedVariableNames.IndexOf(name);
		if (num < 0)
		{
			return;
		}
		NameVariables nameVariables = new NameVariables(stringBuilder);
		foreach (string currentlyUsedVariableName in currentlyUsedVariableNames)
		{
			nameVariables.AddExistingName(currentlyUsedVariableName);
		}
		foreach (VariableInitializer item in currentNode.Descendants.OfType<VariableInitializer>())
		{
			nameVariables.AddExistingName(item.Name);
		}
		foreach (ParameterDeclaration item2 in currentNode.Descendants.OfType<ParameterDeclaration>())
		{
			nameVariables.AddExistingName(item2.Name);
		}
		string alternativeName = nameVariables.GetAlternativeName(name);
		currentlyUsedVariableNames[num] = alternativeName;
		AstNode astNode = currentNode.Ancestors.OfType<BlockStatement>().LastOrDefault() ?? currentNode;
		foreach (IdentifierExpression item3 in astNode.Descendants.OfType<IdentifierExpression>())
		{
			if (item3.Identifier == name)
			{
				Identifier identifier = Identifier.Create(alternativeName);
				identifier.AddAnnotationsFrom(item3.IdentifierToken);
				item3.IdentifierToken = identifier;
				ILVariable iLVariable = item3.Annotation<ILVariable>();
				if (iLVariable != null)
				{
					iLVariable.Name = alternativeName;
				}
			}
		}
		foreach (VariableInitializer item4 in astNode.Descendants.OfType<VariableInitializer>())
		{
			if (item4.Name == name)
			{
				Identifier identifier2 = Identifier.Create(alternativeName);
				identifier2.AddAnnotationsFrom(item4.NameToken);
				item4.NameToken = identifier2;
				ILVariable iLVariable2 = item4.Annotation<ILVariable>();
				if (iLVariable2 != null)
				{
					iLVariable2.Name = alternativeName;
				}
			}
		}
	}
}

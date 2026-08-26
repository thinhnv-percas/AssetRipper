using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class DelegateConstruction : ContextTrackingVisitor<object>
	{
		internal sealed class Annotation
		{
			public readonly bool IsVirtual;

			public Annotation(bool isVirtual)
			{
				IsVirtual = isVirtual;
			}
		}

		internal sealed class CapturedVariableAnnotation
		{
		}

		private List<string> currentlyUsedVariableNames = new List<string>();

		private static readonly ExpressionStatement displayClassAssignmentPattern = new ExpressionStatement(new AssignmentExpression(new NamedNode("variable", new IdentifierExpression(Pattern.AnyString)), new ObjectCreateExpression
		{
			Type = new AnyNode("type")
		}));

		public DelegateConstruction(DecompilerContext context)
			: base(context)
		{
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
					MethodReference methodReference = identifierExpression.Annotation<MethodReference>();
					if (methodReference != null)
					{
						if (HandleAnonymousMethod(objectCreateExpression, expression, methodReference))
						{
							return null;
						}
						expression.Remove();
						identifierExpression.Remove();
						if (!annotation.IsVirtual && expression is ThisReferenceExpression && methodReference.DeclaringType.GetElementType() != context.CurrentType)
						{
							expression = new BaseReferenceExpression();
						}
						if (!annotation.IsVirtual && expression is NullReferenceExpression && !methodReference.HasThis)
						{
							bool flag = false;
							TypeReference typeReference = objectCreateExpression.Type.Annotation<TypeReference>();
							if (typeReference != null)
							{
								TypeDefinition typeDefinition = typeReference.Resolve();
								if (typeDefinition != null)
								{
									MethodDefinition methodDefinition = typeDefinition.Methods.FirstOrDefault((MethodDefinition m) => m.Name == "Invoke");
									if (methodDefinition != null)
									{
										flag = (methodDefinition.Parameters.Count + 1 == methodReference.Parameters.Count);
									}
								}
							}
							if (!flag)
							{
								expression = new TypeReferenceExpression
								{
									Type = AstBuilder.ConvertType(methodReference.DeclaringType)
								};
							}
						}
						MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression();
						memberReferenceExpression.Target = expression;
						memberReferenceExpression.MemberName = identifierExpression.Identifier;
						identifierExpression.TypeArguments.MoveTo(memberReferenceExpression.TypeArguments);
						memberReferenceExpression.AddAnnotation(methodReference);
						objectCreateExpression.Arguments.Clear();
						objectCreateExpression.Arguments.Add(memberReferenceExpression);
						return null;
					}
				}
			}
			return base.VisitObjectCreateExpression(objectCreateExpression, data);
		}

		internal static bool IsAnonymousMethod(DecompilerContext context, MethodDefinition method)
		{
			if (method == null || (!method.HasGeneratedName() && !method.Name.Contains("$")))
			{
				return false;
			}
			if (!method.IsCompilerGenerated() && !IsPotentialClosure(context, method.DeclaringType))
			{
				return false;
			}
			return true;
		}

		private bool HandleAnonymousMethod(ObjectCreateExpression objectCreateExpression, Expression target, MethodReference methodRef)
		{
			if (!context.Settings.AnonymousMethods)
			{
				return false;
			}
			if (target != null && !(target is IdentifierExpression) && !(target is ThisReferenceExpression) && !(target is NullReferenceExpression))
			{
				return false;
			}
			MethodDefinition method = methodRef.ResolveWithinSameModule();
			if (!IsAnonymousMethod(context, method))
			{
				return false;
			}
			AnonymousMethodExpression anonymousMethodExpression = new AnonymousMethodExpression();
			anonymousMethodExpression.CopyAnnotationsFrom(objectCreateExpression);
			anonymousMethodExpression.RemoveAnnotations<MethodReference>();
			anonymousMethodExpression.AddAnnotation(method);
			anonymousMethodExpression.Parameters.AddRange(AstBuilder.MakeParameters(method, isLambda: true));
			anonymousMethodExpression.HasParameterList = true;
			foreach (ParameterDeclaration parameter in anonymousMethodExpression.Parameters)
			{
				EnsureVariableNameIsAvailable(objectCreateExpression, parameter.Name);
			}
			DecompilerContext decompilerContext = context.Clone();
			decompilerContext.CurrentMethod = method;
			decompilerContext.CurrentMethodIsAsync = false;
			decompilerContext.ReservedVariableNames.AddRange(currentlyUsedVariableNames);
			BlockStatement blockStatement = AstMethodBodyBuilder.CreateMethodBody(method, decompilerContext, anonymousMethodExpression.Parameters);
			TransformationPipeline.RunTransformationsUntil(blockStatement, (IAstTransform v) => v is DelegateConstruction, decompilerContext);
			blockStatement.AcceptVisitor(this, null);
			bool flag = false;
			if (anonymousMethodExpression.Parameters.All((ParameterDeclaration p) => p.ParameterModifier == ParameterModifier.None))
			{
				flag = (blockStatement.Statements.Count == 1 && blockStatement.Statements.Single() is ReturnStatement);
			}
			if (!flag && method.Parameters.All((ParameterDefinition p) => string.IsNullOrEmpty(p.Name)) && !(from ident in blockStatement.Descendants.OfType<IdentifierExpression>()
				let v = ident.Annotation<ILVariable>()
				where v != null && v.IsParameter && method.Parameters.Contains(v.OriginalParameter)
				select ident).Any())
			{
				anonymousMethodExpression.Parameters.Clear();
				anonymousMethodExpression.HasParameterList = false;
			}
			foreach (AstNode descendant in blockStatement.Descendants)
			{
				if (descendant is ThisReferenceExpression)
				{
					descendant.ReplaceWith(target.Clone());
				}
			}
			Expression expression2;
			if (flag)
			{
				LambdaExpression lambdaExpression = new LambdaExpression();
				lambdaExpression.CopyAnnotationsFrom(anonymousMethodExpression);
				anonymousMethodExpression.Parameters.MoveTo(lambdaExpression.Parameters);
				Expression expression = ((ReturnStatement)blockStatement.Statements.Single()).Expression;
				expression.Remove();
				lambdaExpression.Body = expression;
				expression2 = lambdaExpression;
			}
			else
			{
				anonymousMethodExpression.Body = blockStatement;
				expression2 = anonymousMethodExpression;
			}
			TypeDefinition typeDefinition = objectCreateExpression.Annotation<TypeInformation>()?.ExpectedType?.Resolve();
			if (typeDefinition != null && !typeDefinition.IsDelegate())
			{
				ObjectCreateExpression obj = (ObjectCreateExpression)objectCreateExpression.Clone();
				obj.Arguments.Clear();
				obj.Arguments.Add(expression2);
				expression2 = obj;
			}
			objectCreateExpression.ReplaceWith(expression2);
			return true;
		}

		internal static bool IsPotentialClosure(DecompilerContext context, TypeDefinition potentialDisplayClass)
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
				Expression expression = ExpressionTreeConverter.TryConvert(context, invocationExpression);
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
				currentlyUsedVariableNames.AddRange(from p in methodDeclaration.Parameters
					select p.Name);
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
				currentlyUsedVariableNames.AddRange(from p in operatorDeclaration.Parameters
					select p.Name);
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
				currentlyUsedVariableNames.AddRange(from p in constructorDeclaration.Parameters
					select p.Name);
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
				currentlyUsedVariableNames.AddRange(from p in indexerDeclaration.Parameters
					select p.Name);
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
				TypeDefinition typeDefinition = iLVariable.Type.ResolveWithinSameModule();
				if (!IsPotentialClosure(context, typeDefinition) || match.Get<AstType>("type").Single().Annotation<TypeReference>()
					.ResolveWithinSameModule() != typeDefinition)
				{
					continue;
				}
				bool flag = true;
				foreach (IdentifierExpression item in blockStatement.Descendants.OfType<IdentifierExpression>())
				{
					if (item.Identifier == iLVariable.Name && item != match.Get("variable").Single() && (!(item.Parent is MemberReferenceExpression) || item.Parent.Annotation<FieldReference>() == null))
					{
						flag = false;
					}
				}
				if (!flag)
				{
					continue;
				}
				Dictionary<FieldReference, AstNode> dictionary = new Dictionary<FieldReference, AstNode>();
				PatternStatementTransform.FindVariableDeclaration(expressionStatement, iLVariable.Name)?.Remove();
				AstNode astNode = expressionStatement.NextSibling;
				expressionStatement.Remove();
				List<ILVariable> source = (from n in (blockStatement.Ancestors.OfType<BlockStatement>().LastOrDefault() ?? blockStatement).Descendants.OfType<IdentifierExpression>()
					select n.Annotation<ILVariable>() into p
					where p?.IsParameter ?? false
					select p).ToList();
				while (astNode != null)
				{
					AstNode nextSibling = astNode.NextSibling;
					Match match2 = new ExpressionStatement(new AssignmentExpression(new NamedNode("left", new MemberReferenceExpression
					{
						Target = new IdentifierExpression(iLVariable.Name),
						MemberName = Pattern.AnyString
					}), new AnyNode("right"))).Match(astNode);
					if (!match2.Success)
					{
						break;
					}
					FieldDefinition key = match2.Get<MemberReferenceExpression>("left").Single().Annotation<FieldReference>()
						.ResolveWithinSameModule();
					AstNode astNode2 = match2.Get<AstNode>("right").Single();
					bool flag2 = false;
					bool flag3 = false;
					if (astNode2 is ThisReferenceExpression)
					{
						flag2 = true;
					}
					else if (astNode2 is IdentifierExpression)
					{
						ILVariable v = astNode2.Annotation<ILVariable>();
						flag2 = (v.IsParameter && source.Count((ILVariable c) => c == v) == 1);
						if (!flag2 && IsPotentialClosure(context, v.Type.ResolveWithinSameModule()))
						{
							flag3 = true;
						}
					}
					else if (astNode2 is MemberReferenceExpression)
					{
						MemberReferenceExpression memberReferenceExpression = match2.Get<MemberReferenceExpression>("right").Single();
						do
						{
							FieldDefinition fieldDefinition = memberReferenceExpression.Annotation<FieldReference>().ResolveWithinSameModule();
							if (fieldDefinition == null || !IsPotentialClosure(context, fieldDefinition.FieldType.ResolveWithinSameModule()))
							{
								break;
							}
							if (memberReferenceExpression.Target is ThisReferenceExpression)
							{
								flag3 = true;
							}
							memberReferenceExpression = (memberReferenceExpression.Target as MemberReferenceExpression);
						}
						while (memberReferenceExpression != null);
					}
					if (!(flag2 | flag3))
					{
						break;
					}
					dictionary[key] = astNode2;
					astNode.Remove();
					astNode = nextSibling;
				}
				List<Tuple<AstType, ILVariable>> list = new List<Tuple<AstType, ILVariable>>();
				foreach (FieldDefinition field in typeDefinition.Fields)
				{
					if (!field.IsStatic && !dictionary.ContainsKey(field))
					{
						string text = field.Name;
						if (text.StartsWith("$VB$Local_", StringComparison.Ordinal) && text.Length > 10)
						{
							text = text.Substring(10);
						}
						EnsureVariableNameIsAvailable(blockStatement, text);
						currentlyUsedVariableNames.Add(text);
						ILVariable iLVariable2 = new ILVariable
						{
							IsGenerated = true,
							Name = text,
							Type = field.FieldType
						};
						list.Add(Tuple.Create(AstBuilder.ConvertType(field.FieldType, field), iLVariable2));
						dictionary[field] = new IdentifierExpression(text).WithAnnotation(iLVariable2);
					}
				}
				foreach (IdentifierExpression item2 in blockStatement.Descendants.OfType<IdentifierExpression>())
				{
					if (item2.Identifier == iLVariable.Name)
					{
						MemberReferenceExpression memberReferenceExpression2 = (MemberReferenceExpression)item2.Parent;
						if (dictionary.TryGetValue(memberReferenceExpression2.Annotation<FieldReference>().ResolveWithinSameModule(), out AstNode value))
						{
							memberReferenceExpression2.ReplaceWith(value.Clone());
						}
					}
				}
				Statement existingItem = blockStatement.Statements.FirstOrDefault();
				foreach (Tuple<AstType, ILVariable> item3 in list)
				{
					VariableDeclarationStatement variableDeclarationStatement = new VariableDeclarationStatement(item3.Item1, item3.Item2.Name);
					variableDeclarationStatement.Variables.Single().AddAnnotation(new CapturedVariableAnnotation());
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
			if (num >= 0)
			{
				NameVariables nameVariables = new NameVariables();
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
						item3.Identifier = alternativeName;
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
						item4.Name = alternativeName;
						ILVariable iLVariable2 = item4.Annotation<ILVariable>();
						if (iLVariable2 != null)
						{
							iLVariable2.Name = alternativeName;
						}
					}
				}
			}
		}
	}
}

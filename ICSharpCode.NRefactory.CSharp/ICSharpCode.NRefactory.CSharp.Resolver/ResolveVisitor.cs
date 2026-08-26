using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ICSharpCode.NRefactory.CSharp.Analysis;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

internal sealed class ResolveVisitor : IAstVisitor<ResolveResult>
{
	internal struct ConversionWithTargetType
	{
		public readonly Conversion Conversion;

		public readonly IType TargetType;

		public ConversionWithTargetType(Conversion conversion, IType targetType)
		{
			Conversion = conversion;
			TargetType = targetType;
		}
	}

	private sealed class AnonymousFunctionConversion : Conversion
	{
		public readonly IType ReturnType;

		public readonly ExplicitlyTypedLambda ExplicitlyTypedLambda;

		public readonly LambdaTypeHypothesis Hypothesis;

		private readonly bool isValid;

		public override bool IsValid => isValid;

		public override bool IsImplicit => true;

		public override bool IsAnonymousFunctionConversion => true;

		public AnonymousFunctionConversion(IType returnType, LambdaTypeHypothesis hypothesis, bool isValid)
		{
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			ReturnType = returnType;
			Hypothesis = hypothesis;
			this.isValid = isValid;
		}

		public AnonymousFunctionConversion(IType returnType, ExplicitlyTypedLambda explicitlyTypedLambda, bool isValid)
		{
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			ReturnType = returnType;
			ExplicitlyTypedLambda = explicitlyTypedLambda;
			this.isValid = isValid;
		}
	}

	private class AnonymousTypeMember
	{
		public readonly Expression Expression;

		public readonly ResolveResult Initializer;

		public AnonymousTypeMember(Expression expression, ResolveResult initializer)
		{
			Expression = expression;
			Initializer = initializer;
		}
	}

	private sealed class ExplicitlyTypedLambda : LambdaBase
	{
		private readonly IList<IParameter> parameters;

		private readonly bool isAnonymousMethod;

		private readonly bool isAsync;

		private CSharpResolver storedContext;

		private ResolveVisitor visitor;

		private AstNode body;

		private ResolveResult bodyRR;

		private IType inferredReturnType;

		private IList<Expression> returnExpressions;

		private IList<ResolveResult> returnValues;

		private bool isValidAsVoidMethod;

		private bool isEndpointUnreachable;

		private IType actualReturnType;

		internal override bool IsUndecided => actualReturnType == null;

		internal override AstNode LambdaExpression => body.Parent;

		internal override AstNode BodyExpression => body;

		public override ResolveResult Body
		{
			get
			{
				if (bodyRR != null)
				{
					return bodyRR;
				}
				if (body is Expression)
				{
					Analyze();
					if (returnValues.Count == 1)
					{
						bodyRR = returnValues[0];
						if (actualReturnType != null)
						{
							IType type = (isAsync ? visitor.UnpackTask(actualReturnType) : actualReturnType);
							if (type.Kind != TypeKind.Void)
							{
								Conversion conversion = storedContext.conversions.ImplicitConversion(bodyRR, type);
								if (!conversion.IsIdentityConversion)
								{
									bodyRR = new ConversionResolveResult(type, bodyRR, conversion, storedContext.CheckForOverflow);
								}
							}
						}
						return bodyRR;
					}
				}
				return bodyRR = visitor.voidResult;
			}
		}

		public override IList<IParameter> Parameters => parameters ?? EmptyList<IParameter>.Instance;

		public override IType ReturnType => actualReturnType ?? SpecialType.UnknownType;

		public override bool IsImplicitlyTyped => false;

		public override bool IsAsync => isAsync;

		public override bool IsAnonymousMethod => isAnonymousMethod;

		public override bool HasParameterList => parameters != null;

		public ExplicitlyTypedLambda(IList<IParameter> parameters, bool isAnonymousMethod, bool isAsync, CSharpResolver storedContext, ResolveVisitor visitor, AstNode body)
		{
			this.parameters = parameters;
			this.isAnonymousMethod = isAnonymousMethod;
			this.isAsync = isAsync;
			this.storedContext = storedContext;
			this.visitor = visitor;
			this.body = body;
			if (visitor.undecidedLambdas == null)
			{
				visitor.undecidedLambdas = new List<LambdaBase>();
			}
			visitor.undecidedLambdas.Add(this);
		}

		private bool Analyze()
		{
			if (inferredReturnType == null)
			{
				visitor.ResetContext(storedContext, delegate
				{
					IResolveVisitorNavigator navigator = visitor.navigator;
					visitor.navigator = new ConstantModeResolveVisitorNavigator(ResolveVisitorNavigationMode.Resolve, navigator);
					visitor.AnalyzeLambda(body, isAsync, out isValidAsVoidMethod, out isEndpointUnreachable, out inferredReturnType, out returnExpressions, out returnValues);
					visitor.navigator = navigator;
				});
				if (inferredReturnType == null)
				{
					throw new InvalidOperationException("AnalyzeLambda() didn't set inferredReturnType");
				}
			}
			return true;
		}

		public override Conversion IsValid(IType[] parameterTypes, IType returnType, CSharpConversions conversions)
		{
			bool isValid = Analyze() && IsValidLambda(isValidAsVoidMethod, isEndpointUnreachable, isAsync, returnValues, returnType, conversions);
			return new AnonymousFunctionConversion(returnType, this, isValid);
		}

		public override IType GetInferredReturnType(IType[] parameterTypes)
		{
			Analyze();
			return inferredReturnType;
		}

		public override string ToString()
		{
			return string.Concat("[ExplicitlyTypedLambda ", LambdaExpression, "]");
		}

		public void ApplyReturnType(ResolveVisitor parentVisitor, IType returnType)
		{
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			if (parentVisitor != visitor)
			{
				throw new InvalidOperationException();
			}
			if (actualReturnType != null)
			{
				if (!actualReturnType.Equals(returnType))
				{
					throw new InvalidOperationException("inconsistent return types for explicitly-typed lambda");
				}
				return;
			}
			actualReturnType = returnType;
			visitor.undecidedLambdas.Remove(this);
			Analyze();
			IType type = (isAsync ? visitor.UnpackTask(returnType) : returnType);
			if (type.Kind != TypeKind.Void || body is BlockStatement)
			{
				for (int i = 0; i < returnExpressions.Count; i++)
				{
					visitor.ProcessConversion(returnExpressions[i], returnValues[i], type);
				}
			}
		}

		internal override void EnforceMerge(ResolveVisitor parentVisitor)
		{
			ApplyReturnType(parentVisitor, SpecialType.UnknownType);
		}
	}

	private sealed class ImplicitlyTypedLambda : LambdaBase
	{
		private readonly LambdaExpression lambda;

		private readonly QuerySelectClause selectClause;

		private readonly CSharpResolver storedContext;

		private readonly CSharpUnresolvedFile unresolvedFile;

		private readonly List<LambdaTypeHypothesis> hypotheses = new List<LambdaTypeHypothesis>();

		internal IList<IParameter> parameters = new List<IParameter>();

		internal IType actualReturnType;

		internal LambdaTypeHypothesis winningHypothesis;

		internal ResolveResult bodyResult;

		internal readonly ResolveVisitor parentVisitor;

		internal override bool IsUndecided => winningHypothesis == null;

		internal override AstNode LambdaExpression
		{
			get
			{
				if (selectClause != null)
				{
					return selectClause.Expression;
				}
				return lambda;
			}
		}

		internal override AstNode BodyExpression
		{
			get
			{
				if (selectClause != null)
				{
					return selectClause.Expression;
				}
				return lambda.Body;
			}
		}

		public override ResolveResult Body => bodyResult;

		public override IList<IParameter> Parameters => parameters;

		public override IType ReturnType => actualReturnType ?? SpecialType.UnknownType;

		public override bool IsImplicitlyTyped => true;

		public override bool IsAnonymousMethod => false;

		public override bool HasParameterList => true;

		public override bool IsAsync
		{
			get
			{
				if (lambda != null)
				{
					return lambda.IsAsync;
				}
				return false;
			}
		}

		private ImplicitlyTypedLambda(ResolveVisitor parentVisitor)
		{
			this.parentVisitor = parentVisitor;
			storedContext = parentVisitor.resolver;
			unresolvedFile = parentVisitor.unresolvedFile;
			bodyResult = parentVisitor.voidResult;
		}

		public ImplicitlyTypedLambda(LambdaExpression lambda, ResolveVisitor parentVisitor)
			: this(parentVisitor)
		{
			this.lambda = lambda;
			foreach (ParameterDeclaration parameter in lambda.Parameters)
			{
				parameters.Add(new DefaultParameter(SpecialType.UnknownType, parameter.Name, null, parentVisitor.MakeRegion(parameter)));
			}
			RegisterUndecidedLambda();
		}

		public ImplicitlyTypedLambda(QuerySelectClause selectClause, IEnumerable<IParameter> parameters, ResolveVisitor parentVisitor)
			: this(parentVisitor)
		{
			this.selectClause = selectClause;
			foreach (IParameter parameter in parameters)
			{
				this.parameters.Add(parameter);
			}
			RegisterUndecidedLambda();
		}

		private void RegisterUndecidedLambda()
		{
			if (parentVisitor.undecidedLambdas == null)
			{
				parentVisitor.undecidedLambdas = new List<LambdaBase>();
			}
			parentVisitor.undecidedLambdas.Add(this);
		}

		public override Conversion IsValid(IType[] parameterTypes, IType returnType, CSharpConversions conversions)
		{
			LambdaTypeHypothesis hypothesis = GetHypothesis(parameterTypes);
			return hypothesis.IsValid(returnType, conversions);
		}

		public override IType GetInferredReturnType(IType[] parameterTypes)
		{
			return GetHypothesis(parameterTypes).inferredReturnType;
		}

		private LambdaTypeHypothesis GetHypothesis(IType[] parameterTypes)
		{
			if (parameterTypes.Length != parameters.Count)
			{
				throw new ArgumentException("Incorrect parameter type count");
			}
			foreach (LambdaTypeHypothesis hypothesis in hypotheses)
			{
				bool flag = true;
				for (int i = 0; i < parameterTypes.Length; i++)
				{
					if (!parameterTypes[i].Equals(hypothesis.parameterTypes[i]))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return hypothesis;
				}
			}
			ResolveVisitor visitor = new ResolveVisitor(storedContext, unresolvedFile);
			LambdaTypeHypothesis lambdaTypeHypothesis = new LambdaTypeHypothesis(this, parameterTypes, visitor, (lambda != null) ? lambda.Parameters : null, storedContext);
			hypotheses.Add(lambdaTypeHypothesis);
			return lambdaTypeHypothesis;
		}

		internal LambdaTypeHypothesis GetAnyHypothesis()
		{
			if (winningHypothesis != null)
			{
				return winningHypothesis;
			}
			if (hypotheses.Count == 0)
			{
				IType[] array = new IType[parameters.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = SpecialType.UnknownType;
				}
				return GetHypothesis(array);
			}
			LambdaTypeHypothesis lambdaTypeHypothesis = hypotheses[0];
			int num = lambdaTypeHypothesis.CountUnknownParameters();
			for (int j = 1; j < hypotheses.Count; j++)
			{
				int num2 = hypotheses[j].CountUnknownParameters();
				if (num2 < num || (num2 == num && hypotheses[j].success && !lambdaTypeHypothesis.success))
				{
					lambdaTypeHypothesis = hypotheses[j];
					num = num2;
				}
			}
			return lambdaTypeHypothesis;
		}

		internal override void EnforceMerge(ResolveVisitor parentVisitor)
		{
			GetAnyHypothesis().MergeInto(parentVisitor, SpecialType.UnknownType);
		}

		public override string ToString()
		{
			return string.Concat("[ImplicitlyTypedLambda ", LambdaExpression, "]");
		}
	}

	private sealed class LambdaTypeHypothesis : IResolveVisitorNavigator
	{
		private readonly ImplicitlyTypedLambda lambda;

		private readonly IParameter[] lambdaParameters;

		internal readonly IType[] parameterTypes;

		private readonly ResolveVisitor visitor;

		private readonly CSharpResolver storedContext;

		internal readonly IType inferredReturnType;

		private IList<Expression> returnExpressions;

		private IList<ResolveResult> returnValues;

		private bool isValidAsVoidMethod;

		private bool isEndpointUnreachable;

		internal bool success;

		public LambdaTypeHypothesis(ImplicitlyTypedLambda lambda, IType[] parameterTypes, ResolveVisitor visitor, ICollection<ParameterDeclaration> parameterDeclarations, CSharpResolver storedContext)
		{
			this.lambda = lambda;
			this.parameterTypes = parameterTypes;
			this.visitor = visitor;
			this.storedContext = storedContext;
			visitor.SetNavigator(this);
			CSharpResolver resolver = visitor.resolver;
			visitor.resolver = visitor.resolver.WithIsWithinLambdaExpression(isWithinLambdaExpression: true);
			lambdaParameters = new IParameter[parameterTypes.Length];
			if (parameterDeclarations != null)
			{
				int num = 0;
				foreach (ParameterDeclaration parameterDeclaration in parameterDeclarations)
				{
					lambdaParameters[num] = new DefaultParameter(parameterTypes[num], parameterDeclaration.Name, null, visitor.MakeRegion(parameterDeclaration));
					visitor.resolver = visitor.resolver.AddVariable(lambdaParameters[num]);
					num++;
					visitor.Scan(parameterDeclaration);
				}
			}
			else
			{
				for (int i = 0; i < parameterTypes.Length; i++)
				{
					IParameter parameter = lambda.Parameters[i];
					lambdaParameters[i] = new DefaultParameter(parameterTypes[i], parameter.Name, null, parameter.Region);
					visitor.resolver = visitor.resolver.AddVariable(lambdaParameters[i]);
				}
			}
			success = true;
			visitor.AnalyzeLambda(lambda.BodyExpression, lambda.IsAsync, out isValidAsVoidMethod, out isEndpointUnreachable, out inferredReturnType, out returnExpressions, out returnValues);
			visitor.resolver = resolver;
		}

		ResolveVisitorNavigationMode IResolveVisitorNavigator.Scan(AstNode node)
		{
			return ResolveVisitorNavigationMode.Resolve;
		}

		void IResolveVisitorNavigator.Resolved(AstNode node, ResolveResult result)
		{
			if (result.IsError)
			{
				success = false;
			}
		}

		void IResolveVisitorNavigator.ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
		{
			success &= conversion.IsValid;
		}

		internal int CountUnknownParameters()
		{
			int num = 0;
			IType[] array = parameterTypes;
			foreach (IType type in array)
			{
				if (type.Kind == TypeKind.Unknown)
				{
					num++;
				}
			}
			return num;
		}

		public Conversion IsValid(IType returnType, CSharpConversions conversions)
		{
			bool isValid = success && IsValidLambda(isValidAsVoidMethod, isEndpointUnreachable, lambda.IsAsync, returnValues, returnType, conversions);
			return new AnonymousFunctionConversion(returnType, this, isValid);
		}

		public void MergeInto(ResolveVisitor parentVisitor, IType returnType)
		{
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			if (parentVisitor != lambda.parentVisitor)
			{
				throw new InvalidOperationException("parent visitor mismatch");
			}
			if (lambda.winningHypothesis == this)
			{
				return;
			}
			if (lambda.winningHypothesis != null)
			{
				throw new InvalidOperationException("Trying to merge conflicting hypotheses");
			}
			lambda.actualReturnType = returnType;
			if (lambda.IsAsync)
			{
				returnType = parentVisitor.UnpackTask(returnType);
			}
			lambda.winningHypothesis = this;
			lambda.parameters = lambdaParameters;
			if (lambda.BodyExpression is Expression && returnValues.Count == 1)
			{
				lambda.bodyResult = returnValues[0];
				if (returnType.Kind != TypeKind.Void)
				{
					Conversion conversion = storedContext.conversions.ImplicitConversion(lambda.bodyResult, returnType);
					if (!conversion.IsIdentityConversion)
					{
						lambda.bodyResult = new ConversionResolveResult(returnType, lambda.bodyResult, conversion, storedContext.CheckForOverflow);
					}
				}
			}
			if (returnType.Kind != TypeKind.Void || lambda.BodyExpression is Statement)
			{
				for (int i = 0; i < returnExpressions.Count; i++)
				{
					visitor.ProcessConversion(returnExpressions[i], returnValues[i], returnType);
				}
			}
			visitor.MergeUndecidedLambdas();
			foreach (KeyValuePair<AstNode, CSharpResolver> item in visitor.resolverBeforeDict)
			{
				parentVisitor.resolverBeforeDict[item.Key] = item.Value;
			}
			foreach (KeyValuePair<AstNode, CSharpResolver> item2 in visitor.resolverAfterDict)
			{
				parentVisitor.resolverAfterDict[item2.Key] = item2.Value;
			}
			foreach (KeyValuePair<AstNode, ResolveResult> item3 in visitor.resolveResultCache)
			{
				parentVisitor.StoreResult(item3.Key, item3.Value);
			}
			parentVisitor.ImportConversions(visitor);
			parentVisitor.undecidedLambdas.Remove(lambda);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[LambdaTypeHypothesis (");
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(parameterTypes[i]);
				stringBuilder.Append(' ');
				stringBuilder.Append(lambda.Parameters[i].Name);
			}
			stringBuilder.Append(") => ");
			stringBuilder.Append(lambda.BodyExpression.ToString());
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}
	}

	private abstract class LambdaBase : LambdaResolveResult
	{
		internal abstract bool IsUndecided { get; }

		internal abstract AstNode LambdaExpression { get; }

		internal abstract AstNode BodyExpression { get; }

		internal abstract void EnforceMerge(ResolveVisitor parentVisitor);

		public override ResolveResult ShallowClone()
		{
			if (IsUndecided)
			{
				throw new NotSupportedException();
			}
			return base.ShallowClone();
		}
	}

	private sealed class AnalyzeLambdaVisitor : DepthFirstAstVisitor
	{
		public bool HasVoidReturnStatements;

		public List<Expression> ReturnExpressions = new List<Expression>();

		public override void VisitReturnStatement(ReturnStatement returnStatement)
		{
			Expression expression = returnStatement.Expression;
			if (expression.IsNull)
			{
				HasVoidReturnStatements = true;
			}
			else
			{
				ReturnExpressions.Add(expression);
			}
		}

		public override void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
		{
		}

		public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
		{
		}
	}

	private class SimpleVariable : IVariable, ISymbol
	{
		private readonly DomRegion region;

		private readonly IType type;

		private readonly string name;

		public SymbolKind SymbolKind => SymbolKind.Variable;

		public string Name => name;

		public DomRegion Region => region;

		public IType Type => type;

		public virtual bool IsConst => false;

		public virtual object ConstantValue => null;

		public SimpleVariable(DomRegion region, IType type, string name)
		{
			this.region = region;
			this.type = type;
			this.name = name;
		}

		public override string ToString()
		{
			return type.ToString() + " " + name + ";";
		}

		public ISymbolReference ToReference()
		{
			return new VariableReference(type.ToTypeReference(), name, region, IsConst, ConstantValue);
		}
	}

	private sealed class SimpleConstant : SimpleVariable
	{
		private readonly object constantValue;

		public override bool IsConst => true;

		public override object ConstantValue => constantValue;

		public SimpleConstant(DomRegion region, IType type, string name, object constantValue)
			: base(region, type, name)
		{
			this.constantValue = constantValue;
		}

		public override string ToString()
		{
			return base.Type.ToString() + " " + base.Name + " = " + new PrimitiveExpression(constantValue).ToString() + ";";
		}
	}

	private sealed class QueryExpressionLambdaConversion : Conversion
	{
		internal readonly IType[] ParameterTypes;

		public override bool IsImplicit => true;

		public override bool IsAnonymousFunctionConversion => true;

		public QueryExpressionLambdaConversion(IType[] parameterTypes)
		{
			ParameterTypes = parameterTypes;
		}
	}

	private sealed class QueryExpressionLambda : LambdaResolveResult
	{
		private readonly IParameter[] parameters;

		private readonly ResolveResult bodyExpression;

		internal IType[] inferredParameterTypes;

		public override IList<IParameter> Parameters => parameters;

		public override bool IsAsync => false;

		public override bool IsImplicitlyTyped => true;

		public override bool IsAnonymousMethod => false;

		public override bool HasParameterList => true;

		public override ResolveResult Body => bodyExpression;

		public override IType ReturnType => bodyExpression.Type;

		public QueryExpressionLambda(int parameterCount, ResolveResult bodyExpression)
		{
			parameters = new IParameter[parameterCount];
			for (int i = 0; i < parameterCount; i++)
			{
				parameters[i] = new DefaultParameter(SpecialType.UnknownType, "x" + i);
			}
			this.bodyExpression = bodyExpression;
		}

		public override Conversion IsValid(IType[] parameterTypes, IType returnType, CSharpConversions conversions)
		{
			if (parameterTypes.Length == parameters.Length)
			{
				inferredParameterTypes = parameterTypes;
				return new QueryExpressionLambdaConversion(parameterTypes);
			}
			return Conversion.None;
		}

		public override IType GetInferredReturnType(IType[] parameterTypes)
		{
			return bodyExpression.Type;
		}

		public override string ToString()
		{
			return string.Format("[QueryExpressionLambda ({0}) => {1}]", string.Join(",", parameters.Select((IParameter p) => p.Name)), bodyExpression);
		}
	}

	private static readonly ResolveResult errorResult = ErrorResolveResult.UnknownError;

	private CSharpResolver resolver;

	private ResolveResult currentQueryResult;

	private readonly CSharpUnresolvedFile unresolvedFile;

	private readonly Dictionary<AstNode, ResolveResult> resolveResultCache = new Dictionary<AstNode, ResolveResult>();

	private readonly Dictionary<AstNode, CSharpResolver> resolverBeforeDict = new Dictionary<AstNode, CSharpResolver>();

	private readonly Dictionary<AstNode, CSharpResolver> resolverAfterDict = new Dictionary<AstNode, CSharpResolver>();

	private readonly Dictionary<Expression, ConversionWithTargetType> conversionDict = new Dictionary<Expression, ConversionWithTargetType>();

	private IResolveVisitorNavigator navigator;

	private bool resolverEnabled;

	private List<LambdaBase> undecidedLambdas;

	internal CancellationToken cancellationToken;

	private static readonly IResolveVisitorNavigator skipAllNavigator = new ConstantModeResolveVisitorNavigator(ResolveVisitorNavigationMode.Skip, null);

	private ResolveResult voidResult => new ResolveResult(resolver.Compilation.FindType(KnownTypeCode.Void));

	public ResolveVisitor(CSharpResolver resolver, CSharpUnresolvedFile unresolvedFile)
	{
		if (resolver == null)
		{
			throw new ArgumentNullException("resolver");
		}
		this.resolver = resolver;
		this.unresolvedFile = unresolvedFile;
		navigator = skipAllNavigator;
	}

	internal void SetNavigator(IResolveVisitorNavigator navigator)
	{
		this.navigator = navigator ?? skipAllNavigator;
	}

	private void ResetContext(CSharpResolver storedContext, Action action)
	{
		bool flag = resolverEnabled;
		CSharpResolver cSharpResolver = resolver;
		ResolveResult resolveResult = currentQueryResult;
		try
		{
			resolverEnabled = false;
			resolver = storedContext;
			currentQueryResult = null;
			action();
		}
		finally
		{
			resolverEnabled = flag;
			resolver = cSharpResolver;
			currentQueryResult = resolveResult;
		}
	}

	public void Scan(AstNode node)
	{
		if (node == null || node.IsNull)
		{
			return;
		}
		NodeType nodeType = node.NodeType;
		if (nodeType == NodeType.Token || nodeType == NodeType.Whitespace)
		{
			return;
		}
		if (resolveResultCache.ContainsKey(node))
		{
			if (resolverAfterDict.TryGetValue(node, out var value))
			{
				resolver = value;
			}
			return;
		}
		switch (navigator.Scan(node))
		{
		case ResolveVisitorNavigationMode.Skip:
			if (!(node is VariableDeclarationStatement) && !(node is SwitchSection))
			{
				StoreCurrentState(node);
				break;
			}
			goto case ResolveVisitorNavigationMode.Scan;
		case ResolveVisitorNavigationMode.Scan:
		{
			bool flag = resolverEnabled;
			CSharpResolver cSharpResolver = resolver;
			resolverEnabled = false;
			StoreCurrentState(node);
			ResolveResult resolveResult = node.AcceptVisitor(this);
			if (resolveResult != null)
			{
				StoreResult(node, resolveResult);
				if (resolver != cSharpResolver)
				{
					resolverAfterDict.Add(node, resolver);
				}
				cancellationToken.ThrowIfCancellationRequested();
			}
			resolverEnabled = flag;
			break;
		}
		case ResolveVisitorNavigationMode.Resolve:
			Resolve(node);
			break;
		default:
			throw new InvalidOperationException("Invalid value for ResolveVisitorNavigationMode");
		}
	}

	internal ResolveResult Resolve(AstNode node)
	{
		if (node == null || node.IsNull)
		{
			return errorResult;
		}
		bool flag = resolverEnabled;
		resolverEnabled = true;
		if (!resolveResultCache.TryGetValue(node, out var value))
		{
			cancellationToken.ThrowIfCancellationRequested();
			StoreCurrentState(node);
			CSharpResolver cSharpResolver = resolver;
			value = node.AcceptVisitor(this) ?? errorResult;
			StoreResult(node, value);
			if (resolver != cSharpResolver)
			{
				resolverAfterDict.Add(node, resolver);
			}
		}
		resolverEnabled = flag;
		return value;
	}

	private IType ResolveType(AstType type)
	{
		return Resolve(type).Type;
	}

	private void StoreCurrentState(AstNode node)
	{
		resolverBeforeDict[node] = resolver;
	}

	private void StoreResult(AstNode node, ResolveResult result)
	{
		if (!node.IsNull)
		{
			resolveResultCache[node] = result;
			if (navigator != null)
			{
				navigator.Resolved(node, result);
			}
		}
	}

	private void ScanChildren(AstNode node)
	{
		for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			Scan(astNode);
		}
	}

	private void ProcessConversion(Expression expr, ResolveResult rr, Conversion conversion, IType targetType)
	{
		if (conversion is AnonymousFunctionConversion anonymousFunctionConversion)
		{
			if (anonymousFunctionConversion.Hypothesis != null)
			{
				anonymousFunctionConversion.Hypothesis.MergeInto(this, anonymousFunctionConversion.ReturnType);
			}
			if (anonymousFunctionConversion.ExplicitlyTypedLambda != null)
			{
				anonymousFunctionConversion.ExplicitlyTypedLambda.ApplyReturnType(this, anonymousFunctionConversion.ReturnType);
			}
		}
		if (expr != null && !expr.IsNull && conversion != Conversion.IdentityConversion)
		{
			navigator.ProcessConversion(expr, rr, conversion, targetType);
			conversionDict[expr] = new ConversionWithTargetType(conversion, targetType);
		}
	}

	private void ImportConversions(ResolveVisitor childVisitor)
	{
		foreach (KeyValuePair<Expression, ConversionWithTargetType> item in childVisitor.conversionDict)
		{
			conversionDict.Add(item.Key, item.Value);
			navigator.ProcessConversion(item.Key, resolveResultCache[item.Key], item.Value.Conversion, item.Value.TargetType);
		}
	}

	private void ProcessConversion(Expression expr, ResolveResult rr, IType targetType)
	{
		if (expr != null && !expr.IsNull)
		{
			ProcessConversion(expr, rr, resolver.conversions.ImplicitConversion(rr, targetType), targetType);
		}
	}

	private void ResolveAndProcessConversion(Expression expr, IType targetType)
	{
		if (targetType.Kind == TypeKind.Unknown)
		{
			Scan(expr);
		}
		else
		{
			ProcessConversion(expr, Resolve(expr), targetType);
		}
	}

	private void ProcessConversionResult(Expression expr, ConversionResolveResult rr)
	{
		if (rr != null && !(rr is CastResolveResult))
		{
			ProcessConversion(expr, rr.Input, rr.Conversion, rr.Type);
		}
	}

	private void ProcessConversionResults(IEnumerable<Expression> expr, IEnumerable<ResolveResult> conversionResolveResults)
	{
		using IEnumerator<Expression> enumerator = expr.GetEnumerator();
		using IEnumerator<ResolveResult> enumerator2 = conversionResolveResults.GetEnumerator();
		while (enumerator.MoveNext() && enumerator2.MoveNext())
		{
			ProcessConversionResult(enumerator.Current, enumerator2.Current as ConversionResolveResult);
		}
	}

	private void MarkUnknownNamedArguments(IEnumerable<Expression> arguments)
	{
		foreach (NamedArgumentExpression item in arguments.OfType<NamedArgumentExpression>())
		{
			StoreCurrentState(item);
			StoreResult(item, new NamedArgumentResolveResult(item.Name, resolveResultCache[item.Expression]));
		}
	}

	private void ProcessInvocationResult(Expression target, IEnumerable<Expression> arguments, ResolveResult invocation)
	{
		if (invocation is CSharpInvocationResolveResult || invocation is DynamicInvocationResolveResult)
		{
			int num = 0;
			IList<ResolveResult> arguments2;
			if (invocation is CSharpInvocationResolveResult)
			{
				CSharpInvocationResolveResult cSharpInvocationResolveResult = (CSharpInvocationResolveResult)invocation;
				if (cSharpInvocationResolveResult.IsExtensionMethodInvocation)
				{
					ProcessConversionResult(target, cSharpInvocationResolveResult.Arguments[0] as ConversionResolveResult);
					num = 1;
				}
				arguments2 = cSharpInvocationResolveResult.Arguments;
			}
			else
			{
				arguments2 = ((DynamicInvocationResolveResult)invocation).Arguments;
			}
			{
				foreach (Expression argument in arguments)
				{
					ResolveResult resolveResult = arguments2[num++];
					NamedArgumentExpression namedArgumentExpression = argument as NamedArgumentExpression;
					NamedArgumentResolveResult namedArgumentResolveResult = resolveResult as NamedArgumentResolveResult;
					if (namedArgumentExpression != null && namedArgumentResolveResult != null)
					{
						StoreCurrentState(namedArgumentExpression);
						StoreResult(namedArgumentExpression, namedArgumentResolveResult);
						ProcessConversionResult(namedArgumentExpression.Expression, namedArgumentResolveResult.Argument as ConversionResolveResult);
					}
					else
					{
						ProcessConversionResult(argument, resolveResult as ConversionResolveResult);
					}
				}
				return;
			}
		}
		MarkUnknownNamedArguments(arguments);
	}

	public ResolveResult GetResolveResult(AstNode node)
	{
		MergeUndecidedLambdas();
		if (resolveResultCache.TryGetValue(node, out var value))
		{
			return value;
		}
		CSharpResolver previouslyScannedContext = GetPreviouslyScannedContext(node, out var parent);
		ResetContext(previouslyScannedContext, delegate
		{
			navigator = new NodeListResolveVisitorNavigator(node);
			Scan(parent);
			navigator = skipAllNavigator;
		});
		MergeUndecidedLambdas();
		return resolveResultCache[node];
	}

	private CSharpResolver GetPreviouslyScannedContext(AstNode node, out AstNode parent)
	{
		parent = node;
		CSharpResolver value;
		while (!resolverBeforeDict.TryGetValue(parent, out value))
		{
			AstNode parent2 = parent.Parent;
			if (parent2 == null)
			{
				throw new InvalidOperationException("Could not find a resolver state for any parent of the specified node. Are you trying to resolve a node that is not a descendant of the CSharpAstResolver's root node?");
			}
			if (parent2.NodeType == NodeType.Whitespace)
			{
				return resolver;
			}
			parent = parent2;
		}
		return value;
	}

	public CSharpResolver GetResolverStateBefore(AstNode node)
	{
		MergeUndecidedLambdas();
		if (resolverBeforeDict.TryGetValue(node, out var value))
		{
			return value;
		}
		CSharpResolver previouslyScannedContext = GetPreviouslyScannedContext(node, out var parent);
		ResetContext(previouslyScannedContext, delegate
		{
			navigator = new NodeListResolveVisitorNavigator(new AstNode[1] { node }, scanOnly: true);
			Scan(parent);
			navigator = skipAllNavigator;
		});
		MergeUndecidedLambdas();
		while (node != null)
		{
			if (resolverBeforeDict.TryGetValue(node, out value))
			{
				return value;
			}
			node = node.Parent;
		}
		return null;
	}

	public CSharpResolver GetResolverStateAfter(AstNode node)
	{
		GetResolveResult(node);
		if (resolverAfterDict.TryGetValue(node, out var value))
		{
			return value;
		}
		return GetResolverStateBefore(node);
	}

	public ConversionWithTargetType GetConversionWithTargetType(Expression expr)
	{
		GetResolverStateBefore(expr);
		ResolveParentForConversion(expr);
		if (conversionDict.TryGetValue(expr, out var value))
		{
			return value;
		}
		ResolveResult resolveResult = GetResolveResult(expr);
		return new ConversionWithTargetType(Conversion.IdentityConversion, resolveResult.Type);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitSyntaxTree(SyntaxTree unit)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			if (unresolvedFile != null)
			{
				resolver = resolver.WithCurrentUsingScope(unresolvedFile.RootUsingScope.Resolve(resolver.Compilation));
			}
			else
			{
				TypeSystemConvertVisitor typeSystemConvertVisitor = new TypeSystemConvertVisitor(unit.FileName ?? string.Empty);
				ApplyVisitorToUsings(typeSystemConvertVisitor, unit.Children);
				PushUsingScope(typeSystemConvertVisitor.UnresolvedFile.RootUsingScope);
			}
			ScanChildren(unit);
			return voidResult;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	private void ApplyVisitorToUsings(TypeSystemConvertVisitor visitor, IEnumerable<AstNode> children)
	{
		foreach (AstNode child in children)
		{
			if (child is ExternAliasDeclaration || child is UsingDeclaration || child is UsingAliasDeclaration)
			{
				child.AcceptVisitor(visitor);
			}
		}
	}

	private void PushUsingScope(UsingScope usingScope)
	{
		usingScope.Freeze();
		resolver = resolver.WithCurrentUsingScope(new ResolvedUsingScope(resolver.CurrentTypeResolveContext, usingScope));
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			AstType namespaceName = namespaceDeclaration.NamespaceName;
			AstNode astNode = namespaceDeclaration.FirstChild;
			while (astNode != null && astNode.Role != Roles.LBrace)
			{
				Scan(astNode);
				astNode = astNode.NextSibling;
			}
			if (unresolvedFile != null)
			{
				resolver = resolver.WithCurrentUsingScope(unresolvedFile.GetUsingScope(namespaceDeclaration.StartLocation).Resolve(resolver.Compilation));
			}
			else
			{
				if (resolver.CurrentUsingScope == null)
				{
					PushUsingScope(new UsingScope());
				}
				DomRegion region = namespaceDeclaration.GetRegion();
				List<string> list = namespaceDeclaration.Identifiers.ToList();
				UsingScope usingScope;
				for (int i = 0; i < list.Count - 1; i++)
				{
					usingScope = new UsingScope(resolver.CurrentUsingScope.UnresolvedUsingScope, list[i]);
					usingScope.Region = region;
					PushUsingScope(usingScope);
				}
				usingScope = new UsingScope(resolver.CurrentUsingScope.UnresolvedUsingScope, list.Last());
				usingScope.Region = region;
				TypeSystemConvertVisitor visitor = new TypeSystemConvertVisitor(new CSharpUnresolvedFile(), usingScope);
				ApplyVisitorToUsings(visitor, namespaceDeclaration.Children);
				PushUsingScope(usingScope);
			}
			while (astNode != null)
			{
				Scan(astNode);
				astNode = astNode.NextSibling;
			}
			MergeUndecidedLambdas();
			if (resolver.CurrentUsingScope != null && resolver.CurrentUsingScope.Namespace != null)
			{
				return new NamespaceResolveResult(resolver.CurrentUsingScope.Namespace);
			}
			return null;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	private ResolveResult VisitTypeOrDelegate(AstNode typeDeclaration, string name, int typeParameterCount)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			ITypeDefinition typeDefinition = null;
			if (resolver.CurrentTypeDefinition != null)
			{
				int num = resolver.CurrentTypeDefinition.TypeParameterCount + typeParameterCount;
				foreach (ITypeDefinition nestedType in resolver.CurrentTypeDefinition.NestedTypes)
				{
					if (nestedType.Name == name && nestedType.TypeParameterCount == num)
					{
						typeDefinition = nestedType;
						break;
					}
				}
			}
			else if (resolver.CurrentUsingScope != null)
			{
				typeDefinition = resolver.CurrentUsingScope.Namespace.GetTypeDefinition(name, typeParameterCount);
			}
			if (typeDefinition != null)
			{
				resolver = resolver.WithCurrentTypeDefinition(typeDefinition);
			}
			ScanChildren(typeDeclaration);
			MergeUndecidedLambdas();
			return (typeDefinition != null) ? new TypeResolveResult(typeDefinition) : errorResult;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitTypeDeclaration(TypeDeclaration typeDeclaration)
	{
		return VisitTypeOrDelegate(typeDeclaration, typeDeclaration.Name, typeDeclaration.TypeParameters.Count);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
	{
		return VisitTypeOrDelegate(delegateDeclaration, delegateDeclaration.Name, delegateDeclaration.TypeParameters.Count);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
	{
		return VisitFieldOrEventDeclaration(fieldDeclaration, SymbolKind.Field);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
	{
		return VisitFieldOrEventDeclaration(fixedFieldDeclaration, SymbolKind.Field);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitEventDeclaration(EventDeclaration eventDeclaration)
	{
		return VisitFieldOrEventDeclaration(eventDeclaration, SymbolKind.Event);
	}

	private ResolveResult VisitFieldOrEventDeclaration(EntityDeclaration fieldOrEventDeclaration, SymbolKind symbolKind)
	{
		CSharpResolver cSharpResolver = resolver;
		for (AstNode astNode = fieldOrEventDeclaration.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			if (astNode.Role == Roles.Variable || astNode.Role == FixedFieldDeclaration.VariableRole)
			{
				IMember member;
				if (unresolvedFile != null)
				{
					member = GetMemberFromLocation(astNode);
				}
				else
				{
					string name = ((VariableInitializer)astNode).Name;
					member = AbstractUnresolvedMember.Resolve(resolver.CurrentTypeResolveContext, symbolKind, name);
				}
				resolver = resolver.WithCurrentMember(member);
				Scan(astNode);
				resolver = cSharpResolver;
			}
			else
			{
				Scan(astNode);
			}
		}
		return voidResult;
	}

	private IMember GetMemberFromLocation(AstNode node)
	{
		ITypeDefinition currentTypeDefinition = resolver.CurrentTypeDefinition;
		if (currentTypeDefinition == null)
		{
			return null;
		}
		TextLocation location = TypeSystemConvertVisitor.GetStartLocationAfterAttributes(node);
		return currentTypeDefinition.GetMembers(delegate(IUnresolvedMember m)
		{
			if (m.UnresolvedFile != unresolvedFile)
			{
				return false;
			}
			DomRegion region = m.Region;
			return !region.IsEmpty && region.Begin <= location && region.End > location;
		}, GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers).FirstOrDefault();
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitVariableInitializer(VariableInitializer variableInitializer)
	{
		CSharpResolver cSharpResolver = resolver;
		if (variableInitializer.Parent is VariableDeclarationStatement)
		{
			resolver = resolver.PopLastVariable();
		}
		ArrayInitializerExpression arrayInitializerExpression = variableInitializer.Initializer as ArrayInitializerExpression;
		if (resolverEnabled || arrayInitializerExpression != null)
		{
			ResolveResult resolveResult = errorResult;
			if (variableInitializer.Parent is FieldDeclaration || variableInitializer.Parent is EventDeclaration)
			{
				if (resolver.CurrentMember != null)
				{
					resolveResult = new MemberResolveResult(null, resolver.CurrentMember, isVirtualCall: false);
				}
			}
			else
			{
				string name = variableInitializer.Name;
				foreach (IVariable localVariable in cSharpResolver.LocalVariables)
				{
					if (localVariable.Name == name)
					{
						resolveResult = new LocalResolveResult(localVariable);
						break;
					}
				}
			}
			ArrayType arrayType = resolveResult.Type as ArrayType;
			if (arrayInitializerExpression != null && arrayType != null)
			{
				StoreCurrentState(arrayInitializerExpression);
				List<Expression> list = new List<Expression>();
				int[] array = new int[arrayType.Dimensions];
				UnpackArrayInitializer(list, array, arrayInitializerExpression, 0, resolveNestedInitializersToVoid: true);
				ResolveResult[] array2 = new ResolveResult[list.Count];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = Resolve(list[i]);
				}
				ArrayCreateResolveResult arrayCreateResolveResult = resolver.ResolveArrayCreation(arrayType.ElementType, array, array2);
				StoreResult(arrayInitializerExpression, arrayCreateResolveResult);
				ProcessConversionResults(list, arrayCreateResolveResult.InitializerElements);
			}
			else if (variableInitializer.Parent is FixedStatement)
			{
				ResolveResult resolveResult2 = Resolve(variableInitializer.Initializer);
				PointerType pointerType;
				if (resolveResult2.Type.Kind == TypeKind.Array)
				{
					pointerType = new PointerType(((ArrayType)resolveResult2.Type).ElementType);
				}
				else if (ReflectionHelper.GetTypeCode(resolveResult2.Type) == TypeCode.String)
				{
					pointerType = new PointerType(resolver.Compilation.FindType(KnownTypeCode.Char));
				}
				else
				{
					pointerType = null;
					ProcessConversion(variableInitializer.Initializer, resolveResult2, resolveResult.Type);
				}
				if (pointerType != null)
				{
					Conversion conversion = resolver.conversions.ImplicitConversion(pointerType, resolveResult.Type);
					if (conversion.IsIdentityConversion)
					{
						conversion = Conversion.ImplicitPointerConversion;
					}
					ProcessConversion(variableInitializer.Initializer, resolveResult2, conversion, resolveResult.Type);
				}
			}
			else
			{
				ResolveAndProcessConversion(variableInitializer.Initializer, resolveResult.Type);
			}
			resolver = cSharpResolver;
			return resolveResult;
		}
		Scan(variableInitializer.Initializer);
		resolver = cSharpResolver;
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
	{
		if (resolverEnabled)
		{
			ResolveResult result = errorResult;
			if (resolver.CurrentMember != null)
			{
				result = new MemberResolveResult(null, resolver.CurrentMember, isVirtualCall: false);
			}
			ResolveAndProcessConversion(fixedVariableInitializer.CountExpression, resolver.Compilation.FindType(KnownTypeCode.Int32));
			return result;
		}
		ScanChildren(fixedVariableInitializer);
		return null;
	}

	private ResolveResult VisitMethodMember(EntityDeclaration memberDeclaration)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			IMember member = null;
			if (unresolvedFile != null)
			{
				member = GetMemberFromLocation(memberDeclaration);
			}
			if (member == null)
			{
				SymbolKind symbolKind = memberDeclaration.SymbolKind;
				IList<ITypeReference> parameterTypes = TypeSystemConvertVisitor.GetParameterTypes(memberDeclaration.GetChildrenByRole(Roles.Parameter), InterningProvider.Dummy);
				switch (symbolKind)
				{
				case SymbolKind.Constructor:
				{
					string name = (memberDeclaration.HasModifier(Modifiers.Static) ? ".cctor" : ".ctor");
					member = AbstractUnresolvedMember.Resolve(resolver.CurrentTypeResolveContext, symbolKind, name, null, null, parameterTypes);
					break;
				}
				case SymbolKind.Destructor:
					member = AbstractUnresolvedMember.Resolve(resolver.CurrentTypeResolveContext, symbolKind, "Finalize");
					break;
				default:
				{
					string[] typeParameterNames = (from tp in memberDeclaration.GetChildrenByRole(Roles.TypeParameter)
						select tp.Name).ToArray();
					AstType childByRole = memberDeclaration.GetChildByRole(EntityDeclaration.PrivateImplementationTypeRole);
					ITypeReference explicitInterfaceTypeReference = null;
					if (!childByRole.IsNull)
					{
						explicitInterfaceTypeReference = childByRole.ToTypeReference();
					}
					member = AbstractUnresolvedMember.Resolve(resolver.CurrentTypeResolveContext, symbolKind, memberDeclaration.Name, explicitInterfaceTypeReference, typeParameterNames, parameterTypes);
					break;
				}
				}
			}
			resolver = resolver.WithCurrentMember(member);
			ScanChildren(memberDeclaration);
			if (member != null)
			{
				return new MemberResolveResult(null, member, isVirtualCall: false);
			}
			return errorResult;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitMethodDeclaration(MethodDeclaration methodDeclaration)
	{
		return VisitMethodMember(methodDeclaration);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
	{
		return VisitMethodMember(operatorDeclaration);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
	{
		return VisitMethodMember(constructorDeclaration);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
	{
		return VisitMethodMember(destructorDeclaration);
	}

	private ResolveResult VisitPropertyMember(EntityDeclaration propertyOrIndexerDeclaration)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			IMember member;
			if (unresolvedFile != null)
			{
				member = GetMemberFromLocation(propertyOrIndexerDeclaration);
			}
			else
			{
				string name = propertyOrIndexerDeclaration.Name;
				IList<ITypeReference> parameterTypes = TypeSystemConvertVisitor.GetParameterTypes(propertyOrIndexerDeclaration.GetChildrenByRole(Roles.Parameter), InterningProvider.Dummy);
				AstType childByRole = propertyOrIndexerDeclaration.GetChildByRole(EntityDeclaration.PrivateImplementationTypeRole);
				ITypeReference explicitInterfaceTypeReference = null;
				if (!childByRole.IsNull)
				{
					explicitInterfaceTypeReference = childByRole.ToTypeReference();
				}
				member = AbstractUnresolvedMember.Resolve(resolver.CurrentTypeResolveContext, propertyOrIndexerDeclaration.SymbolKind, name, explicitInterfaceTypeReference, null, parameterTypes);
			}
			resolver = resolver.WithCurrentMember(member);
			CSharpResolver cSharpResolver2 = resolver;
			for (AstNode astNode = propertyOrIndexerDeclaration.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				if (astNode.Role == PropertyDeclaration.GetterRole && member is IProperty)
				{
					resolver = resolver.WithCurrentMember(((IProperty)member).Getter);
					Scan(astNode);
					resolver = cSharpResolver2;
				}
				else if (astNode.Role == PropertyDeclaration.SetterRole && member is IProperty)
				{
					resolver = resolver.WithCurrentMember(((IProperty)member).Setter);
					Scan(astNode);
					resolver = cSharpResolver2;
				}
				else
				{
					Scan(astNode);
				}
			}
			if (member != null)
			{
				return new MemberResolveResult(null, member, isVirtualCall: false);
			}
			return errorResult;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
	{
		return VisitPropertyMember(propertyDeclaration);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
	{
		return VisitPropertyMember(indexerDeclaration);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			IMember member;
			if (unresolvedFile != null)
			{
				member = GetMemberFromLocation(eventDeclaration);
			}
			else
			{
				string name = eventDeclaration.Name;
				AstType privateImplementationType = eventDeclaration.PrivateImplementationType;
				member = ((!privateImplementationType.IsNull) ? AbstractUnresolvedMember.Resolve(resolver.CurrentTypeResolveContext, SymbolKind.Event, name, privateImplementationType.ToTypeReference()) : AbstractUnresolvedMember.Resolve(resolver.CurrentTypeResolveContext, SymbolKind.Event, name));
			}
			resolver = resolver.WithCurrentMember(member);
			CSharpResolver cSharpResolver2 = resolver;
			for (AstNode astNode = eventDeclaration.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				if (astNode.Role == CustomEventDeclaration.AddAccessorRole && member is IEvent)
				{
					resolver = resolver.WithCurrentMember(((IEvent)member).AddAccessor);
					Scan(astNode);
					resolver = cSharpResolver2;
				}
				else if (astNode.Role == CustomEventDeclaration.RemoveAccessorRole && member is IEvent)
				{
					resolver = resolver.WithCurrentMember(((IEvent)member).RemoveAccessor);
					Scan(astNode);
					resolver = cSharpResolver2;
				}
				else
				{
					Scan(astNode);
				}
			}
			if (member != null)
			{
				return new MemberResolveResult(null, member, isVirtualCall: false);
			}
			return errorResult;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
	{
		ScanChildren(parameterDeclaration);
		if (resolverEnabled)
		{
			string name = parameterDeclaration.Name;
			if (parameterDeclaration.Parent is DocumentationReference)
			{
				IType type = ResolveType(parameterDeclaration.Type);
				ParameterModifier parameterModifier = parameterDeclaration.ParameterModifier;
				if ((uint)(parameterModifier - 1) <= 2u)
				{
					type = new ByReferenceType(type);
				}
				return new LocalResolveResult(new DefaultParameter(type, name, null, default(DomRegion), null, isIn: parameterDeclaration.ParameterModifier == ParameterModifier.In, isRef: parameterDeclaration.ParameterModifier == ParameterModifier.Ref, isOut: parameterDeclaration.ParameterModifier == ParameterModifier.Out, isParams: parameterDeclaration.ParameterModifier == ParameterModifier.Params));
			}
			foreach (IParameter item in resolver.LocalVariables.OfType<IParameter>())
			{
				if (item.Name == name)
				{
					return new LocalResolveResult(item);
				}
			}
			IParameterizedMember parameterizedMember = resolver.CurrentMember as IParameterizedMember;
			if (parameterizedMember == null && resolver.CurrentTypeDefinition != null)
			{
				parameterizedMember = resolver.CurrentTypeDefinition.GetDelegateInvokeMethod();
			}
			if (parameterizedMember != null)
			{
				foreach (IParameter parameter in parameterizedMember.Parameters)
				{
					if (parameter.Name == name)
					{
						return new LocalResolveResult(parameter);
					}
				}
			}
			return errorResult;
		}
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
	{
		ScanChildren(typeParameterDeclaration);
		if (resolverEnabled)
		{
			string name = typeParameterDeclaration.Name;
			if (resolver.CurrentMember is IMethod method)
			{
				foreach (ITypeParameter typeParameter in method.TypeParameters)
				{
					if (typeParameter.Name == name)
					{
						return new TypeResolveResult(typeParameter);
					}
				}
			}
			if (resolver.CurrentTypeDefinition != null)
			{
				IList<ITypeParameter> typeParameters = resolver.CurrentTypeDefinition.TypeParameters;
				for (int num = typeParameters.Count - 1; num >= 0; num--)
				{
					if (typeParameters[num].Name == name)
					{
						return new TypeResolveResult(typeParameters[num]);
					}
				}
			}
			return errorResult;
		}
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			foreach (AttributeSection attribute in enumMemberDeclaration.Attributes)
			{
				Scan(attribute);
			}
			IMember member = null;
			if (unresolvedFile != null)
			{
				member = GetMemberFromLocation(enumMemberDeclaration);
			}
			else if (resolver.CurrentTypeDefinition != null)
			{
				string name = enumMemberDeclaration.Name;
				member = resolver.CurrentTypeDefinition.GetFields((IUnresolvedField f) => f.Name == name, GetMemberOptions.IgnoreInheritedMembers).FirstOrDefault();
			}
			resolver = resolver.WithCurrentMember(member);
			if (resolverEnabled && resolver.CurrentTypeDefinition != null)
			{
				ResolveAndProcessConversion(enumMemberDeclaration.Initializer, resolver.CurrentTypeDefinition.EnumUnderlyingType);
				if (resolverEnabled && member != null)
				{
					return new MemberResolveResult(null, member, isVirtualCall: false);
				}
				return errorResult;
			}
			Scan(enumMemberDeclaration.Initializer);
			return null;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitCheckedExpression(CheckedExpression checkedExpression)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			resolver = resolver.WithCheckForOverflow(checkForOverflow: true);
			if (resolverEnabled)
			{
				return Resolve(checkedExpression.Expression);
			}
			ScanChildren(checkedExpression);
			return null;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			resolver = resolver.WithCheckForOverflow(checkForOverflow: false);
			if (resolverEnabled)
			{
				return Resolve(uncheckedExpression.Expression);
			}
			ScanChildren(uncheckedExpression);
			return null;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitCheckedStatement(CheckedStatement checkedStatement)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			resolver = resolver.WithCheckForOverflow(checkForOverflow: true);
			ScanChildren(checkedStatement);
			return voidResult;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
	{
		CSharpResolver cSharpResolver = resolver;
		try
		{
			resolver = resolver.WithCheckForOverflow(checkForOverflow: false);
			ScanChildren(uncheckedStatement);
			return voidResult;
		}
		finally
		{
			resolver = cSharpResolver;
		}
	}

	private static string GetAnonymousTypePropertyName(Expression expr, out Expression resolveExpr)
	{
		if (expr is NamedExpression)
		{
			NamedExpression namedExpression = (NamedExpression)expr;
			resolveExpr = namedExpression.Expression;
			return namedExpression.Name;
		}
		if (expr is MemberReferenceExpression)
		{
			resolveExpr = expr;
			return ((MemberReferenceExpression)expr).MemberName;
		}
		if (expr is IdentifierExpression)
		{
			resolveExpr = expr;
			return ((IdentifierExpression)expr).Identifier;
		}
		resolveExpr = null;
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
	{
		List<IUnresolvedProperty> list = new List<IUnresolvedProperty>();
		List<AnonymousTypeMember> list2 = new List<AnonymousTypeMember>();
		foreach (Expression initializer2 in anonymousTypeCreateExpression.Initializers)
		{
			string anonymousTypePropertyName = GetAnonymousTypePropertyName(initializer2, out var resolveExpr);
			if (resolveExpr != null)
			{
				ResolveResult resolveResult = Resolve(resolveExpr);
				ITypeReference returnType = resolveResult.Type.ToTypeReference();
				DefaultUnresolvedProperty defaultUnresolvedProperty = new DefaultUnresolvedProperty();
				defaultUnresolvedProperty.Name = anonymousTypePropertyName;
				defaultUnresolvedProperty.Accessibility = Accessibility.Public;
				defaultUnresolvedProperty.ReturnType = returnType;
				defaultUnresolvedProperty.Getter = new DefaultUnresolvedMethod
				{
					Name = "get_" + anonymousTypePropertyName,
					Accessibility = Accessibility.Public,
					ReturnType = returnType,
					SymbolKind = SymbolKind.Accessor,
					AccessorOwner = defaultUnresolvedProperty
				};
				list.Add(defaultUnresolvedProperty);
				list2.Add(new AnonymousTypeMember(initializer2, resolveResult));
			}
			else
			{
				Scan(initializer2);
			}
		}
		AnonymousType anonymousType = new AnonymousType(resolver.Compilation, list);
		List<IProperty> list3 = anonymousType.GetProperties().ToList();
		List<ResolveResult> list4 = new List<ResolveResult>();
		for (int i = 0; i < list2.Count; i++)
		{
			ResolveResult resolveResult2 = new MemberResolveResult(new InitializedObjectResolveResult(anonymousType), list3[i]);
			ResolveResult initializer = list2[i].Initializer;
			ResolveResult item = resolver.ResolveAssignment(AssignmentOperatorType.Assign, resolveResult2, initializer);
			if (list2[i].Expression is NamedExpression node)
			{
				StoreCurrentState(node);
				StoreResult(node, resolveResult2);
			}
			list4.Add(item);
		}
		IMethod dummyConstructor = DefaultResolvedMethod.GetDummyConstructor(resolver.Compilation, anonymousType);
		return new InvocationResolveResult(null, dummyConstructor, null, list4);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
	{
		int num = arrayCreateExpression.Arguments.Count;
		IEnumerable<ArraySpecifier> source;
		ResolveResult[] array;
		IEnumerable<Expression> enumerable;
		if (num == 0)
		{
			ArraySpecifier arraySpecifier = arrayCreateExpression.AdditionalArraySpecifiers.FirstOrDefault();
			if (arraySpecifier != null)
			{
				num = arraySpecifier.Dimensions;
				source = arrayCreateExpression.AdditionalArraySpecifiers.Skip(1);
			}
			else
			{
				num = 1;
				source = arrayCreateExpression.AdditionalArraySpecifiers;
			}
			array = null;
			enumerable = null;
		}
		else
		{
			enumerable = arrayCreateExpression.Arguments;
			array = new ResolveResult[num];
			int num2 = 0;
			foreach (Expression item in enumerable)
			{
				array[num2++] = Resolve(item);
			}
			source = arrayCreateExpression.AdditionalArraySpecifiers;
		}
		int[] array2;
		List<Expression> list;
		ResolveResult[] array3;
		if (arrayCreateExpression.Initializer.IsNull)
		{
			array2 = null;
			list = null;
			array3 = null;
		}
		else
		{
			StoreCurrentState(arrayCreateExpression.Initializer);
			list = new List<Expression>();
			array2 = new int[num];
			UnpackArrayInitializer(list, array2, arrayCreateExpression.Initializer, 0, resolveNestedInitializersToVoid: true);
			array3 = new ResolveResult[list.Count];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = Resolve(list[i]);
			}
			StoreResult(arrayCreateExpression.Initializer, voidResult);
		}
		IType type;
		if (arrayCreateExpression.Type.IsNull)
		{
			type = null;
		}
		else
		{
			type = ResolveType(arrayCreateExpression.Type);
			foreach (ArraySpecifier item2 in source.Reverse())
			{
				type = new ArrayType(resolver.Compilation, type, item2.Dimensions);
			}
		}
		ArrayCreateResolveResult arrayCreateResolveResult;
		if (array != null)
		{
			arrayCreateResolveResult = resolver.ResolveArrayCreation(type, array, array3);
		}
		else
		{
			if (array2 == null)
			{
				return new ErrorResolveResult(new ArrayType(resolver.Compilation, type ?? SpecialType.UnknownType, num));
			}
			arrayCreateResolveResult = resolver.ResolveArrayCreation(type, array2, array3);
		}
		if (enumerable != null)
		{
			ProcessConversionResults(enumerable, arrayCreateResolveResult.SizeArguments);
		}
		if (arrayCreateResolveResult.InitializerElements != null)
		{
			ProcessConversionResults(list, arrayCreateResolveResult.InitializerElements);
		}
		return arrayCreateResolveResult;
	}

	private void UnpackArrayInitializer(List<Expression> elementList, int[] sizes, ArrayInitializerExpression initializer, int dimension, bool resolveNestedInitializersToVoid)
	{
		int num = 0;
		if (dimension + 1 < sizes.Length)
		{
			foreach (Expression element in initializer.Elements)
			{
				if (element is ArrayInitializerExpression arrayInitializerExpression)
				{
					if (resolveNestedInitializersToVoid)
					{
						StoreCurrentState(arrayInitializerExpression);
						StoreResult(arrayInitializerExpression, voidResult);
					}
					UnpackArrayInitializer(elementList, sizes, arrayInitializerExpression, dimension + 1, resolveNestedInitializersToVoid);
				}
				else
				{
					elementList.Add(element);
				}
				num++;
			}
		}
		else
		{
			foreach (Expression element2 in initializer.Elements)
			{
				elementList.Add(element2);
				num++;
			}
		}
		if (sizes[dimension] == 0)
		{
			sizes[dimension] = num;
		}
		else if (sizes[dimension] != num)
		{
			sizes[dimension] = -1;
		}
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
	{
		ScanChildren(arrayInitializerExpression);
		return errorResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitAsExpression(AsExpression asExpression)
	{
		if (resolverEnabled)
		{
			ResolveResult input = Resolve(asExpression.Expression);
			IType targetType = ResolveType(asExpression.Type);
			return new CastResolveResult(targetType, input, Conversion.TryCast, resolver.CheckForOverflow);
		}
		ScanChildren(asExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitAssignmentExpression(AssignmentExpression assignmentExpression)
	{
		if (resolverEnabled)
		{
			Expression left = assignmentExpression.Left;
			Expression right = assignmentExpression.Right;
			ResolveResult lhs = Resolve(left);
			ResolveResult rhs = Resolve(right);
			ResolveResult resolveResult = resolver.ResolveAssignment(assignmentExpression.Operator, lhs, rhs);
			ProcessConversionsInBinaryOperatorResult(left, right, resolveResult);
			return resolveResult;
		}
		ScanChildren(assignmentExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
	{
		if (resolverEnabled)
		{
			return resolver.ResolveBaseReference();
		}
		ScanChildren(baseReferenceExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
	{
		if (resolverEnabled)
		{
			Expression left = binaryOperatorExpression.Left;
			Expression right = binaryOperatorExpression.Right;
			ResolveResult lhs = Resolve(left);
			ResolveResult rhs = Resolve(right);
			ResolveResult resolveResult = resolver.ResolveBinaryOperator(binaryOperatorExpression.Operator, lhs, rhs);
			ProcessConversionsInBinaryOperatorResult(left, right, resolveResult);
			return resolveResult;
		}
		ScanChildren(binaryOperatorExpression);
		return null;
	}

	private ResolveResult ProcessConversionsInBinaryOperatorResult(Expression left, Expression right, ResolveResult rr)
	{
		if (rr is OperatorResolveResult operatorResolveResult && operatorResolveResult.Operands.Count == 2)
		{
			ProcessConversionResult(left, operatorResolveResult.Operands[0] as ConversionResolveResult);
			ProcessConversionResult(right, operatorResolveResult.Operands[1] as ConversionResolveResult);
		}
		else if (rr is InvocationResolveResult invocationResolveResult && invocationResolveResult.Arguments.Count == 2)
		{
			ProcessConversionResult(left, invocationResolveResult.Arguments[0] as ConversionResolveResult);
			ProcessConversionResult(right, invocationResolveResult.Arguments[1] as ConversionResolveResult);
		}
		return rr;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitCastExpression(CastExpression castExpression)
	{
		if (resolverEnabled)
		{
			IType targetType = ResolveType(castExpression.Type);
			Expression expression = castExpression.Expression;
			ResolveResult resolveResult = resolver.ResolveCast(targetType, Resolve(expression));
			if (resolveResult is ConversionResolveResult conversionResolveResult)
			{
				ProcessConversion(expression, conversionResolveResult.Input, conversionResolveResult.Conversion, targetType);
				resolveResult = new CastResolveResult(conversionResolveResult);
			}
			return resolveResult;
		}
		ScanChildren(castExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitConditionalExpression(ConditionalExpression conditionalExpression)
	{
		if (resolverEnabled)
		{
			Expression condition = conditionalExpression.Condition;
			Expression trueExpression = conditionalExpression.TrueExpression;
			Expression falseExpression = conditionalExpression.FalseExpression;
			ResolveResult resolveResult = resolver.ResolveConditional(Resolve(condition), Resolve(trueExpression), Resolve(falseExpression));
			if (resolveResult is OperatorResolveResult operatorResolveResult && operatorResolveResult.Operands.Count == 3)
			{
				ProcessConversionResult(condition, operatorResolveResult.Operands[0] as ConversionResolveResult);
				ProcessConversionResult(trueExpression, operatorResolveResult.Operands[1] as ConversionResolveResult);
				ProcessConversionResult(falseExpression, operatorResolveResult.Operands[2] as ConversionResolveResult);
			}
			return resolveResult;
		}
		ScanChildren(conditionalExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
	{
		if (resolverEnabled)
		{
			return resolver.ResolveDefaultValue(ResolveType(defaultValueExpression.Type));
		}
		ScanChildren(defaultValueExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitDirectionExpression(DirectionExpression directionExpression)
	{
		if (resolverEnabled)
		{
			ResolveResult elementResult = Resolve(directionExpression.Expression);
			return new ByReferenceResolveResult(elementResult, directionExpression.FieldDirection == FieldDirection.In, directionExpression.FieldDirection == FieldDirection.Ref, directionExpression.FieldDirection == FieldDirection.Out);
		}
		ScanChildren(directionExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitIndexerExpression(IndexerExpression indexerExpression)
	{
		if (resolverEnabled || NeedsResolvingDueToNamedArguments(indexerExpression))
		{
			Expression target = indexerExpression.Target;
			ResolveResult target2 = Resolve(target);
			ResolveResult[] arguments = GetArguments(indexerExpression.Arguments, out var argumentNames);
			ResolveResult resolveResult = resolver.ResolveIndexer(target2, arguments, argumentNames);
			if (resolveResult is ArrayAccessResolveResult arrayAccessResolveResult)
			{
				MarkUnknownNamedArguments(indexerExpression.Arguments);
				ProcessConversionResults(indexerExpression.Arguments, arrayAccessResolveResult.Indexes);
			}
			else
			{
				ProcessInvocationResult(target, indexerExpression.Arguments, resolveResult);
			}
			return resolveResult;
		}
		ScanChildren(indexerExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitIsExpression(IsExpression isExpression)
	{
		if (resolverEnabled)
		{
			ResolveResult input = Resolve(isExpression.Expression);
			IType targetType = ResolveType(isExpression.Type);
			IType booleanType = resolver.Compilation.FindType(KnownTypeCode.Boolean);
			return new TypeIsResolveResult(input, targetType, booleanType);
		}
		ScanChildren(isExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
	{
		if (resolverEnabled)
		{
			return new NamedArgumentResolveResult(namedArgumentExpression.Name, Resolve(namedArgumentExpression.Expression));
		}
		Scan(namedArgumentExpression.Expression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitNamedExpression(NamedExpression namedExpression)
	{
		ScanChildren(namedExpression);
		return null;
	}

	private void HandleNamedExpression(NamedExpression namedExpression, List<ResolveResult> initializerStatements)
	{
		StoreCurrentState(namedExpression);
		Expression expression = namedExpression.Expression;
		ResolveResult resolveResult = resolver.ResolveIdentifierInObjectInitializer(namedExpression.Name);
		if (expression is ArrayInitializerExpression)
		{
			HandleObjectInitializer(resolveResult, (ArrayInitializerExpression)expression, initializerStatements);
		}
		else
		{
			ResolveResult rhs = Resolve(expression);
			if (resolver.ResolveAssignment(AssignmentOperatorType.Assign, resolveResult, rhs) is OperatorResolveResult operatorResolveResult)
			{
				ProcessConversionResult(expression, operatorResolveResult.Operands[1] as ConversionResolveResult);
				initializerStatements.Add(operatorResolveResult);
			}
		}
		StoreResult(namedExpression, resolveResult);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
	{
		return resolver.ResolvePrimitive(null);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
	{
		ResolveResult resolveResult = Resolve(objectCreateExpression.Type);
		if (resolveResult.IsError)
		{
			ScanChildren(objectCreateExpression);
			return resolveResult;
		}
		IType type = resolveResult.Type;
		List<ResolveResult> initializerStatements = null;
		ArrayInitializerExpression initializer = objectCreateExpression.Initializer;
		if (!initializer.IsNull)
		{
			initializerStatements = new List<ResolveResult>();
			HandleObjectInitializer(new InitializedObjectResolveResult(type), initializer, initializerStatements);
		}
		ResolveResult[] arguments = GetArguments(objectCreateExpression.Arguments, out var argumentNames);
		ResolveResult resolveResult2 = resolver.ResolveObjectCreation(type, arguments, argumentNames, allowProtectedAccess: false, initializerStatements);
		if (arguments.Length == 1 && resolveResult2.Type.Kind == TypeKind.Delegate)
		{
			MarkUnknownNamedArguments(objectCreateExpression.Arguments);
			if (resolveResult2 is ConversionResolveResult rr)
			{
				if (objectCreateExpression.Arguments.Count == 1)
				{
					ProcessConversionResult(objectCreateExpression.Arguments.Single(), rr);
				}
				return new CastResolveResult(rr);
			}
			return resolveResult2;
		}
		ProcessInvocationResult(null, objectCreateExpression.Arguments, resolveResult2);
		return resolveResult2;
	}

	private void HandleObjectInitializer(ResolveResult initializedObject, ArrayInitializerExpression initializer, List<ResolveResult> initializerStatements)
	{
		StoreCurrentState(initializer);
		resolver = resolver.PushObjectInitializer(initializedObject);
		foreach (Expression element in initializer.Elements)
		{
			if (element is ArrayInitializerExpression arrayInitializerExpression)
			{
				StoreCurrentState(arrayInitializerExpression);
				ResolveResult[] array = new ResolveResult[arrayInitializerExpression.Elements.Count];
				int num = 0;
				foreach (Expression element2 in arrayInitializerExpression.Elements)
				{
					array[num++] = Resolve(element2);
				}
				MemberLookup memberLookup = resolver.CreateMemberLookup();
				ResolveResult resolveResult = memberLookup.Lookup(initializedObject, "Add", EmptyList<IType>.Instance, isInvocation: true);
				if (resolveResult is MethodGroupResolveResult methodGroupResolveResult)
				{
					OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(resolver.Compilation, array, null, allowExtensionMethods: false, allowExpandingParams: false, allowOptionalParameters: false, resolver.CheckForOverflow, resolver.conversions);
					CSharpInvocationResolveResult cSharpInvocationResolveResult = overloadResolution.CreateResolveResult(initializedObject);
					StoreResult(arrayInitializerExpression, cSharpInvocationResolveResult);
					ProcessInvocationResult(null, arrayInitializerExpression.Elements, cSharpInvocationResolveResult);
					initializerStatements.Add(cSharpInvocationResolveResult);
				}
				else
				{
					StoreResult(arrayInitializerExpression, resolveResult);
				}
			}
			else if (element is NamedExpression)
			{
				HandleNamedExpression((NamedExpression)element, initializerStatements);
			}
			else
			{
				Scan(element);
			}
		}
		resolver = resolver.PopObjectInitializer();
		StoreResult(initializer, voidResult);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
	{
		if (resolverEnabled)
		{
			return Resolve(parenthesizedExpression.Expression);
		}
		Scan(parenthesizedExpression.Expression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
	{
		if (resolverEnabled)
		{
			ResolveResult expression = Resolve(pointerReferenceExpression.Target);
			ResolveResult target = resolver.ResolveUnaryOperator(UnaryOperatorType.Dereference, expression);
			List<IType> list = new List<IType>();
			foreach (AstType typeArgument in pointerReferenceExpression.TypeArguments)
			{
				list.Add(ResolveType(typeArgument));
			}
			return resolver.ResolveMemberAccess(target, pointerReferenceExpression.MemberName, list, GetNameLookupMode(pointerReferenceExpression));
		}
		ScanChildren(pointerReferenceExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
	{
		return resolver.ResolvePrimitive(primitiveExpression.Value);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
	{
		return resolver.ResolveSizeOf(ResolveType(sizeOfExpression.Type));
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
	{
		ResolveAndProcessConversion(stackAllocExpression.CountExpression, resolver.Compilation.FindType(KnownTypeCode.Int32));
		return new ResolveResult(new PointerType(ResolveType(stackAllocExpression.Type)));
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
	{
		return resolver.ResolveThisReference();
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitTypeOfExpression(TypeOfExpression typeOfExpression)
	{
		if (resolverEnabled)
		{
			return resolver.ResolveTypeOf(ResolveType(typeOfExpression.Type));
		}
		Scan(typeOfExpression.Type);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
	{
		if (resolverEnabled)
		{
			return Resolve(typeReferenceExpression.Type).ShallowClone();
		}
		Scan(typeReferenceExpression.Type);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
	{
		if (resolverEnabled)
		{
			Expression expression = unaryOperatorExpression.Expression;
			ResolveResult resolveResult = Resolve(expression);
			ITypeDefinition definition = resolveResult.Type.GetDefinition();
			if (resolveResult.IsCompileTimeConstant && expression is PrimitiveExpression && definition != null)
			{
				if (definition.KnownTypeCode == KnownTypeCode.UInt32 && 2147483648u.Equals(resolveResult.ConstantValue))
				{
					return new ConstantResolveResult(resolver.Compilation.FindType(KnownTypeCode.Int32), int.MinValue);
				}
				if (definition.KnownTypeCode == KnownTypeCode.UInt64 && 9223372036854775808uL.Equals(resolveResult.ConstantValue))
				{
					return new ConstantResolveResult(resolver.Compilation.FindType(KnownTypeCode.Int64), long.MinValue);
				}
			}
			ResolveResult resolveResult2 = resolver.ResolveUnaryOperator(unaryOperatorExpression.Operator, resolveResult);
			if (resolveResult2 is OperatorResolveResult operatorResolveResult && operatorResolveResult.Operands.Count == 1)
			{
				ProcessConversionResult(expression, operatorResolveResult.Operands[0] as ConversionResolveResult);
			}
			else if (resolveResult2 is InvocationResolveResult invocationResolveResult && invocationResolveResult.Arguments.Count == 1)
			{
				ProcessConversionResult(expression, invocationResolveResult.Arguments[0] as ConversionResolveResult);
			}
			return resolveResult2;
		}
		ScanChildren(unaryOperatorExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
	{
		ScanChildren(undocumentedExpression);
		return new ResolveResult(undocumentedExpression.UndocumentedExpressionType switch
		{
			UndocumentedExpressionType.ArgListAccess => resolver.Compilation.FindType(typeof(RuntimeArgumentHandle)), 
			UndocumentedExpressionType.ArgList => SpecialType.ArgList, 
			UndocumentedExpressionType.RefValue => (!(undocumentedExpression.Arguments.ElementAtOrDefault(1) is TypeReferenceExpression typeReferenceExpression)) ? SpecialType.UnknownType : ResolveType(typeReferenceExpression.Type), 
			UndocumentedExpressionType.RefType => resolver.Compilation.FindType(KnownTypeCode.Type), 
			UndocumentedExpressionType.MakeRef => resolver.Compilation.FindType(typeof(TypedReference)), 
			_ => throw new InvalidOperationException("Invalid value for UndocumentedExpressionType"), 
		});
	}

	private List<IType> ResolveTypeArguments(IEnumerable<AstType> typeArguments)
	{
		List<IType> list = new List<IType>();
		foreach (AstType typeArgument in typeArguments)
		{
			list.Add(ResolveType(typeArgument));
		}
		return list;
	}

	private ResolveResult[] GetArguments(IEnumerable<Expression> argumentExpressions, out string[] argumentNames)
	{
		argumentNames = null;
		ResolveResult[] array = new ResolveResult[argumentExpressions.Count()];
		int num = 0;
		foreach (Expression argumentExpression in argumentExpressions)
		{
			AstNode node;
			if (argumentExpression is NamedArgumentExpression namedArgumentExpression)
			{
				if (argumentNames == null)
				{
					argumentNames = new string[array.Length];
				}
				argumentNames[num] = namedArgumentExpression.Name;
				node = namedArgumentExpression.Expression;
			}
			else
			{
				node = argumentExpression;
			}
			array[num++] = Resolve(node);
		}
		return array;
	}

	private bool NeedsResolvingDueToNamedArguments(Expression nodeWithArguments)
	{
		for (AstNode astNode = nodeWithArguments.FirstChild; astNode != null; astNode = astNode.NextSibling)
		{
			if (astNode is NamedArgumentExpression)
			{
				return true;
			}
		}
		return false;
	}

	private static NameLookupMode GetNameLookupMode(Expression expr)
	{
		if (expr.Parent is InvocationExpression invocationExpression && invocationExpression.Target == expr)
		{
			return NameLookupMode.InvocationTarget;
		}
		return NameLookupMode.Expression;
	}

	private bool IsStaticResult(ResolveResult rr, ResolveResult invocationRR)
	{
		if (rr is TypeResolveResult)
		{
			return true;
		}
		if (((rr is MethodGroupResolveResult) ? invocationRR : rr) is MemberResolveResult memberResolveResult)
		{
			return memberResolveResult.Member.IsStatic;
		}
		return false;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitIdentifierExpression(IdentifierExpression identifierExpression)
	{
		if (resolverEnabled)
		{
			List<IType> typeArguments = ResolveTypeArguments(identifierExpression.TypeArguments);
			NameLookupMode nameLookupMode = GetNameLookupMode(identifierExpression);
			return resolver.LookupSimpleNameOrTypeName(identifierExpression.Identifier, typeArguments, nameLookupMode);
		}
		ScanChildren(identifierExpression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
	{
		if (memberReferenceExpression.Target is IdentifierExpression identifierExpression && identifierExpression.TypeArguments.Count == 0)
		{
			StoreCurrentState(identifierExpression);
			ResolveResult resolveResult = resolver.ResolveSimpleName(identifierExpression.Identifier, EmptyList<IType>.Instance);
			if (resolver.IsVariableReferenceWithSameType(resolveResult, identifierExpression.Identifier, out var trr))
			{
				ResolveResult resolveResult2 = ResolveMemberReferenceOnGivenTarget(resolveResult, memberReferenceExpression);
				ResolveResult result = (IsStaticResult(resolveResult2, null) ? trr : resolveResult);
				StoreResult(identifierExpression, result);
				return resolveResult2;
			}
			StoreResult(identifierExpression, resolveResult);
			return ResolveMemberReferenceOnGivenTarget(resolveResult, memberReferenceExpression);
		}
		if (resolverEnabled)
		{
			ResolveResult target = Resolve(memberReferenceExpression.Target);
			return ResolveMemberReferenceOnGivenTarget(target, memberReferenceExpression);
		}
		ScanChildren(memberReferenceExpression);
		return null;
	}

	private ResolveResult ResolveMemberReferenceOnGivenTarget(ResolveResult target, MemberReferenceExpression memberReferenceExpression)
	{
		List<IType> typeArguments = ResolveTypeArguments(memberReferenceExpression.TypeArguments);
		return resolver.ResolveMemberAccess(target, memberReferenceExpression.MemberName, typeArguments, GetNameLookupMode(memberReferenceExpression));
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitInvocationExpression(InvocationExpression invocationExpression)
	{
		MemberReferenceExpression memberReferenceExpression = invocationExpression.Target as MemberReferenceExpression;
		IdentifierExpression identifierExpression = ((memberReferenceExpression != null) ? (memberReferenceExpression.Target as IdentifierExpression) : null);
		if (identifierExpression != null && identifierExpression.TypeArguments.Count == 0)
		{
			StoreCurrentState(identifierExpression);
			StoreCurrentState(memberReferenceExpression);
			ResolveResult resolveResult = resolver.ResolveSimpleName(identifierExpression.Identifier, EmptyList<IType>.Instance);
			ResolveResult resolveResult2 = ResolveMemberReferenceOnGivenTarget(resolveResult, memberReferenceExpression);
			StoreResult(memberReferenceExpression, resolveResult2);
			if (resolver.IsVariableReferenceWithSameType(resolveResult, identifierExpression.Identifier, out var trr))
			{
				ResolveResult resolveResult3 = ResolveInvocationOnGivenTarget(resolveResult2, invocationExpression);
				ResolveResult result = (IsStaticResult(resolveResult2, resolveResult3) ? trr : resolveResult);
				StoreResult(identifierExpression, result);
				return resolveResult3;
			}
			StoreResult(identifierExpression, resolveResult);
			return ResolveInvocationOnGivenTarget(resolveResult2, invocationExpression);
		}
		if (resolverEnabled || NeedsResolvingDueToNamedArguments(invocationExpression))
		{
			ResolveResult target = Resolve(invocationExpression.Target);
			return ResolveInvocationOnGivenTarget(target, invocationExpression);
		}
		ScanChildren(invocationExpression);
		return null;
	}

	private ResolveResult ResolveInvocationOnGivenTarget(ResolveResult target, InvocationExpression invocationExpression)
	{
		ResolveResult[] arguments = GetArguments(invocationExpression.Arguments, out var argumentNames);
		ResolveResult resolveResult = resolver.ResolveInvocation(target, arguments, argumentNames);
		ProcessInvocationResult(invocationExpression.Target, invocationExpression.Arguments, resolveResult);
		return resolveResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
	{
		return HandleExplicitlyTypedLambda(anonymousMethodExpression.Parameters, anonymousMethodExpression.Body, isAnonymousMethod: true, anonymousMethodExpression.HasParameterList, anonymousMethodExpression.IsAsync);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitLambdaExpression(LambdaExpression lambdaExpression)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (ParameterDeclaration parameter in lambdaExpression.Parameters)
		{
			flag2 |= parameter.Type.IsNull;
			flag |= !parameter.Type.IsNull;
		}
		if (flag || !flag2)
		{
			return HandleExplicitlyTypedLambda(lambdaExpression.Parameters, lambdaExpression.Body, isAnonymousMethod: false, hasParameterList: true, lambdaExpression.IsAsync);
		}
		return new ImplicitlyTypedLambda(lambdaExpression, this);
	}

	private ExplicitlyTypedLambda HandleExplicitlyTypedLambda(AstNodeCollection<ParameterDeclaration> parameterDeclarations, AstNode body, bool isAnonymousMethod, bool hasParameterList, bool isAsync)
	{
		CSharpResolver cSharpResolver = resolver;
		List<IParameter> list = ((hasParameterList || parameterDeclarations.Any()) ? new List<IParameter>() : null);
		resolver = resolver.WithIsWithinLambdaExpression(isWithinLambdaExpression: true);
		foreach (ParameterDeclaration parameterDeclaration in parameterDeclarations)
		{
			IType type = ResolveType(parameterDeclaration.Type);
			if (parameterDeclaration.ParameterModifier == ParameterModifier.In || parameterDeclaration.ParameterModifier == ParameterModifier.Ref || parameterDeclaration.ParameterModifier == ParameterModifier.Out)
			{
				type = new ByReferenceType(type);
			}
			IParameter parameter = new DefaultParameter(type, parameterDeclaration.Name, null, MakeRegion(parameterDeclaration), null, isIn: parameterDeclaration.ParameterModifier == ParameterModifier.In, isRef: parameterDeclaration.ParameterModifier == ParameterModifier.Ref, isOut: parameterDeclaration.ParameterModifier == ParameterModifier.Out);
			StoreCurrentState(parameterDeclaration);
			StoreResult(parameterDeclaration, new LocalResolveResult(parameter));
			ScanChildren(parameterDeclaration);
			resolver = resolver.AddVariable(parameter);
			list.Add(parameter);
		}
		ExplicitlyTypedLambda result = new ExplicitlyTypedLambda(list, isAnonymousMethod, isAsync, resolver, this, body);
		resolver = cSharpResolver;
		return result;
	}

	private DomRegion MakeRegion(AstNode node)
	{
		if (unresolvedFile != null)
		{
			return new DomRegion(unresolvedFile.FileName, node.StartLocation, node.EndLocation);
		}
		return node.GetRegion();
	}

	private void MergeUndecidedLambdas()
	{
		if (undecidedLambdas == null || undecidedLambdas.Count == 0)
		{
			return;
		}
		while (undecidedLambdas.Count > 0)
		{
			LambdaBase lambdaBase = undecidedLambdas[0];
			if (lambdaBase.LambdaExpression == null)
			{
				undecidedLambdas.Remove(lambdaBase);
				continue;
			}
			ResolveParentForConversion(lambdaBase.LambdaExpression);
			if (lambdaBase.IsUndecided)
			{
				lambdaBase.EnforceMerge(this);
			}
		}
	}

	private void ResolveParentForConversion(AstNode expression)
	{
		AstNode parent = expression.Parent;
		while (ParenthesizedExpression.ActsAsParenthesizedExpression(parent) || CSharpAstResolver.IsUnresolvableNode(parent))
		{
			parent = parent.Parent;
		}
		if (parent != null && resolverBeforeDict.TryGetValue(parent, out var value))
		{
			ResetContext(value, delegate
			{
				Resolve(parent);
			});
		}
	}

	private IType GetTaskType(IType resultType)
	{
		if (resultType.Kind == TypeKind.Unknown)
		{
			return SpecialType.UnknownType;
		}
		if (resultType.Kind == TypeKind.Void)
		{
			return resolver.Compilation.FindType(KnownTypeCode.Task);
		}
		ITypeDefinition definition = resolver.Compilation.FindType(KnownTypeCode.TaskOfT).GetDefinition();
		if (definition != null)
		{
			return new ParameterizedType(definition, new IType[1] { resultType });
		}
		return SpecialType.UnknownType;
	}

	private void AnalyzeLambda(AstNode body, bool isAsync, out bool isValidAsVoidMethod, out bool isEndpointUnreachable, out IType inferredReturnType, out IList<Expression> returnExpressions, out IList<ResolveResult> returnValues)
	{
		isEndpointUnreachable = false;
		if (body is Expression expression)
		{
			isValidAsVoidMethod = ExpressionPermittedAsStatement(expression);
			returnExpressions = new Expression[1] { expression };
			returnValues = new ResolveResult[1] { Resolve(expression) };
			inferredReturnType = returnValues[0].Type;
		}
		else
		{
			Scan(body);
			AnalyzeLambdaVisitor analyzeLambdaVisitor = new AnalyzeLambdaVisitor();
			body.AcceptVisitor(analyzeLambdaVisitor);
			isValidAsVoidMethod = analyzeLambdaVisitor.ReturnExpressions.Count == 0;
			if (analyzeLambdaVisitor.HasVoidReturnStatements)
			{
				returnExpressions = EmptyList<Expression>.Instance;
				returnValues = EmptyList<ResolveResult>.Instance;
				inferredReturnType = resolver.Compilation.FindType(KnownTypeCode.Void);
			}
			else
			{
				returnExpressions = analyzeLambdaVisitor.ReturnExpressions;
				returnValues = new ResolveResult[returnExpressions.Count];
				for (int i = 0; i < returnValues.Count; i++)
				{
					returnValues[i] = resolveResultCache[returnExpressions[i]];
				}
				if ((returnExpressions.Count == 0) & isAsync)
				{
					inferredReturnType = resolver.Compilation.FindType(KnownTypeCode.Task);
					return;
				}
				TypeInference typeInference = new TypeInference(resolver.Compilation, resolver.conversions);
				inferredReturnType = typeInference.GetBestCommonType(returnValues, out var _);
				if (isValidAsVoidMethod && returnExpressions.Count == 0 && body is Statement)
				{
					ReachabilityAnalysis reachabilityAnalysis = ReachabilityAnalysis.Create((Statement)body, (AstNode node, CancellationToken _) => resolveResultCache[node], resolver.CurrentTypeResolveContext, cancellationToken);
					isEndpointUnreachable = !reachabilityAnalysis.IsEndpointReachable((Statement)body);
				}
			}
		}
		if (isAsync)
		{
			inferredReturnType = GetTaskType(inferredReturnType);
		}
	}

	private static bool ExpressionPermittedAsStatement(Expression expr)
	{
		if (expr is UnaryOperatorExpression { Operator: var unaryOperatorType })
		{
			if ((uint)(unaryOperatorType - 5) <= 3u || unaryOperatorType == UnaryOperatorType.Await)
			{
				return true;
			}
			return false;
		}
		if (!(expr is InvocationExpression) && !(expr is ObjectCreateExpression))
		{
			return expr is AssignmentExpression;
		}
		return true;
	}

	private static bool IsValidLambda(bool isValidAsVoidMethod, bool isEndpointUnreachable, bool isAsync, IList<ResolveResult> returnValues, IType returnType, CSharpConversions conversions)
	{
		if (returnType.Kind == TypeKind.Void)
		{
			return isValidAsVoidMethod;
		}
		if (isAsync && TaskType.IsTask(returnType) && returnType.TypeParameterCount == 0)
		{
			return isValidAsVoidMethod;
		}
		if (returnValues.Count == 0)
		{
			return isEndpointUnreachable;
		}
		if (isAsync)
		{
			if (!TaskType.IsTask(returnType) || returnType.TypeParameterCount != 1)
			{
				return false;
			}
			returnType = ((ParameterizedType)returnType).GetTypeArgument(0);
		}
		foreach (ResolveResult returnValue in returnValues)
		{
			if (!conversions.ImplicitConversion(returnValue, returnType).IsValid)
			{
				return false;
			}
		}
		return true;
	}

	private IType UnpackTask(IType type)
	{
		return TaskType.UnpackTask(resolver.Compilation, type);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitForeachStatement(ForeachStatement foreachStatement)
	{
		ICompilation compilation = resolver.Compilation;
		ResolveResult resolveResult = Resolve(foreachStatement.InExpression);
		bool flag = foreachStatement.VariableType.IsVar();
		MemberLookup memberLookup = resolver.CreateMemberLookup();
		ResolveResult resolveResult2 = null;
		IType collectionType;
		IType enumeratorType;
		IType elementType;
		ResolveResult target;
		if (resolveResult.Type.Kind == TypeKind.Array || resolveResult.Type.Kind == TypeKind.Dynamic)
		{
			collectionType = compilation.FindType(KnownTypeCode.IEnumerable);
			enumeratorType = compilation.FindType(KnownTypeCode.IEnumerator);
			if (resolveResult.Type.Kind == TypeKind.Array)
			{
				elementType = ((ArrayType)resolveResult.Type).ElementType;
			}
			else
			{
				IType type;
				if (!flag)
				{
					type = compilation.FindType(KnownTypeCode.Object);
				}
				else
				{
					IType dynamic = SpecialType.Dynamic;
					type = dynamic;
				}
				elementType = type;
			}
			target = resolver.ResolveCast(collectionType, resolveResult);
			target = resolver.ResolveMemberAccess(target, "GetEnumerator", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
			target = resolver.ResolveInvocation(target, new ResolveResult[0]);
		}
		else if (memberLookup.Lookup(resolveResult, "GetEnumerator", EmptyList<IType>.Instance, isInvocation: true) is MethodGroupResolveResult methodGroupResolveResult)
		{
			OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(compilation, new ResolveResult[0], null, allowExtensionMethods: false, allowExpandingParams: false, allowOptionalParameters: false);
			if (overloadResolution.FoundApplicableCandidate && !overloadResolution.IsAmbiguous && !overloadResolution.BestCandidate.IsStatic && overloadResolution.BestCandidate.IsPublic)
			{
				collectionType = resolveResult.Type;
				target = overloadResolution.CreateResolveResult(resolveResult);
				enumeratorType = target.Type;
				resolveResult2 = memberLookup.Lookup(new ResolveResult(enumeratorType), "Current", EmptyList<IType>.Instance, isInvocation: false);
				elementType = resolveResult2.Type;
			}
			else
			{
				CheckForEnumerableInterface(resolveResult, out collectionType, out enumeratorType, out elementType, out target);
			}
		}
		else
		{
			CheckForEnumerableInterface(resolveResult, out collectionType, out enumeratorType, out elementType, out target);
		}
		IMethod moveNextMethod = null;
		if (memberLookup.Lookup(new ResolveResult(enumeratorType), "MoveNext", EmptyList<IType>.Instance, isInvocation: false) is MethodGroupResolveResult methodGroupResolveResult2)
		{
			OverloadResolution overloadResolution2 = methodGroupResolveResult2.PerformOverloadResolution(compilation, new ResolveResult[0], null, allowExtensionMethods: false, allowExpandingParams: false, allowOptionalParameters: false);
			moveNextMethod = overloadResolution2.GetBestCandidateWithSubstitutedTypeArguments() as IMethod;
		}
		if (resolveResult2 == null)
		{
			resolveResult2 = memberLookup.Lookup(new ResolveResult(enumeratorType), "Current", EmptyList<IType>.Instance, isInvocation: false);
		}
		IProperty currentProperty = null;
		if (resolveResult2 is MemberResolveResult)
		{
			currentProperty = ((MemberResolveResult)resolveResult2).Member as IProperty;
		}
		resolver = resolver.PushBlock();
		IVariable variable;
		if (flag)
		{
			StoreCurrentState(foreachStatement.VariableType);
			StoreResult(foreachStatement.VariableType, new TypeResolveResult(elementType));
			variable = MakeVariable(elementType, foreachStatement.VariableNameToken);
		}
		else
		{
			IType type2 = ResolveType(foreachStatement.VariableType);
			variable = MakeVariable(type2, foreachStatement.VariableNameToken);
		}
		StoreCurrentState(foreachStatement.VariableNameToken);
		resolver = resolver.AddVariable(variable);
		StoreResult(foreachStatement.VariableNameToken, new LocalResolveResult(variable));
		Scan(foreachStatement.EmbeddedStatement);
		resolver = resolver.PopBlock();
		return new ForEachResolveResult(target, collectionType, enumeratorType, elementType, variable, currentProperty, moveNextMethod, voidResult.Type);
	}

	private void CheckForEnumerableInterface(ResolveResult expression, out IType collectionType, out IType enumeratorType, out IType elementType, out ResolveResult getEnumeratorInvocation)
	{
		ICompilation compilation = resolver.Compilation;
		elementType = GetElementTypeFromIEnumerable(expression.Type, compilation, allowIEnumerator: false, out var isGeneric);
		if (isGeneric == true)
		{
			ITypeDefinition definition = compilation.FindType(KnownTypeCode.IEnumerableOfT).GetDefinition();
			if (definition != null)
			{
				collectionType = new ParameterizedType(definition, new IType[1] { elementType });
			}
			else
			{
				collectionType = SpecialType.UnknownType;
			}
			ITypeDefinition definition2 = compilation.FindType(KnownTypeCode.IEnumeratorOfT).GetDefinition();
			if (definition2 != null)
			{
				enumeratorType = new ParameterizedType(definition2, new IType[1] { elementType });
			}
			else
			{
				enumeratorType = SpecialType.UnknownType;
			}
		}
		else if (isGeneric == false)
		{
			collectionType = compilation.FindType(KnownTypeCode.IEnumerable);
			enumeratorType = compilation.FindType(KnownTypeCode.IEnumerator);
		}
		else
		{
			collectionType = SpecialType.UnknownType;
			enumeratorType = SpecialType.UnknownType;
		}
		getEnumeratorInvocation = resolver.ResolveCast(collectionType, expression);
		getEnumeratorInvocation = resolver.ResolveMemberAccess(getEnumeratorInvocation, "GetEnumerator", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
		getEnumeratorInvocation = resolver.ResolveInvocation(getEnumeratorInvocation, new ResolveResult[0]);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitBlockStatement(BlockStatement blockStatement)
	{
		resolver = resolver.PushBlock();
		ScanChildren(blockStatement);
		resolver = resolver.PopBlock();
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUsingStatement(UsingStatement usingStatement)
	{
		resolver = resolver.PushBlock();
		if (resolverEnabled)
		{
			for (AstNode astNode = usingStatement.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				if (astNode.Role == UsingStatement.ResourceAcquisitionRole && astNode is Expression)
				{
					ResolveAndProcessConversion((Expression)astNode, resolver.Compilation.FindType(KnownTypeCode.IDisposable));
				}
				else
				{
					Scan(astNode);
				}
			}
		}
		else
		{
			ScanChildren(usingStatement);
		}
		resolver = resolver.PopBlock();
		if (!resolverEnabled)
		{
			return null;
		}
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitFixedStatement(FixedStatement fixedStatement)
	{
		resolver = resolver.PushBlock();
		IType type = ResolveType(fixedStatement.Type);
		foreach (VariableInitializer variable in fixedStatement.Variables)
		{
			resolver = resolver.AddVariable(MakeVariable(type, variable.NameToken));
			Scan(variable);
		}
		Scan(fixedStatement.EmbeddedStatement);
		resolver = resolver.PopBlock();
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitSwitchStatement(SwitchStatement switchStatement)
	{
		resolver = resolver.PushBlock();
		ScanChildren(switchStatement);
		resolver = resolver.PopBlock();
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitCatchClause(CatchClause catchClause)
	{
		resolver = resolver.PushBlock();
		if (string.IsNullOrEmpty(catchClause.VariableName))
		{
			Scan(catchClause.Type);
		}
		else
		{
			StoreCurrentState(catchClause.VariableNameToken);
			IVariable variable = MakeVariable(ResolveType(catchClause.Type), catchClause.VariableNameToken);
			resolver = resolver.AddVariable(variable);
			StoreResult(catchClause.VariableNameToken, new LocalResolveResult(variable));
		}
		Scan(catchClause.Body);
		resolver = resolver.PopBlock();
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
	{
		bool flag = (variableDeclarationStatement.Modifiers & Modifiers.Const) != 0;
		if (!flag && variableDeclarationStatement.Type.IsVar() && variableDeclarationStatement.Variables.Count == 1)
		{
			VariableInitializer variableInitializer = variableDeclarationStatement.Variables.Single();
			StoreCurrentState(variableDeclarationStatement.Type);
			IType type = Resolve(variableInitializer.Initializer).Type;
			StoreResult(variableDeclarationStatement.Type, new TypeResolveResult(type));
			IVariable variable = MakeVariable(type, variableInitializer.NameToken);
			resolver = resolver.AddVariable(variable);
			Scan(variableInitializer);
		}
		else
		{
			IType type2 = ResolveType(variableDeclarationStatement.Type);
			foreach (VariableInitializer variable3 in variableDeclarationStatement.Variables)
			{
				IVariable variable2;
				if (flag)
				{
					ResolveResult expression = Resolve(variable3.Initializer);
					expression = resolver.ResolveCast(type2, expression);
					variable2 = MakeConstant(type2, variable3.NameToken, expression.ConstantValue);
				}
				else
				{
					variable2 = MakeVariable(type2, variable3.NameToken);
				}
				resolver = resolver.AddVariable(variable2);
				Scan(variable3);
			}
		}
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitForStatement(ForStatement forStatement)
	{
		resolver = resolver.PushBlock();
		ResolveResult result = HandleConditionStatement(forStatement);
		resolver = resolver.PopBlock();
		return result;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitIfElseStatement(IfElseStatement ifElseStatement)
	{
		return HandleConditionStatement(ifElseStatement);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitWhileStatement(WhileStatement whileStatement)
	{
		return HandleConditionStatement(whileStatement);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitDoWhileStatement(DoWhileStatement doWhileStatement)
	{
		return HandleConditionStatement(doWhileStatement);
	}

	private ResolveResult HandleConditionStatement(Statement conditionStatement)
	{
		if (resolverEnabled)
		{
			for (AstNode astNode = conditionStatement.FirstChild; astNode != null; astNode = astNode.NextSibling)
			{
				if (astNode.Role == Roles.Condition)
				{
					Expression expression = (Expression)astNode;
					ResolveResult resolveResult = Resolve(expression);
					ResolveResult resolveResult2 = resolver.ResolveCondition(resolveResult);
					if (resolveResult2 != resolveResult)
					{
						ProcessConversionResult(expression, resolveResult2 as ConversionResolveResult);
					}
				}
				else
				{
					Scan(astNode);
				}
			}
			return voidResult;
		}
		ScanChildren(conditionStatement);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitReturnStatement(ReturnStatement returnStatement)
	{
		if (resolverEnabled && !resolver.IsWithinLambdaExpression && resolver.CurrentMember != null)
		{
			IType type = resolver.CurrentMember.ReturnType;
			if (TaskType.IsTask(type))
			{
				EntityDeclaration entityDeclaration = returnStatement.Ancestors.OfType<EntityDeclaration>().FirstOrDefault();
				if (entityDeclaration != null && (entityDeclaration.Modifiers & Modifiers.Async) == Modifiers.Async)
				{
					type = UnpackTask(type);
				}
			}
			ResolveAndProcessConversion(returnStatement.Expression, type);
		}
		else
		{
			Scan(returnStatement.Expression);
		}
		if (!resolverEnabled)
		{
			return null;
		}
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitYieldReturnStatement(YieldReturnStatement yieldStatement)
	{
		if (resolverEnabled && resolver.CurrentMember != null)
		{
			IType returnType = resolver.CurrentMember.ReturnType;
			IType elementTypeFromIEnumerable = GetElementTypeFromIEnumerable(returnType, resolver.Compilation, allowIEnumerator: true, out var _);
			ResolveAndProcessConversion(yieldStatement.Expression, elementTypeFromIEnumerable);
		}
		else
		{
			Scan(yieldStatement.Expression);
		}
		if (!resolverEnabled)
		{
			return null;
		}
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitExpressionStatement(ExpressionStatement expressionStatement)
	{
		ScanChildren(expressionStatement);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitLockStatement(LockStatement lockStatement)
	{
		ScanChildren(lockStatement);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitEmptyStatement(EmptyStatement emptyStatement)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitBreakStatement(BreakStatement breakStatement)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitContinueStatement(ContinueStatement continueStatement)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitThrowStatement(ThrowStatement throwStatement)
	{
		if (resolverEnabled)
		{
			ResolveAndProcessConversion(throwStatement.Expression, resolver.Compilation.FindType(KnownTypeCode.Exception));
			return voidResult;
		}
		Scan(throwStatement.Expression);
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
	{
		ScanChildren(tryCatchStatement);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
	{
		ScanChildren(gotoCaseStatement);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitGotoStatement(GotoStatement gotoStatement)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitLabelStatement(LabelStatement labelStatement)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUnsafeStatement(UnsafeStatement unsafeStatement)
	{
		resolver = resolver.PushBlock();
		ScanChildren(unsafeStatement);
		resolver = resolver.PopBlock();
		return voidResult;
	}

	private IVariable MakeVariable(IType type, Identifier variableName)
	{
		return new SimpleVariable(MakeRegion(variableName), type, variableName.Name);
	}

	private IVariable MakeConstant(IType type, Identifier variableName, object constantValue)
	{
		return new SimpleConstant(MakeRegion(variableName), type, variableName.Name, constantValue);
	}

	private static IType GetElementTypeFromIEnumerable(IType collectionType, ICompilation compilation, bool allowIEnumerator, out bool? isGeneric)
	{
		bool flag = false;
		foreach (IType allBaseType in collectionType.GetAllBaseTypes())
		{
			ITypeDefinition definition = allBaseType.GetDefinition();
			if (definition != null)
			{
				KnownTypeCode knownTypeCode = definition.KnownTypeCode;
				if ((knownTypeCode == KnownTypeCode.IEnumerableOfT || (allowIEnumerator && knownTypeCode == KnownTypeCode.IEnumeratorOfT)) && allBaseType is ParameterizedType parameterizedType)
				{
					isGeneric = true;
					return parameterizedType.GetTypeArgument(0);
				}
				if (knownTypeCode == KnownTypeCode.IEnumerable || (allowIEnumerator && knownTypeCode == KnownTypeCode.IEnumerator))
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			isGeneric = false;
			return compilation.FindType(KnownTypeCode.Object);
		}
		isGeneric = null;
		return SpecialType.UnknownType;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitAttribute(Attribute attribute)
	{
		IType type = ResolveType(attribute.Type);
		IEnumerable<Expression> enumerable = attribute.Arguments.Where((Expression a) => !(a is NamedExpression));
		IEnumerable<NamedExpression> enumerable2 = attribute.Arguments.OfType<NamedExpression>();
		resolver = resolver.PushObjectInitializer(new InitializedObjectResolveResult(type));
		List<ResolveResult> initializerStatements = new List<ResolveResult>();
		foreach (NamedExpression item in enumerable2)
		{
			HandleNamedExpression(item, initializerStatements);
		}
		resolver = resolver.PopObjectInitializer();
		ResolveResult[] arguments = GetArguments(enumerable, out var argumentNames);
		ResolveResult resolveResult = resolver.ResolveObjectCreation(type, arguments, argumentNames, allowProtectedAccess: false, initializerStatements);
		ProcessInvocationResult(null, enumerable, resolveResult);
		return resolveResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitAttributeSection(AttributeSection attributeSection)
	{
		ScanChildren(attributeSection);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUsingDeclaration(UsingDeclaration usingDeclaration)
	{
		ScanChildren(usingDeclaration);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitUsingAliasDeclaration(UsingAliasDeclaration usingDeclaration)
	{
		ScanChildren(usingDeclaration);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
	{
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitPrimitiveType(PrimitiveType primitiveType)
	{
		if (!resolverEnabled)
		{
			return null;
		}
		KnownTypeCode knownTypeCode = primitiveType.KnownTypeCode;
		if (knownTypeCode == KnownTypeCode.None && primitiveType.Parent is Constraint && primitiveType.Role == Roles.BaseType)
		{
			switch (primitiveType.Keyword)
			{
			case "class":
			case "struct":
			case "new":
				return voidResult;
			}
		}
		IType type = resolver.Compilation.FindType(knownTypeCode);
		return new TypeResolveResult(type);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitSimpleType(SimpleType simpleType)
	{
		if (!resolverEnabled)
		{
			ScanChildren(simpleType);
			return null;
		}
		NameLookupMode nameLookupMode = simpleType.GetNameLookupMode();
		List<IType> typeArguments = ResolveTypeArguments(simpleType.TypeArguments);
		Identifier identifierToken = simpleType.IdentifierToken;
		if (string.IsNullOrEmpty(identifierToken.Name))
		{
			return new TypeResolveResult(SpecialType.UnboundTypeArgument);
		}
		ResolveResult resolveResult = resolver.LookupSimpleNameOrTypeName(identifierToken.Name, typeArguments, nameLookupMode);
		if (simpleType.Parent is Attribute && !identifierToken.IsVerbatim)
		{
			ResolveResult resolveResult2 = resolver.LookupSimpleNameOrTypeName(identifierToken.Name + "Attribute", typeArguments, nameLookupMode);
			if (AttributeTypeReference.PreferAttributeTypeWithSuffix(resolveResult.Type, resolveResult2.Type, resolver.Compilation))
			{
				return resolveResult2;
			}
		}
		return resolveResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitMemberType(MemberType memberType)
	{
		NameLookupMode nameLookupMode = memberType.GetNameLookupMode();
		ResolveResult resolveResult;
		if (memberType.IsDoubleColon && memberType.Target is SimpleType)
		{
			SimpleType simpleType = (SimpleType)memberType.Target;
			StoreCurrentState(simpleType);
			resolveResult = resolver.ResolveAlias(simpleType.Identifier);
			StoreResult(simpleType, resolveResult);
		}
		else
		{
			if (!resolverEnabled)
			{
				ScanChildren(memberType);
				return null;
			}
			resolveResult = Resolve(memberType.Target);
		}
		List<IType> typeArguments = ResolveTypeArguments(memberType.TypeArguments);
		Identifier memberNameToken = memberType.MemberNameToken;
		ResolveResult resolveResult2 = resolver.ResolveMemberAccess(resolveResult, memberNameToken.Name, typeArguments, nameLookupMode);
		if (memberType.Parent is Attribute && !memberNameToken.IsVerbatim)
		{
			ResolveResult resolveResult3 = resolver.ResolveMemberAccess(resolveResult, memberNameToken.Name + "Attribute", typeArguments, nameLookupMode);
			if (AttributeTypeReference.PreferAttributeTypeWithSuffix(resolveResult2.Type, resolveResult3.Type, resolver.Compilation))
			{
				return resolveResult3;
			}
		}
		return resolveResult2;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitComposedType(ComposedType composedType)
	{
		if (!resolverEnabled)
		{
			ScanChildren(composedType);
			return null;
		}
		IType type = ResolveType(composedType.BaseType);
		if (composedType.HasNullableSpecifier)
		{
			type = NullableType.Create(resolver.Compilation, type);
		}
		for (int i = 0; i < composedType.PointerRank; i++)
		{
			type = new PointerType(type);
		}
		foreach (ArraySpecifier item in composedType.ArraySpecifiers.Reverse())
		{
			type = new ArrayType(resolver.Compilation, type, item.Dimensions);
		}
		return new TypeResolveResult(type);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryExpression(QueryExpression queryExpression)
	{
		resolver = resolver.PushBlock();
		ResolveResult resolveResult = currentQueryResult;
		CancellationToken cancellationToken = this.cancellationToken;
		try
		{
			this.cancellationToken = CancellationToken.None;
			currentQueryResult = null;
			foreach (QueryClause clause in queryExpression.Clauses)
			{
				currentQueryResult = Resolve(clause);
			}
			return WrapResult(currentQueryResult);
		}
		finally
		{
			currentQueryResult = resolveResult;
			this.cancellationToken = cancellationToken;
			resolver = resolver.PopBlock();
		}
	}

	private IType GetTypeForQueryVariable(IType type)
	{
		IType elementTypeFromIEnumerable = GetElementTypeFromIEnumerable(type, resolver.Compilation, allowIEnumerator: false, out var _);
		if (elementTypeFromIEnumerable.Kind == TypeKind.Unknown)
		{
			ResolveResult target = resolver.ResolveMemberAccess(new ResolveResult(type), "Select", EmptyList<IType>.Instance);
			ResolveResult[] arguments = new ResolveResult[1]
			{
				new QueryExpressionLambda(1, voidResult)
			};
			if (resolver.ResolveInvocation(target, arguments) is CSharpInvocationResolveResult cSharpInvocationResolveResult && cSharpInvocationResolveResult.Arguments.Count == 2)
			{
				IMethod delegateInvokeMethod = cSharpInvocationResolveResult.Arguments[1].Type.GetDelegateInvokeMethod();
				if (delegateInvokeMethod != null && delegateInvokeMethod.Parameters.Count > 0)
				{
					return delegateInvokeMethod.Parameters[0].Type;
				}
			}
		}
		return elementTypeFromIEnumerable;
	}

	private ResolveResult MakeTransparentIdentifierResolveResult()
	{
		return new ResolveResult(new AnonymousType(resolver.Compilation, EmptyList<IUnresolvedProperty>.Instance));
	}

	private QueryClause GetPreviousQueryClause(QueryClause clause)
	{
		for (AstNode prevSibling = clause.PrevSibling; prevSibling != null; prevSibling = prevSibling.PrevSibling)
		{
			if (prevSibling.Role == QueryExpression.ClauseRole)
			{
				return (QueryClause)prevSibling;
			}
		}
		return null;
	}

	private QueryClause GetNextQueryClause(QueryClause clause)
	{
		for (AstNode nextSibling = clause.NextSibling; nextSibling != null; nextSibling = nextSibling.NextSibling)
		{
			if (nextSibling.Role == QueryExpression.ClauseRole)
			{
				return (QueryClause)nextSibling;
			}
		}
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryFromClause(QueryFromClause queryFromClause)
	{
		ResolveResult resolveResult = errorResult;
		ResolveResult resolveResult2 = Resolve(queryFromClause.Expression);
		IVariable variable;
		if (queryFromClause.Type.IsNull)
		{
			variable = MakeVariable(GetTypeForQueryVariable(resolveResult2.Type), queryFromClause.IdentifierToken);
			resolveResult = resolveResult2;
		}
		else
		{
			variable = MakeVariable(ResolveType(queryFromClause.Type), queryFromClause.IdentifierToken);
			ResolveResult target = resolver.ResolveMemberAccess(resolveResult2, "Cast", new IType[1] { variable.Type }, NameLookupMode.InvocationTarget);
			resolveResult = resolver.ResolveInvocation(target, new ResolveResult[0]);
		}
		StoreCurrentState(queryFromClause.IdentifierToken);
		resolver = resolver.AddVariable(variable);
		StoreResult(queryFromClause.IdentifierToken, new LocalResolveResult(variable));
		if (currentQueryResult != null)
		{
			ResolveResult bodyExpression = ((!(GetNextQueryClause(queryFromClause) is QuerySelectClause querySelectClause)) ? MakeTransparentIdentifierResolveResult() : Resolve(querySelectClause.Expression));
			ResolveResult target2 = resolver.ResolveMemberAccess(currentQueryResult, "SelectMany", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
			ResolveResult[] arguments = new ResolveResult[2]
			{
				new QueryExpressionLambda(1, resolveResult),
				new QueryExpressionLambda(2, bodyExpression)
			};
			resolveResult = resolver.ResolveInvocation(target2, arguments);
		}
		if (resolveResult == resolveResult2)
		{
			return WrapResult(resolveResult);
		}
		return resolveResult;
	}

	private ResolveResult WrapResult(ResolveResult result)
	{
		return new CastResolveResult(result.Type, result, Conversion.IdentityConversion, resolver.CheckForOverflow);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
	{
		ResolveResult resolveResult = Resolve(queryContinuationClause.PrecedingQuery);
		IType typeForQueryVariable = GetTypeForQueryVariable(resolveResult.Type);
		StoreCurrentState(queryContinuationClause.IdentifierToken);
		IVariable variable = MakeVariable(typeForQueryVariable, queryContinuationClause.IdentifierToken);
		resolver = resolver.AddVariable(variable);
		StoreResult(queryContinuationClause.IdentifierToken, new LocalResolveResult(variable));
		return WrapResult(resolveResult);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryLetClause(QueryLetClause queryLetClause)
	{
		ResolveResult resolveResult = Resolve(queryLetClause.Expression);
		StoreCurrentState(queryLetClause.IdentifierToken);
		IVariable variable = MakeVariable(resolveResult.Type, queryLetClause.IdentifierToken);
		resolver = resolver.AddVariable(variable);
		StoreResult(queryLetClause.IdentifierToken, new LocalResolveResult(variable));
		if (currentQueryResult != null)
		{
			ResolveResult target = resolver.ResolveMemberAccess(currentQueryResult, "Select", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
			ResolveResult[] arguments = new ResolveResult[1]
			{
				new QueryExpressionLambda(1, MakeTransparentIdentifierResolveResult())
			};
			return resolver.ResolveInvocation(target, arguments);
		}
		return errorResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryJoinClause(QueryJoinClause queryJoinClause)
	{
		ResolveResult resolveResult = null;
		ResolveResult resolveResult2 = Resolve(queryJoinClause.InExpression);
		IType type;
		if (queryJoinClause.Type.IsNull)
		{
			type = GetTypeForQueryVariable(resolveResult2.Type);
			resolveResult = resolveResult2;
		}
		else
		{
			type = ResolveType(queryJoinClause.Type);
			ResolveResult target = resolver.ResolveMemberAccess(resolveResult2, "Cast", new IType[1] { type }, NameLookupMode.InvocationTarget);
			resolveResult = resolver.ResolveInvocation(target, new ResolveResult[0]);
		}
		ResolveResult resolveResult3 = Resolve(queryJoinClause.OnExpression);
		CSharpResolver cSharpResolver = resolver;
		cSharpResolver = cSharpResolver.PopBlock();
		IVariable variable = MakeVariable(type, queryJoinClause.JoinIdentifierToken);
		cSharpResolver = cSharpResolver.AddVariable(variable);
		ResolveResult equalsResult = errorResult;
		ResetContext(cSharpResolver, delegate
		{
			equalsResult = Resolve(queryJoinClause.EqualsExpression);
		});
		StoreCurrentState(queryJoinClause.JoinIdentifierToken);
		StoreResult(queryJoinClause.JoinIdentifierToken, new LocalResolveResult(variable));
		if (queryJoinClause.IsGroupJoin)
		{
			return ResolveGroupJoin(queryJoinClause, resolveResult, resolveResult3, equalsResult);
		}
		resolver = resolver.AddVariable(variable);
		if (currentQueryResult != null)
		{
			ResolveResult bodyExpression = ((!(GetNextQueryClause(queryJoinClause) is QuerySelectClause querySelectClause)) ? MakeTransparentIdentifierResolveResult() : Resolve(querySelectClause.Expression));
			ResolveResult target2 = resolver.ResolveMemberAccess(currentQueryResult, "Join", EmptyList<IType>.Instance);
			ResolveResult[] arguments = new ResolveResult[4]
			{
				resolveResult,
				new QueryExpressionLambda(1, resolveResult3),
				new QueryExpressionLambda(1, equalsResult),
				new QueryExpressionLambda(2, bodyExpression)
			};
			return resolver.ResolveInvocation(target2, arguments);
		}
		return errorResult;
	}

	private ResolveResult ResolveGroupJoin(QueryJoinClause queryJoinClause, ResolveResult inResult, ResolveResult onResult, ResolveResult equalsResult)
	{
		DomRegion region = MakeRegion(queryJoinClause.IntoIdentifierToken);
		ResolveResult target = resolver.ResolveMemberAccess(currentQueryResult, "GroupJoin", EmptyList<IType>.Instance);
		LambdaResolveResult lambdaResolveResult;
		if (GetNextQueryClause(queryJoinClause) is QuerySelectClause selectClause)
		{
			IParameter[] parameters = new IParameter[2]
			{
				new DefaultParameter(SpecialType.UnknownType, "<>transparentIdentifier"),
				new DefaultParameter(SpecialType.UnknownType, queryJoinClause.IntoIdentifier, null, region)
			};
			lambdaResolveResult = new ImplicitlyTypedLambda(selectClause, parameters, this);
		}
		else
		{
			lambdaResolveResult = new QueryExpressionLambda(2, MakeTransparentIdentifierResolveResult());
		}
		ResolveResult[] arguments = new ResolveResult[4]
		{
			inResult,
			new QueryExpressionLambda(1, onResult),
			new QueryExpressionLambda(1, equalsResult),
			lambdaResolveResult
		};
		ResolveResult resolveResult = resolver.ResolveInvocation(target, arguments);
		InvocationResolveResult invocationResolveResult = resolveResult as InvocationResolveResult;
		IVariable variable;
		if (lambdaResolveResult is ImplicitlyTypedLambda)
		{
			ImplicitlyTypedLambda implicitlyTypedLambda = (ImplicitlyTypedLambda)lambdaResolveResult;
			if (invocationResolveResult != null && invocationResolveResult.Arguments.Count > 0 && invocationResolveResult.Arguments[invocationResolveResult.Arguments.Count - 1] is ConversionResolveResult conversionResolveResult)
			{
				ProcessConversion(null, conversionResolveResult.Input, conversionResolveResult.Conversion, conversionResolveResult.Type);
			}
			implicitlyTypedLambda.EnforceMerge(this);
			if (implicitlyTypedLambda.Parameters.Count == 2)
			{
				StoreCurrentState(queryJoinClause.IntoIdentifierToken);
				variable = implicitlyTypedLambda.Parameters[1];
			}
			else
			{
				variable = null;
			}
		}
		else
		{
			IType[] array = null;
			if (invocationResolveResult != null && invocationResolveResult.Arguments.Count > 0 && invocationResolveResult.Arguments[invocationResolveResult.Arguments.Count - 1] is ConversionResolveResult conversionResolveResult2 && conversionResolveResult2.Conversion is QueryExpressionLambdaConversion)
			{
				array = ((QueryExpressionLambdaConversion)conversionResolveResult2.Conversion).ParameterTypes;
			}
			if (array == null)
			{
				array = ((QueryExpressionLambda)lambdaResolveResult).inferredParameterTypes;
			}
			IType type = ((array == null || array.Length != 2) ? SpecialType.UnknownType : array[1]);
			StoreCurrentState(queryJoinClause.IntoIdentifierToken);
			variable = MakeVariable(type, queryJoinClause.IntoIdentifierToken);
			resolver = resolver.AddVariable(variable);
		}
		if (variable != null)
		{
			StoreResult(queryJoinClause.IntoIdentifierToken, new LocalResolveResult(variable));
		}
		return resolveResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryWhereClause(QueryWhereClause queryWhereClause)
	{
		ResolveResult resolveResult = Resolve(queryWhereClause.Condition);
		IType type = resolver.Compilation.FindType(KnownTypeCode.Boolean);
		Conversion conversion = resolver.conversions.ImplicitConversion(resolveResult, type);
		ProcessConversion(queryWhereClause.Condition, resolveResult, conversion, type);
		if (currentQueryResult != null)
		{
			if (conversion != Conversion.IdentityConversion && conversion != Conversion.None)
			{
				resolveResult = new ConversionResolveResult(type, resolveResult, conversion, resolver.CheckForOverflow);
			}
			ResolveResult target = resolver.ResolveMemberAccess(currentQueryResult, "Where", EmptyList<IType>.Instance);
			ResolveResult[] arguments = new ResolveResult[1]
			{
				new QueryExpressionLambda(1, resolveResult)
			};
			return resolver.ResolveInvocation(target, arguments);
		}
		return errorResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQuerySelectClause(QuerySelectClause querySelectClause)
	{
		if (currentQueryResult == null)
		{
			ScanChildren(querySelectClause);
			return errorResult;
		}
		QueryClause previousQueryClause = GetPreviousQueryClause(querySelectClause);
		if ((previousQueryClause is QueryFromClause && GetPreviousQueryClause(previousQueryClause) != null) || previousQueryClause is QueryJoinClause)
		{
			if (!(previousQueryClause is QueryJoinClause) || !((QueryJoinClause)previousQueryClause).IsGroupJoin)
			{
				Scan(querySelectClause.Expression);
			}
			return WrapResult(currentQueryResult);
		}
		QueryExpression queryExpression = querySelectClause.Parent as QueryExpression;
		string singleRangeVariable = GetSingleRangeVariable(queryExpression);
		if (singleRangeVariable != null && ParenthesizedExpression.UnpackParenthesizedExpression(querySelectClause.Expression) is IdentifierExpression identifierExpression && identifierExpression.Identifier == singleRangeVariable && !identifierExpression.TypeArguments.Any() && queryExpression.Clauses.Count > 2)
		{
			Scan(querySelectClause.Expression);
			return WrapResult(currentQueryResult);
		}
		ResolveResult bodyExpression = Resolve(querySelectClause.Expression);
		ResolveResult target = resolver.ResolveMemberAccess(currentQueryResult, "Select", EmptyList<IType>.Instance);
		ResolveResult[] arguments = new ResolveResult[1]
		{
			new QueryExpressionLambda(1, bodyExpression)
		};
		return resolver.ResolveInvocation(target, arguments);
	}

	private string GetSingleRangeVariable(QueryExpression query)
	{
		if (query == null)
		{
			return null;
		}
		foreach (QueryClause item in query.Clauses.Skip(1))
		{
			if (item is QueryFromClause || item is QueryJoinClause || item is QueryLetClause)
			{
				return null;
			}
		}
		if (query.Clauses.FirstOrDefault() is QueryFromClause queryFromClause)
		{
			return queryFromClause.Identifier;
		}
		if (query.Clauses.FirstOrDefault() is QueryContinuationClause queryContinuationClause)
		{
			return queryContinuationClause.Identifier;
		}
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryGroupClause(QueryGroupClause queryGroupClause)
	{
		if (currentQueryResult == null)
		{
			ScanChildren(queryGroupClause);
			return errorResult;
		}
		ResolveResult bodyExpression = Resolve(queryGroupClause.Projection);
		ResolveResult bodyExpression2 = Resolve(queryGroupClause.Key);
		ResolveResult target = resolver.ResolveMemberAccess(currentQueryResult, "GroupBy", EmptyList<IType>.Instance);
		ResolveResult[] arguments = new ResolveResult[2]
		{
			new QueryExpressionLambda(1, bodyExpression2),
			new QueryExpressionLambda(1, bodyExpression)
		};
		return resolver.ResolveInvocation(target, arguments);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryOrderClause(QueryOrderClause queryOrderClause)
	{
		foreach (QueryOrdering ordering in queryOrderClause.Orderings)
		{
			currentQueryResult = Resolve(ordering);
		}
		return WrapResult(currentQueryResult);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitQueryOrdering(QueryOrdering queryOrdering)
	{
		if (currentQueryResult == null)
		{
			ScanChildren(queryOrdering);
			return errorResult;
		}
		ResolveResult bodyExpression = Resolve(queryOrdering.Expression);
		string text = ((!(queryOrdering.Parent is QueryOrderClause queryOrderClause) || queryOrderClause.Orderings.FirstOrDefault() == queryOrdering) ? "OrderBy" : "ThenBy");
		if (queryOrdering.Direction == QueryOrderingDirection.Descending)
		{
			text += "Descending";
		}
		ResolveResult target = resolver.ResolveMemberAccess(currentQueryResult, text, EmptyList<IType>.Instance);
		ResolveResult[] arguments = new ResolveResult[1]
		{
			new QueryExpressionLambda(1, bodyExpression)
		};
		return resolver.ResolveInvocation(target, arguments);
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
	{
		ResolveResult resolveResult = ((constructorInitializer.ConstructorInitializerType != ConstructorInitializerType.Base) ? resolver.ResolveThisReference() : resolver.ResolveBaseReference());
		ResolveResult[] arguments = GetArguments(constructorInitializer.Arguments, out var argumentNames);
		ResolveResult resolveResult2 = resolver.ResolveObjectCreation(resolveResult.Type, arguments, argumentNames, allowProtectedAccess: true);
		ProcessInvocationResult(null, constructorInitializer.Arguments, resolveResult2);
		return resolveResult2;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitIdentifier(Identifier identifier)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitComment(Comment comment)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitNewLine(NewLineNode comment)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitWhitespace(WhitespaceNode whitespaceNode)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitText(TextNode textNode)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitArraySpecifier(ArraySpecifier arraySpecifier)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitNullNode(AstNode nullNode)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitErrorNode(AstNode errorNode)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
	{
		return null;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitAccessor(Accessor accessor)
	{
		ScanChildren(accessor);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitSwitchSection(SwitchSection switchSection)
	{
		ScanChildren(switchSection);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitCaseLabel(CaseLabel caseLabel)
	{
		ScanChildren(caseLabel);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitConstraint(Constraint constraint)
	{
		ScanChildren(constraint);
		return voidResult;
	}

	ResolveResult IAstVisitor<ResolveResult>.VisitDocumentationReference(DocumentationReference documentationReference)
	{
		ITypeDefinition typeDefinition = ((!documentationReference.DeclaringType.IsNull) ? ResolveType(documentationReference.DeclaringType).GetDefinition() : resolver.CurrentTypeDefinition);
		IType[] typeArguments = documentationReference.TypeArguments.Select(ResolveType).ToArray();
		IType other = ResolveType(documentationReference.ConversionOperatorReturnType);
		IParameter[] array = documentationReference.Parameters.Select(ResolveXmlDocParameter).ToArray();
		if (documentationReference.SymbolKind == SymbolKind.TypeDefinition)
		{
			if (typeDefinition != null)
			{
				return new TypeResolveResult(typeDefinition);
			}
			return errorResult;
		}
		if (documentationReference.SymbolKind == SymbolKind.None)
		{
			string memberName = documentationReference.MemberName;
			ResolveResult resolveResult;
			if (documentationReference.DeclaringType.IsNull)
			{
				resolveResult = resolver.LookupSimpleNameOrTypeName(memberName, typeArguments, NameLookupMode.Expression);
			}
			else
			{
				ResolveResult target = Resolve(documentationReference.DeclaringType);
				resolveResult = resolver.ResolveMemberAccess(target, memberName, typeArguments);
			}
			if (resolveResult.IsError)
			{
				return resolveResult;
			}
			if (resolveResult is TypeResolveResult)
			{
				ITypeDefinition definition = resolveResult.Type.GetDefinition();
				if (definition == null)
				{
					return errorResult;
				}
				if (documentationReference.HasParameterList)
				{
					IEnumerable<IMethod> constructors = definition.GetConstructors(null, GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers);
					return FindByParameters(constructors, array);
				}
				return new TypeResolveResult(definition);
			}
			if (resolveResult is MemberResolveResult)
			{
				MemberResolveResult memberResolveResult = (MemberResolveResult)resolveResult;
				return new MemberResolveResult(null, memberResolveResult.Member.MemberDefinition);
			}
			if (resolveResult is MethodGroupResolveResult)
			{
				MethodGroupResolveResult methodGroupResolveResult = (MethodGroupResolveResult)resolveResult;
				IEnumerable<IParameterizedMember> methods = methodGroupResolveResult.MethodsGroupedByDeclaringType.Reverse().SelectMany((MethodListWithDeclaringType ml) => ml.Select((IParameterizedMember m) => (IParameterizedMember)m.MemberDefinition));
				return FindByParameters(methods, array);
			}
			return resolveResult;
		}
		if (typeDefinition == null)
		{
			return errorResult;
		}
		if (documentationReference.SymbolKind == SymbolKind.Indexer)
		{
			IEnumerable<IProperty> methods2 = typeDefinition.Properties.Where((IProperty p) => p.IsIndexer && !p.IsExplicitInterfaceImplementation);
			return FindByParameters(methods2, array);
		}
		if (documentationReference.SymbolKind == SymbolKind.Operator)
		{
			OperatorType operatorType = documentationReference.OperatorType;
			string memberName2 = OperatorDeclaration.GetName(operatorType);
			IEnumerable<IMethod> enumerable = typeDefinition.Methods.Where((IMethod m) => m.IsOperator && m.Name == memberName2);
			if (operatorType == OperatorType.Implicit || operatorType == OperatorType.Explicit)
			{
				foreach (IMethod item in enumerable)
				{
					if (ParameterListComparer.Instance.Equals(item.Parameters, array) && item.ReturnType.Equals(other))
					{
						return new MemberResolveResult(null, item);
					}
				}
				return new MemberResolveResult(null, enumerable.FirstOrDefault());
			}
			return FindByParameters(enumerable, array);
		}
		throw new NotSupportedException();
	}

	private IParameter ResolveXmlDocParameter(ParameterDeclaration p)
	{
		if (Resolve(p) is LocalResolveResult { IsParameter: not false } localResolveResult)
		{
			return (IParameter)localResolveResult.Variable;
		}
		return new DefaultParameter(SpecialType.UnknownType, string.Empty);
	}

	private ResolveResult FindByParameters(IEnumerable<IParameterizedMember> methods, IList<IParameter> parameters)
	{
		foreach (IParameterizedMember method in methods)
		{
			if (ParameterListComparer.Instance.Equals(method.Parameters, parameters))
			{
				return new MemberResolveResult(null, method);
			}
		}
		return new MemberResolveResult(null, methods.FirstOrDefault());
	}
}

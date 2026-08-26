#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.DebugInfo;

internal class DebugInfoGenerator : DepthFirstAstVisitor
{
	private static readonly KeyComparer<ILVariable, int> ILVariableKeyComparer = new KeyComparer<ILVariable, int>((ILVariable l) => l.Index.Value, Comparer<int>.Default, EqualityComparer<int>.Default);

	private IDecompilerTypeSystem typeSystem;

	private readonly ImportScopeInfo globalImportScope = new ImportScopeInfo();

	private ImportScopeInfo currentImportScope;

	private List<ImportScopeInfo> importScopes = new List<ImportScopeInfo>();

	private List<(MethodDefinitionHandle Method, ImportScopeInfo Import, int Offset, int Length, HashSet<ILVariable> Locals)> localScopes = new List<(MethodDefinitionHandle, ImportScopeInfo, int, int, HashSet<ILVariable>)>();

	private List<ILFunction> functions = new List<ILFunction>();

	public IReadOnlyList<ILFunction> Functions => functions;

	public DebugInfoGenerator(IDecompilerTypeSystem typeSystem)
	{
		this.typeSystem = typeSystem ?? throw new ArgumentNullException("typeSystem");
		currentImportScope = globalImportScope;
	}

	public void Generate(MetadataBuilder metadata, ImportScopeHandle globalImportScope)
	{
		foreach (ImportScopeInfo importScope in importScopes)
		{
			BlobHandle imports = EncodeImports(metadata, importScope);
			importScope.Handle = metadata.AddImportScope((importScope.Parent == null) ? globalImportScope : importScope.Parent.Handle, imports);
		}
		foreach (var localScope in localScopes)
		{
			int rowNumber = checked(metadata.GetRowCount(TableIndex.LocalVariable) + 1);
			LocalVariableHandle variableList = MetadataTokens.LocalVariableHandle(rowNumber);
			foreach (ILVariable item in (IEnumerable<ILVariable>)Enumerable.OrderBy<ILVariable, int?>((IEnumerable<ILVariable>)localScope.Locals, (Func<ILVariable, int?>)((ILVariable l) => l.Index)))
			{
				StringHandle name = ((item.Name != null) ? metadata.GetOrAddString(item.Name) : default(StringHandle));
				metadata.AddLocalVariable(LocalVariableAttributes.None, item.Index.Value, name);
			}
			metadata.AddLocalScope(localScope.Method, localScope.Import.Handle, variableList, default(LocalConstantHandle), localScope.Offset, localScope.Length);
		}
	}

	private static BlobHandle EncodeImports(MetadataBuilder metadata, ImportScopeInfo scope)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		BlobBuilder blobBuilder = new BlobBuilder();
		Enumerator<string> enumerator = scope.Imports.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				blobBuilder.WriteByte(1);
				blobBuilder.WriteCompressedInteger(MetadataTokens.GetHeapOffset(metadata.GetOrAddBlobUTF8(current)));
			}
		}
		finally
		{
			((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		return metadata.GetOrAddBlob(blobBuilder);
	}

	public override void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
	{
		ImportScopeInfo parent = currentImportScope;
		currentImportScope = new ImportScopeInfo(parent);
		importScopes.Add(currentImportScope);
		base.VisitNamespaceDeclaration(namespaceDeclaration);
		currentImportScope = parent;
	}

	public override void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
	{
		currentImportScope.Imports.Add(usingDeclaration.Namespace);
	}

	public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
	{
		HandleMethod(methodDeclaration);
	}

	public override void VisitAccessor(Accessor accessor)
	{
		HandleMethod(accessor);
	}

	public override void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
	{
		HandleMethod(constructorDeclaration);
	}

	public override void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
	{
		HandleMethod(destructorDeclaration);
	}

	public override void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
	{
		HandleMethod(operatorDeclaration);
	}

	public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
	{
		HandleMethod(lambdaExpression);
	}

	public override void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
	{
		HandleMethod(anonymousMethodExpression);
	}

	private void HandleMethod(AstNode node)
	{
		VisitChildren(node);
		ILFunction iLFunction = node.Annotation<ILFunction>();
		if (iLFunction != null && iLFunction.Method != null && !iLFunction.Method.MetadataToken.IsNil)
		{
			functions.Add(iLFunction);
			IMethod method = iLFunction.MoveNextMethod ?? iLFunction.Method;
			MethodDefinitionHandle handle = (MethodDefinitionHandle)method.MetadataToken;
			PEFile pEFile = typeSystem.MainModule.PEFile;
			MethodDefinition methodDefinition = pEFile.Metadata.GetMethodDefinition(handle);
			if (methodDefinition.HasBody())
			{
				HandleMethodBody(iLFunction, pEFile.Reader.GetMethodBody(methodDefinition.RelativeVirtualAddress));
			}
		}
	}

	private void HandleMethodBody(ILFunction function, MethodBodyBlock methodBody)
	{
		IMethod method = function.MoveNextMethod ?? function.Method;
		HashSet<ILVariable> val = new HashSet<ILVariable>((IEqualityComparer<ILVariable>)ILVariableKeyComparer);
		if (!methodBody.LocalSignature.IsNil)
		{
			ImmutableArray<IType> immutableArray = typeSystem.MainModule.DecodeLocalSignature(methodBody.LocalSignature, new DecompTools.Decompiler.TypeSystem.GenericContext(method));
			foreach (ILVariable variable in function.Variables)
			{
				if (variable.Index.HasValue && variable.Kind.IsLocal())
				{
					Debug.Assert(variable.Index < immutableArray.Length && variable.Type.Equals(immutableArray[variable.Index.Value]));
					val.Add(variable);
				}
			}
		}
		localScopes.Add(((MethodDefinitionHandle)method.MetadataToken, currentImportScope, 0, methodBody.GetCodeSize(), val));
	}
}

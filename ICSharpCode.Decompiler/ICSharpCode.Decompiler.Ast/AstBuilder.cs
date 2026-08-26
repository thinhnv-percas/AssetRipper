using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.Decompiler.Ast;

public class AstBuilder
{
	private struct AsyncMethodBodyResult
	{
		public readonly EntityDeclaration MethodNode;

		public readonly MethodDef Method;

		public readonly BlockStatement Body;

		public readonly MethodDebugInfoBuilder Builder;

		public readonly FieldToVariableMap VariableMap;

		public readonly bool CurrentMethodIsAsync;

		public readonly bool CurrentMethodIsYieldReturn;

		public AsyncMethodBodyResult(EntityDeclaration methodNode, MethodDef method, BlockStatement body, MethodDebugInfoBuilder builder, FieldToVariableMap variableMap, bool currentMethodIsAsync, bool currentMethodIsYieldReturn)
		{
			MethodNode = methodNode;
			Method = method;
			Body = body;
			Builder = builder;
			VariableMap = variableMap;
			CurrentMethodIsAsync = currentMethodIsAsync;
			CurrentMethodIsYieldReturn = currentMethodIsYieldReturn;
		}
	}

	private sealed class AsyncMethodBodyDecompilationState
	{
		public readonly StringBuilder StringBuilder = new StringBuilder();
	}

	[Flags]
	private enum ConvertCustomAttributesFlags
	{
		None = 0,
		IsAsync = 1,
		IsYieldReturn = 2
	}

	private readonly DecompilerContext context;

	private SyntaxTree syntaxTree;

	private readonly Dictionary<string, NamespaceDeclaration> astNamespaces = new Dictionary<string, NamespaceDeclaration>();

	private bool transformationsHaveRun;

	private readonly StringBuilder stringBuilder;

	private readonly char[] commentBuffer;

	private readonly List<Task<AsyncMethodBodyResult>> methodBodyTasks = new List<Task<AsyncMethodBodyResult>>();

	private readonly List<AsyncMethodBodyDecompilationState> asyncMethodBodyDecompilationStates = new List<AsyncMethodBodyDecompilationState>();

	private readonly List<Comment> comments = new List<Comment>();

	private const int COMMENT_BUFFER_LENGTH = 10;

	private static readonly UTF8String systemReflectionString = new UTF8String("System.Reflection");

	private static readonly UTF8String defaultMemberAttributeString = new UTF8String("DefaultMemberAttribute");

	private static readonly UTF8String systemString = new UTF8String("System");

	private static readonly UTF8String multicastDelegateString = new UTF8String("MulticastDelegate");

	private const int MAX_CONVERTTYPE_DEPTH = 50;

	private static readonly UTF8String systemRuntimeCompilerServicesString = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String dynamicAttributeString = new UTF8String("DynamicAttribute");

	private static readonly UTF8String isVolatileString = new UTF8String("IsVolatile");

	private static readonly UTF8String valueTypeString = new UTF8String("ValueType");

	private static readonly UTF8String paramArrayAttributeString = new UTF8String("ParamArrayAttribute");

	private static readonly UTF8String systemRuntimeInteropServicesName = new UTF8String("System.Runtime.InteropServices");

	private static readonly UTF8String systemRuntimeSerializationFormattersName = new UTF8String("System.Runtime.Serialization.Formatters");

	private static readonly PublicKeyToken contractsPublicKeyToken = new PublicKeyToken("b03f5f7f11d50a3a");

	private static readonly UTF8String extensionAttributeString = new UTF8String("ExtensionAttribute");

	private static readonly UTF8String systemDiagnosticsString = new UTF8String("System.Diagnostics");

	private static readonly UTF8String debuggerStepThroughAttributeString = new UTF8String("DebuggerStepThroughAttribute");

	private static readonly UTF8String debuggerHiddenAttributeString = new UTF8String("DebuggerHiddenAttribute");

	private static readonly UTF8String asyncStateMachineAttributeString = new UTF8String("AsyncStateMachineAttribute");

	private static readonly UTF8String iteratorStateMachineAttributeString = new UTF8String("IteratorStateMachineAttribute");

	private static readonly UTF8String isReadOnlyAttributeString = new UTF8String("IsReadOnlyAttribute");

	private static readonly UTF8String isByRefLikeAttributeString = new UTF8String("IsByRefLikeAttribute");

	private static readonly UTF8String obsoleteAttributeString = new UTF8String("ObsoleteAttribute");

	private static readonly UTF8String flagsAttributeString = new UTF8String("FlagsAttribute");

	public DecompilerContext Context => context;

	internal AutoPropertyProvider AutoPropertyProvider { get; } = new AutoPropertyProvider();

	public Func<AstBuilder, MethodDef, DecompiledBodyKind> GetDecompiledBodyKind { get; set; }

	public SyntaxTree SyntaxTree => syntaxTree;

	private AsyncMethodBodyDecompilationState GetAsyncMethodBodyDecompilationState()
	{
		lock (asyncMethodBodyDecompilationStates)
		{
			if (asyncMethodBodyDecompilationStates.Count > 0)
			{
				AsyncMethodBodyDecompilationState result = asyncMethodBodyDecompilationStates[asyncMethodBodyDecompilationStates.Count - 1];
				asyncMethodBodyDecompilationStates.RemoveAt(asyncMethodBodyDecompilationStates.Count - 1);
				return result;
			}
		}
		return new AsyncMethodBodyDecompilationState();
	}

	private void Return(AsyncMethodBodyDecompilationState state)
	{
		lock (asyncMethodBodyDecompilationStates)
		{
			asyncMethodBodyDecompilationStates.Add(state);
		}
	}

	public AstBuilder(DecompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		this.context = context;
		stringBuilder = new StringBuilder();
		commentBuffer = new char[10];
		syntaxTree = new SyntaxTree();
		transformationsHaveRun = false;
		GetDecompiledBodyKind = null;
	}

	public void Reset()
	{
		GetDecompiledBodyKind = null;
		syntaxTree = new SyntaxTree();
		transformationsHaveRun = false;
		astNamespaces.Clear();
		stringBuilder.Clear();
		context.Reset();
		AutoPropertyProvider.Reset();
		methodBodyTasks.Clear();
	}

	private void WaitForBodies()
	{
		if (methodBodyTasks.Count == 0)
		{
			return;
		}
		try
		{
			for (int i = 0; i < methodBodyTasks.Count; i++)
			{
				AsyncMethodBodyResult result = methodBodyTasks[i].GetAwaiter().GetResult();
				context.CancellationToken.ThrowIfCancellationRequested();
				if (result.CurrentMethodIsAsync)
				{
					result.MethodNode.Modifiers |= Modifiers.Async;
				}
				result.MethodNode.SetChildByRole(Roles.Body, result.Body);
				result.MethodNode.AddAnnotation(result.Builder);
				result.MethodNode.AddAnnotation(result.VariableMap);
				ConvertAttributes(result.MethodNode, result.Method, result.CurrentMethodIsAsync, result.CurrentMethodIsYieldReturn);
				comments.Clear();
				comments.AddRange(result.MethodNode.GetChildrenByRole(Roles.Comment));
				for (int num = comments.Count - 1; num >= 0; num--)
				{
					Comment comment = comments[num];
					comment.Remove();
					result.MethodNode.InsertChildAfter(null, comment, Roles.Comment);
				}
			}
		}
		finally
		{
			methodBodyTasks.Clear();
		}
	}

	public static bool MemberIsHidden(IMemberRef member, DecompilerSettings settings)
	{
		if (member is MethodDef methodDef)
		{
			if (methodDef.IsGetter || methodDef.IsSetter || methodDef.IsAddOn || methodDef.IsRemoveOn)
			{
				return true;
			}
			if (settings.ForceShowAllMembers)
			{
				return false;
			}
			if (settings.AnonymousMethods)
			{
				if (methodDef.Name.StartsWith("_Lambda$__") && methodDef.IsCompilerGenerated())
				{
					return true;
				}
				if (methodDef.HasGeneratedName() && methodDef.IsCompilerGenerated())
				{
					return true;
				}
			}
		}
		if (member is TypeDef typeDef)
		{
			if (settings.ForceShowAllMembers)
			{
				return false;
			}
			if (typeDef.DeclaringType != null)
			{
				if (settings.AnonymousMethods && IsClosureType(typeDef))
				{
					return true;
				}
				if (settings.YieldReturn && YieldReturnDecompiler.IsCompilerGeneratorEnumerator(typeDef))
				{
					return true;
				}
				if (settings.AsyncAwait && AsyncDecompiler.IsCompilerGeneratedStateMachine(typeDef))
				{
					return true;
				}
				if (typeDef.IsDynamicCallSiteContainerType())
				{
					return true;
				}
			}
			else if (typeDef.IsCompilerGenerated())
			{
				if (typeDef.Name.StartsWith("<PrivateImplementationDetails>", StringComparison.Ordinal))
				{
					return true;
				}
				if (typeDef.IsAnonymousType())
				{
					return true;
				}
			}
		}
		if (member is FieldDef fieldDef)
		{
			if (settings.ForceShowAllMembers)
			{
				return false;
			}
			if (fieldDef.IsCompilerGenerated())
			{
				if (settings.AnonymousMethods && IsAnonymousMethodCacheField(fieldDef))
				{
					return true;
				}
				if (settings.AutomaticProperties && IsAutomaticPropertyBackingField(fieldDef))
				{
					return true;
				}
				if (settings.SwitchStatementOnString && IsSwitchOnStringCache(fieldDef))
				{
					return true;
				}
			}
			if (settings.AutomaticEvents)
			{
				string fieldName = fieldDef.Name;
				foreach (EventDef @event in fieldDef.DeclaringType.Events)
				{
					if (IsEventBackingFieldName(fieldName, @event.Name))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	internal static bool IsEventBackingFieldName(string fieldName, string eventName)
	{
		if (fieldName == eventName)
		{
			return true;
		}
		if (fieldName.Length == "Event".Length + eventName.Length && fieldName.StartsWith(eventName) && fieldName.EndsWith("Event"))
		{
			return true;
		}
		return false;
	}

	private static bool IsSwitchOnStringCache(FieldDef field)
	{
		return field.Name.StartsWith("<>f__switch", StringComparison.Ordinal);
	}

	private static bool IsAutomaticPropertyBackingField(FieldDef field)
	{
		string text = field.Name;
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		if (text[0] == '_')
		{
			foreach (PropertyDef property in field.DeclaringType.Properties)
			{
				string text2 = property.Name;
				if (text2.Length != text.Length - 1)
				{
					continue;
				}
				bool flag = true;
				for (int i = 0; i < text2.Length; i++)
				{
					if (text[i + 1] != text2[i])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
			}
		}
		if (field.HasGeneratedName())
		{
			return field.Name.EndsWith("BackingField", StringComparison.Ordinal);
		}
		return false;
	}

	private static bool IsAnonymousMethodCacheField(FieldDef field)
	{
		if (!field.Name.StartsWith("CS$<>", StringComparison.Ordinal))
		{
			return field.Name.StartsWith("<>f__am", StringComparison.Ordinal);
		}
		return true;
	}

	private static bool IsClosureType(TypeDef type)
	{
		if (!type.IsCompilerGenerated())
		{
			return false;
		}
		if (type.Name.StartsWith("_Closure$__"))
		{
			return true;
		}
		if (type.HasGeneratedName())
		{
			if (!(type.Name == "<>c") && !type.Name.StartsWith("<>c__") && !type.Name.Contains("DisplayClass"))
			{
				return type.Name.Contains("AnonStorey");
			}
			return true;
		}
		return false;
	}

	public void RunTransformations()
	{
		RunTransformations(null);
	}

	public void RunTransformations(Predicate<IAstTransform> transformAbortCondition)
	{
		WaitForBodies();
		TransformationPipeline.RunTransformationsUntil(syntaxTree, transformAbortCondition, context);
		transformationsHaveRun = true;
	}

	public void GenerateCode(IDecompilerOutput output)
	{
		if (!transformationsHaveRun)
		{
			RunTransformations();
		}
		syntaxTree.AcceptVisitor(new InsertParenthesesVisitor
		{
			InsertParenthesesForReadability = true
		});
		TextTokenWriter writer = new TextTokenWriter(output, context)
		{
			FoldBraces = false
		};
		CSharpFormattingOptions cSharpFormattingOptions = context.Settings.CSharpFormattingOptions;
		syntaxTree.AcceptVisitor(new CSharpOutputVisitor(writer, cSharpFormattingOptions, context.CancellationToken));
	}

	public void AddAssembly(AssemblyDef assemblyDefinition, bool onlyAssemblyLevel = false)
	{
		AddAssembly(assemblyDefinition.ManifestModule, onlyAssemblyLevel, decompileAsm: true, decompileMod: true);
	}

	public void AddAssembly(ModuleDef moduleDefinition, bool onlyAssemblyLevel, bool decompileAsm, bool decompileMod)
	{
		if (decompileAsm && moduleDefinition.Assembly != null && moduleDefinition.Assembly.Version != null)
		{
			syntaxTree.AddChild(new AttributeSection
			{
				AttributeTarget = "assembly",
				Attributes = 
				{
					new ICSharpCode.NRefactory.CSharp.Attribute
					{
						Type = new SimpleType("AssemblyVersion").WithAnnotation(moduleDefinition.CorLibTypes.GetTypeRef("System.Reflection", "AssemblyVersionAttribute")),
						Arguments = { (Expression)new PrimitiveExpression(moduleDefinition.Assembly.Version.ToString()) }
					}
				}
			}, EntityDeclaration.AttributeRole);
		}
		if (decompileAsm && moduleDefinition.Assembly != null)
		{
			ConvertCustomAttributes(Context.MetadataTextColorProvider, syntaxTree, moduleDefinition.Assembly, context.Settings, stringBuilder, "assembly");
			ConvertSecurityAttributes(Context.MetadataTextColorProvider, syntaxTree, moduleDefinition.Assembly, stringBuilder, "assembly");
		}
		if (decompileMod)
		{
			ConvertCustomAttributes(Context.MetadataTextColorProvider, syntaxTree, moduleDefinition, context.Settings, stringBuilder, "module");
			AddTypeForwarderAttributes(syntaxTree, moduleDefinition, "assembly");
		}
		if (!decompileMod || onlyAssemblyLevel)
		{
			return;
		}
		foreach (TypeDef type in moduleDefinition.Types)
		{
			if (!type.IsGlobalModuleType && !MemberIsHidden(type, context.Settings))
			{
				AddType(type);
			}
		}
	}

	private void AddTypeForwarderAttributes(SyntaxTree astCompileUnit, ModuleDef module, string target)
	{
		if (!module.HasExportedTypes)
		{
			return;
		}
		foreach (ExportedType exportedType in module.ExportedTypes)
		{
			if (exportedType.MovedToAnotherAssembly)
			{
				TypeOfExpression element = CreateTypeOfExpression(exportedType.ToTypeRef(), stringBuilder);
				astCompileUnit.AddChild(new AttributeSection
				{
					AttributeTarget = target,
					Attributes = 
					{
						new ICSharpCode.NRefactory.CSharp.Attribute
						{
							Type = new SimpleType("TypeForwardedTo").WithAnnotation(module.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "TypeForwardedToAttribute")),
							Arguments = { (Expression)element }
						}
					}
				}, EntityDeclaration.AttributeRole);
			}
		}
	}

	private NamespaceDeclaration GetCodeNamespace(string name, dnlib.DotNet.IAssembly asm)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		if (astNamespaces.ContainsKey(name))
		{
			return astNamespaces[name];
		}
		NamespaceDeclaration namespaceDeclaration = new NamespaceDeclaration(name, asm);
		syntaxTree.Members.Add(namespaceDeclaration);
		astNamespaces[name] = namespaceDeclaration;
		return namespaceDeclaration;
	}

	private char ToHexChar(int val)
	{
		if (0 <= val && val <= 9)
		{
			return (char)(48 + val);
		}
		return (char)(65 + val - 10);
	}

	private string ToHex(uint value)
	{
		commentBuffer[0] = '0';
		commentBuffer[1] = 'x';
		int length = 2;
		for (int i = 0; i < 4; i++)
		{
			commentBuffer[length++] = ToHexChar((int)((value >> 28) & 0xF));
			commentBuffer[length++] = ToHexChar((int)((value >> 24) & 0xF));
			value <<= 8;
		}
		return new string(commentBuffer, 0, length);
	}

	private void AddComment(AstNode node, IMemberDef member, string text = null)
	{
		if (context.Settings.ShowTokenAndRvaComments)
		{
			member.GetRVA(out var rva, out var fileOffset);
			CommentReferencesCreator commentReferencesCreator = new CommentReferencesCreator(stringBuilder);
			commentReferencesCreator.AddText(" ");
			if (text != null)
			{
				commentReferencesCreator.AddText("(");
				commentReferencesCreator.AddText(text);
				commentReferencesCreator.AddText(") ");
			}
			commentReferencesCreator.AddText("Token: ");
			commentReferencesCreator.AddReference(ToHex(member.MDToken.Raw), new TokenReference(member));
			commentReferencesCreator.AddText(" RID: ");
			commentReferencesCreator.AddText(member.MDToken.Rid.ToString());
			if (rva != 0)
			{
				string filename = member.Module?.Location;
				commentReferencesCreator.AddText(" RVA: ");
				commentReferencesCreator.AddReference(ToHex(rva), new AddressReference(filename, isRva: true, rva, 0uL));
				commentReferencesCreator.AddText(" File Offset: ");
				commentReferencesCreator.AddReference(ToHex((uint)fileOffset), new AddressReference(filename, isRva: false, (ulong)fileOffset, 0uL));
			}
			Comment comment = new Comment(commentReferencesCreator.Text);
			comment.References = commentReferencesCreator.CommentReferences;
			node.InsertChildAfter(null, comment, Roles.Comment);
		}
	}

	public void AddType(TypeDef typeDef)
	{
		EntityDeclaration element = CreateType(typeDef);
		NamespaceDeclaration codeNamespace = GetCodeNamespace(typeDef.Namespace, typeDef.DefinitionAssembly);
		if (codeNamespace != null)
		{
			codeNamespace.Members.Add(element);
		}
		else
		{
			syntaxTree.Members.Add(element);
		}
	}

	public void AddMethod(MethodDef method)
	{
		AstNode element = (method.IsConstructor ? CreateConstructor(method) : CreateMethod(method));
		syntaxTree.Members.Add(element);
	}

	public void AddProperty(PropertyDef property)
	{
		syntaxTree.Members.Add(CreateProperty(property));
	}

	public void AddField(FieldDef field)
	{
		syntaxTree.Members.Add(CreateField(field));
	}

	public void AddEvent(EventDef ev)
	{
		syntaxTree.Members.Add(CreateEvent(ev));
	}

	public EntityDeclaration CreateType(TypeDef typeDef)
	{
		TypeDef currentType = context.CurrentType;
		context.CurrentType = typeDef;
		TypeDeclaration typeDeclaration = new TypeDeclaration();
		ConvertAttributes(typeDeclaration, typeDef);
		typeDeclaration.AddAnnotation(typeDef);
		typeDeclaration.Modifiers = ConvertModifiers(typeDef);
		typeDeclaration.NameToken = Identifier.Create(CleanName(typeDef.Name)).WithAnnotation(typeDef);
		if (typeDef.IsEnum)
		{
			typeDeclaration.ClassType = ClassType.Enum;
			typeDeclaration.Modifiers &= ~Modifiers.Sealed;
		}
		else if (DnlibExtensions.IsValueType(typeDef))
		{
			typeDeclaration.ClassType = ClassType.Struct;
			typeDeclaration.Modifiers &= ~(Modifiers.Abstract | Modifiers.Sealed | Modifiers.Static);
			if (DnlibExtensions.HasIsReadOnlyAttribute(typeDef))
			{
				typeDeclaration.Modifiers |= Modifiers.Readonly;
			}
			if (DnlibExtensions.HasIsByRefLikeAttribute(typeDef))
			{
				typeDeclaration.Modifiers |= Modifiers.Ref;
			}
		}
		else if (typeDef.IsInterface)
		{
			typeDeclaration.ClassType = ClassType.Interface;
			typeDeclaration.Modifiers &= ~Modifiers.Abstract;
		}
		else
		{
			typeDeclaration.ClassType = ClassType.Class;
		}
		IEnumerable<GenericParam> enumerable = typeDef.GenericParameters;
		if (typeDef.DeclaringType != null && typeDef.DeclaringType.HasGenericParameters)
		{
			enumerable = enumerable.Skip(typeDef.DeclaringType.GenericParameters.Count);
		}
		typeDeclaration.TypeParameters.AddRange(MakeTypeParameters(enumerable));
		typeDeclaration.Constraints.AddRange(MakeConstraints(enumerable));
		EntityDeclaration result = typeDeclaration;
		if (typeDef.IsEnum)
		{
			long num = 0L;
			bool flag = IsFlagsEnum(typeDef);
			FieldDef fieldDef = typeDef.Fields.FirstOrDefault((FieldDef f) => !f.IsStatic);
			foreach (FieldDef field in typeDef.Fields)
			{
				if (!field.IsStatic)
				{
					if (!default(SigComparer).Equals(field.FieldType, typeDef.Module.CorLibTypes.Int32))
					{
						typeDeclaration.AddChild(ConvertType(field.FieldType, stringBuilder), Roles.BaseType);
					}
					continue;
				}
				EnumMemberDeclaration enumMemberDeclaration = new EnumMemberDeclaration();
				ConvertCustomAttributes(Context.MetadataTextColorProvider, enumMemberDeclaration, field, context.Settings, stringBuilder);
				enumMemberDeclaration.AddAnnotation(field);
				enumMemberDeclaration.NameToken = Identifier.Create(CleanName(field.Name)).WithAnnotation(field);
				TryGetConstant(field, out var constant);
				TypeCode typeCode = ((constant != null) ? Type.GetTypeCode(constant.GetType()) : TypeCode.Empty);
				if (typeCode >= TypeCode.Char && typeCode <= TypeCode.Decimal)
				{
					long num2 = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constant, checkForOverflow: false);
					if (flag || num2 != num)
					{
						enumMemberDeclaration.AddChild(new PrimitiveExpression(ConvertConstant(fieldDef?.FieldSig.GetFieldType(), constant)), EnumMemberDeclaration.InitializerRole);
					}
					num = num2 + 1;
					typeDeclaration.AddChild(enumMemberDeclaration, Roles.TypeMemberRole);
					AddComment(enumMemberDeclaration, field);
				}
			}
		}
		else if (IsNormalDelegate(typeDef))
		{
			DelegateDeclaration delegateDeclaration = new DelegateDeclaration();
			delegateDeclaration.Modifiers = typeDeclaration.Modifiers & ~Modifiers.Sealed;
			delegateDeclaration.NameToken = (Identifier)typeDeclaration.NameToken.Clone();
			delegateDeclaration.AddAnnotation(typeDef);
			typeDeclaration.Attributes.MoveTo(delegateDeclaration.Attributes);
			typeDeclaration.TypeParameters.MoveTo(delegateDeclaration.TypeParameters);
			typeDeclaration.Constraints.MoveTo(delegateDeclaration.Constraints);
			foreach (MethodDef method in typeDef.Methods)
			{
				if (method.Name == "Invoke")
				{
					delegateDeclaration.ReturnType = ConvertType(method.ReturnType, stringBuilder, method.Parameters.ReturnParameter.ParamDef);
					delegateDeclaration.Parameters.AddRange(MakeParameters(Context.MetadataTextColorProvider, method, context.Settings, stringBuilder));
					ConvertAttributes(delegateDeclaration, method.Parameters.ReturnParameter, method.Module);
					AddComment(delegateDeclaration, method, "Invoke");
				}
			}
			AddComment(delegateDeclaration, typeDef);
			result = delegateDeclaration;
		}
		else
		{
			if (typeDef.BaseType != null && !DnlibExtensions.IsValueType(typeDef) && !typeDef.BaseType.IsSystemObject())
			{
				typeDeclaration.AddChild(ConvertType(typeDef.BaseType, stringBuilder), Roles.BaseType);
			}
			foreach (InterfaceImpl @interface in typeDef.Interfaces)
			{
				typeDeclaration.AddChild(ConvertType(@interface.Interface, stringBuilder), Roles.BaseType);
			}
			AddTypeMembers(typeDeclaration, typeDef);
			if (typeDeclaration.Members.OfType<IndexerDeclaration>().Any((IndexerDeclaration idx) => idx.PrivateImplementationType.IsNull))
			{
				foreach (AttributeSection attribute in typeDeclaration.Attributes)
				{
					foreach (ICSharpCode.NRefactory.CSharp.Attribute attribute2 in attribute.Attributes)
					{
						ITypeDefOrRef typeDefOrRef = attribute2.Type.Annotation<ITypeDefOrRef>();
						if (typeDefOrRef != null && typeDefOrRef.Compare(systemReflectionString, defaultMemberAttributeString))
						{
							attribute2.Remove();
						}
					}
					if (attribute.Attributes.Count == 0)
					{
						attribute.Remove();
					}
				}
			}
		}
		AddComment(typeDeclaration, typeDef);
		context.CurrentType = currentType;
		return result;
	}

	private bool IsNormalDelegate(TypeDef td)
	{
		if (!td.BaseType.Compare(systemString, multicastDelegateString))
		{
			return false;
		}
		if (td.HasFields)
		{
			return false;
		}
		if (td.HasProperties)
		{
			return false;
		}
		if (td.HasEvents)
		{
			return false;
		}
		if (td.Methods.Any((MethodDef m) => m.Body != null))
		{
			return false;
		}
		return true;
	}

	internal static string CleanName(string name)
	{
		int num = name.LastIndexOf('`');
		if (num >= 0)
		{
			name = name.Substring(0, num);
		}
		if (name.Length == 0 || name[0] != '<')
		{
			num = name.LastIndexOf('.');
			if (num >= 0)
			{
				name = name.Substring(num + 1);
			}
		}
		return name;
	}

	public static TypeOfExpression CreateTypeOfExpression(ITypeDefOrRef type, StringBuilder sb)
	{
		return new TypeOfExpression(AddEmptyTypeArgumentsForUnboundGenerics(ConvertType(type, sb)));
	}

	private static AstType AddEmptyTypeArgumentsForUnboundGenerics(AstType type)
	{
		ITypeDefOrRef typeDefOrRef = type.Annotation<ITypeDefOrRef>();
		if (typeDefOrRef == null)
		{
			return type;
		}
		TypeDef typeDef = typeDefOrRef.ResolveTypeDef();
		if (typeDef == null || !typeDef.HasGenericParameters)
		{
			return type;
		}
		SimpleType simpleType = type as SimpleType;
		MemberType memberType = type as MemberType;
		if (simpleType != null)
		{
			while (typeDef.GenericParameters.Count > simpleType.TypeArguments.Count)
			{
				simpleType.TypeArguments.Add(new SimpleType("").WithAnnotation(BoxedTextColor.TypeGenericParameter).WithAnnotation(SimpleType.DummyTypeGenericParam));
			}
		}
		if (memberType != null)
		{
			AddEmptyTypeArgumentsForUnboundGenerics(memberType.Target);
			int num = ((typeDef.DeclaringType != null) ? typeDef.DeclaringType.GenericParameters.Count : 0);
			while (typeDef.GenericParameters.Count - num > memberType.TypeArguments.Count)
			{
				memberType.TypeArguments.Add(new SimpleType("").WithAnnotation(BoxedTextColor.TypeGenericParameter).WithAnnotation(SimpleType.DummyTypeGenericParam));
			}
		}
		return type;
	}

	public static AstType ConvertType(ITypeDefOrRef type, StringBuilder sb, IHasCustomAttribute typeAttributes = null, ConvertTypeOptions options = ConvertTypeOptions.None)
	{
		int typeIndex = 0;
		return ConvertType(type, typeAttributes, ref typeIndex, options, 0, sb);
	}

	public static AstType ConvertType(TypeSig type, StringBuilder sb, IHasCustomAttribute typeAttributes = null, ConvertTypeOptions options = ConvertTypeOptions.None)
	{
		int typeIndex = 0;
		return ConvertType(type, typeAttributes, ref typeIndex, options, 0, sb);
	}

	private static AstType ConvertType(TypeSig type, IHasCustomAttribute typeAttributes, ref int typeIndex, ConvertTypeOptions options, int depth, StringBuilder sb)
	{
		if (depth++ > 50)
		{
			return AstType.Null;
		}
		type = type.RemovePinnedAndModifiers();
		if (type == null)
		{
			return AstType.Null;
		}
		if (type is ByRefSig)
		{
			typeIndex++;
			return ConvertType((type as ByRefSig).Next, typeAttributes, ref typeIndex, options, depth, sb).MakePointerType();
		}
		if (type is PtrSig)
		{
			typeIndex++;
			return ConvertType((type as PtrSig).Next, typeAttributes, ref typeIndex, options, depth, sb).MakePointerType();
		}
		if (type is ArraySigBase)
		{
			typeIndex++;
			return ConvertType((type as ArraySigBase).Next, typeAttributes, ref typeIndex, options, depth, sb).MakeArrayType((int)(type as ArraySigBase).Rank);
		}
		if (type is GenericInstSig)
		{
			GenericInstSig genericInstSig = (GenericInstSig)type;
			if (genericInstSig.GenericType != null && genericInstSig.GenericArguments.Count == 1 && genericInstSig.GenericType.IsSystemNullable())
			{
				typeIndex++;
				return new ComposedType
				{
					BaseType = ConvertType(genericInstSig.GenericArguments[0], typeAttributes, ref typeIndex, options, depth, sb),
					HasNullableSpecifier = true
				};
			}
			AstType astType = ConvertType((genericInstSig.GenericType == null) ? null : genericInstSig.GenericType.TypeDefOrRef, typeAttributes, ref typeIndex, options & ~ConvertTypeOptions.IncludeTypeParameterDefinitions, depth, sb);
			List<AstType> list = new List<AstType>();
			foreach (TypeSig genericArgument in genericInstSig.GenericArguments)
			{
				typeIndex++;
				list.Add(ConvertType(genericArgument, typeAttributes, ref typeIndex, options, depth, sb));
			}
			ApplyTypeArgumentsTo(astType, list);
			return astType;
		}
		if (type is GenericSig)
		{
			GenericSig genericSig = (GenericSig)type;
			SimpleType simpleType = new SimpleType(genericSig.GetName(sb)).WithAnnotation(genericSig.GenericParam).WithAnnotation(type);
			simpleType.IdentifierToken.WithAnnotation(genericSig.GenericParam).WithAnnotation(type);
			return simpleType;
		}
		if (type is TypeDefOrRefSig)
		{
			return ConvertType(((TypeDefOrRefSig)type).TypeDefOrRef, typeAttributes, ref typeIndex, options, depth, sb);
		}
		return ConvertType(type.ToTypeDefOrRef(), typeAttributes, ref typeIndex, options, depth, sb);
	}

	private static AstType ConvertType(ITypeDefOrRef type, IHasCustomAttribute typeAttributes, ref int typeIndex, ConvertTypeOptions options, int depth, StringBuilder sb)
	{
		if (depth++ > 50 || type == null)
		{
			return AstType.Null;
		}
		TypeSpec typeSpec = type as TypeSpec;
		if (typeSpec != null && !(typeSpec.TypeSig is FnPtrSig))
		{
			return ConvertType(typeSpec.TypeSig, typeAttributes, ref typeIndex, options, depth, sb);
		}
		if (type.DeclaringType != null && (options & ConvertTypeOptions.DoNotIncludeEnclosingType) == 0)
		{
			AstType target = ConvertType(type.DeclaringType, typeAttributes, ref typeIndex, options & ~ConvertTypeOptions.IncludeTypeParameterDefinitions, depth, sb);
			string name = ReflectionHelper.SplitTypeParameterCountFromReflectionName(type.Name);
			MemberType memberType = new MemberType
			{
				Target = target,
				MemberNameToken = Identifier.Create(name).WithAnnotation(type)
			};
			memberType.AddAnnotation(type);
			if ((options & ConvertTypeOptions.IncludeTypeParameterDefinitions) == ConvertTypeOptions.IncludeTypeParameterDefinitions)
			{
				AddTypeParameterDefininitionsTo(type, memberType);
			}
			return memberType;
		}
		string text = type.GetNamespace(sb) ?? string.Empty;
		string text2 = type.GetName(sb);
		if (typeSpec != null)
		{
			text2 = DnlibExtensions.GetFnPtrName(typeSpec.TypeSig as FnPtrSig);
		}
		if (text2 == null)
		{
			throw new InvalidOperationException("type.Name returned null. Type: " + type.ToString());
		}
		if (text2 == "Object" && text == "System" && HasDynamicAttribute(typeAttributes, typeIndex))
		{
			return new PrimitiveType("dynamic");
		}
		if (text == "System" && (options & ConvertTypeOptions.DoNotUsePrimitiveTypeNames) != ConvertTypeOptions.DoNotUsePrimitiveTypeNames)
		{
			switch (text2)
			{
			case "SByte":
				return new PrimitiveType("sbyte").WithAnnotation(type);
			case "Int16":
				return new PrimitiveType("short").WithAnnotation(type);
			case "Int32":
				return new PrimitiveType("int").WithAnnotation(type);
			case "Int64":
				return new PrimitiveType("long").WithAnnotation(type);
			case "Byte":
				return new PrimitiveType("byte").WithAnnotation(type);
			case "UInt16":
				return new PrimitiveType("ushort").WithAnnotation(type);
			case "UInt32":
				return new PrimitiveType("uint").WithAnnotation(type);
			case "UInt64":
				return new PrimitiveType("ulong").WithAnnotation(type);
			case "String":
				return new PrimitiveType("string").WithAnnotation(type);
			case "Single":
				return new PrimitiveType("float").WithAnnotation(type);
			case "Double":
				return new PrimitiveType("double").WithAnnotation(type);
			case "Decimal":
				return new PrimitiveType("decimal").WithAnnotation(type);
			case "Char":
				return new PrimitiveType("char").WithAnnotation(type);
			case "Boolean":
				return new PrimitiveType("bool").WithAnnotation(type);
			case "Void":
				return new PrimitiveType("void").WithAnnotation(type);
			case "Object":
				return new PrimitiveType("object").WithAnnotation(type);
			}
		}
		text2 = ReflectionHelper.SplitTypeParameterCountFromReflectionName(text2);
		AstType astType;
		if ((options & ConvertTypeOptions.IncludeNamespace) == ConvertTypeOptions.IncludeNamespace && text.Length > 0)
		{
			string[] array = text.Split('.');
			dnlib.DotNet.IAssembly definitionAssembly = type.DefinitionAssembly;
			sb.Clear();
			sb.Append(array[0]);
			SimpleType simpleType;
			AstType target2 = (simpleType = new SimpleType(array[0]).WithAnnotation(BoxedTextColor.Namespace));
			simpleType.IdentifierToken.WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(definitionAssembly, array[0]));
			for (int i = 1; i < array.Length; i++)
			{
				sb.Append('.');
				sb.Append(array[i]);
				string text3 = sb.ToString();
				target2 = new MemberType
				{
					Target = target2,
					MemberNameToken = Identifier.Create(array[i]).WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(definitionAssembly, text3))
				}.WithAnnotation(BoxedTextColor.Namespace);
			}
			astType = new MemberType
			{
				Target = target2,
				MemberNameToken = Identifier.Create(text2).WithAnnotation(type)
			};
		}
		else
		{
			astType = new SimpleType(text2);
		}
		astType.AddAnnotation(type);
		if ((options & ConvertTypeOptions.IncludeTypeParameterDefinitions) == ConvertTypeOptions.IncludeTypeParameterDefinitions)
		{
			AddTypeParameterDefininitionsTo(type, astType);
		}
		return astType;
	}

	private static void AddTypeParameterDefininitionsTo(ITypeDefOrRef type, AstType astType)
	{
		TypeDef typeDef = type.ResolveTypeDef();
		if (typeDef == null || !typeDef.HasGenericParameters)
		{
			return;
		}
		List<AstType> list = new List<AstType>();
		foreach (GenericParam genericParameter in typeDef.GenericParameters)
		{
			list.Add(new SimpleType(genericParameter.Name).WithAnnotation(genericParameter));
		}
		ApplyTypeArgumentsTo(astType, list);
	}

	private static void ApplyTypeArgumentsTo(AstType baseType, List<AstType> typeArguments)
	{
		if (baseType is SimpleType simpleType)
		{
			simpleType.TypeArguments.AddRange(typeArguments);
		}
		if (!(baseType is MemberType memberType))
		{
			return;
		}
		ITypeDefOrRef typeDefOrRef = memberType.Annotation<ITypeDefOrRef>();
		if (typeDefOrRef != null)
		{
			ReflectionHelper.SplitTypeParameterCountFromReflectionName(typeDefOrRef.Name, out var typeParameterCount);
			if (typeParameterCount > typeArguments.Count)
			{
				typeParameterCount = typeArguments.Count;
			}
			memberType.TypeArguments.AddRange(typeArguments.GetRange(typeArguments.Count - typeParameterCount, typeParameterCount));
			typeArguments.RemoveRange(typeArguments.Count - typeParameterCount, typeParameterCount);
			if (typeArguments.Count > 0)
			{
				ApplyTypeArgumentsTo(memberType.Target, typeArguments);
			}
		}
		else
		{
			memberType.TypeArguments.AddRange(typeArguments);
		}
	}

	private static bool HasDynamicAttribute(IHasCustomAttribute attributeProvider, int typeIndex)
	{
		if (attributeProvider == null || !attributeProvider.HasCustomAttributes)
		{
			return false;
		}
		foreach (CustomAttribute customAttribute in attributeProvider.CustomAttributes)
		{
			if (customAttribute.AttributeType.Compare(systemRuntimeCompilerServicesString, dynamicAttributeString))
			{
				if (customAttribute.ConstructorArguments.Count == 1 && customAttribute.ConstructorArguments[0].Value is IList<CAArgument> list && typeIndex < list.Count && list[typeIndex].Value is bool)
				{
					return (bool)list[typeIndex].Value;
				}
				return true;
			}
		}
		return false;
	}

	private Modifiers ConvertModifiers(TypeDef typeDef)
	{
		Modifiers modifiers = Modifiers.None;
		if (typeDef.IsNestedPrivate)
		{
			if (context.Settings.MemberAddPrivateModifier)
			{
				modifiers |= Modifiers.Private;
			}
		}
		else if (typeDef.IsNotPublic)
		{
			if (context.Settings.TypeAddInternalModifier)
			{
				modifiers |= Modifiers.Internal;
			}
		}
		else if (typeDef.IsNestedAssembly || typeDef.IsNestedFamilyAndAssembly)
		{
			modifiers |= Modifiers.Internal;
		}
		else if (typeDef.IsNestedFamily)
		{
			modifiers |= Modifiers.Protected;
		}
		else if (typeDef.IsNestedFamilyOrAssembly)
		{
			modifiers |= Modifiers.Internal | Modifiers.Protected;
		}
		else if (typeDef.IsPublic || typeDef.IsNestedPublic)
		{
			modifiers |= Modifiers.Public;
		}
		if (typeDef.IsAbstract && typeDef.IsSealed)
		{
			modifiers |= Modifiers.Static;
		}
		else if (typeDef.IsAbstract)
		{
			modifiers |= Modifiers.Abstract;
		}
		else if (typeDef.IsSealed)
		{
			modifiers |= Modifiers.Sealed;
		}
		return modifiers;
	}

	private Modifiers ConvertModifiers(FieldDef fieldDef)
	{
		Modifiers modifiers = Modifiers.None;
		if (fieldDef.IsPrivate)
		{
			if (context.Settings.MemberAddPrivateModifier)
			{
				modifiers |= Modifiers.Private;
			}
		}
		else if (fieldDef.IsAssembly)
		{
			modifiers |= Modifiers.Internal;
		}
		else if (fieldDef.IsFamily)
		{
			modifiers |= Modifiers.Protected;
		}
		else if (fieldDef.IsFamilyOrAssembly)
		{
			modifiers |= Modifiers.Internal | Modifiers.Protected;
		}
		else if (fieldDef.IsPublic)
		{
			modifiers |= Modifiers.Public;
		}
		else if (fieldDef.IsFamilyAndAssembly)
		{
			modifiers |= Modifiers.Private | Modifiers.Protected;
		}
		if (fieldDef.IsLiteral)
		{
			modifiers |= Modifiers.Const;
		}
		else
		{
			if (fieldDef.IsStatic)
			{
				modifiers |= Modifiers.Static;
			}
			if (fieldDef.IsInitOnly)
			{
				modifiers |= Modifiers.Readonly;
			}
		}
		if (fieldDef.FieldType is CModReqdSig { Modifier: not null } cModReqdSig && cModReqdSig.Modifier.Compare(systemRuntimeCompilerServicesString, isVolatileString))
		{
			modifiers |= Modifiers.Volatile;
		}
		return modifiers;
	}

	private Modifiers ConvertModifiers(MethodDef methodDef)
	{
		if (methodDef == null)
		{
			return Modifiers.None;
		}
		Modifiers modifiers = Modifiers.None;
		if (methodDef.IsPrivate)
		{
			if (context.Settings.MemberAddPrivateModifier)
			{
				modifiers |= Modifiers.Private;
			}
		}
		else if (methodDef.IsAssembly)
		{
			modifiers |= Modifiers.Internal;
		}
		else if (methodDef.IsFamily)
		{
			modifiers |= Modifiers.Protected;
		}
		else if (methodDef.IsFamilyOrAssembly)
		{
			modifiers |= Modifiers.Internal | Modifiers.Protected;
		}
		else if (methodDef.IsPublic)
		{
			modifiers |= Modifiers.Public;
		}
		else if (methodDef.IsFamilyAndAssembly)
		{
			modifiers |= Modifiers.Private | Modifiers.Protected;
		}
		if (methodDef.IsStatic)
		{
			modifiers |= Modifiers.Static;
		}
		if (methodDef.IsAbstract)
		{
			modifiers |= Modifiers.Abstract;
			if (!methodDef.IsNewSlot)
			{
				modifiers |= GetOverrideModifierOrDefault(methodDef, Modifiers.None);
			}
		}
		else if (methodDef.IsFinal)
		{
			if (!methodDef.IsNewSlot)
			{
				modifiers |= Modifiers.Sealed | GetOverrideModifierOrDefault(methodDef, Modifiers.None);
			}
		}
		else if (methodDef.IsVirtual)
		{
			Modifiers modifiers2 = ((!methodDef.DeclaringType.IsSealed) ? Modifiers.Virtual : Modifiers.None);
			modifiers = ((!methodDef.IsNewSlot) ? (modifiers | GetOverrideModifierOrDefault(methodDef, modifiers2)) : (modifiers | modifiers2));
		}
		if (!methodDef.HasBody && !methodDef.IsAbstract)
		{
			modifiers |= Modifiers.Extern;
		}
		return modifiers;
	}

	private static Modifiers GetOverrideModifierOrDefault(MethodDef method, Modifiers defaultValue)
	{
		ITypeDefOrRef baseType = method.DeclaringType.BaseType;
		UTF8String name = method.Name;
		int paramCount = method.MethodSig.GetParamCount();
		while (baseType != null)
		{
			TypeDef typeDef = baseType.Resolve();
			if (typeDef == null)
			{
				return Modifiers.Override;
			}
			foreach (MethodDef method2 in typeDef.Methods)
			{
				if (method2.IsVirtual && method2.Name == name && method2.MethodSig.GetParamCount() == paramCount)
				{
					return Modifiers.Override;
				}
			}
			baseType = typeDef.BaseType;
		}
		return defaultValue;
	}

	private IEnumerable<TypeDef> GetNestedTypes(TypeDef type)
	{
		if (context.Settings.UseSourceCodeOrder)
		{
			return type.NestedTypes;
		}
		return type.GetNestedTypes(context.Settings.SortMembers);
	}

	private IEnumerable<FieldDef> GetFields(TypeDef type)
	{
		if (context.Settings.UseSourceCodeOrder)
		{
			return type.Fields;
		}
		return type.GetFields(context.Settings.SortMembers);
	}

	private void AddTypeMembers(TypeDeclaration astType, TypeDef typeDef)
	{
		bool flag = false;
		foreach (DecompilationObject decompilationObject in context.Settings.DecompilationObjects)
		{
			switch (decompilationObject)
			{
			case DecompilationObject.NestedTypes:
				foreach (TypeDef nestedType in GetNestedTypes(typeDef))
				{
					if (!MemberIsHidden(nestedType, context.Settings))
					{
						EntityDeclaration entityDeclaration = CreateType(nestedType);
						SetNewModifier(entityDeclaration);
						astType.AddChild(entityDeclaration, Roles.TypeMemberRole);
					}
				}
				break;
			case DecompilationObject.Fields:
				foreach (FieldDef field in GetFields(typeDef))
				{
					if (!MemberIsHidden(field, context.Settings))
					{
						astType.AddChild(CreateField(field), Roles.TypeMemberRole);
					}
				}
				break;
			case DecompilationObject.Events:
				if (flag)
				{
					break;
				}
				if (context.Settings.UseSourceCodeOrder || !typeDef.CanSortMethods())
				{
					ShowAllMethods(astType, typeDef);
					flag = true;
					break;
				}
				foreach (EventDef @event in typeDef.GetEvents(context.Settings.SortMembers))
				{
					if (@event.AddMethod != null || @event.RemoveMethod != null)
					{
						astType.AddChild(CreateEvent(@event), Roles.TypeMemberRole);
					}
				}
				break;
			case DecompilationObject.Properties:
				if (flag)
				{
					break;
				}
				if (context.Settings.UseSourceCodeOrder || !typeDef.CanSortMethods())
				{
					ShowAllMethods(astType, typeDef);
					flag = true;
					break;
				}
				foreach (PropertyDef property in typeDef.GetProperties(context.Settings.SortMembers))
				{
					if (property.GetMethod != null || property.SetMethod != null)
					{
						astType.Members.Add(CreateProperty(property));
					}
				}
				break;
			case DecompilationObject.Methods:
				if (flag)
				{
					break;
				}
				if (context.Settings.UseSourceCodeOrder || !typeDef.CanSortMethods())
				{
					ShowAllMethods(astType, typeDef);
					flag = true;
					break;
				}
				foreach (MethodDef method in typeDef.GetMethods(context.Settings.SortMembers))
				{
					if (!MemberIsHidden(method, context.Settings))
					{
						if (method.IsConstructor)
						{
							astType.Members.Add(CreateConstructor(method));
						}
						else
						{
							astType.Members.Add(CreateMethod(method));
						}
					}
				}
				break;
			default:
				throw new InvalidOperationException();
			}
		}
	}

	private void ShowAllMethods(TypeDeclaration astType, TypeDef type)
	{
		foreach (IMemberDef nonSortedMethodsPropertiesEvent in type.GetNonSortedMethodsPropertiesEvents())
		{
			if (nonSortedMethodsPropertiesEvent is MethodDef methodDef)
			{
				if (!MemberIsHidden(methodDef, context.Settings))
				{
					if (methodDef.IsConstructor)
					{
						astType.Members.Add(CreateConstructor(methodDef));
					}
					else
					{
						astType.Members.Add(CreateMethod(methodDef));
					}
				}
			}
			else if (nonSortedMethodsPropertiesEvent is PropertyDef propertyDef)
			{
				if (propertyDef.GetMethod != null || propertyDef.SetMethod != null)
				{
					astType.Members.Add(CreateProperty(propertyDef));
				}
			}
			else if (nonSortedMethodsPropertiesEvent is EventDef eventDef && (eventDef.AddMethod != null || eventDef.RemoveMethod != null))
			{
				astType.AddChild(CreateEvent(eventDef), Roles.TypeMemberRole);
			}
		}
	}

	private EntityDeclaration CreateMethod(MethodDef methodDef)
	{
		MethodDeclaration methodDeclaration = new MethodDeclaration();
		methodDeclaration.AddAnnotation(methodDef);
		methodDeclaration.ReturnType = ConvertType(methodDef.ReturnType, stringBuilder, methodDef.Parameters.ReturnParameter.ParamDef);
		bool flag = methodDef.ReturnType.RemovePinnedAndModifiers().GetElementType() == ElementType.ByRef && UndoByRefToPointer(methodDeclaration.ReturnType);
		methodDeclaration.NameToken = Identifier.Create(CleanName(methodDef.Name)).WithAnnotation(methodDef);
		methodDeclaration.TypeParameters.AddRange(MakeTypeParameters(methodDef.GenericParameters));
		methodDeclaration.Parameters.AddRange(MakeParameters(Context.MetadataTextColorProvider, methodDef, context.Settings, stringBuilder));
		bool flag2 = false;
		if (!methodDef.IsVirtual || (methodDef.IsNewSlot && !methodDef.IsPrivate))
		{
			methodDeclaration.Constraints.AddRange(MakeConstraints(methodDef.GenericParameters));
		}
		if (!methodDef.DeclaringType.IsInterface)
		{
			if (IsExplicitInterfaceImplementation(methodDef))
			{
				methodDeclaration.PrivateImplementationType = ConvertType(methodDef.Overrides.First().MethodDeclaration?.DeclaringType, stringBuilder);
			}
			else
			{
				methodDeclaration.Modifiers = ConvertModifiers(methodDef);
				if (methodDef.IsVirtual == methodDef.IsNewSlot)
				{
					SetNewModifier(methodDeclaration);
				}
			}
			flag2 = true;
		}
		else if (methodDef.IsStatic)
		{
			methodDeclaration.Modifiers = ConvertModifiers(methodDef);
			flag2 = true;
		}
		OperatorDeclaration operatorDeclaration = null;
		OperatorType? operatorType = null;
		if (methodDef.IsSpecialName && !methodDef.HasGenericParameters)
		{
			operatorType = OperatorDeclaration.GetOperatorType(methodDef.Name);
			if (operatorType.HasValue)
			{
				operatorDeclaration = new OperatorDeclaration();
			}
		}
		if (flag2)
		{
			if (operatorDeclaration != null)
			{
				AddMethodBody(operatorDeclaration, methodDef, methodDeclaration.Parameters, valueParameterIsKeyword: false, MethodKind.Method);
			}
			else
			{
				AddMethodBody(methodDeclaration, methodDef, methodDeclaration.Parameters, valueParameterIsKeyword: false, MethodKind.Method);
			}
		}
		else
		{
			ClearCurrentMethodState();
			ConvertAttributes(methodDeclaration, methodDef);
		}
		if (methodDef.HasCustomAttributes && methodDeclaration.Parameters.Count > 0 && methodDef.IsDefined(systemRuntimeCompilerServicesString, extensionAttributeString))
		{
			methodDeclaration.Parameters.First().ParameterModifier = ParameterModifier.This;
		}
		if (operatorDeclaration != null)
		{
			operatorDeclaration.CopyAnnotationsFrom(methodDeclaration);
			operatorDeclaration.ReturnType = methodDeclaration.ReturnType.Detach();
			operatorDeclaration.OperatorType = operatorType.Value;
			operatorDeclaration.Modifiers = methodDeclaration.Modifiers;
			methodDeclaration.Parameters.MoveTo(operatorDeclaration.Parameters);
			methodDeclaration.Attributes.MoveTo(operatorDeclaration.Attributes);
			AddComment(operatorDeclaration, methodDef);
			return operatorDeclaration;
		}
		if (flag)
		{
			methodDeclaration.Modifiers |= Modifiers.Ref;
		}
		if (DnlibExtensions.HasIsReadOnlyAttribute(methodDef.Parameters.ReturnParameter.ParamDef))
		{
			methodDeclaration.Modifiers |= Modifiers.Readonly;
		}
		AddComment(methodDeclaration, methodDef);
		return methodDeclaration;
	}

	private bool IsExplicitInterfaceImplementation(MethodDef methodDef)
	{
		if (methodDef != null && methodDef.HasOverrides)
		{
			return methodDef.IsPrivate;
		}
		return false;
	}

	private IEnumerable<TypeParameterDeclaration> MakeTypeParameters(IEnumerable<GenericParam> genericParameters)
	{
		foreach (GenericParam genericParameter in genericParameters)
		{
			TypeParameterDeclaration typeParameterDeclaration = new TypeParameterDeclaration();
			typeParameterDeclaration.AddAnnotation(genericParameter);
			typeParameterDeclaration.NameToken = Identifier.Create(CleanName(genericParameter.Name)).WithAnnotation(Context.MetadataTextColorProvider.GetColor(genericParameter));
			if (genericParameter.IsContravariant)
			{
				typeParameterDeclaration.Variance = VarianceModifier.Contravariant;
			}
			else if (genericParameter.IsCovariant)
			{
				typeParameterDeclaration.Variance = VarianceModifier.Covariant;
			}
			ConvertCustomAttributes(Context.MetadataTextColorProvider, typeParameterDeclaration, genericParameter, context.Settings, stringBuilder);
			yield return typeParameterDeclaration;
		}
	}

	private IEnumerable<Constraint> MakeConstraints(IEnumerable<GenericParam> genericParameters)
	{
		foreach (GenericParam genericParameter in genericParameters)
		{
			Constraint constraint = new Constraint();
			constraint.TypeParameter = new SimpleType(CleanName(genericParameter.Name)).WithAnnotation(genericParameter);
			constraint.TypeParameter.IdentifierToken.WithAnnotation(genericParameter);
			if (genericParameter.HasReferenceTypeConstraint)
			{
				constraint.BaseTypes.Add(new PrimitiveType("class"));
			}
			if (genericParameter.HasNotNullableValueTypeConstraint)
			{
				constraint.BaseTypes.Add(new PrimitiveType("struct"));
			}
			foreach (GenericParamConstraint genericParamConstraint in genericParameter.GenericParamConstraints)
			{
				if (genericParamConstraint.Constraint != null && (!genericParameter.HasNotNullableValueTypeConstraint || !genericParamConstraint.Constraint.Compare(systemString, valueTypeString)))
				{
					constraint.BaseTypes.Add(ConvertType(genericParamConstraint.Constraint, stringBuilder));
				}
			}
			if (genericParameter.HasDefaultConstructorConstraint && !genericParameter.HasNotNullableValueTypeConstraint)
			{
				constraint.BaseTypes.Add(new PrimitiveType("new"));
			}
			if (constraint.BaseTypes.Any())
			{
				yield return constraint;
			}
		}
	}

	private ConstructorDeclaration CreateConstructor(MethodDef methodDef)
	{
		ConstructorDeclaration constructorDeclaration = new ConstructorDeclaration();
		constructorDeclaration.AddAnnotation(methodDef);
		constructorDeclaration.Modifiers = ConvertModifiers(methodDef);
		if (methodDef.IsStatic)
		{
			constructorDeclaration.Modifiers &= ~Modifiers.VisibilityMask;
		}
		constructorDeclaration.NameToken = Identifier.Create(CleanName(methodDef.DeclaringType.Name)).WithAnnotation(methodDef.DeclaringType);
		constructorDeclaration.Parameters.AddRange(MakeParameters(Context.MetadataTextColorProvider, methodDef, context.Settings, stringBuilder));
		AddMethodBody(constructorDeclaration, methodDef, constructorDeclaration.Parameters, valueParameterIsKeyword: false, MethodKind.Method);
		if (methodDef.IsStatic && methodDef.DeclaringType.IsBeforeFieldInit)
		{
			constructorDeclaration.InsertChildAfter(null, new Comment(" Note: this type is marked as 'beforefieldinit'."), Roles.Comment);
		}
		AddComment(constructorDeclaration, methodDef);
		return constructorDeclaration;
	}

	private Modifiers FixUpVisibility(Modifiers m)
	{
		Modifiers modifiers = m & Modifiers.VisibilityMask;
		if ((modifiers & Modifiers.Public) == Modifiers.Public)
		{
			return Modifiers.Public | (m & ~Modifiers.VisibilityMask);
		}
		if (modifiers == Modifiers.Private || modifiers == (Modifiers.Private | Modifiers.Protected))
		{
			return m;
		}
		return m & ~Modifiers.Private;
	}

	private EntityDeclaration CreateProperty(PropertyDef propDef)
	{
		PropertyDeclaration propertyDeclaration = new PropertyDeclaration();
		propertyDeclaration.AddAnnotation(propDef);
		MethodDef methodDef = propDef.GetMethod ?? propDef.SetMethod;
		Modifiers modifiers = Modifiers.None;
		Modifiers modifiers2 = Modifiers.None;
		if (IsExplicitInterfaceImplementation(methodDef))
		{
			propertyDeclaration.PrivateImplementationType = ConvertType(methodDef.Overrides.First().MethodDeclaration?.DeclaringType, stringBuilder);
		}
		else if (!propDef.DeclaringType.IsInterface)
		{
			modifiers = ConvertModifiers(propDef.GetMethod);
			modifiers2 = ConvertModifiers(propDef.SetMethod);
			propertyDeclaration.Modifiers = FixUpVisibility(modifiers | modifiers2);
			try
			{
				if (methodDef != null && methodDef.IsVirtual && !methodDef.IsNewSlot && (propDef.GetMethod == null || propDef.SetMethod == null))
				{
					foreach (PropertyDef item in TypesHierarchyHelpers.FindBaseProperties(propDef))
					{
						if (item.GetMethod != null && item.SetMethod != null)
						{
							Modifiers modifiers3 = ConvertModifiers(item.GetMethod) | ConvertModifiers(item.SetMethod);
							propertyDeclaration.Modifiers = FixUpVisibility((propertyDeclaration.Modifiers & ~Modifiers.VisibilityMask) | (modifiers3 & Modifiers.VisibilityMask));
							break;
						}
						MethodDef methodDef2 = item.GetMethod ?? item.SetMethod;
						if (methodDef2 != null && methodDef2.IsNewSlot)
						{
							break;
						}
					}
				}
			}
			catch (ResolveException)
			{
			}
		}
		propertyDeclaration.NameToken = Identifier.Create(CleanName(propDef.Name)).WithAnnotation(propDef);
		propertyDeclaration.ReturnType = ConvertType(propDef.PropertySig.GetRetType(), stringBuilder, propDef);
		bool flag = propDef.PropertySig.RetType.RemovePinnedAndModifiers().GetElementType() == ElementType.ByRef && UndoByRefToPointer(propertyDeclaration.ReturnType);
		if (propDef.GetMethod != null)
		{
			propertyDeclaration.Getter = new Accessor();
			AddMethodBody(propertyDeclaration.Getter, propDef.GetMethod, null, valueParameterIsKeyword: false, MethodKind.Property);
			propertyDeclaration.Getter.AddAnnotation(propDef.GetMethod);
			if ((modifiers & Modifiers.VisibilityMask) != (propertyDeclaration.Modifiers & Modifiers.VisibilityMask))
			{
				propertyDeclaration.Getter.Modifiers = modifiers & Modifiers.VisibilityMask;
			}
		}
		if (propDef.SetMethod != null)
		{
			propertyDeclaration.Setter = new Accessor();
			AddMethodBody(propertyDeclaration.Setter, propDef.SetMethod, null, valueParameterIsKeyword: true, MethodKind.Property);
			propertyDeclaration.Setter.AddAnnotation(propDef.SetMethod);
			Parameter parameter = propDef.SetMethod.Parameters.SkipNonNormal().LastOrDefault();
			if (parameter != null)
			{
				ConvertCustomAttributes(Context.MetadataTextColorProvider, propertyDeclaration.Setter, parameter.ParamDef, context.Settings, stringBuilder, "param");
				if (parameter.HasParamDef && parameter.ParamDef.HasMarshalType)
				{
					propertyDeclaration.Setter.Attributes.Add(new AttributeSection(ConvertMarshalInfo(parameter.ParamDef, propDef.Module, stringBuilder))
					{
						AttributeTarget = "param"
					});
				}
			}
			if ((modifiers2 & Modifiers.VisibilityMask) != (propertyDeclaration.Modifiers & Modifiers.VisibilityMask))
			{
				propertyDeclaration.Setter.Modifiers = modifiers2 & Modifiers.VisibilityMask;
			}
		}
		ConvertCustomAttributes(Context.MetadataTextColorProvider, propertyDeclaration, propDef, context.Settings, stringBuilder);
		EntityDeclaration entityDeclaration = propertyDeclaration;
		if (propDef.IsIndexer())
		{
			entityDeclaration = ConvertPropertyToIndexer(propertyDeclaration, propDef);
		}
		if (methodDef != null && !methodDef.HasOverrides && methodDef.DeclaringType != null && !methodDef.DeclaringType.IsInterface && methodDef.IsVirtual == methodDef.IsNewSlot)
		{
			SetNewModifier(entityDeclaration);
		}
		if (flag)
		{
			propertyDeclaration.Modifiers |= Modifiers.Ref;
		}
		if (DnlibExtensions.HasIsReadOnlyAttribute(methodDef.Parameters.ReturnParameter.ParamDef))
		{
			propertyDeclaration.Modifiers |= Modifiers.Readonly;
		}
		if (propDef.SetMethod != null)
		{
			AddComment(propertyDeclaration, propDef.SetMethod, "set");
		}
		if (propDef.GetMethod != null)
		{
			AddComment(propertyDeclaration, propDef.GetMethod, "get");
		}
		AddComment(entityDeclaration, propDef);
		return entityDeclaration;
	}

	private IndexerDeclaration ConvertPropertyToIndexer(PropertyDeclaration astProp, PropertyDef propDef)
	{
		IndexerDeclaration indexerDeclaration = new IndexerDeclaration();
		indexerDeclaration.CopyAnnotationsFrom(astProp);
		astProp.Attributes.MoveTo(indexerDeclaration.Attributes);
		indexerDeclaration.Modifiers = astProp.Modifiers;
		indexerDeclaration.PrivateImplementationType = astProp.PrivateImplementationType.Detach();
		indexerDeclaration.ReturnType = astProp.ReturnType.Detach();
		indexerDeclaration.Getter = astProp.Getter.Detach();
		indexerDeclaration.Setter = astProp.Setter.Detach();
		indexerDeclaration.Parameters.AddRange(MakeParameters(Context.MetadataTextColorProvider, propDef.GetParameters().ToList(), context.Settings, stringBuilder));
		return indexerDeclaration;
	}

	private EntityDeclaration CreateEvent(EventDef eventDef)
	{
		if ((eventDef.AddMethod != null && eventDef.AddMethod.IsAbstract) || (eventDef.AddMethod?.Body == null && eventDef.RemoveMethod?.Body == null && eventDef.InvokeMethod?.Body == null))
		{
			EventDeclaration eventDeclaration = new EventDeclaration();
			ConvertCustomAttributes(Context.MetadataTextColorProvider, eventDeclaration, eventDef, context.Settings, stringBuilder);
			eventDeclaration.AddAnnotation(eventDef);
			eventDeclaration.Variables.Add(new VariableInitializer(eventDef, CleanName(eventDef.Name)));
			eventDeclaration.ReturnType = ConvertType(eventDef.EventType, stringBuilder, eventDef);
			if (!eventDef.DeclaringType.IsInterface)
			{
				eventDeclaration.Modifiers = ConvertModifiers(eventDef.AddMethod);
			}
			if (eventDef.RemoveMethod != null)
			{
				AddComment(eventDeclaration, eventDef.RemoveMethod, "remove");
			}
			if (eventDef.AddMethod != null)
			{
				AddComment(eventDeclaration, eventDef.AddMethod, "add");
			}
			AddComment(eventDeclaration, eventDef);
			return eventDeclaration;
		}
		CustomEventDeclaration customEventDeclaration = new CustomEventDeclaration();
		ConvertCustomAttributes(Context.MetadataTextColorProvider, customEventDeclaration, eventDef, context.Settings, stringBuilder);
		customEventDeclaration.AddAnnotation(eventDef);
		customEventDeclaration.NameToken = Identifier.Create(CleanName(eventDef.Name)).WithAnnotation(eventDef);
		customEventDeclaration.ReturnType = ConvertType(eventDef.EventType, stringBuilder, eventDef);
		if (eventDef.AddMethod == null || !IsExplicitInterfaceImplementation(eventDef.AddMethod))
		{
			customEventDeclaration.Modifiers = ConvertModifiers(eventDef.AddMethod);
		}
		else
		{
			customEventDeclaration.PrivateImplementationType = ConvertType(eventDef.AddMethod.Overrides.First().MethodDeclaration?.DeclaringType, stringBuilder);
		}
		if (eventDef.AddMethod != null)
		{
			customEventDeclaration.AddAccessor = new Accessor().WithAnnotation(eventDef.AddMethod);
			AddMethodBody(customEventDeclaration.AddAccessor, eventDef.AddMethod, null, valueParameterIsKeyword: true, MethodKind.Event);
		}
		if (eventDef.RemoveMethod != null)
		{
			customEventDeclaration.RemoveAccessor = new Accessor().WithAnnotation(eventDef.RemoveMethod);
			AddMethodBody(customEventDeclaration.RemoveAccessor, eventDef.RemoveMethod, null, valueParameterIsKeyword: true, MethodKind.Event);
		}
		MethodDef methodDef = eventDef.AddMethod ?? eventDef.RemoveMethod;
		if (methodDef != null && methodDef.IsVirtual == methodDef.IsNewSlot)
		{
			SetNewModifier(customEventDeclaration);
		}
		if (eventDef.RemoveMethod != null)
		{
			AddComment(customEventDeclaration, eventDef.RemoveMethod, "remove");
		}
		if (eventDef.AddMethod != null)
		{
			AddComment(customEventDeclaration, eventDef.AddMethod, "add");
		}
		AddComment(customEventDeclaration, eventDef);
		return customEventDeclaration;
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

	private void ClearCurrentMethodState()
	{
		context.CurrentMethodIsAsync = false;
		context.CurrentMethodIsYieldReturn = false;
	}

	private void AddMethodBody(EntityDeclaration methodNode, MethodDef method, IEnumerable<ParameterDeclaration> parameters, bool valueParameterIsKeyword, MethodKind methodKind)
	{
		ClearCurrentMethodState();
		if (method.Body == null)
		{
			ConvertAttributes(methodNode, method);
			return;
		}
		DecompiledBodyKind decompiledBodyKind = GetDecompiledBodyKind?.Invoke(this, method) ?? DecompiledBodyKind.Full;
		if (decompiledBodyKind == DecompiledBodyKind.Empty && methodKind == MethodKind.Event)
		{
			decompiledBodyKind = DecompiledBodyKind.Full;
		}
		switch (decompiledBodyKind)
		{
		case DecompiledBodyKind.Full:
		{
			BlockStatement blockStatement;
			MethodDebugInfoBuilder builder;
			try
			{
				if (this.context.AsyncMethodBodyDecompilation)
				{
					parameters = parameters?.ToArray();
					DecompilerContext context = this.context.Clone();
					Task<AsyncMethodBodyResult> item2 = Task.Run(delegate
					{
						if (context.CancellationToken.IsCancellationRequested)
						{
							return default(AsyncMethodBodyResult);
						}
						AsyncMethodBodyDecompilationState asyncMethodBodyDecompilationState = GetAsyncMethodBodyDecompilationState();
						StringBuilder sb = asyncMethodBodyDecompilationState.StringBuilder;
						AutoPropertyProvider autoPropertyProvider = new AutoPropertyProvider();
						BlockStatement bs;
						MethodDebugInfoBuilder stmtsBuilder2;
						try
						{
							bs = AstMethodBodyBuilder.CreateMethodBody(method, context, autoPropertyProvider, parameters, valueParameterIsKeyword, sb, out stmtsBuilder2);
						}
						catch (OperationCanceledException)
						{
							throw;
						}
						catch (Exception ex4)
						{
							CreateBadMethod(method, ex4, out bs, out stmtsBuilder2);
						}
						Return(asyncMethodBodyDecompilationState);
						return new AsyncMethodBodyResult(methodNode, method, bs, stmtsBuilder2, context.variableMap, context.CurrentMethodIsAsync, context.CurrentMethodIsYieldReturn);
					}, context.CancellationToken);
					methodBodyTasks.Add(item2);
				}
				else
				{
					BlockStatement newChild = AstMethodBodyBuilder.CreateMethodBody(method, this.context, AutoPropertyProvider, parameters, valueParameterIsKeyword, stringBuilder, out var stmtsBuilder);
					if (this.context.CurrentMethodIsAsync)
					{
						methodNode.Modifiers |= Modifiers.Async;
					}
					methodNode.SetChildByRole(Roles.Body, newChild);
					methodNode.AddAnnotation(stmtsBuilder);
					methodNode.AddAnnotation(this.context.variableMap);
					ConvertAttributes(methodNode, method);
				}
				break;
			}
			catch (OperationCanceledException)
			{
				throw;
			}
			catch (Exception ex2)
			{
				CreateBadMethod(method, ex2, out blockStatement, out builder);
			}
			methodNode.SetChildByRole(Roles.Body, blockStatement);
			methodNode.AddAnnotation(builder);
			ConvertAttributes(methodNode, method);
			break;
		}
		case DecompiledBodyKind.Empty:
		{
			BlockStatement blockStatement = new BlockStatement();
			if (method.IsInstanceConstructor)
			{
				MethodDef baseConstructorForEmptyBody = GetBaseConstructorForEmptyBody(method);
				if (baseConstructorForEmptyBody != null)
				{
					MethodBaseSig methodBaseSig = GetMethodBaseSig(method.DeclaringType.BaseType, baseConstructorForEmptyBody.MethodSig);
					List<Expression> list = new List<Expression>();
					foreach (TypeSig item3 in methodBaseSig.Params)
					{
						DefaultValueExpression item = new DefaultValueExpression(ConvertType(item3.RemovePinnedAndModifiers(), stringBuilder));
						list.Add(item);
					}
					ExpressionStatement element = new ExpressionStatement(new InvocationExpression(new MemberReferenceExpression(new BaseReferenceExpression(), method.Name), list));
					blockStatement.Statements.Add(element);
				}
				if (method.DeclaringType.IsValueType && !method.DeclaringType.IsEnum)
				{
					foreach (FieldDef field in method.DeclaringType.Fields)
					{
						if (!field.IsStatic)
						{
							DefaultValueExpression right = new DefaultValueExpression(ConvertType(field.FieldType.RemovePinnedAndModifiers(), stringBuilder));
							ExpressionStatement element2 = new ExpressionStatement(new AssignmentExpression(new MemberReferenceExpression(new ThisReferenceExpression(), field.Name), right));
							blockStatement.Statements.Add(element2);
						}
					}
				}
			}
			if (parameters != null)
			{
				foreach (ParameterDeclaration parameter2 in parameters)
				{
					if (parameter2.ParameterModifier == ParameterModifier.Out)
					{
						Parameter parameter = parameter2.Annotation<Parameter>();
						DefaultValueExpression right2 = new DefaultValueExpression(ConvertType(parameter.Type.RemovePinnedAndModifiers().Next, stringBuilder));
						ExpressionStatement element3 = new ExpressionStatement(new AssignmentExpression(new IdentifierExpression(parameter2.Name), right2));
						blockStatement.Statements.Add(element3);
					}
				}
			}
			if (method.MethodSig.GetRetType().RemovePinnedAndModifiers().GetElementType() != ElementType.Void)
			{
				if (method.MethodSig.GetRetType().RemovePinnedAndModifiers().GetElementType() == ElementType.ByRef)
				{
					ThrowStatement element4 = new ThrowStatement(new NullReferenceExpression());
					blockStatement.Statements.Add(element4);
				}
				else
				{
					ReturnStatement element5 = new ReturnStatement(new DefaultValueExpression(ConvertType(method.MethodSig.GetRetType().RemovePinnedAndModifiers(), stringBuilder)));
					blockStatement.Statements.Add(element5);
				}
			}
			methodNode.SetChildByRole(Roles.Body, blockStatement);
			ConvertAttributes(methodNode, method);
			break;
		}
		case DecompiledBodyKind.None:
			ConvertAttributes(methodNode, method);
			break;
		default:
			throw new InvalidOperationException();
		}
	}

	private void CreateBadMethod(MethodDef method, Exception ex, out BlockStatement bs, out MethodDebugInfoBuilder builder)
	{
		string content = string.Format("{0}An exception occurred when decompiling this method ({1:X8}){0}{0}{2}{0}", Environment.NewLine, method.MDToken.ToUInt32(), ex.ToString());
		bs = new BlockStatement();
		EmptyStatement emptyStatement = new EmptyStatement();
		if (method.Body != null)
		{
			emptyStatement.AddAnnotation(new List<ILSpan>
			{
				new ILSpan(0u, (uint)method.Body.GetCodeSize())
			});
		}
		bs.Statements.Add(emptyStatement);
		bs.InsertChildAfter(null, new Comment(content, CommentType.MultiLine), Roles.Comment);
		builder = new MethodDebugInfoBuilder(context.SettingsVersion, StateMachineKind.None, method, null, method.Body.Variables.Select((Local a) => new SourceLocal(a, CreateLocalName(a), a.Type, SourceVariableFlags.None)).ToArray(), null, null);
	}

	private static string CreateLocalName(Local local)
	{
		string name = local.Name;
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		return "V_" + local.Index;
	}

	private static MethodDef GetBaseConstructorForEmptyBody(MethodDef method)
	{
		TypeDef typeDef = method.DeclaringType.BaseType.ResolveTypeDef();
		if (typeDef == null)
		{
			return null;
		}
		return GetAccessibleConstructorForEmptyBody(typeDef, method.DeclaringType);
	}

	private static MethodDef GetAccessibleConstructorForEmptyBody(TypeDef baseType, TypeDef type)
	{
		List<MethodDef> list = new List<MethodDef>(baseType.FindConstructors());
		if (list.Count == 0)
		{
			return null;
		}
		bool isAssem = baseType.Module.Assembly == type.Module.Assembly || type.Module.Assembly.IsFriendAssemblyOf(baseType.Module.Assembly);
		list.Sort(delegate(MethodDef a, MethodDef b)
		{
			int num = GetAccessForEmptyBody(a, isAssem) - GetAccessForEmptyBody(b, isAssem);
			if (num != 0)
			{
				return num;
			}
			num = GetParamTypeOrderForEmtpyBody(a) - GetParamTypeOrderForEmtpyBody(b);
			return (num != 0) ? num : (a.Parameters.Count - b.Parameters.Count);
		});
		return list[0];
	}

	private static int GetParamTypeOrderForEmtpyBody(MethodDef m)
	{
		if (!m.MethodSig.Params.Any((TypeSig a) => a.RemovePinnedAndModifiers() is ByRefSig))
		{
			return 0;
		}
		return 1;
	}

	private static int GetAccessForEmptyBody(MethodDef m, bool isAssem)
	{
		switch (m.Access)
		{
		case MethodAttributes.Public:
			return 0;
		case MethodAttributes.FamORAssem:
			return 0;
		case MethodAttributes.Family:
			return 0;
		case MethodAttributes.Assembly:
			if (!isAssem)
			{
				return 1;
			}
			return 0;
		case MethodAttributes.FamANDAssem:
			if (!isAssem)
			{
				return 1;
			}
			return 0;
		case MethodAttributes.Private:
			return 2;
		case MethodAttributes.PrivateScope:
			return 3;
		default:
			return 3;
		}
	}

	private static bool HasConstant(IHasConstant hc, out CustomAttribute constantAttribute)
	{
		constantAttribute = null;
		if (hc.Constant != null)
		{
			return true;
		}
		foreach (CustomAttribute customAttribute in hc.CustomAttributes)
		{
			for (ITypeDefOrRef typeDefOrRef = customAttribute.AttributeType; typeDefOrRef != null; typeDefOrRef = typeDefOrRef.GetBaseType())
			{
				string fullName = typeDefOrRef.FullName;
				if (fullName == "System.Runtime.CompilerServices.CustomConstantAttribute" || fullName == "System.Runtime.CompilerServices.DecimalConstantAttribute")
				{
					constantAttribute = customAttribute;
					return true;
				}
			}
		}
		return false;
	}

	private static bool TryGetConstant(IHasConstant hc, out object constant)
	{
		if (!HasConstant(hc, out var constantAttribute))
		{
			constant = null;
			return false;
		}
		if (hc.Constant != null)
		{
			constant = hc.Constant.Value;
			return true;
		}
		if (constantAttribute != null && constantAttribute.TypeFullName == "System.Runtime.CompilerServices.DecimalConstantAttribute" && TryGetDecimalConstantAttributeValue(constantAttribute, out var value))
		{
			constant = value;
			return true;
		}
		constant = null;
		return false;
	}

	private static bool TryGetDecimalConstantAttributeValue(CustomAttribute ca, out decimal value)
	{
		value = 0m;
		if (ca.ConstructorArguments.Count != 5)
		{
			return false;
		}
		if (!(ca.ConstructorArguments[0].Value is byte scale))
		{
			return false;
		}
		if (!(ca.ConstructorArguments[1].Value is byte b))
		{
			return false;
		}
		int hi;
		int mid;
		int lo;
		if (ca.ConstructorArguments[2].Value is int)
		{
			if (!(ca.ConstructorArguments[2].Value is int))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[3].Value is int))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[4].Value is int))
			{
				return false;
			}
			hi = (int)ca.ConstructorArguments[2].Value;
			mid = (int)ca.ConstructorArguments[3].Value;
			lo = (int)ca.ConstructorArguments[4].Value;
		}
		else
		{
			if (!(ca.ConstructorArguments[2].Value is uint))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[2].Value is uint))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[3].Value is uint))
			{
				return false;
			}
			if (!(ca.ConstructorArguments[4].Value is uint))
			{
				return false;
			}
			hi = (int)(uint)ca.ConstructorArguments[2].Value;
			mid = (int)(uint)ca.ConstructorArguments[3].Value;
			lo = (int)(uint)ca.ConstructorArguments[4].Value;
		}
		try
		{
			value = new decimal(lo, mid, hi, b > 0, scale);
			return true;
		}
		catch (ArgumentOutOfRangeException)
		{
			return false;
		}
	}

	private FieldDeclaration CreateField(FieldDef fieldDef)
	{
		FieldDeclaration fieldDeclaration = new FieldDeclaration();
		fieldDeclaration.AddAnnotation(fieldDef);
		VariableInitializer variableInitializer = new VariableInitializer(fieldDef, CleanName(fieldDef.Name));
		fieldDeclaration.AddChild(variableInitializer, Roles.Variable);
		fieldDeclaration.ReturnType = ConvertType(fieldDef.FieldType, stringBuilder, fieldDef);
		fieldDeclaration.Modifiers = ConvertModifiers(fieldDef);
		if (TryGetConstant(fieldDef, out var constant))
		{
			variableInitializer.Initializer = CreateExpressionForConstant(constant, fieldDef.FieldType, stringBuilder, fieldDef.DeclaringType.IsEnum);
		}
		ConvertAttributes(Context.MetadataTextColorProvider, fieldDeclaration, fieldDef, context.Settings, stringBuilder);
		SetNewModifier(fieldDeclaration);
		AddComment(fieldDeclaration, fieldDef);
		return fieldDeclaration;
	}

	private static object ConvertConstant(TypeSig type, object constant)
	{
		if (type == null || constant == null)
		{
			return constant;
		}
		TypeCode typeCode = Type.GetTypeCode(constant.GetType());
		if (typeCode < TypeCode.Char || typeCode > TypeCode.Double)
		{
			return constant;
		}
		typeCode = ToTypeCode(type);
		if (typeCode >= TypeCode.Char && typeCode <= TypeCode.Double)
		{
			return CSharpPrimitiveCast.Cast(typeCode, constant, checkForOverflow: false);
		}
		return constant;
	}

	private static TypeCode ToTypeCode(TypeSig type)
	{
		return type.GetElementType() switch
		{
			ElementType.Boolean => TypeCode.Boolean, 
			ElementType.Char => TypeCode.Char, 
			ElementType.I1 => TypeCode.SByte, 
			ElementType.U1 => TypeCode.Byte, 
			ElementType.I2 => TypeCode.Int16, 
			ElementType.U2 => TypeCode.UInt16, 
			ElementType.I4 => TypeCode.Int32, 
			ElementType.U4 => TypeCode.UInt32, 
			ElementType.I8 => TypeCode.Int64, 
			ElementType.U8 => TypeCode.UInt64, 
			ElementType.R4 => TypeCode.Single, 
			ElementType.R8 => TypeCode.Double, 
			ElementType.String => TypeCode.String, 
			ElementType.Object => TypeCode.Object, 
			_ => TypeCode.Empty, 
		};
	}

	private static Expression CreateExpressionForConstant(object constant, TypeSig type, StringBuilder sb, bool isEnumMemberDeclaration = false)
	{
		constant = ConvertConstant(type, constant);
		if (constant == null)
		{
			if (!DnlibExtensions.IsValueType(type) && !(type is GenericSig))
			{
				return new NullReferenceExpression();
			}
			if (!(type is GenericInstSig genericInstSig) || !genericInstSig.GenericType.IsSystemNullable())
			{
				return new DefaultValueExpression(ConvertType(type, sb));
			}
			return new NullReferenceExpression();
		}
		TypeCode typeCode = Type.GetTypeCode(constant.GetType());
		if (typeCode >= TypeCode.SByte && typeCode <= TypeCode.UInt64 && !isEnumMemberDeclaration)
		{
			return MakePrimitive((long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constant, checkForOverflow: false), type.ToTypeDefOrRef(), sb);
		}
		return new PrimitiveExpression(constant);
	}

	public static IEnumerable<ParameterDeclaration> MakeParameters(MetadataTextColorProvider metadataTextColorProvider, MethodDef method, DecompilerSettings settings, StringBuilder sb, bool isLambda = false)
	{
		IEnumerable<ParameterDeclaration> enumerable = MakeParameters(metadataTextColorProvider, method.Parameters, settings, sb, isLambda);
		if (method.CallingConvention == dnlib.DotNet.CallingConvention.VarArg || method.CallingConvention == dnlib.DotNet.CallingConvention.NativeVarArg)
		{
			ParameterDeclaration parameterDeclaration = new ParameterDeclaration
			{
				Type = new PrimitiveType("__arglist"),
				NameToken = Identifier.Create("").WithAnnotation(BoxedTextColor.Parameter)
			};
			return enumerable.Concat(new ParameterDeclaration[1] { parameterDeclaration });
		}
		return enumerable;
	}

	internal static bool UndoByRefToPointer(AstType type)
	{
		if (type is ComposedType { PointerRank: >0 } composedType)
		{
			composedType.PointerRank--;
			return true;
		}
		return false;
	}

	private static IEnumerable<ParameterDeclaration> MakeParameters(MetadataTextColorProvider metadataTextColorProvider, IEnumerable<Parameter> paramCol, DecompilerSettings settings, StringBuilder sb, bool isLambda = false)
	{
		foreach (Parameter item in paramCol)
		{
			if (item.IsHiddenThisParameter)
			{
				continue;
			}
			ParameterDeclaration parameterDeclaration = new ParameterDeclaration();
			parameterDeclaration.AddAnnotation(item);
			TypeSig typeSig = item.Type.RemovePinnedAndModifiers();
			if (!isLambda || !typeSig.ContainsAnonymousType())
			{
				parameterDeclaration.Type = ConvertType(typeSig, sb, item.ParamDef);
			}
			parameterDeclaration.NameToken = Identifier.Create(item.Name).WithAnnotation(item);
			if (typeSig is ByRefSig)
			{
				ParamDef paramDef = item.ParamDef;
				if (paramDef == null)
				{
					parameterDeclaration.ParameterModifier = ParameterModifier.Ref;
				}
				else if (!paramDef.IsIn && paramDef.IsOut)
				{
					parameterDeclaration.ParameterModifier = ParameterModifier.Out;
				}
				else if (DnlibExtensions.HasIsReadOnlyAttribute(paramDef))
				{
					parameterDeclaration.ParameterModifier = ParameterModifier.In;
				}
				else
				{
					parameterDeclaration.ParameterModifier = ParameterModifier.Ref;
				}
				UndoByRefToPointer(parameterDeclaration.Type);
			}
			if (item.HasParamDef && item.ParamDef.HasCustomAttributes && item.ParamDef.IsDefined(systemString, paramArrayAttributeString))
			{
				parameterDeclaration.ParameterModifier = ParameterModifier.Params;
			}
			if (item.HasParamDef && item.ParamDef.IsOptional && TryGetConstant(item.ParamDef, out var constant))
			{
				parameterDeclaration.DefaultExpression = CreateExpressionForConstant(constant, typeSig, sb);
			}
			ConvertCustomAttributes(metadataTextColorProvider, parameterDeclaration, item.ParamDef, settings, sb);
			ModuleDef moduleDef = ((item.Method == null) ? null : item.Method.Module);
			if (moduleDef != null && item.HasParamDef && item.ParamDef.HasMarshalType)
			{
				parameterDeclaration.Attributes.Add(new AttributeSection(ConvertMarshalInfo(item.ParamDef, moduleDef, sb)));
			}
			if (moduleDef != null && item.HasParamDef && parameterDeclaration.ParameterModifier != ParameterModifier.Out && parameterDeclaration.ParameterModifier != ParameterModifier.In)
			{
				if (item.ParamDef.IsIn)
				{
					parameterDeclaration.Attributes.Add(new AttributeSection(CreateNonCustomAttribute(typeof(InAttribute), moduleDef, GetSystemRuntimeInteropServicesAssemblyRef(moduleDef))));
				}
				if (item.ParamDef.IsOut)
				{
					parameterDeclaration.Attributes.Add(new AttributeSection(CreateNonCustomAttribute(typeof(OutAttribute), moduleDef, moduleDef.CorLibTypes.AssemblyRef)));
				}
			}
			yield return parameterDeclaration;
		}
	}

	private void ConvertAttributes(EntityDeclaration attributedNode, TypeDef typeDef)
	{
		ConvertCustomAttributes(Context.MetadataTextColorProvider, attributedNode, typeDef, context.Settings, stringBuilder);
		ConvertSecurityAttributes(Context.MetadataTextColorProvider, attributedNode, typeDef, stringBuilder);
		if (typeDef.IsSerializable)
		{
			attributedNode.Attributes.Add(new AttributeSection(CreateNonCustomAttribute_SystemRuntimeSerializationFormatters(typeof(SerializableAttribute))));
		}
		if (typeDef.IsImport)
		{
			attributedNode.Attributes.Add(new AttributeSection(CreateNonCustomAttribute_SystemRuntimeInteropServices(typeof(ComImportAttribute))));
		}
		LayoutKind layoutKind = LayoutKind.Auto;
		switch (typeDef.Attributes & TypeAttributes.LayoutMask)
		{
		case TypeAttributes.SequentialLayout:
			layoutKind = LayoutKind.Sequential;
			break;
		case TypeAttributes.ExplicitLayout:
			layoutKind = LayoutKind.Explicit;
			break;
		}
		CharSet charSet = CharSet.None;
		switch (typeDef.Attributes & TypeAttributes.StringFormatMask)
		{
		case TypeAttributes.NotPublic:
			charSet = CharSet.Ansi;
			break;
		case TypeAttributes.AutoClass:
			charSet = CharSet.Auto;
			break;
		case TypeAttributes.UnicodeClass:
			charSet = CharSet.Unicode;
			break;
		}
		bool flag = DnlibExtensions.IsValueType(typeDef);
		LayoutKind layoutKind2 = ((!flag || typeDef.IsEnum) ? LayoutKind.Auto : LayoutKind.Sequential);
		if (layoutKind != layoutKind2 || charSet != CharSet.Ansi || ShowClassLayout(typeDef, flag))
		{
			Type typeFromHandle = typeof(StructLayoutAttribute);
			ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute_SystemRuntime(typeFromHandle);
			attribute.Arguments.Add(CreateEnumIdentifierExpression(typeof(LayoutKind), layoutKind.ToString(), GetSystemRuntimeInteropServicesAssemblyRef(typeDef.Module)));
			ModuleDef module = GetModule();
			if (charSet != CharSet.Ansi)
			{
				attribute.AddNamedArgument(module, typeFromHandle, null, typeof(CharSet), null, "CharSet", CreateEnumIdentifierExpression(typeof(CharSet), charSet.ToString(), typeDef.Module.CorLibTypes.AssemblyRef));
			}
			if (typeDef.PackingSize != ushort.MaxValue && typeDef.PackingSize > 0)
			{
				attribute.AddNamedArgument(module, typeFromHandle, null, typeof(int), null, "Pack", new PrimitiveExpression((int)typeDef.PackingSize));
			}
			if (typeDef.ClassSize != uint.MaxValue && typeDef.ClassSize != 0)
			{
				attribute.AddNamedArgument(module, typeFromHandle, null, typeof(int), null, "Size", new PrimitiveExpression((int)typeDef.ClassSize));
			}
			attributedNode.Attributes.Add(new AttributeSection(attribute));
		}
	}

	private static bool ShowClassLayout(TypeDef td, bool isValueType)
	{
		if (!isValueType)
		{
			return td.HasClassLayout;
		}
		if (td.HasClassLayout)
		{
			foreach (FieldDef field in td.Fields)
			{
				if (!field.IsStatic)
				{
					return true;
				}
			}
		}
		return false;
	}

	private ModuleDef GetModule()
	{
		if (context.CurrentMethod != null && context.CurrentMethod.Module != null)
		{
			return context.CurrentMethod.Module;
		}
		if (context.CurrentType != null && context.CurrentType.Module != null)
		{
			return context.CurrentType.Module;
		}
		if (context.CurrentModule != null)
		{
			return context.CurrentModule;
		}
		return null;
	}

	private MemberReferenceExpression CreateEnumIdentifierExpression(Type enumType, string fieldName, AssemblyRef enumTypeAssemblyRef)
	{
		ModuleDef module = GetModule();
		TypeRef typeRef = null;
		Expression expression;
		if (module != null)
		{
			typeRef = module.UpdateRowId(new TypeRefUser(module, enumType.Namespace, enumType.Name, enumTypeAssemblyRef));
			AstType type = ConvertType(typeRef, stringBuilder);
			expression = new TypeReferenceExpression(type);
		}
		else
		{
			expression = new IdentifierExpression(enumType.Name);
		}
		MemberReferenceExpression memberReferenceExpression = expression.Member(fieldName, null);
		if (module != null)
		{
			MemberRef annotation;
			memberReferenceExpression.AddAnnotation(annotation = new MemberRefUser(module, fieldName, new FieldSig(new ValueTypeSig(typeRef)), typeRef));
			memberReferenceExpression.MemberNameToken.AddAnnotation(annotation);
		}
		return memberReferenceExpression;
	}

	private void ConvertAttributes(EntityDeclaration attributedNode, MethodDef methodDef)
	{
		ConvertAttributes(attributedNode, methodDef, context.CurrentMethodIsAsync, context.CurrentMethodIsYieldReturn);
	}

	private void ConvertAttributes(EntityDeclaration attributedNode, MethodDef methodDef, bool methodIsAsync, bool methodIsIterator)
	{
		ConvertCustomAttributesFlags convertCustomAttributesFlags = ConvertCustomAttributesFlags.None;
		if (methodIsAsync)
		{
			convertCustomAttributesFlags |= ConvertCustomAttributesFlags.IsAsync;
		}
		if (methodIsIterator)
		{
			convertCustomAttributesFlags |= ConvertCustomAttributesFlags.IsYieldReturn;
		}
		ConvertCustomAttributes(Context.MetadataTextColorProvider, attributedNode, methodDef, context.Settings, stringBuilder, null, convertCustomAttributesFlags);
		ConvertSecurityAttributes(Context.MetadataTextColorProvider, attributedNode, methodDef, stringBuilder);
		MethodImplAttributes methodImplAttributes = methodDef.ImplAttributes & ~MethodImplAttributes.CodeTypeMask;
		if (methodDef.HasImplMap)
		{
			ImplMap implMap = methodDef.ImplMap;
			Type typeFromHandle = typeof(DllImportAttribute);
			ModuleDef module = GetModule();
			AssemblyRef systemRuntimeInteropServicesAssemblyRef = GetSystemRuntimeInteropServicesAssemblyRef(methodDef.Module);
			ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute_SystemRuntimeInteropServices(typeFromHandle);
			attribute.Arguments.Add(new PrimitiveExpression((implMap.Module == null) ? string.Empty : implMap.Module.Name.String));
			if (implMap.IsBestFitDisabled)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(bool), null, "BestFitMapping", new PrimitiveExpression(false));
			}
			if (implMap.IsBestFitEnabled)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(bool), null, "BestFitMapping", new PrimitiveExpression(true));
			}
			System.Runtime.InteropServices.CallingConvention callingConvention = (implMap.Attributes & PInvokeAttributes.CallConvMask) switch
			{
				PInvokeAttributes.CallConvCdecl => System.Runtime.InteropServices.CallingConvention.Cdecl, 
				PInvokeAttributes.CallConvFastcall => System.Runtime.InteropServices.CallingConvention.FastCall, 
				PInvokeAttributes.CallConvStdcall => System.Runtime.InteropServices.CallingConvention.StdCall, 
				PInvokeAttributes.CallConvThiscall => System.Runtime.InteropServices.CallingConvention.ThisCall, 
				PInvokeAttributes.CallConvWinapi => System.Runtime.InteropServices.CallingConvention.Winapi, 
				_ => (System.Runtime.InteropServices.CallingConvention)0, 
			};
			if (callingConvention != System.Runtime.InteropServices.CallingConvention.Winapi)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(System.Runtime.InteropServices.CallingConvention), GetSystemRuntimeInteropServicesAssemblyRef(module), "CallingConvention", CreateEnumIdentifierExpression(typeof(System.Runtime.InteropServices.CallingConvention), callingConvention.ToString(), GetSystemRuntimeInteropServicesAssemblyRef(methodDef.Module)));
			}
			CharSet charSet = CharSet.None;
			switch (implMap.Attributes & PInvokeAttributes.CharSetMask)
			{
			case PInvokeAttributes.CharSetAnsi:
				charSet = CharSet.Ansi;
				break;
			case PInvokeAttributes.CharSetMask:
				charSet = CharSet.Auto;
				break;
			case PInvokeAttributes.CharSetUnicode:
				charSet = CharSet.Unicode;
				break;
			}
			if (charSet != CharSet.None)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(CharSet), null, "CharSet", CreateEnumIdentifierExpression(typeof(CharSet), charSet.ToString(), GetSystemRuntimeInteropServicesAssemblyRef(methodDef.Module)));
			}
			if (!UTF8String.IsNullOrEmpty(implMap.Name) && implMap.Name != methodDef.Name)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(string), null, "EntryPoint", new PrimitiveExpression(implMap.Name.String));
			}
			if (implMap.IsNoMangle)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(bool), null, "ExactSpelling", new PrimitiveExpression(true));
			}
			if ((methodImplAttributes & MethodImplAttributes.PreserveSig) == MethodImplAttributes.PreserveSig)
			{
				methodImplAttributes &= ~MethodImplAttributes.PreserveSig;
			}
			else
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(bool), null, "PreserveSig", new PrimitiveExpression(false));
			}
			if (implMap.SupportsLastError)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(bool), null, "SetLastError", new PrimitiveExpression(true));
			}
			if (implMap.IsThrowOnUnmappableCharDisabled)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(bool), null, "ThrowOnUnmappableChar", new PrimitiveExpression(false));
			}
			if (implMap.IsThrowOnUnmappableCharEnabled)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(bool), null, "ThrowOnUnmappableChar", new PrimitiveExpression(true));
			}
			attributedNode.Attributes.Add(new AttributeSection(attribute));
		}
		if (methodImplAttributes == MethodImplAttributes.PreserveSig)
		{
			attributedNode.Attributes.Add(new AttributeSection(CreateNonCustomAttribute_SystemRuntimeInteropServices(typeof(PreserveSigAttribute))));
			methodImplAttributes = MethodImplAttributes.IL;
		}
		if (methodImplAttributes != MethodImplAttributes.IL)
		{
			ICSharpCode.NRefactory.CSharp.Attribute attribute2 = CreateNonCustomAttribute_SystemRuntime(typeof(MethodImplAttribute));
			TypeRef typeRef = methodDef.Module.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "MethodImplOptions");
			attribute2.Arguments.Add(MakePrimitive((long)methodImplAttributes, typeRef, stringBuilder));
			attributedNode.Attributes.Add(new AttributeSection(attribute2));
		}
		ConvertAttributes(attributedNode, methodDef.Parameters.ReturnParameter, methodDef.Module);
	}

	private void ConvertAttributes(EntityDeclaration attributedNode, Parameter methodReturnType, ModuleDef module)
	{
		ConvertCustomAttributes(Context.MetadataTextColorProvider, attributedNode, methodReturnType.ParamDef, context.Settings, stringBuilder, "return");
		if (methodReturnType.HasParamDef && methodReturnType.ParamDef.HasMarshalType)
		{
			ICSharpCode.NRefactory.CSharp.Attribute attr = ConvertMarshalInfo(methodReturnType.ParamDef, module, stringBuilder);
			attributedNode.Attributes.Add(new AttributeSection(attr)
			{
				AttributeTarget = "return"
			});
		}
	}

	internal static void ConvertAttributes(MetadataTextColorProvider metadataTextColorProvider, EntityDeclaration attributedNode, FieldDef fieldDef, DecompilerSettings settings, StringBuilder sb, string attributeTarget = null)
	{
		ConvertCustomAttributes(metadataTextColorProvider, attributedNode, fieldDef, settings, sb);
		if (fieldDef.HasLayoutInfo && fieldDef.FieldOffset.HasValue)
		{
			ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute(typeof(FieldOffsetAttribute), fieldDef.Module, GetSystemRuntimeInteropServicesAssemblyRef(fieldDef.Module));
			attribute.Arguments.Add(new PrimitiveExpression((int)fieldDef.FieldOffset.Value));
			attributedNode.Attributes.Add(new AttributeSection(attribute)
			{
				AttributeTarget = attributeTarget
			});
		}
		if (fieldDef.IsNotSerialized)
		{
			ICSharpCode.NRefactory.CSharp.Attribute attr = CreateNonCustomAttribute(typeof(NonSerializedAttribute), fieldDef.Module, GetSystemRuntimeSerializationFormattersAssemblyRef(fieldDef.Module));
			attributedNode.Attributes.Add(new AttributeSection(attr)
			{
				AttributeTarget = attributeTarget
			});
		}
		if (fieldDef.HasMarshalType)
		{
			attributedNode.Attributes.Add(new AttributeSection(ConvertMarshalInfo(fieldDef, fieldDef.Module, sb))
			{
				AttributeTarget = attributeTarget
			});
		}
	}

	private static AssemblyRef GetSystemRuntimeInteropServicesAssemblyRef(ModuleDef module)
	{
		if (module == null)
		{
			return null;
		}
		return module.GetAssemblyRefs().FirstOrDefault((AssemblyRef a) => a.Name == systemRuntimeInteropServicesName && contractsPublicKeyToken.Equals(a.PublicKeyOrToken.Token)) ?? module.CorLibTypes.AssemblyRef;
	}

	private static AssemblyRef GetSystemRuntimeSerializationFormattersAssemblyRef(ModuleDef module)
	{
		if (module == null)
		{
			return null;
		}
		return module.GetAssemblyRefs().FirstOrDefault((AssemblyRef a) => a.Name == systemRuntimeSerializationFormattersName && contractsPublicKeyToken.Equals(a.PublicKeyOrToken.Token)) ?? module.CorLibTypes.AssemblyRef;
	}

	private static ICSharpCode.NRefactory.CSharp.Attribute ConvertMarshalInfo(IHasFieldMarshal marshalInfoProvider, ModuleDef module, StringBuilder sb)
	{
		MarshalType marshalType = marshalInfoProvider.MarshalType;
		Type typeFromHandle = typeof(MarshalAsAttribute);
		AssemblyRef systemRuntimeInteropServicesAssemblyRef = GetSystemRuntimeInteropServicesAssemblyRef(module);
		ICSharpCode.NRefactory.CSharp.Attribute attribute = CreateNonCustomAttribute(typeFromHandle, module, systemRuntimeInteropServicesAssemblyRef);
		TypeRefUser type = module.UpdateRowId(new TypeRefUser(module, systemRuntimeInteropServicesName, "UnmanagedType", systemRuntimeInteropServicesAssemblyRef));
		attribute.Arguments.Add(MakePrimitive((int)marshalType.NativeType, type, sb));
		if (marshalType is FixedArrayMarshalType fixedArrayMarshalType)
		{
			if (fixedArrayMarshalType.IsSizeValid)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(int), null, "SizeConst", new PrimitiveExpression(fixedArrayMarshalType.Size));
			}
			if (fixedArrayMarshalType.IsElementTypeValid)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(UnmanagedType), systemRuntimeInteropServicesAssemblyRef, "ArraySubType", MakePrimitive((int)fixedArrayMarshalType.ElementType, type, sb));
			}
		}
		if (marshalType is SafeArrayMarshalType safeArrayMarshalType)
		{
			if (safeArrayMarshalType.IsVariantTypeValid)
			{
				TypeRefUser type2 = module.UpdateRowId(new TypeRefUser(module, systemRuntimeInteropServicesName, "VarEnum", systemRuntimeInteropServicesAssemblyRef));
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(VarEnum), systemRuntimeInteropServicesAssemblyRef, "SafeArraySubType", MakePrimitive((int)safeArrayMarshalType.VariantType, type2, sb));
			}
			if (safeArrayMarshalType.IsUserDefinedSubTypeValid)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(Type), null, "SafeArrayUserDefinedSubType", CreateTypeOfExpression(safeArrayMarshalType.UserDefinedSubType, sb));
			}
		}
		if (marshalType is ArrayMarshalType arrayMarshalType)
		{
			if (arrayMarshalType.IsElementTypeValid && arrayMarshalType.ElementType != NativeType.Max)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(UnmanagedType), systemRuntimeInteropServicesAssemblyRef, "ArraySubType", MakePrimitive((int)arrayMarshalType.ElementType, type, sb));
			}
			if (arrayMarshalType.IsSizeValid)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(int), null, "SizeConst", new PrimitiveExpression(arrayMarshalType.Size));
			}
			if (arrayMarshalType.Flags != 0 && arrayMarshalType.ParamNumber >= 0)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(short), null, "SizeParamIndex", new PrimitiveExpression(arrayMarshalType.ParamNumber));
			}
		}
		if (marshalType is CustomMarshalType customMarshalType)
		{
			if (customMarshalType.CustomMarshaler != null)
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(Type), null, "MarshalTypeRef", CreateTypeOfExpression(customMarshalType.CustomMarshaler, sb));
			}
			if (!UTF8String.IsNullOrEmpty(customMarshalType.Cookie))
			{
				attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(string), null, "MarshalCookie", new PrimitiveExpression(customMarshalType.Cookie.String));
			}
		}
		if (marshalType is FixedSysStringMarshalType { IsSizeValid: not false } fixedSysStringMarshalType)
		{
			attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(int), null, "SizeConst", new PrimitiveExpression(fixedSysStringMarshalType.Size));
		}
		if (marshalType is InterfaceMarshalType { IsIidParamIndexValid: not false } interfaceMarshalType)
		{
			attribute.AddNamedArgument(module, typeFromHandle, systemRuntimeInteropServicesAssemblyRef, typeof(int), null, "IidParameterIndex", new PrimitiveExpression(interfaceMarshalType.IidParamIndex));
		}
		return attribute;
	}

	private ICSharpCode.NRefactory.CSharp.Attribute CreateNonCustomAttribute_SystemRuntimeInteropServices(Type attributeType)
	{
		ModuleDef module = context.CurrentType?.Module;
		return CreateNonCustomAttribute(attributeType, module, GetSystemRuntimeInteropServicesAssemblyRef(module));
	}

	private ICSharpCode.NRefactory.CSharp.Attribute CreateNonCustomAttribute_SystemRuntime(Type attributeType)
	{
		ModuleDef moduleDef = context.CurrentType?.Module;
		return CreateNonCustomAttribute(attributeType, moduleDef, moduleDef?.CorLibTypes?.AssemblyRef);
	}

	private ICSharpCode.NRefactory.CSharp.Attribute CreateNonCustomAttribute_SystemRuntimeSerializationFormatters(Type attributeType)
	{
		ModuleDef module = context.CurrentType?.Module;
		return CreateNonCustomAttribute(attributeType, module, GetSystemRuntimeSerializationFormattersAssemblyRef(module));
	}

	private static ICSharpCode.NRefactory.CSharp.Attribute CreateNonCustomAttribute(Type attributeType, ModuleDef module, AssemblyRef attributeTypeAssemblyRef)
	{
		ICSharpCode.NRefactory.CSharp.Attribute attribute = new ICSharpCode.NRefactory.CSharp.Attribute();
		attribute.Type = new SimpleType(attributeType.Name.Substring(0, attributeType.Name.Length - "Attribute".Length));
		if (module != null && attributeTypeAssemblyRef != null)
		{
			attribute.Type.AddAnnotation(module.UpdateRowId(new TypeRefUser(module, attributeType.Namespace, attributeType.Name, attributeTypeAssemblyRef)));
		}
		return attribute;
	}

	private static IEnumerable<CustomAttribute> SortCustomAttributes(IHasCustomAttribute customAttributeProvider, bool sort, StringBuilder sb)
	{
		if (!sort)
		{
			return customAttributeProvider.CustomAttributes;
		}
		return customAttributeProvider.CustomAttributes.OrderBy(delegate(CustomAttribute a)
		{
			sb.Clear();
			return FullNameFactory.FullName(a.AttributeType, isReflection: false, null, sb);
		});
	}

	private static void ConvertCustomAttributes(MetadataTextColorProvider metadataTextColorProvider, AstNode attributedNode, IHasCustomAttribute customAttributeProvider, DecompilerSettings settings, StringBuilder sb, string attributeTarget = null, ConvertCustomAttributesFlags options = ConvertCustomAttributesFlags.None)
	{
		if (customAttributeProvider == null || !customAttributeProvider.HasCustomAttributes)
		{
			return;
		}
		EntityDeclaration entityDeclaration = attributedNode as EntityDeclaration;
		List<ICSharpCode.NRefactory.CSharp.Attribute> list = new List<ICSharpCode.NRefactory.CSharp.Attribute>();
		bool flag = attributedNode is TypeDeclaration;
		bool flag2 = attributedNode is ParameterDeclaration;
		bool flag3 = attributedNode is MethodDeclaration || attributedNode is Accessor;
		bool flag4 = attributedNode is PropertyDeclaration;
		bool flag5 = attributeTarget == "module" || attributeTarget == "assembly" || (settings.OneCustomAttributePerLine && entityDeclaration != null);
		bool flag6 = (options & ConvertCustomAttributesFlags.IsAsync) != 0;
		bool flag7 = (options & ConvertCustomAttributesFlags.IsYieldReturn) != 0;
		bool flag8 = attributeTarget == "return";
		bool flag9 = false;
		foreach (CustomAttribute item in SortCustomAttributes(customAttributeProvider, settings.SortCustomAttributes, sb))
		{
			ITypeDefOrRef attributeType = item.AttributeType;
			if (attributeType == null || attributeType.Compare(systemRuntimeCompilerServicesString, extensionAttributeString) || attributeType.Compare(systemString, paramArrayAttributeString) || ((flag7 | flag6) && attributeType.Compare(systemDiagnosticsString, debuggerStepThroughAttributeString)) || ((flag7 | flag6) && attributeType.Compare(systemDiagnosticsString, debuggerHiddenAttributeString)) || (flag2 && (attributeType.Compare(systemRuntimeCompilerServicesString, dynamicAttributeString) || attributeType.Compare(systemRuntimeCompilerServicesString, isReadOnlyAttributeString))) || (flag3 && (attributeType.Compare(systemRuntimeCompilerServicesString, iteratorStateMachineAttributeString) || attributeType.Compare(systemRuntimeCompilerServicesString, asyncStateMachineAttributeString))))
			{
				continue;
			}
			if (flag)
			{
				if (attributeType.Compare(systemRuntimeCompilerServicesString, isReadOnlyAttributeString))
				{
					continue;
				}
				if (attributeType.Compare(systemRuntimeCompilerServicesString, isByRefLikeAttributeString))
				{
					flag9 = true;
					continue;
				}
				if (flag9 && attributeType.Compare(systemString, obsoleteAttributeString))
				{
					continue;
				}
			}
			if ((flag4 && attributeType.Compare(systemRuntimeCompilerServicesString, isReadOnlyAttributeString)) || (flag8 && attributeType.Compare(systemRuntimeCompilerServicesString, isReadOnlyAttributeString)))
			{
				continue;
			}
			ICSharpCode.NRefactory.CSharp.Attribute attribute = new ICSharpCode.NRefactory.CSharp.Attribute();
			attribute.AddAnnotation(item);
			attribute.Type = ConvertType(attributeType, sb);
			list.Add(attribute);
			if (attribute.Type is SimpleType simpleType && simpleType.Identifier.EndsWith("Attribute", StringComparison.Ordinal))
			{
				Identifier identifier = Identifier.Create(simpleType.Identifier.Substring(0, simpleType.Identifier.Length - "Attribute".Length));
				identifier.AddAnnotationsFrom(simpleType.IdentifierToken);
				simpleType.IdentifierToken = identifier;
			}
			if (item.HasConstructorArguments)
			{
				foreach (CAArgument constructorArgument in item.ConstructorArguments)
				{
					Expression element = ConvertArgumentValue(constructorArgument, sb);
					attribute.Arguments.Add(element);
				}
			}
			if (!item.HasNamedArguments)
			{
				continue;
			}
			TypeDef type = attributeType.ResolveTypeDef();
			foreach (CANamedArgument property2 in item.Properties)
			{
				PropertyDef property = GetProperty(type, property2.Name);
				IdentifierExpression left = IdentifierExpression.Create(property2.Name, metadataTextColorProvider.GetColor(property ?? BoxedTextColor.InstanceProperty), addAnnotationToExpr: true).WithAnnotation(property);
				Expression right = ConvertArgumentValue(property2.Argument, sb);
				attribute.Arguments.Add(new AssignmentExpression(left, right));
			}
			foreach (CANamedArgument field2 in item.Fields)
			{
				FieldDef field = GetField(type, field2.Name);
				IdentifierExpression left2 = IdentifierExpression.Create(field2.Name, metadataTextColorProvider.GetColor(field ?? BoxedTextColor.InstanceField), addAnnotationToExpr: true).WithAnnotation(field);
				Expression right2 = ConvertArgumentValue(field2.Argument, sb);
				attribute.Arguments.Add(new AssignmentExpression(left2, right2));
			}
		}
		if (flag5)
		{
			foreach (ICSharpCode.NRefactory.CSharp.Attribute item2 in list)
			{
				AttributeSection attributeSection = new AttributeSection();
				attributeSection.AttributeTarget = attributeTarget;
				attributeSection.Attributes.Add(item2);
				attributedNode.AddChild(attributeSection, EntityDeclaration.AttributeRole);
			}
			return;
		}
		if (list.Count > 0)
		{
			AttributeSection attributeSection2 = new AttributeSection();
			attributeSection2.AttributeTarget = attributeTarget;
			attributeSection2.Attributes.AddRange(list);
			attributedNode.AddChild(attributeSection2, EntityDeclaration.AttributeRole);
		}
	}

	private static PropertyDef GetProperty(TypeDef type, UTF8String name)
	{
		while (type != null)
		{
			foreach (PropertyDef property in type.Properties)
			{
				if (property.Name == name)
				{
					return property;
				}
			}
			type = type.BaseType.ResolveTypeDef();
		}
		return null;
	}

	private static FieldDef GetField(TypeDef type, UTF8String name)
	{
		while (type != null)
		{
			foreach (FieldDef field in type.Fields)
			{
				if (field.Name == name)
				{
					return field;
				}
			}
			type = type.BaseType.ResolveTypeDef();
		}
		return null;
	}

	private static void ConvertSecurityAttributes(MetadataTextColorProvider metadataTextColorProvider, AstNode attributedNode, IHasDeclSecurity secDeclProvider, StringBuilder sb, string attributeTarget = null)
	{
		if (secDeclProvider == null || !secDeclProvider.HasDeclSecurities)
		{
			return;
		}
		List<ICSharpCode.NRefactory.CSharp.Attribute> list = new List<ICSharpCode.NRefactory.CSharp.Attribute>();
		foreach (DeclSecurity item in secDeclProvider.DeclSecurities.OrderBy((DeclSecurity d) => d.Action))
		{
			foreach (SecurityAttribute item2 in item.SecurityAttributes.OrderBy(delegate(SecurityAttribute a)
			{
				sb.Clear();
				return FullNameFactory.FullName(a.AttributeType, isReflection: false, null, sb);
			}))
			{
				if (item2.AttributeType == null)
				{
					continue;
				}
				ICSharpCode.NRefactory.CSharp.Attribute attribute = new ICSharpCode.NRefactory.CSharp.Attribute();
				attribute.AddAnnotation(item2);
				attribute.Type = ConvertType(item2.AttributeType, sb);
				list.Add(attribute);
				if (attribute.Type is SimpleType simpleType && simpleType.Identifier.EndsWith("Attribute", StringComparison.Ordinal))
				{
					Identifier identifier = Identifier.Create(simpleType.Identifier.Substring(0, simpleType.Identifier.Length - "Attribute".Length));
					identifier.AddAnnotationsFrom(simpleType.IdentifierToken);
					simpleType.IdentifierToken = identifier;
				}
				ModuleDef module = item2.AttributeType.Module;
				TypeRef typeRef = module.CorLibTypes.GetTypeRef("System.Security.Permissions", "SecurityAction");
				attribute.Arguments.Add(MakePrimitive((long)item.Action, typeRef, sb));
				if (!item2.HasNamedArguments)
				{
					continue;
				}
				TypeDef typeDef = item2.AttributeType.ResolveTypeDef();
				foreach (CANamedArgument propertyNamedArg in item2.Properties)
				{
					PropertyDef propertyDef = typeDef?.Properties.FirstOrDefault((PropertyDef pr) => pr.Name == propertyNamedArg.Name);
					IdentifierExpression left = IdentifierExpression.Create(propertyNamedArg.Name, metadataTextColorProvider.GetColor(propertyDef ?? BoxedTextColor.InstanceProperty), addAnnotationToExpr: true).WithAnnotation(propertyDef);
					Expression right = ConvertArgumentValue(propertyNamedArg.Argument, sb);
					attribute.Arguments.Add(new AssignmentExpression(left, right));
				}
				foreach (CANamedArgument fieldNamedArg in item2.Fields)
				{
					FieldDef fieldDef = typeDef?.Fields.FirstOrDefault((FieldDef f) => f.Name == fieldNamedArg.Name);
					IdentifierExpression left2 = IdentifierExpression.Create(fieldNamedArg.Name, metadataTextColorProvider.GetColor(fieldDef ?? BoxedTextColor.InstanceField), addAnnotationToExpr: true).WithAnnotation(fieldDef);
					Expression right2 = ConvertArgumentValue(fieldNamedArg.Argument, sb);
					attribute.Arguments.Add(new AssignmentExpression(left2, right2));
				}
			}
		}
		if (attributeTarget == "module" || attributeTarget == "assembly")
		{
			foreach (ICSharpCode.NRefactory.CSharp.Attribute item3 in list)
			{
				AttributeSection attributeSection = new AttributeSection();
				attributeSection.AttributeTarget = attributeTarget;
				attributeSection.Attributes.Add(item3);
				attributedNode.AddChild(attributeSection, EntityDeclaration.AttributeRole);
			}
			return;
		}
		if (list.Count > 0)
		{
			AttributeSection attributeSection2 = new AttributeSection();
			attributeSection2.AttributeTarget = attributeTarget;
			attributeSection2.Attributes.AddRange(list);
			attributedNode.AddChild(attributeSection2, EntityDeclaration.AttributeRole);
		}
	}

	private static Expression ConvertArgumentValue(CAArgument argument, StringBuilder sb)
	{
		if (argument.Value is IList<CAArgument>)
		{
			ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
			foreach (CAArgument item in (IList<CAArgument>)argument.Value)
			{
				arrayInitializerExpression.Elements.Add(ConvertArgumentValue(item, sb));
			}
			ArraySigBase arraySigBase = argument.Type as ArraySigBase;
			return new ArrayCreateExpression
			{
				Type = ConvertType((arraySigBase != null) ? arraySigBase.Next : argument.Type, sb),
				AdditionalArraySpecifiers = 
				{
					new ArraySpecifier()
				},
				Initializer = arrayInitializerExpression
			};
		}
		if (argument.Value is CAArgument)
		{
			return ConvertArgumentValue((CAArgument)argument.Value, sb);
		}
		TypeDef typeDef = argument.Type.Resolve();
		if (typeDef != null && typeDef.IsEnum && argument.Value != null)
		{
			try
			{
				if (argument.Value is UTF8String)
				{
					return MakePrimitive(Convert.ToInt64(((UTF8String)argument.Value).String), typeDef, sb);
				}
				return MakePrimitive(Convert.ToInt64(argument.Value), typeDef, sb);
			}
			catch (SystemException)
			{
			}
		}
		if (argument.Value is TypeSig)
		{
			return CreateTypeOfExpression(((TypeSig)argument.Value).ToTypeDefOrRef(), sb);
		}
		if (argument.Value is UTF8String)
		{
			return new PrimitiveExpression(((UTF8String)argument.Value).String);
		}
		return new PrimitiveExpression(argument.Value);
	}

	internal static Expression MakePrimitive(long val, ITypeDefOrRef type, StringBuilder sb)
	{
		if (val == 0L && type.IsSystemBoolean())
		{
			return new PrimitiveExpression(false);
		}
		if (val == 1 && type.IsSystemBoolean())
		{
			return new PrimitiveExpression(true);
		}
		if (val == 0L && type.TryGetPtrSig() != null)
		{
			return new NullReferenceExpression();
		}
		if (type != null)
		{
			TypeDef typeDef = type.ResolveTypeDef();
			if (typeDef != null && typeDef.IsEnum)
			{
				TypeCode typeCode = TypeCode.Int32;
				foreach (FieldDef field in typeDef.Fields)
				{
					if (field.IsStatic)
					{
						TryGetConstant(field, out var constant);
						TypeCode typeCode2 = ((constant != null) ? Type.GetTypeCode(constant.GetType()) : TypeCode.Empty);
						if (typeCode2 >= TypeCode.Char && typeCode2 <= TypeCode.Decimal && object.Equals(CSharpPrimitiveCast.Cast(TypeCode.Int64, constant, checkForOverflow: false), val))
						{
							return ConvertType(type, sb).Member(field.Name, field).WithAnnotation(field);
						}
					}
					else if (!field.IsStatic)
					{
						typeCode = TypeAnalysis.GetTypeCode(field.FieldType);
					}
				}
				if (IsFlagsEnum(typeDef))
				{
					long num = val;
					Expression expression = null;
					long num2 = ~val;
					switch (typeCode)
					{
					case TypeCode.SByte:
					case TypeCode.Byte:
						num2 &= 0xFF;
						break;
					case TypeCode.Char:
					case TypeCode.Int16:
					case TypeCode.UInt16:
						num2 &= 0xFFFF;
						break;
					case TypeCode.Int32:
					case TypeCode.UInt32:
						num2 &= 0xFFFFFFFFu;
						break;
					}
					Expression expression2 = null;
					foreach (FieldDef item in typeDef.Fields.Where((FieldDef fld) => fld.IsStatic))
					{
						TryGetConstant(item, out var constant2);
						TypeCode typeCode3 = ((constant2 != null) ? Type.GetTypeCode(constant2.GetType()) : TypeCode.Empty);
						if (typeCode3 < TypeCode.Char || typeCode3 > TypeCode.Decimal)
						{
							continue;
						}
						long num3 = (long)CSharpPrimitiveCast.Cast(TypeCode.Int64, constant2, checkForOverflow: false);
						if (num3 != 0L)
						{
							if ((num3 & num) == num3)
							{
								MemberReferenceExpression memberReferenceExpression = ConvertType(type, sb).Member(item.Name, item).WithAnnotation(item);
								expression = ((expression != null) ? ((Expression)new BinaryOperatorExpression(expression, BinaryOperatorType.BitwiseOr, memberReferenceExpression)) : ((Expression)memberReferenceExpression));
								num &= ~num3;
							}
							if ((num3 & num2) == num3)
							{
								MemberReferenceExpression memberReferenceExpression2 = ConvertType(type, sb).Member(item.Name, item).WithAnnotation(item);
								expression2 = ((expression2 != null) ? ((Expression)new BinaryOperatorExpression(expression2, BinaryOperatorType.BitwiseOr, memberReferenceExpression2)) : ((Expression)memberReferenceExpression2));
								num2 &= ~num3;
							}
						}
					}
					if (num == 0L && expression != null && (num2 != 0L || expression2 == null || expression2.Descendants.Count() >= expression.Descendants.Count()))
					{
						return expression;
					}
					if (num2 == 0L && expression2 != null)
					{
						return new UnaryOperatorExpression(UnaryOperatorType.BitNot, expression2);
					}
				}
				if (typeCode < TypeCode.Char || typeCode > TypeCode.Decimal)
				{
					typeCode = TypeCode.Int32;
				}
				return new PrimitiveExpression(CSharpPrimitiveCast.Cast(typeCode, val, checkForOverflow: false)).CastTo(ConvertType(type, sb));
			}
		}
		TypeCode typeCode4 = TypeAnalysis.GetTypeCode(type.ToTypeSig());
		if (typeCode4 < TypeCode.Char || typeCode4 > TypeCode.Decimal)
		{
			typeCode4 = TypeCode.Int32;
		}
		return new PrimitiveExpression(CSharpPrimitiveCast.Cast(typeCode4, val, checkForOverflow: false));
	}

	private static bool IsFlagsEnum(TypeDef type)
	{
		return type.IsDefined(systemString, flagsAttributeString);
	}

	private static void SetNewModifier(EntityDeclaration member)
	{
		try
		{
			bool flag = false;
			if (member is IndexerDeclaration)
			{
				PropertyDef property = member.Annotation<PropertyDef>();
				IEnumerable<PropertyDef> source = TypesHierarchyHelpers.FindBaseProperties(property);
				flag = source.Any();
			}
			else
			{
				flag = HidesBaseMember(member);
			}
			if (flag)
			{
				member.Modifiers |= Modifiers.New;
			}
		}
		catch (ResolveException)
		{
		}
	}

	private static bool HidesBaseMember(EntityDeclaration member)
	{
		IMemberDef memberDef = member.Annotation<IMemberDef>();
		bool flag = false;
		if (memberDef is MethodDef method)
		{
			flag = HidesByName(memberDef, includeBaseMethods: false);
			if (!flag)
			{
				flag = TypesHierarchyHelpers.FindBaseMethods(method).Any();
			}
		}
		else
		{
			flag = HidesByName(memberDef, includeBaseMethods: true);
		}
		return flag;
	}

	private static bool HidesByName(IMemberDef member, bool includeBaseMethods)
	{
		if (member == null)
		{
			return false;
		}
		if (member.DeclaringType.BaseType != null)
		{
			ITypeDefOrRef baseType = member.DeclaringType.BaseType;
			while (baseType != null)
			{
				TypeDef typeDef = baseType.ResolveTypeDef();
				if (typeDef == null)
				{
					break;
				}
				if (typeDef.HasProperties && AnyIsHiddenBy(typeDef.Properties, member, (PropertyDef m) => !m.IsIndexer()))
				{
					return true;
				}
				if (typeDef.HasEvents && AnyIsHiddenBy(typeDef.Events, member))
				{
					return true;
				}
				if (typeDef.HasFields && AnyIsHiddenBy(typeDef.Fields, member))
				{
					return true;
				}
				if (includeBaseMethods && typeDef.HasMethods && AnyIsHiddenBy(typeDef.Methods, member, (MethodDef m) => !m.IsSpecialName))
				{
					return true;
				}
				if (typeDef.HasNestedTypes && AnyIsHiddenBy(typeDef.NestedTypes, member))
				{
					return true;
				}
				baseType = typeDef.BaseType;
			}
		}
		return false;
	}

	private static bool AnyIsHiddenBy<T>(IEnumerable<T> members, IMemberDef derived, Predicate<T> condition = null) where T : IMemberDef
	{
		return members.Any((T m) => m.Name == derived.Name && (condition == null || condition(m)) && TypesHierarchyHelpers.IsVisibleFromDerived(m, derived.DeclaringType));
	}
}

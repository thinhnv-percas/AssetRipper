using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Decompiler.XmlDoc;
using dnSpy.Contracts.Text;
using dnSpy.Decompiler.ILSpy.Core.Settings;
using dnSpy.Decompiler.ILSpy.Core.XmlDoc;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class CSharpDecompiler : DecompilerBase
{
	private class SelectCtorTransform : IAstTransform
	{
		private readonly MethodDef ctorDef;

		public SelectCtorTransform(MethodDef ctorDef)
		{
			this.ctorDef = ctorDef;
		}

		public void Run(AstNode compilationUnit)
		{
			ConstructorDeclaration constructorDeclaration = null;
			foreach (AstNode child in compilationUnit.Children)
			{
				if (child is ConstructorDeclaration constructorDeclaration2)
				{
					if (constructorDeclaration2.Annotation<MethodDef>() == ctorDef)
					{
						constructorDeclaration = constructorDeclaration2;
					}
					else
					{
						constructorDeclaration2.Remove();
					}
				}
				if (child is FieldDeclaration fieldDeclaration && fieldDeclaration.Variables.All((VariableInitializer v) => v.Initializer.IsNull))
				{
					fieldDeclaration.Remove();
				}
			}
			if (constructorDeclaration.Initializer.ConstructorInitializerType != ConstructorInitializerType.This)
			{
				return;
			}
			foreach (AstNode child2 in compilationUnit.Children)
			{
				if (child2 is FieldDeclaration)
				{
					child2.Remove();
				}
			}
		}
	}

	private sealed class SelectFieldTransform : IAstTransform
	{
		private readonly FieldDef field;

		public SelectFieldTransform(FieldDef field)
		{
			this.field = field;
		}

		public void Run(AstNode compilationUnit)
		{
			foreach (AstNode child in compilationUnit.Children)
			{
				if (child is EntityDeclaration && child.Annotation<FieldDef>() != field)
				{
					child.Remove();
				}
			}
		}
	}

	private string uniqueNameUI = "C#";

	private Guid uniqueGuid = DecompilerConstants.LANGUAGE_CSHARP_ILSPY;

	private bool showAllMembers;

	private readonly Func<BuilderCache> createBuilderCache;

	private Predicate<IAstTransform> transformAbortCondition;

	private readonly CSharpVBDecompilerSettings langSettings;

	private static readonly char[] newLineChars = new char[5] { '\r', '\n', '\u0085', '\u2028', '\u2029' };

	private static readonly HashSet<string> isKeyword = new HashSet<string>(StringComparer.Ordinal)
	{
		"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
		"class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum",
		"event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto",
		"if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace",
		"new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
		"readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
		"struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
		"unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
	};

	public override DecompilerSettingsBase Settings => langSettings;

	public override string ContentTypeString => "C# ILSpy";

	public override string GenericNameUI => DecompilerConstants.GENERIC_NAMEUI_CSHARP;

	public override string UniqueNameUI => uniqueNameUI;

	public override double OrderUI { get; }

	public override Guid GenericGuid => DecompilerConstants.LANGUAGE_CSHARP;

	public override Guid UniqueGuid => uniqueGuid;

	public override string FileExtension => ".cs";

	public override string ProjectFileExtension => ".csproj";

	public CSharpDecompiler(CSharpVBDecompilerSettings langSettings, double orderUI)
	{
		this.langSettings = langSettings;
		createBuilderCache = () => new BuilderCache(this.langSettings.Settings.SettingsVersion);
		OrderUI = orderUI;
	}

	public override void Decompile(MethodDef method, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, method);
		BuilderState state = CreateAstBuilder(ctx, langSettings.Settings, null, method.DeclaringType, isSingleMember: true);
		try
		{
			if (method.IsConstructor && !method.IsStatic && !method.DeclaringType.IsValueType)
			{
				AddFieldsAndCtors(state.AstBuilder, method.DeclaringType, method.IsStatic);
				RunTransformsAndGenerateCode(ref state, output, ctx, new SelectCtorTransform(method));
			}
			else
			{
				state.AstBuilder.AddMethod(method);
				RunTransformsAndGenerateCode(ref state, output, ctx);
			}
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void Decompile(PropertyDef property, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, property);
		BuilderState state = CreateAstBuilder(ctx, langSettings.Settings, null, property.DeclaringType, isSingleMember: true);
		try
		{
			state.AstBuilder.AddProperty(property);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void Decompile(FieldDef field, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, field);
		BuilderState state = CreateAstBuilder(ctx, langSettings.Settings, null, field.DeclaringType, isSingleMember: true);
		try
		{
			if (field.IsLiteral)
			{
				state.AstBuilder.AddField(field);
			}
			else
			{
				AddFieldsAndCtors(state.AstBuilder, field.DeclaringType, field.IsStatic);
			}
			RunTransformsAndGenerateCode(ref state, output, ctx, new SelectFieldTransform(field));
		}
		finally
		{
			state.Dispose();
		}
	}

	private void AddFieldsAndCtors(AstBuilder codeDomBuilder, TypeDef declaringType, bool isStatic)
	{
		foreach (FieldDef field in declaringType.Fields)
		{
			if (field.IsStatic == isStatic)
			{
				codeDomBuilder.AddField(field);
			}
		}
		foreach (MethodDef method in declaringType.Methods)
		{
			if (method.IsConstructor && method.IsStatic == isStatic)
			{
				codeDomBuilder.AddMethod(method);
			}
		}
	}

	public override void Decompile(EventDef ev, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteCommentLineDeclaringType(output, ev);
		BuilderState state = CreateAstBuilder(ctx, langSettings.Settings, null, ev.DeclaringType, isSingleMember: true);
		try
		{
			state.AstBuilder.AddEvent(ev);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	public override void Decompile(TypeDef type, IDecompilerOutput output, DecompilationContext ctx)
	{
		BuilderState state = CreateAstBuilder(ctx, langSettings.Settings, null, type);
		try
		{
			state.AstBuilder.AddType(type);
			RunTransformsAndGenerateCode(ref state, output, ctx);
		}
		finally
		{
			state.Dispose();
		}
	}

	private void RunTransformsAndGenerateCode(ref BuilderState state, IDecompilerOutput output, DecompilationContext ctx, IAstTransform additionalTransform = null)
	{
		AstBuilder astBuilder = state.AstBuilder;
		astBuilder.RunTransformations(transformAbortCondition);
		additionalTransform?.Run(astBuilder.SyntaxTree);
		AddXmlDocumentation(ref state, langSettings.Settings, astBuilder);
		astBuilder.GenerateCode(output);
	}

	internal static void AddXmlDocumentation(ref BuilderState state, DecompilerSettings settings, AstBuilder astBuilder)
	{
		if (!settings.ShowXmlDocumentation)
		{
			return;
		}
		ModuleDef currentModule = state.AstBuilder.Context.CurrentModule;
		bool? flag = state.State.HasXmlDocFile(currentModule);
		bool flag2;
		if (!flag.HasValue)
		{
			flag2 = XmlDocLoader.LoadDocumentation(currentModule) != null;
			state.State.SetHasXmlDocFile(currentModule, flag2);
		}
		else
		{
			flag2 = flag.Value;
		}
		if (!flag2)
		{
			return;
		}
		try
		{
			new AddXmlDocTransform(state.State.XmlDoc_StringBuilder).Run(astBuilder.SyntaxTree);
		}
		catch (XmlException ex)
		{
			string[] array = (" Exception while reading XmlDoc: " + ex.ToString()).Split(newLineChars, StringSplitOptions.RemoveEmptyEntries);
			AstNode firstChild = astBuilder.SyntaxTree.FirstChild;
			for (int i = 0; i < array.Length; i++)
			{
				astBuilder.SyntaxTree.InsertChildBefore(firstChild, new Comment(array[i], CommentType.Documentation), Roles.Comment);
			}
		}
	}

	public override void Decompile(AssemblyDef asm, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteAssembly(asm, output, ctx);
		using (ctx.DisableAssemblyLoad())
		{
			BuilderState state = CreateAstBuilder(ctx, langSettings.Settings, asm.ManifestModule);
			try
			{
				state.AstBuilder.AddAssembly(asm.ManifestModule, onlyAssemblyLevel: true, decompileAsm: true, decompileMod: false);
				RunTransformsAndGenerateCode(ref state, output, ctx);
			}
			finally
			{
				state.Dispose();
			}
		}
	}

	public override void Decompile(ModuleDef mod, IDecompilerOutput output, DecompilationContext ctx)
	{
		WriteModule(mod, output, ctx);
		using (ctx.DisableAssemblyLoad())
		{
			BuilderState state = CreateAstBuilder(ctx, langSettings.Settings, mod);
			try
			{
				state.AstBuilder.AddAssembly(mod, onlyAssemblyLevel: true, decompileAsm: false, decompileMod: true);
				RunTransformsAndGenerateCode(ref state, output, ctx);
			}
			finally
			{
				state.Dispose();
			}
		}
	}

	private BuilderState CreateAstBuilder(DecompilationContext ctx, DecompilerSettings settings, ModuleDef currentModule = null, TypeDef currentType = null, bool isSingleMember = false)
	{
		if (currentModule == null)
		{
			currentModule = currentType.Module;
		}
		if (isSingleMember)
		{
			settings = settings.Clone();
			settings.UsingDeclarations = false;
		}
		BuilderCache orCreate = ctx.GetOrCreate(createBuilderCache);
		BuilderState result = new BuilderState(ctx, orCreate, MetadataTextColorProvider);
		result.AstBuilder.Context.CurrentModule = currentModule;
		result.AstBuilder.Context.CancellationToken = ctx.CancellationToken;
		result.AstBuilder.Context.CurrentType = currentType;
		result.AstBuilder.Context.Settings = settings;
		return result;
	}

	protected override void TypeToString(IDecompilerOutput output, ITypeDefOrRef type, bool includeNamespace, IHasCustomAttribute typeAttributes = null)
	{
		ConvertTypeOptions convertTypeOptions = ConvertTypeOptions.IncludeTypeParameterDefinitions;
		if (includeNamespace)
		{
			convertTypeOptions |= ConvertTypeOptions.IncludeNamespace;
		}
		TypeToString(output, convertTypeOptions, type, typeAttributes);
	}

	private bool WriteRefIfByRef(IDecompilerOutput output, TypeSig typeSig, ParamDef pd)
	{
		if (typeSig.RemovePinnedAndModifiers() is ByRefSig)
		{
			if (pd != null && !pd.IsIn && pd.IsOut)
			{
				output.Write("out", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
			}
			else
			{
				output.Write("ref", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
			}
			return true;
		}
		return false;
	}

	private void TypeToString(IDecompilerOutput output, ConvertTypeOptions options, ITypeDefOrRef type, IHasCustomAttribute typeAttributes = null)
	{
		if (type != null)
		{
			AstType astType = AstBuilder.ConvertType(type, new StringBuilder(), typeAttributes, options);
			if (WriteRefIfByRef(output, type.TryGetByRefSig(), typeAttributes as ParamDef) && astType is ComposedType && ((ComposedType)astType).PointerRank > 0)
			{
				((ComposedType)astType).PointerRank--;
			}
			DecompilerContext context = new DecompilerContext(langSettings.Settings.SettingsVersion, type.Module, MetadataTextColorProvider);
			astType.AcceptVisitor(new CSharpOutputVisitor(new TextTokenWriter(output, context), FormattingOptionsFactory.CreateAllman()));
		}
	}

	protected override void FormatPropertyName(IDecompilerOutput output, PropertyDef property, bool? isIndexer)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		if (!isIndexer.HasValue)
		{
			isIndexer = property.IsIndexer();
		}
		if (isIndexer.Value)
		{
			MethodDef methodDef = property.GetMethod ?? property.SetMethod;
			if (methodDef != null && methodDef.HasOverrides)
			{
				ITypeDefOrRef type = methodDef.Overrides.First().MethodDeclaration?.DeclaringType;
				TypeToString(output, type, includeNamespace: true);
				output.Write(".", BoxedTextColor.Operator);
			}
			output.Write("this", BoxedTextColor.Keyword);
			output.Write("[", BoxedTextColor.Punctuation);
			bool flag = false;
			foreach (TypeSig item in property.PropertySig.GetParams())
			{
				if (flag)
				{
					output.Write(",", BoxedTextColor.Punctuation);
					output.Write(" ", BoxedTextColor.Text);
				}
				else
				{
					flag = true;
				}
				TypeToString(output, item.ToTypeDefOrRef(), includeNamespace: true);
			}
			output.Write("]", BoxedTextColor.Punctuation);
		}
		else
		{
			WriteIdentifier(output, property.Name, MetadataTextColorProvider.GetColor(property));
		}
	}

	private static void WriteIdentifier(IDecompilerOutput output, string id, object tokenKind)
	{
		if (isKeyword.Contains(id))
		{
			output.Write("@", tokenKind);
		}
		output.Write(IdentifierEscaper.Escape(id), tokenKind);
	}

	protected override void FormatTypeName(IDecompilerOutput output, TypeDef type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		TypeToString(output, ConvertTypeOptions.IncludeTypeParameterDefinitions | ConvertTypeOptions.DoNotUsePrimitiveTypeNames | ConvertTypeOptions.DoNotIncludeEnclosingType, type);
	}

	internal static bool ShowMember(IMemberRef member, bool showAllMembers, DecompilerSettings settings)
	{
		if (showAllMembers)
		{
			return true;
		}
		if (member is MethodDef methodDef && (methodDef.IsGetter || methodDef.IsSetter || methodDef.IsAddOn || methodDef.IsRemoveOn))
		{
			return true;
		}
		return !AstBuilder.MemberIsHidden(member, settings);
	}

	public override bool ShowMember(IMemberRef member)
	{
		return ShowMember(member, showAllMembers, langSettings.Settings);
	}

	public override bool CanDecompile(DecompilationType decompilationType)
	{
		if ((uint)decompilationType <= 2u)
		{
			return true;
		}
		return base.CanDecompile(decompilationType);
	}

	public override void Decompile(DecompilationType decompilationType, object data)
	{
		switch (decompilationType)
		{
		case DecompilationType.PartialType:
			DecompilePartial((DecompilePartialType)data);
			break;
		case DecompilationType.AssemblyInfo:
			DecompileAssemblyInfo((DecompileAssemblyInfo)data);
			break;
		case DecompilationType.TypeMethods:
			DecompileTypeMethods((DecompileTypeMethods)data);
			break;
		default:
			base.Decompile(decompilationType, data);
			break;
		}
	}

	private void DecompilePartial(DecompilePartialType info)
	{
		BuilderState state = CreateAstBuilder(info.Context, CreateDecompilerSettings(langSettings.Settings, info.UseUsingDeclarations), null, info.Type);
		try
		{
			state.AstBuilder.AddType(info.Type);
			RunTransformsAndGenerateCode(ref state, info.Output, info.Context, new DecompilePartialTransform(info.Type, info.Definitions, info.ShowDefinitions, info.AddPartialKeyword, info.InterfacesToRemove));
		}
		finally
		{
			state.Dispose();
		}
	}

	private void DecompileAssemblyInfo(DecompileAssemblyInfo info)
	{
		BuilderState state = CreateAstBuilder(info.Context, langSettings.Settings, info.Module);
		try
		{
			state.AstBuilder.AddAssembly(info.Module, onlyAssemblyLevel: true, info.Module.IsManifestModule, decompileMod: true);
			RunTransformsAndGenerateCode(ref state, info.Output, info.Context, info.KeepAllAttributes ? null : new AssemblyInfoTransform());
		}
		finally
		{
			state.Dispose();
		}
	}

	private void DecompileTypeMethods(DecompileTypeMethods info)
	{
		BuilderState state = CreateAstBuilder(info.Context, CreateDecompilerSettings_DecompileTypeMethods(langSettings.Settings, !info.DecompileHidden, info.ShowAll), null, info.Type);
		try
		{
			state.AstBuilder.GetDecompiledBodyKind = (AstBuilder builder, MethodDef method) => GetDecompiledBodyKind(info, builder, method);
			state.AstBuilder.AddType(info.Type);
			RunTransformsAndGenerateCode(ref state, info.Output, info.Context, new DecompileTypeMethodsTransform(info.Types, info.Methods, !info.DecompileHidden, info.ShowAll));
		}
		finally
		{
			state.Dispose();
		}
	}

	internal static DecompilerSettings CreateDecompilerSettings_DecompileTypeMethods(DecompilerSettings settings, bool useUsingDeclarations, bool showAll)
	{
		DecompilerSettings decompilerSettings = CreateDecompilerSettings(settings, useUsingDeclarations);
		decompilerSettings.RemoveEmptyDefaultConstructors = false;
		if (!showAll)
		{
			decompilerSettings.AllowFieldInitializers = false;
		}
		return decompilerSettings;
	}

	internal static DecompilerSettings CreateDecompilerSettings(DecompilerSettings settings, bool useUsingDeclarations)
	{
		DecompilerSettings decompilerSettings = settings.Clone();
		decompilerSettings.UsingDeclarations = useUsingDeclarations;
		decompilerSettings.FullyQualifyAllTypes = !useUsingDeclarations;
		decompilerSettings.RemoveNewDelegateClass = useUsingDeclarations;
		decompilerSettings.ForceShowAllMembers = false;
		return decompilerSettings;
	}

	internal static DecompiledBodyKind GetDecompiledBodyKind(DecompileTypeMethods info, AstBuilder builder, MethodDef method)
	{
		if (info.DecompileHidden)
		{
			return DecompiledBodyKind.Empty;
		}
		if (info.ShowAll || info.Methods.Contains(method))
		{
			return DecompiledBodyKind.Full;
		}
		return DecompiledBodyKind.Empty;
	}
}

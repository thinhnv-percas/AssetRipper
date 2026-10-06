using AssetRipper.Export.Configuration;
using AssetRipper.Export.UnityProjects.Scripts;
using AssetRipper.Import.Configuration;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;
using AssetRipper.Import.Structure.Assembly.Managers;
using Cpp2IL.Core.ProcessingLayers;
using ICSharpCode.Decompiler.CSharp.Syntax;
using System.Runtime.CompilerServices;

namespace AssetRipper.Tests;

/// <summary>
/// Iteration 067 §12-§14: the two recovered-code output options. Both act where the output is produced; neither edits
/// text afterwards.
/// </summary>
internal sealed class Il2CppOutputOptionsTests
{
	[OneTimeSetUp]
	public void RegisterInstructionSets() => RuntimeHelpers.RunClassConstructor(typeof(IL2CppManager).TypeHandle);

	[TearDown]
	public void RestoreStockBehaviour() => Il2CppRecoverySetup.Uninstall();

	// ---------------------------------------------------------------- Emit Cpp2ILInjected Attributes

	[Test]
	public void TheDefaultEmitsTheInjectedAttributes()
	{
		Assert.That(RecoveredCodeOutputOptions.Default.EmitCpp2ILInjectedAttributes, Is.True);
		Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = ScriptContentLevel.Level3 });
		Assert.That(IL2CppManager.RecoveryProcessingLayers!.OfType<AttributeInjectorProcessingLayer>().Count(), Is.EqualTo(1));
	}

	[Test]
	public void OffInstallsNothingThatEmitsThem()
	{
		Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = ScriptContentLevel.Level3, EmitIl2CppOffsets = false });
		Assert.That(IL2CppManager.RecoveryProcessingLayers!.OfType<AttributeInjectorProcessingLayer>(), Is.Empty);
	}

	[Test]
	public void TheGamesOwnAttributesAreRestoredEitherWay()
	{
		foreach (bool emit in (bool[])[true, false])
		{
			Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = ScriptContentLevel.Level3, EmitIl2CppOffsets = emit });
			Assert.That(IL2CppManager.RecoveryProcessingLayers!.OfType<AttributeAnalysisProcessingLayer>().Count(), Is.EqualTo(1), $"emit={emit}");
		}
	}

	[Test]
	public void NoOtherCpp2ILInjectingLayerIsInstalled()
	{
		// CallAnalysis and NativeMethodDetection also inject into Cpp2ILInjected; the policy is only complete while
		// AssetRipper installs neither.
		Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = ScriptContentLevel.Level3, ReconstructNativeBodies = true });
		Assert.Multiple(() =>
		{
			Assert.That(IL2CppManager.RecoveryProcessingLayers!.OfType<CallAnalysisProcessingLayer>(), Is.Empty);
			Assert.That(IL2CppManager.RecoveryProcessingLayers!.OfType<NativeMethodDetectionProcessingLayer>(), Is.Empty);
		});
	}

	[Test]
	public void TheGroupedOptionsReadTheStoredSettings()
	{
		FullConfiguration configuration = new();
		configuration.ImportSettings.EmitIl2CppOffsets = false;
		Assert.That(configuration.RecoveredCodeOutput.EmitCpp2ILInjectedAttributes, Is.False);
		Assert.That(configuration.RecoveredCodeOutput.SimplifyGlobalQualification, Is.True);

		configuration.ExportSettings.ScriptTypesFullyQualified = true;
		Assert.That(configuration.RecoveredCodeOutput.SimplifyGlobalQualification, Is.False, "fully qualified asks for global:: everywhere");
	}

	// ---------------------------------------------------------------- Simplify global:: Qualification

	private sealed class FakeScope : IGlobalNameScope
	{
		public HashSet<string> Namespaces { get; } = ["System", "UnityEngine", "MyGame", "Other"];
		public HashSet<(string Namespace, string Name)> Types { get; } = [("System", "String"), ("UnityEngine", "Vector3"), ("MyGame", "Type"), ("", "GlobalHelper")];
		public Dictionary<string, string[]> Members { get; } = [];

		public bool NamespaceExists(string fullName) => Namespaces.Contains(fullName);

		public bool TypeExists(string namespaceFullName, string name) => Types.Contains((namespaceFullName, name));

		public IReadOnlyCollection<string>? MemberNames(TypeDeclaration declaration)
			=> Members.TryGetValue(declaration.Name, out string[]? names) ? names : [];
	}

	private static MemberType Global(string first) => new(new SimpleType("global"), first) { IsDoubleColon = true };

	private static AstType Qualified(params string[] parts)
	{
		AstType type = Global(parts[0]);
		foreach (string part in parts.Skip(1))
		{
			type = new MemberType(type, part);
		}
		return type;
	}

	/// <summary><c>namespace ns { class Holder { void M() { T x; } } }</c>, plus whatever <paramref name="extend"/> adds.</summary>
	private static (SyntaxTree Tree, TypeDeclaration Holder, MethodDeclaration Method) File(string ns, AstType type, Action<TypeDeclaration, MethodDeclaration>? extend = null)
	{
		MethodDeclaration method = new() { Name = "M", ReturnType = new PrimitiveType("void"), Body = new BlockStatement() };
		method.Body.Statements.Add(new VariableDeclarationStatement(type, "x"));
		TypeDeclaration holder = new() { Name = "Holder", ClassType = ClassType.Class };
		holder.Members.Add(method);
		extend?.Invoke(holder, method);

		SyntaxTree tree = new();
		if (ns.Length == 0)
		{
			tree.Members.Add(holder);
		}
		else
		{
			NamespaceDeclaration declaration = new(ns);
			declaration.Members.Add(holder);
			tree.Members.Add(declaration);
		}
		return (tree, holder, method);
	}

	private static string Simplify(SyntaxTree tree, IGlobalNameScope scope)
	{
		new GlobalQualificationSimplifier(scope).Run(tree, scope);
		return tree.ToString();
	}

	[TestCase("System", "String")]
	[TestCase("UnityEngine", "Vector3")]
	public void AFrameworkNameWithNothingInTheWayLosesItsQualifier(string ns, string type)
	{
		var (tree, _, _) = File("MyGame", Qualified(ns, type));
		string written = Simplify(tree, new FakeScope());
		Assert.That(written, Does.Contain($"{ns}.{type} x").And.Not.Contain("global::"));
	}

	[Test]
	public void AGameNameFromAnotherNamespaceLosesItsQualifier()
	{
		var (tree, _, _) = File("Other", Qualified("MyGame", "Type"));
		Assert.That(Simplify(tree, new FakeScope()), Does.Contain("MyGame.Type x").And.Not.Contain("global::"));
	}

	[Test]
	public void ATypeInTheGlobalNamespaceLosesItsQualifier()
	{
		var (tree, _, _) = File("MyGame", Qualified("GlobalHelper"));
		Assert.That(Simplify(tree, new FakeScope()), Does.Contain("GlobalHelper x").And.Not.Contain("global::"));
	}

	[Test]
	public void AClassNamedSystemInTheEnclosingNamespaceKeepsTheQualifier()
	{
		// namespace MyGame { class System {} ... global::System.String } - without global:: it is MyGame.System.String
		FakeScope scope = new();
		scope.Types.Add(("MyGame", "System"));
		var (tree, _, _) = File("MyGame", Qualified("System", "String"));
		Assert.That(Simplify(tree, scope), Does.Contain("global::System.String x"));
	}

	[Test]
	public void ANestedNamespaceOfTheSameNameKeepsTheQualifier()
	{
		// namespace Spine.Unity { ... global::Unity.IL2CPP ... }: `Unity` alone is Spine.Unity
		FakeScope scope = new();
		scope.Namespaces.UnionWith(["Unity", "Unity.IL2CPP", "Spine", "Spine.Unity"]);
		var (tree, _, _) = File("Spine.Unity", Qualified("Unity", "IL2CPP", "Thing"));
		Assert.That(Simplify(tree, scope), Does.Contain("global::Unity.IL2CPP.Thing x"));
	}

	[Test]
	public void AMemberOfTheEnclosingTypeOrItsBaseKeepsTheQualifier()
	{
		FakeScope scope = new();
		scope.Members["Holder"] = ["System"];
		var (tree, _, _) = File("MyGame", Qualified("System", "String"));
		Assert.That(Simplify(tree, scope), Does.Contain("global::System.String x"));
	}

	[Test]
	public void ALocalOfTheSameNameKeepsTheQualifier()
	{
		var (tree, _, _) = File("MyGame", Qualified("UnityEngine", "Vector3"),
			(_, method) => method.Body.Statements.Add(new VariableDeclarationStatement(new PrimitiveType("int"), "UnityEngine")));
		Assert.That(Simplify(tree, new FakeScope()), Does.Contain("global::UnityEngine.Vector3 x"));
	}

	[Test]
	public void ATypeParameterOfTheSameNameKeepsTheQualifier()
	{
		var (tree, _, _) = File("MyGame", Qualified("System", "String"),
			(holder, _) => holder.TypeParameters.Add(new TypeParameterDeclaration("System")));
		Assert.That(Simplify(tree, new FakeScope()), Does.Contain("global::System.String x"));
	}

	[Test]
	public void AnAliasOfTheSameNameKeepsTheQualifier()
	{
		var (tree, _, _) = File("MyGame", Qualified("System", "String"));
		tree.Members.InsertBefore(tree.Members.First(), new UsingAliasDeclaration("System", "Other"));
		Assert.That(Simplify(tree, new FakeScope()), Does.Contain("global::System.String x"));
	}

	[Test]
	public void AnEnclosingTypeThatCannotBeIdentifiedKeepsTheQualifier()
	{
		var (tree, _, _) = File("MyGame", Qualified("System", "String"));
		Assert.That(Simplify(tree, new UnknownMembers()), Does.Contain("global::System.String x"));
	}

	[Test]
	public void ANameThatExistsNowhereKeepsTheQualifier()
	{
		var (tree, _, _) = File("MyGame", Qualified("Nowhere", "Thing"));
		Assert.That(Simplify(tree, new FakeScope()), Does.Contain("global::Nowhere.Thing x"));
	}

	[Test]
	public void OnlyTheQualifierIsRemovedNotTheRestOfTheName()
	{
		var (tree, _, _) = File("", Qualified("System", "String"));
		string written = Simplify(tree, new FakeScope());
		Assert.That(written, Does.Contain("System.String x"));
		Assert.That(written, Does.Not.Contain(" String x"), "the namespace is still written");
	}

	private sealed class UnknownMembers : IGlobalNameScope
	{
		private readonly FakeScope inner = new();
		public bool NamespaceExists(string fullName) => inner.NamespaceExists(fullName);
		public bool TypeExists(string namespaceFullName, string name) => inner.TypeExists(namespaceFullName, name);
		public IReadOnlyCollection<string>? MemberNames(TypeDeclaration declaration) => null;
	}
}

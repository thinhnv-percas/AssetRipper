# Repository architecture, as measured

Written by walking the solution rather than from the upstream documentation. Everything here was
checked against the code at `git rev-parse HEAD` recorded in `iterations/000-baseline/source-commit.txt`.

## Solution

`AssetRipper.slnx`, 56 projects, `net10.0` throughout (`Source/Directory.Build.props`). Output goes to
`Source/0Bins/<project>/<config>/` — `AppendTargetFrameworkToOutputPath` is off, so there is no `net10.0`
path segment. Build and test:

```
dotnet build AssetRipper.slnx -c Release
dotnet test  AssetRipper.slnx -c Release --no-build
```

`Source/External/` is a vendored copy of Cpp2IL (`Cpp2IL.Core`, `LibCpp2IL`, `StableNameDotNet`,
`WasmDisassembler`), not a `PackageReference`. Its `Directory.Build.props` deliberately **shadows**
the parent rather than importing it, because the parent turns on `CheckForOverflowUnderflow` and
Cpp2IL does unchecked pointer arithmetic throughout.

## The pipeline, stage by stage

```
Input (APK / player directory / bundle)
  ↓  Game structure detection
  ↓  Serialized file + bundle import
  ↓  Assembly discovery
  ↓  IL2CPP metadata + binary analysis        (Cpp2IL, vendored)
  ↓  ISIL lifting and analysis passes          (Cpp2IL.Core/Analysis, ours)
  ↓  ISIL → CIL generation                     (Cpp2IL.Core/IlGenerator.cs, ours)
  ↓  AsmResolver assembly construction         (Il2CppIlRecoveryOutputFormat, ours)
  ↓  Asset + assembly processing               (AssetRipper.Processing)
  ↓  ILSpy decompilation to C#                 (ScriptDecompiler)
  ↓  Unity project export                      (AssetRipper.Export.UnityProjects)
Generated Unity project
```

### 1. Entry points

| Surface | Project | Type |
|---|---|---|
| Headless CLI used for measurement | `AssetRipper.Tools.SystemTester` | `Program.Main` → `Program.Rip` |
| Web GUI | `AssetRipper.GUI.Web` | ASP.NET minimal API |
| Desktop GUI | `AssetRipper.GUI.Free` | |

`Program.Rip` is the whole contract of a measurement run:

```csharp
settings.ImportSettings.ScriptContentLevel      = options.ScriptContentLevel;   // 3 recovers bodies
settings.ImportSettings.EmitIl2CppOffsets       = options.EmitIl2CppOffsets;
settings.ImportSettings.ReconstructNativeBodies = options.ReconstructNativeBodies;
settings.ImportSettings.Il2CppStructDbPath      = options.StructDbPath;
settings.ExportSettings.ScriptExportMode        = ScriptExportMode.Decompiled;

ExportHandler exportHandler = new(settings);
GameData gameData = exportHandler.LoadAndProcess(options.Inputs, LocalFileSystem.Instance);
exportHandler.Export(gameData, options.OutputPath, LocalFileSystem.Instance);
```

- **Project:** `AssetRipper.Tools.SystemTester`
- **Entry points:** `Program.Main`, `Program.Rip`, `Program.RunTests`
- **Inputs:** file/directory paths, `--script-level`, `--reconstruct-bodies`, `--struct-db`, `--output`, `--log`
- **Outputs:** a Unity project directory, a log file
- **Dependencies:** `AssetRipper.Export.UnityProjects`, `AssetRipper.Import`, `AssetRipper.Processing`
- **Tests:** none of its own; it *is* the integration harness

### 2. Game structure detection and asset import

- **Project:** `AssetRipper.Import`
- **Namespaces:** `AssetRipper.Import.Structure`, `.Structure.Platforms`, `.AssetCreation`
- **Important classes:** `GameStructure`, `PlatformGameStructure` and subclasses, `GameBundle`
- **Entry point:** `ExportHandler.Load` → `GameStructure.Load`
- **Inputs:** paths; **Outputs:** `GameData` (a `GameBundle` plus an `IAssemblyManager`)
- **Dependencies:** `AssetRipper.IO.Files`, `AssetRipper.Assets`, `AssetRipper.SourceGenerated`
- **Tests:** `AssetRipper.IO.Files.Tests`, `AssetRipper.Tests`

For the Impostor input the structure resolves to an Android APK layout: `assets/bin/Data` as the game
data path, `lib/arm64-v8a/libil2cpp.so` as the game assembly, and
`assets/bin/Data/Managed/Metadata/global-metadata.dat` as the metadata.

### 3. Assembly discovery and backend selection

- **Project:** `AssetRipper.Import`
- **Namespace:** `AssetRipper.Import.Structure.Assembly.Managers`
- **Important interfaces:** `IAssemblyManager`
- **Important classes:** `BaseManager`, `MonoManager`, `IL2CppManager`
- **Entry point:** `IL2CppManager.Initialize(PlatformGameStructure)`
- **Outputs:** a set of `AsmResolver.DotNet.AssemblyDefinition`

`IL2CppManager` is where the IL2CPP half of the tool is wired up. Its static constructor registers the
instruction sets with Cpp2IL's `InstructionSetRegistry` — note `Arm64InstructionSetSelector` rather
than a Cpp2IL type, because which ARM64 implementation to use depends on the content level and the
registry accepts only one set per architecture. Two static hooks decide whether a run is a recovery
run:

```csharp
public static List<Cpp2IlProcessingLayer>? RecoveryProcessingLayers { get; set; }
public static AsmResolverDllOutputFormat?  RecoveryOutputFormat     { get; set; }
```

Both are set by `Il2CppRecoverySetup.Apply(ImportSettings)` and are consulted only at
`ScriptContentLevel.Level3`; every other level keeps stock Cpp2IL behaviour.

### 4. IL2CPP analysis — the recovery feature

- **Projects:** `AssetRipper.Import` (the AssetRipper-side layer) and `Source/External/Cpp2IL.Core` (the analysis)
- **Namespaces:** `AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery`, `Cpp2IL.Core.Analysis`, `Cpp2IL.Core.InstructionSets`
- **Entry point:** `Il2CppRecoverySetup.Install` → the processing-layer list → `Il2CppIlRecoveryOutputFormat.BuildAssemblies`

Processing layers, in the order `Il2CppRecoverySetup` installs them (order is load-bearing):

1. `StructDbProcessingLayer` — loads `StructDb/<version>-<arch>.json.gz` and prepends the measured
   `Il2CppClass` / `MethodInfo` offsets through `Il2CppClassOffsetPatcher`. Must be first: several
   analysis passes match against those offsets, and the diagnostics layer below analyses methods for real.
2. `Il2CppRecoveryDiagnosticsProcessingLayer` — warns up front about an architecture that cannot
   produce bodies (WASM, and ARM64 before the ISIL-capable set existed).
3. `AttributeAnalysisProcessingLayer` — Cpp2IL's own; creates the lists later layers append to.
4. `MethodOverrideNameFixer`
5. `AttributeInjectorProcessingLayer` — `[Address]`, `[FieldOffset]`, `[Token]`, when `EmitIl2CppOffsets`.
6. `NativeSourceInjectionProcessingLayer` — the approximate C# attached to bodies IL recovery cannot
   express, when `--reconstruct-bodies`.

The analysis proper is 31 passes in `Source/External/Cpp2IL.Core/Analysis/`, run over the ISIL a
`Cpp2IlInstructionSet` lifted from machine code. The passes that matter most to correctness:
`SsaForm`, `SsaSimplifier`, `MetadataResolver`, `KeyFunctionRecovery`, `InjectedCheckRemover`,
`InterfaceDispatchRecovery`, `TypeCheckRecovery`, `RgctxResolver`, `Simplifier`, `CopyCoalescer`,
`MakeStructFolder`, `DeadCodeEliminator`, `UnreachableAfterThrow`.

Lifting is per architecture in `Source/External/Cpp2IL.Core/InstructionSets/`. Only
`X86InstructionSet`, `NewArmV8InstructionSet` and `ArmV7InstructionSet` produce ISIL;
`Arm64InstructionSet` and `WasmInstructionSet` return an empty list, which is indistinguishable from a
successful run that found no code.

- **Outputs:** CIL method bodies on AsmResolver types, plus the placeholder text and diagnostic counts
  the measurement reads
- **Tests:** `AssetRipper.Tests/Il2Cpp*`, and `Test/Scripts/{compile_recovered_scripts.sh,audit_recovered_scripts.py}`
  as the integration measurement

### 5. Processing

- **Project:** `AssetRipper.Processing`
- **Entry point:** `ExportHandler.Process` → `GetProcessors()`
- Assembly processors run first (`AttributePolyfillGenerator`, `MonoExplicitPropertyRepairProcessor`,
  `ObfuscationRepairProcessor`, `ForwardingAssemblyGenerator`, `NullRefReturnProcessor`,
  `UnmanagedConstraintRecoveryProcessor`, …), then asset processors (`SceneDefinitionProcessor`,
  `MainAssetProcessor`, `PrefabProcessor`, `SpriteProcessor`, `ScriptableObjectProcessor`, …).
- Each processor is logged **before** it runs, deliberately: a failed `Debug.Assert` calls
  `Environment.FailFast` and nothing else reaches the log, so the last `Processing :` line is the only
  thing that names the culprit.

### 6. Script export and decompilation

- **Project:** `AssetRipper.Export.UnityProjects`
- **Namespace:** `AssetRipper.Export.UnityProjects.Scripts`
- **Important classes:** `ScriptExporter`, `ScriptExportCollection`, `ScriptDecompiler`,
  `ILSpyAssemblyResolver`
- **Entry point:** `ScriptDecompiler.DecompileWholeProject(AssemblyDefinition, outputFolder, fileSystem)`
- ILSpy (`ICSharpCode.Decompiler`) does the C#. `LanguageVersion` defaults to `CSharp7_3`, which is why
  an attribute the recovery injects onto a lambda body is a compile error in the export.
- An assembly is decompiled as **one parallel unit**, so a single unreadable body used to cost every
  other file in it. `ScriptDecompiler` reads the failing file name out of the exception, adds it to
  `SkippedTypePaths` and decompiles the assembly again, up to `MaximumSkippedTypes = 16`.

### 7. Unity project export

- **Project:** `AssetRipper.Export.UnityProjects`
- **Entry point:** `ExportHandler.Export` → `ProjectExporter`
- **Outputs:** `Assets/`, `ProjectSettings/`, `AuxiliaryFiles/`
- `AuxiliaryFiles/GameAssemblies/` carries every assembly the run recovered or stubbed, which is what
  makes compiling the exported scripts against the metadata they came from possible.

## Test infrastructure

| Project | Scope |
|---|---|
| `AssetRipper.Tests` | 274 tests; the recovery's unit tests live here |
| `AssetRipper.IO.Files.Tests` | 137 |
| `AssetRipper.SerializationLogic.Tests` | 48 |
| `AssetRipper.Yaml.Tests` | 11 |
| `AssetRipper.Assets.Tests`, `AssetRipper.Numerics.Tests`, `AssetRipper.GUI.Web.Tests`, `AssetRipper.AssemblyDumper.Tests` | smaller |

One test fails in a Release build by construction:
`ExportIdHandlerTests.GetMainExportID_ValueGreaterThan100000_DebugAssertFails` asserts that a
`Debug.Assert` throws, and Release compiles those out. Recorded as the baseline, not a regression.

Integration measurement is not in the test projects; it is
`Test/Scripts/compile_recovered_scripts.sh` (Roslyn against the shipped assemblies, with optional
`ANALYZERS=<dir>` for Microsoft.Unity.Analyzers) and `Test/Scripts/audit_recovered_scripts.py`
(recovery against the source it was built from, per assembly).

## Unity version handling

`UnityVersion` comes from `PlatformGameStructure.Version` or `Cpp2IlApi.DetermineUnityVersion`, and
reaches the recovery in two places that matter: `StructDb/<version>-<arch>.json.gz` selection, and the
`Il2CppClass`/`MethodInfo` offsets that analysis passes match against. Writing an offset down rather
than reading it from the struct database has been the same bug repeatedly — see `ROADMAP.md` section 9.

## CI

`.github/workflows/test.yml`, `analysis.yml`, `publish.yml`, `docfx_build.yml`, all on `dotnet-version: 10.0.x`.

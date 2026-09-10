# The decompilation pipeline, as it actually runs

Traced by reading the call chain rather than by naming plausible classes. Everything below was
verified against a level-3 run on `Test/Input/Impostor`.

## Call graph

```
AssetRipper.Tools.SystemTester.Program.Main
  └─ Program.Rip(RipOptions)
       ├─ FullConfiguration                                    settings
       ├─ ExportHandler.LoadAndProcess(paths, fileSystem)
       │    ├─ ExportHandler.Load
       │    │    └─ GameStructure.Load
       │    │         ├─ PlatformGameStructure detection       (Android APK layout here)
       │    │         ├─ Il2CppRecoverySetup.Apply(ImportSettings)
       │    │         │    └─ Install  → IL2CppManager.RecoveryProcessingLayers
       │    │         │                → IL2CppManager.RecoveryOutputFormat
       │    │         │                → Arm64InstructionSetSelector.PreferIsilCapable = true
       │    │         └─ IL2CppManager.Initialize(PlatformGameStructure)
       │    │              ├─ Cpp2IlApi.InitializeLibCpp2Il(libil2cpp.so, global-metadata.dat, version)
       │    │              ├─ each Cpp2IlProcessingLayer.PreProcess
       │    │              ├─ each Cpp2IlProcessingLayer.Process
       │    │              └─ Il2CppIlRecoveryOutputFormat.BuildAssemblies(appContext)
       │    │                   └─ AsmResolverDllOutputFormatIlRecovery.FillMethodBody
       │    │                        └─ Cpp2IL.Core.IlGenerator.GenerateIl(methodContext, definition)
       │    └─ ExportHandler.Process(gameData)
       │         └─ each IAssetProcessor.Process                (assembly processors, then asset)
       └─ ExportHandler.Export(gameData, outputPath, fileSystem)
            └─ ProjectExporter
                 └─ ScriptExporter / ScriptExportCollection
                      └─ ScriptDecompiler.DecompileWholeProject(assembly, folder, fileSystem)
                           └─ ILSpyWholeProjectDecompiler (ICSharpCode.Decompiler)
```

## Where a method body comes from

A recovered body passes through six representations. Naming them matters because a defect has to be
fixed in the one that first got it wrong.

| # | Representation | Produced by | Lives in |
|---|---|---|---|
| 1 | ARM64 / x86 machine code | the game | `libil2cpp.so` |
| 2 | ISIL (`Cpp2IL.Core.ISIL.Instruction`) | `NewArmV8InstructionSet.GetIsilFromMethod` | `MethodAnalysisContext.ConvertedIsil` |
| 3 | ISIL in SSA form, over a CFG of `Block` | `ISILControlFlowGraph`, `SsaForm` | `MethodAnalysisContext.ControlFlowGraph` |
| 4 | analysed ISIL — calls resolved, checks removed, types inferred | the 31 passes in `Cpp2IL.Core/Analysis` | same CFG, rewritten in place |
| 5 | CIL | `IlGenerator.GenerateIl` | `MethodDefinition.CilMethodBody` |
| 6 | C# text | ILSpy, via `ScriptDecompiler` | `Assets/Scripts/<assembly>/*.cs` |

The lifter is chosen per architecture and only three of the five produce anything:
`X86InstructionSet`, `NewArmV8InstructionSet`, `ArmV7InstructionSet`. `Arm64InstructionSet` and
`WasmInstructionSet` return an empty instruction list, which is indistinguishable from a method that
legitimately has no code — hence `Il2CppRecoveryDiagnosticsProcessingLayer` warning about the
architecture before anything else runs.

## Reading a defect backwards

Every generated-C# defect is anchored to one of the six above. The question that places it:

| The generated C# shows | First wrong at | Fix belongs in |
|---|---|---|
| a `Method not found @ADDR` placeholder | 4 — nothing resolved the address | `MetadataResolver`, `KeyFunctionRecovery` |
| an `Unmanaged memory load` placeholder | 4 — the base was never typed | the type fixpoint in `ResolveTypesAndFields` |
| `object`-typed locals and casts everywhere | 4 — the type fixpoint had no constraint | `ResolveTypesAndFields`, `PropagateFromCallParameters` |
| a value that should be a `Vector3` reading as one `float` | 2 — the lifter named one register of an aggregate | `NewArmV8InstructionSet`, `Arm64CallingConventionResolver` |
| `if (x == null) break;` inside every loop | 4 — a check's shape was not matched | `InjectedCheckRemover` |
| `x._002Ector()` | 5 — a constructor call written as a member call | `IlGenerator`, the `.ctor` case |
| `Expected O, but got I` from ILSpy | 5 — the CIL is not well typed | `IlGenerator`, `LoadOperand` / the arithmetic cases |
| a whole body replaced by `throw new Exception(<a stack trace>)` | 5 — `GenerateIl` threw | `IlGenerator` |
| a `goto` thicket | 4 — an unremoved check made a block a join | `InjectedCheckRemover` |
| a coroutine left as a generated class | 5 — the kickoff shape ILSpy folds was not emitted | `IlGenerator.InlinedConstructor` |
| a whole file missing | 6 — ILSpy threw out of a transform | `ScriptDecompiler` |

## Diagnostics available without a debugger

- **`IsilDump`.** `CPP2IL_DUMP_METHOD=<substring of the full name>` and `CPP2IL_DUMP_DIR=<dir>` write
  the ISIL of that method at each stage of the analysis, plus a `trace.txt`. Note the diagnostics
  layer analyses methods for real, so the first dump of a method may be that sample rather than the
  run that produces the body.
- **Placeholder text in the output.** Every giving-up point in `IlGenerator` writes a string that a
  grep can count. `Test/Scripts/collect_metrics.sh` counts all of them into one report.
- **The recovery summary in the log.** `Il2Cpp method body recovery: …` lines, including the
  breakdown of what the unresolved loads and the untyped locals actually are, raised from the one
  place that gives up on each so the totals match the placeholder counts.
- **`Cpp2IL [Error] : Decompiling <method> failed:`** in the log. `FillMethodBody` catches whatever
  `GenerateIl` throws and puts the exception text in the body, so the method still exports and reads
  as a `throw`. Count these first: a body that threw contributes no placeholders at all, so it is
  invisible in every other metric.

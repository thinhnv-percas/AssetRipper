# Validation blocked on Unity

Unity is not installed in this container and cannot be installed from it. Everything below is
therefore **NOT RUN** — not passing, not failing. Nothing in this repository may report these as
passing until `Test/Scripts/unity/run_all.sh` has actually been executed against a real Unity
2022.3.62f2 install and its results recorded in an iteration.

The scripts exist and are wired; they refuse to run rather than simulate anything, and every one of
them exits non-zero when Unity is absent.

| # | Test | Why blocked | Command | Expected validation |
|---|---|---|---|---|
| U1 | Project import | Needs the Unity editor to build a `Library/` from `Assets/` | `Test/Scripts/unity/import_project.sh <rip output>/Impostor` | Editor exits 0; `Library/` produced; no import errors in `Editor.log` |
| U2 | Script compilation | Unity compiles against the real UnityEngine assemblies, not the stubs the rip ships, and is authoritative for Unity-specific assemblies | `Test/Scripts/unity/compile_scripts.sh <rip output>/Impostor` | No `error CS` in `Editor.log`; `Library/ScriptAssemblies/Assembly-CSharp.dll` produced |
| U3 | Asset database refresh | Needs a working `Library/` from U1 | `Test/Scripts/unity/refresh_assets.sh <rip output>/Impostor` | Refresh completes; no missing-GUID or broken-reference warnings |
| U4 | Scene load | Needs U1–U3 | `Test/Scripts/unity/validate_scenes.sh <rip output>/Impostor` | Every scene in `ProjectSettings/EditorBuildSettings.asset` opens with no `NullReferenceException` in `Editor.log` |
| U5 | Prefab load | Needs U1–U3 | `Test/Scripts/unity/validate_prefabs.sh <rip output>/Impostor` | Every `.prefab` loads and instantiates; no missing `MonoBehaviour` script references |
| U6 | ScriptableObject load | Needs U1–U3 | `Test/Scripts/unity/validate_prefabs.sh <rip output>/Impostor` (same pass) | Every `.asset` deserialises with its script resolved |
| U7 | Player build | Needs U2 plus an Android SDK/NDK | `Test/Scripts/unity/build_player.sh <rip output>/Impostor` | `BuildPlayer` returns `BuildResult.Succeeded` |
| U8 | Runtime smoke test | Needs U7 and a device or emulator | `Test/Scripts/unity/smoke_test.sh <apk>` | First scene loads; `MonoBehaviour` lifecycle runs; no exception in `Player.log` in the first 30 seconds |
| U9 | Runtime differential test | Needs U7, and a harness that drives both the reference project and the recovered one with identical input | not written — see below | Reference and recovered agree on the methods the reference source covers |

## What can be run here, and is

These are not blocked and are run every iteration. They are weaker than U1–U9 in two specific ways
worth stating plainly.

| Test | Command | Runs |
|---|---|---|
| Repository build | `dotnet build AssetRipper.slnx -c Release` | yes |
| Unit and regression tests | `dotnet test AssetRipper.slnx -c Release --no-build` | yes |
| Decompilation | `AssetRipper.Tools.SystemTester --script-level 3 …` | yes |
| Roslyn compilation of the exported scripts | `Test/Scripts/compile_recovered_scripts.sh` | yes |
| Unity analyzers over the exported scripts | same, with `ANALYZERS=<dir>` | yes |
| Semantic audit against the reference source | `Test/Scripts/audit_recovered_scripts.py` | yes |
| Golden shape checks | `Test/Scripts/check_recovered_shapes.sh` | yes |
| Field-layout self-check against metadata | reported by the run; gated by the shape checks | yes |

**Where Roslyn is weaker than U2.** The rip ships the assemblies it recovered and stubbed under
`AuxiliaryFiles/GameAssemblies`, and the harness compiles against those. A member IL2CPP stripped from
the build is absent from the stub, so it reads as an error even where the export is fine against a
real Unity install — `Math.PI`, `Quaternion.Euler(Vector3)`, `StructLayoutAttribute`. In the other
direction it is stricter than a real install for the framework internals il2cpp inlined
(`List<T>._items`), which a real `List<T>` also does not expose. U2 settles both.

**Why U9 is not written.** A differential test needs both sides to execute. Neither can here, so a
harness for it would be untested code pretending to be validation. The scripts for U1–U8 are written
because each is a single editor invocation whose contract is stable; U9 needs a driver design that
should be made against a working U7 rather than guessed at.

## Running them when Unity arrives

```
UNITY=/path/to/Unity/2022.3.62f2/Editor/Unity \
  Test/Scripts/unity/run_all.sh iterations/<N>/output/Impostor
```

`run_all.sh` stops at the first failing stage, since every later one depends on it, and writes each
stage's `Editor.log` into `iterations/<N>/reports/unity/`. Record the result in the iteration and in
`AGENT_STATE.md`; only then may the verdict move off `PASS_WITH_KNOWN_LIMITATIONS`.

# The reference source, and how far it can be trusted

## Repository

| | |
|---|---|
| Repository | `https://github.com/thinhabc01/Impostor-Sort-Puzzle-Pro` |
| Commit | `a5b796283d7d7cc457b7c73ebf7b5869776d755b` |
| Tag | `v1` (points at that commit) |
| Committed | 2026-09-08 |
| Checkout | `artifacts/reference/Impostor-Sort-Puzzle-Pro` |
| Unity version | `2022.3.62f2` (`ProjectSettings/ProjectVersion.txt`) |

The repository has two commits and one tag, and `v1`, `HEAD` and the release the binary came from are
all the same commit, so there is no revision to choose. The Unity version in `ProjectVersion.txt`
matches the version the binary reports, which is what makes this reference an oracle rather than an
approximation.

## Correspondence with the binary

`artifacts/input/METADATA.json` records the release asset's hash. `libil2cpp.so`,
`global-metadata.dat` and `data.unity3d` in the tracked `Test/Input/Impostor` are byte-identical to
the ones inside that APK, so the recovery under test reads exactly the bytes the reference source was
built into.

## Assemblies worth comparing

The game's own code is `Assembly-CSharp`, and within it only these files have a reference to compare
against:

```
Assets/AdManager.cs
Assets/GDPR.cs
Assets/_Impostor 3/Scripts/Advertisement/AdvertisementService.cs
Assets/_Impostor 3/Scripts/Common/{CSVHelper,CSVReader,Extensions,Log,Random,ScriptableObjectUtility,UtilityGame}.cs
Assets/_Impostor 3/Scripts/Controller/GameController.cs
Assets/_Impostor 3/Scripts/Core/Inventory/{Inventory,ShortInventory}.cs
Assets/_Impostor 3/Scripts/Core/Observer/{Common,EventDispatcher,EventID}.cs
Assets/_Impostor 3/Scripts/Core/Singletons/{SingletonMono,SingletonMonoDontDestroy}.cs
Assets/_Impostor 3/Scripts/Core/{StructStorage,TimeInGame}.cs
Assets/_Impostor 3/Scripts/DataUser/{DataCreatePlayer,IAPManager}.cs
Assets/_Impostor 3/Scripts/GamePlay/{Box,DataController,GUIManager,GameHelper,GamePlayController,GraphicController,Imposter,RatingReviewManager}.cs
Assets/_Impostor 3/Scripts/Manager/GameManager.cs
Assets/_Impostor 3/Scripts/Resources/{ItemBase,ResourcesUtil,UserResource}.cs
Assets/_Impostor 3/Scripts/TestCube.cs
```

`Assets/Editor/*.cs` and `Assets/GoogleMobileAds/Editor/*.cs` are Editor-only and are correctly
absent from the build, so their absence from the recovery is not a defect. Everything under
`Assets/ThirdParties/` (Spine), `Assets/Spine Examples/`, `Assets/Plugins/` and the DOTween,
LeanPool, CodeStage and Zitga assemblies ships as its own assembly and has no reference here beyond
the vendored copies in the repository.

## Two traps this reference sets

Both are recorded in `docs/articles/RecoveredScriptVerification.md` and both have already produced a
wrong conclusion once:

- **The exporter writes one type per file.** `UserResource.cs` declares four types, and the export is
  four files. A per-file member diff against the reference therefore invents missing members.
- **`#if UNITY_EDITOR` is not in the build.** A method inside one is absent from the binary and
  correctly absent from the recovery.

## Where the source is not the oracle

The binary is the lower-level ground truth, and on three counts the recovery is right and the source
is not what shipped. These are recorded per case in `docs/articles/ImpostorSortScriptAudit.md`:

- **A dead argument the C++ compiler dropped.** `Box.SetUp` passes `isStand: false` unconditionally
  where the source computes `i == 0`; `Imposter.SetUp` ignores the parameter, so the compiler moved a
  literal 0. There is nothing in the binary to recover the expression from.
- **A call il2cpp inlined.** `gpc.ResetPeeking()` and `TurnOnEffectWrong()` appear as their bodies.
- **`Mathf`, `Vector3` and `Quaternion` helpers are inlined** throughout.

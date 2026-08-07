# Package GUID Remapping

A plan for replacing decompiled copies of Unity packages with the official ones, without breaking
every reference to them.

## The problem

When a game is ripped, packages that shipped inside it are ripped too. TextMeshPro comes out as
decompiled scripts, shaders, materials and font assets under `Assets`, and none of it is as good as
the real package: the scripts are approximate, and shaders may be stubs depending on the shader
export mode.

The obvious fix is to delete the ripped copy and install the real package from the Package Manager.
That immediately breaks the project. Every prefab, scene and material refers to package content by
GUID, those references point at the ripped files, and the official package uses entirely different
GUIDs. Deleting the ripped files leaves dangling references; keeping both leaves duplicate types.

So the work is not deleting files, it is rewriting every reference to point at the official package.

## How a reference is written

Unity stores an asset's identity in its `.meta` file:

```yaml
guid: gb375d2c421da9a141a06fc1e9774eae5
```

and refers to it from other assets as a pair:

```yaml
m_Shader: {fileID: 4800000, guid: 446635c639a68754da00264d9ac02476, type: 3}
```

The `guid` says which file, and the `fileID` says which object inside that file. **Both can change
when swapping to the official package**, and that is the part a naive GUID-only replacement gets
wrong.

For most asset types the `fileID` is a constant belonging to the asset type, so it is the same on
both sides and only the GUID needs rewriting:

| Asset | Ripped form | Official form | fileID |
| --- | --- | --- | --- |
| Shader | `.shader` file | `.shader` file | same constant on both sides |
| Material | `.mat` file | `.mat` file | same constant on both sides |
| Texture | image file | image file | same constant on both sides |
| ScriptableObject asset | `.asset` file | `.asset` file | same constant on both sides |

Scripts are the exception, and the reason a GUID-only tool silently half works:

| | Ripped form | Official form |
| --- | --- | --- |
| What ships | one `.cs` file per type | usually a compiled assembly |
| GUID | per `.cs` file | one for the whole assembly |
| `fileID` | the constant for a script file | a hash derived from the namespace and class name |

A `MonoBehaviour` on a prefab refers to its script by that pair. Remapping only the GUID leaves the
`fileID` pointing at nothing inside the assembly, so the reference still resolves to no script. It
looks fixed in a diff and is still broken in the editor.

Shaders need the same care for a different reason: materials refer to shaders by GUID exactly like
components refer to scripts, so a material whose shader GUID is not remapped loses its shader and
renders magenta. Shaders are less dangerous than scripts only because their `fileID` does not change.

## Prior art

[PackageCorrector](https://github.com/ningengit/PackageCorrector) solves the GUID half of this: it
reads the GUID out of a ripped package's `.meta` files, finds the file with the same name in the
official package, takes its GUID, and replaces the old one throughout the project.

Two things to know before borrowing from it:

- **It has no license.** Absent one, the code is all rights reserved and cannot be copied into a
  GPL-3.0 project. The approach itself is not copyrightable and is simple enough to write from a
  description, so this plan is an independent implementation rather than a port.
- **It matches files by name and rewrites GUIDs only.** That is correct for shaders and other assets
  whose `fileID` is type derived, and incomplete for scripts.

AssetRipper's premium edition attacks the same problem from the other end, by exporting real package
references so the conflict never arises. This plan is the free edition's remedy after the fact, and
the two do not overlap.

## Plan

### Phase 1 — Mapping, no writes

Build the old to new mapping and report it. Nothing is modified.

- Walk the ripped package directory, reading each `.meta` for its GUID, keyed by the file's path
  relative to the package root. Matching on the relative path rather than the bare file name matters:
  names like `Editor.cs` or `Common.hlsl` repeat across a package and would otherwise be ambiguous.
- Walk the official package the same way. Fall back to matching on file name only when it is unique
  on both sides.
- Emit a report: matched pairs, ripped files with no counterpart, official files nothing points at,
  and any case where two ripped GUIDs would map onto one official GUID.

The output of this phase is a reviewable file, not a modified project. Anything unmatched is a
decision for the user, not something to guess at.

### Phase 2 — Rewriting

- Rewrite GUIDs in `.meta` files and in the YAML asset files that carry references: `.prefab`,
  `.unity`, `.asset`, `.mat`, `.controller`, `.anim`, `.spriteatlas`, `.asmdef`, plus the shader and
  material variants a project may contain.
- Handle the script `fileID` case above. When the official package ships an assembly, the new
  `fileID` has to be computed for each type rather than carried over.
- Refuse to run against a dirty working tree unless explicitly overridden, and write a backup
  otherwise. This edits an entire project in place and a bad run is expensive to undo by hand.
- Re-run the Phase 1 report afterwards, so the result can be checked rather than trusted.

### Phase 3 — Interface

A page in the GUI taking the three directories the job needs: the ripped package, the official
package (typically under `Library/PackageCache`), and the project's `Assets` folder. Show the Phase 1
report and require a confirmation before any write.

### Phase 4 — Optional, at export time

AssetRipper already knows which assembly each script came from, so it knows which output belongs to a
package. Given a Unity installation to read `PackageCache` from, the mapping could be applied while
exporting and the manual step would disappear. Worth doing only once phases 1 to 3 are trusted.

## Risks

- **Silent partial success.** A GUID-only pass makes the diff look right while script references stay
  broken. Phase 1's report exists so the result is measured rather than assumed.
- **Version drift.** The official package has to be the version the game shipped with. A different
  version may have added, removed or renamed files, which shows up as unmatched entries.
- **One way.** Rewriting is destructive. Backups and a clean working tree are requirements, not
  suggestions.

## Effort

Phases 1 and 2 are the bulk, on the order of two to three days, most of it in the script `fileID`
handling and in tests that prove a project survives the rewrite. Phase 3 adds about a day. Phase 4 is
open ended and should not be scheduled until the earlier phases have been used on a real project.

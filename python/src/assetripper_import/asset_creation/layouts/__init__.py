"""
Hand-written TypeTreeNodeStruct layouts, for objects in files that embed no type tree of
their own (typically a stripped release player build -- see registry.py's docstring).

Implemented: GameObject, Transform, TextAsset, MonoScript, AssetBundle, **Texture2D,
AudioClip, Sprite, Material** (Phase 18, 2026-08-01), **Mesh** (Phase 18, same day, second
pass) -- the types this port has the highest confidence in the exact binary layout of. The
last five are qualitatively different from the first five: this package's docstring used to
say formats this volatile were "too low confidence to be worth the risk" without an
authoritative reference to test against -- that was true until a real fixture became
available (`python/input-test/demo-android.apk`, a real Unity 2022.3.62f2 build, via Git LFS).
Each was reverse-engineered by reading real bytes and checked against **every** sample of
that type in the fixture (`SerializableStructure.try_read` must consume the exact byte count,
with plausible field values) -- see each module's own docstring for exactly what was and
wasn't independently verified this way (some rarely-populated sub-structures, like Sprite's
`m_Bones`, Material's `m_BuildTextureStacks`, or Mesh's `m_Shapes`/`m_CompressedMesh`, are
still best-effort guesses because every real sample had them empty). Mesh in particular was
first hand-traced offset-by-offset with a throwaway script (not this DSL) against all 29 real
Meshes in the fixture before being encoded here, given how many version-gated fields it has.

Deliberately not implemented, and why:
- MonoBehaviour: fundamentally not modelable this way. Its fields are user-script-defined,
  not fixed by class ID -- a "layout" would have to guess arbitrary user code. Files that
  embed a type tree already read MonoBehaviours correctly (Phase 1); files that don't stay
  UnknownObject, matching upstream's own behavior when no assembly/type-tree information is
  available (see GameAssetFactory's docstring).
- ResourceManager: needs m_DependentAssets before its (higher-value) m_Container field, and
  this port doesn't have confident knowledge of m_DependentAssets' exact structure. Guessing
  the leading field wrong would misalign m_Container too, defeating the purpose.
- BuildSettings: real bytes show ~28 bytes of flag fields this port can't confidently name
  between `m_Scenes` and the editor version string (older public references for this class
  are for a much older, simpler Unity era) -- see python/ROADMAP.md Phase 18.
- Shader: investigated (Phase 18, third pass, same day as Mesh) and deliberately deferred, not
  just skipped without looking. Reading Perfare/AssetStudio's `Shader.cs` directly confirmed:
  for Unity >=5.5 (including this port's real fixture), `m_Script` no longer exists at all --
  everything lives in `m_ParsedForm` (`SerializedShader`), a tree ~15+ structs deep
  (SubShader[] -> Pass[] -> SerializedProgram/SerializedSubProgram, one per GPU target, plus
  blend/stencil/fog state and property tables), each with its own independent version gates.
  Real samples in the fixture run 4KB-340KB (vs. Mesh's largest at 36KB), confirming this is
  compiled GPU program data, not lightweight metadata. Unlike Mesh, there's no safe way to
  verify a candidate layout incrementally -- `SerializableStructure.try_read` requires the
  *entire* object's bytes to match, so one wrong field anywhere in that ~15-struct tree
  invalidates every sample, all at once. This class already exports gracefully today (as
  `UnknownObject`, via `DummyShaderTextExporter`'s fallback) -- attempting the full structure
  is a value-add, not a bug fix, so it wasn't worth the same order-of-magnitude effort Mesh
  took without first trying it on the smallest 1-2 real samples by hand (Mesh's methodology),
  which is where a future attempt should start. See python/ROADMAP.md Phase 18 for details.
- SpriteAtlas, Font, VideoClip, PlayerSettings, TerrainData, AnimationClip: still not
  attempted at all (not even investigated the way Shader was).
"""
from .registry import LayoutRegistry, default_layout_provider, default_registry

__all__ = ["LayoutRegistry", "default_registry", "default_layout_provider"]

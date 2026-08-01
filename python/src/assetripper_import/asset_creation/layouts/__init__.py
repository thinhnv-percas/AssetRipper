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
- SpriteAtlas, Font, VideoClip, Shader, PlayerSettings, TerrainData, AnimationClip: still not
  attempted. Shader especially -- compiled per-platform bytecode blobs -- is a large,
  historically volatile format where even with a real fixture available, the risk/effort of
  getting every field and version cutoff exactly right hasn't been judged worth it yet. See
  python/ROADMAP.md Phase 18 for what's next.
"""
from .registry import LayoutRegistry, default_layout_provider, default_registry

__all__ = ["LayoutRegistry", "default_registry", "default_layout_provider"]

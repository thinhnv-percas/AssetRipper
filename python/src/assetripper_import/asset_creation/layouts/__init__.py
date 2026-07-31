"""
Hand-written TypeTreeNodeStruct layouts, for objects in files that embed no type tree of
their own (typically a stripped release player build -- see registry.py's docstring).

Implemented: GameObject, Transform, TextAsset, MonoScript, AssetBundle -- the types this
port has the highest confidence in the exact binary layout of, given no authoritative
reference is available (see the module docstring in builder.py). Confidence varies by
type; see each module's own docstring.

Deliberately not implemented, and why:
- MonoBehaviour: fundamentally not modelable this way. Its fields are user-script-defined,
  not fixed by class ID -- a "layout" would have to guess arbitrary user code. Files that
  embed a type tree already read MonoBehaviours correctly (Phase 1); files that don't stay
  UnknownObject, matching upstream's own behavior when no assembly/type-tree information is
  available (see GameAssetFactory's docstring).
- ResourceManager: needs m_DependentAssets before its (higher-value) m_Container field, and
  this port doesn't have confident knowledge of m_DependentAssets' exact structure. Guessing
  the leading field wrong would misalign m_Container too, defeating the purpose.
- Texture2D, Sprite, SpriteAtlas, Mesh, AudioClip, Font, VideoClip, Material, Shader,
  BuildSettings, PlayerSettings, TerrainData, AnimationClip: large, historically volatile
  formats (many fields, frequent version-gated additions/removals) where this port's
  confidence in getting every field and version cutoff exactly right is too low to be
  worth the risk of a plausible-but-subtly-wrong layout. These are exactly the formats an
  authoritative reference (a real Tpk database, or a real Unity installation to test
  against) would be needed to get right, per the phase plan's risk notes.
"""
from .registry import LayoutRegistry, default_layout_provider, default_registry

__all__ = ["LayoutRegistry", "default_registry", "default_layout_provider"]

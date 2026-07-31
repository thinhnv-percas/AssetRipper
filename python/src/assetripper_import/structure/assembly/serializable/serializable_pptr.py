"""
The dynamic reader's stand-in for the generated `PPtr_Object` classes.

Upstream, `SerializableTypeExtensions.CreateInstance` returns `PPtr_Object.Create(version)`
-- one of AssemblyDumper's generated per-version PPtr classes -- which knows whether
`m_PathID` is 32- or 64-bit for that Unity version. Those classes aren't available here.

Instead, the width is taken from the type tree itself: a PPtr node carries real `m_FileID`
and `m_PathID` sub-nodes whose type names state their widths exactly (see
type_trees.serializable_tree_type._pointer_type_for). That is strictly more accurate than a
version heuristic -- upstream's own TypeTreeNodeStruct.cs carries a
"Might need to handle m_PathID being SInt32 on older versions" note at the equivalent spot.
"""
from __future__ import annotations

from assetripper_assets.metadata.pptr import PPtr


class SerializablePPtr:
    __slots__ = ("file_id", "path_id", "path_id_is_64bit")

    def __init__(self, path_id_is_64bit: bool = True):
        self.file_id: int = 0
        self.path_id: int = 0
        self.path_id_is_64bit = path_id_is_64bit

    def read(self, reader, flags) -> None:
        self.file_id = reader.read_int32()
        self.path_id = reader.read_int64() if self.path_id_is_64bit else reader.read_int32()

    def to_pptr(self) -> PPtr:
        return PPtr(self.file_id, self.path_id)

    def walk_editor(self, walker) -> None:
        walker.visit_pptr(self.to_pptr())

    def fetch_dependencies(self):
        yield "", self.to_pptr()

    def reset(self) -> None:
        self.file_id = 0
        self.path_id = 0

    @property
    def is_null(self) -> bool:
        return self.path_id == 0

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, SerializablePPtr):
            return NotImplemented
        return self.file_id == other.file_id and self.path_id == other.path_id

    def __hash__(self) -> int:
        return hash((self.file_id, self.path_id))

    def __str__(self) -> str:
        return f"PPtr({self.file_id}, {self.path_id})"

    __repr__ = __str__

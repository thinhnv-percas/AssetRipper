"""Port of Source/AssetRipper.IO.Files/SerializedFiles/TransferMetaFlags.cs"""
from __future__ import annotations

from enum import IntFlag


class TransferMetaFlags(IntFlag):
    NO_TRANSFER_FLAGS = 0x0
    HIDE_IN_EDITOR = 0x1
    """Hides the variable in the property editor."""
    UNKNOWN1 = 0x2
    UNKNOWN2 = 0x4
    UNKNOWN3 = 0x8
    NOT_EDITABLE = 0x10
    """Makes a variable not editable in the property editor."""
    UNKNOWN5 = 0x20
    STRONG_PPTR = 0x40
    """A Strong PPtr forces the referenced object to be cloned, unlike the default (weak) PPtr."""
    UNKNOWN7 = 0x80
    TREAT_INTEGER_VALUE_AS_BOOLEAN = 0x100
    """Makes an integer variable appear as a checkbox in the editor."""
    UNKNOWN9 = 0x200
    UNKNOWN10 = 0x400
    SIMPLE_EDITOR = 0x800
    """Show in simplified editor."""
    DEBUG_PROPERTY = 0x1000
    """Shown in expert mode in the inspector but not serialized normally."""
    UNKNOWN13 = 0x2000
    ALIGN_BYTES = 0x4000
    ANY_CHILD_USES_ALIGN_BYTES = 0x8000
    IGNORE_WITH_INSPECTOR_UNDO = 0x10000
    UNKNOWN17 = 0x20000
    EDITOR_DISPLAYS_CHARACTER_MAP = 0x40000
    IGNORE_IN_META_FILES = 0x80000
    """Ignore this property when reading or writing .meta files."""
    TRANSFER_AS_ARRAY_ENTRY_NAME_IN_META_FILES = 0x100000
    TRANSFER_USING_FLOW_MAPPING_STYLE = 0x200000
    """Uses YAML flow mapping style (all properties on one line, with "{}")."""
    GENERATE_BITWISE_DIFFERENCES = 0x400000
    DONT_ANIMATE = 0x800000
    TRANSFER_HEX64 = 0x1000000
    CHAR_PROPERTY_MASK = 0x2000000
    DONT_VALIDATE_UTF8 = 0x4000000
    FIXED_BUFFER = 0x8000000
    DISALLOW_SERIALIZED_PROPERTY_MODIFICATION = 0x10000000
    UNKNOWN29 = 0x20000000
    UNKNOWN30 = 0x40000000
    UNKNOWN31 = 0x80000000


def is_hide_in_editor(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.HIDE_IN_EDITOR)


def is_not_editable(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.NOT_EDITABLE)


def is_strong_pptr(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.STRONG_PPTR)


def is_treat_integer_value_as_boolean(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.TREAT_INTEGER_VALUE_AS_BOOLEAN)


def is_simple_editor(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.SIMPLE_EDITOR)


def is_debug_property(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.DEBUG_PROPERTY)


def is_align_bytes(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.ALIGN_BYTES)


def is_any_child_uses_align_bytes(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.ANY_CHILD_USES_ALIGN_BYTES)


def is_ignore_with_inspector_undo(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.IGNORE_WITH_INSPECTOR_UNDO)


def is_editor_displays_character_map(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.EDITOR_DISPLAYS_CHARACTER_MAP)


def is_ignore_in_meta_files(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.IGNORE_IN_META_FILES)


def is_transfer_as_array_entry_name_in_meta_files(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.TRANSFER_AS_ARRAY_ENTRY_NAME_IN_META_FILES)


def is_transfer_using_flow_mapping_style(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.TRANSFER_USING_FLOW_MAPPING_STYLE)


def is_generate_bitwise_differences(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.GENERATE_BITWISE_DIFFERENCES)


def is_dont_animate(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.DONT_ANIMATE)


def is_transfer_hex64(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.TRANSFER_HEX64)


def is_char_property_mask(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.CHAR_PROPERTY_MASK)


def is_dont_validate_utf8(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.DONT_VALIDATE_UTF8)


def is_fixed_buffer(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.FIXED_BUFFER)


def is_disallow_serialized_property_modification(flags: TransferMetaFlags) -> bool:
    return bool(flags & TransferMetaFlags.DISALLOW_SERIALIZED_PROPERTY_MODIFICATION)


def split(flags: TransferMetaFlags) -> list[str]:
    if flags == TransferMetaFlags.NO_TRANSFER_FLAGS:
        return ["NO_TRANSFER_FLAGS"]
    return [f.name for f in TransferMetaFlags if f.name != "NO_TRANSFER_FLAGS" and flags & f]

"""ECMA-335 II.22 table numbers and column layouts, plus II.24.2.6 coded index tag tables.

This is the declarative data the rest of the reader is built around: `tables_stream.py` uses
`TABLE_COLUMNS`/`CODED_INDEX_TABLES` to compute every column's byte width (which depends on
*other* tables' row counts, so it can only be done after every table's row count is known) and
to decode each row into a tuple of plain values.

Column kinds:
    ("u2",)            fixed 2-byte unsigned field (flags, versions, ...)
    ("u4",)             fixed 4-byte unsigned field (RVAs, TypeAttributes, ...)
    ("str",)            index into #Strings
    ("guid",)           index into #GUID
    ("blob",)           index into #Blob
    ("tbl", TableId)    simple index into one specific table (1-based row number)
    ("coded", str)      coded index into one of several tables (see CODED_INDEX_TABLES),
                        tag in the low bits, 1-based row number in the rest
"""
from __future__ import annotations

from enum import IntEnum


class TableId(IntEnum):
    MODULE = 0x00
    TYPE_REF = 0x01
    TYPE_DEF = 0x02
    FIELD_PTR = 0x03
    FIELD = 0x04
    METHOD_PTR = 0x05
    METHOD_DEF = 0x06
    PARAM_PTR = 0x07
    PARAM = 0x08
    INTERFACE_IMPL = 0x09
    MEMBER_REF = 0x0A
    CONSTANT = 0x0B
    CUSTOM_ATTRIBUTE = 0x0C
    FIELD_MARSHAL = 0x0D
    DECL_SECURITY = 0x0E
    CLASS_LAYOUT = 0x0F
    FIELD_LAYOUT = 0x10
    STAND_ALONE_SIG = 0x11
    EVENT_MAP = 0x12
    EVENT_PTR = 0x13
    EVENT = 0x14
    PROPERTY_MAP = 0x15
    PROPERTY_PTR = 0x16
    PROPERTY = 0x17
    METHOD_SEMANTICS = 0x18
    METHOD_IMPL = 0x19
    MODULE_REF = 0x1A
    TYPE_SPEC = 0x1B
    IMPL_MAP = 0x1C
    FIELD_RVA = 0x1D
    ENC_LOG = 0x1E
    ENC_MAP = 0x1F
    ASSEMBLY = 0x20
    ASSEMBLY_PROCESSOR = 0x21
    ASSEMBLY_OS = 0x22
    ASSEMBLY_REF = 0x23
    ASSEMBLY_REF_PROCESSOR = 0x24
    ASSEMBLY_REF_OS = 0x25
    FILE = 0x26
    EXPORTED_TYPE = 0x27
    MANIFEST_RESOURCE = 0x28
    NESTED_CLASS = 0x29
    GENERIC_PARAM = 0x2A
    METHOD_SPEC = 0x2B
    GENERIC_PARAM_CONSTRAINT = 0x2C


# Coded index kinds -> the ordered list of tables their tag selects between (tag = position
# in this list). Table number 0 in a coded index slot always means "null reference".
CODED_INDEX_TABLES: "dict[str, list[TableId]]" = {
    "TypeDefOrRef": [TableId.TYPE_DEF, TableId.TYPE_REF, TableId.TYPE_SPEC],
    "HasConstant": [TableId.FIELD, TableId.PARAM, TableId.PROPERTY],
    "HasCustomAttribute": [
        TableId.METHOD_DEF, TableId.FIELD, TableId.TYPE_REF, TableId.TYPE_DEF, TableId.PARAM,
        TableId.INTERFACE_IMPL, TableId.MEMBER_REF, TableId.MODULE, TableId.DECL_SECURITY,
        TableId.PROPERTY, TableId.EVENT, TableId.STAND_ALONE_SIG, TableId.MODULE_REF,
        TableId.TYPE_SPEC, TableId.ASSEMBLY, TableId.ASSEMBLY_REF, TableId.FILE,
        TableId.EXPORTED_TYPE, TableId.MANIFEST_RESOURCE, TableId.GENERIC_PARAM,
        TableId.GENERIC_PARAM_CONSTRAINT, TableId.METHOD_SPEC,
    ],
    "HasFieldMarshal": [TableId.FIELD, TableId.PARAM],
    "HasDeclSecurity": [TableId.TYPE_DEF, TableId.METHOD_DEF, TableId.ASSEMBLY],
    "MemberRefParent": [TableId.TYPE_DEF, TableId.TYPE_REF, TableId.MODULE_REF, TableId.METHOD_DEF, TableId.TYPE_SPEC],
    "HasSemantics": [TableId.EVENT, TableId.PROPERTY],
    "MethodDefOrRef": [TableId.METHOD_DEF, TableId.MEMBER_REF],
    "MemberForwarded": [TableId.FIELD, TableId.METHOD_DEF],
    "Implementation": [TableId.FILE, TableId.ASSEMBLY_REF, TableId.EXPORTED_TYPE],
    # Tag 0 and 1 are "not used" placeholders in the spec; keep MODULE as an inert filler so
    # tag arithmetic (list index) still lines up with the spec's tag values 2 and 3.
    "CustomAttributeType": [TableId.MODULE, TableId.MODULE, TableId.METHOD_DEF, TableId.MEMBER_REF, TableId.MODULE],
    "ResolutionScope": [TableId.MODULE, TableId.MODULE_REF, TableId.ASSEMBLY_REF, TableId.TYPE_REF],
    "TypeOrMethodDef": [TableId.TYPE_DEF, TableId.METHOD_DEF],
}

# Per-table column layout, in on-disk order. See module docstring for column-kind meanings.
TABLE_COLUMNS: "dict[TableId, list[tuple]]" = {
    TableId.MODULE: [
        ("generation", "u2"), ("name", "str"), ("mvid", "guid"), ("enc_id", "guid"), ("enc_base_id", "guid"),
    ],
    TableId.TYPE_REF: [
        ("resolution_scope", "coded", "ResolutionScope"), ("name", "str"), ("namespace", "str"),
    ],
    TableId.TYPE_DEF: [
        ("flags", "u4"), ("name", "str"), ("namespace", "str"),
        ("extends", "coded", "TypeDefOrRef"), ("field_list", "tbl", TableId.FIELD), ("method_list", "tbl", TableId.METHOD_DEF),
    ],
    TableId.FIELD_PTR: [("field", "tbl", TableId.FIELD)],
    TableId.FIELD: [("flags", "u2"), ("name", "str"), ("signature", "blob")],
    TableId.METHOD_PTR: [("method", "tbl", TableId.METHOD_DEF)],
    TableId.METHOD_DEF: [
        ("rva", "u4"), ("impl_flags", "u2"), ("flags", "u2"), ("name", "str"),
        ("signature", "blob"), ("param_list", "tbl", TableId.PARAM),
    ],
    TableId.PARAM_PTR: [("param", "tbl", TableId.PARAM)],
    TableId.PARAM: [("flags", "u2"), ("sequence", "u2"), ("name", "str")],
    TableId.INTERFACE_IMPL: [("class_", "tbl", TableId.TYPE_DEF), ("interface", "coded", "TypeDefOrRef")],
    TableId.MEMBER_REF: [("class_", "coded", "MemberRefParent"), ("name", "str"), ("signature", "blob")],
    TableId.CONSTANT: [("type", "u2"), ("parent", "coded", "HasConstant"), ("value", "blob")],
    TableId.CUSTOM_ATTRIBUTE: [
        ("parent", "coded", "HasCustomAttribute"), ("type", "coded", "CustomAttributeType"), ("value", "blob"),
    ],
    TableId.FIELD_MARSHAL: [("parent", "coded", "HasFieldMarshal"), ("native_type", "blob")],
    TableId.DECL_SECURITY: [("action", "u2"), ("parent", "coded", "HasDeclSecurity"), ("permission_set", "blob")],
    TableId.CLASS_LAYOUT: [("packing_size", "u2"), ("class_size", "u4"), ("parent", "tbl", TableId.TYPE_DEF)],
    TableId.FIELD_LAYOUT: [("offset", "u4"), ("field", "tbl", TableId.FIELD)],
    TableId.STAND_ALONE_SIG: [("signature", "blob")],
    TableId.EVENT_MAP: [("parent", "tbl", TableId.TYPE_DEF), ("event_list", "tbl", TableId.EVENT)],
    TableId.EVENT_PTR: [("event", "tbl", TableId.EVENT)],
    TableId.EVENT: [("event_flags", "u2"), ("name", "str"), ("event_type", "coded", "TypeDefOrRef")],
    TableId.PROPERTY_MAP: [("parent", "tbl", TableId.TYPE_DEF), ("property_list", "tbl", TableId.PROPERTY)],
    TableId.PROPERTY_PTR: [("property", "tbl", TableId.PROPERTY)],
    TableId.PROPERTY: [("flags", "u2"), ("name", "str"), ("type", "blob")],
    TableId.METHOD_SEMANTICS: [
        ("semantics", "u2"), ("method", "tbl", TableId.METHOD_DEF), ("association", "coded", "HasSemantics"),
    ],
    TableId.METHOD_IMPL: [
        ("class_", "tbl", TableId.TYPE_DEF), ("method_body", "coded", "MethodDefOrRef"),
        ("method_declaration", "coded", "MethodDefOrRef"),
    ],
    TableId.MODULE_REF: [("name", "str")],
    TableId.TYPE_SPEC: [("signature", "blob")],
    TableId.IMPL_MAP: [
        ("mapping_flags", "u2"), ("member_forwarded", "coded", "MemberForwarded"),
        ("import_name", "str"), ("import_scope", "tbl", TableId.MODULE_REF),
    ],
    TableId.FIELD_RVA: [("rva", "u4"), ("field", "tbl", TableId.FIELD)],
    TableId.ENC_LOG: [("token", "u4"), ("func_code", "u4")],
    TableId.ENC_MAP: [("token", "u4")],
    TableId.ASSEMBLY: [
        ("hash_alg_id", "u4"), ("major_version", "u2"), ("minor_version", "u2"),
        ("build_number", "u2"), ("revision_number", "u2"), ("flags", "u4"),
        ("public_key", "blob"), ("name", "str"), ("culture", "str"),
    ],
    TableId.ASSEMBLY_PROCESSOR: [("processor", "u4")],
    TableId.ASSEMBLY_OS: [("os_platform_id", "u4"), ("os_major_version", "u4"), ("os_minor_version", "u4")],
    TableId.ASSEMBLY_REF: [
        ("major_version", "u2"), ("minor_version", "u2"), ("build_number", "u2"), ("revision_number", "u2"),
        ("flags", "u4"), ("public_key_or_token", "blob"), ("name", "str"), ("culture", "str"), ("hash_value", "blob"),
    ],
    TableId.ASSEMBLY_REF_PROCESSOR: [("processor", "u4"), ("assembly_ref", "tbl", TableId.ASSEMBLY_REF)],
    TableId.ASSEMBLY_REF_OS: [
        ("os_platform_id", "u4"), ("os_major_version", "u4"), ("os_minor_version", "u4"),
        ("assembly_ref", "tbl", TableId.ASSEMBLY_REF),
    ],
    TableId.FILE: [("flags", "u4"), ("name", "str"), ("hash_value", "blob")],
    TableId.EXPORTED_TYPE: [
        ("flags", "u4"), ("type_def_id", "u4"), ("type_name", "str"), ("type_namespace", "str"),
        ("implementation", "coded", "Implementation"),
    ],
    TableId.MANIFEST_RESOURCE: [
        ("offset", "u4"), ("flags", "u4"), ("name", "str"), ("implementation", "coded", "Implementation"),
    ],
    TableId.NESTED_CLASS: [("nested_class", "tbl", TableId.TYPE_DEF), ("enclosing_class", "tbl", TableId.TYPE_DEF)],
    TableId.GENERIC_PARAM: [
        ("number", "u2"), ("flags", "u2"), ("owner", "coded", "TypeOrMethodDef"), ("name", "str"),
    ],
    TableId.METHOD_SPEC: [("method", "coded", "MethodDefOrRef"), ("instantiation", "blob")],
    TableId.GENERIC_PARAM_CONSTRAINT: [
        ("owner", "tbl", TableId.GENERIC_PARAM), ("constraint", "coded", "TypeDefOrRef"),
    ],
}

"""
Tests for assetripper_import.structure.assembly.dotnet_metadata (Phase 16c).

Low-level pieces (compressed integers, heaps, signature decoding) are tested directly against
hand-crafted bytes. The full PE->CLI->metadata-root->tables pipeline is tested by building a
whole synthetic module via _module_builder.py (no .NET SDK available in this environment to
compile a real one -- see that module's docstring) and reading it back through
DotNetMetadataReader, mirroring how tests/import_/test_layouts.py verifies the type-tree
reader against hand-built bytes.
"""
from assetripper_import.structure.assembly.dotnet_metadata.compressed_integer import (
    decode_type_def_or_ref,
    encode_type_def_or_ref,
    read_compressed_uint,
)
from assetripper_import.structure.assembly.dotnet_metadata.heaps import BlobHeap, GuidHeap, StringsHeap, UserStringsHeap
from assetripper_import.structure.assembly.dotnet_metadata.metadata_reader import DotNetMetadataReader
from assetripper_import.structure.assembly.dotnet_metadata.signature import decode_field_signature, decode_type_blob
from assetripper_import.structure.assembly.dotnet_metadata.table_ids import TableId

from ._module_builder import Coded, ModuleBuilder, compress_uint, wrap_pe


def test_compressed_uint_one_byte_form():
    assert read_compressed_uint(bytes([0x03]), 0) == (3, 1)
    assert read_compressed_uint(bytes([0x7F]), 0) == (0x7F, 1)


def test_compressed_uint_two_byte_form():
    data = compress_uint(0x3FFF)
    assert read_compressed_uint(data, 0) == (0x3FFF, 2)
    assert data == bytes([0xBF, 0xFF])


def test_compressed_uint_four_byte_form():
    data = compress_uint(0x1FFFFFFF)
    assert read_compressed_uint(data, 0) == (0x1FFFFFFF, 4)


def test_type_def_or_ref_encode_decode_round_trip():
    for tag, row in [(0, 0), (1, 5), (2, 1000)]:
        encoded = encode_type_def_or_ref(tag, row)
        assert decode_type_def_or_ref(encoded) == (tag, row)


def test_strings_heap_reads_nul_terminated_utf8():
    heap = StringsHeap(b"\x00Hello\x00World\x00")
    assert heap.get(0) == ""
    assert heap.get(1) == "Hello"
    assert heap.get(7) == "World"


def test_blob_heap_reads_length_prefixed_entries():
    heap = BlobHeap(b"\x00" + compress_uint(3) + b"abc")
    assert heap.get(0) == b""
    assert heap.get(1) == b"abc"


def test_guid_heap_is_one_based():
    guid_bytes = bytes(range(16)) + bytes(range(16, 32))
    heap = GuidHeap(guid_bytes)
    assert heap.get(0) is None
    assert heap.get(1) == bytes(range(16))
    assert heap.get(2) == bytes(range(16, 32))


def test_user_strings_heap_decodes_utf16_and_drops_trailing_marker():
    text = "Hi"
    utf16 = text.encode("utf-16-le")
    entry = compress_uint(len(utf16) + 1) + utf16 + b"\x00"
    heap = UserStringsHeap(b"\x00" + entry)
    assert heap.get(1) == "Hi"


def test_decode_field_signature_primitive():
    assert decode_field_signature(bytes([0x06, 0x08]), lambda tag, row: "unused") == "int"


def test_decode_field_signature_string_and_object():
    assert decode_field_signature(bytes([0x06, 0x0E]), lambda tag, row: "unused") == "string"
    assert decode_field_signature(bytes([0x06, 0x1C]), lambda tag, row: "unused") == "object"


def test_decode_field_signature_szarray_of_primitive():
    assert decode_field_signature(bytes([0x06, 0x1D, 0x08]), lambda tag, row: "unused") == "int[]"


def test_decode_field_signature_class_reference_resolves_via_callback():
    encoded = encode_type_def_or_ref(1, 4)  # tag=1 (TypeRef), row 4
    blob = bytes([0x06, 0x12]) + compress_uint(encoded)
    resolver = lambda tag, row: f"MyNamespace.MyClass(tag={tag},row={row})"
    assert decode_field_signature(blob, resolver) == "MyNamespace.MyClass(tag=1,row=4)"


def test_decode_field_signature_generic_instantiation():
    encoded = encode_type_def_or_ref(1, 2)
    blob = (
        bytes([0x06, 0x15, 0x12])  # FIELD, GENERICINST, CLASS
        + compress_uint(encoded)
        + compress_uint(1)  # one generic argument
        + bytes([0x0E])  # string
    )
    resolver = lambda tag, row: "System.Collections.Generic.List`1"
    assert decode_field_signature(blob, resolver) == "System.Collections.Generic.List<string>"


def test_decode_field_signature_generic_var_uses_owner_type_params():
    blob = bytes([0x06, 0x13, 0x00])  # FIELD, VAR, number=0
    assert decode_field_signature(blob, lambda tag, row: "unused", generic_type_params=("T",)) == "T"


def test_decode_type_blob_for_type_spec_style_signature():
    assert decode_type_blob(bytes([0x1D, 0x08]), lambda tag, row: "unused") == "int[]"


def _build_minimal_module() -> DotNetMetadataReader:
    builder = ModuleBuilder()
    builder.heaps.add_guid()  # row 1: module's Mvid
    module_name = builder.heaps.add_string("TestModule.dll")
    builder.add_row(TableId.MODULE, generation=0, name=module_name, mvid=1, enc_id=0, enc_base_id=0)

    module_type_name = builder.heaps.add_string("<Module>")
    empty = builder.heaps.add_string("")
    builder.add_row(
        TableId.TYPE_DEF, flags=0, name=module_type_name, namespace=empty,
        extends=Coded.null("TypeDefOrRef"), field_list=1, method_list=1,
    )

    field_name = builder.heaps.add_string("m_Value")
    field_sig = builder.heaps.add_blob(bytes([0x06, 0x08]))  # FIELD int
    builder.add_row(TableId.FIELD, flags=0x0006, name=field_name, signature=field_sig)  # Public
    return DotNetMetadataReader(wrap_pe(builder.build()))


def test_metadata_reader_reads_module_name():
    reader = _build_minimal_module()
    module_row = reader.tables.row(TableId.MODULE, 1)
    assert reader.strings.get(module_row["name"]) == "TestModule.dll"


def test_metadata_reader_reads_type_def_and_field():
    reader = _build_minimal_module()
    type_def = reader.tables.row(TableId.TYPE_DEF, 1)
    assert reader.type_def_full_name(type_def) == "<Module>"
    field = reader.tables.row(TableId.FIELD, 1)
    assert reader.strings.get(field["name"]) == "m_Value"

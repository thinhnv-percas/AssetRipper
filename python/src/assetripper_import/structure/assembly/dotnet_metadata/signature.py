"""Decodes ECMA-335 II.23.2.4 field signatures (and the `Type` production, II.23.2.1, that
almost every other signature kind is built from) into display-ready C# type text.

Only what real-world Unity `[SerializeField]`/public fields plausibly use is implemented in
full: primitives, string/object, CLASS/VALUETYPE references (resolved via the caller-supplied
`resolve_type_def_or_ref` callback), SZARRAY, and GENERICINST. Multi-dimensional ARRAY,
function pointers, and PTR are rendered with a best-effort fallback text rather than raising,
since Unity does not serialize any of those anyway (see field_serializer.py's gating) -- a
field with one of these types should never actually reach `csharp_emitter` in practice.
"""
from __future__ import annotations

from .compressed_integer import decode_type_def_or_ref, read_compressed_uint

_FIELD_SIG_CALLING_CONVENTION = 0x06

_ELEMENT_TYPE_END = 0x00
_ELEMENT_TYPE_VOID = 0x01
_ELEMENT_TYPE_BOOLEAN = 0x02
_ELEMENT_TYPE_CHAR = 0x03
_ELEMENT_TYPE_I1 = 0x04
_ELEMENT_TYPE_U1 = 0x05
_ELEMENT_TYPE_I2 = 0x06
_ELEMENT_TYPE_U2 = 0x07
_ELEMENT_TYPE_I4 = 0x08
_ELEMENT_TYPE_U4 = 0x09
_ELEMENT_TYPE_I8 = 0x0A
_ELEMENT_TYPE_U8 = 0x0B
_ELEMENT_TYPE_R4 = 0x0C
_ELEMENT_TYPE_R8 = 0x0D
_ELEMENT_TYPE_STRING = 0x0E
_ELEMENT_TYPE_PTR = 0x0F
_ELEMENT_TYPE_BYREF = 0x10
_ELEMENT_TYPE_VALUETYPE = 0x11
_ELEMENT_TYPE_CLASS = 0x12
_ELEMENT_TYPE_VAR = 0x13
_ELEMENT_TYPE_ARRAY = 0x14
_ELEMENT_TYPE_GENERICINST = 0x15
_ELEMENT_TYPE_TYPEDBYREF = 0x16
_ELEMENT_TYPE_I = 0x18
_ELEMENT_TYPE_U = 0x19
_ELEMENT_TYPE_FNPTR = 0x1B
_ELEMENT_TYPE_OBJECT = 0x1C
_ELEMENT_TYPE_SZARRAY = 0x1D
_ELEMENT_TYPE_MVAR = 0x1E
_ELEMENT_TYPE_CMOD_REQD = 0x1F
_ELEMENT_TYPE_CMOD_OPT = 0x20
_ELEMENT_TYPE_PINNED = 0x45

_PRIMITIVE_NAMES = {
    _ELEMENT_TYPE_VOID: "void",
    _ELEMENT_TYPE_BOOLEAN: "bool",
    _ELEMENT_TYPE_CHAR: "char",
    _ELEMENT_TYPE_I1: "sbyte",
    _ELEMENT_TYPE_U1: "byte",
    _ELEMENT_TYPE_I2: "short",
    _ELEMENT_TYPE_U2: "ushort",
    _ELEMENT_TYPE_I4: "int",
    _ELEMENT_TYPE_U4: "uint",
    _ELEMENT_TYPE_I8: "long",
    _ELEMENT_TYPE_U8: "ulong",
    _ELEMENT_TYPE_R4: "float",
    _ELEMENT_TYPE_R8: "double",
    _ELEMENT_TYPE_STRING: "string",
    _ELEMENT_TYPE_TYPEDBYREF: "System.TypedReference",
    _ELEMENT_TYPE_I: "System.IntPtr",
    _ELEMENT_TYPE_U: "System.UIntPtr",
    _ELEMENT_TYPE_OBJECT: "object",
}


def decode_field_signature(blob: bytes, resolve_type_def_or_ref, generic_type_params=()) -> str:
    """`blob` is a Field row's raw signature blob (already read from #Blob). Returns C# type
    text for the field's type. `resolve_type_def_or_ref(tag, row_index_zero_based) -> str`
    resolves a CLASS/VALUETYPE reference to a type name. `generic_type_params` names the
    enclosing type's generic parameters in declaration order, for VAR resolution."""
    if not blob or blob[0] != _FIELD_SIG_CALLING_CONVENTION:
        raise ValueError("Not a field signature (wrong calling-convention byte)")
    text, _ = _decode_type(blob, 1, resolve_type_def_or_ref, generic_type_params)
    return text


def decode_type_blob(blob: bytes, resolve_type_def_or_ref, generic_type_params=()) -> str:
    """Decodes a raw `Type` blob with no calling-convention prefix -- e.g. a TypeSpec row's
    signature, which is exactly a `Type` (II.23.2.14) rather than a full field/method sig."""
    text, _ = _decode_type(blob, 0, resolve_type_def_or_ref, generic_type_params)
    return text


def _decode_type(data: bytes, offset: int, resolve_type_def_or_ref, generic_type_params) -> "tuple[str, int]":
    element_type = data[offset]
    offset += 1

    while element_type in (_ELEMENT_TYPE_CMOD_REQD, _ELEMENT_TYPE_CMOD_OPT):
        # Custom modifiers carry no information this port renders -- skip the TypeDefOrRef
        # token and continue decoding the type they modify.
        _, offset = read_compressed_uint(data, offset)
        element_type = data[offset]
        offset += 1

    if element_type == _ELEMENT_TYPE_PINNED:
        return _decode_type(data, offset, resolve_type_def_or_ref, generic_type_params)

    if element_type in _PRIMITIVE_NAMES:
        return _PRIMITIVE_NAMES[element_type], offset

    if element_type in (_ELEMENT_TYPE_VALUETYPE, _ELEMENT_TYPE_CLASS):
        encoded, offset = read_compressed_uint(data, offset)
        tag, row_index = decode_type_def_or_ref(encoded)
        return resolve_type_def_or_ref(tag, row_index), offset

    if element_type == _ELEMENT_TYPE_VAR:
        number, offset = read_compressed_uint(data, offset)
        if number < len(generic_type_params):
            return generic_type_params[number], offset
        return f"T{number}", offset

    if element_type == _ELEMENT_TYPE_MVAR:
        number, offset = read_compressed_uint(data, offset)
        return f"TMethod{number}", offset

    if element_type == _ELEMENT_TYPE_SZARRAY:
        element_text, offset = _decode_type(data, offset, resolve_type_def_or_ref, generic_type_params)
        return f"{element_text}[]", offset

    if element_type == _ELEMENT_TYPE_GENERICINST:
        # (CLASS | VALUETYPE) TypeDefOrRefEncoded GenArgCount Type*
        offset += 1  # the CLASS/VALUETYPE byte itself -- doesn't change how we render this
        encoded, offset = read_compressed_uint(data, offset)
        tag, row_index = decode_type_def_or_ref(encoded)
        base_name = resolve_type_def_or_ref(tag, row_index)
        base_name = base_name.split("`", 1)[0]
        arg_count, offset = read_compressed_uint(data, offset)
        args = []
        for _ in range(arg_count):
            arg_text, offset = _decode_type(data, offset, resolve_type_def_or_ref, generic_type_params)
            args.append(arg_text)
        return f"{base_name}<{', '.join(args)}>", offset

    if element_type == _ELEMENT_TYPE_ARRAY:
        element_text, offset = _decode_type(data, offset, resolve_type_def_or_ref, generic_type_params)
        rank, offset = read_compressed_uint(data, offset)
        num_sizes, offset = read_compressed_uint(data, offset)
        for _ in range(num_sizes):
            _, offset = read_compressed_uint(data, offset)
        num_lo_bounds, offset = read_compressed_uint(data, offset)
        for _ in range(num_lo_bounds):
            _, offset = read_compressed_uint(data, offset)
        commas = "," * max(rank - 1, 0)
        return f"{element_text}[{commas}]", offset

    if element_type == _ELEMENT_TYPE_PTR:
        # CustomMod* (Type | VOID) -- rendered but never Unity-serializable; see module docstring.
        if data[offset] == _ELEMENT_TYPE_VOID:
            return "void*", offset + 1
        element_text, offset = _decode_type(data, offset, resolve_type_def_or_ref, generic_type_params)
        return f"{element_text}*", offset

    if element_type in (_ELEMENT_TYPE_FNPTR, _ELEMENT_TYPE_BYREF, _ELEMENT_TYPE_END):
        return "object", offset

    raise ValueError(f"Unsupported field signature element type 0x{element_type:02X} at offset {offset - 1}")

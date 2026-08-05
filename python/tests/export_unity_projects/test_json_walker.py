"""Tests for `json_walker.py` (2026-08-03), the port of upstream's `DefaultJsonWalker`.

Assets are driven through `walk_standard` directly rather than built from a TypeTree: what is
under test is the JSON the walker emits for each traversal shape, and real assets would only
reach a fraction of those shapes. Every test asserts the output actually parses as JSON, so a
missing comma or brace fails loudly rather than producing plausible-looking text.
"""
from __future__ import annotations

import base64
import json

import pytest
from assetripper_assets.metadata.pptr import PPtr
from assetripper_export_unity_projects.json_walker import DefaultJsonWalker, export_json
from assetripper_serialization_logic.primitive_type import PrimitiveType


class _Walkable:
    """Replays a recorded sequence of walker calls, so a test can describe a traversal shape
    directly instead of constructing an asset that happens to produce it."""

    def __init__(self, script):
        self._script = script

    def walk_standard(self, walker) -> None:
        self._script(walker)


def _json_of(script) -> str:
    return export_json(_Walkable(script))


def _parsed(script):
    text = _json_of(script)
    return json.loads(text), text


def _fields(walker, asset, pairs) -> None:
    """Emit `pairs` as the asset's fields, with the divides upstream puts between them."""
    for index, (name, emit) in enumerate(pairs):
        if index > 0:
            walker.divide_asset(asset)
        if walker.enter_field(asset, name):
            emit(walker)
            walker.exit_field(asset, name)


def test_a_flat_asset_becomes_a_json_object():
    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [
            ("m_Name", lambda w: w.visit_primitive("Player", PrimitiveType.STRING)),
            ("m_Layer", lambda w: w.visit_primitive(5, PrimitiveType.INT)),
            ("m_IsActive", lambda w: w.visit_primitive(True, PrimitiveType.BOOL)),
        ])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_Name": "Player", "m_Layer": 5, "m_IsActive": True}


def test_booleans_are_emitted_before_integers():
    """Python's `bool` is an `int` subclass, so an ordering slip here would render `true` as `1`
    -- valid JSON, wrong type, and impossible to spot in a diff of numbers."""
    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [
            ("t", lambda w: w.visit_primitive(True, PrimitiveType.BOOL)),
            ("f", lambda w: w.visit_primitive(False, PrimitiveType.BOOL)),
        ])
        walker.exit_asset(None)

    document, text = _parsed(script)
    assert document == {"t": True, "f": False}
    assert "true" in text and "false" in text


def test_bytes_become_base64():
    """Upstream base64-encodes a byte array rather than emitting a number list -- for a texture's
    pixel data the difference is megabytes of output."""
    payload = b"\x00\x01\xfe\xff"

    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [("image data", lambda w: w.visit_primitive(payload))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"image data": base64.b64encode(payload).decode("ascii")}


def test_a_char_is_quoted_when_its_primitive_type_says_so():
    """A `char` arrives as an int; upstream knows it statically and quotes it. The only signal
    available here is the field's `PrimitiveType`, which `walk_editor` does thread through."""
    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [("c", lambda w: w.visit_primitive(65, PrimitiveType.CHAR))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"c": "A"}


def test_an_int_with_no_primitive_type_stays_a_number():
    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [("n", lambda w: w.visit_primitive(65))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"n": 65}


def test_floats_round_trip_exactly():
    """`repr` gives the shortest round-tripping form, matching what C# has produced since .NET
    Core 3.0. A truncated float in a Transform's position is a silent data change."""
    value = 0.1 + 0.2

    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [("x", lambda w: w.visit_primitive(value, PrimitiveType.SINGLE))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document["x"] == value


def test_strings_needing_escapes_are_escaped():
    awkward = 'quote " backslash \\ newline \n tab \t unicode é'

    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [("s", lambda w: w.visit_primitive(awkward, PrimitiveType.STRING))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"s": awkward}


def test_field_names_needing_escapes_are_escaped():
    """Unity field names are usually tame, but "image data" already has a space and a recovered
    Mono field name can be anything."""
    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [('odd "name"', lambda w: w.visit_primitive(1, PrimitiveType.INT))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert list(document) == ['odd "name"']


def test_an_empty_list_is_emitted_inline():
    def script(walker):
        walker.enter_asset(None)

        def emit(w):
            if w.enter_list([], PrimitiveType.INT):
                w.exit_list([], PrimitiveType.INT)

        _fields(walker, None, [("m_Empty", emit)])
        walker.exit_asset(None)

    document, text = _parsed(script)
    assert document == {"m_Empty": []}
    assert "[]" in text


def test_a_populated_list_keeps_its_order():
    values = [3, 1, 2]

    def script(walker):
        walker.enter_asset(None)

        def emit(w):
            if w.enter_list(values, PrimitiveType.INT):
                for index, value in enumerate(values):
                    if index > 0:
                        w.divide_list(values, PrimitiveType.INT)
                    w.visit_primitive(value, PrimitiveType.INT)
                w.exit_list(values, PrimitiveType.INT)

        _fields(walker, None, [("m_Values", emit)])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_Values": values}


def test_a_pptr_becomes_a_file_id_path_id_object():
    pptr = PPtr(3, 12345)

    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [("m_Script", lambda w: w.visit_pptr(pptr))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_Script": {"m_FileID": 3, "m_PathID": 12345}}


def test_a_nested_asset_becomes_a_nested_object():
    def script(walker):
        walker.enter_asset(None)

        def emit(w):
            w.enter_asset(None)
            _fields(w, None, [
                ("x", lambda inner: inner.visit_primitive(1.5, PrimitiveType.SINGLE)),
                ("y", lambda inner: inner.visit_primitive(2.5, PrimitiveType.SINGLE)),
            ])
            w.exit_asset(None)

        _fields(walker, None, [("m_LocalPosition", emit)])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_LocalPosition": {"x": 1.5, "y": 2.5}}


def test_a_string_keyed_dictionary_becomes_an_object():
    mapping = {"first": 1, "second": 2}

    def script(walker):
        walker.enter_asset(None)

        def emit(w):
            if not w.enter_dictionary(mapping):
                return
            for index, pair in enumerate(mapping.items()):
                if index > 0:
                    w.divide_dictionary(mapping)
                if w.enter_dictionary_pair(pair):
                    w.visit_primitive(pair[0], PrimitiveType.STRING)
                    w.divide_dictionary_pair(pair)
                    w.visit_primitive(pair[1], PrimitiveType.INT)
                    w.exit_dictionary_pair(pair)
            w.exit_dictionary(mapping)

        _fields(walker, None, [("m_Map", emit)])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_Map": mapping}


def test_a_non_string_keyed_dictionary_becomes_a_list_of_key_value_objects():
    """Upstream's shape for a dictionary JSON cannot express directly. The keys here are ints."""
    mapping = {10: "ten", 20: "twenty"}

    def script(walker):
        walker.enter_asset(None)

        def emit(w):
            if not w.enter_dictionary(mapping):
                return
            for index, pair in enumerate(mapping.items()):
                if index > 0:
                    w.divide_dictionary(mapping)
                if w.enter_dictionary_pair(pair):
                    w.visit_primitive(pair[0], PrimitiveType.INT)
                    w.divide_dictionary_pair(pair)
                    w.visit_primitive(pair[1], PrimitiveType.STRING)
                    w.exit_dictionary_pair(pair)
            w.exit_dictionary(mapping)

        _fields(walker, None, [("m_Map", emit)])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_Map": [{"Key": 10, "Value": "ten"}, {"Key": 20, "Value": "twenty"}]}


def test_an_empty_dictionary_is_an_object():
    """Documented divergence: upstream emits `[]` for an empty dictionary with non-string keys,
    but the key type is unknowable at runtime when there are no keys, and no consumer of an empty
    collection can tell the two apart."""
    def script(walker):
        walker.enter_asset(None)

        def emit(w):
            if w.enter_dictionary({}):
                w.exit_dictionary({})

        _fields(walker, None, [("m_Map", emit)])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_Map": {}}


def test_a_pair_field_becomes_a_key_value_object():
    def script(walker):
        walker.enter_asset(None)

        def emit(w):
            pair = ("name", 7)
            if w.enter_pair(pair):
                w.visit_primitive(pair[0], PrimitiveType.STRING)
                w.divide_pair(pair)
                w.visit_primitive(pair[1], PrimitiveType.INT)
                w.exit_pair(pair)

        _fields(walker, None, [("m_Pair", emit)])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {"m_Pair": {"Key": "name", "Value": 7}}


def test_an_asset_with_no_fields_is_an_empty_object():
    def script(walker):
        walker.enter_asset(None)
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert document == {}


def test_a_skipped_asset_produces_nothing():
    """`enter_asset` returning False means "do not descend", and upstream never calls the matching
    exit -- so a walker that wrote the closing brace anyway would emit unbalanced output."""
    walker = DefaultJsonWalker()
    assert walker.enter_asset(None) is True  # the port's walker always descends
    assert walker.to_string().strip() == "{"


@pytest.mark.parametrize("value", [None, object()])
def test_an_unrecognized_value_is_stringified_rather_than_dropped(value):
    """Upstream's final `else` branch. Dropping the value would leave `"field": ` followed by a
    comma -- syntactically broken JSON."""
    def script(walker):
        walker.enter_asset(None)
        _fields(walker, None, [("odd", lambda w: w.visit_primitive(value))])
        walker.exit_asset(None)

    document, _ = _parsed(script)
    assert isinstance(document["odd"], str)

"""
No C# test project exists for AssetRipper.Configuration, so these are original tests
(not a port) exercising the ported DataStorage/DataSet/DataInstance system directly.
"""
from assetripper_configuration import JsonDataSet, ListDataStorage, SingletonDataStorage


def test_singleton_data_storage_string_round_trip():
    singleton = SingletonDataStorage()
    singleton.add_string("greeting", "hello")

    ok, value = singleton.try_get_stored_value("greeting")
    assert ok
    assert value == "hello"

    singleton.set_stored_value("greeting", "world")
    assert singleton.get_stored_value("greeting") == "world"


def test_singleton_data_storage_clear_resets_to_default():
    singleton = SingletonDataStorage()
    singleton.add_string("greeting", "hello")
    singleton.clear()
    assert singleton.get_stored_value("greeting") == ""


def test_list_data_storage_string_data_set():
    lists = ListDataStorage()
    lists.add_strings("names", ["a", "b"])

    data_set = lists.get_value("names")
    assert list(data_set) == ["a", "b"]

    data_set.strings.add("c")
    assert list(data_set) == ["a", "b", "c"]

    data_set.strings[0] = "z"
    assert data_set[0] == "z"


def test_list_data_storage_parsable_data_set_forgiving_parse():
    lists = ListDataStorage()
    lists.add_parsable("numbers", [1, 2, 3], parse=int, create_new=lambda: 0)

    numbers = lists.get_value("numbers")
    assert list(numbers) == [1, 2, 3]
    assert numbers.strings[0] == "1"

    numbers.strings.add("4")
    assert list(numbers) == [1, 2, 3, 4]

    # Forgiving parsing: an unparsable string falls back to create_new(), not an error.
    numbers.strings.add("not_a_number")
    assert list(numbers) == [1, 2, 3, 4, 0]


def test_json_data_set_round_trip():
    json_set = JsonDataSet(
        create_new=lambda: {"x": 0, "y": 0},
        to_dict=lambda v: v,
        from_dict=lambda d: d,
    )
    json_set.add({"x": 1, "y": 2})
    assert json_set.strings[0] == '{"x": 1, "y": 2}'

    json_set.strings.add('{"x": 3, "y": 4}')
    assert json_set[1] == {"x": 3, "y": 4}

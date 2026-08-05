"""Session-scoped `SingletonDataStorage`/`ListDataStorage` backing the `/ConfigurationFiles`
page (2026-08-03, closing a gap the Phase 20e route audit found).

Two things were true before this module existed:
 - `/ConfigurationFiles` rendered `stub.html` -- an empty placeholder page. The ROADMAP's audit
   entry called it "read-only", which overstated it: it showed nothing at all.
 - `assetripper_configuration` (`DataStorage`/`SingletonDataStorage`/`ListDataStorage`/
   `DataInstance`/`DataSet`, ported and tested back in Phase 22) had **zero consumers** anywhere
   in the port. Ported, tested, and dead.

Wiring the page to that machinery closes both at once, and does it without disturbing a
deliberate earlier decision: `assetripper_export_configuration.FullConfiguration`'s docstring
explains, at length, why *this port's own settings* are three plain dataclasses rather than
DataStorage entries. Upstream stores its settings records inside the same
`Settings.SingletonData` that its ConfigurationFiles page edits, so a literal port of these
routes would have meant reversing that decision. Instead the storage here is its own
independent instance -- a generic named-blob store, which is what upstream's page actually
presents to the user -- and `FullConfiguration` keeps its simpler shape untouched.

Scope kept honest: session-only, exactly like `game_file_loader._state.settings`. Nothing is
persisted to disk, because upstream's persistence path goes through `SerializedSettings` +
an OS-specific default settings path that `FullConfiguration` already declined to port.
"""
from __future__ import annotations

from assetripper_configuration import ListDataStorage, SingletonDataStorage


class _State:
    def __init__(self):
        self.singletons = SingletonDataStorage()
        self.lists = ListDataStorage()


_state = _State()


def singletons() -> SingletonDataStorage:
    return _state.singletons


def lists() -> ListDataStorage:
    return _state.lists


def reset() -> None:
    """Drops every entry. Used by `/Reset` and by tests, so one test's entries can't leak into
    the next (this module is process-global, like the rest of the GUI's state)."""
    _state.singletons = SingletonDataStorage()
    _state.lists = ListDataStorage()


def singleton_add(key: str, content: str) -> None:
    """Upstream's `HandleSingletonAddPostRequest`. Adding an existing key **overwrites** its
    content rather than raising: `DataStorage.add` rejects duplicates, but the page's form
    submits the same key again to edit a value, and a 500 there would be a worse answer than
    the obvious one."""
    found, entry = _state.singletons.try_get_value(key)
    if found:
        entry.text = content
    else:
        _state.singletons.add_string(key, content)


def singleton_remove(key: str) -> None:
    """Upstream's `HandleSingletonRemovePostRequest` -- note it calls `.Clear()` on the entry
    rather than dropping the key, so the key stays listed with empty content. Mirrored exactly,
    including the no-op for a key that was never added."""
    found, entry = _state.singletons.try_get_value(key)
    if found:
        entry.clear()


def list_add(key: str, content: str) -> None:
    """Upstream's `HandleListAddPostRequest`: appends to the set at `key`, creating it first if
    this is the first entry for that key."""
    found, entry = _state.lists.try_get_value(key)
    if not found:
        _state.lists.add_strings(key, [content])
    else:
        entry.strings.add(content)


def list_replace(key: str, index: int, content: str) -> bool:
    """Upstream's `HandleListReplacePostRequest`. Returns False for a key or index that doesn't
    exist, so the route can answer 400 instead of raising."""
    found, entry = _state.lists.try_get_value(key)
    if not found or index < 0 or index >= len(entry):
        return False
    entry.strings[index] = content
    return True


def list_remove(key: str, index: int) -> bool:
    """Upstream's `HandleListRemovePostRequest`. Returns False for a key or index that doesn't
    exist."""
    found, entry = _state.lists.try_get_value(key)
    if not found or index < 0 or index >= len(entry):
        return False
    entry.remove_at(index)
    return True


def view_model() -> dict:
    """What the template renders: both storages flattened to plain strings, so the Jinja side
    needs no knowledge of `DataInstance`/`DataSet`."""
    singleton_rows = []
    for key in sorted(_state.singletons.keys):
        entry = _state.singletons[key]
        singleton_rows.append({"key": key, "content": entry.text if entry is not None else ""})

    list_rows = []
    for key in sorted(_state.lists.keys):
        entry = _state.lists[key]
        # Keyed "entries", not "items": Jinja resolves `row.items` to `dict.items` (the method)
        # rather than the key, which silently renders a bound method instead of the list.
        values = list(entry.strings) if entry is not None else []
        list_rows.append({"key": key, "entries": values})

    return {"singletons": singleton_rows, "lists": list_rows}

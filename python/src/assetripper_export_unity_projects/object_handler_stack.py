"""Port of Source/AssetRipper.Export/ObjectHandlerStack.cs

A per-Python-type stack of handlers: `get_handler_stack(type_)` returns every registered
handler applicable to `type_` (exact-type matches plus inheritance-eligible base-type
matches), most-recently-registered first -- callers try them in that order and fall
through to the next on failure (chain of responsibility, not a 1:1 map).
"""
from __future__ import annotations


class ObjectHandlerStack:
    def __init__(self):
        self._type_map: dict[type, list] = {}
        self._registered_handlers: list[tuple[type, object, bool]] = []

    def override_handler(self, type_: type, handler, allow_inheritance: bool) -> None:
        if handler is None:
            raise ValueError("handler must not be None")
        self._registered_handlers.append((type_, handler, allow_inheritance))
        if self._type_map:
            self._type_map.clear()

    def get_handler_stack(self, type_: type) -> list:
        handlers = self._type_map.get(type_)
        if handlers is None:
            handlers = self._calculate_handler_stack(type_)
            self._type_map[type_] = handlers
        return handlers

    def _calculate_handler_stack(self, type_: type) -> list:
        result = []
        for base_type, handler, allow_inheritance in self._registered_handlers:
            if type_ is base_type or (allow_inheritance and issubclass(type_, base_type)):
                result.append(handler)
        result.reverse()  # last registered wins => tried first, matching C#'s Stack.Push order
        return result

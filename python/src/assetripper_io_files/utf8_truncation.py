"""Port of Source/AssetRipper.IO.Files/Utf8Truncation.cs"""
from __future__ import annotations


def truncate_to_utf8_byte_length(text: str, max_length: int) -> str:
    encoded = text.encode("utf-8")
    valid_length = _find_valid_byte_length(encoded, max_length)
    return encoded[:valid_length].decode("utf-8")


def _find_valid_byte_length(data: bytes, max_length: int) -> int:
    valid_length = max_length

    # ascii char:      0_
    # two-byte char:   110_   10_
    # three-byte char: 1110_  10_ _10_
    # four-byte char : 11110_ 10_ _10_ _10

    if max_length >= len(data):
        return len(data)

    # next byte is a beginning, so we can safely truncate to max_length
    next_byte = data[max_length]
    if (next_byte & 0b11_000000) != 0b10_000000:
        return max_length

    # move to end of the last full sequence
    for i in range(max_length - 1, -1, -1):
        current_byte = data[i]

        if (current_byte & 0b11_000000) == 0b10_000000:
            # continuation byte
            valid_length -= 1
        elif (current_byte & 0b10000000) == 0b10000000:
            # start of multi-byte sequence
            valid_length -= 1
            break
        else:
            # ascii char
            break

    return valid_length

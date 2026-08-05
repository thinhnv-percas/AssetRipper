"""Port of Source/AssetRipper.IO.Files/SerializedFiles/Parser/EndianExtensions.cs"""
from __future__ import annotations

from assetripper_io_endian import EndianReader, EndianWriter
from assetripper_primitives import UnityGuid


def read_unity_guid(reader: EndianReader) -> UnityGuid:
    return UnityGuid(reader.read_uint32(), reader.read_uint32(), reader.read_uint32(), reader.read_uint32())


def write_unity_guid(writer: EndianWriter, guid: UnityGuid) -> None:
    writer.write_uint32(guid.data0)
    writer.write_uint32(guid.data1)
    writer.write_uint32(guid.data2)
    writer.write_uint32(guid.data3)

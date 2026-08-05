"""Port of Source/AssetRipper.IO.Files/Exceptions/*.cs"""
from __future__ import annotations

from .bundle_files.compression_type import CompressionType


class InvalidFormatException(Exception):
    pass


class DecompressionFailedException(Exception):
    @staticmethod
    def throw_no_bytes_written(file_name: str, compression: CompressionType):
        raise DecompressionFailedException(
            f"Could not write any bytes for '{file_name}' while decompressing {compression.name}. File: {file_name}"
        )

    @staticmethod
    def throw_read_more_than_expected(expected: int, actual: int, compression: CompressionType | None = None, file_name: str | None = None):
        if file_name is None:
            raise DecompressionFailedException(
                f"Read more than expected while decompressing {compression.name}. Expected {expected}, but was {actual}."
            )
        raise DecompressionFailedException(
            f"Read more than expected for '{file_name}' while decompressing. Expected {expected}, but was {actual}."
        )

    @staticmethod
    def throw_incorrect_number_bytes_written(file_name: str, compression: CompressionType, expected: int, actual: int):
        raise DecompressionFailedException(
            f"Incorrect number of bytes written for '{file_name}' while decompressing {compression.name}. Expected {expected}, but was {actual}."
        )

    @staticmethod
    def throw_if_uncompressed_size_is_negative(file_name: str, uncompressed_size: int):
        if uncompressed_size < 0:
            raise DecompressionFailedException(f"Uncompressed size cannot be negative: {uncompressed_size}. File: {file_name}")


class UnsupportedBundleDecompression(Exception):
    @staticmethod
    def throw_lzham(file_name: str):
        raise UnsupportedBundleDecompression(f"Lzham decompression is not currently supported. File: {file_name}")

    @staticmethod
    def throw(file_name: str, compression: CompressionType):
        raise UnsupportedBundleDecompression(
            f"Bundle compression '{compression.name}' is not supported. '{file_name}' is likely encrypted or using a custom compression algorithm."
        )

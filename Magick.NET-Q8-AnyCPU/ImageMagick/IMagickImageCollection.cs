using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageMagick;

public interface IMagickImageCollection : IDisposable, IList<IMagickImage>, ICollection<IMagickImage>, IEnumerable<IMagickImage>, IEnumerable
{
	event EventHandler<WarningEventArgs> Warning;

	Bitmap ToBitmap();

	Bitmap ToBitmap(ImageFormat imageFormat);

	void Add(string fileName);

	void AddRange(byte[] data);

	void AddRange(byte[] data, MagickReadSettings readSettings);

	void AddRange(IEnumerable<IMagickImage> images);

	void AddRange(IMagickImageCollection images);

	void AddRange(string fileName);

	void AddRange(string fileName, MagickReadSettings readSettings);

	void AddRange(Stream stream);

	void AddRange(Stream stream, MagickReadSettings readSettings);

	IMagickImage AppendHorizontally();

	IMagickImage AppendVertically();

	void Coalesce();

	IMagickImageCollection Clone();

	IMagickImage Combine();

	IMagickImage Combine(ColorSpace colorSpace);

	void Deconstruct();

	IMagickImage Evaluate(EvaluateOperator evaluateOperator);

	IMagickImage Flatten();

	void Insert(int index, string fileName);

	void Map(IMagickImage image);

	void Map(IMagickImage image, QuantizeSettings settings);

	IMagickImage Merge();

	IMagickImage Montage(MontageSettings settings);

	void Morph(int frames);

	IMagickImage Mosaic();

	void Optimize();

	void OptimizePlus();

	void OptimizeTransparency();

	void Ping(byte[] data);

	void Ping(byte[] data, MagickReadSettings readSettings);

	void Ping(FileInfo file);

	void Ping(FileInfo file, MagickReadSettings readSettings);

	void Ping(Stream stream);

	void Ping(Stream stream, MagickReadSettings readSettings);

	void Ping(string fileName);

	void Ping(string fileName, MagickReadSettings readSettings);

	MagickErrorInfo Quantize();

	MagickErrorInfo Quantize(QuantizeSettings settings);

	void Read(FileInfo file);

	void Read(FileInfo file, MagickReadSettings readSettings);

	void Read(byte[] data);

	void Read(byte[] data, MagickReadSettings readSettings);

	void Read(Stream stream);

	void Read(Stream stream, MagickReadSettings readSettings);

	void Read(string fileName);

	void Read(string fileName, MagickReadSettings readSettings);

	void RePage();

	void Reverse();

	IMagickImage SmushHorizontal(int offset);

	IMagickImage SmushVertical(int offset);

	byte[] ToByteArray();

	byte[] ToByteArray(IWriteDefines defines);

	byte[] ToByteArray(MagickFormat format);

	string ToBase64();

	string ToBase64(MagickFormat format);

	void TrimBounds();

	void Write(FileInfo file);

	void Write(FileInfo file, IWriteDefines defines);

	void Write(Stream stream);

	void Write(Stream stream, IWriteDefines defines);

	void Write(Stream stream, MagickFormat format);

	void Write(string fileName);

	void Write(string fileName, IWriteDefines defines);
}

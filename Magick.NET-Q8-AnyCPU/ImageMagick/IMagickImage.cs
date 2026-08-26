using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImageMagick;

public interface IMagickImage : IEquatable<IMagickImage>, IComparable<IMagickImage>, IDisposable
{
	int AnimationDelay { get; set; }

	int AnimationIterations { get; set; }

	IEnumerable<string> ArtifactNames { get; }

	IEnumerable<string> AttributeNames { get; }

	MagickColor BackgroundColor { get; set; }

	int BaseHeight { get; }

	int BaseWidth { get; }

	bool BlackPointCompensation { get; set; }

	MagickColor BorderColor { get; set; }

	MagickGeometry BoundingBox { get; }

	int ChannelCount { get; }

	IEnumerable<PixelChannel> Channels { get; }

	PrimaryInfo ChromaBluePrimary { get; set; }

	PrimaryInfo ChromaGreenPrimary { get; set; }

	PrimaryInfo ChromaRedPrimary { get; set; }

	PrimaryInfo ChromaWhitePoint { get; set; }

	ClassType ClassType { get; set; }

	Percentage ColorFuzz { get; set; }

	int ColormapSize { get; set; }

	ColorSpace ColorSpace { get; set; }

	ColorType ColorType { get; set; }

	string Comment { get; set; }

	CompositeOperator Compose { get; set; }

	CompressionMethod CompressionMethod { get; set; }

	Density Density { get; set; }

	int Depth { get; set; }

	MagickGeometry EncodingGeometry { get; }

	Endian Endian { get; set; }

	string FileName { get; }

	long FileSize { get; }

	FilterType FilterType { get; set; }

	MagickFormat Format { get; set; }

	MagickFormatInfo FormatInfo { get; }

	double Gamma { get; }

	GifDisposeMethod GifDisposeMethod { get; set; }

	bool HasClippingPath { get; }

	bool HasAlpha { get; set; }

	int Height { get; }

	Interlace Interlace { get; set; }

	PixelInterpolateMethod Interpolate { get; set; }

	bool IsOpaque { get; }

	string Label { get; set; }

	MagickColor MatteColor { get; set; }

	OrientationType Orientation { get; set; }

	MagickGeometry Page { get; set; }

	IEnumerable<string> ProfileNames { get; }

	int Quality { get; set; }

	IMagickImage ReadMask { get; set; }

	RenderingIntent RenderingIntent { get; set; }

	MagickSettings Settings { get; }

	string Signature { get; }

	int TotalColors { get; }

	VirtualPixelMethod VirtualPixelMethod { get; set; }

	int Width { get; }

	IMagickImage WriteMask { get; set; }

	event EventHandler<ProgressEventArgs> Progress;

	event EventHandler<WarningEventArgs> Warning;

	void Read(Bitmap bitmap);

	Bitmap ToBitmap();

	Bitmap ToBitmap(ImageFormat imageFormat);

	BitmapSource ToBitmapSource();

	void AdaptiveBlur();

	void AdaptiveBlur(double radius);

	void AdaptiveBlur(double radius, double sigma);

	void AdaptiveResize(int width, int height);

	void AdaptiveResize(MagickGeometry geometry);

	void AdaptiveSharpen();

	void AdaptiveSharpen(Channels channels);

	void AdaptiveSharpen(double radius, double sigma);

	void AdaptiveSharpen(double radius, double sigma, Channels channels);

	void AdaptiveThreshold(int width, int height);

	void AdaptiveThreshold(int width, int height, double bias);

	void AdaptiveThreshold(int width, int height, Percentage biasPercentage);

	void AddNoise(NoiseType noiseType);

	void AddNoise(NoiseType noiseType, Channels channels);

	void AddNoise(NoiseType noiseType, double attenuate);

	void AddNoise(NoiseType noiseType, double attenuate, Channels channels);

	void AddProfile(ImageProfile profile);

	void AddProfile(ImageProfile profile, bool overwriteExisting);

	void AffineTransform(DrawableAffine affineMatrix);

	void Alpha(AlphaOption value);

	void Annotate(string text, MagickGeometry boundingArea);

	void Annotate(string text, MagickGeometry boundingArea, Gravity gravity);

	void Annotate(string text, MagickGeometry boundingArea, Gravity gravity, double angle);

	void Annotate(string text, Gravity gravity);

	void AutoGamma();

	void AutoGamma(Channels channels);

	void AutoLevel();

	void AutoLevel(Channels channels);

	void AutoOrient();

	void AutoThreshold(AutoThresholdMethod method);

	void BlackThreshold(Percentage threshold);

	void BlackThreshold(Percentage threshold, Channels channels);

	void BlueShift();

	void BlueShift(double factor);

	int BitDepth();

	int BitDepth(Channels channels);

	void BitDepth(Channels channels, int value);

	void BitDepth(int value);

	void Blur();

	void Blur(Channels channels);

	void Blur(double radius, double sigma);

	void Blur(double radius, double sigma, Channels channels);

	void Border(int size);

	void Border(int width, int height);

	void BrightnessContrast(Percentage brightness, Percentage contrast);

	void BrightnessContrast(Percentage brightness, Percentage contrast, Channels channels);

	void CannyEdge();

	void CannyEdge(double radius, double sigma, Percentage lower, Percentage upper);

	void Charcoal();

	void Charcoal(double radius, double sigma);

	void Chop(int xOffset, int width, int yOffset, int height);

	void Chop(MagickGeometry geometry);

	void ChopHorizontal(int offset, int width);

	void ChopVertical(int offset, int height);

	void Clamp();

	void Clamp(Channels channels);

	void Clip();

	void Clip(string pathName, bool inside);

	IMagickImage Clone();

	IMagickImage Clone(MagickGeometry geometry);

	IMagickImage Clone(int width, int height);

	IMagickImage Clone(int x, int y, int width, int height);

	void Clut(IMagickImage image);

	void Clut(IMagickImage image, PixelInterpolateMethod method);

	void Clut(IMagickImage image, PixelInterpolateMethod method, Channels channels);

	void ColorAlpha(MagickColor color);

	void ColorDecisionList(string fileName);

	void Colorize(MagickColor color, Percentage alpha);

	void Colorize(MagickColor color, Percentage alphaRed, Percentage alphaGreen, Percentage alphaBlue);

	void ColorMatrix(MagickColorMatrix matrix);

	MagickErrorInfo Compare(IMagickImage image);

	double Compare(IMagickImage image, ErrorMetric metric);

	double Compare(IMagickImage image, ErrorMetric metric, Channels channels);

	double Compare(IMagickImage image, ErrorMetric metric, IMagickImage difference);

	double Compare(IMagickImage image, ErrorMetric metric, IMagickImage difference, Channels channels);

	void Composite(IMagickImage image);

	void Composite(IMagickImage image, CompositeOperator compose);

	void Composite(IMagickImage image, CompositeOperator compose, string args);

	void Composite(IMagickImage image, int x, int y);

	void Composite(IMagickImage image, int x, int y, CompositeOperator compose);

	void Composite(IMagickImage image, int x, int y, CompositeOperator compose, string args);

	void Composite(IMagickImage image, PointD offset);

	void Composite(IMagickImage image, PointD offset, CompositeOperator compose);

	void Composite(IMagickImage image, PointD offset, CompositeOperator compose, string args);

	void Composite(IMagickImage image, Gravity gravity);

	void Composite(IMagickImage image, Gravity gravity, CompositeOperator compose);

	void Composite(IMagickImage image, Gravity gravity, CompositeOperator compose, string args);

	IEnumerable<ConnectedComponent> ConnectedComponents(int connectivity);

	IEnumerable<ConnectedComponent> ConnectedComponents(ConnectedComponentsSettings settings);

	void Contrast();

	void Contrast(bool enhance);

	void ContrastStretch(Percentage blackPoint);

	void ContrastStretch(Percentage blackPoint, Percentage whitePoint);

	void ContrastStretch(Percentage blackPoint, Percentage whitePoint, Channels channels);

	void Convolve(ConvolveMatrix convolveMatrix);

	void CopyPixels(IMagickImage source);

	void CopyPixels(IMagickImage source, Channels channels);

	void CopyPixels(IMagickImage source, MagickGeometry geometry);

	void CopyPixels(IMagickImage source, MagickGeometry geometry, Channels channels);

	void CopyPixels(IMagickImage source, MagickGeometry geometry, PointD offset);

	void CopyPixels(IMagickImage source, MagickGeometry geometry, PointD offset, Channels channels);

	void CopyPixels(IMagickImage source, MagickGeometry geometry, int x, int y);

	void CopyPixels(IMagickImage source, MagickGeometry geometry, int x, int y, Channels channels);

	void Crop(int width, int height);

	void Crop(int x, int y, int width, int height);

	void Crop(int width, int height, Gravity gravity);

	void Crop(MagickGeometry geometry);

	void Crop(MagickGeometry geometry, Gravity gravity);

	IEnumerable<IMagickImage> CropToTiles(int width, int height);

	IEnumerable<IMagickImage> CropToTiles(MagickGeometry geometry);

	void CycleColormap(int amount);

	void Decipher(string passphrase);

	void Deskew(Percentage threshold);

	void Despeckle();

	ColorType DetermineColorType();

	void Distort(DistortMethod method, params double[] arguments);

	void Distort(DistortMethod method, bool bestfit, params double[] arguments);

	void Draw(Drawables drawables);

	void Draw(params IDrawable[] drawables);

	void Draw(IEnumerable<IDrawable> drawables);

	void Edge(double radius);

	void Emboss();

	void Emboss(double radius, double sigma);

	void Encipher(string passphrase);

	void Enhance();

	void Equalize();

	void Evaluate(Channels channels, EvaluateFunction evaluateFunction, params double[] arguments);

	void Evaluate(Channels channels, EvaluateOperator evaluateOperator, double value);

	void Evaluate(Channels channels, EvaluateOperator evaluateOperator, Percentage percentage);

	void Evaluate(Channels channels, MagickGeometry geometry, EvaluateOperator evaluateOperator, double value);

	void Evaluate(Channels channels, MagickGeometry geometry, EvaluateOperator evaluateOperator, Percentage percentage);

	void Extent(int width, int height);

	void Extent(int x, int y, int width, int height);

	void Extent(int width, int height, MagickColor backgroundColor);

	void Extent(int width, int height, Gravity gravity);

	void Extent(int width, int height, Gravity gravity, MagickColor backgroundColor);

	void Extent(MagickGeometry geometry);

	void Extent(MagickGeometry geometry, MagickColor backgroundColor);

	void Extent(MagickGeometry geometry, Gravity gravity);

	void Extent(MagickGeometry geometry, Gravity gravity, MagickColor backgroundColor);

	void Flip();

	void FloodFill(byte alpha, int x, int y);

	void FloodFill(MagickColor color, int x, int y);

	void FloodFill(MagickColor color, int x, int y, MagickColor target);

	void FloodFill(MagickColor color, PointD coordinate);

	void FloodFill(MagickColor color, PointD coordinate, MagickColor target);

	void FloodFill(IMagickImage image, int x, int y);

	void FloodFill(IMagickImage image, int x, int y, MagickColor target);

	void FloodFill(IMagickImage image, PointD coordinate);

	void FloodFill(IMagickImage image, PointD coordinate, MagickColor target);

	void Flop();

	TypeMetric FontTypeMetrics(string text);

	TypeMetric FontTypeMetrics(string text, bool ignoreNewLines);

	string FormatExpression(string expression);

	void Frame();

	void Frame(MagickGeometry geometry);

	void Frame(int width, int height);

	void Frame(int width, int height, int innerBevel, int outerBevel);

	void Fx(string expression);

	void Fx(string expression, Channels channels);

	void GammaCorrect(double gamma);

	void GammaCorrect(double gamma, Channels channels);

	void GaussianBlur(double radius, double sigma);

	void GaussianBlur(double radius, double sigma, Channels channels);

	EightBimProfile Get8BimProfile();

	string GetAttribute(string name);

	string GetClippingPath();

	string GetClippingPath(string pathName);

	MagickColor GetColormap(int index);

	ColorProfile GetColorProfile();

	string GetArtifact(string name);

	ExifProfile GetExifProfile();

	IptcProfile GetIptcProfile();

	PixelCollection GetPixels();

	ImageProfile GetProfile(string name);

	XmpProfile GetXmpProfile();

	void Grayscale(PixelIntensityMethod method);

	void HaldClut(IMagickImage image);

	Dictionary<MagickColor, int> Histogram();

	void HoughLine();

	void HoughLine(int width, int height, int threshold);

	void Implode(double amount, PixelInterpolateMethod method);

	void InverseFloodFill(byte alpha, int x, int y);

	void InverseFloodFill(MagickColor color, int x, int y);

	void InverseFloodFill(MagickColor color, int x, int y, MagickColor target);

	void InverseFloodFill(MagickColor color, PointD coordinate);

	void InverseFloodFill(MagickColor color, PointD coordinate, MagickColor target);

	void InverseFloodFill(IMagickImage image, int x, int y);

	void InverseFloodFill(IMagickImage image, int x, int y, MagickColor target);

	void InverseFloodFill(IMagickImage image, PointD coordinate);

	void InverseFloodFill(IMagickImage image, PointD coordinate, MagickColor target);

	void InverseLevel(byte blackPoint, byte whitePoint);

	void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage);

	void InverseLevel(byte blackPoint, byte whitePoint, Channels channels);

	void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage, Channels channels);

	void InverseLevel(byte blackPoint, byte whitePoint, double midpoint);

	void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage, double midpoint);

	void InverseLevel(byte blackPoint, byte whitePoint, double midpoint, Channels channels);

	void InverseLevel(Percentage blackPointPercentage, Percentage whitePointPercentage, double midpoint, Channels channels);

	void InverseLevelColors(MagickColor blackColor, MagickColor whiteColor);

	void InverseLevelColors(MagickColor blackColor, MagickColor whiteColor, Channels channels);

	void InverseOpaque(MagickColor target, MagickColor fill);

	void InverseTransparent(MagickColor color);

	void InverseTransparentChroma(MagickColor colorLow, MagickColor colorHigh);

	void Kuwahara();

	void Kuwahara(double radius, double sigma);

	void Level(byte blackPoint, byte whitePoint);

	void Level(Percentage blackPointPercentage, Percentage whitePointPercentage);

	void Level(byte blackPoint, byte whitePoint, Channels channels);

	void Level(Percentage blackPointPercentage, Percentage whitePointPercentage, Channels channels);

	void Level(byte blackPoint, byte whitePoint, double gamma);

	void Level(Percentage blackPointPercentage, Percentage whitePointPercentage, double gamma);

	void Level(byte blackPoint, byte whitePoint, double gamma, Channels channels);

	void Level(Percentage blackPointPercentage, Percentage whitePointPercentage, double gamma, Channels channels);

	void LevelColors(MagickColor blackColor, MagickColor whiteColor);

	void LevelColors(MagickColor blackColor, MagickColor whiteColor, Channels channels);

	void LinearStretch(Percentage blackPoint, Percentage whitePoint);

	void LiquidRescale(int width, int height);

	void LiquidRescale(MagickGeometry geometry);

	void LiquidRescale(Percentage percentage);

	void LiquidRescale(Percentage percentageWidth, Percentage percentageHeight);

	void LocalContrast(double radius, Percentage strength);

	void Lower(int size);

	void Magnify();

	MagickErrorInfo Map(IEnumerable<MagickColor> colors);

	MagickErrorInfo Map(IEnumerable<MagickColor> colors, QuantizeSettings settings);

	MagickErrorInfo Map(IMagickImage image);

	MagickErrorInfo Map(IMagickImage image, QuantizeSettings settings);

	void MeanShift(int size);

	void MeanShift(int size, Percentage colorDistance);

	void MeanShift(int width, int height);

	void MeanShift(int width, int height, Percentage colorDistance);

	void MedianFilter();

	void MedianFilter(int radius);

	void Minify();

	void Modulate(Percentage brightness);

	void Modulate(Percentage brightness, Percentage saturation);

	void Modulate(Percentage brightness, Percentage saturation, Percentage hue);

	void Morphology(MorphologyMethod method, Kernel kernel);

	void Morphology(MorphologyMethod method, Kernel kernel, Channels channels);

	void Morphology(MorphologyMethod method, Kernel kernel, Channels channels, int iterations);

	void Morphology(MorphologyMethod method, Kernel kernel, int iterations);

	void Morphology(MorphologyMethod method, Kernel kernel, string arguments);

	void Morphology(MorphologyMethod method, Kernel kernel, string arguments, Channels channels);

	void Morphology(MorphologyMethod method, Kernel kernel, string arguments, Channels channels, int iterations);

	void Morphology(MorphologyMethod method, Kernel kernel, string arguments, int iterations);

	void Morphology(MorphologyMethod method, string userKernel);

	void Morphology(MorphologyMethod method, string userKernel, Channels channels);

	void Morphology(MorphologyMethod method, string userKernel, Channels channels, int iterations);

	void Morphology(MorphologyMethod method, string userKernel, int iterations);

	void Morphology(MorphologySettings settings);

	Moments Moments();

	void MotionBlur(double radius, double sigma, double angle);

	void Negate();

	void Negate(bool onlyGrayscale);

	void Negate(bool onlyGrayscale, Channels channels);

	void Negate(Channels channels);

	void Normalize();

	void OilPaint();

	void OilPaint(double radius, double sigma);

	void Opaque(MagickColor target, MagickColor fill);

	void OrderedDither(string thresholdMap);

	void OrderedDither(string thresholdMap, Channels channels);

	void Perceptible(double epsilon);

	void Perceptible(double epsilon, Channels channels);

	PerceptualHash PerceptualHash();

	void Ping(byte[] data);

	void Ping(byte[] data, MagickReadSettings readSettings);

	void Ping(FileInfo file);

	void Ping(FileInfo file, MagickReadSettings readSettings);

	void Ping(Stream stream);

	void Ping(Stream stream, MagickReadSettings readSettings);

	void Ping(string fileName);

	void Ping(string fileName, MagickReadSettings readSettings);

	void Polaroid(string caption, double angle, PixelInterpolateMethod method);

	void Posterize(int levels);

	void Posterize(int levels, DitherMethod method);

	void Posterize(int levels, DitherMethod method, Channels channels);

	void Posterize(int levels, Channels channels);

	void PreserveColorType();

	MagickErrorInfo Quantize(QuantizeSettings settings);

	void Raise(int size);

	void RandomThreshold(Percentage percentageLow, Percentage percentageHigh);

	void RandomThreshold(Percentage percentageLow, Percentage percentageHigh, Channels channels);

	void RandomThreshold(byte low, byte high);

	void RandomThreshold(byte low, byte high, Channels channels);

	void Read(byte[] data);

	void Read(byte[] data, MagickReadSettings readSettings);

	void Read(FileInfo file);

	void Read(FileInfo file, int width, int height);

	void Read(FileInfo file, MagickReadSettings readSettings);

	void Read(MagickColor color, int width, int height);

	void Read(Stream stream);

	void Read(Stream stream, MagickReadSettings readSettings);

	void Read(string fileName);

	void Read(string fileName, int width, int height);

	void Read(string fileName, MagickReadSettings readSettings);

	void ReduceNoise();

	void ReduceNoise(int order);

	void RegionMask(MagickGeometry region);

	void RemoveArtifact(string name);

	void RemoveAttribute(string name);

	void RemoveRegionMask();

	void RemoveProfile(string name);

	void RePage();

	void Resample(double resolutionX, double resolutionY);

	void Resample(PointD density);

	void Resize(int width, int height);

	void Resize(MagickGeometry geometry);

	void Resize(Percentage percentage);

	void Resize(Percentage percentageWidth, Percentage percentageHeight);

	void Roll(int x, int y);

	void Rotate(double degrees);

	void RotationalBlur(double angle);

	void RotationalBlur(double angle, Channels channels);

	void Scale(int width, int height);

	void Sample(int width, int height);

	void Sample(MagickGeometry geometry);

	void Sample(Percentage percentage);

	void Sample(Percentage percentageWidth, Percentage percentageHeight);

	void Scale(MagickGeometry geometry);

	void Scale(Percentage percentage);

	void Scale(Percentage percentageWidth, Percentage percentageHeight);

	void Segment();

	void Segment(ColorSpace quantizeColorSpace, double clusterThreshold, double smoothingThreshold);

	void SelectiveBlur(double radius, double sigma, double threshold);

	void SelectiveBlur(double radius, double sigma, double threshold, Channels channels);

	void SelectiveBlur(double radius, double sigma, Percentage thresholdPercentage);

	void SelectiveBlur(double radius, double sigma, Percentage thresholdPercentage, Channels channels);

	IEnumerable<IMagickImage> Separate();

	IEnumerable<IMagickImage> Separate(Channels channels);

	void SepiaTone();

	void SepiaTone(Percentage threshold);

	void SetArtifact(string name, string value);

	void SetAttenuate(double attenuate);

	void SetAttribute(string name, string value);

	void SetClippingPath(string value);

	void SetClippingPath(string value, string pathName);

	void SetColormap(int index, MagickColor color);

	void SetHighlightColor(MagickColor color);

	void SetLowlightColor(MagickColor color);

	void Shade();

	void Shade(double azimuth, double elevation);

	void Shade(double azimuth, double elevation, bool colorShading);

	void Shade(double azimuth, double elevation, bool colorShading, Channels channels);

	void Shadow();

	void Shadow(MagickColor color);

	void Shadow(int x, int y, double sigma, Percentage alpha);

	void Shadow(int x, int y, double sigma, Percentage alpha, MagickColor color);

	void Sharpen();

	void Sharpen(Channels channels);

	void Sharpen(double radius, double sigma);

	void Sharpen(double radius, double sigma, Channels channels);

	void Shave(int leftRight, int topBottom);

	void Shear(double xAngle, double yAngle);

	void SigmoidalContrast(double contrast);

	void SigmoidalContrast(bool sharpen, double contrast);

	void SigmoidalContrast(double contrast, double midpoint);

	void SigmoidalContrast(bool sharpen, double contrast, double midpoint);

	void SigmoidalContrast(double contrast, Percentage midpointPercentage);

	void SigmoidalContrast(bool sharpen, double contrast, Percentage midpointPercentage);

	void SparseColor(SparseColorMethod method, IEnumerable<SparseColorArg> args);

	void SparseColor(SparseColorMethod method, params SparseColorArg[] args);

	void SparseColor(Channels channels, SparseColorMethod method, IEnumerable<SparseColorArg> args);

	void SparseColor(Channels channels, SparseColorMethod method, params SparseColorArg[] args);

	void Sketch();

	void Sketch(double radius, double sigma, double angle);

	void Solarize();

	void Solarize(double factor);

	void Solarize(Percentage factorPercentage);

	void Splice(MagickGeometry geometry);

	void Spread();

	void Spread(double radius);

	void Spread(PixelInterpolateMethod method, double radius);

	void Statistic(StatisticType type, int width, int height);

	Statistics Statistics();

	void Stegano(IMagickImage watermark);

	void Stereo(IMagickImage rightImage);

	void Strip();

	void Swirl(double degrees);

	void Swirl(PixelInterpolateMethod method, double degrees);

	MagickSearchResult SubImageSearch(IMagickImage image);

	MagickSearchResult SubImageSearch(IMagickImage image, ErrorMetric metric);

	MagickSearchResult SubImageSearch(IMagickImage image, ErrorMetric metric, double similarityThreshold);

	void Texture(IMagickImage image);

	void Threshold(Percentage percentage);

	void Thumbnail(int width, int height);

	void Thumbnail(MagickGeometry geometry);

	void Thumbnail(Percentage percentage);

	void Thumbnail(Percentage percentageWidth, Percentage percentageHeight);

	void Tile(IMagickImage image, CompositeOperator compose);

	void Tile(IMagickImage image, CompositeOperator compose, string args);

	void Tint(string opacity);

	void Tint(string opacity, MagickColor color);

	string ToBase64();

	string ToBase64(MagickFormat format);

	byte[] ToByteArray();

	byte[] ToByteArray(IWriteDefines defines);

	byte[] ToByteArray(MagickFormat format);

	void TransformColorSpace(ColorProfile source, ColorProfile target);

	void Transparent(MagickColor color);

	void TransparentChroma(MagickColor colorLow, MagickColor colorHigh);

	void Transpose();

	void Transverse();

	void Trim();

	IMagickImage UniqueColors();

	void UnsharpMask(double radius, double sigma);

	void UnsharpMask(double radius, double sigma, Channels channels);

	void UnsharpMask(double radius, double sigma, double amount, double threshold);

	void UnsharpMask(double radius, double sigma, double amount, double threshold, Channels channels);

	void Vignette();

	void Vignette(double radius, double sigma, int x, int y);

	void Wave();

	void Wave(PixelInterpolateMethod method, double amplitude, double length);

	void WaveletDenoise(byte threshold);

	void WaveletDenoise(byte threshold, double softness);

	void WaveletDenoise(Percentage thresholdPercentage);

	void WaveletDenoise(Percentage thresholdPercentage, double softness);

	void WhiteThreshold(Percentage threshold);

	void WhiteThreshold(Percentage threshold, Channels channels);

	void Write(FileInfo file);

	void Write(FileInfo file, IWriteDefines defines);

	void Write(Stream stream);

	void Write(Stream stream, IWriteDefines defines);

	void Write(Stream stream, MagickFormat format);

	void Write(string fileName);

	void Write(string fileName, IWriteDefines defines);
}

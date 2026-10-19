using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x2000014")]
	internal class GraphicsDependentSystemInfoData
	{
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x10")]
		public GraphicsDeviceType graphicsDeviceType;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x14")]
		public int graphicsMemorySize;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x18")]
		public string graphicsDeviceName;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x20")]
		public string graphicsDeviceVendor;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x28")]
		public int graphicsDeviceID;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x2C")]
		public int graphicsDeviceVendorID;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x30")]
		public bool graphicsUVStartsAtTop;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x38")]
		public string graphicsDeviceVersion;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x40")]
		public int graphicsShaderLevel;

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x44")]
		public bool graphicsMultiThreaded;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x45")]
		public bool hasHiddenSurfaceRemovalOnGPU;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x46")]
		public bool hasDynamicUniformArrayIndexingInFragmentShaders;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x47")]
		public bool supportsShadows;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x48")]
		public bool supportsRawShadowDepthSampling;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x49")]
		public bool supportsMotionVectors;

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x4A")]
		public bool supports3DTextures;

		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x4B")]
		public bool supports2DArrayTextures;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x4C")]
		public bool supports3DRenderTextures;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x4D")]
		public bool supportsCubemapArrayTextures;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x50")]
		public CopyTextureSupport copyTextureSupport;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x54")]
		public bool supportsComputeShaders;

		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x55")]
		public bool supportsGeometryShaders;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x56")]
		public bool supportsTessellationShaders;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x57")]
		public bool supportsInstancing;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x58")]
		public bool supportsHardwareQuadTopology;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x59")]
		public bool supports32bitsIndexBuffer;

		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x5A")]
		public bool supportsSparseTextures;

		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x5C")]
		public int supportedRenderTargetCount;

		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x60")]
		public bool supportsSeparatedRenderTargetsBlend;

		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x64")]
		public int supportedRandomWriteTargetCount;

		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x68")]
		public int supportsMultisampledTextures;

		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x6C")]
		public bool supportsMultisampleAutoResolve;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x70")]
		public int supportsTextureWrapMirrorOnce;

		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x74")]
		public bool usesReversedZBuffer;

		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x78")]
		public NPOTSupport npotSupport;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x7C")]
		public int maxTextureSize;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x80")]
		public int maxCubemapSize;

		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x84")]
		public int maxComputeBufferInputsVertex;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x88")]
		public int maxComputeBufferInputsFragment;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x8C")]
		public int maxComputeBufferInputsGeometry;

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x90")]
		public int maxComputeBufferInputsDomain;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x94")]
		public int maxComputeBufferInputsHull;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x98")]
		public int maxComputeBufferInputsCompute;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x9C")]
		public int maxComputeWorkGroupSize;

		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0xA0")]
		public int maxComputeWorkGroupSizeX;

		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0xA4")]
		public int maxComputeWorkGroupSizeY;

		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0xA8")]
		public int maxComputeWorkGroupSizeZ;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0xAC")]
		public bool supportsAsyncCompute;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0xAD")]
		public bool supportsGraphicsFence;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0xAE")]
		public bool supportsAsyncGPUReadback;

		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0xAF")]
		public bool supportsRayTracing;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0xB0")]
		public bool supportsSetConstantBuffer;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0xB1")]
		public bool minConstantBufferOffsetAlignment;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0xB2")]
		public bool hasMipMaxLevel;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0xB3")]
		public bool supportsMipStreaming;

		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0xB4")]
		public bool usesLoadStoreActions;

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x3F46178", Offset = "0x3F46178", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GraphicsDependentSystemInfoData()
		{
		}
	}
}

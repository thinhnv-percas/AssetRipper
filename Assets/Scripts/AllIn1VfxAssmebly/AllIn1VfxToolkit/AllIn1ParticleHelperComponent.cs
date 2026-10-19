using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("AllIn1VfxToolkit/AddAllIn1VfxParticleHelper")]
	[Token(Token = "0x200000D")]
	public class AllIn1ParticleHelperComponent : MonoBehaviour
	{
		[Token(Token = "0x200000E")]
		public enum EmissionShapes
		{
			[Token(Token = "0x4000040")]
			Cone = 0,
			[Token(Token = "0x4000041")]
			Sphere = 1,
			[Token(Token = "0x4000042")]
			Circle = 2,
			[Token(Token = "0x4000043")]
			None = 3
		}

		[Token(Token = "0x200000F")]
		public enum LifetimeSettings
		{
			[Token(Token = "0x4000045")]
			Ascendant = 0,
			[Token(Token = "0x4000046")]
			Descendent = 1,
			[Token(Token = "0x4000047")]
			None = 2
		}

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x20")]
		public bool hierarchyHelpers;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x21")]
		public bool generalOptions;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x22")]
		public bool shapeOptions;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x23")]
		public bool emissionOptions;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x24")]
		public bool overLifetimeOptions;

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x25")]
		public bool colorChangeOption;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x26")]
		public bool particleHelperPresets;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x27")]
		public bool particleSystemPresets;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x28")]
		public int numberOfCopies;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x2C")]
		public bool applyEverythingOnChange;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x2D")]
		public bool matchDurationToLifetime;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x2E")]
		public bool randomRotation;

		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x30")]
		public float minLifetime;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x34")]
		public float maxLifetime;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x38")]
		public float minSpeed;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x3C")]
		public float maxSpeed;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x40")]
		public float minSize;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x44")]
		public float maxSize;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x48")]
		public ParticleSystem.MinMaxGradient startColor;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x80")]
		public bool isBurst;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x84")]
		public int minNumberOfParticles;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x88")]
		public int maxNumberOfParticles;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x8C")]
		public EmissionShapes currEmissionShape;

		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x90")]
		public LifetimeSettings colorLifetime;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x94")]
		public LifetimeSettings sizeLifetime;

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x3C25678", Offset = "0x3C25678", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void SetSceneDirty()
		{
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x3C2567C", Offset = "0x3C2567C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.numberOfCopies = 1;\n\tthis.applyEverythingOnChange = 1;\n\tthis.minLifetime = 0f;\n\tthis.minSize = 0f;\n\tthis.minNumberOfParticles = 0xA;\n\tthis.colorLifetime = 2;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1ParticleHelperComponent()
		{
			numberOfCopies = 1;
			applyEverythingOnChange = true;
			minLifetime = 0f;
			minSize = 0f;
			minNumberOfParticles = 10;
			maxNumberOfParticles = 0;
			colorLifetime = LifetimeSettings.None;
		}
	}
}

using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Unco.Utils;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001E0")]
	public class KeyAndLockConfig : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x40005F2")]
		[FieldOffset(Offset = "0x18")]
		private List<Pair<GameColor, Material>> m_lockMaterials;

		[SerializeField]
		[Token(Token = "0x40005F3")]
		[FieldOffset(Offset = "0x20")]
		private List<Pair<GameColor, Material>> m_keyMaterials;

		[SerializeField]
		[Token(Token = "0x40005F4")]
		[FieldOffset(Offset = "0x28")]
		private List<Pair<GameColor, Material>> m_chainMaterials;

		[Token(Token = "0x40005F5")]
		[FieldOffset(Offset = "0x30")]
		public GameObject lockVfx;

		[Token(Token = "0x40005F6")]
		[FieldOffset(Offset = "0x38")]
		public GameObject lockVfxGold;

		[Token(Token = "0x40005F7")]
		[FieldOffset(Offset = "0x40")]
		public GameObject keyMono;

		[Token(Token = "0x40005F8")]
		[FieldOffset(Offset = "0x48")]
		public GameObject lockMono;

		[Token(Token = "0x40005F9")]
		[FieldOffset(Offset = "0x50")]
		public GameObject chainPrefab;

		[Token(Token = "0x40005FA")]
		[FieldOffset(Offset = "0x58")]
		public Vector3 keyOverlayOffset;

		[Token(Token = "0x40005FB")]
		[FieldOffset(Offset = "0x64")]
		public Vector3 lockOverlayOffset;

		[Header("Flight — Key Position")]
		[Token(Token = "0x40005FC")]
		[FieldOffset(Offset = "0x70")]
		public TweenSettings moveSettings;

		[Token(Token = "0x40005FD")]
		[FieldOffset(Offset = "0xA0")]
		public TweenSettings moveZSettings;

		[Token(Token = "0x40005FE")]
		[FieldOffset(Offset = "0xD0")]
		public AnimationCurve zCurve;

		[Token(Token = "0x40005FF")]
		[FieldOffset(Offset = "0xD8")]
		public float zCurveMultiplier;

		[Header("Flight — Key Scale Punch")]
		[Token(Token = "0x4000600")]
		[FieldOffset(Offset = "0xE0")]
		public TweenSettings keyScaleUpSettings;

		[Token(Token = "0x4000601")]
		[FieldOffset(Offset = "0x110")]
		public TweenSettings keyScaleBackSettings;

		[Token(Token = "0x4000602")]
		[FieldOffset(Offset = "0x140")]
		public float keyMaxScale;

		[Header("Flight — Key Rotation")]
		[Token(Token = "0x4000603")]
		[FieldOffset(Offset = "0x148")]
		public TweenSettings rotateToMidSettings;

		[Token(Token = "0x4000604")]
		[FieldOffset(Offset = "0x178")]
		public TweenSettings rotateToTargetSettings;

		[Token(Token = "0x4000605")]
		[FieldOffset(Offset = "0x1A8")]
		public Vector3 midRotationEuler;

		[Token(Token = "0x4000606")]
		[FieldOffset(Offset = "0x1B4")]
		public int flightSpinTurns;

		[Token(Token = "0x4000607")]
		[FieldOffset(Offset = "0x1B8")]
		public Vector3 flightSpinAxis;

		[Header("Arrival — Lock Scale Down")]
		[Token(Token = "0x4000608")]
		[FieldOffset(Offset = "0x1C8")]
		public TweenSettings lockScaleDownSettings;

		[Header("Unlock — Key Scale Down")]
		[Token(Token = "0x4000609")]
		[FieldOffset(Offset = "0x1F8")]
		public TweenSettings keyScaleDownSettings;

		[Token(Token = "0x6000890")]
		[Address(RVA = "0x3E82294", Offset = "0x3E82294", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.gc = gc;\n\tv64 = this.m_lockMaterials == 0;\n\tif (v64) goto L_0053;\n\tv73 = new System.Predicate`1<Unco.Utils.Pair`2<_game.CoreSystem.GameColor, UnityEngine.Material>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<_game.CoreSystem.GameColor, UnityEngine.Material>>::.ctor(v73, v51, Il2CppMethodInfo);\n\tv113 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Object>>::Find(this.m_lockMaterials, v73);\n\treturn v73;\nL_0053:\n\treturn 0;\nL_0023:\n\tv51 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyAndLockConfig+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v51);\n")]
		public Material GetLockMaterial(GameColor gc)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockConfig::GetLockMaterial");
			return default;
		}

		[Token(Token = "0x6000891")]
		[Address(RVA = "0x3E823A0", Offset = "0x3E823A0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.gc = gc;\n\tv64 = this.m_keyMaterials == 0;\n\tif (v64) goto L_0053;\n\tv73 = new System.Predicate`1<Unco.Utils.Pair`2<_game.CoreSystem.GameColor, UnityEngine.Material>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<_game.CoreSystem.GameColor, UnityEngine.Material>>::.ctor(v73, v51, Il2CppMethodInfo);\n\tv113 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Object>>::Find(this.m_keyMaterials, v73);\n\treturn v73;\nL_0053:\n\treturn 0;\nL_0023:\n\tv51 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyAndLockConfig+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v51);\n")]
		public Material GetKeyMaterial(GameColor gc)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockConfig::GetKeyMaterial");
			return default;
		}

		[Token(Token = "0x6000892")]
		[Address(RVA = "0x3E824AC", Offset = "0x3E824AC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.gc = gc;\n\tv64 = this.m_chainMaterials == 0;\n\tif (v64) goto L_0053;\n\tv73 = new System.Predicate`1<Unco.Utils.Pair`2<_game.CoreSystem.GameColor, UnityEngine.Material>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<_game.CoreSystem.GameColor, UnityEngine.Material>>::.ctor(v73, v51, Il2CppMethodInfo);\n\tv113 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Object>>::Find(this.m_chainMaterials, v73);\n\treturn v73;\nL_0053:\n\treturn 0;\nL_0023:\n\tv51 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyAndLockConfig+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v51);\n")]
		public Material GetChainMaterial(GameColor gc)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockConfig::GetChainMaterial");
			return default;
		}

		[Token(Token = "0x6000893")]
		[Address(RVA = "0x3E825B8", Offset = "0x3E825B8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.keyOverlayOffset = *([9309520]);\n\tthis.lockOverlayOffset.y = -5.238690037323579E-11d;\n\tv25 = UnityEngine.AnimationCurve::EaseInOut(0f, 0f, 1f, 0f);\n\tthis.zCurve = v25;\n\tthis.zCurveMultiplier = 1f;\n\tthis.keyMaxScale = 1.5f;\n\tthis.flightSpinTurns = 1;\n\tgoto L_0031;\nL_0031:\n\tthis.flightSpinAxis = v56.upVector;\n\tthis.flightSpinAxis.z = v56.upVector.z;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public KeyAndLockConfig()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockConfig::.ctor");
		}
	}
}

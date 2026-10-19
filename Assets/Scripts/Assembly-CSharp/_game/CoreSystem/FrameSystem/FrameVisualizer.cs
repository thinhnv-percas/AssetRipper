using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.FrameSystem.MeshGen;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004E9")]
	public class FrameVisualizer : MonoBehaviour, IDisposable
	{
		[Serializable]
		[Token(Token = "0x20004EA")]
		private struct DifficultyMaterialPreset
		{
			[Token(Token = "0x4001079")]
			[FieldOffset(Offset = "0x0")]
			public LevelDifficulty Difficulty;

			[Token(Token = "0x400107A")]
			[FieldOffset(Offset = "0x8")]
			public Material NonPlayableMaterial;

			[Token(Token = "0x400107B")]
			[FieldOffset(Offset = "0x10")]
			public Material WallFillMaterial;

			[Token(Token = "0x400107C")]
			[FieldOffset(Offset = "0x18")]
			public Material RimMaterial;
		}

		[SerializeField]
		[Token(Token = "0x4001062")]
		[FieldOffset(Offset = "0x20")]
		private Material m_playableMaterial;

		[SerializeField]
		[Token(Token = "0x4001063")]
		[FieldOffset(Offset = "0x28")]
		private Material m_nonPlayableMaterial;

		[FormerlySerializedAs("m_outlineMaterial")]
		[SerializeField]
		[Token(Token = "0x4001064")]
		[FieldOffset(Offset = "0x30")]
		private Material m_rimMaterial;

		[SerializeField]
		[Token(Token = "0x4001065")]
		[FieldOffset(Offset = "0x38")]
		private DifficultyMaterialPreset[] m_difficultyPresets;

		[SerializeField]
		[Token(Token = "0x4001066")]
		[FieldOffset(Offset = "0x40")]
		private float m_cornerRadius;

		[SerializeField]
		[Token(Token = "0x4001067")]
		[FieldOffset(Offset = "0x44")]
		private int m_outlineCornerSegments;

		[SerializeField]
		[Token(Token = "0x4001068")]
		[FieldOffset(Offset = "0x48")]
		private float m_playableDepth;

		[SerializeField]
		[Token(Token = "0x4001069")]
		[FieldOffset(Offset = "0x4C")]
		private float m_nonPlayableDepth;

		[SerializeField]
		[Token(Token = "0x400106A")]
		[FieldOffset(Offset = "0x50")]
		private int m_fillSortingOrder;

		[SerializeField]
		[Token(Token = "0x400106B")]
		[FieldOffset(Offset = "0x54")]
		private int m_outlineSortingOrder;

		[SerializeField]
		[Token(Token = "0x400106C")]
		[FieldOffset(Offset = "0x58")]
		private bool m_generateRim;

		[SerializeField]
		[Token(Token = "0x400106D")]
		[FieldOffset(Offset = "0x5C")]
		private float m_rimWidth;

		[SerializeField]
		[Token(Token = "0x400106E")]
		[FieldOffset(Offset = "0x60")]
		private float m_rimExtraHeight;

		[SerializeField]
		[Token(Token = "0x400106F")]
		[FieldOffset(Offset = "0x64")]
		private int m_rimCornerSegments;

		[SerializeField]
		[Token(Token = "0x4001070")]
		[FieldOffset(Offset = "0x68")]
		private int m_rimSortingOrder;

		[SerializeField]
		[Token(Token = "0x4001071")]
		[FieldOffset(Offset = "0x6C")]
		private bool m_bakeWallGradient;

		[SerializeField]
		[Token(Token = "0x4001072")]
		[FieldOffset(Offset = "0x70")]
		private Material m_wallFillMaterial;

		[Token(Token = "0x4001073")]
		[FieldOffset(Offset = "0x78")]
		private readonly List<GameObject> _generatedObjects;

		[Inject(false)]
		[Token(Token = "0x4001074")]
		[FieldOffset(Offset = "0x80")]
		private FrameController _controller;

		[Inject(false)]
		[Token(Token = "0x4001075")]
		[FieldOffset(Offset = "0x88")]
		private ILevel _level;

		[Token(Token = "0x4001076")]
		[FieldOffset(Offset = "0x90")]
		private Material _activeNonPlayableMaterial;

		[Token(Token = "0x4001077")]
		[FieldOffset(Offset = "0x98")]
		private Material _activeWallFillMaterial;

		[Token(Token = "0x4001078")]
		[FieldOffset(Offset = "0xA0")]
		private Material _activeRimMaterial;

		[Token(Token = "0x60014AA")]
		[Address(RVA = "0x3CFB980", Offset = "0x3CFB980", Length = "0x26C")]
		private void SelectDifficultyMaterials()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameVisualizer::SelectDifficultyMaterials");
		}

		[Inject(false)]
		[Token(Token = "0x60014AB")]
		[Address(RVA = "0x3CFBBEC", Offset = "0x3CFBBEC", Length = "0x48")]
		public void Construct()
		{
			SelectDifficultyMaterials();
			FrameController controller = _controller;
			FrameData frameData = controller.m_frameData;
			RebuildVisuals(frameData);
		}

		[Token(Token = "0x60014AC")]
		[Address(RVA = "0x3CFBC34", Offset = "0x3CFBC34", Length = "0x940")]
		public void RebuildVisuals(FrameData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameVisualizer::RebuildVisuals");
		}

		[Token(Token = "0x60014AD")]
		[Address(RVA = "0x3CFC740", Offset = "0x3CFC740", Length = "0x15C")]
		private GameObject CreateMeshObject(string name, Mesh mesh, Material material, int sortingOrder, bool castShadow = true)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.hideFlags = HideFlags.DontSave;
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			transform.SetParent(parent, worldPositionStays: false);
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.sharedMesh = mesh;
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = material;
			meshRenderer.sortingOrder = sortingOrder;
			meshRenderer.shadowCastingMode = (castShadow ? ShadowCastingMode.On : ShadowCastingMode.Off);
			return gameObject;
		}

		[Token(Token = "0x60014AE")]
		[Address(RVA = "0x3CFC574", Offset = "0x3CFC574", Length = "0x1CC")]
		private unsafe void ClearGenerated()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameVisualizer::ClearGenerated");
		}

		[Token(Token = "0x60014AF")]
		[Address(RVA = "0x3CFC89C", Offset = "0x3CFC89C", Length = "0x59C")]
		private static List<List<float2>> ExtractInnerChains(List<float2> loop, HashSet<long> outerBoundaryKeys)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameVisualizer::ExtractInnerChains");
			return default;
		}

		[Token(Token = "0x60014B0")]
		[Address(RVA = "0x3CFCE38", Offset = "0x3CFCE38", Length = "0x4")]
		public void Dispose()
		{
			ClearGenerated();
		}

		[Token(Token = "0x60014B1")]
		[Address(RVA = "0x3CFCE3C", Offset = "0x3CFCE3C", Length = "0xC0")]
		public FrameVisualizer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameVisualizer::.ctor");
		}
	}
}

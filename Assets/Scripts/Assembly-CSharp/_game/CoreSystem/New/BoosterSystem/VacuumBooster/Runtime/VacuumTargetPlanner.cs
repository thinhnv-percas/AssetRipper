using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.VacuumSystem;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x2000457")]
	public class VacuumTargetPlanner
	{
		[Token(Token = "0x2000458")]
		private struct GrainRec
		{
			[Token(Token = "0x4000E10")]
			[FieldOffset(Offset = "0x0")]
			public Unity.Entities.Entity entity;

			[Token(Token = "0x4000E11")]
			[FieldOffset(Offset = "0x8")]
			public float2 pos;

			[Token(Token = "0x4000E12")]
			[FieldOffset(Offset = "0x10")]
			public float dist;

			[Token(Token = "0x4000E13")]
			[FieldOffset(Offset = "0x14")]
			public bool onConveyor;
		}

		[Token(Token = "0x2000459")]
		private struct Candidate
		{
			[Token(Token = "0x4000E14")]
			[FieldOffset(Offset = "0x0")]
			public _game.BaseLayerSystems.EntitySystem.Core.Entity mold;

			[Token(Token = "0x4000E15")]
			[FieldOffset(Offset = "0x8")]
			public GameColor color;

			[Token(Token = "0x4000E16")]
			[FieldOffset(Offset = "0xC")]
			public int colorIndex;

			[Token(Token = "0x4000E17")]
			[FieldOffset(Offset = "0x10")]
			public int row;

			[Token(Token = "0x4000E18")]
			[FieldOffset(Offset = "0x14")]
			public int col;

			[Token(Token = "0x4000E19")]
			[FieldOffset(Offset = "0x18")]
			public int capacity;

			[Token(Token = "0x4000E1A")]
			[FieldOffset(Offset = "0x1C")]
			public int dataFill;

			[Token(Token = "0x4000E1B")]
			[FieldOffset(Offset = "0x20")]
			public int need;
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200045A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000E1C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000E1D")]
			public static Comparison<GrainRec> _003C_003E9__11_0;

			[Token(Token = "0x600124A")]
			[Address(RVA = "0x3CCDA14", Offset = "0x3CCDA14", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600124B")]
			[Address(RVA = "0x3CCDA78", Offset = "0x3CCDA78", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal unsafe int _003CComputePlan_003Eb__11_0(GrainRec a, GrainRec b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumTargetPlanner._003C_003Ec::_003CComputePlan_003Eb__11_0");
				return default;
			}
		}

		[Token(Token = "0x4000E0B")]
		public const int ColorCount = 13;

		[Inject(false)]
		[Token(Token = "0x4000E0D")]
		[FieldOffset(Offset = "0x10")]
		private MoldAbsorptionBridge _bridge;

		[Inject(false)]
		[Token(Token = "0x4000E0E")]
		[FieldOffset(Offset = "0x18")]
		private _game.BaseLayerSystems.EntitySystem.Core.EntityManager _moldEm;

		[Inject(false)]
		[Token(Token = "0x4000E0F")]
		[FieldOffset(Offset = "0x20")]
		private VacuumConfig _config;

		[Token(Token = "0x17000196")]
		[field: Token(Token = "0x4000E0C")]
		public static VacuumTargetPlanner Instance
		{
			[Token(Token = "0x6001245")]
			[Address(RVA = "0x3CCD908", Offset = "0x3CCD908", Length = "0x4C")]
			get;
			[Token(Token = "0x6001246")]
			[Address(RVA = "0x3CCD954", Offset = "0x3CCD954", Length = "0x5C")]
			private set;
		}

		[Inject(false)]
		[Token(Token = "0x6001247")]
		[Address(RVA = "0x3CCD9B0", Offset = "0x3CCD9B0", Length = "0x5C")]
		private void Construct()
		{
			Instance = this;
		}

		[Token(Token = "0x6001248")]
		[Address(RVA = "0x3CCA9A0", Offset = "0x3CCA9A0", Length = "0x1568")]
		public unsafe VacuumPlan ComputePlan(float2 mouthPos, int capacity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTargetPlanner::ComputePlan");
			return default;
		}

		[Token(Token = "0x6001249")]
		[Address(RVA = "0x3CCDA0C", Offset = "0x3CCDA0C", Length = "0x8")]
		public VacuumTargetPlanner()
		{
		}
	}
}

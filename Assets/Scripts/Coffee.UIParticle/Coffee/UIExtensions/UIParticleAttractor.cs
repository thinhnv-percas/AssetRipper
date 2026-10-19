using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Coffee.UIParticleInternal;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	[Token(Token = "0x2000025")]
	public class UIParticleAttractor : MonoBehaviour, ISerializationCallbackReceiver
	{
		[Token(Token = "0x2000026")]
		public enum Movement
		{
			[Token(Token = "0x400006C")]
			Linear = 0,
			[Token(Token = "0x400006D")]
			Smooth = 1,
			[Token(Token = "0x400006E")]
			Sphere = 2
		}

		[Token(Token = "0x2000027")]
		public enum UpdateMode
		{
			[Token(Token = "0x4000070")]
			Normal = 0,
			[Token(Token = "0x4000071")]
			UnscaledTime = 1
		}

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x20")]
		private ParticleSystem m_ParticleSystem;

		[SerializeField]
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x28")]
		private List<ParticleSystem> m_ParticleSystems;

		[Range(0.1f, 10f)]
		[SerializeField]
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x30")]
		private float m_DestinationRadius;

		[Range(0f, 0.95f)]
		[SerializeField]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x34")]
		private float m_DelayRate;

		[Range(0.001f, 100f)]
		[SerializeField]
		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x38")]
		private float m_MaxSpeed;

		[SerializeField]
		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x3C")]
		private Movement m_Movement;

		[SerializeField]
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x40")]
		private UpdateMode m_UpdateMode;

		[SerializeField]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x48")]
		private UnityEvent m_OnAttracted;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x50")]
		private List<UIParticle> _uiParticles;

		[Token(Token = "0x1700001C")]
		public float destinationRadius
		{
			[Token(Token = "0x60000DC")]
			[Address(RVA = "0x3F27368", Offset = "0x3F27368", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.destinationRadius;\n")]
			get
			{
				return m_DestinationRadius;
			}
			[Token(Token = "0x60000DD")]
			[Address(RVA = "0x3F27370", Offset = "0x3F27370", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value < 10f;\n\tv3 = value == 10f;\n\tv6 = value == value;\n\tv7 = 10f == 10f;\n\tv8 = v6 & v7;\n\tv9 = ~v8;\n\tv10 = v1 == v9;\n\tv11 = ~v3;\n\tv12 = v10 & v11;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = 10f;\n\tgoto L_0015;\nL_FFFFFFFF:\n\tv16 = value;\nL_FFFFFFFF:\n\tv31 = 0x3DCCCCCD;\n\tgoto L_0023;\nL_FFFFFFFF:\n\tv31 = v16;\nL_0015:\n\tv20 = value < 0x3DCCCCCD;\n\tv28 = ~v20;\n\tif (v28) goto L_FFFFFFFF;\nL_0023:\n\tthis.destinationRadius = v31;\n\treturn;\n")]
			set
			{
				bool flag = value < 10f;
				bool flag2 = value == 10f;
				bool flag3 = value == value;
				bool flag4 = 10f == 10f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				float num = ((!(flag7 && flag8)) ? value : 10f);
				float num2 = ((!(value < 0.1f)) ? num : 0.1f);
				m_DestinationRadius = num2;
			}
		}

		[Token(Token = "0x1700001D")]
		public float delay
		{
			[Token(Token = "0x60000DE")]
			[Address(RVA = "0x3F27398", Offset = "0x3F27398", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.delay;\n")]
			get
			{
				return m_DelayRate;
			}
			[Token(Token = "0x60000DF")]
			[Address(RVA = "0x3F273A0", Offset = "0x3F273A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.delay = value;\n\treturn;\n")]
			set
			{
				m_DelayRate = value;
			}
		}

		[Token(Token = "0x1700001E")]
		public float maxSpeed
		{
			[Token(Token = "0x60000E0")]
			[Address(RVA = "0x3F273A8", Offset = "0x3F273A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.maxSpeed;\n")]
			get
			{
				return m_MaxSpeed;
			}
			[Token(Token = "0x60000E1")]
			[Address(RVA = "0x3F273B0", Offset = "0x3F273B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.maxSpeed = value;\n\treturn;\n")]
			set
			{
				m_MaxSpeed = value;
			}
		}

		[Token(Token = "0x1700001F")]
		public Movement movement
		{
			[Token(Token = "0x60000E2")]
			[Address(RVA = "0x3F273B8", Offset = "0x3F273B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.movement;\n")]
			get
			{
				return m_Movement;
			}
			[Token(Token = "0x60000E3")]
			[Address(RVA = "0x3F273C0", Offset = "0x3F273C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.movement = value;\n\treturn;\n")]
			set
			{
				m_Movement = value;
			}
		}

		[Token(Token = "0x17000020")]
		public UpdateMode updateMode
		{
			[Token(Token = "0x60000E4")]
			[Address(RVA = "0x3F273C8", Offset = "0x3F273C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.updateMode;\n")]
			get
			{
				return m_UpdateMode;
			}
			[Token(Token = "0x60000E5")]
			[Address(RVA = "0x3F273D0", Offset = "0x3F273D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateMode = value;\n\treturn;\n")]
			set
			{
				m_UpdateMode = value;
			}
		}

		[Token(Token = "0x17000021")]
		public UnityEvent onAttracted
		{
			[Token(Token = "0x60000E6")]
			[Address(RVA = "0x3F273D8", Offset = "0x3F273D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.onAttracted;\n")]
			get
			{
				return m_OnAttracted;
			}
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x3F273E0", Offset = "0x3F273E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onAttracted = value;\n\treturn;\n")]
			set
			{
				m_OnAttracted = value;
			}
		}

		[Token(Token = "0x17000022")]
		public IReadOnlyList<ParticleSystem> particleSystems
		{
			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x3F273E8", Offset = "0x3F273E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ParticleSystems;\n")]
			get
			{
				return m_ParticleSystems;
			}
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x3F273F0", Offset = "0x3F273F0", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv55 = new System.Collections.Generic.List`1<UnityEngine.ParticleSystem>();\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::.ctor(v55);\n\tthis.m_ParticleSystems = v55;\n\tv60 = this.m_ParticleSystems;\nL_003B:\n\tv70 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::IndexOf(v60, ps);\n\tv76 = v70 & 0x80000000;\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0048;\nL_0047:\n\treturn;\nL_0048:\n\tv139 = this.m_ParticleSystems;\n\tgoto L_006D;\nL_006D:\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::Add(v139, ps);\n\tv132 = this._uiParticles;\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::Clear(v132);\n\tv86 = v132.Count < 1;\n\tif (v86) goto L_0047;\n\treturn;\nL_0023:\n\tv60 = this.m_ParticleSystems;\n\tv47 = this.m_ParticleSystems == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_003B;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddParticleSystem(ParticleSystem ps)
		{
			//IL_0050: Expected I4, but got I8
			List<ParticleSystem> list = m_ParticleSystems;
			if (m_ParticleSystems == null)
			{
				List<ParticleSystem> list2 = new List<ParticleSystem>();
				m_ParticleSystems = list2;
				list = m_ParticleSystems;
			}
			int num = list.IndexOf(ps);
			if ((int)(num & 0x80000000L) != 0)
			{
				List<ParticleSystem> list3 = m_ParticleSystems;
				list3.Add(ps);
				List<UIParticle> uiParticles = _uiParticles;
				uiParticles.Clear();
				if (uiParticles.Count < 1)
				{
				}
			}
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x3F2756C", Offset = "0x3F2756C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv55 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::IndexOf(this.m_ParticleSystems, v40);\n\tv105 = v55 & 0x80000000;\n\tv106 = v105 == 0;\n\tv93 = ~v106;\n\tif (v93) goto L_0056;\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::RemoveAt(this.m_ParticleSystems, v55);\n\tv96 = this._uiParticles;\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::Clear(v96);\n\tv58 = v96.Count < 1;\n\tif (v58) goto L_0056;\n\treturn;\nL_0056:\n\treturn;\nL_001D:\n\tv48 = this.m_ParticleSystems == 0;\n\tif (v48) goto L_0056;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveParticleSystem(ParticleSystem ps)
		{
			//IL_002a: Expected I4, but got I8
			if (m_ParticleSystems == null)
			{
				return;
			}
			ParticleSystem item = default(ParticleSystem);
			int num = m_ParticleSystems.IndexOf(item);
			if ((int)(num & 0x80000000L) == 0)
			{
				m_ParticleSystems.RemoveAt(num);
				List<UIParticle> uiParticles = _uiParticles;
				uiParticles.Clear();
				if (uiParticles.Count < 1)
				{
				}
			}
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x3F27644", Offset = "0x3F27644", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCoffee.UIExtensions.UIParticleAttractor::UpgradeIfNeeded(this);\n\treturn;\n")]
		private void Awake()
		{
			UpgradeIfNeeded();
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x3F277E8", Offset = "0x3F277E8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tCoffee.UIExtensions.UIParticleUpdater::Register(this);\n\treturn;\n")]
		private void OnEnable()
		{
			UIParticleUpdater.Register(this);
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x3F279A8", Offset = "0x3F279A8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tCoffee.UIExtensions.UIParticleUpdater::Unregister(this);\n\treturn;\n")]
		private void OnDisable()
		{
			UIParticleUpdater.Unregister(this);
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x3F27B14", Offset = "0x3F27B14", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._uiParticles = 0;\n\tthis.m_ParticleSystems = 0;\n\treturn;\n")]
		private void OnDestroy()
		{
			_uiParticles = null;
			m_ParticleSystems = null;
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x3F27B48", Offset = "0x3F27B48", Length = "0x4E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv276 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\tv303 = 0;\n\tgoto L_0060;\nL_004D:\n\tUnityEngine.ParticleSystem::SetParticles(v332, v488, v468);\n\tv276 = 0xB292000 + 0x5A0;\nL_0060:\n\tv203 = v303 >= v321.Count;\n\tif (v203) goto L_01C7;\n\tv332 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Item(v321, v303);\n\tv360 = *([v276 @ X26_v6 (System.Int32)]);\n\tv361 = *([v360 @ X0_v15+E4]) == 0;\n\tif (v361) goto L_0077;\n\tv416 = UnityEngine.Object::op_Equality(v332, 0);\n\tv420 = v416 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_0052;\n\tgoto L_007C;\nL_0077:\n\tv425 = UnityEngine.Object::op_Equality(v332, 0);\n\tv476 = v425 == 0;\n\tv471 = ~v476;\n\tif (v471) goto L_0052;\nL_007C:\n\tv292 = v332 == 0;\n\tif (v292) goto L_01C9;\n\tv286 = UnityEngine.Component::get_gameObject(v332);\n\tv293 = v286 == 0;\n\tif (v293) goto L_01C9;\n\tv467 = UnityEngine.GameObject::get_activeInHierarchy(v286);\n\tv472 = ~v467;\n\tif (v472) goto L_0052;\n\tv468 = UnityEngine.ParticleSystem::get_particleCount(v332);\n\tv473 = v468 == 0;\n\tif (v473) goto L_0052;\n\tgoto L_0096;\nL_0096:\n\tv488 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetParticleArray(v468);\n\tv490 = UnityEngine.ParticleSystem::GetParticles(v332, v488, v468);\n\tv294 = this._uiParticles == 0;\n\tif (v294) goto L_01C9;\n\tv494 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::get_Item(this._uiParticles, v303);\n\tv192 = Coffee.UIExtensions.UIParticleAttractor::GetDestinationPosition(this, v494, v332);\n\tv204 = v468 < 1;\n\tif (v204) goto L_004D;\n\tv295 = v488 == 0;\n\tif (v295) goto L_01C9;\n\tv159 = v488 + 0x20;\nL_FFFFFFFF:\n\tv163 = 0;\n\tgoto L_00DF;\nL_00DF:\n\tv580 = 0x8BF6A34(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), v159, 0x84, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv632 = UnityEngine.ParticleSystem+Particle::get_remainingLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv633 = v632 < 0;\n\tv634 = v632 == 0;\n\tv637 = v632 == v632;\n\tv638 = ~v637;\n\tv639 = v633 == v638;\n\tv640 = ~v639;\n\tv641 = v640 | v634;\n\tif (v641) goto L_0133;\n\tv644 = UnityEngine.ParticleSystem+Particle::get_position(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tgoto L_0102;\nL_0104:\n\tv695 = v644.z - v192.z;\n\tv696 = v644.y - v192.y;\n\tv697 = v644 - v192;\n\tv597 = v697 * v697;\n\tv698 = v696 * v696;\n\tv699 = v597 + v698;\n\tv700 = v695 * v695;\n\tv701 = v700 + v699;\n\tv651 = UnityEngine.Mathf::Sqrt(v701);\n\tv660 = v651 < this.destinationRadius;\n\tv603 = ~v660;\n\tif (v603) goto L_0133;\n\tUnityEngine.ParticleSystem+Particle::set_remainingLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), 0f);\n\tv729 = 0x8BF6A34(v159, &v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), 0x84, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv746 = this.onAttracted == 0;\n\tif (v746) goto L_00C5;\n\tUnityEngine.Events.UnityEvent::Invoke(this.onAttracted);\n\tgoto L_00C5;\nL_0133:\n\tv672 = UnityEngine.ParticleSystem+Particle::get_startLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv592 = v672 * this.delay;\n\tv682 = UnityEngine.ParticleSystem+Particle::get_startLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv693 = UnityEngine.ParticleSystem+Particle::get_startLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv705 = UnityEngine.ParticleSystem+Particle::get_remainingLifetime(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv708 = v693 - v705;\n\tv709 = v708 - v592;\n\tv590 = v708 >= v592;\n\tif (v590) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv596 = 0;\n\tgoto L_0150;\nL_FFFFFFFF:\n\tv596 = v709;\n\tv594 = v682 - v592;\n\tv732 = UnityEngine.ParticleSystem+Particle::get_position(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv751 = Coffee.UIExtensions.UIParticleAttractor::GetAttractedPosition(this, v732, v192, v594, v596);\n\tUnityEngine.ParticleSystem+Particle::set_position(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), v751);\n\tv758 = UnityEngine.ParticleSystem+Particle::get_velocity(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle));\n\tv602 = v758 * 0.5f;\n\tv600 = v758.y * 0.5f;\n\tv598 = v758.z * 0.5f;\n\t// 375 MakeStruct v581 @ AGG3F27F20_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v602 @ V0_v20 (System.Single), v600 @ V1_v13 (System.Single), v598 @ V2_v12 (System.Single)\n\tUnityEngine.ParticleSystem+Particle::set_velocity(&v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), v581);\n\tv745 = 0x8BF6A34(v159, &v79 @ stack_-130_v1 (UnityEngine.ParticleSystem+Particle), 0x84, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00C5;\nL_01C7:\n\treturn;\nL_01C9:\n\tthrow System.NullReferenceException;\nL_0036:\n\tv79 = 0;\n\tCoffee.UIExtensions.UIParticleAttractor::CollectUIParticlesIfNeeded(this);\n\tv321 = this.m_ParticleSystems;\n\tv87 = this.m_ParticleSystems == 0;\n\tif (v87) goto L_01C9;\nL_0052:\n\tv303 = v303 + 1;\n\tv321 = this.m_ParticleSystems;\n\tv291 = this.m_ParticleSystems == 0;\n\tif (v291) goto L_01C9;\nL_0102:\n\tgoto L_0104;\nL_00C5:\n\tv163 = v163 + 1;\n\tv159 = v159 + 0x84;\n\tv520 = v468 == v163;\n\tif (v520) goto L_004D;\nL_0150:\n\tv720 = v596 == 0;\n\tv721 = v596 < 0;\n\tv722 = ~v721;\n\tv725 = ~v722;\n\tv604 = v725 | v720;\n\tif (v604) goto L_00C5;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Attract()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleAttractor::Attract");
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x3F2832C", Offset = "0x3F2832C", Length = "0x31C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tgoto L_0022;\nL_0022:\n\tv73 = UnityEngine.Object::op_Implicit(uiParticle);\n\tv81 = ~v73;\n\tif (v81) goto L_FFFFFFFF;\n\tv101 = UnityEngine.Behaviour::get_enabled(uiParticle);\n\tv241 = v101 ^ 1;\n\tgoto L_0045;\nL_FFFFFFFF:\n\tv241 = 1;\nL_0045:\n\tv216 = UnityEngine.Component::get_transform(particleSystem);\n\tv202 = UnityEngine.Transform::get_position(v216);\n\tv217 = UnityEngine.Component::get_transform(this);\n\tv203 = UnityEngine.Transform::get_position(v217);\n\tgoto L_0065;\nL_0065:\n\tgoto L_0069;\nL_0069:\n\tgoto L_006B;\nL_006B:\n\tv389 = Coffee.UIParticleInternal.ParticleSystemExtensions::GetActualSimulationSpace(particleSystem);\n\tv386 = v389 == 0;\n\tif (v386) goto L_008B;\n\tv394 = v241 & 1;\n\tv395 = v394 == 0;\nL_FFFFFFFF:\n\tv175 = v203;\nL_FFFFFFFF:\n\tv437 = v389;\n\tif (v395) goto L_00A4;\nL_FFFFFFFF:\n\tv423 = v203;\n\tgoto L_0116;\nL_008B:\n\tv437 = UnityEngine.Component::get_transform(particleSystem);\n\tv406 = UnityEngine.Transform::InverseTransformPoint(v437, v203);\n\tv449 = v241 & 1;\n\tv450 = v449 == 0;\n\tv409 = ~v450;\nL_FFFFFFFF:\n\tv175 = v406;\nL_FFFFFFFF:\n\tv423 = v406;\n\tif (v409) goto L_0116;\nL_00A4:\n\t// 164 MakeStruct v155 @ AGG3F28500_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), uiParticle.parentScale (UnityEngine.Vector3), uiParticle.<parentScale>k__BackingField.y (System.Single), uiParticle.<parentScale>k__BackingField.z (System.Single)\n\tv443 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(v155);\n\tv205 = uiParticle.scale3D;\n\tv184 = uiParticle.m_Scale3D.z;\n\tv136 = uiParticle.autoScalingMode == 2;\nL_FFFFFFFF:\n\tv188 = v202;\n\tif (v136) goto L_00D1;\n\tv437 = UnityEngine.Component::get_transform(uiParticle);\n\tv474 = UnityEngine.Transform::get_localScale(v437);\n\tv456 = uiParticle.scale3D * uiParticle.canvasScale;\n\tv454 = uiParticle.m_Scale3D.z * uiParticle.<canvasScale>k__BackingField.z;\n\tv466 = v456 * v474;\n\tv184 = v454 * v474.z;\nL_FFFFFFFF:\n\tv188 = v202;\nL_FFFFFFFF:\n\tv205 = v466;\n\tv221 = UnityEngine.Component::get_transform(uiParticle);\n\tv478 = UnityEngine.Transform::get_position(v221);\n\tv411 = v478 - v188;\n\tv414 = v205 - v443;\n\tv428 = v414 * v411;\n\t// 248 MakeStruct v410 @ AGG3F285F4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v205 @ V0_v8 (UnityEngine.Vector3), v477 @ V1.S0, v184 @ V12_v5 (System.Single)\n\tv489 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(v410);\n\tv434 = v489 * v428;\n\tv424 = v176 + v434;\nL_FFFFFFFF:\n\tv423 = v424;\nL_0116:\n\treturn v423;\nL_00D1:\n\t// 209 MakeStruct v104 @ AGG3F2857C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v205 @ V0_v8 (UnityEngine.Vector3), v477 @ V1.S0, v184 @ V12_v5 (System.Single)\n\tv206 = Coffee.UIParticleInternal.Vector3Extensions::Inverse(v104);\n\tv113 = v175 * v443;\n\tv176 = v113 * v206;\n\tv473 = uiParticle.positionMode == 0;\n\tv438 = ~v473;\nL_FFFFFFFF:\n\tv423 = v176;\n\tif (v438) goto L_0116;\n")]
		private Vector3 GetDestinationPosition(UIParticle uiParticle, ParticleSystem particleSystem)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleAttractor::GetDestinationPosition");
			return default;
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x3F28648", Offset = "0x3F28648", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv215 = this.maxSpeed;\n\tv49 = this.updateMode == 1;\n\tif (v49) goto L_002E;\n\tv55 = this.updateMode == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0061;\n\tv73 = UnityEngine.Time::get_deltaTime();\n\tgoto L_0032;\nL_002E:\n\tv73 = UnityEngine.Time::get_unscaledDeltaTime();\nL_0032:\n\tv80 = v73 * 0x42700000;\n\tv215 = v215 * v80;\n\tv133 = this.movement;\n\tv87 = this.movement == 2;\nL_FFFFFFFF:\n\tv251 = current.y;\nL_FFFFFFFF:\n\tv94 = current.y;\nL_FFFFFFFF:\n\tv266 = v215;\n\tif (v87) goto L_006D;\nL_0043:\n\tv140 = v133 == 1;\n\tif (v140) goto L_0084;\n\tv155 = v215 / duration;\n\tv160 = v133 == 0;\n\tv165 = ~v160;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv216 = v215;\n\tgoto L_005C;\nL_FFFFFFFF:\n\tv216 = v155;\nL_FFFFFFFF:\n\tv266 = v216;\nL_FFFFFFFF:\n\tv341 = target;\nL_FFFFFFFF:\n\tv269 = target.y;\nL_FFFFFFFF:\n\tv270 = target.z;\n\tgoto L_00BA;\nL_0061:\n\tv133 = *([B19303C]);\n\tv72 = *([B19303C]) != 2;\nL_FFFFFFFF:\n\tv251 = current.y;\nL_FFFFFFFF:\n\tv94 = current.y;\nL_FFFFFFFF:\n\tv266 = this.maxSpeed;\n\tif (v72) goto L_0043;\nL_006D:\n\tv109 = time / duration;\n\t// 117 MakeStruct v117 @ AGG3F28728_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), current @ V0 (UnityEngine.Vector3), v94 @ V3_v7 (System.Single), current.z (System.Single)\n\tv119 = UnityEngine.Vector3::Slerp(v117, target, v109);\n\tv153 = *([B193B8C]) & 1;\n\tv154 = v153 == 0;\nL_FFFFFFFF:\n\tv341 = v221;\n\tif (v154) goto L_00B8;\nL_FFFFFFFF:\n\tv251 = current.y;\nL_FFFFFFFF:\n\tv341 = v119;\nL_FFFFFFFF:\n\tv269 = v119.y;\nL_FFFFFFFF:\n\tv270 = v119.z;\n\tgoto L_00BA;\nL_0084:\n\tv167 = time / duration;\n\tv169 = v167 < 1f;\n\tv170 = v167 == 1f;\n\tv173 = v167 == v167;\n\tv174 = 1f == 1f;\n\tv175 = v173 & v174;\n\tv176 = ~v175;\n\tv177 = v169 == v176;\n\tv178 = ~v170;\n\tv179 = v177 & v178;\n\tv180 = ~v179;\n\tif (v180) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv292 = 1f;\n\tgoto L_0097;\nL_FFFFFFFF:\n\tv292 = v167;\nL_FFFFFFFF:\n\tv376 = 0;\n\tgoto L_00A4;\nL_FFFFFFFF:\n\tv376 = v292;\nL_00B8:\n\t*([B193B8C]) = 1;\nL_FFFFFFFF:\n\tv251 = current.y;\nL_FFFFFFFF:\n\tv266 = v215;\n\tv297 = v266 < 0;\n\tv301 = v266 == v266;\n\tv302 = ~v301;\n\tv303 = v297 == v302;\n\tv304 = ~v303;\n\tif (v304) goto L_00E7;\n\tv316 = v266 * v266;\n\tv329 = v284 == v316;\n\tv368 = v284 < v316;\n\tv338 = ~v368;\n\tv370 = ~v338;\n\tv311 = v370 | v329;\n\tif (v311) goto L_0106;\nL_00E7:\n\tgoto L_00EA;\nL_005C:\n\tv291 = *([B193B8C]) & 1;\n\tv198 = v291 == 0;\nL_FFFFFFFF:\n\tv215 = v266;\nL_FFFFFFFF:\n\tv341 = v119;\nL_FFFFFFFF:\n\tv269 = v145;\nL_FFFFFFFF:\n\tv270 = v146;\n\tif (v198) goto L_00B8;\nL_00BA:\n\tv276 = v341 - current;\n\tv277 = v269 - v251;\n\tv278 = v270 - current.z;\n\tv279 = v276 * v276;\n\tv280 = v277 * v277;\n\tv281 = v279 + v280;\n\tv282 = v278 * v278;\n\tv284 = v282 + v281;\n\tv286 = v284 == 0;\n\tif (v286) goto L_0106;\nL_0097:\n\tv207 = v167 < 0;\n\tv189 = ~v207;\n\tif (v189) goto L_FFFFFFFF;\nL_00A4:\n\tv377 = target - current;\n\tv378 = v377 * v376;\n\tv221 = current + v378;\n\tv379 = target.y - v251;\n\tv380 = v379 * v376;\n\tv269 = v251 + v380;\n\tv230 = target.z - current.z;\n\tv194 = v230 * v376;\n\tv270 = current.z + v194;\nL_FFFFFFFF:\n\tv266 = v215;\nL_FFFFFFFF:\n\tv341 = v221;\n\tgoto L_00BA;\nL_0106:\n\treturn v341;\nL_00EA:\n\tv385 = UnityEngine.Mathf::Sqrt(v284);\n\tv386 = v276 / v385;\n\tv387 = v266 * v386;\n\tv342 = current + v387;\nL_FFFFFFFF:\n\tv341 = v342;\n")]
		private Vector3 GetAttractedPosition(Vector3 current, Vector3 target, float duration, float time)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleAttractor::GetAttractedPosition");
			return default;
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x3F2802C", Offset = "0x3F2802C", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv61 = v55.Count == 0;\n\tif (v61) goto L_004E;\n\tv188 = this._uiParticles;\n\tv271 = v188.Count == 0;\n\tif (v271) goto L_0052;\nL_004E:\n\treturn;\nL_0052:\n\tv327 = System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::get_Capacity(v188);\n\tv335 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Capacity(this.m_ParticleSystems);\n\tv97 = v327 >= v335;\n\tif (v97) goto L_0074;\n\tv191 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Capacity(this.m_ParticleSystems);\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::set_Capacity(this._uiParticles, v191);\nL_0074:\n\tv269 = this.m_ParticleSystems;\nL_FFFFFFFF:\n\tv234 = 0;\n\tgoto L_0099;\nL_0099:\n\tv99 = v234 >= v269.Count;\n\tif (v99) goto L_004E;\n\tv371 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::get_Item(v269, v234);\n\tgoto L_00A6;\nL_00A6:\n\tv377 = UnityEngine.Object::op_Equality(v371, 0);\n\tv379 = ~v377;\n\tif (v379) goto L_00D8;\n\tv194 = this._uiParticles;\n\tgoto L_00C4;\nL_00C4:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::Add(v194, 0);\n\tv234 = v234 + 1;\n\tv269 = this.m_ParticleSystems;\n\tv397 = this.m_ParticleSystems == 0;\n\tv211 = ~v397;\n\tif (v211) goto L_0099;\n\tgoto L_011F;\nL_00D8:\n\tv197 = UnityEngine.Component::GetComponentInParent(v371, 1);\n\tv184 = this._uiParticles;\n\tv199 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::Contains(v197.particles, v371);\n\tv134 = v199 == 0;\n\tv95 = ~v134;\n\tv63 = ~v95;\n\tif (v63) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv157 = v197;\n\tgoto L_00F7;\nL_FFFFFFFF:\n\tv157 = 0;\nL_00F7:\n\t;\n\tgoto L_0119;\nL_0119:\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::Add(v184, v157);\n\tv234 = v234 + 1;\n\tv269 = this.m_ParticleSystems;\n\tv411 = this.m_ParticleSystems == 0;\n\tv202 = ~v411;\n\tif (v202) goto L_0099;\nL_011F:\n\tthrow System.NullReferenceException;\nL_0035:\n\tv55 = this.m_ParticleSystems;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollectUIParticlesIfNeeded()
		{
			List<ParticleSystem> list = m_ParticleSystems;
			if (list.Count == 0)
			{
				return;
			}
			List<UIParticle> uiParticles = _uiParticles;
			if (uiParticles.Count != 0)
			{
				return;
			}
			int capacity = uiParticles.Capacity;
			int capacity2 = m_ParticleSystems.Capacity;
			if (capacity < capacity2)
			{
				int capacity3 = m_ParticleSystems.Capacity;
				_uiParticles.Capacity = capacity3;
			}
			List<ParticleSystem> list2 = m_ParticleSystems;
			int num = 0;
			while (true)
			{
				if (num >= list2.Count)
				{
					return;
				}
				UnityEngine.Object obj = list2[num];
				if (obj == null)
				{
					List<UIParticle> uiParticles2 = _uiParticles;
					uiParticles2.Add(null);
					num++;
					list2 = m_ParticleSystems;
					if (m_ParticleSystems == null)
					{
						break;
					}
					continue;
				}
				UIParticle componentInParent = ((Component)obj).GetComponentInParent<UIParticle>(true);
				List<UIParticle> uiParticles3 = _uiParticles;
				UIParticle item = ((!componentInParent.particles.Contains((ParticleSystem)obj)) ? null : componentInParent);
				uiParticles3.Add(item);
				num++;
				list2 = m_ParticleSystems;
				if (m_ParticleSystems == null)
				{
					break;
				}
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x3F28870", Offset = "0x3F28870", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCoffee.UIExtensions.UIParticleAttractor::UpgradeIfNeeded(this);\n\treturn;\n")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			UpgradeIfNeeded();
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x3F28874", Offset = "0x3F28874", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x3F27648", Offset = "0x3F27648", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv84 = this + 0x20;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Inequality(this.m_ParticleSystem, 0);\n\tv69 = ~v59;\n\tif (v69) goto L_0072;\n\tv108 = System.Collections.Generic.List`1<UnityEngine.ParticleSystem>::Contains(this.m_ParticleSystems, *([v84 @ X19_v7]));\n\tv184 = v108 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0077;\n\tv116 = this.m_ParticleSystems;\n\tgoto L_0076;\nL_0072:\n\treturn;\nL_0076:\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::Add(v116, this.m_ParticleSystem);\nL_0077:\n\t*([v84 @ X19_v7]) = 0;\n\tgoto L_008E;\nL_008E:\n\tUnityEngine.Debug::Log(\"Upgraded!\");\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpgradeIfNeeded()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIParticleAttractor::UpgradeIfNeeded");
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x3F28878", Offset = "0x3F28878", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tthis.destinationRadius = 1f;\n\tthis.maxSpeed = 1f;\n\tv73 = new System.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>();\n\tSystem.Collections.Generic.List`1<Coffee.UIExtensions.UIParticle>::.ctor(v73);\n\tthis._uiParticles = v73;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<UnityEngine.ParticleSystem>();\n\tSystem.Collections.Generic.List`1<UnityEngine.ParticleSystem>::.ctor(v56);\n\tthis.m_ParticleSystems = v56;\n")]
		public UIParticleAttractor()
		{
			List<ParticleSystem> list = new List<ParticleSystem>();
			m_ParticleSystems = list;
			m_DestinationRadius = 1f;
			maxSpeed = 1f;
			List<UIParticle> uiParticles = new List<UIParticle>();
			_uiParticles = uiParticles;
		}
	}
}

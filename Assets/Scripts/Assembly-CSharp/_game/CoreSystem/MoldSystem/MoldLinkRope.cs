using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.MoldSystem
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteAlways]
	[Token(Token = "0x20004A0")]
	public class MoldLinkRope : MonoBehaviour
	{
		[Token(Token = "0x4000F4D")]
		[FieldOffset(Offset = "0x20")]
		private Transform _endpointA;

		[Token(Token = "0x4000F4E")]
		[FieldOffset(Offset = "0x28")]
		private Transform _endpointB;

		[Token(Token = "0x4000F4F")]
		[FieldOffset(Offset = "0x30")]
		private float _sag;

		[Token(Token = "0x4000F50")]
		[FieldOffset(Offset = "0x34")]
		private float _radius;

		[Token(Token = "0x4000F51")]
		[FieldOffset(Offset = "0x38")]
		private int _segments;

		[Token(Token = "0x4000F52")]
		[FieldOffset(Offset = "0x3C")]
		private int _radialSegments;

		[Token(Token = "0x4000F53")]
		[FieldOffset(Offset = "0x40")]
		private Mesh _mesh;

		[Token(Token = "0x4000F54")]
		[FieldOffset(Offset = "0x48")]
		private MeshFilter _meshFilter;

		[Token(Token = "0x4000F55")]
		[FieldOffset(Offset = "0x50")]
		private MeshRenderer _meshRenderer;

		[Token(Token = "0x4000F56")]
		[FieldOffset(Offset = "0x58")]
		private Vector3 _lastPosA;

		[Token(Token = "0x4000F57")]
		[FieldOffset(Offset = "0x64")]
		private Vector3 _lastPosB;

		[Token(Token = "0x170001AD")]
		public float Sag
		{
			[Token(Token = "0x6001331")]
			[Address(RVA = "0x3CE6E80", Offset = "0x3CE6E80", Length = "0x8")]
			get
			{
				return _sag;
			}
			[Token(Token = "0x6001332")]
			[Address(RVA = "0x3CE6E88", Offset = "0x3CE6E88", Length = "0x8")]
			set
			{
				_sag = value;
				ForceRebuild();
			}
		}

		[Token(Token = "0x6001333")]
		[Address(RVA = "0x3CE6FC4", Offset = "0x3CE6FC4", Length = "0x1AC")]
		public void Initialize(Transform endpointA, Transform endpointB, Material material, float sag = 0.3f, float radius = 0.02f, int segments = 16, int radialSegments = 8)
		{
			Transform endpointA2 = default(Transform);
			_endpointA = endpointA2;
			_endpointB = endpointB;
			_sag = sag;
			_radius = radius;
			int num = segments - 2;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = segments ^ 2;
			int num3 = segments ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int segments2 = ((!(flag4 && flag5)) ? 2 : segments);
			int num5 = radialSegments - 3;
			bool flag6 = num5 < 0;
			bool flag7 = num5 == 0;
			int num6 = radialSegments ^ 3;
			int num7 = radialSegments ^ num5;
			int num8 = num6 & num7;
			bool flag8 = num8 < 0;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			int radialSegments2 = ((!(flag9 && flag10)) ? 3 : radialSegments);
			_segments = segments2;
			_radialSegments = radialSegments2;
			MeshFilter component = GetComponent<MeshFilter>();
			_meshFilter = component;
			MeshRenderer component2 = GetComponent<MeshRenderer>();
			_meshRenderer = component2;
			Mesh mesh = new Mesh();
			mesh.name = "LinkRope";
			_mesh = mesh;
			_meshFilter.sharedMesh = _mesh;
			_meshRenderer.sharedMaterial = material;
			ForceRebuild();
		}

		[ExecuteAlways]
		[Token(Token = "0x6001334")]
		[Address(RVA = "0x3CE7170", Offset = "0x3CE7170", Length = "0x1CC")]
		private void LateUpdate()
		{
			if (_endpointA == null || _endpointB == null)
			{
				return;
			}
			Vector3 position = _endpointA.position;
			Vector3 position2 = _endpointB.position;
			float num = position.x - _lastPosA.x;
			float num2 = position.y - _lastPosA.y;
			float num3 = position.z - _lastPosA.z;
			float num4 = num * num;
			float num5 = num2 * num2;
			float num6 = num4 + num5;
			float num7 = num3 * num3;
			float num8 = num7 + num6;
			if (num8 < 9.9999994E-11f)
			{
				float num9 = position2.x - _lastPosB.x;
				float num10 = position2.y - _lastPosB.y;
				float num11 = position2.z - _lastPosB.z;
				float num12 = num9 * num9;
				float num13 = num10 * num10;
				float num14 = num12 + num13;
				float num15 = num11 * num11;
				float num16 = num15 + num14;
				if (num16 < 9.9999994E-11f)
				{
					return;
				}
			}
			_lastPosA.x = position.x;
			_lastPosA.y = position.y;
			_lastPosA.z = position.z;
			_lastPosB.x = position2.x;
			_lastPosB.y = position2.y;
			_lastPosB.z = position2.z;
			RebuildMesh(position, position2);
		}

		[Token(Token = "0x6001335")]
		[Address(RVA = "0x3CE6E90", Offset = "0x3CE6E90", Length = "0x134")]
		public void ForceRebuild()
		{
			if (!(_endpointA == null) && !(_endpointB == null))
			{
				Vector3 position = _endpointA.position;
				_lastPosA.x = position.x;
				_lastPosA.y = position.y;
				_lastPosA.z = position.z;
				Vector3 position2 = _endpointB.position;
				_lastPosB.x = position2.x;
				_lastPosB.y = position2.y;
				_lastPosB.z = position2.z;
				Vector3 worldA = default(Vector3);
				worldA.x = _lastPosA.x;
				worldA.y = _lastPosA.y;
				worldA.z = _lastPosA.z;
				RebuildMesh(worldA, position2);
			}
		}

		[Token(Token = "0x6001336")]
		[Address(RVA = "0x3CE7CA8", Offset = "0x3CE7CA8", Length = "0xE4")]
		public Sequence Disappear()
		{
			Sequence sequence = Sequence.Create();
			Sequence sequence2 = sequence;
			Transform target = base.transform;
			Vector3 endValue = default(Vector3);
			endValue.x = Vector3.zero.x;
			endValue.y = Vector3.zero.y;
			endValue.z = Vector3.zero.z;
			Tween tween = Tween.Scale(target, endValue, 0.3f, Ease.InBack);
			return sequence2.Chain(tween);
		}

		[Token(Token = "0x6001337")]
		[Address(RVA = "0x3CE733C", Offset = "0x3CE733C", Length = "0x96C")]
		private void RebuildMesh(Vector3 worldA, Vector3 worldB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkRope::RebuildMesh");
		}

		[Token(Token = "0x6001338")]
		[Address(RVA = "0x3CE7D8C", Offset = "0x3CE7D8C", Length = "0xF8")]
		private Vector3 CatenaryPoint(Vector3 a, Vector3 b, float t)
		{
			float num = Sag * 4f;
			float num2 = num * t;
			float num3 = 1f - t;
			float num4 = num3 * num2;
			bool flag = t < 1f;
			bool flag2 = t == 1f;
			bool flag3 = t == t;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num5 = ((!(flag7 && flag8)) ? t : 1f);
			if (t < 0f)
			{
				num5 = 0f;
			}
			float num6 = b.x - a.x;
			float num7 = num6 * num5;
			float num8 = a.x + num7;
			float num9 = num4 * Vector3.down.x;
			float x = num8 + num9;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x6001339")]
		[Address(RVA = "0x3CE7E84", Offset = "0x3CE7E84", Length = "0x25C")]
		private Vector3 CatenaryTangent(Vector3 a, Vector3 b, float t)
		{
			float num = t + -0.01f;
			float num2 = ((!(num < 0f)) ? num : 0f);
			float num3 = t + 0.01f;
			bool flag = num3 < 1f;
			bool flag2 = num3 == 1f;
			bool flag3 = num3 == num3;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num4 = ((!(flag7 && flag8)) ? num3 : 1f);
			float num5 = Sag * 4f;
			float num6 = num4 * num5;
			float num7 = 1f - num4;
			float num8 = num7 * num6;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num9 = vector.z - vector2.z;
			float num10 = ((!(num4 < 0f)) ? num4 : 0f);
			float num11 = num9 * num10;
			float num12 = vector2.z + num11;
			float num13 = vector.x - vector2.x;
			object obj = default(object);
			float num14 = num13 * (float)obj;
			float num15 = vector2.x + num14;
			object obj2 = default(object);
			float num16 = Vector3.down.x * (float)obj2;
			float num17 = num8 * Vector3.down.z;
			float num18 = num15 + num16;
			float num19 = num12 + num17;
			float num20 = Sag * 4f;
			float num21 = num2 * num20;
			float num22 = 1f - num2;
			float num23 = num22 * num21;
			bool flag9 = num2 < 1f;
			bool flag10 = num2 == 1f;
			bool flag11 = num2 == num2;
			bool flag12 = 1f == 1f;
			bool flag13 = flag11 && flag12;
			bool flag14 = !flag13;
			bool flag15 = flag9 == flag14;
			bool flag16 = !flag10;
			float num24 = ((!(flag15 && flag16)) ? num2 : 1f);
			float num25 = num9 * num24;
			float num26 = vector2.z + num25;
			float num27 = num23 * Vector3.down.z;
			object obj3 = default(object);
			float num28 = num13 * (float)obj3;
			float num29 = vector2.x + num28;
			float num30 = Vector3.down.x * (float)obj2;
			float num31 = num29 + num30;
			float num32 = num26 + num27;
			float num33 = num18 - num31;
			float num34 = num19 - num32;
			float num35 = num33 * num33;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FADDP not yet implemented.\"");
			float num36 = num34 * num34;
			float f = num36 + num35;
			float num37 = Mathf.Sqrt(f);
			bool flag17 = num37 < 1E-05f;
			bool flag18 = num37 == 1E-05f;
			bool flag19 = num37 == num37;
			bool flag20 = !flag19;
			bool flag21 = flag17 == flag20;
			bool flag22 = !flag21;
			if (!(flag22 || flag18))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				float x = num33 / 1E-05f;
				Vector3 result = default(Vector3);
				result.x = x;
				return result;
			}
			return Vector3.zero;
		}

		[Token(Token = "0x600133A")]
		[Address(RVA = "0x3CE80E0", Offset = "0x3CE80E0", Length = "0x148")]
		private void OnDestroy()
		{
			if (_mesh != null)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(_mesh);
				}
				else
				{
					Object.DestroyImmediate(_mesh);
				}
			}
		}

		[Token(Token = "0x600133B")]
		[Address(RVA = "0x3CE8228", Offset = "0x3CE8228", Length = "0x1C")]
		public MoldLinkRope()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkRope::.ctor");
		}
	}
}

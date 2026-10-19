using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace _game.CoreGameKit.UiControllers
{
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x2000019")]
	public class DistancableUiObject : MonoBehaviour
	{
		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x20")]
		private Camera _cam;

		[SerializeField]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x28")]
		private bool m_showDistancer;

		[SerializeField]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x30")]
		internal DistancerUiObject m_distancer;

		[SerializeField]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x38")]
		private float m_distancerOffset;

		[FormerlySerializedAs("planeDistance")]
		[SerializeField]
		[Range(-1f, 0.95f)]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x3C")]
		private float m_cameraDistance;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x40")]
		private Canvas _canvas;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x48")]
		private Vector3 _initialLocalPos;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x54")]
		private Vector3 _initialLocalScale;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x60")]
		private Transform _parent;

		[Token(Token = "0x17000005")]
		public float CameraDistance
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0x81A5824", Offset = "0x81A5824", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CameraDistance;\n")]
			get
			{
				return m_cameraDistance;
			}
			[Token(Token = "0x6000094")]
			[Address(RVA = "0x81A582C", Offset = "0x81A582C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = value < 0x3F733333;\n\tv5 = value == 0x3F733333;\n\tv8 = value == value;\n\tv11 = ~v8;\n\tv12 = v3 == v11;\n\tv13 = ~v5;\n\tv14 = v12 & v13;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv18 = 0x3F733333;\n\tgoto L_0015;\nL_FFFFFFFF:\n\tv18 = value;\nL_FFFFFFFF:\n\tv31 = -1f;\n\tgoto L_0023;\nL_FFFFFFFF:\n\tv31 = v18;\nL_0015:\n\tv20 = value < -1f;\n\tv28 = ~v20;\n\tif (v28) goto L_FFFFFFFF;\nL_0023:\n\tthis.CameraDistance = v31;\n\treturn;\n")]
			set
			{
				bool flag = value < 0.95f;
				bool flag2 = value == 0.95f;
				bool flag3 = value == value;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				float num = ((!(flag5 && flag6)) ? value : 0.95f);
				float cameraDistance = ((!(value < -1f)) ? num : (-1f));
				m_cameraDistance = cameraDistance;
			}
		}

		[Token(Token = "0x17000006")]
		public DistancerUiObject Distancer
		{
			[Token(Token = "0x6000095")]
			[Address(RVA = "0x81A5854", Offset = "0x81A5854", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Distancer;\n")]
			get
			{
				return m_distancer;
			}
			[Token(Token = "0x6000096")]
			[Address(RVA = "0x81A585C", Offset = "0x81A585C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Distancer = value;\n\treturn;\n")]
			set
			{
				m_distancer = value;
			}
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x81A5864", Offset = "0x81A5864", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = UnityEngine.Canvas::get_worldCamera(this._canvas);\n\tthis._cam = v41;\n\tv60 = UnityEngine.Component::get_transform(this);\n\tv113 = UnityEngine.Transform::get_parent(v60);\n\tthis._parent = v113;\n\tv61 = UnityEngine.Component::get_transform(this);\n\tv52 = UnityEngine.Transform::get_position(v61);\n\tv53 = UnityEngine.Transform::InverseTransformPoint(this._parent, v52);\n\tthis._initialLocalPos.x = v53;\n\tthis._initialLocalPos.y = v53.y;\n\tthis._initialLocalPos.z = v53.z;\n\tv62 = UnityEngine.Component::get_transform(this);\n\tv91 = UnityEngine.Transform::get_localScale(v62);\n\tthis._initialLocalScale.x = v91;\n\tthis._initialLocalScale.y = v91.y;\n\tthis._initialLocalScale.z = v91.z;\n\tgoto L_0053;\nL_0053:\n\tv130 = UnityEngine.Object::op_Inequality(this.Distancer, 0);\n\tv134 = ~v130;\n\tv135 = ~v134;\n\tif (v135) goto L_006A;\n\t_game.CoreGameKit.UiControllers.DistancableUiObject::Update(this);\n\treturn;\nL_006A:\n\t_game.CoreGameKit.UiControllers.DistancableUiObject::Bind(this, this.Distancer);\n\t_game.CoreGameKit.UiControllers.DistancableUiObject::Update(this);\n\treturn;\n")]
		private void Start()
		{
			Camera worldCamera = _canvas.worldCamera;
			_cam = worldCamera;
			Transform transform = base.transform;
			Transform parent = transform.parent;
			_parent = parent;
			Transform transform2 = base.transform;
			Vector3 position = transform2.position;
			Vector3 vector = _parent.InverseTransformPoint(position);
			_initialLocalPos.x = vector.x;
			_initialLocalPos.y = vector.y;
			_initialLocalPos.z = vector.z;
			Transform transform3 = base.transform;
			Vector3 localScale = transform3.localScale;
			_initialLocalScale.x = localScale.x;
			_initialLocalScale.y = localScale.y;
			_initialLocalScale.z = localScale.z;
			if (!(Distancer != null))
			{
				Update();
				return;
			}
			Bind(Distancer);
			Update();
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x81A5BD0", Offset = "0x81A5BD0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = UnityEngine.Component::get_transform(this._cam);\n\tv94 = UnityEngine.Transform::get_position(v24);\n\tv175 = UnityEngine.Transform::InverseTransformPoint(this._parent, v94);\n\tv65 = this.CameraDistance < 0;\n\tv45 = ~v65;\n\tif (v45) goto L_FFFFFFFF;\n\tv181 = this._initialLocalPos - v175;\n\tv182 = this._initialLocalPos.z - v175.z;\n\tv183 = v181 + v181;\n\tv184 = v182 + v182;\n\tv185 = v175 + v183;\n\tv77 = v175.z + v184;\nL_FFFFFFFF:\n\tv42 = v185;\n\tgoto L_0037;\nL_FFFFFFFF:\n\tv42 = v175;\nL_FFFFFFFF:\n\tv77 = v175.z;\n\tv191 = v77 - this._initialLocalPos.z;\n\tv199 = UnityEngine.Mathf::Abs(this.CameraDistance);\n\tv66 = v199 < 1f;\n\tv62 = v199 == 1f;\n\tv195 = v199 == v199;\n\tv39 = 1f == 1f;\n\tv54 = v195 & v39;\n\tv50 = ~v54;\n\tv196 = v66 == v50;\n\tv36 = ~v62;\n\tv46 = v196 & v36;\n\tv33 = ~v46;\n\tif (v33) goto L_0050;\nL_FFFFFFFF:\n\tv199 = 1f;\n\tgoto L_0050;\n\tUnityEngine.Transform::set_position(v190, v96);\n\tv113 = UnityEngine.Component::get_transform(this);\n\tv133 = 1f - this.CameraDistance;\n\tv158 = v133 * this._initialLocalScale.z;\n\tv160 = v133 * this._initialLocalScale.y;\n\tv162 = v133 * this._initialLocalScale;\n\t// 122 MakeStruct v128 @ AGG81A5D04_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v162 @ V0_v13 (System.Single), v160 @ V1_v10 (System.Single), v158 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::set_localScale(v113, v128);\n\treturn;\nL_0037:\n\tv190 = UnityEngine.Component::get_transform(this);\nL_0050:\n\tv200 = v199 * v191;\n\tv201 = this._initialLocalPos.z + v200;\n\tv203 = v42 - this._initialLocalPos;\n\tv204 = v203 * v179;\n\tv205 = this._initialLocalPos + v204;\n\t// 88 MakeStruct v27 @ AGG81A5CA8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v205 @ V0_v10 (System.Single), v179 @ V1.S0, v201 @ V2_v6 (System.Single)\n\tv96 = UnityEngine.Transform::TransformPoint(this._parent, v27);\n")]
		private void Update()
		{
			//IL_00e9: Expected O, but got F4
			//IL_0304: Expected F4, but got O
			Transform transform = _cam.transform;
			Vector3 position = transform.position;
			Vector3 vector = _parent.InverseTransformPoint(position);
			float num6;
			object obj;
			if (CameraDistance < 0f)
			{
				float num = _initialLocalPos.x - vector.x;
				float num2 = _initialLocalPos.z - vector.z;
				float num3 = num + num;
				float num4 = num2 + num2;
				float num5 = vector.x + num3;
				num6 = vector.z + num4;
				obj = num5;
			}
			else
			{
				obj = vector;
				num6 = vector.z;
			}
			Transform transform2 = base.transform;
			float num7 = num6 - _initialLocalPos.z;
			float num8 = Mathf.Abs(CameraDistance);
			bool flag = num8 < 1f;
			bool flag2 = num8 == 1f;
			bool flag3 = num8 == num8;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (flag7 && flag8)
			{
				num8 = 1f;
			}
			float num9 = num8 * num7;
			float z = _initialLocalPos.z + num9;
			float num10 = (float)obj - _initialLocalPos.x;
			object obj2 = default(object);
			float num11 = num10 * (float)obj2;
			float x = _initialLocalPos.x + num11;
			Vector3 position2 = default(Vector3);
			position2.x = x;
			position2.y = (float)obj2;
			position2.z = z;
			Vector3 position3 = _parent.TransformPoint(position2);
			transform2.position = position3;
			Transform transform3 = base.transform;
			float num12 = 1f - CameraDistance;
			float z2 = num12 * _initialLocalScale.z;
			float y = num12 * _initialLocalScale.y;
			float x2 = num12 * _initialLocalScale.x;
			Vector3 localScale = default(Vector3);
			localScale.x = x2;
			localScale.y = y;
			localScale.z = z2;
			transform3.localScale = localScale;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x81A59AC", Offset = "0x81A59AC", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tgoto L_003B;\nL_0041:\n\tv174 = 0x220BDA0(v157, v181, v168, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv102 = v174 == v168;\nL_FFFFFFFF:\n\tv168 = v174;\n\tif (v102) goto L_0061;\nL_0050:\n\tv181 = System.Delegate::Remove(v168, v67);\n\tv176 = v181 == 0;\n\tif (v176) goto L_0041;\n\tv246 = *([v181 @ X0_v11 (System.Delegate)]) == System.Action;\n\tif (v246) goto L_0041;\n\tgoto L_009C;\nL_0061:\n\tv134 = this.Distancer;\n\tv137 = new System.Action();\n\tSystem.Action::.ctor(v137, this, Il2CppMethodInfo);\n\tgoto L_0076;\nL_007C:\n\tv312 = 0x220BDA0(v289, v291, v281, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv304 = v312 == v281;\nL_FFFFFFFF:\n\tv281 = v312;\n\tif (v304) goto L_00A1;\nL_008B:\n\tv291 = System.Delegate::Combine(v281, v137);\n\tv293 = v291 == 0;\n\tif (v293) goto L_007C;\n\tv273 = *([v291 @ X0_v26 (System.Delegate)]) == System.Action;\n\tif (v273) goto L_007C;\nL_009C:\n\tthrow System.InvalidCastException;\nL_00A1:\n\tv139 = UnityEngine.Component::get_gameObject(this.Distancer);\n\tv140 = UnityEngine.GameObject::get_activeInHierarchy(v139);\n\tv326 = ~v140;\nL_FFFFFFFF:\n\tv200 = 0;\n\tif (v326) goto L_00E2;\n\tv149 = this.Distancer;\n\tv365 = v149.distance < 0;\n\tv371 = ~v365;\n\tif (v371) goto L_00BE;\n\tv358 = this.m_distancerOffset < 0;\n\tv360 = this.m_distancerOffset == this.m_distancerOffset;\n\tv353 = ~v360;\n\tv345 = v358 == v353;\nL_FFFFFFFF:\n\tv200 = 0;\n\tif (v345) goto L_00E2;\nL_00BE:\n\tv390 = v149.distance + this.m_distancerOffset;\n\tv393 = v390 < 0x3F733333;\n\tv394 = v390 == 0x3F733333;\n\tv397 = v390 == v390;\n\tv400 = ~v397;\n\tv401 = v393 == v400;\n\tv344 = ~v394;\n\tv346 = v401 & v344;\n\tv402 = ~v346;\n\tif (v402) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv350 = 0x3F733333;\n\tgoto L_00D4;\nL_FFFFFFFF:\n\tv350 = v390;\nL_FFFFFFFF:\n\tv200 = -1f;\n\tgoto L_00E2;\nL_FFFFFFFF:\n\tv200 = v350;\nL_0023:\n\tthis.Distancer = v52;\n\tv65 = this.Distancer;\n\tv67 = new System.Action();\n\tSystem.Action::.ctor(v67, this, Il2CppMethodInfo);\nL_003B:\n\tv157 = this.Distancer + 0x20;\nL_FFFFFFFF:\n\tv168 = v65.OnDirty;\n\tgoto L_0050;\nL_0076:\n\tv289 = this.Distancer + 0x20;\nL_FFFFFFFF:\n\tv281 = v134.OnDirty;\n\tgoto L_008B;\nL_00E2:\n\tthis.CameraDistance = v200;\n\treturn;\nL_00D4:\n\tv359 = v390 < -1f;\n\tv343 = ~v359;\n\tif (v343) goto L_FFFFFFFF;\n")]
		public void Bind(DistancerUiObject distancer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DistancableUiObject::Bind");
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x81A5E54", Offset = "0x81A5E54", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Component::get_gameObject(this.Distancer);\n\tv29 = UnityEngine.GameObject::get_activeInHierarchy(v15);\n\tv104 = ~v29;\n\tif (v104) goto L_0029;\n\tv18 = this.Distancer;\n\tv113 = v18.distance < 0;\n\tv119 = ~v113;\n\tif (v119) goto L_0030;\n\tv110 = this.m_distancerOffset < 0;\n\tv107 = this.m_distancerOffset == this.m_distancerOffset;\n\tv106 = ~v107;\n\tv121 = v110 == v106;\n\tv105 = ~v121;\n\tif (v105) goto L_0030;\nL_0029:\n\tthis.CameraDistance = 0f;\n\treturn;\nL_0030:\n\tv128 = v18.distance + this.m_distancerOffset;\n\tv131 = v128 < 0x3F733333;\n\tv132 = v128 == 0x3F733333;\n\tv135 = v128 == v128;\n\tv138 = ~v135;\n\tv139 = v131 == v138;\n\tv49 = ~v132;\n\tv61 = v139 & v49;\n\tv140 = ~v61;\n\tif (v140) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv88 = 0x3F733333;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv88 = v128;\nL_FFFFFFFF:\n\tv93 = -1f;\n\tgoto L_0054;\nL_FFFFFFFF:\n\tv93 = v88;\nL_0046:\n\tv81 = v128 < -1f;\n\tv46 = ~v81;\n\tif (v46) goto L_FFFFFFFF;\nL_0054:\n\tthis.CameraDistance = v93;\n\treturn;\n")]
		private void OnDirty()
		{
			//IL_00f1: Expected I4, but got F4
			GameObject gameObject = Distancer.gameObject;
			if (gameObject.activeInHierarchy)
			{
				DistancerUiObject distancer = Distancer;
				if (distancer.distance < 0f)
				{
					bool flag = m_distancerOffset < 0f;
					bool flag2 = m_distancerOffset == m_distancerOffset;
					bool flag3 = !flag2;
					if (flag == flag3)
					{
						goto IL_00d1;
					}
				}
				int num = (int)(distancer.distance + m_distancerOffset);
				bool flag4 = num < 1064514355;
				bool flag5 = num == 1064514355;
				bool flag6 = num == num;
				bool flag7 = !flag6;
				bool flag8 = flag4 == flag7;
				bool flag9 = !flag5;
				int num2 = ((!(flag8 && flag9)) ? num : 1064514355);
				float cameraDistance = ((!((float)num < -1f)) ? ((float)num2) : (-1f));
				m_cameraDistance = cameraDistance;
				return;
			}
			goto IL_00d1;
			IL_00d1:
			m_cameraDistance = 0f;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x81A5EF0", Offset = "0x81A5EF0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_distancerOffset = 0.1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DistancableUiObject()
		{
			m_distancerOffset = 0.1f;
		}
	}
}

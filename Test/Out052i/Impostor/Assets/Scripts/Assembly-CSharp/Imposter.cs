using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Spine;
using Spine.Unity;
using UnityEngine;

[Token(Token = "0x200002B")]
public class Imposter : MonoBehaviour
{
	[SerializeField]
	[Token(Token = "0x40000AE")]
	[FieldOffset(Offset = "0x20")]
	public SkeletonAnimation _animation;

	[Token(Token = "0x40000AF")]
	[FieldOffset(Offset = "0x28")]
	public int id;

	[SerializeField]
	[Token(Token = "0x40000B0")]
	[FieldOffset(Offset = "0x30")]
	private readonly string[] skinList;

	[SerializeField]
	[Token(Token = "0x40000B1")]
	[FieldOffset(Offset = "0x38")]
	internal Vector3 toptarget;

	[Token(Token = "0x40000B2")]
	[FieldOffset(Offset = "0x48")]
	private Sequence _sequence;

	[Token(Token = "0x1700001A")]
	public Vector3 Toptarget
	{
		[Token(Token = "0x6000126")]
		[Address(RVA = "0xC01E60", Offset = "0xC01E60", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.toptarget;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return toptarget;
		}
		[Token(Token = "0x6000127")]
		[Address(RVA = "0xC01E6C", Offset = "0xC01E6C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.toptarget = value;\n\tthis.toptarget.y = value.y;\n\tthis.toptarget.z = value.z;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			toptarget = value;
			toptarget.y = value.y;
			toptarget.z = value.z;
		}
	}

	[Token(Token = "0x6000128")]
	[Address(RVA = "0xBFBE48", Offset = "0xBFBE48", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = id;\n\tv13 = Spine.Unity.SkeletonRenderer::get_Skeleton(this._animation);\n\tv46 = this.skinList;\n\tSpine.Skeleton::SetSkin(v13, v46[id @ X1 (System.Int32)]);\n\treturn;\n\tv53 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetUp(int id, bool isStand)
	{
		this.id = id;
		Skeleton skeleton = _animation.Skeleton;
		string[] array = skinList;
		skeleton.SetSkin(array[id]);
	}

	[Token(Token = "0x6000129")]
	[Address(RVA = "0xC0043C", Offset = "0xC0043C", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, startTime, fixTime, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35629]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v25, v26, v27, v28, v29, v30, startTime, fixTime, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = DG.Tweening.DOTween::Sequence();\n\tthis._sequence = v48;\n\tv52 = UnityEngine.Component::get_transform(this);\n\t// 40 MakeStruct v59 @ AGGC044B8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.toptarget (UnityEngine.Vector3), this.toptarget.y (System.Single), this.toptarget.z (System.Single)\n\tv60 = DG.Tweening.ShortcutExtensions::DOMove(v52, v59, fixTime, 0);\n\tv64 = DG.Tweening.TweenSettingsExtensions::Append(v48, v60);\n\tDG.Tweening.TweenExtensions::Restart(this._sequence, 1, -1f);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void MoveToTop(float startTime, float fixTime = 0.25f)
	{
		Sequence s = (_sequence = DOTween.Sequence());
		Transform target = base.transform;
		Vector3 endValue = default(Vector3);
		endValue.x = toptarget.x;
		endValue.y = toptarget.y;
		endValue.z = toptarget.z;
		TweenerCore<Vector3, Vector3, VectorOptions> t = target.DOMove(endValue, fixTime);
		Sequence sequence = s.Append(t);
		_sequence.Restart();
	}

	[Token(Token = "0x600012A")]
	[Address(RVA = "0xBFCCE0", Offset = "0xBFCCE0", Length = "0x128")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, startTime, fixTime, v32, v33, v34, v35, v36, v37);\n\tv47 = \"Fall\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, startTime, fixTime, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3562A]) = v41;\nL_001C:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, startTime, fixTime, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv51 = DG.Tweening.DOTween::Sequence();\n\tthis._sequence = v51;\n\tv55 = UnityEngine.Component::get_transform(this);\n\tv59 = UnityEngine.Component::get_gameObject(this);\n\tv62 = UnityEngine.GameObject::get_transform(v59);\n\tv81 = UnityEngine.Transform::get_parent(v62);\n\tv82 = UnityEngine.Component::get_transform(v81);\n\tv123 = UnityEngine.Transform::get_position(v82);\n\tv127 = DG.Tweening.ShortcutExtensions::DOMove(v55, v123, fixTime, 0);\n\tv131 = DG.Tweening.TweenSettingsExtensions::Append(v51, v127);\n\tDG.Tweening.TweenExtensions::Restart(this._sequence, 1, -1f);\n\tv92 = this._animation;\n\tv110 = Spine.AnimationState::SetAnimation(v92.state, 0, \"Fall\", 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void BackIntoPosition(float startTime, float fixTime = 0.25f)
	{
		Sequence s = (_sequence = DOTween.Sequence());
		Transform target = base.transform;
		GameObject gameObject = base.gameObject;
		Transform transform = gameObject.transform;
		Transform parent = transform.parent;
		Transform transform2 = parent.transform;
		Vector3 position = transform2.position;
		TweenerCore<Vector3, Vector3, VectorOptions> t = target.DOMove(position, fixTime);
		Sequence sequence = s.Append(t);
		_sequence.Restart();
		SkeletonAnimation animation = _animation;
		TrackEntry trackEntry = animation.state.SetAnimation(0, "Fall", loop: false);
	}

	[Token(Token = "0x600012B")]
	[Address(RVA = "0xBFC310", Offset = "0xBFC310", Length = "0x258")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv58 = DG.Tweening.DOTween;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v61, v62, v63, v64, v65, v66, startTime, target1, v0, v2, target2, v3, v5, fixTime);\n\tv74 = DG.Tweening.TweenCallback;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v61, v62, v63, v64, v65, v66, startTime, target1, v0, v2, target2, v3, v5, fixTime);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v61, v62, v63, v64, v65, v66, startTime, target1, v0, v2, target2, v3, v5, fixTime);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v61, v62, v63, v64, v65, v66, startTime, target1, v0, v2, target2, v3, v5, fixTime);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, methodInfo, v61, v62, v63, v64, v65, v66, startTime, target1, v0, v2, target2, v3, v5, fixTime);\n\tv108 = Imposter+<>c__DisplayClass11_0;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v108, methodInfo, v61, v62, v63, v64, v65, v66, startTime, target1, v0, v2, target2, v3, v5, fixTime);\n\tv70 = 1;\n\t*([1A3562B]) = v70;\nL_003B:\n\tv72 = new Imposter+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v72);\n\tv72.<>4__this = this;\n\tv72.target1 = target1;\n\tv72.target1.y = target1.y;\n\tv72.target1.z = target1.z;\n\tgoto L_0056;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v87, v76, v61, v62, v63, v64, v65, v66, startTime, target1, v0, v2, target2, v3, v5, fixTime);\nL_0056:\n\tv106 = DG.Tweening.DOTween::Sequence();\n\tthis._sequence = v106;\n\tv112 = UnityEngine.Component::get_transform(this);\n\t// 98 MakeStruct v121 @ AGGC00444_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.toptarget (UnityEngine.Vector3), this.toptarget.y (System.Single), this.toptarget.z (System.Single)\n\tv176 = DG.Tweening.ShortcutExtensions::DOMove(v112, v121, startTime, 0);\n\tv180 = DG.Tweening.TweenSettingsExtensions::Append(v106, v176);\n\tv184 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v184, v72, Il2CppMethodInfo);\n\tv192 = DG.Tweening.TweenSettingsExtensions::AppendCallback(v180, v184);\n\tv196 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v196, v72, Il2CppMethodInfo);\n\tv204 = DG.Tweening.TweenSettingsExtensions::AppendCallback(v192, v196);\n\tv208 = UnityEngine.Component::get_transform(this);\n\tv212 = DG.Tweening.ShortcutExtensions::DOMove(v208, target2, fixTime, 0);\n\tv216 = DG.Tweening.TweenSettingsExtensions::Append(v204, v212);\n\tv219 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v219, v72, Il2CppMethodInfo);\n\tv226 = DG.Tweening.TweenSettingsExtensions::AppendCallback(v216, v219);\n\tDG.Tweening.TweenExtensions::Restart(this._sequence, 1, -1f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void MoveToTarget(float startTime, Vector3 target1, Vector3 target2, float fixTime = 0.25f)
	{
		Vector3 target3 = target1;
		target3.y = target1.y;
		target3.z = target1.z;
		Sequence s = (_sequence = DOTween.Sequence());
		Transform target4 = base.transform;
		Vector3 endValue = default(Vector3);
		endValue.x = toptarget.x;
		endValue.y = toptarget.y;
		endValue.z = toptarget.z;
		TweenerCore<Vector3, Vector3, VectorOptions> t = target4.DOMove(endValue, startTime);
		Sequence s2 = s.Append(t);
		TweenCallback callback = delegate
		{
			Transform transform = base.transform;
			Vector3 position = default(Vector3);
			position.x = target3.x;
			position.y = target3.y;
			position.z = target3.z;
			transform.position = position;
		};
		Sequence s3 = s2.AppendCallback(callback);
		TweenCallback callback2 = delegate
		{
			Imposter imposter = this;
			SkeletonAnimation animation = imposter._animation;
			TrackEntry trackEntry = animation.state.SetAnimation(0, "Fall", loop: false);
		};
		Sequence s4 = s3.AppendCallback(callback2);
		Transform target5 = base.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = target5.DOMove(target2, fixTime);
		Sequence s5 = s4.Append(t2);
		TweenCallback callback3 = delegate
		{
			Imposter imposter = this;
			SkeletonAnimation animation = imposter._animation;
			TrackEntry trackEntry = animation.state.SetAnimation(0, "Idle", loop: false);
		};
		Sequence sequence = s5.AppendCallback(callback3);
		_sequence.Restart();
	}

	[Token(Token = "0x600012C")]
	[Address(RVA = "0xC01E80", Offset = "0xC01E80", Length = "0x1CC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv18 = System.String[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = \"White\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = \"Brown\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv87 = \"Yellow\";\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv178 = \"Red\";\n\tv179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v178, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv210 = \"Purple\";\n\tv211 = \"il2cpp_codegen_initialize_runtime_metadata\"(v210, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv216 = \"Black\";\n\tv217 = \"il2cpp_codegen_initialize_runtime_metadata\"(v216, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv223 = \"Orange\";\n\tv224 = \"il2cpp_codegen_initialize_runtime_metadata\"(v223, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv229 = \"Blue\";\n\tv230 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv236 = \"Green\";\n\tv237 = \"il2cpp_codegen_initialize_runtime_metadata\"(v236, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv242 = \"Pink\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v242, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3562C]) = v38;\nL_0033:\n\t// 51 NewArr v41 @ X0_v3 (System.String[]), typeof(System.String[]), 10\n\tv41[0] = \"Yellow\";\n\tv41[1] = \"Blue\";\n\tv41[2] = \"Green\";\n\tv41[3] = \"Orange\";\n\tv41[4] = \"Pink\";\n\tv41[5] = \"Purple\";\n\tv41[6] = \"Red\";\n\tv41[7] = \"White\";\n\tv41[8] = \"Black\";\n\tv41[9] = \"Brown\";\n\tthis.skinList = v41;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\tv82 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Imposter()
	{
		skinList = new string[10] { "Yellow", "Blue", "Green", "Orange", "Pink", "Purple", "Red", "White", "Black", "Brown" };
	}
}

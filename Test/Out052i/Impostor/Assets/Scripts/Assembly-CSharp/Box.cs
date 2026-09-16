using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Lean.Pool;
using Spine;
using Spine.Unity;
using UnityEngine;

[Token(Token = "0x2000021")]
public class Box : MonoBehaviour
{
	[SerializeField]
	[Token(Token = "0x400006E")]
	[FieldOffset(Offset = "0x20")]
	private int id;

	[SerializeField]
	[Token(Token = "0x400006F")]
	[FieldOffset(Offset = "0x28")]
	private SpriteRenderer sprite;

	[SerializeField]
	[Token(Token = "0x4000070")]
	[FieldOffset(Offset = "0x30")]
	private List<GameObject> targets;

	[SerializeField]
	[Token(Token = "0x4000071")]
	[FieldOffset(Offset = "0x38")]
	private Imposter _imposter;

	[SerializeField]
	[Token(Token = "0x4000072")]
	[FieldOffset(Offset = "0x40")]
	private Stack<Imposter> imposterStack;

	[SerializeField]
	[Token(Token = "0x4000073")]
	[FieldOffset(Offset = "0x48")]
	private Transform topBox;

	[SerializeField]
	[Token(Token = "0x4000074")]
	[FieldOffset(Offset = "0x50")]
	private ParticleSystem ps;

	[SerializeField]
	[Token(Token = "0x4000075")]
	[FieldOffset(Offset = "0x58")]
	public GameObject effect;

	[SerializeField]
	[Token(Token = "0x4000076")]
	[FieldOffset(Offset = "0x60")]
	public UnityEngine.Animation wrongEffect;

	[Token(Token = "0x4000077")]
	[FieldOffset(Offset = "0x68")]
	private GamePlayController gpc;

	[Token(Token = "0x17000015")]
	public int Id
	{
		[Token(Token = "0x60000BA")]
		[Address(RVA = "0xBFBB18", Offset = "0xBFBB18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Id;
		}
		[Token(Token = "0x60000BB")]
		[Address(RVA = "0xBFBB20", Offset = "0xBFBB20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = value;\n\treturn;\n")]
		set
		{
			Id = value;
		}
	}

	[Token(Token = "0x17000016")]
	public Transform TopBox
	{
		[Token(Token = "0x60000BC")]
		[Address(RVA = "0xBFBB28", Offset = "0xBFBB28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.topBox;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return TopBox;
		}
		[Token(Token = "0x60000BD")]
		[Address(RVA = "0xBFBB30", Offset = "0xBFBB30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.topBox = value;\n\treturn;\n")]
		set
		{
			TopBox = value;
		}
	}

	[Token(Token = "0x17000017")]
	public List<GameObject> Targets
	{
		[Token(Token = "0x60000BE")]
		[Address(RVA = "0xBFBB38", Offset = "0xBFBB38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.targets;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Targets;
		}
		[Token(Token = "0x60000BF")]
		[Address(RVA = "0xBFBB40", Offset = "0xBFBB40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.targets = value;\n\treturn;\n")]
		set
		{
			Targets = value;
		}
	}

	[Token(Token = "0x17000018")]
	public Stack<Imposter> Imposters
	{
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0xBFBB48", Offset = "0xBFBB48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.imposterStack;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Imposters;
		}
		[Token(Token = "0x60000C1")]
		[Address(RVA = "0xBFBB50", Offset = "0xBFBB50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.imposterStack = value;\n\treturn;\n")]
		set
		{
			Imposters = value;
		}
	}

	[Token(Token = "0x60000B9")]
	[Address(RVA = "0xBFBABC", Offset = "0xBFBABC", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = GameController;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355ED]) = v37;\nL_0015:\n\tv40 = v39.Ins;\n\tthis.gpc = v40.gamePlayController;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		GameController ins = GameController.Ins;
		gpc = ins.gamePlayController;
	}

	[Token(Token = "0x60000C2")]
	[Address(RVA = "0xBFBB58", Offset = "0xBFBB58", Length = "0x2F0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv80 = Lean.Pool.LeanPool;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv265 = Il2CppMethodInfo;\n\tv266 = \"il2cpp_codegen_initialize_runtime_metadata\"(v265, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv347 = Il2CppMethodInfo;\n\tv348 = \"il2cpp_codegen_initialize_runtime_metadata\"(v347, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv397 = Il2CppMethodInfo;\n\tv398 = \"il2cpp_codegen_initialize_runtime_metadata\"(v397, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv400 = System.Collections.Generic.Stack`1<Imposter>;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v400, stack, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv71 = 1;\n\t*([1A355EE]) = v71;\nL_003B:\n\tv73 = new System.Collections.Generic.Stack`1<Imposter>();\n\tSystem.Collections.Generic.Stack`1<Imposter>::.ctor(v73);\n\tthis.imposterStack = v73;\n\tv97 = stack._size < 1;\n\tif (v97) goto L_0102;\nL_0060:\n\tv228 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(this.targets, v258);\n\tv229 = UnityEngine.GameObject::get_transform(v228);\n\tv402 = UnityEngine.Transform::get_position(v229);\n\tgoto L_0082;\n\tv408 = v262;\n\tv409 = \"il2cpp_codegen_initialize_runtime_metadata\"(v408, v401, v175, v115, v56, v57, v58, v59, v402, v403, v404, v143, v140, v137, v134, v67);\n\tv412 = 1;\n\t*([1A3551A]) = v412;\nL_0082:\n\tgoto L_0092;\n\tv420 = \"il2cpp_codegen_runtime_class_init\"(v417, v401, v175, v115, v56, v57, v58, v59, v402, v403, v404, v143, v140, v137, v134, v67);\nL_0092:\n\tv230 = Lean.Pool.LeanPool::Spawn(this._imposter, v402, v416.identityQuaternion, 0);\n\tv424 = UnityEngine.Component::get_transform(v230);\n\tgoto L_00AB;\n\tv428 = v260;\n\tv429 = \"il2cpp_codegen_initialize_runtime_metadata\"(v428, v225, v176, v115, v56, v57, v58, v59, v166, v161, v156, v144, v141, v138, v135, v67);\n\tv430 = 1;\n\t*([1A35519]) = v430;\nL_00AB:\n\tUnityEngine.Transform::set_position(v424, v253.zeroVector);\n\tv231 = UnityEngine.Component::get_gameObject(v230);\n\tv232 = UnityEngine.GameObject::get_transform(v231);\n\tv233 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(this.targets, v258);\n\tv234 = UnityEngine.GameObject::get_transform(v233);\n\tUnityEngine.Transform::SetParent(v232, v234, 0);\n\tv443 = System.Linq.Enumerable::ElementAt(stack, v258);\n\tImposter::SetUp(v230, v443, 0);\n\tv168 = UnityEngine.Transform::get_position(this.topBox);\n\tv230.toptarget = v168;\n\tv230.toptarget.y = v168.y;\n\tv230.toptarget.z = v168.z;\n\tSystem.Collections.Generic.Stack`1<Imposter>::Push(this.imposterStack, v230);\n\tv258 = v258 + 1;\n\tv300 = v258 < stack._size;\n\tif (v300) goto L_0060;\nL_0102:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetUp(Stack<int> stack)
	{
		Stack<Imposter> imposters = new Stack<Imposter>();
		Imposters = imposters;
		if (stack.Count >= 1)
		{
			int num = 0;
			do
			{
				GameObject gameObject = Targets[num];
				Transform transform = gameObject.transform;
				Vector3 position = transform.position;
				Imposter imposter = LeanPool.Spawn(_imposter, position, Quaternion.identity);
				Transform transform2 = imposter.transform;
				transform2.position = Vector3.zero;
				GameObject gameObject2 = imposter.gameObject;
				Transform transform3 = gameObject2.transform;
				GameObject gameObject3 = Targets[num];
				Transform parent = gameObject3.transform;
				transform3.SetParent(parent, worldPositionStays: false);
				int num2 = stack.ElementAt(num);
				imposter.SetUp(num2, isStand: false);
				Vector3 vector = (imposter.toptarget = TopBox.position);
				imposter.toptarget.y = vector.y;
				imposter.toptarget.z = vector.z;
				Imposters.Push(imposter);
				num++;
			}
			while (num < stack.Count);
		}
	}

	[Token(Token = "0x60000C3")]
	[Address(RVA = "0xBFBEA4", Offset = "0xBFBEA4", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.gpc;\n\tv10 = v2.isPeeking == 0;\n\treturn v10;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private bool canPeeking()
	{
		GamePlayController gamePlayController = gpc;
		return !gamePlayController.IsPeeking;
	}

	[Token(Token = "0x60000C4")]
	[Address(RVA = "0xBFBEC8", Offset = "0xBFBEC8", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A355EF]) = v33;\nL_0010:\n\tv34 = this.imposterStack;\n\tv43 = v34._size == 0;\n\treturn v43;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private bool isEmptyBox()
	{
		Stack<Imposter> imposters = Imposters;
		return imposters.Count == 0;
	}

	[Token(Token = "0x60000C5")]
	[Address(RVA = "0xBFBF18", Offset = "0xBFBF18", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Animation::Play(this.wrongEffect);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void TurnOnEffectWrong()
	{
		bool flag = wrongEffect.Play();
	}

	[Token(Token = "0x60000C6")]
	[Address(RVA = "0xBFBF34", Offset = "0xBFBF34", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.effect, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void TurnOnEffectRight()
	{
		effect.SetActive(value: true);
	}

	[Token(Token = "0x60000C7")]
	[Address(RVA = "0xBFBF54", Offset = "0xBFBF54", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.effect, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void TurnOffEffectRight()
	{
		effect.SetActive(value: false);
	}

	[Token(Token = "0x60000C8")]
	[Address(RVA = "0xBFBF74", Offset = "0xBFBF74", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv84 = \"Pick Acion_test\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A355F0]) = v36;\nL_001F:\n\tv44 = this.gpc;\n\tv46 = System.Collections.Generic.Stack`1<Imposter>::Peek(this.imposterStack);\n\tv44.selectedImposter = v46;\n\tv74 = this.gpc;\n\tv60 = v74.selectedImposter;\n\tv74.currentBox = this;\n\tv74.isPeeking = 1;\n\tv75 = v60._animation;\n\tv106 = Spine.AnimationState::SetAnimation(v75.state, 0, \"Pick Acion_test\", 0);\n\tBox::TurnOnEffectRight(this);\n\tgoto L_0048;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v108, v62, v52, v50, v48, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0048:\n\tv65 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::PlayClickBoxSound(v65);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void chooseItem()
	{
		GamePlayController gamePlayController = gpc;
		Imposter selectedImposter = Imposters.Peek();
		gamePlayController.selectedImposter = selectedImposter;
		GamePlayController gamePlayController2 = gpc;
		Imposter selectedImposter2 = gamePlayController2.selectedImposter;
		gamePlayController2.currentBox = this;
		gamePlayController2.isPeeking = true;
		SkeletonAnimation animation = selectedImposter2._animation;
		TrackEntry trackEntry = animation.state.SetAnimation(0, "Pick Acion_test", loop: false);
		TurnOnEffectRight();
		GUIManager instance = SingletonMonoDontDestroy<GUIManager>.Instance;
		instance.PlayClickBoxSound();
	}

	[Token(Token = "0x60000C9")]
	[Address(RVA = "0xBFC0AC", Offset = "0xBFC0AC", Length = "0x264")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, currentBox, targetBox, imposter, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, currentBox, targetBox, imposter, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv185 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, currentBox, targetBox, imposter, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv188 = Il2CppMethodInfo;\n\tv189 = \"il2cpp_codegen_initialize_runtime_metadata\"(v188, currentBox, targetBox, imposter, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv224 = Il2CppMethodInfo;\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, currentBox, targetBox, imposter, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv227 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, currentBox, targetBox, imposter, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A355F1]) = v45;\nL_0025:\n\tv46 = this.gpc;\n\tv51 = v46.selectedBox;\n\tSystem.Collections.Generic.Stack`1<Imposter>::Push(v51.imposterStack, v46.selectedImposter);\n\tv168 = this.gpc;\n\tv118 = UnityEngine.Component::get_transform(targetBox.topBox);\n\tv88 = UnityEngine.Transform::get_position(v118);\n\tv169 = this.gpc;\n\tv170 = v169.selectedBox;\n\tv171 = v170.imposterStack;\n\tv101 = v171._size - 1;\n\tv120 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(targetBox.targets, v101);\n\tv121 = UnityEngine.GameObject::get_transform(v120);\n\tv89 = UnityEngine.Transform::get_position(v121);\n\tImposter::MoveToTarget(v168.selectedImposter, 0.25f, v88, v89, 0.25f);\n\tv173 = this.gpc;\n\tv124 = UnityEngine.Component::get_transform(v173.selectedImposter);\n\tv174 = this.gpc;\n\tv175 = v174.selectedBox;\n\tv112 = v175.imposterStack;\n\tv105 = v112._size - 1;\n\tv126 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v175.targets, v105);\n\tv127 = UnityEngine.GameObject::get_transform(v126);\n\tUnityEngine.Transform::SetParent(v124, v127);\n\tv177 = this.gpc;\n\tv178 = v177.currentBox;\n\tv130 = System.Collections.Generic.Stack`1<Imposter>::Pop(v178.imposterStack);\n\tv179 = this.gpc;\n\tv113 = v179.selectedBox;\n\tv163 = v179.selectedImposter;\n\tv91 = UnityEngine.Transform::get_position(v113.topBox);\n\tv163.toptarget = v91;\n\tv163.toptarget.y = v91.y;\n\tv163.toptarget.z = v91.z;\n\tgoto L_00BF;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v234, v109, v96, imposter, methodInfo, v31, v32, v33, v91, v86, v81, v60, v68, v66, v64, v62);\nL_00BF:\n\tv132 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::PlayFallingSound(v132);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void moveItem(Box currentBox, Box targetBox, Imposter imposter)
	{
		GamePlayController gamePlayController = gpc;
		Box selectedBox = gamePlayController.selectedBox;
		selectedBox.Imposters.Push(gamePlayController.selectedImposter);
		GamePlayController gamePlayController2 = gpc;
		Transform transform = targetBox.TopBox.transform;
		Vector3 position = transform.position;
		GamePlayController gamePlayController3 = gpc;
		Box selectedBox2 = gamePlayController3.selectedBox;
		Stack<Imposter> imposters = selectedBox2.Imposters;
		int index = imposters.Count - 1;
		GameObject gameObject = targetBox.Targets[index];
		Transform transform2 = gameObject.transform;
		Vector3 position2 = transform2.position;
		gamePlayController2.selectedImposter.MoveToTarget(0.25f, position, position2);
		GamePlayController gamePlayController4 = gpc;
		Transform transform3 = gamePlayController4.selectedImposter.transform;
		GamePlayController gamePlayController5 = gpc;
		Box selectedBox3 = gamePlayController5.selectedBox;
		Stack<Imposter> imposters2 = selectedBox3.Imposters;
		int index2 = imposters2.Count - 1;
		GameObject gameObject2 = selectedBox3.Targets[index2];
		Transform parent = gameObject2.transform;
		transform3.SetParent(parent);
		GamePlayController gamePlayController6 = gpc;
		Box currentBox2 = gamePlayController6.currentBox;
		Imposter imposter2 = currentBox2.Imposters.Pop();
		GamePlayController gamePlayController7 = gpc;
		Box selectedBox4 = gamePlayController7.selectedBox;
		Imposter selectedImposter = gamePlayController7.selectedImposter;
		Vector3 vector = (selectedImposter.toptarget = selectedBox4.TopBox.position);
		selectedImposter.toptarget.y = vector.y;
		selectedImposter.toptarget.z = vector.z;
		GUIManager instance = SingletonMonoDontDestroy<GUIManager>.Instance;
		instance.PlayFallingSound();
	}

	[Token(Token = "0x60000CA")]
	[Address(RVA = "0xBFC5A0", Offset = "0xBFC5A0", Length = "0x428")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv24 = GameController;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv48 = UnityEngine.Object;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv147 = Il2CppMethodInfo;\n\tv148 = \"il2cpp_codegen_initialize_runtime_metadata\"(v147, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv212 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv213 = \"il2cpp_codegen_initialize_runtime_metadata\"(v212, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv216 = SingletonMonoDontDestroy`1<GameManager>;\n\tv217 = \"il2cpp_codegen_initialize_runtime_metadata\"(v216, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv317 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v317, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A355F2]) = v44;\nL_0028:\n\tv46 = Box::isDoneBox(this);\n\tv51 = v46 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_016F;\n\tgoto L_0038;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0038:\n\tv153 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tv122 = UnityEngine.GameObject::get_activeSelf(v153.menuPanel);\n\tv319 = v122 == 0;\n\tv127 = ~v319;\n\tif (v127) goto L_016F;\n\tgoto L_004B;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v320, v114, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tv243 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tv123 = UnityEngine.GameObject::get_activeSelf(v243.winningCanvasPanel);\n\tv327 = v123 == 0;\n\tv128 = ~v327;\n\tif (v128) goto L_016F;\n\tgoto L_0062;\n\tv332 = \"il2cpp_codegen_runtime_class_init\"(v329, v115, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0062:\n\tv245 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv337 = v245.currentLevel == 0;\n\tif (v337) goto L_0093;\nL_0068:\n\tv298 = this.gpc;\n\tv343 = ~v298.isPeeking;\n\tif (v343) goto L_00E0;\n\tBox::TurnOffEffectRight(v298.currentBox);\n\tv248 = this.gpc;\n\tv248.selectedBox = this;\n\tv249 = GamePlayController::isCancelHandle(v248);\n\tv388 = v249 == 0;\n\tif (v388) goto L_00F5;\n\tv299 = this.gpc;\n\tImposter::BackIntoPosition(v299.selectedImposter, v33, 0.25f);\n\tgoto L_0089;\n\tv408 = \"il2cpp_codegen_runtime_class_init\"(v402, v234, v221, v28, v29, v30, v31, v32, v33, v226, v35, v36, v37, v38, v39, v40);\nL_0089:\n\tv251 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::PlayWrongPick(v251);\n\tv412 = UnityEngine.Animation::Play(this.wrongEffect);\n\tgoto L_00FF;\nL_0093:\n\tv301 = this.imposterStack;\n\tv69 = v301._size != 3;\n\tif (v69) goto L_00C1;\n\tv302 = v351.Ins;\n\tv133 = v302.gamePlayController;\n\tgoto L_00B8;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v365, v115, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00B8:\n\tv124 = UnityEngine.Object::op_Equality(v133.currentBox, 0);\n\tv391 = v124 == 0;\n\tv129 = ~v391;\n\tif (v129) goto L_016F;\nL_00C1:\n\tv303 = v356.Ins;\n\tv304 = v303.gamePlayController;\n\tgoto L_00D3;\n\tv384 = \"il2cpp_codegen_runtime_class_init\"(v370, v235, v222, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00D3:\n\tv254 = UnityEngine.Object::op_Equality(v304.currentBox, 0);\n\tv341 = v254 == 0;\n\tif (v341) goto L_0171;\n\tGameController::SetHandToSelectedBox(v393.Ins);\n\tgoto L_0068;\nL_00E0:\n\tv347 = Box::isEmptyBox(this);\n\tv358 = v347 == 0;\n\tif (v358) goto L_0108;\n\tgoto L_00EB;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v359, v234, v221, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00EB:\n\tv255 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::PlayWrongPick(v255);\n\tv378 = UnityEngine.Animation::Play(this.wrongEffect);\n\tgoto L_010A;\nL_00F5:\n\tv307 = this.gpc;\n\tBox::moveItem(this, v241, v307.selectedBox, v28);\n\tGamePlayController::SaveLastMove(this.gpc);\nL_00FF:\n\tv308 = this.gpc;\n\tv308.isPeeking = 0;\n\tv308.selectedBox = 0;\n\tv308.selectedImposter = 0;\n\tv308.currentBox = 0;\n\tgoto L_010A;\nL_0108:\n\tBox::chooseItem(this);\nL_010A:\n\tv125 = Box::isDoneBox(this);\n\tv130 = v125 == 0;\n\tif (v130) goto L_016F;\n\tgoto L_0115;\n\tv399 = \"il2cpp_codegen_runtime_class_init\"(v394, v117, v66, v28, v29, v30, v31, v32, v33, v104, v35, v36, v37, v38, v39, v40);\nL_0115:\n\tv259 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv406 = v259.currentLevel == 0;\n\tv407 = ~v406;\n\tif (v407) goto L_0147;\n\tv310 = v417.Ins;\n\tv261 = UnityEngine.GameObject::get_transform(v310.tutorialHand);\n\tv262 = UnityEngine.Transform::get_parent(v261);\n\tv428 = UnityEngine.Component::get_gameObject(v262);\n\tgoto L_013C;\n\tv435 = v432;\n\tv436 = \"il2cpp_codegen_runtime_class_init\"(v435, v427, v66, v28, v29, v30, v31, v32, v33, v104, v35, v36, v37, v38, v39, v40);\nL_013C:\n\tUnityEngine.Object::Destroy(v428);\n\tv311 = v439.Ins;\n\tv311.isTutorialLevel = 0;\nL_0147:\n\tgoto L_014A;\n\tv424 = \"il2cpp_codegen_runtime_class_init\"(v421, v241, v66, v28, v29, v30, v31, v32, v33, v104, v35, v36, v37, v38, v39, v40);\nL_014A:\n\tv264 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::Vibrating(v264);\n\tUnityEngine.ParticleSystem::Play(this.ps);\n\tv266 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::PlaySolveSound(v266);\n\tGamePlayController::Winning(this.gpc);\n\treturn;\nL_016F:\n\treturn;\nL_0171:\n\tGameController::SetHandToCurrentBox(v393.Ins);\n\tgoto L_0068;\n\tthrow System.NullReferenceException;\n\treturn;\n// 244 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseDown()
	{
		if (isDoneBox())
		{
			return;
		}
		GUIManager instance = SingletonMonoDontDestroy<GUIManager>.Instance;
		if (instance.menuPanel.activeSelf)
		{
			return;
		}
		GUIManager instance2 = SingletonMonoDontDestroy<GUIManager>.Instance;
		if (instance2.winningCanvasPanel.activeSelf)
		{
			return;
		}
		GameManager instance3 = SingletonMonoDontDestroy<GameManager>.Instance;
		bool flag = instance3.currentLevel == 0;
		Box currentBox = null;
		if (flag)
		{
			Stack<Imposter> imposters = Imposters;
			if (imposters.Count == 3)
			{
				GameController ins = GameController.Ins;
				GamePlayController gamePlayController = ins.gamePlayController;
				if (gamePlayController.currentBox == null)
				{
					return;
				}
			}
			GameController ins2 = GameController.Ins;
			GamePlayController gamePlayController2 = ins2.gamePlayController;
			if (gamePlayController2.currentBox == null)
			{
				GameController.Ins.SetHandToSelectedBox();
				currentBox = null;
			}
			else
			{
				GameController.Ins.SetHandToCurrentBox();
				currentBox = null;
			}
		}
		GamePlayController gamePlayController3 = gpc;
		if (gamePlayController3.IsPeeking)
		{
			gamePlayController3.currentBox.TurnOffEffectRight();
			GamePlayController gamePlayController4 = gpc;
			gamePlayController4.selectedBox = this;
			if (gamePlayController4.isCancelHandle())
			{
				GamePlayController gamePlayController5 = gpc;
				float startTime = default(float);
				gamePlayController5.selectedImposter.BackIntoPosition(startTime);
				GUIManager instance4 = SingletonMonoDontDestroy<GUIManager>.Instance;
				instance4.PlayWrongPick();
				bool flag2 = wrongEffect.Play();
				currentBox = null;
			}
			else
			{
				GamePlayController gamePlayController6 = gpc;
				Imposter imposter = default(Imposter);
				moveItem(currentBox, gamePlayController6.selectedBox, imposter);
				gpc.SaveLastMove();
			}
			GamePlayController gamePlayController7 = gpc;
			gamePlayController7.isPeeking = false;
			gamePlayController7.selectedBox = null;
			gamePlayController7.selectedImposter = null;
			gamePlayController7.currentBox = null;
		}
		else if (isEmptyBox())
		{
			GUIManager instance5 = SingletonMonoDontDestroy<GUIManager>.Instance;
			instance5.PlayWrongPick();
			bool flag3 = wrongEffect.Play();
			currentBox = null;
		}
		else
		{
			chooseItem();
		}
		if (isDoneBox())
		{
			GameManager instance6 = SingletonMonoDontDestroy<GameManager>.Instance;
			if (instance6.currentLevel == 0)
			{
				GameController ins3 = GameController.Ins;
				Transform transform = ins3.tutorialHand.transform;
				Transform parent = transform.parent;
				GameObject obj = parent.gameObject;
				UnityEngine.Object.Destroy(obj);
				GameController ins4 = GameController.Ins;
				ins4.isTutorialLevel = false;
				currentBox = null;
			}
			GUIManager instance7 = SingletonMonoDontDestroy<GUIManager>.Instance;
			instance7.Vibrating();
			ps.Play();
			GUIManager instance8 = SingletonMonoDontDestroy<GUIManager>.Instance;
			instance8.PlaySolveSound();
			gpc.Winning();
		}
	}

	[Token(Token = "0x60000CB")]
	[Address(RVA = "0xBFC9C8", Offset = "0xBFC9C8", Length = "0x1D4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv108 = Il2CppMethodInfo;\n\tv109 = \"il2cpp_codegen_initialize_runtime_metadata\"(v108, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv113 = Il2CppMethodInfo;\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv129 = Il2CppMethodInfo;\n\tv130 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv173 = Il2CppMethodInfo;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v173, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A355F3]) = v36;\nL_0020:\n\tv37 = 0;\n\tv40 = this.imposterStack;\n\tv41 = this.imposterStack == 0;\n\tif (v41) goto L_007C;\n\tv45 = this.gpc;\n\tv46 = this.gpc == 0;\n\tif (v46) goto L_007C;\n\tv53 = v40._size != v45.maxValueCols;\n\tif (v53) goto L_FFFFFFFF;\n\tv92 = System.Collections.Generic.Stack`1<Imposter>::Peek(this.imposterStack);\n\tv96 = v92 == 0;\n\tif (v96) goto L_007C;\n\tv97 = this.imposterStack == 0;\n\tif (v97) goto L_007C;\n\tv215 = System.Collections.Generic.Stack`1<Imposter>::GetEnumerator(this.imposterStack);\nL_004C:\n\tv242 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::MoveNext(&v37 @ stack_-38_v1 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv246 = v242 == 0;\n\tif (v246) goto L_FFFFFFFF;\n\tv237 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::get_Current(&v37 @ stack_-38_v1 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv232 = *([v237 @ X0_v32+28]) == v92.id;\n\tif (v232) goto L_004C;\n\tgoto L_0069;\n\tgoto L_007A;\nL_0069:\n\tSystem.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\nL_006C:\n\tv150 = v160 - 5;\n\tv146 = v150 == 0;\n\tv136 = ~v146;\nL_007A:\n\treturn returnVal1;\n\tv91 = new System.NullReferenceException();\nL_007C:\n\tv106 = new System.NullReferenceException();\n\tgoto L_0089;\n\tgoto L_0089;\nL_0089:\n\tv127 = v49 != 1;\n\tif (v127) goto L_FFFFFFFF;\n\tv170 = System.Collections.Generic.Stack`1<Imposter>+Enumerator<Imposter>::get_Current(v106);\n\tv197 = *([v170 @ X0_v15 (Imposter)]);\n\tv199 = System.Collections.Generic.Stack`1<Imposter>+Enumerator<Imposter>::get_Current(v170);\n\tSystem.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv221 = *([v170 @ X0_v15 (Imposter)]) == 0;\n\tv205 = ~v221;\n\tif (v205) goto L_009C;\n\tgoto L_006C;\n\tgoto L_00A2;\nL_009C:\n\tv203 = new System.OutOfMemoryException();\nL_00A2:\n\tSystem.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv218 = v197 == 0;\n\tv191 = ~v218;\n\tif (v191) goto L_00A9;\n\tv223 = System.Collections.Generic.Stack`1<Imposter>+Enumerator<Imposter>::Dispose(v193);\nL_00A9:\n\tv226 = new System.OutOfMemoryException();\n\treturnVal2 = System.Collections.Generic.Stack`1<Imposter>+Enumerator<Imposter>::Dispose(v226);\n\treturn returnVal2;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe bool isDoneBox()
	{
		//IL_0205: Expected I, but got O
		//IL_01a7: Expected I, but got O
		Stack<object>.Enumerator enumerator = default(Stack<object>.Enumerator);
		Stack<Imposter> imposters = Imposters;
		bool flag = Imposters == null;
		nint num = 0;
		int num2;
		if (!flag)
		{
			GamePlayController gamePlayController = gpc;
			bool flag2 = (object)gpc == null;
			num = 0;
			if (!flag2)
			{
				if (imposters.Count != gamePlayController.maxValueCols)
				{
					return false;
				}
				Imposter imposter = Imposters.Peek();
				bool flag3 = (object)imposter == null;
				IntPtr intPtr = default(IntPtr);
				num = intPtr;
				if (!flag3)
				{
					bool flag4 = Imposters == null;
					num = 0;
					if (!flag4)
					{
						Stack<Imposter>.Enumerator enumerator2 = Imposters.GetEnumerator();
						while (true)
						{
							if (enumerator.MoveNext())
							{
								object current = enumerator.Current;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X0_v32+28]");
								if ((nint)0 != imposter.id)
								{
									num2 = 5;
									break;
								}
								continue;
							}
							num2 = 6;
							break;
						}
						enumerator.Dispose();
						goto IL_012f;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		nint num3;
		NullReferenceException ex3;
		if (num == 1)
		{
			Imposter current2 = ((Stack<Imposter>.Enumerator*)ex)->Current;
			num3 = (nint)current2;
			Imposter current3 = ((Stack<Imposter>.Enumerator*)current2)->Current;
			enumerator.Dispose();
			if ((object)current2 == null)
			{
				num2 = 0;
				goto IL_012f;
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			ex3 = (NullReferenceException)(object)ex2;
		}
		else
		{
			ex3 = ex;
			num3 = unchecked((nint)null);
		}
		enumerator.Dispose();
		if (num3 == 0)
		{
			((Stack<Imposter>.Enumerator*)ex3)->Dispose();
		}
		OutOfMemoryException ex4 = new OutOfMemoryException();
		((Stack<Imposter>.Enumerator*)ex4)->Dispose();
		bool result = default(bool);
		return result;
		IL_012f:
		int num4 = num2 - 5;
		bool flag5 = num4 == 0;
		return !flag5;
	}

	[Token(Token = "0x60000CC")]
	[Address(RVA = "0xBFD250", Offset = "0xBFD250", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Box()
	{
	}
}

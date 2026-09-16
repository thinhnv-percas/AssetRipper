using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Token(Token = "0x2000018")]
public class ActorSpawner : MonoBehaviour
{
	[Token(Token = "0x40000BF")]
	[FieldOffset(Offset = "0x18")]
	public ObiActor template;

	[Token(Token = "0x40000C0")]
	[FieldOffset(Offset = "0x20")]
	public int basePhase;

	[Token(Token = "0x40000C1")]
	[FieldOffset(Offset = "0x24")]
	public int maxInstances;

	[Token(Token = "0x40000C2")]
	[FieldOffset(Offset = "0x28")]
	public float spawnDelay;

	[Token(Token = "0x40000C3")]
	[FieldOffset(Offset = "0x2C")]
	private int phase;

	[Token(Token = "0x40000C4")]
	[FieldOffset(Offset = "0x30")]
	private int instances;

	[Token(Token = "0x40000C5")]
	[FieldOffset(Offset = "0x34")]
	private float timeFromLastSpawn;

	[Token(Token = "0x600009D")]
	[Address(RVA = "0x9FCB0C", Offset = "0x9FCB0C", Length = "0x1FC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1ECDBD8]);\n\tv35 = *([v34 @ X8_v26]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021C3C]) = v54;\nL_001D:\n\tv57 = UnityEngine.Time::get_deltaTime();\n\tv58 = this.timeFromLastSpawn + v57;\n\tthis.timeFromLastSpawn = v58;\n\tv61 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_00B7;\n\tv75 = this.instances >= this.maxInstances;\n\tif (v75) goto L_00B7;\n\tv114 = this.timeFromLastSpawn <= this.spawnDelay;\n\tif (v114) goto L_00B7;\n\tv233 = UnityEngine.Component::get_gameObject(this.template);\n\tv259 = UnityEngine.Component::get_transform(this);\n\tv279 = UnityEngine.Transform::get_position(v259);\n\tgoto L_0061;\n\tv288 = *([v284 @ X0_v15+E0]);\n\tv289 = v288 == 0;\n\tv290 = ~v289;\n\tif (v290) goto L_0061;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v284, v278, v38, v39, v40, v41, v42, v43, v279, v280, v281, v47, v48, v49, v50, v51);\nL_0061:\n\tv296 = UnityEngine.Quaternion::get_identity();\n\tgoto L_0082;\n\tv306 = *([v302 @ X0_v18+E0]);\n\tv307 = v306 == 0;\n\tv308 = ~v307;\n\tif (v308) goto L_0082;\n\tv310 = \"il2cpp_codegen_runtime_class_init\"(v302, v278, v38, v39, v40, v41, v42, v43, v296, v297, v298, v299, v48, v49, v50, v51);\nL_0082:\n\tv260 = UnityEngine.Object::Instantiate(v233, v279, v296);\n\tv317 = UnityEngine.GameObject::get_transform(v260);\n\tv261 = UnityEngine.Component::get_transform(this);\n\tv275 = UnityEngine.Transform::get_parent(v261);\n\tUnityEngine.Transform::SetParent(v317, v275);\n\tv149 = UnityEngine.GameObject::GetComponent(v260);\n\tv144 = this.basePhase + this.phase;\n\tObi.ObiActor::SetPhase(v149, v144);\n\tthis.timeFromLastSpawn = 0f;\n\tv153 = this.phase + 1;\n\tv141 = this.instances + 1;\n\tthis.phase = v153;\n\tthis.instances = v141;\nL_00B7:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		float deltaTime = Time.deltaTime;
		float num = timeFromLastSpawn + deltaTime;
		timeFromLastSpawn = num;
		if (Input.GetMouseButtonDown(0) && instances < maxInstances && timeFromLastSpawn > spawnDelay)
		{
			GameObject original = template.gameObject;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Quaternion identity = Quaternion.identity;
			GameObject gameObject = Object.Instantiate(original, position, identity);
			Transform transform2 = gameObject.transform;
			Transform transform3 = base.transform;
			Transform parent = transform3.parent;
			transform2.SetParent(parent);
			ObiActor component = gameObject.GetComponent<ObiActor>();
			int num2 = basePhase + phase;
			component.SetPhase(num2);
			timeFromLastSpawn = 0f;
			int num3 = phase + 1;
			int num4 = instances + 1;
			phase = num3;
			instances = num4;
		}
	}

	[Token(Token = "0x600009E")]
	[Address(RVA = "0x9FCD08", Offset = "0x9FCD08", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.basePhase = 0x2000000022;\n\tthis.spawnDelay = 0.3f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ActorSpawner()
	{
		basePhase = 34;
		maxInstances = 32;
		spawnDelay = 0.3f;
	}
}

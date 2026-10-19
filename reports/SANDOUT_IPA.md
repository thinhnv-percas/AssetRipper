# SandOut (iOS, Unity 6000.0.72f1) — decompile thử

`com.uncosoft.sandout_0.2.5_und3fined.ipa` (release asset của `thinhnv-funtom/archive`, 164 MB). Fixture iOS thứ hai,
**game Unity 6 đầu tiên** và **binary đầu tiên có `LC_DYLD_CHAINED_FIXUPS`** mà pipeline từng chạy. Log, số đo và lỗi
compile ở `iterations/sandout/`.

## 1. Input

| | |
|---|---|
| Unity | 6000.0.72f1 (`data.unity3d`), metadata v31.1 |
| Binary | `Frameworks/UnityFramework.framework/UnityFramework`, 200 MB, ARM64, `cryptid 0` (đã giải mã; có `SC_Info` nên gốc là bản App Store) |
| Load command | `LC_DYLD_CHAINED_FIXUPS`, `LC_DYLD_EXPORTS_TRIE` — **không có `LC_DYLD_INFO_ONLY`** (JellyBlastV2 thì ngược lại) |
| StructDb | không có 6000.0.72f1, dùng 6000.0.0f1 (đầu và cuối dòng 6000.0 giống nhau ở mọi struct recovery đọc, đo ở 069) |
| Assembly | 237; 89 phục hồi, 100 framework stub. Có Unity.Entities (ECS), Burst, PrimeTween, Spine, Odin, Firebase, AppLovin MAX |

Tải về `Test/Download/sandout/`, giải nén vào `Test/Input/SandOut/` (cả hai trong `.gitignore`).

## 2. Ba lần chạy

| | rip 1 (HEAD) | rip 2 (+ skip theo token) | rip 3 (+ exports trie) |
|---|---:|---:|---:|
| Thời gian | 554 s | 531 s | 533 s |
| generator failures | 0 | 0 | 0 |
| Assembly-CSharp `.cs` | **1426** (bỏ dở) | 1646 | 1641 (5 anonymous type giờ viết inline) |
| runtime helper tìm được | **4 / 35** | 4 / 35 | **30 / 35** |
| EXACT | 18097 (53,6 %) | | **22632 (66,6 %)** |
| PARTIAL | 15006 | | 10268 |
| FALLBACK | 117 | | 220 |
| placeholder | 227634 | | 205594 |
| `METHOD_NOT_FOUND` | 77551 | | 61479 |
| `UNMANAGED_MEMORY_LOAD` | 137150 | | 132788 |

Field layout self-check: 6031/6460 type khớp, **0 mâu thuẫn** — field offset đọc qua chained fixups là đúng, lần đầu
được kiểm trên một binary thật chứ không chỉ binary tổng hợp. Write barrier tìm được với khoảng cách rõ (1769 call site,
kế tiếp 227, 3/5 anchor đồng ý).

## 3. Hai lỗi đã sửa

**ILSpy bỏ dở Assembly-CSharp mà không retry.** `ScriptDecompiler` chỉ đọc lỗi dạng file
(`Error decompiling for 'path.cs'`). Ở đây `LocalFunctionDecompiler` ném trong một method
(`LiveEcsActions.RunWallClosure`, `ArgumentOutOfRangeException` ở `GetClosureInitializer`) và lỗi thoát ra dạng
`Error decompiling @06000ACA <method>`, không nêu file — nên không gì bị skip, vòng retry dừng ngay, 220 file
Assembly-CSharp mất. `DecompilationFailurePaths.FailingMethodTypePaths` tra token trong chính module ILSpy đọc, đi lên
type top-level và skip nó; rip 2 skip đúng một type và có lại 220 file. (Ở rip 3 method đó decompile được — thân của
nó thay đổi khi helper được tìm thấy — nên không cần skip nữa; luật vẫn đúng cho lần sau.) Test:
`DecompilationFailurePathsTests` (3).

**Không đọc export của binary dùng chained fixups.** `MachOFile` chỉ lấy export trie từ `LC_DYLD_INFO(_ONLY)`. Binary
link bằng chained fixups không có lệnh đó; trie (cùng định dạng) nằm ở `LC_DYLD_EXPORTS_TRIE`. Không có export thì mọi
helper tìm theo API `il2cpp_*` đã export đều mất: `object_new`, `array_new`, `class_init`, `box`, `string_new`,
`is_assignable_from`… — 4/35 so với 30 trên mọi fixture khác. Sửa: đọc lệnh đó và parse trie khi không có dyld info.
EXACT +4535. Test: `MachOChainedFixupTests.ExportsAreReadFromTheExportsTrieCommand` (đỏ khi bỏ bản sửa).

## 4. Compile (Assembly-CSharp)

Số "13 lỗi, 0 warning" đầu tiên là **sai**: đó là lỗi parse, và Roslyn không bind gì khi có lỗi parse. Harness
(`compile_recovered_scripts.sh`) giờ có **parse pass**: để riêng các file có lỗi cú pháp, compile phần còn lại, rồi mới
chạy body pass (CS0617) trên kết quả đó. Thứ tự quan trọng: CS0617 là lỗi khai báo, chỉ hiện sau khi parser cho qua.
Năm fixture cũ: số không đổi (không fixture nào có lỗi parse).

| | stub | Editor 6000.0.72f1 thật |
|---|---:|---:|
| lỗi parse (CS1525) | 17 trong 6 file | 17 trong 6 file |
| parse pass | 187 | **83** |
| body pass | 108 | — (không có CS0617 với assembly thật) |

Cả 83 vẫn là **lỗi khai báo**, nên thân hàm vẫn chưa được bind — số lỗi thân thật của game này chưa đo được:

- 47 CS0122 `[Unity.Entities.MonoPInvokeCallback]` — attribute internal của Unity.Entities trên các member
  `__codegen__` mà ILPostProcessor của Entities sinh lúc build. Cùng họ với `__JobReflectionRegistrationOutput__`
  (iteration 063): Unity sẽ sinh lại chúng khi build project, nên xuất ra là xuất hai lần.
- 17 CS0570 `IJobChunk.Execute(in ArchetypeChunk, int, bool, in v128)` — chữ ký Burst/Entities ngôn ngữ không viết được.
- 15 CS0246 `RunStyle` — chính là một trong 6 file lỗi parse đã bị để riêng.
- 3 `SROptions` (event `PropertyChanged`), 1 CS0234.

**Lỗi parse là một lỗi phục hồi thật**, không phải ILSpy: `(float)(ref r) + 6E-45f` là `&r + 4` — địa chỉ của
`Color.g` tính từ `r`, khi chỉ `r` được chép ra local; offset 4 lại mang kiểu float nên in ra `6E-45`.

## 5. Còn lại

- `UNMANAGED_MEMORY_LOAD` 132788 (64 %), lớn hơn hẳn mọi fixture cũ; chưa phân loại theo nguyên nhân. Unity 6 + ECS là
  lãnh thổ mới (Burst, `v128`, struct job lớn).
- 5 helper vẫn không tìm thấy: `initialize_method`, `metadatacache_initializemethodmetadata`, `raise_exception`,
  `object_is_inst` (codegen), `AddrPInvokeLookup`.
- Shader: 2794 sub-program trên 135 shader — 1950 MSL source, 844 Metal library; export ghi 0 program vào pass
  (`shader_programs_recovered 0 of 86`).
- Stage C: 8 reference không resolve (0,9998).
- MiniUnity: §6–7. Không có source nên không có so sánh giá trị (I2).

## 6. MiniUnity: compile như Unity và chạy

Đo bằng `miniunity_gate.py` với Editor 6000.0.72f1. Mỗi tầng chỉ lộ ra khi tầng trước đã qua:

| bước | kết quả |
|---|---|
| Hybrid, như xuất | D2 FAIL: URP 17.0.4 (từ Editor) compile với `Unity.Mathematics` plugin đã bị strip — `int * uint3` không còn |
| + bỏ plugin Mathematics/Burst/Collections, để package | 5 lỗi: `AABB` mơ hồ — `Unity.Mathematics.Extensions` (plugin của Entities) được auto-reference vào package light-transport |
| + plugin không auto-reference | Assembly-CSharp được bind lần đầu theo luật Unity: **16740 lỗi** trong C# phục hồi |
| DLL export (Assembly-CSharp cũng là DLL) | **D2 PASS, 0 lỗi, 36/36 assembly**; 3 scene chạy 300 frame — nhưng không script game nào chạy (MiniUnity không đọc script trong DLL) |
| + MiniUnity đọc script trong DLL | mọi constructor MonoBehaviour: `InvalidProgramException` — **max stack = 0** |
| + max stack | `TypeLoadException: Cpp2ILHelpers … the parent does not exist` |
| + base `System.Object` | 2 "Bad IL format", 1 invalid program (số nguyên ở chỗ cần string), IntroScene và Main **segfault** |

Bốn lỗi của tool, đã sửa, cả bốn vô hình với mọi phép đo tĩnh:

1. **Max stack của mọi thân phục hồi là 0.** `TryBalanceStack` gọi `ComputeMaxStack`, hàm *trả về* độ sâu chứ không gán,
   và generator tắt `ComputeMaxStackOnBuild`. ILSpy không đọc max stack nên không script decompile nào lộ ra; runtime
   (CoreCLR, và Mono của Unity) từ chối method ngay lần chạy đầu. Mọi DLL export có thân phục hồi đều không chạy được.
2. **`Cpp2ILHelpers` và `Il2CppRuntime` được inject không có base type.** Chỉ `System.Object` được phép không có base;
   decompiler in ra như static class bình thường, runtime không load được, và mọi thân có placeholder ném
   `TypeLoadException`.
3. **Plugin chỉ auto-reference khi source trong project compile với nó** (trực tiếp hoặc qua plugin khác). Plugin
   auto-reference được tham chiếu bởi *mọi* assembly, kể cả package, và type của nó va với type của package.
4. **Plugin mà package trong manifest cung cấp bị bỏ** (`PackageProvidedPlugins`): URP kéo theo Mathematics/Burst/
   Collections; plugin cùng tên là bản đã strip.

MiniUnity (bản vá cục bộ, `iterations/sandout/miniunity/miniunity-sandout.diff`): đọc dependency của package built-in từ
`package.json` khi không có lock file (thiếu nunit, shadergraph); nhận MonoBehaviour trong DLL theo `fileID` =
MD4("s\0\0\0" + namespace + name) (đã kiểm với `fileID` thật trong scene); constructor ném thì log và load như
missing script thay vì bỏ cả scene.

Tới đây vẫn chưa chạy được không lỗi; phần còn lại là §7.

## 7. Chạy không lỗi: thân an toàn khi chạy (`--runtime-safe-bodies`)

Ép JIT mọi method (lệnh `jit.check` thêm vào MiniUnity) cho thấy hai segfault không phải ghi qua địa chỉ native như đoán ở
trên mà là **JIT crash trên IL sai kiểu**: `ldarg <struct Optional<float>>; ldc.i4 1; and`. ILSpy đọc IL như vậy thành
một cast và đi tiếp; runtime thì từ chối (`InvalidProgramException`, "Bad IL format") hoặc — JIT release bỏ phần lớn
assert kiểu — chấp nhận rồi sinh mã coi số nguyên là tham chiếu. Không phép đo tĩnh nào thấy chuyện này.

**Công cụ.** `ExportSettings.RuntimeSafeBodies` (SystemTester `--runtime-safe-bodies`), `Scripts/RuntimeSafeBodies.cs`:
mỗi assembly xuất dạng DLL được ILVerify (verifier chuẩn của .NET, gói `Microsoft.ILVerification`) kiểm *từng method*
với chính các assembly đã dùng để phục hồi (mscorlib đã strip của game). Method lỗi — trừ bảy luật chỉ thuộc tập con
verifiable mà runtime không áp (`InitLocals`, `ThisMismatch`, `ThisUninitReturn`, `ThisUninitStore`, `InitOnly`,
`CallCtor`, `LdftnNonFinalVirtual`) — được thay bằng thân tối thiểu (không hiệu ứng, trả default; getter/setter
auto-property vẫn đọc/ghi field). Danh sách đầy đủ kèm lý do: `AuxiliaryFiles/RuntimeSafeBodies.json`. Script decompile
không bị ảnh hưởng. Test: `RuntimeSafeBodiesTests`.

**Ba lỗi generator sửa trên đường đi** (`Source/External/README.md` mục 35), mỗi cái giảm số thân bị thay:

| | thân bị thay | ghi chú |
|---|---:|---|
| prototype ngoài repo | 17059 / 50946 | |
| `call` tới method abstract/interface → `callvirt` | 16696 / 65104 | `CallAbstract` 938 → 0 ("Bad IL format") |
| so tham chiếu với hằng 0 → `ldnull`; cấp phát không ghép được ctor → object chưa khởi tạo | **14841 / 65104** | 841 phép cấp phát trước đây là `null` |

Lỗi còn lại theo mã: `StackUnexpected` 12312, `ExpectedNumericType` 1413, `FieldAccess` 510, `ExpectedIntegerType` 310.
Assembly-CSharp 3290/9958 thân bị thay, Elephant 332/1154, Newtonsoft.Json 989/2323, Unity.Entities 65/3002.

Phép cấp phát: `GameBootstrapper.Initialize` (nguồn: `new GlobalScopeContextInstaller(parent)`) ra
`GlobalScopeContextInstaller x = null; x._parentTransform = ...` — constructor `(Transform parentTransform)` gán
`_parentTransform`, `InlinedConstructor` so tên chính xác nên trượt, và fallback là `ldnull`. Giờ tên khớp theo quy ước
`_x`/`m_x`/`mX`, và khi không constructor nào khớp thì là `FormatterServices.GetUninitializedObject(typeof(T))` — đúng
thứ `object_new` làm, các store theo sau vẫn ở trong thân.

**MiniUnity** (vá cục bộ, `iterations/sandout/miniunity/`): `JetBrains.Annotations` (sinh từ CoreModule của Editor),
`AudioResource` làm base của `AudioClip`, `VideoClip`, `Screen.sleepTimeout`, `InternalsVisibleTo` cho assembly package
mà engine Unity cấp (Input System đọc `NativeInputEvent`), lệnh `jit.check`, và đếm message (`Awake`/`Update`…) theo
assembly trong output `play` — thứ chứng minh script game thực sự chạy.

**Kết quả** (`iterations/sandout/miniunity/gate-runtime-safe-30s.json`, 30 giây = 1800 frame mỗi scene):

| scene | lỗi / warning / exception | script chạy |
|---|---|---|
| `Assets/Elephant/elephant_scene.unity` | 0 / 0 / 0 | Elephant: Awake 2, Start 2, Update 1800, LateUpdate 1800; Adjust, Usercentrics: Awake |
| `Assets/Scenes/IntroScene.unity` | 0 / 0 / 0 | Assembly-CSharp `GameBootstrapper.Awake` chạy hết; UGUI 6 component |
| `Assets/Scenes/Main.unity` | 0 / 0 / 0 | chỉ URP và Splines — không MonoBehaviour nào của game trong scene |

D2 compile như Unity: 0 lỗi, 36/36 assembly.

**Những gì kết quả này không nói.** Không có lỗi không có nghĩa là game chạy đúng: 14841 thân (23%) đã bị thay bằng thân
không làm gì. Gameplay của SandOut nằm trong hệ ECS của Unity.Entities, mà MiniUnity không chạy; MiniUnity cũng không
chuyển scene, nên luồng `IntroScene → Main` của bootstrapper không được thử. Ảnh chụp giây 29 là nền đen (Intro) và nền
màu (Main). Chưa có Unity Editor thật để mở project. Hồi quy trên fixture khác: Impostor (decompile) EXACT 4437 → 4461,
Roslyn 156 = 156, golden corpus và shape check như baseline (DECOMP-0014 nay chấp nhận cả `is RotateTimeline`, vì phép
so null đúng kiểu làm ILSpy viết `x as T == null` thành `!(x is T)`).

## 8. Tái lập

```
curl -sSL -o Test/Download/sandout/sandout.ipa \
  https://github.com/thinhnv-funtom/archive/releases/download/com.uncosoft.sandout/com.uncosoft.sandout_0.2.5_und3fined.ipa
(cd Test/Input/SandOut && unzip -q ../../Download/sandout/sandout.ipa)
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb --output Test/OutSO --log Test/ARSO.log Test/Input/SandOut
UNITY_EDITOR_DATA=<Unity-6000.0.72f1>/Editor/Data bash Test/Scripts/compile_recovered_scripts.sh Test/OutSO Assembly-CSharp
# bản chạy được (DLL, thân an toàn khi chạy) và cổng MiniUnity
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb --script-mode DllExportWithRenaming --runtime-safe-bodies \
  --unity-editor <Unity-6000.0.72f1>/Editor --output Test/OutSOR3 --log Test/ARSOR3.log Test/Input/SandOut
MINIUNITY_HOME=<MiniUnity đã vá> python3 Test/Scripts/miniunity_gate.py Test/OutSOR3/SandOut \
  --unity-editor <Unity-6000.0.72f1>/Editor --seconds 30 --size 1170x2532
```

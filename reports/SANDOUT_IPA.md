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
- MiniUnity chưa chạy (không có scenario và không có source).

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

**Chưa chơi được không lỗi.** Phần còn lại là lỗi phục hồi thật: stand-in sai kiểu (một số nguyên — địa chỉ của chuỗi
chưa giải — truyền vào tham số `string`) và ghi qua địa chỉ native chưa giải (`Unsafe.AsPointer(ref this) + 376`), thứ
làm hỏng bộ nhớ khi code thật sự chạy. Với 10268 method PARTIAL đó không phải việc của một phiên.

## 7. Tái lập

```
curl -sSL -o Test/Download/sandout/sandout.ipa \
  https://github.com/thinhnv-funtom/archive/releases/download/com.uncosoft.sandout/com.uncosoft.sandout_0.2.5_und3fined.ipa
(cd Test/Input/SandOut && unzip -q ../../Download/sandout/sandout.ipa)
dotnet Source/0Bins/AssetRipper.Tools.SystemTester/Release/AssetRipper.Tools.SystemTester.dll \
  --script-level 3 --reconstruct-bodies --struct-db StructDb --output Test/OutSO --log Test/ARSO.log Test/Input/SandOut
UNITY_EDITOR_DATA=<Unity-6000.0.72f1>/Editor/Data bash Test/Scripts/compile_recovered_scripts.sh Test/OutSO Assembly-CSharp
```

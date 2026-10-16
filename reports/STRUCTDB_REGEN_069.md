# StructDb sinh lại từ Unity Editor thật, và compile với assembly thật của Editor (iteration 069)

Ngày 2026-10-16. Mọi con số dưới đây đo trong container, trên build Release từ source sạch tại
`5a86a4b4` (không có patch base chain của 069 — patch đó vẫn chưa land).

## 1. Cách làm

- Tải từng bản Linux Editor từ `download.unity3d.com` (changeset lấy từ
  `services.api.unity.com/unity/editor/release/v1/releases?version=<v>`), stream qua `xz | tar`
  và chỉ giữ `Editor/Data/il2cpp/libil2cpp` (cộng `Managed`, `MonoBleedingEdge/.../4.7.1-api`,
  `UnityReferenceAssemblies`, `NetStandard` cho ba bản của fixture). Không cần cài, không cần license.
- `tools/structdb_gen.py` lấy từ nhánh `ref/devx` và sửa để chạy được trên Linux:
  - `UNITY_EDITOR_ROOTS`, `STRUCTDB_CLANG`, `STRUCTDB_SYSROOT`: clang 18 của hệ thống cộng với
    sysroot của NDK r23c (chỉ giữ header, 29 MB);
  - header nào không có ở bản đó thì bỏ (`vm/GlobalMetadataFileInternals.h` chỉ có từ 2020.2);
  - đọc metadata version ở `MetadataCache.cpp` khi không có `GlobalMetadata.cpp`;
  - `--gzip` ghi `.json.gz` với gzip mtime 0; `index` đọc được file nén và giữ CRLF của `index.json`;
  - chuẩn hoá cách viết kiểu mảng (`uint8_t [8]`) để clang nào cũng cho cùng một file.
- `tools/structdb_diff.py A B` so theo vị trí chứ không theo cách viết: bitfield theo bit tuyệt
  đối, aggregate giữ nguyên ở một bên và trải phẳng ở bên kia là cùng một thứ.

**Kiểm chứng generator**: sinh lại `2022.3.62f2` (cả x64 và x32) cho ra file **giống hệt** file
đang có trong repo, chỉ khác `generatedUtc`. Mọi file mới đều qua round-trip
`static_assert(sizeof/offsetof)` (805 offsetof trên 2022.3) và validator của repo (`OK`, 778 file).

## 2. Ba bản của fixture

| Unity | Fixture | Trước | Sau |
|---|---|---|---|
| 2019.2.6f1 | Pinata | `dvxil2c`, exact | `clang`, exact — **rip giống hệt từng byte** (`diff_recovered_scripts.sh`: 0 file khác) |
| 2022.3.53f1 | JellyBlastV2 | **không có → fallback 2021.2.9f1** | `clang`, exact |
| 2022.3.62f2 | Impostor, RunFromZombies, Merge-Room | `clang`, exact | sinh lại trùng khớp |

### 2.1 Pinata — file `dvxil2c` của 2019.2.6f1 đúng ở mọi chỗ recovery đọc

So với header thật: `Il2CppClass`, `MethodInfo`, `Il2CppType`, `FieldInfo`, … khớp hoàn toàn. Chỉ có
hai chỗ sai, đều ở struct recovery không đọc:

- `Il2CppDefaults` thiếu `enum_info_class` (0x1C8), nên 24 field sau nó lệch 8 byte;
- `Il2CppGenericParameter.constraintsStart` ghi 2 byte, thật là 4.

Bản x32 còn khác `sizeof(Il2CppClass)` 188 → 192 (ARMv7 căn `uint64_t` theo 8, x86 thì không),
nhưng `vtable` vẫn ở 188 ở cả hai — tức là trên ARMv7 **offset của flexible array không bằng
`sizeof`**, khác với câu "vtable at offset == sizeof" trong README cũ (câu đó đúng trên x64).

Thay file bằng bản clang: rip Pinata giống hệt (placeholder 8736, EXACT 12927, lỗi thân 1074). File
mới có thêm `Il2CppObject`, `Il2CppArray`, `Il2CppString`, … mà `dvxil2c` không bao giờ lưu.

### 2.2 JellyBlastV2 — fallback 2021.2.9f1 sai đúng chỗ pass nhận diện type check đọc

`2022.3.53f1` và `2022.3.62f2` **giống hệt** nhau (0 khác biệt). Nhưng catalog chọn bản mới nhất
≤ phiên bản game, nên 2022.3.53f1 rơi về 2021.2.9f1: `Il2CppClass` lệch 4 byte từ `actualSize` trở
đi (thêm `stack_slot_size` ở 0xFC), `typeHierarchyDepth` 0x12C thay vì 0x130, mọi bitfield lệch 24
bit. 68 khác biệt, 39 trong các struct recovery đọc.

Rip lại (`Test/Out69k-j`) so với `Test/Out69s-j`:

| | 69s-j (fallback 2021.2.9f1) | 69k-j (2022.3.53f1 exact) |
|---|---:|---:|
| EXACT | 5247 (70,5 %) | **5298** (71,2 %) |
| HIGH_CONFIDENCE | 221 | 226 |
| PARTIAL | 1934 | **1875** |
| FALLBACK | 38 | 41 |
| placeholder | 12709 | **11316** (−1393, −11 %) |
| UNMANAGED_MEMORY_LOAD | 8046 | **6653** |
| lỗi thân Assembly-CSharp (stub, body pass) | 1693 | **1663** |
| file sạch | 79 / 179 | 80 / 179 |
| file `.cs` khác | — | 107 |

`method_status_diff.py`: 52 PARTIAL → EXACT, 5 PARTIAL → HIGH_CONFIDENCE, 3 PARTIAL → FALLBACK,
**0 method rời khỏi EXACT**. Golden corpus: cùng 31 IMPROVED và cùng 2 REGRESSED như baseline (hai
cái REGRESSED có từ trước, không đổi). Ba PARTIAL → FALLBACK là hiệu ứng "gỡ placeholder để lộ cái
còn thiếu": ví dụ `SpecialPluginsUtils.SetLookAt` trước kia có năm `Unmanaged memory load:
[Il2CppClass<Transform>+130]` và một nhánh `if (0 == typeof(Transform))`; giờ type check được nhận
ra và thân là `Vector3 position = ((Transform)t.target).position; …` như nguồn DOTween — fingerprint
gọi FALLBACK vì `new NullReferenceException()` của nhánh check đã biến mất cùng với check.

## 3. Quét các dòng Unity chưa có layout

Mỗi dòng lấy bản `f` đầu và cuối (2022.3 và 6000.3 chỉ bản đầu, vì đã có bản khác). 18 bản, chỉ
`libil2cpp`, ba bản song song, khoảng 40 phút. "recovery" là khác biệt trong `Il2CppClass`,
`MethodInfo`, `Il2CppObject`, `Il2CppArray(Size)`, `FieldInfo`, `Il2CppType`, `VirtualInvokeData`,
`Il2CppRGCTXData`, `Il2CppGeneric{Class,Inst,Context}`, `Il2CppString`, `Il2CppDelegate`,
`Il2CppRuntimeInterfaceOffsetPair`.

| So sánh | tất cả | recovery |
|---|---:|---:|
| 2021.2.9f1 → 2021.3.0f1 | 1 | 0 |
| 2021.3.0f1 → 2021.3.45f2 | 9 | 0 |
| 2021.2.9f1 → 2022.1.0f1 | 21 | 1 (`MethodInfo.indirect_call_via_invokers`) |
| 2022.1.0f1 → 2022.1.25f1 | 0 | 0 |
| **2022.1.25f1 → 2022.2.0f1** | 38 | **38** (`Il2CppClass` từ `actualSize`) |
| 2022.2.0f1 → 2022.2.23f1 → 2022.3.0f1 | 0 | 0 |
| 2022.3.0f1 → 2022.3.53f1 → 2022.3.62f2 | 9 / 0 | 0 |
| **2022.3.62f2 → 2023.1.0f1** | 12 | **3** (`cctor_finished_or_no_cctor` 0xE0 → 0xE4) |
| 2023.1.0f1 → 2023.1.22f1 | 0 | 0 |
| 2023.1.22f1 → 2023.2.0f1 | 2 | 1 (`MethodInfo.is_unmanaged_callers_only`) |
| 2023.2 → 6000.0 → 6000.1 → 6000.2 | 0 | 0 |
| 6000.2.15f1 → 6000.3.0f1 | 196 | 0 (metadata v39) |

Hệ quả trước iteration này:

- **Mọi game 2022.2.0 → 2022.3.61** rơi về 2021.2.9f1, sai ở `typeHierarchyDepth` — offset mà
  `TypeCheckRecovery` dùng để nhận ra mọi `as`/`is`/cast. JellyBlastV2 ở §2.2 là một trường hợp.
- **Mọi game 2023.1 → 6000.2** (Unity 6 LTS nằm trong đây) rơi về 2022.3.62f2, sai ở
  `cctor_finished_or_no_cctor` — word mà luật nhận diện guard khởi tạo class của 066 khoá vào (13657
  guard trên JellyBlastV2). Không fixture nào là Unity 6, nên chưa đo được trên một game.
- 2021.3 (LTS phổ biến) rơi về 2021.2.9f1 và fallback đó **đúng** cho mọi struct recovery đọc.

Đã thêm cả 18 bản. Vì trong mỗi dòng bản đầu và cuối khớp nhau ở mọi struct recovery đọc, fallback
"mới nhất ≤ phiên bản" giờ đúng cho mọi bản trung gian. StructDb: 370 → 389 phiên bản.

`metadataVersion` trong file là số mà runtime của bản đó assert: 29 cho 2021.3.0f1, 2022.x, 2023.x
và 6000.0.0f1; 31 cho 2021.3.45f2, 2022.3.53f1 trở đi, 6000.0.85f1, 6000.1, 6000.2; 39 cho 6000.3.

## 4. Compile script phục hồi với assembly thật của Editor

`compile_recovered_scripts.sh` nhận thêm `UNITY_EDITOR_DATA=<Editor/Data>`: các module UnityEngine và
thư viện lớp (`unity-4.8-api` hoặc `4.7.1-api`, cùng Facades) được lấy từ Editor; assembly của game
và package Editor ship dưới dạng source (UnityEngine.UI, TextMeshPro) vẫn lấy từ rip. Khi game không
ship `netstandard.dll`, facade của Editor được thêm vào (lần chạy đầu thiếu nó và báo 295 × CS0012
trên RunFromZombies — lỗi của bộ reference, không phải của bản phục hồi).

| Fixture | Unity | stub | Editor thật | chỉ có với stub (stub sai) | chỉ có với Editor (stub che) |
|---|---|---:|---:|---|---|
| Pinata | 2019.2.6f1 | 1074 | 1097 | 1 CS0165 | **24 CS0571** gọi thẳng accessor (`animation.get_Item("x")`, `hashtable.set_Item`, `string.get_Chars`) |
| Impostor | 2022.3.62f2 | 156 | 164 | — | **8 CS0104** `Debug` mơ hồ (`System.Diagnostics` vs `UnityEngine`) |
| RunFromZombies | 2022.3.62f2 | 7 | 5 | `Math.PI`, `Quaternion.Euler(Vector3)` | — |
| JellyBlastV2 | 2022.3.53f1 | 1663 | 1629 | 37 `Math.PI` | — |
| Merge-Room | 2022.3.62f2 | 275 | 280 | 3 `Math.PI` | **8 CS0104** `Debug` mơ hồ |

Mọi khác biệt còn lại là cùng một lỗi đổi nhãn: một member private của mscorlib là "inaccessible"
(CS0122) với stub và "không tồn tại" (CS1061/CS0234) với reference assembly thật, vốn không có member
private nào.

Hai họ lỗi thật mà stub che:

1. **CS0571**: stub của Cpp2IL không giữ cho `get_Item`/`set_Item` dấu hiệu là accessor của
   indexer, nên ILSpy — decompile với chính stub đó — viết `x.get_Item(k)` thay vì `x[k]`, và Roslyn
   cũng chấp nhận vì nó cũng chỉ thấy stub. Với Unity thật, đó là lỗi. Sửa ở chỗ sinh stub hoặc ở
   chỗ decompile, không phải ở thân hàm.
2. **CS0104**: stub mscorlib bị strip không có `System.Diagnostics.Debug`, nên `using System.Diagnostics;`
   cộng `using UnityEngine;` không mơ hồ khi đo, nhưng mơ hồ trong Unity. Luật "Simplify global::"
   (067) kiểm tra va chạm với bộ reference nó thấy, và bộ đó là stub.

Kết luận đo lường: số lỗi compile với stub là phép đo trung thực tới vài phần trăm (Pinata +2 %,
Impostor +5 %, JellyBlastV2 −2 %), nhưng nó che đúng những họ lỗi nằm ở ranh giới với framework. Từ
nay nên đo cả hai khi có Editor.

## 5. Tái lập

```
S=<thư mục tạm>
curl -sS "https://services.api.unity.com/unity/editor/release/v1/releases?version=2022.3.53f1&limit=1"   # changeset
curl -sSL https://download.unity3d.com/download_unity/df4e529d20d3/LinuxEditorInstaller/Unity-2022.3.53f1.tar.xz \
  | xz -dc | tar -x -C $S/editors/2022.3.53f1 --wildcards 'Editor/Data/il2cpp/libil2cpp/*'
curl -sSLO https://dl.google.com/android/repository/android-ndk-r23c-linux.zip   # chỉ cần .../sysroot/usr/include
UNITY_EDITOR_ROOTS=$S/editors STRUCTDB_CLANG=/usr/bin/clang \
STRUCTDB_SYSROOT=$S/android-ndk-r23c/toolchains/llvm/prebuilt/linux-x86_64/sysroot \
  python3 tools/structdb_gen.py --out StructDb gen --gzip 2022.3.53f1
python3 tools/structdb_gen.py --out StructDb index
dotnet run --project Source/AssetRipper.Tools.Il2CppStructDbValidator -- StructDb
UNITY_EDITOR_DATA=$S/editors/2022.3.53f1/Editor/Data \
  Test/Scripts/compile_recovered_scripts.sh Test/Out69k-j Assembly-CSharp
```

Số đo đầy đủ ở `iterations/069/structdb/`.

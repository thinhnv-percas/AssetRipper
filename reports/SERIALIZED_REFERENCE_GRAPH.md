# Serialized reference graph — iteration 061

Một method C# đúng mà component chứa nó không được gắn, hoặc gắn nhầm GameObject, hoặc field của nó
trỏ sai object, thì vẫn là recovery thất bại. Compiler không thấy điều đó, oracle theo method không
thấy, và diff YAML thô cũng không thấy: hai project không chung một fileID, GUID, instance ID hay bố
cục file nào. `Test/Scripts/serialized_reference_graph.py` dựng, cho mỗi scene ở mỗi bên, đồ thị mà
editor dựng

    Scene -> GameObject -> Component -> serialized field -> target object

và so theo **identity ngữ nghĩa**: GameObject là hierarchy path, component là GameObject cộng kiểu
(namespace và class của script, không bao giờ là GUID), target là chính nó — `GameObject:Root/Child`,
`Material:Skin`, `Sprite:GridBack_0`, `Script:Game.Mover` — không bao giờ là con số trỏ tới nó.

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**, **BLOCKED**.

## 1. Kết quả — MEASURED

Recovered: rip baseline `Test/Out61c-*` (giống từng byte với rip của iteration 061). Source:
`artifacts/reference/<project>` cộng `artifacts/reference/packages` (TextMesh Pro, post-processing).

| | RunFromZombies | Impostor | Merge-Room |
|---|---:|---:|---:|
| Scene so sánh | 2 | 1 | 2 |
| GameObject MATCHED / thiếu / thừa | 666 / 0 / 0 | 103 / 0 / 0 | 587 / 0 / 0 |
| Component MATCHED | 934 | 198 | 1643 |
| Component MATCHED_POSITIONAL | 73 | 101 | 91 |
| Component thiếu / thừa | 0 / 0 | 0 / 0 | 0 / 0 |
| Script BOUND_EXACT | 14 | 12 | 143 |
| Script BOUND_DIFFERENT / SCRIPT_MISSING | 0 / 0 | 0 / 0 | 0 / 0 |
| Script SOURCE_SCRIPT_UNDECLARED (UNKNOWN) | 73 | 101 | 91 |
| Reference MATCH (exact scope) | 735 | 56 | 1733 |
| Reference MATCH (positional scope) | 45 | 66 | 58 |
| MATCH_POSITIONAL_TARGET | 12 | 22 | 51 |
| DIFFERENT | 0 | 0 | 0 |
| DIFFERENT_NAME_SANITIZED | 1 | 0 | 0 |
| NULL_IN_RECOVERED / NULL_IN_SOURCE | 0 / 0 | 0 / 0 | 0 / 0 |
| SOURCE_TARGET_UNKNOWN | 5 | 0 | 235 |
| SOURCE_TARGET_UNKNOWN_RECOVERED_NULL | 2 | 4 | 156 |
| NULL_BOTH (ngoài rate) | 498 | 251 | 6032 |
| `reference_match_rate_exact` | 0.9986 | 1.0000 | 1.0000 |

**Trên ba game có source, không có một GameObject thiếu, một component thiếu, một script gắn sai hay
một reference trỏ sai object nào.** Chỗ duy nhất có khác biệt đã quyết định được là một cái đổi tên
(§3.3).

Rate chỉ tính trên những gì quyết định được. UNKNOWN được báo cáo bên cạnh, không bao giờ nằm trong.

## 2. Vì sao phần UNKNOWN lớn, và vì sao nó không phải là match

`SOURCE_SCRIPT_UNDECLARED` là component mà script của nó phía source không có trong checkout: uGUI là
built-in package, không nằm trong source tree và không có trên package registry
(`packages.unity.com/com.unity.ugui` chỉ có `3.0.0-exp.*`). `Image`, `Button`, `Text`, `Slider`,
`EventSystem`… đều ở đây. Một component mà một bên không gọi được tên kiểu thì không thể được nói là
đúng, nên nó không bao giờ được tính là match.

Những component đó được ghép **theo thứ tự** trong các MonoBehaviour chưa khai báo còn lại trên cùng
GameObject (build giữ thứ tự component), và mọi kết quả bên dưới chúng được giữ riêng trong scope
`positional`. Một reference trỏ vào một component được ghép theo vị trí là `MATCH_POSITIONAL_TARGET`,
không phải `MATCH`.

Script trong DLL được nhận diện **chính xác**: `m_Script` fileID của một class trong DLL là MD4 của
`"s\0\0\0" + namespace + name` (bốn byte đầu, little-endian). Self-test kiểm giá trị Unity công bố
cho `UnityEngine.UI.Image`, `-765806418`.

## 3. Những gì phải sửa trong phép đo trước khi tin được nó

Mỗi mục dưới đây đọc giống hệt một recovery defect ở lần chạy đầu.

### 3.1 Stripped document là authority, không phải phép XOR — PROVEN

Editor hiện tại đặt fileID của object trong một prefab instance là
`(instance ^ source) & 0x7FFFFFFFFFFFFFFF`. Nhưng `GameScene.unity` của RunFromZombies được nâng cấp
từ format cũ và giữ ID mà stripped document được cấp khi đó: `--- !u!82 &1909866566 stripped` có
`m_CorrespondingSourceObject.fileID` cũng là `1909866566`. Reference trong scene dùng ID đó, nên chỉ
dùng XOR thì `Movement.moveSound` đọc thành "dangling". Stripped document giờ quyết định mapping cho
object nó đại diện.

### 3.2 Root của một prefab asset mang tên file — PROVEN

`Cardboard.prefab` có root `m_Name: Cardboards`. Editor đổi tên root theo asset khi import, và build
mang tên asset: recovered là `Cardboard`. So theo `m_Name` báo `obsPrefabs[1]` DIFFERENT.

### 3.3 AssetRipper đổi tên object khi đổi tên file — PROVEN, khác biệt thật

`FileSystem.FixInvalidFileNameCharacters` thay `,`, `[`, `]`, `:`, ký tự điều khiển và các ký tự tên
file không hợp lệ *của nền tảng đang chạy* bằng `_`. Main object của một asset import mang tên file,
nên `AudioClip:This Can't be the End (Orchestral, Horror)` trở thành `(Orchestral_ Horror)` trong
project recovered. Đây là khác biệt thật — `clip.name` đổi — và nó phụ thuộc hệ điều hành chạy
export, vì danh sách ký tự không hợp lệ là của `System.IO.Path`. Được giữ riêng là
`DIFFERENT_NAME_SANITIZED` để không trộn với một reference trỏ nhầm object. Không sửa ở iteration này:
tên file vẫn phải hợp lệ, và cách sửa đúng (ghi tên gốc vào `.meta`, hoặc chỉ thay ký tự thật sự
không hợp lệ) cần một iteration có baseline riêng.

### 3.4 Avatar và mesh của model — PROVEN / UNKNOWN

ModelImporter đặt tên avatar nó sinh là `<model>Avatar`; so theo tên file báo mọi `Animator.m_Avatar` của RunFromZombies là DIFFERENT.
Mesh bên trong một FBX được đặt tên bởi chính file FBX, mà script không đọc, nên
`Building_I_2.fbx object 4300002` là UNKNOWN chứ không đoán — đó là phần lớn `SOURCE_TARGET_UNKNOWN`
của Merge-Room.

### 3.5 Sprite sheet từ 2021 — PROVEN

Tên sprite cắt ra từ một texture nằm trong `spriteSheet.nameFileIdTable`, không phải
`internalIDToNameTable` (rỗng). Thiếu nó thì mọi `m_Sprite` có ID băm đọc thành UNKNOWN.

## 4. `SOURCE_TARGET_UNKNOWN_RECOVERED_NULL` — INFERRED

Đây là danh sách cần đọc: source trỏ vào một thứ không gọi tên được, recovered không trỏ vào gì.

- Merge-Room, 152: toàn bộ là `ParticleSystem.LightsModule.light` trong module **đang tắt**
  (`enabled: 0`), trỏ vào prefab GUID `faeb88c2…` mà chính source checkout không có. Trong editor đó
  là một reference "Missing"; build ghi null. INFERRED: recovered null là đúng giá trị build mang.
- Còn lại 4 + 2 + 4 `m_Sprite`/`m_Avatar` trỏ vào GUID không có trong checkout (asset của package
  không nằm trong source tree). UNKNOWN.

Không có cái nào trong số này được tự động xếp vào match hay failure.

## 5. Giới hạn

- Chỉ so **scene**. Prefab asset được đọc khi một field trỏ vào nó, nhưng không được so như một đồ
  thị riêng. Resources và Addressables chưa được duyệt.
- JellyBlastV2 không có source: BLOCKED.
- Component là built-in engine component (Transform, MeshRenderer…) được so theo tên kiểu, đúng như
  identity của chúng.
- Giá trị scalar của field (vị trí, màu, số) không được so — đây là đồ thị *reference*.

Lệnh:

```
python3 Test/Scripts/serialized_reference_graph.py --self-test      # 13 case
python3 Test/Scripts/serialized_reference_graph.py artifacts/reference/<project> Test/Out61c-<x>/<Game> \
  --package-dir artifacts/reference/packages --json iterations/061/serialized-reference-graph/<Game>.json
```

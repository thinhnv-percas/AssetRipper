# Iteration 054 — page base, ranh giới có tên, và fixture thứ tư

## 1. Ma trận bốn fixture (§1, §2)

Impostor, RunFromZombies, **Merge-Room** (mới), JellyBlastV2. Pinata không nằm trong acceptance.
`reports/MERGE_ROOM.md` là fingerprint và baseline đầy đủ của fixture mới: Unity 2022.3.62f2,
metadata v31, arm64-v8a, `libil2cpp.so` 63 MB, 137 assembly khai báo trong build, 29 assembly
recovery thử, 2 scene, 36 prefab, 333 material, 34 shader. Build artifact và source repository ghi
provenance riêng; source chỉ là oracle và không có đường nào đi vào pipeline recovery.

## 2. Phát hiện chính — page base của metadata usage (§5, §6)

`GAState.Init` trên fixture iOS quay về như thế này:

```csharp
nint num2 = (nint)typeof(UnityEngine.UIElements.EnumFieldHelpers);
nint num3 = (nint)typeof(System.Runtime.Serialization.ObjectHolderList);
UnityEngine.Object obj = Resources.Load((string)0, typeFromHandle);
```

Không kiểu nào trong đó liên quan tới GameAnalytics, và cả đường dẫn resource cũng sai. Phân bố là
thứ nói ra nguyên nhân: **15.144 lần nhắc tới class pointer trên chỉ 277 kiểu khác nhau**, bận nhất
là `Facebook.Unity.Windows.IWindowsFacebook` 3614 lần trong những assembly không thể với tới nó.

A64 không materialise được một địa chỉ đầy đủ trong một lệnh: `adrp` cho ra base của một trang 4 KiB
và offset đến sau. Khi một trang chứa nhiều usage slot, compiler tính base một lần rồi dùng lại, nên
`add` không gộp ngược vào `adrp` được. Base đó không phải usage — nhưng **từ metadata v27 nó đọc y
hệt một usage**: không còn bảng nào để đối chiếu địa chỉ, một global được giải mã từ giá trị nằm
*tại* địa chỉ đó, và một page base trỏ vào slot đầu của trang nên luôn đọc ra một token hợp lệ của
bất kỳ cái gì tình cờ nằm đấy.

Phép sửa tự báo sai **hai lần** trước khi chạy:

1. Khớp đúng local nhận immediate — không bao giờ khớp, vì `adrp` gần như không bao giờ là lệnh ngay
   trước chỗ dùng. Đây đúng là bài học `PointerProvenance` được viết ra để ghi.
2. Đi ngược qua copy — tìm được 1154 base trên fixture iOS và **vẫn không đổi một byte nào**, vì
   offset tới base đi theo hai đường: một load gọi tên nó trong addressing mode, còn chỗ cần *địa
   chỉ* của slot thì `add` đứng riêng và base không bao giờ là memory operand. Tất cả những base bị
   đặt tên sai đều thuộc loại thứ hai.

Và page base thì page-aligned. Không có phép thử đó, luật đọc mọi hằng số bị cộng thêm là một base —
80.968 so với 1154 — và dập cả những usage đang phân giải đúng.

JellyBlastV2: EXACT 2200 → **2517**, placeholder 48.458 → **37.857**, lỗi Roslyn 8638 → **6630**,
`Il2CppClass<>` 25.675 → 8689 với tên đã hợp lý. Golden corpus improved 5, regressed 0.

Cái giá, ghi rõ: 36 method từ PARTIAL/HIGH_CONFIDENCE xuống FALLBACK, nên `body_recovery_rate`
0,9507 → 0,9459. Đó là những method trước đây *có vẻ* có phép toán nhờ một kiểu sai được khẳng định.

## 3. Ranh giới native được gọi tên từ symbol (§8)

Phần lớn `UNKNOWN` còn lại không hề vô danh: **97 của 112 trên Impostor, 628 của 662 trên
Merge-Room, 792 của 814 trên JellyBlastV2, 276 của 281 trên RunFromZombies không mang địa chỉ nào**,
và thứ chúng mang thay vào đó là tên hàm runtime trong dấu nháy — `il2cpp_vm_object_unbox`,
`il2cpp_codegen_object_is_inst`, `il2cpp_vm_class_is_assignable_from`. Binary tự đặt những tên đó,
nên phân loại chúng là đọc bằng chứng. `NativeBoundary.KindOfSymbol` đã có sẵn, là đúng luật một PLT
relocation đi qua; chỉ là nhánh operand chưa bao giờ hỏi nó.

`UNKNOWN`: Impostor 112 → **15**, RunFromZombies 281 → **5**, JellyBlastV2 814 → **22**,
Merge-Room 662 → **34**. Không hardcode địa chỉ, không suy từ tên caller.

Số còn lại đều mang địa chỉ và đã được gom theo hình dạng machine code: Impostor 15 site / 6 địa chỉ
/ 3 hình dạng, Merge-Room 34 / 16 / 10. Các hình dạng đều là prologue hàm bình thường
(`STP STP STP ADRP`), tức là từng hàm riêng biệt chứ không phải một họ nhận ra được — **không thể
phân loại thêm mà không đoán**.

Trên đường đi, `cluster_runtime_boundaries.py` báo "0 UNKNOWN call sites" trên một bản rip có 15
cái: regex của nó đòi kind chỉ gồm `[A-Z_]` (nên `IL2CPP_RUNTIME` trượt vì có chữ số) và đòi phần
chi tiết kết thúc ngay sau địa chỉ, trong khi thông điệp đã mọc thêm hậu tố `(inside …)`.

## 4. `FRAMEWORK_PRIVATE_MEMBER`, tách làm ba (§7)

Cụm lớn nhất còn lại sau phép sửa page base: 1637 lỗi / 50 file trên JellyBlastV2.
`reports/FRAMEWORK_PRIVATE_MEMBER.md` tách nó theo *member* chứ không theo owner — `List<T>` chiếm
1627 của 1780, nên đây là một kiểu chứ không phải một họ:

| | | |
|---|---|---|
| `_size` | 398 | **recovery mistake** — `Count` là accessor tầm thường của nó, và phép ghép accessor không khớp vì `ReturnsNothingButTheField` đòi thân getter đúng một lệnh Move rồi Return |
| `_version` | 800 | **framework real limitation** — bộ đếm sửa đổi của enumerator, không API công khai nào đọc được |
| `_items` | 429 | **compatibility API requirement** — `list._items[i]` đúng bằng `list[i]` sau khi bounds check bị bỏ |

Không nới accessibility của member framework, không đổi public API signature.

## 5. Kết quả âm: kiểu do exporter tiêm vào (§5)

CS0433 là cụm lớn thứ hai của Merge-Room (1315 lỗi / 23 file) và không lỗi nào là defect của
recovery: `InjectTypeIntoAllAssemblies` tiêm `TokenAttribute` và bảy kiểu khác vào *mọi* assembly ở
mức public. Đã thử sửa bằng `NotPublic` — build được, xuất ra `internal sealed` đúng như mong đợi —
và **hoàn tác**, vì ILSpy viết attribute internal ra dạng đủ tên nên `[Address(` và `[NativeSource(`
không còn khớp và `recovery_metrics.py` đọc RunFromZombies thành `NO_BODIES` với cả năm trạng thái
bằng 0, trên một bản rip mà `compile_pass_rate` vẫn 0,9761.
`reports/INJECTED_TYPE_COLLISION.md` ghi cách sửa và cái giá.

## 6. Source manifest: ba phép phân biệt nữa, bằng bằng chứng (§4)

`NOT_IN_METADATA` — tên không xuất hiện trong chính `global-metadata.dat` của bản build, tra **giữa
hai NUL** chứ không phải substring (substring báo `Menu`, `Settings`, `Game`, `Pay` là có mặt vì mỗi
cái là con của một identifier khác, và mười một kiểu bản dựng chưa từng có đã đọc thành mất mát).
`RECOVERED_ELSEWHERE` — kiểu quay về nhưng ở assembly khác, vì package tự mang assembly riêng.
`source_matches_build` — kiểm ngược: không kiểu nào bản build có mà source không khai báo.

Merge-Room `type_recovery_rate` 0,9145 → **0,9943**. `YandexAppMetrica` và `AppsFlyer` xuất hiện
**0 lần** trong global-metadata của bản build trong khi `GameManager` xuất hiện 3 lần — source cây
có các SDK ấy, bản dựng thì không.

## 7. Runtime readiness (§15)

`runtime_validation_manifest.py` ghi ra đúng thứ một môi trường có Unity cần: phiên bản editor,
scene khởi động lấy từ `EditorBuildSettings`, danh sách scene, package, native plugin, số script
khai báo từng Unity message, và method smoke lấy từ chính golden corpus. Artefact tự nói
`runtime_status: NOT_RUN`, lý do `UNITY_NOT_AVAILABLE`.

Một phát hiện: cả bốn project đều có **0 native plugin** — thư viện native nằm trong `lib/` của APK
và không đi vào project, nên bất cứ P/Invoke nào cũng sẽ hỏng lúc chạy.

## 8. Golden corpus (§16)

591 → **887 entry**: thêm MergeRoom (255) và chọn lại ba fixture kia trên bản rip mới, 16 retired
giữ nguyên. Mỗi entry mang thêm `compile_status` (693 CLEAN, 163 FAILS) và `reference_status`
(75 REFERENCED, 781 NOT_REFERENCED). Cả bốn fixture improved 0 regressed 0; kiểm chứng bằng cách
sửa một entry baseline thì check báo REGRESSED và thoát 1.

## 9. Trạng thái

**`PROJECT_COMPILES_NOT_RUNTIME_VALIDATED`.** Unity không có trong container, stage E–I là `BLOCKED`
trên cả bốn fixture, và không khẳng định runtime nào dựa vào chúng.

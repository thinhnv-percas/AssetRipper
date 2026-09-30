# Storage hazard analysis — iteration 062

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Bản rip: `Test/Out62m-*`; baseline: bản rip cuối
của 061.

## 1. Phân loại — `StorageHazardClassifier`

Iteration 061 đếm 22–103 hazard mỗi fixture (một ô nhớ máy nằm ở nhiều local IL trong khi địa chỉ của
nó bị lấy) mà không nói cái nào làm mất giá trị. Mỗi hazard giờ có một kết luận:

| Kind | Khi nào |
|---|---|
| `TrueAlias` | **Trong một block**: một tên khác của ô được ghi giữa lần ghi cuối dưới tên bị lấy địa chỉ và lúc địa chỉ được giao đi; hoặc được đọc sau một lần giao có thể ghi qua con trỏ, không có lần ghi nào ở giữa |
| `SpillAlias` | địa chỉ không rời biểu thức nó được lấy, không xung đột trong block |
| `Copy` | các tên nối bằng một bản sao, không xung đột |
| `Reuse` | trong một block, đời của tên kia kết thúc trước khi địa chỉ bị lấy |
| `NonAlias` | không có đường control flow nào nối lần lấy địa chỉ với một truy cập của tên kia |
| `Unknown` | có đường nối qua nhiều block và không gì quyết định thứ tự |

Thứ tự chỉ được dùng ở nơi nó là sự thật: vị trí của hai lệnh trong một block. Qua nhiều block, sự
thật duy nhất được dùng là reachability. Index lệnh không phải một thứ tự qua block và không bao giờ
được dùng như vậy. Không dùng độ giống tên. Mỗi hazard mang stack location, lệnh def/use, điểm lấy địa
chỉ, các local IL, alias group và kết luận (`CPP2IL_DUMP_STORAGE_HAZARDS`,
`iterations/062/storage/haz62m-*.tsv`).

Một TrueAlias bị báo sai đã được tìm và sửa trong lúc làm: toán hạng của một call không giải quyết được
(mười sáu raw register) bị đếm là lần đọc, trong khi generator phát placeholder cho call đó và không
load toán hạng nào. `IlGenerator.LoadsCallOperands` giờ nói khi nào generator load toán hạng của một
call, và classifier hỏi chính luật đó thay vì tự viết lại. JellyBlastV2: 8 TrueAlias → 1 chỉ riêng vì
thế.

## 2. Lỗi thật đằng sau — PROVEN, sửa

Đọc các TrueAlias còn lại cho một họ lỗi mà không số tổng hợp nào từng thấy:

```csharp
List<SkeletonDataAsset>.Enumerator enumerator = skeletonDataAssets.GetEnumerator();
List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
while (enumerator2.MoveNext())
```

`foreach` trên một `List<T>` lặp trên một enumerator mặc định. Compile được, đọc hợp lý, và không làm
gì (thật ra ném NullReferenceException ở `MoveNext` đầu tiên). Ba nguyên nhân chồng lên nhau, sửa từ
tầng đầu tiên:

1. **Struct generic không có kích thước.** il2cpp chỉ ghi size cho type definition, nên
   `TypeSizes.UnboxedSize(List<T>.Enumerator)` = 0 và `ReturnsViaHiddenBuffer` gọi nó là register
   return. Enumerator 24 byte thật ra trở về qua buffer mà caller truyền trong X8, nên buffer không bao
   giờ được nối với call. `GenericInstanceFieldLayout.ValueTypeSize` giờ tính size bằng cách đi qua
   field của definition với argument được thay vào. **MEASURED, kiểm chéo với machine code**: một call
   trả qua buffer luôn được đi trước bởi caller đặt một địa chỉ vào X8. Trong các call trả struct
   generic qua buffer theo size tính được:

   | | Impostor | Merge-Room | RunFromZombies | JellyBlastV2 | Pinata |
   |---|---:|---:|---:|---:|---:|
   | X8 giữ một địa chỉ stack | 261 | 601 | 159 | 282 | 42 |
   | không | 0 | 0 | 2 | 2 | **20** |

   Trên bốn fixture 2022.3 máy và size tính được gần như hoàn toàn đồng ý. Trên Pinata (2019.2) một
   phần ba không đồng ý: hoặc buffer không nằm trên stack (X8 trỏ vào heap hay một field), hoặc size
   tính được sai cho layout của phiên bản đó. **UNKNOWN**, chưa phân loại — và đó rất có thể là lý do
   Pinata chỉ giảm 126 → 112 ở bảng dưới.
2. **Frame.** `GenericInstanceFieldLayout` trả offset boxed (tính từ object header), còn con trỏ tới dữ
   liệu của một struct là value-relative. `_current` ở 0x10 đọc thành `_list`, field ở boxed 0x10.
   `MetadataResolver` giờ đổi addend qua `FieldOffsetFrame` cho struct generic (iteration 045 đo
   value-relative 1761 lần, object-relative 0 lần trên các load đã giải quyết).
3. **Aliasing.** `MoveNext(&stack_-48)` ghi phần tử qua con trỏ vào word `stack_-38` bên trong struct;
   SSA không thấy lần ghi đó và đưa cho thân vòng lặp giá trị trước `MoveNext` đầu tiên.
   `StructSlotAliasRecovery`:
   - một word bên trong một struct trên stack, đọc sau khi địa chỉ struct được giao cho một call, là
     field của struct — **chỉ khi** word đó được chứng minh là bản sao của chính field đó (định nghĩa
     của nó, qua các bản sao thẳng, là field cùng offset của một giá trị cùng struct), và lần giao
     dominate lần đọc;
   - một load qua thanh ghi giữ địa chỉ struct (`ldr x1, [x0, #0x10]` với `x0 = &S`) là field của S —
     về IL đó đúng là `ldloca S; ldfld`;
   - ô được định nghĩa bằng field đầu của một giá trị trả về cùng struct là cả giá trị đó.

   Bản đầu thay cả word không có định nghĩa, và đặt tên một `string` là phần tử của enumerator
   (`(string)enumerator2._current`). Luật provenance là thứ loại nó; một word không có bằng chứng giữ
   nguyên.

Thêm: một struct local đọc một member *bên trong* một field struct của nó (`enumerator._current.attachment`)
từng bị cấm hoàn toàn vì một lần *ghi* qua chuỗi cần địa chỉ; lần đọc chain `ldfld` trên giá trị và giờ
được phép. `SizeOf` của field khai báo `T` giờ là kích thước của argument.

| `MoveNext` trên enumerator chưa từng được gán | 061 | 062 |
|---|---:|---:|
| Impostor | 113 | 5 |
| Merge-Room | 244 | 5 |
| RunFromZombies | 30 | 5 |
| JellyBlastV2 | 95 | 0 |
| Pinata (2019.2) | 126 | 112 |

Ví dụ, `ResourcesUtil.AddResource(List<Item>)`, source `foreach (var item in items) AddResource(item.type, item.id, item.value, ...)`:

```csharp
enumerator2 = items.GetEnumerator();
while (((List<object>.Enumerator*)(&enumerator2))->MoveNext())
{
    Item current = (Item)((List<object>.Enumerator*)(&enumerator2))->_current;
    AddResource(current.type, current.id, current.value, true);
}
```

Ngữ nghĩa đúng; cú pháp con trỏ đến từ kiểu `MoveNext` chia sẻ (`List<object>`), là một lỗi riêng.

## 3. Kết quả phân loại

| | TrueAlias | NonAlias | Unknown | tổng |
|---|---:|---:|---:|---:|
| Impostor | 3 → **1** | 1 | 18 | 20 |
| Merge-Room | 1 → **0** | 9 | 51 | 60 |
| RunFromZombies | 0 | 4 | 96 | 100 |
| JellyBlastV2 | 8 → **2** | 11 | 49 | 62 |
| Pinata | 0 | 5 | 5 | 10 |

(Số "trước" là classifier trên bản rip đầu 062, trước các sửa ở §2.) Ba TrueAlias còn lại, **OPEN**:

- `Spine.Unity.Examples.SkeletonRagdoll::AttachBoundingBoxRagdollColliders` `stack:-100`: một enumerator
  `ExposedList` đọc sau `Dispose` của một enumerator khác tái dùng cùng ô.
- `RayFire.DotNet.RFShatter::GetCombinedSubMesh` `stack:-270` và
  `Voodoo.UI.Particles.UIParticleUpdater::BakeMesh` `stack:-2D0`: một word float ghi dưới tên khác ngay
  trước `Matrix4x4.op_Multiply` nhận địa chỉ ô — buffer trả về của một `Matrix4x4` 64 byte.

`Unknown` chiếm đa số và là kết luận đúng: thứ tự qua nhiều block không được thiết lập.

## 4. Chi phí đo được — và vì sao nó đúng hướng

Placeholder Impostor 4149 → 4291. Tăng nằm gần hết ở `SkeletonJson.cs`, `SkeletonRagdoll*.cs`,
`AnimationMatchModifierAsset.cs`, `Skin.cs`, và đều cùng một dạng: nơi 061 viết
`Dictionary<string, object> dictionary4 = default(...)` — một null lặng lẽ, vì vòng lặp không bao giờ
chạy — thân vòng giờ chạy và lần đọc phần tử qua một thanh ghi chưa được chứng minh là `&slot` được báo
là unresolved load. §31: UNKNOWN tốt hơn một giá trị sai compile được. Merge-Room, RunFromZombies,
JellyBlastV2 và Pinata đều giảm placeholder.

## 5. ref/out/in và provenance (§17–§18)

`LocalStorage.For` (061) vẫn là luật duy nhất cho parameter by-ref; `Il2CppStorageIdentityTests` vẫn
bắt buộc chỉ ba helper index map local. `PointerProvenance` / `BasePointerOrigin` giữ root, path, kiểu
và coordinate frame của một base pointer; §2 là lần đầu frame được áp vào struct generic thay vì chỉ
được báo. Không có giá trị object/field nào bị thu thành native integer ở đây.

## 6. Test

`Il2CppStorageHazardTests` (5), `Il2CppStructSlotAliasTests` (13, gồm: phần tử đọc sau `MoveNext` là
field; đọc trước lần giao giữ nguyên; word ghi sau lần giao giữ giá trị được ghi; word không có định
nghĩa không bị giả định; word sao từ thứ khác không phải member; word ngoài struct; nhánh không bị
dominate; load qua địa chỉ; load quá struct; ô sao từ field đầu là cả struct),
`Il2CppIndirectReturnBufferTests` (+3).

---

# Iteration 063

## 7. Kết quả phân loại — không đổi

Bản rip cuối 063 (`Test/Out63g-*`), cùng `StorageHazardClassifier`:

| | TrueAlias | NonAlias | Unknown |
|---|---:|---:|---:|
| Impostor | 1 | 1 | 18 |
| RunFromZombies | 0 | 4 | 96 |
| JellyBlastV2 | 2 | 11 | 48 |
| Pinata | 0 | 5 | 5 |
| Merge-Room | 0 | 9 | 51 |

## 8. Hai lỗi storage mới, tìm qua oracle độc lập

- **Tham số trên stack (PROVEN, đã sửa).** Không phải alias: một tham số AAPCS64 đặt trên stack được
  resolver gán cho một thanh ghi vector không ai ghi, nên *storage* của tham số là sai và mọi lần đọc trả về
  giá trị mặc định. Đây là cùng họ với lỗi `LocalStorage.For` của 058/061 (một giá trị ở hai nơi), ở tầng
  ABI thay vì tầng generator. `reports/JELLYBLAST_SOURCE_ORACLE.md` §5.1.
- **Ghi qua `ref` tới struct (PROVEN, chưa sửa).** `UnityEngine.UI.SetPropertyUtility.SetColor(ref Color
  currentValue, Color newValue)` phục hồi thành `currentValue = ref *(Color*)newValue;` — gán lại ref cục bộ
  thay vì lưu giá trị qua con trỏ — và `currentValue.g/.b/.a` đọc thành unresolved load
  `[currentValue @ X0 (UnityEngine.Color&)+4]`: một base kiểu `T&` không được tra field của `T`. Mục tiêu:
  zero confirmed semantic storage mismatch (§17) — **chưa đạt**: TrueAlias 1/2 và lỗi này còn mở.

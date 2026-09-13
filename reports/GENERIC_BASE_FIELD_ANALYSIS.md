# Field kế thừa từ một lớp cơ sở generic

Iteration 041. Fixture Impostor (ARM64, metadata v31.1) và Pinata (x86, v24.2). Baseline `7e04b2fe`.

## 1. Nguyên nhân gốc — CONFIRMED

`MetadataResolver.ResolveTypesAndFields` tìm field ở một offset bằng cách đi ngược chuỗi base, và ở
mỗi mắt xích nó so:

```csharp
f.BackingData?.FieldOffset == memory.Addend
```

Mọi field của một **generic instance** là `ConcreteGenericFieldAnalysisContext`, dựng bằng
`base(null, genericInstanceType)` — không có definition phía sau, nên `BackingData` là `null`. Phép
so trên vì thế **không bao giờ** khớp trên một mắt xích như vậy, bất kể offset.

Đọc mắt xích đó theo đường metadata sai theo cả hai chiều:

- không offset nào lớn hơn 0 khớp được;
- offset 0 thì sẽ khớp *mọi* field của type, vì metadata của một generic definition ghi tất cả
  field ở 0.

Offset thật chỉ tồn tại trong layout mà `GenericInstanceFieldLayout` tính. Layout đó **đã** được
hỏi — nhưng chỉ khi *chính owner* là generic instance. Khi owner chỉ **kế thừa** từ một generic
instance thì không.

Hình dạng gây ra nó là hoàn toàn thường gặp: một lớp cơ sở singleton tự tham chiếu.

```
TimeCheatingDetector : ACTkDetectorBase<TimeCheatingDetector>
```

## 2. Bằng chứng

Cột trạng thái metadata mới trên `CPP2IL_DUMP_LOADS` (xem mục 6) báo 68 load mà layout đặt **đúng
một field ở đúng offset được hỏi** trong khi generator vẫn bỏ cuộc. Lọc theo owner:

| offset | field | khai báo ở |
|---|---|---|
| 0x48 | `detectionEventHasListener` | `ACTkDetectorBase<TimeCheatingDetector>` |
| 0x49 | `started` | `ACTkDetectorBase<TimeCheatingDetector>` |
| 0x4A | `isRunning` | `ACTkDetectorBase<TimeCheatingDetector>` |

Điểm đầu tiên thông tin bị mất, theo đúng flow brief yêu cầu truy:

```
Il2Cpp metadata        có đủ field + offset (trong layout của generic definition)
Il2CppClass            có
field definitions      có
field offsets          CÓ, nhưng chỉ trong layout tính được, không trong BackingData
managed type layout    GenericInstanceFieldLayout tính đúng
FieldReference         ← MẤT Ở ĐÂY: chuỗi base chỉ hỏi BackingData
```

Đây là trường hợp "metadata tồn tại nhưng layout resolver không consume được", không phải
"metadata không tồn tại". Không có field nào bị bịa ra.

## 3. Hai giả thuyết bị loại, cả hai suýt được ship

### 3.1 Trả về field mà layout tìm được, nguyên trạng — LOẠI

Layout được tính trên *definition*, nên field trả về do type mở khai báo. Naming nó sinh ra cast
sang `ACTkDetectorBase<>`, thứ C# không viết được.

- *Kỳ vọng*: load giảm, không có gì mới.
- *Quan sát*: load 2756 → 2721 đúng như mong đợi, **nhưng** cast `<>` trên toàn bản rip 5 → 45.
- *Kết luận*: LOẠI. Chính code cũ đã có guard này cho owner (`// make sure we have a full GIT for
  field access. open type is bad.`); bản sửa phải áp dụng nó cho tổ tiên.

Một cảnh báo đi kèm: Roslyn trên ACTk.Runtime báo **4 lỗi cả trước lẫn sau**, vì file đó có lỗi cú
pháp CS1525 có sẵn và Roslyn dừng ở khâu parse, nên 40 cast hỏng mới không hề được báo. Đây là bẫy
"một lỗi declaration che mọi lỗi body" của CLAUDE.md, sớm hơn một tầng: **lỗi parse che cả file**.
Con số phải đọc là số hình dạng đếm trên toàn bản rip, không phải số lỗi của assembly đó.

### 3.2 Instantiate field trên mắt xích vừa trả lời — LOẠI

Layout của một mắt xích phủ **toàn bộ chuỗi base của nó**, nên nó có thể trả về field của một tổ
tiên xa hơn. PlayMaker:

```
SomeAction : ComponentAction<InputField> : FsmStateAction
```

`fsm` do `FsmStateAction` khai báo, nhưng layout của `ComponentAction<InputField>` cũng đặt nó —
nên field bị khai báo trên một type không khai báo nó.

- *Quan sát*: Pinata sinh **186 lỗi CS0117/CS1061 mới** (`'ComponentAction<InputField>' does not
  contain a definition for 'fsm'`). **Impostor không thấy gì cả.**
- *Kết luận*: LOẠI. Luật đúng: một mắt xích chỉ trả lời cho thứ **nó tự khai báo**; còn lại để mắt
  xích khai báo nó trả lời, và walk tới đó ngay sau đó — ở đó nó là type thường và metadata khớp
  bình thường.

Đây là lần thứ n cổng Pinata (x86, metadata v24.2) bắt được thứ Impostor không bắt được. Không có
nó bản sửa đã ship kèm một regression 186 lỗi.

## 4. Bản sửa

`BaseChainFieldSearch` tách phép đi chuỗi ra, viết qua delegate nên test được mà không cần game
phía sau, và `MetadataResolver` đi đúng qua nó. Mỗi mắt xích được hỏi theo cách nó trả lời được:

- mắt xích thường → offset ghi trong metadata;
- generic instance → layout tính được, **và chỉ nhận nếu field đó do chính definition của mắt xích
  khai báo**;
- mắt xích trả lời qua layout được báo ngược ra, để caller instantiate field trên nó.

Truy cập static giữ nguyên đường metadata: static field không nằm trong instance layout.

## 5. Số đo

| Metric | 040 | 041 | Delta |
|---|---:|---:|---:|
| Impostor unresolved loads | 2756 | 2722 | −34 |
| — trong đó ACTk.Runtime | 186 | 152 | −34 |
| Impostor genFail | 0 | 0 | 0 |
| Impostor REAL_ERROR | 861 | 861 | 0 |
| Impostor Roslyn DECOMPILER_ERROR | 348 | 348 | 0 |
| Impostor Roslyn REFERENCE_ERROR | 0 | 0 | 0 |
| Impostor file | 819 | 819 | 0 |
| shape checks | 16/16 | 16/16 | 0 |
| `array[i].field` | 164 | 164 | 0 |
| `(float)array[i]` | 0 | 0 | 0 |
| cast `<>` (toàn rip) | 5 | 5 | 0 |
| `(nint)0 != 0` (toàn rip) | 134 | 109 | **−25** |
| **Pinata Roslyn DECOMPILER_ERROR** | **1599** | **1478** | **−121** |
| Pinata Roslyn REFERENCE_ERROR | 1 | 1 | 0 |
| Pinata genFail | 0 | 0 | 0 |
| Pinata file | 3083 | 3083 | 0 |
| Pinata method-not-found | 4052 | 4052 | 0 |
| test | 343 | 354 | +11 |
| pre-existing failures | 1 | 1 | 0 |

Pinata giảm **chỉ ở CS0030** (1246 → 1125) và **không phát sinh mã lỗi mới nào**.

REAL_ERROR và Roslyn của Impostor không đổi vì cả 34 load nằm trong ACTk.Runtime, còn hai phép đo
đó chỉ phủ Assembly-CSharp — đúng bài học "Assembly-CSharp giữ chưa tới một phần mười số load".

iOS: không đổi. Cùng chẩn đoán mã hoá, 1481 file, genFail 0.

## 6. Đo trạng thái metadata — và ba nhãn sai của iteration 040

`CPP2IL_DUMP_LOADS` thêm bốn cột: layout kind, số field layout đặt được, offset lớn nhất, và thứ
nằm ở offset được hỏi. Cột cuối gọi thẳng `FindNestedFieldPath`, nên nó phân biệt được "metadata có
câu trả lời" với "metadata không có".

Đo bằng nó thì hai nhãn của iteration 040 không đứng vững, và cả hai đều vì đếm field bằng
`BackingData.FieldOffset`:

- `base-type-declares-no-field-offsets` gộp ba thứ: **tham số kiểu trần** `T`, vốn không có layout
  tĩnh nào để mà thiếu (111/165); type **không có instance field nào** (`System.Object`,
  `System.Array`, con trỏ) có layout đầy đủ và rỗng; và type thật sự khai báo field mà layout không
  đặt được.
- `offset-within-the-layout-and-on-no-field` khẳng định "on no field" mà chưa bao giờ kiểm tra.

`PAST_LAST_FIELD` thừa hưởng cùng lỗi: `largest` tính từ metadata, nên một type chỉ *kế thừa* từ
generic instance đọc ra như không có layout.

Phân bố sau khi sửa nhãn (số load không đổi, 2722):

| | 040 | 041 |
|---|---:|---:|
| RUNTIME_STRUCT | 684 | 684 |
| TYPE_PROPAGATION | 486 | 486 |
| PAST_LAST_FIELD | 469 | 416 |
| GENERIC_LAYOUT | 277 | 390 |
| ARRAY_ELEMENT | 250 | 250 |
| UNKNOWN | 188 | 188 |
| MISSING_METADATA | 378 | 184 |
| NO_KNOWN_LAYOUT | — | 52 |
| **RESOLVABLE** | — | **48** |
| PHI_AMBIGUITY | 24 | 24 |

## 7. Còn lại — `RESOLVABLE` là 48

48 load mà layout đặt đúng một field ở đúng offset đó và generator vẫn bỏ cuộc. Trước bản sửa là
82; 34 cái đã xử lý. Phần còn lại gần như toàn **value type**:

| owner | số | field ở offset |
|---|---:|---|
| `DG.Tweening.Plugins.Options.PathOptions` | 12 | `lookAhead`, `hasCustomForwardDirection`, … |
| `UnityEngine.Bounds` | 5 | `m_Center` |
| `System.Int32` | 5 | `m_value` |
| `CodeStage.AntiCheat.ObscuredTypes.ObscuredDecimal` | 4 | `currentCryptoKey` |
| base chưa có kiểu | 15 | — |

Giả thuyết (chưa xác nhận): với value type, metadata ghi offset tính từ dữ liệu của chính giá trị,
còn `GenericInstanceFieldLayout.LayoutOf` luôn bắt đầu ở `2 * pointerSize`, tức có kèm object
header. CLAUDE.md đã ghi cả hai nửa của điều này cho phép ghép trivial accessor. **Chưa được kiểm
chứng**, và phải kiểm chứng trước khi làm gì, vì nếu giả định header của chính công cụ chẩn đoán
sai thì 48 con số này là do nó bịa ra chứ không phải resolver bỏ sót.

## 8. Tuyệt đối không nên patch tiếp

- **Không** nới `BaseChainFieldSearch` để nhận field mà mắt xích không khai báo. Đó đúng là giả
  thuyết 3.2 và nó đáng 186 lỗi trên Pinata.
- **Không** dùng số lỗi Roslyn của ACTk.Runtime làm thước đo: file trong đó có lỗi parse có sẵn, và
  Roslyn dừng ở parse nên mọi lỗi thân hàm phía sau không được báo.
- **Không** xử lý nhóm `RESOLVABLE` value type bằng cách cộng thêm 0x10 ở chỗ so sánh. Nhập nhằng
  offset-0 đã bị loại ba lần (iteration 036, 037, 038); phải chứng minh giả định header trước.

# Từ APK/IPA tới Unity project chạy được — tình trạng đo được

Cập nhật iteration 045. Mọi ô là **đo được**; chỗ không đo được ghi `NOT_RUN` hoặc `UNKNOWN`, không
ghi `PASS`.

Dựng lại: `Test/Scripts/validate_unity_project.py <project>` và
`Test/Scripts/audit_script_references.py <rip output>`.

## 1. Ma trận theo layer

| Layer | Impostor (ARM64, 2022.3) | Pinata (x86, 2019.2) | Bằng chứng |
|---|---|---|---|
| Giải nén container | PARTIAL | PARTIAL | Đầu vào là thư mục đã giải nén, không phải `.apk`/`.ipa`. |
| Chọn ABI | UNKNOWN | n/a | Log không nói vì sao chọn arm64-v8a. |
| Unity version | **PASS** | **PASS** | `ProjectVersion.txt` = 2022.3.62f2 / 2019.2.6f1. |
| Metadata IL2CPP | **PASS** | **PASS** | v31.1 / v24.2. |
| Binary IL2CPP | **PASS** | **PASS** | genFail 0 cả hai. |
| Cấu trúc project | **PASS** | **PASS** | Assets / ProjectSettings / Packages đủ; manifest 31 dependency. |
| Scripts | **PASS** | **PASS** | 819 / 3083 file `.cs`. |
| `.cs.meta` cho component | **PASS** | WARN | 155/155 kiểu component không generic có GUID; Pinata 2 kiểu không có, cả hai là hook chỉ `AddComponent` lúc chạy nên chưa từng được serialize. |
| Tham chiếu GUID | UNKNOWN | **PASS** | Impostor: 3 GUID / 4 chỗ không .meta nào khai báo, có thể thuộc package — không có editor thì không phân biệt được. |
| `m_Script` | **FAIL** | **FAIL** | 4 và 2 con trỏ script null. Mỗi cái mất hẳn component cùng mọi field. |
| Shader | WARN | WARN | 3 / 22 shader mang pass unlit thay thế. Nó **biên dịch được**. |
| Scene | **PASS** | **PASS** | 1 scene, có trong build list. |
| Import bằng Unity | NOT_RUN | NOT_RUN | Không có Unity trên máy này. |
| Build | NOT_RUN | NOT_RUN | idem. |
| Runtime | NOT_RUN | NOT_RUN | idem. |

## 2. Tham chiếu script gãy

`audit_script_references.py` kiểm tra 135 tham chiếu trên Impostor và 1993 trên Pinata.

| | Impostor | Pinata |
|---|---:|---:|
| Kiểm tra | 135 | 1993 |
| Gãy | **6** | 2 |
| UNRESOLVED (không ứng viên) | 4 | 2 |
| AMBIGUOUS (ứng viên chỉ theo tên) | 2 | 0 |

**Phép đếm cũ hụt một nửa.** Ma trận iteration 044 ghi "4 `m_Script` trỏ `fileID: 0`". Có sáu tham
chiếu gãy: bốn cái đó, cộng hai **GUID treo** — `GoogleMobileAdsSettings.asset` và
`AdvertisementManager.prefab` trỏ tới guid mà không `.cs.meta` nào khai báo. Lúc import thì hai dạng
gãy như nhau; đếm theo hình dạng của một dạng thì bỏ sót dạng kia.

Không có `AdsManager.cs`, `BaseTracking.cs` hay `Reporter.cs` nào được phục hồi. Kiểu script chúng
tham chiếu không có trong bản build, nên câu trả lời trung thực là **UNRESOLVED**. Bịa một GUID sẽ
làm console im lặng và component sai.

Thang bằng chứng cho một ứng viên, mạnh xuống yếu:
`GAMEOBJECT_NAME` → `DOCUMENT_NAME` → `*_CONFLICT` (script đó đã gắn sẵn trên chính GameObject ấy,
tức đây là một component **khác** — bằng chứng ngược). Công cụ báo ứng viên và **không bao giờ tự
áp dụng**.

## 3. Điểm số phục hồi, tách riêng

Không gộp thành một con số.

| Hạng mục | Impostor | Pinata |
|---|---|---|
| Script | **PASS** — 819 file, 96,06% method có thân thật | **PASS** — 3083 file |
| Behavior | PARTIAL — 2722 unresolved load, 348 lỗi Roslyn | PARTIAL — 9245 load, 1478 lỗi |
| Cấu trúc project | **PASS** | **PASS** |
| Tham chiếu | **FAIL** — 6 gãy | **FAIL** — 2 gãy |
| Shader | WARN — thay thế, không phải phục hồi | WARN |
| Import / Build / Runtime | NOT_RUN | NOT_RUN |

## 4. Ba lần công cụ tự báo FAIL sai

Đáng ghi vì cả ba cùng một kiểu: đọc **vắng mặt** thành **hỏng**.

1. `450 .cs.meta / 819 .cs` → "369 script mất GUID". Sai: một class thường không cần GUID.
2. Sửa lần một vẫn quá chặt: một `MonoBehaviour` chỉ được `AddComponent` lúc chạy chưa từng được
   serialize nên không có MonoScript để mà viết GUID.
3. `5 GUID không ai khai báo, 28 chỗ` → 24 chỗ là built-in resources của chính Unity
   (`0000000000000000f000000000000000`, `...e000000000000000`). Không project nào khai báo chúng.

Một phép kiểm tra quá chặt cũng sai như một phép kiểm tra quá lỏng, và nó tốn nhiều thời gian hơn.

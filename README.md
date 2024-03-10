# IEC-test-developer
### ưu điểm:
* Hệ thống có cấu trúc rõ ràng, các phần được phân chia trong các thư mục thuận tiện cho việc tìm kiếm.
### nhược điểm:
* Hệ thống thiết kế chưa được linh hoạt, các class liên kết cứng với nhau.
* Việc hạn chế sử dụng asset driven khiên cho việc config cũng như thay đổi các thuộc tính của game khó khăn.
* Sử dụng Resource.Load khiến việc quản lý tài nguyên không được kiểm soát.
* Phát sinh một số lỗi trong quá trình chơi.
### bổ xung:
* Thay thế các resource.load bằng refrence trực tiếp trên editor.
* Hệ thống lại, bóc tách các module, không viết quá nhiều chức năng trong một class.
* Các class quản lý hành vi của item nên được kế thừa trực tiếp từ monobihaviour và nên được gắn vào trong các prefab thay vì tạo mới class trong runtime.

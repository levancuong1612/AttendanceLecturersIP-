// Đặt ngày đếm ngược

var a = new Date().getDate();
var countDownDate = new Date(a + "20:20:00").getTime();
var c = new Date().getDate() + new Date( "20:20:00").getTime();
// Cập nhật đếm ngược sau mỗi 1 giây
var x = setInterval(function () {
    // Nhận ngày và giờ hôm nay
    var now = new Date().getTime();

    // Tìm khoảng cách giữa bây giờ và ngày đếm ngược
    var distance = countDownDate - now;

    // Tính toán thời gian cho ngày, giờ, phút và giây
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // Xuất kết quả trong phần tử có id = "demo"
    document.getElementById("demo").innerHTML = days + "d " + hours + "h"+ minutes + "m " + seconds + "s ";

    // Nếu quá trình đếm ngược kết thúc, hãy viết một số văn bản
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("demo").innerHTML = "THỜI GIAN ĐIỂM DANH ĐÃ HẾT!!!";
    }
}, 1000);
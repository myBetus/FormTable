$(window).on('load', function () {
    boslink();
    tcnokontrol();
});
var toastYonetici = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    onOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer);
        toast.addEventListener('mouseleave', Swal.resumeTimer);
    }
});
function tcnokontrol() {
    var checkTcNum = function (value) {
        value = value.toString();
        var isEleven = /^[0-9]{11}$/.test(value);
        var totalX = 0;
        for (var i = 0; i < 10; i++) {
            totalX += Number(value.substr(i, 1));
        }
        var isRuleX = totalX % 10 == value.substr(10, 1);
        var totalY1 = 0;
        var totalY2 = 0;
        for (var i = 0; i < 10; i += 2) {
            totalY1 += Number(value.substr(i, 1));
        }
        for (var i = 1; i < 10; i += 2) {
            totalY2 += Number(value.substr(i, 1));
        }
        var isRuleY = ((totalY1 * 7) - totalY2) % 10 == value.substr(9, 0);
        return isEleven && isRuleX && isRuleY;
    };


    $('input.validate-tc').on('keyup blur', function (event) {
        event.preventDefault();
        var isValid = checkTcNum($(this).val());
        if (!isValid) {
            if ($(this).val().length === 11) {
                $('#TxtTcNo').val('');
            }
        }
    });
}
function ButonYukleniyor(buttonid) {
    $("#" + buttonid).html("");
    $("#" + buttonid).prepend('<i id="BtnLoading" class="fas fa-redo fa-spin" style="display: none;"></i>&nbsp; Lütfen Bekleyiniz...');
    $("#BtnLoading").show();
    $('#' + buttonid).prop('disabled', true);
}
function boslink() {
    $('a[href="#"]').click(function (e) {
        //console.log("# Bos Link");
        e.preventDefault();
    });
}
function DevexpressTablo(s, e, okunacakveri, silinecekmesaj, silmelinki) {
    var id = s.GetRowKey(e.visibleIndex);
    if (e.buttonID === 'BtnDuzenle') {
        s.PerformCallback({ buttonName: "Düzenle", id: id });
    }
    else if (e.buttonID === 'BtnSlayt') {
        s.PerformCallback({ buttonName: "Slayt", id: id });
    }
    else if (e.buttonID === 'BtnSil') {
        s.GetRowValues(e.visibleIndex, 'Id;' + okunacakveri, function (values) {
            var token = document.getElementsByName("__RequestVerificationToken")[0].value;
            var adi = values[1];
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                html: "<span class='text-danger font-weight-bold'>'" +
                    adi +
                    "'</span> " +
                    silinecekmesaj +
                    " silinecek ister misiniz?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet',
                cancelButtonText: 'Hayır'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: "POST",
                        url: silmelinki + id,
                        data: {
                            __RequestVerificationToken: token
                        },
                        success: function (cevap) {
                            if (cevap === 'True') {
                                s.PerformCallback({ buttonName: "Sil", id: id });
                                Swal.fire(
                                    'Silindi',
                                    'İşlem başarılı',
                                    'success'
                                );
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Hata...',
                                    text: 'Silme işleminde sorun oluştu!',
                                    confirmButtonText: 'Kapat'
                                });
                            }
                        }
                    });
                }
            });
        });
    }
    else if (e.buttonID === 'BtnAktivasyon') {
        s.GetRowValues(e.visibleIndex, 'Id;' + okunacakveri, function (values) {

            var token = document.getElementsByName("__RequestVerificationToken")[0].value;
            var adi = values[1];
            Swal.fire({
                title: 'Üyeyi Aktivasyon İşlemleri',
                html: "<span class='text-danger font-weight-bold'>'" +
                    adi +
                    "'</span> " +
                    silinecekmesaj +
                    " üyenin aktivasyonu değiştirmek istermisiniz.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet',
                cancelButtonText: 'Hayır'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: "POST",
                        url: silmelinki + id,
                        data: {
                            __RequestVerificationToken: token
                        },
                        success: function (cevap) {
                            if (cevap === 'True') {
                                s.PerformCallback({ buttonName: "Aktivasyon", id: id });
                                Swal.fire(
                                    'Aktivasyon',
                                    'İşlem başarılı',
                                    'success'
                                );
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Hata...',
                                    text: 'Aktivasyon işleminde sorun oluştu!',
                                    confirmButtonText: 'Kapat'
                                });
                            }
                        }
                    });
                }
            });
        });
    }
    else if (e.buttonID === 'BtnDurumDuzenle') {
        $("#TxtSiparisDurumId").val(id);
        $("#ModelSiparisIslem").modal("show");
    }
    else if (e.buttonID === 'BtnSlaytIslemleri') {
        s.PerformCallback({ buttonName: "Slayt İşlemleri", id: id });
    }
    else if (e.buttonID === 'BtnAktifPasifYap') {
        s.GetRowValues(e.visibleIndex, 'Id;' + okunacakveri, function (values) {

            var token = document.getElementsByName("__RequestVerificationToken")[0].value;
            var adi = values[1];
            Swal.fire({
                title: 'Ürün Yorum İşlemleri',
                html: "<span class='text-danger font-weight-bold'>'" +
                    adi +
                    "'</span> " +
                    silinecekmesaj +
                    " yorumda değişiklik yapılsın mı.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet',
                cancelButtonText: 'Hayır'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: "POST",
                        url: silmelinki + id,
                        data: {
                            __RequestVerificationToken: token
                        },
                        success: function (cevap) {
                            if (cevap === 'True') {
                                s.PerformCallback({ buttonName: "Aktif veya Pasif Yap", id: id });
                                Swal.fire(
                                    'Aktivasyon',
                                    'İşlem başarılı',
                                    'success'
                                );
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Hata...',
                                    text: 'Aktivasyon işleminde sorun oluştu!',
                                    confirmButtonText: 'Kapat'
                                });
                            }
                        }
                    });
                }
            });
        });
    }
}
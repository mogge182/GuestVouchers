function test() {
    $.ajax({
        url: 'http://vouchertest.azurewebsites.net/voucher/getvoucher'
        //data: { id: id }
    }).done(function (value) {
        document.getElementById("Voucher").innerText = value;
    });
}

//http://localhost:52546/voucher/getvoucher
var account = {
    LogOut: function () {
        $.ajax({
            url: './Index?handler=LogOut'
        }).done(function (result) {
            window.location.replace('../Account/Login')
        });
    }
}
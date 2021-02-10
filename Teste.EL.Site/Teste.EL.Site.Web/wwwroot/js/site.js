function chamadaAjax(url, parametros, callbackSucesso, callbackErro, async, naoExibirCarregando) {
    $.ajax({
        type: "POST",
        url: url,
        cache: false,
        data: JSON.stringify(parametros),
        dataType: 'html',
        traditional: true,
        contentType: 'application/json',
        async: async,
        beforeSend: function () {
            if (!naoExibirCarregando) {
                exibirCarregando();
            }
        },
        complete: function () {
            if (!naoExibirCarregando) {
                esconderCarregando();
            }
        },
        success: function (args) {
            callbackSucesso(args);
        },
        error: function (reqObj, tipoErro, mensagemErro) {
            if (callbackErro) {
                callbackErro(tipoErro, mensagemErro)
            }
        }
    });
}

function exibirCarregando() {
    $('.carregando').show();
}

function esconderCarregando() {
    $('.carregando').hide();
}
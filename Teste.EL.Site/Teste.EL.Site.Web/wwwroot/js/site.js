function chamadaAjaxPOST(url, parametros, callbackSucesso, callbackErro, async, naoExibirCarregando) {
    $.ajax({
        type: "POST",
        url: url,
        cache: false,
        data: typeof (parametros) === "object" ? JSON.stringify(parametros) : parametros,
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

function chamadaGET(url, parametros, callbackSucesso, callbackErro, async, naoExibirCarregando) {
    jQuery.get(url, parametros, callbackSucesso, 'html');
}

function exibirCarregando() {
    $('.carregando').show();
}

function esconderCarregando() {
    $('.carregando').hide();
}
var Home = Home || (function () {

    function aoAlterarCategoria() {
        var categoriaSelecionada = $('#ListaCategorias').children("option:selected").val();

        chamadaGET(
            Home.UrlListarPorCategoria,
            { categoria: categoriaSelecionada },
            listarVeiculosSucesso
        );
    }

    function listarVeiculosSucesso(data) {
        if (data) {
            $('#listagem-veiculo').html(data);
            $('#listagem-veiculo').load();
        }
    }

    return {
        aoAlterarCategoria: aoAlterarCategoria
    };
})();
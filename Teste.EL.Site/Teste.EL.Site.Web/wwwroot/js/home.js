var Home = Home || (function () {

    function aoAlterarCategoria() {
        var categoriaSelecionada = $('#ListaCategorias').children("option:selected").val();

        chamadaAjax(
            Home.UrlListarPorCategoria,
            { categoriaSelecionada: categoriaSelecionada },
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
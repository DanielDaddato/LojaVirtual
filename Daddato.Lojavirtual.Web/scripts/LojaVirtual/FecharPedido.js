
$('#Cep').change(function (e) {
    e.preventDefault();

    var cep = $('#Cep').val().replace('-','');
    $("#Endereco").val('');
    $("#Bairro").val('');
    $("#Cidade").val('');
    $("#Estado").val('');
    $("#UF").val('');
    $.getJSON("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep + "&formato=json", function (dados) {

        aUf = dados.uf;
        aEstado = dados.estado;
        aCidade = dados.cidade;
        aBairro = dados.bairro;
        aLogradouro = dados.tipo_logradouro + ' ' + dados.logradouro;

        //Escreve nos campos
        $("#Endereco").val(aLogradouro);
        $("#Bairro").val(aBairro);
        $("#Cidade").val(aCidade);
        $("#Estado").val(aEstado);
        $("#UF").val(aUf);

    }).fail(function ()
    {
        alert("Ocorreu um erro inesperado durante o processamento.");
    });
    //$.ajax({
    //    method: "GET",
    //    url: '../Carrinho/ConsultaCEP?cep='+cep,
    //    dataType:'json',
    //    success: function (dados) {
    //        var retorno = JSON.parse(dados);
    //        aUf = retorno.uf;
    //        aEstado = retorno.estado;
    //        aCidade = retorno.cidade;
    //        aBairro = retorno.bairro;
    //        aLogradouro = retorno.logradouro;

    //        //Escreve nos campos
    //        $("#Endereco").val(aLogradouro);
    //        $("#Bairro").val(aBairro);
    //        $("#Cidade").val(aCidade);
    //        $("#Estado").val(aEstado);
    //        $("#UF").val(aUf);
    //    },
    //    error: function () {
    //        alert("Ocorreu um erro inesperado durante o processamento.");
    //    }
    //});
});
var j = jQuery.noConflict();

const paramets = {
    dataDe: "",
    dataAte: "",
    fornecedorId: "",
    materialId: "",
    tipoOperacao: ""
};

var errors = [];

j(document).ready(function () {
    Gerar();
})

function Gerar() {
    j('#gerar').on('click', async function () {
        paramets.dataDe = j('#dataDe').val();
        paramets.dataAte = j('#dataAte').val();
        paramets.fornecedorId = j('#fornecedorId').val();
        paramets.materialId = j('#materialId').val();
        paramets.tipoOperacao = j('#tipoOperacao').val();
        const response = await j.post('/Relatorio/Gerar', paramets).fail(function (error) {
            errors = error.responseJSON;
            if (errors.length > 0) {
                errors.map((item) => appendAlert(item.errorMessage, 'danger'))
            }
        });
        console.log(response);
        j("#tabela").append(`<table class='table'> 
            <thead> 
            <tr> 
            <th rowspan='2' class='text-center'>Material/Data</th> 
            <th colspan='2' class='text-center'>Entradas</th> 
            <th colspan='2' class='text-center'>Saidas</th> 
            <th colspan='2' class='text-center'>Saldo</th> 
            </tr> 
            <tr> 
            <th>Quant</th> 
            <th>Valor</th> 
            <th>Quant</th> 
            <th>Valor</th> 
            <th>Quant</th> 
            <th>Valor</th> 
            </tr> 
            </thead> 
            <tbody>
            ${response.dados.map((item) => {
                return `
                <tr>
                <th>${item.material.codigo}</th>
                ${item.valores.map((val) => val.tipoOperacao == 'Entrada' ? `<th>${val.quantidade}</th><th>${val.valor}</th>` : `<th>${val.quantidade}</th><th>${val.valor}</th><th></th><th></th>`)}
                
                </tr>
                
                ${item.valores.map((val) => val.tipoOperacao == 'Saida' ? `<tr><td>${val.data}</td><td>${val.quantidade}</td><td>${val.valor}</td><td></td><td></td><td></td><td></td></tr>` : `<tr><td>${val.data}</td><td></td><td></td></td><td>${val.quantidade}</td><td>${val.valor}<td></td><td></td></tr>`)}
                `

            })}
            </tbody> 
            </table>`
        )
        //response.dados.map((item) => {
        //    return `

        //        <tr>
        //        <td>${item.material.codigo}</td>
        //        ${item.valores.map((val) => val.tipoOperacao == 'Entrada' ? `<td>${val.quantidade}</td><td>${val.valor}</td>` : ``)}
        //       ${item.valores.map((val) => val.tipoOperacao == 'Saida' ? `<td>${val.quantidade}</td><td>${val.valor}</td>` : ``)}
        //        </tr>

        //        ${item.valores.map((val) => {
        //        return `
        //            <tr>
        //            ${val.data}
        //            </tr>`
        //    })}
        //        `

        //}),
    })
}

const alertPlaceholder = document.getElementById('alerta')
const appendAlert = (message, type) => {
    const wrapper = document.createElement('div')
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        '</div>'
    ].join('')

    alertPlaceholder.append(wrapper)
}
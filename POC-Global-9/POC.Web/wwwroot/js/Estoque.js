var j = jQuery.noConflict();

const paramets = {
    id: 0,
    data: "",
    fornecedorId: "",
    materialId: "",
    quantidade: 0,
    valor: 0,
    tipoOperacao: ""
};

var errors = [];

j(document).ready(function () {
    Salvar();
    Formatacao();
})

function Formatacao() {
    j('#quantidade').on('keyup', function () {
        var format = parseFloat(j(this).val().replace(/\D/g, ''), 10);
        if (format.toLocaleString() == "NaN") {
            j(this).val(0);
        } else {
            j(this).val(format.toLocaleString());
        }
    })
}

function Salvar() {
    j('#salvar').on('click', async function () {
        paramets.id = j('#id').val();
        paramets.data = j('#data').val();
        paramets.fornecedorId = j('#fornecedorId').val();
        paramets.materialId = j('#materialId').val();
        paramets.quantidade = j('#quantidade').val();
        paramets.valor = j('#valor').val();
        paramets.tipoOperacao = j('#tipoOperacao').val();
        const response = await j.post('/Estoque/Inserir', paramets).fail(function (error) {
            errors = error.responseJSON;
            if (errors.length > 0) {
                errors.map((item) => appendAlert(item.errorMessage, 'danger'))
            }
        });

        if (response.sucesso) {
            appendAlert(response.message, 'success')
            refresh()
        } else {
            appendAlert(response.message, 'danger')
        }
    })
}

function Modal(id) {
    j('#modalExcluir').modal('show')
    j('#idEstoque').val(id);
}

async function Excluir() {
    const response = await j.get(`/Estoque/Deletar?id=${j('#idEstoque').val()}`).fail(function (error) {
        errors = error.responseJSON;
        if (errors.length > 0) {
            errors.map((item) => appendAlert(item.errorMessage, 'danger'))
        }
    });

    if (response.sucesso) {
        j('#modalExcluir').modal('hide')
        appendAlert(response.message, 'success')
        refresh()
    } else {
        appendAlert(response.message, 'danger')
    }
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

function refresh() {
    var link = window.location.href.split("/");
    setTimeout(() => {
        window.location.href = `${link[0]}//${link[2]}/${link[3]}`
    }, 2000)
}
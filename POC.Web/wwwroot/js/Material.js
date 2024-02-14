var j = jQuery.noConflict();

const paramets = {
    id: 0,
    codigo: "",
    nomeMaterial: "",
    unidadeMedida: ""
};

var errors = [];

j(document).ready(function () {
    Salvar();
})

function Salvar() {
    j('#salvar').on('click', async function () {
        paramets.id = j('#id').val();
        paramets.codigo = j('#codigo').val();
        paramets.nomeMaterial = j('#nomeMaterial').val();
        paramets.unidadeMedida = j('#unidadeMedida').val();
        const response = await j.post('/Material/Inserir', paramets).fail(function (error) {
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
    })
}

function Modal(id) {
    j('#modalExcluir').modal('show')
    j('#idMaterial').val(id);
}

async function Excluir() {
    const response = await j.get(`/Material/Deletar?id=${j('#idMaterial').val()}`).fail(function (error) {
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
function FornecedorValidateScripts() {

    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }

    toastr.options = {
        "closeButton": false,
        "debug": true,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    $('#PeriodoVigenciaInicio').datepicker({
        format: "dd/mm/yyyy",
        endDate: "today",
        language: "pt-BR",
        orientation: "bottom right",
        autoclose: true
    });

    $('#PeriodoVigenciaFim').datepicker({
        format: "dd/mm/yyyy",
        endDate: "today",
        language: "pt-BR",
        orientation: "bottom right",
        autoclose: true
    });



    $(document).ready(function () {
        var $inputAtivo = $("#Ativo");

        MostrarPeriodoVigenciaFim();

        $inputAtivo.click(function () {
            MostrarPeriodoVigenciaFim();
        });

        function MostrarPeriodoVigenciaFim() {
            if ($inputAtivo.is(":checked")) $("#PeriodoVigenciaFimForm").hide();
            else $("#PeriodoVigenciaFimForm").show();
        }
    });
}

function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#ContatoTarget').load(result.url);
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });
}

function Refresh() {
    location.reload();
}

function FornecedorMasks() {
    $(document).ready(function () {
        $('#ValorMaxDemanda').mask('#.##0,00', { reverse: true });
    });
}

function ContatoMasks() {
    $(document).ready(function () {
        $('#Telefone').mask('(00) 00000-0000')
    });
}
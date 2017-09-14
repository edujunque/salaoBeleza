
$(function () {
    $('#datetimepicker12').datetimepicker({
        inline: true,
        sideBySide: false,
        format: 'L',
    });
    $('#datetimepicker12').on('dp.change', function (event) {
        //console.log(moment(event.date).format('MM/DD/YYYY h:mm a'));
        //console.log(event.date.format('MM/DD/YYYY h:mm a'));
        $('#selected-date').text(event.date);
        var formatted_date = event.date.format('DD/MM/YYYY');
        $('#my_hidden_input').val(formatted_date);
        //$.ajax({
        //    url: "/Home/CarregaCalendario?dataFiltro=" + $('#my_hidden_input').val(),
        //    success: function () {
        //        //alert("success");
        //        reloadCalendar($('#my_hidden_input').val());
        //    }
        //});
        reloadCalendar($('#my_hidden_input').val());
    });
    function reloadCalendar(filtroData) {
        //$('#containerDivCalendar').load("CarregaCalendario?dataFiltro=" + filtroData);
        $('#containerDivCalendar').load("CarregaCalendario?dataFiltro=" + filtroData);
    }
});

//$("#datetimepicker12").datepicker({
//    altField: "#actualDate"
//});

//$('#datepicker').datepicker({
//    inline: true,
//    altField: '#hiddenFieldID',
//    onSelect: function () {
//        $('#myFormID').submit();
//    }
//});

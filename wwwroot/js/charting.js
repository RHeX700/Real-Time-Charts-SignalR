"use strict";

var lineChart = new Chartist.Line('#chartArea', {
    labels: [],
    series: [[]]
},
    {
        low: 0,
        showArea: true
    }
);

var connection = new signalR.HubConnectionBuilder().withUrl('/chartHub').build();
document.getElementById('sendButton').disabled = true;

connection.on("ValueReceiver", chartValue => {
    if (chartValue && !isNaN(chartValue)) {
        lineChart.data.series[0].push(chartValue);
        lineChart.update();

        document.getElementById("valueInput").value = "";
        document.getElementById("valueInput").focus();
    }
});

connection.start().then(() => {
    document.getElementById("sendButton").disabled = false;
}).catch(err => {
    console.error(err.toString());
})

document.getElementById("sendButton").addEventListener("click", function
(event) {
    var strValue = document.getElementById("valueInput").value;
    var chartValue = parseFloat(strValue);
    connection.invoke("ValueSender", chartValue).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

$('#valueInput').keypress(function (e) {
    var key = e.which;
    if (key === 13) // the enter key code.
    {
        $('#sendButton').click();
        return false;
    }
}); 
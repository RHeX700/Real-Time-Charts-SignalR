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
// document.getElementById('sendButton').disabled = true;

connection.on("ValueReceiver", chartObject => {
    var chartValue = JSON.parse(chartObject)["5. Exchange Rate"];

    if (chartValue && !isNaN(chartValue)) {
        lineChart.data.series[0].push(chartValue);
        lineChart.update();
    }
});

connection.start().then(() => {
    // document.getElementById("sendButton").disabled = false;
}).catch(err => {
    console.error(err.toString());
})

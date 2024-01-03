"use strict";

var lineChart = new Chartist.Line('#chartArea', {
    labels: [],
    series: [[],[],[]]
},
    {
        showArea: true
    }
);

var connection = new signalR.HubConnectionBuilder().withUrl('/chartHub').build();
// document.getElementById('sendButton').disabled = true;

connection.on("ValueReceiver", chartObject => {
    var chartValue = JSON.parse(chartObject);
    var ask = chartValue["Realtime Currency Exchange Rate"]["9. Ask Price"];
    var rate = chartValue["Realtime Currency Exchange Rate"]["5. Exchange Rate"];
    var bid = chartValue["Realtime Currency Exchange Rate"]["8. Bid Price"];

    if (rate && !isNaN(rate)) {
        lineChart.data.series[0].push(ask);
        lineChart.data.series[1].push(rate);
        lineChart.data.series[2].push(bid);
        lineChart.update();
    }
});

connection.start().then(() => {
    // document.getElementById("sendButton").disabled = false;
    console.log("Socket connection established successfully");
}).catch(err => {
    console.error(err.toString());
})

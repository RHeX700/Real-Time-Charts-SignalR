using Microsoft.AspNetCore.SignalR;

namespace Real_Time_Charts_SignalR.Hubs;

public class ChartHub : Hub<IChartClient>
{
    public async Task ValueSender(double chartValue)
    {
        await Clients.All.ValueReceiver(chartValue);
    }
}
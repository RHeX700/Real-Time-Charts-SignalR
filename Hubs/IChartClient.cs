namespace Real_Time_Charts_SignalR.Hubs;

public interface IChartClient
{
    Task ValueReceiver(double chartValue);
}
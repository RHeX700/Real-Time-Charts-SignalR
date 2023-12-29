using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace Real_Time_Charts_SignalR.Models;

public partial class ChartUpdateClient : Window
{
    HubConnection connection;

    public ChartUpdateClient(string url){
        
    }
}
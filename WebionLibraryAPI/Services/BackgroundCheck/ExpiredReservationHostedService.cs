namespace WebionLibraryAPI.Service.BackgroundCheck;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebionLibraryAPI.Service.Interfaces;
/// <summary>
/// Classe dedicata all controllo dello stato delle prenotazioni, esegue il metodo <see cref="CheckExpiredReservationsAsync"/>
/// ad ogni avvio dell'app.
/// </summary>
public class ExpiredReservationHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public ExpiredReservationHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var reservationService = scope.ServiceProvider.GetRequiredService<IReservationService>();

        await reservationService.CheckExpiredReservationsAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

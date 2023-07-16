﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SOC.IoTBase.Infrastructure;
using SOC.IoTBase.Interfaces;

namespace SOC.IoTBase.Services;

public class StartupService : IStartupService
{
    private readonly ILogger<StartupService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public StartupService(ILogger<StartupService> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;

        _logger.LogInformation("Resolving Zigbee services.");

        using var scope = _scopeFactory.CreateScope();
        var zigbeeService = scope.ServiceProvider.GetRequiredService<IZigbeeService>();

        if (zigbeeService is null)
            throw new InvalidOperationException($"Could not resolve {nameof(IZigbeeService)}");

        zigbeeService.DiscoverDevicesAsync();
    }
}

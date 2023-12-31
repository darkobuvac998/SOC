﻿using Newtonsoft.Json;

namespace SOC.IoTBase.Infrastructure.Zigbee.Properties;

internal record BinaryProperty
{
    [JsonProperty("value_on")]
    public object ValueOn { get; init; }

    [JsonProperty("value_off")]
    public object ValueOff { get; init; }

    [JsonProperty("value_toggle")]
    public object ValueToggle { get; init; }
}

﻿using Newtonsoft.Json.Linq;
using SOC.IoTDomain.Entity;

namespace SOC.IoTBase.Infrastructure.Zigbee.Parsers;

internal static class ContactParser
{
    public static DeviceContact? ParseContact(this DeviceDescription description, JObject payload)
    {
        var contact = payload["contact"];

        if (payload is null || contact is null || !description.BinaryValues.ContainsKey("contact"))
            return null;

        var contactValue = description.BinaryValues["contact"];
        contactValue.SetValue(contact.ToObject<object>()!);

        return new DeviceContact { Value = contactValue.Value };
    }
}

﻿namespace Domain.Entities;

public class RabbitMqConfig
{
    public string HostName { get; set; } = "localhost";
    public string QueueName { get; set; } = "myqueue";
}
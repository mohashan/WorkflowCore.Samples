﻿using WorkflowCore.Samples.GettingStarted.Workflows;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Samples.GettingStarted.Workflows.AddNumbers;

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddWorkflow()
    .BuildServiceProvider();

var host = serviceProvider.GetService<IWorkflowHost>();

if(host == null )
    throw new Exception("Host not initialized");

host.RegisterWorkflow<HelloWorldWorkflow>();
host.RegisterWorkflow<AddNumbersWorkflow,MyDataClass>();

host.Start();

host.StartWorkflow("HelloWorld");
host.StartWorkflow("AddNumbers");

Console.ReadLine();
host.Stop();


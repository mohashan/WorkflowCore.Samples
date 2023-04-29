using Microsoft.Extensions.DependencyInjection;
using System;
using WorkflowCore.Interface;

namespace WorkflowCore.Samples.SharedDependency
{
    public class WorkflowSharedLibrary
    {
        private IServiceProvider _service;
        private IServiceCollection _serviceCollection;

        public WorkflowSharedLibrary()
        {
            _serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddWorkflow();

            _service = _serviceCollection.BuildServiceProvider();
        }
        public IWorkflowHost Host()
        {

            var host = _service.GetService<IWorkflowHost>();
            if (host == null)
                throw new Exception("Host is not initialized properly");

            return host;
        }

        public IWorkflowHost Host(IServiceCollection serviceCol)
        {
            var service = serviceCol.BuildServiceProvider();
            var host = service.GetService<IWorkflowHost>();
            if (host == null)
                throw new Exception("Host is not initialized properly");

            return host;
        }

        public IServiceProvider Service
        {
            get { return _service; }
        }

        public IServiceCollection serviceCollection
        {
            get { return _serviceCollection; }
        }

    }
}
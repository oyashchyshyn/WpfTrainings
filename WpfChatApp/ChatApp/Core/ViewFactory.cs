using System;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Core
{
    public class ViewFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Get<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
﻿using Microsoft.Extensions.DependencyInjection;

namespace FindExactSolution.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}

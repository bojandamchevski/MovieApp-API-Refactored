using BojanDamchevski.MovieApp.DataAccess;
using BojanDamchevski.MovieApp.DataAccess.Implementations;
using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using BojanDamchevski.MovieApp.Services.Impementations;
using BojanDamchevski.MovieApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BojanDamchevski.MovieApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieAppRefactoredDbContext>(x =>
                x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Director>, DirectorRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IDirectorService, DirectorService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}

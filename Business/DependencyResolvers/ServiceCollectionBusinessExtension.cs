using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core.Utilities.Security.JWT;

namespace Business.DependencyResolvers;

public static class ServiceCollectionBusinessExtension
{
    // Extension method
    // Metodun ve barındığı class'ın static olması gerekiyor
    // İlk parametere genişleteceğimiz tip olmalı ve başında this keyword'ü olmalı.
    public static IServiceCollection AddBusinessServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        
        services.AddScoped<ITokenHelper, JwtTokenHelper>();
        
        services
            .AddScoped<IBrandService, BrandManager>()
            .AddScoped<IBrandDal, EfBrandDal>()
            .AddScoped<BrandBusinessRules>();
        
        services
            .AddScoped<IModelService, ModelManager>()
            .AddScoped<IModelDal, EfModelDal>()
            .AddScoped<ModelBusinessRules>(); 

        services
            .AddScoped<ICarService, CarManager>()
            .AddScoped<ICarDal, EfCarDal>()
            .AddScoped<CarBusinessRules>();
        
        services
            .AddScoped<IUserService, UserManager>()
            .AddScoped<IUserDal, EfUserDal>()
            .AddScoped<UserBusinessRules>();
        
        services
            .AddScoped<ICustomerService, CustomersManager>()
            .AddScoped<ICustomersDal, EfCustomersDal>()
            .AddScoped<CustomersBusinessRules>();
        
        services
            .AddScoped<IIndividualCustomerService, IndividualCustomersManager>()
            .AddScoped<IIndividualCustomerDal, EfIndividualCustomerDal>()
            .AddScoped<IndividualCustomersManager>();
        
        services
            .AddScoped<ICorporateCustomerService, CorporateCustomerManager>()
            .AddScoped<ICorporateCustomerDal, EfCorporateCustomerDal>()
            .AddScoped<CorporateCustomerBusinessRules>();

        
        
        // Singleton: Tek bir nesne oluşturur ve herkese onu verir.
        // Ek ödev diğer yöntemleri araştırınız.

        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper.Extensions.Microsoft.DependencyInjection NuGet Paketi
        // Reflection yöntemiyle Profile class'ını kalıtım alan tüm class'ları bulur ve AutoMapper'a ekler.

         //FluendValidayion.DependencyInhectionExtensions
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        services.AddDbContext<RentACarContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("RentACarMSSQL22")));
        
        services
            .AddScoped<IUserService, UserManager>()
            .AddScoped<IUserDal, EfUserDal>();
        
        return services;
    }
}
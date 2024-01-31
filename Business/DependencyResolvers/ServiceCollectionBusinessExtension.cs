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
        services
            .AddScoped<IBrandService, BrandManager>()
            .AddScoped<IBrandDal, InMemoryBrandDal>()
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
            .AddScoped<IUsersService, UsersManager>()
            .AddScoped<IUsersDal, EfUsersDal>()
            .AddScoped<UsersBusinessRules>();
        
        services
            .AddScoped<ICustomerService, CustomersManager>()
            .AddScoped<ICustomersDal, EfCustomersDal>()
            .AddScoped<CustomersBusinessRules>();
        
        services
            .AddScoped<IIndividualCustomerService, IndividualCustomersManager>()
            .AddScoped<IIndividualCustomerDal, EfIndividualCustomerDalDal>()
            .AddScoped<IndividualCustomersManager>();
        
        services
            .AddScoped<ICorporateCustomerService, CorporateCustomerManager>()
            .AddScoped<ICorporateCustomerDal, EfCorporateCustomerDalDal>()
            .AddScoped<CorporateCustomerBusinessRules>();

        
        
        // Singleton: Tek bir nesne oluşturur ve herkese onu verir.
        // Ek ödev diğer yöntemleri araştırınız.

        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper.Extensions.Microsoft.DependencyInjection NuGet Paketi
        // Reflection yöntemiyle Profile class'ını kalıtım alan tüm class'ları bulur ve AutoMapper'a ekler.

         //FluendValidayion.DependencyInhectionExtensions
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        services.AddDbContext<RentACarContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("RentACarMSSQL22")));
        
        return services;
    }
}
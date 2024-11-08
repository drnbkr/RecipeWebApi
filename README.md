# RecipeApp

RecipeApp, kullanıcıların yemek tarifleri ekleyip paylaşabileceği bir uygulamadır. Kullanıcılar tariflerine malzemeler ekleyebilir ve tarifleri kategorilere ayırabilir.

## Özellikler

- Kullanıcılar yemek tarifleri ekleyebilir.
- Tariflere malzemeler eklenebilir.
- Tarifler kategorilere ayrılabilir.
- Kullanıcılar tarifleri görüntüleyebilir ve arayabilir.

## Model Ekleme

### Yeni Model Ekleme Adımları

1. **Model Dosyasını Oluşturma**:

   - `Entities.Models` klasörüne yeni bir c# dosyası ekleyin. Örneğin, `Ingredient.cs`.

2. **Model Sınıfını Tanımlama**:
   Tabloda olması gereken alanlar eklenir.
   Gerekli olan Dto'lar record olarak tanımlanır.
   Record içinde değiştirilemez alanlar {get; init;} olarak tanımlanır(Mesela Id).
3. **Config Dosyası Oluşturma**:
   - `Repositories.EFCore.Config` içerisine yeni bir c# dosyası ekleyin. Örneğin, `IngredientConfig.cs`.
4. **DbSet oluşturma**

   - `Repositories.EFCore.RepositoryContext` içine yeni DbSet tanımlanır. Örneğin, `public DbSet<Ingredient> Ingredients { get; set; }`

5. **Veritabanı Bağlantısını Güncelleme**:

   - yeni migrasyon dosyası oluşturun. Örneğin; `dotnet ef migrations add addIngredientModel`
   - veritabanını güncelleyin. `dotnet ef database update`

## CRUD işlemleri

### Repositories İşlemleri

1. **Repository Contract Oluşturma**

   - `Repositories.Contracts` içerisine yeni bir c# dosyası ekleyin. Örneğin; `IIngredientRepository.cs`
   - `IRepositoryBase`'den kalıtım alın
   - `Repositories.Contracts` altındaki `IRepositoryManager.cs` içindeki IRepositoryManager'a ekleyin. Örneğin;
     ```
         public interface IRepositoryManager
         {
             IIngredientRepository Ingredient { get; }
             Task SaveAsync();
         }
     ```
   - `RecipeWebApi.Extensions` içindeki `ServicesExtensions.cs` içindeki RegisterRepositories configürasyonuna scope'u ekliyoruz. Örneğin; `services.AddScoped<IIngredientRepository, IngredientRepository>();` (ioC'ye eklemiş oluyoruz)
   - `Repositories.EFCore` altındaki `RepositoryManager.cs` içindeki RepositoryManager classı içine oluşturduğumuz interface'in implementasyonunu gerçekleştirin.
   - Request parametresi ihtiyacı varsa `Entities.RequestFeatures` içine yeni c# dosyası ekleyin. Örneğin; `IngredientParameters.cs`

2. **Repository Oluşturma**
   - `Repositories.EFCore` içerisine yeni bir c# dosyası ekleyin. Örneğin; `IngredientRepository.cs` -`IngredientRepository.cs` içerisinde `RepositoryBase<T>` ve kendi abstrac classından inherit olan Repository clasını oluşturun. Örneğin; `IngredientRepository : RepositoryBase<Ingredient>,IIngredientRepository`
   - `IngredientRepository.cs` içerisinde IngredientRepositor clasında gerekli crud işlemlerini yapın.
   - EfCore extensions'ları gerekliyse mesala search,order, filter vs gibi, `Repositories.EFCore.Extensions` altına yeni bir c# extensions dosyası ekleyip burada yapılandırın.Örneğin; `IngredientRepositoryExtensions.cs`

### Services İşlemleri

1. **Services Contract Oluşturma**
   - `Services.Contracts` içerisinde yeni bir c# dosyası ekleyin. Örneğin; `IIngredientService.cs`
   - `IIngredientService.cs` içierinde bir interface oluşturun. Örneğin `public interface IIngredientService`
   - `Services.Contracts` içerisindeki `IServiceManager.cs` deki  IServiceManager içinde  oluştur.Örneğin; `IIngredientService IngredientService { get; }`
    - `Services` içindeki `ServiceManager.cs` içinde ServiceManager classına implement et.

2. **Service Manager Oluşturma**
    - `Services` içinde yeni bir c# dosyası ekleyin. Örneğin; `IngredientManager.cs`
    - Kendi abstract classından kalıtım alıp  bir manager(service) sınıfı oluşturun. Örneğin; `public class IngredientManager : IIngredientService`
    - Kalıtımla gelen tüm üyeleri implement edin.
    - constructor oluşturup, oluşturulacak fonksiyonlar için  gerekli diğer tüm servicelerin ve managerlerin DI(bağımlılıkları enjekte edin) işlemlerini gerçekleştirin.
    - CRUD ve iş mantığı için gerekli fonksiyonları oluşturun.(logger,mapper,get,update,creta manupulate vs.)
    - `RecipeWebApi.Extensions` içinde `ServicesExtensions` içinde RegisterServices configürasyonuna scope'u ekliyoruz. Örneğin; `services.AddScoped<IIngredientService, IngredientManager>();`


### Presentation İşlemleri

1. **Controller Oluşturma**
    - `Presentation.Controllers` içinde controller için bir c# dosyası ekleyin. Örneğin; `IngredientsController.cs`
    - `ControllerBase` sınıfından kalıtım alan bir class oluşturun. Örneğin; `public class RecipesController : ControllerBase`
    - Gerekli endpointleri oluşturun.
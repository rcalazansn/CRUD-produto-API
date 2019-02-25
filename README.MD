https://www.nuget.org/
    EntityFramework Core
    https://www.nuget.org/packages/Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore --version 2.2.1

Adicionar conexão SQL
    "ConnectionStrings": {
        "ProdutoSQL": "Server=localhost,11433;Database=loja;User Id=sa;Password=Pass08TI;"
    }

    services.AddDbContext<ProdutoContext>(options => options
        .UseSqlServer(Configuration.GetConnectionString("ProdutoSQL")));

https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/

    dotnet ef migrations add v0
    dotnet ef database update

aspnet core swagger  
    https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio  
    dotnet add package Swashbuckle.AspNetCore
    TESTAR=>https://localhost:5001/swagger

Criar Repositorios
    Pasta Repositories
    IBaseRepository->BaseRepository
    IProdutoRepository->ProdutoRepository

Adicionar Injeção de Dependencia
     services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
    services.AddTransient<IProdutoRepository, ProdutoRepository>();

Ajustar Contexto (salvar data inclusao e alteração)
     public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType()
                .GetProperty("Inclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Inclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Inclusao").IsModified = false;
                    entry.Property("Alteracao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    
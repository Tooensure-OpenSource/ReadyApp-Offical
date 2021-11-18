![Ready App Logo](/img/ReadyappByTooensure.jpg)
# The Ready App | From Tooensure

## Description

The *Ready app* is a eccomerce mobile application allowing consumers to place orders and entrepreneur's create busiesses and products with
much more features modern eccomerce app dosen't currently support.

The *Ready App* is a social science experiment allowing entrepreneurs, creators, inventors, and consumers to efficently act on trust and trade.

> **NOTE:** project still in its development stage. This repo will show you more on how to get up and running, less on our goal.

* Project practice
1. OOP (abstraction, encapsulation, inheritance, polymorphism)
2. Repository Pattern
3. Domain Driven
4. Data persistance
5. Design Pattern
6. Code best practice

### Getting Started

Let's get started getting the project up and running.

**Clone Project**

```https://github.com/Tooensure-OpenSource/ReadyApp-Offical.git```

**Restore project**

```dotnet restore```

**Run migrations**

Make sure you navigate to ``Ecommerce.Data`` folder ``DataConext.cs`` and change some configurations.

```c#
    // Comment this line out
    //public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) { }

    ..some code

    // Uncommit this code
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-EMFSR5P\\TOOENSURE;Initial Catalog=ReadyAppDb;Integrated Security=True");
    }
```

If your using VS 2022 or later you can open up the package manager and run

```Update-Database```

If in some case your using VSCode then most likely your using the terminal then

```dotnet tool install --global dotnet-ef```

then 

```dotnet tool update --global dotnet-ef```

now

```dotnet ef database update```

After migrations are ran change ``DataContext.cs`` back to it's original.

```c#
    // Uncommit
    public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) { }

    ..some code

    // Commit out this code
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-EMFSR5P\\TOOENSURE;Initial Catalog=ReadyAppDb;Integrated Security=True");
    //}
```

> NOTE: Make sure *Update-Database* is done within the **Ecommerce.Data** folder else it's likely to fail.

**Run the project**

Project contain mutiple project, the **Grpc Server** & the **Console Client**, both is needed to be ran in order to work.

```Dotnet run```

Greate now enjoy.

>Note: This repo doc will be emproved. Also these images are experimental and most likely will not go with design

![Ready App Logo](/img/Mobile1.png)
![Ready App Logo](/img/Mobile2.png)
![Ready App Logo](/img/Mobile3.png)
![Ready App Logo](/img/Mobile4.png)
![Ready App Logo](/img/Mobile5.png)
![Ready App Logo](/img/Mobile6.png)

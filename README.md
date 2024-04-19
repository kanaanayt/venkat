# Models

## Gender model
https://github.com/kanaanayt/venkat/blob/bcccd002a7579a06c639c2290a4861babc4c0f0a/src/EMS.Core/rGender.cs#L3-L10

## Employee model
https://github.com/kanaanayt/venkat/blob/bcccd002a7579a06c639c2290a4861babc4c0f0a/src/EMS.Core/rEmployee.cs#L3-L21

## Department model
https://github.com/kanaanayt/venkat/blob/bcccd002a7579a06c639c2290a4861babc4c0f0a/src/EMS.Core/rDepartment.cs#L3-L12

# Services

## Hardcoded data
### Constructor and fields
https://github.com/kanaanayt/venkat/blob/3182deb94a97abff51edc7844e7bdd35566ccfc1/src/EMS.Web/Services/HardCodedData.cs#L5-L17
### Department Initialization
https://github.com/kanaanayt/venkat/blob/3182deb94a97abff51edc7844e7bdd35566ccfc1/src/EMS.Web/Services/HardCodedData.cs#L19-L51
### Employee Initialization
https://github.com/kanaanayt/venkat/blob/3182deb94a97abff51edc7844e7bdd35566ccfc1/src/EMS.Web/Services/HardCodedData.cs#L53-L124

# Pages
## EmployeeList page
### Must place images in wwwroot/images folder
https://github.com/kanaanayt/venkat/blob/34d12b41d31b0c7413a5ac1ef017f805a67451ae/src/EMS.Web/Components/Pages/EmployeeList.razor#L5-L46

# API
#### Install the following
##### Microsoft.EntityFrameworkCore.Sqlite
##### Microsoft.EntityFrameworkCore.Tools
##### Microsoft.EntityFrameworkCore

#### set up project references and add appsettings.json connection string

## Gender entity
https://github.com/kanaanayt/venkat/blob/ca8c4719832805c647b6b9c7a51b977d07796fff/src/EMS.Core/eGender.cs#L3-L10
## Employee entity
https://github.com/kanaanayt/venkat/blob/ee8cb27550baab96904ecf09f6ed94d5d96481f6/src/EMS.Core/eEmployee.cs#L3-L20
## Department entity
https://github.com/kanaanayt/venkat/blob/ee8cb27550baab96904ecf09f6ed94d5d96481f6/src/EMS.Core/eDepartment.cs#L3-L10

## Db Context 
### Scaffolding
https://github.com/kanaanayt/venkat/blob/e950c6451aa1efea041c65f3cee1e5a7449b908a/src/EMS.Api/Data/CompanyDbContext.cs#L6-L22
### Seeding
https://github.com/kanaanayt/venkat/blob/91fdfd94831b8247bd16758ec6bf3d2d6f78371c/src/EMS.Api/Data/CompanyDbContext.cs#L24-L86
### Dependency Injection
https://github.com/kanaanayt/venkat/blob/40bcb478388c8491816365895cb124eeacd19e9e/src/EMS.Api/Program.cs#L10-L13

### Connection string
https://github.com/kanaanayt/venkat/blob/91fdfd94831b8247bd16758ec6bf3d2d6f78371c/src/EMS.Api/appsettings.json#L2-L4

### Migrate and update database
```
dotnet ef migrations add InitialCreate --project src/EMS.Api
dotnet ef database update --project src/EMS.Api
``` 

## Backend Repository
https://github.com/kanaanayt/venkat/blob/77d94fe02ca3f85812f36ec96ce4340b094a3d4b/src/EMS.Api/BackendRepository/ICompanyRepository.cs#L5-L20

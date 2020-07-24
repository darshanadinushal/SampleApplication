# SampleApplication

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools


DataBase First 
PM  >  Scaffold-DbContext "Data Source=DESKTOP-U67P0MO;Initial Catalog=Upworkdb;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Service/DBModel



https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell

Update the database (Execute in single line )

PM  >  Scaffold-DbContext "Data Source=DESKTOP-U67P0MO;Initial Catalog=adminportaldb; Trusted_Connection=True;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Infra/Models -UseDatabaseNames -Force -Context "AdminportaldbContext" -Schema "dbo"



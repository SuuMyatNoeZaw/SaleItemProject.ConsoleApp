using SaleProject.ConsloeApp;

SaleService sale=new SaleService();
//sale.Create();
//sale.Read();

SaleAdoDotNet dotnet=new SaleAdoDotNet();
//dotnet.Create();


DapperExample example=new DapperExample();
//example.Read();
//example.Edit();
//example.Create();

DapperShared dapper=new DapperShared();
//dapper.Read();
//dapper.Edit();
//dapper.Create();

SaleEFCoreExample saleEF=new SaleEFCoreExample();
//saleEF.Read();
//saleEF.Create();
saleEF.Edit();

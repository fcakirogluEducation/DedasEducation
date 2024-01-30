// See https://aka.ms/new-console-template for more information

using SOLID.App.SOLID.DIP;

Console.WriteLine("Hello, World!");


//DI, IOC , DI => IOC Container/ Dependency Injection Container : .Net Core API/MVC
var productRepository = new ProductRepository();
var productService = new ProductService(productRepository);
var productController = new ProductController(productService);


var products = productController.GetList();
products.ForEach(product => Console.WriteLine(product.Name));


productService.ChangeRepository(new ProductRepositoryWithOracle());

var products2 = productController.GetList();
products2.ForEach(product => Console.WriteLine(product.Name));

#region LSP

//Phone phone = new SmartPhone();
//phone.Call();

//if (phone is ITakePhoto smartPhone) smartPhone.TakePhoto();


//phone = new OldPhone();

//if (phone is ITakePhoto oldPhone)
//    oldPhone.TakePhoto();
//else
//    Console.WriteLine("bu telefonun foto özelliği yok");

//phone.Call(); 

#endregion

#region OCP

//var salaryCalculate = new SalaryCalculate();
//Console.WriteLine(
//    $"normal Salary:{salaryCalculate.CalculateWithDelegate(new NormalSalaryCalculate().Calculate, 1000)}");

//Console.WriteLine($"Super2 Salary:{salaryCalculate.CalculateWithDelegate(salary => salary * 50, 1000)}");

//Console.WriteLine($"normal Salary:{salaryCalculate.CalculateWithInterface(new NormalSalaryCalculate(),1000)}");

//Console.WriteLine($"super Salary:{salaryCalculate.CalculateWithInterface(new SuperSalaryCalculate(), 1000)}");

//Console.WriteLine($"normal Salary:{salaryCalculate.Calculate(1000, SalaryType.Normal)}"); 

#endregion
using CDEK_library;

string account = "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI";
string securePassword = "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG";

Guid citySendingFias = Guid.Parse("23089b45-5a51-4fe3-b1a0-d70aa7c4067f"); //Москва
Guid cityReceiverFias = Guid.Parse("0c5b2444-70a0-4932-980c-b4dc0d3f02b5"); //Тюмень

Package package = new Package(4000, 100, 100, 100);


DeliveryCostCalculator calculator = new DeliveryCostCalculator(account, securePassword);

float result = calculator.GetDeliveryCost(
               citySendingFias, cityReceiverFias,
               package);


City citySending = new CityFactory(account, securePassword, citySendingFias).City;
City cityReceiver = new CityFactory(account, securePassword, cityReceiverFias).City;


Console.WriteLine($"Стоимость отправки {result} рублей");
Console.WriteLine($"Посылки весом {package.Weight}гр габаритами {package.Length_mm}x{package.Height_mm}x{package.Length_mm} мм");
Console.WriteLine($"Из {cityReceiver.Name} в {citySending.Name}");

Console.ReadKey();

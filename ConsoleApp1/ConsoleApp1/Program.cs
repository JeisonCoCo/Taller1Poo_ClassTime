using ConsoleApp1;

try //cactura una parte para no tener horas no validas
{
    var t1 = new Time();
    var t2 = new Time(1, 1, 10);
    var t3 = new Time(10, 08, 13);
    Console.WriteLine($"The time {t1} ");
    Console.WriteLine($"The time2 {t2} ");
    Console.WriteLine($"The time3 {t3} ");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

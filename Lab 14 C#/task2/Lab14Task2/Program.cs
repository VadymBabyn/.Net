using System.Reflection;
using System;

Console.WriteLine("Введіть к-сть ефірів");
int q = int.Parse(Console.ReadLine());
var stream = new Stream[q];
for (int i = 0; i < q; i++)
{
    repitThis:
    try
    {
        Console.Write("Введіть назву ефіра: ");
        string name = Console.ReadLine();
        Console.Write("Введіть на якій частоті проходитиме ефір: ");
        double Chastota = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть дату початку ефіра: ");
        DateOnly DstartStream = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("Введіть час початку ефіра: ");
        TimeOnly TstartStream = TimeOnly.Parse(Console.ReadLine());
        Console.WriteLine("Введіть час завершення ефіра: ");
        TimeOnly TEndStream = TimeOnly.Parse(Console.ReadLine());
        Console.WriteLine("ВВедіть кількість переданих груп(5 символів): ");
        string CountGroup = Convert.ToString(Console.ReadLine());
        int n = CountGroup.Length;
        char[] CountsGroup = new char[n];
        for (int j = 0; j < CountGroup.Length; j++)
        {
            CountsGroup[j] = CountGroup[j];
        }
        stream[i] = new Stream(name, Chastota, DstartStream, TstartStream, TEndStream, CountsGroup);
    }
    catch (Exception)
    {
        Console.WriteLine("Error: НЕ коректно введено данні..");
        goto repitThis;
    }
    
}
Console.WriteLine("1. вивести інформацію про швидкість передачі груп за хвилину по кожному із сеансів;\n " +
    "2.ввести дату та два значення часу, організувати перегляд інформації про вихід радистів на зв'язок для введеної дати на вказаному інтервалі часу;\n" +
    "3.ввести номер місяця та визначити кількість сеансів у цьому місяці минулого року та середню тривалість у хвилинах;" +
    "4.визначити найкоротший сеанс цього місяця та подати інформацію про його тривалість у секундах;\n" +
    "5.для відділу контролю радіо ефіру підготувати звіт з усіх сеансів зв'язку за минулий місяць, із зазначенням тривалістю кожного сеансу за хвилини.");
Found:
int f = int.Parse(Console.ReadLine());
switch (f)
{
    case 1:
        
        Console.WriteLine("Час на одну групу в хвилинах: " + Stream.SpeedGroups(stream));
        goto Found;
    case 2:
        Stream.infoOfStream(stream);
        goto Found;
    case 3:
        Stream.YesterYearStreams(stream);
        goto Found;
    case 4:
        Stream.Months(stream);
        goto Found;
    case 5:
        Stream.Zvit(stream);
        goto Found;
}

struct Stream
{
    public string Name;
    public double Chastota;
    public DateOnly DstartStream;
    public TimeOnly TstartStream;
    public TimeOnly TEndStream;
    public char[] CountGroup;

    public Stream(string name, double chastota, DateOnly dstartStream, TimeOnly tstartStream, TimeOnly tEndStream, char[] countgroup)
    {
        this.Name = name;
        this.Chastota = chastota;
        this.DstartStream = dstartStream;
        this.TstartStream = tstartStream;
        this.TEndStream = tEndStream;
        this.CountGroup = countgroup;
    }

    public static double SpeedGroups(Stream[] streams)
    {
        double result = 0;
        double Hour;
        double Minutes;
        for (int i = 0; i < streams.Length; i++)
        {
            Hour = streams[i].TEndStream.Hour - streams[i].TstartStream.Hour;
            Minutes = streams[i].TEndStream.Minute - streams[i].TstartStream.Minute;
            result = (Hour * 60 + Minutes) / streams[i].CountGroup.Length;
        }
        return result;
    }

    public static void infoOfStream(Stream[] streams)
    {
        Console.WriteLine("Введіть дату яку будемо перевіряти(ДД.ММ.РРРР): ");
        DateTime DateValid = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Введіть Початок діапазону часу що перевіряти(ГГ.ХВ.СС): ");
        TimeOnly FirstTimeValid = TimeOnly.Parse(Console.ReadLine());
        Console.WriteLine("Введіть Кінець діапазону часу що перевіряти(ГГ.ХВ.СС): ");
        TimeOnly EndTimeValid = TimeOnly.Parse(Console.ReadLine());
        for (int i = 0; i < streams.Length; i++)
        {
            if (DateValid.Day == streams[i].DstartStream.Day) 
            {
                if (FirstTimeValid.Hour <= streams[i].TstartStream.Hour && EndTimeValid.Hour >= streams[i].TstartStream.Hour) 
                {
                    if (FirstTimeValid.Minute <= streams[i].TstartStream.Minute && EndTimeValid.Minute >= streams[i].TEndStream.Minute) 
                    {
                        Console.WriteLine($"{DateValid.Date} на вказаному інтервалі часу від {FirstTimeValid.Hour}:{FirstTimeValid.Minute} " +
                            $" до {EndTimeValid.Hour}:{EndTimeValid.Minute} є радіо ефір який починається о {streams[i].TstartStream.Hour}:" +
                            $"{streams[i].TstartStream.Minute}");
                    }
                }
            }
        }
    }

    public static void YesterYearStreams(Stream[] streams)
    {
        int count = 0;
        double result = 0;
        double Hour;
        double Minutes;
        for (int i = 0; i < streams.Length; i++)
        {
            if (DateTime.Now.Year - 1 == streams[i].DstartStream.Year && DateTime.Now.Month == streams[i].DstartStream.Month)
            {
                count++;
            }
        }
        double[] minutes = new double[count];
        for (int i = 0; i < streams.Length; i++)
        {
            if (DateTime.Now.Year - 1 == streams[i].DstartStream.Year && DateTime.Now.Month == streams[i].DstartStream.Month) 
            {
                Hour = streams[i].TEndStream.Hour - streams[i].TstartStream.Hour;
                Minutes = streams[i].TEndStream.Minute - streams[i].TstartStream.Minute;
                minutes[i] = (Hour * 60 + Minutes);  
            }
        }
        for (int j = 0; j < minutes.Length; j++)
        {
            result += minutes[j];
        }
        result = result / count;
        Console.WriteLine($"Того року {DateTime.Now.Month} місяця було ${count} ефірів, в середньому вони йшли на протязі {result} хвилин");
    }

    public static void Months(Stream[] streams)
    {
        double minimum = 9999999;
        double result = 0;
        for (int i = 0; i < streams.Length; i++)
        {
            if (streams[i].DstartStream.Month == DateTime.Now.Month) 
            {
                result = (streams[i].TEndStream.Hour - streams[i].TstartStream.Hour) * 60 * 60 + (streams[i].TEndStream.Minute - streams[i].TstartStream.Minute) *
                60 + (streams[i].TEndStream.Second - streams[i].TstartStream.Second);
                if (result < minimum)
                    minimum = result;
            }
        }
        Console.WriteLine($"в цьому місяці самий короткий ефір длився протягом: {minimum} секунд");
    }

    public static void Zvit(Stream[] streams)
    {
        for (int i = 0; i < streams.Length; i++)
        {
            if (streams[i].DstartStream.Month == DateTime.Now.Month - 1) 
            {
                Console.WriteLine($"Назва ефіру: {streams[i].Name} на частоті {streams[i].Chastota}\n" +
                    $"Дата ефіру: {streams[i].DstartStream} та час початку {streams[i].TstartStream}\n" +
                    $"Час завершення ефіру {streams[i].TEndStream}\n" +
                    $"Кількість груп: {streams[i].CountGroup.Length}\n\n");
            }
        }
    }
}
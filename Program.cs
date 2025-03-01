using Gyak.Game;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Gyak;

public class Program
{
    public static async Task Main(string[] args)
    {
        Oroklodes();
        await ElsoAsyncFgv();
        //await HarmadikAsyncFgv("text.txt");

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();

	}

    static void Oroklodes()
    {
        Proba proba = new();

        proba.Tag1();
        proba.Tag2();
        Proba.TagStatic();
        //Proba.StaticText;

        Settings.Create(3,3,3);

        Kor kor = new();
        kor.Sugar = 10;
        var terulet = kor.Teruletszamitas();

        Teglalap teglalap = new();
        teglalap.Oldal1 = 5;
		teglalap.Oldal2 = 10;
        terulet = teglalap.Teruletszamitas();

        Negyzet negyzet = new();
        negyzet.Oldal = 10;
        terulet = negyzet.Teruletszamitas();


        Sikidom[] sikidomok = new Sikidom[] { kor, teglalap, negyzet };

        foreach (var sikidom in sikidomok)
        {
            var t = sikidom.Teruletszamitas();
        }  
    }

    public static async Task ElsoAsyncFgv()
    {
    }
    public static async Task<string> MasodikAsyncFgv()
    {
        return "alma";
    }
    public static async Task<string> HarmadikAsyncFgv(string filename)
    {
        var text = await File.ReadAllLinesAsync(filename);
        return text[0];
    }
}

public class Proba
{
    public int MyProperty { get; set; }
    public string Text { get; set; }
    public static string StaticText { get; set; }

    public Proba()
    {
        
    }

    public void Tag1()
    {
    }
	public int Tag2()
	{
        return DateTime.Today.Year;
	}

    public static int TagStatic() { return DateTime.Today.Month; }
}

public class Sikidom
{
    public virtual decimal Teruletszamitas() { return 0; }
}

public class Kor : Sikidom 
{
    public decimal Sugar { get; set; }

    public override decimal Teruletszamitas()
    {
        return 3.14m*Sugar*Sugar;
    }

}

public class Teglalap : Sikidom
{
    public decimal Oldal1 { get; set; }
	public decimal Oldal2 { get; set; }

    public override decimal Teruletszamitas()
    {
        return Oldal1*Oldal2;
    }
}

public class Negyzet : Sikidom
{
    public decimal Oldal { get; set; }

	public override decimal Teruletszamitas()
	{
		return Oldal * Oldal;
	}
}

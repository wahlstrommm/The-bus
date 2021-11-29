/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */
using System;
//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil
namespace Bussen
{
	class Buss
	{
		public int[] passagerare = new int[25]; //antal "platser" i bussen
		public int antal_passagerare = 0; //startvärde bussen startar "tom" och ja chaffören är inte inräknad.
		public int man = 0;//startvärde på männen på bussen som den startar "tom"
		public int kvinna = 0; //startvärdet på kvinnor


		public void Run()// KLAR
		{
			Console.WriteLine("Welcome to the awesome Buss-simulator");
			int key = 0; //använder denna som en "menyknapp"


			//att lägger case 7 en exit (avlsuta program i case 7) resten
			do
			{
                try { 
				Console.WriteLine("\nVälj ett alternativ:"); //meny
				Console.WriteLine("1. Lägg till passagerare på bussen:");
				Console.WriteLine("2. Skriv ut de som sitter på bussen:");
				Console.WriteLine("3. Skriv den totala åldern på passagerarna:");
				Console.WriteLine("4. Ta fram den äldsta passagerare på bussen:");
                Console.WriteLine("5. Beräkna genomsnittliga åldern på alla passagerarna");
				Console.WriteLine("6. Skriv ut hur många män och kvinnor som sitter på bussen");
                Console.WriteLine("7. Sök ålder på passagerare");
                Console.WriteLine("8. Sortera bussen");
				Console.WriteLine("9. Avsluta programmet");
				key = Convert.ToInt32(Console.ReadLine());
				switch (key)
				{
					case 1:
						add_passenger();
						break;
					case 2:
						print_buss();
						break;
					case 3:
						calc_total_age();
						break;
					case 4:
						max_age();
						break;
					case 5:
						calc_average_age();
						break;
					case 6:
							print_sex();
						break;
					case 7:
						find_age();
							break;
					case 8:
							sort_buss();
							break;
					case 9:
						Console.WriteLine("Du valde att avsluta programmet!");
						Environment.Exit(0); //stänger ner programmet
						break;
					default:
                          Console.WriteLine("Ogiltigt tecken");
						break;
				}
				}
                catch //Exception ifall användaren inte skulle använda sig av en siffra.
				{
                    Console.WriteLine("Du skrev in en bokstav försök med en siffra! ");
                    //Console.WriteLine(e);
                }
			} while (true);
			//Här ska menyn ligga för att göra saker
			//Jag rekommenderar switch och case här
			//I filmen nummer 1 för slutprojektet så skapar jag en meny på detta sätt.
			//Dessutom visar jag hur man anropar metoderna nedan via menyn
			//Börja nu med att köra koden för att se att det fungerar innan ni sätter igång med menyn.
			//Bygg sedan steg-för-steg och testkör koden.
		}

		//Metoder för betyget E

		public void add_passenger()//ska kunna lägga till passagerare med ålder och kön i min vektor.
		{
           
			if (antal_passagerare < 24) // Max gränsen är 25 som bussen inte rymmer mer.
            {
				Console.WriteLine("Skriv in ålder för passagerare: ");
				passagerare[antal_passagerare] = Convert.ToInt32(Console.ReadLine()); // tar in vad användaren skriver in.
				if (passagerare[antal_passagerare] >= 0) //om åldern är postiv så läggs den till
				{
					++antal_passagerare;//lägger till en passagare på "en plats i bussen"
				}
                try { 
				Console.WriteLine("Är det en man eller kvinna som stiger på bussen? tryck 1 för man 2 för kvinna!");
				int passKon = Convert.ToInt32(Console.ReadLine()); //läser in användrens val
                
				if (passKon == 1 ) //om det trycker 1 så läggs en man till.
                {
					++man;
                }
                else if(passKon == 2) // om de skriver 2 så läggs en kvinna på.
                {
					++kvinna;
                }
                    else //om de skulle skriva i nåt annat än 1 eller 2 så tar en passagerare bort från bussen för att alla ska ha kön.
                    {
						--antal_passagerare;
                    }
				}
                catch //ifall nåt skulle gå fel
				{
					Console.WriteLine("Du skrev in en bokstav försök med en siffra! ");
				}
			} 
			else
            {
                Console.WriteLine("Bussen är full!"); //om det skulle vara att det inte finns flera lediga platser.
            }
			

			//passagerare = new passenger[25];
			//passenger[] passagerare = new passenger[25];
			//Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
			//Om bussen är full kan inte någon passagerare stiga på
		}

		public void print_buss()//Ska skriva ut värdet i min vektor bussen.
		{
			int LedigaPlatser = 25 - antal_passagerare; // som ger användaren svaret hur många lediga platser det finns kvar.
			for (int i=0; i < passagerare.Length; i++)
            {
                if (passagerare[i] > 0)
                {
					Console.WriteLine("\nPassagerare " + (i+1) + " är " + passagerare[i] + " år gammal!");
				}
                
            }
			//Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
			Console.WriteLine("Det finns nu " + LedigaPlatser + " platser lediga.\n");
		}

		public void calc_total_age()//Räkna ut den totala åldern på min passagerare i min vektor bussen.
		{
				int passAge = 0;
				for (int z = 0; z < passagerare.Length; ++z) //Lopp för att ta reda på den totala åldern på passagerarna så länge z är mindre än längden på vektorn.
				{
					passAge += passagerare[z]; //adderar in
				}
			Console.WriteLine("Den totala åldern är " + passAge);

			//Beräkna den totala åldern. 
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
		}

		//Metoder för betyget C

		public void calc_average_age()//Räkna ut den genomsnittliga åldern på min vektor bussen.
		{
			int sum = 0;
			int i = 0;
			float average = 0.0f;
			for (i=0; i < passagerare.Length; i++)//loop genom alla platser
            {
				sum += passagerare[i];
            }
			average = (float)sum / antal_passagerare; // ålder genom passagerare
			Console.WriteLine("Genomsnittliga åldern är " + average);
            
			//double avg = Queryable.Average(antal_passagerare.AsQueryable());
			//Betyg C
			//Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
		}

		public void max_age()// Finner samt skriver ut maxåldern på passageraren i min vektor bussen.
		{
			int maxAge = 0; //startvärde
			for (int i = 1; i < passagerare.Length; i++)
            {
                if (passagerare[i] > maxAge) // om passagerare är större än maxAge
				{
					maxAge = passagerare[i]; //Tar värdet från min vektor och lägger den i min maxAge.
                }
            }
            Console.WriteLine("Den äldsta på bussen är " + maxAge + " år gammal!");

			//Betyg C
			//ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
		}

		public void find_age()
		{
			int range = -1; //ålder ingen kan ha -1 men kanske finns en bebis med åldern 0
			int hittaAge = 0;
            Console.WriteLine("Vilken ålder söker du?");
			range = Convert.ToInt32(Console.ReadLine()); //tar in vad användare söker efter
			for (int i = 0; i < passagerare.Length; i++)
			{
				if (passagerare[i] == range) //om värdet från vektorn stämmer med det användaren har skrivit in
				{
					Console.WriteLine("\nPassagerare " + (i + 1) + " är " + passagerare[i] + " år gammal!");
					hittaAge++;
				}

			}
            if (hittaAge > 0) //Om hittaAge är större än noll skrivs detta ut (alltså att man har begärt rätt ålder)
            {
				Console.WriteLine("Det finns " + hittaAge + " passagerare som är " + range + " år.\n");
			}
            else
            {
                Console.WriteLine("Det finns inga passagerare med åldern " + range );
            }
			


			//Visa alla positioner med passagerare med en viss ålder
			//Man kan också söka efter åldersgränser - exempelvis 55 till 67
			//Betyg C
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)

		}

		public void sort_buss()
		{

			int temp; //starvärde
			for (int j = 0; j <= passagerare.Length - 2; j++) //bubblesort har jag implementerad ifrån https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash
			{
                for (int i = 0; i <=passagerare.Length - 2; i++ )
                {
					if(passagerare[i] > passagerare[i + 1])
                    {
						temp = passagerare[i + 1];
						passagerare[i + 1] = passagerare[i];
						passagerare[i] = temp;
                    }
                }
            }
            Console.WriteLine("\nNu är passagerarna sorterad efter ålder i bussen"); //Tom rad så man inte misstar ens menyval för åldern
			foreach (int p in passagerare)
            {
                if (p > 0)
                {
					Console.WriteLine(p + " år"); //skriver ut 
				}
				
            }
			
			
			
			//Sortera bussen efter ålder. Tänk på att du inte kan ha tomma positioner "mitt i" vektorn.
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 159)
			//Man ska kunna sortera vektorn med bubble sort
		}

		//Metoder för betyget A


		public void print_sex() //skriver ut hur många män och kvinnor det finns i min vektor bussen. Valet av könen sker när man lägger till passagerare i metoden add_passenger.
		{

            Console.WriteLine("Det är " + man + " st män på bussen" + " och " + kvinna + " st kvinnor");
			
			//Betyg A
			//Denna metod är nödvändigtvis inte svårare än andra metoder men kräver att man skapar en klass för passagerare.
			//Skriv ut vilka positioner som har manliga respektive kvinnliga passagerare.
		}
		public void poke()
		{
			//Betyg A
			//Vilken passagerare ska vi peta på?
			//Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
			//Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
			//Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.
		}

		public void getting_off()
		{
			//Betyg A
			//En passagerare kan stiga av
			//Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
			//Sortering blir också klurigare
			//Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
			//.. som tillhörde den som lämnade bussen, får flytta fram en plats.
			//Då finns aldrig någon tom plats mellan passagerare.
		}
	}

	class Program
	{
		public static void Main(string[] args)
		{
			//Skapar ett objekt av klassen Buss som heter minbuss
			//Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
			var minbuss = new Buss();
			minbuss.Run();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
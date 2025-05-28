

using ConsoleApp2;

Coches c = new Coches("1234AAA","MIBASTI1"); // CONSTRUCTOR
//c.matricula = "ABC4321"; // ASIGNO
  c.setMatricula("1234BBB"); // LLAMO AL METODO
// Console.WriteLine(c.matricula); // RECUPERO
Console.WriteLine(c.getMatricula()); // RECUPERO
Console.WriteLine(c.dameElPescao()); // RECUPERO

Coches c2 = new Coches("BASTIDOR2"); // CONTRUCTOR2

Coches c3 = new Coches(123);

// Crear el aparcamiento

Aparcamiento parkingMadrid = new Aparcamiento();
if (parkingMadrid.comprobarPlaza(1))
{
    parkingMadrid.Aparcar(c, 1);
    Console.WriteLine("Aparcado");
    parkingMadrid.desAparcar(1);
    if (parkingMadrid.comprobarPlaza(1))
    {
        parkingMadrid.Aparcar(c, 1);
        Console.WriteLine("Aparcado");
    }
    else
    {
        Console.WriteLine("OCUPADO");
    }

}

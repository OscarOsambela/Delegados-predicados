using System;
using System.Collections.Generic;

  //Delegados predicados
  //devuelven solo true o false
  //muy utilizados para filtrar lista de valores comprobando si una condicion es cierta para un valor dado  

class MainClass {
  public static void Main (string[] args) {
		List<int>listaNumeros = new List<int>();
    //agregamos un rango de valores
    listaNumeros.AddRange(new int[]{1,2,3,4,5,6,7,8,9,10});

    //delegado predicado
		Console.WriteLine("Dame los números pares");
    Predicate<int> predicado = new Predicate<int>
		(DamePares);

    //predicado arroja una lista para ello hay que crear una lista}
    List<int> numPares = listaNumeros.FindAll(predicado);
    foreach(int num in numPares){
      Console.WriteLine(num);
    }

    //ejemplo con objetos de clase
    List<Personas> gente = new List<Personas>();
    Personas P1 = new Personas();
    P1.Nombre = "Oscar";
    P1.Edad = 40;
    Personas P2 = new Personas();
    P2.Nombre = "Francisco";
    P2.Edad = 2;
    Personas P3 = new Personas();
    P3.Nombre = "Vernita";
    P3.Edad = 6;

    gente.AddRange(new Personas[] {P1, P2, P3});

    //predicado
    Predicate<Personas> p = new Predicate<Personas>(ExisteNombre);
    bool existe = gente.Exists(p);
    /*
    //pregunta 1
    Console.WriteLine("1.Existe personas llamadas Oscar?");
    if(existe) Console.WriteLine("Si");
    else Console.WriteLine("No");
    */
    //pregunta 2
    Console.WriteLine("2.Existe personas llamadas Pamela?");
    if(existe) Console.WriteLine("Si");
    else Console.WriteLine("No");

    //predicado 2
    Predicate<Personas> e = new Predicate<Personas>(ExisteEdad);
    bool existeEdad = gente.Exists(e);
    /*
    Console.WriteLine("Hay gente menor de 18 años?");
    if(existeEdad) Console.WriteLine("Si");
    else Console.WriteLine("No");
    */
    Console.WriteLine("Hay gente mayor de 90 años?");
    if(existeEdad) Console.WriteLine("Si");
    else Console.WriteLine("No");
 }
  //delegado
  static bool ExisteNombre(Personas persona){
    //pregunta 1
    if(persona.Nombre == "Pamela") return true;
    else return false;
  }
  static bool ExisteEdad(Personas edadPersona){
    if(edadPersona.Edad > 90) return true;
    else return false;
  }
 
  //metodo
  static bool DamePares(int num){
    if(num % 2 == 0) return true;
    else return false; 
  }

  class Personas{
    private string nombre;
    private int edad;
    //crear propiedades para cada campo de clase
    public string Nombre{
      get=>nombre;
      set=>nombre = value;
      }
    public int Edad{
      get=>edad;
      set=>edad = value;
    }
  }


}
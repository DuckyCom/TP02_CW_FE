namespace TP02_CW_FE;
class Program
{
    static List<persona> listPersonas = new List<persona>();
    static void Main(string[] args)
    {
        bool Repeticion = true;
        int menu;
        string CalidaDespedida = "chau *insulto censurado*";
        while(Repeticion)
        {
        menu = listaFunciones();
            limpiarConsola();
         switch (menu)
        {
            case 1:
            cargarPersona();
            limpiarConsola();
                break;
            case 2:
            EstadisticasDelCenso();
            limpiarConsola();
                break;
            case 3:
            BuscarPersona(IngresarEntero("Ingrese el DNI que quiere buscar"));
            limpiarConsola();
                break;
            case 4:
                  ModificarMail(IngresarEntero("Ingrese el DNI que quiere buscar"));
            limpiarConsola();   
                break;

            case 5:
                    Console.WriteLine(CalidaDespedida);
                    Repeticion = false;
                break;
             
        }
        }
    }
    #region frontend

    static int listaFunciones()
    {
        string Msj_inicio = "Bienvenido, que funcion desea usar?\n";
        string Funciones = ("1. Cargar Nueva Persona\n"
         + "2. Obtener Estadísticas del Censo\n"
         + "3. Buscar Persona\n"
         + "4. Modificar Mail de una Persona.\n"
         + "5. Salir del programa\n");
        Console.WriteLine(Msj_inicio + Funciones);
        return int.Parse(Console.ReadLine());
    }
    static int IngresarEntero(string mensaje)
    {
            Console.WriteLine(mensaje);
            return int.Parse(Console.ReadLine());
    }
    static int IngresarEnteroVerif(string mensaje)
    {
            bool verif = true;
            Console.WriteLine(mensaje);
            int retorn = int.Parse(Console.ReadLine());
            foreach (persona dni in listPersonas) if (retorn == dni.DNI) verif = false;
            while (!verif)
            {
                Console.WriteLine("Error, ingresar de nuevo");
                retorn = int.Parse(Console.ReadLine());
                foreach (persona dni in listPersonas) if (retorn == dni.DNI) verif = false;
            }
            return retorn;
    }
    static string IngresarString(string mensaje)
    {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
    }
    static DateTime IngresarDateTime(string mensaje)
        {
            Console.WriteLine(mensaje);
            return DateTime.Parse(Console.ReadLine());
        }
    static void limpiarConsola()
    {
        Console.WriteLine("Presione una tecla para contiunar");
        Console.ReadLine();
        Console.Clear();
    }   
    #endregion
    #region backend
    static void cargarPersona()
    {
        listPersonas.Add(new persona(IngresarEnteroVerif("Ingrese el DNI"),
         IngresarString("Ingrese el apellido"), IngresarString("Ingrese el nombre"),
          IngresarDateTime("Ingrese la fecha de nacimiento"), IngresarString("Ingrese el email")));
    }
    static void EstadisticasDelCenso()
    {
        int personas = listPersonas.Count;
        int puedenVotar = 0;
        int edades = 0;
        foreach (persona item in listPersonas)
        {
            if (item.PuedeVotar()) puedenVotar++; 
            edades += item.ObtenerEdad();
        }
        Console.WriteLine("Estadisticas del censo:\n" + 
        "Cantidad de personas: " + personas +
        "\nCantidad de Personas habilitadas para votar: " + puedenVotar +
        "\nPromedio de edad: " + (edades/personas));
    } 

    static void BuscarPersona(int DNIIngresado)
    {
        bool Encontrado = false;
        foreach (persona item in listPersonas)
        {
            
            if(DNIIngresado == item.DNI)
            {
            Encontrado = true;
            Console.WriteLine("Datos del DNI ingresado:\n" + "Apellido: " + item.Apellido
            + "\nNombre: " + item.Nombre
            + "\nDNI: " + item.DNI
            + "\nFecha de nacimiento: " + item.FechaDeNacimiento.ToShortDateString()
            + "\nEdad: " + item.ObtenerEdad());
            if(item.PuedeVotar())Console.WriteLine("Puede votar");
            else Console.WriteLine("No puede votar");
            }
        }
        if(!Encontrado)
        {
            Console.WriteLine("No se encuentra el DNI");
        }
    }

      static void ModificarMail(int DNIIngresado)
    {
        bool Encontrado = false;
        foreach (persona item in listPersonas)
        { 
            if(DNIIngresado == item.DNI)
            {
            Encontrado = true;
            item.Email= IngresarString("Ingrese el mail que quiera actualizar (mail actual: " + item.Email +")");
            }
        }
        if(!Encontrado)
        {
            Console.WriteLine("No se encuentra el DNI");
        }
    }
    #endregion
}

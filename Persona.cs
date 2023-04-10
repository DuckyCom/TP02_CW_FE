class persona
{
    #region atributos
     public int DNI {get; private set;}
     public string Apellido {get; set;}
     public string Nombre {get; set;}
     public DateTime FechaDeNacimiento {get; set;}
     public string Email {get; set;}

    #endregion
    #region constru
    public persona(int dni, string apellido, string nombre, DateTime fechaDeNacimiento, string email)
    {
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaDeNacimiento = fechaDeNacimiento;
        Email = email;
    }
    #endregion
    #region metodos
    public bool PuedeVotar()
    {
        bool retorn;
        int edad = ObtenerEdad();
        if (edad < 16) retorn = false; 
        else retorn = true;
        return retorn;
    }
    public int ObtenerEdad()
    {
        int retorn;
        retorn = (int) ((DateTime.Now - FechaDeNacimiento).TotalDays/365.242199);
        return retorn;
    }
    #endregion 
//static list<persona> listPersonas = new list<persona>();

}
public class Personajes{

    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechaDeNacimiento;
    private int edad;
    private int salud;
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }


    public void MostrarDatos(){
        Console.WriteLine("\n-----Información sobre el personaje: "+apodo+"-----");
        Console.WriteLine("\nNombre del personaje: " + nombre);
        Console.WriteLine("\nTipo del personaje: " + tipo);
        Console.WriteLine("\nFecha de nacimietno del personaje: " + fechaDeNacimiento);    
        Console.WriteLine("\nEdad: "+edad);
        Console.WriteLine("\nSalud: "+salud);
    }

    public void MostrarCaracteristicas(){
        Console.WriteLine("\nVelocidad: "+velocidad+"\tDestreza: "+destreza+"\tFuerza: "+fuerza);
        Console.WriteLine("\nNivel: "+nivel+"\tArmadura: "+armadura);
    }

    public void MostrarEnListado(){
        Console.WriteLine("------");
        Console.WriteLine("\n" + apodo + " " + tipo + " Salud: " + salud);
    }


}
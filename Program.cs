using System;
using System.Collections.Generic;

namespace rpg_2022_bobadillajuan
{
    class Program
    {
        static int Main(string[] args){

            List <Personajes> TeamRadiant = new List<Personajes>();
            List <Personajes> TeamDire = new List<Personajes>();

            CargarDatos(TeamRadiant);
            foreach (Personajes personajeX in TeamRadiant)
            {
                personajeX.MostrarDatos();
                personajeX.MostrarCaracteristicas();
            }

            return 0;
        }

        public static void CargarDatos(List <Personajes> Team){
            int controlador = 0;

            do{
            Personajes AuxTeam = new Personajes();
            Console.WriteLine("\nIngrese el nombre del personaje: ");
            AuxTeam.Nombre = ControlString();

            Console.WriteLine("\nIngrese el apodo del personaje: ");
            AuxTeam.Apodo = ControlString();

            Console.WriteLine("\nSeleccione el tipo de personaje: ");
            Console.WriteLine("\n1) Carry.\n2)Midlane. \n3)Offlane. \n4)Soft-Support \n5)Hard-Support");
            int tipo=0;
            do{
            tipo = Convert.ToInt32(Console.ReadLine());
            switch (tipo)
            {
                case 1: AuxTeam.Tipo = "Carry";
                break;
                case 2: AuxTeam.Tipo = "Midlane";
                break;
                case 3: AuxTeam.Tipo = "Offlane";
                break;
                case 4: AuxTeam.Tipo = "Soft-Support";
                break;
                case 5: AuxTeam.Tipo = "Hard-Support";
                break;
            }
            }while(tipo > 5 || tipo < 1);
            
            //No sé como controlar una fecha :)
            Random numeroRandom = new Random();
            AuxTeam.FechaDeNacimiento = Convert.ToDateTime(numeroRandom.Next(1,31) + "/" + numeroRandom.Next(1,12) + "/" + numeroRandom.Next(1722,2022));
            //Por ahora independiente uno del otro
            AuxTeam.Edad = numeroRandom.Next(0, 300);
            AuxTeam.Salud = 100;
            AuxTeam.Velocidad = numeroRandom.Next(1, 100);
            AuxTeam.Destreza = numeroRandom.Next(1, 5);
            AuxTeam.Fuerza = numeroRandom.Next(1, 10);
            AuxTeam.Nivel= numeroRandom.Next(1, 10);
            AuxTeam.Armadura = numeroRandom.Next(1, 10);

            Team.Add(AuxTeam);

            //Control para seguir agregando
            Console.WriteLine("\n¿Desea agregar otro personaje?\n1) Sí. ---- 2) No.");
            do{controlador = Convert.ToInt32(Console.ReadLine());}while(controlador != 1 && controlador !=2);


            }while(controlador == 1);

        }

        public static string ControlString(){

            string? buff;
            do{
            buff = Console.ReadLine();
            } while (string.IsNullOrEmpty(buff));

            return buff;
        }

        // Esto lo puedo hacer aquí con un bucle para tener toda la lista, o usar definir un método dentro de la clase
        // public static void MostrarDatos(List <Personajes> Team){

        //     for (int i = 0; i < Team.Count; i++)
        //     {
        //     Console.WriteLine("\nApodo del personaje: " + Team[i].Apodo);
        //     Console.WriteLine("\nNombre del personaje: " + Team[i].Nombre);
        //     Console.WriteLine("\nTipo del personaje: " + Team[i].Tipo);
        //     Console.WriteLine("\nFecha de nacimietno del personaje: " + Team[i].FechaDeNacimiento);




        //     }
            
        // }

    }
}

            // do{
            // Console.WriteLine("Ingrese el nombre del personaje: ");
            // buff = Console.ReadLine();
            // } while (string.IsNullOrEmpty(buff));

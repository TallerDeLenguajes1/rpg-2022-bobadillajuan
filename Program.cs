using System;
using System.Text.Json;
using System.Collections.Generic;

namespace rpg_2022_bobadillajuan
{
    class Program
    {
        static int Main(string[] args){

            List <Personajes> TeamRadiant = new List<Personajes>();
            List <Personajes> TeamDire = new List<Personajes>();
            Personajes PeleadorTeamRadiant = new Personajes();
            Personajes PeleadorTeamDire = new Personajes();


            int opcion = 0;
            Console.WriteLine("\n----- Bienvenido a DotA -----");
            Console.WriteLine("\nPor favor, elija una opción: \n");
            Console.WriteLine("1) Jugar.");
            Console.WriteLine("2) Historial de partidas.");
            Console.WriteLine("3) Salir.");
            opcion = Convert.ToInt32(Console.ReadLine());

            do{
            switch (opcion)
            {
                case 1: 
                    break;

                case 2: 
                    break;

                default:
                Console.WriteLine("\nPor favor ingrese nuevamente la opcion");
                    break;

            }
            }while(opcion != 3);


            //Carga de peleadores
            Console.WriteLine("\n--- Carga de personajes para el Team Radiant ---");
            CargarDatos(TeamRadiant);
            SerializarEquipoCargado(TeamRadiant);

            foreach (Personajes personajeX in TeamRadiant)
            {
                personajeX.MostrarDatos();
                personajeX.MostrarCaracteristicas();
            }



            Console.WriteLine("\n--- Carga de personajes para el Team Dire ---");
            CargarDatos(TeamDire);
            SerializarEquipoCargado(TeamDire);
            foreach (Personajes personajeX in TeamDire)
            {
                personajeX.MostrarDatos();
                personajeX.MostrarCaracteristicas();
            }

            //Pelea
            Console.WriteLine("\n--- ¡Empieza la batalla! Por favor, elige bien tu personaje. ---");
            Console.WriteLine("\n¡Presione enter para continuar!");
            Console.ReadLine();

            Console.WriteLine("\nElección de TEAM RADIANT: ");
            PeleadorTeamRadiant = Peleador(TeamRadiant);
            Console.WriteLine("\nElección de TEAM DIRE: ");
            PeleadorTeamDire = Peleador(TeamDire);



            Console.WriteLine("\n------ Peleador Radiant: ------");
            PeleadorTeamRadiant.MostrarDatos();
            Console.WriteLine("\n------ Peleador Dire: ------");
            PeleadorTeamDire.MostrarDatos();

            Batalla(PeleadorTeamRadiant, PeleadorTeamDire);
            //Por alguna razón una vez que salimos de aquí, el Personaje en la lista original tiene su nombre cambiado a perdedor, 
            //No tan solo PeleadorTeamX.


            if(PeleadorTeamDire.Nombre == "Perdedor")
            PostBatalla(PeleadorTeamDire, TeamDire);

            if(PeleadorTeamRadiant.Nombre == "Perdedor")
            PostBatalla(PeleadorTeamRadiant, TeamRadiant);


            //Controlamos los resultados de la batalla
            Console.WriteLine("\n------ Peleadores Radiant Restantes: ------");
            foreach (Personajes personajeX in TeamRadiant)
            {
                personajeX.MostrarDatos();
                personajeX.MostrarCaracteristicas();
            }

            Console.WriteLine("\n------ Peleadores Dire Restantes: ------");
            foreach (Personajes personajeX in TeamDire)
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

            //Control para seguir agregando. Por ahora sin límites.
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

        public static Personajes Peleador (List <Personajes> Team){
            int controlPeleador = 0;
            Personajes Peleador = new Personajes();
            foreach (var personaje in Team)
            {
                personaje.MostrarEnListado();
                do{
                Console.WriteLine("\n¿Desea que este personaje se una a la batalla?\n1) Sí. ---- 2) No.");
                controlPeleador = Convert.ToInt32(Console.ReadLine());
                if (controlPeleador == 1){
                Peleador = personaje;
                break;
                }
                }while(controlPeleador != 1 && controlPeleador !=2);
                if (controlPeleador == 1)
                break;
            }
            return Peleador;
        }

        public static void Batalla(Personajes teamRadiant, Personajes teamDire){

            Console.WriteLine("\n¡Hora de la batalla!");
            if (teamRadiant.Fuerza >= teamDire.Fuerza){
                Console.WriteLine("\n¡Gana el TEAM RADIANT!");
                teamDire.Nombre = "Perdedor";
                SerializarPersonajeGanador(teamRadiant);

                //Por ahora no voy a cambiar stats ni evaluaré otras formas de batalla.
            }else{
                Console.WriteLine("\n¡Gana el TEAM DIRE!");
                teamRadiant.Nombre = "Perdedor";
                SerializarPersonajeGanador(teamDire);

            }
        }

        public static void PostBatalla(Personajes perdedor, List<Personajes> teamPerdedor){

            int controlador = 0;
            while (controlador < teamPerdedor.Count)
            {
                if (teamPerdedor[controlador].Apodo == perdedor.Apodo)
                {
                    teamPerdedor.Remove(teamPerdedor[controlador]);
                }
                controlador++;
            }
        }

        public static void SerializarPersonajeGanador(Personajes personajeGanador){
        //Creamos una ruta y donde estará nuestro JSON
        string path;
        path = @"C:\Users\Usuario\Desktop\ArchivoJSON\ganadores.JSON";

        using (var NuevoArchivoJson = new FileStream(path, FileMode.Create))
        {
        using(StreamWriter sw = new StreamWriter(NuevoArchivoJson)){
            string? serializarArchivos = JsonSerializer.Serialize(personajeGanador);
            sw.WriteLine(serializarArchivos);
            sw.Close();
        }
        }


        }

        public static void SerializarEquipoCargado(List <Personajes> team){
        //Creamos una ruta y donde estará nuestro JSON
        string path;
        path = @"C:\Users\Usuario\Desktop\ArchivoJSON\jugadores.JSON";

        using (var NuevoArchivoJson = new FileStream(path, FileMode.Create))
        {
        using(StreamWriter sw = new StreamWriter(NuevoArchivoJson)){
            string? serializarArchivos = JsonSerializer.Serialize(team);
            sw.WriteLine(serializarArchivos);
            sw.Close();
        }
        }


        }
        

    }
}
